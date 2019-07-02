using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTCN_CongVan.DAL;
using KTCN_CongVan.LinQ;
using KTCN_CongVan.DAL.QuanTri;

namespace KTCN_CongVan.GUI.CongVan
{
    public partial class frmCongVanDen : Form
    {
        string _mnu = "mnuCongVanDen";
        CCongVanDen _cCongVanDen = new CCongVanDen();
        CongVanDen _congvanden = null;

        public frmCongVanDen()
        {
            InitializeComponent();
        }

        private void frmCongVanDen_Load(object sender, EventArgs e)
        {
            dgvCongVan_Den.AutoGenerateColumns = false;
            DataTable dtLoaiCongVan_Den = _cCongVanDen.getLoaiCongVan(CUser.IDPhong);
            AutoCompleteStringCollection auto_Den = new AutoCompleteStringCollection();
            foreach (DataRow item in dtLoaiCongVan_Den.Rows)
            {
                auto_Den.Add(item["LoaiCongVan"].ToString());
            }
            txtLoaiCongVan_Den.AutoCompleteCustomSource = auto_Den;

            DataTable dtNoiDung_Den = _cCongVanDen.getNoiDung(CUser.IDPhong);
            AutoCompleteStringCollection autoNoiDung_Den = new AutoCompleteStringCollection();
            foreach (DataRow item in dtNoiDung_Den.Rows)
            {
                autoNoiDung_Den.Add(item["NoiDung"].ToString());
            }
            txtNoiDung_Den.AutoCompleteCustomSource = autoNoiDung_Den;
        }

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
                if (CUser.CheckQuyen(_mnu, "Them"))
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
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (CUser.CheckQuyen(_mnu, "Xoa"))
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
                else
                    MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (CUser.CheckQuyen(_mnu, "Sua"))
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
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    dgvCongVan_Den.DataSource = _cCongVanDen.getDS_SoCongVan(CUser.IDPhong, txtNoiDungTimKiem_Den.Text.Trim());
                    break;
                case "Nội Dung":
                    dgvCongVan_Den.DataSource = _cCongVanDen.getDS_NoiDung(CUser.IDPhong, txtNoiDungTimKiem_Den.Text.Trim());
                    break;
                case "Nơi Nhận":
                    dgvCongVan_Den.DataSource = _cCongVanDen.getDS_NoiNhan(CUser.IDPhong, txtNoiDungTimKiem_Den.Text.Trim());
                    break;
                case "Ngày Nhận":
                    dgvCongVan_Den.DataSource = _cCongVanDen.getDS(CUser.IDPhong, dateTu_Den.Value, dateDen_Den.Value);
                    break;
                case "Ngày Hết Hạn":
                    dgvCongVan_Den.DataSource = _cCongVanDen.getDS_NgayHetHan(CUser.IDPhong, dateTu_Den.Value, dateDen_Den.Value);
                    break;
                default:
                    break;
            }
        }

        private void dgvCongVan_Den_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _congvanden = _cCongVanDen.get(int.Parse(dgvCongVan_Den.CurrentRow.Cells["ID_Den"].Value.ToString()));
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
