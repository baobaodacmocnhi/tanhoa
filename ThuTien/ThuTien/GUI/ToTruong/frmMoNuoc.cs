using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.DongNuoc;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;

namespace ThuTien.GUI.ToTruong
{
    public partial class frmMoNuoc : Form
    {
        string _mnu = "mnuMoNuoc";
        CDongNuoc _cDongNuoc = new CDongNuoc();

        public frmMoNuoc()
        {
            InitializeComponent();
        }

        private void frmMoNuoc_Load(object sender, EventArgs e)
        {
            dgvKQDongNuoc.AutoGenerateColumns = false;

            btnRefresh.PerformClick();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvKQDongNuoc.DataSource = _cDongNuoc.GetDSCanMoNuoc(CNguoiDung.MaTo);
        }

        private void dgvKQDongNuoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvKQDongNuoc.Columns[e.ColumnIndex].Name == "MaDN" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (dgvKQDongNuoc.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(7, " ").Insert(4, " ");
            }
        }

        private void dgvKQDongNuoc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvKQDongNuoc.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvKQDongNuoc_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvKQDongNuoc.Columns[e.ColumnIndex].Name == "GhiChuTroNgai" && e.FormattedValue.ToString().Replace(" ", "") != dgvKQDongNuoc[e.ColumnIndex, e.RowIndex].Value.ToString())
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    TT_KQDongNuoc kqdongnuoc = _cDongNuoc.GetKQDongNuocByMaKQDN(int.Parse(dgvKQDongNuoc["MaKQDN", e.RowIndex].Value.ToString()));
                    kqdongnuoc.GhiChuTroNgai = e.FormattedValue.ToString();
                    _cDongNuoc.SuaKQ(kqdongnuoc);
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
