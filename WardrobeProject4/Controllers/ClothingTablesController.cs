using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WardrobeProject4.Models;

namespace WardrobeProject4.Controllers
{
    public class ClothingTablesController : Controller
    {
        private WardrobeProject3Entities db = new WardrobeProject3Entities();

        // GET: ClothingTables
        public ActionResult Index()
        {
            return View(db.ClothingTables.ToList());
        }

        // GET: ClothingTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClothingTable clothingTable = db.ClothingTables.Find(id);
            if (clothingTable == null)
            {
                return HttpNotFound();
            }
            return View(clothingTable);
        }

        // GET: ClothingTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClothingTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClothingID,Name,Photo,Color,Occasion,Season,ClothingType")] ClothingTable clothingTable)
        {
            if (ModelState.IsValid)
            {
                db.ClothingTables.Add(clothingTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clothingTable);
        }

        // GET: ClothingTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClothingTable clothingTable = db.ClothingTables.Find(id);
            if (clothingTable == null)
            {
                return HttpNotFound();
            }
            return View(clothingTable);
        }

        // POST: ClothingTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClothingID,Name,Photo,Color,Occasion,Season,ClothingType")] ClothingTable clothingTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clothingTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clothingTable);
        }

        // GET: ClothingTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClothingTable clothingTable = db.ClothingTables.Find(id);
            if (clothingTable == null)
            {
                return HttpNotFound();
            }
            return View(clothingTable);
        }

        // POST: ClothingTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClothingTable clothingTable = db.ClothingTables.Find(id);
            db.ClothingTables.Remove(clothingTable);
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
