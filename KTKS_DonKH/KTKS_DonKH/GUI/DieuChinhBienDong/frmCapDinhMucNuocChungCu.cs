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

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmCapDinhMucNuocChungCu : Form
    {
        string _mnu = "mnuCapDinhMucNuocChungCuCCCD";
        CChungTu _cChungTu = new CChungTu();
        CThuTien _cThuTien = new CThuTien();
        HOADON _hoadon = null;
        bool _flagThem = false;

        public frmCapDinhMucNuocChungCu()
        {
            InitializeComponent();
        }

        private void frmCapDinhMucNuocChungCu_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
            dgvDSDanhBo.AutoGenerateColumns = false;
        }

        /// <summary>
        /// Hiện thị Tổng số NK Đăng Ký của Danh Bộ
        /// </summary>
        private void LoadTongNK()
        {
            int TongNK = 0;
            foreach (DataRow itemRow in ((DataTable)dgvDanhSach.DataSource).Rows)
                if (!bool.Parse(itemRow["Cat"].ToString()))
                {
                    TongNK++;
                }
            lbTongNK.Text = "Tổng NK: " + TongNK;
            lbTongDM.Text = "Tổng ĐM: " + TongNK * 4;
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
                        txtHoTen.Text = _hoadon.TENKH;
                        txtDiaChi.Text = _hoadon.SO + " " + _hoadon.DUONG;
                        txtGiaBieu.Text = _hoadon.GB.ToString();
                        if (_hoadon.DM != null)
                            txtDinhMuc.Text = _hoadon.DM.Value.ToString();
                        dgvDanhSach.DataSource = _cChungTu.getDS_ChiTiet_DanhBo(txtDanhBo.Text.Trim());
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

        private void dgvDanhSach_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            _flagThem = true;
        }

        private void dgvDanhSach_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
                {
                    if (_hoadon != null && _flagThem == true && dgvDanhSach["CCCD", e.RowIndex].Value != null && dgvDanhSach["CCCD", e.RowIndex].Value.ToString() != "")
                    {
                        ///Kiểm tra Danh Bộ & Số Chứng Từ
                        if (_cChungTu.CheckExist_CT(dgvDanhSach["CCCD", e.RowIndex].Value.ToString(), 15))
                        {
                            MessageBox.Show("Số đăng ký này đã có đăng ký trước", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                            if (_cChungTu.CheckExist_CT(_hoadon.DANHBA, dgvDanhSach["CCCD", e.RowIndex].Value.ToString(), 15))
                            {
                                MessageBox.Show("Số đăng ký này đã đăng ký với Danh Bộ này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        using (var scope = new TransactionScope())
                        {
                            ///Kiểm tra Số Chứng Từ
                            if (_cChungTu.CheckExist(dgvDanhSach["CCCD", e.RowIndex].Value.ToString(), 15) == false)
                            {
                                ChungTu chungtu = new ChungTu();
                                chungtu.MaCT = dgvDanhSach["CCCD", e.RowIndex].Value.ToString();
                                string[] NgaySinhs = null;
                                if (dgvDanhSach["CCCD", e.RowIndex].Value.ToString().Contains("/"))
                                    NgaySinhs = dgvDanhSach["CCCD", e.RowIndex].Value.ToString().Split('/');
                                else
                                    if (dgvDanhSach["CCCD", e.RowIndex].Value.ToString().Contains("-"))
                                        NgaySinhs = dgvDanhSach["CCCD", e.RowIndex].Value.ToString().Split('-');
                                if (NgaySinhs != null && NgaySinhs.Count() == 3)
                                {
                                    chungtu.NgaySinh = new DateTime(int.Parse(NgaySinhs[2]), int.Parse(NgaySinhs[1]), int.Parse(NgaySinhs[0]));
                                }
                                else
                                    chungtu.NgaySinh = new DateTime(int.Parse(dgvDanhSach["CCCD", e.RowIndex].Value.ToString()), 1, 1);
                                chungtu.HoTen = dgvDanhSach["HoTen", e.RowIndex].Value.ToString();
                                chungtu.DiaChi = dgvDanhSach["DiaChi", e.RowIndex].Value.ToString();
                                chungtu.SoNKTong = 1;
                                chungtu.MaLCT = 15;
                                _cChungTu.Them(chungtu);
                                //
                                ChungTu_ChiTiet ctchungtu = new ChungTu_ChiTiet();
                                ctchungtu.DanhBo = _hoadon.DANHBA;
                                ctchungtu.MaLCT = 15;
                                ctchungtu.MaCT = chungtu.MaCT;
                                ctchungtu.SoNKDangKy = 1;
                                if (dgvDanhSach["NgayHetHan", e.RowIndex].Value != null && dgvDanhSach["NgayHetHan", e.RowIndex].Value.ToString() != "")
                                {
                                    string[] NgayHetHans = null;
                                    if (dgvDanhSach["NgayHetHan", e.RowIndex].Value.ToString().Contains("/"))
                                        NgayHetHans = dgvDanhSach["NgayHetHan", e.RowIndex].Value.ToString().Split('/');
                                    else
                                        if (dgvDanhSach["NgayHetHan", e.RowIndex].Value.ToString().Contains("-"))
                                            NgayHetHans = dgvDanhSach["NgayHetHan", e.RowIndex].Value.ToString().Split('-');
                                    if (NgayHetHans.Count() == 3)
                                    {
                                        ctchungtu.NgayHetHan = new DateTime(int.Parse(NgayHetHans[2]), int.Parse(NgayHetHans[1]), int.Parse(NgayHetHans[0]));
                                    }
                                }
                                ctchungtu.Lo = dgvDanhSach["Lo", e.RowIndex].Value.ToString();
                                ctchungtu.Phong = dgvDanhSach["Phong", e.RowIndex].Value.ToString();
                                if (_hoadon != null)
                                {
                                    ctchungtu.Phuong = _hoadon.Phuong;
                                    ctchungtu.Quan = _hoadon.Quan;
                                }
                                _cChungTu.ThemCT(ctchungtu);
                                ///Ghi thông tin Lịch Sử chung
                                ChungTu_LichSu lichsuchungtu = new ChungTu_LichSu();
                                lichsuchungtu.Phuong = ctchungtu.Phuong;
                                lichsuchungtu.Quan = ctchungtu.Quan;
                                lichsuchungtu.DanhBo = ctchungtu.DanhBo;
                                lichsuchungtu.MaLCT = ctchungtu.MaLCT;
                                lichsuchungtu.MaCT = ctchungtu.MaCT;
                                lichsuchungtu.SoNKTong = chungtu.SoNKTong;
                                lichsuchungtu.SoNKDangKy = ctchungtu.SoNKDangKy;
                                lichsuchungtu.ThoiHan = ctchungtu.ThoiHan;
                                lichsuchungtu.NgayHetHan = ctchungtu.NgayHetHan;
                                lichsuchungtu.GhiChu = ctchungtu.GhiChu;
                                lichsuchungtu.Lo = ctchungtu.Lo;
                                lichsuchungtu.Phong = ctchungtu.Phong;
                                _cChungTu.ThemLichSuChungTu(lichsuchungtu);
                                scope.Complete();
                                _flagThem = false;
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
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
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDanhSach_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDanhSach.Columns[e.ColumnIndex].Name == "CCCD")
                {
                    DataTable dt = new DataTable();
                    if (_cChungTu.CheckExist_CT(dgvDanhSach["CCCD", e.RowIndex].Value.ToString(), 15))
                    {
                        dt = _cChungTu.getDS_ChiTiet(dgvDanhSach["CCCD", e.RowIndex].Value.ToString(), 15);
                        MessageBox.Show("Số đăng ký này đã có đăng ký trước", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        if (_cChungTu.CheckExist_CT(txtDanhBo.Text.Trim(), dgvDanhSach["CCCD", e.RowIndex].Value.ToString(), 15))
                        {
                            dt = _cChungTu.getDS_ChiTiet(dgvDanhSach["CCCD", e.RowIndex].Value.ToString(), 15);
                            MessageBox.Show("Số đăng ký này đã đăng ký với Danh Bộ này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    dgvDSDanhBo.DataSource = dt;
                }
                else
                    if (dgvDanhSach.Columns[e.ColumnIndex].Name == "Cat")
                    {
                        if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                        {
                            ChungTu_ChiTiet ctchungtu = _cChungTu.GetCT(txtDanhBo.Text.Trim(), dgvDanhSach["CCCD", e.RowIndex].Value.ToString(), 15);
                            if (ctchungtu != null)
                            {
                                ctchungtu.Cat = bool.Parse(dgvDanhSach["Cat", e.RowIndex].Value.ToString());
                                if (_cChungTu.SuaCT(ctchungtu))
                                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                            MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        if (dgvDanhSach.Columns[e.ColumnIndex].Name == "Phong" || dgvDanhSach.Columns[e.ColumnIndex].Name == "Lo"
                            || dgvDanhSach.Columns[e.ColumnIndex].Name == "HoTen" || dgvDanhSach.Columns[e.ColumnIndex].Name == "DiaChi"
                            || dgvDanhSach.Columns[e.ColumnIndex].Name == "NgaySinh" || dgvDanhSach.Columns[e.ColumnIndex].Name == "NgayHetHan")
                        {
                            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                            {
                                ChungTu chungtu = _cChungTu.Get(dgvDanhSach["CCCD", e.RowIndex].Value.ToString(), 15);
                                ChungTu_ChiTiet ctchungtu = _cChungTu.GetCT(txtDanhBo.Text.Trim(), dgvDanhSach["CCCD", e.RowIndex].Value.ToString(), 15);
                                if (chungtu != null && ctchungtu != null)
                                {
                                    string[] NgaySinhs = null;
                                    if (dgvDanhSach["CCCD", e.RowIndex].Value.ToString().Contains("/"))
                                        NgaySinhs = dgvDanhSach["CCCD", e.RowIndex].Value.ToString().Split('/');
                                    else
                                        if (dgvDanhSach["CCCD", e.RowIndex].Value.ToString().Contains("-"))
                                            NgaySinhs = dgvDanhSach["CCCD", e.RowIndex].Value.ToString().Split('-');
                                    if (NgaySinhs != null && NgaySinhs.Count() == 3)
                                    {
                                        chungtu.NgaySinh = new DateTime(int.Parse(NgaySinhs[2]), int.Parse(NgaySinhs[1]), int.Parse(NgaySinhs[0]));
                                    }
                                    else
                                        chungtu.NgaySinh = new DateTime(int.Parse(dgvDanhSach["CCCD", e.RowIndex].Value.ToString()), 1, 1);
                                    chungtu.HoTen = dgvDanhSach["HoTen", e.RowIndex].Value.ToString();
                                    chungtu.DiaChi = dgvDanhSach["DiaChi", e.RowIndex].Value.ToString();
                                    if (dgvDanhSach["NgayHetHan", e.RowIndex].Value != null && dgvDanhSach["NgayHetHan", e.RowIndex].Value.ToString() != "")
                                    {
                                        string[] NgayHetHans = null;
                                        if (dgvDanhSach["NgayHetHan", e.RowIndex].Value.ToString().Contains("/"))
                                            NgayHetHans = dgvDanhSach["NgayHetHan", e.RowIndex].Value.ToString().Split('/');
                                        else
                                            if (dgvDanhSach["NgayHetHan", e.RowIndex].Value.ToString().Contains("-"))
                                                NgayHetHans = dgvDanhSach["NgayHetHan", e.RowIndex].Value.ToString().Split('-');
                                        if (NgayHetHans.Count() == 3)
                                        {
                                            ctchungtu.NgayHetHan = new DateTime(int.Parse(NgayHetHans[2]), int.Parse(NgayHetHans[1]), int.Parse(NgayHetHans[0]));
                                        }
                                    }
                                    ctchungtu.Lo = dgvDanhSach["Lo", e.RowIndex].Value.ToString();
                                    ctchungtu.Phong = dgvDanhSach["Phong", e.RowIndex].Value.ToString();
                                    if (_cChungTu.Sua(chungtu) && _cChungTu.SuaCT(ctchungtu))
                                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
