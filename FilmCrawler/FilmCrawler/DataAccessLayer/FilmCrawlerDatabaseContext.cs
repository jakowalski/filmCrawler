using FilmCrawler.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmCrawler.DataAccessLayer
{
    public class FilmCrawlerDatabaseContext:DbContext
    {
        public virtual DbSet<ImdbMovie> ImdbMovie { get; set; }

        public FilmCrawlerDatabaseContext(DbContextOptions<FilmCrawlerDatabaseContext> options):base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

    }
}
