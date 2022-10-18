using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.DAL.BamChi;

namespace KTKS_DonKH.DAL.TimKiem
{
    class CTimKiem : CDAL
    {
        public DataSet GetTienTrinh_DonTu(int MaDon)
        {
            try
            {
                DataSet ds = new DataSet();
                ///Table DonTu
                var queryDon = from itemDon in db.DonTu_ChiTiets
                               where itemDon.MaDon == MaDon
                               select new
                               {
                                   Phong="TV",
                                   MaDon = itemDon.DonTu.DonTu_ChiTiets.Count == 1 ? itemDon.MaDon.Value.ToString() : itemDon.MaDon.Value.ToString() + "." + itemDon.STT.Value.ToString(),
                                   TenLD = itemDon.DonTu.SoCongVan_PhongBanDoi + ": " + itemDon.DonTu.SoCongVan,
                                   itemDon.CreateDate,
                                   itemDon.DanhBo,
                                   itemDon.HoTen,
                                   itemDon.DiaChi,
                                   itemDon.GiaBieu,
                                   itemDon.DinhMuc,
                                   itemDon.DinhMucHN,
                                   NoiDungPKH = itemDon.DonTu.Name_NhomDon_PKH,
                                   NoiDung = itemDon.DonTu.Name_NhomDon,
                                   itemDon.DienThoai,
                                   itemDon.TinhTrang,
                               };
                DataTable dtDon = new DataTable();
                dtDon = LINQToDataTable(queryDon);
                dtDon.TableName = "DonTu";
                ds.Tables.Add(dtDon);

                ///Table CTKTXM
                var queryKTXM = from itemCTKTXM in db.KTXM_ChiTiets
                                join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                where itemCTKTXM.KTXM.MaDonMoi == MaDon
                                orderby itemCTKTXM.NgayKTXM
                                select new
                                {
                                    Phong = "TV",
                                    MaDon = itemCTKTXM.KTXM.DonTu.DonTu_ChiTiets.Count == 1 ? itemCTKTXM.KTXM.MaDonMoi.Value.ToString() : itemCTKTXM.KTXM.MaDonMoi.Value.ToString() + "." + itemCTKTXM.STT.Value.ToString(),
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
                                    itemCTKTXM.BanChinh,
                                };
                DataTable dtKTXM = new DataTable();
                dtKTXM = LINQToDataTable(queryKTXM);
                dtKTXM.TableName = "KTXM";
                ds.Tables.Add(dtKTXM);

                ///Table CTBamChi
                var queryBamChi = from itemCTBamChi in db.BamChi_ChiTiets
                                  join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                                  where itemCTBamChi.BamChi.MaDonMoi == MaDon
                                  orderby itemCTBamChi.NgayBC
                                  select new
                                  {
                                      Phong = "TV",
                                      MaDon = itemCTBamChi.BamChi.DonTu.DonTu_ChiTiets.Count == 1 ? itemCTBamChi.BamChi.MaDonMoi.Value.ToString() : itemCTBamChi.BamChi.MaDonMoi.Value.ToString() + "." + itemCTBamChi.STT.Value.ToString(),
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
                                    orderby itemCTDongNuoc.NgayDN
                                    select new
                                    {
                                        Phong = "TV",
                                        MaDon = itemCTDongNuoc.DongNuoc.DonTu.DonTu_ChiTiets.Count == 1 ? itemCTDongNuoc.DongNuoc.MaDonMoi.Value.ToString() : itemCTDongNuoc.DongNuoc.MaDonMoi.Value.ToString() + "." + itemCTDongNuoc.STT.Value.ToString(),
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
                                  orderby itemCTDCBD.CreateDate
                                  select new
                                  {
                                      Phong = "TV",
                                      MaDon = itemCTDCBD.DCBD.DonTu.DonTu_ChiTiets.Count == 1 ? itemCTDCBD.DCBD.MaDonMoi.Value.ToString() : itemCTDCBD.DCBD.MaDonMoi.Value.ToString() + "." + itemCTDCBD.STT.Value.ToString(),
                                      MaDC = itemCTDCBD.MaCTDCBD,
                                      DieuChinh = "Biến Động",
                                      itemCTDCBD.CreateDate,
                                      itemCTDCBD.ThongTin,
                                      itemCTDCBD.HieuLucKy,
                                      itemCTDCBD.DanhBo,
                                      itemCTDCBD.HoTen_BD,
                                      itemCTDCBD.DiaChi_BD,
                                      itemCTDCBD.MSThue_BD,
                                      itemCTDCBD.GiaBieu_BD,
                                      itemCTDCBD.DinhMuc_BD,
                                      itemCTDCBD.DinhMucHN_BD,
                                      itemCTDCBD.HoTen,
                                      itemCTDCBD.DiaChi,
                                      itemCTDCBD.MSThue,
                                      itemCTDCBD.GiaBieu,
                                      itemCTDCBD.DinhMuc,
                                      itemCTDCBD.DinhMucHN,
                                      CreateBy = itemUser.HoTen,
                                  };
                ///Bảng CTDCHD
                var queryCTDCHD = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                                  join itemUser in db.Users on itemCTDCHD.CreateBy equals itemUser.MaU
                                  where itemCTDCHD.DCBD.MaDonMoi == MaDon
                                  orderby itemCTDCHD.CreateDate
                                  select new
                                  {
                                      Phong = "TV",
                                      MaDon = itemCTDCHD.DCBD.DonTu.DonTu_ChiTiets.Count == 1 ? itemCTDCHD.DCBD.MaDonMoi.Value.ToString() : itemCTDCHD.DCBD.MaDonMoi.Value.ToString() + "." + itemCTDCHD.STT.Value.ToString(),
                                      MaDC = itemCTDCHD.MaCTDCHD,
                                      DieuChinh = "Hóa Đơn",
                                      itemCTDCHD.KyHD,
                                      itemCTDCHD.CreateDate,
                                      itemCTDCHD.DanhBo,
                                      itemCTDCHD.HoTen,
                                      itemCTDCHD.DiaChi,
                                      itemCTDCHD.GiaBieu,
                                      itemCTDCHD.GiaBieu_BD,
                                      itemCTDCHD.DinhMuc,
                                      itemCTDCHD.DinhMuc_BD,
                                      itemCTDCHD.DinhMucHN,
                                      itemCTDCHD.DinhMucHN_BD,
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
                                  orderby itemCTCTDB.CreateDate
                                  select new
                                  {
                                      Phong = "TV",
                                      MaDon = itemCTCTDB.CHDB.DonTu.DonTu_ChiTiets.Count == 1 ? itemCTCTDB.CHDB.MaDonMoi.Value.ToString() : itemCTCTDB.CHDB.MaDonMoi.Value.ToString() + "." + itemCTCTDB.STT.Value.ToString(),
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
                                  orderby itemCTCHDB.CreateDate
                                  select new
                                  {
                                      Phong = "TV",
                                      MaDon = itemCTCHDB.CHDB.DonTu.DonTu_ChiTiets.Count == 1 ? itemCTCHDB.CHDB.MaDonMoi.Value.ToString() : itemCTCHDB.CHDB.MaDonMoi.Value.ToString() + "." + itemCTCHDB.STT.Value.ToString(),
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
                var queryPhieuCHDB = from itemYCCHDB in db.CHDB_Phieus
                                     where itemYCCHDB.CHDB.MaDonMoi == MaDon
                                     orderby itemYCCHDB.CreateDate
                                     select new
                                     {
                                         Phong = "TV",
                                         MaDon = itemYCCHDB.CHDB.DonTu.DonTu_ChiTiets.Count == 1 ? itemYCCHDB.CHDB.MaDonMoi.Value.ToString() : itemYCCHDB.CHDB.MaDonMoi.Value.ToString() + "." + itemYCCHDB.STT.Value.ToString(),
                                         itemYCCHDB.MaYCCHDB,
                                         itemYCCHDB.CreateDate,
                                         itemYCCHDB.DanhBo,
                                         itemYCCHDB.HoTen,
                                         itemYCCHDB.DiaChi,
                                         itemYCCHDB.LyDo,
                                         itemYCCHDB.GhiChuLyDo,
                                         itemYCCHDB.HieuLucKy,
                                     };
                DataTable dtPhieuCHDB = new DataTable();
                dtPhieuCHDB = LINQToDataTable(queryPhieuCHDB);
                dtPhieuCHDB.TableName = "PhieuCHDB";
                ds.Tables.Add(dtPhieuCHDB);

                ///Table CTTTTL
                var queryTTTL = from itemCTTTTL in db.ThuTraLoi_ChiTiets
                                where itemCTTTTL.ThuTraLoi.MaDonMoi == MaDon
                                orderby itemCTTTTL.CreateDate
                                select new
                                {
                                    Phong = "TV",
                                    MaDon = itemCTTTTL.ThuTraLoi.DonTu.DonTu_ChiTiets.Count == 1 ? itemCTTTTL.ThuTraLoi.MaDonMoi.Value.ToString() : itemCTTTTL.ThuTraLoi.MaDonMoi.Value.ToString() + "." + itemCTTTTL.STT.Value.ToString(),
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
                                   where itemGL.GianLan.MaDonMoi == MaDon
                                   orderby itemGL.CreateDate
                                   select new
                                   {
                                       Phong = "TV",
                                       MaDon = itemGL.GianLan.DonTu.DonTu_ChiTiets.Count == 1 ? itemGL.GianLan.MaDonMoi.Value.ToString() : itemGL.GianLan.MaDonMoi.Value.ToString() + "." + itemGL.STT.Value.ToString(),
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
                                   orderby itemTT.CreateDate
                                   select new
                                   {
                                       Phong = "TV",
                                       MaDon = itemTT.TruyThuTienNuoc.DonTu.DonTu_ChiTiets.Count == 1 ? itemTT.TruyThuTienNuoc.MaDonMoi.Value.ToString() : itemTT.TruyThuTienNuoc.MaDonMoi.Value.ToString() + "." + itemTT.STT.Value.ToString(),
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
                                   orderby itemCTTT.CreateDate
                                   select new
                                   {
                                       Phong = "TV",
                                       MaDon = itemCTTT.ToTrinh.DonTu.DonTu_ChiTiets.Count == 1 ? itemCTTT.ToTrinh.MaDonMoi.Value.ToString() : itemCTTT.ToTrinh.MaDonMoi.Value.ToString() + "." + itemCTTT.STT.Value.ToString(),
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
                var queryToTrinh2 = from itemCTTT in db.ToTrinh_ChiTiet_DanhSaches
                                    where itemCTTT.MaDon == MaDon
                                    orderby itemCTTT.CreateDate
                                    select new
                                    {
                                        Phong = "TV",
                                        MaDon = db.DonTu_ChiTiets.Count(itemA => itemA.MaDon == itemCTTT.MaDon) == 1 ? itemCTTT.MaDon.Value.ToString() : itemCTTT.MaDon.Value.ToString() + "." + itemCTTT.STT.Value.ToString(),
                                        itemCTTT.IDCT,
                                        itemCTTT.DanhBo,
                                        itemCTTT.HoTen,
                                        itemCTTT.DiaChi,
                                        itemCTTT.CreateDate,
                                        itemCTTT.ToTrinh_ChiTiet.VeViec,
                                        itemCTTT.ToTrinh_ChiTiet.NoiDung,
                                    };
                dtToTrinh.Merge(LINQToDataTable(queryToTrinh2));
                dtToTrinh.TableName = "ToTrinh";
                ds.Tables.Add(dtToTrinh);

                ///Table ThuMoi
                var queryThuMoi = from item in db.ThuMoi_ChiTiets
                                  where item.ThuMoi.MaDonMoi == MaDon
                                  orderby item.CreateDate
                                  select new
                                  {
                                      Phong = "TV",
                                      MaDon = item.ThuMoi.DonTu.DonTu_ChiTiets.Count == 1 ? item.ThuMoi.MaDonMoi.Value.ToString() : item.ThuMoi.MaDonMoi.Value.ToString() + "." + item.STT.Value.ToString(),
                                      item.IDCT,
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

                ///Table VanBan
                var queryVanBan = from item in db.VanBan_ChiTiets
                                  where item.VanBan.MaDon == MaDon
                                  orderby item.CreateDate
                                  select new
                                  {
                                      Phong = "TV",
                                      MaDon = item.VanBan.DonTu.DonTu_ChiTiets.Count == 1 ? item.VanBan.MaDon.Value.ToString() : item.VanBan.MaDon.Value.ToString() + "." + item.STT.Value.ToString(),
                                      item.IDCT,
                                      item.DanhBo,
                                      item.HoTen,
                                      item.DiaChi,
                                      item.CreateDate,
                                      item.VeViec,
                                      item.NoiDung,
                                  };
                DataTable dtVanBan = new DataTable();
                dtVanBan = LINQToDataTable(queryVanBan);
                dtVanBan.TableName = "VanBan";
                ds.Tables.Add(dtVanBan);

                //Table TienTrinh
                var queryTienTrinh = from item in db.DonTu_LichSus
                                     where item.MaDon == MaDon
                                     orderby item.NgayChuyen descending, item.ID descending
                                     select new
                                     {
                                         Phong = "TV",
                                         MaDon = item.DonTu.DonTu_ChiTiets.Count == 1 ? item.MaDon.Value.ToString() : item.MaDon.Value.ToString() + "." + item.STT.Value.ToString(),
                                         item.NgayChuyen,
                                         item.NoiChuyen,
                                         item.NoiNhan,
                                         item.KTXM,
                                         item.NoiDung,
                                         CreateBy = db.Users.SingleOrDefault(itemA => itemA.MaU == item.CreateBy).HoTen,
                                     };
                DataTable dtTienTrinh = new DataTable();
                dtTienTrinh = LINQToDataTable(queryTienTrinh);
                dtTienTrinh.TableName = "TienTrinh";
                ds.Tables.Add(dtTienTrinh);

                if (dtDon.Rows.Count > 0 && dtKTXM.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Kiểm Tra Xác Minh", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["KTXM"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtBamChi.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Bấm Chì", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["BamChi"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtDongNuoc.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Đóng Nước", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["DongNuoc"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtDCBD.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Điều Chỉnh Biến Động", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["DCBD"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtCHDB.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Cắt Tạm/Hủy Danh Bộ", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["CHDB"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtPhieuCHDB.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Phiếu Hủy Danh Bộ", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["PhieuCHDB"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtTTTL.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["ThuTraLoi"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtGianLan.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Gian Lận", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["GianLan"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtTruyThu.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Truy Thu", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["TruyThu"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtToTrinh.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Tờ Trình", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["ToTrinh"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtThuMoi.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Thư Mời", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["ThuMoi"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtVanBan.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Văn Bản", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["VanBan"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtTienTrinh.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Tiến Trình", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["TienTrinh"].Columns["MaDon"]);

                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataSet GetTienTrinh_DonTu(int MaDon, int STT)
        {
            try
            {
                DataSet ds = new DataSet();
                ///Table DonTu
                var queryDon = from itemDon in db.DonTu_ChiTiets
                               where itemDon.MaDon == MaDon && itemDon.STT == STT
                               select new
                               {
                                   Phong = "TV",
                                   MaDon = itemDon.MaDon.Value.ToString() + "." + itemDon.STT.Value.ToString(),
                                   TenLD = itemDon.DonTu.SoCongVan_PhongBanDoi + ": " + itemDon.DonTu.SoCongVan,
                                   itemDon.CreateDate,
                                   itemDon.DanhBo,
                                   itemDon.HoTen,
                                   itemDon.DiaChi,
                                   itemDon.GiaBieu,
                                   itemDon.DinhMuc,
                                   itemDon.DinhMucHN,
                                   NoiDungPKH = itemDon.DonTu.Name_NhomDon_PKH,
                                   NoiDung = itemDon.DonTu.Name_NhomDon,
                                   itemDon.DienThoai,
                                   itemDon.TinhTrang,
                               };
                DataTable dtDon = new DataTable();
                dtDon = LINQToDataTable(queryDon);
                dtDon.TableName = "DonTu";
                ds.Tables.Add(dtDon);

                ///Table CTKTXM
                var queryKTXM = from itemCTKTXM in db.KTXM_ChiTiets
                                join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
                                where itemCTKTXM.KTXM.MaDonMoi == MaDon && itemCTKTXM.STT == STT
                                orderby itemCTKTXM.NgayKTXM
                                select new
                                {
                                    Phong = "TV",
                                    MaDon = itemCTKTXM.KTXM.MaDonMoi.Value.ToString() + "." + itemCTKTXM.STT.Value.ToString(),
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
                                    itemCTKTXM.BanChinh,
                                };
                DataTable dtKTXM = new DataTable();
                dtKTXM = LINQToDataTable(queryKTXM);
                dtKTXM.TableName = "KTXM";
                ds.Tables.Add(dtKTXM);

                ///Table CTBamChi
                var queryBamChi = from itemCTBamChi in db.BamChi_ChiTiets
                                  join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
                                  where itemCTBamChi.BamChi.MaDonMoi == MaDon && itemCTBamChi.STT == STT
                                  orderby itemCTBamChi.NgayBC
                                  select new
                                  {
                                      Phong = "TV",
                                      MaDon = itemCTBamChi.BamChi.MaDonMoi.Value.ToString() + "." + itemCTBamChi.STT.Value.ToString(),
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
                                    where itemCTDongNuoc.DongNuoc.MaDonMoi == MaDon && itemCTDongNuoc.STT == STT
                                    orderby itemCTDongNuoc.NgayDN
                                    select new
                                    {
                                        Phong = "TV",
                                        MaDon = itemCTDongNuoc.DongNuoc.MaDonMoi.Value.ToString() + "." + itemCTDongNuoc.STT.Value.ToString(),
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
                                  where itemCTDCBD.DCBD.MaDonMoi == MaDon && itemCTDCBD.STT == STT
                                  orderby itemCTDCBD.CreateDate
                                  select new
                                  {
                                      Phong = "TV",
                                      MaDon = itemCTDCBD.DCBD.MaDonMoi.Value.ToString() + "." + itemCTDCBD.STT.Value.ToString(),
                                      MaDC = itemCTDCBD.MaCTDCBD,
                                      DieuChinh = "Biến Động",
                                      itemCTDCBD.CreateDate,
                                      itemCTDCBD.ThongTin,
                                      itemCTDCBD.HieuLucKy,
                                      itemCTDCBD.DanhBo,
                                      itemCTDCBD.HoTen_BD,
                                      itemCTDCBD.DiaChi_BD,
                                      itemCTDCBD.MSThue_BD,
                                      itemCTDCBD.GiaBieu_BD,
                                      itemCTDCBD.DinhMuc_BD,
                                      itemCTDCBD.DinhMucHN_BD,
                                      itemCTDCBD.HoTen,
                                      itemCTDCBD.DiaChi,
                                      itemCTDCBD.MSThue,
                                      itemCTDCBD.GiaBieu,
                                      itemCTDCBD.DinhMuc,
                                      itemCTDCBD.DinhMucHN,
                                      CreateBy = itemUser.HoTen,
                                  };
                ///Bảng CTDCHD
                var queryCTDCHD = from itemCTDCHD in db.DCBD_ChiTietHoaDons
                                  join itemUser in db.Users on itemCTDCHD.CreateBy equals itemUser.MaU
                                  where itemCTDCHD.DCBD.MaDonMoi == MaDon && itemCTDCHD.STT == STT
                                  orderby itemCTDCHD.CreateDate
                                  select new
                                  {
                                      Phong = "TV",
                                      MaDon = itemCTDCHD.DCBD.MaDonMoi.Value.ToString() + "." + itemCTDCHD.STT.Value.ToString(),
                                      MaDC = itemCTDCHD.MaCTDCHD,
                                      DieuChinh = "Hóa Đơn",
                                      itemCTDCHD.KyHD,
                                      itemCTDCHD.CreateDate,
                                      itemCTDCHD.DanhBo,
                                      itemCTDCHD.HoTen,
                                      itemCTDCHD.DiaChi,
                                      itemCTDCHD.GiaBieu,
                                      itemCTDCHD.GiaBieu_BD,
                                      itemCTDCHD.DinhMuc,
                                      itemCTDCHD.DinhMuc_BD,
                                      itemCTDCHD.DinhMucHN,
                                      itemCTDCHD.DinhMucHN_BD,
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
                                  where itemCTCTDB.CHDB.MaDonMoi == MaDon && itemCTCTDB.STT == STT
                                  orderby itemCTCTDB.CreateDate
                                  select new
                                  {
                                      Phong = "TV",
                                      MaDon = itemCTCTDB.CHDB.MaDonMoi.Value.ToString() + "." + itemCTCTDB.STT.Value.ToString(),
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
                                  where itemCTCHDB.CHDB.MaDonMoi == MaDon && itemCTCHDB.STT == STT
                                  orderby itemCTCHDB.CreateDate
                                  select new
                                  {
                                      Phong = "TV",
                                      MaDon = itemCTCHDB.CHDB.MaDonMoi.Value.ToString() + "." + itemCTCHDB.STT.Value.ToString(),
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
                var queryPhieuCHDB = from itemYCCHDB in db.CHDB_Phieus
                                     where itemYCCHDB.CHDB.MaDonMoi == MaDon && itemYCCHDB.STT == STT
                                     orderby itemYCCHDB.CreateDate
                                     select new
                                     {
                                         Phong = "TV",
                                         MaDon = itemYCCHDB.CHDB.MaDonMoi.Value.ToString() + "." + itemYCCHDB.STT.Value.ToString(),
                                         itemYCCHDB.MaYCCHDB,
                                         itemYCCHDB.CreateDate,
                                         itemYCCHDB.DanhBo,
                                         itemYCCHDB.HoTen,
                                         itemYCCHDB.DiaChi,
                                         itemYCCHDB.LyDo,
                                         itemYCCHDB.GhiChuLyDo,
                                         itemYCCHDB.HieuLucKy,
                                     };
                DataTable dtPhieuCHDB = new DataTable();
                dtPhieuCHDB = LINQToDataTable(queryPhieuCHDB);
                dtPhieuCHDB.TableName = "PhieuCHDB";
                ds.Tables.Add(dtPhieuCHDB);

                ///Table CTTTTL
                var queryTTTL = from itemCTTTTL in db.ThuTraLoi_ChiTiets
                                where itemCTTTTL.ThuTraLoi.MaDonMoi == MaDon && itemCTTTTL.STT == STT
                                orderby itemCTTTTL.CreateDate
                                select new
                                {
                                    Phong = "TV",
                                    MaDon = itemCTTTTL.ThuTraLoi.MaDonMoi.Value.ToString() + "." + itemCTTTTL.STT.Value.ToString(),
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
                                   where itemGL.GianLan.MaDonMoi == MaDon && itemGL.STT == STT
                                   orderby itemGL.CreateDate
                                   select new
                                   {
                                       Phong = "TV",
                                       MaDon = itemGL.GianLan.MaDonMoi.Value.ToString() + "." + itemGL.STT.Value.ToString(),
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
                                   where itemTT.TruyThuTienNuoc.MaDonMoi == MaDon && itemTT.STT == STT
                                   orderby itemTT.CreateDate
                                   select new
                                   {
                                       Phong = "TV",
                                       MaDon = itemTT.TruyThuTienNuoc.MaDonMoi.Value.ToString() + "." + itemTT.STT.Value.ToString(),
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
                                   where itemCTTT.ToTrinh.MaDonMoi == MaDon && itemCTTT.STT == STT
                                   orderby itemCTTT.CreateDate
                                   select new
                                   {
                                       Phong = "TV",
                                       MaDon = itemCTTT.ToTrinh.MaDonMoi.Value.ToString() + "." + itemCTTT.STT.Value.ToString(),
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
                var queryToTrinh2 = from itemCTTT in db.ToTrinh_ChiTiet_DanhSaches
                                    where itemCTTT.MaDon == MaDon && itemCTTT.STT == STT
                                    orderby itemCTTT.CreateDate
                                    select new
                                    {
                                        Phong = "TV",
                                        MaDon = itemCTTT.MaDon.Value.ToString() + "." + itemCTTT.STT.Value.ToString(),
                                        itemCTTT.IDCT,
                                        itemCTTT.DanhBo,
                                        itemCTTT.HoTen,
                                        itemCTTT.DiaChi,
                                        itemCTTT.CreateDate,
                                        itemCTTT.ToTrinh_ChiTiet.VeViec,
                                        itemCTTT.ToTrinh_ChiTiet.NoiDung,
                                    };
                dtToTrinh.Merge(LINQToDataTable(queryToTrinh2));

                dtToTrinh.TableName = "ToTrinh";
                ds.Tables.Add(dtToTrinh);

                ///Table ThuMoi
                var queryThuMoi = from item in db.ThuMoi_ChiTiets
                                  where item.ThuMoi.MaDonMoi == MaDon && item.STT == STT
                                  orderby item.CreateDate
                                  select new
                                  {
                                      Phong = "TV",
                                      MaDon = item.ThuMoi.MaDonMoi.Value.ToString() + "." + item.STT.Value.ToString(),
                                      item.IDCT,
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

                ///Table VanBan
                var queryVanBan = from item in db.VanBan_ChiTiets
                                  where item.VanBan.MaDon == MaDon && item.STT == STT
                                  orderby item.CreateDate
                                  select new
                                  {
                                      Phong = "TV",
                                      MaDon = item.VanBan.MaDon.Value.ToString() + "." + item.STT.Value.ToString(),
                                      item.IDCT,
                                      item.DanhBo,
                                      item.HoTen,
                                      item.DiaChi,
                                      item.CreateDate,
                                      item.VeViec,
                                      item.NoiDung,
                                  };
                DataTable dtVanBan = new DataTable();
                dtVanBan = LINQToDataTable(queryVanBan);
                dtVanBan.TableName = "VanBan";
                ds.Tables.Add(dtVanBan);

                //Table TienTrinh
                var queryTienTrinh = from item in db.DonTu_LichSus
                                     where item.MaDon == MaDon && item.STT == STT
                                     orderby item.NgayChuyen descending, item.ID descending
                                     select new
                                     {
                                         Phong = "TV",
                                         MaDon = item.MaDon.Value.ToString() + "." + item.STT.Value.ToString(),
                                         item.NgayChuyen,
                                         item.NoiChuyen,
                                         item.NoiNhan,
                                         item.KTXM,
                                         item.NoiDung,
                                         CreateBy = db.Users.SingleOrDefault(itemA => itemA.MaU == item.CreateBy).HoTen,
                                     };
                DataTable dtTienTrinh = new DataTable();
                dtTienTrinh = LINQToDataTable(queryTienTrinh);
                dtTienTrinh.TableName = "TienTrinh";
                ds.Tables.Add(dtTienTrinh);

                if (dtDon.Rows.Count > 0 && dtKTXM.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Kiểm Tra Xác Minh", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["KTXM"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtBamChi.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Bấm Chì", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["BamChi"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtDongNuoc.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Đóng Nước", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["DongNuoc"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtDCBD.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Điều Chỉnh Biến Động", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["DCBD"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtCHDB.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Cắt Tạm/Hủy Danh Bộ", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["CHDB"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtPhieuCHDB.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Phiếu Hủy Danh Bộ", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["PhieuCHDB"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtTTTL.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["ThuTraLoi"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtGianLan.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Gian Lận", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["GianLan"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtTruyThu.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Truy Thu", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["TruyThu"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtToTrinh.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Tờ Trình", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["ToTrinh"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtThuMoi.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Thư Mời", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["ThuMoi"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtVanBan.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Văn Bản", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["VanBan"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtTienTrinh.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Tiến Trình", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["TienTrinh"].Columns["MaDon"]);

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
                                   itemDon.DinhMucHN,
                                   itemDon.NoiDung,
                                   itemDon.DienThoai,
                               };
                DataTable dtDon = new DataTable();
                dtDon = LINQToDataTable(queryDon);
                dtDon.TableName = "DonTu";
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
                                    itemCTKTXM.BanChinh
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
                                      itemCTDCBD.HieuLucKy,
                                      itemCTDCBD.DanhBo,
                                      itemCTDCBD.HoTen_BD,
                                      itemCTDCBD.DiaChi_BD,
                                      itemCTDCBD.MSThue_BD,
                                      itemCTDCBD.GiaBieu_BD,
                                      itemCTDCBD.DinhMuc_BD,
                                      itemCTDCBD.DinhMucHN_BD,
                                      itemCTDCBD.HoTen,
                                      itemCTDCBD.DiaChi,
                                      itemCTDCBD.MSThue,
                                      itemCTDCBD.GiaBieu,
                                      itemCTDCBD.DinhMuc,
                                      itemCTDCBD.DinhMucHN,
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
                                      itemCTDCHD.KyHD,
                                      itemCTDCHD.CreateDate,
                                      itemCTDCHD.DanhBo,
                                      itemCTDCHD.HoTen,
                                      itemCTDCHD.DiaChi,
                                      itemCTDCHD.GiaBieu,
                                      itemCTDCHD.GiaBieu_BD,
                                      itemCTDCHD.DinhMuc,
                                      itemCTDCHD.DinhMuc_BD,
                                      itemCTDCHD.DinhMucHN,
                                      itemCTDCHD.DinhMucHN_BD,
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
                var queryPhieuCHDB = from itemYCCHDB in db.CHDB_Phieus
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
                DataTable dtPhieuCHDB = new DataTable();
                dtPhieuCHDB = LINQToDataTable(queryPhieuCHDB);
                dtPhieuCHDB.TableName = "PhieuCHDB";
                ds.Tables.Add(dtPhieuCHDB);

                ///Table CTTTTL
                var queryTTTL = from itemCTTTTL in db.ThuTraLoi_ChiTiets
                                where itemCTTTTL.ThuTraLoi.MaDon == MaDon
                                select new
                                {
                                    MaDon = "TKH" + itemCTTTTL.ThuTraLoi.MaDon,
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
                    ds.Relations.Add("Chi Tiết Kiểm Tra Xác Minh", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["KTXM"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtBamChi.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Bấm Chì", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["BamChi"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtDongNuoc.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Đóng Nước", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["DongNuoc"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtDCBD.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Điều Chỉnh Biến Động", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["DCBD"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtCHDB.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Cắt Tạm/Hủy Danh Bộ", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["CHDB"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtPhieuCHDB.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Phiếu Hủy Danh Bộ", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["PhieuCHDB"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtTTTL.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["ThuTraLoi"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtGianLan.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Gian Lận", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["GianLan"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtTruyThu.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Truy Thu", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["TruyThu"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtToTrinh.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Tờ Trình", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["ToTrinh"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtThuMoi.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Thư Mời", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["ThuMoi"].Columns["MaDon"]);

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
                                   itemDonTXL.DinhMucHN,
                                   itemDonTXL.NoiDung,
                                   itemDonTXL.DienThoai,
                               };
                DataTable dtDon = new DataTable();
                dtDon = LINQToDataTable(queryDon);
                dtDon.TableName = "DonTu";
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
                                    itemCTKTXM.BanChinh,
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
                                      itemCTDCBD.HieuLucKy,
                                      itemCTDCBD.DanhBo,
                                      itemCTDCBD.HoTen_BD,
                                      itemCTDCBD.DiaChi_BD,
                                      itemCTDCBD.MSThue_BD,
                                      itemCTDCBD.GiaBieu_BD,
                                      itemCTDCBD.DinhMuc_BD,
                                      itemCTDCBD.DinhMucHN_BD,
                                      itemCTDCBD.HoTen,
                                      itemCTDCBD.DiaChi,
                                      itemCTDCBD.MSThue,
                                      itemCTDCBD.GiaBieu,
                                      itemCTDCBD.DinhMuc,
                                      itemCTDCBD.DinhMucHN,
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
                                      itemCTDCHD.KyHD,
                                      itemCTDCHD.CreateDate,
                                      itemCTDCHD.DanhBo,
                                      itemCTDCHD.HoTen,
                                      itemCTDCHD.DiaChi,
                                      itemCTDCHD.GiaBieu,
                                      itemCTDCHD.GiaBieu_BD,
                                      itemCTDCHD.DinhMuc,
                                      itemCTDCHD.DinhMuc_BD,
                                      itemCTDCHD.DinhMucHN,
                                      itemCTDCHD.DinhMucHN_BD,
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
                var queryPhieuCHDB = from itemYCCHDB in db.CHDB_Phieus
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
                DataTable dtPhieuCHDB = new DataTable();
                dtPhieuCHDB = LINQToDataTable(queryPhieuCHDB);
                dtPhieuCHDB.TableName = "PhieuCHDB";
                ds.Tables.Add(dtPhieuCHDB);

                ///Table CTTTTL
                var queryTTTL = from itemCTTTTL in db.ThuTraLoi_ChiTiets
                                where itemCTTTTL.ThuTraLoi.MaDonTXL == MaDonTXL
                                select new
                                {
                                    MaDon = "TXL" + itemCTTTTL.ThuTraLoi.MaDonTXL,
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
                    ds.Relations.Add("Chi Tiết Kiểm Tra Xác Minh", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["KTXM"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtBamChi.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Bấm Chì", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["BamChi"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtDongNuoc.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Đóng Nước", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["DongNuoc"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtDCBD.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Điều Chỉnh Biến Động", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["DCBD"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtCHDB.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Cắt Tạm/Hủy Danh Bộ", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["CHDB"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtPhieuCHDB.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Phiếu Hủy Danh Bộ", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["PhieuCHDB"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtTTTL.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["ThuTraLoi"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtGianLan.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Gian Lận", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["GianLan"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtTruyThu.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Truy Thu", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["TruyThu"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtToTrinh.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Tờ Trình", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["ToTrinh"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtThuMoi.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Thư Mời", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["ThuMoi"].Columns["MaDon"]);

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
                                   itemDon.DinhMucHN,
                                   itemDon.NoiDung,
                                   itemDon.DienThoai,
                               };
                DataTable dtDon = new DataTable();
                dtDon = LINQToDataTable(queryDon);
                dtDon.TableName = "DonTu";
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
                                    itemCTKTXM.BanChinh,
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
                                      itemCTDCBD.HieuLucKy,
                                      itemCTDCBD.DanhBo,
                                      itemCTDCBD.HoTen_BD,
                                      itemCTDCBD.DiaChi_BD,
                                      itemCTDCBD.MSThue_BD,
                                      itemCTDCBD.GiaBieu_BD,
                                      itemCTDCBD.DinhMuc_BD,
                                      itemCTDCBD.DinhMucHN_BD,
                                      itemCTDCBD.HoTen,
                                      itemCTDCBD.DiaChi,
                                      itemCTDCBD.MSThue,
                                      itemCTDCBD.GiaBieu,
                                      itemCTDCBD.DinhMuc,
                                      itemCTDCBD.DinhMucHN,
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
                                      itemCTDCHD.KyHD,
                                      itemCTDCHD.CreateDate,
                                      itemCTDCHD.DanhBo,
                                      itemCTDCHD.HoTen,
                                      itemCTDCHD.DiaChi,
                                      itemCTDCHD.GiaBieu,
                                      itemCTDCHD.GiaBieu_BD,
                                      itemCTDCHD.DinhMuc,
                                      itemCTDCHD.DinhMuc_BD,
                                      itemCTDCHD.DinhMucHN,
                                      itemCTDCHD.DinhMucHN_BD,
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
                var queryPhieuCHDB = from itemYCCHDB in db.CHDB_Phieus
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
                DataTable dtPhieuCHDB = new DataTable();
                dtPhieuCHDB = LINQToDataTable(queryPhieuCHDB);
                dtPhieuCHDB.TableName = "PhieuCHDB";
                ds.Tables.Add(dtPhieuCHDB);

                ///Table CTTTTL
                var queryTTTL = from itemCTTTTL in db.ThuTraLoi_ChiTiets
                                where itemCTTTTL.ThuTraLoi.MaDonTBC == MaDonTBC
                                select new
                                {
                                    MaDon = "TBC" + itemCTTTTL.ThuTraLoi.MaDonTBC,
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
                    ds.Relations.Add("Chi Tiết Kiểm Tra Xác Minh", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["KTXM"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtBamChi.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Bấm Chì", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["BamChi"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtDongNuoc.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Đóng Nước", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["DongNuoc"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtDCBD.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Điều Chỉnh Biến Động", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["DCBD"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtCHDB.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Cắt Tạm/Hủy Danh Bộ", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["CHDB"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtPhieuCHDB.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Phiếu Hủy Danh Bộ", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["PhieuCHDB"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtTTTL.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["ThuTraLoi"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtGianLan.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Gian Lận", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["GianLan"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtTruyThu.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Truy Thu", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["TruyThu"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtToTrinh.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Tờ Trình", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["ToTrinh"].Columns["MaDon"]);

                if (dtDon.Rows.Count > 0 && dtThuMoi.Rows.Count > 0)
                    ds.Relations.Add("Chi Tiết Thư Mời", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["ThuMoi"].Columns["MaDon"]);

                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //Vì lý do tìm theo Danh Bộ, Họ Tên, Địa Chỉ phải tìm Con trước, Cha sau nên tìm đơn sau cùng

        #region

        //public DataSet GetTienTrinhByDanhBo(string DanhBo)
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();

        //        #region DanhBo
        //        ///trường hợp đơn danh bộ cần tìm kiếm nhưng lại xử lý danh bộ khác
        //        ///Table CTKTXM
        //        var queryKTXM = from itemCTKTXM in db.KTXM_ChiTiets
        //                        join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
        //                        where itemCTKTXM.DanhBo == DanhBo || (itemCTKTXM.KTXM.DonKH.DanhBo == DanhBo || itemCTKTXM.KTXM.DonTXL.DanhBo == DanhBo || itemCTKTXM.KTXM.DonTBC.DanhBo == DanhBo)
        //                        select new
        //                        {
        //                            MaDon = itemCTKTXM.KTXM.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTKTXM.KTXM.MaDonMoi).Count() == 1 ? itemCTKTXM.KTXM.MaDonMoi.Value.ToString() : itemCTKTXM.KTXM.MaDonMoi + "." + itemCTKTXM.STT
        //                            : itemCTKTXM.KTXM.MaDon != null ? "TKH" + itemCTKTXM.KTXM.MaDon
        //                            : itemCTKTXM.KTXM.MaDonTXL != null ? "TXL" + itemCTKTXM.KTXM.MaDonTXL
        //                            : itemCTKTXM.KTXM.MaDonTBC != null ? "TBC" + itemCTKTXM.KTXM.MaDonTBC : null,
        //                            itemCTKTXM.MaCTKTXM,
        //                            itemCTKTXM.NgayKTXM,
        //                            itemCTKTXM.DanhBo,
        //                            itemCTKTXM.HoTen,
        //                            itemCTKTXM.DiaChi,
        //                            itemCTKTXM.NoiDungKiemTra,
        //                            CreateBy = itemUser.HoTen,
        //                            itemCTKTXM.NoiDungDongTien,
        //                            itemCTKTXM.NgayDongTien,
        //                            itemCTKTXM.SoTienDongTien,itemCTKTXM.BanChinh,
        //                        };
        //        DataTable dtKTXM = new DataTable();
        //        dtKTXM = LINQToDataTable(queryKTXM);
        //        dtKTXM.TableName = "KTXM";
        //        ds.Tables.Add(dtKTXM);

        //        ///Table CTBamChi
        //        var queryBamChi = from itemCTBamChi in db.BamChi_ChiTiets
        //                          join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
        //                          where itemCTBamChi.DanhBo == DanhBo || (itemCTBamChi.BamChi.DonKH.DanhBo == DanhBo || itemCTBamChi.BamChi.DonTXL.DanhBo == DanhBo || itemCTBamChi.BamChi.DonTBC.DanhBo == DanhBo)
        //                          select new
        //                          {
        //                              MaDon = itemCTBamChi.BamChi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTBamChi.BamChi.MaDonMoi).Count() == 1 ? itemCTBamChi.BamChi.MaDonMoi.Value.ToString() : itemCTBamChi.BamChi.MaDonMoi + "." + itemCTBamChi.STT
        //                              : itemCTBamChi.BamChi.MaDon != null ? "TKH" + itemCTBamChi.BamChi.MaDon
        //                              : itemCTBamChi.BamChi.MaDonTXL != null ? "TXL" + itemCTBamChi.BamChi.MaDonTXL
        //                              : itemCTBamChi.BamChi.MaDonTBC != null ? "TBC" + itemCTBamChi.BamChi.MaDonTBC : null,
        //                              itemCTBamChi.MaCTBC,
        //                              itemCTBamChi.NgayBC,
        //                              itemCTBamChi.DanhBo,
        //                              itemCTBamChi.HoTen,
        //                              itemCTBamChi.DiaChi,
        //                              itemCTBamChi.TrangThaiBC,
        //                              itemCTBamChi.TheoYeuCau,
        //                              itemCTBamChi.MaSoBC,
        //                              CreateBy = itemUser.HoTen,
        //                          };

        //        DataTable dtBamChi = new DataTable();
        //        dtBamChi = LINQToDataTable(queryBamChi);
        //        dtBamChi.TableName = "BamChi";
        //        ds.Tables.Add(dtBamChi);

        //        ///Table CTDongNuoc
        //        var queryDongNuoc = from itemCTDongNuoc in db.DongNuoc_ChiTiets
        //                            join itemUser in db.Users on itemCTDongNuoc.CreateBy equals itemUser.MaU
        //                            where itemCTDongNuoc.DanhBo == DanhBo || (itemCTDongNuoc.DongNuoc.DonKH.DanhBo == DanhBo || itemCTDongNuoc.DongNuoc.DonTXL.DanhBo == DanhBo || itemCTDongNuoc.DongNuoc.DonTBC.DanhBo == DanhBo)
        //                            select new
        //                            {
        //                                MaDon = itemCTDongNuoc.DongNuoc.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTDongNuoc.DongNuoc.MaDonMoi).Count() == 1 ? itemCTDongNuoc.DongNuoc.MaDonMoi.Value.ToString() : itemCTDongNuoc.DongNuoc.MaDonMoi + "." + itemCTDongNuoc.STT
        //                                : itemCTDongNuoc.DongNuoc.MaDon != null ? "TKH" + itemCTDongNuoc.DongNuoc.MaDon
        //                                : itemCTDongNuoc.DongNuoc.MaDonTXL != null ? "TXL" + itemCTDongNuoc.DongNuoc.MaDonTXL
        //                                : itemCTDongNuoc.DongNuoc.MaDonTBC != null ? "TBC" + itemCTDongNuoc.DongNuoc.MaDonTBC : null,
        //                                itemCTDongNuoc.MaCTDN,
        //                                itemCTDongNuoc.NgayDN,
        //                                itemCTDongNuoc.DanhBo,
        //                                itemCTDongNuoc.HoTen,
        //                                itemCTDongNuoc.DiaChi,
        //                                itemCTDongNuoc.MaCTMN,
        //                                itemCTDongNuoc.NgayMN,
        //                                CreateBy = itemUser.HoTen,
        //                            };

        //        DataTable dtDongNuoc = new DataTable();
        //        dtDongNuoc = LINQToDataTable(queryDongNuoc);
        //        dtDongNuoc.TableName = "DongNuoc";
        //        ds.Tables.Add(dtDongNuoc);

        //        ///Table CTDCBD
        //        var queryCTDCBD = from itemCTDCBD in db.DCBD_ChiTietBienDongs
        //                          join itemUser in db.Users on itemCTDCBD.CreateBy equals itemUser.MaU
        //                          where itemCTDCBD.DanhBo == DanhBo || (itemCTDCBD.DCBD.DonKH.DanhBo == DanhBo || itemCTDCBD.DCBD.DonTXL.DanhBo == DanhBo || itemCTDCBD.DCBD.DonTBC.DanhBo == DanhBo)
        //                          select new
        //                          {
        //                              MaDon = itemCTDCBD.DCBD.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTDCBD.DCBD.MaDonMoi).Count() == 1 ? itemCTDCBD.DCBD.MaDonMoi.Value.ToString() : itemCTDCBD.DCBD.MaDonMoi + "." + itemCTDCBD.STT
        //                              : itemCTDCBD.DCBD.MaDon != null ? "TKH" + itemCTDCBD.DCBD.MaDon
        //                              : itemCTDCBD.DCBD.MaDonTXL != null ? "TXL" + itemCTDCBD.DCBD.MaDonTXL
        //                              : itemCTDCBD.DCBD.MaDonTBC != null ? "TBC" + itemCTDCBD.DCBD.MaDonTBC : null,
        //                              MaDC = itemCTDCBD.MaCTDCBD,
        //                              DieuChinh = "Biến Động",
        //                              itemCTDCBD.CreateDate,
        //                              itemCTDCBD.DanhBo,
        //                              itemCTDCBD.HoTen_BD,
        //                              itemCTDCBD.DiaChi_BD,
        //                              itemCTDCBD.MSThue_BD,
        //                              itemCTDCBD.GiaBieu_BD,
        //                              itemCTDCBD.DinhMuc_BD,
        //                              itemCTDCBD.HoTen,
        //                              itemCTDCBD.DiaChi,
        //                              itemCTDCBD.MSThue,
        //                              itemCTDCBD.GiaBieu,
        //                              itemCTDCBD.DinhMuc,
        //                              rowextra = "",
        //                              itemCTDCBD.ThongTin,
        //                              CreateBy = itemUser.HoTen,
        //                          };

        //        ///Bảng CTDCHD
        //        var queryCTDCHD = from itemCTDCHD in db.DCBD_ChiTietHoaDons
        //                          join itemUser in db.Users on itemCTDCHD.CreateBy equals itemUser.MaU
        //                          where itemCTDCHD.DanhBo == DanhBo || (itemCTDCHD.DCBD.DonKH.DanhBo == DanhBo || itemCTDCHD.DCBD.DonTXL.DanhBo == DanhBo || itemCTDCHD.DCBD.DonTBC.DanhBo == DanhBo)
        //                          select new
        //                          {
        //                              MaDon = itemCTDCHD.DCBD.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTDCHD.DCBD.MaDonMoi).Count() == 1 ? itemCTDCHD.DCBD.MaDonMoi.Value.ToString() : itemCTDCHD.DCBD.MaDonMoi + "." + itemCTDCHD.STT
        //                              : itemCTDCHD.DCBD.MaDon != null ? "TKH" + itemCTDCHD.DCBD.MaDon
        //                              : itemCTDCHD.DCBD.MaDonTXL != null ? "TXL" + itemCTDCHD.DCBD.MaDonTXL
        //                              : itemCTDCHD.DCBD.MaDonTBC != null ? "TBC" + itemCTDCHD.DCBD.MaDonTBC : null,
        //                              MaDC = itemCTDCHD.MaCTDCHD,
        //                              DieuChinh = "Hóa Đơn",
        //                              itemCTDCHD.CreateDate,
        //                              itemCTDCHD.DanhBo,
        //                              itemCTDCHD.HoTen,
        //                              itemCTDCHD.DiaChi,
        //                              itemCTDCHD.GiaBieu,
        //                              itemCTDCHD.GiaBieu_BD,
        //                              itemCTDCHD.DinhMuc,
        //                              itemCTDCHD.DinhMuc_BD,
        //                              itemCTDCHD.TieuThu,
        //                              itemCTDCHD.TieuThu_BD,
        //                              itemCTDCHD.TongCong_Start,
        //                              itemCTDCHD.TongCong_End,
        //                              itemCTDCHD.TongCong_BD,
        //                              itemCTDCHD.TangGiam,
        //                              CreateBy = itemUser.HoTen,
        //                          };
        //        DataTable dtDCBD = new DataTable();
        //        dtDCBD = LINQToDataTable(queryCTDCBD);
        //        dtDCBD.Merge(LINQToDataTable(queryCTDCHD));
        //        dtDCBD.TableName = "DCBD";
        //        ds.Tables.Add(dtDCBD);

        //        ///Table CTCTDB
        //        var queryCTCTDB = from itemCTCTDB in db.CHDB_ChiTietCatTams
        //                          where itemCTCTDB.DanhBo == DanhBo || (itemCTCTDB.CHDB.DonKH.DanhBo == DanhBo || itemCTCTDB.CHDB.DonTXL.DanhBo == DanhBo || itemCTCTDB.CHDB.DonTBC.DanhBo == DanhBo)
        //                          select new
        //                          {
        //                              MaDon = itemCTCTDB.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTCTDB.CHDB.MaDonMoi).Count() == 1 ? itemCTCTDB.CHDB.MaDonMoi.Value.ToString() : itemCTCTDB.CHDB.MaDonMoi + "." + itemCTCTDB.STT
        //                              : itemCTCTDB.CHDB.MaDon != null ? "TKH" + itemCTCTDB.CHDB.MaDon
        //                              : itemCTCTDB.CHDB.MaDonTXL != null ? "TXL" + itemCTCTDB.CHDB.MaDonTXL
        //                              : itemCTCTDB.CHDB.MaDonTBC != null ? "TBC" + itemCTCTDB.CHDB.MaDonTBC : null,
        //                              MaCH = itemCTCTDB.MaCTCTDB,
        //                              LoaiCat = "Cắt Tạm",
        //                              itemCTCTDB.CreateDate,
        //                              itemCTCTDB.DanhBo,
        //                              itemCTCTDB.HoTen,
        //                              itemCTCTDB.DiaChi,
        //                              itemCTCTDB.LyDo,
        //                              itemCTCTDB.GhiChuLyDo,
        //                              itemCTCTDB.DaLapPhieu,
        //                              itemCTCTDB.SoPhieu,
        //                              itemCTCTDB.NgayLapPhieu,
        //                          };

        //        ///Table CHDB_ChiTietCatHuy
        //        var queryCTCHDB = from itemCTCHDB in db.CHDB_ChiTietCatHuys
        //                          where itemCTCHDB.DanhBo == DanhBo || (itemCTCHDB.CHDB.DonKH.DanhBo == DanhBo || itemCTCHDB.CHDB.DonTXL.DanhBo == DanhBo || itemCTCHDB.CHDB.DonTBC.DanhBo == DanhBo)
        //                          select new
        //                          {
        //                              MaDon = itemCTCHDB.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTCHDB.CHDB.MaDonMoi).Count() == 1 ? itemCTCHDB.CHDB.MaDonMoi.Value.ToString() : itemCTCHDB.CHDB.MaDonMoi + "." + itemCTCHDB.STT
        //                              : itemCTCHDB.CHDB.MaDon != null ? "TKH" + itemCTCHDB.CHDB.MaDon
        //                              : itemCTCHDB.CHDB.MaDonTXL != null ? "TXL" + itemCTCHDB.CHDB.MaDonTXL
        //                              : itemCTCHDB.CHDB.MaDonTBC != null ? "TBC" + itemCTCHDB.CHDB.MaDonTBC : null,
        //                              MaCH = itemCTCHDB.MaCTCHDB,
        //                              LoaiCat = "Cắt Hủy",
        //                              itemCTCHDB.CreateDate,
        //                              itemCTCHDB.DanhBo,
        //                              itemCTCHDB.HoTen,
        //                              itemCTCHDB.DiaChi,
        //                              itemCTCHDB.LyDo,
        //                              itemCTCHDB.GhiChuLyDo,
        //                              itemCTCHDB.DaLapPhieu,
        //                              itemCTCHDB.SoPhieu,
        //                              itemCTCHDB.NgayLapPhieu,
        //                          };
        //        DataTable dtCHDB = new DataTable();
        //        dtCHDB = LINQToDataTable(queryCTCTDB);
        //        dtCHDB.Merge(LINQToDataTable(queryCTCHDB));
        //        dtCHDB.TableName = "CHDB";
        //        ds.Tables.Add(dtCHDB);

        //        ///Table PhieuCHDB
        //        var queryPhieuCHDB = from itemYCCHDB in db.CHDB_Phieus
        //                          where itemYCCHDB.DanhBo == DanhBo || (itemYCCHDB.CHDB.DonKH.DanhBo == DanhBo || itemYCCHDB.CHDB.DonTXL.DanhBo == DanhBo || itemYCCHDB.CHDB.DonTBC.DanhBo == DanhBo)
        //                          select new
        //                          {
        //                              MaDon = itemYCCHDB.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemYCCHDB.CHDB.MaDonMoi).Count() == 1 ? itemYCCHDB.CHDB.MaDonMoi.Value.ToString() : itemYCCHDB.CHDB.MaDonMoi + "." + itemYCCHDB.STT
        //                              : itemYCCHDB.CHDB.MaDon != null ? "TKH" + itemYCCHDB.CHDB.MaDonTXL
        //                              : itemYCCHDB.CHDB.MaDonTXL != null ? "TXL" + itemYCCHDB.CHDB.MaDonTXL
        //                              : itemYCCHDB.CHDB.MaDonTBC != null ? "TBC" + itemYCCHDB.CHDB.MaDonTBC : null,
        //                              itemYCCHDB.MaYCCHDB,
        //                              itemYCCHDB.CreateDate,
        //                              itemYCCHDB.DanhBo,
        //                              itemYCCHDB.HoTen,
        //                              itemYCCHDB.DiaChi,
        //                              itemYCCHDB.LyDo,
        //                              itemYCCHDB.GhiChuLyDo,
        //                              itemYCCHDB.HieuLucKy,
        //                          };
        //        DataTable dtPhieuCHDB = new DataTable();
        //        dtPhieuCHDB = LINQToDataTable(queryPhieuCHDB);
        //        dtPhieuCHDB.TableName = "PhieuCHDB";
        //        ds.Tables.Add(dtPhieuCHDB);

        //        ///Table CTTTTL
        //        var queryTTTL = from itemCTTTTL in db.ThuTraLoi_ChiTiets
        //                        where itemCTTTTL.DanhBo == DanhBo || (itemCTTTTL.ThuTraLoi.DonKH.DanhBo == DanhBo || itemCTTTTL.ThuTraLoi.DonTXL.DanhBo == DanhBo || itemCTTTTL.ThuTraLoi.DonTBC.DanhBo == DanhBo)
        //                        select new
        //                        {
        //                            MaDon = itemCTTTTL.ThuTraLoi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTTTTL.ThuTraLoi.MaDonMoi).Count() == 1 ? itemCTTTTL.ThuTraLoi.MaDonMoi.Value.ToString() : itemCTTTTL.ThuTraLoi.MaDonMoi + "." + itemCTTTTL.STT
        //                            : itemCTTTTL.ThuTraLoi.MaDon != null ? "TKH" + itemCTTTTL.ThuTraLoi.MaDon
        //                            : itemCTTTTL.ThuTraLoi.MaDonTXL != null ? "TXL" + itemCTTTTL.ThuTraLoi.MaDonTXL
        //                            : itemCTTTTL.ThuTraLoi.MaDonTBC != null ? "TBC" + itemCTTTTL.ThuTraLoi.MaDonTBC : null,
        //                            itemCTTTTL.MaCTTTTL,
        //                            itemCTTTTL.CreateDate,
        //                            itemCTTTTL.DanhBo,
        //                            itemCTTTTL.HoTen,
        //                            itemCTTTTL.DiaChi,
        //                            itemCTTTTL.VeViec,
        //                            itemCTTTTL.NoiDung,
        //                            itemCTTTTL.NoiNhan,
        //                        };
        //        DataTable dtTTTL = new DataTable();
        //        dtTTTL = LINQToDataTable(queryTTTL);
        //        dtTTTL.TableName = "ThuTraLoi";
        //        ds.Tables.Add(dtTTTL);

        //        ///Table GianLan
        //        var queryGianLan = from itemGL in db.GianLan_ChiTiets
        //                           where itemGL.DanhBo == DanhBo || (itemGL.GianLan.DonKH.DanhBo == DanhBo || itemGL.GianLan.DonTXL.DanhBo == DanhBo || itemGL.GianLan.DonTBC.DanhBo == DanhBo)
        //                           select new
        //                           {
        //                               MaDon = itemGL.GianLan.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemGL.GianLan.MaDonMoi).Count() == 1 ? itemGL.GianLan.MaDonMoi.Value.ToString() : itemGL.GianLan.MaDonMoi + "." + itemGL.STT
        //                              : itemGL.GianLan.MaDon != null ? "TKH" + itemGL.GianLan.MaDon
        //                               : itemGL.GianLan.MaDonTXL != null ? "TXL" + itemGL.GianLan.MaDonTXL
        //                               : itemGL.GianLan.MaDonTBC != null ? "TBC" + itemGL.GianLan.MaDonTBC : null,
        //                               ID = itemGL.MaCTGL,
        //                               itemGL.CreateDate,
        //                               itemGL.DanhBo,
        //                               itemGL.HoTen,
        //                               itemGL.DiaChi,
        //                               itemGL.NoiDungViPham,
        //                               itemGL.TinhTrang,
        //                               itemGL.ThanhToan1,
        //                               itemGL.ThanhToan2,
        //                               itemGL.ThanhToan3,
        //                               itemGL.XepDon,
        //                           };
        //        DataTable dtGianLan = new DataTable();
        //        dtGianLan = LINQToDataTable(queryGianLan);
        //        dtGianLan.TableName = "GianLan";
        //        ds.Tables.Add(dtGianLan);

        //        ///Table TruyThu
        //        var queryTruyThu = from itemTT in db.TruyThuTienNuoc_ChiTiets
        //                           where itemTT.DanhBo == DanhBo || (itemTT.TruyThuTienNuoc.DonKH.DanhBo == DanhBo || itemTT.TruyThuTienNuoc.DonTXL.DanhBo == DanhBo || itemTT.TruyThuTienNuoc.DonTBC.DanhBo == DanhBo)
        //                           select new
        //                           {
        //                               MaDon = itemTT.TruyThuTienNuoc.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemTT.TruyThuTienNuoc.MaDonMoi).Count() == 1 ? itemTT.TruyThuTienNuoc.MaDonMoi.Value.ToString() : itemTT.TruyThuTienNuoc.MaDonMoi + "." + itemTT.STT
        //                               : itemTT.TruyThuTienNuoc.MaDon != null ? "TKH" + itemTT.TruyThuTienNuoc.MaDon
        //                               : itemTT.TruyThuTienNuoc.MaDonTXL != null ? "TXL" + itemTT.TruyThuTienNuoc.MaDonTXL
        //                               : itemTT.TruyThuTienNuoc.MaDonTBC != null ? "TBC" + itemTT.TruyThuTienNuoc.MaDonTBC : null,
        //                               itemTT.IDCT,
        //                               itemTT.DanhBo,
        //                               itemTT.HoTen,
        //                               itemTT.DiaChi,
        //                               itemTT.CreateDate,
        //                               itemTT.NoiDung,
        //                               itemTT.TongTien,
        //                               itemTT.Tongm3BinhQuan,
        //                               itemTT.TinhTrang,
        //                           };
        //        DataTable dtTruyThu = new DataTable();
        //        dtTruyThu = LINQToDataTable(queryTruyThu);
        //        dtTruyThu.TableName = "TruyThu";
        //        ds.Tables.Add(dtTruyThu);

        //        ///Table ToTrinh
        //        var queryToTrinh = from itemCTTT in db.ToTrinh_ChiTiets
        //                           where itemCTTT.DanhBo == DanhBo || (itemCTTT.ToTrinh.DonKH.DanhBo == DanhBo || itemCTTT.ToTrinh.DonTXL.DanhBo == DanhBo || itemCTTT.ToTrinh.DonTBC.DanhBo == DanhBo)
        //                           select new
        //                           {
        //                               MaDon = itemCTTT.ToTrinh.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTTT.ToTrinh.MaDonMoi).Count() == 1 ? itemCTTT.ToTrinh.MaDonMoi.Value.ToString() : itemCTTT.ToTrinh.MaDonMoi + "." + itemCTTT.STT
        //                               : itemCTTT.ToTrinh.MaDon != null ? "TKH" + itemCTTT.ToTrinh.MaDon
        //                               : itemCTTT.ToTrinh.MaDonTXL != null ? "TXL" + itemCTTT.ToTrinh.MaDonTXL
        //                               : itemCTTT.ToTrinh.MaDonTBC != null ? "TBC" + itemCTTT.ToTrinh.MaDonTBC : null,
        //                               itemCTTT.IDCT,
        //                               itemCTTT.DanhBo,
        //                               itemCTTT.HoTen,
        //                               itemCTTT.DiaChi,
        //                               itemCTTT.CreateDate,
        //                               itemCTTT.NoiDung,
        //                               itemCTTT.VeViec,
        //                           };
        //        DataTable dtToTrinh = new DataTable();
        //        dtToTrinh = LINQToDataTable(queryToTrinh);
        //        dtToTrinh.TableName = "ToTrinh";
        //        ds.Tables.Add(dtToTrinh);

        //        ///Table ThuMoi
        //        var queryThuMoi = from item in db.ThuMoi_ChiTiets
        //                          where item.DanhBo == DanhBo || (item.ThuMoi.DonKH.DanhBo == DanhBo || item.ThuMoi.DonTXL.DanhBo == DanhBo || item.ThuMoi.DonTBC.DanhBo == DanhBo)
        //                          select new
        //                          {
        //                              MaDon = item.ThuMoi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.ThuMoi.MaDonMoi).Count() == 1 ? item.ThuMoi.MaDonMoi.Value.ToString() : item.ThuMoi.MaDonMoi + "." + item.STT
        //                              : item.ThuMoi.MaDonTKH != null ? "TKH" + item.ThuMoi.MaDonTKH
        //                              : item.ThuMoi.MaDonTXL != null ? "TXL" + item.ThuMoi.MaDonTXL
        //                              : item.ThuMoi.MaDonTBC != null ? "TBC" + item.ThuMoi.MaDonTBC : null,
        //                              item.IDCT,
        //                              item.Lan,
        //                              item.DanhBo,
        //                              item.HoTen,
        //                              item.DiaChi,
        //                              item.CreateDate,
        //                              item.VeViec,
        //                          };
        //        DataTable dtThuMoi = new DataTable();
        //        dtThuMoi = LINQToDataTable(queryThuMoi);
        //        dtThuMoi.TableName = "ThuMoi";
        //        ds.Tables.Add(dtThuMoi);

        //        //Table TienTrinh
        //        var queryTienTrinh = from itemDon in db.DonTu_ChiTiets
        //                             join itemTT in db.DonTu_LichSus on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemTT.MaDon, itemTT.STT }
        //                             where itemDon.DanhBo == DanhBo
        //                             orderby itemTT.NgayChuyen ascending,itemTT.ID ascending
        //                             select new
        //                             {
        //                                 MaDon = db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == itemDon.MaDon).Count() == 1 ? itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //                                 itemTT.NgayChuyen,
        //                                 itemTT.NoiChuyen,
        //                                 itemTT.NoiNhan,
        //                                 itemTT.KTXM,
        //                                 itemTT.NoiDung,
        //                             };
        //        DataTable dtTienTrinh = new DataTable();
        //        dtTienTrinh = LINQToDataTable(queryTienTrinh);
        //        dtTienTrinh.TableName = "TienTrinh";
        //        ds.Tables.Add(dtTienTrinh);

        //        #endregion

        //        DataTable dt = new DataTable();

        //        #region

        //        //#region DonTu

        //        /////Table DonTu
        //        //var queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //                 where itemDon.DanhBo == DanhBo
        //        //                 select new
        //        //                 {
        //        //                     MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                     TenLD = "",
        //        //                     itemDon.CreateDate,
        //        //                     itemDon.DanhBo,
        //        //                     itemDon.HoTen,
        //        //                     itemDon.DiaChi,
        //        //                     itemDon.GiaBieu,
        //        //                     itemDon.DinhMuc,
        //        //                     NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //                 };
        //        //dt = LINQToDataTable(queryDonTu);

        //        /////Table KTXM_ChiTiets
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemCTKTXM in db.KTXM_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTKTXM.KTXM.MaDonMoi, itemCTKTXM.STT }
        //        //             where itemCTKTXM.DanhBo == DanhBo
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////Table BamChi_ChiTiets
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemCTBamChi in db.BamChi_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTBamChi.BamChi.MaDonMoi, itemCTBamChi.STT }
        //        //             where itemCTBamChi.DanhBo == DanhBo
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////Table DCBD_ChiTietBienDongs
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemCTDCBD in db.DCBD_ChiTietBienDongs on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTDCBD.DCBD.MaDonMoi, itemCTDCBD.STT }
        //        //             where itemCTDCBD.DanhBo == DanhBo
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////Table DCBD_ChiTietHoaDons
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemCTDCHD in db.DCBD_ChiTietHoaDons on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTDCHD.DCBD.MaDonMoi, itemCTDCHD.STT }
        //        //             where itemCTDCHD.DanhBo == DanhBo
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////Table CHDB_ChiTietCatTams
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemCTCTDB in db.CHDB_ChiTietCatTams on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTCTDB.CHDB.MaDonMoi, itemCTCTDB.STT }
        //        //             where itemCTCTDB.DanhBo == DanhBo
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////Table CHDB_ChiTietCatHuys
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemCTCHDB in db.CHDB_ChiTietCatHuys on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTCHDB.CHDB.MaDonMoi, itemCTCHDB.STT }
        //        //             where itemCTCHDB.DanhBo == DanhBo
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////TablePhieuCHDBs
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemYCCHDB in db.CHDB_Phieus on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemYCCHDB.CHDB.MaDonMoi, itemYCCHDB.STT }
        //        //             where itemYCCHDB.DanhBo == DanhBo
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////Table ThuTraLoi_ChiTiets
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemCTTTTL in db.ThuTraLoi_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTTTTL.ThuTraLoi.MaDonMoi, itemCTTTTL.STT }
        //        //             where itemCTTTTL.DanhBo == DanhBo
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////Table DongNuoc_ChiTiets
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemCTDongNuoc in db.DongNuoc_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTDongNuoc.DongNuoc.MaDonMoi, itemCTDongNuoc.STT }
        //        //             where itemCTDongNuoc.DanhBo == DanhBo
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////Table GianLan_ChiTiets
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemGL in db.GianLan_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemGL.GianLan.MaDonMoi, itemGL.STT }
        //        //             where itemGL.DanhBo == DanhBo
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////Table TruyThu
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemTT in db.TruyThuTienNuoc_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemTT.TruyThuTienNuoc.MaDonMoi, itemTT.STT }
        //        //             where itemTT.DanhBo == DanhBo
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////Table ToTrinh
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemCTTT in db.ToTrinh_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTTT.ToTrinh.MaDonMoi, itemCTTT.STT }
        //        //             where itemCTTT.DanhBo == DanhBo
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////Table ThuMoi
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemTM in db.ThuMoi_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemTM.ThuMoi.MaDonMoi, itemTM.STT }
        //        //             where itemTM.DanhBo == DanhBo
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        //#endregion

        //        //#region DonKH

        //        /////Table DonKH
        //        //var queryDonKH = from itemDon in db.DonKHs
        //        //                 where itemDon.DanhBo == DanhBo
        //        //                 select new
        //        //                 {
        //        //                     MaDon = "TKH" + itemDon.MaDon,
        //        //                     itemDon.LoaiDon.TenLD,
        //        //                     itemDon.CreateDate,
        //        //                     itemDon.DanhBo,
        //        //                     itemDon.HoTen,
        //        //                     itemDon.DiaChi,
        //        //                     itemDon.GiaBieu,
        //        //                     itemDon.DinhMuc,
        //        //                     itemDon.NoiDung,
        //        //                 };

        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table KTXM_ChiTiets
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemCTKTXM in db.KTXM_ChiTiets on itemDon.MaDon equals itemCTKTXM.KTXM.MaDon
        //        //             where itemCTKTXM.DanhBo == DanhBo
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table BamChi_ChiTiets
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemCTBamChi in db.BamChi_ChiTiets on itemDon.MaDon equals itemCTBamChi.BamChi.MaDon
        //        //             where itemCTBamChi.DanhBo == DanhBo
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table DCBD_ChiTietBienDongs
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemCTDCBD in db.DCBD_ChiTietBienDongs on itemDon.MaDon equals itemCTDCBD.DCBD.MaDon
        //        //             where itemCTDCBD.DanhBo == DanhBo
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table DCBD_ChiTietHoaDons
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemCTDCHD in db.DCBD_ChiTietHoaDons on itemDon.MaDon equals itemCTDCHD.DCBD.MaDon
        //        //             where itemCTDCHD.DanhBo == DanhBo
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table CHDB_ChiTietCatTams
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemCTCTDB in db.CHDB_ChiTietCatTams on itemDon.MaDon equals itemCTCTDB.CHDB.MaDon
        //        //             where itemCTCTDB.DanhBo == DanhBo
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table CHDB_ChiTietCatHuys
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemCTCHDB in db.CHDB_ChiTietCatHuys on itemDon.MaDon equals itemCTCHDB.CHDB.MaDon
        //        //             where itemCTCHDB.DanhBo == DanhBo
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////TablePhieuCHDBs
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemYCCHDB in db.CHDB_Phieus on itemDon.MaDon equals itemYCCHDB.CHDB.MaDon
        //        //             where itemYCCHDB.DanhBo == DanhBo
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table ThuTraLoi_ChiTiets
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemCTTTTL in db.ThuTraLoi_ChiTiets on itemDon.MaDon equals itemCTTTTL.ThuTraLoi.MaDon
        //        //             where itemCTTTTL.DanhBo == DanhBo
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table DongNuoc_ChiTiets
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemCTDongNuoc in db.DongNuoc_ChiTiets on itemDon.MaDon equals itemCTDongNuoc.DongNuoc.MaDon
        //        //             where itemCTDongNuoc.DanhBo == DanhBo
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table GianLan_ChiTiets
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemGL in db.GianLan_ChiTiets on itemDon.MaDon equals itemGL.GianLan.MaDon
        //        //             where itemGL.DanhBo == DanhBo
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table TruyThu
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemTT in db.TruyThuTienNuoc_ChiTiets on itemDon.MaDon equals itemTT.TruyThuTienNuoc.MaDon
        //        //             where itemTT.DanhBo == DanhBo
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table ToTrinh
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemCTTT in db.ToTrinh_ChiTiets on itemDon.MaDon equals itemCTTT.ToTrinh.MaDon
        //        //             where itemCTTT.DanhBo == DanhBo
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table ThuMoi
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemTM in db.ThuMoi_ChiTiets on itemDon.MaDon equals itemTM.ThuMoi.MaDonTKH
        //        //             where itemTM.DanhBo == DanhBo
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        //#endregion

        //        //#region DonTXL

        //        /////Table DonTXL
        //        //var queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //                  where itemDonTXL.DanhBo == DanhBo
        //        //                  select new
        //        //                  {
        //        //                      MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                      itemDonTXL.LoaiDonTXL.TenLD,
        //        //                      itemDonTXL.CreateDate,
        //        //                      itemDonTXL.DanhBo,
        //        //                      itemDonTXL.HoTen,
        //        //                      itemDonTXL.DiaChi,
        //        //                      itemDonTXL.GiaBieu,
        //        //                      itemDonTXL.DinhMuc,
        //        //                      itemDonTXL.NoiDung,
        //        //                  };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table KTXM_ChiTiets
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemCTKTXM in db.KTXM_ChiTiets on itemDonTXL.MaDon equals itemCTKTXM.KTXM.MaDonTXL
        //        //              where itemCTKTXM.DanhBo == DanhBo
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table BamChi_ChiTiets
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemCTBamChi in db.BamChi_ChiTiets on itemDonTXL.MaDon equals itemCTBamChi.BamChi.MaDonTXL
        //        //              where itemCTBamChi.DanhBo == DanhBo
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table DCBD_ChiTietBienDongs
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemCTDCBD in db.DCBD_ChiTietBienDongs on itemDonTXL.MaDon equals itemCTDCBD.DCBD.MaDonTXL
        //        //              where itemCTDCBD.DanhBo == DanhBo
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table DCBD_ChiTietHoaDons
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemCTDCHD in db.DCBD_ChiTietHoaDons on itemDonTXL.MaDon equals itemCTDCHD.DCBD.MaDonTXL
        //        //              where itemCTDCHD.DanhBo == DanhBo
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table CHDB_ChiTietCatTams
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemCTCTDB in db.CHDB_ChiTietCatTams on itemDonTXL.MaDon equals itemCTCTDB.CHDB.MaDonTXL
        //        //              where itemCTCTDB.DanhBo == DanhBo
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table CHDB_ChiTietCatHuys
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemCTCHDB in db.CHDB_ChiTietCatHuys on itemDonTXL.MaDon equals itemCTCHDB.CHDB.MaDonTXL
        //        //              where itemCTCHDB.DanhBo == DanhBo
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table CHDB_Phieus
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemYCCHDB in db.CHDB_Phieus on itemDonTXL.MaDon equals itemYCCHDB.CHDB.MaDonTXL
        //        //              where itemYCCHDB.DanhBo == DanhBo
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table ThuTraLoi_ChiTiets
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemCTTTTL in db.ThuTraLoi_ChiTiets on itemDonTXL.MaDon equals itemCTTTTL.ThuTraLoi.MaDonTXL
        //        //              where itemCTTTTL.DanhBo == DanhBo
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table DongNuoc_ChiTiets
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemCTDongNuoc in db.DongNuoc_ChiTiets on itemDonTXL.MaDon equals itemCTDongNuoc.DongNuoc.MaDonTXL
        //        //              where itemCTDongNuoc.DanhBo == DanhBo
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table GianLan_ChiTiets
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemGL in db.GianLan_ChiTiets on itemDonTXL.MaDon equals itemGL.GianLan.MaDonTXL
        //        //              where itemGL.DanhBo == DanhBo
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table TruyThu
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemTT in db.TruyThuTienNuoc_ChiTiets on itemDonTXL.MaDon equals itemTT.TruyThuTienNuoc.MaDonTXL
        //        //              where itemTT.DanhBo == DanhBo
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table ToTrinh
        //        //queryDonTXL = from itemDon in db.DonTXLs
        //        //              join itemCTTT in db.ToTrinh_ChiTiets on itemDon.MaDon equals itemCTTT.ToTrinh.MaDonTXL
        //        //              where itemCTTT.DanhBo == DanhBo
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTXL.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table ThuMoi
        //        //queryDonTXL = from itemDon in db.DonTXLs
        //        //              join itemTM in db.ThuMoi_ChiTiets on itemDon.MaDon equals itemTM.ThuMoi.MaDonTXL
        //        //              where itemTM.DanhBo == DanhBo
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTXL.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        //#endregion

        //        //#region DonTBC

        //        /////Table DonTBC
        //        //var queryDonTBC = from itemDon in db.DonTBCs
        //        //                  where itemDon.DanhBo == DanhBo
        //        //                  select new
        //        //                  {
        //        //                      MaDon = "TBC" + itemDon.MaDon,
        //        //                      itemDon.LoaiDonTBC.TenLD,
        //        //                      itemDon.CreateDate,
        //        //                      itemDon.DanhBo,
        //        //                      itemDon.HoTen,
        //        //                      itemDon.DiaChi,
        //        //                      itemDon.GiaBieu,
        //        //                      itemDon.DinhMuc,
        //        //                      itemDon.NoiDung,
        //        //                  };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table KTXM_ChiTiets
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemCTKTXM in db.KTXM_ChiTiets on itemDon.MaDon equals itemCTKTXM.KTXM.MaDonTBC
        //        //              where itemCTKTXM.DanhBo == DanhBo
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table BamChi_ChiTiets
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemCTBamChi in db.BamChi_ChiTiets on itemDon.MaDon equals itemCTBamChi.BamChi.MaDonTBC
        //        //              where itemCTBamChi.DanhBo == DanhBo
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table DCBD_ChiTietBienDongs
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemCTDCBD in db.DCBD_ChiTietBienDongs on itemDon.MaDon equals itemCTDCBD.DCBD.MaDonTBC
        //        //              where itemCTDCBD.DanhBo == DanhBo
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table DCBD_ChiTietHoaDons
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemCTDCHD in db.DCBD_ChiTietHoaDons on itemDon.MaDon equals itemCTDCHD.DCBD.MaDonTBC
        //        //              where itemCTDCHD.DanhBo == DanhBo
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table CHDB_ChiTietCatTams
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemCTCTDB in db.CHDB_ChiTietCatTams on itemDon.MaDon equals itemCTCTDB.CHDB.MaDonTBC
        //        //              where itemCTCTDB.DanhBo == DanhBo
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table CHDB_ChiTietCatHuys
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemCTCHDB in db.CHDB_ChiTietCatHuys on itemDon.MaDon equals itemCTCHDB.CHDB.MaDonTBC
        //        //              where itemCTCHDB.DanhBo == DanhBo
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////TablePhieuCHDBs
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemYCCHDB in db.CHDB_Phieus on itemDon.MaDon equals itemYCCHDB.CHDB.MaDonTBC
        //        //              where itemYCCHDB.DanhBo == DanhBo
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table ThuTraLoi_ChiTiets
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemCTTTTL in db.ThuTraLoi_ChiTiets on itemDon.MaDon equals itemCTTTTL.ThuTraLoi.MaDonTBC
        //        //              where itemCTTTTL.DanhBo == DanhBo
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table DongNuoc_ChiTiets
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemCTDongNuoc in db.DongNuoc_ChiTiets on itemDon.MaDon equals itemCTDongNuoc.DongNuoc.MaDonTBC
        //        //              where itemCTDongNuoc.DanhBo == DanhBo
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table GianLan_ChiTiets
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemGL in db.GianLan_ChiTiets on itemDon.MaDon equals itemGL.GianLan.MaDonTBC
        //        //              where itemGL.DanhBo == DanhBo
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table TruyThu
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemTT in db.TruyThuTienNuoc_ChiTiets on itemDon.MaDon equals itemTT.TruyThuTienNuoc.MaDonTBC
        //        //              where itemTT.DanhBo == DanhBo
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table ToTrinh
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemCTTT in db.ToTrinh_ChiTiets on itemDon.MaDon equals itemCTTT.ToTrinh.MaDonTBC
        //        //              where itemCTTT.DanhBo == DanhBo
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table ThuMoi
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemTM in db.ThuMoi_ChiTiets on itemDon.MaDon equals itemTM.ThuMoi.MaDonTBC
        //        //              where itemTM.DanhBo == DanhBo
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        //#endregion

        //        #endregion

        //        #region DonTu

        //        ///Table DonTu
        //        var queryDonTu = from itemDon in db.DonTu_ChiTiets
        //                         where itemDon.DanhBo == DanhBo
        //                         select new
        //                         {
        //                             MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //                             TenLD = "",
        //                             itemDon.CreateDate,
        //                             itemDon.DanhBo,
        //                             itemDon.HoTen,
        //                             itemDon.DiaChi,
        //                             itemDon.GiaBieu,
        //                             itemDon.DinhMuc,
        //                             NoiDung = itemDon.DonTu.Name_NhomDon,
        //                         };
        //        dt = LINQToDataTable(queryDonTu);

        //        var queryDonKH = from itemDon in db.DonKHs
        //                         where itemDon.DanhBo == DanhBo
        //                         select new
        //                         {
        //                             MaDon = "TKH" + itemDon.MaDon,
        //                             itemDon.LoaiDon.TenLD,
        //                             itemDon.CreateDate,
        //                             itemDon.DanhBo,
        //                             itemDon.HoTen,
        //                             itemDon.DiaChi,
        //                             itemDon.GiaBieu,
        //                             itemDon.DinhMuc,
        //                             itemDon.NoiDung,
        //                         };
        //        dt.Merge(LINQToDataTable(queryDonKH));

        //        var queryDonTXL = from itemDon in db.DonTXLs
        //                          where itemDon.DanhBo == DanhBo
        //                          select new
        //                          {
        //                              MaDon = "TXL" + itemDon.MaDon,
        //                              itemDon.LoaiDonTXL.TenLD,
        //                              itemDon.CreateDate,
        //                              itemDon.DanhBo,
        //                              itemDon.HoTen,
        //                              itemDon.DiaChi,
        //                              itemDon.GiaBieu,
        //                              itemDon.DinhMuc,
        //                              itemDon.NoiDung,
        //                          };
        //        dt.Merge(LINQToDataTable(queryDonTXL));

        //        var queryDonTBC = from itemDon in db.DonTBCs
        //                          where itemDon.DanhBo == DanhBo
        //                          select new
        //                          {
        //                              MaDon = "TBC" + itemDon.MaDon,
        //                              itemDon.LoaiDonTBC.TenLD,
        //                              itemDon.CreateDate,
        //                              itemDon.DanhBo,
        //                              itemDon.HoTen,
        //                              itemDon.DiaChi,
        //                              itemDon.GiaBieu,
        //                              itemDon.DinhMuc,
        //                              itemDon.NoiDung,
        //                          };
        //        dt.Merge(LINQToDataTable(queryDonTBC));

        //        ///Table KTXM_ChiTiets
        //        queryDonTu = from item in db.KTXM_ChiTiets
        //                     where item.DanhBo == DanhBo
        //                     select new
        //                     {
        //                         MaDon = item.KTXM.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.KTXM.MaDonMoi).Count() == 1 ? item.KTXM.MaDonMoi.Value.ToString() : item.KTXM.MaDonMoi + "." + item.STT
        //                            : item.KTXM.MaDon != null ? "TKH" + item.KTXM.MaDon
        //                            : item.KTXM.MaDonTXL != null ? "TXL" + item.KTXM.MaDonTXL
        //                            : item.KTXM.MaDonTBC != null ? "TBC" + item.KTXM.MaDonTBC : null,
        //                         TenLD = item.KTXM.MaDonMoi != null ? ""
        //                            : item.KTXM.MaDon != null ? item.KTXM.DonKH.LoaiDon.TenLD
        //                            : item.KTXM.MaDonTXL != null ? item.KTXM.DonTXL.LoaiDonTXL.TenLD
        //                            : item.KTXM.MaDonTBC != null ? item.KTXM.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.KTXM.MaDonMoi != null ? item.KTXM.DonTu.CreateDate
        //                            : item.KTXM.MaDon != null ? item.KTXM.DonKH.CreateDate
        //                            : item.KTXM.MaDonTXL != null ? item.KTXM.DonTXL.CreateDate
        //                            : item.KTXM.MaDonTBC != null ? item.KTXM.DonTBC.CreateDate : null,
        //                         DanhBo = item.KTXM.MaDonMoi != null ? item.KTXM.DonTu.DanhBo
        //                            : item.KTXM.MaDon != null ? item.KTXM.DonKH.DanhBo
        //                            : item.KTXM.MaDonTXL != null ? item.KTXM.DonTXL.DanhBo
        //                            : item.KTXM.MaDonTBC != null ? item.KTXM.DonTBC.DanhBo : null,
        //                         HoTen = item.KTXM.MaDonMoi != null ? item.KTXM.DonTu.HoTen
        //                            : item.KTXM.MaDon != null ? item.KTXM.DonKH.HoTen
        //                            : item.KTXM.MaDonTXL != null ? item.KTXM.DonTXL.HoTen
        //                            : item.KTXM.MaDonTBC != null ? item.KTXM.DonTBC.HoTen : null,
        //                         DiaChi = item.KTXM.MaDonMoi != null ? item.KTXM.DonTu.DiaChi
        //                            : item.KTXM.MaDon != null ? item.KTXM.DonKH.DiaChi
        //                            : item.KTXM.MaDonTXL != null ? item.KTXM.DonTXL.DiaChi
        //                            : item.KTXM.MaDonTBC != null ? item.KTXM.DonTBC.DiaChi : null,
        //                         GiaBieu = item.KTXM.MaDonMoi != null ? item.KTXM.DonTu.GiaBieu
        //                            : item.KTXM.MaDon != null ? item.KTXM.DonKH.GiaBieu
        //                            : item.KTXM.MaDonTXL != null ? item.KTXM.DonTXL.GiaBieu
        //                            : item.KTXM.MaDonTBC != null ? item.KTXM.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.KTXM.MaDonMoi != null ? item.KTXM.DonTu.DinhMuc
        //                            : item.KTXM.MaDon != null ? item.KTXM.DonKH.DinhMuc
        //                            : item.KTXM.MaDonTXL != null ? item.KTXM.DonTXL.DinhMuc
        //                            : item.KTXM.MaDonTBC != null ? item.KTXM.DonTBC.DinhMuc : null,
        //                         NoiDung = item.KTXM.MaDonMoi != null ? item.KTXM.DonTu.Name_NhomDon
        //                            : item.KTXM.MaDon != null ? item.KTXM.DonKH.NoiDung
        //                            : item.KTXM.MaDonTXL != null ? item.KTXM.DonTXL.NoiDung
        //                            : item.KTXM.MaDonTBC != null ? item.KTXM.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///Table BamChi_ChiTiets
        //        queryDonTu = from item in db.BamChi_ChiTiets
        //                     where item.DanhBo == DanhBo
        //                     select new
        //                     {
        //                         MaDon = item.BamChi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.BamChi.MaDonMoi).Count() == 1 ? item.BamChi.MaDonMoi.Value.ToString() : item.BamChi.MaDonMoi + "." + item.STT
        //                            : item.BamChi.MaDon != null ? "TKH" + item.BamChi.MaDon
        //                            : item.BamChi.MaDonTXL != null ? "TXL" + item.BamChi.MaDonTXL
        //                            : item.BamChi.MaDonTBC != null ? "TBC" + item.BamChi.MaDonTBC : null,
        //                         TenLD = item.BamChi.MaDonMoi != null ? ""
        //                            : item.BamChi.MaDon != null ? item.BamChi.DonKH.LoaiDon.TenLD
        //                            : item.BamChi.MaDonTXL != null ? item.BamChi.DonTXL.LoaiDonTXL.TenLD
        //                            : item.BamChi.MaDonTBC != null ? item.BamChi.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.BamChi.MaDonMoi != null ? item.BamChi.DonTu.CreateDate
        //                            : item.BamChi.MaDon != null ? item.BamChi.DonKH.CreateDate
        //                            : item.BamChi.MaDonTXL != null ? item.BamChi.DonTXL.CreateDate
        //                            : item.BamChi.MaDonTBC != null ? item.BamChi.DonTBC.CreateDate : null,
        //                         DanhBo = item.BamChi.MaDonMoi != null ? item.BamChi.DonTu.DanhBo
        //                            : item.BamChi.MaDon != null ? item.BamChi.DonKH.DanhBo
        //                            : item.BamChi.MaDonTXL != null ? item.BamChi.DonTXL.DanhBo
        //                            : item.BamChi.MaDonTBC != null ? item.BamChi.DonTBC.DanhBo : null,
        //                         HoTen = item.BamChi.MaDonMoi != null ? item.BamChi.DonTu.HoTen
        //                            : item.BamChi.MaDon != null ? item.BamChi.DonKH.HoTen
        //                            : item.BamChi.MaDonTXL != null ? item.BamChi.DonTXL.HoTen
        //                            : item.BamChi.MaDonTBC != null ? item.BamChi.DonTBC.HoTen : null,
        //                         DiaChi = item.BamChi.MaDonMoi != null ? item.BamChi.DonTu.DiaChi
        //                            : item.BamChi.MaDon != null ? item.BamChi.DonKH.DiaChi
        //                            : item.BamChi.MaDonTXL != null ? item.BamChi.DonTXL.DiaChi
        //                            : item.BamChi.MaDonTBC != null ? item.BamChi.DonTBC.DiaChi : null,
        //                         GiaBieu = item.BamChi.MaDonMoi != null ? item.BamChi.DonTu.GiaBieu
        //                            : item.BamChi.MaDon != null ? item.BamChi.DonKH.GiaBieu
        //                            : item.BamChi.MaDonTXL != null ? item.BamChi.DonTXL.GiaBieu
        //                            : item.BamChi.MaDonTBC != null ? item.BamChi.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.BamChi.MaDonMoi != null ? item.BamChi.DonTu.DinhMuc
        //                            : item.BamChi.MaDon != null ? item.BamChi.DonKH.DinhMuc
        //                            : item.BamChi.MaDonTXL != null ? item.BamChi.DonTXL.DinhMuc
        //                            : item.BamChi.MaDonTBC != null ? item.BamChi.DonTBC.DinhMuc : null,
        //                         NoiDung = item.BamChi.MaDonMoi != null ? item.BamChi.DonTu.Name_NhomDon
        //                            : item.BamChi.MaDon != null ? item.BamChi.DonKH.NoiDung
        //                            : item.BamChi.MaDonTXL != null ? item.BamChi.DonTXL.NoiDung
        //                            : item.BamChi.MaDonTBC != null ? item.BamChi.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///Table DongNuoc_ChiTiets
        //        queryDonTu = from item in db.DongNuoc_ChiTiets
        //                     where item.DanhBo == DanhBo
        //                     select new
        //                     {
        //                         MaDon = item.DongNuoc.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.DongNuoc.MaDonMoi).Count() == 1 ? item.DongNuoc.MaDonMoi.Value.ToString() : item.DongNuoc.MaDonMoi + "." + item.STT
        //                            : item.DongNuoc.MaDon != null ? "TKH" + item.DongNuoc.MaDon
        //                            : item.DongNuoc.MaDonTXL != null ? "TXL" + item.DongNuoc.MaDonTXL
        //                            : item.DongNuoc.MaDonTBC != null ? "TBC" + item.DongNuoc.MaDonTBC : null,
        //                         TenLD = item.DongNuoc.MaDonMoi != null ? ""
        //                            : item.DongNuoc.MaDon != null ? item.DongNuoc.DonKH.LoaiDon.TenLD
        //                            : item.DongNuoc.MaDonTXL != null ? item.DongNuoc.DonTXL.LoaiDonTXL.TenLD
        //                            : item.DongNuoc.MaDonTBC != null ? item.DongNuoc.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.DongNuoc.MaDonMoi != null ? item.DongNuoc.DonTu.CreateDate
        //                            : item.DongNuoc.MaDon != null ? item.DongNuoc.DonKH.CreateDate
        //                            : item.DongNuoc.MaDonTXL != null ? item.DongNuoc.DonTXL.CreateDate
        //                            : item.DongNuoc.MaDonTBC != null ? item.DongNuoc.DonTBC.CreateDate : null,
        //                         DanhBo = item.DongNuoc.MaDonMoi != null ? item.DongNuoc.DonTu.DanhBo
        //                            : item.DongNuoc.MaDon != null ? item.DongNuoc.DonKH.DanhBo
        //                            : item.DongNuoc.MaDonTXL != null ? item.DongNuoc.DonTXL.DanhBo
        //                            : item.DongNuoc.MaDonTBC != null ? item.DongNuoc.DonTBC.DanhBo : null,
        //                         HoTen = item.DongNuoc.MaDonMoi != null ? item.DongNuoc.DonTu.HoTen
        //                            : item.DongNuoc.MaDon != null ? item.DongNuoc.DonKH.HoTen
        //                            : item.DongNuoc.MaDonTXL != null ? item.DongNuoc.DonTXL.HoTen
        //                            : item.DongNuoc.MaDonTBC != null ? item.DongNuoc.DonTBC.HoTen : null,
        //                         DiaChi = item.DongNuoc.MaDonMoi != null ? item.DongNuoc.DonTu.DiaChi
        //                            : item.DongNuoc.MaDon != null ? item.DongNuoc.DonKH.DiaChi
        //                            : item.DongNuoc.MaDonTXL != null ? item.DongNuoc.DonTXL.DiaChi
        //                            : item.DongNuoc.MaDonTBC != null ? item.DongNuoc.DonTBC.DiaChi : null,
        //                         GiaBieu = item.DongNuoc.MaDonMoi != null ? item.DongNuoc.DonTu.GiaBieu
        //                            : item.DongNuoc.MaDon != null ? item.DongNuoc.DonKH.GiaBieu
        //                            : item.DongNuoc.MaDonTXL != null ? item.DongNuoc.DonTXL.GiaBieu
        //                            : item.DongNuoc.MaDonTBC != null ? item.DongNuoc.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.DongNuoc.MaDonMoi != null ? item.DongNuoc.DonTu.DinhMuc
        //                            : item.DongNuoc.MaDon != null ? item.DongNuoc.DonKH.DinhMuc
        //                            : item.DongNuoc.MaDonTXL != null ? item.DongNuoc.DonTXL.DinhMuc
        //                            : item.DongNuoc.MaDonTBC != null ? item.DongNuoc.DonTBC.DinhMuc : null,
        //                         NoiDung = item.DongNuoc.MaDonMoi != null ? item.DongNuoc.DonTu.Name_NhomDon
        //                            : item.DongNuoc.MaDon != null ? item.DongNuoc.DonKH.NoiDung
        //                            : item.DongNuoc.MaDonTXL != null ? item.DongNuoc.DonTXL.NoiDung
        //                            : item.DongNuoc.MaDonTBC != null ? item.DongNuoc.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///Table DCBD_ChiTietBienDongs
        //        queryDonTu = from item in db.DCBD_ChiTietBienDongs
        //                     where item.DanhBo == DanhBo
        //                     select new
        //                     {
        //                         MaDon = item.DCBD.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.DCBD.MaDonMoi).Count() == 1 ? item.DCBD.MaDonMoi.Value.ToString() : item.DCBD.MaDonMoi + "." + item.STT
        //                            : item.DCBD.MaDon != null ? "TKH" + item.DCBD.MaDon
        //                            : item.DCBD.MaDonTXL != null ? "TXL" + item.DCBD.MaDonTXL
        //                            : item.DCBD.MaDonTBC != null ? "TBC" + item.DCBD.MaDonTBC : null,
        //                         TenLD = item.DCBD.MaDonMoi != null ? ""
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.LoaiDon.TenLD
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.LoaiDonTXL.TenLD
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.CreateDate
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.CreateDate
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.CreateDate
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.CreateDate : null,
        //                         DanhBo = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.DanhBo
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.DanhBo
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.DanhBo
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.DanhBo : null,
        //                         HoTen = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.HoTen
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.HoTen
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.HoTen
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.HoTen : null,
        //                         DiaChi = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.DiaChi
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.DiaChi
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.DiaChi
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.DiaChi : null,
        //                         GiaBieu = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.GiaBieu
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.GiaBieu
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.GiaBieu
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.DinhMuc
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.DinhMuc
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.DinhMuc
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.DinhMuc : null,
        //                         NoiDung = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.Name_NhomDon
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.NoiDung
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.NoiDung
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///Table DCBD_ChiTietHoaDons
        //        queryDonTu = from item in db.DCBD_ChiTietHoaDons
        //                     where item.DanhBo == DanhBo
        //                     select new
        //                     {
        //                         MaDon = item.DCBD.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.DCBD.MaDonMoi).Count() == 1 ? item.DCBD.MaDonMoi.Value.ToString() : item.DCBD.MaDonMoi + "." + item.STT
        //                            : item.DCBD.MaDon != null ? "TKH" + item.DCBD.MaDon
        //                            : item.DCBD.MaDonTXL != null ? "TXL" + item.DCBD.MaDonTXL
        //                            : item.DCBD.MaDonTBC != null ? "TBC" + item.DCBD.MaDonTBC : null,
        //                         TenLD = item.DCBD.MaDonMoi != null ? ""
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.LoaiDon.TenLD
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.LoaiDonTXL.TenLD
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.CreateDate
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.CreateDate
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.CreateDate
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.CreateDate : null,
        //                         DanhBo = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.DanhBo
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.DanhBo
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.DanhBo
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.DanhBo : null,
        //                         HoTen = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.HoTen
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.HoTen
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.HoTen
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.HoTen : null,
        //                         DiaChi = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.DiaChi
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.DiaChi
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.DiaChi
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.DiaChi : null,
        //                         GiaBieu = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.GiaBieu
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.GiaBieu
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.GiaBieu
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.DinhMuc
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.DinhMuc
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.DinhMuc
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.DinhMuc : null,
        //                         NoiDung = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.Name_NhomDon
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.NoiDung
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.NoiDung
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///Table CHDB_ChiTietCatTams
        //        queryDonTu = from item in db.CHDB_ChiTietCatTams
        //                     where item.DanhBo == DanhBo
        //                     select new
        //                     {
        //                         MaDon = item.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.CHDB.MaDonMoi).Count() == 1 ? item.CHDB.MaDonMoi.Value.ToString() : item.CHDB.MaDonMoi + "." + item.STT
        //                             : item.CHDB.MaDon != null ? "TKH" + item.CHDB.MaDon
        //                             : item.CHDB.MaDonTXL != null ? "TXL" + item.CHDB.MaDonTXL
        //                             : item.CHDB.MaDonTBC != null ? "TBC" + item.CHDB.MaDonTBC : null,
        //                         TenLD = item.CHDB.MaDonMoi != null ? ""
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.LoaiDon.TenLD
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.LoaiDonTXL.TenLD
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.CreateDate
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.CreateDate
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.CreateDate
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.CreateDate : null,
        //                         DanhBo = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.DanhBo
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.DanhBo
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.DanhBo
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.DanhBo : null,
        //                         HoTen = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.HoTen
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.HoTen
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.HoTen
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.HoTen : null,
        //                         DiaChi = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.DiaChi
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.DiaChi
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.DiaChi
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.DiaChi : null,
        //                         GiaBieu = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.GiaBieu
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.GiaBieu
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.GiaBieu
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.DinhMuc
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.DinhMuc
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.DinhMuc
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.DinhMuc : null,
        //                         NoiDung = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.Name_NhomDon
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.NoiDung
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.NoiDung
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///Table CHDB_ChiTietCatHuys
        //        queryDonTu = from item in db.CHDB_ChiTietCatHuys
        //                     where item.DanhBo == DanhBo
        //                     select new
        //                     {
        //                         MaDon = item.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.CHDB.MaDonMoi).Count() == 1 ? item.CHDB.MaDonMoi.Value.ToString() : item.CHDB.MaDonMoi + "." + item.STT
        //                             : item.CHDB.MaDon != null ? "TKH" + item.CHDB.MaDon
        //                             : item.CHDB.MaDonTXL != null ? "TXL" + item.CHDB.MaDonTXL
        //                             : item.CHDB.MaDonTBC != null ? "TBC" + item.CHDB.MaDonTBC : null,
        //                         TenLD = item.CHDB.MaDonMoi != null ? ""
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.LoaiDon.TenLD
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.LoaiDonTXL.TenLD
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.CreateDate
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.CreateDate
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.CreateDate
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.CreateDate : null,
        //                         DanhBo = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.DanhBo
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.DanhBo
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.DanhBo
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.DanhBo : null,
        //                         HoTen = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.HoTen
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.HoTen
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.HoTen
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.HoTen : null,
        //                         DiaChi = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.DiaChi
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.DiaChi
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.DiaChi
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.DiaChi : null,
        //                         GiaBieu = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.GiaBieu
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.GiaBieu
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.GiaBieu
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.DinhMuc
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.DinhMuc
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.DinhMuc
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.DinhMuc : null,
        //                         NoiDung = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.Name_NhomDon
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.NoiDung
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.NoiDung
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///TablePhieuCHDBs
        //        queryDonTu = from item in db.CHDB_Phieus
        //                     where item.DanhBo == DanhBo
        //                     select new
        //                     {
        //                         MaDon = item.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.CHDB.MaDonMoi).Count() == 1 ? item.CHDB.MaDonMoi.Value.ToString() : item.CHDB.MaDonMoi + "." + item.STT
        //                             : item.CHDB.MaDon != null ? "TKH" + item.CHDB.MaDon
        //                             : item.CHDB.MaDonTXL != null ? "TXL" + item.CHDB.MaDonTXL
        //                             : item.CHDB.MaDonTBC != null ? "TBC" + item.CHDB.MaDonTBC : null,
        //                         TenLD = item.CHDB.MaDonMoi != null ? ""
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.LoaiDon.TenLD
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.LoaiDonTXL.TenLD
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.CreateDate
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.CreateDate
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.CreateDate
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.CreateDate : null,
        //                         DanhBo = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.DanhBo
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.DanhBo
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.DanhBo
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.DanhBo : null,
        //                         HoTen = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.HoTen
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.HoTen
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.HoTen
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.HoTen : null,
        //                         DiaChi = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.DiaChi
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.DiaChi
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.DiaChi
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.DiaChi : null,
        //                         GiaBieu = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.GiaBieu
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.GiaBieu
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.GiaBieu
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.DinhMuc
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.DinhMuc
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.DinhMuc
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.DinhMuc : null,
        //                         NoiDung = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.Name_NhomDon
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.NoiDung
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.NoiDung
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///Table ThuTraLoi_ChiTiets
        //        queryDonTu = from item in db.ThuTraLoi_ChiTiets
        //                     where item.DanhBo == DanhBo
        //                     select new
        //                     {
        //                         MaDon = item.ThuTraLoi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.ThuTraLoi.MaDonMoi).Count() == 1 ? item.ThuTraLoi.MaDonMoi.Value.ToString() : item.ThuTraLoi.MaDonMoi + "." + item.STT
        //                            : item.ThuTraLoi.MaDon != null ? "TKH" + item.ThuTraLoi.MaDon
        //                            : item.ThuTraLoi.MaDonTXL != null ? "TXL" + item.ThuTraLoi.MaDonTXL
        //                            : item.ThuTraLoi.MaDonTBC != null ? "TBC" + item.ThuTraLoi.MaDonTBC : null,
        //                         TenLD = item.ThuTraLoi.MaDonMoi != null ? ""
        //                            : item.ThuTraLoi.MaDon != null ? item.ThuTraLoi.DonKH.LoaiDon.TenLD
        //                            : item.ThuTraLoi.MaDonTXL != null ? item.ThuTraLoi.DonTXL.LoaiDonTXL.TenLD
        //                            : item.ThuTraLoi.MaDonTBC != null ? item.ThuTraLoi.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.ThuTraLoi.MaDonMoi != null ? item.ThuTraLoi.DonTu.CreateDate
        //                            : item.ThuTraLoi.MaDon != null ? item.ThuTraLoi.DonKH.CreateDate
        //                            : item.ThuTraLoi.MaDonTXL != null ? item.ThuTraLoi.DonTXL.CreateDate
        //                            : item.ThuTraLoi.MaDonTBC != null ? item.ThuTraLoi.DonTBC.CreateDate : null,
        //                         DanhBo = item.ThuTraLoi.MaDonMoi != null ? item.ThuTraLoi.DonTu.DanhBo
        //                            : item.ThuTraLoi.MaDon != null ? item.ThuTraLoi.DonKH.DanhBo
        //                            : item.ThuTraLoi.MaDonTXL != null ? item.ThuTraLoi.DonTXL.DanhBo
        //                            : item.ThuTraLoi.MaDonTBC != null ? item.ThuTraLoi.DonTBC.DanhBo : null,
        //                         HoTen = item.ThuTraLoi.MaDonMoi != null ? item.ThuTraLoi.DonTu.HoTen
        //                            : item.ThuTraLoi.MaDon != null ? item.ThuTraLoi.DonKH.HoTen
        //                            : item.ThuTraLoi.MaDonTXL != null ? item.ThuTraLoi.DonTXL.HoTen
        //                            : item.ThuTraLoi.MaDonTBC != null ? item.ThuTraLoi.DonTBC.HoTen : null,
        //                         DiaChi = item.ThuTraLoi.MaDonMoi != null ? item.ThuTraLoi.DonTu.DiaChi
        //                            : item.ThuTraLoi.MaDon != null ? item.ThuTraLoi.DonKH.DiaChi
        //                            : item.ThuTraLoi.MaDonTXL != null ? item.ThuTraLoi.DonTXL.DiaChi
        //                            : item.ThuTraLoi.MaDonTBC != null ? item.ThuTraLoi.DonTBC.DiaChi : null,
        //                         GiaBieu = item.ThuTraLoi.MaDonMoi != null ? item.ThuTraLoi.DonTu.GiaBieu
        //                            : item.ThuTraLoi.MaDon != null ? item.ThuTraLoi.DonKH.GiaBieu
        //                            : item.ThuTraLoi.MaDonTXL != null ? item.ThuTraLoi.DonTXL.GiaBieu
        //                            : item.ThuTraLoi.MaDonTBC != null ? item.ThuTraLoi.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.ThuTraLoi.MaDonMoi != null ? item.ThuTraLoi.DonTu.DinhMuc
        //                            : item.ThuTraLoi.MaDon != null ? item.ThuTraLoi.DonKH.DinhMuc
        //                            : item.ThuTraLoi.MaDonTXL != null ? item.ThuTraLoi.DonTXL.DinhMuc
        //                            : item.ThuTraLoi.MaDonTBC != null ? item.ThuTraLoi.DonTBC.DinhMuc : null,
        //                         NoiDung = item.ThuTraLoi.MaDonMoi != null ? item.ThuTraLoi.DonTu.Name_NhomDon
        //                            : item.ThuTraLoi.MaDon != null ? item.ThuTraLoi.DonKH.NoiDung
        //                            : item.ThuTraLoi.MaDonTXL != null ? item.ThuTraLoi.DonTXL.NoiDung
        //                            : item.ThuTraLoi.MaDonTBC != null ? item.ThuTraLoi.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///Table GianLan_ChiTiets
        //        queryDonTu = from item in db.GianLan_ChiTiets
        //                     where item.DanhBo == DanhBo
        //                     select new
        //                     {
        //                         MaDon = item.GianLan.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.GianLan.MaDonMoi).Count() == 1 ? item.GianLan.MaDonMoi.Value.ToString() : item.GianLan.MaDonMoi + "." + item.STT
        //                            : item.GianLan.MaDon != null ? "TKH" + item.GianLan.MaDon
        //                            : item.GianLan.MaDonTXL != null ? "TXL" + item.GianLan.MaDonTXL
        //                            : item.GianLan.MaDonTBC != null ? "TBC" + item.GianLan.MaDonTBC : null,
        //                         TenLD = item.GianLan.MaDonMoi != null ? ""
        //                            : item.GianLan.MaDon != null ? item.GianLan.DonKH.LoaiDon.TenLD
        //                            : item.GianLan.MaDonTXL != null ? item.GianLan.DonTXL.LoaiDonTXL.TenLD
        //                            : item.GianLan.MaDonTBC != null ? item.GianLan.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.GianLan.MaDonMoi != null ? item.GianLan.DonTu.CreateDate
        //                            : item.GianLan.MaDon != null ? item.GianLan.DonKH.CreateDate
        //                            : item.GianLan.MaDonTXL != null ? item.GianLan.DonTXL.CreateDate
        //                            : item.GianLan.MaDonTBC != null ? item.GianLan.DonTBC.CreateDate : null,
        //                         DanhBo = item.GianLan.MaDonMoi != null ? item.GianLan.DonTu.DanhBo
        //                            : item.GianLan.MaDon != null ? item.GianLan.DonKH.DanhBo
        //                            : item.GianLan.MaDonTXL != null ? item.GianLan.DonTXL.DanhBo
        //                            : item.GianLan.MaDonTBC != null ? item.GianLan.DonTBC.DanhBo : null,
        //                         HoTen = item.GianLan.MaDonMoi != null ? item.GianLan.DonTu.HoTen
        //                            : item.GianLan.MaDon != null ? item.GianLan.DonKH.HoTen
        //                            : item.GianLan.MaDonTXL != null ? item.GianLan.DonTXL.HoTen
        //                            : item.GianLan.MaDonTBC != null ? item.GianLan.DonTBC.HoTen : null,
        //                         DiaChi = item.GianLan.MaDonMoi != null ? item.GianLan.DonTu.DiaChi
        //                            : item.GianLan.MaDon != null ? item.GianLan.DonKH.DiaChi
        //                            : item.GianLan.MaDonTXL != null ? item.GianLan.DonTXL.DiaChi
        //                            : item.GianLan.MaDonTBC != null ? item.GianLan.DonTBC.DiaChi : null,
        //                         GiaBieu = item.GianLan.MaDonMoi != null ? item.GianLan.DonTu.GiaBieu
        //                            : item.GianLan.MaDon != null ? item.GianLan.DonKH.GiaBieu
        //                            : item.GianLan.MaDonTXL != null ? item.GianLan.DonTXL.GiaBieu
        //                            : item.GianLan.MaDonTBC != null ? item.GianLan.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.GianLan.MaDonMoi != null ? item.GianLan.DonTu.DinhMuc
        //                            : item.GianLan.MaDon != null ? item.GianLan.DonKH.DinhMuc
        //                            : item.GianLan.MaDonTXL != null ? item.GianLan.DonTXL.DinhMuc
        //                            : item.GianLan.MaDonTBC != null ? item.GianLan.DonTBC.DinhMuc : null,
        //                         NoiDung = item.GianLan.MaDonMoi != null ? item.GianLan.DonTu.Name_NhomDon
        //                            : item.GianLan.MaDon != null ? item.GianLan.DonKH.NoiDung
        //                            : item.GianLan.MaDonTXL != null ? item.GianLan.DonTXL.NoiDung
        //                            : item.GianLan.MaDonTBC != null ? item.GianLan.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///Table TruyThu
        //        queryDonTu = from item in db.TruyThuTienNuoc_ChiTiets
        //                     where item.DanhBo == DanhBo
        //                     select new
        //                     {
        //                         MaDon = item.TruyThuTienNuoc.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.TruyThuTienNuoc.MaDonMoi).Count() == 1 ? item.TruyThuTienNuoc.MaDonMoi.Value.ToString() : item.TruyThuTienNuoc.MaDonMoi + "." + item.STT
        //                            : item.TruyThuTienNuoc.MaDon != null ? "TKH" + item.TruyThuTienNuoc.MaDon
        //                            : item.TruyThuTienNuoc.MaDonTXL != null ? "TXL" + item.TruyThuTienNuoc.MaDonTXL
        //                            : item.TruyThuTienNuoc.MaDonTBC != null ? "TBC" + item.TruyThuTienNuoc.MaDonTBC : null,
        //                         TenLD = item.TruyThuTienNuoc.MaDonMoi != null ? ""
        //                            : item.TruyThuTienNuoc.MaDon != null ? item.TruyThuTienNuoc.DonKH.LoaiDon.TenLD
        //                            : item.TruyThuTienNuoc.MaDonTXL != null ? item.TruyThuTienNuoc.DonTXL.LoaiDonTXL.TenLD
        //                            : item.TruyThuTienNuoc.MaDonTBC != null ? item.TruyThuTienNuoc.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.TruyThuTienNuoc.MaDonMoi != null ? item.TruyThuTienNuoc.DonTu.CreateDate
        //                            : item.TruyThuTienNuoc.MaDon != null ? item.TruyThuTienNuoc.DonKH.CreateDate
        //                            : item.TruyThuTienNuoc.MaDonTXL != null ? item.TruyThuTienNuoc.DonTXL.CreateDate
        //                            : item.TruyThuTienNuoc.MaDonTBC != null ? item.TruyThuTienNuoc.DonTBC.CreateDate : null,
        //                         DanhBo = item.TruyThuTienNuoc.MaDonMoi != null ? item.TruyThuTienNuoc.DonTu.DanhBo
        //                            : item.TruyThuTienNuoc.MaDon != null ? item.TruyThuTienNuoc.DonKH.DanhBo
        //                            : item.TruyThuTienNuoc.MaDonTXL != null ? item.TruyThuTienNuoc.DonTXL.DanhBo
        //                            : item.TruyThuTienNuoc.MaDonTBC != null ? item.TruyThuTienNuoc.DonTBC.DanhBo : null,
        //                         HoTen = item.TruyThuTienNuoc.MaDonMoi != null ? item.TruyThuTienNuoc.DonTu.HoTen
        //                            : item.TruyThuTienNuoc.MaDon != null ? item.TruyThuTienNuoc.DonKH.HoTen
        //                            : item.TruyThuTienNuoc.MaDonTXL != null ? item.TruyThuTienNuoc.DonTXL.HoTen
        //                            : item.TruyThuTienNuoc.MaDonTBC != null ? item.TruyThuTienNuoc.DonTBC.HoTen : null,
        //                         DiaChi = item.TruyThuTienNuoc.MaDonMoi != null ? item.TruyThuTienNuoc.DonTu.DiaChi
        //                            : item.TruyThuTienNuoc.MaDon != null ? item.TruyThuTienNuoc.DonKH.DiaChi
        //                            : item.TruyThuTienNuoc.MaDonTXL != null ? item.TruyThuTienNuoc.DonTXL.DiaChi
        //                            : item.TruyThuTienNuoc.MaDonTBC != null ? item.TruyThuTienNuoc.DonTBC.DiaChi : null,
        //                         GiaBieu = item.TruyThuTienNuoc.MaDonMoi != null ? item.TruyThuTienNuoc.DonTu.GiaBieu
        //                            : item.TruyThuTienNuoc.MaDon != null ? item.TruyThuTienNuoc.DonKH.GiaBieu
        //                            : item.TruyThuTienNuoc.MaDonTXL != null ? item.TruyThuTienNuoc.DonTXL.GiaBieu
        //                            : item.TruyThuTienNuoc.MaDonTBC != null ? item.TruyThuTienNuoc.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.TruyThuTienNuoc.MaDonMoi != null ? item.TruyThuTienNuoc.DonTu.DinhMuc
        //                            : item.TruyThuTienNuoc.MaDon != null ? item.TruyThuTienNuoc.DonKH.DinhMuc
        //                            : item.TruyThuTienNuoc.MaDonTXL != null ? item.TruyThuTienNuoc.DonTXL.DinhMuc
        //                            : item.TruyThuTienNuoc.MaDonTBC != null ? item.TruyThuTienNuoc.DonTBC.DinhMuc : null,
        //                         NoiDung = item.TruyThuTienNuoc.MaDonMoi != null ? item.TruyThuTienNuoc.DonTu.Name_NhomDon
        //                            : item.TruyThuTienNuoc.MaDon != null ? item.TruyThuTienNuoc.DonKH.NoiDung
        //                            : item.TruyThuTienNuoc.MaDonTXL != null ? item.TruyThuTienNuoc.DonTXL.NoiDung
        //                            : item.TruyThuTienNuoc.MaDonTBC != null ? item.TruyThuTienNuoc.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///Table ToTrinh
        //        queryDonTu = from item in db.ToTrinh_ChiTiets
        //                     where item.DanhBo == DanhBo
        //                     select new
        //                     {
        //                         MaDon = item.ToTrinh.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.ToTrinh.MaDonMoi).Count() == 1 ? item.ToTrinh.MaDonMoi.Value.ToString() : item.ToTrinh.MaDonMoi + "." + item.STT
        //                             : item.ToTrinh.MaDon != null ? "TKH" + item.ToTrinh.MaDon
        //                             : item.ToTrinh.MaDonTXL != null ? "TXL" + item.ToTrinh.MaDonTXL
        //                             : item.ToTrinh.MaDonTBC != null ? "TBC" + item.ToTrinh.MaDonTBC : null,
        //                         TenLD = item.ToTrinh.MaDonMoi != null ? ""
        //                            : item.ToTrinh.MaDon != null ? item.ToTrinh.DonKH.LoaiDon.TenLD
        //                            : item.ToTrinh.MaDonTXL != null ? item.ToTrinh.DonTXL.LoaiDonTXL.TenLD
        //                            : item.ToTrinh.MaDonTBC != null ? item.ToTrinh.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.ToTrinh.MaDonMoi != null ? item.ToTrinh.DonTu.CreateDate
        //                            : item.ToTrinh.MaDon != null ? item.ToTrinh.DonKH.CreateDate
        //                            : item.ToTrinh.MaDonTXL != null ? item.ToTrinh.DonTXL.CreateDate
        //                            : item.ToTrinh.MaDonTBC != null ? item.ToTrinh.DonTBC.CreateDate : null,
        //                         DanhBo = item.ToTrinh.MaDonMoi != null ? item.ToTrinh.DonTu.DanhBo
        //                            : item.ToTrinh.MaDon != null ? item.ToTrinh.DonKH.DanhBo
        //                            : item.ToTrinh.MaDonTXL != null ? item.ToTrinh.DonTXL.DanhBo
        //                            : item.ToTrinh.MaDonTBC != null ? item.ToTrinh.DonTBC.DanhBo : null,
        //                         HoTen = item.ToTrinh.MaDonMoi != null ? item.ToTrinh.DonTu.HoTen
        //                            : item.ToTrinh.MaDon != null ? item.ToTrinh.DonKH.HoTen
        //                            : item.ToTrinh.MaDonTXL != null ? item.ToTrinh.DonTXL.HoTen
        //                            : item.ToTrinh.MaDonTBC != null ? item.ToTrinh.DonTBC.HoTen : null,
        //                         DiaChi = item.ToTrinh.MaDonMoi != null ? item.ToTrinh.DonTu.DiaChi
        //                            : item.ToTrinh.MaDon != null ? item.ToTrinh.DonKH.DiaChi
        //                            : item.ToTrinh.MaDonTXL != null ? item.ToTrinh.DonTXL.DiaChi
        //                            : item.ToTrinh.MaDonTBC != null ? item.ToTrinh.DonTBC.DiaChi : null,
        //                         GiaBieu = item.ToTrinh.MaDonMoi != null ? item.ToTrinh.DonTu.GiaBieu
        //                            : item.ToTrinh.MaDon != null ? item.ToTrinh.DonKH.GiaBieu
        //                            : item.ToTrinh.MaDonTXL != null ? item.ToTrinh.DonTXL.GiaBieu
        //                            : item.ToTrinh.MaDonTBC != null ? item.ToTrinh.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.ToTrinh.MaDonMoi != null ? item.ToTrinh.DonTu.DinhMuc
        //                            : item.ToTrinh.MaDon != null ? item.ToTrinh.DonKH.DinhMuc
        //                            : item.ToTrinh.MaDonTXL != null ? item.ToTrinh.DonTXL.DinhMuc
        //                            : item.ToTrinh.MaDonTBC != null ? item.ToTrinh.DonTBC.DinhMuc : null,
        //                         NoiDung = item.ToTrinh.MaDonMoi != null ? item.ToTrinh.DonTu.Name_NhomDon
        //                            : item.ToTrinh.MaDon != null ? item.ToTrinh.DonKH.NoiDung
        //                            : item.ToTrinh.MaDonTXL != null ? item.ToTrinh.DonTXL.NoiDung
        //                            : item.ToTrinh.MaDonTBC != null ? item.ToTrinh.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///Table ThuMoi
        //        queryDonTu = from item in db.ThuMoi_ChiTiets
        //                     where item.DanhBo == DanhBo
        //                     select new
        //                     {
        //                         MaDon = item.ThuMoi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.ThuMoi.MaDonMoi).Count() == 1 ? item.ThuMoi.MaDonMoi.Value.ToString() : item.ThuMoi.MaDonMoi + "." + item.STT
        //                            : item.ThuMoi.MaDonTKH != null ? "TKH" + item.ThuMoi.MaDonTKH
        //                            : item.ThuMoi.MaDonTXL != null ? "TXL" + item.ThuMoi.MaDonTXL
        //                            : item.ThuMoi.MaDonTBC != null ? "TBC" + item.ThuMoi.MaDonTBC : null,
        //                         TenLD = item.ThuMoi.MaDonMoi != null ? ""
        //                            : item.ThuMoi.MaDonTKH != null ? item.ThuMoi.DonKH.LoaiDon.TenLD
        //                            : item.ThuMoi.MaDonTXL != null ? item.ThuMoi.DonTXL.LoaiDonTXL.TenLD
        //                            : item.ThuMoi.MaDonTBC != null ? item.ThuMoi.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.ThuMoi.MaDonMoi != null ? item.ThuMoi.DonTu.CreateDate
        //                            : item.ThuMoi.MaDonTKH != null ? item.ThuMoi.DonKH.CreateDate
        //                            : item.ThuMoi.MaDonTXL != null ? item.ThuMoi.DonTXL.CreateDate
        //                            : item.ThuMoi.MaDonTBC != null ? item.ThuMoi.DonTBC.CreateDate : null,
        //                         DanhBo = item.ThuMoi.MaDonMoi != null ? item.ThuMoi.DonTu.DanhBo
        //                            : item.ThuMoi.MaDonTKH != null ? item.ThuMoi.DonKH.DanhBo
        //                            : item.ThuMoi.MaDonTXL != null ? item.ThuMoi.DonTXL.DanhBo
        //                            : item.ThuMoi.MaDonTBC != null ? item.ThuMoi.DonTBC.DanhBo : null,
        //                         HoTen = item.ThuMoi.MaDonMoi != null ? item.ThuMoi.DonTu.HoTen
        //                            : item.ThuMoi.MaDonTKH != null ? item.ThuMoi.DonKH.HoTen
        //                            : item.ThuMoi.MaDonTXL != null ? item.ThuMoi.DonTXL.HoTen
        //                            : item.ThuMoi.MaDonTBC != null ? item.ThuMoi.DonTBC.HoTen : null,
        //                         DiaChi = item.ThuMoi.MaDonMoi != null ? item.ThuMoi.DonTu.DiaChi
        //                            : item.ThuMoi.MaDonTKH != null ? item.ThuMoi.DonKH.DiaChi
        //                            : item.ThuMoi.MaDonTXL != null ? item.ThuMoi.DonTXL.DiaChi
        //                            : item.ThuMoi.MaDonTBC != null ? item.ThuMoi.DonTBC.DiaChi : null,
        //                         GiaBieu = item.ThuMoi.MaDonMoi != null ? item.ThuMoi.DonTu.GiaBieu
        //                            : item.ThuMoi.MaDonTKH != null ? item.ThuMoi.DonKH.GiaBieu
        //                            : item.ThuMoi.MaDonTXL != null ? item.ThuMoi.DonTXL.GiaBieu
        //                            : item.ThuMoi.MaDonTBC != null ? item.ThuMoi.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.ThuMoi.MaDonMoi != null ? item.ThuMoi.DonTu.DinhMuc
        //                            : item.ThuMoi.MaDonTKH != null ? item.ThuMoi.DonKH.DinhMuc
        //                            : item.ThuMoi.MaDonTXL != null ? item.ThuMoi.DonTXL.DinhMuc
        //                            : item.ThuMoi.MaDonTBC != null ? item.ThuMoi.DonTBC.DinhMuc : null,
        //                         NoiDung = item.ThuMoi.MaDonMoi != null ? item.ThuMoi.DonTu.Name_NhomDon
        //                            : item.ThuMoi.MaDonTKH != null ? item.ThuMoi.DonKH.NoiDung
        //                            : item.ThuMoi.MaDonTXL != null ? item.ThuMoi.DonTXL.NoiDung
        //                            : item.ThuMoi.MaDonTBC != null ? item.ThuMoi.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        #endregion

        //        DataTable dtDon = new DataTable();
        //        dtDon.Columns.Add("MaDon", typeof(string));
        //        dtDon.Columns.Add("TenLD", typeof(string));
        //        dtDon.Columns.Add("CreateDate", typeof(DateTime));
        //        dtDon.Columns.Add("DanhBo", typeof(string));
        //        dtDon.Columns.Add("HoTen", typeof(string));
        //        dtDon.Columns.Add("DiaChi", typeof(string));
        //        dtDon.Columns.Add("GiaBieu", typeof(string));
        //        dtDon.Columns.Add("DinhMuc", typeof(string));
        //        dtDon.Columns.Add("NoiDung", typeof(string));
        //        dtDon.TableName = "DonTu";

        //        foreach (DataRow itemRow in dt.Rows)
        //        {
        //            if (dtDon.Select("MaDon = '" + itemRow["MaDon"] + "'").Count() <= 0)
        //                dtDon.ImportRow(itemRow);
        //        }

        //        dtDon.DefaultView.Sort = "CreateDate ASC";
        //        ds.Tables.Add(dtDon.DefaultView.ToTable());

        //        if (dtDon.Rows.Count > 0 && dtKTXM.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Kiểm Tra Xác Minh", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["KTXM"].Columns["MaDon"]);

        //        if (dtDon.Rows.Count > 0 && dtBamChi.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Bấm Chì", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["BamChi"].Columns["MaDon"]);

        //        if (dtDon.Rows.Count > 0 && dtDongNuoc.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Đóng Nước", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["DongNuoc"].Columns["MaDon"]);

        //        if (dtDon.Rows.Count > 0 && dtDCBD.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Điều Chỉnh Biến Động", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["DCBD"].Columns["MaDon"]);

        //        if (dtDon.Rows.Count > 0 && dtCHDB.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Cắt Tạm/Hủy Danh Bộ", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["CHDB"].Columns["MaDon"]);

        //        if (dtDon.Rows.Count > 0 && dtPhieuCHDB.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Phiếu Hủy Danh Bộ", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["PhieuCHDB"].Columns["MaDon"]);

        //        if (dtDon.Rows.Count > 0 && dtTTTL.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["ThuTraLoi"].Columns["MaDon"]);

        //        if (dtDon.Rows.Count > 0 && dtGianLan.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Gian Lận", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["GianLan"].Columns["MaDon"]);

        //        if (dtDon.Rows.Count > 0 && dtTruyThu.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Truy Thu", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["TruyThu"].Columns["MaDon"]);

        //        if (dtDon.Rows.Count > 0 && dtToTrinh.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Tờ Trình", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["ToTrinh"].Columns["MaDon"]);

        //        if (dtDon.Rows.Count > 0 && dtThuMoi.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Thư Mời", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["ThuMoi"].Columns["MaDon"]);

        //        if (dtDon.Rows.Count > 0 && dtTienTrinh.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Tiến Trình", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["TienTrinh"].Columns["MaDon"]);

        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return null;
        //    }
        //}

        //public DataSet GetTienTrinhByHoTen(string HoTen)
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();

        //        #region HoTen

        //        ///Table CTKTXM
        //        var queryKTXM = from itemCTKTXM in db.KTXM_ChiTiets
        //                        join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
        //                        where itemCTKTXM.HoTen.Contains(HoTen)
        //                        select new
        //                        {
        //                            MaDon = itemCTKTXM.KTXM.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTKTXM.KTXM.MaDonMoi).Count() == 1 ? itemCTKTXM.KTXM.MaDonMoi.Value.ToString() : itemCTKTXM.KTXM.MaDonMoi + "." + itemCTKTXM.STT
        //                              : itemCTKTXM.KTXM.MaDon != null ? "TKH" + itemCTKTXM.KTXM.MaDon
        //                            : itemCTKTXM.KTXM.MaDonTXL != null ? "TXL" + itemCTKTXM.KTXM.MaDonTXL
        //                            : itemCTKTXM.KTXM.MaDonTBC != null ? "TBC" + itemCTKTXM.KTXM.MaDonTBC : null,
        //                            itemCTKTXM.MaCTKTXM,
        //                            itemCTKTXM.NgayKTXM,
        //                            itemCTKTXM.DanhBo,
        //                            itemCTKTXM.HoTen,
        //                            itemCTKTXM.DiaChi,
        //                            itemCTKTXM.NoiDungKiemTra,
        //                            CreateBy = itemUser.HoTen,
        //                            itemCTKTXM.NoiDungDongTien,
        //                            itemCTKTXM.NgayDongTien,
        //                            itemCTKTXM.SoTienDongTien,itemCTKTXM.BanChinh,
        //                        };
        //        DataTable dtKTXM = new DataTable();
        //        dtKTXM = LINQToDataTable(queryKTXM);
        //        dtKTXM.TableName = "KTXM";
        //        ds.Tables.Add(dtKTXM);

        //        ///Table CTBamChi
        //        var queryBamChi = from itemCTBamChi in db.BamChi_ChiTiets
        //                          join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
        //                          where itemCTBamChi.HoTen.Contains(HoTen)
        //                          select new
        //                          {
        //                              MaDon = itemCTBamChi.BamChi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTBamChi.BamChi.MaDonMoi).Count() == 1 ? itemCTBamChi.BamChi.MaDonMoi.Value.ToString() : itemCTBamChi.BamChi.MaDonMoi + "." + itemCTBamChi.STT
        //                              : itemCTBamChi.BamChi.MaDon != null ? "TKH" + itemCTBamChi.BamChi.MaDon
        //                            : itemCTBamChi.BamChi.MaDonTXL != null ? "TXL" + itemCTBamChi.BamChi.MaDonTXL
        //                            : itemCTBamChi.BamChi.MaDonTBC != null ? "TBC" + itemCTBamChi.BamChi.MaDonTBC : null,
        //                              itemCTBamChi.MaCTBC,
        //                              itemCTBamChi.NgayBC,
        //                              itemCTBamChi.DanhBo,
        //                              itemCTBamChi.HoTen,
        //                              itemCTBamChi.DiaChi,
        //                              itemCTBamChi.TrangThaiBC,
        //                              itemCTBamChi.TheoYeuCau,
        //                              itemCTBamChi.MaSoBC,
        //                              CreateBy = itemUser.HoTen,
        //                          };

        //        DataTable dtBamChi = new DataTable();
        //        dtBamChi = LINQToDataTable(queryBamChi);
        //        dtBamChi.TableName = "BamChi";
        //        ds.Tables.Add(dtBamChi);

        //        ///Table CTDongNuoc
        //        var queryDongNuoc = from itemCTDongNuoc in db.DongNuoc_ChiTiets
        //                            join itemUser in db.Users on itemCTDongNuoc.CreateBy equals itemUser.MaU
        //                            where itemCTDongNuoc.HoTen.Contains(HoTen)
        //                            select new
        //                            {
        //                                MaDon = itemCTDongNuoc.DongNuoc.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTDongNuoc.DongNuoc.MaDonMoi).Count() == 1 ? itemCTDongNuoc.DongNuoc.MaDonMoi.Value.ToString() : itemCTDongNuoc.DongNuoc.MaDonMoi + "." + itemCTDongNuoc.STT
        //                              : itemCTDongNuoc.DongNuoc.MaDon != null ? "TKH" + itemCTDongNuoc.DongNuoc.MaDon
        //                             : itemCTDongNuoc.DongNuoc.MaDonTXL != null ? "TXL" + itemCTDongNuoc.DongNuoc.MaDonTXL
        //                             : itemCTDongNuoc.DongNuoc.MaDonTBC != null ? "TBC" + itemCTDongNuoc.DongNuoc.MaDonTBC : null,
        //                                itemCTDongNuoc.MaCTDN,
        //                                itemCTDongNuoc.NgayDN,
        //                                itemCTDongNuoc.DanhBo,
        //                                itemCTDongNuoc.HoTen,
        //                                itemCTDongNuoc.DiaChi,
        //                                itemCTDongNuoc.MaCTMN,
        //                                itemCTDongNuoc.NgayMN,
        //                                CreateBy = itemUser.HoTen,
        //                            };

        //        DataTable dtDongNuoc = new DataTable();
        //        dtDongNuoc = LINQToDataTable(queryDongNuoc);
        //        dtDongNuoc.TableName = "DongNuoc";
        //        ds.Tables.Add(dtDongNuoc);

        //        ///Table CTDCBD
        //        var queryCTDCBD = from itemCTDCBD in db.DCBD_ChiTietBienDongs
        //                          join itemUser in db.Users on itemCTDCBD.CreateBy equals itemUser.MaU
        //                          where itemCTDCBD.HoTen.Contains(HoTen)
        //                          select new
        //                          {
        //                              MaDon = itemCTDCBD.DCBD.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTDCBD.DCBD.MaDonMoi).Count() == 1 ? itemCTDCBD.DCBD.MaDonMoi.Value.ToString() : itemCTDCBD.DCBD.MaDonMoi + "." + itemCTDCBD.STT
        //                              : itemCTDCBD.DCBD.MaDon != null ? "TKH" + itemCTDCBD.DCBD.MaDon
        //                           : itemCTDCBD.DCBD.MaDonTXL != null ? "TXL" + itemCTDCBD.DCBD.MaDonTXL
        //                           : itemCTDCBD.DCBD.MaDonTBC != null ? "TBC" + itemCTDCBD.DCBD.MaDonTBC : null,
        //                              MaDC = itemCTDCBD.MaCTDCBD,
        //                              DieuChinh = "Biến Động",
        //                              itemCTDCBD.CreateDate,
        //                              itemCTDCBD.ThongTin,
        //                              itemCTDCBD.DanhBo,
        //                              itemCTDCBD.HoTen_BD,
        //                              itemCTDCBD.DiaChi_BD,
        //                              itemCTDCBD.MSThue_BD,
        //                              itemCTDCBD.GiaBieu_BD,
        //                              itemCTDCBD.DinhMuc_BD,
        //                              itemCTDCBD.HoTen,
        //                              itemCTDCBD.DiaChi,
        //                              itemCTDCBD.MSThue,
        //                              itemCTDCBD.GiaBieu,
        //                              itemCTDCBD.DinhMuc,
        //                              CreateBy = itemUser.HoTen,
        //                          };

        //        ///Bảng CTDCHD
        //        var queryCTDCHD = from itemCTDCHD in db.DCBD_ChiTietHoaDons
        //                          join itemUser in db.Users on itemCTDCHD.CreateBy equals itemUser.MaU
        //                          where itemCTDCHD.HoTen.Contains(HoTen)
        //                          select new
        //                          {
        //                              MaDon = itemCTDCHD.DCBD.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTDCHD.DCBD.MaDonMoi).Count() == 1 ? itemCTDCHD.DCBD.MaDonMoi.Value.ToString() : itemCTDCHD.DCBD.MaDonMoi + "." + itemCTDCHD.STT
        //                              : itemCTDCHD.DCBD.MaDon != null ? "TKH" + itemCTDCHD.DCBD.MaDon
        //                             : itemCTDCHD.DCBD.MaDonTXL != null ? "TXL" + itemCTDCHD.DCBD.MaDonTXL
        //                             : itemCTDCHD.DCBD.MaDonTBC != null ? "TBC" + itemCTDCHD.DCBD.MaDonTBC : null,
        //                              MaDC = itemCTDCHD.MaCTDCHD,
        //                              DieuChinh = "Hóa Đơn",
        //                              itemCTDCHD.CreateDate,
        //                              itemCTDCHD.DanhBo,
        //                              itemCTDCHD.HoTen,
        //                              itemCTDCHD.DiaChi,
        //                              itemCTDCHD.GiaBieu,
        //                              itemCTDCHD.GiaBieu_BD,
        //                              itemCTDCHD.DinhMuc,
        //                              itemCTDCHD.DinhMuc_BD,
        //                              itemCTDCHD.TieuThu,
        //                              itemCTDCHD.TieuThu_BD,
        //                              itemCTDCHD.TongCong_Start,
        //                              itemCTDCHD.TongCong_End,
        //                              itemCTDCHD.TangGiam,
        //                              itemCTDCHD.TongCong_BD,
        //                              CreateBy = itemUser.HoTen,
        //                          };
        //        DataTable dtDCBD = new DataTable();
        //        dtDCBD = LINQToDataTable(queryCTDCBD);
        //        dtDCBD.Merge(LINQToDataTable(queryCTDCHD));
        //        dtDCBD.TableName = "DCBD";
        //        ds.Tables.Add(dtDCBD);

        //        ///Table CTCTDB
        //        var queryCTCTDB = from itemCTCTDB in db.CHDB_ChiTietCatTams
        //                          where itemCTCTDB.HoTen.Contains(HoTen)
        //                          select new
        //                          {
        //                              MaDon = itemCTCTDB.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTCTDB.CHDB.MaDonMoi).Count() == 1 ? itemCTCTDB.CHDB.MaDonMoi.Value.ToString() : itemCTCTDB.CHDB.MaDonMoi + "." + itemCTCTDB.STT
        //                              : itemCTCTDB.CHDB.MaDon != null ? "TKH" + itemCTCTDB.CHDB.MaDon
        //                           : itemCTCTDB.CHDB.MaDonTXL != null ? "TXL" + itemCTCTDB.CHDB.MaDonTXL
        //                           : itemCTCTDB.CHDB.MaDonTBC != null ? "TBC" + itemCTCTDB.CHDB.MaDonTBC : null,
        //                              MaCH = itemCTCTDB.MaCTCTDB,
        //                              LoaiCat = "Cắt Tạm",
        //                              itemCTCTDB.CreateDate,
        //                              itemCTCTDB.DanhBo,
        //                              itemCTCTDB.HoTen,
        //                              itemCTCTDB.DiaChi,
        //                              itemCTCTDB.LyDo,
        //                              itemCTCTDB.GhiChuLyDo,
        //                              itemCTCTDB.DaLapPhieu,
        //                              itemCTCTDB.SoPhieu,
        //                              itemCTCTDB.NgayLapPhieu,
        //                          };

        //        ///Table CHDB_ChiTietCatHuy
        //        var queryCTCHDB = from itemCTCHDB in db.CHDB_ChiTietCatHuys
        //                          where itemCTCHDB.HoTen.Contains(HoTen)
        //                          select new
        //                          {
        //                              MaDon = itemCTCHDB.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTCHDB.CHDB.MaDonMoi).Count() == 1 ? itemCTCHDB.CHDB.MaDonMoi.Value.ToString() : itemCTCHDB.CHDB.MaDonMoi + "." + itemCTCHDB.STT
        //                              : itemCTCHDB.CHDB.MaDon != null ? "TKH" + itemCTCHDB.CHDB.MaDon
        //                           : itemCTCHDB.CHDB.MaDonTXL != null ? "TXL" + itemCTCHDB.CHDB.MaDonTXL
        //                           : itemCTCHDB.CHDB.MaDonTBC != null ? "TBC" + itemCTCHDB.CHDB.MaDonTBC : null,
        //                              MaCH = itemCTCHDB.MaCTCHDB,
        //                              LoaiCat = "Cắt Hủy",
        //                              itemCTCHDB.CreateDate,
        //                              itemCTCHDB.DanhBo,
        //                              itemCTCHDB.HoTen,
        //                              itemCTCHDB.DiaChi,
        //                              itemCTCHDB.LyDo,
        //                              itemCTCHDB.GhiChuLyDo,
        //                              itemCTCHDB.DaLapPhieu,
        //                              itemCTCHDB.SoPhieu,
        //                              itemCTCHDB.NgayLapPhieu,
        //                          };
        //        DataTable dtCHDB = new DataTable();
        //        dtCHDB = LINQToDataTable(queryCTCTDB);
        //        dtCHDB.Merge(LINQToDataTable(queryCTCHDB));
        //        dtCHDB.TableName = "CHDB";
        //        ds.Tables.Add(dtCHDB);

        //        ///Table PhieuCHDB
        //        var queryPhieuCHDB = from itemYCCHDB in db.CHDB_Phieus
        //                             where itemYCCHDB.HoTen.Contains(HoTen)
        //                             select new
        //                             {
        //                                 MaDon = itemYCCHDB.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemYCCHDB.CHDB.MaDonMoi).Count() == 1 ? itemYCCHDB.CHDB.MaDonMoi.Value.ToString() : itemYCCHDB.CHDB.MaDonMoi + "." + itemYCCHDB.STT
        //                                 : itemYCCHDB.CHDB.MaDon != null ? "TKH" + itemYCCHDB.CHDB.MaDonTXL
        //                                 : itemYCCHDB.CHDB.MaDonTXL != null ? "TXL" + itemYCCHDB.CHDB.MaDonTXL
        //                                 : itemYCCHDB.CHDB.MaDonTBC != null ? "TBC" + itemYCCHDB.CHDB.MaDonTBC : null,
        //                                 itemYCCHDB.MaYCCHDB,
        //                                 itemYCCHDB.CreateDate,
        //                                 itemYCCHDB.DanhBo,
        //                                 itemYCCHDB.HoTen,
        //                                 itemYCCHDB.DiaChi,
        //                                 itemYCCHDB.LyDo,
        //                                 itemYCCHDB.GhiChuLyDo,
        //                                 itemYCCHDB.HieuLucKy,
        //                             };

        //        DataTable dtPhieuCHDB = new DataTable();
        //        dtPhieuCHDB = LINQToDataTable(queryPhieuCHDB);
        //        dtPhieuCHDB.TableName = "PhieuCHDB";
        //        ds.Tables.Add(dtPhieuCHDB);

        //        ///Table CTTTTL
        //        var queryTTTL = from itemCTTTTL in db.ThuTraLoi_ChiTiets
        //                        where itemCTTTTL.HoTen.Contains(HoTen)
        //                        select new
        //                        {

        //                            MaDon = itemCTTTTL.ThuTraLoi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTTTTL.ThuTraLoi.MaDonMoi).Count() == 1 ? itemCTTTTL.ThuTraLoi.MaDonMoi.Value.ToString() : itemCTTTTL.ThuTraLoi.MaDonMoi + "." + itemCTTTTL.STT
        //                            : itemCTTTTL.ThuTraLoi.MaDon != null ? "TKH" + itemCTTTTL.ThuTraLoi.MaDon
        //                            : itemCTTTTL.ThuTraLoi.MaDonTXL != null ? "TXL" + itemCTTTTL.ThuTraLoi.MaDonTXL
        //                            : itemCTTTTL.ThuTraLoi.MaDonTBC != null ? "TBC" + itemCTTTTL.ThuTraLoi.MaDonTBC : null,
        //                            itemCTTTTL.MaCTTTTL,
        //                            itemCTTTTL.CreateDate,
        //                            itemCTTTTL.DanhBo,
        //                            itemCTTTTL.HoTen,
        //                            itemCTTTTL.DiaChi,
        //                            itemCTTTTL.VeViec,
        //                            itemCTTTTL.NoiDung,
        //                            itemCTTTTL.NoiNhan,
        //                        };
        //        DataTable dtTTTL = new DataTable();
        //        dtTTTL = LINQToDataTable(queryTTTL);
        //        dtTTTL.TableName = "ThuTraLoi";
        //        ds.Tables.Add(dtTTTL);

        //        ///Table GianLan
        //        var queryGianLan = from itemGL in db.GianLan_ChiTiets
        //                           where itemGL.HoTen.Contains(HoTen)
        //                           select new
        //                           {
        //                               MaDon = itemGL.GianLan.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemGL.GianLan.MaDonMoi).Count() == 1 ? itemGL.GianLan.MaDonMoi.Value.ToString() : itemGL.GianLan.MaDonMoi + "." + itemGL.STT
        //                               : itemGL.GianLan.MaDon != null ? "TKH" + itemGL.GianLan.MaDon
        //                               : itemGL.GianLan.MaDonTXL != null ? "TXL" + itemGL.GianLan.MaDonTXL
        //                               : itemGL.GianLan.MaDonTBC != null ? "TBC" + itemGL.GianLan.MaDonTBC : null,
        //                               ID = itemGL.MaCTGL,
        //                               itemGL.CreateDate,
        //                               itemGL.DanhBo,
        //                               itemGL.HoTen,
        //                               itemGL.DiaChi,
        //                               itemGL.NoiDungViPham,
        //                               itemGL.TinhTrang,
        //                               itemGL.ThanhToan1,
        //                               itemGL.ThanhToan2,
        //                               itemGL.ThanhToan3,
        //                               itemGL.XepDon,
        //                           };
        //        DataTable dtGianLan = new DataTable();
        //        dtGianLan = LINQToDataTable(queryGianLan);
        //        dtGianLan.TableName = "GianLan";
        //        ds.Tables.Add(dtGianLan);

        //        ///Table TruyThu
        //        var queryTruyThu = from itemTT in db.TruyThuTienNuoc_ChiTiets
        //                           where itemTT.HoTen.Contains(HoTen)
        //                           select new
        //                           {
        //                               MaDon = itemTT.TruyThuTienNuoc.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemTT.TruyThuTienNuoc.MaDonMoi).Count() == 1 ? itemTT.TruyThuTienNuoc.MaDonMoi.Value.ToString() : itemTT.TruyThuTienNuoc.MaDonMoi + "." + itemTT.STT
        //                               : itemTT.TruyThuTienNuoc.MaDon != null ? "TKH" + itemTT.TruyThuTienNuoc.MaDon
        //                               : itemTT.TruyThuTienNuoc.MaDonTXL != null ? "TXL" + itemTT.TruyThuTienNuoc.MaDonTXL
        //                               : itemTT.TruyThuTienNuoc.MaDonTBC != null ? "TBC" + itemTT.TruyThuTienNuoc.MaDonTBC : null,
        //                               itemTT.IDCT,
        //                               itemTT.DanhBo,
        //                               itemTT.HoTen,
        //                               itemTT.DiaChi,
        //                               itemTT.CreateDate,
        //                               itemTT.NoiDung,
        //                               itemTT.TongTien,
        //                               itemTT.Tongm3BinhQuan,
        //                               itemTT.TinhTrang,
        //                           };
        //        DataTable dtTruyThu = new DataTable();
        //        dtTruyThu = LINQToDataTable(queryTruyThu);
        //        dtTruyThu.TableName = "TruyThu";
        //        ds.Tables.Add(dtTruyThu);

        //        ///Table ToTrinh
        //        var queryToTrinh = from itemCTTT in db.ToTrinh_ChiTiets
        //                           where itemCTTT.HoTen.Contains(HoTen)
        //                           select new
        //                           {
        //                               MaDon = itemCTTT.ToTrinh.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTTT.ToTrinh.MaDonMoi).Count() == 1 ? itemCTTT.ToTrinh.MaDonMoi.Value.ToString() : itemCTTT.ToTrinh.MaDonMoi + "." + itemCTTT.STT
        //                               : itemCTTT.ToTrinh.MaDon != null ? "TKH" + itemCTTT.ToTrinh.MaDon
        //                               : itemCTTT.ToTrinh.MaDonTXL != null ? "TXL" + itemCTTT.ToTrinh.MaDonTXL
        //                               : itemCTTT.ToTrinh.MaDonTBC != null ? "TBC" + itemCTTT.ToTrinh.MaDonTBC : null,
        //                               itemCTTT.IDCT,
        //                               itemCTTT.DanhBo,
        //                               itemCTTT.HoTen,
        //                               itemCTTT.DiaChi,
        //                               itemCTTT.CreateDate,
        //                               itemCTTT.NoiDung,
        //                               itemCTTT.VeViec,
        //                           };
        //        DataTable dtToTrinh = new DataTable();
        //        dtToTrinh = LINQToDataTable(queryToTrinh);
        //        dtToTrinh.TableName = "ToTrinh";
        //        ds.Tables.Add(dtToTrinh);

        //        ///Table ThuMoi
        //        var queryThuMoi = from item in db.ThuMoi_ChiTiets
        //                          where item.HoTen.Contains(HoTen)
        //                          select new
        //                          {
        //                              MaDon = item.ThuMoi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.ThuMoi.MaDonMoi).Count() == 1 ? item.ThuMoi.MaDonMoi.Value.ToString() : item.ThuMoi.MaDonMoi + "." + item.STT
        //                             : item.ThuMoi.MaDonTKH != null ? "TKH" + item.ThuMoi.MaDonTKH
        //                              : item.ThuMoi.MaDonTXL != null ? "TXL" + item.ThuMoi.MaDonTXL
        //                              : item.ThuMoi.MaDonTBC != null ? "TBC" + item.ThuMoi.MaDonTBC : null,
        //                              item.IDCT,
        //                              item.Lan,
        //                              item.DanhBo,
        //                              item.HoTen,
        //                              item.DiaChi,
        //                              item.CreateDate,
        //                              item.VeViec,
        //                          };
        //        DataTable dtThuMoi = new DataTable();
        //        dtThuMoi = LINQToDataTable(queryThuMoi);
        //        dtThuMoi.TableName = "ThuMoi";
        //        ds.Tables.Add(dtThuMoi);

        //        //Table TienTrinh
        //        var queryTienTrinh = from itemDon in db.DonTu_ChiTiets
        //                             join itemTT in db.DonTu_LichSus on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemTT.MaDon, itemTT.STT }
        //                             where itemDon.HoTen.Contains(HoTen)
        //                             select new
        //                             {
        //                                 MaDon = db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == itemDon.MaDon).Count() == 1 ? itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //                                 itemTT.NgayChuyen,
        //                                 itemTT.NoiChuyen,
        //                                 itemTT.NoiNhan,
        //                                 itemTT.KTXM,
        //                                 itemTT.NoiDung,
        //                             };
        //        DataTable dtTienTrinh = new DataTable();
        //        dtTienTrinh = LINQToDataTable(queryTienTrinh);
        //        dtTienTrinh.TableName = "TienTrinh";
        //        ds.Tables.Add(dtTienTrinh);

        //        #endregion

        //        DataTable dt = new DataTable();

        //        #region

        //        //#region DonTu

        //        /////Table DonTu
        //        //var queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //                 where itemDon.HoTen.Contains(HoTen)
        //        //                 select new
        //        //                 {
        //        //                     MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ?  itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                     TenLD = "",
        //        //                     itemDon.CreateDate,
        //        //                     itemDon.DanhBo,
        //        //                     itemDon.HoTen,
        //        //                     itemDon.DiaChi,
        //        //                     itemDon.GiaBieu,
        //        //                     itemDon.DinhMuc,
        //        //                     NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //                 };
        //        //dt = LINQToDataTable(queryDonTu);

        //        /////Table KTXM_ChiTiets
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemCTKTXM in db.KTXM_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTKTXM.KTXM.MaDonMoi, itemCTKTXM.STT }
        //        //             where itemCTKTXM.HoTen.Contains(HoTen)
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ?  itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////Table BamChi_ChiTiets
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemCTBamChi in db.BamChi_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTBamChi.BamChi.MaDonMoi, itemCTBamChi.STT }
        //        //             where itemCTBamChi.HoTen.Contains(HoTen)
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ?  itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////Table DCBD_ChiTietBienDongs
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemCTDCBD in db.DCBD_ChiTietBienDongs on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTDCBD.DCBD.MaDonMoi, itemCTDCBD.STT }
        //        //             where itemCTDCBD.HoTen.Contains(HoTen)
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ?  itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////Table DCBD_ChiTietHoaDons
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemCTDCHD in db.DCBD_ChiTietHoaDons on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTDCHD.DCBD.MaDonMoi, itemCTDCHD.STT }
        //        //             where itemCTDCHD.HoTen.Contains(HoTen)
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ?  itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////Table CHDB_ChiTietCatTams
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemCTCTDB in db.CHDB_ChiTietCatTams on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTCTDB.CHDB.MaDonMoi, itemCTCTDB.STT }
        //        //             where itemCTCTDB.HoTen.Contains(HoTen)
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ?  itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////Table CHDB_ChiTietCatHuys
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemCTCHDB in db.CHDB_ChiTietCatHuys on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTCHDB.CHDB.MaDonMoi, itemCTCHDB.STT }
        //        //             where itemCTCHDB.HoTen.Contains(HoTen)
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ?  itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////TablePhieuCHDBs
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemYCCHDB in db.CHDB_Phieus on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemYCCHDB.CHDB.MaDonMoi, itemYCCHDB.STT }
        //        //             where itemYCCHDB.HoTen.Contains(HoTen)
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ?  itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////Table ThuTraLoi_ChiTiets
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemCTTTTL in db.ThuTraLoi_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTTTTL.ThuTraLoi.MaDonMoi, itemCTTTTL.STT }
        //        //             where itemCTTTTL.HoTen.Contains(HoTen)
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ?  itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////Table DongNuoc_ChiTiets
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemCTDongNuoc in db.DongNuoc_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTDongNuoc.DongNuoc.MaDonMoi, itemCTDongNuoc.STT }
        //        //             where itemCTDongNuoc.HoTen.Contains(HoTen)
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ?  itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////Table GianLan_ChiTiets
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemGL in db.GianLan_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemGL.GianLan.MaDonMoi, itemGL.STT }
        //        //             where itemGL.HoTen.Contains(HoTen)
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ?  itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////Table TruyThu
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemTT in db.TruyThuTienNuoc_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemTT.TruyThuTienNuoc.MaDonMoi, itemTT.STT }
        //        //             where itemTT.HoTen.Contains(HoTen)
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ?  itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////Table ToTrinh
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemCTTT in db.ToTrinh_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTTT.ToTrinh.MaDonMoi, itemCTTT.STT }
        //        //             where itemCTTT.HoTen.Contains(HoTen)
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ?  itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////Table ThuMoi
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemTM in db.ThuMoi_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemTM.ThuMoi.MaDonMoi, itemTM.STT }
        //        //             where itemTM.HoTen.Contains(HoTen)
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ?  itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        //#endregion

        //        //#region DonKH

        //        /////Table DonKH
        //        //var queryDonKH = from itemDon in db.DonKHs
        //        //                 where itemDon.HoTen.Contains(HoTen)
        //        //                 select new
        //        //                 {
        //        //                     MaDon = "TKH" + itemDon.MaDon,
        //        //                     itemDon.LoaiDon.TenLD,
        //        //                     itemDon.CreateDate,
        //        //                     itemDon.DanhBo,
        //        //                     itemDon.HoTen,
        //        //                     itemDon.DiaChi,
        //        //                     itemDon.GiaBieu,
        //        //                     itemDon.DinhMuc,
        //        //                     itemDon.NoiDung,
        //        //                 };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table KTXM_ChiTiets
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemCTKTXM in db.KTXM_ChiTiets on itemDon.MaDon equals itemCTKTXM.KTXM.MaDon
        //        //             where itemCTKTXM.HoTen.Contains(HoTen)
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table BamChi_ChiTiets
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemCTBamChi in db.BamChi_ChiTiets on itemDon.MaDon equals itemCTBamChi.BamChi.MaDon
        //        //             where itemCTBamChi.HoTen.Contains(HoTen)
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table DCBD_ChiTietBienDongs
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemCTDCBD in db.DCBD_ChiTietBienDongs on itemDon.MaDon equals itemCTDCBD.DCBD.MaDon
        //        //             where itemCTDCBD.HoTen.Contains(HoTen)
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table DCBD_ChiTietHoaDons
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemCTDCHD in db.DCBD_ChiTietHoaDons on itemDon.MaDon equals itemCTDCHD.DCBD.MaDon
        //        //             where itemCTDCHD.HoTen.Contains(HoTen)
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table CHDB_ChiTietCatTams
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemCTCTDB in db.CHDB_ChiTietCatTams on itemDon.MaDon equals itemCTCTDB.CHDB.MaDon
        //        //             where itemCTCTDB.HoTen.Contains(HoTen)
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table CHDB_ChiTietCatHuys
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemCTCHDB in db.CHDB_ChiTietCatHuys on itemDon.MaDon equals itemCTCHDB.CHDB.MaDon
        //        //             where itemCTCHDB.HoTen.Contains(HoTen)
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////TablePhieuCHDBs
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemYCCHDB in db.CHDB_Phieus on itemDon.MaDon equals itemYCCHDB.CHDB.MaDon
        //        //             where itemYCCHDB.HoTen.Contains(HoTen)
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table ThuTraLoi_ChiTiets
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemCTTTTL in db.ThuTraLoi_ChiTiets on itemDon.MaDon equals itemCTTTTL.ThuTraLoi.MaDon
        //        //             where itemCTTTTL.HoTen.Contains(HoTen)
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table DongNuoc_ChiTiets
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemCTDongNuoc in db.DongNuoc_ChiTiets on itemDon.MaDon equals itemCTDongNuoc.DongNuoc.MaDon
        //        //             where itemCTDongNuoc.HoTen.Contains(HoTen)
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table GianLan_ChiTiets
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemGL in db.GianLan_ChiTiets on itemDon.MaDon equals itemGL.GianLan.MaDon
        //        //             where itemGL.HoTen.Contains(HoTen)
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table TruyThu
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemTT in db.TruyThuTienNuoc_ChiTiets on itemDon.MaDon equals itemTT.TruyThuTienNuoc.MaDon
        //        //             where itemTT.HoTen.Contains(HoTen)
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table ToTrinh
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemCTTT in db.ToTrinh_ChiTiets on itemDon.MaDon equals itemCTTT.ToTrinh.MaDon
        //        //             where itemCTTT.HoTen.Contains(HoTen)
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table ThuMoi
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemTM in db.ThuMoi_ChiTiets on itemDon.MaDon equals itemTM.ThuMoi.MaDonTKH
        //        //             where itemTM.HoTen.Contains(HoTen)
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        //#endregion

        //        //#region DonTXL

        //        /////Table DonTXL
        //        //var queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //                  where itemDonTXL.HoTen.Contains(HoTen)
        //        //                  select new
        //        //                  {
        //        //                      MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                      itemDonTXL.LoaiDonTXL.TenLD,
        //        //                      itemDonTXL.CreateDate,
        //        //                      itemDonTXL.DanhBo,
        //        //                      itemDonTXL.HoTen,
        //        //                      itemDonTXL.DiaChi,
        //        //                      itemDonTXL.GiaBieu,
        //        //                      itemDonTXL.DinhMuc,
        //        //                      itemDonTXL.NoiDung,
        //        //                  };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table KTXM_ChiTiets
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemCTKTXM in db.KTXM_ChiTiets on itemDonTXL.MaDon equals itemCTKTXM.KTXM.MaDonTXL
        //        //              where itemCTKTXM.HoTen.Contains(HoTen)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table BamChi_ChiTiets
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemCTBamChi in db.BamChi_ChiTiets on itemDonTXL.MaDon equals itemCTBamChi.BamChi.MaDonTXL
        //        //              where itemCTBamChi.HoTen.Contains(HoTen)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table DCBD_ChiTietBienDongs
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemCTDCBD in db.DCBD_ChiTietBienDongs on itemDonTXL.MaDon equals itemCTDCBD.DCBD.MaDonTXL
        //        //              where itemCTDCBD.HoTen.Contains(HoTen)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table DCBD_ChiTietHoaDons
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemCTDCHD in db.DCBD_ChiTietHoaDons on itemDonTXL.MaDon equals itemCTDCHD.DCBD.MaDonTXL
        //        //              where itemCTDCHD.HoTen.Contains(HoTen)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table CHDB_ChiTietCatTams
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemCTCTDB in db.CHDB_ChiTietCatTams on itemDonTXL.MaDon equals itemCTCTDB.CHDB.MaDonTXL
        //        //              where itemCTCTDB.HoTen.Contains(HoTen)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table CHDB_ChiTietCatHuys
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemCTCHDB in db.CHDB_ChiTietCatHuys on itemDonTXL.MaDon equals itemCTCHDB.CHDB.MaDonTXL
        //        //              where itemCTCHDB.HoTen.Contains(HoTen)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table CHDB_Phieus
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemYCCHDB in db.CHDB_Phieus on itemDonTXL.MaDon equals itemYCCHDB.CHDB.MaDonTXL
        //        //              where itemYCCHDB.HoTen.Contains(HoTen)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table ThuTraLoi_ChiTiets
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemCTTTTL in db.ThuTraLoi_ChiTiets on itemDonTXL.MaDon equals itemCTTTTL.ThuTraLoi.MaDonTXL
        //        //              where itemCTTTTL.HoTen.Contains(HoTen)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table DongNuoc_ChiTiets
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemCTDongNuoc in db.DongNuoc_ChiTiets on itemDonTXL.MaDon equals itemCTDongNuoc.DongNuoc.MaDonTXL
        //        //              where itemCTDongNuoc.HoTen.Contains(HoTen)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table GianLan_ChiTiets
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemGL in db.GianLan_ChiTiets on itemDonTXL.MaDon equals itemGL.GianLan.MaDonTXL
        //        //              where itemGL.HoTen.Contains(HoTen)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table TruyThu
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemTT in db.TruyThuTienNuoc_ChiTiets on itemDonTXL.MaDon equals itemTT.TruyThuTienNuoc.MaDonTXL
        //        //              where itemTT.HoTen.Contains(HoTen)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table ToTrinh
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemCTTT in db.ToTrinh_ChiTiets on itemDonTXL.MaDon equals itemCTTT.ToTrinh.MaDonTXL
        //        //              where itemCTTT.HoTen.Contains(HoTen)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table ThuMoi
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemTM in db.ThuMoi_ChiTiets on itemDonTXL.MaDon equals itemTM.ThuMoi.MaDonTXL
        //        //              where itemTM.HoTen.Contains(HoTen)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        //#endregion

        //        //#region DonTBC

        //        /////Table DonTBC
        //        //var queryDonTBC = from itemDon in db.DonTBCs
        //        //                  where itemDon.HoTen.Contains(HoTen)
        //        //                  select new
        //        //                  {
        //        //                      MaDon = "TBC" + itemDon.MaDon,
        //        //                      itemDon.LoaiDonTBC.TenLD,
        //        //                      itemDon.CreateDate,
        //        //                      itemDon.DanhBo,
        //        //                      itemDon.HoTen,
        //        //                      itemDon.DiaChi,
        //        //                      itemDon.GiaBieu,
        //        //                      itemDon.DinhMuc,
        //        //                      itemDon.NoiDung,
        //        //                  };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table KTXM_ChiTiets
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemCTKTXM in db.KTXM_ChiTiets on itemDon.MaDon equals itemCTKTXM.KTXM.MaDonTBC
        //        //              where itemCTKTXM.HoTen.Contains(HoTen)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table BamChi_ChiTiets
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemCTBamChi in db.BamChi_ChiTiets on itemDon.MaDon equals itemCTBamChi.BamChi.MaDonTBC
        //        //              where itemCTBamChi.HoTen.Contains(HoTen)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table DCBD_ChiTietBienDongs
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemCTDCBD in db.DCBD_ChiTietBienDongs on itemDon.MaDon equals itemCTDCBD.DCBD.MaDonTBC
        //        //              where itemCTDCBD.HoTen.Contains(HoTen)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table DCBD_ChiTietHoaDons
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemCTDCHD in db.DCBD_ChiTietHoaDons on itemDon.MaDon equals itemCTDCHD.DCBD.MaDonTBC
        //        //              where itemCTDCHD.HoTen.Contains(HoTen)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table CHDB_ChiTietCatTams
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemCTCTDB in db.CHDB_ChiTietCatTams on itemDon.MaDon equals itemCTCTDB.CHDB.MaDonTBC
        //        //              where itemCTCTDB.HoTen.Contains(HoTen)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table CHDB_ChiTietCatHuys
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemCTCHDB in db.CHDB_ChiTietCatHuys on itemDon.MaDon equals itemCTCHDB.CHDB.MaDonTBC
        //        //              where itemCTCHDB.HoTen.Contains(HoTen)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////TablePhieuCHDBs
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemYCCHDB in db.CHDB_Phieus on itemDon.MaDon equals itemYCCHDB.CHDB.MaDonTBC
        //        //              where itemYCCHDB.HoTen.Contains(HoTen)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table ThuTraLoi_ChiTiets
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemCTTTTL in db.ThuTraLoi_ChiTiets on itemDon.MaDon equals itemCTTTTL.ThuTraLoi.MaDonTBC
        //        //              where itemCTTTTL.HoTen.Contains(HoTen)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table DongNuoc_ChiTiets
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemCTDongNuoc in db.DongNuoc_ChiTiets on itemDon.MaDon equals itemCTDongNuoc.DongNuoc.MaDonTBC
        //        //              where itemCTDongNuoc.HoTen.Contains(HoTen)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table GianLan_ChiTiets
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemGL in db.GianLan_ChiTiets on itemDon.MaDon equals itemGL.GianLan.MaDonTBC
        //        //              where itemGL.HoTen.Contains(HoTen)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table TruyThu
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemTT in db.TruyThuTienNuoc_ChiTiets on itemDon.MaDon equals itemTT.TruyThuTienNuoc.MaDonTBC
        //        //              where itemTT.HoTen.Contains(HoTen)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table ToTrinh
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemCTTT in db.ToTrinh_ChiTiets on itemDon.MaDon equals itemCTTT.ToTrinh.MaDonTBC
        //        //              where itemCTTT.HoTen.Contains(HoTen)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table ToTrinh
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemTM in db.ThuMoi_ChiTiets on itemDon.MaDon equals itemTM.ThuMoi.MaDonTBC
        //        //              where itemTM.HoTen.Contains(HoTen)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        //#endregion

        //        #endregion

        //        #region DonTu

        //        ///Table DonTu
        //        var queryDonTu = from itemDon in db.DonTu_ChiTiets
        //                         where itemDon.HoTen.Contains(HoTen)
        //                         select new
        //                         {
        //                             MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //                             TenLD = "",
        //                             itemDon.CreateDate,
        //                             itemDon.DanhBo,
        //                             itemDon.HoTen,
        //                             itemDon.DiaChi,
        //                             itemDon.GiaBieu,
        //                             itemDon.DinhMuc,
        //                             NoiDung = itemDon.DonTu.Name_NhomDon,
        //                         };
        //        dt = LINQToDataTable(queryDonTu);

        //        var queryDonKH = from itemDon in db.DonKHs
        //                         where itemDon.HoTen.Contains(HoTen)
        //                         select new
        //                         {
        //                             MaDon = "TKH" + itemDon.MaDon,
        //                             itemDon.LoaiDon.TenLD,
        //                             itemDon.CreateDate,
        //                             itemDon.DanhBo,
        //                             itemDon.HoTen,
        //                             itemDon.DiaChi,
        //                             itemDon.GiaBieu,
        //                             itemDon.DinhMuc,
        //                             itemDon.NoiDung,
        //                         };
        //        dt.Merge(LINQToDataTable(queryDonKH));

        //        var queryDonTXL = from itemDon in db.DonTXLs
        //                          where itemDon.HoTen.Contains(HoTen)
        //                          select new
        //                          {
        //                              MaDon = "TXL" + itemDon.MaDon,
        //                              itemDon.LoaiDonTXL.TenLD,
        //                              itemDon.CreateDate,
        //                              itemDon.DanhBo,
        //                              itemDon.HoTen,
        //                              itemDon.DiaChi,
        //                              itemDon.GiaBieu,
        //                              itemDon.DinhMuc,
        //                              itemDon.NoiDung,
        //                          };
        //        dt.Merge(LINQToDataTable(queryDonTXL));

        //        var queryDonTBC = from itemDon in db.DonTBCs
        //                          where itemDon.HoTen.Contains(HoTen)
        //                          select new
        //                          {
        //                              MaDon = "TBC" + itemDon.MaDon,
        //                              itemDon.LoaiDonTBC.TenLD,
        //                              itemDon.CreateDate,
        //                              itemDon.DanhBo,
        //                              itemDon.HoTen,
        //                              itemDon.DiaChi,
        //                              itemDon.GiaBieu,
        //                              itemDon.DinhMuc,
        //                              itemDon.NoiDung,
        //                          };
        //        dt.Merge(LINQToDataTable(queryDonTBC));

        //        ///Table KTXM_ChiTiets
        //        queryDonTu = from item in db.KTXM_ChiTiets
        //                     where item.HoTen.Contains(HoTen)
        //                     select new
        //                     {
        //                         MaDon = item.KTXM.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.KTXM.MaDonMoi).Count() == 1 ? item.KTXM.MaDonMoi.Value.ToString() : item.KTXM.MaDonMoi + "." + item.STT
        //                            : item.KTXM.MaDon != null ? "TKH" + item.KTXM.MaDon
        //                            : item.KTXM.MaDonTXL != null ? "TXL" + item.KTXM.MaDonTXL
        //                            : item.KTXM.MaDonTBC != null ? "TBC" + item.KTXM.MaDonTBC : null,
        //                         TenLD = item.KTXM.MaDonMoi != null ? ""
        //                            : item.KTXM.MaDon != null ? item.KTXM.DonKH.LoaiDon.TenLD
        //                            : item.KTXM.MaDonTXL != null ? item.KTXM.DonTXL.LoaiDonTXL.TenLD
        //                            : item.KTXM.MaDonTBC != null ? item.KTXM.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.KTXM.MaDonMoi != null ? item.KTXM.DonTu.CreateDate
        //                            : item.KTXM.MaDon != null ? item.KTXM.DonKH.CreateDate
        //                            : item.KTXM.MaDonTXL != null ? item.KTXM.DonTXL.CreateDate
        //                            : item.KTXM.MaDonTBC != null ? item.KTXM.DonTBC.CreateDate : null,
        //                         DanhBo = item.KTXM.MaDonMoi != null ? item.KTXM.DonTu.DanhBo
        //                            : item.KTXM.MaDon != null ? item.KTXM.DonKH.DanhBo
        //                            : item.KTXM.MaDonTXL != null ? item.KTXM.DonTXL.DanhBo
        //                            : item.KTXM.MaDonTBC != null ? item.KTXM.DonTBC.DanhBo : null,
        //                         HoTen = item.KTXM.MaDonMoi != null ? item.KTXM.DonTu.HoTen
        //                            : item.KTXM.MaDon != null ? item.KTXM.DonKH.HoTen
        //                            : item.KTXM.MaDonTXL != null ? item.KTXM.DonTXL.HoTen
        //                            : item.KTXM.MaDonTBC != null ? item.KTXM.DonTBC.HoTen : null,
        //                         DiaChi = item.KTXM.MaDonMoi != null ? item.KTXM.DonTu.DiaChi
        //                            : item.KTXM.MaDon != null ? item.KTXM.DonKH.DiaChi
        //                            : item.KTXM.MaDonTXL != null ? item.KTXM.DonTXL.DiaChi
        //                            : item.KTXM.MaDonTBC != null ? item.KTXM.DonTBC.DiaChi : null,
        //                         GiaBieu = item.KTXM.MaDonMoi != null ? item.KTXM.DonTu.GiaBieu
        //                            : item.KTXM.MaDon != null ? item.KTXM.DonKH.GiaBieu
        //                            : item.KTXM.MaDonTXL != null ? item.KTXM.DonTXL.GiaBieu
        //                            : item.KTXM.MaDonTBC != null ? item.KTXM.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.KTXM.MaDonMoi != null ? item.KTXM.DonTu.DinhMuc
        //                            : item.KTXM.MaDon != null ? item.KTXM.DonKH.DinhMuc
        //                            : item.KTXM.MaDonTXL != null ? item.KTXM.DonTXL.DinhMuc
        //                            : item.KTXM.MaDonTBC != null ? item.KTXM.DonTBC.DinhMuc : null,
        //                         NoiDung = item.KTXM.MaDonMoi != null ? item.KTXM.DonTu.Name_NhomDon
        //                            : item.KTXM.MaDon != null ? item.KTXM.DonKH.NoiDung
        //                            : item.KTXM.MaDonTXL != null ? item.KTXM.DonTXL.NoiDung
        //                            : item.KTXM.MaDonTBC != null ? item.KTXM.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///Table BamChi_ChiTiets
        //        queryDonTu = from item in db.BamChi_ChiTiets
        //                     where item.HoTen.Contains(HoTen)
        //                     select new
        //                     {
        //                         MaDon = item.BamChi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.BamChi.MaDonMoi).Count() == 1 ? item.BamChi.MaDonMoi.Value.ToString() : item.BamChi.MaDonMoi + "." + item.STT
        //                            : item.BamChi.MaDon != null ? "TKH" + item.BamChi.MaDon
        //                            : item.BamChi.MaDonTXL != null ? "TXL" + item.BamChi.MaDonTXL
        //                            : item.BamChi.MaDonTBC != null ? "TBC" + item.BamChi.MaDonTBC : null,
        //                         TenLD = item.BamChi.MaDonMoi != null ? ""
        //                            : item.BamChi.MaDon != null ? item.BamChi.DonKH.LoaiDon.TenLD
        //                            : item.BamChi.MaDonTXL != null ? item.BamChi.DonTXL.LoaiDonTXL.TenLD
        //                            : item.BamChi.MaDonTBC != null ? item.BamChi.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.BamChi.MaDonMoi != null ? item.BamChi.DonTu.CreateDate
        //                            : item.BamChi.MaDon != null ? item.BamChi.DonKH.CreateDate
        //                            : item.BamChi.MaDonTXL != null ? item.BamChi.DonTXL.CreateDate
        //                            : item.BamChi.MaDonTBC != null ? item.BamChi.DonTBC.CreateDate : null,
        //                         DanhBo = item.BamChi.MaDonMoi != null ? item.BamChi.DonTu.DanhBo
        //                            : item.BamChi.MaDon != null ? item.BamChi.DonKH.DanhBo
        //                            : item.BamChi.MaDonTXL != null ? item.BamChi.DonTXL.DanhBo
        //                            : item.BamChi.MaDonTBC != null ? item.BamChi.DonTBC.DanhBo : null,
        //                         HoTen = item.BamChi.MaDonMoi != null ? item.BamChi.DonTu.HoTen
        //                            : item.BamChi.MaDon != null ? item.BamChi.DonKH.HoTen
        //                            : item.BamChi.MaDonTXL != null ? item.BamChi.DonTXL.HoTen
        //                            : item.BamChi.MaDonTBC != null ? item.BamChi.DonTBC.HoTen : null,
        //                         DiaChi = item.BamChi.MaDonMoi != null ? item.BamChi.DonTu.DiaChi
        //                            : item.BamChi.MaDon != null ? item.BamChi.DonKH.DiaChi
        //                            : item.BamChi.MaDonTXL != null ? item.BamChi.DonTXL.DiaChi
        //                            : item.BamChi.MaDonTBC != null ? item.BamChi.DonTBC.DiaChi : null,
        //                         GiaBieu = item.BamChi.MaDonMoi != null ? item.BamChi.DonTu.GiaBieu
        //                            : item.BamChi.MaDon != null ? item.BamChi.DonKH.GiaBieu
        //                            : item.BamChi.MaDonTXL != null ? item.BamChi.DonTXL.GiaBieu
        //                            : item.BamChi.MaDonTBC != null ? item.BamChi.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.BamChi.MaDonMoi != null ? item.BamChi.DonTu.DinhMuc
        //                            : item.BamChi.MaDon != null ? item.BamChi.DonKH.DinhMuc
        //                            : item.BamChi.MaDonTXL != null ? item.BamChi.DonTXL.DinhMuc
        //                            : item.BamChi.MaDonTBC != null ? item.BamChi.DonTBC.DinhMuc : null,
        //                         NoiDung = item.BamChi.MaDonMoi != null ? item.BamChi.DonTu.Name_NhomDon
        //                            : item.BamChi.MaDon != null ? item.BamChi.DonKH.NoiDung
        //                            : item.BamChi.MaDonTXL != null ? item.BamChi.DonTXL.NoiDung
        //                            : item.BamChi.MaDonTBC != null ? item.BamChi.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///Table DongNuoc_ChiTiets
        //        queryDonTu = from item in db.DongNuoc_ChiTiets
        //                     where item.HoTen.Contains(HoTen)
        //                     select new
        //                     {
        //                         MaDon = item.DongNuoc.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.DongNuoc.MaDonMoi).Count() == 1 ? item.DongNuoc.MaDonMoi.Value.ToString() : item.DongNuoc.MaDonMoi + "." + item.STT
        //                            : item.DongNuoc.MaDon != null ? "TKH" + item.DongNuoc.MaDon
        //                            : item.DongNuoc.MaDonTXL != null ? "TXL" + item.DongNuoc.MaDonTXL
        //                            : item.DongNuoc.MaDonTBC != null ? "TBC" + item.DongNuoc.MaDonTBC : null,
        //                         TenLD = item.DongNuoc.MaDonMoi != null ? ""
        //                            : item.DongNuoc.MaDon != null ? item.DongNuoc.DonKH.LoaiDon.TenLD
        //                            : item.DongNuoc.MaDonTXL != null ? item.DongNuoc.DonTXL.LoaiDonTXL.TenLD
        //                            : item.DongNuoc.MaDonTBC != null ? item.DongNuoc.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.DongNuoc.MaDonMoi != null ? item.DongNuoc.DonTu.CreateDate
        //                            : item.DongNuoc.MaDon != null ? item.DongNuoc.DonKH.CreateDate
        //                            : item.DongNuoc.MaDonTXL != null ? item.DongNuoc.DonTXL.CreateDate
        //                            : item.DongNuoc.MaDonTBC != null ? item.DongNuoc.DonTBC.CreateDate : null,
        //                         DanhBo = item.DongNuoc.MaDonMoi != null ? item.DongNuoc.DonTu.DanhBo
        //                            : item.DongNuoc.MaDon != null ? item.DongNuoc.DonKH.DanhBo
        //                            : item.DongNuoc.MaDonTXL != null ? item.DongNuoc.DonTXL.DanhBo
        //                            : item.DongNuoc.MaDonTBC != null ? item.DongNuoc.DonTBC.DanhBo : null,
        //                         HoTen = item.DongNuoc.MaDonMoi != null ? item.DongNuoc.DonTu.HoTen
        //                            : item.DongNuoc.MaDon != null ? item.DongNuoc.DonKH.HoTen
        //                            : item.DongNuoc.MaDonTXL != null ? item.DongNuoc.DonTXL.HoTen
        //                            : item.DongNuoc.MaDonTBC != null ? item.DongNuoc.DonTBC.HoTen : null,
        //                         DiaChi = item.DongNuoc.MaDonMoi != null ? item.DongNuoc.DonTu.DiaChi
        //                            : item.DongNuoc.MaDon != null ? item.DongNuoc.DonKH.DiaChi
        //                            : item.DongNuoc.MaDonTXL != null ? item.DongNuoc.DonTXL.DiaChi
        //                            : item.DongNuoc.MaDonTBC != null ? item.DongNuoc.DonTBC.DiaChi : null,
        //                         GiaBieu = item.DongNuoc.MaDonMoi != null ? item.DongNuoc.DonTu.GiaBieu
        //                            : item.DongNuoc.MaDon != null ? item.DongNuoc.DonKH.GiaBieu
        //                            : item.DongNuoc.MaDonTXL != null ? item.DongNuoc.DonTXL.GiaBieu
        //                            : item.DongNuoc.MaDonTBC != null ? item.DongNuoc.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.DongNuoc.MaDonMoi != null ? item.DongNuoc.DonTu.DinhMuc
        //                            : item.DongNuoc.MaDon != null ? item.DongNuoc.DonKH.DinhMuc
        //                            : item.DongNuoc.MaDonTXL != null ? item.DongNuoc.DonTXL.DinhMuc
        //                            : item.DongNuoc.MaDonTBC != null ? item.DongNuoc.DonTBC.DinhMuc : null,
        //                         NoiDung = item.DongNuoc.MaDonMoi != null ? item.DongNuoc.DonTu.Name_NhomDon
        //                            : item.DongNuoc.MaDon != null ? item.DongNuoc.DonKH.NoiDung
        //                            : item.DongNuoc.MaDonTXL != null ? item.DongNuoc.DonTXL.NoiDung
        //                            : item.DongNuoc.MaDonTBC != null ? item.DongNuoc.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///Table DCBD_ChiTietBienDongs
        //        queryDonTu = from item in db.DCBD_ChiTietBienDongs
        //                     where item.HoTen.Contains(HoTen)
        //                     select new
        //                     {
        //                         MaDon = item.DCBD.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.DCBD.MaDonMoi).Count() == 1 ? item.DCBD.MaDonMoi.Value.ToString() : item.DCBD.MaDonMoi + "." + item.STT
        //                            : item.DCBD.MaDon != null ? "TKH" + item.DCBD.MaDon
        //                            : item.DCBD.MaDonTXL != null ? "TXL" + item.DCBD.MaDonTXL
        //                            : item.DCBD.MaDonTBC != null ? "TBC" + item.DCBD.MaDonTBC : null,
        //                         TenLD = item.DCBD.MaDonMoi != null ? ""
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.LoaiDon.TenLD
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.LoaiDonTXL.TenLD
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.CreateDate
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.CreateDate
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.CreateDate
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.CreateDate : null,
        //                         DanhBo = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.DanhBo
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.DanhBo
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.DanhBo
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.DanhBo : null,
        //                         HoTen = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.HoTen
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.HoTen
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.HoTen
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.HoTen : null,
        //                         DiaChi = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.DiaChi
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.DiaChi
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.DiaChi
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.DiaChi : null,
        //                         GiaBieu = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.GiaBieu
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.GiaBieu
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.GiaBieu
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.DinhMuc
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.DinhMuc
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.DinhMuc
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.DinhMuc : null,
        //                         NoiDung = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.Name_NhomDon
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.NoiDung
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.NoiDung
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///Table DCBD_ChiTietHoaDons
        //        queryDonTu = from item in db.DCBD_ChiTietHoaDons
        //                     where item.HoTen.Contains(HoTen)
        //                     select new
        //                     {
        //                         MaDon = item.DCBD.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.DCBD.MaDonMoi).Count() == 1 ? item.DCBD.MaDonMoi.Value.ToString() : item.DCBD.MaDonMoi + "." + item.STT
        //                            : item.DCBD.MaDon != null ? "TKH" + item.DCBD.MaDon
        //                            : item.DCBD.MaDonTXL != null ? "TXL" + item.DCBD.MaDonTXL
        //                            : item.DCBD.MaDonTBC != null ? "TBC" + item.DCBD.MaDonTBC : null,
        //                         TenLD = item.DCBD.MaDonMoi != null ? ""
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.LoaiDon.TenLD
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.LoaiDonTXL.TenLD
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.CreateDate
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.CreateDate
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.CreateDate
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.CreateDate : null,
        //                         DanhBo = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.DanhBo
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.DanhBo
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.DanhBo
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.DanhBo : null,
        //                         HoTen = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.HoTen
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.HoTen
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.HoTen
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.HoTen : null,
        //                         DiaChi = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.DiaChi
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.DiaChi
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.DiaChi
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.DiaChi : null,
        //                         GiaBieu = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.GiaBieu
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.GiaBieu
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.GiaBieu
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.DinhMuc
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.DinhMuc
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.DinhMuc
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.DinhMuc : null,
        //                         NoiDung = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.Name_NhomDon
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.NoiDung
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.NoiDung
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///Table CHDB_ChiTietCatTams
        //        queryDonTu = from item in db.CHDB_ChiTietCatTams
        //                     where item.HoTen.Contains(HoTen)
        //                     select new
        //                     {
        //                         MaDon = item.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.CHDB.MaDonMoi).Count() == 1 ? item.CHDB.MaDonMoi.Value.ToString() : item.CHDB.MaDonMoi + "." + item.STT
        //                             : item.CHDB.MaDon != null ? "TKH" + item.CHDB.MaDon
        //                             : item.CHDB.MaDonTXL != null ? "TXL" + item.CHDB.MaDonTXL
        //                             : item.CHDB.MaDonTBC != null ? "TBC" + item.CHDB.MaDonTBC : null,
        //                         TenLD = item.CHDB.MaDonMoi != null ? ""
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.LoaiDon.TenLD
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.LoaiDonTXL.TenLD
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.CreateDate
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.CreateDate
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.CreateDate
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.CreateDate : null,
        //                         DanhBo = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.DanhBo
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.DanhBo
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.DanhBo
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.DanhBo : null,
        //                         HoTen = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.HoTen
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.HoTen
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.HoTen
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.HoTen : null,
        //                         DiaChi = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.DiaChi
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.DiaChi
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.DiaChi
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.DiaChi : null,
        //                         GiaBieu = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.GiaBieu
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.GiaBieu
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.GiaBieu
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.DinhMuc
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.DinhMuc
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.DinhMuc
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.DinhMuc : null,
        //                         NoiDung = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.Name_NhomDon
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.NoiDung
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.NoiDung
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///Table CHDB_ChiTietCatHuys
        //        queryDonTu = from item in db.CHDB_ChiTietCatHuys
        //                     where item.HoTen.Contains(HoTen)
        //                     select new
        //                     {
        //                         MaDon = item.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.CHDB.MaDonMoi).Count() == 1 ? item.CHDB.MaDonMoi.Value.ToString() : item.CHDB.MaDonMoi + "." + item.STT
        //                             : item.CHDB.MaDon != null ? "TKH" + item.CHDB.MaDon
        //                             : item.CHDB.MaDonTXL != null ? "TXL" + item.CHDB.MaDonTXL
        //                             : item.CHDB.MaDonTBC != null ? "TBC" + item.CHDB.MaDonTBC : null,
        //                         TenLD = item.CHDB.MaDonMoi != null ? ""
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.LoaiDon.TenLD
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.LoaiDonTXL.TenLD
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.CreateDate
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.CreateDate
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.CreateDate
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.CreateDate : null,
        //                         DanhBo = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.DanhBo
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.DanhBo
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.DanhBo
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.DanhBo : null,
        //                         HoTen = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.HoTen
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.HoTen
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.HoTen
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.HoTen : null,
        //                         DiaChi = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.DiaChi
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.DiaChi
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.DiaChi
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.DiaChi : null,
        //                         GiaBieu = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.GiaBieu
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.GiaBieu
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.GiaBieu
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.DinhMuc
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.DinhMuc
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.DinhMuc
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.DinhMuc : null,
        //                         NoiDung = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.Name_NhomDon
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.NoiDung
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.NoiDung
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///TablePhieuCHDBs
        //        queryDonTu = from item in db.CHDB_Phieus
        //                     where item.HoTen.Contains(HoTen)
        //                     select new
        //                     {
        //                         MaDon = item.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.CHDB.MaDonMoi).Count() == 1 ? item.CHDB.MaDonMoi.Value.ToString() : item.CHDB.MaDonMoi + "." + item.STT
        //                             : item.CHDB.MaDon != null ? "TKH" + item.CHDB.MaDon
        //                             : item.CHDB.MaDonTXL != null ? "TXL" + item.CHDB.MaDonTXL
        //                             : item.CHDB.MaDonTBC != null ? "TBC" + item.CHDB.MaDonTBC : null,
        //                         TenLD = item.CHDB.MaDonMoi != null ? ""
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.LoaiDon.TenLD
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.LoaiDonTXL.TenLD
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.CreateDate
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.CreateDate
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.CreateDate
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.CreateDate : null,
        //                         DanhBo = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.DanhBo
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.DanhBo
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.DanhBo
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.DanhBo : null,
        //                         HoTen = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.HoTen
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.HoTen
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.HoTen
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.HoTen : null,
        //                         DiaChi = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.DiaChi
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.DiaChi
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.DiaChi
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.DiaChi : null,
        //                         GiaBieu = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.GiaBieu
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.GiaBieu
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.GiaBieu
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.DinhMuc
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.DinhMuc
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.DinhMuc
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.DinhMuc : null,
        //                         NoiDung = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.Name_NhomDon
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.NoiDung
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.NoiDung
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///Table ThuTraLoi_ChiTiets
        //        queryDonTu = from item in db.ThuTraLoi_ChiTiets
        //                     where item.HoTen.Contains(HoTen)
        //                     select new
        //                     {
        //                         MaDon = item.ThuTraLoi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.ThuTraLoi.MaDonMoi).Count() == 1 ? item.ThuTraLoi.MaDonMoi.Value.ToString() : item.ThuTraLoi.MaDonMoi + "." + item.STT
        //                            : item.ThuTraLoi.MaDon != null ? "TKH" + item.ThuTraLoi.MaDon
        //                            : item.ThuTraLoi.MaDonTXL != null ? "TXL" + item.ThuTraLoi.MaDonTXL
        //                            : item.ThuTraLoi.MaDonTBC != null ? "TBC" + item.ThuTraLoi.MaDonTBC : null,
        //                         TenLD = item.ThuTraLoi.MaDonMoi != null ? ""
        //                            : item.ThuTraLoi.MaDon != null ? item.ThuTraLoi.DonKH.LoaiDon.TenLD
        //                            : item.ThuTraLoi.MaDonTXL != null ? item.ThuTraLoi.DonTXL.LoaiDonTXL.TenLD
        //                            : item.ThuTraLoi.MaDonTBC != null ? item.ThuTraLoi.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.ThuTraLoi.MaDonMoi != null ? item.ThuTraLoi.DonTu.CreateDate
        //                            : item.ThuTraLoi.MaDon != null ? item.ThuTraLoi.DonKH.CreateDate
        //                            : item.ThuTraLoi.MaDonTXL != null ? item.ThuTraLoi.DonTXL.CreateDate
        //                            : item.ThuTraLoi.MaDonTBC != null ? item.ThuTraLoi.DonTBC.CreateDate : null,
        //                         DanhBo = item.ThuTraLoi.MaDonMoi != null ? item.ThuTraLoi.DonTu.DanhBo
        //                            : item.ThuTraLoi.MaDon != null ? item.ThuTraLoi.DonKH.DanhBo
        //                            : item.ThuTraLoi.MaDonTXL != null ? item.ThuTraLoi.DonTXL.DanhBo
        //                            : item.ThuTraLoi.MaDonTBC != null ? item.ThuTraLoi.DonTBC.DanhBo : null,
        //                         HoTen = item.ThuTraLoi.MaDonMoi != null ? item.ThuTraLoi.DonTu.HoTen
        //                            : item.ThuTraLoi.MaDon != null ? item.ThuTraLoi.DonKH.HoTen
        //                            : item.ThuTraLoi.MaDonTXL != null ? item.ThuTraLoi.DonTXL.HoTen
        //                            : item.ThuTraLoi.MaDonTBC != null ? item.ThuTraLoi.DonTBC.HoTen : null,
        //                         DiaChi = item.ThuTraLoi.MaDonMoi != null ? item.ThuTraLoi.DonTu.DiaChi
        //                            : item.ThuTraLoi.MaDon != null ? item.ThuTraLoi.DonKH.DiaChi
        //                            : item.ThuTraLoi.MaDonTXL != null ? item.ThuTraLoi.DonTXL.DiaChi
        //                            : item.ThuTraLoi.MaDonTBC != null ? item.ThuTraLoi.DonTBC.DiaChi : null,
        //                         GiaBieu = item.ThuTraLoi.MaDonMoi != null ? item.ThuTraLoi.DonTu.GiaBieu
        //                            : item.ThuTraLoi.MaDon != null ? item.ThuTraLoi.DonKH.GiaBieu
        //                            : item.ThuTraLoi.MaDonTXL != null ? item.ThuTraLoi.DonTXL.GiaBieu
        //                            : item.ThuTraLoi.MaDonTBC != null ? item.ThuTraLoi.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.ThuTraLoi.MaDonMoi != null ? item.ThuTraLoi.DonTu.DinhMuc
        //                            : item.ThuTraLoi.MaDon != null ? item.ThuTraLoi.DonKH.DinhMuc
        //                            : item.ThuTraLoi.MaDonTXL != null ? item.ThuTraLoi.DonTXL.DinhMuc
        //                            : item.ThuTraLoi.MaDonTBC != null ? item.ThuTraLoi.DonTBC.DinhMuc : null,
        //                         NoiDung = item.ThuTraLoi.MaDonMoi != null ? item.ThuTraLoi.DonTu.Name_NhomDon
        //                            : item.ThuTraLoi.MaDon != null ? item.ThuTraLoi.DonKH.NoiDung
        //                            : item.ThuTraLoi.MaDonTXL != null ? item.ThuTraLoi.DonTXL.NoiDung
        //                            : item.ThuTraLoi.MaDonTBC != null ? item.ThuTraLoi.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///Table GianLan_ChiTiets
        //        queryDonTu = from item in db.GianLan_ChiTiets
        //                     where item.HoTen.Contains(HoTen)
        //                     select new
        //                     {
        //                         MaDon = item.GianLan.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.GianLan.MaDonMoi).Count() == 1 ? item.GianLan.MaDonMoi.Value.ToString() : item.GianLan.MaDonMoi + "." + item.STT
        //                            : item.GianLan.MaDon != null ? "TKH" + item.GianLan.MaDon
        //                            : item.GianLan.MaDonTXL != null ? "TXL" + item.GianLan.MaDonTXL
        //                            : item.GianLan.MaDonTBC != null ? "TBC" + item.GianLan.MaDonTBC : null,
        //                         TenLD = item.GianLan.MaDonMoi != null ? ""
        //                            : item.GianLan.MaDon != null ? item.GianLan.DonKH.LoaiDon.TenLD
        //                            : item.GianLan.MaDonTXL != null ? item.GianLan.DonTXL.LoaiDonTXL.TenLD
        //                            : item.GianLan.MaDonTBC != null ? item.GianLan.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.GianLan.MaDonMoi != null ? item.GianLan.DonTu.CreateDate
        //                            : item.GianLan.MaDon != null ? item.GianLan.DonKH.CreateDate
        //                            : item.GianLan.MaDonTXL != null ? item.GianLan.DonTXL.CreateDate
        //                            : item.GianLan.MaDonTBC != null ? item.GianLan.DonTBC.CreateDate : null,
        //                         DanhBo = item.GianLan.MaDonMoi != null ? item.GianLan.DonTu.DanhBo
        //                            : item.GianLan.MaDon != null ? item.GianLan.DonKH.DanhBo
        //                            : item.GianLan.MaDonTXL != null ? item.GianLan.DonTXL.DanhBo
        //                            : item.GianLan.MaDonTBC != null ? item.GianLan.DonTBC.DanhBo : null,
        //                         HoTen = item.GianLan.MaDonMoi != null ? item.GianLan.DonTu.HoTen
        //                            : item.GianLan.MaDon != null ? item.GianLan.DonKH.HoTen
        //                            : item.GianLan.MaDonTXL != null ? item.GianLan.DonTXL.HoTen
        //                            : item.GianLan.MaDonTBC != null ? item.GianLan.DonTBC.HoTen : null,
        //                         DiaChi = item.GianLan.MaDonMoi != null ? item.GianLan.DonTu.DiaChi
        //                            : item.GianLan.MaDon != null ? item.GianLan.DonKH.DiaChi
        //                            : item.GianLan.MaDonTXL != null ? item.GianLan.DonTXL.DiaChi
        //                            : item.GianLan.MaDonTBC != null ? item.GianLan.DonTBC.DiaChi : null,
        //                         GiaBieu = item.GianLan.MaDonMoi != null ? item.GianLan.DonTu.GiaBieu
        //                            : item.GianLan.MaDon != null ? item.GianLan.DonKH.GiaBieu
        //                            : item.GianLan.MaDonTXL != null ? item.GianLan.DonTXL.GiaBieu
        //                            : item.GianLan.MaDonTBC != null ? item.GianLan.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.GianLan.MaDonMoi != null ? item.GianLan.DonTu.DinhMuc
        //                            : item.GianLan.MaDon != null ? item.GianLan.DonKH.DinhMuc
        //                            : item.GianLan.MaDonTXL != null ? item.GianLan.DonTXL.DinhMuc
        //                            : item.GianLan.MaDonTBC != null ? item.GianLan.DonTBC.DinhMuc : null,
        //                         NoiDung = item.GianLan.MaDonMoi != null ? item.GianLan.DonTu.Name_NhomDon
        //                            : item.GianLan.MaDon != null ? item.GianLan.DonKH.NoiDung
        //                            : item.GianLan.MaDonTXL != null ? item.GianLan.DonTXL.NoiDung
        //                            : item.GianLan.MaDonTBC != null ? item.GianLan.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///Table TruyThu
        //        queryDonTu = from item in db.TruyThuTienNuoc_ChiTiets
        //                     where item.HoTen.Contains(HoTen)
        //                     select new
        //                     {
        //                         MaDon = item.TruyThuTienNuoc.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.TruyThuTienNuoc.MaDonMoi).Count() == 1 ? item.TruyThuTienNuoc.MaDonMoi.Value.ToString() : item.TruyThuTienNuoc.MaDonMoi + "." + item.STT
        //                            : item.TruyThuTienNuoc.MaDon != null ? "TKH" + item.TruyThuTienNuoc.MaDon
        //                            : item.TruyThuTienNuoc.MaDonTXL != null ? "TXL" + item.TruyThuTienNuoc.MaDonTXL
        //                            : item.TruyThuTienNuoc.MaDonTBC != null ? "TBC" + item.TruyThuTienNuoc.MaDonTBC : null,
        //                         TenLD = item.TruyThuTienNuoc.MaDonMoi != null ? ""
        //                            : item.TruyThuTienNuoc.MaDon != null ? item.TruyThuTienNuoc.DonKH.LoaiDon.TenLD
        //                            : item.TruyThuTienNuoc.MaDonTXL != null ? item.TruyThuTienNuoc.DonTXL.LoaiDonTXL.TenLD
        //                            : item.TruyThuTienNuoc.MaDonTBC != null ? item.TruyThuTienNuoc.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.TruyThuTienNuoc.MaDonMoi != null ? item.TruyThuTienNuoc.DonTu.CreateDate
        //                            : item.TruyThuTienNuoc.MaDon != null ? item.TruyThuTienNuoc.DonKH.CreateDate
        //                            : item.TruyThuTienNuoc.MaDonTXL != null ? item.TruyThuTienNuoc.DonTXL.CreateDate
        //                            : item.TruyThuTienNuoc.MaDonTBC != null ? item.TruyThuTienNuoc.DonTBC.CreateDate : null,
        //                         DanhBo = item.TruyThuTienNuoc.MaDonMoi != null ? item.TruyThuTienNuoc.DonTu.DanhBo
        //                            : item.TruyThuTienNuoc.MaDon != null ? item.TruyThuTienNuoc.DonKH.DanhBo
        //                            : item.TruyThuTienNuoc.MaDonTXL != null ? item.TruyThuTienNuoc.DonTXL.DanhBo
        //                            : item.TruyThuTienNuoc.MaDonTBC != null ? item.TruyThuTienNuoc.DonTBC.DanhBo : null,
        //                         HoTen = item.TruyThuTienNuoc.MaDonMoi != null ? item.TruyThuTienNuoc.DonTu.HoTen
        //                            : item.TruyThuTienNuoc.MaDon != null ? item.TruyThuTienNuoc.DonKH.HoTen
        //                            : item.TruyThuTienNuoc.MaDonTXL != null ? item.TruyThuTienNuoc.DonTXL.HoTen
        //                            : item.TruyThuTienNuoc.MaDonTBC != null ? item.TruyThuTienNuoc.DonTBC.HoTen : null,
        //                         DiaChi = item.TruyThuTienNuoc.MaDonMoi != null ? item.TruyThuTienNuoc.DonTu.DiaChi
        //                            : item.TruyThuTienNuoc.MaDon != null ? item.TruyThuTienNuoc.DonKH.DiaChi
        //                            : item.TruyThuTienNuoc.MaDonTXL != null ? item.TruyThuTienNuoc.DonTXL.DiaChi
        //                            : item.TruyThuTienNuoc.MaDonTBC != null ? item.TruyThuTienNuoc.DonTBC.DiaChi : null,
        //                         GiaBieu = item.TruyThuTienNuoc.MaDonMoi != null ? item.TruyThuTienNuoc.DonTu.GiaBieu
        //                            : item.TruyThuTienNuoc.MaDon != null ? item.TruyThuTienNuoc.DonKH.GiaBieu
        //                            : item.TruyThuTienNuoc.MaDonTXL != null ? item.TruyThuTienNuoc.DonTXL.GiaBieu
        //                            : item.TruyThuTienNuoc.MaDonTBC != null ? item.TruyThuTienNuoc.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.TruyThuTienNuoc.MaDonMoi != null ? item.TruyThuTienNuoc.DonTu.DinhMuc
        //                            : item.TruyThuTienNuoc.MaDon != null ? item.TruyThuTienNuoc.DonKH.DinhMuc
        //                            : item.TruyThuTienNuoc.MaDonTXL != null ? item.TruyThuTienNuoc.DonTXL.DinhMuc
        //                            : item.TruyThuTienNuoc.MaDonTBC != null ? item.TruyThuTienNuoc.DonTBC.DinhMuc : null,
        //                         NoiDung = item.TruyThuTienNuoc.MaDonMoi != null ? item.TruyThuTienNuoc.DonTu.Name_NhomDon
        //                            : item.TruyThuTienNuoc.MaDon != null ? item.TruyThuTienNuoc.DonKH.NoiDung
        //                            : item.TruyThuTienNuoc.MaDonTXL != null ? item.TruyThuTienNuoc.DonTXL.NoiDung
        //                            : item.TruyThuTienNuoc.MaDonTBC != null ? item.TruyThuTienNuoc.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///Table ToTrinh
        //        queryDonTu = from item in db.ToTrinh_ChiTiets
        //                     where item.HoTen.Contains(HoTen)
        //                     select new
        //                     {
        //                         MaDon = item.ToTrinh.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.ToTrinh.MaDonMoi).Count() == 1 ? item.ToTrinh.MaDonMoi.Value.ToString() : item.ToTrinh.MaDonMoi + "." + item.STT
        //                             : item.ToTrinh.MaDon != null ? "TKH" + item.ToTrinh.MaDon
        //                             : item.ToTrinh.MaDonTXL != null ? "TXL" + item.ToTrinh.MaDonTXL
        //                             : item.ToTrinh.MaDonTBC != null ? "TBC" + item.ToTrinh.MaDonTBC : null,
        //                         TenLD = item.ToTrinh.MaDonMoi != null ? ""
        //                            : item.ToTrinh.MaDon != null ? item.ToTrinh.DonKH.LoaiDon.TenLD
        //                            : item.ToTrinh.MaDonTXL != null ? item.ToTrinh.DonTXL.LoaiDonTXL.TenLD
        //                            : item.ToTrinh.MaDonTBC != null ? item.ToTrinh.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.ToTrinh.MaDonMoi != null ? item.ToTrinh.DonTu.CreateDate
        //                            : item.ToTrinh.MaDon != null ? item.ToTrinh.DonKH.CreateDate
        //                            : item.ToTrinh.MaDonTXL != null ? item.ToTrinh.DonTXL.CreateDate
        //                            : item.ToTrinh.MaDonTBC != null ? item.ToTrinh.DonTBC.CreateDate : null,
        //                         DanhBo = item.ToTrinh.MaDonMoi != null ? item.ToTrinh.DonTu.DanhBo
        //                            : item.ToTrinh.MaDon != null ? item.ToTrinh.DonKH.DanhBo
        //                            : item.ToTrinh.MaDonTXL != null ? item.ToTrinh.DonTXL.DanhBo
        //                            : item.ToTrinh.MaDonTBC != null ? item.ToTrinh.DonTBC.DanhBo : null,
        //                         HoTen = item.ToTrinh.MaDonMoi != null ? item.ToTrinh.DonTu.HoTen
        //                            : item.ToTrinh.MaDon != null ? item.ToTrinh.DonKH.HoTen
        //                            : item.ToTrinh.MaDonTXL != null ? item.ToTrinh.DonTXL.HoTen
        //                            : item.ToTrinh.MaDonTBC != null ? item.ToTrinh.DonTBC.HoTen : null,
        //                         DiaChi = item.ToTrinh.MaDonMoi != null ? item.ToTrinh.DonTu.DiaChi
        //                            : item.ToTrinh.MaDon != null ? item.ToTrinh.DonKH.DiaChi
        //                            : item.ToTrinh.MaDonTXL != null ? item.ToTrinh.DonTXL.DiaChi
        //                            : item.ToTrinh.MaDonTBC != null ? item.ToTrinh.DonTBC.DiaChi : null,
        //                         GiaBieu = item.ToTrinh.MaDonMoi != null ? item.ToTrinh.DonTu.GiaBieu
        //                            : item.ToTrinh.MaDon != null ? item.ToTrinh.DonKH.GiaBieu
        //                            : item.ToTrinh.MaDonTXL != null ? item.ToTrinh.DonTXL.GiaBieu
        //                            : item.ToTrinh.MaDonTBC != null ? item.ToTrinh.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.ToTrinh.MaDonMoi != null ? item.ToTrinh.DonTu.DinhMuc
        //                            : item.ToTrinh.MaDon != null ? item.ToTrinh.DonKH.DinhMuc
        //                            : item.ToTrinh.MaDonTXL != null ? item.ToTrinh.DonTXL.DinhMuc
        //                            : item.ToTrinh.MaDonTBC != null ? item.ToTrinh.DonTBC.DinhMuc : null,
        //                         NoiDung = item.ToTrinh.MaDonMoi != null ? item.ToTrinh.DonTu.Name_NhomDon
        //                            : item.ToTrinh.MaDon != null ? item.ToTrinh.DonKH.NoiDung
        //                            : item.ToTrinh.MaDonTXL != null ? item.ToTrinh.DonTXL.NoiDung
        //                            : item.ToTrinh.MaDonTBC != null ? item.ToTrinh.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///Table ThuMoi
        //        queryDonTu = from item in db.ThuMoi_ChiTiets
        //                     where item.HoTen.Contains(HoTen)
        //                     select new
        //                     {
        //                         MaDon = item.ThuMoi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.ThuMoi.MaDonMoi).Count() == 1 ? item.ThuMoi.MaDonMoi.Value.ToString() : item.ThuMoi.MaDonMoi + "." + item.STT
        //                            : item.ThuMoi.MaDonTKH != null ? "TKH" + item.ThuMoi.MaDonTKH
        //                            : item.ThuMoi.MaDonTXL != null ? "TXL" + item.ThuMoi.MaDonTXL
        //                            : item.ThuMoi.MaDonTBC != null ? "TBC" + item.ThuMoi.MaDonTBC : null,
        //                         TenLD = item.ThuMoi.MaDonMoi != null ? ""
        //                            : item.ThuMoi.MaDonTKH != null ? item.ThuMoi.DonKH.LoaiDon.TenLD
        //                            : item.ThuMoi.MaDonTXL != null ? item.ThuMoi.DonTXL.LoaiDonTXL.TenLD
        //                            : item.ThuMoi.MaDonTBC != null ? item.ThuMoi.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.ThuMoi.MaDonMoi != null ? item.ThuMoi.DonTu.CreateDate
        //                            : item.ThuMoi.MaDonTKH != null ? item.ThuMoi.DonKH.CreateDate
        //                            : item.ThuMoi.MaDonTXL != null ? item.ThuMoi.DonTXL.CreateDate
        //                            : item.ThuMoi.MaDonTBC != null ? item.ThuMoi.DonTBC.CreateDate : null,
        //                         DanhBo = item.ThuMoi.MaDonMoi != null ? item.ThuMoi.DonTu.DanhBo
        //                            : item.ThuMoi.MaDonTKH != null ? item.ThuMoi.DonKH.DanhBo
        //                            : item.ThuMoi.MaDonTXL != null ? item.ThuMoi.DonTXL.DanhBo
        //                            : item.ThuMoi.MaDonTBC != null ? item.ThuMoi.DonTBC.DanhBo : null,
        //                         HoTen = item.ThuMoi.MaDonMoi != null ? item.ThuMoi.DonTu.HoTen
        //                            : item.ThuMoi.MaDonTKH != null ? item.ThuMoi.DonKH.HoTen
        //                            : item.ThuMoi.MaDonTXL != null ? item.ThuMoi.DonTXL.HoTen
        //                            : item.ThuMoi.MaDonTBC != null ? item.ThuMoi.DonTBC.HoTen : null,
        //                         DiaChi = item.ThuMoi.MaDonMoi != null ? item.ThuMoi.DonTu.DiaChi
        //                            : item.ThuMoi.MaDonTKH != null ? item.ThuMoi.DonKH.DiaChi
        //                            : item.ThuMoi.MaDonTXL != null ? item.ThuMoi.DonTXL.DiaChi
        //                            : item.ThuMoi.MaDonTBC != null ? item.ThuMoi.DonTBC.DiaChi : null,
        //                         GiaBieu = item.ThuMoi.MaDonMoi != null ? item.ThuMoi.DonTu.GiaBieu
        //                            : item.ThuMoi.MaDonTKH != null ? item.ThuMoi.DonKH.GiaBieu
        //                            : item.ThuMoi.MaDonTXL != null ? item.ThuMoi.DonTXL.GiaBieu
        //                            : item.ThuMoi.MaDonTBC != null ? item.ThuMoi.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.ThuMoi.MaDonMoi != null ? item.ThuMoi.DonTu.DinhMuc
        //                            : item.ThuMoi.MaDonTKH != null ? item.ThuMoi.DonKH.DinhMuc
        //                            : item.ThuMoi.MaDonTXL != null ? item.ThuMoi.DonTXL.DinhMuc
        //                            : item.ThuMoi.MaDonTBC != null ? item.ThuMoi.DonTBC.DinhMuc : null,
        //                         NoiDung = item.ThuMoi.MaDonMoi != null ? item.ThuMoi.DonTu.Name_NhomDon
        //                            : item.ThuMoi.MaDonTKH != null ? item.ThuMoi.DonKH.NoiDung
        //                            : item.ThuMoi.MaDonTXL != null ? item.ThuMoi.DonTXL.NoiDung
        //                            : item.ThuMoi.MaDonTBC != null ? item.ThuMoi.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        #endregion

        //        DataTable dtDon = new DataTable();
        //        dtDon.Columns.Add("MaDon", typeof(string));
        //        dtDon.Columns.Add("TenLD", typeof(string));
        //        dtDon.Columns.Add("CreateDate", typeof(string));
        //        dtDon.Columns.Add("DanhBo", typeof(string));
        //        dtDon.Columns.Add("HoTen", typeof(string));
        //        dtDon.Columns.Add("DiaChi", typeof(string));
        //        dtDon.Columns.Add("GiaBieu", typeof(string));
        //        dtDon.Columns.Add("DinhMuc", typeof(string));
        //        dtDon.Columns.Add("NoiDung", typeof(string));
        //        dtDon.TableName = "DonTu";

        //        foreach (DataRow itemRow in dt.Rows)
        //        {
        //            if (dtDon.Select("MaDon = '" + itemRow["MaDon"] + "'").Count() <= 0)
        //                dtDon.ImportRow(itemRow);
        //        }

        //        dtDon.DefaultView.Sort = "CreateDate ASC";
        //        ds.Tables.Add(dtDon.DefaultView.ToTable());

        //        if (dtDon.Rows.Count > 0 && dtKTXM.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Kiểm Tra Xác Minh", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["KTXM"].Columns["MaDon"]);

        //        if (dtDon.Rows.Count > 0 && dtBamChi.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Bấm Chì", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["BamChi"].Columns["MaDon"]);

        //        if (dtDon.Rows.Count > 0 && dtDongNuoc.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Đóng Nước", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["DongNuoc"].Columns["MaDon"]);

        //        if (dtDon.Rows.Count > 0 && dtDCBD.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Điều Chỉnh Biến Động", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["DCBD"].Columns["MaDon"]);

        //        if (dtDon.Rows.Count > 0 && dtCHDB.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Cắt Tạm/Hủy Danh Bộ", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["CHDB"].Columns["MaDon"]);

        //        if (dtDon.Rows.Count > 0 && dtPhieuCHDB.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Phiếu Hủy Danh Bộ", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["PhieuCHDB"].Columns["MaDonTXL"]);

        //        if (dtDon.Rows.Count > 0 && dtTTTL.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["ThuTraLoi"].Columns["MaDonTXL"]);

        //        if (dtDon.Rows.Count > 0 && dtGianLan.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Gian Lận", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["GianLan"].Columns["MaDon"]);

        //        if (dtDon.Rows.Count > 0 && dtTruyThu.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Truy Thu", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["TruyThu"].Columns["MaDon"]);

        //        if (dtDon.Rows.Count > 0 && dtToTrinh.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Tờ Trình", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["ToTrinh"].Columns["MaDon"]);

        //        if (dtDon.Rows.Count > 0 && dtThuMoi.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Thư Mời", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["ThuMoi"].Columns["MaDon"]);

        //        if (dtDon.Rows.Count > 0 && dtTienTrinh.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Tiến Trình", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["TienTrinh"].Columns["MaDon"]);

        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return null;
        //    }
        //}

        //public DataSet GetTienTrinhByDiaChi(string DiaChi)
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();

        //        #region DiaChi

        //        ///Table CTKTXM
        //        var queryKTXM = from itemCTKTXM in db.KTXM_ChiTiets
        //                        join itemUser in db.Users on itemCTKTXM.CreateBy equals itemUser.MaU
        //                        where itemCTKTXM.DiaChi.Contains(DiaChi)
        //                        select new
        //                        {
        //                            MaDon = itemCTKTXM.KTXM.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTKTXM.KTXM.MaDonMoi).Count() == 1 ? itemCTKTXM.KTXM.MaDonMoi.Value.ToString() : itemCTKTXM.KTXM.MaDonMoi + "." + itemCTKTXM.STT
        //                              : itemCTKTXM.KTXM.MaDon != null ? "TKH" + itemCTKTXM.KTXM.MaDon
        //                             : itemCTKTXM.KTXM.MaDonTXL != null ? "TXL" + itemCTKTXM.KTXM.MaDonTXL
        //                             : itemCTKTXM.KTXM.MaDonTBC != null ? "TBC" + itemCTKTXM.KTXM.MaDonTBC : null,
        //                            itemCTKTXM.MaCTKTXM,
        //                            itemCTKTXM.NgayKTXM,
        //                            itemCTKTXM.DanhBo,
        //                            itemCTKTXM.HoTen,
        //                            itemCTKTXM.DiaChi,
        //                            itemCTKTXM.NoiDungKiemTra,
        //                            CreateBy = itemUser.HoTen,
        //                            itemCTKTXM.NoiDungDongTien,
        //                            itemCTKTXM.NgayDongTien,
        //                            itemCTKTXM.SoTienDongTien,itemCTKTXM.BanChinh,
        //                        };
        //        DataTable dtKTXM = new DataTable();
        //        dtKTXM = LINQToDataTable(queryKTXM);
        //        dtKTXM.TableName = "KTXM";
        //        ds.Tables.Add(dtKTXM);

        //        ///Table CTBamChi
        //        var queryBamChi = from itemCTBamChi in db.BamChi_ChiTiets
        //                          join itemUser in db.Users on itemCTBamChi.CreateBy equals itemUser.MaU
        //                          where itemCTBamChi.DiaChi.Contains(DiaChi)
        //                          select new
        //                          {
        //                              MaDon = itemCTBamChi.BamChi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTBamChi.BamChi.MaDonMoi).Count() == 1 ? itemCTBamChi.BamChi.MaDonMoi.Value.ToString() : itemCTBamChi.BamChi.MaDonMoi + "." + itemCTBamChi.STT
        //                              : itemCTBamChi.BamChi.MaDon != null ? "TKH" + itemCTBamChi.BamChi.MaDon
        //                            : itemCTBamChi.BamChi.MaDonTXL != null ? "TXL" + itemCTBamChi.BamChi.MaDonTXL
        //                            : itemCTBamChi.BamChi.MaDonTBC != null ? "TBC" + itemCTBamChi.BamChi.MaDonTBC : null,
        //                              itemCTBamChi.MaCTBC,
        //                              itemCTBamChi.NgayBC,
        //                              itemCTBamChi.DanhBo,
        //                              itemCTBamChi.HoTen,
        //                              itemCTBamChi.DiaChi,
        //                              itemCTBamChi.TrangThaiBC,
        //                              itemCTBamChi.TheoYeuCau,
        //                              itemCTBamChi.MaSoBC,
        //                              CreateBy = itemUser.HoTen,
        //                          };

        //        DataTable dtBamChi = new DataTable();
        //        dtBamChi = LINQToDataTable(queryBamChi);
        //        dtBamChi.TableName = "BamChi";
        //        ds.Tables.Add(dtBamChi);

        //        ///Table CTDongNuoc
        //        var queryDongNuoc = from itemCTDongNuoc in db.DongNuoc_ChiTiets
        //                            join itemUser in db.Users on itemCTDongNuoc.CreateBy equals itemUser.MaU
        //                            where itemCTDongNuoc.DiaChi.Contains(DiaChi)
        //                            select new
        //                            {
        //                                MaDon = itemCTDongNuoc.DongNuoc.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTDongNuoc.DongNuoc.MaDonMoi).Count() == 1 ? itemCTDongNuoc.DongNuoc.MaDonMoi.Value.ToString() : itemCTDongNuoc.DongNuoc.MaDonMoi + "." + itemCTDongNuoc.STT
        //                              : itemCTDongNuoc.DongNuoc.MaDon != null ? "TKH" + itemCTDongNuoc.DongNuoc.MaDon
        //                             : itemCTDongNuoc.DongNuoc.MaDonTXL != null ? "TXL" + itemCTDongNuoc.DongNuoc.MaDonTXL
        //                             : itemCTDongNuoc.DongNuoc.MaDonTBC != null ? "TBC" + itemCTDongNuoc.DongNuoc.MaDonTBC : null,
        //                                itemCTDongNuoc.MaCTDN,
        //                                itemCTDongNuoc.NgayDN,
        //                                itemCTDongNuoc.DanhBo,
        //                                itemCTDongNuoc.HoTen,
        //                                itemCTDongNuoc.DiaChi,
        //                                itemCTDongNuoc.MaCTMN,
        //                                itemCTDongNuoc.NgayMN,
        //                                CreateBy = itemUser.HoTen,
        //                            };

        //        DataTable dtDongNuoc = new DataTable();
        //        dtDongNuoc = LINQToDataTable(queryDongNuoc);
        //        dtDongNuoc.TableName = "DongNuoc";
        //        ds.Tables.Add(dtDongNuoc);

        //        ///Table CTDCBD
        //        var queryCTDCBD = from itemCTDCBD in db.DCBD_ChiTietBienDongs
        //                          join itemUser in db.Users on itemCTDCBD.CreateBy equals itemUser.MaU
        //                          where itemCTDCBD.DiaChi.Contains(DiaChi)
        //                          select new
        //                          {
        //                              MaDon = itemCTDCBD.DCBD.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTDCBD.DCBD.MaDonMoi).Count() == 1 ? itemCTDCBD.DCBD.MaDonMoi.Value.ToString() : itemCTDCBD.DCBD.MaDonMoi + "." + itemCTDCBD.STT
        //                              : itemCTDCBD.DCBD.MaDon != null ? "TKH" + itemCTDCBD.DCBD.MaDon
        //                             : itemCTDCBD.DCBD.MaDonTXL != null ? "TXL" + itemCTDCBD.DCBD.MaDonTXL
        //                             : itemCTDCBD.DCBD.MaDonTBC != null ? "TBC" + itemCTDCBD.DCBD.MaDonTBC : null,
        //                              MaDC = itemCTDCBD.MaCTDCBD,
        //                              DieuChinh = "Biến Động",
        //                              itemCTDCBD.CreateDate,
        //                              itemCTDCBD.ThongTin,
        //                              itemCTDCBD.DanhBo,
        //                              itemCTDCBD.HoTen_BD,
        //                              itemCTDCBD.DiaChi_BD,
        //                              itemCTDCBD.MSThue_BD,
        //                              itemCTDCBD.GiaBieu_BD,
        //                              itemCTDCBD.DinhMuc_BD,
        //                              itemCTDCBD.HoTen,
        //                              itemCTDCBD.DiaChi,
        //                              itemCTDCBD.MSThue,
        //                              itemCTDCBD.GiaBieu,
        //                              itemCTDCBD.DinhMuc,
        //                              CreateBy = itemUser.HoTen,
        //                          };

        //        ///Bảng CTDCHD
        //        var queryCTDCHD = from itemCTDCHD in db.DCBD_ChiTietHoaDons
        //                          join itemUser in db.Users on itemCTDCHD.CreateBy equals itemUser.MaU
        //                          where itemCTDCHD.DiaChi.Contains(DiaChi)
        //                          select new
        //                          {
        //                              MaDon = itemCTDCHD.DCBD.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTDCHD.DCBD.MaDonMoi).Count() == 1 ? itemCTDCHD.DCBD.MaDonMoi.Value.ToString() : itemCTDCHD.DCBD.MaDonMoi + "." + itemCTDCHD.STT
        //                              : itemCTDCHD.DCBD.MaDon != null ? "TKH" + itemCTDCHD.DCBD.MaDon
        //                            : itemCTDCHD.DCBD.MaDonTXL != null ? "TXL" + itemCTDCHD.DCBD.MaDonTXL
        //                            : itemCTDCHD.DCBD.MaDonTBC != null ? "TBC" + itemCTDCHD.DCBD.MaDonTBC : null,
        //                              MaDC = itemCTDCHD.MaCTDCHD,
        //                              DieuChinh = "Hóa Đơn",
        //                              itemCTDCHD.CreateDate,
        //                              itemCTDCHD.DanhBo,
        //                              itemCTDCHD.HoTen,
        //                              itemCTDCHD.DiaChi,
        //                              itemCTDCHD.GiaBieu,
        //                              itemCTDCHD.GiaBieu_BD,
        //                              itemCTDCHD.DinhMuc,
        //                              itemCTDCHD.DinhMuc_BD,
        //                              itemCTDCHD.TieuThu,
        //                              itemCTDCHD.TieuThu_BD,
        //                              itemCTDCHD.TongCong_Start,
        //                              itemCTDCHD.TongCong_End,
        //                              itemCTDCHD.TangGiam,
        //                              itemCTDCHD.TongCong_BD,
        //                              CreateBy = itemUser.HoTen,
        //                          };
        //        DataTable dtDCBD = new DataTable();
        //        dtDCBD = LINQToDataTable(queryCTDCBD);
        //        dtDCBD.Merge(LINQToDataTable(queryCTDCHD));
        //        dtDCBD.TableName = "DCBD";
        //        ds.Tables.Add(dtDCBD);

        //        ///Table CTCTDB
        //        var queryCTCTDB = from itemCTCTDB in db.CHDB_ChiTietCatTams
        //                          where itemCTCTDB.DiaChi.Contains(DiaChi)
        //                          select new
        //                          {
        //                              MaDon = itemCTCTDB.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTCTDB.CHDB.MaDonMoi).Count() == 1 ? itemCTCTDB.CHDB.MaDonMoi.Value.ToString() : itemCTCTDB.CHDB.MaDonMoi + "." + itemCTCTDB.STT
        //                              : itemCTCTDB.CHDB.MaDon != null ? "TKH" + itemCTCTDB.CHDB.MaDon
        //                             : itemCTCTDB.CHDB.MaDonTXL != null ? "TXL" + itemCTCTDB.CHDB.MaDonTXL
        //                             : itemCTCTDB.CHDB.MaDonTBC != null ? "TBC" + itemCTCTDB.CHDB.MaDonTBC : null,
        //                              MaCH = itemCTCTDB.MaCTCTDB,
        //                              LoaiCat = "Cắt Tạm",
        //                              itemCTCTDB.CreateDate,
        //                              itemCTCTDB.DanhBo,
        //                              itemCTCTDB.HoTen,
        //                              itemCTCTDB.DiaChi,
        //                              itemCTCTDB.LyDo,
        //                              itemCTCTDB.GhiChuLyDo,
        //                              itemCTCTDB.DaLapPhieu,
        //                              itemCTCTDB.SoPhieu,
        //                              itemCTCTDB.NgayLapPhieu,
        //                          };

        //        ///Table CHDB_ChiTietCatHuy
        //        var queryCTCHDB = from itemCTCHDB in db.CHDB_ChiTietCatHuys
        //                          where itemCTCHDB.DiaChi.Contains(DiaChi)
        //                          select new
        //                          {
        //                              MaDon = itemCTCHDB.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTCHDB.CHDB.MaDonMoi).Count() == 1 ? itemCTCHDB.CHDB.MaDonMoi.Value.ToString() : itemCTCHDB.CHDB.MaDonMoi + "." + itemCTCHDB.STT
        //                              : itemCTCHDB.CHDB.MaDon != null ? "TKH" + itemCTCHDB.CHDB.MaDon
        //                             : itemCTCHDB.CHDB.MaDonTXL != null ? "TXL" + itemCTCHDB.CHDB.MaDonTXL
        //                             : itemCTCHDB.CHDB.MaDonTBC != null ? "TBC" + itemCTCHDB.CHDB.MaDonTBC : null,
        //                              MaCH = itemCTCHDB.MaCTCHDB,
        //                              LoaiCat = "Cắt Hủy",
        //                              itemCTCHDB.CreateDate,
        //                              itemCTCHDB.DanhBo,
        //                              itemCTCHDB.HoTen,
        //                              itemCTCHDB.DiaChi,
        //                              itemCTCHDB.LyDo,
        //                              itemCTCHDB.GhiChuLyDo,
        //                              itemCTCHDB.DaLapPhieu,
        //                              itemCTCHDB.SoPhieu,
        //                              itemCTCHDB.NgayLapPhieu,
        //                          };
        //        DataTable dtCHDB = new DataTable();
        //        dtCHDB = LINQToDataTable(queryCTCTDB);
        //        dtCHDB.Merge(LINQToDataTable(queryCTCHDB));
        //        dtCHDB.TableName = "CHDB";
        //        ds.Tables.Add(dtCHDB);

        //        ///Table PhieuCHDB
        //        var queryPhieuCHDB = from itemYCCHDB in db.CHDB_Phieus
        //                             where itemYCCHDB.DiaChi.Contains(DiaChi)
        //                             select new
        //                             {
        //                                 MaDon = itemYCCHDB.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemYCCHDB.CHDB.MaDonMoi).Count() == 1 ? itemYCCHDB.CHDB.MaDonMoi.Value.ToString() : itemYCCHDB.CHDB.MaDonMoi + "." + itemYCCHDB.STT
        //                                 : itemYCCHDB.CHDB.MaDon != null ? "TKH" + itemYCCHDB.CHDB.MaDonTXL
        //                               : itemYCCHDB.CHDB.MaDonTXL != null ? "TXL" + itemYCCHDB.CHDB.MaDonTXL
        //                               : itemYCCHDB.CHDB.MaDonTBC != null ? "TBC" + itemYCCHDB.CHDB.MaDonTBC : null,
        //                                 itemYCCHDB.MaYCCHDB,
        //                                 itemYCCHDB.CreateDate,
        //                                 itemYCCHDB.DanhBo,
        //                                 itemYCCHDB.HoTen,
        //                                 itemYCCHDB.DiaChi,
        //                                 itemYCCHDB.LyDo,
        //                                 itemYCCHDB.GhiChuLyDo,
        //                                 itemYCCHDB.HieuLucKy,
        //                             };

        //        DataTable dtPhieuCHDB = new DataTable();
        //        dtPhieuCHDB = LINQToDataTable(queryPhieuCHDB);
        //        dtPhieuCHDB.TableName = "PhieuCHDB";
        //        ds.Tables.Add(dtPhieuCHDB);

        //        ///Table CTTTTL
        //        var queryTTTL = from itemCTTTTL in db.ThuTraLoi_ChiTiets
        //                        where itemCTTTTL.DiaChi.Contains(DiaChi)
        //                        select new
        //                        {
        //                            MaDon = itemCTTTTL.ThuTraLoi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTTTTL.ThuTraLoi.MaDonMoi).Count() == 1 ? itemCTTTTL.ThuTraLoi.MaDonMoi.Value.ToString() : itemCTTTTL.ThuTraLoi.MaDonMoi + "." + itemCTTTTL.STT
        //                              : itemCTTTTL.ThuTraLoi.MaDon != null ? "TKH" + itemCTTTTL.ThuTraLoi.MaDon
        //                            : itemCTTTTL.ThuTraLoi.MaDonTXL != null ? "TXL" + itemCTTTTL.ThuTraLoi.MaDonTXL
        //                            : itemCTTTTL.ThuTraLoi.MaDonTBC != null ? "TBC" + itemCTTTTL.ThuTraLoi.MaDonTBC : null,
        //                            itemCTTTTL.MaCTTTTL,
        //                            itemCTTTTL.CreateDate,
        //                            itemCTTTTL.DanhBo,
        //                            itemCTTTTL.HoTen,
        //                            itemCTTTTL.DiaChi,
        //                            itemCTTTTL.VeViec,
        //                            itemCTTTTL.NoiDung,
        //                            itemCTTTTL.NoiNhan,
        //                        };
        //        DataTable dtTTTL = new DataTable();
        //        dtTTTL = LINQToDataTable(queryTTTL);
        //        dtTTTL.TableName = "ThuTraLoi";
        //        ds.Tables.Add(dtTTTL);

        //        ///Table GianLan
        //        var queryGianLan = from itemGL in db.GianLan_ChiTiets
        //                           where itemGL.DiaChi.Contains(DiaChi)
        //                           select new
        //                           {
        //                               MaDon = itemGL.GianLan.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemGL.GianLan.MaDonMoi).Count() == 1 ? itemGL.GianLan.MaDonMoi.Value.ToString() : itemGL.GianLan.MaDonMoi + "." + itemGL.STT
        //                                 : itemGL.GianLan.MaDon != null ? "TKH" + itemGL.GianLan.MaDon
        //                               : itemGL.GianLan.MaDonTXL != null ? "TXL" + itemGL.GianLan.MaDonTXL
        //                               : itemGL.GianLan.MaDonTBC != null ? "TBC" + itemGL.GianLan.MaDonTBC : null,
        //                               ID = itemGL.MaCTGL,
        //                               itemGL.CreateDate,
        //                               itemGL.DanhBo,
        //                               itemGL.HoTen,
        //                               itemGL.DiaChi,
        //                               itemGL.NoiDungViPham,
        //                               itemGL.TinhTrang,
        //                               itemGL.ThanhToan1,
        //                               itemGL.ThanhToan2,
        //                               itemGL.ThanhToan3,
        //                               itemGL.XepDon,
        //                           };
        //        DataTable dtGianLan = new DataTable();
        //        dtGianLan = LINQToDataTable(queryGianLan);
        //        dtGianLan.TableName = "GianLan";
        //        ds.Tables.Add(dtGianLan);

        //        ///Table TruyThu
        //        var queryTruyThu = from itemTT in db.TruyThuTienNuoc_ChiTiets
        //                           where itemTT.DiaChi.Contains(DiaChi)
        //                           select new
        //                           {
        //                               MaDon = itemTT.TruyThuTienNuoc.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemTT.TruyThuTienNuoc.MaDonMoi).Count() == 1 ? itemTT.TruyThuTienNuoc.MaDonMoi.Value.ToString() : itemTT.TruyThuTienNuoc.MaDonMoi + "." + itemTT.STT
        //                              : itemTT.TruyThuTienNuoc.MaDon != null ? "TKH" + itemTT.TruyThuTienNuoc.MaDon
        //                               : itemTT.TruyThuTienNuoc.MaDonTXL != null ? "TXL" + itemTT.TruyThuTienNuoc.MaDonTXL
        //                               : itemTT.TruyThuTienNuoc.MaDonTBC != null ? "TBC" + itemTT.TruyThuTienNuoc.MaDonTBC : null,
        //                               itemTT.IDCT,
        //                               itemTT.DanhBo,
        //                               itemTT.HoTen,
        //                               itemTT.DiaChi,
        //                               itemTT.CreateDate,
        //                               itemTT.NoiDung,
        //                               itemTT.TongTien,
        //                               itemTT.Tongm3BinhQuan,
        //                               itemTT.TinhTrang,
        //                           };
        //        DataTable dtTruyThu = new DataTable();
        //        dtTruyThu = LINQToDataTable(queryTruyThu);
        //        dtTruyThu.TableName = "TruyThu";
        //        ds.Tables.Add(dtTruyThu);

        //        ///Table ToTrinh
        //        var queryToTrinh = from itemCTTT in db.ToTrinh_ChiTiets
        //                           where itemCTTT.DiaChi.Contains(DiaChi)
        //                           select new
        //                           {
        //                               MaDon = itemCTTT.ToTrinh.MaDonMoi != null ? db.DonTu_ChiTiets.Where(item => item.MaDon == itemCTTT.ToTrinh.MaDonMoi).Count() == 1 ? itemCTTT.ToTrinh.MaDonMoi.Value.ToString() : itemCTTT.ToTrinh.MaDonMoi + "." + itemCTTT.STT
        //                              : itemCTTT.ToTrinh.MaDon != null ? "TKH" + itemCTTT.ToTrinh.MaDon
        //                               : itemCTTT.ToTrinh.MaDonTXL != null ? "TXL" + itemCTTT.ToTrinh.MaDonTXL
        //                               : itemCTTT.ToTrinh.MaDonTBC != null ? "TBC" + itemCTTT.ToTrinh.MaDonTBC : null,
        //                               itemCTTT.IDCT,
        //                               itemCTTT.DanhBo,
        //                               itemCTTT.HoTen,
        //                               itemCTTT.DiaChi,
        //                               itemCTTT.CreateDate,
        //                               itemCTTT.NoiDung,
        //                               itemCTTT.VeViec,
        //                           };
        //        DataTable dtToTrinh = new DataTable();
        //        dtToTrinh = LINQToDataTable(queryToTrinh);
        //        dtToTrinh.TableName = "ToTrinh";
        //        ds.Tables.Add(dtToTrinh);

        //        ///Table ThuMoi
        //        var queryThuMoi = from item in db.ThuMoi_ChiTiets
        //                          where item.DiaChi.Contains(DiaChi)
        //                          select new
        //                          {
        //                              MaDon = item.ThuMoi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.ThuMoi.MaDonMoi).Count() == 1 ? item.ThuMoi.MaDonMoi.Value.ToString() : item.ThuMoi.MaDonMoi + "." + item.STT
        //                             : item.ThuMoi.MaDonTKH != null ? "TKH" + item.ThuMoi.MaDonTKH
        //                              : item.ThuMoi.MaDonTXL != null ? "TXL" + item.ThuMoi.MaDonTXL
        //                              : item.ThuMoi.MaDonTBC != null ? "TBC" + item.ThuMoi.MaDonTBC : null,
        //                              item.IDCT,
        //                              item.Lan,
        //                              item.DanhBo,
        //                              item.HoTen,
        //                              item.DiaChi,
        //                              item.CreateDate,
        //                              item.VeViec,
        //                          };
        //        DataTable dtThuMoi = new DataTable();
        //        dtThuMoi = LINQToDataTable(queryThuMoi);
        //        dtThuMoi.TableName = "ThuMoi";
        //        ds.Tables.Add(dtThuMoi);

        //        //Table TienTrinh
        //        var queryTienTrinh = from itemDon in db.DonTu_ChiTiets
        //                             join itemTT in db.DonTu_LichSus on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemTT.MaDon, itemTT.STT }
        //                             where itemDon.DiaChi.Contains(DiaChi)
        //                             select new
        //                             {
        //                                 MaDon = db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == itemDon.MaDon).Count() == 1 ? itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //                                 itemTT.NgayChuyen,
        //                                 itemTT.NoiChuyen,
        //                                 itemTT.NoiNhan,
        //                                 itemTT.KTXM,
        //                                 itemTT.NoiDung,
        //                             };
        //        DataTable dtTienTrinh = new DataTable();
        //        dtTienTrinh = LINQToDataTable(queryTienTrinh);
        //        dtTienTrinh.TableName = "TienTrinh";
        //        ds.Tables.Add(dtTienTrinh);

        //        #endregion

        //        DataTable dt = new DataTable();

        //        #region

        //        //#region DonTu

        //        /////Table DonTu
        //        //var queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //                 where itemDon.DiaChi.Contains(DiaChi)
        //        //                 select new
        //        //                 {
        //        //                     MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ?  itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                     TenLD = "",
        //        //                     itemDon.CreateDate,
        //        //                     itemDon.DanhBo,
        //        //                     itemDon.HoTen,
        //        //                     itemDon.DiaChi,
        //        //                     itemDon.GiaBieu,
        //        //                     itemDon.DinhMuc,
        //        //                     NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //                 };
        //        //dt = LINQToDataTable(queryDonTu);

        //        /////Table KTXM_ChiTiets
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemCTKTXM in db.KTXM_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTKTXM.KTXM.MaDonMoi, itemCTKTXM.STT }
        //        //             where itemCTKTXM.DiaChi.Contains(DiaChi)
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ?  itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////Table BamChi_ChiTiets
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemCTBamChi in db.BamChi_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTBamChi.BamChi.MaDonMoi, itemCTBamChi.STT }
        //        //             where itemCTBamChi.DiaChi.Contains(DiaChi)
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ?  itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////Table DCBD_ChiTietBienDongs
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemCTDCBD in db.DCBD_ChiTietBienDongs on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTDCBD.DCBD.MaDonMoi, itemCTDCBD.STT }
        //        //             where itemCTDCBD.DiaChi.Contains(DiaChi)
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ?  itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////Table DCBD_ChiTietHoaDons
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemCTDCHD in db.DCBD_ChiTietHoaDons on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTDCHD.DCBD.MaDonMoi, itemCTDCHD.STT }
        //        //             where itemCTDCHD.DiaChi.Contains(DiaChi)
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ?  itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////Table CHDB_ChiTietCatTams
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemCTCTDB in db.CHDB_ChiTietCatTams on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTCTDB.CHDB.MaDonMoi, itemCTCTDB.STT }
        //        //             where itemCTCTDB.DiaChi.Contains(DiaChi)
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ?  itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////Table CHDB_ChiTietCatHuys
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemCTCHDB in db.CHDB_ChiTietCatHuys on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTCHDB.CHDB.MaDonMoi, itemCTCHDB.STT }
        //        //             where itemCTCHDB.DiaChi.Contains(DiaChi)
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ?  itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////TablePhieuCHDBs
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemYCCHDB in db.CHDB_Phieus on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemYCCHDB.CHDB.MaDonMoi, itemYCCHDB.STT }
        //        //             where itemYCCHDB.DiaChi.Contains(DiaChi)
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ?  itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////Table ThuTraLoi_ChiTiets
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemCTTTTL in db.ThuTraLoi_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTTTTL.ThuTraLoi.MaDonMoi, itemCTTTTL.STT }
        //        //             where itemCTTTTL.DiaChi.Contains(DiaChi)
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ?  itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////Table DongNuoc_ChiTiets
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemCTDongNuoc in db.DongNuoc_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTDongNuoc.DongNuoc.MaDonMoi, itemCTDongNuoc.STT }
        //        //             where itemCTDongNuoc.DiaChi.Contains(DiaChi)
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ?  itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////Table GianLan_ChiTiets
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemGL in db.GianLan_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemGL.GianLan.MaDonMoi, itemGL.STT }
        //        //             where itemGL.DiaChi.Contains(DiaChi)
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ?  itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////Table TruyThu
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemTT in db.TruyThuTienNuoc_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemTT.TruyThuTienNuoc.MaDonMoi, itemTT.STT }
        //        //             where itemTT.DiaChi.Contains(DiaChi)
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ?  itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////Table ToTrinh
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemCTTT in db.ToTrinh_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemCTTT.ToTrinh.MaDonMoi, itemCTTT.STT }
        //        //             where itemCTTT.DiaChi.Contains(DiaChi)
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ?  itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        /////Table ThuMoi
        //        //queryDonTu = from itemDon in db.DonTu_ChiTiets
        //        //             join itemTM in db.ThuMoi_ChiTiets on new { itemDon.MaDon, itemDon.STT } equals new { MaDon = itemTM.ThuMoi.MaDonMoi, itemTM.STT }
        //        //             where itemTM.DiaChi.Contains(DiaChi)
        //        //             select new
        //        //             {
        //        //                 MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ?  itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //        //                 TenLD = "",
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 NoiDung = itemDon.DonTu.Name_NhomDon,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonTu));

        //        //#endregion

        //        //#region DonKH

        //        /////Table DonKH
        //        //var queryDonKH = from itemDon in db.DonKHs
        //        //                 where itemDon.DiaChi.Contains(DiaChi)
        //        //                 select new
        //        //                 {
        //        //                     MaDon = "TKH" + itemDon.MaDon,
        //        //                     itemDon.LoaiDon.TenLD,
        //        //                     itemDon.CreateDate,
        //        //                     itemDon.DanhBo,
        //        //                     itemDon.HoTen,
        //        //                     itemDon.DiaChi,
        //        //                     itemDon.GiaBieu,
        //        //                     itemDon.DinhMuc,
        //        //                     itemDon.NoiDung,
        //        //                 };

        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table KTXM_ChiTiets
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemCTKTXM in db.KTXM_ChiTiets on itemDon.MaDon equals itemCTKTXM.KTXM.MaDon
        //        //             where itemCTKTXM.DiaChi.Contains(DiaChi)
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table BamChi_ChiTiets
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemCTBamChi in db.BamChi_ChiTiets on itemDon.MaDon equals itemCTBamChi.BamChi.MaDon
        //        //             where itemCTBamChi.DiaChi.Contains(DiaChi)
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table DCBD_ChiTietBienDongs
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemCTDCBD in db.DCBD_ChiTietBienDongs on itemDon.MaDon equals itemCTDCBD.DCBD.MaDon
        //        //             where itemCTDCBD.DiaChi.Contains(DiaChi)
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table DCBD_ChiTietHoaDons
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemCTDCHD in db.DCBD_ChiTietHoaDons on itemDon.MaDon equals itemCTDCHD.DCBD.MaDon
        //        //             where itemCTDCHD.DiaChi.Contains(DiaChi)
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table CHDB_ChiTietCatTams
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemCTCTDB in db.CHDB_ChiTietCatTams on itemDon.MaDon equals itemCTCTDB.CHDB.MaDon
        //        //             where itemCTCTDB.DiaChi.Contains(DiaChi)
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table CHDB_ChiTietCatHuys
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemCTCHDB in db.CHDB_ChiTietCatHuys on itemDon.MaDon equals itemCTCHDB.CHDB.MaDon
        //        //             where itemCTCHDB.DiaChi.Contains(DiaChi)
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////TablePhieuCHDBs
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemYCCHDB in db.CHDB_Phieus on itemDon.MaDon equals itemYCCHDB.CHDB.MaDon
        //        //             where itemYCCHDB.DiaChi.Contains(DiaChi)
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table ThuTraLoi_ChiTiets
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemCTTTTL in db.ThuTraLoi_ChiTiets on itemDon.MaDon equals itemCTTTTL.ThuTraLoi.MaDon
        //        //             where itemCTTTTL.DiaChi.Contains(DiaChi)
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table DongNuoc_ChiTiets
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemCTDongNuoc in db.DongNuoc_ChiTiets on itemDon.MaDon equals itemCTDongNuoc.DongNuoc.MaDon
        //        //             where itemCTDongNuoc.DiaChi.Contains(DiaChi)
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table GianLan_ChiTiets
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemGL in db.GianLan_ChiTiets on itemDon.MaDon equals itemGL.GianLan.MaDon
        //        //             where itemGL.DiaChi.Contains(DiaChi)
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table TruyThu
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemTT in db.TruyThuTienNuoc_ChiTiets on itemDon.MaDon equals itemTT.TruyThuTienNuoc.MaDon
        //        //             where itemTT.DiaChi.Contains(DiaChi)
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table ToTrinh
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemCTTT in db.ToTrinh_ChiTiets on itemDon.MaDon equals itemCTTT.ToTrinh.MaDon
        //        //             where itemCTTT.DiaChi.Contains(DiaChi)
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        /////Table ThuMoi
        //        //queryDonKH = from itemDon in db.DonKHs
        //        //             join itemTM in db.ThuMoi_ChiTiets on itemDon.MaDon equals itemTM.ThuMoi.MaDonTKH
        //        //             where itemTM.DiaChi.Contains(DiaChi)
        //        //             select new
        //        //             {
        //        //                 MaDon = "TKH" + itemDon.MaDon,
        //        //                 itemDon.LoaiDon.TenLD,
        //        //                 itemDon.CreateDate,
        //        //                 itemDon.DanhBo,
        //        //                 itemDon.HoTen,
        //        //                 itemDon.DiaChi,
        //        //                 itemDon.GiaBieu,
        //        //                 itemDon.DinhMuc,
        //        //                 itemDon.NoiDung,
        //        //             };
        //        //dt.Merge(LINQToDataTable(queryDonKH));

        //        //#endregion

        //        //#region DonTXL

        //        /////Table DonTXL
        //        //var queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //                  where itemDonTXL.DiaChi.Contains(DiaChi)
        //        //                  select new
        //        //                  {
        //        //                      MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                      itemDonTXL.LoaiDonTXL.TenLD,
        //        //                      itemDonTXL.CreateDate,
        //        //                      itemDonTXL.DanhBo,
        //        //                      itemDonTXL.HoTen,
        //        //                      itemDonTXL.DiaChi,
        //        //                      itemDonTXL.GiaBieu,
        //        //                      itemDonTXL.DinhMuc,
        //        //                      itemDonTXL.NoiDung,
        //        //                  };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table KTXM_ChiTiets
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemCTKTXM in db.KTXM_ChiTiets on itemDonTXL.MaDon equals itemCTKTXM.KTXM.MaDonTXL
        //        //              where itemCTKTXM.DiaChi.Contains(DiaChi)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table BamChi_ChiTiets
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemCTBamChi in db.BamChi_ChiTiets on itemDonTXL.MaDon equals itemCTBamChi.BamChi.MaDonTXL
        //        //              where itemCTBamChi.DiaChi.Contains(DiaChi)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table DCBD_ChiTietBienDongs
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemCTDCBD in db.DCBD_ChiTietBienDongs on itemDonTXL.MaDon equals itemCTDCBD.DCBD.MaDonTXL
        //        //              where itemCTDCBD.DiaChi.Contains(DiaChi)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table DCBD_ChiTietHoaDons
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemCTDCHD in db.DCBD_ChiTietHoaDons on itemDonTXL.MaDon equals itemCTDCHD.DCBD.MaDonTXL
        //        //              where itemCTDCHD.DiaChi.Contains(DiaChi)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table CHDB_ChiTietCatTams
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemCTCTDB in db.CHDB_ChiTietCatTams on itemDonTXL.MaDon equals itemCTCTDB.CHDB.MaDonTXL
        //        //              where itemCTCTDB.DiaChi.Contains(DiaChi)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table CHDB_ChiTietCatHuys
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemCTCHDB in db.CHDB_ChiTietCatHuys on itemDonTXL.MaDon equals itemCTCHDB.CHDB.MaDonTXL
        //        //              where itemCTCHDB.DiaChi.Contains(DiaChi)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table CHDB_Phieus
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemYCCHDB in db.CHDB_Phieus on itemDonTXL.MaDon equals itemYCCHDB.CHDB.MaDonTXL
        //        //              where itemYCCHDB.DiaChi.Contains(DiaChi)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table ThuTraLoi_ChiTiets
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemCTTTTL in db.ThuTraLoi_ChiTiets on itemDonTXL.MaDon equals itemCTTTTL.ThuTraLoi.MaDonTXL
        //        //              where itemCTTTTL.DiaChi.Contains(DiaChi)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table DongNuoc_ChiTiets
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemCTDongNuoc in db.DongNuoc_ChiTiets on itemDonTXL.MaDon equals itemCTDongNuoc.DongNuoc.MaDonTXL
        //        //              where itemCTDongNuoc.DiaChi.Contains(DiaChi)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table GianLan_ChiTiets
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemGL in db.GianLan_ChiTiets on itemDonTXL.MaDon equals itemGL.GianLan.MaDonTXL
        //        //              where itemGL.DiaChi.Contains(DiaChi)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table TruyThu
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemTT in db.TruyThuTienNuoc_ChiTiets on itemDonTXL.MaDon equals itemTT.TruyThuTienNuoc.MaDonTXL
        //        //              where itemTT.DiaChi.Contains(DiaChi)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table ToTrinh
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemCTTT in db.ToTrinh_ChiTiets on itemDonTXL.MaDon equals itemCTTT.ToTrinh.MaDonTXL
        //        //              where itemCTTT.DiaChi.Contains(DiaChi)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        /////Table ThuMoi
        //        //queryDonTXL = from itemDonTXL in db.DonTXLs
        //        //              join itemTM in db.ThuMoi_ChiTiets on itemDonTXL.MaDon equals itemTM.ThuMoi.MaDonTXL
        //        //              where itemTM.DiaChi.Contains(DiaChi)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TXL" + itemDonTXL.MaDon,
        //        //                  itemDonTXL.LoaiDonTXL.TenLD,
        //        //                  itemDonTXL.CreateDate,
        //        //                  itemDonTXL.DanhBo,
        //        //                  itemDonTXL.HoTen,
        //        //                  itemDonTXL.DiaChi,
        //        //                  itemDonTXL.GiaBieu,
        //        //                  itemDonTXL.DinhMuc,
        //        //                  itemDonTXL.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTXL));

        //        //#endregion

        //        //#region DonTBC

        //        /////Table DonTBC
        //        //var queryDonTBC = from itemDon in db.DonTBCs
        //        //                  where itemDon.DiaChi.Contains(DiaChi)
        //        //                  select new
        //        //                  {
        //        //                      MaDon = "TBC" + itemDon.MaDon,
        //        //                      itemDon.LoaiDonTBC.TenLD,
        //        //                      itemDon.CreateDate,
        //        //                      itemDon.DanhBo,
        //        //                      itemDon.HoTen,
        //        //                      itemDon.DiaChi,
        //        //                      itemDon.GiaBieu,
        //        //                      itemDon.DinhMuc,
        //        //                      itemDon.NoiDung,
        //        //                  };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table KTXM_ChiTiets
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemCTKTXM in db.KTXM_ChiTiets on itemDon.MaDon equals itemCTKTXM.KTXM.MaDonTBC
        //        //              where itemCTKTXM.DiaChi.Contains(DiaChi)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table BamChi_ChiTiets
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemCTBamChi in db.BamChi_ChiTiets on itemDon.MaDon equals itemCTBamChi.BamChi.MaDonTBC
        //        //              where itemCTBamChi.DiaChi.Contains(DiaChi)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table DCBD_ChiTietBienDongs
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemCTDCBD in db.DCBD_ChiTietBienDongs on itemDon.MaDon equals itemCTDCBD.DCBD.MaDonTBC
        //        //              where itemCTDCBD.DiaChi.Contains(DiaChi)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table DCBD_ChiTietHoaDons
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemCTDCHD in db.DCBD_ChiTietHoaDons on itemDon.MaDon equals itemCTDCHD.DCBD.MaDonTBC
        //        //              where itemCTDCHD.DiaChi.Contains(DiaChi)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table CHDB_ChiTietCatTams
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemCTCTDB in db.CHDB_ChiTietCatTams on itemDon.MaDon equals itemCTCTDB.CHDB.MaDonTBC
        //        //              where itemCTCTDB.DiaChi.Contains(DiaChi)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table CHDB_ChiTietCatHuys
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemCTCHDB in db.CHDB_ChiTietCatHuys on itemDon.MaDon equals itemCTCHDB.CHDB.MaDonTBC
        //        //              where itemCTCHDB.DiaChi.Contains(DiaChi)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////TablePhieuCHDBs
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemYCCHDB in db.CHDB_Phieus on itemDon.MaDon equals itemYCCHDB.CHDB.MaDonTBC
        //        //              where itemYCCHDB.DiaChi.Contains(DiaChi)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table ThuTraLoi_ChiTiets
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemCTTTTL in db.ThuTraLoi_ChiTiets on itemDon.MaDon equals itemCTTTTL.ThuTraLoi.MaDonTBC
        //        //              where itemCTTTTL.DiaChi.Contains(DiaChi)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table DongNuoc_ChiTiets
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemCTDongNuoc in db.DongNuoc_ChiTiets on itemDon.MaDon equals itemCTDongNuoc.DongNuoc.MaDonTBC
        //        //              where itemCTDongNuoc.DiaChi.Contains(DiaChi)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table GianLan_ChiTiets
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemGL in db.GianLan_ChiTiets on itemDon.MaDon equals itemGL.GianLan.MaDonTBC
        //        //              where itemGL.DiaChi.Contains(DiaChi)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table TruyThu
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemTT in db.TruyThuTienNuoc_ChiTiets on itemDon.MaDon equals itemTT.TruyThuTienNuoc.MaDonTBC
        //        //              where itemTT.DiaChi.Contains(DiaChi)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table ToTrinh
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemCTTT in db.ToTrinh_ChiTiets on itemDon.MaDon equals itemCTTT.ToTrinh.MaDonTBC
        //        //              where itemCTTT.DiaChi.Contains(DiaChi)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        /////Table ThuMoi
        //        //queryDonTBC = from itemDon in db.DonTBCs
        //        //              join itemTM in db.ThuMoi_ChiTiets on itemDon.MaDon equals itemTM.ThuMoi.MaDonTBC
        //        //              where itemTM.DiaChi.Contains(DiaChi)
        //        //              select new
        //        //              {
        //        //                  MaDon = "TBC" + itemDon.MaDon,
        //        //                  itemDon.LoaiDonTBC.TenLD,
        //        //                  itemDon.CreateDate,
        //        //                  itemDon.DanhBo,
        //        //                  itemDon.HoTen,
        //        //                  itemDon.DiaChi,
        //        //                  itemDon.GiaBieu,
        //        //                  itemDon.DinhMuc,
        //        //                  itemDon.NoiDung,
        //        //              };
        //        //dt.Merge(LINQToDataTable(queryDonTBC));

        //        //#endregion

        //        #endregion

        //        #region DonTu

        //        ///Table DonTu
        //        var queryDonTu = from itemDon in db.DonTu_ChiTiets
        //                         where itemDon.DiaChi.Contains(DiaChi)
        //                         select new
        //                         {
        //                             MaDon = itemDon.DonTu.DonTu_ChiTiets.Count() == 1 ? itemDon.MaDon.Value.ToString() : itemDon.MaDon + "." + itemDon.STT,
        //                             TenLD = "",
        //                             itemDon.CreateDate,
        //                             itemDon.DanhBo,
        //                             itemDon.HoTen,
        //                             itemDon.DiaChi,
        //                             itemDon.GiaBieu,
        //                             itemDon.DinhMuc,
        //                             NoiDung = itemDon.DonTu.Name_NhomDon,
        //                         };
        //        dt = LINQToDataTable(queryDonTu);

        //        var queryDonKH = from itemDon in db.DonKHs
        //                         where itemDon.DiaChi.Contains(DiaChi)
        //                         select new
        //                         {
        //                             MaDon = "TKH" + itemDon.MaDon,
        //                             itemDon.LoaiDon.TenLD,
        //                             itemDon.CreateDate,
        //                             itemDon.DanhBo,
        //                             itemDon.HoTen,
        //                             itemDon.DiaChi,
        //                             itemDon.GiaBieu,
        //                             itemDon.DinhMuc,
        //                             itemDon.NoiDung,
        //                         };
        //        dt.Merge(LINQToDataTable(queryDonKH));

        //        var queryDonTXL = from itemDon in db.DonTXLs
        //                          where itemDon.DiaChi.Contains(DiaChi)
        //                          select new
        //                          {
        //                              MaDon = "TXL" + itemDon.MaDon,
        //                              itemDon.LoaiDonTXL.TenLD,
        //                              itemDon.CreateDate,
        //                              itemDon.DanhBo,
        //                              itemDon.HoTen,
        //                              itemDon.DiaChi,
        //                              itemDon.GiaBieu,
        //                              itemDon.DinhMuc,
        //                              itemDon.NoiDung,
        //                          };
        //        dt.Merge(LINQToDataTable(queryDonTXL));

        //        var queryDonTBC = from itemDon in db.DonTBCs
        //                          where itemDon.DiaChi.Contains(DiaChi)
        //                          select new
        //                          {
        //                              MaDon = "TBC" + itemDon.MaDon,
        //                              itemDon.LoaiDonTBC.TenLD,
        //                              itemDon.CreateDate,
        //                              itemDon.DanhBo,
        //                              itemDon.HoTen,
        //                              itemDon.DiaChi,
        //                              itemDon.GiaBieu,
        //                              itemDon.DinhMuc,
        //                              itemDon.NoiDung,
        //                          };
        //        dt.Merge(LINQToDataTable(queryDonTBC));

        //        ///Table KTXM_ChiTiets
        //        queryDonTu = from item in db.KTXM_ChiTiets
        //                     where item.DiaChi.Contains(DiaChi)
        //                     select new
        //                     {
        //                         MaDon = item.KTXM.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.KTXM.MaDonMoi).Count() == 1 ? item.KTXM.MaDonMoi.Value.ToString() : item.KTXM.MaDonMoi + "." + item.STT
        //                            : item.KTXM.MaDon != null ? "TKH" + item.KTXM.MaDon
        //                            : item.KTXM.MaDonTXL != null ? "TXL" + item.KTXM.MaDonTXL
        //                            : item.KTXM.MaDonTBC != null ? "TBC" + item.KTXM.MaDonTBC : null,
        //                         TenLD = item.KTXM.MaDonMoi != null ? ""
        //                            : item.KTXM.MaDon != null ? item.KTXM.DonKH.LoaiDon.TenLD
        //                            : item.KTXM.MaDonTXL != null ? item.KTXM.DonTXL.LoaiDonTXL.TenLD
        //                            : item.KTXM.MaDonTBC != null ? item.KTXM.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.KTXM.MaDonMoi != null ? item.KTXM.DonTu.CreateDate
        //                            : item.KTXM.MaDon != null ? item.KTXM.DonKH.CreateDate
        //                            : item.KTXM.MaDonTXL != null ? item.KTXM.DonTXL.CreateDate
        //                            : item.KTXM.MaDonTBC != null ? item.KTXM.DonTBC.CreateDate : null,
        //                         DanhBo = item.KTXM.MaDonMoi != null ? item.KTXM.DonTu.DanhBo
        //                            : item.KTXM.MaDon != null ? item.KTXM.DonKH.DanhBo
        //                            : item.KTXM.MaDonTXL != null ? item.KTXM.DonTXL.DanhBo
        //                            : item.KTXM.MaDonTBC != null ? item.KTXM.DonTBC.DanhBo : null,
        //                         HoTen = item.KTXM.MaDonMoi != null ? item.KTXM.DonTu.HoTen
        //                            : item.KTXM.MaDon != null ? item.KTXM.DonKH.HoTen
        //                            : item.KTXM.MaDonTXL != null ? item.KTXM.DonTXL.HoTen
        //                            : item.KTXM.MaDonTBC != null ? item.KTXM.DonTBC.HoTen : null,
        //                         DiaChi = item.KTXM.MaDonMoi != null ? item.KTXM.DonTu.DiaChi
        //                            : item.KTXM.MaDon != null ? item.KTXM.DonKH.DiaChi
        //                            : item.KTXM.MaDonTXL != null ? item.KTXM.DonTXL.DiaChi
        //                            : item.KTXM.MaDonTBC != null ? item.KTXM.DonTBC.DiaChi : null,
        //                         GiaBieu = item.KTXM.MaDonMoi != null ? item.KTXM.DonTu.GiaBieu
        //                            : item.KTXM.MaDon != null ? item.KTXM.DonKH.GiaBieu
        //                            : item.KTXM.MaDonTXL != null ? item.KTXM.DonTXL.GiaBieu
        //                            : item.KTXM.MaDonTBC != null ? item.KTXM.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.KTXM.MaDonMoi != null ? item.KTXM.DonTu.DinhMuc
        //                            : item.KTXM.MaDon != null ? item.KTXM.DonKH.DinhMuc
        //                            : item.KTXM.MaDonTXL != null ? item.KTXM.DonTXL.DinhMuc
        //                            : item.KTXM.MaDonTBC != null ? item.KTXM.DonTBC.DinhMuc : null,
        //                         NoiDung = item.KTXM.MaDonMoi != null ? item.KTXM.DonTu.Name_NhomDon
        //                            : item.KTXM.MaDon != null ? item.KTXM.DonKH.NoiDung
        //                            : item.KTXM.MaDonTXL != null ? item.KTXM.DonTXL.NoiDung
        //                            : item.KTXM.MaDonTBC != null ? item.KTXM.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///Table BamChi_ChiTiets
        //        queryDonTu = from item in db.BamChi_ChiTiets
        //                     where item.DiaChi.Contains(DiaChi)
        //                     select new
        //                     {
        //                         MaDon = item.BamChi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.BamChi.MaDonMoi).Count() == 1 ? item.BamChi.MaDonMoi.Value.ToString() : item.BamChi.MaDonMoi + "." + item.STT
        //                            : item.BamChi.MaDon != null ? "TKH" + item.BamChi.MaDon
        //                            : item.BamChi.MaDonTXL != null ? "TXL" + item.BamChi.MaDonTXL
        //                            : item.BamChi.MaDonTBC != null ? "TBC" + item.BamChi.MaDonTBC : null,
        //                         TenLD = item.BamChi.MaDonMoi != null ? ""
        //                            : item.BamChi.MaDon != null ? item.BamChi.DonKH.LoaiDon.TenLD
        //                            : item.BamChi.MaDonTXL != null ? item.BamChi.DonTXL.LoaiDonTXL.TenLD
        //                            : item.BamChi.MaDonTBC != null ? item.BamChi.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.BamChi.MaDonMoi != null ? item.BamChi.DonTu.CreateDate
        //                            : item.BamChi.MaDon != null ? item.BamChi.DonKH.CreateDate
        //                            : item.BamChi.MaDonTXL != null ? item.BamChi.DonTXL.CreateDate
        //                            : item.BamChi.MaDonTBC != null ? item.BamChi.DonTBC.CreateDate : null,
        //                         DanhBo = item.BamChi.MaDonMoi != null ? item.BamChi.DonTu.DanhBo
        //                            : item.BamChi.MaDon != null ? item.BamChi.DonKH.DanhBo
        //                            : item.BamChi.MaDonTXL != null ? item.BamChi.DonTXL.DanhBo
        //                            : item.BamChi.MaDonTBC != null ? item.BamChi.DonTBC.DanhBo : null,
        //                         HoTen = item.BamChi.MaDonMoi != null ? item.BamChi.DonTu.HoTen
        //                            : item.BamChi.MaDon != null ? item.BamChi.DonKH.HoTen
        //                            : item.BamChi.MaDonTXL != null ? item.BamChi.DonTXL.HoTen
        //                            : item.BamChi.MaDonTBC != null ? item.BamChi.DonTBC.HoTen : null,
        //                         DiaChi = item.BamChi.MaDonMoi != null ? item.BamChi.DonTu.DiaChi
        //                            : item.BamChi.MaDon != null ? item.BamChi.DonKH.DiaChi
        //                            : item.BamChi.MaDonTXL != null ? item.BamChi.DonTXL.DiaChi
        //                            : item.BamChi.MaDonTBC != null ? item.BamChi.DonTBC.DiaChi : null,
        //                         GiaBieu = item.BamChi.MaDonMoi != null ? item.BamChi.DonTu.GiaBieu
        //                            : item.BamChi.MaDon != null ? item.BamChi.DonKH.GiaBieu
        //                            : item.BamChi.MaDonTXL != null ? item.BamChi.DonTXL.GiaBieu
        //                            : item.BamChi.MaDonTBC != null ? item.BamChi.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.BamChi.MaDonMoi != null ? item.BamChi.DonTu.DinhMuc
        //                            : item.BamChi.MaDon != null ? item.BamChi.DonKH.DinhMuc
        //                            : item.BamChi.MaDonTXL != null ? item.BamChi.DonTXL.DinhMuc
        //                            : item.BamChi.MaDonTBC != null ? item.BamChi.DonTBC.DinhMuc : null,
        //                         NoiDung = item.BamChi.MaDonMoi != null ? item.BamChi.DonTu.Name_NhomDon
        //                            : item.BamChi.MaDon != null ? item.BamChi.DonKH.NoiDung
        //                            : item.BamChi.MaDonTXL != null ? item.BamChi.DonTXL.NoiDung
        //                            : item.BamChi.MaDonTBC != null ? item.BamChi.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///Table DongNuoc_ChiTiets
        //        queryDonTu = from item in db.DongNuoc_ChiTiets
        //                     where item.DiaChi.Contains(DiaChi)
        //                     select new
        //                     {
        //                         MaDon = item.DongNuoc.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.DongNuoc.MaDonMoi).Count() == 1 ? item.DongNuoc.MaDonMoi.Value.ToString() : item.DongNuoc.MaDonMoi + "." + item.STT
        //                            : item.DongNuoc.MaDon != null ? "TKH" + item.DongNuoc.MaDon
        //                            : item.DongNuoc.MaDonTXL != null ? "TXL" + item.DongNuoc.MaDonTXL
        //                            : item.DongNuoc.MaDonTBC != null ? "TBC" + item.DongNuoc.MaDonTBC : null,
        //                         TenLD = item.DongNuoc.MaDonMoi != null ? ""
        //                            : item.DongNuoc.MaDon != null ? item.DongNuoc.DonKH.LoaiDon.TenLD
        //                            : item.DongNuoc.MaDonTXL != null ? item.DongNuoc.DonTXL.LoaiDonTXL.TenLD
        //                            : item.DongNuoc.MaDonTBC != null ? item.DongNuoc.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.DongNuoc.MaDonMoi != null ? item.DongNuoc.DonTu.CreateDate
        //                            : item.DongNuoc.MaDon != null ? item.DongNuoc.DonKH.CreateDate
        //                            : item.DongNuoc.MaDonTXL != null ? item.DongNuoc.DonTXL.CreateDate
        //                            : item.DongNuoc.MaDonTBC != null ? item.DongNuoc.DonTBC.CreateDate : null,
        //                         DanhBo = item.DongNuoc.MaDonMoi != null ? item.DongNuoc.DonTu.DanhBo
        //                            : item.DongNuoc.MaDon != null ? item.DongNuoc.DonKH.DanhBo
        //                            : item.DongNuoc.MaDonTXL != null ? item.DongNuoc.DonTXL.DanhBo
        //                            : item.DongNuoc.MaDonTBC != null ? item.DongNuoc.DonTBC.DanhBo : null,
        //                         HoTen = item.DongNuoc.MaDonMoi != null ? item.DongNuoc.DonTu.HoTen
        //                            : item.DongNuoc.MaDon != null ? item.DongNuoc.DonKH.HoTen
        //                            : item.DongNuoc.MaDonTXL != null ? item.DongNuoc.DonTXL.HoTen
        //                            : item.DongNuoc.MaDonTBC != null ? item.DongNuoc.DonTBC.HoTen : null,
        //                         DiaChi = item.DongNuoc.MaDonMoi != null ? item.DongNuoc.DonTu.DiaChi
        //                            : item.DongNuoc.MaDon != null ? item.DongNuoc.DonKH.DiaChi
        //                            : item.DongNuoc.MaDonTXL != null ? item.DongNuoc.DonTXL.DiaChi
        //                            : item.DongNuoc.MaDonTBC != null ? item.DongNuoc.DonTBC.DiaChi : null,
        //                         GiaBieu = item.DongNuoc.MaDonMoi != null ? item.DongNuoc.DonTu.GiaBieu
        //                            : item.DongNuoc.MaDon != null ? item.DongNuoc.DonKH.GiaBieu
        //                            : item.DongNuoc.MaDonTXL != null ? item.DongNuoc.DonTXL.GiaBieu
        //                            : item.DongNuoc.MaDonTBC != null ? item.DongNuoc.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.DongNuoc.MaDonMoi != null ? item.DongNuoc.DonTu.DinhMuc
        //                            : item.DongNuoc.MaDon != null ? item.DongNuoc.DonKH.DinhMuc
        //                            : item.DongNuoc.MaDonTXL != null ? item.DongNuoc.DonTXL.DinhMuc
        //                            : item.DongNuoc.MaDonTBC != null ? item.DongNuoc.DonTBC.DinhMuc : null,
        //                         NoiDung = item.DongNuoc.MaDonMoi != null ? item.DongNuoc.DonTu.Name_NhomDon
        //                            : item.DongNuoc.MaDon != null ? item.DongNuoc.DonKH.NoiDung
        //                            : item.DongNuoc.MaDonTXL != null ? item.DongNuoc.DonTXL.NoiDung
        //                            : item.DongNuoc.MaDonTBC != null ? item.DongNuoc.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///Table DCBD_ChiTietBienDongs
        //        queryDonTu = from item in db.DCBD_ChiTietBienDongs
        //                     where item.DiaChi.Contains(DiaChi)
        //                     select new
        //                     {
        //                         MaDon = item.DCBD.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.DCBD.MaDonMoi).Count() == 1 ? item.DCBD.MaDonMoi.Value.ToString() : item.DCBD.MaDonMoi + "." + item.STT
        //                            : item.DCBD.MaDon != null ? "TKH" + item.DCBD.MaDon
        //                            : item.DCBD.MaDonTXL != null ? "TXL" + item.DCBD.MaDonTXL
        //                            : item.DCBD.MaDonTBC != null ? "TBC" + item.DCBD.MaDonTBC : null,
        //                         TenLD = item.DCBD.MaDonMoi != null ? ""
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.LoaiDon.TenLD
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.LoaiDonTXL.TenLD
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.CreateDate
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.CreateDate
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.CreateDate
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.CreateDate : null,
        //                         DanhBo = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.DanhBo
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.DanhBo
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.DanhBo
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.DanhBo : null,
        //                         HoTen = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.HoTen
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.HoTen
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.HoTen
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.HoTen : null,
        //                         DiaChi = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.DiaChi
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.DiaChi
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.DiaChi
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.DiaChi : null,
        //                         GiaBieu = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.GiaBieu
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.GiaBieu
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.GiaBieu
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.DinhMuc
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.DinhMuc
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.DinhMuc
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.DinhMuc : null,
        //                         NoiDung = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.Name_NhomDon
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.NoiDung
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.NoiDung
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///Table DCBD_ChiTietHoaDons
        //        queryDonTu = from item in db.DCBD_ChiTietHoaDons
        //                     where item.DiaChi.Contains(DiaChi)
        //                     select new
        //                     {
        //                         MaDon = item.DCBD.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.DCBD.MaDonMoi).Count() == 1 ? item.DCBD.MaDonMoi.Value.ToString() : item.DCBD.MaDonMoi + "." + item.STT
        //                            : item.DCBD.MaDon != null ? "TKH" + item.DCBD.MaDon
        //                            : item.DCBD.MaDonTXL != null ? "TXL" + item.DCBD.MaDonTXL
        //                            : item.DCBD.MaDonTBC != null ? "TBC" + item.DCBD.MaDonTBC : null,
        //                         TenLD = item.DCBD.MaDonMoi != null ? ""
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.LoaiDon.TenLD
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.LoaiDonTXL.TenLD
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.CreateDate
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.CreateDate
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.CreateDate
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.CreateDate : null,
        //                         DanhBo = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.DanhBo
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.DanhBo
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.DanhBo
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.DanhBo : null,
        //                         HoTen = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.HoTen
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.HoTen
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.HoTen
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.HoTen : null,
        //                         DiaChi = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.DiaChi
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.DiaChi
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.DiaChi
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.DiaChi : null,
        //                         GiaBieu = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.GiaBieu
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.GiaBieu
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.GiaBieu
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.DinhMuc
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.DinhMuc
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.DinhMuc
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.DinhMuc : null,
        //                         NoiDung = item.DCBD.MaDonMoi != null ? item.DCBD.DonTu.Name_NhomDon
        //                            : item.DCBD.MaDon != null ? item.DCBD.DonKH.NoiDung
        //                            : item.DCBD.MaDonTXL != null ? item.DCBD.DonTXL.NoiDung
        //                            : item.DCBD.MaDonTBC != null ? item.DCBD.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///Table CHDB_ChiTietCatTams
        //        queryDonTu = from item in db.CHDB_ChiTietCatTams
        //                     where item.DiaChi.Contains(DiaChi)
        //                     select new
        //                     {
        //                         MaDon = item.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.CHDB.MaDonMoi).Count() == 1 ? item.CHDB.MaDonMoi.Value.ToString() : item.CHDB.MaDonMoi + "." + item.STT
        //                             : item.CHDB.MaDon != null ? "TKH" + item.CHDB.MaDon
        //                             : item.CHDB.MaDonTXL != null ? "TXL" + item.CHDB.MaDonTXL
        //                             : item.CHDB.MaDonTBC != null ? "TBC" + item.CHDB.MaDonTBC : null,
        //                         TenLD = item.CHDB.MaDonMoi != null ? ""
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.LoaiDon.TenLD
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.LoaiDonTXL.TenLD
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.CreateDate
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.CreateDate
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.CreateDate
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.CreateDate : null,
        //                         DanhBo = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.DanhBo
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.DanhBo
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.DanhBo
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.DanhBo : null,
        //                         HoTen = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.HoTen
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.HoTen
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.HoTen
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.HoTen : null,
        //                         DiaChi = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.DiaChi
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.DiaChi
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.DiaChi
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.DiaChi : null,
        //                         GiaBieu = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.GiaBieu
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.GiaBieu
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.GiaBieu
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.DinhMuc
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.DinhMuc
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.DinhMuc
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.DinhMuc : null,
        //                         NoiDung = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.Name_NhomDon
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.NoiDung
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.NoiDung
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///Table CHDB_ChiTietCatHuys
        //        queryDonTu = from item in db.CHDB_ChiTietCatHuys
        //                     where item.DiaChi.Contains(DiaChi)
        //                     select new
        //                     {
        //                         MaDon = item.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.CHDB.MaDonMoi).Count() == 1 ? item.CHDB.MaDonMoi.Value.ToString() : item.CHDB.MaDonMoi + "." + item.STT
        //                             : item.CHDB.MaDon != null ? "TKH" + item.CHDB.MaDon
        //                             : item.CHDB.MaDonTXL != null ? "TXL" + item.CHDB.MaDonTXL
        //                             : item.CHDB.MaDonTBC != null ? "TBC" + item.CHDB.MaDonTBC : null,
        //                         TenLD = item.CHDB.MaDonMoi != null ? ""
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.LoaiDon.TenLD
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.LoaiDonTXL.TenLD
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.CreateDate
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.CreateDate
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.CreateDate
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.CreateDate : null,
        //                         DanhBo = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.DanhBo
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.DanhBo
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.DanhBo
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.DanhBo : null,
        //                         HoTen = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.HoTen
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.HoTen
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.HoTen
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.HoTen : null,
        //                         DiaChi = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.DiaChi
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.DiaChi
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.DiaChi
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.DiaChi : null,
        //                         GiaBieu = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.GiaBieu
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.GiaBieu
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.GiaBieu
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.DinhMuc
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.DinhMuc
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.DinhMuc
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.DinhMuc : null,
        //                         NoiDung = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.Name_NhomDon
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.NoiDung
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.NoiDung
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///TablePhieuCHDBs
        //        queryDonTu = from item in db.CHDB_Phieus
        //                     where item.DiaChi.Contains(DiaChi)
        //                     select new
        //                     {
        //                         MaDon = item.CHDB.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.CHDB.MaDonMoi).Count() == 1 ? item.CHDB.MaDonMoi.Value.ToString() : item.CHDB.MaDonMoi + "." + item.STT
        //                             : item.CHDB.MaDon != null ? "TKH" + item.CHDB.MaDon
        //                             : item.CHDB.MaDonTXL != null ? "TXL" + item.CHDB.MaDonTXL
        //                             : item.CHDB.MaDonTBC != null ? "TBC" + item.CHDB.MaDonTBC : null,
        //                         TenLD = item.CHDB.MaDonMoi != null ? ""
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.LoaiDon.TenLD
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.LoaiDonTXL.TenLD
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.CreateDate
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.CreateDate
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.CreateDate
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.CreateDate : null,
        //                         DanhBo = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.DanhBo
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.DanhBo
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.DanhBo
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.DanhBo : null,
        //                         HoTen = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.HoTen
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.HoTen
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.HoTen
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.HoTen : null,
        //                         DiaChi = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.DiaChi
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.DiaChi
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.DiaChi
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.DiaChi : null,
        //                         GiaBieu = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.GiaBieu
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.GiaBieu
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.GiaBieu
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.DinhMuc
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.DinhMuc
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.DinhMuc
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.DinhMuc : null,
        //                         NoiDung = item.CHDB.MaDonMoi != null ? item.CHDB.DonTu.Name_NhomDon
        //                            : item.CHDB.MaDon != null ? item.CHDB.DonKH.NoiDung
        //                            : item.CHDB.MaDonTXL != null ? item.CHDB.DonTXL.NoiDung
        //                            : item.CHDB.MaDonTBC != null ? item.CHDB.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///Table ThuTraLoi_ChiTiets
        //        queryDonTu = from item in db.ThuTraLoi_ChiTiets
        //                     where item.DiaChi.Contains(DiaChi)
        //                     select new
        //                     {
        //                         MaDon = item.ThuTraLoi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.ThuTraLoi.MaDonMoi).Count() == 1 ? item.ThuTraLoi.MaDonMoi.Value.ToString() : item.ThuTraLoi.MaDonMoi + "." + item.STT
        //                            : item.ThuTraLoi.MaDon != null ? "TKH" + item.ThuTraLoi.MaDon
        //                            : item.ThuTraLoi.MaDonTXL != null ? "TXL" + item.ThuTraLoi.MaDonTXL
        //                            : item.ThuTraLoi.MaDonTBC != null ? "TBC" + item.ThuTraLoi.MaDonTBC : null,
        //                         TenLD = item.ThuTraLoi.MaDonMoi != null ? ""
        //                            : item.ThuTraLoi.MaDon != null ? item.ThuTraLoi.DonKH.LoaiDon.TenLD
        //                            : item.ThuTraLoi.MaDonTXL != null ? item.ThuTraLoi.DonTXL.LoaiDonTXL.TenLD
        //                            : item.ThuTraLoi.MaDonTBC != null ? item.ThuTraLoi.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.ThuTraLoi.MaDonMoi != null ? item.ThuTraLoi.DonTu.CreateDate
        //                            : item.ThuTraLoi.MaDon != null ? item.ThuTraLoi.DonKH.CreateDate
        //                            : item.ThuTraLoi.MaDonTXL != null ? item.ThuTraLoi.DonTXL.CreateDate
        //                            : item.ThuTraLoi.MaDonTBC != null ? item.ThuTraLoi.DonTBC.CreateDate : null,
        //                         DanhBo = item.ThuTraLoi.MaDonMoi != null ? item.ThuTraLoi.DonTu.DanhBo
        //                            : item.ThuTraLoi.MaDon != null ? item.ThuTraLoi.DonKH.DanhBo
        //                            : item.ThuTraLoi.MaDonTXL != null ? item.ThuTraLoi.DonTXL.DanhBo
        //                            : item.ThuTraLoi.MaDonTBC != null ? item.ThuTraLoi.DonTBC.DanhBo : null,
        //                         HoTen = item.ThuTraLoi.MaDonMoi != null ? item.ThuTraLoi.DonTu.HoTen
        //                            : item.ThuTraLoi.MaDon != null ? item.ThuTraLoi.DonKH.HoTen
        //                            : item.ThuTraLoi.MaDonTXL != null ? item.ThuTraLoi.DonTXL.HoTen
        //                            : item.ThuTraLoi.MaDonTBC != null ? item.ThuTraLoi.DonTBC.HoTen : null,
        //                         DiaChi = item.ThuTraLoi.MaDonMoi != null ? item.ThuTraLoi.DonTu.DiaChi
        //                            : item.ThuTraLoi.MaDon != null ? item.ThuTraLoi.DonKH.DiaChi
        //                            : item.ThuTraLoi.MaDonTXL != null ? item.ThuTraLoi.DonTXL.DiaChi
        //                            : item.ThuTraLoi.MaDonTBC != null ? item.ThuTraLoi.DonTBC.DiaChi : null,
        //                         GiaBieu = item.ThuTraLoi.MaDonMoi != null ? item.ThuTraLoi.DonTu.GiaBieu
        //                            : item.ThuTraLoi.MaDon != null ? item.ThuTraLoi.DonKH.GiaBieu
        //                            : item.ThuTraLoi.MaDonTXL != null ? item.ThuTraLoi.DonTXL.GiaBieu
        //                            : item.ThuTraLoi.MaDonTBC != null ? item.ThuTraLoi.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.ThuTraLoi.MaDonMoi != null ? item.ThuTraLoi.DonTu.DinhMuc
        //                            : item.ThuTraLoi.MaDon != null ? item.ThuTraLoi.DonKH.DinhMuc
        //                            : item.ThuTraLoi.MaDonTXL != null ? item.ThuTraLoi.DonTXL.DinhMuc
        //                            : item.ThuTraLoi.MaDonTBC != null ? item.ThuTraLoi.DonTBC.DinhMuc : null,
        //                         NoiDung = item.ThuTraLoi.MaDonMoi != null ? item.ThuTraLoi.DonTu.Name_NhomDon
        //                            : item.ThuTraLoi.MaDon != null ? item.ThuTraLoi.DonKH.NoiDung
        //                            : item.ThuTraLoi.MaDonTXL != null ? item.ThuTraLoi.DonTXL.NoiDung
        //                            : item.ThuTraLoi.MaDonTBC != null ? item.ThuTraLoi.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///Table GianLan_ChiTiets
        //        queryDonTu = from item in db.GianLan_ChiTiets
        //                     where item.DiaChi.Contains(DiaChi)
        //                     select new
        //                     {
        //                         MaDon = item.GianLan.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.GianLan.MaDonMoi).Count() == 1 ? item.GianLan.MaDonMoi.Value.ToString() : item.GianLan.MaDonMoi + "." + item.STT
        //                            : item.GianLan.MaDon != null ? "TKH" + item.GianLan.MaDon
        //                            : item.GianLan.MaDonTXL != null ? "TXL" + item.GianLan.MaDonTXL
        //                            : item.GianLan.MaDonTBC != null ? "TBC" + item.GianLan.MaDonTBC : null,
        //                         TenLD = item.GianLan.MaDonMoi != null ? ""
        //                            : item.GianLan.MaDon != null ? item.GianLan.DonKH.LoaiDon.TenLD
        //                            : item.GianLan.MaDonTXL != null ? item.GianLan.DonTXL.LoaiDonTXL.TenLD
        //                            : item.GianLan.MaDonTBC != null ? item.GianLan.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.GianLan.MaDonMoi != null ? item.GianLan.DonTu.CreateDate
        //                            : item.GianLan.MaDon != null ? item.GianLan.DonKH.CreateDate
        //                            : item.GianLan.MaDonTXL != null ? item.GianLan.DonTXL.CreateDate
        //                            : item.GianLan.MaDonTBC != null ? item.GianLan.DonTBC.CreateDate : null,
        //                         DanhBo = item.GianLan.MaDonMoi != null ? item.GianLan.DonTu.DanhBo
        //                            : item.GianLan.MaDon != null ? item.GianLan.DonKH.DanhBo
        //                            : item.GianLan.MaDonTXL != null ? item.GianLan.DonTXL.DanhBo
        //                            : item.GianLan.MaDonTBC != null ? item.GianLan.DonTBC.DanhBo : null,
        //                         HoTen = item.GianLan.MaDonMoi != null ? item.GianLan.DonTu.HoTen
        //                            : item.GianLan.MaDon != null ? item.GianLan.DonKH.HoTen
        //                            : item.GianLan.MaDonTXL != null ? item.GianLan.DonTXL.HoTen
        //                            : item.GianLan.MaDonTBC != null ? item.GianLan.DonTBC.HoTen : null,
        //                         DiaChi = item.GianLan.MaDonMoi != null ? item.GianLan.DonTu.DiaChi
        //                            : item.GianLan.MaDon != null ? item.GianLan.DonKH.DiaChi
        //                            : item.GianLan.MaDonTXL != null ? item.GianLan.DonTXL.DiaChi
        //                            : item.GianLan.MaDonTBC != null ? item.GianLan.DonTBC.DiaChi : null,
        //                         GiaBieu = item.GianLan.MaDonMoi != null ? item.GianLan.DonTu.GiaBieu
        //                            : item.GianLan.MaDon != null ? item.GianLan.DonKH.GiaBieu
        //                            : item.GianLan.MaDonTXL != null ? item.GianLan.DonTXL.GiaBieu
        //                            : item.GianLan.MaDonTBC != null ? item.GianLan.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.GianLan.MaDonMoi != null ? item.GianLan.DonTu.DinhMuc
        //                            : item.GianLan.MaDon != null ? item.GianLan.DonKH.DinhMuc
        //                            : item.GianLan.MaDonTXL != null ? item.GianLan.DonTXL.DinhMuc
        //                            : item.GianLan.MaDonTBC != null ? item.GianLan.DonTBC.DinhMuc : null,
        //                         NoiDung = item.GianLan.MaDonMoi != null ? item.GianLan.DonTu.Name_NhomDon
        //                            : item.GianLan.MaDon != null ? item.GianLan.DonKH.NoiDung
        //                            : item.GianLan.MaDonTXL != null ? item.GianLan.DonTXL.NoiDung
        //                            : item.GianLan.MaDonTBC != null ? item.GianLan.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///Table TruyThu
        //        queryDonTu = from item in db.TruyThuTienNuoc_ChiTiets
        //                     where item.DiaChi.Contains(DiaChi)
        //                     select new
        //                     {
        //                         MaDon = item.TruyThuTienNuoc.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.TruyThuTienNuoc.MaDonMoi).Count() == 1 ? item.TruyThuTienNuoc.MaDonMoi.Value.ToString() : item.TruyThuTienNuoc.MaDonMoi + "." + item.STT
        //                            : item.TruyThuTienNuoc.MaDon != null ? "TKH" + item.TruyThuTienNuoc.MaDon
        //                            : item.TruyThuTienNuoc.MaDonTXL != null ? "TXL" + item.TruyThuTienNuoc.MaDonTXL
        //                            : item.TruyThuTienNuoc.MaDonTBC != null ? "TBC" + item.TruyThuTienNuoc.MaDonTBC : null,
        //                         TenLD = item.TruyThuTienNuoc.MaDonMoi != null ? ""
        //                            : item.TruyThuTienNuoc.MaDon != null ? item.TruyThuTienNuoc.DonKH.LoaiDon.TenLD
        //                            : item.TruyThuTienNuoc.MaDonTXL != null ? item.TruyThuTienNuoc.DonTXL.LoaiDonTXL.TenLD
        //                            : item.TruyThuTienNuoc.MaDonTBC != null ? item.TruyThuTienNuoc.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.TruyThuTienNuoc.MaDonMoi != null ? item.TruyThuTienNuoc.DonTu.CreateDate
        //                            : item.TruyThuTienNuoc.MaDon != null ? item.TruyThuTienNuoc.DonKH.CreateDate
        //                            : item.TruyThuTienNuoc.MaDonTXL != null ? item.TruyThuTienNuoc.DonTXL.CreateDate
        //                            : item.TruyThuTienNuoc.MaDonTBC != null ? item.TruyThuTienNuoc.DonTBC.CreateDate : null,
        //                         DanhBo = item.TruyThuTienNuoc.MaDonMoi != null ? item.TruyThuTienNuoc.DonTu.DanhBo
        //                            : item.TruyThuTienNuoc.MaDon != null ? item.TruyThuTienNuoc.DonKH.DanhBo
        //                            : item.TruyThuTienNuoc.MaDonTXL != null ? item.TruyThuTienNuoc.DonTXL.DanhBo
        //                            : item.TruyThuTienNuoc.MaDonTBC != null ? item.TruyThuTienNuoc.DonTBC.DanhBo : null,
        //                         HoTen = item.TruyThuTienNuoc.MaDonMoi != null ? item.TruyThuTienNuoc.DonTu.HoTen
        //                            : item.TruyThuTienNuoc.MaDon != null ? item.TruyThuTienNuoc.DonKH.HoTen
        //                            : item.TruyThuTienNuoc.MaDonTXL != null ? item.TruyThuTienNuoc.DonTXL.HoTen
        //                            : item.TruyThuTienNuoc.MaDonTBC != null ? item.TruyThuTienNuoc.DonTBC.HoTen : null,
        //                         DiaChi = item.TruyThuTienNuoc.MaDonMoi != null ? item.TruyThuTienNuoc.DonTu.DiaChi
        //                            : item.TruyThuTienNuoc.MaDon != null ? item.TruyThuTienNuoc.DonKH.DiaChi
        //                            : item.TruyThuTienNuoc.MaDonTXL != null ? item.TruyThuTienNuoc.DonTXL.DiaChi
        //                            : item.TruyThuTienNuoc.MaDonTBC != null ? item.TruyThuTienNuoc.DonTBC.DiaChi : null,
        //                         GiaBieu = item.TruyThuTienNuoc.MaDonMoi != null ? item.TruyThuTienNuoc.DonTu.GiaBieu
        //                            : item.TruyThuTienNuoc.MaDon != null ? item.TruyThuTienNuoc.DonKH.GiaBieu
        //                            : item.TruyThuTienNuoc.MaDonTXL != null ? item.TruyThuTienNuoc.DonTXL.GiaBieu
        //                            : item.TruyThuTienNuoc.MaDonTBC != null ? item.TruyThuTienNuoc.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.TruyThuTienNuoc.MaDonMoi != null ? item.TruyThuTienNuoc.DonTu.DinhMuc
        //                            : item.TruyThuTienNuoc.MaDon != null ? item.TruyThuTienNuoc.DonKH.DinhMuc
        //                            : item.TruyThuTienNuoc.MaDonTXL != null ? item.TruyThuTienNuoc.DonTXL.DinhMuc
        //                            : item.TruyThuTienNuoc.MaDonTBC != null ? item.TruyThuTienNuoc.DonTBC.DinhMuc : null,
        //                         NoiDung = item.TruyThuTienNuoc.MaDonMoi != null ? item.TruyThuTienNuoc.DonTu.Name_NhomDon
        //                            : item.TruyThuTienNuoc.MaDon != null ? item.TruyThuTienNuoc.DonKH.NoiDung
        //                            : item.TruyThuTienNuoc.MaDonTXL != null ? item.TruyThuTienNuoc.DonTXL.NoiDung
        //                            : item.TruyThuTienNuoc.MaDonTBC != null ? item.TruyThuTienNuoc.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///Table ToTrinh
        //        queryDonTu = from item in db.ToTrinh_ChiTiets
        //                     where item.DiaChi.Contains(DiaChi)
        //                     select new
        //                     {
        //                         MaDon = item.ToTrinh.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.ToTrinh.MaDonMoi).Count() == 1 ? item.ToTrinh.MaDonMoi.Value.ToString() : item.ToTrinh.MaDonMoi + "." + item.STT
        //                             : item.ToTrinh.MaDon != null ? "TKH" + item.ToTrinh.MaDon
        //                             : item.ToTrinh.MaDonTXL != null ? "TXL" + item.ToTrinh.MaDonTXL
        //                             : item.ToTrinh.MaDonTBC != null ? "TBC" + item.ToTrinh.MaDonTBC : null,
        //                         TenLD = item.ToTrinh.MaDonMoi != null ? ""
        //                            : item.ToTrinh.MaDon != null ? item.ToTrinh.DonKH.LoaiDon.TenLD
        //                            : item.ToTrinh.MaDonTXL != null ? item.ToTrinh.DonTXL.LoaiDonTXL.TenLD
        //                            : item.ToTrinh.MaDonTBC != null ? item.ToTrinh.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.ToTrinh.MaDonMoi != null ? item.ToTrinh.DonTu.CreateDate
        //                            : item.ToTrinh.MaDon != null ? item.ToTrinh.DonKH.CreateDate
        //                            : item.ToTrinh.MaDonTXL != null ? item.ToTrinh.DonTXL.CreateDate
        //                            : item.ToTrinh.MaDonTBC != null ? item.ToTrinh.DonTBC.CreateDate : null,
        //                         DanhBo = item.ToTrinh.MaDonMoi != null ? item.ToTrinh.DonTu.DanhBo
        //                            : item.ToTrinh.MaDon != null ? item.ToTrinh.DonKH.DanhBo
        //                            : item.ToTrinh.MaDonTXL != null ? item.ToTrinh.DonTXL.DanhBo
        //                            : item.ToTrinh.MaDonTBC != null ? item.ToTrinh.DonTBC.DanhBo : null,
        //                         HoTen = item.ToTrinh.MaDonMoi != null ? item.ToTrinh.DonTu.HoTen
        //                            : item.ToTrinh.MaDon != null ? item.ToTrinh.DonKH.HoTen
        //                            : item.ToTrinh.MaDonTXL != null ? item.ToTrinh.DonTXL.HoTen
        //                            : item.ToTrinh.MaDonTBC != null ? item.ToTrinh.DonTBC.HoTen : null,
        //                         DiaChi = item.ToTrinh.MaDonMoi != null ? item.ToTrinh.DonTu.DiaChi
        //                            : item.ToTrinh.MaDon != null ? item.ToTrinh.DonKH.DiaChi
        //                            : item.ToTrinh.MaDonTXL != null ? item.ToTrinh.DonTXL.DiaChi
        //                            : item.ToTrinh.MaDonTBC != null ? item.ToTrinh.DonTBC.DiaChi : null,
        //                         GiaBieu = item.ToTrinh.MaDonMoi != null ? item.ToTrinh.DonTu.GiaBieu
        //                            : item.ToTrinh.MaDon != null ? item.ToTrinh.DonKH.GiaBieu
        //                            : item.ToTrinh.MaDonTXL != null ? item.ToTrinh.DonTXL.GiaBieu
        //                            : item.ToTrinh.MaDonTBC != null ? item.ToTrinh.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.ToTrinh.MaDonMoi != null ? item.ToTrinh.DonTu.DinhMuc
        //                            : item.ToTrinh.MaDon != null ? item.ToTrinh.DonKH.DinhMuc
        //                            : item.ToTrinh.MaDonTXL != null ? item.ToTrinh.DonTXL.DinhMuc
        //                            : item.ToTrinh.MaDonTBC != null ? item.ToTrinh.DonTBC.DinhMuc : null,
        //                         NoiDung = item.ToTrinh.MaDonMoi != null ? item.ToTrinh.DonTu.Name_NhomDon
        //                            : item.ToTrinh.MaDon != null ? item.ToTrinh.DonKH.NoiDung
        //                            : item.ToTrinh.MaDonTXL != null ? item.ToTrinh.DonTXL.NoiDung
        //                            : item.ToTrinh.MaDonTBC != null ? item.ToTrinh.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        ///Table ThuMoi
        //        queryDonTu = from item in db.ThuMoi_ChiTiets
        //                     where item.DiaChi.Contains(DiaChi)
        //                     select new
        //                     {
        //                         MaDon = item.ThuMoi.MaDonMoi != null ? db.DonTu_ChiTiets.Where(itemA => itemA.MaDon == item.ThuMoi.MaDonMoi).Count() == 1 ? item.ThuMoi.MaDonMoi.Value.ToString() : item.ThuMoi.MaDonMoi + "." + item.STT
        //                            : item.ThuMoi.MaDonTKH != null ? "TKH" + item.ThuMoi.MaDonTKH
        //                            : item.ThuMoi.MaDonTXL != null ? "TXL" + item.ThuMoi.MaDonTXL
        //                            : item.ThuMoi.MaDonTBC != null ? "TBC" + item.ThuMoi.MaDonTBC : null,
        //                         TenLD = item.ThuMoi.MaDonMoi != null ? ""
        //                            : item.ThuMoi.MaDonTKH != null ? item.ThuMoi.DonKH.LoaiDon.TenLD
        //                            : item.ThuMoi.MaDonTXL != null ? item.ThuMoi.DonTXL.LoaiDonTXL.TenLD
        //                            : item.ThuMoi.MaDonTBC != null ? item.ThuMoi.DonTBC.LoaiDonTBC.TenLD : null,
        //                         CreateDate = item.ThuMoi.MaDonMoi != null ? item.ThuMoi.DonTu.CreateDate
        //                            : item.ThuMoi.MaDonTKH != null ? item.ThuMoi.DonKH.CreateDate
        //                            : item.ThuMoi.MaDonTXL != null ? item.ThuMoi.DonTXL.CreateDate
        //                            : item.ThuMoi.MaDonTBC != null ? item.ThuMoi.DonTBC.CreateDate : null,
        //                         DanhBo = item.ThuMoi.MaDonMoi != null ? item.ThuMoi.DonTu.DanhBo
        //                            : item.ThuMoi.MaDonTKH != null ? item.ThuMoi.DonKH.DanhBo
        //                            : item.ThuMoi.MaDonTXL != null ? item.ThuMoi.DonTXL.DanhBo
        //                            : item.ThuMoi.MaDonTBC != null ? item.ThuMoi.DonTBC.DanhBo : null,
        //                         HoTen = item.ThuMoi.MaDonMoi != null ? item.ThuMoi.DonTu.HoTen
        //                            : item.ThuMoi.MaDonTKH != null ? item.ThuMoi.DonKH.HoTen
        //                            : item.ThuMoi.MaDonTXL != null ? item.ThuMoi.DonTXL.HoTen
        //                            : item.ThuMoi.MaDonTBC != null ? item.ThuMoi.DonTBC.HoTen : null,
        //                         DiaChi = item.ThuMoi.MaDonMoi != null ? item.ThuMoi.DonTu.DiaChi
        //                            : item.ThuMoi.MaDonTKH != null ? item.ThuMoi.DonKH.DiaChi
        //                            : item.ThuMoi.MaDonTXL != null ? item.ThuMoi.DonTXL.DiaChi
        //                            : item.ThuMoi.MaDonTBC != null ? item.ThuMoi.DonTBC.DiaChi : null,
        //                         GiaBieu = item.ThuMoi.MaDonMoi != null ? item.ThuMoi.DonTu.GiaBieu
        //                            : item.ThuMoi.MaDonTKH != null ? item.ThuMoi.DonKH.GiaBieu
        //                            : item.ThuMoi.MaDonTXL != null ? item.ThuMoi.DonTXL.GiaBieu
        //                            : item.ThuMoi.MaDonTBC != null ? item.ThuMoi.DonTBC.GiaBieu : null,
        //                         DinhMuc = item.ThuMoi.MaDonMoi != null ? item.ThuMoi.DonTu.DinhMuc
        //                            : item.ThuMoi.MaDonTKH != null ? item.ThuMoi.DonKH.DinhMuc
        //                            : item.ThuMoi.MaDonTXL != null ? item.ThuMoi.DonTXL.DinhMuc
        //                            : item.ThuMoi.MaDonTBC != null ? item.ThuMoi.DonTBC.DinhMuc : null,
        //                         NoiDung = item.ThuMoi.MaDonMoi != null ? item.ThuMoi.DonTu.Name_NhomDon
        //                            : item.ThuMoi.MaDonTKH != null ? item.ThuMoi.DonKH.NoiDung
        //                            : item.ThuMoi.MaDonTXL != null ? item.ThuMoi.DonTXL.NoiDung
        //                            : item.ThuMoi.MaDonTBC != null ? item.ThuMoi.DonTBC.NoiDung : null,
        //                     };
        //        dt.Merge(LINQToDataTable(queryDonTu));

        //        #endregion

        //        DataTable dtDon = new DataTable();
        //        dtDon.Columns.Add("MaDon", typeof(string));
        //        dtDon.Columns.Add("TenLD", typeof(string));
        //        dtDon.Columns.Add("CreateDate", typeof(string));
        //        dtDon.Columns.Add("DanhBo", typeof(string));
        //        dtDon.Columns.Add("HoTen", typeof(string));
        //        dtDon.Columns.Add("DiaChi", typeof(string));
        //        dtDon.Columns.Add("GiaBieu", typeof(string));
        //        dtDon.Columns.Add("DinhMuc", typeof(string));
        //        dtDon.Columns.Add("NoiDung", typeof(string));
        //        dtDon.TableName = "DonTu";

        //        foreach (DataRow itemRow in dt.Rows)
        //        {
        //            if (dtDon.Select("MaDon = '" + itemRow["MaDon"] + "'").Count() <= 0)
        //                dtDon.ImportRow(itemRow);
        //        }

        //        dtDon.DefaultView.Sort = "CreateDate ASC";
        //        ds.Tables.Add(dtDon.DefaultView.ToTable());

        //        if (dtDon.Rows.Count > 0 && dtKTXM.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Kiểm Tra Xác Minh", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["KTXM"].Columns["MaDon"]);

        //        if (dtDon.Rows.Count > 0 && dtBamChi.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Bấm Chì", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["BamChi"].Columns["MaDon"]);

        //        if (dtDon.Rows.Count > 0 && dtDongNuoc.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Đóng Nước", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["DongNuoc"].Columns["MaDon"]);

        //        if (dtDon.Rows.Count > 0 && dtDCBD.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Điều Chỉnh Biến Động", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["DCBD"].Columns["MaDon"]);

        //        if (dtDon.Rows.Count > 0 && dtCHDB.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Cắt Tạm/Hủy Danh Bộ", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["CHDB"].Columns["MaDon"]);

        //        if (dtDon.Rows.Count > 0 && dtPhieuCHDB.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Phiếu Hủy Danh Bộ", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["PhieuCHDB"].Columns["MaDon"]);

        //        if (dtDon.Rows.Count > 0 && dtTTTL.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["ThuTraLoi"].Columns["MaDon"]);

        //        if (dtDon.Rows.Count > 0 && dtGianLan.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Gian Lận", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["GianLan"].Columns["MaDon"]);

        //        if (dtDon.Rows.Count > 0 && dtTruyThu.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Truy Thu", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["TruyThu"].Columns["MaDon"]);

        //        if (dtDon.Rows.Count > 0 && dtToTrinh.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Tờ Trình", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["ToTrinh"].Columns["MaDon"]);

        //        if (dtDon.Rows.Count > 0 && dtThuMoi.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Thư Mời", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["ThuMoi"].Columns["MaDon"]);

        //        if (dtDon.Rows.Count > 0 && dtTienTrinh.Rows.Count > 0)
        //            ds.Relations.Add("Chi Tiết Tiến Trình", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables["TienTrinh"].Columns["MaDon"]);

        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return null;
        //    }
        //}

        #endregion

        public DataSet getTienTrinhByDanhBo(string DanhBo)
        {
            DataSet ds = ExecuteQuery_DataSet("exec spTimKiemByBanhBo_DonTuChiTiet '" + DanhBo + "'");

            DataTable dt = ExecuteQuery_DataTable("exec spTimKiemByBanhBo_DonTu '" + DanhBo + "'");
            DataTable dtDon = new DataTable();
            dtDon.Columns.Add("Phong", typeof(string));
            dtDon.Columns.Add("MaDon", typeof(string));
            dtDon.Columns.Add("TenLD", typeof(string));
            dtDon.Columns.Add("CreateDate", typeof(DateTime));
            dtDon.Columns.Add("DanhBo", typeof(string));
            dtDon.Columns.Add("HoTen", typeof(string));
            dtDon.Columns.Add("DiaChi", typeof(string));
            dtDon.Columns.Add("GiaBieu", typeof(string));
            dtDon.Columns.Add("DinhMuc", typeof(string));
            dtDon.Columns.Add("DinhMucHN", typeof(string));
            dtDon.Columns.Add("NoiDungPKH", typeof(string));
            dtDon.Columns.Add("NoiDung", typeof(string));
            dtDon.Columns.Add("DienThoai", typeof(string));
            dtDon.Columns.Add("TinhTrang", typeof(string));
            dtDon.TableName = "DonTu";

            foreach (DataRow itemRow in dt.Rows)
            {
                if (dtDon.Select("MaDon = '" + itemRow["MaDon"] + "'").Count() <= 0)
                    dtDon.ImportRow(itemRow);
            }

            dtDon.DefaultView.Sort = "CreateDate ASC";
            ds.Tables.Add(dtDon.DefaultView.ToTable());

            for (int i = 0; i < ds.Tables.Count; i++)
                if (ds.Tables[i].Rows.Count > 0)
                {
                    switch (ds.Tables[i].Rows[0][0].ToString())
                    {
                        case "KTXM":
                            ds.Relations.Add("Chi Tiết Kiểm Tra Xác Minh", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "BamChi":
                            ds.Relations.Add("Chi Tiết Bấm Chì", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "DongNuoc":
                            ds.Relations.Add("Chi Tiết Đóng Nước", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "DCBD":
                            ds.Relations.Add("Chi Tiết Điều Chỉnh Biến Động", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "CHDB":
                            ds.Relations.Add("Chi Tiết Cắt Tạm/Hủy Danh Bộ", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "PhieuCHDB":
                            ds.Relations.Add("Chi Tiết Phiếu Hủy Danh Bộ", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "ThuTraLoi":
                            ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "GianLan":
                            ds.Relations.Add("Chi Tiết Gian Lận", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "TruyThu":
                            ds.Relations.Add("Chi Tiết Truy Thu", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "ToTrinh":
                            ds.Relations.Add("Chi Tiết Tờ Trình", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "ThuMoi":
                            ds.Relations.Add("Chi Tiết Thư Mời", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "VanBan":
                            ds.Relations.Add("Chi Tiết Văn Bản", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "TienTrinh":
                            ds.Relations.Add("Chi Tiết Tiến Trình", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                    }
                }

            return ds;
        }

        public DataSet getTienTrinhByHoTen(string HoTen)
        {
            DataSet ds = ExecuteQuery_DataSet("exec spTimKiemByHoTen_DonTuChiTiet '" + HoTen + "'");

            DataTable dt = ExecuteQuery_DataTable("exec spTimKiemByHoTen_DonTu '" + HoTen + "'");
            DataTable dtDon = new DataTable();
            dtDon.Columns.Add("Phong", typeof(string));
            dtDon.Columns.Add("MaDon", typeof(string));
            dtDon.Columns.Add("TenLD", typeof(string));
            dtDon.Columns.Add("CreateDate", typeof(DateTime));
            dtDon.Columns.Add("DanhBo", typeof(string));
            dtDon.Columns.Add("HoTen", typeof(string));
            dtDon.Columns.Add("DiaChi", typeof(string));
            dtDon.Columns.Add("GiaBieu", typeof(string));
            dtDon.Columns.Add("DinhMuc", typeof(string));
            dtDon.Columns.Add("DinhMucHN", typeof(string));
            dtDon.Columns.Add("NoiDungPKH", typeof(string));
            dtDon.Columns.Add("NoiDung", typeof(string));
            dtDon.Columns.Add("DienThoai", typeof(string));
            dtDon.Columns.Add("TinhTrang", typeof(string));
            dtDon.TableName = "DonTu";

            foreach (DataRow itemRow in dt.Rows)
            {
                if (dtDon.Select("MaDon = '" + itemRow["MaDon"] + "'").Count() <= 0)
                    dtDon.ImportRow(itemRow);
            }

            dtDon.DefaultView.Sort = "CreateDate ASC";
            ds.Tables.Add(dtDon.DefaultView.ToTable());

            for (int i = 0; i < ds.Tables.Count; i++)
                if (ds.Tables[i].Rows.Count > 0)
                {
                    switch (ds.Tables[i].Rows[0][0].ToString())
                    {
                        case "KTXM":
                            ds.Relations.Add("Chi Tiết Kiểm Tra Xác Minh", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "BamChi":
                            ds.Relations.Add("Chi Tiết Bấm Chì", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "DongNuoc":
                            ds.Relations.Add("Chi Tiết Đóng Nước", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "DCBD":
                            ds.Relations.Add("Chi Tiết Điều Chỉnh Biến Động", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "CHDB":
                            ds.Relations.Add("Chi Tiết Cắt Tạm/Hủy Danh Bộ", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "PhieuCHDB":
                            ds.Relations.Add("Chi Tiết Phiếu Hủy Danh Bộ", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "ThuTraLoi":
                            ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "GianLan":
                            ds.Relations.Add("Chi Tiết Gian Lận", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "TruyThu":
                            ds.Relations.Add("Chi Tiết Truy Thu", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "ToTrinh":
                            ds.Relations.Add("Chi Tiết Tờ Trình", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "ThuMoi":
                            ds.Relations.Add("Chi Tiết Thư Mời", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "VanBan":
                            ds.Relations.Add("Chi Tiết Văn Bản", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "TienTrinh":
                            ds.Relations.Add("Chi Tiết Tiến Trình", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                    }
                }

            return ds;
        }

        public DataSet getTienTrinhByDiaChi(string DiaChi)
        {
            DataSet ds = ExecuteQuery_DataSet("exec spTimKiemByDiaChi_DonTuChiTiet '" + DiaChi + "'");

            DataTable dt = ExecuteQuery_DataTable("exec spTimKiemByDiaChi_DonTu '" + DiaChi + "'");
            DataTable dtDon = new DataTable();
            dtDon.Columns.Add("Phong", typeof(string));
            dtDon.Columns.Add("MaDon", typeof(string));
            dtDon.Columns.Add("TenLD", typeof(string));
            dtDon.Columns.Add("CreateDate", typeof(DateTime));
            dtDon.Columns.Add("DanhBo", typeof(string));
            dtDon.Columns.Add("HoTen", typeof(string));
            dtDon.Columns.Add("DiaChi", typeof(string));
            dtDon.Columns.Add("GiaBieu", typeof(string));
            dtDon.Columns.Add("DinhMuc", typeof(string));
            dtDon.Columns.Add("DinhMucHN", typeof(string));
            dtDon.Columns.Add("NoiDungPKH", typeof(string));
            dtDon.Columns.Add("NoiDung", typeof(string));
            dtDon.Columns.Add("DienThoai", typeof(string));
            dtDon.Columns.Add("TinhTrang", typeof(string));
            dtDon.TableName = "DonTu";

            foreach (DataRow itemRow in dt.Rows)
            {
                if (dtDon.Select("MaDon = '" + itemRow["MaDon"] + "'").Count() <= 0)
                    dtDon.ImportRow(itemRow);
            }

            dtDon.DefaultView.Sort = "CreateDate ASC";
            ds.Tables.Add(dtDon.DefaultView.ToTable());

            for (int i = 0; i < ds.Tables.Count; i++)
                if (ds.Tables[i].Rows.Count > 0)
                {
                    switch (ds.Tables[i].Rows[0][0].ToString())
                    {
                        case "KTXM":
                            ds.Relations.Add("Chi Tiết Kiểm Tra Xác Minh", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "BamChi":
                            ds.Relations.Add("Chi Tiết Bấm Chì", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "DongNuoc":
                            ds.Relations.Add("Chi Tiết Đóng Nước", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "DCBD":
                            ds.Relations.Add("Chi Tiết Điều Chỉnh Biến Động", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "CHDB":
                            ds.Relations.Add("Chi Tiết Cắt Tạm/Hủy Danh Bộ", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "PhieuCHDB":
                            ds.Relations.Add("Chi Tiết Phiếu Hủy Danh Bộ", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "ThuTraLoi":
                            ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "GianLan":
                            ds.Relations.Add("Chi Tiết Gian Lận", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "TruyThu":
                            ds.Relations.Add("Chi Tiết Truy Thu", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "ToTrinh":
                            ds.Relations.Add("Chi Tiết Tờ Trình", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "ThuMoi":
                            ds.Relations.Add("Chi Tiết Thư Mời", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "VanBan":
                            ds.Relations.Add("Chi Tiết Văn Bản", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "TienTrinh":
                            ds.Relations.Add("Chi Tiết Tiến Trình", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                    }
                }

            return ds;
        }

        public DataSet getTienTrinhByNiemChi(int NiemChi)
        {
            CBamChi cBamChi = new CBamChi();
            DataTable dtBamChi = cBamChi.getDS(NiemChi);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            foreach (DataRow item in dtBamChi.Rows)
            {
                dt.Merge(ExecuteQuery_DataTable("exec spTimKiemByBanhBo_DonTu '" + item["DanhBo"] + "'"));
                ds.Merge(ExecuteQuery_DataSet("exec spTimKiemByBanhBo_DonTuChiTiet '" + item["DanhBo"] + "'"));
            }

            DataTable dtDon = new DataTable();
            dtDon.Columns.Add("Phong", typeof(string));
            dtDon.Columns.Add("MaDon", typeof(string));
            dtDon.Columns.Add("TenLD", typeof(string));
            dtDon.Columns.Add("CreateDate", typeof(DateTime));
            dtDon.Columns.Add("DanhBo", typeof(string));
            dtDon.Columns.Add("HoTen", typeof(string));
            dtDon.Columns.Add("DiaChi", typeof(string));
            dtDon.Columns.Add("GiaBieu", typeof(string));
            dtDon.Columns.Add("DinhMuc", typeof(string));
            dtDon.Columns.Add("DinhMucHN", typeof(string));
            dtDon.Columns.Add("NoiDungPKH", typeof(string));
            dtDon.Columns.Add("NoiDung", typeof(string));
            dtDon.Columns.Add("DienThoai", typeof(string));
            dtDon.Columns.Add("TinhTrang", typeof(string));
            dtDon.TableName = "DonTu";

            foreach (DataRow itemRow in dt.Rows)
            {
                if (dtDon.Select("MaDon = '" + itemRow["MaDon"] + "'").Count() <= 0)
                    dtDon.ImportRow(itemRow);
            }

            dtDon.DefaultView.Sort = "CreateDate ASC";
            ds.Tables.Add(dtDon.DefaultView.ToTable());

            for (int i = 0; i < ds.Tables.Count; i++)
                if (ds.Tables[i].Rows.Count > 0)
                {
                    switch (ds.Tables[i].Rows[0][0].ToString())
                    {
                        case "KTXM":
                            ds.Relations.Add("Chi Tiết Kiểm Tra Xác Minh", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "BamChi":
                            ds.Relations.Add("Chi Tiết Bấm Chì", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "DongNuoc":
                            ds.Relations.Add("Chi Tiết Đóng Nước", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "DCBD":
                            ds.Relations.Add("Chi Tiết Điều Chỉnh Biến Động", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "CHDB":
                            ds.Relations.Add("Chi Tiết Cắt Tạm/Hủy Danh Bộ", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "PhieuCHDB":
                            ds.Relations.Add("Chi Tiết Phiếu Hủy Danh Bộ", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "ThuTraLoi":
                            ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "GianLan":
                            ds.Relations.Add("Chi Tiết Gian Lận", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "TruyThu":
                            ds.Relations.Add("Chi Tiết Truy Thu", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "ToTrinh":
                            ds.Relations.Add("Chi Tiết Tờ Trình", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "ThuMoi":
                            ds.Relations.Add("Chi Tiết Thư Mời", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "VanBan":
                            ds.Relations.Add("Chi Tiết Văn Bản", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "TienTrinh":
                            ds.Relations.Add("Chi Tiết Tiến Trình", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                    }
                }

            return ds;
        }

        public DataSet getTienTrinhBySoChungTu(string SoChungTu)
        {
            CChungTu _cChungTu = new CChungTu();
            DataTable dtChungTu = _cChungTu.getDS_ChiTiet(SoChungTu);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            foreach (DataRow item in dtChungTu.Rows)
            {
                dt.Merge(ExecuteQuery_DataTable("exec spTimKiemByBanhBo_DonTu '" + item["DanhBo"] + "'"));
                ds.Merge(ExecuteQuery_DataSet("exec spTimKiemByBanhBo_DonTuChiTiet '" + item["DanhBo"] + "'"));
            }

            DataTable dtDon = new DataTable();
            dtDon.Columns.Add("Phong", typeof(string));
            dtDon.Columns.Add("MaDon", typeof(string));
            dtDon.Columns.Add("TenLD", typeof(string));
            dtDon.Columns.Add("CreateDate", typeof(DateTime));
            dtDon.Columns.Add("DanhBo", typeof(string));
            dtDon.Columns.Add("HoTen", typeof(string));
            dtDon.Columns.Add("DiaChi", typeof(string));
            dtDon.Columns.Add("GiaBieu", typeof(string));
            dtDon.Columns.Add("DinhMuc", typeof(string));
            dtDon.Columns.Add("DinhMucHN", typeof(string));
            dtDon.Columns.Add("NoiDungPKH", typeof(string));
            dtDon.Columns.Add("NoiDung", typeof(string));
            dtDon.Columns.Add("DienThoai", typeof(string));
            dtDon.Columns.Add("TinhTrang", typeof(string));
            dtDon.TableName = "DonTu";

            foreach (DataRow itemRow in dt.Rows)
            {
                if (dtDon.Select("MaDon = '" + itemRow["MaDon"] + "'").Count() <= 0)
                    dtDon.ImportRow(itemRow);
            }

            dtDon.DefaultView.Sort = "CreateDate ASC";
            ds.Tables.Add(dtDon.DefaultView.ToTable());

            for (int i = 0; i < ds.Tables.Count; i++)
                if (ds.Tables[i].Rows.Count > 0)
                {
                    switch (ds.Tables[i].Rows[0][0].ToString())
                    {
                        case "KTXM":
                            ds.Relations.Add("Chi Tiết Kiểm Tra Xác Minh", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "BamChi":
                            ds.Relations.Add("Chi Tiết Bấm Chì", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "DongNuoc":
                            ds.Relations.Add("Chi Tiết Đóng Nước", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "DCBD":
                            ds.Relations.Add("Chi Tiết Điều Chỉnh Biến Động", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "CHDB":
                            ds.Relations.Add("Chi Tiết Cắt Tạm/Hủy Danh Bộ", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "PhieuCHDB":
                            ds.Relations.Add("Chi Tiết Phiếu Hủy Danh Bộ", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "ThuTraLoi":
                            ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "GianLan":
                            ds.Relations.Add("Chi Tiết Gian Lận", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "TruyThu":
                            ds.Relations.Add("Chi Tiết Truy Thu", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "ToTrinh":
                            ds.Relations.Add("Chi Tiết Tờ Trình", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "ThuMoi":
                            ds.Relations.Add("Chi Tiết Thư Mời", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "VanBan":
                            ds.Relations.Add("Chi Tiết Văn Bản", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                        case "TienTrinh":
                            ds.Relations.Add("Chi Tiết Tiến Trình", ds.Tables["DonTu"].Columns["MaDon"], ds.Tables[i].Columns["MaDon"]);
                            break;
                    }
                }

            return ds;
        }
    }
}
