using Microsoft.AspNetCore.Mvc;
using Route.C41.MVC.BLL.Interfaces;
using Route.C41.MVC.DAL.Models;

namespace Route.C41.MVC.PL.Controllers
{
    public class EmployeeController : Controller
    {
        public EmployeeController(IGenericRepository<Employee>) { }
        public IActionResult Index()
        {
            return View();
        }
    }
}
