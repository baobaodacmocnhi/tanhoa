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
        CThuTien _cThuTien = new CThuTien();
        CBaoBao _cBaoBao = new CBaoBao();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public DataTable GetDSHoaDon(string DanhBo)
        {
            return _cThuTien.GetDSHoaDon(DanhBo);
        }

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
        public bool SuaPhong(string ID, string Name, string GiaTien, string ChiSoDien, string ChiSoNuoc)
        {
            return _cBaoBao.SuaPhong(ID, Name, GiaTien, ChiSoDien, ChiSoNuoc);
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
    }
}