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
            cmbLoai.SelectedIndex = 0;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            switch (cmbLoai.SelectedItem.ToString())
            {
                case "Âm Sâu":
                    if (CNguoiDung.Doi)
                    {
                        if (cmbTo.SelectedIndex == 0)
                            dgvDanhSach.DataSource = _cDHN.getDS_AmSau(dateTuNgay.Value, dateDenNgay.Value);
                        else
                            dgvDanhSach.DataSource = _cDHN.getDS_AmSau(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value);
                    }
                    else
                    {
                        dgvDanhSach.DataSource = _cDHN.getDS_AmSau(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value);
                    }
                    break;
                case "Xây Dựng":
                    if (CNguoiDung.Doi)
                    {
                        if (cmbTo.SelectedIndex == 0)
                            dgvDanhSach.DataSource = _cDHN.getDS_XayDung(dateTuNgay.Value, dateDenNgay.Value);
                        else
                            dgvDanhSach.DataSource = _cDHN.getDS_XayDung(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value);
                    }
                    else
                    {
                        dgvDanhSach.DataSource = _cDHN.getDS_XayDung(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value);
                    }
                    break;
                case "Đứt Chì Góc":
                    if (CNguoiDung.Doi)
                    {
                        if (cmbTo.SelectedIndex == 0)
                            dgvDanhSach.DataSource = _cDHN.getDS_DutChiGoc(dateTuNgay.Value, dateDenNgay.Value);
                        else
                            dgvDanhSach.DataSource = _cDHN.getDS_DutChiGoc(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value);
                    }
                    else
                    {
                        dgvDanhSach.DataSource = _cDHN.getDS_DutChiGoc(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value);
                    }
                    break;
                case "Đứt Chì Thân":
                    if (CNguoiDung.Doi)
                    {
                        if (cmbTo.SelectedIndex == 0)
                            dgvDanhSach.DataSource = _cDHN.getDS_DutChiThan(dateTuNgay.Value, dateDenNgay.Value);
                        else
                            dgvDanhSach.DataSource = _cDHN.getDS_DutChiThan(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value);
                    }
                    else
                    {
                        dgvDanhSach.DataSource = _cDHN.getDS_DutChiThan(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value);
                    }
                    break;
                default:
                    DataTable dt = new DataTable();
                    if (CNguoiDung.Doi)
                    {
                        if (cmbTo.SelectedIndex == 0)
                        {
                            dt.Merge(_cDHN.getDS_AmSau(dateTuNgay.Value, dateDenNgay.Value));
                            dt.Merge(_cDHN.getDS_XayDung(dateTuNgay.Value, dateDenNgay.Value));
                            dt.Merge(_cDHN.getDS_DutChiGoc(dateTuNgay.Value, dateDenNgay.Value));
                            dt.Merge(_cDHN.getDS_DutChiThan(dateTuNgay.Value, dateDenNgay.Value));
                        }
                        else
                        {
                            dt.Merge(_cDHN.getDS_AmSau(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value));
                            dt.Merge(_cDHN.getDS_XayDung(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value));
                            dt.Merge(_cDHN.getDS_DutChiGoc(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value));
                            dt.Merge(_cDHN.getDS_DutChiThan(int.Parse(cmbTo.SelectedValue.ToString()), dateTuNgay.Value, dateDenNgay.Value));
                        }
                    }
                    else
                    {
                        dt.Merge(_cDHN.getDS_AmSau(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value));
                        dt.Merge(_cDHN.getDS_XayDung(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value));
                        dt.Merge(_cDHN.getDS_DutChiGoc(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value));
                        dt.Merge(_cDHN.getDS_DutChiThan(CNguoiDung.MaTo, dateTuNgay.Value, dateDenNgay.Value));
                    }
                    dgvDanhSach.DataSource = dt;
                    break;
            }

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
                    if (CNguoiDung.Doi)
                    {
                        if (cmbTo.SelectedIndex == 0)
                            dr["SoPhieu"] = "Số:_____/DS";
                        else
                            dr["SoPhieu"] = "Số:_____/DS-" + _cTo.get(int.Parse(cmbTo.SelectedValue.ToString())).KyHieu;
                    }
                    else
                    {
                        dr["SoPhieu"] = "Số:_____/DS-" + _cTo.get(CNguoiDung.MaTo).KyHieu;
                    }

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
                    dr["ThoiGian"] = "Từ ngày " + dateTuNgay.Value.ToString("dd/MM/yyyy") + " đến ngày " + dateDenNgay.Value.ToString("dd/MM/yyyy");
                    dr["DanhBo"] = ttkh.DANHBO.Insert(7, " ").Insert(4, " ");
                    dr["MLT"] = ttkh.LOTRINH;
                    dr["HoTen"] = ttkh.HOTEN;
                    dr["DiaChi"] = ttkh.SONHA + " " + ttkh.TENDUONG + _cDHN.getPhuongQuan(ttkh.QUAN, ttkh.PHUONG);
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
