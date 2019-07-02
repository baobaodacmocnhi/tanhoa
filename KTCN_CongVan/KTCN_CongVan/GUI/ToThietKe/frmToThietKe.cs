using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTCN_CongVan.DAL;

namespace KTCN_CongVan.GUI.ToThietKe
{
    public partial class frmToThietKe : Form
    {
        //string _mnu = "mnuTimKiemTTK";
        CToThietKe _cTTK = new CToThietKe();

        public frmToThietKe()
        {
            InitializeComponent();
        }

        private void frmToThietKe_Load(object sender, EventArgs e)
        {

        }
        private void btnXem_TTK_Click(object sender, EventArgs e)
        {
            try
            {
                string LoaiHoSo = "";
                switch (cmbLoaiHoSo_TTK.SelectedIndex)
                {
                    case 0:
                        LoaiHoSo = "";
                        break;
                    case 1:
                        LoaiHoSo = "GanMoi";
                        break;
                    case 2:
                        LoaiHoSo = "CatHuy";
                        break;
                    case 3:
                        LoaiHoSo = "DichVu";
                        break;
                    default:
                        break;
                }
                if (radNgayLap.Checked == true)
                    dgvDotThiCong.DataSource = _cTTK.getDSDotThiCong_NgayLap(LoaiHoSo, dateTu.Value, dateDen.Value);
                else
                    if (radNgayChuyen.Checked == true)
                        dgvDotThiCong.DataSource = _cTTK.getDSDotThiCong_NgayChuyen(LoaiHoSo, dateTu.Value, dateDen.Value);
                    else
                        if (radTon.Checked == true)
                            dgvDotThiCong.DataSource = _cTTK.getDSDotThiCong_Ton(LoaiHoSo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_TTK_Click(object sender, EventArgs e)
        {
            try
            {
                dgvDotThiCong.DataSource = _cTTK.getDSDotThiCong(txtMaDot_TTK.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDotThiCong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvDSHoSo.DataSource = _cTTK.getDSHoSo(dgvDotThiCong.CurrentRow.Cells["MaDot"].Value.ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void dgvDotThiCong_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDotThiCong.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDotThiCong_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (dgvDotThiCong.Rows[e.RowIndex].Cells["HoanCong_DTC"].Value != null && bool.Parse(dgvDotThiCong.Rows[e.RowIndex].Cells["HoanCong_DTC"].Value.ToString()) == false)
                if (dgvDotThiCong.Rows[e.RowIndex].Cells["NgayGiaoSDV_DTC"].Value != null && dgvDotThiCong.Rows[e.RowIndex].Cells["NgayGiaoSDV_DTC"].Value.ToString() != "")
                    if (dgvDotThiCong.Rows[e.RowIndex].Cells["MaLoai"].Value.ToString() == "GM" || dgvDotThiCong.Rows[e.RowIndex].Cells["MaLoai"].Value.ToString() == "HD")
                    {
                        if (_cTTK.GetToDate(DateTime.Parse(dgvDotThiCong.Rows[e.RowIndex].Cells["NgayGiaoSDV_DTC"].Value.ToString()), 5).Date <= DateTime.Now.Date)
                            dgvDotThiCong.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                    }
                    else
                        if (_cTTK.GetToDate(DateTime.Parse(dgvDotThiCong.Rows[e.RowIndex].Cells["NgayGiaoSDV_DTC"].Value.ToString()), 2).Date <= DateTime.Now.Date)
                            dgvDotThiCong.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
        }

        private void dgvDSHoSo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSHoSo.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSHoSo_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (dgvDSHoSo.Rows[e.RowIndex].Cells["NgayHoanCong"].Value.ToString() == "")
                if (dgvDSHoSo.Rows[e.RowIndex].Cells["MaLoaiHoSo"].Value.ToString() == "GM" || dgvDSHoSo.Rows[e.RowIndex].Cells["MaLoaiHoSo"].Value.ToString() == "HD")
                {
                    if (dgvDSHoSo.Rows[e.RowIndex].Cells["HoSoCha"].Value.ToString() == "" && (dgvDSHoSo.Rows[e.RowIndex].Cells["NgayGiaoSDV"].Value.ToString() == "" || (_cTTK.GetToDate(DateTime.Parse(dgvDSHoSo.Rows[e.RowIndex].Cells["NgayGiaoSDV"].Value.ToString()), 5).Date <= DateTime.Now.Date && dgvDSHoSo.Rows[e.RowIndex].Cells["NgayLapBG"].Value.ToString() == "" && dgvDSHoSo.Rows[e.RowIndex].Cells["NgayTraHS"].Value.ToString() == "")))
                        dgvDSHoSo.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                }
                else
                    if (dgvDSHoSo.Rows[e.RowIndex].Cells["HoSoCha"].Value.ToString() == "" && (dgvDSHoSo.Rows[e.RowIndex].Cells["NgayGiaoSDV"].Value.ToString() == "" || (_cTTK.GetToDate(DateTime.Parse(dgvDSHoSo.Rows[e.RowIndex].Cells["NgayGiaoSDV"].Value.ToString()), 2).Date <= DateTime.Now.Date && dgvDSHoSo.Rows[e.RowIndex].Cells["NgayLapBG"].Value.ToString() == "" && dgvDSHoSo.Rows[e.RowIndex].Cells["NgayTraHS"].Value.ToString() == "")))
                        dgvDSHoSo.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
        }

        private void txtMaDot_TTK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnTimKiem_TTK.PerformClick();
        }
    }
}
