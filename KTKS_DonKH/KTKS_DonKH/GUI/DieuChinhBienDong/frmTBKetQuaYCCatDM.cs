using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.DieuChinhBienDong;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmTBKetQuaYCCatDM : Form
    {
        CChiNhanh _cChiNhanh = new CChiNhanh();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        CTBKetQuaYCCatDM _cTB = new CTBKetQuaYCCatDM();
        int _selectedindex = -1;

        public frmTBKetQuaYCCatDM()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            txtDanhBo_Cat.Text = "";
            txtHoTen_Cat.Text = "";
            txtDiaChi_Cat.Text = "";
            txtMaCT_Cat.Text = "";
            txtSoNK_Cat.Text = "";
            cmbChiNhanh_Nhan.SelectedIndex = -1;
            txtDanhBo_Nhan.Text = "";
            txtHoTen_Nhan.Text = "";
            txtDiaChi_Nhan.Text = "";
            txtSoPhieuNhan.Text = "";
            dateNhan.Value = DateTime.Now;
            txtGhiChu.Text = "";
            _selectedindex = -1;
        }

        private void frmTBKetQuaYCCatDM_Load(object sender, EventArgs e)
        {
            dgvDSTBKetQuaYCCatDM.AutoGenerateColumns = false;
            dgvDSTBKetQuaYCCatDM.DataSource = _cTB.LoadDSTBKetQuaYCCatDM();

            cmbChiNhanh_Nhan.DataSource = _cChiNhanh.LoadDSChiNhanh();
            cmbChiNhanh_Nhan.DisplayMember = "TenCN";
            cmbChiNhanh_Nhan.ValueMember = "MaCN";
            cmbChiNhanh_Nhan.SelectedIndex = -1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            TBKetQuaYCCatDM tb = new TBKetQuaYCCatDM();
            tb.PYC = txtPYC.Text.Trim();
            tb.SoPhieuNhan = txtSoPhieuNhan.Text.Trim();
            tb.NgayNhan = dateNhan.Value;
            tb.CatNK_DanhBo = txtDanhBo_Cat.Text.Trim();
            tb.CatNK_HoTen = txtHoTen_Cat.Text.Trim();
            tb.CatNK_DiaChi = txtDiaChi_Cat.Text.Trim();
            tb.MaCT = txtMaCT_Cat.Text.Trim();
            tb.NhanNK_MaCN = int.Parse(cmbChiNhanh_Nhan.SelectedValue.ToString());
            tb.NhanNK_DanhBo = txtDanhBo_Nhan.Text.Trim();
            tb.NhanNK_HoTen = txtHoTen_Nhan.Text.Trim();
            tb.NhanNK_DiaChi = txtDiaChi_Nhan.Text.Trim();
            tb.SoNKCat = int.Parse(txtSoNK_Cat.Text.Trim());
            tb.GhiChu = txtGhiChu.Text.Trim();
            ///Ký Tên
            BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                tb.ChucVu = "GIÁM ĐỐC";
            else
                tb.ChucVu = "KT.GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
            tb.NguoiKy = bangiamdoc.HoTen.ToUpper();
            tb.PhieuDuocKy = true;

            if (_cTB.ThemTBKetQuaYCCatDM(tb))
            {
                dgvDSTBKetQuaYCCatDM.DataSource = _cTB.LoadDSTBKetQuaYCCatDM();
                Clear();
            }
        }

        private void dgvDSTBKetQuaYCCatDM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _selectedindex = e.RowIndex;
                txtPYC.Text = dgvDSTBKetQuaYCCatDM["PYC", e.RowIndex].Value.ToString();
                txtDanhBo_Cat.Text = dgvDSTBKetQuaYCCatDM["CatNK_DanhBo", e.RowIndex].Value.ToString();
                txtHoTen_Cat.Text = dgvDSTBKetQuaYCCatDM["CatNK_HoTen", e.RowIndex].Value.ToString();
                txtDiaChi_Cat.Text = dgvDSTBKetQuaYCCatDM["CatNK_DiaChi", e.RowIndex].Value.ToString();
                txtMaCT_Cat.Text = dgvDSTBKetQuaYCCatDM["MaCT", e.RowIndex].Value.ToString();
                txtSoNK_Cat.Text = dgvDSTBKetQuaYCCatDM["SoNKCat", e.RowIndex].Value.ToString();
                cmbChiNhanh_Nhan.SelectedValue = int.Parse(dgvDSTBKetQuaYCCatDM["NhanNK_MaCN", e.RowIndex].Value.ToString());
                txtDanhBo_Nhan.Text = dgvDSTBKetQuaYCCatDM["NhanNK_DanhBo", e.RowIndex].Value.ToString();
                txtHoTen_Nhan.Text = dgvDSTBKetQuaYCCatDM["NhanNK_HoTen", e.RowIndex].Value.ToString();
                txtDiaChi_Nhan.Text = dgvDSTBKetQuaYCCatDM["NhanNK_DiaChi", e.RowIndex].Value.ToString();
                txtSoPhieuNhan.Text = dgvDSTBKetQuaYCCatDM["SoPhieuNhan", e.RowIndex].Value.ToString();
                dateNhan.Value = DateTime.Parse(dgvDSTBKetQuaYCCatDM["NgayNhan", e.RowIndex].Value.ToString());
                txtGhiChu.Text = dgvDSTBKetQuaYCCatDM["GhiChu", e.RowIndex].Value.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_selectedindex != -1)
            {
                TBKetQuaYCCatDM tb = _cTB.GetTBKetQuaYCCatDMByID(decimal.Parse(dgvDSTBKetQuaYCCatDM["SoPhieu", _selectedindex].Value.ToString()));
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["PhieuCatChuyenDM"].NewRow();

                dr["SoPhieu"] = tb.SoPhieu.ToString().Insert(tb.SoPhieu.ToString().Length - 2, "-");
                dr["ChiNhanh"] = _cChiNhanh.getTenChiNhanhbyID(tb.NhanNK_MaCN.Value);
                if (!string.IsNullOrEmpty(tb.NhanNK_DanhBo))
                    dr["DanhBoNhan"] = tb.NhanNK_DanhBo.Insert(7, " ").Insert(4, " ");
                dr["HoTenNhan"] = tb.NhanNK_HoTen;
                dr["DiaChiNhan"] = tb.NhanNK_DiaChi;
                if (!string.IsNullOrEmpty(tb.CatNK_DanhBo))
                    dr["DanhBoCat"] = tb.CatNK_DanhBo.Insert(7, " ").Insert(4, " ");
                dr["HoTenCat"] = tb.CatNK_HoTen;
                dr["DiaChiCat"] = tb.CatNK_DiaChi;
                dr["SoNKCat"] = tb.SoNKCat + " nhân khẩu (HK: " + tb.MaCT + ")";

                dr["SoPhieuNhan"] = tb.SoPhieuNhan;
                dr["NgayNhan"] = tb.NgayNhan.Value.ToString("dd/MM/yyyy");

                dr["ChucVu"] = tb.ChucVu;
                dr["NguoiKy"] = tb.NguoiKy;

                dsBaoCao.Tables["PhieuCatChuyenDM"].Rows.Add(dr);

                //rptPhieuYCNhanDM rpt = new rptPhieuYCNhanDM();
                //rpt.SetDataSource(dsBaoCao);
                rptPhieuTBYCNhanDMx2_N rpt = new rptPhieuTBYCNhanDMx2_N();
                for (int j = 0; j < rpt.Subreports.Count; j++)
                {
                    rpt.Subreports[j].SetDataSource(dsBaoCao);
                }
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.ShowDialog();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedindex != -1)
            {
                TBKetQuaYCCatDM tb = _cTB.GetTBKetQuaYCCatDMByID(decimal.Parse(dgvDSTBKetQuaYCCatDM["SoPhieu", _selectedindex].Value.ToString()));
                tb.PYC = txtPYC.Text.Trim();
                tb.SoPhieuNhan = txtSoPhieuNhan.Text.Trim();
                tb.NgayNhan = dateNhan.Value;
                tb.CatNK_DanhBo = txtDanhBo_Cat.Text.Trim();
                tb.CatNK_HoTen = txtHoTen_Cat.Text.Trim();
                tb.CatNK_DiaChi = txtDiaChi_Cat.Text.Trim();
                tb.MaCT = txtMaCT_Cat.Text.Trim();
                tb.NhanNK_MaCN = int.Parse(cmbChiNhanh_Nhan.SelectedValue.ToString());
                tb.NhanNK_DanhBo = txtDanhBo_Nhan.Text.Trim();
                tb.NhanNK_HoTen = txtHoTen_Nhan.Text.Trim();
                tb.NhanNK_DiaChi = txtDiaChi_Nhan.Text.Trim();
                tb.SoNKCat = int.Parse(txtSoNK_Cat.Text.Trim());
                tb.GhiChu = txtGhiChu.Text.Trim();

                if (_cTB.SuaTBKetQuaYCCatDM(tb))
                {
                    dgvDSTBKetQuaYCCatDM.DataSource = _cTB.LoadDSTBKetQuaYCCatDM();
                    Clear();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedindex != -1)
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    TBKetQuaYCCatDM tb = _cTB.GetTBKetQuaYCCatDMByID(decimal.Parse(dgvDSTBKetQuaYCCatDM["SoPhieu", _selectedindex].Value.ToString()));
                    if (_cTB.XoaTBKetQuaYCCatDM(tb))
                    {
                        dgvDSTBKetQuaYCCatDM.DataSource = _cTB.LoadDSTBKetQuaYCCatDM();
                        Clear();
                    }
                }
        }

        private void dgvDSTBKetQuaYCCatDM_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSTBKetQuaYCCatDM.Columns[e.ColumnIndex].Name == "SoPhieu" && e.Value != null)
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            if (dgvDSTBKetQuaYCCatDM.Columns[e.ColumnIndex].Name == "NhanNK_MaCN"&& e.Value!=null)
                e.Value = _cChiNhanh.getTenChiNhanhbyID(int.Parse(dgvDSTBKetQuaYCCatDM["NhanNK_MaCN", e.RowIndex].Value.ToString()));
        }

        private void btnInDongY_Click(object sender, EventArgs e)
        {
            if (_selectedindex != -1)
            {
                TBKetQuaYCCatDM tb = _cTB.GetTBKetQuaYCCatDMByID(decimal.Parse(dgvDSTBKetQuaYCCatDM["SoPhieu", _selectedindex].Value.ToString()));
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["PhieuCatChuyenDM"].NewRow();

                dr["SoPhieu"] = tb.SoPhieu.ToString().Insert(tb.SoPhieu.ToString().Length - 2, "-");
                dr["ChiNhanh"] = _cChiNhanh.getTenChiNhanhbyID(tb.NhanNK_MaCN.Value);
                if (!string.IsNullOrEmpty(tb.NhanNK_DanhBo))
                    dr["DanhBoCat"] = tb.NhanNK_DanhBo.Insert(7, " ").Insert(4, " ");
                dr["HoTenCat"] = tb.NhanNK_HoTen;
                dr["DiaChiCat"] = tb.NhanNK_DiaChi;
                if (!string.IsNullOrEmpty(tb.CatNK_DanhBo))
                    dr["DanhBoNhan"] = tb.CatNK_DanhBo.Insert(7, " ").Insert(4, " ");
                dr["HoTenNhan"] = tb.CatNK_HoTen;
                dr["DiaChiNhan"] = tb.CatNK_DiaChi;
                dr["SoNKCat"] = tb.SoNKCat + " nhân khẩu (HK: " + tb.MaCT + ")";

                dr["PYC"] = tb.PYC;
                dr["SoPhieuNhan"] = tb.SoPhieuNhan;
                dr["NgayNhan"] = tb.NgayNhan.Value.ToString("dd/MM/yyyy");

                dr["ChucVu"] = tb.ChucVu;
                dr["NguoiKy"] = tb.NguoiKy;

                dsBaoCao.Tables["PhieuCatChuyenDM"].Rows.Add(dr);

                //rptPhieuYCNhanDM rpt = new rptPhieuYCNhanDM();
                //rpt.SetDataSource(dsBaoCao);
                rptPhieuTBYCNhanDMx2_Y rpt = new rptPhieuTBYCNhanDMx2_Y();
                for (int j = 0; j < rpt.Subreports.Count; j++)
                {
                    rpt.Subreports[j].SetDataSource(dsBaoCao);
                }
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.ShowDialog();
            }
        }
    }
}
