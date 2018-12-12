using FilmCrawler.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmCrawler.DataAccessLayer
{
    public class FilmCrawlerDatabaseContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public virtual DbSet<ImdbMovie> ImdbMovie { get; set; }
        public virtual DbSet<Actor> Actor { get; set; }
        public virtual DbSet<Director> Director { get; set; }

        public virtual DbSet<Creator> Creator { get; set; }
        public virtual DbSet<AggregateRating> AggregateRating { get; set; }
        public virtual DbSet<Review> Review { get; set; }

        public virtual DbSet<ReviewRating> ReviewRating { get; set; }
        public virtual DbSet<ReviewRating> ReviewRating { get; set; }



        public FilmCrawlerDatabaseContext(DbContextOptions<FilmCrawlerDatabaseContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImdbMovie>()
                .HasMany(b => b.Actors)
                .WithOne();
            modelBuilder.Entity<ImdbMovie>()
                .HasMany(b => b.Creators)
                .WithOne();
            modelBuilder.Entity<ImdbMovie>()
                .HasMany(b => b.Directors)
                .WithOne();

            modelBuilder.Entity<ImdbMovie>()
              .HasOne(b => b.AggregateRating)
              .WithOne();
            modelBuilder.Entity<ImdbMovie>()
           .HasOne(b => b.Review)
           .WithOne();
        }
    }
}
