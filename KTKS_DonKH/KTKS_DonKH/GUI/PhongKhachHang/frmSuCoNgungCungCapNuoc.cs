using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.DonTu;

namespace KTKS_DonKH.GUI.PhongKhachHang
{
    public partial class frmSuCoNgungCungCapNuoc : Form
    {
        string _mnu = "mnuSuCoNgungCungCapNuoc";
        CTTKH _cTTKH = new CTTKH();
        CDonTu _cDonTu = new CDonTu();
        SuCoNgungCungCapNuoc _en = null;

        public frmSuCoNgungCungCapNuoc()
        {
            InitializeComponent();
        }

        private void frmSuCoNgungCungCapNuoc_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
            loaddgvDanhSach();
        }

        public void loaddgvDanhSach()
        {
            dgvDanhSach.DataSource = _cTTKH.getDS();
        }

        public void Clear()
        {
            txtNoiDung.Text = "";
            txtDanhBo.Text = "";
            txtDMA.Text = "";
            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;
            _en = null;
            loaddgvDanhSach();
        }

        public void fillEntity(SuCoNgungCungCapNuoc en)
        {
            if (en != null)
            {
                txtNoiDung.Text = en.NoiDung;
                txtDanhBo.Text = en.DanhBos;
                txtDMA.Text = en.DMAs;
                dateTu.Value = en.DateStart.Value;
                dateDen.Value = en.DateEnd.Value;
            }
        }

        private void btnImportDanhBo_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                dialog.Multiselect = false;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    DataTable dtExcel = _cDonTu.ExcelToDataTable(dialog.FileName);
                    string str = "";
                    foreach (DataRow item in dtExcel.Rows)
                    {
                        if (str == "")
                            str += item[0].ToString().Trim();
                        else
                            str += "," + item[0].ToString().Trim();
                    }
                    txtDanhBo.Text = str;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImportDMA_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                dialog.Multiselect = false;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    DataTable dtExcel = _cDonTu.ExcelToDataTable(dialog.FileName);
                    string str = "";
                    foreach (DataRow item in dtExcel.Rows)
                    {
                        if (str == "")
                            str += item[0].ToString().Trim();
                        else
                            str += "," + item[0].ToString().Trim();
                    }
                    txtDMA.Text = str;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
                {
                    SuCoNgungCungCapNuoc en = new SuCoNgungCungCapNuoc();
                    en.NoiDung = txtNoiDung.Text.Trim();
                    en.DanhBos = txtDanhBo.Text.Trim();
                    en.DMAs = txtDMA.Text.Trim();
                    en.DateStart = dateTu.Value;
                    en.DateEnd = dateDen.Value;
                    if (_cTTKH.them(en))
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
                {
                    if (_en != null)
                    {
                        if (_cTTKH.xoa(_en) && MessageBox.Show("Bạn có chắc chắn xóa Toàn Bộ Truy Thu?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {
                    if (_en != null)
                    {
                        _en.NoiDung = txtNoiDung.Text.Trim();
                        _en.DanhBos = txtDanhBo.Text.Trim();
                        _en.DMAs = txtDMA.Text.Trim();
                        _en.DateStart = dateTu.Value;
                        _en.DateEnd = dateDen.Value;
                        if (_cTTKH.sua(_en))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _en = _cTTKH.get(int.Parse(dgvDanhSach.CurrentRow.Cells["ID"].Value.ToString()));
                fillEntity(_en);
            }
            catch
            {
            }
        }


    }
}
