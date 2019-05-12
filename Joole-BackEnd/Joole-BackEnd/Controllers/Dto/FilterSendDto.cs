using Joole_BackEnd.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Joole_BackEnd.Controllers.Dto
{
    public class FilterSendDto
    {
        public IEnumerable<TypePropsListValuesDto> TypePropsListValuesDtos { get; set; }
        public IEnumerable<TechPropsMinMaxValueDto> TechPropsMinMaxValueDtos { get; set; }
        public IEnumerable<Manufacturer> Manufacturers { get; set; }

        public FilterSendDto()
        {

        }

        public FilterSendDto(IEnumerable<TypePropsListValuesDto> typePropsListValuesDtos,
            IEnumerable<TechPropsMinMaxValueDto> techPropsMinMaxValueDtos,
            IEnumerable<Manufacturer> manufacturers)
        {
            TypePropsListValuesDtos = typePropsListValuesDtos;
            TechPropsMinMaxValueDtos = techPropsMinMaxValueDtos;
            Manufacturers = manufacturers;
        }
    }
}