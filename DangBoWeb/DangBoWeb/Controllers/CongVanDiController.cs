using DangBoWeb.LinQ;
using DangBoWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DangBoWeb.Controllers
{
    public class CongVanDiController : BaseController
    {
        private dbDangBo _db = new dbDangBo();
        private string _mnu = "mnuCongVanDi";

        public void getListForCombobox()
        {
            ViewBag.lstDonVi = new SelectList(_db.DonVis, "ID", "TenDonVi");
            ViewBag.lstLoaiCV = new SelectList(_db.LoaiCongVans, "ID", "LoaiCV");
        }

        // GET: CongVanDi
        public async Task<ActionResult> Index()
        {
            if (CUserSession.CheckQuyen(_mnu, "Xem") == false)
                return RedirectToAction("PermissionDenied", "User");
            return View(await _db.CongVanDis.OrderByDescending(item => item.CreateDate).ToListAsync());
        }

        public ActionResult Create()
        {
            if (CUserSession.CheckQuyen(_mnu, "Them") == false)
                return RedirectToAction("PermissionDenied", "User");
            getListForCombobox();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CongVanDi model)
        {
            if (CUserSession.CheckQuyen(_mnu, "Them") == false)
                return RedirectToAction("PermissionDenied", "User");
            if (ModelState.IsValid || model.HetHan == true)
            {
                if (_db.CongVanDis.Count() > 0)
                    model.ID = _db.CongVanDis.Max(item => item.ID) + 1;
                else
                    model.ID = 1;
                if (model.HetHan == true)
                    if (model.NgayHetHan == null)
                    {
                        getListForCombobox();
                        ModelState.AddModelError("NgayHetHan", "Thiếu Ngày Hết Hạn");
                        return View(model);
                    }
                model.CreateBy = CUserSession.getMaUserSession();
                model.CreateDate = DateTime.Now;
                _db.CongVanDis.Add(model);
                await _db.SaveChangesAsync();
                if (Request.Files.Count > 0)
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                        if (Request.Files[i] != null && Request.Files[i].ContentLength > 0)
                        {
                            CongVanDi_Hinh en = new CongVanDi_Hinh();
                            if (_db.CongVanDi_Hinh.Count() == 0)
                                en.ID = 1;
                            else
                                en.ID = _db.CongVanDi_Hinh.Max(item => item.ID) + 1;
                            en.IDCongVanDi = model.ID;
                            en.FileName = Path.GetFileName(Request.Files[i].FileName);
                            en.ContentType = Request.Files[i].ContentType;
                            en.FileExtention = Path.GetExtension(Request.Files[i].FileName);
                            en.FileSize = Request.Files[i].ContentLength;
                            BinaryReader br = new BinaryReader(Request.Files[i].InputStream);
                            byte[] buffer = br.ReadBytes(Request.Files[i].ContentLength);
                            en.FileContent = buffer;
                            en.CreateBy = CUserSession.getMaUserSession();
                            en.CreateDate = DateTime.Now;
                            _db.CongVanDi_Hinh.Add(en);
                            await _db.SaveChangesAsync();
                        }
                }
                return RedirectToAction("Index");
            }
            else
                return Create();
        }

        [HttpPost]
        public JsonResult getSoCV(int IDDonVi, int IDLoaiCV)
        {
            NhiemKy nhiemky = _db.NhiemKies.OrderByDescending(item => item.CreateDate).First();
            LoaiCongVan loaiCV = _db.LoaiCongVans.SingleOrDefault(item => item.ID == IDLoaiCV);
            DonVi donvi = _db.DonVis.SingleOrDefault(item => item.ID == IDDonVi);
            int id = -1;
            if (_db.CongVanDis.Any(item => item.IDLoaiCV == IDLoaiCV && DbFunctions.TruncateTime(item.CreateDate.Value) >= DbFunctions.TruncateTime(nhiemky.TuNgay.Value)) == true)
                id = _db.CongVanDis.Where(item => item.IDLoaiCV == IDLoaiCV && DbFunctions.TruncateTime(item.CreateDate.Value) >= DbFunctions.TruncateTime(nhiemky.TuNgay.Value)).Max(item => item.SoCV1).Value + 1;
            else
                id = 1;
            return Json(new { SoCV1 = id, SoCV = id + "-" + loaiCV.KyHieu + "/" + donvi.KyHieu }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Edit(int? ID)
        {
            if (CUserSession.CheckQuyen(_mnu, "Sua") == false)
                return RedirectToAction("PermissionDenied", "User");
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            getListForCombobox();
            CongVanDi model = await _db.CongVanDis.FindAsync(ID);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CongVanDi model)
        {
            if (CUserSession.CheckQuyen(_mnu, "Sua") == false)
                return RedirectToAction("PermissionDenied", "User");
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                        if (Request.Files[i] != null && Request.Files[i].ContentLength > 0)
                        {
                            CongVanDi_Hinh en = new CongVanDi_Hinh();
                            if (_db.CongVanDi_Hinh.Count() == 0)
                                en.ID = 1;
                            else
                                en.ID = _db.CongVanDi_Hinh.Max(item => item.ID) + 1;
                            en.IDCongVanDi = model.ID;
                            en.FileName = Path.GetFileName(Request.Files[i].FileName);
                            en.ContentType = Request.Files[i].ContentType;
                            en.FileExtention = Path.GetExtension(Request.Files[i].FileName);
                            en.FileSize = Request.Files[i].ContentLength;
                            BinaryReader br = new BinaryReader(Request.Files[i].InputStream);
                            byte[] buffer = br.ReadBytes(Request.Files[i].ContentLength);
                            en.FileContent = buffer;
                            en.CreateBy = CUserSession.getMaUserSession();
                            en.CreateDate = DateTime.Now;
                            _db.CongVanDi_Hinh.Add(en);
                            await _db.SaveChangesAsync();
                        }
                }
                if (model.HetHan == false)
                    model.NgayHetHan = null;
                model.ModifyBy = CUserSession.getMaUserSession();
                model.ModifyDate = DateTime.Now;
                _db.Entry(model).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (CUserSession.CheckQuyen(_mnu, "Xoa") == false)
                return RedirectToAction("PermissionDenied", "User");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CongVanDi model = await _db.CongVanDis.FindAsync(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            else
            {
                _db.CongVanDi_Hinh.RemoveRange(model.CongVanDi_Hinh.ToList());
                _db.CongVanDis.Remove(model);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult downloadFile(int ID)
        {
            CongVanDi_Hinh en = _db.CongVanDi_Hinh.SingleOrDefault(item => item.ID == ID);
            if (en != null)
                return File(en.FileContent, en.FileExtention, en.FileName);
            else
                return null;
        }

        public ActionResult viewFile(int ID)
        {
            CongVanDi_Hinh en = _db.CongVanDi_Hinh.SingleOrDefault(item => item.ID == ID);
            if (en != null)
                return new FileStreamResult(new MemoryStream(en.FileContent), en.ContentType);
            else
                return null;
        }

        public async Task<ActionResult> deleteFile(int ID)
        {
            if (CUserSession.CheckQuyen(_mnu, "Xoa") == false)
                return RedirectToAction("PermissionDenied", "User");
            CongVanDi_Hinh en = _db.CongVanDi_Hinh.SingleOrDefault(item => item.ID == ID);
            int IDCongVanDen = en.IDCongVanDi.Value;
            _db.CongVanDi_Hinh.Remove(en);
            await _db.SaveChangesAsync();
            return RedirectToAction("Edit", "CongVanDi", new { ID = IDCongVanDen });
        }
    }
}