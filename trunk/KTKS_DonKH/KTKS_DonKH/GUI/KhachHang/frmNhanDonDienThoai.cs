using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.KhachHang
{
    public partial class frmNhanDonDienThoai : Form
    {
        CDonDienThoai _cDonDT = new CDonDienThoai();
        CTTKH _cTTKH = new CTTKH();
        CPhuongQuan _cPhuongQuan = new CPhuongQuan();
        TTKhachHang _ttkhachhang = null;
        int _selectedindex = -1;

        public frmNhanDonDienThoai()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void frmNhanDonDienThoai_Load(object sender, EventArgs e)
        {
            dgvLichSuDonDT.AutoGenerateColumns = false;

        }

        public void Clear()
        {
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtNoiDung.Text = "";
            txtGhiChu.Text = "";
            txtDienThoai.Text = "";
            txtNguoiBao.Text = "";
            dgvLichSuDonDT.DataSource = _cDonDT.getDSDonDienThoaiByDanhBo(txtDanhBo.Text.Trim());
            _selectedindex = -1;
            _ttkhachhang = null;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DonDienThoai dondt = new DonDienThoai();
            dondt.DanhBo = txtDanhBo.Text;
            dondt.HoTen = txtHoTen.Text.Trim();
            dondt.DiaChi = txtDiaChi.Text.Trim();
            if (_ttkhachhang != null)
            {
                dondt.HopDong = _ttkhachhang.GiaoUoc;
                dondt.MSThue = _ttkhachhang.MSThue;
                dondt.GiaBieu = _ttkhachhang.GB;
                dondt.DinhMuc = _ttkhachhang.TGDM;
                dondt.Dot = _ttkhachhang.Dot;
                dondt.Ky = _ttkhachhang.Ky;
                dondt.Nam = _ttkhachhang.Nam;
            }
            dondt.NoiDung = txtNoiDung.Text.Trim();
            dondt.GhiChu = txtGhiChu.Text.Trim();
            dondt.DienThoai = txtDienThoai.Text.Trim();
            dondt.NguoiBao = txtNguoiBao.Text.Trim();
            if (_cDonDT.ThemDonDienThoai(dondt))
            {
                Clear();
                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedindex != -1)
                if (!_cDonDT.CheckLapDonKH(int.Parse(dgvLichSuDonDT["MaDonDT", _selectedindex].Value.ToString())))
                {
                    DonDienThoai dondt = _cDonDT.getDonDienThoaibyID(int.Parse(dgvLichSuDonDT["MaDonDT", _selectedindex].Value.ToString()));
                    //dondt.DanhBo = txtDanhBo.Text;
                    //dondt.HoTen = txtHoTen.Text.Trim();
                    //dondt.DiaChi = txtDiaChi.Text.Trim();
                    dondt.NoiDung = txtNoiDung.Text.Trim();
                    dondt.GhiChu = txtGhiChu.Text.Trim();
                    dondt.DienThoai = txtDienThoai.Text.Trim();
                    dondt.NguoiBao = txtNguoiBao.Text.Trim();
                    if (_cDonDT.SuaDonDienThoai(dondt))
                    {
                        Clear();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("Đã lập Đơn Khách Hàng, không Sửa được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedindex != -1)
                if (MessageBox.Show("Bạn chắc chắn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    if (!_cDonDT.CheckLapDonKH(int.Parse(dgvLichSuDonDT["MaDonDT", _selectedindex].Value.ToString())))
                    {
                        DonDienThoai dondt = _cDonDT.getDonDienThoaibyID(int.Parse(dgvLichSuDonDT["MaDonDT", _selectedindex].Value.ToString()));
                        if (_cDonDT.XoaDonDienThoai(dondt))
                        {
                            Clear();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                        MessageBox.Show("Đã lập Đơn Khách Hàng, không Xóa được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtDanhBo.Text.Trim()))
            {
                if (_cTTKH.getTTKHbyID(txtDanhBo.Text.Trim()) != null)
                {
                    _ttkhachhang = _cTTKH.getTTKHbyID(txtDanhBo.Text.Trim());
                    txtHoTen.Text = _ttkhachhang.HoTen;
                    txtDiaChi.Text = _ttkhachhang.DC1 + " " + _ttkhachhang.DC2 + _cPhuongQuan.getPhuongQuanByID(_ttkhachhang.Quan, _ttkhachhang.Phuong);
                }
                else
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvLichSuDonDT.DataSource = _cDonDT.getDSDonDienThoaiByDanhBo(txtDanhBo.Text.Trim());
            }
        }

        private void dgvLichSuDonDT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _selectedindex = e.RowIndex;
                txtHoTen.Text = dgvLichSuDonDT["HoTen", e.RowIndex].Value.ToString();
                txtDiaChi.Text = dgvLichSuDonDT["DiaChi", e.RowIndex].Value.ToString();
                txtNoiDung.Text = dgvLichSuDonDT["NoiDung", e.RowIndex].Value.ToString();
                txtGhiChu.Text = dgvLichSuDonDT["GhiChu", e.RowIndex].Value.ToString();
                txtDienThoai.Text = dgvLichSuDonDT["DienThoai", e.RowIndex].Value.ToString();
                txtNguoiBao.Text = dgvLichSuDonDT["NguoiBao", e.RowIndex].Value.ToString();
            }
            catch
            {
                
            }
        }

        private void dgvLichSuDonDT_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLichSuDonDT.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null)
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
        }

        private void dgvLichSuDonDT_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvLichSuDonDT.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }
    }
}
