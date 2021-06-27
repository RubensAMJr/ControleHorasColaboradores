using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleHorasColaborador.Model;
using Microsoft.EntityFrameworkCore;

namespace ControleHorasColaborador.Context
{
    public class ControleHorasContext : DbContext
     {
        public ControleHorasContext(DbContextOptions<ControleHorasContext> options)
            : base(options)
        {
        }

        public DbSet<Gestor> Gestor { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Projeto> Projetos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Gestor>().HasKey(g => g.GestorId);
            builder.Entity<Colaborador>().HasKey(c => c.ColaboradorId);
            builder.Entity<Equipe>().HasKey(e => e.EquipeId);
            builder.Entity<Projeto>().HasKey(p => p.ProjetoId);

            builder.Entity<Projeto>()
                   .HasOne<Equipe>(p => p.Equipe)
                   .WithOne(e => e.Projeto)
                   .HasForeignKey<Equipe>(e => e.ProjetoId);
                   

            builder.Entity<EquipeColaborador>()
                   .HasKey(ec => new { ec.ColaboradorId, ec.EquipeId});

            builder.Entity<EquipeColaborador>()
                    .HasOne(ec => ec.Equipe)
                    .WithMany(e => e.EquipeColaborador)
                    .HasForeignKey(ec => ec.EquipeId);

            builder.Entity<EquipeColaborador>()
                   .HasOne(ec => ec.Colaborador)
                   .WithMany(c => c.EquipeColaborador)
                   .HasForeignKey(ec => ec.ColaboradorId);
             
            base.OnModelCreating(builder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ControleHorasDb;Trusted_Connection=true;");
        //}

    }
}
