using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.DAL.HanhThu;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;
using ThuTien.BaoCao;
using KTKS_DonKH.GUI.BaoCao;

namespace ThuTien.GUI.HanhThu
{
    public partial class frmQuetTam : Form
    {
        string _mnu = "mnuQuetTam";
        CHoaDon _cHoaDon = new CHoaDon();
        CQuetTam _cQuetTam = new CQuetTam();

        public frmQuetTam()
        {
            InitializeComponent();
        }

        private void frmQuetTam_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
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
                foreach (var item in lstHD.Items)
                {
                    if (!_cHoaDon.CheckBySoHoaDon(item.ToString()))
                    {
                        MessageBox.Show("Hóa Đơn sai: " + item.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lstHD.SelectedItem = item;
                        return;
                    }
                }
                try
                {
                    _cQuetTam.BeginTransaction();
                    foreach (var item in lstHD.Items)
                    {
                        TT_QuetTam quettam = new TT_QuetTam();
                        quettam.SoHoaDon = item.ToString();
                        if (!_cQuetTam.Them(quettam))
                        {
                            _cQuetTam.Rollback();
                            MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    _cQuetTam.CommitTransaction();
                    lstHD.Items.Clear();
                    dgvHoaDon.DataSource = _cQuetTam.GetDSByMaNVCreatedDate(CNguoiDung.MaND, dateTu.Value);
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    _cQuetTam.Rollback();
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
                        _cQuetTam.BeginTransaction();
                        foreach (DataGridViewRow item in dgvHoaDon.SelectedRows)
                        {
                            TT_QuetTam quettam = _cQuetTam.GetBySoHoaDon(item.Cells["SoHoaDon"].Value.ToString());
                            if (!_cQuetTam.Xoa(quettam))
                            {
                                _cQuetTam.Rollback();
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        _cQuetTam.CommitTransaction();
                        lstHD.Items.Clear();
                        dgvHoaDon.DataSource = _cQuetTam.GetDSByMaNVCreatedDate(CNguoiDung.MaND, dateTu.Value);
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        _cQuetTam.Rollback();
                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvHoaDon.Rows)
            {
                DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(4, " ").Insert(8, " ");
                dr["Ky"] = item.Cells["Ky"].Value;
                dr["MLT"] = item.Cells["MLT"].Value;
                dr["TongCong"] = item.Cells["TongCong"].Value;
                dr["SoPhatHanh"] = item.Cells["SoPhatHanh"].Value;
                dr["SoHoaDon"] = item.Cells["SoHoaDon"].Value;
                dr["NhanVien"] = CNguoiDung.HoTen;
                ds.Tables["DSHoaDon"].Rows.Add(dr);
            }
            rptDSHoaDon rpt = new rptDSHoaDon();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvHoaDon.DataSource = _cQuetTam.GetDSByMaNVCreatedDate(CNguoiDung.MaND, dateTu.Value);
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
        }

        private void dgvHoaDon_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHoaDon.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
    }
}
