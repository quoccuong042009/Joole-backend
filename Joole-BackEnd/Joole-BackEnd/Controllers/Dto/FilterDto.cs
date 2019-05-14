using Joole_BackEnd.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Joole_BackEnd.Controllers.Dto
{
    public class FilterDto
    {
        public int SubCategoryId { get; set; }
        public IEnumerable<TypePropsListValuesDto> TypePropsListValuesDtos { get; set; }
        public IEnumerable<TechPropsMinMaxValueDto> TechPropsMinMaxValueDtos { get; set; }
        public IEnumerable<Manufacturer> Manufacturers { get; set; }

        public FilterDto()
        {

        }

        public FilterDto(int subCategoryId, IEnumerable<TypePropsListValuesDto> typePropsListValuesDtos, IEnumerable<TechPropsMinMaxValueDto> techPropsMinMaxValueDtos, IEnumerable<Manufacturer> manufacturers)
        {
            SubCategoryId = subCategoryId;
            TypePropsListValuesDtos = typePropsListValuesDtos;
            TechPropsMinMaxValueDtos = techPropsMinMaxValueDtos;
            Manufacturers = manufacturers;
        }
    }
}