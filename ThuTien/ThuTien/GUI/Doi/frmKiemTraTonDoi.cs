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
            DataTable dt = new DataTable();
            List<TT_To> lst = _cTo.GetDSHanhThu();

            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                ///chọn tất cả tổ
                if (int.Parse(cmbTo.SelectedValue.ToString()) == 0)
                {
                    ///chọn tất cả các kỳ
                    if (cmbKy.SelectedIndex == 0)
                    {
                        dt = _cHoaDon.GetTongTon_Doi("TG", lst[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()));
                        for (int i = 1; i < lst.Count; i++)
                            dt.Merge(_cHoaDon.GetTongTon_Doi("TG", lst[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString())));
                    }
                    ///chọn 1 kỳ cụ thể
                    else
                        if (cmbKy.SelectedIndex > 0)
                        {
                            dt = _cHoaDon.GetTongTon_Doi("TG", lst[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                            for (int i = 1; i < lst.Count; i++)
                                dt.Merge(_cHoaDon.GetTongTon_Doi("TG", lst[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString())));
                        }
                }
                ///chọn 1 tổ
                else
                {
                    ///chọn tất cả các kỳ
                    if (cmbKy.SelectedIndex == 0)
                        dt = _cHoaDon.GetTongTon_Doi("TG", int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()));
                    ///chọn 1 kỳ cụ thể
                    else
                        if (cmbKy.SelectedIndex > 0)
                            dt = _cHoaDon.GetTongTon_Doi("TG", int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                }
                dgvHDTuGia.DataSource = dt;
                CountdgvHDTuGia();
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    ///chọn tất cả tổ
                    if (int.Parse(cmbTo.SelectedValue.ToString()) == 0)
                    {
                        ///chọn tất cả các kỳ
                        if (cmbKy.SelectedIndex == 0)
                        {
                            dt = _cHoaDon.GetTongTon_Doi("CQ", lst[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()));
                            for (int i = 1; i < lst.Count; i++)
                                dt.Merge(_cHoaDon.GetTongTon_Doi("CQ", lst[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString())));
                        }
                        ///chọn 1 kỳ cụ thể
                        else
                            if (cmbKy.SelectedIndex > 0)
                            {
                                dt = _cHoaDon.GetTongTon_Doi("CQ", lst[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                for (int i = 1; i < lst.Count; i++)
                                    dt.Merge(_cHoaDon.GetTongTon_Doi("CQ", lst[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString())));
                            }
                    }
                    ///chọn 1 tổ
                    else
                    {
                        ///chọn tất cả các kỳ
                        if (cmbKy.SelectedIndex == 0)
                            dt = _cHoaDon.GetTongTon_Doi("CQ", int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()));
                        ///chọn 1 kỳ cụ thể
                        else
                            if (cmbKy.SelectedIndex > 0)
                                dt = _cHoaDon.GetTongTon_Doi("CQ", int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                    }
                    dgvHDCoQuan.DataSource = dt;
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

        private void dgvHDTuGia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cmbKy.SelectedIndex == 0)
            {
                dgvNhanVien.DataSource = _cHoaDon.GetTongTon_To("TG", int.Parse(dgvHDTuGia["MaTo_TG", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()));
            }
            else
                if (cmbKy.SelectedIndex > 0)
                {
                    dgvNhanVien.DataSource = _cHoaDon.GetTongTon_To("TG", int.Parse(dgvHDTuGia["MaTo_TG", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                }
        }

        private void dgvHDCoQuan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cmbKy.SelectedIndex == 0)
            {
                dgvNhanVien.DataSource = _cHoaDon.GetTongTon_To("TG", int.Parse(dgvHDCoQuan["MaTo_CQ", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()));
            }
            else
                if (cmbKy.SelectedIndex > 0)
                {
                    dgvNhanVien.DataSource = _cHoaDon.GetTongTon_To("TG", int.Parse(dgvHDCoQuan["MaTo_CQ", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                }
        }

        private void dgvNhanVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "TongHD_NV" && e.Value != null)
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
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "TongCongThu_NV" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "TongHDTon_NV" && e.Value != null)
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
    }
}
