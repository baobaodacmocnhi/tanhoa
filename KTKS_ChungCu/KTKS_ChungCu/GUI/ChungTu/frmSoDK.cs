using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_ChungCu.DAL;
using KTKS_ChungCu.LinQ;

namespace KTKS_ChungCu.GUI.ChungTu
{
    public partial class frmSoDK : Form
    {
        //string _DanhBo = "", _MaCT = "";
        int _ID = 0;
        CChiNhanh _cChiNhanh = new CChiNhanh();
        //CTChungTu _ctchungtu = new CTChungTu();
        CLoaiChungTu _cLoaiChungTu = new CLoaiChungTu();
        CChungTu _cChungTu = new CChungTu();
        DanhSachChungTu _dsct = new DanhSachChungTu();
        CDanhSachChungTu _cDSCT = new CDanhSachChungTu();

        public frmSoDK()
        {
            InitializeComponent();
        }

        public frmSoDK(int ID)
        {
            InitializeComponent();
            _ID = ID;
        }

        public frmSoDK(string DanhBo,string MaCT)
        {
            InitializeComponent();
            //_DanhBo = DanhBo;
            //_MaCT = MaCT;
        }

        private void frmSoDK_Load(object sender, EventArgs e)
        {
            dgvDSDanhBo.AutoGenerateColumns = false;
            dgvDSDanhBo.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSDanhBo.Font, FontStyle.Bold);
            try
            {
                this.Location = new Point(70, 70);
                _dsct = _cDSCT.Get(_ID);
                if (_dsct.YeuCauCat2)
                    this.Location = new Point(10, 70);
                cmbLoaiCT.DataSource = _cLoaiChungTu.LoadDSLoaiChungTu(true);
                cmbLoaiCT.DisplayMember = "TenLCT";
                cmbLoaiCT.ValueMember = "MaLCT";

                txtDanhBo.Text = _dsct.DanhBo;
                cmbLoaiCT.SelectedValue = _dsct.MaLCT;
                txtMaCT.Text = _dsct.MaCT;
                txtHoTenCT.Text = _dsct.HoTen;

                txtHoTen_Cat_YCC1.Text = txtHoTenCT.Text;
                txtHoTen_Cat_YCC2.Text = txtHoTenCT.Text;
                txtHoTen_Cat_YCC3.Text = txtHoTenCT.Text;
                txtHoTen_Cat_YCC4.Text = txtHoTenCT.Text;
                txtHoTen_Cat_YCC5.Text = txtHoTenCT.Text;

                txtGhiChu.Text = _dsct.GhiChu;
                txtSoNKTong.Text = _dsct.SoNKTong.ToString();
                txtSoNKDangKy.Text = _dsct.SoNKDangKy.ToString();
                txtSTT.Text = _dsct.STT.ToString();
                txtLo.Text = _dsct.Lo;
                txtPhong.Text = _dsct.Phong;

                cmbChiNhanh_YCC1.DataSource = _cChiNhanh.LoadDSChiNhanh(true);
                cmbChiNhanh_YCC1.DisplayMember = "TenCN";
                cmbChiNhanh_YCC1.ValueMember = "MaCN";

                cmbChiNhanh_YCC2.DataSource = _cChiNhanh.LoadDSChiNhanh(true);
                cmbChiNhanh_YCC2.DisplayMember = "TenCN";
                cmbChiNhanh_YCC2.ValueMember = "MaCN";

                cmbChiNhanh_YCC3.DataSource = _cChiNhanh.LoadDSChiNhanh(true);
                cmbChiNhanh_YCC3.DisplayMember = "TenCN";
                cmbChiNhanh_YCC3.ValueMember = "MaCN";

                cmbChiNhanh_YCC4.DataSource = _cChiNhanh.LoadDSChiNhanh(true);
                cmbChiNhanh_YCC4.DisplayMember = "TenCN";
                cmbChiNhanh_YCC4.ValueMember = "MaCN";

                cmbChiNhanh_YCC5.DataSource = _cChiNhanh.LoadDSChiNhanh(true);
                cmbChiNhanh_YCC5.DisplayMember = "TenCN";
                cmbChiNhanh_YCC5.ValueMember = "MaCN";

                if (_dsct.YeuCauCat)
                {
                    chkYCCat1.Checked = true;
                    cmbChiNhanh_YCC1.SelectedValue = _dsct.CatNK_MaCN;
                    txtDanhBo_Cat_YCC1.Text = _dsct.CatNK_DanhBo;
                    txtHoTen_Cat_YCC1.Text = _dsct.CatNK_HoTen;
                    txtDiaChiKH_Cat_YCC1.Text = _dsct.CatNK_DiaChi;
                    txtSoNKCat_YCC1.Text = _dsct.CatNK_SoNKCat.ToString();
                    txtMaCT_YCC1.Text = _dsct.CatNK_MaCT;
                    txtGhiChu_YCC1.Text = _dsct.CatNK_GhiChu;
                }
                if (_dsct.YeuCauCat2)
                {
                    panel_YCCat2.Visible = true;
                    this.Size = new Size(1370, 356);
                    this.Location = new Point(10, 70);
                    ///
                    chkYCCat2.Checked = true;
                    cmbChiNhanh_YCC2.SelectedValue = _dsct.CatNK_MaCN2;
                    txtDanhBo_Cat_YCC2.Text = _dsct.CatNK_DanhBo2;
                    txtHoTen_Cat_YCC2.Text = _dsct.CatNK_HoTen2;
                    txtDiaChiKH_Cat_YCC2.Text = _dsct.CatNK_DiaChi2;
                    txtSoNKCat_YCC2.Text = _dsct.CatNK_SoNKCat2.ToString();
                    txtMaCT_YCC2.Text = _dsct.CatNK_MaCT2;
                    txtGhiChu_YCC2.Text = _dsct.CatNK_GhiChu2;
                }
                if (_dsct.YeuCauCat3)
                {
                    panel_YCCat3.Visible = true;
                    this.Size = new Size(1370, 477);
                    ///
                    chkYCCat3.Checked = true;
                    cmbChiNhanh_YCC3.SelectedValue = _dsct.CatNK_MaCN3;
                    txtDanhBo_Cat_YCC3.Text = _dsct.CatNK_DanhBo3;
                    txtHoTen_Cat_YCC3.Text = _dsct.CatNK_HoTen3;
                    txtDiaChiKH_Cat_YCC3.Text = _dsct.CatNK_DiaChi3;
                    txtSoNKCat_YCC3.Text = _dsct.CatNK_SoNKCat3.ToString();
                    txtMaCT_YCC3.Text = _dsct.CatNK_MaCT3;
                    txtGhiChu_YCC3.Text = _dsct.CatNK_GhiChu3;
                }
                if (_dsct.YeuCauCat4)
                {
                    panel_YCCat4.Visible = true;
                    this.Size = new Size(1370, 477);
                    ///
                    chkYCCat4.Checked = true;
                    cmbChiNhanh_YCC4.SelectedValue = _dsct.CatNK_MaCN4;
                    txtDanhBo_Cat_YCC4.Text = _dsct.CatNK_DanhBo4;
                    txtHoTen_Cat_YCC4.Text = _dsct.CatNK_HoTen4;
                    txtDiaChiKH_Cat_YCC4.Text = _dsct.CatNK_DiaChi4;
                    txtSoNKCat_YCC4.Text = _dsct.CatNK_SoNKCat4.ToString();
                    txtMaCT_YCC4.Text = _dsct.CatNK_MaCT4;
                    txtGhiChu_YCC4.Text = _dsct.CatNK_GhiChu4;
                }
                if (_dsct.YeuCauCat5)
                {
                    panel_YCCat5.Visible = true;
                    this.Size = new Size(1370, 515);
                    ///
                    chkYCCat5.Checked = true;
                    cmbChiNhanh_YCC5.SelectedValue = _dsct.CatNK_MaCN5;
                    txtDanhBo_Cat_YCC5.Text = _dsct.CatNK_DanhBo5;
                    txtHoTen_Cat_YCC5.Text = _dsct.CatNK_HoTen5;
                    txtDiaChiKH_Cat_YCC5.Text = _dsct.CatNK_DiaChi5;
                    txtSoNKCat_YCC5.Text = _dsct.CatNK_SoNKCat5.ToString();
                    txtMaCT_YCC5.Text = _dsct.CatNK_MaCT5;
                    txtGhiChu_YCC5.Text = _dsct.CatNK_GhiChu5;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnYCCat_Click(object sender, EventArgs e)
        {
            if (!panel_YCCat2.Visible)
            {
                panel_YCCat2.Visible = true;
                this.Size = new Size(1370, 478);
                this.Location = new Point(10, 70);
            }
            else
                if (!panel_YCCat3.Visible)
                {
                    panel_YCCat3.Visible = true;
                    this.Size = new Size(1370, 478);
                }
                else
                    if (!panel_YCCat4.Visible)
                    {
                        panel_YCCat4.Visible = true;
                        this.Size = new Size(1370, 478);
                    }
                    else
                        if (!panel_YCCat5.Visible)
                        {
                            panel_YCCat5.Visible = true;
                            this.Size = new Size(1370, 692);
                        }
                        else
                        {
                            panel_YCCat2.Visible = false;
                            panel_YCCat3.Visible = false;
                            panel_YCCat4.Visible = false;
                            panel_YCCat5.Visible = false;
                            this.Size = new Size(919, 510);
                            this.Location = new Point(70, 70);
                        }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //LinQ.ChungTu chungtu = new LinQ.ChungTu();
            //chungtu.MaCT = txtMaCT.Text.Trim();
            //chungtu.DiaChi = txtDiaChi.Text.Trim();
            //chungtu.HoTen = txtHoTenCT.Text.Trim();
            //chungtu.MaLCT = int.Parse(cmbLoaiCT.SelectedValue.ToString());
            //chungtu.SoNKTong = int.Parse(txtSoNKTong.Text.Trim());

            //CTChungTu ctchungtu = new CTChungTu();
            //ctchungtu.STT = int.Parse(txtSTT.Text.Trim());
            //ctchungtu.DanhBo = txtDanhBo.Text.Trim();
            //ctchungtu.MaCT = txtMaCT.Text.Trim();
            //ctchungtu.SoNKDangKy = int.Parse(txtSoNKDangKy.Text.Trim());

            //ctchungtu.GhiChu = txtGhiChu.Text.Trim();
            //ctchungtu.Phong = txtPhong.Text.Trim();

            LichSuChungTu lichsuchungtu = new LichSuChungTu();
            lichsuchungtu.STT = int.Parse(txtSTT.Text.Trim());
            lichsuchungtu.Lo = txtLo.Text.Trim();
            lichsuchungtu.Phong = txtPhong.Text.Trim();
            lichsuchungtu.ID_DSChungTu = _dsct.ID;

            if (chkYCCat1.Checked)
                if (txtSoNKCat_YCC1.Text.Trim() == "")
                {
                    MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    /////Cập nhật cái mới nhất(cuối cùng)
                    //chungtu.YeuCauCat = true;
                    //chungtu.CatNK_MaCN = int.Parse(cmbChiNhanh_YCC1.SelectedValue.ToString());
                    //chungtu.CatNK_DanhBo = txtDanhBo_Cat_YCC1.Text.Trim();
                    //chungtu.CatNK_HoTen = txtHoTen_Cat_YCC1.Text.Trim();
                    //chungtu.CatNK_DiaChi = txtDiaChiKH_Cat_YCC1.Text.Trim();
                    //chungtu.CatNK_SoNKCat = int.Parse(txtSoNKCat_YCC1.Text.Trim());
                    ///Chi tiết liên quan đến Danh Bộ nào
                    _dsct.YeuCauCat = true;
                    _dsct.CatNK_MaCN = int.Parse(cmbChiNhanh_YCC1.SelectedValue.ToString());
                    _dsct.CatNK_DanhBo = txtDanhBo_Cat_YCC1.Text.Trim();
                    _dsct.CatNK_HoTen = txtHoTen_Cat_YCC1.Text.Trim();
                    _dsct.CatNK_DiaChi = txtDiaChiKH_Cat_YCC1.Text.Trim();
                    _dsct.CatNK_SoNKCat = int.Parse(txtSoNKCat_YCC1.Text.Trim());
                    _dsct.CatNK_GhiChu = txtGhiChu_YCC1.Text.Trim();
                    _dsct.CatNK_MaCT = txtMaCT_YCC1.Text.Trim();
                    _dsct.SoLuongDC_YCC = 1;
                    ///
                    lichsuchungtu.YeuCauCat = true;
                    lichsuchungtu.NhanNK_DanhBo = txtDanhBo.Text.Trim();
                    lichsuchungtu.NhanNK_HoTen = _dsct.HoTen;
                    lichsuchungtu.PhieuDuocKy = true;
                }
            else
            {
                //chungtu.YeuCauCat = false;
                _dsct.YeuCauCat = false;
            }

            #region Yêu Cầu Cắt 2,3,4,5

            if (chkYCCat2.Checked)
                if (txtSoNKCat_YCC2.Text.Trim() == "")
                {
                    MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC2", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    LichSuChungTu lichsuchungtu2 = lichsuchungtu;
                    ///Chi tiết liên quan đến Danh Bộ nào
                    _dsct.YeuCauCat2 = true;
                    _dsct.CatNK_MaCN2 = int.Parse(cmbChiNhanh_YCC2.SelectedValue.ToString());
                    _dsct.CatNK_DanhBo2 = txtDanhBo_Cat_YCC2.Text.Trim();
                    _dsct.CatNK_HoTen2 = txtHoTen_Cat_YCC2.Text.Trim();
                    _dsct.CatNK_DiaChi2 = txtDiaChiKH_Cat_YCC2.Text.Trim();
                    _dsct.CatNK_SoNKCat2 = int.Parse(txtSoNKCat_YCC2.Text.Trim());
                    _dsct.CatNK_GhiChu2 = txtGhiChu_YCC2.Text.Trim();
                    _dsct.CatNK_MaCT2 = txtMaCT_YCC2.Text.Trim();
                    _dsct.SoLuongDC_YCC = 2;
                    ///
                    lichsuchungtu2.YeuCauCat = true;
                    lichsuchungtu2.NhanNK_DanhBo = txtDanhBo.Text.Trim();
                    lichsuchungtu2.NhanNK_HoTen = _dsct.HoTen;
                    lichsuchungtu2.PhieuDuocKy = true;
                    ///
                }
            else
            {
                _dsct.YeuCauCat2 = false;
            }

            if (chkYCCat3.Checked)
                if (txtSoNKCat_YCC3.Text.Trim() == "")
                {
                    MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC3", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    LichSuChungTu lichsuchungtu3 = lichsuchungtu;
                    ///Chi tiết liên quan đến Danh Bộ nào
                    _dsct.YeuCauCat3 = true;
                    _dsct.CatNK_MaCN3 = int.Parse(cmbChiNhanh_YCC3.SelectedValue.ToString());
                    _dsct.CatNK_DanhBo3 = txtDanhBo_Cat_YCC3.Text.Trim();
                    _dsct.CatNK_HoTen3 = txtHoTen_Cat_YCC3.Text.Trim();
                    _dsct.CatNK_DiaChi3 = txtDiaChiKH_Cat_YCC3.Text.Trim();
                    _dsct.CatNK_SoNKCat3 = int.Parse(txtSoNKCat_YCC3.Text.Trim());
                    _dsct.CatNK_GhiChu3 = txtGhiChu_YCC3.Text.Trim();
                    _dsct.CatNK_MaCT3 = txtMaCT_YCC3.Text.Trim();
                    _dsct.SoLuongDC_YCC = 3;
                    ///
                    lichsuchungtu3.YeuCauCat = true;
                    lichsuchungtu3.NhanNK_DanhBo = txtDanhBo.Text.Trim();
                    lichsuchungtu3.NhanNK_HoTen = _dsct.HoTen;
                    lichsuchungtu3.PhieuDuocKy = true;
                    ///
                }
            else
            {
                _dsct.YeuCauCat3 = false;
            }

            if (chkYCCat4.Checked)
                if (txtSoNKCat_YCC4.Text.Trim() == "")
                {
                    MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC4", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    LichSuChungTu lichsuchungtu4 = lichsuchungtu;
                    ///Chi tiết liên quan đến Danh Bộ nào
                    _dsct.YeuCauCat4 = true;
                    _dsct.CatNK_MaCN4 = int.Parse(cmbChiNhanh_YCC4.SelectedValue.ToString());
                    _dsct.CatNK_DanhBo4 = txtDanhBo_Cat_YCC4.Text.Trim();
                    _dsct.CatNK_HoTen4 = txtHoTen_Cat_YCC4.Text.Trim();
                    _dsct.CatNK_DiaChi4 = txtDiaChiKH_Cat_YCC4.Text.Trim();
                    _dsct.CatNK_SoNKCat4 = int.Parse(txtSoNKCat_YCC4.Text.Trim());
                    _dsct.CatNK_GhiChu4 = txtGhiChu_YCC4.Text.Trim();
                    _dsct.CatNK_MaCT4 = txtMaCT_YCC4.Text.Trim();
                    _dsct.SoLuongDC_YCC = 4;
                    ///
                    lichsuchungtu4.YeuCauCat = true;
                    lichsuchungtu4.NhanNK_DanhBo = txtDanhBo.Text.Trim();
                    lichsuchungtu4.NhanNK_HoTen = _dsct.HoTen;
                    lichsuchungtu4.PhieuDuocKy = true;
                    ///
                }
            else
            {
                _dsct.YeuCauCat4 = false;
            }

            if (chkYCCat5.Checked)
                if (txtSoNKCat_YCC5.Text.Trim() == "")
                {
                    MessageBox.Show("Chưa nhập Số Nhân Khẩu cắt YCC5", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    LichSuChungTu lichsuchungtu5 = lichsuchungtu;
                    ///Chi tiết liên quan đến Danh Bộ nào
                    _dsct.YeuCauCat5 = true;
                    _dsct.CatNK_MaCN5 = int.Parse(cmbChiNhanh_YCC5.SelectedValue.ToString());
                    _dsct.CatNK_DanhBo5 = txtDanhBo_Cat_YCC5.Text.Trim();
                    _dsct.CatNK_HoTen5 = txtHoTen_Cat_YCC5.Text.Trim();
                    _dsct.CatNK_DiaChi5 = txtDiaChiKH_Cat_YCC5.Text.Trim();
                    _dsct.CatNK_SoNKCat5 = int.Parse(txtSoNKCat_YCC5.Text.Trim());
                    _dsct.CatNK_GhiChu5 = txtGhiChu_YCC5.Text.Trim();
                    _dsct.CatNK_MaCT5 = txtMaCT_YCC5.Text.Trim();
                    _dsct.SoLuongDC_YCC = 5;
                    ///
                    lichsuchungtu5.YeuCauCat = true;
                    lichsuchungtu5.NhanNK_DanhBo = txtDanhBo.Text.Trim();
                    lichsuchungtu5.NhanNK_HoTen = _dsct.HoTen;
                    lichsuchungtu5.PhieuDuocKy = true;
                    ///

                }
            else
            {
                _dsct.YeuCauCat5 = false;
            }

            #endregion

            if (_cChungTu.SuaChungTu(_dsct, lichsuchungtu))
            {
                MessageBox.Show("Sửa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void chkYCCat1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkYCCat1.Checked)
            {
                groupBox1.Enabled = true;
            }
            else
            {
                groupBox1.Enabled = false;
            }
        }

        private void chkYCCat2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkYCCat2.Checked)
            {
                groupBox2.Enabled = true;
            }
            else
            {
                groupBox2.Enabled = false;
            }
        }

        private void chkYCCat3_CheckedChanged(object sender, EventArgs e)
        {
            if (chkYCCat3.Checked)
            {
                groupBox3.Enabled = true;
            }
            else
            {
                groupBox3.Enabled = false;
            }
        }

        private void chkYCCat4_CheckedChanged(object sender, EventArgs e)
        {
            if (chkYCCat4.Checked)
            {
                groupBox4.Enabled = true;
            }
            else
            {
                groupBox4.Enabled = false;
            }
        }

        private void chkYCCat5_CheckedChanged(object sender, EventArgs e)
        {
            if (chkYCCat5.Checked)
            {
                groupBox5.Enabled = true;
            }
            else
            {
                groupBox5.Enabled = false;
            }
        }

        private void cmbChiNhanh_YCC1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtDanhBo_Cat_YCC1.Focus();
        }

        private void txtDanhBo_Cat_YCC1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtHoTen_Cat_YCC1.Focus();
        }

        private void txtHoTen_Cat_YCC1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtDiaChiKH_Cat_YCC1.Focus();
        }

        private void txtDiaChiKH_Cat_YCC1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtSoNKCat_YCC1.Focus();
        }

        private void cmbChiNhanh_YCC2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtDanhBo_Cat_YCC2.Focus();
        }

        private void txtDanhBo_Cat_YCC2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtHoTen_Cat_YCC2.Focus();
        }

        private void txtHoTen_Cat_YCC2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtDiaChiKH_Cat_YCC2.Focus();
        }

        private void txtDiaChiKH_Cat_YCC2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtSoNKCat_YCC2.Focus();
        }

        private void txtSoNKCat_YCC2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtGhiChu_YCC2.Focus();
        }

        private void cmbChiNhanh_YCC3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtDanhBo_Cat_YCC3.Focus();
        }

        private void txtDanhBo_Cat_YCC3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtHoTen_Cat_YCC3.Focus();
        }

        private void txtHoTen_Cat_YCC3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtDiaChiKH_Cat_YCC3.Focus();
        }

        private void txtDiaChiKH_Cat_YCC3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtSoNKCat_YCC3.Focus();
        }

        private void txtSoNKCat_YCC3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtGhiChu_YCC3.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void txtSoNKCat_YCC1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtGhiChu_YCC1.Focus();
        }

        private void txtSoNKCat_YCC4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtGhiChu_YCC4.Focus();
        }

        private void txtSoNKCat_YCC5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtGhiChu_YCC5.Focus();
        }


    }
}
