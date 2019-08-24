using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.netCoreMVCCRUD.Data;
using Asp.netCoreMVCCRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp.netCoreMVCCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeContext _context;

        public EmployeeController(EmployeeContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<EmployeeViewModel> model =  _context.Set<Employee>().ToList().Select(e => new EmployeeViewModel
            {
                Id = e.Id,
                FullName = e.FullName,
                EmployeeCode = e.EmployeeCode,
                Position = e.Position,
                OfficeLocation = e.OfficeLocation
            });
            return View("Index", model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            EmployeeViewModel model = new EmployeeViewModel();
            Employee employee = _context.Set<Employee>().SingleOrDefault(e => e.Id == Id);
            if (employee != null)
            {
                model.Id = employee.Id;
                model.FullName = employee.FullName;
                model.EmployeeCode = employee.EmployeeCode;
                model.Position = employee.Position;
                model.OfficeLocation = employee.OfficeLocation;
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(EmployeeViewModel employee)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Employee model = new Employee();
                    model.FullName = employee.FullName;
                    model.EmployeeCode = employee.EmployeeCode;
                    model.Position = employee.Position;
                    model.OfficeLocation = employee.OfficeLocation;
                    _context.Add(model);
                    _context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Index");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int Id, EmployeeViewModel employee)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Employee model = _context.Set<Employee>().SingleOrDefault(e => e.Id == Id);
                    model.FullName = employee.FullName;
                    model.EmployeeCode = employee.EmployeeCode;
                    model.Position = employee.Position;
                    model.OfficeLocation = employee.OfficeLocation;
                    _context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Index");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int Id)
        {
            try
            {
                Employee employee = _context.Set<Employee>().SingleOrDefault(e => e.Id == Id);
                _context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }
    }
}