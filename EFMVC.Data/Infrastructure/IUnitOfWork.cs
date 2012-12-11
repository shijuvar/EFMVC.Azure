using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFMVC.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
