using Microsoft.EntityFrameworkCore;
using WebApi_Associado.Data;
using WebApi_Associado.Models;

namespace WebApi_Associado.Services
{
    public class AssociadoService
    {
        private readonly WebApi_DbContext _context;
        
        public AssociadoService(WebApi_DbContext context)
        {
            _context = context;
        }
        
        public async Task<List<Associado>> GetAllAsync()
        {
            return await _context.Associados.ToListAsync();
        }
        
        public async Task<Associado?> GetByIdAsync(int id)
        {
            return await _context.Associados
                                 .FirstOrDefaultAsync(a => a.Id == id);
        }
        
        public async Task<Associado> AddAsync(Associado associado)
        {
            _context.Associados.Add(associado);
            await _context.SaveChangesAsync();
            return associado;
        }
        
        public async Task<bool> UpdateAsync(Associado associado)
        {
            var existing = await _context.Associados.FindAsync(associado.Id);
            if (existing == null)
            {
                return false; 
            }
            
            existing.Nome = associado.Nome;
            existing.Cpf = associado.Cpf;
            existing.Data_Nascimento = associado.Data_Nascimento;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var associado = await _context.Associados.FindAsync(id);
            if (associado == null)
            {
                return false; 
            }

            _context.Associados.Remove(associado);
            await _context.SaveChangesAsync();
            return true;
        }

        // Filtrar por Nome
        public async Task<List<Associado>> FilterByNomeAsync(string nome)
        {
            return await _context.Associados
                                 .Where(a => EF.Functions.Like(a.Nome, $"%{nome}%"))
                                 .ToListAsync();
        }

        // Filtrar por CPF
        public async Task<List<Associado>> FilterByCpfAsync(string cpf)
        {
            return await _context.Associados
                                 .Where(a => a.Cpf == cpf)
                                 .ToListAsync();
        }

        // Filtrar por Data de Nascimento
        public async Task<List<Associado>> FilterByDataNascimentoAsync(DateTime? dataNascimento)
        {
            return await _context.Associados
                                 .Where(a => a.Data_Nascimento == dataNascimento)
                                 .ToListAsync();
        }

    }
}
