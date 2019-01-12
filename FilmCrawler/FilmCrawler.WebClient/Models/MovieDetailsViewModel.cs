using FilmCrawler.Core.Models.Dto;
using System.Collections.Generic;

namespace FilmCrawler.WebClient.Models
{
    public class MovieDetailsViewModel
    {
        public MovieDetailsViewModel(int id, string title, string url, string keywords, string datePublished, string description)
        {
            Id = id;
            Name = title;
            Url = url;
            Keywords = keywords;
            DatePublished = datePublished;
            Description = description;
        }
        public MovieDetailsViewModel(int id, string title, string url, string keywords, string datePublished, string description,List<CreatorDto> creators, List<string> genres, List<PersonDto> actors, List<PersonDto> directors, AggregateRating aggregateRating, ReviewDto review)
        {
            Id = id;
            Name = title;
            Url = url;
            Keywords = keywords;
            DatePublished = datePublished;
            Description = description;
            Creator = creators;
            Genre = genres;
            Actor = actors;
            Director = directors;
            AggregateRating = aggregateRating;
            Review = review;
        }
       
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }

      
        public string Description { get; set; }
        public string DatePublished { get; set; }
        public string Keywords { get; set; }
        public string Duration { get; set; }

        public List<CreatorDto> Creator { get; set; }
        public List<string> Genre { get; set; }

        public List<PersonDto> Actor { get; set; }

        public List<PersonDto> Director { get; set; }
        public AggregateRating AggregateRating { get; set; }
     
        public ReviewDto Review { get; set; }
    }
}
