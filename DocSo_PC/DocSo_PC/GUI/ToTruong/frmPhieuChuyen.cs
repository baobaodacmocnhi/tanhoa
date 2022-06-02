﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.QuanTri;
using DocSo_PC.LinQ;
using DocSo_PC.DAL;
using DocSo_PC.BaoCao;
using DocSo_PC.BaoCao.ToTruong;
using DocSo_PC.GUI.BaoCao;
using DocSo_PC.DAL.Doi;

namespace DocSo_PC.GUI.ToTruong
{
    public partial class frmPhieuChuyen : Form
    {
        CTo _cTo = new CTo();
        CDHN _cDHN = new CDHN();
        CDocSo _cDocSo = new CDocSo();
        wrDHN.wsDHN _wsDHN = new wrDHN.wsDHN();

        public frmPhieuChuyen()
        {
            InitializeComponent();
        }

        private void frmPhieuChuyen_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
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
            }
            else
            {
                lbTo.Text = "Tổ  " + CNguoiDung.TenTo;
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = _cDHN.getDS_AmSau_XayDung(dateTuNgay.Value, dateDenNgay.Value);
        }

        private void dgvDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDanhSach.Columns[e.ColumnIndex].Name == "XemHinh")
                {
                    _cTo.LoadImageView(_cTo.imageToByteArray(_cTo.byteArrayToImage(_wsDHN.get_Hinh_MaHoa(dgvDanhSach["Folder", e.RowIndex].Value.ToString(), "", dgvDanhSach["DanhBo", e.RowIndex].Value.ToString() + ".jpg"))));
                }
            }
            catch
            {
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            dsBaoCao dsBaoCao = new dsBaoCao();
            foreach (DataGridViewRow item in dgvDanhSach.Rows)
            {
                TB_DULIEUKHACHHANG ttkh = _cDHN.get(item.Cells["DanhBo"].Value.ToString());
                if (ttkh != null)
                {
                    DataRow dr = dsBaoCao.Tables["BaoCao"].NewRow();
                    dr["TenPhong"] = CNguoiDung.TenPhong;
                    switch (item.Cells["NoiDung"].Value.ToString())
                    {
                        case "Âm Sâu":
                            if (ttkh.ViTriDHN_Ngoai)
                                dr["TieuDe"] = "DANH SÁCH ĐỒNG HỒ NƯỚC " + item.Cells["NoiDung"].Value.ToString().ToUpper() + " NGOÀI BẤT ĐỘNG SẢN";
                            else
                                dr["TieuDe"] = "DANH SÁCH ĐỒNG HỒ NƯỚC " + item.Cells["NoiDung"].Value.ToString().ToUpper() + " TRONG BẤT ĐỘNG SẢN";
                            break;
                        default:
                            dr["TieuDe"] = "DANH SÁCH ĐỒNG HỒ NƯỚC " + item.Cells["NoiDung"].Value.ToString().ToUpper();
                            break;
                    }
                    dr["DanhBo"] = ttkh.DANHBO.Insert(7, " ").Insert(4, " ");
                    dr["MLT"] = ttkh.LOTRINH;
                    dr["HoTen"] = ttkh.HOTEN;
                    dr["DiaChi"] = ttkh.SONHA + " " + ttkh.TENDUONG;
                    dr["Hieu"] = ttkh.HIEUDH;
                    dr["Co"] = ttkh.CODH;
                    dr["SoThan"] = ttkh.SOTHANDH;
                    dr["ViTri"] = ttkh.VITRIDHN;
                    DocSo docso = _cDocSo.get_DocSo_MoiNhat(ttkh.DANHBO);
                    dr["ChiSo"] = docso.CSMoi;
                    dr["TieuThu"] = docso.TieuThuMoi;
                    dr["ChucVu"] = CNguoiDung.ChucVu.ToUpper();
                    dr["NguoiKy"] = CNguoiDung.NguoiKy.ToUpper();
                    dsBaoCao.Tables["BaoCao"].Rows.Add(dr);
                }
            }
            rptDSPhieuChuyen rpt = new rptDSPhieuChuyen();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }
    }
}
