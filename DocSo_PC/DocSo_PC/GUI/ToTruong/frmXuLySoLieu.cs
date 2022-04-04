using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.Doi;
using DocSo_PC.DAL.QuanTri;
using DocSo_PC.LinQ;
using DocSo_PC.DAL;
using DocSo_PC.wrDHN;
using DocSo_PC.DAL.MaHoa;

namespace DocSo_PC.GUI.ToTruong
{
    public partial class frmXuLySoLieu : Form
    {
        string _mnu = "mnuXuLySoLieu";
        CDocSo _cDocSo = new CDocSo();
        CDocSo12 _cDocSo12 = new CDocSo12();
        CTo _cTo = new CTo();
        CMayDS _cMayDS = new CMayDS();
        CDHN _cDHN = new CDHN();
        DocSo _docso = null;
        wsDHN wsDHN = new wsDHN();
        CDonTu _cDonTu = new CDonTu();
        CThuTien _cThuTien = new CThuTien();
        bool _flagLoadFirst = false;

        public frmXuLySoLieu()
        {
            InitializeComponent();
        }

        private void frmXuLySoLieu_Load(object sender, EventArgs e)
        {
            try
            {
                dgvDanhSach.AutoGenerateColumns = false;
                dgvThongBao.AutoGenerateColumns = false;
                dgvBaoThay.AutoGenerateColumns = false;
                dgvLichSu.AutoGenerateColumns = false;

                cmbNam.DataSource = _cDocSo.getDS_Nam();
                cmbNam.DisplayMember = "Nam";
                cmbNam.ValueMember = "Nam";
                cmbKy.SelectedItem = CNguoiDung.Ky;
                cmbDot.SelectedItem = CNguoiDung.Dot;

                DataTable dtCode = _cDocSo.getDS_Code();
                cmbCodeMoi.DataSource = dtCode;
                cmbCodeMoi.DisplayMember = "Code";
                cmbCodeMoi.ValueMember = "Code";
                if (CNguoiDung.Doi)
                {
                    cmbTo.Visible = true;
                    List<To> lst = _cTo.getDS_HanhThu();
                    To en = new To();
                    en.MaTo = 0;
                    en.TenTo = "Tất Cả";
                    lst.Insert(0, en);
                    cmbTo.DataSource = lst;
                    cmbTo.DisplayMember = "TenTo";
                    cmbTo.ValueMember = "MaTo";
                    loadMay(cmbTo.SelectedValue.ToString());

                }
                else
                {
                    lbTo.Text = "Tổ  " + CNguoiDung.TenTo;
                    loadMay(CNguoiDung.MaTo.ToString());
                }
                _flagLoadFirst = true;
                loadCodeMoi();
                if (CNguoiDung.Admin)
                    btnReset.Visible = true;
                btnChuyenDonToMaHoa.Text = "Chuyển Đơn" + Environment.NewLine + "Tổ Mã Hóa";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadMay(string MaTo)
        {
            try
            {
                DataTable dtMay = new DataTable();
                if (MaTo == "0")
                    for (int i = 1; i < cmbTo.Items.Count; i++)
                    {
                        dtMay.Merge(_cMayDS.getDS(((To)cmbTo.Items[i]).MaTo.ToString()));
                    }
                else
                    dtMay = _cMayDS.getDS(MaTo);
                DataRow dr = dtMay.NewRow();
                dr["May"] = "Tất Cả";
                dtMay.Rows.InsertAt(dr, 0);
                cmbMay.DataSource = dtMay;
                cmbMay.DisplayMember = "May";
                cmbMay.ValueMember = "May";
                cmbMay.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadThongTin()
        {
            try
            {
                if (_docso != null)
                {
                    TB_DULIEUKHACHHANG dhn = _cDHN.get(_docso.DanhBa);
                    if (dhn != null)
                    {
                        txtCSC.Text = _docso.CSCu.Value.ToString();
                        if (_docso.CodeMoi != null && _docso.CodeMoi.ToString() != "")
                            cmbCodeMoi.SelectedValue = _docso.CodeMoi;
                        if (_docso.CSMoi != null)
                            txtCSM.Text = _docso.CSMoi.Value.ToString();
                        if (_docso.TieuThuMoi != null)
                            txtTieuThu.Text = _docso.TieuThuMoi.Value.ToString();
                        txtHoTen.Text = dhn.HOTEN;
                        txtDanhBo.Text = dhn.DANHBO.Insert(7, " ").Insert(4, " ");
                        txtHieu.Text = dhn.HIEUDH;
                        txtCo.Text = dhn.CODH;
                        txtSoThan.Text = dhn.SOTHANDH;
                        txtViTri.Text = dhn.VITRIDHN;
                        txtHopDong.Text = dhn.HOPDONG;
                        txtDiaChi.Text = dhn.SONHA + " " + dhn.TENDUONG;
                        txtMLT.Text = dhn.LOTRINH.Insert(4, " ").Insert(2, " ");
                        txtGiaBieu.Text = dhn.GIABIEU;
                        txtDinhMuc.Text = dhn.DINHMUC;
                        if (_docso.GIOGHI != null)
                            txtNgayGhiCS.Text = _docso.GIOGHI.Value.ToString();
                        if (_docso.NVCapNhat != null)
                            txtNguoiCapNhat.Text = _docso.NVCapNhat;
                        if (_docso.NgayCapNhat != null)
                            txtNgayCapNhat.Text = _docso.NgayCapNhat.Value.ToString();
                        tbxGCDS.Text = _docso.GhiChuDS;
                        tbxGCKH.Text = _docso.GhiChuKH;
                        tbxGCTV.Text = _docso.GhiChuTV;
                        dgvThongBao.DataSource = _cDocSo.getThongBao(_docso.DanhBa);
                        dgvBaoThay.DataSource = _cDocSo.getBaoThay(_docso.DanhBa);
                        dgvLichSu.DataSource = _cDocSo.getLichSu(_docso.DanhBa, _docso.Nam.Value.ToString(), _docso.Ky);
                        foreach (DataGridViewColumn item in dgvLichSu.Columns)
                        {
                            if (item.Name.Contains("Ky") == true && dgvLichSu[item.Index, dgvLichSu.Rows.Count - 1].Value.ToString() != "")
                                dgvLichSu[item.Index, dgvLichSu.Rows.Count - 3].Style.BackColor = Color.Orange;
                        }
                        dgvLichSu.Rows.RemoveAt(dgvLichSu.Rows.Count - 1);
                        if (chkLoadHinh.Checked == true)
                            btnXemHinh.PerformClick();
                        //cmbCodeMoi.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_flagLoadFirst == true && cmbTo.SelectedIndex > -1)
                loadMay(cmbTo.SelectedValue.ToString());
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dtTong = new DataTable();

            if (cmbMay.SelectedValue != null && cmbCode.SelectedValue != null)
            {
                if (CNguoiDung.Doi == true)
                {
                    CNguoiDung.Ky = cmbKy.SelectedItem.ToString();
                    CNguoiDung.Dot = cmbDot.SelectedItem.ToString();
                    if (txtDanhBoTK.Text.Trim().Replace(" ", "").Replace("-", "") != "")
                    {
                        dt = _cDocSo.getDS_XuLy_DanhBo(cmbNam.SelectedValue.ToString(), cmbKy.SelectedItem.ToString(), txtDanhBoTK.Text.Trim().Replace(" ", "").Replace("-", ""));
                    }
                    else
                    {
                        dt = _cDocSo.getDS_XuLy(cmbTo.SelectedValue.ToString(), cmbNam.SelectedValue.ToString(), cmbKy.SelectedItem.ToString(), cmbDot.SelectedItem.ToString(), cmbMay.SelectedValue.ToString(), cmbCode.SelectedValue.ToString(), ref dtTong);
                    }
                }
                else
                {
                    CNguoiDung.Ky = cmbKy.SelectedItem.ToString();
                    CNguoiDung.Dot = cmbDot.SelectedItem.ToString();
                    if (txtDanhBoTK.Text.Trim().Replace(" ", "").Replace("-", "") != "")
                    {
                        dt = _cDocSo.getDS_XuLy_DanhBo(CNguoiDung.MaTo.ToString(), cmbNam.SelectedValue.ToString(), cmbKy.SelectedItem.ToString(), txtDanhBoTK.Text.Trim().Replace(" ", "").Replace("-", ""));
                    }
                    else
                    {
                        dt = _cDocSo.getDS_XuLy(CNguoiDung.MaTo.ToString(), cmbNam.SelectedValue.ToString(), cmbKy.SelectedItem.ToString(), cmbDot.SelectedItem.ToString(), cmbMay.SelectedValue.ToString(), cmbCode.SelectedValue.ToString(), ref dtTong);
                    }
                }
            }
            dgvDanhSach.DataSource = dt;
            loaddgvDanhSach();
            if (dtTong != null && dtTong.Rows.Count > 0)
            {
                lbTongSL.Text = dtTong.Rows[0]["TongSL"].ToString();
                lbSLDaGhi.Text = dtTong.Rows[0]["SLDaGhi"].ToString();
                lbSLChuaGhi.Text = dtTong.Rows[0]["SLChuaGhi"].ToString();
                lbSanLuong.Text = dtTong.Rows[0]["SanLuong"].ToString();
                lbSLHD0.Text = dtTong.Rows[0]["SLHD0"].ToString();
            }
        }

        public void loaddgvDanhSach()
        {
            foreach (DataGridViewRow item in dgvDanhSach.Rows)
            {
                //tiêu thu tăng cao, tiêu thụ âm
                if (item.Cells["TieuThuMoi"].Value != null && item.Cells["TieuThuMoi"].Value.ToString() != ""
                    && (int.Parse(item.Cells["TieuThuMoi"].Value.ToString()) < int.Parse(item.Cells["TBTT"].Value.ToString()) - int.Parse(item.Cells["TBTT"].Value.ToString()) * 1.4
                    || int.Parse(item.Cells["TieuThuMoi"].Value.ToString()) >= int.Parse(item.Cells["TBTT"].Value.ToString()) * 1.4
                    || int.Parse(item.Cells["TieuThuMoi"].Value.ToString()) < 0))
                    item.DefaultCellStyle.BackColor = Color.Red;
                //có BBKT, tờ trình, code 8 không có hoàn công thay (bồi thường, tái lập,...)
                if (bool.Parse(item.Cells["BaoThayBT"].Value.ToString()) == true)
                    item.DefaultCellStyle.BackColor = Color.Orange;
                //code 4 có hoàn công thay (báo thay), sai code
                if (item.Cells["CodeMoi"].Value != null && item.Cells["CodeMoi"].Value.ToString() != "" && bool.Parse(item.Cells["BaoThayDK"].Value.ToString()) == true
                    && ((item.Cells["CodeCu"].Value.ToString().Contains("4") && item.Cells["CodeMoi"].Value.ToString().Contains("5"))
                    || (item.Cells["CodeCu"].Value.ToString().Contains("4") && item.Cells["CodeMoi"].Value.ToString().Contains("8"))))
                    item.DefaultCellStyle.BackColor = Color.Yellow;
                if (bool.Parse(item.Cells["ChuBao"].Value.ToString()) == true)
                    item.DefaultCellStyle.BackColor = Color.Green;
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBoTK.Text.Trim().Replace(" ", "").Replace("-", "") != "")
                btnXem.PerformClick();
        }

        private void dgvDanhSach_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDanhSach.Columns[e.ColumnIndex].Name == "MLT" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(2, " ");
            }
            //if (dgvDanhSach.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            //{
            //    e.Value = e.Value.ToString().Insert(7, " ").Insert(4, " ");
            //}
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
                _docso = _cDocSo.get_DocSo(dgvDanhSach.CurrentRow.Cells["DocSoID"].Value.ToString());
                loadThongTin();
            }
            catch
            {
            }
        }

        private void btnXemHinh_Click(object sender, EventArgs e)
        {
            try
            {
                if (_docso != null)
                {
                    lblKy0.Text = (int.Parse(_docso.Ky)).ToString("00") + "/" + (_docso.Nam);
                    byte[] img = wsDHN.get_Hinh((_docso.Nam) + (int.Parse(_docso.Ky)).ToString("00") + _docso.DanhBa);
                    if (img != null)
                        ptbKy0.Image = _cDocSo.byteArrayToImage(img);
                    else
                        ptbKy0.Image = Properties.Resources.no_image;
                    if (_docso.Ky == "01")
                    {
                        lblKy1.Text = "12" + "/" + (_docso.Nam - 1);
                        lblKy2.Text = "11" + "/" + (_docso.Nam - 1);
                        lblKy3.Text = "10" + "/" + (_docso.Nam - 1);
                        img = wsDHN.get_Hinh((_docso.Nam - 1) + "12" + _docso.DanhBa);
                        if (img != null)
                            ptbKy1.Image = _cDocSo.byteArrayToImage(img);
                        else
                            ptbKy1.Image = Properties.Resources.no_image;
                        img = wsDHN.get_Hinh((_docso.Nam - 1) + "11" + _docso.DanhBa);
                        if (img != null)
                            ptbKy2.Image = _cDocSo.byteArrayToImage(img);
                        else
                            ptbKy2.Image = Properties.Resources.no_image;
                        img = wsDHN.get_Hinh((_docso.Nam - 1) + "10" + _docso.DanhBa);
                        if (img != null)
                            ptbKy3.Image = _cDocSo.byteArrayToImage(img);
                        else
                            ptbKy3.Image = Properties.Resources.no_image;
                    }
                    else
                        if (_docso.Ky == "02")
                        {
                            lblKy1.Text = "01" + "/" + (_docso.Nam);
                            lblKy2.Text = "12" + "/" + (_docso.Nam - 1);
                            lblKy3.Text = "11" + "/" + (_docso.Nam - 1);
                            img = wsDHN.get_Hinh((_docso.Nam) + "01" + _docso.DanhBa);
                            if (img != null)
                                ptbKy1.Image = _cDocSo.byteArrayToImage(img);
                            else
                                ptbKy1.Image = Properties.Resources.no_image;
                            img = wsDHN.get_Hinh((_docso.Nam - 1) + "12" + _docso.DanhBa);
                            if (img != null)
                                ptbKy2.Image = _cDocSo.byteArrayToImage(img);
                            else
                                ptbKy2.Image = Properties.Resources.no_image;
                            img = wsDHN.get_Hinh((_docso.Nam - 1) + "11" + _docso.DanhBa);
                            if (img != null)
                                ptbKy3.Image = _cDocSo.byteArrayToImage(img);
                            else
                                ptbKy3.Image = Properties.Resources.no_image;
                        }
                        else
                            if (_docso.Ky == "03")
                            {
                                lblKy1.Text = "02" + "/" + (_docso.Nam);
                                lblKy2.Text = "01" + "/" + (_docso.Nam);
                                lblKy3.Text = "12" + "/" + (_docso.Nam - 1);
                                img = wsDHN.get_Hinh((_docso.Nam) + "02" + _docso.DanhBa);
                                if (img != null)
                                    ptbKy1.Image = _cDocSo.byteArrayToImage(img);
                                else
                                    ptbKy1.Image = Properties.Resources.no_image;
                                img = wsDHN.get_Hinh((_docso.Nam) + "01" + _docso.DanhBa);
                                if (img != null)
                                    ptbKy2.Image = _cDocSo.byteArrayToImage(img);
                                else
                                    ptbKy2.Image = Properties.Resources.no_image;
                                img = wsDHN.get_Hinh((_docso.Nam - 1) + "12" + _docso.DanhBa);
                                if (img != null)
                                    ptbKy3.Image = _cDocSo.byteArrayToImage(img);
                                else
                                    ptbKy3.Image = Properties.Resources.no_image;
                            }
                            else
                            {
                                lblKy1.Text = (int.Parse(_docso.Ky) - 1).ToString("00") + "/" + (_docso.Nam);
                                lblKy2.Text = (int.Parse(_docso.Ky) - 2).ToString("00") + "/" + (_docso.Nam);
                                lblKy3.Text = (int.Parse(_docso.Ky) - 3).ToString("00") + "/" + (_docso.Nam);
                                img = wsDHN.get_Hinh((_docso.Nam) + (int.Parse(_docso.Ky) - 1).ToString("00") + _docso.DanhBa);
                                if (img != null)
                                    ptbKy1.Image = _cDocSo.byteArrayToImage(img);
                                else
                                    ptbKy1.Image = Properties.Resources.no_image;
                                img = wsDHN.get_Hinh((_docso.Nam) + (int.Parse(_docso.Ky) - 2).ToString("00") + _docso.DanhBa);
                                if (img != null)
                                    ptbKy2.Image = _cDocSo.byteArrayToImage(img);
                                else
                                    ptbKy2.Image = Properties.Resources.no_image;
                                img = wsDHN.get_Hinh((_docso.Nam) + (int.Parse(_docso.Ky) - 3).ToString("00") + _docso.DanhBa);
                                if (img != null)
                                    ptbKy3.Image = _cDocSo.byteArrayToImage(img);
                                else
                                    ptbKy3.Image = Properties.Resources.no_image;
                            }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ptbKy0_MouseClick(object sender, MouseEventArgs e)
        {
            if (ptbKy0.Image != null)
                _cDocSo.LoadImageView(_cDocSo.imageToByteArray(ptbKy0.Image));
        }

        private void ptbKy1_MouseClick(object sender, MouseEventArgs e)
        {
            if (ptbKy1.Image != null)
                _cDocSo.LoadImageView(_cDocSo.imageToByteArray(ptbKy1.Image));
        }

        private void ptbKy2_MouseClick(object sender, MouseEventArgs e)
        {
            if (ptbKy2.Image != null)
                _cDocSo.LoadImageView(_cDocSo.imageToByteArray(ptbKy2.Image));
        }

        private void ptbKy3_MouseClick(object sender, MouseEventArgs e)
        {
            if (ptbKy3.Image != null)
                _cDocSo.LoadImageView(_cDocSo.imageToByteArray(ptbKy3.Image));
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (_docso != null)
                    {
                        if (CNguoiDung.updateChuyenListing == false)
                            if (_cDocSo.checkChot_BillState(_docso.Nam.Value.ToString(), _docso.Ky, _docso.Dot) == true)
                            {
                                MessageBox.Show("Năm " + _docso.Nam.Value.ToString() + " Kỳ " + _docso.Ky + " Đợt " + _docso.Dot + " đã chuyển billing", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        int TTienNuoc = 0, TThueGTGT = 0, TTDVTN = 0, TThueTDVTN = 0, TTieuThu = 0;
                        //if (wsDHN.tinhCodeTieuThu_CSM(_docso.DocSoID, cmbCodeMoi.SelectedValue.ToString(), int.Parse(txtCSM.Text.Trim()), out TieuThu, out GiaBan, out ThueGTGT, out PhiBVMT, out TongCong) == true)
                        if (wsDHN.tinhCodeTieuThu_TieuThu(_docso.DocSoID, cmbCodeMoi.SelectedValue.ToString(), int.Parse(txtTieuThu.Text.Trim()), out TTienNuoc, out TThueGTGT, out TTDVTN, out TThueTDVTN) == true)
                        {
                            _docso.GhiChuDS = tbxGCDS.Text.Trim();
                            _docso.GhiChuKH = tbxGCKH.Text.Trim();
                            _docso.GhiChuTV = tbxGCTV.Text.Trim();

                            _docso.CodeMoi = cmbCodeMoi.SelectedValue.ToString();
                            _docso.TTDHNMoi = _cDocSo.getTTDHNCode(_docso.CodeMoi);
                            //_docso.CSCu = int.Parse(txtCSC.Text.Trim());
                            _docso.CSMoi = int.Parse(txtCSM.Text.Trim());
                            //_docso.TieuThuMoi = TieuThu;
                            _docso.TieuThuMoi = int.Parse(txtTieuThu.Text.Trim());
                            if (_docso.CodeMoi.Substring(0, 1).Contains("F") == true || _docso.CodeMoi.Contains("61") == true)
                                _docso.CSMoi = _docso.CSCu + _docso.TieuThuMoi;
                            _docso.TienNuoc = TTienNuoc;
                            _docso.Thue = TThueGTGT;
                            _docso.BVMT = TTDVTN;
                            _docso.BVMT_Thue = TThueTDVTN;
                            _docso.TongTien = TTienNuoc + TThueGTGT + TTDVTN + TThueTDVTN;
                            _docso.NVCapNhat = CNguoiDung.HoTen;
                            _docso.NgayCapNhat = DateTime.Now;
                            _docso.StaCapNhat = "1";
                            _cDocSo.SubmitChanges();
                            dgvDanhSach.CurrentRow.Cells["TTDHNMoi"].Value = _docso.TTDHNMoi;
                            dgvDanhSach.CurrentRow.Cells["CodeMoi"].Value = _docso.CodeMoi;
                            dgvDanhSach.CurrentRow.Cells["CSMoi"].Value = _docso.CSMoi;
                            dgvDanhSach.CurrentRow.Cells["TieuThuMoi"].Value = _docso.TieuThuMoi;
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //loadCodeMoi();
                            //btnXem.PerformClick();
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

        private void txtCSM_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (txtCSM.Text.Trim() != "" && e.KeyChar == 13)
                {
                    txtTieuThu.Text = _cDocSo.tinhCodeTieuThu(_docso.DocSoID, cmbCodeMoi.SelectedValue.ToString(), int.Parse(txtCSM.Text.Trim())).ToString();
                    txtTieuThu.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDieuChinhXuat_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (_cDocSo.checkChot_BillState(cmbNam.SelectedValue.ToString(), cmbKy.SelectedItem.ToString(), cmbDot.SelectedItem.ToString()) == true)
                        {
                            MessageBox.Show("Năm " + cmbNam.SelectedValue.ToString() + " Kỳ " + cmbKy.SelectedItem.ToString() + " Đợt " + cmbDot.SelectedItem.ToString() + " đã chuyển billing", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        DataTable dt = new DataTable();
                        switch (cmbDieuChinhXuat.SelectedItem.ToString())
                        {
                            case "Điều chỉnh Code 5N, 5K":
                                dt = _cDocSo.getDS_Code5K5N(cmbNam.SelectedValue.ToString(), cmbKy.SelectedItem.ToString(), cmbDot.SelectedItem.ToString());
                                break;
                            default:
                                break;
                        }
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            //Tạo các đối tượng Excel
                            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
                            Microsoft.Office.Interop.Excel.Workbooks oBooks;
                            Microsoft.Office.Interop.Excel.Sheets oSheets;
                            Microsoft.Office.Interop.Excel.Workbook oBook;
                            Microsoft.Office.Interop.Excel.Worksheet oSheet;
                            //Microsoft.Office.Interop.Excel.Worksheet oSheetCQ;

                            //Tạo mới một Excel WorkBook 
                            oExcel.Visible = true;
                            oExcel.DisplayAlerts = false;
                            //khai báo số lượng sheet
                            oExcel.Application.SheetsInNewWorkbook = 1;
                            oBooks = oExcel.Workbooks;

                            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
                            oSheets = oBook.Worksheets;
                            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

                            _cDocSo.XuatExcel(dt, oSheet, "5K,5N");
                            if (_cDocSo.updateDS_Code5K5N(cmbNam.SelectedValue.ToString(), cmbKy.SelectedItem.ToString(), cmbDot.SelectedItem.ToString()) == true)
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void cmbCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnXem.PerformClick();
        }

        private void cmbMay_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnXem.PerformClick();
        }

        private void cmbDot_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadCodeMoi();
        }

        private void cmbKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadCodeMoi();
        }

        private void cmbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadCodeMoi();
        }

        public void loadCodeMoi()
        {
            if (_flagLoadFirst == true)
            {
                DataTable dtCode = _cDocSo.getDS_Code(cmbNam.SelectedValue.ToString(), cmbKy.SelectedItem.ToString(), cmbDot.SelectedItem.ToString());
                DataRow dr = dtCode.NewRow();
                dr["Code"] = "Tất Cả";
                dtCode.Rows.InsertAt(dr, 0);
                cmbCode.DataSource = dtCode;
                cmbCode.DisplayMember = "Code";
                cmbCode.ValueMember = "Code";
            }
        }

        private void btnXemGhiChu_Click(object sender, EventArgs e)
        {
            if (_docso != null)
            {
                frmXemLichSuGhiChu frm = new frmXemLichSuGhiChu(_docso.DanhBa);
                frm.ShowDialog();
            }
        }

        private void btnXemLichSu_Click(object sender, EventArgs e)
        {
            if (_docso != null)
            {
                frmXemLichSuXuLy frm = new frmXemLichSuXuLy(_docso.DocSoID);
                frm.ShowDialog();
            }
        }

        private void txtTieuThu_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (txtTieuThu.Text.Trim() != "" && e.KeyChar == 13)
                {
                    btnSua.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbCodeMoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCodeMoi.SelectedValue.ToString() == "N" || cmbCodeMoi.SelectedValue.ToString() == "K" || cmbCodeMoi.SelectedValue.ToString() == "68")
                txtTieuThu.Text = "0";
            txtCSM.Focus();
        }

        private void dgvDanhSach_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            loaddgvDanhSach();
        }

        private void dgvDanhSach_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                {
                    _docso = _cDocSo.get_DocSo(dgvDanhSach.CurrentRow.Cells["DocSoID"].Value.ToString());
                    loadThongTin();
                }
            }
            catch
            {
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {
                if (CNguoiDung.updateChuyenListing == false)
                    if (_cDocSo.checkChot_BillState(_docso.Nam.Value.ToString(), _docso.Ky, _docso.Dot) == true)
                    {
                        MessageBox.Show("Năm " + _docso.Nam.Value.ToString() + " Kỳ " + _docso.Ky + " Đợt " + _docso.Dot + " đã chuyển billing", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                if (MessageBox.Show("Bạn có chắc chắn?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    if (_docso != null)
                    {
                        _docso.CodeMoi = null;
                        _docso.TTDHNMoi = null;
                        _docso.CSMoi = null;
                        _docso.TieuThuMoi = null;
                        _docso.TienNuoc = null;
                        _docso.Thue = null;
                        _docso.BVMT = null;
                        _docso.TongTien = null;
                        _docso.NVCapNhat = CNguoiDung.HoTen;
                        _docso.NgayCapNhat = DateTime.Now;
                        _cDocSo.SubmitChanges();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Lỗi, Vui lòng chọn Người Dùng cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnChuyenDonToMaHoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen("mnuDonTu", "Them"))
                {
                    if (cmbNoiDung.SelectedIndex >= 0)
                    {
                        if (MessageBox.Show("Bạn có chắc chắn?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            foreach (DataGridViewRow item in dgvDanhSach.SelectedRows)
                                if (_cDonTu.checkExists(item.Cells["DanhBo"].Value.ToString().Replace(" ", ""), DateTime.Now) == false)
                                {
                                    MaHoa_DonTu en = new MaHoa_DonTu();
                                    HOADON hd = _cThuTien.GetMoiNhat(item.Cells["DanhBo"].Value.ToString().Replace(" ", ""));
                                    if (hd != null)
                                    {
                                        en.DanhBo = hd.DANHBA;
                                        en.HoTen = hd.TENKH;
                                        en.DiaChi = hd.SO + " " + hd.DUONG;
                                        en.GiaBieu = hd.GB;
                                        if (hd.DM != null)
                                            en.DinhMuc = hd.DM;
                                        if (hd.DinhMucHN != null)
                                            en.DinhMucHN = hd.DinhMucHN;
                                        en.NoiDung = cmbNoiDung.SelectedItem.ToString();
                                        //en.GhiChu = txtGhiChu.Text.Trim();
                                        en.TinhTrang = "Tồn";
                                        en.MLT = hd.MALOTRINH;
                                        en.HopDong = hd.HOPDONG;
                                        en.Dot = hd.DOT;
                                        en.Ky = hd.KY;
                                        en.Nam = hd.NAM;
                                        en.Quan = hd.Quan;
                                        en.Phuong = hd.Phuong;
                                        _cDonTu.Them(en);
                                    }
                                }
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Chưa chọn Nội Dung Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKiemTraHinh_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("DanhBo", typeof(string));
                dt.Columns.Add("May", typeof(string));
                foreach (DataGridViewRow item in dgvDanhSach.Rows)
                {
                    if (wsDHN.checkExists_Hinh(item.Cells["DocSoID"].Value.ToString()) == false)
                    {
                        DataRow dr = dt.NewRow();
                        dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString();
                        dr["May"] = item.Cells["MLT"].Value.ToString().Substring(2, 2);
                        dt.Rows.Add(dr);
                    }
                }

                //Tạo các đối tượng Excel
                Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbooks oBooks;
                Microsoft.Office.Interop.Excel.Sheets oSheets;
                Microsoft.Office.Interop.Excel.Workbook oBook;
                Microsoft.Office.Interop.Excel.Worksheet oSheet;

                //Tạo mới một Excel WorkBook 
                oExcel.Visible = true;
                oExcel.DisplayAlerts = false;
                //khai báo số lượng sheet
                oExcel.Application.SheetsInNewWorkbook = 1;
                oBooks = oExcel.Workbooks;

                oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
                oSheets = oBook.Worksheets;
                oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

                oSheet.Name = "Sheet1";
                // Tạo tiêu đề cột 

                Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A1", "A1");
                cl1.Value2 = "Danh Bộ";
                cl1.ColumnWidth = 12;

                Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B1", "B1");
                cl2.Value2 = "Máy";
                cl2.ColumnWidth = 10;

                // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
                // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
                int numColumn = 2;
                object[,] arr = new object[dt.Rows.Count, numColumn];

                //Chuyển dữ liệu từ DataTable vào mảng đối tượng
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    {
                        arr[i, 0] = dr["DanhBo"].ToString();
                        arr[i, 1] = dr["May"].ToString();
                    }
                }

                //Thiết lập vùng điền dữ liệu
                int rowStart = 2;
                int columnStart = 1;

                int rowEnd = rowStart + dt.Rows.Count - 1;
                int columnEnd = numColumn;

                // Ô bắt đầu điền dữ liệu
                Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
                // Ô kết thúc điền dữ liệu
                Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
                // Lấy về vùng điền dữ liệu
                Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

                Microsoft.Office.Interop.Excel.Range c1a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 1];
                Microsoft.Office.Interop.Excel.Range c2a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 1];
                Microsoft.Office.Interop.Excel.Range c3a = oSheet.get_Range(c1a, c2a);
                c3a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                Microsoft.Office.Interop.Excel.Range c1b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 2];
                Microsoft.Office.Interop.Excel.Range c2b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 2];
                Microsoft.Office.Interop.Excel.Range c3b = oSheet.get_Range(c1b, c2b);
                c3b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                c3b.NumberFormat = "@";

                Microsoft.Office.Interop.Excel.Range c1c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 3];
                Microsoft.Office.Interop.Excel.Range c2c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 3];
                Microsoft.Office.Interop.Excel.Range c3c = oSheet.get_Range(c1c, c2c);
                c3c.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                Microsoft.Office.Interop.Excel.Range c1d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 4];
                Microsoft.Office.Interop.Excel.Range c2d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 4];
                Microsoft.Office.Interop.Excel.Range c3d = oSheet.get_Range(c1d, c2d);
                c3d.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                //Điền dữ liệu vào vùng đã thiết lập
                range.Value2 = arr;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




    }
}
