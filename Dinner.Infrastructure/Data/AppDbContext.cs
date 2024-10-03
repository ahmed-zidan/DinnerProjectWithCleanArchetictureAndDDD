using Dinner.Domain.Common.Models;
using Dinner.Domain.MenuAggregate;
using Dinner.Infrastructure.Interceptors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dinner.Infrastructure.Data
{
    public class AppDbContext:DbContext
    {
        private readonly PublishedDomainEventsInterceptor publishedDomainEventsInterceptor;
        public AppDbContext(DbContextOptions<AppDbContext> options, PublishedDomainEventsInterceptor publishedDomainEventsInterceptor) : base(options)
        {
            this.publishedDomainEventsInterceptor = publishedDomainEventsInterceptor;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Ignore<List<IDomainEvent>>()
                .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
         }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(publishedDomainEventsInterceptor);
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Menu> Menus { get; set; }

    }
}
