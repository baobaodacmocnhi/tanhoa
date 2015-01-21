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
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;
using System.Globalization;

namespace ThuTien.GUI.Quay
{
    public partial class frmTamThuQuay : Form
    {
        string _mnu = "mnuTamThuQuay";
        CHoaDon _cHoaDon = new CHoaDon();
        CTamThu _cTamThu = new CTamThu();

        public frmTamThuQuay()
        {
            InitializeComponent();
        }

        private void frmTamThu_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
            dgvTamThu.AutoGenerateColumns = false;
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
                dgvHoaDon.DataSource = _cHoaDon.GetDSTonByDanhBo(txtDanhBo.Text.Trim());
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                ///Có nhiều hơn 1 hóa đơn
                if (dgvHoaDon.RowCount > 1)
                {
                    ///Kiểm tra có chọn hóa đơn đăng ngân chưa
                    int Count = 0;
                    int index = -1;
                    for (int i = 0; i < dgvHoaDon.RowCount; i++)
                    {
                        if (bool.Parse(dgvHoaDon["Chon", i].Value.ToString()))
                        {
                            Count++;
                            index = i;
                        }
                    }
                    if (Count == 0)
                    {
                        MessageBox.Show("Chưa chọn Hóa Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                        if (Count > 1)
                        {
                            MessageBox.Show("Chọn quá 1 Hóa Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    ///Bắt đầu đăng ngân chỉ 1 hóa đơn được chọn
                    if (bool.Parse(dgvHoaDon["Chon", index].Value.ToString()) && !_cTamThu.CheckBySoHoaDon(dgvHoaDon["SoHoaDon", index].Value.ToString()))
                    {
                        TAMTHU tamthu = new TAMTHU();
                        tamthu.DANHBA = dgvHoaDon["DanhBo", index].Value.ToString();
                        tamthu.FK_HOADON = int.Parse(dgvHoaDon["MaHD", index].Value.ToString());
                        tamthu.SoHoaDon = dgvHoaDon["SoHoaDon", index].Value.ToString();

                        if (_cTamThu.Them(tamthu))
                        {
                            Clear();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                        MessageBox.Show("Chưa Chọn Hóa Đơn \nhoặc Hóa Đơn này đã Tạm Thu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    ///Có 1 hóa đơn nên set mặc định row 0
                    if (dgvHoaDon.RowCount == 1 && !_cTamThu.CheckBySoHoaDon(dgvHoaDon["SoHoaDon", 0].Value.ToString()))
                    {
                        TAMTHU tamthu = new TAMTHU();
                        tamthu.DANHBA = dgvHoaDon["DanhBo", 0].Value.ToString();
                        tamthu.FK_HOADON = int.Parse(dgvHoaDon["MaHD", 0].Value.ToString());
                        tamthu.SoHoaDon = dgvHoaDon["SoHoaDon", 0].Value.ToString();

                        if (_cTamThu.Them(tamthu))
                        {
                            Clear();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                        MessageBox.Show("Chưa có thông tin Hóa Đơn \nhoặc Hóa Đơn này đã Tạm Thu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dateTu.Value <= dateDen.Value)
            {
                dgvTamThu.DataSource = _cTamThu.GetDSByDates(false,CNguoiDung.MaND, dateTu.Value, dateDen.Value);
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
                        TAMTHU tamthu=_cTamThu.GetByMaTT(int.Parse(item.Cells["MaTT"].Value.ToString()));
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
