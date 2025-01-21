using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_Associado.Models
{
    [Table("Associado")]
    public class Associado
    {
        public int Id { get; set; } 
        
        public string Nome { get; set; } = string.Empty; 

        public string Cpf { get; set; } = string.Empty; 

        public DateTime? Data_Nascimento { get; set; }

        
        public  ICollection<Associado_Empresa> AssociadoEmpresas { get; set; } = new List<Associado_Empresa>();
    }
}
