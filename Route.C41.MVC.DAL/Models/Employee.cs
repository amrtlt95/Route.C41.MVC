using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Route.C41.MVC.DAL.Models
{

    public enum Gender
    {
        [EnumMember(Value ="Male")]
        Male=1 ,
        [EnumMember(Value = "Female")]
        Female = 2
    }

    public enum EmployeeType
    {
        [EnumMember(Value ="Full Time")]
        FullTime=1,
        [EnumMember(Value ="Part Time")]
        PartTime=2
    }
    internal class Employee : ModelBase
    {

        [MinLength(3)]
        public string Name { get; set; }

        [Range(20,50)]
        public int? Age { get; set; }

        [RegularExpression("^[0-9]{1,4}-[A-Za-z]{4,20]-[A-Za-z]{4,20]-[A-Za-z]{4,20]$" 
            , ErrorMessage ="Address must be like 123-Street-City-Country")]
        public string Address { get; set; }


        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [Display(Name="Is Active?")]
        public bool IsActive { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }


        public DateTime CreationDate{ get; set; }

        [Display(Name= "Hiring Date")]
        public DateTime HiringDate { get; set; }

        public bool IsDeleted { get; set; }



    }
}
