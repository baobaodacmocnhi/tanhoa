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
            cmbLoaiXem.SelectedIndex = 0;
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
                    switch (int.Parse(cmbNCC.SelectedValue.ToString()))
                    {
                        case 1:
                            if (_csDHN.updateDS_DHN_HoaSen() == true)
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case 2:
                            if (_csDHN.updateDS_DHN_Rynan() == true)
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        default:
                            break;
                    }
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
                switch (int.Parse(cmbNCC.SelectedValue.ToString()))
                {
                    case 1:
                        switch (cmbLoaiXem.SelectedItem.ToString())
                        {
                            case "Chỉ Số":
                                dgvLichSu.DataSource = _csDHN.get_ChiSoNuoc_HoaSen(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), DateTime.Now);
                                break;
                            case "Chất Lượng Sóng":
                                dgvLichSu.DataSource = _csDHN.get_ChatLuongSong_HoaSen(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), DateTime.Now);
                                break;
                            case "Cảnh Báo":
                                dgvLichSu.DataSource = _csDHN.get_CanhBao_HoaSen(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), DateTime.Now);
                                break;
                            case "% Pin":
                                dgvLichSu.DataSource = _csDHN.get_Pin_HoaSen(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), DateTime.Now);
                                break;
                            case "Tất Cả 1 ngày":
                                dgvLichSu.DataSource = _csDHN.get_All_HoaSen(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), DateTime.Now);
                                break;
                            case "Tất Cả 10 ngày":
                                dgvLichSu.DataSource = _csDHN.get_All_HoaSen(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), DateTime.Now.AddDays(-10), DateTime.Now);
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2:
                        switch (cmbLoaiXem.SelectedItem.ToString())
                        {
                            case "Chỉ Số":
                                dgvLichSu.DataSource = _csDHN.get_ChiSoNuoc_Rynan(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), DateTime.Now);
                                break;
                            case "Chỉ Số giờ":
                                dgvLichSu.DataSource = _csDHN.get_ChiSoNuoc_Rynan(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), DateTime.Now, DateTime.Now.Hour);
                                break;
                            case "Chất Lượng Sóng":
                                dgvLichSu.DataSource = _csDHN.get_ChatLuongSong_Rynan(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), DateTime.Now);
                                break;
                            case "Cảnh Báo":
                                dgvLichSu.DataSource = _csDHN.get_CanhBao_Rynan(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), DateTime.Now);
                                break;
                            case "% Pin":
                                dgvLichSu.DataSource = _csDHN.get_Pin_Rynan(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), DateTime.Now);
                                break;
                            case "Tất Cả 1 ngày":
                                dgvLichSu.DataSource = _csDHN.get_All_Rynan(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), DateTime.Now);
                                break;
                            case "Tất Cả 1 ngày giờ":
                                dgvLichSu.DataSource = _csDHN.get_All_Rynan(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), DateTime.Now, DateTime.Now.Hour);
                                break;
                            case "Tất Cả 10 ngày":
                                dgvLichSu.DataSource = _csDHN.get_All_Rynan(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), DateTime.Now.AddDays(-10), DateTime.Now);
                                break;
                            case "Tất Cả 10 ngày giờ":
                                dgvLichSu.DataSource = _csDHN.get_All_Rynan(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), DateTime.Now.AddDays(-10), DateTime.Now, DateTime.Now.Hour);
                                break;
                            default:
                                break;
                        }
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
