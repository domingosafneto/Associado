using Microsoft.EntityFrameworkCore;
using WebApi_Associado.Data;
using WebApi_Associado.Models;

namespace WebApi_Associado.Services
{
    public class EmpresaService
    {
        private readonly WebApi_DbContext _context;

        public EmpresaService(WebApi_DbContext context)
        {
            _context = context;
        }
        
        public async Task<List<Empresa>> GetAllAsync()
        {
            return await _context.Empresas.ToListAsync();
        }

        public async Task<Empresa?> GetByIdAsync(int id)
        {
            return await _context.Empresas.FindAsync(id);
        }

        public async Task<Empresa> AddAsync(Empresa empresa)
        {
            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();
            return empresa;
        }

        public async Task<Empresa?> UpdateAsync(int id, Empresa empresaAtualizada)
        {
            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa == null)
            {
                return null;
            }

            empresa.Nome = empresaAtualizada.Nome;
            empresa.Cnpj = empresaAtualizada.Cnpj;

            _context.Empresas.Update(empresa);
            await _context.SaveChangesAsync();
            return empresa;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa == null)
            {
                return false;
            }

            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
