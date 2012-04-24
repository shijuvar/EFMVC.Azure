using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace EFMVC.Web.Core.ActionFilters
{
    public class EFMVCAuthorize : AuthorizeAttribute
    {
        public EFMVCAuthorize(params string[] roles)
        {
            this.Roles = String.Join(", ", roles);
        }
    }
}
