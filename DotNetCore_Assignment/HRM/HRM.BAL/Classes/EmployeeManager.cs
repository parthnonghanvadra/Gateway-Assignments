using HRM.BAL.Interfaces;
using HRM.BusinessEntities;
using HRM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRM.BAL.Classes
{
    public class EmployeeManager : IEmployeeManager
    {
        IEmployeeRepository _employeeRepository;
        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public string AddEmployee(Employee employee)
        {
            return _employeeRepository.AddEmployee(employee);
        }

        public string DeleteEmployee(int id)
        {
            return _employeeRepository.DeleteEmployee(id);
        }

        public string EditEmployee(Employee employee)
        {
            return _employeeRepository.EditEmployee(employee);
        }

        public Employee GetEmployee(int id)
        {
            return _employeeRepository.GetEmployee(id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeRepository.GetEmployees();
        }

        public IEnumerable<Employee> GetManager()
        {
            return _employeeRepository.GetManager();
        }
    }
}
