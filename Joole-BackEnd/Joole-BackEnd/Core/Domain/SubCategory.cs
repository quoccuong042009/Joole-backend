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
        public ICollection<SubCatToTypeProp> TypeProperties { get; set; }
        public ICollection<SubCatToTechProp> TechProperties { get; set; }
        public SubCategory()
        {
            TypeProperties = new Collection<SubCatToTypeProp>();
            TechProperties = new Collection<SubCatToTechProp>();
        }
    }
}