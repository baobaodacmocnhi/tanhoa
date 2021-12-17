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

namespace DocSo_PC.GUI.ToTruong
{
    public partial class frmXuLySoLieu : Form
    {
        string _mnu = "mnuXuLySoLieu";
        CDocSo _cDocSo = new CDocSo();
        CTo _cTo = new CTo();
        CMayDS _cMayDS = new CMayDS();
        bool _flagLoadFirst = false;

        public frmXuLySoLieu()
        {
            InitializeComponent();
        }

        private void frmXuLySoLieu_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;

            cmbNam.DataSource = _cDocSo.getDS_Nam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";
            cmbKy.SelectedItem = DateTime.Now.Month.ToString();
            DataTable dtCode = _cDocSo.getDS_Code();
            DataRow dr = dtCode.NewRow();
            dr["Code"] = "Tất Cả";
            dtCode.Rows.InsertAt(dr, 0);
            cmbCode.DataSource = dtCode;
            cmbCode.DisplayMember = "Code";
            cmbCode.ValueMember = "Code";
            if (CNguoiDung.Doi)
            {
                cmbTo.Visible = true;

                cmbTo.DataSource = _cTo.getDS_HanhThu();
                cmbTo.DisplayMember = "TenTo";
                cmbTo.ValueMember = "MaTo";
                cmbTo.SelectedIndex = -1;
            }
            else
            {
                lbTo.Text = "Tổ  " + CNguoiDung.TenTo;
                loadMay(CNguoiDung.MaTo.ToString());
            }
            _flagLoadFirst = true;
        }

        public void loadMay(string MaTo)
        {
            DataTable dtMay = _cMayDS.getDS(MaTo);
            DataRow dr = dtMay.NewRow();
            dr["May"] = "Tất Cả";
            dtMay.Rows.InsertAt(dr, 0);
            cmbMay.DataSource = dtMay;
            cmbMay.DisplayMember = "May";
            cmbMay.ValueMember = "May";
            //cmbMay.SelectedIndex = ;
        }

        private void cmbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_flagLoadFirst == true && cmbTo.SelectedIndex > -1)
                loadMay(cmbTo.SelectedValue.ToString());
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (txtDanhBo.Text.Trim().Replace(" ", "").Replace("-", "") != "")
            {

            }
            else
            {

            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo.Text.Trim().Replace(" ", "").Replace("-", "") != "")
                btnXem.PerformClick();
        }
    }
}
