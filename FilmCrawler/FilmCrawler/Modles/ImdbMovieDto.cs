using FilmCrawler.Converters;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FilmCrawler.Modles
{
    public class ImdbMovieDto
    {
        public string Url { get; set; }
        public string Name { get; set; }

        [JsonConverter(typeof(SingleValueArrayConverter<string>))]

        public List<string> Genre { get; set; }
        [JsonConverter(typeof(SingleValueArrayConverter<Person>))]

        public List<Person> Actor { get; set; }
        [JsonConverter(typeof(SingleValueArrayConverter<Person>))]

        public List<Person> Director { get; set; }
        public string Description { get; set; }
        public string DatePublished { get; set; }

        [JsonConverter(typeof(SingleValueArrayConverter<Creator>))]

        public List<Creator> Creator { get; set; }
        public string Keywords { get; set; }
        public AggregateRating AggregateRating { get; set; }
        public Review Review { get; set; }
        public string Duration { get; set; }
    }
    public class RatingResult
    {
        public string Type { get; set; }
        public string WorstRating { get; set; }
        public string BestRating { get; set; }
        public string RatingValue { get; set; }
    }
    public class Person
    {
        public string type { get; set; }
        public string url { get; set; }
        public string name { get; set; }
    }
    public class Creator
    {
        public string url { get; set; }
    }
    public class AggregateRating
    {
        public int RatingCount { get; set; }

        public string WorstRating { get; set; }
        public string BestRating { get; set; }
        public string RatingValue { get; set; }
    }

    public class Review
    {
        public ItemReviewed ItemReviewed { get; set; }
        public Person Author { get; set; }
        public string DateCreated { get; set; }
        public string InLanguage { get; set; }
        public string Name { get; set; }
        public string ReviewBody { get; set; }
        public ReviewRating ReviewRating { get; set; }

    }
    public class ItemReviewed
    {
        public string Url { get; set; }
    }
    public class ReviewRating
    {
        public string WorstRating { get; set; }
        public string BestRating { get; set; }
        public string RatingValue { get; set; }

    }
}
