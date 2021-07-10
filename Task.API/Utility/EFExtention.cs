using AutoMapper;
using Task.DAL;
using Task.DAL.Context;
using Task.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task.API.Utility
{
    public static class EFExtention
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, string connectionString)
        {
            // add connection string
            services.AddDbContext<TaskContext>(options => options.UseSqlServer(connectionString, x => x.MigrationsAssembly("Task.API")));

            // add ref. for UOW 
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // add ref. auto-mapper
            //var config = new MapperConfiguration(cfg =>
            //{
            //    //cfg.AddProfile(new CMSMapper());
            //    cfg.AddProfile<CMSMapper>();
            //});
            //var mapper = config.CreateMapper(); //var mapper = new Mapper(config);
            //config.AssertConfigurationIsValid();
            //config.AddCollectionMappers();

            //services.AddSingleton(mapper);

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            return services;
        }
    }
}
