using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.ToTruong;
using DocSo_PC.LinQ;
using DocSo_PC.DAL;

namespace DocSo_PC.GUI.ToTruong
{
    public partial class frmDHNDienTu : Form
    {
        CDHNDienTu _cDHNDienTu = new CDHNDienTu();
        CDHN _cDHN = new CDHN();
        public frmDHNDienTu()
        {
            InitializeComponent();
        }

        private void frmDHNDienTu_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
            cmbDanhBo.DataSource = _cDHNDienTu.getDS();
            cmbDanhBo.ValueMember = "TableName";
            cmbDanhBo.DisplayMember = "DanhBo";
        }

        private void cmbDanhBo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDanhBo.SelectedIndex > -1)
            {
                TB_DULIEUKHACHHANG ttkh = _cDHN.get(cmbDanhBo.Text);
                if (ttkh != null)
                {
                    txtHoTen.Text = ttkh.HOTEN;
                    txtDiaChi.Text = ttkh.SONHA + " " + ttkh.TENDUONG;
                }
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = _cDHNDienTu.getDS_ChiSo(cmbDanhBo.SelectedValue.ToString(), dateTuNgay.Value, dateDenNgay.Value);
        }

        private void dgvDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }


    }
}
