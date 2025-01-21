namespace WebUI_Associado.Models
{
    public class AssociadoModel
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Cpf { get; set; } = string.Empty;

        public DateTime? Data_Nascimento { get; set; }
    }
}
