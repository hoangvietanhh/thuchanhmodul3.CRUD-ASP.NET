using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace thuchanhmodul3.Controllers
{
    public class UserController : Controller
    {

        public ActionResult Logout()
        {
            return View();
        }

        // GET: User
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            if (userName == "admin" && password == "123456")
            {
                Session["USER"] = userName;
                return RedirectToAction("List", "Product");
            }
            return View();
        }
    }
}