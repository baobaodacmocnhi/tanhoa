using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.DAL.QuanTri;
using System.Globalization;
using ThuTien.DAL.Quay;
using ThuTien.DAL.TongHop;
using ThuTien.BaoCao;
using ThuTien.BaoCao.NhanVien;
using ThuTien.GUI.BaoCao;
using ThuTien.LinQ;

namespace ThuTien.GUI.ToTruong
{
    public partial class frmDieuChinhDangNganTo : Form
    {
        ///Load tất cả hóa đơn đăng ngân hành thu & tồn nên hàm DangNgan & XoaDangNgan có chút thay đổi
        ///Xóa người đăng ngân nhưng vẫn giữ hình thức đăng ngân
        
        string _mnu = "mnuDieuChinhDangNgan";
        CHoaDon _cHoaDon = new CHoaDon();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CTamThu _cTamThu = new CTamThu();
        CDCHD _cDCHD = new CDCHD();
        CLenhHuy _cLenhHuy = new CLenhHuy();

        public frmDieuChinhDangNganTo()
        {
            InitializeComponent();
        }

        private void frmDieuChinhDangNgan_Load(object sender, EventArgs e)
        {
            dgvHDTuGia.AutoGenerateColumns = false;
            dgvHDCoQuan.AutoGenerateColumns = false;

            cmbNhanVien.DataSource = _cNguoiDung.GetDSHanhThuByMaTo(CNguoiDung.MaTo);
            cmbNhanVien.DisplayMember = "HoTen";
            cmbNhanVien.ValueMember = "MaND";

            lbTo.Text = "Tổ  " + CNguoiDung.TenTo;

            dateGiaiTrach.Value = DateTime.Now;
        }

        public void CountdgvHDTuGia()
        {
            int TongGiaBan = 0;
            int TongThueGTGT = 0;
            int TongPhiBVMT = 0;
            int TongCong = 0;

            if (dgvHDTuGia.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    TongGiaBan += int.Parse(item.Cells["GiaBan_TG"].Value.ToString());
                    TongThueGTGT += int.Parse(item.Cells["ThueGTGT_TG"].Value.ToString());
                    TongPhiBVMT += int.Parse(item.Cells["PhiBVMT_TG"].Value.ToString());
                    TongCong += int.Parse(item.Cells["TongCong_TG"].Value.ToString());
                }
                txtTongHD_TG.Text = dgvHDTuGia.RowCount.ToString();
                txtTongCong_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", dgvHDTuGia.RowCount);
                txtTongGiaBan_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBan);
                txtTongThueGTGT_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongThueGTGT);
                txtTongPhiBVMT_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongPhiBVMT);
                txtTongCong_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
        }

        public void CoungdgvHDCoQuan()
        {
            int TongGiaBan = 0;
            int TongThueGTGT = 0;
            int TongPhiBVMT = 0;
            int TongCong = 0;
            
            if (dgvHDCoQuan.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                {
                    TongGiaBan += int.Parse(item.Cells["GiaBan_CQ"].Value.ToString());
                    TongThueGTGT += int.Parse(item.Cells["ThueGTGT_CQ"].Value.ToString());
                    TongPhiBVMT += int.Parse(item.Cells["PhiBVMT_CQ"].Value.ToString());
                    TongCong += int.Parse(item.Cells["TongCong_CQ"].Value.ToString());
                }
                txtTongHD_CQ.Text = dgvHDCoQuan.RowCount.ToString();
                txtTongCong_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", dgvHDCoQuan.RowCount);
                txtTongGiaBan_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBan);
                txtTongThueGTGT_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongThueGTGT);
                txtTongPhiBVMT_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongPhiBVMT);
                txtTongCong_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                dgvHDTuGia.DataSource = _cHoaDon.GetDSDangNganByMaNVNgayGiaiTrach("TG", (int)cmbNhanVien.SelectedValue, dateGiaiTrach.Value);
                CountdgvHDTuGia();
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    dgvHDCoQuan.DataSource = _cHoaDon.GetDSDangNganByMaNVNgayGiaiTrach("CQ", (int)cmbNhanVien.SelectedValue, dateGiaiTrach.Value);
                    CoungdgvHDCoQuan();
                }
        }

        private void txtSoHoaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtSoHoaDon.Text.Trim()))
            {
                foreach (string item in txtSoHoaDon.Lines)
                    if (!string.IsNullOrEmpty(item.Trim().ToUpper()) && item.ToString().Length == 13 && lstHD.FindItemWithText(item.Trim().ToUpper()) == null)
                    {
                        lstHD.Items.Add(item.Trim().ToUpper());
                        lstHD.EnsureVisible(lstHD.Items.Count - 1);
                    }
                txtSoLuong.Text = lstHD.Items.Count.ToString();
                txtSoHoaDon.Text = "";
            }
        }

        private void lstHD_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstHD.Items.Count > 0 && e.Button == MouseButtons.Left)
            {
                foreach (ListViewItem item in lstHD.SelectedItems)
                {
                    lstHD.Items.Remove(item);
                }
                txtSoLuong.Text = lstHD.Items.Count.ToString();
            }
        }

        private void lstHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSoLuong.Text = lstHD.Items.Count.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                if (dateGiaiTrachSua.Value.Date != DateTime.Now.Date)
                {
                    MessageBox.Show("Chỉ được Điều Chỉnh Đăng Ngân trong ngày", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (lstHD.Items.Count > 0)
                {
                    //DataTable dt = (DataTable)dgvHDChuaThu.DataSource;
                    //DataColumn[] keyColumns = new DataColumn[1];
                    //keyColumns[0] = dt.Columns["SoHoaDon"];
                    //dt.PrimaryKey = keyColumns;
                    //string loai;
                    foreach (ListViewItem item in lstHD.Items)
                    {
                        //if (!dt.Rows.Contains(item.ToString()))
                        //{
                        //    MessageBox.Show("Hóa Đơn sai Hoặc đã Đăng Ngân: " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    lstHD.SelectedItem = item;
                        //    return;
                        //}
                        //if (_cHoaDon.CheckDangNganBySoHoaDon(item.ToString()))
                        //{
                        //    MessageBox.Show("Hóa Đơn đã Đăng Ngân: " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    lstHD.SelectedItem = item;
                        //    return;
                        //}
                        //if (_cTamThu.CheckBySoHoaDon(item.ToString(), out loai))
                        //{
                        //    MessageBox.Show("Hóa Đơn đã được Tạm Thu(" + loai + "): " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    lstHD.SelectedItem = item;
                        //    return;
                        //}
                        //if (_cDCHD.CheckExistByDangRutDC(item.ToString()))
                        //{
                        //    MessageBox.Show("Hóa Đơn đã rút đi Điều Chỉnh: " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    lstHD.SelectedItem = item;
                        //    return;
                        //}
                    }
                    try
                    {
                        //_cHoaDon.SqlBeginTransaction();
                        foreach (ListViewItem item in lstHD.Items)
                            if (_cHoaDon.DangNgan("HanhThu", item.Text, (int)cmbNhanVien.SelectedValue, dateGiaiTrachSua.Value))
                            {
                                ///ưu tiên đăng ngân hành thu, tự động xóa tạm thu chuyển qua thu 2 lần
                                bool ChuyenKhoan = false;
                                if (_cTamThu.CheckExist(item.Text,out ChuyenKhoan))
                                    if (_cHoaDon.Thu2Lan(item.Text,ChuyenKhoan))
                                    {
                                        if (!_cTamThu.XoaAn(item.Text))
                                        {
                                            //_cHoaDon.SqlRollbackTransaction();
                                            MessageBox.Show("Lỗi Xóa Tạm Thu, Vui lòng thử lại \r\n" + item.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        //_cHoaDon.SqlRollbackTransaction();
                                        MessageBox.Show("Lỗi Thu 2 Lần, Vui lòng thử lại \r\n" + item.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                //if (_cLenhHuy.CheckExist(item.ToString()))
                                //    if (!_cLenhHuy.Xoa(item.ToString()))
                                //    {
                                //        _cHoaDon.SqlRollbackTransaction();
                                //        MessageBox.Show("Lỗi Xóa Lệnh Hủy, Vui lòng thử lại \r\n" + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //        return;
                                //    }
                            }
                            else
                            {
                                //_cHoaDon.SqlRollbackTransaction();
                                //MessageBox.Show("Lỗi, Vui lòng thử lại \r\n" + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //return;
                            }
                        //_cHoaDon.SqlCommitTransaction();
                        btnXem.PerformClick();
                        lstHD.Items.Clear();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        //_cHoaDon.SqlRollbackTransaction();
                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (tabControl.SelectedTab.Name == "tabTuGia")
                    {
                        foreach (DataGridViewRow item in dgvHDTuGia.SelectedRows)
                        {
                            if (_cHoaDon.GetNgayGiaiTrach(item.Cells["SoHoaDon_TG"].Value.ToString()).Date != DateTime.Now.Date)
                            {
                                MessageBox.Show("Chỉ được Điều Chỉnh Đăng Ngân trong ngày", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    else
                        if (tabControl.SelectedTab.Name == "tabCoQuan")
                        {
                            foreach (DataGridViewRow item in dgvHDTuGia.SelectedRows)
                            {
                                if (_cHoaDon.GetNgayGiaiTrach(item.Cells["SoHoaDon_CQ"].Value.ToString()).Date != DateTime.Now.Date)
                                {
                                    MessageBox.Show("Chỉ được Điều Chỉnh Đăng Ngân trong ngày", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }

                    try
                    {
                        //_cHoaDon.SqlBeginTransaction();
                        if (tabControl.SelectedTab.Name == "tabTuGia")
                        {
                            foreach (DataGridViewRow item in dgvHDTuGia.SelectedRows)
                            {
                                if (!_cHoaDon.XoaDangNgan("", item.Cells["SoHoaDon_TG"].Value.ToString(), (int)cmbNhanVien.SelectedValue))
                                {
                                    //_cHoaDon.SqlRollbackTransaction();
                                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }
                        else
                            if (tabControl.SelectedTab.Name == "tabCoQuan")
                            {
                                foreach (DataGridViewRow item in dgvHDTuGia.SelectedRows)
                                {
                                    if (!_cHoaDon.XoaDangNgan("", item.Cells["SoHoaDon_CQ"].Value.ToString(), (int)cmbNhanVien.SelectedValue))
                                    {
                                        //_cHoaDon.SqlRollbackTransaction();
                                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                            }
                        
                        //_cHoaDon.SqlCommitTransaction();
                        btnXem.PerformClick();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        //_cHoaDon.SqlRollbackTransaction();
                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvHDTuGia_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "DanhBo_TG" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TieuThu_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "GiaBan_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "ThueGTGT_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "PhiBVMT_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCong_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHDTuGia_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHDTuGia.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvHDCoQuan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "DanhBo_CQ" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TieuThu_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "GiaBan_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "ThueGTGT_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "PhiBVMT_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongCong_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHDCoQuan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHDCoQuan.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                DataTable dt = _cHoaDon.GetTongDangNganByMaNV_DangNganNgayGiaiTrach("TG", int.Parse(cmbNhanVien.SelectedValue.ToString()), dateGiaiTrach.Value);
                foreach (DataRow item in dt.Rows)
                {
                    DataRow dr = ds.Tables["PhieuDangNgan"].NewRow();
                    dr["To"] = CNguoiDung.TenTo;
                    dr["Loai"] = "Tư Gia";
                    dr["NgayDangNgan"] = dateGiaiTrach.Value.Date.ToString("dd/MM/yyyy");
                    dr["TongHD"] = item["TongHD"].ToString();
                    dr["TongGiaBan"] = item["TongGiaBan"].ToString();
                    dr["TongThueGTGT"] = item["TongThueGTGT"].ToString();
                    dr["TongPhiBVMT"] = item["TongPhiBVMT"].ToString();
                    dr["TongCong"] = item["TongCong"].ToString();
                    dr["NhanVien"] = ((TT_NguoiDung)cmbNhanVien.SelectedItem).HoTen;
                    ds.Tables["PhieuDangNgan"].Rows.Add(dr);
                }
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    DataTable dt = _cHoaDon.GetTongDangNganByMaNV_DangNganNgayGiaiTrach("CQ", int.Parse(cmbNhanVien.SelectedValue.ToString()), dateGiaiTrach.Value);
                    foreach (DataRow item in dt.Rows)
                    {
                        DataRow dr = ds.Tables["PhieuDangNgan"].NewRow();
                        dr["To"] = CNguoiDung.TenTo;
                        dr["Loai"] = "Cơ Quan";
                        dr["NgayDangNgan"] = dateGiaiTrach.Value.Date.ToString("dd/MM/yyyy");
                        dr["TongHD"] = item["TongHD"].ToString();
                        dr["TongGiaBan"] = item["TongGiaBan"].ToString();
                        dr["TongThueGTGT"] = item["TongThueGTGT"].ToString();
                        dr["TongPhiBVMT"] = item["TongPhiBVMT"].ToString();
                        dr["TongCong"] = item["TongCong"].ToString();
                        dr["NhanVien"] = ((TT_NguoiDung)cmbNhanVien.SelectedItem).HoTen;
                        ds.Tables["PhieuDangNgan"].Rows.Add(dr);
                    }
                }
            

            rptPhieuDangNgan rpt = new rptPhieuDangNgan();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            string str = "";
            foreach (ListViewItem item in lstHD.Items)
            {
                str += item.Text + "\n";
            }
            Clipboard.SetText(str);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

    }
}
