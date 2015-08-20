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
using ThuTien.LinQ;
using System.Globalization;
using ThuTien.BaoCao;
using KTKS_DonKH.GUI.BaoCao;
using ThuTien.DAL.Quay;

namespace ThuTien.GUI.ToTruong
{
    public partial class frmKiemTraTonTo : Form
    {
        //string _mnu = "mnuKiemTraTonTo";
        CHoaDon _cHoaDon = new CHoaDon();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CLenhHuy _cLenhHuy = new CLenhHuy();

        public frmKiemTraTonTo()
        {
            InitializeComponent();
        }

        private void frmKiemTraTon_Load(object sender, EventArgs e)
        {
            dgvHDTuGia.AutoGenerateColumns = false;
            dgvHDCoQuan.AutoGenerateColumns = false;

            TT_NguoiDung nguoidung = new TT_NguoiDung();
            nguoidung.MaND = -1;
            nguoidung.HoTen = "Tất cả";
            List<TT_NguoiDung> lst = _cNguoiDung.GetDSHanhThuByMaTo(CNguoiDung.MaTo);
            lst.Insert(0, nguoidung);
            cmbNhanVien.DataSource = lst;
            cmbNhanVien.DisplayMember = "HoTen";
            cmbNhanVien.ValueMember = "MaND";

            DataTable dtNam = _cHoaDon.GetNam();
            DataRow dr = dtNam.NewRow();
            dr["ID"] = "Tất Cả";
            dtNam.Rows.InsertAt(dr, 0);
            cmbNam.DataSource = dtNam;
            cmbNam.DisplayMember = "ID";
            cmbNam.ValueMember = "Nam";

            lbTo.Text = "Tổ  " + CNguoiDung.TenTo;

            dateGiaiTrach.Value = DateTime.Now;
        }

        public void CountdgvHDTuGia()
        {
            int TongHD = 0;
            long TongCong = 0;
            int TongHDThu = 0;
            long TongCongThu = 0;
            int TongHDTon = 0;
            long TongCongTon = 0;

            if (dgvHDTuGia.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    if (!string.IsNullOrEmpty(item.Cells["TongHD_TG"].Value.ToString()))
                        TongHD += int.Parse(item.Cells["TongHD_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCong_TG"].Value.ToString()))
                        TongCong += long.Parse(item.Cells["TongCong_TG"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDThu_TG"].Value.ToString()))
                        TongHDThu += int.Parse(item.Cells["TongHDThu_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongThu_TG"].Value.ToString()))
                        TongCongThu += long.Parse(item.Cells["TongCongThu_TG"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDTon_TG"].Value.ToString()))
                        TongHDTon += int.Parse(item.Cells["TongHDTon_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongTon_TG"].Value.ToString()))
                        TongCongTon += long.Parse(item.Cells["TongCongTon_TG"].Value.ToString());
                }
                txtTongHD_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHD);
                txtTongCong_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
                txtTongHDThu_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDThu);
                txtTongCongThu_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongThu);
                txtTongHDTon_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDTon);
                txtTongCongTon_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongTon);
            }
        }

        public void CountdgvHDCoQuan()
        {
            int TongHD = 0;
            long TongCong = 0;
            int TongHDThu = 0;
            long TongCongThu = 0;
            int TongHDTon = 0;
            long TongCongTon = 0;

            if (dgvHDCoQuan.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                {
                    if (!string.IsNullOrEmpty(item.Cells["TongHD_CQ"].Value.ToString()))
                        TongHD += int.Parse(item.Cells["TongHD_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCong_CQ"].Value.ToString()))
                        TongCong += long.Parse(item.Cells["TongCong_CQ"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDThu_CQ"].Value.ToString()))
                        TongHDThu += int.Parse(item.Cells["TongHDThu_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongThu_CQ"].Value.ToString()))
                        TongCongThu += long.Parse(item.Cells["TongCongThu_CQ"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDTon_CQ"].Value.ToString()))
                        TongHDTon += int.Parse(item.Cells["TongHDTon_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongTon_CQ"].Value.ToString()))
                        TongCongTon += long.Parse(item.Cells["TongCongTon_CQ"].Value.ToString());
                }
                txtTongHD_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHD);
                txtTongCong_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
                txtTongHDThu_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDThu);
                txtTongCongThu_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongThu);
                txtTongHDTon_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDTon);
                txtTongCongTon_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongTon);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                ///chọn tất cả nhân viên trong tổ
                if (cmbNhanVien.SelectedIndex == 0)
                {
                    if (chkNgayKiemTra.Checked)
                    {
                        dgvHDTuGia.DataSource = _cHoaDon.GetTongTon_To("TG", CNguoiDung.MaTo, dateGiaiTrach.Value);
                    }
                    else
                    {
                        ///chọn tất cả các năm
                        if (cmbNam.SelectedIndex == 0)
                        {
                            dgvHDTuGia.DataSource = _cHoaDon.GetTongTon_To("TG", CNguoiDung.MaTo);
                        }
                        else
                            ///chọn 1 năm cụ thể
                            if (cmbNam.SelectedIndex > 0)
                                ///chọn tất cả các kỳ
                                if (cmbKy.SelectedIndex == 0)
                                {
                                    dgvHDTuGia.DataSource = _cHoaDon.GetTongTon_To("TG", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()));
                                }
                                ///chọn 1 kỳ cụ thể
                                else
                                    if (cmbKy.SelectedIndex > 0)
                                    {
                                        dgvHDTuGia.DataSource = _cHoaDon.GetTongTon_To("TG", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                    }
                    }
                }
                else
                    ///chọn 1 nhân viên cụ thể
                    if (cmbNhanVien.SelectedIndex > 0)
                    {
                        if (chkNgayKiemTra.Checked)
                        {
                            dgvHDTuGia.DataSource = _cHoaDon.GetTongTonByMaNV_HanhThu("TG", int.Parse(cmbNhanVien.SelectedValue.ToString()), dateGiaiTrach.Value);
                        }
                        else
                        {
                            ///chọn tất cả các năm
                            if (cmbNam.SelectedIndex == 0)
                            {
                                dgvHDTuGia.DataSource = _cHoaDon.GetTongTonByMaNV_HanhThu("TG", int.Parse(cmbNhanVien.SelectedValue.ToString()));
                            }
                            else
                                ///chọn 1 năm cụ thể
                                if (cmbNam.SelectedIndex > 0)
                                    ///chọn tất cả các kỳ
                                    if (cmbKy.SelectedIndex == 0)
                                    {
                                        dgvHDTuGia.DataSource = _cHoaDon.GetTongTonByMaNV_HanhThu("TG", int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()));
                                    }
                                    ///chọn 1 kỳ cụ thể
                                    else
                                        if (cmbKy.SelectedIndex > 0)
                                        {
                                            dgvHDTuGia.DataSource = _cHoaDon.GetTongTonByMaNV_HanhThu("TG", int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                        }
                        }
                    }
                CountdgvHDTuGia();
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    ///chọn tất cả nhân viên trong tổ
                    if (cmbNhanVien.SelectedIndex == 0)
                    {
                        if (chkNgayKiemTra.Checked)
                        {
                            dgvHDCoQuan.DataSource = _cHoaDon.GetTongTon_To("CQ", CNguoiDung.MaTo, dateGiaiTrach.Value);
                        }
                        else
                        {
                            ///chọn tất cả các năm
                            if (cmbNam.SelectedIndex == 0)
                            {
                                dgvHDCoQuan.DataSource = _cHoaDon.GetTongTon_To("CQ", CNguoiDung.MaTo);
                            }
                            else
                                ///chọn 1 năm cụ thể
                                if (cmbNam.SelectedIndex > 0)
                                    ///chọn tất cả các kỳ
                                    if (cmbKy.SelectedIndex == 0)
                                    {
                                        dgvHDCoQuan.DataSource = _cHoaDon.GetTongTon_To("CQ", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()));
                                    }
                                    ///chọn 1 kỳ cụ thể
                                    else
                                        if (cmbKy.SelectedIndex > 0)
                                        {
                                            dgvHDCoQuan.DataSource = _cHoaDon.GetTongTon_To("CQ", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                        }
                        }
                    }
                    else
                        ///chọn 1 nhân viên cụ thể
                        if (cmbNhanVien.SelectedIndex > 0)
                        {
                            if (chkNgayKiemTra.Checked)
                            {
                                dgvHDCoQuan.DataSource = _cHoaDon.GetTongTonByMaNV_HanhThu("CQ", int.Parse(cmbNhanVien.SelectedValue.ToString()), dateGiaiTrach.Value);
                            }
                            else
                            {
                                ///chọn tất cả các năm
                                if (cmbNam.SelectedIndex == 0)
                                {
                                    dgvHDTuGia.DataSource = _cHoaDon.GetTongTonByMaNV_HanhThu("CQ", int.Parse(cmbNhanVien.SelectedValue.ToString()));
                                }
                                else
                                    ///chọn 1 năm cụ thể
                                    if (cmbNam.SelectedIndex > 0)
                                        ///chọn tất cả các kỳ
                                        if (cmbKy.SelectedIndex == 0)
                                        {
                                            dgvHDCoQuan.DataSource = _cHoaDon.GetTongTonByMaNV_HanhThu("CQ", int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()));
                                        }
                                        ///chọn 1 kỳ cụ thể
                                        else
                                            if (cmbKy.SelectedIndex > 0)
                                            {
                                                dgvHDCoQuan.DataSource = _cHoaDon.GetTongTonByMaNV_HanhThu("CQ", int.Parse(cmbNhanVien.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                            }
                            }
                        }
                    CountdgvHDCoQuan();
                }
        }

        private void dgvHDTuGia_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongHD_TG" && e.Value != null)
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
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCongThu_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongHDTon_TG" && e.Value != null)
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
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongCong_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongHDThu_CQ" && e.Value != null)
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

        private void btnInDSNhanVien_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dsBaoCao ds = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                if (chkNgayKiemTra.Checked)
                {
                    dt = _cHoaDon.GetDSTon_NV("TG", int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaNV_TG"].Value.ToString()), dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                }
                else
                {
                    if (cmbNam.SelectedIndex == 0)
                        dt = _cHoaDon.GetDSTon_NV("TG", int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaNV_TG"].Value.ToString()), int.Parse(txtSoKy.Text.Trim()));
                    else
                        if (cmbNam.SelectedIndex > 0)
                    if (cmbKy.SelectedIndex == 0)
                        dt = _cHoaDon.GetDSTon_NV("TG", int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaNV_TG"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtSoKy.Text.Trim()));
                    else
                        if (cmbKy.SelectedIndex > 1)
                            dt = _cHoaDon.GetDSTon_NV("TG", int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaNV_TG"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                    foreach (DataRow item in dt.Rows)
                    {
                        DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                        dr["LoaiBaoCao"] = "TƯ GIA TỒN";
                        dr["DanhBo"] = item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
                        dr["Ky"] = item["Ky"];
                        dr["MLT"] = item["MLT"];
                        dr["TongCong"] = item["TongCong"];
                        dr["SoPhatHanh"] = item["SoPhatHanh"];
                        dr["SoHoaDon"] = item["SoHoaDon"];
                        dr["NhanVien"] = dgvHDTuGia.SelectedRows[0].Cells["HoTen_TG"].Value.ToString();
                        if (_cLenhHuy.CheckExist(item["SoHoaDon"].ToString()))
                            dr["LenhHuy"] = true;
                        ds.Tables["DSHoaDon"].Rows.Add(dr);
                    }
                }
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    if (chkNgayKiemTra.Checked)
                    {
                        dt = _cHoaDon.GetDSTon_NV("CQ", int.Parse(dgvHDCoQuan.SelectedRows[0].Cells["MaNV_TG"].Value.ToString()), dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                    }
                    else
                    {
                        if (cmbNam.SelectedIndex == 0)
                            dt = _cHoaDon.GetDSTon_NV("CQ", int.Parse(dgvHDCoQuan.SelectedRows[0].Cells["MaNV_CQ"].Value.ToString()), int.Parse(txtSoKy.Text.Trim()));
                        else
                            if (cmbNam.SelectedIndex > 0)
                        if (cmbKy.SelectedIndex == 0)
                            dt = _cHoaDon.GetDSTon_NV("CQ", int.Parse(dgvHDCoQuan.SelectedRows[0].Cells["MaNV_CQ"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtSoKy.Text.Trim()));
                        else
                            if (cmbKy.SelectedIndex > 1)
                                dt = _cHoaDon.GetDSTon_NV("CQ", int.Parse(dgvHDCoQuan.SelectedRows[0].Cells["MaNV_CQ"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                        foreach (DataRow item in dt.Rows)
                        {
                            DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                            dr["LoaiBaoCao"] = "CƠ QUAN TỒN";
                            dr["DanhBo"] = item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
                            dr["Ky"] = item["Ky"];
                            dr["MLT"] = item["MLT"];
                            dr["TongCong"] = item["TongCong"];
                            dr["SoPhatHanh"] = item["SoPhatHanh"];
                            dr["SoHoaDon"] = item["SoHoaDon"];
                            dr["NhanVien"] = dgvHDCoQuan.SelectedRows[0].Cells["HoTen_CQ"].Value.ToString();
                            if (_cLenhHuy.CheckExist(item["SoHoaDon"].ToString()))
                                dr["LenhHuy"] = true;
                            ds.Tables["DSHoaDon"].Rows.Add(dr);
                        }
                    }
                }
            rptDSHoaDon rpt = new rptDSHoaDon();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnInDSTo_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dsBaoCao ds = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                if (chkNgayKiemTra.Checked)
                {
                    dt = _cHoaDon.GetDSTon_To("TG", CNguoiDung.MaTo, dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                }
                else
                {
                    if (cmbNam.SelectedIndex == 0)
                        dt = _cHoaDon.GetDSTon_To("TG", CNguoiDung.MaTo, int.Parse(txtSoKy.Text.Trim()));
                    else
                        if (cmbNam.SelectedIndex > 0)
                            if (cmbKy.SelectedIndex == 0)
                                dt = _cHoaDon.GetDSTon_To("TG", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtSoKy.Text.Trim()));
                            else
                                if (cmbKy.SelectedIndex > 1)
                                    dt = _cHoaDon.GetDSTon_To("TG", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                    foreach (DataRow item in dt.Rows)
                    {
                        DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                        dr["LoaiBaoCao"] = "TƯ GIA TỒN";
                        dr["DanhBo"] = item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
                        dr["Ky"] = item["Ky"];
                        dr["MLT"] = item["MLT"];
                        dr["TongCong"] = item["TongCong"];
                        dr["SoPhatHanh"] = item["SoPhatHanh"];
                        dr["SoHoaDon"] = item["SoHoaDon"];
                        dr["NhanVien"] = dgvHDTuGia.SelectedRows[0].Cells["HoTen_TG"].Value.ToString();
                        if (_cLenhHuy.CheckExist(item["SoHoaDon"].ToString()))
                            dr["LenhHuy"] = true;
                        ds.Tables["DSHoaDon"].Rows.Add(dr);
                    }
                }
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    if (chkNgayKiemTra.Checked)
                    {
                        dt = _cHoaDon.GetDSTon_To("CQ", CNguoiDung.MaTo, dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                    }
                    else
                    {
                        if (cmbNam.SelectedIndex == 0)
                            dt = _cHoaDon.GetDSTon_To("CQ", CNguoiDung.MaTo, int.Parse(txtSoKy.Text.Trim()));
                        else
                            if (cmbNam.SelectedIndex > 0)
                                if (cmbKy.SelectedIndex == 0)
                                    dt = _cHoaDon.GetDSTon_To("CQ", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtSoKy.Text.Trim()));
                                else
                                    if (cmbKy.SelectedIndex > 1)
                                        dt = _cHoaDon.GetDSTon_To("CQ", CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                        foreach (DataRow item in dt.Rows)
                        {
                            DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                            dr["LoaiBaoCao"] = "CƠ QUAN TỒN";
                            dr["DanhBo"] = item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
                            dr["Ky"] = item["Ky"];
                            dr["MLT"] = item["MLT"];
                            dr["TongCong"] = item["TongCong"];
                            dr["SoPhatHanh"] = item["SoPhatHanh"];
                            dr["SoHoaDon"] = item["SoHoaDon"];
                            dr["NhanVien"] = dgvHDCoQuan.SelectedRows[0].Cells["HoTen_CQ"].Value.ToString();
                            if (_cLenhHuy.CheckExist(item["SoHoaDon"].ToString()))
                                dr["LenhHuy"] = true;
                            ds.Tables["DSHoaDon"].Rows.Add(dr);
                        }
                    }
                }
            rptDSHoaDon rpt = new rptDSHoaDon();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
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
