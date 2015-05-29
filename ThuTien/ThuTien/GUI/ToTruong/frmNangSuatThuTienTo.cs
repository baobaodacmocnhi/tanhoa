using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.DAL.QuanTri;
using System.Globalization;
using ThuTien.BaoCao;
using KTKS_DonKH.GUI.BaoCao;
using ThuTien.BaoCao.ToTruong;

namespace ThuTien.GUI.ToTruong
{
    public partial class frmNangSuatThuTienTo : Form
    {
        //string _mnu = "mnuKiemTraTon";
        CHoaDon _cHoaDon = new CHoaDon();

        public frmNangSuatThuTienTo()
        {
            InitializeComponent();
        }

        private void frmNangSuatThuTien_Load(object sender, EventArgs e)
        {
            dgvHDTuGia.AutoGenerateColumns = false;
            dgvHDCoQuan.AutoGenerateColumns = false;

            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";

            lbTo.Text = "Tổ  " + CNguoiDung.TenTo;
        }

        public void LoadDataGridView()
        {
            int TongHD = 0;
            long TongGiaBan = 0;
            int TongHDThu = 0;
            long TongGiaBanThu = 0;
            int TongHDTon = 0;
            long TongGiaBanTon = 0;
            if (dgvHDTuGia.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    TongHD += int.Parse(item.Cells["TongHD_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBan_TG"].Value.ToString()))
                        TongGiaBan += long.Parse(item.Cells["TongGiaBan_TG"].Value.ToString());
                    TongHDThu += int.Parse(item.Cells["TongHDThu_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBanThu_TG"].Value.ToString()))
                        TongGiaBanThu += long.Parse(item.Cells["TongGiaBanThu_TG"].Value.ToString());
                    TongHDTon += int.Parse(item.Cells["TongHDTon_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBanTon_TG"].Value.ToString()))
                        TongGiaBanTon += long.Parse(item.Cells["TongGiaBanTon_TG"].Value.ToString());
                    if (string.IsNullOrEmpty(item.Cells["TongGiaBanThu_TG"].Value.ToString()))
                        item.Cells["TiLe_TG"].Value = "0%";
                    else
                        item.Cells["TiLe_TG"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongGiaBanThu_TG"].Value.ToString()) / double.Parse(item.Cells["TongGiaBan_TG"].Value.ToString())) * 100);
                }
                txtTongHD_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHD);
                txtTongGiaBan_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBan);
                txtTongHDThu_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDThu);
                txtTongGiaBanThu_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanThu);
                txtTongHDTon_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDTon);
                txtTongGiaBanTon_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanTon);
            }
            TongHD = 0;
            TongGiaBan = 0;
            TongHDThu = 0;
            TongGiaBanThu = 0;
            TongHDTon = 0;
            TongGiaBanTon = 0;
            if (dgvHDCoQuan.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                {
                    TongHD += int.Parse(item.Cells["TongHD_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBan_CQ"].Value.ToString()))
                        TongGiaBan += long.Parse(item.Cells["TongGiaBan_CQ"].Value.ToString());
                    TongHDThu += int.Parse(item.Cells["TongHDThu_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBanThu_CQ"].Value.ToString()))
                        TongGiaBanThu += long.Parse(item.Cells["TongGiaBanThu_CQ"].Value.ToString());
                    TongHDTon += int.Parse(item.Cells["TongHDTon_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBanTon_CQ"].Value.ToString()))
                        TongGiaBanTon += long.Parse(item.Cells["TongGiaBanTon_CQ"].Value.ToString());
                    if (string.IsNullOrEmpty(item.Cells["TongGiaBanThu_CQ"].Value.ToString()))
                        item.Cells["TiLe_CQ"].Value = "0%";
                    else
                        item.Cells["TiLe_CQ"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongGiaBanThu_CQ"].Value.ToString()) / double.Parse(item.Cells["TongGiaBan_CQ"].Value.ToString())) * 100);
                }
                txtTongHD_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHD);
                txtTongGiaBan_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBan);
                txtTongHDThu_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDThu);
                txtTongGiaBanThu_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanThu);
                txtTongHDTon_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDTon);
                txtTongGiaBanTon_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanTon);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            ///chọn tất cả các kỳ
            if (cmbKy.SelectedIndex == 0)
            {
                dgvHDTuGia.DataSource = _cHoaDon.GetNangSuatByNam_To(CNguoiDung.MaTo, "TG", int.Parse(cmbNam.SelectedValue.ToString()));
                dgvHDCoQuan.DataSource = _cHoaDon.GetNangSuatByNam_To(CNguoiDung.MaTo, "CQ", int.Parse(cmbNam.SelectedValue.ToString()));
            }
            ///chọn 1 kỳ cụ thể
            else
                if (cmbKy.SelectedIndex > 0)
                {
                    dgvHDTuGia.DataSource = _cHoaDon.GetNangSuatByNamKy_To(CNguoiDung.MaTo, "TG", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                    dgvHDCoQuan.DataSource = _cHoaDon.GetNangSuatByNamKy_To(CNguoiDung.MaTo, "CQ", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                }
            LoadDataGridView();
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
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongHDThu_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongGiaBanThu_TG" && e.Value != null)
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
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongHDThu_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongGiaBanThu_CQ" && e.Value != null)
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

        private void btnIn_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvHDTuGia.Rows)
            {
                DataRow dr = ds.Tables["NangSuatThuTien"].NewRow();
                dr["Nam"] = cmbNam.SelectedItem.ToString();
                dr["Ky"] = cmbKy.SelectedItem.ToString();
                dr["To"] = CNguoiDung.TenTo;
                dr["Loai"] = "Tư Gia";
                dr["TongHD"] = item.Cells["TongHD_TG"].Value;
                dr["TongGiaBan"] = item.Cells["TongGiaBan_TG"].Value;
                dr["TongHDThu"] = item.Cells["TongHDThu_TG"].Value;
                dr["TongGiaBanThu"] = item.Cells["TongGiaBanThu_TG"].Value;
                dr["TongHDTon"] = item.Cells["TongHDTon_TG"].Value;
                dr["TongGiaBanTon"] = item.Cells["TongGiaBanTon_TG"].Value;
                dr["NhanVien"] = item.Cells["HoTen_TG"].Value;
                dr["TiLe"] = item.Cells["TiLe_TG"].Value;
                ds.Tables["NangSuatThuTien"].Rows.Add(dr);
            }

            foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
            {
                DataRow dr = ds.Tables["NangSuatThuTien"].NewRow();
                dr["Nam"] = cmbNam.SelectedItem.ToString();
                dr["Ky"] = cmbKy.SelectedItem.ToString();
                dr["To"] = CNguoiDung.TenTo;
                dr["Loai"] = "Cơ Quan";
                dr["TongHD"] = item.Cells["TongHD_CQ"].Value;
                dr["TongGiaBan"] = item.Cells["TongGiaBan_CQ"].Value;
                dr["TongHDThu"] = item.Cells["TongHDThu_CQ"].Value;
                dr["TongGiaBanThu"] = item.Cells["TongGiaBanThu_CQ"].Value;
                dr["TongHDTon"] = item.Cells["TongHDTon_CQ"].Value;
                dr["TongGiaBanTon"] = item.Cells["TongGiaBanTon_CQ"].Value;
                dr["NhanVien"] = item.Cells["HoTen_CQ"].Value;
                dr["TiLe"] = item.Cells["TiLe_CQ"].Value;
                ds.Tables["NangSuatThuTien"].Rows.Add(dr);
            }

            rptNangSuatThuTien rpt = new rptNangSuatThuTien();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }

        
    }
}
