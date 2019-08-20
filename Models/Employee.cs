using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netCoreMVCCRUD.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public string EmployeeCode { get; set; }
        public string Position { get; set; }
        public string OfficeLocation { get; set; }
    }
}
