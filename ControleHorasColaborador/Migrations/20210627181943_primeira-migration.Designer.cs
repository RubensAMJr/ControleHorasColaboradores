﻿// <auto-generated />
using ControleHorasColaborador.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControleHorasColaborador.Migrations
{
    [DbContext(typeof(ControleHorasContext))]
    [Migration("20210627181943_primeira-migration")]
    partial class primeiramigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ControleHorasColaborador.Model.Colaborador", b =>
                {
                    b.Property<long>("colaboradorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("colaboradorId");

                    b.ToTable("Colaboradores");
                });

            modelBuilder.Entity("ControleHorasColaborador.Model.Equipe", b =>
                {
                    b.Property<long>("equipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("horasTrabalhadasProjeto")
                        .HasColumnType("int");

                    b.Property<string>("nomeEquipe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("equipeId");

                    b.ToTable("Equipes");
                });

            modelBuilder.Entity("ControleHorasColaborador.Model.Gestor", b =>
                {
                    b.Property<long>("gestorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("nome")
                        .HasColumnType("int");

                    b.HasKey("gestorId");

                    b.ToTable("Gestor");
                });

            modelBuilder.Entity("ControleHorasColaborador.Model.Projeto", b =>
                {
                    b.Property<long>("projetoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("horasTrabalhadasProjeto")
                        .HasColumnType("int");

                    b.Property<string>("nomeProjeto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("projetoId");

                    b.ToTable("Projetos");
                });
#pragma warning restore 612, 618
        }
    }
}
