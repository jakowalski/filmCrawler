using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FilmCrawler.Infrastructure.CQRS.Base;
using FilmCrawler.Modles.FileParserModel;
using FilmCrawler.Services.Interfaces;
using FluentValidation;
using HtmlAgilityPack;
using Newtonsoft.Json;

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

            //INJECT HTTP CLIENT
            var basePath = "https://www.imdb.com/title/tt000000"+1.ToString();
            using (var httpClient=new HttpClient())
            {
                var pageAsString=await httpClient.GetStringAsync(basePath);

                var doc = new HtmlDocument();
                doc.LoadHtml(pageAsString);

                var schemaScript = doc.DocumentNode.Descendants("script").Where(n=>n.Attributes.SingleOrDefault(a=>a.Value=="application/ld+json")!=null)
                    ?.SingleOrDefault();

                
                if (schemaScript != null)
                {
                    var ss = new JsonSerializer();
                    var deserializedSchemaScript=JsonConvert.DeserializeObject(schemaScript.InnerText);
                }

            }
            //using (fileParserEngine.BeginReadFile(command.Filename))
            //{
            //    foreach (var record in fileParserEngine)
            //    {
            //        // put your code here !!!!
                    
            //    }
            //}
        }
    }
}
