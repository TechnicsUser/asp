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

namespace WebApplication9.Controllers
{
    public class AspNetUsersController : Controller
    {
      //  private userEntities1 db = new userEntities1();
        private ApplicationDbContext db2 = new ApplicationDbContext();

        private SiteDataContext db3 = new SiteDataContext();
 

        // GET: AspNetUsers
        public async Task<ActionResult> Index()
        {
             return View(await db3.AspNetUser.ToListAsync());
            
        }


        // GET: AspNetUsers
        [Authorize]

        public async Task<ActionResult> ViewUser([Bind(Include = "Id")]string id) {

         AspNetUser aspNetUser = await db3.AspNetUser.FindAsync(id);

         ApplicationUser temp = db2.Users.Where(x => x.Id == id).First();

            List<Fish> fl = db3.Fish.Where(x => x.UploadedBy == temp.UserName).ToList();
             List<Coral> cl = db3.Corals.Where(x => x.UploadedBy == temp.UserName).ToList();
          


            return View(aspNetUser);
            }
        // GET: AspNetUsers
        [Authorize]
        public async Task<ActionResult> UserViewViewModel([Bind(Include = "Id")]string id)
        {
            AspNetUser aspNetUser =   db3.AspNetUser.Where(x => x.IdUserName == id).First();
             ApplicationUser temp = db2.Users.Where(x => x.IdUserName == id).First();
            List<Fish> fl = db3.Fish.Where(x => x.UploadedBy == temp.UserName).ToList();
             List<Coral> cl = db3.Corals.Where(x => x.UploadedBy == temp.UserName).ToList();
            //   var user = User.Identity.GetUserId();
            //var list = db2.Feedbacks.Where(x => x.FeedbackForUserId == id).ToList();

            //   var list = db3.Feedbacks.Where(x => x.FeedbackForUserId == id).ToList();
            var list = db3.Feedbacks.Where(x => x.FeedbackForUserId == aspNetUser.Id).ToList();
            var positiveFeedbacks = 0;
            var negativeFeedbacks = 0;
            var nutralFeedbacks = 0;
            foreach (var item in list)
            {
                // assign to aspNetUser from FeedbackFromUserId for easy access to image
                item.FeedbackFrom = db3.AspNetUser.Find(item.FeedbackFromUserId);
                if (item.FeedbackType == FeedbackType.Positive) positiveFeedbacks++;
                if (item.FeedbackType == FeedbackType.Negative) negativeFeedbacks++;
                if (item.FeedbackType == FeedbackType.Nutral) nutralFeedbacks++;
            }

           

            UserViewViewModel view =   new UserViewViewModel
            {
                User = aspNetUser,
                CoralAdds = cl.Count,
                CoralAddsId = temp.UserName,
                FishAdds = fl.Count,
                FishAddsId = temp.UserName,
                lastOnline = temp.LastLoginTime,
                RegistrationDate = temp.RegistrationDate,
                Feedback = list,
                positiveFeedbacks = positiveFeedbacks,
                negativeFeedbacks = negativeFeedbacks,
                nutralFeedbacks = nutralFeedbacks
                
            };

            return View(view);
        }
        [Authorize]

        // GET: AspNetUsers/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspNetUser = await db3.AspNetUser.FindAsync(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
          
  }
            return View(aspNetUser);
        }


        // GET: AspNetUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AspNetUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,FirstName,LastName,IdUserName,LocationLon,LocationLat,UserPhoto,LastLoginTime,RegistrationDate")] AspNetUser aspNetUser)
        {
            if (ModelState.IsValid)
            {
                
                db3.AspNetUser.Add(aspNetUser);
                await db3.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(aspNetUser);
        }
        //// GET: Feedbacks
        //public ActionResult IndexPartial()
        //{
        //    var user = User.Identity.GetUserId();
        //    var list = db2.Feedbacks.Where(x => x.FeedbackForUserId == user).ToList();
        //    foreach (var item in list)
        //    {
        //        item.FeedbackFrom = db.AspNetUsers.Find(item.FeedbackFromUserId);

        //    }
        //    return PartialView(list);
        //}
        //// GET: AspNetUsers/Edit/5
        //public async Task<ActionResult> Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    AspNetUser aspNetUser = await db.AspNetUsers.FindAsync(id);
        //    if (aspNetUser == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(aspNetUser);
        //}

        //// POST: AspNetUsers/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,FirstName,LastName,IdUserName,LocationLon,LocationLat,UserPhoto")] AspNetUser aspNetUser)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(aspNetUser).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(aspNetUser);
        //}

        //// GET: AspNetUsers/Delete/5
        //public async Task<ActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    AspNetUser aspNetUser = await db.AspNetUsers.FindAsync(id);
        //    if (aspNetUser == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(aspNetUser);
        //}

        //// POST: AspNetUsers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(string id)
        //{
        //    AspNetUser aspNetUser = await db.AspNetUsers.FindAsync(id);
        //    db.AspNetUsers.Remove(aspNetUser);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
