using Microsoft.AspNetCore.Mvc;
using Route.C41.MVC.BLL.Interfaces;
using Route.C41.MVC.BLL.Repositories;
using Route.C41.MVC.DAL.Models;
using System.Threading.Tasks;

namespace Route.C41.MVC.PL.Controllers
{
    //[ValidateAntiForgeryToken]
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        //private readonly IGenericRepository<Department> _departmentRepository;


        public DepartmentController(IUnitOfWork unitOfWork/*IGenericRepository<Department> Repository<Department>()*/) {
          _unitOfWork = unitOfWork;
            //_departmentRepository = Repository<Department>();
        }
        #region Actions
        public async Task<IActionResult> Index()
        {
            var allDepartments = await _unitOfWork.Repository<Department>().GetAllAsync();

            return View(allDepartments);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Repository<Department>().Add(department);
                var count = await _unitOfWork.CompleteAsync();
                if (count > 0)
                    return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        public async Task<IActionResult> Details([FromRoute]int? id, string ActionName = "Details")
        {
            if (id is null)
                return BadRequest();

            var department = await _unitOfWork.Repository<Department>().GetAsync(id.Value);
            if (department == null)
                return NotFound();

            return View(ActionName, department);
        }
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            return await Details(id, "Edit");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Repository<Department>().Update(department);
                var count = await _unitOfWork.CompleteAsync();
                if (count > 0)
                    return RedirectToAction(nameof(Index));
            }
            return View(department);
        }


        public async Task<IActionResult> Delete([FromRoute]int? id)
        {
            return await Details(id, "Delete");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Department department)
        {
            _unitOfWork.Repository<Department>().Delete(department);
            var count = await _unitOfWork.CompleteAsync();
            if (count > 0)
                return RedirectToAction(nameof(Index));
            return View(department);
        } 
        #endregion

    }
}
