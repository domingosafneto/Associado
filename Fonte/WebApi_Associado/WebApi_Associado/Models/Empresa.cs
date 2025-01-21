using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_Associado.Models
{
    [Table("Empresa")]
    public class Empresa
    {
        public int Id { get; set; } 

        public string Nome { get; set; } = string.Empty; 

        public string Cnpj { get; set; } = string.Empty;

        
        public ICollection<Associado_Empresa> AssociadoEmpresas { get; set; } = new List<Associado_Empresa>();
    }
}
