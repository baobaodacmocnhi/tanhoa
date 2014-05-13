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
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using System.Globalization;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.CatHuyDanhBo;
using KTKS_DonKH.GUI.ToXuLy;

namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    public partial class frmDSCHDB : Form
    {
        CChuyenDi _cChuyenDi = new CChuyenDi();
        CCHDB _cCHDB = new CCHDB();
        CDonKH _cDonKH = new CDonKH();
        CKTXM _cKTXM = new CKTXM();
        DataTable DSCHDB_Edited = new DataTable();
        DataRowView _CTRow = null;
        BindingSource DSCHDB_BS;
        string _tuNgay = "", _denNgay = "";

        public frmDSCHDB()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //this.ControlBox = false;
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
            myLookUpEdit.DataSource = _cChuyenDi.LoadDSChuyenDi("CTCHDB");
            myLookUpEdit.DisplayMember = "NoiChuyenDi";
            myLookUpEdit.ValueMember = "MaChuyen";
            ///Add LookUpEdit vào GridControl
            ((GridView)gridControl.MainView).Columns["MaChuyen"].ColumnEdit = myLookUpEdit;

            radDSCatTamDanhBo.Checked = true;

            gridControl.LevelTree.Nodes.Add("Chi Tiết Cắt Tạm Danh Bộ", gridViewCTCTDB);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Cắt Hủy Danh Bộ", gridViewCTCHDB);

            dgvDSCTCHDB.AutoGenerateColumns = false;
            dgvDSCTCHDB.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSCTCHDB.Font, FontStyle.Bold);
            dgvDSCTCHDB.Location = gridControl.Location;

            dgvDSYCCHDB.AutoGenerateColumns = false;
            dgvDSYCCHDB.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSYCCHDB.Font, FontStyle.Bold);
            dgvDSYCCHDB.Location = gridControl.Location;

            dateTimKiem.Location = txtNoiDungTimKiem.Location;
        }

        private void radDaDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radDaDuyet.Checked)
            {
                DSCHDB_BS = new BindingSource();
                DSCHDB_BS.DataSource = _cCHDB.LoadDSCHDBDaDuyet().Tables["CHDB"];
                gridControl.DataSource = DSCHDB_BS;

                radDaDuyet_TXL.Checked = false;
                radDSCatHuyDanhBo_TXL.Checked = false;
                radDSCatTamDanhBo_TXL.Checked = false;
                gridControl.Visible = true;
                dgvDSCTCHDB.Visible = false;
                dgvDSYCCHDB.Visible = false;
                //btnLuu.Enabled = true;
                chkSelectAll.Visible = false;
            }
        }

        private void radChuaDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radChuaDuyet.Checked)
            {
                DSCHDB_BS = new BindingSource();
                DSCHDB_BS.DataSource = _cCHDB.LoadDSCHDBChuaDuyet();
                gridControl.DataSource = DSCHDB_BS;

                gridControl.Visible = true;
                dgvDSCTCHDB.Visible = false;
                //btnLuu.Enabled = false;
                chkSelectAll.Visible = false;
            }
        }

        private void radDSCatTamDanhBo_CheckedChanged(object sender, EventArgs e)
        {
            if (radDSCatTamDanhBo.Checked)
            {
                DSCHDB_BS = new BindingSource();
                DSCHDB_BS.DataSource = _cCHDB.LoadDSCTCTDB();
                dgvDSCTCHDB.DataSource = DSCHDB_BS;

                radDaDuyet_TXL.Checked = false;
                radDSCatHuyDanhBo_TXL.Checked = false;
                radDSCatTamDanhBo_TXL.Checked = false;
                dgvDSCTCHDB.Visible = true;
                //dgvDSCTCHDB.Columns["DaLapPhieu"].Visible = false;
                //dgvDSCTCHDB.Columns["PhieuDuocKy"].Visible = false;
                gridControl.Visible = false;
                dgvDSYCCHDB.Visible = false;
                //btnLuu.Enabled = false;
                chkSelectAll.Visible = true;
            }
        }

        private void radDSCatHuyDanhBo_CheckedChanged(object sender, EventArgs e)
        {
            if (radDSCatHuyDanhBo.Checked)
            {
                DSCHDB_BS = new BindingSource();
                DSCHDB_BS.DataSource = _cCHDB.LoadDSCTCHDB();
                dgvDSCTCHDB.DataSource = DSCHDB_BS;

                radDaDuyet_TXL.Checked = false;
                radDSCatHuyDanhBo_TXL.Checked = false;
                radDSCatTamDanhBo_TXL.Checked = false;
                dgvDSCTCHDB.Visible = true;
                //dgvDSCTCHDB.Columns["DaLapPhieu"].Visible = true;
                //dgvDSCTCHDB.Columns["PhieuDuocKy"].Visible = true;
                gridControl.Visible = false;
                dgvDSYCCHDB.Visible = false;
                //btnLuu.Enabled = false;
                chkSelectAll.Visible = true;
            }
        }

        private void radDSYCCHDB_CheckedChanged(object sender, EventArgs e)
        {
            if (radDSYCCHDB.Checked)
            {
                DSCHDB_BS = new BindingSource();
                DSCHDB_BS.DataSource = _cCHDB.LoadDSYCCHDB();
                dgvDSYCCHDB.DataSource = DSCHDB_BS;

                radDaDuyet_TXL.Checked = false;
                radDSCatHuyDanhBo_TXL.Checked = false;
                radDSCatTamDanhBo_TXL.Checked = false;
                dgvDSYCCHDB.Visible = true;
                dgvDSCTCHDB.Visible = false;
                //dgvDSCTCHDB.Columns["DaLapPhieu"].Visible = true;
                //dgvDSCTCHDB.Columns["PhieuDuocKy"].Visible = true;
                gridControl.Visible = false;
                //btnLuu.Enabled = false;
                chkSelectAll.Visible = false;
            }
        }

        private void cắtTạmDanhBộtoolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Dictionary<string, string> source = new Dictionary<string, string>();
            ///Lấy dữ liệu tại selected row
            DataRowView selRow = (DataRowView)gridViewCHDB.GetRow(gridViewCHDB.GetSelectedRows()[0]);     
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
            ///gridcontrol
            if (radDaDuyet.Checked)
                source.Add("MaCTCTDB", _CTRow["MaCTCTDB"].ToString());
            ///datagridview
            if (radDSCatTamDanhBo.Checked)
                source.Add("MaCTCTDB", dgvDSCTCHDB.CurrentRow.Cells["MaTB"].Value.ToString());

            frmCTDB frm = new frmCTDB(source);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _CTRow = null;
                if (radDaDuyet.Checked)
                    gridControl.DataSource = _cCHDB.LoadDSCHDBDaDuyet().Tables["CHDB"];
                if (radDSCatTamDanhBo.Checked)
                    dgvDSCTCHDB.DataSource = _cCHDB.LoadDSCTCTDB();
            }
        }

        private void cắtHủyDanhBộtoolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Dictionary<string, string> source = new Dictionary<string, string>();
            if (radChuaDuyet.Checked)
            {
                ///Lấy dữ liệu tại selected row
                DataRowView selRow = (DataRowView)gridViewCHDB.GetRow(gridViewCHDB.GetSelectedRows()[0]);    
                source.Add("MaDon", selRow["MaDon"].ToString());
                source.Add("DanhBo", selRow["DanhBo"].ToString());
                source.Add("Action", "Thêm");
                ///Nơi Chuyển Đến, dùng để xét Đơn Khách Hàng nhận từ bản nào, Vì lúc ta load danh sách đơn chưa duyệt ở nhiều bảng
                source.Add("MaNoiChuyenDen", selRow["MaNoiChuyenDen"].ToString());
                source.Add("NoiChuyenDen", selRow["NoiChuyenDen"].ToString());
                source.Add("LyDoChuyenDen", selRow["LyDoChuyenDen"].ToString());
            }
            if (radDaDuyet.Checked || radDSCatTamDanhBo.Checked)
            {
                source.Add("Action", "CTDBThêm");
                ///gridcontrol
                if (radDaDuyet.Checked)
                    source.Add("MaCTCTDB", _CTRow["MaCTCTDB"].ToString());
                ///datagridview
                if (radDSCatTamDanhBo.Checked)
                    source.Add("MaCTCTDB", dgvDSCTCHDB.CurrentRow.Cells["MaTB"].Value.ToString());
            }

            frmCHDB frm = new frmCHDB(source);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _CTRow = null;
                if (radChuaDuyet.Checked)
                    gridControl.DataSource = _cCHDB.LoadDSCHDBChuaDuyet();
                if(radDaDuyet.Checked)
                    gridControl.DataSource = _cCHDB.LoadDSCHDBDaDuyet().Tables["CHDB"];
                if(radDSCatTamDanhBo.Checked)
                    dgvDSCTCHDB.DataSource = _cCHDB.LoadDSCTCTDB();
            }
        }

        private void cậpNhậtCắtHủyDanhBộtoolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Dictionary<string, string> source = new Dictionary<string, string>();
            //DataRowView selRow = (DataRowView)gridViewCTCHDB.GetRow(gridViewCTCHDB.GetSelectedRows()[0]);
            source.Add("Action", "Sửa");
            ///gridcontrol
            if (radDaDuyet.Checked)
                source.Add("MaCTCHDB", _CTRow["MaCTCHDB"].ToString());
            ///datagridview
            if (radDSCatHuyDanhBo.Checked)
                source.Add("MaCTCHDB", dgvDSCTCHDB.CurrentRow.Cells["MaTB"].Value.ToString());

            frmCHDB frm = new frmCHDB(source);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _CTRow = null;
                if(radDaDuyet.Checked)
                    gridControl.DataSource = _cCHDB.LoadDSCHDBDaDuyet().Tables["CHDB"];
                if(radDSCatHuyDanhBo.Checked)
                    dgvDSCTCHDB.DataSource = _cCHDB.LoadDSCTCHDB();
            }
        } 

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (DSCHDB_Edited != null && DSCHDB_Edited.Rows.Count > 0)
                {
                    foreach (DataRow itemRow in DSCHDB_Edited.Rows)
                    {
                        //if (itemRow["MaCHDB"].ToString() == "")
                        //{
                        //    CHDB chdb = new CHDB();
                        //    chdb.MaDon = decimal.Parse(itemRow["MaDon"].ToString());
                        //    chdb.MaNoiChuyenDen = decimal.Parse(itemRow["MaNoiChuyenDen"].ToString());
                        //    chdb.NoiChuyenDen = itemRow["NoiChuyenDen"].ToString();
                        //    chdb.LyDoChuyenDen = itemRow["LyDoChuyenDen"].ToString();
                        //    chdb.KetQua = itemRow["KetQua"].ToString();
                        //    if (itemRow["MaChuyen"].ToString() != "" && itemRow["MaChuyen"].ToString() != "NONE")
                        //    {
                        //        chdb.Chuyen = true;
                        //        chdb.MaChuyen = itemRow["MaChuyen"].ToString();
                        //        chdb.LyDoChuyen = itemRow["LyDoChuyenDi"].ToString();
                        //    }
                        //    if (_cCHDB.ThemCHDB(chdb))
                        //    {
                        //        switch (itemRow["NoiChuyenDen"].ToString())
                        //        {
                        //            case "Khách Hàng":
                        //                ///Báo cho bảng DonKH là đơn này đã được nơi nhận xử lý
                        //                DonKH donkh = _cDonKH.getDonKHbyID(decimal.Parse(itemRow["MaDon"].ToString()));
                        //                donkh.Nhan = true;
                        //                _cDonKH.SuaDonKH(donkh);
                        //                break;
                        //            case "Điều Chỉnh Biến Động":
                        //                ///Báo cho bảng KTXM là đơn này đã được nơi nhận xử lý
                        //                KTXM ktxm = _cKTXM.getKTXMbyID(decimal.Parse(itemRow["MaNoiChuyenDen"].ToString()));
                        //                ktxm.Nhan = true;
                        //                _cKTXM.SuaKTXM(ktxm);
                        //                break;
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    CHDB chdb = _cCHDB.getCHDBbyID(decimal.Parse(itemRow["MaCHDB"].ToString()));
                        //    ///Đơn đã được nơi nhận xử lý thì không được sửa
                        //    if (!chdb.Nhan)
                        //    {
                        //        chdb.KetQua = itemRow["KetQua"].ToString();
                        //        if (itemRow["MaChuyen"].ToString() != "" && itemRow["MaChuyen"].ToString() != "NONE")
                        //        {
                        //            chdb.Chuyen = true;
                        //            chdb.MaChuyen = itemRow["MaChuyen"].ToString();
                        //            chdb.LyDoChuyen = itemRow["LyDoChuyenDi"].ToString();
                        //        }
                        //        else
                        //            if (itemRow["MaChuyen"].ToString() == "NONE")
                        //            {
                        //                chdb.Chuyen = false;
                        //                chdb.MaChuyen = null;
                        //                chdb.LyDoChuyen = null;
                        //            }
                        //        _cCHDB.SuaCHDB(chdb);
                        //    }
                        //    else
                        //    {
                        //        MessageBox.Show("Đơn " + chdb.MaCHDB + " đã được xử lý nên không sửa đổi được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    }
                        //}
                        CHDB chdb = _cCHDB.getCHDBbyID(decimal.Parse(itemRow["MaCHDB"].ToString()));
                        chdb.KetQua = itemRow["KetQua"].ToString();
                        chdb.Chuyen = true;
                        chdb.MaChuyen = itemRow["MaChuyen"].ToString();
                        chdb.LyDoChuyen = itemRow["LyDoChuyenDi"].ToString();
                        _cCHDB.SuaCHDB(chdb);
                    }
                    MessageBox.Show("Lưu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DSCHDB_Edited.Clear();

                    if (radDaDuyet.Checked)
                        gridControl.DataSource = _cCHDB.LoadDSCHDBDaDuyet().Tables["CHDB"];
                    if (radChuaDuyet.Checked)
                        gridControl.DataSource = _cCHDB.LoadDSCHDBChuaDuyet();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        #region gridViewCHDB (Danh Sách Cắt Hủy Danh Bộ)

        /// <summary>
        /// Ctrl+F Tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewCHDB_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridViewCHDB.RowCount > 0 && e.Control && e.KeyCode == Keys.F)
            {
                if (((DataRowView)gridViewCHDB.GetRow(gridViewCHDB.GetSelectedRows()[0])).Row["ToXuLy"].ToString() == "True")
                {
                    Dictionary<string, string> source = new Dictionary<string, string>();
                    source.Add("Action", "View");
                    source.Add("MaDon", ((DataRowView)gridViewCHDB.GetRow(gridViewCHDB.GetSelectedRows()[0])).Row["MaDon"].ToString());
                    frmShowDonTXL frm = new frmShowDonTXL(source);
                    //frmShowDonKH frm = new frmShowDonKH(_cDonKH.getDonKHbyID(decimal.Parse(((DataRowView)gridViewCHDB.GetRow(gridViewCHDB.GetSelectedRows()[0])).Row["MaDon"].ToString())));
                    frm.ShowDialog();
                }
                else
                {
                    Dictionary<string, string> source = new Dictionary<string, string>();
                    source.Add("Action", "View");
                    source.Add("MaDon", ((DataRowView)gridViewCHDB.GetRow(gridViewCHDB.GetSelectedRows()[0])).Row["MaDon"].ToString());
                    frmShowDonKH frm = new frmShowDonKH(source);
                    frm.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Hiện thị số thứ tự dòng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewCHDB_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        /// <summary>
        /// Hiện thị menuStrip tại chỗ click chuột
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewCHDB_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (radChuaDuyet.Checked && gridControl.MainView.RowCount > 0 && e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(gridControl, new Point(e.X, e.Y));

                cắtTạmDanhBộtoolStripMenuItem.Visible = true;
                cắtHủyDanhBộtoolStripMenuItem.Visible = true;
                cậpNhậtCắtTạmDanhBộtoolStripMenuItem.Visible = false;
                cậpNhậtCắtHủyDanhBộtoolStripMenuItem.Visible = false;
            }
        }

        /// <summary>
        /// Format dữ liệu trong column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewCHDB_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaDon" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        /// <summary>
        /// Bắt đầu Edit Column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewCHDB_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            btnLuu.Enabled = false;
        }

        /// <summary>
        /// Kết thúc Edit Column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewCHDB_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            /////Khai báo các cột tương ứng trong Datagridview
            //if (DSCHDB_Edited.Columns.Count == 0)
            //    foreach (DataColumn itemCol in ((DataView)gridViewCHDB.DataSource).Table.Columns)
            //    {
            //        DSCHDB_Edited.Columns.Add(itemCol.ColumnName, itemCol.DataType);
            //    }

            /////Gọi hàm EndEdit để kết thúc Edit nếu không sẽ bị lỗi Value chưa cập nhật trong trường hợp chuyển Cell trong cùng 1 Row. Nếu chuyển Row thì không bị lỗi
            //((DataRowView)gridViewCHDB.GetRow(gridViewCHDB.GetSelectedRows()[0])).Row.EndEdit();

            /////DataRow != DataGridViewRow nên phải qua 1 loạt gán biến
            /////Tránh tình trạng trùng Danh Bộ nên xóa đi rồi add lại
            //if (DSCHDB_Edited.Select("MaDon = " + ((DataRowView)gridViewCHDB.GetRow(gridViewCHDB.GetSelectedRows()[0])).Row["MaDon"]).Count() > 0)
            //    DSCHDB_Edited.Rows.Remove(DSCHDB_Edited.Select("MaDon = " + ((DataRowView)gridViewCHDB.GetRow(gridViewCHDB.GetSelectedRows()[0])).Row["MaDon"])[0]);

            //DSCHDB_Edited.ImportRow(((DataRowView)gridViewCHDB.GetRow(gridViewCHDB.GetSelectedRows()[0])).Row);
            //btnLuu.Enabled = true;

            DataRowView itemRow = (DataRowView)gridViewCHDB.GetRow(gridViewCHDB.GetSelectedRows()[0]);

            CHDB chdb = _cCHDB.getCHDBbyID(decimal.Parse(itemRow["MaCHDB"].ToString()));
            chdb.KetQua = itemRow["KetQua"].ToString();
            chdb.Chuyen = true;
            chdb.MaChuyen = itemRow["MaChuyen"].ToString();
            chdb.LyDoChuyen = itemRow["LyDoChuyenDi"].ToString();
            _cCHDB.SuaCHDB(chdb);
        }

        #endregion

        #region gridViewCTCTDB (Chi Tiết Cắt Tạm Danh Bộ)

        /// <summary>
        /// Lấy DataRow & Hiện thị menuStrip tại chỗ click chuột
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewCTCTDB_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            GridView gridview = (GridView)gridControl.GetViewAt(new Point(e.X, e.Y));
            _CTRow = (DataRowView)gridview.GetRow(gridview.GetSelectedRows()[0]);
            if (radDaDuyet.Checked && e.Button == MouseButtons.Right)
            {
                ///Mỗi 1 record là 1 gridcontrol và 1 gridview khác nhau nên để lấy
                ///được dữ liệu phải làm cách sau
                //GridView gridview = (GridView)gridControl.GetViewAt(new Point(e.X, e.Y));
                //_CTRow = (DataRowView)gridview.GetRow(gridview.GetSelectedRows()[0]);

                contextMenuStrip1.Show(gridControl, new Point(e.X, e.Y));

                cậpNhậtCắtTạmDanhBộtoolStripMenuItem.Visible = true;
                cắtHủyDanhBộtoolStripMenuItem.Visible = true;
                cắtTạmDanhBộtoolStripMenuItem.Visible = false;
                cậpNhậtCắtHủyDanhBộtoolStripMenuItem.Visible = false;
            }
        }

        /// <summary>
        /// Format dữ liệu trong column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewCTCTDB_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaCTCTDB" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length-2, "-");
            }
            if (e.Column.FieldName == "SoTien" && e.Value != null)
            {
                e.DisplayText = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        /// <summary>
        /// Ctrl+F Tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewCTCTDB_KeyDown(object sender, KeyEventArgs e)
        {
            if (_CTRow != null && e.Control && e.KeyCode == Keys.F)
            {
                frmShowCTDB frm = new frmShowCTDB(decimal.Parse(_CTRow.Row["MaCTCTDB"].ToString()));
                if (frm.ShowDialog() == DialogResult.Cancel)
                    _CTRow = null;
            }
        }

        #endregion

        #region gridViewCTCHDB (Chi Tiết Cắt Hủy Danh Bộ)

        /// <summary>
        /// Lấy DataRow & Hiện thị menuStrip tại chỗ click chuột
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewCTCHDB_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            GridView gridview = (GridView)gridControl.GetViewAt(new Point(e.X, e.Y));
            _CTRow = (DataRowView)gridview.GetRow(gridview.GetSelectedRows()[0]);
            if (radDaDuyet.Checked && e.Button == MouseButtons.Right)
            {
                ///Mỗi 1 record là 1 gridcontrol và 1 gridview khác nhau nên để lấy
                ///được dữ liệu phải làm cách sau
                //GridView gridview = (GridView)gridControl.GetViewAt(new Point(e.X, e.Y));
                //_CTRow = (DataRowView)gridview.GetRow(gridview.GetSelectedRows()[0]);

                contextMenuStrip1.Show(gridControl, new Point(e.X, e.Y));

                cậpNhậtCắtHủyDanhBộtoolStripMenuItem.Visible = true;
                cậpNhậtCắtTạmDanhBộtoolStripMenuItem.Visible = false;
                cắtTạmDanhBộtoolStripMenuItem.Visible = false;
                cắtHủyDanhBộtoolStripMenuItem.Visible = false;
            }
        }

        /// <summary>
        /// Format dữ liệu trong column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewCTCHDB_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaCTCHDB" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length-2, "-");
            }
            if (e.Column.FieldName == "SoTien" && e.Value != null)
            {
                e.DisplayText = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        /// <summary>
        /// Ctrl+F Tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewCTCHDB_KeyDown(object sender, KeyEventArgs e)
        {
            if (_CTRow != null && e.Control && e.KeyCode == Keys.F)
            {
                frmShowCHDB frm = new frmShowCHDB(decimal.Parse(_CTRow.Row["MaCTCHDB"].ToString()));
                if (frm.ShowDialog() == DialogResult.Cancel)
                    _CTRow = null;
            }
        }

        #endregion

        #region dgvDSCTCHDB (Danh Sách Cắt Tạm Cắt Hủy Danh Bộ)

        /// <summary>
        /// Format dữ liệu trong column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSCTCHDB_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSCTCHDB.Columns[e.ColumnIndex].Name == "MaTB" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length-2, "-");
            }
            if (dgvDSCTCHDB.Columns[e.ColumnIndex].Name == "SoTien" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        /// <summary>
        /// Hiện thị số thứ tự dòng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSCTCHDB_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSCTCHDB.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        /// <summary>
        /// Ẩn/Hiện Items trong menuStrip tại chỗ click chuột
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSCTCHDB_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    if (radDSCatTamDanhBo.Checked)
                    {
                        cậpNhậtCắtTạmDanhBộtoolStripMenuItem.Visible = true;
                        cắtHủyDanhBộtoolStripMenuItem.Visible = true;
                        cắtTạmDanhBộtoolStripMenuItem.Visible = false;
                        cậpNhậtCắtHủyDanhBộtoolStripMenuItem.Visible = false;
                    }
                    if (radDSCatHuyDanhBo.Checked)
                    {
                        cậpNhậtCắtHủyDanhBộtoolStripMenuItem.Visible = true;
                        cậpNhậtCắtTạmDanhBộtoolStripMenuItem.Visible = false;
                        cắtTạmDanhBộtoolStripMenuItem.Visible = false;
                        cắtHủyDanhBộtoolStripMenuItem.Visible = false;
                    }
                }
                else
                {
                    cậpNhậtCắtHủyDanhBộtoolStripMenuItem.Visible = false;
                    cậpNhậtCắtTạmDanhBộtoolStripMenuItem.Visible = false;
                    cắtTạmDanhBộtoolStripMenuItem.Visible = false;
                    cắtHủyDanhBộtoolStripMenuItem.Visible = false;
                }
                ///Khi chuột phải Selected-Row sẽ được chuyển đến nơi click chuột
                dgvDSCTCHDB.CurrentCell = dgvDSCTCHDB.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        /// <summary>
        /// Hiện thị menuStrip tại chỗ click chuột
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSCTCHDB_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvDSCTCHDB.RowCount > 0 && e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(dgvDSCTCHDB, new Point(e.X, e.Y));
            }
        }

        /// <summary>
        /// Kết thúc Edit Column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSCTCHDB_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (radDSCatTamDanhBo.Checked)
            {
                CTCTDB ctctdb = _cCHDB.getCTCTDBbyID(decimal.Parse(dgvDSCTCHDB.CurrentRow.Cells["MaTB"].Value.ToString()));
                if (bool.Parse(dgvDSCTCHDB.CurrentCell.Value.ToString()) != ctctdb.ThongBaoDuocKy)
                {
                    ctctdb.ThongBaoDuocKy = bool.Parse(dgvDSCTCHDB.CurrentCell.Value.ToString());
                    _cCHDB.SuaCTCTDB(ctctdb);
                }
                if (bool.Parse(dgvDSCTCHDB.CurrentRow.Cells["PhieuDuocKy"].Value.ToString()) != ctctdb.PhieuDuocKy)
                {
                    ctctdb.PhieuDuocKy = bool.Parse(dgvDSCTCHDB.CurrentRow.Cells["PhieuDuocKy"].Value.ToString());
                    _cCHDB.SuaCTCTDB(ctctdb);
                    YeuCauCHDB ycchdb = _cCHDB.getYeuCauCHDBbyMaCTCTDB(ctctdb.MaCTCTDB);
                    ycchdb.PhieuDuocKy = ctctdb.PhieuDuocKy;
                    _cCHDB.SuaYeuCauCHDB(ycchdb);
                }
            }
            if (radDSCatHuyDanhBo.Checked)
            {
                CTCHDB ctchdb = _cCHDB.getCTCHDBbyID(decimal.Parse(dgvDSCTCHDB.CurrentRow.Cells["MaTB"].Value.ToString()));
                if (bool.Parse(dgvDSCTCHDB.CurrentRow.Cells["ThongBaoDuocKy"].Value.ToString()) != ctchdb.ThongBaoDuocKy)
                {
                    ctchdb.ThongBaoDuocKy = bool.Parse(dgvDSCTCHDB.CurrentRow.Cells["ThongBaoDuocKy"].Value.ToString());
                    _cCHDB.SuaCTCHDB(ctchdb);
                }
                if (bool.Parse(dgvDSCTCHDB.CurrentRow.Cells["PhieuDuocKy"].Value.ToString()) != ctchdb.PhieuDuocKy)
                {
                    ctchdb.PhieuDuocKy = bool.Parse(dgvDSCTCHDB.CurrentRow.Cells["PhieuDuocKy"].Value.ToString());
                    _cCHDB.SuaCTCHDB(ctchdb);
                    YeuCauCHDB ycchdb = _cCHDB.getYeuCauCHDBbyMaCTCHDB(ctchdb.MaCTCHDB);
                    ycchdb.PhieuDuocKy = ctchdb.PhieuDuocKy;
                    _cCHDB.SuaYeuCauCHDB(ycchdb);
                }
            }
        }

        /// <summary>
        /// Ctrl+F Tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSCTCHDB_KeyDown(object sender, KeyEventArgs e)
        {
            if (radDSCatTamDanhBo.Checked||radDSCatTamDanhBo_TXL.Checked)
                if (dgvDSCTCHDB.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
                {
                    frmShowCTDB frm = new frmShowCTDB(decimal.Parse(dgvDSCTCHDB["MaTB", dgvDSCTCHDB.CurrentRow.Index].Value.ToString()));
                    frm.ShowDialog();
                }
            if (radDSCatHuyDanhBo.Checked||radDSCatHuyDanhBo_TXL.Checked)
                if (dgvDSCTCHDB.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
                {
                    frmShowCHDB frm = new frmShowCHDB(decimal.Parse(dgvDSCTCHDB["MaTB", dgvDSCTCHDB.CurrentRow.Index].Value.ToString()));
                    frm.ShowDialog();
                }
        }

        #endregion

        #region dgvDSYCCHDB (Danh Sách Phiếu Yêu Cầu Cắt Hủy Danh Bộ)

        private void dgvDSYCCHDB_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSYCCHDB.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSYCCHDB_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSYCCHDB.Columns[e.ColumnIndex].Name == "MaYCCHDB" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (dgvDSYCCHDB.Columns[e.ColumnIndex].Name == "YC_SoTien" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvDSYCCHDB_KeyDown(object sender, KeyEventArgs e)
        {
            if (radDSYCCHDB.Checked)
                if (dgvDSYCCHDB.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
                {
                    frmShowYCCHDB frm = new frmShowYCCHDB(decimal.Parse(dgvDSYCCHDB["MaYCCHDB", dgvDSYCCHDB.CurrentRow.Index].Value.ToString()));
                    frm.ShowDialog();
                }
        }

        #endregion

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked)
                for (int i = 0; i < dgvDSCTCHDB.Rows.Count; i++)
                {
                    dgvDSCTCHDB["In", i].Value = true;
                }
            else
                for (int i = 0; i < dgvDSCTCHDB.Rows.Count; i++)
                {
                    dgvDSCTCHDB["In", i].Value = false;
                }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn In những Thông Báo trên?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    if (radDSCatTamDanhBo.Checked||radDSCatTamDanhBo_TXL.Checked)
                        for (int i = 0; i < dgvDSCTCHDB.Rows.Count; i++)
                            if (bool.Parse(dgvDSCTCHDB["In", i].Value.ToString()) == true)
                            {
                                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                DataRow dr = dsBaoCao.Tables["ThongBaoCHDB"].NewRow();

                                CTCTDB ctctdb = _cCHDB.getCTCTDBbyID(decimal.Parse(dgvDSCTCHDB["MaTB", i].Value.ToString()));
                                dr["SoPhieu"] = ctctdb.MaCTCTDB.ToString().Insert(ctctdb.MaCTCTDB.ToString().Length - 2, "-");
                                dr["HoTen"] = ctctdb.HoTen;
                                dr["DiaChi"] = ctctdb.DiaChi;
                                dr["DanhBo"] = ctctdb.DanhBo.Insert(7, " ").Insert(4, " ");
                                dr["HopDong"] = ctctdb.HopDong;
                                if (ctctdb.LyDo != "Vấn Đề Khác")
                                    dr["LyDo"] = ctctdb.LyDo + ". ";
                                if (ctctdb.GhiChuLyDo != "")
                                    dr["LyDo"] += ctctdb.GhiChuLyDo + ". ";
                                if (ctctdb.SoTien.ToString() != "")
                                    dr["LyDo"] += "Số Tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", ctctdb.SoTien);
                                dr["ChucVu"] = ctctdb.ChucVu;
                                dr["NguoiKy"] = ctctdb.NguoiKy;

                                dsBaoCao.Tables["ThongBaoCHDB"].Rows.Add(dr);

                                rptThongBaoCTDB rpt = new rptThongBaoCTDB();
                                rpt.SetDataSource(dsBaoCao);

                                printDialog.AllowSomePages = true;
                                printDialog.ShowHelp = true;

                                rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                                rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;

                                rpt.PrintToPrinter(1, false, 0, 0);
                            }
                    if (radDSCatHuyDanhBo.Checked || radDSCatHuyDanhBo_TXL.Checked)
                        for (int i = 0; i < dgvDSCTCHDB.Rows.Count; i++)
                            if (bool.Parse(dgvDSCTCHDB["In", i].Value.ToString()) == true)
                            {
                                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                DataRow dr = dsBaoCao.Tables["ThongBaoCHDB"].NewRow();

                                CTCHDB ctchdb = _cCHDB.getCTCHDBbyID(decimal.Parse(dgvDSCTCHDB["MaTB", i].Value.ToString()));
                                dr["SoPhieu"] = ctchdb.MaCTCHDB.ToString().Insert(ctchdb.MaCTCHDB.ToString().Length - 2, "-");
                                dr["HoTen"] = ctchdb.HoTen;
                                dr["DiaChi"] = ctchdb.DiaChi;
                                dr["DanhBo"] = ctchdb.DanhBo.Insert(7, " ").Insert(4, " ");
                                dr["HopDong"] = ctchdb.HopDong;
                                if (ctchdb.LyDo != "Vấn Đề Khác")
                                    dr["LyDo"] = ctchdb.LyDo + ". ";
                                if (ctchdb.GhiChuLyDo != "")
                                    dr["LyDo"] += ctchdb.GhiChuLyDo + ". ";
                                if (ctchdb.SoTien.ToString() != "")
                                    dr["LyDo"] += "Số Tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", ctchdb.SoTien);
                                dr["ChucVu"] = ctchdb.ChucVu;
                                dr["NguoiKy"] = ctchdb.NguoiKy;

                                dsBaoCao.Tables["ThongBaoCHDB"].Rows.Add(dr);

                                rptThongBaoCHDB rpt = new rptThongBaoCHDB();
                                rpt.SetDataSource(dsBaoCao);

                                printDialog.AllowSomePages = true;
                                printDialog.ShowHelp = true;

                                rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                                rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;

                                rpt.PrintToPrinter(1, false, 0, 0);
                            }
                }
            }
        }

        private void radDaDuyet_TXL_CheckedChanged(object sender, EventArgs e)
        {
            if (radDaDuyet_TXL.Checked)
            {
                DSCHDB_BS = new BindingSource();
                DSCHDB_BS.DataSource = _cCHDB.LoadDSCHDBDaDuyet_TXL().Tables["CHDB"];
                gridControl.DataSource = DSCHDB_BS;

                radDaDuyet.Checked = false;
                radDSCatHuyDanhBo.Checked = false;
                radDSCatTamDanhBo.Checked = false;
                gridControl.Visible = true;
                dgvDSCTCHDB.Visible = false;
                //btnLuu.Enabled = true;
                chkSelectAll.Visible = false;
            }
        }

        private void radDSCatTamDanhBo_TXL_CheckedChanged(object sender, EventArgs e)
        {
            if (radDSCatTamDanhBo_TXL.Checked)
            {
                DSCHDB_BS = new BindingSource();
                DSCHDB_BS.DataSource = _cCHDB.LoadDSCTCTDB_TXL();
                dgvDSCTCHDB.DataSource = DSCHDB_BS;

                radDaDuyet.Checked = false;
                radDSCatHuyDanhBo.Checked = false;
                radDSCatTamDanhBo.Checked = false;
                dgvDSCTCHDB.Visible = true;
                dgvDSCTCHDB.Columns["DaLapPhieu"].Visible = false;
                dgvDSCTCHDB.Columns["PhieuDuocKy"].Visible = false;
                gridControl.Visible = false;
                //btnLuu.Enabled = false;
                chkSelectAll.Visible = true;
            }
        }

        private void radDSCatHuyDanhBo_TXL_CheckedChanged(object sender, EventArgs e)
        {
            if (radDSCatHuyDanhBo_TXL.Checked)
            {
                DSCHDB_BS = new BindingSource();
                DSCHDB_BS.DataSource = _cCHDB.LoadDSCTCHDB_TXL();
                dgvDSCTCHDB.DataSource = DSCHDB_BS;

                radDaDuyet.Checked = false;
                radDSCatHuyDanhBo.Checked = false;
                radDSCatTamDanhBo.Checked = false;
                dgvDSCTCHDB.Visible = true;
                dgvDSCTCHDB.Columns["DaLapPhieu"].Visible = true;
                dgvDSCTCHDB.Columns["PhieuDuocKy"].Visible = true;
                gridControl.Visible = false;
                //btnLuu.Enabled = false;
                chkSelectAll.Visible = true;
            }
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                case "Danh Bộ":
                    txtNoiDungTimKiem.Visible = true;
                    dateTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Ngày Lập":
                    txtNoiDungTimKiem.Visible = false;
                    dateTimKiem.Visible = true;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Khoảng Thời Gian":
                    txtNoiDungTimKiem.Visible = false;
                    dateTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = true;
                    break;
                default:
                    txtNoiDungTimKiem.Visible = false;
                    dateTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    DSCHDB_BS.RemoveFilter();
                    break;
            }
        }

        private void txtNoiDungTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtNoiDungTimKiem.Text.Trim() != "")
                {
                    string expression = "";
                    switch (cmbTimTheo.SelectedItem.ToString())
                    {
                        case "Mã Đơn":
                            if (radDaDuyet.Checked || radDSCatTamDanhBo.Checked || radDSCatHuyDanhBo.Checked)
                                expression = String.Format("MaDon = {0}", txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                            if (radDaDuyet_TXL.Checked || radDSCatTamDanhBo_TXL.Checked || radDSCatHuyDanhBo_TXL.Checked)
                                expression = String.Format("MaDon = {0}", txtNoiDungTimKiem.Text.Trim().Replace("-", "").Replace("TXL", ""));
                            break;
                        case "Danh Bộ":
                            expression = String.Format("DanhBo like '{0}%'", txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                            break;
                    }
                    DSCHDB_BS.Filter = expression;
                }
                else
                    DSCHDB_BS.RemoveFilter();
            }
            catch (Exception)
            {

            }
        }

        private void dateTimKiem_ValueChanged(object sender, EventArgs e)
        {
            string expression = String.Format("CreateDate > #{0:yyyy-MM-dd} 00:00:00# and CreateDate < #{0:yyyy-MM-dd} 23:59:59#", dateTimKiem.Value);
            DSCHDB_BS.Filter = expression;
        }

        private void dateTu_ValueChanged(object sender, EventArgs e)
        {
            if (radDaDuyet.Checked)
            {
                string expression = String.Format("CreateDate >= #{0:yyyy-MM-dd} 00:00:00# and CreateDate <= #{0:yyyy-MM-dd} 23:59:59#", dateTu.Value);
                DSCHDB_BS.Filter = expression;
                _tuNgay = dateTu.Value.ToString("dd/MM/yyyy");
                _denNgay = "";
            }
            else
                if (radDSCatTamDanhBo.Checked||radDSCatHuyDanhBo.Checked)
                {
                    string expression = String.Format("CreateDate >= #{0:yyyy-MM-dd} 00:00:00# and CreateDate <= #{0:yyyy-MM-dd} 23:59:59#", dateTu.Value);
                    DSCHDB_BS.Filter = expression;
                    _tuNgay = dateTu.Value.ToString("dd/MM/yyyy");
                    _denNgay = "";
                }
        }

        private void dateDen_ValueChanged(object sender, EventArgs e)
        {
            if (radDaDuyet.Checked)
            {
                string expression = String.Format("CreateDate >= #{0:yyyy-MM-dd} 00:00:00# and CreateDate <= #{1:yyyy-MM-dd} 23:59:59#", dateTu.Value, dateDen.Value);
                DSCHDB_BS.Filter = expression;
                _denNgay = dateDen.Value.ToString("dd/MM/yyyy");
            }
            else
                if (radDSCatTamDanhBo.Checked || radDSCatHuyDanhBo.Checked)
                {
                    string expression = String.Format("CreateDate >= #{0:yyyy-MM-dd} 00:00:00# and CreateDate <= #{1:yyyy-MM-dd} 23:59:59#", dateTu.Value, dateDen.Value);
                    DSCHDB_BS.Filter = expression;
                    _denNgay = dateDen.Value.ToString("dd/MM/yyyy");
                }
        }

        

        

        

    }
}
