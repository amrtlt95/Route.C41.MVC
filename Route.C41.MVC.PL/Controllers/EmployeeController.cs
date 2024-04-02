using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Route.C41.MVC.BLL.Interfaces;
using Route.C41.MVC.BLL.Repositories;
using Route.C41.MVC.DAL.Models;
using Route.C41.MVC.PL.ViewModels.Employee;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Route.C41.MVC.PL.Controllers
{
    //[ValidateAntiForgeryToken]
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public IMapper _mapper { get; }

        //private readonly IGenericRepository<Employee> _employeeRepository;
        //private readonly IGenericRepository<Department> _departmentRepository;



        public EmployeeController(IUnitOfWork unitOfWork , IMapper mapper /*IGenericRepository<Employee> Repository<Employee>()*//*, IGenericRepository<Department> departmentRepository*/)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

            //_employeeRepository = Repository<Employee>();
            //_departmentRepository = departmentRepository;
        }
        #region Actions
        public IActionResult Index()
        {
            var allEmployees = _unitOfWork.Repository<Employee>().GetAll();

            var allEmpViewModel = _mapper.Map<IEnumerable<EmployeeViewModel>>(allEmployees);
            //var allEmpViewModel = allEmployees.Select(e => _mapper.Map<EmployeeViewModel>(e));
            //var allEmpViewModel = Enumerable.Empty<EmployeeViewModel>();
            //foreach (var employee in allEmployees)
            //{
            //    allEmpViewModel.Append(_mapper.Map<EmployeeViewModel>( employee));
            //}
            //var allEmployeeViewModel = 

            return View(allEmpViewModel);
        }


        public IActionResult Create()
        {
            //ViewData["Departments"] = _departmentRepository.GetAll();

            return View();
        }


        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                var employee = _mapper.Map<Employee>(employeeViewModel);
                _unitOfWork.Repository<Employee>().Add(employee);
                var count = _unitOfWork.Complete();
                if (count > 0)
                {
                    TempData["Message"] = "Employee created successfully";
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(employeeViewModel);
        }

        public IActionResult Details([FromRoute] int? id, string ActionName = "Details")
        {
            if (id is null)
                return BadRequest();

            var employee = _unitOfWork.Repository<Employee>().Get(id.Value);
            if (employee == null)
                return NotFound();

            var mappedEmployeeViewModel=_mapper.Map<EmployeeViewModel>(employee);
            return View(ActionName, mappedEmployeeViewModel);
        }
        public IActionResult Edit([FromRoute] int? id)
        {
            return Details(id, "Edit");
        }

        [HttpPost]
        public IActionResult Edit(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                var employee = _mapper.Map<Employee>(employeeViewModel);
                _unitOfWork.Repository<Employee>().Update(employee);
                var count = _unitOfWork.Complete();
                if (count > 0) {
                    TempData["Message"] = "Employee updated successfully";
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(employeeViewModel);
        }


        public IActionResult Delete([FromRoute] int? id)
        {
            return Details(id, "Delete");
        }


        [HttpPost]
        public IActionResult Delete(EmployeeViewModel employeeViewModel)
        {
            var employee = _mapper.Map<Employee>(employeeViewModel);
            _unitOfWork.Repository<Employee>().Delete(employee);
            var count = _unitOfWork.Complete();
            if (count > 0)
            {
                TempData["Message"] = "Employee deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(employeeViewModel);
        }
        #endregion

    }
}
