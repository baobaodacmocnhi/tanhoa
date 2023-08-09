using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.VanThu;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;
using ThuTien.DAL;

namespace ThuTien.GUI.ToTruong
{
    public partial class frmCongVanDenTo : Form
    {
        string _mnu = "mnuCongVanDenTo";
        CCongVanDen _cCVD = new CCongVanDen();
        CTo _cTo = new CTo();
        CThuongVu _cThuongVu = new CThuongVu();

        public frmCongVanDenTo()
        {
            InitializeComponent();
        }

        private void frmCongVanDenTo_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
            if (CNguoiDung.Doi)
            {
                cmbTo.Visible = true;

                List<TT_To> lstTo = _cTo.getDS_HanhThu();
                TT_To to = new TT_To();
                to.MaTo = 0;
                to.TenTo = "Tất Cả";
                lstTo.Insert(0, to);
                cmbTo.DataSource = lstTo;
                cmbTo.DisplayMember = "TenTo";
                cmbTo.ValueMember = "MaTo";
            }
            else
                lbTo.Text = "Tổ  " + CNguoiDung.TenTo;
            btnXem.PerformClick();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (radChuaXuLy.Checked)
                flag = false;
            else
                if (radDaXuLy.Checked)
                    flag = true;
            if (CNguoiDung.Doi)
            {
                ///chọn tất cả các tổ
                if (cmbTo.SelectedIndex == 0)
                    dgvDanhSach.DataSource = _cCVD.getDS_XuLy_Doi(flag.ToString());
                else
                    ///chọn 1 tổ cụ thể
                    if (cmbTo.SelectedIndex > 0)
                        dgvDanhSach.DataSource = _cCVD.getDS_XuLy_To(flag.ToString(), cmbTo.SelectedValue.ToString());
            }
            else
                dgvDanhSach.DataSource = _cCVD.getDS_XuLy_To(flag.ToString(), cmbTo.SelectedValue.ToString());
        }

        private void dgvDanhSach_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (dgvDanhSach.Columns[e.ColumnIndex].Name == "DaXuLy" && dgvDanhSach.CurrentRow.Cells["ID"].Value != null && dgvDanhSach.CurrentRow.Cells["ID"].Value.ToString() != "")
                    {
                        TT_CongVanDen en = _cCVD.get(int.Parse(dgvDanhSach.CurrentRow.Cells["ID"].Value.ToString()));
                        en.DaXuLy = bool.Parse(dgvDanhSach.CurrentRow.Cells["DaXuLy"].Value.ToString());
                        if (en.DaXuLy)
                            en.DaXuLy_Ngay = DateTime.Now;
                        else
                            en.DaXuLy_Ngay = null;
                        _cCVD.Sua(en);
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDanhSach.Columns[e.ColumnIndex].Name == "XemHinh")
                {
                    if (dgvDanhSach.CurrentRow.Cells["TableName"].Value.ToString() == "")
                    {
                        MessageBox.Show("Không có File", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    DataTable dt = _cThuongVu.getFile(dgvDanhSach.CurrentRow.Cells["TableName"].Value.ToString(), int.Parse(dgvDanhSach.CurrentRow.Cells["IDCT"].Value.ToString()));
                    if (dt != null && dt.Rows.Count > 0)
                        foreach (DataRow item in dt.Rows)
                        {
                            if (item["Type"].ToString().ToLower().Contains("pdf"))
                                _cCVD.viewPDF((byte[])item["File"]);
                            else
                                _cCVD.viewImage((byte[])item["File"]);
                        }
                    //string TableNameHinh, IDName;
                    //_cThuongVu.getTableHinh(dgvDanhSach.CurrentRow.Cells["TableName"].Value.ToString(), out TableNameHinh, out IDName);
                    //System.Diagnostics.Process.Start("https://service.cskhtanhoa.com.vn/ThuongVu/viewFile?TableName=" + TableNameHinh + "&IDFileName=" + IDName + "&IDFileContent=" + dgvDanhSach.CurrentRow.Cells["IDCT"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }
    }
}
