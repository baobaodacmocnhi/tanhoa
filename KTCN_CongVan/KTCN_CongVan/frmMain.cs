using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTCN_CongVan.LinQ;
using KTCN_CongVan.DAL;

namespace KTCN_CongVan
{
    public partial class frmMain : Form
    {
        CongVanDi _congvandi = null;
        CongVanDen _congvanden = null;
        CCongVanDi _cCongVanDi = new CCongVanDi();
        CCongVanDen _cCongVanDen = new CCongVanDen();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            dgvCongVan_Den.AutoGenerateColumns = false;
            DataTable dtLoaiCongVan_Den = _cCongVanDen.GetLoaiCongVan();
            AutoCompleteStringCollection auto_Den = new AutoCompleteStringCollection();
            foreach (DataRow item in dtLoaiCongVan_Den.Rows)
            {
                auto_Den.Add(item["LoaiCongVan"].ToString());
            }
            txtLoaiCongVan_Den.AutoCompleteCustomSource = auto_Den;

            DataTable dtNoiDung_Den = _cCongVanDen.GetNoiDung();
            AutoCompleteStringCollection autoNoiDung_Den = new AutoCompleteStringCollection();
            foreach (DataRow item in dtNoiDung_Den.Rows)
            {
                autoNoiDung_Den.Add(item["NoiDung"].ToString());
            }
            txtNoiDung_Den.AutoCompleteCustomSource = autoNoiDung_Den;

            //////////////
            dgvCongVan_Di.AutoGenerateColumns = false;
            DataTable dtLoaiCongVan_Di = _cCongVanDi.GetLoaiCongVan();
            AutoCompleteStringCollection auto_Di = new AutoCompleteStringCollection();
            foreach (DataRow item in dtLoaiCongVan_Di.Rows)
            {
                auto_Di.Add(item["LoaiCongVan"].ToString());
            }
            txtLoaiCongVan_Di.AutoCompleteCustomSource = auto_Di;

            DataTable dtNoiDung_Di = _cCongVanDi.GetNoiDung();
            AutoCompleteStringCollection autoNoiDung_Di = new AutoCompleteStringCollection();
            foreach (DataRow item in dtNoiDung_Di.Rows)
            {
                autoNoiDung_Di.Add(item["NoiDung"].ToString());
            }
            txtNoiDung_Di.AutoCompleteCustomSource = autoNoiDung_Di;
        }

        private void LoadCongVanDi(CongVanDi entity)
        {
            txtSoCongVan_Di.Text = entity.SoCongVan;
            dateNgayNhan_Di.Value = entity.NgayNhan.Value;
            chkCongVanCongTy_Di.Checked = entity.CongVanCongTy;
            txtLoaiCongVan_Di.Text = entity.LoaiCongVan;
            chkBanChinh_Di.Checked = entity.BanChinh;
            txtNoiDung_Di.Text = entity.NoiDung;
            txtNoiNhan_Di.Text = entity.NoiNhan;
            txtGhiChu_Di.Text = entity.GhiChu;
            chkHetHan_Di.Checked = entity.HetHan;
            dateNgayHetHan_Di.Value = entity.NgayHetHan.Value;
        }

        private void ClearCongVanDi()
        {
            txtSoCongVan_Di.Text = "";
            dateNgayNhan_Di.Value = DateTime.Now;
            chkCongVanCongTy_Di.Checked = false;
            txtLoaiCongVan_Di.Text = "";
            chkBanChinh_Di.Checked = false;
            txtNoiDung_Di.Text = "";
            txtNoiNhan_Di.Text = "";
            txtGhiChu_Di.Text = "";
            chkHetHan_Di.Checked = false;
            dateNgayHetHan_Di.Value = DateTime.Now;

            _congvandi = null;
        }

        private void btnThem_Di_Click(object sender, EventArgs e)
        {
            try
            {
                CongVanDi entity = new CongVanDi();
                entity.SoCongVan = txtSoCongVan_Di.Text.Trim();
                entity.NgayNhan = dateNgayNhan_Di.Value;
                entity.CongVanCongTy = chkCongVanCongTy_Di.Checked;
                entity.LoaiCongVan = txtLoaiCongVan_Di.Text.Trim();
                entity.BanChinh = chkBanChinh_Di.Checked;
                entity.NoiDung = txtNoiDung_Di.Text.Trim();
                entity.NoiNhan = txtNoiNhan_Di.Text.Trim();
                entity.GhiChu = txtGhiChu_Di.Text.Trim();
                if (chkHetHan_Di.Checked == true)
                {
                    entity.HetHan = chkHetHan_Di.Checked;
                    entity.NgayHetHan = dateNgayHetHan_Di.Value;
                }
                if (_cCongVanDi.Them(entity) == true)
                {
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearCongVanDi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Di_Click(object sender, EventArgs e)
        {
            try
            {
                if (_congvandi != null && MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (_cCongVanDi.Xoa(_congvandi) == true)
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearCongVanDi();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Di_Click(object sender, EventArgs e)
        {
            try
            {
                if (_congvandi != null)
                {
                    _congvandi.SoCongVan = txtSoCongVan_Di.Text.Trim();
                    _congvandi.NgayNhan = dateNgayNhan_Di.Value;
                    _congvandi.CongVanCongTy = chkCongVanCongTy_Di.Checked;
                    _congvandi.LoaiCongVan = txtLoaiCongVan_Di.Text.Trim();
                    _congvandi.BanChinh = chkBanChinh_Di.Checked;
                    _congvandi.NoiDung = txtNoiDung_Di.Text.Trim();
                    _congvandi.NoiNhan = txtNoiNhan_Di.Text.Trim();
                    _congvandi.GhiChu = txtGhiChu_Di.Text.Trim();
                    if (chkHetHan_Di.Checked == true)
                    {
                        _congvandi.HetHan = true;
                        _congvandi.NgayHetHan = dateNgayHetHan_Di.Value;
                    }
                    else
                    {
                        _congvandi.HetHan = false;
                    }
                    if (_cCongVanDi.Sua(_congvandi) == true)
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearCongVanDi();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbTimTheo_Di_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo_Di.SelectedItem.ToString())
            {
                case "Số Công Văn":
                case "Nội Dung":
                case "Nơi Nhận":
                    panel_NoiDung_Di.Visible = true;
                    panel_ThoiGian_Di.Visible = false;
                    break;
                case "Ngày Nhận":
                case "Ngày Hết Hạn":
                    panel_NoiDung_Di.Visible = false;
                    panel_ThoiGian_Di.Visible = true;
                    break;
                default:
                    panel_NoiDung_Di.Visible = false;
                    panel_ThoiGian_Di.Visible = false;
                    break;
            }
        }

        private void btnXem_Di_Click(object sender, EventArgs e)
        {
            
            switch (cmbTimTheo_Di.SelectedItem.ToString())
            {
                case "Số Công Văn":
                    dgvCongVan_Di.DataSource = _cCongVanDi.GetDS_SoCongVan(txtNoiDungTimKiem_Di.Text.Trim());
                    break;
                case "Nội Dung":
                    dgvCongVan_Di.DataSource = _cCongVanDi.GetDS_NoiDung(txtNoiDungTimKiem_Di.Text.Trim());
                    break;
                case "Nơi Nhận":
                    dgvCongVan_Di.DataSource = _cCongVanDi.GetDS_NoiNhan(txtNoiDungTimKiem_Di.Text.Trim());
                    break;
                case "Ngày Nhận":
                    dgvCongVan_Di.DataSource = _cCongVanDi.GetDS(dateTu_Di.Value, dateDen_Di.Value);
                    break;
                case "Ngày Hết Hạn":
                    dgvCongVan_Di.DataSource = _cCongVanDi.GetDS_NgayHetHan(dateTu_Di.Value, dateDen_Di.Value);
                    break;
                default:
                    dgvCongVan_Di.DataSource = null;
                    break;
            }
        }

        private void dgvCongVan_Di_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _congvandi = _cCongVanDi.Get(int.Parse(dgvCongVan_Di.CurrentRow.Cells["ID_Di"].Value.ToString()));
                LoadCongVanDi(_congvandi);
            }
            catch (Exception)
            {

            }
        }

        private void chkHetHan_Di_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHetHan_Di.Checked == true)
                dateNgayHetHan_Di.Enabled = true;
            else
                dateNgayHetHan_Di.Enabled = false;
        }

        /////////////////////

        private void LoadCongVanDen(CongVanDen entity)
        {
            txtSoCongVan_Den.Text = entity.SoCongVan;
            dateNgayCongVan_Den.Value = entity.NgayCongVan.Value;
            txtDonViPhatHanh_Den.Text = entity.DonViPhatHanh;
            dateNgayNhan_Den.Value = entity.NgayNhan.Value;
            txtLoaiCongVan_Den.Text = entity.LoaiCongVan;
            txtNoiDung_Den.Text = entity.NoiDung;
            txtNoiNhan_Den.Text = entity.NoiNhan;
            txtGhiChu_Den.Text = entity.GhiChu;
            chkHetHan_Den.Checked = entity.HetHan;
            dateNgayHetHan_Den.Value = entity.NgayHetHan.Value;
        }

        private void ClearCongVanDen()
        {
            txtSoCongVan_Den.Text = "";
            dateNgayCongVan_Den.Value = DateTime.Now;
            txtDonViPhatHanh_Den.Text = "";
            dateNgayNhan_Den.Value = DateTime.Now;
            txtLoaiCongVan_Den.Text = "";
            txtNoiDung_Den.Text = "";
            txtNoiNhan_Den.Text = "";
            txtGhiChu_Den.Text = "";
            chkHetHan_Den.Checked = false;
            dateNgayHetHan_Den.Value = DateTime.Now;

            _congvanden = null;
        }

        private void btnThem_Den_Click(object sender, EventArgs e)
        {
            try
            {
                CongVanDen entity = new CongVanDen();
                entity.SoCongVan = txtSoCongVan_Den.Text.Trim();
                entity.NgayCongVan = dateNgayCongVan_Den.Value;
                entity.DonViPhatHanh = txtDonViPhatHanh_Den.Text.Trim();
                entity.NgayNhan = dateNgayNhan_Den.Value;
                entity.LoaiCongVan = txtLoaiCongVan_Den.Text.Trim();
                entity.NoiDung = txtNoiDung_Den.Text.Trim();
                entity.NoiNhan = txtNoiNhan_Den.Text.Trim();
                entity.GhiChu = txtGhiChu_Den.Text.Trim();
                if (chkHetHan_Den.Checked == true)
                {
                    entity.HetHan = chkHetHan_Den.Checked;
                    entity.NgayHetHan = dateNgayHetHan_Den.Value;
                }
                if (_cCongVanDen.Them(entity) == true)
                {
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearCongVanDen();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Den_Click(object sender, EventArgs e)
        {
            try
            {
                if (_congvanden != null && MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (_cCongVanDen.Xoa(_congvanden) == true)
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearCongVanDen();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Den_Click(object sender, EventArgs e)
        {
            try
            {
                if (_congvanden != null)
                {
                    _congvanden.SoCongVan = txtSoCongVan_Den.Text.Trim();
                    _congvanden.NgayCongVan = dateNgayCongVan_Den.Value;
                    _congvanden.DonViPhatHanh = txtDonViPhatHanh_Den.Text.Trim();
                    _congvanden.NgayNhan = dateNgayNhan_Den.Value;
                    _congvanden.LoaiCongVan = txtLoaiCongVan_Den.Text.Trim();
                    _congvanden.NoiDung = txtNoiDung_Den.Text.Trim();
                    _congvanden.NoiNhan = txtNoiNhan_Den.Text.Trim();
                    _congvanden.GhiChu = txtGhiChu_Den.Text.Trim();
                    if (chkHetHan_Den.Checked == true)
                    {
                        _congvanden.HetHan = true;
                        _congvanden.NgayHetHan = dateNgayHetHan_Den.Value;
                    }
                    else
                    {
                        _congvanden.HetHan = false;
                    }
                    if (_cCongVanDen.Sua(_congvanden) == true)
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearCongVanDen();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbTimTheo_Den_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo_Den.SelectedItem.ToString())
            {
                case "Số Công Văn":
                case "Nội Dung":
                case "Nơi Nhận":
                    panel_NoiDung_Den.Visible = true;
                    panel_ThoiGian_Den.Visible = false;
                    break;
                case "Ngày Nhận":
                case "Ngày Hết Hạn":
                    panel_NoiDung_Den.Visible = false;
                    panel_ThoiGian_Den.Visible = true;
                    break;
                default:
                    panel_NoiDung_Den.Visible = false;
                    panel_ThoiGian_Den.Visible = false;
                    break;
            }
        }

        private void btnXem_Den_Click(object sender, EventArgs e)
        {
           
            switch (cmbTimTheo_Den.SelectedItem.ToString())
            {
                case "Số Công Văn":
                    dgvCongVan_Den.DataSource = _cCongVanDen.GetDS_SoCongVan(txtNoiDungTimKiem_Den.Text.Trim());
                    break;
                case "Nội Dung":
                    dgvCongVan_Den.DataSource = _cCongVanDen.GetDS_NoiDung(txtNoiDungTimKiem_Den.Text.Trim());
                    break;
                case "Nơi Nhận":
                    dgvCongVan_Den.DataSource = _cCongVanDen.GetDS_NoiNhan(txtNoiDungTimKiem_Den.Text.Trim());
                    break;
                case "Ngày Nhận":
                    dgvCongVan_Den.DataSource = _cCongVanDen.GetDS(dateTu_Den.Value, dateDen_Den.Value);
                    break;
                case "Ngày Hết Hạn":
                    dgvCongVan_Den.DataSource = _cCongVanDen.GetDS_NgayHetHan(dateTu_Den.Value, dateDen_Den.Value);
                    break;
                default:
                    break;
            }
        }

        private void dgvCongVan_Den_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _congvanden = _cCongVanDen.Get(int.Parse(dgvCongVan_Den.CurrentRow.Cells["ID_Den"].Value.ToString()));
                LoadCongVanDen(_congvanden);
            }
            catch (Exception)
            {

            }
        }

        private void chkHetHan_Den_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHetHan_Den.Checked == true)
                dateNgayHetHan_Den.Enabled = true;
            else
                dateNgayHetHan_Den.Enabled = false;
        }

        

        
    }
}
