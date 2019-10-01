using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.TimKiem;
using KTKS_DonKH.GUI.ToKhachHang;
using DevExpress.XtraGrid.Views.Grid;
using KTKS_DonKH.GUI.KiemTraXacMinh;
using KTKS_DonKH.GUI.ThuTraLoi;
using KTKS_DonKH.GUI.DieuChinhBienDong;
using KTKS_DonKH.GUI.CatHuyDanhBo;
using KTKS_DonKH.GUI.ToXuLy;
using KTKS_DonKH.GUI.BamChi;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.TimKiem;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.CatHuyDanhBo;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.GUI.DongNuoc;
using KTKS_DonKH.DAL;
using KTKS_DonKH.GUI.ToBamChi;
using KTKS_DonKH.GUI.TruyThu;
using KTKS_DonKH.GUI.ThuMoi;
using KTKS_DonKH.GUI.DonTu;

namespace KTKS_DonKH.GUI.TimKiem
{
    public partial class frmTienTrinhDon : Form
    {
        CTimKiem _cTimKiem = new CTimKiem();
        CThuTien _cThuTien = new CThuTien();
        CDHN _cDocSo = new CDHN();
        DataRowView _CTRow = null;
        DataTable dt = new DataTable();
        //System.IO.StreamWriter _log;

        public frmTienTrinhDon()
        {
            InitializeComponent();
        }

        private void frmTienTrinhDon_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;

            cmbTimTheo.SelectedIndex = 0;
            gridControl.LevelTree.Nodes.Add("Chi Tiết Kiểm Tra Xác Minh", gridViewKTXM);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Bấm Chì", gridViewBamChi);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Đóng Nước", gridViewDongNuoc);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Điều Chỉnh Biến Động", gridViewDCBD);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Cắt Tạm/Hủy Danh Bộ", gridViewCHDB);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Phiếu Hủy Danh Bộ", gridViewPhieuCHDB);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Thảo Thư Trả Lời", gridViewTTTL);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Gian Lận", gridViewGianLan);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Truy Thu", gridViewTruyThu);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Tờ Trình", gridViewToTrinh);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Thư Mời", gridViewThuMoi);
            gridControl.LevelTree.Nodes.Add("Chi Tiết Tiến Trình", gridViewTienTrinh);
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
                //_log = System.IO.File.AppendText("\\\\192.168.90.9\\BaoBao$\\TrungTamKhachHang\\log.txt");
                //DateTime date = DateTime.Now;
                
                switch (cmbTimTheo.SelectedItem.ToString())
                {
                    case "Mã Đơn":
                        if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TKH"))
                            dt = _cTimKiem.GetTienTrinh_DonTKH(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", ""))).Tables["DonTu"];
                    else
                        if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                            dt = _cTimKiem.GetTienTrinh_DonTXL(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", ""))).Tables["DonTu"];
                        else
                            if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TBC"))
                                dt = _cTimKiem.GetTienTrinh_DonTBC(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", ""))).Tables["DonTu"];
                            else
                            {
                                if (txtNoiDungTimKiem.Text.Trim().Contains("."))
                                {
                                    string[] MaDons = txtNoiDungTimKiem.Text.Trim().Split('.');
                                    dt = _cTimKiem.GetTienTrinh_DonTu(int.Parse(MaDons[0]), int.Parse(MaDons[1])).Tables["DonTu"];
                                }
                                else
                                    dt = _cTimKiem.GetTienTrinh_DonTu(int.Parse(txtNoiDungTimKiem.Text.Trim())).Tables["DonTu"];
                            }
                        break;
                    case "Danh Bộ":
                        dt = _cTimKiem.getTienTrinhByDanhBo(txtNoiDungTimKiem.Text.Trim().Replace(" ","")).Tables["DonTu"];
                        break;
                    case "Họ Tên":
                        dt = _cTimKiem.getTienTrinhByHoTen(txtNoiDungTimKiem.Text.Trim()).Tables["DonTu"];
                        break;
                    case "Địa Chỉ":
                        dt = _cTimKiem.getTienTrinhByDiaChi(txtNoiDungTimKiem.Text.Trim()).Tables["DonTu"];
                        break;
                    case "Niêm Chì":
                        dt = _cTimKiem.getTienTrinhByNiemChi(int.Parse(txtNoiDungTimKiem.Text.Trim())).Tables["DonTu"];
                        break;
                    case "Số Chứng Từ":
                        dt = _cTimKiem.getTienTrinhBySoChungTu(txtNoiDungTimKiem.Text.Trim()).Tables["DonTu"];
                        break;
                }
                //TimeSpan diff = DateTime.Now - date;
                //_log.WriteLine("lấy lịch sử khiếu nại " + diff.TotalSeconds.ToString());
                //_log.Close();
                //_log.Dispose();
                gridControl.DataSource = dt;
            }
            catch (Exception)
            {
               
            }
        }

        #region gridViewDon

        private void gridViewDon_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            //if (e.Column.FieldName == "MaDon" && e.Value != null)
            //{
            //    e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            //}
        }

        private void gridViewDon_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridViewDon.RowCount > 0 && e.Control && e.KeyCode == Keys.F)
            {
                if (((DataRowView)gridViewDon.GetRow(gridViewDon.GetSelectedRows()[0])).Row["MaDon"].ToString().ToUpper().Contains("TKH"))
                {
                    frmNhanDonTKH frm = new frmNhanDonTKH(decimal.Parse(((DataRowView)gridViewDon.GetRow(gridViewDon.GetSelectedRows()[0])).Row["MaDon"].ToString().Substring(3)));
                    frm.ShowDialog();
                }
                else
                    if (((DataRowView)gridViewDon.GetRow(gridViewDon.GetSelectedRows()[0])).Row["MaDon"].ToString().ToUpper().Contains("TXL"))
                    {
                        frmNhanDonTXL frm = new frmNhanDonTXL(decimal.Parse(((DataRowView)gridViewDon.GetRow(gridViewDon.GetSelectedRows()[0])).Row["MaDon"].ToString().Substring(3)));
                        frm.ShowDialog();
                    }
                    else
                        if (((DataRowView)gridViewDon.GetRow(gridViewDon.GetSelectedRows()[0])).Row["MaDon"].ToString().ToUpper().Contains("TBC"))
                        {
                            frmNhanDonTBC frm = new frmNhanDonTBC(decimal.Parse(((DataRowView)gridViewDon.GetRow(gridViewDon.GetSelectedRows()[0])).Row["MaDon"].ToString().Substring(3)));
                            frm.ShowDialog();
                        }
                        else
                        {
                            string MaDon = ((DataRowView)gridViewDon.GetRow(gridViewDon.GetSelectedRows()[0])).Row["MaDon"].ToString();

                            if (MaDon.Contains(".") == true)
                                MaDon = MaDon.Substring(0,MaDon.IndexOf("."));

                            frmNhanDonTu frm = new frmNhanDonTu(int.Parse(MaDon));
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
                frmKTXM frm = new frmKTXM(decimal.Parse(_CTRow.Row["MaCTKTXM"].ToString()));
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
                frmBamChi frm = new frmBamChi(decimal.Parse(_CTRow.Row["MaCTBC"].ToString()));
                if (frm.ShowDialog() == DialogResult.Cancel)
                    _CTRow = null;
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
                frmDCBD frm = new frmDCBD(decimal.Parse(_CTRow.Row["MaDC"].ToString()));
                if (frm.ShowDialog() == DialogResult.Cancel)
                {
                    _CTRow = null;
                }
            }
            if (e.Control && e.KeyCode == Keys.F && _CTRow != null && _CTRow.Row["DieuChinh"].ToString() == "Hóa Đơn")
            {
                frmDCHD frm = new frmDCHD(decimal.Parse(_CTRow.Row["MaDC"].ToString()));
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
                frmCHDB frm = new frmCHDB(decimal.Parse(_CTRow.Row["MaCH"].ToString()));
                if (frm.ShowDialog() == DialogResult.Cancel)
                {
                    _CTRow = null;
                }
            }
            if (e.Control && e.KeyCode == Keys.F && _CTRow != null && _CTRow.Row["LoaiCat"].ToString() == "Cắt Tạm")
            {
                frmCTDB frm = new frmCTDB(decimal.Parse(_CTRow.Row["MaCH"].ToString()));
                if (frm.ShowDialog() == DialogResult.Cancel)
                {
                    _CTRow = null;
                }
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
                frmDongNuoc frm = new frmDongNuoc(decimal.Parse(_CTRow.Row["MaCTDN"].ToString()));
                if (frm.ShowDialog() == DialogResult.Cancel)
                    _CTRow = null;
            }
        }
        #endregion

        #region gridViewPhieuCHDB

        private void gridViewPhieuCHDB_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaYCCHDB" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void gridViewPhieuCHDB_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            GridView gridview = (GridView)gridControl.GetViewAt(new Point(e.X, e.Y));
            _CTRow = (DataRowView)gridview.GetRow(gridview.GetSelectedRows()[0]);
        }

        private void gridViewPhieuCHDB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F && _CTRow != null)
            {
                frmYCCHDB frm = new frmYCCHDB(decimal.Parse(_CTRow.Row["MaYCCHDB"].ToString()));
                if (frm.ShowDialog() == DialogResult.Cancel)
                    _CTRow = null;
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

        #region girdViewGianLan

        private void gridViewGianLan_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            //if (e.Column.FieldName == "ID" && e.Value != null)
            //{
            //    e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            //}
        }

        private void gridViewGianLan_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            GridView gridview = (GridView)gridControl.GetViewAt(new Point(e.X, e.Y));
            _CTRow = (DataRowView)gridview.GetRow(gridview.GetSelectedRows()[0]);
        }

        private void gridViewGianLan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F && _CTRow != null)
            {
                frmGianLan frm = new frmGianLan(int.Parse(_CTRow.Row["ID"].ToString()));
                if (frm.ShowDialog() == DialogResult.Cancel)
                {
                    _CTRow = null;
                }
            }
        }

        #endregion

        #region girdViewTruyThu

        private void gridViewTruyThu_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "IDCT" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (e.Column.FieldName == "Tongm3BinhQuan" && e.Value != null)
            {
                e.DisplayText = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (e.Column.FieldName == "TongTien" && e.Value != null)
            {
                e.DisplayText = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void gridViewTruyThu_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            GridView gridview = (GridView)gridControl.GetViewAt(new Point(e.X, e.Y));
            _CTRow = (DataRowView)gridview.GetRow(gridview.GetSelectedRows()[0]);
        }

        private void gridViewTruyThu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F && _CTRow != null)
            {
                frmTruyThuTienNuoc frm = new frmTruyThuTienNuoc(int.Parse(_CTRow.Row["IDCT"].ToString()));
                if (frm.ShowDialog() == DialogResult.Cancel)
                {
                    _CTRow = null;
                }
            }
        }

        #endregion

        #region girdViewToTrinh

        private void gridViewToTrinh_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "IDCT" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void gridViewToTrinh_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            GridView gridview = (GridView)gridControl.GetViewAt(new Point(e.X, e.Y));
            _CTRow = (DataRowView)gridview.GetRow(gridview.GetSelectedRows()[0]);
        }

        private void gridViewToTrinh_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Control && e.KeyCode == Keys.F && _CTRow != null)
            //{
            //    frmToTrinh frm = new frmToTrinh(decimal.Parse(_CTRow.Row["IDCT"].ToString()));
            //    if (frm.ShowDialog() == DialogResult.Cancel)
            //    {
            //        _CTRow = null;
            //    }
            //}
        }

        #endregion

        #region gridViewThuMoi

        private void gridViewThuMoi_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "SoPhieu" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void gridViewThuMoi_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            GridView gridview = (GridView)gridControl.GetViewAt(new Point(e.X, e.Y));
            _CTRow = (DataRowView)gridview.GetRow(gridview.GetSelectedRows()[0]);
        }

        private void gridViewThuMoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F && _CTRow != null)
            {
                frmThaoThuMoi frm = new frmThaoThuMoi(int.Parse(_CTRow.Row["IDCT"].ToString()));
                if (frm.ShowDialog() == DialogResult.Cancel)
                {
                    _CTRow = null;
                }
            }
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
                                //dr["ToXuLy"] = itemRow["ToXuLy"];
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
                                        CHDB_Phieu ycchdb = cCHDB.GetPhieuHuy(decimal.Parse(itemChildRow["SoPhieu"].ToString()));
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtDanhBo.Text = "";
            txtHoTen.Text = "";
            txtSoNha.Text = "";
            txtTenDuong.Text = "";
            txtSoThanDHN.Text = "";
        }

        private void btnTimKiemTTKH_Click(object sender, EventArgs e)
        {
            if (txtSoThanDHN.Text.Trim() != "")
                dgvHoaDon.DataSource = _cDocSo.GetDS(txtSoThanDHN.Text.Trim());
            else
                if (!string.IsNullOrEmpty(txtDanhBo.Text.Trim().Replace(" ", "")))
                    dgvHoaDon.DataSource = _cThuTien.GetDSTimKiem(txtDanhBo.Text.Trim().Replace(" ", ""),"");
                else
                    dgvHoaDon.DataSource = _cThuTien.GetDSTimKiemTTKH(txtHoTen.Text.Trim(), txtSoNha.Text.Trim(), txtTenDuong.Text.Trim());
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "DanhBo_TTKH" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnTimKiemTTKH.PerformClick();
        }

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnTimKiemTTKH.PerformClick();
        }

        private void txtSoNha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnTimKiemTTKH.PerformClick();
        }

        private void txtTenDuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnTimKiemTTKH.PerformClick();
        }



    }

}
