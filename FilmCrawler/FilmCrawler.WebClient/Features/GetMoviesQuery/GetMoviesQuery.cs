using FilmCrawler.Core.Infrastructure.CQRS.QueryBase.Interfaces;

namespace FilmCrawler.WebClient.Features.GetMoviesQuery
{
    public class GetMoviesQuery:IQuery
    {
        public int PageIndex { get; set; }
        public GetMoviesQuery(int pageIndex)
        {
            PageIndex = pageIndex;
        }
    }
}
