using Task.DAL.Context;
using Task.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Task.DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        DbSet<T> table { get; set; }
        public Repository(TaskContext context)
        {
            // _context = context;
            table = context.Set<T>();
        }

        #region Add Entity
        //public async Task Add(T entity) => await table.AddAsync(entity);
        public async System.Threading.Tasks.Task Add(T entity)
        {
            await table.AddAsync(entity);
        }
        public async System.Threading.Tasks.Task AddRange(IEnumerable<T> entities)
        {
            await table.AddRangeAsync(entities);
        }
        #endregion

        #region Update Entity
        public void Update(T entity)
        {
            //table.Attach(entity);
            //_context.Entry(entity).State = EntityState.Modified;
            table.Update(entity);
        }
        public void UpdateRange(IEnumerable<T> entities)
        {
            table.UpdateRange(entities);
        }
        #endregion

        #region Delete Entity
        public void Delete(long id)
        {
            T entity = table.Find(id);            
            Delete(entity);
        }
        public void Delete(T entity)
        {
            //if (_context.Entry(entity).State == EntityState.Detached)
            //    table.Attach(entity);
            table.Remove(entity);
        }
        public void DeleteRange(IEnumerable<T> entities)
        {
            //if (_context.Entry(entities).State == EntityState.Detached)
            //    table.AttachRange(entities);
            table.RemoveRange(entities);
        }
        #endregion

        #region Get Entity
        public async Task<IEnumerable<T>> GetAll()
        {
            return await table.AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, string includeProperties = "")
        {
            IQueryable<T> query = table;

            if (filter != null)
                query = query.Where(filter);

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

            return await query.AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAll(string includeProperties = "")
        {
            IQueryable<T> query = table;

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

            return await query.AsNoTracking().ToListAsync();
        }
        public async Task<T> GetByKey(long id)
        {
            //return await table.SingleAsync(s => s.Id == id);
            return await table.FindAsync(id);
            //return null;
        }
        public async Task<T> GetEntity(T entity)
        {
            IQueryable<T> query = table;
            return await query.SingleOrDefaultAsync(q => q == entity);
        }
        public async Task<T> GetEntity(long id, string includeProperties = "")
        {
            var entity = await GetByKey(id);

            IQueryable<T> query = table;

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

            return await query.SingleOrDefaultAsync(q => q == entity);
        }

        public async Task<T> GetEntity(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = table;

            if (filter != null)
                query = query.Where(filter);

            return await query.SingleOrDefaultAsync();
        }      

        #endregion
    }
}
