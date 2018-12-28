using FilmCrawler.Core.Infrastructure.CQRS.QueryBase.Interfaces;


namespace FilmCrawler.WebClient.Features.GetDirectorsQuery
{
    public class GetDirectorsQuery:IQuery
    {
        public int PageIndex { get; set; }
        public GetDirectorsQuery(int pageIndex)
        {
            PageIndex = pageIndex;
        }
    }
}
