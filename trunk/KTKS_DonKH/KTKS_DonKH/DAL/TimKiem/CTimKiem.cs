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
                                  where itemCTDCBD.DanhBo == DanhBo
                                  select new
                                  {
                                      itemCTDCBD.DCBD.MaDon,
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
                                  };

                ///Bảng CTDCHD
                var queryCTDCHD = from itemCTDCHD in db.CTDCHDs
                                  where itemCTDCHD.DanhBo == DanhBo
                                  select new
                                  {
                                      itemCTDCHD.DCBD.MaDon,
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

                ///Table DonKH 1
                var queryDon = from itemDon in db.DonKHs
                               //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                               join itemCTKTXM in db.CTKTXMs on itemDon.MaDon equals itemCTKTXM.KTXM.MaDon
                               where itemCTKTXM.DanhBo == DanhBo
                               select new
                               {
                                   TXL=false,
                                   itemDon.MaDon,
                                   itemDon.LoaiDon.TenLD,
                                   itemDon.CreateDate,
                                   itemDon.DanhBo,
                                   itemDon.HoTen,
                                   itemDon.DiaChi,
                                   itemDon.NoiDung,
                               };
                DataTable dt = new DataTable();
                dt = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon);

                ///Table DonKH 2
                var queryDon2 = from itemDon in db.DonKHs
                                join itemCTDCBD in db.CTDCBDs on itemDon.MaDon equals itemCTDCBD.DCBD.MaDon
                                where itemCTDCBD.DanhBo == DanhBo
                                select new
                                {
                                    TXL = false,
                                    itemDon.MaDon,
                                    itemDon.LoaiDon.TenLD,
                                    itemDon.CreateDate,
                                    itemDon.DanhBo,
                                    itemDon.HoTen,
                                    itemDon.DiaChi,
                                    itemDon.NoiDung,
                                };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon2));

                ///Table DonKH 3
                var queryDon3 = from itemDon in db.DonKHs
                                join itemCTDCHD in db.CTDCHDs on itemDon.MaDon equals itemCTDCHD.DCBD.MaDon
                                where itemCTDCHD.DanhBo == DanhBo
                                select new
                                {
                                    TXL = false,
                                    itemDon.MaDon,
                                    itemDon.LoaiDon.TenLD,
                                    itemDon.CreateDate,
                                    itemDon.DanhBo,
                                    itemDon.HoTen,
                                    itemDon.DiaChi,
                                    itemDon.NoiDung,
                                };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon3));

                ///Table DonKH 4
                var queryDon4 = from itemDon in db.DonKHs
                                join itemCTCTDB in db.CTCTDBs on itemDon.MaDon equals itemCTCTDB.CHDB.MaDon
                                where itemCTCTDB.DanhBo == DanhBo
                                select new
                                {
                                    TXL = false,
                                    itemDon.MaDon,
                                    itemDon.LoaiDon.TenLD,
                                    itemDon.CreateDate,
                                    itemDon.DanhBo,
                                    itemDon.HoTen,
                                    itemDon.DiaChi,
                                    itemDon.NoiDung,
                                };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon4));

                ///Table DonKH 5
                var queryDon5 = from itemDon in db.DonKHs
                                join itemCTCHDB in db.CTCHDBs on itemDon.MaDon equals itemCTCHDB.CHDB.MaDon
                                where itemCTCHDB.DanhBo == DanhBo
                                select new
                                {
                                    TXL = false,
                                    itemDon.MaDon,
                                    itemDon.LoaiDon.TenLD,
                                    itemDon.CreateDate,
                                    itemDon.DanhBo,
                                    itemDon.HoTen,
                                    itemDon.DiaChi,
                                    itemDon.NoiDung,
                                };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon5));

                ///Table DonKH 6
                var queryDon6 = from itemDon in db.DonKHs
                                join itemCTTTTL in db.CTTTTLs on itemDon.MaDon equals itemCTTTTL.TTTL.MaDon
                                where itemCTTTTL.DanhBo == DanhBo
                                select new
                                {
                                    TXL = false,
                                    itemDon.MaDon,
                                    itemDon.LoaiDon.TenLD,
                                    itemDon.CreateDate,
                                    itemDon.DanhBo,
                                    itemDon.HoTen,
                                    itemDon.DiaChi,
                                    itemDon.NoiDung,
                                };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon6));

#endregion

                #region DonTXL
                
                ///Table DonTXL 1
                var queryDonTXL = from itemDonTXL in db.DonTXLs
                                  //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                                  join itemCTKTXM in db.CTKTXMs on itemDonTXL.MaDon equals itemCTKTXM.KTXM.MaDonTXL
                                  where itemCTKTXM.DanhBo == DanhBo
                                  select new
                                  {
                                      TXL=true,
                                      itemDonTXL.MaDon,
                                      itemDonTXL.LoaiDonTXL.TenLD,
                                      itemDonTXL.CreateDate,
                                      itemDonTXL.DanhBo,
                                      itemDonTXL.HoTen,
                                      itemDonTXL.DiaChi,
                                      itemDonTXL.NoiDung,
                                  };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonTXL));

                ///Table DonTXL 2
                var queryDonTXL2 = from itemDonTXL in db.DonTXLs
                                  //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                                  join itemCTCTDB in db.CTCTDBs on itemDonTXL.MaDon equals itemCTCTDB.CHDB.MaDonTXL
                                   where itemCTCTDB.DanhBo == DanhBo
                                  select new
                                  {
                                      TXL = true,
                                      itemDonTXL.MaDon,
                                      itemDonTXL.LoaiDonTXL.TenLD,
                                      itemDonTXL.CreateDate,
                                      itemDonTXL.DanhBo,
                                      itemDonTXL.HoTen,
                                      itemDonTXL.DiaChi,
                                      itemDonTXL.NoiDung,
                                  };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonTXL2));

                ///Table DonTXL 3
                var queryDonTXL3 = from itemDonTXL in db.DonTXLs
                                   //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                                   join itemCTCHDB in db.CTCHDBs on itemDonTXL.MaDon equals itemCTCHDB.CHDB.MaDonTXL
                                   where itemCTCHDB.DanhBo == DanhBo
                                   select new
                                   {
                                       TXL = true,
                                       itemDonTXL.MaDon,
                                       itemDonTXL.LoaiDonTXL.TenLD,
                                       itemDonTXL.CreateDate,
                                       itemDonTXL.DanhBo,
                                       itemDonTXL.HoTen,
                                       itemDonTXL.DiaChi,
                                       itemDonTXL.NoiDung,
                                   };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonTXL3));

                ///Table DonTXL 4
                var queryDonTXL4 = from itemDonTXL in db.DonTXLs
                                   //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                                   join itemCTTTTL in db.CTTTTLs on itemDonTXL.MaDon equals itemCTTTTL.TTTL.MaDonTXL
                                   where itemCTTTTL.DanhBo == DanhBo
                                   select new
                                   {
                                       TXL = true,
                                       itemDonTXL.MaDon,
                                       itemDonTXL.LoaiDonTXL.TenLD,
                                       itemDonTXL.CreateDate,
                                       itemDonTXL.DanhBo,
                                       itemDonTXL.HoTen,
                                       itemDonTXL.DiaChi,
                                       itemDonTXL.NoiDung,
                                   };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonTXL4));

                #endregion

                DataTable dtDon = new DataTable();
                dtDon.Columns.Add("TXL", typeof(bool));
                dtDon.Columns.Add("MaDon", typeof(decimal));
                dtDon.Columns.Add("TenLD", typeof(string));
                dtDon.Columns.Add("CreateDate", typeof(string));
                dtDon.Columns.Add("DanhBo", typeof(string));
                dtDon.Columns.Add("HoTen", typeof(string));
                dtDon.Columns.Add("DiaChi", typeof(string));
                dtDon.Columns.Add("NoiDung", typeof(string));
                dtDon.TableName = "Don";
                foreach (DataRow itemRow in dt.Rows)
                {
                    if (dtDon.Select("MaDon = " + itemRow["MaDon"]).Count() <= 0)
                        dtDon.ImportRow(itemRow);
                }

                ds.Tables.Add(dtDon);

                if (dtDon.Rows.Count > 0 && dtKTXM.Rows.Count > 0)
                {
                    ds.Relations.Add("Chi Tiết Kiểm Tra Xác Minh", ds.Tables["Don"].Columns["MaDon"], ds.Tables["KTXM"].Columns["MaDon"]);
                    ds.Relations.Add("Chi Tiết Kiểm Tra Xác Minh TXL", ds.Tables["Don"].Columns["MaDon"], ds.Tables["KTXM"].Columns["MaDonTXL"]);
                }

                if (dtDon.Rows.Count > 0 && dtDCBD.Rows.Count > 0)  
                    ds.Relations.Add("Chi Tiết Điều Chỉnh Biến Động", ds.Tables["Don"].Columns["MaDon"], ds.Tables["DCBD"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtCHDB.Rows.Count > 0)
                {
                    ds.Relations.Add("Chi Tiết Cắt Hủy Danh Bộ", ds.Tables["Don"].Columns["MaDon"], ds.Tables["CHDB"].Columns["MaDon"]);
                    ds.Relations.Add("Chi Tiết Cắt Hủy Danh Bộ TXL", ds.Tables["Don"].Columns["MaDon"], ds.Tables["CHDB"].Columns["MaDonTXL"]);
                }

                if (dtDon.Rows.Count > 0 && dtTTTL.Rows.Count > 0)
                {
                    ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời", ds.Tables["Don"].Columns["MaDon"], ds.Tables["TTTL"].Columns["MaDon"]);
                    ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời TXL", ds.Tables["Don"].Columns["MaDon"], ds.Tables["CHDB"].Columns["MaDonTXL"]);
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
                                  where itemCTDCBD.DiaChi.Contains(DiaChi)
                                  select new
                                  {
                                      itemCTDCBD.DCBD.MaDon,
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
                                  };

                ///Bảng CTDCHD
                var queryCTDCHD = from itemCTDCHD in db.CTDCHDs
                                  where itemCTDCHD.DiaChi.Contains(DiaChi)
                                  select new
                                  {
                                      itemCTDCHD.DCBD.MaDon,
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

                ///Table DonKH 1
                var queryDon = from itemDon in db.DonKHs
                               //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                               join itemCTKTXM in db.CTKTXMs on itemDon.MaDon equals itemCTKTXM.KTXM.MaDon
                               where itemCTKTXM.DiaChi.Contains(DiaChi)
                               select new
                               {
                                   TXL = false,
                                   itemDon.MaDon,
                                   itemDon.LoaiDon.TenLD,
                                   itemDon.CreateDate,
                                   itemDon.DanhBo,
                                   itemDon.HoTen,
                                   itemDon.DiaChi,
                                   itemDon.NoiDung,
                               };
                DataTable dt = new DataTable();
                dt = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon);

                ///Table DonKH 2
                var queryDon2 = from itemDon in db.DonKHs
                                join itemCTDCBD in db.CTDCBDs on itemDon.MaDon equals itemCTDCBD.DCBD.MaDon
                                where itemCTDCBD.DiaChi.Contains(DiaChi)
                                select new
                                {
                                    TXL = false,
                                    itemDon.MaDon,
                                    itemDon.LoaiDon.TenLD,
                                    itemDon.CreateDate,
                                    itemDon.DanhBo,
                                    itemDon.HoTen,
                                    itemDon.DiaChi,
                                    itemDon.NoiDung,
                                };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon2));

                ///Table DonKH 3
                var queryDon3 = from itemDon in db.DonKHs
                                join itemCTDCHD in db.CTDCHDs on itemDon.MaDon equals itemCTDCHD.DCBD.MaDon
                                where itemCTDCHD.DiaChi.Contains(DiaChi)
                                select new
                                {
                                    TXL = false,
                                    itemDon.MaDon,
                                    itemDon.LoaiDon.TenLD,
                                    itemDon.CreateDate,
                                    itemDon.DanhBo,
                                    itemDon.HoTen,
                                    itemDon.DiaChi,
                                    itemDon.NoiDung,
                                };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon3));

                ///Table DonKH 4
                var queryDon4 = from itemDon in db.DonKHs
                                join itemCTCTDB in db.CTCTDBs on itemDon.MaDon equals itemCTCTDB.CHDB.MaDon
                                where itemCTCTDB.DiaChi.Contains(DiaChi)
                                select new
                                {
                                    TXL = false,
                                    itemDon.MaDon,
                                    itemDon.LoaiDon.TenLD,
                                    itemDon.CreateDate,
                                    itemDon.DanhBo,
                                    itemDon.HoTen,
                                    itemDon.DiaChi,
                                    itemDon.NoiDung,
                                };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon4));

                ///Table DonKH 5
                var queryDon5 = from itemDon in db.DonKHs
                                join itemCTCHDB in db.CTCHDBs on itemDon.MaDon equals itemCTCHDB.CHDB.MaDon
                                where itemCTCHDB.DiaChi.Contains(DiaChi)
                                select new
                                {
                                    TXL = false,
                                    itemDon.MaDon,
                                    itemDon.LoaiDon.TenLD,
                                    itemDon.CreateDate,
                                    itemDon.DanhBo,
                                    itemDon.HoTen,
                                    itemDon.DiaChi,
                                    itemDon.NoiDung,
                                };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon5));

                ///Table DonKH 6
                var queryDon6 = from itemDon in db.DonKHs
                                join itemCTTTTL in db.CTTTTLs on itemDon.MaDon equals itemCTTTTL.TTTL.MaDon
                                where itemCTTTTL.DiaChi.Contains(DiaChi)
                                select new
                                {
                                    TXL = false,
                                    itemDon.MaDon,
                                    itemDon.LoaiDon.TenLD,
                                    itemDon.CreateDate,
                                    itemDon.DanhBo,
                                    itemDon.HoTen,
                                    itemDon.DiaChi,
                                    itemDon.NoiDung,
                                };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDon6));

                #endregion

                #region DonTXL

                ///Table DonTXL 1
                var queryDonTXL = from itemDonTXL in db.DonTXLs
                                  //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                                  join itemCTKTXM in db.CTKTXMs on itemDonTXL.MaDon equals itemCTKTXM.KTXM.MaDonTXL
                                  where itemCTKTXM.DiaChi.Contains(DiaChi)
                                  select new
                                  {
                                      TXL = true,
                                      itemDonTXL.MaDon,
                                      itemDonTXL.LoaiDonTXL.TenLD,
                                      itemDonTXL.CreateDate,
                                      itemDonTXL.DanhBo,
                                      itemDonTXL.HoTen,
                                      itemDonTXL.DiaChi,
                                      itemDonTXL.NoiDung,
                                  };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonTXL));

                ///Table DonTXL 2
                var queryDonTXL2 = from itemDonTXL in db.DonTXLs
                                   //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                                   join itemCTCTDB in db.CTCTDBs on itemDonTXL.MaDon equals itemCTCTDB.CHDB.MaDonTXL
                                   where itemCTCTDB.DiaChi.Contains(DiaChi)
                                   select new
                                   {
                                       TXL = true,
                                       itemDonTXL.MaDon,
                                       itemDonTXL.LoaiDonTXL.TenLD,
                                       itemDonTXL.CreateDate,
                                       itemDonTXL.DanhBo,
                                       itemDonTXL.HoTen,
                                       itemDonTXL.DiaChi,
                                       itemDonTXL.NoiDung,
                                   };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonTXL2));

                ///Table DonTXL 3
                var queryDonTXL3 = from itemDonTXL in db.DonTXLs
                                   //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                                   join itemCTCHDB in db.CTCHDBs on itemDonTXL.MaDon equals itemCTCHDB.CHDB.MaDonTXL
                                   where itemCTCHDB.DiaChi.Contains(DiaChi)
                                   select new
                                   {
                                       TXL = true,
                                       itemDonTXL.MaDon,
                                       itemDonTXL.LoaiDonTXL.TenLD,
                                       itemDonTXL.CreateDate,
                                       itemDonTXL.DanhBo,
                                       itemDonTXL.HoTen,
                                       itemDonTXL.DiaChi,
                                       itemDonTXL.NoiDung,
                                   };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonTXL3));

                ///Table DonTXL 4
                var queryDonTXL4 = from itemDonTXL in db.DonTXLs
                                   //join itemKTXM in db.KTXMs on itemDon.MaDon equals itemKTXM.MaDon
                                   join itemCTTTTL in db.CTTTTLs on itemDonTXL.MaDon equals itemCTTTTL.TTTL.MaDonTXL
                                   where itemCTTTTL.DiaChi.Contains(DiaChi)
                                   select new
                                   {
                                       TXL = true,
                                       itemDonTXL.MaDon,
                                       itemDonTXL.LoaiDonTXL.TenLD,
                                       itemDonTXL.CreateDate,
                                       itemDonTXL.DanhBo,
                                       itemDonTXL.HoTen,
                                       itemDonTXL.DiaChi,
                                       itemDonTXL.NoiDung,
                                   };
                dt.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonTXL4));

                #endregion

                DataTable dtDon = new DataTable();
                dtDon.Columns.Add("TXL", typeof(bool));
                dtDon.Columns.Add("MaDon", typeof(decimal));
                dtDon.Columns.Add("TenLD", typeof(string));
                dtDon.Columns.Add("CreateDate", typeof(string));
                dtDon.Columns.Add("DanhBo", typeof(string));
                dtDon.Columns.Add("HoTen", typeof(string));
                dtDon.Columns.Add("DiaChi", typeof(string));
                dtDon.Columns.Add("NoiDung", typeof(string));
                dtDon.TableName = "Don";
                foreach (DataRow itemRow in dt.Rows)
                {
                    if (dtDon.Select("MaDon = " + itemRow["MaDon"]).Count() <= 0)
                        dtDon.ImportRow(itemRow);
                }

                ds.Tables.Add(dtDon);

                if (dtDon.Rows.Count > 0 && dtKTXM.Rows.Count > 0)
                {
                    ds.Relations.Add("Chi Tiết Kiểm Tra Xác Minh", ds.Tables["Don"].Columns["MaDon"], ds.Tables["KTXM"].Columns["MaDon"]);
                    ds.Relations.Add("Chi Tiết Kiểm Tra Xác Minh TXL", ds.Tables["Don"].Columns["MaDon"], ds.Tables["KTXM"].Columns["MaDonTXL"]);
                }

                if (dtDon.Rows.Count > 0 && dtDCBD.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Điều Chỉnh Biến Động", ds.Tables["Don"].Columns["MaDon"], ds.Tables["DCBD"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtCHDB.Rows.Count > 0)
                {
                    ds.Relations.Add("Chi Tiết Cắt Hủy Danh Bộ", ds.Tables["Don"].Columns["MaDon"], ds.Tables["CHDB"].Columns["MaDon"]);
                    ds.Relations.Add("Chi Tiết Cắt Hủy Danh Bộ TXL", ds.Tables["Don"].Columns["MaDon"], ds.Tables["CHDB"].Columns["MaDonTXL"]);
                }

                if (dtDon.Rows.Count > 0 && dtTTTL.Rows.Count > 0)
                {
                    ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời", ds.Tables["Don"].Columns["MaDon"], ds.Tables["TTTL"].Columns["MaDon"]);
                    ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời TXL", ds.Tables["Don"].Columns["MaDon"], ds.Tables["CHDB"].Columns["MaDonTXL"]);
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
