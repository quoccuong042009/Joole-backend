using Joole_BackEnd.Controllers.Dto;
using Joole_BackEnd.Core.Domain.Property;
using Joole_BackEnd.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Joole_BackEnd.Persistence.Repositories
{
    public class TypePropRepository : Repository<TypeProperty>, ITypePropRepository
    {
        public TypePropRepository(JooleContext context) : base(context)
        {
        }

        public JooleContext JooleContext
        {
            get { return Context as JooleContext; }
        }

        public IEnumerable<TypePropsListValuesDto> GetTypePropsAndListValuesWithSubCategoryId(int id)
        {
            List<TypePropsListValuesDto> res = new List<TypePropsListValuesDto>();
            SqlParameter param1 = new SqlParameter("@SubCategoryId", id.ToString());
            List<TypePropsStringValueDto> objects = JooleContext.Database.SqlQuery<TypePropsStringValueDto>("TypePropWithListValueBySubCatId @SubCategoryId", param1).ToList();
            foreach(TypePropsStringValueDto o in objects)
            {
                TypePropsListValuesDto temp = new TypePropsListValuesDto(o.Id, o.Name, o.StringValues);
                res.Add(temp);
            }

            return res;
        }
    }
}