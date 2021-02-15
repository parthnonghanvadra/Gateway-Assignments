using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PagedList;
using System.Web.Mvc;
using NLog;
using System.Net.Http;

namespace ProductManagement.Controllers
{
    public class ProductManagementController : Controller
    {
        public readonly Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        // GET: ProductManagement
        public ActionResult Index(string Sorting_Order, string Filter_Value, int? Page_No, string option, string search)
        {
            ViewBag.CurrentSortOrder = Sorting_Order;
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "SortedName_Des" : "";
            ViewBag.SortingCategoryName = (Sorting_Order == "SortedCategory_Asc" || String.IsNullOrEmpty(Sorting_Order)) ? "SortedCategoryName_Des" : "SortedCategory_Asc";
            if (search != null)
            {
                Page_No = 1;
            }
            else
            {
                search = Filter_Value;
            }

            ViewBag.FilterValue = search;

            ProductManagementDbContext db = new ProductManagementDbContext();
            var products = from product in db.Products.Include("Categories") select product;

            if (option == "Name")
            {
                //Index action method will return a view with a Products records based on what a user specify the value in textbox 
                products = products.Where(x => x.Name.ToUpper().Contains(search.ToUpper()) || search == null);

            }
            else if (option == "Category")
            {
                products = products.Where(x => x.Categories.CategoryName.ToUpper().Contains(search.ToUpper()) || search == null);

            }
            else if (option == "Price")
            {
                var searchedPrice = int.Parse(search);
                products = products.Where(x => x.Price == searchedPrice || search == null);
            }
            else
            {
                products = products.Where(x => x.Name.StartsWith(search) || search == null);

            }
            
            switch (Sorting_Order)
            {
                case "SortedName_Des":
                    products = products.OrderByDescending(product => product.Name);
                    break;

                case "SortedCategory_Asc":
                    products = products.OrderBy(product => product.Categories.CategoryName);
                    break;

                case "SortedCategoryName_Des":
                    products = products.OrderByDescending(product => product.Categories.CategoryName);
                    break;

                default:
                    products = products.OrderBy(product => product.Name);
                    break;
            }

            int Size_Of_Page = 4;
            int No_Of_Page = (Page_No ?? 1);
            return View(products.ToPagedList(No_Of_Page, Size_Of_Page));
        }


        // GET: ProductManagement/Details/5
        public ActionResult Details(int id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            //Calling WebAPI ProductManagementController GetProduct action method
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("ProductManagement/" + id.ToString()).Result;
            var product = response.Content.ReadAsAsync<Product>().Result;

            if(product == null)
            {
                Response.StatusCode = 404;
                return View("404", id);
            }

            return View(product);


        }

        [HttpPost]
        public ActionResult Addcategory(string categoryName)
        {
            using (ProductManagementDbContext db = new ProductManagementDbContext())
            {
                var categories = new Category()
                {
                    CategoryName = categoryName
                };
                db.Categories.Add(categories);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Add(string CategoryName)
        {
            using (ProductManagementDbContext db = new ProductManagementDbContext())
            {
                var category = new Category();
                category.CategoryName = CategoryName;
                db.Categories.Add(category);
                db.SaveChanges();
            }
            
            return View();
        }

        [Authorize]
        // GET: ProductManagement/Create
        [HttpGet]
        public ActionResult Create()
        {
            using (ProductManagementDbContext db = new ProductManagementDbContext())
            {
                var categoryList = db.Categories.ToList();
                ViewBag.CategoryList = new SelectList(categoryList, "Id", "CategoryName");
            }
            return View();
        }

        [Authorize]
        // POST: ProductManagement/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                // TODO: Added insert logic here
                int permittedSmallImageSizeInBytes = 5 * 1024 * 1024; //5 MB

                if (product.ImageFile.ContentLength > permittedSmallImageSizeInBytes)
                {
                    ModelState.AddModelError("SmallImage", "File cannot be more than 5MB");
                }
                else
                {
                    string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                    string extension = Path.GetExtension(product.ImageFile.FileName).ToLower();
                    if (extension.Equals(".jpg") || extension.Equals(".jpeg") || extension.Equals(".png"))
                    {
                        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        product.SmallImage = "~/Image/" + fileName;
                        fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                        product.ImageFile.SaveAs(fileName);
                    }
                    else
                    {
                        ModelState.AddModelError("SmallImage", "Only upload jpg, jpeg or png files");
                    }

                }


                if (product.LargeImageFile != null)
                {
                    string largeFileName = Path.GetFileNameWithoutExtension(product.LargeImageFile.FileName);
                    string largeFileExtension = Path.GetExtension(product.LargeImageFile.FileName);
                    if (largeFileExtension.Equals(".jpg") || largeFileExtension.Equals(".jpeg") || largeFileExtension.Equals(".png"))
                    {
                        largeFileName = largeFileName + DateTime.Now.ToString("yymmssfff") + largeFileExtension;
                        product.LargeImage = "~/Image/" + largeFileName;
                        largeFileName = Path.Combine(Server.MapPath("~/Image/"), largeFileName);
                        product.LargeImageFile.SaveAs(largeFileName);
                    }
                    else
                    {
                        ModelState.AddModelError("LargeImage", "Only upload jpg, jpeg or png files");
                    }

                }
                using (ProductManagementDbContext db = new ProductManagementDbContext())
                {

                    var categoryList = db.Categories.ToList();
                    ViewBag.CategoryList = new SelectList(categoryList, "Id", "CategoryName");
                    
                }

                //Create Temp Product
                Product tempProduct = new Product();
                tempProduct.Name = product.Name;
                tempProduct.CategoryId = product.CategoryId;
                tempProduct.Price = product.Price;
                tempProduct.Quantity = product.Quantity;
                tempProduct.ShortDescription = product.ShortDescription;
                tempProduct.LongDescription = product.LongDescription;
                tempProduct.SmallImage = product.SmallImage;
                tempProduct.LargeImage = product.LargeImage;

                //Calling WebAPI ProductManagementController PostProduct action method
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("ProductManagement", tempProduct).Result; 

                Logger.Info("Product created with ID: " + product.ProductId + " and Product Name: " + product.Name);
                TempData["CreateSuccess"] = product.Name;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error occured Error occured while creating Products");
                TempData["CreateError"] = true;
                return RedirectToAction("Index");
            }
        }

        // GET: ProductManagement/Edit/5
        public ActionResult Edit(int id)
        {
            using (ProductManagementDbContext db = new ProductManagementDbContext())
            {
                var product = db.Products.Include("Categories").Where(x => x.ProductId == id).FirstOrDefault();
                if (product == null)
                {
                    Response.StatusCode = 404;
                    Logger.Info("404! Product Not Found of product ID : " + id);
                    return View("404", id);
                }
                var categoryList = db.Categories.ToList();
                ViewBag.CategoryList = new SelectList(categoryList, "Id", "CategoryName");

                return View(product);
            }


        }

        // POST: ProductManagement/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                // TODO: Added update logic here
                ProductManagementDbContext db = new ProductManagementDbContext();
                
                var products = db.Products.Include("Categories").Single(m => m.ProductId == id);
                if (TryUpdateModel(products))

                {

                    products.Name = product.Name;
                    products.CategoryId = product.CategoryId;
                    products.Quantity = product.Quantity;
                    products.Price = product.Price;
                    products.ShortDescription = product.ShortDescription;
                    products.LongDescription = product.LongDescription;

                    if (product.ImageFile != null && product.LargeImageFile != null)
                    {
                        int permittedSmallImageSizeInBytes = 5 * 1024 * 1024; //5 MB

                        if (product.ImageFile.ContentLength > permittedSmallImageSizeInBytes)
                        {
                            ModelState.AddModelError("SmallImage", "File cannot be more than 5MB");
                        }
                        else
                        {
                            string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                            string extension = Path.GetExtension(product.ImageFile.FileName);
                            if (extension.Equals(".jpg") || extension.Equals(".jpeg") || extension.Equals(".png"))
                            {
                                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                                product.SmallImage = "~/Image/" + fileName;
                                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                                product.ImageFile.SaveAs(fileName);
                                products.ImageFile = product.ImageFile;
                                products.SmallImage = product.SmallImage;
                            }
                            else
                            {
                                ModelState.AddModelError("SmallImage", "Only upload jpg, jpeg or png files");
                            }
                        }

                        string largeFileName = Path.GetFileNameWithoutExtension(product.LargeImageFile.FileName);
                        string largeFileExtension = Path.GetExtension(product.LargeImageFile.FileName);
                        if (largeFileExtension.Equals(".jpg") || largeFileExtension.Equals(".jpeg") || largeFileExtension.Equals(".png"))
                        {
                            largeFileName = largeFileName + DateTime.Now.ToString("yymmssfff") + largeFileExtension;
                            product.LargeImage = "~/Image/" + largeFileName;
                            largeFileName = Path.Combine(Server.MapPath("~/Image/"), largeFileName);
                            product.LargeImageFile.SaveAs(largeFileName);
                            products.LargeImageFile = product.LargeImageFile;
                            products.LargeImage = product.LargeImage;
                        }
                        else
                        {
                            ModelState.AddModelError("LargeImage", "Only upload jpg, jpeg or png files");
                        }

                    }
                    else if (product.ImageFile != null && product.LargeImageFile == null)
                    {
                        int permittedSmallImageSizeInBytes = 5 * 1024 * 1024; //5 MB

                        if (product.ImageFile.ContentLength > permittedSmallImageSizeInBytes)
                        {
                            ModelState.AddModelError("SmallImage", "File cannot be more than 5MB");
                        }
                        else
                        {
                            string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                            string extension = Path.GetExtension(product.ImageFile.FileName);
                            if (extension.Equals(".jpg") || extension.Equals(".jpeg") || extension.Equals(".png"))
                            {
                                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                                product.SmallImage = "~/Image/" + fileName;
                                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                                product.ImageFile.SaveAs(fileName);
                                products.ImageFile = product.ImageFile;
                                products.SmallImage = product.SmallImage;
                            }
                            else
                            {
                                ModelState.AddModelError("SmallImage", "Only upload jpg, jpeg or png files");
                            }
                        }
                    }
                    else if (product.ImageFile == null && product.LargeImageFile != null)
                    {
                        string largeFileName = Path.GetFileNameWithoutExtension(product.LargeImageFile.FileName);
                        string largeFileExtension = Path.GetExtension(product.LargeImageFile.FileName);
                        if (largeFileExtension.Equals(".jpg") || largeFileExtension.Equals(".jpeg") || largeFileExtension.Equals(".png"))
                        {
                            largeFileName = largeFileName + DateTime.Now.ToString("yymmssfff") + largeFileExtension;
                            product.LargeImage = "~/Image/" + largeFileName;
                            largeFileName = Path.Combine(Server.MapPath("~/Image/"), largeFileName);
                            product.LargeImageFile.SaveAs(largeFileName);
                            products.LargeImageFile = product.LargeImageFile;
                            products.LargeImage = product.LargeImage;
                        }
                        else
                        {
                            ModelState.AddModelError("LargeImage", "Only upload jpg, jpeg or png files");
                        }
                    }

                    //Create Temp Product
                    Product tempProduct = new Product();
                    tempProduct.Name = product.Name;
                    tempProduct.CategoryId = product.CategoryId;
                    tempProduct.Price = product.Price;
                    tempProduct.Quantity = product.Quantity;
                    tempProduct.ShortDescription = product.ShortDescription;
                    tempProduct.LongDescription = product.LongDescription;
                    tempProduct.SmallImage = product.SmallImage;
                    tempProduct.LargeImage = product.LargeImage;

                    //Calling WebAPI ProductManagementController PutProduct action method
                    HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("ProductManagement/" + product.ProductId, tempProduct).Result;
                    Logger.Info("Product  updated with ID: " + product.ProductId + " and Product Name: " + product.Name);
                    TempData["UpdateSuccess"] = products.Name;
                    return RedirectToAction("Index");
                }
                return View(products);
            }
            catch(Exception ex)
            {
                Logger.Error(ex, "Error occured while updating Products");
                TempData["UpdateError"] = true;
                return RedirectToAction("Index");
            }
        }

        // GET: ProductManagement/Delete/5
        public ActionResult Delete(int id)
        {
            using (ProductManagementDbContext db = new ProductManagementDbContext())
            {
                var product = db.Products.Include("Categories").Where(x => x.ProductId == id).FirstOrDefault();
                if (product == null)
                {
                    Response.StatusCode = 404;
                    Logger.Info("404! Product Not Found of product ID : " + id);
                    return View("404", id);
                }
                
                return View(product);
            }
            
        }

        // POST: ProductManagement/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Product product)
        {
            try
            {
                // TODO: Added delete logic here
                
                using (ProductManagementDbContext db = new ProductManagementDbContext())
                {
                    product = db.Products.Find(id);

                    //Calling WebAPI ProductManagementController DeleteProduct action method
                    HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("ProductManagement/" + id.ToString()).Result;
                    
                    TempData["DeleteSuccess"] = product.Name;
                }
                Logger.Info("Product Deleted with ID: " + product.ProductId + " and Product Name: " + product.Name);
                return RedirectToAction("Index");

            }
            catch(Exception ex)
            {
                Logger.Error(ex, "Error occured while deleting Products");
                TempData["DeleteError"] = true;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult DeleteMultipleItems(string[] ids)
        {
            try
            {
                // TODO: Add delete logic here
                
                List<int> Ids = ids.Select(x => Int32.Parse(x)).ToList();
                for (var i = 0; i < Ids.Count(); i++)
                {
                    using (ProductManagementDbContext db = new ProductManagementDbContext())
                    {
                        var product = db.Products.Find(Ids[i]);

                        //Calling WebAPI ProductManagementController DeleteProduct action method
                        HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("ProductManagement/" + Ids[i].ToString()).Result;
                        
                    }
                }
                Logger.Info("Multiple Products Deleted");

                TempData["DeleteMultipleSuccess"] = true;
                return RedirectToAction("Index");

            }
            catch(Exception ex)
            {
                Logger.Error(ex, "Error occured while deleting Multiple Products");
                TempData["DeleteSuccess"] = true;
                return RedirectToAction("Index");
            }
        }
        public ActionResult List()
        {
            ProductManagementDbContext db = new ProductManagementDbContext();
            var products = from product in db.Products.Include("Categories") select product;
            return View(products.ToList());
        }
    }
}
