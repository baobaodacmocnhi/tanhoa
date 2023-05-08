using BaoCaoWeb.DAL;
using BaoCaoWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace BaoCaoWeb.Controllers
{
    public class HomeController : Controller
    {
        cDHN _cDHN = new cDHN();
        cDocSo _cDocSo = new cDocSo();
        cThuTien _cThuTien = new cThuTien();
        cTTKH _cTTKH = new cTTKH();
        public ActionResult Index()
        {
            ThongTin enTT = new ThongTin();
            enTT.NamPresent = DateTime.Now.Year;
            enTT.NamPrevious = DateTime.Now.Year - 1;
            enTT.KhachHang = decimal.Parse(_cDHN.ExecuteQuery_ReturnOneValue("select count(DanhBo) from TB_DULIEUKHACHHANG").ToString());
            enTT.SanLuong = decimal.Parse(_cDocSo.ExecuteQuery_ReturnOneValue("select SUM(TieuThuMoi) from DocSo where Nam=" + enTT.NamPresent).ToString());
            enTT.DoanhThu = decimal.Parse(_cThuTien.ExecuteQuery_ReturnOneValue("select SUM(TONGCONG) from HOADON where YEAR(NGAYGIAITRACH)=" + enTT.NamPresent + " and MaNV_DangNgan is not null").ToString());
            enTT.lstSanLuong = getlstSanLuong();
            enTT.lstDoanhThu = getlstDoanhThu();
            enTT.lstGiaBanBinhQuan = getlstGiaBanBinhQuan();
            enTT.ThatThoatNuoc = (double)_cTTKH.ExecuteQuery_ReturnOneValue("select TyLeThatThoatNuoc2 from BC_SoLieu where Nam=2022");
            return View(enTT);
        }

        //public ActionResult Index()
        //{
        //    ThongTin enTT = new ThongTin();
        //    enTT.NamPresent = DateTime.Now.Year;
        //    enTT.NamPrevious = DateTime.Now.Year - 1;
        //    enTT.KhachHang = decimal.Parse(_cDHN.ExecuteQuery_ReturnOneValue("select count(DanhBo) from TB_DULIEUKHACHHANG").ToString());
        //    enTT.SanLuong = decimal.Parse(_cDocSo.ExecuteQuery_ReturnOneValue("select SUM(TieuThuMoi) from DocSo where Nam=" + enTT.NamPresent).ToString());
        //    enTT.DoanhThu = decimal.Parse(_cThuTien.ExecuteQuery_ReturnOneValue("select SUM(TONGCONG) from HOADON where YEAR(NGAYGIAITRACH)=" + enTT.NamPresent + " and MaNV_DangNgan is not null").ToString());
        //    enTT.lstSanLuong = getlstSanLuong();
        //    enTT.lstDoanhThu = getlstDoanhThu();
        //    enTT.lstGiaBanBinhQuan = getlstGiaBanBinhQuan();
        //    enTT.ThatThoatNuoc = (double)_cTTKH.ExecuteQuery_ReturnOneValue("select TyLeThatThoatNuoc2 from BC_SoLieu where Nam=2022");
        //    return View(enTT);
        //}

        public ActionResult IndexChiTieu()
        {
            ThongTin enTT = new ThongTin();
            enTT.NamPresent = DateTime.Now.Year;
            enTT.NamPrevious = DateTime.Now.Year - 1;
            DataTable dtKeHoach = _cTTKH.ExecuteQuery_DataTable("select * from BC_KeHoach where Nam=" + enTT.NamPresent);
            string sql = "select Nam,SanLuong=SUM(SanLuong),DoanhThu=SUM(DoanhThu),GanMoi=SUM(GanMoi)"
                    + " , ThayDHNNho = SUM(ThayDHNNho), ThayDHNLon = SUM(ThayDHNLon), TyLeThatThoatNuoc = SUM(TyLeThatThoatNuoc)"
                    + " from BC_SoLieu where Nam = " + enTT.NamPresent + " group by Nam";
            DataTable dtSoLieu = _cTTKH.ExecuteQuery_DataTable(sql);
            enTT.SanLuongKH = int.Parse(dtKeHoach.Rows[0]["SanLuong"].ToString());
            enTT.DoanhThuKH = decimal.Parse(dtKeHoach.Rows[0]["DoanhThu"].ToString());
            enTT.GanMoiKH = int.Parse(dtKeHoach.Rows[0]["GanMoi"].ToString());
            enTT.ThayDHNNhoKH = int.Parse(dtKeHoach.Rows[0]["ThayDHNNho"].ToString());
            enTT.ThayDHNLonKH = int.Parse(dtKeHoach.Rows[0]["ThayDHNLon"].ToString());
            enTT.ThatThoatNuocKH = double.Parse(dtKeHoach.Rows[0]["TyLeThatThoatNuoc"].ToString());
            //
            enTT.SanLuong = int.Parse(dtSoLieu.Rows[0]["SanLuong"].ToString());
            enTT.DoanhThu = decimal.Parse(dtSoLieu.Rows[0]["DoanhThu"].ToString());
            enTT.GanMoi = int.Parse(dtSoLieu.Rows[0]["GanMoi"].ToString());
            enTT.ThayDHNNho = int.Parse(dtSoLieu.Rows[0]["ThayDHNNho"].ToString());
            enTT.ThayDHNLon = int.Parse(dtSoLieu.Rows[0]["ThayDHNLon"].ToString());
            enTT.ThatThoatNuoc = double.Parse(dtSoLieu.Rows[0]["TyLeThatThoatNuoc"].ToString());
            //
            enTT.SanLuongDat = (double)enTT.SanLuong / (double)enTT.SanLuongKH * 100;
            enTT.DoanhThuDat = (double)enTT.DoanhThu / (double)enTT.DoanhThuKH * 100;
            enTT.GanMoiDat = (double)enTT.GanMoi / (double)enTT.GanMoiKH * 100;
            enTT.ThayDHNNhoDat = (double)enTT.ThayDHNNho / (double)enTT.ThayDHNNhoKH * 100;
            enTT.ThayDHNLonDat = (double)enTT.ThayDHNLon / (double)enTT.ThayDHNLonKH * 100;
            enTT.ThatThoatNuocDat = enTT.ThatThoatNuoc - enTT.ThatThoatNuocKH;
            return View(enTT);
        }

        public List<Chart> getlstSanLuong()
        {
            List<Chart> lstChart = new List<Chart>();
            DataTable dt = _cDocSo.getSanLuong();
            for (int i = 1; i <= 12; i++)
            {
                Chart enSL = new Chart();
                enSL.Ky = i;
                enSL.NamPrevious = decimal.Parse(dt.Rows[i - 1]["SanLuongPrevious"].ToString());
                if (dt.Rows[i - 1]["SanLuongPresent"].ToString() != "")
                {
                    enSL.NamPresent = decimal.Parse(dt.Rows[i - 1]["SanLuongPresent"].ToString());
                    enSL.ChenhLech = decimal.Parse(dt.Rows[i - 1]["ChenhLech"].ToString());
                }
                else
                {
                    enSL.NamPresent = 0;
                }
                lstChart.Add(enSL);
            }

            return lstChart;
        }

        [HttpGet]
        public JsonResult getSanLuong_amcharts()
        {
            List<Chart> lstChart = new List<Chart>();
            DataTable dt = _cDocSo.getSanLuong();
            for (int i = 1; i <= 12; i++)
            {
                Chart enSL = new Chart();
                enSL.Ky = i;
                enSL.NamPrevious = decimal.Parse(dt.Rows[i - 1]["SanLuongPrevious"].ToString());
                if (dt.Rows[i - 1]["SanLuongPresent"].ToString() != "")
                    enSL.NamPresent = decimal.Parse(dt.Rows[i - 1]["SanLuongPresent"].ToString());
                else
                    enSL.NamPresent = 0;
                lstChart.Add(enSL);
            }

            //return list as Json
            return Json(lstChart, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getSanLuong_anycharts()
        {
            List<Array> lstChart = new List<Array>();
            DataTable dt = _cDocSo.getSanLuong();
            for (int i = 1; i <= 12; i++)
            {
                string[] a = new string[] { i.ToString(), dt.Rows[i - 1]["SanLuongPrevious"].ToString(), dt.Rows[i - 1]["SanLuongPresent"].ToString() };

                lstChart.Add(a);
            }

            //return list as Json
            return Json(lstChart, JsonRequestBehavior.AllowGet);
        }

        public List<Chart> getlstDoanhThu()
        {
            List<Chart> lstChart = new List<Chart>();
            DataTable dt = _cThuTien.getDoanhThu();
            for (int i = 1; i <= 12; i++)
            {
                Chart enSL = new Chart();
                enSL.Ky = i;
                enSL.NamPrevious = decimal.Parse(dt.Rows[i - 1]["DoanhThuPrevious"].ToString());
                if (dt.Rows[i - 1]["DoanhThuPresent"].ToString() != "")
                {
                    enSL.NamPresent = decimal.Parse(dt.Rows[i - 1]["DoanhThuPresent"].ToString());
                    enSL.ChenhLech = decimal.Parse(dt.Rows[i - 1]["ChenhLech"].ToString());
                }
                else
                    enSL.NamPresent = 0;
                lstChart.Add(enSL);
            }

            return lstChart;
        }

        [HttpGet]
        public JsonResult getDoanhThu_amcharts()
        {
            List<Chart> lstChart = new List<Chart>();
            DataTable dt = _cThuTien.getDoanhThu();
            for (int i = 1; i <= 12; i++)
            {
                Chart enSL = new Chart();
                enSL.Ky = i;
                enSL.NamPrevious = decimal.Parse(dt.Rows[i - 1]["DoanhThuPrevious"].ToString());
                if (dt.Rows[i - 1]["DoanhThuPresent"].ToString() != "")
                    enSL.NamPresent = decimal.Parse(dt.Rows[i - 1]["DoanhThuPresent"].ToString());
                else
                    enSL.NamPresent = 0;
                lstChart.Add(enSL);
            }

            //return list as Json
            return Json(lstChart, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getDoanhThu_anycharts()
        {
            List<Array> lstChart = new List<Array>();
            DataTable dt = _cThuTien.getDoanhThu();
            for (int i = 1; i <= 12; i++)
            {
                string[] a = new string[] { i.ToString(), dt.Rows[i - 1]["DoanhThuPrevious"].ToString(), dt.Rows[i - 1]["DoanhThuPresent"].ToString() };

                lstChart.Add(a);
            }

            //return list as Json
            return Json(lstChart, JsonRequestBehavior.AllowGet);
        }

        public List<Chart> getlstGiaBanBinhQuan()
        {
            List<Chart> lstChart = new List<Chart>();
            DataTable dt = _cThuTien.getGiaBanBinhQuan();
            for (int i = 1; i <= 12; i++)
            {
                Chart enSL = new Chart();
                enSL.Ky = i;
                enSL.NamPrevious = Math.Round(decimal.Parse(dt.Rows[i - 1]["DoanhThuPrevious"].ToString()));
                if (dt.Rows[i - 1]["DoanhThuPresent"].ToString() != "")
                {
                    enSL.NamPresent = Math.Round(decimal.Parse(dt.Rows[i - 1]["DoanhThuPresent"].ToString()));
                    enSL.ChenhLech = Math.Round(decimal.Parse(dt.Rows[i - 1]["ChenhLech"].ToString()));
                }
                else
                    enSL.NamPresent = 0;
                lstChart.Add(enSL);
            }

            return lstChart;
        }

        [HttpGet]
        public JsonResult getGiaBanBinhQuan_amcharts()
        {
            List<Chart> lstChart = new List<Chart>();
            DataTable dt = _cThuTien.getGiaBanBinhQuan();
            for (int i = 1; i <= 12; i++)
            {
                Chart enSL = new Chart();
                enSL.Ky = i;
                enSL.NamPrevious = Math.Round(decimal.Parse(dt.Rows[i - 1]["DoanhThuPrevious"].ToString()));
                if (dt.Rows[i - 1]["DoanhThuPresent"].ToString() != "")
                    enSL.NamPresent = Math.Round(decimal.Parse(dt.Rows[i - 1]["DoanhThuPresent"].ToString()));
                else
                    enSL.NamPresent = 0;
                lstChart.Add(enSL);
            }

            //return list as Json
            return Json(lstChart, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getGiaBanBinhQuan_anycharts()
        {
            List<Array> lstChart = new List<Array>();
            DataTable dt = _cThuTien.getGiaBanBinhQuan();
            for (int i = 1; i <= 12; i++)
            {
                string[] a = new string[] { i.ToString(), dt.Rows[i - 1]["DoanhThuPrevious"].ToString(), dt.Rows[i - 1]["DoanhThuPresent"].ToString() };

                lstChart.Add(a);
            }

            //return list as Json
            return Json(lstChart, JsonRequestBehavior.AllowGet);
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