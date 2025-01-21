using Microsoft.EntityFrameworkCore;
using WebApi_Associado.Data;
using WebApi_Associado.Models;

namespace WebApi_Associado.Services
{
    public class Associado_EmpresaService
    {
        private readonly WebApi_DbContext _context;

        public Associado_EmpresaService(WebApi_DbContext context)
        {
            _context = context;
        }

        // Obter todos os associados de uma empresa
        public async Task<List<Associado>> GetAssociadosByEmpresaIdAsync(int idEmpresa)
        {
            var associados = await _context.Associado_Empresa
                .Where(ae => ae.Id_Empresa == idEmpresa)
                .Select(ae => ae.Associado)
                .ToListAsync();

            return associados;
        }

        // Obter todas as empresas de um associado
        public async Task<List<Empresa>> GetEmpresasByAssociadoIdAsync(int idAssociado)
        {
            var empresas = await _context.Associado_Empresa
                .Where(ae => ae.Id_Associado == idAssociado)
                .Select(ae => ae.Empresa)
                .ToListAsync();

            return empresas;
        }

        // Adicionar um relacionamento entre um associado e uma empresa
        public async Task<Associado_Empresa> AddAssociadoEmpresaAsync(int idAssociado, int idEmpresa)
        {
            var associadoEmpresa = new Associado_Empresa
            {
                Id_Associado = idAssociado,
                Id_Empresa = idEmpresa
            };

            _context.Associado_Empresa.Add(associadoEmpresa);
            await _context.SaveChangesAsync();

            return associadoEmpresa;
        }

        // Remover um relacionamento entre um associado e uma empresa
        public async Task<bool> RemoveAssociadoEmpresaAsync(int idAssociado, int idEmpresa)
        {
            var associadoEmpresa = await _context.Associado_Empresa
                .FirstOrDefaultAsync(ae => ae.Id_Associado == idAssociado && ae.Id_Empresa == idEmpresa);

            if (associadoEmpresa == null)
            {
                return false; // Não encontrou o relacionamento
            }

            _context.Associado_Empresa.Remove(associadoEmpresa);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
