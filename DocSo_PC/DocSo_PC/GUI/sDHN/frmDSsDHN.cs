using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.sDHN;

namespace DocSo_PC.GUI.sDHN
{
    public partial class frmDSsDHN : Form
    {
        string _mnu = "mnuDSsDHN";
        CsDHN _csDHN = new CsDHN();

        public frmDSsDHN()
        {
            InitializeComponent();
        }

        private void frmDSsDHN_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {

        }

        private void btnCapNhatDS_Click(object sender, EventArgs e)
        {

        }
    }
}
