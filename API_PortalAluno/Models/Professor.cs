using Microsoft.Extensions.Hosting;

namespace API_PortalAluno.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }

        public int EnderecoId { get; set; }
        public required Endereco Endereco { get; set; }
        public ICollection<Materia> Materias { get; } = new List<Materia>();
        public List<Turma> Turmas { get; } = [];
    }
}
