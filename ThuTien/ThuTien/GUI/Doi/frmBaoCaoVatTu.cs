using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.DongNuoc;
using ThuTien.BaoCao;
using ThuTien.BaoCao.DongNuoc;
using ThuTien.GUI.BaoCao;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;
using ThuTien.DAL.Doi;

namespace ThuTien.GUI.Doi
{
    public partial class frmBaoCaoVatTu : Form
    {
        string _mnu = "mnuBaoCaoVatTu";
        CDongNuoc _cDongNuoc = new CDongNuoc();
        CNiemChi _cNiemChi = new CNiemChi();
        CHoaDon _cHoaDon = new CHoaDon();

        public frmBaoCaoVatTu()
        {
            InitializeComponent();
        }

        private void frmBaoCaoVatTu_Load(object sender, EventArgs e)
        {
            dgvBamChi.AutoGenerateColumns = false;

        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (radDongNuoc.Checked)
                dgvBamChi.DataSource = _cDongNuoc.getDS_KQDongNuoc(dateTu.Value, dateDen.Value);
            else
                if (radMoNuoc.Checked)
                    dgvBamChi.DataSource = _cDongNuoc.getDS_KQMoNuoc(dateTu.Value, dateDen.Value);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                dsBaoCao ds = new dsBaoCao();
                foreach (DataGridViewRow item in dgvBamChi.Rows)
                    if (item.Cells["DanhBo"].Value != null)
                    {
                        DateTime date = new DateTime();
                        if (radDongNuoc.Checked)
                            DateTime.TryParse(item.Cells["NgayDN"].Value.ToString(), out date);
                        else
                            if (radMoNuoc.Checked)
                                DateTime.TryParse(item.Cells["NgayMN"].Value.ToString(), out date);
                        if (date.Date >= dateTu.Value.Date && date.Date <= dateDen.Value.Date)
                        {
                            DataRow dr = ds.Tables["KQDongNuoc"].NewRow();
                            if (radDongNuoc.Checked)
                            {
                                dr["Loai"] = "màu XANH";
                                if (item.Cells["NiemChi"].Value.ToString() != "")
                                {
                                    dr["NiemChi"] = item.Cells["NiemChi"].Value.ToString();
                                    dr["DayDong"] = _cDongNuoc.convertToDouble("0,6");
                                }
                                else
                                    if (bool.Parse(item.Cells["KhoaKhac"].Value.ToString()) == true || bool.Parse(item.Cells["KhoaTu"].Value.ToString()) == true)
                                        dr["KhoaTu"] = "X";
                            }
                            else
                                if (radMoNuoc.Checked)
                                {
                                    dr["Loai"] = "màu VÀNG";
                                    if (item.Cells["NiemChiMN"].Value.ToString() != "")
                                    {
                                        dr["NiemChi"] = item.Cells["NiemChiMN"].Value.ToString();
                                        dr["DayDong"] = _cDongNuoc.convertToDouble("0,6");
                                    }
                                    else
                                        if (bool.Parse(item.Cells["KhoaKhac"].Value.ToString()) == true || bool.Parse(item.Cells["KhoaTu"].Value.ToString()) == true)
                                            dr["KhoaTu"] = "X";
                                }
                            dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                            dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                            dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(7, " ").Insert(4, " ");
                            dr["HoTen"] = item.Cells["HoTen"].Value.ToString();
                            dr["DiaChi"] = item.Cells["DiaChi"].Value.ToString();
                            dr["Hieu"] = item.Cells["Hieu"].Value.ToString();
                            dr["Co"] = item.Cells["Co"].Value.ToString();
                            if (int.Parse(item.Cells["Co"].Value.ToString()) <= 25)
                                dr["ChiSo"] = int.Parse(item.Cells["ChiSoDN"].Value.ToString()).ToString("D4");
                            else
                                dr["ChiSo"] = int.Parse(item.Cells["ChiSoDN"].Value.ToString()).ToString("D5");
                            dr["NgayDN"] = date.ToString("dd/MM/yyyy");
                            dr["To"] = item.Cells["To"].Value.ToString();
                            dr["NhanVien"] = item.Cells["NhanVien"].Value.ToString();
      
                            dr["GhiChu"] = "Thu hồi nợ";
                            dr["ChucVu"] = CNguoiKy.getChucVu();
                            dr["NguoiKy"] = CNguoiKy.getNguoiKy();

                            ds.Tables["KQDongNuoc"].Rows.Add(dr);
                        }
                    }

                object soluong = _cNiemChi.countHuHong_ChuQuyetToan();
                if (radDongNuoc.Checked)
                    soluong = _cNiemChi.countHuHong_ChuQuyetToan("Xanh");
                else
                    if (radMoNuoc.Checked)
                        soluong = _cNiemChi.countHuHong_ChuQuyetToan("Vàng");
                if (soluong != null && int.Parse(soluong.ToString()) > 0)
                {
                    DataTable dtHD = _cHoaDon.getDS(soluong.ToString());
                    DataTable dtNC = _cNiemChi.getDSHuHong_ChuaQyetToan();

                    for (int i = 0; i < dtNC.Rows.Count; i++)
                    {
                        DataRow dr = ds.Tables["KQDongNuoc"].NewRow();

                        dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                        dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                        dr["DanhBo"] = dtHD.Rows[i]["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                        dr["HoTen"] = dtHD.Rows[i]["HoTen"].ToString();
                        dr["DiaChi"] = dtHD.Rows[i]["DiaChi"].ToString();
                        dr["Hieu"] = dtHD.Rows[i]["Hieu"].ToString();
                        dr["Co"] = dtHD.Rows[i]["Co"].ToString();

                        dr["To"] = dtNC.Rows[i]["TenTo"].ToString();
                        dr["NhanVien"] = dtNC.Rows[i]["HoTen"].ToString();

                        dr["NiemChi"] = dtNC.Rows[i]["ID"].ToString();
                        dr["DayDong"] = _cDongNuoc.convertToDouble("0,6");

                        dr["ChucVu"] = CNguoiKy.getChucVu();
                        dr["NguoiKy"] = CNguoiKy.getNguoiKy();

                        ds.Tables["KQDongNuoc"].Rows.Add(dr);
                    }
                }
                rptBaoCaoVatTu_NiemChi rpt = new rptBaoCaoVatTu_NiemChi();
                rpt.SetDataSource(ds);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvBamChi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvBamChi.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null && e.Value.ToString().Length == 11)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
        }

        private void dgvBamChi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvBamChi.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvBamChi_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvBamChi.Columns[e.ColumnIndex].Name == "Duyet" && bool.Parse(e.FormattedValue.ToString()) != bool.Parse(dgvBamChi[e.ColumnIndex, e.RowIndex].Value.ToString()))
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    TT_KQDongNuoc kqdongnuoc = _cDongNuoc.GetKQDongNuocByMaKQDN(int.Parse(dgvBamChi["MaKQDN", e.RowIndex].Value.ToString()));
                    kqdongnuoc.Duyet = bool.Parse(e.FormattedValue.ToString());
                    _cDongNuoc.SuaKQ(kqdongnuoc);
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radDongNuoc_CheckedChanged(object sender, EventArgs e)
        {
            if (radDongNuoc.Checked)
            {
                dgvBamChi.Columns["ChiSoDN"].Visible = true;
                dgvBamChi.Columns["NgayDN"].Visible = true;
                dgvBamChi.Columns["NiemChi"].Visible = true;
                dgvBamChi.Columns["NiemChi1"].Visible = true;
                dgvBamChi.Columns["MauSac"].Visible = true;
                dgvBamChi.Columns["ChiSoMN"].Visible = false;
                dgvBamChi.Columns["NgayMN"].Visible = false;
                dgvBamChi.Columns["NiemChiMN"].Visible = false;
                dgvBamChi.Columns["MauSacMN"].Visible = false;
            }
        }

        private void radMoNuoc_CheckedChanged(object sender, EventArgs e)
        {
            if (radMoNuoc.Checked)
            {
                dgvBamChi.Columns["ChiSoDN"].Visible = false;
                dgvBamChi.Columns["NgayDN"].Visible = false;
                dgvBamChi.Columns["NiemChi"].Visible = false;
                dgvBamChi.Columns["NiemChi1"].Visible = false;
                dgvBamChi.Columns["MauSac"].Visible = false;
                dgvBamChi.Columns["ChiSoMN"].Visible = true;
                dgvBamChi.Columns["NgayMN"].Visible = true;
                dgvBamChi.Columns["NiemChiMN"].Visible = true;
                dgvBamChi.Columns["MauSacMN"].Visible = true;
            }
        }
    }
}
