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
        public DataSet GetTienTrinh_DonTu(int MaDon)
        {
            try
            {
                DataSet ds = new DataSet();
                ///Table DonKH
                var queryDon = from itemDon in db.DonTu_ChiTiets
                               where itemDon.MaDon == MaDon
                               select new
                               {
                                   MaDon = "TKH" + itemDon.MaDon,
                                   //itemDon.LoaiDon.TenLD,
                                   itemDon.CreateDate,
                                   itemDon.DanhBo,
                                   itemDon.HoTen,
                                   itemDon.DiaChi,
                                   itemDon.GiaBieu,
                                   itemDon.DinhMuc,
                                   NoiDung=itemDon.DonTu.Name_NhomDon,
                               };
                DataTable dtDon = new DataTable();
                dtDon = LINQToDataTable(queryDon);
                dtDon.TableName = "Don";
                ds.Tables.Add(dtDon);

                ///Table CTKTXM
                var queryKTXM = from itemCTKTXM in db.KTXM_ChiTiets
                                join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                where itemCTKTXM.KTXM.MaDonMoi == MaDon
                                select new
                                {
                                    MaDon = itemCTKTXM.KTXM.MaDonMoi,
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
                                  where itemCTBamChi.BamChi.MaDonMoi == MaDon
                                  select new
                                  {
                                      MaDon = itemCTBamChi.BamChi.MaDonMoi,
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
                                    where itemCTDongNuoc.DongNuoc.MaDonMoi == MaDon
                                    select new
                                    {
                                        MaDon = itemCTDongNuoc.DongNuoc.MaDonMoi,
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
                                  where itemCTDCBD.DCBD.MaDonMoi == MaDon
                                  select new
                                  {
                                      MaDon = itemCTDCBD.DCBD.MaDonMoi,
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
                                  where itemCTDCHD.DCBD.MaDonMoi == MaDon
                                  select new
                                  {
                                      MaDon = itemCTDCHD.DCBD.MaDonMoi,
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
                                  where itemCTCTDB.CHDB.MaDonMoi == MaDon
                                  select new
                                  {
                                      MaDon = itemCTCTDB.CHDB.MaDonMoi,
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
                ///Table CHDB_ChiTietCatHuy
                var queryCTCHDB = from itemCTCHDB in db.CHDB_ChiTietCatHuys
                                  where itemCTCHDB.CHDB.MaDonMoi == MaDon
                                  select new
                                  {
                                      MaDon = itemCTCHDB.CHDB.MaDonMoi,
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
                                  where itemYCCHDB.CHDB.MaDonMoi == MaDon
                                  select new
                                  {
                                      MaDon = itemYCCHDB.CHDB.MaDonMoi,
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
                var queryTTTL = from itemCTTTTL in db.TTTL_ChiTiets
                                where itemCTTTTL.TTTL.MaDonMoi == MaDon
                                select new
                                {
                                    MaDon = itemCTTTTL.TTTL.MaDonMoi,
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
                var queryGianLan = from itemGL in db.GianLan_ChiTiets
                                   where itemGL.GianLan.MaDonMoi == MaDon
                                   select new
                                   {
                                       MaDon = itemGL.GianLan.MaDonMoi,
                                       ID = itemGL.MaCTGL,
                                       itemGL.DanhBo,
                                       itemGL.HoTen,
                                       itemGL.DiaChi,
                                       itemGL.CreateDate,
                                       itemGL.NoiDungViPham,
                                       itemGL.TinhTrang,
                                       itemGL.ThanhToan1,
                                       itemGL.ThanhToan2,
                                       itemGL.ThanhToan3,
                                       itemGL.XepDon,
                                   };
                DataTable dtGianLan = new DataTable();
                dtGianLan = LINQToDataTable(queryGianLan);
                dtGianLan.TableName = "GianLan";
                ds.Tables.Add(dtGianLan);

                ///Table TruyThu
                var queryTruyThu = from itemTT in db.TruyThuTienNuoc_ChiTiets
                                   where itemTT.TruyThuTienNuoc.MaDonMoi == MaDon
                                   select new
                                   {
                                       MaDon = itemTT.TruyThuTienNuoc.MaDonMoi,
                                       itemTT.IDCT,
                                       itemTT.DanhBo,
                                       itemTT.HoTen,
                                       itemTT.DiaChi,
                                       itemTT.CreateDate,
                                       itemTT.NoiDung,
                                       itemTT.TongTien,
                                       itemTT.Tongm3BinhQuan,
                                       itemTT.TinhTrang,
                                   };
                DataTable dtTruyThu = new DataTable();
                dtTruyThu = LINQToDataTable(queryTruyThu);
                dtTruyThu.TableName = "TruyThu";
                ds.Tables.Add(dtTruyThu);

                ///Table ToTrinh
                var queryToTrinh = from itemCTTT in db.ToTrinh_ChiTiets
                                   where itemCTTT.ToTrinh.MaDonMoi == MaDon
                                   select new
                                   {
                                       MaDon = itemCTTT.ToTrinh.MaDonMoi,
                                       itemCTTT.IDCT,
                                       itemCTTT.DanhBo,
                                       itemCTTT.HoTen,
                                       itemCTTT.DiaChi,
                                       itemCTTT.CreateDate,
                                       itemCTTT.VeViec,
                                       itemCTTT.NoiDung,
                                   };
                DataTable dtToTrinh = new DataTable();
                dtToTrinh = LINQToDataTable(queryToTrinh);
                dtToTrinh.TableName = "ToTrinh";
                ds.Tables.Add(dtToTrinh);

                ///Table ThuMoi
                var queryThuMoi = from item in db.ThuMoi_ChiTiets
                                  where item.ThuMoi.MaDonMoi == MaDon
                                  select new
                                  {
                                      MaDon = item.ThuMoi.MaDonMoi,
                                      item.IDCT,
                                      item.SoPhieu,
                                      item.Lan,
                                      item.DanhBo,
                                      item.HoTen,
                                      item.DiaChi,
                                      item.CreateDate,
                                      item.VeViec,
                                  };
                DataTable dtThuMoi = new DataTable();
                dtThuMoi = LINQToDataTable(queryThuMoi);
                dtThuMoi.TableName = "ThuMoi";
                ds.Tables.Add(dtThuMoi);

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

                if (dtDon.Rows.Count > 0 && dtTruyThu.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Truy Thu", ds.Tables["Don"].Columns["MaDon"], ds.Tables["TruyThu"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtToTrinh.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Tờ Trình", ds.Tables["Don"].Columns["MaDon"], ds.Tables["ToTrinh"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtThuMoi.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Thư Mời", ds.Tables["Don"].Columns["MaDon"], ds.Tables["ThuMoi"].Columns["MaDon"]);

                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataSet GetTienTrinh_DonTKH(decimal MaDon)
        {
            try
            {
                DataSet ds = new DataSet();
                ///Table DonKH
                var queryDon = from itemDon in db.DonKHs
                               where itemDon.MaDon == MaDon
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
                DataTable dtDon = new DataTable();
                dtDon = LINQToDataTable(queryDon);
                dtDon.TableName = "Don";
                ds.Tables.Add(dtDon);

                ///Table CTKTXM
                var queryKTXM = from itemCTKTXM in db.KTXM_ChiTiets
                                join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                where itemCTKTXM.KTXM.MaDon == MaDon
                                select new
                                {
                                    MaDon = "TKH" + itemCTKTXM.KTXM.MaDon,
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
                                  where itemCTBamChi.BamChi.MaDon == MaDon
                                  select new
                                  {
                                      MaDon = "TKH" + itemCTBamChi.BamChi.MaDon,
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
                                    where itemCTDongNuoc.DongNuoc.MaDon == MaDon
                                    select new
                                    {
                                        MaDon = "TKH" + itemCTDongNuoc.DongNuoc.MaDon,
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
                                  where itemCTDCBD.DCBD.MaDon == MaDon
                                  select new
                                  {
                                      MaDon = "TKH" + itemCTDCBD.DCBD.MaDon,
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
                                  where itemCTDCHD.DCBD.MaDon == MaDon
                                  select new
                                  {
                                      MaDon = "TKH" + itemCTDCHD.DCBD.MaDon,
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
                                  where itemCTCTDB.CHDB.MaDon == MaDon
                                  select new
                                  {
                                      MaDon = "TKH" + itemCTCTDB.CHDB.MaDon,
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
                ///Table CHDB_ChiTietCatHuy
                var queryCTCHDB = from itemCTCHDB in db.CHDB_ChiTietCatHuys
                                  where itemCTCHDB.CHDB.MaDon == MaDon
                                  select new
                                  {
                                      MaDon = "TKH" + itemCTCHDB.CHDB.MaDon,
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
                                  where itemYCCHDB.CHDB.MaDon == MaDon
                                  select new
                                  {
                                      MaDon = "TKH" + itemYCCHDB.CHDB.MaDon,
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
                var queryTTTL = from itemCTTTTL in db.TTTL_ChiTiets
                                where itemCTTTTL.TTTL.MaDon == MaDon
                                select new
                                {
                                    MaDon = "TKH" + itemCTTTTL.TTTL.MaDon,
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
                var queryGianLan = from itemGL in db.GianLan_ChiTiets
                                   where itemGL.GianLan.MaDon == MaDon
                                   select new
                                   {
                                       MaDon = "TKH" + itemGL.GianLan.MaDon,
                                       ID = itemGL.MaCTGL,
                                       itemGL.DanhBo,
                                       itemGL.HoTen,
                                       itemGL.DiaChi,
                                       itemGL.CreateDate,
                                       itemGL.NoiDungViPham,
                                       itemGL.TinhTrang,
                                       itemGL.ThanhToan1,
                                       itemGL.ThanhToan2,
                                       itemGL.ThanhToan3,
                                       itemGL.XepDon,
                                   };
                DataTable dtGianLan = new DataTable();
                dtGianLan = LINQToDataTable(queryGianLan);
                dtGianLan.TableName = "GianLan";
                ds.Tables.Add(dtGianLan);

                ///Table TruyThu
                var queryTruyThu = from itemTT in db.TruyThuTienNuoc_ChiTiets
                                   where itemTT.TruyThuTienNuoc.MaDon == MaDon
                                   select new
                                   {
                                       MaDon = "TKH" + itemTT.TruyThuTienNuoc.MaDon,
                                       itemTT.IDCT,
                                       itemTT.DanhBo,
                                       itemTT.HoTen,
                                       itemTT.DiaChi,
                                       itemTT.CreateDate,
                                       itemTT.NoiDung,
                                       itemTT.TongTien,
                                       itemTT.Tongm3BinhQuan,
                                       itemTT.TinhTrang,
                                   };
                DataTable dtTruyThu = new DataTable();
                dtTruyThu = LINQToDataTable(queryTruyThu);
                dtTruyThu.TableName = "TruyThu";
                ds.Tables.Add(dtTruyThu);

                ///Table ToTrinh
                var queryToTrinh = from itemCTTT in db.ToTrinh_ChiTiets
                                   where itemCTTT.ToTrinh.MaDon == MaDon
                                   select new
                                   {
                                       MaDon = "TKH" + itemCTTT.ToTrinh.MaDon,
                                       itemCTTT.IDCT,
                                       itemCTTT.DanhBo,
                                       itemCTTT.HoTen,
                                       itemCTTT.DiaChi,
                                       itemCTTT.CreateDate,
                                       itemCTTT.VeViec,
                                       itemCTTT.NoiDung,
                                   };
                DataTable dtToTrinh = new DataTable();
                dtToTrinh = LINQToDataTable(queryToTrinh);
                dtToTrinh.TableName = "ToTrinh";
                ds.Tables.Add(dtToTrinh);

                ///Table ThuMoi
                var queryThuMoi = from item in db.ThuMoi_ChiTiets
                                  where item.ThuMoi.MaDonTKH == MaDon
                                  select new
                                  {
                                      MaDon = "TKH" + item.ThuMoi.MaDonTKH,
                                      item.IDCT,
                                      item.SoPhieu,
                                      item.Lan,
                                      item.DanhBo,
                                      item.HoTen,
                                      item.DiaChi,
                                      item.CreateDate,
                                      item.VeViec,
                                  };
                DataTable dtThuMoi = new DataTable();
                dtThuMoi = LINQToDataTable(queryThuMoi);
                dtThuMoi.TableName = "ThuMoi";
                ds.Tables.Add(dtThuMoi);

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

                if (dtDon.Rows.Count > 0 && dtTruyThu.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Truy Thu", ds.Tables["Don"].Columns["MaDon"], ds.Tables["TruyThu"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtToTrinh.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Tờ Trình", ds.Tables["Don"].Columns["MaDon"], ds.Tables["ToTrinh"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtThuMoi.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Thư Mời", ds.Tables["Don"].Columns["MaDon"], ds.Tables["ThuMoi"].Columns["MaDon"]);

                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataSet GetTienTrinh_DonTXL(decimal MaDonTXL)
        {
            try
            {
                DataSet ds = new DataSet();
                ///Table DonTXL
                var queryDon = from itemDonTXL in db.DonTXLs
                               where itemDonTXL.MaDon == MaDonTXL
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
                DataTable dtDon = new DataTable();
                dtDon = LINQToDataTable(queryDon);
                dtDon.TableName = "Don";
                ds.Tables.Add(dtDon);

                ///Table CTKTXM
                var queryKTXM = from itemCTKTXM in db.KTXM_ChiTiets
                                join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                where itemCTKTXM.KTXM.MaDonTXL == MaDonTXL
                                select new
                                {
                                    MaDon = "TXL" + itemCTKTXM.KTXM.MaDonTXL,
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
                                  where itemCTBamChi.BamChi.MaDonTXL == MaDonTXL
                                  select new
                                  {
                                      MaDon = "TXL" + itemCTBamChi.BamChi.MaDonTXL,
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
                                    where itemCTDongNuoc.DongNuoc.MaDonTXL == MaDonTXL
                                    select new
                                    {
                                        MaDon = "TXL" + itemCTDongNuoc.DongNuoc.MaDonTXL,
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
                                  where itemCTDCBD.DCBD.MaDonTXL == MaDonTXL
                                  select new
                                  {
                                      MaDon = "TXL" + itemCTDCBD.DCBD.MaDonTXL,
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
                                  where itemCTDCHD.DCBD.MaDonTXL == MaDonTXL
                                  select new
                                  {
                                      MaDon = "TXL" + itemCTDCHD.DCBD.MaDonTXL,
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
                                  where itemCTCTDB.CHDB.MaDonTXL == MaDonTXL
                                  select new
                                  {
                                      MaDon = "TXL" + itemCTCTDB.CHDB.MaDonTXL,
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
                ///Table CHDB_ChiTietCatHuy
                var queryCTCHDB = from itemCTCHDB in db.CHDB_ChiTietCatHuys
                                  where itemCTCHDB.CHDB.MaDonTXL == MaDonTXL
                                  select new
                                  {
                                      MaDon = "TXL" + itemCTCHDB.CHDB.MaDonTXL,
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
                                  where itemYCCHDB.CHDB.MaDonTXL == MaDonTXL
                                  select new
                                  {
                                      MaDon = "TXL" + itemYCCHDB.CHDB.MaDonTXL,
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
                var queryTTTL = from itemCTTTTL in db.TTTL_ChiTiets
                                where itemCTTTTL.TTTL.MaDonTXL == MaDonTXL
                                select new
                                {
                                    MaDon = "TXL" + itemCTTTTL.TTTL.MaDonTXL,
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
                var queryGianLan = from itemGL in db.GianLan_ChiTiets
                                   where itemGL.GianLan.MaDonTXL == MaDonTXL
                                   select new
                                   {
                                       MaDon = "TXL" + itemGL.GianLan.MaDonTXL,
                                       ID = itemGL.MaCTGL,
                                       itemGL.DanhBo,
                                       itemGL.HoTen,
                                       itemGL.DiaChi,
                                       itemGL.CreateDate,
                                       itemGL.NoiDungViPham,
                                       itemGL.TinhTrang,
                                       itemGL.ThanhToan1,
                                       itemGL.ThanhToan2,
                                       itemGL.ThanhToan3,
                                       itemGL.XepDon,
                                   };
                DataTable dtGianLan = new DataTable();
                dtGianLan = LINQToDataTable(queryGianLan);
                dtGianLan.TableName = "GianLan";
                ds.Tables.Add(dtGianLan);

                ///Table TruyThu
                var queryTruyThu = from itemTT in db.TruyThuTienNuoc_ChiTiets
                                   where itemTT.TruyThuTienNuoc.MaDonTXL == MaDonTXL
                                   select new
                                   {
                                       MaDon = "TXL" + itemTT.TruyThuTienNuoc.MaDonTXL,
                                       itemTT.IDCT,
                                       itemTT.DanhBo,
                                       itemTT.HoTen,
                                       itemTT.DiaChi,
                                       itemTT.CreateDate,
                                       itemTT.NoiDung,
                                       itemTT.TongTien,
                                       itemTT.Tongm3BinhQuan,
                                       itemTT.TinhTrang,
                                   };
                DataTable dtTruyThu = new DataTable();
                dtTruyThu = LINQToDataTable(queryTruyThu);
                dtTruyThu.TableName = "TruyThu";
                ds.Tables.Add(dtTruyThu);

                ///Table ToTrinh
                var queryToTrinh = from itemCTTT in db.ToTrinh_ChiTiets
                                   where itemCTTT.ToTrinh.MaDonTXL == MaDonTXL
                                   select new
                                   {
                                       MaDon = "TXL" + itemCTTT.ToTrinh.MaDonTXL,
                                       itemCTTT.IDCT,
                                       itemCTTT.DanhBo,
                                       itemCTTT.HoTen,
                                       itemCTTT.DiaChi,
                                       itemCTTT.CreateDate,
                                       itemCTTT.VeViec,
                                       itemCTTT.NoiDung,
                                   };
                DataTable dtToTrinh = new DataTable();
                dtToTrinh = LINQToDataTable(queryToTrinh);
                dtToTrinh.TableName = "ToTrinh";
                ds.Tables.Add(dtToTrinh);

                ///Table ThuMoi
                var queryThuMoi = from item in db.ThuMoi_ChiTiets
                                  where item.ThuMoi.MaDonTXL == MaDonTXL
                                  select new
                                  {
                                      MaDon = "TXL" + item.ThuMoi.MaDonTXL,
                                      item.IDCT,
                                      item.SoPhieu,
                                      item.Lan,
                                      item.DanhBo,
                                      item.HoTen,
                                      item.DiaChi,
                                      item.CreateDate,
                                      item.VeViec,
                                  };
                DataTable dtThuMoi = new DataTable();
                dtThuMoi = LINQToDataTable(queryThuMoi);
                dtThuMoi.TableName = "ThuMoi";
                ds.Tables.Add(dtThuMoi);

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

                if (dtDon.Rows.Count > 0 && dtTruyThu.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Truy Thu", ds.Tables["Don"].Columns["MaDon"], ds.Tables["TruyThu"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtToTrinh.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Tờ Trình", ds.Tables["Don"].Columns["MaDon"], ds.Tables["ToTrinh"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtThuMoi.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Thư Mời", ds.Tables["Don"].Columns["MaDon"], ds.Tables["ThuMoi"].Columns["MaDon"]);

                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataSet GetTienTrinh_DonTBC(decimal MaDonTBC)
        {
            try
            {
                DataSet ds = new DataSet();
                ///Table DonKH
                var queryDon = from itemDon in db.DonTBCs
                               where itemDon.MaDon == MaDonTBC
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
                DataTable dtDon = new DataTable();
                dtDon = LINQToDataTable(queryDon);
                dtDon.TableName = "Don";
                ds.Tables.Add(dtDon);

                ///Table CTKTXM
                var queryKTXM = from itemCTKTXM in db.KTXM_ChiTiets
                                join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                where itemCTKTXM.KTXM.MaDonTBC == MaDonTBC
                                select new
                                {
                                    MaDon = "TBC" + itemCTKTXM.KTXM.MaDonTBC,
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
                                  where itemCTBamChi.BamChi.MaDonTBC == MaDonTBC
                                  select new
                                  {
                                      MaDon = "TBC" + itemCTBamChi.BamChi.MaDonTBC,
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
                                    where itemCTDongNuoc.DongNuoc.MaDonTBC == MaDonTBC
                                    select new
                                    {
                                        MaDon = "TBC" + itemCTDongNuoc.DongNuoc.MaDonTBC,
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
                                  where itemCTDCBD.DCBD.MaDonTBC == MaDonTBC
                                  select new
                                  {
                                      MaDon = "TBC" + itemCTDCBD.DCBD.MaDonTBC,
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
                                  where itemCTDCHD.DCBD.MaDonTBC == MaDonTBC
                                  select new
                                  {
                                      MaDon = "TBC" + itemCTDCHD.DCBD.MaDonTBC,
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
                                  where itemCTCTDB.CHDB.MaDonTBC == MaDonTBC
                                  select new
                                  {
                                      MaDon = "TBC" + itemCTCTDB.CHDB.MaDonTBC,
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
                ///Table CHDB_ChiTietCatHuy
                var queryCTCHDB = from itemCTCHDB in db.CHDB_ChiTietCatHuys
                                  where itemCTCHDB.CHDB.MaDonTBC == MaDonTBC
                                  select new
                                  {
                                      MaDon = "TBC" + itemCTCHDB.CHDB.MaDonTBC,
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
                                  where itemYCCHDB.CHDB.MaDonTBC == MaDonTBC
                                  select new
                                  {
                                      MaDon = "TBC" + itemYCCHDB.CHDB.MaDonTBC,
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
                var queryTTTL = from itemCTTTTL in db.TTTL_ChiTiets
                                where itemCTTTTL.TTTL.MaDonTBC == MaDonTBC
                                select new
                                {
                                    MaDon = "TBC" + itemCTTTTL.TTTL.MaDonTBC,
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
                var queryGianLan = from itemGL in db.GianLan_ChiTiets
                                   where itemGL.GianLan.MaDonTBC == MaDonTBC
                                   select new
                                   {
                                       MaDon = "TBC" + itemGL.GianLan.MaDonTBC,
                                       ID = itemGL.MaCTGL,
                                       itemGL.DanhBo,
                                       itemGL.HoTen,
                                       itemGL.DiaChi,
                                       itemGL.CreateDate,
                                       itemGL.NoiDungViPham,
                                       itemGL.TinhTrang,
                                       itemGL.ThanhToan1,
                                       itemGL.ThanhToan2,
                                       itemGL.ThanhToan3,
                                       itemGL.XepDon,
                                   };
                DataTable dtGianLan = new DataTable();
                dtGianLan = LINQToDataTable(queryGianLan);
                dtGianLan.TableName = "GianLan";
                ds.Tables.Add(dtGianLan);

                ///Table TruyThu
                var queryTruyThu = from itemTT in db.TruyThuTienNuoc_ChiTiets
                                   where itemTT.TruyThuTienNuoc.MaDonTBC == MaDonTBC
                                   select new
                                   {
                                       MaDon = "TBC" + itemTT.TruyThuTienNuoc.MaDonTBC,
                                       itemTT.IDCT,
                                       itemTT.DanhBo,
                                       itemTT.HoTen,
                                       itemTT.DiaChi,
                                       itemTT.CreateDate,
                                       itemTT.NoiDung,
                                       itemTT.TongTien,
                                       itemTT.Tongm3BinhQuan,
                                       itemTT.TinhTrang,
                                   };
                DataTable dtTruyThu = new DataTable();
                dtTruyThu = LINQToDataTable(queryTruyThu);
                dtTruyThu.TableName = "TruyThu";
                ds.Tables.Add(dtTruyThu);

                ///Table ToTrinh
                var queryToTrinh = from itemCTTT in db.ToTrinh_ChiTiets
                                   where itemCTTT.ToTrinh.MaDonTBC == MaDonTBC
                                   select new
                                   {
                                       MaDon = "TBC" + itemCTTT.ToTrinh.MaDonTBC,
                                       itemCTTT.IDCT,
                                       itemCTTT.DanhBo,
                                       itemCTTT.HoTen,
                                       itemCTTT.DiaChi,
                                       itemCTTT.CreateDate,
                                       itemCTTT.VeViec,
                                       itemCTTT.NoiDung,
                                   };
                DataTable dtToTrinh = new DataTable();
                dtToTrinh = LINQToDataTable(queryToTrinh);
                dtToTrinh.TableName = "ToTrinh";
                ds.Tables.Add(dtToTrinh);

                ///Table ThuMoi
                var queryThuMoi = from item in db.ThuMoi_ChiTiets
                                  where item.ThuMoi.MaDonTBC == MaDonTBC
                                  select new
                                  {
                                      MaDon = "TBC" + item.ThuMoi.MaDonTBC,
                                      item.IDCT,
                                      item.SoPhieu,
                                      item.Lan,
                                      item.DanhBo,
                                      item.HoTen,
                                      item.DiaChi,
                                      item.CreateDate,
                                      item.VeViec,
                                  };
                DataTable dtThuMoi = new DataTable();
                dtThuMoi = LINQToDataTable(queryThuMoi);
                dtThuMoi.TableName = "ThuMoi";
                ds.Tables.Add(dtThuMoi);

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

                if (dtDon.Rows.Count > 0 && dtTruyThu.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Truy Thu", ds.Tables["Don"].Columns["MaDon"], ds.Tables["TruyThu"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtToTrinh.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Tờ Trình", ds.Tables["Don"].Columns["MaDon"], ds.Tables["ToTrinh"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtThuMoi.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Thư Mời", ds.Tables["Don"].Columns["MaDon"], ds.Tables["ThuMoi"].Columns["MaDon"]);

                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //Vì lý do tìm theo Danh Bộ, Họ Tên, Địa Chỉ phải tìm Con trước, Cha sau nên tìm đơn sau cùng

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
                                    MaDon = itemCTKTXM.KTXM.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTKTXM.KTXM.MaDonMoi).Count() == 1 ? "" + itemCTKTXM.KTXM.MaDonMoi : itemCTKTXM.KTXM.MaDonMoi + "." + itemCTKTXM.STT
                                    : itemCTKTXM.KTXM.MaDon != null ? "TKH" + itemCTKTXM.KTXM.MaDon
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
                                      MaDon = itemCTBamChi.BamChi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTBamChi.BamChi.MaDonMoi).Count() == 1 ? "" + itemCTBamChi.BamChi.MaDonMoi : itemCTBamChi.BamChi.MaDonMoi + "." + itemCTBamChi.STT
                                      : itemCTBamChi.BamChi.MaDon != null ? "TKH" + itemCTBamChi.BamChi.MaDon
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
                                        MaDon = itemCTDongNuoc.DongNuoc.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTDongNuoc.DongNuoc.MaDonMoi).Count() == 1 ? "" + itemCTDongNuoc.DongNuoc.MaDonMoi : itemCTDongNuoc.DongNuoc.MaDonMoi + "." + itemCTDongNuoc.STT
                                        : itemCTDongNuoc.DongNuoc.MaDon != null ? "TKH" + itemCTDongNuoc.DongNuoc.MaDon
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
                                      MaDon = itemCTDCBD.DCBD.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTDCBD.DCBD.MaDonMoi).Count() == 1 ? "" + itemCTDCBD.DCBD.MaDonMoi : itemCTDCBD.DCBD.MaDonMoi + "." + itemCTDCBD.STT
                                      : itemCTDCBD.DCBD.MaDon != null ? "TKH" + itemCTDCBD.DCBD.MaDon
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
                                      MaDon = itemCTDCHD.DCBD.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTDCHD.DCBD.MaDonMoi).Count() == 1 ? "" + itemCTDCHD.DCBD.MaDonMoi : itemCTDCHD.DCBD.MaDonMoi + "." + itemCTDCHD.STT
                                      : itemCTDCHD.DCBD.MaDon != null ? "TKH" + itemCTDCHD.DCBD.MaDon
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
                                      MaDon = itemCTCTDB.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTCTDB.CHDB.MaDonMoi).Count() == 1 ? "" + itemCTCTDB.CHDB.MaDonMoi : itemCTCTDB.CHDB.MaDonMoi + "." + itemCTCTDB.STT
                                      : itemCTCTDB.CHDB.MaDon != null ? "TKH" + itemCTCTDB.CHDB.MaDon
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

                ///Table CHDB_ChiTietCatHuy
                var queryCTCHDB = from itemCTCHDB in db.CHDB_ChiTietCatHuys
                                  where itemCTCHDB.DanhBo == DanhBo || (itemCTCHDB.CHDB.DonKH.DanhBo == DanhBo || itemCTCHDB.CHDB.DonTXL.DanhBo == DanhBo || itemCTCHDB.CHDB.DonTBC.DanhBo == DanhBo)
                                  select new
                                  {
                                      MaDon = itemCTCHDB.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTCHDB.CHDB.MaDonMoi).Count() == 1 ? "" + itemCTCHDB.CHDB.MaDonMoi : itemCTCHDB.CHDB.MaDonMoi + "." + itemCTCHDB.STT
                                      : itemCTCHDB.CHDB.MaDon != null ? "TKH" + itemCTCHDB.CHDB.MaDon
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
                                      MaDon = itemYCCHDB.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemYCCHDB.CHDB.MaDonMoi).Count() == 1 ? "" + itemYCCHDB.CHDB.MaDonMoi : itemYCCHDB.CHDB.MaDonMoi + "." + itemYCCHDB.STT
                                      : itemYCCHDB.CHDB.MaDon != null ? "TKH" + itemYCCHDB.CHDB.MaDonTXL
                                    : itemYCCHDB.CHDB.MaDonTXL != null ? "TXL" + itemYCCHDB.CHDB.MaDonTXL
                                    : itemYCCHDB.CHDB.MaDonTBC != null ? "TBC" + itemYCCHDB.CHDB.MaDonTBC : null,
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
                var queryTTTL = from itemCTTTTL in db.TTTL_ChiTiets
                                where itemCTTTTL.DanhBo == DanhBo || (itemCTTTTL.TTTL.DonKH.DanhBo == DanhBo || itemCTTTTL.TTTL.DonTXL.DanhBo == DanhBo || itemCTTTTL.TTTL.DonTBC.DanhBo == DanhBo)
                                select new
                                {
                                    MaDon = itemCTTTTL.TTTL.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTTTTL.TTTL.MaDonMoi).Count() == 1 ? "" + itemCTTTTL.TTTL.MaDonMoi : itemCTTTTL.TTTL.MaDonMoi + "." + itemCTTTTL.STT
                                      : itemCTTTTL.TTTL.MaDon != null ? "TKH" + itemCTTTTL.TTTL.MaDon
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
                var queryGianLan = from itemGL in db.GianLan_ChiTiets
                                   where itemGL.DanhBo == DanhBo || (itemGL.GianLan.DonKH.DanhBo == DanhBo || itemGL.GianLan.DonTXL.DanhBo == DanhBo || itemGL.GianLan.DonTBC.DanhBo == DanhBo)
                                   select new
                                   {
                                       MaDon = itemGL.GianLan.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemGL.GianLan.MaDonMoi).Count() == 1 ? "" + itemGL.GianLan.MaDonMoi : itemGL.GianLan.MaDonMoi + "." + itemGL.STT
                                      : itemGL.GianLan.MaDon != null ? "TKH" + itemGL.GianLan.MaDon
                                       : itemGL.GianLan.MaDonTXL != null ? "TXL" + itemGL.GianLan.MaDonTXL
                                       : itemGL.GianLan.MaDonTBC != null ? "TBC" + itemGL.GianLan.MaDonTBC : null,
                                       ID = itemGL.MaCTGL,
                                       itemGL.CreateDate,
                                       itemGL.DanhBo,
                                       itemGL.HoTen,
                                       itemGL.DiaChi,
                                       itemGL.NoiDungViPham,
                                       itemGL.TinhTrang,
                                       itemGL.ThanhToan1,
                                       itemGL.ThanhToan2,
                                       itemGL.ThanhToan3,
                                       itemGL.XepDon,
                                   };
                DataTable dtGianLan = new DataTable();
                dtGianLan = LINQToDataTable(queryGianLan);
                dtGianLan.TableName = "GianLan";
                ds.Tables.Add(dtGianLan);

                ///Table TruyThu
                var queryTruyThu = from itemTT in db.TruyThuTienNuoc_ChiTiets
                                   where itemTT.DanhBo == DanhBo || (itemTT.TruyThuTienNuoc.DonKH.DanhBo == DanhBo || itemTT.TruyThuTienNuoc.DonTXL.DanhBo == DanhBo || itemTT.TruyThuTienNuoc.DonTBC.DanhBo == DanhBo)
                                   select new
                                   {
                                       MaDon = itemTT.TruyThuTienNuoc.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemTT.TruyThuTienNuoc.MaDonMoi).Count() == 1 ? "" + itemTT.TruyThuTienNuoc.MaDonMoi : itemTT.TruyThuTienNuoc.MaDonMoi + "." + itemTT.STT
                                      : itemTT.TruyThuTienNuoc.MaDon != null ? "TKH" + itemTT.TruyThuTienNuoc.MaDon
                                       : itemTT.TruyThuTienNuoc.MaDonTXL != null ? "TXL" + itemTT.TruyThuTienNuoc.MaDonTXL
                                       : itemTT.TruyThuTienNuoc.MaDonTBC != null ? "TBC" + itemTT.TruyThuTienNuoc.MaDonTBC : null,
                                       itemTT.IDCT,
                                       itemTT.DanhBo,
                                       itemTT.HoTen,
                                       itemTT.DiaChi,
                                       itemTT.CreateDate,
                                       itemTT.NoiDung,
                                       itemTT.TongTien,
                                       itemTT.Tongm3BinhQuan,
                                       itemTT.TinhTrang,
                                   };
                DataTable dtTruyThu = new DataTable();
                dtTruyThu = LINQToDataTable(queryTruyThu);
                dtTruyThu.TableName = "TruyThu";
                ds.Tables.Add(dtTruyThu);

                ///Table ToTrinh
                var queryToTrinh = from itemCTTT in db.ToTrinh_ChiTiets
                                   where itemCTTT.DanhBo == DanhBo || (itemCTTT.ToTrinh.DonKH.DanhBo == DanhBo || itemCTTT.ToTrinh.DonTXL.DanhBo == DanhBo || itemCTTT.ToTrinh.DonTBC.DanhBo == DanhBo)
                                   select new
                                   {
                                       MaDon = itemCTTT.ToTrinh.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTTT.ToTrinh.MaDonMoi).Count() == 1 ? "" + itemCTTT.ToTrinh.MaDonMoi : itemCTTT.ToTrinh.MaDonMoi + "." + itemCTTT.STT
                                      : itemCTTT.ToTrinh.MaDon != null ? "TKH" + itemCTTT.ToTrinh.MaDon
                                       : itemCTTT.ToTrinh.MaDonTXL != null ? "TXL" + itemCTTT.ToTrinh.MaDonTXL
                                       : itemCTTT.ToTrinh.MaDonTBC != null ? "TBC" + itemCTTT.ToTrinh.MaDonTBC : null,
                                       itemCTTT.IDCT,
                                       itemCTTT.DanhBo,
                                       itemCTTT.HoTen,
                                       itemCTTT.DiaChi,
                                       itemCTTT.CreateDate,
                                       itemCTTT.NoiDung,
                                       itemCTTT.VeViec,
                                   };
                DataTable dtToTrinh = new DataTable();
                dtToTrinh = LINQToDataTable(queryToTrinh);
                dtToTrinh.TableName = "ToTrinh";
                ds.Tables.Add(dtToTrinh);

                ///Table ThuMoi
                var queryThuMoi = from item in db.ThuMoi_ChiTiets
                                  where item.DanhBo == DanhBo || (item.ThuMoi.DonKH.DanhBo == DanhBo || item.ThuMoi.DonTXL.DanhBo == DanhBo || item.ThuMoi.DonTBC.DanhBo == DanhBo)
                                  select new
                                  {
                                      MaDon = item.ThuMoi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.ThuMoi.MaDonMoi).Count() == 1 ? "" + item.ThuMoi.MaDonMoi : item.ThuMoi.MaDonMoi + "." + item.STT
                                     : item.ThuMoi.MaDonTKH != null ? "TKH" + item.ThuMoi.MaDonTKH
                                      : item.ThuMoi.MaDonTXL != null ? "TXL" + item.ThuMoi.MaDonTXL
                                      : item.ThuMoi.MaDonTBC != null ? "TBC" + item.ThuMoi.MaDonTBC : null,
                                      item.IDCT,
                                      item.SoPhieu,
                                      item.Lan,
                                      item.DanhBo,
                                      item.HoTen,
                                      item.DiaChi,
                                      item.CreateDate,
                                      item.VeViec,
                                  };
                DataTable dtThuMoi = new DataTable();
                dtThuMoi = LINQToDataTable(queryThuMoi);
                dtThuMoi.TableName = "ThuMoi";
                ds.Tables.Add(dtThuMoi);

                #endregion

                DataTable dt = new DataTable();

                #region DonTu

                ///Table DonTu
                var queryDonTu = from itemDon in db.DonTu_ChiTiets
                                 where itemDon.DanhBo == DanhBo
                                 select new
                                 {
                                     MaDon =  itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                     TenLD="",
                                     itemDon.CreateDate,
                                     itemDon.DanhBo,
                                     itemDon.HoTen,
                                     itemDon.DiaChi,
                                     itemDon.GiaBieu,
                                     itemDon.DinhMuc,
                                     NoiDung=itemDon.DonTu.Name_NhomDon,
                                 };
                dt = LINQToDataTable(queryDonTu);

                ///Table KTXM_ChiTiets
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemCTKTXM in db.KTXM_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new {MaDon= itemCTKTXM.KTXM.MaDonMoi,itemCTKTXM.STT }
                             where itemCTKTXM.DanhBo == DanhBo
                             select new
                             {
                                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD = "",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///Table BamChi_ChiTiets
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemCTBamChi in db.BamChi_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTBamChi.BamChi.MaDonMoi, itemCTBamChi.STT }
                             where itemCTBamChi.DanhBo == DanhBo
                             select new
                             {
                                 MaDon =  itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD="",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///Table DCBD_ChiTietBienDongs
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemCTDCBD in db.DCBD_ChiTietBienDongs on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTDCBD.DCBD.MaDonMoi, itemCTDCBD.STT }
                             where itemCTDCBD.DanhBo == DanhBo
                             select new
                             {
                                 MaDon =  itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD="",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///Table DCBD_ChiTietHoaDons
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemCTDCHD in db.DCBD_ChiTietHoaDons on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTDCHD.DCBD.MaDonMoi, itemCTDCHD.STT }
                             where itemCTDCHD.DanhBo == DanhBo
                             select new
                             {
                                 MaDon =  itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD="",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///Table CHDB_ChiTietCatTams
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemCTCTDB in db.CHDB_ChiTietCatTams on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTCTDB.CHDB.MaDonMoi, itemCTCTDB.STT }
                             where itemCTCTDB.DanhBo == DanhBo
                             select new
                             {
                                 MaDon =  itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD="",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///Table CHDB_ChiTietCatHuys
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemCTCHDB in db.CHDB_ChiTietCatHuys on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTCHDB.CHDB.MaDonMoi, itemCTCHDB.STT }
                             where itemCTCHDB.DanhBo == DanhBo
                             select new
                             {
                                 MaDon =  itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD="",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///TablePhieuCHDBs
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemYCCHDB in db.CHDB_Phieus on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemYCCHDB.CHDB.MaDonMoi, itemYCCHDB.STT }
                             where itemYCCHDB.DanhBo == DanhBo
                             select new
                             {
                                 MaDon =  itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD="",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///Table TTTL_ChiTiets
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemCTTTTL in db.TTTL_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTTTTL.TTTL.MaDonMoi, itemCTTTTL.STT }
                             where itemCTTTTL.DanhBo == DanhBo
                             select new
                             {
                                 MaDon =  itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD="",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///Table DongNuoc_ChiTiets
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemCTDongNuoc in db.DongNuoc_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTDongNuoc.DongNuoc.MaDonMoi, itemCTDongNuoc.STT }
                             where itemCTDongNuoc.DanhBo == DanhBo
                             select new
                             {
                                 MaDon =  itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD="",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///Table GianLan_ChiTiets
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemGL in db.GianLan_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemGL.GianLan.MaDonMoi, itemGL.STT }
                             where itemGL.DanhBo == DanhBo
                             select new
                             {
                                 MaDon =  itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD="",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///Table TruyThu
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemTT in db.TruyThuTienNuoc_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemTT.TruyThuTienNuoc.MaDonMoi, itemTT.STT }
                             where itemTT.DanhBo == DanhBo
                             select new
                             {
                                 MaDon =  itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD="",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///Table ToTrinh
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemCTTT in db.ToTrinh_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTTT.ToTrinh.MaDonMoi, itemCTTT.STT }
                             where itemCTTT.DanhBo == DanhBo
                             select new
                             {
                                 MaDon =  itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD="",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///Table ThuMoi
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemTM in db.ThuMoi_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemTM.ThuMoi.MaDonMoi, itemTM.STT }
                             where itemTM.DanhBo == DanhBo
                             select new
                             {
                                 MaDon =  itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD="",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

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
                
                dt.Merge( LINQToDataTable(queryDonKH));

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
                             join itemYCCHDB in db.CHDB_Phieus on itemDon.MaDon equals itemYCCHDB.CHDB.MaDon
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

                ///Table TTTL_ChiTiets
                queryDonKH = from itemDon in db.DonKHs
                             join itemCTTTTL in db.TTTL_ChiTiets on itemDon.MaDon equals itemCTTTTL.TTTL.MaDon
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

                ///Table TruyThu
                queryDonKH = from itemDon in db.DonKHs
                             join itemTT in db.TruyThuTienNuoc_ChiTiets on itemDon.MaDon equals itemTT.TruyThuTienNuoc.MaDon
                             where itemTT.DanhBo == DanhBo
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

                ///Table ToTrinh
                queryDonKH = from itemDon in db.DonKHs
                             join itemCTTT in db.ToTrinh_ChiTiets on itemDon.MaDon equals itemCTTT.ToTrinh.MaDon
                             where itemCTTT.DanhBo == DanhBo
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

                ///Table ThuMoi
                queryDonKH = from itemDon in db.DonKHs
                             join itemTM in db.ThuMoi_ChiTiets on itemDon.MaDon equals itemTM.ThuMoi.MaDonTKH
                             where itemTM.DanhBo == DanhBo
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
                              join itemYCCHDB in db.CHDB_Phieus on itemDonTXL.MaDon equals itemYCCHDB.CHDB.MaDonTXL
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

                ///Table TTTL_ChiTiets
                queryDonTXL = from itemDonTXL in db.DonTXLs
                              join itemCTTTTL in db.TTTL_ChiTiets on itemDonTXL.MaDon equals itemCTTTTL.TTTL.MaDonTXL
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

                ///Table TruyThu
                queryDonTXL = from itemDonTXL in db.DonTXLs
                              join itemTT in db.TruyThuTienNuoc_ChiTiets on itemDonTXL.MaDon equals itemTT.TruyThuTienNuoc.MaDonTXL
                              where itemTT.DanhBo == DanhBo
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

                ///Table ToTrinh
                queryDonTXL = from itemDon in db.DonTXLs
                              join itemCTTT in db.ToTrinh_ChiTiets on itemDon.MaDon equals itemCTTT.ToTrinh.MaDonTXL
                              where itemCTTT.DanhBo == DanhBo
                              select new
                              {
                                  MaDon = "TXL" + itemDon.MaDon,
                                  itemDon.LoaiDonTXL.TenLD,
                                  itemDon.CreateDate,
                                  itemDon.DanhBo,
                                  itemDon.HoTen,
                                  itemDon.DiaChi,
                                  itemDon.GiaBieu,
                                  itemDon.DinhMuc,
                                  itemDon.NoiDung,
                              };
                dt.Merge(LINQToDataTable(queryDonTXL));

                ///Table ThuMoi
                queryDonTXL = from itemDon in db.DonTXLs
                              join itemTM in db.ThuMoi_ChiTiets on itemDon.MaDon equals itemTM.ThuMoi.MaDonTXL
                              where itemTM.DanhBo == DanhBo
                              select new
                              {
                                  MaDon = "TXL" + itemDon.MaDon,
                                  itemDon.LoaiDonTXL.TenLD,
                                  itemDon.CreateDate,
                                  itemDon.DanhBo,
                                  itemDon.HoTen,
                                  itemDon.DiaChi,
                                  itemDon.GiaBieu,
                                  itemDon.DinhMuc,
                                  itemDon.NoiDung,
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
                              join itemYCCHDB in db.CHDB_Phieus on itemDon.MaDon equals itemYCCHDB.CHDB.MaDonTBC
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

                ///Table TTTL_ChiTiets
                queryDonTBC = from itemDon in db.DonTBCs
                              join itemCTTTTL in db.TTTL_ChiTiets on itemDon.MaDon equals itemCTTTTL.TTTL.MaDonTBC
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

                ///Table TruyThu
                queryDonTBC = from itemDon in db.DonTBCs
                              join itemTT in db.TruyThuTienNuoc_ChiTiets on itemDon.MaDon equals itemTT.TruyThuTienNuoc.MaDonTBC
                              where itemTT.DanhBo == DanhBo
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

                ///Table ToTrinh
                queryDonTBC = from itemDon in db.DonTBCs
                              join itemCTTT in db.ToTrinh_ChiTiets on itemDon.MaDon equals itemCTTT.ToTrinh.MaDonTBC
                              where itemCTTT.DanhBo == DanhBo
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

                ///Table ThuMoi
                queryDonTBC = from itemDon in db.DonTBCs
                              join itemTM in db.ThuMoi_ChiTiets on itemDon.MaDon equals itemTM.ThuMoi.MaDonTBC
                              where itemTM.DanhBo == DanhBo
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

                dtDon.DefaultView.Sort = "CreateDate ASC";
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

                if (dtDon.Rows.Count > 0 && dtTruyThu.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Truy Thu", ds.Tables["Don"].Columns["MaDon"], ds.Tables["TruyThu"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtToTrinh.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Tờ Trình", ds.Tables["Don"].Columns["MaDon"], ds.Tables["ToTrinh"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtThuMoi.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Thư Mời", ds.Tables["Don"].Columns["MaDon"], ds.Tables["ThuMoi"].Columns["MaDon"]);

                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataSet GetTienTrinhByHoTen(string HoTen)
        {
            try
            {
                DataSet ds = new DataSet();

                #region HoTen

                ///Table CTKTXM
                var queryKTXM = from itemCTKTXM in db.KTXM_ChiTiets
                                join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                where itemCTKTXM.HoTen.Contains(HoTen)
                                select new
                                {
                                    MaDon = itemCTKTXM.KTXM.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTKTXM.KTXM.MaDonMoi).Count() == 1 ? "" + itemCTKTXM.KTXM.MaDonMoi : itemCTKTXM.KTXM.MaDonMoi + "." + itemCTKTXM.STT
                                      : itemCTKTXM.KTXM.MaDon != null ? "TKH" + itemCTKTXM.KTXM.MaDon
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
                                  where itemCTBamChi.HoTen.Contains(HoTen)
                                  select new
                                  {
                                      MaDon = itemCTBamChi.BamChi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTBamChi.BamChi.MaDonMoi).Count() == 1 ? "" + itemCTBamChi.BamChi.MaDonMoi : itemCTBamChi.BamChi.MaDonMoi + "." + itemCTBamChi.STT
                                      : itemCTBamChi.BamChi.MaDon != null ? "TKH" + itemCTBamChi.BamChi.MaDon
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
                                    where itemCTDongNuoc.HoTen.Contains(HoTen)
                                    select new
                                    {
                                        MaDon = itemCTDongNuoc.DongNuoc.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTDongNuoc.DongNuoc.MaDonMoi).Count() == 1 ? "" + itemCTDongNuoc.DongNuoc.MaDonMoi : itemCTDongNuoc.DongNuoc.MaDonMoi + "." + itemCTDongNuoc.STT
                                      : itemCTDongNuoc.DongNuoc.MaDon != null ? "TKH" + itemCTDongNuoc.DongNuoc.MaDon
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
                                  where itemCTDCBD.HoTen.Contains(HoTen)
                                  select new
                                  {
                                      MaDon = itemCTDCBD.DCBD.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTDCBD.DCBD.MaDonMoi).Count() == 1 ? "" + itemCTDCBD.DCBD.MaDonMoi : itemCTDCBD.DCBD.MaDonMoi + "." + itemCTDCBD.STT
                                      : itemCTDCBD.DCBD.MaDon != null ? "TKH" + itemCTDCBD.DCBD.MaDon
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
                                  where itemCTDCHD.HoTen.Contains(HoTen)
                                  select new
                                  {
                                      MaDon = itemCTDCHD.DCBD.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTDCHD.DCBD.MaDonMoi).Count() == 1 ? "" + itemCTDCHD.DCBD.MaDonMoi : itemCTDCHD.DCBD.MaDonMoi + "." + itemCTDCHD.STT
                                      : itemCTDCHD.DCBD.MaDon != null ? "TKH" + itemCTDCHD.DCBD.MaDon
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
                                  where itemCTCTDB.HoTen.Contains(HoTen)
                                  select new
                                  {
                                      MaDon = itemCTCTDB.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTCTDB.CHDB.MaDonMoi).Count() == 1 ? "" + itemCTCTDB.CHDB.MaDonMoi : itemCTCTDB.CHDB.MaDonMoi + "." + itemCTCTDB.STT
                                      : itemCTCTDB.CHDB.MaDon != null ? "TKH" + itemCTCTDB.CHDB.MaDon
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

                ///Table CHDB_ChiTietCatHuy
                var queryCTCHDB = from itemCTCHDB in db.CHDB_ChiTietCatHuys
                                  where itemCTCHDB.HoTen.Contains(HoTen)
                                  select new
                                  {
                                      MaDon = itemCTCHDB.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTCHDB.CHDB.MaDonMoi).Count() == 1 ? "" + itemCTCHDB.CHDB.MaDonMoi : itemCTCHDB.CHDB.MaDonMoi + "." + itemCTCHDB.STT
                                      : itemCTCHDB.CHDB.MaDon != null ? "TKH" + itemCTCHDB.CHDB.MaDon
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
                                  where itemYCCHDB.HoTen.Contains(HoTen)
                                  select new
                                  {
                                      MaDon = itemYCCHDB.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemYCCHDB.CHDB.MaDonMoi).Count() == 1 ? "" + itemYCCHDB.CHDB.MaDonMoi : itemYCCHDB.CHDB.MaDonMoi + "." + itemYCCHDB.STT
                                      : itemYCCHDB.CHDB.MaDon != null ? "TKH" + itemYCCHDB.CHDB.MaDonTXL
                                    : itemYCCHDB.CHDB.MaDonTXL != null ? "TXL" + itemYCCHDB.CHDB.MaDonTXL
                                    : itemYCCHDB.CHDB.MaDonTBC != null ? "TBC" + itemYCCHDB.CHDB.MaDonTBC : null,
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
                var queryTTTL = from itemCTTTTL in db.TTTL_ChiTiets
                                where itemCTTTTL.HoTen.Contains(HoTen)
                                select new
                                {

                                    MaDon = itemCTTTTL.TTTL.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTTTTL.TTTL.MaDonMoi).Count() == 1 ? "" + itemCTTTTL.TTTL.MaDonMoi : itemCTTTTL.TTTL.MaDonMoi + "." + itemCTTTTL.STT
                                      : itemCTTTTL.TTTL.MaDon != null ? "TKH" + itemCTTTTL.TTTL.MaDon
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
                var queryGianLan = from itemGL in db.GianLan_ChiTiets
                                   where itemGL.HoTen.Contains(HoTen)
                                   select new
                                   {
                                       MaDon = itemGL.GianLan.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemGL.GianLan.MaDonMoi).Count() == 1 ? "" + itemGL.GianLan.MaDonMoi : itemGL.GianLan.MaDonMoi + "." + itemGL.STT
                                      : itemGL.GianLan.MaDon != null ? "TKH" + itemGL.GianLan.MaDon
                                       : itemGL.GianLan.MaDonTXL != null ? "TXL" + itemGL.GianLan.MaDonTXL
                                       : itemGL.GianLan.MaDonTBC != null ? "TBC" + itemGL.GianLan.MaDonTBC : null,
                                       ID = itemGL.MaCTGL,
                                       itemGL.CreateDate,
                                       itemGL.DanhBo,
                                       itemGL.HoTen,
                                       itemGL.DiaChi,
                                       itemGL.NoiDungViPham,
                                       itemGL.TinhTrang,
                                       itemGL.ThanhToan1,
                                       itemGL.ThanhToan2,
                                       itemGL.ThanhToan3,
                                       itemGL.XepDon,
                                   };
                DataTable dtGianLan = new DataTable();
                dtGianLan = LINQToDataTable(queryGianLan);
                dtGianLan.TableName = "GianLan";
                ds.Tables.Add(dtGianLan);

                ///Table TruyThu
                var queryTruyThu = from itemTT in db.TruyThuTienNuoc_ChiTiets
                                   where itemTT.HoTen.Contains(HoTen)
                                   select new
                                   {
                                       MaDon = itemTT.TruyThuTienNuoc.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemTT.TruyThuTienNuoc.MaDonMoi).Count() == 1 ? "" + itemTT.TruyThuTienNuoc.MaDonMoi : itemTT.TruyThuTienNuoc.MaDonMoi + "." + itemTT.STT
                                      : itemTT.TruyThuTienNuoc.MaDon != null ? "TKH" + itemTT.TruyThuTienNuoc.MaDon
                                       : itemTT.TruyThuTienNuoc.MaDonTXL != null ? "TXL" + itemTT.TruyThuTienNuoc.MaDonTXL
                                       : itemTT.TruyThuTienNuoc.MaDonTBC != null ? "TBC" + itemTT.TruyThuTienNuoc.MaDonTBC : null,
                                       itemTT.IDCT,
                                       itemTT.DanhBo,
                                       itemTT.HoTen,
                                       itemTT.DiaChi,
                                       itemTT.CreateDate,
                                       itemTT.NoiDung,
                                       itemTT.TongTien,
                                       itemTT.Tongm3BinhQuan,
                                       itemTT.TinhTrang,
                                   };
                DataTable dtTruyThu = new DataTable();
                dtTruyThu = LINQToDataTable(queryTruyThu);
                dtTruyThu.TableName = "TruyThu";
                ds.Tables.Add(dtTruyThu);

                ///Table ToTrinh
                var queryToTrinh = from itemCTTT in db.ToTrinh_ChiTiets
                                   where itemCTTT.HoTen.Contains(HoTen)
                                   select new
                                   {
                                       MaDon = itemCTTT.ToTrinh.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTTT.ToTrinh.MaDonMoi).Count() == 1 ? "" + itemCTTT.ToTrinh.MaDonMoi : itemCTTT.ToTrinh.MaDonMoi + "." + itemCTTT.STT
                                      : itemCTTT.ToTrinh.MaDon != null ? "TKH" + itemCTTT.ToTrinh.MaDon
                                       : itemCTTT.ToTrinh.MaDonTXL != null ? "TXL" + itemCTTT.ToTrinh.MaDonTXL
                                       : itemCTTT.ToTrinh.MaDonTBC != null ? "TBC" + itemCTTT.ToTrinh.MaDonTBC : null,
                                       itemCTTT.IDCT,
                                       itemCTTT.DanhBo,
                                       itemCTTT.HoTen,
                                       itemCTTT.DiaChi,
                                       itemCTTT.CreateDate,
                                       itemCTTT.NoiDung,
                                       itemCTTT.VeViec,
                                   };
                DataTable dtToTrinh = new DataTable();
                dtToTrinh = LINQToDataTable(queryToTrinh);
                dtToTrinh.TableName = "ToTrinh";
                ds.Tables.Add(dtToTrinh);

                ///Table ThuMoi
                var queryThuMoi = from item in db.ThuMoi_ChiTiets
                                  where item.HoTen.Contains(HoTen)
                                  select new
                                  {
                                      MaDon = item.ThuMoi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.ThuMoi.MaDonMoi).Count() == 1 ? "" + item.ThuMoi.MaDonMoi : item.ThuMoi.MaDonMoi + "." + item.STT
                                     : item.ThuMoi.MaDonTKH != null ? "TKH" + item.ThuMoi.MaDonTKH
                                      : item.ThuMoi.MaDonTXL != null ? "TXL" + item.ThuMoi.MaDonTXL
                                      : item.ThuMoi.MaDonTBC != null ? "TBC" + item.ThuMoi.MaDonTBC : null,
                                      item.IDCT,
                                      item.SoPhieu,
                                      item.Lan,
                                      item.DanhBo,
                                      item.HoTen,
                                      item.DiaChi,
                                      item.CreateDate,
                                      item.VeViec,
                                  };
                DataTable dtThuMoi = new DataTable();
                dtThuMoi = LINQToDataTable(queryThuMoi);
                dtThuMoi.TableName = "ThuMoi";
                ds.Tables.Add(dtThuMoi);

                #endregion

                DataTable dt = new DataTable();

                #region DonTu

                ///Table DonTu
                var queryDonTu = from itemDon in db.DonTu_ChiTiets
                                 where itemDon.HoTen.Contains(HoTen)
                                 select new
                                 {
                                     MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                     TenLD = "",
                                     itemDon.CreateDate,
                                     itemDon.DanhBo,
                                     itemDon.HoTen,
                                     itemDon.DiaChi,
                                     itemDon.GiaBieu,
                                     itemDon.DinhMuc,
                                     NoiDung=itemDon.DonTu.Name_NhomDon,
                                 };
                dt = LINQToDataTable(queryDonTu);

                ///Table KTXM_ChiTiets
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemCTKTXM in db.KTXM_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTKTXM.KTXM.MaDonMoi, itemCTKTXM.STT }
                             where itemCTKTXM.HoTen.Contains(HoTen)
                             select new
                             {
                                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD = "",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///Table BamChi_ChiTiets
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemCTBamChi in db.BamChi_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTBamChi.BamChi.MaDonMoi, itemCTBamChi.STT }
                             where itemCTBamChi.HoTen.Contains(HoTen)
                             select new
                             {
                                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD = "",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///Table DCBD_ChiTietBienDongs
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemCTDCBD in db.DCBD_ChiTietBienDongs on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTDCBD.DCBD.MaDonMoi, itemCTDCBD.STT }
                             where itemCTDCBD.HoTen.Contains(HoTen)
                             select new
                             {
                                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD = "",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///Table DCBD_ChiTietHoaDons
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemCTDCHD in db.DCBD_ChiTietHoaDons on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTDCHD.DCBD.MaDonMoi, itemCTDCHD.STT }
                             where itemCTDCHD.HoTen.Contains(HoTen)
                             select new
                             {
                                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD = "",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///Table CHDB_ChiTietCatTams
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemCTCTDB in db.CHDB_ChiTietCatTams on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTCTDB.CHDB.MaDonMoi, itemCTCTDB.STT }
                             where itemCTCTDB.HoTen.Contains(HoTen)
                             select new
                             {
                                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD = "",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///Table CHDB_ChiTietCatHuys
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemCTCHDB in db.CHDB_ChiTietCatHuys on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTCHDB.CHDB.MaDonMoi, itemCTCHDB.STT }
                             where itemCTCHDB.HoTen.Contains(HoTen)
                             select new
                             {
                                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD = "",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///TablePhieuCHDBs
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemYCCHDB in db.CHDB_Phieus on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemYCCHDB.CHDB.MaDonMoi, itemYCCHDB.STT }
                             where itemYCCHDB.HoTen.Contains(HoTen)
                             select new
                             {
                                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD = "",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///Table TTTL_ChiTiets
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemCTTTTL in db.TTTL_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTTTTL.TTTL.MaDonMoi, itemCTTTTL.STT }
                             where itemCTTTTL.HoTen.Contains(HoTen)
                             select new
                             {
                                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD = "",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///Table DongNuoc_ChiTiets
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemCTDongNuoc in db.DongNuoc_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTDongNuoc.DongNuoc.MaDonMoi, itemCTDongNuoc.STT }
                             where itemCTDongNuoc.HoTen.Contains(HoTen)
                             select new
                             {
                                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD = "",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///Table GianLan_ChiTiets
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemGL in db.GianLan_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemGL.GianLan.MaDonMoi, itemGL.STT }
                             where itemGL.HoTen.Contains(HoTen)
                             select new
                             {
                                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD = "",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///Table TruyThu
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemTT in db.TruyThuTienNuoc_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemTT.TruyThuTienNuoc.MaDonMoi, itemTT.STT }
                             where itemTT.HoTen.Contains(HoTen)
                             select new
                             {
                                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD = "",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///Table ToTrinh
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemCTTT in db.ToTrinh_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTTT.ToTrinh.MaDonMoi, itemCTTT.STT }
                             where itemCTTT.HoTen.Contains(HoTen)
                             select new
                             {
                                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD = "",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///Table ThuMoi
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemTM in db.ThuMoi_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemTM.ThuMoi.MaDonMoi, itemTM.STT }
                             where itemTM.HoTen.Contains(HoTen)
                             select new
                             {
                                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD = "",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                #endregion

                #region DonKH

                ///Table DonKH
                var queryDonKH = from itemDon in db.DonKHs
                                 where itemDon.HoTen.Contains(HoTen)
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
                dt.Merge( LINQToDataTable(queryDonKH));

                ///Table KTXM_ChiTiets
                queryDonKH = from itemDon in db.DonKHs
                             join itemCTKTXM in db.KTXM_ChiTiets on itemDon.MaDon equals itemCTKTXM.KTXM.MaDon
                             where itemCTKTXM.HoTen.Contains(HoTen)
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
                             where itemCTBamChi.HoTen.Contains(HoTen)
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
                             where itemCTDCBD.HoTen.Contains(HoTen)
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
                             where itemCTDCHD.HoTen.Contains(HoTen)
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
                             where itemCTCTDB.HoTen.Contains(HoTen)
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
                             where itemCTCHDB.HoTen.Contains(HoTen)
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
                             join itemYCCHDB in db.CHDB_Phieus on itemDon.MaDon equals itemYCCHDB.CHDB.MaDon
                             where itemYCCHDB.HoTen.Contains(HoTen)
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

                ///Table TTTL_ChiTiets
                queryDonKH = from itemDon in db.DonKHs
                             join itemCTTTTL in db.TTTL_ChiTiets on itemDon.MaDon equals itemCTTTTL.TTTL.MaDon
                             where itemCTTTTL.HoTen.Contains(HoTen)
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
                             where itemCTDongNuoc.HoTen.Contains(HoTen)
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
                             where itemGL.HoTen.Contains(HoTen)
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

                ///Table TruyThu
                queryDonKH = from itemDon in db.DonKHs
                             join itemTT in db.TruyThuTienNuoc_ChiTiets on itemDon.MaDon equals itemTT.TruyThuTienNuoc.MaDon
                             where itemTT.HoTen.Contains(HoTen)
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

                ///Table ToTrinh
                queryDonKH = from itemDon in db.DonKHs
                             join itemCTTT in db.ToTrinh_ChiTiets on itemDon.MaDon equals itemCTTT.ToTrinh.MaDon
                             where itemCTTT.HoTen.Contains(HoTen)
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

                ///Table ThuMoi
                queryDonKH = from itemDon in db.DonKHs
                             join itemTM in db.ThuMoi_ChiTiets on itemDon.MaDon equals itemTM.ThuMoi.MaDonTKH
                             where itemTM.HoTen.Contains(HoTen)
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
                                  where itemDonTXL.HoTen.Contains(HoTen)
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
                              where itemCTKTXM.HoTen.Contains(HoTen)
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
                              where itemCTBamChi.HoTen.Contains(HoTen)
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
                              where itemCTDCBD.HoTen.Contains(HoTen)
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
                              where itemCTDCHD.HoTen.Contains(HoTen)
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
                              where itemCTCTDB.HoTen.Contains(HoTen)
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
                              where itemCTCHDB.HoTen.Contains(HoTen)
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
                              join itemYCCHDB in db.CHDB_Phieus on itemDonTXL.MaDon equals itemYCCHDB.CHDB.MaDonTXL
                              where itemYCCHDB.HoTen.Contains(HoTen)
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

                ///Table TTTL_ChiTiets
                queryDonTXL = from itemDonTXL in db.DonTXLs
                              join itemCTTTTL in db.TTTL_ChiTiets on itemDonTXL.MaDon equals itemCTTTTL.TTTL.MaDonTXL
                              where itemCTTTTL.HoTen.Contains(HoTen)
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
                              where itemCTDongNuoc.HoTen.Contains(HoTen)
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
                              where itemGL.HoTen.Contains(HoTen)
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

                ///Table TruyThu
                queryDonTXL = from itemDonTXL in db.DonTXLs
                              join itemTT in db.TruyThuTienNuoc_ChiTiets on itemDonTXL.MaDon equals itemTT.TruyThuTienNuoc.MaDonTXL
                              where itemTT.HoTen.Contains(HoTen)
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

                ///Table ToTrinh
                queryDonTXL = from itemDonTXL in db.DonTXLs
                              join itemCTTT in db.ToTrinh_ChiTiets on itemDonTXL.MaDon equals itemCTTT.ToTrinh.MaDonTXL
                              where itemCTTT.HoTen.Contains(HoTen)
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

                ///Table ThuMoi
                queryDonTXL = from itemDonTXL in db.DonTXLs
                              join itemTM in db.ThuMoi_ChiTiets on itemDonTXL.MaDon equals itemTM.ThuMoi.MaDonTXL
                              where itemTM.HoTen.Contains(HoTen)
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
                                  where itemDon.HoTen.Contains(HoTen)
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
                              where itemCTKTXM.HoTen.Contains(HoTen)
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
                              where itemCTBamChi.HoTen.Contains(HoTen)
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
                              where itemCTDCBD.HoTen.Contains(HoTen)
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
                              where itemCTDCHD.HoTen.Contains(HoTen)
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
                              where itemCTCTDB.HoTen.Contains(HoTen)
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
                              where itemCTCHDB.HoTen.Contains(HoTen)
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
                              join itemYCCHDB in db.CHDB_Phieus on itemDon.MaDon equals itemYCCHDB.CHDB.MaDonTBC
                              where itemYCCHDB.HoTen.Contains(HoTen)
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

                ///Table TTTL_ChiTiets
                queryDonTBC = from itemDon in db.DonTBCs
                              join itemCTTTTL in db.TTTL_ChiTiets on itemDon.MaDon equals itemCTTTTL.TTTL.MaDonTBC
                              where itemCTTTTL.HoTen.Contains(HoTen)
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
                              where itemCTDongNuoc.HoTen.Contains(HoTen)
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
                              where itemGL.HoTen.Contains(HoTen)
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

                ///Table TruyThu
                queryDonTBC = from itemDon in db.DonTBCs
                              join itemTT in db.TruyThuTienNuoc_ChiTiets on itemDon.MaDon equals itemTT.TruyThuTienNuoc.MaDonTBC
                              where itemTT.HoTen.Contains(HoTen)
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

                ///Table ToTrinh
                queryDonTBC = from itemDon in db.DonTBCs
                              join itemCTTT in db.ToTrinh_ChiTiets on itemDon.MaDon equals itemCTTT.ToTrinh.MaDonTBC
                              where itemCTTT.HoTen.Contains(HoTen)
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

                ///Table ToTrinh
                queryDonTBC = from itemDon in db.DonTBCs
                              join itemTM in db.ThuMoi_ChiTiets on itemDon.MaDon equals itemTM.ThuMoi.MaDonTBC
                              where itemTM.HoTen.Contains(HoTen)
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
                    if (dtDon.Select("MaDon = '" + itemRow["MaDon"] + "'").Count() <= 0)
                        dtDon.ImportRow(itemRow);
                }

                dtDon.DefaultView.Sort = "CreateDate ASC";
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
                    ds.Relations.Add("Chi Tiết Phiếu Hủy Danh Bộ TXL", ds.Tables["Don"].Columns["MaDon"], ds.Tables["YCCHDB"].Columns["MaDonTXL"]);

                if (dtDon.Rows.Count > 0 && dtTTTL.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời TXL", ds.Tables["Don"].Columns["MaDon"], ds.Tables["TTTL"].Columns["MaDonTXL"]);

                if (dtDon.Rows.Count > 0 && dtGianLan.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Gian Lận", ds.Tables["Don"].Columns["MaDon"], ds.Tables["GianLan"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtTruyThu.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Truy Thu", ds.Tables["Don"].Columns["MaDon"], ds.Tables["TruyThu"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtToTrinh.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Tờ Trình", ds.Tables["Don"].Columns["MaDon"], ds.Tables["ToTrinh"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtThuMoi.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Thư Mời", ds.Tables["Don"].Columns["MaDon"], ds.Tables["ThuMoi"].Columns["MaDon"]);

                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataSet GetTienTrinhByDiaChi(string DiaChi)
        {
            try
            {
                DataSet ds = new DataSet();

                #region DiaChi

                ///Table CTKTXM
                var queryKTXM = from itemCTKTXM in db.KTXM_ChiTiets
                                join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                where itemCTKTXM.DiaChi.Contains(DiaChi)
                                select new
                                {
                                    MaDon = itemCTKTXM.KTXM.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTKTXM.KTXM.MaDonMoi).Count() == 1 ? "" + itemCTKTXM.KTXM.MaDonMoi : itemCTKTXM.KTXM.MaDonMoi + "." + itemCTKTXM.STT
                                      : itemCTKTXM.KTXM.MaDon != null ? "TKH" + itemCTKTXM.KTXM.MaDon
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
                                  where itemCTBamChi.DiaChi.Contains(DiaChi)
                                  select new
                                  {
                                      MaDon = itemCTBamChi.BamChi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTBamChi.BamChi.MaDonMoi).Count() == 1 ? "" + itemCTBamChi.BamChi.MaDonMoi : itemCTBamChi.BamChi.MaDonMoi + "." + itemCTBamChi.STT
                                      : itemCTBamChi.BamChi.MaDon != null ? "TKH" + itemCTBamChi.BamChi.MaDon
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
                                    where itemCTDongNuoc.DiaChi.Contains(DiaChi)
                                    select new
                                    {
                                        MaDon = itemCTDongNuoc.DongNuoc.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTDongNuoc.DongNuoc.MaDonMoi).Count() == 1 ? "" + itemCTDongNuoc.DongNuoc.MaDonMoi : itemCTDongNuoc.DongNuoc.MaDonMoi + "." + itemCTDongNuoc.STT
                                      : itemCTDongNuoc.DongNuoc.MaDon != null ? "TKH" + itemCTDongNuoc.DongNuoc.MaDon
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
                                  where itemCTDCBD.DiaChi.Contains(DiaChi)
                                  select new
                                  {
                                      MaDon = itemCTDCBD.DCBD.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTDCBD.DCBD.MaDonMoi).Count() == 1 ? "" + itemCTDCBD.DCBD.MaDonMoi : itemCTDCBD.DCBD.MaDonMoi + "." + itemCTDCBD.STT
                                      : itemCTDCBD.DCBD.MaDon != null ? "TKH" + itemCTDCBD.DCBD.MaDon
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
                                  where itemCTDCHD.DiaChi.Contains(DiaChi)
                                  select new
                                  {
                                      MaDon = itemCTDCHD.DCBD.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTDCHD.DCBD.MaDonMoi).Count() == 1 ? "" + itemCTDCHD.DCBD.MaDonMoi : itemCTDCHD.DCBD.MaDonMoi + "." + itemCTDCHD.STT
                                      : itemCTDCHD.DCBD.MaDon != null ? "TKH" + itemCTDCHD.DCBD.MaDon
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
                                  where itemCTCTDB.DiaChi.Contains(DiaChi)
                                  select new
                                  {
                                      MaDon = itemCTCTDB.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTCTDB.CHDB.MaDonMoi).Count() == 1 ? "" + itemCTCTDB.CHDB.MaDonMoi : itemCTCTDB.CHDB.MaDonMoi + "." + itemCTCTDB.STT
                                      : itemCTCTDB.CHDB.MaDon != null ? "TKH" + itemCTCTDB.CHDB.MaDon
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

                ///Table CHDB_ChiTietCatHuy
                var queryCTCHDB = from itemCTCHDB in db.CHDB_ChiTietCatHuys
                                  where itemCTCHDB.DiaChi.Contains(DiaChi)
                                  select new
                                  {
                                      MaDon = itemCTCHDB.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTCHDB.CHDB.MaDonMoi).Count() == 1 ? "" + itemCTCHDB.CHDB.MaDonMoi : itemCTCHDB.CHDB.MaDonMoi + "." + itemCTCHDB.STT
                                      : itemCTCHDB.CHDB.MaDon != null ? "TKH" + itemCTCHDB.CHDB.MaDon
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
                                  where itemYCCHDB.DiaChi.Contains(DiaChi)
                                  select new
                                  {
                                      MaDon = itemYCCHDB.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemYCCHDB.CHDB.MaDonMoi).Count() == 1 ? "" + itemYCCHDB.CHDB.MaDonMoi : itemYCCHDB.CHDB.MaDonMoi + "." + itemYCCHDB.STT
                                      : itemYCCHDB.CHDB.MaDon != null ? "TKH" + itemYCCHDB.CHDB.MaDonTXL
                                    : itemYCCHDB.CHDB.MaDonTXL != null ? "TXL" + itemYCCHDB.CHDB.MaDonTXL
                                    : itemYCCHDB.CHDB.MaDonTBC != null ? "TBC" + itemYCCHDB.CHDB.MaDonTBC : null,
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
                var queryTTTL = from itemCTTTTL in db.TTTL_ChiTiets
                                where itemCTTTTL.DiaChi.Contains(DiaChi)
                                select new
                                {
                                    MaDon = itemCTTTTL.TTTL.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTTTTL.TTTL.MaDonMoi).Count() == 1 ? "" + itemCTTTTL.TTTL.MaDonMoi : itemCTTTTL.TTTL.MaDonMoi + "." + itemCTTTTL.STT
                                      : itemCTTTTL.TTTL.MaDon != null ? "TKH" + itemCTTTTL.TTTL.MaDon
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
                var queryGianLan = from itemGL in db.GianLan_ChiTiets
                                   where itemGL.DiaChi.Contains(DiaChi)
                                   select new
                                   {
                                       MaDon = itemGL.GianLan.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemGL.GianLan.MaDonMoi).Count() == 1 ? "" + itemGL.GianLan.MaDonMoi : itemGL.GianLan.MaDonMoi + "." + itemGL.STT
                                         : itemGL.GianLan.MaDon != null ? "TKH" + itemGL.GianLan.MaDon
                                       : itemGL.GianLan.MaDonTXL != null ? "TXL" + itemGL.GianLan.MaDonTXL
                                       : itemGL.GianLan.MaDonTBC != null ? "TBC" + itemGL.GianLan.MaDonTBC : null,
                                       ID = itemGL.MaCTGL,
                                       itemGL.CreateDate,
                                       itemGL.DanhBo,
                                       itemGL.HoTen,
                                       itemGL.DiaChi,
                                       itemGL.NoiDungViPham,
                                       itemGL.TinhTrang,
                                       itemGL.ThanhToan1,
                                       itemGL.ThanhToan2,
                                       itemGL.ThanhToan3,
                                       itemGL.XepDon,
                                   };
                DataTable dtGianLan = new DataTable();
                dtGianLan = LINQToDataTable(queryGianLan);
                dtGianLan.TableName = "GianLan";
                ds.Tables.Add(dtGianLan);

                ///Table TruyThu
                var queryTruyThu = from itemTT in db.TruyThuTienNuoc_ChiTiets
                                   where itemTT.DiaChi.Contains(DiaChi)
                                   select new
                                   {
                                       MaDon = itemTT.TruyThuTienNuoc.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemTT.TruyThuTienNuoc.MaDonMoi).Count() == 1 ? "" + itemTT.TruyThuTienNuoc.MaDonMoi : itemTT.TruyThuTienNuoc.MaDonMoi + "." + itemTT.STT
                                      : itemTT.TruyThuTienNuoc.MaDon != null ? "TKH" + itemTT.TruyThuTienNuoc.MaDon
                                       : itemTT.TruyThuTienNuoc.MaDonTXL != null ? "TXL" + itemTT.TruyThuTienNuoc.MaDonTXL
                                       : itemTT.TruyThuTienNuoc.MaDonTBC != null ? "TBC" + itemTT.TruyThuTienNuoc.MaDonTBC : null,
                                       itemTT.IDCT,
                                       itemTT.DanhBo,
                                       itemTT.HoTen,
                                       itemTT.DiaChi,
                                       itemTT.CreateDate,
                                       itemTT.NoiDung,
                                       itemTT.TongTien,
                                       itemTT.Tongm3BinhQuan,
                                       itemTT.TinhTrang,
                                   };
                DataTable dtTruyThu = new DataTable();
                dtTruyThu = LINQToDataTable(queryTruyThu);
                dtTruyThu.TableName = "TruyThu";
                ds.Tables.Add(dtTruyThu);

                ///Table ToTrinh
                var queryToTrinh = from itemCTTT in db.ToTrinh_ChiTiets
                                   where itemCTTT.DiaChi.Contains(DiaChi)
                                   select new
                                   {
                                       MaDon = itemCTTT.ToTrinh.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTTT.ToTrinh.MaDonMoi).Count() == 1 ? "" + itemCTTT.ToTrinh.MaDonMoi : itemCTTT.ToTrinh.MaDonMoi + "." + itemCTTT.STT
                                      : itemCTTT.ToTrinh.MaDon != null ? "TKH" + itemCTTT.ToTrinh.MaDon
                                       : itemCTTT.ToTrinh.MaDonTXL != null ? "TXL" + itemCTTT.ToTrinh.MaDonTXL
                                       : itemCTTT.ToTrinh.MaDonTBC != null ? "TBC" + itemCTTT.ToTrinh.MaDonTBC : null,
                                       itemCTTT.IDCT,
                                       itemCTTT.DanhBo,
                                       itemCTTT.HoTen,
                                       itemCTTT.DiaChi,
                                       itemCTTT.CreateDate,
                                       itemCTTT.NoiDung,
                                       itemCTTT.VeViec,
                                   };
                DataTable dtToTrinh = new DataTable();
                dtToTrinh = LINQToDataTable(queryToTrinh);
                dtToTrinh.TableName = "ToTrinh";
                ds.Tables.Add(dtToTrinh);

                ///Table ThuMoi
                var queryThuMoi = from item in db.ThuMoi_ChiTiets
                                  where item.DiaChi.Contains(DiaChi)
                                  select new
                                  {
                                      MaDon = item.ThuMoi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.ThuMoi.MaDonMoi).Count() == 1 ? "" + item.ThuMoi.MaDonMoi : item.ThuMoi.MaDonMoi + "." + item.STT
                                     : item.ThuMoi.MaDonTKH != null ? "TKH" + item.ThuMoi.MaDonTKH
                                      : item.ThuMoi.MaDonTXL != null ? "TXL" + item.ThuMoi.MaDonTXL
                                      : item.ThuMoi.MaDonTBC != null ? "TBC" + item.ThuMoi.MaDonTBC : null,
                                      item.IDCT,
                                      item.SoPhieu,
                                      item.Lan,
                                      item.DanhBo,
                                      item.HoTen,
                                      item.DiaChi,
                                      item.CreateDate,
                                      item.VeViec,
                                  };
                DataTable dtThuMoi = new DataTable();
                dtThuMoi = LINQToDataTable(queryThuMoi);
                dtThuMoi.TableName = "ThuMoi";
                ds.Tables.Add(dtThuMoi);

                #endregion

                DataTable dt = new DataTable();

                #region DonTu

                ///Table DonTu
                var queryDonTu = from itemDon in db.DonTu_ChiTiets
                                 where itemDon.DiaChi.Contains(DiaChi)
                                 select new
                                 {
                                     MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                     TenLD = "",
                                     itemDon.CreateDate,
                                     itemDon.DanhBo,
                                     itemDon.HoTen,
                                     itemDon.DiaChi,
                                     itemDon.GiaBieu,
                                     itemDon.DinhMuc,
                                     NoiDung=itemDon.DonTu.Name_NhomDon,
                                 };
                dt = LINQToDataTable(queryDonTu);

                ///Table KTXM_ChiTiets
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemCTKTXM in db.KTXM_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTKTXM.KTXM.MaDonMoi, itemCTKTXM.STT }
                             where itemCTKTXM.DiaChi.Contains(DiaChi)
                             select new
                             {
                                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD = "",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///Table BamChi_ChiTiets
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemCTBamChi in db.BamChi_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTBamChi.BamChi.MaDonMoi, itemCTBamChi.STT }
                             where itemCTBamChi.DiaChi.Contains(DiaChi)
                             select new
                             {
                                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD = "",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///Table DCBD_ChiTietBienDongs
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemCTDCBD in db.DCBD_ChiTietBienDongs on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTDCBD.DCBD.MaDonMoi, itemCTDCBD.STT }
                             where itemCTDCBD.DiaChi.Contains(DiaChi)
                             select new
                             {
                                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD = "",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///Table DCBD_ChiTietHoaDons
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemCTDCHD in db.DCBD_ChiTietHoaDons on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTDCHD.DCBD.MaDonMoi, itemCTDCHD.STT }
                             where itemCTDCHD.DiaChi.Contains(DiaChi)
                             select new
                             {
                                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD = "",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///Table CHDB_ChiTietCatTams
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemCTCTDB in db.CHDB_ChiTietCatTams on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTCTDB.CHDB.MaDonMoi, itemCTCTDB.STT }
                             where itemCTCTDB.DiaChi.Contains(DiaChi)
                             select new
                             {
                                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD = "",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///Table CHDB_ChiTietCatHuys
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemCTCHDB in db.CHDB_ChiTietCatHuys on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTCHDB.CHDB.MaDonMoi, itemCTCHDB.STT }
                             where itemCTCHDB.DiaChi.Contains(DiaChi)
                             select new
                             {
                                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD = "",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///TablePhieuCHDBs
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemYCCHDB in db.CHDB_Phieus on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemYCCHDB.CHDB.MaDonMoi, itemYCCHDB.STT }
                             where itemYCCHDB.DiaChi.Contains(DiaChi)
                             select new
                             {
                                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD = "",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///Table TTTL_ChiTiets
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemCTTTTL in db.TTTL_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTTTTL.TTTL.MaDonMoi, itemCTTTTL.STT }
                             where itemCTTTTL.DiaChi.Contains(DiaChi)
                             select new
                             {
                                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD = "",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///Table DongNuoc_ChiTiets
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemCTDongNuoc in db.DongNuoc_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTDongNuoc.DongNuoc.MaDonMoi, itemCTDongNuoc.STT }
                             where itemCTDongNuoc.DiaChi.Contains(DiaChi)
                             select new
                             {
                                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD = "",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///Table GianLan_ChiTiets
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemGL in db.GianLan_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemGL.GianLan.MaDonMoi, itemGL.STT }
                             where itemGL.DiaChi.Contains(DiaChi)
                             select new
                             {
                                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD = "",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///Table TruyThu
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemTT in db.TruyThuTienNuoc_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemTT.TruyThuTienNuoc.MaDonMoi, itemTT.STT }
                             where itemTT.DiaChi.Contains(DiaChi)
                             select new
                             {
                                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD = "",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///Table ToTrinh
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemCTTT in db.ToTrinh_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTTT.ToTrinh.MaDonMoi, itemCTTT.STT }
                             where itemCTTT.DiaChi.Contains(DiaChi)
                             select new
                             {
                                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD = "",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                ///Table ThuMoi
                queryDonTu = from itemDon in db.DonTu_ChiTiets
                             join itemTM in db.ThuMoi_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemTM.ThuMoi.MaDonMoi, itemTM.STT }
                             where itemTM.DiaChi.Contains(DiaChi)
                             select new
                             {
                                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? "" + itemDon.MaDon : itemDon.MaDon + "." + itemDon.STT,
                                 TenLD = "",
                                 itemDon.CreateDate,
                                 itemDon.DanhBo,
                                 itemDon.HoTen,
                                 itemDon.DiaChi,
                                 itemDon.GiaBieu,
                                 itemDon.DinhMuc,
                                 NoiDung=itemDon.DonTu.Name_NhomDon,
                             };
                dt.Merge(LINQToDataTable(queryDonTu));

                #endregion

                #region DonKH

                ///Table DonKH
                var queryDonKH = from itemDon in db.DonKHs
                                 where itemDon.DiaChi.Contains(DiaChi)
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
                
                dt.Merge( LINQToDataTable(queryDonKH));

                ///Table KTXM_ChiTiets
                queryDonKH = from itemDon in db.DonKHs
                             join itemCTKTXM in db.KTXM_ChiTiets on itemDon.MaDon equals itemCTKTXM.KTXM.MaDon
                             where itemCTKTXM.DiaChi.Contains(DiaChi)
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
                             where itemCTBamChi.DiaChi.Contains(DiaChi)
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
                             where itemCTDCBD.DiaChi.Contains(DiaChi)
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
                             where itemCTDCHD.DiaChi.Contains(DiaChi)
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
                             where itemCTCTDB.DiaChi.Contains(DiaChi)
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
                             where itemCTCHDB.DiaChi.Contains(DiaChi)
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
                             join itemYCCHDB in db.CHDB_Phieus on itemDon.MaDon equals itemYCCHDB.CHDB.MaDon
                             where itemYCCHDB.DiaChi.Contains(DiaChi)
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

                ///Table TTTL_ChiTiets
                queryDonKH = from itemDon in db.DonKHs
                             join itemCTTTTL in db.TTTL_ChiTiets on itemDon.MaDon equals itemCTTTTL.TTTL.MaDon
                             where itemCTTTTL.DiaChi.Contains(DiaChi)
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
                             where itemCTDongNuoc.DiaChi.Contains(DiaChi)
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
                             where itemGL.DiaChi.Contains(DiaChi)
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

                ///Table TruyThu
                queryDonKH = from itemDon in db.DonKHs
                             join itemTT in db.TruyThuTienNuoc_ChiTiets on itemDon.MaDon equals itemTT.TruyThuTienNuoc.MaDon
                             where itemTT.DiaChi.Contains(DiaChi)
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

                ///Table ToTrinh
                queryDonKH = from itemDon in db.DonKHs
                             join itemCTTT in db.ToTrinh_ChiTiets on itemDon.MaDon equals itemCTTT.ToTrinh.MaDon
                             where itemCTTT.DiaChi.Contains(DiaChi)
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

                ///Table ThuMoi
                queryDonKH = from itemDon in db.DonKHs
                             join itemTM in db.ThuMoi_ChiTiets on itemDon.MaDon equals itemTM.ThuMoi.MaDonTKH
                             where itemTM.DiaChi.Contains(DiaChi)
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
                                  where itemDonTXL.DiaChi.Contains(DiaChi)
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
                              where itemCTKTXM.DiaChi.Contains(DiaChi)
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
                              where itemCTBamChi.DiaChi.Contains(DiaChi)
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
                              where itemCTDCBD.DiaChi.Contains(DiaChi)
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
                              where itemCTDCHD.DiaChi.Contains(DiaChi)
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
                              where itemCTCTDB.DiaChi.Contains(DiaChi)
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
                              where itemCTCHDB.DiaChi.Contains(DiaChi)
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
                              join itemYCCHDB in db.CHDB_Phieus on itemDonTXL.MaDon equals itemYCCHDB.CHDB.MaDonTXL
                              where itemYCCHDB.DiaChi.Contains(DiaChi)
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

                ///Table TTTL_ChiTiets
                queryDonTXL = from itemDonTXL in db.DonTXLs
                              join itemCTTTTL in db.TTTL_ChiTiets on itemDonTXL.MaDon equals itemCTTTTL.TTTL.MaDonTXL
                              where itemCTTTTL.DiaChi.Contains(DiaChi)
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
                              where itemCTDongNuoc.DiaChi.Contains(DiaChi)
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
                              where itemGL.DiaChi.Contains(DiaChi)
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

                ///Table TruyThu
                queryDonTXL = from itemDonTXL in db.DonTXLs
                              join itemTT in db.TruyThuTienNuoc_ChiTiets on itemDonTXL.MaDon equals itemTT.TruyThuTienNuoc.MaDonTXL
                              where itemTT.DiaChi.Contains(DiaChi)
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

                ///Table ToTrinh
                queryDonTXL = from itemDonTXL in db.DonTXLs
                              join itemCTTT in db.ToTrinh_ChiTiets on itemDonTXL.MaDon equals itemCTTT.ToTrinh.MaDonTXL
                              where itemCTTT.DiaChi.Contains(DiaChi)
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

                ///Table ThuMoi
                queryDonTXL = from itemDonTXL in db.DonTXLs
                              join itemTM in db.ThuMoi_ChiTiets on itemDonTXL.MaDon equals itemTM.ThuMoi.MaDonTXL
                              where itemTM.DiaChi.Contains(DiaChi)
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
                                  where itemDon.DiaChi.Contains(DiaChi)
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
                              where itemCTKTXM.DiaChi.Contains(DiaChi)
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
                              where itemCTBamChi.DiaChi.Contains(DiaChi)
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
                              where itemCTDCBD.DiaChi.Contains(DiaChi)
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
                              where itemCTDCHD.DiaChi.Contains(DiaChi)
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
                              where itemCTCTDB.DiaChi.Contains(DiaChi)
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
                              where itemCTCHDB.DiaChi.Contains(DiaChi)
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
                              join itemYCCHDB in db.CHDB_Phieus on itemDon.MaDon equals itemYCCHDB.CHDB.MaDonTBC
                              where itemYCCHDB.DiaChi.Contains(DiaChi)
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

                ///Table TTTL_ChiTiets
                queryDonTBC = from itemDon in db.DonTBCs
                              join itemCTTTTL in db.TTTL_ChiTiets on itemDon.MaDon equals itemCTTTTL.TTTL.MaDonTBC
                              where itemCTTTTL.DiaChi.Contains(DiaChi)
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
                              where itemCTDongNuoc.DiaChi.Contains(DiaChi)
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
                              where itemGL.DiaChi.Contains(DiaChi)
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

                ///Table TruyThu
                queryDonTBC = from itemDon in db.DonTBCs
                              join itemTT in db.TruyThuTienNuoc_ChiTiets on itemDon.MaDon equals itemTT.TruyThuTienNuoc.MaDonTBC
                              where itemTT.DiaChi.Contains(DiaChi)
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

                ///Table ToTrinh
                queryDonTBC = from itemDon in db.DonTBCs
                              join itemCTTT in db.ToTrinh_ChiTiets on itemDon.MaDon equals itemCTTT.ToTrinh.MaDonTBC
                              where itemCTTT.DiaChi.Contains(DiaChi)
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

                ///Table ThuMoi
                queryDonTBC = from itemDon in db.DonTBCs
                              join itemTM in db.ThuMoi_ChiTiets on itemDon.MaDon equals itemTM.ThuMoi.MaDonTBC
                              where itemTM.DiaChi.Contains(DiaChi)
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
                    if (dtDon.Select("MaDon = '" + itemRow["MaDon"] + "'").Count() <= 0)
                        dtDon.ImportRow(itemRow);
                }

                dtDon.DefaultView.Sort = "CreateDate ASC";
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

                if (dtDon.Rows.Count > 0 && dtTruyThu.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Truy Thu", ds.Tables["Don"].Columns["MaDon"], ds.Tables["TruyThu"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtToTrinh.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Tờ Trình", ds.Tables["Don"].Columns["MaDon"], ds.Tables["ToTrinh"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtThuMoi.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Thư Mời", ds.Tables["Don"].Columns["MaDon"], ds.Tables["ThuMoi"].Columns["MaDon"]);

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
