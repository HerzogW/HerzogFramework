using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Herzog.Web.Areas.Auth.Controllers
{
    public class RoleController : Controller
    {
        // GET: Auth/Role
        public ActionResult Index()
        {


            return View();
        }

        // GET: Auth/Role/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Auth/Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auth/Role/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Auth/Role/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Auth/Role/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Auth/Role/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Auth/Role/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
