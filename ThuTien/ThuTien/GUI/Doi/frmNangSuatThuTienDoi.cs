using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using System.Globalization;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using ThuTien.BaoCao;
using ThuTien.BaoCao.ToTruong;
using ThuTien.GUI.BaoCao;
using ThuTien.BaoCao.Doi;

namespace ThuTien.GUI.Doi
{
    public partial class frmNangSuatThuTienDoi : Form
    {
        CTo _cTo = new CTo();
        CHoaDon _cHoaDon = new CHoaDon();

        public frmNangSuatThuTienDoi()
        {
            InitializeComponent();
        }

        private void frmNangSuatThuTienDoi_Load(object sender, EventArgs e)
        {
            dgvHDTuGia.AutoGenerateColumns = false;
            dgvHDCoQuan.AutoGenerateColumns = false;
            dgvNhanVien.AutoGenerateColumns = false;

            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";
        }

        public void CountdgvHDTuGia()
        {
            int TongHD = 0;
            long TongGiaBan = 0;
            long TongCong = 0;
            int TongHDThu = 0;
            long TongGiaBanThu = 0;
            long TongCongThu = 0;
            int TongHDTon = 0;
            long TongGiaBanTon = 0;
            long TongCongTon = 0;

            if (dgvHDTuGia.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    if (!string.IsNullOrEmpty(item.Cells["TongHD_TG"].Value.ToString()))
                    TongHD += int.Parse(item.Cells["TongHD_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBan_TG"].Value.ToString()))
                        TongGiaBan += long.Parse(item.Cells["TongGiaBan_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCong_TG"].Value.ToString()))
                        TongCong += long.Parse(item.Cells["TongCong_TG"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDThu_TG"].Value.ToString()))
                    TongHDThu += int.Parse(item.Cells["TongHDThu_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBanThu_TG"].Value.ToString()))
                        TongGiaBanThu += long.Parse(item.Cells["TongGiaBanThu_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongThu_TG"].Value.ToString()))
                        TongCongThu += long.Parse(item.Cells["TongCongThu_TG"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDTon_TG"].Value.ToString()))
                    TongHDTon += int.Parse(item.Cells["TongHDTon_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBanTon_TG"].Value.ToString()))
                        TongGiaBanTon += long.Parse(item.Cells["TongGiaBanTon_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongTon_TG"].Value.ToString()))
                        TongCongTon += long.Parse(item.Cells["TongCongTon_TG"].Value.ToString());
                    
                    if (string.IsNullOrEmpty(item.Cells["TongGiaBanThu_TG"].Value.ToString()))
                        item.Cells["TiLeGiaBan_TG"].Value = "0%";
                    else
                        item.Cells["TiLeGiaBan_TG"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongGiaBanThu_TG"].Value.ToString()) / double.Parse(item.Cells["TongGiaBan_TG"].Value.ToString())) * 100);
                    if (string.IsNullOrEmpty(item.Cells["TongCongThu_TG"].Value.ToString()))
                        item.Cells["TiLeTongCong_TG"].Value = "0%";
                    else
                        item.Cells["TiLeTongCong_TG"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongCongThu_TG"].Value.ToString()) / double.Parse(item.Cells["TongCong_TG"].Value.ToString())) * 100);
                }
                txtTongHD_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHD);
                txtTongGiaBan_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBan);
                txtTongCong_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
                txtTongHDThu_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDThu);
                txtTongGiaBanThu_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanThu);
                txtTongCongThu_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongThu);
                txtTongHDTon_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDTon);
                txtTongGiaBanTon_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanTon);
                txtTongCongTon_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongTon);
            }
        }

        public void CountdgvHDCoQuan()
        {
            int TongHD = 0;
            long TongGiaBan = 0;
            long TongCong = 0;
            int TongHDThu = 0;
            long TongGiaBanThu = 0;
            long TongCongThu = 0;
            int TongHDTon = 0;
            long TongGiaBanTon = 0;
            long TongCongTon = 0;

            if (dgvHDCoQuan.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                {
                    if (!string.IsNullOrEmpty(item.Cells["TongHD_CQ"].Value.ToString()))
                        TongHD += int.Parse(item.Cells["TongHD_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBan_CQ"].Value.ToString()))
                        TongGiaBan += long.Parse(item.Cells["TongGiaBan_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCong_CQ"].Value.ToString()))
                        TongCong += long.Parse(item.Cells["TongCong_CQ"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDThu_CQ"].Value.ToString()))
                    TongHDThu += int.Parse(item.Cells["TongHDThu_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBanThu_CQ"].Value.ToString()))
                        TongGiaBanThu += long.Parse(item.Cells["TongGiaBanThu_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongThu_CQ"].Value.ToString()))
                        TongCongThu += long.Parse(item.Cells["TongCongThu_CQ"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDTon_CQ"].Value.ToString()))
                    TongHDTon += int.Parse(item.Cells["TongHDTon_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBanTon_CQ"].Value.ToString()))
                        TongGiaBanTon += long.Parse(item.Cells["TongGiaBanTon_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongTon_CQ"].Value.ToString()))
                        TongCongTon += long.Parse(item.Cells["TongCongTon_CQ"].Value.ToString());
                    
                    if (string.IsNullOrEmpty(item.Cells["TongGiaBanThu_CQ"].Value.ToString()))
                        item.Cells["TiLeGiaBan_CQ"].Value = "0%";
                    else
                        item.Cells["TiLeGiaBan_CQ"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongGiaBanThu_CQ"].Value.ToString()) / double.Parse(item.Cells["TongGiaBan_CQ"].Value.ToString())) * 100);
                    if (string.IsNullOrEmpty(item.Cells["TongCongThu_CQ"].Value.ToString()))
                        item.Cells["TiLeTongCong_CQ"].Value = "0%";
                    else
                        item.Cells["TiLeTongCong_CQ"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongCongThu_CQ"].Value.ToString()) / double.Parse(item.Cells["TongCong_CQ"].Value.ToString())) * 100);
                }
                txtTongHD_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHD);
                txtTongGiaBan_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBan);
                txtTongCong_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
                txtTongHDThu_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDThu);
                txtTongGiaBanThu_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanThu);
                txtTongCongThu_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongThu);
                txtTongHDTon_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDTon);
                txtTongGiaBanTon_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanTon);
                txtTongCongTon_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongTon);
            }
        }

        public void CountdgvNhanVien()
        {
            int TongHD = 0;
            long TongGiaBan = 0;
            long TongCong = 0;
            int TongHDThu = 0;
            long TongGiaBanThu = 0;
            long TongCongThu = 0;
            int TongHDTon = 0;
            long TongGiaBanTon = 0;
            long TongCongTon = 0;

            if (dgvNhanVien.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvNhanVien.Rows)
                {
                    if (!string.IsNullOrEmpty(item.Cells["TongHD_NV"].Value.ToString()))
                        TongHD += int.Parse(item.Cells["TongHD_NV"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBan_NV"].Value.ToString()))
                        TongGiaBan += long.Parse(item.Cells["TongGiaBan_NV"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCong_NV"].Value.ToString()))
                        TongCong += long.Parse(item.Cells["TongCong_NV"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDThu_NV"].Value.ToString()))
                        TongHDThu += int.Parse(item.Cells["TongHDThu_NV"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBanThu_NV"].Value.ToString()))
                        TongGiaBanThu += long.Parse(item.Cells["TongGiaBanThu_NV"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongThu_NV"].Value.ToString()))
                        TongCongThu += long.Parse(item.Cells["TongCongThu_NV"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDTon_NV"].Value.ToString()))
                        TongHDTon += int.Parse(item.Cells["TongHDTon_NV"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBanTon_NV"].Value.ToString()))
                        TongGiaBanTon += long.Parse(item.Cells["TongGiaBanTon_NV"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongTon_NV"].Value.ToString()))
                        TongCongTon += long.Parse(item.Cells["TongCongTon_NV"].Value.ToString());

                    if (string.IsNullOrEmpty(item.Cells["TongGiaBanThu_NV"].Value.ToString()))
                        item.Cells["TiLeGiaBan_NV"].Value = "0%";
                    else
                        item.Cells["TiLeGiaBan_NV"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongGiaBanThu_NV"].Value.ToString()) / double.Parse(item.Cells["TongGiaBan_NV"].Value.ToString())) * 100);
                    if (string.IsNullOrEmpty(item.Cells["TongCongThu_NV"].Value.ToString()))
                        item.Cells["TiLeTongCong_NV"].Value = "0%";
                    else
                        item.Cells["TiLeTongCong_NV"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongCongThu_NV"].Value.ToString()) / double.Parse(item.Cells["TongCong_NV"].Value.ToString())) * 100);
                }
                txtTongHD_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHD);
                txtTongGiaBan_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBan);
                txtTongCong_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
                txtTongHDThu_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDThu);
                txtTongGiaBanThu_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanThu);
                txtTongCongThu_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongThu);
                txtTongHDTon_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDTon);
                txtTongGiaBanTon_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanTon);
                txtTongCongTon_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongTon);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            List<TT_To> _lstTo = _cTo.GetDSHanhThu();

            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                if (chkNgayKiemTra.Checked)
                {
                    dt = _cHoaDon.GetNangSuat_Doi("TG", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
                    for (int i = 1; i < _lstTo.Count; i++)
                    {
                        dt.Merge(_cHoaDon.GetNangSuat_Doi("TG", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value));
                    }
                }
                else
                {
                    ///chọn tất cả các kỳ
                    if (cmbKy.SelectedIndex == 0)
                    {
                        dt = _cHoaDon.GetNangSuat_Doi("TG", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()));
                        for (int i = 1; i < _lstTo.Count; i++)
                        {
                            dt.Merge(_cHoaDon.GetNangSuat_Doi("TG", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString())));
                        }
                    }
                    ///chọn 1 kỳ cụ thể
                    else
                        if (cmbKy.SelectedIndex > 0)
                        {
                            dt = _cHoaDon.GetNangSuat_Doi("TG", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                            for (int i = 1; i < _lstTo.Count; i++)
                            {
                                dt.Merge(_cHoaDon.GetNangSuat_Doi("TG", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString())));
                            }
                        }
                }
                dgvHDTuGia.DataSource = dt;
                CountdgvHDTuGia();
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    if (chkNgayKiemTra.Checked)
                    {
                        dt = _cHoaDon.GetNangSuat_Doi("CQ", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
                        for (int i = 1; i < _lstTo.Count; i++)
                        {
                            dt.Merge(_cHoaDon.GetNangSuat_Doi("CQ", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value));
                        }
                    }
                    else
                    {
                        ///chọn tất cả các kỳ
                        if (cmbKy.SelectedIndex == 0)
                        {
                            dt = _cHoaDon.GetNangSuat_Doi("CQ", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()));
                            for (int i = 1; i < _lstTo.Count; i++)
                            {
                                dt.Merge(_cHoaDon.GetNangSuat_Doi("CQ", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString())));
                            }
                        }
                        ///chọn 1 kỳ cụ thể
                        else
                            if (cmbKy.SelectedIndex > 0)
                            {
                                dt = _cHoaDon.GetNangSuat_Doi("CQ", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                for (int i = 1; i < _lstTo.Count; i++)
                                {
                                    dt.Merge(_cHoaDon.GetNangSuat_Doi("CQ", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString())));
                                }
                            }
                    }
                    dgvHDCoQuan.DataSource = dt;
                    CountdgvHDCoQuan();
                }
        }

        private void btnInDoi_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    DataRow dr = ds.Tables["NangSuatThuTien"].NewRow();
                    dr["Nam"] = cmbNam.SelectedValue.ToString();
                    dr["Ky"] = cmbKy.SelectedItem.ToString();
                    dr["Loai"] = "TƯ GIA";
                    dr["TongHD"] = item.Cells["TongHD_TG"].Value;
                    dr["TongGiaBan"] = item.Cells["TongGiaBan_TG"].Value;
                    dr["TongCong"] = item.Cells["TongCong_TG"].Value;
                    dr["TongHDThu"] = item.Cells["TongHDThu_TG"].Value;
                    dr["TongGiaBanThu"] = item.Cells["TongGiaBanThu_TG"].Value;
                    dr["TongCongThu"] = item.Cells["TongCongThu_TG"].Value;
                    dr["TongHDTon"] = item.Cells["TongHDTon_TG"].Value;
                    dr["TongGiaBanTon"] = item.Cells["TongGiaBanTon_TG"].Value;
                    dr["TongCongTon"] = item.Cells["TongCongTon_TG"].Value;
                    dr["NhanVien"] = item.Cells["TenTo_TG"].Value;
                    dr["TiLeGiaBan"] = item.Cells["TiLeGiaBan_TG"].Value;
                    dr["TiLeTongCong"] = item.Cells["TiLeTongCong_TG"].Value;
                    ds.Tables["NangSuatThuTien"].Rows.Add(dr);
                }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                    foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                    {
                        DataRow dr = ds.Tables["NangSuatThuTien"].NewRow();
                        dr["Nam"] = cmbNam.SelectedValue.ToString();
                        dr["Ky"] = cmbKy.SelectedItem.ToString();
                        dr["Loai"] = "CƠ QUAN";
                        dr["TongHD"] = item.Cells["TongHD_CQ"].Value;
                        dr["TongGiaBan"] = item.Cells["TongGiaBan_CQ"].Value;
                        dr["TongCong"] = item.Cells["TongCong_CQ"].Value;
                        dr["TongHDThu"] = item.Cells["TongHDThu_CQ"].Value;
                        dr["TongGiaBanThu"] = item.Cells["TongGiaBanThu_CQ"].Value;
                        dr["TongCongThu"] = item.Cells["TongCongThu_CQ"].Value;
                        dr["TongHDTon"] = item.Cells["TongHDTon_CQ"].Value;
                        dr["TongGiaBanTon"] = item.Cells["TongGiaBanTon_CQ"].Value;
                        dr["TongCongTon"] = item.Cells["TongCongTon_CQ"].Value;
                        dr["NhanVien"] = item.Cells["TenTo_CQ"].Value;
                        dr["TiLeGiaBan"] = item.Cells["TiLeGiaBan_CQ"].Value;
                        dr["TiLeTongCong"] = item.Cells["TiLeTongCong_CQ"].Value;
                        ds.Tables["NangSuatThuTien"].Rows.Add(dr);
                    }

            rptNangSuatThuTien_Doi rpt = new rptNangSuatThuTien_Doi();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void btnInTo_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
                foreach (DataGridViewRow item in dgvNhanVien.Rows)
                {
                    DataRow dr = ds.Tables["NangSuatThuTien"].NewRow();
                    dr["Nam"] = cmbNam.SelectedValue.ToString();
                    dr["Ky"] = cmbKy.SelectedItem.ToString();
                    dr["To"] = dgvHDTuGia.SelectedRows[0].Cells["TenTo_TG"].Value.ToString();
                    dr["Loai"] = "TƯ GIA";
                    dr["TongHD"] = item.Cells["TongHD_NV"].Value;
                    dr["TongGiaBan"] = item.Cells["TongGiaBan_NV"].Value;
                    dr["TongCong"] = item.Cells["TongCong_NV"].Value;
                    dr["TongHDThu"] = item.Cells["TongHDThu_NV"].Value;
                    dr["TongGiaBanThu"] = item.Cells["TongGiaBanThu_NV"].Value;
                    dr["TongCongThu"] = item.Cells["TongCongThu_NV"].Value;
                    dr["TongHDTon"] = item.Cells["TongHDTon_NV"].Value;
                    dr["TongGiaBanTon"] = item.Cells["TongGiaBanTon_NV"].Value;
                    dr["TongCongTon"] = item.Cells["TongCongTon_NV"].Value;
                    dr["NhanVien"] = item.Cells["HoTen_NV"].Value;
                    dr["TiLeGiaBan"] = item.Cells["TiLeGiaBan_NV"].Value;
                    dr["TiLeTongCong"] = item.Cells["TiLeTongCong_NV"].Value;
                    ds.Tables["NangSuatThuTien"].Rows.Add(dr);
                }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                    foreach (DataGridViewRow item in dgvNhanVien.Rows)
                    {
                        DataRow dr = ds.Tables["NangSuatThuTien"].NewRow();
                        dr["Nam"] = cmbNam.SelectedValue.ToString();
                        dr["Ky"] = cmbKy.SelectedItem.ToString();
                        dr["To"] = dgvHDCoQuan.SelectedRows[0].Cells["TenTo_CQ"].Value.ToString();
                        dr["Loai"] = "CƠ QUAN";
                        dr["TongHD"] = item.Cells["TongHD_NV"].Value;
                        dr["TongGiaBan"] = item.Cells["TongGiaBan_NV"].Value;
                        dr["TongCong"] = item.Cells["TongCong_NV"].Value;
                        dr["TongHDThu"] = item.Cells["TongHDThu_NV"].Value;
                        dr["TongGiaBanThu"] = item.Cells["TongGiaBanThu_NV"].Value;
                        dr["TongCongThu"] = item.Cells["TongCongThu_NV"].Value;
                        dr["TongHDTon"] = item.Cells["TongHDTon_NV"].Value;
                        dr["TongGiaBanTon"] = item.Cells["TongGiaBanTon_NV"].Value;
                        dr["TongCongTon"] = item.Cells["TongCongTon_NV"].Value;
                        dr["NhanVien"] = item.Cells["HoTen_NV"].Value;
                        dr["TiLeGiaBan"] = item.Cells["TiLeGiaBan_NV"].Value;
                        dr["TiLeTongCong"] = item.Cells["TiLeTongCong_NV"].Value;
                        ds.Tables["NangSuatThuTien"].Rows.Add(dr);
                    }

            rptNangSuatThuTien_To rpt = new rptNangSuatThuTien_To();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void dgvHDTuGia_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongHD_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongGiaBan_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCong_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongHDThu_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongGiaBanThu_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCongThu_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongHDTon_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongGiaBanTon_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCongTon_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHDCoQuan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongHD_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongGiaBan_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongCong_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongHDThu_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongGiaBanThu_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongCongThu_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongHDTon_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongGiaBanTon_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongCongTon_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHDTuGia_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHDTuGia.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvHDCoQuan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHDCoQuan.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvHDTuGia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = new DataTable();
            if (chkNgayKiemTra.Checked)
            {
                dt = _cHoaDon.GetNangSuat_To("TG", int.Parse(dgvHDTuGia["MaTo_TG", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
            }
            else
            {
                ///chọn tất cả các kỳ
                if (cmbKy.SelectedIndex == 0)
                {
                    dt = _cHoaDon.GetNangSuat_To("TG", int.Parse(dgvHDTuGia["MaTo_TG", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()));
                }
                ///chọn 1 kỳ cụ thể
                else
                    if (cmbKy.SelectedIndex > 0)
                    {
                        dt = _cHoaDon.GetNangSuat_To("TG", int.Parse(dgvHDTuGia["MaTo_TG", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                    }
            }
            dgvNhanVien.DataSource = dt;
            CountdgvNhanVien();
        }

        private void dgvHDCoQuan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = new DataTable();
            if (chkNgayKiemTra.Checked)
            {
                dt = _cHoaDon.GetNangSuat_To("CQ", int.Parse(dgvHDCoQuan["MaTo_CQ", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
            }
            else
            {
                ///chọn tất cả các kỳ
                if (cmbKy.SelectedIndex == 0)
                {
                    dt = _cHoaDon.GetNangSuat_To("CQ", int.Parse(dgvHDCoQuan["MaTo_CQ", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()));
                }
                ///chọn 1 kỳ cụ thể
                else
                    if (cmbKy.SelectedIndex > 0)
                    {
                        dt = _cHoaDon.GetNangSuat_To("CQ", int.Parse(dgvHDCoQuan["MaTo_CQ", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                    }
            }
            dgvNhanVien.DataSource = dt;
            CountdgvNhanVien();
        }

        private void dgvNhanVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "TongHD_NV" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "TongGiaBan_NV" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "TongCong_NV" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "TongHDThu_NV" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "TongGiaBanThu_NV" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "TongCongThu_NV" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "TongHDTon_NV" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "TongGiaBanTon_NV" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "TongCongTon_NV" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvNhanVien_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvNhanVien.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void chkNgayKiemTra_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNgayKiemTra.Checked)
                dateGiaiTrach.Enabled = true;
            else
                dateGiaiTrach.Enabled = false;
        }

    }
}
