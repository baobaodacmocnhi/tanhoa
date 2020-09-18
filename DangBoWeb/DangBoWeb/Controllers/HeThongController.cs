using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DangBoWeb.Models;

namespace DangBoWeb.Controllers
{
    public class HeThongController : Controller
    {
        // GET: HeThong
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(User en)
        {
            return View();
        }

        public ActionResult DoiMatKhau()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoiMatKhau(DoiMatKhau en)
        {
            return View();
        }

        public ActionResult DangXuat()
        {
            return View();
        }
    }
}