using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using EFMVC.Web.Core.Models;

namespace EFMVC.Web.Core.Extensions
{
    public static class SecurityExtensions
    {
      public static string Name(this IPrincipal user)
        {
            return user.Identity.Name;
        }

        public static bool InAnyRole(this IPrincipal user, params string[] roles)
        {
            foreach (string role in roles)
            {
                if (user.IsInRole(role)) return true;
            }
            return false;
        }
        public static EFMVCUser GetEFMVCUser(this IPrincipal principal)
        {
            if (principal.Identity is EFMVCUser)
                return (EFMVCUser)principal.Identity;
            else
                return new EFMVCUser(string.Empty, new UserInfo());
        }
    }    
}
