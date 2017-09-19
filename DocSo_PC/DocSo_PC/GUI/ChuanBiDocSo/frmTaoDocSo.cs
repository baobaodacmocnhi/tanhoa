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

namespace DocSo_PC.GUI.ChuanBiDocSo
{
    public partial class frmTaoDocSo : Form
    {
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CChuanBiDS _cHoaDon = new CChuanBiDS();
        CTo _ct = new CTo();
        public frmTaoDocSo()
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

            string sql = "SELECT MaTo,TenTo FROM [To] ";
            if (CNguoiDung.ToTruong)
                sql += " WHERE MaTo=" + CNguoiDung.MaTo;
            cmbToDS.DataSource = _cHoaDon.ExecuteQuery_SqlDataReader_DataTable(sql);
            cmbToDS.DisplayMember = "TenTo";
            cmbToDS.ValueMember = "MaTo";
            
            //PageLoad();
        }
        public void PageLoad()
        {
            int nam = int.Parse(cmbNam.Text);
            string ky = cmbKy.Text;
            string dot = cmbDot.Text;

            // load So Doc So
            if (CNguoiDung.ToTruong)
            {
                To _t = _ct.GetByMaTo(CNguoiDung.MaTo);
                dataTaoDS.DataSource = CChuanBiDS.GetSoDocSo("GetSoDocSo", nam, ky, dot, _t.TuMay.Value, _t.DenMay.Value);
            }
            else
                dataTaoDS.DataSource = CChuanBiDS.GetSoDocSo("GetSoDocSo", nam, ky, dot, 0, 100);
        }

        private void cmbDot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDot.SelectedIndex != -1)
            {
                PageLoad();
            }
        }

        private void cmbToDS_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!"".Equals(cmbDot.Text))
            {
                
                To _t=_ct.GetByMaTo(int.Parse(cmbToDS.SelectedValue.ToString()));
                dataTaoDS.DataSource = CChuanBiDS.GetSoDocSo("GetSoDocSo", int.Parse(cmbNam.Text), cmbKy.Text, cmbDot.Text, _t.TuMay.Value, _t.DenMay.Value);
            }
        }

    }
}
