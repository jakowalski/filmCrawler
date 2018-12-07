

using FileHelpers;

namespace FilmCrawler.Services.Interfaces
{
    public interface IFileParserProvider
    {
        FileHelperAsyncEngine<TEngineResult> GetAsyncFileParserEngine<TEngineResult>() where TEngineResult:class;
    }
}
