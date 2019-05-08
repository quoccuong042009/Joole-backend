using Joole_BackEnd.Core.IRepositories;
using System;
using System.Threading.Tasks;

namespace Joole_BackEnd.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        ICategoryRepository Categories { get; }
        ISubCategoryRepository SubCategories { get; }
        IProductRepository Products { get; }
        Task CompleteAsync();
    }
}