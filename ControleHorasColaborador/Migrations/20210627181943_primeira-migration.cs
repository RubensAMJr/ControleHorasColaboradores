using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleHorasColaborador.Migrations
{
    public partial class primeiramigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colaboradores",
                columns: table => new
                {
                    colaboradorId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores", x => x.colaboradorId);
                });

            migrationBuilder.CreateTable(
                name: "Equipes",
                columns: table => new
                {
                    equipeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeEquipe = table.Column<string>(nullable: true),
                    horasTrabalhadasProjeto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipes", x => x.equipeId);
                });

            migrationBuilder.CreateTable(
                name: "Gestor",
                columns: table => new
                {
                    gestorId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gestor", x => x.gestorId);
                });

            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    projetoId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeProjeto = table.Column<string>(nullable: true),
                    horasTrabalhadasProjeto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.projetoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colaboradores");

            migrationBuilder.DropTable(
                name: "Equipes");

            migrationBuilder.DropTable(
                name: "Gestor");

            migrationBuilder.DropTable(
                name: "Projetos");
        }
    }
}
