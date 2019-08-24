using Asp.netCoreMVCCRUD.Controllers;
using Asp.netCoreMVCCRUD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netCoreMVCCRUD.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public static implicit operator EmployeeContext(EmployeeController v)
        {
            throw new NotImplementedException();
        }
    }
}
