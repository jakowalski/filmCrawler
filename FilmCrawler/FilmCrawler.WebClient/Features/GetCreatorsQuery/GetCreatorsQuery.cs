using FilmCrawler.Core.Infrastructure.CQRS.QueryBase.Interfaces;

namespace FilmCrawler.WebClient.Features.GetCreatorsQuery
{
    public class GetCreatorsQuery : IQuery
    {
        public int PageIndex { get; set; }
        public GetCreatorsQuery(int pageIndex)
        {
            PageIndex = pageIndex;
        }
    }
}
