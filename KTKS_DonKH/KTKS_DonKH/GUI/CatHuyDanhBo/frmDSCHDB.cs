using System;
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
using KTKS_DonKH.DAL.CatHuyDanhBo;
using KTKS_DonKH.GUI.KhachHang;

namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    public partial class frmDSCHDB : Form
    {
        CChuyenDi _cChuyenDi = new CChuyenDi();
        CCHDB _cCHDB = new CCHDB();
        CDonKH _cDonKH = new CDonKH();
        DataTable DSCHDB_Edited = new DataTable();
        DataRowView CTRow;

        public frmDSCHDB()
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

        private void frmDSCHDB_Load(object sender, EventArgs e)
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

            gridControl.LevelTree.Nodes.Add("Chi Tiết Cắt Tạm Danh Bộ", gridViewCTCTDB);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Cắt Hủy Danh Bộ", gridViewCTCHDB);

            dgvDSCTCHDB.AutoGenerateColumns = false;
            dgvDSCTCHDB.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSCTCHDB.Font, FontStyle.Bold);
            dgvDSCTCHDB.Location = gridControl.Location;
        }

        private void radDaDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radDaDuyet.Checked)
            {
                gridControl.Visible = true;
                gridControl.DataSource = _cCHDB.LoadDSCHDBDaDuyet().Tables["CHDB"];
                dgvDSCTCHDB.Visible = false;
            }
        }

        private void radChuaDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radChuaDuyet.Checked)
            {
                gridControl.Visible = true;
                gridControl.DataSource = _cCHDB.LoadDSCHDBChuaDuyet();
                dgvDSCTCHDB.Visible = false;
            }
        }

        private void radDSCatTamDanhBo_CheckedChanged(object sender, EventArgs e)
        {
            if (radDSCatTamDanhBo.Checked)
            {
                dgvDSCTCHDB.Visible = true;
                dgvDSCTCHDB.DataSource = _cCHDB.LoadDSCTCTDB();
                gridControl.Visible = false;
            }
        }

        private void radDSCatHuyDanhBo_CheckedChanged(object sender, EventArgs e)
        {
            if (radDSCatHuyDanhBo.Checked)
            {
                dgvDSCTCHDB.Visible = true;
                dgvDSCTCHDB.DataSource = _cCHDB.LoadDSCTCHDB();
                gridControl.Visible = false;
            }
        }

        private void gridViewCHDB_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridViewCHDB.RowCount > 0 && e.Control && e.KeyCode == Keys.F)
            {
                frmShowDonKH frm = new frmShowDonKH(_cDonKH.getDonKHbyID(decimal.Parse(((DataRowView)gridViewCHDB.GetRow(gridViewCHDB.GetSelectedRows()[0])).Row["MaDon"].ToString())));
                frm.ShowDialog();
            }
        }

        private void cắtTạmDanhBộtoolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Dictionary<string, string> source = new Dictionary<string, string>();
            ///Lấy dữ liệu tại selected row
            //int selRows = ((GridView)gridControl.MainView).GetSelectedRows()[0];
            //DataRowView selRow = (DataRowView)(((GridView)gridControl.MainView).GetRow(selRows));
            DataRowView selRow = (DataRowView)gridViewCHDB.GetRow(gridViewCHDB.GetSelectedRows()[0]);
            //decimal _MaDon = decimal.Parse(selRow["MaDon"].ToString());
            //string _DanhBo = selRow["DanhBo"].ToString();       
            source.Add("MaDon", selRow["MaDon"].ToString());
            source.Add("DanhBo", selRow["DanhBo"].ToString());
            source.Add("Action", "Thêm");
            ///Nơi Chuyển Đến, dùng để xét Đơn Khách Hàng nhận từ bản nào, Vì lúc ta load danh sách đơn chưa duyệt ở nhiều bảng
            source.Add("MaNoiChuyenDen", selRow["MaNoiChuyenDen"].ToString());
            source.Add("NoiChuyenDen", selRow["NoiChuyenDen"].ToString());
            source.Add("LyDoChuyenDen", selRow["LyDoChuyenDen"].ToString());

            frmCTDB frm = new frmCTDB(source);
            if (frm.ShowDialog() == DialogResult.OK)
                gridControl.DataSource = _cCHDB.LoadDSCHDBChuaDuyet();
        }

        private void cậpNhậtCắtTạmDanhBộtoolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Dictionary<string, string> source = new Dictionary<string, string>();
            source.Add("Action", "Sửa");
            if (radDaDuyet.Checked)
                source.Add("MaCTCTDB", CTRow["MaCTCTDB"].ToString());
            if (radDSCatTamDanhBo.Checked)
                source.Add("MaCTCTDB", dgvDSCTCHDB.CurrentRow.Cells["MaTB"].Value.ToString());
            frmCTDB frm = new frmCTDB(source);
            if (frm.ShowDialog() == DialogResult.OK)
                gridControl.DataSource = _cCHDB.LoadDSCHDBDaDuyet();
        }

        private void cắtHủyDanhBộtoolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Dictionary<string, string> source = new Dictionary<string, string>();
            ///Lấy dữ liệu tại selected row
            //int selRows = ((GridView)gridControl.MainView).GetSelectedRows()[0];
            //DataRowView selRow = (DataRowView)(((GridView)gridControl.MainView).GetRow(selRows));
            DataRowView selRow = (DataRowView)gridViewCHDB.GetRow(gridViewCHDB.GetSelectedRows()[0]);
            //decimal _MaDon = decimal.Parse(selRow["MaDon"].ToString());
            //string _DanhBo = selRow["DanhBo"].ToString();       
            source.Add("MaDon", selRow["MaDon"].ToString());
            source.Add("DanhBo", selRow["DanhBo"].ToString());
            source.Add("Action", "Thêm");
            ///Nơi Chuyển Đến, dùng để xét Đơn Khách Hàng nhận từ bản nào, Vì lúc ta load danh sách đơn chưa duyệt ở nhiều bảng
            source.Add("MaNoiChuyenDen", selRow["MaNoiChuyenDen"].ToString());
            source.Add("NoiChuyenDen", selRow["NoiChuyenDen"].ToString());
            source.Add("LyDoChuyenDen", selRow["LyDoChuyenDen"].ToString());

            frmCHDB frm = new frmCHDB(source);
            if (frm.ShowDialog() == DialogResult.OK)
                gridControl.DataSource = _cCHDB.LoadDSCHDBChuaDuyet();
        }

        private void cậpNhậtCắtHủyDanhBộtoolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Dictionary<string, string> source = new Dictionary<string, string>();
            DataRowView selRow = (DataRowView)gridViewCTCHDB.GetRow(gridViewCTCHDB.GetSelectedRows()[0]);
            source.Add("Action", "Sửa");
            source.Add("MaCTCHDB", CTRow["MaCTCHDB"].ToString());
            frmCHDB frm = new frmCHDB(source);
            if (frm.ShowDialog() == DialogResult.OK)
                gridControl.DataSource = _cCHDB.LoadDSCHDBDaDuyet();
        } 

        private void gridViewCHDB_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gridViewCHDB_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (radChuaDuyet.Checked && gridControl.MainView.RowCount > 0 && e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(gridControl, new Point(e.X, e.Y));
                cắtTạmDanhBộtoolStripMenuItem.Visible = true;
                cắtHủyDanhBộtoolStripMenuItem.Visible = true;
            }
        }

        private void gridViewCTCTDB_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (radDaDuyet.Checked && e.Button == MouseButtons.Right)
            {
                ///Mỗi 1 record là 1 gridcontrol và 1 gridview khác nhau nên để lấy
                ///được dữ liệu phải làm cách sau
                GridView gridview = (GridView)gridControl.GetViewAt(new Point(e.X, e.Y));
                CTRow = (DataRowView)gridview.GetRow(gridview.GetSelectedRows()[0]);
                contextMenuStrip1.Show(gridControl, new Point(e.X, e.Y));
                cậpNhậtCắtTạmDanhBộtoolStripMenuItem.Visible = true;
            } 
        }

        private void gridViewCTCHDB_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (radDaDuyet.Checked && e.Button == MouseButtons.Right)
            {
                ///Mỗi 1 record là 1 gridcontrol và 1 gridview khác nhau nên để lấy
                ///được dữ liệu phải làm cách sau
                GridView gridview = (GridView)gridControl.GetViewAt(new Point(e.X, e.Y));
                CTRow = (DataRowView)gridview.GetRow(gridview.GetSelectedRows()[0]);
                contextMenuStrip1.Show(gridControl, new Point(e.X, e.Y));
                cậpNhậtCắtHủyDanhBộtoolStripMenuItem.Visible = true;
            }
        }

        private void gridViewCHDB_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaDon" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(4, "-");
            }
        }

        private void gridViewCHDB_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            btnLuu.Enabled = false;
        }

        private void gridViewCHDB_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            ///Khai báo các cột tương ứng trong Datagridview
            if (DSCHDB_Edited.Columns.Count == 0)
                foreach (DataColumn itemCol in ((DataView)gridViewCHDB.DataSource).Table.Columns)
                {
                    DSCHDB_Edited.Columns.Add(itemCol.ColumnName, itemCol.DataType);
                }

            ///Gọi hàm EndEdit để kết thúc Edit nếu không sẽ bị lỗi Value chưa cập nhật trong trường hợp chuyển Cell trong cùng 1 Row. Nếu chuyển Row thì không bị lỗi
            ((DataRowView)gridViewCHDB.GetRow(gridViewCHDB.GetSelectedRows()[0])).Row.EndEdit();

            ///DataRow != DataGridViewRow nên phải qua 1 loạt gán biến
            ///Tránh tình trạng trùng Danh Bộ nên xóa đi rồi add lại
            if (DSCHDB_Edited.Select("MaDon = " + ((DataRowView)gridViewCHDB.GetRow(gridViewCHDB.GetSelectedRows()[0])).Row["MaDon"]).Count() > 0)
                DSCHDB_Edited.Rows.Remove(DSCHDB_Edited.Select("MaDon = " + ((DataRowView)gridViewCHDB.GetRow(gridViewCHDB.GetSelectedRows()[0])).Row["MaDon"])[0]);

            DSCHDB_Edited.ImportRow(((DataRowView)gridViewCHDB.GetRow(gridViewCHDB.GetSelectedRows()[0])).Row);
            btnLuu.Enabled = true;
        }

        private void gridViewCTCTDB_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaCTCTDB" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(4, "-");
            }
            if (e.Column.FieldName == "SoTien" && e.Value != null)
            {
                e.DisplayText = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }   
        }

        private void gridViewCTCHDB_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaCTCHDB" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(4, "-");
            }
            if (e.Column.FieldName == "SoTien" && e.Value != null)
            {
                e.DisplayText = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvDSCTCHDB_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSCTCHDB.Columns[e.ColumnIndex].Name == "MaTB" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, "-");
            }

            if (dgvDSCTCHDB.Columns[e.ColumnIndex].Name == "SoTien" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvDSCTCHDB_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSCTCHDB.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSCTCHDB_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                cậpNhậtCắtTạmDanhBộtoolStripMenuItem.Visible = true;
                ///Khi chuột phải Selected-Row sẽ được chuyển đến nơi click chuột
                dgvDSCTCHDB.CurrentCell = dgvDSCTCHDB.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dgvDSCTCHDB_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(dgvDSCTCHDB, new Point(e.X, e.Y));
            }
        }
  

    }
}
