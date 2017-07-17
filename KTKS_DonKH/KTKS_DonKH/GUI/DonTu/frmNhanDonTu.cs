using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.DonTu;
using KTKS_DonKH.DAL;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.GUI.DonTu
{
    public partial class frmNhanDonTu : Form
    {
        string _mnu = "mnuNhanDonTu";
        LinQ.DonTu _dontu = null;
        HOADON _hoadon = null;
        CDonTu _cDonTu = new CDonTu();
        CNhomDon _cNhomDon = new CNhomDon();
        CThuTien _cThuTien = new CThuTien();
        CDocSo _cDocSo = new CDocSo();

        public frmNhanDonTu()
        {
            InitializeComponent();
        }

        private void frmDonTu_Load(object sender, EventArgs e)
        {
            DataTable dt = _cNhomDon.GetDS("DieuChinh");
            chkcmbDieuChinh.Properties.DataSource = dt;
            chkcmbDieuChinh.Properties.ValueMember = "ID";
            chkcmbDieuChinh.Properties.DisplayMember = "Name";
            chkcmbDieuChinh.Properties.DropDownRows = dt.Rows.Count + 1;

            dt = _cNhomDon.GetDS("KhieuNai");
            chkcmbKhieuNai.Properties.DataSource = dt;
            chkcmbKhieuNai.Properties.ValueMember = "ID";
            chkcmbKhieuNai.Properties.DisplayMember = "Name";
            chkcmbKhieuNai.Properties.DropDownRows = dt.Rows.Count + 1;

            dt = _cNhomDon.GetDS("DHN");
            chkcmbDHN.Properties.DataSource = dt;
            chkcmbDHN.Properties.ValueMember = "ID";
            chkcmbDHN.Properties.DisplayMember = "Name";
            chkcmbDHN.Properties.DropDownRows = dt.Rows.Count + 1;
        }

        public void LoadTTKH(HOADON hoadon)
        {
            txtDanhBo.Text = hoadon.DANHBA.Insert(7," ").Insert(4," ");
            txtHopDong.Text = hoadon.HOPDONG;
            txtHoTen.Text = hoadon.TENKH;
            txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG + _cDocSo.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
            txtGiaBieu.Text = hoadon.GB.ToString();
            txtDinhMuc.Text = hoadon.DM.ToString();
        }

        public void Clear()
        {
            txtSoCongVan.Text = "";
            txtTongDB.Text = "1";
            txtMaDon.Text = "";

            for (int i = 0; i < chkcmbDieuChinh.Properties.Items.Count; i++)
            {
                chkcmbDieuChinh.Properties.Items[i].CheckState = CheckState.Unchecked;
            }
            for (int i = 0; i < chkcmbKhieuNai.Properties.Items.Count; i++)
            {
                chkcmbKhieuNai.Properties.Items[i].CheckState = CheckState.Unchecked;
            }
            for (int i = 0; i < chkcmbDHN.Properties.Items.Count; i++)
            {
                chkcmbDHN.Properties.Items[i].CheckState = CheckState.Unchecked;
            }
            txtSoNK.Text = "";
            txtHieuLucKy.Text = "";
            txtNoiDung.Text = "";
            txtVanDeKhac.Text = "";

            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtDienThoai.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";

            chkCT_HoaDon.Checked = false;
            chkCT_HK_KT3.Checked = false;
            chkCT_STT_GXNTT.Checked = false;
            chkCT_HDTN_CQN.Checked = false;
            chkCT_GC_SDSN.Checked = false;
            chkCT_GXN2SN.Checked = false;
            chkCT_GDKKD.Checked = false;
            chkCT_GCNDTDHN.Checked = false;

            _dontu = null;
            _hoadon = null;
        }
        private void chkcmbDieuChinh_EditValueChanged(object sender, EventArgs e)
        {
            if (chkcmbDieuChinh.Properties.Items.Count > 0)
            {
                int count = 0;
                for (int i = 0; i < chkcmbDieuChinh.Properties.Items.Count; i++)
                {
                    if (chkcmbDieuChinh.Properties.Items[i].CheckState == CheckState.Checked && txtNoiDung.Text.Trim().Contains(chkcmbDieuChinh.Properties.Items[i].ToString()) == false)
                    {
                        if (txtNoiDung.Text.Trim() == "")
                            txtNoiDung.Text = chkcmbDieuChinh.Properties.Items[i].ToString();
                        else
                            txtNoiDung.Text += ", " + chkcmbDieuChinh.Properties.Items[i].ToString();
                    }
                    else
                        if (chkcmbDieuChinh.Properties.Items[i].CheckState == CheckState.Unchecked && txtNoiDung.Text.Trim().Contains(chkcmbDieuChinh.Properties.Items[i].ToString()) == true)
                        {
                            txtNoiDung.Text = txtNoiDung.Text.Replace(", " + chkcmbDieuChinh.Properties.Items[i].ToString(), "");
                            txtNoiDung.Text = txtNoiDung.Text.Replace(chkcmbDieuChinh.Properties.Items[i].ToString() + ", ", "");
                            txtNoiDung.Text = txtNoiDung.Text.Replace(chkcmbDieuChinh.Properties.Items[i].ToString(), "");
                        }
                    if (chkcmbDieuChinh.Properties.Items[i].CheckState == CheckState.Checked && (chkcmbDieuChinh.Properties.Items[i].ToString() == "Cấp định mức nước" || chkcmbDieuChinh.Properties.Items[i].ToString() == "Cắt chuyển định mức nước"))
                        count++;
                }
                if (count != 0)
                    panel1.Visible = true;
                else
                    panel1.Visible = false;
            }
        }

        private void chkcmbKhieuNai_EditValueChanged(object sender, EventArgs e)
        {
            if (chkcmbKhieuNai.Properties.Items.Count > 0)
            {
                for (int i = 0; i < chkcmbKhieuNai.Properties.Items.Count; i++)
                    if (chkcmbKhieuNai.Properties.Items[i].CheckState == CheckState.Checked && txtNoiDung.Text.Trim().Contains(chkcmbKhieuNai.Properties.Items[i].ToString()) == false)
                    {
                        if (txtNoiDung.Text.Trim() == "")
                            txtNoiDung.Text = chkcmbKhieuNai.Properties.Items[i].ToString();
                        else
                            txtNoiDung.Text += ", " + chkcmbKhieuNai.Properties.Items[i].ToString();
                    }
                    else
                        if (chkcmbKhieuNai.Properties.Items[i].CheckState == CheckState.Unchecked && txtNoiDung.Text.Trim().Contains(chkcmbKhieuNai.Properties.Items[i].ToString()) == true)
                        {
                            txtNoiDung.Text = txtNoiDung.Text.Replace(", " + chkcmbKhieuNai.Properties.Items[i].ToString(), "");
                            txtNoiDung.Text = txtNoiDung.Text.Replace(chkcmbKhieuNai.Properties.Items[i].ToString() + ", ", "");
                            txtNoiDung.Text = txtNoiDung.Text.Replace(chkcmbKhieuNai.Properties.Items[i].ToString(), "");
                        }
            }
        }

        private void chkcmbDHN_EditValueChanged(object sender, EventArgs e)
        {
            if (chkcmbDHN.Properties.Items.Count > 0)
            {
                for (int i = 0; i < chkcmbDHN.Properties.Items.Count; i++)
                    if (chkcmbDHN.Properties.Items[i].CheckState == CheckState.Checked && txtNoiDung.Text.Trim().Contains(chkcmbDHN.Properties.Items[i].ToString()) == false)
                    {
                        if (txtNoiDung.Text.Trim() == "")
                            txtNoiDung.Text = chkcmbDHN.Properties.Items[i].ToString();
                        else
                            txtNoiDung.Text += ", " + chkcmbDHN.Properties.Items[i].ToString();
                    }
                    else
                        if (chkcmbDHN.Properties.Items[i].CheckState == CheckState.Unchecked && txtNoiDung.Text.Trim().Contains(chkcmbDHN.Properties.Items[i].ToString()) == true)
                        {
                            txtNoiDung.Text = txtNoiDung.Text.Replace(", " + chkcmbDHN.Properties.Items[i].ToString(), "");
                            txtNoiDung.Text = txtNoiDung.Text.Replace(chkcmbDHN.Properties.Items[i].ToString() + ", ", "");
                            txtNoiDung.Text = txtNoiDung.Text.Replace(chkcmbDHN.Properties.Items[i].ToString(), "");
                        }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    LinQ.DonTu entity = new LinQ.DonTu();
                    if (txtSoCongVan.Text.Trim() != "")
                    {
                        entity.SoCongVan = txtSoCongVan.Text.Trim();
                        entity.TongDB = int.Parse(txtTongDB.Text.Trim());
                    }
                    else
                    {
                        entity.DanhBo = txtDanhBo.Text.Trim().Replace(" ", "");
                        entity.HopDong = txtHopDong.Text.Trim();
                        entity.DienThoai = txtDienThoai.Text.Trim();
                        entity.HoTen = txtHoTen.Text.Trim();
                        entity.DiaChi = txtDiaChi.Text.Trim();
                        if(txtGiaBieu.Text.Trim()!="")
                        entity.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                        if(txtDinhMuc.Text.Trim()!="")
                        entity.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                        if (_hoadon != null)
                        {
                            entity.Dot = _hoadon.DOT;
                            entity.Ky = _hoadon.KY;
                            entity.Nam = _hoadon.NAM;
                        }
                    }
                    if (txtSoNK.Text.Trim() != "")
                    {
                        entity.SoNK = int.Parse(txtSoNK.Text.Trim());
                        entity.HieuLucKy = txtHieuLucKy.Text.Trim();
                    }
                    ///
                    entity.ID_NhomDon = "";
                    for (int i = 0; i < chkcmbDieuChinh.Properties.Items.Count; i++)
                        if (chkcmbDieuChinh.Properties.Items[i].CheckState == CheckState.Checked)
                        {
                            if (entity.ID_NhomDon == "")
                                entity.ID_NhomDon = chkcmbDieuChinh.Properties.Items[i].Value.ToString();
                            else
                                entity.ID_NhomDon += "," + chkcmbDieuChinh.Properties.Items[i].Value.ToString();
                        }
                    for (int i = 0; i < chkcmbKhieuNai.Properties.Items.Count; i++)
                        if (chkcmbKhieuNai.Properties.Items[i].CheckState == CheckState.Checked)
                        {
                            if (entity.ID_NhomDon == "")
                                entity.ID_NhomDon = chkcmbKhieuNai.Properties.Items[i].Value.ToString();
                            else
                                entity.ID_NhomDon += "," + chkcmbKhieuNai.Properties.Items[i].Value.ToString();
                        }
                    for (int i = 0; i < chkcmbDHN.Properties.Items.Count; i++)
                        if (chkcmbDHN.Properties.Items[i].CheckState == CheckState.Checked)
                        {
                            if (entity.ID_NhomDon == "")
                                entity.ID_NhomDon = chkcmbDHN.Properties.Items[i].Value.ToString();
                            else
                                entity.ID_NhomDon += "," + chkcmbDHN.Properties.Items[i].Value.ToString();
                        }
                    entity.Name_NhomDon = txtNoiDung.Text.Trim();
                    if (txtVanDeKhac.Text.Trim() != "")
                        entity.VanDeKhac = txtVanDeKhac.Text.Trim();
                    ///
                    if (chkCT_HoaDon.Checked)
                        entity.CT_HoaDon = true;

                    if (chkCT_HK_KT3.Checked)
                        entity.CT_HK_KT3 = true;

                    if (chkCT_STT_GXNTT.Checked)
                        entity.CT_STT_GXNTT = true;

                    if (chkCT_HDTN_CQN.Checked)
                        entity.CT_HDTN_CQN = true;

                    if (chkCT_GC_SDSN.Checked)
                        entity.CT_GC_SDSN = true;

                    if (chkCT_GXN2SN.Checked)
                        entity.CT_GXN2SN = true;

                    if (chkCT_GDKKD.Checked)
                        entity.CT_GDKKD = true;

                    if (chkCT_GCNDTDHN.Checked)
                        entity.CT_GCNDTDHN = true;
                    ///
                    if (_cDonTu.Them(entity))
                    {
                        Clear();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                try
                {

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
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                try
                {

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtSoNK_Leave(object sender, EventArgs e)
        {
            if (txtSoNK.Text.Trim() != "")
                txtDM.Text = (int.Parse(txtSoNK.Text.Trim()) * 4).ToString();
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtDanhBo.Text.Trim().Replace(" ", "").Length == 11 && e.KeyChar == 13)
            {
                _hoadon = _cThuTien.GetMoiNhat(txtDanhBo.Text.Trim().Replace(" ", ""));
                if (_hoadon != null)
                {
                    LoadTTKH(_hoadon);
                }
                else
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
