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
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;

namespace ThuTien.GUI.Doi
{
    public partial class frmDieuChinhMLT : Form
    {
        string _mnu = "mnuDieuChinhMLT";
        CHoaDon _cHoaDon = new CHoaDon();

        public frmDieuChinhMLT()
        {
            InitializeComponent();
        }

        private void frmDieuChinhMLT_Load(object sender, EventArgs e)
        {

        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                dialog.Multiselect = false;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    CExcel fileExcel = new CExcel(dialog.FileName);
                    DataTable dtExcel = fileExcel.GetDataTable("select * from [Sheet1$]");

                    foreach (DataRow item in dtExcel.Rows)
                        if ((string.IsNullOrEmpty(item[0].ToString()) || item[0].ToString().Replace(" ", "").Length == 11) && !string.IsNullOrEmpty(item[1].ToString().Replace(" ","")))
                        {
                            ListViewItem lvi = new ListViewItem();
                            lvi.Text = item[0].ToString().Replace(" ", "");
                            lvi.SubItems.Add(item[1].ToString().Replace(" ", ""));
                            lvi.Name = item[0].ToString().Replace(" ", "");

                            lstView_A.Items.Add(lvi);

                            DataTable dt = _cHoaDon.GetDSTon_DieuChinhMLT(item[0].ToString().Replace(" ", ""), item[1].ToString().Replace(" ", ""));
                            foreach (DataRow itemR in dt.Rows)
                            {
                                ListViewItem lviR = new ListViewItem();
                                lviR.Text = itemR["SoHoaDon"].ToString();
                                lviR.SubItems.Add(itemR["Ky"].ToString());
                                lviR.SubItems.Add(itemR["SoHoaDon"].ToString());
                                lviR.SubItems.Add(itemR["MLT"].ToString());
                                lviR.SubItems.Add(item[1].ToString().Replace(" ", ""));
                                lviR.Name = itemR["MaHD"].ToString();

                                lstView_B.Items.Add(lviR);
                            }
                        }
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi, Vui lòng thử lại " + ex.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    foreach (ListViewItem item in lstView_B.Items)
                    {
                        string Dot, May, Stt;
                        Dot=item.SubItems[4].Text.Substring(0,2);
                        May = item.SubItems[4].Text.Substring(2, 2);
                        Stt = item.SubItems[4].Text.Substring(4, 5);
                        string sql = "update HOADON set DOT=" + Dot + ",MAY='" + May + "',STT='" + Stt + "',MALOTRINH='" + item.SubItems[4].Text + "' where ID_HOADON=" + item.Name;
                        _cHoaDon.LinQ_ExecuteNonQuery(sql);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi, Vui lòng thử lại "+ex.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }            
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
