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

namespace ThuTien.GUI.Doi
{
    public partial class frmCuaHangThuHo : Form
    {
        CHoaDon _cHoaDon = new CHoaDon();

        public frmCuaHangThuHo()
        {
            InitializeComponent();
        }

        private void frmCuaHangThuHo_Load(object sender, EventArgs e)
        {
            dgvCuaHangThuHo.AutoGenerateColumns = false;
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
                        CExcel fileExcel = new CExcel(dialog.FileName);
                        DataTable dtExcel = fileExcel.GetDataTable("select * from [Page58$]");

                        foreach (DataRow item in dtExcel.Rows)
                        {
                            string sql = "INSERT INTO TT_DichVuThu_CuaHang"
                                       + "([ID]"
                                       + ",[Name]"
                                       + ",[DiaChi]"
                                       + ",[GioHoatDong]"
                                       + ",[TenDichVu]"
                                       + ",[CreateBy]"
                                       + ",[CreateDate])"
                                       + "VALUES"
                                       + "((select max(ID) from TT_DichVuThu_CuaHang)+1"
                                       + ",N'" + item[0].ToString().Substring(item[0].ToString().IndexOf(" ")+1) + "'"
                                       + ",N'" + item[1].ToString() + "'"
                                       + ",'" + item[2].ToString() + "'"
                                       + ",'PAYOO'"
                                       + ",0"
                                       + ",getDate())";
                            _cHoaDon.ExecuteNonQuery(sql);
                        }
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvCuaHangThuHo.DataSource = _cHoaDon.ExecuteQuery_DataTable("select * from TT_DichVuThu_CuaHang");
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
                //string url = "https://maps.googleapis.com/maps/api/geocode/json?address=" + dgvCuaHangThuHo.CurrentRow.Cells["DiaChi"].Value.ToString().Replace(" ","+") + "&key=AIzaSyD-NJFGGxGO_RGTZtQ6kvhqU3r_vEULGr8";
                string url = "https://maps.googleapis.com/maps/api/geocode/json?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&key=AIzaSyAA7tRqy9iDfjJ-RoP6Cs6ulrKTqjtCpns";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = 0;
                request.Expect = "application/json";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    MessageBox.Show(reader.ReadToEnd(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
