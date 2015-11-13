using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.ChuyenKhoan;
using ThuTien.DAL.QuanTri;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmDieuChinhTienDu : Form
    {
        string _DanhBo = "";
        string _SoTien = "";
        CTienDu _cTienDu = new CTienDu();

        public frmDieuChinhTienDu()
        {
            InitializeComponent();
        }

        public frmDieuChinhTienDu(string DanhBo, string SoTien)
        {
            _DanhBo = DanhBo;
            _SoTien = SoTien;
            InitializeComponent();
        }

        private void frmChuyenTien_Load(object sender, EventArgs e)
        {
            this.Location = new Point(200, 150);

            txtDanhBoCTA.Text = txtDanhBoSuaTien.Text = _DanhBo.Insert(7, " ").Insert(4, " ");
            txtSoTienCTA.Text = txtSoTienCu.Text = _SoTien;

            if (CNguoiDung.MaND == 0)
                btnSua.Enabled = true;
            else
                btnSua.Enabled = false;
        }

        private void txtDanhBoCTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBoCTB.Text.Trim().Length == 11)
            {
                if (_cTienDu.CheckExist(txtDanhBoCTB.Text.Trim().Replace(" ", "")))
                {
                    txtSoTienCTB.Text = _cTienDu.GetTienDu(txtDanhBoCTB.Text.Trim().Replace(" ", "")).ToString();
                }
                else
                    MessageBox.Show("Danh Bộ này chưa được Thêm vào Tiền Dư, Xin liên hệ T.CNTT", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtSoTienChuyen_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(txtSoTienChuyen.Text.Trim()) > int.Parse(txtSoTienCTA.Text.Trim()))
                txtSoTienChuyen.Text = txtSoTienCTA.Text;
        }

        private void btnChuyen_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuDangNganChuyenKhoan", "Sua"))
            {
                if (MessageBox.Show("Bạn có chắc chắn Chuyển?", "Xác nhận chuyển", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (txtDanhBoCTA.Text.Trim().Replace(" ", "").Length == 11 && txtDanhBoCTB.Text.Trim().Replace(" ", "").Length == 11 && int.Parse(txtSoTienChuyen.Text.Trim()) > 0 && int.Parse(txtSoTienCTA.Text.Trim()) > 0)
                        if (_cTienDu.Update(txtDanhBoCTA.Text.Trim().Replace(" ", ""), int.Parse(txtSoTienChuyen.Text.Trim()) * -1, "Chuyển Tiền",txtGhiChuChuyen.Text.Trim()))
                            if (_cTienDu.Update(txtDanhBoCTB.Text.Trim().Replace(" ", ""), int.Parse(txtSoTienChuyen.Text.Trim()), "Chuyển Tiền", txtGhiChuChuyen.Text.Trim()))
                            {
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                                this.Close();
                            }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn Sửa?", "Xác nhận sửa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (int.Parse(txtSoTienMoi.Text.Trim()) >= 0)
                    if (_cTienDu.Update(txtDanhBoSuaTien.Text.Trim().Replace(" ", ""), int.Parse(txtSoTienCu.Text.Trim()) * -1, "Điều Chỉnh Tiền", txtGhiChuSua.Text.Trim()))
                        if (_cTienDu.Update(txtDanhBoSuaTien.Text.Trim().Replace(" ", ""), int.Parse(txtSoTienMoi.Text.Trim()), "Điều Chỉnh Tiền", txtGhiChuSua.Text.Trim()))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            this.Close();
                        }
            }
        }

    }
}
