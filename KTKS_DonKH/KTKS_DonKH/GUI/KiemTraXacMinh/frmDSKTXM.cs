using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using KTKS_DonKH.GUI.KhachHang;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using KTKS_DonKH.DAL.HeThong;
using KTKS_DonKH.GUI.ToXuLy;
using KTKS_DonKH.BaoCao.KiemTraXacMinh;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.BaoCao;

namespace KTKS_DonKH.GUI.KiemTraXacMinh
{
    public partial class frmDSKTXM : Form
    {
        CChuyenDi _cChuyenDi = new CChuyenDi();
        CKTXM _cKTXM = new CKTXM();
        CDonKH _cDonKH = new CDonKH();
        DataTable DSKTXM_Edited = new DataTable();
        CDCBD _cDCBD = new CDCBD();
        //BindingSource DSDon_BS;
        DataRowView _CTRow = null;
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();
        string _tuNgay = "", _denNgay = "";

        public frmDSKTXM()
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

        private void frmKTXM_Load(object sender, EventArgs e)
        {
            dgvDSCTKTXM.Location = gridControl.Location;
            dgvDSCTKTXM.AutoGenerateColumns = false;
            dgvDSCTKTXM.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSCTKTXM.Font, FontStyle.Bold);
            //DataGridViewComboBoxColumn cmbColumn = (DataGridViewComboBoxColumn)dgvDSCTKTXM.Columns["MaChuyen"];
            //cmbColumn.DataSource = _cChuyenDi.LoadDSChuyenDi("KTXM");
            //cmbColumn.DisplayMember = "NoiChuyenDi";
            //cmbColumn.ValueMember = "MaChuyen";

            //dgvDSCTKTXM.DataSource = DSDon_BS;
            //if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
            //{
            //    radDaDuyet.Checked = true;
            //    //btnLuu.Visible = true;
            //}
            //else
            //    if (CTaiKhoan.RoleKTXM_Xem || CTaiKhoan.RoleKTXM_CapNhat)
                    radDSKTXM.Checked = true;

            dateTimKiem.Location = txtNoiDungTimKiem.Location;

            ///GridControl
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
            myLookUpEdit.DataSource = _cChuyenDi.LoadDSChuyenDi("KTXM");
            myLookUpEdit.DisplayMember = "NoiChuyenDi";
            myLookUpEdit.ValueMember = "MaChuyen";
            ///Add LookUpEdit vào GridControl
            ((GridView)gridControl.MainView).Columns["MaChuyen"].ColumnEdit = myLookUpEdit;

            gridControl.LevelTree.Nodes.Add("Chi Tiết Kiểm Tra Xác Minh", gridViewCTKTXM);
        }

        private void radChuaDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radChuaDuyet.Checked)
            {
                //DSDon_BS = new BindingSource();
                //DSDon_BS.DataSource = _cKTXM.LoadDSKTXMChuaDuyet();
                //cmbTimTheo.SelectedIndex = 0;
                //gridControl.DataSource = DSDon_BS;
                dgvDSCTKTXM.Visible = false;
                gridControl.Visible = true;
            }
        }

        private void radDaDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radDaDuyet.Checked)
            {
                radDaDuyet_TXL.Checked = false;
                radDSKTXM_TXL.Checked = false;

                //DSDon_BS = new BindingSource();
                //if (CTaiKhoan.RoleQLKTXM_Xem||CTaiKhoan.RoleQLKTXM_CapNhat)
                //DSDon_BS.DataSource = _cKTXM.LoadDSKTXMDaDuyet().Tables["KTXM"];
                //cmbTimTheo.SelectedIndex = 0;
                //gridControl.DataSource = DSDon_BS;
                dgvDSCTKTXM.Visible = false;
                gridControl.Visible = true;
            }
        }

        private void radDSKTXM_CheckedChanged(object sender, EventArgs e)
        {
            if (radDSKTXM.Checked)
            {
                radDaDuyet_TXL.Checked = false;
                radDSKTXM_TXL.Checked = false;

                //DSDon_BS = new BindingSource();
                //if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
                //DSDon_BS.DataSource = _cKTXM.LoadDSCTKTXM();
                //else
                //DSDon_BS.DataSource = _cKTXM.LoadDSCTKTXM(CTaiKhoan.MaUser);
                //dgvDSCTKTXM.DataSource = DSDon_BS;
                dgvDSCTKTXM.Visible = true;
                gridControl.Visible = false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (DSKTXM_Edited != null && DSKTXM_Edited.Rows.Count > 0)
                {
                    foreach (DataRow itemRow in DSKTXM_Edited.Rows)
                    {
                        //    if (itemRow["MaKTXM"].ToString() == "")
                        //    {
                        //        KTXM ktxm = new KTXM();
                        //        //ktxm.MaKTXM = decimal.Parse(itemRow["MaDon"].ToString());
                        //        ktxm.MaDon = decimal.Parse(itemRow["MaDon"].ToString());
                        //        ktxm.MaNoiChuyenDen = decimal.Parse(itemRow["MaNoiChuyenDen"].ToString());
                        //        ktxm.NoiChuyenDen = itemRow["NoiChuyenDen"].ToString();
                        //        ktxm.LyDoChuyenDen = itemRow["LyDoChuyenDen"].ToString();
                        //        ktxm.KetQua = itemRow["KetQua"].ToString();
                        //        if (itemRow["MaChuyen"].ToString() != "" && itemRow["MaChuyen"].ToString() != "NONE")
                        //        {
                        //            ktxm.Chuyen = true;
                        //            ktxm.MaChuyen = itemRow["MaChuyen"].ToString();
                        //            ktxm.LyDoChuyen = itemRow["LyDoChuyenDi"].ToString();
                        //        }
                        //        if (_cKTXM.ThemKTXM(ktxm))
                        //        {
                        //            switch (itemRow["NoiChuyenDen"].ToString())
                        //            {
                        //                case "Khách Hàng":
                        //                    ///Báo cho bảng DonKH là đơn này đã được nơi nhận xử lý
                        //                    DonKH donkh = _cDonKH.getDonKHbyID(decimal.Parse(itemRow["MaDon"].ToString()));
                        //                    donkh.Nhan = true;
                        //                    _cDonKH.SuaDonKH(donkh);
                        //                    break;
                        //                case "Điều Chỉnh Biến Động":
                        //                    ///Báo cho bảng KTXM là đơn này đã được nơi nhận xử lý
                        //                    DCBD dcbd = _cDCBD.getDCBDbyID(decimal.Parse(itemRow["MaNoiChuyenDen"].ToString()));
                        //                    dcbd.Nhan = true;
                        //                    _cDCBD.SuaDCBD(dcbd);
                        //                    break;
                        //            }
                        //        }
                        //    }
                        //    else
                        //    {
                        //        KTXM ktxm = _cKTXM.getKTXMbyID(decimal.Parse(itemRow["MaKTXM"].ToString()));
                        //        ///Đơn đã được nơi nhận xử lý thì không được sửa
                        //        if (!ktxm.Nhan)
                        //        {
                        //            ktxm.KetQua = itemRow["KetQua"].ToString();
                        //            if (itemRow["MaChuyen"].ToString() != "" && itemRow["MaChuyen"].ToString() != "NONE")
                        //            {
                        //                ktxm.Chuyen = true;
                        //                ktxm.MaChuyen = itemRow["MaChuyen"].ToString();
                        //                ktxm.LyDoChuyen = itemRow["LyDoChuyenDi"].ToString();
                        //            }
                        //            else
                        //                if (itemRow["MaChuyen"].ToString() == "NONE")
                        //                {
                        //                    ktxm.Chuyen = false;
                        //                    ktxm.MaChuyen = null;
                        //                    ktxm.LyDoChuyen = null;
                        //                }
                        //            _cKTXM.SuaKTXM(ktxm);
                        //        }
                        //        else
                        //        {
                        //            MessageBox.Show("Đơn " + ktxm.MaKTXM + " đã được xử lý nên không sửa đổi được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //        }
                        //    }

                        KTXM ktxm = _cKTXM.getKTXMbyID(decimal.Parse(itemRow["MaKTXM"].ToString()));
                        ktxm.KetQua = itemRow["KetQua"].ToString();
                        ktxm.Chuyen = true;
                        ktxm.MaChuyen = itemRow["MaChuyen"].ToString();
                        ktxm.LyDoChuyen = itemRow["LyDoChuyenDi"].ToString();
                        _cKTXM.SuaKTXM(ktxm);


                    }
                    MessageBox.Show("Lưu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DSKTXM_Edited.Clear();

                    //if (radDaDuyet.Checked)
                    //    DSDon_BS.DataSource = _cKTXM.LoadDSKTXMDaDuyet().Tables["KTXM"];
                    //if (radChuaDuyet.Checked)
                    //    DSDon_BS.DataSource = _cKTXM.LoadDSKTXMChuaDuyet();
                    //if (radDSKTXM.Checked)
                    //    DSDon_BS.DataSource = _cKTXM.LoadDSCTKTXM();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Hiện thị số thứ tự dòng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSDonKH_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSCTKTXM.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        /// <summary>
        /// Ctrl+F Tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSKTXM_KeyDown(object sender, KeyEventArgs e)
        {
            //if (dgvDSCTKTXM.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            //{
            //    Dictionary<string, string> source = new Dictionary<string, string>();
            //    source.Add("Action", "View");
            //    source.Add("MaDon", dgvDSCTKTXM["MaDon", dgvDSCTKTXM.CurrentRow.Index].Value.ToString());
            //    frmShowDonKH frm = new frmShowDonKH(source);
            //    frm.ShowDialog();
            //}
            if (dgvDSCTKTXM.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                frmShowKTXM frm = new frmShowKTXM(decimal.Parse(dgvDSCTKTXM["MaCTKTXM", dgvDSCTKTXM.CurrentRow.Index].Value.ToString()));
                frm.ShowDialog();
                //if (frm.ShowDialog() == DialogResult.OK)
                //{
                //    if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
                //        DSDon_BS.DataSource = _cKTXM.LoadDSCTKTXM();
                //    else
                //        DSDon_BS.DataSource = _cKTXM.LoadDSCTKTXM(CTaiKhoan.MaUser);
                //}

            }
        }

        /// <summary>
        /// Bắt đầu Edit Column (Cũ)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSKTXM_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //btnLuu.Enabled = false;
        }

        /// <summary>
        /// Kết thúc Edit Column (Cũ)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSKTXM_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            /////Khai báo các cột tương ứng trong Datagridview
            //if (DSKTXM_Edited.Columns.Count == 0)
            //    foreach (DataGridViewColumn itemCol in dgvDSCTKTXM.Columns)
            //    {
            //        DSKTXM_Edited.Columns.Add(itemCol.Name, itemCol.ValueType);
            //    }

            /////Gọi hàm EndEdit để kết thúc Edit nếu không sẽ bị lỗi Value chưa cập nhật trong trường hợp chuyển Cell trong cùng 1 Row. Nếu chuyển Row thì không bị lỗi
            //((DataRowView)dgvDSCTKTXM.CurrentRow.DataBoundItem).Row.EndEdit();

            /////DataRow != DataGridViewRow nên phải qua 1 loạt gán biến
            /////Tránh tình trạng trùng Danh Bộ nên xóa đi rồi add lại
            //if (DSKTXM_Edited.Select("MaDon = " + ((DataRowView)dgvDSCTKTXM.CurrentRow.DataBoundItem).Row["MaDon"]).Count() > 0)
            //    DSKTXM_Edited.Rows.Remove(DSKTXM_Edited.Select("MaDon = " + ((DataRowView)dgvDSCTKTXM.CurrentRow.DataBoundItem).Row["MaDon"])[0]);

            //DSKTXM_Edited.ImportRow(((DataRowView)dgvDSCTKTXM.CurrentRow.DataBoundItem).Row);
            //btnLuu.Enabled = true;
        }

        /// <summary>
        /// Format dữ liệu trong column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSKTXM_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSCTKTXM.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null)
                if (radDaDuyet_TXL.Checked || radDSKTXM_TXL.Checked)
                    e.Value = "TXL" + e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
                else
                    e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
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
                case "Ngày":
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
                    //DSDon_BS.RemoveFilter();
                    break;
            }
            gridControl.DataSource = null;
            dgvDSCTKTXM.DataSource = null;
        }

        private void txtNoiDungTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if (txtNoiDungTimKiem.Text.Trim() != "")
                //{
                //    string expression = "";
                //    switch (cmbTimTheo.SelectedItem.ToString())
                //    {
                //        case "Mã Đơn":
                //            if (radDaDuyet.Checked || radDSKTXM.Checked)
                //                expression = String.Format("MaDon = {0}", txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                //            if (radDaDuyet_TXL.Checked || radDSKTXM_TXL.Checked)
                //                expression = String.Format("MaDon = {0}", txtNoiDungTimKiem.Text.Trim().Replace("-", "").Replace("TXL", ""));
                //            break;
                //        case "Danh Bộ":
                //            expression = String.Format("DanhBo like '{0}%'", txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                //            break;
                //    }
                //    DSDon_BS.Filter = expression;
                //}
                //else
                //    DSDon_BS.RemoveFilter();
                if (txtNoiDungTimKiem.Text.Trim() != "")
                {
                    switch (cmbTimTheo.SelectedItem.ToString())
                    {
                        case "Mã Đơn":
                            if (radDaDuyet.Checked)
                                gridControl.DataSource = _cKTXM.LoadDSKTXMDaDuyetByMaDon(decimal.Parse(txtNoiDungTimKiem.Text.Trim().ToUpper().Replace("-", "").Replace("T", "").Replace("X", "").Replace("L", ""))).Tables["KTXM"];
                            else
                                if (radDSKTXM.Checked)
                                    if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
                                        dgvDSCTKTXM.DataSource = _cKTXM.LoadDSCTKTXMByMaDon(decimal.Parse(txtNoiDungTimKiem.Text.Trim().ToUpper().Replace("-", "").Replace("T", "").Replace("X", "").Replace("L", "")));
                                    else
                                        dgvDSCTKTXM.DataSource = _cKTXM.LoadDSCTKTXMByMaDon(CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().ToUpper().Replace("-", "").Replace("T", "").Replace("X", "").Replace("L", "")));
                            break;
                        case "Danh Bộ":
                            if (radDaDuyet.Checked)
                                gridControl.DataSource = _cKTXM.LoadDSKTXMDaDuyetByDanhBo(txtNoiDungTimKiem.Text.Trim()).Tables["KTXM"];
                            else
                                if (radDSKTXM.Checked)
                                    if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
                                        dgvDSCTKTXM.DataSource = _cKTXM.LoadDSCTKTXMByDanhBo(txtNoiDungTimKiem.Text.Trim());
                                    else
                                        dgvDSCTKTXM.DataSource = _cKTXM.LoadDSCTKTXMByDanhBo(CTaiKhoan.MaUser, txtNoiDungTimKiem.Text.Trim());
                            break;
                    }
                }
            }
            catch (Exception)
            {

            }

        }

        private void dateTimKiem_ValueChanged(object sender, EventArgs e)
        {
            if (radDaDuyet.Checked)
            {
                //string expression = String.Format("CreateDate >= #{0:yyyy-MM-dd} 00:00:00# and CreateDate <= #{0:yyyy-MM-dd} 23:59:59#", dateTimKiem.Value);
                //DSDon_BS.Filter = expression;
                _tuNgay = dateTimKiem.Value.ToString("dd/MM/yyyy");
                gridControl.DataSource = _cKTXM.LoadDSKTXMDaDuyetByDate(dateTimKiem.Value).Tables["KTXM"];
            }
            else
                if (radDSKTXM.Checked)
                {
                    //string expression = String.Format("NgayKTXM >= #{0:yyyy-MM-dd} 00:00:00# and NgayKTXM <= #{0:yyyy-MM-dd} 23:59:59#", dateTimKiem.Value);
                    //DSDon_BS.Filter = expression;
                    _tuNgay = dateTimKiem.Value.ToString("dd/MM/yyyy");
                    if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
                        dgvDSCTKTXM.DataSource = _cKTXM.LoadDSCTKTXMByDate(dateTimKiem.Value);
                    else
                        dgvDSCTKTXM.DataSource = _cKTXM.LoadDSCTKTXMByDate(CTaiKhoan.MaUser, dateTimKiem.Value);
                }
        }

        private void radDaDuyet_TXL_CheckedChanged(object sender, EventArgs e)
        {
            if (radDaDuyet_TXL.Checked)
            {
                radDaDuyet.Checked = false;
                radDSKTXM.Checked = false;

                //DSDon_BS = new BindingSource();
                //if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
                //    DSDon_BS.DataSource = _cKTXM.LoadDSKTXMDaDuyet_TXL().Tables["KTXM"];
                //cmbTimTheo.SelectedIndex = 0;
                //gridControl.DataSource = DSDon_BS;
                dgvDSCTKTXM.Visible = false;
                gridControl.Visible = true;
            }
        }

        private void radDSKTXM_TXL_CheckedChanged(object sender, EventArgs e)
        {
            if (radDSKTXM_TXL.Checked)
            {
                radDaDuyet.Checked = false;
                radDSKTXM.Checked = false;

                //DSDon_BS = new BindingSource();
                //if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
                //    DSDon_BS.DataSource = _cKTXM.LoadDSCTKTXM_TXL();
                //else
                //    DSDon_BS.DataSource = _cKTXM.LoadDSCTKTXM_TXL(CTaiKhoan.MaUser);
                //dgvDSCTKTXM.DataSource = DSDon_BS;
                dgvDSCTKTXM.Visible = true;
                gridControl.Visible = false;
            }
        }

        #region girdViewKTXM

        private void gridViewKTXM_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gridViewKTXM_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaDon" && e.Value != null)
                if (radDaDuyet_TXL.Checked || radDSKTXM_TXL.Checked)
                    e.DisplayText = "TXL" + e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
                else
                    e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
        }

        private void gridViewKTXM_KeyDown(object sender, KeyEventArgs e)
        {
            if (((DataRowView)gridViewKTXM.GetRow(gridViewKTXM.GetSelectedRows()[0])).Row["ToXuLy"].ToString() == "True")
            {
                Dictionary<string, string> source = new Dictionary<string, string>();
                source.Add("Action", "View");
                source.Add("MaDon", ((DataRowView)gridViewKTXM.GetRow(gridViewKTXM.GetSelectedRows()[0])).Row["MaDon"].ToString());
                frmShowDonTXL frm = new frmShowDonTXL(source);
                frm.ShowDialog();
            }
            else
            {
                Dictionary<string, string> source = new Dictionary<string, string>();
                source.Add("Action", "View");
                source.Add("MaDon", ((DataRowView)gridViewKTXM.GetRow(gridViewKTXM.GetSelectedRows()[0])).Row["MaDon"].ToString());
                frmShowDonKH frm = new frmShowDonKH(source);
                //frmShowDonKH frm = new frmShowDonKH(_cDonKH.getDonKHbyID(decimal.Parse(((DataRowView)gridViewTTTL.GetRow(gridViewTTTL.GetSelectedRows()[0])).Row["MaDon"].ToString())));
                frm.ShowDialog();
            }
        }

        private void gridViewKTXM_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            btnLuu.Enabled = false;
        }

        private void gridViewKTXM_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            /////Khai báo các cột tương ứng trong Datagridview
            //if (DSKTXM_Edited.Columns.Count == 0)
            //    foreach (DataColumn itemCol in ((DataTable)DSDon_BS.DataSource).Columns)
            //    {
            //        DSKTXM_Edited.Columns.Add(itemCol.ColumnName, itemCol.DataType);
            //    }

            /////Gọi hàm EndEdit để kết thúc Edit nếu không sẽ bị lỗi Value chưa cập nhật trong trường hợp chuyển Cell trong cùng 1 Row. Nếu chuyển Row thì không bị lỗi
            //((DataRowView)gridViewKTXM.GetRow(gridViewKTXM.GetSelectedRows()[0])).Row.EndEdit();

            /////DataRow != DataGridViewRow nên phải qua 1 loạt gán biến
            /////Tránh tình trạng trùng Danh Bộ nên xóa đi rồi add lại
            //if (DSKTXM_Edited.Select("MaDon = " + ((DataRowView)gridViewKTXM.GetRow(gridViewKTXM.GetSelectedRows()[0])).Row["MaDon"]).Count() > 0)
            //    DSKTXM_Edited.Rows.Remove(DSKTXM_Edited.Select("MaDon = " + ((DataRowView)gridViewKTXM.GetRow(gridViewKTXM.GetSelectedRows()[0])).Row["MaDon"])[0]);

            //DSKTXM_Edited.ImportRow(((DataRowView)gridViewKTXM.GetRow(gridViewKTXM.GetSelectedRows()[0])).Row);
            //btnLuu.Enabled = true;

            DataRowView itemRow = (DataRowView)gridViewKTXM.GetRow(gridViewKTXM.GetSelectedRows()[0]);

            KTXM ktxm = _cKTXM.getKTXMbyID(decimal.Parse(itemRow["MaKTXM"].ToString()));
            ktxm.KetQua = itemRow["KetQua"].ToString();
            ktxm.Chuyen = true;
            ktxm.MaChuyen = itemRow["MaChuyen"].ToString();
            ktxm.LyDoChuyen = itemRow["LyDoChuyenDi"].ToString();
            _cKTXM.SuaKTXM(ktxm);
        }

        #endregion

        #region girdViewCTKTXM

        private void gridViewCTKTXM_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaCTKTXM" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void gridViewCTKTXM_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            GridView gridview = (GridView)gridControl.GetViewAt(new Point(e.X, e.Y));
            _CTRow = (DataRowView)gridview.GetRow(gridview.GetSelectedRows()[0]);
        }

        private void gridViewCTKTXM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                frmShowKTXM frm = new frmShowKTXM(decimal.Parse(_CTRow.Row["MaCTKTXM"].ToString()));
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
                    //    DSDon_BS.DataSource = _cKTXM.LoadDSKTXMDaDuyet().Tables["KTXM"];
                }
            }
        }

        #endregion

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (radDSKTXM.Checked)
            {
                DataTable dt = ((DataTable)dgvDSCTKTXM.DataSource).DefaultView.ToTable();
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                foreach (DataRow itemRow in dt.Rows)
                {
                    DataRow dr = dsBaoCao.Tables["DSKTXM"].NewRow();

                    dr["TuNgay"] = _tuNgay;
                    dr["DenNgay"] = _denNgay;
                    dr["TenLD"] = itemRow["TenLD"];
                    dr["MaCTKTXM"] = itemRow["MaCTKTXM"];
                    //dr["NgayNhan"] = itemRow["CreateDate"].ToString().Substring(0, 10);
                    //DonKH donkh = _cDonKH.getDonKHbyID(decimal.Parse(itemRow["MaDon"].ToString()));
                    if (itemRow["ToXuLy"].ToString() == "True")
                        dr["MaDon"] = "TXL" + itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-");
                    else
                        dr["MaDon"] = itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-");
                    if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                        dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                    dr["HoTen"] = itemRow["HoTen"];
                    dr["DiaChi"] = itemRow["DiaChi"];
                    dr["NoiDungKiemTra"] = itemRow["NoiDungKiemTra"];
                    dr["NguoiLap"] = itemRow["CreateBy"];
                    if (_cTaiKhoan.getUserbyID(int.Parse(itemRow["MaU"].ToString())).ToKH)
                        dr["To"] = "TKH";
                    else
                        if (_cTaiKhoan.getUserbyID(int.Parse(itemRow["MaU"].ToString())).ToXuLy)
                            dr["To"] = "TXL";

                    dsBaoCao.Tables["DSKTXM"].Rows.Add(dr);
                }

                if (CTaiKhoan.MaUser == 1 || CTaiKhoan.MaUser == 26 || CTaiKhoan.MaUser == 27||CTaiKhoan.MaUser==13)
                {
                    if (chkLoaiDon.Checked)
                    {
                        rptThongKeDSKTXM_LoaiDon rpt = new rptThongKeDSKTXM_LoaiDon();
                        rpt.SetDataSource(dsBaoCao);
                        rpt.Subreports[0].SetDataSource(dsBaoCao);
                        frmBaoCao frm = new frmBaoCao(rpt);
                        frm.ShowDialog();
                    }
                    else
                    {
                        rptThongKeDSKTXM rpt = new rptThongKeDSKTXM();
                        rpt.SetDataSource(dsBaoCao);
                        rpt.Subreports[0].SetDataSource(dsBaoCao);
                        frmBaoCao frm = new frmBaoCao(rpt);
                        frm.ShowDialog();
                    }
                }
                else
                {
                    rptDSKTXM rpt = new rptDSKTXM();
                    rpt.SetDataSource(dsBaoCao);
                    frmBaoCao frm = new frmBaoCao(rpt);
                    frm.ShowDialog();
                }
            }
            else
                MessageBox.Show("Chưa chọn Danh Sách KTXM", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dateTu_ValueChanged(object sender, EventArgs e)
        {
            if (radDaDuyet.Checked)
            {
                //string expression = String.Format("CreateDate >= #{0:yyyy-MM-dd} 00:00:00# and CreateDate <= #{0:yyyy-MM-dd} 23:59:59#", dateTu.Value);
                //DSDon_BS.Filter = expression;
                _tuNgay = dateTu.Value.ToString("dd/MM/yyyy");
                _denNgay = "";
                gridControl.DataSource = _cKTXM.LoadDSKTXMDaDuyetByDate(dateTu.Value).Tables["KTXM"];
            }
            else
                if (radDSKTXM.Checked)
                {
                    //string expression = String.Format("NgayKTXM >= #{0:yyyy-MM-dd} 00:00:00# and NgayKTXM <= #{0:yyyy-MM-dd} 23:59:59#", dateTu.Value);
                    //DSDon_BS.Filter = expression;
                    _tuNgay = dateTu.Value.ToString("dd/MM/yyyy");
                    _denNgay = "";
                    if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
                        dgvDSCTKTXM.DataSource = _cKTXM.LoadDSCTKTXMByDate(dateTu.Value);
                    else
                        dgvDSCTKTXM.DataSource = _cKTXM.LoadDSCTKTXMByDate(CTaiKhoan.MaUser, dateTu.Value);
                }
        }

        private void dateDen_ValueChanged(object sender, EventArgs e)
        {
            if (radDaDuyet.Checked)
            {
                //string expression = String.Format("CreateDate >= #{0:yyyy-MM-dd} 00:00:00# and CreateDate <= #{1:yyyy-MM-dd} 23:59:59#", dateTu.Value, dateDen.Value);
                //DSDon_BS.Filter = expression;
                _denNgay = dateDen.Value.ToString("dd/MM/yyyy");
                gridControl.DataSource = _cKTXM.LoadDSKTXMDaDuyetByDates(dateTu.Value, dateDen.Value).Tables["KTXM"];
            }
            else
                if (radDSKTXM.Checked)
                {
                    //string expression = String.Format("NgayKTXM >= #{0:yyyy-MM-dd} 00:00:00# and NgayKTXM <= #{1:yyyy-MM-dd} 23:59:59#", dateTu.Value, dateDen.Value);
                    //DSDon_BS.Filter = expression;
                    _denNgay = dateDen.Value.ToString("dd/MM/yyyy");
                    if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
                        dgvDSCTKTXM.DataSource = _cKTXM.LoadDSCTKTXMByDates(dateTu.Value, dateDen.Value);
                    else
                        dgvDSCTKTXM.DataSource = _cKTXM.LoadDSCTKTXMByDates(CTaiKhoan.MaUser, dateTu.Value, dateDen.Value);
                }
        }
    }
}