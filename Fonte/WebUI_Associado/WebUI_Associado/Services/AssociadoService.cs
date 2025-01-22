using Newtonsoft.Json;
using WebUI_Associado.Models;

namespace WebUI_Associado.Services
{
    public class AssociadoService
    {
        private readonly HttpClient _httpClient;

        public AssociadoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<AssociadoModel>> GetAllAssociadosAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7148/api/Associado");  
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<AssociadoModel>>(content);
        }
    }
}
