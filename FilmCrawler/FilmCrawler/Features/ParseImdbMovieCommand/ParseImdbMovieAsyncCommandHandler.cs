using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FilmCrawler.Core.Infrastructure.CQRS.Base;
using FilmCrawler.Core.Models.Entities;
using FilmCrawler.Core.Modles;
using FilmCrawler.DataAccessLayer;
using FluentValidation;
using HtmlAgilityPack;
using Newtonsoft.Json;

namespace FilmCrawler.Features.ParseImdbMovieCommand
{
    public class ParseImdbMovieAsyncCommandHandler:BaseCommandAsyncHandler<ParseImdbMovieCommand>
    {
        private readonly FilmCrawlerDatabaseContext _dbContext;
        public ParseImdbMovieAsyncCommandHandler(IValidatorFactory validatorFactory, FilmCrawlerDatabaseContext dbContext) : base(validatorFactory)
        {
            _dbContext = dbContext;
        }

        protected override async Task RunCommandAsync(ParseImdbMovieCommand command)
        {            
            //INJECT HTTP CLIENT
            var basePath = "https://www.imdb.com/title/"+command.FilmId;
            using (var httpClient=new HttpClient())
            {
                var pageAsString=await httpClient.GetStringAsync(basePath);

                var doc = new HtmlDocument();
                doc.LoadHtml(pageAsString);

                var schemaScript = doc.DocumentNode.Descendants("script").
                    Where(n=>n.Attributes.FirstOrDefault(a=>a.Value=="application/ld+json")!=null)
                    ?.FirstOrDefault();

                
                if (schemaScript != null)
                {                    
                    var movieModel=JsonConvert.DeserializeObject<ImdbMovieDto>(schemaScript.InnerText);

                    var existedMovie=_dbContext.ImdbMovie.FirstOrDefault(p => p.Url == movieModel.Url);

                    if (existedMovie != null)
                        return;

                    var actorsDb = new List<Actor>();

                    if (movieModel.Actor!=null)
                    {
                        foreach (var actor in movieModel.Actor)
                        {
                            var existedActor = _dbContext.Actor.SingleOrDefault(a => a.Url == actor.Url);
                            if (existedActor == null)
                            {
                                var currentActor = new Actor(actor.Url, actor.Name);
                                _dbContext.Actor.Add(currentActor);
                                actorsDb.Add(currentActor);
                            }
                        }
                        _dbContext.SaveChanges();
                    }


                    var genresDb = new List<Genre>();

                    if(movieModel.Genre!=null)
                    {
                        foreach (var genre in movieModel.Genre)
                        {
                            var existedGenre = _dbContext.Genre.FirstOrDefault(a => a.Name == genre);
                            if (existedGenre == null)
                            {
                                var currentGenre = new Genre(genre);
                                _dbContext.Genre.Add(currentGenre);
                                genresDb.Add(currentGenre);
                            }
                        }
                        _dbContext.SaveChanges();
                    }


                    var directoresDb = new List<Director>();

                    if(movieModel.Director!=null)
                    {
                        foreach (var director in movieModel.Director)
                        {
                            var existedDirector = _dbContext.Director.FirstOrDefault(a => a.Url == director.Url);
                            if (existedDirector == null)
                            {
                                var currentDirector = new Director(director.Url, director.Name);
                                _dbContext.Director.Add(currentDirector);
                                directoresDb.Add(currentDirector);
                            }
                        }
                        _dbContext.SaveChanges();
                    }


                    var creatorsDb = new List<Creator>();
                    if(movieModel.Creator!=null)
                    {
                        foreach (var creator in movieModel.Creator)
                        {
                            var existedCreator = _dbContext.Creator.FirstOrDefault(a => a.Url == creator.Url);
                            if (existedCreator == null)
                            {
                                var currentCreator = new Creator(creator.Url);
                                _dbContext.Creator.Add(currentCreator);
                                creatorsDb.Add(currentCreator);
                            }
                        }
                        _dbContext.SaveChanges();
                    }
                   
                    _dbContext.ImdbMovie.Add(ImdbMovie.CreateImdbMovie(movieModel,actorsDb,genresDb,directoresDb,creatorsDb));
                    await _dbContext.SaveChangesAsync();
                }

            }         
        }
    }    	
}

