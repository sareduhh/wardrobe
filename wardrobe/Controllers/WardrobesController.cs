using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using wardrobe.Models;

namespace wardrobe.Controllers
{
    public class WardrobesController : Controller
    {
        private wardrobeEntities db = new wardrobeEntities();

        // GET: Wardrobes
        public ActionResult Index()
        {
            var wardrobes = db.Wardrobes.Include(w => w.Accessory).Include(w => w.Bottom).Include(w => w.Shoe).Include(w => w.Top);
            return View(wardrobes.ToList());
        }

        // GET: Wardrobes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wardrobe wardrobe = db.Wardrobes.Find(id);
            if (wardrobe == null)
            {
                return HttpNotFound();
            }
            return View(wardrobe);
        }

        // GET: Wardrobes/Create
        public ActionResult Create()
        {
            ViewBag.WardrobeID = new SelectList(db.Accessories, "AccessorieID", "Name");
            ViewBag.WardrobeID = new SelectList(db.Bottoms, "BottomID", "Name");
            ViewBag.WardrobeID = new SelectList(db.Shoes, "ShoeID", "Name");
            ViewBag.WardrobeID = new SelectList(db.Tops, "TopID", "Name");
            return View();
        }

        // POST: Wardrobes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WardrobeID,TopID,BottomID,ShoeID,AccessorieID")] Wardrobe wardrobe)
        {
            if (ModelState.IsValid)
            {
                db.Wardrobes.Add(wardrobe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WardrobeID = new SelectList(db.Accessories, "AccessorieID", "Name", wardrobe.WardrobeID);
            ViewBag.WardrobeID = new SelectList(db.Bottoms, "BottomID", "Name", wardrobe.WardrobeID);
            ViewBag.WardrobeID = new SelectList(db.Shoes, "ShoeID", "Name", wardrobe.WardrobeID);
            ViewBag.WardrobeID = new SelectList(db.Tops, "TopID", "Name", wardrobe.WardrobeID);
            return View(wardrobe);
        }

        // GET: Wardrobes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wardrobe wardrobe = db.Wardrobes.Find(id);
            if (wardrobe == null)
            {
                return HttpNotFound();
            }
            ViewBag.WardrobeID = new SelectList(db.Accessories, "AccessorieID", "Name", wardrobe.WardrobeID);
            ViewBag.WardrobeID = new SelectList(db.Bottoms, "BottomID", "Name", wardrobe.WardrobeID);
            ViewBag.WardrobeID = new SelectList(db.Shoes, "ShoeID", "Name", wardrobe.WardrobeID);
            ViewBag.WardrobeID = new SelectList(db.Tops, "TopID", "Name", wardrobe.WardrobeID);
            return View(wardrobe);
        }

        // POST: Wardrobes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WardrobeID,TopID,BottomID,ShoeID,AccessorieID")] Wardrobe wardrobe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wardrobe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WardrobeID = new SelectList(db.Accessories, "AccessorieID", "Name", wardrobe.WardrobeID);
            ViewBag.WardrobeID = new SelectList(db.Bottoms, "BottomID", "Name", wardrobe.WardrobeID);
            ViewBag.WardrobeID = new SelectList(db.Shoes, "ShoeID", "Name", wardrobe.WardrobeID);
            ViewBag.WardrobeID = new SelectList(db.Tops, "TopID", "Name", wardrobe.WardrobeID);
            return View(wardrobe);
        }

        // GET: Wardrobes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wardrobe wardrobe = db.Wardrobes.Find(id);
            if (wardrobe == null)
            {
                return HttpNotFound();
            }
            return View(wardrobe);
        }

        // POST: Wardrobes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wardrobe wardrobe = db.Wardrobes.Find(id);
            db.Wardrobes.Remove(wardrobe);
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
