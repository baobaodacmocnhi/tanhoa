
using DangBoWeb.LinQ;
using DangBoWeb.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DangBoWeb.Controllers
{
    public class UserController : Controller
    {
        private dbDangBo _db = new dbDangBo();
        // GET: User
        public async Task<ActionResult> Index()
        {
            return View(await _db.Users.OrderBy(item=>item.MaU).ToListAsync());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(User model)
        {
            if (ModelState.IsValid)
            {
                if (_db.Users.Any(item => item.TaiKhoan == model.TaiKhoan) == true)
                {
                    ModelState.AddModelError("TaiKhoan", "Tài Khoản đã tồn tại");
                    return View(model);
                }
                model.MaU = _db.Users.Max(item => item.MaU) + 1;
                model.CreateBy = CUserSession.getUser().MaU;
                model.CreateDate = DateTime.Now;
                _db.Users.Add(model);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return View(model);
        }

        public async Task<ActionResult> Edit(int? MaU)
        {
            if (MaU == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User model = await _db.Users.FindAsync(MaU);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(User model)
        {
            if (ModelState.IsValid)
            {
                model.ModifyBy = CUserSession.getUser().MaU;
                model.ModifyDate = DateTime.Now;
                _db.Entry(model).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(User model)
        {
            User user = _db.Users.SingleOrDefault(item => item.TaiKhoan == model.TaiKhoan && item.MatKhau == model.MatKhau);
            if (user != null && ModelState.IsValid)
            {
                CUserSession.setUser(new CUserSessionChild() { MaU = user.MaU, HoTen = user.HoTen });
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tài Khoản hoặc Mật Khẩu không đúng");
            }
            return View(user);
        }
    }
}