﻿using Microsoft.AspNetCore.Mvc;
using Route.C41.MVC.BLL.Interfaces;
using Route.C41.MVC.BLL.Repositories;
using Route.C41.MVC.DAL.Models;

namespace Route.C41.MVC.PL.Controllers
{
    //[ValidateAntiForgeryToken]
    public class EmployeeController : Controller
    {
        private readonly IGenericRepository<Employee> _employeeRepository;
        //private readonly IGenericRepository<Department> _departmentRepository;


        public EmployeeController(IGenericRepository<Employee> EmployeeRepository/*, IGenericRepository<Department> departmentRepository*/)
        {
            _employeeRepository = EmployeeRepository;
            //_departmentRepository = departmentRepository;
        }
        #region Actions
        public IActionResult Index()
        {
            var allEmployees = _employeeRepository.GetAll();

            return View(allEmployees);
        }


        public IActionResult Create()
        {
            //ViewData["Departments"] = __departmentRepository.GetAll();

            return View();
        }


        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var count = _employeeRepository.Add(employee);
                if (count > 0)
                {
                    TempData["Message"] = "Employee created successfully";
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(employee);
        }

        public IActionResult Details([FromRoute] int? id, string ActionName = "Details")
        {
            if (id is null)
                return BadRequest();

            var employee = _employeeRepository.Get(id.Value);
            if (employee == null)
                return NotFound();

            return View(ActionName, employee);
        }
        public IActionResult Edit([FromRoute] int? id)
        {
            return Details(id, "Edit");
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var count = _employeeRepository.Update(employee);
                if (count > 0) {
                    TempData["Message"] = "Employee updated successfully";
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(employee);
        }


        public IActionResult Delete([FromRoute] int? id)
        {
            return Details(id, "Delete");
        }


        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            var count = _employeeRepository.Delete(employee);
            if (count > 0)
            {
                TempData["Message"] = "Employee deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }
        #endregion

    }
}
