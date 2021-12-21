using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.Doi;

namespace DocSo_PC.GUI.Doi
{
    public partial class frmChuyenBilling : Form
    {
        string _mnu = "mnuChuyenBilling";
        CDocSo _cDocSo = new CDocSo();
        CChuyenBilling _cChuyenBilling = new CChuyenBilling();

        public frmChuyenBilling()
        {
            InitializeComponent();
        }

        private void frmChuyenBilling_Load(object sender, EventArgs e)
        {
            cmbNam.DataSource = _cDocSo.getDS_Nam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";
            cmbKy.SelectedItem = DateTime.Now.Month.ToString();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                _cChuyenBilling.OpenConnectionTCT();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
