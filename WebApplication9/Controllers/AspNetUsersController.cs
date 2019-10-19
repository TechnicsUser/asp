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
        public async Task<ActionResult> Index() {
            List<AspNetUser> lst = await db3.AspNetUser.Where(x => x.EmailConfirmed == true).ToListAsync();
            return View(lst);


            }
        // GET: AspNetUsers
        public async Task<ActionResult> View() {
            List<AspNetUser> lst = await db3.AspNetUser.Where(x => x.EmailConfirmed == true).ToListAsync();
            return View(lst);

            }

        // GET: AspNetUsers
        // [Authorize]
        public async Task<ActionResult> UserView([Bind(Include = "Id")]string id) {
            AspNetUser aspNetUser = db3.AspNetUser.Where(x => x.IdUserName == id).First();
            ApplicationUser temp = db2.Users.Where(x => x.IdUserName == id).First();
            List<Fish> fl = db3.Fish.Where(x => x.UploadedBy == temp.UserName).ToList();
            List<Coral> cl = db3.Corals.Where(x => x.UploadedBy == temp.UserName).ToList();

            var list = db3.Feedbacks.Where(x => x.FeedbackForUserId == aspNetUser.Id).ToList();
            var positiveFeedbacks = 0;
            var negativeFeedbacks = 0;
            var nutralFeedbacks = 0;
            foreach(var item in list) {
                // assign to aspNetUser from FeedbackFromUserId for easy access to image
                item.FeedbackFrom = db3.AspNetUser.Find(item.FeedbackFromUserId);
                if(item.FeedbackType == FeedbackType.Positive) positiveFeedbacks++;
                if(item.FeedbackType == FeedbackType.Negative) negativeFeedbacks++;
                if(item.FeedbackType == FeedbackType.Nutral) nutralFeedbacks++;
                }



            UserView view = new UserView {
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


        }
    }
