using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace GIAYKHEN
{
    public partial class Form1 : Form
    {
        GKDataContext db = new GKDataContext();

        public Form1()
        {
            InitializeComponent();
            this.txtQDNm.Focus();

        }
        private DataSet getData(string sql)
        {

            DataSet ds = new DataSet();

            SqlDataAdapter adapter = new SqlDataAdapter(sql, db.Connection.ConnectionString);

            adapter.Fill(ds, "A_GIAYKHEN");
            return ds;
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            string sql = "";
            //foreach (DataRow item in dt.Rows)
            //{
            //    item["HOTEN"] = UNI_2_TCVN3(item["HOTEN"].ToString());
            //    item["CHUCVU"] = UNI_2_TCVN3(item["CHUCVU"].ToString());
            //    item["PHONGBAN"] = UNI_2_TCVN3(item["PHONGBAN"].ToString());
            //}
            ReportDocument rp = new ReportDocument();
            if (cmbGiayKhen.SelectedIndex > -1)
                if (cmbGiayKhen.SelectedItem.ToString() == "Công ty")
                {
                    if (cmbNhom.SelectedIndex == 0)
                    {
                        sql = "select * FROM A_GIAYKHEN WHERE TAPTHE=0 and CongDoan=0 and DoanThanhNien=0 and DangBo=0 and DanVanKheo=0";
                        rp = new ChinhQuyen_CANHAN_A3();
                    }
                    else
                        if (cmbNhom.SelectedIndex == 1)
                        {
                            sql = "select * FROM A_GIAYKHEN WHERE TAPTHE=1 and CongDoan=0 and DoanThanhNien=0 and DangBo=0 and DanVanKheo=0";
                            rp = new ChinhQuyen_TAPTHE_A3();
                        }
                }
                else
                    if (cmbGiayKhen.SelectedItem.ToString() == "Công đoàn")
                    {
                        if (cmbNhom.SelectedIndex == 0)
                        {
                            sql = "select * FROM A_GIAYKHEN WHERE TAPTHE=0 and CongDoan=1";
                            rp = new TLD_GKCongDoan_CANHAN_2021();
                        }
                        else
                            if (cmbNhom.SelectedIndex == 1)
                            {
                                sql = "select * FROM A_GIAYKHEN WHERE TAPTHE=1 and CongDoan=1";
                                rp = new TLD_GKCongDoan_TAPTHE_2021();
                            }
                    }
                    else
                        if (cmbGiayKhen.SelectedItem.ToString() == "Đảng")
                        {
                            if (cmbNhom.SelectedIndex == 0)
                            {
                                sql = "select * FROM A_GIAYKHEN WHERE TAPTHE=0 and DangBo=1";
                                rp = new DangBo_CANHAN_A3_2021();
                            }
                            else
                                if (cmbNhom.SelectedIndex == 1)
                                {
                                    sql = "select * FROM A_GIAYKHEN WHERE TAPTHE=1 and DangBo=1";
                                    rp = new DangBo_TAPTHE_A3();
                                }
                        }
                        else
                            if (cmbGiayKhen.SelectedItem.ToString() == "Đoàn thanh niên")
                            {
                                if (cmbNhom.SelectedIndex == 0)
                                {
                                    sql = "select * FROM A_GIAYKHEN WHERE TAPTHE=0 and DoanThanhNien=1";
                                    rp = new DoanThanhNien_CANHAN();
                                }
                                else
                                    if (cmbNhom.SelectedIndex == 1)
                                    {
                                        sql = "select * FROM A_GIAYKHEN WHERE TAPTHE=1 and DoanThanhNien=1";
                                        rp = new DoanThanhNien_TAPTHE();
                                    }
                            }
                            else
                                if (cmbGiayKhen.SelectedItem.ToString() == "Gương 5 năm")
                                {
                                    if (cmbNhom.SelectedIndex == 0)
                                    {
                                        sql = "select * FROM A_GIAYKHEN WHERE TAPTHE=0 and Guong=1";
                                        rp = new GuongDienHinh5nam_CANHAN_A3();
                                    }
                                    else
                                        if (cmbNhom.SelectedIndex == 1)
                                        {
                                            sql = "select * FROM A_GIAYKHEN WHERE TAPTHE=1 and Guong=1";
                                            rp = new GuongDienHinh5nam_TAPTHE_A3();
                                        }
                                }
                                else
                                    if (cmbGiayKhen.SelectedItem.ToString() == "HCM")
                                    {
                                        if (cmbNhom.SelectedIndex == 0)
                                        {
                                            sql = "select * FROM A_GIAYKHEN WHERE TAPTHE=0 and HCM=1";
                                            rp = new HCM_CANHAN_ddmmyyyy_A3();
                                        }
                                        else
                                            if (cmbNhom.SelectedIndex == 1)
                                            {
                                                sql = "select * FROM A_GIAYKHEN WHERE TAPTHE=1 and HCM=1";
                                                rp = new HCM_TAPTHE_ddmmyyyy_A3();
                                            }
                                    }
                                    else
                                        if (cmbGiayKhen.SelectedItem.ToString() == "Dân vận khéo")
                                        {
                                            if (cmbNhom.SelectedIndex == 0)
                                            {
                                                sql = "select * FROM A_GIAYKHEN WHERE TAPTHE=0 and DanVanKheo=1";
                                                rp = new DanVanKheo_CANHAN_A3_2022B();
                                            }
                                            else
                                                if (cmbNhom.SelectedIndex == 1)
                                                {
                                                    sql = "select * FROM A_GIAYKHEN WHERE TAPTHE=1 and DanVanKheo=1";
                                                    rp = new DanVanKheo_TAPTHE_A3_2022();
                                                }
                                        }

            DataTable dt = getData(sql).Tables[0];
            //ReportDocument rp = new GKCongDoan_CANHAN();
            rp.SetDataSource(dt);
            rp.SetParameterValue("qdNam", this.txtQDNm.Text);
            if (cmbNhom.SelectedIndex == 0)
                rp.SetParameterValue("qd", this.txtQuyetDinhCaNhan.Text);
            else
                if (cmbNhom.SelectedIndex == 1)
                    rp.SetParameterValue("qd", this.txtQuyetDinhTapThe.Text);
            rp.SetParameterValue("ngay", this.txtNgay.Value.ToString("dd"));
            rp.SetParameterValue("thang", this.txtNgay.Value.ToString("MM"));
            rp.SetParameterValue("nam", this.txtNgay.Value.ToString("yyyy"));
            rp.SetParameterValue("gk", txtNguoiKy.Text);
            crystalReportViewer1.ReportSource = rp;
        }

        private string UNI_2_TCVN3(string text)
        {
            string[] UNI = { "à", "á", "ả", "ã", "ạ", "ă", "ằ", "ắ", "ẳ", "ẵ", "ặ", "â", "ầ", "ấ", "ẩ", "ẫ", "ậ", "đ", "è", "é", "ẻ", "ẽ", "ẹ", "ê", "ề", "ế", "ể", "ễ", "ệ", "ì", "í", "ỉ", "ĩ", "ị", "ò", "ó", "ỏ", "õ", "ọ", "ô", "ồ", "ố", "ổ", "ỗ", "ộ", "ơ", "ờ", "ớ", "ở", "ỡ", "ợ", "ù", "ú", "ủ", "ũ", "ụ", "ư", "ừ", "ứ", "ử", "ữ", "ự", "ỳ", "ý", "ỷ", "ỹ", "ỵ", "Ă", "Â", "Đ", "Ê", "Ô", "Ơ", "Ư" };
            string[] TCVN3 = { "µ", "¸", "¶", "·", "¹", "¨", "»", "¾", "¼", "½", "Æ", "©", "Ç", "Ê", "È", "É", "Ë", "®", "Ì", "Ð", "Î", "Ï", "Ñ", "ª", "Ò", "Õ", "Ó", "Ô", "Ö", "×", "Ý", "Ø", "Ü", "Þ", "ß", "ã", "á", "â", "ä", "«", "å", "è", "æ", "ç", "é", "¬", "ê", "í", "ë", "ì", "î", "ï", "ó", "ñ", "ò", "ô", "­", "õ", "ø", "ö", "÷", "ù", "ú", "ý", "û", "ü", "þ", "¡", "¢", "§", "£", "¤", "¥", "¦" };

            for (int i = 0; i < UNI.Length; i++)
            {
                text.Replace(UNI[i], TCVN3[i]);
            }

            return text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbGiayKhen.SelectedIndex = 0;
            cmbNhom.SelectedIndex = 0;
            txtNgay.Value = new DateTime(2023, 11, 08);
        }

        private void txtQuyetDinhCaNhan_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            frmNhap frm = new frmNhap();
            frm.ShowDialog();
        }

    }
}
