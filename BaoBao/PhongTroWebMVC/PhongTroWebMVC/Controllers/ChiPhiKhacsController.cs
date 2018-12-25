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
    public class ChiPhiKhacsController : Controller
    {
        private dbPhongTro db = new dbPhongTro();

        // GET: ChiPhiKhacs
        public ActionResult Index()
        {
            return View(db.ChiPhiKhacs.ToList());
        }

        // GET: ChiPhiKhacs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiPhiKhac chiPhiKhac = db.ChiPhiKhacs.Find(id);
            if (chiPhiKhac == null)
            {
                return HttpNotFound();
            }
            return View(chiPhiKhac);
        }

        // GET: ChiPhiKhacs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChiPhiKhacs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,GiaTien,CreateDate,ModifyDate")] ChiPhiKhac chiPhiKhac)
        {
            if (ModelState.IsValid)
            {
                if (db.ChiPhiKhacs.Count() == 0)
                    chiPhiKhac.ID = 1;
                else
                    chiPhiKhac.ID = db.ChiPhiKhacs.Max(item => item.ID) + 1;
                chiPhiKhac.CreateDate = DateTime.Now;
                db.ChiPhiKhacs.Add(chiPhiKhac);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chiPhiKhac);
        }

        // GET: ChiPhiKhacs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiPhiKhac chiPhiKhac = db.ChiPhiKhacs.Find(id);
            if (chiPhiKhac == null)
            {
                return HttpNotFound();
            }
            return View(chiPhiKhac);
        }

        // POST: ChiPhiKhacs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,GiaTien,CreateDate,ModifyDate")] ChiPhiKhac chiPhiKhac)
        {
            if (ModelState.IsValid)
            {
                chiPhiKhac.ModifyDate = DateTime.Now;
                db.Entry(chiPhiKhac).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chiPhiKhac);
        }

        // GET: ChiPhiKhacs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiPhiKhac chiPhiKhac = db.ChiPhiKhacs.Find(id);
            if (chiPhiKhac == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.ChiPhiKhacs.Remove(chiPhiKhac);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chiPhiKhac);
        }

        // POST: ChiPhiKhacs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiPhiKhac chiPhiKhac = db.ChiPhiKhacs.Find(id);
            db.ChiPhiKhacs.Remove(chiPhiKhac);
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
