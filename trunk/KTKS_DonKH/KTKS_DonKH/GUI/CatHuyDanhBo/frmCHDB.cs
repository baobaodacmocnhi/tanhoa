using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    public partial class frmCHDB : Form
    {
        Dictionary<string, string> _source = new Dictionary<string, string>();

        public frmCHDB()
        {
            InitializeComponent();
        }

        public frmCHDB(Dictionary<string, string> source)
        {
            InitializeComponent();
            _source = source;
        }

        private void frmCHDB_Load(object sender, EventArgs e)
        {
            this.Location = new Point(70, 70);

        }

        private void txtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtThoiGianLapCatHuy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        

    }
}
