﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ThuTien.GUI.TimKiem
{
    public partial class frmTimKiemForm : Form
    {
        public frmTimKiemForm()
        {
            InitializeComponent();
        }

        public delegate void GetNoiDung(String NoiDung);
        public GetNoiDung MyGetNoiDung;

        private void frmTimKiem_Load(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNoiDung.Text.Trim()))
            {
                string str = "";
                if (txtNoiDung.Text.Trim().Replace(" ", "").Length == 11)
                    str = txtNoiDung.Text.Trim().Replace(" ", "");
                else
                    str = txtNoiDung.Text.Trim();
                MyGetNoiDung(str);
            }
        }

        private void txtNoiDung_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnTimKiem.PerformClick();
        }

    }
}
