using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using System.Globalization;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.ChuyenKhoan;
using ThuTien.LinQ;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmDuLieuKhachHang : Form
    {
        string _mnu = "mnuDuLieuKhachHang";
        CHoaDon _cHoaDon = new CHoaDon();
        CDuLieuKhachHang _cDLKH = new CDuLieuKhachHang();

        public frmDuLieuKhachHang()
        {
            InitializeComponent();
        }

        private void frmDuLieuKhachHang_Load(object sender, EventArgs e)
        {
            dgvHDDaThu.AutoGenerateColumns = false;
            dgvHDChuaThu.AutoGenerateColumns = false;

            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";
        }

        public void LoadDanhSachHD()
        {
            dgvHDDaThu.DataSource = _cDLKH.GetDSDangNgan(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
            dgvHDChuaThu.DataSource = _cDLKH.GetDSTon(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
            int TongCong = 0;
            if (dgvHDDaThu.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDDaThu.Rows)
                {
                    TongCong += int.Parse(item.Cells["TongCong_DT"].Value.ToString());
                }
                if (TongCong == 0)
                    txtTongCong_DT.Text = "0";
                else
                    txtTongCong_DT.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
            TongCong = 0;
            if (dgvHDChuaThu.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDChuaThu.Rows)
                {
                    TongCong += int.Parse(item.Cells["TongCong_CT"].Value.ToString());
                }
                if (TongCong == 0)
                    txtTongCong_CT.Text = "0";
                else
                    txtTongCong_CT.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (cmbNam.SelectedIndex != -1 && cmbKy.SelectedIndex != -1)
            {
                LoadDanhSachHD();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    if (cmbKy.SelectedIndex == -1)
                    {
                        MessageBox.Show("Vui lòng chọn Kỳ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _cDLKH.BeginTransaction();
                    foreach (string item in txtDanhBo.Lines)
                        if (item.Length == 11)
                        {
                            TT_DuLieuKhachHang dlkh = new TT_DuLieuKhachHang();
                            dlkh.Nam = (int)cmbNam.SelectedValue;
                            dlkh.Ky = int.Parse(cmbKy.SelectedItem.ToString());
                            dlkh.DanhBo = item;
                            if (!_cDLKH.Them(dlkh))
                            {
                                _cDLKH.Rollback();
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    _cDLKH.CommitTransaction();
                    LoadDanhSachHD();
                    txtDanhBo.Text = "";
                    cmbKy.SelectedIndex = -1;
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    _cDLKH.Rollback();
                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                try
                {
                    _cDLKH.BeginTransaction();
                    if (tabControl.SelectedTab.Name == "tabDaThu")
                    {
                        foreach (DataGridViewRow item in dgvHDDaThu.SelectedRows)
                        {
                            TT_DuLieuKhachHang dlkh = _cDLKH.GetByNamKyDanhBo(int.Parse(item.Cells["Nam_DT"].Value.ToString()), int.Parse(item.Cells["Ky_DT"].Value.ToString()), item.Cells["DanhBo_DT"].Value.ToString());
                            if (!_cDLKH.Xoa(dlkh))
                            {
                                _cDLKH.Rollback();
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    else
                        if (tabControl.SelectedTab.Name == "tabChuaThu")
                        {
                            foreach (DataGridViewRow item in dgvHDChuaThu.SelectedRows)
                            {
                                TT_DuLieuKhachHang dlkh = _cDLKH.GetByNamKyDanhBo(int.Parse(item.Cells["Nam_CT"].Value.ToString()), int.Parse(item.Cells["Ky_CT"].Value.ToString()), item.Cells["DanhBo_CT"].Value.ToString());
                                if (!_cDLKH.Xoa(dlkh))
                                {
                                    _cDLKH.Rollback();
                                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }
                    _cDLKH.CommitTransaction();
                    LoadDanhSachHD();
                    txtDanhBo.Text = "";
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    _cDLKH.Rollback();
                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
