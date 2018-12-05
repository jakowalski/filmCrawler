
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FilmCrawler.DataAccessLayer
{
    public class FilmCrawlerDbContextFactory:IDesignTimeDbContextFactory<FilmCrawlerDatabaseContext>
    {       
        public FilmCrawlerDatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FilmCrawlerDatabaseContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-U0OUIVQ\\SQLEXPRESS;Initial Catalog=FilmCrawlerDb;Trusted_Connection=True;MultipleActiveResultSets=true;");

            return new FilmCrawlerDatabaseContext(optionsBuilder.Options);
        }
    }
}
