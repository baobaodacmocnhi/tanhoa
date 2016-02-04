using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.ChuyenKhoan;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;
using ThuTien.DAL.Doi;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmDieuChinhTienDu : Form
    {
        string _DanhBo = "";
        string _SoTien = "";
        string _mnu = "mnuTienDu";
        CTienDu _cTienDu = new CTienDu();
        CHoaDon _cHoaDon = new CHoaDon();
        CBangKe _cBangKe = new CBangKe();
        CPhiMoNuoc _cPhiMoNuoc = new CPhiMoNuoc();

        public frmDieuChinhTienDu()
        {
            InitializeComponent();
        }

        public frmDieuChinhTienDu(string DanhBo, string SoTien)
        {
            _DanhBo = DanhBo;
            _SoTien = SoTien;
            InitializeComponent();
        }

        private void frmChuyenTien_Load(object sender, EventArgs e)
        {
            this.Location = new Point(200, 150);

            if (_DanhBo.Length == 11)
                txtDanhBoCTA.Text = txtDanhBoSuaTien.Text = _DanhBo.Insert(7, " ").Insert(4, " ");
            txtSoTienCTA.Text = txtSoTienCu.Text = _SoTien;

            if (CNguoiDung.MaND == 0||CNguoiDung.MaND == 1)
                btnSua.Enabled = true;
            else
                btnSua.Enabled = false;
        }

        private void txtDanhBoCTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBoCTB.Text.Trim().Replace(" ", "").Length == 11)
            {
                //if (_cTienDu.CheckExist(txtDanhBoCTB.Text.Trim().Replace(" ", "")))
                //{
                    txtSoTienCTB.Text = _cTienDu.GetTienDu(txtDanhBoCTB.Text.Trim().Replace(" ", "")).ToString();
                //}
                //else
                //    MessageBox.Show("Danh Bộ này chưa được Thêm vào Tiền Dư, Xin liên hệ T.CNTT", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtDanhBoCTB_Leave(object sender, EventArgs e)
        {
            txtSoTienCTB.Text = _cTienDu.GetTienDu(txtDanhBoCTB.Text.Trim().Replace(" ", "")).ToString();
        }

        private void txtSoTienChuyen_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(txtSoTienChuyen.Text.Trim()) > int.Parse(txtSoTienCTA.Text.Trim()))
                txtSoTienChuyen.Text = txtSoTienCTA.Text;
        }

        private void btnChuyen_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {
                if (MessageBox.Show("Bạn có chắc chắn Chuyển?", "Xác nhận chuyển", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    if (txtDanhBoCTB.Text.Trim().Replace(" ", "").Length == 11 && int.Parse(txtSoTienChuyen.Text.Trim()) > 0 && int.Parse(txtSoTienCTA.Text.Trim()) > 0)
                    {
                        try
                        {
                            _cTienDu.BeginTransaction();
                            if (_cTienDu.Update(txtDanhBoCTA.Text.Trim().Replace(" ", ""), int.Parse(txtSoTienChuyen.Text.Trim()) * -1, "Chuyển Tiền", txtGhiChuChuyen.Text.Trim(), txtDanhBoCTB.Text.Trim().Replace(" ", "")))
                            {
                                if (_cTienDu.Update(txtDanhBoCTB.Text.Trim().Replace(" ", ""), int.Parse(txtSoTienChuyen.Text.Trim()), "Nhận Tiền", txtGhiChuChuyen.Text.Trim(), txtDanhBoCTA.Text.Trim().Replace(" ", "")))
                                {
                                    _cTienDu.SubmitChanges();
                                    _cTienDu.CommitTransaction();
                                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                                    this.Close();
                                }
                                else
                                {
                                    _cTienDu.Rollback();
                                    MessageBox.Show("Lỗi Update Tiền Dư B, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                _cTienDu.Rollback();
                                MessageBox.Show("Lỗi Update Tiền Dư A, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception)
                        {
                            _cTienDu.Rollback();
                            MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            _cTienDu.NullTransaction();
                        }
                    }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {
                if (MessageBox.Show("Bạn có chắc chắn Sửa?", "Xác nhận sửa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        _cTienDu.BeginTransaction();
                        if (_cTienDu.Update(txtDanhBoSuaTien.Text.Trim().Replace(" ", ""), int.Parse(txtSoTienCu.Text.Trim()) * -1, "Điều Chỉnh Tiền", txtGhiChuSua.Text.Trim()))
                        {
                            if (_cTienDu.Update(txtDanhBoSuaTien.Text.Trim().Replace(" ", ""), int.Parse(txtSoTienMoi.Text.Trim()), "Điều Chỉnh Tiền", txtGhiChuSua.Text.Trim()))
                            {
                                _cTienDu.SubmitChanges();
                                _cTienDu.CommitTransaction();
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                _cTienDu.Rollback();
                                MessageBox.Show("Lỗi Update Tiền Dư Cũ, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            _cTienDu.Rollback();
                            MessageBox.Show("Lỗi Update Tiền Dư Mới, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception)
                    {
                        _cTienDu.Rollback();
                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        _cTienDu.NullTransaction();
                    }
                }
            }
        }

        private void btnChuyenPhiMoNuoc_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {
                if (MessageBox.Show("Bạn có chắc chắn Chuyển Phí Mở Nước?", "Xác nhận sửa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    if (int.Parse(txtSoTienCu.Text.Trim()) >= 50000)
                    {
                        try
                        {
                            _cTienDu.BeginTransaction();
                            if (_cTienDu.Update(txtDanhBoSuaTien.Text.Trim().Replace(" ", ""), -50000, "Điều Chỉnh Tiền", "Thêm Chuyển Phí Mở Nước"))
                            {
                                HOADON hoadon = _cHoaDon.GetMoiNhat(txtDanhBoSuaTien.Text.Trim().Replace(" ", ""));

                                TT_PhiMoNuoc phimonuoc = new TT_PhiMoNuoc();
                                phimonuoc.DanhBo = hoadon.DANHBA;
                                phimonuoc.HoTen = hoadon.TENKH;
                                phimonuoc.DiaChi = hoadon.SO + " " + hoadon.DUONG;
                                phimonuoc.NgayBK = dateBangKe.Value;
                                phimonuoc.SoTien = _cBangKe.GetSoTien(hoadon.DANHBA, dateBangKe.Value);
                                phimonuoc.TongCong = phimonuoc.SoTien - 50000;
                                if (_cPhiMoNuoc.Them(phimonuoc))
                                {
                                    if (_cTienDu.GetTienDu(hoadon.DANHBA) == 0)
                                    {
                                        TT_TienDu tiendu = _cTienDu.Get(hoadon.DANHBA);
                                        tiendu.ChoXuLy = false;
                                        _cTienDu.Sua(tiendu);
                                        _cTienDu.SubmitChanges();
                                        _cTienDu.Rollback();
                                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                                        this.Close();
                                    }
                                    else
                                    {
                                        _cTienDu.Rollback();
                                        MessageBox.Show("Lỗi Cập Nhật Chờ Xử Lý Tiền Dư, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    _cTienDu.Rollback();
                                    MessageBox.Show("Lỗi Thêm Phí Mở Nước, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                _cTienDu.Rollback();
                                MessageBox.Show("Lỗi Update Tiền Dư, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception)
                        {
                            _cTienDu.Rollback();
                            MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            _cTienDu.NullTransaction();
                        }
                    }
                    else
                        MessageBox.Show("Số tiền không đủ 50.000đ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateBangKe_ValueChanged(object sender, EventArgs e)
        {
            txtSoTien.Text = _cBangKe.GetSoTien(txtDanhBoSuaTien.Text.Trim().Replace(" ", ""), dateBangKe.Value).ToString() ;
        }

        private void txtDanhBoSuaTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBoSuaTien.Text.Trim().Replace(" ", "").Length == 11)
            {
                txtSoTienCu.Text = _cTienDu.GetTienDu(txtDanhBoSuaTien.Text.Trim().Replace(" ", "")).ToString();
            }
        }

        private void txtSoTienDieuChinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar)&&e.KeyChar!='-')
            e.Handled = true;
        }

        private void txtSoTienDieuChinh_TextChanged(object sender, EventArgs e)
        {
            if (txtSoTienDieuChinh.Text.Trim() != "-")
                txtSoTienMoi.Text = (int.Parse(txtSoTienCu.Text.Trim()) + int.Parse(txtSoTienDieuChinh.Text.Trim())).ToString();
        }
    }
}
