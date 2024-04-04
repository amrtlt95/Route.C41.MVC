using Route.C41.MVC.DAL.Models;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http;
using System.Runtime.CompilerServices;

namespace Route.C41.MVC.PL.ViewModels.Employee
{
    public class EmployeeViewModel
    {
        public int ID { get; set; }

        [MinLength(3)]
        public string Name { get; set; }

        [Range(20, 50)]
        public int? Age { get; set; }

        [RegularExpression("^[0-9]{1,4}-[A-Za-z]{4,20]-[A-Za-z]{4,20]-[A-Za-z]{4,20]$"
            , ErrorMessage = "Address must be like 123-Street-City-Country")]
        public string Address { get; set; }


        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [Display(Name = "Is Active?")]
        public bool IsActive { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public Gender Gender { get; set; }

        [Display(Name = "Employee type")]
        public EmployeeType EmployeeType { get; set; }



        [Display(Name = "Hiring Date")]
        public DateTime HiringDate { get; set; }




        //foreign Key
        public int? DepartmentID { get; set; }

        //navigational property
        public virtual Department? Department { get; set; }

        public string ImageName { get; set; }


  
        public IFormFile Image { get; set; }
    }
}
