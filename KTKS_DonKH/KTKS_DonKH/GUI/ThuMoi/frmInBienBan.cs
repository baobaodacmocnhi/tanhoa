using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL;
using KTKS_DonKH.DAL.ThuMoi;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.ThuMoi;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.ThuMoi
{
    public partial class frmInBienBan : Form
    {
        string _mnu = "mnuInBienBan";
        CThuTien _cThuTien = new CThuTien();
        CDHN _cDHN = new CDHN();
        CInBienBan _cInBienBan = new CInBienBan();

        public frmInBienBan()
        {
            InitializeComponent();
        }

        private void frmInBienBan_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
        }

        public void Clear()
        {
            txtDanhBo.Text = "";
            btnXem.PerformClick();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = _cInBienBan.getDS(CTaiKhoan.MaUser, dateTu.Value, dateDen.Value);
        }

        private void dgvDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDanhSach_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDanhSach.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(7, " ").Insert(4, " ");
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13 && txtDanhBo.Text.Trim().Replace(" ", "").Length == 11)
                {
                    if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
                    {
                        TB_DULIEUKHACHHANG ttkh = _cDHN.GetTTKH(txtDanhBo.Text.Trim().Replace(" ", ""));
                        if (ttkh != null)
                        {
                            InBienBan en = new InBienBan();
                            en.DanhBo = ttkh.DANHBO;
                            en.HopDong = ttkh.HOPDONG;
                            en.HoTen = ttkh.HOTEN;
                            en.DiaChi = ttkh.SONHA + " " + ttkh.TENDUONG;
                            en.Hieu = ttkh.HIEUDH;
                            en.SoThan = ttkh.SOTHANDH;
                            en.Co = int.Parse(ttkh.CODH);
                            if (_cInBienBan.them(en))
                            {
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Clear();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Danh Bộ này không tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInBBBanGiaoNapHopBV_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataGridViewRow item in dgvDanhSach.Rows)
            {
                DataRow dr = dsBaoCao.Tables["PhieuTieuThu"].NewRow();
                dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = item.Cells["HoTen"].Value.ToString();
                dr["DiaChi"] = item.Cells["DiaChi"].Value.ToString();
                dr["HopDong"] = item.Cells["HopDong"].Value.ToString();
                dr["Hieu"] = item.Cells["Hieu"].Value.ToString();
                dr["Co"] = item.Cells["Co"].Value.ToString();
                dr["SoThan"] = item.Cells["SoThan"].Value.ToString();
                dsBaoCao.Tables["PhieuTieuThu"].Rows.Add(dr);
            }
            rptBBBanGiaoNapHopBV rpt = new rptBBBanGiaoNapHopBV();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK &&_cInBienBan.xoa(_cInBienBan.get(int.Parse(dgvDanhSach.CurrentRow.Cells["ID"].Value.ToString()))))
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
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


    }
}
