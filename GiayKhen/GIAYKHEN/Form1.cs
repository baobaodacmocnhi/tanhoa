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
        public Form1()
        {
            InitializeComponent();
            this.txtQDNm.Focus();

        }
        private DataSet getData()
        {
            GKDataContext db = new GKDataContext();
            DataSet ds = new DataSet();

            string query = "";
            if (comboBox1.SelectedIndex == 0)
                query = "select * FROM A_GIAYKHEN WHERE TAPTHE=0 AND CONGDOAN=0";
            if (comboBox1.SelectedIndex == 1)
                query = "select * FROM A_GIAYKHEN WHERE TAPTHE=1 AND CONGDOAN=0";
            SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection.ConnectionString);

            adapter.Fill(ds, "A_GIAYKHEN");
            return ds;
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            DataTable dt = getData().Tables[0];
            //foreach (DataRow item in dt.Rows)
            //{
            //    item["HOTEN"] = UNI_2_TCVN3(item["HOTEN"].ToString());
            //    item["CHUCVU"] = UNI_2_TCVN3(item["CHUCVU"].ToString());
            //    item["PHONGBAN"] = UNI_2_TCVN3(item["PHONGBAN"].ToString());
            //}
            ReportDocument rp = new ReportDocument();
            if (comboBox1.SelectedIndex == 0)
                rp = new ChinhQuyen_CANHAN();
            else
                if (comboBox1.SelectedIndex == 1)
                    rp = new ChinhQuyen_TAPTHE();
            //ReportDocument rp = new GKCongDoan_CANHAN();
            rp.SetDataSource(dt);
            rp.SetParameterValue("qdNam", this.txtQDNm.Text);
            if (comboBox1.SelectedIndex == 0)
                rp.SetParameterValue("qd", this.txtQuyetDinhCaNhan.Text);
            else
                if (comboBox1.SelectedIndex == 1)
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
            comboBox1.SelectedIndex = 0;
            txtNgay.Value = new DateTime(2019, 01, 11);
        }
    }
}