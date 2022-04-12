using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.QuanTri;
using DocSo_PC.LinQ;
using DocSo_PC.DAL.MaHoa;
using DocSo_PC.DAL;
using System.Transactions;
using DocSo_PC.BaoCao;
using DocSo_PC.BaoCao.MaHoa;
using DocSo_PC.GUI.BaoCao;
using DocSo_PC.DAL.Doi;

namespace DocSo_PC.GUI.MaHoa
{
    public partial class frmDonTu : Form
    {
        string _mnu = "mnuDonTu";
        CDonTu _cDonTu = new CDonTu();
        CThuTien _cThuTien = new CThuTien();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CThuongVu _cThuongVu = new CThuongVu();
        CDocSo _cDocSo = new CDocSo();
        wrDHN.wsDHN _wsDHN = new wrDHN.wsDHN();

        MaHoa_DonTu _dontu = null;
        HOADON _hoadon = null;

        public frmDonTu()
        {
            InitializeComponent();
        }

        private void frmNhanDon_Load(object sender, EventArgs e)
        {
            try
            {
                dgvDanhSach.AutoGenerateColumns = false;
                dgvDonTuLichSu.AutoGenerateColumns = false;
                cmbNoiChuyen.DataSource = _cDonTu.getDS_NoiChuyen();
                cmbNoiChuyen.ValueMember = "ID";
                cmbNoiChuyen.DisplayMember = "Name";
                cmbNoiChuyen.SelectedIndex = -1;
                cmbNoiNhan.DataSource = _cDonTu.getDS_NoiNhan();
                cmbNoiNhan.ValueMember = "ID";
                cmbNoiNhan.DisplayMember = "Name";
                cmbNoiNhan.SelectedIndex = -1;
                DataTable dt = _cNguoiDung.getDS_KTXM();
                DataRow dr = dt.NewRow();
                dr["MaND"] = 0;
                dr["HoTen"] = "Tất Cả";
                dt.Rows.InsertAt(dr, 0);
                cmbKTXM_DSChuyenKTXM.DataSource = dt;
                cmbKTXM_DSChuyenKTXM.ValueMember = "MaND";
                cmbKTXM_DSChuyenKTXM.DisplayMember = "HoTen";
                dt = _cDonTu.getDS_PhieuChuyenAll();
                cmbNoiDung.DataSource = dt;
                cmbNoiDung.ValueMember = "Name";
                cmbNoiDung.DisplayMember = "Name";
                cmbNoiDung.SelectedIndex = -1;
                string str = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (str == "")
                        str += dt.Rows[i]["Name"].ToString();
                    else
                        str += ";" + dt.Rows[i]["Name"].ToString();
                }
                chkcmbNoiDung.Properties.DataSource = dt;
                chkcmbNoiDung.Properties.ValueMember = "Name";
                chkcmbNoiDung.Properties.DisplayMember = "Name";
                chkcmbNoiDung.SetEditValue(str);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Nhận Đơn

        public void loadTTKH(HOADON entity)
        {
            txtDanhBo.Text = entity.DANHBA.Insert(7, " ").Insert(4, " ");
            txtHoTen.Text = entity.TENKH;
            txtDiaChi.Text = entity.SO + " " + entity.DUONG;
            txtGiaBieu.Text = entity.GB.ToString();
            if (entity.DM != null)
                txtDinhMuc.Text = entity.DM.ToString();
            else
                txtDinhMuc.Text = "";
            if (entity.DinhMucHN != null)
                txtDinhMucHN.Text = entity.DinhMucHN.Value.ToString();
            else
                txtDinhMucHN.Text = "";
        }

        public void loadDonTu(MaHoa_DonTu entity)
        {
            txtDanhBo.Text = entity.DanhBo.Insert(7, " ").Insert(4, " ");
            txtHoTen.Text = entity.HoTen;
            txtDiaChi.Text = entity.DiaChi;
            txtGiaBieu.Text = entity.GiaBieu.ToString();
            if (entity.DinhMuc != null)
                txtDinhMuc.Text = entity.DinhMuc.ToString();
            else
                txtDinhMuc.Text = "";
            if (entity.DinhMucHN != null)
                txtDinhMucHN.Text = entity.DinhMucHN.Value.ToString();
            else
                txtDinhMucHN.Text = "";
            txtNoiDung.Text = entity.NoiDung;
            txtGhiChu.Text = entity.GhiChu;
            lbTinhTrang.Text = "Tình Trạng: " + entity.TinhTrang;
            loadDonTu_LichSu(entity.ID);
        }

        public void Clear()
        {
            cmbNoiDung.SelectedIndex = -1;
            txtDanhBo.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            txtDinhMucHN.Text = "";
            txtNoiDung.Text = "";
            txtGhiChu.Text = "";
            ClearChuyenDon();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    if (_cDonTu.checkExists(txtDanhBo.Text.Trim().Replace(" ", ""), DateTime.Now) == true)
                    {
                        MessageBox.Show("Đã lập Đơn trong ngày", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MaHoa_DonTu en = new MaHoa_DonTu();
                    en.DanhBo = txtDanhBo.Text.Trim().Replace(" ", "");
                    en.HoTen = txtHoTen.Text.Trim();
                    en.DiaChi = txtDiaChi.Text.Trim();
                    if (txtGiaBieu.Text.Trim() != "")
                        en.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                    if (txtDinhMuc.Text.Trim() != "")
                        en.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                    if (txtDinhMucHN.Text.Trim() != "")
                        en.DinhMucHN = int.Parse(txtDinhMucHN.Text.Trim());
                    en.NoiDung = txtNoiDung.Text.Trim();
                    en.GhiChu = txtGhiChu.Text.Trim();
                    en.TinhTrang = "Tồn";
                    if (_hoadon != null)
                    {
                        en.MLT = _hoadon.MALOTRINH;
                        en.HopDong = _hoadon.HOPDONG;
                        en.Dot = _hoadon.DOT;
                        en.Ky = _hoadon.KY;
                        en.Nam = _hoadon.NAM;
                        en.Quan = _hoadon.Quan;
                        en.Phuong = _hoadon.Phuong;
                    }
                    if (_cDonTu.Them(en))
                    {
                        MessageBox.Show("Thành công\nMã đơn: " + en.ID.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        if (_dontu != null)
                        {
                            string flagID = _dontu.ID.ToString();
                            var transactionOptions = new TransactionOptions();
                            transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
                            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                            {
                                if (_cDonTu.Xoa(_dontu))
                                {
                                    _wsDHN.xoa_Folder_Hinh_MaHoa("DonTu", flagID);
                                    scope.Complete();
                                    scope.Dispose();
                                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Clear();
                                }
                            }
                        }
                }
                else
                    MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (_dontu != null)
                    {
                        _dontu.DanhBo = txtDanhBo.Text.Trim().Replace(" ", "");
                        _dontu.HoTen = txtHoTen.Text.Trim();
                        _dontu.DiaChi = txtDiaChi.Text.Trim();
                        if (txtGiaBieu.Text.Trim() != "")
                            _dontu.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                        if (txtDinhMuc.Text.Trim() != "")
                            _dontu.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                        if (txtDinhMucHN.Text.Trim() != "")
                            _dontu.DinhMucHN = int.Parse(txtDinhMucHN.Text.Trim());
                        _dontu.NoiDung = txtNoiDung.Text.Trim();
                        _dontu.GhiChu = txtGhiChu.Text.Trim();
                        if (_hoadon != null)
                        {
                            _dontu.MLT = _hoadon.MALOTRINH;
                            _dontu.Dot = _hoadon.DOT;
                            _dontu.Ky = _hoadon.KY;
                            _dontu.Nam = _hoadon.NAM;
                            _dontu.Quan = _hoadon.Quan;
                            _dontu.Phuong = _hoadon.Phuong;
                        }
                        if (_cDonTu.Sua(_dontu))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtDanhBo.Text.Trim().Replace(" ", "").Length == 11 && e.KeyChar == 13)
            {
                _hoadon = _cThuTien.GetMoiNhat(txtDanhBo.Text.Trim().Replace(" ", ""));
                if (_hoadon != null)
                {
                    loadTTKH(_hoadon);
                }
                else
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMaDon.Text.Trim() != "" && e.KeyChar == 13)
            {
                _dontu = _cDonTu.get(int.Parse(txtMaDon.Text.Trim()));
                if (_dontu != null)
                {
                    loadDonTu(_dontu);
                }
                else
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbNoiDung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNoiDung.SelectedIndex >= 0)
                txtNoiDung.Text = cmbNoiDung.SelectedValue.ToString();
            else
                txtNoiDung.Text = "";
        }

        #endregion

        #region Danh Sách

        public void loadDonTu_LichSu(int MaDon)
        {
            dgvDonTuLichSu.DataSource = _cDonTu.getDS_LichSu(MaDon);
        }

        public void ClearChuyenDon()
        {
            dateChuyen.Value = DateTime.Now;
            cmbNoiChuyen.SelectedIndex = -1;
            cmbNoiNhan.SelectedIndex = -1;
            cmbKTXM.DataSource = null;
            txtNoiDung_LichSu.Text = "";
            lbTinhTrang.Text = "Tình Trạng";
        }

        private void dgvDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _dontu = _cDonTu.get(int.Parse(dgvDanhSach.CurrentRow.Cells["ID"].Value.ToString()));
                loadDonTu(_dontu);
                if (dgvDanhSach.Columns[e.ColumnIndex].Name == "XemHinh")
                {
                    _cDonTu.LoadImageView(_cDonTu.imageToByteArray(_cDonTu.byteArrayToImage(_wsDHN.get_Hinh_MaHoa("DonTu", _dontu.ID.ToString(), _dontu.MaHoa_DonTu_Hinhs.SingleOrDefault().Name + _dontu.MaHoa_DonTu_Hinhs.SingleOrDefault().Loai))));
                }
            }
            catch
            {
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            string str = "";
            for (int i = 0; i < chkcmbNoiDung.Properties.Items.Count; i++)
                if (chkcmbNoiDung.Properties.Items[i].CheckState == CheckState.Checked)
                {
                    if (str == "")
                        str = chkcmbNoiDung.Properties.Items[i].Value.ToString();
                    else
                        str += ";" + chkcmbNoiDung.Properties.Items[i].Value.ToString();
                }
            dgvDanhSach.DataSource = _cDonTu.getDS(str, dateTuNgay.Value, dateDenNgay.Value);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (cmbNoiChuyen.SelectedIndex > -1)
                    {
                        foreach (DataGridViewRow item in dgvDanhSach.SelectedRows)
                        {
                            MaHoa_DonTu dontu = _cDonTu.get(int.Parse(item.Cells["ID"].Value.ToString()));
                            if (dontu != null)
                            {
                                MaHoa_DonTu_LichSu entity = new MaHoa_DonTu_LichSu();
                                entity.NgayChuyen = dateChuyen.Value;
                                entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                entity.NoiChuyen = cmbNoiChuyen.Text;
                                entity.ID_NoiNhan = int.Parse(cmbNoiNhan.SelectedValue.ToString());
                                entity.NoiNhan = cmbNoiNhan.Text;
                                entity.NoiDung = txtNoiDung_LichSu.Text.Trim();
                                entity.IDMaDon = dontu.ID;
                                if (cmbNoiNhan.SelectedValue.ToString() == "2")
                                {
                                    entity.ID_KTXM = int.Parse(cmbKTXM.SelectedValue.ToString());
                                    entity.KTXM = cmbKTXM.Text;
                                }
                                if (_cDonTu.Them_LichSu(entity) == true)
                                {
                                    
                                }
                            }
                        }
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearChuyenDon();
                        _cDonTu.Refresh();
                    }

                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbNoiNhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNoiNhan.Items.Count > 0 && cmbNoiNhan.SelectedIndex >= 0 && cmbNoiNhan.SelectedValue.ToString() == "2")
            {
                DataTable dt = _cNguoiDung.getDS_KTXM();
                cmbKTXM.DataSource = dt;
                cmbKTXM.ValueMember = "MaND";
                cmbKTXM.DisplayMember = "HoTen";
            }
        }

        private void dgvDonTuLichSu_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
                {
                    if (_dontu != null)
                    {
                        MaHoa_DonTu_LichSu en = _cDonTu.get_LicSu(int.Parse(e.Row.Cells["ID_DTLS"].Value.ToString()));
                        if (_cDonTu.Xoa_LichSu(en) == true)
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadDonTu_LichSu(_dontu.ID);
                            ClearChuyenDon();
                        }
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInDS_Click(object sender, EventArgs e)
        {
            try
            {
                dsBaoCao dsBaoCao = new dsBaoCao();
                foreach (DataGridViewRow item in dgvDanhSach.Rows)
                {
                    MaHoa_DonTu dontu = _cDonTu.get(int.Parse(item.Cells["ID"].Value.ToString()));
                    DataRow dr = dsBaoCao.Tables["BaoCao"].NewRow();
                    dr["TenPhong"] = CNguoiDung.TenPhong;
                    dr["DanhBo"] = dontu.DanhBo.Insert(7, " ").Insert(4, " ");
                    dr["HopDong"] = dontu.HopDong;
                    dr["HoTen"] = dontu.HoTen;
                    dr["DiaChi"] = dontu.DiaChi;
                    dr["GiaBieu"] = dontu.GiaBieu;
                    dr["DinhMuc"] = dontu.DinhMuc;
                    int Nam = dontu.Nam.Value;
                    int Ky = dontu.Ky.Value;
                    if (Ky == 12)
                    {
                        Nam++;
                        Ky = 1;
                    }
                    else
                        Ky++;
                    DocSo docso = _cDocSo.get_DocSo(dontu.DanhBo, Nam.ToString(), Ky.ToString("00"));
                    dr["TBTT"] = docso.TBTT;
                    dr["GhiChu"] = dontu.GhiChu;
                    dr["ChucVu"] = CNguoiDung.ChucVu.ToUpper();
                    dr["NguoiKy"] = CNguoiDung.NguoiKy;
                    dr["ChucVuDuyet"] = "DUYỆT\n" + _cThuongVu.getChucVu_Duyet().ToUpper();
                    dr["NguoiKyDuyet"] = _cThuongVu.getNguoiKy_Duyet();
                    dsBaoCao.Tables["BaoCao"].Rows.Add(dr);
                }
                rptDSDonTu rpt = new rptDSDonTu();
                rpt.SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Báo Cáo

        private void btnIn_DSChuyenKTXM_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt;
                if (cmbKTXM_DSChuyenKTXM.SelectedIndex == 0)
                    dt = _cDonTu.getDS_ChuyenKTXM(dateTu_DSChuyenKTXM.Value, dateDen_DSChuyenKTXM.Value);
                else
                    dt = _cDonTu.getDS_ChuyenKTXM(int.Parse(cmbKTXM_DSChuyenKTXM.SelectedValue.ToString()), dateTu_DSChuyenKTXM.Value, dateDen_DSChuyenKTXM.Value);
                if (dt != null && dt.Rows.Count > 0)
                {
                    dsBaoCao dsBaoCao = new dsBaoCao();
                    if (chkChuaKTXM_DSChuyenKTXM.Checked)
                        foreach (DataRow itemRow in dt.Rows)
                        {
                            if (bool.Parse(itemRow["KTXM"].ToString()) == false)
                            {
                                DataRow dr = dsBaoCao.Tables["BaoCao"].NewRow();

                                dr["ThoiGian"] = "Từ ngày " + dateTu_DSChuyenKTXM.Value.ToString("dd/MM/yyyy") + " đến ngày " + dateDen_DSChuyenKTXM.Value.ToString("dd/MM/yyyy");
                                dr["MaDon"] = itemRow["MaDon"].ToString();
                                dr["NgayChuyen"] = itemRow["NgayChuyen"];
                                //dr["NgayNhan"] = itemRow["NgayNhan"];
                                if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()) && itemRow["DanhBo"].ToString().Length == 11)
                                    dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                                dr["HoTen"] = itemRow["HoTen"];
                                dr["DiaChi"] = itemRow["DiaChi"];
                                dr["NoiDung"] = itemRow["NoiDung"];
                                dr["GhiChu"] = itemRow["NoiDungKTXM"];
                                dr["NguoiKTXM"] = itemRow["NguoiKTXM"];
                                dr["TenPhong"] = CNguoiDung.TenPhong.ToUpper();

                                dsBaoCao.Tables["BaoCao"].Rows.Add(dr);
                            }
                        }
                    else
                        foreach (DataRow itemRow in dt.Rows)
                        {
                            DataRow dr = dsBaoCao.Tables["BaoCao"].NewRow();

                            dr["ThoiGian"] = "Từ ngày " + dateTu_DSChuyenKTXM.Value.ToString("dd/MM/yyyy") + " đến ngày " + dateDen_DSChuyenKTXM.Value.ToString("dd/MM/yyyy");
                            dr["MaDon"] = itemRow["MaDon"].ToString();
                            dr["NgayChuyen"] = itemRow["NgayChuyen"];
                            //dr["NgayNhan"] = itemRow["NgayNhan"];
                            if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()) && itemRow["DanhBo"].ToString().Length == 11)
                                dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                            dr["HoTen"] = itemRow["HoTen"];
                            dr["DiaChi"] = itemRow["DiaChi"];
                            dr["NoiDung"] = itemRow["NoiDung"];
                            dr["GhiChu"] = itemRow["NoiDungKTXM"];
                            dr["NguoiKTXM"] = itemRow["NguoiKTXM"];
                            dr["KTXM"] = itemRow["KTXM"];
                            dr["NgayKTXM"] = itemRow["NgayKTXM"];
                            dr["TenPhong"] = CNguoiDung.TenPhong.ToUpper();

                            dsBaoCao.Tables["BaoCao"].Rows.Add(dr);
                        }
                    rptDSChuyenKTXM rpt = new rptDSChuyenKTXM();
                    rpt.SetDataSource(dsBaoCao);
                    frmShowBaoCao frm = new frmShowBaoCao(rpt);
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion



    }
}
