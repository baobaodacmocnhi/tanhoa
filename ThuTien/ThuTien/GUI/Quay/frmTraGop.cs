using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ThuTien.GUI.Quay
{
    public partial class frmTraGop : Form
    {
        public frmTraGop()
        {
            InitializeComponent();
        }

        private void frmTraGop_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
            dgvTraGop.AutoGenerateColumns = false;
        }
    }
}
