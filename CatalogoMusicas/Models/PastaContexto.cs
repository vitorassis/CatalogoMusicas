using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoMusicas.Models
{
    public class PastaContexto : DbContext
    {
        //public PastaContexto(DbContextOptions<PastaContexto> options) : base(options) { }

        public DbSet<Pasta> Pastas { get; set; }
        public DbSet<Musica> Musicas { get; set; }
        public DbSet<Tom> Tons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=pastas.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Pasta>().HasData(new Pasta { Id = 1, Nome = "Igreja"});
        }
    }
}
