using Joole_BackEnd.Controllers.Dto;
using Joole_BackEnd.Core;
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
    //[AllowAnonymous]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        public IUnitOfWork UnitOfWork { get; }
        public ProductController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        [Route("productDto/{id}")]
        [HttpGet]
        public ProductDto GetProductDtosById(int id)
        {
            return UnitOfWork.Products.GetProductDtosById(id);
        }

        [Route("productDto/subcategory/{id}")]
        [HttpGet]
        public IEnumerable<ProductDto> GetProductDtosWithSubCategoryId(int id)
        {
            return UnitOfWork.Products.GetProductDtosWithSubCategoryId(id);
        }

        
    }
}
