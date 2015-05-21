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

namespace ThuTien.GUI.Doi
{
    public partial class frmKiemTraTonDoi : Form
    {
        CTo _cTo = new CTo();
        CHoaDon _cHoaDon = new CHoaDon();

        public frmKiemTraTonDoi()
        {
            InitializeComponent();
        }

        private void frmKiemTraTonDoi_Load(object sender, EventArgs e)
        {
            dgvHDTuGia.AutoGenerateColumns = false;
            dgvHDCoQuan.AutoGenerateColumns = false;

            List<TT_To> lst = _cTo.GetDSHanhThu();
            TT_To to = new TT_To();
            to.MaTo = 0;
            to.TenTo = "Tất Cả";
            lst.Insert(0, to);
            cmbTo.DataSource = lst;
            cmbTo.DisplayMember = "TenTo";
            cmbTo.ValueMember = "MaTo";

            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DataTable dtTG = new DataTable();
            DataTable dtCQ = new DataTable();
            List<TT_To> lst = _cTo.GetDSHanhThu();

            ///chọn tất cả tổ
            if (int.Parse(cmbTo.SelectedValue.ToString()) == 0)
            {
                ///chọn tất cả các kỳ
                if (cmbKy.SelectedIndex != -1 && cmbKy.SelectedIndex == 0)
                {
                    dtTG = _cHoaDon.GetTongTonByNam_Doi(lst[0].MaTo, "TG", int.Parse(cmbNam.SelectedValue.ToString()));
                    dtCQ = _cHoaDon.GetTongTonByNam_Doi(lst[0].MaTo, "CQ", int.Parse(cmbNam.SelectedValue.ToString()));
                    for (int i = 1; i < lst.Count; i++)
                    {
                        dtTG.Merge(_cHoaDon.GetTongTonByNam_Doi(lst[i].MaTo, "TG", int.Parse(cmbNam.SelectedValue.ToString())));
                        dtCQ.Merge(_cHoaDon.GetTongTonByNam_Doi(lst[i].MaTo, "CQ", int.Parse(cmbNam.SelectedValue.ToString())));
                    }
                }
                ///chọn 1 kỳ cụ thể
                else
                {
                    dtTG = _cHoaDon.GetTongTonByNamKy_Doi(lst[0].MaTo, "TG", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                    dtCQ = _cHoaDon.GetTongTonByNamKy_Doi(lst[0].MaTo, "CQ", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                    for (int i = 1; i < lst.Count; i++)
                    {
                        dtTG.Merge(_cHoaDon.GetTongTonByNamKy_Doi(lst[i].MaTo, "TG", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString())));
                        dtCQ.Merge(_cHoaDon.GetTongTonByNamKy_Doi(lst[i].MaTo, "CQ", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString())));
                    }
                }
            }
            ///chọn 1 tổ
            else
            {
                ///chọn tất cả các kỳ
                if (cmbKy.SelectedIndex != -1 && cmbKy.SelectedIndex == 0)
                {
                    dtTG = _cHoaDon.GetTongTonByNam_Doi(int.Parse(cmbTo.SelectedValue.ToString()), "TG", int.Parse(cmbNam.SelectedValue.ToString()));
                    dtCQ = _cHoaDon.GetTongTonByNam_Doi(int.Parse(cmbTo.SelectedValue.ToString()), "CQ", int.Parse(cmbNam.SelectedValue.ToString()));
                }
                ///chọn 1 kỳ cụ thể
                else
                {
                    dtTG = _cHoaDon.GetTongTonByNamKy_Doi(int.Parse(cmbTo.SelectedValue.ToString()), "TG", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                    dtCQ = _cHoaDon.GetTongTonByNamKy_Doi(int.Parse(cmbTo.SelectedValue.ToString()), "CQ", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                }
            }
            dgvHDTuGia.DataSource = dtTG;
            dgvHDCoQuan.DataSource = dtCQ;
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
    }
}
