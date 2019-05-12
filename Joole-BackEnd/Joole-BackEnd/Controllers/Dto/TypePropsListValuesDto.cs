using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Joole_BackEnd.Controllers.Dto
{
    public class TypePropsListValuesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> ListValues { get; set; }
    }
}