using DoctorManagmentApp.Exceptions;
using Newtonsoft.Json;

namespace DoctorManagmentApp.Helpers
{
    public class ApiHelper<T>
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ApiHelper(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> CallApiAsync(string apiUrl)
        {
            using (var client = _httpClientFactory.CreateClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(jsonResponse);
                }
                else
                {
                    throw new ExternalApiRequestException($"External API request failed with status code: {response.StatusCode} and content: {response.Content}");
                }
            }
        }
    }
}
