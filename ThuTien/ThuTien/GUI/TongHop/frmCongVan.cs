using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.DongNuoc;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL;
using ThuTien.BaoCao;
using ThuTien.BaoCao.TongHop;
using ThuTien.GUI.BaoCao;
using ThuTien.LinQ;
using ThuTien.DAL.Doi;
using ThuTien.BaoCao.DongNuoc;
using ThuTien.DAL.TongHop;

namespace ThuTien.GUI.TongHop
{
    public partial class frmCongVan : Form
    {
        string _mnu = "mnuCongVan";
        CDongNuoc _cDongNuoc = new CDongNuoc();
        CKTKS_DonKH _cKinhDoanh = new CKTKS_DonKH();
        CHoaDon _cHoaDon = new CHoaDon();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CCongVan _cCongVan = new CCongVan();

        public frmCongVan()
        {
            InitializeComponent();
        }

        private void frmCongVan_Load(object sender, EventArgs e)
        {
            dgvKQDongNuoc.AutoGenerateColumns = false;
            dgvKQMoNuoc.AutoGenerateColumns = false;
            dgvKQDongMoNuoc.AutoGenerateColumns = false;
            dgvKinhDoanh.AutoGenerateColumns = false;
            dgvDSCongVan.AutoGenerateColumns = false;

            cmbLoaiVanBan_KD.SelectedIndex = 0;

            btnXem.PerformClick();
        }

        private void dgvKQDongNuoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvKQDongNuoc.Columns[e.ColumnIndex].Name == "SoPhieuDN" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void dgvKQDongNuoc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvKQDongNuoc.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvKQDongNuoc_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvKQDongNuoc.RowCount > 0 && e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                dsBaoCao dsBaoCao = new dsBaoCao();
                List<TT_KQDongNuoc>  lst = _cDongNuoc.GetDSKQDongNuocBySoPhieuDN(decimal.Parse(dgvKQDongNuoc["SoPhieuDN",e.RowIndex].Value.ToString()));
                foreach (TT_KQDongNuoc item in lst)
                {
                    DataRow dr = dsBaoCao.Tables["TBDongNuoc"].NewRow();

                    dr["MaDN"] = item.SoPhieuDN.ToString().Insert(item.SoPhieuDN.ToString().Length - 2, "-");
                    dr["Loai"] = "ĐÓNG NƯỚC";
                    dr["KyHieuLoai"] = "ĐN";
                    if (item.DanhBo.Length == 11)
                        dr["DanhBo"] = item.DanhBo.Insert(7, " ").Insert(4, " ");
                    dr["DiaChi"] = item.DiaChi;
                    string Ky = "";
                    foreach (TT_CTDongNuoc itemDN in item.TT_DongNuoc.TT_CTDongNuocs.ToList())
                    {
                        if (string.IsNullOrEmpty(Ky))
                            Ky = itemDN.Ky.Substring(0, itemDN.Ky.Length - 5);
                        else
                            Ky += ", " + itemDN.Ky.Substring(0, itemDN.Ky.Length - 5);
                    }
                    dr["Ky"] = Ky;
                    dr["NgayDongMoNuoc"] = item.NgayDN;
                    dr["ChiSoDongMoNuoc"] = item.ChiSoDN;

                    dsBaoCao.Tables["TBDongNuoc"].Rows.Add(dr);
                }

                rptPhieuBaoDongMoNuoc rpt = new rptPhieuBaoDongMoNuoc();
                rpt.SetDataSource(dsBaoCao);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.Show();
            }
        }

        private void dgvKQDongNuoc_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvKQDongNuoc.Columns[e.ColumnIndex].Name == "ChuyenDN" && e.FormattedValue.ToString() != dgvKQDongNuoc[e.ColumnIndex, e.RowIndex].Value.ToString())
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (bool.Parse(e.FormattedValue.ToString()) == true)
                        _cDongNuoc.LinQ_ExecuteNonQuery("update TT_KQDongNuoc set ChuyenDN=1,NgayChuyenDN=getdate(),ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getdate() where SoPhieuDN=" + dgvKQDongNuoc["SoPhieuDN", e.RowIndex].Value.ToString());
                    else
                        _cDongNuoc.LinQ_ExecuteNonQuery("update TT_KQDongNuoc set ChuyenDN=0,NgayChuyenDN=null,ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getdate() where SoPhieuDN=" + dgvKQDongNuoc["SoPhieuDN", e.RowIndex].Value.ToString());
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvKQMoNuoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvKQMoNuoc.Columns[e.ColumnIndex].Name == "SoPhieuMN" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void dgvKQMoNuoc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvKQMoNuoc.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvKQMoNuoc_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvKQMoNuoc.RowCount > 0 && e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                dsBaoCao dsBaoCao = new dsBaoCao();
                List<TT_KQDongNuoc> lst = _cDongNuoc.GetDSKQDongNuocBySoPhieuMN(decimal.Parse(dgvKQMoNuoc["SoPhieuMN", e.RowIndex].Value.ToString()));
                foreach (TT_KQDongNuoc item in lst)
                {
                    DataRow dr = dsBaoCao.Tables["TBDongNuoc"].NewRow();

                    dr["MaDN"] = item.SoPhieuMN.ToString().Insert(item.SoPhieuMN.ToString().Length - 2, "-");
                    dr["Loai"] = "MỞ NƯỚC";
                    dr["KyHieuLoai"] = "MN";
                    if (item.DanhBo.Length == 11)
                        dr["DanhBo"] = item.DanhBo.Insert(7, " ").Insert(4, " ");
                    dr["DiaChi"] = item.DiaChi;
                    string Ky = "";
                    foreach (TT_CTDongNuoc itemDN in item.TT_DongNuoc.TT_CTDongNuocs.ToList())
                    {
                        if (string.IsNullOrEmpty(Ky))
                            Ky = itemDN.Ky.Substring(0, itemDN.Ky.Length - 5);
                        else
                            Ky += ", " + itemDN.Ky.Substring(0, itemDN.Ky.Length - 5);
                    }
                    dr["Ky"] = Ky;
                    dr["NgayDongMoNuoc"] = item.NgayMN;
                    dr["ChiSoDongMoNuoc"] = item.ChiSoMN;

                    dsBaoCao.Tables["TBDongNuoc"].Rows.Add(dr);
                }

                rptPhieuBaoDongMoNuoc rpt = new rptPhieuBaoDongMoNuoc();
                rpt.SetDataSource(dsBaoCao);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.Show();
            }
        }

        private void dgvKQMoNuoc_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvKQMoNuoc.Columns[e.ColumnIndex].Name == "ChuyenMN" && e.FormattedValue.ToString() != dgvKQMoNuoc[e.ColumnIndex, e.RowIndex].Value.ToString())
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (bool.Parse(e.FormattedValue.ToString()) == true)
                        _cDongNuoc.LinQ_ExecuteNonQuery("update TT_KQDongNuoc set ChuyenMN=1,NgayChuyenMN=getdate(),ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getdate() where SoPhieuMN=" + dgvKQMoNuoc["SoPhieuMN", e.RowIndex].Value.ToString());
                    else
                        _cDongNuoc.LinQ_ExecuteNonQuery("update TT_KQDongNuoc set ChuyenMN=0,NgayChuyenMN=null,ModifyBy=" + CNguoiDung.MaND + ",ModifyDate=getdate() where SoPhieuMN=" + dgvKQMoNuoc["SoPhieuMN", e.RowIndex].Value.ToString());
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvKQDongNuoc.DataSource = _cDongNuoc.GetDSSoPhieuDN();
            dgvKQMoNuoc.DataSource = _cDongNuoc.GetDSSoPhieuMN();
        }

        private void txtDanhBo_KD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo_KD.Text.Trim().Replace(" ", "").Length == 11)
            {
                DataTable dt = new DataTable();
                dt.Merge(_cKinhDoanh.GetDSP_KinhDoanh(txtDanhBo_KD.Text.Trim().Replace(" ", "")));
                dt.Merge(_cCongVan.GetDS(txtDanhBo_KD.Text.Trim().Replace(" ", "")));
                dgvKinhDoanh.DataSource = dt;

                cmbLoaiVanBan_KD_Them.SelectedIndex = -1;
                txtNoiDung_KD.Text = "";
                txtGhiChu_KD.Text = "";
            }
        }

        private void dgvKinhDoanh_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvKinhDoanh.Columns[e.ColumnIndex].Name == "ThuTien_Nhan" &&dgvKinhDoanh["db",e.RowIndex].Value.ToString()=="Kinh Doanh"&& bool.Parse(e.FormattedValue.ToString()) != bool.Parse(dgvKinhDoanh[e.ColumnIndex, e.RowIndex].Value.ToString()))
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (bool.Parse(e.FormattedValue.ToString()) == true)
                        _cKinhDoanh.LinQ_ExecuteNonQuery("update " + dgvKinhDoanh["Table", e.RowIndex].Value.ToString() + " set ThuTien_Nhan=1,ThuTien_NgayNhan=getdate() where " + dgvKinhDoanh["Column", e.RowIndex].Value.ToString() + "=" + dgvKinhDoanh["Ma", e.RowIndex].Value.ToString());
                    else
                        _cKinhDoanh.LinQ_ExecuteNonQuery("update " + dgvKinhDoanh["Table", e.RowIndex].Value.ToString() + " set ThuTien_Nhan=0,ThuTien_NgayNhan=null where " + dgvKinhDoanh["Column", e.RowIndex].Value.ToString() + "=" + dgvKinhDoanh["Ma", e.RowIndex].Value.ToString());
                    //dgvKinhDoanh.DataSource = _cKinhDoanh.GetDSP_KinhDoanh(txtDanhBo_KD.Text.Trim().Replace(" ", ""));
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (dgvKinhDoanh.Columns[e.ColumnIndex].Name == "ThuTien_GhiChu" && e.FormattedValue.ToString().Trim() != dgvKinhDoanh[e.ColumnIndex, e.RowIndex].Value.ToString().Trim())
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (dgvKinhDoanh["db", e.RowIndex].Value.ToString() == "Kinh Doanh")
                    _cKinhDoanh.LinQ_ExecuteNonQuery("update " + dgvKinhDoanh["Table", e.RowIndex].Value.ToString() + " set ThuTien_GhiChu=N'" + e.FormattedValue.ToString().Trim() + "' where " + dgvKinhDoanh["Column", e.RowIndex].Value.ToString() + "=" + dgvKinhDoanh["Ma", e.RowIndex].Value.ToString());
                    if (dgvKinhDoanh["db", e.RowIndex].Value.ToString() == "Thu Tiền")
                        _cCongVan.LinQ_ExecuteNonQuery("update " + dgvKinhDoanh["Table", e.RowIndex].Value.ToString() + " set GhiChu=N'" + e.FormattedValue.ToString().Trim() + "' where " + dgvKinhDoanh["Column", e.RowIndex].Value.ToString() + "=" + dgvKinhDoanh["Ma", e.RowIndex].Value.ToString());
                    //dgvKinhDoanh.DataSource = _cKinhDoanh.GetDSP_KinhDoanh(txtDanhBo_KD.Text.Trim().Replace(" ", ""));
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvKinhDoanh_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvKinhDoanh.Columns[e.ColumnIndex].Name == "Ma" && e.Value != null && e.Value.ToString().Length>2)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void dgvKinhDoanh_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvKinhDoanh.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void txtDanhBo_DHN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo_DHN.Text.Trim().Replace(" ", "").Length == 11)
            {
                dgvKQDongMoNuoc.DataSource = _cDongNuoc.GetDSKQDongMoNuocByDanhBo(txtDanhBo_DHN.Text.Trim().Replace(" ", ""));
            }
        }

        private void btnXem_KD_Click(object sender, EventArgs e)
        {
            if (dateTu_KD.Value <= dateDen_KD.Value)
            {
                ///chọn tất cả văn bản
                if (cmbLoaiVanBan_KD.SelectedIndex == 0)
                {
                    DataTable dt = new DataTable();
                    dt.Merge(_cKinhDoanh.GetDSP_KinhDoanh("", dateTu_KD.Value, dateDen_KD.Value));
                    dt.Merge(_cCongVan.GetDS("", dateTu_KD.Value, dateDen_KD.Value));
                    dgvDSCongVan.DataSource = dt;
                }
                else
                    ///chọn 1 văn bản cụ thể
                    if (cmbLoaiVanBan_KD.SelectedIndex > 0)
                    {
                        DataTable dt = new DataTable();
                        dt.Merge(_cKinhDoanh.GetDSP_KinhDoanh(cmbLoaiVanBan_KD.SelectedItem.ToString(), dateTu_KD.Value, dateDen_KD.Value));
                        dt.Merge(_cCongVan.GetDS(cmbLoaiVanBan_KD.SelectedItem.ToString(), dateTu_KD.Value, dateDen_KD.Value));
                        dgvDSCongVan.DataSource = dt;
                    }

                foreach (DataGridViewRow item in dgvDSCongVan.Rows)
                {
                    item.Cells["Chon_CV"].Value = true;
                }
            }
        }

        private void dgvDSCongVan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSCongVan.Columns[e.ColumnIndex].Name == "Ma_CV" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void dgvDSCongVan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSCongVan.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnIn_KD_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvDSCongVan.Rows)
                if (item.Cells["Chon_CV"].Value != null && bool.Parse(item.Cells["Chon_CV"].Value.ToString()))
                {
                    DataRow dr = ds.Tables["TamThuChuyenKhoan"].NewRow();

                    dr["TuNgay"] = item.Cells["ThuTien_NgayNhan_CV"].Value.ToString();
                    dr["LoaiBaoCao"] = item.Cells["Loai_CV"].Value.ToString();
                    dr["DanhBo"] = item.Cells["DanhBo_CV"].Value.ToString().Insert(4, " ").Insert(8, " ");
                    dr["GhiChu"] = item.Cells["NoiDung_CV"].Value.ToString();

                    HOADON hoadon = _cHoaDon.GetMoiNhat(item.Cells["DanhBo_CV"].Value.ToString());
                    if(hoadon.MaNV_HanhThu==null)
                        hoadon = _cHoaDon.GetMoiNhi(item.Cells["DanhBo_CV"].Value.ToString());
                    dr["To"] = _cNguoiDung.GetTenToByMaND(hoadon.MaNV_HanhThu.Value);
                    dr["HanhThu"] = _cNguoiDung.GetHoTenByMaND(hoadon.MaNV_HanhThu.Value);

                    List<HOADON> lstHDTon = _cHoaDon.GetListDSTonByDanhBo(item.Cells["DanhBo_CV"].Value.ToString());
                    foreach (HOADON itemHDTon in lstHDTon)
                    {
                        if (string.IsNullOrEmpty(dr["Ky"].ToString()))
                            dr["Ky"] += itemHDTon.KY.ToString();
                        else
                            dr["Ky"] += "," + itemHDTon.KY.ToString();
                    }


                    ds.Tables["TamThuChuyenKhoan"].Rows.Add(dr);
                }
            rptDSCongVan rpt = new rptDSCongVan();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void dgvKQDongMoNuoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvKQMoNuoc.Columns[e.ColumnIndex].Name == "SoPhieuMN" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(7, " ").Insert(4, " ");
            }
        }

        private void btnThem_KD_Click(object sender, EventArgs e)
        {
            if (txtDanhBo_KD.Text.Trim().Replace(" ","").Length==11&&cmbLoaiVanBan_KD_Them.SelectedIndex != -1)
            {
                if (_cCongVan.CheckExist(cmbLoaiVanBan_KD_Them.SelectedItem.ToString(), txtDanhBo_KD.Text.Trim().Replace(" ", ""), DateTime.Now))
                {
                    MessageBox.Show("Đã Thêm Rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                TT_CongVan congvan = new TT_CongVan();
                congvan.Loai = cmbLoaiVanBan_KD_Them.SelectedItem.ToString();
                congvan.DanhBo = txtDanhBo_KD.Text.Trim().Replace(" ","");
                congvan.NoiDung = txtNoiDung_KD.Text.Trim();
                congvan.GhiChu = txtGhiChu_KD.Text.Trim();

                if (_cCongVan.Them(congvan))
                {
                    DataTable dt = new DataTable();
                    dt.Merge(_cKinhDoanh.GetDSP_KinhDoanh(txtDanhBo_KD.Text.Trim().Replace(" ", "")));
                    dt.Merge(_cCongVan.GetDS(txtDanhBo_KD.Text.Trim().Replace(" ", "")));
                    dgvKinhDoanh.DataSource = dt;

                    cmbLoaiVanBan_KD_Them.SelectedIndex = -1;
                    txtNoiDung_KD.Text = "";
                    txtGhiChu_KD.Text = "";
                }
            }
        }

        

    }
}
