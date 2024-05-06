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
using System.Globalization;
using DocSo_PC.DAL.MaHoa;

namespace DocSo_PC.GUI.ToTruong
{
    public partial class frmGhiChu : Form
    {
        string _mnu = "mnuGhiChu";
        CDocSo _cDocSo = new CDocSo();
        CTo _cTo = new CTo();
        CMayDS _cMayDS = new CMayDS();
        CDHN _cDHN = new CDHN();
        CPhieuChuyen _cPhieuChuyen = new CPhieuChuyen();
        bool _flagLoadFirst = false;
        TB_DULIEUKHACHHANG _enDLKH = null;
        bool _flagThemDienThoai = false;
        wrDHN.wsDHN _wsDHN = new wrDHN.wsDHN();

        public frmGhiChu()
        {
            InitializeComponent();
        }

        private void frmGhiChu_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
            dgvDienThoai.AutoGenerateColumns = false;
            dgvThongKe.AutoGenerateColumns = false;
            dgvPhieuChuyen.AutoGenerateColumns = false;
            dgvGhiChu.AutoGenerateColumns = false;
            cmbDot.Items.Add("Tất Cả");
            for (int i = CNguoiDung.FromDot; i <= CNguoiDung.ToDot; i++)
            {
                cmbDot.Items.Add(i.ToString("00"));
            }
            if (CNguoiDung.Admin)
                btnChonFile.Visible = true;
            if (CNguoiDung.Doi || CNguoiDung.Admin)
            {
                cmbTo.Visible = true;
                List<To> lst = null;
                if (CNguoiDung.Admin)
                    lst = _cTo.getDS_HanhThu();
                else
                    if (CNguoiDung.Doi)
                        lst = _cTo.getDS_HanhThu(CNguoiDung.IDPhong);
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
            DataTable dt1, dt2;
            dt1 = dt2 = _cDHN.getDS_ViTriDHN();
            cmbViTri.DataSource = dt1;
            cmbViTri.DisplayMember = "KyHieu";
            cmbViTri.ValueMember = "KyHieu";
            cmbDot.SelectedIndex = 0;
            _flagLoadFirst = true;
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

        public void clear()
        {
            txtSoNha.Text = "";
            txtTenDuong.Text = "";
            cmbViTri.SelectedIndex = -1;
            chkViTriDHN_Ngoai.Checked = false;
            chkViTriDHN_Hop.Checked = false;
            chkGieng.Checked = false;
            cmbMauSacChiGoc.SelectedIndex = -1;
            //chkAmSau.Checked = false;
            //chkXayDung.Checked = false;
            //chkDutChiGoc.Checked = false;
            //chkDutChiThan.Checked = false;
            //chkNgapNuoc.Checked = false;
            //chkKetTuong.Checked = false;
            //chkLapKhoaGoc.Checked = false;
            //chkBeHBV.Checked = false;
            //chkBeNapMatNapHBV.Checked = false;
            //chkGayTayVan.Checked = false;
            //chkTroNgaiThay.Checked = false;
            //chkDauChungMayBom.Checked = false;
        }

        public void loadthongtin(TB_DULIEUKHACHHANG en)
        {
            clear();
            if (en != null)
            {
                txtSoNha.Text = en.SONHA;
                txtTenDuong.Text = en.TENDUONG;
                if (en.VITRIDHN != null && en.VITRIDHN != "")
                    cmbViTri.SelectedValue = en.VITRIDHN;
                chkViTriDHN_Ngoai.Checked = en.ViTriDHN_Ngoai;
                chkViTriDHN_Hop.Checked = en.ViTriDHN_Hop;
                chkGieng.Checked = en.Gieng;
                cmbMauSacChiGoc.SelectedItem = en.MauSacChiGoc;
                dgvDienThoai.DataSource = _cDHN.getDS_DienThoai(en.DANHBO);
                //chkAmSau.Checked = en.AmSau;
                //if (en.AmSau == true)
                //    dateAmSau.Value = en.AmSau_Ngay.Value;
                //chkXayDung.Checked = en.XayDung;
                //if (en.XayDung == true)
                //    dateXayDung.Value = en.XayDung_Ngay.Value;
                //chkDutChiGoc.Checked = en.DutChi_Goc;
                //if (en.DutChi_Goc == true)
                //    dateDutChiGoc.Value = en.DutChi_Goc_Ngay.Value;
                //chkDutChiThan.Checked = en.DutChi_Than;
                //if (en.DutChi_Than == true)
                //    dateDutChiThan.Value = en.DutChi_Than_Ngay.Value;
                //chkNgapNuoc.Checked = en.NgapNuoc;
                //if (en.NgapNuoc == true)
                //    dateNgapNuoc.Value = en.NgapNuoc_Ngay.Value;
                //chkKetTuong.Checked = en.KetTuong;
                //if (en.KetTuong == true)
                //    dateKetTuong.Value = en.KetTuong_Ngay.Value;
                //chkLapKhoaGoc.Checked = en.LapKhoaGoc;
                //if (en.LapKhoaGoc == true)
                //    dateLapKhoaGoc.Value = en.LapKhoaGoc_Ngay.Value;
                //chkBeHBV.Checked = en.BeHBV;
                //if (en.BeHBV == true)
                //    dateBeHBV.Value = en.BeHBV_Ngay.Value;
                //chkBeNapMatNapHBV.Checked = en.BeNapMatNapHBV;
                //if (en.BeNapMatNapHBV == true)
                //    dateBeNapMatNapHBV.Value = en.BeNapMatNapHBV_Ngay.Value;
                //chkGayTayVan.Checked = en.GayTayVan;
                //if (en.GayTayVan == true)
                //    dateGayTayVan.Value = en.GayTayVan_Ngay.Value;
                //chkTroNgaiThay.Checked = en.TroNgaiThay;
                //if (en.TroNgaiThay == true)
                //    dateTroNgaiThay.Value = en.TroNgaiThay_Ngay.Value;
                //chkDauChungMayBom.Checked = en.DauChungMayBom;
                //if (en.DauChungMayBom == true)
                //    dateDauChungMayBom.Value = en.DauChungMayBom_Ngay.Value;
                dgvPhieuChuyen.DataSource = _cPhieuChuyen.getDS(en.DANHBO);
                dgvGhiChu.DataSource = _cDHN.getDS_GhiChu(en.DANHBO);
            }
        }

        private void cmbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_flagLoadFirst == true && cmbTo.SelectedIndex > -1)
                loadMay(cmbTo.SelectedValue.ToString());
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.Doi == true)
            {
                if (txtDanhBo.Text.Trim().Replace(" ", "").Replace("-", "") != "")
                {
                    dgvDanhSach.DataSource = _cDHN.getDS_DienThoai_DanhBo(txtDanhBo.Text.Trim().Replace(" ", "").Replace("-", ""));
                    _enDLKH = _cDHN.get(dgvDanhSach.Rows[0].Cells["DanhBo"].Value.ToString());
                    loadthongtin(_enDLKH);
                }
                else
                    if (cmbMay.SelectedIndex == 0)
                    {
                        DataTable dt = new DataTable();
                        foreach (object item in cmbMay.Items)
                        {
                            DataRowView row = item as DataRowView;
                            if (row != null)
                            {
                                string displayValue = row["May"].ToString();
                                if (displayValue != "Tất Cả")
                                    dt.Merge(_cDHN.getDS_DienThoai(cmbDot.SelectedItem.ToString(), displayValue));
                            }
                        }
                        dgvDanhSach.DataSource = dt;
                    }
                    else
                    {
                        dgvDanhSach.DataSource = _cDHN.getDS_DienThoai(cmbDot.SelectedItem.ToString(), cmbMay.SelectedValue.ToString());
                    }
                if (cmbDot.SelectedIndex == 0)
                {
                    DataTable dt = new DataTable();
                    for (int i = 1; i < cmbDot.Items.Count; i++)
                    {
                        dt.Merge(_cDHN.getThongKe_DienThoai(cmbDot.Items[i].ToString()));
                    }
                }
                else
                    dgvThongKe.DataSource = _cDHN.getThongKe_DienThoai(cmbDot.SelectedItem.ToString());
            }
            else
            {
                if (txtDanhBo.Text.Trim().Replace(" ", "").Replace("-", "") != "")
                    dgvDanhSach.DataSource = _cDHN.getDS_DienThoai_DanhBo(CNguoiDung.MaTo.ToString(), txtDanhBo.Text.Trim().Replace(" ", "").Replace("-", ""));
                else
                    if (cmbMay.SelectedIndex == 0)
                    {
                        DataTable dt = new DataTable();
                        foreach (object item in cmbMay.Items)
                        {
                            DataRowView row = item as DataRowView;
                            if (row != null)
                            {
                                string displayValue = row["May"].ToString();
                                if (displayValue != "Tất Cả")
                                    dt.Merge(_cDHN.getDS_DienThoai(cmbDot.SelectedItem.ToString(), displayValue));
                            }
                        }
                        dgvDanhSach.DataSource = dt;
                    }
                    else
                    {
                        dgvDanhSach.DataSource = _cDHN.getDS_DienThoai(cmbDot.SelectedItem.ToString(), cmbMay.SelectedValue.ToString());
                    }
                if (cmbDot.SelectedIndex == 0)
                {
                    DataTable dt = new DataTable();
                    for (int i = 1; i < cmbDot.Items.Count; i++)
                    {
                        dt.Merge(_cDHN.getThongKe_DienThoai(cmbDot.Items[i].ToString()));
                    }
                }
                else
                    dgvThongKe.DataSource = _cDHN.getThongKe_DienThoai(cmbDot.SelectedItem.ToString());
            }
            int TongViTri = 0, TongDienThoai = 0;//, TongDTKH = 0, TongDTDHN = 0, TongDTTV = 0;
            foreach (DataGridViewRow item in dgvDanhSach.Rows)
            {
                if (item.Cells["ViTri"].Value.ToString() != "")
                    TongViTri++;
                if (item.Cells["DienThoai"].Value.ToString() != "")
                    TongDienThoai++;
                //if (item.Cells["DTKH"].Value.ToString() != "")
                //    TongDTKH++;
                //if (item.Cells["DTDHN"].Value.ToString() != "")
                //    TongDTDHN++;
                //if (item.Cells["DTTV"].Value.ToString() != "")
                //    TongDTTV++;
            }
            txtTongViTri.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongViTri);
            txtTongDienThoai.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongDienThoai);
            //txtTongDTKH.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongDTKH);
            //txtTongDTDHN.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongDTDHN);
            //txtTongDTTV.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongDTTV);
        }

        private void dgvDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (_enDLKH != null)
                    {
                        _enDLKH.SONHA = txtSoNha.Text.Trim();
                        _enDLKH.TENDUONG = txtTenDuong.Text.Trim();
                        if (cmbViTri.SelectedIndex >= 0)
                            _enDLKH.VITRIDHN = cmbViTri.SelectedValue.ToString();
                        _enDLKH.ViTriDHN_Ngoai = chkViTriDHN_Ngoai.Checked;
                        _enDLKH.ViTriDHN_Hop = chkViTriDHN_Hop.Checked;
                        _enDLKH.Gieng = chkGieng.Checked;
                        //if (_enDLKH.AmSau && _enDLKH.AmSau != chkAmSau.Checked)
                        //{
                        //    _enDLKH.AmSau = chkAmSau.Checked;
                        //}
                        //if (_enDLKH.XayDung && _enDLKH.XayDung != chkXayDung.Checked)
                        //{
                        //    _enDLKH.XayDung = chkXayDung.Checked;
                        //}
                        //if (_enDLKH.DutChi_Goc && _enDLKH.DutChi_Goc != chkDutChiGoc.Checked)
                        //{
                        //    _enDLKH.DutChi_Goc = chkDutChiGoc.Checked;
                        //}
                        //if (_enDLKH.DutChi_Than && _enDLKH.DutChi_Than != chkDutChiThan.Checked)
                        //{
                        //    _enDLKH.DutChi_Than = chkDutChiThan.Checked;
                        //}
                        //if (_enDLKH.NgapNuoc && _enDLKH.NgapNuoc != chkNgapNuoc.Checked)
                        //{
                        //    _enDLKH.NgapNuoc = chkNgapNuoc.Checked;
                        //}
                        //if (_enDLKH.KetTuong && _enDLKH.KetTuong != chkKetTuong.Checked)
                        //{
                        //    _enDLKH.KetTuong = chkKetTuong.Checked;
                        //}
                        //if (_enDLKH.LapKhoaGoc && _enDLKH.LapKhoaGoc != chkLapKhoaGoc.Checked)
                        //{
                        //    _enDLKH.LapKhoaGoc = chkLapKhoaGoc.Checked;
                        //}
                        //if (_enDLKH.BeHBV && _enDLKH.BeHBV != chkBeHBV.Checked)
                        //{
                        //    _enDLKH.BeHBV = chkBeHBV.Checked;
                        //}
                        //if (_enDLKH.BeNapMatNapHBV && _enDLKH.BeNapMatNapHBV != chkBeNapMatNapHBV.Checked)
                        //{
                        //    _enDLKH.BeNapMatNapHBV = chkBeNapMatNapHBV.Checked;
                        //}
                        //if (_enDLKH.GayTayVan && _enDLKH.GayTayVan != chkGayTayVan.Checked)
                        //{
                        //    _enDLKH.GayTayVan = chkGayTayVan.Checked;
                        //}
                        //if (_enDLKH.TroNgaiThay && _enDLKH.TroNgaiThay != chkTroNgaiThay.Checked)
                        //{
                        //    _enDLKH.TroNgaiThay = chkTroNgaiThay.Checked;
                        //}
                        //if (_enDLKH.DauChungMayBom && _enDLKH.DauChungMayBom != chkDauChungMayBom.Checked)
                        //{
                        //    _enDLKH.DauChungMayBom = chkDauChungMayBom.Checked;
                        //}
                        _enDLKH.MauSacChiGoc = cmbMauSacChiGoc.SelectedItem.ToString();
                        _enDLKH.MODIFYBY = CNguoiDung.MaND.ToString();
                        _enDLKH.MODIFYDATE = DateTime.Now;
                        _cDHN.SubmitChanges();
                        //foreach (DataGridViewRow item in dgvDienThoai.Rows)
                        //{

                        //}
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _enDLKH = _cDHN.get(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString());
                loadthongtin(_enDLKH);
            }
            catch
            {
            }
        }

        private void dgvDienThoai_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            _flagThemDienThoai = true;
        }

        private void dgvDienThoai_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
                {
                    if (_enDLKH != null)
                    {
                        SDT_DHN en = _cDHN.get_DienThoai(e.Row.Cells["DanhBo_DT"].Value.ToString(), e.Row.Cells["DienThoai_DT"].Value.ToString());
                        if (en != null)
                        {
                            if (_cDHN.xoa_DienThoai(en) == true)
                            {
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgvDienThoai_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_flagThemDienThoai == false && dgvDienThoai["DanhBo_DT", e.RowIndex].Value.ToString() != "" && (dgvDienThoai.Columns[e.ColumnIndex].Name == "HoTen_DT" || dgvDienThoai.Columns[e.ColumnIndex].Name == "SoChinh_DT"))
                    if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                    {
                        if (_enDLKH != null)
                        {
                            SDT_DHN en = _cDHN.get_DienThoai(dgvDienThoai["DanhBo_DT", e.RowIndex].Value.ToString(), dgvDienThoai["DienThoai_DT", e.RowIndex].Value.ToString());
                            if (en != null)
                            {
                                en.HoTen = dgvDienThoai["HoTen_DT", e.RowIndex].Value.ToString();
                                if (dgvDienThoai["SoChinh_DT", e.RowIndex].Value != null && dgvDienThoai["SoChinh_DT", e.RowIndex].Value.ToString() != "")
                                    en.SoChinh = bool.Parse(dgvDienThoai["SoChinh_DT", e.RowIndex].Value.ToString());
                                else
                                    en.SoChinh = false;
                                //en.GhiChu = dgvDienThoai["GhiChu_DT", e.RowIndex].Value.ToString();
                                en.GhiChu = "Đ. QLĐHN";
                                en.ModifyBy = CNguoiDung.MaND;
                                en.ModifyDate = DateTime.Now;
                                _cDHN.SubmitChanges();
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

        private void dgvDienThoai_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    if (_enDLKH != null && _flagThemDienThoai == true)
                    {
                        if (dgvDienThoai["DienThoai_DT", e.RowIndex].Value.ToString().Length != 11 && dgvDienThoai["DienThoai_DT", e.RowIndex].Value.ToString().All(char.IsNumber) == false)
                        {
                            MessageBox.Show("Không đủ 10 số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (_cDHN.checkExists_DienThoai(_enDLKH.DANHBO, dgvDienThoai["DienThoai_DT", e.RowIndex].Value.ToString()) == true)
                        {
                            MessageBox.Show("Đã Tồn Tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        SDT_DHN en = new SDT_DHN();
                        en.DanhBo = _enDLKH.DANHBO;
                        en.DienThoai = dgvDienThoai["DienThoai_DT", e.RowIndex].Value.ToString();
                        en.HoTen = dgvDienThoai["HoTen_DT", e.RowIndex].Value.ToString();
                        if (dgvDienThoai["SoChinh_DT", e.RowIndex].Value != null && dgvDienThoai["SoChinh_DT", e.RowIndex].Value.ToString() != "")
                            en.SoChinh = bool.Parse(dgvDienThoai["SoChinh_DT", e.RowIndex].Value.ToString());
                        else
                            en.SoChinh = false;
                        en.GhiChu = dgvDienThoai["GhiChu_DT", e.RowIndex].Value.ToString();
                        if (_cDHN.them_DienThoai(en) == true)
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        _flagThemDienThoai = false;
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

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            string error = "";
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                    dialog.Multiselect = false;

                    if (dialog.ShowDialog() == DialogResult.OK)
                        if (MessageBox.Show("Bạn có chắc chắn Thêm?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            DataTable dtExcel = _cDocSo.ExcelToDataTable(dialog.FileName);

                            foreach (DataRow item in dtExcel.Rows)
                                if (!string.IsNullOrEmpty(item[2].ToString().Trim()) && item[3].ToString().Trim().Length == 10)
                                {
                                    string[] DanhBos = item[2].ToString().Trim().Split(',');
                                    foreach (string itemS in DanhBos)
                                        if (itemS.Length == 11)
                                        {
                                            SDT_DHN en = new SDT_DHN();
                                            en.DanhBo = itemS;
                                            en.HoTen = item[0].ToString().Trim();
                                            en.DienThoai = item[3].ToString().Trim();
                                            en.GhiChu = "P. KH";
                                            if (_cDHN.checkExists_DienThoai(en.DanhBo, en.DienThoai) == false)
                                                _cDHN.them_DienThoai(en);
                                        }
                                }
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnXem.PerformClick();
                        }
                    //chạy ngày 5/7/2022
                    //DataTable dt = CThuongVu._cDAL.ExecuteQuery_DataTable("select DanhBo,DienThoai from DonTu_ChiTiet where LEN(DienThoai)=10 and cast(createdate as date)>='20220311'"
                    //+ "union all select DanhBo,DienThoai from KTXM_ChiTiet where LEN(DienThoai)=10 and cast(createdate as date)>='20220311'");
                    //foreach (DataRow item in dt.Rows)
                    //    if (item["DanhBo"].ToString().Trim() != "" && _cDHN.checkExists_DienThoai(item["DanhBo"].ToString().Trim(), item["DienThoai"].ToString().Trim()) == false)
                    //    {
                    //        SDT_DHN en = new SDT_DHN();
                    //        en.DanhBo = item["DanhBo"].ToString().Trim();
                    //        en.DienThoai = item["DienThoai"].ToString().Trim();
                    //        en.HoTen = "";
                    //        //en.SoChinh = true;
                    //        en.GhiChu = "P. TV";
                    //        if (_cDHN.them_DienThoai(en) == true)
                    //        {
                    //        }
                    //        //error = item["DanhBo"].ToString();
                    //        //string[] DienThoais = item["DienThoai"].ToString().Split('-');
                    //        //foreach (string itemDT in DienThoais)
                    //        //{
                    //        //    if (itemDT.Trim() != "" && itemDT.Trim().Replace(".", "").Length == 10 && _cDHN.checkExists_DienThoai(item["DanhBo"].ToString(), itemDT.Trim()) == false)
                    //        //    {
                    //        //        SDT_DHN en = new SDT_DHN();
                    //        //        en.DanhBo = item["DanhBo"].ToString();
                    //        //        en.DienThoai = itemDT.Trim();
                    //        //        en.HoTen = "";
                    //        //        en.SoChinh = true;
                    //        //        en.GhiChu = "Đ. QLĐHN";
                    //        //        if (_cDHN.them_DienThoai(en) == true)
                    //        //        {
                    //        //        }
                    //        //    }
                    //        //}
                    //    }
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi, Vui lòng thử lại\n" + ex.Message + error, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkAmSau_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAmSau.Checked)
            {
                dateAmSau.Enabled = true;
                btnHinhAmSau.Enabled = true;
            }
            else
            {
                dateAmSau.Enabled = false;
                btnHinhAmSau.Enabled = false;
            }
        }

        private void chkXayDung_CheckedChanged(object sender, EventArgs e)
        {
            if (chkXayDung.Checked)
            {
                dateXayDung.Enabled = true;
                btnHinhXayDung.Enabled = true;
            }
            else
            {
                dateXayDung.Enabled = false;
                btnHinhXayDung.Enabled = false;
            }
        }

        private void chkDutChiGoc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDutChiGoc.Checked)
            {
                dateDutChiGoc.Enabled = true;
                btnHinhDutChiGoc.Enabled = true;
            }
            else
            {
                dateDutChiGoc.Enabled = false;
                btnHinhDutChiGoc.Enabled = false;
            }
        }

        private void chkDutChiThan_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDutChiThan.Checked)
            {
                dateDutChiThan.Enabled = true;
                btnHinhDutChiThan.Enabled = true;
            }
            else
            {
                dateDutChiThan.Enabled = false;
                btnHinhDutChiThan.Enabled = false;
            }
        }

        private void btnHinhAmSau_Click(object sender, EventArgs e)
        {
            if (_enDLKH != null)
                _cDocSo.viewImage(_cDocSo.imageToByteArray(_cDocSo.byteArrayToImage(_wsDHN.get_Hinh_MaHoa("AmSau", "", _enDLKH.DANHBO + ".jpg"))));
        }

        private void btnHinhXayDung_Click(object sender, EventArgs e)
        {
            if (_enDLKH != null)
                _cDocSo.viewImage(_cDocSo.imageToByteArray(_cDocSo.byteArrayToImage(_wsDHN.get_Hinh_MaHoa("XayDung", "", _enDLKH.DANHBO + ".jpg"))));
        }

        private void btnHinhDutChiGoc_Click(object sender, EventArgs e)
        {
            if (_enDLKH != null)
                _cDocSo.viewImage(_cDocSo.imageToByteArray(_cDocSo.byteArrayToImage(_wsDHN.get_Hinh_MaHoa("DutChi", "", _enDLKH.DANHBO + ".jpg"))));
        }

        private void btnHinhDutChiThan_Click(object sender, EventArgs e)
        {
            if (_enDLKH != null)
                _cDocSo.viewImage(_cDocSo.imageToByteArray(_cDocSo.byteArrayToImage(_wsDHN.get_Hinh_MaHoa("DutChi", "", _enDLKH.DANHBO + ".jpg"))));
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo.Text.Trim().Replace(" ", "").Replace("-", "").Length == 11)
                btnXem.PerformClick();
        }

        private void chkNgapNuoc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNgapNuoc.Checked)
            {
                dateNgapNuoc.Enabled = true;
                btnHinhNgapNuoc.Enabled = true;
            }
            else
            {
                dateNgapNuoc.Enabled = false;
                btnHinhNgapNuoc.Enabled = false;
            }
        }

        private void chkKetTuong_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKetTuong.Checked)
            {
                dateKetTuong.Enabled = true;
                btnHinhKetTuong.Enabled = true;
            }
            else
            {
                dateKetTuong.Enabled = false;
                btnHinhKetTuong.Enabled = false;
            }
        }

        private void chkLapKhoaGoc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLapKhoaGoc.Checked)
            {
                dateLapKhoaGoc.Enabled = true;
                btnHinhLapKhoaGoc.Enabled = true;
            }
            else
            {
                dateLapKhoaGoc.Enabled = false;
                btnHinhLapKhoaGoc.Enabled = false;
            }
        }

        private void chkBeHBV_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBeHBV.Checked)
            {
                dateBeHBV.Enabled = true;
                btnHinhBeHBV.Enabled = true;
            }
            else
            {
                dateBeHBV.Enabled = false;
                btnHinhBeHBV.Enabled = false;
            }
        }

        private void chkBeNapMatNapHBV_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBeNapMatNapHBV.Checked)
            {
                dateBeNapMatNapHBV.Enabled = true;
                btnHinhBeNapMatNapHBV.Enabled = true;
            }
            else
            {
                dateBeNapMatNapHBV.Enabled = false;
                btnHinhBeNapMatNapHBV.Enabled = false;
            }
        }

        private void btnHinhNgapNuoc_Click(object sender, EventArgs e)
        {
            if (_enDLKH != null)
                _cDocSo.viewImage(_cDocSo.imageToByteArray(_cDocSo.byteArrayToImage(_wsDHN.get_Hinh_MaHoa("NgapNuoc", "", _enDLKH.DANHBO + ".jpg"))));
        }

        private void btnHinhKetTuong_Click(object sender, EventArgs e)
        {
            if (_enDLKH != null)
                _cDocSo.viewImage(_cDocSo.imageToByteArray(_cDocSo.byteArrayToImage(_wsDHN.get_Hinh_MaHoa("KetTuong", "", _enDLKH.DANHBO + ".jpg"))));
        }

        private void btnHinhLapKhoaGoc_Click(object sender, EventArgs e)
        {
            if (_enDLKH != null)
                _cDocSo.viewImage(_cDocSo.imageToByteArray(_cDocSo.byteArrayToImage(_wsDHN.get_Hinh_MaHoa("LapKhoaGoc", "", _enDLKH.DANHBO + ".jpg"))));
        }

        private void btnHinhBeHBV_Click(object sender, EventArgs e)
        {
            if (_enDLKH != null)
                _cDocSo.viewImage(_cDocSo.imageToByteArray(_cDocSo.byteArrayToImage(_wsDHN.get_Hinh_MaHoa("BeHBV", "", _enDLKH.DANHBO + ".jpg"))));
        }

        private void btnHinhBeNapMatNapHBV_Click(object sender, EventArgs e)
        {
            if (_enDLKH != null)
                _cDocSo.viewImage(_cDocSo.imageToByteArray(_cDocSo.byteArrayToImage(_wsDHN.get_Hinh_MaHoa("BeNapMatNapHBV", "", _enDLKH.DANHBO + ".jpg"))));
        }

        private void chkGayTayVan_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGayTayVan.Checked)
            {
                dateGayTayVan.Enabled = true;
                btnHinhGayTayVan.Enabled = true;
            }
            else
            {
                dateGayTayVan.Enabled = false;
                btnHinhGayTayVan.Enabled = false;
            }
        }

        private void btnHinhGayTayVan_Click(object sender, EventArgs e)
        {
            if (_enDLKH != null)
                _cDocSo.viewImage(_cDocSo.imageToByteArray(_cDocSo.byteArrayToImage(_wsDHN.get_Hinh_MaHoa("GayTayVan", "", _enDLKH.DANHBO + ".jpg"))));
        }

        private void chkTroNgaiThay_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTroNgaiThay.Checked)
            {
                dateTroNgaiThay.Enabled = true;
                btnHinhTroNgaiThay.Enabled = true;
            }
            else
            {
                dateTroNgaiThay.Enabled = false;
                btnHinhTroNgaiThay.Enabled = false;
            }
        }

        private void btnHinhTroNgaiThay_Click(object sender, EventArgs e)
        {
            if (_enDLKH != null)
                _cDocSo.viewImage(_cDocSo.imageToByteArray(_cDocSo.byteArrayToImage(_wsDHN.get_Hinh_MaHoa("TroNgaiThay", "", _enDLKH.DANHBO + ".jpg"))));
        }

        private void chkDauChungMayBom_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDauChungMayBom.Checked)
            {
                dateDauChungMayBom.Enabled = true;
                btnHinhDauChungMayBom.Enabled = true;
            }
            else
            {
                dateDauChungMayBom.Enabled = false;
                btnHinhDauChungMayBom.Enabled = false;
            }
        }

        private void btnHinhDauChungMayBom_Click(object sender, EventArgs e)
        {
            if (_enDLKH != null)
                _cDocSo.viewImage(_cDocSo.imageToByteArray(_cDocSo.byteArrayToImage(_wsDHN.get_Hinh_MaHoa("DauChungMayBom", "", _enDLKH.DANHBO + ".jpg"))));
        }

        private void dgvPhieuChuyen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvPhieuChuyen.Columns[e.ColumnIndex].Name == "XemHinh")
                {
                    _cTo.viewImage(_cTo.imageToByteArray(_cTo.byteArrayToImage(_wsDHN.get_Hinh_MaHoa(dgvPhieuChuyen["Folder", e.RowIndex].Value.ToString(), "", dgvPhieuChuyen["DanhBo_PC", e.RowIndex].Value.ToString() + ".jpg"))));
                }
            }
            catch
            {
            }
        }

        private void dgvPhieuChuyen_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (dgvPhieuChuyen.Columns[e.ColumnIndex].Name == "TinhTrang")
                    {
                        if (CPhieuChuyen._cDAL.ExecuteNonQuery("update MaHoa_PhieuChuyen_LichSu set TinhTrang=N'" + dgvPhieuChuyen["TinhTrang", e.RowIndex].Value.ToString() + "' where ID=" + dgvPhieuChuyen["ID", e.RowIndex].Value.ToString()))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


    }
}
