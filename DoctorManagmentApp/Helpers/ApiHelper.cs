using DoctorManagmentApp.Configurations;
using DoctorManagmentApp.Exceptions;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace DoctorManagmentApp.Helpers
{
    public class ApiHelper<T>
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ApiHelper(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> CallApiAsync(ExternalApi apiSettings)
        {
            using (var client = _httpClientFactory.CreateClient())
            {
                if (apiSettings.IsAuthenticationRequired)
                {
                    // Call the OAuth authentication API to get a JWT token
                    var token = await GetJwtTokenAsync(apiSettings);

                    // Set the JWT token in the Authorization header of the HttpClient
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                HttpResponseMessage response = await client.GetAsync(apiSettings.Uri);

                if (!response.IsSuccessStatusCode)
                    throw new ExternalApiRequestException($"Call to {response.RequestMessage.RequestUri} External API has failed with status code: {response.StatusCode}");

                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(jsonResponse);
            }
        }

        private async Task<string> GetJwtTokenAsync(ExternalApi apiSettings)
        {
            using (var tokenClient = _httpClientFactory.CreateClient())
            {
                var tokenRequest = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("grant_type", apiSettings.AuthApi.GrantType),
                    new KeyValuePair<string, string>("client_id", apiSettings.AuthApi.ClientId),
                    new KeyValuePair<string, string>("client_secret", apiSettings.AuthApi.ClientSecret),
                    new KeyValuePair<string, string>("audience", apiSettings.AuthApi.Audience),
                };

                var tokenRequestContent = new FormUrlEncodedContent(tokenRequest);

                var response = await tokenClient.PostAsync($"{apiSettings.AuthApi.Authority}/oauth/token", tokenRequestContent);
                if (!response.IsSuccessStatusCode)
                    throw new HttpRequestException($"Token request to {response.RequestMessage.RequestUri} failed with status code: {response.StatusCode}");

                var tokenContent = await response.Content.ReadAsStringAsync();
                dynamic json = JsonConvert.DeserializeObject(tokenContent);
                var jwtToken = json["access_token"];
                return jwtToken;
            }
        }

    }
}
