using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.DonTu;

namespace KTKS_DonKH.GUI.DonTu
{
    public partial class frmNhanDon : Form
    {
        string _mnu = "mnuNhanDon";
        CNhomDon _cNhomDon = new CNhomDon();

        public frmNhanDon()
        {
            InitializeComponent();
        }

        private void frmDonTu_Load(object sender, EventArgs e)
        {
            DataTable dt = _cNhomDon.GetDS("DieuChinh");
            chkcmbDieuChinh.Properties.DataSource = dt;
            chkcmbDieuChinh.Properties.ValueMember = "ID";
            chkcmbDieuChinh.Properties.DisplayMember = "Name";
            chkcmbDieuChinh.Properties.DropDownRows = dt.Rows.Count + 1;

            dt = _cNhomDon.GetDS("KhieuNai");
            chkcmbKhieuNai.Properties.DataSource = dt;
            chkcmbKhieuNai.Properties.ValueMember = "ID";
            chkcmbKhieuNai.Properties.DisplayMember = "Name";
            chkcmbKhieuNai.Properties.DropDownRows = dt.Rows.Count + 1;

            dt = _cNhomDon.GetDS("DHN");
            chkcmbDHN.Properties.DataSource = dt;
            chkcmbDHN.Properties.ValueMember = "ID";
            chkcmbDHN.Properties.DisplayMember = "Name";
            chkcmbDHN.Properties.DropDownRows = dt.Rows.Count + 1;
        }

        private void chkcmbDieuChinh_EditValueChanged(object sender, EventArgs e)
        {
            if (chkcmbDieuChinh.Properties.Items.Count > 0)
            {
                for (int i = 0; i < chkcmbDieuChinh.Properties.Items.Count; i++)
                    if (chkcmbDieuChinh.Properties.Items[i].CheckState == CheckState.Checked && txtNoiDung.Text.Trim().Contains(chkcmbDieuChinh.Properties.Items[i].ToString()) == false)
                    {
                        if (txtNoiDung.Text.Trim() == "")
                            txtNoiDung.Text = chkcmbDieuChinh.Properties.Items[i].ToString();
                        else
                            txtNoiDung.Text += "," + chkcmbDieuChinh.Properties.Items[i].ToString();
                    }
            }
        }

        private void chkcmbKhieuNai_EditValueChanged(object sender, EventArgs e)
        {
            if (chkcmbKhieuNai.Properties.Items.Count > 0)
            {
                for (int i = 0; i < chkcmbKhieuNai.Properties.Items.Count; i++)
                    if (chkcmbKhieuNai.Properties.Items[i].CheckState == CheckState.Checked && txtNoiDung.Text.Trim().Contains(chkcmbKhieuNai.Properties.Items[i].ToString()) == false)
                    {
                        if (txtNoiDung.Text.Trim() == "")
                            txtNoiDung.Text = chkcmbKhieuNai.Properties.Items[i].ToString();
                        else
                            txtNoiDung.Text += "," + chkcmbKhieuNai.Properties.Items[i].ToString();
                    }
            }
        }

        private void chkcmbDHN_EditValueChanged(object sender, EventArgs e)
        {
            if (chkcmbDHN.Properties.Items.Count > 0)
            {
                for (int i = 0; i < chkcmbDHN.Properties.Items.Count; i++)
                    if (chkcmbDHN.Properties.Items[i].CheckState == CheckState.Checked && txtNoiDung.Text.Trim().Contains(chkcmbDHN.Properties.Items[i].ToString()) == false)
                    {
                        if (txtNoiDung.Text.Trim() == "")
                            txtNoiDung.Text = chkcmbDHN.Properties.Items[i].ToString();
                        else
                            txtNoiDung.Text += "," + chkcmbDHN.Properties.Items[i].ToString();
                    }
            }
        }
    }
}
