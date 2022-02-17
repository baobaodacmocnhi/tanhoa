using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocSo_PC.LinQ;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;
using DocSo_PC.DAL.QuanTri;

namespace DocSo_PC.DAL
{
    class CDHN
    {
        public static dbDHNDataContext _db = new dbDHNDataContext();
        public static CConnection _cDAL = new CConnection(_db.Connection.ConnectionString);


        public void SubmitChanges()
        {
            _db.SubmitChanges();
        }

        public void Refresh()
        {
            _db = new dbDHNDataContext();
        }

        /// <summary>
        /// Function lấy dữ liệu
        /// </summary> 
        public DataTable getGhiChuKH(string db)
        {
            string sql = "SELECT ID,NOIDUNG,DONVI,CREATEDATE FROM TB_GHICHU WHERE DANHBO='" + db + "'  ORDER BY CREATEDATE DESC";
            return _cDAL.ExecuteQuery_DataTable(sql);

        }

        public DataTable getTTThay(string db)
        {
            string sql = "SELECT DHN_LYDOTHAY AS 'TENBANGKE',DHN_NGAYBAOTHAY,HCT_NGAYGAN,CASE WHEN ISNULL(HCT_TRONGAI,0)=1 THEN N'TN: ' +HCT_LYDOTRONGAI ELSE N'Hoàn tất' end as KETQUA,HCT_CHISOGO,HCT_CHISOGAN,HCT_CREATEDATE, HCT_CREATEBY ";
            sql += " FROM  TB_THAYDHN thay WHERE DHN_DANHBO='" + db + "' ORDER BY DHN_NGAYBAOTHAY DESC ";
            return _cDAL.ExecuteQuery_DataTable(sql);

        }

        public TB_DULIEUKHACHHANG get(string DanhBo)
        {
            return _db.TB_DULIEUKHACHHANGs.SingleOrDefault(item => item.DANHBO == DanhBo);
        }

        public TB_DULIEUKHACHHANG_HUYDB get_Huy(string DanhBo)
        {
            return _db.TB_DULIEUKHACHHANG_HUYDBs.SingleOrDefault(item => item.DANHBO == DanhBo);
        }

        public DataTable getDS_ViTriDHN()
        {
            return _cDAL.LINQToDataTable(_db.ViTriDHNs.ToList());
        }

        public DataTable getDS_Doi()
        {
            string sql = "select MLT=LOTRINH,DanhBo,HOTEN,DiaChi=SONHA+' '+TENDUONG,ViTri=VITRIDHN"
                        + " ,DienThoai=(select top 1 DIENTHOAI from SDT_DHN where DANHBO=TB_DULIEUKHACHHANG.DANHBO)"
                        + " from TB_DULIEUKHACHHANG order by LOTRINH";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_To(string MaTo)
        {
            string sql = "select MLT=LOTRINH,DanhBo,HOTEN,DiaChi=SONHA+' '+TENDUONG,ViTri=VITRIDHN"
                + " ,DienThoai=(select top 1 DIENTHOAI from SDT_DHN where DANHBO=TB_DULIEUKHACHHANG.DANHBO)"
                        + " from TB_DULIEUKHACHHANG where SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") order by LOTRINH";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_May(string May)
        {
            string sql = "select MLT=LOTRINH,DanhBo,HOTEN,DiaChi=SONHA+' '+TENDUONG,ViTri=VITRIDHN"
                + " ,DienThoai=(select top 1 DIENTHOAI from SDT_DHN where DANHBO=TB_DULIEUKHACHHANG.DANHBO)"
                        + " from TB_DULIEUKHACHHANG where SUBSTRING(LOTRINH,3,2)=" + May + " order by LOTRINH";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_DanhBo(string DanhBo)
        {
            string sql = "select MLT=LOTRINH,DanhBo,HOTEN,DiaChi=SONHA+' '+TENDUONG,ViTri=VITRIDHN"
                + " ,DienThoai=(select top 1 DIENTHOAI from SDT_DHN where DANHBO=TB_DULIEUKHACHHANG.DANHBO)"
                        + " from TB_DULIEUKHACHHANG where DanhBo='" + DanhBo + "' order by LOTRINH";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_DanhBo(string MaTo, string DanhBo)
        {
            string sql = "select MLT=LOTRINH,DanhBo,HOTEN,DiaChi=SONHA+' '+TENDUONG,ViTri=VITRIDHN"
                + " ,DienThoai=(select top 1 DIENTHOAI from SDT_DHN where DANHBO=TB_DULIEUKHACHHANG.DANHBO)"
                        + " from TB_DULIEUKHACHHANG where DanhBo='" + DanhBo + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") order by LOTRINH";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public SDT_DHN get_DienThoai(string DanhBo, string DienThoai)
        {
            return _db.SDT_DHNs.SingleOrDefault(item => item.DanhBo == DanhBo && item.DienThoai == DienThoai);
        }

        public DataTable getDS_DienThoai(string DanhBo)
        {
            return _cDAL.ExecuteQuery_DataTable("select * from SDT_DHN where DanhBo='" + DanhBo + "' order by CreateDate desc");
        }

        public bool them_DienThoai(SDT_DHN en)
        {
            try
            {
                en.CreateBy = CNguoiDung.MaND;
                en.CreateDate = DateTime.Now;
                _db.SDT_DHNs.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool xoa_DienThoai(SDT_DHN en)
        {
            try
            {
                _db.SDT_DHNs.DeleteOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool checkExists_DienThoai(string DanhBo, string DienThoai)
        {
            return _db.SDT_DHNs.Any(item => item.DanhBo == DanhBo && item.DienThoai == DienThoai);
        }

    }
}
