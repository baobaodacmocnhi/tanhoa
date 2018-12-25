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
    public class PhongsController : Controller
    {
        private dbPhongTro db = new dbPhongTro();

        // GET: Phongs
        public ActionResult Index()
        {
            return View(db.Phongs.ToList());
        }

        // GET: Phongs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phong phong = db.Phongs.Find(id);
            if (phong == null)
            {
                return HttpNotFound();
            }
            return View(phong);
        }

        // GET: Phongs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Phongs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,GiaTien,Thue,NgayThue,ChiSoDienOld,ChiSoDien,SoNKNuoc,ChiSoNuocOld,ChiSoNuoc,CreateDate,ModifyDate")] Phong phong)
        {
            if (ModelState.IsValid)
            {
                if (db.Phongs.Count() == 0)
                    phong.ID = 1;
                else
                    phong.ID = db.Phongs.Max(item => item.ID) + 1;
                phong.CreateDate = DateTime.Now;
                db.Phongs.Add(phong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phong);
        }

        // GET: Phongs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phong phong = db.Phongs.Find(id);
            if (phong == null)
            {
                return HttpNotFound();
            }
            return View(phong);
        }

        // POST: Phongs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,GiaTien,Thue,NgayThue,ChiSoDienOld,ChiSoDien,SoNKNuoc,ChiSoNuocOld,ChiSoNuoc,CreateDate,ModifyDate")] Phong phong)
        {
            if (ModelState.IsValid)
            {
                phong.ModifyDate = DateTime.Now;
                db.Entry(phong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phong);
        }

        // GET: Phongs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phong phong = db.Phongs.Find(id);
            if (phong == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.Phongs.Remove(phong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phong);
        }

        // POST: Phongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Phong phong = db.Phongs.Find(id);
            db.Phongs.Remove(phong);
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
