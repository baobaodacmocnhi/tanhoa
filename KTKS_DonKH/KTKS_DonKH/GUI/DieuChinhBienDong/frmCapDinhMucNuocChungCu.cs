using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.DAL.QuanTri;
using System.Transactions;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.DieuChinhBienDong;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.wrThuongVu;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmCapDinhMucNuocChungCu : Form
    {
        string _mnu = "mnuCapDinhMucNuocChungCuCCCD";
        CChungTu _cChungTu = new CChungTu();
        CThuTien _cThuTien = new CThuTien();
        wsThuongVu _wsThuongVu = new wsThuongVu();
        HOADON _hoadon = null;
        ChungTu_ChiTiet _ctchungtu = null;
        int _TongNK = 0;

        public frmCapDinhMucNuocChungCu()
        {
            InitializeComponent();
        }

        private void frmCapDinhMucNuocChungCu_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
            dgvDSDanhBo.AutoGenerateColumns = false;
            dgvDanhSachXoa.AutoGenerateColumns = false;
        }

        public void Clear()
        {
            txtHoTen.Text = "";
            txtNgaySinh.Text = "";
            txtCCCD.Text = "";
            txtGhiChu.Text = "";
            txtNgayHetHan.Text = "";
            chkCat.Checked = false;
            chkKhacDiaBan.Checked = false;
            chkThuongTru.Checked = false;
            chkTamTru.Checked = false;
            _ctchungtu = null;

            LoadTongNK();
            txtHoTen.Focus();
        }

        /// <summary>
        /// Hiện thị Tổng số NK Đăng Ký của Danh Bộ
        /// </summary>
        private void LoadTongNK()
        {
            if (txtDanhBo.Text.Trim() != "")
            {
                dgvDanhSach.DataSource = _cChungTu.getDS_ChiTiet_DanhBo(txtDanhBo.Text.Trim());
                dgvDanhSachXoa.DataSource = _cChungTu.getDS_ChiTiet_Xoa_DanhBo(txtDanhBo.Text.Trim());
            }
            else
                if (txtSHS.Text.Trim() != "")
                    dgvDanhSach.DataSource = _cChungTu.getDS_ChiTiet_SHS(txtSHS.Text.Trim());
            int TongNK = 0;
            foreach (DataRow itemRow in ((DataTable)dgvDanhSach.DataSource).Rows)
                if (!bool.Parse(itemRow["Cat"].ToString()))
                {
                    TongNK++;
                }
            _TongNK = TongNK;
            lbTongNK.Text = "Tổng NK: " + TongNK;
            lbTongDM.Text = "Tổng ĐM: " + TongNK * 4;
            dgvDanhSach.Focus();
            if (dgvDanhSach.Rows.Count > 0)
                dgvDanhSach.CurrentCell = dgvDanhSach.Rows[dgvDanhSach.Rows.Count - 1].Cells[3];
        }

        public void FillForm(ChungTu_ChiTiet en)
        {
            if (en.STT != null)
                txtSTT.Text = en.STT.Value.ToString();
            txtLo.Text = en.Lo;
            txtPhong.Text = en.Phong;
            txtCCCD.Text = en.MaCT;
            txtHoTen.Text = en.ChungTu.HoTen;
            if (en.ChungTu.NgaySinh != null)
                txtNgaySinh.Text = en.ChungTu.NgaySinh.Value.ToString("dd/MM/yyyy");
            txtDiaChi.Text = en.ChungTu.DiaChi;
            if (en.NgayHetHan != null)
                txtNgayHetHan.Text = en.NgayHetHan.Value.ToString("dd/MM/yyyy");
            txtGhiChu.Text = en.GhiChu;
            chkCat.Checked = en.Cat;
            if (en.SHS != "")
                txtSHS.Text = en.SHS;
            chkKhacDiaBan.Checked = en.ChungTu.KhacDiaBan;
            chkThuongTru.Checked = en.ThuongTru;
            chkTamTru.Checked = en.TamTru;
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13 && txtDanhBo.Text.Trim() != "")
                {
                    _hoadon = _cThuTien.GetMoiNhat(txtDanhBo.Text.Trim());
                    if (_hoadon != null)
                    {
                        txtDanhBo.Text = _hoadon.DANHBA;
                        txtMLT.Text = _hoadon.MALOTRINH;
                        txtHoTenCC.Text = _hoadon.TENKH;
                        txtDiaChiCC.Text = _hoadon.SO + " " + _hoadon.DUONG;
                        txtGiaBieu.Text = _hoadon.GB.ToString();
                        if (_hoadon.DM != null)
                            txtDinhMuc.Text = _hoadon.DM.Value.ToString();
                        LoadTongNK();
                    }
                    else
                        MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDanhSach_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
                {
                    ChungTu_ChiTiet ctchungtu = _cChungTu.GetCT(txtDanhBo.Text.Trim(), e.Row.Cells["CCCD"].Value.ToString(), 15);
                    if (ctchungtu != null)
                    {
                        if (_cChungTu.XoaCT(ctchungtu))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
                {
                    if (txtCCCD.Text.Trim() != "" && txtDanhBo.Text.Trim().Length == 11)
                    {
                        if (txtCCCD.Text.Trim().Length != 12)
                        {
                            MessageBox.Show("CCCD gồm 12 số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (txtSHS.Text.Trim() == "" && txtDanhBo.Text.Trim().Length != 11)
                        {
                            MessageBox.Show("Thiếu Danh Bộ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        //string resultCheckCCCD = "";
                        //int result = _wsThuongVu.checkExists_CCCD("", txtCCCD.Text.Trim(), out resultCheckCCCD);
                        //if (result == 1)
                        //{
                        //    if (!resultCheckCCCD.Contains("Tân Hòa"))
                        //    {
                        //        MessageBox.Show(resultCheckCCCD, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //        return;
                        //    }
                        //    else
                        //    {
                        //        if (_cChungTu.CheckExist_CT(txtDanhBo.Text.Trim(), txtCCCD.Text.Trim(), 15) == true)
                        //        {
                        //            MessageBox.Show("Dữ liệu đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //            return;
                        //        }
                        //    }
                        //}
                        //else
                        //    if (result == -1)
                        //    {
                        //        MessageBox.Show("Lỗi, vui lòng thao tác lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //        return;
                        //    }
                        var transactionOptions = new TransactionOptions();
                        transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
                        using (var scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                        {
                            ChungTu chungtu;
                            ///Kiểm tra Số Chứng Từ
                            if (_cChungTu.CheckExist(txtCCCD.Text.Trim(), 15) == false)
                            {
                                chungtu = new ChungTu();
                                chungtu.MaCT = txtCCCD.Text.Trim();
                                if (txtNgaySinh.Text.ToString() != "")
                                {
                                    string[] NgaySinhs = null;
                                    if (txtNgaySinh.Text.Trim().Contains("/"))
                                        NgaySinhs = txtNgaySinh.Text.Trim().Split('/');
                                    else
                                        if (txtNgaySinh.Text.Trim().Contains("-"))
                                            NgaySinhs = txtNgaySinh.Text.Trim().Split('-');
                                    if (NgaySinhs != null && NgaySinhs.Count() == 3)
                                        chungtu.NgaySinh = new DateTime(int.Parse(NgaySinhs[2]), int.Parse(NgaySinhs[1]), int.Parse(NgaySinhs[0]));
                                    else
                                        chungtu.NgaySinh = new DateTime(int.Parse(txtNgaySinh.Text.Trim()), 1, 1);
                                }
                                chungtu.HoTen = txtHoTen.Text.Trim();
                                chungtu.DiaChi = txtDiaChi.Text.Trim();
                                chungtu.SoNKTong = 1;
                                chungtu.MaLCT = 15;
                                chungtu.KhacDiaBan = chkKhacDiaBan.Checked;
                                _cChungTu.Them(chungtu);
                            }
                            else
                            {
                                chungtu = _cChungTu.Get(txtCCCD.Text.Trim(), 15);
                                if (txtNgaySinh.Text.ToString() != "")
                                {
                                    string[] NgaySinhs = null;
                                    if (txtNgaySinh.Text.Trim().Contains("/"))
                                        NgaySinhs = txtNgaySinh.Text.Trim().Split('/');
                                    else
                                        if (txtNgaySinh.Text.Trim().Contains("-"))
                                            NgaySinhs = txtNgaySinh.Text.Trim().Split('-');
                                    if (NgaySinhs != null && NgaySinhs.Count() == 3)
                                        chungtu.NgaySinh = new DateTime(int.Parse(NgaySinhs[2]), int.Parse(NgaySinhs[1]), int.Parse(NgaySinhs[0]));
                                    else
                                        chungtu.NgaySinh = new DateTime(int.Parse(txtNgaySinh.Text.Trim()), 1, 1);
                                }
                                chungtu.HoTen = txtHoTen.Text.Trim();
                                chungtu.DiaChi = txtDiaChi.Text.Trim();
                                chungtu.MaLCT = 15;
                                chungtu.KhacDiaBan = chkKhacDiaBan.Checked;
                                _cChungTu.Sua(chungtu);
                            }
                            //Lấy thông tin Chứng Từ để kiểm tra
                            ChungTu _chungtu = _cChungTu.Get(txtCCCD.Text.Trim(), 15);
                            if (_chungtu.SoNKTong - _chungtu.ChungTu_ChiTiets.Sum(o => o.SoNKDangKy) < 1)
                            {
                                MessageBox.Show("Vượt Nhân Khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            ChungTu_ChiTiet ctchungtu = new ChungTu_ChiTiet();
                            ctchungtu.DanhBo = txtDanhBo.Text.Trim();
                            ctchungtu.ThuongTru = chkThuongTru.Checked;
                            ctchungtu.TamTru = chkTamTru.Checked;
                            ctchungtu.MaLCT = 15;
                            ctchungtu.MaCT = chungtu.MaCT;
                            ctchungtu.SoNKDangKy = 1;
                            if (txtNgayHetHan.Text.Trim() != "")
                            {
                                string[] NgayHetHans = null;
                                if (txtNgayHetHan.Text.Trim().Contains("/"))
                                    NgayHetHans = txtNgayHetHan.Text.Trim().Split('/');
                                else
                                    if (txtNgayHetHan.Text.Trim().Contains("-"))
                                        NgayHetHans = txtNgayHetHan.Text.Trim().Split('-');
                                if (NgayHetHans.Count() == 3)
                                {
                                    ctchungtu.NgayHetHan = new DateTime(int.Parse(NgayHetHans[2]), int.Parse(NgayHetHans[1]), int.Parse(NgayHetHans[0]));
                                }
                            }
                            ctchungtu.GhiChu = txtGhiChu.Text.Trim();
                            if (txtSTT.Text.Trim() != "")
                                ctchungtu.STT = int.Parse(txtSTT.Text.Trim());
                            ctchungtu.Lo = txtLo.Text.Trim();
                            ctchungtu.Phong = txtPhong.Text.Trim();
                            if (_hoadon != null)
                            {
                                ctchungtu.Phuong = _hoadon.Phuong;
                                ctchungtu.Quan = _hoadon.Quan;
                            }
                            if (txtSHS.Text.Trim() != "")
                            {
                                ctchungtu.SHS = txtSHS.Text.Trim();
                                ctchungtu.DanhBo = "";
                            }
                            if (_cChungTu.ThemCT(ctchungtu))
                            {
                                ///Ghi thông tin Lịch Sử chung
                                ChungTu_LichSu lichsuchungtu = _cChungTu.ChungTuToLichSu(ctchungtu);
                                lichsuchungtu.Loai = "Thêm";
                                lichsuchungtu.NgayThucHien = DateTime.Now;
                                lichsuchungtu.NguoiThucHien = CTaiKhoan.HoTen;
                                _cChungTu.ThemLichSuChungTu(lichsuchungtu);
                            }
                            scope.Complete();
                        }
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ctchungtu != null)
                    if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                    {
                        string[] NgaySinhs = null;
                        if (txtNgaySinh.Text.Trim().Contains("/"))
                            NgaySinhs = txtNgaySinh.Text.Trim().Split('/');
                        else
                            if (txtNgaySinh.Text.Trim().Contains("-"))
                                NgaySinhs = txtNgaySinh.Text.Trim().Split('-');
                        if (NgaySinhs != null && NgaySinhs.Count() == 3)
                        {
                            _ctchungtu.ChungTu.NgaySinh = new DateTime(int.Parse(NgaySinhs[2]), int.Parse(NgaySinhs[1]), int.Parse(NgaySinhs[0]));
                        }
                        else
                            _ctchungtu.ChungTu.NgaySinh = new DateTime(int.Parse(txtNgaySinh.Text.Trim()), 1, 1);
                        _ctchungtu.ChungTu.HoTen = txtHoTen.Text.Trim();
                        _ctchungtu.ChungTu.DiaChi = txtDiaChi.Text.Trim();
                        _ctchungtu.ChungTu.KhacDiaBan = chkKhacDiaBan.Checked;
                        _ctchungtu.ThuongTru = chkThuongTru.Checked;
                        _ctchungtu.TamTru = chkTamTru.Checked;
                        if (txtNgayHetHan.Text.Trim() != "")
                        {
                            string[] NgayHetHans = null;
                            if (txtNgayHetHan.Text.Trim().Contains("/"))
                                NgayHetHans = txtGhiChu.Text.Trim().Split('/');
                            else
                                if (txtNgayHetHan.Text.Trim().Contains("-"))
                                    NgayHetHans = txtGhiChu.Text.Trim().Split('-');
                            if (NgayHetHans.Count() == 3)
                            {
                                _ctchungtu.NgayHetHan = new DateTime(int.Parse(NgayHetHans[2]), int.Parse(NgayHetHans[1]), int.Parse(NgayHetHans[0]));
                            }
                        }
                        _ctchungtu.GhiChu = txtGhiChu.Text.Trim();
                        if (txtSTT.Text.Trim() != "")
                            _ctchungtu.STT = int.Parse(txtSTT.Text.Trim());
                        _ctchungtu.Lo = txtLo.Text.Trim();
                        _ctchungtu.Phong = txtPhong.Text.Trim();
                        if (txtSHS.Text.Trim() != "")
                            _ctchungtu.SHS = txtSHS.Text.Trim();
                        _ctchungtu.Cat = chkCat.Checked;
                        if (_cChungTu.SuaCT(_ctchungtu))
                        {
                            ///Ghi thông tin Lịch Sử chung
                            ChungTu_LichSu lichsuchungtu = _cChungTu.ChungTuToLichSu(_ctchungtu);
                            _cChungTu.ThemLichSuChungTu(lichsuchungtu);
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
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

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _ctchungtu = _cChungTu.GetCT(txtDanhBo.Text.Trim(), dgvDanhSach["CCCD", e.RowIndex].Value.ToString(), 15);
                if (_ctchungtu != null)
                    FillForm(_ctchungtu);
            }
            catch
            {

            }
        }

        private void frmCapDinhMucNuocChungCu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                switch (e.KeyCode)
                {
                    case Keys.D1://lưu
                        btnThem.PerformClick();
                        break;
                    case Keys.D4:
                        frmTimKiemChungTu frm = new frmTimKiemChungTu();
                        frm.ShowDialog();
                        break;
                    default:
                        break;
                }
        }

        private void dgvDanhSach_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    sửaToolStripMenuItem.Enabled = true;
                    xóaToolStripMenuItem.Enabled = true;
                }
                else
                {
                    sửaToolStripMenuItem.Enabled = false;
                    xóaToolStripMenuItem.Enabled = false;
                }
                ///Khi chuột phải Selected-Row sẽ được chuyển đến nơi click chuột
                dgvDanhSach.CurrentCell = dgvDanhSach.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dgvDanhSach_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(dgvDanhSach, new Point(e.X, e.Y));
            }
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                CDataTransfer dataT = new CDataTransfer();
                dataT.Loai = "ChungCu";
                if (_hoadon != null)
                {
                    dataT.Quan = _hoadon.Quan;
                    dataT.Phuong = _hoadon.Phuong;
                }
                dataT.DanhBo = txtDanhBo.Text.Trim();
                dataT.HoTenDB = txtHoTenCC.Text.Trim();
                dataT.DiaChiDB = txtDiaChiCC.Text.Trim();
                dataT.MaCT = dgvDanhSach.CurrentRow.Cells["CCCD"].Value.ToString();
                dataT.MaLCT = 15;

                frmSoDK frm = new frmSoDK(dataT);
                frm.Show();
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                _ctchungtu = _cChungTu.GetCT(txtDanhBo.Text.Trim(), dgvDanhSach.CurrentRow.Cells["CCCD"].Value.ToString(), int.Parse(dgvDanhSach.CurrentRow.Cells["MaLCT"].Value.ToString()));
                if (_ctchungtu != null && MessageBox.Show("Bạn có chắc chắn???", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (_cChungTu.XoaCT(_ctchungtu))
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtSTT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtLo.Focus();
        }

        private void txtLo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtPhong.Focus();
        }

        private void txtPhong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtHoTen.Focus();
        }

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtNgaySinh.Focus();
        }

        private void txtNgaySinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtDiaChi.Focus();
        }

        private void txtDiaChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtCCCD.Focus();
        }

        private void txtCCCD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtGhiChu.Focus();
            }
        }

        private void txtCCCD_Leave(object sender, EventArgs e)
        {
            if (txtCCCD.Text.Trim() != "")
            {
                if (txtCCCD.Text.Trim() != "" && txtCCCD.Text.Trim().Length != 12)
                {
                    MessageBox.Show("CCCD gồm 12 số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string resultCheckCCCD = "";
                int result = _wsThuongVu.checkExists_CCCD("", txtCCCD.Text.Trim(), out resultCheckCCCD);
                if (result == 1)
                {
                    if (!resultCheckCCCD.Contains("Tân Hòa"))
                    {
                        MessageBox.Show(resultCheckCCCD, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (_cChungTu.CheckExist_CT(txtDanhBo.Text.Trim(), txtCCCD.Text.Trim(), 15) == true)
                        {
                            MessageBox.Show("Dữ liệu đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            foreach (DataGridViewRow item in dgvDanhSach.Rows)
                                if (item.Cells["CCCD"].Value.ToString() == txtCCCD.Text.Trim())
                                {
                                    dgvDanhSach.Focus();
                                    dgvDanhSach.CurrentCell = dgvDanhSach.Rows[item.Index].Cells[6];
                                }
                        }
                    }
                }
                dgvDSDanhBo.DataSource = _cChungTu.getDS_ChiTiet(txtCCCD.Text.Trim(), 15);
                ChungTu ct = _cChungTu.Get(txtCCCD.Text.Trim(), 15);
                if (ct != null)
                {
                    txtHoTen.Text = ct.HoTen;
                    if (ct.NgaySinh != null)
                        txtNgaySinh.Text = ct.NgaySinh.Value.ToString("dd/MM/yyyy");
                    else
                        txtNgaySinh.Text = "";
                    txtDiaChi.Text = ct.DiaChi;
                    chkKhacDiaBan.Checked = ct.KhacDiaBan;
                }
            }
        }

        private void txtNgayHetHan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnThem.Focus();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_hoadon != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                for (int i = 0; i < dgvDanhSach.Rows.Count; i++)
                {
                    DataRow dr = dsBaoCao.Tables["DSChungTu"].NewRow();

                    dr["STT"] = i + 1;
                    dr["DanhBo"] = txtDanhBo.Text.Trim().Insert(7, " ").Insert(4, " ");
                    dr["HoTen"] = txtHoTenCC.Text.Trim();
                    dr["DiaChi"] = txtDiaChiCC.Text.Trim();
                    dr["HopDong"] = _hoadon.HOPDONG;
                    dr["Dot"] = _hoadon.DOT.ToString();
                    dr["GiaBieu"] = _hoadon.GB;
                    dr["DinhMuc"] = _hoadon.DM;
                    dr["LoTrinh"] = _hoadon.DOT + _hoadon.MAY + _hoadon.STT;
                    //dr["TenLCT"] = dgvKhachHangChungCu["TenLCT", i].Value.ToString();
                    dr["HoTenCT"] = dgvDanhSach["HoTen", i].Value.ToString();
                    dr["MaCT"] = dgvDanhSach["CCCD", i].Value.ToString();
                    dr["SoNKTong"] = _TongNK;
                    if (bool.Parse(dgvDanhSach["Cat", i].Value.ToString()))
                        dr["SoNKDangKy"] = 0;
                    else
                        dr["SoNKDangKy"] = 1;
                    //if (chkAnGhiChu.Checked == false)
                    dr["GhiChu"] = dgvDanhSach["GhiChu", i].Value.ToString();
                    dr["Lo"] = dgvDanhSach["Lo", i].Value.ToString();
                    dr["Phong"] = dgvDanhSach["Phong", i].Value.ToString();

                    dsBaoCao.Tables["DSChungTu"].Rows.Add(dr);
                }
                rptDSChungTuChungCu rpt = new rptDSChungTuChungCu();
                rpt.SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.ShowDialog();
            }
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Ngày":
                    panel1.Visible = false;
                    panel2.Visible = true;
                    break;
                default:
                    panel1.Visible = true;
                    panel2.Visible = false;
                    break;
            }
            dgvDanhSach.DataSource = null;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "CCCD":
                    if (string.IsNullOrEmpty(txtDanhBo.Text.Trim()))
                        dgvDanhSach.DataSource = _cChungTu.getDS_ChiTiet_TimKiem_CCCD(txtNoiDungTimKiem.Text.Trim());
                    else
                        dgvDanhSach.DataSource = _cChungTu.getDS_ChiTiet_TimKiem_CCCD(txtDanhBo.Text.Trim(), txtNoiDungTimKiem.Text.Trim());
                    break;
                case "Họ Tên":
                    dgvDanhSach.DataSource = _cChungTu.getDS_ChiTiet_TimKiem_HoTen(txtNoiDungTimKiem.Text.Trim());
                    break;
                case "STT":
                    if (string.IsNullOrEmpty(txtNoiDungTimKiem2.Text.Trim()))
                        if (string.IsNullOrEmpty(txtDanhBo.Text.Trim()))
                            dgvDanhSach.DataSource = _cChungTu.getDS_ChiTiet_TimKiem_STT(int.Parse(txtNoiDungTimKiem.Text.Trim()));
                        else
                            dgvDanhSach.DataSource = _cChungTu.getDS_ChiTiet_TimKiem_STT(txtDanhBo.Text.Trim(), int.Parse(txtNoiDungTimKiem.Text.Trim()));
                    else
                        if (string.IsNullOrEmpty(txtDanhBo.Text.Trim()))
                            dgvDanhSach.DataSource = _cChungTu.getDS_ChiTiet_TimKiem_STT(int.Parse(txtNoiDungTimKiem.Text.Trim()), int.Parse(txtNoiDungTimKiem2.Text.Trim()));
                        else
                            dgvDanhSach.DataSource = _cChungTu.getDS_ChiTiet_TimKiem_STT(txtDanhBo.Text.Trim(), int.Parse(txtNoiDungTimKiem.Text.Trim()), int.Parse(txtNoiDungTimKiem2.Text.Trim()));
                    break;
                case "Lô":
                    if (string.IsNullOrEmpty(txtDanhBo.Text.Trim()))
                        dgvDanhSach.DataSource = _cChungTu.getDS_ChiTiet_TimKiem_Lo(txtNoiDungTimKiem.Text.Trim());
                    else
                        dgvDanhSach.DataSource = _cChungTu.getDS_ChiTiet_TimKiem_Lo(txtDanhBo.Text.Trim(), txtNoiDungTimKiem.Text.Trim());
                    break;
                case "Phòng":
                    if (string.IsNullOrEmpty(txtDanhBo.Text.Trim()))
                        dgvDanhSach.DataSource = _cChungTu.getDS_ChiTiet_TimKiem_Phong(txtNoiDungTimKiem.Text.Trim());
                    else
                        dgvDanhSach.DataSource = _cChungTu.getDS_ChiTiet_TimKiem_Phong(txtDanhBo.Text.Trim(), txtNoiDungTimKiem.Text.Trim());
                    break;
                case "Ngày":
                    dgvDanhSach.DataSource = _cChungTu.getDS_ChiTiet_TimKiem_Ngay(txtDanhBo.Text.Trim(), txtLo.Text.Trim(), dateTu_TimKiem.Value, dateDen_TimKiem.Value);
                    break;
                default:

                    break;
            }
        }

        private void txtNoiDungTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtNoiDungTimKiem.Text.Trim() != "")
            {
                btnTimKiem.PerformClick();
            }
        }

        private void txtSHS_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13 && txtSHS.Text.Trim() != "")
                {
                    LoadTongNK();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSachXoa_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSachXoa.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }


    }
}
