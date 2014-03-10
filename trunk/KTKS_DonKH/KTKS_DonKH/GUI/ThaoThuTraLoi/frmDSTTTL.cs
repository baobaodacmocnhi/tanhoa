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
using KTKS_DonKH.DAL.ThaoThuTraLoi;
using KTKS_DonKH.GUI.KhachHang;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.BaoCao.ThaoThuTraLoi;
using KTKS_DonKH.BaoCao;

namespace KTKS_DonKH.GUI.ThaoThuTraLoi
{
    public partial class frmDSTTTL : Form
    {
        CChuyenDi _cChuyenDi = new CChuyenDi();
        CTTTL _cTTTL = new CTTTL();
        CDonKH _cDonKH = new CDonKH();
        CKTXM _cKTXM = new CKTXM();
        DataTable DSTTTL_Edited = new DataTable();
        DataRowView _CTRow = null;
        BindingSource DSTTTL_BS;

        public frmDSTTTL()
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

        private void frmDSTTTL_Load(object sender, EventArgs e)
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
            myLookUpEdit.DataSource = _cChuyenDi.LoadDSChuyenDi("TTTL");
            myLookUpEdit.DisplayMember = "NoiChuyenDi";
            myLookUpEdit.ValueMember = "MaChuyen";
            ///Add LookUpEdit vào GridControl
            ((GridView)gridControl.MainView).Columns["MaChuyen"].ColumnEdit = myLookUpEdit;

            radDSThu.Checked = true;

            gridControl.LevelTree.Nodes.Add("Chi Tiết Thảo Thư Trả Lời", gridViewCTTTTL);

            dgvDSThu.AutoGenerateColumns = false;
            dgvDSThu.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSThu.Font, FontStyle.Bold);
            dgvDSThu.Location = gridControl.Location;

            dateTimKiem.Location = txtNoiDungTimKiem.Location;
        }

        private void radDaDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radDaDuyet.Checked)
            {
                DSTTTL_BS = new BindingSource();
                DSTTTL_BS.DataSource = _cTTTL.LoadDSTTTLDaDuyet().Tables["TTTL"];
                gridControl.DataSource = DSTTTL_BS;

                gridControl.Visible = true;
                dgvDSThu.Visible = false;
                //btnLuu.Enabled = true;
                //DSTTTL_Edited = new DataTable();
                chkSelectAll.Visible = false;
            }
        }

        private void radChuaDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radChuaDuyet.Checked)
            {
                DSTTTL_BS = new BindingSource();
                DSTTTL_BS.DataSource = _cTTTL.LoadDSTTTLChuaDuyet();
                gridControl.DataSource = DSTTTL_BS;

                gridControl.Visible = true;
                dgvDSThu.Visible = false;
                //btnLuu.Enabled = false;
                //DSTTTL_Edited = new DataTable();
                chkSelectAll.Visible = false;
            }
        }

        private void radDSThu_CheckedChanged(object sender, EventArgs e)
        {
            if (radDSThu.Checked)
            {
                DSTTTL_BS = new BindingSource();
                DSTTTL_BS.DataSource = _cTTTL.LoadDSCTTTTL();
                dgvDSThu.Visible = true;
                dgvDSThu.DataSource = DSTTTL_BS;
                gridControl.Visible = false;
                //btnLuu.Enabled = false;
                //DSTTTL_Edited = new DataTable();
                chkSelectAll.Visible = true;
            }
        }

        public void thảoThưTrảLờitoolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Dictionary<string, string> source = new Dictionary<string, string>();
            ///Lấy dữ liệu tại selected row
            DataRowView selRow = (DataRowView)gridViewTTTL.GetRow(gridViewTTTL.GetSelectedRows()[0]);
            source.Add("MaDon", selRow["MaDon"].ToString());
            source.Add("DanhBo", selRow["DanhBo"].ToString());
            ///Nơi Chuyển Đến, dùng để xét Đơn Khách Hàng nhận từ bản nào, Vì lúc ta load danh sách đơn chưa duyệt ở nhiều bảng
            source.Add("MaNoiChuyenDen", selRow["MaNoiChuyenDen"].ToString());
            source.Add("NoiChuyenDen", selRow["NoiChuyenDen"].ToString());
            source.Add("LyDoChuyenDen", selRow["LyDoChuyenDen"].ToString());

            frmTTTL frm = new frmTTTL(source);
            if (frm.ShowDialog() == DialogResult.OK)
                gridControl.DataSource = _cTTTL.LoadDSTTTLChuaDuyet();
        }

        #region gridViewTTTL (Danh Sách Thảo Thư Trả Lời)

        /// <summary>
        /// Hiện thị số thứ tự dòng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewTTTL_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        /// <summary>
        /// Format dữ liệu trong column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewTTTL_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaDon" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        /// <summary>
        /// Hiện thị menuStrip tại chỗ click chuột
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewTTTL_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (radChuaDuyet.Checked && gridControl.MainView.RowCount > 0 && e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(gridControl, new Point(e.X, e.Y));
            }
        }

        /// <summary>
        /// Ctrl+F Tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewTTTL_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridViewTTTL.RowCount > 0 && e.Control && e.KeyCode == Keys.F)
            {
                Dictionary<string, string> source = new Dictionary<string, string>();
                source.Add("Action", "View");
                source.Add("MaDon", ((DataRowView)gridViewTTTL.GetRow(gridViewTTTL.GetSelectedRows()[0])).Row["MaDon"].ToString());
                frmShowDonKH frm = new frmShowDonKH(source);
                //frmShowDonKH frm = new frmShowDonKH(_cDonKH.getDonKHbyID(decimal.Parse(((DataRowView)gridViewTTTL.GetRow(gridViewTTTL.GetSelectedRows()[0])).Row["MaDon"].ToString())));
                frm.ShowDialog();
            }
        }

        /// <summary>
        /// Bắt đầu Edit Column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewTTTL_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            btnLuu.Enabled = false;
        }

        /// <summary>
        /// Kết thúc Edit Column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewTTTL_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            /////Khai báo các cột tương ứng trong Datagridview
            //if (DSTTTL_Edited.Columns.Count == 0)
            //    foreach (DataColumn itemCol in ((DataView)gridViewTTTL.DataSource).Table.Columns)
            //    {
            //        DSTTTL_Edited.Columns.Add(itemCol.ColumnName, itemCol.DataType);
            //    }

            /////Gọi hàm EndEdit để kết thúc Edit nếu không sẽ bị lỗi Value chưa cập nhật trong trường hợp chuyển Cell trong cùng 1 Row. Nếu chuyển Row thì không bị lỗi
            //((DataRowView)gridViewTTTL.GetRow(gridViewTTTL.GetSelectedRows()[0])).Row.EndEdit();

            /////DataRow != DataGridViewRow nên phải qua 1 loạt gán biến
            /////Tránh tình trạng trùng Danh Bộ nên xóa đi rồi add lại
            //if (DSTTTL_Edited.Select("MaDon = " + ((DataRowView)gridViewTTTL.GetRow(gridViewTTTL.GetSelectedRows()[0])).Row["MaDon"]).Count() > 0)
            //    DSTTTL_Edited.Rows.Remove(DSTTTL_Edited.Select("MaDon = " + ((DataRowView)gridViewTTTL.GetRow(gridViewTTTL.GetSelectedRows()[0])).Row["MaDon"])[0]);

            //DSTTTL_Edited.ImportRow(((DataRowView)gridViewTTTL.GetRow(gridViewTTTL.GetSelectedRows()[0])).Row);
            //btnLuu.Enabled = true;
            DataRowView itemRow = (DataRowView)gridViewTTTL.GetRow(gridViewTTTL.GetSelectedRows()[0]);

            TTTL tttl = _cTTTL.getTTTLbyID(decimal.Parse(itemRow["MaTTTL"].ToString()));
            tttl.KetQua = itemRow["KetQua"].ToString();
            tttl.Chuyen = true;
            tttl.MaChuyen = itemRow["MaChuyen"].ToString();
            tttl.LyDoChuyen = itemRow["LyDoChuyenDi"].ToString();
            _cTTTL.SuaTTTL(tttl);
        }

        #endregion

        #region gridViewCTTTTL (Chi Tiết Thảo Thư Trả Lời)

        /// <summary>
        /// Format dữ liệu trong column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewCTTTTL_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaCTTTTL" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        /// <summary>
        /// Lấy DataRow tại click chuột
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewCTTTTL_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            GridView gridview = (GridView)gridControl.GetViewAt(new Point(e.X, e.Y));
            _CTRow = (DataRowView)gridview.GetRow(gridview.GetSelectedRows()[0]);
        }

        /// <summary>
        /// Ctrl+F Tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewCTTTTL_KeyDown(object sender, KeyEventArgs e)
        {
            if (_CTRow != null && e.Control && e.KeyCode == Keys.F)
            {
                frmShowTTTL frm = new frmShowTTTL(decimal.Parse(_CTRow.Row["MaCTTTTL"].ToString()));
                if (frm.ShowDialog() == DialogResult.Cancel)
                    _CTRow = null;
            }
        }

        #endregion

        #region dgvDSThu (Danh Sách Thư Trả Lời)

        private void dgvDSThu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSThu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        /// <summary>
        /// Ctrl+F Tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSThu_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDSThu.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                frmShowTTTL frm = new frmShowTTTL(decimal.Parse(dgvDSThu["MaCTTTTL", dgvDSThu.CurrentRow.Index].Value.ToString()));
                frm.ShowDialog();
            }
        }

        #endregion

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (DSTTTL_Edited != null && DSTTTL_Edited.Rows.Count > 0)
                {
                    foreach (DataRow itemRow in DSTTTL_Edited.Rows)
                    {
                        //if (itemRow["MaTTTL"].ToString() == "")
                        //{
                        //    TTTL tttl = new TTTL();
                        //    tttl.MaDon = decimal.Parse(itemRow["MaDon"].ToString());
                        //    tttl.MaNoiChuyenDen = decimal.Parse(itemRow["MaNoiChuyenDen"].ToString());
                        //    tttl.NoiChuyenDen = itemRow["NoiChuyenDen"].ToString();
                        //    tttl.LyDoChuyenDen = itemRow["LyDoChuyenDen"].ToString();
                        //    tttl.KetQua = itemRow["KetQua"].ToString();
                        //    if (itemRow["MaChuyen"].ToString() != "" && itemRow["MaChuyen"].ToString() != "NONE")
                        //    {
                        //        tttl.Chuyen = true;
                        //        tttl.MaChuyen = itemRow["MaChuyen"].ToString();
                        //        tttl.LyDoChuyen = itemRow["LyDoChuyenDi"].ToString();
                        //    }
                        //    if (_cTTTL.ThemTTTL(tttl))
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
                        //    TTTL tttl = _cTTTL.getTTTLbyID(decimal.Parse(itemRow["MaTTTL"].ToString()));
                        //    ///Đơn đã được nơi nhận xử lý thì không được sửa
                        //    if (!tttl.Nhan)
                        //    {
                        //        tttl.KetQua = itemRow["KetQua"].ToString();
                        //        if (itemRow["MaChuyen"].ToString() != "" && itemRow["MaChuyen"].ToString() != "NONE")
                        //        {
                        //            tttl.Chuyen = true;
                        //            tttl.MaChuyen = itemRow["MaChuyen"].ToString();
                        //            tttl.LyDoChuyen = itemRow["LyDoChuyenDi"].ToString();
                        //        }
                        //        else
                        //            if (itemRow["MaChuyen"].ToString() == "NONE")
                        //            {
                        //                tttl.Chuyen = false;
                        //                tttl.MaChuyen = null;
                        //                tttl.LyDoChuyen = null;
                        //            }
                        //        _cTTTL.SuaTTTL(tttl);
                        //    }
                        //    else
                        //    {
                        //        MessageBox.Show("Đơn " + tttl.MaTTTL + " đã được xử lý nên không sửa đổi được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    }
                        //}

                        TTTL tttl = _cTTTL.getTTTLbyID(decimal.Parse(itemRow["MaTTTL"].ToString()));
                        tttl.KetQua = itemRow["KetQua"].ToString();
                        tttl.Chuyen = true;
                        tttl.MaChuyen = itemRow["MaChuyen"].ToString();
                        tttl.LyDoChuyen = itemRow["LyDoChuyenDi"].ToString();
                        _cTTTL.SuaTTTL(tttl);
                    }
                    MessageBox.Show("Lưu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DSTTTL_Edited.Clear();

                    if (radDaDuyet.Checked)
                        gridControl.DataSource = _cTTTL.LoadDSTTTLDaDuyet().Tables["TTTL"];
                    if (radChuaDuyet.Checked)
                        gridControl.DataSource = _cTTTL.LoadDSTTTLChuaDuyet();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void dgvDSThu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSThu.Columns[e.ColumnIndex].Name == "MaCTTTTL" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void dgvDSThu_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            bool ischecked = false;
            if (bool.Parse(dgvDSThu["ThuDuocKy", e.RowIndex].Value.ToString()) == true)
                ischecked = true;
            else
                ischecked = false;
            CTTTTL cttttl = _cTTTL.getCTTTTLbyID(decimal.Parse(dgvDSThu["MaCTTTTL", e.RowIndex].Value.ToString()));
            cttttl.ThuDuocKy = ischecked;
            _cTTTL.SuaCTTTTL(cttttl);
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                case "Mã Thư":
                    txtNoiDungTimKiem.Visible = true;
                    dateTimKiem.Visible = false;
                    break;
                case "Ngày Lập":
                    txtNoiDungTimKiem.Visible = false;
                    dateTimKiem.Visible = true;
                    break;
                default:
                    txtNoiDungTimKiem.Visible = false;
                    dateTimKiem.Visible = false;
                    DSTTTL_BS.RemoveFilter();
                    break;
            }
        }

        private void txtNoiDungTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtNoiDungTimKiem.Text.Trim() != "")
            {
                string expression = "";
                switch (cmbTimTheo.SelectedItem.ToString())
                {
                    case "Mã Đơn":
                        expression = String.Format("MaDon = {0}", txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                        break;
                    case "Mã Thư":
                        expression = String.Format("MaCTTTTL = {0}", txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                        break;
                }
                DSTTTL_BS.Filter = expression;
            }
            else
                DSTTTL_BS.RemoveFilter();
        }

        private void dateTimKiem_ValueChanged(object sender, EventArgs e)
        {
            string expression = String.Format("CreateDate > #{0:yyyy-MM-dd} 00:00:00# and CreateDate < #{0:yyyy-MM-dd} 23:59:59#", dateTimKiem.Value);
            DSTTTL_BS.Filter = expression;
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked)
                for (int i = 0; i < dgvDSThu.Rows.Count; i++)
                {
                    dgvDSThu["In", i].Value = true;
                }
            else
                for (int i = 0; i < dgvDSThu.Rows.Count; i++)
                {
                    dgvDSThu["In", i].Value = false;
                }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn In những Thư trên?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (radDSThu.Checked)
                    for (int i = 0; i < dgvDSThu.Rows.Count; i++)
                        if (bool.Parse(dgvDSThu["In", i].Value.ToString()) == true)
                        {
                            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                            DataRow dr = dsBaoCao.Tables["ThaoThuTraLoi"].NewRow();

                            CTTTTL cttttl = _cTTTL.getCTTTTLbyID(decimal.Parse(dgvDSThu["MaCTTTTL", i].Value.ToString()));
                            dr["SoPhieu"] = cttttl.MaCTTTTL.ToString().Insert(cttttl.MaCTTTTL.ToString().Length - 2, "-");
                            dr["LoTrinh"] = cttttl.LoTrinh;
                            dr["HoTen"] = cttttl.HoTen;
                            dr["DiaChi"] = cttttl.DiaChi;
                            dr["DanhBo"] = cttttl.DanhBo.Insert(7, " ").Insert(4, " ");
                            dr["HopDong"] = cttttl.HopDong;
                            dr["GiaBieu"] = cttttl.GiaBieu;
                            dr["DinhMuc"] = cttttl.DinhMuc;
                            dr["NgayNhanDon"] = cttttl.TTTL.DonKH.CreateDate.Value.ToString("dd/MM/yyyy");
                            dr["VeViec"] = cttttl.VeViec;
                            dr["NoiDung"] = cttttl.NoiDung;
                            dr["NoiNhan"] = cttttl.NoiNhan;
                            dr["ChucVu"] = cttttl.ChucVu;
                            dr["NguoiKy"] = cttttl.NguoiKy;

                            dsBaoCao.Tables["ThaoThuTraLoi"].Rows.Add(dr);

                            rptThaoThuTraLoi rpt = new rptThaoThuTraLoi();
                            rpt.SetDataSource(dsBaoCao);
                            rpt.PrintToPrinter(1, false, 0, 0);
                        }
            }
        }

        

    }
}
