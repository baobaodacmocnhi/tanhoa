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
    public partial class frmCongVanDi : Form
    {
        string _mnu = "mnuCongVanDi";
        CCongVanDi _cCongVanDi = new CCongVanDi();
        CongVanDi _congvandi = null;
        public frmCongVanDi()
        {
            InitializeComponent();
        }

        private void frmCongVanDi_Load(object sender, EventArgs e)
        {
            dgvCongVan_Di.AutoGenerateColumns = false;
            DataTable dtLoaiCongVan_Di = _cCongVanDi.getLoaiCongVan(CUser.IDPhong);
            AutoCompleteStringCollection auto_Di = new AutoCompleteStringCollection();
            foreach (DataRow item in dtLoaiCongVan_Di.Rows)
            {
                auto_Di.Add(item["LoaiCongVan"].ToString());
            }
            txtLoaiCongVan_Di.AutoCompleteCustomSource = auto_Di;

            DataTable dtNoiDung_Di = _cCongVanDi.getNoiDung(CUser.IDPhong);
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
                if (CUser.CheckQuyen(_mnu, "Them"))
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
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (CUser.CheckQuyen(_mnu, "Xoa"))
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
                else
                    MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (CUser.CheckQuyen(_mnu, "Sua"))
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
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    dgvCongVan_Di.DataSource = _cCongVanDi.getDS_SoCongVan(CUser.IDPhong,txtNoiDungTimKiem_Di.Text.Trim());
                    break;
                case "Nội Dung":
                    dgvCongVan_Di.DataSource = _cCongVanDi.getDS_NoiDung(CUser.IDPhong, txtNoiDungTimKiem_Di.Text.Trim());
                    break;
                case "Nơi Nhận":
                    dgvCongVan_Di.DataSource = _cCongVanDi.getDS_NoiNhan(CUser.IDPhong, txtNoiDungTimKiem_Di.Text.Trim());
                    break;
                case "Ngày Nhận":
                    dgvCongVan_Di.DataSource = _cCongVanDi.getDS(CUser.IDPhong, dateTu_Di.Value, dateDen_Di.Value);
                    break;
                case "Ngày Hết Hạn":
                    dgvCongVan_Di.DataSource = _cCongVanDi.getDS_NgayHetHan(CUser.IDPhong, dateTu_Di.Value, dateDen_Di.Value);
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
                _congvandi = _cCongVanDi.get(int.Parse(dgvCongVan_Di.CurrentRow.Cells["ID_Di"].Value.ToString()));
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
    }
}
