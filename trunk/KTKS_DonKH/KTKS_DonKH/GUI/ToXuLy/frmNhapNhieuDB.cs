using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.DAL.HeThong;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.ToXuLy;

namespace KTKS_DonKH.GUI.ToXuLy
{
    public partial class frmNhapNhieuDB : Form
    {
        CLoaiDonTXL _cLoaiDonTXL = new CLoaiDonTXL();
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();
        CTTKH _cTTKH = new CTTKH();
        CPhuongQuan _cPhuongQuan = new CPhuongQuan();
        CDonTXL _cDonTXL = new CDonTXL();


        public frmNhapNhieuDB()
        {
            InitializeComponent();
        }

        private void frmNhapNhieuDB_Load(object sender, EventArgs e)
        {
            Location = new Point(50, 50);

            dgvDanhBo.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDanhBo.Font, FontStyle.Bold);

            cmbLD.DataSource = _cLoaiDonTXL.LoadDSLoaiDonTXL(true);
            cmbLD.DisplayMember = "TenLD";
            cmbLD.ValueMember = "MaLD";
            cmbLD.SelectedIndex = -1;

            DataGridViewComboBoxColumn cmbColumn = (DataGridViewComboBoxColumn)dgvDanhBo.Columns["NguoiDi"];
            cmbColumn.DataSource = _cTaiKhoan.LoadDSTaiKhoanTXL();
            cmbColumn.DisplayMember = "HoTen";
            cmbColumn.ValueMember = "MaU";
        }

        private void cmbLD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLD.SelectedIndex != -1)
            {
                txtNgayNhan.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        private void dgvDanhBo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDanhBo.Columns[e.ColumnIndex].Name == "DanhBo")
            {
                if (_cTTKH.getTTKHbyID(dgvDanhBo["DanhBo", e.RowIndex].Value.ToString()) != null)
                {
                    TTKhachHang ttkhachhang = _cTTKH.getTTKHbyID(dgvDanhBo["DanhBo", e.RowIndex].Value.ToString());
                    dgvDanhBo["HopDong", e.RowIndex].Value = ttkhachhang.GiaoUoc;
                    dgvDanhBo["HoTen", e.RowIndex].Value = ttkhachhang.HoTen;
                    dgvDanhBo["DiaChi", e.RowIndex].Value = ttkhachhang.DC1 + " " + ttkhachhang.DC2 + _cPhuongQuan.getPhuongQuanByID(ttkhachhang.Quan, ttkhachhang.Phuong);
                    dgvDanhBo["MSThue", e.RowIndex].Value = ttkhachhang.MSThue;
                    dgvDanhBo["GiaBieu", e.RowIndex].Value = ttkhachhang.GB;
                    dgvDanhBo["DinhMuc", e.RowIndex].Value = ttkhachhang.TGDM;
                    dgvDanhBo["Dot", e.RowIndex].Value = ttkhachhang.Dot;
                    dgvDanhBo["Ky", e.RowIndex].Value = ttkhachhang.Ky;
                    dgvDanhBo["Nam", e.RowIndex].Value = ttkhachhang.Nam;
                }
                else
                {
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (e.RowIndex > 0)
                dgvDanhBo["NguoiDi", e.RowIndex].Value = dgvDanhBo["NguoiDi", e.RowIndex - 1].Value;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                _cDonTXL.beginTransaction();

                foreach (DataGridViewRow item in dgvDanhBo.Rows)
                    if (item.Cells["DanhBo"].Value != null || item.Cells["HoTen"].Value != null || item.Cells["DiaChi"].Value != null)
                    {
                        DonTXL dontxl = new DonTXL();
                        dontxl.MaDon = _cDonTXL.getMaxNextID();
                        dontxl.MaLD = int.Parse(cmbLD.SelectedValue.ToString());
                        dontxl.SoCongVan = txtSoCongVan.Text.Trim();
                        dontxl.TongSoDanhBo = int.Parse(txtTongSoDanhBo.Text.Trim());
                        dontxl.NoiDung = txtNoiDung.Text.Trim();
                        ///
                        if (item.Cells["DanhBo"].Value != null)
                            dontxl.DanhBo = item.Cells["DanhBo"].Value.ToString();
                        if (item.Cells["HopDong"].Value != null)
                            dontxl.HopDong = item.Cells["HopDong"].Value.ToString();
                        if (item.Cells["HoTen"].Value != null)
                            dontxl.HoTen = item.Cells["HoTen"].Value.ToString();
                        if (item.Cells["DiaChi"].Value != null)
                            dontxl.DiaChi = item.Cells["DiaChi"].Value.ToString();
                        if (item.Cells["MSThue"].Value != null)
                            dontxl.MSThue = item.Cells["MSThue"].Value.ToString();
                        if (item.Cells["GiaBieu"].Value != null)
                            dontxl.GiaBieu = item.Cells["GiaBieu"].Value.ToString();
                        if (item.Cells["DinhMuc"].Value != null)
                            dontxl.DinhMuc = item.Cells["DinhMuc"].Value.ToString();
                        if (item.Cells["Dot"].Value != null)
                            dontxl.Dot = item.Cells["Dot"].Value.ToString();
                        if (item.Cells["Ky"].Value != null)
                            dontxl.Ky = item.Cells["Ky"].Value.ToString();
                        if (item.Cells["Nam"].Value != null)
                            dontxl.Nam = item.Cells["Nam"].Value.ToString();
                        ///
                        if (item.Cells["NguoiDi"].Value != null)
                        {
                            dontxl.ChuyenKT = true;
                            dontxl.NgayChuyenKT = DateTime.Now;
                            dontxl.NguoiDi = int.Parse(item.Cells["NguoiDi"].Value.ToString());
                            if (item.Cells["GhiChu"].Value != null)
                                dontxl.GhiChuChuyenKT = item.Cells["GhiChu"].Value.ToString();
                        }
                        ///
                        if (_cDonTXL.ThemDonTXL(dontxl))
                        {
                            if (item.Cells["NguoiDi"].Value != null)
                            {
                                LichSuChuyenKT lichsuchuyenkt = new LichSuChuyenKT();
                                lichsuchuyenkt.NgayChuyenKT = dontxl.NgayChuyenKT;
                                lichsuchuyenkt.NguoiDi = dontxl.NguoiDi;
                                lichsuchuyenkt.GhiChuChuyenKT = dontxl.GhiChuChuyenKT;
                                lichsuchuyenkt.MaDonTXL = dontxl.MaDon;
                                _cDonTXL.ThemLichSuChuyenKT(lichsuchuyenkt);
                            }
                        }
                    }

                _cDonTXL.commitTransaction();
                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbLD.SelectedIndex = -1;
                txtMaDon.Text = "";
                txtNgayNhan.Text = "";
                txtNoiDung.Text = "";
                txtSoCongVan.Text = "";
                txtTongSoDanhBo.Text = "1";
                dgvDanhBo.Rows.Clear();
            }
            catch (Exception ex)
            {
                _cDonTXL.rollback();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhBo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhBo.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }


    }
}
