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
using PagedList;


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
        public ActionResult coralPhotoView(int?  id) {
            SiteDataContext cp = new SiteDataContext();
            byte[] ba = new byte[] { 0x0 };
            List<CoralPhoto> rl = cp.CoralPhoto.Where(x => x.CoralId == id).Where(x => x.Photo != ba).ToList();
            Coral thisCoral = db.Corals.Find(id);
            ViewBag.thisCoral = thisCoral;
            Coral c = db.Corals.Find(id);
            return View(rl, c);


            }


            public ViewResult Index1(string sortOrder, string currentFilter, string searchString, int? page) {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "UploadedOn";

            if(searchString != null) {
                page = 1;
                }
            else {
                searchString = currentFilter;
                }

            ViewBag.CurrentFilter = searchString;

            var students = from s in db.Corals
                           select s;
            if(!String.IsNullOrEmpty(searchString)) {
                students = students.Where(s => s.Name.Contains(searchString)
                                       || s.ScientificName.Contains(searchString));
                }
            switch(sortOrder) {
                case "name_desc":
                students = students.OrderByDescending(s => s.Name);
                break;
                case "UploadedOn":
                students = students.OrderBy(s => s.UploadedOn);
                break;
                case "date_desc":
                students = students.OrderByDescending(s => s.UploadedOn);
                break;
                default:  // Name ascending 
                students = students.OrderBy(s => s.ScientificName);
                break;
                }

            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(students.ToPagedList(pageNumber, pageSize));
            }

        public ActionResult View(int? id) {
            SiteDataContext cp = new SiteDataContext();
            byte[] ba = new byte[] { 0x0 };
            List<CoralPhoto> rl = cp.CoralPhoto.Where(x => x.CoralId == id).Where(x=> x.Photo != ba).ToList();
            Coral thisCoral = db.Corals.Find(id);
            ViewBag.thisCoral = thisCoral;
            return View( rl);
            }

        private ActionResult View(List<CoralPhoto> rl, Coral thisCoral) {
            return View(rl, thisCoral);
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
        public FileContentResult CoralPhoto2(int id, int number) {
            //   if(User.Identity.IsAuthenticated) {

            //  var coralPhoto = db.CoralPhoto.Find(id);
            //if(coralPhoto.Photo == null) {
            //    string fileName = HttpContext.Server.MapPath(@"~/Images/noImg.png");

            //    byte[] imageData = null;
            //    FileInfo fileInfo = new FileInfo(fileName);
            //    long imageFileLength = fileInfo.Length;
            //    FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            //    BinaryReader br = new BinaryReader(fs);
            //    imageData = br.ReadBytes((int)imageFileLength);

            //    return File(imageData, "image/png");
            //    }
            // byte[] coralImage = coralPhoto.Photo;

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


            var coralPhoto = (from sn3 in db.CoralPhoto
                              where sn3.CoralId == id
                              select sn3.Photo).ToList();
            byte[] coralImage = coralPhoto[number];


            //var mylist = db.CoralPhoto.ToList();
            //    var photo = mylist.First().Photo;
            return new FileContentResult(coralImage, "image/jpeg");

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
        //Exclude = "CoralPhoto",
        public ActionResult Create([Bind( Include = "CoralPhoto, CoralId,Type,Light,Flow,Food,Name,ScientificName,Details,UploadedBy,Price,Size,FragSize,CommentId,Likes,DisLikes,Views,SoldOut,FragAvailable,FragAvailableFrom")] Coral coral)
        {
             if(ModelState.IsValid) {
                byte[] imageData = null;
              
                db.Corals.Add(coral);
                db.SaveChanges();

                if(Request.Files.Count > 0) {
                    for(int i = 0; i < Request.Files.Count; i++) {
                        var hpf = Request.Files[i];
                        using(var binary = new BinaryReader(hpf.InputStream)) {
                            imageData = binary.ReadBytes(hpf.ContentLength);
                            }

                        CoralPhoto cp = new CoralPhoto();
                        cp.UserId = User.Identity.GetUserId();

                        if(i == 0) {
                            coral.Photo = imageData;
                            }
                        cp.Photo = imageData;
                        
                          cp.CoralId = coral.CoralId;

                        db.CoralPhoto.Add(cp);
                        db.SaveChanges();
                        }
                    }

                    //      HttpPostedFileBase poImgFile = Request.Files["CoralPhoto"];

                    //      using(var binary = new BinaryReader(poImgFile.InputStream)) {
                    //          imageData = binary.ReadBytes(poImgFile.ContentLength);
                    //          }
                    //      }
                    ////  byte[] smallArray = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };

                    //  coral.Photo = imageData;
                    //  coral.UploadedBy = User.Identity.GetUserId();
               

                    //  foreach(var item in Request.Files) {
                    //         CoralPhoto cp = new CoralPhoto();
                    //  cp.UserId = User.Identity.GetUserId();
                    //  cp.Photo = coral.Photo;
                    //  cp.CoralPhotoId = coral.CoralId;
                    //  cp.CoralId = coral.CoralId;
                    //  cp.Views = 0;
                    //  cp.Likes = 0;
                    //  cp.DisLikes = 0;
                    //  db.CoralPhoto.Add(cp);
                    //  db.SaveChanges();
                    //      }


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
        // Exclude = "CoralPhoto",
        public ActionResult Edit([Bind( Include = "CoralPhoto, CoralId,Type,Light,Flow,Food,Name,ScientificName,Details,UploadedBy,Price,Size,FragSize,CommentId,Likes,DisLikes,Views,SoldOut,FragAvailable,FragAvailableFrom")] Coral coral)
        {
            if (ModelState.IsValid)
            {
                byte[] imageData = null;
                if(Request.Files.Count > 0) {


                    for(int i = 0; i < Request.Files.Count; i++) {
                        var hpf = Request.Files[i];
                        using(var binary = new BinaryReader(hpf.InputStream)) {
                            imageData = binary.ReadBytes(hpf.ContentLength);
                            }

                        CoralPhoto cp = new CoralPhoto();
                        cp.UserId = User.Identity.GetUserId();


                        cp.Photo = imageData;
                        cp.CoralPhotoId = coral.CoralId;
                        cp.CoralId = coral.CoralId;
                        cp.Views = 0;
                        cp.Likes = 0;
                        cp.DisLikes = 0;
                        db.CoralPhoto.Add(cp);
                        db.SaveChanges();
                        }



                    }


                var CredID = (from sn3 in db.CoralPhoto
                              where sn3.CoralId == coral.CoralId
                              select sn3.Photo).First();
                db.Entry(coral).Entity.Photo = CredID;

         //       db.Entry(coral).Entity.Name = coral.Name;

                // name
                //sceientific
                //details
                //price
                //

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
