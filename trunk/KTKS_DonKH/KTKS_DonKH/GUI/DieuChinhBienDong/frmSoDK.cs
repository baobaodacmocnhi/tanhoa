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

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmSoDK : Form
    {
        CLoaiChungTu _cLoaiChungTu = new CLoaiChungTu();
        CChungTu _cChungTu = new CChungTu();
        Dictionary<string, string> _source = new Dictionary<string, string>();
        string _action = "";

        public frmSoDK()
        {
            InitializeComponent();
        }

        public frmSoDK(string action, Dictionary<string, string> source)
        {
            InitializeComponent();
            ///Check để chọn chức năng Thêm hoặc Sửa
            _action = action;
            if (action == "Thêm")
            {
                cmbLoaiCT.Enabled = true;
                txtMaCT.ReadOnly = false;
                txtDiaChi.ReadOnly = false;
                txtSoNKTong.ReadOnly = false;
                txtSoNKDangKy.ReadOnly = false;
                txtThoiHan.ReadOnly = false;
                btnThem.Enabled = true;
            }
            else
                if (action == "Sửa")
                {
                    txtDiaChi.ReadOnly = false;
                    txtSoNKTong.ReadOnly = false;
                    txtSoNKDangKy.ReadOnly = false;
                    txtThoiHan.ReadOnly = false;
                    btnSua.Enabled = true;
                }
            _source = source;
        }

        private void frmSoDK_Load(object sender, EventArgs e)
        {
            this.Location = new Point(70, 70);
            cmbLoaiCT.DataSource = _cLoaiChungTu.LoadDSLoaiChungTu(true);
            cmbLoaiCT.DisplayMember = "TenLCT";
            cmbLoaiCT.ValueMember = "MaLCT";

            txtDanhBo.Text = _source["DanhBo"];
            cmbLoaiCT.SelectedValue = int.Parse(_source["MaLCT"]);
            txtMaCT.Text = _source["MaCT"];
            txtSoNKTong.Text = _source["SoNKTong"];
            txtSoNKDangKy.Text = _source["SoNKDangKy"];
            txtThoiHan.Text = _source["ThoiHan"];

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtSoNKTong.Text.Trim()) >= int.Parse(txtSoNKTong.Text.Trim()))
            {
                ChungTu chungtu = new ChungTu();
                chungtu.MaCT = txtMaCT.Text.Trim();
                chungtu.DiaChi = txtDiaChi.Text.Trim();
                chungtu.SoNKTong = int.Parse(txtSoNKTong.Text.Trim());
                chungtu.MaLCT = int.Parse(cmbLoaiCT.SelectedValue.ToString());

                CTChungTu ctchungtu = new CTChungTu();
                ctchungtu.DanhBo = txtDanhBo.Text.Trim();
                ctchungtu.MaCT = txtMaCT.Text.Trim();
                ctchungtu.SoNKDangKy = int.Parse(txtSoNKDangKy.Text.Trim());
                if (txtThoiHan.Text.Trim() != "")
                    ctchungtu.ThoiHan = int.Parse(txtThoiHan.Text.Trim());
                else
                    ctchungtu.ThoiHan = null;
                
                if (_cChungTu.ThemChungTu(chungtu, ctchungtu))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
                MessageBox.Show("Số Nhân Khẩu đăng ký vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtSoNKTong.Text.Trim()) >= int.Parse(txtSoNKTong.Text.Trim()))
            {
                ChungTu chungtu = new ChungTu();
                chungtu.MaCT = txtMaCT.Text.Trim();
                chungtu.DiaChi = txtDiaChi.Text.Trim();
                chungtu.SoNKTong = int.Parse(txtSoNKTong.Text.Trim());

                CTChungTu ctchungtu = new CTChungTu();
                ctchungtu.DanhBo = txtDanhBo.Text.Trim();
                ctchungtu.MaCT = txtMaCT.Text.Trim();
                ctchungtu.SoNKDangKy = int.Parse(txtSoNKDangKy.Text.Trim());
                if (txtThoiHan.Text.Trim() != "")
                    ctchungtu.ThoiHan = int.Parse(txtThoiHan.Text.Trim());
                else
                    ctchungtu.ThoiHan = null;

                if (_cChungTu.SuaChungTu(chungtu, ctchungtu))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
                MessageBox.Show("Số Nhân Khẩu đăng ký vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cmbLoaiCT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_action == "Thêm" && cmbLoaiCT.SelectedIndex != -1)
            {
                txtThoiHan.Text = ((KTKS_DonKH.LinQ.LoaiChungTu)cmbLoaiCT.SelectedItem).ThoiHan.ToString();
            }
        }

        private void txtMaCT_Leave(object sender, EventArgs e)
        {
            if (_cChungTu.CheckCTChungTu(txtDanhBo.Text.Trim(), txtMaCT.Text.Trim()))
                    MessageBox.Show("Số đăng ký này đã có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtMaCT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtSoNKTong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtSoNKDangKy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtThoiHan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
