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
using DocSo_PC.WebReference;

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
        wsThuTien wsThuTien = new wsThuTien();
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
                cmbKy.SelectedItem = DateTime.Now.Month.ToString();
                DataTable dtCode = _cDocSo.getDS_Code();
                DataRow dr = dtCode.NewRow();
                dr["Code"] = "Tất Cả";
                dtCode.Rows.InsertAt(dr, 0);
                cmbCode.DataSource = dtCode;
                cmbCode.DisplayMember = "Code";
                cmbCode.ValueMember = "Code";

                dtCode = _cDocSo.getDS_Code();
                cmbCodeMoi.DataSource = dtCode;
                cmbCodeMoi.DisplayMember = "Code";
                cmbCodeMoi.ValueMember = "Code";
                if (CNguoiDung.Doi)
                {
                    cmbTo.Visible = true;

                    cmbTo.DataSource = _cTo.getDS_HanhThu();
                    cmbTo.DisplayMember = "TenTo";
                    cmbTo.ValueMember = "MaTo";
                    cmbTo.SelectedIndex = -1;
                }
                else
                {
                    lbTo.Text = "Tổ  " + CNguoiDung.TenTo;
                    loadMay(CNguoiDung.MaTo.ToString());
                }
                _flagLoadFirst = true;
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
                DataTable dtMay = _cMayDS.getDS(MaTo);
                DataRow dr = dtMay.NewRow();
                dr["May"] = "Tất Cả";
                dtMay.Rows.InsertAt(dr, 0);
                cmbMay.DataSource = dtMay;
                cmbMay.DisplayMember = "May";
                cmbMay.ValueMember = "May";
                //cmbMay.SelectedIndex = ;
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
                        txtNgayGhiCS.Text = _docso.GIOGHI.Value.ToString();
                        txtNguoiCapNhat.Text = _docso.NVCapNhat;
                        txtNgayCapNhat.Text = _docso.NgayCapNhat.Value.ToString();
                        tbxGCDS.Text = _docso.GhiChuDS;
                        tbxGCKH.Text = _docso.GhiChuKH;
                        tbxGCTV.Text = _docso.GhiChuTV;
                        dgvThongBao.DataSource = _cDocSo.getThongBao(_docso.DanhBa);
                        dgvBaoThay.DataSource = _cDocSo.getBaoThay(_docso.DanhBa);
                        dgvLichSu.DataSource = _cDocSo.getLichSu(_docso.DanhBa, _docso.Nam.Value.ToString(), _docso.Ky);
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
            if (CNguoiDung.Doi == true)
            {
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

            }
            dgvDanhSach.DataSource = dt;
            if (dtTong != null && dtTong.Rows.Count > 0)
            {
                lbTongSL.Text = dtTong.Rows[0]["TongSL"].ToString();
                lbSLDaGhi.Text = dtTong.Rows[0]["SLDaGhi"].ToString();
                lbSLChuaGhi.Text = dtTong.Rows[0]["SLChuaGhi"].ToString();
                lbSanLuong.Text = dtTong.Rows[0]["SanLuong"].ToString();
                lbSLHD0.Text = dtTong.Rows[0]["SLHD0"].ToString();
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
            if (dgvDanhSach.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(7, " ").Insert(4, " ");
            }
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
                    byte[] img = _cDocSo12.getHinh((_docso.Nam) + (int.Parse(_docso.Ky)).ToString("00") + _docso.DanhBa);
                    if (img != null)
                        ptbKy0.Image = _cDocSo.byteArrayToImage(img);
                    else
                        ptbKy0.Image = Properties.Resources.no_image;
                    if (_docso.Ky == "01")
                    {
                        lblKy1.Text = "12" + "/" + (_docso.Nam - 1);
                        lblKy2.Text = "11" + "/" + (_docso.Nam - 1);
                        lblKy3.Text = "10" + "/" + (_docso.Nam - 1);
                        img = _cDocSo12.getHinh((_docso.Nam - 1) + "12" + _docso.DanhBa);
                        if (img != null)
                            ptbKy1.Image = _cDocSo.byteArrayToImage(img);
                        else
                            ptbKy1.Image = Properties.Resources.no_image;
                        img = _cDocSo12.getHinh((_docso.Nam - 1) + "11" + _docso.DanhBa);
                        if (img != null)
                            ptbKy2.Image = _cDocSo.byteArrayToImage(img);
                        else
                            ptbKy2.Image = Properties.Resources.no_image;
                        img = _cDocSo12.getHinh((_docso.Nam - 1) + "10" + _docso.DanhBa);
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
                            img = _cDocSo12.getHinh((_docso.Nam) + "01" + _docso.DanhBa);
                            if (img != null)
                                ptbKy1.Image = _cDocSo.byteArrayToImage(img);
                            else
                                ptbKy1.Image = Properties.Resources.no_image;
                            img = _cDocSo12.getHinh((_docso.Nam - 1) + "12" + _docso.DanhBa);
                            if (img != null)
                                ptbKy2.Image = _cDocSo.byteArrayToImage(img);
                            else
                                ptbKy2.Image = Properties.Resources.no_image;
                            img = _cDocSo12.getHinh((_docso.Nam - 1) + "11" + _docso.DanhBa);
                            if (img != null)
                                ptbKy3.Image = _cDocSo.byteArrayToImage(img);
                            else
                                ptbKy3.Image = Properties.Resources.no_image;
                        }
                        else
                            if (_docso.Ky == "03")
                            {
                                lblKy1.Text = "01" + "/" + (_docso.Nam);
                                lblKy2.Text = "02" + "/" + (_docso.Nam);
                                lblKy3.Text = "12" + "/" + (_docso.Nam - 1);
                                img = _cDocSo12.getHinh((_docso.Nam) + "01" + _docso.DanhBa);
                                if (img != null)
                                    ptbKy1.Image = _cDocSo.byteArrayToImage(img);
                                else
                                    ptbKy1.Image = Properties.Resources.no_image;
                                img = _cDocSo12.getHinh((_docso.Nam) + "02" + _docso.DanhBa);
                                if (img != null)
                                    ptbKy2.Image = _cDocSo.byteArrayToImage(img);
                                else
                                    ptbKy2.Image = Properties.Resources.no_image;
                                img = _cDocSo12.getHinh((_docso.Nam - 1) + "12" + _docso.DanhBa);
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
                                img = _cDocSo12.getHinh((_docso.Nam) + (int.Parse(_docso.Ky) - 1).ToString("00") + _docso.DanhBa);
                                if (img != null)
                                    ptbKy1.Image = _cDocSo.byteArrayToImage(img);
                                else
                                    ptbKy1.Image = Properties.Resources.no_image;
                                img = _cDocSo12.getHinh((_docso.Nam) + (int.Parse(_docso.Ky) - 2).ToString("00") + _docso.DanhBa);
                                if (img != null)
                                    ptbKy2.Image = _cDocSo.byteArrayToImage(img);
                                else
                                    ptbKy2.Image = Properties.Resources.no_image;
                                img = _cDocSo12.getHinh((_docso.Nam) + (int.Parse(_docso.Ky) - 3).ToString("00") + _docso.DanhBa);
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

        private void ptbKy0_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _cDocSo.LoadImageView(_cDocSo.imageToByteArray(ptbKy0.Image));
        }

        private void ptbKy1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _cDocSo.LoadImageView(_cDocSo.imageToByteArray(ptbKy1.Image));
        }

        private void ptbKy2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _cDocSo.LoadImageView(_cDocSo.imageToByteArray(ptbKy2.Image));
        }

        private void ptbKy3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
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
                        if (_cDocSo.checkChot_BillState(_docso.Nam.Value.ToString(), _docso.Ky, _docso.Dot) == true)
                        {
                            MessageBox.Show("Năm " + _docso.Nam.Value.ToString() + " Kỳ " + _docso.Ky + " Đợt " + _docso.Dot + " đã chuyển billing", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        _docso.CodeMoi = cmbCodeMoi.SelectedValue.ToString();
                        _docso.TTDHNMoi = _cDocSo.getTTDHNCode(_docso.CodeMoi);
                        _docso.CSCu = int.Parse(txtCSC.Text.Trim());
                        _docso.CSMoi = int.Parse(txtCSM.Text.Trim());
                        _docso.TieuThuMoi = int.Parse(txtTieuThu.Text.Trim());
                        BienDong bd = _cDocSo.get_BienDong(_docso.DocSoID);
                        int TienNuocA = 0, TienNuocB = 0, PhiBVMTA = 0, PhiBVMTB = 0, TieuThu_DieuChinhGia = 0;
                        string ChiTietA = "", ChiTietB = "", ChiTietPhiBVMTA = "", ChiTietPhiBVMTB = "";
                        wsThuTien.TinhTienNuoc(false, false, false, 0, bd.DanhBa, int.Parse(bd.Ky), bd.Nam.Value, _docso.TuNgay.Value, _docso.DenNgay.Value
                             , bd.GB.Value, bd.SH.Value, bd.SX.Value, bd.DV.Value, bd.HC.Value
                             , bd.DM.Value, bd.DMHN.Value, _docso.TieuThuMoi.Value, ref TienNuocA, ref ChiTietA, ref TienNuocB, ref ChiTietB, ref TieuThu_DieuChinhGia, ref PhiBVMTA, ref ChiTietPhiBVMTA, ref PhiBVMTB, ref ChiTietPhiBVMTB);
                        _docso.TienNuoc = (TienNuocA + TienNuocB);
                        _docso.Thue = (int)Math.Round((double)(TienNuocA + TienNuocB) * 5 / 100, 0, MidpointRounding.AwayFromZero);
                        _docso.BVMT = (PhiBVMTA + PhiBVMTB);
                        _docso.TongTien = _docso.TienNuoc + _docso.Thue + (PhiBVMTA + PhiBVMTB);
                        _cDocSo.SubmitChanges();
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
