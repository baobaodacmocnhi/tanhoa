using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.Doi;

namespace DocSo_PC.GUI.ToTruong
{
    public partial class frmXemLichSuGhiChu : Form
    {
        CDocSo _cDocSo = new CDocSo();

        public frmXemLichSuGhiChu(string DanhBo)
        {
            InitializeComponent();
            dgvGhiChu.DataSource = _cDocSo.getDS_GhiChu(DanhBo);
        }

        private void frmXemGhiChu_Load(object sender, EventArgs e)
        {
            dgvGhiChu.AutoGenerateColumns = false;
        }

    }
}
