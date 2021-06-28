using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleHorasColaborador.Migrations
{
    public partial class Alteracao_Id_EquipeColaborador2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EquipeColaborador_ColaboradorId",
                table: "EquipeColaborador");

            migrationBuilder.CreateIndex(
                name: "IX_EquipeColaborador_ColaboradorId_EquipeId",
                table: "EquipeColaborador",
                columns: new[] { "ColaboradorId", "EquipeId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EquipeColaborador_ColaboradorId_EquipeId",
                table: "EquipeColaborador");

            migrationBuilder.CreateIndex(
                name: "IX_EquipeColaborador_ColaboradorId",
                table: "EquipeColaborador",
                column: "ColaboradorId");
        }
    }
}
