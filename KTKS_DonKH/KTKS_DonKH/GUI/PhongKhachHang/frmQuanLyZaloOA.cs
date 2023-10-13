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
using System.Xml.Linq;
using System.Web.Script.Serialization;
using KTKS_DonKH.DAL;

namespace KTKS_DonKH.GUI.PhongKhachHang
{
    public partial class frmQuanLyZaloOA : Form
    {
        string _mnu = "mnuQuanLyZaloOA";
        CGuiTinNhanZalo _cGTNZ = new CGuiTinNhanZalo();
        CTTKH _cTTKH = new CTTKH();

        public frmQuanLyZaloOA()
        {
            InitializeComponent();
        }

        private void frmZaloGuiTinNhan_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
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
                        DataTable dt = _cGTNZ.getDS_Zalo();
                        //foreach (DataRow item in dt.Rows)
                        {
                            string apiUrl = "http://192.168.90.11:1010/api/Zalo/sendMessageCupNuoc?IDZalo=4276209776391262580&message=" + en.NoiDung;
                            WebClient client = new WebClient();
                            client.Headers["Content-type"] = "application/xml";
                            client.Encoding = Encoding.UTF8;
                            string data = client.DownloadString(apiUrl);
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

            //string apiUrl = "https://openapi.zalo.me/v2.0/oa/getfollowers?access_token=SVFT5EqUDLzm_zGKw1KzNN7rtXJb0bSiSPxaEQeWH0zgYU4ViIf52764tH-41qCROhNg4FiUKHanz_aByHvDGn2WzLpCCd9d8gxi8CWr2GeXdReSoNO9D1_LgGpsQ2uv6_IX2_Li0XDhWeGhYGa45bNzkW2RL0S_3kgaUEnAB6Xpr8judaywOs3btN-lT3euRPoTAhGlVon8miKUrtHDAZZbysVL3njiBBd_8BDJ7Z9-lA4VdKWq2W6WoHRRAI034RU1D-9UCsHbMQpPq7xk13vJ&data={%22offset%22:"+j+",%22count%22:50}";
            //WebClient client = new WebClient();
            ////client.Headers["Content-type"] = "application/json";
            ////client.Encoding = Encoding.UTF8;
            //string data = client.DownloadString(apiUrl);
            //JavaScriptSerializer jss = new JavaScriptSerializer();
            //dynamic obj = jss.Deserialize<dynamic>(data);

            //for (int i = 0; i < 50; i++)
            //{
            //    string str = obj["data"]["followers"][i]["user_id"];
            //    string sql = "if not exists(select * from ZaloQuanTam where IDZalo=" + str + ")"
            //        + " insert into ZaloQuanTam(IDZalo, CreateDate)values(" + str + ", GETDATE())";
            //    _cGTNZ.excute(sql);
            //}
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (txtDanhBo.Text.Trim() != "" && e.KeyChar == 13)
                {
                    dgvDanhSach.DataSource = _cTTKH.getDS_Zalo(txtDanhBo.Text.Trim().Replace(" ", "").Replace("-", ""));
                }
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
                    System.Diagnostics.Process.Start(dgvDanhSach.CurrentRow.Cells["Avatar"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
