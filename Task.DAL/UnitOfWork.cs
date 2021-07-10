using Task.DAL.Context;
using Task.Entity;
using Task.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Task.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<Step> Step { get; }        

        public IRepository<Item> Item { get; }
        public TaskContext _context;

        public DbContext Context { get { return this._context; } }

        public UnitOfWork(TaskContext context)
        {
            _context = context;
            Step = new Repository<Step>(_context);            
            Item = new Repository<Item>(_context);
        }


        public async System.Threading.Tasks.Task Commite()
        {
            Context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
