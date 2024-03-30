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
        public void Add(T entity)
        {
          
                 _applicationContext.Add(entity);
               
            
        }

        public void Delete(T entity)
        {
            _applicationContext.Remove(entity);
           
        }

        public IEnumerable<T> GetAll()
        {
            return _applicationContext.Set<T>().AsNoTracking().ToList();
        }

        public T Get(int id)
        {
            return _applicationContext.Find<T>(id);
        }

        public void Update(T entity)
        {
            _applicationContext.Update(entity);
           
        }
    }
}
