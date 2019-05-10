using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Joole_BackEnd.Controllers.Dto
{
    public class TechPropsMinMaxValueDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
    }
}