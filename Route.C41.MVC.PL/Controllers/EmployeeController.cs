using Microsoft.AspNetCore.Mvc;
using Route.C41.MVC.BLL.Interfaces;
using Route.C41.MVC.DAL.Models;

namespace Route.C41.MVC.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IGenericRepository<Employee> _employeeRepository;


        public EmployeeController(IGenericRepository<Employee> EmployeeRepository) {
            _employeeRepository = EmployeeRepository;
        }
        public IActionResult Index()
        {
            var allEmployees = _employeeRepository.GetAll();

            return View(allEmployees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid && _employeeRepository.Add(employee) > 0)
                return RedirectToAction("Index");
            return View(employee);

        }

        public IActionResult Details(int? id, string viewName = "Details")
        {
            if (!id.HasValue)
                return BadRequest();

            var employee = _employeeRepository.Get(id.Value);
            if (employee is null)
                return NotFound();

            return View(viewName,employee);

        }

        public IActionResult Edit(int? id)
        {
            return Details(id,"Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute]int id ,Employee employee)
        {
            if(id != employee.ID)
                return BadRequest();

            if(!ModelState.IsValid) 
                return View(employee);

            _employeeRepository.Update(employee);

            return RedirectToAction("Index");
    
        }

        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }

        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            _employeeRepository.Delete(employee);
            return RedirectToAction("Index");
        }

    }
}
