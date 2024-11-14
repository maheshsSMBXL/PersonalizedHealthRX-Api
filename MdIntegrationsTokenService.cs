using Newtonsoft.Json;
using PersonalizedHealthRX_Api.Models;
using System.Net.Http.Headers;

namespace PersonalizedHealthRX_Api
{
    public class MdIntegrationsTokenService
    {
        private readonly HttpClient _httpClient;

        public MdIntegrationsTokenService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MdIntegrationsTokenResponse> GetTokenAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.mdintegrations.com/v1/partner/auth/token");

            var body = new
            {
                grant_type = "client_credentials",
                client_id = "7243309d-1338-4809-ab2d-947e13e04893",
                client_secret = "UgNmWMuuXaQnBpR1kXuNOVfMyqLjWMJVVpWj06Y7",
                scope = "*"
            };

            request.Content = new StringContent(JsonConvert.SerializeObject(body), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<MdIntegrationsTokenResponse>(responseContent);
        }
        public async Task<string> GetPatientDetailsAsync(string patientId, string accessToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.mdintegrations.com/v1/partner/patients/{patientId}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
