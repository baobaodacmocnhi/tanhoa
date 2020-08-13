using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DangBoWeb.LinQ;
using DangBoWeb.Models;

namespace DangBoWeb.Controllers
{
    public class CongVanDisController : Controller
    {
        private dbDangBo db = new dbDangBo();

        // GET: CongVanDis
        public ActionResult Index()
        {
            var congVanDis = db.CongVanDis.Include(c => c.DonVi).Include(c => c.LoaiCongVan);
            return View(congVanDis.ToList());
        }

        // GET: CongVanDis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongVanDi congVanDi = db.CongVanDis.Find(id);
            if (congVanDi == null)
            {
                return HttpNotFound();
            }
            return View(congVanDi);
        }

        // GET: CongVanDis/Create
        public ActionResult Create()
        {
            ViewBag.IDDonVi = new SelectList(db.DonVis, "ID", "TenDonVi");
            ViewBag.IDLoaiCV = new SelectList(db.LoaiCongVans, "ID", "LoaiCV");
            return View();
        }

        // POST: CongVanDis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDDonVi,IDLoaiCV,SoCV,TieuDe,NoiDung,Mat,Khan,HetHan,NgayHetHan,CreateBy,CreateDate,ModifyBy,ModifyDate")] CongVanDi congVanDi)
        {
            if (ModelState.IsValid)
            {
                db.CongVanDis.Add(congVanDi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDDonVi = new SelectList(db.DonVis, "ID", "TenDonVi", congVanDi.IDDonVi);
            ViewBag.IDLoaiCV = new SelectList(db.LoaiCongVans, "ID", "LoaiCV", congVanDi.IDLoaiCV);
            return View(congVanDi);
        }

        // GET: CongVanDis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongVanDi congVanDi = db.CongVanDis.Find(id);
            if (congVanDi == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDDonVi = new SelectList(db.DonVis, "ID", "TenDonVi", congVanDi.IDDonVi);
            ViewBag.IDLoaiCV = new SelectList(db.LoaiCongVans, "ID", "LoaiCV", congVanDi.IDLoaiCV);
            return View(congVanDi);
        }

        // POST: CongVanDis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDDonVi,IDLoaiCV,SoCV,TieuDe,NoiDung,Mat,Khan,HetHan,NgayHetHan,CreateBy,CreateDate,ModifyBy,ModifyDate")] CongVanDi congVanDi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(congVanDi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDDonVi = new SelectList(db.DonVis, "ID", "TenDonVi", congVanDi.IDDonVi);
            ViewBag.IDLoaiCV = new SelectList(db.LoaiCongVans, "ID", "LoaiCV", congVanDi.IDLoaiCV);
            return View(congVanDi);
        }

        // GET: CongVanDis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongVanDi congVanDi = db.CongVanDis.Find(id);
            if (congVanDi == null)
            {
                return HttpNotFound();
            }
            return View(congVanDi);
        }

        // POST: CongVanDis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CongVanDi congVanDi = db.CongVanDis.Find(id);
            db.CongVanDis.Remove(congVanDi);
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
