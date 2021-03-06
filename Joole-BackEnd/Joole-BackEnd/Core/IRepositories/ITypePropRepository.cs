﻿using Joole_BackEnd.Controllers.Dto;
using Joole_BackEnd.Core.Domain.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joole_BackEnd.Core.IRepositories
{
    public interface ITypePropRepository : IRepository<TypeProperty>
    {
        IEnumerable<TypePropsListValuesDto> GetTypePropsAndListValuesWithSubCategoryId(int id);
    }
}
