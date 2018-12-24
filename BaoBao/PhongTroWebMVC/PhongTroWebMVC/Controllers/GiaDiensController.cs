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
    public class GiaDiensController : Controller
    {
        private dbPhongTro db = new dbPhongTro();

        // GET: GiaDiens
        public ActionResult Index()
        {
            return View(db.GiaDiens.ToList());
        }

        // GET: GiaDiens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaDien giaDien = db.GiaDiens.Find(id);
            if (giaDien == null)
            {
                return HttpNotFound();
            }
            return View(giaDien);
        }

        // GET: GiaDiens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GiaDiens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,GiaTien,DinhMuc,CreateDate,ModifyDate")] GiaDien giaDien)
        {
            if (ModelState.IsValid)
            {
                if (db.GiaDiens.Count() == 0)
                    giaDien.ID = 1;
                else
                    giaDien.ID = db.GiaDiens.Max(item => item.ID) + 1;
                giaDien.CreateDate = DateTime.Now;
                db.GiaDiens.Add(giaDien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(giaDien);
        }

        // GET: GiaDiens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaDien giaDien = db.GiaDiens.Find(id);
            if (giaDien == null)
            {
                return HttpNotFound();
            }
            return View(giaDien);
        }

        // POST: GiaDiens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,GiaTien,DinhMuc,CreateDate,ModifyDate")] GiaDien giaDien)
        {
            if (ModelState.IsValid)
            {
                giaDien.ModifyDate = DateTime.Now;
                db.Entry(giaDien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(giaDien);
        }

        // GET: GiaDiens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaDien giaDien = db.GiaDiens.Find(id);
            if (giaDien == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.GiaDiens.Remove(giaDien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(giaDien);
        }

        // POST: GiaDiens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GiaDien giaDien = db.GiaDiens.Find(id);
            db.GiaDiens.Remove(giaDien);
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
