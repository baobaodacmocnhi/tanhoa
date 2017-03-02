using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.ToKhachHang;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.GUI.ToKhachHang
{
    public partial class frmNhanDonDienThoai : Form
    {
        string _mnu = "mnuNhanDonDienThoai";
        CDonDienThoai _cDonDT = new CDonDienThoai();
        CThuTien _cThuTien = new CThuTien();
        CDocSo _cDocSo = new CDocSo();
        CThongTinKhachHang _cTTKH = new CThongTinKhachHang();
        HOADON _hoadon = null;
        int _selectedindex = -1;

        public frmNhanDonDienThoai()
        {
            InitializeComponent();
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
            _hoadon = null;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                DonDienThoai dondt = new DonDienThoai();
                dondt.DanhBo = txtDanhBo.Text.Trim();
                dondt.HoTen = txtHoTen.Text.Trim();
                dondt.DiaChi = txtDiaChi.Text.Trim();
                if (_hoadon != null)
                {
                    dondt.HopDong = _hoadon.HOPDONG;
                    dondt.MSThue = _hoadon.MST;
                    dondt.GiaBieu = _hoadon.GB.ToString();
                    dondt.DinhMuc = _hoadon.DM.ToString();
                    dondt.Dot = _hoadon.DOT.ToString();
                    dondt.Ky = _hoadon.KY.ToString();
                    dondt.Nam = _hoadon.NAM.ToString();
                }
                dondt.NoiDung = txtNoiDung.Text.Trim();
                dondt.GhiChu = txtGhiChu.Text.Trim();
                dondt.DienThoai = txtDienThoai.Text.Trim();
                dondt.NguoiBao = txtNguoiBao.Text.Trim();
                dondt.NgayBao = dateBao.Value;
                if (_cDonDT.Them(dondt))
                {
                    if (dondt.DienThoai!=""&&dondt.DanhBo!=""&& _cTTKH.CheckExist(dondt.DienThoai, dondt.DanhBo) == false)
                    {
                        ThongTinKhachHang entity = new ThongTinKhachHang();
                        entity.DienThoai = dondt.DienThoai;
                        entity.DanhBo = dondt.DanhBo;
                        entity.HoTen = dondt.NguoiBao;
                        _cTTKH.Them(entity);
                    }
                    Clear();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
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
                        dondt.NgayBao = dateBao.Value;
                        if (_cDonDT.Sua(dondt))
                        {
                            Clear();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                        MessageBox.Show("Đã lập Đơn Khách Hàng, không Sửa được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                if (_selectedindex != -1)
                    if (MessageBox.Show("Bạn chắc chắn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        if (!_cDonDT.CheckLapDonKH(int.Parse(dgvLichSuDonDT["MaDonDT", _selectedindex].Value.ToString())))
                        {
                            DonDienThoai dondt = _cDonDT.getDonDienThoaibyID(int.Parse(dgvLichSuDonDT["MaDonDT", _selectedindex].Value.ToString()));
                            if (_cDonDT.Xoa(dondt))
                            {
                                Clear();
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                            MessageBox.Show("Đã lập Đơn Khách Hàng, không Xóa được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtDanhBo.Text.Trim()))
            {
                if (_cThuTien.GetMoiNhat(txtDanhBo.Text.Trim()) != null)
                {
                    _hoadon = _cThuTien.GetMoiNhat(txtDanhBo.Text.Trim());
                    txtHoTen.Text = _hoadon.TENKH;
                    txtDiaChi.Text = _hoadon.SO + " " + _hoadon.DUONG + _cDocSo.getPhuongQuanByID(_hoadon.Quan, _hoadon.Phuong);
                    dateBao.Focus();
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
                dateBao.Value = DateTime.Parse(dgvLichSuDonDT["NguoiBao", e.RowIndex].Value.ToString());
            }
            catch
            {

            }
        }

        private void dgvLichSuDonDT_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLichSuDonDT.Columns[e.ColumnIndex].Name == "MaDon" && !string.IsNullOrEmpty(e.Value.ToString()))
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
        }

        private void dgvLichSuDonDT_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvLichSuDonDT.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void dateBao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtHoTen.Focus();
        }

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtDiaChi.Focus();
        }

        private void txtDiaChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtNoiDung.Focus();
        }

        private void txtNoiDung_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtGhiChu.Focus();
        }

        private void txtGhiChu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtDienThoai.Focus();
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtNguoiBao.Focus();
        }

        private void txtNguoiBao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnThem.Focus();
        }
    }
}
