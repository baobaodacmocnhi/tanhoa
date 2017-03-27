using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TCTB_Web.DAL.QuanTri;
using TCTB_Web.Database;

namespace TCTB_Web
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        CGiamSat _cGiamSat = new CGiamSat();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
                LoaddgvNhanVien();
        }

        public void LoaddgvNhanVien()
        {
            dgvNhanVien.DataSource = _cGiamSat.GetDS_KTCN();
            dgvNhanVien.DataBind();
        }

        public void Clear()
        {
            //txtHoTen.Text = "";
            //txtDienThoai.Text = "";
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text.Trim() != "")
            {
                KT_NhanVienGiamSat entity = new KT_NhanVienGiamSat();
                entity.TenNV = txtHoTen.Text.Trim();
                entity.DienThoai = txtDienThoai.Text.Trim();
                entity.KTCN = true;
                if (_cGiamSat.Them(entity))
                {
                    LoaddgvNhanVien();
                    Clear();
                }
            }
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Trim() != "")
            {
                KT_NhanVienGiamSat entity = _cGiamSat.Get(int.Parse(txtID.Text.Trim()));
                entity.TenNV = txtHoTen.Text.Trim();
                entity.DienThoai = txtDienThoai.Text.Trim();
                if (_cGiamSat.Sua(entity))
                {
                    LoaddgvNhanVien();
                    Clear();
                }
            }
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Trim() != "")
            {
                KT_NhanVienGiamSat entity = _cGiamSat.Get(int.Parse(txtID.Text.Trim()));
                if (_cGiamSat.Xoa(entity))
                {
                    LoaddgvNhanVien();
                    Clear();
                }
            }
        }

        protected void dgvNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtID.Text = dgvNhanVien.SelectedRow.Cells[0].Text;
            txtHoTen.Text = HttpUtility.HtmlDecode(dgvNhanVien.SelectedRow.Cells[1].Text);
            txtDienThoai.Text = dgvNhanVien.SelectedRow.Cells[2].Text;
        }
    }
}