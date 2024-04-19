using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmCapDinhMucNuocCCCD_Show : Form
    {
        CChungTu _cChungTu = new CChungTu();
        public frmCapDinhMucNuocCCCD_Show()
        {
            InitializeComponent();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvDSSoDangKy.DataSource = _cChungTu.getDS_ChiTiet_CreateDates(CTaiKhoan.MaUser, dateTu.Value, dateDen.Value);
            txtTongCCCD.Text = dgvDSSoDangKy.Rows.Count.ToString();
            txtTongDanhBo.Text = _cChungTu.countDS_ChiTiet_CreateDates(CTaiKhoan.MaUser, dateTu.Value, dateDen.Value).ToString();
        }

        private void frmCapDinhMucNuocCCCD_Show_Load(object sender, EventArgs e)
        {
            dgvDSSoDangKy.AutoGenerateColumns = false;
        }

        private void dgvDSSoDangKy_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSSoDangKy.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
    }
}
