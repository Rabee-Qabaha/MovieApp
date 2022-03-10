using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Models;

namespace MovieApp.EF.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie_Actor>()
                .HasOne(m => m.Movie)
                .WithMany(ma => ma.Movie_Actors)
                .HasForeignKey(m => m.MovieId);

            modelBuilder.Entity<Movie_Actor>()
                .HasOne(a => a.Actor)
                .WithMany(am => am.Movie_Actors)
                .HasForeignKey(a => a.ActorId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Movie_Actor>  movie_Actors { get; set; }

    }
}
