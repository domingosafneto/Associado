using Microsoft.EntityFrameworkCore;
using WebApi_Associado.Models;

namespace WebApi_Associado.Data
{
    public class WebApi_DbContext : DbContext
    {

        public WebApi_DbContext(DbContextOptions<WebApi_DbContext> options)
            : base(options) 
        {
        }

        public DbSet<Associado> Associados { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Associado_Empresa> Associado_Empresa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Associado_Empresa>()
                .HasKey(ae => new { ae.Id_Associado, ae.Id_Empresa });
            
            modelBuilder.Entity<Associado_Empresa>()
                .HasOne(ae => ae.Associado)
                .WithMany(a => a.AssociadoEmpresas)
                .HasForeignKey(ae => ae.Id_Associado)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Associado_Empresa>()
                .HasOne(ae => ae.Empresa)
                .WithMany(e => e.AssociadoEmpresas)
                .HasForeignKey(ae => ae.Id_Empresa)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
