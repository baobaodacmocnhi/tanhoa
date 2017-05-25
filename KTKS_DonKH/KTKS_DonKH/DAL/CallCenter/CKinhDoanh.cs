using System;
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
                var queryKTXM = from itemCTKTXM in db.CTKTXMs
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
                                    itemCTKTXM.NoiDung,
                                    itemCTKTXM.NgayDongTien,
                                    itemCTKTXM.SoTien,
                                };
                DataTable dtKTXM = new DataTable();
                dtKTXM = LINQToDataTable(queryKTXM);
                dtKTXM.TableName = "KTXM";
                ds.Tables.Add(dtKTXM);

                ///Table CTBamChi
                var queryBamChi = from itemCTBamChi in db.CTBamChis
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
                var queryDongNuoc = from itemCTDongNuoc in db.CTDongNuocs
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
                var queryCTDCBD = from itemCTDCBD in db.CTDCBDs
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
                var queryCTDCHD = from itemCTDCHD in db.CTDCHDs
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
                var queryCTCTDB = from itemCTCTDB in db.CTCTDBs
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
                var queryCTCHDB = from itemCTCHDB in db.CTCHDBs
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
                var queryYCCHDB = from itemYCCHDB in db.PhieuCHDBs
                                  where itemYCCHDB.DanhBo == DanhBo || (itemYCCHDB.DonKH.DanhBo == DanhBo || itemYCCHDB.DonTXL.DanhBo == DanhBo || itemYCCHDB.DonTBC.DanhBo == DanhBo)
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

                ///Table CTTTTL
                var queryTTTL = from itemCTTTTL in db.CTTTTLs
                                where itemCTTTTL.DanhBo == DanhBo || (itemCTTTTL.TTTL.DonKH.DanhBo == DanhBo || itemCTTTTL.TTTL.DonTXL.DanhBo == DanhBo || itemCTTTTL.TTTL.DonTBC.DanhBo == DanhBo)
                                select new
                                {
                                    MaDon = itemCTTTTL.TTTL.MaDon != null ? "TKH" + itemCTTTTL.TTTL.MaDon
                                    : itemCTTTTL.TTTL.MaDonTXL != null ? "TXL" + itemCTTTTL.TTTL.MaDonTXL
                                    : itemCTTTTL.TTTL.MaDonTBC != null ? "TBC" + itemCTTTTL.TTTL.MaDonTBC : null,
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
                dtTTTL.TableName = "TTTL";
                ds.Tables.Add(dtTTTL);

                ///Table GianLan
                var queryGianLan = from itemGL in db.GianLans
                                   where itemGL.DanhBo == DanhBo || (itemGL.DonKH.DanhBo == DanhBo || itemGL.DonTXL.DanhBo == DanhBo || itemGL.DonTBC.DanhBo == DanhBo)
                                   select new
                                   {
                                       MaDon = itemGL.MaDon != null ? "TKH" + itemGL.MaDon
                                       : itemGL.MaDonTXL != null ? "TXL" + itemGL.MaDonTXL
                                       : itemGL.MaDonTBC != null ? "TBC" + itemGL.MaDonTBC : null,
                                       itemGL.ID,
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

                ///Table CTKTXMs
                queryDonKH = from itemDon in db.DonKHs
                             join itemCTKTXM in db.CTKTXMs on itemDon.MaDon equals itemCTKTXM.KTXM.MaDon
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

                ///Table CTBamChis
                queryDonKH = from itemDon in db.DonKHs
                             join itemCTBamChi in db.CTBamChis on itemDon.MaDon equals itemCTBamChi.BamChi.MaDon
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

                ///Table CTDCBDs
                queryDonKH = from itemDon in db.DonKHs
                             join itemCTDCBD in db.CTDCBDs on itemDon.MaDon equals itemCTDCBD.DCBD.MaDon
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

                ///Table CTDCHDs
                queryDonKH = from itemDon in db.DonKHs
                             join itemCTDCHD in db.CTDCHDs on itemDon.MaDon equals itemCTDCHD.DCBD.MaDon
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

                ///Table CTCTDBs
                queryDonKH = from itemDon in db.DonKHs
                             join itemCTCTDB in db.CTCTDBs on itemDon.MaDon equals itemCTCTDB.CHDB.MaDon
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

                ///Table CTCHDBs
                queryDonKH = from itemDon in db.DonKHs
                             join itemCTCHDB in db.CTCHDBs on itemDon.MaDon equals itemCTCHDB.CHDB.MaDon
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
                             join itemYCCHDB in db.PhieuCHDBs on itemDon.MaDon equals itemYCCHDB.MaDon
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

                ///Table CTTTTLs
                queryDonKH = from itemDon in db.DonKHs
                             join itemCTTTTL in db.CTTTTLs on itemDon.MaDon equals itemCTTTTL.TTTL.MaDon
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

                ///Table CTDongNuocs
                queryDonKH = from itemDon in db.DonKHs
                             join itemCTDongNuoc in db.CTDongNuocs on itemDon.MaDon equals itemCTDongNuoc.DongNuoc.MaDon
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

                ///Table GianLans
                queryDonKH = from itemDon in db.DonKHs
                             join itemGL in db.GianLans on itemDon.MaDon equals itemGL.MaDon
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

                ///Table CTKTXMs
                queryDonTXL = from itemDonTXL in db.DonTXLs
                              join itemCTKTXM in db.CTKTXMs on itemDonTXL.MaDon equals itemCTKTXM.KTXM.MaDonTXL
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

                ///Table CTBamChis
                queryDonTXL = from itemDonTXL in db.DonTXLs
                              join itemCTBamChi in db.CTBamChis on itemDonTXL.MaDon equals itemCTBamChi.BamChi.MaDonTXL
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

                ///Table CTDCBDs
                queryDonTXL = from itemDonTXL in db.DonTXLs
                              join itemCTDCBD in db.CTDCBDs on itemDonTXL.MaDon equals itemCTDCBD.DCBD.MaDonTXL
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

                ///Table CTDCHDs
                queryDonTXL = from itemDonTXL in db.DonTXLs
                              join itemCTDCHD in db.CTDCHDs on itemDonTXL.MaDon equals itemCTDCHD.DCBD.MaDonTXL
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

                ///Table CTCTDBs
                queryDonTXL = from itemDonTXL in db.DonTXLs
                              join itemCTCTDB in db.CTCTDBs on itemDonTXL.MaDon equals itemCTCTDB.CHDB.MaDonTXL
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

                ///Table CTCHDBs
                queryDonTXL = from itemDonTXL in db.DonTXLs
                              join itemCTCHDB in db.CTCHDBs on itemDonTXL.MaDon equals itemCTCHDB.CHDB.MaDonTXL
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

                ///Table PhieuCHDBs
                queryDonTXL = from itemDonTXL in db.DonTXLs
                              join itemYCCHDB in db.PhieuCHDBs on itemDonTXL.MaDon equals itemYCCHDB.MaDonTXL
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

                ///Table CTTTTLs
                queryDonTXL = from itemDonTXL in db.DonTXLs
                              join itemCTTTTL in db.CTTTTLs on itemDonTXL.MaDon equals itemCTTTTL.TTTL.MaDonTXL
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

                ///Table CTDongNuocs
                queryDonTXL = from itemDonTXL in db.DonTXLs
                              join itemCTDongNuoc in db.CTDongNuocs on itemDonTXL.MaDon equals itemCTDongNuoc.DongNuoc.MaDonTXL
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

                ///Table GianLans
                queryDonTXL = from itemDonTXL in db.DonTXLs
                              join itemGL in db.GianLans on itemDonTXL.MaDon equals itemGL.MaDonTXL
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

                ///Table CTKTXMs
                queryDonTBC = from itemDon in db.DonTBCs
                              join itemCTKTXM in db.CTKTXMs on itemDon.MaDon equals itemCTKTXM.KTXM.MaDonTBC
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

                ///Table CTBamChis
                queryDonTBC = from itemDon in db.DonTBCs
                              join itemCTBamChi in db.CTBamChis on itemDon.MaDon equals itemCTBamChi.BamChi.MaDonTBC
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

                ///Table CTDCBDs
                queryDonTBC = from itemDon in db.DonTBCs
                              join itemCTDCBD in db.CTDCBDs on itemDon.MaDon equals itemCTDCBD.DCBD.MaDonTBC
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

                ///Table CTDCHDs
                queryDonTBC = from itemDon in db.DonTBCs
                              join itemCTDCHD in db.CTDCHDs on itemDon.MaDon equals itemCTDCHD.DCBD.MaDonTBC
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

                ///Table CTCTDBs
                queryDonTBC = from itemDon in db.DonTBCs
                              join itemCTCTDB in db.CTCTDBs on itemDon.MaDon equals itemCTCTDB.CHDB.MaDonTBC
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

                ///Table CTCHDBs
                queryDonTBC = from itemDon in db.DonTBCs
                              join itemCTCHDB in db.CTCHDBs on itemDon.MaDon equals itemCTCHDB.CHDB.MaDonTBC
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
                              join itemYCCHDB in db.PhieuCHDBs on itemDon.MaDon equals itemYCCHDB.MaDonTBC
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

                ///Table CTTTTLs
                queryDonTBC = from itemDon in db.DonTBCs
                              join itemCTTTTL in db.CTTTTLs on itemDon.MaDon equals itemCTTTTL.TTTL.MaDonTBC
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

                ///Table CTDongNuocs
                queryDonTBC = from itemDon in db.DonTBCs
                              join itemCTDongNuoc in db.CTDongNuocs on itemDon.MaDon equals itemCTDongNuoc.DongNuoc.MaDonTBC
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

                ///Table GianLans
                queryDonTBC = from itemDon in db.DonTBCs
                              join itemGL in db.GianLans on itemDon.MaDon equals itemGL.MaDonTBC
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
                    ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời", ds.Tables["Don"].Columns["MaDon"], ds.Tables["TTTL"].Columns["MaDon"]);

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
