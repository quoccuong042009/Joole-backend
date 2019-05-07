using AutoMapper;
using Joole_BackEnd.Controllers.Dto;
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

        public UserController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return UnitOfWork.Users.GetAll();
        }

        [HttpPost]
        public HttpResponseMessage Login(User User)
        {
            User tempUser = UnitOfWork.Users.SingleOrDefault(u => u.Username == User.Username);

            if(tempUser != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Good");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "NotGood");
            }
            //if (u == null)
            //    return Request.CreateResponse(HttpStatusCode.NotFound, "The user was not found.");

            //bool credentials = u.Password.Equals(user.Password);

            //if (!credentials) return Request.CreateResponse(HttpStatusCode.Forbidden,
            //    "The username/password combination was wrong.");

            //return Request.CreateResponse(HttpStatusCode.OK, TokenManager.GenerateToken(user.Username));
        }
    }
}
