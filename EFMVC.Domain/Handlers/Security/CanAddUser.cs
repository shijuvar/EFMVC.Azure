using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFMVC.Domain.Commands;
using EFMVC.CommandProcessor.Command;
using EFMVC.Data.Infrastructure;
using EFMVC.Data.Repositories;
using EFMVC.Core.Common;
using EFMVC.Model;
using EFMVC.Domain.Properties;

namespace EFMVC.Domain.Handlers
{
     public class CanAddUser : IValidationHandler<UserRegisterCommand>
    {
         private readonly IUserRepository userRepository;
         public CanAddUser(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
         public IEnumerable<ValidationResult> Validate(UserRegisterCommand command)
        {
            User isUserExists = null;
            isUserExists = userRepository.Get(c => c.Email == command.Email);

            if (isUserExists != null)
            {
                yield return new ValidationResult("EMail", Resources.UserExists);
            }
        }
    }
}
