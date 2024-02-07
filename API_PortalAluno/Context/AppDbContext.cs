﻿using API_PortalAluno.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace API_PortalAluno.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Aluno> Alunos => Set<Aluno>();
        public DbSet<Endereco> Enderecos => Set<Endereco>();
        public DbSet<Materia> Materia => Set<Materia>();
        public DbSet<Professor> Professores => Set<Professor>();
        public DbSet<Turma> Turmas => Set<Turma>();
        //public DbSet<ControleAluno> ControleAlunos => Set<ControleAluno>();
        public DbSet<MateriaAluno> MateriaAlunos => Set<MateriaAluno>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region TurmaProfessor

            modelBuilder.Entity<Professor>()
                .HasMany(e => e.Turmas)
                .WithMany(e => e.Professores);

            #endregion

            #region MateriaAluno

            modelBuilder.Entity<Aluno>()
                    .HasMany(e => e.Materias)
                    .WithMany(e => e.Alunos)
                    .UsingEntity<MateriaAluno>(
                        j =>
                        {
                            j.Property(am => am.Nota1);
                            j.Property(am => am.Nota2);
                            j.Property(am => am.Nota3);
                            j.Property(am => am.Status);
                            j.Property(am => am.Faltas);
                        }
                     );

            #endregion
        }
    }
}