using DoctorManagmentApp.Configurations;
using DoctorManagmentApp.Exceptions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;

namespace DoctorManagmentApp.Helpers
{
    public class ApiHelper<T>
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly AppSettings appSettings;

        public ApiHelper(IHttpClientFactory httpClientFactory, IOptions<AppSettings> appSettings)
        {
            _httpClientFactory = httpClientFactory;
            this.appSettings = appSettings.Value;
        }

        public async Task<T> CallApiAsync(string apiUrl)
        {
            using (var client = _httpClientFactory.CreateClient())
            {
                // Call the OAuth authentication API to get a JWT token
                var token = await GetJwtTokenAsync();

                // Set the JWT token in the Authorization header of the HttpClient
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(jsonResponse);
                }
                else
                {
                    throw new ExternalApiRequestException($"Call to {response.RequestMessage.RequestUri} External API has failed with status code: {response.StatusCode}");
                }
            }
        }

        private async Task<string> GetJwtTokenAsync()
        {
            using (var tokenClient = new HttpClient())
            {
                var tokenRequest = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("grant_type", "client_credentials"),
                    new KeyValuePair<string, string>("client_id", appSettings.AuthApi.ClientId),
                    new KeyValuePair<string, string>("client_secret", appSettings.AuthApi.ClientSecret),
                    new KeyValuePair<string, string>("audience", appSettings.AuthApi.Audience),
                };

                var tokenRequestContent = new FormUrlEncodedContent(tokenRequest);

                var tokenResponse = await tokenClient.PostAsync($"{appSettings.AuthApi.Authority}/oauth/token", tokenRequestContent);
                if (tokenResponse.IsSuccessStatusCode)
                {
                    var tokenContent = await tokenResponse.Content.ReadAsStringAsync();
                    dynamic json = JsonConvert.DeserializeObject(tokenContent);
                    var jwtToken = json["access_token"];
                    return jwtToken;
                }
                else
                {
                    throw new HttpRequestException($"Token request failed with status code: {tokenResponse.StatusCode}");
                }
            }
        }

    }
}
