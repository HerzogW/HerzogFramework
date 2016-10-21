using Herzog.Business.Authorization;
using Herzog.Model.Authorization;
using Herzog.Web.Areas.Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Herzog.Web.Areas.Auth.Controllers
{
    public class PermissionController : Controller
    {
        PermissionBLL bll = new PermissionBLL();

        // GET: Auth/Permission
        public ActionResult Index()
        {
            var list = bll.GetAllPermissions();
            return View(list);
        }

        // GET: Auth/Permission/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auth/Permission/Create
        [HttpPost]
        public ActionResult Create(PermissionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var p = new PermissionModel();
            p.Id = Guid.NewGuid().ToString();
            p.PermissionCode = model.PermissionCode;
            p.PermissionDescription = model.PermissionDescription;

            var result = bll.InsertPermission(p);
            if (!result)
            {
                return View(model);
            }

            return RedirectToAction("Index");
        }

        // GET: Auth/Permission/Edit/5
        public ActionResult Edit(string id)
        {
            PermissionModel p = bll.GetPermission(id);
            PermissionViewModel model = new PermissionViewModel();
            model.Id = p.Id;
            model.PermissionCode = p.PermissionCode;
            model.PermissionDescription = p.PermissionDescription;

            return View(model);
        }

        // POST: Auth/Permission/Edit/5
        [HttpPost]
        public ActionResult Edit(PermissionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var p = new PermissionModel();
            p.Id = model.Id;
            p.PermissionCode = model.PermissionCode;
            p.PermissionDescription = model.PermissionDescription;

            var result = bll.UpdatePermission(p);
            if (!result)
            {
                return View(model);
            }

            return RedirectToAction("Index");
        }

        // GET: Auth/Permission/Delete/5
        public ActionResult Delete(string[] ids)
        {
            if (ids == null || ids.Length == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            bll.DeletePermissions(ids);

            return RedirectToAction("Index");
        }       
    }
}
