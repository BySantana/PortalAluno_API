namespace API_PortalAluno.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public required string Cidade { get; set; }
        public required string Rua { get; set; }
        public required string Complemento { get; set; }
        public required string Telefone { get; set; }
    }
}
