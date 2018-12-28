using FilmCrawler.Core.Modles;
using System.Collections.Generic;

namespace FilmCrawler.Core.Models.Entities
{
    public class ImdbMovie:BaseEntity
    {
        public string SiteId { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public ICollection<GenreImdbMovie> Genres { get; set; }
        public string Duration { get; set; }
      
        public string Description { get; set; }
        public string DatePublished { get; set; }
        public string Keywords { get; set; }

        public  ICollection<ActorImdbMovie> Actors { get; set; }
        public  ICollection<DirectorMovie> Directors { get; set; }

        public  ICollection<CreatorImdbMovie> Creators { get; set; }

        public  virtual AggregateRating AggregateRating { get; set; }

        public virtual Review Review { get; set; }

        public ImdbMovie()
        {
                
        }
        public ImdbMovie(string title,
                         string url,
                         List<GenreImdbMovie> genres,
                         string duration,
                         string description,
                         string datePublished,
                         string keywords,
                         List<ActorImdbMovie> actors,
                         List<DirectorMovie> directors,
                         List<CreatorImdbMovie> creators,
                         AggregateRating aggregateRating,
                         Review review)                
        {
            Title = title;
            Url = url;
            Genres = genres;
            Duration = duration;
            Description = description;
            DatePublished = datePublished;
            Keywords = keywords;
            Actors = actors;
            Directors = directors;
            Creators = creators;
            AggregateRating = aggregateRating;
            Review = review;

        }
        public ImdbMovie(string title,
                         string url,
                         string duration,
                         string description,
                         string datePublished,
                         string keywords,
                         AggregateRating aggregateRating,
                         Review review)
        {
            Title = title;
            Url = url;
            Duration = duration;
            Description = description;
            DatePublished = datePublished;
            Keywords = keywords;          
            AggregateRating = aggregateRating;
            Review = review;
        }

        public static ImdbMovie CreateImdbMovie(ImdbMovieDto movieModel, List<Actor> actorsDb, List<Genre> genresDb, List<Director> directoresDb, List<Creator> creatorsDb)
        {
            var result = new ImdbMovie(movieModel.Name,
                                       movieModel.Url,
                                       movieModel.Duration,
                                       movieModel.Description,
                                       movieModel.DatePublished,
                                       movieModel.Keywords,
                                       new AggregateRating(movieModel.AggregateRating==null?0:movieModel.AggregateRating.RatingCount,
                                                           movieModel.AggregateRating?.WorstRating,
                                                           movieModel.AggregateRating?.BestRating,
                                                           movieModel.AggregateRating?.RatingValue),
                                       new Review(movieModel.Review?.Name,
                                           movieModel.Review?.ReviewBody,
                                           movieModel.Review?.InLanguage,
                                           movieModel.Review?.DateCreated,
                                           new ItemReviewed(movieModel.Review?.ItemReviewed.Url),
                                           new Person(movieModel.Review?.Author?.Url, movieModel.Review?.Author?.Name),
                                           new ReviewRating(movieModel.Review?.ReviewRating?.WorstRating,
                                                            movieModel.Review?.ReviewRating?.BestRating,
                                                            movieModel.Review?.ReviewRating?.RatingValue)));


            var movieActors = new List<ActorImdbMovie>();
            foreach (var actor in actorsDb)
            {
                movieActors.Add(new ActorImdbMovie { Actor = actor, ImdbMovie = result });
            }
            var movieCreators = new List<CreatorImdbMovie>();
            foreach (var creator in creatorsDb)
            {
                movieCreators.Add(new CreatorImdbMovie { Creator = creator, ImdbMovie = result });
            }
            var movieDirectos = new List<DirectorMovie>();
            foreach (var director in directoresDb)
            {
                movieDirectos.Add(new DirectorMovie { Director = director, ImdbMovie = result });
            }
            var movieGenres = new List<GenreImdbMovie>();
            foreach (var genre in genresDb)
            {
                movieGenres.Add(new GenreImdbMovie { Genre = genre, ImdbMovie = result });
            }
            result.Actors = movieActors;
            result.Creators = movieCreators;
            result.Directors = movieDirectos;
            result.Genres = movieGenres;
            return result;
        }
    }
}




