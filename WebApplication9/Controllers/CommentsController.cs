using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication9.Models;

namespace WebApplication9.Controllers
    {
    public class CommentsController : Controller
        {
        private SiteDataContext db = new SiteDataContext();

        // GET: Comments
        public ActionResult Index() {
            var user = User.Identity.GetUserName();
            var list = db.Comments.Where(x => x.UserId == user).ToList();
           

            foreach(var item in list) {
                // assign to aspNetUser from FeedbackFromUserId for easy access to image
                // item.UploadedBy = db.AspNetUser.Find(item.);

                try 
                    {
                    item.UserPhoto = db.CoralPhoto.Where(x => x.CoralId.ToString() == item.CommentOn).First().Photo;

                    }

                catch(Exception e) {
                    Console.Write(e);

                    }

                //change commentOn to coral name

             var item2 = db.Corals.Where(x => x.CoralId.ToString() == item.CommentOn).First();
                item.CommentOn = item2.Name;
                item.UserId = item2.UploadedBy;
                }
            return View(list);

            }

        // GET: Comments/Details/5
        public ActionResult Details(int? id) {
            if(id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            Comments comments = db.Comments.Find(id);
            if(comments == null) {
                return HttpNotFound();
                }
            return View(comments);
            }

        // GET: Comments/Create
        public ActionResult Create() {
            return View();
            }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserPhoto,CommentId,Type,UserId,CreatedOn,RemovedOn,CommentOn,CommentTitle,CommentText,CommentViews,Removed,Reports,Likes,DisLikes")] Comments comments) {
            if(ModelState.IsValid) {
                comments.UserId = User.Identity.GetUserId();
                comments.CommentTitle = User.Identity.GetUserName();
                comments.CreatedOn = DateTime.Now.ToShortDateString();
                comments.UploadedBy = User.Identity.GetUserName();
                db.Comments.Add(comments);
                db.SaveChanges();
                return RedirectToAction("Index");
                }

            return View(comments);
            }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> _CreateCommentPartial([Bind(Include = "UserPhoto,CommentId,Type,UserId,CreatedOn,RemovedOn,CommentOn,CommentTitle,CommentText,CommentViews,Removed,Reports,Likes,DisLikes")] Comments comments) {
            if(ModelState.IsValid) {
                comments.UserId = User.Identity.GetUserId();

                comments.CommentTitle = User.Identity.GetUserName();
                comments.CreatedOn = DateTime.Now.ToShortDateString();
                db.Comments.Add(comments);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
                }

            return PartialView();
            }

        // GET: Comments/Edit/5
        public ActionResult Edit(int id) {
            if(id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            Comments comments = db.Comments.Find(id);
            if(comments == null) {
                return HttpNotFound();
                }
            return View(comments);
            }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentId,Type,UserId,CreatedOn,RemovedOn,CommentOn,CommentTitle,CommentText,CommentViews,Removed,Reports,Likes,DisLikes")] Comments comments) {
            if(ModelState.IsValid) {
                db.Entry(comments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
                }
            return View(comments);
            }

        // GET: Comments/Delete/5
        public ActionResult Delete(int id) {
            if(id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            Comments comments = db.Comments.Find(id);
            if(comments == null) {
                return HttpNotFound();
                }
            return View(comments);
            }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Comments comments = db.Comments.Find(id);
            comments.Removed = true;
            comments.RemovedOn = DateTime.Now.ToShortDateString();
            db.SaveChanges();

            return RedirectToAction("Index");
            }

        protected override void Dispose(bool disposing) {
            if(disposing) {
                db.Dispose();
                }
            base.Dispose(disposing);
            }


        public ActionResult Report(int id) {
            Comments comments = db.Comments.Find(id);
            comments.Reports++;
            db.Entry(comments).State = EntityState.Modified;

            db.SaveChanges();
            return RedirectToAction("Index");

            }

        public ActionResult Reply(int id) {
            throw new NotImplementedException();
            }
        public ActionResult ActionMethod(int value) {
            //process value
            throw new NotImplementedException();

            }
        }
    }
