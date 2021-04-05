using HRM.BusinessEntities;
using HRM.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRM.DAL.Classes
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DepartmentRepository(ApplicationDbContext db)
        {
            _dbContext = db;
        }

        /// <summary>
        /// Add Department
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>created message if it is created.</returns>
        public string AddDepartment(Department department)
        {
            try
            {
                if (department != null)
                {
                    var res = _dbContext.Departments.Where(x => x.Name == department.Name).FirstOrDefault();
                    if (res != null)
                    {
                        return "already";
                    }
                    _dbContext.Departments.Add(department);
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

        /// <summary>
        ///  Delete Department 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>deleted string if Department is deleted</returns>
        public string DeleteDepartment(int id)
        {
            var entity = _dbContext.Departments.Where(x => x.Id == id).FirstOrDefault();
            if (entity != null)
            {
                _dbContext.Departments.Remove(entity);
                _dbContext.SaveChanges();
                return "deleted";
            }
            return "null";
        }

        /// <summary>
        /// Edit Department
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>updated string if Department is updated</returns>
        public string EditDepartment(Department department)
        {
            try
            {
                var entity = _dbContext.Departments.Where(x => x.Id == department.Id).FirstOrDefault();
                if (entity != null)
                {
                    entity.Name = department.Name;

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

        /// <summary>
        /// Get department by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Department Object</returns>
        public Department GetDepartment(int id)
        {
            var entity = _dbContext.Departments.Find(id);

            if (entity == null)
            {
                entity = new Department();
            }
            return entity;
        }

        /// <summary>
        /// Get all Department
        /// </summary>
        /// <returns>List of all Departments</returns>
        public IEnumerable<Department> GetDepartments()
        {
            var entities = _dbContext.Departments.ToList();
            return entities;
        }
    }
}
