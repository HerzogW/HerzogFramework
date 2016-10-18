using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Herzog.Web.Areas.Authorization.Controllers
{
    public class PermissionController : Controller
    {
        // GET: Authorization/Permission
        public ActionResult Index()
        {
            return View();
        }

        // GET: Authorization/Permission/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Authorization/Permission/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authorization/Permission/Create
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

        // GET: Authorization/Permission/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Authorization/Permission/Edit/5
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

        // GET: Authorization/Permission/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Authorization/Permission/Delete/5
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
