using Joole_BackEnd.Core;
using Joole_BackEnd.Core.Domain;
using Joole_BackEnd.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Joole_BackEnd.Controllers
{
    [Route("api/users")]
    public class UserController : ApiController
    {
        public IUnitOfWork UnitOfWork { get; }
        //public JooleContext JooleContext { get; }
        //public UserController()
        //{
        //    JooleContext = new JooleContext();
        //    UnitOfWork = new UnitOfWork(JooleContext);
        //}

        public UserController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await UnitOfWork.Users.GetAll();
        }
    }
}
