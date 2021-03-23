using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCinema.Data.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-FEBP7C8; database=DBProjectCinema; integrated security=true");
        }
        // Modelimin içinde tanımlamış olduğum entity sınıflarını burda tanımlıyorum.
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MovieCategory> MovieCategory { get; set; }
        public DbSet<Saloon> Saloons { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Chair> Chairs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>()
                .HasOne(b => b.Chair)
                .WithMany(a => a.Ticket)
                .OnDelete(DeleteBehavior.NoAction);
        }// Db içerisi dolu olduğundan fk boş olamaz ondan dolayı bunu ekliyoruz null olabilir.
    }
}
