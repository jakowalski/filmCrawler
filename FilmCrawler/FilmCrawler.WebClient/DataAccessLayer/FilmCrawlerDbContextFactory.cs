using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FilmCrawler.DataAccessLayer
{
    public class FilmCrawlerDbContextFactory:IDesignTimeDbContextFactory<FilmCrawlerDatabaseContext>
    {       
        public FilmCrawlerDatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FilmCrawlerDatabaseContext>();
            optionsBuilder.UseSqlServer("Server=tcp:filmcrawlerdbserver.database.windows.net,1433;Initial Catalog=FilmCrawlerDb;Persist Security Info=False;User ID=sidrox;Password=TechnikiMultimedialne123;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            return new FilmCrawlerDatabaseContext(optionsBuilder.Options);
        }
        public static DbContextOptions GetDbOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<FilmCrawlerDatabaseContext>();
            optionsBuilder.UseSqlServer("Server=tcp:filmcrawlerdbserver.database.windows.net,1433;Initial Catalog=FilmCrawlerDb;Persist Security Info=False;User ID=sidrox;Password=TechnikiMultimedialne123;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            return optionsBuilder.Options;
        }
    }
}
