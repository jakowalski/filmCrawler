using System.Reflection;
using Autofac;
using FilmCrawler.Core.Infrastructure.CQRS.CommandBase;
using FilmCrawler.DataAccessLayer;
using FluentValidation;
using Module = Autofac.Module;

namespace FilmCrawler.AutofacModules
{
    public class CommonServicesModule : Module    
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
           
            var myAssembly = Assembly.GetExecutingAssembly();

            //Validators
            builder.RegisterAssemblyTypes(myAssembly)
                .Where(t => t.Name.EndsWith("Validator"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
              builder.RegisterType<AutofacValidatorFactory>().As<IValidatorFactory>().InstancePerLifetimeScope();

            //Context
            builder.RegisterType<FilmCrawlerDatabaseContext>()
            .WithParameter("options", FilmCrawlerDbContextFactory.GetDbOptions())
            .InstancePerLifetimeScope();
        }
    }
}
