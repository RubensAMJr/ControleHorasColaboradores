﻿// <auto-generated />
using System;
using ControleHorasColaborador.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControleHorasColaborador.Migrations
{
    [DbContext(typeof(ControleHorasContext))]
    [Migration("20210627224423_Alteracao_Id_EquipeColaborador")]
    partial class Alteracao_Id_EquipeColaborador
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
                    b.Property<long>("ColaboradorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ColaboradorId");

                    b.ToTable("Colaboradores");
                });

            modelBuilder.Entity("ControleHorasColaborador.Model.Equipe", b =>
                {
                    b.Property<long>("EquipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HorasTrabalhadasProjeto")
                        .HasColumnType("int");

                    b.Property<string>("NomeEquipe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ProjetoId")
                        .HasColumnType("bigint");

                    b.HasKey("EquipeId");

                    b.HasIndex("ProjetoId")
                        .IsUnique()
                        .HasFilter("[ProjetoId] IS NOT NULL");

                    b.ToTable("Equipes");
                });

            modelBuilder.Entity("ControleHorasColaborador.Model.EquipeColaborador", b =>
                {
                    b.Property<long>("EquipeColaboradorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ColaboradorId")
                        .HasColumnType("bigint");

                    b.Property<long>("EquipeId")
                        .HasColumnType("bigint");

                    b.HasKey("EquipeColaboradorId");

                    b.HasIndex("ColaboradorId");

                    b.HasIndex("EquipeId");

                    b.ToTable("EquipeColaborador");
                });

            modelBuilder.Entity("ControleHorasColaborador.Model.Gestor", b =>
                {
                    b.Property<long>("GestorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GestorId");

                    b.ToTable("Gestor");
                });

            modelBuilder.Entity("ControleHorasColaborador.Model.Projeto", b =>
                {
                    b.Property<long>("ProjetoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HorasTrabalhadasProjeto")
                        .HasColumnType("int");

                    b.Property<string>("NomeProjeto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjetoId");

                    b.ToTable("Projetos");
                });

            modelBuilder.Entity("ControleHorasColaborador.Model.Equipe", b =>
                {
                    b.HasOne("ControleHorasColaborador.Model.Projeto", "Projeto")
                        .WithOne("Equipe")
                        .HasForeignKey("ControleHorasColaborador.Model.Equipe", "ProjetoId");
                });

            modelBuilder.Entity("ControleHorasColaborador.Model.EquipeColaborador", b =>
                {
                    b.HasOne("ControleHorasColaborador.Model.Colaborador", "Colaborador")
                        .WithMany("EquipeColaborador")
                        .HasForeignKey("ColaboradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleHorasColaborador.Model.Equipe", "Equipe")
                        .WithMany("EquipeColaborador")
                        .HasForeignKey("EquipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
