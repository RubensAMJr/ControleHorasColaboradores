using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleHorasColaborador.Migrations
{
    public partial class Table_Relationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nomeProjeto",
                table: "Projetos",
                newName: "NomeProjeto");

            migrationBuilder.RenameColumn(
                name: "horasTrabalhadasProjeto",
                table: "Projetos",
                newName: "HorasTrabalhadasProjeto");

            migrationBuilder.RenameColumn(
                name: "projetoId",
                table: "Projetos",
                newName: "ProjetoId");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Gestor",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "gestorId",
                table: "Gestor",
                newName: "GestorId");

            migrationBuilder.RenameColumn(
                name: "nomeEquipe",
                table: "Equipes",
                newName: "NomeEquipe");

            migrationBuilder.RenameColumn(
                name: "horasTrabalhadasProjeto",
                table: "Equipes",
                newName: "HorasTrabalhadasProjeto");

            migrationBuilder.RenameColumn(
                name: "equipeId",
                table: "Equipes",
                newName: "EquipeId");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Colaboradores",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "colaboradorId",
                table: "Colaboradores",
                newName: "ColaboradorId");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Gestor",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<long>(
                name: "ProjetoId",
                table: "Equipes",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "EquipeColaborador",
                columns: table => new
                {
                    EquipeId = table.Column<long>(nullable: false),
                    ColaboradorId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipeColaborador", x => new { x.ColaboradorId, x.EquipeId });
                    table.ForeignKey(
                        name: "FK_EquipeColaborador_Colaboradores_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaboradores",
                        principalColumn: "ColaboradorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipeColaborador_Equipes_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Equipes",
                        principalColumn: "EquipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipes_ProjetoId",
                table: "Equipes",
                column: "ProjetoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EquipeColaborador_EquipeId",
                table: "EquipeColaborador",
                column: "EquipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipes_Projetos_ProjetoId",
                table: "Equipes",
                column: "ProjetoId",
                principalTable: "Projetos",
                principalColumn: "ProjetoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipes_Projetos_ProjetoId",
                table: "Equipes");

            migrationBuilder.DropTable(
                name: "EquipeColaborador");

            migrationBuilder.DropIndex(
                name: "IX_Equipes_ProjetoId",
                table: "Equipes");

            migrationBuilder.DropColumn(
                name: "ProjetoId",
                table: "Equipes");

            migrationBuilder.RenameColumn(
                name: "NomeProjeto",
                table: "Projetos",
                newName: "nomeProjeto");

            migrationBuilder.RenameColumn(
                name: "HorasTrabalhadasProjeto",
                table: "Projetos",
                newName: "horasTrabalhadasProjeto");

            migrationBuilder.RenameColumn(
                name: "ProjetoId",
                table: "Projetos",
                newName: "projetoId");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Gestor",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "GestorId",
                table: "Gestor",
                newName: "gestorId");

            migrationBuilder.RenameColumn(
                name: "NomeEquipe",
                table: "Equipes",
                newName: "nomeEquipe");

            migrationBuilder.RenameColumn(
                name: "HorasTrabalhadasProjeto",
                table: "Equipes",
                newName: "horasTrabalhadasProjeto");

            migrationBuilder.RenameColumn(
                name: "EquipeId",
                table: "Equipes",
                newName: "equipeId");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Colaboradores",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "ColaboradorId",
                table: "Colaboradores",
                newName: "colaboradorId");

            migrationBuilder.AlterColumn<int>(
                name: "nome",
                table: "Gestor",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
