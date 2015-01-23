using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.DAL.Quay;
using System.Globalization;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;
using ThuTien.DAL.ChuyenKhoan;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmTamThuChuyenKhoan : Form
    {
        string _mnu = "mnuTamThuChuyenKhoan";
        CHoaDon _cHoaDon = new CHoaDon();
        CTamThu _cTamThu = new CTamThu();
        CNganHang _cNganHang = new CNganHang();

        public frmTamThuChuyenKhoan()
        {
            InitializeComponent();
        }

        private void frmTamThuChuyenKhoan_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
            dgvTamThu.AutoGenerateColumns = false;
            cmbNganHang.DataSource = _cNganHang.GetDS();
            cmbNganHang.DisplayMember = "TenNH";
            cmbNganHang.ValueMember = "MaNH";
        }

        public void Clear()
        {
            txtDanhBo.Text = "";
            dgvHoaDon.DataSource = null;
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDanhBo.Text.Trim()) && e.KeyChar == 13)
            {
                DataTable dt = new DataTable();
                foreach (string item in txtDanhBo.Lines)
                    if (item.Length == 11)
                    {
                        dt.Merge(_cHoaDon.GetDSTonByDanhBo(item));
                    }
                dgvHoaDon.DataSource = dt;
                for (int i = 0; i < dgvHoaDon.Rows.Count; i++)
                {
                    dgvHoaDon["Chon", i].Value = true;
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.RowCount > 0)
            {
                _cTamThu.BeginTransaction();
                foreach (DataGridViewRow item in dgvHoaDon.Rows)
                    if (bool.Parse(item.Cells["Chon"].Value.ToString()))
                        if (!_cTamThu.CheckBySoHoaDon(item.Cells["SoHoaDon"].Value.ToString()))
                        {
                            TAMTHU tamthu = new TAMTHU();
                            //tamthu.DANHBA = item.Cells["DanhBo"].Value.ToString();
                            tamthu.FK_HOADON = int.Parse(item.Cells["MaHD"].Value.ToString());
                            tamthu.SoHoaDon = item.Cells["SoHoaDon"].Value.ToString();
                            tamthu.ChuyenKhoan = true;
                            tamthu.MaNH = int.Parse(cmbNganHang.SelectedValue.ToString());

                            if (!_cTamThu.Them(tamthu))
                            {
                                _cTamThu.Rollback();
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                        {
                            _cTamThu.Rollback();
                            MessageBox.Show("Hóa Đơn này đã Tạm Thu: " + item.Cells["SoHoaDon"].Value.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                _cTamThu.CommitTransaction();
                Clear();
                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dateTu.Value <= dateDen.Value)
            {
                dgvTamThu.DataSource = _cTamThu.GetDSByDates(true, CNguoiDung.MaND, dateTu.Value, dateDen.Value);
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name == "tabThongTin")
            {
                btnThem.Enabled = true;
                btnXoa.Enabled = false;
            }
            else
                if (tabControl.SelectedTab.Name == "tabTamThu")
                {
                    btnThem.Enabled = false;
                    btnXoa.Enabled = true;
                }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    _cTamThu.BeginTransaction();
                    foreach (DataGridViewRow item in dgvTamThu.SelectedRows)
                    {
                        TAMTHU tamthu = _cTamThu.GetByMaTT(int.Parse(item.Cells["MaTT"].Value.ToString()));
                        if (!_cHoaDon.CheckDangNganBySoHoaDon(tamthu.SoHoaDon))
                        {
                            if (!_cTamThu.Xoa(tamthu))
                            {
                                _cTamThu.Rollback();
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                        {
                            _cTamThu.Rollback();
                            dgvTamThu.ClearSelection();
                            dgvTamThu.Rows[item.Index].Selected = true;
                            MessageBox.Show("Hóa đơn đã Đăng Ngân", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    _cTamThu.CommitTransaction();
                    dgvTamThu.DataSource = null;
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TieuThu" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "GiaBan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "ThueGTGT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "PhiBVMT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvTamThu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTamThu.Columns[e.ColumnIndex].Name == "DanhBo_TT" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvTamThu.Columns[e.ColumnIndex].Name == "TieuThu_TT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTamThu.Columns[e.ColumnIndex].Name == "GiaBan_TT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTamThu.Columns[e.ColumnIndex].Name == "ThueGTGT_TT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTamThu.Columns[e.ColumnIndex].Name == "PhiBVMT_TT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTamThu.Columns[e.ColumnIndex].Name == "TongCong_TT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTamThu.Columns[e.ColumnIndex].Name == "MaNH_TT" && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.Value = _cNganHang.GetByMaNH(int.Parse(e.Value.ToString())).NGANHANG1;
            }
        }

        private void dgvHoaDon_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHoaDon.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvTamThu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvTamThu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
    }
}
