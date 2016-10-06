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
using KTKS_DonKH.DAL.KiemTraXacMinh;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.GUI.KiemTraXacMinh
{
    public partial class frmDongTienBoiThuong : Form
    {
        int _selectedindex = -1;
        CHienTrangKiemTra _cHienTrangKiemTra = new CHienTrangKiemTra();
        CKTXM _cKTXM = new CKTXM();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        public frmDongTienBoiThuong()
        {
            InitializeComponent();
        }

        private void frmDongTienBoiThuong_Load(object sender, EventArgs e)
        {
            dgvDSKetQuaKiemTra.AutoGenerateColumns = false;
            dgvDSKetQuaKiemTra.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSKetQuaKiemTra.Font, FontStyle.Bold);

            cmbHienTrangKiemTra.DataSource = _cHienTrangKiemTra.LoadDSHienTrangKiemTra(true);
            cmbHienTrangKiemTra.DisplayMember = "TenHTKT";
            cmbHienTrangKiemTra.ValueMember = "TenHTKT";
            cmbHienTrangKiemTra.SelectedIndex = -1;
        }

        public void LoadCTKTXM(CTKTXM ctktxm)
        {
            dateKTXM.Value = ctktxm.NgayKTXM.Value;

            txtHieu.Text = ctktxm.Hieu;
            txtCo.Text = ctktxm.Co;
            txtSoThan.Text = ctktxm.SoThan;
            txtChiSo.Text = ctktxm.ChiSo;
            cmbTinhTrangChiSo.SelectedItem = ctktxm.TinhTrangChiSo;
            cmbChiMatSo.SelectedItem = ctktxm.ChiMatSo;
            cmbChiKhoaGoc.SelectedItem = ctktxm.ChiKhoaGoc;
            txtMucDichSuDung.Text = ctktxm.MucDichSuDung;
            txtDienThoai.Text = ctktxm.DienThoai;
            txtHoTenKHKy.Text = ctktxm.HoTenKHKy;
            cmbTinhTrangDHN.SelectedItem = ctktxm.TinhTrangDHN;
            txtNoiDungKiemTra.Text = ctktxm.NoiDungKiemTra;

            if (ctktxm.LapBangGia)
            {
                chkLapBangGia.Checked = true;
                dateLapBangGia.Value = ctktxm.NgayLapBangGia.Value;
            }
            else
            {
                chkLapBangGia.Checked = false;
                dateLapBangGia.Value = DateTime.Now;
            }

            if (ctktxm.DongTienBoiThuong)
            {
                chkDongTienBoiThuong.Checked = true;
                cmbNoiDung.SelectedItem = ctktxm.NoiDung;
                dateDongTien.Value = ctktxm.NgayDongTien.Value;
                txtSoTien.Text = ctktxm.SoTien.ToString();
            }
            else
            {
                chkDongTienBoiThuong.Checked = false;
                cmbNoiDung.SelectedIndex = -1;
                dateDongTien.Value = DateTime.Now;
                txtSoTien.Text = "";
            }

            if (ctktxm.ChuyenLapTBCat)
            {
                chkChuyenCatHuy.Checked = true;
                dateChuyenCatHuy.Value = ctktxm.NgayChuyenLapTBCat.Value;
            }
            else
            {
                chkChuyenCatHuy.Checked = false;
                dateChuyenCatHuy.Value = DateTime.Now;
            }
            cmbHienTrangKiemTra.SelectedValue = ctktxm.HienTrangKiemTra;
        }

        public void Clear()
        {
            try
            {

            
            //dateKTXM.Value = DateTime.Now;
            //cmbTinhTrangKiemTra.SelectedIndex = -1;
            txtHieu.Text = "";
            txtCo.Text = "";
            txtSoThan.Text = "";
            txtChiSo.Text = "";
            cmbTinhTrangChiSo.SelectedIndex = -1;
            //cmbChiMatSo.SelectedIndex = -1;
            //cmbChiKhoaGoc.SelectedIndex = -1;
            txtMucDichSuDung.Text = "";
            txtDienThoai.Text = "";
            txtHoTenKHKy.Text = "";
            //cmbTinhTrangDHN.SelectedIndex = -1;
            txtNoiDungKiemTra.Text = "";
            ///
            chkLapBangGia.Checked = false;
            dateLapBangGia.Value = DateTime.Now;
            ///
            chkDongTienBoiThuong.Checked = false;
            cmbNoiDung.SelectedIndex = -1;
            dateDongTien.Value = DateTime.Now;
            txtSoTien.Text = "";
            ///
            chkChuyenCatHuy.Checked = false;
            dateChuyenCatHuy.Value = DateTime.Now;
            _selectedindex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo.Text.Trim() != "")
            {
                Clear();
                dgvDSKetQuaKiemTra.DataSource = _cKTXM.LoadDSCTKTXM(txtDanhBo.Text.Trim());
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedindex != -1)
            {
                if (_cKTXM.CheckCTKTXMbyID(decimal.Parse(dgvDSKetQuaKiemTra["MaCTKTXM", _selectedindex].Value.ToString())))
                {
                    CTKTXM ctktxm = _cKTXM.getCTKTXMbyID(decimal.Parse(dgvDSKetQuaKiemTra["MaCTKTXM", _selectedindex].Value.ToString()));

                    if (ctktxm.LapBangGia != chkLapBangGia.Checked)
                        if (chkLapBangGia.Checked)
                        {
                            ctktxm.LapBangGia = true;
                            ctktxm.NgayLapBangGia = dateLapBangGia.Value;
                        }
                        else
                        {
                            ctktxm.LapBangGia = false;
                            ctktxm.NgayLapBangGia = null;
                        }
                    
                    if (ctktxm.DongTienBoiThuong != chkDongTienBoiThuong.Checked)
                        if (chkDongTienBoiThuong.Checked)
                        {
                            ctktxm.DongTienBoiThuong = true;
                            ctktxm.NoiDung = cmbNoiDung.SelectedItem.ToString();
                            ctktxm.NgayDongTien = dateDongTien.Value;
                            ctktxm.SoTien = txtSoTien.Text.Trim();
                        }
                        else
                        {
                            ctktxm.DongTienBoiThuong = false;
                            ctktxm.NoiDung = null;
                            ctktxm.NgayDongTien = null;
                            ctktxm.SoTien = null;
                        }

                    if (ctktxm.ChuyenLapTBCat != chkChuyenCatHuy.Checked)
                        if (chkChuyenCatHuy.Checked)
                        {
                            ctktxm.ChuyenLapTBCat = true;
                            ctktxm.NgayChuyenLapTBCat = dateChuyenCatHuy.Value;
                        }
                        else
                        {
                            ctktxm.ChuyenLapTBCat = false;
                            ctktxm.NgayChuyenLapTBCat = null;
                        }

                    if (_cKTXM.SuaCTKTXM(ctktxm))
                    {
                        MessageBox.Show("Cập Nhật Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                        dgvDSKetQuaKiemTra.DataSource = _cKTXM.LoadDSCTKTXM(txtDanhBo.Text.Trim(), CTaiKhoan.MaUser);
                    }
                }
            }
            else
                MessageBox.Show("Chưa chọn Biên Bản Kiểm Tra", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void chkLapBangGia_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLapBangGia.Checked)
                groupBoxLapBangGia.Enabled = true;
            else
                groupBoxLapBangGia.Enabled = false;
        }

        private void chkDongTienBoiThuong_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDongTienBoiThuong.Checked)
            {
                cmbNoiDung.SelectedIndex = 0;
                groupBoxDongTienBoiThuong.Enabled = true;
            }
            else
            {
                cmbNoiDung.SelectedIndex = -1;
                groupBoxDongTienBoiThuong.Enabled = false;
            }
        }

        private void chkChuyenCatHuy_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChuyenCatHuy.Checked)
                groupBoxChuyenCatHuy.Enabled = true;
            else
                groupBoxChuyenCatHuy.Enabled = false;
        }

        private void txtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            //    e.Handled = true;
        }

        private void dgvDSKetQuaKiemTra_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSKetQuaKiemTra.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSKetQuaKiemTra_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSKetQuaKiemTra.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void dgvDSKetQuaKiemTra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _selectedindex = e.RowIndex;
                LoadCTKTXM(_cKTXM.getCTKTXMbyID(decimal.Parse(dgvDSKetQuaKiemTra["MaCTKTXM", e.RowIndex].Value.ToString())));
            }
            catch (Exception)
            {
            }
        }
    }
}
