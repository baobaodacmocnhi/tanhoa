using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace KTKS_DonKH.DAL.TimKiem
{
    class CTimKiem : CDAL
    {
        public DataSet GetTienTrinhbyMaDon(decimal MaDon)
        {
            try
            {
                DataSet ds = new DataSet();
                ///Table DonKH
                var queryDon = from itemDon in db.DonKHs
                                 where itemDon.MaDon == MaDon
                                 select new
                                 {
                                     ToXuLy = false,
                                     itemDon.MaDon,
                                     itemDon.LoaiDon.TenLD,
                                     itemDon.CreateDate,
                                     itemDon.DanhBo,
                                     itemDon.HoTen,
                                     itemDon.DiaChi,
                                     itemDon.GiaBieu,
                                     itemDon.DinhMuc,
                                     itemDon.NoiDung,
                                 };
                DataTable dtDon = new DataTable();
                dtDon = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon);
                dtDon.TableName = "Don";
                ds.Tables.Add(dtDon);

                ///Table CTKTXM
                var queryKTXM = from itemCTKTXM in db.CTKTXMs
                                join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                where itemCTKTXM.KTXM.MaDon == MaDon
                                select new
                                {
                                    itemCTKTXM.KTXM.MaDon,
                                    itemCTKTXM.MaCTKTXM,
                                    itemCTKTXM.NgayKTXM,
                                    itemCTKTXM.DanhBo,
                                    itemCTKTXM.HoTen,
                                    itemCTKTXM.DiaChi,
                                    itemCTKTXM.NoiDungKiemTra,
                                    CreateBy = itemUser.HoTen,
                                    itemCTKTXM.NgayDongTien,
                                    itemCTKTXM.SoTien,
                                };

                DataTable dtKTXM = new DataTable();
                dtKTXM = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryKTXM);
                dtKTXM.TableName = "KTXM";
                ds.Tables.Add(dtKTXM);

                ///Table CTBamChi
                var queryBamChi = from itemCTBamChi in db.CTBamChis
                                  join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                                  where itemCTBamChi.BamChi.MaDon == MaDon
                                  select new
                                  {
                                      itemCTBamChi.BamChi.MaDon,
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
                dtBamChi = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryBamChi);
                dtBamChi.TableName = "BamChi";
                ds.Tables.Add(dtBamChi);

                ///Table CTDongNuoc
                var queryDongNuoc = from itemCTDongNuoc in db.CTDongNuocs
                                    join itemUser in db.Users on itemCTDongNuoc.CreateBy equals itemUser.MaU
                                    where itemCTDongNuoc.DongNuoc.MaDon == MaDon
                                    select new
                                    {
                                        MaDon = itemCTDongNuoc.DongNuoc.MaDon,
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
                dtDongNuoc = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDongNuoc);
                dtDongNuoc.TableName = "DongNuoc";
                ds.Tables.Add(dtDongNuoc);

                ///Table CTDCBD
                var queryCTDCBD = from itemCTDCBD in db.CTDCBDs
                                  join itemUser in db.Users on itemCTDCBD.CreateBy equals itemUser.MaU
                                  where itemCTDCBD.DCBD.MaDon == MaDon
                                  select new
                                  {
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
                                      itemCTDCBD.DCBD.MaDon,
                                      CreateBy = itemUser.HoTen,
                                  };
                ///Bảng CTDCHD
                var queryCTDCHD = from itemCTDCHD in db.CTDCHDs
                                  join itemUser in db.Users on itemCTDCHD.CreateBy equals itemUser.MaU
                                  where itemCTDCHD.DCBD.MaDon == MaDon
                                  select new
                                  {
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
                                      itemCTDCHD.DCBD.MaDon,
                                      CreateBy = itemUser.HoTen,
                                  };

                DataTable dtDCBD = new DataTable();
                dtDCBD = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTDCBD);
                dtDCBD.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTDCHD));
                dtDCBD.TableName = "DCBD";
                ds.Tables.Add(dtDCBD);

                ///Table CTCTDB
                var queryCTCTDB = from itemCTCTDB in db.CTCTDBs
                                  where itemCTCTDB.CHDB.MaDon == MaDon
                                  select new
                                  {
                                      MaCH=itemCTCTDB.MaCTCTDB,
                                      LoaiCat="Cắt Tạm",
                                      itemCTCTDB.CreateDate,
                                      itemCTCTDB.DanhBo,
                                      itemCTCTDB.HoTen,
                                      itemCTCTDB.DiaChi,
                                      itemCTCTDB.LyDo,
                                      itemCTCTDB.GhiChuLyDo,
                                      itemCTCTDB.CHDB.MaDon,
                                      itemCTCTDB.DaLapPhieu,
                                      itemCTCTDB.SoPhieu,
                                      itemCTCTDB.NgayLapPhieu,
                                  };


                ///Table CTCHDB
                var queryCTCHDB = from itemCTCHDB in db.CTCHDBs
                                  where itemCTCHDB.CHDB.MaDon == MaDon
                                  select new
                                  {
                                      MaCH = itemCTCHDB.MaCTCHDB,
                                      LoaiCat = "Cắt Hủy",
                                      itemCTCHDB.CreateDate,
                                      itemCTCHDB.DanhBo,
                                      itemCTCHDB.HoTen,
                                      itemCTCHDB.DiaChi,
                                      itemCTCHDB.LyDo,
                                      itemCTCHDB.GhiChuLyDo,
                                      itemCTCHDB.CHDB.MaDon,
                                      itemCTCHDB.DaLapPhieu,
                                      itemCTCHDB.SoPhieu,
                                      itemCTCHDB.NgayLapPhieu,
                                  };

                DataTable dtCHDB = new DataTable();
                dtCHDB = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTCTDB);
                dtCHDB.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTCHDB));
                dtCHDB.TableName = "CHDB";
                ds.Tables.Add(dtCHDB);

                ///Table CTTTTL
                var queryTTTL = from itemCTTTTL in db.CTTTTLs
                            where itemCTTTTL.TTTL.MaDon == MaDon
                            select new
                            {
                                itemCTTTTL.MaCTTTTL,
                                itemCTTTTL.CreateDate,
                                itemCTTTTL.DanhBo,
                                itemCTTTTL.HoTen,
                                itemCTTTTL.DiaChi,
                                itemCTTTTL.VeViec,
                                itemCTTTTL.NoiDung,
                                itemCTTTTL.NoiNhan,
                                itemCTTTTL.TTTL.MaDon,
                            };

                DataTable dtTTTL = new DataTable();
                dtTTTL = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryTTTL);
                dtTTTL.TableName = "TTTL";
                ds.Tables.Add(dtTTTL);

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

                if (dtDon.Rows.Count > 0 && dtTTTL.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời", ds.Tables["Don"].Columns["MaDon"], ds.Tables["TTTL"].Columns["MaDon"]);

                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataSet GetTienTrinhbyMaDon_TXL(decimal MaDonTXL)
        {
            try
            {
                DataSet ds = new DataSet();
                ///Table DonTXL
                var queryDon = from itemDonTXL in db.DonTXLs
                               where itemDonTXL.MaDon == MaDonTXL
                               select new
                               {
                                   ToXuLy=true,
                                   itemDonTXL.MaDon,
                                   itemDonTXL.LoaiDonTXL.TenLD,
                                   itemDonTXL.CreateDate,
                                   itemDonTXL.DanhBo,
                                   itemDonTXL.HoTen,
                                   itemDonTXL.DiaChi,
                                   itemDonTXL.GiaBieu,
                                   itemDonTXL.DinhMuc,
                                   itemDonTXL.NoiDung,
                               };
                DataTable dtDon = new DataTable();
                dtDon = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon);
                dtDon.TableName = "Don";
                ds.Tables.Add(dtDon);

                ///Table CTKTXM
                var queryKTXM = from itemCTKTXM in db.CTKTXMs
                                join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                where itemCTKTXM.KTXM.MaDonTXL == MaDonTXL
                                select new
                                {
                                    MaDon = itemCTKTXM.KTXM.MaDonTXL,
                                    itemCTKTXM.MaCTKTXM,
                                    itemCTKTXM.NgayKTXM,
                                    itemCTKTXM.DanhBo,
                                    itemCTKTXM.HoTen,
                                    itemCTKTXM.DiaChi,
                                    itemCTKTXM.NoiDungKiemTra,
                                    CreateBy=itemUser.HoTen,
                                    itemCTKTXM.NgayDongTien,
                                    itemCTKTXM.SoTien,
                                };

                DataTable dtKTXM = new DataTable();
                dtKTXM = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryKTXM);
                dtKTXM.TableName = "KTXM";
                ds.Tables.Add(dtKTXM);

                ///Table CTBamChi
                var queryBamChi = from itemCTBamChi in db.CTBamChis
                                  join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                                  where itemCTBamChi.BamChi.MaDonTXL == MaDonTXL
                                select new
                                {
                                    MaDon = itemCTBamChi.BamChi.MaDonTXL,
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
                dtBamChi = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryBamChi);
                dtBamChi.TableName = "BamChi";
                ds.Tables.Add(dtBamChi);

                ///Table CTDongNuoc
                var queryDongNuoc = from itemCTDongNuoc in db.CTDongNuocs
                                  join itemUser in db.Users on itemCTDongNuoc.CreateBy equals itemUser.MaU
                                  where itemCTDongNuoc.DongNuoc.MaDonTXL == MaDonTXL
                                  select new
                                  {
                                      MaDon = itemCTDongNuoc.DongNuoc.MaDonTXL,
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
                dtDongNuoc = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDongNuoc);
                dtDongNuoc.TableName = "DongNuoc";
                ds.Tables.Add(dtDongNuoc);

                ///Table CTDCBD
                var queryCTDCBD = from itemCTDCBD in db.CTDCBDs
                                  join itemUser in db.Users on itemCTDCBD.CreateBy equals itemUser.MaU
                                  where itemCTDCBD.DCBD.MaDonTXL == MaDonTXL
                                  select new
                                  {
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
                                      MaDon=itemCTDCBD.DCBD.MaDonTXL,
                                      CreateBy=itemUser.HoTen,
                                  };
                ///Bảng CTDCHD
                var queryCTDCHD = from itemCTDCHD in db.CTDCHDs
                                  join itemUser in db.Users on itemCTDCHD.CreateBy equals itemUser.MaU
                                  where itemCTDCHD.DCBD.MaDonTXL == MaDonTXL
                                  select new
                                  {
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
                                      MaDon=itemCTDCHD.DCBD.MaDonTXL,
                                      CreateBy = itemUser.HoTen,
                                  };

                DataTable dtDCBD = new DataTable();
                dtDCBD = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTDCBD);
                dtDCBD.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTDCHD));
                dtDCBD.TableName = "DCBD";
                ds.Tables.Add(dtDCBD);

                ///Table CTCTDB
                var queryCTCTDB = from itemCTCTDB in db.CTCTDBs
                                  where itemCTCTDB.CHDB.MaDonTXL == MaDonTXL
                                  select new
                                  {
                                      MaCH = itemCTCTDB.MaCTCTDB,
                                      LoaiCat = "Cắt Tạm",
                                      itemCTCTDB.CreateDate,
                                      itemCTCTDB.DanhBo,
                                      itemCTCTDB.HoTen,
                                      itemCTCTDB.DiaChi,
                                      itemCTCTDB.LyDo,
                                      itemCTCTDB.GhiChuLyDo,
                                      MaDon=itemCTCTDB.CHDB.MaDonTXL,
                                      itemCTCTDB.DaLapPhieu,
                                      itemCTCTDB.SoPhieu,
                                      itemCTCTDB.NgayLapPhieu,
                                  };


                ///Table CTCHDB
                var queryCTCHDB = from itemCTCHDB in db.CTCHDBs
                                  where itemCTCHDB.CHDB.MaDonTXL == MaDonTXL
                                  select new
                                  {
                                      MaCH = itemCTCHDB.MaCTCHDB,
                                      LoaiCat = "Cắt Hủy",
                                      itemCTCHDB.CreateDate,
                                      itemCTCHDB.DanhBo,
                                      itemCTCHDB.HoTen,
                                      itemCTCHDB.DiaChi,
                                      itemCTCHDB.LyDo,
                                      itemCTCHDB.GhiChuLyDo,
                                      MaDon = itemCTCHDB.CHDB.MaDonTXL,
                                      itemCTCHDB.DaLapPhieu,
                                      itemCTCHDB.SoPhieu,
                                      itemCTCHDB.NgayLapPhieu,
                                  };

                DataTable dtCHDB = new DataTable();
                dtCHDB = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTCTDB);
                dtCHDB.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTCHDB));
                dtCHDB.TableName = "CHDB";
                ds.Tables.Add(dtCHDB);

                ///Table YeuCauCHDB
                var queryYCCHDB = from itemYCCHDB in db.YeuCauCHDBs
                                      where itemYCCHDB.MaDonTXL == MaDonTXL
                                  select new
                                  {
                                     itemYCCHDB.MaYCCHDB,
                                     itemYCCHDB.CreateDate,
                                     itemYCCHDB.DanhBo,
                                     itemYCCHDB.HoTen,
                                     itemYCCHDB.DiaChi,
                                     itemYCCHDB.LyDo,
                                     itemYCCHDB.GhiChuLyDo,
                                     MaDon = itemYCCHDB.MaDonTXL,
                                  };

                DataTable dtYCCHDB = new DataTable();
                dtYCCHDB = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryYCCHDB);
                dtYCCHDB.TableName = "YeuCauCHDB";
                ds.Tables.Add(dtYCCHDB);

                ///Table CTTTTL
                var queryTTTL = from itemCTTTTL in db.CTTTTLs
                                where itemCTTTTL.TTTL.MaDonTXL == MaDonTXL
                                select new
                                {
                                    itemCTTTTL.MaCTTTTL,
                                    itemCTTTTL.CreateDate,
                                    itemCTTTTL.DanhBo,
                                    itemCTTTTL.HoTen,
                                    itemCTTTTL.DiaChi,
                                    itemCTTTTL.VeViec,
                                    itemCTTTTL.NoiDung,
                                    itemCTTTTL.NoiNhan,
                                    MaDon = itemCTTTTL.TTTL.MaDonTXL,
                                };

                DataTable dtTTTL = new DataTable();
                dtTTTL = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryTTTL);
                dtTTTL.TableName = "TTTL";
                ds.Tables.Add(dtTTTL);

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

                if (dtDon.Rows.Count > 0 && dtTTTL.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời", ds.Tables["Don"].Columns["MaDon"], ds.Tables["TTTL"].Columns["MaDon"]);

                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //Vì lý do tìm theo Danh Bộ, Họ Tên, Địa Chỉ phải tìm Con trước, Cha sau nên tìm đơn sau cùng

        public DataSet GetTienTrinhbyDanhBo(string DanhBo)
        {
            try
            {
                DataSet ds = new DataSet();
                
                ///Table CTKTXM
                var queryKTXM = from itemCTKTXM in db.CTKTXMs
                                join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                where itemCTKTXM.DanhBo == DanhBo
                                select new
                                {
                                    itemCTKTXM.KTXM.MaDon,
                                    itemCTKTXM.KTXM.ToXuLy,
                                    itemCTKTXM.KTXM.MaDonTXL,
                                    itemCTKTXM.MaCTKTXM,
                                    itemCTKTXM.NgayKTXM,
                                    itemCTKTXM.DanhBo,
                                    itemCTKTXM.HoTen,
                                    itemCTKTXM.DiaChi,
                                    itemCTKTXM.NoiDungKiemTra,
                                    CreateBy = itemUser.HoTen,
                                    itemCTKTXM.NgayDongTien,
                                    itemCTKTXM.SoTien,
                                };
                DataTable dtKTXM = new DataTable();
                dtKTXM = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryKTXM);
                dtKTXM.TableName = "KTXM";
                ds.Tables.Add(dtKTXM);

                ///Table CTBamChi
                var queryBamChi = from itemCTBamChi in db.CTBamChis
                                  join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                                  where itemCTBamChi.DanhBo==DanhBo
                                  select new
                                  {
                                      itemCTBamChi.BamChi.MaDon,
                                      itemCTBamChi.BamChi.ToXuLy,
                                      itemCTBamChi.BamChi.MaDonTXL,
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
                dtBamChi = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryBamChi);
                dtBamChi.TableName = "BamChi";
                ds.Tables.Add(dtBamChi);

                ///Table CTDongNuoc
                var queryDongNuoc = from itemCTDongNuoc in db.CTDongNuocs
                                    join itemUser in db.Users on itemCTDongNuoc.CreateBy equals itemUser.MaU
                                    where itemCTDongNuoc.DanhBo == DanhBo
                                    select new
                                    {
                                        itemCTDongNuoc.DongNuoc.MaDon,
                                        itemCTDongNuoc.DongNuoc.ToXuLy,
                                        itemCTDongNuoc.DongNuoc.MaDonTXL,
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
                dtDongNuoc = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDongNuoc);
                dtDongNuoc.TableName = "DongNuoc";
                ds.Tables.Add(dtDongNuoc);

                ///Table CTDCBD
                var queryCTDCBD = from itemCTDCBD in db.CTDCBDs
                                  join itemUser in db.Users on itemCTDCBD.CreateBy equals itemUser.MaU
                                  where itemCTDCBD.DanhBo == DanhBo
                                  select new
                                  {
                                      itemCTDCBD.DCBD.MaDon,
                                      itemCTDCBD.DCBD.ToXuLy,
                                      itemCTDCBD.DCBD.MaDonTXL,
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
                                  where itemCTDCHD.DanhBo == DanhBo
                                  select new
                                  {
                                      itemCTDCHD.DCBD.MaDon,
                                      itemCTDCHD.DCBD.ToXuLy,
                                      itemCTDCHD.DCBD.MaDonTXL,
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
                dtDCBD = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTDCBD);
                dtDCBD.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTDCHD));
                dtDCBD.TableName = "DCBD";
                ds.Tables.Add(dtDCBD);

                ///Table CTCTDB
                var queryCTCTDB = from itemCTCTDB in db.CTCTDBs
                                  where itemCTCTDB.DanhBo == DanhBo
                                  select new
                                  {
                                      itemCTCTDB.CHDB.MaDon,
                                      itemCTCTDB.CHDB.ToXuLy,
                                      itemCTCTDB.CHDB.MaDonTXL,
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
                                  where itemCTCHDB.DanhBo == DanhBo
                                  select new
                                  {
                                      itemCTCHDB.CHDB.MaDon,
                                      itemCTCHDB.CHDB.ToXuLy,
                                      itemCTCHDB.CHDB.MaDonTXL,
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
                dtCHDB = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTCTDB);
                dtCHDB.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTCHDB));
                dtCHDB.TableName = "CHDB";
                ds.Tables.Add(dtCHDB);

                ///Table CTTTTL
                var queryTTTL = from itemCTTTTL in db.CTTTTLs
                                where itemCTTTTL.DanhBo == DanhBo
                                select new
                                {
                                    itemCTTTTL.TTTL.MaDon,
                                    itemCTTTTL.TTTL.ToXuLy,
                                    itemCTTTTL.TTTL.MaDonTXL,
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
                dtTTTL = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryTTTL);
                dtTTTL.TableName = "TTTL";
                ds.Tables.Add(dtTTTL);

                #region DonKH

                ///Table DonKH
                var queryDon = from itemDon in db.DonKHs
                            where itemDon.DanhBo == DanhBo
                               select new
                               {
                                   ToXuLy = false,
                                   itemDon.MaDon,
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
                dt = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon);

                ///Table DonKH 1
                var queryDon1 = from itemDon in db.DonKHs
                               //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                               join itemCTKTXM in db.CTKTXMs on itemDon.MaDon equals itemCTKTXM.KTXM.MaDon
                               where itemCTKTXM.DanhBo == DanhBo
                               select new
                               {
                                   ToXuLy=false,
                                   itemDon.MaDon,
                                   itemDon.LoaiDon.TenLD,
                                   itemDon.CreateDate,
                                   itemDon.DanhBo,
                                   itemDon.HoTen,
                                   itemDon.DiaChi,
                                   itemDon.GiaBieu,
                                   itemDon.DinhMuc,
                                   itemDon.NoiDung,
                               };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon1));

                ///Table DonKH 2
                var queryDon2 = from itemDon in db.DonKHs
                                join itemCTBamChi in db.CTBamChis on itemDon.MaDon equals itemCTBamChi.BamChi.MaDon
                                where itemCTBamChi.DanhBo == DanhBo
                                select new
                                {
                                    ToXuLy = false,
                                    itemDon.MaDon,
                                    itemDon.LoaiDon.TenLD,
                                    itemDon.CreateDate,
                                    itemDon.DanhBo,
                                    itemDon.HoTen,
                                    itemDon.DiaChi,
                                    itemDon.GiaBieu,
                                    itemDon.DinhMuc,
                                    itemDon.NoiDung,
                                };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon2));

                ///Table DonKH 3
                var queryDon3 = from itemDon in db.DonKHs
                                join itemCTDCBD in db.CTDCBDs on itemDon.MaDon equals itemCTDCBD.DCBD.MaDon
                                where itemCTDCBD.DanhBo == DanhBo
                                select new
                                {
                                    ToXuLy = false,
                                    itemDon.MaDon,
                                    itemDon.LoaiDon.TenLD,
                                    itemDon.CreateDate,
                                    itemDon.DanhBo,
                                    itemDon.HoTen,
                                    itemDon.DiaChi,
                                    itemDon.GiaBieu,
                                    itemDon.DinhMuc,
                                    itemDon.NoiDung,
                                };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon3));

                ///Table DonKH 4
                var queryDon4 = from itemDon in db.DonKHs
                                join itemCTDCHD in db.CTDCHDs on itemDon.MaDon equals itemCTDCHD.DCBD.MaDon
                                where itemCTDCHD.DanhBo == DanhBo
                                select new
                                {
                                    ToXuLy = false,
                                    itemDon.MaDon,
                                    itemDon.LoaiDon.TenLD,
                                    itemDon.CreateDate,
                                    itemDon.DanhBo,
                                    itemDon.HoTen,
                                    itemDon.DiaChi,
                                    itemDon.GiaBieu,
                                    itemDon.DinhMuc,
                                    itemDon.NoiDung,
                                };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon4));

                ///Table DonKH 5
                var queryDon5 = from itemDon in db.DonKHs
                                join itemCTCTDB in db.CTCTDBs on itemDon.MaDon equals itemCTCTDB.CHDB.MaDon
                                where itemCTCTDB.DanhBo == DanhBo
                                select new
                                {
                                    ToXuLy = false,
                                    itemDon.MaDon,
                                    itemDon.LoaiDon.TenLD,
                                    itemDon.CreateDate,
                                    itemDon.DanhBo,
                                    itemDon.HoTen,
                                    itemDon.DiaChi,
                                    itemDon.GiaBieu,
                                    itemDon.DinhMuc,
                                    itemDon.NoiDung,
                                };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon5));

                ///Table DonKH 6
                var queryDon6 = from itemDon in db.DonKHs
                                join itemCTCHDB in db.CTCHDBs on itemDon.MaDon equals itemCTCHDB.CHDB.MaDon
                                where itemCTCHDB.DanhBo == DanhBo
                                select new
                                {
                                    ToXuLy = false,
                                    itemDon.MaDon,
                                    itemDon.LoaiDon.TenLD,
                                    itemDon.CreateDate,
                                    itemDon.DanhBo,
                                    itemDon.HoTen,
                                    itemDon.DiaChi,
                                    itemDon.GiaBieu,
                                    itemDon.DinhMuc,
                                    itemDon.NoiDung,
                                };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon6));

                ///Table DonKH 7
                var queryDon7 = from itemDon in db.DonKHs
                                join itemCTTTTL in db.CTTTTLs on itemDon.MaDon equals itemCTTTTL.TTTL.MaDon
                                where itemCTTTTL.DanhBo == DanhBo
                                select new
                                {
                                    ToXuLy = false,
                                    itemDon.MaDon,
                                    itemDon.LoaiDon.TenLD,
                                    itemDon.CreateDate,
                                    itemDon.DanhBo,
                                    itemDon.HoTen,
                                    itemDon.DiaChi,
                                    itemDon.GiaBieu,
                                    itemDon.DinhMuc,
                                    itemDon.NoiDung,
                                };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon7));

                ///Table DonKH 8
                var queryDon8 = from itemDon in db.DonKHs
                                join itemCTDongNuoc in db.CTDongNuocs on itemDon.MaDon equals itemCTDongNuoc.DongNuoc.MaDon
                                where itemCTDongNuoc.DanhBo == DanhBo
                                select new
                                {
                                    ToXuLy = false,
                                    itemDon.MaDon,
                                    itemDon.LoaiDon.TenLD,
                                    itemDon.CreateDate,
                                    itemDon.DanhBo,
                                    itemDon.HoTen,
                                    itemDon.DiaChi,
                                    itemDon.GiaBieu,
                                    itemDon.DinhMuc,
                                    itemDon.NoiDung,
                                };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon8));
#endregion

                #region DonTXL

                ///Table DonTXL
                var queryDonTXL = from itemDonTXL in db.DonTXLs
                               where itemDonTXL.DanhBo == DanhBo
                                  select new
                                  {
                                      ToXuLy = true,
                                      itemDonTXL.MaDon,
                                      itemDonTXL.LoaiDonTXL.TenLD,
                                      itemDonTXL.CreateDate,
                                      itemDonTXL.DanhBo,
                                      itemDonTXL.HoTen,
                                      itemDonTXL.DiaChi,
                                      itemDonTXL.GiaBieu,
                                      itemDonTXL.DinhMuc,
                                      itemDonTXL.NoiDung,
                                  };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonTXL));

                ///Table DonTXL 1
                var queryDonTXL1 = from itemDonTXL in db.DonTXLs
                                  //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                                  join itemCTKTXM in db.CTKTXMs on itemDonTXL.MaDon equals itemCTKTXM.KTXM.MaDonTXL
                                  where itemCTKTXM.DanhBo == DanhBo
                                  select new
                                  {
                                      ToXuLy = true,
                                      itemDonTXL.MaDon,
                                      itemDonTXL.LoaiDonTXL.TenLD,
                                      itemDonTXL.CreateDate,
                                      itemDonTXL.DanhBo,
                                      itemDonTXL.HoTen,
                                      itemDonTXL.DiaChi,
                                      itemDonTXL.GiaBieu,
                                      itemDonTXL.DinhMuc,
                                      itemDonTXL.NoiDung,
                                  };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonTXL1));

                ///Table DonTXL 2
                var queryDonTXL2 = from itemDonTXL in db.DonTXLs
                                   //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                                   join itemCTBamChi in db.CTBamChis on itemDonTXL.MaDon equals itemCTBamChi.BamChi.MaDonTXL
                                   where itemCTBamChi.DanhBo == DanhBo
                                   select new
                                   {
                                       ToXuLy = true,
                                       itemDonTXL.MaDon,
                                       itemDonTXL.LoaiDonTXL.TenLD,
                                       itemDonTXL.CreateDate,
                                       itemDonTXL.DanhBo,
                                       itemDonTXL.HoTen,
                                       itemDonTXL.DiaChi,
                                       itemDonTXL.GiaBieu,
                                       itemDonTXL.DinhMuc,
                                       itemDonTXL.NoiDung,
                                   };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonTXL2));

                ///Table DonTXL 3
                var queryDonTXL3 = from itemDonTXL in db.DonTXLs
                                   //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                                   join itemCTDCBD in db.CTDCBDs on itemDonTXL.MaDon equals itemCTDCBD.DCBD.MaDonTXL
                                   where itemCTDCBD.DanhBo == DanhBo
                                   select new
                                   {
                                       ToXuLy = true,
                                       itemDonTXL.MaDon,
                                       itemDonTXL.LoaiDonTXL.TenLD,
                                       itemDonTXL.CreateDate,
                                       itemDonTXL.DanhBo,
                                       itemDonTXL.HoTen,
                                       itemDonTXL.DiaChi,
                                       itemDonTXL.GiaBieu,
                                       itemDonTXL.DinhMuc,
                                       itemDonTXL.NoiDung,
                                   };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonTXL3));

                ///Table DonTXL 4
                var queryDonTXL4 = from itemDonTXL in db.DonTXLs
                                   //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                                   join itemCTDCHD in db.CTDCHDs on itemDonTXL.MaDon equals itemCTDCHD.DCBD.MaDonTXL
                                   where itemCTDCHD.DanhBo == DanhBo
                                   select new
                                   {
                                       ToXuLy = true,
                                       itemDonTXL.MaDon,
                                       itemDonTXL.LoaiDonTXL.TenLD,
                                       itemDonTXL.CreateDate,
                                       itemDonTXL.DanhBo,
                                       itemDonTXL.HoTen,
                                       itemDonTXL.DiaChi,
                                       itemDonTXL.GiaBieu,
                                       itemDonTXL.DinhMuc,
                                       itemDonTXL.NoiDung,
                                   };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonTXL4));

                ///Table DonTXL 5
                var queryDonTXL5 = from itemDonTXL in db.DonTXLs
                                  //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                                  join itemCTCTDB in db.CTCTDBs on itemDonTXL.MaDon equals itemCTCTDB.CHDB.MaDonTXL
                                   where itemCTCTDB.DanhBo == DanhBo
                                  select new
                                  {
                                      ToXuLy = true,
                                      itemDonTXL.MaDon,
                                      itemDonTXL.LoaiDonTXL.TenLD,
                                      itemDonTXL.CreateDate,
                                      itemDonTXL.DanhBo,
                                      itemDonTXL.HoTen,
                                      itemDonTXL.DiaChi,
                                      itemDonTXL.GiaBieu,
                                      itemDonTXL.DinhMuc,
                                      itemDonTXL.NoiDung,
                                  };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonTXL5));

                ///Table DonTXL 6
                var queryDonTXL6 = from itemDonTXL in db.DonTXLs
                                   //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                                   join itemCTCHDB in db.CTCHDBs on itemDonTXL.MaDon equals itemCTCHDB.CHDB.MaDonTXL
                                   where itemCTCHDB.DanhBo == DanhBo
                                   select new
                                   {
                                       ToXuLy = true,
                                       itemDonTXL.MaDon,
                                       itemDonTXL.LoaiDonTXL.TenLD,
                                       itemDonTXL.CreateDate,
                                       itemDonTXL.DanhBo,
                                       itemDonTXL.HoTen,
                                       itemDonTXL.DiaChi,
                                       itemDonTXL.GiaBieu,
                                       itemDonTXL.DinhMuc,
                                       itemDonTXL.NoiDung,
                                   };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonTXL6));

                ///Table DonTXL 7
                var queryDonTXL7 = from itemDonTXL in db.DonTXLs
                                   //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                                   join itemCTTTTL in db.CTTTTLs on itemDonTXL.MaDon equals itemCTTTTL.TTTL.MaDonTXL
                                   where itemCTTTTL.DanhBo == DanhBo
                                   select new
                                   {
                                       ToXuLy = true,
                                       itemDonTXL.MaDon,
                                       itemDonTXL.LoaiDonTXL.TenLD,
                                       itemDonTXL.CreateDate,
                                       itemDonTXL.DanhBo,
                                       itemDonTXL.HoTen,
                                       itemDonTXL.DiaChi,
                                       itemDonTXL.GiaBieu,
                                       itemDonTXL.DinhMuc,
                                       itemDonTXL.NoiDung,
                                   };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonTXL7));

                ///Table DonTXL 8
                var queryDonTXL8 = from itemDonTXL in db.DonTXLs
                                   //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                                   join itemCTDongNuoc in db.CTDongNuocs on itemDonTXL.MaDon equals itemCTDongNuoc.DongNuoc.MaDonTXL
                                   where itemCTDongNuoc.DanhBo == DanhBo
                                   select new
                                   {
                                       ToXuLy = true,
                                       itemDonTXL.MaDon,
                                       itemDonTXL.LoaiDonTXL.TenLD,
                                       itemDonTXL.CreateDate,
                                       itemDonTXL.DanhBo,
                                       itemDonTXL.HoTen,
                                       itemDonTXL.DiaChi,
                                       itemDonTXL.GiaBieu,
                                       itemDonTXL.DinhMuc,
                                       itemDonTXL.NoiDung,
                                   };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonTXL8));

                #endregion

                DataTable dtDon = new DataTable();
                dtDon.Columns.Add("ToXuLy", typeof(bool));
                dtDon.Columns.Add("MaDon", typeof(decimal));
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
                    if (dtDon.Select("MaDon = " + itemRow["MaDon"]).Count() <= 0)
                        dtDon.ImportRow(itemRow);
                }

                dtDon.DefaultView.Sort = "CreateDate ASC";
                ds.Tables.Add(dtDon.DefaultView.ToTable());

                if (dtDon.Rows.Count > 0 && dtKTXM.Rows.Count > 0)
                {
                    ds.Relations.Add("Chi Tiết Kiểm Tra Xác Minh", ds.Tables["Don"].Columns["MaDon"], ds.Tables["KTXM"].Columns["MaDon"]);
                    ds.Relations.Add("Chi Tiết Kiểm Tra Xác Minh TXL", ds.Tables["Don"].Columns["MaDon"], ds.Tables["KTXM"].Columns["MaDonTXL"]);
                }

                if (dtDon.Rows.Count > 0 && dtBamChi.Rows.Count > 0)
                {
                    ds.Relations.Add("Chi Tiết Bấm Chì", ds.Tables["Don"].Columns["MaDon"], ds.Tables["BamChi"].Columns["MaDon"]);
                    ds.Relations.Add("Chi Tiết Bấm Chì TXL", ds.Tables["Don"].Columns["MaDon"], ds.Tables["BamChi"].Columns["MaDonTXL"]);
                }

                if (dtDon.Rows.Count > 0 && dtDongNuoc.Rows.Count > 0)
                {
                    ds.Relations.Add("Chi Tiết Đóng Nước", ds.Tables["Don"].Columns["MaDon"], ds.Tables["DongNuoc"].Columns["MaDon"]);
                    ds.Relations.Add("Chi Tiết Đóng Nước TXL", ds.Tables["Don"].Columns["MaDon"], ds.Tables["DongNuoc"].Columns["MaDonTXL"]);
                }

                if (dtDon.Rows.Count > 0 && dtDCBD.Rows.Count > 0)
                {
                    ds.Relations.Add("Chi Tiết Điều Chỉnh Biến Động", ds.Tables["Don"].Columns["MaDon"], ds.Tables["DCBD"].Columns["MaDon"]);
                    ds.Relations.Add("Chi Tiết Điều Chỉnh Biến Động TXL", ds.Tables["Don"].Columns["MaDon"], ds.Tables["DCBD"].Columns["MaDonTXL"]);
                }

                if (dtDon.Rows.Count > 0 && dtCHDB.Rows.Count > 0)
                {
                    ds.Relations.Add("Chi Tiết Cắt Tạm/Hủy Danh Bộ", ds.Tables["Don"].Columns["MaDon"], ds.Tables["CHDB"].Columns["MaDon"]);
                    ds.Relations.Add("Chi Tiết Cắt Tạm/Hủy Danh Bộ TXL", ds.Tables["Don"].Columns["MaDon"], ds.Tables["CHDB"].Columns["MaDonTXL"]);
                }

                if (dtDon.Rows.Count > 0 && dtTTTL.Rows.Count > 0)
                {
                    ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời", ds.Tables["Don"].Columns["MaDon"], ds.Tables["TTTL"].Columns["MaDon"]);
                    ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời TXL", ds.Tables["Don"].Columns["MaDon"], ds.Tables["TTTL"].Columns["MaDonTXL"]);
                }

                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataSet GetTienTrinhbyHoTen(string HoTen)
        {
            try
            {
                DataSet ds = new DataSet();

                ///Table CTKTXM
                var queryKTXM = from itemCTKTXM in db.CTKTXMs
                                join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                where itemCTKTXM.HoTen.Contains(HoTen)
                                select new
                                {
                                    itemCTKTXM.KTXM.MaDon,
                                    itemCTKTXM.KTXM.ToXuLy,
                                    itemCTKTXM.KTXM.MaDonTXL,
                                    itemCTKTXM.MaCTKTXM,
                                    itemCTKTXM.NgayKTXM,
                                    itemCTKTXM.DanhBo,
                                    itemCTKTXM.HoTen,
                                    itemCTKTXM.DiaChi,
                                    itemCTKTXM.NoiDungKiemTra,
                                    CreateBy = itemUser.HoTen,
                                    itemCTKTXM.NgayDongTien,
                                    itemCTKTXM.SoTien,
                                };
                DataTable dtKTXM = new DataTable();
                dtKTXM = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryKTXM);
                dtKTXM.TableName = "KTXM";
                ds.Tables.Add(dtKTXM);

                ///Table CTBamChi
                var queryBamChi = from itemCTBamChi in db.CTBamChis
                                  join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                                  where itemCTBamChi.HoTen.Contains(HoTen)
                                  select new
                                  {
                                      itemCTBamChi.BamChi.MaDon,
                                      itemCTBamChi.BamChi.ToXuLy,
                                      itemCTBamChi.BamChi.MaDonTXL,
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
                dtBamChi = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryBamChi);
                dtBamChi.TableName = "BamChi";
                ds.Tables.Add(dtBamChi);

                ///Table CTDongNuoc
                var queryDongNuoc = from itemCTDongNuoc in db.CTDongNuocs
                                    join itemUser in db.Users on itemCTDongNuoc.CreateBy equals itemUser.MaU
                                    where itemCTDongNuoc.HoTen.Contains(HoTen)
                                  select new
                                  {
                                      itemCTDongNuoc.DongNuoc.MaDon,
                                      itemCTDongNuoc.DongNuoc.ToXuLy,
                                      itemCTDongNuoc.DongNuoc.MaDonTXL,
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
                dtDongNuoc = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDongNuoc);
                dtDongNuoc.TableName = "DongNuoc";
                ds.Tables.Add(dtDongNuoc);

                ///Table CTDCBD
                var queryCTDCBD = from itemCTDCBD in db.CTDCBDs
                                  join itemUser in db.Users on itemCTDCBD.CreateBy equals itemUser.MaU
                                  where itemCTDCBD.HoTen.Contains(HoTen)
                                  select new
                                  {
                                      itemCTDCBD.DCBD.MaDon,
                                      itemCTDCBD.DCBD.ToXuLy,
                                      itemCTDCBD.DCBD.MaDonTXL,
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
                                      CreateBy=itemUser.HoTen,
                                  };

                ///Bảng CTDCHD
                var queryCTDCHD = from itemCTDCHD in db.CTDCHDs
                                  join itemUser in db.Users on itemCTDCHD.CreateBy equals itemUser.MaU
                                  where itemCTDCHD.HoTen.Contains(HoTen)
                                  select new
                                  {
                                      itemCTDCHD.DCBD.MaDon,
                                      itemCTDCHD.DCBD.ToXuLy,
                                      itemCTDCHD.DCBD.MaDonTXL,
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
                dtDCBD = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTDCBD);
                dtDCBD.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTDCHD));
                dtDCBD.TableName = "DCBD";
                ds.Tables.Add(dtDCBD);

                ///Table CTCTDB
                var queryCTCTDB = from itemCTCTDB in db.CTCTDBs
                                  where itemCTCTDB.HoTen.Contains(HoTen)
                                  select new
                                  {
                                      itemCTCTDB.CHDB.MaDon,
                                      itemCTCTDB.CHDB.ToXuLy,
                                      itemCTCTDB.CHDB.MaDonTXL,
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
                                  where itemCTCHDB.HoTen.Contains(HoTen)
                                  select new
                                  {
                                      itemCTCHDB.CHDB.MaDon,
                                      itemCTCHDB.CHDB.ToXuLy,
                                      itemCTCHDB.CHDB.MaDonTXL,
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
                dtCHDB = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTCTDB);
                dtCHDB.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTCHDB));
                dtCHDB.TableName = "CHDB";
                ds.Tables.Add(dtCHDB);

                ///Table CTTTTL
                var queryTTTL = from itemCTTTTL in db.CTTTTLs
                                where itemCTTTTL.HoTen.Contains(HoTen)
                                select new
                                {
                                    itemCTTTTL.TTTL.MaDon,
                                    itemCTTTTL.TTTL.ToXuLy,
                                    itemCTTTTL.TTTL.MaDonTXL,
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
                dtTTTL = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryTTTL);
                dtTTTL.TableName = "TTTL";
                ds.Tables.Add(dtTTTL);

                #region DonKH

                ///Table DonKH
                var queryDon = from itemDon in db.DonKHs
                            where itemDon.HoTen.Contains(HoTen)
                               select new
                               {
                                   ToXuLy = false,
                                   itemDon.MaDon,
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
                dt = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon);

                ///Table DonKH 1
                var queryDon1 = from itemDon in db.DonKHs
                               //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                               join itemCTKTXM in db.CTKTXMs on itemDon.MaDon equals itemCTKTXM.KTXM.MaDon
                               where itemCTKTXM.HoTen.Contains(HoTen)
                               select new
                               {
                                   ToXuLy = false,
                                   itemDon.MaDon,
                                   itemDon.LoaiDon.TenLD,
                                   itemDon.CreateDate,
                                   itemDon.DanhBo,
                                   itemDon.HoTen,
                                   itemDon.DiaChi,
                                   itemDon.GiaBieu,
                                   itemDon.DinhMuc,
                                   itemDon.NoiDung,
                               };
                //DataTable dt = new DataTable();
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon1));

                ///Table DonKH 2
                var queryDon2 = from itemDon in db.DonKHs
                                join itemCTBamChi in db.CTBamChis on itemDon.MaDon equals itemCTBamChi.BamChi.MaDon
                                where itemCTBamChi.HoTen.Contains(HoTen)
                                select new
                                {
                                    ToXuLy = false,
                                    itemDon.MaDon,
                                    itemDon.LoaiDon.TenLD,
                                    itemDon.CreateDate,
                                    itemDon.DanhBo,
                                    itemDon.HoTen,
                                    itemDon.DiaChi,
                                    itemDon.GiaBieu,
                                    itemDon.DinhMuc,
                                    itemDon.NoiDung,
                                };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon2));

                ///Table DonKH 3
                var queryDon3 = from itemDon in db.DonKHs
                                join itemCTDCBD in db.CTDCBDs on itemDon.MaDon equals itemCTDCBD.DCBD.MaDon
                                where itemCTDCBD.HoTen.Contains(HoTen)
                                select new
                                {
                                    ToXuLy = false,
                                    itemDon.MaDon,
                                    itemDon.LoaiDon.TenLD,
                                    itemDon.CreateDate,
                                    itemDon.DanhBo,
                                    itemDon.HoTen,
                                    itemDon.DiaChi,
                                    itemDon.GiaBieu,
                                    itemDon.DinhMuc,
                                    itemDon.NoiDung,
                                };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon3));

                ///Table DonKH 4
                var queryDon4 = from itemDon in db.DonKHs
                                join itemCTDCHD in db.CTDCHDs on itemDon.MaDon equals itemCTDCHD.DCBD.MaDon
                                where itemCTDCHD.HoTen.Contains(HoTen)
                                select new
                                {
                                    ToXuLy = false,
                                    itemDon.MaDon,
                                    itemDon.LoaiDon.TenLD,
                                    itemDon.CreateDate,
                                    itemDon.DanhBo,
                                    itemDon.HoTen,
                                    itemDon.DiaChi,
                                    itemDon.GiaBieu,
                                    itemDon.DinhMuc,
                                    itemDon.NoiDung,
                                };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon4));

                ///Table DonKH 5
                var queryDon5 = from itemDon in db.DonKHs
                                join itemCTCTDB in db.CTCTDBs on itemDon.MaDon equals itemCTCTDB.CHDB.MaDon
                                where itemCTCTDB.HoTen.Contains(HoTen)
                                select new
                                {
                                    ToXuLy = false,
                                    itemDon.MaDon,
                                    itemDon.LoaiDon.TenLD,
                                    itemDon.CreateDate,
                                    itemDon.DanhBo,
                                    itemDon.HoTen,
                                    itemDon.DiaChi,
                                    itemDon.GiaBieu,
                                    itemDon.DinhMuc,
                                    itemDon.NoiDung,
                                };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon5));

                ///Table DonKH 6
                var queryDon6 = from itemDon in db.DonKHs
                                join itemCTCHDB in db.CTCHDBs on itemDon.MaDon equals itemCTCHDB.CHDB.MaDon
                                where itemCTCHDB.HoTen.Contains(HoTen)
                                select new
                                {
                                    ToXuLy = false,
                                    itemDon.MaDon,
                                    itemDon.LoaiDon.TenLD,
                                    itemDon.CreateDate,
                                    itemDon.DanhBo,
                                    itemDon.HoTen,
                                    itemDon.DiaChi,
                                    itemDon.GiaBieu,
                                    itemDon.DinhMuc,
                                    itemDon.NoiDung,
                                };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon6));

                ///Table DonKH 7
                var queryDon7 = from itemDon in db.DonKHs
                                join itemCTTTTL in db.CTTTTLs on itemDon.MaDon equals itemCTTTTL.TTTL.MaDon
                                where itemCTTTTL.HoTen.Contains(HoTen)
                                select new
                                {
                                    ToXuLy = false,
                                    itemDon.MaDon,
                                    itemDon.LoaiDon.TenLD,
                                    itemDon.CreateDate,
                                    itemDon.DanhBo,
                                    itemDon.HoTen,
                                    itemDon.DiaChi,
                                    itemDon.GiaBieu,
                                    itemDon.DinhMuc,
                                    itemDon.NoiDung,
                                };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon7));

                ///Table DonKH 8
                var queryDon8 = from itemDon in db.DonKHs
                                join itemCTDongNuoc in db.CTDongNuocs on itemDon.MaDon equals itemCTDongNuoc.DongNuoc.MaDon
                                where itemCTDongNuoc.HoTen.Contains(HoTen)
                                select new
                                {
                                    ToXuLy = false,
                                    itemDon.MaDon,
                                    itemDon.LoaiDon.TenLD,
                                    itemDon.CreateDate,
                                    itemDon.DanhBo,
                                    itemDon.HoTen,
                                    itemDon.DiaChi,
                                    itemDon.GiaBieu,
                                    itemDon.DinhMuc,
                                    itemDon.NoiDung,
                                };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon8));
                #endregion

                #region DonTXL

                ///Table DonTXL
                var queryDonTXL = from itemDonTXL in db.DonTXLs
                                  where itemDonTXL.HoTen.Contains(HoTen)
                                  select new
                                  {
                                      ToXuLy = true,
                                      itemDonTXL.MaDon,
                                      itemDonTXL.LoaiDonTXL.TenLD,
                                      itemDonTXL.CreateDate,
                                      itemDonTXL.DanhBo,
                                      itemDonTXL.HoTen,
                                      itemDonTXL.DiaChi,
                                      itemDonTXL.GiaBieu,
                                      itemDonTXL.DinhMuc,
                                      itemDonTXL.NoiDung,
                                  };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonTXL));

                ///Table DonTXL 1
                var queryDonTXL1 = from itemDonTXL in db.DonTXLs
                                  //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                                  join itemCTKTXM in db.CTKTXMs on itemDonTXL.MaDon equals itemCTKTXM.KTXM.MaDonTXL
                                  where itemCTKTXM.HoTen.Contains(HoTen)
                                  select new
                                  {
                                      ToXuLy = true,
                                      itemDonTXL.MaDon,
                                      itemDonTXL.LoaiDonTXL.TenLD,
                                      itemDonTXL.CreateDate,
                                      itemDonTXL.DanhBo,
                                      itemDonTXL.HoTen,
                                      itemDonTXL.DiaChi,
                                      itemDonTXL.GiaBieu,
                                      itemDonTXL.DinhMuc,
                                      itemDonTXL.NoiDung,
                                  };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonTXL1));

                ///Table DonTXL 2
                var queryDonTXL2 = from itemDonTXL in db.DonTXLs
                                   //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                                   join itemCTBamChi in db.CTBamChis on itemDonTXL.MaDon equals itemCTBamChi.BamChi.MaDonTXL
                                   where itemCTBamChi.HoTen.Contains(HoTen)
                                   select new
                                   {
                                       ToXuLy = true,
                                       itemDonTXL.MaDon,
                                       itemDonTXL.LoaiDonTXL.TenLD,
                                       itemDonTXL.CreateDate,
                                       itemDonTXL.DanhBo,
                                       itemDonTXL.HoTen,
                                       itemDonTXL.DiaChi,
                                       itemDonTXL.GiaBieu,
                                       itemDonTXL.DinhMuc,
                                       itemDonTXL.NoiDung,
                                   };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonTXL2));

                ///Table DonTXL 3
                var queryDonTXL3 = from itemDonTXL in db.DonTXLs
                                  //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                                   join itemCTDCDB in db.CTDCBDs on itemDonTXL.MaDon equals itemCTDCDB.DCBD.MaDonTXL
                                   where itemCTDCDB.HoTen.Contains(HoTen)
                                  select new
                                  {
                                      ToXuLy = true,
                                      itemDonTXL.MaDon,
                                      itemDonTXL.LoaiDonTXL.TenLD,
                                      itemDonTXL.CreateDate,
                                      itemDonTXL.DanhBo,
                                      itemDonTXL.HoTen,
                                      itemDonTXL.DiaChi,
                                      itemDonTXL.GiaBieu,
                                      itemDonTXL.DinhMuc,
                                      itemDonTXL.NoiDung,
                                  };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonTXL3));

                ///Table DonTXL 4
                var queryDonTXL4 = from itemDonTXL in db.DonTXLs
                                  //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                                  join itemCTDCHD in db.CTDCHDs on itemDonTXL.MaDon equals itemCTDCHD.DCBD.MaDonTXL
                                   where itemCTDCHD.HoTen.Contains(HoTen)
                                  select new
                                  {
                                      ToXuLy = true,
                                      itemDonTXL.MaDon,
                                      itemDonTXL.LoaiDonTXL.TenLD,
                                      itemDonTXL.CreateDate,
                                      itemDonTXL.DanhBo,
                                      itemDonTXL.HoTen,
                                      itemDonTXL.DiaChi,
                                      itemDonTXL.GiaBieu,
                                      itemDonTXL.DinhMuc,
                                      itemDonTXL.NoiDung,
                                  };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonTXL4));

                ///Table DonTXL 5
                var queryDonTXL5 = from itemDonTXL in db.DonTXLs
                                   //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                                   join itemCTCTDB in db.CTCTDBs on itemDonTXL.MaDon equals itemCTCTDB.CHDB.MaDonTXL
                                   where itemCTCTDB.HoTen.Contains(HoTen)
                                   select new
                                   {
                                       ToXuLy = true,
                                       itemDonTXL.MaDon,
                                       itemDonTXL.LoaiDonTXL.TenLD,
                                       itemDonTXL.CreateDate,
                                       itemDonTXL.DanhBo,
                                       itemDonTXL.HoTen,
                                       itemDonTXL.DiaChi,
                                       itemDonTXL.GiaBieu,
                                       itemDonTXL.DinhMuc,
                                       itemDonTXL.NoiDung,
                                   };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonTXL5));

                ///Table DonTXL 6
                var queryDonTXL6 = from itemDonTXL in db.DonTXLs
                                   //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                                   join itemCTCHDB in db.CTCHDBs on itemDonTXL.MaDon equals itemCTCHDB.CHDB.MaDonTXL
                                   where itemCTCHDB.HoTen.Contains(HoTen)
                                   select new
                                   {
                                       ToXuLy = true,
                                       itemDonTXL.MaDon,
                                       itemDonTXL.LoaiDonTXL.TenLD,
                                       itemDonTXL.CreateDate,
                                       itemDonTXL.DanhBo,
                                       itemDonTXL.HoTen,
                                       itemDonTXL.DiaChi,
                                       itemDonTXL.GiaBieu,
                                       itemDonTXL.DinhMuc,
                                       itemDonTXL.NoiDung,
                                   };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonTXL6));

                ///Table DonTXL 7
                var queryDonTXL7 = from itemDonTXL in db.DonTXLs
                                   //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                                   join itemCTTTTL in db.CTTTTLs on itemDonTXL.MaDon equals itemCTTTTL.TTTL.MaDonTXL
                                   where itemCTTTTL.HoTen.Contains(HoTen)
                                   select new
                                   {
                                       ToXuLy = true,
                                       itemDonTXL.MaDon,
                                       itemDonTXL.LoaiDonTXL.TenLD,
                                       itemDonTXL.CreateDate,
                                       itemDonTXL.DanhBo,
                                       itemDonTXL.HoTen,
                                       itemDonTXL.DiaChi,
                                       itemDonTXL.GiaBieu,
                                       itemDonTXL.DinhMuc,
                                       itemDonTXL.NoiDung,
                                   };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonTXL7));

                ///Table DonTXL 8
                var queryDonTXL8 = from itemDonTXL in db.DonTXLs
                                   //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                                   join itemCTDongNuoc in db.CTDongNuocs on itemDonTXL.MaDon equals itemCTDongNuoc.DongNuoc.MaDonTXL
                                   where itemCTDongNuoc.HoTen.Contains(HoTen)
                                   select new
                                   {
                                       ToXuLy = true,
                                       itemDonTXL.MaDon,
                                       itemDonTXL.LoaiDonTXL.TenLD,
                                       itemDonTXL.CreateDate,
                                       itemDonTXL.DanhBo,
                                       itemDonTXL.HoTen,
                                       itemDonTXL.DiaChi,
                                       itemDonTXL.GiaBieu,
                                       itemDonTXL.DinhMuc,
                                       itemDonTXL.NoiDung,
                                   };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonTXL8));

                #endregion

                DataTable dtDon = new DataTable();
                dtDon.Columns.Add("ToXuLy", typeof(bool));
                dtDon.Columns.Add("MaDon", typeof(decimal));
                dtDon.Columns.Add("TenLD", typeof(string));
                dtDon.Columns.Add("CreateDate", typeof(string));
                dtDon.Columns.Add("DanhBo", typeof(string));
                dtDon.Columns.Add("HoTen", typeof(string));
                dtDon.Columns.Add("DiaChi", typeof(string));
                dtDon.Columns.Add("GiaBieu", typeof(string));
                dtDon.Columns.Add("DinhMuc", typeof(string));
                dtDon.Columns.Add("NoiDung", typeof(string));
                dtDon.TableName = "Don";
                foreach (DataRow itemRow in dt.Rows)
                {
                    if (dtDon.Select("MaDon = " + itemRow["MaDon"]).Count() <= 0)
                        dtDon.ImportRow(itemRow);
                }

                dtDon.DefaultView.Sort = "CreateDate ASC";
                ds.Tables.Add(dtDon.DefaultView.ToTable());

                if (dtDon.Rows.Count > 0 && dtKTXM.Rows.Count > 0)
                {
                    ds.Relations.Add("Chi Tiết Kiểm Tra Xác Minh", ds.Tables["Don"].Columns["MaDon"], ds.Tables["KTXM"].Columns["MaDon"]);
                    ds.Relations.Add("Chi Tiết Kiểm Tra Xác Minh TXL", ds.Tables["Don"].Columns["MaDon"], ds.Tables["KTXM"].Columns["MaDonTXL"]);
                }

                if (dtDon.Rows.Count > 0 && dtBamChi.Rows.Count > 0)
                {
                    ds.Relations.Add("Chi Tiết Bấm Chì", ds.Tables["Don"].Columns["MaDon"], ds.Tables["BamChi"].Columns["MaDon"]);
                    ds.Relations.Add("Chi Tiết Bấm Chì TXL", ds.Tables["Don"].Columns["MaDon"], ds.Tables["BamChi"].Columns["MaDonTXL"]);
                }

                if (dtDon.Rows.Count > 0 && dtDongNuoc.Rows.Count > 0)
                {
                    ds.Relations.Add("Chi Tiết Đóng Nước", ds.Tables["Don"].Columns["MaDon"], ds.Tables["DongNuoc"].Columns["MaDon"]);
                    ds.Relations.Add("Chi Tiết Đóng Nước TXL", ds.Tables["Don"].Columns["MaDon"], ds.Tables["DongNuoc"].Columns["MaDonTXL"]);
                }

                if (dtDon.Rows.Count > 0 && dtDCBD.Rows.Count > 0)
                {
                    ds.Relations.Add("Chi Tiết Điều Chỉnh Biến Động", ds.Tables["Don"].Columns["MaDon"], ds.Tables["DCBD"].Columns["MaDon"]);
                    ds.Relations.Add("Chi Tiết Điều Chỉnh Biến Động TXL", ds.Tables["Don"].Columns["MaDon"], ds.Tables["DCBD"].Columns["MaDonTXL"]);
                }

                if (dtDon.Rows.Count > 0 && dtCHDB.Rows.Count > 0)
                {
                    ds.Relations.Add("Chi Tiết Cắt Tạm/Hủy Danh Bộ", ds.Tables["Don"].Columns["MaDon"], ds.Tables["CHDB"].Columns["MaDon"]);
                    ds.Relations.Add("Chi Tiết Cắt Tạm/Hủy Danh Bộ TXL", ds.Tables["Don"].Columns["MaDon"], ds.Tables["CHDB"].Columns["MaDonTXL"]);
                }

                if (dtDon.Rows.Count > 0 && dtTTTL.Rows.Count > 0)
                {
                    ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời", ds.Tables["Don"].Columns["MaDon"], ds.Tables["TTTL"].Columns["MaDon"]);
                    ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời TXL", ds.Tables["Don"].Columns["MaDon"], ds.Tables["TTTL"].Columns["MaDonTXL"]);
                }

                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataSet GetTienTrinhbyDiaChi(string DiaChi)
        {
            try
            {
                DataSet ds = new DataSet();

                ///Table CTKTXM
                var queryKTXM = from itemCTKTXM in db.CTKTXMs
                                join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                where itemCTKTXM.DiaChi.Contains(DiaChi)
                                select new
                                {
                                    itemCTKTXM.KTXM.MaDon,
                                    itemCTKTXM.KTXM.ToXuLy,
                                    itemCTKTXM.KTXM.MaDonTXL,
                                    itemCTKTXM.MaCTKTXM,
                                    itemCTKTXM.NgayKTXM,
                                    itemCTKTXM.DanhBo,
                                    itemCTKTXM.HoTen,
                                    itemCTKTXM.DiaChi,
                                    itemCTKTXM.NoiDungKiemTra,
                                    CreateBy = itemUser.HoTen,
                                    itemCTKTXM.NgayDongTien,
                                    itemCTKTXM.SoTien,
                                };
                DataTable dtKTXM = new DataTable();
                dtKTXM = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryKTXM);
                dtKTXM.TableName = "KTXM";
                ds.Tables.Add(dtKTXM);

                ///Table CTBamChi
                var queryBamChi = from itemCTBamChi in db.CTBamChis
                                  join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                                  where itemCTBamChi.DiaChi.Contains(DiaChi)
                                  select new
                                  {
                                      itemCTBamChi.BamChi.MaDon,
                                      itemCTBamChi.BamChi.ToXuLy,
                                      itemCTBamChi.BamChi.MaDonTXL,
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
                dtBamChi = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryBamChi);
                dtBamChi.TableName = "BamChi";
                ds.Tables.Add(dtBamChi);

                ///Table CTDongNuoc
                var queryDongNuoc = from itemCTDongNuoc in db.CTDongNuocs
                                  join itemUser in db.Users on itemCTDongNuoc.CreateBy equals itemUser.MaU
                                  where itemCTDongNuoc.DiaChi.Contains(DiaChi)
                                  select new
                                  {
                                      itemCTDongNuoc.DongNuoc.MaDon,
                                      itemCTDongNuoc.DongNuoc.ToXuLy,
                                      itemCTDongNuoc.DongNuoc.MaDonTXL,
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
                dtDongNuoc = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDongNuoc);
                dtDongNuoc.TableName = "DongNuoc";
                ds.Tables.Add(dtDongNuoc);

                ///Table CTDCBD
                var queryCTDCBD = from itemCTDCBD in db.CTDCBDs
                                  join itemUser in db.Users on itemCTDCBD.CreateBy equals itemUser.MaU
                                  where itemCTDCBD.DiaChi.Contains(DiaChi)
                                  select new
                                  {
                                      itemCTDCBD.DCBD.MaDon,
                                      itemCTDCBD.DCBD.ToXuLy,
                                      itemCTDCBD.DCBD.MaDonTXL,
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
                                  where itemCTDCHD.DiaChi.Contains(DiaChi)
                                  select new
                                  {
                                      itemCTDCHD.DCBD.MaDon,
                                      itemCTDCHD.DCBD.ToXuLy,
                                      itemCTDCHD.DCBD.MaDonTXL,
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
                                      CreateBy=itemUser.HoTen,
                                  };
                DataTable dtDCBD = new DataTable();
                dtDCBD = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTDCBD);
                dtDCBD.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTDCHD));
                dtDCBD.TableName = "DCBD";
                ds.Tables.Add(dtDCBD);

                ///Table CTCTDB
                var queryCTCTDB = from itemCTCTDB in db.CTCTDBs
                                  where itemCTCTDB.DiaChi.Contains(DiaChi)
                                  select new
                                  {
                                      itemCTCTDB.CHDB.MaDon,
                                      itemCTCTDB.CHDB.ToXuLy,
                                      itemCTCTDB.CHDB.MaDonTXL,
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
                                  where itemCTCHDB.DiaChi.Contains(DiaChi)
                                  select new
                                  {
                                      itemCTCHDB.CHDB.MaDon,
                                      itemCTCHDB.CHDB.ToXuLy,
                                      itemCTCHDB.CHDB.MaDonTXL,
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
                dtCHDB = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTCTDB);
                dtCHDB.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTCHDB));
                dtCHDB.TableName = "CHDB";
                ds.Tables.Add(dtCHDB);

                ///Table CTTTTL
                var queryTTTL = from itemCTTTTL in db.CTTTTLs
                                where itemCTTTTL.DiaChi.Contains(DiaChi)
                                select new
                                {
                                    itemCTTTTL.TTTL.MaDon,
                                    itemCTTTTL.TTTL.ToXuLy,
                                    itemCTTTTL.TTTL.MaDonTXL,
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
                dtTTTL = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryTTTL);
                dtTTTL.TableName = "TTTL";
                ds.Tables.Add(dtTTTL);

                #region DonKH

                ///Table DonKH
                var queryDon = from itemDon in db.DonKHs
                            where itemDon.DiaChi.Contains(DiaChi)
                               select new
                               {
                                   ToXuLy = false,
                                   itemDon.MaDon,
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
                dt = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon);

                ///Table DonKH 1
                var queryDon1 = from itemDon in db.DonKHs
                               //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                               join itemCTKTXM in db.CTKTXMs on itemDon.MaDon equals itemCTKTXM.KTXM.MaDon
                               where itemCTKTXM.DiaChi.Contains(DiaChi)
                               select new
                               {
                                   ToXuLy = false,
                                   itemDon.MaDon,
                                   itemDon.LoaiDon.TenLD,
                                   itemDon.CreateDate,
                                   itemDon.DanhBo,
                                   itemDon.HoTen,
                                   itemDon.DiaChi,
                                   itemDon.GiaBieu,
                                   itemDon.DinhMuc,
                                   itemDon.NoiDung,
                               };
                //DataTable dt = new DataTable();
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon1));

                ///Table DonKH 2
                var queryDon2 = from itemDon in db.DonKHs
                                join itemCTBamChi in db.CTBamChis on itemDon.MaDon equals itemCTBamChi.BamChi.MaDon
                                where itemCTBamChi.DiaChi.Contains(DiaChi)
                                select new
                                {
                                    ToXuLy = false,
                                    itemDon.MaDon,
                                    itemDon.LoaiDon.TenLD,
                                    itemDon.CreateDate,
                                    itemDon.DanhBo,
                                    itemDon.HoTen,
                                    itemDon.DiaChi,
                                    itemDon.GiaBieu,
                                    itemDon.DinhMuc,
                                    itemDon.NoiDung,
                                };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon2));

                ///Table DonKH 3
                var queryDon3 = from itemDon in db.DonKHs
                                join itemCTDCBD in db.CTDCBDs on itemDon.MaDon equals itemCTDCBD.DCBD.MaDon
                                where itemCTDCBD.DiaChi.Contains(DiaChi)
                                select new
                                {
                                    ToXuLy = false,
                                    itemDon.MaDon,
                                    itemDon.LoaiDon.TenLD,
                                    itemDon.CreateDate,
                                    itemDon.DanhBo,
                                    itemDon.HoTen,
                                    itemDon.DiaChi,
                                    itemDon.GiaBieu,
                                    itemDon.DinhMuc,
                                    itemDon.NoiDung,
                                };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon3));

                ///Table DonKH 4
                var queryDon4 = from itemDon in db.DonKHs
                                join itemCTDCHD in db.CTDCHDs on itemDon.MaDon equals itemCTDCHD.DCBD.MaDon
                                where itemCTDCHD.DiaChi.Contains(DiaChi)
                                select new
                                {
                                    ToXuLy = false,
                                    itemDon.MaDon,
                                    itemDon.LoaiDon.TenLD,
                                    itemDon.CreateDate,
                                    itemDon.DanhBo,
                                    itemDon.HoTen,
                                    itemDon.DiaChi,
                                    itemDon.GiaBieu,
                                    itemDon.DinhMuc,
                                    itemDon.NoiDung,
                                };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon4));

                ///Table DonKH 5
                var queryDon5 = from itemDon in db.DonKHs
                                join itemCTCTDB in db.CTCTDBs on itemDon.MaDon equals itemCTCTDB.CHDB.MaDon
                                where itemCTCTDB.DiaChi.Contains(DiaChi)
                                select new
                                {
                                    ToXuLy = false,
                                    itemDon.MaDon,
                                    itemDon.LoaiDon.TenLD,
                                    itemDon.CreateDate,
                                    itemDon.DanhBo,
                                    itemDon.HoTen,
                                    itemDon.DiaChi,
                                    itemDon.GiaBieu,
                                    itemDon.DinhMuc,
                                    itemDon.NoiDung,
                                };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon5));

                ///Table DonKH 6
                var queryDon6 = from itemDon in db.DonKHs
                                join itemCTCHDB in db.CTCHDBs on itemDon.MaDon equals itemCTCHDB.CHDB.MaDon
                                where itemCTCHDB.DiaChi.Contains(DiaChi)
                                select new
                                {
                                    ToXuLy = false,
                                    itemDon.MaDon,
                                    itemDon.LoaiDon.TenLD,
                                    itemDon.CreateDate,
                                    itemDon.DanhBo,
                                    itemDon.HoTen,
                                    itemDon.DiaChi,
                                    itemDon.GiaBieu,
                                    itemDon.DinhMuc,
                                    itemDon.NoiDung,
                                };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon6));

                ///Table DonKH 7
                var queryDon7 = from itemDon in db.DonKHs
                                join itemCTTTTL in db.CTTTTLs on itemDon.MaDon equals itemCTTTTL.TTTL.MaDon
                                where itemCTTTTL.DiaChi.Contains(DiaChi)
                                select new
                                {
                                    ToXuLy = false,
                                    itemDon.MaDon,
                                    itemDon.LoaiDon.TenLD,
                                    itemDon.CreateDate,
                                    itemDon.DanhBo,
                                    itemDon.HoTen,
                                    itemDon.DiaChi,
                                    itemDon.GiaBieu,
                                    itemDon.DinhMuc,
                                    itemDon.NoiDung,
                                };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon7));

                ///Table DonKH 8
                var queryDon8= from itemDon in db.DonKHs
                               join itemCTDongNuoc in db.CTDongNuocs on itemDon.MaDon equals itemCTDongNuoc.DongNuoc.MaDon
                               where itemCTDongNuoc.DiaChi.Contains(DiaChi)
                                select new
                                {
                                    ToXuLy = false,
                                    itemDon.MaDon,
                                    itemDon.LoaiDon.TenLD,
                                    itemDon.CreateDate,
                                    itemDon.DanhBo,
                                    itemDon.HoTen,
                                    itemDon.DiaChi,
                                    itemDon.GiaBieu,
                                    itemDon.DinhMuc,
                                    itemDon.NoiDung,
                                };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon8));
                #endregion

                #region DonTXL

                ///Table DonTXL
                var queryDonTXL = from itemDonTXL in db.DonTXLs
                               where itemDonTXL.DiaChi.Contains(DiaChi)
                                  select new
                                  {
                                      ToXuLy = true,
                                      itemDonTXL.MaDon,
                                      itemDonTXL.LoaiDonTXL.TenLD,
                                      itemDonTXL.CreateDate,
                                      itemDonTXL.DanhBo,
                                      itemDonTXL.HoTen,
                                      itemDonTXL.DiaChi,
                                      itemDonTXL.GiaBieu,
                                      itemDonTXL.DinhMuc,
                                      itemDonTXL.NoiDung,
                                  };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonTXL));

                ///Table DonTXL 1
                var queryDonTXL1 = from itemDonTXL in db.DonTXLs
                                  //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                                  join itemCTKTXM in db.CTKTXMs on itemDonTXL.MaDon equals itemCTKTXM.KTXM.MaDonTXL
                                  where itemCTKTXM.DiaChi.Contains(DiaChi)
                                  select new
                                  {
                                      ToXuLy = true,
                                      itemDonTXL.MaDon,
                                      itemDonTXL.LoaiDonTXL.TenLD,
                                      itemDonTXL.CreateDate,
                                      itemDonTXL.DanhBo,
                                      itemDonTXL.HoTen,
                                      itemDonTXL.DiaChi,
                                      itemDonTXL.GiaBieu,
                                      itemDonTXL.DinhMuc,
                                      itemDonTXL.NoiDung,
                                  };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonTXL1));

                ///Table DonTXL 2
                var queryDonTXL2 = from itemDonTXL in db.DonTXLs
                                   //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                                   join itemCTBamChi in db.CTBamChis on itemDonTXL.MaDon equals itemCTBamChi.BamChi.MaDonTXL
                                   where itemCTBamChi.DiaChi.Contains(DiaChi)
                                   select new
                                   {
                                       ToXuLy = true,
                                       itemDonTXL.MaDon,
                                       itemDonTXL.LoaiDonTXL.TenLD,
                                       itemDonTXL.CreateDate,
                                       itemDonTXL.DanhBo,
                                       itemDonTXL.HoTen,
                                       itemDonTXL.DiaChi,
                                       itemDonTXL.GiaBieu,
                                       itemDonTXL.DinhMuc,
                                       itemDonTXL.NoiDung,
                                   };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonTXL2));

                ///Table DonTXL 3
                var queryDonTXL3 = from itemDonTXL in db.DonTXLs
                                  //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                                  join itemCTDCBD in db.CTDCBDs on itemDonTXL.MaDon equals itemCTDCBD.DCBD.MaDonTXL
                                   where itemCTDCBD.DiaChi.Contains(DiaChi)
                                  select new
                                  {
                                      ToXuLy = true,
                                      itemDonTXL.MaDon,
                                      itemDonTXL.LoaiDonTXL.TenLD,
                                      itemDonTXL.CreateDate,
                                      itemDonTXL.DanhBo,
                                      itemDonTXL.HoTen,
                                      itemDonTXL.DiaChi,
                                      itemDonTXL.GiaBieu,
                                      itemDonTXL.DinhMuc,
                                      itemDonTXL.NoiDung,
                                  };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonTXL3));

                ///Table DonTXL 4
                var queryDonTXL4 = from itemDonTXL in db.DonTXLs
                                  //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                                   join itemCTDCHD in db.CTDCHDs on itemDonTXL.MaDon equals itemCTDCHD.DCBD.MaDonTXL
                                   where itemCTDCHD.DiaChi.Contains(DiaChi)
                                  select new
                                  {
                                      ToXuLy = true,
                                      itemDonTXL.MaDon,
                                      itemDonTXL.LoaiDonTXL.TenLD,
                                      itemDonTXL.CreateDate,
                                      itemDonTXL.DanhBo,
                                      itemDonTXL.HoTen,
                                      itemDonTXL.DiaChi,
                                      itemDonTXL.GiaBieu,
                                      itemDonTXL.DinhMuc,
                                      itemDonTXL.NoiDung,
                                  };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonTXL4));

                ///Table DonTXL 5
                var queryDonTXL5 = from itemDonTXL in db.DonTXLs
                                   //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                                   join itemCTCTDB in db.CTCTDBs on itemDonTXL.MaDon equals itemCTCTDB.CHDB.MaDonTXL
                                   where itemCTCTDB.DiaChi.Contains(DiaChi)
                                   select new
                                   {
                                       ToXuLy = true,
                                       itemDonTXL.MaDon,
                                       itemDonTXL.LoaiDonTXL.TenLD,
                                       itemDonTXL.CreateDate,
                                       itemDonTXL.DanhBo,
                                       itemDonTXL.HoTen,
                                       itemDonTXL.DiaChi,
                                       itemDonTXL.GiaBieu,
                                       itemDonTXL.DinhMuc,
                                       itemDonTXL.NoiDung,
                                   };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonTXL5));

                ///Table DonTXL 6
                var queryDonTXL6 = from itemDonTXL in db.DonTXLs
                                   //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                                   join itemCTCHDB in db.CTCHDBs on itemDonTXL.MaDon equals itemCTCHDB.CHDB.MaDonTXL
                                   where itemCTCHDB.DiaChi.Contains(DiaChi)
                                   select new
                                   {
                                       ToXuLy = true,
                                       itemDonTXL.MaDon,
                                       itemDonTXL.LoaiDonTXL.TenLD,
                                       itemDonTXL.CreateDate,
                                       itemDonTXL.DanhBo,
                                       itemDonTXL.HoTen,
                                       itemDonTXL.DiaChi,
                                       itemDonTXL.GiaBieu,
                                       itemDonTXL.DinhMuc,
                                       itemDonTXL.NoiDung,
                                   };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonTXL6));

                ///Table DonTXL 7
                var queryDonTXL7 = from itemDonTXL in db.DonTXLs
                                   //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                                   join itemCTTTTL in db.CTTTTLs on itemDonTXL.MaDon equals itemCTTTTL.TTTL.MaDonTXL
                                   where itemCTTTTL.DiaChi.Contains(DiaChi)
                                   select new
                                   {
                                       ToXuLy = true,
                                       itemDonTXL.MaDon,
                                       itemDonTXL.LoaiDonTXL.TenLD,
                                       itemDonTXL.CreateDate,
                                       itemDonTXL.DanhBo,
                                       itemDonTXL.HoTen,
                                       itemDonTXL.DiaChi,
                                       itemDonTXL.GiaBieu,
                                       itemDonTXL.DinhMuc,
                                       itemDonTXL.NoiDung,
                                   };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonTXL7));

                ///Table DonTXL 8
                var queryDonTXL8 = from itemDonTXL in db.DonTXLs
                                   //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                                   join itemCTDongNuoc in db.CTDongNuocs on itemDonTXL.MaDon equals itemCTDongNuoc.DongNuoc.MaDonTXL
                                   where itemCTDongNuoc.DiaChi.Contains(DiaChi)
                                   select new
                                   {
                                       ToXuLy = true,
                                       itemDonTXL.MaDon,
                                       itemDonTXL.LoaiDonTXL.TenLD,
                                       itemDonTXL.CreateDate,
                                       itemDonTXL.DanhBo,
                                       itemDonTXL.HoTen,
                                       itemDonTXL.DiaChi,
                                       itemDonTXL.GiaBieu,
                                       itemDonTXL.DinhMuc,
                                       itemDonTXL.NoiDung,
                                   };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonTXL8));
                #endregion

                DataTable dtDon = new DataTable();
                dtDon.Columns.Add("ToXuLy", typeof(bool));
                dtDon.Columns.Add("MaDon", typeof(decimal));
                dtDon.Columns.Add("TenLD", typeof(string));
                dtDon.Columns.Add("CreateDate", typeof(string));
                dtDon.Columns.Add("DanhBo", typeof(string));
                dtDon.Columns.Add("HoTen", typeof(string));
                dtDon.Columns.Add("DiaChi", typeof(string));
                dtDon.Columns.Add("GiaBieu", typeof(string));
                dtDon.Columns.Add("DinhMuc", typeof(string));
                dtDon.Columns.Add("NoiDung", typeof(string));
                dtDon.TableName = "Don";
                foreach (DataRow itemRow in dt.Rows)
                {
                    if (dtDon.Select("MaDon = " + itemRow["MaDon"]).Count() <= 0)
                        dtDon.ImportRow(itemRow);
                }

                dtDon.DefaultView.Sort = "CreateDate ASC";
                ds.Tables.Add(dtDon.DefaultView.ToTable());

                if (dtDon.Rows.Count > 0 && dtKTXM.Rows.Count > 0)
                {
                    ds.Relations.Add("Chi Tiết Kiểm Tra Xác Minh", ds.Tables["Don"].Columns["MaDon"], ds.Tables["KTXM"].Columns["MaDon"]);
                    ds.Relations.Add("Chi Tiết Kiểm Tra Xác Minh TXL", ds.Tables["Don"].Columns["MaDon"], ds.Tables["KTXM"].Columns["MaDonTXL"]);
                }

                if (dtDon.Rows.Count > 0 && dtBamChi.Rows.Count > 0)
                {
                    ds.Relations.Add("Chi Tiết Bấm Chì", ds.Tables["Don"].Columns["MaDon"], ds.Tables["BamChi"].Columns["MaDon"]);
                    ds.Relations.Add("Chi Tiết Bấm Chì TXL", ds.Tables["Don"].Columns["MaDon"], ds.Tables["BamChi"].Columns["MaDonTXL"]);
                }

                if (dtDon.Rows.Count > 0 && dtDongNuoc.Rows.Count > 0)
                {
                    ds.Relations.Add("Chi Tiết Đóng Nước", ds.Tables["Don"].Columns["MaDon"], ds.Tables["DongNuoc"].Columns["MaDon"]);
                    ds.Relations.Add("Chi Tiết Đóng Nước TXL", ds.Tables["Don"].Columns["MaDon"], ds.Tables["DongNuoc"].Columns["MaDonTXL"]);
                }

                if (dtDon.Rows.Count > 0 && dtDCBD.Rows.Count > 0)
                {
                    ds.Relations.Add("Chi Tiết Điều Chỉnh Biến Động", ds.Tables["Don"].Columns["MaDon"], ds.Tables["DCBD"].Columns["MaDon"]);
                    ds.Relations.Add("Chi Tiết Điều Chỉnh Biến Động TXL", ds.Tables["Don"].Columns["MaDon"], ds.Tables["DCBD"].Columns["MaDonTXL"]);
                }

                if (dtDon.Rows.Count > 0 && dtCHDB.Rows.Count > 0)
                {
                    ds.Relations.Add("Chi Tiết Cắt Tạm/Hủy Danh Bộ", ds.Tables["Don"].Columns["MaDon"], ds.Tables["CHDB"].Columns["MaDon"]);
                    ds.Relations.Add("Chi Tiết Cắt Tạm/Hủy Danh Bộ TXL", ds.Tables["Don"].Columns["MaDon"], ds.Tables["CHDB"].Columns["MaDonTXL"]);
                }

                if (dtDon.Rows.Count > 0 && dtTTTL.Rows.Count > 0)
                {
                    ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời", ds.Tables["Don"].Columns["MaDon"], ds.Tables["TTTL"].Columns["MaDon"]);
                    ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời TXL", ds.Tables["Don"].Columns["MaDon"], ds.Tables["TTTL"].Columns["MaDonTXL"]);
                }

                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
