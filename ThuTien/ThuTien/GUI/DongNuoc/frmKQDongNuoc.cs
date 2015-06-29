using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.DongNuoc;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;

namespace ThuTien.GUI.DongNuoc
{
    public partial class frmKQDongNuoc : Form
    {
        string _mnu = "mnuKQDongNuoc";
        CDongNuoc _cDongNuoc = new CDongNuoc();
        TT_DongNuoc _dongnuoc = null;

        public frmKQDongNuoc()
        {
            InitializeComponent();
        }

        private void frmKQDongNuoc_Load(object sender, EventArgs e)
        {
            dgvKQDongNuoc.AutoGenerateColumns = false;

            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;
        }

        public void Clear()
        {
            txtDanhBo.Text = "";
            txtMLT.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            dateDongNuoc.Value = DateTime.Now;
            txtChiSo.Text = "";
            txtHieu.Text = "";
            txtCo.Text = "";
            txtSoThan.Text = "";
            cmbChiMatSo.SelectedIndex = -1;
            cmbChiKhoaGoc.SelectedIndex = -1;
            txtLyDo.Text = "";
            _dongnuoc = null;
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaDN.Text.Trim()) && e.KeyChar == 13)
                if (_cDongNuoc.GetDongNuocByMaDN(decimal.Parse(txtMaDN.Text.Trim().Replace("-", ""))) != null)
                {
                    _dongnuoc = _cDongNuoc.GetDongNuocByMaDN(decimal.Parse(txtMaDN.Text.Trim().Replace("-", "")));
                    txtMaDN.Text = _dongnuoc.MaDN.ToString().Insert(_dongnuoc.MaDN.ToString().Length - 2, "-");
                    txtDanhBo.Text = _dongnuoc.DanhBo;
                    txtMLT.Text = _dongnuoc.MLT;
                    txtHoTen.Text = _dongnuoc.HoTen;
                    txtDiaChi.Text = _dongnuoc.DiaChi;
                }
                else
                {
                    Clear();
                }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                if (_dongnuoc != null)
                {
                    if (_cDongNuoc.CheckKQDongNuocByMaDNNgayDN(_dongnuoc.MaDN, dateDongNuoc.Value))
                    {
                        MessageBox.Show("Biên Bản ngày " + dateDongNuoc.Value.ToString("dd/MM/yyyy") + " đã nhập rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!_cDongNuoc.CheckDongNuocByMaDNMaNV_DongNuoc(_dongnuoc.MaDN, CNguoiDung.MaND))
                    {
                        MessageBox.Show("Thông báo này không được giao cho bạn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    TT_KQDongNuoc kqdongnuoc = new TT_KQDongNuoc();
                    kqdongnuoc.MaDN = _dongnuoc.MaDN;
                    kqdongnuoc.DanhBo = txtDanhBo.Text.Trim();
                    kqdongnuoc.MLT = txtMLT.Text.Trim();
                    kqdongnuoc.HoTen = txtHoTen.Text.Trim();
                    kqdongnuoc.DiaChi = txtDiaChi.Text.Trim();

                    kqdongnuoc.NgayDN = dateDongNuoc.Value;
                    if (!string.IsNullOrEmpty(txtChiSo.Text.Trim()))
                        kqdongnuoc.ChiSo = int.Parse(txtChiSo.Text.Trim());
                    kqdongnuoc.Hieu = txtDanhBo.Text.Trim();
                    if (!string.IsNullOrEmpty(txtCo.Text.Trim()))
                        kqdongnuoc.Co = int.Parse(txtCo.Text.Trim());
                    kqdongnuoc.SoThan = txtDanhBo.Text.Trim();
                    if (cmbChiMatSo.SelectedItem != null)
                        kqdongnuoc.ChiMatSo = cmbChiMatSo.SelectedItem.ToString();
                    if (cmbChiKhoaGoc.SelectedItem != null)
                        kqdongnuoc.ChiKhoaGoc = cmbChiKhoaGoc.SelectedItem.ToString();
                    kqdongnuoc.LyDo = txtLyDo.Text.Trim();
                    if (_cDongNuoc.ThemKQ(kqdongnuoc))
                    {
                        Clear();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {
                TT_KQDongNuoc kqdongnuoc = _cDongNuoc.GetKQDongNuocByMaCTDN(decimal.Parse(dgvKQDongNuoc.SelectedRows[0].Cells["MaCTDN"].Value.ToString()));
                kqdongnuoc.DanhBo = txtDanhBo.Text.Trim();
                kqdongnuoc.MLT = txtMLT.Text.Trim();
                kqdongnuoc.HoTen = txtHoTen.Text.Trim();
                kqdongnuoc.DiaChi = txtDiaChi.Text.Trim();

                kqdongnuoc.NgayDN = dateDongNuoc.Value;
                if (!string.IsNullOrEmpty(txtChiSo.Text.Trim()))
                    kqdongnuoc.ChiSo = int.Parse(txtChiSo.Text.Trim());
                kqdongnuoc.Hieu = txtDanhBo.Text.Trim();
                if (!string.IsNullOrEmpty(txtCo.Text.Trim()))
                    kqdongnuoc.Co = int.Parse(txtCo.Text.Trim());
                kqdongnuoc.SoThan = txtDanhBo.Text.Trim();
                if (cmbChiMatSo.SelectedItem != null)
                    kqdongnuoc.ChiMatSo = cmbChiMatSo.SelectedItem.ToString();
                if (cmbChiKhoaGoc.SelectedItem != null)
                    kqdongnuoc.ChiKhoaGoc = cmbChiKhoaGoc.SelectedItem.ToString();
                kqdongnuoc.LyDo = txtLyDo.Text.Trim();

                if (_cDongNuoc.SuaKQ(kqdongnuoc))
                {
                    Clear();
                    dgvKQDongNuoc.DataSource = _cDongNuoc.GetDSKQDongNuocByDates(CNguoiDung.MaND, dateTu.Value, dateDen.Value);
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                TT_KQDongNuoc kqdongnuoc = _cDongNuoc.GetKQDongNuocByMaCTDN(decimal.Parse(dgvKQDongNuoc.SelectedRows[0].Cells["MaCTDN"].Value.ToString()));
                if (_cDongNuoc.XoaKQ(kqdongnuoc))
                {
                    Clear();
                    dgvKQDongNuoc.DataSource = _cDongNuoc.GetDSKQDongNuocByDates(CNguoiDung.MaND, dateTu.Value, dateDen.Value);
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvKQDongNuoc.DataSource = _cDongNuoc.GetDSKQDongNuocByDates(CNguoiDung.MaND, dateTu.Value, dateDen.Value);
        }

        private void dgvKQDongNuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvKQDongNuoc.Rows[e.RowIndex].Selected = true;
                txtDanhBo.Text = dgvKQDongNuoc["DanhBo", e.RowIndex].Value.ToString();
                txtMLT.Text = dgvKQDongNuoc["MLT", e.RowIndex].Value.ToString();
                txtHoTen.Text = dgvKQDongNuoc["HoTen", e.RowIndex].Value.ToString();
                txtDiaChi.Text = dgvKQDongNuoc["DiaChi", e.RowIndex].Value.ToString();
                dateDongNuoc.Value = DateTime.Parse(dgvKQDongNuoc["NgayDN", e.RowIndex].Value.ToString());
                txtChiSo.Text = dgvKQDongNuoc["ChiSo", e.RowIndex].Value.ToString();
                txtHieu.Text = dgvKQDongNuoc["Hieu", e.RowIndex].Value.ToString();
                txtCo.Text = dgvKQDongNuoc["Co", e.RowIndex].Value.ToString();
                txtSoThan.Text = dgvKQDongNuoc["SoThan", e.RowIndex].Value.ToString();
                cmbChiMatSo.SelectedItem = dgvKQDongNuoc["ChiMatSo", e.RowIndex].Value.ToString();
                cmbChiKhoaGoc.SelectedItem = dgvKQDongNuoc["ChiKhoaGoc", e.RowIndex].Value.ToString();
                txtLyDo.Text = dgvKQDongNuoc["LyDo", e.RowIndex].Value.ToString();
            }
            catch
            {
            }  
        }

        private void dgvKQDongNuoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvKQDongNuoc.Columns[e.ColumnIndex].Name == "MaDN" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void dgvKQDongNuoc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvKQDongNuoc.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void txtChiSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtCo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        
    }
}
