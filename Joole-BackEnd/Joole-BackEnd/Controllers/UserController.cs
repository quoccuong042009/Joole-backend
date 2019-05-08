using AutoMapper;
using Joole_BackEnd.Controllers.Dto;
using Joole_BackEnd.Core;
using Joole_BackEnd.Core.Domain;
using Joole_BackEnd.Filter;
using Joole_BackEnd.Jwt;
using Joole_BackEnd.PasswordHelper;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Joole_BackEnd.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        public IUnitOfWork UnitOfWork { get; }
        public UserController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        [JwtAuthentication]
        [Route("")]
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return UnitOfWork.Users.GetAll();
        }

        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public HttpResponseMessage Register(UserRegisterDto userRegisterDto)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);

            var user = Mapper.Map<UserRegisterDto, User>(userRegisterDto);

            //Check If Username existed
            User tempUser = UnitOfWork.Users.GetUserWithUsername(user.Username);
            if (tempUser != null)
                return Request.CreateResponse(HttpStatusCode.Forbidden, "Username Has Already Existed");

            user.Password = SecurePasswordHasher.Hash(user.Password);
            UnitOfWork.Users.Add(user);
            UnitOfWork.CompleteAsync();

            return Request.CreateResponse(HttpStatusCode.OK, "Created");
        }

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public HttpResponseMessage Login(User user)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);

            User tempUser = UnitOfWork.Users.GetUserWithUsername(user.Username);

            if (tempUser == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "The User Was Not Found.");
            }

            bool credentials = SecurePasswordHasher.Verify(user.Password, tempUser.Password);

            if (!credentials)
                return Request.CreateResponse(HttpStatusCode.Forbidden,"The username/password combination was wrong.");

            return Request.CreateResponse(HttpStatusCode.OK, JwtManager.GenerateToken(tempUser.Username));
        }
    }
}
