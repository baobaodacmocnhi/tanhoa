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
    public partial class frmCatChuyenDM : Form
    {
        Dictionary<string, string> _source = new Dictionary<string, string>();
        CChiNhanh _cChiNhanh = new CChiNhanh();
        CLoaiChungTu _cLoaiChungTu = new CLoaiChungTu();

        public frmCatChuyenDM()
        {
            InitializeComponent();
        }

        public frmCatChuyenDM(Dictionary<string, string> source)
        {
            InitializeComponent();
            _source = source;
        }

        private void frmCatChuyenDM_Load(object sender, EventArgs e)
        {
            this.Location = new Point(70, 70);
            cmbChiNhanh_Cat.DataSource = _cChiNhanh.LoadDSChiNhanh();
            cmbChiNhanh_Cat.DisplayMember = "TenCN";
            cmbChiNhanh_Cat.ValueMember = "MaCN";

            cmbCN_Nhan.DataSource = _cChiNhanh.LoadDSChiNhanh();
            cmbCN_Nhan.DisplayMember = "TenCN";
            cmbCN_Nhan.ValueMember = "MaCN";

            cmbLoaiCT_Cat.DataSource = _cLoaiChungTu.LoadDSLoaiChungTu();
            cmbLoaiCT_Cat.DisplayMember = "TenLCT";
            cmbLoaiCT_Cat.ValueMember = "MaLCT";

            txtDanhBo_Cat.Text=_source["DanhBo"];
            txtKhachHang_Cat.Text = _source["HoTen"];
            txtDiaChi_Cat.Text = _source["DiaChi"];
            cmbLoaiCT_Cat.SelectedValue = int.Parse(_source["MaLCT"]);
            txtMaCT_Cat.Text = _source["MaCT"];
        }


    }
}
