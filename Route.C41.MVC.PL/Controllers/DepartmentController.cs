using Microsoft.AspNetCore.Mvc;
using Route.C41.MVC.BLL.Interfaces;
using Route.C41.MVC.DAL.Models;

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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid && _departmentRepository.Add(department) > 0)
                return RedirectToAction("Index");
            return View(department);

        }

        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var department = _departmentRepository.Get(id.Value);
            if (department is null)
                return NotFound();

            return View(department);

        }

    }
}
