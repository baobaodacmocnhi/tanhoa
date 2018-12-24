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
    public class KhachHangsController : Controller
    {
        private dbPhongTro db = new dbPhongTro();

        // GET: KhachHangs
        public ActionResult Index()
        {
            var khachHangs = db.KhachHangs.Include(k => k.Phong);
            return View(khachHangs.ToList());
        }

        // GET: KhachHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // GET: KhachHangs/Create
        public ActionResult Create()
        {
            ViewBag.IDPhong = new SelectList(db.Phongs, "ID", "Name");
            return View();
        }

        // POST: KhachHangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,HoTen,GioiTinh,NgaySinh,DienThoai,BienSoXe,IDPhong,CreateDate,ModifyDate")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                if (db.KhachHangs.Count() == 0)
                    khachHang.ID = 1;
                else
                    khachHang.ID = db.KhachHangs.Max(item => item.ID) + 1;
                khachHang.CreateDate = DateTime.Now;
                db.KhachHangs.Add(khachHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDPhong = new SelectList(db.Phongs, "ID", "Name", khachHang.IDPhong);
            return View(khachHang);
        }

        // GET: KhachHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDPhong = new SelectList(db.Phongs, "ID", "Name", khachHang.IDPhong);
            return View(khachHang);
        }

        // POST: KhachHangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,HoTen,GioiTinh,NgaySinh,DienThoai,BienSoXe,IDPhong,CreateDate,ModifyDate")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                khachHang.ModifyDate = DateTime.Now;
                db.Entry(khachHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDPhong = new SelectList(db.Phongs, "ID", "Name", khachHang.IDPhong);
            return View(khachHang);
        }

        // GET: KhachHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.KhachHangs.Remove(khachHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khachHang);
        }

        // POST: KhachHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KhachHang khachHang = db.KhachHangs.Find(id);
            db.KhachHangs.Remove(khachHang);
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
