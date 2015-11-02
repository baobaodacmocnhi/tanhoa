using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ThuTien.GUI.HanhThu
{
    public partial class frmThongTinKhachHang : Form
    {
        string _mnu = "mnuThongTinKhachHang";
        public frmThongTinKhachHang()
        {
            InitializeComponent();
        }

        private void frmThongTinKhachHang_Load(object sender, EventArgs e)
        {
            dgvTTKH.AutoGenerateColumns = false;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }
    }
}
