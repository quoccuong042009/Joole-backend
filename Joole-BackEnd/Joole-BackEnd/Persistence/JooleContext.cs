using Joole_BackEnd.Core.Domain;
using Joole_BackEnd.Core.Domain.ManyToMany;
using Joole_BackEnd.Core.Domain.Property;
using System.Data.Entity;

namespace Joole_BackEnd.Persistence
{
    public class JooleContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<TypeProperty> TypeProperties { get; set; }
        public DbSet<TechProperty> TechProperties { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<ProdDoc> ProdDocs { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SubCatToTypeProp> SubCatToTypeProp { get; set; }
        public DbSet<SubCatToTechProp> SubCatToTechProp { get; set; }
        public DbSet<TypePropToProd> TypePropToProd { get; set; }
        public DbSet<TechPropToProd> TechPropToProd { get; set; }
        public JooleContext(): base("name=DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubCatToTypeProp>().HasKey(a => new { a.SubCategoryId, a.TypePropertyId });
            modelBuilder.Entity<SubCatToTechProp>().HasKey(a => new { a.SubCategoryId, a.TechPropertyId });
            modelBuilder.Entity<TypePropToProd>().HasKey(a => new { a.ProductId, a.TypePropertyId });
            modelBuilder.Entity<TechPropToProd>().HasKey(a => new { a.ProductId, a.TechPropertyId });
            base.OnModelCreating(modelBuilder);
        }

    }
}
