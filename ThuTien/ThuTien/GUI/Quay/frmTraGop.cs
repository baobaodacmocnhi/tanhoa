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
using ThuTien.DAL.Quay;
using ThuTien.DAL.QuanTri;

namespace ThuTien.GUI.Quay
{
    public partial class frmTraGop : Form
    {
        string _mnu = "mnuTraGop";
        CHoaDon _cHoaDon = new CHoaDon();
        CTraGop _cTraGop = new CTraGop();

        public frmTraGop()
        {
            InitializeComponent();
        }

        private void frmTraGop_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
            dgvTraGop.AutoGenerateColumns = false;
        }

        public void LoadDanhSach()
        {
            dgvTraGop.DataSource = _cTraGop.GetDSByMaHD(int.Parse(dgvHoaDon.CurrentRow.Cells["MaHD"].Value.ToString()));
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

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtDanhBo.Text.Trim()))
            {
                dgvHoaDon.DataSource = _cHoaDon.GetDSTonByDanhBo(txtDanhBo.Text.Trim());
            }
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

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadDanhSach();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                TT_TraGop tragop = new TT_TraGop();

                tragop.MaHD = int.Parse(dgvHoaDon.CurrentRow.Cells["MaHD"].Value.ToString());
                tragop.SoHoaDon = dgvHoaDon.CurrentRow.Cells["SoHoaDon"].Value.ToString();
                string[] date = dgvHoaDon.CurrentRow.Cells["NgayTra"].Value.ToString().Split('/');
                tragop.NgayTra = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                tragop.SoTien = int.Parse(dgvHoaDon.CurrentRow.Cells["SoTien"].Value.ToString());

                if (_cTraGop.Them(tragop))
                {
                    LoadDanhSach();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {
                TT_TraGop tragop = _cTraGop.GetByMaTG(int.Parse(dgvTraGop.CurrentRow.Cells["MaTG"].Value.ToString()));

                string[] date = dgvHoaDon.CurrentRow.Cells["NgayTra"].Value.ToString().Split('/');
                tragop.NgayTra = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                tragop.SoTien = int.Parse(dgvHoaDon.CurrentRow.Cells["SoTien"].Value.ToString());

                if (_cTraGop.Sua(tragop))
                {
                    LoadDanhSach();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    TT_TraGop tragop = _cTraGop.GetByMaTG(int.Parse(dgvTraGop.CurrentRow.Cells["MaTG"].Value.ToString()));

                    if (_cTraGop.Xoa(tragop))
                    {
                        LoadDanhSach();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {

        }

        private void dgvTraGop_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            TT_TraGop tragop = _cTraGop.GetByMaTG(int.Parse(dgvTraGop.CurrentRow.Cells["MaTG"].Value.ToString()));

            if (tragop.DaThanhToan != bool.Parse(dgvTraGop.CurrentRow.Cells["DaThanhToan"].Value.ToString()))
            {
                tragop.DaThanhToan = bool.Parse(dgvTraGop.CurrentRow.Cells["DaThanhToan"].Value.ToString());
                if (tragop.SoPhieu == null)
                    tragop.SoPhieu = _cTraGop.GetNextSoPhieu();
                _cTraGop.Sua(tragop);
            }
        }

        
    }
}
