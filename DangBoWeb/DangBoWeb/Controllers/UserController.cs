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
        private string _mnu = "mnuNguoiDung";
        public void getListForCombobox()
        {
            ViewBag.lstNhom = new SelectList(_db.Nhoms, "MaNhom", "TenNhom");
        }

        // GET: User
        public async Task<ActionResult> Index()
        {
            if (CUserSession.CheckQuyen(_mnu, "Xem") == false)
                return RedirectToAction("PermissionDenied", "User");
            return View(await _db.Users.OrderBy(item => item.MaU).ToListAsync());
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
        public async Task<ActionResult> Create(User model)
        {
            if (CUserSession.CheckQuyen(_mnu, "Them") == false)
                return RedirectToAction("PermissionDenied", "User");
            if (ModelState.IsValid)
            {
                if (_db.Users.Any(item => item.TaiKhoan == model.TaiKhoan) == true)
                {
                    ModelState.AddModelError("TaiKhoan", "Tài Khoản đã tồn tại");
                    return View(model);
                }
                model.MaU = _db.Users.Max(item => item.MaU) + 1;
                model.CreateBy = CUserSession.getUserSession().MaU;
                model.CreateDate = DateTime.Now;
                ///tự động thêm quyền cho người mới
                foreach (var item in _db.Menus.ToList())
                {
                    PhanQuyenNguoiDung phanquyennguoidung = new PhanQuyenNguoiDung();
                    phanquyennguoidung.MaMenu = item.MaMenu;
                    phanquyennguoidung.MaND = model.MaU;
                    model.PhanQuyenNguoiDungs.Add(phanquyennguoidung);
                }
                _db.Users.Add(model);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return View(model);
        }

        public async Task<ActionResult> Edit(int? MaU)
        {
            if (CUserSession.CheckQuyen(_mnu, "Sua") == false)
                return RedirectToAction("PermissionDenied", "User");
            getListForCombobox();
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
            if (CUserSession.CheckQuyen(_mnu, "Sua") == false)
                return RedirectToAction("PermissionDenied", "User");
            if (ModelState.IsValid)
            {
                model.ModifyBy = CUserSession.getUserSession().MaU;
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

        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(DangNhapModel model)
        {
            User user = _db.Users.SingleOrDefault(item => item.TaiKhoan == model.TaiKhoan && item.MatKhau == model.MatKhau);
            if (user != null && ModelState.IsValid)
            {
                DangNhapModel en = new DangNhapModel();
                en.MaU = user.MaU;
                en.HoTen = user.HoTen;
                en.Admin = user.Admin;
                if (user.MaNhom != null)
                    en.dtQuyenNhom = CDAL.getDS_PhanQuyenNhom(user.MaNhom.Value);
                en.dtQuyenNguoiDung = CDAL.getDS_PhanQuyenNguoiDung(user.MaU);
                CUserSession.setUserSession(en);
                Session.Add("UserSession", CUserSession.getUserSession());
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tài Khoản hoặc Mật Khẩu không đúng");
            }
            return View(user);
        }

        public ActionResult DoiMatKhau()
        {
            if (CUserSession.checkExistsUserSession() == false)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public ActionResult DoiMatKhau(DoiMatKhauModel en)
        {
            int id = CUserSession.getMaUserSession();
            User user = _db.Users.SingleOrDefault(item => item.MaU == id);
            if (user != null)
            {
                user.MatKhau = en.MatKhauMoi;
                user.ModifyBy = CUserSession.getMaUserSession();
                user.ModifyDate = DateTime.Now;
                _db.SaveChangesAsync();
                return RedirectToAction("DangXuat", "User");
            }
            ModelState.AddModelError("", "Lỗi");
            return View();
        }

        public ActionResult DangXuat()
        {
            CUserSession.removeUserSession();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult PermissionDenied()
        {
            return View();
        }

        public async Task<ActionResult> UpdateMenu()
        {
            string[] lstTenMenu = new string[] { "mnuNhom", "mnuNguoiDung","mnuDonVi","mnuLoaiCongVan", "mnuCongVanDen", "mnuCongVanDi" };
            string[] lstTextMenu = new string[] { "Nhóm", "Người Dùng","Đơn Vị","Loại Công Văn", "Công Văn Đến", "Công Văn Đi" };
            int STT = 1;
            for (int i = 0; i < lstTenMenu.Count(); i++)
            {

                string tmp = lstTenMenu[i];
                if (_db.Menus.Any(item => item.TenMenu == tmp) == false)
                {
                    Menu menu = new Menu();
                    menu.STT = STT++;
                    menu.TenMenu = tmp;
                    menu.TextMenu = lstTextMenu[i];
                    foreach (var item in _db.Nhoms.ToList())
                    {
                        PhanQuyenNhom phanquyennhom = new PhanQuyenNhom();
                        phanquyennhom.MaMenu = menu.MaMenu;
                        phanquyennhom.MaNhom = item.MaNhom;
                        phanquyennhom.CreateBy = CUserSession.getUserSession().MaU;
                        phanquyennhom.CreateDate = DateTime.Now;
                        menu.PhanQuyenNhoms.Add(phanquyennhom);
                    }
                    foreach (var item in _db.Users.ToList())
                    {
                        PhanQuyenNguoiDung phanquyennguoidung = new PhanQuyenNguoiDung();
                        phanquyennguoidung.MaMenu = menu.MaMenu;
                        phanquyennguoidung.MaND = item.MaU;
                        phanquyennguoidung.CreateBy = CUserSession.getUserSession().MaU;
                        phanquyennguoidung.CreateDate = DateTime.Now;
                        if (item.MaU == 0)
                        {
                            phanquyennguoidung.Xem = true;
                            phanquyennguoidung.Them = true;
                            phanquyennguoidung.Sua = true;
                            phanquyennguoidung.Xoa = true;
                        }
                        menu.PhanQuyenNguoiDungs.Add(phanquyennguoidung);
                    }
                    //insert db
                    if (_db.Menus.Count() > 0)
                        menu.MaMenu = _db.Menus.Max(item => item.MaMenu) + 1;
                    else
                        menu.MaMenu = 1;
                    menu.CreateBy = CUserSession.getUserSession().MaU;
                    menu.CreateDate = DateTime.Now;
                    _db.Menus.Add(menu);
                    await _db.SaveChangesAsync();
                }
                else
                {
                    Menu menu = _db.Menus.SingleOrDefault(item => item.TenMenu == tmp);
                    menu.STT = STT++;
                    menu.ModifyBy = CUserSession.getUserSession().MaU;
                    menu.ModifyDate = DateTime.Now;
                    await _db.SaveChangesAsync();
                }
            }
            return RedirectToAction("Index", "Home");
        }


    }
}