using Herzog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Herzog.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginViewModel model,string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {

            }
            catch (Exception e)
            {
                return View(model);
            }

            return View();
        }

    }
}