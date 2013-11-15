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
using KTKS_DonKH.DAL.DieuChinhBienDong;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmDCBD : Form
    {
        DonKH _donkh = new DonKH();
        TTKhachHang _ttkhachhang = new TTKhachHang();
        CLoaiChungTu _cLoaiChungTu = new CLoaiChungTu();
        CChungTu _cChungTu = new CChungTu();
        CTTKH _cTTKH = new CTTKH();

        public frmDCBD()
        {
            InitializeComponent();
        }

        public frmDCBD(DonKH donkh,TTKhachHang ttkhachhang)
        {
            InitializeComponent();
            _donkh = donkh;
            _ttkhachhang = ttkhachhang;
        }

        private void frmDCBD_Load(object sender, EventArgs e)
        {
            this.Location = new Point(70, 70);
            dgvDSSoDangKy.AutoGenerateColumns = false;
            DataGridViewComboBoxColumn cmbColumn = (DataGridViewComboBoxColumn)dgvDSSoDangKy.Columns["MaLCT"];
            cmbColumn.DataSource = _cLoaiChungTu.LoadDSLoaiChungTu(true);
            cmbColumn.DisplayMember = "TenLCT";
            cmbColumn.ValueMember = "MaLCT";

            if (_donkh != null)
                txtMaDon.Text = _donkh.MaDon;
            if (_ttkhachhang != null)
                LoadDS(_ttkhachhang);
        }

        /// <summary>
        /// Nhận Entity DonKH để điền vào textbox
        /// </summary>
        /// <param name="donkh"></param>
        public void LoadDS(TTKhachHang ttkhachhang)
        {
            txtDanhBo.Text = ttkhachhang.DanhBo;
            txtHopDong.Text = ttkhachhang.GiaoUoc;
            txtHoTen_BD.Text = ttkhachhang.HoTen;
            txtDiaChi_BD.Text = ttkhachhang.DC1 + " " + ttkhachhang.DC2;
            txtMST_BD.Text = ttkhachhang.MSThue;
            txtGB_BD.Text = ttkhachhang.GB;
            txtDM_BD.Text = ttkhachhang.TGDM;
            txtSH_BD.Text = ttkhachhang.SH;
            txtSX_BD.Text = ttkhachhang.SX;
            txtDV_BD.Text = ttkhachhang.DV;
            txtHCSN_BD.Text = ttkhachhang.HCSN;

            dgvDSSoDangKy.DataSource = _cChungTu.LoadDSChungTu(ttkhachhang.DanhBo);
        }

        public void Clear()
        {
            txtMaDon.Text = "";
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtHoTen_BD.Text = "";
            txtDiaChi_BD.Text = "";
            txtMST_BD.Text = "";
            txtGB_BD.Text = "";
            txtDM_BD.Text = "";
            txtSH_BD.Text = "";
            txtSX_BD.Text = "";
            txtDV_BD.Text = "";
            txtHCSN_BD.Text = "";

            dgvDSSoDangKy.DataSource = null;
        }

        private void dgvDSSoDangKy_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSSoDangKy.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
            if (bool.Parse(dgvDSSoDangKy.Rows[e.RowIndex].Cells["Cat"].Value.ToString()) == true)
                dgvDSSoDangKy.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSlateGray;
        }

        private void dgvDSSoDangKy_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    sửaToolStripMenuItem.Enabled = true;
                    cắtChuyểnĐịnhMứcToolStripMenuItem.Enabled = true;
                }
                else
                {
                    sửaToolStripMenuItem.Enabled = false;
                    cắtChuyểnĐịnhMứcToolStripMenuItem.Enabled = false;
                }
                ///Khi chuột phải Selected-Row sẽ được chuyển đến nơi click chuột
                dgvDSSoDangKy.CurrentCell = dgvDSSoDangKy.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dgvDSSoDangKy_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(dgvDSSoDangKy, new Point(e.X, e.Y));
            }
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> source = new Dictionary<string, string>();
            source.Add("MaDon", txtMaDon.Text.Trim());
            source.Add("DanhBo", txtDanhBo.Text.Trim());
            source.Add("HoTenKH", txtHoTen_BD.Text.Trim());
            source.Add("DiaChiKH", txtDiaChi_BD.Text.Trim());
            source.Add("MaLCT", "1");
            source.Add("MaCT", "");
            source.Add("DiaChi", "");
            source.Add("SoNKTong", "");
            source.Add("SoNKDangKy", "");
            source.Add("NgayHetHan", "");
            source.Add("ThoiHan", "");
            frmSoDK frm = new frmSoDK("Thêm", source);
            if (frm.ShowDialog() == DialogResult.OK)
                dgvDSSoDangKy.DataSource = _cChungTu.LoadDSChungTu(_donkh.DanhBo);
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> source = new Dictionary<string, string>();
            source.Add("MaDon", txtMaDon.Text.Trim());
            source.Add("DanhBo",txtDanhBo.Text.Trim());
            source.Add("MaLCT", dgvDSSoDangKy.CurrentRow.Cells["MaLCT"].Value.ToString());
            source.Add("MaCT", dgvDSSoDangKy.CurrentRow.Cells["MaCT"].Value.ToString());
            source.Add("DiaChi", dgvDSSoDangKy.CurrentRow.Cells["DiaChi"].Value.ToString());
            source.Add("SoNKTong", dgvDSSoDangKy.CurrentRow.Cells["SoNKTong"].Value.ToString());
            source.Add("SoNKDangKy", dgvDSSoDangKy.CurrentRow.Cells["SoNKDangKy"].Value.ToString());
            source.Add("NgayHetHan", dgvDSSoDangKy.CurrentRow.Cells["NgayHetHan"].Value.ToString());
            source.Add("ThoiHan", dgvDSSoDangKy.CurrentRow.Cells["ThoiHan"].Value.ToString());
            frmSoDK frm = new frmSoDK("Sửa", source);
            if (frm.ShowDialog() == DialogResult.OK)
                dgvDSSoDangKy.DataSource = _cChungTu.LoadDSChungTu(_donkh.DanhBo);
        }

        private void cắtChuyểnĐịnhMứcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> source = new Dictionary<string, string>();
            source.Add("MaDon", txtMaDon.Text.Trim());
            source.Add("DanhBo", txtDanhBo.Text.Trim());
            source.Add("HoTen", txtHoTen_BD.Text.Trim());
            source.Add("DiaChi", txtDiaChi_BD.Text.Trim());
            source.Add("MaLCT", dgvDSSoDangKy.CurrentRow.Cells["MaLCT"].Value.ToString());
            source.Add("MaCT", dgvDSSoDangKy.CurrentRow.Cells["MaCT"].Value.ToString());
            frmCatChuyenDM frm = new frmCatChuyenDM(source);
            frm.ShowDialog();
        }

        private void nhậnĐịnhMứctoolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Dictionary<string, string> source = new Dictionary<string, string>();
            source.Add("MaDon", txtMaDon.Text.Trim());
            source.Add("DanhBo", txtDanhBo.Text.Trim());
            source.Add("HoTen", txtHoTen_BD.Text.Trim());
            source.Add("DiaChi", txtDiaChi_BD.Text.Trim());
            frmNhanDM frm = new frmNhanDM(source);
            frm.ShowDialog();
        }

        private void dgvDSSoDangKy_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            this.ControlBox = false;
            contextMenuStrip1.Enabled = false;
        }

        private void dgvDSSoDangKy_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ///Hiện tại nếu check SoChinh mà exit bằng X thì dữ liệu không được lưu
            ///Sau khi check phải check qua chỗ khác mới lưu
            CTChungTu ctchungtu = _cChungTu.getCTChungTubyID(dgvDSSoDangKy["DanhBo", e.RowIndex].Value.ToString(), dgvDSSoDangKy["MaCT", e.RowIndex].Value.ToString());
            if (bool.Parse(dgvDSSoDangKy["SoChinh", e.RowIndex].Value.ToString()) == true)
                ctchungtu.SoChinh = true;
            else
                ctchungtu.SoChinh = false;
            if (bool.Parse(dgvDSSoDangKy["Cat", e.RowIndex].Value.ToString()) == true)
                ctchungtu.Cat = true;
            else
                ctchungtu.Cat = false;
            _cChungTu.SuaCTChungTu(ctchungtu);
            this.ControlBox = true;
            contextMenuStrip1.Enabled = true;
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (_cTTKH.getTTKHbyID(txtDanhBo.Text.Trim()) != null)
                    LoadDS(_cTTKH.getTTKHbyID(txtDanhBo.Text.Trim()));
                else
                    Clear();
            }
        }

        
    }
}
