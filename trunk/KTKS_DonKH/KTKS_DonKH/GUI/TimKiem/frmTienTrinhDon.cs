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

namespace KTKS_DonKH.GUI.TimKiem
{
    public partial class frmTienTrinhDon : Form
    {
        CTimKiem _cTimKiem = new CTimKiem();
        DataRowView _CTRow = null;

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
            gridControl.LevelTree.Nodes.Add("Chi Tiết Cắt Hủy Danh Bộ", gridViewCHDB);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Thảo Thư Trả Lời", gridViewTTTL);
            ///Tổ Xử Lý
            gridControl.LevelTree.Nodes.Add("Chi Tiết Kiểm Tra Xác Minh TXL", gridViewKTXM_TXL);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Điều Chỉnh Biến Động TXL", gridViewDCBD_TXL);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Cắt Hủy Danh Bộ TXL", gridViewCHDB_TXL);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Thảo Thư Trả Lời TXL", gridViewTTTTL_TXL);
        }

        private void txtNoiDungTimKiem_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtNoiDungTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    switch (cmbTimTheo.SelectedItem.ToString())
                    {
                        case "Mã Đơn":
                            ///Nếu Đơn thuộc Tổ Xử Lý
                            if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                            {
                                gridControl.DataSource = _cTimKiem.GetTienTrinhbyMaDon_TXL(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", ""))).Tables["Don"];
                            }
                            ///Nếu Đơn thuộc Tổ Khách Hàng
                            else
                            {
                                gridControl.DataSource = _cTimKiem.GetTienTrinhbyMaDon(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", ""))).Tables["Don"];
                            }
                            break;
                        case "Danh Bộ":
                            gridControl.DataSource = _cTimKiem.GetTienTrinhbyDanhBo(txtNoiDungTimKiem.Text.Trim()).Tables["Don"];
                            break;
                        case "Họ Tên":
                            gridControl.DataSource = _cTimKiem.GetTienTrinhbyHoTen(txtNoiDungTimKiem.Text.Trim()).Tables["Don"];
                            break;
                        case "Địa Chỉ":
                            gridControl.DataSource = _cTimKiem.GetTienTrinhbyDiaChi(txtNoiDungTimKiem.Text.Trim()).Tables["Don"];
                            break;
                    }
                }
                catch (Exception)
                {

                }
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
                Dictionary<string, string> source = new Dictionary<string, string>();
                source.Add("Action", "View");
                source.Add("TimKiem", "True");
                source.Add("MaDon", ((DataRowView)gridViewDon.GetRow(gridViewDon.GetSelectedRows()[0])).Row["MaDon"].ToString());
                frmShowDonKH frm = new frmShowDonKH(source);
                //frmShowDonKH frm = new frmShowDonKH(_cDonKH.getDonKHbyID(decimal.Parse(((DataRowView)gridViewDCBD.GetRow(gridViewDCBD.GetSelectedRows()[0])).Row["MaDon"].ToString())));
                frm.ShowDialog();
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

                view.Columns["HoTen_BD"].VisibleIndex = 5;
                view.Columns["DiaChi"].VisibleIndex = 6;
                view.Columns["DiaChi_BD"].VisibleIndex = 7;
                view.Columns["MSThue"].VisibleIndex = 8;
                view.Columns["MSThue_BD"].VisibleIndex = 9;
                view.Columns["GiaBieu"].VisibleIndex = 10;
                view.Columns["GiaBieu_BD"].VisibleIndex = 11;
                view.Columns["DinhMuc"].VisibleIndex = 12;
                view.Columns["DinhMuc_BD"].VisibleIndex = 13;
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
                frmShowCTDB frm = new frmShowCTDB(decimal.Parse(_CTRow.Row["MaCH"].ToString()), true);
                if (frm.ShowDialog() == DialogResult.Cancel)
                {
                    _CTRow = null;
                }
            }
            if (e.Control && e.KeyCode == Keys.F && _CTRow != null && _CTRow.Row["LoaiCat"].ToString() == "Cắt Tạm")
            {
                frmShowCHDB frm = new frmShowCHDB(decimal.Parse(_CTRow.Row["MaCH"].ToString()), true);
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
                frmShowTTTL frm = new frmShowTTTL(decimal.Parse(_CTRow.Row["MaCTKTXM"].ToString()));
                if (frm.ShowDialog() == DialogResult.Cancel)
                {
                    _CTRow = null;
                }
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
                frmShowCTDB frm = new frmShowCTDB(decimal.Parse(_CTRow.Row["MaCH"].ToString()), true);
                if (frm.ShowDialog() == DialogResult.Cancel)
                {
                    _CTRow = null;
                }
            }
            if (e.Control && e.KeyCode == Keys.F && _CTRow != null && _CTRow.Row["LoaiCat"].ToString() == "Cắt Tạm")
            {
                frmShowCHDB frm = new frmShowCHDB(decimal.Parse(_CTRow.Row["MaCH"].ToString()), true);
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
                frmShowTTTL frm = new frmShowTTTL(decimal.Parse(_CTRow.Row["MaCTTTTL"].ToString()), true);
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

                view.Columns["HoTen_BD"].VisibleIndex = 5;
                view.Columns["DiaChi"].VisibleIndex = 6;
                view.Columns["DiaChi_BD"].VisibleIndex = 7;
                view.Columns["MSThue"].VisibleIndex = 8;
                view.Columns["MSThue_BD"].VisibleIndex = 9;
                view.Columns["GiaBieu"].VisibleIndex = 10;
                view.Columns["GiaBieu_BD"].VisibleIndex = 11;
                view.Columns["DinhMuc"].VisibleIndex = 12;
                view.Columns["DinhMuc_BD"].VisibleIndex = 13;
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

        
    }
}
