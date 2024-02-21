using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_PortalAluno.Migrations
{
    /// <inheritdoc />
    public partial class ProfessorTurma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorTurma_Professores_ProfessoresId",
                table: "ProfessorTurma");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorTurma_Turmas_TurmasId",
                table: "ProfessorTurma");

            migrationBuilder.RenameColumn(
                name: "TurmasId",
                table: "ProfessorTurma",
                newName: "TurmaId");

            migrationBuilder.RenameColumn(
                name: "ProfessoresId",
                table: "ProfessorTurma",
                newName: "ProfessorId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfessorTurma_TurmasId",
                table: "ProfessorTurma",
                newName: "IX_ProfessorTurma_TurmaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorTurma_Professores_ProfessorId",
                table: "ProfessorTurma",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorTurma_Turmas_TurmaId",
                table: "ProfessorTurma",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorTurma_Professores_ProfessorId",
                table: "ProfessorTurma");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorTurma_Turmas_TurmaId",
                table: "ProfessorTurma");

            migrationBuilder.RenameColumn(
                name: "TurmaId",
                table: "ProfessorTurma",
                newName: "TurmasId");

            migrationBuilder.RenameColumn(
                name: "ProfessorId",
                table: "ProfessorTurma",
                newName: "ProfessoresId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfessorTurma_TurmaId",
                table: "ProfessorTurma",
                newName: "IX_ProfessorTurma_TurmasId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorTurma_Professores_ProfessoresId",
                table: "ProfessorTurma",
                column: "ProfessoresId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorTurma_Turmas_TurmasId",
                table: "ProfessorTurma",
                column: "TurmasId",
                principalTable: "Turmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
