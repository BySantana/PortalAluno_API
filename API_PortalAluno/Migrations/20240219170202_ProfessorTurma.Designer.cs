﻿// <auto-generated />
using API_PortalAluno.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_PortalAluno.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240219170202_ProfessorTurma")]
    partial class ProfessorTurma
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API_PortalAluno.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TurmaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("TurmaId");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("API_PortalAluno.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("API_PortalAluno.Models.Materia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("int");

                    b.Property<int>("TurmaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

                    b.HasIndex("TurmaId");

                    b.ToTable("Materia");
                });

            modelBuilder.Entity("API_PortalAluno.Models.MateriaAluno", b =>
                {
                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int>("MateriaId")
                        .HasColumnType("int");

                    b.Property<int>("Faltas")
                        .HasColumnType("int");

                    b.Property<double>("Nota1")
                        .HasColumnType("float");

                    b.Property<double>("Nota2")
                        .HasColumnType("float");

                    b.Property<double>("Nota3")
                        .HasColumnType("float");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AlunoId", "MateriaId");

                    b.HasIndex("MateriaId");

                    b.ToTable("MateriaAlunos");
                });

            modelBuilder.Entity("API_PortalAluno.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("API_PortalAluno.Models.ProfessorTurma", b =>
                {
                    b.Property<int>("ProfessorId")
                        .HasColumnType("int");

                    b.Property<int>("TurmaId")
                        .HasColumnType("int");

                    b.HasKey("ProfessorId", "TurmaId");

                    b.HasIndex("TurmaId");

                    b.ToTable("ProfessorTurma");
                });

            modelBuilder.Entity("API_PortalAluno.Models.Turma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("serie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Turmas");
                });

            modelBuilder.Entity("API_PortalAluno.Models.Aluno", b =>
                {
                    b.HasOne("API_PortalAluno.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_PortalAluno.Models.Turma", "Turma")
                        .WithMany("Alunos")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("API_PortalAluno.Models.Materia", b =>
                {
                    b.HasOne("API_PortalAluno.Models.Professor", "Professor")
                        .WithMany("Materias")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_PortalAluno.Models.Turma", "Turma")
                        .WithMany("Materias")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professor");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("API_PortalAluno.Models.MateriaAluno", b =>
                {
                    b.HasOne("API_PortalAluno.Models.Aluno", "Aluno")
                        .WithMany("MateriasAlunos")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_PortalAluno.Models.Materia", "Materia")
                        .WithMany("MateriasAlunos")
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Materia");
                });

            modelBuilder.Entity("API_PortalAluno.Models.Professor", b =>
                {
                    b.HasOne("API_PortalAluno.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("API_PortalAluno.Models.ProfessorTurma", b =>
                {
                    b.HasOne("API_PortalAluno.Models.Professor", "Professor")
                        .WithMany()
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_PortalAluno.Models.Turma", "Turma")
                        .WithMany()
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professor");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("API_PortalAluno.Models.Aluno", b =>
                {
                    b.Navigation("MateriasAlunos");
                });

            modelBuilder.Entity("API_PortalAluno.Models.Materia", b =>
                {
                    b.Navigation("MateriasAlunos");
                });

            modelBuilder.Entity("API_PortalAluno.Models.Professor", b =>
                {
                    b.Navigation("Materias");
                });

            modelBuilder.Entity("API_PortalAluno.Models.Turma", b =>
                {
                    b.Navigation("Alunos");

                    b.Navigation("Materias");
                });
#pragma warning restore 612, 618
        }
    }
}
