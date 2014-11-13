using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.ToXuLy;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.HeThong;

namespace KTKS_DonKH.GUI.ToXuLy
{
    public partial class frmQLDonTXL : Form
    {
        BindingSource DSDonKH_BS = new BindingSource();
        CChuyenDi _cChuyenDi = new CChuyenDi();
        CDonTXL _cDonTXL = new CDonTXL();
        string _tuNgay = "", _denNgay = "";
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();

        public frmQLDonTXL()
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

        private void frmQLDonTXL_Load(object sender, EventArgs e)
        {
            dgvDSDonTXL.AutoGenerateColumns = false;
            dgvDSDonTXL.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSDonTXL.Font, FontStyle.Bold);
            DataGridViewComboBoxColumn cmbColumn = (DataGridViewComboBoxColumn)dgvDSDonTXL.Columns["MaChuyen"];
            cmbColumn.DataSource = _cChuyenDi.LoadDSChuyenDi();
            cmbColumn.DisplayMember = "NoiChuyenDi";
            cmbColumn.ValueMember = "MaChuyen";

            dgvDSDonTXL.DataSource = DSDonKH_BS;
            radAll.Checked = true;

            cmbTimTheo.SelectedIndex = 6;
            dateTimKiem.Location = txtNoiDungTimKiem.Location;
        }

        private void radDaDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radDaChuyen.Checked)
            {
                DSDonKH_BS.DataSource = _cDonTXL.LoadDSDonTXLDaChuyen();
                cmbTimTheo.SelectedIndex = 0;
            }
        }

        private void radChuaDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radChuaChuyen.Checked)
            {
                DSDonKH_BS.DataSource = _cDonTXL.LoadDSDonTXLChuaChuyen();
                cmbTimTheo.SelectedIndex = 0;
            }
        }

        private void radAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radAll.Checked)
            {
                DSDonKH_BS.DataSource = _cDonTXL.LoadDSAllDonTXL();
                cmbTimTheo.SelectedIndex = 0;
            }
        }

        private void dgvDSDonTXL_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSDonTXL.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSDonTXL_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDSDonTXL.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                Dictionary<string, string> source = new Dictionary<string, string>();
                source.Add("Action", "Cập Nhật");
                source.Add("MaDon", dgvDSDonTXL["MaDon", dgvDSDonTXL.CurrentRow.Index].Value.ToString());
                frmShowDonTXL frm = new frmShowDonTXL(source);
                if (frm.ShowDialog() == DialogResult.OK)
                    if (radChuaChuyen.Checked)
                        DSDonKH_BS.DataSource = _cDonTXL.LoadDSDonTXLChuaChuyen();
                    else
                        if (radDaChuyen.Checked)
                            DSDonKH_BS.DataSource = _cDonTXL.LoadDSDonTXLDaChuyen();
                        else
                            if (radAll.Checked)
                                DSDonKH_BS.DataSource = _cDonTXL.LoadDSAllDonTXL();
            }
        }

        private void dgvDSDonTXL_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DonTXL dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(dgvDSDonTXL["MaDon", e.RowIndex].Value.ToString()));
            dontxl.Chuyen = true;
            if (string.IsNullOrEmpty(dgvDSDonTXL["MaChuyen", e.RowIndex].Value.ToString()))
                dontxl.MaChuyen = "NONE";
            else
                dontxl.MaChuyen = dgvDSDonTXL["MaChuyen", e.RowIndex].Value.ToString();
            dontxl.LyDoChuyen = dgvDSDonTXL["LyDoChuyen", e.RowIndex].Value.ToString();
            //if (string.IsNullOrEmpty(dgvDSDonTXL["SoLuongDiaChi", e.RowIndex].ToString()))
            //    dontxl.SoLuongDiaChi = null;
            //else
            //    dontxl.SoLuongDiaChi = int.Parse(dgvDSDonTXL["SoLuongDiaChi", e.RowIndex].ToString());
            //dontxl.NVKiemTra = dgvDSDonTXL["NVKiemTra", e.RowIndex].ToString();
            _cDonTXL.SuaDonTXL(dontxl);
        }

        private void dgvDSDonTXL_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSDonTXL.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null)
            {
                e.Value = "TXL"+e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (dgvDSDonTXL.Columns[e.ColumnIndex].Name == "NguoiDi" && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.Value = _cTaiKhoan.getHoTenUserbyID(int.Parse(e.Value.ToString()));
            }
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                case "Danh Bộ":
                case "Địa Chỉ":
                case "Số Công Văn":
                    txtNoiDungTimKiem.Visible = true;
                    dateTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Ngày Lập":
                    txtNoiDungTimKiem.Visible = false;
                    dateTimKiem.Visible = true;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Khoảng Thời Gian":
                    txtNoiDungTimKiem.Visible = false;
                    dateTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = true;
                    break;
                default:
                    txtNoiDungTimKiem.Visible = false;
                    dateTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    DSDonKH_BS.RemoveFilter();
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
                        expression = String.Format("MaDon = {0}", txtNoiDungTimKiem.Text.Trim().ToUpper().Replace("-", "").Replace("TXL",""));
                        break;
                    case "Số Công Văn":
                        expression = String.Format("SoCongVan like '{0}%'", txtNoiDungTimKiem.Text.Trim().ToUpper());
                        break;
                    case "Danh Bộ":
                        expression = String.Format("DanhBo like '{0}%'", txtNoiDungTimKiem.Text.Trim().ToUpper());
                        break;
                    case "Địa Chỉ":
                        expression = String.Format("DiaChi like '{0}%'", txtNoiDungTimKiem.Text.Trim().ToUpper());
                        break;
                }
                DSDonKH_BS.Filter = expression;
            }
            else
                DSDonKH_BS.RemoveFilter();
        }

        private void dateTimKiem_ValueChanged(object sender, EventArgs e)
        {
            string expression = String.Format("CreateDate > #{0:yyyy-MM-dd} 00:00:00# and CreateDate < #{0:yyyy-MM-dd} 23:59:59#", dateTimKiem.Value);
            DSDonKH_BS.Filter = expression;
            _tuNgay = dateTimKiem.Value.ToString("dd/MM/yyyy");
            _denNgay = "";
        }

        private void dateTu_ValueChanged(object sender, EventArgs e)
        {
            string expression = String.Format("CreateDate > #{0:yyyy-MM-dd} 00:00:00# and CreateDate < #{0:yyyy-MM-dd} 23:59:59#", dateTu.Value);
            DSDonKH_BS.Filter = expression;
            _tuNgay = dateTu.Value.ToString("dd/MM/yyyy");
            _denNgay = "";
        }

        private void dateDen_ValueChanged(object sender, EventArgs e)
        {
            string expression = String.Format("CreateDate > #{0:yyyy-MM-dd} 00:00:00# and CreateDate < #{1:yyyy-MM-dd} 23:59:59#", dateTu.Value, dateDen.Value);
            DSDonKH_BS.Filter = expression;
            _denNgay = dateDen.Value.ToString("dd/MM/yyyy");
        }

        private void btnInDSDonKH_Click(object sender, EventArgs e)
        {
            DataTable dt = ((DataTable)DSDonKH_BS.DataSource).DefaultView.ToTable();
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Ngày Lập":
                    dt = _cDonTXL.LoadDSDonTXLDaChuyenKT(dateTimKiem.Value);
                    break;
                case "Khoảng Thời Gian":
                    dt = _cDonTXL.LoadDSDonTXLDaChuyenKT(dateTu.Value, dateDen.Value);
                    break;
                case "Số Công Văn":
                    dt = _cDonTXL.LoadDSDonTXLbySoCongVan(txtNoiDungTimKiem.Text.Trim().ToUpper());
                    break;
            }
            
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataRow itemRow in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DSDonTXL"].NewRow();

                dr["TuNgay"] = _tuNgay;
                dr["DenNgay"] = _denNgay;
                //dr["MaLD"] = itemRow["MaLD"];
                dr["TenLD"] = itemRow["TenLD"];
                dr["SoCongVan"] = itemRow["SoCongVan"];
                dr["NgayNhan"] = itemRow["CreateDate"].ToString().Substring(0, 10);
                DonTXL dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(itemRow["MaDon"].ToString()));
                dr["MaDon"] = "TXL" + itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-");
                dr["TenLD"] = dontxl.LoaiDonTXL.TenLD;

                if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                    dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = itemRow["HoTen"];
                dr["DiaChi"] = itemRow["DiaChi"];
                dr["NoiDung"] = itemRow["NoiDung"];
                if (!string.IsNullOrEmpty(itemRow["NguoiDi"].ToString()))
                {
                    dr["NguoiDi"] = _cTaiKhoan.getHoTenUserbyID(int.Parse(itemRow["NguoiDi"].ToString()));
                    dr["DaGiaiQuyet"] = _cDonTXL.CheckGiaiQuyetbyUser(int.Parse(itemRow["NguoiDi"].ToString()), dontxl.MaDon).ToString();
                }

                dsBaoCao.Tables["DSDonTXL"].Rows.Add(dr);
            }

            rptDSDonTXL rpt = new rptDSDonTXL();
            rpt.SetDataSource(dsBaoCao);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }
    }
}
