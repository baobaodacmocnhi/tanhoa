using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TCTB_Web.DAL.TCTB;
using TCTB_Web.Database;
using TCTB_Web.DAL.QuanTri;

namespace TCTB_Web
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        CGiamSat _cGiamSat = new CGiamSat();
        CThiCong _cThiCong = new CThiCong();
        CBaoBe _cBaoBe = new CBaoBe();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack==false)
                LoaddgvBaoBe();

            cmbGiamSat_GNKDT.DataSource = _cGiamSat.GetDS_GNKDT();
            cmbGiamSat_GNKDT.DataTextField = "TenNV";
            cmbGiamSat_GNKDT.DataValueField = "ID";
            cmbGiamSat_GNKDT.DataBind();
            ///
            cmbGiamSat_KTCN.DataSource = _cGiamSat.GetDS_KTCN();
            cmbGiamSat_KTCN.DataTextField = "TenNV";
            cmbGiamSat_KTCN.DataValueField = "ID";
            cmbGiamSat_KTCN.DataBind();
            ///
            cmbSuaBe.DataSource = _cThiCong.GetDS();
            cmbSuaBe.DataTextField = "TenNV";
            cmbSuaBe.DataValueField = "ID";
            cmbSuaBe.DataBind();
        }

        public void LoaddgvBaoBe()
        {
            dgvBaoBe.DataSource = _cBaoBe.GetDS();
            dgvBaoBe.DataBind();
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            
        }

        protected void dgvBaoBe_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvBaoBe.EditIndex = e.NewEditIndex;
            LoaddgvBaoBe();
        }

        protected void dgvBaoBe_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvBaoBe.EditIndex = -1;
            LoaddgvBaoBe();
        }

        protected void dgvBaoBe_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = dgvBaoBe.Rows[e.RowIndex];
            KT_BaoBe_BB entity = _cBaoBe.Get(int.Parse(dgvBaoBe.DataKeys[e.RowIndex].Values[0].ToString()));
            entity.SoNha = (row.FindControl("txtSoNha") as TextBox).Text;
            entity.TenDuong = (row.FindControl("txtTenDuong") as TextBox).Text;
            entity.Phuong = (row.FindControl("txtPhuong") as TextBox).Text;

            if (_cBaoBe.Sua(entity))
            {
                dgvBaoBe.EditIndex = -1;
                LoaddgvBaoBe();
            }
        }

        protected void dgvBaoBe_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
             KT_BaoBe_BB entity = _cBaoBe.Get(int.Parse(dgvBaoBe.DataKeys[e.RowIndex].Values[0].ToString()));
             //if (_cBaoBe.Xoa(entity))
             //{
             //    LoaddgvBaoBe();
             //}
        }

        protected void dgvBaoBe_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && dgvBaoBe.EditIndex != e.Row.RowIndex)
            {
                ((LinkButton)e.Row.Cells[0].Controls[0]).OnClientClick = "return confirm('Are you sure you want to delete?');";
            }
        }

        protected void chkGiamSat_GNKDT_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGiamSat_GNKDT.Checked == true)
                cmbGiamSat_GNKDT.Enabled = true;
            else
                cmbGiamSat_GNKDT.Enabled = false;
        }

        protected void chkGiamSat_KTCN_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGiamSat_KTCN.Checked == true)
                cmbGiamSat_KTCN.Enabled = true;
            else
                cmbGiamSat_KTCN.Enabled = false;
        }

    }
}