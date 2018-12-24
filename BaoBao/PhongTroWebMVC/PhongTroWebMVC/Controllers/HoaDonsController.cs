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
    public class HoaDonsController : Controller
    {
        private dbPhongTro db = new dbPhongTro();

        // GET: HoaDons
        public ActionResult Index()
        {
            var hoaDons = db.HoaDons.Include(h => h.Phong);
            return View(hoaDons.ToList());
        }

        // GET: HoaDons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // GET: HoaDons/Create
        public ActionResult Create()
        {
            ViewBag.IDPhong = new SelectList(db.Phongs, "ID", "Name");
            return View();
        }

        // POST: HoaDons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPhong,ChiSoDienNew,ChiSoNuocNew")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                int SoNKDien = db.KhachHangs.Count(item => item.IDPhong == hoaDon.IDPhong && item.Thue == true);
                int ChiSoDienOld = db.Phongs.SingleOrDefault(item => item.ID == hoaDon.IDPhong).ChiSoDien.Value;
                int TieuThuDien = hoaDon.ChiSoDienNew.Value - ChiSoDienOld;
                if (TieuThuDien <= 0)
                    return View(hoaDon);

                string ChiTietDien = "";
                int TienDien = TinhTienDien(SoNKDien, TieuThuDien, out ChiTietDien);

                int DinhMucNuoc = db.Phongs.SingleOrDefault(item => item.ID == hoaDon.IDPhong).SoNKNuoc.Value * 4;
                int ChiSoNuocOld = db.Phongs.SingleOrDefault(item => item.ID == hoaDon.IDPhong).ChiSoNuoc.Value;
                int TieuThuNuoc = hoaDon.ChiSoNuocNew.Value - ChiSoNuocOld;
                if (TieuThuNuoc <= 0)
                    return View(hoaDon);

                string ChiTietNuoc = "";
                int TienNuoc = TinhTienNuoc(DinhMucNuoc, TieuThuNuoc, out ChiTietNuoc);

                if (db.HoaDons.Count() == 0)
                    hoaDon.ID = 1;
                else
                    hoaDon.ID = db.HoaDons.Max(item => item.ID) + 1;

                hoaDon.ChiSoDienOld = ChiSoDienOld;
                hoaDon.TieuThuDien = TieuThuDien;
                hoaDon.TienDien = TienDien;
                hoaDon.ChiTietDien = ChiTietDien;

                hoaDon.ChiSoNuocOld = ChiSoNuocOld;
                hoaDon.TieuThuNuoc = TieuThuNuoc;
                hoaDon.TienNuoc = TienNuoc;
                hoaDon.ChiTietNuoc = ChiTietNuoc;

                hoaDon.CreateDate = DateTime.Now;
                db.HoaDons.Add(hoaDon);

                hoaDon.Phong.ChiSoDienOld = hoaDon.Phong.ChiSoDien;
                hoaDon.Phong.ChiSoNuocOld = hoaDon.Phong.ChiSoNuoc;
                hoaDon.Phong.ChiSoDien = hoaDon.ChiSoDienNew;
                hoaDon.Phong.ChiSoNuoc = hoaDon.ChiSoNuocNew;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDPhong = new SelectList(db.Phongs, "ID", "Name", hoaDon.IDPhong);
            return View(hoaDon);
        }

        // GET: HoaDons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDPhong = new SelectList(db.Phongs, "ID", "Name", hoaDon.IDPhong);
            return View(hoaDon);
        }

        // POST: HoaDons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPhong,ChiSoDienOld,ChiSoDienNew,TieuThuDien,TienDien,ChiTietDien,ChiSoNuocOld,ChiSoNuocNew,TieuThuNuoc,TienNuoc,ChiTietNuoc")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                hoaDon.ModifyDate = DateTime.Now;
                db.Entry(hoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDPhong = new SelectList(db.Phongs, "ID", "Name", hoaDon.IDPhong);
            return View(hoaDon);
        }

        // GET: HoaDons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            else
            {
                hoaDon.Phong.ChiSoDien = hoaDon.Phong.ChiSoDienOld;
                hoaDon.Phong.ChiSoDienOld = 0;
                hoaDon.Phong.ChiSoNuoc = hoaDon.Phong.ChiSoNuocOld;
                hoaDon.Phong.ChiSoNuocOld = 0;
                db.HoaDons.Remove(hoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hoaDon);
        }

        // POST: HoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
            db.HoaDons.Remove(hoaDon);
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

        public int TinhTienDien(int SoNKDien, int TieuThu, out string ChiTiet)
        {
            int B1 = (int)Math.Round(50 * ((double)SoNKDien / 4), 1);
            int B2 = (int)Math.Round(100 * ((double)SoNKDien / 4), 1);
            int B3 = (int)Math.Round(200 * ((double)SoNKDien / 4), 1);
            int B4 = (int)Math.Round(300 * ((double)SoNKDien / 4), 1);
            int B5 = (int)Math.Round(400 * ((double)SoNKDien / 4), 1);

            List<GiaDien> dtGiaDien = db.GiaDiens.ToList();
            int TienDien = 0;
            ChiTiet = "";
            if (TieuThu <= B1)
            {
                TienDien = TieuThu * (int)dtGiaDien[0].GiaTien;
                ChiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int)dtGiaDien[0].GiaTien);
            }
            else
                if (B1 < TieuThu && TieuThu <= B2)
            {
                TienDien = (B1 * (int)dtGiaDien[0].GiaTien) + ((TieuThu - B1) * (int)dtGiaDien[1].GiaTien);
                ChiTiet = B1 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int)dtGiaDien[0].GiaTien) + "\r\n"
                        + (TieuThu - B1).ToString() + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int)dtGiaDien[1].GiaTien);
            }
            else
                    if (B2 < TieuThu && TieuThu <= B3)
            {
                TienDien = (B1 * (int)dtGiaDien[0].GiaTien) + (B2 * (int)dtGiaDien[1].GiaTien) + ((TieuThu - 100) * (int)dtGiaDien[2].GiaTien);
                ChiTiet = B1 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int)dtGiaDien[0].GiaTien) + "\r\n"
                        + B2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int)dtGiaDien[1].GiaTien) + "\r\n"
                        + (TieuThu - B2).ToString() + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int)dtGiaDien[2].GiaTien);
            }
            else
                        if (B3 < TieuThu && TieuThu <= B4)
            {
                TienDien = (B1 * (int)dtGiaDien[0].GiaTien) + (B2 * (int)dtGiaDien[1].GiaTien) + (B3 * (int)dtGiaDien[2].GiaTien) + ((TieuThu - B3) * (int)dtGiaDien[3].GiaTien);
                ChiTiet = B1 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int)dtGiaDien[0].GiaTien) + "\r\n"
                        + B2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int)dtGiaDien[1].GiaTien) + "\r\n"
                        + B3 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int)dtGiaDien[2].GiaTien) + "\r\n"
                        + (TieuThu - B3).ToString() + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int)dtGiaDien[3].GiaTien);
            }
            else
                            if (B3 < TieuThu && TieuThu <= B5)
            {
                TienDien = (B1 * (int)dtGiaDien[0].GiaTien) + (B2 * (int)dtGiaDien[1].GiaTien) + (B3 * (int)dtGiaDien[2].GiaTien) + (B4 * (int)dtGiaDien[3].GiaTien) + ((TieuThu - B4) * (int)dtGiaDien[4].GiaTien);
                ChiTiet = B1 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int)dtGiaDien[0].GiaTien) + "\r\n"
                        + B2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int)dtGiaDien[1].GiaTien) + "\r\n"
                        + B3 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int)dtGiaDien[2].GiaTien) + "\r\n"
                        + B4 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int)dtGiaDien[3].GiaTien) + "\r\n"
                        + (TieuThu - B4).ToString() + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int)dtGiaDien[4].GiaTien);
            }
            else
                                if (B4 < TieuThu)
            {
                TienDien = (B1 * (int)dtGiaDien[0].GiaTien) + (B2 * (int)dtGiaDien[1].GiaTien) + (B3 * (int)dtGiaDien[2].GiaTien) + (B4 * (int)dtGiaDien[3].GiaTien) + (B5 * (int)dtGiaDien[4].GiaTien) + ((TieuThu - B5) * (int)dtGiaDien[5].GiaTien);
                ChiTiet = B1 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int)dtGiaDien[0].GiaTien) + "\r\n"
                         + B2 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int)dtGiaDien[1].GiaTien) + "\r\n"
                         + B3 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int)dtGiaDien[2].GiaTien) + "\r\n"
                         + B4 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int)dtGiaDien[3].GiaTien) + "\r\n"
                         + B5 + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int)dtGiaDien[4].GiaTien) + "\r\n"
                         + (TieuThu - B5).ToString() + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int)dtGiaDien[5].GiaTien);
            }

            TienDien = (int)(TienDien * 1.10);
            ChiTiet += "\r\nThuế 10% " + ((int)(TienDien * 0.10)).ToString();
            ///tỷ lệ hao hụt
            TienDien += (int)Math.Round(TienDien * double.Parse(dtGiaDien[6].GiaTien.ToString()) / 100);
            ChiTiet += "\r\nTỷ lệ hao hụt " + dtGiaDien[6].GiaTien.ToString() + "% " + (int)Math.Round(TienDien * double.Parse(dtGiaDien[6].GiaTien.ToString()) / 100);
            return TienDien;
        }

        public int TinhTienNuoc(int DinhMuc, int TieuThu, out string ChiTiet)
        {
            List<GiaNuoc> dtGiaNuoc = db.GiaNuocs.ToList();
            int TienNuoc = 0;
            if (TieuThu <= DinhMuc)
            {
                TienNuoc = (TieuThu * (int)dtGiaNuoc[0].GiaTien);

                ChiTiet = TieuThu + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int)dtGiaNuoc[0].GiaTien);
            }
            else
            {
                if (TieuThu - DinhMuc <= Math.Round((double)DinhMuc / 2))
                {
                    TienNuoc = (DinhMuc * (int)dtGiaNuoc[0].GiaTien)
                            + (TieuThu - (int)Math.Round((double)DinhMuc / 2) * (int)dtGiaNuoc[1].GiaTien);

                    ChiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int)dtGiaNuoc[0].GiaTien) + "\r\n"
                               + (TieuThu - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int)dtGiaNuoc[1].GiaTien);
                }
                else
                {
                    TienNuoc = (DinhMuc * (int)dtGiaNuoc[0].GiaTien)
                            + ((int)Math.Round((double)DinhMuc / 2) * (int)dtGiaNuoc[1].GiaTien)
                            + ((TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) * (int)dtGiaNuoc[2].GiaTien);

                    ChiTiet = DinhMuc + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int)dtGiaNuoc[0].GiaTien) + "\r\n"
                               + (int)Math.Round((double)DinhMuc / 2) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int)dtGiaNuoc[1].GiaTien) + "\r\n"
                               + (TieuThu - DinhMuc - (int)Math.Round((double)DinhMuc / 2)) + " x " + String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", (int)dtGiaNuoc[2].GiaTien);
                }
            }

            TienNuoc = (int)(TienNuoc * 1.15);
            ChiTiet += "\r\nThuế 15% " + ((int)(TienNuoc * 0.15)).ToString();
            TienNuoc += (int)Math.Round(TienNuoc * double.Parse(dtGiaNuoc[3].GiaTien.ToString()) / 100);
            ChiTiet += "\r\nTỷ lệ hao hụt " + dtGiaNuoc[3].GiaTien.ToString() + "% " + (int)Math.Round(TienNuoc * double.Parse(dtGiaNuoc[3].GiaTien.ToString()) / 100);
            return TienNuoc;
        }
    }
}
