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

namespace KTKS_DonKH.GUI.BamChi
{
    public partial class frmDSBamChi : Form
    {
        CBamChi _cBamChi = new CBamChi();
        DataRowView _CTRow = null;

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

        }

        private void radDaDuyet_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radDSBamChi_CheckedChanged(object sender, EventArgs e)
        {

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
                frmShowNhapBamChi frm = new frmShowNhapBamChi(decimal.Parse(_CTRow.Row["MaCTBC"].ToString()));
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (CTaiKhoan.RoleQLBamChi_Xem || CTaiKhoan.RoleQLBamChi_CapNhat)
                        DSDon_BS.DataSource = _cKTXM.LoadDSKTXMDaDuyet().Tables["KTXM"];
                }
            }
        }

        #endregion
    }
}
