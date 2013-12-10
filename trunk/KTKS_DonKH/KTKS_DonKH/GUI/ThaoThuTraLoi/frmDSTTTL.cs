﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using KTKS_DonKH.DAL.KhachHang;
using DevExpress.XtraGrid.Views.Grid;
using KTKS_DonKH.DAL.ThaoThuTraLoi;

namespace KTKS_DonKH.GUI.ThaoThuTraLoi
{
    public partial class frmDSTTTL : Form
    {
        CChuyenDi _cChuyenDi = new CChuyenDi();
        CTTTL _cTTTL = new CTTTL();
        DataTable DSTTTL_Edited = new DataTable();

        public frmDSTTTL()
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

        private void frmDSTTTL_Load(object sender, EventArgs e)
        {
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
            myLookUpEdit.DataSource = _cChuyenDi.LoadDSChuyenDi("DCBD");
            myLookUpEdit.DisplayMember = "NoiChuyenDi";
            myLookUpEdit.ValueMember = "MaChuyen";
            ///Add LookUpEdit vào GridControl
            ((GridView)gridControl.MainView).Columns["MaChuyen"].ColumnEdit = myLookUpEdit;

            radChuaDuyet.Checked = true;

            gridControl.LevelTree.Nodes.Add("Chi Tiết Thảo Thư Trả Lời", gridViewCTTTTL);

            dgvDSThu.AutoGenerateColumns = false;
            dgvDSThu.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSThu.Font, FontStyle.Bold);
            dgvDSThu.Location = gridControl.Location;
        }

        private void radDaDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radDaDuyet.Checked)
            {
                gridControl.Visible = true;
                gridControl.DataSource = _cTTTL.LoadDSTTTLDaDuyet().Tables["TTTL"];
                dgvDSThu.Visible = false;
            }
        }

        private void radChuaDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radChuaDuyet.Checked)
            {
                gridControl.Visible = true;
                gridControl.DataSource = _cTTTL.LoadDSTTTLChuaDuyet();
                dgvDSThu.Visible = false;
            }
        }

        private void radDSThu_CheckedChanged(object sender, EventArgs e)
        {
            if (radDSThu.Checked)
            {
                dgvDSThu.Visible = true;
                dgvDSThu.DataSource = _cTTTL.LoadDSCTTTTL();
                gridControl.Visible = false;
            }
        }

        public void thảoThưTrảLờitoolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Dictionary<string, string> source = new Dictionary<string, string>();
            ///Lấy dữ liệu tại selected row
            DataRowView selRow = (DataRowView)gridViewTTTL.GetRow(gridViewTTTL.GetSelectedRows()[0]);
            source.Add("MaDon", selRow["MaDon"].ToString());
            source.Add("DanhBo", selRow["DanhBo"].ToString());
            ///Nơi Chuyển Đến, dùng để xét Đơn Khách Hàng nhận từ bản nào, Vì lúc ta load danh sách đơn chưa duyệt ở nhiều bảng
            source.Add("MaNoiChuyenDen", selRow["MaNoiChuyenDen"].ToString());
            source.Add("NoiChuyenDen", selRow["NoiChuyenDen"].ToString());
            source.Add("LyDoChuyenDen", selRow["LyDoChuyenDen"].ToString());

            frmTTTL frm = new frmTTTL(source);
            if (frm.ShowDialog() == DialogResult.OK)
                gridControl.DataSource = _cTTTL.LoadDSTTTLChuaDuyet();
        }

        private void gridViewTTTL_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gridViewTTTL_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaDon" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(4, "-");
            }
        }

        private void gridViewTTTL_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (radChuaDuyet.Checked && gridControl.MainView.RowCount > 0 && e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(gridControl, new Point(e.X, e.Y));
            }
        }

        private void gridViewTTTL_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            btnLuu.Enabled = false;
        }

        private void gridViewTTTL_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            ///Khai báo các cột tương ứng trong Datagridview
            if (DSTTTL_Edited.Columns.Count == 0)
                foreach (DataColumn itemCol in ((DataView)gridViewTTTL.DataSource).Table.Columns)
                {
                    DSTTTL_Edited.Columns.Add(itemCol.ColumnName, itemCol.DataType);
                }

            ///Gọi hàm EndEdit để kết thúc Edit nếu không sẽ bị lỗi Value chưa cập nhật trong trường hợp chuyển Cell trong cùng 1 Row. Nếu chuyển Row thì không bị lỗi
            ((DataRowView)gridViewTTTL.GetRow(gridViewTTTL.GetSelectedRows()[0])).Row.EndEdit();

            ///DataRow != DataGridViewRow nên phải qua 1 loạt gán biến
            ///Tránh tình trạng trùng Danh Bộ nên xóa đi rồi add lại
            if (DSTTTL_Edited.Select("MaDon = " + ((DataRowView)gridViewTTTL.GetRow(gridViewTTTL.GetSelectedRows()[0])).Row["MaDon"]).Count() > 0)
                DSTTTL_Edited.Rows.Remove(DSTTTL_Edited.Select("MaDon = " + ((DataRowView)gridViewTTTL.GetRow(gridViewTTTL.GetSelectedRows()[0])).Row["MaDon"])[0]);

            DSTTTL_Edited.ImportRow(((DataRowView)gridViewTTTL.GetRow(gridViewTTTL.GetSelectedRows()[0])).Row);
            btnLuu.Enabled = true;
        }

        private void gridViewCTTTTL_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaCTTTTL" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(4, "-");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }
    }
}
