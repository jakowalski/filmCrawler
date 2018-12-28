using System;
using Autofac;
using FilmCrawler.Infrastructure.CQRS.Base;
using FilmCrawler.Infrastructure.CQRS.Base.Interfaces;
using FilmCrawler.Infrastructure.CQRS.CommandBase;
using FilmCrawler.Infrastructure.CQRS.CommandBase.Interfaces;
using Module = Autofac.Module;

namespace FilmCrawler.AutofacModules
{
    public class CommandModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<AutofacCommandDispatcher>().As<ICommandDispatcher>();
            builder.RegisterType<AutofacCommandAsyncDispatcher>().As<ICommandAsyncDispatcher>();
            

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(x => x.IsAssignableTo<ICommandAsyncHandlerBase>())
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(x => x.IsAssignableTo<ICommandHandlerBase>())
                .AsImplementedInterfaces();

            builder.Register<Func<Type, ICommandAsyncHandlerBase>>(c =>
            {
                var ctx = c.Resolve<IComponentContext>();

                return t =>
                {
                    var handlerType = typeof(ICommandAsyncHandler<>).MakeGenericType(t);                    
                    return (ICommandAsyncHandlerBase)ctx.Resolve(handlerType);
                };
            });


            builder.Register<Func<Type, ICommandHandlerBase>>(c =>
            {
                var ctx = c.Resolve<IComponentContext>();

                return t =>
                {
                    var handlerType = typeof(ICommandHandler<>).MakeGenericType(t);
                    return (ICommandHandlerBase)ctx.Resolve(handlerType);
                };
            });

            builder.RegisterType<CommandHandlerFactory>()
                .AsImplementedInterfaces();
        }
    }
}
