using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KTKS_DonKH.DAL.HeThong;
using System.Windows.Forms;

namespace KTKS_DonKH.DAL.CatHuyDanhBo
{
    class CCHDB : CDAL
    {
        public DataSet LoadDSDCBDDaDuyet()
        {
            try
            {
                if (CTaiKhoan.RoleDCBD)
                {
                    DataSet ds = new DataSet();
                    ///Table DCBD
                    var queryDCBD = from itemDCBD in db.DCBDs
                                    join itemDonKH in db.DonKHs on itemDCBD.MaDon equals itemDonKH.MaDon
                                    join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                    select new
                                    {
                                        itemDonKH.MaDon,
                                        itemLoaiDon.TenLD,
                                        itemDonKH.CreateDate,
                                        itemDonKH.DanhBo,
                                        itemDonKH.HoTen,
                                        itemDonKH.DiaChi,
                                        itemDonKH.NoiDung,
                                        MaNoiChuyenDen = itemDCBD.MaNoiChuyenDen,
                                        NoiChuyenDen = itemDCBD.NoiChuyenDen,
                                        LyDoChuyenDen = itemDCBD.LyDoChuyenDen,
                                        itemDCBD.MaDCBD,
                                        NgayXuLy = itemDCBD.CreateDate,
                                        itemDCBD.KetQua,
                                        itemDCBD.MaChuyen,
                                        LyDoChuyenDi = itemDCBD.LyDoChuyen
                                    };
                    DataTable dtDCBD = new DataTable();
                    dtDCBD = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryDCBD);
                    dtDCBD.TableName = "DCBD";
                    ds.Tables.Add(dtDCBD);

                    ///Table CTDCBD
                    var queryCTDCBD = from itemCTDCBD in db.CTDCBDs
                                      select itemCTDCBD;

                    DataTable dtCTDCBD = new DataTable();
                    dtCTDCBD = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTDCBD);
                    dtCTDCBD.TableName = "CTDCBD";
                    ds.Tables.Add(dtCTDCBD);

                    ///Table CTDCHD
                    var queryCTDCHD = from itemCTDCHD in db.CTDCHDs
                                      select itemCTDCHD;

                    DataTable dtCTDCHD = new DataTable();
                    dtCTDCHD = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(queryCTDCHD);
                    dtCTDCHD.TableName = "CTDCHD";
                    ds.Tables.Add(dtCTDCHD);

                    if (dtDCBD.Rows.Count > 0 && dtCTDCBD.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Điều Chỉnh Biến Động", ds.Tables["DCBD"].Columns["MaDCBD"], ds.Tables["CTDCBD"].Columns["MaDCBD"]);
                    if (dtDCBD.Rows.Count > 0 && dtCTDCHD.Rows.Count > 0)
                        ds.Relations.Add("Chi Tiết Điều Chỉnh Hóa Đơn", ds.Tables["DCBD"].Columns["MaDCBD"], ds.Tables["CTDCHD"].Columns["MaDCBD"]);
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

        public DataTable LoadDSDCBDChuaDuyet()
        {
            try
            {
                if (CTaiKhoan.RoleDCBD)
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
                                         MaDCBD = "",
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
                                        MaDCBD = "",
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
    }
}
