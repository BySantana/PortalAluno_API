﻿namespace API_PortalAluno.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }
        public required string Status { get; set; }
        public int EnderecoId { get; set; }
        public required Endereco Endereco { get; set; }
        public int TurmaId { get; set; }
        public required Turma Turma { get; set; }

        public List<Materia> Materias { get; } = [];
        public List<MateriaAluno> MateriasAlunos { get; } = [];

        //public List<ControleAluno> ControleAlunos { get; } = [];
    }
}
