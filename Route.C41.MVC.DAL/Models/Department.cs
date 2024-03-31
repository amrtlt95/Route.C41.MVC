using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.C41.MVC.DAL.Models
{
    public class Department : ModelBase
    {

        public string Name { get; set; }

        [Required(ErrorMessage ="Code cannot be empty ya hamada!!!!!!!!!!!!!!!!!!")]
        public string Code { get; set; }

        [Display(Name = "Creation Date")]
        public DateTime DateCreated { get; set; }




        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();


    }
}
