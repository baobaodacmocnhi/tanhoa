using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.BamChi;
using KTKS_DonKH.GUI.ToXuLy;
using KTKS_DonKH.GUI.KhachHang;
using DevExpress.XtraGrid.Views.Grid;
using KTKS_DonKH.DAL.HeThong;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.BamChi;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.BamChi
{
    public partial class frmDSBamChi : Form
    {
        CChuyenDi _cChuyenDi = new CChuyenDi();
        CBamChi _cBamChi = new CBamChi();
        DataRowView _CTRow = null;
        BindingSource DSDon_BS;
        string _tuNgay = "", _denNgay = "";

        public frmDSBamChi()
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

        private void frmDSBamChi_Load(object sender, EventArgs e)
        {
            dgvDSCTBamChi.Location = gridControl.Location;
            dgvDSCTBamChi.AutoGenerateColumns = false;
            dgvDSCTBamChi.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSCTBamChi.Font, FontStyle.Bold);
            //DataGridViewComboBoxColumn cmbColumn = (DataGridViewComboBoxColumn)dgvDSCTKTXM.Columns["MaChuyen"];
            //cmbColumn.DataSource = _cChuyenDi.LoadDSChuyenDi("KTXM");
            //cmbColumn.DisplayMember = "NoiChuyenDi";
            //cmbColumn.ValueMember = "MaChuyen";

            //dgvDSCTKTXM.DataSource = DSDon_BS;
            if (CTaiKhoan.RoleQLBamChi_Xem || CTaiKhoan.RoleQLBamChi_CapNhat)
            {
                radDaDuyet.Checked = true;
                //btnLuu.Visible = true;
            }
            else
                if (CTaiKhoan.RoleBamChi_Xem || CTaiKhoan.RoleBamChi_CapNhat)
                    radDSBamChi.Checked = true;

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

            gridControl.LevelTree.Nodes.Add("Chi Tiết Bấm Chì", gridViewCTBamChi);
        }

        private void radDaDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radDaDuyet.Checked)
            {
                DSDon_BS = new BindingSource();
                if (CTaiKhoan.RoleQLKTXM_Xem || CTaiKhoan.RoleQLKTXM_CapNhat)
                    DSDon_BS.DataSource = _cBamChi.LoadDSBamChiDaDuyet().Tables["BamChi"];
                //cmbTimTheo.SelectedIndex = 0;
                gridControl.DataSource = DSDon_BS;
                dgvDSCTBamChi.Visible = false;
                gridControl.Visible = true;
            }
        }

        private void radDSBamChi_CheckedChanged(object sender, EventArgs e)
        {
            if (radDSBamChi.Checked)
            {
                DSDon_BS = new BindingSource();
                if (CTaiKhoan.RoleQLBamChi_Xem || CTaiKhoan.RoleQLBamChi_CapNhat)
                    DSDon_BS.DataSource = _cBamChi.LoadDSCTBamChi();
                else
                    DSDon_BS.DataSource = _cBamChi.LoadDSCTBamChi(CTaiKhoan.MaUser);
                dgvDSCTBamChi.DataSource = DSDon_BS;
                dgvDSCTBamChi.Visible = true;
                gridControl.Visible = false;
            }
        }

        #region gridViewBamChi

        private void gridViewBamChi_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaDon" && e.Value != null)
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
        }

        private void gridViewBamChi_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gridViewBamChi_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRowView itemRow = (DataRowView)gridViewBamChi.GetRow(gridViewBamChi.GetSelectedRows()[0]);

            LinQ.BamChi bamchi = _cBamChi.getBamChibyID(decimal.Parse(itemRow["MaBC"].ToString()));
            bamchi.KetQua = itemRow["KetQua"].ToString();
            bamchi.Chuyen = true;
            bamchi.MaChuyen = itemRow["MaChuyen"].ToString();
            bamchi.LyDoChuyen = itemRow["LyDoChuyenDi"].ToString();
            _cBamChi.SuaBamChi(bamchi);
        }

        private void gridViewBamChi_KeyDown(object sender, KeyEventArgs e)
        {
            if (((DataRowView)gridViewBamChi.GetRow(gridViewBamChi.GetSelectedRows()[0])).Row["ToXuLy"].ToString() == "True")
            {
                Dictionary<string, string> source = new Dictionary<string, string>();
                source.Add("Action", "View");
                source.Add("MaDon", ((DataRowView)gridViewBamChi.GetRow(gridViewBamChi.GetSelectedRows()[0])).Row["MaDon"].ToString());
                frmShowDonTXL frm = new frmShowDonTXL(source);
                frm.ShowDialog();
            }
            else
            {
                Dictionary<string, string> source = new Dictionary<string, string>();
                source.Add("Action", "View");
                source.Add("MaDon", ((DataRowView)gridViewBamChi.GetRow(gridViewBamChi.GetSelectedRows()[0])).Row["MaDon"].ToString());
                frmShowDonKH frm = new frmShowDonKH(source);
                frm.ShowDialog();
            }
        }

        #endregion

        #region gridViewCTBamChi

        private void gridViewCTBamChi_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaCTBC" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void gridViewCTBamChi_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            GridView gridview = (GridView)gridControl.GetViewAt(new Point(e.X, e.Y));
            _CTRow = (DataRowView)gridview.GetRow(gridview.GetSelectedRows()[0]);
        }

        private void gridViewCTBamChi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                frmShowBamChi frm = new frmShowBamChi(decimal.Parse(_CTRow.Row["MaCTBC"].ToString()));
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (CTaiKhoan.RoleQLBamChi_Xem || CTaiKhoan.RoleQLBamChi_CapNhat)
                        DSDon_BS.DataSource = _cBamChi.LoadDSBamChiDaDuyet().Tables["BamChi"];
                }
            }
        }

        #endregion

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (radDSBamChi.Checked)
            {
                DataTable dt = ((DataTable)DSDon_BS.DataSource).DefaultView.ToTable();
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                foreach (DataRow itemRow in dt.Rows)
                {
                    DataRow dr = dsBaoCao.Tables["DSBamChi"].NewRow();

                    dr["TuNgay"] = _tuNgay;
                    dr["DenNgay"] = _denNgay;
                    if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                        dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                    dr["HopDong"] = itemRow["HopDong"];
                    dr["HoTen"] = itemRow["HoTen"];
                    dr["DiaChi"] = itemRow["DiaChi"];
                    dr["Hieu"] = itemRow["Hieu"];
                    dr["Co"] = itemRow["Co"];
                    dr["ChiSo"] = itemRow["ChiSo"];
                    dr["TrangThai"] = itemRow["TrangThaiBC"];
                    dr["VienChi"] = itemRow["VienChi"];
                    dr["DayChi"] = itemRow["DayChi"];
                    dr["MaSoBC"] = itemRow["MaSoBC"];
                    dr["TheoYeuCau"] = itemRow["TheoYeuCau"].ToString().ToUpper();
                    dr["NguoiLap"] = CTaiKhoan.HoTen;

                    dsBaoCao.Tables["DSBamChi"].Rows.Add(dr);
                }

                rptDSBamChi rpt = new rptDSBamChi();
                rpt.SetDataSource(dsBaoCao);
                rpt.Subreports[0].SetDataSource(dsBaoCao);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Chưa chọn Danh Sách Bấm Chì", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnInQuetToanVatTu_Click(object sender, EventArgs e)
        {
            if (radDSBamChi.Checked)
            {
                DataTable dt = ((DataTable)DSDon_BS.DataSource).DefaultView.ToTable();
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                foreach (DataRow itemRow in dt.Rows)
                {
                    DataRow dr = dsBaoCao.Tables["QuyetToanVatTu"].NewRow();

                    dr["TuNgay"] = _tuNgay;
                    dr["DenNgay"] = _denNgay;
                    if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                        dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                    dr["Co"] = itemRow["Co"];
                    dr["VienChi"] = itemRow["VienChi"];
                    dr["DayChi"] = itemRow["DayChi"];
                    dr["TheoYeuCau"] = itemRow["TheoYeuCau"].ToString().ToUpper();
                    dr["NguoiLap"] = CTaiKhoan.HoTen;

                    dsBaoCao.Tables["QuyetToanVatTu"].Rows.Add(dr);
                }

                rptQuyetToanVatTu rpt = new rptQuyetToanVatTu();
                rpt.SetDataSource(dsBaoCao);
                ///report 0 là header
                for (int j = 1; j < rpt.Subreports.Count; j++)
                {
                    rpt.Subreports[j].SetDataSource(dsBaoCao);
                }

                frmBaoCao frm = new frmBaoCao(rpt);
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Chưa chọn Danh Sách Bấm Chì", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    DSDon_BS.RemoveFilter();
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
                            expression = String.Format("MaDon = {0}", txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                            break;
                        case "Danh Bộ":
                            expression = String.Format("DanhBo like '{0}%'", txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                            break;
                    }
                    DSDon_BS.Filter = expression;
                }
                else
                    DSDon_BS.RemoveFilter();
            }
            catch (Exception)
            {

            }
        }

        private void dateTimKiem_ValueChanged(object sender, EventArgs e)
        {
            if (radDaDuyet.Checked)
            {
                string expression = String.Format("CreateDate >= #{0:yyyy-MM-dd} 00:00:00# and CreateDate <= #{0:yyyy-MM-dd} 23:59:59#", dateTimKiem.Value);
                DSDon_BS.Filter = expression;
                _tuNgay = dateTimKiem.Value.ToString("dd/MM/yyyy");
            }
            else
                if (radDSBamChi.Checked)
                {
                    string expression = String.Format("NgayBC >= #{0:yyyy-MM-dd} 00:00:00# and NgayBC <= #{0:yyyy-MM-dd} 23:59:59#", dateTimKiem.Value);
                    DSDon_BS.Filter = expression;
                    _tuNgay = dateTimKiem.Value.ToString("dd/MM/yyyy");
                }
        }

        private void dateTu_ValueChanged(object sender, EventArgs e)
        {
            if (radDaDuyet.Checked)
            {
                string expression = String.Format("CreateDate >= #{0:yyyy-MM-dd} 00:00:00# and CreateDate <= #{0:yyyy-MM-dd} 23:59:59#", dateTu.Value);
                DSDon_BS.Filter = expression;
                _tuNgay = dateTu.Value.ToString("dd/MM/yyyy");
                _denNgay = "";
            }
            else
                if (radDSBamChi.Checked)
                {
                    string expression = String.Format("NgayBC >= #{0:yyyy-MM-dd} 00:00:00# and NgayBC <= #{0:yyyy-MM-dd} 23:59:59#", dateTu.Value);
                    DSDon_BS.Filter = expression;
                    _tuNgay = dateTu.Value.ToString("dd/MM/yyyy");
                    _denNgay = "";
                }
        }

        private void dateDen_ValueChanged(object sender, EventArgs e)
        {
            if (radDaDuyet.Checked)
            {
                string expression = String.Format("CreateDate >= #{0:yyyy-MM-dd} 00:00:00# and CreateDate <= #{1:yyyy-MM-dd} 23:59:59#", dateTu.Value, dateDen.Value);
                DSDon_BS.Filter = expression;
                _denNgay = dateDen.Value.ToString("dd/MM/yyyy");
            }
            else
                if (radDSBamChi.Checked)
                {
                    string expression = String.Format("NgayBC >= #{0:yyyy-MM-dd} 00:00:00# and NgayBC <= #{1:yyyy-MM-dd} 23:59:59#", dateTu.Value, dateDen.Value);
                    DSDon_BS.Filter = expression;
                    _denNgay = dateDen.Value.ToString("dd/MM/yyyy");
                }
        }

        private void dgvDSCTBamChi_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDSCTBamChi.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                frmShowBamChi frm = new frmShowBamChi(decimal.Parse(dgvDSCTBamChi["MaCTBC", dgvDSCTBamChi.CurrentRow.Index].Value.ToString()));
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (CTaiKhoan.RoleQLBamChi_Xem || CTaiKhoan.RoleQLBamChi_CapNhat)
                        DSDon_BS.DataSource = _cBamChi.LoadDSCTBamChi();
                    else
                        DSDon_BS.DataSource = _cBamChi.LoadDSCTBamChi(CTaiKhoan.MaUser);
                }

            }
        }

        private void dgvDSCTBamChi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSCTBamChi.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSCTBamChi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSCTBamChi.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }
    }
}
