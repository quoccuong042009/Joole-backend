using Joole_BackEnd.Core.Domain;
using Joole_BackEnd.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Joole_BackEnd.Persistence.Repositories
{
    public class ManufacturerRepository : Repository<Manufacturer>, IManufacturerRepository
    {
        public ManufacturerRepository(JooleContext context) : base(context)
        {
        }

        public JooleContext JooleContext
        {
            get { return Context as JooleContext; }
        }

        public IEnumerable<Manufacturer> GetManufacturersBySubCategoryId(int id)
        {
            return (from product in JooleContext.Products
                    where product.SubCategoryId == id
                    select product.Manufacturer);
        }
    }
}