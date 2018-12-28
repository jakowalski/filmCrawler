namespace FilmCrawler.Core.Infrastructure.CQRS.QueryBase.Interfaces
{
    public interface IQueryDispatcher
    {
        void Dispatch<TQuery, TResult>(TQuery command) where TQuery : IQuery;
    }
}
