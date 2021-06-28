using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleHorasColaborador.Migrations
{
    public partial class Alteracao_Id_Nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipes_Projetos_ProjetoId",
                table: "Equipes");

            migrationBuilder.DropIndex(
                name: "IX_Equipes_ProjetoId",
                table: "Equipes");

            migrationBuilder.AlterColumn<long>(
                name: "ProjetoId",
                table: "Equipes",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Equipes_ProjetoId",
                table: "Equipes",
                column: "ProjetoId",
                unique: true,
                filter: "[ProjetoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipes_Projetos_ProjetoId",
                table: "Equipes",
                column: "ProjetoId",
                principalTable: "Projetos",
                principalColumn: "ProjetoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipes_Projetos_ProjetoId",
                table: "Equipes");

            migrationBuilder.DropIndex(
                name: "IX_Equipes_ProjetoId",
                table: "Equipes");

            migrationBuilder.AlterColumn<long>(
                name: "ProjetoId",
                table: "Equipes",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipes_ProjetoId",
                table: "Equipes",
                column: "ProjetoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipes_Projetos_ProjetoId",
                table: "Equipes",
                column: "ProjetoId",
                principalTable: "Projetos",
                principalColumn: "ProjetoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
