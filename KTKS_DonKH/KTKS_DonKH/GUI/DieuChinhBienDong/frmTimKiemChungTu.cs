using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.DieuChinhBienDong;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmTimKiemChungTu : Form
    {
        CChungTu _cChungTu = new CChungTu();
        CLoaiChungTu _cLoaiChungTu = new CLoaiChungTu();

        public frmTimKiemChungTu()
        {
            InitializeComponent();
        }

        private void frmTimKiemChungTu_Load(object sender, EventArgs e)
        {
            this.Location = new Point(70, 70);
        }

        public delegate void GetNoiDung(String NoiDung);
        public GetNoiDung MyGetNoiDung;

        private void txtMaCT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaCT.Text.Trim()) && e.KeyChar == 13)
            {
                MyGetNoiDung(txtMaCT.Text.Trim());
            }
        }


    }
}
