using Joole_BackEnd.Core.Domain;
using Joole_BackEnd.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Joole_BackEnd.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(JooleContext context): base(context)
        {
        }
    }
}