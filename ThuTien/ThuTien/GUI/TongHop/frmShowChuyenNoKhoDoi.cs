using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;
using ThuTien.DAL.TongHop;
using ThuTien.DAL.Doi;

namespace ThuTien.GUI.TongHop
{
    public partial class frmShowChuyenNoKhoDoi : Form
    {
        string _DanhBo;
        decimal _MaCNKD;
        int _MaHD;
        TT_ChuyenNoKhoDoi _cnkd = null;
        PhieuCHDB _ycch = null;
        TT_CTChuyenNoKhoDoi _ctcnkd = null;
        CChuyenNoKhoDoi _cCNKD = new CChuyenNoKhoDoi();
        CHoaDon _cHoaDon = new CHoaDon();

        public frmShowChuyenNoKhoDoi(string DanhBo, decimal MaCNKD,int MaHD)
        {
            InitializeComponent();
            _DanhBo = DanhBo;
            _MaCNKD = MaCNKD;
            _MaHD = MaHD;
        }

        private void frmShowChuyenNoKhoDoi_Load(object sender, EventArgs e)
        {
            if (CNguoiDung.Doi)
            {
                lbNgayLap.Visible = true;
                dateLap.Visible = true;
            }
            else
            {
                lbNgayLap.Visible = false;
                dateLap.Visible = false;
            }
            Location = new Point(100, 100);

            LoadForm();
        }

        public void LoadForm()
        {
            _cnkd = _cCNKD.Get(_MaCNKD);
            _ctcnkd = _cCNKD.GetCT(_MaHD);

            if (_cnkd.SoPhieuYCCHDB != null)
            {
                txtSoPhieu.Text = _cnkd.SoPhieuYCCHDB.ToString().Insert(_cnkd.SoPhieuYCCHDB.ToString().Length - 2, "-");
                dateYCCHDB.Value = _cnkd.NgayYCCHDB.Value;
                txtLyDo.Text = _cnkd.LyDo;
            }
            txtDanhBo.Text = _cnkd.DanhBo;
            txtHoTen.Text = _cnkd.HoTen;
            txtDiaChi.Text = _cnkd.DiaChi;
            dateLap.Value = _ctcnkd.CreateDate.Value;
        }

        private void txtSoPhieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSoPhieu.Text.Trim()) && e.KeyChar == 13)
            {
                _ycch = _cCNKD.GetYeuCauCHDB(decimal.Parse(txtSoPhieu.Text.Trim().Replace("-", "")));

                txtSoPhieu.Text = _ycch.MaYCCHDB.ToString().Insert(_ycch.MaYCCHDB.ToString().Length - 2, "-");
                dateYCCHDB.Value = _ycch.CreateDate.Value;
                txtLyDo.Text = _ycch.LyDo;
                txtDanhBo.Text = _ycch.DanhBo;
                txtHoTen.Text = _ycch.HoTen;
                txtDiaChi.Text = _ycch.DiaChi;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuChuyenNoKhoDoi", "Sua"))
            {
                if (_ctcnkd != null && _ycch == null)
                {
                    _ctcnkd.CreateDate = dateLap.Value;
                    if (_cCNKD.SuaCT(_ctcnkd))
                    {
                        HOADON hoadon = _cHoaDon.Get(_MaHD);
                        hoadon.NGAYGIAITRACH = _ctcnkd.CreateDate;
                        _cHoaDon.Sua(hoadon);
                        _cnkd.CreateDate = _ctcnkd.CreateDate;
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                }
                if (_ycch != null)
                    try
                    {
                        _cnkd.SoPhieuYCCHDB = _ycch.MaYCCHDB;
                        _cnkd.NgayYCCHDB = dateYCCHDB.Value;
                        _cnkd.LyDo = _ycch.LyDo;
                        _cnkd.DanhBo = _ycch.DanhBo;
                        _cnkd.HoTen = _ycch.HoTen;
                        _cnkd.DiaChi = _ycch.DiaChi;
                       
                        if (_cCNKD.Sua(_cnkd))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            this.Close();
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen("mnuChuyenNoKhoDoi", "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    _cnkd.SoPhieuYCCHDB = null;
                    _cnkd.NgayYCCHDB = null;
                    _cnkd.LyDo = null;
                    _cnkd.DanhBo = null;
                    _cnkd.HoTen = null;
                    _cnkd.DiaChi = null;

                    if (_cCNKD.Sua(_cnkd))
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
