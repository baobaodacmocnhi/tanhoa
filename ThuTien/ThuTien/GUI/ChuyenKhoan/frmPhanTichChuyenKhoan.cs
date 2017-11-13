using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.ChuyenKhoan;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.Doi;
using System.Globalization;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmPhanTichChuyenKhoan : Form
    {
        CDichVuThu _cDichVuThu = new CDichVuThu();
        CTo _cTo = new CTo();
        CHoaDon _cHoaDon = new CHoaDon();
        CNguoiDung _cNguoiDung = new CNguoiDung();

        public frmPhanTichChuyenKhoan()
        {
            InitializeComponent();
        }

        private void frmPhanTichChuyenKhoan_Load(object sender, EventArgs e)
        {
            dgvTo_PhanTich.AutoGenerateColumns = false;
            dgvNhanVien_PhanTich.AutoGenerateColumns = false;

            DataTable dtDichVuThu = _cDichVuThu.GetDichVuThu();
            DataRow dr = dtDichVuThu.NewRow();
            dr["ID"] = "";
            dr["TenDichVu"] = "Tất Cả";
            dtDichVuThu.Rows.InsertAt(dr, 0);
            cmbDichVuThu_PhanTich.DataSource = dtDichVuThu;
            cmbDichVuThu_PhanTich.DisplayMember = "TenDichVu";
            cmbDichVuThu_PhanTich.ValueMember = "ID";

            List<TT_To> lstTo = _cTo.GetDSHanhThu();
            TT_To to = new TT_To();
            to.MaTo = 0;
            to.TenTo = "Tất Cả";
            lstTo.Insert(0, to);
            cmbTo_PhanTich.DataSource = lstTo;
            cmbTo_PhanTich.DisplayMember = "TenTo";
            cmbTo_PhanTich.ValueMember = "MaTo";

            DataTable dtNam = _cHoaDon.GetNam();
            cmbNam_PhanTich.DataSource = dtNam;
            cmbNam_PhanTich.DisplayMember = "Nam";
            cmbNam_PhanTich.ValueMember = "Nam";

            dgvDichVuThu.AutoGenerateColumns = false;
            dgvBienDong_HD.AutoGenerateColumns = false;

            cmbDichVuThu_HD.DataSource = dtDichVuThu;
            cmbDichVuThu_HD.DisplayMember = "TenDichVu";
            cmbDichVuThu_HD.ValueMember = "ID";

            cmbTo_HD.DataSource = lstTo;
            cmbTo_HD.DisplayMember = "TenTo";
            cmbTo_HD.ValueMember = "MaTo";

            cmbNam_HD.DataSource = dtNam;
            cmbNam_HD.DisplayMember = "Nam";
            cmbNam_HD.ValueMember = "Nam";
        }

        public void CountdgvTo_PhanTich()
        {
            int TongHDCK = 0;
            long TongGiaBanCK = 0;
            long TongCongCK = 0;
            int TongHDChuaCK = 0;
            long TongGiaBanChuaCK = 0;
            long TongCongChuaCK = 0;

            if (dgvTo_PhanTich.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvTo_PhanTich.Rows)
                {
                    if (!string.IsNullOrEmpty(item.Cells["TongHDCK"].Value.ToString()))
                        TongHDCK += int.Parse(item.Cells["TongHDCK"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBanCK"].Value.ToString()))
                        TongGiaBanCK += long.Parse(item.Cells["TongGiaBanCK"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongCK"].Value.ToString()))
                        TongCongCK += long.Parse(item.Cells["TongCongCK"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDChuaCK"].Value.ToString()))
                        TongHDChuaCK += int.Parse(item.Cells["TongHDChuaCK"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBanChuaCK"].Value.ToString()))
                        TongGiaBanChuaCK += long.Parse(item.Cells["TongGiaBanChuaCK"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongChuaCK"].Value.ToString()))
                        TongCongChuaCK += long.Parse(item.Cells["TongCongChuaCK"].Value.ToString());

                    if (string.IsNullOrEmpty(item.Cells["TongHDCK"].Value.ToString()))
                        item.Cells["TiLeHDCK"].Value = "0%";
                    else
                        item.Cells["TiLeHDCK"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongHDCK"].Value.ToString()) / double.Parse(item.Cells["TongHD"].Value.ToString())) * 100);
                    if (string.IsNullOrEmpty(item.Cells["TongHDChuaCK"].Value.ToString()))
                        item.Cells["TiLeHDChuaCK"].Value = "0%";
                    else
                        item.Cells["TiLeHDChuaCK"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongHDChuaCK"].Value.ToString()) / double.Parse(item.Cells["TongHD"].Value.ToString())) * 100);
                }
                txtTongHDCK.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDCK);
                txtTongGiaBanCK.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanCK);
                txtTongCongCK.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongCK);
                txtTongHDChuaCK.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDChuaCK);
                txtTongGiaBanaChuaCK.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanChuaCK);
                txtTongCongChuaCK.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongChuaCK);
            }
        }

        public void CountdgvNhanVien_PhanTich()
        {
            int TongHDCK = 0;
            long TongGiaBanCK = 0;
            long TongCongCK = 0;
            int TongHDChuaCK = 0;
            long TongGiaBanChuaCK = 0;
            long TongCongChuaCK = 0;

            if (dgvNhanVien_PhanTich.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvNhanVien_PhanTich.Rows)
                {
                    if (!string.IsNullOrEmpty(item.Cells["TongHDCK_NV"].Value.ToString()))
                        TongHDCK += int.Parse(item.Cells["TongHDCK_NV"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBanCK_NV"].Value.ToString()))
                        TongGiaBanCK += long.Parse(item.Cells["TongGiaBanCK_NV"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongCK_NV"].Value.ToString()))
                        TongCongCK += long.Parse(item.Cells["TongCongCK_NV"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDChuaCK_NV"].Value.ToString()))
                        TongHDChuaCK += int.Parse(item.Cells["TongHDChuaCK_NV"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBanChuaCK_NV"].Value.ToString()))
                        TongGiaBanChuaCK += long.Parse(item.Cells["TongGiaBanChuaCK_NV"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongChuaCK_NV"].Value.ToString()))
                        TongCongChuaCK += long.Parse(item.Cells["TongCongChuaCK_NV"].Value.ToString());

                    if (string.IsNullOrEmpty(item.Cells["TongHDCK_NV"].Value.ToString()))
                        item.Cells["TiLeHDCK_NV"].Value = "0%";
                    else
                        item.Cells["TiLeHDCK_NV"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongHDCK_NV"].Value.ToString()) / double.Parse(item.Cells["TongHD_NV"].Value.ToString())) * 100);
                    if (string.IsNullOrEmpty(item.Cells["TongHDChuaCK_NV"].Value.ToString()))
                        item.Cells["TiLeHDChuaCK_NV"].Value = "0%";
                    else
                        item.Cells["TiLeHDChuaCK_NV"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongHDChuaCK_NV"].Value.ToString()) / double.Parse(item.Cells["TongHD_NV"].Value.ToString())) * 100);
                }
                //txtTongHDCK.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDCK);
                //txtTongGiaBanCK.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanCK);
                //txtTongCongCK.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongCK);
                //txtTongHDChuaCK.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDChuaCK);
                //txtTongGiaBanaChuaCK.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanChuaCK);
                //txtTongCongChuaCK.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongChuaCK);
            }
        }

        private void cmbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnXem_PhanTich_Click(object sender, EventArgs e)
        {
            if (chkNgayKiemTra.Checked == true)
            {
                ///chọn tất cả tổ
                if (cmbTo_PhanTich.SelectedIndex == 0)
                {
                    DataTable dt = new DataTable();
                    ///chọn tất cả kỳ
                    if (cmbKy_PhanTich.SelectedIndex == 0)
                    {
                        for (int i = 1; i < cmbTo_PhanTich.Items.Count; i++)
                            dt.Merge(_cDichVuThu.GetPhanTichChuyenKhoan(cmbDichVuThu_PhanTich.SelectedValue.ToString(), ((TT_To)cmbTo_PhanTich.Items[i]).MaTo, int.Parse(cmbNam_PhanTich.SelectedValue.ToString()), dateGiaiTrach.Value));
                    }
                    else
                        ///chọn 1 kỳ
                        if (cmbKy_PhanTich.SelectedIndex > 0)
                        {
                            for (int i = 1; i < cmbTo_PhanTich.Items.Count; i++)
                                dt.Merge(_cDichVuThu.GetPhanTichChuyenKhoan(cmbDichVuThu_PhanTich.SelectedValue.ToString(), ((TT_To)cmbTo_PhanTich.Items[i]).MaTo, int.Parse(cmbNam_PhanTich.SelectedValue.ToString()), int.Parse(cmbKy_PhanTich.SelectedItem.ToString()), dateGiaiTrach.Value));
                        }
                    dgvTo_PhanTich.DataSource = dt;
                }
                ///chọn 1 tổ
                else
                    if (cmbTo_PhanTich.SelectedIndex > 0)
                        ///chọn tất cả kỳ
                        if (cmbKy_PhanTich.SelectedIndex == 0)
                            dgvTo_PhanTich.DataSource = _cDichVuThu.GetPhanTichChuyenKhoan(cmbDichVuThu_PhanTich.SelectedValue.ToString(), int.Parse(cmbTo_PhanTich.SelectedValue.ToString()), int.Parse(cmbNam_PhanTich.SelectedValue.ToString()), dateGiaiTrach.Value);
                        else
                            ///chọn 1 kỳ
                            if (cmbKy_PhanTich.SelectedIndex > 0)
                                dgvTo_PhanTich.DataSource = _cDichVuThu.GetPhanTichChuyenKhoan(cmbDichVuThu_PhanTich.SelectedValue.ToString(), int.Parse(cmbTo_PhanTich.SelectedValue.ToString()), int.Parse(cmbNam_PhanTich.SelectedValue.ToString()), int.Parse(cmbKy_PhanTich.SelectedItem.ToString()), dateGiaiTrach.Value);
            }
            else
            {
                ///chọn tất cả tổ
                if (cmbTo_PhanTich.SelectedIndex == 0)
                {
                    DataTable dt = new DataTable();
                    ///chọn tất cả kỳ
                    if (cmbKy_PhanTich.SelectedIndex == 0)
                    {
                        for (int i = 1; i < cmbTo_PhanTich.Items.Count; i++)
                            dt.Merge(_cDichVuThu.GetPhanTichChuyenKhoan(cmbDichVuThu_PhanTich.SelectedValue.ToString(), ((TT_To)cmbTo_PhanTich.Items[i]).MaTo, int.Parse(cmbNam_PhanTich.SelectedValue.ToString())));
                    }
                    else
                        ///chọn 1 kỳ
                        if (cmbKy_PhanTich.SelectedIndex > 0)
                        {
                            for (int i = 1; i < cmbTo_PhanTich.Items.Count; i++)
                                dt.Merge(_cDichVuThu.GetPhanTichChuyenKhoan(cmbDichVuThu_PhanTich.SelectedValue.ToString(), ((TT_To)cmbTo_PhanTich.Items[i]).MaTo, int.Parse(cmbNam_PhanTich.SelectedValue.ToString()), int.Parse(cmbKy_PhanTich.SelectedItem.ToString())));
                        }
                    dgvTo_PhanTich.DataSource = dt;
                }
                ///chọn 1 tổ
                else
                    if (cmbTo_PhanTich.SelectedIndex > 0)
                        ///chọn tất cả kỳ
                        if (cmbKy_PhanTich.SelectedIndex == 0)
                            dgvTo_PhanTich.DataSource = _cDichVuThu.GetPhanTichChuyenKhoan(cmbDichVuThu_PhanTich.SelectedValue.ToString(), int.Parse(cmbTo_PhanTich.SelectedValue.ToString()), int.Parse(cmbNam_PhanTich.SelectedValue.ToString()));
                        else
                            ///chọn 1 kỳ
                            if (cmbKy_PhanTich.SelectedIndex > 0)
                                dgvTo_PhanTich.DataSource = _cDichVuThu.GetPhanTichChuyenKhoan(cmbDichVuThu_PhanTich.SelectedValue.ToString(), int.Parse(cmbTo_PhanTich.SelectedValue.ToString()), int.Parse(cmbNam_PhanTich.SelectedValue.ToString()), int.Parse(cmbKy_PhanTich.SelectedItem.ToString()));
            }
            CountdgvTo_PhanTich();
        }

        private void btnInDS_PhanTich_Click(object sender, EventArgs e)
        {

        }

        private void dgvTo_PhanTich_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTo_PhanTich.RowCount > 0)
            {
                if (chkNgayKiemTra.Checked == true)
                {
                    ///chọn tất cả kỳ
                    if (cmbKy_PhanTich.SelectedIndex == 0)
                        dgvNhanVien_PhanTich.DataSource = _cDichVuThu.GetPhanTichChuyenKhoan_NV(cmbDichVuThu_PhanTich.SelectedValue.ToString(), int.Parse(dgvTo_PhanTich.CurrentRow.Cells["MaTo"].Value.ToString()), int.Parse(cmbNam_PhanTich.SelectedValue.ToString()), dateGiaiTrach.Value);
                    else
                        ///chọn 1 kỳ
                        if (cmbKy_PhanTich.SelectedIndex > 0)
                            dgvNhanVien_PhanTich.DataSource = _cDichVuThu.GetPhanTichChuyenKhoan_NV(cmbDichVuThu_PhanTich.SelectedValue.ToString(), int.Parse(dgvTo_PhanTich.CurrentRow.Cells["MaTo"].Value.ToString()), int.Parse(cmbNam_PhanTich.SelectedValue.ToString()), int.Parse(cmbKy_PhanTich.SelectedItem.ToString()), dateGiaiTrach.Value);
                }
                else
                {
                    ///chọn tất cả kỳ
                    if (cmbKy_PhanTich.SelectedIndex == 0)
                        dgvNhanVien_PhanTich.DataSource = _cDichVuThu.GetPhanTichChuyenKhoan_NV(cmbDichVuThu_PhanTich.SelectedValue.ToString(), int.Parse(dgvTo_PhanTich.CurrentRow.Cells["MaTo"].Value.ToString()), int.Parse(cmbNam_PhanTich.SelectedValue.ToString()));
                    else
                        ///chọn 1 kỳ
                        if (cmbKy_PhanTich.SelectedIndex > 0)
                            dgvNhanVien_PhanTich.DataSource = _cDichVuThu.GetPhanTichChuyenKhoan_NV(cmbDichVuThu_PhanTich.SelectedValue.ToString(), int.Parse(dgvTo_PhanTich.CurrentRow.Cells["MaTo"].Value.ToString()), int.Parse(cmbNam_PhanTich.SelectedValue.ToString()), int.Parse(cmbKy_PhanTich.SelectedItem.ToString()));
                }
                CountdgvNhanVien_PhanTich();
            }
        }

        private void dgvTo_PhanTich_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTo_PhanTich.Columns[e.ColumnIndex].Name == "TongHDCK" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTo_PhanTich.Columns[e.ColumnIndex].Name == "TongGiaBanCK" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTo_PhanTich.Columns[e.ColumnIndex].Name == "TongCongCK" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTo_PhanTich.Columns[e.ColumnIndex].Name == "TongHDChuaCK" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTo_PhanTich.Columns[e.ColumnIndex].Name == "TongGiaBanChuaCK" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTo_PhanTich.Columns[e.ColumnIndex].Name == "TongCongChuaCK" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvTo_PhanTich_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvTo_PhanTich.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvNhanVien_PhanTich_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvNhanVien_PhanTich.Columns[e.ColumnIndex].Name == "TongHDCK_NV" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien_PhanTich.Columns[e.ColumnIndex].Name == "TongGiaBanCK_NV" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien_PhanTich.Columns[e.ColumnIndex].Name == "TongCongCK_NV" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien_PhanTich.Columns[e.ColumnIndex].Name == "TongHDChuaCK_NV" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien_PhanTich.Columns[e.ColumnIndex].Name == "TongGiaBanChuaCK_NV" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien_PhanTich.Columns[e.ColumnIndex].Name == "TongCongChuaCK_NV" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvNhanVien_PhanTich_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvNhanVien_PhanTich.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        public void CountdgvDichVuThu()
        {
            long TongSoTien = 0;

            if (dgvDichVuThu.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvDichVuThu.Rows)
                {
                    if (!string.IsNullOrEmpty(item.Cells["SoTien"].Value.ToString()))
                        TongSoTien += long.Parse(item.Cells["SoTien"].Value.ToString());
                }
                txtTongHD_HD.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", dgvDichVuThu.RowCount);
                txtTongSoTien_HD.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongSoTien);
            }
        }

        private void btnXem_HD_Click(object sender, EventArgs e)
        {
            ///chọn tất cả tổ
            if (cmbTo_HD.SelectedIndex == 0)
            {
                DataTable dt = new DataTable();
                ///chọn tất cả kỳ
                if (cmbKy_HD.SelectedIndex == 0)
                {
                    for (int i = 1; i < cmbTo_HD.Items.Count; i++)
                        dt.Merge(_cDichVuThu.GetDS(cmbDichVuThu_HD.SelectedValue.ToString(), ((TT_To)cmbTo_HD.Items[i]).MaTo, int.Parse(cmbNam_HD.SelectedValue.ToString())));
                    DataTable dtBD = new DataTable();
                    for (int i = 1; i <= 12; i++)
                    {
                        dtBD.Merge(_cDichVuThu.GetBienDongChuyenKhoan(cmbDichVuThu_HD.SelectedValue.ToString(), int.Parse(cmbNam_HD.SelectedValue.ToString()), i));
                    }
                    dgvBienDong_HD.DataSource = dtBD;
                }
                else
                    ///chọn 1 kỳ
                    if (cmbKy_HD.SelectedIndex > 0)
                        ///chọn tất cả đợt
                        if (cmbFromDot.SelectedIndex == 0)
                        {
                            for (int i = 1; i < cmbTo_HD.Items.Count; i++)
                                dt.Merge(_cDichVuThu.GetDS(cmbDichVuThu_HD.SelectedValue.ToString(), ((TT_To)cmbTo_HD.Items[i]).MaTo, int.Parse(cmbNam_HD.SelectedValue.ToString()), int.Parse(cmbKy_HD.SelectedItem.ToString())));
                            dgvBienDong_HD.DataSource = _cDichVuThu.GetBienDongChuyenKhoan(cmbDichVuThu_HD.SelectedValue.ToString(), int.Parse(cmbNam_HD.SelectedValue.ToString()), int.Parse(cmbKy_HD.SelectedItem.ToString()));
                        }
                        else
                            ///chọn từ đợt đến đợt
                            if (cmbFromDot.SelectedIndex > 0)
                                for (int i = 1; i < cmbTo_HD.Items.Count; i++)
                                    dt.Merge(_cDichVuThu.GetDS(cmbDichVuThu_HD.SelectedValue.ToString(), ((TT_To)cmbTo_HD.Items[i]).MaTo, int.Parse(cmbNam_HD.SelectedValue.ToString()), int.Parse(cmbKy_HD.SelectedItem.ToString()), int.Parse(cmbFromDot.SelectedItem.ToString()), int.Parse(cmbToDot.SelectedItem.ToString())));
                dgvDichVuThu.DataSource = dt;
            }
            ///chọn 1 tổ
            else
                if (cmbTo_HD.SelectedIndex > 0)
                    ///chọn tất cả nhân viên
                    if (cmbNhanVien_HD.SelectedIndex == 0)
                    {
                        ///chọn tất cả kỳ
                        if (cmbKy_HD.SelectedIndex == 0)
                        {
                            dgvDichVuThu.DataSource = _cDichVuThu.GetDS(cmbDichVuThu_HD.SelectedValue.ToString(), int.Parse(cmbTo_HD.SelectedValue.ToString()), int.Parse(cmbNam_HD.SelectedValue.ToString()));
                            DataTable dt = new DataTable();
                            for (int i = 1; i <= 12; i++)
                            {
                                dt.Merge(_cDichVuThu.GetBienDongChuyenKhoan(cmbDichVuThu_HD.SelectedValue.ToString(), int.Parse(cmbTo_HD.SelectedValue.ToString()), int.Parse(cmbNam_HD.SelectedValue.ToString()), i));
                            }
                            dgvBienDong_HD.DataSource = dt;
                        }
                        else
                            ///chọn 1 kỳ
                            if (cmbKy_HD.SelectedIndex > 0)
                                ///chọn tất cả đợt
                                if (cmbFromDot.SelectedIndex == 0)
                                {
                                    dgvDichVuThu.DataSource = _cDichVuThu.GetDS(cmbDichVuThu_HD.SelectedValue.ToString(), int.Parse(cmbTo_HD.SelectedValue.ToString()), int.Parse(cmbNam_HD.SelectedValue.ToString()), int.Parse(cmbKy_HD.SelectedItem.ToString()));
                                    dgvBienDong_HD.DataSource = _cDichVuThu.GetBienDongChuyenKhoan(cmbDichVuThu_HD.SelectedValue.ToString(), int.Parse(cmbTo_HD.SelectedValue.ToString()), int.Parse(cmbNam_HD.SelectedValue.ToString()), int.Parse(cmbKy_HD.SelectedItem.ToString()));
                                }
                                else
                                    ///chọn từ đợt đến đợt
                                    if (cmbFromDot.SelectedIndex > 0)
                                        dgvDichVuThu.DataSource = _cDichVuThu.GetDS(cmbDichVuThu_HD.SelectedValue.ToString(), int.Parse(cmbTo_HD.SelectedValue.ToString()), int.Parse(cmbNam_HD.SelectedValue.ToString()), int.Parse(cmbKy_HD.SelectedItem.ToString()), int.Parse(cmbFromDot.SelectedItem.ToString()), int.Parse(cmbToDot.SelectedItem.ToString()));
                    }
                    else
                        ///chọn 1 nhân viên
                        if (cmbNhanVien_HD.SelectedIndex > 0)
                        {
                            ///chọn tất cả kỳ
                            if (cmbKy_HD.SelectedIndex == 0)
                            {
                                dgvDichVuThu.DataSource = _cDichVuThu.GetDS_NV(cmbDichVuThu_HD.SelectedValue.ToString(), int.Parse(cmbNhanVien_HD.SelectedValue.ToString()), int.Parse(cmbNam_HD.SelectedValue.ToString()));
                                DataTable dt = new DataTable();
                                for (int i = 1; i <= 12; i++)
                                {
                                    dt.Merge(_cDichVuThu.GetBienDongChuyenKhoan_NV(cmbDichVuThu_HD.SelectedValue.ToString(), int.Parse(cmbNhanVien_HD.SelectedValue.ToString()), int.Parse(cmbNam_HD.SelectedValue.ToString()), i));
                                }
                                dgvBienDong_HD.DataSource = dt;
                            }
                            else
                                ///chọn 1 kỳ
                                if (cmbKy_HD.SelectedIndex > 0)
                                    ///chọn tất cả đợt
                                    if (cmbFromDot.SelectedIndex == 0)
                                    {
                                        dgvDichVuThu.DataSource = _cDichVuThu.GetDS_NV(cmbDichVuThu_HD.SelectedValue.ToString(), int.Parse(cmbNhanVien_HD.SelectedValue.ToString()), int.Parse(cmbNam_HD.SelectedValue.ToString()), int.Parse(cmbKy_HD.SelectedItem.ToString()));
                                        dgvBienDong_HD.DataSource = _cDichVuThu.GetBienDongChuyenKhoan_NV(cmbDichVuThu_HD.SelectedValue.ToString(), int.Parse(cmbNhanVien_HD.SelectedValue.ToString()), int.Parse(cmbNam_HD.SelectedValue.ToString()), int.Parse(cmbKy_HD.SelectedItem.ToString()));
                                    }
                                    else
                                        ///chọn từ đợt đến đợt
                                        if (cmbFromDot.SelectedIndex > 0)
                                            dgvDichVuThu.DataSource = _cDichVuThu.GetDS_NV(cmbDichVuThu_HD.SelectedValue.ToString(), int.Parse(cmbNhanVien_HD.SelectedValue.ToString()), int.Parse(cmbNam_HD.SelectedValue.ToString()), int.Parse(cmbKy_HD.SelectedItem.ToString()), int.Parse(cmbFromDot.SelectedItem.ToString()), int.Parse(cmbToDot.SelectedItem.ToString()));
                        }
            CountdgvDichVuThu();
        }

        private void dgvDichVuThu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDichVuThu.Columns[e.ColumnIndex].Name == "MLT" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(2, " ");
            }
            if (dgvDichVuThu.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null && e.Value.ToString().Length == 11)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvDichVuThu.Columns[e.ColumnIndex].Name == "SoTien" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvDichVuThu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDichVuThu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void cmbTo_HD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTo_HD.SelectedIndex > 0)
            {
                List<TT_NguoiDung> lstND = _cNguoiDung.GetDSHanhThuByMaTo(int.Parse(cmbTo_HD.SelectedValue.ToString()));
                TT_NguoiDung nguoidung = new TT_NguoiDung();
                nguoidung.MaND = 0;
                nguoidung.HoTen = "Tất Cả";
                lstND.Insert(0, nguoidung);
                cmbNhanVien_HD.DataSource = lstND;
                cmbNhanVien_HD.DisplayMember = "HoTen";
                cmbNhanVien_HD.ValueMember = "MaND";
            }
            else
            {
                cmbNhanVien_HD.DataSource = null;
            }
        }
    }
}
