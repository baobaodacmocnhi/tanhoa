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
                                     itemDon.MaDon,
                                     itemDon.LoaiDon.TenLD,
                                     itemDon.CreateDate,
                                     itemDon.DanhBo,
                                     itemDon.HoTen,
                                     itemDon.DiaChi,
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
                                    itemCTKTXM.CreateDate,
                                    itemCTKTXM.DanhBo,
                                    itemCTKTXM.NoiDungKiemTra,
                                    CreateBy = itemUser.HoTen,
                                };

                DataTable dtKTXM = new DataTable();
                dtKTXM = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryKTXM);
                dtKTXM.TableName = "KTXM";
                ds.Tables.Add(dtKTXM);

                ///Table CTDCBD
                var queryCTDCBD = from itemCTDCBD in db.CTDCBDs
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
                                  };
                ///Bảng CTDCHD
                var queryCTDCHD = from itemCTDCHD in db.CTDCHDs
                                  where itemCTDCHD.DCBD.MaDon == MaDon
                                  select new
                                  {
                                      MaDC = itemCTDCHD.MaCTDCHD,
                                      DieuChinh = "Hóa Đơn",
                                      itemCTDCHD.CreateDate,
                                      itemCTDCHD.DanhBo,
                                      itemCTDCHD.HoTen,
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

                if (dtDon.Rows.Count > 0 && dtDCBD.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Điều Chỉnh Biến Động", ds.Tables["Don"].Columns["MaDon"], ds.Tables["DCBD"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtCHDB.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Cắt Hủy Danh Bộ", ds.Tables["Don"].Columns["MaDon"], ds.Tables["CHDB"].Columns["MaDon"]);

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
                                   itemDonTXL.MaDon,
                                   itemDonTXL.LoaiDonTXL.TenLD,
                                   itemDonTXL.CreateDate,
                                   itemDonTXL.DanhBo,
                                   itemDonTXL.HoTen,
                                   itemDonTXL.DiaChi,
                                   itemDonTXL.NoiDung,
                               };
                DataTable dtDon = new DataTable();
                dtDon = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon);
                dtDon.TableName = "Don";
                ds.Tables.Add(dtDon);

                ///Table KTXM
                var queryKTXM = from itemCTKTXM in db.CTKTXMs
                                join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                where itemCTKTXM.KTXM.MaDonTXL == MaDonTXL
                                select new
                                {
                                    MaDon = itemCTKTXM.KTXM.MaDonTXL,
                                    itemCTKTXM.MaCTKTXM,
                                    itemCTKTXM.CreateDate,
                                    itemCTKTXM.DanhBo,
                                    itemCTKTXM.NoiDungKiemTra,
                                    CreateBy=itemUser.HoTen,
                                };

                DataTable dtKTXM = new DataTable();
                dtKTXM = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryKTXM);
                dtKTXM.TableName = "KTXM";
                ds.Tables.Add(dtKTXM);

                ///Table CTDCBD
                var queryCTDCBD = from itemCTDCBD in db.CTDCBDs
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
                                  };
                ///Bảng CTDCHD
                var queryCTDCHD = from itemCTDCHD in db.CTDCHDs
                                  where itemCTDCHD.DCBD.MaDonTXL == MaDonTXL
                                  select new
                                  {
                                      MaDC = itemCTDCHD.MaCTDCHD,
                                      DieuChinh = "Hóa Đơn",
                                      itemCTDCHD.CreateDate,
                                      itemCTDCHD.DanhBo,
                                      itemCTDCHD.HoTen,
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
                                  };

                DataTable dtCHDB = new DataTable();
                dtCHDB = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTCTDB);
                dtCHDB.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTCHDB));
                dtCHDB.TableName = "CHDB";
                ds.Tables.Add(dtCHDB);

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

                if (dtDon.Rows.Count > 0 && dtDCBD.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Điều Chỉnh Biến Động", ds.Tables["Don"].Columns["MaDon"], ds.Tables["DCBD"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtCHDB.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Cắt Hủy Danh Bộ", ds.Tables["Don"].Columns["MaDon"], ds.Tables["CHDB"].Columns["MaDon"]);

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

        public DataSet GetTienTrinhbyDanhBo(string DanhBo)
        {
            try
            {
                DataSet ds = new DataSet();
                ///Table DonKH
                var queryDon = from itemDon in db.DonKHs
                               where itemDon.DanhBo == DanhBo
                               select new
                               {
                                   itemDon.MaDon,
                                   itemDon.LoaiDon.TenLD,
                                   itemDon.CreateDate,
                                   itemDon.DanhBo,
                                   itemDon.HoTen,
                                   itemDon.DiaChi,
                                   itemDon.NoiDung,
                               };
                DataTable dtDon = new DataTable();
                dtDon = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon);
                dtDon.TableName = "Don";
                ds.Tables.Add(dtDon);

                ///Table CTKTXM
                var queryKTXM = from itemCTKTXM in db.CTKTXMs
                                join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                //where itemCTKTXM.KTXM.MaDon == MaDon
                                select new
                                {
                                    itemCTKTXM.KTXM.MaDon,
                                    itemCTKTXM.MaCTKTXM,
                                    itemCTKTXM.CreateDate,
                                    itemCTKTXM.DanhBo,
                                    itemCTKTXM.NoiDungKiemTra,
                                    CreateBy = itemUser.HoTen,
                                };

                DataTable dtKTXM = new DataTable();
                dtKTXM = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryKTXM);
                dtKTXM.TableName = "KTXM";
                ds.Tables.Add(dtKTXM);

                ///Table CTDCBD
                var queryCTDCBD = from itemCTDCBD in db.CTDCBDs
                                  //where itemCTDCBD.DCBD.MaDon == MaDon
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
                                  };
                ///Bảng CTDCHD
                var queryCTDCHD = from itemCTDCHD in db.CTDCHDs
                                  //where itemCTDCHD.DCBD.MaDon == MaDon
                                  select new
                                  {
                                      MaDC = itemCTDCHD.MaCTDCHD,
                                      DieuChinh = "Hóa Đơn",
                                      itemCTDCHD.CreateDate,
                                      itemCTDCHD.DanhBo,
                                      itemCTDCHD.HoTen,
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
                                  };

                DataTable dtDCBD = new DataTable();
                dtDCBD = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTDCBD);
                dtDCBD.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTDCHD));
                dtDCBD.TableName = "DCBD";
                ds.Tables.Add(dtDCBD);

                ///Table CTCTDB
                var queryCTCTDB = from itemCTCTDB in db.CTCTDBs
                                  //where itemCTCTDB.CHDB.MaDon == MaDon
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
                                      itemCTCTDB.CHDB.MaDon,
                                  };


                ///Table CTCHDB
                var queryCTCHDB = from itemCTCHDB in db.CTCHDBs
                                  //where itemCTCHDB.CHDB.MaDon == MaDon
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
                                  };

                DataTable dtCHDB = new DataTable();
                dtCHDB = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTCTDB);
                dtCHDB.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTCHDB));
                dtCHDB.TableName = "CHDB";
                ds.Tables.Add(dtCHDB);

                ///Table CTTTTL
                var queryTTTL = from itemCTTTTL in db.CTTTTLs
                                //where itemCTTTTL.TTTL.MaDon == MaDon
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

                if (dtDon.Rows.Count > 0 && dtDCBD.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Điều Chỉnh Biến Động", ds.Tables["Don"].Columns["MaDon"], ds.Tables["DCBD"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtCHDB.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Cắt Hủy Danh Bộ", ds.Tables["Don"].Columns["MaDon"], ds.Tables["CHDB"].Columns["MaDon"]);

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

        public DataSet GetTienTrinhbyDanhBo_TXL(string DanhBo)
        {
            try
            {
                DataSet ds = new DataSet();
                ///Table DonTXL
                var queryDon = from itemDonTXL in db.DonTXLs
                               where itemDonTXL.DanhBo == DanhBo
                               select new
                               {
                                   itemDonTXL.MaDon,
                                   itemDonTXL.LoaiDonTXL.TenLD,
                                   itemDonTXL.CreateDate,
                                   itemDonTXL.DanhBo,
                                   itemDonTXL.HoTen,
                                   itemDonTXL.DiaChi,
                                   itemDonTXL.NoiDung,
                               };
                DataTable dtDon = new DataTable();
                dtDon = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon);
                dtDon.TableName = "Don";
                ds.Tables.Add(dtDon);

                ///Table KTXM
                var queryKTXM = from itemCTKTXM in db.CTKTXMs
                                join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                //where itemCTKTXM.KTXM.MaDonTXL == MaDonTXL
                                select new
                                {
                                    MaDon = itemCTKTXM.KTXM.MaDonTXL,
                                    itemCTKTXM.MaCTKTXM,
                                    itemCTKTXM.CreateDate,
                                    itemCTKTXM.DanhBo,
                                    itemCTKTXM.NoiDungKiemTra,
                                    CreateBy = itemUser.HoTen,
                                };

                DataTable dtKTXM = new DataTable();
                dtKTXM = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryKTXM);
                dtKTXM.TableName = "KTXM";
                ds.Tables.Add(dtKTXM);

                ///Table CTDCBD
                var queryCTDCBD = from itemCTDCBD in db.CTDCBDs
                                  //where itemCTDCBD.DCBD.MaDonTXL == MaDonTXL
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
                                      MaDon = itemCTDCBD.DCBD.MaDonTXL,
                                  };
                ///Bảng CTDCHD
                var queryCTDCHD = from itemCTDCHD in db.CTDCHDs
                                  //where itemCTDCHD.DCBD.MaDonTXL == MaDonTXL
                                  select new
                                  {
                                      MaDC = itemCTDCHD.MaCTDCHD,
                                      DieuChinh = "Hóa Đơn",
                                      itemCTDCHD.CreateDate,
                                      itemCTDCHD.DanhBo,
                                      itemCTDCHD.HoTen,
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
                                      MaDon = itemCTDCHD.DCBD.MaDonTXL,
                                  };

                DataTable dtDCBD = new DataTable();
                dtDCBD = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTDCBD);
                dtDCBD.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTDCHD));
                dtDCBD.TableName = "DCBD";
                ds.Tables.Add(dtDCBD);

                ///Table CTCTDB
                var queryCTCTDB = from itemCTCTDB in db.CTCTDBs
                                  //where itemCTCTDB.CHDB.MaDonTXL == MaDonTXL
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
                                      MaDon = itemCTCTDB.CHDB.MaDonTXL,
                                  };


                ///Table CTCHDB
                var queryCTCHDB = from itemCTCHDB in db.CTCHDBs
                                  //where itemCTCHDB.CHDB.MaDonTXL == MaDonTXL
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
                                  };

                DataTable dtCHDB = new DataTable();
                dtCHDB = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTCTDB);
                dtCHDB.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTCHDB));
                dtCHDB.TableName = "CHDB";
                ds.Tables.Add(dtCHDB);

                ///Table CTTTTL
                var queryTTTL = from itemCTTTTL in db.CTTTTLs
                                //where itemCTTTTL.TTTL.MaDonTXL == MaDonTXL
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

                if (dtDon.Rows.Count > 0 && dtDCBD.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Điều Chỉnh Biến Động", ds.Tables["Don"].Columns["MaDon"], ds.Tables["DCBD"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtCHDB.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Cắt Hủy Danh Bộ", ds.Tables["Don"].Columns["MaDon"], ds.Tables["CHDB"].Columns["MaDon"]);

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
    }
}
