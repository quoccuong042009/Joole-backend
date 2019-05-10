using Joole_BackEnd.Controllers.Dto;
using Joole_BackEnd.Core.Domain;
using Joole_BackEnd.Core.Domain.Property;
using Joole_BackEnd.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Joole_BackEnd.Persistence.Repositories
{
    public class TechPropRepository : Repository<TechProperty>, ITechPropRepository
    {
        public TechPropRepository(JooleContext context) : base(context)
        {
        }

        public JooleContext JooleContext
        {
            get { return Context as JooleContext; }
        }

        public IEnumerable<TechPropsMinMaxValueDto> GetTechPropsAndMinMaxValueWithSubCategoryId(int id)
        {
            SqlParameter param1 = new SqlParameter("@SubCategoryId", id.ToString());
            return JooleContext.Database.SqlQuery<TechPropsMinMaxValueDto>("TechPropWithMinMaxValueBySubCatId @SubCategoryId", param1).ToList();
        }
    }
}