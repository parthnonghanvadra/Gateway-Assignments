using HRM.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRM.DAL.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(int id);
        string AddEmployee(Employee employee);
        string EditEmployee(Employee employee);
        string DeleteEmployee(int id);

        IEnumerable<Employee> GetManager();
    }
}
