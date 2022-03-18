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

namespace DocSo_PC.GUI.MaHoa
{
    public partial class frmNhanDon : Form
    {
        string _mnu = "mnuNhanDon";
        CDonTu _cDonTu = new CDonTu();
        CThuTien _cThuTien = new CThuTien();

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

        public void loadEntity(MaHoa_DonTu entity)
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
                    if (_hoadon != null)
                    {
                        en.MLT = _hoadon.MALOTRINH;
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
                            if (_cDonTu.Xoa(_dontu))
                            {
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Clear();
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
            if (txtMaDon.Text.Trim()!="" && e.KeyChar == 13)
            {
                _dontu = _cDonTu.get(int.Parse(txtMaDon.Text.Trim()));
                if (_dontu != null)
                {
                    loadEntity(_dontu);
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
                loadEntity(_dontu);
            }
            catch
            {
            }
        }


    }
}
