using Microsoft.AspNetCore.Mvc;
using Route.C41.MVC.BLL.Interfaces;

namespace Route.C41.MVC.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;


        public DepartmentController(IDepartmentRepository DepartmentRepository) {
            _departmentRepository = DepartmentRepository;
        }
        public IActionResult Index()
        {
            var allDepartments = _departmentRepository.GetAll();

            return View(allDepartments);
        }


    }
}
