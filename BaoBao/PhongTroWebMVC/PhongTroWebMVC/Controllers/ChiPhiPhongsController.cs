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
    public class ChiPhiPhongsController : Controller
    {
        private dbPhongTro db = new dbPhongTro();

        // GET: ChiPhiPhongs
        public ActionResult Index()
        {
            var chiPhiPhongs = db.ChiPhiPhongs.Include(c => c.ChiPhiKhac).Include(c => c.Phong);
            return View(chiPhiPhongs.ToList());
        }

        // GET: ChiPhiPhongs/Details/5
        public ActionResult Details(int? IDPhong, int? IDChiPhiKhac)
        {
            if (IDPhong == null && IDChiPhiKhac == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiPhiPhong chiPhiPhong = db.ChiPhiPhongs.Find(IDPhong, IDChiPhiKhac);
            if (chiPhiPhong == null)
            {
                return HttpNotFound();
            }
            return View(chiPhiPhong);
        }

        // GET: ChiPhiPhongs/Create
        public ActionResult Create()
        {
            ViewBag.IDChiPhiKhac = new SelectList(db.ChiPhiKhacs, "ID", "Name");
            ViewBag.IDPhong = new SelectList(db.Phongs, "ID", "Name");
            return View();
        }

        // POST: ChiPhiPhongs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPhong,IDChiPhiKhac,CreateDate")] ChiPhiPhong chiPhiPhong)
        {
            if (ModelState.IsValid)
            {
                chiPhiPhong.CreateDate = DateTime.Now;
                db.ChiPhiPhongs.Add(chiPhiPhong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDChiPhiKhac = new SelectList(db.ChiPhiKhacs, "ID", "Name", chiPhiPhong.IDChiPhiKhac);
            ViewBag.IDPhong = new SelectList(db.Phongs, "ID", "Name", chiPhiPhong.IDPhong);
            return View(chiPhiPhong);
        }

        // GET: ChiPhiPhongs/Edit/5
        public ActionResult Edit(int? IDPhong, int? IDChiPhiKhac)
        {
            if (IDPhong == null && IDChiPhiKhac == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiPhiPhong chiPhiPhong = db.ChiPhiPhongs.Find(IDPhong, IDChiPhiKhac);
            if (chiPhiPhong == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDChiPhiKhac = new SelectList(db.ChiPhiKhacs, "ID", "Name", chiPhiPhong.IDChiPhiKhac);
            ViewBag.IDPhong = new SelectList(db.Phongs, "ID", "Name", chiPhiPhong.IDPhong);
            return View(chiPhiPhong);
        }

        // POST: ChiPhiPhongs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPhong,IDChiPhiKhac,CreateDate")] ChiPhiPhong chiPhiPhong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiPhiPhong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDChiPhiKhac = new SelectList(db.ChiPhiKhacs, "ID", "Name", chiPhiPhong.IDChiPhiKhac);
            ViewBag.IDPhong = new SelectList(db.Phongs, "ID", "Name", chiPhiPhong.IDPhong);
            return View(chiPhiPhong);
        }

        // GET: ChiPhiPhongs/Delete/5
        public ActionResult Delete(int? IDPhong, int? IDChiPhiKhac)
        {
            if (IDPhong == null&& IDChiPhiKhac == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiPhiPhong chiPhiPhong = db.ChiPhiPhongs.Find(IDPhong, IDChiPhiKhac);
            if (chiPhiPhong == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.ChiPhiPhongs.Remove(chiPhiPhong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chiPhiPhong);
        }

        // POST: ChiPhiPhongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiPhiPhong chiPhiPhong = db.ChiPhiPhongs.Find(id);
            db.ChiPhiPhongs.Remove(chiPhiPhong);
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
