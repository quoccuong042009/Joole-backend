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
    [JwtAuthentication]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    //[AllowAnonymous]
    [RoutePrefix("api/manufacturer")]
    public class ManufacturerController : ApiController
    {
        public IUnitOfWork UnitOfWork { get; }
        public ManufacturerController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        [Route("subcategory/{id}")]
        [HttpGet]
        public IEnumerable<Manufacturer> GetManufacturerBySubCategoryId(int id)
        {
            return this.UnitOfWork.Manufacturers.GetManufacturersBySubCategoryId(id);
        }
    }
}
