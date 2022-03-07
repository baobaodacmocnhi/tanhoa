using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.sDHN;
using DocSo_PC.DAL.QuanTri;

namespace DocSo_PC.GUI.sDHN
{
    public partial class frmDSsDHN : Form
    {
        string _mnu = "mnuDSsDHN";
        CsDHN _csDHN = new CsDHN();

        public frmDSsDHN()
        {
            InitializeComponent();
        }

        private void frmDSsDHN_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
            cmbNCC.DataSource = _csDHN.getDS_NCC();
            cmbNCC.DisplayMember = "Name";
            cmbNCC.ValueMember = "ID";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = _csDHN.getDS(int.Parse(cmbNCC.SelectedValue.ToString()));
        }

        private void btnCapNhatDS_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    if (int.Parse(cmbNCC.SelectedValue.ToString()) == 1)
                        if (_csDHN.updateDS_DHN() == true)
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDanhSach_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDanhSach.Columns[e.ColumnIndex].Name == "MLT" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(2, " ");
            }
            if (dgvDanhSach.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(7, " ").Insert(4, " ");
            }
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (cmbLoaiXem.SelectedItem.ToString())
                {
                    case "Chỉ Số":
                        dgvLichSu.DataSource = _csDHN.get_ChiSoNuoc(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), DateTime.Now);
                        break;
                    case "Chất Lượng Sóng":
                        dgvLichSu.DataSource = _csDHN.get_ChatLuongSong(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), DateTime.Now);
                        break;
                    case "Cảnh Báo":
                        dgvLichSu.DataSource = _csDHN.get_CanhBao(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), DateTime.Now);
                        break;
                    case "% Pin":
                        dgvLichSu.DataSource = _csDHN.get_Pin(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), DateTime.Now);
                        break;
                    case "Tất Cả 1 ngày":
                        dgvLichSu.DataSource = _csDHN.get_All(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), DateTime.Now);
                        break;
                    case "Tất Cả 10 ngày":

                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
