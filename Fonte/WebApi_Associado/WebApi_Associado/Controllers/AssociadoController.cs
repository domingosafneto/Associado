using Microsoft.AspNetCore.Mvc;
using WebApi_Associado.Models;
using WebApi_Associado.Services;

namespace WebApi_Associado.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssociadoController : Controller
    {
        private readonly AssociadoService _associadoService;

        public AssociadoController(AssociadoService associadoService)
        {
            _associadoService = associadoService;
        }

        // GET: api/Associado
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var associados = await _associadoService.GetAllAsync();
            return Ok(associados);
        }

        // GET: api/Associado/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var associado = await _associadoService.GetByIdAsync(id);
            if (associado == null)
            {
                return NotFound();
            }
            return Ok(associado);
        }

        // POST: api/Associado
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Associado associado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var novoAssociado = await _associadoService.AddAsync(associado);
            return CreatedAtAction(nameof(GetById), new { id = novoAssociado.Id }, novoAssociado);
        }

        // PUT: api/Associado/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Associado associado)
        {
            if (id != associado.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var atualizado = await _associadoService.UpdateAsync(associado);
            if (!atualizado)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Associado/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletado = await _associadoService.DeleteAsync(id);
            if (!deletado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
