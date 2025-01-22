using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI_Associado.Models;

namespace WebUI_Associado.Controllers
{
    public class AssociadoController : Controller
    {
        private readonly HttpClient _httpClient;

        public AssociadoController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Associados()
        {
            var response = await _httpClient.GetAsync("https://localhost:7148/api/Associado");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var associados = JsonConvert.DeserializeObject<List<AssociadoModel>>(content);

            return View(associados);
        }
    }
}
