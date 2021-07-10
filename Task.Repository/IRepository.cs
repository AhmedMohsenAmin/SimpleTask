using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Task.Repository
{
    public interface IRepository<T> where T : class
    {
        // Get ALL
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, string includeProperties = "");
        Task<IEnumerable<T>> GetAll(string includeProperties = "");

        // Get By Key
        Task<T> GetByKey(long Id);
        Task<T> GetEntity(T Entity);
        Task<T> GetEntity(Expression<Func<T, bool>> filter = null);
        Task<T> GetEntity(long Id, string IncludeProperties = "");

        // Add New Entity
        System.Threading.Tasks.Task Add(T entity);
        System.Threading.Tasks.Task AddRange(IEnumerable<T> entities);

        // Update Entity
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);

        // Delete Entity
        void Delete(long Id);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
    }
}
