using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TrungTamKhachHang.DAL
{
    class CCapNuocTanHoa
    {
        CConnection _cDAL = new CConnection(CConnection.connectionString_CapNuocTanHoa);

        public DataTable getThongTin(string DanhBo)
        {
            DataTable dt = new DataTable();
            //lấy thông tin khách hàng
            string sql = "select DanhBo"
                         + ",HoTen"
                         + ",DiaChi=SoNha+' '+TenDuong+', P.'+(select TenPhuong from Phuong where MaPhuong=Phuong and MaQuan=Quan)+', Q.'+(select TenQuan from Quan where MaQuan=Quan)"
                         + ",HopDong"
                         + ",DienThoai"
                         + ",MLT=LoTrinh"
                         + ",DinhMuc"
                         + ",GiaBieu"
                         + ",HieuDH"
                         + ",CoDH"
                         + ",Cap"
                         + ",SoThanDH"
                         + ",ViTriDHN"
                         + ",NgayThay"
                         + ",NgayKiemDinh"
                         + ",HieuLuc=convert(varchar(2),Ky)+'/'+convert(char(4),Nam)"
                         + " from TB_DULIEUKHACHHANG where DanhBo=" + DanhBo;
            dt.Merge(_cDAL.ExecuteQuery_DataTable(sql));
            //lấy thông tin khách hàng đã hủy
            if (dt == null || dt.Rows.Count == 0)
            {
                sql = "select DanhBo"
                             + ",HoTen"
                             + ",DiaChi=SoNha+' '+TenDuong+', P.'+(select TenPhuong from Phuong where MaPhuong=Phuong and MaQuan=Quan)+', Q.'+(select TenQuan from Quan where MaQuan=Quan)"
                             + ",HopDong"
                             + ",DienThoai=''"
                             + ",MLT=LoTrinh"
                             + ",DinhMuc"
                             + ",GiaBieu"
                             + ",HieuDH"
                             + ",CoDH"
                             + ",Cap"
                             + ",SoThanDH"
                             + ",ViTriDHN"
                             + ",NgayThay"
                             + ",NgayKiemDinh"
                             + ",HieuLuc=convert(varchar(2),Ky)+'/'+convert(char(4),Nam)"
                             + " from TB_DULIEUKHACHHANG_HUYDB where DanhBo=" + DanhBo;
                dt.Merge(_cDAL.ExecuteQuery_DataTable(sql));
            }

            return dt;
        }

        public DataTable getGhiChu(string DanhBo)
        {
            return _cDAL.ExecuteQuery_DataTable("select NoiDung,CreateDate from TB_GHICHU where DanhBo=" + DanhBo + " order by CreateDate desc");
        }
    }
}
