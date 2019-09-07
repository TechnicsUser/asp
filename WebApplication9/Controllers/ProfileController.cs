using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication9.Models;

namespace WebApplication9.Controllers
    {
    public class ProfileController : Controller
        {
        public ActionResult ChangeTheme(string themename) {
            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(userStore);
            var user = manager.FindById(User.Identity.GetUserId());
            user.CssTheme = themename;
            manager.Update(user);
            var ctx = userStore.Context;

            ctx.SaveChanges();


            if(Request.UrlReferrer != null) {
                var returnUrl = Request.UrlReferrer.ToString();
                return new RedirectResult(returnUrl);
                }
            return RedirectToAction("Index", "Home");
            }
        }
    }