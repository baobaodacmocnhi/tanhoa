using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.ToKhachHang;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using KTKS_DonKH.GUI.ToKhachHang;
using KTKS_DonKH.LinQ;
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
        CKTXM _cKTXM = new CKTXM();
        CDonKH _cDonKH = new CDonKH();
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();

        public frmDSKTXM()
        {
            InitializeComponent();
        }
        
        private void frmKTXM_Load(object sender, EventArgs e)
        {
            dgvDSCTKTXM.AutoGenerateColumns = false;

            cmbTimTheo.SelectedItem = "Ngày";
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
            dgvDSCTKTXM.DataSource = null;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                    if (txtNoiDungTimKiem.Text.Trim() != "" && txtNoiDungTimKiem2.Text.Trim() != "")
                        MessageBox.Show("Liên hệ BảoBảo", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        if (txtNoiDungTimKiem.Text.Trim() != "")
                            if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                                dgvDSCTKTXM.DataSource = _cKTXM.GetDS("TXL", CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                            else
                                if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TBC"))
                                    dgvDSCTKTXM.DataSource = _cKTXM.GetDS("TBC", CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                else
                                    dgvDSCTKTXM.DataSource = _cKTXM.GetDS("TKH", CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                    break;
                case "Danh Bộ":
                    if (txtNoiDungTimKiem.Text.Trim() != "")
                        dgvDSCTKTXM.DataSource = _cKTXM.GetDS_DanhBo(CTaiKhoan.MaUser, txtNoiDungTimKiem.Text.Trim());
                    break;
                case "Số Công Văn":
                    if (txtNoiDungTimKiem.Text.Trim() != "")
                        dgvDSCTKTXM.DataSource = _cKTXM.GetDS_SoCongVan(CTaiKhoan.MaUser, txtNoiDungTimKiem.Text.Trim());
                    break;
                case "Ngày":
                    if (CTaiKhoan.ThuKy)
                    {
                        if (CTaiKhoan.ToKH)
                            dgvDSCTKTXM.DataSource = _cKTXM.GetDS("TKH", dateTu.Value, dateDen.Value);
                        else
                            if (CTaiKhoan.ToXL)
                                dgvDSCTKTXM.DataSource = _cKTXM.GetDS("TXL", dateTu.Value, dateDen.Value);
                            else
                                if (CTaiKhoan.ToBC)
                                    dgvDSCTKTXM.DataSource = _cKTXM.GetDS("TBC", dateTu.Value, dateDen.Value);
                    }
                    else
                        dgvDSCTKTXM.DataSource = _cKTXM.GetDS(CTaiKhoan.MaUser, dateTu.Value, dateDen.Value);
                    break;
                default:
                    break;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            DataTable dt = ((DataTable)dgvDSCTKTXM.DataSource).DefaultView.ToTable();
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataRow itemRow in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DSKTXM"].NewRow();

                dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
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
                    if (_cTaiKhoan.GetByID(int.Parse(itemRow["MaU"].ToString())).ToXL)
                        dr["To"] = "TXL";

                dsBaoCao.Tables["DSKTXM"].Rows.Add(dr);
            }
            rptDSKTXM rpt = new rptDSKTXM();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void dgvDSDonKH_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSCTKTXM.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSKTXM_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDSCTKTXM.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                frmKTXM frm = new frmKTXM(decimal.Parse(dgvDSCTKTXM["MaCTKTXM", dgvDSCTKTXM.CurrentRow.Index].Value.ToString()));
                frm.ShowDialog();
            }
        }

        private void dgvDSKTXM_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSCTKTXM.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null)
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
        }


    }
}