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

namespace ThuTien.GUI.TongHop
{
    public partial class frmChuyenNoKhoDoi : Form
    {
        string _mnu = "mnuChuyenNoKhoDoi";
        CHoaDon _cHoaDon = new CHoaDon();
        CChuyenNoKhoDoi _cCNKD = new CChuyenNoKhoDoi();
        CLenhHuy _cLenhHuy = new CLenhHuy();
        CDCHD _cDCHD = new CDCHD();

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
                    if (!string.IsNullOrEmpty(item.Trim().ToUpper()) && item.ToString().Length == 13 && lstHD.FindItemWithText(item.Trim().ToUpper()) == null)
                    {
                        lstHD.Items.Add(item.Trim().ToUpper());
                        lstHD.EnsureVisible(lstHD.Items.Count - 1);
                    }
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
                foreach (ListViewItem item in lstHD.Items)
                {
                    if (!_cHoaDon.CheckExist(item.Text))
                    {
                        MessageBox.Show("Hóa Đơn sai: " + item.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        item.Selected = true;
                        item.Focused = true;
                        return;
                    }
                    if (_cCNKD.CheckExistCT(item.ToString()))
                    {
                        MessageBox.Show("Hóa Đơn đã có trong Chuyển Nợ Khó Đòi: " + item.Text, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        item.Selected = true;
                        item.Focused = true;
                        return;
                    }
                    lstHDTemp.Add(_cHoaDon.Get(item.Text));
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
                            if (_cCNKD.CountCT(ctcnkd.MaCNKD) == 0)
                                _cCNKD.Xoa(ctcnkd.MaCNKD);
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
            dgvHoaDon.DataSource = _cCNKD.GetDSCT(dateTu.Value, dateDen.Value);
            foreach (DataGridViewRow item in dgvHoaDon.Rows)
                if (_cDCHD.CheckExist_ChuanThu(item.Cells["SoHoaDon"].Value.ToString()))
                {
                    DIEUCHINH_HD dchd = _cDCHD.Get(item.Cells["SoHoaDon"].Value.ToString());
                    item.Cells["TongCong"].Value = dchd.TONGCONG_BD;
                }
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "MaCNKD" && e.Value.ToString().Length>2)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length-2, "-");
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
            if (!string.IsNullOrEmpty(dgvHoaDon.SelectedRows[0].Cells["MaCNKD"].Value.ToString()))
            {
                TT_ChuyenNoKhoDoi cnkd = _cCNKD.Get(decimal.Parse(dgvHoaDon.SelectedRows[0].Cells["MaCNKD"].Value.ToString()));
                DataTable dt = _cCNKD.GetDSCT(decimal.Parse(dgvHoaDon.SelectedRows[0].Cells["MaCNKD"].Value.ToString()));
                
                dsBaoCao ds = new dsBaoCao();
                foreach (DataRow item in dt.Rows)
                {
                    DataRow dr = ds.Tables["TongHopNo"].NewRow();
                    dr["SoPhieu"] = item["MaCNKD"].ToString().Insert(item["MaCNKD"].ToString().Length - 2, "-");
                    dr["DanhBo"] = cnkd.DanhBo.Insert(4, " ").Insert(8, " ");
                    dr["HoTen"] = cnkd.HoTen;
                    dr["DiaChi"] = cnkd.DiaChi;
                    if (cnkd.SoPhieuYCCHDB!=null)
                        dr["SoPhieuYCCHDB"] = cnkd.SoPhieuYCCHDB.Value.ToString().Insert(cnkd.SoPhieuYCCHDB.Value.ToString().Length - 2, "-");
                    if (cnkd.NgayYCCHDB != null)
                        dr["NgayYCCHDB"] = cnkd.NgayYCCHDB.Value.ToString("dd/MM/yyyy");
                    dr["Ky"] = item["Ky"];
                    dr["SoPhatHanh"] = item["SoPhatHanh"];
                    dr["TieuThu"] = item["TieuThu"];
                    if (_cDCHD.CheckExist_ChuanThu(item["SoHoaDon"].ToString()))
                    {
                        DIEUCHINH_HD dchd = _cDCHD.Get(item["SoHoaDon"].ToString());
                        dr["GiaBan"] = dchd.GIABAN_BD;
                        dr["ThueGTGT"] =  dchd.THUE_BD;
                        dr["PhiBVMT"] = dchd.PHI_BD;
                    }
                    else
                    {
                        dr["GiaBan"] = item["GiaBan"];
                        dr["ThueGTGT"] = item["ThueGTGT"];
                        dr["PhiBVMT"] = item["PhiBVMT"];
                    }
                    ds.Tables["TongHopNo"].Rows.Add(dr);
                }

                rptChuyenNoKhoDoi rpt = new rptChuyenNoKhoDoi();
                rpt.SetDataSource(ds);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.Show();
            }
        }

        private void dgvHoaDon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvHoaDon.RowCount > 0)
            {
                frmShowChuyenNoKhoDoi frm = new frmShowChuyenNoKhoDoi(dgvHoaDon.CurrentRow.Cells["DanhBo"].Value.ToString(), decimal.Parse(dgvHoaDon.CurrentRow.Cells["MaCNKD"].Value.ToString()));
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
    }
}
