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

namespace ThuTien.GUI.Doi
{
    public partial class frmPhanTichHD0 : Form
    {
        string _mnu = "mnuPhanTichHD0";
        CTo _cTo = new CTo();
        CHoaDon _cHoaDon = new CHoaDon();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CDangKyHD0 _cDangKyHD0 = new CDangKyHD0();
        List<TT_To> _lstTo;

        public frmPhanTichHD0()
        {
            InitializeComponent();
        }

        private void frmPhanTichHD0_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
            dgvDanhBoDK.AutoGenerateColumns = false;

            _lstTo = _cTo.GetDSHanhThu();
            TT_To to = new TT_To();
            to.MaTo = 0;
            to.TenTo = "Tất Cả";
            _lstTo.Insert(0, to);
            cmbTo.DataSource = _lstTo;
            cmbTo.DisplayMember = "TenTo";
            cmbTo.ValueMember = "MaTo";

            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";

            cmbToDK.DataSource = _lstTo;
            cmbToDK.DisplayMember = "TenTo";
            cmbToDK.ValueMember = "MaTo";

            cmbNamDK.DataSource = _cHoaDon.GetNam();
            cmbNamDK.DisplayMember = "Nam";
            cmbNamDK.ValueMember = "Nam";
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
                        dgvHoaDon.DataSource = _cHoaDon.GetDSHoaDon0(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), txtGiaBieu.Text.Trim(), txtDinhMuc.Text.Trim(), txtCode.Text.Trim());
            }
            else
                ///chọn 1 tổ cụ thể
                if (cmbTo.SelectedIndex > 0)
                {
                    ///chọn tất cả nhân viên
                    if (cmbNhanVien.SelectedIndex == 0)
                    {
                        if (cmbKy.SelectedIndex == 0)
                            dgvHoaDon.DataSource = _cHoaDon.GetDSHoaDon0_To(int.Parse(cmbTo.SelectedValue.ToString()),int.Parse(cmbNam.SelectedValue.ToString()), txtGiaBieu.Text.Trim(), txtDinhMuc.Text.Trim(), txtCode.Text.Trim());
                        else
                            if (cmbKy.SelectedIndex > 0)
                                dgvHoaDon.DataSource = _cHoaDon.GetDSHoaDon0_To(int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), txtGiaBieu.Text.Trim(), txtDinhMuc.Text.Trim(), txtCode.Text.Trim());
                    }
                    else
                        ///chọn 1 nhân viên cụ thể
                        if (cmbNhanVien.SelectedIndex > 0)
                        {
                            if (cmbKy.SelectedIndex == 0)
                                dgvHoaDon.DataSource = _cHoaDon.GetDSHoaDon0_NV(int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), txtGiaBieu.Text.Trim(), txtDinhMuc.Text.Trim(), txtCode.Text.Trim());
                            else
                                if (cmbKy.SelectedIndex > 0)
                                    dgvHoaDon.DataSource = _cHoaDon.GetDSHoaDon0_NV(int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), txtGiaBieu.Text.Trim(), txtDinhMuc.Text.Trim(), txtCode.Text.Trim());
                        }
                    
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
                List<TT_NguoiDung> lstND = _cNguoiDung.GetDSHanhThuByMaTo(int.Parse(cmbToDK.SelectedValue.ToString()));
                TT_NguoiDung nguoidung = new TT_NguoiDung();
                nguoidung.MaND = 0;
                nguoidung.HoTen = "Tất Cả";
                lstND.Insert(0, nguoidung);
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
        }

        private void btnThemDK_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                if (cmbNhanVienDK.Items.Count == 0 || cmbNhanVienDK.SelectedIndex == 0)
                {
                    MessageBox.Show("Chưa chọn Nhân Viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (_cDangKyHD0.CheckExist(txtDanhBoDK.Text.Trim()))
                {
                    MessageBox.Show("Danh Bộ đã được đăng ký", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                TT_DangKyHD0 dangky = new TT_DangKyHD0();
                dangky.DanhBo = txtDanhBoDK.Text.Trim();
                dangky.MaNV = int.Parse(cmbNhanVienDK.SelectedValue.ToString());

                if (_cDangKyHD0.Them(dangky))
                {
                    txtDanhBoDK.Text = "";
                    btnXemDK.PerformClick();
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
                        TT_DangKyHD0 dangky = _cDangKyHD0.GetByID(item.Cells["DanhBo_DK"].Value.ToString());
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
    }
}
