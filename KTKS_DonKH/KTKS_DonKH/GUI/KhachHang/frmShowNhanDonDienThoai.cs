using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.KhachHang
{
    public partial class frmShowNhanDonDienThoai : Form
    {
        decimal _MaDonDT = 0;
        DonDienThoai _dondt = null;
        CDonDienThoai _cDonDT = new CDonDienThoai();

        public frmShowNhanDonDienThoai()
        {
            InitializeComponent();
        }

        public frmShowNhanDonDienThoai(decimal MaDonDT)
        {
            _MaDonDT = MaDonDT;
            InitializeComponent();  
        }

        private void frmShowNhanDonDienThoai_Load(object sender, EventArgs e)
        {
            this.Location = new Point(70, 70);
            dgvLichSuDonDT.AutoGenerateColumns = false;

            if (_cDonDT.getDonDienThoaibyID(_MaDonDT) != null)
            {
                _dondt = _cDonDT.getDonDienThoaibyID(_MaDonDT);
                txtDanhBo.Text = _dondt.DanhBo;
                txtHoTen.Text = _dondt.HoTen;
                txtDiaChi.Text = _dondt.DiaChi;
                txtNoiDung.Text = _dondt.NoiDung;
                txtGhiChu.Text = _dondt.GhiChu;
                txtDienThoai.Text = _dondt.DienThoai;
                txtNguoiBao.Text = _dondt.NguoiBao;
                dgvLichSuDonDT.DataSource = _cDonDT.getDSDonDienThoaiByDanhBo(_dondt.DanhBo);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_dondt!=null&&!_cDonDT.CheckLapDonKH(_dondt.MaDonDT))
            {
                DonDienThoai dondt = _cDonDT.getDonDienThoaibyID(_dondt.MaDonDT);
                dondt.DanhBo = txtDanhBo.Text;
                dondt.HoTen = txtHoTen.Text.Trim();
                dondt.DiaChi = txtDiaChi.Text.Trim();
                dondt.NoiDung = txtNoiDung.Text.Trim();
                dondt.GhiChu = txtGhiChu.Text.Trim();
                dondt.DienThoai = txtDienThoai.Text.Trim();
                dondt.NguoiBao = txtNguoiBao.Text.Trim();
                if (_cDonDT.SuaDonDienThoai(dondt))
                {
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
                MessageBox.Show("Đã lập Đơn Khách Hàng, không Sửa được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_dondt!=null&&!_cDonDT.CheckLapDonKH(_dondt.MaDonDT))
            {
                DonDienThoai dondt = _cDonDT.getDonDienThoaibyID(_dondt.MaDonDT);
                if (_cDonDT.XoaDonDienThoai(dondt))
                {
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
                MessageBox.Show("Đã lập Đơn Khách Hàng, không Xóa được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
