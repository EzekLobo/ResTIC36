using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uesc.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AlunoMateria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlunoMateria",
                columns: table => new
                {
                    AlunosId = table.Column<int>(type: "int", nullable: false),
                    MateriasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoMateria", x => new { x.AlunosId, x.MateriasId });
                    table.ForeignKey(
                        name: "FK_AlunoMateria_Alunos_AlunosId",
                        column: x => x.AlunosId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoMateria_Materias_MateriasId",
                        column: x => x.MateriasId,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoMateria_MateriasId",
                table: "AlunoMateria",
                column: "MateriasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoMateria");
        }
    }
}
