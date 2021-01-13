using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.DonTu;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.DonTu
{
    public partial class frmCapNhatDonTu2019 : Form
    {
        string _mnu = "mnuCapNhatDonTu";
        CDonTu _cDonTu = new CDonTu();
        CNoiChuyen _cNoiChuyen = new CNoiChuyen();
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();
        CPhongBanDoi _cPhongBanDoi = new CPhongBanDoi();
        CLichSuDonTu _cLichSuDonTu = new CLichSuDonTu();
        CNhomDon _cNhomDon = new CNhomDon();

        LinQ.DonTu _dontu = null;
        DonTu_ChiTiet _dontu_ChiTiet = null;
        DonTu_LichSu _dontu_LichSu = null;

        public frmCapNhatDonTu2019()
        {
            InitializeComponent();
        }

        private void frmCapNhatDonTu_Load(object sender, EventArgs e)
        {
            dgvDanhBo.AutoGenerateColumns = false;
            dgvLichSuDonTu.AutoGenerateColumns = false;
            dgvLichSuDonTu_Update.AutoGenerateColumns = false;

            DataTable dt = _cNhomDon.getDS("DieuChinh");
            chkcmbDieuChinh.Properties.DataSource = dt;
            chkcmbDieuChinh.Properties.ValueMember = "ID";
            chkcmbDieuChinh.Properties.DisplayMember = "Name";
            chkcmbDieuChinh.Properties.DropDownRows = dt.Rows.Count + 1;

            dt = _cNhomDon.getDS("KhieuNai");
            chkcmbKhieuNai.Properties.DataSource = dt;
            chkcmbKhieuNai.Properties.ValueMember = "ID";
            chkcmbKhieuNai.Properties.DisplayMember = "Name";
            chkcmbKhieuNai.Properties.DropDownRows = dt.Rows.Count + 1;

            dt = _cNhomDon.getDS("SuCo");
            chkcmbDHN.Properties.DataSource = dt;
            chkcmbDHN.Properties.ValueMember = "ID";
            chkcmbDHN.Properties.DisplayMember = "Name";
            chkcmbDHN.Properties.DropDownRows = dt.Rows.Count + 1;

            dt = _cNhomDon.getDS("QuanLy");
            chkcmbQuanLy.Properties.DataSource = dt;
            chkcmbQuanLy.Properties.ValueMember = "ID";
            chkcmbQuanLy.Properties.DisplayMember = "Name";
            chkcmbQuanLy.Properties.DropDownRows = dt.Rows.Count + 1;

            cmbNoiChuyen.DataSource = _cNoiChuyen.GetDS("DonTuChuyen");
            cmbNoiChuyen.ValueMember = "ID";
            cmbNoiChuyen.DisplayMember = "Name";
            cmbNoiChuyen.SelectedIndex = -1;

            chkcmbNoiNhan.Properties.DataSource = _cNoiChuyen.GetDS("DonTuNhan");
            chkcmbNoiNhan.Properties.ValueMember = "ID";
            chkcmbNoiNhan.Properties.DisplayMember = "Name";
            //chkcmbNoiNhan.Properties.DropDownRows = dt.Rows.Count + 1;

        }

        public void LoadDonTu(LinQ.DonTu entity, DonTu_ChiTiet en_ChiTiet)
        {
            try
            {
                txtMaDon.Text = entity.MaDon.ToString();
                dateCreateDate.Value = entity.CreateDate.Value;
                txtNguoiLap.Text = _cTaiKhoan.GetHoTen(entity.CreateBy.Value);
                if (entity.SoCongVan_PhongBanDoi != null)
                    txtPhongBanDoi.Text = entity.SoCongVan_PhongBanDoi;
                if (entity.SoCongVan != null)
                {
                    txtSoCongVan.Text = entity.SoCongVan;
                    txtTongDB.Text = entity.TongDB.ToString();
                }

                if (entity.ID_NhomDon_PKH != null && entity.ID_NhomDon_PKH.Contains("7"))
                    panel1.Visible = true;
                else
                    panel1.Visible = false;
                if (entity.ID_NhomDon != null)
                {
                    chkcmbDieuChinh.SetEditValue(entity.ID_NhomDon);
                    chkcmbKhieuNai.SetEditValue(entity.ID_NhomDon);
                    chkcmbDHN.SetEditValue(entity.ID_NhomDon);
                    chkcmbQuanLy.SetEditValue(entity.ID_NhomDon);
                }
                txtNoiDungKhachHang.Text = entity.Name_NhomDon_PKH;
                txtNoiDungThuongVu.Text = entity.Name_NhomDon;
                txtVanDeKhac.Text = entity.VanDeKhac;
                if (entity.DonTu_ChiTiets.Count == 1)
                {
                    tabControl.SelectTab("tabTTKH");
                    if (entity.SoNK != null)
                    {
                        txtSoNK.Text = entity.SoNK.Value.ToString();
                        txtHieuLucKy.Text = entity.HieuLucKy;
                    }
                    if (entity.DonTu_ChiTiets.SingleOrDefault().DanhBo != null && entity.DonTu_ChiTiets.SingleOrDefault().DanhBo.Length == 11)
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
                    chkHoanThanh.Checked = entity.DonTu_ChiTiets.SingleOrDefault().HoanThanh;
                    lbTinhTrang.Text = "Tình Trạng: " + entity.DonTu_ChiTiets.SingleOrDefault().TinhTrang;
                }
                else
                {
                    tabControl.SelectTab("tabCongVan");
                    dgvDanhBo.DataSource = entity.DonTu_ChiTiets.ToList();
                    if (en_ChiTiet != null)
                    {
                        txtMaDon.Text += "." + en_ChiTiet.STT;
                        foreach (DataGridViewRow item in dgvDanhBo.Rows)
                            if (int.Parse(item.Cells["STT"].Value.ToString()) == en_ChiTiet.STT)
                            {
                                item.Selected = true;
                                dgvDanhBo.CurrentCell = item.Cells["DanhBo"];
                            }
                        chkHoanThanh.Checked = en_ChiTiet.HoanThanh;
                        lbTinhTrang.Text = "Tình Trạng: " + en_ChiTiet.TinhTrang;
                    }
                }
                LoadLichSu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadDonTu_ChiTiet(LinQ.DonTu_ChiTiet entity)
        {
            try
            {
                txtMaDon.Text += "." + entity.STT.Value;

                LoadLichSu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadLichSu()
        {
            if (_dontu != null)
                if (_dontu_ChiTiet == null)
                    dgvLichSuDonTu.DataSource = _cDonTu.getDS_LichSu(_dontu.MaDon, 1);
                else
                    if (dgvDanhBo.SelectedRows.Count > 1)
                        dgvLichSuDonTu.DataSource = _cDonTu.getDS_LichSu(_dontu_ChiTiet.MaDon.Value, dgvDanhBo.CurrentRow.Index);
                    else
                        dgvLichSuDonTu.DataSource = _cDonTu.getDS_LichSu(_dontu_ChiTiet.MaDon.Value, _dontu_ChiTiet.STT.Value);

        }

        public void FillLichSu(DonTu_LichSu en)
        {
            for (int i = 0; i < chkcmbNoiNhan.Properties.Items.Count; i++)
                chkcmbNoiNhan.Properties.Items[i].CheckState = CheckState.Unchecked;
            for (int i = 0; i < chkcmbNoiNhanKTXM.Properties.Items.Count; i++)
                chkcmbNoiNhanKTXM.Properties.Items[i].CheckState = CheckState.Unchecked;
            dateChuyen.Value = en.NgayChuyen.Value;

            if (en.ID_NoiChuyen != null)
                cmbNoiChuyen.SelectedValue = en.ID_NoiChuyen;
            else
                cmbNoiChuyen.SelectedIndex = -1;

            if (en.ID_NoiNhan != null)
                chkcmbNoiNhan.SetEditValue(en.ID_NoiNhan);

            if (en.ID_KTXM != null)
                chkcmbNoiNhanKTXM.SetEditValue(en.ID_KTXM);

            txtNoiDung_LichSu.Text = en.NoiDung;
        }

        public void Clear()
        {
            txtPhongBanDoi.Text.Trim();
            txtSoCongVan.Text = "";
            txtTongDB.Text = "";
            txtMaDon.Text = "";
            txtNguoiLap.Text = "";

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
            for (int i = 0; i < chkcmbQuanLy.Properties.Items.Count; i++)
            {
                chkcmbQuanLy.Properties.Items[i].CheckState = CheckState.Unchecked;
            }

            txtSoNK.Text = "";
            txtHieuLucKy.Text = "";
            txtDM.Text = "";
            txtNoiDungKhachHang.Text = "";
            txtNoiDungThuongVu.Text = "";
            txtVanDeKhac.Text = "";

            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtDienThoai.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            dgvDanhBo.DataSource = null;

            _dontu = null;
            _dontu_ChiTiet = null;
            _dontu_LichSu = null;

            dateChuyen.Value = DateTime.Now;
            cmbNoiChuyen.SelectedIndex = -1;
            for (int i = 0; i < chkcmbNoiNhan.Properties.Items.Count; i++)
            {
                chkcmbNoiNhan.Properties.Items[i].CheckState = CheckState.Unchecked;
            }
            for (int i = 0; i < chkcmbNoiNhanKTXM.Properties.Items.Count; i++)
            {
                chkcmbNoiNhanKTXM.Properties.Items[i].CheckState = CheckState.Unchecked;
            }
            chkHoanThanh.Checked = false;
            txtNoiDung_LichSu.Text = "";
            lbTinhTrang.Text = "Tình Trạng";
        }

        public void ClearChuyenDon()
        {
            dateChuyen.Value = DateTime.Now;
            for (int i = 0; i < chkcmbNoiNhan.Properties.Items.Count; i++)
            {
                chkcmbNoiNhan.Properties.Items[i].CheckState = CheckState.Unchecked;
            }
            for (int i = 0; i < chkcmbNoiNhanKTXM.Properties.Items.Count; i++)
            {
                chkcmbNoiNhanKTXM.Properties.Items[i].CheckState = CheckState.Unchecked;
            }
            txtNoiDung_LichSu.Text = "";
            _dontu_LichSu = null;
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMaDon.Text.Trim() != "" && e.KeyChar == 13)
            {
                string MaDon = txtMaDon.Text.Trim();
                Clear();
                if (MaDon.Contains(".") == true)
                {
                    string[] MaDons = MaDon.Split('.');
                    _dontu = _cDonTu.get(int.Parse(MaDons[0]));
                    _dontu_ChiTiet = _cDonTu.get_ChiTiet(int.Parse(MaDons[0]), int.Parse(MaDons[1]));
                }
                else
                {
                    _dontu = _cDonTu.get(int.Parse(MaDon));
                }

                if (_dontu != null)
                {
                    //if (_dontu.SoCongVan != null && _dontu_ChiTiet == null)
                    //{
                    //    MessageBox.Show("Đơn Công Văn, vui lòng nhập thêm số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return;
                    //}
                    LoadDonTu(_dontu, _dontu_ChiTiet);
                }
                else
                {
                    MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clear();
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {
                    if (_dontu != null)
                    {
                        _dontu.ID_NhomDon = "";
                        for (int i = 0; i < chkcmbDieuChinh.Properties.Items.Count; i++)
                            if (chkcmbDieuChinh.Properties.Items[i].CheckState == CheckState.Checked)
                            {
                                if (_dontu.ID_NhomDon == "")
                                    _dontu.ID_NhomDon = chkcmbDieuChinh.Properties.Items[i].Value.ToString();
                                else
                                    _dontu.ID_NhomDon += ";" + chkcmbDieuChinh.Properties.Items[i].Value.ToString();
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
                        for (int i = 0; i < chkcmbQuanLy.Properties.Items.Count; i++)
                            if (chkcmbQuanLy.Properties.Items[i].CheckState == CheckState.Checked)
                            {
                                if (_dontu.ID_NhomDon == "")
                                    _dontu.ID_NhomDon = chkcmbQuanLy.Properties.Items[i].Value.ToString();
                                else
                                    _dontu.ID_NhomDon += ";" + chkcmbQuanLy.Properties.Items[i].Value.ToString();
                            }
                        _dontu.Name_NhomDon = txtNoiDungThuongVu.Text.Trim();
                        _dontu.VanDeKhac = txtVanDeKhac.Text.Trim();
                        _cDonTu.SubmitChanges();
                    }
                    //cập nhật
                    if (_dontu_LichSu != null)
                    {
                        bool flag = false;//ghi nhận có chọn checkcombobox
                        if (cmbNoiChuyen.SelectedIndex > -1)
                        {
                            for (int i = 0; i < chkcmbNoiNhan.Properties.Items.Count; i++)
                                if (chkcmbNoiNhan.Properties.Items[i].CheckState == CheckState.Checked)
                                {
                                    //đi KTXM
                                    if (chkcmbNoiNhan.Properties.Items[i].Value.ToString() == "5")
                                    {

                                        for (int j = 0; j < chkcmbNoiNhanKTXM.Properties.Items.Count; j++)
                                            if (chkcmbNoiNhanKTXM.Properties.Items[j].CheckState == CheckState.Checked)
                                            {
                                                _dontu_LichSu.NgayChuyen = dateChuyen.Value;
                                                _dontu_LichSu.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                                _dontu_LichSu.NoiChuyen = cmbNoiChuyen.Text;
                                                _dontu_LichSu.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                                _dontu_LichSu.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                                _dontu_LichSu.NoiDung = txtNoiDung_LichSu.Text.Trim();
                                                //_dontu_LichSu.MaDon = _dontu.MaDon;
                                                _dontu_LichSu.ID_KTXM = int.Parse(chkcmbNoiNhanKTXM.Properties.Items[j].Value.ToString());
                                                _dontu_LichSu.KTXM = chkcmbNoiNhanKTXM.Properties.Items[j].ToString();
                                                _cDonTu.SubmitChanges();
                                            }
                                    }
                                    else
                                    {
                                        _dontu_LichSu.NgayChuyen = dateChuyen.Value;
                                        _dontu_LichSu.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                        _dontu_LichSu.NoiChuyen = cmbNoiChuyen.Text;
                                        _dontu_LichSu.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                        _dontu_LichSu.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                        _dontu_LichSu.NoiDung = txtNoiDung_LichSu.Text.Trim();
                                        //_dontu_LichSu.MaDon = _dontu.MaDon;
                                        _cDonTu.SubmitChanges();
                                    }
                                    flag = true;
                                }
                            if (flag == false)
                            {
                                _dontu_LichSu.NgayChuyen = dateChuyen.Value;
                                _dontu_LichSu.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                _dontu_LichSu.NoiChuyen = cmbNoiChuyen.Text;
                                //_dontu_LichSu.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                //_dontu_LichSu.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                _dontu_LichSu.NoiDung = txtNoiDung_LichSu.Text.Trim();
                                //_dontu_LichSu.MaDon = _dontu.MaDon;
                                _cDonTu.SubmitChanges();
                            }
                        }
                        //else
                        //{
                        //    MessageBox.Show("Chưa chọn Nơi Chuyển", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    return;
                        //}

                        //else
                        //{
                        //    _dontu_LichSu.NgayChuyen = dateChuyen.Value;
                        //    _dontu_LichSu.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                        //    _dontu_LichSu.NoiChuyen = cmbNoiChuyen.Text;
                        //    //_dontu_LichSu.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                        //    //_dontu_LichSu.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                        //    _dontu_LichSu.NoiDung = txtNoiDung_LichSu.Text.Trim();
                        //    //_dontu_LichSu.MaDon = _dontu.MaDon;
                        //    _cDonTu.SubmitChanges();
                        //}
                    }
                    else
                        //thêm mới
                        if (_dontu != null)
                        {
                            //đơn cá nhân
                            if (tabControl.SelectedTab.Name == "tabTTKH")
                            {
                                if (_dontu.DonTu_ChiTiets.Count() > 1)
                                {
                                    MessageBox.Show("Đơn Công Văn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                bool flag = false;//ghi nhận có chọn checkcombobox
                                if (cmbNoiChuyen.SelectedIndex > -1)
                                {
                                    for (int i = 0; i < chkcmbNoiNhan.Properties.Items.Count; i++)
                                        if (chkcmbNoiNhan.Properties.Items[i].CheckState == CheckState.Checked)
                                        {
                                            //đi KTXM
                                            if (chkcmbNoiNhan.Properties.Items[i].Value.ToString() == "5")
                                            {

                                                for (int j = 0; j < chkcmbNoiNhanKTXM.Properties.Items.Count; j++)
                                                    if (chkcmbNoiNhanKTXM.Properties.Items[j].CheckState == CheckState.Checked)
                                                    {
                                                        DonTu_LichSu entity = new DonTu_LichSu();
                                                        entity.NgayChuyen = dateChuyen.Value;
                                                        entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                                        entity.NoiChuyen = cmbNoiChuyen.Text;
                                                        entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                                        entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                                        entity.NoiDung = txtNoiDung_LichSu.Text.Trim();
                                                        entity.MaDon = _dontu.MaDon;
                                                        entity.STT = 1;
                                                        entity.ID_KTXM = int.Parse(chkcmbNoiNhanKTXM.Properties.Items[j].Value.ToString());
                                                        entity.KTXM = chkcmbNoiNhanKTXM.Properties.Items[j].ToString();
                                                        _cDonTu.Them_LichSu(entity);
                                                    }
                                            }
                                            else
                                            {
                                                DonTu_LichSu entity = new DonTu_LichSu();
                                                entity.NgayChuyen = dateChuyen.Value;
                                                entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                                entity.NoiChuyen = cmbNoiChuyen.Text;
                                                entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                                entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                                entity.NoiDung = txtNoiDung_LichSu.Text.Trim();
                                                entity.MaDon = _dontu.MaDon;
                                                entity.STT = 1;
                                                _cDonTu.Them_LichSu(entity);
                                            }
                                            flag = true;
                                        }
                                    if (flag == false)
                                    {
                                        if (chkHoanThanh.Checked == true)
                                        {
                                            if (txtNoiDung_LichSu.Text.Trim() != "")
                                            {
                                                //cập nhật tình trạng
                                                _dontu.DonTu_ChiTiets.SingleOrDefault().HoanThanh = chkHoanThanh.Checked;
                                                _dontu.DonTu_ChiTiets.SingleOrDefault().HoanThanh_Ngay = DateTime.Now;
                                                _dontu.DonTu_ChiTiets.SingleOrDefault().HoanThanh_GhiChu = txtNoiDung_LichSu.Text.Trim();
                                                _cDonTu.SubmitChanges();
                                                //
                                                DonTu_LichSu entity = new DonTu_LichSu();
                                                entity.NgayChuyen = dateChuyen.Value;
                                                entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                                entity.NoiChuyen = cmbNoiChuyen.Text;
                                                //entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                                //entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                                entity.NoiDung = txtNoiDung_LichSu.Text.Trim();
                                                entity.MaDon = _dontu.MaDon;
                                                entity.STT = 1;
                                                entity.HoanThanh = true;
                                                _cDonTu.Them_LichSu(entity);
                                            }
                                            else
                                                MessageBox.Show("Thiếu Nội Dung lý do Hoàn Thành", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        else
                                        {
                                            DonTu_LichSu entity = new DonTu_LichSu();
                                            entity.NgayChuyen = dateChuyen.Value;
                                            entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                            entity.NoiChuyen = cmbNoiChuyen.Text;
                                            //entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                            //entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                            entity.NoiDung = txtNoiDung_LichSu.Text.Trim();
                                            entity.MaDon = _dontu.MaDon;
                                            entity.STT = 1;
                                            _cDonTu.Them_LichSu(entity);
                                        }
                                    }
                                }
                                //else
                                //{
                                //    MessageBox.Show("Chưa chọn Nơi Chuyển", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //    return;
                                //}
                            }
                            else
                                //đơn công văn
                                if (tabControl.SelectedTab.Name == "tabCongVan")
                                {
                                    //nhập 1
                                    if (_dontu_ChiTiet != null)
                                    {
                                        bool flag = false;//ghi nhận có chọn checkcombobox
                                        if (cmbNoiChuyen.SelectedIndex > -1)
                                        {
                                            for (int i = 0; i < chkcmbNoiNhan.Properties.Items.Count; i++)
                                                if (chkcmbNoiNhan.Properties.Items[i].CheckState == CheckState.Checked)
                                                {
                                                    //đi KTXM
                                                    if (chkcmbNoiNhan.Properties.Items[i].Value.ToString() == "5")
                                                    {

                                                        for (int j = 0; j < chkcmbNoiNhanKTXM.Properties.Items.Count; j++)
                                                            if (chkcmbNoiNhanKTXM.Properties.Items[j].CheckState == CheckState.Checked)
                                                            {
                                                                DonTu_LichSu entity = new DonTu_LichSu();
                                                                entity.NgayChuyen = dateChuyen.Value;
                                                                entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                                                entity.NoiChuyen = cmbNoiChuyen.Text;
                                                                entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                                                entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                                                entity.NoiDung = txtNoiDung_LichSu.Text.Trim();
                                                                entity.MaDon = _dontu.MaDon;
                                                                entity.STT = _dontu_ChiTiet.STT;
                                                                entity.ID_KTXM = int.Parse(chkcmbNoiNhanKTXM.Properties.Items[j].Value.ToString());
                                                                entity.KTXM = chkcmbNoiNhanKTXM.Properties.Items[j].ToString();
                                                                _cDonTu.Them_LichSu(entity);
                                                            }
                                                    }
                                                    else
                                                    {
                                                        DonTu_LichSu entity = new DonTu_LichSu();
                                                        entity.NgayChuyen = dateChuyen.Value;
                                                        entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                                        entity.NoiChuyen = cmbNoiChuyen.Text;
                                                        entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                                        entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                                        entity.NoiDung = txtNoiDung_LichSu.Text.Trim();
                                                        entity.MaDon = _dontu.MaDon;
                                                        entity.STT = _dontu_ChiTiet.STT;
                                                        _cDonTu.Them_LichSu(entity);
                                                    }
                                                    flag = true;
                                                }
                                            if (flag == false)
                                            {
                                                if (chkHoanThanh.Checked == true)
                                                {
                                                    if (txtNoiDung_LichSu.Text.Trim() != "")
                                                    {
                                                        //cập nhật tình trạng
                                                        _dontu_ChiTiet.HoanThanh = chkHoanThanh.Checked;
                                                        _dontu_ChiTiet.HoanThanh_Ngay = DateTime.Now;
                                                        _dontu_ChiTiet.HoanThanh_GhiChu = txtNoiDung_LichSu.Text.Trim();
                                                        _cDonTu.SubmitChanges();
                                                        //
                                                        DonTu_LichSu entity = new DonTu_LichSu();
                                                        entity.NgayChuyen = dateChuyen.Value;
                                                        entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                                        entity.NoiChuyen = cmbNoiChuyen.Text;
                                                        //entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                                        //entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                                        entity.NoiDung = txtNoiDung_LichSu.Text.Trim();
                                                        entity.MaDon = _dontu.MaDon;
                                                        entity.STT = _dontu_ChiTiet.STT;
                                                        entity.HoanThanh = true;
                                                        _cDonTu.Them_LichSu(entity);
                                                    }
                                                    else
                                                        MessageBox.Show("Thiếu Nội Dung lý do Hoàn Thành", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                                else
                                                {
                                                    DonTu_LichSu entity = new DonTu_LichSu();
                                                    entity.NgayChuyen = dateChuyen.Value;
                                                    entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                                    entity.NoiChuyen = cmbNoiChuyen.Text;
                                                    //entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                                    //entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                                    entity.NoiDung = txtNoiDung_LichSu.Text.Trim();
                                                    entity.MaDon = _dontu.MaDon;
                                                    entity.STT = _dontu_ChiTiet.STT;
                                                    _cDonTu.Them_LichSu(entity);
                                                }
                                            }
                                        }
                                        //else
                                        //{
                                        //    MessageBox.Show("Chưa chọn Nơi Chuyển", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        //    return;
                                        //}
                                    }
                                    else
                                        //nhập nhiều
                                        foreach (DataGridViewRow item in dgvDanhBo.SelectedRows)
                                        {
                                            bool flag = false;//ghi nhận có chọn checkcombobox
                                            if (cmbNoiChuyen.SelectedIndex > -1)
                                            {
                                                for (int i = 0; i < chkcmbNoiNhan.Properties.Items.Count; i++)
                                                    if (chkcmbNoiNhan.Properties.Items[i].CheckState == CheckState.Checked)
                                                    {
                                                        //đi KTXM
                                                        if (chkcmbNoiNhan.Properties.Items[i].Value.ToString() == "5")
                                                        {

                                                            for (int j = 0; j < chkcmbNoiNhanKTXM.Properties.Items.Count; j++)
                                                                if (chkcmbNoiNhanKTXM.Properties.Items[j].CheckState == CheckState.Checked)
                                                                {
                                                                    DonTu_LichSu entity = new DonTu_LichSu();
                                                                    entity.NgayChuyen = dateChuyen.Value;
                                                                    entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                                                    entity.NoiChuyen = cmbNoiChuyen.Text;
                                                                    entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                                                    entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                                                    entity.NoiDung = txtNoiDung_LichSu.Text.Trim();
                                                                    DonTu_ChiTiet dontu_chitiet = _cDonTu.get_ChiTiet(int.Parse(item.Cells["ID_CongVan"].Value.ToString()));
                                                                    entity.MaDon = dontu_chitiet.DonTu.MaDon;
                                                                    entity.STT = dontu_chitiet.STT;
                                                                    entity.ID_KTXM = int.Parse(chkcmbNoiNhanKTXM.Properties.Items[j].Value.ToString());
                                                                    entity.KTXM = chkcmbNoiNhanKTXM.Properties.Items[j].ToString();
                                                                    _cDonTu.Them_LichSu(entity);
                                                                }
                                                        }
                                                        else
                                                        {
                                                            DonTu_LichSu entity = new DonTu_LichSu();
                                                            entity.NgayChuyen = dateChuyen.Value;
                                                            entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                                            entity.NoiChuyen = cmbNoiChuyen.Text;
                                                            entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                                            entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                                            entity.NoiDung = txtNoiDung_LichSu.Text.Trim();
                                                            DonTu_ChiTiet dontu_chitiet = _cDonTu.get_ChiTiet(int.Parse(item.Cells["ID_CongVan"].Value.ToString()));
                                                            entity.MaDon = dontu_chitiet.DonTu.MaDon;
                                                            entity.STT = dontu_chitiet.STT;
                                                            _cDonTu.Them_LichSu(entity);
                                                        }
                                                        flag = true;
                                                    }
                                                if (flag == false)
                                                {
                                                    if (chkHoanThanh.Checked == true)
                                                    {
                                                        if (txtNoiDung_LichSu.Text.Trim() != "")
                                                        {
                                                            DonTu_ChiTiet dontu_chitiet = _cDonTu.get_ChiTiet(int.Parse(item.Cells["ID_CongVan"].Value.ToString()));
                                                            //cập nhật tình trạng
                                                            dontu_chitiet.HoanThanh = chkHoanThanh.Checked;
                                                            dontu_chitiet.HoanThanh_Ngay = DateTime.Now;
                                                            dontu_chitiet.HoanThanh_GhiChu = txtNoiDung_LichSu.Text.Trim();
                                                            _cDonTu.SubmitChanges();
                                                            //
                                                            DonTu_LichSu entity = new DonTu_LichSu();
                                                            entity.NgayChuyen = dateChuyen.Value;
                                                            entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                                            entity.NoiChuyen = cmbNoiChuyen.Text;
                                                            //entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                                            //entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                                            entity.NoiDung = txtNoiDung_LichSu.Text.Trim();
                                                            entity.MaDon = dontu_chitiet.DonTu.MaDon;
                                                            entity.STT = dontu_chitiet.STT;
                                                            entity.HoanThanh = true;
                                                            _cDonTu.Them_LichSu(entity);
                                                        }
                                                        else
                                                            MessageBox.Show("Thiếu Nội Dung lý do Hoàn Thành", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    }
                                                    else
                                                    {
                                                        DonTu_LichSu entity = new DonTu_LichSu();
                                                        entity.NgayChuyen = dateChuyen.Value;
                                                        entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                                        entity.NoiChuyen = cmbNoiChuyen.Text;
                                                        //entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                                        //entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                                        entity.NoiDung = txtNoiDung_LichSu.Text.Trim();
                                                        DonTu_ChiTiet dontu_chitiet = _cDonTu.get_ChiTiet(int.Parse(item.Cells["ID_CongVan"].Value.ToString()));
                                                        entity.MaDon = dontu_chitiet.DonTu.MaDon;
                                                        entity.STT = dontu_chitiet.STT;
                                                        _cDonTu.Them_LichSu(entity);
                                                    }
                                                }
                                            }
                                            //else
                                            //{
                                            //    MessageBox.Show("Chưa chọn Nơi Chuyển", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            //    return;
                                            //}
                                        }
                                }
                        }
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //ClearChuyenDon();
                    //LoadLichSu();
                    _cDonTu.Refresh();
                    KeyPressEventArgs arg = new KeyPressEventArgs(Convert.ToChar(Keys.Enter));
                    txtMaDon_KeyPress(sender, arg);
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLichSuDonTu_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                ///Khi chuột phải Selected-Row sẽ được chuyển đến nơi click chuột
                dgvLichSuDonTu.CurrentCell = dgvLichSuDonTu.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dgvLichSuDonTu_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && (_dontu != null))
            {
                contextMenuStrip1.Show(dgvLichSuDonTu, new Point(e.X, e.Y));
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (CTaiKhoan.Admin == true || CTaiKhoan.TruongPhong == true)
                        {
                            DonTu_LichSu dtls = _cDonTu.get_LichSu(int.Parse(dgvLichSuDonTu.CurrentRow.Cells["ID"].Value.ToString()));
                            int MaDon = dtls.MaDon.Value, STT = dtls.STT.Value;
                            bool HoanThanh = dtls.HoanThanh;
                            if (_cDonTu.Xoa_LichSu(dtls))
                            {
                                if (HoanThanh == true)
                                {
                                    DonTu_ChiTiet dtct = _cDonTu.get_ChiTiet(MaDon, STT);
                                    dtct.HoanThanh = false;
                                    dtct.HoanThanh_Ngay = null;
                                    dtct.HoanThanh_GhiChu = null;
                                    _cDonTu.SubmitChanges();
                                }
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //LoadLichSu();
                                _cDonTu.Refresh();
                                KeyPressEventArgs arg = new KeyPressEventArgs(Convert.ToChar(Keys.Enter));
                                txtMaDon_KeyPress(sender, arg);
                            }
                            else
                                MessageBox.Show("Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            DonTu_LichSu dtls = _cDonTu.get_LichSu(int.Parse(dgvLichSuDonTu.CurrentRow.Cells["ID"].Value.ToString()));
                            int MaDon = dtls.MaDon.Value, STT = dtls.STT.Value;
                            bool HoanThanh = dtls.HoanThanh;
                            if (_cDonTu.Xoa_LichSu(dtls, CTaiKhoan.MaUser))
                            {
                                if (HoanThanh == true)
                                {
                                    DonTu_ChiTiet dtct = _cDonTu.get_ChiTiet(MaDon, STT);
                                    dtct.HoanThanh = false;
                                    dtct.HoanThanh_Ngay = null;
                                    dtct.HoanThanh_GhiChu = null;
                                    _cDonTu.SubmitChanges();
                                }
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //LoadLichSu();
                                _cDonTu.Refresh();
                                KeyPressEventArgs arg = new KeyPressEventArgs(Convert.ToChar(Keys.Enter));
                                txtMaDon_KeyPress(sender, arg);
                            }
                            else
                                MessageBox.Show("Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSoNK_TextChanged(object sender, EventArgs e)
        {
            if (txtSoNK.Text.Trim() != "")
                txtDM.Text = (int.Parse(txtSoNK.Text.Trim()) * 4).ToString();
            else
                txtDM.Text = "";
        }

        private void txtSoNK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void chkcmbNoiNhan_EditValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < chkcmbNoiNhan.Properties.Items.Count; i++)
                if (chkcmbNoiNhan.Properties.Items[i].CheckState == CheckState.Checked && chkcmbNoiNhan.Properties.Items[i].Value.ToString() == "5")
                {
                    DataTable dt = new DataTable();

                    dt = _cTaiKhoan.GetDS_KTXM(CTaiKhoan.KyHieuMaTo);
                    chkcmbNoiNhanKTXM.Properties.DataSource = dt;
                    chkcmbNoiNhanKTXM.Properties.ValueMember = "MaU";
                    chkcmbNoiNhanKTXM.Properties.DisplayMember = "HoTen";
                }
        }

        private void dgvLichSuDonTu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _dontu_LichSu = _cDonTu.get_LichSu(int.Parse(dgvLichSuDonTu.CurrentRow.Cells["ID"].Value.ToString()));
                FillLichSu(_dontu_LichSu);
            }
            catch (Exception)
            {

            }
        }

        private void dgvLichSuDonTu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDanhBo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //_dontu_ChiTiet = _cDonTu.get_ChiTiet(int.Parse(dgvDanhBo.CurrentRow.Cells["ID_CongVan"].Value.ToString()));
                //LoadDonTu_ChiTiet(_dontu_ChiTiet);
            }
            catch (Exception)
            {
            }

        }

        private void dgvDanhBo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhBo.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnXem_Update_Click(object sender, EventArgs e)
        {
            //string To = "";
            //if (CTaiKhoan.ToGD == true)
            //    To = "TGD";
            //else if (CTaiKhoan.ToTB == true)
            //    To = "TKH";
            //else if (CTaiKhoan.ToTP == true)
            //    To = "TXL";
            //else if (CTaiKhoan.ToBC == true)
            //    To = "TBC";
            dgvLichSuDonTu_Update.DataSource = _cDonTu.getDS_LichSu(CTaiKhoan.KyHieuMaTo, CTaiKhoan.MaUser, dateFromNgayChuyen.Value, dateToNgayChuyen.Value);
        }

        private void btnXoa_Update_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
                {
                    foreach (DataGridViewRow item in dgvLichSuDonTu_Update.SelectedRows)
                    {
                        DonTu_LichSu en = _cDonTu.get_LichSu(int.Parse(item.Cells["ID_Update"].Value.ToString()));
                        _cDonTu.Xoa_LichSu(en);
                    }
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnXem_Update.PerformClick();
                }
                else
                    MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkcmbDieuChinh_EditValueChanged(object sender, EventArgs e)
        {
            if (chkcmbDieuChinh.Properties.Items.Count > 0)
            {
                for (int i = 0; i < chkcmbDieuChinh.Properties.Items.Count; i++)
                {
                    if (chkcmbDieuChinh.Properties.Items[i].CheckState == CheckState.Checked && txtNoiDungThuongVu.Text.Trim().Contains(chkcmbDieuChinh.Properties.Items[i].ToString()) == false)
                    {
                        if (txtNoiDungThuongVu.Text.Trim() == "")
                            txtNoiDungThuongVu.Text = chkcmbDieuChinh.Properties.Items[i].ToString();
                        else
                            txtNoiDungThuongVu.Text += "; " + chkcmbDieuChinh.Properties.Items[i].ToString();
                    }
                    else
                        if (chkcmbDieuChinh.Properties.Items[i].CheckState == CheckState.Unchecked && txtNoiDungThuongVu.Text.Trim().Contains(chkcmbDieuChinh.Properties.Items[i].ToString()) == true)
                        {
                            txtNoiDungThuongVu.Text = txtNoiDungThuongVu.Text.Replace("; " + chkcmbDieuChinh.Properties.Items[i].ToString(), "");
                            txtNoiDungThuongVu.Text = txtNoiDungThuongVu.Text.Replace(chkcmbDieuChinh.Properties.Items[i].ToString() + "; ", "");
                            txtNoiDungThuongVu.Text = txtNoiDungThuongVu.Text.Replace(chkcmbDieuChinh.Properties.Items[i].ToString(), "");
                        }
                }
            }
        }

        private void chkcmbKhieuNai_EditValueChanged(object sender, EventArgs e)
        {
            if (chkcmbKhieuNai.Properties.Items.Count > 0)
            {
                for (int i = 0; i < chkcmbKhieuNai.Properties.Items.Count; i++)
                    if (chkcmbKhieuNai.Properties.Items[i].CheckState == CheckState.Checked && txtNoiDungThuongVu.Text.Trim().Contains(chkcmbKhieuNai.Properties.Items[i].ToString()) == false)
                    {
                        if (txtNoiDungThuongVu.Text.Trim() == "")
                            txtNoiDungThuongVu.Text = chkcmbKhieuNai.Properties.Items[i].ToString();
                        else
                            txtNoiDungThuongVu.Text += "; " + chkcmbKhieuNai.Properties.Items[i].ToString();
                    }
                    else
                        if (chkcmbKhieuNai.Properties.Items[i].CheckState == CheckState.Unchecked && txtNoiDungThuongVu.Text.Trim().Contains(chkcmbKhieuNai.Properties.Items[i].ToString()) == true)
                        {
                            txtNoiDungThuongVu.Text = txtNoiDungThuongVu.Text.Replace("; " + chkcmbKhieuNai.Properties.Items[i].ToString(), "");
                            txtNoiDungThuongVu.Text = txtNoiDungThuongVu.Text.Replace(chkcmbKhieuNai.Properties.Items[i].ToString() + "; ", "");
                            txtNoiDungThuongVu.Text = txtNoiDungThuongVu.Text.Replace(chkcmbKhieuNai.Properties.Items[i].ToString(), "");
                        }
            }
        }

        private void chkcmbDHN_EditValueChanged(object sender, EventArgs e)
        {
            if (chkcmbDHN.Properties.Items.Count > 0)
            {
                for (int i = 0; i < chkcmbDHN.Properties.Items.Count; i++)
                    if (chkcmbDHN.Properties.Items[i].CheckState == CheckState.Checked && txtNoiDungThuongVu.Text.Trim().Contains(chkcmbDHN.Properties.Items[i].ToString()) == false)
                    {
                        if (txtNoiDungThuongVu.Text.Trim() == "")
                            txtNoiDungThuongVu.Text = chkcmbDHN.Properties.Items[i].ToString();
                        else
                            txtNoiDungThuongVu.Text += "; " + chkcmbDHN.Properties.Items[i].ToString();
                    }
                    else
                        if (chkcmbDHN.Properties.Items[i].CheckState == CheckState.Unchecked && txtNoiDungThuongVu.Text.Trim().Contains(chkcmbDHN.Properties.Items[i].ToString()) == true)
                        {
                            txtNoiDungThuongVu.Text = txtNoiDungThuongVu.Text.Replace("; " + chkcmbDHN.Properties.Items[i].ToString(), "");
                            txtNoiDungThuongVu.Text = txtNoiDungThuongVu.Text.Replace(chkcmbDHN.Properties.Items[i].ToString() + "; ", "");
                            txtNoiDungThuongVu.Text = txtNoiDungThuongVu.Text.Replace(chkcmbDHN.Properties.Items[i].ToString(), "");
                        }
            }
        }

        private void chkcmbQuanLy_EditValueChanged(object sender, EventArgs e)
        {
            if (chkcmbQuanLy.Properties.Items.Count > 0)
            {
                for (int i = 0; i < chkcmbQuanLy.Properties.Items.Count; i++)
                    if (chkcmbQuanLy.Properties.Items[i].CheckState == CheckState.Checked && txtNoiDungThuongVu.Text.Trim().Contains(chkcmbQuanLy.Properties.Items[i].ToString()) == false)
                    {
                        if (txtNoiDungThuongVu.Text.Trim() == "")
                            txtNoiDungThuongVu.Text = chkcmbQuanLy.Properties.Items[i].ToString();
                        else
                            txtNoiDungThuongVu.Text += "; " + chkcmbQuanLy.Properties.Items[i].ToString();
                    }
                    else
                        if (chkcmbQuanLy.Properties.Items[i].CheckState == CheckState.Unchecked && txtNoiDungThuongVu.Text.Trim().Contains(chkcmbQuanLy.Properties.Items[i].ToString()) == true)
                        {
                            txtNoiDungThuongVu.Text = txtNoiDungThuongVu.Text.Replace("; " + chkcmbQuanLy.Properties.Items[i].ToString(), "");
                            txtNoiDungThuongVu.Text = txtNoiDungThuongVu.Text.Replace(chkcmbQuanLy.Properties.Items[i].ToString() + "; ", "");
                            txtNoiDungThuongVu.Text = txtNoiDungThuongVu.Text.Replace(chkcmbQuanLy.Properties.Items[i].ToString(), "");
                        }
            }
        }

        private void dgvLichSuDonTu_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {
                    if (dgvLichSuDonTu.Columns[e.ColumnIndex].Name == "Huy")
                    {
                        _dontu_LichSu.Huy = bool.Parse(dgvLichSuDonTu["Huy", e.RowIndex].Value.ToString());
                        _dontu_LichSu.NgayHuy = DateTime.Now;
                        _cDonTu.SubmitChanges();
                        Clear();
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
