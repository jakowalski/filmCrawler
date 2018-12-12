using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCrawler.DataAccessLayer.Entities
{
    public class ReviewRating:BaseEntity
    {
        public string WorstRating { get; set; }
        public string BestRating { get; set; }
        public string RatingValue { get; set; }
    }
}
