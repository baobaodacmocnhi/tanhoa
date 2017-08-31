using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data;

namespace WSSmartPhone
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Service : System.Web.Services.WebService
    {
        CBaoBao _cBaoBao = new CBaoBao();
        CDocSo _cDocSo = new CDocSo();
        CThuTien _cThuTien = new CThuTien();
        
        #region BaoBao

        [WebMethod]
        public bool ThemKhachHang(string HoTen, string GioiTinh, string MaPhong)
        {
            return _cBaoBao.ThemKhachHang(HoTen, GioiTinh, MaPhong);
        }

        [WebMethod]
        public bool SuaKhachHang(string ID, string HoTen, string GioiTinh, string MaPhong)
        {
            return _cBaoBao.SuaKhachHang(ID, HoTen, GioiTinh, MaPhong);
        }

        [WebMethod]
        public bool XoaKhachHang(string ID)
        {
            return _cBaoBao.XoaKhachHang(ID);
        }

        [WebMethod]
        public DataTable GetDSKhachHang()
        {
            return _cBaoBao.GetDSKhachHang();
        }

        [WebMethod]
        public bool SuaPhong(string ID, string Name, string GiaTien,string SoNKNuoc, string ChiSoDien, string ChiSoNuoc)
        {
            return _cBaoBao.SuaPhong(ID, Name, GiaTien,SoNKNuoc, ChiSoDien, ChiSoNuoc);
        }

        [WebMethod]
        public DataTable GetDSPhong()
        {
            return _cBaoBao.GetDSPhong();
        }

        [WebMethod]
        public bool SuaGiaDien(string ID, string Name, string GiaTien)
        {
            return _cBaoBao.SuaGiaDien(ID, Name, GiaTien);
        }

        [WebMethod]
        public DataTable GetDSGiaDien()
        {
            return _cBaoBao.GetDSGiaDien();
        }

        [WebMethod]
        public bool SuaGiaNuoc(string ID, string Name, string GiaTien)
        {
            return _cBaoBao.SuaGiaNuoc(ID, Name, GiaTien);
        }

        [WebMethod]
        public DataTable GetDSGiaNuoc()
        {
            return _cBaoBao.GetDSGiaNuoc();
        }

        [WebMethod]
        public bool ThemHoaDon(string MaPhong, string ChiSoDien, string ChiSoNuoc)
        {
            return _cBaoBao.ThemHoaDon(MaPhong, int.Parse(ChiSoDien), int.Parse(ChiSoNuoc));
        }

        [WebMethod]
        public bool SuaHoaDon(string ID, string ChiSoDien, string ChiSoNuoc)
        {
            return _cBaoBao.SuaHoaDon(ID, int.Parse(ChiSoDien), int.Parse(ChiSoNuoc));
        }

        [WebMethod]
        public bool XoaHoaDon(string ID)
        {
            return _cBaoBao.XoaHoaDon(ID);
        }

        [WebMethod]
        public DataTable GetDSHoaDonBB()
        {
            return _cBaoBao.GetDSHoaDon();
        }

        [WebMethod]
        public DataTable GetDSHoaDonBBByMaPhong(string MaPhong)
        {
            return _cBaoBao.GetDSHoaDon(MaPhong);
        }

        #endregion

        #region DocSo

        [WebMethod]
        public bool DS_CheckDangNhap(string TaiKhoan, string MatKhau)
        {
            return _cDocSo.CheckDangNhap(TaiKhoan, MatKhau);
        }

        [WebMethod]
        public DataTable DS_DangNhap(string TaiKhoan, string MatKhau)
        {
            return _cDocSo.DangNhap(TaiKhoan, MatKhau);
        }

        [WebMethod]
        public DataTable DS_GetDSCode()
        {
            return _cDocSo.GetDSCode();
        }

        [WebMethod]
        public DataTable DS_GetDSDocSo(string Nam, string Ky, string Dot, string May)
        {
            return _cDocSo.GetDSDocSo(Nam, Ky, Dot, May);
        }

        [WebMethod]
        public int DS_TinhTieuThu(string DanhBo, string Nam, string Ky, string CodeMoi, string CSMoi)
        {
            return _cDocSo.TinhTieuThu(DanhBo, int.Parse(Nam), int.Parse(Ky), CodeMoi, int.Parse(CSMoi));
        }

        [WebMethod]
        public int DS_TinhTienNuoc(string DanhBo, string GiaBieu, string DinhMuc, string TieuThu, out string ChiTiet)
        {
            return _cDocSo.TinhTienNuoc(DanhBo, int.Parse(GiaBieu), int.Parse(DinhMuc), int.Parse(TieuThu), out ChiTiet);
        }

        [WebMethod]
        public bool DS_CapNhat(string ID, string CodeMoi, string TTDHNMoi, string CSMoi, string TieuThuMoi, string TienNuoc, string ChiTiet)
        {
            return _cDocSo.CapNhat(ID, CodeMoi, TTDHNMoi, CSMoi, TieuThuMoi, TienNuoc, ChiTiet);
        }

        #endregion

    }
}