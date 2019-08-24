using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netCoreMVCCRUD.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Code")]
        public string EmployeeCode { get; set; }

        [Display(Name = "Position")]
        public string Position { get; set; }

        [Display(Name = "Office Location")]
        public string OfficeLocation { get; set; }
    }
}
