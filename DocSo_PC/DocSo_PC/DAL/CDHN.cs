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
            sql += " FROM TB_THAYDHN thay WHERE DHN_DANHBO='" + db + "' ORDER BY DHN_NGAYBAOTHAY DESC ";
            return _cDAL.ExecuteQuery_DataTable(sql);

        }

        public bool checkExists(string DanhBo)
        {
            return _db.TB_DULIEUKHACHHANGs.Any(item => item.DANHBO == DanhBo);
        }

        public TB_DULIEUKHACHHANG get(string DanhBo)
        {
            return _db.TB_DULIEUKHACHHANGs.SingleOrDefault(item => item.DANHBO == DanhBo);
        }

        public TB_DULIEUKHACHHANG_HUYDB get_Huy(string DanhBo)
        {
            return _db.TB_DULIEUKHACHHANG_HUYDBs.SingleOrDefault(item => item.DANHBO == DanhBo);
        }

        public string getPhuongQuan(string MaQuan, string MaPhuong)
        {
            try
            {
                string Phuong = " P." + _db.PHUONGs.Single(itemPhuong => itemPhuong.MAQUAN == int.Parse(MaQuan) && itemPhuong.MAPHUONG == MaPhuong).TENPHUONG;
                string Quan = " Q." + _db.QUANs.Single(itemQuan => itemQuan.MAQUAN == int.Parse(MaQuan)).TENQUAN;
                return Phuong + Quan;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public DataTable getDS_ViTriDHN()
        {
            return _cDAL.LINQToDataTable(_db.ViTriDHNs.ToList());
        }

        public DataTable getDS_GhiChu()
        {
            string sql = "select MLT=LOTRINH,DanhBo,HOTEN,DiaChi=SONHA+' '+TENDUONG,ViTri=VITRIDHN,ViTriDHN_Ngoai,ViTriDHN_Hop"
                        + " ,DienThoai=( select"
                        + "   distinct"
                        + "    stuff(("
                        + "        select ',' + u.DienThoai+' '+u.HoTen"
                        + "        from SDT_DHN u"
                        + "        where u.DanhBo = TB_DULIEUKHACHHANG.DanhBo"
                        + "        for xml path('')"
                        + "    ),1,1,'')"
                        + ")"
                        + " ,DTKH=(select top 1 DienThoai from SDT_DHN where DanhBo=TB_DULIEUKHACHHANG.DanhBo and GhiChu=N'P. KH' order by CreateDate desc)"
                        + " ,DTDHN=(select top 1 DienThoai from SDT_DHN where DanhBo=TB_DULIEUKHACHHANG.DanhBo and GhiChu=N'Đ. QLĐHN' order by CreateDate desc)"
                        + " ,DTTV=(select top 1 DienThoai from SDT_DHN where DanhBo=TB_DULIEUKHACHHANG.DanhBo and GhiChu=N'P. TV' order by CreateDate desc)"
                        + " from TB_DULIEUKHACHHANG order by LOTRINH";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_GhiChu(string Dot, string May)
        {
            if (Dot == "Tất Cả")
                Dot = "";
            if (May == "Tất Cả")
                May = "";
            string sql = "select MLT=LOTRINH,DanhBo,HOTEN,DiaChi=SONHA+' '+TENDUONG,ViTri=VITRIDHN,ViTriDHN_Ngoai,ViTriDHN_Hop"
                + ",Hieu=HieuDH,Co=CoDH,SoThan=SoThanDH,NgayKiemDinh,NgayThay"        
                + " ,DienThoai=( select"
                        + "   distinct"
                        + "    stuff(("
                        + "        select ',' + u.DienThoai+' '+u.HoTen"
                        + "        from SDT_DHN u"
                        + "        where u.DanhBo = TB_DULIEUKHACHHANG.DanhBo"
                        + "        for xml path('')"
                        + "    ),1,1,'')"
                        + ")"
                        //+ " ,DTKH=(select top 1 DienThoai from SDT_DHN where DanhBo=TB_DULIEUKHACHHANG.DanhBo and GhiChu=N'P. KH' order by CreateDate desc)"
                        //+ " ,DTDHN=(select top 1 DienThoai from SDT_DHN where DanhBo=TB_DULIEUKHACHHANG.DanhBo and GhiChu=N'Đ. QLĐHN' order by CreateDate desc)"
                        //+ " ,DTTV=(select top 1 DienThoai from SDT_DHN where DanhBo=TB_DULIEUKHACHHANG.DanhBo and GhiChu=N'P. TV' order by CreateDate desc)"
                        + " from TB_DULIEUKHACHHANG where SUBSTRING(LOTRINH,0,3) like '%" + Dot + "%' and SUBSTRING(LOTRINH,3,2) like '%" + May + "%' order by LOTRINH";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_GhiChu_DanhBo(string DanhBo)
        {
            string sql = "select MLT=LOTRINH,DanhBo,HOTEN,DiaChi=SONHA+' '+TENDUONG,ViTri=VITRIDHN,ViTriDHN_Ngoai,ViTriDHN_Hop"
                        + ",Hieu=HieuDH,Co=CoDH,SoThan=SoThanDH,NgayKiemDinh,NgayThay"
                        + " ,DienThoai=( select"
                        + "   distinct"
                        + "    stuff(("
                        + "        select ',' + u.DienThoai+' '+u.HoTen"
                        + "        from SDT_DHN u"
                        + "        where u.DanhBo = TB_DULIEUKHACHHANG.DanhBo"
                        + "        for xml path('')"
                        + "    ),1,1,'')"
                        + ")"
                        //+ " ,DTKH=(select top 1 DienThoai from SDT_DHN where DanhBo=TB_DULIEUKHACHHANG.DanhBo and GhiChu=N'P. KH' order by CreateDate desc)"
                        //+ " ,DTDHN=(select top 1 DienThoai from SDT_DHN where DanhBo=TB_DULIEUKHACHHANG.DanhBo and GhiChu=N'Đ. QLĐHN' order by CreateDate desc)"
                        //+ " ,DTTV=(select top 1 DienThoai from SDT_DHN where DanhBo=TB_DULIEUKHACHHANG.DanhBo and GhiChu=N'P. TV' order by CreateDate desc)"
                        + " from TB_DULIEUKHACHHANG where DanhBo='" + DanhBo + "' order by LOTRINH";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_GhiChu_DanhBo(string MaTo, string DanhBo)
        {
            string sql = "select MLT=LOTRINH,DanhBo,HOTEN,DiaChi=SONHA+' '+TENDUONG,ViTri=VITRIDHN,ViTriDHN_Ngoai,ViTriDHN_Hop"
                + ",Hieu=HieuDH,Co=CoDH,SoThan=SoThanDH,NgayKiemDinh,NgayThay"      
                + " ,DienThoai=( select"
                        + "   distinct"
                        + "    stuff(("
                        + "        select ',' + u.DienThoai+' '+u.HoTen"
                        + "        from SDT_DHN u"
                        + "        where u.DanhBo = TB_DULIEUKHACHHANG.DanhBo"
                        + "        for xml path('')"
                        + "    ),1,1,'')"
                        + ")"
                        //+ " ,DTKH=(select top 1 DienThoai from SDT_DHN where DanhBo=TB_DULIEUKHACHHANG.DanhBo and GhiChu=N'P. KH' order by CreateDate desc)"
                        //+ " ,DTDHN=(select top 1 DienThoai from SDT_DHN where DanhBo=TB_DULIEUKHACHHANG.DanhBo and GhiChu=N'Đ. QLĐHN' order by CreateDate desc)"
                        //+ " ,DTTV=(select top 1 DienThoai from SDT_DHN where DanhBo=TB_DULIEUKHACHHANG.DanhBo and GhiChu=N'P. TV' order by CreateDate desc)"
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

        public DataTable getThongKe_DienThoai(string Dot)
        {
            string sql = "select May,Tong=COUNT(distinct t1.DANHBO),DaCo=COUNT(distinct dt.DANHBO),ChuaCo=COUNT(distinct t1.DANHBO)-COUNT(distinct dt.DANHBO) from"
                    + " (select May=SUBSTRING(LOTRINH,3,2),DanhBo from TB_DULIEUKHACHHANG where SUBSTRING(LOTRINH,1,2)=" + Dot + ")t1"
                    + " left join (select * from SDT_DHN where GhiChu=N'Đ. QLĐHN')dt on t1.DANHBO=dt.DanhBo"
                    + " group by May"
                    + " order by May";
            return _cDAL.ExecuteQuery_DataTable(sql);
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

        //public DataTable getDS_AmSau(DateTime FromCreateDate, DateTime ToCreateDate)
        //{
        //    string sql = "select MLT=LOTRINH,DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Âm Sâu',CREATEDATE=AmSau_Ngay,Folder='AmSau'"
        //        + ",ID=(select top 1 ID from DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu where DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.DanhBo=TB_DULIEUKHACHHANG.DanhBo and DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.NoiDung like N'Âm Sâu' and cast(DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.CreateDate as date)=cast(TB_DULIEUKHACHHANG.AmSau_Ngay as date))"
        //        + " from TB_DULIEUKHACHHANG where AmSau=1 and CAST(AmSau_Ngay as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(AmSau_Ngay as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
        //    return _cDAL.ExecuteQuery_DataTable(sql);
        //}

        //public DataTable getDS_AmSau(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        //{
        //    string sql = "select MLT=LOTRINH,DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Âm Sâu',CREATEDATE=AmSau_Ngay,Folder='AmSau'"
        //        + ",ID=(select top 1 ID from DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu where DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.DanhBo=TB_DULIEUKHACHHANG.DanhBo and DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.NoiDung like N'Âm Sâu' and cast(DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.CreateDate as date)=cast(TB_DULIEUKHACHHANG.AmSau_Ngay as date))"
        //        +" from TB_DULIEUKHACHHANG where AmSau=1 and CAST(AmSau_Ngay as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(AmSau_Ngay as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
        //    return _cDAL.ExecuteQuery_DataTable(sql);
        //}

        //public DataTable getDS_XayDung(DateTime FromCreateDate, DateTime ToCreateDate)
        //{
        //    string sql = " select MLT=LOTRINH,DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Xây Dựng',CREATEDATE=XayDung_Ngay,Folder='XayDung'"
        //        + ",ID=(select top 1 ID from DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu where DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.DanhBo=TB_DULIEUKHACHHANG.DanhBo and DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.NoiDung like N'Xây Dựng' and cast(DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.CreateDate as date)=cast(TB_DULIEUKHACHHANG.XayDung_Ngay as date))"
        //        +" from TB_DULIEUKHACHHANG where XayDung=1 and CAST(XayDung_Ngay as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(XayDung_Ngay as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
        //    return _cDAL.ExecuteQuery_DataTable(sql);
        //}

        //public DataTable getDS_XayDung(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        //{
        //    string sql = " select MLT=LOTRINH,DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Xây Dựng',CREATEDATE=XayDung_Ngay,Folder='XayDung'"
        //        + ",ID=(select top 1 ID from DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu where DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.DanhBo=TB_DULIEUKHACHHANG.DanhBo and DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.NoiDung like N'Xây Dựng' and cast(DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.CreateDate as date)=cast(TB_DULIEUKHACHHANG.XayDung_Ngay as date))"
        //        + " from TB_DULIEUKHACHHANG where XayDung=1 and CAST(XayDung_Ngay as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(XayDung_Ngay as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
        //    return _cDAL.ExecuteQuery_DataTable(sql);
        //}

        //public DataTable getDS_DutChiGoc(DateTime FromCreateDate, DateTime ToCreateDate)
        //{
        //    string sql = " select MLT=LOTRINH,DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Đứt Chì Góc',CREATEDATE=DutChi_Goc_Ngay,Folder='DutChi'"
        //        + ",ID=(select top 1 ID from DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu where DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.DanhBo=TB_DULIEUKHACHHANG.DanhBo and DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.NoiDung like N'Đứt Chì Góc' and cast(DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.CreateDate as date)=cast(TB_DULIEUKHACHHANG.DutChi_Goc_Ngay as date))"
        //        + " from TB_DULIEUKHACHHANG where DutChi_Goc=1 and DutChi_Than=0 and CAST(DutChi_Goc_Ngay as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(DutChi_Goc_Ngay as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
        //    return _cDAL.ExecuteQuery_DataTable(sql);
        //}

        //public DataTable getDS_DutChiGoc(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        //{
        //    string sql = " select MLT=LOTRINH,DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Đứt Chì Góc',CREATEDATE=DutChi_Goc_Ngay,Folder='DutChi'"
        //        + ",ID=(select top 1 ID from DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu where DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.DanhBo=TB_DULIEUKHACHHANG.DanhBo and DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.NoiDung like N'Đứt Chì Góc' and cast(DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.CreateDate as date)=cast(TB_DULIEUKHACHHANG.DutChi_Goc_Ngay as date))"
        //        + " from TB_DULIEUKHACHHANG where DutChi_Goc=1 and DutChi_Than=0 and CAST(DutChi_Goc_Ngay as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(DutChi_Goc_Ngay as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
        //    return _cDAL.ExecuteQuery_DataTable(sql);
        //}

        //public DataTable getDS_DutChiThan(DateTime FromCreateDate, DateTime ToCreateDate)
        //{
        //    string sql = " select MLT=LOTRINH,DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Đứt Chì Thân',CREATEDATE=DutChi_Than_Ngay,Folder='DutChi'"
        //        + ",ID=(select top 1 ID from DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu where DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.DanhBo=TB_DULIEUKHACHHANG.DanhBo and DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.NoiDung like N'Đứt Chì Thân' and cast(DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.CreateDate as date)=cast(TB_DULIEUKHACHHANG.DutChi_Than_Ngay as date))"
        //        + " from TB_DULIEUKHACHHANG where DutChi_Than=1 and CAST(DutChi_Than_Ngay as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(DutChi_Than_Ngay as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
        //    return _cDAL.ExecuteQuery_DataTable(sql);
        //}

        //public DataTable getDS_DutChiThan(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        //{
        //    string sql = " select MLT=LOTRINH,DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Đứt Chì Thân',CREATEDATE=DutChi_Than_Ngay,Folder='DutChi'"
        //        + ",ID=(select top 1 ID from DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu where DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.DanhBo=TB_DULIEUKHACHHANG.DanhBo and DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.NoiDung like N'Đứt Chì Thân' and cast(DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.CreateDate as date)=cast(TB_DULIEUKHACHHANG.DutChi_Than_Ngay as date))"
        //        + " from TB_DULIEUKHACHHANG where DutChi_Than=1 and CAST(DutChi_Than_Ngay as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(DutChi_Than_Ngay as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
        //    return _cDAL.ExecuteQuery_DataTable(sql);
        //}

        //public DataTable getDS_DutChiGocThan(DateTime FromCreateDate, DateTime ToCreateDate)
        //{
        //    string sql = " select MLT=LOTRINH,DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Đứt Chì Góc + Thân',CREATEDATE=DutChi_Than_Ngay,Folder='DutChi'"
        //        + ",ID=(select top 1 ID from DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu where DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.DanhBo=TB_DULIEUKHACHHANG.DanhBo and DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.NoiDung like N'Đứt Chì Góc + Thân' and cast(DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.CreateDate as date)=cast(TB_DULIEUKHACHHANG.DutChi_Than_Ngay as date))"
        //        + " from TB_DULIEUKHACHHANG where DutChi_Goc=1 and DutChi_Than=1 and CAST(DutChi_Than_Ngay as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(DutChi_Than_Ngay as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
        //    return _cDAL.ExecuteQuery_DataTable(sql);
        //}

        //public DataTable getDS_DutChiGocThan(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        //{
        //    string sql = " select MLT=LOTRINH,DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Đứt Chì Góc + Thân',CREATEDATE=DutChi_Than_Ngay,Folder='DutChi'"
        //        + ",ID=(select top 1 ID from DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu where DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.DanhBo=TB_DULIEUKHACHHANG.DanhBo and DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.NoiDung like N'Đứt Chì Góc + Thân' and cast(DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.CreateDate as date)=cast(TB_DULIEUKHACHHANG.DutChi_Than_Ngay as date))"
        //        + " from TB_DULIEUKHACHHANG where DutChi_Goc=1 and DutChi_Than=1 and CAST(DutChi_Than_Ngay as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(DutChi_Than_Ngay as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
        //    return _cDAL.ExecuteQuery_DataTable(sql);
        //}

        //public DataTable getDS_NgapNuoc(DateTime FromCreateDate, DateTime ToCreateDate)
        //{
        //    string sql = "select MLT=LOTRINH,DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Ngập Nước',CREATEDATE=NgapNuoc_Ngay,Folder='NgapNuoc'"
        //        + ",ID=(select top 1 ID from DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu where DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.DanhBo=TB_DULIEUKHACHHANG.DanhBo and DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.NoiDung like N'Ngập Nước' and cast(DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.CreateDate as date)=cast(TB_DULIEUKHACHHANG.NgapNuoc_Ngay as date))"
        //        + " from TB_DULIEUKHACHHANG where NgapNuoc=1 and CAST(NgapNuoc_Ngay as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(NgapNuoc_Ngay as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
        //    return _cDAL.ExecuteQuery_DataTable(sql);
        //}

        //public DataTable getDS_NgapNuoc(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        //{
        //    string sql = "select MLT=LOTRINH,DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Ngập Nước',CREATEDATE=NgapNuoc_Ngay,Folder='NgapNuoc'"
        //        + ",ID=(select top 1 ID from DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu where DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.DanhBo=TB_DULIEUKHACHHANG.DanhBo and DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.NoiDung like N'Ngập Nước' and cast(DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.CreateDate as date)=cast(TB_DULIEUKHACHHANG.NgapNuoc_Ngay as date))"
        //        + " from TB_DULIEUKHACHHANG where NgapNuoc=1 and CAST(NgapNuoc_Ngay as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(NgapNuoc_Ngay as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
        //    return _cDAL.ExecuteQuery_DataTable(sql);
        //}

        //public DataTable getDS_KetTuong(DateTime FromCreateDate, DateTime ToCreateDate)
        //{
        //    string sql = "select MLT=LOTRINH,DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Kẹt Tường',CREATEDATE=KetTuong_Ngay,Folder='KetTuong'"
        //        + ",ID=(select top 1 ID from DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu where DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.DanhBo=TB_DULIEUKHACHHANG.DanhBo and DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.NoiDung like N'Kẹt Tường' and cast(DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.CreateDate as date)=cast(TB_DULIEUKHACHHANG.KetTuong_Ngay as date))"
        //        + " from TB_DULIEUKHACHHANG where KetTuong=1 and CAST(KetTuong_Ngay as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(KetTuong_Ngay as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
        //    return _cDAL.ExecuteQuery_DataTable(sql);
        //}

        //public DataTable getDS_KetTuong(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        //{
        //    string sql = "select MLT=LOTRINH,DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Kẹt Tường',CREATEDATE=KetTuong_Ngay,Folder='KetTuong'"
        //        + ",ID=(select top 1 ID from DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu where DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.DanhBo=TB_DULIEUKHACHHANG.DanhBo and DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.NoiDung like N'Kẹt Tường' and cast(DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.CreateDate as date)=cast(TB_DULIEUKHACHHANG.KetTuong_Ngay as date))"
        //        + " from TB_DULIEUKHACHHANG where KetTuong=1 and CAST(KetTuong_Ngay as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(KetTuong_Ngay as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
        //    return _cDAL.ExecuteQuery_DataTable(sql);
        //}

        //public DataTable getDS_LapKhoaGoc(DateTime FromCreateDate, DateTime ToCreateDate)
        //{
        //    string sql = "select MLT=LOTRINH,DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Lấp Khóa Góc',CREATEDATE=LapKhoaGoc_Ngay,Folder='LapKhoaGoc'"
        //        + ",ID=(select top 1 ID from DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu where DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.DanhBo=TB_DULIEUKHACHHANG.DanhBo and DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.NoiDung like N'Lấp Khóa Góc' and cast(DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.CreateDate as date)=cast(TB_DULIEUKHACHHANG.LapKhoaGoc_Ngay as date))"
        //        + " from TB_DULIEUKHACHHANG where LapKhoaGoc=1 and CAST(LapKhoaGoc_Ngay as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(LapKhoaGoc_Ngay as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
        //    return _cDAL.ExecuteQuery_DataTable(sql);
        //}

        //public DataTable getDS_LapKhoaGoc(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        //{
        //    string sql = "select MLT=LOTRINH,DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Lấp Khóa Góc',CREATEDATE=LapKhoaGoc_Ngay,Folder='LapKhoaGoc'"
        //        + ",ID=(select top 1 ID from DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu where DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.DanhBo=TB_DULIEUKHACHHANG.DanhBo and DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.NoiDung like N'Lấp Khóa Góc' and cast(DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.CreateDate as date)=cast(TB_DULIEUKHACHHANG.LapKhoaGoc_Ngay as date))"
        //        + " from TB_DULIEUKHACHHANG where LapKhoaGoc=1 and CAST(LapKhoaGoc_Ngay as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(LapKhoaGoc_Ngay as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
        //    return _cDAL.ExecuteQuery_DataTable(sql);
        //}

        //public DataTable getDS_BeHBV(DateTime FromCreateDate, DateTime ToCreateDate)
        //{
        //    string sql = "select MLT=LOTRINH,DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Bể HBV',CREATEDATE=BeHBV_Ngay,Folder='BeHBV'"
        //        + ",ID=(select top 1 ID from DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu where DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.DanhBo=TB_DULIEUKHACHHANG.DanhBo and DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.NoiDung like N'Bể HBV' and cast(DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.CreateDate as date)=cast(TB_DULIEUKHACHHANG.BeHBV_Ngay as date))"
        //        + " from TB_DULIEUKHACHHANG where BeHBV=1 and CAST(BeHBV_Ngay as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(BeHBV_Ngay as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
        //    return _cDAL.ExecuteQuery_DataTable(sql);
        //}

        //public DataTable getDS_BeHBV(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        //{
        //    string sql = "select MLT=LOTRINH,DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Bể HBV',CREATEDATE=BeHBV_Ngay,Folder='BeHBV'"
        //        + ",ID=(select top 1 ID from DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu where DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.DanhBo=TB_DULIEUKHACHHANG.DanhBo and DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.NoiDung like N'Bể HBV' and cast(DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.CreateDate as date)=cast(TB_DULIEUKHACHHANG.BeHBV_Ngay as date))"
        //        + " from TB_DULIEUKHACHHANG where BeHBV=1 and CAST(BeHBV_Ngay as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(BeHBV_Ngay as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
        //    return _cDAL.ExecuteQuery_DataTable(sql);
        //}

        //public DataTable getDS_BeNapMatNapHBV(DateTime FromCreateDate, DateTime ToCreateDate)
        //{
        //    string sql = "select MLT=LOTRINH,DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Bể Nấp, Mất Nấp HBV',CREATEDATE=BeNapMatNapHBV_Ngay,Folder='BeNapMatNapHBV'"
        //        + ",ID=(select top 1 ID from DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu where DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.DanhBo=TB_DULIEUKHACHHANG.DanhBo and DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.NoiDung like N'Bể Nấp, Mất Nấp HBV' and cast(DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.CreateDate as date)=cast(TB_DULIEUKHACHHANG.BeNapMatNapHBV_Ngay as date))"
        //        + " from TB_DULIEUKHACHHANG where BeNapMatNapHBV=1 and CAST(BeNapMatNapHBV_Ngay as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(BeNapMatNapHBV_Ngay as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
        //    return _cDAL.ExecuteQuery_DataTable(sql);
        //}

        //public DataTable getDS_BeNapMatNapHBV(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        //{
        //    string sql = "select MLT=LOTRINH,DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Bể Nấp, Mất Nấp HBV',CREATEDATE=BeNapMatNapHBV_Ngay,Folder='BeNapMatNapHBV'"
        //        + ",ID=(select top 1 ID from DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu where DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.DanhBo=TB_DULIEUKHACHHANG.DanhBo and DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.NoiDung like N'Bể Nấp, Mất Nấp HBV' and cast(DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.CreateDate as date)=cast(TB_DULIEUKHACHHANG.BeNapMatNapHBV_Ngay as date))"
        //        + " from TB_DULIEUKHACHHANG where BeNapMatNapHBV=1 and CAST(BeNapMatNapHBV_Ngay as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(BeNapMatNapHBV_Ngay as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
        //    return _cDAL.ExecuteQuery_DataTable(sql);
        //}

        //public DataTable getDS_GayTayVan(DateTime FromCreateDate, DateTime ToCreateDate)
        //{
        //    string sql = "select MLT=LOTRINH,DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Gãy Tay Van',CREATEDATE=GayTayVan_Ngay,Folder='GayTayVan'"
        //        + ",ID=(select top 1 ID from DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu where DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.DanhBo=TB_DULIEUKHACHHANG.DanhBo and DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.NoiDung like N'Gãy Tay Van' and cast(DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.CreateDate as date)=cast(TB_DULIEUKHACHHANG.GayTayVan_Ngay as date))"
        //        + " from TB_DULIEUKHACHHANG where GayTayVan=1 and CAST(GayTayVan_Ngay as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(GayTayVan_Ngay as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
        //    return _cDAL.ExecuteQuery_DataTable(sql);
        //}

        //public DataTable getDS_GayTayVan(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        //{
        //    string sql = "select MLT=LOTRINH,DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Gãy Tay Van',CREATEDATE=GayTayVan_Ngay,Folder='GayTayVan'"
        //        + ",ID=(select top 1 ID from DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu where DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.DanhBo=TB_DULIEUKHACHHANG.DanhBo and DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.NoiDung like N'Gãy Tay Van' and cast(DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.CreateDate as date)=cast(TB_DULIEUKHACHHANG.GayTayVan_Ngay as date))"
        //        + " from TB_DULIEUKHACHHANG where GayTayVan=1 and CAST(GayTayVan_Ngay as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(GayTayVan_Ngay as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
        //    return _cDAL.ExecuteQuery_DataTable(sql);
        //}

        //public DataTable getDS_TroNgaiThay(DateTime FromCreateDate, DateTime ToCreateDate)
        //{
        //    string sql = "select MLT=LOTRINH,DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Trở Ngại Thay',CREATEDATE=TroNgaiThay_Ngay,Folder='TroNgaiThay'"
        //        + ",ID=(select top 1 ID from DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu where DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.DanhBo=TB_DULIEUKHACHHANG.DanhBo and DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.NoiDung like N'Trở Ngại Thay' and cast(DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.CreateDate as date)=cast(TB_DULIEUKHACHHANG.TroNgaiThay_Ngay as date))"
        //        + " from TB_DULIEUKHACHHANG where TroNgaiThay=1 and CAST(TroNgaiThay_Ngay as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(TroNgaiThay_Ngay as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
        //    return _cDAL.ExecuteQuery_DataTable(sql);
        //}

        //public DataTable getDS_TroNgaiThay(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        //{
        //    string sql = "select MLT=LOTRINH,DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Trở Ngại Thay',CREATEDATE=TroNgaiThay_Ngay,Folder='TroNgaiThay'"
        //        + ",ID=(select top 1 ID from DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu where DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.DanhBo=TB_DULIEUKHACHHANG.DanhBo and DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.NoiDung like N'Trở Ngại Thay' and cast(DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.CreateDate as date)=cast(TB_DULIEUKHACHHANG.TroNgaiThay_Ngay as date))"
        //        + " from TB_DULIEUKHACHHANG where TroNgaiThay=1 and CAST(TroNgaiThay_Ngay as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(TroNgaiThay_Ngay as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
        //    return _cDAL.ExecuteQuery_DataTable(sql);
        //}

        //public DataTable getDS_DauChungMayBom(DateTime FromCreateDate, DateTime ToCreateDate)
        //{
        //    string sql = "select MLT=LOTRINH,DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Đấu Chung Máy Bơm',CREATEDATE=DauChungMayBom_Ngay,Folder='DauChungMayBom'"
        //        + ",ID=(select top 1 ID from DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu where DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.DanhBo=TB_DULIEUKHACHHANG.DanhBo and DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.NoiDung like N'Đấu Chung Máy Bơm' and cast(DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.CreateDate as date)=cast(TB_DULIEUKHACHHANG.DauChungMayBom_Ngay as date))"
        //        + " from TB_DULIEUKHACHHANG where DauChungMayBom=1 and CAST(DauChungMayBom_Ngay as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(DauChungMayBom_Ngay as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
        //    return _cDAL.ExecuteQuery_DataTable(sql);
        //}

        //public DataTable getDS_DauChungMayBom(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        //{
        //    string sql = "select MLT=LOTRINH,DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Đấu Chung Máy Bơm',CREATEDATE=DauChungMayBom_Ngay,Folder='DauChungMayBom'"
        //        + ",ID=(select top 1 ID from DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu where DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.DanhBo=TB_DULIEUKHACHHANG.DanhBo and DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.NoiDung like N'Đấu Chung Máy Bơm' and cast(DocSoTH.dbo.MaHoa_PhieuChuyen_LichSu.CreateDate as date)=cast(TB_DULIEUKHACHHANG.DauChungMayBom_Ngay as date))"
        //        + " from TB_DULIEUKHACHHANG where DauChungMayBom=1 and CAST(DauChungMayBom_Ngay as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(DauChungMayBom_Ngay as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
        //    return _cDAL.ExecuteQuery_DataTable(sql);
        //}

        public DataTable getThongKe_Gieng()
        {
            return _cDAL.ExecuteQuery_DataTable("select MLT=LOTRINH,DanhBo,HoTen,DiaChi=SONHA+' '+TENDUONG,Hieu=HIEUDH,Co=CODH,SoThan=SOTHANDH,Phuong=(select TENPHUONG from PHUONG where MAQUAN=Quan and MAPHUONG=PHUONG),Quan=(select TENQUAN from QUAN where MAQUAN=Quan and MAQUAN=QUAN) from TB_DULIEUKHACHHANG where Gieng=1");
        }

        public DataTable getDS_DiaChiSaiLech(string Dot, string May)
        {
            string sql = "select * from"
+ " (select MLT=LOTRINH,DanhBo,HoTen,DiaChiDHN=SONHA+' '+TENDUONG,GiaBieu,DiaChiHD=(select top 1 SO+' '+DUONG from HOADON_TA.dbo.HOADON"
+ " where DANHBA=TB_DULIEUKHACHHANG.DANHBO order by ID_HOADON desc)"
+ " from TB_DULIEUKHACHHANG where SUBSTRING(LOTRINH,1,2)=" + Dot;
            if (May == "Tất Cả")
                May = "";
            else
                May = " and SUBSTRING(LOTRINH,3,2)=" + May;
            sql += May;
            sql += ")t1 where DiaChiDHN!=DiaChiHD order by MLT";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

    }
}
