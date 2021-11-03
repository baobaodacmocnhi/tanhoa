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
using KTKS_DonKH.DAL.ToKhachHang;
using DevExpress.XtraGrid.Views.Grid;
using KTKS_DonKH.DAL.CatHuyDanhBo;
using KTKS_DonKH.GUI.ToKhachHang;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using System.Globalization;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.CatHuyDanhBo;
using KTKS_DonKH.GUI.ToXuLy;
using KTKS_DonKH.DAL.DongNuoc;
using KTKS_DonKH.BaoCao.DongNuoc;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.GUI.DongNuoc;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL;

namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    public partial class frmDSCHDB : Form
    {
        CCHDB _cCHDB = new CCHDB();
        CDonKH _cDonKH = new CDonKH();
        CKTXM _cKTXM = new CKTXM();
        CDongNuoc _cDongNuoc = new CDongNuoc();
        CDHN _cDocSo = new CDHN();

        public frmDSCHDB()
        {
            InitializeComponent();
        }

        private void frmDSCHDB_Load(object sender, EventArgs e)
        {
            dgvDSCTCHDB.AutoGenerateColumns = false;
            dgvDSYCCHDB.AutoGenerateColumns = false;

            radDSCatTamDanhBo.Checked = true;
            dgvDSYCCHDB.Location = dgvDSCTCHDB.Location;

            cmbTimTheo.SelectedItem = "Ngày";

            List<Quan> lst = _cCHDB.GetDSQuan();
            Quan quan = new Quan();
            quan.ID = 0;
            quan.Name2 = "Tất Cả";
            lst.Insert(0, quan);
            cmbQuan.DataSource = lst;
            cmbQuan.DisplayMember = "Name2";
            cmbQuan.ValueMember = "ID";
        }

        private void radDSCatTamDanhBo_CheckedChanged(object sender, EventArgs e)
        {
            if (radDSCatTamDanhBo.Checked)
            {
                //DSCHDB_BS = new BindingSource();
                //DSCHDB_BS.DataSource = _cCHDB.LoadDSCTCTDB();
                //dgvDSCTCHDB.DataSource = DSCHDB_BS;

                dgvDSCTCHDB.Visible = true;
                //dgvDSCTCHDB.Columns["DaLapPhieu"].Visible = false;
                //dgvDSCTCHDB.Columns["PhieuDuocKy"].Visible = false;
                dgvDSYCCHDB.Visible = false;
                //btnLuu.Enabled = false;
                chkSelectAll.Visible = true;
            }
        }

        private void radDSCatHuyDanhBo_CheckedChanged(object sender, EventArgs e)
        {
            if (radDSCatHuyDanhBo.Checked)
            {
                //DSCHDB_BS = new BindingSource();
                //DSCHDB_BS.DataSource = _cCHDB.LoadDSCTCHDB();
                //dgvDSCTCHDB.DataSource = DSCHDB_BS;

                dgvDSCTCHDB.Visible = true;
                //dgvDSCTCHDB.Columns["DaLapPhieu"].Visible = true;
                //dgvDSCTCHDB.Columns["PhieuDuocKy"].Visible = true;
                dgvDSYCCHDB.Visible = false;
                //btnLuu.Enabled = false;
                chkSelectAll.Visible = true;
            }
        }

        private void radDSYCCHDB_CheckedChanged(object sender, EventArgs e)
        {
            if (radDSYCCHDB.Checked)
            {
                //DSCHDB_BS = new BindingSource();
                //DSCHDB_BS.DataSource = _cCHDB.LoadDSYCCHDB();
                //dgvDSYCCHDB.DataSource = DSCHDB_BS;

                dgvDSYCCHDB.Visible = true;
                dgvDSCTCHDB.Visible = false;
                //
                dgvDSYCCHDB.Columns["YC_LyDo"].Visible = true;
                dgvDSYCCHDB.Columns["YC_GhiChuLyDo"].Visible = true;
                dgvDSYCCHDB.Columns["YC_PhieuDuocKy"].HeaderText = "Phiếu Được Ký";
                dgvDSYCCHDB.Columns["SoPhieu"].HeaderText = "Số Phiếu";
                //
                //btnLuu.Enabled = false;
                chkSelectAll.Visible = true;
            }
        }

        private void radDSDongNuoc_CheckedChanged(object sender, EventArgs e)
        {
            if (radDSDongNuoc.Checked)
            {
                //DSCHDB_BS = new BindingSource();
                //DSCHDB_BS.DataSource = _cDongNuoc.LoadDSCTDongNuoc();
                //dgvDSYCCHDB.DataSource = DSCHDB_BS;

                dgvDSYCCHDB.Visible = true;
                dgvDSCTCHDB.Visible = false;
                //
                dgvDSYCCHDB.Columns["YC_LyDo"].Visible = false;
                dgvDSYCCHDB.Columns["YC_GhiChuLyDo"].Visible = false;
                dgvDSYCCHDB.Columns["YC_PhieuDuocKy"].HeaderText = "TB Được Ký";
                dgvDSYCCHDB.Columns["SoPhieu"].HeaderText = "Mã TB";
                //
                //btnLuu.Enabled = false;
                chkSelectAll.Visible = true;
            }
        }

        #region dgvDSCTCHDB (Danh Sách Cắt Tạm Cắt Hủy Danh Bộ)

        /// <summary>
        /// Format dữ liệu trong column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSCTCHDB_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSCTCHDB.Columns[e.ColumnIndex].Name == "SoPhieuYCCHDB" && dgvDSCTCHDB["SoPhieuYCCHDB", e.RowIndex].Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (dgvDSCTCHDB.Columns[e.ColumnIndex].Name == "MaTB" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (dgvDSCTCHDB.Columns[e.ColumnIndex].Name == "SoTien" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        /// <summary>
        /// Hiện thị số thứ tự dòng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSCTCHDB_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSCTCHDB.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        /// <summary>
        /// Kết thúc Edit Column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSCTCHDB_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (radDSCatTamDanhBo.Checked)
            //{
            //    CHDB_ChiTietCatTam ctctdb = _cCHDB.GetCTCTDB(decimal.Parse(dgvDSCTCHDB.CurrentRow.Cells["MaTB"].Value.ToString()));
            //    if (bool.Parse(dgvDSCTCHDB.CurrentRow.Cells["ThongBaoDuocKy"].Value.ToString()) != ctctdb.ThongBaoDuocKy)
            //    {
            //        ctctdb.ThongBaoDuocKy = bool.Parse(dgvDSCTCHDB.CurrentCell.Value.ToString());
            //        _cCHDB.SuaCTCTDB(ctctdb);
            //    }
            //    if (bool.Parse(dgvDSCTCHDB.CurrentRow.Cells["PhieuDuocKy"].Value.ToString()) != ctctdb.PhieuDuocKy)
            //    {
            //        ctctdb.PhieuDuocKy = bool.Parse(dgvDSCTCHDB.CurrentRow.Cells["PhieuDuocKy"].Value.ToString());
            //        if (_cCHDB.SuaCTCTDB(ctctdb))
            //        {
            //            CHDB_Phieu ycchdb = _cCHDB.GetPhieuHuyByMaCTCTDB(ctctdb.MaCTCTDB);
            //            ycchdb.PhieuDuocKy = ctctdb.PhieuDuocKy;
            //            _cCHDB.SuaPhieuHuy(ycchdb);
            //        }
            //    }
            //}
            //if (radDSCatHuyDanhBo.Checked)
            //{
            //    CHDB_ChiTietCatHuy ctchdb = _cCHDB.GetCTCHDB(decimal.Parse(dgvDSCTCHDB.CurrentRow.Cells["MaTB"].Value.ToString()));
            //    if (bool.Parse(dgvDSCTCHDB.CurrentRow.Cells["ThongBaoDuocKy"].Value.ToString()) != ctchdb.ThongBaoDuocKy)
            //    {
            //        ctchdb.ThongBaoDuocKy = bool.Parse(dgvDSCTCHDB.CurrentRow.Cells["ThongBaoDuocKy"].Value.ToString());
            //        _cCHDB.SuaCTCHDB(ctchdb);
            //    }
            //    if (bool.Parse(dgvDSCTCHDB.CurrentRow.Cells["PhieuDuocKy"].Value.ToString()) != ctchdb.PhieuDuocKy)
            //    {
            //        ctchdb.PhieuDuocKy = bool.Parse(dgvDSCTCHDB.CurrentRow.Cells["PhieuDuocKy"].Value.ToString());
            //        if (_cCHDB.SuaCTCHDB(ctchdb))
            //        {
            //            CHDB_Phieu ycchdb = _cCHDB.GetPhieuHuyByMaCTCHDB(ctchdb.MaCTCHDB);
            //            ycchdb.PhieuDuocKy = ctchdb.PhieuDuocKy;
            //            _cCHDB.SuaPhieuHuy(ycchdb);
            //        }
            //    }
            //}
        }

        private void dgvDSCTCHDB_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvDSCTCHDB.Columns[e.ColumnIndex].Name == "ThongBaoDuocKy" && bool.Parse(e.FormattedValue.ToString()) != bool.Parse(dgvDSCTCHDB[e.ColumnIndex, e.RowIndex].Value.ToString()))
            {
                if (radDSCatTamDanhBo.Checked)
                {
                    if (CTaiKhoan.CheckQuyen("mnuCTDB", "Sua"))
                    {
                        CHDB_ChiTietCatTam ctctdb = _cCHDB.GetCTCTDB(decimal.Parse(dgvDSCTCHDB.CurrentRow.Cells["MaTB"].Value.ToString()));
                        ctctdb.ThongBaoDuocKy = bool.Parse(e.FormattedValue.ToString());
                        _cCHDB.SuaCTCTDB(ctctdb);
                    }
                    else
                        MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (radDSCatHuyDanhBo.Checked)
                {
                    if (CTaiKhoan.CheckQuyen("mnuCHDB", "Sua"))
                    {
                        CHDB_ChiTietCatHuy ctchdb = _cCHDB.GetCTCHDB(decimal.Parse(dgvDSCTCHDB.CurrentRow.Cells["MaTB"].Value.ToString()));
                        ctchdb.ThongBaoDuocKy = bool.Parse(e.FormattedValue.ToString());
                        _cCHDB.SuaCTCHDB(ctchdb);
                    }
                    else
                        MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (dgvDSCTCHDB.Columns[e.ColumnIndex].Name == "PhieuDuocKy" && bool.Parse(e.FormattedValue.ToString()) != bool.Parse(dgvDSCTCHDB[e.ColumnIndex, e.RowIndex].Value.ToString()))
            {
                if (radDSCatTamDanhBo.Checked)
                {
                    if (CTaiKhoan.CheckQuyen("mnuCTDB", "Sua"))
                    {
                        CHDB_ChiTietCatTam ctctdb = _cCHDB.GetCTCTDB(decimal.Parse(dgvDSCTCHDB.CurrentRow.Cells["MaTB"].Value.ToString()));
                        ctctdb.PhieuDuocKy = bool.Parse(e.FormattedValue.ToString());
                        if (_cCHDB.SuaCTCTDB(ctctdb))
                        {
                            CHDB_Phieu ycchdb = _cCHDB.GetPhieuHuyByMaCTCTDB(ctctdb.MaCTCTDB);
                            ycchdb.PhieuDuocKy = ctctdb.PhieuDuocKy;
                            _cCHDB.SuaPhieuHuy(ycchdb);
                        }
                    }
                    else
                        MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (radDSCatHuyDanhBo.Checked)
                {
                    if (CTaiKhoan.CheckQuyen("mnuCHDB", "Sua"))
                    {
                        CHDB_ChiTietCatHuy ctchdb = _cCHDB.GetCTCHDB(decimal.Parse(dgvDSCTCHDB.CurrentRow.Cells["MaTB"].Value.ToString()));
                        ctchdb.PhieuDuocKy = bool.Parse(e.FormattedValue.ToString());
                        if (_cCHDB.SuaCTCHDB(ctchdb))
                        {
                            CHDB_Phieu ycchdb = _cCHDB.GetPhieuHuyByMaCTCHDB(ctchdb.MaCTCHDB);
                            ycchdb.PhieuDuocKy = ctchdb.PhieuDuocKy;
                            _cCHDB.SuaPhieuHuy(ycchdb);
                        }
                    }
                    else
                        MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Ctrl+F Tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSCTCHDB_KeyDown(object sender, KeyEventArgs e)
        {
            if (radDSCatTamDanhBo.Checked)
                if (dgvDSCTCHDB.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
                {
                    frmCTDB frm = new frmCTDB(decimal.Parse(dgvDSCTCHDB["MaTB", dgvDSCTCHDB.CurrentRow.Index].Value.ToString()));
                    if (frm.ShowDialog() == DialogResult.OK) { }
                    //DSCHDB_BS.DataSource = _cCHDB.LoadDSCTCTDB();
                }
            if (radDSCatHuyDanhBo.Checked)
                if (dgvDSCTCHDB.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
                {
                    frmCHDB frm = new frmCHDB(decimal.Parse(dgvDSCTCHDB["MaTB", dgvDSCTCHDB.CurrentRow.Index].Value.ToString()));
                    if (frm.ShowDialog() == DialogResult.OK) { }
                    //DSCHDB_BS.DataSource = _cCHDB.LoadDSCTCHDB();
                }
        }

        #endregion

        #region dgvDSYCCHDB (Danh Sách Phiếu Yêu Cầu Cắt Hủy Danh Bộ)

        private void dgvDSYCCHDB_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSYCCHDB.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSYCCHDB_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSYCCHDB.Columns[e.ColumnIndex].Name == "SoPhieu" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (dgvDSYCCHDB.Columns[e.ColumnIndex].Name == "YC_SoTien" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvDSYCCHDB_KeyDown(object sender, KeyEventArgs e)
        {
            if (radDSYCCHDB.Checked)
                if (dgvDSYCCHDB.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
                {
                    frmYCCHDB frm = new frmYCCHDB(decimal.Parse(dgvDSYCCHDB["SoPhieu", dgvDSYCCHDB.CurrentRow.Index].Value.ToString()));
                    frm.ShowDialog();
                }
            if (radDSDongNuoc.Checked)
                if (dgvDSYCCHDB.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
                {
                    frmDongNuoc frm = new frmDongNuoc(decimal.Parse(dgvDSYCCHDB["SoPhieu", dgvDSYCCHDB.CurrentRow.Index].Value.ToString()));
                    frm.ShowDialog();
                }
        }

        private void dgvDSYCCHDB_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (radDSYCCHDB.Checked)
            //{
            //    CHDB_Phieu ycchdb = _cCHDB.GetPhieuHuy(decimal.Parse(dgvDSYCCHDB.CurrentRow.Cells["SoPhieu"].Value.ToString()));
            //    if (bool.Parse(dgvDSYCCHDB.CurrentRow.Cells["YC_PhieuDuocKy"].Value.ToString()) != ycchdb.PhieuDuocKy)
            //    {
            //        ycchdb.PhieuDuocKy = bool.Parse(dgvDSYCCHDB.CurrentRow.Cells["YC_PhieuDuocKy"].Value.ToString());
            //        if (_cCHDB.SuaPhieuHuy(ycchdb))
            //        {
            //            if (ycchdb.TBCTDB)
            //            {
            //                CHDB_ChiTietCatTam ctctdb = _cCHDB.GetCTCTDB(ycchdb.MaCTCTDB.Value);
            //                ctctdb.PhieuDuocKy = bool.Parse(dgvDSYCCHDB.CurrentRow.Cells["YC_PhieuDuocKy"].Value.ToString());
            //                _cCHDB.SuaCTCTDB(ctctdb);
            //            }
            //            else
            //                if (ycchdb.TBCHDB)
            //                {
            //                    CHDB_ChiTietCatHuy ctchdb = _cCHDB.GetCTCHDB(ycchdb.MaCTCHDB.Value);
            //                    ctchdb.PhieuDuocKy = bool.Parse(dgvDSYCCHDB.CurrentRow.Cells["YC_PhieuDuocKy"].Value.ToString());
            //                    _cCHDB.SuaCTCHDB(ctchdb);
            //                }
            //        }
            //    }
            //}
            //if (radDSDongNuoc.Checked)
            //{
            //    DongNuoc_ChiTiet ctdongnuoc = _cDongNuoc.GetCTByMaCTDN(decimal.Parse(dgvDSYCCHDB.CurrentRow.Cells["SoPhieu"].Value.ToString()));
            //    if (bool.Parse(dgvDSYCCHDB.CurrentRow.Cells["YC_PhieuDuocKy"].Value.ToString()) != ctdongnuoc.ThongBaoDuocKy_DN)
            //    {
            //        ctdongnuoc.ThongBaoDuocKy_DN = bool.Parse(dgvDSYCCHDB.CurrentRow.Cells["YC_PhieuDuocKy"].Value.ToString());
            //        _cDongNuoc.SuaCT(ctdongnuoc);
            //    }
            //}
        }

        private void dgvDSYCCHDB_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvDSYCCHDB.Columns[e.ColumnIndex].Name == "YC_PhieuDuocKy" && bool.Parse(e.FormattedValue.ToString()) != bool.Parse(dgvDSYCCHDB[e.ColumnIndex, e.RowIndex].Value.ToString()))
            {
                if (radDSYCCHDB.Checked)
                {
                    if (CTaiKhoan.CheckQuyen("mnuPhieuCHDB", "Sua"))
                    {
                        CHDB_Phieu ycchdb = _cCHDB.GetPhieuHuy(decimal.Parse(dgvDSYCCHDB.CurrentRow.Cells["SoPhieu"].Value.ToString()));
                        ycchdb.PhieuDuocKy = bool.Parse(e.FormattedValue.ToString());
                        if (_cCHDB.SuaPhieuHuy(ycchdb))
                        {
                            if (ycchdb.TBCTDB)
                            {
                                CHDB_ChiTietCatTam ctctdb = _cCHDB.GetCTCTDB(ycchdb.MaCTCTDB.Value);
                                ctctdb.PhieuDuocKy = ycchdb.PhieuDuocKy;
                                _cCHDB.SuaCTCTDB(ctctdb);
                            }
                            else
                                if (ycchdb.TBCHDB)
                                {
                                    CHDB_ChiTietCatHuy ctchdb = _cCHDB.GetCTCHDB(ycchdb.MaCTCHDB.Value);
                                    ctchdb.PhieuDuocKy = ycchdb.PhieuDuocKy;
                                    _cCHDB.SuaCTCHDB(ctchdb);
                                }
                        }
                    }
                    else
                        MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (radDSDongNuoc.Checked)
                {
                    if (CTaiKhoan.CheckQuyen("mnuDongNuoc", "Sua"))
                    {
                        DongNuoc_ChiTiet ctdongnuoc = _cDongNuoc.GetCTByMaCTDN(decimal.Parse(dgvDSYCCHDB.CurrentRow.Cells["SoPhieu"].Value.ToString()));
                        ctdongnuoc.ThongBaoDuocKy_DN = bool.Parse(e.FormattedValue.ToString());
                        _cDongNuoc.SuaCT(ctdongnuoc);
                    }
                    else
                        MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radDSCatTamDanhBo.Checked || radDSCatHuyDanhBo.Checked)
                if (chkSelectAll.Checked)

                    for (int i = 0; i < dgvDSCTCHDB.Rows.Count; i++)
                    {
                        dgvDSCTCHDB["In", i].Value = true;
                    }
                else
                    for (int i = 0; i < dgvDSCTCHDB.Rows.Count; i++)
                    {
                        dgvDSCTCHDB["In", i].Value = false;
                    }
            else
                if (radDSYCCHDB.Checked || radDSDongNuoc.Checked)
                    if (chkSelectAll.Checked)

                        for (int i = 0; i < dgvDSYCCHDB.Rows.Count; i++)
                        {
                            dgvDSYCCHDB["YC_In", i].Value = true;
                        }
                    else
                        for (int i = 0; i < dgvDSYCCHDB.Rows.Count; i++)
                        {
                            dgvDSYCCHDB["YC_In", i].Value = false;
                        }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn In những Thông Báo trên?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    if (radDSCatTamDanhBo.Checked)
                        for (int i = 0; i < dgvDSCTCHDB.Rows.Count; i++)
                            if (dgvDSCTCHDB["In", i].Value != null && bool.Parse(dgvDSCTCHDB["In", i].Value.ToString()) == true)
                            {
                                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                DataRow dr = dsBaoCao.Tables["ThongBaoCHDB"].NewRow();

                                CHDB_ChiTietCatTam ctctdb = _cCHDB.GetCTCTDB(decimal.Parse(dgvDSCTCHDB["MaTB", i].Value.ToString()));

                                //dr["SoPhieu"] = ctctdb.MaCTCTDB.ToString().Insert(ctctdb.MaCTCTDB.ToString().Length - 2, "-");
                                dr["HoTen"] = ctctdb.HoTen;
                                dr["DiaChi"] = ctctdb.DiaChi;
                                if (!string.IsNullOrEmpty(ctctdb.DanhBo))
                                    dr["DanhBo"] = ctctdb.DanhBo.Insert(7, " ").Insert(4, " ");
                                dr["HopDong"] = ctctdb.HopDong;
                                dr["Quan"] = _cCHDB.getTenQuan(int.Parse(ctctdb.Quan));
                                dr["Phuong"] = _cCHDB.getTenPhuong(int.Parse(ctctdb.Quan), int.Parse(ctctdb.Phuong));

                                dr["ViTriDHN"] = "Vị trí ĐHN lắp đặt: " + ctctdb.ViTriDHN1 + ", " + ctctdb.ViTriDHN2;

                                if (ctctdb.LyDo != "Vấn Đề Khác")
                                    dr["LyDo"] = ctctdb.LyDo + ". ";
                                if (ctctdb.GhiChuLyDo != "")
                                    dr["LyDo"] += ctctdb.GhiChuLyDo + ". ";
                                if (ctctdb.SoTien.ToString() != "")
                                    dr["LyDo"] += "Tổng số tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", ctctdb.SoTien);
                                dr["NoiDung"] = ctctdb.NoiDung;

                                dr["NoiNhan"] = ctctdb.NoiNhan + "\r\nTB" + ctctdb.MaCTCTDB.ToString().Insert(ctctdb.MaCTCTDB.ToString().Length - 2, "-");

                                if (ctctdb.NgayXuLy != null)
                                    dr["NgayXuLy"] = ctctdb.NgayXuLy.Value.ToString("dd/MM/yyyy") + " : " + ctctdb.NoiDungXuLy;

                                dr["ChucVu"] = ctctdb.ChucVu;
                                dr["NguoiKy"] = ctctdb.NguoiKy;
                                dr["KyHieuPhong"] = CTaiKhoan.KyHieuPhong;

                                dsBaoCao.Tables["ThongBaoCHDB"].Rows.Add(dr);

                                DataRow drLogo = dsBaoCao.Tables["BienNhanDonKH"].NewRow();
                                drLogo["PathLogo"] = Application.StartupPath.ToString() + @"\Resources\logocongty.png";
                                dsBaoCao.Tables["BienNhanDonKH"].Rows.Add(drLogo);

                                rptThongBaoCTDB rpt = new rptThongBaoCTDB();
                                rpt.SetDataSource(dsBaoCao);

                                printDialog.AllowSomePages = true;
                                printDialog.ShowHelp = true;

                                rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                                rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                                rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.ToPage, printDialog.PrinterSettings.FromPage);
                                //rpt.PrintToPrinter(1, false, 1, 1);
                                rpt.Clone();
                                rpt.Dispose();
                            }
                    if (radDSCatHuyDanhBo.Checked)
                        for (int i = 0; i < dgvDSCTCHDB.Rows.Count; i++)
                            if (dgvDSCTCHDB["In", i].Value != null && bool.Parse(dgvDSCTCHDB["In", i].Value.ToString()) == true)
                            {
                                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                DataRow dr = dsBaoCao.Tables["ThongBaoCHDB"].NewRow();

                                CHDB_ChiTietCatHuy ctchdb = _cCHDB.GetCTCHDB(decimal.Parse(dgvDSCTCHDB["MaTB", i].Value.ToString()));

                                //dr["SoPhieu"] = ctchdb.MaCTCHDB.ToString().Insert(ctchdb.MaCTCHDB.ToString().Length - 2, "-");
                                dr["HoTen"] = ctchdb.HoTen;
                                dr["DiaChi"] = ctchdb.DiaChi;
                                if (!string.IsNullOrEmpty(ctchdb.DanhBo))
                                    dr["DanhBo"] = ctchdb.DanhBo.Insert(7, " ").Insert(4, " ");
                                dr["HopDong"] = ctchdb.HopDong;
                                dr["Quan"] = _cCHDB.getTenQuan(int.Parse(ctchdb.Quan));
                                dr["Phuong"] = _cCHDB.getTenPhuong(int.Parse(ctchdb.Quan), int.Parse(ctchdb.Phuong));

                                dr["ViTriDHN"] = "Vị trí ĐHN lắp đặt: " + ctchdb.ViTriDHN1 + ", " + ctchdb.ViTriDHN2;

                                if (ctchdb.LyDo != "Vấn Đề Khác")
                                    dr["LyDo"] = ctchdb.LyDo + ". ";
                                if (ctchdb.GhiChuLyDo != "")
                                    dr["LyDo"] += ctchdb.GhiChuLyDo + ". ";
                                if (ctchdb.SoTien.ToString() != "")
                                    dr["LyDo"] += "Tổng số tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", ctchdb.SoTien);
                                dr["NoiDung"] = ctchdb.NoiDung;

                                dr["NoiNhan"] = ctchdb.NoiNhan + "\r\nTB" + ctchdb.MaCTCHDB.ToString().Insert(ctchdb.MaCTCHDB.ToString().Length - 2, "-");

                                if (ctchdb.NgayXuLy != null)
                                    dr["NgayXuLy"] = ctchdb.NgayXuLy.Value.ToString("dd/MM/yyyy") + " : " + ctchdb.NoiDungXuLy;

                                dr["ChucVu"] = ctchdb.ChucVu;
                                dr["NguoiKy"] = ctchdb.NguoiKy;
                                dr["KyHieuPhong"] = CTaiKhoan.KyHieuPhong;

                                dsBaoCao.Tables["ThongBaoCHDB"].Rows.Add(dr);

                                DataRow drLogo = dsBaoCao.Tables["BienNhanDonKH"].NewRow();
                                drLogo["PathLogo"] = Application.StartupPath.ToString() + @"\Resources\logocongty.png";
                                dsBaoCao.Tables["BienNhanDonKH"].Rows.Add(drLogo);

                                rptThongBaoCHDB rpt = new rptThongBaoCHDB();
                                rpt.SetDataSource(dsBaoCao);

                                printDialog.AllowSomePages = true;
                                printDialog.ShowHelp = true;

                                rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                                rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                                rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.ToPage, printDialog.PrinterSettings.FromPage);
                                //rpt.PrintToPrinter(1, false, 1, 1);
                            }
                    if (radDSYCCHDB.Checked)
                        for (int i = 0; i < dgvDSYCCHDB.Rows.Count; i++)
                            if (dgvDSYCCHDB["YC_In", i].Value != null && bool.Parse(dgvDSYCCHDB["YC_In", i].Value.ToString()) == true)
                            {
                                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                DataRow dr = dsBaoCao.Tables["PhieuCHDB"].NewRow();

                                CHDB_Phieu ycchdb = _cCHDB.GetPhieuHuy(decimal.Parse(dgvDSYCCHDB["SoPhieu", i].Value.ToString()));
                                dr["SoPhieu"] = ycchdb.MaYCCHDB.ToString().Insert(ycchdb.MaYCCHDB.ToString().Length - 2, "-");
                                dr["HieuLucKy"] = ycchdb.HieuLucKy;
                                dr["Dot"] = ycchdb.Dot;
                                dr["HoTen"] = ycchdb.HoTen;
                                dr["DiaChi"] = ycchdb.DiaChi;
                                if (!string.IsNullOrEmpty(ycchdb.DanhBo))
                                    dr["DanhBo"] = ycchdb.DanhBo.Insert(7, " ").Insert(4, " ");
                                dr["HopDong"] = ycchdb.HopDong;

                                if (ycchdb.LyDo == "Vấn Đề Khác")
                                    dr["LyDo"] = "";
                                else
                                    dr["LyDo"] = ycchdb.LyDo + ". ";

                                if (ycchdb.GhiChuLyDo != "")
                                    dr["LyDo"] += ycchdb.GhiChuLyDo + ". ";
                                if (ycchdb.SoTien.ToString() != "")
                                    dr["LyDo"] += "Tổng số tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", ycchdb.SoTien);

                                dr["ChucVu"] = ycchdb.ChucVu;
                                dr["NguoiKy"] = ycchdb.NguoiKy;
                                dr["KyHieuPhong"] = CTaiKhoan.KyHieuPhong;

                                if (ycchdb.CHDB.MaDonMoi != null)
                                {
                                    if (ycchdb.CHDB.DonTu.DonTu_ChiTiets.Count == 1)
                                        dr["MaDon"] = ycchdb.CHDB.MaDonMoi.Value.ToString();
                                    else
                                        dr["MaDon"] = ycchdb.CHDB.MaDonMoi.Value.ToString() + "." + ycchdb.STT.Value.ToString();
                                }
                                else
                                    if (ycchdb.CHDB.MaDon != null)
                                        dr["MaDon"] = ycchdb.CHDB.MaDon.ToString().Insert(ycchdb.CHDB.MaDon.ToString().Length - 2, "-");
                                    else
                                        if (ycchdb.CHDB.MaDonTXL != null)
                                            dr["MaDon"] = "TXL" + ycchdb.CHDB.MaDonTXL.ToString().Insert(ycchdb.CHDB.MaDonTXL.ToString().Length - 2, "-");
                                        else
                                            if (ycchdb.CHDB.MaDonTBC != null)
                                                dr["MaDon"] = "TBC" + ycchdb.CHDB.MaDonTBC.ToString().Insert(ycchdb.CHDB.MaDonTBC.ToString().Length - 2, "-");

                                dsBaoCao.Tables["PhieuCHDB"].Rows.Add(dr);

                                //rptPhieuCHDBx2 rpt = new rptPhieuCHDBx2();
                                //for (int j = 0; j < rpt.Subreports.Count; j++)
                                //{
                                //    rpt.Subreports[j].SetDataSource(dsBaoCao);
                                //}
                                DataRow drLogo = dsBaoCao.Tables["BienNhanDonKH"].NewRow();
                                drLogo["PathLogo"] = Application.StartupPath.ToString() + @"\Resources\logocongty.png";
                                dsBaoCao.Tables["BienNhanDonKH"].Rows.Add(drLogo);

                                rptPhieuCHDB rpt = new rptPhieuCHDB();
                                rpt.SetDataSource(dsBaoCao);

                                printDialog.AllowSomePages = true;
                                printDialog.ShowHelp = true;

                                rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                                rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                                rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.ToPage, printDialog.PrinterSettings.FromPage);
                                //rpt.PrintToPrinter(1, false, 1, 1);
                                rpt.Clone();
                                rpt.Dispose();
                            }
                    if (radDSDongNuoc.Checked)
                        for (int i = 0; i < dgvDSYCCHDB.Rows.Count; i++)
                            if (dgvDSYCCHDB["YC_In", i].Value != null && bool.Parse(dgvDSYCCHDB["YC_In", i].Value.ToString()) == true)
                            {
                                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                                DataRow dr = dsBaoCao.Tables["ThongBaoDongNuoc"].NewRow();

                                DongNuoc_ChiTiet ctdongnuoc = _cDongNuoc.GetCTByMaCTDN(decimal.Parse(dgvDSYCCHDB["SoPhieu", i].Value.ToString()));
                                dr["SoPhieu"] = ctdongnuoc.MaCTDN.ToString().Insert(ctdongnuoc.MaCTDN.ToString().Length - 2, "-");
                                dr["HoTen"] = ctdongnuoc.HoTen;
                                dr["DiaChi"] = ctdongnuoc.DiaChi;
                                dr["DanhBo"] = ctdongnuoc.DanhBo;
                                dr["HopDong"] = ctdongnuoc.HopDong;
                                dr["DiaChiDHN"] = ctdongnuoc.DiaChiDHN;
                                ///
                                dr["NgayXuLy"] = ctdongnuoc.NgayDN.Value.ToString("dd/MM/yyyy");
                                dr["SoCongVan"] = ctdongnuoc.SoCongVan_DN;
                                dr["NgayCongVan"] = ctdongnuoc.NgayCongVan_DN.Value.ToString("dd/MM/yyyy");
                                dr["Phuong"] = ctdongnuoc.TenPhuong;
                                dr["Quan"] = ctdongnuoc.TenQuan;
                                ///
                                dr["ChucVu"] = ctdongnuoc.ChucVu_DN;
                                dr["NguoiKy"] = ctdongnuoc.NguoiKy_DN;
                                dr["KyHieuPhong"] = CTaiKhoan.KyHieuPhong;

                                dsBaoCao.Tables["ThongBaoDongNuoc"].Rows.Add(dr);

                                rptThongBaoDN rpt = new rptThongBaoDN();
                                rpt.SetDataSource(dsBaoCao);

                                printDialog.AllowSomePages = true;
                                printDialog.ShowHelp = true;

                                rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                                rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                                rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                                rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.ToPage, printDialog.PrinterSettings.FromPage);
                                //rpt.PrintToPrinter(1, false, 1, 1);
                                rpt.Clone();
                                rpt.Dispose();
                            }
                }
            }
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                case "Danh Bộ":
                case "Số Thông Báo/Số Phiếu":
                case "Lý Do":
                    txtNoiDungTimKiem.Visible = true;
                    txtNoiDungTimKiem2.Visible = true;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Ngày":
                    txtNoiDungTimKiem.Visible = false;
                    txtNoiDungTimKiem2.Visible = false;
                    panel_KhoangThoiGian.Visible = true;
                    break;
                default:
                    txtNoiDungTimKiem.Visible = false;
                    txtNoiDungTimKiem2.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    break;
            }
            txtNoiDungTimKiem.Text = "";
            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;
            dgvDSCTCHDB.DataSource = null;
            dgvDSYCCHDB.DataSource = null;
        }

        private void btnInNhan_Click(object sender, EventArgs e)
        {
            if (radDSCatTamDanhBo.Checked)
            {
                DataSetBaoCao dsBaoCao1 = new DataSetBaoCao();
                DataSetBaoCao dsBaoCao2 = new DataSetBaoCao();
                bool flag = true;
                for (int i = 0; i < dgvDSCTCHDB.Rows.Count; i++)
                    if (dgvDSCTCHDB["In", i].Value != null && bool.Parse(dgvDSCTCHDB["In", i].Value.ToString()) == true)
                        if (flag)
                        {
                            DataRow dr = dsBaoCao1.Tables["ThaoThuTraLoi"].NewRow();

                            CHDB_ChiTietCatTam ctctdb = _cCHDB.GetCTCTDB(decimal.Parse(dgvDSCTCHDB["MaTB", i].Value.ToString()));
                            dr["SoPhieu"] = "CT " + ctctdb.MaCTCTDB.ToString().Insert(ctctdb.MaCTCTDB.ToString().Length - 2, "-");
                            dr["HoTen"] = ctctdb.HoTen;
                            dr["DiaChi"] = ctctdb.DiaChi;

                            dsBaoCao1.Tables["ThaoThuTraLoi"].Rows.Add(dr);
                            flag = false;
                        }
                        else
                        {
                            DataRow dr = dsBaoCao2.Tables["ThaoThuTraLoi"].NewRow();

                            CHDB_ChiTietCatTam ctctdb = _cCHDB.GetCTCTDB(decimal.Parse(dgvDSCTCHDB["MaTB", i].Value.ToString()));
                            dr["SoPhieu"] = "CT " + ctctdb.MaCTCTDB.ToString().Insert(ctctdb.MaCTCTDB.ToString().Length - 2, "-");
                            dr["HoTen"] = ctctdb.HoTen;
                            dr["DiaChi"] = ctctdb.DiaChi;

                            dsBaoCao2.Tables["ThaoThuTraLoi"].Rows.Add(dr);
                            flag = true;
                        }
                rptKinhGui rpt = new rptKinhGui();
                rpt.Subreports[0].SetDataSource(dsBaoCao1);
                rpt.Subreports[1].SetDataSource(dsBaoCao2);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.ShowDialog();
            }
            if (radDSCatHuyDanhBo.Checked)
            {
                DataSetBaoCao dsBaoCao1 = new DataSetBaoCao();
                DataSetBaoCao dsBaoCao2 = new DataSetBaoCao();
                bool flag = true;
                for (int i = 0; i < dgvDSCTCHDB.Rows.Count; i++)
                    if (dgvDSCTCHDB["In", i].Value != null && bool.Parse(dgvDSCTCHDB["In", i].Value.ToString()) == true)
                        if (flag)
                        {
                            DataRow dr = dsBaoCao1.Tables["ThaoThuTraLoi"].NewRow();

                            CHDB_ChiTietCatHuy ctchdb = _cCHDB.GetCTCHDB(decimal.Parse(dgvDSCTCHDB["MaTB", i].Value.ToString()));
                            dr["SoPhieu"] = "CH " + ctchdb.MaCTCHDB.ToString().Insert(ctchdb.MaCTCHDB.ToString().Length - 2, "-");
                            dr["HoTen"] = ctchdb.HoTen;
                            dr["DiaChi"] = ctchdb.DiaChi;

                            dsBaoCao1.Tables["ThaoThuTraLoi"].Rows.Add(dr);
                            flag = false;
                        }
                        else
                        {
                            DataRow dr = dsBaoCao2.Tables["ThaoThuTraLoi"].NewRow();

                            CHDB_ChiTietCatHuy ctchdb = _cCHDB.GetCTCHDB(decimal.Parse(dgvDSCTCHDB["MaTB", i].Value.ToString()));
                            dr["SoPhieu"] = "CH " + ctchdb.MaCTCHDB.ToString().Insert(ctchdb.MaCTCHDB.ToString().Length - 2, "-");
                            dr["HoTen"] = ctchdb.HoTen;
                            dr["DiaChi"] = ctchdb.DiaChi;

                            dsBaoCao2.Tables["ThaoThuTraLoi"].Rows.Add(dr);
                            flag = true;
                        }
                rptKinhGui rpt = new rptKinhGui();
                rpt.Subreports[0].SetDataSource(dsBaoCao1);
                rpt.Subreports[1].SetDataSource(dsBaoCao2);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.ShowDialog();
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                    if (txtNoiDungTimKiem.Text.Trim() != "")
                        if (radDSCatTamDanhBo.Checked)
                        {
                            if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TKH"))
                                dgvDSCTCHDB.DataSource = _cCHDB.getDS_CatTam("TKH", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                            else
                                if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                                    dgvDSCTCHDB.DataSource = _cCHDB.getDS_CatTam("TXL", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                else
                                    if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TBC"))
                                        dgvDSCTCHDB.DataSource = _cCHDB.getDS_CatTam("TBC", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                    else
                                        dgvDSCTCHDB.DataSource = _cCHDB.getDS_CatTam("", decimal.Parse(txtNoiDungTimKiem.Text.Trim()));
                        }
                        else
                            if (radDSCatHuyDanhBo.Checked)
                            {
                                if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TKH"))
                                    dgvDSCTCHDB.DataSource = _cCHDB.getDS_CatHuy("TKH", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                else
                                    if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                                        dgvDSCTCHDB.DataSource = _cCHDB.getDS_CatHuy("TXL", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                    else
                                        if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TBC"))
                                            dgvDSCTCHDB.DataSource = _cCHDB.getDS_CatHuy("TBC", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                        else
                                            dgvDSCTCHDB.DataSource = _cCHDB.getDS_CatHuy("", decimal.Parse(txtNoiDungTimKiem.Text.Trim()));
                            }
                            else
                                if (radDSYCCHDB.Checked)
                                {
                                    if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TKH"))
                                        dgvDSCTCHDB.DataSource = _cCHDB.getDS_PhieuHuy("TKH", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                    else
                                        if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                                            dgvDSCTCHDB.DataSource = _cCHDB.getDS_PhieuHuy("TXL", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                        else
                                            if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TBC"))
                                                dgvDSCTCHDB.DataSource = _cCHDB.getDS_PhieuHuy("TBC", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                            else
                                                dgvDSCTCHDB.DataSource = _cCHDB.getDS_PhieuHuy("", decimal.Parse(txtNoiDungTimKiem.Text.Trim()));
                                }
                                else
                                    if (radDSDongNuoc.Checked)
                                    {
                                        if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TKH"))
                                            dgvDSYCCHDB.DataSource = _cDongNuoc.getDS_DongNuoc("TKH", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                        else
                                            if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                                                dgvDSYCCHDB.DataSource = _cDongNuoc.getDS_DongNuoc("TXL", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                            else
                                                if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TBC"))
                                                    dgvDSYCCHDB.DataSource = _cDongNuoc.getDS_DongNuoc("TBC", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                                else
                                                    dgvDSYCCHDB.DataSource = _cDongNuoc.getDS_DongNuoc("", decimal.Parse(txtNoiDungTimKiem.Text.Trim()));
                                    }
                    break;
                case "Danh Bộ":
                    if (txtNoiDungTimKiem.Text.Trim() != "")
                        if (radDSCatTamDanhBo.Checked)
                            dgvDSCTCHDB.DataSource = _cCHDB.getDS_CatTam_DanhBo(txtNoiDungTimKiem.Text.Trim().Replace(" ", ""));
                        else
                            if (radDSCatHuyDanhBo.Checked)
                                dgvDSCTCHDB.DataSource = _cCHDB.getDS_CatHuy_DanhBo(txtNoiDungTimKiem.Text.Trim().Replace(" ", ""));
                            else
                                if (radDSYCCHDB.Checked)
                                    dgvDSYCCHDB.DataSource = _cCHDB.getDS_PhieuHuy(txtNoiDungTimKiem.Text.Trim().Replace(" ", ""));
                                else
                                    if (radDSDongNuoc.Checked)
                                        dgvDSYCCHDB.DataSource = _cDongNuoc.getDS_DongNuoc(txtNoiDungTimKiem.Text.Trim().Replace(" ", ""));
                    break;
                case "Số Thông Báo/Số Phiếu":
                    if (txtNoiDungTimKiem.Text.Trim() != "" && txtNoiDungTimKiem2.Text.Trim() != "")
                    {
                        if (radDSCatTamDanhBo.Checked)
                            dgvDSCTCHDB.DataSource = _cCHDB.getDS_CatTam(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Replace("-", "")));
                        else
                            if (radDSCatHuyDanhBo.Checked)
                                dgvDSCTCHDB.DataSource = _cCHDB.getDS_CatHuy(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Replace("-", "")));
                            else
                                if (radDSYCCHDB.Checked)
                                    dgvDSYCCHDB.DataSource = _cCHDB.getDS_PhieuHuy(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Replace("-", "")));
                    }
                    else
                    {
                        if (txtNoiDungTimKiem.Text.Trim() != "")
                            if (radDSCatTamDanhBo.Checked)
                                dgvDSCTCHDB.DataSource = _cCHDB.getDS_CatTam(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                            else
                                if (radDSCatHuyDanhBo.Checked)
                                    dgvDSCTCHDB.DataSource = _cCHDB.getDS_CatHuy(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                                else
                                    if (radDSYCCHDB.Checked)
                                        dgvDSYCCHDB.DataSource = _cCHDB.getDS_PhieuHuy(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                                    else
                                        if (radDSDongNuoc.Checked)
                                            dgvDSYCCHDB.DataSource = _cDongNuoc.getDS_DongNuoc(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                    }
                    break;
                case "Lý Do":
                    if (radDSCatTamDanhBo.Checked)
                        dgvDSCTCHDB.DataSource = _cCHDB.getDS_CatTam_LyDo(txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                    else
                        if (radDSCatHuyDanhBo.Checked)
                            dgvDSCTCHDB.DataSource = _cCHDB.getDS_CatHuy_LyDo(txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                    break;
                case "Ngày":
                    if (cmbQuan.SelectedIndex == 0)
                    {
                        if (radDSCatTamDanhBo.Checked)
                            dgvDSCTCHDB.DataSource = _cCHDB.getDS_CatTam(dateTu.Value, dateDen.Value);
                        else
                            if (radDSCatHuyDanhBo.Checked)
                                dgvDSCTCHDB.DataSource = _cCHDB.getDS_CatHuy(dateTu.Value, dateDen.Value);
                            else
                                if (radDSYCCHDB.Checked)
                                    dgvDSYCCHDB.DataSource = _cCHDB.getDS_PhieuHuy(dateTu.Value, dateDen.Value);
                                else
                                    if (radDSDongNuoc.Checked)
                                        dgvDSYCCHDB.DataSource = _cDongNuoc.getDS_DongNuoc_CreateDate(dateTu.Value, dateDen.Value);
                    }
                    else
                        if (cmbQuan.SelectedIndex > 0)
                        {
                            if (radDSCatTamDanhBo.Checked)
                                dgvDSCTCHDB.DataSource = _cCHDB.getDS_CatTam(cmbQuan.SelectedValue.ToString(), dateTu.Value, dateDen.Value);
                            else
                                if (radDSCatHuyDanhBo.Checked)
                                    dgvDSCTCHDB.DataSource = _cCHDB.getDS_CatHuy(cmbQuan.SelectedValue.ToString(), dateTu.Value, dateDen.Value);
                                else
                                    if (radDSYCCHDB.Checked)
                                        dgvDSYCCHDB.DataSource = _cCHDB.getDS_PhieuHuy(dateTu.Value, dateDen.Value, cmbQuan.SelectedValue.ToString());
                                    else
                                        if (radDSDongNuoc.Checked)
                                            dgvDSYCCHDB.DataSource = _cDongNuoc.getDS_DongNuoc_CreateDate(cmbQuan.SelectedValue.ToString(), dateTu.Value, dateDen.Value);
                        }
                    break;
                default:
                    break;
            }
        }

        private void btnInDS_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            if (radDSCatTamDanhBo.Checked)


                if (radDSCatHuyDanhBo.Checked)
                    foreach (DataGridViewRow item in dgvDSCTCHDB.Rows)
                    {
                        DataRow dr = dsBaoCao.Tables["ThongBaoCHDB"].NewRow();

                        dr["LoaiBaoCao"] = "CẮT HỦY";
                        dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                        dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                        dr["SoPhieu"] = item.Cells["MaTB"].Value.ToString().Insert(item.Cells["MaTB"].Value.ToString().Length - 2, "-");
                        dr["CreateDate"] = item.Cells["CreateDate"].Value.ToString();
                        dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(7, " ").Insert(4, " ");
                        dr["HoTen"] = item.Cells["HoTen"].Value.ToString();
                        dr["DiaChi"] = item.Cells["DiaChi"].Value.ToString();
                        dr["LyDo"] = item.Cells["LyDo"].Value.ToString();
                        dr["NgayXuLy"] = item.Cells["NgayXuLyCHDB"].Value.ToString();
                        dr["NoiDungXuLy"] = item.Cells["NoiDungXuLy"].Value.ToString();
                        dsBaoCao.Tables["ThongBaoCHDB"].Rows.Add(dr);
                    }


        }

        private void btnInDS_Click_1(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            if (radDSCatTamDanhBo.Checked)
                for (int i = 0; i < dgvDSCTCHDB.Rows.Count; i++)
                    if (dgvDSCTCHDB["In", i].Value != null && bool.Parse(dgvDSCTCHDB["In", i].Value.ToString()) == true)
                    {
                        DataRow dr = dsBaoCao.Tables["ThongBaoCHDB"].NewRow();

                        CHDB_ChiTietCatTam ctctdb = _cCHDB.GetCTCTDB(decimal.Parse(dgvDSCTCHDB["MaTB", i].Value.ToString()));

                        dr["Quan"] = _cCHDB.getTenQuan(int.Parse(ctctdb.Quan));
                        dr["Phuong"] = _cCHDB.getTenPhuong(int.Parse(ctctdb.Quan), int.Parse(ctctdb.Phuong));
                        dr["HoTen"] = ctctdb.HoTen;
                        dr["DiaChi"] = ctctdb.DiaChi;
                        if (!string.IsNullOrEmpty(ctctdb.DanhBo))
                            dr["DanhBo"] = ctctdb.DanhBo.Insert(7, " ").Insert(4, " ");

                        if (ctctdb.LyDo != "Vấn Đề Khác")
                            dr["LyDo"] = ctctdb.LyDo + ". ";
                        if (ctctdb.GhiChuLyDo != "")
                            dr["LyDo"] += ctctdb.GhiChuLyDo + ". ";
                        if (ctctdb.SoTien.ToString() != "")
                            dr["LyDo"] += "Tổng Số Tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", ctctdb.SoTien);

                        dr["TenPhong"] = CTaiKhoan.TenPhong;

                        dsBaoCao.Tables["ThongBaoCHDB"].Rows.Add(dr);    
                    }
            if (radDSCatHuyDanhBo.Checked)
                for (int i = 0; i < dgvDSCTCHDB.Rows.Count; i++)
                    if (dgvDSCTCHDB["In", i].Value != null && bool.Parse(dgvDSCTCHDB["In", i].Value.ToString()) == true)
                    {
                        DataRow dr = dsBaoCao.Tables["ThongBaoCHDB"].NewRow();

                        CHDB_ChiTietCatHuy ctchdb = _cCHDB.GetCTCHDB(decimal.Parse(dgvDSCTCHDB["MaTB", i].Value.ToString()));

                        dr["Quan"] = _cCHDB.getTenQuan(int.Parse(ctchdb.Quan));
                        dr["Phuong"] = _cCHDB.getTenPhuong(int.Parse(ctchdb.Quan), int.Parse(ctchdb.Phuong));
                        dr["HoTen"] = ctchdb.HoTen;
                        dr["DiaChi"] = ctchdb.DiaChi;
                        if (!string.IsNullOrEmpty(ctchdb.DanhBo))
                            dr["DanhBo"] = ctchdb.DanhBo.Insert(7, " ").Insert(4, " ");
                        dr["HopDong"] = ctchdb.HopDong;

                        dr["ViTriDHN"] = "Vị trí ĐHN lắp đặt: " + ctchdb.ViTriDHN1 + ", " + ctchdb.ViTriDHN2;

                        if (ctchdb.LyDo != "Vấn Đề Khác")
                            dr["LyDo"] = ctchdb.LyDo + ". ";
                        if (ctchdb.GhiChuLyDo != "")
                            dr["LyDo"] += ctchdb.GhiChuLyDo + ". ";
                        if (ctchdb.SoTien.ToString() != "")
                            dr["LyDo"] += "Tổng Số Tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,## đồng}", ctchdb.SoTien);

                        dr["TenPhong"] = CTaiKhoan.TenPhong;

                        dsBaoCao.Tables["ThongBaoCHDB"].Rows.Add(dr);
                    }
            rptCHDB_BienNhan rpt = new rptCHDB_BienNhan();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

    }
}
