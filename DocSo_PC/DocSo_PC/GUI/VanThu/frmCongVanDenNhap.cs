using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.VanThu;
using DocSo_PC.DAL;
using DocSo_PC.LinQ;
using DocSo_PC.DAL.QuanTri;

namespace DocSo_PC.GUI.VanThu
{
    public partial class frmCongVanDenNhap : Form
    {
        string _mnu = "mnuCongVanDen";
        CCongVanDen _cCVD = new CCongVanDen();
        CThuongVu _cThuongVu = new CThuongVu();
        CGanMoi _cGanMoi = new CGanMoi();

        public frmCongVanDenNhap()
        {
            InitializeComponent();
        }

        private void frmCongVanDenNhap_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
            cmbLoaiVanBan.SelectedIndex = 0;
        }

        public void Clear()
        {
            txtMaDon.Text.Trim();
            txtMaDon.Focus();
            dgvDanhSach.DataSource = null;
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDon.Text.Trim() != "")
            {
                DonTu_ChiTiet dontu_ChiTiet = null;
                if (txtMaDon.Text.Trim().Contains(".") == true)
                {
                    string[] MaDons = txtMaDon.Text.Trim().Split('.');
                    dontu_ChiTiet = _cThuongVu.get_ChiTiet(decimal.Parse(MaDons[0]), decimal.Parse(MaDons[1]));
                }
                else
                {
                    LinQ.DonTu dt = _cThuongVu.get(decimal.Parse(txtMaDon.Text.Trim()));
                    if (dt != null)
                        dontu_ChiTiet = dt.DonTu_ChiTiets.SingleOrDefault();
                }
                switch (cmbLoaiVanBan.SelectedItem.ToString())
                {
                    case "Biên Bản Kiểm Tra":
                        if (dontu_ChiTiet != null)
                            dgvDanhSach.DataSource = _cThuongVu.getDS_KTXM(dontu_ChiTiet.MaDon.Value, dontu_ChiTiet.STT.Value);
                        else
                            dgvDanhSach.DataSource = _cThuongVu.getDS_KTXM(txtMaDon.Text.Trim().Replace(" ", "").Replace("-", ""));
                        break;
                    case "TB Cắt Tạm/Cắt Hủy":
                        if (dontu_ChiTiet != null)
                            dgvDanhSach.DataSource = _cThuongVu.getDS_CHDB(dontu_ChiTiet.MaDon.Value, dontu_ChiTiet.STT.Value);
                        else
                            dgvDanhSach.DataSource = _cThuongVu.getDS_CHDB(txtMaDon.Text.Trim().Replace(" ", "").Replace("-", ""));
                        break;
                    case "Tờ Trình":
                        if (dontu_ChiTiet != null)
                            dgvDanhSach.DataSource = _cThuongVu.getDS_ToTrinh(dontu_ChiTiet.MaDon.Value, dontu_ChiTiet.STT.Value);
                        else
                            dgvDanhSach.DataSource = _cThuongVu.getDS_ToTrinh(txtMaDon.Text.Trim().Replace(" ", "").Replace("-", ""));
                        break;
                    case "Biên Bản Nghiệm Thu":
                        dgvDanhSach.DataSource = _cGanMoi.getDS_BBNT(txtMaDon.Text.Trim().Replace(" ", "").Replace("-", ""));
                        break;
                    default:
                        break;
                }
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = _cCVD.getDS(dateTu.Value, dateDen.Value);
        }

        private void dgvDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDanhSach_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDanhSach.Columns[e.ColumnIndex].Name == "XemHinh")
                {
                    string TableNameHinh, IDName;
                    _cThuongVu.getTableHinh(dgvDanhSach.CurrentRow.Cells["TableName"].Value.ToString(), out TableNameHinh, out IDName);
                    System.Diagnostics.Process.Start("https://service.cskhtanhoa.com.vn/ThuongVu/viewFile?TableName=" + TableNameHinh + "&IDFileName=" + IDName + "&IDFileContent=" + dgvDanhSach.CurrentRow.Cells["IDCT"].Value.ToString());
                }
            }
            catch { }
        }

        private void dgvDanhSach_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    if (dgvDanhSach.CurrentRow.Cells["NoiDung"].Value == null || string.IsNullOrEmpty(dgvDanhSach.CurrentRow.Cells["NoiDung"].Value.ToString().Trim()))
                    {
                        MessageBox.Show("Nội Dung rỗng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    CongVanDen en = new CongVanDen();
                    en.LoaiVB = dgvDanhSach.CurrentRow.Cells["LoaiVB"].Value.ToString();
                    en.NoiChuyen = dgvDanhSach.CurrentRow.Cells["NoiChuyen"].Value.ToString();
                    //en.NgayChuyen = DateTime.Parse(dgvDanhSach.CurrentRow.Cells["NgayChuyen"].Value.ToString());
                    en.MLT = dgvDanhSach.CurrentRow.Cells["MLT"].Value.ToString();
                    en.DanhBo = dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString();
                    en.HoTen = dgvDanhSach.CurrentRow.Cells["HoTen"].Value.ToString();
                    en.DiaChi = dgvDanhSach.CurrentRow.Cells["DiaChi"].Value.ToString();
                    en.NoiDung = dgvDanhSach.CurrentRow.Cells["NoiDung"].Value.ToString();
                    en.MaDon = dgvDanhSach.CurrentRow.Cells["MaDon"].Value.ToString();
                    en.TableName = dgvDanhSach.CurrentRow.Cells["TableName"].Value.ToString();
                    en.IDCT = int.Parse(dgvDanhSach.CurrentRow.Cells["IDCT"].Value.ToString());
                    if (_cCVD.checkExists(en.TableName, en.IDCT.Value) == true)
                    {
                        MessageBox.Show("Đã nhập rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (_cCVD.Them(en) == true)
                    {
                        //CThuongVu._cDAL.ExecuteNonQuery("update CongVanDi set Nhan_QLDHN=1,Nhan_QLDHN_Ngay=getdate() where ID=" + dgvDanhSach.CurrentRow.Cells["ID"].Value.ToString());
                        string sql = "insert into TB_GHICHU(DANHBO,DONVI,NOIDUNG,CREATEDATE,CREATEBY)values('" + en.DanhBo + "',N'QLDHN',N'" + en.NoiDung + "','" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture) + "',N'" + CNguoiDung.HoTen + "')";
                        CDHN._cDAL.ExecuteNonQuery(sql);
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Xoa") && MessageBox.Show("Bạn chắc chắn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CongVanDen en = _cCVD.get(int.Parse(dgvDanhSach.CurrentRow.Cells["ID"].Value.ToString()));
                    if (en != null)
                    {
                        if (_cCVD.Xoa(en))
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
