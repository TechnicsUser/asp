using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication9.Filters;
using WebApplication9.Models;

namespace WebApplication9.Controllers {
    public class CoralsController : Controller {
        private SiteDataContext db = new SiteDataContext();
        private ApplicationDbContext db2 = new ApplicationDbContext();


        [NotificationFilter]
        [MessagesFilter]
        // GET: Corals
        public async Task<ActionResult> Index() {
            return  View(await db.Corals.ToListAsync());
         }


        // GET: Corals
        public ActionResult Index2()
        {
            List<Coral> cl = db.Corals.ToList();
            for (int i = 0; i < cl.Count; i++)
            {
                Coral c = cl[i];
                combineCoral(c.CoralId);

            }

            CoralViewModel coralViewModel = new CoralViewModel(cl);

            return View(coralViewModel);


        }
        public Coral combineCoral(int id)
        {
            Coral coral =  db.Corals.Find(id);
            byte[] ba = new byte[] { 0x0 };
            List<CoralPhoto> CoralPhotoList =  db.CoralPhoto.Where(x => x.CoralId == id).Where(x => x.Photo != ba).ToList();
            coral.PhotoList = CoralPhotoList;

            return (coral);

        }


        public async Task<ActionResult> View(int id) {
             byte[] ba = new byte[] { 0x0 };
            List<CoralPhoto> rl = await db.CoralPhoto.Where(x => x.CoralId == id).Where(x => x.Photo != ba).ToListAsync();
            Coral thisCoral = db.Corals.Find(id);
            ViewBag.thisCoral = thisCoral;
            thisCoral.Views++;
            db.Entry(thisCoral).State = EntityState.Modified;
           await db.SaveChangesAsync();
            return View(rl);
        }

        //private ActionResult View(List<CoralPhoto> rl, Coral thisCoral) {
        //    throw new NotImplementedException();
        //}



        public   FileContentResult CoralPhoto3(int id, int number) {
            try {
           //   CoralPhoto rl = await db.CoralPhoto.Where(x => x.CoralId == id).Skip(number).FirstAsync();

                var pic =   (from  sn3 in db.CoralPhoto
                              where sn3.CoralId == id
                              orderby sn3.Likes descending

                              select sn3.Photo).Skip(number).First();


                return new FileContentResult(pic, "image/jpeg");
            }
            catch {

                var CredID = (from sn3 in db.CoralPhoto
                              where sn3.CoralId == id
                              select sn3.Photo).First();


                return new FileContentResult(CredID, "image/jpeg");
            }

        }

        // GET: Corals/Details/5
        public async Task<ActionResult> Details(int? id) {
       
            if (id == null )
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             Coral coral = await db.Corals.FindAsync(id);
            byte[] ba = new byte[] { 0x0 };
            List<CoralPhoto> CoralPhotoList = await db.CoralPhoto.Where(x => x.CoralId == id).Where(x => x.Photo != ba).ToListAsync();
            ApplicationUser Owner = await db2.Users.Where(x => x.UserName == coral.UploadedBy).FirstAsync();

            if (coral == null)
            {
                return HttpNotFound();
            }

            CoralDetailsViewModel coralViewModal = new CoralDetailsViewModel(coral, Owner, CoralPhotoList);
            coral.Views++;
            db.Entry(coral).State = EntityState.Modified;
            await db.SaveChangesAsync();

            return View(coralViewModal);



        }

        // GET: Corals/Create
        [Authorize]
        public ActionResult Create() {
            return View();
            }

        // POST: Corals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "CoralPhoto", Include = "CoralId,Type,Light,Flow,Food,Name,ScientificName,Details,UploadedBy,Price,Size,FragSize,CommentId,Likes,DisLikes,Views,SoldOut,FragAvailable,FragAvailableFrom")] Coral coral) {
            if (ModelState.IsValid) {
                byte[] imageData = null;
                //if (Request.Files.Count > 0) {
                //    HttpPostedFileBase poImgFile = Request.Files["CoralPhoto"];

                //    using (var binary = new BinaryReader(poImgFile.InputStream)) {
                //        imageData = binary.ReadBytes(poImgFile.ContentLength);
                //    }
                //}
                //  byte[] smallArray = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };

                //coral.Photo = imageData;
                coral.UploadedBy = User.Identity.Name;
                db.Corals.Add(coral);
                db.SaveChanges();
            
                if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        var hpf = Request.Files[i];
                        using (var binary = new BinaryReader(hpf.InputStream))
                        {
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

                return RedirectToAction("Index");
                }

            return View(coral);
            }

        // GET: Corals/Edit/5
        public ActionResult Edit(int? id) {
            if(id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            Coral coral = db.Corals.Find(id);
            List<CoralPhoto> fl = db.CoralPhoto.Where(x => x.CoralId == id).ToList();
            // ViewBag.fl = fl;
            ViewBag.count = fl.Count();

            if (User.Identity.Name == coral.UploadedBy) {

                return View(coral);

                }
            if(coral == null) {
                return HttpNotFound();
                }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        // POST: Corals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Exclude = "CoralPhoto",
        public ActionResult Edit([Bind(Include = "CoralPhoto, CoralId,Type,Light,Flow,Food,Name,ScientificName,Details,UploadedBy,Price,Size,FragSize,CommentId,Likes,DisLikes,Views,SoldOut,FragAvailable,FragAvailableFrom")] Coral coral) {
            if(ModelState.IsValid) {
                byte[] imageData = null;
                if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
                { 

                    for (int i = 0; i < Request.Files.Count; i++) {
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


                //var CredID = (from sn3 in db.CoralPhoto
                //              where sn3.CoralId == coral.CoralId
                //              select sn3.Photo).First();
                //db.Entry(coral).Entity.Photo = CredID;

                //       db.Entry(coral).Entity.Name = coral.Name;

                // name
                //sceientific
                //details
                //price
                //
                coral.UploadedBy = User.Identity.Name; // ************** FIX THIS **********************

                db.Entry(coral).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
                }
            return View(coral);
            }

        // GET: Corals/Delete/5
        public ActionResult Delete(int? id) {
            if(id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            Coral coral = db.Corals.Find(id);
            if(coral == null) {
                return HttpNotFound();
                }
            return View(coral);
            }

        // POST: Corals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Coral coral = db.Corals.Find(id);
            db.Corals.Remove(coral);
            db.SaveChanges();
            return RedirectToAction("Index");
            }
        [HttpPost, ActionName("DeleteItem")]
        public void DeleteItem(int id, int num)
        {
            //find photo
            List<CoralPhoto> fl = db.CoralPhoto.Where(x => x.CoralId == num).ToList();
            //remove
            db.CoralPhoto.Remove(fl[id]);
            //update
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing) {
            if(disposing) {
                db.Dispose();
                }
            base.Dispose(disposing);
            }
        }
    }
