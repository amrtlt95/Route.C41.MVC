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
        [EnumMember(Value ="Female")]
        Female =2 
    }

    public enum EmployeeType
    {
        [EnumMember(Value ="Full Time")]
        FullTime=1,
        [EnumMember(Value ="Part Time")]
        PartTime=2
    }
    public class Employee : ModelBase
    {
        


        [MaxLength(50 , ErrorMessage ="Max Length of Name is 50 charachters")]
        [MinLength(10,ErrorMessage ="Minimum length of name is 10")]
        public string Name { get; set; }

        [Range(20,50)]
        public int? Age { get; set; }

        [RegularExpression(@"^[0-9]{1,3}-[A-Za-z]{5,10}-[A-Za-z]{4,10}-[A-Za-z]{5,10}$", ErrorMessage = "Address must be like 123-Street-City-Country")]
        public string Address { get; set; }


        public Gender Gender{ get; set; }

        [Display(Name="Employee Type")]
        public EmployeeType EmployeeType { get; set; }


        [DataType(DataType.Currency)]
        public Decimal Salary { get; set; }

        public bool IsActive { get; set; }


        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [DataType(DataType.PhoneNumber)]
        [Display(Name="Phone Number")]
        public string Phone { get; set; }


        [Display(Name="Hiring Date")]
        public DateTime HiringDate { get; set; }

        public DateTime CreationDate { get; set; }


        public bool IsDeleted { get; set; }


    }
}
