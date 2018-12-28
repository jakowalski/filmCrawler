using FilmCrawler.Core.Infrastructure.CQRS.CommandBase.Interfaces;


namespace FilmCrawler.Features.ParseImdbMovieCommand
{
    public class ParseImdbMovieCommand:ICommand
    {
        public string FilmId { get; set; }

        public ParseImdbMovieCommand(string filename)
       {
            FilmId = filename;
        }
    }
}
