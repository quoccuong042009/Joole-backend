using Joole_BackEnd.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Joole_BackEnd.Controllers.Dto
{
    public class FilterReceiveDto
    {
        public IEnumerable<TypePropsStringValueDto> TypePropsStringValueDtos { get; set; }
        public IEnumerable<TechPropsMinMaxValueDto> TechPropsMinMaxValueDtos { get; set; }
        public IEnumerable<Manufacturer> Manufacturers { get; set; }

        public FilterReceiveDto()
        {
        }

        public FilterReceiveDto(IEnumerable<TypePropsStringValueDto> typePropsStringValueDtos, 
            IEnumerable<TechPropsMinMaxValueDto> techPropsMinMaxValueDtos, 
            IEnumerable<Manufacturer> manufacturers)
        {
            TypePropsStringValueDtos = typePropsStringValueDtos;
            TechPropsMinMaxValueDtos = techPropsMinMaxValueDtos;
            Manufacturers = manufacturers;
        }
    }
}