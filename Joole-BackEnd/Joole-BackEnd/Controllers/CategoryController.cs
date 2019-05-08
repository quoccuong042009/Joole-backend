using Joole_BackEnd.Core;
using Joole_BackEnd.Core.Domain;
using Joole_BackEnd.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Joole_BackEnd.Controllers
{
    [JwtAuthentication]
    [RoutePrefix("api/categories")]
    public class CategoryController : ApiController
    {
        public IUnitOfWork UnitOfWork { get; }
        public CategoryController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        [JwtAuthentication]
        [Route("")]
        [HttpGet]
        public IEnumerable<Category> GetCategories()
        {
            return UnitOfWork.Categories.GetAll();
        }
    }
}
