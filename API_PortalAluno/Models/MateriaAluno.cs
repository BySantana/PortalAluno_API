namespace API_PortalAluno.Models
{
    public class MateriaAluno
    {
        public int MateriaId { get; set; }
        public required Materia Materia { get; set; }
        public int AlunoId { get; set; }
        public required Aluno Aluno { get; set; }

        public double Nota1 { get; set; }
        public double Nota2 { get; set; }
        public double Nota3 { get; set; }
        public int Faltas { get; set; }
        public required string Status { get; set; }
    }
}
