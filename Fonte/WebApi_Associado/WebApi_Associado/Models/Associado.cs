namespace WebApi_Associado.Models
{
    public class Associado
    {
        public int Id { get; set; } 

        public string Nome { get; set; } = string.Empty; 

        public string Cpf { get; set; } = string.Empty; 

        public DateTime? DataNascimento { get; set; }

        
        public  ICollection<Associado_Empresa> AssociadoEmpresas { get; set; } = new List<Associado_Empresa>();
    }
}
