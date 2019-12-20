using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL.PhongKhachHang;
using KTKS_DonKH.LinQ;
using System.Net;

namespace KTKS_DonKH.GUI.PhongKhachHang
{
    public partial class frmGuiTinNhanZalo : Form
    {
        string _mnu = "mnuGuiTinNhanZalo";
        CGuiTinNhanZalo _cGTNZ = new CGuiTinNhanZalo();
 
        public frmGuiTinNhanZalo()
        {
            InitializeComponent();
        }

        private void frmZaloGuiTinNhan_Load(object sender, EventArgs e)
        {
            dgvTinNhan.AutoGenerateColumns = false;
            dgvTinNhan.DataSource = _cGTNZ.getDS();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
                {
                    KH_GuiTinNhanZalo en = new KH_GuiTinNhanZalo();
                    en.NoiDung = txtNoiDung.Text.Trim();
                    if (_cGTNZ.them(en) == true)
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNoiDung.Text = "";
                        dgvTinNhan.DataSource = _cGTNZ.getDS();

                        //4276209776391262580
                        //DataTable dt = _cGTNZ.getDS_Zalo();
                        //foreach (DataRow item in dt.Rows)
                        //{
                        //    string apiUrl = "http://192.168.90.11:1010/api/Zalo/sendMessage?IDZalo="+item["IDZalo"]+"&message=" + en.NoiDung;
                        //    WebClient client = new WebClient();
                        //    client.Headers["Content-type"] = "application/xml";
                        //    client.Encoding = Encoding.UTF8;
                        //    string data = client.DownloadString(apiUrl);
                        //}
                        string apiUrl = "http://192.168.90.11:1010/api/Zalo/sendMessageCupNuoc?IDZalo=4276209776391262580&message=" + en.NoiDung;
                        WebClient client = new WebClient();
                        client.Headers["Content-type"] = "application/xml";
                        client.Encoding = Encoding.UTF8;
                        string data = client.DownloadString(apiUrl);
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

    }
}
