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
    [RoutePrefix("api/techprop")]
    public class TechPropController : ApiController
    {
        public IUnitOfWork UnitOfWork { get; }
        public TechPropController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        [Route("minmaxvalue/subcategory/{id}")]
        [HttpGet]
        public IEnumerable<TechPropsMinMaxValueDto> GetTechPropsAndMinMaxValueWithSubCategoryId(int id)
        {
            return UnitOfWork.TechProps.GetTechPropsAndMinMaxValueWithSubCategoryId(id);
        }

    }
}
