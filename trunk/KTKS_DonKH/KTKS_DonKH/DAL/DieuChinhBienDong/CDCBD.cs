using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KTKS_DonKH.DAL.HeThong;
using System.Windows.Forms;

namespace KTKS_DonKH.DAL.DieuChinhBienDong
{
    class CDCBD : CDAL
    {
        //public DataTable LoadDSKTXMDaDuyet()
        //{
        //    try
        //    {
        //        if (CTaiKhoan.RoleDCBD)
        //        {
        //            DataSet ds = new DataSet();
        //            var query = from itemDCBD in db.DCBDs
        //                        join itemDonKH in db.DonKHs on itemDCBD.MaDCBD equals itemDonKH.MaDon
        //                        join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
        //                        select new
        //                        {
        //                            itemDonKH.MaDon,
        //                            itemLoaiDon.TenLD,
        //                            itemDonKH.CreateDate,
        //                            itemDonKH.DanhBo,
        //                            itemDonKH.HoTen,
        //                            itemDonKH.DiaChi,
        //                            itemDonKH.NoiDung,
        //                            NoiChuyenDen = itemDCBD.NoiChuyenDen,
        //                            LyDoChuyenDen = itemDCBD.LyDoChuyen,
        //                            itemDCBD.MaDCBD,
        //                            NgayXuLy = itemDCBD.CreateDate,
        //                            itemDCBD.KetQua,
        //                            itemDCBD.MaChuyen,
        //                            LyDoChuyenDi = itemDCBD.LyDoChuyen
        //                        };
        //            return KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);

        //        }
        //        else
        //        {
        //            MessageBox.Show("Tài khoản này không có quyền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return null;
        //    }
        //}

        public DataSet LoadDSKTXMDaDuyet()
        {
            DataSet ds = new DataSet();
            try
            {
                if (CTaiKhoan.RoleDCBD)
                {
                    
                    var query = from itemDCBD in db.DCBDs
                                join itemDonKH in db.DonKHs on itemDCBD.MaDCBD equals itemDonKH.MaDon
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
                                    NoiChuyenDen = itemDCBD.NoiChuyenDen,
                                    LyDoChuyenDen = itemDCBD.LyDoChuyen,
                                    itemDCBD.MaDCBD,
                                    NgayXuLy = itemDCBD.CreateDate,
                                    itemDCBD.KetQua,
                                    itemDCBD.MaChuyen,
                                    LyDoChuyenDi = itemDCBD.LyDoChuyen
                                };
                    DataTable dtDCBD = new DataTable();
                    dtDCBD = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query);
                    dtDCBD.TableName = "DCBD";
                    if (dtDCBD.Rows.Count <= 0)
                    {
                        dtDCBD.Columns.Add("MaDon", typeof(String));
                        dtDCBD.Columns.Add("TenLD", typeof(String));
                        dtDCBD.Columns.Add("CreateDate", typeof(String));
                        dtDCBD.Columns.Add("DanhBo", typeof(String));
                        dtDCBD.Columns.Add("HoTen", typeof(String));
                        dtDCBD.Columns.Add("DiaChi", typeof(String));
                        dtDCBD.Columns.Add("NoiDung", typeof(String));
                        dtDCBD.Columns.Add("NoiChuyenDen", typeof(String));
                        dtDCBD.Columns.Add("LyDoChuyenDen", typeof(String));
                        dtDCBD.Columns.Add("MaDCBD", typeof(String));
                        dtDCBD.Columns.Add("NgayXuLy", typeof(String));
                        dtDCBD.Columns.Add("KetQua", typeof(String));
                        dtDCBD.Columns.Add("MaChuyen", typeof(String));
                        dtDCBD.Columns.Add("LyDoChuyenDi", typeof(String));

                        DataRow row = dtDCBD.NewRow();
                        row["MaDon"] = "a";
                        row["TenLD"] = "a";
                        row["CreateDate"] = "a";
                        row["DanhBo"] = "a";
                        row["HoTen"] = "a";
                        row["DiaChi"] = "a";
                        row["NoiDung"] = "a";
                        row["NoiChuyenDen"] = "a";
                        row["LyDoChuyenDen"] = "a";
                        row["MaDCBD"] = "0";
                        row["NgayXuLy"] = "a";
                        row["KetQua"] = "a";
                        row["MaChuyen"] = "a";
                        row["LyDoChuyenDi"] = "a";
                        dtDCBD.Rows.Add(row);
                    }
                    ds.Tables.Add(dtDCBD);

                    var query2 = from itemCTDCBD in db.CTDCBDs
                                 select itemCTDCBD;         

                    DataTable dtCTDCBD = new DataTable();
                    dtCTDCBD = KTKS_DonKH.Function.CLinQToDataTable.LINQToDataTable(query2);
                    dtCTDCBD.TableName = "CTDCBD";
                    if (dtCTDCBD.Rows.Count <= 0)
                    {
                        dtCTDCBD.Columns.Add("MaCTDCBD", typeof(String));
                        dtCTDCBD.Columns.Add("DanhBo", typeof(String));
                        dtCTDCBD.Columns.Add("DinhMuc", typeof(String));
                        dtCTDCBD.Columns.Add("DinhMuc_BD", typeof(String));
                        dtCTDCBD.Columns.Add("MaDCBD", typeof(String));

                        DataRow row = dtCTDCBD.NewRow();
                        row["MaCTDCBD"] = "a";
                        row["DanhBo"] = "a";
                        row["DinhMuc"] = "a";
                        row["DinhMuc_BD"] = "a";
                        row["MaDCBD"] = "0";
                    }
                    ds.Tables.Add(dtCTDCBD);

                    ds.Relations.Add("Chi Tiết", ds.Tables["DCBD"].Columns["MaDCBD"], ds.Tables["CTDCBD"].Columns["MaDCBD"]);
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

        public DataTable LoadDSKTXMChuaDuyet()
        {
            try
            {
                if (CTaiKhoan.RoleDCBD)
                {
                    ///Bảng DonKH
                    var query1 = from itemDonKH in db.DonKHs
                                 join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                 where itemDonKH.Nhan == false && itemDonKH.MaChuyen == "DCBD"
                                 select new
                                 {
                                     itemDonKH.MaDon,
                                     itemLoaiDon.TenLD,
                                     itemDonKH.CreateDate,
                                     itemDonKH.DanhBo,
                                     itemDonKH.HoTen,
                                     itemDonKH.DiaChi,
                                     itemDonKH.NoiDung,
                                     NoiChuyenDen = "Khách Hàng",
                                     LyDoChuyenDen = itemDonKH.LyDoChuyen,
                                     MaDCBD = "",
                                     NgayXuLy = "",
                                     KetQua = "",
                                     MaChuyen = "",
                                     LyDoChuyenDi = ""
                                 };
                    ///Bảng KTXM
                    var query2 = from itemKTXM in db.KTXMs
                                 join itemDonKH in db.DonKHs on itemKTXM.MaKTXM equals itemDonKH.MaDon
                                 join itemLoaiDon in db.LoaiDons on itemDonKH.MaLD equals itemLoaiDon.MaLD
                                 where itemKTXM.Nhan == false && itemKTXM.MaChuyen == "DCBD"
                                 select new
                                 {
                                     itemDonKH.MaDon,
                                     itemLoaiDon.TenLD,
                                     itemDonKH.CreateDate,
                                     itemDonKH.DanhBo,
                                     itemDonKH.HoTen,
                                     itemDonKH.DiaChi,
                                     itemDonKH.NoiDung,
                                     NoiChuyenDen = "Kiểm Tra Xác Minh",
                                     LyDoChuyenDen = itemKTXM.LyDoChuyen,
                                     MaDCBD = "",
                                     NgayXuLy = "",
                                     KetQua = "",
                                     MaChuyen = "",
                                     LyDoChuyenDi = ""
                                 };
                    var query = query1.Union(query2);
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
    }
}
