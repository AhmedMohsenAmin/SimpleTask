using Task.DAL.Map;
using Task.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.DAL.Context
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {

        }

        public DbSet<Step> Step { set; get; }        
        public DbSet<Item> Item { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new StepMap(modelBuilder.Entity<Step>());
            new ItemMap(modelBuilder.Entity<Item>());
        }
    }
}
