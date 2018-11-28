using System;
using System.Threading.Tasks;
using FilmCrawler.Infrastructure.CQRS.CommandBase;
using FilmCrawler.Infrastructure.CQRS.CommandBase.Interfaces;
using FluentValidation;

namespace FilmCrawler.Infrastructure.CQRS.Base
{
    public abstract class BaseCommandAsyncHandler<TCommand> : ICommandAsyncHandler<TCommand> where TCommand : ICommand
    {
        private readonly IValidatorFactory _validatorFactory;

        protected BaseCommandAsyncHandler(IValidatorFactory validatorFactory)
        {
            _validatorFactory = validatorFactory;
        }

        public virtual async Task ExecuteAsync(TCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var validator = _validatorFactory.GetValidator<TCommand>();

            if (validator != null)
            {
                var result =  await validator.ValidateAsync(command);

                if (result == null)
                {
                    throw new ValidationException("Validation failed");
                }

                if (!result.IsValid)
                {
                    throw new ValidationException(result.Errors);
                }
            }

            await RunCommandAsync(command);
        }

        protected abstract Task RunCommandAsync(TCommand command);
    }
}