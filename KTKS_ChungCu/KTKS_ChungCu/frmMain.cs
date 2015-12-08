using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_ChungCu.LinQ;
using KTKS_ChungCu.DAL;
using KTKS_ChungCu.BaoCao;
using KTKS_ChungCu.GUI.ChungTu;

namespace KTKS_ChungCu
{
    public partial class frmMain : Form
    {
        CTTKH _cTTKH = new CTTKH();
        TTKhachHang _ttkhachhang = new TTKhachHang();
        CLoaiChungTu _cLoaiChungTu = new CLoaiChungTu();
        CChungTu _cChungTu = new CChungTu();
        int _selectedindex = -1;
        BindingSource DSKHCC_BS = new BindingSource();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            dgvKhachHangChungCu.AutoGenerateColumns = false;
            dgvKhachHangChungCu.ColumnHeadersDefaultCellStyle.Font = new Font(dgvKhachHangChungCu.Font, FontStyle.Bold);
            dgvKhachHangChungCu.DataSource = DSKHCC_BS;

            cmbLoaiCT.DataSource = _cLoaiChungTu.LoadDSLoaiChungTu(true);
            cmbLoaiCT.DisplayMember = "TenLCT";
            cmbLoaiCT.ValueMember = "MaLCT";

            DataGridViewComboBoxColumn cmbColumn = (DataGridViewComboBoxColumn)dgvKhachHangChungCu.Columns["MaLCT"];
            cmbColumn.DataSource = _cLoaiChungTu.LoadDSLoaiChungTu(true);
            cmbColumn.DisplayMember = "TenLCT";
            cmbColumn.ValueMember = "MaLCT";
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
            ///
            txtLo.Text = "";
            txtPhong.Text = "";
            cmbLoaiCT.SelectedIndex = 0;
            txtMaCT.Text = "";
            txtHoTenCT.Text = "";
            txtSoNKDangKy.Text = "";
            txtGhiChu.Text = "";
            _ttkhachhang = null;
            _selectedindex = -1;
        }

        private void dgvKhachHangChungTu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvKhachHangChungCu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
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
                    txtLo.Focus();
                }
                else
                {
                    _ttkhachhang = null;
                    Clear();
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_cChungTu.CheckCTChungTu(txtDanhBo.Text.Trim(), txtMaCT.Text.Trim(), txtLo.Text.Trim(), txtPhong.Text.Trim()))
                {
                    MessageBox.Show("Sổ này đã được lưu tại Lô, Phòng trên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtMaCT.Text.Trim() != "" && txtSoNKDangKy.Text.Trim() != "" && txtSoNKDangKy.Text.Trim() != "0")
                    //if (int.Parse(txtSoNKTong.Text.Trim()) >= int.Parse(txtSoNKDangKy.Text.Trim()))
                    {
                        ChungTu chungtu = new ChungTu();
                        chungtu.MaCT = txtMaCT.Text.Trim();
                        chungtu.HoTen = txtHoTenCT.Text.Trim();
                        chungtu.SoNKTong = int.Parse(txtSoNKDangKy.Text.Trim());
                        chungtu.MaLCT = int.Parse(cmbLoaiCT.SelectedValue.ToString());

                        CTChungTu ctchungtu = new CTChungTu();
                        ctchungtu.STT = int.Parse(txtSTT.Text.Trim());
                        ctchungtu.DanhBo = txtDanhBo.Text.Trim();
                        ctchungtu.MaCT = txtMaCT.Text.Trim();
                        ctchungtu.SoNKDangKy = int.Parse(txtSoNKDangKy.Text.Trim());
                        //if (txtThoiHan.Text.Trim() != "" && txtThoiHan.Text.Trim() != "0")
                        //    ctchungtu.ThoiHan = int.Parse(txtThoiHan.Text.Trim());
                        //else
                        //    ctchungtu.ThoiHan = null;
                        ctchungtu.GhiChu = txtGhiChu.Text.Trim();
                        ctchungtu.Lo = txtLo.Text.Trim();
                        ctchungtu.Phong = txtPhong.Text.Trim();
                        ctchungtu.GhiChu = txtGhiChu.Text.Trim();

                        LichSuChungTu lichsuchungtu = new LichSuChungTu();
                        lichsuchungtu.GhiChu = txtGhiChu.Text.Trim();

                        if (_cChungTu.ThemChungTu(chungtu, ctchungtu, lichsuchungtu))
                        {
                            MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DSKHCC_BS.DataSource = _cChungTu.LoadDSChungTu(_ttkhachhang.DanhBo);

                            //txtSTT.Text = "";
                            //txtLo.Text = "";
                            //txtPhong.Text = "";
                            cmbLoaiCT.SelectedIndex = 0;
                            txtMaCT.Text = "";
                            txtHoTenCT.Text = "";
                            txtSoNKDangKy.Text = "";
                            txtGhiChu.Text = "";
                            _selectedindex = -1;
                            txtSTT.Focus();
                        }

                    }
                    else
                        MessageBox.Show("Số Nhân Khẩu đăng ký vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedindex != -1)
            {
                try
                {
                    //if (_cChungTu.CheckCTChungTu(txtDanhBo.Text.Trim(), txtMaCT.Text.Trim(), txtLo.Text.Trim(), txtPhong.Text.Trim()))
                    //{
                    //    MessageBox.Show("Sổ này đã được lưu tại Lô, Phòng trên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return;
                    //}
                    if (txtSoNKDangKy.Text.Trim() != "" && txtSoNKDangKy.Text.Trim() != "0")
                    {
                        ChungTu chungtu = new ChungTu();
                        chungtu.MaCT = txtMaCT.Text.Trim();
                        chungtu.HoTen = txtHoTenCT.Text.Trim();
                        chungtu.SoNKTong = int.Parse(txtSoNKDangKy.Text.Trim());
                        chungtu.MaLCT = int.Parse(cmbLoaiCT.SelectedValue.ToString());

                        CTChungTu ctchungtu = new CTChungTu();
                        ctchungtu.STT = int.Parse(txtSTT.Text.Trim());
                        ctchungtu.DanhBo = txtDanhBo.Text.Trim();
                        ctchungtu.MaCT = txtMaCT.Text.Trim();
                        ctchungtu.SoNKDangKy = int.Parse(txtSoNKDangKy.Text.Trim());
                        //if (txtThoiHan.Text.Trim() != "" && txtThoiHan.Text.Trim() != "0")
                        //    ctchungtu.ThoiHan = int.Parse(txtThoiHan.Text.Trim());
                        //else
                        //    ctchungtu.ThoiHan = null;
                        ctchungtu.GhiChu = txtGhiChu.Text.Trim();
                        ctchungtu.Lo = txtLo.Text.Trim();
                        ctchungtu.Phong = txtPhong.Text.Trim();
                        ctchungtu.GhiChu = txtGhiChu.Text.Trim();

                        LichSuChungTu lichsuchungtu = new LichSuChungTu();
                        lichsuchungtu.GhiChu = txtGhiChu.Text.Trim();

                        if (_cChungTu.SuaChungTu(chungtu, ctchungtu, lichsuchungtu))
                        {
                            MessageBox.Show("Sửa Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DSKHCC_BS.DataSource = _cChungTu.LoadDSChungTu(_ttkhachhang.DanhBo);

                            txtSTT.Text = "";
                            txtLo.Text = "";
                            txtPhong.Text = "";
                            cmbLoaiCT.SelectedIndex = 0;
                            txtMaCT.Text = "";
                            txtHoTenCT.Text = "";
                            txtSoNKDangKy.Text = "";
                            txtGhiChu.Text = "";
                            _selectedindex = -1;
                        }
                    }
                    else
                        MessageBox.Show("Số Nhân Khẩu đăng ký vượt định mức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvKhachHangChungCu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectedindex = e.RowIndex;
            txtSTT.Text = dgvKhachHangChungCu["STT", e.RowIndex].Value.ToString();
            txtLo.Text = dgvKhachHangChungCu["Lo", e.RowIndex].Value.ToString();
            txtPhong.Text = dgvKhachHangChungCu["Phong", e.RowIndex].Value.ToString();
            cmbLoaiCT.SelectedValue = int.Parse(dgvKhachHangChungCu["MaLCT", e.RowIndex].Value.ToString());
            txtMaCT.Text = dgvKhachHangChungCu["MaCT", e.RowIndex].Value.ToString();
            txtHoTenCT.Text = dgvKhachHangChungCu["HoTen", e.RowIndex].Value.ToString();
            txtSoNKDangKy.Text = dgvKhachHangChungCu["SoNKDangKy", e.RowIndex].Value.ToString();
            txtGhiChu.Text = dgvKhachHangChungCu["GhiChu", e.RowIndex].Value.ToString();
        }

        private void txtMaCT_TimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMaCT_TimKiem.Text.Trim() != "")
            {
                string expression = String.Format("MaCT = {0}", txtMaCT_TimKiem.Text.Trim());
                DSKHCC_BS.Filter = expression;
            }
            else
                DSKHCC_BS.RemoveFilter();
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
            if (e.KeyChar == 13)
                txtGhiChu.Focus();
    }

        private void txtThoiHan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_ttkhachhang != null)
            {
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                for (int i = 0; i < dgvKhachHangChungCu.Rows.Count; i++)
                {
                    DataRow dr = dsBaoCao.Tables["DSChungTu"].NewRow();

                    dr["STT"] = dgvKhachHangChungCu["STT", i].Value.ToString();
                    dr["DanhBo"] = txtDanhBo.Text.Trim().Insert(7," ").Insert(4," ");
                    dr["HoTen"] = txtHoTen.Text.Trim();
                    dr["DiaChi"] = txtDiaChi.Text.Trim();
                    dr["HopDong"] = _ttkhachhang.GiaoUoc;
                    dr["GiaBieu"] = _ttkhachhang.GB;
                    dr["DinhMuc"] = _ttkhachhang.TGDM;
                    dr["LoTrinh"] = _ttkhachhang.Dot + _ttkhachhang.CuonGCS + _ttkhachhang.CuonSTT;
                    //dr["TenLCT"] = dgvKhachHangChungCu["TenLCT", i].Value.ToString();
                    dr["HoTenCT"] = dgvKhachHangChungCu["HoTen", i].Value.ToString();
                    dr["MaCT"] = dgvKhachHangChungCu["MaCT", i].Value.ToString();
                    //dr["SoNKTong"] = dgvKhachHangChungCu["SoNKTong", i].Value.ToString();
                    dr["SoNKDangKy"] = dgvKhachHangChungCu["SoNKDangKy", i].Value.ToString();
                    dr["GhiChu"] = dgvKhachHangChungCu["GhiChu", i].Value.ToString();
                    dr["Lo"] = dgvKhachHangChungCu["Lo", i].Value.ToString();
                    dr["Phong"] = dgvKhachHangChungCu["Phong", i].Value.ToString();

                    dsBaoCao.Tables["DSChungTu"].Rows.Add(dr);
                }
                rptDSChungTu rpt = new rptDSChungTu();
                rpt.SetDataSource(dsBaoCao);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.ShowDialog();

            }
        }

        private void frmMain_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtMaCT_TimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbLoaiCT_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dgvKhachHangChungCu_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvKhachHangChungCu.RowCount > 0 && e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                frmSoDK frm = new frmSoDK(dgvKhachHangChungCu["DanhBo", e.RowIndex].Value.ToString(), dgvKhachHangChungCu["MaCT", e.RowIndex].Value.ToString());
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                }
            }
        }

        private void btnShowDSCatChuyenDM_Click(object sender, EventArgs e)
        {
            frmDSCatChuyenDM frm = new frmDSCatChuyenDM();
            frm.ShowDialog();
        }

        private void txtLo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtSTT.Focus();
        }

        private void txtHoTenCT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtPhong.Focus();
        }

        private void txtPhong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                cmbLoaiCT.Focus();
        }

        private void cmbLoaiCT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtMaCT.Focus();
        }

        private void txtMaCT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtSoNKDangKy.Focus();
        }

        private void txtGhiChu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
               btnThem.Focus();
        }

        private void txtSTT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtHoTenCT.Focus();
        }


        
    }
}
