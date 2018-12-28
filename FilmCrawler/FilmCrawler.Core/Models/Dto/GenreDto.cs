namespace FilmCrawler.Core.Models.Dto
{
    public class GenreDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public GenreDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public static GenreDto Create(int id, string name)
        {
            return new GenreDto(id, name);
        }
    }
}
