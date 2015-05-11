using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.LinQ;

namespace ThuTien.GUI.Quay
{
    public partial class frmTraGop : Form
    {
        CHoaDon _cHoaDon = new CHoaDon();

        public frmTraGop()
        {
            InitializeComponent();
        }

        private void frmTraGop_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
            dgvTraGop.AutoGenerateColumns = false;
        }

        private void txtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtSoHoaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtSoHoaDon.Text.Trim()))
                if (_cHoaDon.CheckBySoHoaDon(txtSoHoaDon.Text.Trim()))
                {
                    dgvHoaDon.Rows.Clear();
                    HOADON hoadon = _cHoaDon.GetBySoHoaDon(txtSoHoaDon.Text.Trim());
                    dgvHoaDon.Rows.Add(hoadon.ID_HOADON,hoadon.SOHOADON,hoadon.KY+"/"+hoadon.NAM,hoadon.MALOTRINH,hoadon.SOPHATHANH,hoadon.DANHBA,hoadon.TONGCONG);
                    txtSoHoaDon.Text = "";
                }
                else
                    MessageBox.Show("Hóa Đơn sai", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }
    }
}
