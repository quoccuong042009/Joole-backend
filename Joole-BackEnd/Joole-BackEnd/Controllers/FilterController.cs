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
    [RoutePrefix("api/filter")]
    public class FilterController : ApiController
    {
        public IUnitOfWork UnitOfWork { get; }
        public FilterController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        [Route("subcategory/{id}")]
        [HttpGet]
        public FilterDto GetFilterDtoBySubCategoryId(int id)
        {
            return new FilterDto(id, UnitOfWork.TypeProps.GetTypePropsAndListValuesWithSubCategoryId(id),
                UnitOfWork.TechProps.GetTechPropsAndMinMaxValueWithSubCategoryId(id),
                UnitOfWork.Manufacturers.GetManufacturersBySubCategoryId(id));
        }

        [Route("")]
        [HttpPost]
        public IEnumerable<ProductDto> getProductDtosByFilterDto(FilterDto filterDto)
        {
            List<ProductDto> products = UnitOfWork.Products.GetProductDtosWithSubCategoryId(filterDto.SubCategoryId).ToList();

            //For Type
            foreach(TypePropsListValuesDto type in filterDto.TypePropsListValuesDtos)
            {
                if(type.Name == "Model Year")
                {
                    products = products.Where(p =>
                    compareStringFromYear(p.TypeProps.Single(t => t.Name == type.Name).StringValues, type.ListValues.ElementAt(0)) &&
                    compareStringToYear(p.TypeProps.Single(t => t.Name == type.Name).StringValues, type.ListValues.ElementAt(1))
                    ).ToList();
                }
                else
                {
                    if(type.ListValues.Count() == 1)
                        products = products.Where(p => p.TypeProps.Single(t => t.Name == type.Name).StringValues == type.ListValues.First().ToString()).ToList();
                }
            }

            //For Tech
            foreach (TechPropsMinMaxValueDto type in filterDto.TechPropsMinMaxValueDtos)
            {
                products = products.Where(p => 
                p.TechProps.Single(t => t.Name == type.Name).MinValue >= type.MinValue && 
                p.TechProps.Single(t => t.Name == type.Name).MaxValue <= type.MaxValue
                ).ToList();
            }

            //For Manufacturer
            if(filterDto.Manufacturers.Count() == 1)
            {
                products = products.Where(p => p.Product.Manufacturer.Name == filterDto.Manufacturers.First().Name.ToString()).ToList();
            }

            return products;
        }


        public bool compareStringFromYear(string year, string from)
        {
            int intYear = Int32.Parse(year);
            int intFrom = Int32.Parse(from);

            return intFrom <= intYear;
        }

        public bool compareStringToYear(string year, string to)
        {
            int intYear = Int32.Parse(year);
            int intTo = Int32.Parse(to);

            return  intYear <= intTo;
        }
    }
}
