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
        private DateTimePicker cellDateTimePickerVP;
        bool _flag = false;

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
            this.dgvDanhBoChuyenKT.Controls.Add(cellDateTimePicker);
            Location = new Point(20, 50);

            dgvDanhBoChuyenKT.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDanhBoChuyenKT.Font, FontStyle.Bold);

            cmbLD.DataSource = _cLoaiDon.LoadDSLoaiDon(true);
            cmbLD.DisplayMember = "TenLD";
            cmbLD.ValueMember = "MaLD";
            cmbLD.SelectedIndex = -1;

            DataGridViewComboBoxColumn cmbColumn = (DataGridViewComboBoxColumn)dgvDanhBoChuyenKT.Columns["NguoiDi"];
            cmbColumn.DataSource = _cTaiKhoan.LoadDSTaiKhoanTKH();
            cmbColumn.DisplayMember = "HoTen";
            cmbColumn.ValueMember = "MaU";

            dgvDanhBoChuyenVanPhong.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDanhBoChuyenVanPhong.Font, FontStyle.Bold);

            this.cellDateTimePickerVP = new DateTimePicker();
            this.cellDateTimePickerVP.ValueChanged += new EventHandler(cellDateTimePickerVPValueChanged);
            this.cellDateTimePickerVP.Visible = false;
            this.cellDateTimePickerVP.CustomFormat = "dd/MM/yyyy";
            this.cellDateTimePickerVP.Format = DateTimePickerFormat.Custom;
            this.dgvDanhBoChuyenVanPhong.Controls.Add(cellDateTimePickerVP);

            DataGridViewComboBoxColumn cmbColumnVP = (DataGridViewComboBoxColumn)dgvDanhBoChuyenVanPhong.Columns["NguoiDiVP"];
            cmbColumnVP.DataSource = _cTaiKhoan.LoadDSTaiKhoanTVP();
            cmbColumnVP.DisplayMember = "HoTen";
            cmbColumnVP.ValueMember = "MaU";
        }

        void cellDateTimePickerValueChanged(object sender, EventArgs e)
        {
            dgvDanhBoChuyenKT.CurrentCell.Value = cellDateTimePicker.Value.ToString("dd/MM/yyyy");
            cellDateTimePicker.Visible = false;
        }

        void cellDateTimePickerVPValueChanged(object sender, EventArgs e)
        {
            dgvDanhBoChuyenVanPhong.CurrentCell.Value = cellDateTimePickerVP.Value.ToString("dd/MM/yyyy");
            cellDateTimePickerVP.Visible = false;
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
            if (dgvDanhBoChuyenKT.Columns[e.ColumnIndex].Name == "NgayChuyen")
            {
                //var index = dgvDanhBo.CurrentCell.ColumnIndex;

                Rectangle tempRect = this.dgvDanhBoChuyenKT.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                cellDateTimePicker.Location = tempRect.Location;
                cellDateTimePicker.Width = tempRect.Width;
                try
                {
                    cellDateTimePicker.Value = DateTime.Parse(dgvDanhBoChuyenKT.CurrentCell.Value.ToString());
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
            if (dgvDanhBoChuyenKT.Columns[e.ColumnIndex].Name == "DanhBo" && dgvDanhBoChuyenKT["DanhBo", e.RowIndex].Value != null)
            {
                if (_cTTKH.getTTKHbyID(dgvDanhBoChuyenKT["DanhBo", e.RowIndex].Value.ToString()) != null)
                {
                    TTKhachHang ttkhachhang = _cTTKH.getTTKHbyID(dgvDanhBoChuyenKT["DanhBo", e.RowIndex].Value.ToString());
                    dgvDanhBoChuyenKT["HopDong", e.RowIndex].Value = ttkhachhang.GiaoUoc;
                    dgvDanhBoChuyenKT["HoTen", e.RowIndex].Value = ttkhachhang.HoTen;
                    dgvDanhBoChuyenKT["DiaChi", e.RowIndex].Value = ttkhachhang.DC1 + " " + ttkhachhang.DC2 + _cPhuongQuan.getPhuongQuanByID(ttkhachhang.Quan, ttkhachhang.Phuong);
                    dgvDanhBoChuyenKT["MSThue", e.RowIndex].Value = ttkhachhang.MSThue;
                    dgvDanhBoChuyenKT["GiaBieu", e.RowIndex].Value = ttkhachhang.GB;
                    dgvDanhBoChuyenKT["DinhMuc", e.RowIndex].Value = ttkhachhang.TGDM;
                    dgvDanhBoChuyenKT["Dot", e.RowIndex].Value = ttkhachhang.Dot;
                    dgvDanhBoChuyenKT["Ky", e.RowIndex].Value = ttkhachhang.Ky;
                    dgvDanhBoChuyenKT["Nam", e.RowIndex].Value = ttkhachhang.Nam;
                }
                else
                {
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (e.RowIndex > 0 && dgvDanhBoChuyenKT.Columns[e.ColumnIndex].Name == "NguoiDi")
            {
                _flag = true;
                //dgvDanhBo["NgayChuyen", e.RowIndex].Value = dgvDanhBo["NgayChuyen", e.RowIndex - 1].Value;
                //dgvDanhBo["NguoiDi", e.RowIndex].Value = dgvDanhBo["NguoiDi", e.RowIndex - 1].Value;
            }
        }

        private void dgvDanhBo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhBoChuyenKT.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl.SelectedTab.Name == "tabKiemTra")
                {
                    decimal min = 0, max = 0;
                    _cDonKH.beginTransaction();

                    foreach (DataGridViewRow item in dgvDanhBoChuyenKT.Rows)
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
                                    lichsuchuyenkt.NgayChuyen = donkh.NgayChuyenKT;
                                    lichsuchuyenkt.NguoiDi = donkh.NguoiDi;
                                    lichsuchuyenkt.GhiChuChuyen = donkh.GhiChuChuyenKT;
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
                    //dgvDanhBoChuyenKT.Rows.Clear();
                    //dgvDanhBoChuyenVanPhong.Rows.Clear();
                    this.Close();
                }
                else
                    if (tabControl.SelectedTab.Name == "tabVanPhong")
                    {
                        decimal min = 0, max = 0;
                        _cDonKH.beginTransaction();

                        foreach (DataGridViewRow item in dgvDanhBoChuyenVanPhong.Rows)
                            if (item.Cells["DanhBoVP"].Value != null || item.Cells["HoTenVP"].Value != null || item.Cells["DiaChiVP"].Value != null)
                            {
                                DonKH donkh = new DonKH();
                                donkh.MaDon = _cDonKH.getMaxNextID();
                                donkh.MaLD = int.Parse(cmbLD.SelectedValue.ToString());
                                donkh.SoCongVan = txtSoCongVan.Text.Trim();
                                donkh.TongSoDanhBo = int.Parse(txtTongSoDanhBo.Text.Trim());
                                donkh.NoiDung = txtNoiDung.Text.Trim();
                                ///
                                if (item.Cells["DanhBoVP"].Value != null)
                                    donkh.DanhBo = item.Cells["DanhBoVP"].Value.ToString();
                                if (item.Cells["HopDongVP"].Value != null)
                                    donkh.HopDong = item.Cells["HopDongVP"].Value.ToString();
                                if (item.Cells["HoTenVP"].Value != null)
                                    donkh.HoTen = item.Cells["HoTenVP"].Value.ToString();
                                if (item.Cells["DiaChiVP"].Value != null)
                                    donkh.DiaChi = item.Cells["DiaChiVP"].Value.ToString();
                                if (item.Cells["MSThueVP"].Value != null)
                                    donkh.MSThue = item.Cells["MSThueVP"].Value.ToString();
                                if (item.Cells["GiaBieuVP"].Value != null)
                                    donkh.GiaBieu = item.Cells["GiaBieuVP"].Value.ToString();
                                if (item.Cells["DinhMucVP"].Value != null)
                                    donkh.DinhMuc = item.Cells["DinhMucVP"].Value.ToString();
                                if (item.Cells["DotVP"].Value != null)
                                    donkh.Dot = item.Cells["DotVP"].Value.ToString();
                                if (item.Cells["KyVP"].Value != null)
                                    donkh.Ky = item.Cells["KyVP"].Value.ToString();
                                if (item.Cells["NamVP"].Value != null)
                                    donkh.Nam = item.Cells["NamVP"].Value.ToString();
                                ///
                                if (item.Cells["NguoiDiVP"].Value != null)
                                {
                                    string[] date = item.Cells["NgayChuyenVP"].Value.ToString().Split('/');
                                    donkh.ChuyenKT = true;
                                    donkh.NgayChuyenKT = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                                    donkh.NguoiDi = int.Parse(item.Cells["NguoiDiVP"].Value.ToString());
                                    if (item.Cells["GhiChuVP"].Value != null)
                                        donkh.GhiChuChuyenKT = item.Cells["GhiChuVP"].Value.ToString();
                                }
                                ///
                                if (_cDonKH.ThemDonKH(donkh))
                                {
                                    if (min == 0)
                                        min = donkh.MaDon;
                                    max = donkh.MaDon;
                                    if (item.Cells["NguoiDiVP"].Value != null)
                                    {
                                        LichSuChuyenVanPhong lichsuchuyenvanphong = new LichSuChuyenVanPhong();
                                        lichsuchuyenvanphong.NgayChuyen = donkh.NgayChuyenVanPhong;
                                        lichsuchuyenvanphong.NguoiDi = donkh.NguoiVanPhong;
                                        lichsuchuyenvanphong.GhiChuChuyen = donkh.GhiChuChuyenVanPhong;
                                        lichsuchuyenvanphong.MaDon = donkh.MaDon;
                                        _cDonKH.ThemLichSuChuyenVanPhong(lichsuchuyenvanphong);
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
                        //dgvDanhBoChuyenKT.Rows.Clear();
                        //dgvDanhBoChuyenVanPhong.Rows.Clear();
                        this.Close();
                    }
            }
            catch (Exception ex)
            {
                _cDonKH.rollback();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhBoChuyenVanPhong_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvDanhBoChuyenVanPhong.Columns[e.ColumnIndex].Name == "NgayChuyenVP")
            {
                //var index = dgvDanhBo.CurrentCell.ColumnIndex;

                Rectangle tempRect = this.dgvDanhBoChuyenVanPhong.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                cellDateTimePickerVP.Location = tempRect.Location;
                cellDateTimePickerVP.Width = tempRect.Width;
                try
                {
                    cellDateTimePickerVP.Value = DateTime.Parse(dgvDanhBoChuyenVanPhong.CurrentCell.Value.ToString());
                }
                catch
                {
                    cellDateTimePickerVP.Value = DateTime.Now;
                }
                cellDateTimePickerVP.Visible = true;
            }
        }

        private void dgvDanhBoChuyenVanPhong_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDanhBoChuyenVanPhong.Columns[e.ColumnIndex].Name == "DanhBoVP" && dgvDanhBoChuyenVanPhong["DanhBoVP", e.RowIndex].Value != null)
            {
                if (_cTTKH.getTTKHbyID(dgvDanhBoChuyenVanPhong["DanhBoVP", e.RowIndex].Value.ToString()) != null)
                {
                    TTKhachHang ttkhachhang = _cTTKH.getTTKHbyID(dgvDanhBoChuyenVanPhong["DanhBoVP", e.RowIndex].Value.ToString());
                    dgvDanhBoChuyenVanPhong["HopDongVP", e.RowIndex].Value = ttkhachhang.GiaoUoc;
                    dgvDanhBoChuyenVanPhong["HoTenVP", e.RowIndex].Value = ttkhachhang.HoTen;
                    dgvDanhBoChuyenVanPhong["DiaChiVP", e.RowIndex].Value = ttkhachhang.DC1 + " " + ttkhachhang.DC2 + _cPhuongQuan.getPhuongQuanByID(ttkhachhang.Quan, ttkhachhang.Phuong);
                    dgvDanhBoChuyenVanPhong["MSThueVP", e.RowIndex].Value = ttkhachhang.MSThue;
                    dgvDanhBoChuyenVanPhong["GiaBieuVP", e.RowIndex].Value = ttkhachhang.GB;
                    dgvDanhBoChuyenVanPhong["DinhMucVP", e.RowIndex].Value = ttkhachhang.TGDM;
                    dgvDanhBoChuyenVanPhong["DotVP", e.RowIndex].Value = ttkhachhang.Dot;
                    dgvDanhBoChuyenVanPhong["KyVP", e.RowIndex].Value = ttkhachhang.Ky;
                    dgvDanhBoChuyenVanPhong["NamVP", e.RowIndex].Value = ttkhachhang.Nam;
                }
                else
                {
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (e.RowIndex > 0 && dgvDanhBoChuyenKT.Columns[e.ColumnIndex].Name == "NguoiDiVP")
            {
                _flag = true;
                //dgvDanhBo["NgayChuyen", e.RowIndex].Value = dgvDanhBo["NgayChuyen", e.RowIndex - 1].Value;
                //dgvDanhBo["NguoiDi", e.RowIndex].Value = dgvDanhBo["NguoiDi", e.RowIndex - 1].Value;
            }
        }

        private void dgvDanhBoChuyenVanPhong_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhBoChuyenVanPhong.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDanhBoChuyenKT_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
                if (!_flag)
                {
                    dgvDanhBoChuyenKT["NgayChuyen", e.RowIndex].Value = dgvDanhBoChuyenKT["NgayChuyen", e.RowIndex - 1].Value;
                    dgvDanhBoChuyenKT["NguoiDi", e.RowIndex].Value = dgvDanhBoChuyenKT["NguoiDi", e.RowIndex - 1].Value;
                }
                else
                    _flag = false;
        }

        private void dgvDanhBoChuyenVanPhong_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
                if (!_flag)
                {
                    dgvDanhBoChuyenVanPhong["NgayChuyenVP", e.RowIndex].Value = dgvDanhBoChuyenVanPhong["NgayChuyenVP", e.RowIndex - 1].Value;
                    dgvDanhBoChuyenVanPhong["NguoiDiVP", e.RowIndex].Value = dgvDanhBoChuyenVanPhong["NguoiDiVP", e.RowIndex - 1].Value;
                }
                else
                    _flag = false;
        }
    }
}
