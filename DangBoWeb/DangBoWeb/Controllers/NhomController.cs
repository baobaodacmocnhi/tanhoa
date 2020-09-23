using DangBoWeb.LinQ;
using DangBoWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DangBoWeb.Controllers
{
    public class NhomController : BaseController
    {
        private dbDangBo _db = new dbDangBo();
        private string _mnu = "mnuNhom";

        // GET: Nhom
        public async Task<ActionResult> Index()
        {
            if (CUserSession.CheckQuyen(_mnu, "Xem") == false)
                return RedirectToAction("PermissionDenied", "User");
            return View(await _db.Nhoms.ToListAsync());
        }

        public ActionResult Create()
        {
            if (CUserSession.CheckQuyen(_mnu, "Them") == false)
                return RedirectToAction("PermissionDenied", "User");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Nhom model)
        {
            if (CUserSession.CheckQuyen(_mnu, "Them") == false)
                return RedirectToAction("PermissionDenied", "User");
            if (ModelState.IsValid)
            {
                if (_db.Nhoms.Count() > 0)
                    model.MaNhom = _db.Nhoms.Max(item => item.MaNhom) + 1;
                else
                    model.MaNhom = 1;
                foreach (var item in _db.Menus.ToList())
                {
                    PhanQuyenNhom phanquyennhom = new PhanQuyenNhom();
                    phanquyennhom.MaMenu = item.MaMenu;
                    phanquyennhom.MaNhom = model.MaNhom;
                    model.PhanQuyenNhoms.Add(phanquyennhom);
                }
                model.CreateBy = CUserSession.getMaUserSession();
                model.CreateDate = DateTime.Now;
                _db.Nhoms.Add(model);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return Create();
        }

        public async Task<ActionResult> Edit(int? ID)
        {
            if (CUserSession.CheckQuyen(_mnu, "Sua") == false)
                return RedirectToAction("PermissionDenied", "User");
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nhom model = await _db.Nhoms.FindAsync(ID);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Nhom model)
        {
            if (CUserSession.CheckQuyen(_mnu, "Sua") == false)
                return RedirectToAction("PermissionDenied", "User");
            if (ModelState.IsValid)
            {
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
            Nhom model = await _db.Nhoms.FindAsync(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            else
            {
                _db.Nhoms.Remove(model);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


    }
}