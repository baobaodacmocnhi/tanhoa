﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.DAL.CallCenter
{
    class CKinhDoanh
    {
        dbKinhDoanhDataContext db = new dbKinhDoanhDataContext();

        public static DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();

            // column names 
            PropertyInfo[] oProps = null;

            if (varlist == null) return dtReturn;

            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow 
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }

                DataRow dr = dtReturn.NewRow();

                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);
                }

                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }


        public DataSet GetTienTrinhByDanhBo(string DanhBo)
        {
            try
            {
                DataSet ds = new DataSet();

                #region DanhBo
                ///trường hợp đơn danh bộ cần tìm kiếm nhưng lại xử lý danh bộ khác
                ///Table CTKTXM
                var queryKTXM = from itemCTKTXM in db.KTXM_ChiTiets
                                join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                where itemCTKTXM.DanhBo == DanhBo || (itemCTKTXM.KTXM.DonKH.DanhBo == DanhBo || itemCTKTXM.KTXM.DonTXL.DanhBo == DanhBo || itemCTKTXM.KTXM.DonTBC.DanhBo == DanhBo)
                                select new
                                {
                                    MaDon = itemCTKTXM.KTXM.MaDon != null ? "TKH" + itemCTKTXM.KTXM.MaDon
                                    : itemCTKTXM.KTXM.MaDonTXL != null ? "TXL" + itemCTKTXM.KTXM.MaDonTXL
                                    : itemCTKTXM.KTXM.MaDonTBC != null ? "TBC" + itemCTKTXM.KTXM.MaDonTBC : null,
                                    itemCTKTXM.MaCTKTXM,
                                    itemCTKTXM.NgayKTXM,
                                    itemCTKTXM.DanhBo,
                                    itemCTKTXM.HoTen,
                                    itemCTKTXM.DiaChi,
                                    itemCTKTXM.NoiDungKiemTra,
                                    CreateBy = itemUser.HoTen,
                                    itemCTKTXM.NoiDungDongTien,
                                    itemCTKTXM.NgayDongTien,
                                    itemCTKTXM.SoTienDongTien,
                                };
                DataTable dtKTXM = new DataTable();
                dtKTXM = LINQToDataTable(queryKTXM);
                dtKTXM.TableName = "KTXM";
                ds.Tables.Add(dtKTXM);

                ///Table CTBamChi
                var queryBamChi = from itemCTBamChi in db.BamChi_ChiTiets
                                  join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                                  where itemCTBamChi.DanhBo == DanhBo || (itemCTBamChi.BamChi.DonKH.DanhBo == DanhBo || itemCTBamChi.BamChi.DonTXL.DanhBo == DanhBo || itemCTBamChi.BamChi.DonTBC.DanhBo == DanhBo)
                                  select new
                                  {
                                      MaDon = itemCTBamChi.BamChi.MaDon != null ? "TKH" + itemCTBamChi.BamChi.MaDon
                                    : itemCTBamChi.BamChi.MaDonTXL != null ? "TXL" + itemCTBamChi.BamChi.MaDonTXL
                                    : itemCTBamChi.BamChi.MaDonTBC != null ? "TBC" + itemCTBamChi.BamChi.MaDonTBC : null,
                                      itemCTBamChi.MaCTBC,
                                      itemCTBamChi.NgayBC,
                                      itemCTBamChi.DanhBo,
                                      itemCTBamChi.HoTen,
                                      itemCTBamChi.DiaChi,
                                      itemCTBamChi.TrangThaiBC,
                                      itemCTBamChi.TheoYeuCau,
                                      itemCTBamChi.MaSoBC,
                                      CreateBy = itemUser.HoTen,
                                  };

                DataTable dtBamChi = new DataTable();
                dtBamChi = LINQToDataTable(queryBamChi);
                dtBamChi.TableName = "BamChi";
                ds.Tables.Add(dtBamChi);

                ///Table CTDongNuoc
                var queryDongNuoc = from itemCTDongNuoc in db.DongNuoc_ChiTiets
                                    join itemUser in db.Users on itemCTDongNuoc.CreateBy equals itemUser.MaU
                                    where itemCTDongNuoc.DanhBo == DanhBo || (itemCTDongNuoc.DongNuoc.DonKH.DanhBo == DanhBo || itemCTDongNuoc.DongNuoc.DonTXL.DanhBo == DanhBo || itemCTDongNuoc.DongNuoc.DonTBC.DanhBo == DanhBo)
                                    select new
                                    {
                                        MaDon = itemCTDongNuoc.DongNuoc.MaDon != null ? "TKH" + itemCTDongNuoc.DongNuoc.MaDon
                                    : itemCTDongNuoc.DongNuoc.MaDonTXL != null ? "TXL" + itemCTDongNuoc.DongNuoc.MaDonTXL
                                    : itemCTDongNuoc.DongNuoc.MaDonTBC != null ? "TBC" + itemCTDongNuoc.DongNuoc.MaDonTBC : null,
                                        itemCTDongNuoc.MaCTDN,
                                        itemCTDongNuoc.NgayDN,
                                        itemCTDongNuoc.DanhBo,
                                        itemCTDongNuoc.HoTen,
                                        itemCTDongNuoc.DiaChi,
                                        itemCTDongNuoc.MaCTMN,
                                        itemCTDongNuoc.NgayMN,
                                        CreateBy = itemUser.HoTen,
                                    };

                DataTable dtDongNuoc = new DataTable();
                dtDongNuoc = LINQToDataTable(queryDongNuoc);
                dtDongNuoc.TableName = "DongNuoc";
                ds.Tables.Add(dtDongNuoc);

                ///Table CTDCBD
                var queryCTDCBD = from itemCTDCBD in db.DCBD_ChiTietBienDongs
                                  join itemUser in db.Users on itemCTDCBD.CreateBy equals itemUser.MaU
                                  where itemCTDCBD.DanhBo == DanhBo || (itemCTDCBD.DCBD.DonKH.DanhBo == DanhBo || itemCTDCBD.DCBD.DonTXL.DanhBo == DanhBo || itemCTDCBD.DCBD.DonTBC.DanhBo == DanhBo)
                                  select new
                                  {
                                      MaDon = itemCTDCBD.DCBD.MaDon != null ? "TKH" + itemCTDCBD.DCBD.MaDon
                                    : itemCTDCBD.DCBD.MaDonTXL != null ? "TXL" + itemCTDCBD.DCBD.MaDonTXL
                                    : itemCTDCBD.DCBD.MaDonTBC != null ? "TBC" + itemCTDCBD.DCBD.MaDonTBC : null,
                                      MaDC = itemCTDCBD.MaCTDCBD,
                                      DieuChinh = "Biến Động",
                                      itemCTDCBD.CreateDate,
                                      itemCTDCBD.ThongTin,
                                      itemCTDCBD.DanhBo,
                                      itemCTDCBD.HoTen_BD,
                                      itemCTDCBD.DiaChi_BD,
                                      itemCTDCBD.MSThue_BD,
                                      itemCTDCBD.GiaBieu_BD,
                                      itemCTDCBD.DinhMuc_BD,
                                      itemCTDCBD.HoTen,
                                      itemCTDCBD.DiaChi,
                                      itemCTDCBD.MSThue,
                                      itemCTDCBD.GiaBieu,
                                      itemCTDCBD.DinhMuc,
                                      CreateBy = itemUser.HoTen,
                                  };

                ///Bảng CTDCHD
                var queryCTDCHD = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                                  join itemUser in db.Users on itemCTDCHD.CreateBy equals itemUser.MaU
                                  where itemCTDCHD.DanhBo == DanhBo || (itemCTDCHD.DCBD.DonKH.DanhBo == DanhBo || itemCTDCHD.DCBD.DonTXL.DanhBo == DanhBo || itemCTDCHD.DCBD.DonTBC.DanhBo == DanhBo)
                                  select new
                                  {
                                      MaDon = itemCTDCHD.DCBD.MaDon != null ? "TKH" + itemCTDCHD.DCBD.MaDon
                                    : itemCTDCHD.DCBD.MaDonTXL != null ? "TXL" + itemCTDCHD.DCBD.MaDonTXL
                                    : itemCTDCHD.DCBD.MaDonTBC != null ? "TBC" + itemCTDCHD.DCBD.MaDonTBC : null,
                                      MaDC = itemCTDCHD.MaCTDCHD,
                                      DieuChinh = "Hóa Đơn",
                                      itemCTDCHD.CreateDate,
                                      itemCTDCHD.DanhBo,
                                      itemCTDCHD.HoTen,
                                      itemCTDCHD.DiaChi,
                                      itemCTDCHD.GiaBieu,
                                      itemCTDCHD.GiaBieu_BD,
                                      itemCTDCHD.DinhMuc,
                                      itemCTDCHD.DinhMuc_BD,
                                      itemCTDCHD.TieuThu,
                                      itemCTDCHD.TieuThu_BD,
                                      itemCTDCHD.TongCong_Start,
                                      itemCTDCHD.TongCong_End,
                                      itemCTDCHD.TangGiam,
                                      itemCTDCHD.TongCong_BD,
                                      CreateBy = itemUser.HoTen,
                                  };
                DataTable dtDCBD = new DataTable();
                dtDCBD = LINQToDataTable(queryCTDCBD);
                dtDCBD.Merge(LINQToDataTable(queryCTDCHD));
                dtDCBD.TableName = "DCBD";
                ds.Tables.Add(dtDCBD);

                ///Table CTCTDB
                var queryCTCTDB = from itemCTCTDB in db.CHDB_ChiTietCatTams
                                  where itemCTCTDB.DanhBo == DanhBo || (itemCTCTDB.CHDB.DonKH.DanhBo == DanhBo || itemCTCTDB.CHDB.DonTXL.DanhBo == DanhBo || itemCTCTDB.CHDB.DonTBC.DanhBo == DanhBo)
                                  select new
                                  {
                                      MaDon = itemCTCTDB.CHDB.MaDon != null ? "TKH" + itemCTCTDB.CHDB.MaDon
                                    : itemCTCTDB.CHDB.MaDonTXL != null ? "TXL" + itemCTCTDB.CHDB.MaDonTXL
                                    : itemCTCTDB.CHDB.MaDonTBC != null ? "TBC" + itemCTCTDB.CHDB.MaDonTBC : null,
                                      MaCH = itemCTCTDB.MaCTCTDB,
                                      LoaiCat = "Cắt Tạm",
                                      itemCTCTDB.CreateDate,
                                      itemCTCTDB.DanhBo,
                                      itemCTCTDB.HoTen,
                                      itemCTCTDB.DiaChi,
                                      itemCTCTDB.LyDo,
                                      itemCTCTDB.GhiChuLyDo,
                                      itemCTCTDB.DaLapPhieu,
                                      itemCTCTDB.SoPhieu,
                                      itemCTCTDB.NgayLapPhieu,
                                  };

                ///Table CTCHDB
                var queryCTCHDB = from itemCTCHDB in db.CHDB_ChiTietCatHuys
                                  where itemCTCHDB.DanhBo == DanhBo || (itemCTCHDB.CHDB.DonKH.DanhBo == DanhBo || itemCTCHDB.CHDB.DonTXL.DanhBo == DanhBo || itemCTCHDB.CHDB.DonTBC.DanhBo == DanhBo)
                                  select new
                                  {
                                      MaDon = itemCTCHDB.CHDB.MaDon != null ? "TKH" + itemCTCHDB.CHDB.MaDon
                                    : itemCTCHDB.CHDB.MaDonTXL != null ? "TXL" + itemCTCHDB.CHDB.MaDonTXL
                                    : itemCTCHDB.CHDB.MaDonTBC != null ? "TBC" + itemCTCHDB.CHDB.MaDonTBC : null,
                                      MaCH = itemCTCHDB.MaCTCHDB,
                                      LoaiCat = "Cắt Hủy",
                                      itemCTCHDB.CreateDate,
                                      itemCTCHDB.DanhBo,
                                      itemCTCHDB.HoTen,
                                      itemCTCHDB.DiaChi,
                                      itemCTCHDB.LyDo,
                                      itemCTCHDB.GhiChuLyDo,
                                      itemCTCHDB.DaLapPhieu,
                                      itemCTCHDB.SoPhieu,
                                      itemCTCHDB.NgayLapPhieu,
                                  };
                DataTable dtCHDB = new DataTable();
                dtCHDB = LINQToDataTable(queryCTCTDB);
                dtCHDB.Merge(LINQToDataTable(queryCTCHDB));
                dtCHDB.TableName = "CHDB";
                ds.Tables.Add(dtCHDB);

                ///Table PhieuCHDB
                var queryYCCHDB = from itemYCCHDB in db.CHDB_Phieus
                                  where itemYCCHDB.DanhBo == DanhBo || (itemYCCHDB.CHDB.DonKH.DanhBo == DanhBo || itemYCCHDB.CHDB.DonTXL.DanhBo == DanhBo || itemYCCHDB.CHDB.DonTBC.DanhBo == DanhBo)
                                  select new
                                  {
                                      MaDon = itemYCCHDB.MaDon != null ? "TKH" + itemYCCHDB.MaDonTXL
                                    : itemYCCHDB.MaDonTXL != null ? "TXL" + itemYCCHDB.MaDonTXL
                                    : itemYCCHDB.MaDonTBC != null ? "TBC" + itemYCCHDB.MaDonTBC : null,
                                      itemYCCHDB.MaYCCHDB,
                                      itemYCCHDB.CreateDate,
                                      itemYCCHDB.DanhBo,
                                      itemYCCHDB.HoTen,
                                      itemYCCHDB.DiaChi,
                                      itemYCCHDB.LyDo,
                                      itemYCCHDB.GhiChuLyDo,
                                      itemYCCHDB.HieuLucKy,
                                  };

                DataTable dtYCCHDB = new DataTable();
                dtYCCHDB = LINQToDataTable(queryYCCHDB);
                dtYCCHDB.TableName = "YCCHDB";
                ds.Tables.Add(dtYCCHDB);

                ///Table TTTL_ChiTiet
                var queryTTTL = from itemCTTTTL in db.ThuTraLoi_ChiTiets
                                where itemCTTTTL.DanhBo == DanhBo || (itemCTTTTL.ThuTraLoi.DonKH.DanhBo == DanhBo || itemCTTTTL.ThuTraLoi.DonTXL.DanhBo == DanhBo || itemCTTTTL.ThuTraLoi.DonTBC.DanhBo == DanhBo)
                                select new
                                {
                                    MaDon = itemCTTTTL.ThuTraLoi.MaDon != null ? "TKH" + itemCTTTTL.ThuTraLoi.MaDon
                                    : itemCTTTTL.ThuTraLoi.MaDonTXL != null ? "TXL" + itemCTTTTL.ThuTraLoi.MaDonTXL
                                    : itemCTTTTL.ThuTraLoi.MaDonTBC != null ? "TBC" + itemCTTTTL.ThuTraLoi.MaDonTBC : null,
                                    itemCTTTTL.MaCTTTTL,
                                    itemCTTTTL.CreateDate,
                                    itemCTTTTL.DanhBo,
                                    itemCTTTTL.HoTen,
                                    itemCTTTTL.DiaChi,
                                    itemCTTTTL.VeViec,
                                    itemCTTTTL.NoiDung,
                                    itemCTTTTL.NoiNhan,
                                };
                DataTable dtTTTL = new DataTable();
                dtTTTL = LINQToDataTable(queryTTTL);
                dtTTTL.TableName = "ThuTraLoi";
                ds.Tables.Add(dtTTTL);

                ///Table GianLan
                var queryGianLan = from itemGL in db.GianLan_ChiTiets
                                   where itemGL.DanhBo == DanhBo || (itemGL.GianLan.DonKH.DanhBo == DanhBo || itemGL.GianLan.DonTXL.DanhBo == DanhBo || itemGL.GianLan.DonTBC.DanhBo == DanhBo)
                                   select new
                                   {
                                       MaDon = itemGL.GianLan.MaDon != null ? "TKH" + itemGL.GianLan.MaDon
                                       : itemGL.GianLan.MaDonTXL != null ? "TXL" + itemGL.GianLan.MaDonTXL
                                       : itemGL.GianLan.MaDonTBC != null ? "TBC" + itemGL.GianLan.MaDonTBC : null,
                                       ID=itemGL.MaCTGL,
                                       itemGL.CreateDate,
                                       itemGL.DanhBo,
                                       itemGL.HoTen,
                                       itemGL.DiaChi,
                                       itemGL.NoiDungViPham,
                                       itemGL.TinhTrang,
                                       itemGL.XepDon,
                                   };
                DataTable dtGianLan = new DataTable();
                dtGianLan = LINQToDataTable(queryGianLan);
                dtGianLan.TableName = "GianLan";
                ds.Tables.Add(dtGianLan);

                #endregion

                #region DonKH

                ///Table DonKH
                var queryDonKH = from itemDon in db.DonKHs
                                 where itemDon.DanhBo == DanhBo
                                 select new
                                 {
                                     MaDon = "TKH" + itemDon.MaDon,
                                     itemDon.LoaiDon.TenLD,
                                     itemDon.CreateDate,
                                     itemDon.DanhBo,
                                     itemDon.HoTen,
                                     itemDon.DiaChi,
                                     itemDon.GiaBieu,
                                     itemDon.DinhMuc,
                                     itemDon.NoiDung,
                                 };
                DataTable dt = new DataTable();
                dt = LINQToDataTable(queryDonKH);

                ///Table KTXM_ChiTiets
                queryDonKH = from itemDon in db.DonKHs
                             join itemCTKTXM in db.KTXM_ChiTiets on itemDon.MaDon equals itemCTKTXM.KTXM.MaDon
                             where itemCTKTXM.DanhBo == DanhBo
                             select new
                             {
                                 MaDon = "TKH" + itemDon.MaDon,
                                 itemDon.LoaiDon.TenLD,
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 itemDon.NoiDung,
                             };
                dt.Merge(LINQToDataTable(queryDonKH));

                ///Table BamChi_ChiTiets
                queryDonKH = from itemDon in db.DonKHs
                             join itemCTBamChi in db.BamChi_ChiTiets on itemDon.MaDon equals itemCTBamChi.BamChi.MaDon
                             where itemCTBamChi.DanhBo == DanhBo
                             select new
                             {
                                 MaDon = "TKH" + itemDon.MaDon,
                                 itemDon.LoaiDon.TenLD,
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 itemDon.NoiDung,
                             };
                dt.Merge(LINQToDataTable(queryDonKH));

                ///Table DCBD_ChiTietBienDongs
                queryDonKH = from itemDon in db.DonKHs
                             join itemCTDCBD in db.DCBD_ChiTietBienDongs on itemDon.MaDon equals itemCTDCBD.DCBD.MaDon
                             where itemCTDCBD.DanhBo == DanhBo
                             select new
                             {
                                 MaDon = "TKH" + itemDon.MaDon,
                                 itemDon.LoaiDon.TenLD,
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 itemDon.NoiDung,
                             };
                dt.Merge(LINQToDataTable(queryDonKH));

                ///Table DCBD_ChiTietHoaDons
                queryDonKH = from itemDon in db.DonKHs
                             join itemCTDCHD in db.DCBD_ChiTietHoaDons on itemDon.MaDon equals itemCTDCHD.DCBD.MaDon
                             where itemCTDCHD.DanhBo == DanhBo
                             select new
                             {
                                 MaDon = "TKH" + itemDon.MaDon,
                                 itemDon.LoaiDon.TenLD,
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 itemDon.NoiDung,
                             };
                dt.Merge(LINQToDataTable(queryDonKH));

                ///Table CHDB_ChiTietCatTams
                queryDonKH = from itemDon in db.DonKHs
                             join itemCTCTDB in db.CHDB_ChiTietCatTams on itemDon.MaDon equals itemCTCTDB.CHDB.MaDon
                             where itemCTCTDB.DanhBo == DanhBo
                             select new
                             {
                                 MaDon = "TKH" + itemDon.MaDon,
                                 itemDon.LoaiDon.TenLD,
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 itemDon.NoiDung,
                             };
                dt.Merge(LINQToDataTable(queryDonKH));

                ///Table CHDB_ChiTietCatHuys
                queryDonKH = from itemDon in db.DonKHs
                             join itemCTCHDB in db.CHDB_ChiTietCatHuys on itemDon.MaDon equals itemCTCHDB.CHDB.MaDon
                             where itemCTCHDB.DanhBo == DanhBo
                             select new
                             {
                                 MaDon = "TKH" + itemDon.MaDon,
                                 itemDon.LoaiDon.TenLD,
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 itemDon.NoiDung,
                             };
                dt.Merge(LINQToDataTable(queryDonKH));

                ///TablePhieuCHDBs
                queryDonKH = from itemDon in db.DonKHs
                             join itemYCCHDB in db.CHDB_Phieus on itemDon.MaDon equals itemYCCHDB.MaDon
                             where itemYCCHDB.DanhBo == DanhBo
                             select new
                             {
                                 MaDon = "TKH" + itemDon.MaDon,
                                 itemDon.LoaiDon.TenLD,
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 itemDon.NoiDung,
                             };
                dt.Merge(LINQToDataTable(queryDonKH));

                ///Table ThuTraLoi_ChiTiets
                queryDonKH = from itemDon in db.DonKHs
                             join itemCTTTTL in db.ThuTraLoi_ChiTiets on itemDon.MaDon equals itemCTTTTL.ThuTraLoi.MaDon
                             where itemCTTTTL.DanhBo == DanhBo
                             select new
                             {
                                 MaDon = "TKH" + itemDon.MaDon,
                                 itemDon.LoaiDon.TenLD,
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 itemDon.NoiDung,
                             };
                dt.Merge(LINQToDataTable(queryDonKH));

                ///Table DongNuoc_ChiTiets
                queryDonKH = from itemDon in db.DonKHs
                             join itemCTDongNuoc in db.DongNuoc_ChiTiets on itemDon.MaDon equals itemCTDongNuoc.DongNuoc.MaDon
                             where itemCTDongNuoc.DanhBo == DanhBo
                             select new
                             {
                                 MaDon = "TKH" + itemDon.MaDon,
                                 itemDon.LoaiDon.TenLD,
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 itemDon.NoiDung,
                             };
                dt.Merge(LINQToDataTable(queryDonKH));

                ///Table GianLan_ChiTiets
                queryDonKH = from itemDon in db.DonKHs
                             join itemGL in db.GianLan_ChiTiets on itemDon.MaDon equals itemGL.GianLan.MaDon
                             where itemGL.DanhBo == DanhBo
                             select new
                             {
                                 MaDon = "TKH" + itemDon.MaDon,
                                 itemDon.LoaiDon.TenLD,
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 itemDon.NoiDung,
                             };
                dt.Merge(LINQToDataTable(queryDonKH));

                #endregion

                #region DonTXL

                ///Table DonTXL
                var queryDonTXL = from itemDonTXL in db.DonTXLs
                                  where itemDonTXL.DanhBo == DanhBo
                                  select new
                                  {
                                      MaDon = "TXL" + itemDonTXL.MaDon,
                                      itemDonTXL.LoaiDonTXL.TenLD,
                                      itemDonTXL.CreateDate,
                                      itemDonTXL.DanhBo,
                                      itemDonTXL.HoTen,
                                      itemDonTXL.DiaChi,
                                      itemDonTXL.GiaBieu,
                                      itemDonTXL.DinhMuc,
                                      itemDonTXL.NoiDung,
                                  };
                dt.Merge(LINQToDataTable(queryDonTXL));

                ///Table KTXM_ChiTiets
                queryDonTXL = from itemDonTXL in db.DonTXLs
                              join itemCTKTXM in db.KTXM_ChiTiets on itemDonTXL.MaDon equals itemCTKTXM.KTXM.MaDonTXL
                              where itemCTKTXM.DanhBo == DanhBo
                              select new
                              {
                                  MaDon = "TXL" + itemDonTXL.MaDon,
                                  itemDonTXL.LoaiDonTXL.TenLD,
                                  itemDonTXL.CreateDate,
                                  itemDonTXL.DanhBo,
                                  itemDonTXL.HoTen,
                                  itemDonTXL.DiaChi,
                                  itemDonTXL.GiaBieu,
                                  itemDonTXL.DinhMuc,
                                  itemDonTXL.NoiDung,
                              };
                dt.Merge(LINQToDataTable(queryDonTXL));

                ///Table BamChi_ChiTiets
                queryDonTXL = from itemDonTXL in db.DonTXLs
                              join itemCTBamChi in db.BamChi_ChiTiets on itemDonTXL.MaDon equals itemCTBamChi.BamChi.MaDonTXL
                              where itemCTBamChi.DanhBo == DanhBo
                              select new
                              {
                                  MaDon = "TXL" + itemDonTXL.MaDon,
                                  itemDonTXL.LoaiDonTXL.TenLD,
                                  itemDonTXL.CreateDate,
                                  itemDonTXL.DanhBo,
                                  itemDonTXL.HoTen,
                                  itemDonTXL.DiaChi,
                                  itemDonTXL.GiaBieu,
                                  itemDonTXL.DinhMuc,
                                  itemDonTXL.NoiDung,
                              };
                dt.Merge(LINQToDataTable(queryDonTXL));

                ///Table DCBD_ChiTietBienDongs
                queryDonTXL = from itemDonTXL in db.DonTXLs
                              join itemCTDCBD in db.DCBD_ChiTietBienDongs on itemDonTXL.MaDon equals itemCTDCBD.DCBD.MaDonTXL
                              where itemCTDCBD.DanhBo == DanhBo
                              select new
                              {
                                  MaDon = "TXL" + itemDonTXL.MaDon,
                                  itemDonTXL.LoaiDonTXL.TenLD,
                                  itemDonTXL.CreateDate,
                                  itemDonTXL.DanhBo,
                                  itemDonTXL.HoTen,
                                  itemDonTXL.DiaChi,
                                  itemDonTXL.GiaBieu,
                                  itemDonTXL.DinhMuc,
                                  itemDonTXL.NoiDung,
                              };
                dt.Merge(LINQToDataTable(queryDonTXL));

                ///Table DCBD_ChiTietHoaDons
                queryDonTXL = from itemDonTXL in db.DonTXLs
                              join itemCTDCHD in db.DCBD_ChiTietHoaDons on itemDonTXL.MaDon equals itemCTDCHD.DCBD.MaDonTXL
                              where itemCTDCHD.DanhBo == DanhBo
                              select new
                              {
                                  MaDon = "TXL" + itemDonTXL.MaDon,
                                  itemDonTXL.LoaiDonTXL.TenLD,
                                  itemDonTXL.CreateDate,
                                  itemDonTXL.DanhBo,
                                  itemDonTXL.HoTen,
                                  itemDonTXL.DiaChi,
                                  itemDonTXL.GiaBieu,
                                  itemDonTXL.DinhMuc,
                                  itemDonTXL.NoiDung,
                              };
                dt.Merge(LINQToDataTable(queryDonTXL));

                ///Table CHDB_ChiTietCatTams
                queryDonTXL = from itemDonTXL in db.DonTXLs
                              join itemCTCTDB in db.CHDB_ChiTietCatTams on itemDonTXL.MaDon equals itemCTCTDB.CHDB.MaDonTXL
                              where itemCTCTDB.DanhBo == DanhBo
                              select new
                              {
                                  MaDon = "TXL" + itemDonTXL.MaDon,
                                  itemDonTXL.LoaiDonTXL.TenLD,
                                  itemDonTXL.CreateDate,
                                  itemDonTXL.DanhBo,
                                  itemDonTXL.HoTen,
                                  itemDonTXL.DiaChi,
                                  itemDonTXL.GiaBieu,
                                  itemDonTXL.DinhMuc,
                                  itemDonTXL.NoiDung,
                              };
                dt.Merge(LINQToDataTable(queryDonTXL));

                ///Table CHDB_ChiTietCatHuys
                queryDonTXL = from itemDonTXL in db.DonTXLs
                              join itemCTCHDB in db.CHDB_ChiTietCatHuys on itemDonTXL.MaDon equals itemCTCHDB.CHDB.MaDonTXL
                              where itemCTCHDB.DanhBo == DanhBo
                              select new
                              {
                                  MaDon = "TXL" + itemDonTXL.MaDon,
                                  itemDonTXL.LoaiDonTXL.TenLD,
                                  itemDonTXL.CreateDate,
                                  itemDonTXL.DanhBo,
                                  itemDonTXL.HoTen,
                                  itemDonTXL.DiaChi,
                                  itemDonTXL.GiaBieu,
                                  itemDonTXL.DinhMuc,
                                  itemDonTXL.NoiDung,
                              };
                dt.Merge(LINQToDataTable(queryDonTXL));

                ///Table CHDB_Phieus
                queryDonTXL = from itemDonTXL in db.DonTXLs
                              join itemYCCHDB in db.CHDB_Phieus on itemDonTXL.MaDon equals itemYCCHDB.MaDonTXL
                              where itemYCCHDB.DanhBo == DanhBo
                              select new
                              {
                                  MaDon = "TXL" + itemDonTXL.MaDon,
                                  itemDonTXL.LoaiDonTXL.TenLD,
                                  itemDonTXL.CreateDate,
                                  itemDonTXL.DanhBo,
                                  itemDonTXL.HoTen,
                                  itemDonTXL.DiaChi,
                                  itemDonTXL.GiaBieu,
                                  itemDonTXL.DinhMuc,
                                  itemDonTXL.NoiDung,
                              };
                dt.Merge(LINQToDataTable(queryDonTXL));

                ///Table ThuTraLoi_ChiTiets
                queryDonTXL = from itemDonTXL in db.DonTXLs
                              join itemCTTTTL in db.ThuTraLoi_ChiTiets on itemDonTXL.MaDon equals itemCTTTTL.ThuTraLoi.MaDonTXL
                              where itemCTTTTL.DanhBo == DanhBo
                              select new
                              {
                                  MaDon = "TXL" + itemDonTXL.MaDon,
                                  itemDonTXL.LoaiDonTXL.TenLD,
                                  itemDonTXL.CreateDate,
                                  itemDonTXL.DanhBo,
                                  itemDonTXL.HoTen,
                                  itemDonTXL.DiaChi,
                                  itemDonTXL.GiaBieu,
                                  itemDonTXL.DinhMuc,
                                  itemDonTXL.NoiDung,
                              };
                dt.Merge(LINQToDataTable(queryDonTXL));

                ///Table DongNuoc_ChiTiets
                queryDonTXL = from itemDonTXL in db.DonTXLs
                              join itemCTDongNuoc in db.DongNuoc_ChiTiets on itemDonTXL.MaDon equals itemCTDongNuoc.DongNuoc.MaDonTXL
                              where itemCTDongNuoc.DanhBo == DanhBo
                              select new
                              {
                                  MaDon = "TXL" + itemDonTXL.MaDon,
                                  itemDonTXL.LoaiDonTXL.TenLD,
                                  itemDonTXL.CreateDate,
                                  itemDonTXL.DanhBo,
                                  itemDonTXL.HoTen,
                                  itemDonTXL.DiaChi,
                                  itemDonTXL.GiaBieu,
                                  itemDonTXL.DinhMuc,
                                  itemDonTXL.NoiDung,
                              };
                dt.Merge(LINQToDataTable(queryDonTXL));

                ///Table GianLan_ChiTiets
                queryDonTXL = from itemDonTXL in db.DonTXLs
                              join itemGL in db.GianLan_ChiTiets on itemDonTXL.MaDon equals itemGL.GianLan.MaDonTXL
                              where itemGL.DanhBo == DanhBo
                              select new
                              {
                                  MaDon = "TXL" + itemDonTXL.MaDon,
                                  itemDonTXL.LoaiDonTXL.TenLD,
                                  itemDonTXL.CreateDate,
                                  itemDonTXL.DanhBo,
                                  itemDonTXL.HoTen,
                                  itemDonTXL.DiaChi,
                                  itemDonTXL.GiaBieu,
                                  itemDonTXL.DinhMuc,
                                  itemDonTXL.NoiDung,
                              };
                dt.Merge(LINQToDataTable(queryDonTXL));

                #endregion

                #region DonTBC

                ///Table DonTBC
                var queryDonTBC = from itemDon in db.DonTBCs
                                  where itemDon.DanhBo == DanhBo
                                  select new
                                  {
                                      MaDon = "TBC" + itemDon.MaDon,
                                      itemDon.LoaiDonTBC.TenLD,
                                      itemDon.CreateDate,
                                      itemDon.DanhBo,
                                      itemDon.HoTen,
                                      itemDon.DiaChi,
                                      itemDon.GiaBieu,
                                      itemDon.DinhMuc,
                                      itemDon.NoiDung,
                                  };
                dt.Merge(LINQToDataTable(queryDonTBC));

                ///Table KTXM_ChiTiets
                queryDonTBC = from itemDon in db.DonTBCs
                              join itemCTKTXM in db.KTXM_ChiTiets on itemDon.MaDon equals itemCTKTXM.KTXM.MaDonTBC
                              where itemCTKTXM.DanhBo == DanhBo
                              select new
                              {
                                  MaDon = "TBC" + itemDon.MaDon,
                                  itemDon.LoaiDonTBC.TenLD,
                                  itemDon.CreateDate,
                                  itemDon.DanhBo,
                                  itemDon.HoTen,
                                  itemDon.DiaChi,
                                  itemDon.GiaBieu,
                                  itemDon.DinhMuc,
                                  itemDon.NoiDung,
                              };
                dt.Merge(LINQToDataTable(queryDonTBC));

                ///Table BamChi_ChiTiets
                queryDonTBC = from itemDon in db.DonTBCs
                              join itemCTBamChi in db.BamChi_ChiTiets on itemDon.MaDon equals itemCTBamChi.BamChi.MaDonTBC
                              where itemCTBamChi.DanhBo == DanhBo
                              select new
                              {
                                  MaDon = "TBC" + itemDon.MaDon,
                                  itemDon.LoaiDonTBC.TenLD,
                                  itemDon.CreateDate,
                                  itemDon.DanhBo,
                                  itemDon.HoTen,
                                  itemDon.DiaChi,
                                  itemDon.GiaBieu,
                                  itemDon.DinhMuc,
                                  itemDon.NoiDung,
                              };
                dt.Merge(LINQToDataTable(queryDonTBC));

                ///Table DCBD_ChiTietBienDongs
                queryDonTBC = from itemDon in db.DonTBCs
                              join itemCTDCBD in db.DCBD_ChiTietBienDongs on itemDon.MaDon equals itemCTDCBD.DCBD.MaDonTBC
                              where itemCTDCBD.DanhBo == DanhBo
                              select new
                              {
                                  MaDon = "TBC" + itemDon.MaDon,
                                  itemDon.LoaiDonTBC.TenLD,
                                  itemDon.CreateDate,
                                  itemDon.DanhBo,
                                  itemDon.HoTen,
                                  itemDon.DiaChi,
                                  itemDon.GiaBieu,
                                  itemDon.DinhMuc,
                                  itemDon.NoiDung,
                              };
                dt.Merge(LINQToDataTable(queryDonTBC));

                ///Table DCBD_ChiTietHoaDons
                queryDonTBC = from itemDon in db.DonTBCs
                              join itemCTDCHD in db.DCBD_ChiTietHoaDons on itemDon.MaDon equals itemCTDCHD.DCBD.MaDonTBC
                              where itemCTDCHD.DanhBo == DanhBo
                              select new
                              {
                                  MaDon = "TBC" + itemDon.MaDon,
                                  itemDon.LoaiDonTBC.TenLD,
                                  itemDon.CreateDate,
                                  itemDon.DanhBo,
                                  itemDon.HoTen,
                                  itemDon.DiaChi,
                                  itemDon.GiaBieu,
                                  itemDon.DinhMuc,
                                  itemDon.NoiDung,
                              };
                dt.Merge(LINQToDataTable(queryDonTBC));

                ///Table CHDB_ChiTietCatTams
                queryDonTBC = from itemDon in db.DonTBCs
                              join itemCTCTDB in db.CHDB_ChiTietCatTams on itemDon.MaDon equals itemCTCTDB.CHDB.MaDonTBC
                              where itemCTCTDB.DanhBo == DanhBo
                              select new
                              {
                                  MaDon = "TBC" + itemDon.MaDon,
                                  itemDon.LoaiDonTBC.TenLD,
                                  itemDon.CreateDate,
                                  itemDon.DanhBo,
                                  itemDon.HoTen,
                                  itemDon.DiaChi,
                                  itemDon.GiaBieu,
                                  itemDon.DinhMuc,
                                  itemDon.NoiDung,
                              };
                dt.Merge(LINQToDataTable(queryDonTBC));

                ///Table CHDB_ChiTietCatHuys
                queryDonTBC = from itemDon in db.DonTBCs
                              join itemCTCHDB in db.CHDB_ChiTietCatHuys on itemDon.MaDon equals itemCTCHDB.CHDB.MaDonTBC
                              where itemCTCHDB.DanhBo == DanhBo
                              select new
                              {
                                  MaDon = "TBC" + itemDon.MaDon,
                                  itemDon.LoaiDonTBC.TenLD,
                                  itemDon.CreateDate,
                                  itemDon.DanhBo,
                                  itemDon.HoTen,
                                  itemDon.DiaChi,
                                  itemDon.GiaBieu,
                                  itemDon.DinhMuc,
                                  itemDon.NoiDung,
                              };
                dt.Merge(LINQToDataTable(queryDonTBC));

                ///TablePhieuCHDBs
                queryDonTBC = from itemDon in db.DonTBCs
                              join itemYCCHDB in db.CHDB_Phieus on itemDon.MaDon equals itemYCCHDB.MaDonTBC
                              where itemYCCHDB.DanhBo == DanhBo
                              select new
                              {
                                  MaDon = "TBC" + itemDon.MaDon,
                                  itemDon.LoaiDonTBC.TenLD,
                                  itemDon.CreateDate,
                                  itemDon.DanhBo,
                                  itemDon.HoTen,
                                  itemDon.DiaChi,
                                  itemDon.GiaBieu,
                                  itemDon.DinhMuc,
                                  itemDon.NoiDung,
                              };
                dt.Merge(LINQToDataTable(queryDonTBC));

                ///Table ThuTraLoi_ChiTiets
                queryDonTBC = from itemDon in db.DonTBCs
                              join itemCTTTTL in db.ThuTraLoi_ChiTiets on itemDon.MaDon equals itemCTTTTL.ThuTraLoi.MaDonTBC
                              where itemCTTTTL.DanhBo == DanhBo
                              select new
                              {
                                  MaDon = "TBC" + itemDon.MaDon,
                                  itemDon.LoaiDonTBC.TenLD,
                                  itemDon.CreateDate,
                                  itemDon.DanhBo,
                                  itemDon.HoTen,
                                  itemDon.DiaChi,
                                  itemDon.GiaBieu,
                                  itemDon.DinhMuc,
                                  itemDon.NoiDung,
                              };
                dt.Merge(LINQToDataTable(queryDonTBC));

                ///Table DongNuoc_ChiTiets
                queryDonTBC = from itemDon in db.DonTBCs
                              join itemCTDongNuoc in db.DongNuoc_ChiTiets on itemDon.MaDon equals itemCTDongNuoc.DongNuoc.MaDonTBC
                              where itemCTDongNuoc.DanhBo == DanhBo
                              select new
                              {
                                  MaDon = "TBC" + itemDon.MaDon,
                                  itemDon.LoaiDonTBC.TenLD,
                                  itemDon.CreateDate,
                                  itemDon.DanhBo,
                                  itemDon.HoTen,
                                  itemDon.DiaChi,
                                  itemDon.GiaBieu,
                                  itemDon.DinhMuc,
                                  itemDon.NoiDung,
                              };
                dt.Merge(LINQToDataTable(queryDonTBC));

                ///Table GianLan_ChiTiets
                queryDonTBC = from itemDon in db.DonTBCs
                              join itemGL in db.GianLan_ChiTiets on itemDon.MaDon equals itemGL.GianLan.MaDonTBC
                              where itemGL.DanhBo == DanhBo
                              select new
                              {
                                  MaDon = "TBC" + itemDon.MaDon,
                                  itemDon.LoaiDonTBC.TenLD,
                                  itemDon.CreateDate,
                                  itemDon.DanhBo,
                                  itemDon.HoTen,
                                  itemDon.DiaChi,
                                  itemDon.GiaBieu,
                                  itemDon.DinhMuc,
                                  itemDon.NoiDung,
                              };
                dt.Merge(LINQToDataTable(queryDonTBC));

                #endregion

                DataTable dtDon = new DataTable();
                dtDon.Columns.Add("MaDon", typeof(string));
                dtDon.Columns.Add("TenLD", typeof(string));
                dtDon.Columns.Add("CreateDate", typeof(DateTime));
                dtDon.Columns.Add("DanhBo", typeof(string));
                dtDon.Columns.Add("HoTen", typeof(string));
                dtDon.Columns.Add("DiaChi", typeof(string));
                dtDon.Columns.Add("GiaBieu", typeof(string));
                dtDon.Columns.Add("DinhMuc", typeof(string));
                dtDon.Columns.Add("NoiDung", typeof(string));
                dtDon.TableName = "Don";

                foreach (DataRow itemRow in dt.Rows)
                {
                    if (dtDon.Select("MaDon = '" + itemRow["MaDon"] + "'").Count() <= 0)
                        dtDon.ImportRow(itemRow);
                }

                dtDon.DefaultView.Sort = "CreateDate DESC";
                ds.Tables.Add(dtDon.DefaultView.ToTable());

                if (dtDon.Rows.Count > 0 && dtKTXM.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Kiểm Tra Xác Minh", ds.Tables["Don"].Columns["MaDon"], ds.Tables["KTXM"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtBamChi.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Bấm Chì", ds.Tables["Don"].Columns["MaDon"], ds.Tables["BamChi"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtDongNuoc.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Đóng Nước", ds.Tables["Don"].Columns["MaDon"], ds.Tables["DongNuoc"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtDCBD.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Điều Chỉnh Biến Động", ds.Tables["Don"].Columns["MaDon"], ds.Tables["DCBD"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtCHDB.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Cắt Tạm/Hủy Danh Bộ", ds.Tables["Don"].Columns["MaDon"], ds.Tables["CHDB"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtYCCHDB.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Phiếu Hủy Danh Bộ", ds.Tables["Don"].Columns["MaDon"], ds.Tables["YCCHDB"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtTTTL.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời", ds.Tables["Don"].Columns["MaDon"], ds.Tables["ThuTraLoi"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtGianLan.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Gian Lận", ds.Tables["Don"].Columns["MaDon"], ds.Tables["GianLan"].Columns["MaDon"]);

                return ds;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
