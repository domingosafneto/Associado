using Microsoft.EntityFrameworkCore;
using WebApi_Associado.Models;

namespace WebApi_Associado.Data
{
    public class WebApi_DbContext : DbContext
    {
        public DbSet<Associado> Associados { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Associado_Empresa> Associado_Empresas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar os relacionamentos aqui
        }
    }
}
