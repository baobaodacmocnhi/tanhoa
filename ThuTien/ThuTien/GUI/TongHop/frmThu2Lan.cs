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
using ThuTien.LinQ;
using System.Globalization;

namespace ThuTien.GUI.TongHop
{
    public partial class frmThu2Lan : Form
    {
        string _mnu = "mnuThu2Lan";
        CHoaDon _cHoaDon = new CHoaDon();
        //private DateTimePicker cellDateTimePicker;

        public frmThu2Lan()
        {
            InitializeComponent();
        }

        private void frmThu2Lan_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;

            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";

            //this.cellDateTimePicker = new DateTimePicker();
            //this.cellDateTimePicker.ValueChanged += new EventHandler(cellDateTimePickerValueChanged);
            //this.cellDateTimePicker.Visible = false;
            //this.cellDateTimePicker.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            //this.cellDateTimePicker.Format = DateTimePickerFormat.Custom;
            //this.dgvHoaDon.Controls.Add(cellDateTimePicker);
        }

        void cellDateTimePickerValueChanged(object sender, EventArgs e)
        {
            //dgvHoaDon.CurrentCell.Value = cellDateTimePicker.Value.ToString("dd/MM/yyyy HH:mm:ss");
            //cellDateTimePicker.Visible = false;
        }

        private void txtSoHoaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtSoHoaDon.Text.Trim()))
            //    if (!lstHD.Items.Contains(txtSoHoaDon.Text.Trim()))
            //    {
            //        lstHD.Items.Add(txtSoHoaDon.Text.Trim());
            //        txtSoHoaDon.Text = "";
            //    }
            //    else
            //        txtSoHoaDon.Text = "";
            if (e.KeyChar == 13)
                btnXem.PerformClick();
        }

        private void lstHD_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstHD.Items.Count > 0)
                lstHD.Items.RemoveAt(lstHD.SelectedIndex);
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnXem.PerformClick();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                foreach (var item in lstHD.Items)
                {
                    if (!_cHoaDon.CheckBySoHoaDon(item.ToString()))
                    {
                        MessageBox.Show("Hóa Đơn sai: " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lstHD.SelectedItem = item;
                        return;
                    }
                }
                try
                {
                    _cHoaDon.BeginTransaction();
                    foreach (var item in lstHD.Items)
                    {
                        HOADON hoadon = _cHoaDon.GetBySoHoaDon(item.ToString());
                        hoadon.Thu2Lan = true;
                    }
                    _cHoaDon.SubmitChanges();
                    _cHoaDon.CommitTransaction();
                    lstHD.Items.Clear();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    _cHoaDon.Rollback();
                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                try
                {
                    _cHoaDon.BeginTransaction();
                    foreach (DataGridViewRow item in dgvHoaDon.SelectedRows)
                    {
                        HOADON hoadon = _cHoaDon.GetByMaHD(int.Parse(item.Cells["MaHD"].Value.ToString()));
                        hoadon.Thu2Lan = false;
                    }
                    _cHoaDon.SubmitChanges();
                    _cHoaDon.CommitTransaction();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    _cHoaDon.Rollback();
                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvHoaDon.DataSource = _cHoaDon.GetDSThu2Lan(txtSoHoaDon.Text.Trim(),txtDanhBo.Text.Trim().Replace(" ",""));
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TieuThu" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "GiaBan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "ThueGTGT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "PhiBVMT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHoaDon_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHoaDon.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvHoaDon_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //if (dgvHoaDon.Columns[e.ColumnIndex].Name == "NgayTra")
            //{
            //    Rectangle tempRect = this.dgvHoaDon.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
            //    cellDateTimePicker.Location = tempRect.Location;
            //    cellDateTimePicker.Width = tempRect.Width;
            //    try
            //    {
            //        cellDateTimePicker.Value = DateTime.Parse(dgvHoaDon.CurrentCell.Value.ToString());
            //    }
            //    catch
            //    {
            //        cellDateTimePicker.Value = DateTime.Now;
            //    }
            //    cellDateTimePicker.Visible = true;
            //    dgvHoaDon["Tra", e.RowIndex].Value = "True";
            //}
        }

        private void dgvHoaDon_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvHoaDon.Columns[e.ColumnIndex].Name == "NgayTra" && !string.IsNullOrEmpty(dgvHoaDon["NgayTra", e.RowIndex].Value.ToString()))
            //{
            //    HOADON hoadon = _cHoaDon.GetBySoHoaDon(dgvHoaDon["SoHoaDon", e.RowIndex].Value.ToString());
            //    string[] date = dgvHoaDon["NgayTra", e.RowIndex].Value.ToString().Split('/');
            //    string[] name = date[2].Split(' ');
            //    string[] time = name[1].Split(':');
            //    hoadon.Thu2Lan_Tra = true;
            //    hoadon.Thu2Lan_NgayTra = new DateTime(int.Parse(name[0]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
            //    _cHoaDon.Sua(hoadon);
            //    btnXem.PerformClick();
            //}
            
        }

        private void dgvHoaDon_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "Tra")
            {
                if (bool.Parse(dgvHoaDon["Tra", e.RowIndex].Value.ToString()))
                {
                    _cHoaDon.Thu2Lan_Tra(dgvHoaDon["SoHoaDon", e.RowIndex].Value.ToString());
                }
                else
                {
                    _cHoaDon.Thu2Lan_XoaTra(dgvHoaDon["SoHoaDon", e.RowIndex].Value.ToString());
                }
                btnXem.PerformClick();
            }
            
        }

        

       
    }
}
