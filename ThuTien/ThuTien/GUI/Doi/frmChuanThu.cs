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
using System.Globalization;
using ThuTien.LinQ;
using ThuTien.DAL.TongHop;

namespace ThuTien.GUI.Doi
{
    public partial class frmChuanThu : Form
    {
        CTo _cTo = new CTo();
        CHoaDon _cHoaDon = new CHoaDon();
        CDCHD _cDCHD = new CDCHD();

        public frmChuanThu()
        {
            InitializeComponent();
        }

        private void frmChuanThu_Load(object sender, EventArgs e)
        {
            dgvHDTuGia.AutoGenerateColumns = false;
            dgvHDCoQuan.AutoGenerateColumns = false;

            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";
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
            DataTable dtTG = new DataTable();
            DataTable dtCQ = new DataTable();
            DataTable dtTG_DCHD = new DataTable();
            DataTable dtCQ_DCHD = new DataTable();
            List<TT_To> lst = _cTo.GetDSHanhThu();

            ///chọn tất cả các kỳ
            if (cmbKy.SelectedIndex != -1 && cmbKy.SelectedIndex == 0)
            {
                dtTG = _cHoaDon.GetNangSuatByNam_Doi(lst[0].MaTo, "TG", int.Parse(cmbNam.SelectedValue.ToString()));
                dtCQ = _cHoaDon.GetNangSuatByNam_Doi(lst[0].MaTo, "CQ", int.Parse(cmbNam.SelectedValue.ToString()));
                dtTG_DCHD = _cDCHD.GetChuanThuByNam(lst[0].MaTo, "TG", int.Parse(cmbNam.SelectedValue.ToString()));
                dtCQ_DCHD = _cDCHD.GetChuanThuByNam(lst[0].MaTo, "CQ", int.Parse(cmbNam.SelectedValue.ToString()));
                for (int i = 1; i < lst.Count; i++)
                {
                    dtTG.Merge(_cHoaDon.GetNangSuatByNam_Doi(lst[i].MaTo, "TG", int.Parse(cmbNam.SelectedValue.ToString())));
                    dtCQ.Merge(_cHoaDon.GetNangSuatByNam_Doi(lst[i].MaTo, "CQ", int.Parse(cmbNam.SelectedValue.ToString())));
                    dtTG_DCHD.Merge(_cDCHD.GetChuanThuByNam(lst[i].MaTo, "TG", int.Parse(cmbNam.SelectedValue.ToString())));
                    dtCQ_DCHD.Merge(_cDCHD.GetChuanThuByNam(lst[i].MaTo, "CQ", int.Parse(cmbNam.SelectedValue.ToString())));
                }
            }
            ///chọn 1 kỳ cụ thể
            else
                if (cmbKy.SelectedIndex != -1 && cmbKy.SelectedIndex > 0)
                {
                    dtTG = _cHoaDon.GetNangSuatByNamKy_Doi(lst[0].MaTo, "TG", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                    dtCQ = _cHoaDon.GetNangSuatByNamKy_Doi(lst[0].MaTo, "CQ", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                    dtTG_DCHD = _cDCHD.GetChuanThuByNamKy(lst[0].MaTo, "TG", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                    dtCQ_DCHD = _cDCHD.GetChuanThuByNamKy(lst[0].MaTo, "CQ", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                    for (int i = 1; i < lst.Count; i++)
                    {
                        dtTG.Merge(_cHoaDon.GetNangSuatByNamKy_Doi(lst[i].MaTo, "TG", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString())));
                        dtCQ.Merge(_cHoaDon.GetNangSuatByNamKy_Doi(lst[i].MaTo, "CQ", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString())));
                        dtTG_DCHD.Merge(_cDCHD.GetChuanThuByNamKy(lst[i].MaTo, "TG", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString())));
                        dtCQ_DCHD.Merge(_cDCHD.GetChuanThuByNamKy(lst[i].MaTo, "CQ", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString())));
                    }

                }

            foreach (DataRow item in dtTG_DCHD.Rows)
            {
                if (!string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()))
                {
                    DataRow[] dr = dtTG.Select("MaTo=" + item["MaTo"].ToString());

                    dtTG.Rows[dtTG.Rows.IndexOf(dr[0])]["TongGiaBan"] = long.Parse(dtTG.Rows[dtTG.Rows.IndexOf(dr[0])]["TongGiaBan"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                    dtTG.Rows[dtTG.Rows.IndexOf(dr[0])]["TongGiaBanThu"] = long.Parse(dtTG.Rows[dtTG.Rows.IndexOf(dr[0])]["TongGiaBanThu"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                }
                else
                {
                    DataRow[] dr = dtTG.Select("MaTo=" + item["MaTo"].ToString());

                    dtTG.Rows[dtTG.Rows.IndexOf(dr[0])]["TongGiaBan"] = long.Parse(dtTG.Rows[dtTG.Rows.IndexOf(dr[0])]["TongGiaBan"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                    dtTG.Rows[dtTG.Rows.IndexOf(dr[0])]["TongGiaBanTon"] = long.Parse(dtTG.Rows[dtTG.Rows.IndexOf(dr[0])]["TongGiaBanTon"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                }
            }

            foreach (DataRow item in dtCQ_DCHD.Rows)
            {
                if (!string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()))
                {
                    DataRow[] dr = dtCQ.Select("MaTo=" + item["MaTo"].ToString());

                    dtCQ.Rows[dtCQ.Rows.IndexOf(dr[0])]["TongGiaBan"] = long.Parse(dtCQ.Rows[dtCQ.Rows.IndexOf(dr[0])]["TongGiaBan"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                    dtCQ.Rows[dtCQ.Rows.IndexOf(dr[0])]["TongGiaBanThu"] = long.Parse(dtCQ.Rows[dtCQ.Rows.IndexOf(dr[0])]["TongGiaBanThu"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                }
                else
                {
                    DataRow[] dr = dtCQ.Select("MaTo=" + item["MaTo"].ToString());

                    dtCQ.Rows[dtCQ.Rows.IndexOf(dr[0])]["TongGiaBan"] = long.Parse(dtCQ.Rows[dtCQ.Rows.IndexOf(dr[0])]["TongGiaBan"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                    dtCQ.Rows[dtCQ.Rows.IndexOf(dr[0])]["TongGiaBanTon"] = long.Parse(dtCQ.Rows[dtCQ.Rows.IndexOf(dr[0])]["TongGiaBanTon"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                }
            }
            
            dgvHDTuGia.DataSource = dtTG;
            dgvHDCoQuan.DataSource = dtCQ;
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
    }
}
