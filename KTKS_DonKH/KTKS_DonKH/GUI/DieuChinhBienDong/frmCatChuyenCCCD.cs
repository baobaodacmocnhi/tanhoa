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
    public partial class frmCatChuyenCCCD : Form
    {
        string _mnu = "mnuCatChuyenCCCD";
        CChungTu _cChungTu = new CChungTu();
        public frmCatChuyenCCCD()
        {
            InitializeComponent();
        }

        private void frmCatChuyenCCCD_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
        }

        private void dgvDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (radTCT.Checked)
                flag = true;
            dgvDanhSach.DataSource = _cChungTu.getDS_CatChuyenCCCD(flag, dateTu.Value, dateDen.Value);
        }
    }
}
