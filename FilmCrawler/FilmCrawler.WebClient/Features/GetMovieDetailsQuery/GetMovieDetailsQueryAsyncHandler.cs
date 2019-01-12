using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmCrawler.Core.Infrastructure.CQRS.Base;
using FilmCrawler.Core.Models.Dto;
using FilmCrawler.DataAccessLayer;
using FilmCrawler.WebClient.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmCrawler.WebClient.Features.GetMovieDetailsQuery
{
    public class GetMovieDetailsQueryAsyncHandler : BaseQueryAsyncHandler<GetMovieDetailsQuery, GetMovieDetailsQueryResult>
    {
        private readonly FilmCrawlerDatabaseContext _dbContext;
        public GetMovieDetailsQueryAsyncHandler(FilmCrawlerDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override Task<GetMovieDetailsQueryResult> RunQueryAsync(GetMovieDetailsQuery query)
        {
            var imdbMovie=_dbContext
                .ImdbMovie
                .Include(b => b.AggregateRating)
                .Include(b => b.Actors)
                .Include(b => b.Directors)
                .Include(b => b.Creators)                
                .Include(b => b.Genres)
                .Include(b => b.Review)
                .SingleOrDefault(p => p.Id == query.MovieId);

            if(imdbMovie!=null)
            {
                var creators = new List<CreatorDto>();
                foreach (var c in imdbMovie.Creators)
                {
                    var creator=_dbContext.Creator.Single(p => p.Id == c.CreatorId);
                    creators.Add(new CreatorDto(creator.Id, creator.Url));
                }

                var genres = new List<string>();
                foreach (var c in imdbMovie.Genres)
                {
                    var genre = _dbContext.Genre.Single(p => p.Id == c.GenreId);

                    genres.Add(genre.Name);
                }

                var actors = new List<PersonDto>();
                foreach (var c in imdbMovie.Actors)
                {
                    var actor = _dbContext.Actor.Single(p => p.Id == c.ActorId);

                    actors.Add(new PersonDto(actor.Url, actor.Name));
                }

                var directors = new List<PersonDto>();
                foreach (var c in imdbMovie.Directors)
                {
                    var director = _dbContext.Director.Single(p => p.Id == c.DirectorId);

                    directors.Add(new PersonDto(director.Url, director.Name));
                }
                var agregateRating = new AggregateRating(imdbMovie.AggregateRating.RatingCount,
                                                         imdbMovie.AggregateRating.WorstRating,
                                                         imdbMovie.AggregateRating.BestRating,
                                                         imdbMovie.AggregateRating.RatingValue);
                var review = new ReviewDto(imdbMovie.Review.Name,imdbMovie.Review.ReviewBody);

                var movieDetailsModel = new MovieDetailsViewModel(imdbMovie.Id,
                    imdbMovie.Title,
                    imdbMovie.Url,
                    imdbMovie.Keywords,
                    imdbMovie.DatePublished,
                    imdbMovie.Description,
                    creators, 
                    genres,
                    actors,
                    directors,
                    agregateRating,
                    review);

                var result = new GetMovieDetailsQueryResult(movieDetailsModel);
                return Task.FromResult(result);
            }
        
            return Task.FromResult(new GetMovieDetailsQueryResult());
        }
    }
}
