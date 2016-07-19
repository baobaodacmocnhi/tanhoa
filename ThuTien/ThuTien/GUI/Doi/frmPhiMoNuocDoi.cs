using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.DongNuoc;
using ThuTien.DAL.Doi;
using ThuTien.LinQ;

namespace ThuTien.GUI.Doi
{
    public partial class frmPhiMoNuocDoi : Form
    {
        CDongNuoc _cDongNuoc = new CDongNuoc();
        CHoaDon _cHoaDon = new CHoaDon();
        CPhiMoNuocDoi _cPhiMoNuocDoi = new CPhiMoNuocDoi();

        public frmPhiMoNuocDoi()
        {
            InitializeComponent();
        }

        private void frmPhiMoNuocDoi_Load(object sender, EventArgs e)
        {
            dgvPhiMoNuoc.AutoGenerateColumns = false;
            dgvPhiMoNuocDoi.AutoGenerateColumns = false;

            dgvPhiMoNuocDoi.DataSource = _cPhiMoNuocDoi.GetDS();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvPhiMoNuoc.DataSource = _cDongNuoc.GetDSKQDongNuoc(dateTu.Value, dateDen.Value);
        }

        private void dgvPhiMoNuoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPhiMoNuoc.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null && e.Value.ToString().Length==11)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
        }

        private void dgvPhiMoNuoc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvPhiMoNuoc.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvPhiMoNuocDoi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPhiMoNuoc.Columns[e.ColumnIndex].Name == "DanhBo_Doi" && e.Value != null && e.Value.ToString().Length == 11)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
        }

        private void dgvPhiMoNuocDoi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvPhiMoNuocDoi.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }


        private void dgvPhiMoNuocDoi_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPhiMoNuocDoi.Columns[e.ColumnIndex].Name == "DanhBo_Doi" && dgvPhiMoNuocDoi["DanhBo_Doi", e.RowIndex].Value.ToString().Replace(" ", "").Length == 11)
            {
                HOADON hoadon = _cHoaDon.GetMoiNhat(dgvPhiMoNuocDoi[e.ColumnIndex, e.RowIndex].Value.ToString().Replace(" ", ""));

                if (hoadon != null)
                {
                    dgvPhiMoNuocDoi["HoTen_Doi", e.RowIndex].Value = hoadon.TENKH;
                    dgvPhiMoNuocDoi["DiaChi_Doi", e.RowIndex].Value = hoadon.SO + " " + hoadon.DUONG;

                    TT_PhiMoNuocDoi entity = new TT_PhiMoNuocDoi();

                    entity.DanhBo = dgvPhiMoNuocDoi["DanhBo_Doi", e.RowIndex].Value.ToString().Replace(" ", "");
                    entity.HoTen = dgvPhiMoNuocDoi["HoTen_Doi", e.RowIndex].Value.ToString();
                    entity.DiaChi = dgvPhiMoNuocDoi["DiaChi_Doi", e.RowIndex].Value.ToString();

                    if (_cPhiMoNuocDoi.Them(entity))
                        dgvPhiMoNuocDoi["ID_Doi", e.RowIndex].Value = entity.ID;
                }
            }
        }

        private void dgvPhiMoNuocDoi_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (e.Row.Cells["ID_Doi"].Value != null && string.IsNullOrEmpty(e.Row.Cells["ID_Doi"].Value.ToString()))
            {
                TT_PhiMoNuocDoi entity = _cPhiMoNuocDoi.Get(int.Parse(e.Row.Cells["ID_Doi"].Value.ToString()));

                _cPhiMoNuocDoi.Xoa(entity);
            }
        }

    }
}
