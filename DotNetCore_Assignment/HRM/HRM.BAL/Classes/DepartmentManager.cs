using HRM.BAL.Interfaces;
using HRM.BusinessEntities;
using HRM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRM.BAL.Classes
{
    public class DepartmentManager : IDepartmentManager
    {
        IDepartmentRepository _departmentRepository;
        public DepartmentManager(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public string AddDepartment(Department department)
        {
            return _departmentRepository.AddDepartment(department);
        }

        public string DeleteDepartment(int id)
        {
            return _departmentRepository.DeleteDepartment(id);
        }

        public string EditDepartment(Department department)
        {
            return _departmentRepository.EditDepartment(department);
        }

        public Department GetDepartment(int id)
        {
            return _departmentRepository.GetDepartment(id);
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _departmentRepository.GetDepartments();
        }
    }
}
