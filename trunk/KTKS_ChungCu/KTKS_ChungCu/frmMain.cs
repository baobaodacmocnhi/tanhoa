using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_ChungCu.LinQ;
using KTKS_ChungCu.DAL;

namespace KTKS_ChungCu
{
    public partial class frmMain : Form
    {
        CTTKH _cTTKH = new CTTKH();
        TTKhachHang _ttkhachhang = new TTKhachHang();
        CLoaiChungTu _cLoaiChungTu = new CLoaiChungTu();
        CChungCu _cChungCu = new CChungCu();
        int _selectedindex = -1;
        BindingSource DSKHCC_BS = new BindingSource();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            dgvKhachHangChungCu.AutoGenerateColumns = false;
            dgvKhachHangChungCu.ColumnHeadersDefaultCellStyle.Font = new Font(dgvKhachHangChungCu.Font, FontStyle.Bold);
            dgvKhachHangChungCu.DataSource = DSKHCC_BS;

            cmbLoaiCT.DataSource = _cLoaiChungTu.LoadDSLoaiChungTu(true);
            cmbLoaiCT.DisplayMember = "TenLCT";
            cmbLoaiCT.ValueMember = "MaLCT";
        }

        public void LoadTTKH(TTKhachHang ttkhachhang)
        {
            txtDanhBo.Text = ttkhachhang.DanhBo;
            txtHopDong.Text = ttkhachhang.GiaoUoc;
            txtHoTen.Text = ttkhachhang.HoTen;
            txtDiaChi.Text = ttkhachhang.DC1 + " " + ttkhachhang.DC2;
        }

        public void Clear()
        {
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            ///
            txtHoTenKH.Text = "";
            txtLo.Text = "";
            cmbLoaiCT.SelectedIndex = 0;
            txtMaCT.Text = "";
            txtSoNK.Text = "";
            txtGhiChu.Text = "";
            _ttkhachhang = null;
            _selectedindex = -1;
        }

        private void dgvKhachHangChungTu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvKhachHangChungCu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (_cTTKH.getTTKHbyID(txtDanhBo.Text.Trim()) != null)
                {
                    _ttkhachhang = _cTTKH.getTTKHbyID(txtDanhBo.Text.Trim());
                    LoadTTKH(_ttkhachhang);
                    DSKHCC_BS.DataSource = _cChungCu.LoadDSKHChungCu(_ttkhachhang.DanhBo);
                }
                else
                {
                    _ttkhachhang = null;
                    Clear();
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSoNK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (_ttkhachhang != null)
                if (!_cChungCu.CheckKHChungCu(_ttkhachhang.DanhBo, txtMaCT.Text.Trim()))
                {
                    ChungCu chungcu = new ChungCu();
                    chungcu.DanhBo = _ttkhachhang.DanhBo;
                    chungcu.MaCT = txtMaCT.Text.Trim();
                    chungcu.HoTen = txtHoTenKH.Text.Trim();
                    chungcu.Lo = txtLo.Text.Trim();
                    chungcu.Phong = txtPhong.Text.Trim();
                    chungcu.MaLCT = int.Parse(cmbLoaiCT.SelectedValue.ToString());
                    chungcu.SoNK = int.Parse(txtSoNK.Text.Trim());
                    chungcu.GhiChu = txtGhiChu.Text.Trim();
                    if (txtThoiHan.Text.Trim() != "" && txtThoiHan.Text.Trim() != "0")
                    {
                        chungcu.ThoiHan = int.Parse(txtThoiHan.Text.Trim());
                        chungcu.NgayHetHan = DateTime.Now.AddMonths(chungcu.ThoiHan.Value);
                    }
                    else
                    {
                        chungcu.ThoiHan = null;
                        chungcu.NgayHetHan = null;
                    }
                    

                    if (_cChungCu.ThemKHChungCu(chungcu))
                    {
                        MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtHoTenKH.Text = "";
                        //txtLo.Text = "";
                        txtPhong.Text = "";
                        cmbLoaiCT.SelectedIndex = 0;
                        txtMaCT.Text = "";
                        txtSoNK.Text = "";
                        txtGhiChu.Text = "";
                        txtThoiHan.Text = "";
                        DSKHCC_BS.DataSource = _cChungCu.LoadDSKHChungCu(_ttkhachhang.DanhBo);
                    }
                }
                else
                {
                    MessageBox.Show("Sổ này đã được đăng ký với Danh Bộ này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedindex != -1)
            {
                ChungCu chungcu = _cChungCu.getKHChungCuByID(dgvKhachHangChungCu["DanhBo", _selectedindex].Value.ToString(), dgvKhachHangChungCu["MaCT", _selectedindex].Value.ToString());
                chungcu.HoTen = txtHoTenKH.Text.Trim();
                chungcu.Lo = txtLo.Text.Trim();
                chungcu.Phong = txtPhong.Text.Trim();
                chungcu.MaLCT = int.Parse(cmbLoaiCT.SelectedValue.ToString());
                chungcu.SoNK = int.Parse(txtSoNK.Text.Trim());
                chungcu.GhiChu = txtGhiChu.Text.Trim();
                if (txtThoiHan.Text.Trim() != "" && txtThoiHan.Text.Trim() != "0")
                {
                    chungcu.ThoiHan = int.Parse(txtThoiHan.Text.Trim());
                    chungcu.NgayHetHan = DateTime.Now.AddMonths(chungcu.ThoiHan.Value);
                }
                else
                {
                    chungcu.ThoiHan = null;
                    chungcu.NgayHetHan = null;
                }

                if (_cChungCu.SuaKHChungCu(chungcu))
                {
                    MessageBox.Show("Sửa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtHoTenKH.Text = "";
                    txtLo.Text = "";
                    txtPhong.Text = "";
                    cmbLoaiCT.SelectedIndex = 0;
                    txtMaCT.Text = "";
                    txtSoNK.Text = "";
                    txtGhiChu.Text = "";
                    txtThoiHan.Text = "";
                    _selectedindex = -1;
                    DSKHCC_BS.DataSource = _cChungCu.LoadDSKHChungCu(_ttkhachhang.DanhBo);
                }
            }
        }

        private void dgvKhachHangChungCu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectedindex = e.RowIndex;
            txtHoTenKH.Text = dgvKhachHangChungCu["HoTen", e.RowIndex].Value.ToString();
            txtLo.Text = dgvKhachHangChungCu["Lo", e.RowIndex].Value.ToString();
            txtPhong.Text = dgvKhachHangChungCu["Phong", e.RowIndex].Value.ToString();
            cmbLoaiCT.SelectedValue = int.Parse(dgvKhachHangChungCu["Lo", e.RowIndex].Value.ToString());
            txtMaCT.Text = dgvKhachHangChungCu["MaCT", e.RowIndex].Value.ToString();
            txtSoNK.Text = dgvKhachHangChungCu["SoNK", e.RowIndex].Value.ToString();
            txtThoiHan.Text = dgvKhachHangChungCu["ThoiHan", e.RowIndex].Value.ToString();
            txtGhiChu.Text = dgvKhachHangChungCu["GhiChu", e.RowIndex].Value.ToString();
        }

        private void txtMaCT_TimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMaCT_TimKiem.Text.Trim() != "")
            {
                string expression = String.Format("MaCT = {0}", txtMaCT_TimKiem.Text.Trim());
                DSKHCC_BS.Filter = expression;
            }
            else
                DSKHCC_BS.RemoveFilter();
        }

        private void cmbLoaiCT_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtThoiHan.Text = ((LoaiChungTu)cmbLoaiCT.SelectedItem).ThoiHan.ToString();
            if (cmbLoaiCT.SelectedValue.ToString() == "7")
                txtMaCT.Text = _cLoaiChungTu.getMaxNextID();
            else
                txtMaCT.Text = "";
        }

        private void txtMaCT_Leave(object sender, EventArgs e)
        {
            DataTable dt = _cChungCu.LoadDSKHChungCu(txtDanhBo.Text.Trim(), txtMaCT.Text.Trim());
            foreach (DataRow itemRow in dt.Rows)
            {
                MessageBox.Show("Số Chừng Từ này đã đăng ký với Danh Bộ " + itemRow["DanhBo"] + "\nVới số NK: " + itemRow["SoNK"], "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
    }
}
