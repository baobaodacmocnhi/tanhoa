using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ThuTien.GUI.TimKiem
{
    public partial class frmTimKiem : Form
    {
        public frmTimKiem()
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
                MyGetNoiDung(txtNoiDung.Text.Trim());
        }
    }
}
