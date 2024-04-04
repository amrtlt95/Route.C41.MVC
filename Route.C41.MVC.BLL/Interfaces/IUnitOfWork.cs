using Route.C41.MVC.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.C41.MVC.BLL.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        //public IGenericRepository<Department> DepartmentRepository{ get; set; }
        //public IGenericRepository<Employee> EmployeeRepository{ get; set; }
        IGenericRepository<T> Repository<T>() where T : ModelBase;


        Task<int> CompleteAsync();

    }
}
