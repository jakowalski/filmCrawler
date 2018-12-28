

using System.ComponentModel.DataAnnotations.Schema;

namespace FilmCrawler.Core.Models.Entities
{
    public class Person:BaseEntity
    {
        public string Url { get; set; }
        public string Name { get; set; }

        [ForeignKey("Review")]
        public int ReviewId { get; set; }
        public virtual Review Review { get; set; }

        public Person()
        {

        }
        public Person(string url, string name)
        {
            Url = url;
            Name = name;
        }
    }
}
