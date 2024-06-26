﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.C41.MVC.BLL.Interfaces
{
    public interface IGenericRepository<T>
    {
        public IEnumerable<T> GetAll();

        public T Get(int id);

        public void Add(T entity);
             
        public void Update(T entity);
              
        public void Delete(T entity);

    }
}
