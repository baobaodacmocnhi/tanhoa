using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.DieuChinhBienDong;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmShowNhanDM : Form
    {
        decimal _MaLSCT = 0;
        CChungTu _cChungTu = new CChungTu();
        LichSuChungTu _lichsuchungtu = null;
        CChiNhanh _cChiNhanh = new CChiNhanh();

        public frmShowNhanDM()
        {
            InitializeComponent();
        }

        public frmShowNhanDM(decimal MaLSCT)
        {
            InitializeComponent();
            _MaLSCT = MaLSCT;
        }

        private void frmShowNhanDM_Load(object sender, EventArgs e)
        {
            cmbChiNhanh.DataSource = _cChiNhanh.LoadDSChiNhanh(true);
            cmbChiNhanh.DisplayMember = "TenCN";
            cmbChiNhanh.ValueMember = "MaCN";
            cmbChiNhanh.SelectedIndex = -1;

            if (_cChungTu.getLSCTbyID(_MaLSCT) != null)
            {
                _lichsuchungtu = _cChungTu.getLSCTbyID(_MaLSCT);
                if (_lichsuchungtu.NhanDM.Value)
                {
                    txtDanhBo_Nhan.Text = _lichsuchungtu.NhanNK_DanhBo;
                    txtHoTen_Nhan.Text = _lichsuchungtu.NhanNK_HoTen;
                    txtDiaChi_Nhan.Text = _lichsuchungtu.NhanNK_DiaChi;
                    ///
                    cmbChiNhanh.SelectedValue = _lichsuchungtu.CatNK_MaCN;
                    txtDanhBo_Cat.Text = _lichsuchungtu.CatNK_DanhBo;
                    txtHoTen_Cat.Text = _lichsuchungtu.CatNK_HoTen;
                    txtDiaChi_Cat.Text = _lichsuchungtu.CatNK_DiaChi;
                    txtMaCT.Text = _lichsuchungtu.MaCT;
                    txtSoNKNhan.Text = _lichsuchungtu.SoNKNhan.Value.ToString();
                }
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_lichsuchungtu != null)
            {
                if (_lichsuchungtu.NhanDM.Value)
                {
                    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                    DataRow dr = dsBaoCao.Tables["PhieuCatChuyenDM"].NewRow();

                    dr["SoPhieu"] = _lichsuchungtu.SoPhieu.ToString().Insert(_lichsuchungtu.SoPhieu.ToString().Length - 2, "-");
                    dr["ChiNhanh"] = _cChiNhanh.getTenChiNhanhbyID(_lichsuchungtu.CatNK_MaCN.Value);
                    dr["DanhBoNhan"] = _lichsuchungtu.NhanNK_DanhBo;
                    dr["HoTenNhan"] = _lichsuchungtu.NhanNK_HoTen;
                    dr["DiaChiNhan"] = _lichsuchungtu.NhanNK_DiaChi;
                    dr["DanhBoCat"] = _lichsuchungtu.CatNK_DanhBo;
                    dr["HoTenCat"] = _lichsuchungtu.CatNK_HoTen;
                    dr["DiaChiCat"] = _lichsuchungtu.CatNK_DiaChi;
                    dr["SoNKCat"] = _lichsuchungtu.SoNKNhan + " nhân khẩu (HK: " + _lichsuchungtu.MaCT + ")";

                    dr["ChucVu"] = _lichsuchungtu.ChucVu;
                    dr["NguoiKy"] = _lichsuchungtu.NguoiKy;

                    dsBaoCao.Tables["PhieuCatChuyenDM"].Rows.Add(dr);

                    rptPhieuYCCatDM rpt = new rptPhieuYCCatDM();
                    rpt.SetDataSource(dsBaoCao);
                    frmBaoCao frm = new frmBaoCao(rpt);
                    frm.ShowDialog();
                }
            }
        }
    }
}
