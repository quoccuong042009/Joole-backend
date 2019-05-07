using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Joole_BackEnd.Core.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Remove(TEntity entity);
    }
}