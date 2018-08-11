using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class CoralsController : Controller
    {
        private SiteDataContext db = new SiteDataContext();

        // GET: Corals
        public ActionResult Index()
        {
            return View(db.Corals.ToList());
        }

        public ActionResult View(int id) {
            SiteDataContext cp = new SiteDataContext();
            List<CoralPhoto> rl = cp.CoralPhoto.Where(x => x.CoralId == id).ToList();

            return View( rl);
            }

        public FileContentResult CoralPhoto(int id) {
            //   if(User.Identity.IsAuthenticated) {

            Coral coral = db.Corals.Find(id);
            if(coral.Photo == null) {
                string fileName = HttpContext.Server.MapPath(@"~/Images/noImg.png");

                byte[] imageData = null;
                FileInfo fileInfo = new FileInfo(fileName);
                long imageFileLength = fileInfo.Length;
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)imageFileLength);

                return File(imageData, "image/png");
                }
            byte[] coralImage = coral.Photo;

           // String userId = User.Identity.GetUserId();

                //if(userId != null) {
                //    string fileName = HttpContext.Server.MapPath(@"~/Images/noImg.png");

                //    byte[] imageData = null;
                //    FileInfo fileInfo = new FileInfo(fileName);
                //    long imageFileLength = fileInfo.Length;
                //    FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                //    BinaryReader br = new BinaryReader(fs);
                //    imageData = br.ReadBytes((int)imageFileLength);

                //    return File(imageData, "image/png");

                //    }
                // to get the user details to load user Image    
                //var bdUsers = HttpContext.GetOwinContext().Get<Coral>();
                //var userImage = bdUsers.Users.Where(x => x.Id == userId).FirstOrDefault();

               


                return new FileContentResult(coralImage, "image/jpeg");
            //    }
            //else {
            //    string fileName = HttpContext.Server.MapPath(@"~/Images/noImg.png");

            //    byte[] imageData = null;
            //    FileInfo fileInfo = new FileInfo(fileName);
            //    long imageFileLength = fileInfo.Length;
            //    FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            //    BinaryReader br = new BinaryReader(fs);
            //    imageData = br.ReadBytes((int)imageFileLength);
            //    return File(imageData, "image/png");

            //    }
            }
        public FileContentResult CoralPhoto2(int id) {
            //   if(User.Identity.IsAuthenticated) {

            var coralPhoto = db.CoralPhoto.Find(id);
            if(coralPhoto.Photo == null) {
                string fileName = HttpContext.Server.MapPath(@"~/Images/noImg.png");

                byte[] imageData = null;
                FileInfo fileInfo = new FileInfo(fileName);
                long imageFileLength = fileInfo.Length;
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)imageFileLength);

                return File(imageData, "image/png");
                }
            byte[] coralImage = coralPhoto.Photo;

            // String userId = User.Identity.GetUserId();

            //if(userId != null) {
            //    string fileName = HttpContext.Server.MapPath(@"~/Images/noImg.png");

            //    byte[] imageData = null;
            //    FileInfo fileInfo = new FileInfo(fileName);
            //    long imageFileLength = fileInfo.Length;
            //    FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            //    BinaryReader br = new BinaryReader(fs);
            //    imageData = br.ReadBytes((int)imageFileLength);

            //    return File(imageData, "image/png");

            //    }
            // to get the user details to load user Image    
            //var bdUsers = HttpContext.GetOwinContext().Get<CoralPhoto>();
            //var userImage = bdUsers.CoralId.(x => x.Id == id).FirstOrDefault();


            var CredID = (from sn3 in db.CoralPhoto
                          where sn3.CoralId == id
                          select sn3.Photo).First();


            return new FileContentResult(CredID, "image/jpeg");

            //SiteDataContext cp = new SiteDataContext();
            //List<CoralPhoto> rl = cp.CoralPhoto.Where(x => x.CoralId == id).ToList();

            //return View(rl);

            }


        // GET: Corals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coral coral = db.Corals.Find(id);
            if (coral == null)
            {
                return HttpNotFound();
            }
            return View(coral);
        }

        // GET: Corals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Corals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "CoralPhoto", Include = "CoralId,Type,Light,Flow,Food,Name,ScientificName,Details,UploadedBy,Price,Size,FragSize,CommentId,Likes,DisLikes,Views,SoldOut,FragAvailable,FragAvailableFrom")] Coral coral)
        {
            if(ModelState.IsValid) {
                byte[] imageData = null;
                if(Request.Files.Count > 0) {
                    HttpPostedFileBase poImgFile = Request.Files["CoralPhoto"];

                    using(var binary = new BinaryReader(poImgFile.InputStream)) {
                        imageData = binary.ReadBytes(poImgFile.ContentLength);
                        }
                    }
              //  byte[] smallArray = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };

                coral.Photo = imageData;
                coral.UploadedBy = User.Identity.GetUserId();
                db.Corals.Add(coral);
                db.SaveChanges();
              
                foreach(var item in Request.Files) {
                       CoralPhoto cp = new CoralPhoto();
                cp.UserId = User.Identity.GetUserId();
                cp.Photo = coral.Photo;
                cp.CoralPhotoId = coral.CoralId;
                cp.CoralId = coral.CoralId;
                cp.Views = 0;
                cp.Likes = 0;
                cp.DisLikes = 0;
                db.CoralPhoto.Add(cp);
                db.SaveChanges();
                    }
             

                return RedirectToAction("Index");
            }

            return View(coral);
        }

        // GET: Corals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coral coral = db.Corals.Find(id);
            if (coral == null)
            {
                return HttpNotFound();
            }
            return View(coral);
        }

        // POST: Corals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude = "CoralPhoto", Include = "CoralId,Type,Light,Flow,Food,Name,ScientificName,Details,UploadedBy,Price,Size,FragSize,CommentId,Likes,DisLikes,Views,SoldOut,FragAvailable,FragAvailableFrom")] Coral coral)
        {
            if (ModelState.IsValid)
            {
                byte[] imageData = null;
                if(Request.Files.Count > 0) {
                    HttpPostedFileBase poImgFile = Request.Files["CoralPhoto"];

                    using(var binary = new BinaryReader(poImgFile.InputStream)) {
                        imageData = binary.ReadBytes(poImgFile.ContentLength);
                        }
                    }
                byte[] smallArray = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };

                coral.Photo = imageData;
                db.Entry(coral).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coral);
        }

        // GET: Corals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coral coral = db.Corals.Find(id);
            if (coral == null)
            {
                return HttpNotFound();
            }
            return View(coral);
        }

        // POST: Corals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Coral coral = db.Corals.Find(id);
            db.Corals.Remove(coral);
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
