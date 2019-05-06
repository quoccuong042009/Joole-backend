using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Joole_BackEnd.Core.Domain.ManyToMany
{
    public class ProjToProd
    {
        public int ProjectId { get; set; }
        public int ProductId { get; set; }
        public Project Project { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}