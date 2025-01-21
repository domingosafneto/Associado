namespace WebApi_Associado.Models
{
    public class Associado_Empresa
    {
        public int AssociadoId { get; set; } 

        public Associado Associado { get; set; } = null!; 


        public int EmpresaId { get; set; } 

        public Empresa Empresa { get; set; } = null!; 
    }
}
