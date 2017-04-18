using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KTKS_DonKH.GUI.CallCenter
{
    public partial class MessChuaXL : Form
    {
        public MessChuaXL(DataTable tb)
        {
            InitializeComponent();
            dataGrid.DataSource = tb;
        }

        private void MessChuaXL_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
