namespace API_PortalAluno.Models
{
    public class ProfessorTurma
    {
        public int ProfessorId { get; set; }
        public Professor? Professor { get; set; }
        public int TurmaId { get; set; }
        public Turma? Turma { get; set; }
    }
}
