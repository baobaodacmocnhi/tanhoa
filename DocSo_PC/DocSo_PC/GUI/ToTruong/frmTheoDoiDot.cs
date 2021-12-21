using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.Doi;
using DocSo_PC.DAL.QuanTri;
using DocSo_PC.LinQ;
using System.Data.SqlClient;
using DocSo_PC.DAL.ToTruong;

namespace DocSo_PC.GUI.ToTruong
{
    public partial class frmTheoDoiDot : Form
    {
        //  CNguoiDung _cNguoiDung = new CNguoiDung();
        CChuanBiDS _cChuanBi = new CChuanBiDS();
        CXuLyDocSo _cXuLy = new CXuLyDocSo();
        int tumay = CNguoiDung.TuMayDS;
        int denmay = CNguoiDung.DenMayDS;
        public frmTheoDoiDot()
        {
            InitializeComponent();
        }


        private void dataTaoDS_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataTaoDS.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }
       
        private void frmGiaoTangCuong_Load(object sender, EventArgs e)
        {
            cmbNam.Items.Add(DateTime.Now.Year - 2);
            cmbNam.Items.Add(DateTime.Now.Year - 1);
            cmbNam.Items.Add(DateTime.Now.Year);
            cmbNam.Items.Add(DateTime.Now.Year + 1);
            cmbNam.SelectedIndex = 2;

            if (DateTime.Now.Day >= 19)
                cmbKy.SelectedIndex = DateTime.Now.Month;
            else
                cmbKy.SelectedIndex = DateTime.Now.Month - 1;

            string sql = "SELECT MaTo,TenTo FROM [To] ";
            if (CNguoiDung.ToTruong)
                sql += " WHERE MaTo=" + CNguoiDung.MaTo;
            cmbToDS.DataSource = CChuanBiDS._cDAL.ExecuteQuery_DataTable(sql);
            cmbToDS.DisplayMember = "TenTo";
            cmbToDS.ValueMember = "MaTo";


        }

        string setSoMay(int i)
        {
            if (i < 10)
                return "0" + i;
            return ""+i;
        }
        private void cmbToDS_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                CTo _ct = new CTo();
                To _t = _ct.get(int.Parse(cmbToDS.SelectedValue.ToString()));
                tumay = _t.TuMay.Value;
                denmay = _t.DenMay.Value;
            }
            catch (Exception)
            {
            } 
        }

        private void cmbDot_SelectedValueChanged(object sender, EventArgs e)
        {
            string sql = "select May, COUNT(*) as SLDoc,COUNT(CASE WHEN CAST( May as int)  != CAST(SUBSTRING(MLT1,3,2) as int) THEN 1 ELSE NULL END ) AS TANGCUONG ";
            sql += " ,COUNT(CASE WHEN CodeMoi !='' THEN 1 ELSE NULL END) AS DADOC  ";
            sql += " ,COUNT(CASE WHEN CodeMoi = '' THEN 1 ELSE NULL END) AS CHUADOC  ";
            sql += " ,COUNT(CASE WHEN CodeMoi LIKE 'F%' THEN 1 ELSE NULL END) AS DONGCUA from DocSo where Nam=" + int.Parse(cmbNam.Text) + "AND Ky='" + cmbKy.Text + "' AND Dot='" + cmbDot.Text + "' AND TODS=" + int.Parse(cmbToDS.SelectedValue.ToString()) + " group by May ORDER BY MAY ASC ";
            dataTaoDS.DataSource = CChuanBiDS._cDAL.ExecuteQuery_DataTable(sql);
        }
       

        
    }
}