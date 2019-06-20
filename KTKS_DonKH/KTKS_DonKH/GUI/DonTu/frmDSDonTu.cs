using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.DonTu;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.DonTu;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.DonTu
{
    public partial class frmDSDonTu : Form
    {
        CDonTu _cDonTu = new CDonTu();
        CNoiChuyen _cNoiChuyen = new CNoiChuyen();
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();
        CPhongBanDoi _cPhongBanDoi = new CPhongBanDoi();

        //DataSet _dsNoiChuyen = new DataSet("NoiChuyen");

        public frmDSDonTu()
        {
            InitializeComponent();
        }

        private void frmDSDonTu_Load(object sender, EventArgs e)
        {
            dgvDSDonTu.AutoGenerateColumns = false;

            if (CTaiKhoan.Admin)
            {
                lbPhong.Visible = true;
                cmbPhong.Visible = true;
                DataTable dt = _cPhongBanDoi.getDS_ConfigChuongTrinh();
                DataRow dr = dt.NewRow();
                dr["ID"] = 0;
                dr["Name"] = "Tất Cả";
                dt.Rows.InsertAt(dr, 0);
                cmbPhong.DataSource = dt;
                cmbPhong.ValueMember = "ID";
                cmbPhong.DisplayMember = "Name";
            }
            else
            {
                lbPhong.Visible = false;
                cmbPhong.Visible = false;
            }

            //repositoryItemLookUpEdit1.DataSource = _cNoiChuyen.GetDS("DonTu");
            //repositoryItemLookUpEdit1.DisplayMember = "Name";
            //repositoryItemLookUpEdit1.ValueMember = "ID";

            //DataTable dt = new DataTable();
            //dt = new DataTable();
            //dt = _cTaiKhoan.GetDS_ThuKy("TKH");
            //dt.TableName = "2";//Tổ Khách Hàng
            //_dsNoiChuyen.Tables.Add(dt);
            /////
            //dt = new DataTable();
            //dt = _cTaiKhoan.GetDS_ThuKy("TXL");
            //dt.TableName = "3";//Tổ Xử Lý
            //_dsNoiChuyen.Tables.Add(dt);
            /////
            //dt = new DataTable();
            //dt = _cTaiKhoan.GetDS_ThuKy("TBC");
            //dt.TableName = "4";//Tổ Bấm Chì
            //_dsNoiChuyen.Tables.Add(dt);
            /////
            //dt = new DataTable();
            //dt = _cTaiKhoan.GetDS_ThuKy("TVP");
            //dt.TableName = "5";//Tổ Văn Phòng
            //_dsNoiChuyen.Tables.Add(dt);
            /////
            //dt = new DataTable();
            //dt = _cPhongBanDoi.GetDS();
            //dt.TableName = "6";//Phòng Ban Đội Khác
            //_dsNoiChuyen.Tables.Add(dt);

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
                    //txtNoiDungTimKiem2.Visible = true;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Ngày":
                    txtNoiDungTimKiem.Visible = false;
                    //txtNoiDungTimKiem2.Visible = false;
                    panel_KhoangThoiGian.Visible = true;
                    break;
                default:
                    txtNoiDungTimKiem.Visible = false;
                    //txtNoiDungTimKiem2.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    break;
            }
            dgvDSDonTu.DataSource = null;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.Admin == true)
            {
                if(cmbPhong.SelectedIndex==0)
                switch (cmbTimTheo.SelectedItem.ToString())
                {
                    case "Mã Đơn":
                        //if (txtNoiDungTimKiem.Text.Trim() != "" && txtNoiDungTimKiem2.Text.Trim() != "")
                        //    dgvDSDonTu.DataSource = _cDonTu.getDS(int.Parse(txtNoiDungTimKiem.Text.Trim()), int.Parse(txtNoiDungTimKiem2.Text.Trim()));
                        //else
                        if (txtNoiDungTimKiem.Text.Trim() != "")
                            dgvDSDonTu.DataSource = _cDonTu.getDS(int.Parse(txtNoiDungTimKiem.Text.Trim()));
                        break;
                    case "Danh Bộ":
                        if (txtNoiDungTimKiem.Text.Trim() != "")
                            dgvDSDonTu.DataSource = _cDonTu.getDS_ChiTiet_ByDanhBo(txtNoiDungTimKiem.Text.Trim().Replace(" ", ""));
                        break;
                    case "Số Công Văn":
                        if (txtNoiDungTimKiem.Text.Trim() != "")
                            dgvDSDonTu.DataSource = _cDonTu.getDSBySoCongVan(txtNoiDungTimKiem.Text.Trim().ToUpper());
                        break;
                    case "Ngày":
                        dgvDSDonTu.DataSource = _cDonTu.getDS(dateTu.Value, dateDen.Value);
                        //gridControl1.DataSource = _cDonTu.GetDS(dateTu.Value, dateDen.Value);
                        break;
                    default:
                        break;
                }
                else
                    if(cmbPhong.SelectedIndex>0)
                        switch (cmbTimTheo.SelectedItem.ToString())
                        {
                            case "Mã Đơn":
                                //if (txtNoiDungTimKiem.Text.Trim() != "" && txtNoiDungTimKiem2.Text.Trim() != "")
                                //    dgvDSDonTu.DataSource = _cDonTu.getDS(int.Parse(txtNoiDungTimKiem.Text.Trim()), int.Parse(txtNoiDungTimKiem2.Text.Trim()));
                                //else
                                if (txtNoiDungTimKiem.Text.Trim() != "")
                                    dgvDSDonTu.DataSource = _cDonTu.getDS(int.Parse(txtNoiDungTimKiem.Text.Trim()), int.Parse(cmbPhong.SelectedValue.ToString()));
                                break;
                            case "Danh Bộ":
                                if (txtNoiDungTimKiem.Text.Trim() != "")
                                    dgvDSDonTu.DataSource = _cDonTu.getDS_ChiTiet_ByDanhBo(txtNoiDungTimKiem.Text.Trim().Replace(" ", ""), int.Parse(cmbPhong.SelectedValue.ToString()));
                                break;
                            case "Số Công Văn":
                                if (txtNoiDungTimKiem.Text.Trim() != "")
                                    dgvDSDonTu.DataSource = _cDonTu.getDSBySoCongVan(txtNoiDungTimKiem.Text.Trim().ToUpper(), int.Parse(cmbPhong.SelectedValue.ToString()));
                                break;
                            case "Ngày":
                                dgvDSDonTu.DataSource = _cDonTu.getDS(dateTu.Value, dateDen.Value, int.Parse(cmbPhong.SelectedValue.ToString()));
                                //gridControl1.DataSource = _cDonTu.GetDS(dateTu.Value, dateDen.Value);
                                break;
                            default:
                                break;
                        }
            }
            else
            {
                switch (cmbTimTheo.SelectedItem.ToString())
                {
                    case "Mã Đơn":
                        //if (txtNoiDungTimKiem.Text.Trim() != "" && txtNoiDungTimKiem2.Text.Trim() != "")
                        //    dgvDSDonTu.DataSource = _cDonTu.getDS(int.Parse(txtNoiDungTimKiem.Text.Trim()), int.Parse(txtNoiDungTimKiem2.Text.Trim()));
                        //else
                        if (txtNoiDungTimKiem.Text.Trim() != "")
                            dgvDSDonTu.DataSource = _cDonTu.getDS(int.Parse(txtNoiDungTimKiem.Text.Trim()), CTaiKhoan.MaPhong);
                        break;
                    case "Danh Bộ":
                        if (txtNoiDungTimKiem.Text.Trim() != "")
                            dgvDSDonTu.DataSource = _cDonTu.getDS_ChiTiet_ByDanhBo(txtNoiDungTimKiem.Text.Trim().Replace(" ", ""), CTaiKhoan.MaPhong);
                        break;
                    case "Số Công Văn":
                        if (txtNoiDungTimKiem.Text.Trim() != "")
                            dgvDSDonTu.DataSource = _cDonTu.getDSBySoCongVan(txtNoiDungTimKiem.Text.Trim().ToUpper(), CTaiKhoan.MaPhong);
                        break;
                    case "Ngày":
                        dgvDSDonTu.DataSource = _cDonTu.getDS(dateTu.Value, dateDen.Value, CTaiKhoan.MaPhong);
                        //gridControl1.DataSource = _cDonTu.GetDS(dateTu.Value, dateDen.Value);
                        break;
                    default:
                        break;
                }
            }
        }

        private void dgvDSDonTu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSDonTu.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null && e.Value.ToString().Length ==11)
            {
                e.Value = e.Value.ToString().Insert(7, " ").Insert(4, " ");
            }
        }

        private void dgvDSDonTu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSDonTu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSDonTu_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDSDonTu.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                frmNhanDonTu frm = new frmNhanDonTu(int.Parse(dgvDSDonTu["MaDon", dgvDSDonTu.CurrentRow.Index].Value.ToString()));
                frm.ShowDialog();
            }
        }

        private void btnInDSDon_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataGridViewRow item in dgvDSDonTu.Rows)
            {
                    DataRow dr = dsBaoCao.Tables["CongVan"].NewRow();

                    dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                    dr["Ma"] = item.Cells["MaDon"].Value.ToString();
                    dr["CreateDate"] = item.Cells["CreateDate"].Value.ToString();
                    if (item.Cells["DanhBo"].Value.ToString().Length == 11)
                        dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(7, " ").Insert(4, " ");
                    dr["DiaChi"] = item.Cells["DiaChi"].Value.ToString();
                    dr["NoiDung"] = item.Cells["NoiDung"].Value.ToString();
                    dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();

                    dsBaoCao.Tables["CongVan"].Rows.Add(dr);
            }
            rptDSChuyenDonTu rpt = new rptDSChuyenDonTu();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        
    }
}
