using Route.C41.MVC.BLL.Interfaces;
using Route.C41.MVC.BLL.Repositories;
using Route.C41.MVC.DAL.Data;
using Route.C41.MVC.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.C41.MVC.BLL.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _applicationContext;

        public IGenericRepository<Department> DepartmentRepository { get ; set; }
        public IGenericRepository<Employee> EmployeeRepository { get ; set; }

        public UnitOfWork(ApplicationContext applicationContext)
        {
            DepartmentRepository = new GenericRepository<Department>(applicationContext);
            EmployeeRepository = new GenericRepository<Employee>(applicationContext);
            _applicationContext = applicationContext;
        }

        public int Complete()
        {
            return _applicationContext.SaveChanges();
        }

        public void Dispose()
        {
            _applicationContext.Dispose();
        }
    }
}
