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
using KTKS_DonKH.DAL.QuanTri;
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
        //DataRowView _CTRow = null;
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();
        string _tuNgay = "", _denNgay = "";

        public frmDSKTXM()
        {
            InitializeComponent();
        }

        private void frmKTXM_Load(object sender, EventArgs e)
        {
            dgvDSCTKTXM.AutoGenerateColumns = false;
            dateTimKiem.Location = txtNoiDungTimKiem.Location;
            //txtNoiDungTimKiem2.Location=txtNoiDungTimKiem.Location;

            cmbTimTheo.SelectedItem = "Ngày";
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
        /// Format dữ liệu trong column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSKTXM_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSCTKTXM.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null)
                    e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                case "Danh Bộ":
                case "Số Công Văn":
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
                    //DSDon_BS.RemoveFilter();
                    break;
            }
            dgvDSCTKTXM.DataSource = null;
        }

        private void txtNoiDungTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtNoiDungTimKiem2.Text = "";
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
                                        //if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                                        //    dgvDSCTKTXM.DataSource = _cKTXM.LoadDSCTKTXMByMaDonTXL(decimal.Parse(txtNoiDungTimKiem.Text.Trim().ToUpper().Replace("-", "").Replace("T", "").Replace("X", "").Replace("L", "")));
                                        //else
                                        //    dgvDSCTKTXM.DataSource = _cKTXM.LoadDSCTKTXMByMaDon(decimal.Parse(txtNoiDungTimKiem.Text.Trim().ToUpper().Replace("-", "").Replace("T", "").Replace("X", "").Replace("L", "")));
                                        dgvDSCTKTXM.DataSource = _cKTXM.LoadDSCTKTXMByMaDon(CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().ToUpper().Replace("-", "").Replace("T", "").Replace("X", "").Replace("L", "")));
                            break;
                        case "Danh Bộ":
                                        //dgvDSCTKTXM.DataSource = _cKTXM.LoadDSCTKTXMByDanhBo(txtNoiDungTimKiem.Text.Trim());
                                        dgvDSCTKTXM.DataSource = _cKTXM.LoadDSCTKTXMByDanhBo(CTaiKhoan.MaUser, txtNoiDungTimKiem.Text.Trim());
                            break;
                        case "Số Công Văn":
                                //dgvDSCTKTXM.DataSource = _cKTXM.LoadDSCTKTXMBySoCongVan(txtNoiDungTimKiem.Text.Trim());
                                dgvDSCTKTXM.DataSource = _cKTXM.LoadDSCTKTXMBySoCongVan(CTaiKhoan.MaUser, txtNoiDungTimKiem.Text.Trim());
                            break;
                    }
                }
            }
            catch (Exception)
            {

            }

        }

        private void txtNoiDungTimKiem2_TextChanged(object sender, EventArgs e)
        {
            if (txtNoiDungTimKiem.Text.Trim() != "" && txtNoiDungTimKiem2.Text.Trim() != "")
            {
                switch (cmbTimTheo.SelectedItem.ToString())
                {
                    case "Mã Đơn":
                                    //if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                                    //    dgvDSCTKTXM.DataSource = _cKTXM.LoadDSCTKTXMByMaDonsTXL(decimal.Parse(txtNoiDungTimKiem.Text.Trim().ToUpper().Replace("-", "").Replace("T", "").Replace("X", "").Replace("L", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().ToUpper().Replace("-", "").Replace("T", "").Replace("X", "").Replace("L", "")));
                                    //else
                                    //    dgvDSCTKTXM.DataSource = _cKTXM.LoadDSCTKTXMByMaDons(decimal.Parse(txtNoiDungTimKiem.Text.Trim().ToUpper().Replace("-", "").Replace("T", "").Replace("X", "").Replace("L", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().ToUpper().Replace("-", "").Replace("T", "").Replace("X", "").Replace("L", "")));
                                    dgvDSCTKTXM.DataSource = _cKTXM.LoadDSCTKTXMByMaDons(CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().ToUpper().Replace("-", "").Replace("T", "").Replace("X", "").Replace("L", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().ToUpper().Replace("-", "").Replace("T", "").Replace("X", "").Replace("L", "")));
                        break;
                }
            }
        }

        private void dateTimKiem_ValueChanged(object sender, EventArgs e)
        {
                    //string expression = String.Format("NgayKTXM >= #{0:yyyy-MM-dd} 00:00:00# and NgayKTXM <= #{0:yyyy-MM-dd} 23:59:59#", dateTimKiem.Value);
                    //DSDon_BS.Filter = expression;
                    _tuNgay = dateTimKiem.Value.ToString("dd/MM/yyyy");
                        //dgvDSCTKTXM.DataSource = _cKTXM.LoadDSCTKTXMByDate(dateTimKiem.Value);
                        dgvDSCTKTXM.DataSource = _cKTXM.LoadDSCTKTXMByDate(CTaiKhoan.MaUser, dateTimKiem.Value);
        }

        private void btnIn_Click(object sender, EventArgs e)
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
                    if (_cTaiKhoan.GetByID(int.Parse(itemRow["MaU"].ToString())).ToKH)
                        dr["To"] = "TKH";
                    else
                        if (_cTaiKhoan.GetByID(int.Parse(itemRow["MaU"].ToString())).ToXuLy)
                            dr["To"] = "TXL";

                    dsBaoCao.Tables["DSKTXM"].Rows.Add(dr);
                }
                rptDSKTXM rpt = new rptDSKTXM();
                rpt.SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.ShowDialog();
        }

        private void dateTu_ValueChanged(object sender, EventArgs e)
        {
                    //string expression = String.Format("NgayKTXM >= #{0:yyyy-MM-dd} 00:00:00# and NgayKTXM <= #{0:yyyy-MM-dd} 23:59:59#", dateTu.Value);
                    //DSDon_BS.Filter = expression;
                    _tuNgay = dateTu.Value.ToString("dd/MM/yyyy");
                    _denNgay = "";
                        //dgvDSCTKTXM.DataSource = _cKTXM.LoadDSCTKTXMByDate(dateTu.Value);
                        dgvDSCTKTXM.DataSource = _cKTXM.LoadDSCTKTXMByDate(CTaiKhoan.MaUser, dateTu.Value);
        }

        private void dateDen_ValueChanged(object sender, EventArgs e)
        {
                    //string expression = String.Format("NgayKTXM >= #{0:yyyy-MM-dd} 00:00:00# and NgayKTXM <= #{1:yyyy-MM-dd} 23:59:59#", dateTu.Value, dateDen.Value);
                    //DSDon_BS.Filter = expression;
                    _denNgay = dateDen.Value.ToString("dd/MM/yyyy");
                        //dgvDSCTKTXM.DataSource = _cKTXM.LoadDSCTKTXMByDates(dateTu.Value, dateDen.Value);
                        dgvDSCTKTXM.DataSource = _cKTXM.LoadDSCTKTXMByDates(CTaiKhoan.MaUser, dateTu.Value, dateDen.Value);
        }

        private void btnInThongKe_Click(object sender, EventArgs e)
        {
                DataTable dt = ((DataTable)dgvDSCTKTXM.DataSource).DefaultView.ToTable();
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                foreach (DataRow itemRow in dt.Rows)
                    if (radToKH.Checked)
                    {
                        if (itemRow["ToXuLy"].ToString() == "False")
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
                            if (_cTaiKhoan.GetByID(int.Parse(itemRow["MaU"].ToString())).ToKH)
                                dr["To"] = "TKH";
                            else
                                if (_cTaiKhoan.GetByID(int.Parse(itemRow["MaU"].ToString())).ToXuLy)
                                    dr["To"] = "TXL";

                            dsBaoCao.Tables["DSKTXM"].Rows.Add(dr);
                        }
                    }
                    else
                        if (radToXuLy.Checked)
                        {
                            if (itemRow["ToXuLy"].ToString() == "True")
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
                                if (_cTaiKhoan.GetByID(int.Parse(itemRow["MaU"].ToString())).ToKH)
                                    dr["To"] = "TKH";
                                else
                                    if (_cTaiKhoan.GetByID(int.Parse(itemRow["MaU"].ToString())).ToXuLy)
                                        dr["To"] = "TXL";

                                dsBaoCao.Tables["DSKTXM"].Rows.Add(dr);
                            }
                        }
                if (chkLoaiDon.Checked)
                {
                    rptThongKeDSKTXM_LoaiDon rpt = new rptThongKeDSKTXM_LoaiDon();
                    rpt.SetDataSource(dsBaoCao);
                    rpt.Subreports[0].SetDataSource(dsBaoCao);
                    frmShowBaoCao frm = new frmShowBaoCao(rpt);
                    frm.ShowDialog();
                }
                else
                {
                    rptThongKeDSKTXM rpt = new rptThongKeDSKTXM();
                    rpt.SetDataSource(dsBaoCao);
                    rpt.Subreports[0].SetDataSource(dsBaoCao);
                    frmShowBaoCao frm = new frmShowBaoCao(rpt);
                    frm.ShowDialog();
                }
        }


    }
}