﻿using Microsoft.AspNetCore.Mvc;
using Route.C41.MVC.BLL.Interfaces;
using Route.C41.MVC.DAL.Models;

namespace Route.C41.MVC.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IGenericRepository<Department> _departmentRepository;


        public DepartmentController(IGenericRepository<Department> DepartmentRepository) {
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

        public IActionResult Details(int? id, string viewName = "Details")
        {
            if (!id.HasValue)
                return BadRequest();

            var department = _departmentRepository.Get(id.Value);
            if (department is null)
                return NotFound();

            return View(viewName,department);

        }

        public IActionResult Edit(int? id)
        {
            return Details(id,"Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute]int id ,Department department)
        {
            if(id != department.ID)
                return BadRequest();

            if(!ModelState.IsValid) 
                return View(department);

            _departmentRepository.Update(department);

            return RedirectToAction("Index");
    
        }

        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }

        [HttpPost]
        public IActionResult Delete(Department department)
        {
            _departmentRepository.Delete(department);
            return RedirectToAction("Index");
        }

    }
}
