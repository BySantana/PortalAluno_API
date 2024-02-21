namespace API_PortalAluno.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Serie { get; set; }
        public ICollection<Aluno> Alunos { get; } = [];
        public ICollection<Materia> Materias { get; } = [];
        public List<Professor> Professores { get; } = [];
    }
}
