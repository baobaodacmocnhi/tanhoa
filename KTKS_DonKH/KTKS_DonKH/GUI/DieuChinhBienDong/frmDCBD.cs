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
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.DieuChinhBienDong;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.ToXuLy;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmDCBD : Form
    {
        DonKH _donkh = null;
        DonTXL _dontxl = null;
        TTKhachHang _ttkhachhang = null;
        CLoaiChungTu _cLoaiChungTu = new CLoaiChungTu();
        CChungTu _cChungTu = new CChungTu();
        CTTKH _cTTKH = new CTTKH();
        CDCBD _cDCBD = new CDCBD();
        Dictionary<string, string> _source = new Dictionary<string, string>();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CKTXM _cKTXM = new CKTXM();
        CPhuongQuan _cPhuongQuan = new CPhuongQuan();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        bool flagFirst = true;///Lần đầu Load Form (trường hợp 1 đơn nhiều Danh Bộ)
        bool _direct = false;///Mở form trực tiếp không qua Danh Sách Đơn
        bool _flagCtrl3 = false;

        public frmDCBD()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load Form trực tiếp không qua Danh Sách Đơn
        /// </summary>
        /// <param name="direct">true</param>
        public frmDCBD(bool direct)
        {
            InitializeComponent();
            _direct = direct;
        }

        public frmDCBD(Dictionary<string, string> source)
        {
            InitializeComponent();
            _source = source;
        }

        private void frmDCBD_Load(object sender, EventArgs e)
        {
            ///this.KeyPreview = true;
            ///Hàm Properties không có nên phải add code
            ///Dùng để bôi đen Text
            txtMaDon.GotFocus += new EventHandler(txtMaDon_GotFocus);

            if (_direct)
            {
                this.ControlBox = false;
                this.WindowState = FormWindowState.Maximized;
                this.BringToFront();
                txtMaDon.ReadOnly = false;
            }
            else
            {
                this.Location = new Point(70, 70);
                if (_cDonKH.getDonKHbyID(decimal.Parse(_source["MaDon"])) != null)
                {
                    _donkh = _cDonKH.getDonKHbyID(decimal.Parse(_source["MaDon"]));
                    txtMaDon.Text = _donkh.MaDon.ToString().Insert(_donkh.MaDon.ToString().Length - 2, "-");
                }
                if (_cTTKH.getTTKHbyID(_source["DanhBo"]) != null)
                {
                    _ttkhachhang = _cTTKH.getTTKHbyID(_source["DanhBo"]);
                    LoadTTKH(_ttkhachhang);
                }
            }
            dgvDSSoDangKy.AutoGenerateColumns = false;
            dgvDSSoDangKy.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSChungTu.Font, FontStyle.Bold);
            //DataGridViewComboBoxColumn cmbColumn = (DataGridViewComboBoxColumn)dgvDSSoDangKy.Columns["MaLCT"];
            //cmbColumn.DataSource = _cLoaiChungTu.LoadDSLoaiChungTu(true);
            //cmbColumn.DisplayMember = "TenLCT";
            //cmbColumn.ValueMember = "MaLCT";

            dgvDSDieuChinh.AutoGenerateColumns = false;
            dgvDSDieuChinh.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSChungTu.Font, FontStyle.Bold);

            dgvLichSuChungTu.AutoGenerateColumns = false;
            dgvLichSuChungTu.ColumnHeadersDefaultCellStyle.Font = new Font(dgvLichSuChungTu.Font, FontStyle.Bold);

            dgvDSChungTu.AutoGenerateColumns = false;
            dgvDSChungTu.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSChungTu.Font, FontStyle.Bold);

            lbDSHetHan.Text = _cChungTu.LoadDSCapDinhMucHetHan().Rows.Count.ToString()+" Sổ sắp hết hạn";
        }

        void txtMaDon_GotFocus(object sender, EventArgs e)
        {
            txtMaDon.SelectAll();
        }

        /// <summary>
        /// Nhận Entity TTKhachHang để điền vào textbox
        /// </summary>
        /// <param name="ttkhachhang"></param>
        public void LoadTTKH(TTKhachHang ttkhachhang)
        {
            txtDanhBo.Text = ttkhachhang.DanhBo;
            txtHopDong.Text = ttkhachhang.GiaoUoc;
            txtHoTen.Text = ttkhachhang.HoTen;
            txtDiaChi.Text = ttkhachhang.DC1 + " " + ttkhachhang.DC2 + _cPhuongQuan.getPhuongQuanByID(ttkhachhang.Quan, ttkhachhang.Phuong);
            txtMSThue.Text = ttkhachhang.MSThue;
            txtGiaBieu.Text = ttkhachhang.GB;
            txtDinhMuc.Text = ttkhachhang.TGDM;
            txtSH.Text = ttkhachhang.SH;
            txtSX.Text = ttkhachhang.SX;
            txtDV.Text = ttkhachhang.DV;
            txtHCSN.Text = ttkhachhang.HCSN;
            txtDot.Text = ttkhachhang.Dot;

            dgvDSSoDangKy.DataSource = _cChungTu.LoadDSChungTubyDanhBo(ttkhachhang.DanhBo);
            dgvDSDieuChinh.DataSource = _cDCBD.LoadDSDCbyDanhBo(ttkhachhang.DanhBo);
            LoadTongNK();
        }

        public void Clear()
        {
            //txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtMSThue.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            txtSH.Text = "";
            txtSX.Text = "";
            txtDV.Text = "";
            txtHCSN.Text = "";
            txtDot.Text = "";
            txtHieuLucKy.Text = "";
            chkCatMSThue.Checked = false;
            ///
            txtHoTen_BD.Text = "";
            txtDiaChi_BD.Text = "";
            txtMSThue_BD.Text = "";
            txtGiaBieu_BD.Text = "";
            txtDinhMuc_BD.Text = "";
            txtSH_BD.Text = "";
            txtSX_BD.Text = "";
            txtDV_BD.Text = "";
            txtHCSN_BD.Text = "";
            lbTongNK.Text = "";

            _ttkhachhang = null;
            dgvDSSoDangKy.DataSource = null;
            dgvDSDieuChinh.DataSource = null;
            dgvLichSuChungTu.DataSource = null;
            dgvDSChungTu.DataSource = null;
            flagFirst = true;
        }

        /// <summary>
        /// Hiện thị Tổng số NK Đăng Ký của Danh Bộ
        /// </summary>
        public void LoadTongNK()
        {
            int TongNK = 0;
            foreach (DataRow itemRow in ((DataTable)dgvDSSoDangKy.DataSource).Rows)
            {
                TongNK += int.Parse(itemRow["SoNKDangKy"].ToString());
            }
            lbTongNK.Text = "Tổng NK: " + TongNK;
            lbTongDM.Text = "Tổng ĐM: " + TongNK * 4;
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
            if (e.Button == MouseButtons.Right && (_donkh!=null||_dontxl!=null))
            {
                thêmToolStripMenuItem.Enabled = true;
                nhậnĐịnhMứctoolStripMenuItem.Enabled = true;
                contextMenuStrip1.Show(dgvDSSoDangKy, new Point(e.X, e.Y));
            }
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> source = new Dictionary<string, string>();
            source.Add("ChungCu", "False");
            ///Đơn Tổ Xử Lý
            if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
            {
                source.Add("TXL", "True");
                source.Add("MaDon", _dontxl.MaDon.ToString());
            }
            ///Đơn Tổ Khách Hàng
            else
            {
                source.Add("TXL", "False");
                source.Add("MaDon", _donkh.MaDon.ToString());
            }
            source.Add("DanhBo", txtDanhBo.Text.Trim());
            source.Add("HoTenKH", txtHoTen.Text.Trim());
            if(txtDiaChi.Text.Trim().Contains(","))
                source.Add("DiaChiKH", txtDiaChi.Text.Trim().Substring(0, txtDiaChi.Text.Trim().IndexOf(",")));
            else
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
            {
                dgvDSSoDangKy.DataSource = _cChungTu.LoadDSChungTubyDanhBo(txtDanhBo.Text.Trim());
                LoadTongNK();
            }
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> source = new Dictionary<string, string>();
            source.Add("ChungCu", "False");
            ///Đơn Tổ Xử Lý
            if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
            {
                source.Add("TXL", "True");
                source.Add("MaDon", _dontxl.MaDon.ToString());
            }
            ///Đơn Tổ Khách Hàng
            else
            {
                source.Add("TXL", "False");
                source.Add("MaDon", _donkh.MaDon.ToString());
            }
            source.Add("DanhBo", txtDanhBo.Text.Trim());
            source.Add("TenLCT", dgvDSSoDangKy.CurrentRow.Cells["TenLCT"].Value.ToString());
            source.Add("MaCT", dgvDSSoDangKy.CurrentRow.Cells["MaCT"].Value.ToString());
            source.Add("HoTenKH", txtHoTen.Text.Trim());
            source.Add("DiaChiKH", txtDiaChi.Text.Trim());
            source.Add("DiaChi", dgvDSSoDangKy.CurrentRow.Cells["DiaChi"].Value.ToString());
            source.Add("SoNKTong", dgvDSSoDangKy.CurrentRow.Cells["SoNKTong"].Value.ToString());
            source.Add("SoNKDangKy", dgvDSSoDangKy.CurrentRow.Cells["SoNKDangKy"].Value.ToString());
            source.Add("NgayHetHan", dgvDSSoDangKy.CurrentRow.Cells["NgayHetHan"].Value.ToString());
            source.Add("ThoiHan", dgvDSSoDangKy.CurrentRow.Cells["ThoiHan"].Value.ToString());
            source.Add("GhiChu", dgvDSSoDangKy.CurrentRow.Cells["GhiChu"].Value.ToString());
            source.Add("Lo", dgvDSSoDangKy.CurrentRow.Cells["Lo"].Value.ToString());
            source.Add("Phong", dgvDSSoDangKy.CurrentRow.Cells["Phong"].Value.ToString());
            frmSoDK frm = new frmSoDK("Sửa", source);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                dgvDSSoDangKy.DataSource = _cChungTu.LoadDSChungTubyDanhBo(txtDanhBo.Text.Trim());
                LoadTongNK();
            }
        }

        private void cắtChuyểnĐịnhMứcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> source = new Dictionary<string, string>();
            ///Đơn Tổ Xử Lý
            if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
            {
                source.Add("TXL", "True");
                source.Add("MaDon", _dontxl.MaDon.ToString());
            }
            ///Đơn Tổ Khách Hàng
            else
            {
                source.Add("TXL", "False");
                source.Add("MaDon", _donkh.MaDon.ToString());
            }
            source.Add("DanhBo", txtDanhBo.Text.Trim());
            source.Add("HoTen", txtHoTen.Text.Trim());
            source.Add("DiaChi", txtDiaChi.Text.Trim());
            source.Add("TenLCT", dgvDSSoDangKy.CurrentRow.Cells["TenLCT"].Value.ToString());
            source.Add("MaCT", dgvDSSoDangKy.CurrentRow.Cells["MaCT"].Value.ToString());
            source.Add("SoNKDangKy", dgvDSSoDangKy.CurrentRow.Cells["SoNKDangKy"].Value.ToString());
            frmCatChuyenDM frm = new frmCatChuyenDM(source);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                dgvDSSoDangKy.DataSource = _cChungTu.LoadDSChungTubyDanhBo(txtDanhBo.Text.Trim());
                LoadTongNK();
            }
        }

        private void nhậnĐịnhMứctoolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Dictionary<string, string> source = new Dictionary<string, string>();
            source.Add("ChungCu", "False");
            ///Đơn Tổ Xử Lý
            if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
            {
                source.Add("TXL", "True");
                source.Add("MaDon", _dontxl.MaDon.ToString());
            }
            ///Đơn Tổ Khách Hàng
            else
            {
                source.Add("TXL", "False");
                source.Add("MaDon", _donkh.MaDon.ToString());
            }
            source.Add("DanhBo", txtDanhBo.Text.Trim());
            source.Add("HoTen", txtHoTen.Text.Trim());
            source.Add("DiaChi", txtDiaChi.Text.Trim());
            frmNhanDM frm = new frmNhanDM(source);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                dgvDSSoDangKy.DataSource = _cChungTu.LoadDSChungTubyDanhBo(txtDanhBo.Text.Trim());
                LoadTongNK();
            }
        }

        private void dgvDSSoDangKy_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            this.ControlBox = false;
            contextMenuStrip1.Enabled = false;
        }

        private void dgvDSSoDangKy_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ///Hiện tại nếu check Cat mà exit bằng X thì dữ liệu không được lưu
            ///Sau khi check phải check qua chỗ khác mới lưu
            CTChungTu ctchungtu = _cChungTu.getCTChungTubyID(dgvDSSoDangKy["DanhBo", e.RowIndex].Value.ToString(), dgvDSSoDangKy["MaCT", e.RowIndex].Value.ToString());
            if (bool.Parse(dgvDSSoDangKy["Cat", e.RowIndex].Value.ToString()) != ctchungtu.SoChinh)
            {
                ctchungtu.Cat = bool.Parse(dgvDSSoDangKy["Cat", e.RowIndex].Value.ToString());
                _cChungTu.SuaCTChungTu(ctchungtu);
            }
            if (dgvDSSoDangKy["DienThoai", e.RowIndex].Value.ToString() != ctchungtu.DienThoai)
            {
                ctchungtu.DienThoai = dgvDSSoDangKy["DienThoai", e.RowIndex].Value.ToString();
                _cChungTu.SuaCTChungTu(ctchungtu);
            }

            this.ControlBox = true;
            contextMenuStrip1.Enabled = true;
        }

        private void dgvDSSoDangKy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvDSChungTu.DataSource = _cChungTu.LoadDSCTChungTubyMaCT(dgvDSSoDangKy["MaCT", e.RowIndex].Value.ToString());
                dgvLichSuChungTu.DataSource = _cChungTu.LoadDSLichSuChungTubyID(dgvDSSoDangKy["MaCT", e.RowIndex].Value.ToString());
            }
            catch (Exception)
            {

            }
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDon.Text.Trim() != "")
            {
                Clear();
                ///Đơn Tổ Xử Lý
                if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
                {
                    if (_cDonTXL.getDonTXLbyID(decimal.Parse(txtMaDon.Text.Trim().Substring(3).Replace("-", ""))) != null)
                    {
                        _dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(txtMaDon.Text.Trim().Substring(3).Replace("-", "")));
                        txtMaDon.Text = "TXL"+_dontxl.MaDon.ToString().Insert(_dontxl.MaDon.ToString().Length - 2, "-");
                        if (_cTTKH.getTTKHbyID(_dontxl.DanhBo) != null)
                        {
                            _ttkhachhang = _cTTKH.getTTKHbyID(_dontxl.DanhBo);
                            LoadTTKH(_ttkhachhang);
                            txtDanhBo.Focus();
                        }
                        else
                        {
                            //dgvDSSoDangKy.DataSource = _cChungTu.LoadDSChungTu(txtDanhBo.Text.Trim());
                            //dgvDSDieuChinh.DataSource = _cDCBD.LoadDSDCbyDanhBo(txtDanhBo.Text.Trim());
                            txtDanhBo.Focus();
                        }
                    }
                    else
                    {
                        _dontxl = null;
                        MessageBox.Show("Mã Đơn TXL này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                ///Đơn Tổ Khách Hàng
                else
                    if (_cDonKH.getDonKHbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("-", ""))) != null)
                    {
                        _donkh = _cDonKH.getDonKHbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("-", "")));
                        txtMaDon.Text = _donkh.MaDon.ToString().Insert(_donkh.MaDon.ToString().Length - 2, "-");
                        if (_cTTKH.getTTKHbyID(_donkh.DanhBo) != null)
                        {
                            _ttkhachhang = _cTTKH.getTTKHbyID(_donkh.DanhBo);
                            LoadTTKH(_ttkhachhang);
                            txtDanhBo.Focus();
                        }
                        else
                        {
                            //dgvDSSoDangKy.DataSource = _cChungTu.LoadDSChungTu(txtDanhBo.Text.Trim());
                            //dgvDSDieuChinh.DataSource = _cDCBD.LoadDSDCbyDanhBo(txtDanhBo.Text.Trim());
                            txtDanhBo.Focus();
                        }
                    }
                    else
                    {
                        _donkh = null;
                        MessageBox.Show("Mã Đơn KH này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
                    txtHieuLucKy.Focus();
                }
                else
                {
                    Clear();
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvDSSoDangKy.DataSource = _cChungTu.LoadDSChungTubyDanhBo(txtDanhBo.Text.Trim());
                    dgvDSDieuChinh.DataSource = _cDCBD.LoadDSDCbyDanhBo(txtDanhBo.Text.Trim());
                    LoadTongNK();
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                ///Nếu đơn thuộc Tổ Xử Lý
                if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
                {
                    if (_dontxl != null && txtHieuLucKy.Text.Trim() != "")
                    {
                        ///Nếu DCBD chưa có thì thêm vào
                        if (!_cDCBD.CheckDCBDbyMaDon_TXL(_dontxl.MaDon))
                        {
                            DCBD dcbd = new DCBD();
                            dcbd.ToXuLy = true;
                            dcbd.MaDonTXL = _dontxl.MaDon;
                            if (_direct)
                            {
                                if (!_source.ContainsKey("NoiChuyenDen"))
                                    _source.Add("NoiChuyenDen", "");
                            }
                            else
                            {
                                dcbd.MaNoiChuyenDen = decimal.Parse(_source["MaNoiChuyenDen"]);
                                dcbd.NoiChuyenDen = _source["NoiChuyenDen"];
                                dcbd.LyDoChuyenDen = _source["LyDoChuyenDen"];
                            }
                            if (_cDCBD.ThemDCBD(dcbd))
                            {
                                switch (_source["NoiChuyenDen"])
                                {
                                    case "Khách Hàng":
                                        ///Báo cho bảng DonTXL là đơn này đã được nơi nhận xử lý
                                        DonTXL dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(_source["MaNoiChuyenDen"]));
                                        dontxl.Nhan = true;
                                        _cDonTXL.SuaDonTXL(dontxl, true);
                                        break;
                                    case "Kiểm Tra Xác Minh":
                                        ///Báo cho bảng KTXM là đơn này đã được nơi nhận xử lý
                                        KTXM ktxm = _cKTXM.getKTXMbyID(decimal.Parse(_source["MaNoiChuyenDen"]));
                                        ktxm.Nhan = true;
                                        _cKTXM.SuaKTXM(ktxm, true);
                                        break;
                                }
                                if (string.IsNullOrEmpty(_dontxl.TienTrinh))
                                    _dontxl.TienTrinh = "DCBD";
                                else
                                    _dontxl.TienTrinh += ",DCBD";
                                _dontxl.Nhan = true;
                                _cDonTXL.SuaDonTXL(_dontxl, true);
                            }
                        }
                        if (_cDCBD.CheckCTDCBDbyMaDonDanhBo_TXL(_dontxl.MaDon, txtDanhBo.Text.Trim()))
                        {
                            MessageBox.Show("Danh Bộ này đã được Lập Điều Chỉnh Biến Động", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        ///Biến lưu Điều Chỉnh về gì (Họ Tên,Địa Chỉ,Định Mức,Giá Biểu,MSThuế)
                        string ThongTin = "";
                        ///Thêm CTDCBD
                        CTDCBD ctdcbd = new CTDCBD();
                        ctdcbd.MaDCBD = _cDCBD.getDCBDbyMaDon_TXL(_dontxl.MaDon).MaDCBD;
                        ctdcbd.DanhBo = txtDanhBo.Text.Trim();
                        ctdcbd.HopDong = txtHopDong.Text.Trim();
                        ctdcbd.HoTen = txtHoTen.Text.Trim();
                        ctdcbd.DiaChi = txtDiaChi.Text.Trim();
                        if (_ttkhachhang != null)
                        {
                            ctdcbd.MaQuanPhuong = _ttkhachhang.Quan + " " + _ttkhachhang.Phuong;
                            ctdcbd.Ky = _ttkhachhang.Ky;
                            ctdcbd.Nam = _ttkhachhang.Nam;
                        }
                        ctdcbd.MSThue = txtMSThue.Text.Trim();
                        if (!string.IsNullOrEmpty(txtGiaBieu.Text.Trim()))
                            ctdcbd.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                        else
                            ctdcbd.GiaBieu = null;
                        if (!string.IsNullOrEmpty(txtDinhMuc.Text.Trim()))
                            ctdcbd.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                        else
                            ctdcbd.DinhMuc = null;
                        ctdcbd.SH = txtSH.Text.Trim();
                        ctdcbd.SX = txtSX.Text.Trim();
                        ctdcbd.DV = txtDV.Text.Trim();
                        ctdcbd.HCSN = txtHCSN.Text.Trim();
                        ctdcbd.Dot = txtDot.Text.Trim();

                        ///Họ Tên
                        if (txtHoTen_BD.Text.Trim() != "")
                        {
                            ThongTin += "Họ Tên. ";
                            ctdcbd.HoTen_BD = txtHoTen_BD.Text.Trim();
                        }
                        ///Địa Chỉ
                        if (txtDiaChi_BD.Text.Trim() != "")
                        {
                            ThongTin += "Địa Chỉ. ";
                            ctdcbd.DiaChi_BD = txtDiaChi_BD.Text.Trim();
                        }
                        ///Mã Số Thuế
                        if (txtMSThue_BD.Text.Trim() != "")
                        {
                            ThongTin += "MST. ";
                            ctdcbd.MSThue_BD = txtMSThue_BD.Text.Trim();
                        }
                        if (chkCatMSThue.Checked)
                        {
                            ThongTin += "MST. ";
                            ctdcbd.CatMSThue = true;
                        }
                        ///Giá Biểu
                        if (txtGiaBieu_BD.Text.Trim() != "")
                        {
                            ThongTin += "GB. ";
                            ctdcbd.GiaBieu_BD = int.Parse(txtGiaBieu_BD.Text.Trim());
                        }
                        ///Định Mức
                        if (txtDinhMuc_BD.Text.Trim() != "")
                        {
                            ThongTin += "ĐM. ";
                            ctdcbd.DinhMuc_BD = int.Parse(txtDinhMuc_BD.Text.Trim());
                        }
                        ///SH
                        if (txtSH_BD.Text.Trim() != "")
                            ctdcbd.SH_BD = txtSH_BD.Text.Trim();
                        ///SX
                        if (txtSX_BD.Text.Trim() != "")
                            ctdcbd.SX_BD = txtSX_BD.Text.Trim();
                        ///DV
                        if (txtDV_BD.Text.Trim() != "")
                            ctdcbd.DV_BD = txtDV_BD.Text.Trim();
                        ///HCSN
                        if (txtHCSN_BD.Text.Trim() != "")
                            ctdcbd.HCSN_BD = txtHCSN_BD.Text.Trim();

                        ctdcbd.ThongTin = ThongTin;
                        ctdcbd.HieuLucKy = txtHieuLucKy.Text.Trim();

                        BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                        if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                            ctdcbd.ChucVu = "GIÁM ĐỐC";
                        else
                            ctdcbd.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                        ctdcbd.NguoiKy = bangiamdoc.HoTen.ToUpper();
                        ctdcbd.PhieuDuocKy = true;

                        if (_cDCBD.ThemCTDCBD(ctdcbd))
                        {
                            MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                            txtMaDon.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chưa có Mã Đơn/Danh Bộ/Hiệu Lực Kỳ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                ///Nếu đơn thuộc Tổ Khách Hàng
                else
                if (_donkh != null && txtHieuLucKy.Text.Trim() != "")
                {
                    ///Nếu DCBD chưa có thì thêm vào
                    if (!_cDCBD.CheckDCBDbyMaDon(_donkh.MaDon))
                    //if (flagFirst)
                    {
                        DCBD dcbd = new DCBD();
                        dcbd.MaDon = _donkh.MaDon;
                        if (_direct)
                        {
                            ///mới check DonKH còn KTXM chưa
                            //string a, b, c;
                            //_cDonKH.GetInfobyMaDon(_donkh.MaDon, "DCBD", out a, out b, out c);
                            //_source.Add("MaNoiChuyenDen", a);
                            if (!_source.ContainsKey("NoiChuyenDen"))
                                _source.Add("NoiChuyenDen", "");
                            //_source.Add("LyDoChuyenDen", c);
                        }
                        else
                        {
                            dcbd.MaNoiChuyenDen = decimal.Parse(_source["MaNoiChuyenDen"]);
                            dcbd.NoiChuyenDen = _source["NoiChuyenDen"];
                            dcbd.LyDoChuyenDen = _source["LyDoChuyenDen"];
                        }
                        if (_cDCBD.ThemDCBD(dcbd))
                        {
                            switch (_source["NoiChuyenDen"])
                            {
                                case "Khách Hàng":
                                    ///Báo cho bảng DonKH là đơn này đã được nơi nhận xử lý
                                    DonKH donkh = _cDonKH.getDonKHbyID(decimal.Parse(_source["MaNoiChuyenDen"]));
                                    donkh.Nhan = true;
                                    _cDonKH.SuaDonKH(donkh, true);
                                    break;
                                case "Kiểm Tra Xác Minh":
                                    ///Báo cho bảng KTXM là đơn này đã được nơi nhận xử lý
                                    KTXM ktxm = _cKTXM.getKTXMbyID(decimal.Parse(_source["MaNoiChuyenDen"]));
                                    ktxm.Nhan = true;
                                    _cKTXM.SuaKTXM(ktxm, true);
                                    break;
                            }
                            //_source.Add("MaDCBD", _cDCBD.getMaxMaDCBD().ToString());
                            //flagFirst = false;
                            if (string.IsNullOrEmpty(_donkh.TienTrinh))
                                _donkh.TienTrinh = "DCBD";
                            else
                                _donkh.TienTrinh += ",DCBD";
                            _donkh.Nhan = true;
                            _cDonKH.SuaDonKH(_donkh, true);
                        }
                    }
                    if (_cDCBD.CheckCTDCBDbyMaDonDanhBo(_donkh.MaDon, txtDanhBo.Text.Trim()))
                    {
                        MessageBox.Show("Danh Bộ này đã được Lập Điều Chỉnh Biến Động", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    ///Biến lưu Điều Chỉnh về gì (Họ Tên,Địa Chỉ,Định Mức,Giá Biểu,MSThuế)
                    string ThongTin = "";
                    ///Thêm CTDCBD
                    CTDCBD ctdcbd = new CTDCBD();
                    ctdcbd.MaDCBD = _cDCBD.getDCBDbyMaDon(_donkh.MaDon).MaDCBD;
                    ctdcbd.DanhBo = txtDanhBo.Text.Trim();
                    ctdcbd.HopDong = txtHopDong.Text.Trim();
                    ctdcbd.HoTen = txtHoTen.Text.Trim();
                    ctdcbd.DiaChi = txtDiaChi.Text.Trim();
                    if (_ttkhachhang != null)
                    {
                        ctdcbd.MaQuanPhuong = _ttkhachhang.Quan + " " + _ttkhachhang.Phuong;
                        ctdcbd.Ky = _ttkhachhang.Ky;
                        ctdcbd.Nam = _ttkhachhang.Nam;
                    }
                    ctdcbd.MSThue = txtMSThue.Text.Trim();
                    if (!string.IsNullOrEmpty(txtGiaBieu.Text.Trim()))
                        ctdcbd.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                    else
                        ctdcbd.GiaBieu = null;
                    if (!string.IsNullOrEmpty(txtDinhMuc.Text.Trim()))
                        ctdcbd.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                    else
                        ctdcbd.DinhMuc = null;
                    ctdcbd.SH = txtSH.Text.Trim();
                    ctdcbd.SX = txtSX.Text.Trim();
                    ctdcbd.DV = txtDV.Text.Trim();
                    ctdcbd.HCSN = txtHCSN.Text.Trim();
                    ctdcbd.Dot = txtDot.Text.Trim();
                    
                    ///Họ Tên
                    if (txtHoTen_BD.Text.Trim() != "")
                    {
                        ThongTin += "Họ Tên. ";
                        ctdcbd.HoTen_BD = txtHoTen_BD.Text.Trim();
                    }
                    ///Địa Chỉ
                    if (txtDiaChi_BD.Text.Trim() != "")
                    {
                        ThongTin += "Địa Chỉ. ";
                        ctdcbd.DiaChi_BD = txtDiaChi_BD.Text.Trim();
                    }
                    ///Mã Số Thuế
                    if (txtMSThue_BD.Text.Trim() != "")
                    {
                        ThongTin += "MST. ";
                        ctdcbd.MSThue_BD = txtMSThue_BD.Text.Trim();
                    }
                    if (chkCatMSThue.Checked)
                    {
                        ThongTin += "MST. ";
                        ctdcbd.CatMSThue = true;
                    }
                    ///Giá Biểu
                    if (txtGiaBieu_BD.Text.Trim() != "")
                    {
                        ThongTin += "GB. ";
                        ctdcbd.GiaBieu_BD = int.Parse(txtGiaBieu_BD.Text.Trim());
                    }
                    ///Định Mức
                    if (txtDinhMuc_BD.Text.Trim() != "")
                    {
                        ThongTin += "ĐM. ";
                        ctdcbd.DinhMuc_BD = int.Parse(txtDinhMuc_BD.Text.Trim());
                    }
                    ///SH
                    if (txtSH_BD.Text.Trim() != "")
                        ctdcbd.SH_BD = txtSH_BD.Text.Trim();
                    ///SX
                    if (txtSX_BD.Text.Trim() != "")
                        ctdcbd.SX_BD = txtSX_BD.Text.Trim();
                    ///DV
                    if (txtDV_BD.Text.Trim() != "")
                        ctdcbd.DV_BD = txtDV_BD.Text.Trim();
                    ///HCSN
                    if (txtHCSN_BD.Text.Trim() != "")
                        ctdcbd.HCSN_BD = txtHCSN_BD.Text.Trim();

                    ctdcbd.ThongTin = ThongTin;
                    ctdcbd.HieuLucKy = txtHieuLucKy.Text.Trim();

                    BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                    if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                        ctdcbd.ChucVu = "GIÁM ĐỐC";
                    else
                        ctdcbd.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                    ctdcbd.NguoiKy = bangiamdoc.HoTen.ToUpper();
                    ctdcbd.PhieuDuocKy = true;

                    if (_cDCBD.ThemCTDCBD(ctdcbd))
                    {
                        MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                        //DataRow dr = dsBaoCao.Tables["DCBD"].NewRow();

                        //dr["SoPhieu"] = _cDCBD.getMaxMaCTDCBD().ToString().Insert(_cDCBD.getMaxMaCTDCBD().ToString().Length - 2, "-");
                        //dr["ThongTin"] = ctdcbd.ThongTin;
                        //dr["HieuLucKy"] = ctdcbd.HieuLucKy;
                        //dr["Dot"] = ctdcbd.Dot;
                        /////Hiện tại xử lý mã số thuế như vậy
                        //if (ctdcbd.CatMSThue)
                        //    dr["MSThue"] = "MST: Cắt MST";
                        //if (!string.IsNullOrEmpty(ctdcbd.MSThue_BD))
                        //    dr["MSThue"] = "MST: " + ctdcbd.MSThue_BD;
                        //dr["DanhBo"] = ctdcbd.DanhBo.Insert(7, " ").Insert(4, " ");
                        //dr["HopDong"] = ctdcbd.HopDong;
                        //dr["HoTen"] = ctdcbd.HoTen;
                        //dr["DiaChi"] = ctdcbd.DiaChi;
                        //dr["MaQuanPhuong"] = ctdcbd.MaQuanPhuong;
                        //dr["GiaBieu"] = ctdcbd.GiaBieu;
                        //dr["DinhMuc"] = ctdcbd.DinhMuc;
                        /////Biến Động
                        //dr["HoTenBD"] = ctdcbd.HoTen_BD;
                        //dr["DiaChiBD"] = ctdcbd.DiaChi_BD;
                        //dr["GiaBieuBD"] = ctdcbd.GiaBieu_BD;
                        //dr["DinhMucBD"] = ctdcbd.DinhMuc_BD;
                        /////Ký Tên
                        //dr["ChucVu"] = ctdcbd.ChucVu;
                        //dr["NguoiKy"] = ctdcbd.NguoiKy;

                        //dsBaoCao.Tables["DCBD"].Rows.Add(dr);

                        //rptPhieuDCBD rpt = new rptPhieuDCBD();
                        //rpt.SetDataSource(dsBaoCao);
                        //frmBaoCao frm = new frmBaoCao(rpt);
                        //frm.ShowDialog();

                        Clear();
                        txtMaDon.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Chưa có Mã Đơn/Danh Bộ/Hiệu Lực Kỳ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void frmDCBD_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void dgvDSDonKH_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSDieuChinh.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSDieuChinh_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSDieuChinh.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSDieuChinh_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSDieuChinh.Columns[e.ColumnIndex].Name == "MaDC" && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (dgvDSDieuChinh.Columns[e.ColumnIndex].Name == "MaDon" && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void dgvDSDieuChinh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDSDieuChinh["DieuChinh", e.RowIndex].Value.ToString() == "Biến Động")
            {  
                if (dgvDSSoDangKy.RowCount > 0)
                {
                    CTDCBD ctdcbd = _cDCBD.getCTDCBDbyID(decimal.Parse(dgvDSDieuChinh["MaDC", e.RowIndex].Value.ToString()));
                    DataTable dt = (DataTable)dgvDSSoDangKy.DataSource;
                    DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                    foreach (DataRow itemRow in dt.Rows)
                    {
                        DataRow dr = dsBaoCao.Tables["ChiTietDieuChinh"].NewRow();

                        dr["SoPhieu"] = ctdcbd.MaCTDCBD.ToString().Insert(ctdcbd.MaCTDCBD.ToString().Length - 2, "-");
                        dr["ThongTin"] = ctdcbd.ThongTin;
                        dr["HieuLucKy"] = ctdcbd.HieuLucKy;
                        dr["DanhBo"] = ctdcbd.DanhBo.Insert(7, " ").Insert(4, " ");

                        if (ctdcbd.DCBD.ToXuLy)
                            dr["MaDon"] = ctdcbd.DCBD.MaDonTXL.Value.ToString().Insert(ctdcbd.DCBD.MaDonTXL.Value.ToString().Length - 2, "-");
                        else
                            dr["MaDon"] = ctdcbd.DCBD.MaDon.Value.ToString().Insert(ctdcbd.DCBD.MaDon.Value.ToString().Length - 2, "-");

                        dr["HoTen"] = ctdcbd.HoTen;
                        dr["DiaChi"] = ctdcbd.DiaChi;
                        dr["GiaBieu"] = ctdcbd.GiaBieu;
                        dr["DinhMuc"] = ctdcbd.DinhMuc;
                        dr["MSThue"] = ctdcbd.MSThue;
                        ///Biến Động
                        dr["HoTenBD"] = ctdcbd.HoTen_BD;
                        dr["DiaChiBD"] = ctdcbd.DiaChi_BD;
                        dr["GiaBieuBD"] = ctdcbd.GiaBieu_BD;
                        dr["DinhMucBD"] = ctdcbd.DinhMuc_BD;
                        dr["MSThueBD"] = ctdcbd.MSThue_BD;

                        dr["TenLCT"] = itemRow["TenLCT"].ToString();
                        dr["MaCT"] = itemRow["MaCT"].ToString();
                        dr["DiaChiCT"] = itemRow["DiaChi"].ToString();
                        dr["SoNKTong"] = itemRow["SoNKTong"].ToString();
                        dr["SoNKDangKy"] = itemRow["SoNKDangKy"].ToString();

                        dsBaoCao.Tables["ChiTietDieuChinh"].Rows.Add(dr);
                    }
                    rptChiTietDieuChinh rpt = new rptChiTietDieuChinh();
                    rpt.SetDataSource(dsBaoCao);
                    frmBaoCao frm = new frmBaoCao(rpt);
                    frm.ShowDialog();
                }
            }
            else
                if (dgvDSDieuChinh["DieuChinh", e.RowIndex].Value.ToString() == "Hóa Đơn")
                    MessageBox.Show("Tính năng này chưa được xây dựng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvLichSuChungTu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvLichSuChungTu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSChungTu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSChungTu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        #region Configure TextBox

        private void txtDanhBo_Leave(object sender, EventArgs e)
        {
            //txtHieuLucKy.Focus();
        }

        private void txtHieuLucKy_Leave(object sender, EventArgs e)
        {
            //txtHoTen_BD.Focus();
            //flagFirst = false;
        }

        private void txtHieuLucKy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtHoTen_BD.Focus();
        }

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtDiaChi.Focus();
        }

        private void txtDiaChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtMSThue.Focus();
        }

        private void txtMSThue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtGiaBieu.Focus();
        }

        private void txtGiaBieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtDinhMuc.Focus();
        }

        private void txtDinhMuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtHoTen_BD.Focus();
        }

        private void txtHoTen_BD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtDiaChi_BD.Focus();
        }

        private void txtDiaChi_BD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtMSThue_BD.Focus();
        }

        private void txtMSThue_BD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtGiaBieu_BD.Focus();
        }

        private void txtGiaBieu_BD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                txtDinhMuc_BD.Focus();
        }

        private void txtDinhMuc_BD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                dgvDSSoDangKy.Focus();
        }

        #endregion

        private void frmDCBD_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Add)
                btnLuu.PerformClick();
            if ((_donkh!=null||_dontxl!=null) && e.Control && e.KeyCode == Keys.D1)
            {
                Dictionary<string, string> source = new Dictionary<string, string>();
                source.Add("ChungCu", "False");
                if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
                {
                    source.Add("TXL", "True");
                    source.Add("MaDon", _dontxl.MaDon.ToString());
                }
                ///Đơn Tổ Khách Hàng
                else
                {
                    source.Add("TXL", "False");
                    source.Add("MaDon", _donkh.MaDon.ToString());
                }
                source.Add("DanhBo", txtDanhBo.Text.Trim());
                source.Add("HoTenKH", txtHoTen.Text.Trim());
                if (txtDiaChi.Text.Trim().Contains(","))
                    source.Add("DiaChiKH", txtDiaChi.Text.Trim().Substring(0, txtDiaChi.Text.Trim().IndexOf(",")));
                else
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
                {
                    dgvDSSoDangKy.DataSource = _cChungTu.LoadDSChungTubyDanhBo(txtDanhBo.Text.Trim());
                    LoadTongNK();
                }
                //thêmToolStripMenuItem.PerformClick();
            }
            if ((_donkh != null || _dontxl != null) && e.Control && e.KeyCode == Keys.D2)
            {
                Dictionary<string, string> source = new Dictionary<string, string>();
                source.Add("ChungCu", "False");
                if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
                {
                    source.Add("TXL", "True");
                    source.Add("MaDon", _dontxl.MaDon.ToString());
                }
                ///Đơn Tổ Khách Hàng
                else
                {
                    source.Add("TXL", "False");
                    source.Add("MaDon", _donkh.MaDon.ToString());
                }
                source.Add("DanhBo", txtDanhBo.Text.Trim());
                source.Add("HoTen", txtHoTen.Text.Trim());
                source.Add("DiaChi", txtDiaChi.Text.Trim());
                frmNhanDM frm = new frmNhanDM(source);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    dgvDSSoDangKy.DataSource = _cChungTu.LoadDSChungTubyDanhBo(txtDanhBo.Text.Trim());
                    LoadTongNK();
                }
                //nhậnĐịnhMứctoolStripMenuItem.PerformClick();
            }
            if (e.Control && e.KeyCode == Keys.D3)
            {
                if (!_flagCtrl3)
                {
                    _flagCtrl3 = true;
                    groupBox_DSSoDangKy.Height = 358;
                    dgvDSSoDangKy.Height = 330;
                    panel_LichSuDieuChinh.Location = new Point(0, 560);
                }
                else
                {
                    _flagCtrl3 = false;
                    groupBox_DSSoDangKy.Height = 188;
                    dgvDSSoDangKy.Height = 158;
                    panel_LichSuDieuChinh.Location = new Point(0, 386);
                }
            }
            if (e.Control && e.KeyCode == Keys.D4)
            {
                frmTimKiemChungTu frm = new frmTimKiemChungTu();
                frm.ShowDialog();
            }
        }

        private void lbDSHetHan_DoubleClick(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = _cChungTu.LoadDSCapDinhMucHetHan();

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataRow itemRow in dt.Rows)
            {
                if (!string.IsNullOrEmpty(itemRow["NgayHetHan"].ToString()))
                {
                    DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                    dr["TuNgay"] = "";
                    dr["DenNgay"] = "";
                    if (_cDCBD.checkCTDCBDbyDanhBoCreateDate(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())))
                    {
                        string a = _cDCBD.getCTDCBDbyDanhBoCreateDate(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())).ToString();
                        dr["SoPhieu"] = a.Insert(a.Length - 2, "-");
                    }
                    else
                        dr["SoPhieu"] = "";


                    if (_cChungTu.CheckMaDonbyDanhBoChungTu(itemRow["DanhBo"].ToString(), itemRow["MaCT"].ToString()))
                    {
                        decimal MaDon = _cChungTu.getMaDonbyDanhBoChungTu(itemRow["DanhBo"].ToString(), itemRow["MaCT"].ToString());
                        dr["MaDon"] = MaDon.ToString().Insert(MaDon.ToString().Length - 2, "-");
                    }
                    else
                        dr["MaDon"] = "";

                    if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                        dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                    dr["HoTen"] = itemRow["HoTen"];
                    dr["DiaChi"] = itemRow["DiaChi"];
                    dr["MaLCT"] = itemRow["MaLCT"];
                    dr["TenLCT"] = itemRow["TenLCT"];
                    dr["MaCT"] = itemRow["MaCT"];
                    dr["DinhMucCap"] = (int.Parse(itemRow["SoNKDangKy"].ToString()) * 4).ToString();
                    dr["NgayHetHan"] = itemRow["NgayHetHan"];
                    dr["DienThoai"] = itemRow["DienThoai"];
                    dr["GhiChu"] = itemRow["GhiChu"];
                    dsBaoCao.Tables["DSCapDinhMuc"].Rows.Add(dr);
                }
            }

            rptDSCapDinhMuc rpt = new rptDSCapDinhMuc();
            rpt.SetDataSource(dsBaoCao);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }

    }
}
