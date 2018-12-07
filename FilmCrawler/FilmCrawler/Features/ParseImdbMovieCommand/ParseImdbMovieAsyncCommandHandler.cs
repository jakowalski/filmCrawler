using System.Threading.Tasks;
using FilmCrawler.Infrastructure.CQRS.Base;
using FilmCrawler.Modles.FileParserModel;
using FilmCrawler.Services.Interfaces;
using FluentValidation;

namespace FilmCrawler.Features.ParseImdbMovieCommand
{
    public class ParseImdbMovieAsyncCommandHandler:BaseCommandAsyncHandler<ParseImdbMovieCommand>
    {
        private readonly IFileParserProvider _fileParserProvider;
        public ParseImdbMovieAsyncCommandHandler(IValidatorFactory validatorFactory, IFileParserProvider fileParserProvider) : base(validatorFactory)
        {
            _fileParserProvider = fileParserProvider;
        }

        protected override async Task RunCommandAsync(ParseImdbMovieCommand command)
        {
            var fileParserEngine = _fileParserProvider.GetAsyncFileParserEngine<ImdbMovieFileParserModel>();

            using (fileParserEngine.BeginReadFile(command.Filename))
            {
                foreach (var record in fileParserEngine)
                {
                    // put your code here !!!!
                    
                }
            }
        }
    }
}
