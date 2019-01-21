using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrungTamKhachHang.DAL.QuanTri;
using TrungTamKhachHang.LinQ;
using TrungTamKhachHang.DAL.KhachHang;

namespace TrungTamKhachHang.GUI.KhachHang
{
    public partial class frmKhieuNaiKhachHang : Form
    {
        string _mnu = "mnuThongTinKhachHang";
        CKhieuNai _cKN = new CKhieuNai();
        KhieuNai _en = null;

        public frmKhieuNaiKhachHang()
        {
            InitializeComponent();
        }

        public frmKhieuNaiKhachHang(int ID)
        {
            InitializeComponent();
            _en = _cKN.get(ID);
        }

        private void frmKhieuNaiKhachHang_Load(object sender, EventArgs e)
        {
            if (_en != null)
                FillEntity(_en);
        }

        public void FillEntity(KhieuNai en)
        {
            txtDanhBo.Text = en.DanhBo;
            txtHoTen.Text = en.HoTen;
            txtDiaChi.Text = en.DiaChi;
            txtNoiDung.Text = en.NoiDung;
            txtNguoiBao.Text = en.NguoiBao;
            txtDienThoai.Text = en.DienThoai;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CUser.CheckQuyen(_mnu, "Them") == true)
                {
                    KhieuNai en = new KhieuNai();
                    en.DanhBo = txtDanhBo.Text.Trim().Replace(" ", "");
                    en.HoTen = txtHoTen.Text.Trim();
                    en.DiaChi = txtDiaChi.Text.Trim();
                    en.NoiDung = txtNoiDung.Text.Trim();
                    en.NguoiBao = txtNguoiBao.Text.Trim();
                    en.DienThoai = txtDienThoai.Text.Trim();
                    if (_cKN.Them(en) == true)
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
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
                if (CUser.CheckQuyen(_mnu, "Sua") == true)
                {
                    if (_en != null)
                    {
                        if (_cKN.Xoa(_en) == true)
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (CUser.CheckQuyen(_mnu, "Xoa") == true)
                {
                    if (_en != null)
                    {
                        _en.DanhBo = txtDanhBo.Text.Trim().Replace(" ", "");
                        _en.HoTen = txtHoTen.Text.Trim();
                        _en.DiaChi = txtDiaChi.Text.Trim();
                        _en.NoiDung = txtNoiDung.Text.Trim();
                        _en.NguoiBao = txtNguoiBao.Text.Trim();
                        _en.DienThoai = txtDienThoai.Text.Trim();
                        if (_cKN.Sua(_en) == true)
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
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
    }
}
