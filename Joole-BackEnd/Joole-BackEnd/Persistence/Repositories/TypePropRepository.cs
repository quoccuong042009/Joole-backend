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
            SqlParameter param1 = new SqlParameter("@SubCategoryId", id.ToString());
            List<TypePropsStringValueDto> objects = JooleContext.Database.SqlQuery<TypePropsStringValueDto>("TypePropWithListValueBySubCatId @SubCategoryId", param1).ToList();

            var res = AutoMapper.Mapper.Map<List<TypePropsStringValueDto>, List<TypePropsListValuesDto>>(objects);

            foreach(TypePropsListValuesDto r in res)
            {
                if(r.Name == "Model Year")
                {
                    List<int> intYears = r.ListValues.Select(int.Parse).ToList();
                    intYears.Sort();
                    r.ListValues = new List<string>() { intYears[0].ToString(), intYears[intYears.Count - 1].ToString() };
                }
            }

            return res;
        }
    }
}