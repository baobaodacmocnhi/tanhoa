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
    public partial class frmDongMoNuocDoi : Form
    {
        CDongNuoc _cDongNuoc = new CDongNuoc();
        CHoaDon _cHoaDon = new CHoaDon();
        CPhiMoNuocDoi _cPhiMoNuocDoi = new CPhiMoNuocDoi();

        public frmDongMoNuocDoi()
        {
            InitializeComponent();
        }

        private void frmPhiMoNuocDoi_Load(object sender, EventArgs e)
        {
            dgvDongNuoc.AutoGenerateColumns = false;
            dgvPhiMoNuoc.AutoGenerateColumns = false;
            dgvPhiMoNuocDoi.AutoGenerateColumns = false;
            
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvPhiMoNuoc.DataSource = _cDongNuoc.GetDSKQDongNuoc_PhiMoNuoc(dateTu.Value, dateDen.Value);
            foreach (DataGridViewRow item in dgvPhiMoNuoc.Rows)
            {
                if (int.Parse(item.Cells["PhiMoNuoc"].Value.ToString()) / _cDongNuoc.GetPhiMoNuoc(int.Parse(item.Cells["CoDHN"].Value.ToString())) > 1)
                    item.DefaultCellStyle.BackColor = Color.Orange;
            }

            dgvPhiMoNuocDoi.DataSource = _cPhiMoNuocDoi.GetDS();
        }

        private void dgvPhiMoNuoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPhiMoNuoc.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null && e.Value.ToString().Length==11)
            {
                e.Value = e.Value.ToString().Insert(7, " ").Insert(4, " ");
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
                    entity.MLT = hoadon.MALOTRINH;
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

        private void radTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (radTatCa_DongNuoc.Checked == true)
                panel2.Enabled = false;
        }

        private void radThoiGian_CheckedChanged(object sender, EventArgs e)
        {
            if (radThoiGian_DongNuoc.Checked == true)
                panel2.Enabled = true;
        }

        private void btnXem_DongNuoc_Click(object sender, EventArgs e)
        {
            if (radTatCa_DongNuoc.Checked == true)
            {
                if (radChuaDongPhi_DongNuoc.Checked == true)
                    dgvDongNuoc.DataSource = _cDongNuoc.getDSKQDongNuoc_ChuaDongPhi();
                else
                    if (radCanMoNuoc_DongNuoc.Checked == true)
                        dgvDongNuoc.DataSource = _cDongNuoc.getDSKQDongNuoc_CanMoNuoc();
                    else
                        if (radTroNgaiMoNuoc_DongNuoc.Checked == true)
                            dgvDongNuoc.DataSource = _cDongNuoc.getDSKQDongNuoc_TroNgaiMoNuoc();
            }
            else
                if (radThoiGian_DongNuoc.Checked == true)
                {
                    if (radChuaDongPhi_DongNuoc.Checked == true)
                        dgvDongNuoc.DataSource = _cDongNuoc.getDSKQDongNuoc_ChuaDongPhi(dateTu_DongNuoc.Value, dateDen_DongNuoc.Value);
                    else
                        if (radCanMoNuoc_DongNuoc.Checked == true)
                            dgvDongNuoc.DataSource = _cDongNuoc.getDSKQDongNuoc_CanMoNuoc(dateTu_DongNuoc.Value, dateDen_DongNuoc.Value);
                        else
                            if (radTroNgaiMoNuoc_DongNuoc.Checked == true)
                                dgvDongNuoc.DataSource = _cDongNuoc.getDSKQDongNuoc_TroNgaiMoNuoc(dateTu_DongNuoc.Value, dateDen_DongNuoc.Value);
                }
        }

        private void dgvDongNuoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDongNuoc.Columns[e.ColumnIndex].Name == "MaDN_DongNuoc" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length-2, "-");
            }
            if (dgvDongNuoc.Columns[e.ColumnIndex].Name == "DanhBo_DongNuoc" && e.Value != null && e.Value.ToString().Length == 11)
            {
                e.Value = e.Value.ToString().Insert(7, " ").Insert(4, " ");
            }
        }

        private void dgvDongNuoc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDongNuoc.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

       


    }
}
