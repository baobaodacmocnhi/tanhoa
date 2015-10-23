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
    public partial class frmChuyenTien : Form
    {
        string _DanhBo = "";
        string _SoTien = "";
        CTienDu _cTienDu = new CTienDu();

        public frmChuyenTien()
        {
            InitializeComponent();
        }

        public frmChuyenTien(string DanhBo, string SoTien)
        {
            _DanhBo = DanhBo;
            _SoTien = SoTien;
            InitializeComponent();
        }

        private void frmChuyenTien_Load(object sender, EventArgs e)
        {
            this.Location = new Point(200, 150);

            txtDanhBoA.Text = _DanhBo.Insert(7, " ").Insert(4, " ");
            txtSoTienA.Text = _SoTien;
        }

        private void txtDanhBoB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBoB.Text.Trim().Length == 11)
            {
                if (_cTienDu.CheckExist(txtDanhBoB.Text.Trim().Replace(" ", "")))
                {
                    txtSoTienB.Text = _cTienDu.GetTienDu(txtDanhBoB.Text.Trim().Replace(" ", "")).ToString();
                }
                else
                    MessageBox.Show("Danh Bộ này chưa được Thêm vào Tiền Dư, Xin liên hệ T.CNTT", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtSoTienChuyen_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(txtSoTienChuyen.Text.Trim()) > int.Parse(txtSoTienA.Text.Trim()))
                txtSoTienChuyen.Text = txtSoTienA.Text;
        }

        private void btnChuyen_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuDangNganChuyenKhoan", "Sua"))
            {
                if (MessageBox.Show("Bạn có chắc chắn Chuyển?", "Xác nhận chuyển", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (_cTienDu.Update(txtDanhBoA.Text.Trim().Replace(" ", ""), int.Parse(txtSoTienChuyen.Text.Trim()) * -1, "Chuyển Tiền"))
                        if (_cTienDu.Update(txtDanhBoB.Text.Trim().Replace(" ", ""), int.Parse(txtSoTienChuyen.Text.Trim()), "Chuyển Tiền"))
                        {
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            this.Close();
                        }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
