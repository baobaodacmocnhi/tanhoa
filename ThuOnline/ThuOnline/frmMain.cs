using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ThuOnline
{
    public partial class frmMain : Form
    {
        BindingSource DSThuOnline_BS = new BindingSource();
        DB_HOADON_TADataContext db = new DB_HOADON_TADataContext();


        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Location = new Point(20, 20);
            cmbKey.SelectedIndex = 0;
            groupBox_ThoiGian.Location = groupBox_NoiDung.Location;

            dgvDSThuOnline.AutoGenerateColumns = false;
            dgvDSThuOnline.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSThuOnline.Font, FontStyle.Bold);

            DSThuOnline_BS.DataSource = LoadDSThuOnline();
            dgvDSThuOnline.DataSource = DSThuOnline_BS;
        }

        /// <summary>
        /// Lấy Danh Sách Thu Online
        /// </summary>
        /// <returns></returns>
        public DataTable LoadDSThuOnline()
        {
            try
            {
                var query = from itemThuOnline in db.ThuOnlines
                            select new
                            {
                                itemThuOnline.ID,
                                DanhBo = itemThuOnline.Dbo,
                                HoTen = itemThuOnline.KHang,
                                DiaChi = itemThuOnline.Dchi1 + " " + itemThuOnline.DChi2,
                                Dot = itemThuOnline.Dot,
                                Ky = itemThuOnline.KyHD,
                                Nam = itemThuOnline.NamHD,
                                TongTien = itemThuOnline.GiaBan + itemThuOnline.TGTGT + itemThuOnline.PBVMT,
                                SoHoaDon = itemThuOnline.ID_HD,
                                NgayThanhToan = itemThuOnline.Giothanhtoan
                            };
                return CLinQToDataTable.LINQToDataTable(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void cmbKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbKey.SelectedItem.ToString())
            {
                case "Số Hóa Đơn":
                    groupBox_NoiDung.Visible = true;
                    groupBox_ThoiGian.Visible = false;
                    break;
                case "Ngày":
                    groupBox_NoiDung.Visible = false;
                    groupBox_ThoiGian.Visible = true;
                    label3.Visible = false;
                    dateDenNgay.Visible = false;
                    break;
                case "Tháng":
                    groupBox_NoiDung.Visible = false;
                    groupBox_ThoiGian.Visible = true;
                    label3.Visible = false;
                    dateDenNgay.Visible = false;
                    break;
                case "Khoảng Thời Gian":
                    groupBox_NoiDung.Visible = false;
                    groupBox_ThoiGian.Visible = true;
                    label3.Visible = true;
                    dateDenNgay.Visible = true;
                    break;
                default:
                    groupBox_NoiDung.Visible = false;
                    groupBox_ThoiGian.Visible = false;
                    label3.Visible = false;
                    dateDenNgay.Visible = false;
                    DSThuOnline_BS.RemoveFilter();
                    break;
            }
        }

        private void dgvDSThuOnline_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSThuOnline.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSThuOnline_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSThuOnline.Columns[e.ColumnIndex].Name == "TongTien" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##} đ", e.Value);
            }
        }

        private void txtNoiDung_TextChanged(object sender, EventArgs e)
        {
            string expression = "";
            if (txtNoiDung.Text.Trim() != "")
                expression = String.Format("SoHoaDon = {0}", txtNoiDung.Text.Trim());
            DSThuOnline_BS.Filter = expression;
        }

        private void dateTuNgay_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string expression = "";
                if (cmbKey.SelectedItem.ToString() == "Ngày")
                    expression = String.Format("NgayThanhToan > #{0:yyyy-MM-dd} 00:00:00# and NgayThanhToan < #{0:yyyy-MM-dd} 23:59:59#", dateTuNgay.Value);
                if (cmbKey.SelectedItem.ToString() == "Tháng")
                {
                    DateTime date1 = new DateTime(dateTuNgay.Value.Year, dateTuNgay.Value.Month, 1);
                    
                    DateTime date2 = new DateTime(dateTuNgay.Value.Year, dateTuNgay.Value.Month, 1);
                    expression = String.Format("NgayThanhToan > #{0:yyyy-MM-dd} 00:00:00# and NgayThanhToan < #{1:yyyy-MM-dd} 23:59:59#", dateTuNgay.Value, dateTuNgay.Value);
                }
                DSThuOnline_BS.Filter = expression;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void dateDenNgay_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
