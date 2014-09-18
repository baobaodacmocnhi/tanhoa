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
    public partial class frmShowCatChuyenDM : Form
    {
        decimal _MaLSCT = 0;
        CChungTu _cChungTu = new CChungTu();
        LichSuChungTu _lichsuchungtu = null;
        CChiNhanh _cChiNhanh = new CChiNhanh();

        public frmShowCatChuyenDM()
        {
            InitializeComponent();
        }

        public frmShowCatChuyenDM(decimal MaLSCT)
        {
            InitializeComponent();
            _MaLSCT = MaLSCT;
        }

        private void frmShowCatChuyenDM_Load(object sender, EventArgs e)
        {
            cmbChiNhanh_Nhan.DataSource = _cChiNhanh.LoadDSChiNhanh(true);
            cmbChiNhanh_Nhan.DisplayMember = "TenCN";
            cmbChiNhanh_Nhan.ValueMember = "MaCN";
            cmbChiNhanh_Nhan.SelectedIndex = -1;

            if (_cChungTu.getLSCTbyID(_MaLSCT) != null)
            {
                _lichsuchungtu = _cChungTu.getLSCTbyID(_MaLSCT);
                if (_lichsuchungtu.CatDM.Value)
                {
                    txtDanhBo_Cat.Text = _lichsuchungtu.CatNK_DanhBo;
                    txtHoTen_Cat.Text = _lichsuchungtu.CatNK_HoTen;
                    txtDiaChi_Cat.Text = _lichsuchungtu.CatNK_DiaChi;
                    txtMaCT_Cat.Text = _lichsuchungtu.MaCT;
                    txtSoNK_Cat.Text = _lichsuchungtu.SoNKCat.Value.ToString();
                    ///
                    cmbChiNhanh_Nhan.SelectedValue = _lichsuchungtu.NhanNK_MaCN;
                    txtDanhBo_Nhan.Text = _lichsuchungtu.NhanNK_DanhBo;
                    txtHoTen_Nhan.Text = _lichsuchungtu.NhanNK_HoTen;
                    txtDiaChi_Nhan.Text = _lichsuchungtu.NhanNK_DiaChi;
                }
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_lichsuchungtu != null)
            {
                if (_lichsuchungtu.CatDM.Value)
                {
                    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                    DataRow dr = dsBaoCao.Tables["PhieuCatChuyenDM"].NewRow();

                    if (!string.IsNullOrEmpty(_lichsuchungtu.MaDon.ToString()) || !string.IsNullOrEmpty(_lichsuchungtu.MaDonTXL.ToString()))
                        if (_lichsuchungtu.ToXuLy)
                            dr["MaDon"] = "TXL" + _lichsuchungtu.MaDonTXL.ToString().Insert(_lichsuchungtu.MaDonTXL.ToString().Length - 2, "-");
                        else
                            dr["MaDon"] = _lichsuchungtu.MaDon.ToString().Insert(_lichsuchungtu.MaDon.ToString().Length - 2, "-");

                    dr["SoPhieu"] = _lichsuchungtu.SoPhieu.ToString().Insert(_lichsuchungtu.SoPhieu.ToString().Length - 2, "-");
                    dr["ChiNhanh"] = _cChiNhanh.getTenChiNhanhbyID(_lichsuchungtu.NhanNK_MaCN.Value);
                    if (!string.IsNullOrEmpty(_lichsuchungtu.NhanNK_DanhBo))
                        dr["DanhBoNhan"] = _lichsuchungtu.NhanNK_DanhBo.Insert(7, " ").Insert(4, " ");
                    dr["HoTenNhan"] = _lichsuchungtu.NhanNK_HoTen;
                    dr["DiaChiNhan"] = _lichsuchungtu.NhanNK_DiaChi;
                    if (!string.IsNullOrEmpty(_lichsuchungtu.CatNK_DanhBo))
                        dr["DanhBoCat"] = _lichsuchungtu.CatNK_DanhBo.Insert(7, " ").Insert(4, " ");
                    dr["HoTenCat"] = _lichsuchungtu.CatNK_HoTen;
                    dr["DiaChiCat"] = _lichsuchungtu.CatNK_DiaChi;
                    dr["SoNKCat"] = _lichsuchungtu.SoNKCat + " nhân khẩu (HK: " + _lichsuchungtu.MaCT + ")";

                    dr["ChucVu"] = _lichsuchungtu.ChucVu;
                    dr["NguoiKy"] = _lichsuchungtu.NguoiKy;

                    dsBaoCao.Tables["PhieuCatChuyenDM"].Rows.Add(dr);

                    //rptPhieuYCNhanDM rpt = new rptPhieuYCNhanDM();
                    //rpt.SetDataSource(dsBaoCao);
                    rptPhieuYCNhanDMx2 rpt = new rptPhieuYCNhanDMx2();
                    for (int j = 0; j < rpt.Subreports.Count; j++)
                    {
                        rpt.Subreports[j].SetDataSource(dsBaoCao);
                    }
                    frmBaoCao frm = new frmBaoCao(rpt);
                    frm.ShowDialog();
                }
            }
        }
    }
}
