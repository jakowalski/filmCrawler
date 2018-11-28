using System;
using Autofac;
using FilmCrawler.Infrastructure.CQRS.Base;
using FilmCrawler.Infrastructure.CQRS.Base.Interfaces;
using FilmCrawler.Infrastructure.CQRS.QueryBase;
using FilmCrawler.Infrastructure.CQRS.QueryBase.Interfaces;
using Module = Autofac.Module;

namespace FilmCrawler.AutofacModules
{
    public class QueryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<AutofacQueryDispatcher>().As<IQueryDispatcher>();
            builder.RegisterType<AutofacQueryAsyncDispatcher>().As<IQueryAsyncDispatcher>();


            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(x => x.IsAssignableTo<IQueryAsyncHandlerBase>())
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(x => x.IsAssignableTo<IQueryHandlerBase>())
                .AsImplementedInterfaces();

            builder.Register<Func<Type,Type, IQueryAsyncHandlerBase>>(c =>
            {
                var ctx = c.Resolve<IComponentContext>();

                return (t,r) =>
                {
                    var handlerType = typeof(IQueryAsyncHandler<,>).MakeGenericType(t,r);
                    return (IQueryAsyncHandlerBase)ctx.Resolve(handlerType);
                };
            });


            builder.Register<Func<Type, Type, IQueryHandlerBase>>(c =>
            {
                var ctx = c.Resolve<IComponentContext>();

                return (t, r) =>
                {
                    var handlerType = typeof(IQueryHandler<,>).MakeGenericType(t, r);
                    return (IQueryHandlerBase)ctx.Resolve(handlerType);
                };
            });

            builder.RegisterType<QueryHandlerFactory>()
                .AsImplementedInterfaces();
        }
    }
}
