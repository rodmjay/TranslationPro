using System.Text.Json;
using TranslationPro.Shared.Applications;

namespace TranslationPro.App.Services
{
    public class ApplicationServiceProxy : IApplicationServiceProxy
    {
        private readonly HttpClient _httpClient;

        public ApplicationServiceProxy(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ApplicationDto>> GetApplications()
        {
            return await JsonSerializer.DeserializeAsync<List<ApplicationDto>>
                (await _httpClient.GetStreamAsync($"v1.0/applications"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
