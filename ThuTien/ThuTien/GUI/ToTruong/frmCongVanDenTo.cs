using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.VanThu;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;

namespace ThuTien.GUI.ToTruong
{
    public partial class frmCongVanDenTo : Form
    {
        CCongVanDen _cCongVanDen = new CCongVanDen();
        CTo _cTo = new CTo();

        public frmCongVanDenTo()
        {
            InitializeComponent();
        }

        private void frmCongVanDenTo_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
            if (CNguoiDung.Doi)
            {
                cmbTo.Visible = true;

                List<TT_To> lstTo = _cTo.getDS_HanhThu();
                TT_To to = new TT_To();
                to.MaTo = 0;
                to.TenTo = "Tất Cả";
                lstTo.Insert(0, to);
                cmbTo.DataSource = lstTo;
                cmbTo.DisplayMember = "TenTo";
                cmbTo.ValueMember = "MaTo";
            }
            else
                lbTo.Text = "Tổ  " + CNguoiDung.TenTo;
            btnXem.PerformClick();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.Doi)
            {
                ///chọn tất cả các tổ
                if (cmbTo.SelectedIndex == 0)
                    dgvDanhSach.DataSource = _cCongVanDen.getDS_Ton_Doi("false");
                else
                    ///chọn 1 tổ cụ thể
                    if (cmbTo.SelectedIndex > 0)
                        dgvDanhSach.DataSource = _cCongVanDen.getDS_Ton_To("false", cmbTo.SelectedValue.ToString());
            }
            else
                dgvDanhSach.DataSource = _cCongVanDen.getDS_Ton_To("false", cmbTo.SelectedValue.ToString());
        }
    }
}
