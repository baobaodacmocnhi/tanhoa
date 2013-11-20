using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmCatChuyenDM : Form
    {
        Dictionary<string, string> _source = new Dictionary<string, string>();
        CChiNhanh _cChiNhanh = new CChiNhanh();
        CLoaiChungTu _cLoaiChungTu = new CLoaiChungTu();
        TTKhachHang _ttkhachhang = new TTKhachHang();
        CTTKH _cTTKH = new CTTKH();
        CChungTu _cChungTu = new CChungTu();

        public frmCatChuyenDM()
        {
            InitializeComponent();
        }

        public frmCatChuyenDM(Dictionary<string, string> source)
        {
            InitializeComponent();
            _source = source;
        }

        private void frmCatChuyenDM_Load(object sender, EventArgs e)
        {
            this.Location = new Point(70, 70);
            cmbChiNhanh_Cat.DataSource = _cChiNhanh.LoadDSChiNhanh(true);
            cmbChiNhanh_Cat.DisplayMember = "TenCN";
            cmbChiNhanh_Cat.ValueMember = "MaCN";

            cmbChiNhanh_Nhan.DataSource = _cChiNhanh.LoadDSChiNhanh(true);
            cmbChiNhanh_Nhan.DisplayMember = "TenCN";
            cmbChiNhanh_Nhan.ValueMember = "MaCN";
            cmbChiNhanh_Nhan.SelectedIndex = -1;

            cmbLoaiCT_Cat.DataSource = _cLoaiChungTu.LoadDSLoaiChungTu(true);
            cmbLoaiCT_Cat.DisplayMember = "TenLCT";
            cmbLoaiCT_Cat.ValueMember = "MaLCT";

            txtDanhBo_Cat.Text=_source["DanhBo"];
            txtHoTen_Cat.Text = _source["HoTen"];
            txtDiaChi_Cat.Text = _source["DiaChi"];
            cmbLoaiCT_Cat.SelectedValue = int.Parse(_source["MaLCT"]);
            txtMaCT_Cat.Text = _source["MaCT"];
        }

        /// <summary>
        /// Nhận Entity TTKhachHang để điền vào textbox
        /// </summary>
        /// <param name="ttkhachhang"></param>
        public void LoadDS(TTKhachHang ttkhachhang)
        {
            txtDanhBo_Nhan.Text = ttkhachhang.DanhBo;
            txtHoTen_Nhan.Text = ttkhachhang.HoTen;
            txtDiaChi_Nhan.Text = ttkhachhang.DC1 + " " + ttkhachhang.DC2;
        }

        public void Clear()
        {
            txtDanhBo_Nhan.Text = "";
            txtHoTen_Nhan.Text = "";
            txtDiaChi_Nhan.Text = "";
        }

        private void txtDanhBo_Nhan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;

            if (e.KeyChar == 13 && ((ChiNhanh)cmbChiNhanh_Nhan.SelectedItem).TenCN.ToUpper().Contains("TÂN HÒA") && txtDanhBo_Cat.Text.Trim() != txtDanhBo_Nhan.Text.Trim())
            {
                if (_cTTKH.getTTKHbyID(txtDanhBo_Nhan.Text.Trim()) != null)
                    LoadDS(_cTTKH.getTTKHbyID(txtDanhBo_Nhan.Text.Trim()));
                else
                    Clear();
            }
        }

        private void txtSoNK_Cat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtSoNK_Cat.Text.Trim() != "" && txtSoNK_Cat.Text.Trim() != "0" && cmbChiNhanh_Nhan.SelectedIndex != -1)
            {
                if (int.Parse(_source["SoNKDangKy"]) >= int.Parse(txtSoNK_Cat.Text.Trim()))
                {
                    CTChungTu ctchungtuCat = new CTChungTu();
                    ctchungtuCat.DanhBo = _source["DanhBo"];
                    ctchungtuCat.MaCT = _source["MaCT"];

                    CTChungTu ctchungtuNhan = new CTChungTu();
                    ctchungtuNhan.DanhBo = txtDanhBo_Nhan.Text.Trim();
                    ctchungtuNhan.MaCT = _source["MaCT"];

                    int SoNKCat = int.Parse(txtSoNK_Cat.Text.Trim());

                    LichSuChungTu lichsuchungtu = new LichSuChungTu();
                    lichsuchungtu.MaDon = decimal.Parse(_source["MaDon"]);
                    lichsuchungtu.SoPhieu = _cChungTu.getMaxNextSoPhieuLSCT();
                    lichsuchungtu.CatDM = true;
                    lichsuchungtu.CatNK_DanhBo = txtDanhBo_Cat.Text.Trim();
                    lichsuchungtu.CatNK_HoTen = txtHoTen_Cat.Text.Trim();
                    lichsuchungtu.CatNK_DiaChi = txtDiaChi_Cat.Text.Trim();
                    lichsuchungtu.NhanNK_MaCN = int.Parse(cmbChiNhanh_Nhan.SelectedValue.ToString());
                    lichsuchungtu.NhanNK_DanhBo = txtDanhBo_Nhan.Text.Trim();
                    lichsuchungtu.NhanNK_HoTen = txtHoTen_Nhan.Text.Trim();
                    lichsuchungtu.NhanNK_DiaChi = txtDiaChi_Nhan.Text.Trim();
                    lichsuchungtu.SoNKCat = int.Parse(txtSoNK_Cat.Text.Trim());

                    if (_cChungTu.CatChuyenChungTu(ctchungtuCat, ctchungtuNhan, int.Parse(txtSoNK_Cat.Text.Trim()), lichsuchungtu))
                    {
                        if (!((ChiNhanh)cmbChiNhanh_Nhan.SelectedItem).TenCN.ToUpper().Contains("TÂN HÒA"))
                        {
                            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                            DataRow dr = dsBaoCao.Tables["PhieuCatChuyenDM"].NewRow();

                            dr["SoPhieu"] = lichsuchungtu.SoPhieu.ToString().Insert(4, "-");
                            dr["ChiNhanh"] = ((ChiNhanh)cmbChiNhanh_Nhan.SelectedItem).TenCN;
                            dr["DanhBoNhan"] = txtDanhBo_Nhan.Text.Trim();
                            dr["HoTenNhan"] = txtHoTen_Nhan.Text.Trim();
                            dr["DiaChiNhan"] = txtDiaChi_Nhan.Text.Trim();
                            dr["DanhBoCat"] = txtDanhBo_Cat.Text.Trim();
                            dr["HoTenCat"] = txtHoTen_Cat.Text.Trim();
                            dr["DiaChiCat"] = txtDiaChi_Cat.Text.Trim();
                            dr["SoNKCat"] = txtSoNK_Cat.Text.Trim() + " nhân khẩu (HK: " + txtMaCT_Cat.Text.Trim() + ")";

                            dsBaoCao.Tables["PhieuCatChuyenDM"].Rows.Add(dr);

                            rptPhieuYCNhanDM rpt = new rptPhieuYCNhanDM();
                            rpt.SetDataSource(dsBaoCao);
                            frmBaoCao frm = new frmBaoCao(rpt);
                            frm.ShowDialog();
                        }

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                    MessageBox.Show("Cắt vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Bạn chưa nhập Số NK Cắt hoặc chưa chọn Chi Nhánh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


    }
}
