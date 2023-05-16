using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.DonTu;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Transactions;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using KTKS_DonKH.DAL.BamChi;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.DAL.CatHuyDanhBo;
using KTKS_DonKH.DAL.ThuTraLoi;
using KTKS_DonKH.DAL.TruyThu;
using KTKS_DonKH.DAL.ThuMoi;
using KTKS_DonKH.DAL.VanBan;

namespace KTKS_DonKH.GUI.DonTu
{
    public partial class frmCapNhatDonTu_Thumbnail : Form
    {
        CNoiChuyen _cNoiChuyen = new CNoiChuyen();
        CDonTu _cDonTu = new CDonTu();
        DonTu_ChiTiet _dontu_ChiTiet = null;
        DonTu_LichSu _dontu_LichSu = null;
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();
        CKTXM _cKTXM = new CKTXM();
        CBamChi _cBamChi = new CBamChi();
        CDCBD _cDCBD = new CDCBD();
        CCHDB _cCHDB = new CCHDB();
        CToTrinh _cToTrinh = new CToTrinh();
        CTTTL _cTTTL = new CTTTL();
        CTruyThuTienNuoc _cTTTN = new CTruyThuTienNuoc();
        CGianLan _cGL = new CGianLan();
        CThuMoi _cThuMoi = new CThuMoi();
        CVanBan _cVanBan = new CVanBan();
        string _TableName = null;
        int _ID = -1;
        int _selectedIndex = -1;

        public frmCapNhatDonTu_Thumbnail()
        {
            InitializeComponent();
        }

        public frmCapNhatDonTu_Thumbnail(DonTu_ChiTiet dontu_ChiTiet)
        {
            InitializeComponent();
            _dontu_ChiTiet = dontu_ChiTiet;
        }

        public frmCapNhatDonTu_Thumbnail(DonTu_ChiTiet dontu_ChiTiet, string TableName, int ID)
        {
            InitializeComponent();
            _dontu_ChiTiet = dontu_ChiTiet;
            _TableName = TableName;
            _ID = ID;
            switch (TableName)
            {
                case "KTXM_ChiTiet":
                    _selectedIndex = 5;
                    break;
                case "DCBD_ChiTietBienDong":
                case "DCBD_ChiTietHoaDon":
                    _selectedIndex = 6;
                    break;
                case "CHDB_ChiTietCatTam":
                case "CHDB_ChiTietCatHuy":
                case "CHDB_Phieu":
                    _selectedIndex = 7;
                    break;
                case "TruyThuTienNuoc_ChiTiet":
                case "GianLan_ChiTiet":
                    _selectedIndex = 8;
                    break;
                case "ThuTraLoi_ChiTiet":
                    _selectedIndex = 9;
                    break;
                case "ThuMoi_ChiTiet":
                    _selectedIndex = 10;
                    break;
                case "ToTrinh_ChiTiet":
                    _selectedIndex = 11;
                    break;
                case "VanBan_ChiTiet":
                    _selectedIndex = 38;
                    break;
            }
        }

        private void frmCapNhanDonTu_Thumbnail_Load(object sender, EventArgs e)
        {
            this.Location = new Point(200, 120);
            dgvLichSuDonTu.AutoGenerateColumns = false;

            cmbNoiChuyen.DataSource = _cNoiChuyen.GetDS("DonTuChuyen");
            cmbNoiChuyen.ValueMember = "ID";
            cmbNoiChuyen.DisplayMember = "Name";
            cmbNoiChuyen.SelectedValue = _selectedIndex;

            chkcmbNoiNhan.Properties.DataSource = _cNoiChuyen.GetDS("DonTuNhan");
            chkcmbNoiNhan.Properties.ValueMember = "ID";
            chkcmbNoiNhan.Properties.DisplayMember = "Name";

            if (_dontu_ChiTiet != null)
            {
                if (_dontu_ChiTiet.DonTu.DonTu_ChiTiets.Count == 1)
                    txtMaDon.Text = _dontu_ChiTiet.MaDon.Value.ToString();
                else
                    txtMaDon.Text = _dontu_ChiTiet.MaDon.Value.ToString() + "." + _dontu_ChiTiet.STT.Value.ToString();
                dgvLichSuDonTu.DataSource = _cDonTu.getDS_LichSu(_dontu_ChiTiet.MaDon.Value, _dontu_ChiTiet.STT.Value);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (_dontu_LichSu != null)
                {
                    if (CTaiKhoan.Admin != true && CTaiKhoan.TruongPhong != true && CTaiKhoan.ThuKy != true)
                        if (CTaiKhoan.MaUser != _dontu_LichSu.CreateBy)
                        {
                            MessageBox.Show("Bạn không phải người tạo nên không sửa được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    bool flag = false;//ghi nhận có chọn checkcombobox
                    if (cmbNoiChuyen.SelectedIndex > -1)
                    {
                        for (int i = 0; i < chkcmbNoiNhan.Properties.Items.Count; i++)
                            if (chkcmbNoiNhan.Properties.Items[i].CheckState == CheckState.Checked)
                            {
                                //đi KTXM
                                if (chkcmbNoiNhan.Properties.Items[i].Value.ToString() == "5" || chkcmbNoiNhan.Properties.Items[i].Value.ToString() == "39")
                                {
                                    for (int j = 0; j < chkcmbNoiNhanKTXM.Properties.Items.Count; j++)
                                        if (chkcmbNoiNhanKTXM.Properties.Items[j].CheckState == CheckState.Checked)
                                        {
                                            _dontu_LichSu.NgayChuyen = dateChuyen.Value;
                                            _dontu_LichSu.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                            _dontu_LichSu.NoiChuyen = cmbNoiChuyen.Text;
                                            _dontu_LichSu.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                            _dontu_LichSu.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                            _dontu_LichSu.NoiDung = txtNoiDung_LichSu.Text.Trim();
                                            //_dontu_LichSu.MaDon = _dontu.MaDon;
                                            _dontu_LichSu.ID_KTXM = int.Parse(chkcmbNoiNhanKTXM.Properties.Items[j].Value.ToString());
                                            _dontu_LichSu.KTXM = chkcmbNoiNhanKTXM.Properties.Items[j].ToString();
                                            _cDonTu.SubmitChanges();
                                        }
                                }
                                else
                                {
                                    _dontu_LichSu.NgayChuyen = dateChuyen.Value;
                                    _dontu_LichSu.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                    _dontu_LichSu.NoiChuyen = cmbNoiChuyen.Text;
                                    _dontu_LichSu.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                    _dontu_LichSu.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                    _dontu_LichSu.NoiDung = txtNoiDung_LichSu.Text.Trim();
                                    //_dontu_LichSu.MaDon = _dontu.MaDon;
                                    _cDonTu.SubmitChanges();
                                }
                                flag = true;
                            }
                        if (flag == false)
                        {
                            _dontu_LichSu.NgayChuyen = dateChuyen.Value;
                            _dontu_LichSu.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                            _dontu_LichSu.NoiChuyen = cmbNoiChuyen.Text;
                            //_dontu_LichSu.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                            //_dontu_LichSu.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                            _dontu_LichSu.NoiDung = txtNoiDung_LichSu.Text.Trim();
                            //_dontu_LichSu.MaDon = _dontu.MaDon;
                            _cDonTu.SubmitChanges();
                        }
                    }
                }
                else
                    if (_dontu_ChiTiet != null)
                    {
                        bool flag = false;//ghi nhận có chọn checkcombobox
                        if (cmbNoiChuyen.SelectedIndex > -1)
                        {
                            for (int i = 0; i < chkcmbNoiNhan.Properties.Items.Count; i++)
                                if (chkcmbNoiNhan.Properties.Items[i].CheckState == CheckState.Checked)
                                {
                                    //đi KTXM
                                    if (chkcmbNoiNhan.Properties.Items[i].Value.ToString() == "5" || chkcmbNoiNhan.Properties.Items[i].Value.ToString() == "39")
                                    {
                                        for (int j = 0; j < chkcmbNoiNhanKTXM.Properties.Items.Count; j++)
                                            if (chkcmbNoiNhanKTXM.Properties.Items[j].CheckState == CheckState.Checked)
                                            {
                                                DonTu_LichSu entity = new DonTu_LichSu();
                                                entity.NgayChuyen = dateChuyen.Value;
                                                entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                                entity.NoiChuyen = cmbNoiChuyen.Text;
                                                entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                                entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                                entity.NoiDung = txtNoiDung_LichSu.Text.Trim();
                                                entity.MaDon = _dontu_ChiTiet.MaDon;
                                                entity.STT = _dontu_ChiTiet.STT;
                                                entity.ID_KTXM = int.Parse(chkcmbNoiNhanKTXM.Properties.Items[j].Value.ToString());
                                                entity.KTXM = chkcmbNoiNhanKTXM.Properties.Items[j].ToString();
                                                _cDonTu.Them_LichSu(entity);
                                            }
                                    }
                                    else
                                    {
                                        DonTu_LichSu entity = new DonTu_LichSu();
                                        entity.NgayChuyen = dateChuyen.Value;
                                        entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                        entity.NoiChuyen = cmbNoiChuyen.Text;
                                        entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                        entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                        entity.NoiDung = txtNoiDung_LichSu.Text.Trim();
                                        entity.MaDon = _dontu_ChiTiet.MaDon;
                                        entity.STT = _dontu_ChiTiet.STT;
                                        if (_TableName != null)
                                        {
                                            entity.TableName = _TableName;
                                            entity.IDCT = _ID;
                                        }
                                        _cDonTu.Them_LichSu(entity);
                                    }
                                    flag = true;
                                }
                            if (flag == false)
                            {
                                if (chkHoanThanh.Checked == true)
                                {
                                    if (txtNoiDung_LichSu.Text.Trim() != "")
                                    {
                                        //cập nhật tình trạng
                                        _dontu_ChiTiet.HoanThanh = chkHoanThanh.Checked;
                                        _dontu_ChiTiet.HoanThanh_Ngay = DateTime.Now;
                                        _dontu_ChiTiet.HoanThanh_GhiChu = txtNoiDung_LichSu.Text.Trim();
                                        _cDonTu.SubmitChanges();
                                        //
                                        DonTu_LichSu entity = new DonTu_LichSu();
                                        entity.NgayChuyen = dateChuyen.Value;
                                        entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                        entity.NoiChuyen = cmbNoiChuyen.Text;
                                        //entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                        //entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                        entity.NoiDung = txtNoiDung_LichSu.Text.Trim();
                                        entity.MaDon = _dontu_ChiTiet.MaDon;
                                        entity.STT = _dontu_ChiTiet.STT;
                                        if (_TableName != null)
                                        {
                                            entity.TableName = _TableName;
                                            entity.IDCT = _ID;
                                        }
                                        _cDonTu.Them_LichSu(entity);
                                    }
                                    else
                                        MessageBox.Show("Thiếu Nội Dung lý do Hoàn Thành", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    DonTu_LichSu entity = new DonTu_LichSu();
                                    entity.NgayChuyen = dateChuyen.Value;
                                    entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                    entity.NoiChuyen = cmbNoiChuyen.Text;
                                    //entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                    //entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                    entity.NoiDung = txtNoiDung_LichSu.Text.Trim();
                                    entity.MaDon = _dontu_ChiTiet.MaDon;
                                    entity.STT = _dontu_ChiTiet.STT;
                                    if (_TableName != null)
                                    {
                                        entity.TableName = _TableName;
                                        entity.IDCT = _ID;
                                    }
                                    _cDonTu.Them_LichSu(entity);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Chưa chọn Nơi Chuyển", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                dgvLichSuDonTu.DataSource = _cDonTu.getDS_LichSu(_dontu_ChiTiet.MaDon.Value, _dontu_ChiTiet.STT.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLichSuDonTu_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                ///Khi chuột phải Selected-Row sẽ được chuyển đến nơi click chuột
                dgvLichSuDonTu.CurrentCell = dgvLichSuDonTu.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dgvLichSuDonTu_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && (_dontu_ChiTiet != null))
            {
                contextMenuStrip1.Show(dgvLichSuDonTu, new Point(e.X, e.Y));
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn???", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        if (CTaiKhoan.Admin == true || CTaiKhoan.TruongPhong == true)
                        {
                            DonTu_LichSu dtls = _cDonTu.get_LichSu(int.Parse(dgvLichSuDonTu.CurrentRow.Cells["ID"].Value.ToString()));
                            int MaDon = dtls.MaDon.Value, STT = dtls.STT.Value;
                            bool HoanThanh = dtls.HoanThanh;
                            if (_cDonTu.Xoa_LichSu(dtls, true))
                            {
                                if (HoanThanh == true)
                                {
                                    DonTu_ChiTiet dtct = _cDonTu.get_ChiTiet(MaDon, STT);
                                    dtct.HoanThanh = false;
                                    dtct.HoanThanh_Ngay = null;
                                    dtct.HoanThanh_GhiChu = null;
                                    _cDonTu.SubmitChanges();
                                }
                                scope.Complete();
                            }
                            else
                                MessageBox.Show("Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            DonTu_LichSu dtls = _cDonTu.get_LichSu(int.Parse(dgvLichSuDonTu.CurrentRow.Cells["ID"].Value.ToString()));
                            int MaDon = dtls.MaDon.Value, STT = dtls.STT.Value;
                            bool HoanThanh = dtls.HoanThanh;
                            if (_cDonTu.Xoa_LichSu(dtls, CTaiKhoan.MaUser))
                            {
                                if (HoanThanh == true)
                                {
                                    DonTu_ChiTiet dtct = _cDonTu.get_ChiTiet(MaDon, STT);
                                    dtct.HoanThanh = false;
                                    dtct.HoanThanh_Ngay = null;
                                    dtct.HoanThanh_GhiChu = null;
                                    _cDonTu.SubmitChanges();
                                }
                                scope.Complete();
                            }
                            else
                                MessageBox.Show("Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _cDonTu.Refresh();
                    dgvLichSuDonTu.DataSource = _cDonTu.getDS_LichSu(_dontu_ChiTiet.MaDon.Value, _dontu_ChiTiet.STT.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLichSuDonTu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _dontu_LichSu = _cDonTu.get_LichSu(int.Parse(dgvLichSuDonTu.CurrentRow.Cells["ID"].Value.ToString()));
                FillLichSu(_dontu_LichSu);
            }
            catch
            {

            }
        }

        public void FillLichSu(DonTu_LichSu en)
        {
            for (int i = 0; i < chkcmbNoiNhan.Properties.Items.Count; i++)
                chkcmbNoiNhan.Properties.Items[i].CheckState = CheckState.Unchecked;
            for (int i = 0; i < chkcmbNoiNhanKTXM.Properties.Items.Count; i++)
                chkcmbNoiNhanKTXM.Properties.Items[i].CheckState = CheckState.Unchecked;
            dateChuyen.Value = en.NgayChuyen.Value;

            if (en.ID_NoiChuyen != null)
                cmbNoiChuyen.SelectedValue = en.ID_NoiChuyen;
            else
                cmbNoiChuyen.SelectedIndex = -1;

            if (en.ID_NoiNhan != null)
                chkcmbNoiNhan.SetEditValue(en.ID_NoiNhan);

            if (en.ID_KTXM != null)
                chkcmbNoiNhanKTXM.SetEditValue(en.ID_KTXM);

            txtNoiDung_LichSu.Text = en.NoiDung;
        }

        private void chkcmbNoiNhan_EditValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < chkcmbNoiNhan.Properties.Items.Count; i++)
                if (chkcmbNoiNhan.Properties.Items[i].CheckState == CheckState.Checked && (chkcmbNoiNhan.Properties.Items[i].Value.ToString() == "5" || chkcmbNoiNhan.Properties.Items[i].Value.ToString() == "39"))
                {
                    DataTable dt = new DataTable();
                    dt = _cTaiKhoan.getDS_KTXM(CTaiKhoan.KyHieuMaTo);
                    chkcmbNoiNhanKTXM.Properties.DataSource = dt;
                    chkcmbNoiNhanKTXM.Properties.ValueMember = "MaU";
                    chkcmbNoiNhanKTXM.Properties.DisplayMember = "HoTen";
                }
        }

        private void txtMa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtMa.Text.Trim()))
            {
                if (lstMa.FindItemWithText(txtMa.Text.Trim().ToUpper()) == null)
                {
                    lstMa.Items.Add(txtMa.Text.Trim().ToUpper());
                    lstMa.EnsureVisible(lstMa.Items.Count - 1);
                    txtMa.Text = "";
                }
            }
        }

        private void btnCapNhat_Nhieu_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem item in lstMa.Items)
                {
                    int MaDon = 0, STT = 0, ID = 0;
                    switch (_TableName)
                    {
                        case "KTXM_ChiTiet":

                            break;
                        case "DCBD_ChiTietBienDong":
                            DCBD_ChiTietBienDong bd = _cDCBD.getBienDong(decimal.Parse(item.Text.Replace("-", "")));
                            if (bd != null)
                            {
                                MaDon = bd.DCBD.MaDonMoi.Value;
                                STT = bd.STT.Value;
                                ID = (int)bd.MaCTDCBD;
                            }
                            break;
                        case "DCBD_ChiTietHoaDon":
                            DCBD_ChiTietHoaDon hd = _cDCBD.getHoaDon(decimal.Parse(item.Text.Replace("-", "")));
                            if (hd != null)
                            {
                                MaDon = hd.DCBD.MaDonMoi.Value;
                                STT = hd.STT.Value;
                                ID = (int)hd.MaCTDCHD;
                            }
                            break;
                        case "CHDB_ChiTietCatTam":
                            CHDB_ChiTietCatTam ct = _cCHDB.GetCTCTDB(decimal.Parse(item.Text.Replace("-", "")));
                            if (ct != null)
                            {
                                MaDon = ct.CHDB.MaDonMoi.Value;
                                STT = ct.STT.Value;
                                ID = (int)ct.MaCTCTDB;
                            }
                            break;
                        case "CHDB_ChiTietCatHuy":
                            CHDB_ChiTietCatHuy ch = _cCHDB.GetCTCHDB(decimal.Parse(item.Text.Replace("-", "")));
                            if (ch != null)
                            {
                                MaDon = ch.CHDB.MaDonMoi.Value;
                                STT = ch.STT.Value;
                                ID = (int)ch.MaCTCHDB;
                            }
                            break;
                        case "CHDB_Phieu":
                            CHDB_Phieu ph = _cCHDB.GetPhieuHuy(decimal.Parse(item.Text.Replace("-", "")));
                            if (ph != null)
                            {
                                MaDon = ph.CHDB.MaDonMoi.Value;
                                STT = ph.STT.Value;
                                ID = (int)ph.MaYCCHDB;
                            }
                            break;
                        case "TruyThuTienNuoc_ChiTiet":
                            TruyThuTienNuoc_ChiTiet tttn = _cTTTN.get_ChiTiet(decimal.Parse(item.Text.Replace("-", "")));
                            if (tttn != null)
                            {
                                MaDon = tttn.TruyThuTienNuoc.MaDonMoi.Value;
                                STT = tttn.STT.Value;
                                ID = (int)tttn.IDCT;
                            }
                            break;
                        case "GianLan_ChiTiet":
                            GianLan_ChiTiet gl = _cGL.get_ChiTiet(int.Parse(item.Text.Replace("-", "")));
                            if (gl != null)
                            {
                                MaDon = gl.GianLan.MaDonMoi.Value;
                                STT = gl.STT.Value;
                                ID = (int)gl.MaCTGL;
                            }
                            break;
                        case "ThuTraLoi_ChiTiet":
                            ThuTraLoi_ChiTiet tttl = _cTTTL.GetCT(decimal.Parse(item.Text.Replace("-", "")));
                            if (tttl != null)
                            {
                                MaDon = tttl.ThuTraLoi.MaDonMoi.Value;
                                STT = tttl.STT.Value;
                                ID = (int)tttl.MaCTTTTL;
                            }
                            break;
                        case "ThuMoi_ChiTiet":
                            ThuMoi_ChiTiet tm = _cThuMoi.get_ChiTiet(int.Parse(item.Text.Replace("-", "")));
                            if (tm != null)
                            {
                                MaDon = tm.ThuMoi.MaDonMoi.Value;
                                STT = tm.STT.Value;
                                ID = (int)tm.IDCT;
                            }
                            break;
                        case "ToTrinh_ChiTiet":
                            ToTrinh_ChiTiet tt = _cToTrinh.get_ChiTiet(int.Parse(item.Text.Replace("-", "")));
                            if (tt != null)
                            {
                                MaDon = tt.ToTrinh.MaDonMoi.Value;
                                STT = tt.STT.Value;
                                ID = (int)tt.IDCT;
                            }
                            break;
                        case "VanBan_ChiTiet":
                            VanBan_ChiTiet vb = _cVanBan.get_ChiTiet(int.Parse(item.Text.Replace("-", "")));
                            if (vb != null)
                            {
                                MaDon = vb.VanBan.MaDon.Value;
                                STT = vb.STT.Value;
                                ID = (int)vb.IDCT;
                            }
                            break;
                    }
                    if (MaDon > 0 && ID > 0 && STT > 0)
                    {
                        bool flag = false;//ghi nhận có chọn checkcombobox
                        if (cmbNoiChuyen.SelectedIndex > -1)
                        {
                            for (int i = 0; i < chkcmbNoiNhan.Properties.Items.Count; i++)
                                if (chkcmbNoiNhan.Properties.Items[i].CheckState == CheckState.Checked)
                                {
                                    //đi KTXM
                                    if (chkcmbNoiNhan.Properties.Items[i].Value.ToString() == "5" || chkcmbNoiNhan.Properties.Items[i].Value.ToString() == "39")
                                    {
                                        for (int j = 0; j < chkcmbNoiNhanKTXM.Properties.Items.Count; j++)
                                            if (chkcmbNoiNhanKTXM.Properties.Items[j].CheckState == CheckState.Checked)
                                            {
                                                DonTu_LichSu entity = new DonTu_LichSu();
                                                entity.NgayChuyen = dateChuyen.Value;
                                                entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                                entity.NoiChuyen = cmbNoiChuyen.Text;
                                                entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                                entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                                entity.NoiDung = txtNoiDung_LichSu.Text.Trim();
                                                entity.MaDon = MaDon;
                                                entity.STT = STT;
                                                entity.ID_KTXM = int.Parse(chkcmbNoiNhanKTXM.Properties.Items[j].Value.ToString());
                                                entity.KTXM = chkcmbNoiNhanKTXM.Properties.Items[j].ToString();
                                                _cDonTu.Them_LichSu(entity);
                                            }
                                    }
                                    else
                                    {
                                        DonTu_LichSu entity = new DonTu_LichSu();
                                        entity.NgayChuyen = dateChuyen.Value;
                                        entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                        entity.NoiChuyen = cmbNoiChuyen.Text;
                                        entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                        entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                        entity.NoiDung = txtNoiDung_LichSu.Text.Trim();
                                        entity.MaDon = MaDon;
                                        entity.STT = STT;
                                        if (_TableName != null)
                                        {
                                            entity.TableName = _TableName;
                                            entity.IDCT = ID;
                                        }
                                        _cDonTu.Them_LichSu(entity);
                                    }
                                    flag = true;
                                }
                            if (flag == false)
                            {
                                if (chkHoanThanh.Checked == true)
                                {
                                    if (txtNoiDung_LichSu.Text.Trim() != "")
                                    {
                                        //cập nhật tình trạng
                                        _dontu_ChiTiet.HoanThanh = chkHoanThanh.Checked;
                                        _dontu_ChiTiet.HoanThanh_Ngay = DateTime.Now;
                                        _dontu_ChiTiet.HoanThanh_GhiChu = txtNoiDung_LichSu.Text.Trim();
                                        _cDonTu.SubmitChanges();
                                        //
                                        DonTu_LichSu entity = new DonTu_LichSu();
                                        entity.NgayChuyen = dateChuyen.Value;
                                        entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                        entity.NoiChuyen = cmbNoiChuyen.Text;
                                        //entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                        //entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                        entity.NoiDung = txtNoiDung_LichSu.Text.Trim();
                                        entity.MaDon = MaDon;
                                        entity.STT = STT;
                                        if (_TableName != null)
                                        {
                                            entity.TableName = _TableName;
                                            entity.IDCT = ID;
                                        }
                                        _cDonTu.Them_LichSu(entity);
                                    }
                                    else
                                        MessageBox.Show("Thiếu Nội Dung lý do Hoàn Thành", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    DonTu_LichSu entity = new DonTu_LichSu();
                                    entity.NgayChuyen = dateChuyen.Value;
                                    entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                    entity.NoiChuyen = cmbNoiChuyen.Text;
                                    //entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                    //entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                    entity.NoiDung = txtNoiDung_LichSu.Text.Trim();
                                    entity.MaDon = MaDon;
                                    entity.STT = STT;
                                    if (_TableName != null)
                                    {
                                        entity.TableName = _TableName;
                                        entity.IDCT = ID;
                                    }
                                    _cDonTu.Them_LichSu(entity);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Chưa chọn Nơi Chuyển", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                lstMa.Items.Clear();
                MessageBox.Show("Đã xử lý", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
