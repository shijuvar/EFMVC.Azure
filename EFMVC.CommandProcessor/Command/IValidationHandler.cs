using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFMVC.CommandProcessor;
using EFMVC.Core.Common;

namespace EFMVC.CommandProcessor.Command
{
    public interface IValidationHandler<in TCommand> where TCommand : ICommand
    {
        IEnumerable<ValidationResult>  Validate(TCommand command);
    }
}
