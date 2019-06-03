using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WebApplication9.Filters;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class CoralsController : Controller
    {
        private readonly SiteDataContext db = new SiteDataContext();


        [NotificationFilter]
        [MessagesFilter]
        // GET: Corals
        public ActionResult Index()
        {
            var cl = db.Corals.ToList();
            foreach (var c in cl)
            {
                combineCoral(c.CoralId);
            }
            var coralViewModel = new CoralViewModel(cl);
            return View(coralViewModel);
        }

        public Coral combineCoral(int id)
        {
            var coral = db.Corals.Find(id);
            var CoralPhotoList = db.CoralPhoto.Where(x => x.CoralId == id).ToList();
            if (CoralPhotoList.Count == 0)
            {
                id = 61;
                CoralPhotoList.Add(db.CoralPhoto.First(x => x.CoralId == id));
            }
            coral.PhotoList = CoralPhotoList;
            return coral;
        }


        public async Task<ActionResult> View(int id)
        {
            var rl = await db.CoralPhoto.Where(x => x.CoralId == id).ToListAsync();
            var thisCoral = db.Corals.Find(id);
            ViewBag.thisCoral = thisCoral;
            if (thisCoral != null)
            {
                thisCoral.Views++;
                db.Entry(thisCoral).State = EntityState.Modified;
            }
            await db.SaveChangesAsync();
            return View(rl);
        }



        // GET: Corals/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var coral = await db.Corals.FindAsync(id);
            if (coral == null) return HttpNotFound();

            var coralPhotoList = await db.CoralPhoto.Where(x => x.CoralId == id).ToListAsync();
            if (coralPhotoList.Count == 0)
            {
                id = 61;
                coralPhotoList.Add(db.CoralPhoto.First(x => x.CoralId == id));
            }

            var owner = await db.Users.Where(x => x.UserName == coral.UploadedBy).FirstAsync();
            var comments = await db.Comments.Where(x => x.CommentOn == coral.CoralId.ToString()).ToListAsync();

            var coralViewModal = new CoralDetailsViewModel(coral, owner, coralPhotoList, comments);
            coral.Views++;
            db.Entry(coral).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return View(coralViewModal);
        }

        // GET: Corals/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Corals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "CoralPhoto",
                Include =
                    "CoralId,Type,Light,Flow,Food,Name,ScientificName,Details,UploadedBy,Price,Size,FragSize,CommentId,Likes,DisLikes,Views,SoldOut,FragAvailable,FragAvailableFrom")]
            Coral coral)
        {
            if (!ModelState.IsValid) return View(coral);
            coral.UploadedBy = User.Identity.Name;
            db.Corals.Add(coral);
            db.SaveChanges();
            if (Request.Files.Count <= 0 || Request.Files[0].ContentLength <= 0) return RedirectToAction("Index");

            for (var i = 0; i < Request.Files.Count; i++)
            {
                var hpf = Request.Files[i];
                byte[] imageData;
                using (var binary = new BinaryReader(hpf.InputStream))
                {
                    imageData = binary.ReadBytes(hpf.ContentLength);
                }

                var cp = new CoralPhoto
                {
                    UserId = User.Identity.GetUserId(),
                    Photo = imageData,
                    CoralPhotoId = coral.CoralId,
                    CoralId = coral.CoralId,
                    Views = 0,
                    Likes = 0,
                    DisLikes = 0
                };
                db.CoralPhoto.Add(cp);
                db.SaveChanges();
            }

            return RedirectToAction("Index");

        }

        // GET: Corals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var coral = db.Corals.Find(id);
            var fl = db.CoralPhoto.Where(x => x.CoralId == id).ToList();
            ViewBag.count = fl.Count();

            if (User.Identity.Name == coral.UploadedBy) return View(coral);
            else
                return coral == null ? HttpNotFound() : new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // POST: Corals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include =
                "CoralPhoto, CoralId,Type,Light,Flow,Food,Name,ScientificName,Details,UploadedBy,Price,Size,FragSize,CommentId,Likes,DisLikes,Views,SoldOut,FragAvailable,FragAvailableFrom")]
            Coral coral)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
                    for (var i = 0; i < Request.Files.Count; i++)
                    {
                        var hpf = Request.Files[i];
                        byte[] imageData;
                        using (var binary = new BinaryReader(hpf.InputStream))
                        {
                            imageData = binary.ReadBytes(hpf.ContentLength);
                        }
                        var cp = new CoralPhoto
                        {
                            UserId = User.Identity.GetUserId(),
                            Photo = imageData,
                            CoralPhotoId = coral.CoralId,
                            CoralId = coral.CoralId,
                            Views = 0,
                            Likes = 0,
                            DisLikes = 0
                        };
                        db.CoralPhoto.Add(cp);
                        db.SaveChanges();
                    }

                coral.UploadedBy =
                User.Identity.Name; // ************ FIX THIS (should be binding) **********************
                db.Entry(coral).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(coral);
        }

        // GET: Corals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var coral = db.Corals.Find(id);
            if (coral == null) return HttpNotFound();
            return View(coral);
        }

        // POST: Corals/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var coral = db.Corals.Find(id);
            if (coral != null) db.Corals.Remove(coral);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ActionName("DeleteItem")]
        public void DeleteItem(int id, int num)
        {
            //find photo
            var fl = db.CoralPhoto.Where(x => x.CoralId == num).ToList();
            //remove
            db.CoralPhoto.Remove(fl[id]);
            //update
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }


        //******************************** Comments Create ***********************************************
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]

        public async Task<ActionResult> Details([Bind(Include = "UserPhoto,CommentId,Type,UserId,CreatedOn,CommentOn,CommentTitle,CommentText")] Comments comments)
        {
            if (ModelState.IsValid)
            {
                comments.CommentViews = 0;
                comments.Removed = false;
                comments.Reports = 0;
                comments.Likes = 0;
                comments.DisLikes = 0;

                try
                {
                    comments.UserPhoto = await db.Users.Where(x => x.UserName == comments.UserId).
                        Select(x => x.UserPhoto).FirstAsync();
                }
                catch (Exception Ex)
                {
                    //return RedirectToAction("Login", "Account", null);
                }

                comments.UploadedBy = User.Identity.GetUserId();
                comments.CreatedOn = DateTime.Now.ToShortDateString();
                db.Comments.Add(comments);
                db.SaveChanges();
                return RedirectToAction("Details", "Corals", new { comments.CommentOn });
            }

            return View();
        }

    }
}