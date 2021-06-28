using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleHorasColaborador.Migrations
{
    public partial class Inserção_de_constraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NomeProjeto",
                table: "Projetos",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomeEquipe",
                table: "Equipes",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_NomeProjeto",
                table: "Projetos",
                column: "NomeProjeto",
                unique: true,
                filter: "[NomeProjeto] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Equipes_NomeEquipe",
                table: "Equipes",
                column: "NomeEquipe",
                unique: true,
                filter: "[NomeEquipe] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Projetos_NomeProjeto",
                table: "Projetos");

            migrationBuilder.DropIndex(
                name: "IX_Equipes_NomeEquipe",
                table: "Equipes");

            migrationBuilder.AlterColumn<string>(
                name: "NomeProjeto",
                table: "Projetos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomeEquipe",
                table: "Equipes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
