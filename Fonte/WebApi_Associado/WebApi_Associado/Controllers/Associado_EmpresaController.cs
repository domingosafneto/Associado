using Microsoft.AspNetCore.Mvc;
using WebApi_Associado.DTOs;
using WebApi_Associado.Services;

namespace WebApi_Associado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Associado_EmpresaController : Controller
    {
        private readonly Associado_EmpresaService _associadoEmpresaService;

        public Associado_EmpresaController(Associado_EmpresaService associadoEmpresaService)
        {
            _associadoEmpresaService = associadoEmpresaService;
        }

        // Obter todos os associados de uma empresa
        [HttpGet("empresa/{idEmpresa}")]
        public async Task<IActionResult> GetAssociadosByEmpresaId(int idEmpresa)
        {
            var associados = await _associadoEmpresaService.GetAssociadosByEmpresaIdAsync(idEmpresa);
            if (associados == null || associados.Count == 0)
            {
                return NotFound(new { mensagem = "Nenhum associado encontrado para esta empresa." });
            }

            return Ok(associados);
        }

        // Obter todas as empresas de um associado
        [HttpGet("associado/{idAssociado}")]
        public async Task<IActionResult> GetEmpresasByAssociadoId(int idAssociado)
        {
            var empresas = await _associadoEmpresaService.GetEmpresasByAssociadoIdAsync(idAssociado);
            if (empresas == null || empresas.Count == 0)
            {
                return NotFound(new { mensagem = "Nenhuma empresa encontrada para este associado." });
            }

            return Ok(empresas);
        }

        // Adicionar um relacionamento entre um associado e uma empresa
        [HttpPost]
        public async Task<IActionResult> AddAssociadoEmpresa([FromBody] AssociadoEmpresaRequest request)
        {
            if (request == null)
            {
                return BadRequest(new { mensagem = "Dados inválidos." });
            }

            var associadoEmpresa = await _associadoEmpresaService.AddAssociadoEmpresaAsync(request.Id_Associado, request.Id_Empresa);
            if (associadoEmpresa != null)
            {
                return Ok(new { mensagem = "Relacionamento criado com sucesso!"});
            }

            return BadRequest(new { mensagem = "Não foi possível criar o relacionamento." });
        }

        // Remover um relacionamento entre um associado e uma empresa
        [HttpDelete]
        public async Task<IActionResult> RemoveAssociadoEmpresa([FromBody] AssociadoEmpresaRequest request)
        {
            if (request == null)
            {
                return BadRequest(new { mensagem = "Dados inválidos." });
            }

            var resultado = await _associadoEmpresaService.RemoveAssociadoEmpresaAsync(request.Id_Associado, request.Id_Empresa);
            if (resultado)
            {
                return Ok(new { mensagem = "Relacionamento removido com sucesso!" });
            }

            return NotFound(new { mensagem = "Relacionamento não encontrado." });
        }
    }



}
