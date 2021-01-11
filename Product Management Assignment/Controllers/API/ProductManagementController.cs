using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ProductManagement.Models;

namespace ProductManagement.Controllers.API
{
    public class ProductManagementController : ApiController
    {
        private ProductManagementDbContext _context = new ProductManagementDbContext();

        // GET: api/ProductManagement
        public IEnumerable<Product> GetProducts()
        {
            IEnumerable<Product> products = _context.Products.Include("Categories").ToList();
            return products;
        }

        // GET: api/ProductManagement/5
        [HttpGet]
        public Product GetProduct(int id)
        {
            var product = _context.Products.Include("Categories").Where(x => x.ProductId == id).FirstOrDefault();

            return product;
        }

        // PUT: api/ProductManagement/5
        [HttpPut]
        public string PutProduct(int id, Product product)
        {

            Product productInDb = _context.Products.Include("Categories").Single(m => m.ProductId == id);

            productInDb.Name = product.Name;
            productInDb.CategoryId = product.CategoryId;
            productInDb.Price = product.Price;
            productInDb.Quantity = product.Quantity;
            productInDb.ShortDescription = product.ShortDescription;
            productInDb.LongDescription = product.LongDescription;
            productInDb.SmallImage = product.SmallImage;
            productInDb.LargeImage = product.LargeImage;

            _context.SaveChanges();

            return "Product Updated";
        }

        // POST: api/ProductManagement
        [HttpPost]
        public string PostProduct(Product product)
        {
            
            _context.Products.Add(product);
            _context.SaveChanges();

            return "Product Added success";
        }

        // DELETE: api/ProductManagement/5
        [HttpDelete]
        public string DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);

            _context.Products.Remove(product);
            _context.SaveChanges();

            return "Product Deleted";
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}