using System.Threading.Tasks;
using FilmCrawler.Core.Infrastructure.CQRS.Base;

namespace FilmCrawler.Features.TestQuery
{
    public class TestQueryAsyncHandler: BaseQueryAsyncHandler<TestQuery, TestQueryResult>
    {
        protected override Task<TestQueryResult> RunQueryAsync(TestQuery query)
        {
            return Task.FromResult(new TestQueryResult {Value = "QUERY WORKS"});
        }
    }
}
