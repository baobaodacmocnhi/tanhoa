using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.Doi;
using DocSo_PC.DAL.QuanTri;
using DocSo_PC.LinQ;
using DocSo_PC.DAL;

namespace DocSo_PC.GUI.BaoCao
{
    public partial class frmThongKe : Form
    {
        CDocSo _cDocSo = new CDocSo();
        CTo _cTo = new CTo();
        CDHN _cDHN = new CDHN();

        public frmThongKe()
        {
            InitializeComponent();
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
            cmbNam.DataSource = _cDocSo.getDS_Nam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";
            cmbKy.SelectedItem = CNguoiDung.Ky;
            cmbDot.SelectedItem = CNguoiDung.Dot;

            DataTable dtCode = _cDocSo.getDS_Code2023();
            DataRow dr = dtCode.NewRow();
            dr["Code"] = "Tất Cả";
            dtCode.Rows.InsertAt( dr,0);
            cmbCode.DataSource = dtCode;
            cmbCode.DisplayMember = "Code";
            cmbCode.ValueMember = "Code";

            if (CNguoiDung.Doi)
            {
                cmbTo.Visible = true;
                List<To> lst = _cTo.getDS_HanhThu();
                To en = new To();
                en.MaTo = 0;
                en.TenTo = "Tất Cả";
                lst.Insert(0, en);
                cmbTo.DataSource = lst;
                cmbTo.DisplayMember = "TenTo";
                cmbTo.ValueMember = "MaTo";
            }
            else
            {
                lbTo.Text = "Tổ  " + CNguoiDung.TenTo;
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = _cDocSo.getThongKe(cmbTo.SelectedValue.ToString(), cmbNam.SelectedValue.ToString(), cmbKy.SelectedItem.ToString(), cmbDot.SelectedItem.ToString(), cmbCode.SelectedValue.ToString(), txtTieuThu1.Text.Trim(), txtTieuThu2.Text.Trim(), txtSoKy.Text.Trim());
        }

        private void chkGieng_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGieng.Checked)
                dgvDanhSach.DataSource = _cDHN.getThongKe_Gieng();
            else
                dgvDanhSach.DataSource = null;
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
