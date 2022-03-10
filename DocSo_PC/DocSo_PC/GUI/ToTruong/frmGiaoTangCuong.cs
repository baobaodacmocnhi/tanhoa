using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.QuanTri;
using DocSo_PC.LinQ;
using System.Data.SqlClient;
using DocSo_PC.DAL.Doi;

namespace DocSo_PC.GUI.ToTruong
{
    public partial class frmGiaoTangCuong : Form
    {
        string _mnu = "mnuGiaoTangCuong";
        CDocSo _cDocSo = new CDocSo();
        CTo _cTo = new CTo();
        CMayDS _cMayDS = new CMayDS();
        bool _flagLoadFirst = false;

        public frmGiaoTangCuong()
        {
            InitializeComponent();
        }

        private void frmGiaoTangCuong_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
            cmbNam.DataSource = _cDocSo.getDS_Nam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";
            cmbKy.SelectedItem = CNguoiDung.Ky;
            cmbDot.SelectedItem = CNguoiDung.Dot;

            if (CNguoiDung.Doi)
            {
                cmbTo.Visible = true;

                cmbTo.DataSource = _cTo.getDS_HanhThu();
                cmbTo.DisplayMember = "TenTo";
                cmbTo.ValueMember = "MaTo";
                loadMay(cmbTo.SelectedValue.ToString());
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
            DataTable dt = _cMayDS.getDS(MaTo);
            cmbMay.DataSource = dt;
            cmbMay.DisplayMember = "May";
            cmbMay.ValueMember = "May";
            cmbMay.SelectedIndex = -1;
            //
            cmbMayTangCuong.DataSource = dt;
            cmbMayTangCuong.DisplayMember = "May";
            cmbMayTangCuong.ValueMember = "May";
            cmbMayTangCuong.SelectedIndex = -1;
        }

        private void dgvDanhSach_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDanhSach.Columns[e.ColumnIndex].Name == "MLT" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(2, " ");
            }
            if (dgvDanhSach.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
        }

        private void dgvDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void cmbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_flagLoadFirst == true && cmbTo.SelectedIndex > -1)
                loadMay(cmbTo.SelectedValue.ToString());
        }

        private void btnGiao_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    string sql = "";
                    foreach (DataGridViewRow item in dgvDanhSach.SelectedRows)
                    {
                        sql += " update DocSo set PhanMay='" + int.Parse(cmbMayTangCuong.SelectedValue.ToString()).ToString("00") + "' where DocSoID='" + item.Cells["DocSoID"].Value.ToString() + "'";
                    }
                    CDocSo._cDAL.ExecuteNonQuery(sql);
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
                dgvDanhSach.DataSource = _cDocSo.getDS_GiaoTangCuong(cmbMay.SelectedValue.ToString(), cmbNam.SelectedValue.ToString(), cmbKy.SelectedItem.ToString(), cmbDot.SelectedItem.ToString());
        }





    }
}