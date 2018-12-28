using FilmCrawler.Core.Infrastructure.CQRS.QueryBase.Interfaces;

namespace FilmCrawler.WebClient.Features.GetActorsQuery
{
    public class GetActorsQuery:IQuery
    {
        public int PageIndex { get; set; }
        public GetActorsQuery(int pageIndex)
        {
            PageIndex = pageIndex;
        }
    }
}
