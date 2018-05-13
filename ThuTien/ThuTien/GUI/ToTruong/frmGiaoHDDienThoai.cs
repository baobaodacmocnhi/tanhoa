using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.Doi;
using ThuTien.DAL.ToTruong;
using ThuTien.LinQ;
using System.Globalization;

namespace ThuTien.GUI.ToTruong
{
    public partial class frmGiaoHDDienThoai : Form
    {
        string _mnu = "mnuGiaoHDDienThoai";
        CHoaDon _cHoaDon = new CHoaDon();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CTo _cTo = new CTo();
        CGiaoHDDienThoai _cGiaoHDDienThoai = new CGiaoHDDienThoai();

        public frmGiaoHDDienThoai()
        {
            InitializeComponent();
        }

        private void frnGiaoHDDienThoai_Load(object sender, EventArgs e)
        {
            dgvHDTuGia.AutoGenerateColumns = false;
            dgvHDCoQuan.AutoGenerateColumns = false;
            dgvHDGiaoDienThoai.AutoGenerateColumns = false;

            if (CNguoiDung.Doi)
            {
                cmbTo.Visible = true;

                cmbTo.DataSource = _cTo.GetDSHanhThu();
                cmbTo.DisplayMember = "TenTo";
                cmbTo.ValueMember = "MaTo";
            }
            else
            {
                lbTo.Text = "Tổ  " + CNguoiDung.TenTo;
                cmbNhanVien.DataSource = _cNguoiDung.GetDSHanhThuByMaTo(CNguoiDung.MaTo);
                cmbNhanVien.DisplayMember = "HoTen";
                cmbNhanVien.ValueMember = "MaND";
            }
            DataTable dtNam = _cHoaDon.GetNam();
            DataRow dr = dtNam.NewRow();
            dr["ID"] = "Tất Cả";
            dtNam.Rows.InsertAt(dr, 0);
            cmbNam.DataSource = dtNam;
            cmbNam.DisplayMember = "ID";
            cmbNam.ValueMember = "Nam";
        }

        public void CountdgvHDTuGia()
        {
            long TongCong = 0;

            if (dgvHDTuGia.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    if (!string.IsNullOrEmpty(item.Cells["TongCong_TG"].Value.ToString()))
                        TongCong += long.Parse(item.Cells["TongCong_TG"].Value.ToString());
                }
                txtTongHD_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", dgvHDTuGia.Rows.Count);
                txtTongCong_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
        }

        public void CountdgvHDCoQuan()
        {
            long TongCong = 0;

            if (dgvHDCoQuan.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                {
                    if (!string.IsNullOrEmpty(item.Cells["TongCong_CQ"].Value.ToString()))
                        TongCong += long.Parse(item.Cells["TongCong_CQ"].Value.ToString());
                }
                txtTongHD_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", dgvHDCoQuan.Rows.Count);
                txtTongCong_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
        }

        public void CountdgvHDGiaoDienThoai()
        {
            long TongCong = 0;

            if (dgvHDGiaoDienThoai.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDGiaoDienThoai.Rows)
                {
                    if (!string.IsNullOrEmpty(item.Cells["TongCong_Giao"].Value.ToString()))
                        TongCong += long.Parse(item.Cells["TongCong_Giao"].Value.ToString());
                }
                txtTongHD_Giao.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", dgvHDGiaoDienThoai.Rows.Count);
                txtTongCong_Giao.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            //if (CNguoiDung.Doi)
            //{

            //}
            //else
            {
                if (tabControl.SelectedTab.Name == "tabTuGia")
                {
                    if (cmbFromDot.SelectedIndex == 0)
                    {
                        dgvHDTuGia.DataSource = _cHoaDon.GetDSTonDenKy_NV("TG", int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), 1);
                    }
                    else
                        if (cmbFromDot.SelectedIndex > 0)
                        {
                            DataTable dt = new DataTable();
                            for (int i = int.Parse(cmbFromDot.SelectedItem.ToString()); i <= int.Parse(cmbToDot.SelectedItem.ToString()); i++)
                            {
                                dt.Merge(_cHoaDon.GetDSTonDenKy_NV("TG", int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), i, 1));
                            }
                            dgvHDTuGia.DataSource = dt;
                        }
                    CountdgvHDTuGia();
                }
                else
                    if (tabControl.SelectedTab.Name == "tabCoQuan")
                    {
                        if (cmbFromDot.SelectedIndex == 0)
                        {
                            dgvHDCoQuan.DataSource = _cHoaDon.GetDSTonDenKy_NV("CQ", int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), 1);
                        }
                        else
                            if (cmbFromDot.SelectedIndex > 0)
                            {
                                DataTable dt = new DataTable();
                                for (int i = int.Parse(cmbFromDot.SelectedItem.ToString()); i <= int.Parse(cmbToDot.SelectedItem.ToString()); i++)
                                {
                                    dt.Merge(_cHoaDon.GetDSTonDenKy_NV("CQ", int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), i, 1));
                                }
                                dgvHDCoQuan.DataSource = dt;
                            }
                        CountdgvHDCoQuan();
                    }
            }
        }

        private void cmbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTo.Items.Count > 0 && cmbTo.SelectedIndex > -1)
            {
                cmbNhanVien.DataSource = _cNguoiDung.GetDSHanhThuByMaTo(((TT_To)cmbTo.SelectedItem).MaTo);
                cmbNhanVien.DisplayMember = "HoTen";
                cmbNhanVien.ValueMember = "MaND";
            }
        }

        private void btnXem_Giao_Click(object sender, EventArgs e)
        {
            dgvHDGiaoDienThoai.DataSource = _cGiaoHDDienThoai.getDS(int.Parse(cmbNhanVien.SelectedValue.ToString()), dateDi.Value);
            CountdgvHDGiaoDienThoai();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    if (tabControl.SelectedTab.Name == "tabTuGia")
                    {
                        foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                            if (_cGiaoHDDienThoai.CheckExist(int.Parse(item.Cells["MaHD_TG"].Value.ToString()), int.Parse(item.Cells["MaNV_TG"].Value.ToString()), dateDi.Value) == false)
                            {
                                TT_GiaoHDDienThoai entity = new TT_GiaoHDDienThoai();
                                entity.MaHD = int.Parse(item.Cells["MaHD_TG"].Value.ToString());
                                entity.SoHoaDon = item.Cells["SoHoaDon_TG"].Value.ToString();
                                entity.MaNV = int.Parse(item.Cells["MaNV_TG"].Value.ToString());
                                entity.NgayDi = dateDi.Value.Date;
                                _cGiaoHDDienThoai.Them(entity);
                            }
                    }
                    else
                        if (tabControl.SelectedTab.Name == "tabCoQuan")
                        {
                            foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                                if (_cGiaoHDDienThoai.CheckExist(int.Parse(item.Cells["MaHD_CQ"].Value.ToString()), int.Parse(item.Cells["MaNV_CQ"].Value.ToString()), dateDi.Value) == false)
                                {
                                    TT_GiaoHDDienThoai entity = new TT_GiaoHDDienThoai();
                                    entity.MaHD = int.Parse(item.Cells["MaHD_CQ"].Value.ToString());
                                    entity.SoHoaDon = item.Cells["SoHoaDon_CQ"].Value.ToString();
                                    entity.MaNV = int.Parse(item.Cells["MaNV_CQ"].Value.ToString());
                                    entity.NgayDi = dateDi.Value.Date;
                                    _cGiaoHDDienThoai.Them(entity);
                                }
                        }
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                try
                {
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    foreach (DataGridViewRow item in dgvHDGiaoDienThoai.SelectedRows)
                    {
                        string sql = "delete TT_GiaoHDDienThoai where MaHD=" + item.Cells["MaHD_Giao"].Value.ToString() + " and MaNV=" + item.Cells["MaNV_Giao"].Value.ToString()
                            + " and NgayDi='" + DateTime.Parse(item.Cells["NgayDi_Giao"].Value.ToString()).ToString("yyyy-MM-dd") + "'";
                        _cGiaoHDDienThoai.LinQ_ExecuteNonQuery(sql);
                    }
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
