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

namespace WebApplication9.Controllers
{
    public class FishController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private SiteDataContext db2 = new SiteDataContext();


        // GET: Fish
        public async Task<ActionResult> Index()
        {
            return View(await db.Fish.ToListAsync());
        }

        // GET: Fish/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fish fish = await db.Fish.FindAsync(id);
            if (fish == null)
            {
                return HttpNotFound();
            }
            return View(fish);
        }

        // GET: Fish/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fish/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]/* Flow,Food,Growth,*/
        public async Task<ActionResult> Create([Bind(Include = "FishId,Type,TankSize,Name,ScientificName,Details,Photo,UploadedBy,UploadedOn,Price,Size,FishSize,CommentId,Likes,DisLikes,Views,SoldOut,FishAvailable,FishAvailableFrom")] Fish fish)
        {
            if (ModelState.IsValid)
            {
                db.Fish.Add(fish);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(fish);
        }

        // GET: Fish/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fish fish = await db.Fish.FindAsync(id);
            if (fish == null)
            {
                return HttpNotFound();
            }
            return View(fish);
        }

        // POST: Fish/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]/* Flow,Food,Growth,*/
        public async Task<ActionResult> Edit([Bind(Include = "FishId,Type,TankSize,Name,ScientificName,Details,Photo,UploadedBy,UploadedOn,Price,Size,FishSize,CommentId,Likes,DisLikes,Views,SoldOut,FishAvailable,FishAvailableFrom")] Fish fish)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fish).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(fish);
        }

        // GET: Fish/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fish fish = await db.Fish.FindAsync(id);
            if (fish == null)
            {
                return HttpNotFound();
            }
            return View(fish);
        }

        // POST: Fish/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Fish fish = await db.Fish.FindAsync(id);
            db.Fish.Remove(fish);
            await db.SaveChangesAsync();
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
