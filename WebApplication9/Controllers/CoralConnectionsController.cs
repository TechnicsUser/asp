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
    public class CoralConnectionsController : Controller
        {
        private SiteDataContext db = new SiteDataContext();

        // GET: CoralConnections
        public ActionResult Index() {
            return View(db.CoralConnections.ToList());
            }

        // GET: CoralConnections/Details/5
        public ActionResult Details(int? id) {
            if(id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            CoralConnection coralConnection = db.CoralConnections.Find(id);
            if(coralConnection == null) {
                return HttpNotFound();
                }
            return View(coralConnection);
            }

        // GET: CoralConnections/Create
        public ActionResult Create() {
            return View();
            }

        // POST: CoralConnections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConnectionId,CoralId,UserId,CreatedOn,RemovedOn,FragTo,FragFrom,ColonyTo,ColonyFrom")] CoralConnection coralConnection) {
            if(ModelState.IsValid) {
                coralConnection.UserId = User.Identity.GetUserId();
                coralConnection.CreatedOn = DateTime.Now.ToShortDateString();
                db.CoralConnections.Add(coralConnection);
                db.SaveChanges();
                return RedirectToAction("Index");
                }

            return View(coralConnection);
            }

        // GET: CoralConnections/Edit/5
        public ActionResult Edit(int? id) {
            if(id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            CoralConnection coralConnection = db.CoralConnections.Find(id);
            if(coralConnection == null) {
                return HttpNotFound();
                }
            return View(coralConnection);
            }

        // POST: CoralConnections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConnectionId,CoralId,UserId,CreatedOn,RemovedOn,FragTo,FragFrom,ColonyTo,ColonyFrom")] CoralConnection coralConnection) {
            if(ModelState.IsValid) {
                db.Entry(coralConnection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
                }
            return View(coralConnection);
            }

        // GET: CoralConnections/Delete/5
        public ActionResult Delete(int? id) {
            if(id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            CoralConnection coralConnection = db.CoralConnections.Find(id);
            if(coralConnection == null) {
                return HttpNotFound();
                }
            return View(coralConnection);
            }

        // POST: CoralConnections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            CoralConnection coralConnection = db.CoralConnections.Find(id);
            coralConnection.Removed = true;
            coralConnection.RemovedOn = DateTime.Now.ToShortDateString();
            db.SaveChanges();

            return RedirectToAction("Index");
            }

        protected override void Dispose(bool disposing) {
            if(disposing) {
                db.Dispose();
                }
            base.Dispose(disposing);
            }
        }
    }
