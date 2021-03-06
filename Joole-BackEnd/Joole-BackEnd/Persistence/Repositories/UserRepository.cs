﻿using Joole_BackEnd.Core.Domain;
using Joole_BackEnd.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Joole_BackEnd.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {   

        public UserRepository(JooleContext context): base(context)
        {
        }

        public JooleContext JooleContext
        {
            get { return Context as JooleContext; }
        }

        public User GetUserWithUsername(string Username)
        {
            return JooleContext.Users.SingleOrDefault(u => u.Username == Username);
        }
    }
}