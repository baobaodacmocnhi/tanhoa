using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.KhachHang
{
    public partial class frmQLDonKH : Form
    {
        CDonKH _cDonKH = new CDonKH();
        CChuyenDi _cChuyenDi = new CChuyenDi();

        public frmQLDonKH()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void frmQLDonKH_Load(object sender, EventArgs e)
        {
            dgvDSDonKH.AutoGenerateColumns = false;
            //dgvDSDonKH.DataSource = _cDonKH.LoadDSDonKH();
            DataGridViewComboBoxColumn cmbColumn = (DataGridViewComboBoxColumn)dgvDSDonKH.Columns["MaChuyen"];
            //cmbColumn.Items.Add("Kiểm Tra Xác Minh");
            //cmbColumn.Items.Add("Điều Chỉnh Biến Động");
            //cmbColumn.Items.Add("Lục Hồ Sơ Góc");
            //cmbColumn.Items.Add("Thảo Thư Trả Lời");
            //cmbColumn.Items.Add("Cắt Tạm hoặc Cắt Hủy Danh Bộ");
            //cmbColumn.Items.Add("Trình Cấp Trên Xem Xét Giải Quyết");
            cmbColumn.DataSource = _cChuyenDi.LoadDSChuyenDi();
            cmbColumn.DisplayMember = "NoiChuyenDi";
            cmbColumn.ValueMember = "MaChuyen";
            radChuDuyet.Checked = true;
        }
            
        private void dgvDSDonKH_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSDonKH.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void radAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radAll.Checked)
            {
                dgvDSDonKH.DataSource = _cDonKH.LoadDSDonKHAll();
            }
        }

        private void radChuDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radChuDuyet.Checked)
            {
                dgvDSDonKH.DataSource = _cDonKH.LoadDSDonKHChuaDuyet();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DataTable table = (DataTable)dgvDSDonKH.DataSource;
            foreach (DataRow itemRow in table.Rows)
            {
                if (itemRow["MaChuyen"].ToString() != "")
                {
                    DonKH donkh = _cDonKH.getDonKHbyID(int.Parse(itemRow["MaDon"].ToString()));
                    if (!donkh.Nhan)
                    {
                        donkh.Chuyen = true;
                        donkh.MaChuyen = itemRow["MaChuyen"].ToString();
                        donkh.LyDoChuyen = itemRow["LyDoChuyen"].ToString();
                        _cDonKH.SuaDonKH(donkh);
                    }
                    else
                    {
                        MessageBox.Show("Đơn " + donkh.MaDon + " đã được xử lý nên không sửa đổi được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
            }
            if(radAll.Checked)
                dgvDSDonKH.DataSource = _cDonKH.LoadDSDonKHAll();
            if (radChuDuyet.Checked)
                dgvDSDonKH.DataSource = _cDonKH.LoadDSDonKHChuaDuyet();
        }

        private void dgvDSDonKH_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                frmShowDonKH frm = new frmShowDonKH(_cDonKH.getDonKHbyID(int.Parse(dgvDSDonKH["MaDon", e.RowIndex].Value.ToString())));
                frm.ShowDialog();
            }
        }
    }
}
