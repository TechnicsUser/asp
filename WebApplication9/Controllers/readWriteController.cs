using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class readWriteController : Controller
    {

        public ActionResult Index() {
            userEntities1 db = new userEntities1();

            var u = from m in db.AspNetUser
                         where m.LocationLat != null
                         select m;

            return View(u.ToList());

            }

        // GET: readWrite/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: readWrite/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: readWrite/Create
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

        // GET: readWrite/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: readWrite/Edit/5
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

        // GET: readWrite/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: readWrite/Delete/5
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
