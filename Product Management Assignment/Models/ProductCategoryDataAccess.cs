using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductManagement.Models
{
    public class ProductCategoryDataAccess
    {
        private ProductManagementDbContext _productDbContext = new ProductManagementDbContext();

        public IEnumerable<Category> GetAllProductCategories()
        {
            IEnumerable<Category> categories;
            categories = _productDbContext.Categories.ToList();
            return categories;
        }

        public Category GetProductCategoryById(int id)
        {
            Category category;
            category = _productDbContext.Categories.Find(id);
            return category;
        }

        public void AddProductCategory(Category category)
        {
            //var category = new Category();
            //category.CategoryName = AddProductCategory;
            _productDbContext.Categories.Add(category);
        }

        public void UpdateProductCategory(Category category)
        {
            _productDbContext.Categories.Add(category);
            _productDbContext.Entry(category).State = (EntityState)System.Data.Entity.EntityState.Modified;
        }
        public void DeleteProductCategory(Category category)
        {
            _productDbContext.Categories.Remove(category);
        }
        public void Save()
        {
            _productDbContext.SaveChanges();
        }
    }
}