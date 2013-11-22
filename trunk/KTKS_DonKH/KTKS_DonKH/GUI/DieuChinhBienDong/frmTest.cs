using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.CapNhat;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmTest : Form
    {
        CGiaNuoc _cGiaNuoc = new CGiaNuoc();

        public frmTest()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtKetQua.Text = _cGiaNuoc.TinhTienNuoc(txtDanhBo.Text.Trim(), int.Parse(txtGiaBieu.Text.Trim()), int.Parse(txtDinhMuc.Text.Trim()), int.Parse(txtTieuThu.Text.Trim())).ToString();
        }



    }
}
