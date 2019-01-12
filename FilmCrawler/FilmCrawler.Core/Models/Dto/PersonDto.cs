namespace FilmCrawler.Core.Models.Dto
{
    public class PersonDto
    {
        public string Type { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }

        public PersonDto()
        {

        }
        public PersonDto(string url,string name)
        {
            Url = url;
            Name = name;
        }
    }
}
