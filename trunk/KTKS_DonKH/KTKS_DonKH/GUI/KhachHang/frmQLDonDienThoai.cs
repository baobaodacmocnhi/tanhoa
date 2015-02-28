using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.KhachHang;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.KhachHang
{
    public partial class frmQLDonDienThoai : Form
    {
        CDonDienThoai _cDonDT = new CDonDienThoai();
        CDonKH _cDonKH = new CDonKH();
        CLoaiDon _cLoaiDon = new CLoaiDon();

        string _tuNgay = "", _denNgay = "";

        public frmQLDonDienThoai()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void frmQLDonDienThoai_Load(object sender, EventArgs e)
        {
            dgvDonDT.AutoGenerateColumns = false;

            DataGridViewComboBoxColumn cmbColumn = (DataGridViewComboBoxColumn)dgvDonDT.Columns["MaLD"];
            cmbColumn.DataSource = _cLoaiDon.LoadDSLoaiDon(true);
            cmbColumn.DisplayMember = "TenLD";
            cmbColumn.ValueMember = "MaLD";

            dateTimKiem.Location = txtNoiDungTimKiem.Location;
            cmbTimTheo.SelectedIndex = 0;
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                case "Danh Bộ":
                case "Số Công Văn":
                    txtNoiDungTimKiem.Visible = true;
                    dateTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Ngày":
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
                    //DSDonKH_BS.RemoveFilter();
                    break;
            }
            dgvDonDT.DataSource = null;
        }

        private void txtNoiDungTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtNoiDungTimKiem.Text.Trim() != "")
            {
                switch (cmbTimTheo.SelectedItem.ToString())
                {
                    //case "Mã Đơn":
                    //    dgvDSDonKH.DataSource = _cDonKH.LoadDSDonKHByMaDon(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                    //    break;
                    //case "Danh Bộ":
                    //    dgvDSDonKH.DataSource = _cDonKH.LoadDSDonKHByDanhBo(txtNoiDungTimKiem.Text.Trim());
                    //    break;
                    //case "Số Công Văn":
                    //    dgvDSDonKH.DataSource = _cDonKH.LoadDSDonKHBySoCongVan(txtNoiDungTimKiem.Text.Trim().ToUpper());
                    //    break;
                }
            }
        }

        private void dateTimKiem_ValueChanged(object sender, EventArgs e)
        {
            _tuNgay = dateTimKiem.Value.ToString("dd/MM/yyyy");
            _denNgay = "";
            dgvDonDT.DataSource = _cDonDT.getDSDonDienThoaiByDate(dateTimKiem.Value);
        }

        private void dateTu_ValueChanged(object sender, EventArgs e)
        {
            _tuNgay = dateTimKiem.Value.ToString("dd/MM/yyyy");
            _denNgay = "";
            dgvDonDT.DataSource = _cDonDT.getDSDonDienThoaiByDate(dateTimKiem.Value);
        }

        private void dateDen_ValueChanged(object sender, EventArgs e)
        {
            _denNgay = dateDen.Value.ToString("dd/MM/yyyy");
            dgvDonDT.DataSource = _cDonDT.getDSDonDienThoaiByDates(dateTu.Value, dateDen.Value);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            DataTable dt = ((DataTable)dgvDonDT.DataSource).DefaultView.ToTable();
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataRow itemRow in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DSDonDienThoai"].NewRow();

                dr["TuNgay"] = _tuNgay;
                dr["DenNgay"] = _denNgay;
                //dr["NgayNhan"] = itemRow["CreateDate"].ToString().Substring(0, 10);
                if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                    dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = itemRow["HoTen"];
                dr["DiaChi"] = itemRow["DiaChi"];
                dr["NoiDung"] = itemRow["NoiDung"];
                dr["DienThoai"] = itemRow["DienThoai"];
                dr["NguoiBao"] = itemRow["NguoiBao"];

                dsBaoCao.Tables["DSDonDienThoai"].Rows.Add(dr);
            }

            rptDSDonDienThoai rpt = new rptDSDonDienThoai();
            rpt.SetDataSource(dsBaoCao);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnInDaLapDon_Click(object sender, EventArgs e)
        {
            DataTable dt = ((DataTable)dgvDonDT.DataSource).DefaultView.ToTable();
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataRow itemRow in dt.Rows)
                if (!string.IsNullOrEmpty(itemRow["MaDon"].ToString()))
                {
                    DataRow dr = dsBaoCao.Tables["DSDonDienThoai"].NewRow();

                    dr["TuNgay"] = _tuNgay;
                    dr["DenNgay"] = _denNgay;
                    //dr["NgayNhan"] = itemRow["CreateDate"].ToString().Substring(0, 10);
                    dr["MaDon"] = itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-");
                    if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                        dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                    dr["HoTen"] = itemRow["HoTen"];
                    dr["DiaChi"] = itemRow["DiaChi"];
                    dr["NoiDung"] = itemRow["NoiDung"];
                    dr["DienThoai"] = itemRow["DienThoai"];
                    dr["NguoiBao"] = itemRow["NguoiBao"];

                    dsBaoCao.Tables["DSDonDienThoai"].Rows.Add(dr);
                }

            rptDSDonDienThoai rpt = new rptDSDonDienThoai();
            rpt.SetDataSource(dsBaoCao);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnLapDon_Click(object sender, EventArgs e)
        {
            try
            {
                _cDonKH.beginTransaction();
                foreach (DataGridViewRow item in dgvDonDT.Rows)
                    if (bool.Parse(item.Cells["LapDon"].Value.ToString()))
                    {
                        DonDienThoai dondt = _cDonDT.getDonDienThoaibyID(decimal.Parse(item.Cells["MaDonDT"].Value.ToString()));
                        DonKH donkh = new DonKH();
                        donkh.MaDon = _cDonKH.getMaxNextID();
                        donkh.MaLD = int.Parse(item.Cells["MaLD"].Value.ToString());
                        donkh.TongSoDanhBo = 1;
                        donkh.NoiDung = dondt.NoiDung;

                        donkh.DanhBo = dondt.DanhBo;
                        donkh.HopDong = dondt.HopDong;
                        donkh.HoTen = dondt.HoTen;
                        donkh.DiaChi = dondt.DiaChi;
                        donkh.DienThoai = dondt.DienThoai;
                        donkh.MSThue = dondt.MSThue;
                        donkh.GiaBieu = dondt.GiaBieu;
                        donkh.DinhMuc = dondt.DinhMuc;
                        donkh.Dot = dondt.Dot;
                        donkh.Ky = dondt.Ky;
                        donkh.Nam = dondt.Nam;

                        if (_cDonKH.ThemDonKH(donkh))
                        {
                            dondt.MaDon = donkh.MaDon;
                            _cDonDT.SuaDonDienThoai(dondt);
                        }
                    }
                _cDonKH.commitTransaction();
                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                _cDonKH.rollback();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
