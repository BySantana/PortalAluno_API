using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_PortalAluno.Migrations
{
    /// <inheritdoc />
    public partial class ajustes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ControleAlunos");

            migrationBuilder.CreateTable(
                name: "MateriaAlunos",
                columns: table => new
                {
                    MateriaId = table.Column<int>(type: "int", nullable: false),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    Nota1 = table.Column<double>(type: "float", nullable: false),
                    Nota2 = table.Column<double>(type: "float", nullable: false),
                    Nota3 = table.Column<double>(type: "float", nullable: false),
                    Faltas = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriaAlunos", x => new { x.AlunoId, x.MateriaId });
                    table.ForeignKey(
                        name: "FK_MateriaAlunos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MateriaAlunos_Materia_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MateriaAlunos_MateriaId",
                table: "MateriaAlunos",
                column: "MateriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MateriaAlunos");

            migrationBuilder.CreateTable(
                name: "ControleAlunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    MateriaId = table.Column<int>(type: "int", nullable: false),
                    Faltas = table.Column<int>(type: "int", nullable: false),
                    Nota1 = table.Column<double>(type: "float", nullable: false),
                    Nota2 = table.Column<double>(type: "float", nullable: false),
                    Nota3 = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControleAlunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControleAlunos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ControleAlunos_Materia_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ControleAlunos_AlunoId",
                table: "ControleAlunos",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_ControleAlunos_MateriaId",
                table: "ControleAlunos",
                column: "MateriaId");
        }
    }
}
