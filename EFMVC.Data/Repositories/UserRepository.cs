using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFMVC.Data.Infrastructure;
using EFMVC.Model;

namespace EFMVC.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
        {
        public UserRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
            {
            }           
        }
    public interface IUserRepository : IRepository<User>
    {
    }    
}
