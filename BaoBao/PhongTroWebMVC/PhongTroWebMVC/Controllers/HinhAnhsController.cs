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
    public class HinhAnhsController : Controller
    {
        private dbPhongTro db = new dbPhongTro();

        // GET: HinhAnhs
        public ActionResult Index()
        {
            var hinhAnhs = db.HinhAnhs.Include(h => h.KhachHang);
            return View(hinhAnhs.ToList());
        }

        // GET: HinhAnhs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HinhAnh hinhAnh = db.HinhAnhs.Find(id);
            if (hinhAnh == null)
            {
                return HttpNotFound();
            }
            return View(hinhAnh);
        }

        // GET: HinhAnhs/Create
        public ActionResult Create()
        {
            ViewBag.ID_KhachHang = new SelectList(db.KhachHangs, "ID", "HoTen");
            return View();
        }

        // POST: HinhAnhs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create([Bind(Include = "ID_KhachHang")] HinhAnh hinhAnh,HttpPostedFileBase imageUpload)
        {
            if (ModelState.IsValid)
            {
                if (imageUpload != null)
                {
                    if (db.HinhAnhs.Count() == 0)
                        hinhAnh.ID = 1;
                    else
                        hinhAnh.ID = db.HinhAnhs.Max(item => item.ID) + 1;
                    hinhAnh.Image = new byte[imageUpload.ContentLength];
                    imageUpload.InputStream.Read(hinhAnh.Image, 0, imageUpload.ContentLength);
                    hinhAnh.CreateDate = DateTime.Now;
                    db.HinhAnhs.Add(hinhAnh);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.ID_KhachHang = new SelectList(db.KhachHangs, "ID", "HoTen", hinhAnh.ID_KhachHang);
            return View(hinhAnh);
        }

        // GET: HinhAnhs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HinhAnh hinhAnh = db.HinhAnhs.Find(id);
            if (hinhAnh == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_KhachHang = new SelectList(db.KhachHangs, "ID", "HoTen", hinhAnh.ID_KhachHang);
            return View(hinhAnh);
        }

        // POST: HinhAnhs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Image,ID_KhachHang,CreateDate")] HinhAnh hinhAnh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hinhAnh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_KhachHang = new SelectList(db.KhachHangs, "ID", "HoTen", hinhAnh.ID_KhachHang);
            return View(hinhAnh);
        }

        // GET: HinhAnhs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HinhAnh hinhAnh = db.HinhAnhs.Find(id);
            if (hinhAnh == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.HinhAnhs.Remove(hinhAnh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hinhAnh);
        }

        // POST: HinhAnhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HinhAnh hinhAnh = db.HinhAnhs.Find(id);
            db.HinhAnhs.Remove(hinhAnh);
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

        public ActionResult GetImage(int ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HinhAnh hinhAnh = db.HinhAnhs.Find(ID);
            if (hinhAnh == null)
            {
                return HttpNotFound();
            }
            else
            {
                return File(hinhAnh.Image, "image/jpg");
            }
        }
    }
}
