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

            //    newest coral
            var newCoralList = db.Corals.Where(n => n.UploadedOn.Value < DateTime.Now && n.Name != "test" )
                                    .OrderByDescending(n => n.UploadedOn)
                                    .Take(3).ToList();
            //var newCoralList = db.Corals.Where(n => n.Views > 3)
            //.OrderByDescending(n => n.Views)
            //.Take(5).ToList();

            foreach(var c in newCoralList) {
                 combineCoral(c.CoralId);
                }


            // free coral
            var feeeCoralList = db.Corals.Where(n => n.Views > 3 && n.Name != "test")
                                    .OrderByDescending(n => n.Views)
                                    .Take(6).ToList();
            foreach(var c in feeeCoralList) {
                 combineCoral(c.CoralId);
                }


            // most viewed
            var display5CoralList = db.Corals.Where(n => n.Views > 3 && n.Name != "test")
                           .OrderBy(n => n.Views)
                           .Take(5).ToList();
            foreach(var c in display5CoralList) {
                combineCoral(c.CoralId);
                }


            var coralViewModel = new HomeViewModel(newCoralList, feeeCoralList, display5CoralList);
            return View(coralViewModel);

                
        }

        public Coral combineCoral(int id) {
            var coral = db.Corals.Find(id);
            var CoralPhotoList = db.CoralPhoto.Where(x => x.CoralId == id).ToList();
            if(CoralPhotoList.Count == 0) {
                id = 8;
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
        public ActionResult Chat() {

            return View();
            }
        [Authorize]
        public ActionResult FreeCoral() {
            var cl = db.Corals.Where(n => n.Views >= 13)
                              .OrderBy(n => n.Views)
                              .Take(5).ToList();

            foreach(var c in cl) {
                //  CoralsController cc = new CoralsController();
                combineCoral(c.CoralId);
                }



            CoralViewModel cvm = new CoralViewModel(cl);

            return View(cvm);
            }



        }
    }
