namespace API_PortalAluno.Models
{
    public class Materia
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public int ProfessorId { get; set; }
        public required Professor Professor { get; set; }
        public int TurmaId { get; set; }
        public required Turma Turma { get; set; }

        public List<Aluno> Alunos { get; } = [];
        public List<MateriaAluno> MateriasAlunos { get; } = [];

        //public List<ControleAluno> ControleAlunos { get; } = [];
    }
}
