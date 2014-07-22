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
using KTKS_DonKH.DAL.HeThong;

namespace KTKS_DonKH.GUI.KiemTraXacMinh
{
    public partial class frmDongTienBoiThuong : Form
    {
        int selectedindex = -1;
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
            if (ctktxm.DongTienBoiThuong)
            {
                chkDongTienBoiThuong.Checked = true;
                dateDongTien.Value = ctktxm.NgayDongTien.Value;
                txtSoTien.Text = ctktxm.SoTien.ToString();
            }
            cmbHienTrangKiemTra.SelectedValue = ctktxm.HienTrangKiemTra;
        }

        public void Clear()
        {
            txtNoiDungKiemTra.Text = "";
            ///
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
            chkDongTienBoiThuong.Checked = false;
            dateDongTien.Value = DateTime.Now;
            txtSoTien.Text = "";
            selectedindex = -1;
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo.Text.Trim() != "")
            {
                dgvDSKetQuaKiemTra.DataSource = _cKTXM.LoadDSCTKTXM(txtDanhBo.Text.Trim(), CTaiKhoan.MaUser);
            }
        }

        private void dgvDSKetQuaKiemTra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedindex = e.RowIndex;
                LoadCTKTXM(_cKTXM.getCTKTXMbyID(decimal.Parse(dgvDSKetQuaKiemTra["MaCTKTXM", e.RowIndex].Value.ToString())));
            }
            catch (Exception)
            {
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedindex != -1)
            {
                if (_cKTXM.CheckCTKTXMbyID(decimal.Parse(dgvDSKetQuaKiemTra["MaCTKTXM", selectedindex].Value.ToString())))
                {
                    CTKTXM ctktxm = _cKTXM.getCTKTXMbyID(decimal.Parse(dgvDSKetQuaKiemTra["MaCTKTXM", selectedindex].Value.ToString()));
                    if (chkDongTienBoiThuong.Checked)
                    {
                        ctktxm.DongTienBoiThuong = true;
                        ctktxm.NgayDongTien = dateDongTien.Value;
                        if (!string.IsNullOrEmpty(txtSoTien.Text.Trim()))
                            ctktxm.SoTien = int.Parse(txtSoTien.Text.Trim());
                    }
                    else
                    {
                        ctktxm.DongTienBoiThuong = false;
                        ctktxm.NgayDongTien = null;
                        ctktxm.SoTien = null;
                    }
                    if (_cKTXM.SuaCTKTXM(ctktxm))
                    {
                        MessageBox.Show("Cập Nhật Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                        dgvDSKetQuaKiemTra.DataSource = _cKTXM.LoadDSCTKTXM(txtDanhBo.Text.Trim(), CTaiKhoan.MaUser);
                    }
                }
            }
            MessageBox.Show("Chưa chọn Biên Bản Kiểm Tra", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void chkDongTienBoiThuong_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDongTienBoiThuong.Checked)
                groupDongTienBoiThuong.Enabled = true;
            else
                groupDongTienBoiThuong.Enabled = false;
        }

        private void txtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
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
    }
}
