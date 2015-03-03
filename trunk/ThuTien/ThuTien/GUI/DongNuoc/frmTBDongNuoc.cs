﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.LinQ;
using ThuTien.DAL.Doi;
using ThuTien.DAL.DongNuoc;
using ThuTien.DAL.QuanTri;
using ThuTien.BaoCao;
using ThuTien.BaoCao.DongNuoc;
using KTKS_DonKH.GUI.BaoCao;
using System.Globalization;

namespace ThuTien.GUI.DongNuoc
{
    public partial class frmTBDongNuoc : Form
    {
        string _mnu = "mnuTBDongNuoc";
        CHoaDon _cHoaDon = new CHoaDon();
        CDongNuoc _cDongNuoc = new CDongNuoc();

        public frmTBDongNuoc()
        {
            InitializeComponent();
        }

        private void frmLenhDongNuoc_Load(object sender, EventArgs e)
        {
            gridControl.LevelTree.Nodes.Add("Chi Tiết Đóng Nước", gridViewCTDN);
        }

        private void txtSoHoaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtSoHoaDon.Text.Trim()))
                if (!lstHD.Items.Contains(txtSoHoaDon.Text.Trim()))
                {
                    lstHD.Items.Add(txtSoHoaDon.Text.Trim());
                    txtSoHoaDon.Text = "";
                }
                else
                    txtSoHoaDon.Text = "";
        }

        private void lstHD_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstHD.Items.Count > 0)
                lstHD.Items.RemoveAt(lstHD.SelectedIndex);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                List<HOADON> lstHDTemp = new List<HOADON>();
                foreach (var item in lstHD.Items)
                {
                    if (_cHoaDon.CheckDangNganBySoHoaDon(item.ToString()))
                    {
                        MessageBox.Show("Hóa Đơn đã Đăng Ngân: " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lstHD.SelectedItem = item;
                        return;
                    }
                    lstHDTemp.Add(_cHoaDon.GetBySoHoaDon(item.ToString()));
                }

                try
                {
                    _cHoaDon.BeginTransaction();
                    while (lstHDTemp.Count > 0)
                    {
                        TT_DongNuoc dongnuoc = new TT_DongNuoc();
                        dongnuoc.DanhBo = lstHDTemp[0].DANHBA;
                        dongnuoc.HoTen = lstHDTemp[0].TENKH;
                        dongnuoc.DiaChi = lstHDTemp[0].SO + " " + lstHDTemp[0].DUONG;
                        dongnuoc.MLT = lstHDTemp[0].MALOTRINH;

                        TT_CTDongNuoc ctdongnuoc = new TT_CTDongNuoc();
                        ctdongnuoc.MaDN = dongnuoc.MaDN;
                        ctdongnuoc.MaHD = lstHDTemp[0].ID_HOADON;
                        ctdongnuoc.SoHoaDon = lstHDTemp[0].SOHOADON;
                        ctdongnuoc.Ky = lstHDTemp[0].KY + "/" + lstHDTemp[0].NAM;
                        ctdongnuoc.TieuThu=(int)lstHDTemp[0].TIEUTHU;
                        ctdongnuoc.GiaBan = lstHDTemp[0].GIABAN;
                        ctdongnuoc.ThueGTGT = lstHDTemp[0].THUE;
                        ctdongnuoc.PhiBVMT = lstHDTemp[0].PHI;
                        ctdongnuoc.TongCong = lstHDTemp[0].TONGCONG;

                        dongnuoc.TT_CTDongNuocs.Add(ctdongnuoc);

                        int k = -1;
                        for (int j = 1; j < lstHDTemp.Count; j++)
                            if (lstHDTemp[0].DANHBA == lstHDTemp[j].DANHBA)
                            {
                                k = j;
                                TT_CTDongNuoc ctdongnuoc2 = new TT_CTDongNuoc();
                                ctdongnuoc2.MaDN = dongnuoc.MaDN;
                                ctdongnuoc2.MaHD = lstHDTemp[j].ID_HOADON;
                                ctdongnuoc2.SoHoaDon = lstHDTemp[j].SOHOADON;
                                ctdongnuoc2.Ky = lstHDTemp[j].KY + "/" + lstHDTemp[j].NAM;
                                ctdongnuoc2.TieuThu = (int)lstHDTemp[j].TIEUTHU;
                                ctdongnuoc2.GiaBan = lstHDTemp[j].GIABAN;
                                ctdongnuoc2.ThueGTGT = lstHDTemp[j].THUE;
                                ctdongnuoc2.PhiBVMT = lstHDTemp[j].PHI;
                                ctdongnuoc2.TongCong = lstHDTemp[j].TONGCONG;

                                dongnuoc.TT_CTDongNuocs.Add(ctdongnuoc2);
                            }
                        if (_cDongNuoc.Them(dongnuoc))
                        {
                            if (k != -1)
                                lstHDTemp.RemoveAt(k);
                            lstHDTemp.RemoveAt(0);
                        }
                    }
                    _cHoaDon.CommitTransaction();
                    lstHD.Items.Clear();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    _cHoaDon.Rollback();
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                try
                {
                    _cDongNuoc.SqlBeginTransaction();

                    for (int i = 0; i < gridViewDN.SelectedRowsCount; i++)
                        if (gridViewDN.GetSelectedRows()[i] >= 0)
                            if (!_cDongNuoc.CheckKQDongNuocByMaDN(decimal.Parse(gridViewDN.GetDataRow(gridViewDN.GetSelectedRows()[i])["MaDN"].ToString())))
                                if (!_cDongNuoc.Xoa(decimal.Parse(gridViewDN.GetDataRow(gridViewDN.GetSelectedRows()[i])["MaDN"].ToString())))
                                {
                                    _cHoaDon.SqlRollbackTransaction();
                                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                    _cDongNuoc.SqlCommitTransaction();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    _cHoaDon.SqlRollbackTransaction();
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dateTu.Value <= dateDen.Value)
            {
                gridControl.DataSource = _cDongNuoc.GetDSByDates(CNguoiDung.MaND,dateTu.Value, dateDen.Value).Tables["DongNuoc"];
            }
        }

        private void btnInTB_Click(object sender, EventArgs e)
        {
            dsBaoCao dsBaoCao = new dsBaoCao();
            DataTable dt = ((DataTable)gridControl.DataSource).DefaultView.Table;
            foreach (DataRow item in dt.Rows)
                if (bool.Parse(item["In"].ToString()))
                {
                    DataRow[] childRows = item.GetChildRows("Chi Tiết Đóng Nước");
                    string Ky = "";
                    foreach (DataRow itemChild in childRows)
                    {
                        Ky += itemChild["Ky"] + "  Số tiền: " + String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", itemChild["TongCong"]) +"\n";
                    }

                    DataRow dr = dsBaoCao.Tables["TBDongNuoc"].NewRow();
                    dr["MaDN"] = item["MaDN"];
                    dr["HoTen"] = item["HoTen"];
                    dr["DiaChi"] = item["DiaChi"];
                    if (!string.IsNullOrEmpty(item["DanhBo"].ToString()))
                        dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                    dr["MLT"] = item["MLT"];
                    dr["Ky"] = Ky;
                    dsBaoCao.Tables["TBDongNuoc"].Rows.Add(dr);

                    rptTBDongNuoc rpt = new rptTBDongNuoc();
                    rpt.SetDataSource(dsBaoCao);
                    frmBaoCao frm = new frmBaoCao(rpt);
                    frm.ShowDialog();
                }
        }

        private void gridViewCTDN_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "TieuThu" && e.Value != null)
            {
                e.DisplayText = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (e.Column.FieldName == "GiaBan" && e.Value != null)
            {
                e.DisplayText = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (e.Column.FieldName == "ThueGTGT" && e.Value != null)
            {
                e.DisplayText = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (e.Column.FieldName == "PhiBVMT" && e.Value != null)
            {
                e.DisplayText = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (e.Column.FieldName == "TongCong" && e.Value != null)
            {
                e.DisplayText = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void gridViewDN_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "MaDN" && e.Value != null)
            {
                e.DisplayText = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

       
 
    }
}
