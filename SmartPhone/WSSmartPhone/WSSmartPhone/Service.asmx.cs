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
        public bool ThemKhachHang(string HoTen,int GioiTinh)
        {
            return _cBaoBao.ThemKhachHang(HoTen, GioiTinh);
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

        #endregion
    }
}