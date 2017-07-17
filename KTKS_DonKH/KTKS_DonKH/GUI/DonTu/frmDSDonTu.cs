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
    public partial class frmDSDonTu : Form
    {
        CDonTu _cDonTu = new CDonTu();

        public frmDSDonTu()
        {
            InitializeComponent();
        }

        private void frmDSDonTu_Load(object sender, EventArgs e)
        {
            dgvDSDonTu.AutoGenerateColumns = false;
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                case "Danh Bộ":
                case "Số Công Văn":
                    txtNoiDungTimKiem.Visible = true;
                    txtNoiDungTimKiem2.Visible = true;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Ngày":
                    txtNoiDungTimKiem.Visible = false;
                    txtNoiDungTimKiem2.Visible = false;
                    panel_KhoangThoiGian.Visible = true;
                    break;
                default:
                    txtNoiDungTimKiem.Visible = false;
                    txtNoiDungTimKiem2.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    break;
            }
            dgvDSDonTu.DataSource = null;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                //case "Mã Đơn":
                //    if (txtNoiDungTimKiem.Text.Trim() != "" && txtNoiDungTimKiem2.Text.Trim() != "")
                //        dgvDSDonTu.DataSource = _cDonKH.GetDS(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Replace("-", "")));
                //    else
                //        if (txtNoiDungTimKiem.Text.Trim() != "")
                //            dgvDSDonTu.DataSource = _cDonKH.GetDS(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                //    break;
                //case "Danh Bộ":
                //    if (txtNoiDungTimKiem.Text.Trim() != "")
                //        dgvDSDonTu.DataSource = _cDonKH.GetDSByDanhBo(txtNoiDungTimKiem.Text.Trim());
                //    break;
                //case "Số Công Văn":
                //    if (txtNoiDungTimKiem.Text.Trim() != "")
                //        dgvDSDonTu.DataSource = _cDonKH.GetDSBySoCongVan(txtNoiDungTimKiem.Text.Trim().ToUpper());
                //    break;
                case "Ngày":
                    dgvDSDonTu.DataSource = _cDonTu.GetDS(dateTu.Value, dateDen.Value);
                    break;
                default:
                    break;
            }
        }

        
    }
}
