using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.DongNuoc;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;

namespace ThuTien.GUI.Quay
{
    public partial class frmPhiMoNuocQuay : Form
    {
        string _mnu = "mnuPhiMoNuocQuay";
        CDongNuoc _cDongNuoc = new CDongNuoc();
        DateTimePicker cellDateTimePicker;

        public frmPhiMoNuocQuay()
        {
            InitializeComponent();
        }

        private void frmPhiMoNuoc_Load(object sender, EventArgs e)
        {
            dgvKQDongNuoc.AutoGenerateColumns = false;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                if (txtDanhBo.Text.Trim().Replace(" ", "").Length == 11)
                    dgvKQDongNuoc.DataSource = _cDongNuoc.GetDSKQDongNuoc_PhiMoNuoc_All(false, txtDanhBo.Text.Trim().Replace(" ", ""));
                else
                    dgvKQDongNuoc.DataSource = _cDongNuoc.GetDSKQDongNuoc_PhiMoNuoc_All(false, dateTu.Value, dateDen.Value);
            }
            else
            {
                if (txtDanhBo.Text.Trim().Replace(" ", "").Length == 11)
                    dgvKQDongNuoc.DataSource = _cDongNuoc.GetDSKQDongNuoc_PhiMoNuoc(false, txtDanhBo.Text.Trim().Replace(" ", ""));
                else
                    dgvKQDongNuoc.DataSource = _cDongNuoc.GetDSKQDongNuoc_PhiMoNuoc(false, dateTu.Value, dateDen.Value);
            }
        }

        private void dgvKQDongNuoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvKQDongNuoc.Columns[e.ColumnIndex].Name == "MaDN" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (dgvKQDongNuoc.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(7, " ").Insert(4, " ");
            }
        }

        private void dgvKQDongNuoc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvKQDongNuoc.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvKQDongNuoc_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvKQDongNuoc.Columns[e.ColumnIndex].Name == "DongPhi" && bool.Parse(e.FormattedValue.ToString()) != bool.Parse(dgvKQDongNuoc[e.ColumnIndex, e.RowIndex].Value.ToString()))
            {
                //if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                //{
                //    TT_KQDongNuoc kqdongnuoc = _cDongNuoc.GetKQDongNuocByMaKQDN(int.Parse(dgvKQDongNuoc["MaKQDN", e.RowIndex].Value.ToString()));
                //    if (kqdongnuoc.DongPhi == true && kqdongnuoc.ChuyenKhoan == true)
                //    {
                //        MessageBox.Show("Đã có đóng phí Chuyển Khoản", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        return;
                //    }
                //    kqdongnuoc.DongPhi = bool.Parse(e.FormattedValue.ToString());
                //    if (kqdongnuoc.DongPhi)
                //        kqdongnuoc.NgayDongPhi = DateTime.Now;
                //    else
                //        kqdongnuoc.NgayDongPhi = null;
                //    if (_cDongNuoc.SuaKQ(kqdongnuoc))
                //    {
                //        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //}
                //else
                //    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo.Text.Trim().Replace(" ", "").Length == 11)
                btnXem.PerformClick();
        }

        private void dgvKQDongNuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvKQDongNuoc.Columns[e.ColumnIndex].Name == "NgayDongPhi")
            {
                //Initialized a new DateTimePicker Control  
                cellDateTimePicker = new DateTimePicker();

                // Setting the format (i.e. 2014-10-10)  
                cellDateTimePicker.CustomFormat ="dd/MM/yyyy";
                cellDateTimePicker.Format = DateTimePickerFormat.Custom;

                //Adding DateTimePicker control into DataGridView   
                dgvKQDongNuoc.Controls.Add(cellDateTimePicker);

                // It returns the retangular area that represents the Display area for a cell  
                Rectangle oRectangle = dgvKQDongNuoc.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                //Setting area for DateTimePicker Control  
                cellDateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);

                // Setting Location  
                cellDateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y);

                // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
                cellDateTimePicker.CloseUp += new EventHandler(cellDateTimePicker_CloseUp);

                // An event attached to dateTimePicker Control which is fired when any date is selected  
                cellDateTimePicker.TextChanged += new EventHandler(cellDateTimePicker_TextChanged);

                // Now make it visible  
                cellDateTimePicker.Visible = true;
            }
        }

        void cellDateTimePicker_TextChanged(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            dgvKQDongNuoc.CurrentCell.Value = cellDateTimePicker.Value.ToString("dd/MM/yyyy");
        }

        void cellDateTimePicker_CloseUp(object sender, EventArgs e)
        {   // Hiding the control after use   
            cellDateTimePicker.Visible = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {
                try
                {
                    foreach (DataGridViewRow item in dgvKQDongNuoc.Rows)
                    {
                        TT_KQDongNuoc kqdongnuoc = _cDongNuoc.GetKQDongNuocByMaKQDN(int.Parse(item.Cells["MaKQDN"].Value.ToString()));
                        if (kqdongnuoc.DongPhi == true && kqdongnuoc.ChuyenKhoan == true)
                        {
                            MessageBox.Show("Đã có đóng phí Chuyển Khoản: " + item.Cells["DanhBo"].Value.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (bool.Parse(item.Cells["DongPhi"].Value.ToString()) == true)
                        {
                            kqdongnuoc.DongPhi = true;
                            string[] date = item.Cells["NgayDongPhi"].Value.ToString().Split('/');
                            kqdongnuoc.NgayDongPhi = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);
                        }
                        else
                        {
                            kqdongnuoc.DongPhi = false;
                            kqdongnuoc.NgayDongPhi = null;
                        }
                        _cDongNuoc.SuaKQ(kqdongnuoc);
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
