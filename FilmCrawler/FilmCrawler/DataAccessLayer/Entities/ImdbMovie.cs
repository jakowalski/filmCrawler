using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCrawler.DataAccessLayer.Entities
{
    public class ImdbMovie:BaseEntity
    {
        public string SiteId { get; set; }

        public string Title { get; set; }

        public string Region  { get; set; }

        public string Language { get; set; }

        public bool IsOriginalTitle { get; set; }
    }
}
