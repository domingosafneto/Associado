using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_Associado.Models
{
    [Table("Associado_Empresa")]
    public class Associado_Empresa
    {
        public int Id_Associado { get; set; } 

        public Associado Associado { get; set; } = null!; 


        public int Id_Empresa { get; set; } 

        public Empresa Empresa { get; set; } = null!; 
    }
}
