using Task.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Task.Repository
{
    public interface IUnitOfWork : IDisposable 
    {
        IRepository<Step> Step { get; }        
        IRepository<Item> Item { get; }

        System.Threading.Tasks.Task Commite();
        DbContext Context { get; }
    }
}
