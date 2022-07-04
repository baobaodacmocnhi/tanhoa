using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.LinQ;
using DocSo_PC.DAL.QuanTri;
using DocSo_PC.DAL;
using DocSo_PC.DAL.MaHoa;
using DocSo_PC.BaoCao;
using DocSo_PC.BaoCao.MaHoa;
using DocSo_PC.GUI.BaoCao;
using DocSo_PC.DAL.Doi;

namespace DocSo_PC.GUI.MaHoa
{
    public partial class frmToTrinh : Form
    {
        string _mnu = "mnuToTrinh";
        CDHN _cDHN = new CDHN();
        CToTrinh _cToTrinh = new CToTrinh();
        CThuTien _cThuTien = new CThuTien();
        CDonTu _cDonTu = new CDonTu();
        CDocSo _cDocSo = new CDocSo();
        CThuongVu _cThuongVu = new CThuongVu();
        wrDHN.wsDHN _wsDHN = new wrDHN.wsDHN();

        MaHoa_DonTu _dontu = null;
        BienDong _biendong = null;
        MaHoa_ToTrinh _totrinh = null;
        MaHoa_ToTrinh_VeViec _veviec = null;

        public frmToTrinh()
        {
            InitializeComponent();
        }

        private void frmToTrinh_Load(object sender, EventArgs e)
        {
            dgvToTrinh.AutoGenerateColumns = false;
            dgvVeViec.AutoGenerateColumns = false;
            List<MaHoa_ToTrinh_VeViec> lst = _cToTrinh.getDS_VeViec();
            cmbVeViec.DataSource = lst;
            cmbVeViec.DisplayMember = "Name";
            cmbVeViec.SelectedIndex = -1;
            dgvVeViec.DataSource = lst;
        }

        public void loadTTKH(BienDong hoadon)
        {
            txtDanhBo.Text = hoadon.DanhBa;
            txtHoTen.Text = hoadon.TenKH;
            txtDiaChi.Text = hoadon.So + " " + hoadon.Duong + _cDHN.getPhuongQuan(hoadon.Quan, hoadon.Phuong);
            txtGiaBieu.Text = hoadon.GB.ToString();
            if (hoadon.DM != null)
                txtDinhMuc.Text = hoadon.DM.Value.ToString();
            else
                txtDinhMuc.Text = "";
            if (hoadon.DMHN != null)
                txtDinhMucHN.Text = hoadon.DMHN.Value.ToString();
            else
                txtDinhMucHN.Text = "";
        }

        public void LoadTT(MaHoa_ToTrinh en)
        {
            _dontu = _cDonTu.get(en.IDMaDon);
            txtMaDon.Text = en.IDMaDon.ToString();
            txtDanhBo.Text = en.DanhBo;
            txtHoTen.Text = en.HoTen;
            txtDiaChi.Text = en.DiaChi;
            if (en.GiaBieu != null)
                txtGiaBieu.Text = en.GiaBieu.Value.ToString();
            if (en.DinhMuc != null)
                txtDinhMuc.Text = en.DinhMuc.Value.ToString();
            if (en.DinhMucHN != null)
                txtDinhMucHN.Text = en.DinhMucHN.Value.ToString();
            txtID.Text = en.ID.ToString();
            txtVeViec.Text = en.VeViec;
            txtKinhTrinh.Text = en.KinhTrinh;
            txtNoiDung.Text = en.NoiDung;
            txtNoiNhan.Text = en.NoiNhan;
            dgvHinh.Rows.Clear();
            foreach (MaHoa_ToTrinh_Hinh item in en.MaHoa_ToTrinh_Hinhs.ToList())
            {
                var index = dgvHinh.Rows.Add();
                dgvHinh.Rows[index].Cells["ID_Hinh"].Value = item.ID;
                dgvHinh.Rows[index].Cells["Name_Hinh"].Value = item.Name;
                dgvHinh.Rows[index].Cells["Loai_Hinh"].Value = item.Loai;
            }

        }

        public void Clear()
        {
            txtMaDon.Text = "";
            txtID.Text = "";
            txtDanhBo.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            txtDinhMucHN.Text = "";
            ///
            txtVeViec.Text = "";
            txtKinhTrinh.Text = "Ông Phó Giám đốc";
            txtNoiDung.Text = "";
            txtNoiNhan.Text = "";
            ///
            _dontu = null;
            _biendong = null;
            _totrinh = null;
            _veviec = null;

            dgvHinh.Rows.Clear();
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (txtMaDon.Text.Trim() != "" && e.KeyChar == 13)
                {
                    string MaDon = txtMaDon.Text.Trim();
                    Clear();
                    txtMaDon.Text = MaDon;
                    _dontu = _cDonTu.get(int.Parse(MaDon));
                    if (_dontu != null)
                    {
                        _biendong = _cDocSo.get_BienDong_MoiNhat(_dontu.DanhBo);
                        if (_biendong != null)
                        {
                            loadTTKH(_biendong);
                        }
                        else
                            MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (txtDanhBo.Text.Trim() != "" && e.KeyChar == 13)
                {
                    _biendong = _cDocSo.get_BienDong_MoiNhat(txtDanhBo.Text.Trim());
                    if (_biendong != null)
                    {
                        loadTTKH(_biendong);
                    }
                    else
                        MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (txtID.Text.Trim() != "" && e.KeyChar == 13)
                {
                    string MaDon = txtID.Text.Trim();
                    Clear();
                    txtID.Text = MaDon;
                    _totrinh = _cToTrinh.get(int.Parse(MaDon));
                    if (_totrinh != null)
                    {
                        LoadTT(_totrinh);
                    }
                    else
                        MessageBox.Show("Mã này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                    MaHoa_ToTrinh cttt = new MaHoa_ToTrinh();
                    if (_dontu != null)
                    {
                        if (_cToTrinh.checkExist(_dontu.ID, txtDanhBo.Text.Trim(), DateTime.Now) == true)
                        {
                            MessageBox.Show("Danh Bộ này đã được Lập Tờ Trình", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    cttt.IDMaDon = _dontu.ID;
                    cttt.DanhBo = txtDanhBo.Text.Trim();
                    cttt.HoTen = txtHoTen.Text.Trim();
                    cttt.DiaChi = txtDiaChi.Text.Trim();
                    if (string.IsNullOrEmpty(txtGiaBieu.Text.Trim()) == false)
                        cttt.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                    if (string.IsNullOrEmpty(txtDinhMuc.Text.Trim()) == false)
                        cttt.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                    if (string.IsNullOrEmpty(txtDinhMucHN.Text.Trim()) == false)
                        cttt.DinhMucHN = int.Parse(txtDinhMucHN.Text.Trim());
                    if (_biendong != null)
                    {
                        cttt.Dot = int.Parse(_biendong.Dot);
                        cttt.Ky = int.Parse(_biendong.Ky);
                        cttt.Nam = _biendong.Nam;
                        cttt.Phuong = _biendong.Phuong;
                        cttt.Quan = _biendong.Quan;
                        cttt.Hieu = _biendong.Hieu;
                        cttt.Co = _biendong.Co.Value.ToString();
                        cttt.SoThan = _biendong.SoThan;
                        cttt.MLT = _biendong.MLT1;
                    }
                    cttt.VeViec = txtVeViec.Text.Trim();
                    cttt.KinhTrinh = txtKinhTrinh.Text.Trim();
                    cttt.NoiDung = txtNoiDung.Text;
                    cttt.NoiNhan = txtNoiNhan.Text.Trim();
                    cttt.ThuDuocKy = true;
                    if (_cToTrinh.Them(cttt))
                    {
                        if (_dontu != null)
                        {
                            _cDonTu.Them_LichSu(cttt.CreateDate.Value, "ToTrinh", "Đã Lập Tờ Trình, " + cttt.VeViec, cttt.ID, _dontu.ID);
                        }
                        string noidung = "Số: " + cttt.ID + "/TTr-QLĐHN, " + cttt.CreateDate.Value.ToString("dd/MM/yyyy") + " - V/v: " + cttt.VeViec;
                        string sql = "insert into TB_GHICHU(DANHBO,DONVI,NOIDUNG,CREATEDATE,CREATEBY)values('" + cttt.DanhBo + "',N'QLDHN',N'" + noidung + "','" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture) + "',N'" + CNguoiDung.HoTen + "')";
                        CDHN._cDAL.ExecuteNonQuery(sql);
                        MessageBox.Show("Thành Công " + cttt.ID.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
                {
                    if (_totrinh != null && MessageBox.Show("Bạn chắc chắn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (_cToTrinh.Xoa(_totrinh) == true)
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
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
                    if (_totrinh != null)
                    {
                        _totrinh.DanhBo = txtDanhBo.Text.Trim();
                        _totrinh.HoTen = txtHoTen.Text.Trim();
                        _totrinh.DiaChi = txtDiaChi.Text.Trim();
                        if (string.IsNullOrEmpty(txtGiaBieu.Text.Trim()) == false)
                            _totrinh.GiaBieu = int.Parse(txtGiaBieu.Text.Trim());
                        if (string.IsNullOrEmpty(txtDinhMuc.Text.Trim()) == false)
                            _totrinh.DinhMuc = int.Parse(txtDinhMuc.Text.Trim());
                        if (string.IsNullOrEmpty(txtDinhMucHN.Text.Trim()) == false)
                            _totrinh.DinhMucHN = int.Parse(txtDinhMucHN.Text.Trim());
                        if (_biendong != null)
                        {
                            _totrinh.Dot = int.Parse(_biendong.Dot);
                            _totrinh.Ky = int.Parse(_biendong.Ky);
                            _totrinh.Nam = _biendong.Nam;
                            _totrinh.Phuong = _biendong.Phuong;
                            _totrinh.Quan = _biendong.Quan;
                            _totrinh.Hieu = _biendong.Hieu;
                            _totrinh.Co = _biendong.Co.Value.ToString();
                            _totrinh.SoThan = _biendong.SoThan;
                            _totrinh.MLT = _biendong.MLT1;
                        }
                        _totrinh.VeViec = txtVeViec.Text.Trim();
                        _totrinh.KinhTrinh = txtKinhTrinh.Text.Trim();
                        _totrinh.NoiDung = txtNoiDung.Text;
                        _totrinh.NoiNhan = txtNoiNhan.Text.Trim();
                        _totrinh.ThuDuocKy = true;
                        if (_cToTrinh.Sua(_totrinh))
                        {
                            MessageBox.Show("Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    byte[] bytes = _cToTrinh.scanVanBan(dialog.FileName);
                    if (_totrinh != null)
                    {
                        if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                        {
                            MaHoa_ToTrinh_Hinh en = new MaHoa_ToTrinh_Hinh();
                            en.IDParent = _totrinh.ID;
                            en.Name = DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss");
                            en.Loai = System.IO.Path.GetExtension(dialog.FileName);
                            if (_wsDHN.ghi_Hinh_MaHoa("ToTrinh", _totrinh.ID.ToString(), en.Name + en.Loai, bytes) == true)
                                if (_cToTrinh.Them_Hinh(en) == true)
                                {
                                    _cToTrinh.Refresh();
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
            byte[] hinh = _wsDHN.get_Hinh_MaHoa("ToTrinh", _totrinh.ID.ToString(), dgvHinh.CurrentRow.Cells["Name_Hinh"].Value.ToString() + dgvHinh.CurrentRow.Cells["Loai_Hinh"].Value.ToString());
            if (hinh != null)
                _cToTrinh.LoadImageView(hinh);
            else
                MessageBox.Show("Lỗi File", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvHinh_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (_totrinh != null)
                    if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                    {
                        if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            if (e.Row.Cells["ID_Hinh"].Value != null)
                                if (_wsDHN.xoa_Hinh_MaHoa("ToTrinh", _totrinh.ID.ToString(), e.Row.Cells["Name_Hinh"].Value.ToString() + e.Row.Cells["Loai_Hinh"].Value.ToString()) == true)
                                    if (_cToTrinh.Xoa_Hinh(_cToTrinh.get_Hinh(int.Parse(e.Row.Cells["ID_Hinh"].Value.ToString()))))
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

        #region Danh Sách

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.Text)
            {
                case "Thời Gian":
                    panel_Time.Visible = true;
                    panel_NoiDung.Visible = false;
                    break;
                default:
                    panel_Time.Visible = false;
                    panel_NoiDung.Visible = true;
                    break;
            }
        }

        private void btnXem_DS_Click(object sender, EventArgs e)
        {
            switch (cmbTimTheo.Text)
            {
                case "Thời Gian":
                    dgvToTrinh.DataSource = _cToTrinh.getDS(dateTu_DS.Value, dateDen_DS.Value);
                    break;
                case "Mã Đơn":
                    if (txtDenSo.Text.Trim() != "")
                        dgvToTrinh.DataSource = _cToTrinh.getDS_MaDon(int.Parse(txtTuSo.Text.Trim()), int.Parse(txtDenSo.Text.Trim()));
                    else
                        dgvToTrinh.DataSource = _cToTrinh.getDS_MaDon(int.Parse(txtTuSo.Text.Trim()));
                    break;
                case "Số Phiếu":
                    if (txtDenSo.Text.Trim() != "")
                        dgvToTrinh.DataSource = _cToTrinh.getDS_SoPhieu(int.Parse(txtTuSo.Text.Trim()), int.Parse(txtDenSo.Text.Trim()));
                    else
                        dgvToTrinh.DataSource = _cToTrinh.getDS_SoPhieu(int.Parse(txtTuSo.Text.Trim()));
                    break;
                case "Danh Bộ":
                    dgvToTrinh.DataSource = _cToTrinh.getDS_DanhBo(txtTuSo.Text.Trim());
                    break;
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                dsBaoCao dsBaoCao = new dsBaoCao();
                foreach (DataGridViewRow item in dgvToTrinh.Rows)
                    if (item.Cells["Chon_DS"].Value != null && bool.Parse(item.Cells["Chon_DS"].Value.ToString()) == true)
                    {
                        MaHoa_ToTrinh en = _cToTrinh.get(int.Parse(item.Cells["ID_DS"].Value.ToString()));
                        if (en != null)
                        {
                            DataRow dr = dsBaoCao.Tables["BaoCao"].NewRow();

                            dr["TenPhong"] = CNguoiDung.TenPhong;
                            dr["VeViec"] = en.VeViec;
                            dr["KinhTrinh"] = en.KinhTrinh;
                            dr["MaDon"] = en.ID.ToString();
                            dr["DanhBo"] = en.DanhBo.Insert(7, " ").Insert(4, " ");
                            dr["HoTen"] = en.HoTen;
                            dr["DiaChi"] = en.DiaChi;
                            dr["MLT"] = en.MLT;
                            dr["GiaBieu"] = en.GiaBieu;
                            dr["DinhMuc"] = en.DinhMuc;
                            dr["DinhMucHN"] = en.DinhMucHN;
                            dr["NoiDung"] = en.NoiDung;
                            dr["NoiNhan"] = en.NoiNhan;
                            dr["ChucVu"] = CNguoiDung.ChucVu.ToUpper();
                            dr["NguoiKy"] = CNguoiDung.NguoiKy.ToUpper();
                            dr["ChucVuDuyet"] = "DUYỆT\n" + _cThuongVu.getChucVu_Duyet().ToUpper();
                            dr["NguoiKyDuyet"] = _cThuongVu.getNguoiKy_Duyet().ToUpper();
                            dsBaoCao.Tables["BaoCao"].Rows.Add(dr);
                        }
                    }
                rptToTrinh_ThongQuaPGD_2022 rpt = new rptToTrinh_ThongQuaPGD_2022();
                rpt.SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvToTrinh_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvToTrinh.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void cmbVeViec_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVeViec.SelectedIndex != -1)
            {
                MaHoa_ToTrinh_VeViec vv = (MaHoa_ToTrinh_VeViec)cmbVeViec.SelectedItem;
                txtVeViec.Text = vv.Name;
                txtNoiDung.Text = vv.NoiDung;
                if (txtMaDon.Text.Trim() != "")
                    txtNoiNhan.Text = vv.NoiNhan + " (" + txtMaDon.Text.Trim() + ")";
            }
            else
            {
                txtVeViec.Text = "";
                txtNoiDung.Text = "";
                txtNoiNhan.Text = "";
            }
        }

        private void txtTuSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnXem_DS.PerformClick();
        }

        private void txtDenSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnXem_DS.PerformClick();
        }

        private void dgvToTrinh_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (dgvToTrinh.Columns[e.ColumnIndex].Name == "ThuDuocKy_DS")
                    {
                        MaHoa_ToTrinh totrinh = _cToTrinh.get(int.Parse(dgvToTrinh["ID_DS", e.RowIndex].Value.ToString()));
                        totrinh.ThuDuocKy = bool.Parse(dgvToTrinh["ThuDuocKy_DS", e.RowIndex].Value.ToString());
                        _cToTrinh.Sua(totrinh);
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

        #endregion

        #region Về Việc

        private void btnThem_VV_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                if (txtVeViec_VV.Text.Trim() != "" && txtNoiDung_VV.Text.Trim() != "" && txtNoiNhan_VV.Text.Trim() != "")
                {
                    MaHoa_ToTrinh_VeViec vv = new MaHoa_ToTrinh_VeViec();
                    vv.Name = txtVeViec_VV.Text.Trim();
                    vv.NoiDung = txtNoiDung_VV.Text;
                    vv.NoiNhan = txtNoiNhan_VV.Text.Trim();
                    if (_cToTrinh.Them(vv))
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                    }
                }
                else
                    MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_VV_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (_veviec != null && MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (_cToTrinh.Xoa(_veviec))
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_VV_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {
                if (_veviec != null)
                    if (txtVeViec_VV.Text.Trim() != "" && txtNoiDung_VV.Text.Trim() != "" && txtNoiNhan_VV.Text.Trim() != "")
                    {
                        _veviec.Name = txtVeViec_VV.Text.Trim();
                        _veviec.NoiDung = txtNoiDung_VV.Text;
                        _veviec.NoiNhan = txtNoiNhan_VV.Text.Trim();
                        if (_cToTrinh.Sua(_veviec))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                    }
                    else
                        MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvVeViec_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvVeViec.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvVeViec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _veviec = _cToTrinh.get_VeViec(int.Parse(dgvVeViec.CurrentRow.Cells["ID"].Value.ToString()));
                txtVeViec_VV.Text = _veviec.Name;
                txtNoiDung_VV.Text = _veviec.NoiDung;
                txtNoiNhan_VV.Text = _veviec.NoiNhan;
            }
            catch
            {

            }
        }

        #endregion















    }
}
