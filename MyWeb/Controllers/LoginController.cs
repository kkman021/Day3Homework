using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWeb.Models;

namespace MyWeb.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginVM model)
        {
            if (model.Account == "ming" && model.Pwd == "1234")
                return RedirectToAction("Index", "Welcome");
            else
            {
                ModelState.AddModelError("", "ming is a good man");
            }

            return View();
        }
    }
}
