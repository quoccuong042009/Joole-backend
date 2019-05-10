using Joole_BackEnd.Core;
using Joole_BackEnd.Core.Domain;
using Joole_BackEnd.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Joole_BackEnd.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [JwtAuthentication]
    [RoutePrefix("api/subcategories")]
    public class SubCategoryController : ApiController
    {
        public IUnitOfWork UnitOfWork { get; }
        public SubCategoryController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        [Route("category/{id}")]
        [HttpGet]
        public IEnumerable<SubCategory> GetSubCategoriesByCategoryId(int id)
        {
            return UnitOfWork.SubCategories.GetSubCategoriesByCategoryId(id);
        }
    }
}
