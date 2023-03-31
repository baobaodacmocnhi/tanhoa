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
        CToTrinh _cToTrinh = new CToTrinh();
        CDCBD _cDCBD = new CDCBD();
        CTo _cTo = new CTo();
        CPhieuChuyen _cPhieuChuyen = new CPhieuChuyen();
        wrDHN.wsDHN _wsDHN = new wrDHN.wsDHN();
        wrThuongVu.wsThuongVu _wsThuongVu = new wrThuongVu.wsThuongVu();
        CDanhBoBoQua _cDBBQ = new CDanhBoBoQua();

        MaHoa_DonTu _dontu = null;
        BienDong _biendong = null;

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
                dt = _cPhieuChuyen.getDS_All();
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
                cmbTimTheo.SelectedIndex = 0;
                List<To> lst = _cTo.getDS_HanhThu();
                To en = new To();
                en.MaTo = 0;
                en.TenTo = "Tất Cả";
                lst.Insert(0, en);
                cmbTo.DataSource = lst;
                cmbTo.DisplayMember = "TenTo";
                cmbTo.ValueMember = "MaTo";
                cmbNam.DataSource = _cDocSo.getDS_Nam();
                cmbNam.DisplayMember = "Nam";
                cmbNam.ValueMember = "Nam";
                cmbKy.SelectedItem = CNguoiDung.Ky;
                cmbDot.SelectedItem = CNguoiDung.Dot;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Nhận Đơn

        public void loadTTKH(BienDong entity)
        {
            txtDanhBo.Text = entity.DanhBa.Insert(7, " ").Insert(4, " ");
            txtHoTen.Text = entity.TenKH;
            txtDiaChi.Text = entity.So + " " + entity.Duong;
            txtGiaBieu.Text = entity.GB.ToString();
            if (entity.DM != null)
                txtDinhMuc.Text = entity.DM.ToString();
            else
                txtDinhMuc.Text = "";
            if (entity.DMHN != null)
                txtDinhMucHN.Text = entity.DMHN.Value.ToString();
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

            dgvHinh.Rows.Clear();
            foreach (MaHoa_DonTu_Hinh item in entity.MaHoa_DonTu_Hinhs.ToList())
            {
                var index = dgvHinh.Rows.Add();
                dgvHinh.Rows[index].Cells["ID_Hinh"].Value = item.ID;
                dgvHinh.Rows[index].Cells["Name_Hinh"].Value = item.Name;
                dgvHinh.Rows[index].Cells["Loai_Hinh"].Value = item.Loai;
            }
        }

        public void Clear()
        {
            try
            {
                dgvHinh.Rows.Clear();
                cmbNoiDung.SelectedIndex = -1;
                txtDanhBo.Text = "";
                txtHoTen.Text = "";
                txtDiaChi.Text = "";
                txtGiaBieu.Text = "";
                txtDinhMuc.Text = "";
                txtDinhMucHN.Text = "";
                txtNoiDung.Text = "";
                txtGhiChu.Text = "";
                _dontu = null;
                _biendong = null;
                ClearChuyenDon();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    if (txtNoiDung.Text.Trim().Contains("Giá Biểu") && _cDBBQ.checkExist(txtDanhBo.Text.Trim().Replace(" ", "")))
                    {
                        MessageBox.Show("Danh Bộ nằm trong danh sách bỏ qua", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (txtNoiDung.Text.Trim().Contains("Giá Biểu") && _wsThuongVu.checkExists_DonTu(txtDanhBo.Text.Trim().Replace(" ", ""), "Giá Biểu", "30"))
                    {
                        MessageBox.Show("Danh Bộ có đơn Thương Vụ cùng nội dung trong 30 ngày", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (_biendong != null)
                    {
                        en.MLT = _biendong.MLT1;
                        en.Dot = int.Parse(_biendong.Dot);
                        en.Ky = int.Parse(_biendong.Ky);
                        en.Nam = _biendong.Nam;
                        en.Quan = _biendong.Quan;
                        en.Phuong = _biendong.Phuong;
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
                    if (MessageBox.Show("Bạn có chắc chắn???", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
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
                        if (_cDonTu.checkExists(txtDanhBo.Text.Trim().Replace(" ", ""), DateTime.Now) == true)
                        {
                            MessageBox.Show("Đã lập Đơn trong ngày", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (txtNoiDung.Text.Trim().Contains("Giá Biểu") && _cDBBQ.checkExist(txtDanhBo.Text.Trim().Replace(" ", "")))
                        {
                            MessageBox.Show("Danh Bộ nằm trong danh sách bỏ qua", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
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
                        if (_biendong != null)
                        {
                            _dontu.MLT = _biendong.MLT1;
                            _dontu.Dot = int.Parse(_biendong.Dot);
                            _dontu.Ky = int.Parse(_biendong.Ky);
                            _dontu.Nam = _biendong.Nam;
                            _dontu.Quan = _biendong.Quan;
                            _dontu.Phuong = _biendong.Phuong;
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
                _biendong = _cDocSo.get_BienDong_MoiNhat(txtDanhBo.Text.Trim().Replace(" ", ""));
                if (_biendong != null)
                {
                    loadTTKH(_biendong);
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

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png|PDF files (*.pdf) | *.pdf";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    byte[] bytes = _cDonTu.scanVanBan(dialog.FileName);
                    if (_dontu != null)
                    {
                        if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                        {
                            MaHoa_DonTu_Hinh en = new MaHoa_DonTu_Hinh();
                            en.IDParent = _dontu.ID;
                            en.Name = DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss");
                            en.Loai = System.IO.Path.GetExtension(dialog.FileName);
                            if (_wsDHN.ghi_Hinh_MaHoa("DonTu", _dontu.ID.ToString(), en.Name + en.Loai, bytes) == true)
                                if (_cDonTu.Them_Hinh(en) == true)
                                {
                                    _cDonTu.Refresh();
                                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    var index = dgvHinh.Rows.Add();
                                    dgvHinh.Rows[index].Cells["Name_Hinh"].Value = en.Name;
                                    dgvHinh.Rows[index].Cells["Bytes_Hinh"].Value = Convert.ToBase64String(bytes);
                                    dgvHinh.Rows[index].Cells["Loai_Hinh"].Value = System.IO.Path.GetExtension(dialog.FileName);
                                }
                        }
                        else
                            MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvHinh_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            byte[] file = _wsDHN.get_Hinh_MaHoa("DonTu", _dontu.ID.ToString(), dgvHinh.CurrentRow.Cells["Name_Hinh"].Value.ToString() + dgvHinh.CurrentRow.Cells["Loai_Hinh"].Value.ToString());
            if (file != null)
                if (dgvHinh.CurrentRow.Cells["Loai_Hinh"].Value.ToString().Contains("pdf"))
                    _cToTrinh.viewPDF(file);
                else
                    _cToTrinh.viewImage(file);
            else
                MessageBox.Show("Lỗi File", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvHinh_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (_dontu != null)
                    if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                    {
                        if (MessageBox.Show("Bạn có chắc chắn???", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            if (e.Row.Cells["ID_Hinh"].Value != null)
                                if (_wsDHN.xoa_Hinh_MaHoa("DonTu", _dontu.ID.ToString(), e.Row.Cells["Name_Hinh"].Value.ToString() + e.Row.Cells["Loai_Hinh"].Value.ToString()) == true)
                                    if (_cDonTu.Xoa_Hinh(_cDonTu.get_Hinh(int.Parse(e.Row.Cells["ID_Hinh"].Value.ToString()))))
                                    {
                                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        dgvHinh.Rows.RemoveAt(e.Row.Index);
                                    }
                                    else
                                        MessageBox.Show("Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            Clear();
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
                    _cDonTu.viewImage(_cDonTu.imageToByteArray(_cDonTu.byteArrayToImage(_wsDHN.get_Hinh_MaHoa("DonTu", _dontu.ID.ToString(), _dontu.MaHoa_DonTu_Hinhs.SingleOrDefault().Name + _dontu.MaHoa_DonTu_Hinhs.SingleOrDefault().Loai))));
                }
            }
            catch { }
        }

        private void txtSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnXem.PerformClick();
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.Text)
            {
                case "Thời Gian":
                    panel_Time.Visible = true;
                    panel_NoiDung.Visible = false;
                    panel_NamKyDot.Visible = false;
                    break;
                case "Năm Kỳ Đợt":
                    panel_Time.Visible = false;
                    panel_NoiDung.Visible = false;
                    panel_NamKyDot.Visible = true;
                    break;
                default:
                    panel_Time.Visible = false;
                    panel_NoiDung.Visible = true;
                    panel_NamKyDot.Visible = false;
                    break;
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            string str = "";
            switch (cmbTimTheo.Text)
            {
                case "Thời Gian":
                    for (int i = 0; i < chkcmbNoiDung.Properties.Items.Count; i++)
                        if (chkcmbNoiDung.Properties.Items[i].CheckState == CheckState.Checked)
                        {
                            if (str == "")
                                str = chkcmbNoiDung.Properties.Items[i].Value.ToString();
                            else
                                str += ";" + chkcmbNoiDung.Properties.Items[i].Value.ToString();
                        }
                    dgvDanhSach.DataSource = _cDonTu.getDS(cmbTo.SelectedValue.ToString(), str, dateTuNgay.Value, dateDenNgay.Value);
                    break;
                case "Mã Đơn":
                    dgvDanhSach.DataSource = _cDonTu.getDS(int.Parse(txtSo.Text.Trim()));
                    break;
                case "Danh Bộ":
                    dgvDanhSach.DataSource = _cDonTu.getDS_DanhBo(txtSo.Text.Trim());
                    break;
                case "Tồn Theo Thời Gian":
                    str = "";
                    for (int i = 0; i < chkcmbNoiDung.Properties.Items.Count; i++)
                        if (chkcmbNoiDung.Properties.Items[i].CheckState == CheckState.Checked)
                        {
                            if (str == "")
                                str = chkcmbNoiDung.Properties.Items[i].Value.ToString();
                            else
                                str += ";" + chkcmbNoiDung.Properties.Items[i].Value.ToString();
                        }
                    dgvDanhSach.DataSource = _cDonTu.getDS_Ton(cmbTo.SelectedValue.ToString(), str, dateTuNgay.Value, dateDenNgay.Value);
                    break;
                case "Tồn Tất Cả":
                    str = "";
                    for (int i = 0; i < chkcmbNoiDung.Properties.Items.Count; i++)
                        if (chkcmbNoiDung.Properties.Items[i].CheckState == CheckState.Checked)
                        {
                            if (str == "")
                                str = chkcmbNoiDung.Properties.Items[i].Value.ToString();
                            else
                                str += ";" + chkcmbNoiDung.Properties.Items[i].Value.ToString();
                        }
                    dgvDanhSach.DataSource = _cDonTu.getDS_Ton(cmbTo.SelectedValue.ToString(), str);
                    break;
                case "Năm Kỳ Đợt":
                    str = "";
                    for (int i = 0; i < chkcmbNoiDung.Properties.Items.Count; i++)
                        if (chkcmbNoiDung.Properties.Items[i].CheckState == CheckState.Checked)
                        {
                            if (str == "")
                                str = chkcmbNoiDung.Properties.Items[i].Value.ToString();
                            else
                                str += ";" + chkcmbNoiDung.Properties.Items[i].Value.ToString();
                        }
                    dgvDanhSach.DataSource = _cDonTu.getDS_Ton(cmbTo.SelectedValue.ToString(), str, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
                    break;
            }
        }

        private void btnXemTon_Click(object sender, EventArgs e)
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
            dgvDanhSach.DataSource = _cDonTu.getDS_Ton(cmbTo.SelectedValue.ToString(), str);
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
            string error = "";
            try
            {
                dsBaoCao dsBaoCao = new dsBaoCao();
                foreach (DataGridViewRow item in dgvDanhSach.Rows)
                {
                    MaHoa_DonTu dontu = _cDonTu.get(int.Parse(item.Cells["ID"].Value.ToString()));
                    DataRow dr = dsBaoCao.Tables["BaoCao"].NewRow();
                    error = dontu.DanhBo;
                    dr["TenPhong"] = CNguoiDung.TenPhong;
                    dr["DanhBo"] = dontu.DanhBo.Insert(7, " ").Insert(4, " ");
                    dr["HopDong"] = dontu.HopDong;
                    dr["HoTen"] = dontu.HoTen;
                    dr["DiaChi"] = dontu.DiaChi;
                    dr["GiaBieu"] = dontu.GiaBieu;
                    dr["DinhMuc"] = dontu.DinhMuc;
                    DocSo docso = _cDocSo.get_DocSo(dontu.DanhBo, dontu.Nam.Value.ToString(), dontu.Ky.Value.ToString("00"));
                    dr["TBTT"] = docso.TBTT;
                    dr["GhiChu"] = dontu.GhiChu;
                    dr["ChucVu"] = CNguoiDung.ChucVu.ToUpper();
                    dr["NguoiKy"] = CNguoiDung.NguoiKy.ToUpper();
                    dr["ChucVuDuyet"] = "DUYỆT\n" + _cThuongVu.getChucVu_Duyet().ToUpper();
                    dr["NguoiKyDuyet"] = _cThuongVu.getNguoiKy_Duyet().ToUpper();
                    dsBaoCao.Tables["BaoCao"].Rows.Add(dr);
                }
                rptDSDonTu rpt = new rptDSDonTu();
                rpt.SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(error + "\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInDSTon_Click(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                dsBaoCao dsBaoCao = new dsBaoCao();
                foreach (DataGridViewRow item in dgvDanhSach.Rows)
                    if (item.Cells["TinhTrang"].Value.ToString().Contains("Tồn"))
                    {
                        MaHoa_DonTu dontu = _cDonTu.get(int.Parse(item.Cells["ID"].Value.ToString()));
                        if (dontu != null)
                        {
                            DataRow dr = dsBaoCao.Tables["BaoCao"].NewRow();
                            dr["TenPhong"] = CNguoiDung.TenPhong;
                            dr["TieuDe"] = "DANH SÁCH ĐƠN TỒN";
                            dr["ThoiGian"] = "Từ ngày " + dateTuNgay.Value.ToString("dd/MM/yyyy") + " đến ngày " + dateDenNgay.Value.ToString("dd/MM/yyyy");
                            dr["DanhBo"] = dontu.DanhBo.Insert(7, " ").Insert(4, " ");
                            dr["MLT"] = dontu.MLT;
                            dr["HoTen"] = dontu.HoTen;
                            dr["DiaChi"] = dontu.DiaChi;
                            dr["MaDon"] = dontu.ID;
                            dr["TinhTrang"] = dontu.TinhTrang;
                            dr["ChucVu"] = CNguoiDung.ChucVu.ToUpper();
                            dr["NguoiKy"] = CNguoiDung.NguoiKy.ToUpper();
                            dsBaoCao.Tables["BaoCao"].Rows.Add(dr);
                        }
                    }
                rptDanhSach rpt = new rptDanhSach();
                rpt.SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(error + "\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = _cDonTu.getDS(dateTu_DSChuyenKTXM.Value, dateDen_DSChuyenKTXM.Value);
                dsBaoCao dsBaoCaoTo = new dsBaoCao();
                foreach (DataRow item in dt.Rows)
                {
                    DataRow dr = dsBaoCaoTo.Tables["BaoCao"].NewRow();
                    dr["ThoiGian"] = "Từ ngày " + dateTu_DSChuyenKTXM.Value.ToString("dd/MM/yyyy") + " đến ngày " + dateDen_DSChuyenKTXM.Value.ToString("dd/MM/yyyy");
                    dr["TenPhong"] = CNguoiDung.TenPhong.ToUpper();
                    dr["MaDon"] = item["ID"].ToString();
                    dr["TinhTrang"] = item["TinhTrang"].ToString();
                    dr["NoiDung"] = item["NoiDung"].ToString();
                    dsBaoCaoTo.Tables["BaoCao"].Rows.Add(dr);
                }
                dt = _cDonTu.getDS_ChuyenKTXM(dateTu_DSChuyenKTXM.Value, dateDen_DSChuyenKTXM.Value);
                dsBaoCao dsBaoCaoNV = new dsBaoCao();
                foreach (DataRow item in dt.Rows)
                {
                    DataRow dr = dsBaoCaoNV.Tables["BaoCao"].NewRow();
                    dr["NguoiKTXM"] = item["NguoiKTXM"].ToString();
                    dr["MaDon"] = item["MaDon"].ToString();
                    if (bool.Parse(item["KTXM"].ToString()))
                        dr["TinhTrang"] = "Hoàn Thành";
                    else
                        dr["TinhTrang"] = "Tồn";
                    dr["NoiDung"] = item["NoiDung"].ToString();
                    dsBaoCaoNV.Tables["BaoCao"].Rows.Add(dr);
                }
                dt = _cToTrinh.getDS(dateTu_DSChuyenKTXM.Value, dateDen_DSChuyenKTXM.Value);
                dsBaoCao dsBaoCaoTT = new dsBaoCao();
                foreach (DataRow item in dt.Rows)
                {
                    DataRow dr = dsBaoCaoTT.Tables["BaoCao"].NewRow();
                    dr["MaDon"] = item["ID"].ToString();
                    dr["NoiDung"] = item["VeViec"].ToString();
                    dsBaoCaoTT.Tables["BaoCao"].Rows.Add(dr);
                }
                dt = _cDCBD.getDS(dateTu_DSChuyenKTXM.Value, dateDen_DSChuyenKTXM.Value);
                foreach (DataRow item in dt.Rows)
                {
                    DataRow dr = dsBaoCaoTT.Tables["BaoCao"].NewRow();
                    dr["MaDon"] = item["ID"].ToString();
                    dr["NoiDung"] = "Điều chỉnh " + item["ThongTin"].ToString();
                    dsBaoCaoTT.Tables["BaoCao"].Rows.Add(dr);
                }
                rptBaoCao rpt = new rptBaoCao();
                rpt.SetDataSource(dsBaoCaoTo);
                rpt.Subreports["To"].SetDataSource(dsBaoCaoTo);
                rpt.Subreports["NhanVien"].SetDataSource(dsBaoCaoNV);
                rpt.Subreports["DCBD"].SetDataSource(dsBaoCaoTT);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIn_CV_Click(object sender, EventArgs e)
        {
            dsBaoCao dsBaoCao = new dsBaoCao();
            DataTable dt = _cDonTu.getDS_ChuyenPhongDoi(dateTu_CV.Value, dateDen_CV.Value);
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["BaoCao"].NewRow();
                dr["ThoiGian"] = "Từ ngày " + dateTu_CV.Value.ToString("dd/MM/yyyy") + " đến ngày " + dateDen_CV.Value.ToString("dd/MM/yyyy");
                dr["TenPhong"] = CNguoiDung.TenPhong.ToUpper();
                dr["MaDon"] = item["MaDon"].ToString();
                dr["NgayChuyen"] = item["NgayChuyen"].ToString();
                if (item["DanhBo"].ToString().Length == 11)
                    dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                dr["DiaChi"] = item["DiaChi"].ToString();
                dr["NoiNhan"] = item["NoiNhan"].ToString();
                dr["NoiDung"] = item["NoiDung"].ToString();
                dsBaoCao.Tables["BaoCao"].Rows.Add(dr);
            }
            rptDSCongVan rpt = new rptDSCongVan();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }




    }
}
