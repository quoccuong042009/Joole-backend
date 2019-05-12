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
    [RoutePrefix("api/filter")]
    public class FilterController : ApiController
    {
        public IUnitOfWork UnitOfWork { get; }
        public FilterController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        [Route("send/subcategory/{id}")]
        [HttpGet]
        public FilterSendDto GetFilterSentDtoBySubCategoryId(int id)
        {
            return new FilterSendDto(UnitOfWork.TypeProps.GetTypePropsAndListValuesWithSubCategoryId(id),
                UnitOfWork.TechProps.GetTechPropsAndMinMaxValueWithSubCategoryId(id),
                UnitOfWork.Manufacturers.GetManufacturersBySubCategoryId(id));
        }
    }
}
