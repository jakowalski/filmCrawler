using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FilmCrawler.DataAccessLayer
{
    public class FilmCrawlerDbContextFactory:IDesignTimeDbContextFactory<FilmCrawlerDatabaseContext>
    {       
        public FilmCrawlerDatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FilmCrawlerDatabaseContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-M94H1SH\\SQLEXPRESS;Initial Catalog=FilmCrawlerDb;Trusted_Connection=True;MultipleActiveResultSets=true;");
            return new FilmCrawlerDatabaseContext(optionsBuilder.Options);
        }
        public static DbContextOptions GetDbOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<FilmCrawlerDatabaseContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-M94H1SH\\SQLEXPRESS;Initial Catalog=FilmCrawlerDb;Trusted_Connection=True;MultipleActiveResultSets=true;");
            return optionsBuilder.Options;
        }
    }
}
