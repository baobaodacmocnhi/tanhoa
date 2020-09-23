using DangBoWeb.LinQ;
using DangBoWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DangBoWeb.Controllers
{
    public class DonViController : BaseController
    {
        private dbDangBo _db = new dbDangBo();
        private string _mnu = "mnuDonVi";

        // GET: DonVi
        public async Task<ActionResult> Index()
        {
            if (CUserSession.CheckQuyen(_mnu, "Xem") == false)
                return RedirectToAction("PermissionDenied", "User");
            return View(await _db.DonVis.ToListAsync());
        }

        public ActionResult Create()
        {
            if (CUserSession.CheckQuyen(_mnu, "Them") == false)
                return RedirectToAction("PermissionDenied", "User");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DonVi model)
        {
            if (CUserSession.CheckQuyen(_mnu, "Them") == false)
                return RedirectToAction("PermissionDenied", "User");
            if (ModelState.IsValid)
            {
                if (_db.DonVis.Count() > 0)
                    model.ID = _db.DonVis.Max(item => item.ID) + 1;
                else
                    model.ID = 1;
                model.CreateBy = CUserSession.getMaUserSession();
                model.CreateDate = DateTime.Now;
                _db.DonVis.Add(model);
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
            DonVi model = await _db.DonVis.FindAsync(ID);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(DonVi model)
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
            DonVi model = await _db.DonVis.FindAsync(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            else
            {
                _db.DonVis.Remove(model);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}