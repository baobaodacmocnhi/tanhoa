﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.DAL.ToKhachHang;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL.ToBamChi;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmNhapNhieuGB : Form
    {
        string _mnu = "mnuDCBD";
        CThuTien _cThuTien = new CThuTien();
        CDocSo _cDocSo = new CDocSo();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        CDCBD _cDCBD = new CDCBD();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CDonTBC _cDonTBC = new CDonTBC();

        public frmNhapNhieuGB()
        {
            InitializeComponent();
        }

        private void frmNhapNhieuGB_Load(object sender, EventArgs e)
        {

        }

        private void dgvDanhBo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDanhBo.Columns[e.ColumnIndex].Name == "MaDon" && dgvDanhBo["MaDon", e.RowIndex].Value != null)
            {
                ///Đơn Tổ Xử Lý
                if (dgvDanhBo["MaDon", e.RowIndex].Value.ToString().ToUpper().Contains("TXL"))
                {
                    DonTXL dontxl = _cDonTXL.Get(decimal.Parse(dgvDanhBo["MaDon", e.RowIndex].Value.ToString().Substring(3).Replace("-", "")));
                    if (dontxl != null)
                    {
                        if (_cThuTien.GetMoiNhat(dontxl.DanhBo) != null)
                        {
                            HOADON hoadon = _cThuTien.GetMoiNhat(dontxl.DanhBo);
                            dgvDanhBo["DanhBo", e.RowIndex].Value = hoadon.DANHBA;
                            dgvDanhBo["HopDong", e.RowIndex].Value = hoadon.HOPDONG;
                            dgvDanhBo["HoTen", e.RowIndex].Value = hoadon.TENKH;
                            dgvDanhBo["DiaChi", e.RowIndex].Value = hoadon.SO + " " + hoadon.DUONG + _cDocSo.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
                            dgvDanhBo["MSThue", e.RowIndex].Value = hoadon.MST;
                            dgvDanhBo["GiaBieu", e.RowIndex].Value = hoadon.GB;
                            dgvDanhBo["DinhMuc", e.RowIndex].Value = hoadon.DM;
                            dgvDanhBo["Dot", e.RowIndex].Value = hoadon.DOT.ToString();
                            dgvDanhBo["Ky", e.RowIndex].Value = hoadon.KY.ToString();
                            dgvDanhBo["Nam", e.RowIndex].Value = hoadon.NAM.ToString();
                            dgvDanhBo["MLT", e.RowIndex].Value = hoadon.MALOTRINH.ToString();
                            dgvDanhBo["SX", e.RowIndex].Value = hoadon.TILESX.ToString();
                            dgvDanhBo["SH", e.RowIndex].Value = hoadon.TILESH.ToString();
                            dgvDanhBo["DV", e.RowIndex].Value = hoadon.TILEDV.ToString();
                            dgvDanhBo["HCSN", e.RowIndex].Value = hoadon.TILEHCSN.ToString();
                            dgvDanhBo["MaQuanPhuong", e.RowIndex].Value = hoadon.Quan + " " + hoadon.Phuong;
                        }
                        else
                        {
                            MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                    if (dgvDanhBo["MaDon", e.RowIndex].Value.ToString().ToUpper().Contains("TBC"))
                    {
                        DonTBC dontbc = _cDonTBC.Get(decimal.Parse(dgvDanhBo["MaDon", e.RowIndex].Value.ToString().Substring(3).Replace("-", "")));
                        if (dontbc != null)
                        {
                            if (_cThuTien.GetMoiNhat(dontbc.DanhBo) != null)
                            {
                                HOADON hoadon = _cThuTien.GetMoiNhat(dontbc.DanhBo);
                                dgvDanhBo["DanhBo", e.RowIndex].Value = hoadon.DANHBA;
                                dgvDanhBo["HopDong", e.RowIndex].Value = hoadon.HOPDONG;
                                dgvDanhBo["HoTen", e.RowIndex].Value = hoadon.TENKH;
                                dgvDanhBo["DiaChi", e.RowIndex].Value = hoadon.SO + " " + hoadon.DUONG + _cDocSo.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
                                dgvDanhBo["MSThue", e.RowIndex].Value = hoadon.MST;
                                dgvDanhBo["GiaBieu", e.RowIndex].Value = hoadon.GB;
                                dgvDanhBo["DinhMuc", e.RowIndex].Value = hoadon.DM;
                                dgvDanhBo["Dot", e.RowIndex].Value = hoadon.DOT.ToString();
                                dgvDanhBo["Ky", e.RowIndex].Value = hoadon.KY.ToString();
                                dgvDanhBo["Nam", e.RowIndex].Value = hoadon.NAM.ToString();
                                dgvDanhBo["MLT", e.RowIndex].Value = hoadon.MALOTRINH.ToString();
                                dgvDanhBo["SX", e.RowIndex].Value = hoadon.TILESX.ToString();
                                dgvDanhBo["SH", e.RowIndex].Value = hoadon.TILESH.ToString();
                                dgvDanhBo["DV", e.RowIndex].Value = hoadon.TILEDV.ToString();
                                dgvDanhBo["HCSN", e.RowIndex].Value = hoadon.TILEHCSN.ToString();
                                dgvDanhBo["MaQuanPhuong", e.RowIndex].Value = hoadon.Quan + " " + hoadon.Phuong;
                            }
                            else
                            {
                                MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    ///Đơn Tổ Khách Hàng
                    else
                    {
                        DonKH dontkh = _cDonKH.Get(decimal.Parse(dgvDanhBo["MaDon", e.RowIndex].Value.ToString().Replace("-", "")));
                        if (dontkh != null)
                        {
                            if (_cThuTien.GetMoiNhat(dontkh.DanhBo) != null)
                            {
                                HOADON hoadon = _cThuTien.GetMoiNhat(dontkh.DanhBo);
                                dgvDanhBo["DanhBo", e.RowIndex].Value = hoadon.DANHBA;
                                dgvDanhBo["HopDong", e.RowIndex].Value = hoadon.HOPDONG;
                                dgvDanhBo["HoTen", e.RowIndex].Value = hoadon.TENKH;
                                dgvDanhBo["DiaChi", e.RowIndex].Value = hoadon.SO + " " + hoadon.DUONG + _cDocSo.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
                                dgvDanhBo["MSThue", e.RowIndex].Value = hoadon.MST;
                                dgvDanhBo["GiaBieu", e.RowIndex].Value = hoadon.GB;
                                dgvDanhBo["DinhMuc", e.RowIndex].Value = hoadon.DM;
                                dgvDanhBo["Dot", e.RowIndex].Value = hoadon.DOT.ToString();
                                dgvDanhBo["Ky", e.RowIndex].Value = hoadon.KY.ToString();
                                dgvDanhBo["Nam", e.RowIndex].Value = hoadon.NAM.ToString();
                                dgvDanhBo["MLT", e.RowIndex].Value = hoadon.MALOTRINH.ToString();
                                dgvDanhBo["SX", e.RowIndex].Value = hoadon.TILESX.ToString();
                                dgvDanhBo["SH", e.RowIndex].Value = hoadon.TILESH.ToString();
                                dgvDanhBo["DV", e.RowIndex].Value = hoadon.TILEDV.ToString();
                                dgvDanhBo["HCSN", e.RowIndex].Value = hoadon.TILEHCSN.ToString();
                                dgvDanhBo["MaQuanPhuong", e.RowIndex].Value = hoadon.Quan + " " + hoadon.Phuong;
                            }
                            else
                            {
                                MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
            }

            //if (dgvDanhBo.Columns[e.ColumnIndex].Name == "DanhBo" && dgvDanhBo["DanhBo", e.RowIndex].Value != null)
            //{
            //    for (int i = 0; i < dgvDanhBo.Rows.Count - 2; i++)
            //        if (i != e.RowIndex && dgvDanhBo["DanhBo", i].Value != null && dgvDanhBo["DanhBo", i].Value.ToString() != "" && dgvDanhBo["DanhBo", i].Value.ToString() == dgvDanhBo["DanhBo", e.RowIndex].Value.ToString())
            //        {
            //            MessageBox.Show("Danh Bộ đã nhập rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }

            //    if (_cThuTien.GetMoiNhat(dgvDanhBo["DanhBo", e.RowIndex].Value.ToString()) != null)
            //    {
            //        HOADON hoadon = _cThuTien.GetMoiNhat(dgvDanhBo["DanhBo", e.RowIndex].Value.ToString());
            //        dgvDanhBo["HopDong", e.RowIndex].Value = hoadon.HOPDONG;
            //        dgvDanhBo["HoTen", e.RowIndex].Value = hoadon.TENKH;
            //        dgvDanhBo["DiaChi", e.RowIndex].Value = hoadon.SO + " " + hoadon.DUONG + _cDocSo.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
            //        dgvDanhBo["MSThue", e.RowIndex].Value = hoadon.MST;
            //        dgvDanhBo["GiaBieu", e.RowIndex].Value = hoadon.GB;
            //        dgvDanhBo["DinhMuc", e.RowIndex].Value = hoadon.DM;
            //        dgvDanhBo["Dot", e.RowIndex].Value = hoadon.DOT.ToString();
            //        dgvDanhBo["Ky", e.RowIndex].Value = hoadon.KY.ToString();
            //        dgvDanhBo["Nam", e.RowIndex].Value = hoadon.NAM.ToString();
            //        dgvDanhBo["MLT", e.RowIndex].Value = hoadon.MALOTRINH.ToString();
            //        dgvDanhBo["SX", e.RowIndex].Value = hoadon.TILESX.ToString();
            //        dgvDanhBo["SH", e.RowIndex].Value = hoadon.TILESH.ToString();
            //        dgvDanhBo["DV", e.RowIndex].Value = hoadon.TILEDV.ToString();
            //        dgvDanhBo["HCSN", e.RowIndex].Value = hoadon.TILEHCSN.ToString();
            //        dgvDanhBo["MaQuanPhuong", e.RowIndex].Value = hoadon.Quan + " " + hoadon.Phuong;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

        private void dgvDanhBo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhBo.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDanhBo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    foreach (DataGridViewRow item in dgvDanhBo.Rows)
                        if (item.Cells["MaDon"].Value != null && item.Cells["DanhBo"].Value != null)
                        {
                            ///Đơn Tổ Xử Lý
                            if (item.Cells["MaDon"].Value.ToString().ToUpper().Contains("TXL"))
                            {
                                if (_cDCBD.CheckExist_DCBD("TKH", decimal.Parse(item.Cells["MaDon"].Value.ToString().Substring(3).Replace("-", "")), item.Cells["DanhBo"].Value.ToString()) == true)
                                {
                                    MessageBox.Show("Danh Bộ này đã được Lập Điều Chỉnh Biến Động", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            else
                                if (item.Cells["MaDon"].Value.ToString().ToUpper().Contains("TBC"))
                                {
                                    if (_cDCBD.CheckExist_DCBD("TKH", decimal.Parse(item.Cells["MaDon"].Value.ToString().Substring(3).Replace("-", "")), item.Cells["DanhBo"].Value.ToString()) == true)
                                    {
                                        MessageBox.Show("Danh Bộ này đã được Lập Điều Chỉnh Biến Động", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                ///Đơn Tổ Khách Hàng
                                else
                                {
                                    if (_cDCBD.CheckExist_DCBD("TKH", decimal.Parse(item.Cells["MaDon"].Value.ToString().Replace("-", "")), item.Cells["DanhBo"].Value.ToString()) == true)
                                    {
                                        MessageBox.Show("Danh Bộ này đã được Lập Điều Chỉnh Biến Động", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                        }

                    decimal min = 0, max = 0;
                    _cDCBD.beginTransaction();
                    foreach (DataGridViewRow item in dgvDanhBo.Rows)
                        if (item.Cells["MaDon"].Value != null && item.Cells["DanhBo"].Value != null && item.Cells["GBMoi"].Value != null)
                        {
                            CTDCBD ctdcbd = new CTDCBD();

                            ///Đơn Tổ Xử Lý
                            if (item.Cells["MaDon"].Value.ToString().ToUpper().Contains("TXL"))
                            {
                                if (_cDCBD.CheckExist("TXL", decimal.Parse(item.Cells["MaDon"].Value.ToString().Substring(3).Replace("-", ""))) == false)
                                {
                                    DCBD dcbd = new DCBD();
                                    dcbd.MaDonTXL = decimal.Parse(item.Cells["MaDon"].Value.ToString().Substring(3).Replace("-", ""));
                                    //dcbd.MaDonMoi = _dontxl.MaDonMoi;
                                    _cDCBD.Them(dcbd);
                                }
                                ctdcbd.MaDCBD = _cDCBD.Get("TXL", decimal.Parse(item.Cells["MaDon"].Value.ToString().Substring(3).Replace("-", ""))).MaDCBD;
                            }
                            else
                                if (item.Cells["MaDon"].Value.ToString().ToUpper().Contains("TBC"))
                                {
                                    if (_cDCBD.CheckExist("TBC", decimal.Parse(item.Cells["MaDon"].Value.ToString().Substring(3).Replace("-", ""))) == false)
                                    {
                                        DCBD dcbd = new DCBD();
                                        dcbd.MaDonTBC = decimal.Parse(item.Cells["MaDon"].Value.ToString().Substring(3).Replace("-", ""));
                                        //dcbd.MaDonMoi = _dontbc.MaDonMoi;
                                        _cDCBD.Them(dcbd);
                                    }
                                    ctdcbd.MaDCBD = _cDCBD.Get("TBC", decimal.Parse(item.Cells["MaDon"].Value.ToString().Substring(3).Replace("-", ""))).MaDCBD;
                                }
                                ///Đơn Tổ Khách Hàng
                                else
                                {
                                    if (_cDCBD.CheckExist("TKH", decimal.Parse(item.Cells["MaDon"].Value.ToString().Replace("-", ""))) == false)
                                    {
                                        DCBD dcbd = new DCBD();
                                        dcbd.MaDon = decimal.Parse(item.Cells["MaDon"].Value.ToString().Replace("-", ""));
                                        //dcbd.MaDonMoi = _dontkh.MaDonMoi;
                                        _cDCBD.Them(dcbd);
                                    }
                                    ctdcbd.MaDCBD = _cDCBD.Get("TKH", decimal.Parse(item.Cells["MaDon"].Value.ToString().Replace("-", ""))).MaDCBD;
                                }

                            if (item.Cells["DanhBo"].Value != null)
                                ctdcbd.DanhBo = item.Cells["DanhBo"].Value.ToString();
                            if (item.Cells["HopDong"].Value != null)
                                ctdcbd.HopDong = item.Cells["HopDong"].Value.ToString();
                            if (item.Cells["HoTen"].Value != null)
                                ctdcbd.HoTen = item.Cells["HoTen"].Value.ToString();
                            if (item.Cells["DiaChi"].Value != null)
                                ctdcbd.DiaChi = item.Cells["DiaChi"].Value.ToString();
                            if (item.Cells["MSThue"].Value != null)
                                ctdcbd.MSThue = item.Cells["MSThue"].Value.ToString();
                            if (item.Cells["GiaBieu"].Value != null)
                                ctdcbd.GiaBieu = int.Parse(item.Cells["GiaBieu"].Value.ToString());
                            if (item.Cells["DinhMuc"].Value != null)
                                ctdcbd.DinhMuc = int.Parse(item.Cells["DinhMuc"].Value.ToString());
                            if (item.Cells["Dot"].Value != null)
                                ctdcbd.Dot = item.Cells["Dot"].Value.ToString();
                            if (item.Cells["Ky"].Value != null)
                                ctdcbd.Ky = item.Cells["Ky"].Value.ToString();
                            if (item.Cells["Nam"].Value != null)
                                ctdcbd.Nam = item.Cells["Nam"].Value.ToString();
                            if (item.Cells["MaQuanPhuong"].Value != null)
                                ctdcbd.MaQuanPhuong = item.Cells["MaQuanPhuong"].Value.ToString();
                            if (item.Cells["SH"].Value != null)
                                ctdcbd.SH = item.Cells["SH"].Value.ToString();
                            if (item.Cells["SX"].Value != null)
                                ctdcbd.SX = item.Cells["SX"].Value.ToString();
                            if (item.Cells["DV"].Value != null)
                                ctdcbd.DV = item.Cells["DV"].Value.ToString();
                            if (item.Cells["HCSN"].Value != null)
                                ctdcbd.HCSN = item.Cells["HCSN"].Value.ToString();

                            if (item.Cells["GBMoi"].Value != null)
                            {
                                ctdcbd.ThongTin = "GB. ";
                                ctdcbd.GiaBieu_BD = int.Parse(item.Cells["GBMoi"].Value.ToString());
                            }

                            if (item.Cells["HieuLucKy"].Value != null)
                                ctdcbd.HieuLucKy = item.Cells["HieuLucKy"].Value.ToString();

                            BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                ctdcbd.ChucVu = "GIÁM ĐỐC";
                            else
                                ctdcbd.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            ctdcbd.NguoiKy = bangiamdoc.HoTen.ToUpper();
                            ctdcbd.PhieuDuocKy = true;

                            if (_cDCBD.ThemDCBD(ctdcbd))
                            {
                                if (min == 0)
                                    min = ctdcbd.MaCTDCBD;
                                max = ctdcbd.MaCTDCBD;
                            }
                        }

                    _cDCBD.commitTransaction();
                    MessageBox.Show("Thành công\nSố Phiếu từ " + min.ToString().Insert(min.ToString().Length - 2, "-") + " đến " + max.ToString().Insert(max.ToString().Length - 2, "-"), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    _cDCBD.rollback();
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvDanhBo_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
                {
                    dgvDanhBo["GBMoi", e.RowIndex].Value = dgvDanhBo["GBMoi", e.RowIndex - 1].Value;
                }
        }
    }
}