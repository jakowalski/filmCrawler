using FilmCrawler.Infrastructure.CQRS.CommandBase.Interfaces;

namespace FilmCrawler.Features.ParseImdbMovieCommand
{
    public class ParseImdbMovieCommand:ICommand
    {
        public string Filename { get; set; }

        public ParseImdbMovieCommand(string filename)
       {
            Filename = filename;
        }
    }
}
