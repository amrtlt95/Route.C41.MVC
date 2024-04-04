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

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            //return _applicationContext.Set<T>().AsNoTracking().ToList();
            return await _applicationContext.Set<T>().ToListAsync();

        }

        public async Task<T> GetAsync(int id)
        {
            return await _applicationContext.FindAsync<T>(id);
        }

        public void Update(T entity)
        {
            _applicationContext.Update(entity);
           
        }
    }
}
