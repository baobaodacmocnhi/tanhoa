using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTCN_CongVan.DAL.QuanTri;
using KTCN_CongVan.LinQ;

namespace KTCN_CongVan.GUI.HeThong
{
    public partial class frmDoiMatKhau : Form
    {
        CUser _cUser = new CUser();

        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnThayDoi_Click(object sender, EventArgs e)
        {
            if (txtMatKhauCu.Text.Trim() != "" && txtMatKhauMoi.Text.Trim() != "" && txtXNMatKhauMoi.Text.Trim() != "")
                if (txtMatKhauMoi.Text.Trim() == txtXNMatKhauMoi.Text.Trim())
                {
                    User en = _cUser.GetByMaND(CUser.ID);
                    en.Password = txtMatKhauMoi.Text.Trim();
                    if (_cUser.Sua(en))
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMatKhauCu.Text = "";
                        txtMatKhauMoi.Text = "";
                        txtXNMatKhauMoi.Text = "";
                    }
                }
                else
                    MessageBox.Show("Xác nhận Mật khẩu không giống nhau", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {

        }
    }
}
