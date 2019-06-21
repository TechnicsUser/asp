using Microsoft.AspNet.Identity;
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
    public class FishController : Controller {
        private ApplicationDbContext db = new ApplicationDbContext();
        private SiteDataContext db2 = new SiteDataContext();

        [NotificationFilter]
        [MessagesFilter]
        // GET: Fish
        public async Task<ActionResult> Index()
        {
            return View(await db2.Fish.ToListAsync());
        }
        public async Task<ActionResult> Index1(string id)
        {
            List<Fish> fishList = await db2.Fish.Where(x => x.UploadedBy == id).ToListAsync();

            return View(fishList);
        }

        public ActionResult View(int id) {
            //   byte[] ba = new byte[] { 0x0 };  //.Where(x => x.Photo != ba)
            List<fishPhoto> rl = db2.FishPhoto.Where(x => x.FishId == id).ToList();
            Fish thisFish = db2.Fish.Find(id);
            ViewBag.thisFish = thisFish;
            thisFish.Views++;
            db2.Entry(thisFish).State = EntityState.Modified;
            db2.SaveChangesAsync();
            return View(rl);
            }

        public ActionResult View1(int id) {

            List<Fish> fl = db2.Fish.Where(x => x.FishId == id).ToList();
            Fish thisFish = db2.Fish.Find(id);
            return View(thisFish);
            }
        public FileContentResult FishPhoto(int id, int number) {
            //   if(User.Identity.IsAuthenticated) {
            try {
                byte[] ba = new byte[] { 0x0 };
                var CredID = (from sn3 in db2.FishPhoto.Where(x => x.Photo != ba)
                              where sn3.FishId == id
                              orderby sn3.Likes descending
                              select sn3.Photo).Skip(number).First();
                return new FileContentResult(CredID, "image/jpeg");
                }
            catch {
                var CredID = (from sn3 in db2.FishPhoto
                              where sn3.FishId == id
                              select sn3.Photo).First();
                return new FileContentResult(CredID, "image/jpeg");
                }

            }


        // GET: Fish/Details/5
        public async Task<ActionResult> Details(int? id) {
            if(id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            Fish fish = await db2.Fish.FindAsync(id);
            if(fish == null) {
                return HttpNotFound();
                }
            return View(fish);
            }
        [Authorize]

        // GET: Fish/Create
        public ActionResult Create() {
            var model = new Fish()
            {

                TankSize = Fish.TankSizeRequirement.None,
            };
return View(model);
           // return View();
            }

        // POST: Fish/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]/* Flow,Food,Growth,*/
        public async Task<ActionResult> Create([Bind(Exclude = "FishPhoto", Include = "FishId,Type,TankSize,Name,ScientificName,Details,UploadedBy,UploadedOn,Price,Size,FishSize,CommentId,Likes,DisLikes,Views,SoldOut,FishAvailable,FishAvailableFrom")] Fish fish) {
            if(ModelState.IsValid) {

                fish.UploadedBy = User.Identity.Name;
                fish.UploadedOn = DateTime.Now.ToShortDateString();
                db2.Fish.Add(fish);
                await db.SaveChangesAsync();

                byte[] imageData = null;
                if(Request.Files.Count > 0 && Request.Files[0].ContentLength > 0) {
                    for(int i = 0; i < Request.Files.Count; i++) {
                        var hpf = Request.Files[i];
                        using(var binary = new BinaryReader(hpf.InputStream)) {
                            imageData = binary.ReadBytes(hpf.ContentLength);
                            }
                        fishPhoto cp = new fishPhoto();
                        cp.UserId = User.Identity.GetUserId();
                        cp.CreatedOn = DateTime.Now.ToShortDateString();
                        cp.Photo = imageData;
                        cp.FishId = fish.FishId;
                        cp.Views = 0;
                        cp.Likes = 0;
                        cp.DisLikes = 0;
                        db2.FishPhoto.Add(cp);
                        db2.SaveChanges();
                        }
                    }
                return RedirectToAction("Index");
                }
            return View(fish);
            }

        // GET: Fish/Edit/5
        public async Task<ActionResult> Edit(int? id) {
            if(id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            Fish fish = await db2.Fish.FindAsync(id);
            List<fishPhoto> fl = db2.FishPhoto.Where(x => x.FishId == id).ToList();
           // ViewBag.fl = fl;
            ViewBag.count = fl.Count();
            if(fish == null) {
                return HttpNotFound();
                }
            return View(fish);
            }

        // POST: Fish/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]/* Flow,Food,Growth,*/
        //[Bind(Exclude = "CommentId,Likes,DisLikes,Views,UploadedBy, UploadedOn", Include = "FishPhoto,FishId,Type,TankSize,Name,ScientificName,Details,Photo,Price,Size,FishSize,SoldOut,FishAvailable,FishAvailableFrom")]
        //[Bind(Include = "Type,TankSize,Name,ScientificName,Details,Price,FishSize,SoldOut,FishAvailable,FishAvailableFrom")]
        public async Task<ActionResult> Edit([Bind(Include = "CommentId,Likes,DisLikes,Views,UploadedBy, UploadedOn,FishPhoto, FishId,Type,TankSize,Name,ScientificName,Details,Photo,Price,Size,FishSize,SoldOut,FishAvailable,FishAvailableFrom")]Fish fish) {
            if(ModelState.IsValid) {
                byte[] imageData = null;
                if(Request.Files.Count > 0 && Request.Files[0].ContentLength > 0) {
                         for(int i = 0; i < Request.Files.Count; i++) {
                            var hpf = Request.Files[i];
                            using(var binary = new BinaryReader(hpf.InputStream)) {
                                imageData = binary.ReadBytes(hpf.ContentLength);
                                }
                            fishPhoto cp = new fishPhoto();
                            cp.UserId = User.Identity.GetUserId();
                            cp.Photo = imageData;
                            //cp.FishPhotoId = fish.FishId;
                            cp.FishId = fish.FishId;
                            cp.Views = 0;
                            cp.Likes = 0;
                            cp.DisLikes = 0;
                            db2.FishPhoto.Add(cp);
                            db2.SaveChanges();
                            }
                        }
                    //var CredID = (from sn3 in db2.FishPhoto
                    //              where sn3.FishId == fish.FishId
                    //              select sn3.Photo).First();
                    //db2.Entry(fish).Entity.Photo = CredID;
                    // fish.UploadedBy = User.Identity.Name;
                    db.Entry(fish).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                    }
                 
            return View(fish);
            }

        // GET: Fish/Delete/5
        public async Task<ActionResult> Delete(int? id) {
            if(id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            Fish fish = await db2.Fish.FindAsync(id);
            if(fish == null) {
                return HttpNotFound();
                }
            if(fish.UploadedBy == User.Identity.Name) {
                return View(fish);
                }
            return HttpNotFound();
            }
        // POST: Fish/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id) {
            Fish fish = await db2.Fish.FindAsync(id);
            if(fish.UploadedBy == User.Identity.Name) {
                db2.Fish.Remove(fish);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
                }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        [HttpPost, ActionName("DeleteItem")]
        public void DeleteItem(int id, int num) {
            //find photo
            List<fishPhoto> fl = db2.FishPhoto.Where(x => x.FishId == num).ToList();
            //remove
            db2.FishPhoto.Remove(fl[id]);
            //update
            db2.SaveChangesAsync();
            }
        protected override void Dispose(bool disposing) {
            if(disposing) {
                db.Dispose();
                }
            base.Dispose(disposing);
            }
        }
    }
