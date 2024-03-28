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

        public int Add(T entity);

        public int Update(T entity);

        public int Delete(T entity);

    }
}
