using Joole_BackEnd.Core.Domain.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Joole_BackEnd.Core.Domain.ManyToMany
{
    public class SubCatToTechProp
    {
        public int ProductId { get; set; }
        public int TechPropertyId { get; set; }
        public Product Product { get; set; }
        public TechProperty TechProperty { get; set; }
    }
}