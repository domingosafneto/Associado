using Microsoft.AspNetCore.Mvc;
using WebUI_Associado.Services;

namespace WebUI_Associado.Controllers
{
    public class AssociadoController : Controller
    {
        private readonly AssociadoService _associadoService;

        public AssociadoController(AssociadoService associadoService)
        {
            _associadoService = associadoService;
        }

        public async Task<IActionResult> Index()
        {
            var associados = await _associadoService.GetAllAssociadosAsync();
            return View(associados);
        }
    }
}
