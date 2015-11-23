using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KTKS_DonKH.DAL.HeThong;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.DAL.CatHuyDanhBo
{
    class CCHDB : CDAL
    {
        ///Chứa hàm truy xuất dữ liệu từ bảng CHDB & CTCTDB & CTCHDB & YeuCauCHDB

        #region CHDB (Cắt Hủy Danh Bộ)

        public DataSet LoadDSCHDBDaDuyet()
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    DataSet ds = new DataSet();
                    ///Table CHDB
                    var queryCHDB_DonKH = from itemCHDB in db.CHDBs
                                    //join itemDonKH in db.DonKHs on itemCHDB.MaDon equals itemDonKH.MaDon
                                    //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                    where itemCHDB.ToXuLy==false
                                    select new
                                    {
                                        itemCHDB.ToXuLy,
                                        itemCHDB.MaDon,
                                        itemCHDB.DonKH.LoaiDon.TenLD,
                                        itemCHDB.DonKH.CreateDate,
                                        itemCHDB.DonKH.DanhBo,
                                        itemCHDB.DonKH.HoTen,
                                        itemCHDB.DonKH.DiaChi,
                                        itemCHDB.DonKH.NoiDung,
                                        MaNoiChuyenDen = itemCHDB.MaNoiChuyenDen,
                                        NoiChuyenDen = itemCHDB.NoiChuyenDen,
                                        LyDoChuyenDen = itemCHDB.LyDoChuyenDen,
                                        itemCHDB.MaCHDB,
                                        NgayXuLy = itemCHDB.CreateDate,
                                        itemCHDB.KetQua,
                                        itemCHDB.MaChuyen,
                                        LyDoChuyenDi = itemCHDB.LyDoChuyen
                                    };

                    var queryCHDB_DonTXL = from itemCHDB in db.CHDBs
                                          //join itemDonKH in db.DonKHs on itemCHDB.MaDon equals itemDonKH.MaDon
                                          //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                          where itemCHDB.ToXuLy == true
                                          select new
                                          {
                                              itemCHDB.ToXuLy,
                                              MaDon=itemCHDB.MaDonTXL,
                                              itemCHDB.DonTXL.LoaiDonTXL.TenLD,
                                              itemCHDB.DonTXL.CreateDate,
                                              itemCHDB.DonTXL.DanhBo,
                                              itemCHDB.DonTXL.HoTen,
                                              itemCHDB.DonTXL.DiaChi,
                                              itemCHDB.DonTXL.NoiDung,
                                              MaNoiChuyenDen = itemCHDB.MaNoiChuyenDen,
                                              NoiChuyenDen = itemCHDB.NoiChuyenDen,
                                              LyDoChuyenDen = itemCHDB.LyDoChuyenDen,
                                              itemCHDB.MaCHDB,
                                              NgayXuLy = itemCHDB.CreateDate,
                                              itemCHDB.KetQua,
                                              itemCHDB.MaChuyen,
                                              LyDoChuyenDi = itemCHDB.LyDoChuyen
                                          };
                    DataTable dtCHDB = new DataTable();
                    dtCHDB = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCHDB_DonKH);
                    dtCHDB.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCHDB_DonTXL));
                    dtCHDB.TableName = "CHDB";
                    ds.Tables.Add(dtCHDB);

                    ///Table CTCTDB
                    var queryCTCTDB = from itemCTCTDB in db.CTCTDBs
                                      //where itemCTCTDB.CHDB.MaDon!=null
                                      select itemCTCTDB;

                    DataTable dtCTCTDB = new DataTable();
                    dtCTCTDB = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTCTDB);
                    dtCTCTDB.TableName = "CTCTDB";
                    ds.Tables.Add(dtCTCTDB);

                    ///Table CTCHDB
                    var queryCTCHDB = from itemCTCHDB in db.CTCHDBs
                                      //where itemCTCHDB.CHDB.MaDon != null
                                      select itemCTCHDB;

                    DataTable dtCTCHDB = new DataTable();
                    dtCTCHDB = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTCHDB);
                    dtCTCHDB.TableName = "CTCHDB";
                    ds.Tables.Add(dtCTCHDB);

                    if (dtCHDB.Rows.Count > 0 && dtCTCTDB.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Cắt Tạm Danh Bộ", ds.Tables["CHDB"].Columns["MaCHDB"], ds.Tables["CTCTDB"].Columns["MaCHDB"]);
                    if (dtCHDB.Rows.Count > 0 && dtCTCHDB.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Cắt Hủy Danh Bộ", ds.Tables["CHDB"].Columns["MaCHDB"], ds.Tables["CTCHDB"].Columns["MaCHDB"]);
                    return ds;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataSet LoadDSCHDBDaDuyetByMaDon(decimal MaDon)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    DataSet ds = new DataSet();
                    ///Table CHDB
                    var queryCHDB_DonKH = from itemCHDB in db.CHDBs
                                          //join itemDonKH in db.DonKHs on itemCHDB.MaDon equals itemDonKH.MaDon
                                          //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                          where itemCHDB.ToXuLy == false && itemCHDB.MaDon==MaDon
                                          select new
                                          {
                                              itemCHDB.ToXuLy,
                                              itemCHDB.MaDon,
                                              itemCHDB.DonKH.LoaiDon.TenLD,
                                              itemCHDB.DonKH.CreateDate,
                                              itemCHDB.DonKH.DanhBo,
                                              itemCHDB.DonKH.HoTen,
                                              itemCHDB.DonKH.DiaChi,
                                              itemCHDB.DonKH.NoiDung,
                                              MaNoiChuyenDen = itemCHDB.MaNoiChuyenDen,
                                              NoiChuyenDen = itemCHDB.NoiChuyenDen,
                                              LyDoChuyenDen = itemCHDB.LyDoChuyenDen,
                                              itemCHDB.MaCHDB,
                                              NgayXuLy = itemCHDB.CreateDate,
                                              itemCHDB.KetQua,
                                              itemCHDB.MaChuyen,
                                              LyDoChuyenDi = itemCHDB.LyDoChuyen
                                          };

                    var queryCHDB_DonTXL = from itemCHDB in db.CHDBs
                                           //join itemDonKH in db.DonKHs on itemCHDB.MaDon equals itemDonKH.MaDon
                                           //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                           where itemCHDB.ToXuLy == true && itemCHDB.MaDonTXL==MaDon
                                           select new
                                           {
                                               itemCHDB.ToXuLy,
                                               MaDon = itemCHDB.MaDonTXL,
                                               itemCHDB.DonTXL.LoaiDonTXL.TenLD,
                                               itemCHDB.DonTXL.CreateDate,
                                               itemCHDB.DonTXL.DanhBo,
                                               itemCHDB.DonTXL.HoTen,
                                               itemCHDB.DonTXL.DiaChi,
                                               itemCHDB.DonTXL.NoiDung,
                                               MaNoiChuyenDen = itemCHDB.MaNoiChuyenDen,
                                               NoiChuyenDen = itemCHDB.NoiChuyenDen,
                                               LyDoChuyenDen = itemCHDB.LyDoChuyenDen,
                                               itemCHDB.MaCHDB,
                                               NgayXuLy = itemCHDB.CreateDate,
                                               itemCHDB.KetQua,
                                               itemCHDB.MaChuyen,
                                               LyDoChuyenDi = itemCHDB.LyDoChuyen
                                           };
                    DataTable dtCHDB = new DataTable();
                    dtCHDB = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCHDB_DonKH.Distinct());
                    dtCHDB.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCHDB_DonTXL.Distinct()));
                    dtCHDB.TableName = "CHDB";
                    ds.Tables.Add(dtCHDB);

                    ///Table CTCTDB
                    var queryCTCTDB = from itemCTCTDB in db.CTCTDBs
                                      where itemCTCTDB.CHDB.MaDon==MaDon || itemCTCTDB.CHDB.MaDonTXL==MaDon
                                      select itemCTCTDB;

                    DataTable dtCTCTDB = new DataTable();
                    dtCTCTDB = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTCTDB);
                    dtCTCTDB.TableName = "CTCTDB";
                    ds.Tables.Add(dtCTCTDB);

                    ///Table CTCHDB
                    var queryCTCHDB = from itemCTCHDB in db.CTCHDBs
                                      where itemCTCHDB.CHDB.MaDon == MaDon || itemCTCHDB.CHDB.MaDonTXL == MaDon
                                      select itemCTCHDB;

                    DataTable dtCTCHDB = new DataTable();
                    dtCTCHDB = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTCHDB);
                    dtCTCHDB.TableName = "CTCHDB";
                    ds.Tables.Add(dtCTCHDB);

                    if (dtCHDB.Rows.Count > 0 && dtCTCTDB.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Cắt Tạm Danh Bộ", ds.Tables["CHDB"].Columns["MaCHDB"], ds.Tables["CTCTDB"].Columns["MaCHDB"]);
                    if (dtCHDB.Rows.Count > 0 && dtCTCHDB.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Cắt Hủy Danh Bộ", ds.Tables["CHDB"].Columns["MaCHDB"], ds.Tables["CTCHDB"].Columns["MaCHDB"]);
                    return ds;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataSet LoadDSCHDBDaDuyetByMaTB(decimal MaTB)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    DataSet ds = new DataSet();
                    ///Table CHDB
                    var queryCHDB_DonKH = from itemCHDB in db.CHDBs
                                          //join itemDonKH in db.DonKHs on itemCHDB.MaDon equals itemDonKH.MaDon
                                          //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                          join itemCTCTDB in db.CTCTDBs on itemCHDB.MaCHDB equals itemCTCTDB.MaCHDB
                                          join itemCTCHDB in db.CTCHDBs on itemCTCTDB.MaCHDB equals itemCTCHDB.MaCHDB
                                          where itemCHDB.ToXuLy == false && (itemCTCTDB.MaCTCTDB == MaTB || itemCTCHDB.MaCTCHDB == MaTB)
                                          select new
                                          {
                                              itemCHDB.ToXuLy,
                                              itemCHDB.MaDon,
                                              itemCHDB.DonKH.LoaiDon.TenLD,
                                              itemCHDB.DonKH.CreateDate,
                                              itemCHDB.DonKH.DanhBo,
                                              itemCHDB.DonKH.HoTen,
                                              itemCHDB.DonKH.DiaChi,
                                              itemCHDB.DonKH.NoiDung,
                                              MaNoiChuyenDen = itemCHDB.MaNoiChuyenDen,
                                              NoiChuyenDen = itemCHDB.NoiChuyenDen,
                                              LyDoChuyenDen = itemCHDB.LyDoChuyenDen,
                                              itemCHDB.MaCHDB,
                                              NgayXuLy = itemCHDB.CreateDate,
                                              itemCHDB.KetQua,
                                              itemCHDB.MaChuyen,
                                              LyDoChuyenDi = itemCHDB.LyDoChuyen
                                          };

                    var queryCHDB_DonTXL = from itemCHDB in db.CHDBs
                                           //join itemDonKH in db.DonKHs on itemCHDB.MaDon equals itemDonKH.MaDon
                                           //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                           join itemCTCTDB in db.CTCTDBs on itemCHDB.MaCHDB equals itemCTCTDB.MaCHDB
                                           join itemCTCHDB in db.CTCHDBs on itemCTCTDB.MaCHDB equals itemCTCHDB.MaCHDB
                                           where itemCHDB.ToXuLy == true && (itemCTCTDB.MaCTCTDB == MaTB || itemCTCHDB.MaCTCHDB == MaTB)
                                           select new
                                           {
                                               itemCHDB.ToXuLy,
                                               MaDon = itemCHDB.MaDonTXL,
                                               itemCHDB.DonTXL.LoaiDonTXL.TenLD,
                                               itemCHDB.DonTXL.CreateDate,
                                               itemCHDB.DonTXL.DanhBo,
                                               itemCHDB.DonTXL.HoTen,
                                               itemCHDB.DonTXL.DiaChi,
                                               itemCHDB.DonTXL.NoiDung,
                                               MaNoiChuyenDen = itemCHDB.MaNoiChuyenDen,
                                               NoiChuyenDen = itemCHDB.NoiChuyenDen,
                                               LyDoChuyenDen = itemCHDB.LyDoChuyenDen,
                                               itemCHDB.MaCHDB,
                                               NgayXuLy = itemCHDB.CreateDate,
                                               itemCHDB.KetQua,
                                               itemCHDB.MaChuyen,
                                               LyDoChuyenDi = itemCHDB.LyDoChuyen
                                           };
                    DataTable dtCHDB = new DataTable();
                    dtCHDB = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCHDB_DonKH.Distinct());
                    dtCHDB.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCHDB_DonTXL.Distinct()));
                    dtCHDB.TableName = "CHDB";
                    ds.Tables.Add(dtCHDB);

                    ///Table CTCTDB
                    var queryCTCTDB = from itemCTCTDB in db.CTCTDBs
                                      where itemCTCTDB.MaCTCTDB == MaTB
                                      select itemCTCTDB;

                    DataTable dtCTCTDB = new DataTable();
                    dtCTCTDB = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTCTDB);
                    dtCTCTDB.TableName = "CTCTDB";
                    ds.Tables.Add(dtCTCTDB);

                    ///Table CTCHDB
                    var queryCTCHDB = from itemCTCHDB in db.CTCHDBs
                                      where itemCTCHDB.MaCTCHDB == MaTB
                                      select itemCTCHDB;

                    DataTable dtCTCHDB = new DataTable();
                    dtCTCHDB = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTCHDB);
                    dtCTCHDB.TableName = "CTCHDB";
                    ds.Tables.Add(dtCTCHDB);

                    if (dtCHDB.Rows.Count > 0 && dtCTCTDB.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Cắt Tạm Danh Bộ", ds.Tables["CHDB"].Columns["MaCHDB"], ds.Tables["CTCTDB"].Columns["MaCHDB"]);
                    if (dtCHDB.Rows.Count > 0 && dtCTCHDB.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Cắt Hủy Danh Bộ", ds.Tables["CHDB"].Columns["MaCHDB"], ds.Tables["CTCHDB"].Columns["MaCHDB"]);
                    return ds;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataSet LoadDSCHDBDaDuyetByDanhBo(string DanhBo)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    DataSet ds = new DataSet();
                    ///Table CHDB
                    var queryCHDB_DonKH = from itemCHDB in db.CHDBs
                                          //join itemDonKH in db.DonKHs on itemCHDB.MaDon equals itemDonKH.MaDon
                                          //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                          join itemCTCTDB in db.CTCTDBs on itemCHDB.MaCHDB equals itemCTCTDB.MaCHDB
                                          join itemCTCHDB in db.CTCHDBs on itemCTCTDB.MaCHDB equals itemCTCHDB.MaCHDB
                                          where itemCHDB.ToXuLy == false && (itemCTCTDB.DanhBo==DanhBo||itemCTCHDB.DanhBo==DanhBo)
                                          select new
                                          {
                                              itemCHDB.ToXuLy,
                                              itemCHDB.MaDon,
                                              itemCHDB.DonKH.LoaiDon.TenLD,
                                              itemCHDB.DonKH.CreateDate,
                                              itemCHDB.DonKH.DanhBo,
                                              itemCHDB.DonKH.HoTen,
                                              itemCHDB.DonKH.DiaChi,
                                              itemCHDB.DonKH.NoiDung,
                                              MaNoiChuyenDen = itemCHDB.MaNoiChuyenDen,
                                              NoiChuyenDen = itemCHDB.NoiChuyenDen,
                                              LyDoChuyenDen = itemCHDB.LyDoChuyenDen,
                                              itemCHDB.MaCHDB,
                                              NgayXuLy = itemCHDB.CreateDate,
                                              itemCHDB.KetQua,
                                              itemCHDB.MaChuyen,
                                              LyDoChuyenDi = itemCHDB.LyDoChuyen
                                          };

                    var queryCHDB_DonTXL = from itemCHDB in db.CHDBs
                                           //join itemDonKH in db.DonKHs on itemCHDB.MaDon equals itemDonKH.MaDon
                                           //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                           join itemCTCTDB in db.CTCTDBs on itemCHDB.MaCHDB equals itemCTCTDB.MaCHDB
                                           join itemCTCHDB in db.CTCHDBs on itemCTCTDB.MaCHDB equals itemCTCHDB.MaCHDB
                                           where itemCHDB.ToXuLy == true && (itemCTCTDB.DanhBo == DanhBo || itemCTCHDB.DanhBo == DanhBo)
                                           select new
                                           {
                                               itemCHDB.ToXuLy,
                                               MaDon = itemCHDB.MaDonTXL,
                                               itemCHDB.DonTXL.LoaiDonTXL.TenLD,
                                               itemCHDB.DonTXL.CreateDate,
                                               itemCHDB.DonTXL.DanhBo,
                                               itemCHDB.DonTXL.HoTen,
                                               itemCHDB.DonTXL.DiaChi,
                                               itemCHDB.DonTXL.NoiDung,
                                               MaNoiChuyenDen = itemCHDB.MaNoiChuyenDen,
                                               NoiChuyenDen = itemCHDB.NoiChuyenDen,
                                               LyDoChuyenDen = itemCHDB.LyDoChuyenDen,
                                               itemCHDB.MaCHDB,
                                               NgayXuLy = itemCHDB.CreateDate,
                                               itemCHDB.KetQua,
                                               itemCHDB.MaChuyen,
                                               LyDoChuyenDi = itemCHDB.LyDoChuyen
                                           };
                    DataTable dtCHDB = new DataTable();
                    dtCHDB = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCHDB_DonKH.Distinct());
                    dtCHDB.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCHDB_DonTXL.Distinct()));
                    dtCHDB.TableName = "CHDB";
                    ds.Tables.Add(dtCHDB);

                    ///Table CTCTDB
                    var queryCTCTDB = from itemCTCTDB in db.CTCTDBs
                                      where itemCTCTDB.DanhBo==DanhBo
                                      select itemCTCTDB;

                    DataTable dtCTCTDB = new DataTable();
                    dtCTCTDB = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTCTDB);
                    dtCTCTDB.TableName = "CTCTDB";
                    ds.Tables.Add(dtCTCTDB);

                    ///Table CTCHDB
                    var queryCTCHDB = from itemCTCHDB in db.CTCHDBs
                                      where itemCTCHDB.DanhBo== DanhBo
                                      select itemCTCHDB;

                    DataTable dtCTCHDB = new DataTable();
                    dtCTCHDB = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTCHDB);
                    dtCTCHDB.TableName = "CTCHDB";
                    ds.Tables.Add(dtCTCHDB);

                    if (dtCHDB.Rows.Count > 0 && dtCTCTDB.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Cắt Tạm Danh Bộ", ds.Tables["CHDB"].Columns["MaCHDB"], ds.Tables["CTCTDB"].Columns["MaCHDB"]);
                    if (dtCHDB.Rows.Count > 0 && dtCTCHDB.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Cắt Hủy Danh Bộ", ds.Tables["CHDB"].Columns["MaCHDB"], ds.Tables["CTCHDB"].Columns["MaCHDB"]);
                    return ds;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataSet LoadDSCHDBDaDuyetByDate(DateTime TuNgay)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    DataSet ds = new DataSet();
                    ///Table CHDB
                    var queryCHDB_DonKH = from itemCHDB in db.CHDBs
                                          //join itemDonKH in db.DonKHs on itemCHDB.MaDon equals itemDonKH.MaDon
                                          //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                          join itemCTCTDB in db.CTCTDBs on itemCHDB.MaCHDB equals itemCTCTDB.MaCHDB
                                          join itemCTCHDB in db.CTCHDBs on itemCTCTDB.MaCHDB equals itemCTCHDB.MaCHDB
                                          where itemCHDB.ToXuLy == false && (itemCTCTDB.CreateDate.Value.Date==TuNgay.Date||itemCTCHDB.CreateDate.Value.Date==TuNgay.Date)
                                          select new
                                          {
                                              itemCHDB.ToXuLy,
                                              itemCHDB.MaDon,
                                              itemCHDB.DonKH.LoaiDon.TenLD,
                                              itemCHDB.DonKH.CreateDate,
                                              itemCHDB.DonKH.DanhBo,
                                              itemCHDB.DonKH.HoTen,
                                              itemCHDB.DonKH.DiaChi,
                                              itemCHDB.DonKH.NoiDung,
                                              MaNoiChuyenDen = itemCHDB.MaNoiChuyenDen,
                                              NoiChuyenDen = itemCHDB.NoiChuyenDen,
                                              LyDoChuyenDen = itemCHDB.LyDoChuyenDen,
                                              itemCHDB.MaCHDB,
                                              NgayXuLy = itemCHDB.CreateDate,
                                              itemCHDB.KetQua,
                                              itemCHDB.MaChuyen,
                                              LyDoChuyenDi = itemCHDB.LyDoChuyen
                                          };

                    var queryCHDB_DonTXL = from itemCHDB in db.CHDBs
                                           //join itemDonKH in db.DonKHs on itemCHDB.MaDon equals itemDonKH.MaDon
                                           //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                           join itemCTCTDB in db.CTCTDBs on itemCHDB.MaCHDB equals itemCTCTDB.MaCHDB
                                           join itemCTCHDB in db.CTCHDBs on itemCTCTDB.MaCHDB equals itemCTCHDB.MaCHDB
                                           where itemCHDB.ToXuLy == true && (itemCTCTDB.CreateDate.Value.Date == TuNgay.Date || itemCTCHDB.CreateDate.Value.Date == TuNgay.Date)
                                           select new
                                           {
                                               itemCHDB.ToXuLy,
                                               MaDon = itemCHDB.MaDonTXL,
                                               itemCHDB.DonTXL.LoaiDonTXL.TenLD,
                                               itemCHDB.DonTXL.CreateDate,
                                               itemCHDB.DonTXL.DanhBo,
                                               itemCHDB.DonTXL.HoTen,
                                               itemCHDB.DonTXL.DiaChi,
                                               itemCHDB.DonTXL.NoiDung,
                                               MaNoiChuyenDen = itemCHDB.MaNoiChuyenDen,
                                               NoiChuyenDen = itemCHDB.NoiChuyenDen,
                                               LyDoChuyenDen = itemCHDB.LyDoChuyenDen,
                                               itemCHDB.MaCHDB,
                                               NgayXuLy = itemCHDB.CreateDate,
                                               itemCHDB.KetQua,
                                               itemCHDB.MaChuyen,
                                               LyDoChuyenDi = itemCHDB.LyDoChuyen
                                           };
                    DataTable dtCHDB = new DataTable();
                    dtCHDB = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCHDB_DonKH.Distinct());
                    dtCHDB.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCHDB_DonTXL.Distinct()));
                    dtCHDB.TableName = "CHDB";
                    ds.Tables.Add(dtCHDB);

                    ///Table CTCTDB
                    var queryCTCTDB = from itemCTCTDB in db.CTCTDBs
                                      where itemCTCTDB.CreateDate.Value.Date==TuNgay.Date
                                      select itemCTCTDB;

                    DataTable dtCTCTDB = new DataTable();
                    dtCTCTDB = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTCTDB);
                    dtCTCTDB.TableName = "CTCTDB";
                    ds.Tables.Add(dtCTCTDB);

                    ///Table CTCHDB
                    var queryCTCHDB = from itemCTCHDB in db.CTCHDBs
                                      where itemCTCHDB.CreateDate.Value.Date==TuNgay.Date
                                      select itemCTCHDB;

                    DataTable dtCTCHDB = new DataTable();
                    dtCTCHDB = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTCHDB);
                    dtCTCHDB.TableName = "CTCHDB";
                    ds.Tables.Add(dtCTCHDB);

                    if (dtCHDB.Rows.Count > 0 && dtCTCTDB.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Cắt Tạm Danh Bộ", ds.Tables["CHDB"].Columns["MaCHDB"], ds.Tables["CTCTDB"].Columns["MaCHDB"]);
                    if (dtCHDB.Rows.Count > 0 && dtCTCHDB.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Cắt Hủy Danh Bộ", ds.Tables["CHDB"].Columns["MaCHDB"], ds.Tables["CTCHDB"].Columns["MaCHDB"]);
                    return ds;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataSet LoadDSCHDBDaDuyetByDates(DateTime TuNgay,DateTime DenNgay)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    DataSet ds = new DataSet();
                    ///Table CHDB
                    var queryCHDB_DonKH = from itemCHDB in db.CHDBs
                                          //join itemDonKH in db.DonKHs on itemCHDB.MaDon equals itemDonKH.MaDon
                                          //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                          join itemCTCTDB in db.CTCTDBs on itemCHDB.MaCHDB equals itemCTCTDB.MaCHDB
                                          join itemCTCHDB in db.CTCHDBs on itemCTCTDB.MaCHDB equals itemCTCHDB.MaCHDB
                                          where itemCHDB.ToXuLy == false && ((itemCTCTDB.CreateDate.Value.Date >= TuNgay.Date && itemCTCTDB.CreateDate.Value.Date <= DenNgay.Date) || (itemCTCHDB.CreateDate.Value.Date >= TuNgay.Date && itemCTCHDB.CreateDate.Value.Date <= DenNgay.Date))
                                          select new
                                          {
                                              itemCHDB.ToXuLy,
                                              itemCHDB.MaDon,
                                              itemCHDB.DonKH.LoaiDon.TenLD,
                                              itemCHDB.DonKH.CreateDate,
                                              itemCHDB.DonKH.DanhBo,
                                              itemCHDB.DonKH.HoTen,
                                              itemCHDB.DonKH.DiaChi,
                                              itemCHDB.DonKH.NoiDung,
                                              MaNoiChuyenDen = itemCHDB.MaNoiChuyenDen,
                                              NoiChuyenDen = itemCHDB.NoiChuyenDen,
                                              LyDoChuyenDen = itemCHDB.LyDoChuyenDen,
                                              itemCHDB.MaCHDB,
                                              NgayXuLy = itemCHDB.CreateDate,
                                              itemCHDB.KetQua,
                                              itemCHDB.MaChuyen,
                                              LyDoChuyenDi = itemCHDB.LyDoChuyen
                                          };

                    var queryCHDB_DonTXL = from itemCHDB in db.CHDBs
                                           //join itemDonKH in db.DonKHs on itemCHDB.MaDon equals itemDonKH.MaDon
                                           //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                           join itemCTCTDB in db.CTCTDBs on itemCHDB.MaCHDB equals itemCTCTDB.MaCHDB
                                           join itemCTCHDB in db.CTCHDBs on itemCTCTDB.MaCHDB equals itemCTCHDB.MaCHDB
                                           where itemCHDB.ToXuLy == true && ((itemCTCTDB.CreateDate.Value.Date >= TuNgay.Date && itemCTCTDB.CreateDate.Value.Date <= DenNgay.Date) || (itemCTCHDB.CreateDate.Value.Date >= TuNgay.Date && itemCTCHDB.CreateDate.Value.Date <= DenNgay.Date))
                                           select new
                                           {
                                               itemCHDB.ToXuLy,
                                               MaDon = itemCHDB.MaDonTXL,
                                               itemCHDB.DonTXL.LoaiDonTXL.TenLD,
                                               itemCHDB.DonTXL.CreateDate,
                                               itemCHDB.DonTXL.DanhBo,
                                               itemCHDB.DonTXL.HoTen,
                                               itemCHDB.DonTXL.DiaChi,
                                               itemCHDB.DonTXL.NoiDung,
                                               MaNoiChuyenDen = itemCHDB.MaNoiChuyenDen,
                                               NoiChuyenDen = itemCHDB.NoiChuyenDen,
                                               LyDoChuyenDen = itemCHDB.LyDoChuyenDen,
                                               itemCHDB.MaCHDB,
                                               NgayXuLy = itemCHDB.CreateDate,
                                               itemCHDB.KetQua,
                                               itemCHDB.MaChuyen,
                                               LyDoChuyenDi = itemCHDB.LyDoChuyen
                                           };
                    DataTable dtCHDB = new DataTable();
                    dtCHDB = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCHDB_DonKH.Distinct());
                    dtCHDB.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCHDB_DonTXL.Distinct()));
                    dtCHDB.TableName = "CHDB";
                    ds.Tables.Add(dtCHDB);

                    ///Table CTCTDB
                    var queryCTCTDB = from itemCTCTDB in db.CTCTDBs
                                      where itemCTCTDB.CreateDate.Value.Date >= TuNgay.Date && itemCTCTDB.CreateDate.Value.Date <= DenNgay.Date
                                      select itemCTCTDB;

                    DataTable dtCTCTDB = new DataTable();
                    dtCTCTDB = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTCTDB);
                    dtCTCTDB.TableName = "CTCTDB";
                    ds.Tables.Add(dtCTCTDB);

                    ///Table CTCHDB
                    var queryCTCHDB = from itemCTCHDB in db.CTCHDBs
                                      where itemCTCHDB.CreateDate.Value.Date >= TuNgay.Date && itemCTCHDB.CreateDate.Value.Date <= DenNgay.Date
                                      select itemCTCHDB;

                    DataTable dtCTCHDB = new DataTable();
                    dtCTCHDB = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTCHDB);
                    dtCTCHDB.TableName = "CTCHDB";
                    ds.Tables.Add(dtCTCHDB);

                    if (dtCHDB.Rows.Count > 0 && dtCTCTDB.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Cắt Tạm Danh Bộ", ds.Tables["CHDB"].Columns["MaCHDB"], ds.Tables["CTCTDB"].Columns["MaCHDB"]);
                    if (dtCHDB.Rows.Count > 0 && dtCTCHDB.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Cắt Hủy Danh Bộ", ds.Tables["CHDB"].Columns["MaCHDB"], ds.Tables["CTCHDB"].Columns["MaCHDB"]);
                    return ds;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataSet LoadDSCHDBDaDuyet_TXL()
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    DataSet ds = new DataSet();
                    ///Table CHDB
                    var queryCHDB = from itemCHDB in db.CHDBs
                                    join itemDonTXL in db.DonTXLs on itemCHDB.MaDonTXL equals itemDonTXL.MaDon
                                    join itemLoaiDonTXL in db.LoaiDonTXLs on itemDonTXL.MaLD equals itemLoaiDonTXL.MaLD
                                    where itemCHDB.MaDonTXL != null
                                    select new
                                    {
                                        itemDonTXL.MaDon,
                                        itemLoaiDonTXL.TenLD,
                                        itemDonTXL.CreateDate,
                                        itemDonTXL.DanhBo,
                                        itemDonTXL.HoTen,
                                        itemDonTXL.DiaChi,
                                        itemDonTXL.NoiDung,
                                        MaNoiChuyenDen = itemCHDB.MaNoiChuyenDen,
                                        NoiChuyenDen = itemCHDB.NoiChuyenDen,
                                        LyDoChuyenDen = itemCHDB.LyDoChuyenDen,
                                        itemCHDB.MaCHDB,
                                        NgayXuLy = itemCHDB.CreateDate,
                                        itemCHDB.KetQua,
                                        itemCHDB.MaChuyen,
                                        LyDoChuyenDi = itemCHDB.LyDoChuyen
                                    };
                    DataTable dtCHDB = new DataTable();
                    dtCHDB = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCHDB);
                    dtCHDB.TableName = "CHDB";
                    ds.Tables.Add(dtCHDB);

                    ///Table CTCTDB
                    var queryCTCTDB = from itemCTCTDB in db.CTCTDBs
                                      where itemCTCTDB.CHDB.MaDonTXL != null
                                      select itemCTCTDB;

                    DataTable dtCTCTDB = new DataTable();
                    dtCTCTDB = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTCTDB);
                    dtCTCTDB.TableName = "CTCTDB";
                    ds.Tables.Add(dtCTCTDB);

                    ///Table CTCHDB
                    var queryCTCHDB = from itemCTCHDB in db.CTCHDBs
                                      where itemCTCHDB.CHDB.MaDonTXL != null
                                      select itemCTCHDB;

                    DataTable dtCTCHDB = new DataTable();
                    dtCTCHDB = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTCHDB);
                    dtCTCHDB.TableName = "CTCHDB";
                    ds.Tables.Add(dtCTCHDB);

                    if (dtCHDB.Rows.Count > 0 && dtCTCTDB.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Cắt Tạm Danh Bộ", ds.Tables["CHDB"].Columns["MaCHDB"], ds.Tables["CTCTDB"].Columns["MaCHDB"]);
                    if (dtCHDB.Rows.Count > 0 && dtCTCHDB.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Cắt Hủy Danh Bộ", ds.Tables["CHDB"].Columns["MaCHDB"], ds.Tables["CTCHDB"].Columns["MaCHDB"]);
                    return ds;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCHDBChuaDuyet()
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    ///Bảng DonKH
                    var queryDonKH = from itemDonKH in db.DonKHs
                                     join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                     where itemDonKH.Nhan == false && itemDonKH.MaChuyen == "CTCHDB"
                                     select new
                                     {
                                         itemDonKH.MaDon,
                                         itemLoaiDon.TenLD,
                                         itemDonKH.CreateDate,
                                         itemDonKH.DanhBo,
                                         itemDonKH.HoTen,
                                         itemDonKH.DiaChi,
                                         itemDonKH.NoiDung,
                                         MaNoiChuyenDen = itemDonKH.MaDon,
                                         NoiChuyenDen = "Khách Hàng",
                                         LyDoChuyenDen = itemDonKH.LyDoChuyen,
                                         MaCHDB = "",
                                         NgayXuLy = "",
                                         KetQua = "",
                                         MaChuyen = "",
                                         LyDoChuyenDi = ""
                                     };
                    ///Bảng KTXM
                    var queryKTXM = from itemKTXM in db.KTXMs
                                    join itemDonKH in db.DonKHs on itemKTXM.MaDon equals itemDonKH.MaDon
                                    join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                    where itemKTXM.Nhan == false && itemKTXM.MaChuyen == "CTCHDB"
                                    select new
                                    {
                                        itemDonKH.MaDon,
                                        itemLoaiDon.TenLD,
                                        itemDonKH.CreateDate,
                                        itemDonKH.DanhBo,
                                        itemDonKH.HoTen,
                                        itemDonKH.DiaChi,
                                        itemDonKH.NoiDung,
                                        MaNoiChuyenDen = itemKTXM.MaKTXM,
                                        NoiChuyenDen = "Kiểm Tra Xác Minh",
                                        LyDoChuyenDen = itemKTXM.LyDoChuyen,
                                        MaCHDB = "",
                                        NgayXuLy = "",
                                        KetQua = "",
                                        MaChuyen = "",
                                        LyDoChuyenDi = ""
                                    };
                    //if (queryKTXM.Count() > 0)
                    //    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonKH.Union(queryKTXM));
                    //else
                    //    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonKH);
                    DataTable tableDonKH = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDonKH);
                    DataTable tableKTXM = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryKTXM);
                    tableDonKH.Merge(tableKTXM);
                    return tableDonKH;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool ThemCHDB(CHDB chdb)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_CapNhat)
                {
                    if (db.CHDBs.Count() > 0)
                    {
                        string ID = "MaCHDB";
                        string Table = "CHDB";
                        decimal MaCHDB = db.ExecuteQuery<decimal>("declare @Ma int " +
                            "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                            "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                        //decimal MaCHDB = db.CHDBs.Max(itemCHDB => itemCHDB.MaCHDB);
                        chdb.MaCHDB = getMaxNextIDTable(MaCHDB);
                    }
                    else
                        chdb.MaCHDB = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    chdb.CreateDate = DateTime.Now;
                    chdb.CreateBy = CTaiKhoan.MaUser.ToString();
                    db.CHDBs.InsertOnSubmit(chdb);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Thêm CHDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.CHDBs);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool SuaCHDB(CHDB chdb)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_CapNhat)
                {

                    chdb.ModifyDate = DateTime.Now;
                    chdb.ModifyBy = CTaiKhoan.MaUser.ToString();
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa CHDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.CHDBs);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        /// <summary>
        /// Lấy Mã Cắt Hủy Danh Bộ lớn nhất hiện tại
        /// </summary>
        /// <returns></returns>
        public decimal getMaxMaCHDB()
        {
            try
            {
                return db.CHDBs.Max(itemCHDB => itemCHDB.MaCHDB);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public CHDB getCHDBbyID(decimal MaCHDB)
        {
            try
            {
                return db.CHDBs.SingleOrDefault(itemCHDB => itemCHDB.MaCHDB == MaCHDB);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Kiểm tra Đơn Khách Hàng có được CHDB xử lý hay chưa
        /// </summary>
        /// <param name="MaDon"></param>
        /// <returns>true/có</returns>
        public bool CheckCHDBbyMaDon(decimal MaDon)
        {
            try
            {
                if (db.CHDBs.Any(itemCHDB => itemCHDB.MaDon == MaDon))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra Đơn Tổ Xử Lý có được CHDB xử lý hay chưa
        /// </summary>
        /// <param name="MaDonTXL"></param>
        /// <returns>true/có</returns>
        public bool CheckCHDBbyMaDon_TXL(decimal MaDonTXL)
        {
            try
            {
                if (db.CHDBs.Any(itemCHDB => itemCHDB.MaDonTXL == MaDonTXL))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Lấy CHDB bằng MaDon
        /// </summary>
        /// <param name="MaDon"></param>
        /// <returns></returns>
        public CHDB getCHDBbyMaDon(decimal MaDon)
        {
            try
            {
                return db.CHDBs.SingleOrDefault(itemCHDB => itemCHDB.MaDon == MaDon);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy CHDB bằng MaDon Tổ Xử Lý
        /// </summary>
        /// <param name="MaDonTXL"></param>
        /// <returns></returns>
        public CHDB getCHDBbyMaDon_TXL(decimal MaDonTXL)
        {
            try
            {
                return db.CHDBs.SingleOrDefault(itemCHDB => itemCHDB.MaDonTXL == MaDonTXL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Kiểm tra Danh Bộ đã lập cắt tạm/cắt hủy nào trước đó chưa
        /// </summary>
        /// <param name="DanhBo"></param>
        /// <param name="ThongTin"></param>
        /// <returns></returns>
        public bool CheckCHDBbyDanhBo(string DanhBo,out string ThongTin)
        {
            ThongTin = "";
            try
            {
                if (db.CTCTDBs.Any(itemCTCTDB => itemCTCTDB.DanhBo == DanhBo))
                {
                    ThongTin = "Cắt Tạm với Số Phiếu: " + db.CTCTDBs.Where(itemCTCTDB => itemCTCTDB.DanhBo == DanhBo).ToList().LastOrDefault().MaCTCTDB.ToString().Insert(db.CTCTDBs.Where(itemCTCTDB => itemCTCTDB.DanhBo == DanhBo).ToList().LastOrDefault().MaCTCTDB.ToString().Length - 2, "-");
                    return true;
                }
                else
                    if (db.CTCHDBs.Any(itemCTCHDB => itemCTCHDB.DanhBo == DanhBo))
                    {
                        ThongTin = "Cắt Hủy với Số Phiếu: " + db.CTCHDBs.Where(itemCTCHDB => itemCTCHDB.DanhBo == DanhBo).ToList().LastOrDefault().MaCTCHDB.ToString().Insert(db.CTCHDBs.Where(itemCTCHDB => itemCTCHDB.DanhBo == DanhBo).ToList().LastOrDefault().MaCTCHDB.ToString().Length - 2, "-");
                        return true;
                    }
                    else
                        return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion

        #region CTCTDB (Chi Tiết Cắt Tạm Danh Bộ)

        public bool ThemCTCTDB(CTCTDB ctctdb)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_CapNhat)
                {
                    if (db.CTCTDBs.Count() > 0)
                    {
                        string ID = "MaCTCTDB";
                        string Table = "CTCTDB";
                        decimal MaCTCTDB = db.ExecuteQuery<decimal>("declare @Ma int " +
                            "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                            "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                        //decimal MaCTCTDB = db.CTCTDBs.Max(itemCTCTDB => itemCTCTDB.MaCTCTDB);
                        ctctdb.MaCTCTDB = getMaxNextIDTable(MaCTCTDB);
                    }
                    else
                        ctctdb.MaCTCTDB = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    ctctdb.CreateDate = DateTime.Now;
                    ctctdb.CreateBy = CTaiKhoan.MaUser;
                    db.CTCTDBs.InsertOnSubmit(ctctdb);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Thêm CTCTDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.CTCTDBs);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool SuaCTCTDB(CTCTDB ctctdb)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_CapNhat)
                {
                    ctctdb.ModifyDate = DateTime.Now;
                    ctctdb.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa CTCTDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.CTCTDBs);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool XoaCTCTDB(CTCTDB ctctdb)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_CapNhat)
                {
                    db.CTCTDBs.DeleteOnSubmit(ctctdb);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Xóa CTCTDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.CTCTDBs);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool CheckCTCTDBbyID(decimal MaCTCTDB)
        {
            try
            {
                return db.CTCTDBs.Any(itemCTCTDB => itemCTCTDB.MaCTCTDB == MaCTCTDB);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public CTCTDB getCTCTDBbyID(decimal MaCTCTDB)
        {
            try
            {
                return db.CTCTDBs.SingleOrDefault(itemCTCTDB => itemCTCTDB.MaCTCTDB == MaCTCTDB);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public decimal getMaxMaCTCTDB()
        {
            try
            {
                return db.CTCTDBs.Max(itemCTCTDB => itemCTCTDB.MaCTCTDB);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        /// <summary>
        /// Lấy Danh Sách Chi Tiết Cắt Tạm Danh Bộ
        /// </summary>
        /// <returns></returns>
        public DataTable LoadDSCTCTDB()
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem||CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemCTCTDB in db.CTCTDBs
                                //where itemCTCTDB.CHDB.MaDon!=null
                                orderby itemCTCTDB.CreateDate descending
                                select new
                                {
                                    In=false,
                                    itemCTCTDB.PhieuDuocKy,
                                    itemCTCTDB.DaLapPhieu,
                                    itemCTCTDB.SoPhieu,
                                    itemCTCTDB.ThongBaoDuocKy,
                                    MaTB = itemCTCTDB.MaCTCTDB,
                                    Ma = itemCTCTDB.MaCTCTDB,
                                    itemCTCTDB.CreateDate,
                                    itemCTCTDB.DanhBo,
                                    itemCTCTDB.HoTen,
                                    itemCTCTDB.DiaChi,
                                    itemCTCTDB.LyDo,
                                    itemCTCTDB.GhiChuLyDo,
                                    itemCTCTDB.SoTien,
                                    itemCTCTDB.NguoiKy,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTCTDBByMaDon(decimal MaDon)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemCTCTDB in db.CTCTDBs
                                where itemCTCTDB.CHDB.MaDon==MaDon||itemCTCTDB.CHDB.MaDonTXL==MaDon
                                orderby itemCTCTDB.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemCTCTDB.PhieuDuocKy,
                                    itemCTCTDB.DaLapPhieu,
                                    itemCTCTDB.SoPhieu,
                                    itemCTCTDB.ThongBaoDuocKy,
                                    MaTB = itemCTCTDB.MaCTCTDB,
                                    Ma = itemCTCTDB.MaCTCTDB,
                                    itemCTCTDB.CreateDate,
                                    itemCTCTDB.DanhBo,
                                    itemCTCTDB.HoTen,
                                    itemCTCTDB.DiaChi,
                                    itemCTCTDB.LyDo,
                                    itemCTCTDB.GhiChuLyDo,
                                    itemCTCTDB.SoTien,
                                    itemCTCTDB.NguoiKy,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTCTDBByMaTB(decimal MaTB)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemCTCTDB in db.CTCTDBs
                                where itemCTCTDB.MaCTCTDB==MaTB
                                orderby itemCTCTDB.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemCTCTDB.PhieuDuocKy,
                                    itemCTCTDB.DaLapPhieu,
                                    itemCTCTDB.SoPhieu,
                                    itemCTCTDB.ThongBaoDuocKy,
                                    MaTB = itemCTCTDB.MaCTCTDB,
                                    Ma = itemCTCTDB.MaCTCTDB,
                                    itemCTCTDB.CreateDate,
                                    itemCTCTDB.DanhBo,
                                    itemCTCTDB.HoTen,
                                    itemCTCTDB.DiaChi,
                                    itemCTCTDB.LyDo,
                                    itemCTCTDB.GhiChuLyDo,
                                    itemCTCTDB.SoTien,
                                    itemCTCTDB.NguoiKy,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTCTDBByMaTBs(decimal TuMaTB, decimal DenMaTB)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemCTCTDB in db.CTCTDBs
                                where itemCTCTDB.MaCTCTDB.ToString().Substring(itemCTCTDB.MaCTCTDB.ToString().Length - 2, 2) == TuMaTB.ToString().Substring(TuMaTB.ToString().Length - 2, 2)
                                && itemCTCTDB.MaCTCTDB.ToString().Substring(itemCTCTDB.MaCTCTDB.ToString().Length - 2, 2) == DenMaTB.ToString().Substring(DenMaTB.ToString().Length - 2, 2)
                                && itemCTCTDB.MaCTCTDB >= TuMaTB && itemCTCTDB.MaCTCTDB <= DenMaTB
                                orderby itemCTCTDB.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemCTCTDB.PhieuDuocKy,
                                    itemCTCTDB.DaLapPhieu,
                                    itemCTCTDB.SoPhieu,
                                    itemCTCTDB.ThongBaoDuocKy,
                                    MaTB = itemCTCTDB.MaCTCTDB,
                                    Ma = itemCTCTDB.MaCTCTDB,
                                    itemCTCTDB.CreateDate,
                                    itemCTCTDB.DanhBo,
                                    itemCTCTDB.HoTen,
                                    itemCTCTDB.DiaChi,
                                    itemCTCTDB.LyDo,
                                    itemCTCTDB.GhiChuLyDo,
                                    itemCTCTDB.SoTien,
                                    itemCTCTDB.NguoiKy,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTCTDBByDanhBo(string DanhBo)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemCTCTDB in db.CTCTDBs
                                where itemCTCTDB.DanhBo==DanhBo
                                orderby itemCTCTDB.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemCTCTDB.PhieuDuocKy,
                                    itemCTCTDB.DaLapPhieu,
                                    itemCTCTDB.SoPhieu,
                                    itemCTCTDB.ThongBaoDuocKy,
                                    MaTB = itemCTCTDB.MaCTCTDB,
                                    Ma = itemCTCTDB.MaCTCTDB,
                                    itemCTCTDB.CreateDate,
                                    itemCTCTDB.DanhBo,
                                    itemCTCTDB.HoTen,
                                    itemCTCTDB.DiaChi,
                                    itemCTCTDB.LyDo,
                                    itemCTCTDB.GhiChuLyDo,
                                    itemCTCTDB.SoTien,
                                    itemCTCTDB.NguoiKy,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTCTDBByDate(DateTime TuNgay)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemCTCTDB in db.CTCTDBs
                                where itemCTCTDB.CreateDate.Value.Date==TuNgay.Date
                                orderby itemCTCTDB.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemCTCTDB.PhieuDuocKy,
                                    itemCTCTDB.DaLapPhieu,
                                    itemCTCTDB.SoPhieu,
                                    itemCTCTDB.ThongBaoDuocKy,
                                    MaTB = itemCTCTDB.MaCTCTDB,
                                    Ma = itemCTCTDB.MaCTCTDB,
                                    itemCTCTDB.CreateDate,
                                    itemCTCTDB.DanhBo,
                                    itemCTCTDB.HoTen,
                                    itemCTCTDB.DiaChi,
                                    itemCTCTDB.LyDo,
                                    itemCTCTDB.GhiChuLyDo,
                                    itemCTCTDB.SoTien,
                                    itemCTCTDB.NguoiKy,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTCTDBByDates(DateTime TuNgay,DateTime DenNgay)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemCTCTDB in db.CTCTDBs
                                where itemCTCTDB.CreateDate.Value.Date>=TuNgay.Date&&itemCTCTDB.CreateDate.Value<=DenNgay.Date
                                orderby itemCTCTDB.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemCTCTDB.PhieuDuocKy,
                                    itemCTCTDB.DaLapPhieu,
                                    itemCTCTDB.SoPhieu,
                                    itemCTCTDB.ThongBaoDuocKy,
                                    MaTB = itemCTCTDB.MaCTCTDB,
                                    Ma = itemCTCTDB.MaCTCTDB,
                                    itemCTCTDB.CreateDate,
                                    itemCTCTDB.DanhBo,
                                    itemCTCTDB.HoTen,
                                    itemCTCTDB.DiaChi,
                                    itemCTCTDB.LyDo,
                                    itemCTCTDB.GhiChuLyDo,
                                    itemCTCTDB.SoTien,
                                    itemCTCTDB.NguoiKy,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTCTDBtheocamketByDate(DateTime TuNgay)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemCTCTDB in db.CTCTDBs
                                where itemCTCTDB.CreateDate.Value.Date == TuNgay.Date && itemCTCTDB.GhiChuLyDo.Contains("theo cam kết")
                                //orderby itemCTCTDB.CreateDate descending
                                select new
                                {
                                    itemCTCTDB.DanhBo,
                                    itemCTCTDB.HoTen,
                                    itemCTCTDB.DiaChi,
                                    itemCTCTDB.LyDo,
                                    itemCTCTDB.GhiChuLyDo,
                                    itemCTCTDB.SoTien,
                                    itemCTCTDB.NgayTCTBXuLy,
                                    itemCTCTDB.KetQuaTCTBXuLy,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTCTDBtheocamketByDates(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemCTCTDB in db.CTCTDBs
                                where itemCTCTDB.CreateDate.Value.Date >= TuNgay.Date && itemCTCTDB.CreateDate.Value <= DenNgay.Date && itemCTCTDB.GhiChuLyDo.Contains("theo cam kết")
                                //orderby itemCTCTDB.CreateDate descending
                                select new
                                {
                                    itemCTCTDB.DanhBo,
                                    itemCTCTDB.HoTen,
                                    itemCTCTDB.DiaChi,
                                    itemCTCTDB.LyDo,
                                    itemCTCTDB.GhiChuLyDo,
                                    itemCTCTDB.SoTien,
                                    itemCTCTDB.NgayTCTBXuLy,
                                    itemCTCTDB.KetQuaTCTBXuLy,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Danh Sách Chi Tiết Cắt Tạm Danh Bộ trong Ngày
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <returns></returns>
        public DataTable LoadDSCTCTDB(DateTime TuNgay)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemCTCTDB in db.CTCTDBs
                                where itemCTCTDB.CreateDate.Value.Date == TuNgay.Date
                                select new
                                {
                                    In = false,
                                    itemCTCTDB.PhieuDuocKy,
                                    itemCTCTDB.DaLapPhieu,
                                    itemCTCTDB.ThongBaoDuocKy,
                                    MaTB = itemCTCTDB.MaCTCTDB,
                                    Ma = itemCTCTDB.MaCTCTDB,
                                    itemCTCTDB.CreateDate,
                                    itemCTCTDB.DanhBo,
                                    itemCTCTDB.HoTen,
                                    itemCTCTDB.DiaChi,
                                    itemCTCTDB.LyDo,
                                    itemCTCTDB.GhiChuLyDo,
                                    itemCTCTDB.SoTien,
                                    itemCTCTDB.TCTBXuLy,
                                    itemCTCTDB.TroNgai,
                                    itemCTCTDB.NguoiKy,
                                    itemCTCTDB.NoiDungXuLy,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Danh Sách Chi Tiết Cắt Tạm Danh Bộ trong Khoảng Thời Gian
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <returns></returns>
        public DataTable LoadDSCTCTDB(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemCTCTDB in db.CTCTDBs
                                where itemCTCTDB.CreateDate.Value.Date >= TuNgay.Date && itemCTCTDB.CreateDate.Value.Date <= DenNgay.Date
                                select new
                                {
                                    In = false,
                                    itemCTCTDB.PhieuDuocKy,
                                    itemCTCTDB.DaLapPhieu,
                                    itemCTCTDB.ThongBaoDuocKy,
                                    MaTB = itemCTCTDB.MaCTCTDB,
                                    Ma = itemCTCTDB.MaCTCTDB,
                                    itemCTCTDB.CreateDate,
                                    itemCTCTDB.DanhBo,
                                    itemCTCTDB.HoTen,
                                    itemCTCTDB.DiaChi,
                                    itemCTCTDB.LyDo,
                                    itemCTCTDB.GhiChuLyDo,
                                    itemCTCTDB.SoTien,
                                    itemCTCTDB.TCTBXuLy,
                                    itemCTCTDB.TroNgai,
                                    itemCTCTDB.NguoiKy,
                                    itemCTCTDB.NoiDungXuLy,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTCTDB_Ton(DateTime TuNgay)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemCTCTDB in db.CTCTDBs
                                where itemCTCTDB.NgayXuLy==null && itemCTCTDB.SoPhieu==null && itemCTCTDB.CreateDate.Value.Date == TuNgay.Date
                                orderby itemCTCTDB.CreateDate ascending
                                select new
                                {
                                    itemCTCTDB.MaCTCTDB,
                                    itemCTCTDB.CreateDate,
                                    itemCTCTDB.DanhBo,
                                    itemCTCTDB.HoTen,
                                    itemCTCTDB.DiaChi,
                                    itemCTCTDB.LyDo,
                                    itemCTCTDB.GhiChuLyDo,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTCTDB_Ton(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemCTCTDB in db.CTCTDBs
                                where itemCTCTDB.NgayXuLy == null && itemCTCTDB.SoPhieu == null && itemCTCTDB.CreateDate.Value.Date >= TuNgay.Date && itemCTCTDB.CreateDate.Value.Date <= DenNgay.Date
                                orderby itemCTCTDB.CreateDate ascending
                                select new
                                {
                                    itemCTCTDB.MaCTCTDB,
                                    itemCTCTDB.CreateDate,
                                    itemCTCTDB.DanhBo,
                                    itemCTCTDB.HoTen,
                                    itemCTCTDB.DiaChi,
                                    itemCTCTDB.LyDo,
                                    itemCTCTDB.GhiChuLyDo,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Danh Sách Chi Tiết Cắt Tạm Danh Bộ Tổ Xử Lý
        /// </summary>
        /// <returns></returns>
        public DataTable LoadDSCTCTDB_TXL()
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemCTCTDB in db.CTCTDBs
                                where itemCTCTDB.CHDB.MaDonTXL != null
                                select new
                                {
                                    In=false,
                                    MaTB = itemCTCTDB.MaCTCTDB,
                                    itemCTCTDB.DanhBo,
                                    itemCTCTDB.HoTen,
                                    itemCTCTDB.DiaChi,
                                    itemCTCTDB.LyDo,
                                    itemCTCTDB.GhiChuLyDo,
                                    itemCTCTDB.SoTien,
                                    itemCTCTDB.ThongBaoDuocKy,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Kiểm tra CTCTDB đã được tạo cho Mã Đơn KH và Danh Bộ này chưa
        /// </summary>
        /// <param name="MaDon"></param>
        /// <param name="DanhBo"></param>
        /// <returns></returns>
        public bool CheckCTCTDBbyMaDonDanhBo(decimal MaDon, string DanhBo)
        {
            try
            {
                return db.CTCTDBs.Any(itemCTCTDB => itemCTCTDB.CHDB.MaDon == MaDon && itemCTCTDB.DanhBo == DanhBo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra CTCTDB đã được tạo cho Mã Đơn TXL và Danh Bộ này chưa
        /// </summary>
        /// <param name="MaDonTXL"></param>
        /// <param name="DanhBo"></param>
        /// <returns></returns>
        public bool CheckCTCTDBbyMaDonDanhBo_TXL(decimal MaDonTXL, string DanhBo)
        {
            try
            {
                return db.CTCTDBs.Any(itemCTCTDB => itemCTCTDB.CHDB.MaDonTXL == MaDonTXL && itemCTCTDB.DanhBo == DanhBo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion

        #region CTCHDB (Chi Tiết Cắt Hủy Danh Bộ)

        public bool ThemCTCHDB(CTCHDB ctchdb)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_CapNhat)
                {
                    if (db.CTCHDBs.Count() > 0)
                    {
                        string ID = "MaCTCHDB";
                        string Table = "CTCHDB";
                        decimal MaCTCHDB = db.ExecuteQuery<decimal>("declare @Ma int " +
                            "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                            "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                        //decimal MaCTCHDB = db.CTCHDBs.Max(itemCTCHDB => itemCTCHDB.MaCTCHDB);
                        ctchdb.MaCTCHDB = getMaxNextIDTable(MaCTCHDB);
                    }
                    else
                        ctchdb.MaCTCHDB = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    ctchdb.CreateDate = DateTime.Now;
                    ctchdb.CreateBy = CTaiKhoan.MaUser;
                    db.CTCHDBs.InsertOnSubmit(ctchdb);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Thêm CTCHDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.CTCHDBs);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool SuaCTCHDB(CTCHDB ctchdb)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_CapNhat)
                {
                    ctchdb.ModifyDate = DateTime.Now;
                    ctchdb.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa CTCHDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.CTCHDBs);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool XoaCTCHDB(CTCHDB ctchdb)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_CapNhat)
                {
                    db.CTCHDBs.DeleteOnSubmit(ctchdb);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Xóa CTCHDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.CTCHDBs);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public CTCHDB getCTCHDBbyID(decimal MaCTCHDB)
        {
            try
            {
                return db.CTCHDBs.SingleOrDefault(itemCTCHDB => itemCTCHDB.MaCTCHDB == MaCTCHDB);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public decimal getMaxMaCTCHDB()
        {
            try
            {
                return db.CTCHDBs.Max(itemCTCHDB => itemCTCHDB.MaCTCHDB);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        /// <summary>
        /// Lấy Danh Sách Chi Tiết Cắt Hủy Danh Bộ
        /// </summary>
        /// <returns></returns>
        public DataTable LoadDSCTCHDB()
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemCTCHDB in db.CTCHDBs
                                //where itemCTCHDB.CHDB.MaDon!=null
                                orderby itemCTCHDB.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemCTCHDB.PhieuDuocKy,
                                    itemCTCHDB.DaLapPhieu,
                                    itemCTCHDB.SoPhieu,
                                    itemCTCHDB.ThongBaoDuocKy,
                                    MaTB = itemCTCHDB.MaCTCHDB,
                                    Ma = itemCTCHDB.MaCTCHDB,
                                    itemCTCHDB.CreateDate,
                                    itemCTCHDB.DanhBo,
                                    itemCTCHDB.HoTen,
                                    itemCTCHDB.DiaChi,
                                    itemCTCHDB.LyDo,
                                    itemCTCHDB.GhiChuLyDo,
                                    itemCTCHDB.SoTien,
                                    itemCTCHDB.NguoiKy,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTCHDBByMaDon(decimal MaDon)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemCTCHDB in db.CTCHDBs
                                where itemCTCHDB.CHDB.MaDon==MaDon||itemCTCHDB.CHDB.MaDonTXL==MaDon
                                orderby itemCTCHDB.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemCTCHDB.PhieuDuocKy,
                                    itemCTCHDB.DaLapPhieu,
                                    itemCTCHDB.SoPhieu,
                                    itemCTCHDB.ThongBaoDuocKy,
                                    MaTB = itemCTCHDB.MaCTCHDB,
                                    Ma = itemCTCHDB.MaCTCHDB,
                                    itemCTCHDB.CreateDate,
                                    itemCTCHDB.DanhBo,
                                    itemCTCHDB.HoTen,
                                    itemCTCHDB.DiaChi,
                                    itemCTCHDB.LyDo,
                                    itemCTCHDB.GhiChuLyDo,
                                    itemCTCHDB.SoTien,
                                    itemCTCHDB.NguoiKy,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTCHDBByMaTB(decimal MaTB)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemCTCHDB in db.CTCHDBs
                                where itemCTCHDB.MaCTCHDB==MaTB
                                orderby itemCTCHDB.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemCTCHDB.PhieuDuocKy,
                                    itemCTCHDB.DaLapPhieu,
                                    itemCTCHDB.SoPhieu,
                                    itemCTCHDB.ThongBaoDuocKy,
                                    MaTB = itemCTCHDB.MaCTCHDB,
                                    Ma = itemCTCHDB.MaCTCHDB,
                                    itemCTCHDB.CreateDate,
                                    itemCTCHDB.DanhBo,
                                    itemCTCHDB.HoTen,
                                    itemCTCHDB.DiaChi,
                                    itemCTCHDB.LyDo,
                                    itemCTCHDB.GhiChuLyDo,
                                    itemCTCHDB.SoTien,
                                    itemCTCHDB.NguoiKy,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTCHDBByMaTBs(decimal TuMaTB, decimal DenMaTB)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemCTCHDB in db.CTCHDBs
                                where itemCTCHDB.MaCTCHDB.ToString().Substring(itemCTCHDB.MaCTCHDB.ToString().Length - 2, 2) == TuMaTB.ToString().Substring(TuMaTB.ToString().Length - 2, 2)
                                && itemCTCHDB.MaCTCHDB.ToString().Substring(itemCTCHDB.MaCTCHDB.ToString().Length - 2, 2) == DenMaTB.ToString().Substring(DenMaTB.ToString().Length - 2, 2)
                                && itemCTCHDB.MaCTCHDB >= TuMaTB && itemCTCHDB.MaCTCHDB <= DenMaTB
                                orderby itemCTCHDB.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemCTCHDB.PhieuDuocKy,
                                    itemCTCHDB.DaLapPhieu,
                                    itemCTCHDB.SoPhieu,
                                    itemCTCHDB.ThongBaoDuocKy,
                                    MaTB = itemCTCHDB.MaCTCHDB,
                                    Ma = itemCTCHDB.MaCTCHDB,
                                    itemCTCHDB.CreateDate,
                                    itemCTCHDB.DanhBo,
                                    itemCTCHDB.HoTen,
                                    itemCTCHDB.DiaChi,
                                    itemCTCHDB.LyDo,
                                    itemCTCHDB.GhiChuLyDo,
                                    itemCTCHDB.SoTien,
                                    itemCTCHDB.NguoiKy,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTCHDBByDanhBo(string DanhBo)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemCTCHDB in db.CTCHDBs
                                where itemCTCHDB.DanhBo==DanhBo
                                orderby itemCTCHDB.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemCTCHDB.PhieuDuocKy,
                                    itemCTCHDB.DaLapPhieu,
                                    itemCTCHDB.SoPhieu,
                                    itemCTCHDB.ThongBaoDuocKy,
                                    MaTB = itemCTCHDB.MaCTCHDB,
                                    Ma = itemCTCHDB.MaCTCHDB,
                                    itemCTCHDB.CreateDate,
                                    itemCTCHDB.DanhBo,
                                    itemCTCHDB.HoTen,
                                    itemCTCHDB.DiaChi,
                                    itemCTCHDB.LyDo,
                                    itemCTCHDB.GhiChuLyDo,
                                    itemCTCHDB.SoTien,
                                    itemCTCHDB.NguoiKy,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTCHDBByDate(DateTime TuNgay)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemCTCHDB in db.CTCHDBs
                                where itemCTCHDB.CreateDate.Value.Date==TuNgay.Date
                                orderby itemCTCHDB.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemCTCHDB.PhieuDuocKy,
                                    itemCTCHDB.DaLapPhieu,
                                    itemCTCHDB.SoPhieu,
                                    itemCTCHDB.ThongBaoDuocKy,
                                    MaTB = itemCTCHDB.MaCTCHDB,
                                    Ma = itemCTCHDB.MaCTCHDB,
                                    itemCTCHDB.CreateDate,
                                    itemCTCHDB.DanhBo,
                                    itemCTCHDB.HoTen,
                                    itemCTCHDB.DiaChi,
                                    itemCTCHDB.LyDo,
                                    itemCTCHDB.GhiChuLyDo,
                                    itemCTCHDB.SoTien,
                                    itemCTCHDB.NguoiKy,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTCHDBByDates(DateTime TuNgay,DateTime DenNgay)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemCTCHDB in db.CTCHDBs
                                where itemCTCHDB.CreateDate.Value.Date>=TuNgay.Date&&itemCTCHDB.CreateDate.Value.Date<=DenNgay.Date
                                orderby itemCTCHDB.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemCTCHDB.PhieuDuocKy,
                                    itemCTCHDB.DaLapPhieu,
                                    itemCTCHDB.SoPhieu,
                                    itemCTCHDB.ThongBaoDuocKy,
                                    MaTB = itemCTCHDB.MaCTCHDB,
                                    Ma = itemCTCHDB.MaCTCHDB,
                                    itemCTCHDB.CreateDate,
                                    itemCTCHDB.DanhBo,
                                    itemCTCHDB.HoTen,
                                    itemCTCHDB.DiaChi,
                                    itemCTCHDB.LyDo,
                                    itemCTCHDB.GhiChuLyDo,
                                    itemCTCHDB.SoTien,
                                    itemCTCHDB.NguoiKy,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Danh Sách Chi Tiết Cắt Hủy Danh Bộ trong Ngày
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <returns></returns>
        public DataTable LoadDSCTCHDB(DateTime TuNgay)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemCTCHDB in db.CTCHDBs
                                where itemCTCHDB.CreateDate.Value.Date == TuNgay.Date
                                select new
                                {
                                    In = false,
                                    itemCTCHDB.PhieuDuocKy,
                                    itemCTCHDB.DaLapPhieu,
                                    itemCTCHDB.ThongBaoDuocKy,
                                    MaTB = itemCTCHDB.MaCTCHDB,
                                    Ma = itemCTCHDB.MaCTCHDB,
                                    itemCTCHDB.CreateDate,
                                    itemCTCHDB.DanhBo,
                                    itemCTCHDB.HoTen,
                                    itemCTCHDB.DiaChi,
                                    itemCTCHDB.LyDo,
                                    itemCTCHDB.GhiChuLyDo,
                                    itemCTCHDB.SoTien,
                                    itemCTCHDB.TCTBXuLy,
                                    itemCTCHDB.TroNgai,
                                    itemCTCHDB.NguoiKy,
                                    itemCTCHDB.NoiDungXuLy,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Danh Sách Chi Tiết Cắt Hủy Danh Bộ trong Khoảng Thời Gian
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <returns></returns>
        public DataTable LoadDSCTCHDB(DateTime TuNgay,DateTime DenNgay)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemCTCHDB in db.CTCHDBs
                                where itemCTCHDB.CreateDate.Value.Date >= TuNgay.Date && itemCTCHDB.CreateDate.Value.Date <= DenNgay.Date
                                select new
                                {
                                    In = false,
                                    itemCTCHDB.PhieuDuocKy,
                                    itemCTCHDB.DaLapPhieu,
                                    itemCTCHDB.ThongBaoDuocKy,
                                    MaTB = itemCTCHDB.MaCTCHDB,
                                    Ma = itemCTCHDB.MaCTCHDB,
                                    itemCTCHDB.CreateDate,
                                    itemCTCHDB.DanhBo,
                                    itemCTCHDB.HoTen,
                                    itemCTCHDB.DiaChi,
                                    itemCTCHDB.LyDo,
                                    itemCTCHDB.GhiChuLyDo,
                                    itemCTCHDB.SoTien,
                                    itemCTCHDB.TCTBXuLy,
                                    itemCTCHDB.TroNgai,
                                    itemCTCHDB.NguoiKy,
                                    itemCTCHDB.NoiDungXuLy,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTCHDB_Ton(DateTime TuNgay)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemCTCHDB in db.CTCHDBs
                                where itemCTCHDB.NgayXuLy == null && itemCTCHDB.SoPhieu == null && itemCTCHDB.CreateDate.Value.Date == TuNgay.Date
                                orderby itemCTCHDB.CreateDate ascending
                                select new
                                {
                                    itemCTCHDB.MaCTCHDB,
                                    itemCTCHDB.CreateDate,
                                    itemCTCHDB.DanhBo,
                                    itemCTCHDB.HoTen,
                                    itemCTCHDB.DiaChi,
                                    itemCTCHDB.LyDo,
                                    itemCTCHDB.GhiChuLyDo,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSCTCHDB_Ton(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemCTCHDB in db.CTCHDBs
                                where itemCTCHDB.NgayXuLy == null && itemCTCHDB.SoPhieu == null && itemCTCHDB.CreateDate.Value.Date >= TuNgay.Date && itemCTCHDB.CreateDate.Value.Date <= DenNgay.Date
                                orderby itemCTCHDB.CreateDate ascending
                                select new
                                {
                                    itemCTCHDB.MaCTCHDB,
                                    itemCTCHDB.CreateDate,
                                    itemCTCHDB.DanhBo,
                                    itemCTCHDB.HoTen,
                                    itemCTCHDB.DiaChi,
                                    itemCTCHDB.LyDo,
                                    itemCTCHDB.GhiChuLyDo,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Danh Sách Chi Tiết Cắt Hủy Danh Bộ Tổ Xử Lý
        /// </summary>
        /// <returns></returns>
        public DataTable LoadDSCTCHDB_TXL()
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemCTCHDB in db.CTCHDBs
                                where itemCTCHDB.CHDB.MaDonTXL != null
                                select new
                                {
                                    In = false,
                                    MaTB = itemCTCHDB.MaCTCHDB,
                                    itemCTCHDB.DanhBo,
                                    itemCTCHDB.HoTen,
                                    itemCTCHDB.DiaChi,
                                    itemCTCHDB.LyDo,
                                    itemCTCHDB.GhiChuLyDo,
                                    itemCTCHDB.SoTien,
                                    itemCTCHDB.ThongBaoDuocKy,
                                    itemCTCHDB.DaLapPhieu,
                                    itemCTCHDB.PhieuDuocKy,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        /// <summary>
        /// Kiểm tra Cắt Hủy đã được lập trước đó chưa, trong record Cắt Hủy có column Mã Chi Tiết Cắt Tạm
        /// </summary>
        /// <param name="MaCTCTDB"></param>
        /// <returns></returns>
        public bool CheckCTCHDBbyCTCTDB(decimal MaCTCTDB)
        {
            try
            {
                return db.CTCHDBs.Any(itemCTCHDB => itemCTCHDB.MaCTCTDB == MaCTCTDB);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        ///// <summary>
        ///// Lấy Số Phiếu kế tiếp khi lập Cắt Hủy Danh Bộ
        ///// </summary>
        ///// <returns></returns>
        //public decimal getMaxNextSoPhieuCHDB()
        //{
        //    try
        //    {
        //        if (db.CTCHDBs.Count() > 0)
        //        {
        //            if (db.CTCHDBs.Max(itemCTCHDB => itemCTCHDB.SoPhieu) == null)
        //                return decimal.Parse("1" + DateTime.Now.ToString("yy"));
        //            else
        //                return getMaxNextIDTable(db.CTCHDBs.Max(itemCTCHDB => itemCTCHDB.SoPhieu).Value);
        //        }
        //        else
        //            return decimal.Parse("1" + DateTime.Now.ToString("yy"));
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return 0;
        //    }
        //}

        ///// <summary>
        ///// Kiểm Tra Cắt Hủy Danh Bộ đã lập Phiếu chưa
        ///// </summary>
        ///// <param name="MaCTCHDB"></param>
        ///// <returns></returns>
        //public bool CheckDaLapPhieuCHDB(decimal MaCTCHDB)
        //{
        //    try
        //    {
        //        return db.CTCHDBs.Any(itemCTCHDB => itemCTCHDB.MaCTCHDB == MaCTCHDB && itemCTCHDB.DaLapPhieu == true);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //}

        /// <summary>
        /// Kiểm tra CTCHDB đã được tạo cho Mã Đơn Khách Hàng và Danh Bộ này chưa
        /// </summary>
        /// <param name="MaDon"></param>
        /// <param name="DanhBo"></param>
        /// <returns></returns>
        public bool CheckCTCHDBbyMaDonDanhBo(decimal MaDon, string DanhBo)
        {
            try
            {
                return db.CTCHDBs.Any(itemCTCHDB => itemCTCHDB.CHDB.MaDon == MaDon && itemCTCHDB.DanhBo == DanhBo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra CTCHDB đã được tạo cho Mã Đơn Tổ Xử Lý và Danh Bộ này chưa
        /// </summary>
        /// <param name="MaDonTXL"></param>
        /// <param name="DanhBo"></param>
        /// <returns></returns>
        public bool CheckCTCHDBbyMaDonDanhBo_TXL(decimal MaDonTXL, string DanhBo)
        {
            try
            {
                return db.CTCHDBs.Any(itemCTCHDB => itemCTCHDB.CHDB.MaDonTXL == MaDonTXL && itemCTCHDB.DanhBo == DanhBo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion

        #region YeuCauCHDB (Phiếu Yêu Cầu Cắt Hủy Danh Bộ)

        /// <summary>
        /// Kiểm tra Thông Báo CTDB có được lấp Phiếu Yếu Cầu CHDB không
        /// </summary>
        /// <param name="MaCTCTDB"></param>
        /// <returns></returns>
        public bool CheckYeuCauCHDBbyMaCTCTDB(decimal MaCTCTDB)
        {
            try
            {
                return db.YeuCauCHDBs.Any(itemYCCHDB => itemYCCHDB.MaCTCTDB==MaCTCTDB);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra Thông Báo CHDB có được lấp Phiếu Yếu Cầu CHDB không
        /// </summary>
        /// <param name="MaCTCHDB"></param>
        /// <returns></returns>
        public bool CheckYeuCauCHDBbyMaCTCHDB(decimal MaCTCHDB)
        {
            try
            {
                return db.YeuCauCHDBs.Any(itemYCCHDB => itemYCCHDB.MaCTCHDB == MaCTCHDB);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool ThemYeuCauCHDB(YeuCauCHDB ycchdb)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_CapNhat)
                {
                    if (db.YeuCauCHDBs.Count() > 0)
                    {
                        string ID = "MaYCCHDB";
                        string Table = "YeuCauCHDB";
                        decimal MaYCCHDB = db.ExecuteQuery<decimal>("declare @Ma int " +
                            "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                            "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                        //decimal MaYCCHDB = db.YeuCauCHDBs.Max(itemYCCHDB => itemYCCHDB.MaYCCHDB);
                        ycchdb.MaYCCHDB = getMaxNextIDTable(MaYCCHDB);
                    }
                    else
                        ycchdb.MaYCCHDB = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    ycchdb.CreateDate = DateTime.Now;
                    ycchdb.CreateBy = CTaiKhoan.MaUser;
                    db.YeuCauCHDBs.InsertOnSubmit(ycchdb);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Thêm YeuCauCHDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.YeuCauCHDBs);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool SuaYeuCauCHDB(YeuCauCHDB ycchdb)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_CapNhat)
                {
                    ycchdb.ModifyDate = DateTime.Now;
                    ycchdb.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa YeuCauCHDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.YeuCauCHDBs);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool XoaYeuCauCHDB(YeuCauCHDB ycchdb)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_CapNhat)
                {
                    db.YeuCauCHDBs.DeleteOnSubmit(ycchdb);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa YeuCauCHDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.YeuCauCHDBs);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public YeuCauCHDB getYeuCauCHDbyID(decimal MaYCCHDB)
        {
            try
            {
                return db.YeuCauCHDBs.SingleOrDefault(itemYCCHDB => itemYCCHDB.MaYCCHDB == MaYCCHDB);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public YeuCauCHDB getYeuCauCHDBbyMaCTCTDB(decimal MaCTCTDB)
        {
            try
            {
                return db.YeuCauCHDBs.Where(itemYCCHDB => itemYCCHDB.MaCTCTDB == MaCTCTDB).OrderBy(item=>item.CreateDate).ToList().Last();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public YeuCauCHDB getYeuCauCHDBbyMaCTCHDB(decimal MaCTCHDB)
        {
            try
            {
                return db.YeuCauCHDBs.Where(itemYCCHDB => itemYCCHDB.MaCTCHDB == MaCTCHDB).OrderBy(item => item.CreateDate).ToList().Last();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Kiểm tra Đơn Khách Hàng có được YCCHDB xử lý hay chưa
        /// </summary>
        /// <param name="MaDon"></param>
        /// <param name="DanhBo"></param>
        /// <returns>true/có</returns>
        public bool CheckYCCHDBbyMaDonDanhBo(decimal MaDon,string DanhBo)
        {
            try
            {
                if (db.YeuCauCHDBs.Any(itemYCCHDB => itemYCCHDB.MaDon == MaDon&& itemYCCHDB.DanhBo==DanhBo))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra Đơn Tổ Xử Lý có được YCCHDB xử lý hay chưa
        /// </summary>
        /// <param name="MaDonTXL"></param>
        /// <param name="DanhBo"></param>
        /// <returns>true/có</returns>
        public bool CheckYCCHDBbyMaDonDanhBo_TXL(decimal MaDonTXL,string DanhBo)
        {
            try
            {
                if (db.YeuCauCHDBs.Any(itemYCCHDB => itemYCCHDB.MaDonTXL == MaDonTXL&&itemYCCHDB.DanhBo==DanhBo))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Lấy Danh Sách Yêu Cầu Cắt Hủy Danh Bộ trực tiếp không qua Thông Báo
        /// </summary>
        /// <returns></returns>
        public DataTable LoadDSYCCHDB()
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemYCCHDB in db.YeuCauCHDBs
                                orderby itemYCCHDB.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemYCCHDB.PhieuDuocKy,
                                    SoPhieu=itemYCCHDB.MaYCCHDB,
                                    Ma = itemYCCHDB.MaYCCHDB,
                                    itemYCCHDB.CreateDate,
                                    itemYCCHDB.DanhBo,
                                    itemYCCHDB.HoTen,
                                    itemYCCHDB.DiaChi,
                                    itemYCCHDB.LyDo,
                                    itemYCCHDB.GhiChuLyDo,
                                    itemYCCHDB.SoTien,
                                    itemYCCHDB.NguoiKy,
                                    itemYCCHDB.NgayCatTamNutBit,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSYCCHDBByMaDon(decimal MaDon)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemYCCHDB in db.YeuCauCHDBs
                                where itemYCCHDB.MaDon==MaDon ||itemYCCHDB.MaDonTXL==MaDon
                                orderby itemYCCHDB.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemYCCHDB.PhieuDuocKy,
                                    SoPhieu = itemYCCHDB.MaYCCHDB,
                                    Ma = itemYCCHDB.MaYCCHDB,
                                    itemYCCHDB.CreateDate,
                                    itemYCCHDB.DanhBo,
                                    itemYCCHDB.HoTen,
                                    itemYCCHDB.DiaChi,
                                    itemYCCHDB.LyDo,
                                    itemYCCHDB.GhiChuLyDo,
                                    itemYCCHDB.SoTien,
                                    itemYCCHDB.NguoiKy,
                                    itemYCCHDB.NgayCatTamNutBit,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSYCCHDBBySoPhieu(decimal SoPhieu)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemYCCHDB in db.YeuCauCHDBs
                                where itemYCCHDB.MaYCCHDB==SoPhieu
                                orderby itemYCCHDB.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemYCCHDB.PhieuDuocKy,
                                    SoPhieu = itemYCCHDB.MaYCCHDB,
                                    Ma = itemYCCHDB.MaYCCHDB,
                                    itemYCCHDB.CreateDate,
                                    itemYCCHDB.DanhBo,
                                    itemYCCHDB.HoTen,
                                    itemYCCHDB.DiaChi,
                                    itemYCCHDB.LyDo,
                                    itemYCCHDB.GhiChuLyDo,
                                    itemYCCHDB.SoTien,
                                    itemYCCHDB.NguoiKy,
                                    itemYCCHDB.NgayCatTamNutBit,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSYCCHDBBySoPhieus(decimal TuSoPhieu, decimal DenSoPhieu)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemYCCHDB in db.YeuCauCHDBs
                                where itemYCCHDB.MaYCCHDB >= TuSoPhieu && itemYCCHDB.MaYCCHDB <= DenSoPhieu
                                orderby itemYCCHDB.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemYCCHDB.PhieuDuocKy,
                                    SoPhieu = itemYCCHDB.MaYCCHDB,
                                    Ma = itemYCCHDB.MaYCCHDB,
                                    itemYCCHDB.CreateDate,
                                    itemYCCHDB.DanhBo,
                                    itemYCCHDB.HoTen,
                                    itemYCCHDB.DiaChi,
                                    itemYCCHDB.LyDo,
                                    itemYCCHDB.GhiChuLyDo,
                                    itemYCCHDB.SoTien,
                                    itemYCCHDB.NguoiKy,
                                    itemYCCHDB.NgayCatTamNutBit,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSYCCHDBByDanhBo(string DanhBo)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemYCCHDB in db.YeuCauCHDBs
                                where itemYCCHDB.DanhBo==DanhBo
                                orderby itemYCCHDB.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemYCCHDB.PhieuDuocKy,
                                    SoPhieu = itemYCCHDB.MaYCCHDB,
                                    Ma = itemYCCHDB.MaYCCHDB,
                                    itemYCCHDB.CreateDate,
                                    itemYCCHDB.DanhBo,
                                    itemYCCHDB.HoTen,
                                    itemYCCHDB.DiaChi,
                                    itemYCCHDB.LyDo,
                                    itemYCCHDB.GhiChuLyDo,
                                    itemYCCHDB.SoTien,
                                    itemYCCHDB.NguoiKy,
                                    itemYCCHDB.NgayCatTamNutBit,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSYCCHDBByDate(DateTime TuNgay)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemYCCHDB in db.YeuCauCHDBs
                                where itemYCCHDB.CreateDate.Value.Date==TuNgay.Date
                                orderby itemYCCHDB.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemYCCHDB.PhieuDuocKy,
                                    SoPhieu = itemYCCHDB.MaYCCHDB,
                                    Ma = itemYCCHDB.MaYCCHDB,
                                    itemYCCHDB.CreateDate,
                                    itemYCCHDB.DanhBo,
                                    itemYCCHDB.HoTen,
                                    itemYCCHDB.DiaChi,
                                    itemYCCHDB.LyDo,
                                    itemYCCHDB.GhiChuLyDo,
                                    itemYCCHDB.SoTien,
                                    itemYCCHDB.NguoiKy,
                                    itemYCCHDB.NgayCatTamNutBit,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LoadDSYCCHDBByDates(DateTime TuNgay,DateTime DenNgay)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemYCCHDB in db.YeuCauCHDBs
                                where itemYCCHDB.CreateDate.Value.Date>=TuNgay.Date&&itemYCCHDB.CreateDate.Value.Date<=DenNgay.Date
                                orderby itemYCCHDB.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemYCCHDB.PhieuDuocKy,
                                    SoPhieu = itemYCCHDB.MaYCCHDB,
                                    Ma = itemYCCHDB.MaYCCHDB,
                                    itemYCCHDB.CreateDate,
                                    itemYCCHDB.DanhBo,
                                    itemYCCHDB.HoTen,
                                    itemYCCHDB.DiaChi,
                                    itemYCCHDB.LyDo,
                                    itemYCCHDB.GhiChuLyDo,
                                    itemYCCHDB.SoTien,
                                    itemYCCHDB.NguoiKy,
                                    itemYCCHDB.NgayCatTamNutBit,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Danh Sách Yêu Cầu Cắt Hủy Danh Bộ trực tiếp không qua Thông Báo trong Ngày
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <returns></returns>
        public DataTable LoadDSYCCHDB_Don(DateTime TuNgay)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemYCCHDB in db.YeuCauCHDBs
                                where itemYCCHDB.CreateDate.Value.Date==TuNgay.Date //&& (itemYCCHDB.MaDon != null || itemYCCHDB.MaDonTXL != null)
                                select new
                                {
                                    In = false,
                                    itemYCCHDB.PhieuDuocKy,
                                    SoPhieu = itemYCCHDB.MaYCCHDB,
                                    Ma = itemYCCHDB.MaYCCHDB,
                                    itemYCCHDB.CreateDate,
                                    itemYCCHDB.DanhBo,
                                    itemYCCHDB.HoTen,
                                    itemYCCHDB.DiaChi,
                                    itemYCCHDB.LyDo,
                                    itemYCCHDB.GhiChuLyDo,
                                    itemYCCHDB.SoTien,
                                    itemYCCHDB.NguoiKy,
                                    itemYCCHDB.HieuLucKy,
                                    itemYCCHDB.NoiDungXuLy,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Danh Sách Yêu Cầu Cắt Hủy Danh Bộ trực tiếp không qua Thông Báo trong Khoảng Thời Gian
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <returns></returns>
        public DataTable LoadDSYCCHDB_Don(DateTime TuNgay,DateTime DenNgay)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemYCCHDB in db.YeuCauCHDBs
                                where itemYCCHDB.CreateDate.Value.Date >= TuNgay.Date && itemYCCHDB.CreateDate.Value.Date <= DenNgay.Date //&& (itemYCCHDB.MaDon != null || itemYCCHDB.MaDonTXL != null)
                                select new
                                {
                                    In = false,
                                    itemYCCHDB.PhieuDuocKy,
                                    SoPhieu = itemYCCHDB.MaYCCHDB,
                                    Ma = itemYCCHDB.MaYCCHDB,
                                    itemYCCHDB.CreateDate,
                                    itemYCCHDB.DanhBo,
                                    itemYCCHDB.HoTen,
                                    itemYCCHDB.DiaChi,
                                    itemYCCHDB.LyDo,
                                    itemYCCHDB.GhiChuLyDo,
                                    itemYCCHDB.SoTien,
                                    itemYCCHDB.NguoiKy,
                                    itemYCCHDB.HieuLucKy,
                                    itemYCCHDB.NoiDungXuLy,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Danh Sách Yêu Cầu Cắt Hủy Danh Bộ bao gồm qua Thông Báo trong Ngày
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <returns></returns>
        public DataTable LoadDSYCCHDB(DateTime TuNgay)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemYCCHDB in db.YeuCauCHDBs
                                where itemYCCHDB.CreateDate.Value.Date == TuNgay.Date
                                select new
                                {
                                    In = false,
                                    itemYCCHDB.PhieuDuocKy,
                                    SoPhieu = itemYCCHDB.MaYCCHDB,
                                    Ma = itemYCCHDB.MaYCCHDB,
                                    itemYCCHDB.CreateDate,
                                    itemYCCHDB.DanhBo,
                                    itemYCCHDB.HoTen,
                                    itemYCCHDB.DiaChi,
                                    itemYCCHDB.LyDo,
                                    itemYCCHDB.GhiChuLyDo,
                                    itemYCCHDB.SoTien,
                                    itemYCCHDB.NguoiKy,
                                    itemYCCHDB.HieuLucKy,
                                    itemYCCHDB.NgayCatTamNutBit,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Danh Sách Yêu Cầu Cắt Hủy Danh Bộ bao gồm qua Thông Báo trong Ngày
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <returns></returns>
        public DataTable LoadDSYCCHDB(DateTime TuNgay, DateTime DenNgay)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_Xem || CTaiKhoan.RoleCHDB_CapNhat)
                {
                    var query = from itemYCCHDB in db.YeuCauCHDBs
                                where itemYCCHDB.CreateDate.Value.Date >= TuNgay.Date && itemYCCHDB.CreateDate.Value.Date <= DenNgay.Date
                                select new
                                {
                                    In = false,
                                    itemYCCHDB.PhieuDuocKy,
                                    SoPhieu = itemYCCHDB.MaYCCHDB,
                                    Ma = itemYCCHDB.MaYCCHDB,
                                    itemYCCHDB.CreateDate,
                                    itemYCCHDB.DanhBo,
                                    itemYCCHDB.HoTen,
                                    itemYCCHDB.DiaChi,
                                    itemYCCHDB.LyDo,
                                    itemYCCHDB.GhiChuLyDo,
                                    itemYCCHDB.SoTien,
                                    itemYCCHDB.NguoiKy,
                                    itemYCCHDB.HieuLucKy,
                                    itemYCCHDB.NgayCatTamNutBit,
                                };
                    return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        #endregion

        #region LichSuXuLy (Lịch Sử Xử Lý)

        public bool ThemLichSuXuLy(LichSuXuLyCTCHDB lsxl)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_CapNhat)
                {
                    if (db.LichSuXuLyCTCHDBs.Count() > 0)
                    {
                        string ID = "MaLSXuLy";
                        string Table = "LichSuXuLyCTCHDB";
                        decimal MaCHDB = db.ExecuteQuery<decimal>("declare @Ma int " +
                            "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                            "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                        //decimal MaCHDB = db.CHDBs.Max(itemCHDB => itemCHDB.MaCHDB);
                        lsxl.MaLSXuLy = getMaxNextIDTable(MaCHDB);
                    }
                    else
                        lsxl.MaLSXuLy = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    lsxl.CreateDate = DateTime.Now;
                    lsxl.CreateBy = CTaiKhoan.MaUser;
                    db.LichSuXuLyCTCHDBs.InsertOnSubmit(lsxl);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Thêm CHDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.LichSuXuLyCTCHDBs);
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool SuaLichSuXuLy(LichSuXuLyCTCHDB lsxl)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_CapNhat)
                {

                    lsxl.ModifyDate = DateTime.Now;
                    lsxl.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa CHDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.LichSuXuLyCTCHDBs);
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public bool XoaLichSuXuLy(LichSuXuLyCTCHDB lsxl)
        {
            try
            {
                if (CTaiKhoan.RoleCHDB_CapNhat)
                {

                    db.LichSuXuLyCTCHDBs.DeleteOnSubmit(lsxl);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa CHDB", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.LichSuXuLyCTCHDBs);
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db = new DB_KTKS_DonKHDataContext();
                return false;
            }
        }

        public List<LichSuXuLyCTCHDB> LoadDSLichSuXuLyByMaCTCTDB(decimal MaCTCTDB)
        {
            return db.LichSuXuLyCTCHDBs.Where(item => item.MaCTCTDB == MaCTCTDB).ToList();
        }

        public List<LichSuXuLyCTCHDB> LoadDSLichSuXuLyByMaCTCHDB(decimal MaCTCHDB)
        {
            return db.LichSuXuLyCTCHDBs.Where(item => item.MaCTCHDB == MaCTCHDB).ToList();
        }

        public LichSuXuLyCTCHDB GetLichSuXyLyByID(decimal MaLSXuLy)
        {
            return db.LichSuXuLyCTCHDBs.SingleOrDefault(item => item.MaLSXuLy == MaLSXuLy);
        }

        public DataTable GetDSNoiDungLichSuXyLy()
        {
            return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(db.LichSuXuLyCTCHDBs.Select(item => new { item.NoiDung }).ToList().Distinct());
        }

        public DataTable GetDSNoiNhanXuLyLichSuXyLy()
        {
            return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(db.LichSuXuLyCTCHDBs.Select(item => new { item.NoiNhan }).ToList().Distinct());
        }

        #endregion
    }
}
