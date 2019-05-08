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
        public UnitOfWork(JooleContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
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