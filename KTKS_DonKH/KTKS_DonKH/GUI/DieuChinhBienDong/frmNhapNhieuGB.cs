using System;
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
using KTKS_DonKH.DAL.DonTu;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmNhapNhieuGB : Form
    {
        string _mnu = "mnuDCBD";
        CDonTu _cDonTu = new CDonTu();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CDonTBC _cDonTBC = new CDonTBC();
        CThuTien _cThuTien = new CThuTien();
        CDHN _cDocSo = new CDHN();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        CDCBD _cDCBD = new CDCBD();
        CHoNgheo _cHoNgheo = new CHoNgheo();
        CChungTu _cChungTu = new CChungTu();

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
                //Đơn Tổ Khách Hàng
                if (dgvDanhBo["MaDon", e.RowIndex].Value.ToString().ToUpper().Contains("TKH"))
                {
                    DonKH dontkh = _cDonKH.Get(decimal.Parse(dgvDanhBo["MaDon", e.RowIndex].Value.ToString().Substring(3).Replace("-", "")));
                    if (dontkh != null)
                    {
                        HOADON hoadon = _cThuTien.GetMoiNhat(dontkh.DanhBo);
                        if (hoadon != null)
                        {
                            dgvDanhBo["DanhBo", e.RowIndex].Value = hoadon.DANHBA;
                            dgvDanhBo["HopDong", e.RowIndex].Value = hoadon.HOPDONG;
                            dgvDanhBo["HoTen", e.RowIndex].Value = hoadon.TENKH;
                            dgvDanhBo["DiaChi", e.RowIndex].Value = hoadon.SO + " " + hoadon.DUONG + _cDocSo.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
                            dgvDanhBo["MSThue", e.RowIndex].Value = hoadon.MST;
                            dgvDanhBo["GiaBieu", e.RowIndex].Value = hoadon.GB;
                            dgvDanhBo["DinhMucHN", e.RowIndex].Value = hoadon.DinhMucHN;
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
                    //Đơn Tổ Xử Lý
                    if (dgvDanhBo["MaDon", e.RowIndex].Value.ToString().ToUpper().Contains("TXL"))
                    {
                        DonTXL dontxl = _cDonTXL.Get(decimal.Parse(dgvDanhBo["MaDon", e.RowIndex].Value.ToString().Substring(3).Replace("-", "")));
                        if (dontxl != null)
                        {
                            HOADON hoadon = _cThuTien.GetMoiNhat(dontxl.DanhBo);
                            if (hoadon != null)
                            {
                                dgvDanhBo["DanhBo", e.RowIndex].Value = hoadon.DANHBA;
                                dgvDanhBo["HopDong", e.RowIndex].Value = hoadon.HOPDONG;
                                dgvDanhBo["HoTen", e.RowIndex].Value = hoadon.TENKH;
                                dgvDanhBo["DiaChi", e.RowIndex].Value = hoadon.SO + " " + hoadon.DUONG + _cDocSo.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
                                dgvDanhBo["MSThue", e.RowIndex].Value = hoadon.MST;
                                dgvDanhBo["GiaBieu", e.RowIndex].Value = hoadon.GB;
                                dgvDanhBo["DinhMucHN", e.RowIndex].Value = hoadon.DinhMucHN;
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
                                HOADON hoadon = _cThuTien.GetMoiNhat(dontbc.DanhBo);
                                if (hoadon != null)
                                {
                                    dgvDanhBo["DanhBo", e.RowIndex].Value = hoadon.DANHBA;
                                    dgvDanhBo["HopDong", e.RowIndex].Value = hoadon.HOPDONG;
                                    dgvDanhBo["HoTen", e.RowIndex].Value = hoadon.TENKH;
                                    dgvDanhBo["DiaChi", e.RowIndex].Value = hoadon.SO + " " + hoadon.DUONG + _cDocSo.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
                                    dgvDanhBo["MSThue", e.RowIndex].Value = hoadon.MST;
                                    dgvDanhBo["GiaBieu", e.RowIndex].Value = hoadon.GB;
                                    dgvDanhBo["DinhMucHN", e.RowIndex].Value = hoadon.DinhMucHN;
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
                        {
                            string MaDon = dgvDanhBo["MaDon", e.RowIndex].Value.ToString();
                            DonTu_ChiTiet dontu_ChiTiet = null;
                            if (MaDon.Contains(".") == true)
                            {
                                string[] MaDons = MaDon.Split('.');
                                dontu_ChiTiet = _cDonTu.get_ChiTiet(int.Parse(MaDons[0]), int.Parse(MaDons[1]));
                            }
                            else
                            {
                                LinQ.DonTu dt = _cDonTu.get(int.Parse(MaDon));
                                if (dt != null)
                                    dontu_ChiTiet = dt.DonTu_ChiTiets.SingleOrDefault();
                            }
                            //
                            if (dontu_ChiTiet != null)
                            {
                                HOADON hoadon = _cThuTien.GetMoiNhat(dontu_ChiTiet.DanhBo);
                                if (hoadon != null)
                                {
                                    dgvDanhBo["DanhBo", e.RowIndex].Value = hoadon.DANHBA;
                                    dgvDanhBo["HopDong", e.RowIndex].Value = hoadon.HOPDONG;
                                    dgvDanhBo["HoTen", e.RowIndex].Value = hoadon.TENKH;
                                    dgvDanhBo["DiaChi", e.RowIndex].Value = hoadon.SO + " " + hoadon.DUONG + _cDocSo.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
                                    dgvDanhBo["MSThue", e.RowIndex].Value = hoadon.MST;
                                    dgvDanhBo["GiaBieu", e.RowIndex].Value = hoadon.GB;
                                    dgvDanhBo["DinhMucHN", e.RowIndex].Value = hoadon.DinhMucHN;
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

            if (dgvDanhBo.Columns[e.ColumnIndex].Name == "GBMoi" && dgvDanhBo["GBMoi", e.RowIndex].Value != null)
            {
                if (dgvDanhBo["GBMoi", e.RowIndex].Value.ToString() == dgvDanhBo["GiaBieu", e.RowIndex].Value.ToString())
                    dgvDanhBo.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
            }

            if (dgvDanhBo.Columns[e.ColumnIndex].Name == "DMHNMoi" && dgvDanhBo["DMHNMoi", e.RowIndex].Value != null)
            {
                if (dgvDanhBo["DMHNMoi", e.RowIndex].Value.ToString() == dgvDanhBo["DinhMucHN", e.RowIndex].Value.ToString())
                    dgvDanhBo.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
            }
            if (dgvDanhBo.Columns[e.ColumnIndex].Name == "DMMoi" && dgvDanhBo["DMMoi", e.RowIndex].Value != null)
            {
                if (dgvDanhBo["DMMoi", e.RowIndex].Value.ToString() == dgvDanhBo["DinhMuc", e.RowIndex].Value.ToString())
                    dgvDanhBo.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
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
                            //Đơn Tổ Khách Hàng
                            if (item.Cells["MaDon"].Value.ToString().ToUpper().Contains("TKH"))
                            {
                                if (_cDCBD.checkExist_BienDong("TKH", decimal.Parse(item.Cells["MaDon"].Value.ToString().Replace("-", "")), item.Cells["DanhBo"].Value.ToString()) == true)
                                {
                                    MessageBox.Show("Danh Bộ này đã được Lập Điều Chỉnh Biến Động", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            else
                                //Đơn Tổ Xử Lý
                                if (item.Cells["MaDon"].Value.ToString().ToUpper().Contains("TXL"))
                                {
                                    if (_cDCBD.checkExist_BienDong("TKH", decimal.Parse(item.Cells["MaDon"].Value.ToString().Substring(3).Replace("-", "")), item.Cells["DanhBo"].Value.ToString()) == true)
                                    {
                                        MessageBox.Show("Danh Bộ này đã được Lập Điều Chỉnh Biến Động", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                else
                                    //Đơn Tổ Bấm Chì
                                    if (item.Cells["MaDon"].Value.ToString().ToUpper().Contains("TBC"))
                                    {
                                        if (_cDCBD.checkExist_BienDong("TKH", decimal.Parse(item.Cells["MaDon"].Value.ToString().Substring(3).Replace("-", "")), item.Cells["DanhBo"].Value.ToString()) == true)
                                        {
                                            MessageBox.Show("Danh Bộ này đã được Lập Điều Chỉnh Biến Động", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        string MaDon = item.Cells["MaDon"].Value.ToString();
                                        DonTu_ChiTiet dontu_ChiTiet = null;
                                        if (MaDon.Contains(".") == true)
                                        {
                                            string[] MaDons = MaDon.Split('.');
                                            dontu_ChiTiet = _cDonTu.get_ChiTiet(int.Parse(MaDons[0]), int.Parse(MaDons[1]));
                                        }
                                        else
                                        {
                                            LinQ.DonTu dt = _cDonTu.get(int.Parse(MaDon));
                                            if (dt != null)
                                                dontu_ChiTiet = dt.DonTu_ChiTiets.SingleOrDefault();
                                        }
                                        if (_cDCBD.checkExist_BienDong(dontu_ChiTiet.MaDon.Value, item.Cells["DanhBo"].Value.ToString()) == true)
                                        {
                                            MessageBox.Show("Danh Bộ này đã được Lập Điều Chỉnh Biến Động", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                    }
                        }

                    decimal min = 0, max = 0;
                    _cDCBD.beginTransaction();
                    foreach (DataGridViewRow item in dgvDanhBo.Rows)
                        if (item.Cells["MaDon"].Value != null && item.Cells["MaDon"].Value.ToString() != "" && item.Cells["DanhBo"].Value != null && (item.Cells["GBMoi"].Value != null || item.Cells["DMMoi"].Value != null || item.Cells["DMHNMoi"].Value != null))
                        {
                            DonTu_ChiTiet dontu_ChiTiet = null;
                            DCBD_ChiTietBienDong ctdcbd = new DCBD_ChiTietBienDong();

                            //Đơn Tổ Khách Hàng
                            if (item.Cells["MaDon"].Value.ToString().ToUpper().Contains("TKH"))
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
                            //Đơn Tổ Xử Lý
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
                                //Tổ Bấm Chì
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
                                else
                                {
                                    string MaDon = item.Cells["MaDon"].Value.ToString();

                                    if (MaDon.Contains(".") == true)
                                    {
                                        string[] MaDons = MaDon.Split('.');
                                        dontu_ChiTiet = _cDonTu.get_ChiTiet(int.Parse(MaDons[0]), int.Parse(MaDons[1]));
                                    }
                                    else
                                    {
                                        LinQ.DonTu dt = _cDonTu.get(int.Parse(MaDon));
                                        if (dt != null)
                                            dontu_ChiTiet = dt.DonTu_ChiTiets.SingleOrDefault();
                                    }
                                    if (_cDCBD.checkExist(dontu_ChiTiet.MaDon.Value) == false)
                                    {
                                        DCBD dcbd = new DCBD();
                                        dcbd.MaDonMoi = dontu_ChiTiet.MaDon.Value;
                                        _cDCBD.Them(dcbd);
                                    }
                                    ctdcbd.MaDCBD = _cDCBD.get(dontu_ChiTiet.MaDon.Value).MaDCBD;
                                    ctdcbd.STT = dontu_ChiTiet.STT.Value;
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
                                ctdcbd.ThongTin = "Giá Biểu";
                                ctdcbd.GiaBieu_BD = int.Parse(item.Cells["GBMoi"].Value.ToString());
                            }

                            if (item.Cells["DMHNMoi"].Value != null || item.Cells["DMMoi"].Value != null)
                            {
                                if (string.IsNullOrEmpty(ctdcbd.ThongTin) == true)
                                    ctdcbd.ThongTin += "Định Mức";
                                else
                                    ctdcbd.ThongTin += ". Định Mức";
                                if (item.Cells["DMHNMoi"].Value != null)
                                    ctdcbd.DinhMucHN_BD = int.Parse(item.Cells["DMHNMoi"].Value.ToString());
                                if (item.Cells["DMMoi"].Value != null)
                                    ctdcbd.DinhMuc_BD = int.Parse(item.Cells["DMMoi"].Value.ToString());
                            }

                            if (item.Cells["HieuLucKy"].Value != null)
                                ctdcbd.HieuLucKy = item.Cells["HieuLucKy"].Value.ToString();

                            if (item.Cells["CongDung"].Value != null)
                                ctdcbd.CongDung = item.Cells["CongDung"].Value.ToString();

                            BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                ctdcbd.ChucVu = "GIÁM ĐỐC";
                            else
                                ctdcbd.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                            ctdcbd.NguoiKy = bangiamdoc.HoTen.ToUpper();
                            ctdcbd.PhieuDuocKy = true;

                            if (_cDCBD.ThemDCBD(ctdcbd))
                            {
                                //string[] MaCTs = item.Cells["MaCT"].Value.ToString().Split(',');
                                //int DinhMuc = 0;
                                //if (ctdcbd.GiaBieu_BD == null)
                                //    DinhMuc = (int)Math.Round((double)ctdcbd.DinhMucHN_BD.Value / MaCTs.Length, 0, MidpointRounding.AwayFromZero);
                                //else
                                //    DinhMuc = (int)Math.Round((double)ctdcbd.DinhMuc_BD.Value / MaCTs.Length, 0, MidpointRounding.AwayFromZero);
                                //int[] a = new int[MaCTs.Length];
                                //int temp = 0;
                                //for (int i = 0; i < MaCTs.Length; i++)
                                //    if (i + 1 == MaCTs.Length)
                                //    {
                                //        if (ctdcbd.GiaBieu_BD == null)
                                //            a[i] = ctdcbd.DinhMucHN_BD.Value - temp;
                                //        else
                                //            a[i] = ctdcbd.DinhMuc_BD.Value - temp;
                                //    }
                                //    else
                                //    {
                                //        temp += DinhMuc;
                                //    }
                                //for (int i = 0; i < MaCTs.Length; i++)
                                //{
                                //    ChungTu chungtu = new ChungTu();
                                //    chungtu.MaCT = MaCTs[i];
                                //    chungtu.HoTen = item.Cells["HoTen"].Value.ToString();
                                //    chungtu.DiaChi = item.Cells["DiaChi"].Value.ToString();
                                //    chungtu.SoNKTong = a[i] / 4;
                                //    chungtu.MaLCT = 9;
                                //    _cChungTu.Them(chungtu);

                                //    ChungTu_ChiTiet ctchungtu = new ChungTu_ChiTiet();
                                //    ctchungtu.DanhBo = item.Cells["DanhBo"].Value.ToString();
                                //    ctchungtu.MaLCT = 9;
                                //    ctchungtu.MaCT = MaCTs[i];
                                //    ctchungtu.SoNKDangKy = a[i] / 4;
                                //    ctchungtu.ThoiHan = 12;
                                //    ctchungtu.NgayHetHan = DateTime.Now.AddMonths(12);
                                //    _cChungTu.ThemCT(ctchungtu);
                                //}
                                //_cDCBD.ExecuteNonQuery("update HoNgheo set DCBD=1 where DanhBo='" + item.Cells["DanhBo"].Value.ToString() + "'");
                                if (dontu_ChiTiet != null)
                                    _cDonTu.Them_LichSu(ctdcbd.CreateDate.Value, "DCBD", "Đã Điều Chỉnh Biến Động, " + ctdcbd.ThongTin, (int)ctdcbd.MaCTDCBD, dontu_ChiTiet.MaDon.Value, dontu_ChiTiet.STT.Value);
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
            //if (e.RowIndex > 0)
            //    {
            //        dgvDanhBo["GBMoi", e.RowIndex].Value = dgvDanhBo["GBMoi", e.RowIndex - 1].Value;
            //    }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (cmbDot.SelectedIndex == 0)
            {
                dt = _cHoNgheo.getDS();
            }
            else
                if (cmbDot.SelectedIndex > 0)
                {
                    dt = _cHoNgheo.getDS_Dot(int.Parse(cmbDot.SelectedItem.ToString()));
                }

            foreach (DataRow item in dt.Rows)
            {
                HOADON hoadon = _cThuTien.GetMoiNhat(item["DanhBo"].ToString());
                if (hoadon != null)
                {
                    var index = dgvDanhBo.Rows.Add();
                    dgvDanhBo["MaDon", index].Value = "19110518";
                    dgvDanhBo["HieuLucKy", index].Value = "12/2019";
                    dgvDanhBo["DanhBo", index].Value = hoadon.DANHBA;
                    dgvDanhBo["HopDong", index].Value = hoadon.HOPDONG;
                    dgvDanhBo["HoTen", index].Value = hoadon.TENKH;
                    dgvDanhBo["DiaChi", index].Value = hoadon.SO + " " + hoadon.DUONG + _cDocSo.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
                    dgvDanhBo["MSThue", index].Value = hoadon.MST;
                    dgvDanhBo["GiaBieu", index].Value = hoadon.GB;
                    dgvDanhBo["DinhMucHN", index].Value = hoadon.DinhMucHN;
                    dgvDanhBo["DinhMuc", index].Value = hoadon.DM;
                    dgvDanhBo["Dot", index].Value = hoadon.DOT.ToString();
                    dgvDanhBo["Ky", index].Value = hoadon.KY.ToString();
                    dgvDanhBo["Nam", index].Value = hoadon.NAM.ToString();
                    dgvDanhBo["MLT", index].Value = hoadon.MALOTRINH.ToString();
                    dgvDanhBo["SX", index].Value = hoadon.TILESX.ToString();
                    dgvDanhBo["SH", index].Value = hoadon.TILESH.ToString();
                    dgvDanhBo["DV", index].Value = hoadon.TILEDV.ToString();
                    dgvDanhBo["HCSN", index].Value = hoadon.TILEHCSN.ToString();
                    dgvDanhBo["MaQuanPhuong", index].Value = hoadon.Quan + " " + hoadon.Phuong;
                    dgvDanhBo["MaCT", index].Value = item["MaCT"].ToString();
                    if (int.Parse(dgvDanhBo["GiaBieu", index].Value.ToString()) == 11)
                    {
                        if (int.Parse(dgvDanhBo["DinhMuc", index].Value.ToString()) <= int.Parse(item["DinhMucHN"].ToString()))
                        {
                            dgvDanhBo["GBMoi", index].Value = "10";
                            dgvDanhBo["DMMoi", index].Value = item["DinhMucHN"].ToString();
                        }
                        else
                            if (int.Parse(dgvDanhBo["DinhMuc", index].Value.ToString()) > int.Parse(item["DinhMucHN"].ToString()))
                            {
                                dgvDanhBo["DMMoi", index].Value = int.Parse(dgvDanhBo["DinhMuc", index].Value.ToString());
                                dgvDanhBo["DMHNMoi", index].Value = item["DinhMucHN"].ToString();
                            }
                    }
                    else
                    {
                        if (int.Parse(dgvDanhBo["DinhMuc", index].Value.ToString()) <= int.Parse(item["DinhMucHN"].ToString()))
                        {
                            dgvDanhBo["DMMoi", index].Value = item["DinhMucHN"].ToString();
                            dgvDanhBo["DMHNMoi", index].Value = item["DinhMucHN"].ToString();
                        }
                        else
                            if (int.Parse(dgvDanhBo["DinhMuc", index].Value.ToString()) > int.Parse(item["DinhMucHN"].ToString()))
                            {
                                dgvDanhBo["DMMoi", index].Value = int.Parse(dgvDanhBo["DinhMuc", index].Value.ToString());
                                dgvDanhBo["DMHNMoi", index].Value = item["DinhMucHN"].ToString();
                            }
                    }
                }

            }

        }
    }
}