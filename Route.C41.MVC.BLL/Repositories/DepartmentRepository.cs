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
    internal class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationContext _context;

        public DepartmentRepository(ApplicationContext context) {
            _context = context;
        }
        public int Add(Department entity)
        {
            _context.Add(entity);
            return _context.SaveChanges();
        }

        public int Delete(Department entity)
        {
            _context.Remove(entity);
            return _context.SaveChanges();
        }

        public Department Get(int id)
        {
            return _context.Find<Department>(id);
        }

        public IEnumerable<Department> GetAll()
        {
            return _context.Departments.ToList();
        }

        public int Update(Department entity)
        {
            _context.Update(entity);
            return _context.SaveChanges();
        }
    }
}
