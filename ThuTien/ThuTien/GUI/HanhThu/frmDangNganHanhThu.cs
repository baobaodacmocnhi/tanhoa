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
using ThuTien.GUI.BaoCao;
using ThuTien.BaoCao.NhanVien;
using System.Transactions;
using ThuTien.LinQ;

namespace ThuTien.GUI.HanhThu
{
    public partial class frmDangNganHanhThu : Form
    {
        string _mnu = "mnuDangNganHanhThu";
        CHoaDon _cHoaDon = new CHoaDon();
        CTamThu _cTamThu = new CTamThu();
        CDCHD _cDCHD = new CDCHD();
        CLenhHuy _cLenhHuy = new CLenhHuy();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CTienDuQuay _cTienDuQuay = new CTienDuQuay();
        //int _selectedindexDaThu = -1;

        public frmDangNganHanhThu()
        {
            InitializeComponent();
        }

        private void frmDangNganHD_Load(object sender, EventArgs e)
        {
            dgvTongHD.AutoGenerateColumns = false;
            dgvHDDaThu.AutoGenerateColumns = false;
            dgvHDChuaThu.AutoGenerateColumns = false;
            dgvHDDaThuDum.AutoGenerateColumns = false;

            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";

            cmbKy.SelectedItem = DateTime.Now.Month.ToString();
            tabControl.SelectedTab = tabControl.TabPages["tabChuaThu"];

            if (CNguoiDung.ToTruong)
            {
                lbNhanVien.Visible = true;
                cmbNhanVien.Visible = true;
                cmbNhanVien.DataSource = _cNguoiDung.GetDSHanhThuByMaTo(CNguoiDung.MaTo);
                cmbNhanVien.DisplayMember = "HoTen";
                cmbNhanVien.ValueMember = "MaND";
            }
        }

        public void LoadDataGridView()
        {
            int TongGiaBan = 0;
            int TongThueGTGT = 0;
            int TongPhiBVMT = 0;
            int TongCong = 0;
            if (dgvHDDaThu.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDDaThu.Rows)
                {
                    TongGiaBan += int.Parse(item.Cells["GiaBan_DT"].Value.ToString());
                    TongThueGTGT += int.Parse(item.Cells["ThueGTGT_DT"].Value.ToString());
                    TongPhiBVMT += int.Parse(item.Cells["PhiBVMT_DT"].Value.ToString());
                    TongCong += int.Parse(item.Cells["TongCong_DT"].Value.ToString());
                }
                txtTongHD_DT.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", dgvHDDaThu.RowCount);
                txtTongGiaBan_DT.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBan);
                txtTongThueGTGT_DT.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongThueGTGT);
                txtTongPhiBVMT_DT.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongPhiBVMT);
                txtTongCong_DT.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
            TongGiaBan = 0;
            TongThueGTGT = 0;
            TongPhiBVMT = 0;
            TongCong = 0;
            if (dgvHDChuaThu.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDChuaThu.Rows)
                {
                    TongGiaBan += int.Parse(item.Cells["GiaBan_CT"].Value.ToString());
                    TongThueGTGT += int.Parse(item.Cells["ThueGTGT_CT"].Value.ToString());
                    TongPhiBVMT += int.Parse(item.Cells["PhiBVMT_CT"].Value.ToString());
                    TongCong += int.Parse(item.Cells["TongCong_CT"].Value.ToString());
                }
                txtTongHD_CT.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", dgvHDChuaThu.RowCount);
                txtTongGiaBan_CT.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBan);
                txtTongThueGTGT_CT.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongThueGTGT);
                txtTongPhiBVMT_CT.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongPhiBVMT);
                txtTongCong_CT.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (cmbKy.SelectedIndex != -1 && cmbDot.SelectedIndex != -1)
            {
                if (CNguoiDung.ToTruong)
                {
                    dgvTongHD.DataSource = _cHoaDon.GetTongTGByMaNVNamKyDot(int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
                    dgvHDDaThuDum.DataSource = _cHoaDon.GetTongDangNgan("TG", int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
                    dgvHDDaThu.DataSource = _cHoaDon.GetDSDangNganHanhThuTG(int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
                    dgvHDChuaThu.DataSource = _cHoaDon.GetDSTon_NV("TG", int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), 1);
                }
                else
                {
                    dgvTongHD.DataSource = _cHoaDon.GetTongTGByMaNVNamKyDot(CNguoiDung.MaND, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
                    dgvHDDaThuDum.DataSource = _cHoaDon.GetTongDangNgan("TG", CNguoiDung.MaND, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
                    dgvHDDaThu.DataSource = _cHoaDon.GetDSDangNganHanhThuTG(CNguoiDung.MaND, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
                    dgvHDChuaThu.DataSource = _cHoaDon.GetDSTon_NV("TG", CNguoiDung.MaND, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), 1);
                }
                LoadDataGridView();
            }
        }

        private void txtSoHoaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtSoHoaDon.Text.Trim()))
            {
                foreach (string item in txtSoHoaDon.Lines)
                    if (!string.IsNullOrEmpty(item.Trim().ToUpper()) && item.ToString().Length == 13)
                    {
                        if (lstHD.FindItemWithText(item.Trim().ToUpper()) == null)
                        {
                            lstHD.Items.Add(item.Trim().ToUpper());
                            lstHD.EnsureVisible(lstHD.Items.Count - 1);
                        }
                    }
                    else
                        ///Trung An thêm 'K' phía cuối liên hóa đơn
                        if (!string.IsNullOrEmpty(item.Trim().ToUpper()) && item.ToString().Length == 14)
                        {
                            if (lstHD.FindItemWithText(item.Trim().ToUpper().Replace("K", "")) == null)
                            {
                                lstHD.Items.Add(item.Trim().ToUpper().Replace("K", ""));
                                lstHD.EnsureVisible(lstHD.Items.Count - 1);
                            }
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
                bool flagThem = false;
                if (radDaThu.Checked)
                {
                    if (MessageBox.Show("Bạn có chắc chắn chọn " + radDaThu.Text + "?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        flagThem = true;
                }
                else
                    if (radChuaThu.Checked)
                        if (MessageBox.Show("Bạn có chắc chắn chọn " + radChuaThu.Text + "?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            flagThem = true;
                if (dgvHDChuaThu.RowCount > 0 && flagThem && lstHD.Items.Count > 0)
                    if (radDaThu.Checked)
                    {
                        DataTable dt = (DataTable)dgvHDChuaThu.DataSource;
                        DataColumn[] keyColumns = new DataColumn[1];
                        keyColumns[0] = dt.Columns["SoHoaDon"];
                        dt.PrimaryKey = keyColumns;
                        //string loai;
                        foreach (ListViewItem item in lstHD.Items)
                        {
                            if (!dt.Rows.Contains(item.Text))
                            {
                                MessageBox.Show("Hóa Đơn sai: " + item.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                lstHD.Focus();
                                item.Selected = true;
                                item.Focused = true;
                                return;
                            }
                            //if (_cTamThu.CheckBySoHoaDon(item.ToString(),out loai))
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
                            if (_cHoaDon.CheckKhoaTienDuBySoHoaDon(item.Text))
                            {
                                MessageBox.Show("Hóa Đơn đã Khóa Tiền Dư " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                lstHD.Focus();
                                item.Selected = true;
                                item.Focused = true;
                                return;
                            }
                            if (_cHoaDon.CheckDCHDienDuBySoHoaDon(item.Text))
                            {
                                MessageBox.Show("Hóa Đơn đã DCHD Tiền Dư " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                lstHD.Focus();
                                item.Selected = true;
                                item.Focused = true;
                                return;
                            }
                        }
                        try
                        {
                            foreach (ListViewItem item in lstHD.Items)
                            {
                                ///ưu tiên đăng ngân hành thu, tự động xóa tạm thu chuyển qua thu 2 lần
                                bool ChuyenKhoan = false;
                                if (_cTamThu.CheckExist(item.Text, out ChuyenKhoan))
                                    using (var scope = new TransactionScope())
                                    {
                                        if (_cHoaDon.DangNgan("HanhThu", item.Text, CNguoiDung.MaND))
                                            if (_cHoaDon.Thu2Lan(item.Text, ChuyenKhoan))
                                                if (_cTamThu.XoaAn(item.Text))
                                                    if (_cTienDuQuay.UpdateXoa(item.Text, "Thu 2 Lần", "Thêm"))
                                                        scope.Complete();
                                    }
                                else
                                {
                                    _cHoaDon.DangNgan("HanhThu", item.Text, CNguoiDung.MaND);
                                }
                            }
                            //if (_cLenhHuy.CheckExist(item.ToString()))
                            //    if (!_cLenhHuy.Xoa(item.ToString()))
                            //    {
                            //        _cHoaDon.SqlRollbackTransaction();
                            //        MessageBox.Show("Lỗi Xóa Lệnh Hủy, Vui lòng thử lại \r\n" + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //        return;
                            //    }
                            btnXem.PerformClick();
                            lstHD.Items.Clear();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        ///Đăng Ngân tất cả trừ những Hóa Đơn Quét
                        if (radChuaThu.Checked)
                        {
                            if (dgvHDDaThu.Rows.Count > 0)
                            {
                                MessageBox.Show("Đã Đăng Ngân trước đó\nKhông thể Quét theo kiểu  " + radChuaThu.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            DataTable dt = (DataTable)dgvHDChuaThu.DataSource;
                            DataColumn[] keyColumns = new DataColumn[1];
                            keyColumns[0] = dt.Columns["SoHoaDon"];
                            dt.PrimaryKey = keyColumns;
                            //string loai;
                            foreach (ListViewItem item in lstHD.Items)
                            {
                                if (!dt.Rows.Contains(item.Text))
                                {
                                    MessageBox.Show("Hóa Đơn sai: " + item.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    lstHD.Focus();
                                    item.Selected = true;
                                    item.Focused = true;
                                    return;
                                }
                                //if (_cTamThu.CheckBySoHoaDon(item.ToString(),out loai))
                                //{
                                //    MessageBox.Show("Hóa Đơn đã được "+loai+": " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //    lstHD.SelectedItem = item;
                                //    return;
                                //}
                                if (_cHoaDon.CheckKhoaTienDuBySoHoaDon(item.Text))
                                {
                                    MessageBox.Show("Hóa Đơn đã Khóa Tiền Dư " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    lstHD.Focus();
                                    item.Selected = true;
                                    item.Focused = true;
                                    return;
                                }
                                if (_cHoaDon.CheckDCHDienDuBySoHoaDon(item.Text))
                                {
                                    MessageBox.Show("Hóa Đơn đã DCHD Tiền Dư " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    lstHD.Focus();
                                    item.Selected = true;
                                    item.Focused = true;
                                    return;
                                }
                            }
                            try
                            {
                                //_cHoaDon.SqlBeginTransaction();
                                foreach (DataRow item in dt.Rows)
                                    if (lstHD.FindItemWithText(item["SoHoaDon"].ToString()) == null)
                                    {
                                        ///ưu tiên đăng ngân hành thu, tự động xóa tạm thu chuyển qua thu 2 lần
                                        bool ChuyenKhoan = false;
                                        if (_cTamThu.CheckExist(item["SoHoaDon"].ToString(), out ChuyenKhoan))
                                            using (var scope = new TransactionScope())
                                            {
                                                if (_cHoaDon.DangNgan("HanhThu", item["SoHoaDon"].ToString(), CNguoiDung.MaND))
                                                    if (_cHoaDon.Thu2Lan(item["SoHoaDon"].ToString(), ChuyenKhoan))
                                                        if (_cTamThu.XoaAn(item["SoHoaDon"].ToString()))
                                                            if (_cTienDuQuay.UpdateXoa(item["SoHoaDon"].ToString(), "Thu 2 Lần", "Thêm"))
                                                                scope.Complete();
                                            }
                                        else
                                        {
                                            _cHoaDon.DangNgan("HanhThu", item["SoHoaDon"].ToString(), CNguoiDung.MaND);
                                        }
                                        //if (_cLenhHuy.CheckExist(item.ToString()))
                                        //    if (!_cLenhHuy.Xoa(item.ToString()))
                                        //    {
                                        //        _cHoaDon.SqlRollbackTransaction();
                                        //        MessageBox.Show("Lỗi Xóa Lệnh Hủy, Vui lòng thử lại \r\n" + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        //        return;
                                        //    }
                                    }
                                btnXem.PerformClick();
                                lstHD.Items.Clear();
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception)
                            {
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
                    //if (_selectedindexDaThu != -1)
                    //{
                    //    if (_cHoaDon.XoaDangNgan("HanhThu",dgvHDDaThu["SoHoaDon_DT", _selectedindexDaThu].Value.ToString(), CNguoiDung.MaND, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString())))
                    //    {
                    //        //LoadDanhSachHD();
                    //        //_selectedindexDaThu = -1;
                    //    }
                    //}
                    //else
                    //    MessageBox.Show("Lỗi, Vui lòng chọn Hóa Đơn(đã thu) cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    foreach (DataGridViewRow item in dgvHDDaThu.SelectedRows)
                    {
                        if (_cHoaDon.GetNgayGiaiTrach(item.Cells["SoHoaDon_DT"].Value.ToString()).Date != DateTime.Now.Date)
                        {
                            MessageBox.Show("Chỉ được Điều Chỉnh Đăng Ngân trong ngày", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    try
                    {
                        //_cHoaDon.SqlBeginTransaction();
                        foreach (DataGridViewRow item in dgvHDDaThu.SelectedRows)
                        {
                            if (!_cHoaDon.XoaDangNgan("HanhThu", item.Cells["SoHoaDon_DT"].Value.ToString(), CNguoiDung.MaND))
                            {
                                //_cHoaDon.SqlRollbackTransaction();
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        //_cHoaDon.SqlCommitTransaction();
                        LoadDataGridView();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //_selectedindexDaThu = -1;
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

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabDaThu")
            {
                foreach (DataGridViewRow item in dgvHDDaThu.Rows)
                {
                    DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                    dr["LoaiBaoCao"] = "TƯ GIA ĐÃ THU";
                    dr["DanhBo"] = item.Cells["DanhBo_DT"].Value.ToString().Insert(4, " ").Insert(8, " ");
                    dr["Ky"] = item.Cells["Ky_DT"].Value;
                    dr["MLT"] = item.Cells["MLT_DT"].Value.ToString().Insert(4, " ").Insert(2, " ");
                    dr["TongCong"] = item.Cells["TongCong_DT"].Value;
                    dr["SoPhatHanh"] = item.Cells["SoPhatHanh_DT"].Value;
                    dr["SoHoaDon"] = item.Cells["SoHoaDon_DT"].Value;
                    if (CNguoiDung.ToTruong)
                        dr["NhanVien"] = ((TT_NguoiDung)cmbNhanVien.SelectedItem).HoTen;
                    else
                        dr["NhanVien"] = CNguoiDung.HoTen;
                    ds.Tables["DSHoaDon"].Rows.Add(dr);
                }
            }
            else
                if (tabControl.SelectedTab.Name == "tabChuaThu")
                {
                    foreach (DataGridViewRow item in dgvHDChuaThu.Rows)
                    {
                        DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                        dr["LoaiBaoCao"] = "TƯ GIA CHƯA THU";
                        dr["DanhBo"] = item.Cells["DanhBo_CT"].Value.ToString().Insert(4, " ").Insert(8, " ");
                        dr["Ky"] = item.Cells["Ky_CT"].Value;
                        dr["MLT"] = item.Cells["MLT_CT"].Value.ToString().Insert(4, " ").Insert(2, " ");
                        dr["TongCong"] = item.Cells["TongCong_CT"].Value;
                        dr["SoPhatHanh"] = item.Cells["SoPhatHanh_CT"].Value;
                        dr["SoHoaDon"] = item.Cells["SoHoaDon_CT"].Value;
                        if (CNguoiDung.ToTruong)
                            dr["NhanVien"] = ((TT_NguoiDung)cmbNhanVien.SelectedItem).HoTen;
                        else
                            dr["NhanVien"] = CNguoiDung.HoTen;
                        ds.Tables["DSHoaDon"].Rows.Add(dr);
                    }
                }
            rptDSHoaDon rpt = new rptDSHoaDon();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void dateDangNgan_ValueChanged(object sender, EventArgs e)
        {
            //_flagNgayDangNgan = true;
            cmbKy.SelectedIndex = -1;
            cmbDot.SelectedIndex = -1;
            dgvHDDaThu.DataSource = _cHoaDon.GetDSDangNganHanhThu("TG", CNguoiDung.MaND, dateDangNgan.Value);
            dgvHDChuaThu.Rows.Clear();
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            DataTable dt = _cHoaDon.GetTongDangNgan("TG", CNguoiDung.MaND, dateDangNgan.Value);
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = ds.Tables["PhieuDangNgan"].NewRow();
                dr["To"] = CNguoiDung.TenTo;
                dr["Loai"] = "Tư Gia";
                dr["NgayDangNgan"] = dateDangNgan.Value.Date.ToString("dd/MM/yyyy");
                dr["TongHD"] = item["TongHD"].ToString();
                dr["TongGiaBan"] = item["TongGiaBan"].ToString();
                dr["TongThueGTGT"] = item["TongThueGTGT"].ToString();
                dr["TongPhiBVMT"] = item["TongPhiBVMT"].ToString();
                dr["TongCong"] = item["TongCong"].ToString();
                if (CNguoiDung.ToTruong)
                    dr["NhanVien"] = ((TT_NguoiDung)cmbNhanVien.SelectedItem).HoTen;
                else
                    dr["NhanVien"] = CNguoiDung.HoTen;
                ds.Tables["PhieuDangNgan"].Rows.Add(dr);
            }

            //dt = _cHoaDon.GetTongDangNganByMaNV_DangNganNgayDangNgan(CNguoiDung.MaND, "CQ", dateDangNgan.Value);
            //foreach (DataRow item in dt.Rows)
            //{
            //    DataRow dr = ds.Tables["PhieuDangNgan"].NewRow();
            //    dr["To"] = CNguoiDung.TenTo;
            //    dr["Loai"] = "Cơ Quan";
            //    dr["NgayDangNgan"] = dateDangNgan.Value.Date.ToString("dd/MM/yyyy");
            //    dr["TongHD"] = item["TongHD"].ToString();
            //    dr["TongGiaBan"] = item["TongGiaBan"].ToString();
            //    dr["TongThueGTGT"] = item["TongThueGTGT"].ToString();
            //    dr["TongPhiBVMT"] = item["TongPhiBVMT"].ToString();
            //    dr["TongCong"] = item["TongCong"].ToString();
            //    dr["NhanVien"] = CNguoiDung.HoTen;
            //    ds.Tables["PhieuDangNgan"].Rows.Add(dr);
            //}

            rptPhieuDangNgan rpt = new rptPhieuDangNgan();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void dgvTongHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTongHD.Columns[e.ColumnIndex].Name == "Loai" && e.Value != null)
            {
                if (bool.Parse(e.Value.ToString()))
                    e.Value = "TG";
                else
                    e.Value = "CQ";
            }
            if (dgvTongHD.Columns[e.ColumnIndex].Name == "TongHD" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTongHD.Columns[e.ColumnIndex].Name == "TongTieuThu" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTongHD.Columns[e.ColumnIndex].Name == "TongGiaBan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTongHD.Columns[e.ColumnIndex].Name == "TongThueGTGT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTongHD.Columns[e.ColumnIndex].Name == "TongPhiBVMT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTongHD.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHDDaThu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDDaThu.Columns[e.ColumnIndex].Name == "MLT_DT" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(2, " ");
            }
            if (dgvHDDaThu.Columns[e.ColumnIndex].Name == "DanhBo_DT" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHDDaThu.Columns[e.ColumnIndex].Name == "TieuThu_DT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDDaThu.Columns[e.ColumnIndex].Name == "GiaBan_DT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDDaThu.Columns[e.ColumnIndex].Name == "ThueGTGT_DT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDDaThu.Columns[e.ColumnIndex].Name == "PhiBVMT_DT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDDaThu.Columns[e.ColumnIndex].Name == "TongCong_DT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHDChuaThu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDChuaThu.Columns[e.ColumnIndex].Name == "MLT_CT" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(2, " ");
            }
            if (dgvHDChuaThu.Columns[e.ColumnIndex].Name == "DanhBo_CT" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHDChuaThu.Columns[e.ColumnIndex].Name == "TieuThu_CT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDChuaThu.Columns[e.ColumnIndex].Name == "GiaBan_CT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDChuaThu.Columns[e.ColumnIndex].Name == "ThueGTGT_CT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDChuaThu.Columns[e.ColumnIndex].Name == "PhiBVMT_CT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDChuaThu.Columns[e.ColumnIndex].Name == "TongCong_CT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHDDaThu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHDDaThu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvHDChuaThu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHDChuaThu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvHDDaThu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //_selectedindexDaThu = e.RowIndex;
            }
            catch (Exception)
            {
            }
        }

        private void dgvHDDaThuDum_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDDaThuDum.Columns[e.ColumnIndex].Name == "TongHD_Dum" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDDaThuDum.Columns[e.ColumnIndex].Name == "TongCong_Dum" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
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

        private void dgvHDDaThuDum_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvHDDaThuDum.RowCount > 0 && e.Button == MouseButtons.Left)
            {
                string[] time=dgvHDDaThuDum["NgayGiaiTrach_Dum", e.RowIndex].Value.ToString().Split(' ');
                string[] date=time[0].Split('/');
                DateTime NgayGiaiTrach=new DateTime(int.Parse(date[2]), int.Parse(date[1]),int.Parse(date[0]));

                DataTable dt=new DataTable();
                if(string.IsNullOrEmpty(dgvHDDaThuDum["MaNV_DangNgan", e.RowIndex].Value.ToString()))
                    dt= _cHoaDon.GetDSDangNganDum(int.Parse(dgvHDDaThuDum["MaNV_HanhThu", e.RowIndex].Value.ToString()), null, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), NgayGiaiTrach);
                else
                    dt = _cHoaDon.GetDSDangNganDum(int.Parse(dgvHDDaThuDum["MaNV_HanhThu", e.RowIndex].Value.ToString()), int.Parse(dgvHDDaThuDum["MaNV_DangNgan", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), NgayGiaiTrach);

                dsBaoCao ds = new dsBaoCao();
                foreach (DataRow item in dt.Rows)
                {
                    DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                    dr["LoaiBaoCao"] = "ĐÃ THU";
                    dr["DanhBo"] = item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
                    dr["Ky"] = item["Ky"];
                    dr["MLT"] = item["MLT"];
                    dr["TongCong"] = item["TongCong"];
                    dr["SoPhatHanh"] = item["SoPhatHanh"];
                    dr["SoHoaDon"] = item["SoHoaDon"];
                    dr["NhanVien"] = dgvHDDaThuDum["HoTen", e.RowIndex].Value.ToString();
                    ds.Tables["DSHoaDon"].Rows.Add(dr);
                }

                rptDSHoaDon rpt = new rptDSHoaDon();
                rpt.SetDataSource(ds);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.ShowDialog();
            }
        }

        private void btnHuyDangNgan_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn Xóa Đăng Ngân Năm " + cmbNam.SelectedValue.ToString() + " Kỳ " + cmbKy.SelectedItem.ToString() + " Đợt " + cmbDot.SelectedItem.ToString(), "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    if (_cHoaDon.CheckCoTheXoaDangNgan(CNguoiDung.MaND, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString())))
                    {
                        DataTable dt = _cHoaDon.GetDSDangNganHanhThuTG(CNguoiDung.MaND, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
                        foreach (DataRow item in dt.Rows)
                        {
                            _cHoaDon.XoaDangNgan("HanhThu", item["SoHoaDon"].ToString(), CNguoiDung.MaND);
                        }
                        LoadDataGridView();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Đã quá thời gian được xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);    
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
