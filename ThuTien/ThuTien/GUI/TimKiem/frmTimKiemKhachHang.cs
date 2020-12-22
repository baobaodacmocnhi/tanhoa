using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.DAL.DongNuoc;
using ThuTien.DAL;
using ThuTien.DAL.TongHop;
using ThuTien.LinQ;
using ThuTien.DAL.Quay;
using CrystalDecisions.CrystalReports.Engine;
using ThuTien.GUI.BaoCao;
using ThuTien.BaoCao.TimKiem;
using ThuTien.BaoCao;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.ChuyenKhoan;

namespace ThuTien.GUI.TimKiem
{
    public partial class frmTimKiemKhachHang : Form
    {
        CHoaDon _cHoaDon = new CHoaDon();
        CDongNuoc _cDongNuoc = new CDongNuoc();
        CKinhDoanh _cKinhDoanh = new CKinhDoanh();
        CChuyenNoKhoDoi _cCNKD = new CChuyenNoKhoDoi();
        CLenhHuy _cLenhHuy = new CLenhHuy();
        CToTrinhCatHuy _cTTCH = new CToTrinhCatHuy();
        CDHN _cDocSo = new CDHN();
        CDichVuThu _cDichVuThu = new CDichVuThu();

        public frmTimKiemKhachHang()
        {
            InitializeComponent();
        }

        private void frmTimKiemKhachHang_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
            dgvKinhDoanh.AutoGenerateColumns = false;
            dgvLenhHuy.AutoGenerateColumns = false;
            dgvThuHo.AutoGenerateColumns = false;
            cmbSoKy.SelectedIndex = 0;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDanhBo.Text.Trim().Replace(" ", "")) || !string.IsNullOrEmpty(txtMLT.Text.Trim().Replace(" ", "")))
                dgvHoaDon.DataSource = _cHoaDon.GetDSTimKiem(txtDanhBo.Text.Trim().Replace(" ", ""), txtMLT.Text.Trim().Replace(" ", ""));
            else
                dgvHoaDon.DataSource = _cHoaDon.GetDSTimKiemTTKH(txtHoTen.Text.Trim(), txtSoNha.Text.Trim(), txtTenDuong.Text.Trim());

            dgvKinhDoanh.DataSource = null;
            dgvKinhDoanh.Visible = false;

            dgvLenhHuy.DataSource = null;
            dgvLenhHuy.Visible = false;

            dgvThuHo.DataSource = null;
            dgvThuHo.Visible = false;

            if (!string.IsNullOrEmpty(txtDanhBo.Text.Trim().Replace(" ", "")) || !string.IsNullOrEmpty(txtMLT.Text.Trim().Replace(" ", "")))
                foreach (DataGridViewRow item in dgvHoaDon.Rows)
                {
                    //if (_cDongNuoc.CheckExist_CTDongNuoc(item.Cells["SoHoaDon"].Value.ToString()) == true)
                    if (item.Cells["MaDN"].Value.ToString() != "")
                        if (item.Cells["MaNV_DongNuoc"].Value.ToString() == "")
                            item.DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                        else
                            item.DefaultCellStyle.BackColor = Color.Yellow;
                    //if (_cDongNuoc.CheckExist_KQDongNuocLan2(item.Cells["SoHoaDon"].Value.ToString()) == true)
                    if (bool.Parse(item.Cells["DongNuoc2"].Value.ToString()) == true)
                        item.DefaultCellStyle.BackColor = Color.Orange;
                    //if (_cLenhHuy.CheckExist(item.Cells["SoHoaDon"].Value.ToString()) == true)
                    if (bool.Parse(item.Cells["LenhHuy"].Value.ToString()) == true)
                    {
                        //item.Cells["TinhTrang"].Value = _cLenhHuy.GetTinhTrangBySoHoaDon(item.Cells["SoHoaDon"].Value.ToString());
                        item.DefaultCellStyle.BackColor = Color.Red;
                    }
                    else
                        //if (_cTTCH.CheckExist_CT(item.Cells["SoHoaDon"].Value.ToString()) == true)
                        if (bool.Parse(item.Cells["ToTrinh"].Value.ToString()) == true)
                        {
                            item.DefaultCellStyle.BackColor = Color.Green;
                        }
                    //điều chỉnh tiền dư chuyển khoản
                    if (bool.Parse(item.Cells["DCHD"].Value.ToString()) == true)
                        item.DefaultCellStyle.BackColor = Color.Fuchsia;
                    //điều chỉnh hóa đơn thương vụ
                    if (bool.Parse(item.Cells["ChanDCHD"].Value.ToString()) == false)
                        item.DefaultCellStyle.BackColor = Color.Blue;
                    //if (_cCNKD.CheckExistCT(item.Cells["SoHoaDon"].Value.ToString()) == true)
                    //{
                    //TT_CTChuyenNoKhoDoi ctcnkd = _cCNKD.GetCT(item.Cells["SoHoaDon"].Value.ToString());

                    //    //item.Cells["NgayGiaiTrach"].Value = ctcnkd.CreateDate.Value.ToString("dd/MM/yyyy");
                    //    item.Cells["DangNgan"].Value = "CNKĐ";
                    //}
                }
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "MLT" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(2, " ");
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "GiaBan" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "ThueGTGT" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "PhiBVMT" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "MaDN" && e.Value != null && e.Value.ToString().Length > 2)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void dgvHoaDon_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHoaDon.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnTimKiem.PerformClick();
        }

        private void txtMLT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnTimKiem.PerformClick();
        }

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnTimKiem.PerformClick();
        }

        private void txtDiaChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnTimKiem.PerformClick();
        }

        private void txtTenDuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnTimKiem.PerformClick();
        }

        private void btnInPhieuTieuThu_Click(object sender, EventArgs e)
        {
            //DataTable dtTieuThu = _cHoaDon.GetDSTieuThu(txtDanhBo.Text.Trim());

            TB_DULIEUKHACHHANG ttkh = _cDocSo.GetTTKH(txtDanhBo.Text.Trim().Replace(" ", ""));

            DataTable dtGhiChu = _cDocSo.GetGhiChu(txtDanhBo.Text.Trim().Replace(" ", ""));

            dsBaoCao ds = new dsBaoCao();

            if (ttkh!=null)
            {
                DataRow dr = ds.Tables["PhieuTieuThu"].NewRow();
                dr["DanhBo"] = ttkh.DANHBO.Insert(7, " ").Insert(4, " ");
                dr["HopDong"] = ttkh.HOPDONG;
                dr["GiaBieu"] = ttkh.GIABIEU;
                dr["DinhMuc"] = ttkh.DINHMUC;
                dr["MLT"] = ttkh.LOTRINH;
                dr["Hieu"] = ttkh.HIEUDH;
                dr["Co"] = ttkh.CODH;
                dr["SoThan"] = ttkh.SOTHANDH;
                dr["ViTri"] = ttkh.VITRIDHN;
                //dr["HoTen"] = ttkh.HOTEN;
                //dr["DiaChi"] = ttkh.SONHA + " " + ttkh.TENDUONG;
                dr["DienThoai"] = ttkh.DIENTHOAI;
                if (dgvHoaDon.Rows.Count > 0)
                {
                    dr["HoTen"] = dgvHoaDon["HoTen", 0].Value.ToString();
                    dr["DiaChi"] = dgvHoaDon["DiaChi", 0].Value.ToString();
                    dr["HanhThu"] = dgvHoaDon["HanhThu", 0].Value.ToString();
                }
                ds.Tables["PhieuTieuThu"].Rows.Add(dr);
            }

            //foreach (DataRow item in dtTieuThu.Rows)
            //{
            //    DataRow dr = ds.Tables["TieuThu"].NewRow();
            //    dr["Ky"] = item["Ky"];
            //    dr["SoHoaDon"] = item["SoHoaDon"];
            //    dr["TieuThu"] = item["TieuThu"];
            //    dr["TongCong"] = item["TongCong"];
            //    dr["NgayGiaiTrach"] = item["NgayGiaiTrach"];
            //    ds.Tables["TieuThu"].Rows.Add(dr);
            //}
            if (dgvHoaDon.RowCount > int.Parse(cmbSoKy.SelectedItem.ToString()))
                for (int i = 0; i < int.Parse(cmbSoKy.SelectedItem.ToString()); i++)
                {
                    DataRow dr = ds.Tables["TieuThu"].NewRow();
                    dr["Ky"] = dgvHoaDon["Ky", i].Value.ToString();
                    dr["NgayDoc"] = dgvHoaDon["NgayDoc", i].Value.ToString();
                    dr["Code"] = dgvHoaDon["Code", i].Value.ToString();
                    dr["ChiSo"] = dgvHoaDon["ChiSo", i].Value.ToString();
                    dr["TieuThu"] = dgvHoaDon["TieuThu", i].Value.ToString();
                    dr["TongCong"] = dgvHoaDon["TongCong", i].Value.ToString();
                    dr["NgayGiaiTrach"] = dgvHoaDon["NgayGiaiTrach", i].Value.ToString();
                    ds.Tables["TieuThu"].Rows.Add(dr);
                }
            else
                for (int i = 0; i < dgvHoaDon.RowCount; i++)
                {
                    DataRow dr = ds.Tables["TieuThu"].NewRow();
                    dr["Ky"] = dgvHoaDon["Ky", i].Value.ToString();
                    dr["NgayDoc"] = dgvHoaDon["NgayDoc", i].Value.ToString();
                    dr["Code"] = dgvHoaDon["Code", i].Value.ToString();
                    dr["ChiSo"] = dgvHoaDon["ChiSo", i].Value.ToString();
                    dr["TieuThu"] = dgvHoaDon["TieuThu", i].Value.ToString();
                    dr["TongCong"] = dgvHoaDon["TongCong", i].Value.ToString();
                    dr["NgayGiaiTrach"] = dgvHoaDon["NgayGiaiTrach", i].Value.ToString();
                    ds.Tables["TieuThu"].Rows.Add(dr);
                }

            foreach (DataRow item in dtGhiChu.Rows)
            {
                DataRow dr = ds.Tables["GhiChu"].NewRow();
                dr["CreateDate"] = item["CreateDate"];
                dr["NoiDung"] = item["NoiDung"];
                ds.Tables["GhiChu"].Rows.Add(dr);
            }

            rptPhieuTieuThu rpt = new rptPhieuTieuThu();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void btnXemPKinhDoanh_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDanhBo.Text.Trim().Replace(" ", "")))
            {
                dgvKinhDoanh.DataSource = _cKinhDoanh.GetDSP_KinhDoanh(txtDanhBo.Text.Trim().Replace(" ", ""));
                dgvKinhDoanh.Visible = true;
            }
        }

        private void btnXemLenhHuy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDanhBo.Text.Trim().Replace(" ", "")))
            {
                dgvLenhHuy.DataSource = _cLenhHuy.GetTinhTrangMoiNhat(txtDanhBo.Text.Trim().Replace(" ", ""));
                dgvLenhHuy.Visible = true;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtDanhBo.Text = "";
            txtMLT.Text = "";
            txtHoTen.Text = "";
            txtSoNha.Text = "";
            txtTenDuong.Text = "";
            txtDanhBo.Focus();
        }

        private void btnTimKiemTatCa_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDanhBo.Text.Trim().Replace(" ", "")) || !string.IsNullOrEmpty(txtMLT.Text.Trim().Replace(" ", "")))
                dgvHoaDon.DataSource = _cHoaDon.GetDSTimKiemTatCa(txtDanhBo.Text.Trim().Replace(" ", ""), txtMLT.Text.Trim().Replace(" ", ""));

            foreach (DataGridViewRow item in dgvHoaDon.Rows)
            {
                if (_cDongNuoc.CheckExist_CTDongNuoc(item.Cells["SoHoaDon"].Value.ToString()))
                    item.DefaultCellStyle.BackColor = Color.Yellow;
                if (_cLenhHuy.CheckExist(item.Cells["SoHoaDon"].Value.ToString()))
                {
                    //item.Cells["TinhTrang"].Value = _cLenhHuy.GetTinhTrangBySoHoaDon(item.Cells["SoHoaDon"].Value.ToString());
                    item.DefaultCellStyle.BackColor = Color.Red;
                }
                if (_cCNKD.CheckExistCT(item.Cells["SoHoaDon"].Value.ToString()))
                {
                    TT_CTChuyenNoKhoDoi ctcnkd = _cCNKD.GetCT(item.Cells["SoHoaDon"].Value.ToString());

                    //item.Cells["NgayGiaiTrach"].Value = ctcnkd.CreateDate.Value.ToString("dd/MM/yyyy");
                    item.Cells["DangNgan"].Value = "CNKĐ";
                }
            }
        }

        private void dgvHoaDon_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (CNguoiDung.MaND == 0)
                if (dgvHoaDon.RowCount > 0 && e.Button == MouseButtons.Left)
                {
                    frmDoiSoHoaDon frm = new frmDoiSoHoaDon(int.Parse(dgvHoaDon.CurrentRow.Cells["MaHD"].Value.ToString()));
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        btnTimKiem.PerformClick();
                    }
                }
        }

        private void dgvHoaDon_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDanhBo.Text.Trim().Replace(" ", "")) || !string.IsNullOrEmpty(txtMLT.Text.Trim().Replace(" ", "")))
                foreach (DataGridViewRow item in dgvHoaDon.Rows)
                {
                    if (_cDongNuoc.CheckExist_CTDongNuoc(item.Cells["SoHoaDon"].Value.ToString()))
                        item.DefaultCellStyle.BackColor = Color.Yellow;
                    if (_cDongNuoc.CheckExist_KQDongNuocLan2(item.Cells["SoHoaDon"].Value.ToString()))
                        item.DefaultCellStyle.BackColor = Color.Orange;
                    if (_cLenhHuy.CheckExist(item.Cells["SoHoaDon"].Value.ToString()))
                    {
                        //item.Cells["TinhTrang"].Value = _cLenhHuy.GetTinhTrangBySoHoaDon(item.Cells["SoHoaDon"].Value.ToString());
                        item.DefaultCellStyle.BackColor = Color.Red;
                    }
                    if (_cCNKD.CheckExistCT(item.Cells["SoHoaDon"].Value.ToString()))
                    {
                        TT_CTChuyenNoKhoDoi ctcnkd = _cCNKD.GetCT(item.Cells["SoHoaDon"].Value.ToString());

                        //item.Cells["NgayGiaiTrach"].Value = ctcnkd.CreateDate.Value.ToString("dd/MM/yyyy");
                        item.Cells["DangNgan"].Value = "CNKĐ";
                    }
                }
        }

        private void btnXemThuHo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDanhBo.Text.Trim().Replace(" ", "")))
            {
                dgvThuHo.DataSource = _cDichVuThu.getDS(txtDanhBo.Text.Trim().Replace(" ", ""));
                dgvThuHo.Visible = true;
            }
        }

       

    }
}
