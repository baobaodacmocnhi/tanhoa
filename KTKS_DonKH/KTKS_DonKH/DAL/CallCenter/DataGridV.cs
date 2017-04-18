using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using DevComponents.DotNetBar.Controls;
namespace KTKS_DonKH.Utilities
{
    public class DataGridV
    {
        public static void formatRows(DataGridView dview) {
            for (int i = 0; i < dview.Rows.Count; i++) {
                if (i % 2 == 0)
                {
                    dview.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(217))))); ;
                     
                }
                else {
                    dview.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                }
            }
        }
        public static void formatRows(DataGridView dview, string rows)
        {
            for (int i = 0; i < dview.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    dview.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(217)))));
                }
                else
                {
                    dview.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                }
                try
                {
                    dview.Rows[i].Cells[rows].Value = dview.Rows[i].Cells[rows].Value != null ? sodanhbo(dview.Rows[i].Cells[rows].Value + "") : dview.Rows[i].Cells[rows].Value;
                }
                catch (Exception)
                {

                }

            }
        }

        public static string sodanhbo(string _danhbo)
        {
            if (_danhbo.Length == 11)
            {
                _danhbo = _danhbo.Insert(4, "  ");
                _danhbo = _danhbo.Insert(9, "  ");

            }
            return _danhbo;
        }

        public static string sohoso(string _sohoso) {
            try
            {
                _sohoso = _sohoso.Insert(4, ".");
                _sohoso = _sohoso.Insert(9, ".");
            }
            catch (Exception)
            {
                
            }
            
            return _sohoso;
        }
        
      
        
    }
}

