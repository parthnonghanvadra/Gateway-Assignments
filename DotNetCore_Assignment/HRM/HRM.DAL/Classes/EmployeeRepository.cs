using HRM.BusinessEntities;
using HRM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRM.DAL.Classes
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeRepository(ApplicationDbContext db)
        {
            _dbContext = db;
        }

        public string AddEmployee(Employee employee)
        {
            try
            {
                if (employee != null)
                {
                    var res = _dbContext.Employees.Where(x => x.Id == employee.Id).FirstOrDefault();
                    if (res != null)
                    {
                        return "already";
                    }
                    _dbContext.Employees.Add(employee);
                    _dbContext.SaveChanges();
                    return "created";
                }
                return "null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DeleteEmployee(int id)
        {
            var entity = _dbContext.Employees.Where(x => x.Id == id).FirstOrDefault();
            if (entity != null)
            {
                _dbContext.Employees.Remove(entity);
                _dbContext.SaveChanges();
                return "deleted";
            }
            return "null";
        }

        public string EditEmployee(Employee employee)
        {
            try
            {
                var entity = _dbContext.Employees.Where(x => x.Id == employee.Id).FirstOrDefault();
                if (entity != null)
                {
                    entity.Name = employee.Name;
                    entity.Email = employee.Email;
                    entity.Phone = employee.Phone;
                    entity.IsManager = employee.IsManager;
                    entity.Manager = employee.Manager;
                    entity.DepartmentId = employee.DepartmentId;
                    entity.Salary = employee.Salary;

                    _dbContext.SaveChanges();
                    return "updated";
                }
                return "null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Employee GetEmployee(int id)
        {
            var entity = _dbContext.Employees.Find(id);

            if (entity == null)
            {
                entity = new Employee();
            }
            return entity;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            var entities = _dbContext.Employees.ToList();
            return entities;
        }

        public IEnumerable<Employee> GetManager()
        {
            var entities = _dbContext.Employees.Where(e => e.IsManager == true).ToList();
            return entities;
        }
    }
}
