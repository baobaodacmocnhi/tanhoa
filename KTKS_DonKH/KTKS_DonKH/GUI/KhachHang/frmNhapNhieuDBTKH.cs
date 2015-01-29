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
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.KhachHang
{
    public partial class frmNhapNhieuDBTKH : Form
    {
        CLoaiDon _cLoaiDon = new CLoaiDon();
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();
        CTTKH _cTTKH = new CTTKH();
        CPhuongQuan _cPhuongQuan = new CPhuongQuan();
        CDonTXL _cDonTXL = new CDonTXL();
        CDonKH _cDonKH = new CDonKH();

        private DateTimePicker cellDateTimePicker;

        public frmNhapNhieuDBTKH()
        {
            InitializeComponent();
        }

        private void frmNhapNhieuDBTKH_Load(object sender, EventArgs e)
        {
            this.cellDateTimePicker = new DateTimePicker();
            this.cellDateTimePicker.ValueChanged += new EventHandler(cellDateTimePickerValueChanged);
            this.cellDateTimePicker.Visible = false;
            this.cellDateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.cellDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.dgvDanhBo.Controls.Add(cellDateTimePicker);
            Location = new Point(20, 50);

            dgvDanhBo.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDanhBo.Font, FontStyle.Bold);

            cmbLD.DataSource = _cLoaiDon.LoadDSLoaiDon(true);
            cmbLD.DisplayMember = "TenLD";
            cmbLD.ValueMember = "MaLD";
            cmbLD.SelectedIndex = -1;

            DataGridViewComboBoxColumn cmbColumn = (DataGridViewComboBoxColumn)dgvDanhBo.Columns["NguoiDi"];
            cmbColumn.DataSource = _cTaiKhoan.LoadDSTaiKhoanTKH();
            cmbColumn.DisplayMember = "HoTen";
            cmbColumn.ValueMember = "MaU";
        }

        void cellDateTimePickerValueChanged(object sender, EventArgs e)
        {
            dgvDanhBo.CurrentCell.Value = cellDateTimePicker.Value.ToString("dd/MM/yyyy");
            cellDateTimePicker.Visible = false;
        }

        private void cmbLD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLD.SelectedIndex != -1)
            {
                txtNgayNhan.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        private void dgvDanhBo_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvDanhBo.Columns[e.ColumnIndex].Name == "NgayChuyen")
            {
                //var index = dgvDanhBo.CurrentCell.ColumnIndex;

                Rectangle tempRect = this.dgvDanhBo.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                cellDateTimePicker.Location = tempRect.Location;
                cellDateTimePicker.Width = tempRect.Width;
                try
                {
                    cellDateTimePicker.Value = DateTime.Parse(dgvDanhBo.CurrentCell.Value.ToString());
                }
                catch
                {
                    cellDateTimePicker.Value = DateTime.Now;
                }
                cellDateTimePicker.Visible = true;
            }
        }

        private void dgvDanhBo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDanhBo.Columns[e.ColumnIndex].Name == "DanhBo" && dgvDanhBo["DanhBo", e.RowIndex].Value != null)
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
            {
                dgvDanhBo["NgayChuyen", e.RowIndex].Value = dgvDanhBo["NgayChuyen", e.RowIndex - 1].Value;
                dgvDanhBo["NguoiDi", e.RowIndex].Value = dgvDanhBo["NguoiDi", e.RowIndex - 1].Value;
            }
        }

        private void dgvDanhBo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhBo.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                decimal min = 0, max = 0;
                _cDonKH.beginTransaction();

                foreach (DataGridViewRow item in dgvDanhBo.Rows)
                    if (item.Cells["DanhBo"].Value != null || item.Cells["HoTen"].Value != null || item.Cells["DiaChi"].Value != null)
                    {
                        DonKH donkh = new DonKH();
                        donkh.MaDon = _cDonKH.getMaxNextID();
                        donkh.MaLD = int.Parse(cmbLD.SelectedValue.ToString());
                        donkh.SoCongVan = txtSoCongVan.Text.Trim();
                        donkh.TongSoDanhBo = int.Parse(txtTongSoDanhBo.Text.Trim());
                        donkh.NoiDung = txtNoiDung.Text.Trim();
                        ///
                        if (item.Cells["DanhBo"].Value != null)
                            donkh.DanhBo = item.Cells["DanhBo"].Value.ToString();
                        if (item.Cells["HopDong"].Value != null)
                            donkh.HopDong = item.Cells["HopDong"].Value.ToString();
                        if (item.Cells["HoTen"].Value != null)
                            donkh.HoTen = item.Cells["HoTen"].Value.ToString();
                        if (item.Cells["DiaChi"].Value != null)
                            donkh.DiaChi = item.Cells["DiaChi"].Value.ToString();
                        if (item.Cells["MSThue"].Value != null)
                            donkh.MSThue = item.Cells["MSThue"].Value.ToString();
                        if (item.Cells["GiaBieu"].Value != null)
                            donkh.GiaBieu = item.Cells["GiaBieu"].Value.ToString();
                        if (item.Cells["DinhMuc"].Value != null)
                            donkh.DinhMuc = item.Cells["DinhMuc"].Value.ToString();
                        if (item.Cells["Dot"].Value != null)
                            donkh.Dot = item.Cells["Dot"].Value.ToString();
                        if (item.Cells["Ky"].Value != null)
                            donkh.Ky = item.Cells["Ky"].Value.ToString();
                        if (item.Cells["Nam"].Value != null)
                            donkh.Nam = item.Cells["Nam"].Value.ToString();
                        ///
                        if (item.Cells["NguoiDi"].Value != null)
                        {
                            string[] date = item.Cells["NgayChuyen"].Value.ToString().Split('/');
                            donkh.ChuyenKT = true;
                            donkh.NgayChuyenKT = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                            donkh.NguoiDi = int.Parse(item.Cells["NguoiDi"].Value.ToString());
                            if (item.Cells["GhiChu"].Value != null)
                                donkh.GhiChuChuyenKT = item.Cells["GhiChu"].Value.ToString();
                        }
                        ///
                        if (_cDonKH.ThemDonKH(donkh))
                        {
                            if (min == 0)
                                min = donkh.MaDon;
                            max = donkh.MaDon;
                            if (item.Cells["NguoiDi"].Value != null)
                            {
                                LichSuChuyenKT lichsuchuyenkt = new LichSuChuyenKT();
                                lichsuchuyenkt.NgayChuyenKT = donkh.NgayChuyenKT;
                                lichsuchuyenkt.NguoiDi = donkh.NguoiDi;
                                lichsuchuyenkt.GhiChuChuyenKT = donkh.GhiChuChuyenKT;
                                lichsuchuyenkt.MaDon = donkh.MaDon;
                                _cDonTXL.ThemLichSuChuyenKT(lichsuchuyenkt);
                            }
                        }
                    }

                _cDonKH.commitTransaction();
                MessageBox.Show("Thành công\nSố đơn từ " + min.ToString().Insert(min.ToString().Length - 2, "-") + " đến " + max.ToString().Insert(max.ToString().Length - 2, "-"), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                _cDonKH.rollback();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
