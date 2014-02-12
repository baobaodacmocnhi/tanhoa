using System;
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
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.KiemTraXacMinh;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmDSDCBD : Form
    {
        CChuyenDi _cChuyenDi = new CChuyenDi();
        CDonKH _cDonKH = new CDonKH();
        CDCBD _cDCBD = new CDCBD();
        CTTKH _cTTKH = new CTTKH();
        DataTable DSDCBD_Edited = new DataTable();
        CKTXM _cKTXM = new CKTXM();
        CChiNhanh _cChiNhanh = new CChiNhanh();
        CChungTu _cChungTu = new CChungTu();
        DataRowView _CTRow = null;

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

            gridControl.LevelTree.Nodes.Add("Chi Tiết Điều Chỉnh Biến Động", gridViewCTDCBD);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Điều Chỉnh Hóa Đơn", gridViewCTDCHD);

            dgvDSDCBD.AutoGenerateColumns = false;
            dgvDSDCBD.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSDCBD.Font, FontStyle.Bold);
            dgvDSDCBD.Location = gridControl.Location;

            dgvDSCatChuyenDM.AutoGenerateColumns = false;
            dgvDSCatChuyenDM.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSDCBD.Font, FontStyle.Bold);
            dgvDSCatChuyenDM.Location = gridControl.Location;

            //DataGridViewComboBoxColumn cmbColumn_NhanNK = (DataGridViewComboBoxColumn)dgvDSDCBD.Columns["CT_NhanNK_MaCN"];
            //cmbColumn_NhanNK.DataSource = _cChiNhanh.LoadDSChiNhanh(true);
            //cmbColumn_NhanNK.DisplayMember = "TenCN";
            //cmbColumn_NhanNK.ValueMember = "MaCN";

        }

        private void radDaDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radDaDuyet.Checked)
            {
                gridControl.Visible = true;
                gridControl.DataSource = _cDCBD.LoadDSDCBDDaDuyet().Tables["DCBD"];
                dgvDSDCBD.Visible = false;
                dgvDSCatChuyenDM.Visible = false;
                btnLuu.Enabled = true;
            }
        }

        private void radChuaDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radChuaDuyet.Checked)
            {
                gridControl.Visible = true;
                gridControl.DataSource = _cDCBD.LoadDSDCBDChuaDuyet();
                dgvDSDCBD.Visible = false;
                dgvDSCatChuyenDM.Visible = false;
                btnLuu.Enabled = false;
            }
        }

        private void radDSDCDB_CheckedChanged(object sender, EventArgs e)
        {
            if (radDSDCDB.Checked)
            {
                dgvDSDCBD.Visible = true;
                dgvDSDCBD.DataSource = _cDCBD.LoadDSDCBD();
                dgvDSDCBD.Columns["HoTen"].Visible = true;
                dgvDSDCBD.Columns["HoTen_BD"].Visible = true;
                dgvDSDCBD.Columns["DiaChi"].Visible = true;
                dgvDSDCBD.Columns["DiaChi_BD"].Visible = true;
                dgvDSDCBD.Columns["MSThue"].Visible = true;
                dgvDSDCBD.Columns["MSThue_BD"].Visible = true;
                dgvDSDCBD.Columns["GiaBieu"].Visible = true;
                dgvDSDCBD.Columns["GiaBieu_BD"].Visible = true;
                dgvDSDCBD.Columns["DinhMuc"].Visible = true;
                dgvDSDCBD.Columns["DinhMuc_BD"].Visible = true;
                ///
                dgvDSDCBD.Columns["TieuThu"].Visible = false;
                dgvDSDCBD.Columns["TieuThu_BD"].Visible = false;
                dgvDSDCBD.Columns["TongCong_Start"].Visible = false;
                dgvDSDCBD.Columns["TongCong_End"].Visible = false;
                dgvDSDCBD.Columns["TongCong_BD"].Visible = false;
                dgvDSDCBD.Columns["TangGiam"].Visible = false;

                gridControl.Visible = false;
                dgvDSCatChuyenDM.Visible = false;
                btnLuu.Enabled = false;
            }
        }

        private void radDSDCHD_CheckedChanged(object sender, EventArgs e)
        {
            if (radDSDCHD.Checked)
            {
                dgvDSDCBD.Visible = true;
                dgvDSDCBD.DataSource = _cDCBD.LoadDSDCHD();
                dgvDSDCBD.Columns["HoTen"].Visible = false;
                dgvDSDCBD.Columns["HoTen_BD"].Visible = false;
                dgvDSDCBD.Columns["DiaChi"].Visible = false;
                dgvDSDCBD.Columns["DiaChi_BD"].Visible = false;
                dgvDSDCBD.Columns["MSThue"].Visible = false;
                dgvDSDCBD.Columns["MSThue_BD"].Visible = false;
                ///
                dgvDSDCBD.Columns["GiaBieu"].Visible = true;
                dgvDSDCBD.Columns["GiaBieu_BD"].Visible = true;
                dgvDSDCBD.Columns["DinhMuc"].Visible = true;
                dgvDSDCBD.Columns["DinhMuc_BD"].Visible = true;
                dgvDSDCBD.Columns["TieuThu"].Visible = true;
                dgvDSDCBD.Columns["TieuThu_BD"].Visible = true;
                dgvDSDCBD.Columns["TongCong_Start"].Visible = true;
                dgvDSDCBD.Columns["TongCong_End"].Visible = true;
                dgvDSDCBD.Columns["TongCong_BD"].Visible = true;
                dgvDSDCBD.Columns["TangGiam"].Visible = true;

                gridControl.Visible = false;
                dgvDSCatChuyenDM.Visible = false;
                btnLuu.Enabled = false;
            }
        }

        private void radDSCatChuyenDM_CheckedChanged(object sender, EventArgs e)
        {
            dgvDSCatChuyenDM.Visible = true;
            dgvDSCatChuyenDM.DataSource = _cChungTu.LoadDSCatChuyenDM();
            gridControl.Visible = false;
            dgvDSDCBD.Visible = false;
            btnLuu.Enabled = false;
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
            source.Add("NoiChuyenDen", selRow["NoiChuyenDen"].ToString());
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
            frmDCHD frm = new frmDCHD(source);
            if (frm.ShowDialog() == DialogResult.OK)
                gridControl.DataSource = _cDCBD.LoadDSDCBDChuaDuyet();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (DSDCBD_Edited != null && DSDCBD_Edited.Rows.Count > 0)
            {
                foreach (DataRow itemRow in DSDCBD_Edited.Rows)
                {
                    if (itemRow["MaDCBD"].ToString() == "")
                    {
                        DCBD dcbd = new DCBD();
                        dcbd.MaDon = decimal.Parse(itemRow["MaDon"].ToString());
                        dcbd.MaNoiChuyenDen = decimal.Parse(itemRow["MaNoiChuyenDen"].ToString());
                        dcbd.NoiChuyenDen = itemRow["NoiChuyenDen"].ToString();
                        dcbd.LyDoChuyenDen = itemRow["LyDoChuyenDen"].ToString();
                        dcbd.KetQua = itemRow["KetQua"].ToString();
                        if (itemRow["MaChuyen"].ToString() != "" && itemRow["MaChuyen"].ToString() != "NONE")
                        {
                            dcbd.Chuyen = true;
                            dcbd.MaChuyen = itemRow["MaChuyen"].ToString();
                            dcbd.LyDoChuyen = itemRow["LyDoChuyenDi"].ToString();
                        }
                        if (_cDCBD.ThemDCBD(dcbd))
                        {
                            switch (itemRow["NoiChuyenDen"].ToString())
                            {
                                case "Khách Hàng":
                                    ///Báo cho bảng DonKH là đơn này đã được nơi nhận xử lý
                                    DonKH donkh = _cDonKH.getDonKHbyID(decimal.Parse(itemRow["MaDon"].ToString()));
                                    donkh.Nhan = true;
                                    _cDonKH.SuaDonKH(donkh);
                                    break;
                                case "Điều Chỉnh Biến Động":
                                    ///Báo cho bảng KTXM là đơn này đã được nơi nhận xử lý
                                    KTXM ktxm = _cKTXM.getKTXMbyID(decimal.Parse(itemRow["MaNoiChuyenDen"].ToString()));
                                    ktxm.Nhan = true;
                                    _cKTXM.SuaKTXM(ktxm);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        DCBD dcbd = _cDCBD.getDCBDbyID(decimal.Parse(itemRow["MaDCBD"].ToString()));
                        ///Đơn đã được nơi nhận xử lý thì không được sửa
                        if (!dcbd.Nhan)
                        {
                            dcbd.KetQua = itemRow["KetQua"].ToString();
                            if (itemRow["MaChuyen"].ToString() != "" && itemRow["MaChuyen"].ToString() != "NONE")
                            {
                                dcbd.Chuyen = true;
                                dcbd.MaChuyen = itemRow["MaChuyen"].ToString();
                                dcbd.LyDoChuyen = itemRow["LyDoChuyenDi"].ToString();
                            }
                            else
                                if (itemRow["MaChuyen"].ToString() == "NONE")
                                {
                                    dcbd.Chuyen = false;
                                    dcbd.MaChuyen = null;
                                    dcbd.LyDoChuyen = null;
                                }
                            _cDCBD.SuaDCBD(dcbd);
                        }
                        else
                        {
                            MessageBox.Show("Đơn " + dcbd.MaDCBD + " đã được xử lý nên không sửa đổi được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                DSDCBD_Edited.Clear();

                if (radDaDuyet.Checked)
                    gridControl.DataSource = _cDCBD.LoadDSDCBDDaDuyet().Tables["DCBD"];
                if (radChuaDuyet.Checked)
                    gridControl.DataSource = _cDCBD.LoadDSDCBDChuaDuyet();
            }
        }

        #region gridViewDCBD (Danh Sách Điều Chỉnh Biến Động)

        /// <summary>
        /// Hiện thị số thứ tự dòng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewDCBD_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        /// <summary>
        /// Hiện thị menuStrip tại chỗ click chuột
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewDCBD_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (radChuaDuyet.Checked && gridControl.MainView.RowCount > 0 && e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(gridControl, new Point(e.X, e.Y));
            }
        }

        /// <summary>
        /// Format dữ liệu trong column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewDCBD_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
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
        private void gridViewDCBD_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            btnLuu.Enabled = false;
        }

        /// <summary>
        /// Kết thúc Edit Column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewDCBD_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            ///Khai báo các cột tương ứng trong Datagridview
            if (DSDCBD_Edited.Columns.Count == 0)
                foreach (DataColumn itemCol in ((DataView)gridViewDCBD.DataSource).Table.Columns)
                {
                    DSDCBD_Edited.Columns.Add(itemCol.ColumnName, itemCol.DataType);
                }

            ///Gọi hàm EndEdit để kết thúc Edit nếu không sẽ bị lỗi Value chưa cập nhật trong trường hợp chuyển Cell trong cùng 1 Row. Nếu chuyển Row thì không bị lỗi
            ((DataRowView)gridViewDCBD.GetRow(gridViewDCBD.GetSelectedRows()[0])).Row.EndEdit();

            ///DataRow != DataGridViewRow nên phải qua 1 loạt gán biến
            ///Tránh tình trạng trùng Danh Bộ nên xóa đi rồi add lại
            if (DSDCBD_Edited.Select("MaDon = " + ((DataRowView)gridViewDCBD.GetRow(gridViewDCBD.GetSelectedRows()[0])).Row["MaDon"]).Count() > 0)
                DSDCBD_Edited.Rows.Remove(DSDCBD_Edited.Select("MaDon = " + ((DataRowView)gridViewDCBD.GetRow(gridViewDCBD.GetSelectedRows()[0])).Row["MaDon"])[0]);

            DSDCBD_Edited.ImportRow(((DataRowView)gridViewDCBD.GetRow(gridViewDCBD.GetSelectedRows()[0])).Row);
            btnLuu.Enabled = true;
        }

        /// <summary>
        /// Ctrl+F Tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewDCBD_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridViewDCBD.RowCount > 0 && e.Control && e.KeyCode == Keys.F)
            {
                Dictionary<string, string> source = new Dictionary<string, string>();
                source.Add("Action", "View");
                source.Add("MaDon", ((DataRowView)gridViewDCBD.GetRow(gridViewDCBD.GetSelectedRows()[0])).Row["MaDon"].ToString());
                frmShowDonKH frm = new frmShowDonKH(source);
                //frmShowDonKH frm = new frmShowDonKH(_cDonKH.getDonKHbyID(decimal.Parse(((DataRowView)gridViewDCBD.GetRow(gridViewDCBD.GetSelectedRows()[0])).Row["MaDon"].ToString())));
                frm.ShowDialog();
            }
        }

        #endregion

        #region gridViewCTDCBD (Chi Tiết Điều Chỉnh Biến Động)

        /// <summary>
        /// Format dữ liệu trong column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewCTDCBD_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaCTDCBD" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        /// <summary>
        /// Lấy DataRow tại chỗ click chuột
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewCTDCBD_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            GridView gridview = (GridView)gridControl.GetViewAt(new Point(e.X, e.Y));
            _CTRow = (DataRowView)gridview.GetRow(gridview.GetSelectedRows()[0]);
        }

        /// <summary>
        /// Ctrl+F Tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewCTDCBD_KeyDown(object sender, KeyEventArgs e)
        {
            if (_CTRow != null && e.Control && e.KeyCode == Keys.F)
            {
                frmShowDCBD frm = new frmShowDCBD(decimal.Parse(_CTRow.Row["MaCTDCBD"].ToString()));
                if (frm.ShowDialog() == DialogResult.Cancel)
                    _CTRow = null;
            }
        }

        #endregion

        #region gridViewCTDCHD (Chi Tiết Điều Chỉnh Hóa Đơn)

        /// <summary>
        /// Format dữ liệu trong column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewCTDCHD_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaCTDCHD" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (e.Column.FieldName == "TongCong_Start" && e.Value != null)
            {
                e.DisplayText = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (e.Column.FieldName == "TongCong_End" && e.Value != null)
            {
                e.DisplayText = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (e.Column.FieldName == "TongCong_BD" && e.Value != null)
            {
                e.DisplayText = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        /// <summary>
        /// Lấy DataRow tại chỗ click chuột
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewCTDCHD_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            GridView gridview = (GridView)gridControl.GetViewAt(new Point(e.X, e.Y));
            _CTRow = (DataRowView)gridview.GetRow(gridview.GetSelectedRows()[0]);
        }

        /// <summary>
        /// Ctrl+F Tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewCTDCHD_KeyDown(object sender, KeyEventArgs e)
        {
            if (_CTRow != null && e.Control && e.KeyCode == Keys.F)
            {
                frmShowDCHD frm = new frmShowDCHD(decimal.Parse(_CTRow.Row["MaCTDCHD"].ToString()));
                if (frm.ShowDialog() == DialogResult.Cancel)
                    _CTRow = null;
            }
        }

        #endregion

        #region dgvDSDCBD (Danh Sách Điều Chỉnh Biến Động)

        /// <summary>
        /// Hiện thị số thứ tự dòng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSDCBD_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSDCBD.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        /// <summary>
        /// Format dữ liệu trong column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSDCBD_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSDCBD.Columns[e.ColumnIndex].Name == "SoPhieu" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (dgvDSDCBD.Columns[e.ColumnIndex].Name == "TongCong_Start" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDSDCBD.Columns[e.ColumnIndex].Name == "TongCong_End" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvDSDCBD.Columns[e.ColumnIndex].Name == "TongCong_BD" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        /// <summary>
        /// Kết thúc Edit Column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSDCBD_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (radDSDCDB.Checked)
            {
                CTDCBD ctdcbd = _cDCBD.getCTDCBDbyID(decimal.Parse(dgvDSDCBD.CurrentRow.Cells["SoPhieu"].Value.ToString()));
                if (bool.Parse(dgvDSDCBD.CurrentCell.Value.ToString()) != ctdcbd.PhieuDuocKy)
                {
                    ctdcbd.PhieuDuocKy = bool.Parse(dgvDSDCBD.CurrentCell.Value.ToString());
                    _cDCBD.SuaCTDCBD(ctdcbd);
                }
            }
            if (radDSDCHD.Checked)
            {
                CTDCHD ctdchd = _cDCBD.getCTDCHDbyID(decimal.Parse(dgvDSDCBD.CurrentRow.Cells["SoPhieu"].Value.ToString()));
                if (bool.Parse(dgvDSDCBD.CurrentCell.Value.ToString()) != ctdchd.PhieuDuocKy)
                {
                    ctdchd.PhieuDuocKy = bool.Parse(dgvDSDCBD.CurrentCell.Value.ToString());
                    _cDCBD.SuaCTDCHD(ctdchd);
                }
            }
        }

        /// <summary>
        /// Ctrl+F Tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSDCBD_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDSDCBD.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                if (radDSDCDB.Checked)
                {
                    frmShowDCBD frm = new frmShowDCBD(decimal.Parse(dgvDSDCBD["SoPhieu", dgvDSDCBD.CurrentRow.Index].Value.ToString()));
                    frm.ShowDialog();
                }
                if (radDSDCHD.Checked)
                {
                    frmShowDCHD frm = new frmShowDCHD(decimal.Parse(dgvDSDCBD["SoPhieu", dgvDSDCBD.CurrentRow.Index].Value.ToString()));
                    frm.ShowDialog();
                }
            }
        }

        #endregion

        #region dgvDSCatChuyenDM (Danh Sách Cắt Chuyển Định Mức)

        /// <summary>
        /// Kết thúc Edit Column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSCatChuyenDM_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (radDSCatChuyenDM.Checked)
            {
                LichSuChungTu lichsuchungtu = _cChungTu.getLSCTbyID(decimal.Parse(dgvDSCatChuyenDM.CurrentRow.Cells["MaLSCT"].Value.ToString()));
                if (bool.Parse(dgvDSCatChuyenDM.CurrentCell.Value.ToString()) != lichsuchungtu.PhieuDuocKy)
                {
                    lichsuchungtu.PhieuDuocKy = bool.Parse(dgvDSCatChuyenDM.CurrentCell.Value.ToString());
                    _cChungTu.SuaLichSuChungTu(lichsuchungtu);
                }
            }
        }

        /// <summary>
        /// Format dữ liệu trong column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSCatChuyenDM_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSCatChuyenDM.Columns[e.ColumnIndex].Name == "CT_SoPhieu" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        /// <summary>
        /// Ctrl+F Tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSCatChuyenDM_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDSCatChuyenDM.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                if (dgvDSCatChuyenDM["CT_CatNhan", dgvDSCatChuyenDM.CurrentRow.Index].Value.ToString() == "Nhận")
                {
                    frmShowNhanDM frm = new frmShowNhanDM(decimal.Parse(dgvDSCatChuyenDM["MaLSCT", dgvDSCatChuyenDM.CurrentRow.Index].Value.ToString()));
                    frm.ShowDialog();
                }
                if (dgvDSCatChuyenDM["CT_CatNhan", dgvDSCatChuyenDM.CurrentRow.Index].Value.ToString() == "Cắt")
                {
                    frmShowCatChuyenDM frm = new frmShowCatChuyenDM(decimal.Parse(dgvDSCatChuyenDM["MaLSCT", dgvDSCatChuyenDM.CurrentRow.Index].Value.ToString()));
                    frm.ShowDialog();
                }
            }
        }

        #endregion

    }
}
