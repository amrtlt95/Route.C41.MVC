using Microsoft.EntityFrameworkCore;
using Route.C41.MVC.DAL.Data.Configurations;
using Route.C41.MVC.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Route.C41.MVC.DAL.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new DepartmentConfigurations());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

       public DbSet<Department> Departments { get; set; }

    }
}
