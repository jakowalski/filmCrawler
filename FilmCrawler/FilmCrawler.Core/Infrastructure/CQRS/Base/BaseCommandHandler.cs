using System;
using FilmCrawler.Core.Infrastructure.CQRS.CommandBase.Interfaces;
using FluentValidation;

namespace FilmCrawler.Core.Infrastructure.CQRS.Base
{
    public abstract class BaseCommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        private readonly IValidatorFactory _validatorFactory;

        protected BaseCommandHandler(IValidatorFactory validatorFactory)
        {
            _validatorFactory = validatorFactory;
        }

        public virtual void Execute(TCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var validator = _validatorFactory.GetValidator<TCommand>();

            if (validator != null)
            {
                var result = validator.Validate(command);

                if (result == null)
                {
                    throw new ValidationException("Validation failed");
                }

                if (!result.IsValid)
                {
                    throw new ValidationException(result.Errors);
                }
            }

            RunCommand(command);
        }

        protected abstract void RunCommand(TCommand command);
    }
}