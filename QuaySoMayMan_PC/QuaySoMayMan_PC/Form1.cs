using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using WMPLib;

namespace QuaySoMayMan_PC
{
    public partial class Form1 : Form
    {
        CDAL _cDAL = new CDAL();
        WindowsMediaPlayer myplayerQuay = new WindowsMediaPlayer();
        WindowsMediaPlayer myplayerKQ = new WindowsMediaPlayer();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CDAL._dtExcel = _cDAL.ExcelToDataTable(AppDomain.CurrentDomain.BaseDirectory + "\\danhsach.xlsx");

            myplayerQuay.URL = AppDomain.CurrentDomain.BaseDirectory + @"nhacxosokienthiet.mp3";
            myplayerKQ.URL = AppDomain.CurrentDomain.BaseDirectory + @"chucmungchienthang.mp3";
            myplayerQuay.controls.stop();
            myplayerKQ.controls.stop();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (chkNhac.Checked)
                    myplayerQuay.controls.play();

                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;

                timer1.Enabled = true;
                timer2.Enabled = true;
                timer3.Enabled = true;

                int number = RandomNumber();
                while (_cDAL.checkExist_Quay(number) == true)
                {
                    number = RandomNumber();
                }
                string str = number.ToString("000");

                wait(5000);
                timer1.Enabled = false;
                textBox1.Text = str.Substring(0, 1);
                textBox1.BackColor = Color.Lime;
                wait(2000);
                timer2.Enabled = false;
                textBox2.Text = str.Substring(1, 1);
                textBox2.BackColor = Color.Lime;
                wait(2000);
                timer3.Enabled = false;
                textBox3.Text = str.Substring(2, 1);
                textBox3.BackColor = Color.Lime;

                wait(2000);
                if (chkNhac.Checked)
                    myplayerQuay.controls.stop();

                if (chkNhac.Checked)
                    myplayerKQ.controls.play();

                DataTable dt = _cDAL.get_KhachMoi(number);
                if (dt != null && dt.Rows.Count > 0)
                {
                    label1.Text = int.Parse(dt.Rows[0]["STT"].ToString()).ToString("000");
                    label2.Text = dt.Rows[0]["HoTen"].ToString();
                    label3.Text = dt.Rows[0]["CongTy"].ToString();
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    textBox3.Visible = false;

                    int x = (this.Width / 2) - (label1.Width / 2);
                    label1.Location = new Point(x, label1.Location.Y);

                    x = (this.Width / 2) - (label2.Width / 2);
                    label2.Location = new Point(x, label2.Location.Y);

                    x = (this.Width / 2) - (label3.Width / 2);
                    label3.Location = new Point(x, label3.Location.Y);
                }

                _cDAL.update_Quay(number);
            }
        }

        public static void wait(int milliseconds)
        {
            System.Windows.Forms.Timer timer5 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;
            timer5.Interval = milliseconds;
            timer5.Enabled = true;
            timer5.Start();
            timer5.Tick += (s, e) =>
            {
                timer5.Enabled = false;
                timer5.Stop();
            };
            while (timer5.Enabled)
            {
                Application.DoEvents();
            }
        }

        private readonly Random _random = new Random();

        public int RandomNumber()
        {
            return _random.Next(1, 542);
        }

        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = RandomNumber(0, 9).ToString();
            if (textBox1.BackColor.Name == "Red")
                textBox1.BackColor = Color.Yellow;
            else
                textBox1.BackColor = Color.Red;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            textBox2.Text = RandomNumber(0, 9).ToString();
            if (textBox2.BackColor.Name == "Red")
                textBox2.BackColor = Color.Yellow;
            else
                textBox2.BackColor = Color.Red;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            textBox3.Text = RandomNumber(0, 9).ToString();
            if (textBox3.BackColor.Name == "Red")
                textBox3.BackColor = Color.Yellow;
            else
                textBox3.BackColor = Color.Red;
        }

        private void btnResetAll_Click(object sender, EventArgs e)
        {
            _cDAL.update_ResetQuay();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _cDAL.update_ResetQuay(int.Parse(txtSTT.Text.Trim()));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Tạo các đối tượng Excel
            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            oExcel.Workbooks.Add();

            Microsoft.Office.Interop.Excel._Worksheet workSheet = oExcel.ActiveSheet;

            // Tạo tiêu đề cột 
            workSheet.Cells[1, 1] = "STT";
            workSheet.Cells[1, 2] = "HoTen";
            workSheet.Cells[1, 3] = "CongTy";
            workSheet.Cells[1, 4] = "Quay";

            for (int i = 0; i < CDAL._dtExcel.Rows.Count; i++)
            {
                workSheet.Cells[i + 2, 1] = CDAL._dtExcel.Rows[i][0];
                workSheet.Cells[i + 2, 2] = CDAL._dtExcel.Rows[i][1];
                workSheet.Cells[i + 2, 3] = CDAL._dtExcel.Rows[i][2];
                workSheet.Cells[i + 2, 4] = CDAL._dtExcel.Rows[i][3];
            }
            workSheet.SaveAs("danhsach.xlsx");
            oExcel.Quit();
        }

    }
}
