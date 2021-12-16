using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.ChuanBiDocSo;
using DocSo_PC.DAL.QuanTri;
using DocSo_PC.LinQ;
using System.Data.SqlClient;
using DocSo_PC.DAL.ChuyenBillding;

namespace DocSo_PC.GUI.ChuyenBillding
{
    public partial class frmKiemTraDuLieu : Form
    {
        //  CNguoiDung _cNguoiDung = new CNguoiDung();
        CChuyenDuLieu _cChuyen = new CChuyenDuLieu();
        int tumay = CNguoiDung.TuMayDS;
        int denmay = CNguoiDung.DenMayDS;
        public frmKiemTraDuLieu()
        {
            InitializeComponent();
        }

        private void frmTaoDocSo_Load(object sender, EventArgs e)
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

            //string sql = "SELECT MaTo,TenTo FROM [To] ";
            //if (CNguoiDung.ToTruong)
            //    sql += " WHERE MaTo=" + CNguoiDung.MaTo;
            //cmbToDS.DataSource = _cChuanBi.ExecuteQuery_SqlDataReader_DataTable(sql);
            //cmbToDS.DisplayMember = "TenTo";
            //cmbToDS.ValueMember = "MaTo";

            //dsDenNgay.Value = DateTime.Now.Date.AddDays(1.0);
            //PageLoad();
        }

        private void dataKiemsoat_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataKiemsoat.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
            
        }

        private void btnKiemsoatDL_Click(object sender, EventArgs e)
        {
            int nam = int.Parse(cmbNam.Text);
            string ky = cmbKy.Text;
            string dot = cmbDot.Text;
            string SQL = "SELECT TODS,MAY,DANHBA,MLT1 FROM DocSo WHERE (CodeMoi='' OR CSMoi ='' OR TieuThuMoi ='' )  AND  NAM=" + nam + " AND KY='" + ky + "' AND DOT='" + dot + "' ORDER BY MLT1 ASC";
            dataKiemsoat.DataSource = CChuyenDuLieu._cDAL.ExecuteQuery_SqlDataAdapter_DataTable(SQL);
        }

    }
}