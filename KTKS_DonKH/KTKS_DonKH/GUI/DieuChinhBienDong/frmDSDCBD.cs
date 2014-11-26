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
using KTKS_DonKH.BaoCao.DieuChinhBienDong;
using KTKS_DonKH.BaoCao;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Printing;
using KTKS_DonKH.GUI.ToXuLy;
using System.Threading;
using KTKS_DonKH.DAL.HeThong;
using KTKS_DonKH.GUI.BaoCao;

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
        CCatChuyenDM _cCatChuyenDM = new CCatChuyenDM();
        DataRowView _CTRow = null;
        BindingSource DSDCBD_BS;

        public frmDSDCBD()
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

        private void frmDSDCBD_Load(object sender, EventArgs e)
        {
            dateTimKiem.Location = txtNoiDungTimKiem.Location;
            //txtNoiDungTimKiem2.Location = new Point(746, 35);
            //panel_KhoangThoiGian.Location = new Point(746, 1);

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

            radDSDCBD.Checked = true;

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
                DSDCBD_BS = new BindingSource();
                DSDCBD_BS.DataSource = _cDCBD.LoadDSDCBDDaDuyet().Tables["DCBD"];
                gridControl.DataSource = DSDCBD_BS;

                gridControl.Visible = true;
                dgvDSDCBD.Visible = false;
                dgvDSCatChuyenDM.Visible = false;
                chkSelectAll.Visible = false;
            }
        }

        private void radChuaDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radChuaDuyet.Checked)
            {
                DSDCBD_BS = new BindingSource();
                DSDCBD_BS.DataSource = _cDCBD.LoadDSDCBDChuaDuyet();
                gridControl.DataSource = DSDCBD_BS;

                gridControl.Visible = true;
                dgvDSDCBD.Visible = false;
                dgvDSCatChuyenDM.Visible = false;
                chkSelectAll.Visible = false;
            }
        }

        private void radDSDCDB_CheckedChanged(object sender, EventArgs e)
        {
            if (radDSDCBD.Checked)
            {
                DSDCBD_BS = new BindingSource();
                DSDCBD_BS.DataSource = _cDCBD.LoadDSCTDCBD();
                dgvDSDCBD.DataSource = DSDCBD_BS;

                dgvDSDCBD.Columns["ChuyenDocSo"].Visible = true;
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

                dgvDSDCBD.Visible = true;
                gridControl.Visible = false;
                dgvDSCatChuyenDM.Visible = false;
                chkSelectAll.Visible = true;
            }
        }

        private void radDSDCHD_CheckedChanged(object sender, EventArgs e)
        {
            if (radDSDCHD.Checked)
            {
                DSDCBD_BS = new BindingSource();
                DSDCBD_BS.DataSource = _cDCBD.LoadDSCTDCHD();
                dgvDSDCBD.DataSource = DSDCBD_BS;

                dgvDSDCBD.Columns["ChuyenDocSo"].Visible = false;
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

                dgvDSDCBD.Visible = true;
                gridControl.Visible = false;
                dgvDSCatChuyenDM.Visible = false;
                chkSelectAll.Visible = true;
            }
        }

        private void radDSCatChuyenDM_CheckedChanged(object sender, EventArgs e)
        {
            DSDCBD_BS = new BindingSource();
            DSDCBD_BS.DataSource = _cChungTu.LoadDSCatChuyenDM();
            dgvDSCatChuyenDM.DataSource = DSDCBD_BS;

            dgvDSCatChuyenDM.Visible = true;
            gridControl.Visible = false;
            dgvDSDCBD.Visible = false;
            chkSelectAll.Visible = true;
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
            try
            {
                if (DSDCBD_Edited != null && DSDCBD_Edited.Rows.Count > 0)
                {
                    foreach (DataRow itemRow in DSDCBD_Edited.Rows)
                    {
                        //if (itemRow["MaDCBD"].ToString() == "")
                        //{
                        //    DCBD dcbd = new DCBD();
                        //    dcbd.MaDon = decimal.Parse(itemRow["MaDon"].ToString());
                        //    dcbd.MaNoiChuyenDen = decimal.Parse(itemRow["MaNoiChuyenDen"].ToString());
                        //    dcbd.NoiChuyenDen = itemRow["NoiChuyenDen"].ToString();
                        //    dcbd.LyDoChuyenDen = itemRow["LyDoChuyenDen"].ToString();
                        //    dcbd.KetQua = itemRow["KetQua"].ToString();
                        //    if (itemRow["MaChuyen"].ToString() != "" && itemRow["MaChuyen"].ToString() != "NONE")
                        //    {
                        //        dcbd.Chuyen = true;
                        //        dcbd.MaChuyen = itemRow["MaChuyen"].ToString();
                        //        dcbd.LyDoChuyen = itemRow["LyDoChuyenDi"].ToString();
                        //    }
                        //    if (_cDCBD.ThemDCBD(dcbd))
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
                        //    DCBD dcbd = _cDCBD.getDCBDbyID(decimal.Parse(itemRow["MaDCBD"].ToString()));
                        //    ///Đơn đã được nơi nhận xử lý thì không được sửa
                        //    if (!dcbd.Nhan)
                        //    {
                        //        dcbd.KetQua = itemRow["KetQua"].ToString();
                        //        if (itemRow["MaChuyen"].ToString() != "" && itemRow["MaChuyen"].ToString() != "NONE")
                        //        {
                        //            dcbd.Chuyen = true;
                        //            dcbd.MaChuyen = itemRow["MaChuyen"].ToString();
                        //            dcbd.LyDoChuyen = itemRow["LyDoChuyenDi"].ToString();
                        //        }
                        //        else
                        //            if (itemRow["MaChuyen"].ToString() == "NONE")
                        //            {
                        //                dcbd.Chuyen = false;
                        //                dcbd.MaChuyen = null;
                        //                dcbd.LyDoChuyen = null;
                        //            }
                        //        _cDCBD.SuaDCBD(dcbd);
                        //    }
                        //    else
                        //    {
                        //        MessageBox.Show("Đơn " + dcbd.MaDCBD + " đã được xử lý nên không sửa đổi được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    }
                        //}
                        DCBD dcbd = _cDCBD.getDCBDbyID(decimal.Parse(itemRow["MaDCBD"].ToString()));
                        dcbd.KetQua = itemRow["KetQua"].ToString();
                        dcbd.Chuyen = true;
                        dcbd.MaChuyen = itemRow["MaChuyen"].ToString();
                        dcbd.LyDoChuyen = itemRow["LyDoChuyenDi"].ToString();
                        _cDCBD.SuaDCBD(dcbd);
                    }
                    MessageBox.Show("Lưu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DSDCBD_Edited.Clear();

                    if (radDaDuyet.Checked)
                        gridControl.DataSource = _cDCBD.LoadDSDCBDDaDuyet().Tables["DCBD"];
                    if (radChuaDuyet.Checked)
                        gridControl.DataSource = _cDCBD.LoadDSDCBDChuaDuyet();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            /////Khai báo các cột tương ứng trong Datagridview
            //if (DSDCBD_Edited.Columns.Count == 0)
            //    foreach (DataColumn itemCol in ((DataView)gridViewDCBD.DataSource).Table.Columns)
            //    {
            //        DSDCBD_Edited.Columns.Add(itemCol.ColumnName, itemCol.DataType);
            //    }

            /////Gọi hàm EndEdit để kết thúc Edit nếu không sẽ bị lỗi Value chưa cập nhật trong trường hợp chuyển Cell trong cùng 1 Row. Nếu chuyển Row thì không bị lỗi
            //((DataRowView)gridViewDCBD.GetRow(gridViewDCBD.GetSelectedRows()[0])).Row.EndEdit();

            /////DataRow != DataGridViewRow nên phải qua 1 loạt gán biến
            /////Tránh tình trạng trùng Danh Bộ nên xóa đi rồi add lại
            //if (DSDCBD_Edited.Select("MaDon = " + ((DataRowView)gridViewDCBD.GetRow(gridViewDCBD.GetSelectedRows()[0])).Row["MaDon"]).Count() > 0)
            //    DSDCBD_Edited.Rows.Remove(DSDCBD_Edited.Select("MaDon = " + ((DataRowView)gridViewDCBD.GetRow(gridViewDCBD.GetSelectedRows()[0])).Row["MaDon"])[0]);

            //DSDCBD_Edited.ImportRow(((DataRowView)gridViewDCBD.GetRow(gridViewDCBD.GetSelectedRows()[0])).Row);
            //btnLuu.Enabled = true;

            DataRowView itemRow = (DataRowView)gridViewDCBD.GetRow(gridViewDCBD.GetSelectedRows()[0]);

            DCBD dcbd = _cDCBD.getDCBDbyID(decimal.Parse(itemRow["MaDCBD"].ToString()));
            dcbd.KetQua = itemRow["KetQua"].ToString();
            dcbd.Chuyen = true;
            dcbd.MaChuyen = itemRow["MaChuyen"].ToString();
            dcbd.LyDoChuyen = itemRow["LyDoChuyenDi"].ToString();
            _cDCBD.SuaDCBD(dcbd);
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
                if (((DataRowView)gridViewDCBD.GetRow(gridViewDCBD.GetSelectedRows()[0])).Row["ToXuLy"].ToString() == "True")
                {
                    Dictionary<string, string> source = new Dictionary<string, string>();
                    source.Add("Action", "View");
                    source.Add("MaDon", ((DataRowView)gridViewDCBD.GetRow(gridViewDCBD.GetSelectedRows()[0])).Row["MaDon"].ToString());
                    frmShowDonTXL frm = new frmShowDonTXL(source);
                    //frmShowDonKH frm = new frmShowDonKH(_cDonKH.getDonKHbyID(decimal.Parse(((DataRowView)gridViewDCBD.GetRow(gridViewDCBD.GetSelectedRows()[0])).Row["MaDon"].ToString())));
                    frm.ShowDialog();
                }
                else
                {
                    Dictionary<string, string> source = new Dictionary<string, string>();
                    source.Add("Action", "View");
                    source.Add("MaDon", ((DataRowView)gridViewDCBD.GetRow(gridViewDCBD.GetSelectedRows()[0])).Row["MaDon"].ToString());
                    frmShowDonKH frm = new frmShowDonKH(source);
                    //frmShowDonKH frm = new frmShowDonKH(_cDonKH.getDonKHbyID(decimal.Parse(((DataRowView)gridViewDCBD.GetRow(gridViewDCBD.GetSelectedRows()[0])).Row["MaDon"].ToString())));
                    frm.ShowDialog();
                }
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
            if (radDSDCBD.Checked)
            {
                bool ischecked = false;
                if (bool.Parse(dgvDSDCBD["PhieuDuocKy", e.RowIndex].Value.ToString()) == true)
                    ischecked = true;
                else
                    ischecked = false;
                CTDCBD ctdcbd = _cDCBD.getCTDCBDbyID(decimal.Parse(dgvDSDCBD.CurrentRow.Cells["SoPhieu"].Value.ToString()));
                if (ctdcbd.PhieuDuocKy != ischecked)
                {
                    ctdcbd.PhieuDuocKy = ischecked;
                    _cDCBD.SuaCTDCBD(ctdcbd);
                }
            }
            if (radDSDCHD.Checked)
            {
                bool ischecked = false;
                if (bool.Parse(dgvDSDCBD["PhieuDuocKy", e.RowIndex].Value.ToString()) == true)
                    ischecked = true;
                else
                    ischecked = false;
                CTDCHD ctdchd = _cDCBD.getCTDCHDbyID(decimal.Parse(dgvDSDCBD.CurrentRow.Cells["SoPhieu"].Value.ToString()));
                if (ctdchd.PhieuDuocKy != ischecked)
                {
                    ctdchd.PhieuDuocKy = ischecked;
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
                if (radDSDCBD.Checked)
                {
                    frmShowDCBD frm = new frmShowDCBD(decimal.Parse(dgvDSDCBD["SoPhieu", dgvDSDCBD.CurrentRow.Index].Value.ToString()));
                    if (frm.ShowDialog() == DialogResult.OK)
                        DSDCBD_BS.DataSource = _cDCBD.LoadDSCTDCBD();
                }
                if (radDSDCHD.Checked)
                {
                    frmShowDCHD frm = new frmShowDCHD(decimal.Parse(dgvDSDCBD["SoPhieu", dgvDSDCBD.CurrentRow.Index].Value.ToString()));
                    if (frm.ShowDialog() == DialogResult.OK)
                        DSDCBD_BS.DataSource = _cDCBD.LoadDSCTDCHD();
                }
            }
        }

        #endregion

        #region dgvDSCatChuyenDM (Danh Sách Cắt Chuyển Định Mức)

        private void dgvDSCatChuyenDM_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSCatChuyenDM.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        /// <summary>
        /// Kết thúc Edit Column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSCatChuyenDM_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (radDSCatChuyenDM.Checked)
            {
                bool ischecked = false;
                if (bool.Parse(dgvDSCatChuyenDM["CT_PhieuDuocKy", e.RowIndex].Value.ToString()) == true)
                    ischecked = true;
                else
                    ischecked = false;
                LichSuChungTu lichsuchungtu = _cChungTu.getLSCTbyID(decimal.Parse(dgvDSCatChuyenDM.CurrentRow.Cells["MaLSCT"].Value.ToString()));
                if (lichsuchungtu.PhieuDuocKy != ischecked)
                    _cChungTu.SuaLichSuChungTu(lichsuchungtu);
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
            //if (dgvDSCatChuyenDM.Columns[e.ColumnIndex].Name == "SoPhieuDCBD" && e.Value != null && e.Value != "")
            //{
            //    e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            //}
            if (dgvDSCatChuyenDM.Columns[e.ColumnIndex].Name == "SoPhieuDCBD" && dgvDSCatChuyenDM["MaDon", e.RowIndex].Value.ToString() != "" && _cDCBD.getCTDCBDbyMaDon(decimal.Parse(dgvDSCatChuyenDM["MaDon", e.RowIndex].Value.ToString())) != null)
            {
                string a = _cDCBD.getCTDCBDbyMaDon(decimal.Parse(dgvDSCatChuyenDM["MaDon", e.RowIndex].Value.ToString())).MaCTDCBD.ToString();
                e.Value = a.Insert(a.Length - 2, "-");
            }
            if (dgvDSCatChuyenDM.Columns[e.ColumnIndex].Name == "CT_NhanNK_MaCN")
                if (dgvDSCatChuyenDM["CT_NhanNK_MaCN", e.RowIndex].Value.ToString() != "")
                    e.Value = _cChiNhanh.getTenChiNhanhbyID(int.Parse(dgvDSCatChuyenDM["CT_NhanNK_MaCN", e.RowIndex].Value.ToString()));
                else
                    e.Value = _cChiNhanh.getTenChiNhanhbyID(1);
            if (dgvDSCatChuyenDM.Columns[e.ColumnIndex].Name == "CT_CatNK_MaCN")
                if (dgvDSCatChuyenDM["CT_CatNK_MaCN", e.RowIndex].Value.ToString() != "")
                    e.Value = _cChiNhanh.getTenChiNhanhbyID(int.Parse(dgvDSCatChuyenDM["CT_CatNK_MaCN", e.RowIndex].Value.ToString()));
                else
                    e.Value = _cChiNhanh.getTenChiNhanhbyID(1);
            if (dgvDSCatChuyenDM["CatDM", e.RowIndex].Value.ToString() != "")
                if (bool.Parse(dgvDSCatChuyenDM["CatDM", e.RowIndex].Value.ToString()))
                {
                    dgvDSCatChuyenDM["CT_CatNhan", e.RowIndex].Value = "Cắt";
                    dgvDSCatChuyenDM["CT_SoNK", e.RowIndex].Value = dgvDSCatChuyenDM["SoNKCat", e.RowIndex].Value.ToString();
                }
            if (dgvDSCatChuyenDM["NhanDM", e.RowIndex].Value.ToString() != "")
                if (bool.Parse(dgvDSCatChuyenDM["NhanDM", e.RowIndex].Value.ToString()))
                {
                    dgvDSCatChuyenDM["CT_CatNhan", e.RowIndex].Value = "Nhận";
                    dgvDSCatChuyenDM["CT_SoNK", e.RowIndex].Value = dgvDSCatChuyenDM["SoNKNhan", e.RowIndex].Value.ToString();
                }
            if (dgvDSCatChuyenDM["YeuCauCat", e.RowIndex].Value.ToString() != "")
                if (bool.Parse(dgvDSCatChuyenDM["YeuCauCat", e.RowIndex].Value.ToString()))
                {
                    dgvDSCatChuyenDM["CT_CatNhan", e.RowIndex].Value = "YC Cắt";
                    dgvDSCatChuyenDM["CT_SoNK", e.RowIndex].Value = dgvDSCatChuyenDM["SoNKNhan", e.RowIndex].Value.ToString();
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
                if (dgvDSCatChuyenDM["CT_CatNhan", dgvDSCatChuyenDM.CurrentRow.Index].Value.ToString() == "YC Cắt")
                {
                    frmShowNhanDM frm = new frmShowNhanDM(decimal.Parse(dgvDSCatChuyenDM["MaLSCT", dgvDSCatChuyenDM.CurrentRow.Index].Value.ToString()));
                    frm.ShowDialog();
                }
            }
        }

        #endregion

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                case "Số Phiếu":
                    txtNoiDungTimKiem.Visible = true;
                    txtNoiDungTimKiem2.Visible = true;
                    dateTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Danh Bộ":
                    txtNoiDungTimKiem.Visible = true;
                    txtNoiDungTimKiem2.Visible = false;
                    dateTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Ngày":
                    txtNoiDungTimKiem.Visible = false;
                    txtNoiDungTimKiem2.Visible = false;
                    dateTimKiem.Visible = true;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Khoảng Thời Gian":
                    txtNoiDungTimKiem.Visible = false;
                    txtNoiDungTimKiem2.Visible = false;
                    dateTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = true;
                    break;
                default:
                    txtNoiDungTimKiem.Visible = false;
                    txtNoiDungTimKiem2.Visible = false;
                    dateTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    DSDCBD_BS.RemoveFilter();
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
                    txtNoiDungTimKiem2.Text = "";
                    switch (cmbTimTheo.SelectedItem.ToString())
                    {
                        case "Mã Đơn":
                            if (txtNoiDungTimKiem2.Text.Trim() == "")
                                expression = String.Format("MaDon = {0}", txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                            else
                                expression = String.Format("MaDon >= {0} and MaDon <= {1}", txtNoiDungTimKiem.Text.Trim().Replace("-", ""), txtNoiDungTimKiem2.Text.Trim().Replace("-", ""));
                            break;
                        case "Số Phiếu":
                            if (txtNoiDungTimKiem2.Text.Trim() == "")
                                expression = String.Format("SoPhieu = {0}", txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                            else
                                expression = String.Format("SoPhieu >= {0} and SoPhieu <= {1}", txtNoiDungTimKiem.Text.Trim().Replace("-", ""), txtNoiDungTimKiem2.Text.Trim().Replace("-", ""));
                            break;
                        case "Danh Bộ":
                            if (radDSCatChuyenDM.Checked)
                                expression = String.Format("NhanNK_DanhBo like '{0}%'", txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                            else

                                expression = String.Format("DanhBo like '{0}%'", txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                            break;
                    }
                    if (chkLocUser.Checked)
                        expression += String.Format(" and CreateBy = {0}", CTaiKhoan.MaUser);
                    DSDCBD_BS.Filter = expression;
                }
                else
                    DSDCBD_BS.RemoveFilter();
            }
            catch (Exception)
            {

            }

        }

        private void dateTimKiem_ValueChanged(object sender, EventArgs e)
        {
            string expression = String.Format("CreateDate >= #{0:yyyy-MM-dd} 00:00:00# and CreateDate <= #{0:yyyy-MM-dd} 23:59:59#", dateTimKiem.Value);
            if (chkLocUser.Checked)
                expression += String.Format(" and CreateBy = {0}", CTaiKhoan.MaUser);
            DSDCBD_BS.Filter = expression;
            //if (radDSDCBD.Checked)
            //{
            //    int a = 0;
            //    int b = 0;
            //    DataTable dt = ((DataTable)DSDCBD_BS.DataSource).DefaultView.ToTable();
            //    foreach (DataRow itemRow in dt.Rows)
            //    {
            //        if (!string.IsNullOrEmpty(itemRow["HoTen_BD"].ToString()))
            //        {
            //            a++;
            //        }
            //        else
            //            b++;
            //    }
            //    txtDCTen.Text = a.ToString();
            //    txtDCConLai.Text = b.ToString();
            //}
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn In những Phiếu trên?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    if (radDSDCBD.Checked)
                    {
                        try
                        {
                            for (int i = 0; i < dgvDSDCBD.Rows.Count; i++)
                                if (bool.Parse(dgvDSDCBD["In", i].Value.ToString()) == true)
                                {
                                    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                    DataRow dr = dsBaoCao.Tables["DCBD"].NewRow();

                                    CTDCBD ctdcbd = _cDCBD.getCTDCBDbyID(decimal.Parse(dgvDSDCBD["SoPhieu", i].Value.ToString()));
                                    if (ctdcbd.DCBD.ToXuLy)
                                        dr["MaDon"] = "TXL" + ctdcbd.DCBD.MaDonTXL.ToString().Insert(ctdcbd.DCBD.MaDonTXL.ToString().Length - 2, "-");
                                    else
                                        dr["MaDon"] = ctdcbd.DCBD.MaDon.ToString().Insert(ctdcbd.DCBD.MaDon.ToString().Length - 2, "-");
                                    dr["SoPhieu"] = ctdcbd.MaCTDCBD.ToString().Insert(ctdcbd.MaCTDCBD.ToString().Length - 2, "-");
                                    dr["ThongTin"] = ctdcbd.ThongTin;
                                    dr["HieuLucKy"] = ctdcbd.HieuLucKy;
                                    dr["Dot"] = ctdcbd.Dot;
                                    ///Hiện tại xử lý mã số thuế như vậy
                                    if (ctdcbd.CatMSThue)
                                        dr["MSThue"] = "MST: Cắt MST";
                                    if (!string.IsNullOrEmpty(ctdcbd.MSThue_BD))
                                        dr["MSThue"] = "MST: " + ctdcbd.MSThue_BD;
                                    dr["DanhBo"] = ctdcbd.DanhBo.Insert(7, " ").Insert(4, " ");
                                    dr["HopDong"] = ctdcbd.HopDong;
                                    dr["HoTen"] = ctdcbd.HoTen;
                                    dr["DiaChi"] = ctdcbd.DiaChi;
                                    dr["MaQuanPhuong"] = ctdcbd.MaQuanPhuong;
                                    dr["GiaBieu"] = ctdcbd.GiaBieu;
                                    dr["DinhMuc"] = ctdcbd.DinhMuc;
                                    ///Biến Động
                                    dr["HoTenBD"] = ctdcbd.HoTen_BD;
                                    dr["DiaChiBD"] = ctdcbd.DiaChi_BD;
                                    dr["GiaBieuBD"] = ctdcbd.GiaBieu_BD;
                                    dr["DinhMucBD"] = ctdcbd.DinhMuc_BD;
                                    ///Ký Tên
                                    dr["ChucVu"] = ctdcbd.ChucVu;
                                    dr["NguoiKy"] = ctdcbd.NguoiKy;

                                    dsBaoCao.Tables["DCBD"].Rows.Add(dr);

                                    rptPhieuDCBD rpt = new rptPhieuDCBD();
                                    rpt.SetDataSource(dsBaoCao);

                                    printDialog.AllowSomePages = true;
                                    printDialog.ShowHelp = true;

                                    rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                    rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                                    rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                                    //rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, false, printDialog.PrinterSettings.FromPage, printDialog.PrinterSettings.ToPage);
                                    rpt.PrintToPrinter(1, false, 1, 1);
                                    //Thread.Sleep(31000);
                                }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        if (radDSDCHD.Checked)
                        {
                            for (int i = 0; i < dgvDSDCBD.Rows.Count; i++)
                                if (bool.Parse(dgvDSDCBD["In", i].Value.ToString()) == true)
                                {
                                    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                    DataRow dr = dsBaoCao.Tables["DCHD"].NewRow();

                                    CTDCHD ctdchd = _cDCBD.getCTDCHDbyID(decimal.Parse(dgvDSDCBD["SoPhieu", i].Value.ToString()));
                                    dr["SoPhieu"] = ctdchd.MaCTDCHD.ToString().Insert(ctdchd.MaCTDCHD.ToString().Length - 2, "-");
                                    dr["DanhBo"] = ctdchd.DanhBo.Insert(7, " ").Insert(4, " "); ;
                                    dr["HoTen"] = ctdchd.HoTen;
                                    if (ctdchd.DCBD.ToXuLy)
                                        dr["SoDon"] = "TXL" + ctdchd.DCBD.MaDonTXL.Value.ToString().Insert(ctdchd.DCBD.MaDonTXL.Value.ToString().Length - 2, "-");
                                    else
                                        dr["SoDon"] = ctdchd.DCBD.MaDon.Value.ToString().Insert(ctdchd.DCBD.MaDon.Value.ToString().Length - 2, "-");
                                    dr["NgayKy"] = ctdchd.NgayKy.Value.ToString("dd/MM/yyyy");
                                    dr["KyHD"] = ctdchd.KyHD;
                                    dr["SoHD"] = ctdchd.SoHD;
                                    ///
                                    dr["TieuThuStart"] = ctdchd.TieuThu;
                                    if (ctdchd.TienNuoc_Start == 0)
                                        dr["TienNuocStart"] = "0";
                                    else
                                        dr["TienNuocStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TienNuoc_Start);
                                    if (ctdchd.ThueGTGT_Start == 0)
                                        dr["ThueGTGTStart"] = 0;
                                    else
                                        dr["ThueGTGTStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.ThueGTGT_Start);
                                    if (ctdchd.PhiBVMT_Start == 0)
                                        dr["PhiBVMTStart"] = 0;
                                    else
                                        dr["PhiBVMTStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.PhiBVMT_Start);
                                    if (ctdchd.TongCong_Start == 0)
                                        dr["TongCongStart"] = 0;
                                    else
                                        dr["TongCongStart"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TongCong_Start);
                                    ///
                                    dr["TangGiam"] = ctdchd.TangGiam;
                                    ///
                                    dr["TieuThuBD"] = ctdchd.TieuThu_BD - ctdchd.TieuThu;
                                    if (ctdchd.TienNuoc_BD == 0)
                                        dr["TienNuocBD"] = 0;
                                    else
                                        dr["TienNuocBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TienNuoc_BD);
                                    if (ctdchd.ThueGTGT_BD == 0)
                                        dr["ThueGTGTBD"] = 0;
                                    else
                                        dr["ThueGTGTBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.ThueGTGT_BD);
                                    if (ctdchd.PhiBVMT_BD == 0)
                                        dr["PhiBVMTBD"] = 0;
                                    else
                                        dr["PhiBVMTBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.PhiBVMT_BD);
                                    if (ctdchd.TongCong_BD == 0)
                                        dr["TongCongBD"] = 0;
                                    else
                                        dr["TongCongBD"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TongCong_BD);
                                    ///
                                    dr["TieuThuEnd"] = ctdchd.TieuThu_BD;
                                    if (ctdchd.TienNuoc_End == 0)
                                        dr["TienNuocEnd"] = 0;
                                    else
                                        dr["TienNuocEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TienNuoc_End);
                                    if (ctdchd.ThueGTGT_End == 0)
                                        dr["ThueGTGTEnd"] = 0;
                                    else
                                        dr["ThueGTGTEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.ThueGTGT_End);
                                    if (ctdchd.PhiBVMT_End == 0)
                                        dr["PhiBVMTEnd"] = 0;
                                    else
                                        dr["PhiBVMTEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.PhiBVMT_End);
                                    if (ctdchd.TongCong_End == 0)
                                        dr["TongCongEnd"] = 0;
                                    else
                                        dr["TongCongEnd"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ctdchd.TongCong_End);

                                    dr["ChucVu"] = ctdchd.ChucVu;
                                    dr["NguoiKy"] = ctdchd.NguoiKy;

                                    dsBaoCao.Tables["DCHD"].Rows.Add(dr);

                                    rptPhieuDCHD rpt = new rptPhieuDCHD();
                                    rpt.SetDataSource(dsBaoCao);

                                    printDialog.AllowSomePages = true;
                                    printDialog.ShowHelp = true;

                                    rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                    rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                                    rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                                    //rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.FromPage, printDialog.PrinterSettings.ToPage);
                                    rpt.PrintToPrinter(1, false, 1, 1);
                                    //Thread.Sleep(31000);
                                }
                        }
                        else
                            if (radDSCatChuyenDM.Checked)
                            {
                                for (int i = 0; i < dgvDSCatChuyenDM.Rows.Count; i++)
                                    if (bool.Parse(dgvDSCatChuyenDM["InCatChuyen", i].Value.ToString()) == true)
                                    {
                                        LichSuChungTu lichsuchungtu = _cChungTu.getLichSuChungTubySoPhieu(decimal.Parse(dgvDSCatChuyenDM["CT_SoPhieu", i].Value.ToString()));
                                        if (!string.IsNullOrEmpty(lichsuchungtu.NhanDM.ToString()))
                                        {
                                            if (lichsuchungtu.NhanDM.Value)
                                            {
                                                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                                DataRow dr = dsBaoCao.Tables["PhieuCatChuyenDM"].NewRow();

                                                if (!string.IsNullOrEmpty(lichsuchungtu.MaDon.ToString()) || !string.IsNullOrEmpty(lichsuchungtu.MaDonTXL.ToString()))
                                                    if (lichsuchungtu.ToXuLy)
                                                        dr["MaDon"] = "TXL" + lichsuchungtu.MaDonTXL.ToString().Insert(lichsuchungtu.MaDonTXL.ToString().Length - 2, "-");
                                                    else
                                                        dr["MaDon"] = lichsuchungtu.MaDon.ToString().Insert(lichsuchungtu.MaDon.ToString().Length - 2, "-");

                                                dr["SoPhieu"] = lichsuchungtu.SoPhieu.ToString().Insert(lichsuchungtu.SoPhieu.ToString().Length - 2, "-");
                                                dr["ChiNhanh"] = _cChiNhanh.getTenChiNhanhbyID(lichsuchungtu.CatNK_MaCN.Value);
                                                if (!string.IsNullOrEmpty(lichsuchungtu.NhanNK_DanhBo))
                                                    dr["DanhBoNhan"] = lichsuchungtu.NhanNK_DanhBo.Insert(7, " ").Insert(4, " "); ;
                                                dr["HoTenNhan"] = lichsuchungtu.NhanNK_HoTen;
                                                dr["DiaChiNhan"] = lichsuchungtu.NhanNK_DiaChi;
                                                if (!string.IsNullOrEmpty(lichsuchungtu.CatNK_DanhBo))
                                                    dr["DanhBoCat"] = lichsuchungtu.CatNK_DanhBo.Insert(7, " ").Insert(4, " "); ;
                                                dr["HoTenCat"] = lichsuchungtu.CatNK_HoTen;
                                                dr["DiaChiCat"] = lichsuchungtu.CatNK_DiaChi;
                                                ///có thể sai MaCT, nếu sai đổi lại lấy txtMaCT
                                                dr["SoNKCat"] = lichsuchungtu.SoNKNhan.ToString() + " nhân khẩu (HK: " + lichsuchungtu.MaCT + ")";

                                                dr["ChucVu"] = lichsuchungtu.ChucVu;
                                                dr["NguoiKy"] = lichsuchungtu.NguoiKy;

                                                dsBaoCao.Tables["PhieuCatChuyenDM"].Rows.Add(dr);

                                                rptPhieuYCCatDMx2 rpt = new rptPhieuYCCatDMx2();
                                                for (int j = 0; j < rpt.Subreports.Count; j++)
                                                {
                                                    rpt.Subreports[j].SetDataSource(dsBaoCao);
                                                }

                                                printDialog.AllowSomePages = true;
                                                printDialog.ShowHelp = true;

                                                rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                                rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                                                rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                                                rpt.PrintToPrinter(1, false, 1, 1);
                                            }
                                        }
                                        else
                                            if (!string.IsNullOrEmpty(lichsuchungtu.CatDM.ToString()))
                                            {
                                                if (lichsuchungtu.CatDM.Value)
                                                {
                                                    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                                    DataRow dr = dsBaoCao.Tables["PhieuCatChuyenDM"].NewRow();

                                                    if (!string.IsNullOrEmpty(lichsuchungtu.MaDon.ToString()) || !string.IsNullOrEmpty(lichsuchungtu.MaDonTXL.ToString()))
                                                        if (lichsuchungtu.ToXuLy)
                                                            dr["MaDon"] = "TXL" + lichsuchungtu.MaDonTXL.ToString().Insert(lichsuchungtu.MaDonTXL.ToString().Length - 2, "-");
                                                        else
                                                            dr["MaDon"] = lichsuchungtu.MaDon.ToString().Insert(lichsuchungtu.MaDon.ToString().Length - 2, "-");

                                                    dr["SoPhieu"] = lichsuchungtu.SoPhieu.ToString().Insert(lichsuchungtu.SoPhieu.ToString().Length - 2, "-");
                                                    dr["ChiNhanh"] = _cChiNhanh.getTenChiNhanhbyID(lichsuchungtu.NhanNK_MaCN.Value);
                                                    if (!string.IsNullOrEmpty(lichsuchungtu.NhanNK_DanhBo))
                                                        dr["DanhBoNhan"] = lichsuchungtu.NhanNK_DanhBo.Insert(7, " ").Insert(4, " "); ;
                                                    dr["HoTenNhan"] = lichsuchungtu.NhanNK_HoTen;
                                                    dr["DiaChiNhan"] = lichsuchungtu.NhanNK_DiaChi;
                                                    if (!string.IsNullOrEmpty(lichsuchungtu.CatNK_DanhBo))
                                                        dr["DanhBoCat"] = lichsuchungtu.CatNK_DanhBo.Insert(7, " ").Insert(4, " "); ;
                                                    dr["HoTenCat"] = lichsuchungtu.CatNK_HoTen;
                                                    dr["DiaChiCat"] = lichsuchungtu.CatNK_DiaChi;
                                                    dr["SoNKCat"] = lichsuchungtu.SoNKCat + " nhân khẩu (HK: " + lichsuchungtu.MaCT + ")";

                                                    dr["ChucVu"] = lichsuchungtu.ChucVu;
                                                    dr["NguoiKy"] = lichsuchungtu.NguoiKy;

                                                    dsBaoCao.Tables["PhieuCatChuyenDM"].Rows.Add(dr);

                                                    rptPhieuYCNhanDMx2 rpt = new rptPhieuYCNhanDMx2();
                                                    for (int j = 0; j < rpt.Subreports.Count; j++)
                                                    {
                                                        rpt.Subreports[j].SetDataSource(dsBaoCao);
                                                    }

                                                    printDialog.AllowSomePages = true;
                                                    printDialog.ShowHelp = true;

                                                    rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                                    rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                                                    rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                                                    rpt.PrintToPrinter(1, false, 1, 1);
                                                }
                                            }
                                            else
                                                if (!string.IsNullOrEmpty(lichsuchungtu.YeuCauCat.ToString()))
                                                {
                                                    if (lichsuchungtu.YeuCauCat.Value)
                                                    {
                                                        DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                                        DataRow dr = dsBaoCao.Tables["PhieuCatChuyenDM"].NewRow();

                                                        if (!string.IsNullOrEmpty(lichsuchungtu.MaDon.ToString()) || !string.IsNullOrEmpty(lichsuchungtu.MaDonTXL.ToString()))
                                                            if (lichsuchungtu.ToXuLy)
                                                                dr["MaDon"] = "TXL" + lichsuchungtu.MaDonTXL.ToString().Insert(lichsuchungtu.MaDonTXL.ToString().Length - 2, "-");
                                                            else
                                                                dr["MaDon"] = lichsuchungtu.MaDon.ToString().Insert(lichsuchungtu.MaDon.ToString().Length - 2, "-");

                                                        dr["SoPhieu"] = lichsuchungtu.SoPhieu.ToString().Insert(lichsuchungtu.SoPhieu.ToString().Length - 2, "-");
                                                        dr["ChiNhanh"] = _cChiNhanh.getTenChiNhanhbyID(lichsuchungtu.CatNK_MaCN.Value);
                                                        if (!string.IsNullOrEmpty(lichsuchungtu.NhanNK_DanhBo))
                                                            dr["DanhBoNhan"] = lichsuchungtu.NhanNK_DanhBo.Insert(7, " ").Insert(4, " "); ;
                                                        dr["HoTenNhan"] = lichsuchungtu.NhanNK_HoTen;
                                                        dr["DiaChiNhan"] = lichsuchungtu.NhanNK_DiaChi;
                                                        if (!string.IsNullOrEmpty(lichsuchungtu.CatNK_DanhBo))
                                                            dr["DanhBoCat"] = lichsuchungtu.CatNK_DanhBo.Insert(7, " ").Insert(4, " "); ;
                                                        dr["HoTenCat"] = lichsuchungtu.CatNK_HoTen;
                                                        dr["DiaChiCat"] = lichsuchungtu.CatNK_DiaChi;
                                                        ///có thể sai MaCT, nếu sai đổi lại lấy txtMaCT
                                                        dr["SoNKCat"] = lichsuchungtu.SoNKNhan.ToString() + " nhân khẩu (HK: " + lichsuchungtu.MaCT + ")";

                                                        dr["ChucVu"] = lichsuchungtu.ChucVu;
                                                        dr["NguoiKy"] = lichsuchungtu.NguoiKy;

                                                        dsBaoCao.Tables["PhieuCatChuyenDM"].Rows.Add(dr);

                                                        rptPhieuYCCatDMx2 rpt = new rptPhieuYCCatDMx2();
                                                        for (int j = 0; j < rpt.Subreports.Count; j++)
                                                        {
                                                            rpt.Subreports[j].SetDataSource(dsBaoCao);
                                                        }

                                                        printDialog.AllowSomePages = true;
                                                        printDialog.ShowHelp = true;

                                                        rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                                        rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                                                        rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                                                        rpt.PrintToPrinter(1, false, 1, 1);
                                                    }
                                                }
                                    }
                            }
                }
            }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked)
            {
                if (radDSDCBD.Checked || radDSDCHD.Checked)
                    for (int i = 0; i < dgvDSDCBD.Rows.Count; i++)
                    {
                        dgvDSDCBD["In", i].Value = true;
                    }
                else
                    if (radDSCatChuyenDM.Checked)
                        for (int i = 0; i < dgvDSCatChuyenDM.Rows.Count; i++)
                        {
                            dgvDSCatChuyenDM["InCatChuyen", i].Value = true;
                        }
            }
            else
                if (radDSDCBD.Checked || radDSDCHD.Checked)
                    for (int i = 0; i < dgvDSDCBD.Rows.Count; i++)
                    {
                        dgvDSDCBD["In", i].Value = false;
                    }
                else
                    if (radDSCatChuyenDM.Checked)
                        for (int i = 0; i < dgvDSCatChuyenDM.Rows.Count; i++)
                        {
                            dgvDSCatChuyenDM["InCatChuyen", i].Value = false;
                        }
        }

        private void txtNoiDungTimKiem2_TextChanged(object sender, EventArgs e)
        {
            if (txtNoiDungTimKiem.Text.Trim() != "" && txtNoiDungTimKiem2.Text.Trim() != "")
            {
                string expression = "";
                switch (cmbTimTheo.SelectedItem.ToString())
                {
                    case "Mã Đơn":
                        expression = String.Format("MaDon >= {0} and MaDon <= {1}", txtNoiDungTimKiem.Text.Trim().Replace("-", ""), txtNoiDungTimKiem2.Text.Trim().Replace("-", ""));
                        break;
                    case "Số Phiếu":
                        expression = String.Format("SoPhieu >= {0} and SoPhieu <= {1}", txtNoiDungTimKiem.Text.Trim().Replace("-", ""), txtNoiDungTimKiem2.Text.Trim().Replace("-", ""));
                        break;
                }
                if (chkLocUser.Checked)
                    expression += String.Format(" and CreateBy = {0}", CTaiKhoan.MaUser);
                DSDCBD_BS.Filter = expression;
            }
            else
                DSDCBD_BS.RemoveFilter();
        }

        private void dateTu_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateDen_ValueChanged(object sender, EventArgs e)
        {
            string expression = String.Format("CreateDate >= #{0:yyyy-MM-dd} 00:00:00# and CreateDate <= #{1:yyyy-MM-dd} 23:59:59#", dateTu.Value, dateDen.Value);
            if (chkLocUser.Checked)
                expression += String.Format(" and CreateBy = {0}", CTaiKhoan.MaUser);
            DSDCBD_BS.Filter = expression;
            //if (radDSDCBD.Checked)
            //{
            //    int a = 0;
            //    int b = 0;
            //    DataTable dt = ((DataTable)DSDCBD_BS.DataSource).DefaultView.ToTable();
            //    foreach (DataRow itemRow in dt.Rows)
            //    {
            //        if (!string.IsNullOrEmpty(itemRow["HoTen_BD"].ToString()))
            //        {
            //            a++;
            //        }
            //        else
            //            b++;
            //    }
            //    txtDCTen.Text = a.ToString();
            //    txtDCConLai.Text = b.ToString();
            //}
        }

        private void btnCapNhatDocSo_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Chưa được thông qua", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (MessageBox.Show("Bạn chắc chắn Cập Nhật Đọc Số những Phiếu trên?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                if (radDSDCBD.Checked)
                {
                    CDuLieuKhachHang _cDLKH = new CDuLieuKhachHang();
                    try
                    {
                        _cDLKH.beginTransaction();
                        _cDCBD.beginTransaction();
                        for (int i = 0; i < dgvDSDCBD.Rows.Count; i++)
                            if (bool.Parse(dgvDSDCBD["In", i].Value.ToString()) == true && bool.Parse(dgvDSDCBD["PhieuDuocKy", i].Value.ToString()) == true && bool.Parse(dgvDSDCBD["ChuyenDocSo", i].Value.ToString()) == false)
                            {
                                CTDCBD ctdcbd = _cDCBD.getCTDCBDbyID(decimal.Parse(dgvDSDCBD["SoPhieu", i].Value.ToString()));
                                TB_DULIEUKHACHHANG dlkh = _cDLKH.getDLKH(ctdcbd.DanhBo);
                                if (dlkh != null && !string.IsNullOrEmpty(ctdcbd.ThongTin))
                                {
                                    if (!string.IsNullOrEmpty(ctdcbd.HoTen_BD))
                                        dlkh.HOTEN = ctdcbd.HoTen_BD;
                                    //if (!string.IsNullOrEmpty(ctdcbd.DiaChi_BD))
                                    //{
                                    //    dlkh.SONHA = ctdcbd.DiaChi_BD.Substring(0,ctdcbd.DiaChi_BD.IndexOf(" "));
                                    //    dlkh.TENDUONG = ctdcbd.DiaChi_BD.Substring((ctdcbd.DiaChi_BD.IndexOf(" ") + 1), ctdcbd.DiaChi_BD.Length - ctdcbd.DiaChi_BD.IndexOf(" ") - 1);
                                    //}
                                    if (!string.IsNullOrEmpty(ctdcbd.MSThue_BD))
                                        dlkh.MSTHUE = ctdcbd.MSThue_BD;
                                    if (!string.IsNullOrEmpty(ctdcbd.GiaBieu_BD.ToString()))
                                        dlkh.GIABIEU = ctdcbd.GiaBieu_BD.ToString();
                                    if (!string.IsNullOrEmpty(ctdcbd.DinhMuc_BD.ToString()))
                                        dlkh.DINHMUC = ctdcbd.DinhMuc_BD.ToString();
                                    if (_cDLKH.SuaDLKH(dlkh))
                                    {
                                        TB_GHICHU ghichu = new TB_GHICHU();
                                        ghichu.DANHBO = dlkh.DANHBO;
                                        ghichu.DONVI = "KTKS";
                                        ghichu.NOIDUNG = " PYC: " + ctdcbd.MaCTDCBD.ToString().Insert(ctdcbd.MaCTDCBD.ToString().Length - 2, "-");
                                        ghichu.NOIDUNG += " ," + ctdcbd.CreateDate.Value.ToString("dd/MM/yyyy");
                                        ghichu.NOIDUNG += " - HL : " + ctdcbd.HieuLucKy + " - ĐC";
                                        if (!string.IsNullOrEmpty(ctdcbd.HoTen_BD))
                                        {
                                            ghichu.NOIDUNG += " Tên: " + ctdcbd.HoTen_BD + ",";
                                        }
                                        if (!string.IsNullOrEmpty(ctdcbd.DiaChi_BD))
                                        {
                                            ghichu.NOIDUNG += " Địa Chỉ: " + ctdcbd.DiaChi_BD + ",";
                                        }
                                        if (!string.IsNullOrEmpty(ctdcbd.DiaChi_BD))
                                        {
                                            ghichu.NOIDUNG += " MST: " + ctdcbd.MSThue_BD + ",";
                                        }
                                        if (!string.IsNullOrEmpty(ctdcbd.GiaBieu_BD.ToString()))
                                        {
                                            ghichu.NOIDUNG += " Giá Biểu Từ " + ctdcbd.GiaBieu + " -> " + ctdcbd.GiaBieu_BD + ",";
                                        }
                                        if (!string.IsNullOrEmpty(ctdcbd.DinhMuc_BD.ToString()))
                                        {
                                            ghichu.NOIDUNG += " Định Mức Từ " + ctdcbd.DinhMuc + " -> " + ctdcbd.DinhMuc_BD + ",";
                                        }
                                        _cDLKH.ThemGhiChu(ghichu);
                                        ctdcbd.ChuyenDocSo = true;
                                        ctdcbd.NgayChuyenDocSo = DateTime.Now;
                                        ctdcbd.NguoiChuyenDocSo = CTaiKhoan.MaUser;
                                        _cDCBD.SuaCTDCBD(ctdcbd);
                                    }
                                }
                                else
                                    MessageBox.Show("Danh Bộ: " + ctdcbd.DanhBo + " thuộc Số Phiếu: " + ctdcbd.MaCTDCBD.ToString().Insert(ctdcbd.MaCTDCBD.ToString().Length - 2, "-")
                                        + " không có bên QLĐHN", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        MessageBox.Show("Cập Nhật Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DSDCBD_BS.DataSource = _cDCBD.LoadDSCTDCBD();
                        _cDCBD.commitTransaction();
                        _cDLKH.commitTransaction();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _cDCBD.rollback();
                        _cDLKH.rollback();
                    }

                }
        }

        private void btnInDSPhieu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn In những Phiếu trên?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (radDSCatChuyenDM.Checked)
                {
                    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                    for (int i = 0; i < dgvDSCatChuyenDM.Rows.Count; i++)
                        if (bool.Parse(dgvDSCatChuyenDM["InCatChuyen", i].Value.ToString()) == true)
                        {
                            LichSuChungTu lichsuchungtu = _cChungTu.getLichSuChungTubySoPhieu(decimal.Parse(dgvDSCatChuyenDM["CT_SoPhieu", i].Value.ToString()));
                            if (!string.IsNullOrEmpty(lichsuchungtu.NhanDM.ToString()))
                            {
                                if (lichsuchungtu.NhanDM.Value)
                                {
                                    DataRow dr = dsBaoCao.Tables["PhieuCatChuyenDM"].NewRow();

                                    if (!string.IsNullOrEmpty(lichsuchungtu.MaDon.ToString()) || !string.IsNullOrEmpty(lichsuchungtu.MaDonTXL.ToString()))
                                        if (lichsuchungtu.ToXuLy)
                                            dr["MaDon"] = "TXL" + lichsuchungtu.MaDonTXL.ToString().Insert(lichsuchungtu.MaDonTXL.ToString().Length - 2, "-");
                                        else
                                            dr["MaDon"] = lichsuchungtu.MaDon.ToString().Insert(lichsuchungtu.MaDon.ToString().Length - 2, "-");

                                    dr["SoPhieu"] = lichsuchungtu.SoPhieu.ToString().Insert(lichsuchungtu.SoPhieu.ToString().Length - 2, "-");
                                    dr["ChiNhanh"] = _cChiNhanh.getTenChiNhanhbyID(lichsuchungtu.CatNK_MaCN.Value);
                                    if (!string.IsNullOrEmpty(lichsuchungtu.NhanNK_DanhBo))
                                        dr["DanhBoNhan"] = lichsuchungtu.NhanNK_DanhBo.Insert(7, " ").Insert(4, " "); ;
                                    dr["HoTenNhan"] = lichsuchungtu.NhanNK_HoTen;
                                    dr["DiaChiNhan"] = lichsuchungtu.NhanNK_DiaChi;
                                    if (!string.IsNullOrEmpty(lichsuchungtu.CatNK_DanhBo))
                                        dr["DanhBoCat"] = lichsuchungtu.CatNK_DanhBo.Insert(7, " ").Insert(4, " "); ;
                                    dr["HoTenCat"] = lichsuchungtu.CatNK_HoTen;
                                    dr["DiaChiCat"] = lichsuchungtu.CatNK_DiaChi;
                                    ///có thể sai MaCT, nếu sai đổi lại lấy txtMaCT
                                    dr["SoNKCat"] = lichsuchungtu.SoNKNhan.ToString() + " nhân khẩu (HK: " + lichsuchungtu.MaCT + ")";

                                    dr["ChucVu"] = lichsuchungtu.ChucVu;
                                    dr["NguoiKy"] = lichsuchungtu.NguoiKy;

                                    dsBaoCao.Tables["PhieuCatChuyenDM"].Rows.Add(dr);
                                }
                            }
                            else
                                //if (!string.IsNullOrEmpty(lichsuchungtu.CatDM.ToString()))
                                //{
                                //    if (lichsuchungtu.CatDM.Value)
                                //    {
                                //        DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                //        DataRow dr = dsBaoCao.Tables["PhieuCatChuyenDM"].NewRow();

                                //        if (!string.IsNullOrEmpty(lichsuchungtu.MaDon.ToString()) || !string.IsNullOrEmpty(lichsuchungtu.MaDonTXL.ToString()))
                                //            if (lichsuchungtu.ToXuLy)
                                //                dr["MaDon"] = "TXL" + lichsuchungtu.MaDonTXL.ToString().Insert(lichsuchungtu.MaDonTXL.ToString().Length - 2, "-");
                                //            else
                                //                dr["MaDon"] = lichsuchungtu.MaDon.ToString().Insert(lichsuchungtu.MaDon.ToString().Length - 2, "-");

                                //        dr["SoPhieu"] = lichsuchungtu.SoPhieu.ToString().Insert(lichsuchungtu.SoPhieu.ToString().Length - 2, "-");
                                //        dr["ChiNhanh"] = _cChiNhanh.getTenChiNhanhbyID(lichsuchungtu.NhanNK_MaCN.Value);
                                //        if (!string.IsNullOrEmpty(lichsuchungtu.NhanNK_DanhBo))
                                //            dr["DanhBoNhan"] = lichsuchungtu.NhanNK_DanhBo.Insert(7, " ").Insert(4, " "); ;
                                //        dr["HoTenNhan"] = lichsuchungtu.NhanNK_HoTen;
                                //        dr["DiaChiNhan"] = lichsuchungtu.NhanNK_DiaChi;
                                //        if (!string.IsNullOrEmpty(lichsuchungtu.CatNK_DanhBo))
                                //            dr["DanhBoCat"] = lichsuchungtu.CatNK_DanhBo.Insert(7, " ").Insert(4, " "); ;
                                //        dr["HoTenCat"] = lichsuchungtu.CatNK_HoTen;
                                //        dr["DiaChiCat"] = lichsuchungtu.CatNK_DiaChi;
                                //        dr["SoNKCat"] = lichsuchungtu.SoNKCat + " nhân khẩu (HK: " + lichsuchungtu.MaCT + ")";

                                //        dr["ChucVu"] = lichsuchungtu.ChucVu;
                                //        dr["NguoiKy"] = lichsuchungtu.NguoiKy;

                                //        dsBaoCao.Tables["PhieuCatChuyenDM"].Rows.Add(dr);

                                //        rptPhieuYCNhanDMx2 rpt = new rptPhieuYCNhanDMx2();
                                //        for (int j = 0; j < rpt.Subreports.Count; j++)
                                //        {
                                //            rpt.Subreports[j].SetDataSource(dsBaoCao);
                                //        }

                                //        printDialog.AllowSomePages = true;
                                //        printDialog.ShowHelp = true;

                                //        rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                //        rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                                //        rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                                //        rpt.PrintToPrinter(1, false, 1, 1);
                                //    }
                                //}
                                //else
                                if (!string.IsNullOrEmpty(lichsuchungtu.YeuCauCat.ToString()))
                                {
                                    if (lichsuchungtu.YeuCauCat.Value)
                                    {
                                        //DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                        DataRow dr = dsBaoCao.Tables["PhieuCatChuyenDM"].NewRow();

                                        if (!string.IsNullOrEmpty(lichsuchungtu.MaDon.ToString()) || !string.IsNullOrEmpty(lichsuchungtu.MaDonTXL.ToString()))
                                            if (lichsuchungtu.ToXuLy)
                                                dr["MaDon"] = "TXL" + lichsuchungtu.MaDonTXL.ToString().Insert(lichsuchungtu.MaDonTXL.ToString().Length - 2, "-");
                                            else
                                                dr["MaDon"] = lichsuchungtu.MaDon.ToString().Insert(lichsuchungtu.MaDon.ToString().Length - 2, "-");

                                        dr["SoPhieu"] = lichsuchungtu.SoPhieu.ToString().Insert(lichsuchungtu.SoPhieu.ToString().Length - 2, "-");
                                        dr["ChiNhanh"] = _cChiNhanh.getTenChiNhanhbyID(lichsuchungtu.CatNK_MaCN.Value);
                                        if (!string.IsNullOrEmpty(lichsuchungtu.NhanNK_DanhBo))
                                            dr["DanhBoNhan"] = lichsuchungtu.NhanNK_DanhBo.Insert(7, " ").Insert(4, " "); ;
                                        dr["HoTenNhan"] = lichsuchungtu.NhanNK_HoTen;
                                        dr["DiaChiNhan"] = lichsuchungtu.NhanNK_DiaChi;
                                        if (!string.IsNullOrEmpty(lichsuchungtu.CatNK_DanhBo))
                                            dr["DanhBoCat"] = lichsuchungtu.CatNK_DanhBo.Insert(7, " ").Insert(4, " "); ;
                                        dr["HoTenCat"] = lichsuchungtu.CatNK_HoTen;
                                        dr["DiaChiCat"] = lichsuchungtu.CatNK_DiaChi;
                                        ///có thể sai MaCT, nếu sai đổi lại lấy txtMaCT
                                        dr["SoNKCat"] = lichsuchungtu.SoNKNhan.ToString() + " nhân khẩu (HK: " + lichsuchungtu.MaCT + ")";

                                        dr["ChucVu"] = lichsuchungtu.ChucVu;
                                        dr["NguoiKy"] = lichsuchungtu.NguoiKy;

                                        dsBaoCao.Tables["PhieuCatChuyenDM"].Rows.Add(dr);
                                    }
                                }
                        }
                    rptDSPhieuCatChuyen rpt = new rptDSPhieuCatChuyen();
                    rpt.SetDataSource(dsBaoCao);

                    frmBaoCao frm = new frmBaoCao(rpt);
                    frm.ShowDialog();
                }
            }
        }


    }
}
