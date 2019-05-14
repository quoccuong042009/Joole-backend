using Joole_BackEnd.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Joole_BackEnd.Controllers.Dto
{
    public class ProductDto
    {
        public Product Product { get; set; }
        public IEnumerable<TypePropsStringValueDto> TypeProps { get; set; }
        public IEnumerable<TechPropsMinMaxValueDto> TechProps { get; set; }

        public ProductDto(Product product, IEnumerable<TypePropsStringValueDto> typeProps, IEnumerable<TechPropsMinMaxValueDto> techProps)
        {
            Product = product;
            TypeProps = typeProps;
            TechProps = techProps;
        }
    }
}