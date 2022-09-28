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
using KTKS_DonKH.DAL.DonTu;

namespace KTKS_DonKH.GUI.KiemTraXacMinh
{
    public partial class frmDSKTXM : Form
    {
        CKTXM _cKTXM = new CKTXM();
        CTo _cTo = new CTo();
        CDonKH _cDonKH = new CDonKH();
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();
        CDonTu _cDonTu = new CDonTu();

        public frmDSKTXM()
        {
            InitializeComponent();
        }

        private void frmKTXM_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;

            cmbTimTheo.SelectedItem = "Ngày";

            if (CTaiKhoan.TruongPhong == true)
            {
                lbTo.Visible = true;
                cmbTo.Visible = true;
                List<To> lst = _cTo.getDS_KTXM();
                To to = new To();
                to.MaTo = 0;
                to.TenTo = "Tất Cả";
                lst.Insert(0, to);
                cmbTo.DataSource = lst;
                cmbTo.DisplayMember = "TenTo";
                cmbTo.ValueMember = "MaTo";
            }
            else
            {
                lbTo.Visible = false;
                cmbTo.Visible = false;
            }
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
            dgvDanhSach.DataSource = null;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (radKTXM.Checked == true)
                if (CTaiKhoan.TruongPhong == true)
                {
                    if (cmbTo.SelectedIndex == 0)
                        switch (cmbTimTheo.SelectedItem.ToString())
                        {
                            case "Mã Đơn":
                                if (txtNoiDungTimKiem.Text.Trim() != "" && txtNoiDungTimKiem2.Text.Trim() != "")
                                    MessageBox.Show("Liên hệ BảoBảo", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    if (txtNoiDungTimKiem.Text.Trim() != "")
                                        if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TKH"))
                                            dgvDanhSach.DataSource = _cKTXM.getDS("TKH", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                        else
                                            if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                                                dgvDanhSach.DataSource = _cKTXM.getDS("TXL", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                            else
                                                if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TBC"))
                                                    dgvDanhSach.DataSource = _cKTXM.getDS("TBC", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                                else
                                                    dgvDanhSach.DataSource = _cKTXM.getDS("", decimal.Parse(txtNoiDungTimKiem.Text.Trim()));
                                break;
                            case "Danh Bộ":
                                if (txtNoiDungTimKiem.Text.Trim() != "")
                                    dgvDanhSach.DataSource = _cKTXM.getDS_ByDanhBo(txtNoiDungTimKiem.Text.Trim());
                                break;
                            case "Số Công Văn":
                                if (txtNoiDungTimKiem.Text.Trim() != "")
                                    dgvDanhSach.DataSource = _cKTXM.getDS_BySoCongVan(txtNoiDungTimKiem.Text.Trim());
                                break;
                            case "Ngày":
                                dgvDanhSach.DataSource = _cKTXM.getDS(dateTu.Value, dateDen.Value);
                                break;
                        }
                    else
                        switch (cmbTimTheo.SelectedItem.ToString())
                        {
                            case "Mã Đơn":
                                if (txtNoiDungTimKiem.Text.Trim() != "" && txtNoiDungTimKiem2.Text.Trim() != "")
                                    MessageBox.Show("Liên hệ BảoBảo", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    if (txtNoiDungTimKiem.Text.Trim() != "")
                                        if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TKH"))
                                            dgvDanhSach.DataSource = _cKTXM.getDS("TKH", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                        else
                                            if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                                                dgvDanhSach.DataSource = _cKTXM.getDS("TXL", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                            else
                                                if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TBC"))
                                                    dgvDanhSach.DataSource = _cKTXM.getDS("TBC", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                                else
                                                    dgvDanhSach.DataSource = _cKTXM.getDS("", decimal.Parse(txtNoiDungTimKiem.Text.Trim()));
                                break;
                            case "Danh Bộ":
                                if (txtNoiDungTimKiem.Text.Trim() != "")
                                    dgvDanhSach.DataSource = _cKTXM.getDS_To_ByDanhBo(int.Parse(cmbTo.SelectedValue.ToString()), txtNoiDungTimKiem.Text.Trim());
                                break;
                            case "Số Công Văn":
                                if (txtNoiDungTimKiem.Text.Trim() != "")
                                    dgvDanhSach.DataSource = _cKTXM.getDS_To_BySoCongVan(int.Parse(cmbTo.SelectedValue.ToString()), txtNoiDungTimKiem.Text.Trim());
                                break;
                            case "Ngày":
                                dgvDanhSach.DataSource = _cKTXM.getDS_To(int.Parse(cmbTo.SelectedValue.ToString()), dateTu.Value, dateDen.Value);
                                break;
                        }
                }
                else if (CTaiKhoan.ToTruong == true || CTaiKhoan.ThuKy == true)
                {
                    switch (cmbTimTheo.SelectedItem.ToString())
                    {
                        case "Mã Đơn":
                            if (txtNoiDungTimKiem.Text.Trim() != "" && txtNoiDungTimKiem2.Text.Trim() != "")
                                MessageBox.Show("Liên hệ BảoBảo", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                if (txtNoiDungTimKiem.Text.Trim() != "")
                                    if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TKH"))
                                        dgvDanhSach.DataSource = _cKTXM.getDS("TKH", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                    else
                                        if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                                            dgvDanhSach.DataSource = _cKTXM.getDS("TXL", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                        else
                                            if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TBC"))
                                                dgvDanhSach.DataSource = _cKTXM.getDS("TBC", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                            else
                                                dgvDanhSach.DataSource = _cKTXM.getDS("", decimal.Parse(txtNoiDungTimKiem.Text.Trim()));
                            break;
                        case "Danh Bộ":
                            if (txtNoiDungTimKiem.Text.Trim() != "")
                                dgvDanhSach.DataSource = _cKTXM.getDS_To_ByDanhBo(CTaiKhoan.MaTo, txtNoiDungTimKiem.Text.Trim());
                            break;
                        case "Số Công Văn":
                            if (txtNoiDungTimKiem.Text.Trim() != "")
                                dgvDanhSach.DataSource = _cKTXM.getDS_To_BySoCongVan(CTaiKhoan.MaTo, txtNoiDungTimKiem.Text.Trim());
                            break;
                        case "Ngày":
                            dgvDanhSach.DataSource = _cKTXM.getDS_To(CTaiKhoan.MaTo, dateTu.Value, dateDen.Value);
                            break;
                    }
                }
                else
                {
                    switch (cmbTimTheo.SelectedItem.ToString())
                    {
                        case "Mã Đơn":
                            if (txtNoiDungTimKiem.Text.Trim() != "" && txtNoiDungTimKiem2.Text.Trim() != "")
                                MessageBox.Show("Liên hệ BảoBảo", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                if (txtNoiDungTimKiem.Text.Trim() != "")
                                    if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TKH"))
                                        dgvDanhSach.DataSource = _cKTXM.getDS("TKH", CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                    else
                                        if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                                            dgvDanhSach.DataSource = _cKTXM.getDS("TXL", CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                        else
                                            if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TBC"))
                                                dgvDanhSach.DataSource = _cKTXM.getDS("TBC", CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                            else
                                                dgvDanhSach.DataSource = _cKTXM.getDS("", CTaiKhoan.MaUser, decimal.Parse(txtNoiDungTimKiem.Text.Trim()));
                            break;
                        case "Danh Bộ":
                            if (txtNoiDungTimKiem.Text.Trim() != "")
                                dgvDanhSach.DataSource = _cKTXM.getDS_ByDanhBo(CTaiKhoan.MaUser, txtNoiDungTimKiem.Text.Trim());
                            break;
                        case "Số Công Văn":
                            if (txtNoiDungTimKiem.Text.Trim() != "")
                                dgvDanhSach.DataSource = _cKTXM.getDS_BySoCongVan(CTaiKhoan.MaUser, txtNoiDungTimKiem.Text.Trim());
                            break;
                        case "Ngày":
                            dgvDanhSach.DataSource = _cKTXM.getDS(CTaiKhoan.MaUser, dateTu.Value, dateDen.Value);
                            break;
                    }
                }
            else
                if (radNhanDon.Checked == true)
                    if (CTaiKhoan.TruongPhong == true)
                        dgvDanhSach.DataSource = _cDonTu.getDS_ChuyenKTXM_KyNhan_Phong(dateTu.Value, dateDen.Value);
                    else if (CTaiKhoan.ToTruong == true || CTaiKhoan.ThuKy == true)
                        dgvDanhSach.DataSource = _cDonTu.getDS_ChuyenKTXM_KyNhan_To(CTaiKhoan.MaTo, dateTu.Value, dateDen.Value);
                    else
                        dgvDanhSach.DataSource = _cDonTu.getDS_ChuyenKTXM_KyNhan_NV(CTaiKhoan.MaUser, dateTu.Value, dateDen.Value);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            DataTable dt = ((DataTable)dgvDanhSach.DataSource).DefaultView.ToTable();
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataRow itemRow in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DSKTXM"].NewRow();

                dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                dr["TenLD"] = itemRow["TenLD"];
                dr["MaCTKTXM"] = itemRow["MaCTKTXM"];
                dr["MaDon"] = itemRow["MaDon"].ToString();
                if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                    dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = itemRow["HoTen"];
                dr["DiaChi"] = itemRow["DiaChi"];
                dr["NoiDungKiemTra"] = itemRow["NoiDungKiemTra"];
                dr["NguoiLap"] = CTaiKhoan.HoTen;
                dr["NgayLapBangGia"] = itemRow["NgayKTXM"];
                dr["NgayDongTienBoiThuong"] = itemRow["CreateBy"];

                dsBaoCao.Tables["DSKTXM"].Rows.Add(dr);
            }
            rptKTXM rpt = new rptKTXM();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void dgvDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDanhSach_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDanhSach.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                frmKTXM frm = new frmKTXM(decimal.Parse(dgvDanhSach["MaCTKTXM", dgvDanhSach.CurrentRow.Index].Value.ToString()));
                frm.ShowDialog();
            }
        }

        private void dgvDanhSach_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (dgvDSCTKTXM.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null)
            //    e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
        }

        private void radKTXM_CheckedChanged(object sender, EventArgs e)
        {
            if (radKTXM.Checked == true)
            {
                dgvDanhSach.Columns["NgayKTXM"].Visible = true;
                dgvDanhSach.Columns["NoiDungKiemTra"].Visible = true;
                //dgvDanhSach.Columns["CreateBy"].Visible = true;
                dgvDanhSach.Columns["Nhan"].Visible = false;
                dgvDanhSach.Columns["NgayNhan"].Visible = false;
            }
        }

        private void radNhanDon_CheckedChanged(object sender, EventArgs e)
        {
            if (radNhanDon.Checked == true)
            {
                dgvDanhSach.DataSource = null;
                dgvDanhSach.Columns["NgayKTXM"].Visible = false;
                dgvDanhSach.Columns["NoiDungKiemTra"].Visible = false;
                //dgvDanhSach.Columns["CreateBy"].Visible = false;
                dgvDanhSach.Columns["Nhan"].Visible = true;
                dgvDanhSach.Columns["NgayNhan"].Visible = true;
            }
        }

        private void dgvDanhSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDanhSach.Columns[e.ColumnIndex].Name == "Nhan" && CTaiKhoan.TruongPhong == false && CTaiKhoan.ToTruong == false)
            {
                if (bool.Parse(dgvDanhSach["Nhan", e.RowIndex].Value.ToString()) == true)
                    _cDonTu.ExecuteNonQuery("update DonTu_LichSu set Nhan=1,NgayNhan=getdate() where ID=" + dgvDanhSach["ID", e.RowIndex].Value.ToString());
                else
                    _cDonTu.ExecuteNonQuery("update DonTu_LichSu set Nhan=0,NgayNhan=NULL where ID=" + dgvDanhSach["ID", e.RowIndex].Value.ToString());
            }
        }


    }
}