using HRM.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRM.DAL.Interfaces
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetDepartments();
        Department GetDepartment(int id);
        string AddDepartment(Department department);
        string EditDepartment(Department department);
        string DeleteDepartment(int id);

    }
}
