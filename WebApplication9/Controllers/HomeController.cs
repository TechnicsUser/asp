using com.sun.tools.doclets.@internal.toolkit.util;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication9.Filters;
using WebApplication9.Models;

namespace WebApplication9.Controllers
    {
    // [RequireHttps]

    public class HomeController : Controller
        {

        private readonly SiteDataContext db = new SiteDataContext();

        //[NotificationFilter]
        //[MessagesFilter]

        public ActionResult Index() {
            var cl = db.Corals.Where(n => n.Views >= 3)
                                    .OrderBy(n => n.Views)
                                    .Take(5).ToList();

            foreach(var c in cl) {
                CoralsController cc = new CoralsController();
           combineCoral(c.CoralId);
                }
            var coralViewModel = new HomeViewModel(cl);
            return View(coralViewModel);

            }

        public Coral combineCoral(int id) {
            var coral = db.Corals.Find(id);
            var CoralPhotoList = db.CoralPhoto.Where(x => x.CoralId == id).ToList();
            if(CoralPhotoList.Count == 0) {
                id = 61;
                CoralPhotoList.Add(db.CoralPhoto.First(x => x.CoralId == id));
                }
            coral.PhotoList = CoralPhotoList;
            return coral;
            }


        public FileContentResult UserPhotos() {

            if(User.Identity.IsAuthenticated) {


                String userId = User.Identity.GetUserId();

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

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";


            return View();
            }
        //[Authorize]

        public ActionResult Contact() {

            return View();
            }



        }
    }
