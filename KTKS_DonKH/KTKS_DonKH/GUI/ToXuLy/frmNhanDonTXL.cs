using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.KhachHang;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.ToXuLy
{
    public partial class frmNhanDonTXL : Form
    {
        CPhuongQuan _cPhuongQuan = new CPhuongQuan();
        CTTKH _cTTKH = new CTTKH();
        CLoaiDonTXL _cLoaiDonTXL = new CLoaiDonTXL();
        TTKhachHang _ttkhachhang = null;
        CDonTXL _cDonTXL = new CDonTXL();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        public frmNhanDonTXL()
        {
            InitializeComponent();
        }

        public void LoadTTKH(TTKhachHang ttkhachhang)
        {
            txtHopDong.Text = ttkhachhang.GiaoUoc;
            txtHoTen.Text = ttkhachhang.HoTen;
            txtDiaChi.Text = ttkhachhang.DC1 + " " + ttkhachhang.DC2 + _cPhuongQuan.getPhuongQuanByID(ttkhachhang.Quan, ttkhachhang.Phuong);
            txtMSThue.Text = ttkhachhang.MSThue;
            txtGiaBieu.Text = ttkhachhang.GB;
            txtDinhMuc.Text = ttkhachhang.TGDM;
        }

        public void Clear()
        {
            cmbLD.SelectedIndex = -1;
            txtMaDon.Text = "";
            txtNgayNhan.Text = "";
            txtNoiDung.Text = "";
            txtSoCongVan.Text = "";
            ///
            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtMSThue.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            txtDienThoai.Text = "";
            _ttkhachhang = null;
        }

        private void frmNhanDonTXL_Load(object sender, EventArgs e)
        {
            cmbLD.DataSource = _cLoaiDonTXL.LoadDSLoaiDonTXL(true);
            cmbLD.DisplayMember = "TenLD";
            cmbLD.ValueMember = "MaLD";
            cmbLD.SelectedIndex = -1;

            Clear();
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (_cTTKH.getTTKHbyID(txtDanhBo.Text.Trim()) != null)
                {
                    _ttkhachhang = _cTTKH.getTTKHbyID(txtDanhBo.Text.Trim());
                    LoadTTKH(_ttkhachhang);
                }
                else
                {
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clear();
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbLD.SelectedIndex != -1)
                {
                    DonTXL dontxl = new DonTXL();
                    dontxl.MaDon = _cDonTXL.getMaxNextID();
                    dontxl.MaLD = int.Parse(cmbLD.SelectedValue.ToString());
                    dontxl.SoCongVan = txtSoCongVan.Text.Trim();
                    dontxl.NoiDung = txtNoiDung.Text.Trim();

                    dontxl.DanhBo = txtDanhBo.Text.Trim();
                    dontxl.HopDong = txtHopDong.Text.Trim();
                    dontxl.HoTen = txtHoTen.Text.Trim();
                    dontxl.DiaChi = txtDiaChi.Text.Trim();
                    dontxl.DienThoai = txtDienThoai.Text.Trim();
                    dontxl.MSThue = txtMSThue.Text.Trim();
                    dontxl.GiaBieu = txtGiaBieu.Text.Trim();
                    dontxl.DinhMuc = txtDinhMuc.Text.Trim();
                    if (_ttkhachhang != null)
                    {
                        dontxl.Dot = _ttkhachhang.Dot;
                        dontxl.Ky = _ttkhachhang.Ky;
                        dontxl.Nam = _ttkhachhang.Nam;
                    }

                    if (_cDonTXL.ThemDonTXL(dontxl))
                    {
                        MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                        DataRow dr = dsBaoCao.Tables["BienNhanDonKH"].NewRow();
                        dr["MaDon"] = dontxl.MaDon.ToString().Insert(dontxl.MaDon.ToString().Length - 2, "-");// +"/" + _cLoaiDon.getKyHieuLDubyID(int.Parse(cmbLD.SelectedValue.ToString()));
                        //dr["MaXepDon"] = _cLoaiDon.getKyHieuLDubyID(int.Parse(cmbLD.SelectedValue.ToString()));
                        dr["TenLD"] = cmbLD.Text;
                        dr["KhachHang"] = txtHoTen.Text.Trim();
                        if (txtDanhBo.Text.Trim() != "")
                            dr["DanhBo"] = txtDanhBo.Text.Trim().Insert(7, ".").Insert(4, ".");
                        dr["DiaChi"] = txtDiaChi.Text.Trim();
                        dr["HopDong"] = txtHopDong.Text.Trim();
                        dr["DienThoai"] = txtDienThoai.Text.Trim();

                        dsBaoCao.Tables["BienNhanDonKH"].Rows.Add(dr);
                        rptBienNhanDonKH rpt = new rptBienNhanDonKH();
                        rpt.SetDataSource(dsBaoCao);
                        frmBaoCao frm = new frmBaoCao(rpt);
                        frm.ShowDialog();

                        Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbLD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLD.SelectedIndex != -1)
            {
                txtMaDon.Text = "TXL" + _cDonTXL.getMaxNextID().ToString().Insert(_cDonTXL.getMaxNextID().ToString().Length - 2, "-");
                txtNgayNhan.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        
    }
}
