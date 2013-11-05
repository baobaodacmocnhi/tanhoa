using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.CapNhat;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmSoDK : Form
    {
        CLoaiChungTu _cLoaiChungTu = new CLoaiChungTu();
        Dictionary<string, string> _source = new Dictionary<string, string>();
        bool flagFirst = false;

        public frmSoDK()
        {
            InitializeComponent();
        }

        public frmSoDK(string action, Dictionary<string, string> source)
        {
            InitializeComponent();
            ///Check để chọn chức năng Thêm hoặc Sửa
            if (action == "Thêm")
            {
                cmbLoaiCT.Enabled = true;
                txtMaCT.ReadOnly = false;
                txtSoNKTong.ReadOnly = false;
                txtSoNKDangKy.ReadOnly = false;
                txtThoiHan.ReadOnly = false;
                btnThem.Enabled = true;
            }
            else
                if (action == "Sửa")
                {
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
            cmbLoaiCT.SelectedIndex = -1;

            txtDanhBo.Text = _source["DanhBo"];
            cmbLoaiCT.SelectedValue = int.Parse(_source["MaLCT"]);
            txtMaCT.Text = _source["MaCT"];
            txtSoNKTong.Text = _source["SoNKTong"];
            txtSoNKDangKy.Text = _source["SoNKDangKy"];
            txtThoiHan.Text = _source["ThoiHan"];

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
           
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cmbLoaiCT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(flagFirst)
            if (cmbLoaiCT.SelectedIndex > -1)
            {
                //txtThoiHan.Text = _cLoaiChungTu.getLoaiChungTubyID(int.Parse(cmbLoaiCT.SelectedValue.ToString())).ThoiHan.ToString();
                MessageBox.Show(cmbLoaiCT.SelectedValue.ToString());
            }
        }
    }
}
