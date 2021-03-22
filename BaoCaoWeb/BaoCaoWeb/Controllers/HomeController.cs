using BaoCaoWeb.DAL;
using BaoCaoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaoCaoWeb.Controllers
{
    public class HomeController : Controller
    {
        cDHN _cDHN = new cDHN();
        cDocSo _cDocSo = new cDocSo();
        cThuTien _cThuTien = new cThuTien();

        public ActionResult Index()
        {
            ThongTin en = new ThongTin();
            en.TongKhachHang = decimal.Parse(_cDHN.ExecuteQuery_ReturnOneValue("select count(DanhBo) from TB_DULIEUKHACHHANG").ToString());
            en.TongSanLuong = decimal.Parse(_cDocSo.ExecuteQuery_ReturnOneValue("select SUM(TieuThuMoi) from DocSo where Nam=" + DateTime.Now.Year).ToString());
            en.TongDoanhThu = decimal.Parse(_cThuTien.ExecuteQuery_ReturnOneValue("select SUM(TONGCONG) from HOADON where YEAR(NGAYGIAITRACH)=" + DateTime.Now.Year + " and MaNV_DangNgan is not null").ToString());
            return View(en);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}