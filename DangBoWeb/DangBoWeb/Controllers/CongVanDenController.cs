using DangBoWeb.DAL;
using DangBoWeb.Database;
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
    public class CongVanDenController : Controller
    {
        private dbDangBo _db = new dbDangBo();
        // GET: CongVanDen
        public async Task<ActionResult> Index()
        {
            return View(await _db.CongVanDens.OrderBy(item => item.ID).ToListAsync());
        }

        public ActionResult Create()
        {
            ViewBag.lstDonVi = new SelectList(_db.DonVis, "ID", "TenDonVi");
            ViewBag.lstLoaiCV = new SelectList(_db.LoaiCongVans, "ID", "LoaiCV");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CongVanDen model)
        {
            if (ModelState.IsValid)
            {
                model.ID = _db.CongVanDens.Max(item => item.ID) + 1;
                //model.CreateBy = CUserSession.getUser().MaU;
                model.CreateDate = DateTime.Now;
                _db.CongVanDens.Add(model);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return View(model);
        }

        public async Task<ActionResult> Edit(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.lstDonVi = new SelectList(_db.DonVis, "ID", "TenDonVi");
            ViewBag.lstLoaiCV = new SelectList(_db.LoaiCongVans, "ID", "LoaiCV");
            CongVanDen model = await _db.CongVanDens.FindAsync(ID);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CongVanDen model)
        {
            if (ModelState.IsValid)
            {
                //model.ModifyBy = CUserSession.getUser().MaU;
                model.ModifyDate = DateTime.Now;
                _db.Entry(model).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}