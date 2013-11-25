﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.GUI.KhachHang;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.DAL.CapNhat;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmDSDCBD : Form
    {
        CChuyenDi _cChuyenDi = new CChuyenDi();
        CDonKH _cDonKH = new CDonKH();
        CDCBD _cDCBD = new CDCBD();
        CTTKH _cTTKH = new CTTKH();
        

        public frmDSDCBD()
        {
            InitializeComponent();
            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void frmDSDCBD_Load(object sender, EventArgs e)
        {
            //dgvDSDCBD.AutoGenerateColumns = false;
            //DataGridViewComboBoxColumn cmbColumn = (DataGridViewComboBoxColumn)dgvDSDCBD.Columns["MaChuyen"];
            //cmbColumn.DataSource = _cChuyenDi.LoadDSChuyenDi("DCBD","KTXM");
            //cmbColumn.DisplayMember = "NoiChuyenDi";
            //cmbColumn.ValueMember = "MaChuyen";

            

            ///Tạo đối tượng LookUpEdit
            RepositoryItemLookUpEdit myLookUpEdit = new RepositoryItemLookUpEdit();
            ///Tạo đối tượng Column
            LookUpColumnInfo column = new LookUpColumnInfo();
            column.FieldName = "NoiChuyenDi";
            column.Caption = "Nơi Chuyển Đi";
            column.Width = 70;
            myLookUpEdit.AppearanceDropDown.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            myLookUpEdit.AppearanceDropDownHeader.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            myLookUpEdit.Columns.Add(column);
            ///Load dữ liệu
            myLookUpEdit.DataSource = _cChuyenDi.LoadDSChuyenDi("DCBD", "KTXM");
            myLookUpEdit.DisplayMember = "NoiChuyenDi";
            myLookUpEdit.ValueMember = "MaChuyen";
            ///Add LookUpEdit vào GridControl
            ((GridView)gridControl.MainView).Columns["MaChuyen"].ColumnEdit = myLookUpEdit;

            radChuaDuyet.Checked = true;

            gridControl.LevelTree.Nodes.Add("Chi Tiết", gridViewCTDCBD);
        }

        #region dsg
        private void dgvDSDCBD_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSDCBD.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSDCBD_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDSDCBD.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                frmShowDonKH frm = new frmShowDonKH(_cDonKH.getDonKHbyID(decimal.Parse(dgvDSDCBD["MaDon", dgvDSDCBD.CurrentRow.Index].Value.ToString())));
                frm.ShowDialog();
            }
        }

        private void dgvDSDCBD_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                ///Khi chuột phải Selected-Row sẽ được chuyển đến nơi click chuột
                dgvDSDCBD.CurrentCell = dgvDSDCBD.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dgvDSDCBD_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvDSDCBD.Rows.Count > 0 && e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(dgvDSDCBD, new Point(e.X, e.Y));
            }
        }
        #endregion
        
        private void radDaDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radDaDuyet.Checked)
            {
                //dgvDSDCBD.DataSource = _cDCBD.LoadDSKTXMDaDuyet();
                gridControl.DataSource = _cDCBD.LoadDSDCBDDaDuyet().Tables["DCBD"];
            }
        }

        private void radChuaDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radChuaDuyet.Checked)
            {
                //dgvDSDCBD.DataSource = _cDCBD.LoadDSKTXMChuaDuyet();
                gridControl.DataSource = _cDCBD.LoadDSDCBDChuaDuyet();
            }
        }

        private void điềuChỉnhBiếnĐộngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> source = new Dictionary<string, string>();
            ///Lấy dữ liệu tại selected row
            //int selRows = ((GridView)gridControl.MainView).GetSelectedRows()[0];
            //DataRowView selRow = (DataRowView)(((GridView)gridControl.MainView).GetRow(selRows));
            DataRowView selRow = (DataRowView)gridViewDCBD.GetRow(gridViewDCBD.GetSelectedRows()[0]);
            //decimal _MaDon = decimal.Parse(selRow["MaDon"].ToString());
            //string _DanhBo = selRow["DanhBo"].ToString();       
            source.Add("MaDon", selRow["MaDon"].ToString());
            source.Add("DanhBo", selRow["DanhBo"].ToString());
            ///Nơi Chuyển Đến, dùng để xét Đơn Khách Hàng nhận từ bản nào, Vì lúc ta load danh sách đơn chưa duyệt ở nhiều bảng
            source.Add("MaNoiChuyenDen", selRow["MaNoiChuyenDen"].ToString());
            source.Add("NoiChuyenDen",selRow["NoiChuyenDen"].ToString());
            source.Add("LyDoChuyenDen", selRow["LyDoChuyenDen"].ToString());

            frmDCBD frm = new frmDCBD(source);
            if (frm.ShowDialog() == DialogResult.OK)
                gridControl.DataSource = _cDCBD.LoadDSDCBDChuaDuyet();
        }

        private void điềuChỉnhHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> source = new Dictionary<string, string>();
            DataRowView selRow = (DataRowView)gridViewDCBD.GetRow(gridViewDCBD.GetSelectedRows()[0]);
            source.Add("MaDon", selRow["MaDon"].ToString());
            source.Add("DanhBo", selRow["DanhBo"].ToString());
            source.Add("HoTen", selRow["HoTen"].ToString());
            ///Nơi Chuyển Đến, dùng để xét Đơn Khách Hàng nhận từ bản nào, Vì lúc ta load danh sách đơn chưa duyệt ở nhiều bảng
            source.Add("MaNoiChuyenDen", selRow["MaNoiChuyenDen"].ToString());
            source.Add("NoiChuyenDen", selRow["NoiChuyenDen"].ToString());
            source.Add("LyDoChuyenDen", selRow["LyDoChuyenDen"].ToString());
            frmDCHDN frm = new frmDCHDN(source);
            if (frm.ShowDialog() == DialogResult.OK)
                gridControl.DataSource = _cDCBD.LoadDSDCBDChuaDuyet();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void gridView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (radChuaDuyet.Checked && gridControl.MainView.RowCount > 0 && e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(gridControl, new Point(e.X, e.Y));
            }
        }

        private void gridViewDCBD_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaDon" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(4, "-");
            }
        }

       
        
    }
}
