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
    public partial class frmHienThi : Form
    {
        CDAL _cDAL = new CDAL();

        public frmHienThi()
        {
            InitializeComponent();
        }

        private void frmHienThi_Load(object sender, EventArgs e)
        {
            CDAL._dtExcel = _cDAL.ExcelToDataTable(AppDomain.CurrentDomain.BaseDirectory + "\\danhsach.xlsx");
        }

        private void txtSTT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtSTT.Text.Trim() != "" && e.KeyChar == 13)
            {
                DataRow[] dr = CDAL._dtExcel.Select("STT='" + txtSTT.Text.Trim() + "'");
                if (dr != null && dr.Count() > 0)
                {
                    label1.Text = int.Parse(dr[0]["STT"].ToString()).ToString("000");
                    label2.Text = dr[0]["HoTen"].ToString();
                    label3.Text = dr[0]["CongTy"].ToString();
                }
                else
                {
                    label1.Text = txtSTT.Text.Trim();
                    label2.Text = "Không tồn tại";
                    label3.Text = "";
                }
            }
        }



    }
}
