using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRM.BusinessEntities;
using HRM.BAL.Interfaces;
using HRM.ViewLayer.Filters;
using Microsoft.AspNetCore.Authorization;

namespace HRM.ViewLayer.Controllers
{
    [ResponseCache(Duration = 5, Location = ResponseCacheLocation.None, NoStore = true)]
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeManager _employeeManager;
        private readonly IDepartmentManager _departmentManager;

        public EmployeesController(IEmployeeManager employeeManager, IDepartmentManager departmentManager)
        {
            _employeeManager = employeeManager;
            _departmentManager = departmentManager;
        }

        // GET: Employees
        public IActionResult Index()
        {
            var employees = _employeeManager.GetEmployees();
            return View(employees);
        }

        // GET: Employees/Details/5
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var employee = _employeeManager.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [ResponseCache(Duration = 60)]
        // GET: Employees/Create
        public IActionResult Create()
        {
            var departments = _departmentManager.GetDepartments();
            var managers = _employeeManager.GetManager();
            ViewData["Manager"] = new SelectList(managers, "Id", "Name");
            ViewData["DepartmentId"] = new SelectList(departments, "Id", "Name");
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Salary,IsManager,Manager,Phone,Email,DepartmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                string response = _employeeManager.AddEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            var departments = _departmentManager.GetDepartments();
            var managers = _employeeManager.GetManager();
            ViewData["Manager"] = new SelectList(managers, "Id", "Name", employee.Manager);
            ViewData["DepartmentId"] = new SelectList(departments, "Id", "Name", employee.DepartmentId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var employee = _employeeManager.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }

            var departments = _departmentManager.GetDepartments();
            var managers = _employeeManager.GetManager();
            ViewData["Manager"] = new SelectList(managers, "Id", "Name", employee.Manager);
            ViewData["DepartmentId"] = new SelectList(departments, "Id", "Name", employee.DepartmentId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Salary,IsManager,Manager,Phone,Email,DepartmentId")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string reponse = _employeeManager.EditEmployee(employee);
                }
                catch (Exception)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            var departments = _departmentManager.GetDepartments();
            var managers = _employeeManager.GetManager();
            ViewData["Manager"] = new SelectList(managers, "Id", "Name", employee.Manager);
            ViewData["DepartmentId"] = new SelectList(departments, "Id", "Name", employee.DepartmentId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var employee = _employeeManager.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            string reponse = _employeeManager.DeleteEmployee(id);
            return RedirectToAction(nameof(Index));
        }

    }
}


