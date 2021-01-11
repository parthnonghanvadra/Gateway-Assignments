using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductManagement.Models;

namespace ProductManagement.Controllers
{
    public class ProductCategoryController : Controller
    {
        ProductCategoryDataAccess categoryDataAccess = new ProductCategoryDataAccess();

        // GET: ProductCategory
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Category category)
        {
            try
            {
                categoryDataAccess.AddProductCategory(category);
                categoryDataAccess.Save();
                return RedirectToAction("Index", "ProductManagement");
            }
            catch
            {
                return View();
            }

        }
    }
}