using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DocSo_PC.DAL
{
    static class CFormat
    {
        public static void GirdFormat(DataGridView dg)
        {
            for (int i = 0; i < dg.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    dg.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(217)))));
                }
                else
                {
                    dg.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                }
            }
        }

        public static string NgayVN(DateTime d1)
        {
            string kq = "";
            string ngay;
            string thang;
            string nam = d1.Year.ToString();

            if (d1.Day < 10)
            {
                ngay = "0" + d1.Day.ToString();
            }
            else
            {
                ngay = d1.Day.ToString();
            }
            if (d1.Month < 10)
            {
                thang = "0" + d1.Month.ToString();
            }
            else
            {
                thang = d1.Month.ToString();
            }
            kq = kq + ngay + "/" + thang + "/" + nam;
            return kq;
        }

    }
}
