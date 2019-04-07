using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication9.Models;
using Microsoft.AspNet.Identity;

namespace WebApplication9.Views.Notifications
{
    public class NotificationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Notifications
        public async Task<ActionResult> Index()
        {

            if(User.Identity.IsAuthenticated) {


                var id = User.Identity.GetUserId();
                List<Notification> ml = await db.Notifications.Where(x => x.UserId == id).Where(x => x.IsDismissed == false).ToListAsync();

                return View(ml);
                }
            return RedirectToAction("Login", "Account");


        }

        // GET: Notifications/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notification notification = await db.Notifications.FindAsync(id);
            if (notification == null)
            {
                return HttpNotFound();
            }
            return View(notification);
        }

        // GET: Notifications/Create
        public ActionResult Create()
        {
            if(User.Identity.IsAuthenticated) {


                return View();
                }
            return RedirectToAction("Login", "Account");


         
        }

        // POST: Notifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "NotificationId,Title,NotificationType,Controller,Action,UserId,IsDismissed")] Notification notification)
        {
            if (ModelState.IsValid)
            {
                db.Notifications.Add(notification);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(notification);
        }



        // GET: Notifications/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notification notification = await db.Notifications.FindAsync(id);
            if (notification == null)
            {
                return HttpNotFound();
            }
            if(notification.UserId == User.Identity.GetUserId()) {
                return View(notification);
                }
            return RedirectToAction("Login", "Account");
            }

        // POST: Notifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Notification notification = await db.Notifications.FindAsync(id);

            if(notification.UserId == User.Identity.GetUserId()) notification.IsDismissed = true;
            await db.SaveChangesAsync();
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
