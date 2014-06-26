﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.DieuChinhBienDong;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmChungCu : Form
    {
        CTTKH _cTTKH = new CTTKH();
        TTKhachHang _ttkhachhang = new TTKhachHang();
        CChungTu _cChungTu = new CChungTu();
        BindingSource DSKHCC_BS = new BindingSource();
        CChiNhanh _cChiNhanh = new CChiNhanh();
        string _tuNgay = "", _denNgay = "";

        public frmChungCu()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void frmChungCu_Load(object sender, EventArgs e)
        {
            dgvKhachHangChungCu.AutoGenerateColumns = false;
            dgvKhachHangChungCu.ColumnHeadersDefaultCellStyle.Font = new Font(dgvKhachHangChungCu.Font, FontStyle.Bold);
            dgvKhachHangChungCu.DataSource = DSKHCC_BS;
            dateTimKiem.Location = txtNoiDungTimKiem.Location;
        }

        public void LoadTTKH(TTKhachHang ttkhachhang)
        {
            txtDanhBo.Text = ttkhachhang.DanhBo;
            txtHopDong.Text = ttkhachhang.GiaoUoc;
            txtHoTen.Text = ttkhachhang.HoTen;
            txtDiaChi.Text = ttkhachhang.DC1 + " " + ttkhachhang.DC2;
        }

        public void Clear()
        {
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            _ttkhachhang = null;
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (_cTTKH.getTTKHbyID(txtDanhBo.Text.Trim()) != null)
                {
                    _ttkhachhang = _cTTKH.getTTKHbyID(txtDanhBo.Text.Trim());
                    LoadTTKH(_ttkhachhang);
                    DSKHCC_BS.DataSource = _cChungTu.LoadDSChungTu(_ttkhachhang.DanhBo);
                }
                else
                {
                    _ttkhachhang = null;
                    Clear();
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvKhachHangChungCu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvKhachHangChungCu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_ttkhachhang != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                for (int i = 0; i < dgvKhachHangChungCu.Rows.Count; i++)
                {
                    DataRow dr = dsBaoCao.Tables["DSChungTu"].NewRow();

                    dr["TuNgay"] = _tuNgay;
                    dr["DenNgay"] = _denNgay;
                    dr["DanhBo"] = txtDanhBo.Text.Trim().Insert(7, " ").Insert(4, " ");
                    dr["HoTen"] = txtHoTen.Text.Trim();
                    dr["DiaChi"] = txtDiaChi.Text.Trim();
                    dr["HopDong"] = _ttkhachhang.GiaoUoc;
                    dr["GiaBieu"] = _ttkhachhang.GB;
                    dr["DinhMuc"] = _ttkhachhang.TGDM;
                    dr["LoTrinh"] = _ttkhachhang.Dot + _ttkhachhang.CuonGCS + _ttkhachhang.CuonSTT;
                    dr["TenLCT"] = dgvKhachHangChungCu["TenLCT", i].Value.ToString();
                    dr["MaCT"] = dgvKhachHangChungCu["MaCT", i].Value.ToString();
                    dr["DiaChiCT"] = dgvKhachHangChungCu["DiaChi", i].Value.ToString();
                    dr["SoNKTong"] = dgvKhachHangChungCu["SoNKTong", i].Value.ToString();
                    dr["SoNKDangKy"] = dgvKhachHangChungCu["SoNKDangKy", i].Value.ToString();
                    dr["GhiChu"] = dgvKhachHangChungCu["GhiChu", i].Value.ToString();
                    dr["Lo"] = dgvKhachHangChungCu["Lo", i].Value.ToString();
                    dr["Phong"] = dgvKhachHangChungCu["Phong", i].Value.ToString();

                    dsBaoCao.Tables["DSChungTu"].Rows.Add(dr);
                }
                if (radLo.Checked)
                {
                    rptDSChungTu_Lo rpt = new rptDSChungTu_Lo();
                    rpt.SetDataSource(dsBaoCao);
                    frmBaoCao frm = new frmBaoCao(rpt);
                    frm.ShowDialog();
                }
                if (radThuTuNhap.Checked)
                {
                    rptDSChungTu_ThuTuNhap rpt = new rptDSChungTu_ThuTuNhap();
                    rpt.SetDataSource(dsBaoCao);
                    frmBaoCao frm = new frmBaoCao(rpt);
                    frm.ShowDialog();
                }
            }
        }

        private void frmChungCu_KeyDown(object sender, KeyEventArgs e)
        {
            if (_ttkhachhang!=null && e.Control && e.KeyCode == Keys.D1)
            {
                Dictionary<string, string> source = new Dictionary<string, string>();
                source.Add("ChungCu", "True");
                source.Add("DanhBo", txtDanhBo.Text.Trim());
                source.Add("HoTenKH", txtHoTen.Text.Trim());
                source.Add("DiaChiKH", txtDiaChi.Text.Trim());
                source.Add("TenLCT", "Hộ Khẩu");
                source.Add("MaCT", "");
                source.Add("DiaChi", "");
                source.Add("SoNKTong", "");
                source.Add("SoNKDangKy", "");
                source.Add("NgayHetHan", "");
                source.Add("ThoiHan", "");
                source.Add("GhiChu", "");
                source.Add("Lo", "");
                source.Add("Phong", "");
                frmSoDK frm = new frmSoDK("Thêm", source);
                if (frm.ShowDialog() == DialogResult.OK)
                    dgvKhachHangChungCu.DataSource = _cChungTu.LoadDSChungTu(_ttkhachhang.DanhBo);
            }
            if (_ttkhachhang != null && e.Control && e.KeyCode == Keys.D2)
            {
                Dictionary<string, string> source = new Dictionary<string, string>();
                source.Add("ChungCu", "True");
                source.Add("DanhBo", txtDanhBo.Text.Trim());
                source.Add("HoTen", txtHoTen.Text.Trim());
                source.Add("DiaChi", txtDiaChi.Text.Trim());
                frmNhanDM frm = new frmNhanDM(source);
                if (frm.ShowDialog() == DialogResult.OK)
                    dgvKhachHangChungCu.DataSource = _cChungTu.LoadDSChungTu(_ttkhachhang.DanhBo);
            }
        }

        private void thêmThuộcĐịaBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> source = new Dictionary<string, string>();
            source.Add("ChungCu", "True");
            source.Add("DanhBo", txtDanhBo.Text.Trim());
            source.Add("HoTenKH", txtHoTen.Text.Trim());
            source.Add("DiaChiKH", txtDiaChi.Text.Trim());
            source.Add("TenLCT", "Hộ Khẩu");
            source.Add("MaCT", "");
            source.Add("DiaChi", "");
            source.Add("SoNKTong", "");
            source.Add("SoNKDangKy", "");
            source.Add("NgayHetHan", "");
            source.Add("ThoiHan", "");
            source.Add("GhiChu", "");
            source.Add("Lo", "");
            source.Add("Phong", "");
            frmSoDK frm = new frmSoDK("Thêm", source);
            if (frm.ShowDialog() == DialogResult.OK)
                DSKHCC_BS.DataSource = _cChungTu.LoadDSChungTu(_ttkhachhang.DanhBo);
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> source = new Dictionary<string, string>();
            source.Add("ChungCu", "True");
            source.Add("DanhBo", txtDanhBo.Text.Trim());
            source.Add("TenLCT", dgvKhachHangChungCu.CurrentRow.Cells["TenLCT"].Value.ToString());
            source.Add("MaCT", dgvKhachHangChungCu.CurrentRow.Cells["MaCT"].Value.ToString());
            source.Add("HoTenKH", txtHoTen.Text.Trim());
            source.Add("DiaChiKH", txtDiaChi.Text.Trim());
            source.Add("DiaChi", dgvKhachHangChungCu.CurrentRow.Cells["DiaChi"].Value.ToString());
            source.Add("SoNKTong", dgvKhachHangChungCu.CurrentRow.Cells["SoNKTong"].Value.ToString());
            source.Add("SoNKDangKy", dgvKhachHangChungCu.CurrentRow.Cells["SoNKDangKy"].Value.ToString());
            source.Add("NgayHetHan", dgvKhachHangChungCu.CurrentRow.Cells["NgayHetHan"].Value.ToString());
            source.Add("ThoiHan", dgvKhachHangChungCu.CurrentRow.Cells["ThoiHan"].Value.ToString());
            source.Add("GhiChu", dgvKhachHangChungCu.CurrentRow.Cells["GhiChu"].Value.ToString());
            source.Add("Lo", dgvKhachHangChungCu.CurrentRow.Cells["Lo"].Value.ToString());
            source.Add("Phong", dgvKhachHangChungCu.CurrentRow.Cells["Phong"].Value.ToString());
            frmSoDK frm = new frmSoDK("Sửa", source);
            if (frm.ShowDialog() == DialogResult.OK)
                DSKHCC_BS.DataSource = _cChungTu.LoadDSChungTu(_ttkhachhang.DanhBo);
        }

        private void nhậnĐịnhMứcKhácĐịaBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> source = new Dictionary<string, string>();
            source.Add("ChungCu", "True");
            source.Add("DanhBo", txtDanhBo.Text.Trim());
            source.Add("HoTen", txtHoTen.Text.Trim());
            source.Add("DiaChi", txtDiaChi.Text.Trim());
            frmNhanDM frm = new frmNhanDM(source);
            if (frm.ShowDialog() == DialogResult.OK)
                DSKHCC_BS.DataSource = _cChungTu.LoadDSChungTu(_ttkhachhang.DanhBo);
        }

        private void dgvKhachHangChungCu_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && _ttkhachhang != null)
            {
                thêmThuộcĐịaBànToolStripMenuItem.Enabled = true;
                nhậnĐịnhMứcKhácĐịaBànToolStripMenuItem.Enabled = true;
                contextMenuStrip1.Show(dgvKhachHangChungCu, new Point(e.X, e.Y));
            }
        }

        private void dgvKhachHangChungCu_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    sửaToolStripMenuItem.Enabled = true;
                }
                else
                {
                    sửaToolStripMenuItem.Enabled = false;
                }
                ///Khi chuột phải Selected-Row sẽ được chuyển đến nơi click chuột
                dgvKhachHangChungCu.CurrentCell = dgvKhachHangChungCu.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void btnInDSCatChuyen_Click(object sender, EventArgs e)
        {
            if (_ttkhachhang != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                List<LichSuChungTu> lstLSCT = _cChungTu.getLichSuChungTubyDanhBo(txtDanhBo.Text.Trim());

                foreach (LichSuChungTu itemLSCT in lstLSCT)
                {
                    DataRow dr = dsBaoCao.Tables["DSCatChuyen"].NewRow();
                    
                    dr["Lo"] = _cChungTu.getCTChungTubyID(itemLSCT.DanhBo, itemLSCT.MaCT).Lo;
                    dr["Phong"] = _cChungTu.getCTChungTubyID(itemLSCT.DanhBo, itemLSCT.MaCT).Phong;
                    dr["DanhBo_Nhan"] = txtDanhBo.Text.Trim().Insert(7, " ").Insert(4, " ");
                    dr["MaCT"] = itemLSCT.MaCT;
                    dr["DiaChiNoiCat"] = itemLSCT.CatNK_DiaChi;
                    dr["TongNK"] = itemLSCT.SoNKTong;
                    dr["SoNKCat"] = itemLSCT.SoNKNhan;
                    dr["NoiCat"] = _cChiNhanh.getTenChiNhanhbyID(itemLSCT.CatNK_MaCN.Value);
                    if (!string.IsNullOrEmpty(itemLSCT.CatNK_DanhBo))
                        dr["DanhBo_Cat"] = itemLSCT.CatNK_DanhBo.Insert(7, " ").Insert(4, " ");
                    else
                        dr["DanhBo_Cat"] = "";

                    dsBaoCao.Tables["DSCatChuyen"].Rows.Add(dr);
                }
                rptDSCatChuyen rpt = new rptDSCatChuyen();
                rpt.SetDataSource(dsBaoCao);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.ShowDialog();

            }
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Số Chứng Từ":
                    txtNoiDungTimKiem.Visible = true;
                    dateTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Ngày Lập":
                    txtNoiDungTimKiem.Visible = false;
                    dateTimKiem.Visible = true;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Khoảng Thời Gian":
                    txtNoiDungTimKiem.Visible = false;
                    dateTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = true;
                    break;
                default:
                    txtNoiDungTimKiem.Visible = false;
                    dateTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    DSKHCC_BS.RemoveFilter();
                    break;
            }
        }

        private void txtNoiDungTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtNoiDungTimKiem.Text.Trim() != "")
                {
                    string expression = String.Format("MaCT like '{0}%'", txtNoiDungTimKiem.Text.Trim());
                    DSKHCC_BS.Filter = expression;
                    DSKHCC_BS.Filter = expression;
                }
                else
                    DSKHCC_BS.RemoveFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateTimKiem_ValueChanged(object sender, EventArgs e)
        {
            string expression = String.Format("CreateDate > #{0:yyyy-MM-dd} 00:00:00# and CreateDate < #{0:yyyy-MM-dd} 23:59:59#", dateTimKiem.Value);
            DSKHCC_BS.Filter = expression;
            _tuNgay = dateTimKiem.Value.ToString("dd/MM/yyyy");
            _denNgay = "";
        }

        private void dateTu_ValueChanged(object sender, EventArgs e)
        {
            string expression = String.Format("CreateDate >= #{0:yyyy-MM-dd} 00:00:00# and CreateDate <= #{0:yyyy-MM-dd} 23:59:59#", dateTu.Value);
            DSKHCC_BS.Filter = expression;
            _tuNgay = dateTu.Value.ToString("dd/MM/yyyy");
            _denNgay = "";
        }

        private void dateDen_ValueChanged(object sender, EventArgs e)
        {
            string expression = String.Format("CreateDate >= #{0:yyyy-MM-dd} 00:00:00# and CreateDate <= #{1:yyyy-MM-dd} 23:59:59#", dateTu.Value, dateDen.Value);
            DSKHCC_BS.Filter = expression;
            _denNgay = dateDen.Value.ToString("dd/MM/yyyy");
        }
    }
}
