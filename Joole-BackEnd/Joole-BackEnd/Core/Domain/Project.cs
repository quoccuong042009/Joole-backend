using Joole_BackEnd.Core.Domain.ManyToMany;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Joole_BackEnd.Core.Domain
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<ProjToProd> Products { get; set; }
        public Project()
        {
            Products = new Collection<ProjToProd>();
        }
    }
}