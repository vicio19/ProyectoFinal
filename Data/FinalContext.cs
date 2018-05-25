using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Data
{
    public class FinalContext: DbContext

    {
        public FinalContext(DbContextOptions<FinalContext> options) : base(options)
        {
        }

        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Pais> Paises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jugador>().ToTable("Jugador");
            modelBuilder.Entity<Pais>().ToTable("Pais");
            
        }
    }
}

