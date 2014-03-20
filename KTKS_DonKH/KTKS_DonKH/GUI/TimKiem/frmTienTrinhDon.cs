using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.TimKiem;

namespace KTKS_DonKH.GUI.TimKiem
{
    public partial class frmTienTrinhDon : Form
    {
        CTimKiem _cTimKiem = new CTimKiem();

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
        }

        private void txtNoiDungTimKiem_TextChanged(object sender, EventArgs e)
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

                        break;
                }
            }
            catch (Exception)
            {

            }
        }

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
                view.Columns["DiaChi"].Visible = true;
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

        private void gridViewDon_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaDon" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            } 
        }

        private void gridViewKTXM_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaCTKTXM" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            } 
        }

        private void gridViewCHDB_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaCH" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            } 
        }

        private void gridViewTTTL_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaCTTTTL" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            } 
        }

       
    }
}
