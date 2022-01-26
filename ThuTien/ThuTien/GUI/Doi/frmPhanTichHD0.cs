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
using ThuTien.LinQ;
using ThuTien.BaoCao;
using ThuTien.BaoCao.Doi;
using ThuTien.GUI.BaoCao;
using ThuTien.DAL.ChuyenKhoan;

namespace ThuTien.GUI.Doi
{
    public partial class frmPhanTichHD0 : Form
    {
        string _mnu = "mnuPhanTichHD0";
        CTo _cTo = new CTo();
        CHoaDon _cHoaDon = new CHoaDon();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CDangKyHD0 _cDangKyHD0 = new CDangKyHD0();
        CDangKy _cDangKy = new CDangKy();
        CDangKy2 _cDangKy2 = new CDangKy2();
        List<TT_To> _lstTo;

        public frmPhanTichHD0()
        {
            InitializeComponent();
        }

        private void frmPhanTichHD0_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
            dgvDSTongHD0.AutoGenerateColumns = false;
            dgvDanhBoDK.AutoGenerateColumns = false;
            dgvDanhBoDK2.AutoGenerateColumns = false;
            dgvDangKy3.AutoGenerateColumns = false;

            _lstTo = _cTo.getDS();
            TT_To to = new TT_To();
            to.MaTo = 0;
            to.TenTo = "Tất Cả";
            _lstTo.Insert(0, to);
            cmbTo.DataSource = _lstTo;
            cmbTo.DisplayMember = "TenTo";
            cmbTo.ValueMember = "MaTo";

            DataTable dt = _cHoaDon.GetNam();
            cmbNam.DataSource = dt;
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";

            cmbToDK.DataSource = _lstTo;
            cmbToDK.DisplayMember = "TenTo";
            cmbToDK.ValueMember = "MaTo";

            cmbNamDK.DataSource = dt;
            cmbNamDK.DisplayMember = "Nam";
            cmbNamDK.ValueMember = "Nam";

            cmbKy.SelectedItem = DateTime.Now.Month.ToString();
            cmbDot.SelectedIndex = 0;

            cmbToDK2.DataSource = _lstTo;
            cmbToDK2.DisplayMember = "TenTo";
            cmbToDK2.ValueMember = "MaTo";

            cmbNamDK2.DataSource = dt;
            cmbNamDK2.DisplayMember = "Nam";
            cmbNamDK2.ValueMember = "Nam";

            cmbNam3.DataSource = dt;
            cmbNam3.DisplayMember = "Nam";
            cmbNam3.ValueMember = "Nam";
        }

        public void CountdgvDanhBoDK()
        {
            int Ky1 = 0;
            int Ky2 = 0;
            int Ky3 = 0;
            int Ky4 = 0;
            int Ky5 = 0;
            int Ky6 = 0;
            int Ky7 = 0;
            int Ky8 = 0;
            int Ky9 = 0;
            int Ky10 = 0;
            int Ky11 = 0;
            int Ky12 = 0;
            foreach (DataGridViewRow item in dgvDanhBoDK.Rows)
            {
                if (item.Cells["Ky1_DK"] != null && item.Cells["Ky1_DK"].Value.ToString() != "" && int.Parse(item.Cells["Ky1_DK"].Value.ToString()) != 0)
                    Ky1++;
                if (item.Cells["Ky2_DK"] != null && item.Cells["Ky2_DK"].Value.ToString() != "" && int.Parse(item.Cells["Ky2_DK"].Value.ToString()) != 0)
                    Ky2++;
                if (item.Cells["Ky3_DK"] != null && item.Cells["Ky3_DK"].Value.ToString() != "" && int.Parse(item.Cells["Ky3_DK"].Value.ToString()) != 0)
                    Ky3++;
                if (item.Cells["Ky4_DK"] != null && item.Cells["Ky4_DK"].Value.ToString() != "" && int.Parse(item.Cells["Ky4_DK"].Value.ToString()) != 0)
                    Ky4++;
                if (item.Cells["Ky5_DK"] != null && item.Cells["Ky5_DK"].Value.ToString() != "" && int.Parse(item.Cells["Ky5_DK"].Value.ToString()) != 0)
                    Ky5++;
                if (item.Cells["Ky6_DK"] != null && item.Cells["Ky6_DK"].Value.ToString() != "" && int.Parse(item.Cells["Ky6_DK"].Value.ToString()) != 0)
                    Ky6++;
                if (item.Cells["Ky7_DK"] != null && item.Cells["Ky7_DK"].Value.ToString() != "" && int.Parse(item.Cells["Ky7_DK"].Value.ToString()) != 0)
                    Ky7++;
                if (item.Cells["Ky8_DK"] != null && item.Cells["Ky8_DK"].Value.ToString() != "" && int.Parse(item.Cells["Ky8_DK"].Value.ToString()) != 0)
                    Ky8++;
                if (item.Cells["Ky9_DK"] != null && item.Cells["Ky9_DK"].Value.ToString() != "" && int.Parse(item.Cells["Ky9_DK"].Value.ToString()) != 0)
                    Ky9++;
                if (item.Cells["Ky10_DK"] != null && item.Cells["Ky10_DK"].Value.ToString() != "" && int.Parse(item.Cells["Ky10_DK"].Value.ToString()) != 0)
                    Ky10++;
                if (item.Cells["Ky11_DK"] != null && item.Cells["Ky11_DK"].Value.ToString() != "" && int.Parse(item.Cells["Ky11_DK"].Value.ToString()) != 0)
                    Ky11++;
                if (item.Cells["Ky12_DK"] != null && item.Cells["Ky12_DK"].Value.ToString() != "" && int.Parse(item.Cells["Ky12_DK"].Value.ToString()) != 0)
                    Ky12++;
            }
            txtTong.Text = dgvDanhBoDK.Rows.Count.ToString();
            txtKy1.Text = Ky1.ToString();
            txtKy2.Text = Ky2.ToString();
            txtKy3.Text = Ky3.ToString();
            txtKy4.Text = Ky4.ToString();
            txtKy5.Text = Ky5.ToString();
            txtKy6.Text = Ky6.ToString();
            txtKy7.Text = Ky7.ToString();
            txtKy8.Text = Ky8.ToString();
            txtKy9.Text = Ky9.ToString();
            txtKy10.Text = Ky10.ToString();
            txtKy11.Text = Ky11.ToString();
            txtKy12.Text = Ky12.ToString();
        }

        public void CountdgvDanhBoDK2()
        {
            int Ky1 = 0;
            int Ky2 = 0;
            int Ky3 = 0;
            int Ky4 = 0;
            int Ky5 = 0;
            int Ky6 = 0;
            int Ky7 = 0;
            int Ky8 = 0;
            int Ky9 = 0;
            int Ky10 = 0;
            int Ky11 = 0;
            int Ky12 = 0;
            foreach (DataGridViewRow item in dgvDanhBoDK2.Rows)
            {
                if (item.Cells["Ky1_DK2"] != null && item.Cells["Ky1_DK2"].Value.ToString() != "" && int.Parse(item.Cells["Ky1_DK2"].Value.ToString()) != 0)
                    Ky1++;
                if (item.Cells["Ky2_DK2"] != null && item.Cells["Ky2_DK2"].Value.ToString() != "" && int.Parse(item.Cells["Ky2_DK2"].Value.ToString()) != 0)
                    Ky2++;
                if (item.Cells["Ky3_DK2"] != null && item.Cells["Ky3_DK2"].Value.ToString() != "" && int.Parse(item.Cells["Ky3_DK2"].Value.ToString()) != 0)
                    Ky3++;
                if (item.Cells["Ky4_DK2"] != null && item.Cells["Ky4_DK2"].Value.ToString() != "" && int.Parse(item.Cells["Ky4_DK2"].Value.ToString()) != 0)
                    Ky4++;
                if (item.Cells["Ky5_DK2"] != null && item.Cells["Ky5_DK2"].Value.ToString() != "" && int.Parse(item.Cells["Ky5_DK2"].Value.ToString()) != 0)
                    Ky5++;
                if (item.Cells["Ky6_DK2"] != null && item.Cells["Ky6_DK2"].Value.ToString() != "" && int.Parse(item.Cells["Ky6_DK2"].Value.ToString()) != 0)
                    Ky6++;
                if (item.Cells["Ky7_DK2"] != null && item.Cells["Ky7_DK2"].Value.ToString() != "" && int.Parse(item.Cells["Ky7_DK2"].Value.ToString()) != 0)
                    Ky7++;
                if (item.Cells["Ky8_DK2"] != null && item.Cells["Ky8_DK2"].Value.ToString() != "" && int.Parse(item.Cells["Ky8_DK2"].Value.ToString()) != 0)
                    Ky8++;
                if (item.Cells["Ky9_DK2"] != null && item.Cells["Ky9_DK2"].Value.ToString() != "" && int.Parse(item.Cells["Ky9_DK2"].Value.ToString()) != 0)
                    Ky9++;
                if (item.Cells["Ky10_DK2"] != null && item.Cells["Ky10_DK2"].Value.ToString() != "" && int.Parse(item.Cells["Ky10_DK2"].Value.ToString()) != 0)
                    Ky10++;
                if (item.Cells["Ky11_DK2"] != null && item.Cells["Ky11_DK2"].Value.ToString() != "" && int.Parse(item.Cells["Ky11_DK2"].Value.ToString()) != 0)
                    Ky11++;
                if (item.Cells["Ky12_DK2"] != null && item.Cells["Ky12_DK2"].Value.ToString() != "" && int.Parse(item.Cells["Ky12_DK2"].Value.ToString()) != 0)
                    Ky12++;
            }
            txtTong2.Text = dgvDanhBoDK2.Rows.Count.ToString();
            txtKy1_2.Text = Ky1.ToString();
            txtKy2_2.Text = Ky2.ToString();
            txtKy3_2.Text = Ky3.ToString();
            txtKy4_2.Text = Ky4.ToString();
            txtKy5_2.Text = Ky5.ToString();
            txtKy6_2.Text = Ky6.ToString();
            txtKy7_2.Text = Ky7.ToString();
            txtKy8_2.Text = Ky8.ToString();
            txtKy9_2.Text = Ky9.ToString();
            txtKy10_2.Text = Ky10.ToString();
            txtKy11_2.Text = Ky11.ToString();
            txtKy12_2.Text = Ky12.ToString();
        }

        private void cmbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTo.SelectedIndex > 0)
            {
                List<TT_NguoiDung> lstND = _cNguoiDung.GetDSHanhThuByMaTo(int.Parse(cmbTo.SelectedValue.ToString()));
                TT_NguoiDung nguoidung = new TT_NguoiDung();
                nguoidung.MaND = 0;
                nguoidung.HoTen = "Tất Cả";
                lstND.Insert(0, nguoidung);
                cmbNhanVien.DataSource = lstND;
                cmbNhanVien.DisplayMember = "HoTen";
                cmbNhanVien.ValueMember = "MaND";
            }
            else
            {
                cmbNhanVien.DataSource = null;
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            ///chọn tất cả tổ
            if (cmbTo.SelectedIndex == 0)
            {
                if (cmbKy.SelectedIndex == 0)
                    dgvHoaDon.DataSource = _cHoaDon.GetDSHoaDon0(int.Parse(cmbNam.SelectedValue.ToString()), txtGiaBieu.Text.Trim(), txtDinhMuc.Text.Trim(), txtCode.Text.Trim());
                else
                    if (cmbKy.SelectedIndex > 0)
                        if (cmbDot.SelectedIndex == 0)
                            dgvHoaDon.DataSource = _cHoaDon.GetDSHoaDon0(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), txtGiaBieu.Text.Trim(), txtDinhMuc.Text.Trim(), txtCode.Text.Trim());
                        else
                            if (cmbDot.SelectedIndex > 0)
                                if (cmbDenDot.SelectedIndex == 0)
                                    dgvHoaDon.DataSource = _cHoaDon.GetDSHoaDon0(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), txtGiaBieu.Text.Trim(), txtDinhMuc.Text.Trim(), txtCode.Text.Trim());
                                else
                                    if (cmbDenDot.SelectedIndex > 0)
                                        dgvHoaDon.DataSource = _cHoaDon.GetDSHoaDon0(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), int.Parse(cmbDenDot.SelectedItem.ToString()), txtGiaBieu.Text.Trim(), txtDinhMuc.Text.Trim(), txtCode.Text.Trim());
                dgvDSTongHD0.DataSource = _cHoaDon.GetGroupHD0(int.Parse(cmbNam.SelectedValue.ToString()));
            }
            else
                ///chọn 1 tổ cụ thể
                if (cmbTo.SelectedIndex > 0)
                {
                    ///chọn tất cả nhân viên
                    if (cmbNhanVien.SelectedIndex == 0)
                    {
                        if (cmbKy.SelectedIndex == 0)
                            dgvHoaDon.DataSource = _cHoaDon.GetDSHoaDon0_To(int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), txtGiaBieu.Text.Trim(), txtDinhMuc.Text.Trim(), txtCode.Text.Trim());
                        else
                            if (cmbKy.SelectedIndex > 0)
                                if (cmbDot.SelectedIndex == 0)
                                    dgvHoaDon.DataSource = _cHoaDon.GetDSHoaDon0_To(int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), txtGiaBieu.Text.Trim(), txtDinhMuc.Text.Trim(), txtCode.Text.Trim());
                                else
                                    if (cmbDot.SelectedIndex > 0)
                                        if (cmbDenDot.SelectedIndex == 0)
                                            dgvHoaDon.DataSource = _cHoaDon.GetDSHoaDon0_To(int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), txtGiaBieu.Text.Trim(), txtDinhMuc.Text.Trim(), txtCode.Text.Trim());
                                        else
                                            if (cmbDenDot.SelectedIndex > 0)
                                                dgvHoaDon.DataSource = _cHoaDon.GetDSHoaDon0_To(int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), int.Parse(cmbDenDot.SelectedItem.ToString()), txtGiaBieu.Text.Trim(), txtDinhMuc.Text.Trim(), txtCode.Text.Trim());
                        dgvDSTongHD0.DataSource = _cHoaDon.GetGroupHD0_To(int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()));
                    }
                    else
                        ///chọn 1 nhân viên cụ thể
                        if (cmbNhanVien.SelectedIndex > 0)
                        {
                            if (cmbKy.SelectedIndex == 0)
                                dgvHoaDon.DataSource = _cHoaDon.GetDSHoaDon0_NV(int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), txtGiaBieu.Text.Trim(), txtDinhMuc.Text.Trim(), txtCode.Text.Trim());
                            else
                                if (cmbKy.SelectedIndex > 0)
                                    if (cmbDot.SelectedIndex == 0)
                                        dgvHoaDon.DataSource = _cHoaDon.GetDSHoaDon0_NV(int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), txtGiaBieu.Text.Trim(), txtDinhMuc.Text.Trim(), txtCode.Text.Trim());
                                    else
                                        if (cmbDot.SelectedIndex > 0)
                                            if (cmbDenDot.SelectedIndex == 0)
                                                dgvHoaDon.DataSource = _cHoaDon.GetDSHoaDon0_NV(int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), txtGiaBieu.Text.Trim(), txtDinhMuc.Text.Trim(), txtCode.Text.Trim());
                                            else
                                                if (cmbDenDot.SelectedIndex > 0)
                                                    dgvHoaDon.DataSource = _cHoaDon.GetDSHoaDon0_NV(int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), int.Parse(cmbDenDot.SelectedItem.ToString()), txtGiaBieu.Text.Trim(), txtDinhMuc.Text.Trim(), txtCode.Text.Trim());
                            dgvDSTongHD0.DataSource = _cHoaDon.GetGroupHD0_NV(int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()));
                        }
                }
            txtTongHD.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", dgvHoaDon.Rows.Count);
            for (int i = 1; i < dgvDSTongHD0.Rows.Count; i++)
            {
                dgvDSTongHD0["BienDong", i].Value = int.Parse(dgvDSTongHD0["TongHD", i].Value.ToString()) - int.Parse(dgvDSTongHD0["TongHD", i - 1].Value.ToString());
            }
        }

        private void dgvHoaDon_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHoaDon.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
        }

        private void cmbToDK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbToDK.SelectedIndex > 0)
            {
                List<TT_NguoiDung> lstND = null;
                if ((_cTo.checkHanhThu(int.Parse(cmbToDK.SelectedValue.ToString()))))
                {
                    lstND = _cNguoiDung.GetDSHanhThuByMaTo(int.Parse(cmbToDK.SelectedValue.ToString()));
                    TT_NguoiDung nguoidung = new TT_NguoiDung();
                    nguoidung.MaND = 0;
                    nguoidung.HoTen = "Tất Cả";
                    lstND.Insert(0, nguoidung);

                }
                else
                {
                    lstND = _cNguoiDung.GetDSByToVanPhong(int.Parse(cmbToDK.SelectedValue.ToString()));
                }
                cmbNhanVienDK.DataSource = lstND;
                cmbNhanVienDK.DisplayMember = "HoTen";
                cmbNhanVienDK.ValueMember = "MaND";
            }
            else
            {
                cmbNhanVienDK.DataSource = null;
            }
        }

        private void btnXemDK_Click(object sender, EventArgs e)
        {
            ///chọn tất cả tổ
            if (cmbToDK.SelectedIndex == 0)
            {
                DataTable dt = new DataTable();
                foreach (TT_To itemTo in _lstTo)
                {
                    List<TT_NguoiDung> lstND = _cNguoiDung.GetDSHanhThuByMaTo(itemTo.MaTo);
                    foreach (TT_NguoiDung itemND in lstND)
                    {
                        dt.Merge(_cDangKyHD0.GetDS(itemND.MaND, int.Parse(cmbNamDK.SelectedValue.ToString())));
                    }
                }
                dgvDanhBoDK.DataSource = dt;
            }
            else
                ///chọn 1 tổ cụ thể
                if (cmbToDK.SelectedIndex > 0)
                    ///chọn tất cả nhân viên
                    if (cmbNhanVienDK.SelectedIndex == 0)
                    {
                        DataTable dt = new DataTable();
                        List<TT_NguoiDung> lstND = _cNguoiDung.GetDSHanhThuByMaTo(int.Parse(cmbToDK.SelectedValue.ToString()));
                        foreach (TT_NguoiDung itemND in lstND)
                        {
                            dt.Merge(_cDangKyHD0.GetDS(itemND.MaND, int.Parse(cmbNamDK.SelectedValue.ToString())));
                        }
                        dgvDanhBoDK.DataSource = dt;
                    }
                    else
                        ///chọn 1 nhân viên cụ thể
                        if (cmbNhanVienDK.SelectedIndex > 0)
                        {
                            dgvDanhBoDK.DataSource = _cDangKyHD0.GetDS(int.Parse(cmbNhanVienDK.SelectedValue.ToString()), int.Parse(cmbNamDK.SelectedValue.ToString()));
                        }
            CountdgvDanhBoDK();
        }

        private void btnThemDK_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                if (txtDanhBoDK.Text.Trim().Replace(" ", "") != "")
                {
                    if (cmbNhanVienDK.Items.Count == 0 || cmbNhanVienDK.SelectedIndex == 0)
                    {
                        MessageBox.Show("Chưa chọn Nhân Viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (_cDangKyHD0.CheckExist(txtDanhBoDK.Text.Trim().Replace(" ", "")) == true)
                    {
                        MessageBox.Show(_cDangKyHD0.GetHoTen(txtDanhBoDK.Text.Trim().Replace(" ", "")) + " đã đăng ký " + txtDanhBoDK.Text.Trim().Replace(" ", ""), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    TT_DangKyHD0 dangky = new TT_DangKyHD0();
                    dangky.DanhBo = txtDanhBoDK.Text.Trim().Replace(" ", "");
                    dangky.MaNV = int.Parse(cmbNhanVienDK.SelectedValue.ToString());

                    if (_cDangKyHD0.Them(dangky))
                    {
                        txtDanhBoDK.Text = "";
                        btnXemDK.PerformClick();
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoaDK_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    foreach (DataGridViewRow item in dgvDanhBoDK.SelectedRows)
                    {
                        TT_DangKyHD0 dangky = _cDangKyHD0.Get(item.Cells["DanhBo_DK"].Value.ToString());
                        _cDangKyHD0.Xoa(dangky);
                    }
                    btnXemDK.PerformClick();
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtDanhBoDK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBoDK.Text.Length == 11)
                btnThemDK.PerformClick();
        }

        private void dgvDanhBoDK_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDanhBoDK.Columns[e.ColumnIndex].Name == "DanhBo_DK" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
        }

        private void dgvDanhBoDK_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhBoDK.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvDanhBoDK.Rows)
            {
                DataRow dr = ds.Tables["DangKyHD0"].NewRow();
                dr["NhanVien"] = item.Cells["HoTen_DK"].Value;
                dr["DanhBo"] = item.Cells["DanhBo_DK"].Value.ToString().Insert(7, " ").Insert(4, " ");
                dr["DiaChi"] = item.Cells["DiaChi_DK"].Value;
                dr["Ky1"] = item.Cells["Ky1_DK"].Value;
                dr["Ky2"] = item.Cells["Ky2_DK"].Value;
                dr["Ky3"] = item.Cells["Ky3_DK"].Value;
                dr["Ky4"] = item.Cells["Ky4_DK"].Value;
                dr["Ky5"] = item.Cells["Ky5_DK"].Value;
                dr["Ky6"] = item.Cells["Ky6_DK"].Value;
                dr["Ky7"] = item.Cells["Ky7_DK"].Value;
                dr["Ky8"] = item.Cells["Ky8_DK"].Value;
                dr["Ky9"] = item.Cells["Ky9_DK"].Value;
                dr["Ky10"] = item.Cells["Ky10_DK"].Value;
                dr["Ky11"] = item.Cells["Ky11_DK"].Value;
                dr["Ky12"] = item.Cells["Ky12_DK"].Value;
                ds.Tables["DangKyHD0"].Rows.Add(dr);
            }

            rptDangKyHD0 rpt = new rptDangKyHD0();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void btnInThongKe_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvDanhBoDK.Rows)
            {
                DataRow dr = ds.Tables["DangKyHD0"].NewRow();
                dr["To"] = item.Cells["TenTo_DK"].Value;
                dr["NhanVien"] = item.Cells["HoTen_DK"].Value;
                dr["DanhBo"] = item.Cells["DanhBo_DK"].Value.ToString().Insert(7, " ").Insert(4, " ");
                dr["DiaChi"] = item.Cells["DiaChi_DK"].Value;
                dr["Ky1"] = item.Cells["Ky1_DK"].Value;
                dr["Ky2"] = item.Cells["Ky2_DK"].Value;
                dr["Ky3"] = item.Cells["Ky3_DK"].Value;
                dr["Ky4"] = item.Cells["Ky4_DK"].Value;
                dr["Ky5"] = item.Cells["Ky5_DK"].Value;
                dr["Ky6"] = item.Cells["Ky6_DK"].Value;
                dr["Ky7"] = item.Cells["Ky7_DK"].Value;
                dr["Ky8"] = item.Cells["Ky8_DK"].Value;
                dr["Ky9"] = item.Cells["Ky9_DK"].Value;
                dr["Ky10"] = item.Cells["Ky10_DK"].Value;
                dr["Ky11"] = item.Cells["Ky11_DK"].Value;
                dr["Ky12"] = item.Cells["Ky12_DK"].Value;
                ds.Tables["DangKyHD0"].Rows.Add(dr);
            }

            rptThongKeDangKyHD0 rpt = new rptThongKeDangKyHD0();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void btnInThongKeCode_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            ///chọn tất cả tổ
            if (cmbTo.SelectedIndex == 0)
            {
                if (cmbKy.SelectedIndex == 0)
                { }
                else
                    if (cmbKy.SelectedIndex > 0)
                        if (cmbDot.SelectedIndex == 0)
                            dt = _cHoaDon.ThongKeHD0_Code(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                        else
                            if (cmbDot.SelectedIndex > 0)
                                if (cmbDenDot.SelectedIndex == 0)
                                { }
                                else
                                    if (cmbDenDot.SelectedIndex > 0)
                                    { }
            }
            else
                ///chọn 1 tổ cụ thể
                if (cmbTo.SelectedIndex > 0)
                {
                    ///chọn tất cả nhân viên
                    if (cmbNhanVien.SelectedIndex == 0)
                    {
                        if (cmbKy.SelectedIndex == 0)
                        { }
                        else
                            if (cmbKy.SelectedIndex > 0)
                                if (cmbDot.SelectedIndex == 0)
                                    dt = _cHoaDon.ThongKeHD0_Code_To(int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                else
                                    if (cmbDot.SelectedIndex > 0)
                                        if (cmbDenDot.SelectedIndex == 0)
                                        { }
                                        else
                                            if (cmbDenDot.SelectedIndex > 0)
                                            { }
                    }
                    else
                        ///chọn 1 nhân viên cụ thể
                        if (cmbNhanVien.SelectedIndex > 0)
                        {
                            if (cmbKy.SelectedIndex == 0)
                            { }
                            else
                                if (cmbKy.SelectedIndex > 0)
                                    if (cmbDot.SelectedIndex == 0)
                                        dt = _cHoaDon.ThongKeHD0_Code_NV(int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                    else
                                        if (cmbDot.SelectedIndex > 0)
                                            if (cmbDenDot.SelectedIndex == 0)
                                            { }
                                            else
                                                if (cmbDenDot.SelectedIndex > 0)
                                                { }
                        }
                }


            dsBaoCao ds = new dsBaoCao();
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = ds.Tables["DangKyHD0"].NewRow();
                dr["Code"] = item["Code"];
                dr["Ky1"] = cmbKy.SelectedItem.ToString();
                dr["Ky2"] = int.Parse(cmbKy.SelectedItem.ToString()) - 1;
                dr["Ky3"] = item["KyA"];
                dr["Ky4"] = item["KyB"];
                dr["Ky5"] = item["BienDong"];

                ds.Tables["DangKyHD0"].Rows.Add(dr);
            }

            rptThongKeHD0Code rpt = new rptThongKeHD0Code();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    if (cmbNhanVienDK.Items.Count == 0 || cmbNhanVienDK.SelectedIndex == 0)
                    {
                        MessageBox.Show("Chưa chọn Nhân Viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                    dialog.Multiselect = false;

                    if (dialog.ShowDialog() == DialogResult.OK)
                        if (MessageBox.Show("Bạn có chắc chắn Thêm?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            DataTable dtExcel = _cHoaDon.ExcelToDataTable(dialog.FileName);
                            //CExcel fileExcel = new CExcel(dialog.FileName);
                            //DataTable dtExcel = fileExcel.GetDataTable("select * from [Sheet1$]");

                            foreach (DataRow item in dtExcel.Rows)
                                if (item[0].ToString().Replace(" ", "").Length == 11)
                                {
                                    if (_cDangKyHD0.CheckExist(item[0].ToString().Replace(" ", "")) == true)
                                    {
                                        MessageBox.Show(_cDangKyHD0.GetHoTen(item[0].ToString().Replace(" ", "")) + " đã đăng ký " + item[0].ToString().Replace(" ", ""), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        TT_DangKyHD0 dangky = new TT_DangKyHD0();
                                        dangky.DanhBo = item[0].ToString().Replace(" ", "");
                                        dangky.MaNV = int.Parse(cmbNhanVienDK.SelectedValue.ToString());

                                        _cDangKyHD0.Them(dangky);
                                    }
                                }
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnXemDK.PerformClick();
                        }
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cmbToDK2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbToDK2.SelectedIndex > 0)
            {
                List<TT_NguoiDung> lstND = null;
                if ((_cTo.checkHanhThu(int.Parse(cmbToDK2.SelectedValue.ToString()))))
                {
                    lstND = _cNguoiDung.GetDSHanhThuByMaTo(int.Parse(cmbToDK2.SelectedValue.ToString()));
                    TT_NguoiDung nguoidung = new TT_NguoiDung();
                    nguoidung.MaND = 0;
                    nguoidung.HoTen = "Tất Cả";
                    lstND.Insert(0, nguoidung);

                }
                else
                {
                    lstND = _cNguoiDung.GetDSByToVanPhong(int.Parse(cmbToDK2.SelectedValue.ToString()));
                }
                cmbNhanVienDK2.DataSource = lstND;
                cmbNhanVienDK2.DisplayMember = "HoTen";
                cmbNhanVienDK2.ValueMember = "MaND";
            }
            else
            {
                cmbNhanVienDK2.DataSource = null;
            }
        }

        private void btnXemDK2_Click(object sender, EventArgs e)
        {
            ///chọn tất cả tổ
            if (cmbToDK2.SelectedIndex == 0)
            {
                DataTable dt = new DataTable();
                foreach (TT_To itemTo in _lstTo)
                {
                    List<TT_NguoiDung> lstND = _cNguoiDung.GetDSHanhThuByMaTo(itemTo.MaTo);
                    foreach (TT_NguoiDung itemND in lstND)
                    {
                        if (cmbFromDot.SelectedIndex == 0)
                            dt.Merge(_cDangKy.getDS(itemND.MaND, int.Parse(cmbNamDK2.SelectedValue.ToString())));
                        else
                            if (cmbFromDot.SelectedIndex > 0)
                                dt.Merge(_cDangKy.getDS(itemND.MaND, int.Parse(cmbNamDK2.SelectedValue.ToString()), int.Parse(cmbFromDot.SelectedItem.ToString()), int.Parse(cmbToDot.SelectedItem.ToString())));
                    }
                }
                dgvDanhBoDK2.DataSource = dt;
            }
            else
                ///chọn 1 tổ cụ thể
                if (cmbToDK2.SelectedIndex > 0)
                    ///chọn tất cả nhân viên
                    if (cmbNhanVienDK2.SelectedIndex == 0)
                    {
                        DataTable dt = new DataTable();
                        List<TT_NguoiDung> lstND = _cNguoiDung.GetDSHanhThuByMaTo(int.Parse(cmbToDK2.SelectedValue.ToString()));
                        foreach (TT_NguoiDung itemND in lstND)
                        {
                            if (cmbFromDot.SelectedIndex == 0)
                                dt.Merge(_cDangKy.getDS(itemND.MaND, int.Parse(cmbNamDK2.SelectedValue.ToString())));
                            else
                                if (cmbFromDot.SelectedIndex > 0)
                                    dt.Merge(_cDangKy.getDS(itemND.MaND, int.Parse(cmbNamDK2.SelectedValue.ToString()), int.Parse(cmbFromDot.SelectedItem.ToString()), int.Parse(cmbToDot.SelectedItem.ToString())));

                        }
                        dgvDanhBoDK2.DataSource = dt;
                    }
                    else
                        ///chọn 1 nhân viên cụ thể
                        if (cmbNhanVienDK2.SelectedIndex > 0)
                        {
                            if (cmbFromDot.SelectedIndex == 0)
                                dgvDanhBoDK2.DataSource = _cDangKy.getDS(int.Parse(cmbNhanVienDK2.SelectedValue.ToString()), int.Parse(cmbNamDK2.SelectedValue.ToString()));
                            else
                                dgvDanhBoDK2.DataSource = _cDangKy.getDS(int.Parse(cmbNhanVienDK2.SelectedValue.ToString()), int.Parse(cmbNamDK2.SelectedValue.ToString()), int.Parse(cmbFromDot.SelectedItem.ToString()), int.Parse(cmbToDot.SelectedItem.ToString()));
                        }
            CountdgvDanhBoDK2();
        }

        private void btnThemDK2_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                if (txtDanhBoDK2.Text.Trim().Replace(" ", "") != "")
                {
                    if (cmbNhanVienDK2.Items.Count == 0 || cmbNhanVienDK2.SelectedIndex == 0)
                    {
                        MessageBox.Show("Chưa chọn Nhân Viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (_cDangKy.CheckExist(txtDanhBoDK2.Text.Trim().Replace(" ", ""), int.Parse(cmbNhanVienDK2.SelectedValue.ToString())) == true)
                    {
                        MessageBox.Show(_cDangKy.GetHoTen(txtDanhBoDK2.Text.Trim().Replace(" ", "")) + " đã đăng ký " + txtDanhBoDK2.Text.Trim().Replace(" ", ""), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    TT_DangKy dangky = new TT_DangKy();
                    dangky.DanhBo = txtDanhBoDK2.Text.Trim().Replace(" ", "");
                    dangky.MaNV = int.Parse(cmbNhanVienDK2.SelectedValue.ToString());

                    if (_cDangKy.Them(dangky))
                    {
                        txtDanhBoDK2.Text = "";
                        btnXemDK2.PerformClick();
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoaDK2_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        foreach (DataGridViewRow item in dgvDanhBoDK2.SelectedRows)
                        {
                            TT_DangKy dangky = _cDangKy.Get(item.Cells["DanhBo_DK2"].Value.ToString(), int.Parse(item.Cells["MaNV_DK2"].Value.ToString()));
                            _cDangKy.Xoa(dangky);
                        }
                        btnXemDK2.PerformClick();
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDanhBoDK2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBoDK2.Text.Length == 11)
                btnThemDK2.PerformClick();
        }

        private void dgvDanhBoDK2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDanhBoDK2.Columns[e.ColumnIndex].Name == "DanhBo_DK2" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvDanhBoDK2.Columns[e.ColumnIndex].Name == "MLT_DK2" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(2, " ");
            }
        }

        private void dgvDanhBoDK2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhBoDK2.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnIn2_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvDanhBoDK2.Rows)
            {
                DataRow dr = ds.Tables["DangKyHD0"].NewRow();
                dr["NhanVien"] = item.Cells["NhanVien_DK2"].Value;
                dr["MLT"] = item.Cells["MLT_DK2"].Value.ToString().Insert(4, " ").Insert(2, " ");
                dr["DanhBo"] = item.Cells["DanhBo_DK2"].Value.ToString().Insert(7, " ").Insert(4, " ");
                dr["DiaChi"] = item.Cells["DiaChi_DK2"].Value;
                dr["Ky1"] = item.Cells["Ky1_DK2"].Value;
                dr["Ky2"] = item.Cells["Ky2_DK2"].Value;
                dr["Ky3"] = item.Cells["Ky3_DK2"].Value;
                dr["Ky4"] = item.Cells["Ky4_DK2"].Value;
                dr["Ky5"] = item.Cells["Ky5_DK2"].Value;
                dr["Ky6"] = item.Cells["Ky6_DK2"].Value;
                dr["Ky7"] = item.Cells["Ky7_DK2"].Value;
                dr["Ky8"] = item.Cells["Ky8_DK2"].Value;
                dr["Ky9"] = item.Cells["Ky9_DK2"].Value;
                dr["Ky10"] = item.Cells["Ky10_DK2"].Value;
                dr["Ky11"] = item.Cells["Ky11_DK2"].Value;
                dr["Ky12"] = item.Cells["Ky12_DK2"].Value;
                ds.Tables["DangKyHD0"].Rows.Add(dr);
            }

            rptDangKyHD0 rpt = new rptDangKyHD0();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void btnInThongKe2_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvDanhBoDK2.Rows)
            {
                DataRow dr = ds.Tables["DangKyHD0"].NewRow();
                dr["To"] = item.Cells["TenTo_DK2"].Value;
                dr["NhanVien"] = item.Cells["NhanVien_DK2"].Value;
                dr["DanhBo"] = item.Cells["DanhBo_DK2"].Value.ToString().Insert(7, " ").Insert(4, " ");
                dr["DiaChi"] = item.Cells["DiaChi_DK2"].Value;
                dr["Ky1"] = item.Cells["Ky1_DK2"].Value;
                dr["Ky2"] = item.Cells["Ky2_DK2"].Value;
                dr["Ky3"] = item.Cells["Ky3_DK2"].Value;
                dr["Ky4"] = item.Cells["Ky4_DK2"].Value;
                dr["Ky5"] = item.Cells["Ky5_DK2"].Value;
                dr["Ky6"] = item.Cells["Ky6_DK2"].Value;
                dr["Ky7"] = item.Cells["Ky7_DK2"].Value;
                dr["Ky8"] = item.Cells["Ky8_DK2"].Value;
                dr["Ky9"] = item.Cells["Ky9_DK2"].Value;
                dr["Ky10"] = item.Cells["Ky10_DK2"].Value;
                dr["Ky11"] = item.Cells["Ky11_DK2"].Value;
                dr["Ky12"] = item.Cells["Ky12_DK2"].Value;
                ds.Tables["DangKyHD0"].Rows.Add(dr);
            }

            rptThongKeDangKyHD0 rpt = new rptThongKeDangKyHD0();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void btnChonFile2_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    if (cmbNhanVienDK2.Items.Count == 0 || cmbNhanVienDK2.SelectedIndex == 0)
                    {
                        MessageBox.Show("Chưa chọn Nhân Viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                    dialog.Multiselect = false;

                    if (dialog.ShowDialog() == DialogResult.OK)
                        if (MessageBox.Show("Bạn có chắc chắn Thêm?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            DataTable dtExcel = _cHoaDon.ExcelToDataTable(dialog.FileName);
                            //CExcel fileExcel = new CExcel(dialog.FileName);
                            //DataTable dtExcel = fileExcel.GetDataTable("select * from [Sheet1$]");

                            foreach (DataRow item in dtExcel.Rows)
                                if (item[0].ToString().Replace(" ", "").Length == 11)
                                {
                                    if (_cDangKy.CheckExist(item[0].ToString().Replace(" ", ""), int.Parse(cmbNhanVienDK2.SelectedValue.ToString())) == true)
                                    {
                                        MessageBox.Show(_cDangKy.GetHoTen(item[0].ToString().Replace(" ", "")) + " đã đăng ký " + item[0].ToString().Replace(" ", ""), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        TT_DangKy dangky = new TT_DangKy();
                                        dangky.DanhBo = item[0].ToString().Replace(" ", "");
                                        dangky.MaNV = int.Parse(cmbNhanVienDK2.SelectedValue.ToString());

                                        _cDangKy.Them(dangky);
                                    }
                                }
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnXemDK2.PerformClick();
                        }
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnChonFileCoNhanVien_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                    dialog.Multiselect = false;

                    if (dialog.ShowDialog() == DialogResult.OK)
                        if (MessageBox.Show("Bạn có chắc chắn Thêm?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            DataTable dtExcel = _cHoaDon.ExcelToDataTable(dialog.FileName);
                            //CExcel fileExcel = new CExcel(dialog.FileName);
                            //DataTable dtExcel = fileExcel.GetDataTable("select * from [Sheet1$]");

                            foreach (DataRow item in dtExcel.Rows)
                                if (item[0].ToString().Replace(" ", "").Length == 11 && item[1].ToString().Trim() != "")
                                {
                                    if (_cDangKyHD0.CheckExist(item[0].ToString().Replace(" ", "")) == true)
                                    {
                                        MessageBox.Show(_cDangKyHD0.GetHoTen(item[0].ToString().Replace(" ", "")) + " đã đăng ký " + item[0].ToString().Replace(" ", ""), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        TT_DangKyHD0 dangky = new TT_DangKyHD0();
                                        dangky.DanhBo = item[0].ToString().Replace(" ", "");
                                        dangky.MaNV = _cNguoiDung.GetMaNVByHoTen(item[1].ToString().Trim());

                                        _cDangKyHD0.Them(dangky);
                                    }
                                }
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnXemDK.PerformClick();
                        }
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnChonFile2KhongNhanVien_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                    dialog.Multiselect = false;

                    if (dialog.ShowDialog() == DialogResult.OK)
                        if (MessageBox.Show("Bạn có chắc chắn Thêm?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            DataTable dtExcel = _cHoaDon.ExcelToDataTable(dialog.FileName);
                            //CExcel fileExcel = new CExcel(dialog.FileName);
                            //DataTable dtExcel = fileExcel.GetDataTable("select * from [Sheet1$]");

                            foreach (DataRow item in dtExcel.Rows)
                                if (item[0].ToString().Replace(" ", "").Length == 11)
                                {
                                    HOADON hoadon = _cHoaDon.GetMoiNhat(item[0].ToString().Replace(" ", ""));
                                    if (hoadon.MaNV_HanhThu == null)
                                        hoadon = _cHoaDon.GetMoiNhi(item[0].ToString().Replace(" ", ""));

                                    if (_cDangKy.CheckExist(item[0].ToString().Replace(" ", ""), hoadon.MaNV_HanhThu.Value) == true)
                                    {
                                        MessageBox.Show(_cDangKy.GetHoTen(item[0].ToString().Replace(" ", "")) + " đã đăng ký " + item[0].ToString().Replace(" ", ""), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        TT_DangKy dangky = new TT_DangKy();
                                        dangky.DanhBo = item[0].ToString().Replace(" ", "");
                                        dangky.MaNV = hoadon.MaNV_HanhThu.Value;

                                        _cDangKy.Them(dangky);
                                    }
                                }
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnXemDK2.PerformClick();
                        }
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnInTBBamChi_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvDanhBoDK2.Rows)
                if (int.Parse(item.Cells["Ky" + DateTime.Today.Month + "_DK2"].Value.ToString()) == 0)
                {
                    DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                    dr["NhanVien"] = item.Cells["NhanVien_DK2"].Value;
                    dr["MLT"] = item.Cells["MLT_DK2"].Value.ToString().Insert(4, " ").Insert(2, " ");
                    dr["DanhBo"] = item.Cells["DanhBo_DK2"].Value.ToString().Insert(7, " ").Insert(4, " ");
                    dr["HoTen"] = item.Cells["HoTen_DK2"].Value;
                    dr["DiaChi"] = item.Cells["DiaChi_DK2"].Value;
                    dr["SoHoaDon"] = item.Cells["HopDong_DK2"].Value;
                    ds.Tables["DSHoaDon"].Rows.Add(dr);
                }

            rptGuiThongBaoBamChi rpt = new rptGuiThongBaoBamChi();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void btnChonFile3_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                    dialog.Multiselect = false;
                    if (dialog.ShowDialog() == DialogResult.OK)
                        if (MessageBox.Show("Bạn có chắc chắn Thêm?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            DataTable dtExcel = _cHoaDon.ExcelToDataTable(dialog.FileName);
                            foreach (DataRow item in dtExcel.Rows)
                                if (item[0].ToString().Replace(" ", "").Length == 11)
                                {
                                    if (_cDangKy2.CheckExist(item[0].ToString().Replace(" ", "")) == true)
                                    {
                                        MessageBox.Show(item[0].ToString().Replace(" ", "") + " đã đăng ký ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        TT_DangKy2 dangky = new TT_DangKy2();
                                        dangky.DanhBo = item[0].ToString().Replace(" ", "");

                                        _cDangKy2.Them(dangky);
                                    }
                                }
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnXem3.PerformClick();
                        }
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa3_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        foreach (DataGridViewRow item in dgvDangKy3.SelectedRows)
                        {
                            TT_DangKy2 dangky = _cDangKy2.Get(item.Cells["DanhBo_DK3"].Value.ToString());
                            _cDangKy2.Xoa(dangky);
                        }
                        btnXem3.PerformClick();
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXem3_Click(object sender, EventArgs e)
        {
            dgvDangKy3.DataSource = _cDangKy2.getDS(int.Parse(cmbNam3.SelectedValue.ToString()));
            foreach (DataGridViewRow item in dgvDangKy3.Rows)
            {
                item.Cells["Ky1_DK3"].Value = item.Cells["Ky1_DK3"].Value.ToString().Replace("\r\n", Environment.NewLine);
            }
        }
    }
}
