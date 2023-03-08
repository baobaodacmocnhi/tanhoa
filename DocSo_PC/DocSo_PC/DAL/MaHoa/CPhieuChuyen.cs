using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocSo_PC.LinQ;
using System.Data;

namespace DocSo_PC.DAL.MaHoa
{
    class CPhieuChuyen:CDAL
    {
        public MaHoa_PhieuChuyen_LichSu get(int ID)
        {
            return _db.MaHoa_PhieuChuyen_LichSus.SingleOrDefault(o => o.ID == ID);
        }

        public List<MaHoa_PhieuChuyen_LichSu> getDS(int SoPhieu)
        {
            return _db.MaHoa_PhieuChuyen_LichSus.Where(o => o.SoPhieu == SoPhieu).ToList();
        }

        public DataTable getDS(string DanhBo)
        {
            DataTable dt = new DataTable();
            dt.Merge(getDS_AmSau(DanhBo));
            dt.Merge(getDS_XayDung(DanhBo));
            dt.Merge(getDS_DutChiGoc(DanhBo));
            dt.Merge(getDS_DutChiThan(DanhBo));
            dt.Merge(getDS_NgapNuoc(DanhBo));
            dt.Merge(getDS_KetTuong(DanhBo));
            dt.Merge(getDS_LapKhoaGoc(DanhBo));
            dt.Merge(getDS_BeHBV(DanhBo));
            dt.Merge(getDS_BeNapMatNapHBV(DanhBo));
            dt.Merge(getDS_GayTayVan(DanhBo));
            dt.Merge(getDS_TroNgaiThay(DanhBo));
            dt.Merge(getDS_DauChungMayBom(DanhBo));
            return dt;
        }

        public DataTable getDS_AmSau(string DanhBo)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Âm Sâu',CREATEDATE=AmSau_Ngay,Folder='AmSau',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Âm Sâu' and a.DanhBo='" + DanhBo + "' order by a.CreateDate desc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_AmSau(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Âm Sâu',CREATEDATE=AmSau_Ngay,Folder='AmSau',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Âm Sâu' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_AmSau(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Âm Sâu',CREATEDATE=AmSau_Ngay,Folder='AmSau',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Âm Sâu' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_XayDung(string DanhBo)
        {
            string sql = " select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Xây Dựng',CREATEDATE=XayDung_Ngay,Folder='XayDung',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Xây Dựng' and a.DanhBo='" + DanhBo + "' order by a.CreateDate desc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_XayDung(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = " select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Xây Dựng',CREATEDATE=XayDung_Ngay,Folder='XayDung',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Xây Dựng' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_XayDung(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = " select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Xây Dựng',CREATEDATE=XayDung_Ngay,Folder='XayDung',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Xây Dựng' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_DutChiGoc(string DanhBo)
        {
            string sql = " select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Đứt Chì Góc',CREATEDATE=DutChi_Goc_Ngay,Folder='DutChi',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Đứt Chì Góc' and a.DanhBo='" + DanhBo + "' order by a.CreateDate desc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_DutChiGoc(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = " select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Đứt Chì Góc',CREATEDATE=DutChi_Goc_Ngay,Folder='DutChi',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Đứt Chì Góc' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_DutChiGoc(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = " select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Đứt Chì Góc',CREATEDATE=DutChi_Goc_Ngay,Folder='DutChi',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Đứt Chì Góc' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_DutChiThan(string DanhBo)
        {
            string sql = " select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Đứt Chì Thân',CREATEDATE=DutChi_Than_Ngay,Folder='DutChi',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Đứt Chì Thân' and a.DanhBo='" + DanhBo + "' order by a.CreateDate desc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_DutChiThan(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = " select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Đứt Chì Thân',CREATEDATE=DutChi_Than_Ngay,Folder='DutChi',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Đứt Chì Thân' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_DutChiThan(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = " select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Đứt Chì Thân',CREATEDATE=DutChi_Than_Ngay,Folder='DutChi',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Đứt Chì Thân' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_NgapNuoc(string DanhBo)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Ngập Nước',CREATEDATE=NgapNuoc_Ngay,Folder='NgapNuoc',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Ngập Nước' and a.DanhBo='" + DanhBo + "' order by a.CreateDate desc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_NgapNuoc(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Ngập Nước',CREATEDATE=NgapNuoc_Ngay,Folder='NgapNuoc',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Ngập Nước' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_NgapNuoc(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Ngập Nước',CREATEDATE=NgapNuoc_Ngay,Folder='NgapNuoc',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Ngập Nước' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_KetTuong(string DanhBo)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Kẹt Tường',CREATEDATE=KetTuong_Ngay,Folder='KetTuong',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Kẹt Tường' and a.DanhBo='" + DanhBo + "' order by a.CreateDate desc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_KetTuong(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Kẹt Tường',CREATEDATE=KetTuong_Ngay,Folder='KetTuong',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Kẹt Tường' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_KetTuong(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Kẹt Tường',CREATEDATE=KetTuong_Ngay,Folder='KetTuong',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Kẹt Tường' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_LapKhoaGoc(string DanhBo)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Lấp Khóa Góc',CREATEDATE=LapKhoaGoc_Ngay,Folder='LapKhoaGoc',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Lấp Khóa Góc' and a.DanhBo='" + DanhBo + "' order by a.CreateDate desc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_LapKhoaGoc(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Lấp Khóa Góc',CREATEDATE=LapKhoaGoc_Ngay,Folder='LapKhoaGoc',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Lấp Khóa Góc' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_LapKhoaGoc(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Lấp Khóa Góc',CREATEDATE=LapKhoaGoc_Ngay,Folder='LapKhoaGoc',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Lấp Khóa Góc' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_BeHBV(string DanhBo)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Bể HBV',CREATEDATE=BeHBV_Ngay,Folder='BeHBV',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Bể HBV' and a.DanhBo='" + DanhBo + "' order by a.CreateDate desc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_BeHBV(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Bể HBV',CREATEDATE=BeHBV_Ngay,Folder='BeHBV',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Bể HBV' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_BeHBV(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Bể HBV',CREATEDATE=BeHBV_Ngay,Folder='BeHBV',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Bể HBV' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_BeNapMatNapHBV(string DanhBo)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Bể Nấp, Mất Nấp HBV',CREATEDATE=BeNapMatNapHBV_Ngay,Folder='BeNapMatNapHBV',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Bể Nấp, Mất Nấp HBV' and a.DanhBo='" + DanhBo + "' order by a.CreateDate desc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_BeNapMatNapHBV(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Bể Nấp, Mất Nấp HBV',CREATEDATE=BeNapMatNapHBV_Ngay,Folder='BeNapMatNapHBV',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Bể Nấp, Mất Nấp HBV' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_BeNapMatNapHBV(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Bể Nấp, Mất Nấp HBV',CREATEDATE=BeNapMatNapHBV_Ngay,Folder='BeNapMatNapHBV',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Bể Nấp, Mất Nấp HBV' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_GayTayVan(string DanhBo)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Gãy Tay Van',CREATEDATE=GayTayVan_Ngay,Folder='GayTayVan',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Gãy Tay Van' and a.DanhBo='" + DanhBo + "' order by a.CreateDate desc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_GayTayVan(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Gãy Tay Van',CREATEDATE=GayTayVan_Ngay,Folder='GayTayVan',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Gãy Tay Van' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_GayTayVan(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Gãy Tay Van',CREATEDATE=GayTayVan_Ngay,Folder='GayTayVan',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Gãy Tay Van' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_TroNgaiThay(string DanhBo)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Trở Ngại Thay',CREATEDATE=TroNgaiThay_Ngay,Folder='TroNgaiThay',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Trở Ngại Thay' and a.DanhBo='" + DanhBo + "' order by a.CreateDate desc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_TroNgaiThay(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Trở Ngại Thay',CREATEDATE=TroNgaiThay_Ngay,Folder='TroNgaiThay',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Trở Ngại Thay' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_TroNgaiThay(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Trở Ngại Thay',CREATEDATE=TroNgaiThay_Ngay,Folder='TroNgaiThay',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Trở Ngại Thay' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_DauChungMayBom(string DanhBo)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Đấu Chung Máy Bơm',CREATEDATE=DauChungMayBom_Ngay,Folder='DauChungMayBom',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Đấu Chung Máy Bơm' and a.DanhBo='" + DanhBo + "' order by a.CreateDate desc";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_DauChungMayBom(DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Đấu Chung Máy Bơm',CREATEDATE=DauChungMayBom_Ngay,Folder='DauChungMayBom',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Đấu Chung Máy Bơm' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "'";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

        public DataTable getDS_DauChungMayBom(int MaTo, DateTime FromCreateDate, DateTime ToCreateDate)
        {
            string sql = "select MLT=LOTRINH,a.DANHBO,HOTEN,DiaChi=SONHA+' '+TENDUONG,NoiDung=N'Đấu Chung Máy Bơm',CREATEDATE=DauChungMayBom_Ngay,Folder='DauChungMayBom',a.ID,a.GhiChu,a.TinhTrang,a.SoPhieu"
                + " from MaHoa_PhieuChuyen_LichSu a,CAPNUOCTANHOA.dbo.TB_DULIEUKHACHHANG b where a.DanhBo=b.DanhBo and NoiDung=N'Đấu Chung Máy Bơm' and CAST(a.CreateDate as date)>='" + FromCreateDate.ToString("yyyyMMdd") + "' and CAST(a.CreateDate as date)<='" + ToCreateDate.ToString("yyyyMMdd") + "' and SUBSTRING(LOTRINH,3,2)>=(select TuMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ") and SUBSTRING(LOTRINH,3,2)<=(select DenMay from DocSoTH.dbo.[To] where MaTo=" + MaTo + ")";
            return _cDAL.ExecuteQuery_DataTable(sql);
        }

    }
}
