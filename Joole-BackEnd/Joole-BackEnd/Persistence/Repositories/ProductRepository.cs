using Joole_BackEnd.Controllers.Dto;
using Joole_BackEnd.Core.Domain;
using Joole_BackEnd.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Joole_BackEnd.Persistence.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(JooleContext context) : base(context)
        {
        }

        public JooleContext JooleContext
        {
            get { return Context as JooleContext; }
        }

        public ProductDto GetProductDtosById(int id)
        {
            Product product = JooleContext.Products
                .Include(a => a.SubCategory.Category)
                .Include(a => a.Manufacturer.Department)
                .Include(a => a.Series)
                .Include(a => a.ProdDoc)
                .Include(a => a.Sale)
                .Single(p => p.Id == id);

            SqlParameter param1 = new SqlParameter("@ProductId", id);
            SqlParameter param2 = new SqlParameter("@ProductId", id);
            IEnumerable<TypePropsStringValueDto> type = JooleContext.Database.SqlQuery<TypePropsStringValueDto>("TypePropValueByProductId @ProductId", param1).ToList();
            IEnumerable<TechPropsMinMaxValueDto> tech = JooleContext.Database.SqlQuery<TechPropsMinMaxValueDto>("TechPropValueByProductId @ProductId", param2).ToList();

            return new ProductDto(product, type, tech);
        }

        public IEnumerable<ProductDto> GetProductDtosWithSubCategoryId(int id)
        {
            List<ProductDto> res = new List<ProductDto>();
            List<Product> products = JooleContext.Products
                .Include(a => a.SubCategory.Category)
                .Include(a => a.Manufacturer.Department)
                .Include(a => a.Series)
                .Include(a => a.ProdDoc)
                .Include(a => a.Sale)
                .Where(p => p.SubCategoryId == id).ToList();

            foreach(Product e in products)
            {
                SqlParameter param1 = new SqlParameter("@ProductId", e.Id);
                SqlParameter param2 = new SqlParameter("@ProductId", e.Id);
                IEnumerable<TypePropsStringValueDto> type = JooleContext.Database.SqlQuery<TypePropsStringValueDto>("TypePropValueByProductId @ProductId", param1).ToList();
                IEnumerable<TechPropsMinMaxValueDto> tech = JooleContext.Database.SqlQuery<TechPropsMinMaxValueDto>("TechPropValueByProductId @ProductId", param2).ToList();
                res.Add(new ProductDto(e, type, tech));
            }

            return res;
        }
    }
}