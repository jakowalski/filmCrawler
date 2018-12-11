using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FilmCrawler.Infrastructure.CQRS.Base;
using FilmCrawler.Modles.FileParserModel;
using FilmCrawler.Services.Interfaces;
using FluentValidation;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
                    
                    var parseResult = JObject.Parse(schemaScript.InnerText);


                    var contextResult = parseResult["@context"].ToString();
                    var typeResult = parseResult["@type"].ToString();
                    var urlResult = parseResult["url"].ToString();
                    var nameResult = parseResult["name"].ToString();
                    var durationResult = parseResult["duration"].ToString();
                    var genreResult = parseResult["genre"].ToString().Replace("\r\n", string.Empty).Split(",").ToList();
                    var contenRatingResult = parseResult["contentRating"].ToString();

                    // var reviewRatingType = parseResult["reviewRating"]["@type"].ToString();
                    //var reviewRatingWorstRating = parseResult["reviewRating"]["worstRating"].ToString();
                    //var reviewRatingBestRating = parseResult["reviewRating"]["bestRating"].ToString();

                    //var reviewRatingRatingValue = parseResult["reviewRating"]["ratingValue"].ToString();



                    foreach (var c in parseResult.Children())
                    {

                    }
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
    public class RatingResult
    {
        public string Type { get; set; }
        public string WorstRating { get; set; }
        public string BestRating { get; set; }
        public string RatingValue { get; set; }        
    }
}
