using Joole_BackEnd.Core.Domain.ManyToMany;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Joole_BackEnd.Core.Domain
{
    public class SubCategory
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<TypePropVal> TypeProperties { get; set; }
        public ICollection<TechPropVal> TechProperties { get; set; }
        public SubCategory()
        {
            TypeProperties = new Collection<TypePropVal>();
            TechProperties = new Collection<TechPropVal>();
        }
    }
}