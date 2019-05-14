using Joole_BackEnd.Controllers.Dto;
using Joole_BackEnd.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joole_BackEnd.Core.IRepositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<ProductDto> GetProductDtosWithSubCategoryId(int id);
        ProductDto GetProductDtosById(int id);
    }
}
