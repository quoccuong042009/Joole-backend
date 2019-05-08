using Joole_BackEnd.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Joole_BackEnd.Core.IRepositories
{
    public interface ISubCategoryRepository : IRepository<SubCategory>
    {
        IEnumerable<SubCategory> GetSubCategoriesByCategoryId(int id);
    }
}