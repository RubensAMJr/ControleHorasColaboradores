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
        //public ControleHorasContext(DbContextOptions<ControleHorasContext> options)
        //    : base(options)
        //{
        //}

        public DbSet<Gestor> Gestor { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Projeto> Projetos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Gestor>().HasKey(g => g.gestorId);
            builder.Entity<Colaborador>().HasKey(c => c.colaboradorId);
            builder.Entity<Equipe>().HasKey(e => e.equipeId);
            builder.Entity<Projeto>().HasKey(p => p.projetoId);

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ControleHorasDb;Trusted_Connection=true;");
        }

    }
}
