using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KTKS_DonKH.DAL.HeThong;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.DAL.ThaoThuTraLoi
{
    class CTTTL : CDAL
    {
        ///Chứa hàm truy xuất dữ liệu từ bảng TTTL & CTTTL

        #region TTTL (Thảo Thư Trả Lời)

        public DataSet LoadDSTTTLDaDuyet()
        {
            try
            {
                if (CTaiKhoan.RoleTTTL_Xem||CTaiKhoan.RoleTTTL_CapNhat)
                {
                    DataSet ds = new DataSet();
                    ///Table TTTL
                    var queryTTTL_DonKH = from itemTTTL in db.TTTLs
                                    //join itemDonKH in db.DonKHs on itemTTTL.MaDon equals itemDonKH.MaDon
                                    //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                    where itemTTTL.ToXuLy==false
                                    orderby itemTTTL.CreateDate descending
                                    select new
                                    {
                                        itemTTTL.ToXuLy,
                                        itemTTTL.MaDon,
                                        itemTTTL.DonKH.LoaiDon.TenLD,
                                        itemTTTL.DonKH.CreateDate,
                                        itemTTTL.DonKH.DanhBo,
                                        itemTTTL.DonKH.HoTen,
                                        itemTTTL.DonKH.DiaChi,
                                        itemTTTL.DonKH.NoiDung,
                                        MaNoiChuyenDen = itemTTTL.MaNoiChuyenDen,
                                        NoiChuyenDen = itemTTTL.NoiChuyenDen,
                                        LyDoChuyenDen = itemTTTL.LyDoChuyenDen,
                                        itemTTTL.MaTTTL,
                                        NgayXuLy = itemTTTL.CreateDate,
                                        itemTTTL.KetQua,
                                        itemTTTL.MaChuyen,
                                        LyDoChuyenDi = itemTTTL.LyDoChuyen
                                    };

                    var queryTTTL_DonTXL = from itemTTTL in db.TTTLs
                                    //join itemDonKH in db.DonKHs on itemTTTL.MaDon equals itemDonKH.MaDon
                                    //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                    where itemTTTL.ToXuLy == true
                                    orderby itemTTTL.CreateDate descending
                                    select new
                                    {
                                        itemTTTL.ToXuLy,
                                        itemTTTL.MaDonTXL,
                                        itemTTTL.DonTXL.LoaiDonTXL.TenLD,
                                        itemTTTL.DonTXL.CreateDate,
                                        itemTTTL.DonTXL.DanhBo,
                                        itemTTTL.DonTXL.HoTen,
                                        itemTTTL.DonTXL.DiaChi,
                                        itemTTTL.DonTXL.NoiDung,
                                        MaNoiChuyenDen = itemTTTL.MaNoiChuyenDen,
                                        NoiChuyenDen = itemTTTL.NoiChuyenDen,
                                        LyDoChuyenDen = itemTTTL.LyDoChuyenDen,
                                        itemTTTL.MaTTTL,
                                        NgayXuLy = itemTTTL.CreateDate,
                                        itemTTTL.KetQua,
                                        itemTTTL.MaChuyen,
                                        LyDoChuyenDi = itemTTTL.LyDoChuyen
                                    };
                    DataTable dtTTTL = new DataTable();
                    dtTTTL = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryTTTL_DonKH);
                    dtTTTL.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryTTTL_DonTXL));
                    dtTTTL.TableName = "TTTL";
                    ds.Tables.Add(dtTTTL);

                    ///Table CTTTTL
                    var queryCTTTTL = from itemCTTTTL in db.CTTTTLs
                                      //where itemCTTTTL.TTTL.MaDon!=null
                                      select itemCTTTTL;

                    DataTable dtCTTTTL = new DataTable();
                    dtCTTTTL = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTTTTL);
                    dtCTTTTL.TableName = "CTTTTL";
                    ds.Tables.Add(dtCTTTTL);

                    if (dtTTTL.Rows.Count > 0 && dtCTTTTL.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời", ds.Tables["TTTL"].Columns["MaTTTL"], ds.Tables["CTTTTL"].Columns["MaTTTL"]);
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

        public DataSet LoadDSTTTLDaDuyetByMaDon(decimal MaDon)
        {
            try
            {
                if (CTaiKhoan.RoleTTTL_Xem || CTaiKhoan.RoleTTTL_CapNhat)
                {
                    DataSet ds = new DataSet();
                    ///Table TTTL
                    var queryTTTL_DonKH = from itemTTTL in db.TTTLs
                                          //join itemDonKH in db.DonKHs on itemTTTL.MaDon equals itemDonKH.MaDon
                                          //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                          where itemTTTL.ToXuLy == false && itemTTTL.MaDon==MaDon
                                          orderby itemTTTL.CreateDate descending
                                          select new
                                          {
                                              itemTTTL.ToXuLy,
                                              itemTTTL.MaDon,
                                              itemTTTL.DonKH.LoaiDon.TenLD,
                                              itemTTTL.DonKH.CreateDate,
                                              itemTTTL.DonKH.DanhBo,
                                              itemTTTL.DonKH.HoTen,
                                              itemTTTL.DonKH.DiaChi,
                                              itemTTTL.DonKH.NoiDung,
                                              MaNoiChuyenDen = itemTTTL.MaNoiChuyenDen,
                                              NoiChuyenDen = itemTTTL.NoiChuyenDen,
                                              LyDoChuyenDen = itemTTTL.LyDoChuyenDen,
                                              itemTTTL.MaTTTL,
                                              NgayXuLy = itemTTTL.CreateDate,
                                              itemTTTL.KetQua,
                                              itemTTTL.MaChuyen,
                                              LyDoChuyenDi = itemTTTL.LyDoChuyen
                                          };

                    var queryTTTL_DonTXL = from itemTTTL in db.TTTLs
                                           //join itemDonKH in db.DonKHs on itemTTTL.MaDon equals itemDonKH.MaDon
                                           //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                           where itemTTTL.ToXuLy == true && itemTTTL.MaDonTXL == MaDon
                                           orderby itemTTTL.CreateDate descending
                                           select new
                                           {
                                               itemTTTL.ToXuLy,
                                               itemTTTL.MaDonTXL,
                                               itemTTTL.DonTXL.LoaiDonTXL.TenLD,
                                               itemTTTL.DonTXL.CreateDate,
                                               itemTTTL.DonTXL.DanhBo,
                                               itemTTTL.DonTXL.HoTen,
                                               itemTTTL.DonTXL.DiaChi,
                                               itemTTTL.DonTXL.NoiDung,
                                               MaNoiChuyenDen = itemTTTL.MaNoiChuyenDen,
                                               NoiChuyenDen = itemTTTL.NoiChuyenDen,
                                               LyDoChuyenDen = itemTTTL.LyDoChuyenDen,
                                               itemTTTL.MaTTTL,
                                               NgayXuLy = itemTTTL.CreateDate,
                                               itemTTTL.KetQua,
                                               itemTTTL.MaChuyen,
                                               LyDoChuyenDi = itemTTTL.LyDoChuyen
                                           };
                    DataTable dtTTTL = new DataTable();
                    dtTTTL = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryTTTL_DonKH.Distinct());
                    dtTTTL.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryTTTL_DonTXL.Distinct()));
                    dtTTTL.TableName = "TTTL";
                    ds.Tables.Add(dtTTTL);

                    ///Table CTTTTL
                    var queryCTTTTL = from itemCTTTTL in db.CTTTTLs
                                      where itemCTTTTL.TTTL.MaDon==MaDon || itemCTTTTL.TTTL.MaDonTXL==MaDon
                                      select itemCTTTTL;

                    DataTable dtCTTTTL = new DataTable();
                    dtCTTTTL = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTTTTL);
                    dtCTTTTL.TableName = "CTTTTL";
                    ds.Tables.Add(dtCTTTTL);

                    if (dtTTTL.Rows.Count > 0 && dtCTTTTL.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời", ds.Tables["TTTL"].Columns["MaTTTL"], ds.Tables["CTTTTL"].Columns["MaTTTL"]);
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

        public DataSet LoadDSTTTLDaDuyetByMaTB(decimal MaCTTTTL)
        {
            try
            {
                if (CTaiKhoan.RoleTTTL_Xem || CTaiKhoan.RoleTTTL_CapNhat)
                {
                    DataSet ds = new DataSet();
                    ///Table TTTL
                    var queryTTTL_DonKH = from itemTTTL in db.TTTLs
                                          //join itemDonKH in db.DonKHs on itemTTTL.MaDon equals itemDonKH.MaDon
                                          //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                          join itemCTTTTL in db.CTTTTLs on itemTTTL.MaTTTL equals itemCTTTTL.MaTTTL
                                          where itemTTTL.ToXuLy == false && itemCTTTTL.MaCTTTTL==MaCTTTTL
                                          orderby itemTTTL.CreateDate descending
                                          select new
                                          {
                                              itemTTTL.ToXuLy,
                                              itemTTTL.MaDon,
                                              itemTTTL.DonKH.LoaiDon.TenLD,
                                              itemTTTL.DonKH.CreateDate,
                                              itemTTTL.DonKH.DanhBo,
                                              itemTTTL.DonKH.HoTen,
                                              itemTTTL.DonKH.DiaChi,
                                              itemTTTL.DonKH.NoiDung,
                                              MaNoiChuyenDen = itemTTTL.MaNoiChuyenDen,
                                              NoiChuyenDen = itemTTTL.NoiChuyenDen,
                                              LyDoChuyenDen = itemTTTL.LyDoChuyenDen,
                                              itemTTTL.MaTTTL,
                                              NgayXuLy = itemTTTL.CreateDate,
                                              itemTTTL.KetQua,
                                              itemTTTL.MaChuyen,
                                              LyDoChuyenDi = itemTTTL.LyDoChuyen
                                          };

                    var queryTTTL_DonTXL = from itemTTTL in db.TTTLs
                                           //join itemDonKH in db.DonKHs on itemTTTL.MaDon equals itemDonKH.MaDon
                                           //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                           join itemCTTTTL in db.CTTTTLs on itemTTTL.MaTTTL equals itemCTTTTL.MaTTTL
                                           where itemTTTL.ToXuLy == true && itemCTTTTL.MaCTTTTL == MaCTTTTL
                                           orderby itemTTTL.CreateDate descending
                                           select new
                                           {
                                               itemTTTL.ToXuLy,
                                               itemTTTL.MaDonTXL,
                                               itemTTTL.DonTXL.LoaiDonTXL.TenLD,
                                               itemTTTL.DonTXL.CreateDate,
                                               itemTTTL.DonTXL.DanhBo,
                                               itemTTTL.DonTXL.HoTen,
                                               itemTTTL.DonTXL.DiaChi,
                                               itemTTTL.DonTXL.NoiDung,
                                               MaNoiChuyenDen = itemTTTL.MaNoiChuyenDen,
                                               NoiChuyenDen = itemTTTL.NoiChuyenDen,
                                               LyDoChuyenDen = itemTTTL.LyDoChuyenDen,
                                               itemTTTL.MaTTTL,
                                               NgayXuLy = itemTTTL.CreateDate,
                                               itemTTTL.KetQua,
                                               itemTTTL.MaChuyen,
                                               LyDoChuyenDi = itemTTTL.LyDoChuyen
                                           };
                    DataTable dtTTTL = new DataTable();
                    dtTTTL = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryTTTL_DonKH.Distinct());
                    dtTTTL.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryTTTL_DonTXL.Distinct()));
                    dtTTTL.TableName = "TTTL";
                    ds.Tables.Add(dtTTTL);

                    ///Table CTTTTL
                    var queryCTTTTL = from itemCTTTTL in db.CTTTTLs
                                      where itemCTTTTL.MaCTTTTL==MaCTTTTL
                                      select itemCTTTTL;

                    DataTable dtCTTTTL = new DataTable();
                    dtCTTTTL = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTTTTL);
                    dtCTTTTL.TableName = "CTTTTL";
                    ds.Tables.Add(dtCTTTTL);

                    if (dtTTTL.Rows.Count > 0 && dtCTTTTL.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời", ds.Tables["TTTL"].Columns["MaTTTL"], ds.Tables["CTTTTL"].Columns["MaTTTL"]);
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

        public DataSet LoadDSTTTLDaDuyetByDanhBo(string DanhBo)
        {
            try
            {
                if (CTaiKhoan.RoleTTTL_Xem || CTaiKhoan.RoleTTTL_CapNhat)
                {
                    DataSet ds = new DataSet();
                    ///Table TTTL
                    var queryTTTL_DonKH = from itemTTTL in db.TTTLs
                                          //join itemDonKH in db.DonKHs on itemTTTL.MaDon equals itemDonKH.MaDon
                                          //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                          join itemCTTTTL in db.CTTTTLs on itemTTTL.MaTTTL equals itemCTTTTL.MaTTTL
                                          where itemTTTL.ToXuLy == false && itemCTTTTL.DanhBo==DanhBo
                                          orderby itemTTTL.CreateDate descending
                                          select new
                                          {
                                              itemTTTL.ToXuLy,
                                              itemTTTL.MaDon,
                                              itemTTTL.DonKH.LoaiDon.TenLD,
                                              itemTTTL.DonKH.CreateDate,
                                              itemTTTL.DonKH.DanhBo,
                                              itemTTTL.DonKH.HoTen,
                                              itemTTTL.DonKH.DiaChi,
                                              itemTTTL.DonKH.NoiDung,
                                              MaNoiChuyenDen = itemTTTL.MaNoiChuyenDen,
                                              NoiChuyenDen = itemTTTL.NoiChuyenDen,
                                              LyDoChuyenDen = itemTTTL.LyDoChuyenDen,
                                              itemTTTL.MaTTTL,
                                              NgayXuLy = itemTTTL.CreateDate,
                                              itemTTTL.KetQua,
                                              itemTTTL.MaChuyen,
                                              LyDoChuyenDi = itemTTTL.LyDoChuyen
                                          };

                    var queryTTTL_DonTXL = from itemTTTL in db.TTTLs
                                           //join itemDonKH in db.DonKHs on itemTTTL.MaDon equals itemDonKH.MaDon
                                           //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                           join itemCTTTTL in db.CTTTTLs on itemTTTL.MaTTTL equals itemCTTTTL.MaTTTL
                                           where itemTTTL.ToXuLy == true && itemCTTTTL.DanhBo == DanhBo
                                           orderby itemTTTL.CreateDate descending
                                           select new
                                           {
                                               itemTTTL.ToXuLy,
                                               itemTTTL.MaDonTXL,
                                               itemTTTL.DonTXL.LoaiDonTXL.TenLD,
                                               itemTTTL.DonTXL.CreateDate,
                                               itemTTTL.DonTXL.DanhBo,
                                               itemTTTL.DonTXL.HoTen,
                                               itemTTTL.DonTXL.DiaChi,
                                               itemTTTL.DonTXL.NoiDung,
                                               MaNoiChuyenDen = itemTTTL.MaNoiChuyenDen,
                                               NoiChuyenDen = itemTTTL.NoiChuyenDen,
                                               LyDoChuyenDen = itemTTTL.LyDoChuyenDen,
                                               itemTTTL.MaTTTL,
                                               NgayXuLy = itemTTTL.CreateDate,
                                               itemTTTL.KetQua,
                                               itemTTTL.MaChuyen,
                                               LyDoChuyenDi = itemTTTL.LyDoChuyen
                                           };
                    DataTable dtTTTL = new DataTable();
                    dtTTTL = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryTTTL_DonKH.Distinct());
                    dtTTTL.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryTTTL_DonTXL.Distinct()));
                    dtTTTL.TableName = "TTTL";
                    ds.Tables.Add(dtTTTL);

                    ///Table CTTTTL
                    var queryCTTTTL = from itemCTTTTL in db.CTTTTLs
                                      where itemCTTTTL.DanhBo==DanhBo
                                      select itemCTTTTL;

                    DataTable dtCTTTTL = new DataTable();
                    dtCTTTTL = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTTTTL);
                    dtCTTTTL.TableName = "CTTTTL";
                    ds.Tables.Add(dtCTTTTL);

                    if (dtTTTL.Rows.Count > 0 && dtCTTTTL.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời", ds.Tables["TTTL"].Columns["MaTTTL"], ds.Tables["CTTTTL"].Columns["MaTTTL"]);
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

        public DataSet LoadDSTTTLDaDuyetByDate(DateTime TuNgay)
        {
            try
            {
                if (CTaiKhoan.RoleTTTL_Xem || CTaiKhoan.RoleTTTL_CapNhat)
                {
                    DataSet ds = new DataSet();
                    ///Table TTTL
                    var queryTTTL_DonKH = from itemTTTL in db.TTTLs
                                          //join itemDonKH in db.DonKHs on itemTTTL.MaDon equals itemDonKH.MaDon
                                          //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                          join itemCTTTTL in db.CTTTTLs on itemTTTL.MaTTTL equals itemCTTTTL.MaTTTL
                                          where itemTTTL.ToXuLy == false&& itemCTTTTL.CreateDate.Value.Date==TuNgay.Date
                                          orderby itemTTTL.CreateDate descending
                                          select new
                                          {
                                              itemTTTL.ToXuLy,
                                              itemTTTL.MaDon,
                                              itemTTTL.DonKH.LoaiDon.TenLD,
                                              itemTTTL.DonKH.CreateDate,
                                              itemTTTL.DonKH.DanhBo,
                                              itemTTTL.DonKH.HoTen,
                                              itemTTTL.DonKH.DiaChi,
                                              itemTTTL.DonKH.NoiDung,
                                              MaNoiChuyenDen = itemTTTL.MaNoiChuyenDen,
                                              NoiChuyenDen = itemTTTL.NoiChuyenDen,
                                              LyDoChuyenDen = itemTTTL.LyDoChuyenDen,
                                              itemTTTL.MaTTTL,
                                              NgayXuLy = itemTTTL.CreateDate,
                                              itemTTTL.KetQua,
                                              itemTTTL.MaChuyen,
                                              LyDoChuyenDi = itemTTTL.LyDoChuyen
                                          };

                    var queryTTTL_DonTXL = from itemTTTL in db.TTTLs
                                           //join itemDonKH in db.DonKHs on itemTTTL.MaDon equals itemDonKH.MaDon
                                           //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                           join itemCTTTTL in db.CTTTTLs on itemTTTL.MaTTTL equals itemCTTTTL.MaTTTL
                                           where itemTTTL.ToXuLy == true && itemCTTTTL.CreateDate.Value.Date == TuNgay.Date
                                           orderby itemTTTL.CreateDate descending
                                           select new
                                           {
                                               itemTTTL.ToXuLy,
                                               itemTTTL.MaDonTXL,
                                               itemTTTL.DonTXL.LoaiDonTXL.TenLD,
                                               itemTTTL.DonTXL.CreateDate,
                                               itemTTTL.DonTXL.DanhBo,
                                               itemTTTL.DonTXL.HoTen,
                                               itemTTTL.DonTXL.DiaChi,
                                               itemTTTL.DonTXL.NoiDung,
                                               MaNoiChuyenDen = itemTTTL.MaNoiChuyenDen,
                                               NoiChuyenDen = itemTTTL.NoiChuyenDen,
                                               LyDoChuyenDen = itemTTTL.LyDoChuyenDen,
                                               itemTTTL.MaTTTL,
                                               NgayXuLy = itemTTTL.CreateDate,
                                               itemTTTL.KetQua,
                                               itemTTTL.MaChuyen,
                                               LyDoChuyenDi = itemTTTL.LyDoChuyen
                                           };
                    DataTable dtTTTL = new DataTable();
                    dtTTTL = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryTTTL_DonKH.Distinct());
                    dtTTTL.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryTTTL_DonTXL.Distinct()));
                    dtTTTL.TableName = "TTTL";
                    ds.Tables.Add(dtTTTL);

                    ///Table CTTTTL
                    var queryCTTTTL = from itemCTTTTL in db.CTTTTLs
                                      where itemCTTTTL.CreateDate.Value.Date == TuNgay.Date
                                      select itemCTTTTL;

                    DataTable dtCTTTTL = new DataTable();
                    dtCTTTTL = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTTTTL);
                    dtCTTTTL.TableName = "CTTTTL";
                    ds.Tables.Add(dtCTTTTL);

                    if (dtTTTL.Rows.Count > 0 && dtCTTTTL.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời", ds.Tables["TTTL"].Columns["MaTTTL"], ds.Tables["CTTTTL"].Columns["MaTTTL"]);
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

        public DataSet LoadDSTTTLDaDuyetByDates(DateTime TuNgay,DateTime DenNgay)
        {
            try
            {
                if (CTaiKhoan.RoleTTTL_Xem || CTaiKhoan.RoleTTTL_CapNhat)
                {
                    DataSet ds = new DataSet();
                    ///Table TTTL
                    var queryTTTL_DonKH = from itemTTTL in db.TTTLs
                                          //join itemDonKH in db.DonKHs on itemTTTL.MaDon equals itemDonKH.MaDon
                                          //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                          join itemCTTTTL in db.CTTTTLs on itemTTTL.MaTTTL equals itemCTTTTL.MaTTTL
                                          where itemTTTL.ToXuLy == false && itemCTTTTL.CreateDate.Value.Date>=TuNgay.Date && itemCTTTTL.CreateDate.Value.Date<=DenNgay.Date
                                          orderby itemTTTL.CreateDate descending
                                          select new
                                          {
                                              itemTTTL.ToXuLy,
                                              itemTTTL.MaDon,
                                              itemTTTL.DonKH.LoaiDon.TenLD,
                                              itemTTTL.DonKH.CreateDate,
                                              itemTTTL.DonKH.DanhBo,
                                              itemTTTL.DonKH.HoTen,
                                              itemTTTL.DonKH.DiaChi,
                                              itemTTTL.DonKH.NoiDung,
                                              MaNoiChuyenDen = itemTTTL.MaNoiChuyenDen,
                                              NoiChuyenDen = itemTTTL.NoiChuyenDen,
                                              LyDoChuyenDen = itemTTTL.LyDoChuyenDen,
                                              itemTTTL.MaTTTL,
                                              NgayXuLy = itemTTTL.CreateDate,
                                              itemTTTL.KetQua,
                                              itemTTTL.MaChuyen,
                                              LyDoChuyenDi = itemTTTL.LyDoChuyen
                                          };

                    var queryTTTL_DonTXL = from itemTTTL in db.TTTLs
                                           //join itemDonKH in db.DonKHs on itemTTTL.MaDon equals itemDonKH.MaDon
                                           //join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                           join itemCTTTTL in db.CTTTTLs on itemTTTL.MaTTTL equals itemCTTTTL.MaTTTL
                                           where itemTTTL.ToXuLy == true && itemCTTTTL.CreateDate.Value.Date >= TuNgay.Date && itemCTTTTL.CreateDate.Value.Date <= DenNgay.Date
                                           orderby itemTTTL.CreateDate descending
                                           select new
                                           {
                                               itemTTTL.ToXuLy,
                                               itemTTTL.MaDonTXL,
                                               itemTTTL.DonTXL.LoaiDonTXL.TenLD,
                                               itemTTTL.DonTXL.CreateDate,
                                               itemTTTL.DonTXL.DanhBo,
                                               itemTTTL.DonTXL.HoTen,
                                               itemTTTL.DonTXL.DiaChi,
                                               itemTTTL.DonTXL.NoiDung,
                                               MaNoiChuyenDen = itemTTTL.MaNoiChuyenDen,
                                               NoiChuyenDen = itemTTTL.NoiChuyenDen,
                                               LyDoChuyenDen = itemTTTL.LyDoChuyenDen,
                                               itemTTTL.MaTTTL,
                                               NgayXuLy = itemTTTL.CreateDate,
                                               itemTTTL.KetQua,
                                               itemTTTL.MaChuyen,
                                               LyDoChuyenDi = itemTTTL.LyDoChuyen
                                           };
                    DataTable dtTTTL = new DataTable();
                    dtTTTL = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryTTTL_DonKH.Distinct());
                    dtTTTL.Merge(KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryTTTL_DonTXL.Distinct()));
                    dtTTTL.TableName = "TTTL";
                    ds.Tables.Add(dtTTTL);

                    ///Table CTTTTL
                    var queryCTTTTL = from itemCTTTTL in db.CTTTTLs
                                      where  itemCTTTTL.CreateDate.Value.Date>=TuNgay.Date && itemCTTTTL.CreateDate.Value.Date<=DenNgay.Date
                                      select itemCTTTTL;

                    DataTable dtCTTTTL = new DataTable();
                    dtCTTTTL = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTTTTL);
                    dtCTTTTL.TableName = "CTTTTL";
                    ds.Tables.Add(dtCTTTTL);

                    if (dtTTTL.Rows.Count > 0 && dtCTTTTL.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời", ds.Tables["TTTL"].Columns["MaTTTL"], ds.Tables["CTTTTL"].Columns["MaTTTL"]);
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

        public DataSet LoadDSTTTLDaDuyet_TXL()
        {
            try
            {
                if (CTaiKhoan.RoleTTTL_Xem || CTaiKhoan.RoleTTTL_CapNhat)
                {
                    DataSet ds = new DataSet();
                    ///Table TTTL
                    var queryTTTL = from itemTTTL in db.TTTLs
                                    join itemDonTXL in db.DonTXLs on itemTTTL.MaDonTXL equals itemDonTXL.MaDon
                                    join itemLoaiDonTXL in db.LoaiDonTXLs on itemDonTXL.MaLD equals itemLoaiDonTXL.MaLD
                                    where itemTTTL.MaDonTXL != null
                                    select new
                                    {
                                        itemDonTXL.MaDon,
                                        itemLoaiDonTXL.TenLD,
                                        itemDonTXL.CreateDate,
                                        itemDonTXL.DanhBo,
                                        itemDonTXL.HoTen,
                                        itemDonTXL.DiaChi,
                                        itemDonTXL.NoiDung,
                                        MaNoiChuyenDen = itemTTTL.MaNoiChuyenDen,
                                        NoiChuyenDen = itemTTTL.NoiChuyenDen,
                                        LyDoChuyenDen = itemTTTL.LyDoChuyenDen,
                                        itemTTTL.MaTTTL,
                                        NgayXuLy = itemTTTL.CreateDate,
                                        itemTTTL.KetQua,
                                        itemTTTL.MaChuyen,
                                        LyDoChuyenDi = itemTTTL.LyDoChuyen
                                    };
                    DataTable dtTTTL = new DataTable();
                    dtTTTL = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryTTTL);
                    dtTTTL.TableName = "TTTL";
                    ds.Tables.Add(dtTTTL);

                    ///Table CTTTTL
                    var queryCTTTTL = from itemCTTTTL in db.CTTTTLs
                                      where itemCTTTTL.TTTL.MaDonTXL != null
                                      select itemCTTTTL;

                    DataTable dtCTTTTL = new DataTable();
                    dtCTTTTL = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTTTTL);
                    dtCTTTTL.TableName = "CTTTTL";
                    ds.Tables.Add(dtCTTTTL);

                    if (dtTTTL.Rows.Count > 0 && dtCTTTTL.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Thảo Thư Trả Lời", ds.Tables["TTTL"].Columns["MaTTTL"], ds.Tables["CTTTTL"].Columns["MaTTTL"]);
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

        public DataTable LoadDSTTTLChuaDuyet()
        {
            try
            {
                if (CTaiKhoan.RoleTTTL_Xem||CTaiKhoan.RoleTTTL_CapNhat)
                {
                    ///Bảng DonKH
                    var queryDonKH = from itemDonKH in db.DonKHs
                                     join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                     where itemDonKH.Nhan == false && itemDonKH.MaChuyen == "TTTL"
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
                                         MaTTTL = "",
                                         NgayXuLy = "",
                                         KetQua = "",
                                         MaChuyen = "",
                                         LyDoChuyenDi = ""
                                     };
                    ///Bảng KTXM
                    var queryKTXM = from itemKTXM in db.KTXMs
                                    join itemDonKH in db.DonKHs on itemKTXM.MaDon equals itemDonKH.MaDon
                                    join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                    where itemKTXM.Nhan == false && itemKTXM.MaChuyen == "TTTL"
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
                                        MaTTTL = "",
                                        NgayXuLy = "",
                                        KetQua = "",
                                        MaChuyen = "",
                                        LyDoChuyenDi = ""
                                    };
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

        public bool ThemTTTL(TTTL tttl)
        {
            try
            {
                if (CTaiKhoan.RoleTTTL_CapNhat)
                {
                    if (db.TTTLs.Count() > 0)
                    {
                        string ID = "MaTTTL";
                        string Table = "TTTL";
                        decimal MaTTTL = db.ExecuteQuery<decimal>("declare @Ma int " +
                            "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                            "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                        //decimal MaTTTL = db.TTTLs.Max(itemTTTL => itemTTTL.MaTTTL);
                        tttl.MaTTTL = getMaxNextIDTable(MaTTTL);
                    }
                    else
                        tttl.MaTTTL = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    tttl.CreateDate = DateTime.Now;
                    tttl.CreateBy = CTaiKhoan.MaUser;
                    db.TTTLs.InsertOnSubmit(tttl);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Thêm TTTL", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.TTTLs);
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

        public bool SuaTTTL(TTTL tttl)
        {
            try
            {
                if (CTaiKhoan.RoleTTTL_CapNhat)
                {

                    tttl.ModifyDate = DateTime.Now;
                    tttl.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa TTTL", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.TTTLs);
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

        public TTTL getTTTLbyID(decimal MaTTTL)
        {
            try
            {
                return db.TTTLs.SingleOrDefault(itemTTTL => itemTTTL.MaTTTL == MaTTTL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy Mã Thảo Thư Trả Lời lớn nhất hiện tại
        /// </summary>
        /// <returns></returns>
        public decimal getMaxMaTTTL()
        {
            try
            {
                return db.TTTLs.Max(itemTTTL => itemTTTL.MaTTTL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        /// <summary>
        /// Kiểm tra Đơn KH có được TTTL xử lý hay chưa
        /// </summary>
        /// <param name="MaDon"></param>
        /// <returns>true/có</returns>
        public bool CheckTTTLbyMaDon(decimal MaDon)
        {
            try
            {
                if (db.TTTLs.Any(itemTTTL => itemTTTL.MaDon == MaDon))
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
        /// Kiểm tra Đơn Tổ Xử Lý có được TTTL xử lý hay chưa
        /// </summary>
        /// <param name="MaDon"></param>
        /// <returns>true/có</returns>
        public bool CheckTTTLbyMaDon_TXL(decimal MaDonTXL)
        {
            try
            {
                if (db.TTTLs.Any(itemTTTL => itemTTTL.MaDonTXL == MaDonTXL))
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
        /// Lấy TTTL bằng MaDon
        /// </summary>
        /// <param name="MaDon"></param>
        /// <returns></returns>
        public TTTL getTTTLbyMaDon(decimal MaDon)
        {
            try
            {
                return db.TTTLs.SingleOrDefault(itemTTTL => itemTTTL.MaDon == MaDon);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy TTTL bằng MaDon Tổ Xử Lý
        /// </summary>
        /// <param name="MaDon"></param>
        /// <returns></returns>
        public TTTL getTTTLbyMaDon_TXL(decimal MaDonTXL)
        {
            try
            {
                return db.TTTLs.SingleOrDefault(itemTTTL => itemTTTL.MaDonTXL == MaDonTXL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        #endregion

        #region CTTTTL (Chi Tiết Thảo Thư Trả Lời)

        public bool ThemCTTTTL(CTTTTL cttttl)
        {
            try
            {
                if (CTaiKhoan.RoleTTTL_CapNhat)
                {
                    if (db.CTTTTLs.Count() > 0)
                    {
                        string ID = "MaCTTTTL";
                        string Table = "CTTTTL";
                        decimal MaCTTTTL = db.ExecuteQuery<decimal>("declare @Ma int " +
                            "select @Ma=MAX(SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)) from " + Table + " " +
                            "select MAX(" + ID + ") from " + Table + " where SUBSTRING(CONVERT(nvarchar(50)," + ID + "),LEN(CONVERT(nvarchar(50)," + ID + "))-1,2)=@Ma").Single();
                        //decimal MaCTTTTL = db.CTTTTLs.Max(itemCTTTTL => itemCTTTTL.MaCTTTTL);
                        cttttl.MaCTTTTL = getMaxNextIDTable(MaCTTTTL);
                    }
                    else
                        cttttl.MaCTTTTL = decimal.Parse("1" + DateTime.Now.ToString("yy"));
                    cttttl.CreateDate = DateTime.Now;
                    cttttl.CreateBy = CTaiKhoan.MaUser;
                    db.CTTTTLs.InsertOnSubmit(cttttl);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Thêm CTTTTL", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.CTTTTLs);
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

        public bool SuaCTTTTL(CTTTTL cttttl)
        {
            try
            {
                if (CTaiKhoan.RoleTTTL_CapNhat)
                {
                    cttttl.ModifyDate = DateTime.Now;
                    cttttl.ModifyBy = CTaiKhoan.MaUser;
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa CTTTTL", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.CTTTTLs);
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

        public bool XoaCTTTTL(CTTTTL cttttl)
        {
            try
            {
                if (CTaiKhoan.RoleTTTL_CapNhat)
                {
                    db.CTTTTLs.DeleteOnSubmit(cttttl);
                    db.SubmitChanges();
                    //MessageBox.Show("Thành công Sửa CTTTTL", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.CTTTTLs);
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

        public CTTTTL getCTTTTLbyID(decimal MaCTTTTL)
        {
            try
            {
                return db.CTTTTLs.SingleOrDefault(itemCTTTTL => itemCTTTTL.MaCTTTTL == MaCTTTTL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public decimal getMaxMaCTTTTL()
        {
            try
            {
                return db.CTTTTLs.Max(itemCTTTTL => itemCTTTTL.MaCTTTTL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        /// <summary>
        /// Lấy Danh Sách Chi Tiết Thảo Thư Trả Lời
        /// </summary>
        /// <returns></returns>
        public DataTable LoadDSCTTTTL()
        {
            try
            {
                if (CTaiKhoan.RoleTTTL_Xem || CTaiKhoan.RoleTTTL_CapNhat)
                {
                    var query = from itemCTTTTL in db.CTTTTLs
                                //where itemCTTTTL.TTTL.MaDon!=null
                                orderby itemCTTTTL.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemCTTTTL.MaCTTTTL,
                                    Ma = itemCTTTTL.MaCTTTTL,
                                    itemCTTTTL.ThuDuocKy,
                                    itemCTTTTL.DanhBo,
                                    itemCTTTTL.GhiChu,
                                    itemCTTTTL.CreateDate,
                                    itemCTTTTL.VeViec,
                                    itemCTTTTL.NoiDung,
                                    itemCTTTTL.NoiNhan,
                                    itemCTTTTL.NguoiKy,
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

        public DataTable LoadDSCTTTTLByMaDon(decimal MaDon)
        {
            try
            {
                if (CTaiKhoan.RoleTTTL_Xem || CTaiKhoan.RoleTTTL_CapNhat)
                {
                    var query = from itemCTTTTL in db.CTTTTLs
                                where itemCTTTTL.TTTL.MaDon==MaDon || itemCTTTTL.TTTL.MaDonTXL==MaDon
                                orderby itemCTTTTL.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemCTTTTL.MaCTTTTL,
                                    Ma = itemCTTTTL.MaCTTTTL,
                                    itemCTTTTL.ThuDuocKy,
                                    itemCTTTTL.DanhBo,
                                    itemCTTTTL.GhiChu,
                                    itemCTTTTL.CreateDate,
                                    itemCTTTTL.VeViec,
                                    itemCTTTTL.NoiDung,
                                    itemCTTTTL.NoiNhan,
                                    itemCTTTTL.NguoiKy,
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

        public DataTable LoadDSCTTTTLByMaTB(decimal MaCTTTTL)
        {
            try
            {
                if (CTaiKhoan.RoleTTTL_Xem || CTaiKhoan.RoleTTTL_CapNhat)
                {
                    var query = from itemCTTTTL in db.CTTTTLs
                                where itemCTTTTL.MaCTTTTL==MaCTTTTL
                                orderby itemCTTTTL.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemCTTTTL.MaCTTTTL,
                                    Ma = itemCTTTTL.MaCTTTTL,
                                    itemCTTTTL.ThuDuocKy,
                                    itemCTTTTL.DanhBo,
                                    itemCTTTTL.GhiChu,
                                    itemCTTTTL.CreateDate,
                                    itemCTTTTL.VeViec,
                                    itemCTTTTL.NoiDung,
                                    itemCTTTTL.NoiNhan,
                                    itemCTTTTL.NguoiKy,
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

        public DataTable LoadDSCTTTTLByMaTBs(decimal TuMaCTTTTL, decimal DenMaCTTTTL)
        {
            try
            {
                if (CTaiKhoan.RoleTTTL_Xem || CTaiKhoan.RoleTTTL_CapNhat)
                {
                    var query = from itemCTTTTL in db.CTTTTLs
                                where itemCTTTTL.MaCTTTTL.ToString().Substring(itemCTTTTL.MaCTTTTL.ToString().Length - 2, 2) == TuMaCTTTTL.ToString().Substring(TuMaCTTTTL.ToString().Length - 2, 2)
                                && itemCTTTTL.MaCTTTTL.ToString().Substring(itemCTTTTL.MaCTTTTL.ToString().Length - 2, 2) == DenMaCTTTTL.ToString().Substring(DenMaCTTTTL.ToString().Length - 2, 2)
                                && itemCTTTTL.MaCTTTTL >= TuMaCTTTTL && itemCTTTTL.MaCTTTTL <= DenMaCTTTTL
                                orderby itemCTTTTL.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemCTTTTL.MaCTTTTL,
                                    Ma = itemCTTTTL.MaCTTTTL,
                                    itemCTTTTL.ThuDuocKy,
                                    itemCTTTTL.DanhBo,
                                    itemCTTTTL.GhiChu,
                                    itemCTTTTL.CreateDate,
                                    itemCTTTTL.VeViec,
                                    itemCTTTTL.NoiDung,
                                    itemCTTTTL.NoiNhan,
                                    itemCTTTTL.NguoiKy,
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

        public DataTable LoadDSCTTTTLByDanhBo(string DanhBo)
        {
            try
            {
                if (CTaiKhoan.RoleTTTL_Xem || CTaiKhoan.RoleTTTL_CapNhat)
                {
                    var query = from itemCTTTTL in db.CTTTTLs
                                where itemCTTTTL.DanhBo==DanhBo
                                orderby itemCTTTTL.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemCTTTTL.MaCTTTTL,
                                    Ma = itemCTTTTL.MaCTTTTL,
                                    itemCTTTTL.ThuDuocKy,
                                    itemCTTTTL.DanhBo,
                                    itemCTTTTL.GhiChu,
                                    itemCTTTTL.CreateDate,
                                    itemCTTTTL.VeViec,
                                    itemCTTTTL.NoiDung,
                                    itemCTTTTL.NoiNhan,
                                    itemCTTTTL.NguoiKy,
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

        public DataTable LoadDSCTTTTLByDate(DateTime TuNgay)
        {
            try
            {
                if (CTaiKhoan.RoleTTTL_Xem || CTaiKhoan.RoleTTTL_CapNhat)
                {
                    var query = from itemCTTTTL in db.CTTTTLs
                                where itemCTTTTL.CreateDate.Value.Date==TuNgay.Date
                                orderby itemCTTTTL.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemCTTTTL.MaCTTTTL,
                                    Ma = itemCTTTTL.MaCTTTTL,
                                    itemCTTTTL.ThuDuocKy,
                                    itemCTTTTL.DanhBo,
                                    itemCTTTTL.GhiChu,
                                    itemCTTTTL.CreateDate,
                                    itemCTTTTL.VeViec,
                                    itemCTTTTL.NoiDung,
                                    itemCTTTTL.NoiNhan,
                                    itemCTTTTL.NguoiKy,
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

        public DataTable LoadDSCTTTTLByDates(DateTime TuNgay,DateTime DenNgay)
        {
            try
            {
                if (CTaiKhoan.RoleTTTL_Xem || CTaiKhoan.RoleTTTL_CapNhat)
                {
                    var query = from itemCTTTTL in db.CTTTTLs
                                where itemCTTTTL.CreateDate.Value.Date>=TuNgay.Date&&itemCTTTTL.CreateDate.Value.Date<=DenNgay.Date
                                orderby itemCTTTTL.CreateDate descending
                                select new
                                {
                                    In = false,
                                    itemCTTTTL.MaCTTTTL,
                                    Ma = itemCTTTTL.MaCTTTTL,
                                    itemCTTTTL.ThuDuocKy,
                                    itemCTTTTL.DanhBo,
                                    itemCTTTTL.GhiChu,
                                    itemCTTTTL.CreateDate,
                                    itemCTTTTL.VeViec,
                                    itemCTTTTL.NoiDung,
                                    itemCTTTTL.NoiNhan,
                                    itemCTTTTL.NguoiKy,
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
        /// Lấy Danh Sách Chi Tiết Thảo Thư Trả Lời trong Ngày
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <returns></returns>
        public DataTable LoadDSCTTTTL(DateTime TuNgay)
        {
            try
            {
                if (CTaiKhoan.RoleTTTL_Xem || CTaiKhoan.RoleTTTL_CapNhat)
                {
                    var query = from itemCTTTTL in db.CTTTTLs
                                where itemCTTTTL.CreateDate.Value.Date==TuNgay.Date
                                select new
                                {
                                    In = false,
                                    itemCTTTTL.MaCTTTTL,
                                    Ma = itemCTTTTL.MaCTTTTL,
                                    itemCTTTTL.ThuDuocKy,
                                    itemCTTTTL.DanhBo,
                                    itemCTTTTL.GhiChu,
                                    itemCTTTTL.CreateDate,
                                    itemCTTTTL.VeViec,
                                    itemCTTTTL.NoiDung,
                                    itemCTTTTL.NoiNhan,
                                    itemCTTTTL.NguoiKy,
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
        /// Lấy Danh Sách Chi Tiết Thảo Thư Trả Lời trong Khoảng Thời Gian
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <returns></returns>
        public DataTable LoadDSCTTTTL(DateTime TuNgay,DateTime DenNgay)
        {
            try
            {
                if (CTaiKhoan.RoleTTTL_Xem || CTaiKhoan.RoleTTTL_CapNhat)
                {
                    var query = from itemCTTTTL in db.CTTTTLs
                                where itemCTTTTL.CreateDate.Value.Date >= TuNgay.Date && itemCTTTTL.CreateDate.Value.Date <= DenNgay.Date
                                select new
                                {
                                    In = false,
                                    itemCTTTTL.MaCTTTTL,
                                    Ma = itemCTTTTL.MaCTTTTL,
                                    itemCTTTTL.ThuDuocKy,
                                    itemCTTTTL.DanhBo,
                                    itemCTTTTL.GhiChu,
                                    itemCTTTTL.CreateDate,
                                    itemCTTTTL.VeViec,
                                    itemCTTTTL.NoiDung,
                                    itemCTTTTL.NoiNhan,
                                    itemCTTTTL.NguoiKy,
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
        /// Lấy Danh Sách Chi Tiết Thảo Thư Trả Lời Tổ Xử Lý
        /// </summary>
        /// <returns></returns>
        public DataTable LoadDSCTTTTL_TXL()
        {
            try
            {
                if (CTaiKhoan.RoleTTTL_Xem || CTaiKhoan.RoleTTTL_CapNhat)
                {
                    var query = from itemCTTTTL in db.CTTTTLs
                                where itemCTTTTL.TTTL.MaDonTXL != null
                                select new
                                {
                                    In = false,
                                    itemCTTTTL.MaCTTTTL,
                                    itemCTTTTL.ThuDuocKy,
                                    itemCTTTTL.DanhBo,
                                    itemCTTTTL.GhiChu,
                                    itemCTTTTL.CreateDate,
                                    itemCTTTTL.VeViec,
                                    itemCTTTTL.NoiDung,
                                    itemCTTTTL.NoiNhan,
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
        /// Kiểm tra Thư đã được tạo cho Mã Đơn và Danh Bộ này chưa
        /// </summary>
        /// <param name="MaDon"></param>
        /// <param name="DanhBo"></param>
        /// <returns></returns>
        public bool CheckCTTTTLbyMaDonDanhBo(decimal MaDon, string DanhBo, DateTime CreateDate)
        {
            try
            {
                return db.CTTTTLs.Any(itemCTTTTL => itemCTTTTL.TTTL.MaDon == MaDon && itemCTTTTL.DanhBo == DanhBo && itemCTTTTL.CreateDate.Value.Date == CreateDate.Date);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra Thư đã được tạo cho Mã Đơn Tổ Xử Lý và Danh Bộ này chưa
        /// </summary>
        /// <param name="MaDon"></param>
        /// <param name="DanhBo"></param>
        /// <returns></returns>
        public bool CheckCTTTTLbyMaDonDanhBo_TXL(decimal MaDonTXL, string DanhBo,DateTime CreateDate)
        {
            try
            {
                return db.CTTTTLs.Any(itemCTTTTL => itemCTTTTL.TTTL.MaDonTXL == MaDonTXL && itemCTTTTL.DanhBo == DanhBo&&itemCTTTTL.CreateDate.Value.Date==CreateDate.Date);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public DataTable LoadLichSuTTTLbyDanhBo(string DanhBo)
        {
            try
            {
                if (CTaiKhoan.RoleTTTL_Xem || CTaiKhoan.RoleTTTL_CapNhat)
                {
                    var query = from itemCTTTTL in db.CTTTTLs
                                where itemCTTTTL.DanhBo==DanhBo
                                select new
                                {
                                    itemCTTTTL.MaCTTTTL,
                                    itemCTTTTL.TTTL.MaDon,
                                    itemCTTTTL.VeViec,
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
    }
}
