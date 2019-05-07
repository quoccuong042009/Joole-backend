using Joole_BackEnd.Core.Domain;
using Joole_BackEnd.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joole_BackEnd.Core.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        //Task<User> GetUserWithUsername(string Username);
    }
}
