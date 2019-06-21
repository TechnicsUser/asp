using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class FeedbacksController : Controller
    {
        private SiteDataContext db = new SiteDataContext();

        // GET: Feedbacks
        public ActionResult Index()
        {
            var user = User.Identity.GetUserId();
            var list = db.Feedbacks.Where(x => x.FeedbackForUserId == user).ToList();
            foreach (var item in list)
            {
                // assign to aspNetUser from FeedbackFromUserId for easy access to image
                item.FeedbackFrom = db.AspNetUser.Find(item.FeedbackFromUserId);

            }
            return View(list);
        }
        // GET: Feedbacks
        public ActionResult IndexPartial()
        {
            var user = User.Identity.GetUserId();
            var list = db.Feedbacks.Where(x => x.FeedbackForUserId == user).ToList();
            foreach (var item in list)
            {
                item.FeedbackFrom = db.AspNetUser.Find(item.FeedbackFromUserId);

            }
            return View(list);
        }
        // GET: Feedbacks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            feedback.FeedbackFrom = db.AspNetUser.Find(feedback.FeedbackFromUserId);
               
            return View(feedback);
        }

        // GET: Feedbacks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Feedbacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FeedbackId,FeedbackType,Content,IsReply,FeedbackForUserId,IsDismissed,SenderDeleted,RecieverDeleted,IsReported,DismissedOn,SenderDeletedOn,RecieverDeletedOn")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                feedback.FeedbackFromUserId = User.Identity.GetUserId();
                feedback.CreatedOn = DateTime.Now.Date;
                feedback.IsReported = false;
                feedback.RecieverDeleted = false;
                feedback.SenderDeleted = false;

                db.Feedbacks.Add(feedback);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(feedback);
        }

        // GET: Feedbacks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // POST: Feedbacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FeedbackId,FeedbackType,Content,IsReply,FeedbackFromUserId,IsDismissed,SenderDeleted,RecieverDeleted,IsReported,CreatedOn,DismissedOn,SenderDeletedOn,RecieverDeletedOn")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(feedback);
        }

        // GET: Feedbacks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // POST: Feedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Feedback feedback = db.Feedbacks.Find(id);
            db.Feedbacks.Remove(feedback);
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
