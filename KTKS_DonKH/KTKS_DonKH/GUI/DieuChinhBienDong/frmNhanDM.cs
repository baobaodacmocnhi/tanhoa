using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmNhanDM : Form
    {
        Dictionary<string, string> _source = new Dictionary<string, string>();


        public frmNhanDM()
        {
            InitializeComponent();
        }

        public frmNhanDM(Dictionary<string, string> source)
        {
            InitializeComponent();
            _source = source;
        }

        private void frmNhanDM_Load(object sender, EventArgs e)
        {
            this.Location = new Point(70, 70);
            txtDanhBo_Nhan.Text = _source["DanhBo"];
            txtKhachHang_Nhan.Text = _source["HoTen"];
            txtDiaChi_Nhan.Text = _source["DiaChi"];
        }
    }
}
