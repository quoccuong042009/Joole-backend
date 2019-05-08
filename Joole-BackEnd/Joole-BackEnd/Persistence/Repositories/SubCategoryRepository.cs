using Joole_BackEnd.Core.Domain;
using Joole_BackEnd.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Joole_BackEnd.Persistence.Repositories
{
    public class SubCategoryRepository : Repository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(JooleContext context) : base(context)
        {
        }

        public JooleContext JooleContext
        {
            get { return Context as JooleContext; }
        }

        public IEnumerable<SubCategory> GetSubCategoriesByCategoryId(int id)
        {
            return JooleContext.SubCategories.Where(sc => sc.CategoryId == id).ToList();
        }
    }
}