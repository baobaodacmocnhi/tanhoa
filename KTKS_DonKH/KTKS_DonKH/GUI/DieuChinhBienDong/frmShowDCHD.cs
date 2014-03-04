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
    public partial class frmShowDCHD : Form
    {
        decimal _MaCTDCHD = 0;
        CDCBD _cDCBD = new CDCBD();
        CTDCHD _ctdchd = null;

        public frmShowDCHD()
        {
            InitializeComponent();
        }

        public frmShowDCHD(decimal MaCTDCHD)
        {
            InitializeComponent();
            _MaCTDCHD = MaCTDCHD;
        }

        private void frmShowDCHD_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmShowDCHD_Load(object sender, EventArgs e)
        {
            if (_cDCBD.getCTDCHDbyID(_MaCTDCHD) != null)
            {
                this.Location = new Point(70, 70);
                _ctdchd = _cDCBD.getCTDCHDbyID(_MaCTDCHD);
                txtMaDon.Text = _ctdchd.MaCTDCHD.ToString().Insert(_ctdchd.MaCTDCHD.ToString().Length - 2, "-");
                txtSoVB.Text = _ctdchd.SoVB;
                dateNgayKy.Value = _ctdchd.NgayKy.Value;
                txtKyHD.Text = _ctdchd.KyHD;
                txtSoHD.Text = _ctdchd.SoHD;
                txtDanhBo.Text = _ctdchd.DanhBo;
                txtHoTen.Text = _ctdchd.HoTen;
                ///
                txtGiaBieu_Cu.Text = _ctdchd.GiaBieu.Value.ToString();
                txtDinhMuc_Cu.Text = _ctdchd.DinhMuc.Value.ToString();
                txtTieuThu_Cu.Text = _ctdchd.TieuThu.Value.ToString();
                txtGiaBieu_Moi.Text = _ctdchd.GiaBieu_BD.Value.ToString();
                txtDinhMuc_Moi.Text = _ctdchd.DinhMuc_BD.Value.ToString();
                txtTieuThu_Moi.Text = _ctdchd.TieuThu_BD.Value.ToString();
                ///
                txtTieuThu_Start.Text = _ctdchd.TieuThu.Value.ToString();
                txtTienNuoc_Start.Text = _ctdchd.TienNuoc_Start.Value.ToString();
                txtThueGTGT_Start.Text = _ctdchd.ThueGTGT_Start.Value.ToString();
                txtPhiBVMT_Start.Text = _ctdchd.PhiBVMT_Start.Value.ToString();
                txtTongCong_Start.Text = _ctdchd.TongCong_Start.Value.ToString();
                ///
                lbTangGiam.Text = _ctdchd.TangGiam;
                txtTieuThu_BD.Text = (_ctdchd.TieuThu_BD - _ctdchd.TieuThu).Value.ToString();
                txtTienNuoc_BD.Text = _ctdchd.TienNuoc_BD.Value.ToString();
                txtThueGTGT_BD.Text = _ctdchd.ThueGTGT_BD.Value.ToString();
                txtPhiBVMT_BD.Text = _ctdchd.PhiBVMT_BD.Value.ToString();
                txtTongCong_BD.Text = _ctdchd.TongCong_BD.Value.ToString();
                ///
                txtTieuThu_End.Text = _ctdchd.TieuThu_BD.Value.ToString();
                txtTienNuoc_End.Text = _ctdchd.TienNuoc_End.Value.ToString();
                txtThueGTGT_End.Text = _ctdchd.ThueGTGT_End.Value.ToString();
                txtPhiBVMT_End.Text = _ctdchd.PhiBVMT_End.Value.ToString();
                txtTongCong_End.Text = _ctdchd.TongCong_End.Value.ToString();
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_ctdchd != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["DCHD"].NewRow();

                dr["SoPhieu"] = _ctdchd.MaCTDCHD.ToString().Insert(_ctdchd.MaCTDCHD.ToString().Length - 2, "-");
                dr["DanhBo"] = _ctdchd.DanhBo;
                dr["HoTen"] = _ctdchd.HoTen;
                dr["SoVB"] = _ctdchd.SoVB;
                dr["NgayKy"] = _ctdchd.NgayKy.Value.ToString("dd/MM/yyyy");
                dr["KyHD"] = _ctdchd.KyHD;
                dr["SoHD"] = _ctdchd.SoHD;
                ///
                dr["TieuThuStart"] = _ctdchd.TieuThu;
                dr["TienNuocStart"] = _ctdchd.TienNuoc_Start;
                dr["ThueGTGTStart"] = _ctdchd.ThueGTGT_Start;
                dr["PhiBVMTStart"] = _ctdchd.PhiBVMT_Start;
                dr["TongCongStart"] = _ctdchd.TongCong_Start;
                ///
                dr["TangGiam"] = _ctdchd.TangGiam;
                ///
                dr["TieuThuBD"] = _ctdchd.TieuThu_BD - _ctdchd.TieuThu;
                dr["TienNuocBD"] = _ctdchd.TienNuoc_BD;
                dr["ThueGTGTBD"] = _ctdchd.ThueGTGT_BD;
                dr["PhiBVMTBD"] = _ctdchd.PhiBVMT_BD;
                dr["TongCongBD"] = _ctdchd.TongCong_BD;
                ///
                dr["TieuThuEnd"] = _ctdchd.TieuThu_BD;
                dr["TienNuocEnd"] = _ctdchd.TienNuoc_End;
                dr["ThueGTGTEnd"] = _ctdchd.ThueGTGT_End;
                dr["PhiBVMTEnd"] = _ctdchd.PhiBVMT_End;
                dr["TongCongEnd"] = _ctdchd.TongCong_End;

                dr["ChucVu"] = _ctdchd.ChucVu;
                dr["NguoiKy"] = _ctdchd.NguoiKy;

                dsBaoCao.Tables["DCHD"].Rows.Add(dr);

                rptPhieuDCHD rpt = new rptPhieuDCHD();
                rpt.SetDataSource(dsBaoCao);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.ShowDialog();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_ctdchd != null)
            {
                _ctdchd.DanhBo = txtDanhBo.Text.Trim();
                _ctdchd.HoTen = txtHoTen.Text.Trim();
                _ctdchd.SoVB = txtSoVB.Text.Trim();
                _ctdchd.NgayKy = dateNgayKy.Value;
                _ctdchd.KyHD = txtKyHD.Text.Trim();
                _ctdchd.SoHD = txtSoHD.Text.Trim();
                ///
                _ctdchd.GiaBieu = int.Parse(txtGiaBieu_Cu.Text.Trim());
                _ctdchd.DinhMuc = int.Parse(txtDinhMuc_Cu.Text.Trim());
                _ctdchd.TieuThu = int.Parse(txtTieuThu_Cu.Text.Trim());
                ///
                _ctdchd.GiaBieu_BD = int.Parse(txtGiaBieu_Moi.Text.Trim());
                _ctdchd.DinhMuc_BD = int.Parse(txtDinhMuc_Moi.Text.Trim());
                _ctdchd.TieuThu_BD = int.Parse(txtTieuThu_Moi.Text.Trim());
                ///
                _ctdchd.TienNuoc_Start = int.Parse(txtTienNuoc_Start.Text.Trim());
                _ctdchd.ThueGTGT_Start = int.Parse(txtThueGTGT_Start.Text.Trim());
                _ctdchd.PhiBVMT_Start = int.Parse(txtPhiBVMT_Start.Text.Trim());
                _ctdchd.TongCong_Start = int.Parse(txtTongCong_Start.Text.Trim());
                ///
                _ctdchd.TienNuoc_BD = int.Parse(txtTienNuoc_BD.Text.Trim());
                _ctdchd.ThueGTGT_BD = int.Parse(txtThueGTGT_BD.Text.Trim());
                _ctdchd.PhiBVMT_BD = int.Parse(txtPhiBVMT_BD.Text.Trim());
                _ctdchd.TongCong_BD = int.Parse(txtTongCong_BD.Text.Trim());
                ///
                _ctdchd.TienNuoc_End = int.Parse(txtTienNuoc_End.Text.Trim());
                _ctdchd.ThueGTGT_End = int.Parse(txtThueGTGT_End.Text.Trim());
                _ctdchd.PhiBVMT_End = int.Parse(txtPhiBVMT_End.Text.Trim());
                _ctdchd.TongCong_End = int.Parse(txtTongCong_End.Text.Trim());

                if (_ctdchd.TienNuoc_End - _ctdchd.TienNuoc_Start == 0)
                    _ctdchd.TangGiam = "";
                else
                    if (_ctdchd.TienNuoc_End - _ctdchd.TienNuoc_Start > 0)
                        _ctdchd.TangGiam = "Tăng";
                    else
                        _ctdchd.TangGiam = "Giảm";

                if (_cDCBD.SuaCTDCHD(_ctdchd))
                    MessageBox.Show("Sửa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
