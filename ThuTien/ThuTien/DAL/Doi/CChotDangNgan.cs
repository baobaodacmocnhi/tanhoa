﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using System.Data;

namespace ThuTien.DAL.Doi
{
    class CChotDangNgan : CDAL
    {
        public bool them(TT_ChotDangNgan en)
        {
            try
            {
                if (_db.TT_ChotDangNgans.Count() > 0)
                    en.ID = _db.TT_ChotDangNgans.Max(item => item.ID) + 1;
                else
                    en.ID = 1;
                en.CreateBy = CNguoiDung.MaND;
                en.CreateDate = DateTime.Now;
                _db.TT_ChotDangNgans.InsertOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool sua(TT_ChotDangNgan en)
        {
            try
            {
                en.ModifyBy = CNguoiDung.MaND;
                en.ModifyDate = DateTime.Now;
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool xoa(TT_ChotDangNgan en)
        {
            try
            {
                _db.TT_ChotDangNgans.DeleteOnSubmit(en);
                _db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Refresh();
                throw ex;
            }
        }

        public bool checkExist(DateTime NgayChot)
        {
            return _db.TT_ChotDangNgans.Any(item => item.NgayChot.Value.Date == NgayChot.Date);
        }

        public bool checkExist_ChotDangNgan(DateTime NgayChot)
        {
            return _db.TT_ChotDangNgans.Any(item => item.NgayChot.Value.Date == NgayChot.Date && item.Chot == true);
        }

        public TT_ChotDangNgan get(int ID)
        {
            return _db.TT_ChotDangNgans.SingleOrDefault(item => item.ID == ID);
        }

        public DataTable getDS(DateTime FromNgayChot, DateTime ToNgayChot)
        {
            string sql = "select ID,NgayChot,Chot,"
                        + " SLDangNgan=(select COUNT(ID_HOADON) from HOADON where CAST(NGAYGIAITRACH as date)=CAST(NgayChot as date) and MaNV_DangNgan is not null),"
                        + " TCDangNgan=(select SUM(TONGCONG) from HOADON where CAST(NGAYGIAITRACH as date)=CAST(NgayChot as date) and MaNV_DangNgan is not null),"
                        + " SLCNKD=(select COUNT(ID_HOADON) from HOADON where CAST(NGAYGIAITRACH as date)=CAST(NgayChot as date) and ChuyenNoKhoDoi=1),"
                        + " TCCNKD=(select SUM(TONGCONG) from HOADON where CAST(NGAYGIAITRACH as date)=CAST(NgayChot as date) and ChuyenNoKhoDoi=1),"
                        + " SLGiay=(select COUNT(ID_HOADON) from HOADON where CAST(NGAYGIAITRACH as date)=CAST(NgayChot as date) and (NAM<2020 or (NAM=2020 and KY<7)) and MaNV_DangNgan is not null),"
                        + " TCGiay=(select SUM(TONGCONG) from HOADON where CAST(NGAYGIAITRACH as date)=CAST(NgayChot as date) and (NAM<2020 or (NAM=2020 and KY<7)) and MaNV_DangNgan is not null),"
                        + " SLHDDT=(select COUNT(ID_HOADON) from HOADON where CAST(NGAYGIAITRACH as date)=CAST(NgayChot as date) and (NAM>2020 or (NAM=2020 and KY>=7)) and MaNV_DangNgan is not null),"
                        + " TCHDDT=(select SUM(TONGCONG) from HOADON where CAST(NGAYGIAITRACH as date)=CAST(NgayChot as date) and (NAM>2020 or (NAM=2020 and KY>=7)) and MaNV_DangNgan is not null),"
                        + " SLHDDTDC=(select COUNT(ID_HOADON) from HOADON where CAST(NGAYGIAITRACH as date)=CAST(NgayChot as date) and (NAM>2020 or (NAM=2020 and KY>=7)) and MaNV_DangNgan is not null and SoHoaDonCu is not null),"
                        + " TCHDDTDC=(select SUM(TONGCONG) from HOADON where CAST(NGAYGIAITRACH as date)=CAST(NgayChot as date) and (NAM>2020 or (NAM=2020 and KY>=7)) and MaNV_DangNgan is not null and SoHoaDonCu is not null),"
                        + " SLHDDTDCBCT=(select COUNT(ID_HOADON) from HOADON where CAST(NGAYGIAITRACH as date)=CAST(NgayChot as date) and (NAM>2020 or (NAM=2020 and KY>=7)) and MaNV_DangNgan is not null and BaoCaoThue=1),"
                        + " TCHDDTDCBCT=(select SUM(TONGCONG) from HOADON where CAST(NGAYGIAITRACH as date)=CAST(NgayChot as date) and (NAM>2020 or (NAM=2020 and KY>=7)) and MaNV_DangNgan is not null and BaoCaoThue=1),"
                        + " SLHDDTSach=(select COUNT(ID_HOADON) from HOADON where CAST(NGAYGIAITRACH as date)=CAST(NgayChot as date) and (NAM>2020 or (NAM=2020 and KY>=7)) and MaNV_DangNgan is not null and SoHoaDonCu is null and BaoCaoThue=0),"
                        + " TCHDDTSach=(select SUM(TONGCONG) from HOADON where CAST(NGAYGIAITRACH as date)=CAST(NgayChot as date) and (NAM>2020 or (NAM=2020 and KY>=7)) and MaNV_DangNgan is not null and SoHoaDonCu is null and BaoCaoThue=0),"
                        + " SLNopTien=(select COUNT(ID_HOADON) from HOADON where CAST(NGAYGIAITRACH as date)=CAST(NgayChot as date) and SyncNopTien=1),"
                        + " TCNopTien=(select SUM(TONGCONG) from HOADON where CAST(NGAYGIAITRACH as date)=CAST(NgayChot as date) and SyncNopTien=1)"
                        + " from TT_ChotDangNgan where CAST(NgayChot as date)>='" + FromNgayChot.ToString("yyyyMMdd") + "' and CAST(NgayChot as date)<='" + ToNgayChot.ToString("yyyyMMdd") + "'"
                        + " group by ID,NgayChot,Chot order by ID desc";
            return ExecuteQuery_DataTable(sql);
        }

    }
}
