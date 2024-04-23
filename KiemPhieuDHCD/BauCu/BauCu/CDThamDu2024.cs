using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BauCu
{
    public partial class CDThamDu2024 : Form
    {
        dbDH_CODONGDataContext db = new dbDH_CODONGDataContext();
        int _ticks = 0;
        public CDThamDu2024()
        {
            InitializeComponent();
            FormLoad();
            timer1.Start();
        }
        public void FormLoad()
        {
            try
            {
                String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", db.DSCODONG_THAMDUs.Count());

                if (db.DSCODONG_THAMDUs.Count() > 0)
                    lbSL.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", db.DSCODONG_THAMDUs.Count());
                else
                    lbSL.Text = "0";

                double _cpTC=0;
                if (db.DSCODONG_THAMDUs.Count() > 0)
                    _cpTC = db.DSCODONG_THAMDUs.Sum(item => item.TONGCD.Value);
                else
                    _cpTC = 0;

                if (_cpTC > 0)
                    lbCP.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _cpTC);
                else
                    lbCP.Text = "0";

                double tl = _cpTC / double.Parse(db.DSCODONGs.Sum(item => item.TONGCD.Value) + "");

                lbTL.Text = String.Format("{0:0.##}", tl * 100).Replace(".",",") + "%";
                lbTime.Text = DateTime.Now.ToString("HH:mm");

            }
            catch (Exception ex)
            {
                
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _ticks++;
            if (_ticks % 2 == 0)
                FormLoad();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 o = new Form1();
            o.ShowDialog();
        }

        private void CDThamDu_Load(object sender, EventArgs e)
        {

        }
    }
}
