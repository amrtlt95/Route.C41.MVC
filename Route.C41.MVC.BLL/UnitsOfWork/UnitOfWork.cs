using Route.C41.MVC.BLL.Interfaces;
using Route.C41.MVC.BLL.Repositories;
using Route.C41.MVC.DAL.Data;
using Route.C41.MVC.DAL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.C41.MVC.BLL.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _applicationContext;
        private Hashtable _repositories;

        //public IGenericRepository<Department> DepartmentRepository { get ; set; }
        //public IGenericRepository<Employee> EmployeeRepository { get ; set; }

        public UnitOfWork(ApplicationContext applicationContext)
        {
            //DepartmentRepository = new GenericRepository<Department>(applicationContext);
            //EmployeeRepository = new GenericRepository<Employee>(applicationContext);
            _applicationContext = applicationContext;
            _repositories = new Hashtable();
        }

        public int Complete()
        {
            return _applicationContext.SaveChanges();
        }

        public void Dispose()
        {
            _applicationContext.Dispose();
        }

        public IGenericRepository<T> Repository<T>() where T : ModelBase
        {
            var key = typeof(T).Name;

            if( !_repositories.ContainsKey(key) )
            {
                _repositories.Add(key, new GenericRepository<T>(_applicationContext));
            }
            
            return _repositories[key] as IGenericRepository<T>;
        }
    }
}
