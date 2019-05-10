using Joole_BackEnd.Controllers.Dto;
using Joole_BackEnd.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Joole_BackEnd.Controllers
{
    [AllowAnonymous]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/typeprop")]
    public class TypePropController : ApiController
    {
        public IUnitOfWork UnitOfWork { get; }
        public TypePropController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        [Route("listvalues/subcategory/{id}")]
        [HttpGet]
        public IEnumerable<TypePropsListValuesDto> GetTypePropsAndListValuesWithSubCategoryId(int id)
        {
            return UnitOfWork.TypeProps.GetTypePropsAndListValuesWithSubCategoryId(id);
        }
    }
}
