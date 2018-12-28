using FilmCrawler.Converters;
using FilmCrawler.Core.Models.Dto;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FilmCrawler.Core.Modles
{
    public class ImdbMovieDto
    {
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
        public ReviewDto Review { get; set; }
        public string Duration { get; set; }
    }
}
