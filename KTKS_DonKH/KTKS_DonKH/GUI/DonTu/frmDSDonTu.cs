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

namespace KTKS_DonKH.GUI.DonTu
{
    public partial class frmDSDonTu : Form
    {
        CDonTu _cDonTu = new CDonTu();
        CNoiChuyen _cNoiChuyen = new CNoiChuyen();
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();
        CPhongBanDoi _cPhongBanDoi = new CPhongBanDoi();

        DataSet _dsNoiChuyen = new DataSet("NoiChuyen");

        public frmDSDonTu()
        {
            InitializeComponent();
        }

        private void frmDSDonTu_Load(object sender, EventArgs e)
        {
            dgvDSDonTu.AutoGenerateColumns = false;

            repositoryItemLookUpEdit1.DataSource = _cNoiChuyen.GetDS("DonTu");
            repositoryItemLookUpEdit1.DisplayMember = "Name";
            repositoryItemLookUpEdit1.ValueMember = "ID";

                DataTable dt = new DataTable();
            dt = new DataTable();
            dt = _cTaiKhoan.GetDS_ThuKy("TKH");
            dt.TableName = "2";//Tổ Khách Hàng
            _dsNoiChuyen.Tables.Add(dt);
            ///
            dt = new DataTable();
            dt = _cTaiKhoan.GetDS_ThuKy("TXL");
            dt.TableName = "3";//Tổ Xử Lý
            _dsNoiChuyen.Tables.Add(dt);
            ///
            dt = new DataTable();
            dt = _cTaiKhoan.GetDS_ThuKy("TBC");
            dt.TableName = "4";//Tổ Bấm Chì
            _dsNoiChuyen.Tables.Add(dt);
            ///
            dt = new DataTable();
            dt = _cTaiKhoan.GetDS_ThuKy("TVP");
            dt.TableName = "5";//Tổ Văn Phòng
            _dsNoiChuyen.Tables.Add(dt);
            ///
            dt = new DataTable();
            dt = _cPhongBanDoi.GetDS();
            dt.TableName = "6";//Phòng Ban Đội Khác
            _dsNoiChuyen.Tables.Add(dt);

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
            dgvDSDonTu.DataSource = null;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                    if (txtNoiDungTimKiem.Text.Trim() != "" && txtNoiDungTimKiem2.Text.Trim() != "")
                        dgvDSDonTu.DataSource = _cDonTu.GetDS(int.Parse(txtNoiDungTimKiem.Text.Trim()), int.Parse(txtNoiDungTimKiem2.Text.Trim()));
                    else
                        if (txtNoiDungTimKiem.Text.Trim() != "")
                            dgvDSDonTu.DataSource = _cDonTu.GetDS(int.Parse(txtNoiDungTimKiem.Text.Trim()));
                    break;
                case "Danh Bộ":
                    if (txtNoiDungTimKiem.Text.Trim() != "")
                        dgvDSDonTu.DataSource = _cDonTu.GetDSByDanhBo(txtNoiDungTimKiem.Text.Trim().Replace(" ",""));
                    break;
                case "Số Công Văn":
                    if (txtNoiDungTimKiem.Text.Trim() != "")
                        dgvDSDonTu.DataSource = _cDonTu.GetDSBySoCongVan(txtNoiDungTimKiem.Text.Trim().ToUpper());
                    break;
                case "Ngày":
                    dgvDSDonTu.DataSource = _cDonTu.GetDS(dateTu.Value, dateDen.Value);
                    //gridControl1.DataSource = _cDonTu.GetDS(dateTu.Value, dateDen.Value);
                    break;
                default:
                    break;
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

        
    }
}
