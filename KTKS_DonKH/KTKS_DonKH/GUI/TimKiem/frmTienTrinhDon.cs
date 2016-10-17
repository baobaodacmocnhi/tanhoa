using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.TimKiem;
using KTKS_DonKH.GUI.KhachHang;
using DevExpress.XtraGrid.Views.Grid;
using KTKS_DonKH.GUI.KiemTraXacMinh;
using KTKS_DonKH.GUI.ThaoThuTraLoi;
using KTKS_DonKH.GUI.DieuChinhBienDong;
using KTKS_DonKH.GUI.CatHuyDanhBo;
using KTKS_DonKH.GUI.ToXuLy;
using KTKS_DonKH.GUI.BamChi;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.TimKiem;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.CatHuyDanhBo;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.TimKiem
{
    public partial class frmTienTrinhDon : Form
    {
        CTimKiem _cTimKiem = new CTimKiem();
        DataRowView _CTRow = null;
        DataTable dt = new DataTable();

        public frmTienTrinhDon()
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

        private void frmTienTrinhDon_Load(object sender, EventArgs e)
        {
            cmbTimTheo.SelectedIndex = 0;
            gridControl.LevelTree.Nodes.Add("Chi Tiết Kiểm Tra Xác Minh", gridViewKTXM);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Điều Chỉnh Biến Động", gridViewDCBD);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Cắt Tạm/Hủy Danh Bộ", gridViewCHDB);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Phiếu Hủy Danh Bộ", gridViewYeuCauCHDB);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Thảo Thư Trả Lời", gridViewTTTL);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Bấm Chì", gridViewBamChi);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Đóng Nước", gridViewDongNuoc);
            ///Tổ Xử Lý
            gridControl.LevelTree.Nodes.Add("Chi Tiết Kiểm Tra Xác Minh TXL", gridViewKTXM_TXL);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Điều Chỉnh Biến Động TXL", gridViewDCBD_TXL);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Cắt Tạm/Hủy Danh Bộ TXL", gridViewCHDB_TXL);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Phiếu Hủy Danh Bộ TXL", gridViewYeuCauCHDB_TXL);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Thảo Thư Trả Lời TXL", gridViewTTTTL_TXL);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Bấm Chì TXL", gridViewBamChi_TXL);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Đóng Nước TXL", gridViewDongNuoc_TXL);
        }

        private void txtNoiDungTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNoiDungTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnTimKiem.PerformClick();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                switch (cmbTimTheo.SelectedItem.ToString())
                {
                    case "Mã Đơn":
                        ///Nếu Đơn thuộc Tổ Xử Lý
                        if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                        {
                            dt = _cTimKiem.GetTienTrinhbyMaDon_TXL(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", ""))).Tables["Don"];
                            gridControl.DataSource = dt;
                        }
                        ///Nếu Đơn thuộc Tổ Khách Hàng
                        else
                        {
                            dt = _cTimKiem.GetTienTrinhbyMaDon(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", ""))).Tables["Don"];
                            gridControl.DataSource = dt;
                        }
                        break;
                    case "Danh Bộ":
                        dt = _cTimKiem.GetTienTrinhbyDanhBo(txtNoiDungTimKiem.Text.Trim()).Tables["Don"];
                        gridControl.DataSource = dt;
                        break;
                    case "Họ Tên":
                        dt = _cTimKiem.GetTienTrinhbyHoTen(txtNoiDungTimKiem.Text.Trim()).Tables["Don"];
                        gridControl.DataSource = dt;
                        break;
                    case "Địa Chỉ":
                        dt = _cTimKiem.GetTienTrinhbyDiaChi(txtNoiDungTimKiem.Text.Trim()).Tables["Don"];
                        gridControl.DataSource = dt;
                        break;
                }
            }
            catch (Exception)
            {

            }
        }

        #region gridViewDon

        private void gridViewDon_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaDon" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void gridViewDon_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridViewDon.RowCount > 0 && e.Control && e.KeyCode == Keys.F)
            {
                if (((DataRowView)gridViewDon.GetRow(gridViewDon.GetSelectedRows()[0])).Row["ToXuLy"].ToString() == "True")
                {
                    Dictionary<string, string> source = new Dictionary<string, string>();
                    source.Add("Action", "Tìm Kiếm");
                    source.Add("MaDon", ((DataRowView)gridViewDon.GetRow(gridViewDon.GetSelectedRows()[0])).Row["MaDon"].ToString());
                    frmShowDonTXL frm = new frmShowDonTXL(source);
                    frm.ShowDialog();
                }
                else
                {
                    Dictionary<string, string> source = new Dictionary<string, string>();
                    source.Add("Action", "Tìm Kiếm");
                    source.Add("MaDon", ((DataRowView)gridViewDon.GetRow(gridViewDon.GetSelectedRows()[0])).Row["MaDon"].ToString());
                    frmShowDonKH frm = new frmShowDonKH(source);
                    //frmShowDonKH frm = new frmShowDonKH(_cDonKH.getDonKHbyID(decimal.Parse(((DataRowView)gridViewDCBD.GetRow(gridViewDCBD.GetSelectedRows()[0])).Row["MaDon"].ToString())));
                    frm.ShowDialog();
                }
            }
        }

        private void gridViewDon_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            //for (int i = 0; i < view.RowCount; i++)
            //    if (bool.Parse(view.GetRowCellValue(i, "TXL").ToString()) == true)
            //    {
            //        view.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(view_CustomColumnDisplayText);
            //    }
        }

        void view_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            //if (e.Column.FieldName == "MaDon" && e.Value != null)
            //{
            //    e.DisplayText = "TXL" + e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            //}
        }

        #endregion

        #region gridViewKTXM

        private void gridViewKTXM_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaCTKTXM" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (e.Column.FieldName == "SoTien" && e.Value != null)
            {
                e.DisplayText = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void gridViewKTXM_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            GridView gridview = (GridView)gridControl.GetViewAt(new Point(e.X, e.Y));
            _CTRow = (DataRowView)gridview.GetRow(gridview.GetSelectedRows()[0]);
        }

        private void gridViewKTXM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F && _CTRow != null)
            {
                frmShowKTXM frm = new frmShowKTXM(decimal.Parse(_CTRow.Row["MaCTKTXM"].ToString()), true);
                if (frm.ShowDialog() == DialogResult.Cancel)
                {
                    _CTRow = null;
                }
            }
        }

        #endregion

        #region gridViewDCBD

        private void gridViewDCBD_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaDC" && e.Value != null)
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

        private void gridViewDCBD_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            if (view.GetRowCellDisplayText(0, "DieuChinh") == "Biến Động")
            {
                view.Columns["HoTen_BD"].Visible = true;
                //view.Columns["DiaChi"].Visible = true;
                view.Columns["DiaChi_BD"].Visible = true;
                view.Columns["MSThue"].Visible = true;
                view.Columns["MSThue_BD"].Visible = true;

                view.Columns["HoTen_BD"].VisibleIndex = 6;
                //view.Columns["DiaChi"].VisibleIndex = 6;
                view.Columns["DiaChi_BD"].VisibleIndex = 7;
                //view.Columns["MSThue"].VisibleIndex = 8;
                view.Columns["MSThue_BD"].VisibleIndex = 8;
                //view.Columns["GiaBieu"].VisibleIndex = 10;
                view.Columns["GiaBieu_BD"].VisibleIndex = 9;
                //view.Columns["DinhMuc"].VisibleIndex = 12;
                view.Columns["DinhMuc_BD"].VisibleIndex = 10;
                view.Columns["CreateBy"].VisibleIndex = 11;
            }
            if (view.GetRowCellDisplayText(0, "DieuChinh") == "Hóa Đơn")
            {
                view.Columns["TieuThu"].Visible = true;
                view.Columns["TieuThu_BD"].Visible = true;
                view.Columns["TongCong_Start"].Visible = true;
                view.Columns["TongCong_End"].Visible = true;
                view.Columns["TangGiam"].Visible = true;
                view.Columns["TongCong_BD"].Visible = true;
                view.Columns["ThongTin"].Visible = false;
                view.Columns["CreateBy"].VisibleIndex = 14;
            }
        }

        private void gridViewDCBD_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            GridView gridview = (GridView)gridControl.GetViewAt(new Point(e.X, e.Y));
            _CTRow = (DataRowView)gridview.GetRow(gridview.GetSelectedRows()[0]);
        }

        private void gridViewDCBD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F && _CTRow != null && _CTRow.Row["DieuChinh"].ToString() == "Biến Động")
            {
                frmShowDCBD frm = new frmShowDCBD(decimal.Parse(_CTRow.Row["MaDC"].ToString()), true);
                if (frm.ShowDialog() == DialogResult.Cancel)
                {
                    _CTRow = null;
                }
            }
            if (e.Control && e.KeyCode == Keys.F && _CTRow != null && _CTRow.Row["DieuChinh"].ToString() == "Hóa Đơn")
            {
                frmShowDCHD frm = new frmShowDCHD(decimal.Parse(_CTRow.Row["MaDC"].ToString()), true);
                if (frm.ShowDialog() == DialogResult.Cancel)
                {
                    _CTRow = null;
                }
            }
        }

        #endregion

        #region gridViewCHDB

        private void gridViewCHDB_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaCH" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (e.Column.FieldName == "SoPhieu")
                if (e.Value != null)
                    if (!string.IsNullOrEmpty(e.Value.ToString()))
                    {
                        e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
                    }
        }

        private void gridViewCHDB_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            GridView gridview = (GridView)gridControl.GetViewAt(new Point(e.X, e.Y));
            _CTRow = (DataRowView)gridview.GetRow(gridview.GetSelectedRows()[0]);
        }

        private void gridViewCHDB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F && _CTRow != null && _CTRow.Row["LoaiCat"].ToString() == "Cắt Hủy")
            {
                frmShowCHDB frm = new frmShowCHDB(decimal.Parse(_CTRow.Row["MaCH"].ToString()), true);
                if (frm.ShowDialog() == DialogResult.Cancel)
                {
                    _CTRow = null;
                }
            }
            if (e.Control && e.KeyCode == Keys.F && _CTRow != null && _CTRow.Row["LoaiCat"].ToString() == "Cắt Tạm")
            {
                frmShowCTDB frm = new frmShowCTDB(decimal.Parse(_CTRow.Row["MaCH"].ToString()), true);
                if (frm.ShowDialog() == DialogResult.Cancel)
                {
                    _CTRow = null;
                }
            }
        }

        #endregion

        #region gridViewTTTL

        private void gridViewTTTL_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaCTTTTL" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void gridViewTTTL_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            GridView gridview = (GridView)gridControl.GetViewAt(new Point(e.X, e.Y));
            _CTRow = (DataRowView)gridview.GetRow(gridview.GetSelectedRows()[0]);
        }

        private void gridViewTTTL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F && _CTRow != null)
            {
                frmTTTL frm = new frmTTTL(decimal.Parse(_CTRow.Row["MaCTTTTL"].ToString()));
                if (frm.ShowDialog() == DialogResult.Cancel)
                {
                    _CTRow = null;
                }
            }
        }

        #endregion

        #region gridViewBamChi

        private void gridViewBamChi_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaCTBC" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void gridViewBamChi_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            GridView gridview = (GridView)gridControl.GetViewAt(new Point(e.X, e.Y));
            _CTRow = (DataRowView)gridview.GetRow(gridview.GetSelectedRows()[0]);
        }

        private void gridViewBamChi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F && _CTRow != null)
            {
                frmShowBamChi frm = new frmShowBamChi(decimal.Parse(_CTRow.Row["MaCTBC"].ToString()), true);
                if (frm.ShowDialog() == DialogResult.Cancel)
                    _CTRow = null;
            }
        }

        #endregion

        #region gridViewDongNuoc

        private void gridViewDongNuoc_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaCTDN" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (e.Column.FieldName == "MaCTMN")
                if (e.Value != null)
                    if (!string.IsNullOrEmpty(e.Value.ToString()))
                    {
                        e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
                    }
        }

        private void gridViewDongNuoc_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            GridView gridview = (GridView)gridControl.GetViewAt(new Point(e.X, e.Y));
            _CTRow = (DataRowView)gridview.GetRow(gridview.GetSelectedRows()[0]);
        }

        private void gridViewDongNuoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F && _CTRow != null)
            {
                frmShowDongNuoc frm = new frmShowDongNuoc(decimal.Parse(_CTRow.Row["MaCTDN"].ToString()), true);
                if (frm.ShowDialog() == DialogResult.Cancel)
                    _CTRow = null;
            }
        }
        #endregion

        #region gridViewYeuCauCHDB

        private void gridViewYeuCauCHDB_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaYCCHDB" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void gridViewYeuCauCHDB_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            GridView gridview = (GridView)gridControl.GetViewAt(new Point(e.X, e.Y));
            _CTRow = (DataRowView)gridview.GetRow(gridview.GetSelectedRows()[0]);
        }

        private void gridViewYeuCauCHDB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F && _CTRow != null)
            {
                frmShowYCCHDB frm = new frmShowYCCHDB(decimal.Parse(_CTRow.Row["MaYCCHDB"].ToString()), true);
                if (frm.ShowDialog() == DialogResult.Cancel)
                    _CTRow = null;
            }
        }

        #endregion

        #region gridViewKTXM_TXL

        private void gridViewKTXM_TXL_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaCTKTXM" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (e.Column.FieldName == "SoTien" && e.Value != null)
            {
                e.DisplayText = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void gridViewKTXM_TXL_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            GridView gridview = (GridView)gridControl.GetViewAt(new Point(e.X, e.Y));
            _CTRow = (DataRowView)gridview.GetRow(gridview.GetSelectedRows()[0]);
        }

        private void gridViewKTXM_TXL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F && _CTRow != null)
            {
                frmShowKTXM frm = new frmShowKTXM(decimal.Parse(_CTRow.Row["MaCTKTXM"].ToString()), true);
                if (frm.ShowDialog() == DialogResult.Cancel)
                {
                    _CTRow = null;
                }
            }
        }

        #endregion

        #region gridViewCHDB_TXL

        private void gridViewCHDB_TXL_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaCH" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (e.Column.FieldName == "SoPhieu")
                if (e.Value != null)
                    if (!string.IsNullOrEmpty(e.Value.ToString()))
                    {
                        e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
                    }
        }

        private void gridViewCHDB_TXL_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            GridView gridview = (GridView)gridControl.GetViewAt(new Point(e.X, e.Y));
            _CTRow = (DataRowView)gridview.GetRow(gridview.GetSelectedRows()[0]);
        }

        private void gridViewCHDB_TXL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F && _CTRow != null && _CTRow.Row["LoaiCat"].ToString() == "Cắt Hủy")
            {
                frmShowCHDB frm = new frmShowCHDB(decimal.Parse(_CTRow.Row["MaCH"].ToString()), true);
                if (frm.ShowDialog() == DialogResult.Cancel)
                {
                    _CTRow = null;
                }
            }
            if (e.Control && e.KeyCode == Keys.F && _CTRow != null && _CTRow.Row["LoaiCat"].ToString() == "Cắt Tạm")
            {
                frmShowCTDB frm = new frmShowCTDB(decimal.Parse(_CTRow.Row["MaCH"].ToString()), true);
                if (frm.ShowDialog() == DialogResult.Cancel)
                {
                    _CTRow = null;
                }
            }
        }

        #endregion

        #region gridViewTTTL_TXL

        private void gridViewTTTTL_TXL_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaCTTTTL" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void gridViewTTTTL_TXL_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            GridView gridview = (GridView)gridControl.GetViewAt(new Point(e.X, e.Y));
            _CTRow = (DataRowView)gridview.GetRow(gridview.GetSelectedRows()[0]);
        }

        private void gridViewTTTTL_TXL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F && _CTRow != null)
            {
                frmTTTL frm = new frmTTTL(decimal.Parse(_CTRow.Row["MaCTTTTL"].ToString()));
                if (frm.ShowDialog() == DialogResult.Cancel)
                    _CTRow = null;
            }
        }

        #endregion

        #region gridViewDCBD_TXL

        private void gridViewDCBD_TXL_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaDC" && e.Value != null)
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

        private void gridViewDCBD_TXL_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            if (view.GetRowCellDisplayText(0, "DieuChinh") == "Biến Động")
            {
                view.Columns["HoTen_BD"].Visible = true;
                //view.Columns["DiaChi"].Visible = true;
                view.Columns["DiaChi_BD"].Visible = true;
                view.Columns["MSThue"].Visible = true;
                view.Columns["MSThue_BD"].Visible = true;

                view.Columns["HoTen_BD"].VisibleIndex = 6;
                //view.Columns["DiaChi"].VisibleIndex = 6;
                view.Columns["DiaChi_BD"].VisibleIndex = 7;
                //view.Columns["MSThue"].VisibleIndex = 8;
                view.Columns["MSThue_BD"].VisibleIndex = 8;
                //view.Columns["GiaBieu"].VisibleIndex = 10;
                view.Columns["GiaBieu_BD"].VisibleIndex = 9;
                //view.Columns["DinhMuc"].VisibleIndex = 12;
                view.Columns["DinhMuc_BD"].VisibleIndex = 10;
                view.Columns["CreateBy"].VisibleIndex = 11;
            }
            if (view.GetRowCellDisplayText(0, "DieuChinh") == "Hóa Đơn")
            {
                view.Columns["TieuThu"].Visible = true;
                view.Columns["TieuThu_BD"].Visible = true;
                view.Columns["TongCong_Start"].Visible = true;
                view.Columns["TongCong_End"].Visible = true;
                view.Columns["TangGiam"].Visible = true;
                view.Columns["TongCong_BD"].Visible = true;
                view.Columns["ThongTin"].Visible = false;
                view.Columns["CreateBy"].VisibleIndex = 14;
            }
        }

        private void gridViewDCBD_TXL_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            GridView gridview = (GridView)gridControl.GetViewAt(new Point(e.X, e.Y));
            _CTRow = (DataRowView)gridview.GetRow(gridview.GetSelectedRows()[0]);
        }

        private void gridViewDCBD_TXL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F && _CTRow != null && _CTRow.Row["DieuChinh"].ToString() == "Biến Động")
            {
                frmShowDCBD frm = new frmShowDCBD(decimal.Parse(_CTRow.Row["MaDC"].ToString()), true);
                if (frm.ShowDialog() == DialogResult.Cancel)
                {
                    _CTRow = null;
                }
            }
            if (e.Control && e.KeyCode == Keys.F && _CTRow != null && _CTRow.Row["DieuChinh"].ToString() == "Hóa Đơn")
            {
                frmShowDCHD frm = new frmShowDCHD(decimal.Parse(_CTRow.Row["MaDC"].ToString()), true);
                if (frm.ShowDialog() == DialogResult.Cancel)
                {
                    _CTRow = null;
                }
            }
        }

        #endregion

        #region gridViewBamChi_TXL

        private void gridViewBamChi_TXL_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaCTBC" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void gridViewBamChi_TXL_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            GridView gridview = (GridView)gridControl.GetViewAt(new Point(e.X, e.Y));
            _CTRow = (DataRowView)gridview.GetRow(gridview.GetSelectedRows()[0]);
        }

        private void gridViewBamChi_TXL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F && _CTRow != null)
            {
                frmShowBamChi frm = new frmShowBamChi(decimal.Parse(_CTRow.Row["MaCTBC"].ToString()), true);
                if (frm.ShowDialog() == DialogResult.Cancel)
                    _CTRow = null;
            }
        }

        #endregion

        #region gridViewDongNuoc_TXL

        private void gridViewDongNuoc_TXL_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaCTDN" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (e.Column.FieldName == "MaCTMN")
                if (e.Value != null)
                    if (!string.IsNullOrEmpty(e.Value.ToString()))
                    {
                        e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
                    }
        }

        private void gridViewDongNuoc_TXL_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            GridView gridview = (GridView)gridControl.GetViewAt(new Point(e.X, e.Y));
            _CTRow = (DataRowView)gridview.GetRow(gridview.GetSelectedRows()[0]);
        }

        private void gridViewDongNuoc_TXL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F && _CTRow != null)
            {
                frmShowDongNuoc frm = new frmShowDongNuoc(decimal.Parse(_CTRow.Row["MaCTDN"].ToString()), true);
                if (frm.ShowDialog() == DialogResult.Cancel)
                    _CTRow = null;
            }
        }
        #endregion

        #region gridViewYeuCauCHDB_TXL

        private void gridViewYeuCauCHDB_TXL_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaYCCHDB" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void gridViewYeuCauCHDB_TXL_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            GridView gridview = (GridView)gridControl.GetViewAt(new Point(e.X, e.Y));
            _CTRow = (DataRowView)gridview.GetRow(gridview.GetSelectedRows()[0]);
        }

        private void gridViewYeuCauCHDB_TXL_KeyDown(object sender, KeyEventArgs e)
        {
            frmShowYCCHDB frm = new frmShowYCCHDB(decimal.Parse(_CTRow.Row["MaYCCHDB"].ToString()), true);
            if (frm.ShowDialog() == DialogResult.Cancel)
                _CTRow = null;
        }

        #endregion

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (gridViewDon.RowCount > 0)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow[] childRows;


                foreach (DataRow itemRow in dt.Rows)
                {
                    foreach (DataRelation itemRelation in dt.ChildRelations)
                    {
                        childRows = itemRow.GetChildRows(itemRelation);
                        if (childRows.Count() > 0)
                            foreach (DataRow itemChildRow in childRows)
                            {
                                DataRow dr = dsBaoCao.Tables["KetQuaTimKiem"].NewRow();
                                dr["ToXuLy"] = itemRow["ToXuLy"];
                                dr["MaDon"] = itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-");
                                dr["LoaiDon"] = itemRow["TenLD"];
                                dr["NgayNhan"] = itemRow["CreateDate"];
                                dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                                dr["HoTen"] = itemRow["HoTen"];
                                dr["DiaChi"] = itemRow["DiaChi"];
                                dr["NoiDung"] = itemRow["NoiDung"];
                                dr["LoaiXuLy"] = itemRelation.RelationName;

                                dr["DanhBoXuLy"] = itemChildRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                                dr["HoTenXuLy"] = itemChildRow["HoTen"];
                                dr["DiaChiXuLy"] = itemChildRow["DiaChi"];

                                dr["LoaiChiTietXuLy"] = "";
                                dr["Ma"] = "";

                                if (itemRelation.RelationName.Contains("Kiểm Tra"))
                                {
                                    dr["NgayLapXuLy"] = itemChildRow["NgayKTXM"];
                                    dr["NoiDungXuLy"] = itemChildRow["NoiDungKiemTra"];
                                    dr["NguoiLapXuLy"] = itemChildRow["CreateBy"];
                                }
                                if (itemRelation.RelationName.Contains("Bấm Chì"))
                                {
                                    dr["NgayLapXuLy"] = itemChildRow["NgayBC"];
                                    dr["NoiDungXuLy"] = "Mã Chì: " + itemChildRow["MaSoBC"] + ", Thực Hiện: " + itemChildRow["TheoYeuCau"];
                                    dr["NguoiLapXuLy"] = itemChildRow["CreateBy"];
                                }
                                if (itemRelation.RelationName.Contains("Tạm/Hủy"))
                                {
                                    dr["LoaiChiTietXuLy"] = itemChildRow["LoaiCat"];
                                    dr["Ma"] = itemChildRow["MaCH"].ToString().Insert(itemChildRow["MaCH"].ToString().Length - 2, "-");
                                    dr["NgayLapXuLy"] = itemChildRow["CreateDate"];
                                    dr["NoiDungXuLy"] = itemChildRow["LyDo"] + ", " + itemChildRow["GhiChuLyDo"];
                                    if (itemChildRow["DaLapPhieu"].ToString() == "True")
                                    {
                                        CCHDB cCHDB = new CCHDB();
                                        YeuCauCHDB ycchdb = cCHDB.getYeuCauCHDbyID(decimal.Parse(itemChildRow["SoPhieu"].ToString()));
                                        dr["NoiDungXuLy"] += ", Đã Lập Phiếu YCCH số: " + itemChildRow["SoPhieu"].ToString().Insert(itemChildRow["SoPhieu"].ToString().Length - 2, "-") + ", Ngày Lập: " + itemChildRow["NgayLapPhieu"] + ", Hiệu Lực Kỳ: " + ycchdb.HieuLucKy;
                                    }
                                }
                                if (itemRelation.RelationName.Contains("Thảo Thư"))
                                {
                                    dr["Ma"] = itemChildRow["MaCTTTTL"].ToString().Insert(itemChildRow["MaCTTTTL"].ToString().Length - 2, "-");
                                    dr["NgayLapXuLy"] = itemChildRow["CreateDate"];
                                    dr["NoiDungXuLy"] = itemChildRow["VeViec"];
                                }
                                if (itemRelation.RelationName.Contains("Điều Chỉnh"))
                                {
                                    dr["LoaiChiTietXuLy"] = itemChildRow["DieuChinh"];
                                    dr["Ma"] = itemChildRow["MaDC"].ToString().Insert(itemChildRow["MaDC"].ToString().Length - 2, "-");
                                    dr["NgayLapXuLy"] = itemChildRow["CreateDate"];
                                    dr["NguoiLapXuLy"] = itemChildRow["CreateBy"];

                                    if (itemChildRow["DieuChinh"].ToString() == "Biến Động")
                                    {
                                        string s = "";
                                        if (!string.IsNullOrEmpty(itemChildRow["HoTen_BD"].ToString()))
                                            s += "Khách Hàng: " + itemChildRow["HoTen_BD"];
                                        if (!string.IsNullOrEmpty(itemChildRow["DiaChi_BD"].ToString()))
                                            s += ", Địa Chỉ: " + itemChildRow["DiaChi_BD"];
                                        if (!string.IsNullOrEmpty(itemChildRow["MSThue_BD"].ToString()))
                                            s += ", MST: " + itemChildRow["MSThue_BD"];
                                        if (!string.IsNullOrEmpty(itemChildRow["GiaBieu_BD"].ToString()))
                                            s += ", GB: " + itemChildRow["GiaBieu_BD"];
                                        if (!string.IsNullOrEmpty(itemChildRow["DinhMuc_BD"].ToString()))
                                            s += ", ĐM: " + itemChildRow["DinhMuc_BD"];
                                        dr["NoiDungXuLy"] = s;
                                    }
                                    else
                                    {
                                        dr["NoiDungXuLy"] = itemChildRow["TangGiam"] + " " + itemChildRow["TongCong_BD"];
                                    }
                                }
                                dsBaoCao.Tables["KetQuaTimKiem"].Rows.Add(dr);
                            }
                    }
                }
                if (cmbTimTheo.SelectedItem.ToString() == "Mã Đơn")
                {
                    rptKetQuaTimKiembyMaDon rpt = new rptKetQuaTimKiembyMaDon();
                    rpt.SetDataSource(dsBaoCao);
                    frmShowBaoCao frm = new frmShowBaoCao(rpt);
                    frm.ShowDialog();
                }
                else
                    if (cmbTimTheo.SelectedItem.ToString() == "Danh Bộ")
                    {
                        rptKetQuaTimKiembyDanhBo rpt = new rptKetQuaTimKiembyDanhBo();
                        rpt.SetDataSource(dsBaoCao);
                        frmShowBaoCao frm = new frmShowBaoCao(rpt);
                        frm.ShowDialog();
                    }
            }
            else
                MessageBox.Show("Không có đơn nào", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
    }

}
