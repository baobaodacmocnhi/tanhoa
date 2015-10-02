using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ThuTien.GUI.DongNuoc
{
    public partial class frmVanTu : Form
    {
        public frmVanTu()
        {
            InitializeComponent();
        }

        private void frmVanTu_Load(object sender, EventArgs e)
        {
            dgvVanTu.AutoGenerateColumns = false;

        }

        private void txtDanhBoDK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBoDK.Text.Length == 11)
                btnThemDK.PerformClick();
        }

        private void btnThemDK_Click(object sender, EventArgs e)
        {

        }

        private void btnXoaDK_Click(object sender, EventArgs e)
        {

        }

        
    }
}
