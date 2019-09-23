using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebApplication9.Models;

namespace WebApplication9.Controllers
    {
    public class MessagesController : Controller
        {
        private SiteDataContext db = new SiteDataContext();

        // GET: Messages
        public async Task<ActionResult> Index() {
            if(User.Identity.IsAuthenticated) {

                var id = User.Identity.GetUserName();
                List<Messages> ml = await db.Messages.Where(x => x.MessageTo == id).Where(x => x.RecieverDeleted == false).ToListAsync();

                return View(ml);
                }
            return RedirectToAction("Login", "Account");


            }
        public async Task<ActionResult> Sent() {
            if(User.Identity.IsAuthenticated) {

                var id = User.Identity.Name;
                List<Messages> ml = await db.Messages.Where(x => x.MessageFrom == id).Where(x => x.SenderDeleted == false).ToListAsync();

                return View(ml);
                }
            return RedirectToAction("Login", "Account");


            }

        // GET: Messages/Details/5
        public ActionResult Details(int? id) {
            if(id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            Messages messages = db.Messages.Find(id);
            if(messages == null) {
                return HttpNotFound();
                }
            if(messages.MessageTo == User.Identity.Name | messages.MessageFrom == User.Identity.Name) {
                if(messages.MessageTo == User.Identity.Name && messages.IsDismissed == false) {
                    messages.IsDismissed = true;
                    messages.DismissedOn = DateTime.Now;
                    db.SaveChanges();
                    }



                List<Messages> ml = db.Messages.Where(x => x.MessageId == id | x.PreviousMessage == id.ToString()).ToList();

                return View(ml);
                }
            return HttpNotFound();


            }

        // GET: Messages/Create
        public ActionResult Create() {
            if(User.Identity.IsAuthenticated) {

                return View();
                }
            return RedirectToAction("Login", "Account");

            }

        // POST: Messages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MessageId,Title,MessageType,MessageTo,IsDismissed, Content, Subject")] Messages messages) {
            if(User.Identity.IsAuthenticated) {

                if(ModelState.IsValid) {
                    messages.UserId = User.Identity.GetUserId();
                    messages.MessageFrom = User.Identity.Name;
                    messages.CreatedOn = DateTime.Now;
                    messages.MessageType = MessageType.Email;
                    db.Messages.Add(messages);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                    }
                }


            return MessagesReplyViewModel();
            }




        // GET: Messages/Create
        public ActionResult MessagesReplyViewModel() {
            if(User.Identity.IsAuthenticated) {
                MessagesReplyViewModel mc = new MessagesReplyViewModel();



                return View(mc);
                }
            return RedirectToAction("Login", "Account");

            }






        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MessagesReplyViewModel([Bind(Include = "MessageId,Title,MessageType,MessageTo,IsDismissed, Content, Subject,PreviousMessage")] Messages messages) {
            if(User.Identity.IsAuthenticated) {

                if(ModelState.IsValid) {
                    messages.UserId = User.Identity.GetUserId();
                    messages.MessageFrom = User.Identity.Name;
                    messages.CreatedOn = DateTime.Now;
                    messages.MessageType = MessageType.Email;
                    //   messages.PreviousMessage = messages.PreviousMessage + ":"; 
                    messages.IsReply = true;
                    db.Messages.Add(messages);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                    }
                }


            return View();
            }




        [Authorize]
        // GET: Messages/Create
        public ActionResult MessagesCreateViewModel(string user) {
            MessagesCreateViewModel mc = new MessagesCreateViewModel();
            if(user != null) {
                mc.Users = db.AspNetUser.Where(x => x.IdUserName.Equals(user)).ToList();

                }
            else {

               mc.Users = db.AspNetUser.Where(x => x.Id != null).ToList();
                AspNetUser aspNetUser = db.AspNetUser.Where(x => x.IdUserName == User.Identity.Name).First();

                mc.Users.Remove(aspNetUser);
                }


                return View(mc);
       //         }
       //     return RedirectToAction("Login", "Account");

            }
 
        // POST: Messages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MessagesCreateViewModel(Messages messages) {
            if(User.Identity.IsAuthenticated) {

                if(ModelState.IsValid) {
                    messages.UserId = messages.MessageTo;
                    messages.MessageFrom = User.Identity.Name;
                    messages.CreatedOn = DateTime.Now;
                    messages.MessageType = MessageType.Email;

                    db.Messages.Add(messages);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                    }
                }


            return View(messages);
            }


        // GET: Messages/Delete/5
        public ActionResult Delete(int? id) {
            if(id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            Messages messages = db.Messages.Find(id);
            if(messages == null) {
                return HttpNotFound();
                }
            return View(messages);
            }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Messages messages = db.Messages.Find(id);

            if(messages.MessageTo == User.Identity.Name) {
                messages.RecieverDeleted = true;
                messages.RecieverDeletedOn = DateTime.Now;

                }
            //if (messages.MessageTo == User.Identity.Name)
            else {
                messages.SenderDeleted = true;
                messages.SenderDeletedOn = DateTime.Now;

                }
            db.SaveChanges();
            return RedirectToAction("Index");
            }

        protected override void Dispose(bool disposing) {
            if(disposing) {
                db.Dispose();
                }
            base.Dispose(disposing);
            }
        private IEnumerable<SelectListItem> GetRoles() {
            var users = db.AspNetUser
                        .Select(x =>
                                new SelectListItem {
                                    Value = x.IdUserName.ToString(),
                                    Text = x.IdUserName
                                    });

            return new SelectList(users, "Value", "Text");
            }
        }
    }
