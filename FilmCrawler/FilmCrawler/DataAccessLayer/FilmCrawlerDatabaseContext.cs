using FilmCrawler.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmCrawler.DataAccessLayer
{
    public class FilmCrawlerDatabaseContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public virtual DbSet<ImdbMovie> ImdbMovie { get; set; }
        public virtual DbSet<Actor> Actor { get; set; }
        public virtual DbSet<Director> Director { get; set; }
        public virtual DbSet<ActorImdbMovie> ActorMovie { get; set; }
        public virtual DbSet<CreatorImdbMovie> CreatorMovie { get; set; }
        public virtual DbSet<DirectorMovie> DirectorMovie { get; set; }
        public virtual DbSet<GenreImdbMovie> GenreMovie { get; set; }
        public virtual DbSet<Creator> Creator { get; set; }
        public virtual DbSet<AggregateRating> AggregateRating { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<Genre> Genre{ get; set; }
        public virtual DbSet<ReviewRating> ReviewRating { get; set; }


        public FilmCrawlerDatabaseContext(DbContextOptions<FilmCrawlerDatabaseContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetupRelationActorMovie(modelBuilder);

            SetupRelationGenreMovie(modelBuilder);

            SetupRelationCreatorMovie(modelBuilder);
            SetupRelationDirectorMovie(modelBuilder);

            modelBuilder.Entity<ImdbMovie>()
              .HasOne(b => b.AggregateRating)
              .WithOne(d => d.ImdbMovie)
              .HasForeignKey<AggregateRating>(c => c.ImdbMovieId);

            modelBuilder.Entity<ImdbMovie>()
              .HasOne(b => b.Review)
              .WithOne(d => d.ImdbMovie)
              .HasForeignKey<Review>(c => c.ImdbMovieId);


            //REVIEW
            modelBuilder.Entity<Review>()
             .HasOne(b => b.ItemReviewed)
             .WithOne(b => b.Review)
             .HasForeignKey<ItemReviewed>(c => c.ReviewId);

            modelBuilder.Entity<Review>()
             .HasOne(b => b.Author)
             .WithOne(b => b.Review)
             .HasForeignKey<Person>(c => c.ReviewId);


            modelBuilder.Entity<Review>()
             .HasOne(b => b.ReviewRating)
             .WithOne(b => b.Review)
             .HasForeignKey<ReviewRating>(c => c.ReviewId);
        }

        private static void SetupRelationDirectorMovie(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DirectorMovie>()
                            .HasKey(bc => new { bc.DirectorId, bc.ImdbMovieId });

            modelBuilder.Entity<DirectorMovie>()
                .HasOne(a => a.Director)
                .WithMany(b => b.DirectorMovies)
                .HasForeignKey(bc => bc.DirectorId);

            modelBuilder.Entity<DirectorMovie>()
                .HasOne(bc => bc.ImdbMovie)
                .WithMany(c => c.Directors)
                .HasForeignKey(bc => bc.ImdbMovieId);
        }

        private static void SetupRelationCreatorMovie(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreatorImdbMovie>()
            .HasKey(bc => new { bc.CreatorId, bc.ImdbMovieId });

            modelBuilder.Entity<CreatorImdbMovie>()
                .HasOne(a => a.Creator)
                .WithMany(b => b.CreatorMovies)
                .HasForeignKey(bc => bc.CreatorId);

            modelBuilder.Entity<CreatorImdbMovie>()
                .HasOne(bc => bc.ImdbMovie)
                .WithMany(c => c.Creators)
                .HasForeignKey(bc => bc.ImdbMovieId);
        }

        private static void SetupRelationGenreMovie(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GenreImdbMovie>()
            .HasKey(bc => new { bc.GenreId, bc.ImdbMovieId });

            modelBuilder.Entity<GenreImdbMovie>()
                .HasOne(a => a.Genre)
                .WithMany(b => b.GenreImdbMovies)
                .HasForeignKey(bc => bc.GenreId);

            modelBuilder.Entity<GenreImdbMovie>()
                .HasOne(bc => bc.ImdbMovie)
                .WithMany(c => c.Genres)
                .HasForeignKey(bc => bc.ImdbMovieId);
        }

        private static void SetupRelationActorMovie(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorImdbMovie>()
            .HasKey(bc => new { bc.ActorId, bc.ImdbMovieId });

            modelBuilder.Entity<ActorImdbMovie>()
                .HasOne(a => a.Actor)
                .WithMany(b => b.ActorMovies)
                .HasForeignKey(bc => bc.ActorId);

            modelBuilder.Entity<ActorImdbMovie>()
                .HasOne(bc => bc.ImdbMovie)
                .WithMany(c => c.Actors)
                .HasForeignKey(bc => bc.ImdbMovieId);
        }
    }
}
