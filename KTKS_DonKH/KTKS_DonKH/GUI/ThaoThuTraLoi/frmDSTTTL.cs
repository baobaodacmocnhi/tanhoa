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
using KTKS_DonKH.GUI.ToXuLy;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.ThaoThuTraLoi
{
    public partial class frmDSTTTL : Form
    {
        CTTTL _cTTTL = new CTTTL();
        CDonKH _cDonKH = new CDonKH();
        CKTXM _cKTXM = new CKTXM();
        DataTable DSTTTL_Edited = new DataTable();
        //BindingSource DSTTTL_BS;
        string _tuNgay = "", _denNgay = "";

        public frmDSTTTL()
        {
            InitializeComponent();
        }

        private void frmDSTTTL_Load(object sender, EventArgs e)
        {
            dgvDSThu.AutoGenerateColumns = false;

            dateTimKiem.Location = txtNoiDungTimKiem.Location;
        }

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
            if (cttttl.ThuDuocKy != ischecked || cttttl.GhiChu != dgvDSThu["GhiChu", e.RowIndex].Value.ToString())
            {
                cttttl.ThuDuocKy = ischecked;
                cttttl.GhiChu = dgvDSThu["GhiChu", e.RowIndex].Value.ToString();
                _cTTTL.SuaCTTTTL(cttttl);
            }
        }

        #endregion

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                case "Mã Thư":
                case "Danh Bộ":
                    txtNoiDungTimKiem.Visible = true;
                    txtNoiDungTimKiem2.Visible = true;
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
                    //DSTTTL_BS.RemoveFilter();
                    break;
            }
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
                //            if (radDaDuyet.Checked || radDSThu.Checked)
                //                expression = String.Format("MaDon = {0}", txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                //            if (radDaDuyet_TXL.Checked || radDSThu_TXL.Checked)
                //                expression = String.Format("MaDon = {0}", txtNoiDungTimKiem.Text.Trim().Replace("-", "").Replace("TXL", ""));
                //            break;
                //        case "Mã Thư":
                //            expression = String.Format("MaCTTTTL = {0}", txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                //            break;
                //        case "Danh Bộ":
                //            expression = String.Format("DanhBo like '{0}%'", txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                //            break;
                //    }
                //    DSTTTL_BS.Filter = expression;
                //}
                //else
                //    DSTTTL_BS.RemoveFilter();
                if (txtNoiDungTimKiem.Text.Trim() != "")
                {
                    txtNoiDungTimKiem2.Text = "";
                    switch (cmbTimTheo.SelectedItem.ToString())
                    {
                        case "Mã Đơn":
                                    dgvDSThu.DataSource = _cTTTL.LoadDSCTTTTLByMaDon(decimal.Parse(txtNoiDungTimKiem.Text.Trim().ToUpper().Replace("-", "").Replace("T", "").Replace("X", "").Replace("L", "")));
                            break;
                        case "Mã Thư":
                                    dgvDSThu.DataSource = _cTTTL.LoadDSCTTTTLByMaTB(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                            break;
                        case "Danh Bộ":
                                    dgvDSThu.DataSource = _cTTTL.LoadDSCTTTTLByDanhBo(txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
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
            //string expression = String.Format("CreateDate > #{0:yyyy-MM-dd} 00:00:00# and CreateDate < #{0:yyyy-MM-dd} 23:59:59#", dateTimKiem.Value);
            //DSTTTL_BS.Filter = expression;
                    dgvDSThu.DataSource = _cTTTL.LoadDSCTTTTLByDate(dateTimKiem.Value);
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
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
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
                            if (!string.IsNullOrEmpty(cttttl.DanhBo))
                                dr["DanhBo"] = cttttl.DanhBo.Insert(7, " ").Insert(4, " ");
                            dr["HopDong"] = cttttl.HopDong;
                            dr["GiaBieu"] = cttttl.GiaBieu;
                            dr["DinhMuc"] = cttttl.DinhMuc;
                            if (cttttl.TTTL.ToXuLy)
                                dr["NgayNhanDon"] = cttttl.TTTL.DonTXL.CreateDate.Value.ToString("dd/MM/yyyy");
                            else
                                dr["NgayNhanDon"] = cttttl.TTTL.DonKH.CreateDate.Value.ToString("dd/MM/yyyy");
                            dr["VeViec"] = cttttl.VeViec;
                            dr["NoiDung"] = cttttl.NoiDung;
                            dr["NoiNhan"] = cttttl.NoiNhan;
                            dr["ChucVu"] = cttttl.ChucVu;
                            dr["NguoiKy"] = cttttl.NguoiKy;

                            dsBaoCao.Tables["ThaoThuTraLoi"].Rows.Add(dr);

                            rptThaoThuTraLoi rpt = new rptThaoThuTraLoi();
                            rpt.SetDataSource(dsBaoCao);

                            printDialog.AllowSomePages = true;
                            printDialog.ShowHelp = true;

                            rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                            rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
                            rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;

                            rpt.PrintToPrinter(1, false, 0, 0);
                        }
                }
            }
        }

        private void dateTu_ValueChanged(object sender, EventArgs e)
        {
                    //string expression = String.Format("CreateDate >= #{0:yyyy-MM-dd} 00:00:00# and CreateDate <= #{0:yyyy-MM-dd} 23:59:59#", dateTu.Value);
                    //DSTTTL_BS.Filter = expression;
                    _tuNgay = dateTu.Value.ToString("dd/MM/yyyy");
                    _denNgay = "";
                    dgvDSThu.DataSource = _cTTTL.LoadDSCTTTTLByDate(dateTu.Value);
        }

        private void dateDen_ValueChanged(object sender, EventArgs e)
        {
                    //string expression = String.Format("CreateDate >= #{0:yyyy-MM-dd} 00:00:00# and CreateDate <= #{1:yyyy-MM-dd} 23:59:59#", dateTu.Value, dateDen.Value);
                    //DSTTTL_BS.Filter = expression;
                    _denNgay = dateDen.Value.ToString("dd/MM/yyyy");
                    dgvDSThu.DataSource = _cTTTL.LoadDSCTTTTLByDates(dateTu.Value,dateDen.Value);
        }

        private void btnInNhan_Click(object sender, EventArgs e)
        {
                DataSetBaoCao dsBaoCao1 = new DataSetBaoCao();
                DataSetBaoCao dsBaoCao2 = new DataSetBaoCao();
                bool flag = true;
                for (int i = 0; i < dgvDSThu.Rows.Count; i++)
                    if (bool.Parse(dgvDSThu["In", i].Value.ToString()) == true)
                        if (flag)
                        {
                            DataRow dr = dsBaoCao1.Tables["ThaoThuTraLoi"].NewRow();

                            CTTTTL cttttl = _cTTTL.getCTTTTLbyID(decimal.Parse(dgvDSThu["MaCTTTTL", i].Value.ToString()));
                            dr["HoTen"] = cttttl.HoTen;
                            dr["DiaChi"] = cttttl.DiaChi;

                            dsBaoCao1.Tables["ThaoThuTraLoi"].Rows.Add(dr);
                            flag = false;
                        }
                        else
                        {
                            DataRow dr = dsBaoCao2.Tables["ThaoThuTraLoi"].NewRow();

                            CTTTTL cttttl = _cTTTL.getCTTTTLbyID(decimal.Parse(dgvDSThu["MaCTTTTL", i].Value.ToString()));
                            dr["HoTen"] = cttttl.HoTen;
                            dr["DiaChi"] = cttttl.DiaChi;

                            dsBaoCao2.Tables["ThaoThuTraLoi"].Rows.Add(dr);
                            flag = true;
                        }
                rptKinhGui rpt = new rptKinhGui();
                rpt.Subreports[0].SetDataSource(dsBaoCao1);
                rpt.Subreports[1].SetDataSource(dsBaoCao2);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.ShowDialog();
        }

        private void txtNoiDungTimKiem2_TextChanged(object sender, EventArgs e)
        {
            if (txtNoiDungTimKiem.Text.Trim() != "" && txtNoiDungTimKiem.Text.Trim().Length > 2 && txtNoiDungTimKiem2.Text.Trim() != "" && txtNoiDungTimKiem2.Text.Trim().Length > 2)
            {
                    dgvDSThu.DataSource = _cTTTL.LoadDSCTTTTLByMaTBs(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Replace("-", "")));
            }
        }


    }
}
