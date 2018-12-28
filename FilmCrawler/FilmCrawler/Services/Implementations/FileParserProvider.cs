using FileHelpers;
using FilmCrawler.Services.Interfaces;

namespace FilmCrawler.Services
{
    public class FileParserProvider:IFileParserProvider
    {

        //TOOD CONSIDER TO USE LAZY LOADING

        //private static readonly Lazy<FileHelperEngine> _instance =
        //    //new Lazy<FileHelperEngine>(() => new FileHelperEngine());
        public FileHelperAsyncEngine<TEngineResult> GetAsyncFileParserEngine<TEngineResult>() where TEngineResult : class
        {
            return new FileHelperAsyncEngine<TEngineResult>();
        }
    }
}
