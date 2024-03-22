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
using System.Transactions;
using ThuTien.DAL.DongNuoc;

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
        CDongNuoc _cDongNuoc = new CDongNuoc();

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

            //if (CNguoiDung.MaND == 0 || CNguoiDung.Doi == true)
            //    btnSua.Enabled = true;
            //else
            //    btnSua.Enabled = false;
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
                    if ((string.IsNullOrEmpty(txtDanhBoCTB.Text.Trim().Replace(" ", "")) || txtDanhBoCTB.Text.Trim().Replace(" ", "").Length == 11) && int.Parse(txtSoTienChuyen.Text.Trim()) > 0 && int.Parse(txtSoTienCTA.Text.Trim()) > 0)
                        using (var scope = new TransactionScope())
                        {
                            if (_cTienDu.Update(txtDanhBoCTA.Text.Trim().Replace(" ", ""), int.Parse(txtSoTienChuyen.Text.Trim()) * -1, "Chuyển Tiền", txtGhiChuChuyen.Text.Trim(), txtDanhBoCTB.Text.Trim().Replace(" ", "")))
                                if (_cTienDu.Update(txtDanhBoCTB.Text.Trim().Replace(" ", ""), int.Parse(txtSoTienChuyen.Text.Trim()), "Nhận Tiền", txtGhiChuChuyen.Text.Trim(), txtDanhBoCTA.Text.Trim().Replace(" ", "")))
                                {
                                    scope.Complete();
                                    scope.Dispose();
                                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
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
                    using (var scope = new TransactionScope())
                    {
                        if (_cTienDu.Update(txtDanhBoSuaTien.Text.Trim().Replace(" ", ""), int.Parse(txtSoTienCu.Text.Trim()) * -1, "Điều Chỉnh Tiền", txtGhiChuSua.Text.Trim()))
                            if (_cTienDu.Update(txtDanhBoSuaTien.Text.Trim().Replace(" ", ""), int.Parse(txtSoTienMoi.Text.Trim()), "Điều Chỉnh Tiền", txtGhiChuSua.Text.Trim()))
                            {
                                scope.Complete();
                                scope.Dispose();
                                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                    }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnChuyenPhiMoNuoc_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {
                if (MessageBox.Show("Bạn có chắc chắn Chuyển Phí Mở Nước?", "Xác nhận sửa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (chkKhongBangKe.Checked == false)
                        if (txtSoTien.Text.Trim() == "" || int.Parse(txtSoTien.Text.Trim()) == 0)
                        {
                            MessageBox.Show("Chưa chọn Ngày Bảng Kê", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    TT_KQDongNuoc kqdongnuoc = _cDongNuoc.GetKQDongNuocByDanhBo_Last(txtDanhBoSuaTien.Text.Trim().Replace(" ", ""));
                    if (kqdongnuoc != null)
                    {
                        if (kqdongnuoc.DongPhi == false)
                        {
                            if (int.Parse(txtSoTienCu.Text.Trim()) < kqdongnuoc.PhiMoNuoc.Value)
                            {
                                MessageBox.Show("Số Tiền Không Đủ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            using (var scope = new TransactionScope())
                            {
                                if (_cTienDu.Update(txtDanhBoSuaTien.Text.Trim().Replace(" ", ""), -kqdongnuoc.PhiMoNuoc.Value, "Điều Chỉnh Tiền", "Thêm Chuyển Phí Mở Nước", dateLap.Value))
                                {
                                    HOADON hoadon = _cHoaDon.GetMoiNhat(txtDanhBoSuaTien.Text.Trim().Replace(" ", ""));

                                    TT_PhiMoNuoc phimonuoc = new TT_PhiMoNuoc();
                                    phimonuoc.MLT = hoadon.MALOTRINH;
                                    phimonuoc.DanhBo = hoadon.DANHBA;
                                    phimonuoc.HoTen = hoadon.TENKH;
                                    phimonuoc.DiaChi = hoadon.SO + " " + hoadon.DUONG;
                                    if (chkKhongBangKe.Checked == false)
                                    {
                                        phimonuoc.NgayBK = dateBangKe.Value;
                                        phimonuoc.SoTien = _cBangKe.getSoTien(hoadon.DANHBA, dateBangKe.Value);
                                        phimonuoc.SoTK = _cBangKe.GetSoTK(hoadon.DANHBA, dateBangKe.Value);
                                    }
                                    phimonuoc.TongCong = phimonuoc.SoTien - kqdongnuoc.PhiMoNuoc.Value;
                                    phimonuoc.PhiMoNuoc = kqdongnuoc.PhiMoNuoc;
                                    phimonuoc.MaKQDN = kqdongnuoc.MaKQDN;
                                    if (_cPhiMoNuoc.Them(phimonuoc, dateLap.Value))
                                    {
                                        if (_cTienDu.LinQ_ExecuteNonQuery("update TT_TienDu set ChoXuLy=0 where DanhBo='" + hoadon.DANHBA + "'"))
                                        {
                                            kqdongnuoc.DongPhi = true;
                                            kqdongnuoc.ChuyenKhoan = true;
                                            kqdongnuoc.NgayDongPhi = dateLap.Value;
                                            if (_cDongNuoc.SuaKQ(kqdongnuoc))
                                            //if (_cDongNuoc.LinQ_ExecuteNonQuery("update TT_KQDongNuoc set DongPhi=1,ChuyenKhoan=1,NgayDongPhi=getdate() where MaKQDN=" + kqdongnuoc.MaKQDN))
                                            {
                                                scope.Complete();
                                                scope.Dispose();
                                                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                this.Close();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                            MessageBox.Show("Đóng Phí rồi, " + kqdongnuoc.NgayDongPhi.Value.ToString("dd/MM/yyyy"), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Không có Kết Quả Đóng Nước", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dateBangKe_ValueChanged(object sender, EventArgs e)
        {
            txtSoTien.Text = _cBangKe.getSoTien(txtDanhBoSuaTien.Text.Trim().Replace(" ", ""), dateBangKe.Value).ToString();
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
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != '-')
                e.Handled = true;
        }

        private void txtSoTienDieuChinh_TextChanged(object sender, EventArgs e)
        {
            if (txtSoTienDieuChinh.Text.Trim() != "-")
                txtSoTienMoi.Text = (int.Parse(txtSoTienCu.Text.Trim()) + int.Parse(txtSoTienDieuChinh.Text.Trim())).ToString();
        }
    }
}
