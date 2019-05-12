using System.Threading.Tasks;
using Joole_BackEnd.Core;
using Joole_BackEnd.Core.IRepositories;
using Joole_BackEnd.Persistence.Repositories;

namespace Joole_BackEnd.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JooleContext _context;
        public IUserRepository Users { get; private set; }
        public ICategoryRepository Categories { get; private set; }

        public ISubCategoryRepository SubCategories { get; private set; }

        public IProductRepository Products { get; private set; }

        public ITechPropRepository TechProps { get; private set; }

        public ITypePropRepository TypeProps { get; private set; }

        public IManufacturerRepository Manufacturers { get; private set; }

        public UnitOfWork(JooleContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Categories = new CategoryRepository(_context);
            SubCategories = new SubCategoryRepository(_context);
            Products = new ProductRepository(_context);
            TechProps = new TechPropRepository(_context);
            TypeProps = new TypePropRepository(_context);
            Manufacturers = new ManufacturerRepository(_context);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}