using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_PortalAluno.Migrations
{
    /// <inheritdoc />
    public partial class teste2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfessorTurma");

            migrationBuilder.CreateIndex(
                name: "IX_ControleAlunos_MateriaId",
                table: "ControleAlunos",
                column: "MateriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ControleAlunos_Materia_MateriaId",
                table: "ControleAlunos",
                column: "MateriaId",
                principalTable: "Materia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControleAlunos_Materia_MateriaId",
                table: "ControleAlunos");

            migrationBuilder.DropIndex(
                name: "IX_ControleAlunos_MateriaId",
                table: "ControleAlunos");

            migrationBuilder.CreateTable(
                name: "ProfessorTurma",
                columns: table => new
                {
                    ProfessoresId = table.Column<int>(type: "int", nullable: false),
                    TurmasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorTurma", x => new { x.ProfessoresId, x.TurmasId });
                    table.ForeignKey(
                        name: "FK_ProfessorTurma_Professores_ProfessoresId",
                        column: x => x.ProfessoresId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessorTurma_Turmas_TurmasId",
                        column: x => x.TurmasId,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorTurma_TurmasId",
                table: "ProfessorTurma",
                column: "TurmasId");
        }
    }
}
