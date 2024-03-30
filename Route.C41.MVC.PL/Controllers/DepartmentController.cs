using Microsoft.AspNetCore.Mvc;
using Route.C41.MVC.BLL.Interfaces;
using Route.C41.MVC.BLL.Repositories;
using Route.C41.MVC.DAL.Models;

namespace Route.C41.MVC.PL.Controllers
{
    //[ValidateAntiForgeryToken]
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        //private readonly IGenericRepository<Department> _departmentRepository;


        public DepartmentController(IUnitOfWork unitOfWork/*IGenericRepository<Department> DepartmentRepository*/) {
          _unitOfWork = unitOfWork;
            //_departmentRepository = DepartmentRepository;
        }
        #region Actions
        public IActionResult Index()
        {
            var allDepartments = _unitOfWork.DepartmentRepository.GetAll();

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
                _unitOfWork.DepartmentRepository.Add(department);
                var count = _unitOfWork.Complete();
                if (count > 0)
                    return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        public IActionResult Details([FromRoute]int? id, string ActionName = "Details")
        {
            if (id is null)
                return BadRequest();

            var department = _unitOfWork.DepartmentRepository.Get(id.Value);
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
                _unitOfWork.DepartmentRepository.Update(department);
                var count = _unitOfWork.Complete();
                if (count > 0)
                    return RedirectToAction(nameof(Index));
            }
            return View(department);
        }


        public IActionResult Delete([FromRoute]int? id)
        {
            return Details(id, "Delete");
        }


        [HttpPost]
        public IActionResult Delete(Department department)
        {
            _unitOfWork.DepartmentRepository.Delete(department);
            var count = _unitOfWork.Complete();
            if (count > 0)
                return RedirectToAction(nameof(Index));
            return View(department);
        } 
        #endregion

    }
}
