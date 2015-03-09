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

namespace ThuTien.GUI.ToTruong
{
    public partial class frmKiemTraTon : Form
    {
        string _mnu = "mnuKiemTraTon";
        CHoaDon _cHoaDon = new CHoaDon();
        CNguoiDung _cNguoiDung = new CNguoiDung();

        public frmKiemTraTon()
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

            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";

            lbTo.Text = "Tổ  " + CNguoiDung.TenTo;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            ///chọn tất cả nhân viên trong tổ
            if (cmbNhanVien.SelectedValue.ToString() == "-1")
                ///chọn tất cả các kỳ
                if (cmbKy.SelectedIndex != -1 && cmbKy.SelectedIndex != 0)
                {
                    dgvHDTuGia.DataSource = _cHoaDon.GetTongTonByNam(CNguoiDung.MaTo, "TG", int.Parse(cmbNam.SelectedValue.ToString()));
                    dgvHDCoQuan.DataSource = _cHoaDon.GetTongTonByNam(CNguoiDung.MaTo, "CQ", int.Parse(cmbNam.SelectedValue.ToString()));
                }
                ///chọn 1 kỳ cụ thể
                else
                {
                    dgvHDTuGia.DataSource = _cHoaDon.GetTongTonByNamKy(CNguoiDung.MaTo, "TG", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedValue.ToString()));
                    dgvHDCoQuan.DataSource = _cHoaDon.GetTongTonByNamKy(CNguoiDung.MaTo, "CQ", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedValue.ToString()));
                }
            ///chọn 1 nhân viên cụ thể
            else
                ///chọn tất cả các kỳ
                if (cmbKy.SelectedIndex != -1 && cmbKy.SelectedIndex != 0)
                {
                    dgvHDTuGia.DataSource = _cHoaDon.GetTongTonByMaNV_HanhThuNam(int.Parse(cmbNhanVien.SelectedValue.ToString()), "TG", int.Parse(cmbNam.SelectedValue.ToString()));
                    dgvHDCoQuan.DataSource = _cHoaDon.GetTongTonByMaNV_HanhThuNam(int.Parse(cmbNhanVien.SelectedValue.ToString()), "CQ", int.Parse(cmbNam.SelectedValue.ToString()));
                }
                ///chọn 1 kỳ cụ thể
                else
                {
                    dgvHDTuGia.DataSource = _cHoaDon.GetTongTonByMaNV_HanhThuNamKy(int.Parse(cmbNhanVien.SelectedValue.ToString()), "TG", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedValue.ToString()));
                    dgvHDCoQuan.DataSource = _cHoaDon.GetTongTonByMaNV_HanhThuNamKy(int.Parse(cmbNhanVien.SelectedValue.ToString()), "CQ", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedValue.ToString()));
                }
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
    }
}
