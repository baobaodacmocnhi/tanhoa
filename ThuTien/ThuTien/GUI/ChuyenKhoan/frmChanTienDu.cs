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
using System.Globalization;
using ThuTien.DAL.ChuyenKhoan;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmChanTienDu : Form
    {
        string _mnu = "mnuChanTienDu";
        CHoaDon _cHoaDon = new CHoaDon();

        public frmChanTienDu()
        {
            InitializeComponent();
        }

        private void frmChanTienDu_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
            dgvDSChanTienDu.AutoGenerateColumns = false;

            dgvDSChanTienDu.DataSource = _cHoaDon.GetDSChanTienDu();
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDanhBo.Text.Trim()) && e.KeyChar == 13)
                dgvHoaDon.DataSource = _cHoaDon.GetDSTonByDanhBo(txtDanhBo.Text.Trim().Replace(" ", ""));
            foreach (DataGridViewRow item in dgvHoaDon.Rows)
            {
                item.Cells["Chon"].Value = "True";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    foreach (DataGridViewRow item in dgvHoaDon.Rows)
                        if (item.Cells["Chon"].Value != null && bool.Parse(item.Cells["Chon"].Value.ToString()))
                        {
                            HOADON hoadon = _cHoaDon.Get(item.Cells["SoHoaDon_HD"].Value.ToString());
                            hoadon.KhoaTienDu = true;
                            hoadon.ChanTienDu = true;
                            hoadon.NgayChanTienDu = DateTime.Now;
                            hoadon.NGAYGIAITRACH = DateTime.Now;
                            _cHoaDon.Sua(hoadon);
                        }
                    dgvDSChanTienDu.DataSource = _cHoaDon.GetDSChanTienDu();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    foreach (DataGridViewRow item in dgvDSChanTienDu.SelectedRows)
                    {
                        HOADON hoadon = _cHoaDon.Get(item.Cells["SoHoaDon_Chan"].Value.ToString());
                        hoadon.KhoaTienDu = false;
                        hoadon.ChanTienDu = false;
                        hoadon.NGAYGIAITRACH = null;
                        _cHoaDon.Sua(hoadon);
                    }
                    dgvDSChanTienDu.DataSource = _cHoaDon.GetDSChanTienDu();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "DanhBo_HD" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongCong_HD" && e.Value != null)
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

        private void dgvDSChanTienDu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSChanTienDu.Columns[e.ColumnIndex].Name == "DanhBo_Chan" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvDSChanTienDu.Columns[e.ColumnIndex].Name == "TongCong_Chan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDSChanTienDu.Columns[e.ColumnIndex].Name == "TienDu" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvDSChanTienDu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSChanTienDu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSChanTienDu_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvDSChanTienDu.Columns[e.ColumnIndex].Name == "ChanTienDu" && bool.Parse(e.FormattedValue.ToString()) != bool.Parse(dgvDSChanTienDu[e.ColumnIndex, e.RowIndex].Value.ToString()))
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    HOADON hoadon = _cHoaDon.Get(dgvDSChanTienDu["SoHoaDon_Chan", e.RowIndex].Value.ToString());
                    if (bool.Parse(e.FormattedValue.ToString()))
                        hoadon.NGAYGIAITRACH = DateTime.Now;
                    else
                        hoadon.NGAYGIAITRACH = null;
                    hoadon.ChanTienDu = bool.Parse(e.FormattedValue.ToString());
                    _cHoaDon.Sua(hoadon);
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {
                if (chkAll.Checked)
                    foreach (DataGridViewRow item in dgvDSChanTienDu.Rows)
                    {
                        HOADON hoadon = _cHoaDon.Get(item.Cells["SoHoaDon_Chan"].Value.ToString());
                        hoadon.NGAYGIAITRACH = DateTime.Now;
                        hoadon.ChanTienDu = true;
                        _cHoaDon.Sua(hoadon);
                    }
                else
                    foreach (DataGridViewRow item in dgvDSChanTienDu.Rows)
                    {
                        HOADON hoadon = _cHoaDon.Get(item.Cells["SoHoaDon_Chan"].Value.ToString());
                        hoadon.NGAYGIAITRACH = null;
                        hoadon.ChanTienDu = false;
                        _cHoaDon.Sua(hoadon);
                    }
                dgvDSChanTienDu.DataSource = _cHoaDon.GetDSChanTienDu();
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnChonFile_Click(object sender, EventArgs e)
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
                            Excel fileExcel = new Excel(dialog.FileName);
                            DataTable dtExcel = fileExcel.GetDataTable("select * from [Sheet1$]");

                            foreach (DataRow item in dtExcel.Rows)
                                if (item[0].ToString().Trim().Replace(" ", "").Length == 11)
                                {
                                    DataTable dt = _cHoaDon.GetDSTonByDanhBo(item[0].ToString().Trim().Replace(" ", ""));
                                    foreach (DataRow itemB in dt.Rows)
                                    {
                                        HOADON hoadon = _cHoaDon.Get(itemB["SoHoaDon"].ToString());
                                        hoadon.KhoaTienDu = true;
                                        hoadon.ChanTienDu = true;
                                        hoadon.NgayChanTienDu = DateTime.Now;
                                        hoadon.NGAYGIAITRACH = DateTime.Now;
                                        _cHoaDon.Sua(hoadon);
                                    }
                                }
                            dgvDSChanTienDu.DataSource = _cHoaDon.GetDSChanTienDu();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
