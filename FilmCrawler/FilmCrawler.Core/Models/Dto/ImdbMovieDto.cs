using FilmCrawler.Converters;
using FilmCrawler.Core.Models.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FilmCrawler.Core.Modles
{
    public class ImdbMovieDto
    {

        public ImdbMovieDto(int id,string title, string url, string keywords, string datePublished, string description)
        {
            Id = id;
            Name = title;
            Url = url;
            Keywords = keywords;
            DatePublished = datePublished;
            Description = description;
        }
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }

        [JsonConverter(typeof(SingleValueArrayConverter<string>))]

        public List<string> Genre { get; set; }
        [JsonConverter(typeof(SingleValueArrayConverter<PersonDto>))]

        public List<PersonDto> Actor { get; set; }

        [JsonConverter(typeof(SingleValueArrayConverter<PersonDto>))]
        public List<PersonDto> Director { get; set; }
        public string Description { get; set; }
        public string DatePublished { get; set; }

        [JsonConverter(typeof(SingleValueArrayConverter<CreatorDto>))]
        public List<CreatorDto> Creator { get; set; }
        public string Keywords { get; set; }
        public AggregateRating AggregateRating { get; set; }

        public static ImdbMovieDto Create(int id,string title, string url, string keywords, string datePublished, string description)
        {
            return new ImdbMovieDto(id,title, url, keywords, datePublished, description);            
        }

        public ReviewDto Review { get; set; }
        public string Duration { get; set; }
    }
}
