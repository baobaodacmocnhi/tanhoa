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

namespace ThuTien.GUI.Doi
{
    public partial class frmCuaHangThuHo : Form
    {
        string _mnu = "mnuCuaHangThuHo";
        CHoaDon _cHoaDon = new CHoaDon();
        int _selectedintdex = -1;

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
            _selectedintdex = -1;
            dgvCuaHangThuHo.DataSource = _cHoaDon.ExecuteQuery_DataTable("select * from TT_DichVuThu_CuaHang");
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
                        //CExcel fileExcel = new CExcel(dialog.FileName);
                        //DataTable dtExcel = fileExcel.GetDataTable("select * from [Sheet1]");

                        //foreach (DataRow item in dtExcel.Rows)
                        //{
                        //    string sql = "INSERT INTO TT_DichVuThu_CuaHang"
                        //               + "([ID]"
                        //               + ",[Name]"
                        //               + ",[DiaChi]"
                        //               + ",[GioHoatDong]"
                        //               + ",[TenDichVu]"
                        //               + ",[CreateBy]"
                        //               + ",[CreateDate])"
                        //               + "VALUES"
                        //               + "((select max(ID) from TT_DichVuThu_CuaHang)+1"
                        //               + ",N'" + item[0].ToString().Substring(item[0].ToString().IndexOf(" ")+1) + "'"
                        //               + ",N'" + item[1].ToString() + "'"
                        //               + ",'" + item[2].ToString() + "'"
                        //               + ",'PAYOO'"
                        //               + ",0"
                        //               + ",getDate())";
                        //    _cHoaDon.ExecuteNonQuery(sql);
                        //}

                        //Create COM Objects. Create a COM object for everything that is referenced
                        Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                        Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(dialog.FileName);
                        Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                        Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;

                        int rowCount = xlRange.Rows.Count;
                        int colCount = xlRange.Columns.Count;

                        //iterate over the rows and columns and print to the console as it appears in the file
                        //excel is not zero based!!
                        for (int i = 1; i <= rowCount; i++)
                        {
                            if (xlRange.Cells[i, 1] != null && xlRange.Cells[i, 1].Value2 != null && !string.IsNullOrEmpty(xlRange.Cells[i, 1].Value2.ToString()))
                            {
                                string sql = "INSERT INTO TT_DichVuThu_CuaHang"
                                           + "([ID]"
                                           + ",[Name]"
                                           + ",[DiaChi]"
                                           + ",[DanhBo]"
                                           + ",[CreateBy]"
                                           + ",[CreateDate])"
                                           + "VALUES"
                                           + "((select case when not exists(select * from TT_DichVuThu_CuaHang) then 1 else (select max(ID)+1 from TT_DichVuThu_CuaHang) end)"
                                           + ",N'" + xlRange.Cells[i, 1].Value2.ToString() + "'"
                                           + ",N'" + xlRange.Cells[i, 2].Value2.ToString() + "'"
                                           + ",'" + xlRange.Cells[i, 3].Value2.ToString() + "'"
                                           + "," + CNguoiDung.MaND + ""
                                           + ",getDate())";
                                _cHoaDon.ExecuteNonQuery(sql);
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
                _selectedintdex = e.RowIndex;
                txtHoTen.Text = dgvCuaHangThuHo.CurrentRow.Cells["Name1"].Value.ToString();
                txtDiaChi.Text = dgvCuaHangThuHo.CurrentRow.Cells["DiaChi"].Value.ToString();
                txtDanhBo.Text = dgvCuaHangThuHo.CurrentRow.Cells["DanhBo"].Value.ToString();
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
                    if (txtHoTen.Text.Trim() != "")
                    {
                        string sql = "INSERT INTO TT_DichVuThu_CuaHang"
                                          + "([ID]"
                                          + ",[Name]"
                                          + ",[DiaChi]"
                                          + ",[DanhBo]"
                                          + ",[CreateBy]"
                                          + ",[CreateDate])"
                                          + "VALUES"
                                          + "((select case when not exists(select * from TT_DichVuThu_CuaHang) then 1 else (select max(ID)+1 from TT_DichVuThu_CuaHang) end)"
                                          + ",N'" + txtHoTen.Text.Trim() + "'"
                                          + ",N'" + txtDiaChi.Text.Trim() + "'"
                                          + ",'" + txtDanhBo.Text.Trim() + "'"
                                          + "," + CNguoiDung.MaND + ""
                                          + ",getDate())";
                        if (_cHoaDon.ExecuteNonQuery(sql) == true)
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
                    if (_selectedintdex > -1)
                    {
                        string sql = "update TT_DichVuThu_CuaHang set"
                            + " [Name]=" + txtHoTen.Text.Trim()
                            + " ,DiaChi=" + txtDiaChi.Text.Trim()
                            + " ,DanhBo=" + txtDanhBo.Text.Trim()
                            + " ,ModifyBy=" + CNguoiDung.MaND
                            + " ,ModifyDate=getDate()"
                            + " where ID=" + dgvCuaHangThuHo["ID", _selectedintdex].Value.ToString();
                        if (_cHoaDon.ExecuteNonQuery(sql) == true)
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
                    if (_selectedintdex > -1 && MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (_cHoaDon.ExecuteNonQuery("delete TT_DichVuThu_CuaHang where ID=" + dgvCuaHangThuHo["ID", _selectedintdex].Value.ToString()) == true)
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


    }
}
