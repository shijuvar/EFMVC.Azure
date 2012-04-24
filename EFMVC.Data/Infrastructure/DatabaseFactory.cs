using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFMVC.Data.Infrastructure
{
public class DatabaseFactory : Disposable, IDatabaseFactory
{
    private EFMVCDataContex dataContext;
    public EFMVCDataContex Get()
    {
        return dataContext ?? (dataContext = new EFMVCDataContex());
    }
    protected override void DisposeCore()
    {
        if (dataContext != null)
            dataContext.Dispose();
    }
}
}
