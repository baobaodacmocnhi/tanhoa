using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.DieuChinhBienDong;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmShowDCBD : Form
    {
        decimal _MaCTDCBD = 0;
        CDCBD _cDCBD = new CDCBD();
        CTDCBD _ctdcbd = null;

        public frmShowDCBD()
        {
            InitializeComponent();
        }

        public frmShowDCBD(decimal MaCTDCBD)
        {
            InitializeComponent();
            _MaCTDCBD = MaCTDCBD;
        }

        private void frmShowDCBD_Load(object sender, EventArgs e)
        {
            this.Location = new Point(70, 70);
            if (_cDCBD.getCTDCBDbyID(_MaCTDCBD) != null)
            {
                _ctdcbd = _cDCBD.getCTDCBDbyID(_MaCTDCBD);
                txtMaDon.Text = _ctdcbd.MaCTDCBD.ToString().Insert(_ctdcbd.MaCTDCBD.ToString().Length - 2, "-");
                txtHieuLucKy.Text = _ctdcbd.HieuLucKy;
                txtDanhBo.Text = _ctdcbd.DanhBo;
                txtHopDong.Text = _ctdcbd.HopDong;
                txtHoTen.Text = _ctdcbd.HoTen;
                txtDiaChi.Text = _ctdcbd.DiaChi;
                txtDot.Text = _ctdcbd.Dot;
                txtMSThue.Text = _ctdcbd.MSThue;
                txtGiaBieu.Text = _ctdcbd.GiaBieu;
                txtDinhMuc.Text = _ctdcbd.DinhMuc;
                txtSH.Text = _ctdcbd.SH;
                txtSX.Text = _ctdcbd.SX;
                txtDV.Text = _ctdcbd.DV;
                txtHCSN.Text = _ctdcbd.HCSN;
                ///
                txtHoTen_BD.Text = _ctdcbd.HoTen_BD;
                txtDiaChi_BD.Text = _ctdcbd.DiaChi_BD;
                txtMSThue_BD.Text = _ctdcbd.MSThue_BD;
                txtGiaBieu_BD.Text = _ctdcbd.GiaBieu_BD;
                txtDinhMuc_BD.Text = _ctdcbd.DinhMuc_BD;
                txtSH_BD.Text = _ctdcbd.SH_BD;
                txtSX_BD.Text = _ctdcbd.SX_BD;
                txtDV_BD.Text = _ctdcbd.DV_BD;
                txtHCSN_BD.Text = _ctdcbd.HCSN_BD;
                if (_ctdcbd.CatMSThue)
                    chkCatMSThue.Checked = true;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_ctdcbd != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["DCBD"].NewRow();

                dr["SoPhieu"] = _ctdcbd.MaCTDCBD.ToString().Insert(_ctdcbd.MaCTDCBD.ToString().Length - 2, "-");
                dr["ThongTin"] = _ctdcbd.ThongTin;
                dr["HieuLucKy"] = _ctdcbd.HieuLucKy;
                dr["Dot"] = _ctdcbd.Dot;
                ///Hiện tại xử lý mã số thuế như vậy
                if (chkCatMSThue.Checked)
                    dr["MSThue"] = "MST: Cắt MST";
                if (txtMSThue_BD.Text.Trim() != "")
                    dr["MSThue"] = "MST: " + _ctdcbd.MSThue_BD;
                dr["DanhBo"] = _ctdcbd.DanhBo.Insert(7, " ").Insert(4, " ");
                dr["HopDong"] = _ctdcbd.HopDong;
                dr["HoTen"] = _ctdcbd.HoTen;
                dr["DiaChi"] = _ctdcbd.DiaChi;
                dr["MaPhuongQuan"] = _ctdcbd.MaPhuongQuan;
                dr["GiaBieu"] = _ctdcbd.GiaBieu;
                dr["DinhMuc"] = _ctdcbd.DinhMuc;
                ///Biến Động
                dr["HoTenBD"] = _ctdcbd.HoTen_BD;
                dr["DiaChiBD"] = _ctdcbd.DiaChi_BD;
                dr["GiaBieuBD"] = _ctdcbd.GiaBieu_BD;
                dr["DinhMucBD"] = _ctdcbd.DinhMuc_BD;
                ///Ký Tên
                dr["ChucVu"] = _ctdcbd.ChucVu;
                dr["NguoiKy"] = _ctdcbd.NguoiKy;

                dsBaoCao.Tables["DCBD"].Rows.Add(dr);

                rptPhieuDCBDtest rpt = new rptPhieuDCBDtest();
                rpt.SetDataSource(dsBaoCao);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.ShowDialog();
            }
        }

        private void frmShowDCBD_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_ctdcbd != null)
            {
                ///Biến lưu Điều Chỉnh về gì (Họ Tên,Địa Chỉ,Định Mức,Giá Biểu,MSThuế)
                string ThongTin = "";
                ///Thêm CTDCBD
                _ctdcbd.DanhBo = txtDanhBo.Text.Trim();
                _ctdcbd.HopDong = txtHopDong.Text.Trim();
                _ctdcbd.HoTen = txtHoTen.Text.Trim();
                _ctdcbd.DiaChi = txtDiaChi.Text.Trim();
                _ctdcbd.MSThue = txtMSThue.Text.Trim();
                _ctdcbd.GiaBieu = txtGiaBieu.Text.Trim();
                _ctdcbd.DinhMuc = txtDinhMuc.Text.Trim();
                _ctdcbd.SH = txtSH.Text.Trim();
                _ctdcbd.SX = txtSX.Text.Trim();
                _ctdcbd.DV = txtDV.Text.Trim();
                _ctdcbd.HCSN = txtHCSN.Text.Trim();
                ///Họ Tên
                if (txtHoTen_BD.Text.Trim() != "")
                {
                    ThongTin += "Họ Tên. ";
                    _ctdcbd.HoTen_BD = txtHoTen_BD.Text.Trim();
                }
                ///Địa Chỉ
                if (txtDiaChi_BD.Text.Trim() != "")
                {
                    ThongTin += "Địa Chỉ. ";
                    _ctdcbd.DiaChi_BD = txtDiaChi_BD.Text.Trim();
                }
                ///Mã Số Thuế
                if (txtMSThue_BD.Text.Trim() != "")
                {
                    ThongTin += "MST. ";
                    _ctdcbd.MSThue_BD = txtMSThue_BD.Text.Trim();
                }
                if (chkCatMSThue.Checked)
                {
                    ThongTin += "MST. ";
                    _ctdcbd.CatMSThue = true;
                }
                ///Giá Biểu
                if (txtGiaBieu_BD.Text.Trim() != "")
                {
                    ThongTin += "GB. ";
                    _ctdcbd.GiaBieu_BD = txtGiaBieu_BD.Text.Trim();
                }
                ///Định Mức
                if (txtDinhMuc_BD.Text.Trim() != "")
                {
                    ThongTin += "ĐM. ";
                    _ctdcbd.DinhMuc_BD = txtDinhMuc_BD.Text.Trim();
                }
                ///SH
                if (txtSH_BD.Text.Trim() != "")
                    _ctdcbd.SH_BD = txtSH_BD.Text.Trim();
                ///SX
                if (txtSX_BD.Text.Trim() != "")
                    _ctdcbd.SX_BD = txtSX_BD.Text.Trim();
                ///DV
                if (txtDV_BD.Text.Trim() != "")
                    _ctdcbd.DV_BD = txtDV_BD.Text.Trim();
                ///HCSN
                if (txtHCSN_BD.Text.Trim() != "")
                    _ctdcbd.HCSN_BD = txtHCSN_BD.Text.Trim();

                _ctdcbd.ThongTin = ThongTin;
                _ctdcbd.HieuLucKy = txtHieuLucKy.Text.Trim();

                 if (_cDCBD.SuaCTDCBD(_ctdcbd))
                    MessageBox.Show("Sửa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
