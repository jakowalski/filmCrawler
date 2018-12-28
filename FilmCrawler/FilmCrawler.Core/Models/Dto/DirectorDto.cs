

using System;

namespace FilmCrawler.Core.Models.Dto
{
    public class DirectorDto
    {
        public DirectorDto(int id, string name, string url)
        {
            Id = id;
            Name = name;
            Url = url;
        }

        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }

        public static DirectorDto Create(int id, string name, string url)
        {
            return new DirectorDto(id, name, url);
        }
    }
}
