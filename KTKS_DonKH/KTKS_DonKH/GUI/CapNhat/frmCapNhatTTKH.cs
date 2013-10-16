﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.CapNhat;

namespace KTKS_DonKH.GUI.CapNhat
{
    public partial class frmCapNhatTTKH : Form
    {
        CCapNhatTTKH _cCapNhatTTKH = new CCapNhatTTKH();

        public frmCapNhatTTKH()
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

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Files (.dat)|*.dat";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtDuongDan.Text = dialog.FileName;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtDuongDan.Text.Trim() != "")
            {
                _cCapNhatTTKH.CapNhatTTKH(txtDuongDan.Text.Trim());
            }
        }
    }
}
