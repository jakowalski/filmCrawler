

namespace FilmCrawler.Core.Models.Dto
{
    public class ActorDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }

        public ActorDto(int id, string url,string name)
        {
            Id = id;
            Url = url;
            Name = name;
        }
        public static ActorDto Create(int id,string url,string name)
        {
            return new ActorDto(id, url, name);
        }
    }
}
