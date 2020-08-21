using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.TongHop;
using ThuTien.LinQ;
using ThuTien.DAL.Doi;

namespace ThuTien.GUI.TongHop
{
    public partial class frmHoaDonChoDieuChinh : Form
    {
        string _mnu = "mnuDCHD";
        CDCHD _cDCHD = new CDCHD();
        CHoaDon _cHoaDon = new CHoaDon();
        TT_HoaDonChoDieuChinh _en = null;

        public frmHoaDonChoDieuChinh()
        {
            InitializeComponent();
        }

        private void frmHoaDonChoDieuChinh_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
            Clear();
        }

        public void LoadView()
        {
            dgvDanhSach.DataSource = _cDCHD.getDS_HDChoDC();
        }

        public void LoadTTKH(HOADON en)
        {
            txtHoTen.Text = en.TENKH;
            txtDiaChi.Text = en.SO + " " + en.DUONG;
        }

        public void LoadEntity(TT_HoaDonChoDieuChinh en)
        {
            txtDanhBo.Text = en.DanhBo;
            txtHoTen.Text = en.HoTen;
            txtDiaChi.Text = en.DiaChi;
            txtNam.Text = en.Nam.ToString();
            cmbKy.SelectedItem = en.Ky.ToString();
        }

        public void Clear()
        {
            txtDanhBo.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtNam.Text = DateTime.Now.Year.ToString();
            cmbKy.SelectedItem = DateTime.Now.Month.ToString();
            dgvDanhSach.DataSource = _cDCHD.getDS_HDChoDC();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    if (_cHoaDon.CheckExist(txtDanhBo.Text.Trim().Replace(" ", ""), int.Parse(txtNam.Text.Trim()), int.Parse(cmbKy.SelectedItem.ToString())) == true)
                    {
                        MessageBox.Show("Hóa Đơn Đã Tồn Tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (_cDCHD.checkExist_HDChoDC(txtDanhBo.Text.Trim().Replace(" ", ""), int.Parse(txtNam.Text.Trim()), int.Parse(cmbKy.SelectedItem.ToString())) == true)
                    {
                        MessageBox.Show("Đã Tồn Tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    TT_HoaDonChoDieuChinh en = new TT_HoaDonChoDieuChinh();
                    en.DanhBo = txtDanhBo.Text.Trim().Replace(" ", "");
                    en.HoTen = txtHoTen.Text.Trim();
                    en.DiaChi = txtDiaChi.Text.Trim();
                    en.Nam = int.Parse(txtNam.Text.Trim());
                    en.Ky = int.Parse(cmbKy.SelectedItem.ToString());
                    if (_cDCHD.Them_HDChoDC(en) == true)
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
                if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
                {
                    if (_en != null && MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (_cDCHD.Xoa_HDChoDC(_en) == true)
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

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _en = _cDCHD.get_HDChoDC(dgvDanhSach["DanhBo", e.RowIndex].Value.ToString(), int.Parse(dgvDanhSach["Nam", e.RowIndex].Value.ToString()), int.Parse(dgvDanhSach["Ky", e.RowIndex].Value.ToString()));
                if (_en != null)
                    LoadEntity(_en);
            }
            catch (Exception)
            {

            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtDanhBo.Text.Trim() != "" && txtDanhBo.Text.Trim().Replace(" ", "").Length == 11)
            {
                HOADON en = _cHoaDon.GetMoiNhat(txtDanhBo.Text.Trim().Replace(" ", ""));
                if (en != null)
                    LoadTTKH(en);
                else
                    MessageBox.Show("Danh Bộ không tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
