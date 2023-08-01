using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.DAL.TongHop;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;
using ThuTien.BaoCao;
using ThuTien.BaoCao.TongHop;
using ThuTien.GUI.BaoCao;
using ThuTien.DAL.Quay;
using System.Globalization;
using ThuTien.DAL;

namespace ThuTien.GUI.TongHop
{
    public partial class frmChuyenNoKhoDoi : Form
    {
        string _mnu = "mnuChuyenNoKhoDoi";
        CHoaDon _cHoaDon = new CHoaDon();
        CChuyenNoKhoDoi _cCNKD = new CChuyenNoKhoDoi();
        CLenhHuy _cLenhHuy = new CLenhHuy();
        CDCHD _cDCHD = new CDCHD();
        wrThuTien.wsThuTien _wsThuTien = new wrThuTien.wsThuTien();

        public frmChuyenNoKhoDoi()
        {
            InitializeComponent();
        }

        private void frmChuyenNoKhoDoi_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;

            dateDen.Value = DateTime.Now;
        }

        private void txtSoHoaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtSoHoaDon.Text.Trim()))
            {
                foreach (string item in txtSoHoaDon.Lines)
                    if (!string.IsNullOrEmpty(item.Trim().ToUpper()))
                    {
                        if (lstHD.FindItemWithText(item.Trim().ToUpper()) == null)
                        {
                            lstHD.Items.Add(item.Trim().ToUpper());
                            lstHD.EnsureVisible(lstHD.Items.Count - 1);
                        }
                    }
                //else
                //    ///Trung An thêm 'K' phía cuối liên hóa đơn
                //    if (!string.IsNullOrEmpty(item.Trim().ToUpper()) && item.ToString().Length == 14)
                //    {
                //        if (lstHD.FindItemWithText(item.Trim().ToUpper().Replace("K", "")) == null)
                //        {
                //            lstHD.Items.Add(item.Trim().ToUpper().Replace("K", ""));
                //            lstHD.EnsureVisible(lstHD.Items.Count - 1);
                //        }
                //    }
                txtSoLuong.Text = lstHD.Items.Count.ToString();
                txtSoHoaDon.Text = "";
            }
        }

        private void lstHD_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstHD.Items.Count > 0 && e.Button == MouseButtons.Left)
            {
                foreach (ListViewItem item in lstHD.SelectedItems)
                {
                    lstHD.Items.Remove(item);
                }
                txtSoLuong.Text = lstHD.Items.Count.ToString();
            }
        }

        private void lstHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSoLuong.Text = lstHD.Items.Count.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                List<HOADON> lstHDTemp = new List<HOADON>();
                //insert from list
                if (dgvHoaDon_Chon.Rows.Count == 0)
                    foreach (ListViewItem item in lstHD.Items)
                    {
                        if (!_cHoaDon.CheckExist(item.Text))
                        {
                            MessageBox.Show("Hóa Đơn sai: " + item.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            item.Selected = true;
                            item.Focused = true;
                            return;
                        }
                        if (_cCNKD.CheckExistCT(item.Text))
                        {
                            MessageBox.Show("Hóa Đơn đã có trong Chuyển Nợ Khó Đòi: " + item.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            item.Selected = true;
                            item.Focused = true;
                            return;
                        }
                        lstHDTemp.Add(_cHoaDon.Get(item.Text));
                    }
                //insert from datagridview
                else
                    foreach (DataGridViewRow item in dgvHoaDon_Chon.Rows)
                    {
                        if (_cCNKD.CheckExistCT(item.Cells["SoHoaDon_Chon"].ToString()))
                        {
                            MessageBox.Show("Hóa Đơn đã có trong Chuyển Nợ Khó Đòi: " + item.Cells["SoHoaDon_Chon"].Value.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        lstHDTemp.Add(_cHoaDon.Get(item.Cells["SoHoaDon_Chon"].Value.ToString()));
                    }
                try
                {
                    _cCNKD.BeginTransaction();
                    while (lstHDTemp.Count > 0)
                    {
                        TT_ChuyenNoKhoDoi cnkd = new TT_ChuyenNoKhoDoi();
                        cnkd.DanhBo = lstHDTemp[0].DANHBA;
                        cnkd.HoTen = lstHDTemp[0].TENKH;
                        cnkd.DiaChi = lstHDTemp[0].SO + " " + lstHDTemp[0].DUONG;

                        TT_CTChuyenNoKhoDoi ctcnkd = new TT_CTChuyenNoKhoDoi();
                        ctcnkd.MaCNKD = cnkd.MaCNKD;
                        ctcnkd.MaHD = lstHDTemp[0].ID_HOADON;
                        ctcnkd.SoHoaDon = lstHDTemp[0].SOHOADON;
                        ctcnkd.CreateBy = CNguoiDung.MaND;
                        ctcnkd.CreateDate = DateTime.Now;

                        cnkd.TT_CTChuyenNoKhoDois.Add(ctcnkd);
                        _cHoaDon.ChuyenNoKhoDoi(ctcnkd.SoHoaDon);

                        for (int j = 1; j < lstHDTemp.Count; j++)
                            if (lstHDTemp[0].DANHBA == lstHDTemp[j].DANHBA)
                            {
                                TT_CTChuyenNoKhoDoi ctcnkd2 = new TT_CTChuyenNoKhoDoi();
                                ctcnkd2.MaCNKD = cnkd.MaCNKD;
                                ctcnkd2.MaHD = lstHDTemp[j].ID_HOADON;
                                ctcnkd2.SoHoaDon = lstHDTemp[j].SOHOADON;
                                ctcnkd2.CreateBy = CNguoiDung.MaND;
                                ctcnkd2.CreateDate = DateTime.Now;

                                cnkd.TT_CTChuyenNoKhoDois.Add(ctcnkd2);
                                _cHoaDon.ChuyenNoKhoDoi(ctcnkd2.SoHoaDon);
                            }

                        if (_cCNKD.Them(cnkd))
                        {
                            //foreach (TT_CTChuyenNoKhoDoi item in cnkd.TT_CTChuyenNoKhoDois.ToList())
                            //{
                            //    if (_cLenhHuy.CheckExist(item.SoHoaDon))
                            //        if (!_cLenhHuy.Xoa(item.SoHoaDon))
                            //        {
                            //            _cCNKD.Rollback();
                            //            MessageBox.Show("Lỗi Xóa Lệnh Hủy, Vui lòng thử lại \r\n" + item.SoHoaDon, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //            return;
                            //        }
                            //}
                            for (int i = lstHDTemp.Count - 1; i >= 0; i--)
                                if (lstHDTemp[i].DANHBA == cnkd.DanhBo)
                                {
                                    lstHDTemp.RemoveAt(i);
                                }
                        }
                    }
                    _cCNKD.CommitTransaction();
                    lstHD.Items.Clear();
                    dgvHoaDon_Chon.DataSource = null;
                    btnXem.PerformClick();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    _cCNKD.Rollback();
                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        //_cCNKD.BeginTransaction();
                        foreach (DataGridViewRow item in dgvHoaDon.SelectedRows)
                        {
                            TT_CTChuyenNoKhoDoi ctcnkd = _cCNKD.GetCT(item.Cells["SoHoaDon"].Value.ToString());
                            if (_cCNKD.XoaCT(ctcnkd))
                            {
                                if (!_cHoaDon.XoaChuyenNoKhoDoi(item.Cells["SoHoaDon"].Value.ToString()))
                                {
                                    //_cCNKD.SqlRollbackTransaction();
                                    MessageBox.Show("Lỗi Cập Nhật Hóa Đơn Chuyển Nợ Khó Đòi, Vui lòng thử lại \r\n" + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            else
                            {
                                //_cCNKD.Rollback();
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            _cCNKD.CountCT(ctcnkd.MaCNKD);
                            //_cCNKD.Xoa(ctcnkd.MaCNKD);
                        }
                        //_cCNKD.CommitTransaction();
                        lstHD.Items.Clear();
                        btnXem.PerformClick();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        //_cCNKD.Rollback();
                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvHoaDon.DataSource = _cCNKD.getDS_ChiTitet(dateTu.Value, dateDen.Value);
            int TongCong = 0;
            foreach (DataGridViewRow item in dgvHoaDon.Rows)
            {
                if (_cDCHD.CheckExist_ChuanThu(int.Parse(item.Cells["MaHD"].Value.ToString())))
                {
                    DIEUCHINH_HD dchd = _cDCHD.Get(int.Parse(item.Cells["MaHD"].Value.ToString()));
                    item.Cells["TongCong"].Value = dchd.TONGCONG_BD;
                }
                TongCong += int.Parse(item.Cells["TongCong"].Value.ToString());
            }
            txtTongHD.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", dgvHoaDon.RowCount);
            txtTongCong.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "MLT" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(2, " ");
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "MaCNKD" && e.Value.ToString().Length > 2)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void dgvHoaDon_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHoaDon.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvHoaDon.SelectedRows)
                if (!string.IsNullOrEmpty(item.Cells["MaCNKD"].Value.ToString()) && ds.Tables["TongHopNo"].AsEnumerable().Any(itemL => itemL.Field<String>("DanhBo").Replace(" ", "") == item.Cells["DanhBo"].Value.ToString()) == false)
                {
                    TT_ChuyenNoKhoDoi cnkd = _cCNKD.Get(decimal.Parse(item.Cells["MaCNKD"].Value.ToString()));
                    DataTable dt = _cCNKD.GetDSCT(decimal.Parse(item.Cells["MaCNKD"].Value.ToString()));


                    foreach (DataRow itemC in dt.Rows)
                    {
                        DataRow dr = ds.Tables["TongHopNo"].NewRow();
                        dr["SoPhieu"] = itemC["MaCNKD"].ToString().Insert(itemC["MaCNKD"].ToString().Length - 2, "-");
                        dr["DanhBo"] = cnkd.DanhBo.Insert(4, " ").Insert(8, " ");
                        dr["HoTen"] = cnkd.HoTen;
                        dr["DiaChi"] = cnkd.DiaChi;
                        if (cnkd.SoPhieuYCCHDB != null)
                            dr["SoPhieuYCCHDB"] = cnkd.SoPhieuYCCHDB.Value.ToString().Insert(cnkd.SoPhieuYCCHDB.Value.ToString().Length - 2, "-");
                        if (cnkd.NgayYCCHDB != null)
                            dr["NgayYCCHDB"] = cnkd.NgayYCCHDB.Value.ToString("dd/MM/yyyy");
                        if (cnkd.LyDo != null)
                            dr["LyDo"] = cnkd.LyDo;
                        dr["Ky"] = itemC["KyHD"];
                        dr["SoPhatHanh"] = itemC["SoPhatHanh"];
                        dr["TieuThu"] = itemC["TieuThu"];
                        if (_cDCHD.CheckExist_ChuanThu(int.Parse(itemC["MaHD"].ToString())))
                        {
                            CThuongVu _cKinhDoanh = new CThuongVu();
                            DataTable dtDC = _cKinhDoanh.getTong_HoaDon(cnkd.DanhBo, int.Parse(itemC["Nam"].ToString()), int.Parse(itemC["Ky"].ToString()));
                            dr["GiaBan"] = int.Parse(itemC["GiaBan"].ToString()) - int.Parse(dtDC.Rows[0]["GiaBan"].ToString());
                            dr["ThueGTGT"] = int.Parse(itemC["ThueGTGT"].ToString()) - int.Parse(dtDC.Rows[0]["ThueGTGT"].ToString());
                            dr["PhiBVMT"] = int.Parse(itemC["PhiBVMT"].ToString()) - int.Parse(dtDC.Rows[0]["PhiBVMT"].ToString());
                            if (dtDC.Rows[0]["PhiBVMT_Thue"].ToString() != "")
                                dr["PhiBVMT_Thue"] = int.Parse(itemC["PhiBVMT_Thue"].ToString()) - int.Parse(dtDC.Rows[0]["PhiBVMT_Thue"].ToString());
                            else
                                dr["PhiBVMT_Thue"] = int.Parse(itemC["PhiBVMT_Thue"].ToString()) - 0;
                            dr["TongCong"] = int.Parse(itemC["TongCong"].ToString()) - int.Parse(dtDC.Rows[0]["TongCong"].ToString());
                            //DIEUCHINH_HD dchd = _cDCHD.Get(int.Parse(itemC["MaHD"].ToString()));
                            //dr["GiaBan"] = dchd.GIABAN_BD;
                            //dr["ThueGTGT"] = dchd.THUE_BD;
                            //dr["PhiBVMT"] = dchd.PHI_BD;
                            //dr["PhiBVMT_Thue"] = dchd.PHI_Thue_BD == null ? 0 : dchd.PHI_Thue_BD;
                            //dr["TongCong"] = dchd.TONGCONG_BD;
                        }
                        else
                        {
                            dr["GiaBan"] = itemC["GiaBan"];
                            dr["ThueGTGT"] = itemC["ThueGTGT"];
                            dr["PhiBVMT"] = itemC["PhiBVMT"];
                            dr["PhiBVMT_Thue"] = itemC["PhiBVMT_Thue"];
                            dr["TongCong"] = itemC["TongCong"];
                        }
                        ds.Tables["TongHopNo"].Rows.Add(dr);
                    }
                }
            rptChuyenNoKhoDoi rpt = new rptChuyenNoKhoDoi();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void dgvHoaDon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvHoaDon.RowCount > 0)
            {
                frmShowChuyenNoKhoDoi frm = new frmShowChuyenNoKhoDoi(dgvHoaDon.CurrentRow.Cells["DanhBo"].Value.ToString(), decimal.Parse(dgvHoaDon.CurrentRow.Cells["MaCNKD"].Value.ToString()), int.Parse(dgvHoaDon.CurrentRow.Cells["MaHD"].Value.ToString()));
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    btnXem.PerformClick();
            }
        }

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            string str = "";
            foreach (ListViewItem item in lstHD.Items)
            {
                str += item.Text + "\n";
            }
            Clipboard.SetText(str);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo.Text.Trim() != "")
            {
                dgvHoaDon_Chon.DataSource = _cHoaDon.GetDSTonByDanhBo(txtDanhBo.Text.Trim());
            }
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvHoaDon.Columns[e.ColumnIndex].Name == "File_Xem")
                {
                    byte[] file = _wsThuTien.get_Hinh_ThuTien("CNKD", dgvHoaDon.CurrentRow.Cells["MaCNKD"].Value.ToString(), dgvHoaDon.CurrentRow.Cells["DanhBo"].Value.ToString() + ".pdf");
                    if (file != null)
                        _cCNKD.viewPDF(file);
                    else
                        MessageBox.Show("Lỗi File", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    if (dgvHoaDon.Columns[e.ColumnIndex].Name == "File_Them")
                    {
                        OpenFileDialog dialog = new OpenFileDialog();
                        dialog.Filter = "PDF files (*.pdf) | *.pdf";
                        dialog.Multiselect = false;
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            byte[] bytes = _cCNKD.scanVanBan(dialog.FileName);
                            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                            {
                                if (_wsThuTien.ghi_Hinh_ThuTien("CNKD", dgvHoaDon.CurrentRow.Cells["MaCNKD"].Value.ToString(), dgvHoaDon.CurrentRow.Cells["DanhBo"].Value.ToString() + ".pdf", bytes) == true)
                                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
