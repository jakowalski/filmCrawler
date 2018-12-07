using FluentValidation;

namespace FilmCrawler.Features.ParseImdbMovieCommand
{
    public class ParseImdbMovieValidator: AbstractValidator<ParseImdbMovieCommand>
    {
        public ParseImdbMovieValidator()
        {
            RuleFor(c => c.Filename).NotEmpty();
        }
    }
}
