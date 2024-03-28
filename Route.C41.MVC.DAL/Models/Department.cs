using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.C41.MVC.DAL.Models
{
    public class Department
    {
        public int ID { get; set; }

        public string Name { get; set; }

        [Required(ErrorMessage ="Code cannot be empty ya hamada!!!!!!!!!!!!!!!!!!")]
        public string Code { get; set; }

        public DateTime DateCreated { get; set; }


    }
}
