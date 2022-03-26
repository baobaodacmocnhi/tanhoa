using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.QuanTri;
using DocSo_PC.LinQ;
using DocSo_PC.DAL.MaHoa;
using DocSo_PC.DAL;
using System.Transactions;

namespace DocSo_PC.GUI.MaHoa
{
    public partial class frmNhanDon : Form
    {
        string _mnu = "mnuNhanDon";
        CDonTu _cDonTu = new CDonTu();
        CThuTien _cThuTien = new CThuTien();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        wrDHN.wsDHN _wsDHN = new wrDHN.wsDHN();

        MaHoa_DonTu _dontu = null;
        HOADON _hoadon = null;

        public frmNhanDon()
        {
            InitializeComponent();
        }

        private void frmNhanDon_Load(object sender, EventArgs e)
        {
            try
            {
                dgvDanhSach.AutoGenerateColumns = false;
                dgvDonTuLichSu.AutoGenerateColumns = false;
                cmbNoiChuyen.DataSource = _cDonTu.getDS_NoiChuyen();
                cmbNoiChuyen.ValueMember = "ID";
                cmbNoiChuyen.DisplayMember = "Name";
                cmbNoiChuyen.SelectedIndex = -1;
                cmbNoiNhan.DataSource = _cDonTu.getDS_NoiNhan();
                cmbNoiNhan.ValueMember = "ID";
                cmbNoiNhan.DisplayMember = "Name";
                cmbNoiNhan.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadTTKH(HOADON entity)
        {
            txtDanhBo.Text = entity.DANHBA.Insert(7, " ").Insert(4, " ");
            txtHoTen.Text = entity.TENKH;
            txtDiaChi.Text = entity.SO + " " + entity.DUONG;
            txtGiaBieu.Text = entity.GB.ToString();
            if (entity.DM != null)
                txtDinhMuc.Text = entity.DM.ToString();
            else
                txtDinhMuc.Text = "";
            if (entity.DinhMucHN != null)
                txtDinhMucHN.Text = entity.DinhMucHN.Value.ToString();
            else
                txtDinhMucHN.Text = "";
        }

        public void loadDonTu(MaHoa_DonTu entity)
        {
            txtDanhBo.Text = entity.DanhBo.Insert(7, " ").Insert(4, " ");
            txtHoTen.Text = entity.HoTen;
            txtDiaChi.Text = entity.DiaChi;
            txtGiaBieu.Text = entity.GiaBieu.ToString();
            if (entity.DinhMuc != null)
                txtDinhMuc.Text = entity.DinhMuc.ToString();
            else
                txtDinhMuc.Text = "";
            if (entity.DinhMucHN != null)
                txtDinhMucHN.Text = entity.DinhMucHN.Value.ToString();
            else
                txtDinhMucHN.Text = "";
            txtNoiDung.Text = entity.NoiDung;
            txtGhiChu.Text = entity.GhiChu;
            lbTinhTrang.Text = "Tình Trạng: " + entity.TinhTrang;
            loadDonTu_LichSu(entity.ID);
        }

        public void loadDonTu_LichSu(int MaDon)
        {
            dgvDonTuLichSu.DataSource = _cDonTu.getDS_LichSu(MaDon);
        }

        public void Clear()
        {
            txtDanhBo.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            txtDinhMucHN.Text = "";
            txtNoiDung.Text = "";
            txtGhiChu.Text = "";
            ClearChuyenDon();
        }

        public void ClearChuyenDon()
        {
            dateChuyen.Value = DateTime.Now;
            cmbNoiChuyen.SelectedIndex = -1;
            cmbNoiNhan.SelectedIndex = -1;
            cmbKTXM.DataSource = null;
            txtNoiDung_LichSu.Text = "";
            lbTinhTrang.Text = "Tình Trạng";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    MaHoa_DonTu en = new MaHoa_DonTu();
                    en.DanhBo = txtDanhBo.Text.Trim().Replace(" ", "");
                    en.HoTen = txtHoTen.Text.Trim();
                    en.DiaChi = txtDiaChi.Text.Trim();
                    if (txtGiaBieu.Text.Trim() != "")
                        en.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                    if (txtDinhMuc.Text.Trim() != "")
                        en.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                    if (txtDinhMucHN.Text.Trim() != "")
                        en.DinhMucHN = int.Parse(txtDinhMucHN.Text.Trim());
                    en.NoiDung = txtNoiDung.Text.Trim();
                    en.GhiChu = txtGhiChu.Text.Trim();
                    if (_hoadon != null)
                    {
                        en.MLT = _hoadon.MALOTRINH;
                        en.HopDong = _hoadon.HOPDONG;
                        en.Dot = _hoadon.DOT;
                        en.Ky = _hoadon.KY;
                        en.Nam = _hoadon.NAM;
                        en.Quan = _hoadon.Quan;
                        en.Phuong = _hoadon.Phuong;
                    }
                    if (_cDonTu.Them(en))
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        if (_dontu != null)
                        {
                            string flagID = _dontu.ID.ToString();
                            var transactionOptions = new TransactionOptions();
                            transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
                            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                            {
                                if (_cDonTu.Xoa(_dontu))
                                {
                                    _wsDHN.xoa_Folder_Hinh_MaHoa("DonTu", flagID);
                                    scope.Complete();
                                    scope.Dispose();
                                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Clear();
                                }
                            }
                        }
                }
                else
                    MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (_dontu != null)
                    {
                        _dontu.DanhBo = txtDanhBo.Text.Trim().Replace(" ", "");
                        _dontu.HoTen = txtHoTen.Text.Trim();
                        _dontu.DiaChi = txtDiaChi.Text.Trim();
                        if (txtGiaBieu.Text.Trim() != "")
                            _dontu.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                        if (txtDinhMuc.Text.Trim() != "")
                            _dontu.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                        if (txtDinhMucHN.Text.Trim() != "")
                            _dontu.DinhMucHN = int.Parse(txtDinhMucHN.Text.Trim());
                        _dontu.NoiDung = txtNoiDung.Text.Trim();
                        _dontu.GhiChu = txtGhiChu.Text.Trim();
                        if (_hoadon != null)
                        {
                            _dontu.MLT = _hoadon.MALOTRINH;
                            _dontu.Dot = _hoadon.DOT;
                            _dontu.Ky = _hoadon.KY;
                            _dontu.Nam = _hoadon.NAM;
                            _dontu.Quan = _hoadon.Quan;
                            _dontu.Phuong = _hoadon.Phuong;
                        }
                        if (_cDonTu.Sua(_dontu))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtDanhBo.Text.Trim().Replace(" ", "").Length == 11 && e.KeyChar == 13)
            {
                _hoadon = _cThuTien.GetMoiNhat(txtDanhBo.Text.Trim().Replace(" ", ""));
                if (_hoadon != null)
                {
                    loadTTKH(_hoadon);
                }
                else
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMaDon.Text.Trim() != "" && e.KeyChar == 13)
            {
                _dontu = _cDonTu.get(int.Parse(txtMaDon.Text.Trim()));
                if (_dontu != null)
                {
                    loadDonTu(_dontu);
                }
                else
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _dontu = _cDonTu.get(int.Parse(dgvDanhSach.CurrentRow.Cells["ID"].Value.ToString()));
                loadDonTu(_dontu);
                if (dgvDanhSach.Columns[e.ColumnIndex].Name == "XemHinh")
                {
                    _cDonTu.LoadImageView(_cDonTu.imageToByteArray(_cDonTu.byteArrayToImage(_wsDHN.get_Hinh_MaHoa("DonTu", _dontu.ID.ToString(), _dontu.MaHoa_DonTu_Hinhs.SingleOrDefault().Name + _dontu.MaHoa_DonTu_Hinhs.SingleOrDefault().Loai))));
                }
            }
            catch
            {
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = _cDonTu.getDS(dateTuNgay.Value, dateDenNgay.Value);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (_dontu != null)
                    {
                        MaHoa_DonTu_LichSu entity = new MaHoa_DonTu_LichSu();
                        entity.NgayChuyen = dateChuyen.Value;
                        entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                        entity.NoiChuyen = cmbNoiChuyen.Text;
                        entity.ID_NoiNhan = int.Parse(cmbNoiNhan.SelectedValue.ToString());
                        entity.NoiNhan = cmbNoiNhan.SelectedValue.ToString();
                        entity.NoiDung = txtNoiDung_LichSu.Text.Trim();
                        entity.IDMaDon = _dontu.ID;
                        if (cmbNoiNhan.SelectedValue.ToString() == "2")
                        {
                            entity.ID_KTXM = int.Parse(cmbKTXM.SelectedValue.ToString());
                            entity.KTXM = cmbKTXM.SelectedText.ToString();
                        }
                        if (_cDonTu.Them_LichSu(entity) == true)
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadDonTu_LichSu(_dontu.ID);
                            ClearChuyenDon();
                            _cDonTu.Refresh();
                        }
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbNoiNhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNoiNhan.Items.Count > 0 && cmbNoiNhan.SelectedIndex >= 0 && cmbNoiNhan.SelectedValue.ToString() == "2")
            {
                DataTable dt = _cNguoiDung.getDS_KTXM();
                cmbKTXM.DataSource = dt;
                cmbKTXM.ValueMember = "MaND";
                cmbKTXM.DisplayMember = "HoTen";
            }
        }

        private void dgvDonTuLichSu_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
                {
                    if (_dontu != null)
                    {
                        MaHoa_DonTu_LichSu en = _cDonTu.get_LicSu(int.Parse(e.Row.Cells["ID_DTLS"].Value.ToString()));
                        if (_cDonTu.Xoa_LichSu(en) == true)
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadDonTu_LichSu(_dontu.ID);
                            ClearChuyenDon();
                        }
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
