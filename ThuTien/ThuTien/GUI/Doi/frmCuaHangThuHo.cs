using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.ChuyenKhoan;
using ThuTien.DAL.Doi;
using System.Net;
using System.IO;
using ThuTien.DAL.QuanTri;
using System.Runtime.InteropServices;
using ThuTien.LinQ;

namespace ThuTien.GUI.Doi
{
    public partial class frmCuaHangThuHo : Form
    {
        string _mnu = "mnuCuaHangThuHo";
        CHoaDon _cHoaDon = new CHoaDon();
        CCuaHangThuHo _cCHTH = new CCuaHangThuHo();
        TT_DichVuThu_CuaHang _en = null;

        public frmCuaHangThuHo()
        {
            InitializeComponent();
        }

        private void frmCuaHangThuHo_Load(object sender, EventArgs e)
        {
            dgvCuaHangThuHo.AutoGenerateColumns = false;
            dgvCuaHangThuHo.DataSource = _cHoaDon.ExecuteQuery_DataTable("select * from TT_DichVuThu_CuaHang");
        }

        public void Clear()
        {
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtDanhBo.Text = "";
            _en = null;
            dgvCuaHangThuHo.DataSource = _cCHTH.getDS();
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                dialog.Multiselect = false;

                if (dialog.ShowDialog() == DialogResult.OK)
                    if (MessageBox.Show("Bạn có chắc chắn Thêm?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        //Create COM Objects. Create a COM object for everything that is referenced
                        Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                        Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(dialog.FileName);
                        Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                        Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;

                        int rowCount = xlRange.Rows.Count;
                        int colCount = xlRange.Columns.Count;

                        //iterate over the rows and columns and print to the console as it appears in the file
                        //excel is not zero based!!
                        for (int i = 3; i <= rowCount; i++)
                        {
                            if (xlRange.Cells[i, 2] != null && xlRange.Cells[i, 2].Value2 != null && !string.IsNullOrEmpty(xlRange.Cells[i, 2].Value2.ToString())
                                && xlRange.Cells[i, 3] != null && xlRange.Cells[i, 3].Value2 != null && !string.IsNullOrEmpty(xlRange.Cells[i, 3].Value2.ToString()))
                            {
                                if (_cCHTH.checkExists_DiaChi(xlRange.Cells[i, 3].Value2.ToString()) == true)
                                {
                                    MessageBox.Show("Địa chỉ: " + xlRange.Cells[i, 3].Value2.ToString() + " đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    TT_DichVuThu_CuaHang en = new TT_DichVuThu_CuaHang();
                                    en.Name = xlRange.Cells[i, 2].Value2.ToString().Trim().Replace("'", "");
                                    en.DiaChi = xlRange.Cells[i, 3].Value2.ToString().Trim();
                                    if (xlRange.Cells[i, 6] != null && xlRange.Cells[i, 6].Value2 != null && !string.IsNullOrEmpty(xlRange.Cells[i, 6].Value2.ToString()))
                                        en.DanhBo = xlRange.Cells[i, 6].Value2.ToString().Trim().Replace(" ", "");
                                    if (_cCHTH.Them(en) == true)
                                    {
                                    }
                                }
                            }
                        }

                        //cleanup
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        //rule of thumb for releasing com objects:
                        //  never use two dots, all COM objects must be referenced and released individually
                        //  ex: [somthing].[something].[something] is bad
                        //release com objects to fully kill excel process from running in the background
                        Marshal.ReleaseComObject(xlRange);
                        Marshal.ReleaseComObject(xlWorksheet);
                        //close and release
                        xlWorkbook.Close();
                        Marshal.ReleaseComObject(xlWorkbook);
                        //quit and release
                        xlApp.Quit();
                        Marshal.ReleaseComObject(xlApp);

                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi, Vui lòng thử lại\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCuaHangThuHo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _en = _cCHTH.get(int.Parse(dgvCuaHangThuHo.CurrentRow.Cells["ID"].Value.ToString()));
                if (_en != null)
                {
                    txtHoTen.Text = _en.Name;
                    txtDiaChi.Text = _en.DiaChi;
                    txtDanhBo.Text = _en.DanhBo;
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    if (txtHoTen.Text.Trim() != "" && txtDiaChi.Text.Trim() != "")
                    {
                        if (_cCHTH.checkExists_DiaChi(txtDiaChi.Text.Trim()) == true)
                        {
                            MessageBox.Show("Địa chỉ đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        TT_DichVuThu_CuaHang en = new TT_DichVuThu_CuaHang();
                        en.Name = txtHoTen.Text.Trim();
                        en.DiaChi = txtDiaChi.Text.Trim();
                        en.DanhBo = txtDanhBo.Text.Trim();
                        if (_cCHTH.Them(en) == true)
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (_en != null)
                    {
                        if (_cCHTH.checkExists_DiaChi(txtDiaChi.Text.Trim()) == true)
                        {
                            MessageBox.Show("Địa chỉ đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        _en.Name = txtHoTen.Text.Trim();
                        _en.DiaChi = txtDiaChi.Text.Trim();
                        _en.DanhBo = txtDanhBo.Text.Trim();
                        if (_cCHTH.Sua(_en) == true)
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
                {
                    if (_en != null && MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (_cCHTH.Xoa(_en) == true)
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
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

        private void dgvCuaHangThuHo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvCuaHangThuHo.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }


    }
}
