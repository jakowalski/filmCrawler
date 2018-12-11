using System.Collections.Generic;
using FileHelpers;
using FilmCrawler.Converters;

namespace FilmCrawler.Modles.FileParserModel
{
    [DelimitedRecord("\t")]

    public class ImdbMovieFileParserModel
    {
        public string Context { get; set; }
        public string TitleId { get; set; }

        public string Title { get; set; }

        public string Region { get; set; }

        public string Language { get; set; }

        [FieldConverter(typeof(AttribiuteFileHelperConverter))]

        public List<string> Types { get; set; }
        [FieldConverter(typeof(AttribiuteFileHelperConverter))]

        public List<string> Attributes { get; set; }

        public bool IsOriginalTitle { get; set; }
    }
}
