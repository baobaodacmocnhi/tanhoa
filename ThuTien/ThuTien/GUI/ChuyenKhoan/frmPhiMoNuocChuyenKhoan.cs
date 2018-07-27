using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.ChuyenKhoan;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;
using ThuTien.BaoCao;
using ThuTien.BaoCao.ChuyenKhoan;
using ThuTien.GUI.BaoCao;
using System.Transactions;
using ThuTien.DAL.DongNuoc;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmPhiMoNuocChuyenKhoan : Form
    {
        string _mnu = "mnuPhiMoNuocChuyenKhoan";
        CTienDu _cTienDu = new CTienDu();
        CPhiMoNuoc _cPhiMoNuoc = new CPhiMoNuoc();
        CDongNuoc _cDongNuoc = new CDongNuoc();

        public frmPhiMoNuocChuyenKhoan()
        {
            InitializeComponent();
        }

        private void frmPhiMoNuocChuyenKhoan_Load(object sender, EventArgs e)
        {
            dgvTienDu.AutoGenerateColumns = false;
            dgvPhiMoNuoc.AutoGenerateColumns = false;

            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvTienDu.DataSource = _cTienDu.GetDSPhiMoNuoc();

            if (dateTu.Value <= dateDen.Value)
                dgvPhiMoNuoc.DataSource = _cPhiMoNuoc.GetDS(dateTu.Value, dateDen.Value);

            foreach (DataGridViewRow item in dgvPhiMoNuoc.Rows)
            {
                if(int.Parse(item.Cells["PhiMoNuoc"].Value.ToString())/_cDongNuoc.GetPhiMoNuoc()>1)
                    item.DefaultCellStyle.BackColor = Color.Orange;
            }
        }

        private void dgvPhiMoNuoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPhiMoNuoc.Columns[e.ColumnIndex].Name == "MaPMN" && e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (dgvPhiMoNuoc.Columns[e.ColumnIndex].Name == "DanhBo_PMN" && e.Value != null && e.Value.ToString().Length==11)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
        }

        private void dgvPhiMoNuoc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvPhiMoNuoc.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvPhiMoNuoc_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvPhiMoNuoc.Columns[e.ColumnIndex].Name == "GhiChu_PMN" && e.FormattedValue.ToString() != dgvPhiMoNuoc[e.ColumnIndex, e.RowIndex].Value.ToString())
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    TT_PhiMoNuoc phimonuoc = _cPhiMoNuoc.Get(decimal.Parse(dgvPhiMoNuoc["MaPMN", e.RowIndex].Value.ToString()));
                    phimonuoc.GhiChu = e.FormattedValue.ToString();
                    _cPhiMoNuoc.Sua(phimonuoc);
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (dgvPhiMoNuoc.Columns[e.ColumnIndex].Name == "NhanHD_PMN" && bool.Parse(e.FormattedValue.ToString()) != bool.Parse(dgvPhiMoNuoc[e.ColumnIndex, e.RowIndex].Value.ToString()))
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    TT_PhiMoNuoc phimonuoc = _cPhiMoNuoc.Get(decimal.Parse(dgvPhiMoNuoc["MaPMN", e.RowIndex].Value.ToString()));
                    if (bool.Parse(e.FormattedValue.ToString()))
                    {
                        phimonuoc.NhanHD = bool.Parse(e.FormattedValue.ToString());
                        phimonuoc.NgayNhanHD = DateTime.Now;
                    }
                    else
                    {
                        phimonuoc.NhanHD = bool.Parse(e.FormattedValue.ToString());
                        phimonuoc.NgayNhanHD = null;
                    }
                    _cPhiMoNuoc.Sua(phimonuoc);
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (dgvPhiMoNuoc.Columns[e.ColumnIndex].Name == "TraHD_PMN" && bool.Parse(e.FormattedValue.ToString()) != bool.Parse(dgvPhiMoNuoc[e.ColumnIndex, e.RowIndex].Value.ToString()))
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    TT_PhiMoNuoc phimonuoc = _cPhiMoNuoc.Get(decimal.Parse(dgvPhiMoNuoc["MaPMN", e.RowIndex].Value.ToString()));
                    if (bool.Parse(e.FormattedValue.ToString()))
                    {
                        phimonuoc.TraHD = bool.Parse(e.FormattedValue.ToString());
                        phimonuoc.NgayTraHD = DateTime.Now;
                    }
                    else
                    {
                        phimonuoc.TraHD = bool.Parse(e.FormattedValue.ToString());
                        phimonuoc.NgayTraHD = null;
                    }
                    _cPhiMoNuoc.Sua(phimonuoc);
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();

            foreach (DataGridViewRow item in dgvPhiMoNuoc.SelectedRows)
            {
                DataRow dr = ds.Tables["PhiMoNuoc"].NewRow();
                dr["SoPhieu"] = item.Cells["MaPMN"].Value.ToString().Insert(item.Cells["MaPMN"].Value.ToString().Length - 2, "-");
                dr["DanhBo"] = item.Cells["DanhBo_PMN"].Value.ToString().Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = item.Cells["HoTen_PMN"].Value.ToString();
                dr["DiaChi"] = item.Cells["DiaChi_PMN"].Value.ToString();
                DateTime NgayBK = new DateTime();
                DateTime.TryParse(item.Cells["NgayBK_PMN"].Value.ToString(), out NgayBK);
                dr["NgayBK"] = NgayBK.ToString("dd/MM/yyyy");
                dr["NgayGiaiTrach"] = NgayBK.ToString("dd/MM/yyyy");
                dr["SoTien"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", int.Parse(item.Cells["SoTien_PMN"].Value.ToString()));
                dr["TongCong"] = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", int.Parse(item.Cells["TongCong_PMN"].Value.ToString()));
                if (item.Cells["PhiMoNuoc"].Value.ToString() != "")
                {
                    dr["PhiMoNuoc"] = int.Parse(item.Cells["PhiMoNuoc"].Value.ToString());
                    dr["PhiMoNuocChu"] = _cPhiMoNuoc.ConvertMoneyToWord(item.Cells["PhiMoNuoc"].Value.ToString());
                }
                else
                {
                    dr["PhiMoNuoc"] = 50000;
                    dr["PhiMoNuocChu"] = _cPhiMoNuoc.ConvertMoneyToWord(dr["PhiMoNuoc"].ToString());
                }
                dr["SoTK"] = item.Cells["SoTK_PMN"].Value.ToString();
                ds.Tables["PhiMoNuoc"].Rows.Add(dr);
            }

            rptChuyenPhiMoNuoc rpt = new rptChuyenPhiMoNuoc();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn Xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    using (var scope = new TransactionScope())
                    {
                        if (_cTienDu.Update(dgvPhiMoNuoc.SelectedRows[0].Cells["DanhBo_PMN"].Value.ToString(), int.Parse(dgvPhiMoNuoc.SelectedRows[0].Cells["SoTien_PMN"].Value.ToString()) - int.Parse(dgvPhiMoNuoc.SelectedRows[0].Cells["TongCong_PMN"].Value.ToString()), "Điều Chỉnh Tiền", "Xóa Chuyển Phí Mở Nước"))
                        {
                            TT_PhiMoNuoc phimonuoc = _cPhiMoNuoc.Get(decimal.Parse(dgvPhiMoNuoc.SelectedRows[0].Cells["MaPMN"].Value.ToString()));
                            TT_KQDongNuoc kqdongnuoc = _cDongNuoc.GetKQDongNuocByMaKQDN(phimonuoc.MaKQDN.Value);
                            kqdongnuoc.DongPhi = false;
                            kqdongnuoc.NgayDongPhi = null;
                            kqdongnuoc.ChuyenKhoan = false;
                            if (_cDongNuoc.SuaKQ(kqdongnuoc))
                                if (_cPhiMoNuoc.Xoa(phimonuoc))
                                {
                                    scope.Complete();
                                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                        }
                    }
                    btnXem.PerformClick();
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvTienDu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}
