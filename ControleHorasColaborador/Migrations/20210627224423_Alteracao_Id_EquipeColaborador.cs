using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleHorasColaborador.Migrations
{
    public partial class Alteracao_Id_EquipeColaborador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipeColaborador",
                table: "EquipeColaborador");

            migrationBuilder.AddColumn<long>(
                name: "EquipeColaboradorId",
                table: "EquipeColaborador",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipeColaborador",
                table: "EquipeColaborador",
                column: "EquipeColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipeColaborador_ColaboradorId",
                table: "EquipeColaborador",
                column: "ColaboradorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipeColaborador",
                table: "EquipeColaborador");

            migrationBuilder.DropIndex(
                name: "IX_EquipeColaborador_ColaboradorId",
                table: "EquipeColaborador");

            migrationBuilder.DropColumn(
                name: "EquipeColaboradorId",
                table: "EquipeColaborador");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipeColaborador",
                table: "EquipeColaborador",
                columns: new[] { "ColaboradorId", "EquipeId" });
        }
    }
}
