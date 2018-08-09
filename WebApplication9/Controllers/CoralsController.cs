using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class CoralsController : Controller
    {
        private SiteDataContext db = new SiteDataContext();

        // GET: Corals
        public ActionResult Index()
        {
            return View(db.Corals.ToList());
        }

        // GET: Corals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coral coral = db.Corals.Find(id);
            if (coral == null)
            {
                return HttpNotFound();
            }
            return View(coral);
        }

        // GET: Corals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Corals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CoralId,Type,Light,Flow,Food,Name,ScientificName,Details,UploadedBy,Price,Size,FragSize,CommentId,Likes,DisLikes,Views,SoldOut,FragAvailable,FragAvailableFrom")] Coral coral)
        {
            if (ModelState.IsValid)
            {
                String ThisUserId = User.Identity.GetUserId();
                coral.UploadedBy = ThisUserId;
                 db.Corals.Add(coral);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coral);
        }

        // GET: Corals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coral coral = db.Corals.Find(id);
            if (coral == null)
            {
                return HttpNotFound();
            }
            return View(coral);
        }

        // POST: Corals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CoralId,Type,Light,Flow,Food,Name,ScientificName,Details,UploadedBy,Price,Size,FragSize,CommentId,Likes,DisLikes,Views,SoldOut,FragAvailable,FragAvailableFrom")] Coral coral)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coral).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coral);
        }

        // GET: Corals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coral coral = db.Corals.Find(id);
            if (coral == null)
            {
                return HttpNotFound();
            }
            return View(coral);
        }

        // POST: Corals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Coral coral = db.Corals.Find(id);
            db.Corals.Remove(coral);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
