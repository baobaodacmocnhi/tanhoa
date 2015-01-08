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

namespace ThuTien.GUI.Doi
{
    public partial class frmLuuHD : Form
    {
        string _fileName = "";
        string _mnu = "mnuLuuHD";
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CHoaDon _cHoaDon = new CHoaDon();

        public frmLuuHD()
        {
            InitializeComponent();
        }

        private void frmLuuHoaDon_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";
            cmbKy.SelectedItem = DateTime.Now.Month.ToString();
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Files (.dat)|*.dat";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtDuongDan.Text = dialog.FileName;
                _fileName = dialog.SafeFileName;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                if (txtDuongDan.Text.Trim() != "" && _fileName.Length == 12)
                {
                    if (_cHoaDon.Them(txtDuongDan.Text.Trim()))
                    {
                        txtDuongDan.Text = "";
                        _fileName = "";
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (cmbKy.SelectedIndex != -1)
            {
                //var startTime = System.Diagnostics.Stopwatch.StartNew();
                dgvHoaDon.DataSource = _cHoaDon.GetTongByNamKy(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                //startTime.Stop();
                //MessageBox.Show(startTime.ElapsedMilliseconds.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongHD" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongTieuThu" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongGiaBan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongThueGTGT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongPhiBVMT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        
    }
}
