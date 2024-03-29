using Microsoft.EntityFrameworkCore;
using Route.C41.MVC.BLL.Interfaces;
using Route.C41.MVC.DAL.Data;
using Route.C41.MVC.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.C41.MVC.BLL.Repositories
{
    
    public class GenericRepository<T> : IGenericRepository<T> where T : ModelBase
    {
        private readonly ApplicationContext _applicationContext;

        public GenericRepository(ApplicationContext applicationContext)
        {
           _applicationContext = applicationContext;
        }
        public int Add(T entity)
        {
          
                 _applicationContext.Add(entity);
                return _applicationContext.SaveChanges();
            
        }

        public int Delete(T entity)
        {
            _applicationContext.Remove(entity);
            return _applicationContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _applicationContext.Set<T>().AsNoTracking().ToList();
        }

        public T Get(int id)
        {
            return _applicationContext.Find<T>(id);
        }

        public int Update(T entity)
        {
            _applicationContext.Update(entity);
            return _applicationContext.SaveChanges();
        }
    }
}
