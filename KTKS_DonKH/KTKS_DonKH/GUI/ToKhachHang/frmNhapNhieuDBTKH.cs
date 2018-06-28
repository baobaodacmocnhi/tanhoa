using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.ToKhachHang;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.DonTu;

namespace KTKS_DonKH.GUI.ToKhachHang
{
    public partial class frmNhapNhieuDBTKH : Form
    {
        CLoaiDon _cLoaiDon = new CLoaiDon();
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();
        CThuTien _cThuTien = new CThuTien();
        CDocSo _cDocSo = new CDocSo();
        CDonTu _cDonTu = new CDonTu();
        CDonKH _cDonKH = new CDonKH();
        CLichSuDonTu _cLichSuDonTu = new CLichSuDonTu();

        LinQ.DonTu _dontu = null;

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

            cmbLD.DataSource = _cLoaiDon.LoadDSLoaiDon();
            cmbLD.DisplayMember = "TenLD";
            cmbLD.ValueMember = "MaLD";
            cmbLD.SelectedIndex = -1;

            DataGridViewComboBoxColumn cmbColumn = (DataGridViewComboBoxColumn)dgvDanhBoChuyenKT.Columns["NguoiDi"];
            cmbColumn.DataSource = _cTaiKhoan.GetDS_KTXM("TKH");
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
            cmbColumnVP.DataSource = _cTaiKhoan.GetDS_ThuKy("TVP");
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
                for (int i = 0; i < dgvDanhBoChuyenKT.Rows.Count-2; i++)
                    if (i != e.RowIndex && dgvDanhBoChuyenKT["DanhBo", i].Value != null && dgvDanhBoChuyenKT["DanhBo", i].Value.ToString() != "" && dgvDanhBoChuyenKT["DanhBo", i].Value.ToString() == dgvDanhBoChuyenKT["DanhBo", e.RowIndex].Value.ToString())
                    {
                        MessageBox.Show("Danh Bộ đã nhập rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                if (_cThuTien.GetMoiNhat(dgvDanhBoChuyenKT["DanhBo", e.RowIndex].Value.ToString()) != null)
                {
                    HOADON hoadon = _cThuTien.GetMoiNhat(dgvDanhBoChuyenKT["DanhBo", e.RowIndex].Value.ToString());
                    dgvDanhBoChuyenKT["HopDong", e.RowIndex].Value = hoadon.HOPDONG;
                    dgvDanhBoChuyenKT["HoTen", e.RowIndex].Value = hoadon.TENKH;
                    dgvDanhBoChuyenKT["DiaChi", e.RowIndex].Value = hoadon.SO + " " + hoadon.DUONG + _cDocSo.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
                    dgvDanhBoChuyenKT["GiaBieu", e.RowIndex].Value = hoadon.GB;
                    dgvDanhBoChuyenKT["DinhMuc", e.RowIndex].Value = hoadon.DM;
                    dgvDanhBoChuyenKT["Dot", e.RowIndex].Value = hoadon.DOT;
                    dgvDanhBoChuyenKT["Ky", e.RowIndex].Value = hoadon.KY;
                    dgvDanhBoChuyenKT["Nam", e.RowIndex].Value = hoadon.NAM;
                    dgvDanhBoChuyenKT["MLT", e.RowIndex].Value = hoadon.MALOTRINH;
                    dgvDanhBoChuyenKT["Quan", e.RowIndex].Value = hoadon.Quan;
                    dgvDanhBoChuyenKT["Phuong", e.RowIndex].Value = hoadon.Phuong;
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
                    foreach (DataGridViewRow item in dgvDanhBoChuyenKT.Rows)
                        if (item.Cells["DanhBo"].Value != null || item.Cells["HoTen"].Value != null || item.Cells["DiaChi"].Value != null)
                        {
                            if (item.Cells["DanhBo"].Value != null)
                                if (_cDonKH.CheckExist(item.Cells["DanhBo"].Value.ToString(), DateTime.Now) == true)
                                {
                                    if (MessageBox.Show("Danh Bộ " + item.Cells["DanhBo"].Value.ToString() + "đã nhận đơn trong ngày hôm nay rồi\nBạn vẫn muốn tiếp tục???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                        return;
                                }
                        }

                    decimal min = 0, max = 0;
                    _cDonKH.beginTransaction();
                    foreach (DataGridViewRow item in dgvDanhBoChuyenKT.Rows)
                        if (item.Cells["DanhBo"].Value != null || item.Cells["HoTen"].Value != null || item.Cells["DiaChi"].Value != null)
                        {
                            //if (item.Cells["DanhBo"].Value != null)
                            //    if (_cDonKH.CheckExist(item.Cells["DanhBo"].Value.ToString(), DateTime.Now) == true)
                            //    {
                            //        MessageBox.Show("Danh Bộ này đã nhận đơn trong ngày hôm nay rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //        return;
                            //    }

                            DonKH donkh = new DonKH();

                            if (_dontu != null)
                            {
                                donkh.MaDonCha = _dontu.MaDon;
                            }

                            donkh.MaLD = int.Parse(cmbLD.SelectedValue.ToString());
                            donkh.SoCongVan = txtSoCongVan.Text.Trim();
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
                            if (item.Cells["MLT"].Value != null)
                                donkh.MLT = item.Cells["MLT"].Value.ToString();
                            if (item.Cells["Quan"].Value != null)
                                donkh.Quan = item.Cells["Quan"].Value.ToString();
                            if (item.Cells["Phuong"].Value != null)
                                donkh.Phuong = item.Cells["Phuong"].Value.ToString();
                            ///
                            if (item.Cells["NguoiDi"].Value != null)
                            {
                                string[] date = item.Cells["NgayChuyen"].Value.ToString().Split('/');
                                donkh.Chuyen_KTXM = true;
                                donkh.NgayChuyen_KTXM = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                                donkh.NguoiDi_KTXM = int.Parse(item.Cells["NguoiDi"].Value.ToString());
                                if (item.Cells["GhiChu"].Value != null)
                                    donkh.GhiChuChuyen_KTXM = item.Cells["GhiChu"].Value.ToString();
                            }
                            ///
                            if (_cDonKH.Them(donkh))
                            {
                                if (min == 0)
                                    min = donkh.MaDon;
                                max = donkh.MaDon;
                                if (item.Cells["NguoiDi"].Value != null)
                                {
                                    string[] date = item.Cells["NgayChuyen"].Value.ToString().Split('/');
                                    //LichSuChuyenKTXM lichsuchuyenkt = new LichSuChuyenKTXM();
                                    //lichsuchuyenkt.NgayChuyen = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                                    //lichsuchuyenkt.NguoiDi = int.Parse(item.Cells["NguoiDi"].Value.ToString());
                                    //if (item.Cells["GhiChu"].Value != null)
                                    //lichsuchuyenkt.GhiChuChuyen = item.Cells["GhiChu"].Value.ToString();
                                    //lichsuchuyenkt.MaDon = donkh.MaDon;
                                    //_cLichSuDonTu.Them(lichsuchuyenkt);

                                    LichSuDonTu entity = new LichSuDonTu();
                                    entity.NgayChuyen = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                                    entity.ID_NoiChuyen = 1;
                                    entity.NoiChuyen = "Kiểm Tra Xác Minh";
                                    entity.ID_NoiNhan = int.Parse(item.Cells["NguoiDi"].Value.ToString());
                                    entity.NoiNhan = _cTaiKhoan.GetHoTen(int.Parse(item.Cells["NguoiDi"].Value.ToString()));
                                    if (item.Cells["GhiChu"].Value != null)
                                    entity.GhiChu = item.Cells["GhiChu"].Value.ToString();
                                    entity.MaDon = donkh.MaDon;
                                    _cLichSuDonTu.Them(entity);
                                }
                            }
                        }

                    _cDonKH.commitTransaction();
                    MessageBox.Show("Thành công\nSố đơn từ " + min.ToString().Insert(min.ToString().Length - 2, "-") + " đến " + max.ToString().Insert(max.ToString().Length - 2, "-"), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbLD.SelectedIndex = -1;
                    txtNoiDung.Text = "";
                    txtSoCongVan.Text = "";
                    //dgvDanhBoChuyenKT.Rows.Clear();
                    //dgvDanhBoChuyenVanPhong.Rows.Clear();
                    this.Close();
                }
                else
                    if (tabControl.SelectedTab.Name == "tabVanPhong")
                    {
                        foreach (DataGridViewRow item in dgvDanhBoChuyenVanPhong.Rows)
                            if (item.Cells["DanhBoVP"].Value != null || item.Cells["HoTenVP"].Value != null || item.Cells["DiaChiVP"].Value != null)
                            {
                                if (item.Cells["DanhBoVP"].Value != null)
                                    if (_cDonKH.CheckExist(item.Cells["DanhBoVP"].Value.ToString(), DateTime.Now) == true)
                                    {
                                        if (MessageBox.Show("Danh Bộ " + item.Cells["DanhBoVP"].Value.ToString() + "đã nhận đơn trong ngày hôm nay rồi\nBạn vẫn muốn tiếp tục???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                            return;
                                    }
                            }

                        decimal min = 0, max = 0;
                        _cDonKH.beginTransaction();
                        foreach (DataGridViewRow item in dgvDanhBoChuyenVanPhong.Rows)
                            if (item.Cells["DanhBoVP"].Value != null || item.Cells["HoTenVP"].Value != null || item.Cells["DiaChiVP"].Value != null)
                            {
                                //if (item.Cells["DanhBoVP"].Value != null)
                                //    if (_cDonKH.CheckExist(item.Cells["DanhBoVP"].Value.ToString(), DateTime.Now) == true)
                                //    {
                                //        MessageBox.Show("Danh Bộ này đã nhận đơn trong ngày hôm nay rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //        return;
                                //    }

                                DonKH donkh = new DonKH();

                                if (_dontu != null)
                                {
                                    donkh.MaDonCha = _dontu.MaDon;
                                }

                                donkh.MaLD = int.Parse(cmbLD.SelectedValue.ToString());
                                donkh.SoCongVan = txtSoCongVan.Text.Trim();
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
                                if (item.Cells["MLTVP"].Value != null)
                                    donkh.MLT = item.Cells["MLTVP"].Value.ToString();
                                if (item.Cells["QuanVP"].Value != null)
                                    donkh.Quan = item.Cells["QuanVP"].Value.ToString();
                                if (item.Cells["PhuongVP"].Value != null)
                                    donkh.Phuong = item.Cells["PhuongVP"].Value.ToString();
                                ///
                                if (item.Cells["NguoiDiVP"].Value != null)
                                {
                                    //string[] date = item.Cells["NgayChuyenVP"].Value.ToString().Split('/');
                                    //donkh.ChuyenVanPhong = true;
                                    //donkh.NgayChuyenVanPhong = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                                    //donkh.NguoiVanPhong = int.Parse(item.Cells["NguoiDiVP"].Value.ToString());
                                    //if (item.Cells["GhiChuVP"].Value != null)
                                    //    donkh.GhiChuChuyenVanPhong = item.Cells["GhiChuVP"].Value.ToString();
                                }
                                ///
                                if (_cDonKH.Them(donkh))
                                {
                                    if (min == 0)
                                        min = donkh.MaDon;
                                    max = donkh.MaDon;
                                    if (item.Cells["NguoiDiVP"].Value != null)
                                    {
                                        string[] date = item.Cells["NgayChuyenVP"].Value.ToString().Split('/');
                                        //LichSuChuyenVanPhong lichsuchuyenvanphong = new LichSuChuyenVanPhong();
                                        //lichsuchuyenvanphong.NgayChuyen = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                                        //lichsuchuyenvanphong.NguoiDi = int.Parse(item.Cells["NguoiDiVP"].Value.ToString());
                                        //if (item.Cells["GhiChuVP"].Value != null)
                                        //lichsuchuyenvanphong.GhiChuChuyen = item.Cells["GhiChuVP"].Value.ToString();
                                        //lichsuchuyenvanphong.MaDon = donkh.MaDon;
                                        //_cDonKH.ThemLichSuChuyenVanPhong(lichsuchuyenvanphong);

                                        LichSuDonTu entity = new LichSuDonTu();
                                        entity.NgayChuyen = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                                        entity.ID_NoiChuyen = 4;
                                        entity.NoiChuyen = "Tổ Văn Phòng";
                                        entity.ID_NoiNhan = int.Parse(item.Cells["NguoiDiVP"].Value.ToString());
                                        entity.NoiNhan = _cTaiKhoan.GetHoTen(int.Parse(item.Cells["NguoiDiVP"].Value.ToString()));
                                        if (item.Cells["GhiChuVP"].Value != null)
                                        entity.GhiChu = item.Cells["GhiChuVP"].Value.ToString();
                                        entity.MaDon = donkh.MaDon;
                                        _cLichSuDonTu.Them(entity);
                                    }
                                }
                            }

                        _cDonKH.commitTransaction();
                        MessageBox.Show("Thành công\nSố đơn từ " + min.ToString().Insert(min.ToString().Length - 2, "-") + " đến " + max.ToString().Insert(max.ToString().Length - 2, "-"), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbLD.SelectedIndex = -1;
                        txtNoiDung.Text = "";
                        txtSoCongVan.Text = "";
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
                for (int i = 0; i < dgvDanhBoChuyenVanPhong.Rows.Count - 2; i++)
                    if (i != e.RowIndex && dgvDanhBoChuyenVanPhong["DanhBoVP", i].Value != null && dgvDanhBoChuyenVanPhong["DanhBoVP", i].Value.ToString() != "" && dgvDanhBoChuyenVanPhong["DanhBoVP", i].Value.ToString() == dgvDanhBoChuyenVanPhong["DanhBoVP", e.RowIndex].Value.ToString())
                    {
                        MessageBox.Show("Danh Bộ đã nhập rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                if (_cThuTien.GetMoiNhat(dgvDanhBoChuyenVanPhong["DanhBoVP", e.RowIndex].Value.ToString()) != null)
                {
                    HOADON hoadon = _cThuTien.GetMoiNhat(dgvDanhBoChuyenVanPhong["DanhBoVP", e.RowIndex].Value.ToString());
                    dgvDanhBoChuyenVanPhong["HopDongVP", e.RowIndex].Value = hoadon.HOPDONG;
                    dgvDanhBoChuyenVanPhong["HoTenVP", e.RowIndex].Value = hoadon.TENKH;
                    dgvDanhBoChuyenVanPhong["DiaChiVP", e.RowIndex].Value = hoadon.SO + " " + hoadon.DUONG + _cDocSo.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
                    dgvDanhBoChuyenVanPhong["GiaBieuVP", e.RowIndex].Value = hoadon.GB;
                    dgvDanhBoChuyenVanPhong["DinhMucVP", e.RowIndex].Value = hoadon.DM;
                    dgvDanhBoChuyenVanPhong["DotVP", e.RowIndex].Value = hoadon.DOT;
                    dgvDanhBoChuyenVanPhong["KyVP", e.RowIndex].Value = hoadon.KY;
                    dgvDanhBoChuyenVanPhong["NamVP", e.RowIndex].Value = hoadon.NAM;
                    dgvDanhBoChuyenVanPhong["MLTVP", e.RowIndex].Value = hoadon.MALOTRINH;
                    dgvDanhBoChuyenVanPhong["QuanVP", e.RowIndex].Value = hoadon.Quan;
                    dgvDanhBoChuyenVanPhong["PhuongVP", e.RowIndex].Value = hoadon.Phuong;
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

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDon.Text.Trim() != "")
            {
                if (_cDonTu.CheckExist(int.Parse(txtMaDon.Text.Trim())) == true)
                {
                    _dontu = _cDonTu.Get(int.Parse(txtMaDon.Text.Trim()));
                    txtSoCongVan.Text = _dontu.SoCongVan;
                }
                else
                {
                    MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
