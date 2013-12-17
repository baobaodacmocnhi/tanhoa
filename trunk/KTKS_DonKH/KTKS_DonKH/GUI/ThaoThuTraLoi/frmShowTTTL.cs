using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.ThaoThuTraLoi;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.ThaoThuTraLoi;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.ThaoThuTraLoi
{
    public partial class frmShowTTTL : Form
    {
        decimal _MaCTTTTL = 0;
        CTTTL _cTTTL = new CTTTL();
        CTTTTL _cttttl = null;

        public frmShowTTTL()
        {
            InitializeComponent();
        }

        public frmShowTTTL(decimal MaCTTTTL)
        {
            InitializeComponent();
            _MaCTTTTL = MaCTTTTL;
        }

        private void frmShowTTTL_Load(object sender, EventArgs e)
        {
            this.Location = new Point(70, 70);
            if (_cTTTL.getCTTTTLbyID(_MaCTTTTL) != null)
            {
                _cttttl = _cTTTL.getCTTTTLbyID(_MaCTTTTL);
                txtMaDon.Text = _cttttl.TTTL.MaDon.Value.ToString().Insert(_cttttl.TTTL.MaDon.Value.ToString().Length - 2, "-");
                txtDanhBo.Text = _cttttl.DanhBo;
                txtHopDong.Text = _cttttl.HopDong;
                txtHoTen.Text = _cttttl.HoTen;
                txtDiaChi.Text = _cttttl.DiaChi;
                txtGiaBieu.Text = _cttttl.GiaBieu;
                txtDinhMuc.Text = _cttttl.DinhMuc;
                txtVeViec.Text = _cttttl.VeViec;
                txtNoiDung.Text = _cttttl.NoiDung;
                txtNoiNhan.Text = _cttttl.NoiNhan;
                if (_cttttl.GiamNuocXaBo)
                    chkGiamNuocXaBo.Checked = true;
                if (_cttttl.KiemDinhDHN_Dung)
                    chkKiemDinhDHN_Dung.Checked = true;
                if (_cttttl.KiemDinhDHN_Sai)
                    chkKiemDinhDHN_Sai.Checked = true;
                if (_cttttl.ThayDHN)
                    chkThayDHN.Checked = true;
                if (_cttttl.DieuChinh_GB_DM)
                    chkDieuChinh_GB_DM.Checked = true;
                if (_cttttl.ThuMoi)
                    chkThuMoi.Checked = true;
                if (_cttttl.ThuBao)
                    chkThuBao.Checked = true;
            }
            
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_cttttl != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["ThaoThuTraLoi"].NewRow();

                dr["SoPhieu"] = _cttttl.MaCTTTTL.ToString().Insert(_cttttl.MaCTTTTL.ToString().Length - 2, "-");
                dr["HoTen"] = _cttttl.HoTen;
                dr["DiaChi"] = _cttttl.DiaChi;
                dr["DanhBo"] = _cttttl.DanhBo;
                dr["HopDong"] = _cttttl.HopDong;
                dr["GiaBieu"] = _cttttl.GiaBieu;
                dr["DinhMuc"] = _cttttl.DinhMuc;
                dr["NgayNhanDon"] = _cttttl.TTTL.DonKH.CreateDate;
                dr["VeViec"] = _cttttl.VeViec;
                dr["NoiDung"] = _cttttl.NoiDung;
                dr["NoiNhan"] = _cttttl.NoiNhan;
                dr["ChucVu"] = _cttttl.ChucVu;
                dr["NguoiKy"] = _cttttl.NguoiKy;

                dsBaoCao.Tables["ThaoThuTraLoi"].Rows.Add(dr);

                rptThaoThuTraLoi rpt = new rptThaoThuTraLoi();
                rpt.SetDataSource(dsBaoCao);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.ShowDialog();
            }
        }

        private void frmShowTTTL_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
