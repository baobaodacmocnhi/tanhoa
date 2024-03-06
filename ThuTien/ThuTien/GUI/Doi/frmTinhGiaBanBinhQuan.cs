using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.DAL.TongHop;
using System.Globalization;
using ThuTien.DAL;

namespace ThuTien.GUI.Doi
{
    public partial class frmTinhGiaBanBinhQuan : Form
    {
        CHoaDon _cHoaDon = new CHoaDon();
        CDCHD _cDCHD = new CDCHD();
        CGiaBanBinhQuan _cGBBQ = new CGiaBanBinhQuan();
        CThuongVu _cKinhDoanh = new CThuongVu();

        public frmTinhGiaBanBinhQuan()
        {
            InitializeComponent();
        }

        private void frmTinhGiaBanBinhQuan_Load(object sender, EventArgs e)
        {
            dgvGiaBanBinhQuan.AutoGenerateColumns = false;

            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            //if (cmbKy.SelectedIndex == 0)
            //    txtGiaBanBinhQuan.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _cHoaDon.TinhGiaBanBinhQuanByNam(int.Parse(cmbNam.SelectedValue.ToString())));
            //else
            //    if (cmbKy.SelectedIndex > 0)
            //        txtGiaBanBinhQuan.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _cHoaDon.TinhGiaBanBinhQuanByNamKy(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString())));
            dgvGiaBanBinhQuan.DataSource = _cGBBQ.GetDS(int.Parse(cmbNam.SelectedValue.ToString()));
            double TongDoanhThu = 0;
            double TongSanLuong = 0;
            double TongTyLeThucThu = 0;
            for (int i = 0; i < dgvGiaBanBinhQuan.RowCount; i++)
            {
                //DataTable dtDCHD = _cDCHD.GetTongChuanThu(int.Parse(cmbNam.SelectedValue.ToString()), i + 1);
                //if (dtDCHD.Rows.Count > 0)
                //{
                //    dgvGiaBanBinhQuan["TongGiaBan", i].Value = long.Parse(dgvGiaBanBinhQuan["TongGiaBan", i].Value.ToString()) - long.Parse(dtDCHD.Rows[0]["GIABAN_END"].ToString()) + long.Parse(dtDCHD.Rows[0]["GIABAN_BD"].ToString());
                //    dgvGiaBanBinhQuan["GiaBanBinhQuan", i].Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", long.Parse(dgvGiaBanBinhQuan["TongGiaBan", i].Value.ToString()) / long.Parse(dgvGiaBanBinhQuan["TongTieuThu", i].Value.ToString()));
                //}
                //else
                dgvGiaBanBinhQuan["GiaBanBinhQuan", i].Value = double.Parse(dgvGiaBanBinhQuan["TongGiaBan", i].Value.ToString()) / double.Parse(dgvGiaBanBinhQuan["TongTieuThu", i].Value.ToString());
                TongDoanhThu += double.Parse(dgvGiaBanBinhQuan["TongGiaBan", i].Value.ToString());
                TongSanLuong += double.Parse(dgvGiaBanBinhQuan["TongTieuThu", i].Value.ToString());
                DataTable dt = _cHoaDon.getNangSuat_Doi(int.Parse(dgvGiaBanBinhQuan["Nam", i].Value.ToString()), int.Parse(dgvGiaBanBinhQuan["Ky", i].Value.ToString()), new DateTime(int.Parse(dgvGiaBanBinhQuan["Nam", i].Value.ToString()), int.Parse(dgvGiaBanBinhQuan["Ky", i].Value.ToString()), DateTime.DaysInMonth(int.Parse(dgvGiaBanBinhQuan["Nam", i].Value.ToString()), int.Parse(dgvGiaBanBinhQuan["Ky", i].Value.ToString())) - 1));
                DataTable dtDCHD = _cDCHD.getNangSuat_ChuanThu_Doi(int.Parse(dgvGiaBanBinhQuan["Nam", i].Value.ToString()), int.Parse(dgvGiaBanBinhQuan["Ky", i].Value.ToString()), new DateTime(int.Parse(dgvGiaBanBinhQuan["Nam", i].Value.ToString()), int.Parse(dgvGiaBanBinhQuan["Ky", i].Value.ToString()), DateTime.DaysInMonth(int.Parse(dgvGiaBanBinhQuan["Nam", i].Value.ToString()), int.Parse(dgvGiaBanBinhQuan["Ky", i].Value.ToString())) - 1));
                if (dtDCHD != null && dtDCHD.Rows.Count > 0)
                {
                    dgvGiaBanBinhQuan["TyLeThuThang", i].Value = Math.Round((double.Parse(dt.Rows[0]["TongGiaBanThu"].ToString()) - double.Parse(dtDCHD.Rows[0]["TongGiaBanThu"].ToString())) / (double.Parse(dt.Rows[0]["TongGiaBan"].ToString()) - double.Parse(dtDCHD.Rows[0]["TongGiaBan"].ToString())) * 100, 2);
                    dgvGiaBanBinhQuan["TyLeThucThu", i].Value = Math.Round((double.Parse(dt.Rows[0]["TongGiaBanThucThu"].ToString()) - double.Parse(dtDCHD.Rows[0]["TongGiaBanThucThu"].ToString())) / (double.Parse(dt.Rows[0]["TongGiaBan"].ToString()) - double.Parse(dtDCHD.Rows[0]["TongGiaBan"].ToString())) * 100, 2);
                }
                TongTyLeThucThu += double.Parse(dgvGiaBanBinhQuan["TyLeThucThu", i].Value.ToString());
            }
            txtTongDoanhThu.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongDoanhThu);
            txtTongSanLuong.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongSanLuong);
            txtGiaBanBinhQuan.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", Math.Round((TongDoanhThu / TongSanLuong)));
            txtTongTyLeThucThu.Text = Math.Round((TongTyLeThucThu / dgvGiaBanBinhQuan.RowCount), 2).ToString();
        }

        private void dgvGiaBanBinhQuan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvGiaBanBinhQuan.Columns[e.ColumnIndex].Name == "TongGiaBan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvGiaBanBinhQuan.Columns[e.ColumnIndex].Name == "TongTieuThu" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvGiaBanBinhQuan.Columns[e.ColumnIndex].Name == "GiaBanBinhQuan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            switch (cmbLoai.SelectedItem.ToString())
            {
                case "Cắt Tạm":
                    txtDanhBo.Text = _cKinhDoanh.getDanhBo_CatTam(int.Parse(txtMa.Text.Trim().Replace("-", "")));
                    break;
                case "Cắt Hủy":
                    txtDanhBo.Text = _cKinhDoanh.getDanhBo_CatHuy(int.Parse(txtMa.Text.Trim().Replace("-", "")));
                    break;
                default:
                    break;
            }
        }

    }
}
