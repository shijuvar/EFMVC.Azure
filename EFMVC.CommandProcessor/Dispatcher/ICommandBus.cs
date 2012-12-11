using EFMVC.CommandProcessor.Command;
using EFMVC.Core.Common;
using System.Collections.Generic;
namespace EFMVC.CommandProcessor.Dispatcher
{
    public interface ICommandBus
    {
        ICommandResult Submit<TCommand>(TCommand command) where TCommand: ICommand;
        IEnumerable<ValidationResult> Validate<TCommand>(TCommand command) where TCommand : ICommand;
    }
}

