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

namespace ThuTien.GUI.Doi
{
    public partial class frmKetThucNamTaiKhoa : Form
    {
        string _fileName = "";
        string _mnu = "mnuLuuHD";
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CHoaDon _cHoaDon = new CHoaDon();
        CHoaDonTon _cHoaDonTon = new CHoaDonTon();

        public frmKetThucNamTaiKhoa()
        {
            InitializeComponent();
        }

        private void frmKetThucNamTaiKhoa_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Files (.dat)|*.dat";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtDuongDan.Text = dialog.FileName;
                _fileName = dialog.SafeFileName;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                if (txtDuongDan.Text.Trim() != "" && _fileName.Length == 12)
                {
                    if (_cHoaDonTon.Them(txtDuongDan.Text.Trim()))
                    {
                        txtDuongDan.Text = "";
                        _fileName = "";
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                _cHoaDonTon.BeginTransaction();
                try
                {
                    foreach (DataGridViewRow item in dgvHoaDon.SelectedRows)
                    {
                        _cHoaDonTon.Xoa(_cHoaDonTon.GetByMaHD(int.Parse(item.Cells["MaHD"].Value.ToString())));
                    }
                    _cHoaDonTon.CommitTransaction();
                    dgvHoaDon.DataSource = _cHoaDonTon.GetDS();
                }
                catch
                {
                    _cHoaDonTon.Rollback();
                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvHoaDon.DataSource = _cHoaDonTon.GetDS();
            txtSoHDTonBilling.Text = dgvHoaDon.RowCount.ToString();
            txtSoHDTonCty.Text = _cHoaDon.CountDSTon().ToString();
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TieuThu" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
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

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn cập nhật?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    _cHoaDon.SqlBeginTransaction();
                    foreach (DataGridViewRow item in dgvHoaDon.Rows)
                    {
                        if (!_cHoaDon.XoaDangNgan(item.Cells["SoHoaDon"].Value.ToString()))
                        {
                            _cHoaDon.SqlRollbackTransaction();
                            MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    _cHoaDon.SqlCommitTransaction();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    _cHoaDon.SqlRollbackTransaction();
                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
    }
}
