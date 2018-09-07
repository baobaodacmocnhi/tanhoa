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
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.DonTu;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.DonTu
{
    public partial class frmNhanDonTu : Form
    {
        string _mnu = "mnuNhanDonTu";
        CDonTu _cDonTu = new CDonTu();
        CNhomDon _cNhomDon = new CNhomDon();
        CThuTien _cThuTien = new CThuTien();
        CDocSo _cDocSo = new CDocSo();

        LinQ.DonTu _dontu = null;
        HOADON _hoadon = null;
        int _MaDon = -1;

        public frmNhanDonTu()
        {
            InitializeComponent();
        }

        public frmNhanDonTu(int MaDon)
        {
            InitializeComponent();
            _MaDon = MaDon;
        }

        private void frmDonTu_Load(object sender, EventArgs e)
        {
            dgvDanhBo.AutoGenerateColumns = false;

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

            if (_MaDon != -1)
            {
                txtMaDon.Text = _MaDon.ToString();
                KeyPressEventArgs arg = new KeyPressEventArgs(Convert.ToChar(Keys.Enter));

                txtMaDon_KeyPress(sender, arg);
            }
        }

        public void LoadTTKH(HOADON entity)
        {
            txtDanhBo.Text = entity.DANHBA.Insert(7, " ").Insert(4, " ");
            txtHopDong.Text = entity.HOPDONG;
            txtHoTen.Text = entity.TENKH;
            txtDiaChi.Text = entity.SO + " " + entity.DUONG + _cDocSo.GetPhuongQuan(entity.Quan, entity.Phuong);
            txtGiaBieu.Text = entity.GB.ToString();
            txtDinhMuc.Text = entity.DM.ToString();
        }

        public void LoadDonTu(LinQ.DonTu entity)
        {
            try
            {
                if (entity.SoCongVan == null)
                {
                    tabControl.SelectTab("tabTTKH");
                    if (entity.SoNK != null)
                    {
                        txtSoNK.Text = entity.SoNK.Value.ToString();
                        txtHieuLucKy.Text = entity.HieuLucKy;
                    }
                    if (entity.DonTu_ChiTiets.SingleOrDefault().DanhBo.Length == 11)
                        txtDanhBo.Text = entity.DonTu_ChiTiets.SingleOrDefault().DanhBo.Insert(7, " ").Insert(4, " ");
                    txtHopDong.Text = entity.DonTu_ChiTiets.SingleOrDefault().HopDong;
                    txtDienThoai.Text = entity.DonTu_ChiTiets.SingleOrDefault().DienThoai;
                    txtNguoiBao.Text = entity.DonTu_ChiTiets.SingleOrDefault().NguoiBao;
                    txtHoTen.Text = entity.DonTu_ChiTiets.SingleOrDefault().HoTen;
                    txtDiaChi.Text = entity.DonTu_ChiTiets.SingleOrDefault().DiaChi;
                    if (entity.GiaBieu != null)
                        txtGiaBieu.Text = entity.DonTu_ChiTiets.SingleOrDefault().GiaBieu.Value.ToString();
                    if (entity.DinhMuc != null)
                        txtDinhMuc.Text = entity.DonTu_ChiTiets.SingleOrDefault().DinhMuc.Value.ToString();
                }
                else
                {
                    tabControl.SelectTab("tabCongVan");
                    txtSoCongVan.Text = entity.SoCongVan;
                    txtTongDB.Text = entity.TongDB.ToString();

                    dgvDanhBo.DataSource = entity.DonTu_ChiTiets.ToList();
                }
                txtMaDon.Text = entity.MaDon.ToString();
                dateCreateDate.Value = entity.CreateDate.Value;

                chkcmbDieuChinh.SetEditValue(entity.ID_NhomDon);
                chkcmbKhieuNai.SetEditValue(entity.ID_NhomDon);
                chkcmbDHN.SetEditValue(entity.ID_NhomDon);

                txtNoiDung.Text = entity.Name_NhomDon;
                txtVanDeKhac.Text = entity.VanDeKhac;

                chkCT_HoaDon.Checked = entity.CT_HoaDon;
                chkCT_HK_KT3.Checked = entity.CT_HK_KT3;
                chkCT_STT_GXNTT.Checked = entity.CT_STT_GXNTT;
                chkCT_HDTN_CQN.Checked = entity.CT_HDTN_CQN;
                chkCT_GC_SDSN.Checked = entity.CT_GC_SDSN;
                chkCT_GXN2SN.Checked = entity.CT_GXN2SN;
                chkCT_GDKKD.Checked = entity.CT_GDKKD;
                chkCT_GCNDTDHN.Checked = entity.CT_GCNDTDHN;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Clear()
        {
            txtSoCongVan.Text = "";
            txtTongDB.Text = "";
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
            dgvDanhBo.Rows.Clear();

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
            _MaDon = -1;
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
                            txtNoiDung.Text += "; " + chkcmbDieuChinh.Properties.Items[i].ToString();
                    }
                    else
                        if (chkcmbDieuChinh.Properties.Items[i].CheckState == CheckState.Unchecked && txtNoiDung.Text.Trim().Contains(chkcmbDieuChinh.Properties.Items[i].ToString()) == true)
                        {
                            txtNoiDung.Text = txtNoiDung.Text.Replace("; " + chkcmbDieuChinh.Properties.Items[i].ToString(), "");
                            txtNoiDung.Text = txtNoiDung.Text.Replace(chkcmbDieuChinh.Properties.Items[i].ToString() + "; ", "");
                            txtNoiDung.Text = txtNoiDung.Text.Replace(chkcmbDieuChinh.Properties.Items[i].ToString(), "");
                        }
                    if (chkcmbDieuChinh.Properties.Items[i].CheckState == CheckState.Checked && (chkcmbDieuChinh.Properties.Items[i].Value.ToString() == "1" || chkcmbDieuChinh.Properties.Items[i].Value.ToString() == "2"))
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
                            txtNoiDung.Text += "; " + chkcmbKhieuNai.Properties.Items[i].ToString();
                    }
                    else
                        if (chkcmbKhieuNai.Properties.Items[i].CheckState == CheckState.Unchecked && txtNoiDung.Text.Trim().Contains(chkcmbKhieuNai.Properties.Items[i].ToString()) == true)
                        {
                            txtNoiDung.Text = txtNoiDung.Text.Replace("; " + chkcmbKhieuNai.Properties.Items[i].ToString(), "");
                            txtNoiDung.Text = txtNoiDung.Text.Replace(chkcmbKhieuNai.Properties.Items[i].ToString() + "; ", "");
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
                            txtNoiDung.Text += "; " + chkcmbDHN.Properties.Items[i].ToString();
                    }
                    else
                        if (chkcmbDHN.Properties.Items[i].CheckState == CheckState.Unchecked && txtNoiDung.Text.Trim().Contains(chkcmbDHN.Properties.Items[i].ToString()) == true)
                        {
                            txtNoiDung.Text = txtNoiDung.Text.Replace("; " + chkcmbDHN.Properties.Items[i].ToString(), "");
                            txtNoiDung.Text = txtNoiDung.Text.Replace(chkcmbDHN.Properties.Items[i].ToString() + "; ", "");
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
                    if (string.IsNullOrEmpty(txtSoCongVan.Text.Trim()) == true)
                    {
                        if (_cDonTu.checkExist_ChiTiet(txtDanhBo.Text.Trim().Replace(" ", ""), DateTime.Now) == true)
                        {
                            if (MessageBox.Show("Danh Bộ " + txtDanhBo.Text.Trim().Replace(" ", "") + " đã nhận đơn trong ngày hôm nay rồi\nBạn vẫn muốn tiếp tục???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                return;
                        }
                        if (txtSoNK.Text.Trim() != "")
                        {
                            entity.SoNK = int.Parse(txtSoNK.Text.Trim());
                            entity.HieuLucKy = txtHieuLucKy.Text.Trim();
                        }
                        DonTu_ChiTiet entityCT = new DonTu_ChiTiet();
                        entityCT.ID = _cDonTu.getMaxID_ChiTiet() + 1;
                        entityCT.STT = 1;
                        entityCT.DanhBo = txtDanhBo.Text.Trim().Replace(" ", "");
                        entityCT.HopDong = txtHopDong.Text.Trim();
                        entityCT.DienThoai = txtDienThoai.Text.Trim();
                        entityCT.NguoiBao = txtNguoiBao.Text.Trim();
                        entityCT.HoTen = txtHoTen.Text.Trim();
                        entityCT.DiaChi = txtDiaChi.Text.Trim();
                        if (txtGiaBieu.Text.Trim() != "")
                            entityCT.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                        if (txtDinhMuc.Text.Trim() != "")
                            entityCT.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                        if (_hoadon != null)
                        {
                            entityCT.MLT = _hoadon.MALOTRINH;
                            entityCT.Dot = _hoadon.DOT;
                            entityCT.Ky = _hoadon.KY;
                            entityCT.Nam = _hoadon.NAM;
                            entityCT.Quan = _hoadon.Quan;
                            entityCT.Phuong = _hoadon.Phuong;
                        }
                        entityCT.CreateBy = CTaiKhoan.MaUser;
                        entityCT.CreateDate = DateTime.Now;

                        entity.DonTu_ChiTiets.Add(entityCT);
                    }
                    else
                    {
                        entity.SoCongVan = txtSoCongVan.Text.Trim();
                        entity.TongDB = int.Parse(txtTongDB.Text.Trim());

                        foreach (DataGridViewRow item in dgvDanhBo.Rows)
                        {
                            if (item.Cells["DanhBo"].Value != null || item.Cells["HoTen"].Value != null || item.Cells["DiaChi"].Value != null)
                            {
                                if (item.Cells["DanhBo"].Value != null)
                                    if (_cDonTu.checkExist_ChiTiet(item.Cells["DanhBo"].Value.ToString(), DateTime.Now) == true)
                                    {
                                        if (MessageBox.Show("Danh Bộ " + item.Cells["DanhBo"].Value.ToString() + " đã nhận đơn trong ngày hôm nay rồi\nBạn vẫn muốn tiếp tục???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                            return;
                                    }
                            }
                        }
                        int ID = _cDonTu.getMaxID_ChiTiet();
                        int STT = 0;
                        foreach (DataGridViewRow item in dgvDanhBo.Rows)
                        {
                            if (item.Cells["DanhBo"].Value != null || item.Cells["HoTen"].Value != null || item.Cells["DiaChi"].Value != null)
                            {
                                DonTu_ChiTiet entityCT = new DonTu_ChiTiet();
                                entityCT.ID = ++ID;
                                entityCT.STT = ++STT;

                                if (item.Cells["DanhBo"].Value != null)
                                    entityCT.DanhBo = item.Cells["DanhBo"].Value.ToString();
                                if (item.Cells["MLT"].Value != null)
                                    entityCT.MLT = item.Cells["MLT"].Value.ToString();
                                if (item.Cells["HopDong"].Value != null)
                                    entityCT.HopDong = item.Cells["HopDong"].Value.ToString();
                                if (item.Cells["HoTen"].Value != null)
                                    entityCT.HoTen = item.Cells["HoTen"].Value.ToString();
                                if (item.Cells["DiaChi"].Value != null)
                                    entityCT.DiaChi = item.Cells["DiaChi"].Value.ToString();
                                if (item.Cells["GiaBieu"].Value != null)
                                    entityCT.GiaBieu = int.Parse(item.Cells["GiaBieu"].Value.ToString());
                                if (item.Cells["DinhMuc"].Value != null)
                                    entityCT.DinhMuc = int.Parse(item.Cells["DinhMuc"].Value.ToString());
                                if (item.Cells["Dot"].Value != null)
                                    entityCT.Dot = int.Parse(item.Cells["Dot"].Value.ToString());
                                if (item.Cells["Ky"].Value != null)
                                    entityCT.Ky = int.Parse(item.Cells["Ky"].Value.ToString());
                                if (item.Cells["Nam"].Value != null)
                                    entityCT.Nam = int.Parse(item.Cells["Nam"].Value.ToString());
                                if (item.Cells["Quan"].Value != null)
                                    entityCT.Quan = item.Cells["Quan"].Value.ToString();
                                if (item.Cells["Phuong"].Value != null)
                                    entityCT.Phuong = item.Cells["Phuong"].Value.ToString();

                                entityCT.CreateBy = CTaiKhoan.MaUser;
                                entityCT.CreateDate = DateTime.Now;

                                entity.DonTu_ChiTiets.Add(entityCT);
                            }
                        }
                    }
                    ///
                    entity.NgayHenGiaiQuyet = "Trong thời gian 5 ngày làm việc kể từ ngày nhận hồ sơ, Công ty sẽ giải quyết theo quy định hiện hành";
                    entity.ID_NhomDon = "";
                    for (int i = 0; i < chkcmbDieuChinh.Properties.Items.Count; i++)
                        if (chkcmbDieuChinh.Properties.Items[i].CheckState == CheckState.Checked)
                        {
                            if (entity.ID_NhomDon == "")
                                entity.ID_NhomDon = chkcmbDieuChinh.Properties.Items[i].Value.ToString();
                            else
                                entity.ID_NhomDon += ";" + chkcmbDieuChinh.Properties.Items[i].Value.ToString();
                            if (chkcmbDieuChinh.Properties.Items[i].Value.ToString() == "4")
                                entity.NgayHenGiaiQuyet = "Quý khách nhận lại Hợp Đồng vào ngày " + GetToDate(DateTime.Now, 30).ToString("dd/MM/yyyy") + ". Quá thời hạn trên, Khách Hàng không liên hệ nhận Hợp Đồng; mọi Khiếu Nại về sau sẽ không được giải quyết";
                        }
                    for (int i = 0; i < chkcmbKhieuNai.Properties.Items.Count; i++)
                        if (chkcmbKhieuNai.Properties.Items[i].CheckState == CheckState.Checked)
                        {
                            if (entity.ID_NhomDon == "")
                                entity.ID_NhomDon = chkcmbKhieuNai.Properties.Items[i].Value.ToString();
                            else
                                entity.ID_NhomDon += ";" + chkcmbKhieuNai.Properties.Items[i].Value.ToString();
                        }
                    for (int i = 0; i < chkcmbDHN.Properties.Items.Count; i++)
                        if (chkcmbDHN.Properties.Items[i].CheckState == CheckState.Checked)
                        {
                            if (entity.ID_NhomDon == "")
                                entity.ID_NhomDon = chkcmbDHN.Properties.Items[i].Value.ToString();
                            else
                                entity.ID_NhomDon += ";" + chkcmbDHN.Properties.Items[i].Value.ToString();
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
                    if (_dontu != null)
                    {
                        if (_dontu.SoCongVan == null)
                        {
                            if (_cDonTu.checkExist_ChiTiet(txtDanhBo.Text.Trim().Replace(" ", ""), DateTime.Now) == true)
                            {
                                if (MessageBox.Show("Danh Bộ " + txtDanhBo.Text.Trim().Replace(" ", "") + " đã nhận đơn trong ngày hôm nay rồi\nBạn vẫn muốn tiếp tục???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                    return;
                            }
                            if (txtSoNK.Text.Trim() != "")
                            {
                                _dontu.SoNK = int.Parse(txtSoNK.Text.Trim());
                                _dontu.HieuLucKy = txtHieuLucKy.Text.Trim();
                            }
                            _dontu.DonTu_ChiTiets.SingleOrDefault().DanhBo = txtDanhBo.Text.Trim().Replace(" ", "");
                            _dontu.DonTu_ChiTiets.SingleOrDefault().HopDong = txtHopDong.Text.Trim();
                            _dontu.DonTu_ChiTiets.SingleOrDefault().DienThoai = txtDienThoai.Text.Trim();
                            _dontu.DonTu_ChiTiets.SingleOrDefault().NguoiBao = txtNguoiBao.Text.Trim();
                            _dontu.DonTu_ChiTiets.SingleOrDefault().HoTen = txtHoTen.Text.Trim();
                            _dontu.DonTu_ChiTiets.SingleOrDefault().DiaChi = txtDiaChi.Text.Trim();
                            if (txtGiaBieu.Text.Trim() != "")
                                _dontu.DonTu_ChiTiets.SingleOrDefault().GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                            if (txtDinhMuc.Text.Trim() != "")
                                _dontu.DonTu_ChiTiets.SingleOrDefault().DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                            if (_hoadon != null && _hoadon.DANHBA != txtDanhBo.Text.Trim().Replace(" ", ""))
                            {
                                _dontu.DonTu_ChiTiets.SingleOrDefault().MLT = _hoadon.MALOTRINH;
                                _dontu.DonTu_ChiTiets.SingleOrDefault().Dot = _hoadon.DOT;
                                _dontu.DonTu_ChiTiets.SingleOrDefault().Ky = _hoadon.KY;
                                _dontu.DonTu_ChiTiets.SingleOrDefault().Nam = _hoadon.NAM;
                                _dontu.DonTu_ChiTiets.SingleOrDefault().Quan = _hoadon.Quan;
                                _dontu.DonTu_ChiTiets.SingleOrDefault().Phuong = _hoadon.Phuong;
                            }
                        }
                        else
                        {
                            _dontu.SoCongVan = txtSoCongVan.Text.Trim();
                            _dontu.TongDB = int.Parse(txtTongDB.Text.Trim());
                        }
                        ///
                        _dontu.ID_NhomDon = "";
                        _dontu.NgayHenGiaiQuyet = "Trong thời gian 5 ngày làm việc kể từ ngày nhận hồ sơ, Công ty sẽ giải quyết theo quy định hiện hành";
                        for (int i = 0; i < chkcmbDieuChinh.Properties.Items.Count; i++)
                            if (chkcmbDieuChinh.Properties.Items[i].CheckState == CheckState.Checked)
                            {
                                if (_dontu.ID_NhomDon == "")
                                    _dontu.ID_NhomDon = chkcmbDieuChinh.Properties.Items[i].Value.ToString();
                                else
                                    _dontu.ID_NhomDon += ";" + chkcmbDieuChinh.Properties.Items[i].Value.ToString();
                                if (chkcmbDieuChinh.Properties.Items[i].Value.ToString() == "4")
                                    _dontu.NgayHenGiaiQuyet = "Quý khách nhận lại Hợp Đồng vào ngày " + GetToDate(_dontu.CreateDate.Value, 30).ToString("dd/MM/yyyy") + ". Quá thời hạn trên, Khách Hàng không liên hệ nhận Hợp Đồng; mọi Khiếu Nại về sau sẽ không được giải quyết";
                            }
                        for (int i = 0; i < chkcmbKhieuNai.Properties.Items.Count; i++)
                            if (chkcmbKhieuNai.Properties.Items[i].CheckState == CheckState.Checked)
                            {
                                if (_dontu.ID_NhomDon == "")
                                    _dontu.ID_NhomDon = chkcmbKhieuNai.Properties.Items[i].Value.ToString();
                                else
                                    _dontu.ID_NhomDon += ";" + chkcmbKhieuNai.Properties.Items[i].Value.ToString();
                            }
                        for (int i = 0; i < chkcmbDHN.Properties.Items.Count; i++)
                            if (chkcmbDHN.Properties.Items[i].CheckState == CheckState.Checked)
                            {
                                if (_dontu.ID_NhomDon == "")
                                    _dontu.ID_NhomDon = chkcmbDHN.Properties.Items[i].Value.ToString();
                                else
                                    _dontu.ID_NhomDon += ";" + chkcmbDHN.Properties.Items[i].Value.ToString();
                            }
                        _dontu.Name_NhomDon = txtNoiDung.Text.Trim();
                        if (txtVanDeKhac.Text.Trim() != "")
                            _dontu.VanDeKhac = txtVanDeKhac.Text.Trim();
                        ///
                        if (chkCT_HoaDon.Checked)
                            _dontu.CT_HoaDon = true;
                        else
                            _dontu.CT_HoaDon = false;

                        if (chkCT_HK_KT3.Checked)
                            _dontu.CT_HK_KT3 = true;
                        else
                            _dontu.CT_HK_KT3 = false;

                        if (chkCT_STT_GXNTT.Checked)
                            _dontu.CT_STT_GXNTT = true;
                        else
                            _dontu.CT_STT_GXNTT = false;

                        if (chkCT_HDTN_CQN.Checked)
                            _dontu.CT_HDTN_CQN = true;
                        else
                            _dontu.CT_HDTN_CQN = false;

                        if (chkCT_GC_SDSN.Checked)
                            _dontu.CT_GC_SDSN = true;
                        else
                            _dontu.CT_GC_SDSN = false;

                        if (chkCT_GXN2SN.Checked)
                            _dontu.CT_GXN2SN = true;
                        else
                            _dontu.CT_GXN2SN = false;

                        if (chkCT_GDKKD.Checked)
                            _dontu.CT_GDKKD = true;
                        else
                            _dontu.CT_GDKKD = false;

                        if (chkCT_GCNDTDHN.Checked)
                            _dontu.CT_GCNDTDHN = true;
                        else
                            _dontu.CT_GCNDTDHN = false;
                        ///
                        if (_cDonTu.Sua(_dontu))
                        {
                            Clear();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
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
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                try
                {
                    if (_dontu != null && MessageBox.Show("Bạn chắc chắn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (_cDonTu.Xoa(_dontu))
                        {
                            Clear();
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMaDon.Text.Trim() != "" && e.KeyChar == 13)
            {
                int MaDon = int.Parse(txtMaDon.Text.Trim());
                Clear();
                _dontu = _cDonTu.get(MaDon);
                if (_dontu != null)
                {
                    LoadDonTu(_dontu);
                }
                else
                {
                    MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clear();
                }
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_dontu != null)
                InBienNhan(_dontu);
        }

        public void InBienNhan(LinQ.DonTu entity)
        {
            try
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                DataRow dr = dsBaoCao.Tables["BienNhanDonKH"].NewRow();
                dr["MaDon"] = entity.MaDon.ToString();
                dr["KhachHang"] = entity.DonTu_ChiTiets.SingleOrDefault().HoTen;
                if (entity.DonTu_ChiTiets.SingleOrDefault().DanhBo != "")
                    dr["DanhBo"] = entity.DonTu_ChiTiets.SingleOrDefault().DanhBo.Insert(7, " ").Insert(4, " ");
                dr["DiaChi"] = entity.DonTu_ChiTiets.SingleOrDefault().DiaChi;
                dr["HopDong"] = entity.DonTu_ChiTiets.SingleOrDefault().HopDong;
                dr["DienThoai"] = entity.DonTu_ChiTiets.SingleOrDefault().DienThoai;
                dr["NoiDung"] = entity.Name_NhomDon;
                dr["LyDoLoaiKhac"] = entity.VanDeKhac;

                #region CheckBox

                if (entity.CT_HoaDon)
                {
                    dr["CT_HoaDon"] = true;
                }
                else
                {
                    dr["CT_HoaDon"] = false;
                }

                if (entity.CT_HK_KT3)
                {
                    dr["CT_HK_KT3"] = true;
                }
                else
                {
                    dr["CT_HK_KT3"] = false;
                }

                if (entity.CT_STT_GXNTT)
                {
                    dr["CT_STT_GXNTT"] = true;
                }
                else
                {
                    dr["CT_STT_GXNTT"] = false;
                }

                if (entity.CT_HDTN_CQN)
                {
                    dr["CT_HDTN_CQN"] = true;
                }
                else
                {
                    dr["CT_HDTN_CQN"] = false;
                }

                if (entity.CT_GC_SDSN)
                {
                    dr["CT_GC_SDSN"] = true;
                }
                else
                {
                    dr["CT_GC_SDSN"] = false;
                }

                if (entity.CT_GXN2SN)
                {
                    dr["CT_GXN2SN"] = true;
                }
                else
                {
                    dr["CT_GXN2SN"] = false;
                }

                if (entity.CT_GDKKD)
                {
                    dr["CT_GDKKD"] = true;
                }
                else
                {
                    dr["CT_GDKKD"] = false;
                }

                if (entity.CT_GCNDTDHN)
                {
                    dr["CT_GCNDTDHN"] = true;
                }
                else
                {
                    dr["CT_GCNDTDHN"] = false;
                }
                #endregion

                dr["NgayGiaiQuyet"] = entity.NgayHenGiaiQuyet;
                if (entity.SoNK != null)
                    dr["DinhMucSau"] = entity.SoNK * 4;
                dr["HieuLucTuKy"] = entity.HieuLucKy;
                dr["HoTenNV"] = CTaiKhoan.HoTen;
                dsBaoCao.Tables["BienNhanDonKH"].Rows.Add(dr);
                rptBienNhanDonTu rpt = new rptBienNhanDonTu();
                rpt.SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DateTime GetToDate(DateTime FromDate, int SoNgayCongThem)
        {
            while (SoNgayCongThem > 0)
            {
                if (FromDate.DayOfWeek == DayOfWeek.Friday)
                    FromDate = FromDate.AddDays(3);
                else
                    if (FromDate.DayOfWeek == DayOfWeek.Saturday)
                        FromDate = FromDate.AddDays(2);
                    else
                        FromDate = FromDate.AddDays(1);
                SoNgayCongThem--;
            }
            return FromDate;
        }

        private void dgvDanhBo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDanhBo.Columns[e.ColumnIndex].Name == "DanhBo" && dgvDanhBo["DanhBo", e.RowIndex].Value != null)
            {
                for (int i = 0; i < dgvDanhBo.Rows.Count - 2; i++)
                    if (i != e.RowIndex && dgvDanhBo["DanhBo", i].Value != null && dgvDanhBo["DanhBo", i].Value.ToString() != "" && dgvDanhBo["DanhBo", i].Value.ToString() == dgvDanhBo["DanhBo", e.RowIndex].Value.ToString())
                    {
                        MessageBox.Show("Danh Bộ đã nhập rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                HOADON hoadon = _cThuTien.GetMoiNhat(dgvDanhBo["DanhBo", e.RowIndex].Value.ToString());
                if (hoadon != null)
                {
                    dgvDanhBo["HopDong", e.RowIndex].Value = hoadon.HOPDONG;
                    dgvDanhBo["HoTen", e.RowIndex].Value = hoadon.TENKH;
                    dgvDanhBo["DiaChi", e.RowIndex].Value = hoadon.SO + " " + hoadon.DUONG + _cDocSo.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
                    dgvDanhBo["GiaBieu", e.RowIndex].Value = hoadon.GB;
                    dgvDanhBo["DinhMuc", e.RowIndex].Value = hoadon.DM;
                    dgvDanhBo["Dot", e.RowIndex].Value = hoadon.DOT;
                    dgvDanhBo["Ky", e.RowIndex].Value = hoadon.KY;
                    dgvDanhBo["Nam", e.RowIndex].Value = hoadon.NAM;
                    dgvDanhBo["MLT", e.RowIndex].Value = hoadon.MALOTRINH;
                    dgvDanhBo["Quan", e.RowIndex].Value = hoadon.Quan;
                    dgvDanhBo["Phuong", e.RowIndex].Value = hoadon.Phuong;
                }
                else
                {
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvDanhBo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhBo.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void txtSoNK_TextChanged(object sender, EventArgs e)
        {
            if (txtSoNK.Text.Trim() != "")
                txtDM.Text = (int.Parse(txtSoNK.Text.Trim()) * 4).ToString();
        }

        private void txtSoNK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
