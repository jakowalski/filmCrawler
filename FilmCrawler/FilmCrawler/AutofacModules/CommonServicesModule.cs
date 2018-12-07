using System.Reflection;
using Autofac;
using FilmCrawler.DataAccessLayer;
using FilmCrawler.Infrastructure.CQRS.CommandBase;
using FilmCrawler.Infrastructure.CQRS.CommandBase.Interfaces;
using FilmCrawler.Services;
using FilmCrawler.Services.Interfaces;
using FluentValidation;
using Module = Autofac.Module;

namespace FilmCrawler.AutofacModules
{ 
    public class CommonServicesModule : Module    
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<FileParserProvider>().As<IFileParserProvider>().InstancePerLifetimeScope();
            var myAssembly = Assembly.GetExecutingAssembly();

            //Validators
            builder.RegisterAssemblyTypes(myAssembly)
                .Where(t => t.Name.EndsWith("Validator"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
              builder.RegisterType<AutofacValidatorFactory>().As<IValidatorFactory>().InstancePerLifetimeScope();

            //Context
            builder.RegisterType<FilmCrawlerDatabaseContext>().AsSelf().InstancePerLifetimeScope();
        }
    }
}
