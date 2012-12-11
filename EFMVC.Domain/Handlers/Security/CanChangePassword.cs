using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFMVC.Data.Repositories;
using EFMVC.Core.Common;
using EFMVC.CommandProcessor.Command;
using EFMVC.Model;
using EFMVC.Domain.Commands;
using EFMVC.Domain.Properties;

namespace EFMVC.Domain.Handlers
{
    public class CanChangePassword : IValidationHandler<ChangePasswordCommand>
    {
         private readonly IUserRepository userRepository;
         public CanChangePassword(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
         public IEnumerable<ValidationResult> Validate(ChangePasswordCommand command)
        {
            User user = userRepository.GetById(command.UserId);
            var encoded = Md5Encrypt.Md5EncryptPassword(command.OldPassword);      

           if (!user.PasswordHash.Equals(encoded))
            {
                yield return new ValidationResult("OldPassword", Resources.Password);
            }
        }
    }
}
