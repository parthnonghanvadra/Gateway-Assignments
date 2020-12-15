using Microsoft.AspNet.Identity;
using NLog;
using Source_Control_Final_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Source_Control_Final_Assignment.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public readonly Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        [Authorize]
        public ActionResult Index()
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            string email = User.Identity.GetUserName();
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Login", "Account");
            }
            try { 
                var applicationUser = dbContext.Users.Where(x => x.Email.Equals(email)).FirstOrDefault();
                ViewBag.User = applicationUser;

            }
            catch(Exception ex){
                Logger.Error("Error occured." + ex.Message);
                return RedirectToAction("BadRequest", "Error");
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}