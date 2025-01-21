using Microsoft.AspNetCore.Mvc;
using WebApi_Associado.Models;
using WebApi_Associado.Services;

namespace WebApi_Associado.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : Controller
    {
        private readonly EmpresaService _empresaService;

        public EmpresaController(EmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        // GET: api/Empresas
        [HttpGet]
        public async Task<ActionResult<List<Empresa>>> GetAll()
        {
            var empresas = await _empresaService.GetAllAsync();
            return Ok(empresas);
        }

        // GET: api/Empresas/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Empresa>> GetById(int id)
        {
            var empresa = await _empresaService.GetByIdAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }
            return Ok(empresa);
        }

        // POST: api/Empresas
        [HttpPost]
        public async Task<ActionResult<Empresa>> Create([FromBody] Empresa novaEmpresa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var empresa = await _empresaService.AddAsync(novaEmpresa);
            return CreatedAtAction(nameof(GetById), new { id = empresa.Id }, empresa);
        }

        // PUT: api/Empresas/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Empresa>> Update(int id, [FromBody] Empresa empresaAtualizada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var empresa = await _empresaService.UpdateAsync(id, empresaAtualizada);
            if (empresa == null)
            {
                return NotFound();
            }

            return Ok(empresa);
        }

        // DELETE: api/Empresas/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _empresaService.DeleteAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
