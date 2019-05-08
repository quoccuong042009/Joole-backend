using Joole_BackEnd.Core.Domain.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Joole_BackEnd.Core.Domain.ManyToMany
{
    public class TechPropToProd
    {
        public int TechPropertyId { get; set; }
        public int ProductId { get; set; }
        public TechProperty TechProperty { get; set; }
        public Product Product { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
    }
}