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
        cDMA _cDMA = new cDMA();
        public ActionResult Index()
        {
            ThongTin enTT = new ThongTin();
            enTT.NamPresent = DateTime.Now.Year;
            enTT.NamPrevious = DateTime.Now.Year - 1;
            enTT.KhachHang = decimal.Parse(_cDHN.ExecuteQuery_ReturnOneValue("select count(DanhBo) from TB_DULIEUKHACHHANG").ToString());
            DataTable dt = _cDHN.ExecuteQuery_DataTable("declare @Nam int=" + enTT.NamPresent
                    + " select SUM(TieuThuMoi), (select SanLuong from TRUNGTAMKHACHHANG.dbo.BC_KeHoach where Nam = @Nam),N'Nước tiêu thụ (m3)','ChiTietSanLuong' from DocSoTH.dbo.DocSo where Nam = @Nam"
                    + " union all"
                    + " select SUM(GIABAN), (select DoanhThu from TRUNGTAMKHACHHANG.dbo.BC_KeHoach where Nam = @Nam),N'Doanh thu tiền nước (đồng)','ChiTietDoanhThu' from HOADON_TA.dbo.HOADON where Nam = @Nam"
                    + " union all"
                    + " select SUM(GiaBanBinhQuan) / COUNT(*), (select GiaBanBinhQuan from TRUNGTAMKHACHHANG.dbo.BC_KeHoach where Nam = @Nam),N'Giá bán bình quân (đồng)','ChiTietGiaBanBinhQuan' from HOADON_TA.dbo.TT_GiaBanBinhQuan where Nam = @Nam"
                    + " union all"
                    + " select COUNT(*), (select GanMoi from TRUNGTAMKHACHHANG.dbo.BC_KeHoach where Nam = @Nam),N'Gắn mới ĐHN (cái)','' from CAPNUOCTANHOA.dbo.TB_GANMOI where YEAR(CREATEDATE) = @Nam"
                    + " union all"
                    + " select COUNT(*), (select ThayDHNNho from TRUNGTAMKHACHHANG.dbo.BC_KeHoach where Nam = @Nam),N'Thay ĐHN cỡ nhỏ (cái)','' from CAPNUOCTANHOA.dbo.TB_THAYDHN where YEAR(HCT_CREATEDATE) = @Nam and DHN_CODH<= 25"
                    + " union all"
                    + " select COUNT(*), (select ThayDHNLon from TRUNGTAMKHACHHANG.dbo.BC_KeHoach where Nam = @Nam),N'Thay ĐHN cỡ lớn (cái)','' from CAPNUOCTANHOA.dbo.TB_THAYDHN where YEAR(HCT_CREATEDATE) = @Nam and DHN_CODH> 25"
                    + " union all"
                    + " select 0, (select TyLeThatThoatNuoc from TRUNGTAMKHACHHANG.dbo.BC_KeHoach where Nam = @Nam),N'Tỷ lệ thất thoát thất thu (%)','ChiTietThatThoatNuoc'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Chart en = new Chart();
                en.Ky = i + 1;
                en.ThucHien = double.Parse(dt.Rows[i][0].ToString());
                en.KeHoach = double.Parse(dt.Rows[i][1].ToString());
                en.NoiDung = dt.Rows[i][2].ToString();
                en.TyLe = Math.Round(en.ThucHien / en.KeHoach * 100, 2);
                if (dt.Rows[i][3].ToString() != "")
                    en.NoiDung3 = dt.Rows[i][3].ToString();
                enTT.lstSanLuongNam.Add(en);
            }
            dt = _cDMA.ExecuteQuery_DataTable("SELECT sum(LN_ThatThoat)/sum(SL_DHT)*100 FROM[tanhoa].[dbo].[g_ThatThoatMangLuoi] where nam = " + enTT.NamPresent);
            enTT.lstSanLuongNam[enTT.lstSanLuongNam.Count - 1].ThucHien = Math.Round(double.Parse(dt.Rows[0][0].ToString()), 2);
            enTT.lstSanLuongNam[enTT.lstSanLuongNam.Count - 1].TyLe = Math.Round(enTT.lstSanLuongNam[enTT.lstSanLuongNam.Count - 1].KeHoach / enTT.lstSanLuongNam[enTT.lstSanLuongNam.Count - 1].ThucHien * 100, 2);
            return View(enTT);
        }

        public JsonResult getThuHo(string SoNgay)
        {
            List<NoiDung> lstChart = new List<NoiDung>();
            DataTable dt = _cThuTien.ExecuteQuery_DataTable("select * from"
                    + " (select dvt.TenDichVu, SoLuong = COUNT(ID_HOADON), TongCong = SUM(TONGCONG) from HOADON hd left join TT_DichVuThu dvt on hd.ID_HOADON = dvt.MaHD"
                    + " where CAST(NGAYGIAITRACH as date)>=CAST(DATEADD(day, " + (-1 * int.Parse(SoNgay)) + ", getdate()) as date) and CAST(NGAYGIAITRACH as date) <= CAST(getdate() as date) and MaNV_DangNgan is not null"
                    + " group by dvt.TenDichVu)t1"
                    + " order by SoLuong desc");
            decimal SLHoaDon = 0;
            foreach (DataRow item in dt.Rows)
            {
                SLHoaDon += decimal.Parse(item["SoLuong"].ToString());
            }
            decimal SoLuong = 0, TongCong = 0;
            foreach (DataRow item in dt.Rows)
            {
                NoiDung enSL = new NoiDung();
                enSL.NoiDung1 = item["TenDichVu"].ToString();
                SoLuong += decimal.Parse(item["SoLuong"].ToString());
                enSL.NoiDung2 = decimal.Parse(item["SoLuong"].ToString()).ToString("N0").Replace(",", ".");
                TongCong += decimal.Parse(item["TongCong"].ToString());
                enSL.NoiDung3 = decimal.Parse(item["TongCong"].ToString()).ToString("N0").Replace(",", ".");
                enSL.NoiDung4 = Math.Round(double.Parse(item["SoLuong"].ToString()) / (double)SLHoaDon * 100, 2).ToString().Replace(".", ",");
                lstChart.Add(enSL);
            }
            //tongcong
            NoiDung enTC = new NoiDung();
            enTC.NoiDung2 = SoLuong.ToString("N0").Replace(",", ".");
            enTC.NoiDung3 = TongCong.ToString("N0").Replace(",", ".");
            lstChart.Add(enTC);
            return Json(lstChart, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getNhanDon_anycharts(string SoNgay)
        {
            DataTable dt = _cThuTien.ExecuteQuery_DataTable("select MaDon, ID_NhomDon_PKH from KTKS_DonKH.dbo.DonTu"
                    + " where CAST(CreateDate as date) >= CAST(DATEADD(day, " + (-1 * int.Parse(SoNgay)) + ", getdate()) as date) and CAST(CreateDate as date) <= CAST(getdate() as date)");
            decimal DieuChinh = 0, KhieuNai = 0, SuCo = 0, QuanLy = 0, Khac = 0;
            foreach (DataRow item in dt.Rows)
            {
                if (item["ID_NhomDon_PKH"].ToString() != "")
                {
                    string[] strs = item["ID_NhomDon_PKH"].ToString().Split(';');
                    for (int i = 0; i < strs.Length; i++)
                    {
                        DataTable dtCount = _cThuTien.ExecuteQuery_DataTable("select top 1 DieuChinh,KhieuNai,SuCo,QuanLy from [KTKS_DonKH].[dbo].[NhomDon] where STTGroup=" + strs[i]);
                        if (bool.Parse(dtCount.Rows[0]["DieuChinh"].ToString()))
                            DieuChinh++;
                        else
                            if (bool.Parse(dtCount.Rows[0]["KhieuNai"].ToString()))
                            KhieuNai++;
                        else
                            if (bool.Parse(dtCount.Rows[0]["SuCo"].ToString()))
                            SuCo++;
                        else
                            if (bool.Parse(dtCount.Rows[0]["QuanLy"].ToString()))
                            QuanLy++;
                    }
                }
                else
                    Khac++;
            }
            List<Array> lstChart = new List<Array>();
            string[] a = new string[] { "Điều Chỉnh", DieuChinh.ToString() };
            lstChart.Add(a);
            a = new string[] { "Khiếu Nại", KhieuNai.ToString() };
            lstChart.Add(a);
            a = new string[] { "Sự Cố", SuCo.ToString() };
            lstChart.Add(a);
            a = new string[] { "Quản Lý", QuanLy.ToString() };
            lstChart.Add(a);
            a = new string[] { "Khác", Khac.ToString() };
            lstChart.Add(a);
            return Json(lstChart, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getDiemBe(string SoNgay)
        {
            List<NoiDung> lstChart = new List<NoiDung>();
            DataTable dt = _cDMA.ExecuteQuery_DataTable("SELECT Quan=TenQuan,LoaiBe=case when LoaiBe=1 then N'Bể Nổi' when LoaiBe=0 then N'Bể Ngầm' end"
                    + " , Tong = count(ID)"
                    + " , DaSua = count( case when TinhTrangSuaBe = 1 then 1 end)"
                    + " , KhongBe = count(case when TinhTrangSuaBe = 2 then 1 end)"
                    + " , ChuaSua = count(case when TinhTrangSuaBe is null then 1 end)"
                    + "   FROM[tanhoa].[dbo].[w_BaoBe]"
                    + "   where CAST(CreateDate as date) >= CAST(DATEADD(day, " + (-1 * int.Parse(SoNgay)) + ", getdate()) as date) and CAST(CreateDate as date) <= CAST(getdate() as date)"
                    + "   group by TenQuan, LoaiBe"
                    + "   order by TenQuan, LoaiBe");
            decimal Tong = 0, DaSua = 0, KhongBe = 0, ChuaSua = 0;
            foreach (DataRow item in dt.Rows)
            {
                NoiDung enSL = new NoiDung();
                enSL.NoiDung1 = item["Quan"].ToString();
                enSL.NoiDung2 = item["LoaiBe"].ToString();
                Tong += decimal.Parse(item["Tong"].ToString());
                enSL.NoiDung3 = decimal.Parse(item["Tong"].ToString()).ToString("N0").Replace(",", ".");
                DaSua += decimal.Parse(item["DaSua"].ToString());
                enSL.NoiDung4 = decimal.Parse(item["DaSua"].ToString()).ToString("N0").Replace(",", ".");
                KhongBe += decimal.Parse(item["KhongBe"].ToString());
                enSL.NoiDung5 = decimal.Parse(item["KhongBe"].ToString()).ToString("N0").Replace(",", ".");
                ChuaSua += decimal.Parse(item["ChuaSua"].ToString());
                enSL.NoiDung6 = decimal.Parse(item["ChuaSua"].ToString()).ToString("N0").Replace(",", ".");
                lstChart.Add(enSL);
            }
            //tongcong
            NoiDung enTC = new NoiDung();
            enTC.NoiDung3 = Tong.ToString("N0").Replace(",", ".");
            enTC.NoiDung4 = DaSua.ToString("N0").Replace(",", ".");
            enTC.NoiDung5 = KhongBe.ToString("N0").Replace(",", ".");
            enTC.NoiDung6 = ChuaSua.ToString("N0").Replace(",", ".");
            lstChart.Add(enTC);
            return Json(lstChart, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult Index()
        //{
        //    ThongTin enTT = new ThongTin();
        //    enTT.NamPresent = DateTime.Now.Year;
        //    enTT.NamPrevious = DateTime.Now.Year - 1;
        //    enTT.KhachHang = decimal.Parse(_cDHN.ExecuteQuery_ReturnOneValue("select count(DanhBo) from TB_DULIEUKHACHHANG").ToString());
        //    enTT.SanLuong = decimal.Parse(_cDocSo.ExecuteQuery_ReturnOneValue("select SUM(TieuThuMoi) from DocSo where Nam=" + enTT.NamPresent).ToString());
        //    enTT.DoanhThu = decimal.Parse(_cThuTien.ExecuteQuery_ReturnOneValue("select SUM(TONGCONG) from HOADON where YEAR(NGAYGIAITRACH)=" + enTT.NamPresent + " and MaNV_DangNgan is not null").ToString());
        //    enTT.lstSanLuongChuanThu = getlstSanLuongChuanThu(enTT.NamPresent);
        //    enTT.lstDoanhThu = getlstDoanhThu(enTT.NamPrevious,enTT.NamPresent);
        //    enTT.lstGiaBanBinhQuan = getlstGiaBanBinhQuan(enTT.NamPrevious,enTT.NamPresent);
        //    enTT.ThatThoatNuoc = (double)_cTTKH.ExecuteQuery_ReturnOneValue("select TyLeThatThoatNuoc2 from BC_SoLieu where Nam=2022");
        //    return View(enTT);
        //}

        #region ChiTietSanLuong
        public ActionResult ChiTietSanLuong()
        {
            ThongTin enTT = new ThongTin();
            enTT.NamPresent = DateTime.Now.Year;
            enTT.NamPrevious = enTT.NamPresent - 1;
            enTT.lstSanLuongNam = getlstSanLuongNam(enTT.NamPrevious, enTT.NamPresent);
            enTT.lstSanLuongChuanThu = getlstSanLuongChuanThu(enTT.NamPresent);
            return View(enTT);
        }

        public JsonResult getSanLuongDoi(string Nam, string Ky, string Dot)
        {
            if (Dot == "0")
                Dot = "";
            else
                Dot = " and Dot=" + Dot;
            List<NoiDung> lstChart = new List<NoiDung>();
            DataTable dt = _cDocSo.ExecuteQuery_DataTable("declare @Nam int = " + Nam + ";"
                    + " declare @Ky int= " + Ky + ";"
                    + " if(@Ky=1) begin set @Nam=@Nam-1; set @Ky=12; end"
                    + " select t2.[To],SoLuong=SUM(t2.SoLuong),SanLuong=SUM(t2.SanLuong)"
                    + " , SoLuongKyTruoc=SUM(t2.SoLuongKyTruoc),SanLuongKyTruoc=SUM(t2.SanLuongKyTruoc)"
                    + " , SoLuongBD1=SUM(t2.SoLuong)-SUM(t2.SoLuongKyTruoc),SanLuongBD1=SUM(t2.SanLuong)-SUM(t2.SanLuongKyTruoc)"
                    + " , SoLuongNamTruoc=SUM(t2.SoLuongNamTruoc),SanLuongNamTruoc=SUM(t2.SanLuongNamTruoc)"
                    + " , SoLuongBD2=SUM(t2.SoLuong)-SUM(t2.SoLuongNamTruoc),SanLuongBD2=SUM(t2.SanLuong)-SUM(t2.SanLuongNamTruoc)"
                    + " from"
                    + " ("
                    + " select 'To'=(select TenTo from[To] where MaTo= t1.MaTo),SoLuong=COUNT(DanhBo),SanLuong=SUM(TieuThu),SoLuongKyTruoc=0,SanLuongKyTruoc=0,SoLuongNamTruoc=0,SanLuongNamTruoc=0 from"
                    + " ("
                    + " select MaTo = 1, DanhBo= DanhBa, TieuThu= TieuThuMoi from DocSo where nam = @Nam and ky = @Ky " + Dot + " and (select TuMay from[To] where MaTo= 1)<=May and May<=(select DenMay from[To] where MaTo=1)"
                    + " union all"
                    + " select MaTo = 2, DanhBo = DanhBa, TieuThu = TieuThuMoi from DocSo where nam = @Nam and ky = @Ky " + Dot + " and(select TuMay from[To] where MaTo= 2)<=May and May<=(select DenMay from[To] where MaTo=2)"
                    + " union all"
                    + " select MaTo = 3, DanhBo = DanhBa, TieuThu = TieuThuMoi from DocSo where nam = @Nam and ky = @Ky " + Dot + " and(select TuMay from[To] where MaTo= 3)<=May and May<=(select DenMay from[To] where MaTo=3)"
                    + " union all"
                    + " select MaTo = 4, DanhBo = DanhBa, TieuThu = TieuThuMoi from DocSo where nam = @Nam and ky = @Ky " + Dot + " and(select TuMay from[To] where MaTo= 4)<=May and May<=(select DenMay from[To] where MaTo=4)"
                    + " )t1 group by t1.MaTo"
                    + " union"
                    + " select 'To'=(select TenTo from[To] where MaTo= t1.MaTo),SoLuong=0,SanLuong=0,SoLuongKyTruoc=COUNT(DanhBo),SanLuongKyTruoc=SUM(TieuThu),SoLuongNamTruoc=0,SanLuongNamTruoc=0 from"
                    + " ("
                    + " select MaTo = 1, DanhBo= DanhBa, TieuThu= TieuThuMoi from DocSo where nam = @Nam and ky = @Ky - 1 " + Dot + " and (select TuMay from[To] where MaTo= 1)<=May and May<=(select DenMay from[To] where MaTo=1)"
                    + " union all"
                    + " select MaTo = 2, DanhBo = DanhBa, TieuThu = TieuThuMoi from DocSo where nam = @Nam and ky = @Ky - 1 " + Dot + " and(select TuMay from[To] where MaTo= 2)<=May and May<=(select DenMay from[To] where MaTo=2)"
                    + " union all"
                    + " select MaTo = 3, DanhBo = DanhBa, TieuThu = TieuThuMoi from DocSo where nam = @Nam and ky = @Ky - 1 " + Dot + " and(select TuMay from[To] where MaTo= 3)<=May and May<=(select DenMay from[To] where MaTo=3)"
                    + " union all"
                    + " select MaTo = 4, DanhBo = DanhBa, TieuThu = TieuThuMoi from DocSo where nam = @Nam and ky = @Ky - 1 " + Dot + " and(select TuMay from[To] where MaTo= 4)<=May and May<=(select DenMay from[To] where MaTo=4)"
                    + " )t1 group by t1.MaTo"
                    + " union"
                    + " select 'To'=(select TenTo from[To] where MaTo= t1.MaTo),SoLuong=0,SanLuong=0,SoLuongKyTruoc=0,SanLuongKyTruoc=0,SoLuongNamTruoc=COUNT(DanhBo),SanLuongNamTruoc=SUM(TieuThu) from"
                    + " ("
                    + " select MaTo = 1, DanhBo= DanhBa, TieuThu= TieuThuMoi from DocSo where nam = @Nam - 1 and ky = @Ky " + Dot + " and (select TuMay from[To] where MaTo= 1)<=May and May<=(select DenMay from[To] where MaTo=1)"
                    + " union all"
                    + " select MaTo = 2, DanhBo = DanhBa, TieuThu = TieuThuMoi from DocSo where nam = @Nam - 1 and ky = @Ky " + Dot + " and(select TuMay from[To] where MaTo= 2)<=May and May<=(select DenMay from[To] where MaTo=2)"
                    + " union all"
                    + " select MaTo = 3, DanhBo = DanhBa, TieuThu = TieuThuMoi from DocSo where nam = @Nam - 1 and ky = @Ky " + Dot + " and(select TuMay from[To] where MaTo= 3)<=May and May<=(select DenMay from[To] where MaTo=3)"
                    + " union all"
                    + " select MaTo = 4, DanhBo = DanhBa, TieuThu = TieuThuMoi from DocSo where nam = @Nam - 1 and ky = @Ky " + Dot + " and(select TuMay from[To] where MaTo= 4)<=May and May<=(select DenMay from[To] where MaTo=4)"
                    + " )t1 group by t1.MaTo"
                    + " )t2 group by t2.[To]");
            decimal SoLuong = 0, SanLuong = 0, SoLuongKyTruoc = 0, SanLuongKyTruoc = 0, SoLuongBD1 = 0, SanLuongBD1 = 0, SoLuongNamTruoc = 0, SanLuongNamTruoc = 0, SoLuongBD2 = 0, SanLuongBD2 = 0;
            foreach (DataRow item in dt.Rows)
            {
                NoiDung enSL = new NoiDung();
                enSL.NoiDung1 = item["To"].ToString();
                SoLuong += decimal.Parse(item["SoLuong"].ToString());
                enSL.NoiDung2 = decimal.Parse(item["SoLuong"].ToString()).ToString("N0").Replace(",", ".");
                SanLuong += decimal.Parse(item["SanLuong"].ToString());
                enSL.NoiDung3 = decimal.Parse(item["SanLuong"].ToString()).ToString("N0").Replace(",", ".");
                SoLuongKyTruoc += decimal.Parse(item["SoLuongKyTruoc"].ToString());
                enSL.NoiDung4 = decimal.Parse(item["SoLuongKyTruoc"].ToString()).ToString("N0").Replace(",", ".");
                SanLuongKyTruoc += decimal.Parse(item["SanLuongKyTruoc"].ToString());
                enSL.NoiDung5 = decimal.Parse(item["SanLuongKyTruoc"].ToString()).ToString("N0").Replace(",", ".");
                SoLuongBD1 += decimal.Parse(item["SoLuongBD1"].ToString());
                enSL.NoiDung6 = decimal.Parse(item["SoLuongBD1"].ToString()).ToString("N0").Replace(",", ".");
                SanLuongBD1 += decimal.Parse(item["SanLuongBD1"].ToString());
                enSL.NoiDung7 = decimal.Parse(item["SanLuongBD1"].ToString()).ToString("N0").Replace(",", ".");
                SoLuongNamTruoc += decimal.Parse(item["SoLuongNamTruoc"].ToString());
                enSL.NoiDung8 = decimal.Parse(item["SoLuongNamTruoc"].ToString()).ToString("N0").Replace(",", ".");
                SanLuongNamTruoc += decimal.Parse(item["SanLuongNamTruoc"].ToString());
                enSL.NoiDung9 = decimal.Parse(item["SanLuongNamTruoc"].ToString()).ToString("N0").Replace(",", ".");
                SoLuongBD2 += decimal.Parse(item["SoLuongBD2"].ToString());
                enSL.NoiDung10 = decimal.Parse(item["SoLuongBD2"].ToString()).ToString("N0").Replace(",", ".");
                SanLuongBD2 += decimal.Parse(item["SanLuongBD2"].ToString());
                enSL.NoiDung11 = decimal.Parse(item["SanLuongBD2"].ToString()).ToString("N0").Replace(",", ".");
                lstChart.Add(enSL);
            }
            //tongcong
            NoiDung enTC = new NoiDung();
            enTC.NoiDung2 = SoLuong.ToString("N0").Replace(",", ".");
            enTC.NoiDung3 = SanLuong.ToString("N0").Replace(",", ".");
            enTC.NoiDung4 = SoLuongKyTruoc.ToString("N0").Replace(",", ".");
            enTC.NoiDung5 = SanLuongKyTruoc.ToString("N0").Replace(",", ".");
            enTC.NoiDung6 = SoLuongBD1.ToString("N0").Replace(",", ".");
            enTC.NoiDung7 = SanLuongBD1.ToString("N0").Replace(",", ".");
            enTC.NoiDung8 = SoLuongNamTruoc.ToString("N0").Replace(",", ".");
            enTC.NoiDung9 = SanLuongNamTruoc.ToString("N0").Replace(",", ".");
            enTC.NoiDung10 = SoLuongBD2.ToString("N0").Replace(",", ".");
            enTC.NoiDung11 = SanLuongBD2.ToString("N0").Replace(",", ".");
            lstChart.Add(enTC);
            return Json(lstChart, JsonRequestBehavior.AllowGet);
        }

        public List<Chart> getlstSanLuongNam(int NamPrevious, int NamPresent)
        {
            List<Chart> lstChart = new List<Chart>();
            DataTable dt = _cDocSo.getSanLuongNam(NamPrevious, NamPresent);
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

        public JsonResult getSanLuongNam_amcharts(int NamPrevious, int NamPresent)
        {
            List<Chart> lstChart = new List<Chart>();
            DataTable dt = _cDocSo.getSanLuongNam(NamPrevious, NamPresent);
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
            return Json(lstChart, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getSanLuongNam_anycharts(int NamPrevious, int NamPresent)
        {
            List<Array> lstChart = new List<Array>();
            DataTable dt = _cDocSo.getSanLuongNam(NamPrevious, NamPresent);
            for (int i = 1; i <= 12; i++)
            {
                string[] a = new string[] { i.ToString(), dt.Rows[i - 1]["SanLuongPrevious"].ToString(), dt.Rows[i - 1]["SanLuongPresent"].ToString() };

                lstChart.Add(a);
            }
            return Json(lstChart, JsonRequestBehavior.AllowGet);
        }

        public List<Chart> getlstSanLuongChuanThu(int NamPresent)
        {
            List<Chart> lstChart = new List<Chart>();
            DataTable dt = _cDocSo.getSanLuongChuanThu(NamPresent);
            for (int i = 1; i <= 12; i++)
            {
                Chart enSL = new Chart();
                enSL.Ky = i;
                if (dt.Rows.Count >= i)
                {
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
                }
                lstChart.Add(enSL);
            }
            return lstChart;
        }

        public JsonResult getSanLuongChuanThu_anycharts(int NamPresent)
        {
            List<Array> lstChart = new List<Array>();
            DataTable dt = _cDocSo.getSanLuongChuanThu(NamPresent);
            for (int i = 1; i <= 12; i++)
            {
                if (dt.Rows.Count >= i)
                {
                    string[] a = new string[] { i.ToString(), dt.Rows[i - 1]["SanLuongPrevious"].ToString(), dt.Rows[i - 1]["SanLuongPresent"].ToString() };
                    lstChart.Add(a);
                }
            }
            return Json(lstChart, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region ChiTietDoanhThu
        public ActionResult ChiTietDoanhThu()
        {
            ThongTin enTT = new ThongTin();
            enTT.NamPresent = DateTime.Now.Year;
            enTT.NamPrevious = enTT.NamPresent - 1;
            enTT.lstDoanhThu = getlstDoanhThu(enTT.NamPrevious, enTT.NamPresent);
            return View(enTT);
        }

        public List<Chart> getlstDoanhThu(int NamPrevious, int NamPresent)
        {
            List<Chart> lstChart = new List<Chart>();
            DataTable dt = _cThuTien.getDoanhThu(NamPrevious, NamPresent);
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

        public JsonResult getDoanhThu_amcharts(int NamPrevious, int NamPresent)
        {
            List<Chart> lstChart = new List<Chart>();
            DataTable dt = _cThuTien.getDoanhThu(NamPrevious, NamPresent);
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
            return Json(lstChart, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getDoanhThu_anycharts(int NamPrevious, int NamPresent)
        {
            List<Array> lstChart = new List<Array>();
            DataTable dt = _cThuTien.getDoanhThu(NamPrevious, NamPresent);
            for (int i = 1; i <= 12; i++)
            {
                string[] a = new string[] { i.ToString(), dt.Rows[i - 1]["DoanhThuPrevious"].ToString(), dt.Rows[i - 1]["DoanhThuPresent"].ToString() };
                lstChart.Add(a);
            }
            return Json(lstChart, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region ChiTietGiaBanBinhQuan
        public ActionResult ChiTietGiaBanBinhQuan()
        {
            ThongTin enTT = new ThongTin();
            enTT.NamPresent = DateTime.Now.Year;
            enTT.NamPrevious = enTT.NamPresent - 1;
            enTT.lstGiaBanBinhQuan = getlstGiaBanBinhQuan(enTT.NamPrevious, enTT.NamPresent);
            return View(enTT);
        }

        public List<Chart> getlstGiaBanBinhQuan(int NamPrevious, int NamPresent)
        {
            List<Chart> lstChart = new List<Chart>();
            DataTable dt = _cThuTien.getGiaBanBinhQuan(NamPrevious, NamPresent);
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
        public JsonResult getGiaBanBinhQuan_amcharts(int NamPrevious, int NamPresent)
        {
            List<Chart> lstChart = new List<Chart>();
            DataTable dt = _cThuTien.getGiaBanBinhQuan(NamPrevious, NamPresent);
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
            return Json(lstChart, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getGiaBanBinhQuan_anycharts(int NamPrevious, int NamPresent)
        {
            List<Array> lstChart = new List<Array>();
            DataTable dt = _cThuTien.getGiaBanBinhQuan(NamPrevious, NamPresent);
            for (int i = 1; i <= 12; i++)
            {
                string[] a = new string[] { i.ToString(), dt.Rows[i - 1]["DoanhThuPrevious"].ToString(), dt.Rows[i - 1]["DoanhThuPresent"].ToString() };
                lstChart.Add(a);
            }
            return Json(lstChart, JsonRequestBehavior.AllowGet);
        }

        #endregion

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