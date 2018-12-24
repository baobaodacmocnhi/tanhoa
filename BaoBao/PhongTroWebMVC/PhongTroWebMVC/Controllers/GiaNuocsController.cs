using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhongTroWebMVC.Models;

namespace PhongTroWebMVC.Controllers
{
    public class GiaNuocsController : Controller
    {
        private dbPhongTro db = new dbPhongTro();

        // GET: GiaNuocs
        public ActionResult Index()
        {
            return View(db.GiaNuocs.ToList());
        }

        // GET: GiaNuocs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaNuoc giaNuoc = db.GiaNuocs.Find(id);
            if (giaNuoc == null)
            {
                return HttpNotFound();
            }
            return View(giaNuoc);
        }

        // GET: GiaNuocs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GiaNuocs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,GiaTien,CreateDate,ModifyDate")] GiaNuoc giaNuoc)
        {
            if (ModelState.IsValid)
            {
                if (db.GiaNuocs.Count() == 0)
                    giaNuoc.ID = 1;
                else
                    giaNuoc.ID = db.GiaNuocs.Max(item => item.ID) + 1;
                giaNuoc.CreateDate = DateTime.Now;
                db.GiaNuocs.Add(giaNuoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(giaNuoc);
        }

        // GET: GiaNuocs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaNuoc giaNuoc = db.GiaNuocs.Find(id);
            if (giaNuoc == null)
            {
                return HttpNotFound();
            }
            return View(giaNuoc);
        }

        // POST: GiaNuocs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,GiaTien,CreateDate,ModifyDate")] GiaNuoc giaNuoc)
        {
            if (ModelState.IsValid)
            {
                giaNuoc.ModifyDate = DateTime.Now;
                db.Entry(giaNuoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(giaNuoc);
        }

        // GET: GiaNuocs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaNuoc giaNuoc = db.GiaNuocs.Find(id);
            if (giaNuoc == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.GiaNuocs.Remove(giaNuoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(giaNuoc);
        }

        // POST: GiaNuocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GiaNuoc giaNuoc = db.GiaNuocs.Find(id);
            db.GiaNuocs.Remove(giaNuoc);
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
