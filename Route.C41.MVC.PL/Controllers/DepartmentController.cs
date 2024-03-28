using Microsoft.AspNetCore.Mvc;
using Route.C41.MVC.BLL.Interfaces;
using Route.C41.MVC.BLL.Repositories;
using Route.C41.MVC.DAL.Models;

namespace Route.C41.MVC.PL.Controllers
{
    //[ValidateAntiForgeryToken]
    public class DepartmentController : Controller
    {
        private readonly IGenericRepository<Department> _departmentRepository;


        public DepartmentController(IGenericRepository<Department> DepartmentRepository) {
            _departmentRepository = DepartmentRepository;
        }
        #region Actions
        public IActionResult Index()
        {
            var allDepartments = _departmentRepository.GetAll();

            return View(allDepartments);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                var count = _departmentRepository.Add(department);
                if (count > 0)
                    return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        public IActionResult Details(int? id, string ActionName = "Details")
        {
            if (id is null)
                return BadRequest();

            var department = _departmentRepository.Get(id.Value);
            if (department == null)
                return NotFound();

            return View(ActionName, department);
        }
        public IActionResult Edit([FromRoute] int id)
        {
            return Details(id, "Edit");
        }

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                var count = _departmentRepository.Update(department);
                if (count > 0)
                    return RedirectToAction(nameof(Index));
            }
            return View(department);
        }


        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }


        [HttpPost]
        public IActionResult Delete(Department department)
        {
            var count = _departmentRepository.Delete(department);
            if (count > 0)
                return RedirectToAction(nameof(Index));
            return View(department);
        } 
        #endregion

    }
}
