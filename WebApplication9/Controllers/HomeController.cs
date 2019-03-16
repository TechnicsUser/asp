﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication9.Filters;
using WebApplication9.Models;

namespace WebApplication9.Controllers {
    [RequireHttps]

    public class HomeController : Controller {

        [NotificationFilter]
        [MessagesFilter]

        public ActionResult Index() {

            userEntities1 db = new userEntities1();

            var movies = from m in db.AspNetUsers
                         where m.LocationLat != null
                         select m;

            return View(movies.ToList());
            // return View();
            }

        public ActionResult Users() {

            userEntities1 db = new userEntities1();

            var movies = from m in db.AspNetUsers
                         where m.LocationLat != null
                         select m;

            return View(movies.ToList());
            // return View();
            }

        public FileContentResult UserPhotos() {
            if(User.Identity.IsAuthenticated) {


                String userId = User.Identity.GetUserId();

                if(userId == null) {
                    string fileName = HttpContext.Server.MapPath(@"~/Images/noImg.png");

                    byte[] imageData = null;
                    FileInfo fileInfo = new FileInfo(fileName);
                    long imageFileLength = fileInfo.Length;
                    FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    imageData = br.ReadBytes((int)imageFileLength);

                    return File(imageData, "image/png");

                    }
                // to get the user details to load user Image    
                var bdUsers = HttpContext.GetOwinContext().Get<ApplicationDbContext>();
                var userImage = bdUsers.Users.Where(x => x.Id == userId).FirstOrDefault();

                return new FileContentResult(userImage.UserPhoto, "image/jpeg");
                }
            else {
                string fileName = HttpContext.Server.MapPath(@"~/Images/noImg.png");

                byte[] imageData = null;
                FileInfo fileInfo = new FileInfo(fileName);
                long imageFileLength = fileInfo.Length;
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)imageFileLength);
                return File(imageData, "image/png");

                }
            }
        [Authorize]
        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
            }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
            }
        }

    }
