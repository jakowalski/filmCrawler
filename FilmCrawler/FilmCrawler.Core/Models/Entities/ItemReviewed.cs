

using System.ComponentModel.DataAnnotations.Schema;

namespace FilmCrawler.Core.Models.Entities
{
    public class ItemReviewed:BaseEntity
    {
        public string Url { get; set; }
        [ForeignKey("Review")]
        public int ReviewId { get; set; }
        public virtual Review Review { get; set; }
        public ItemReviewed()
        {

        }
        public ItemReviewed(string url)
        {
            Url = url;
        }
    }
}
