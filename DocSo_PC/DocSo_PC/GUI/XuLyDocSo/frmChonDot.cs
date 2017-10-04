using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DocSo_PC.GUI.XuLyDocSo
{
    public partial class frmChonDot : Form
    {
        public int nam { get; set; }
        public string ky { get; set; }
        public string dot { get; set; }
        public frmChonDot()
        {
            InitializeComponent();
        }

        public void btChonDieuChinh_Click(object sender, EventArgs e)
        {
            nam = int.Parse(cmbNam.Text);
            ky = cmbKy.Text;
            dot = cmbDot.Text;
           // frmDieuChinhDocSo f = new frmDieuChinhDocSo(nam, ky, dot);


        }

        private void frmChonDot_Load(object sender, EventArgs e)
        {
            cmbNam.Items.Add(DateTime.Now.Year - 2);
            cmbNam.Items.Add(DateTime.Now.Year - 1);
            cmbNam.Items.Add(DateTime.Now.Year);
            cmbNam.Items.Add(DateTime.Now.Year + 1);
            cmbNam.SelectedIndex = 2;

            if (DateTime.Now.Day >= 19)
                cmbKy.SelectedIndex = DateTime.Now.Month;
            else
                cmbKy.SelectedIndex = DateTime.Now.Month - 1;
        }
    }
}
