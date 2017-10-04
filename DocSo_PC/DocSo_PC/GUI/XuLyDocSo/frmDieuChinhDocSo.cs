using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.QuanTri;
using DocSo_PC.DAL.ChuanBiDocSo;
using DocSo_PC.DAL.XuLyDocSo;

namespace DocSo_PC.GUI.XuLyDocSo
{
    public partial class frmDieuChinhDocSo : Form
    {
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CXuLyDocSo _cCXuLy = new CXuLyDocSo();
        int tumay = CNguoiDung.TuMayDS;
        int denmay = CNguoiDung.DenMayDS;
        int nam;
        string dot;
        string ky;
        public frmDieuChinhDocSo()
        {
            frmChonDot f = new frmChonDot();
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                InitializeComponent();
            nam = f.nam;
            ky = f.ky;
            dot = f.dot;
        }

        private void frmDieuChinhDocSo_Load(object sender, EventArgs e)
        {
            this.Text = "Điều Chỉnh Đọc Số Kỳ " + ky + "/" + nam + " Đợt " + dot;
            string sql = "SELECT MaTo,TenTo FROM [To] ";
            if (CNguoiDung.ToTruong)
                sql += " WHERE MaTo=" + CNguoiDung.MaTo;
            DataTable tb = _cCXuLy.ExecuteQuery_SqlDataReader_DataTable(sql);
            int index =0;
            if (tb.Rows.Count > 1)
            {
                DataRow newRow = tb.NewRow();
                newRow["MaTo"] = "0";
                newRow["TenTo"] = "Tất Cả";
                tb.Rows.Add(newRow);
                index=tb.Rows.Count -1;
            }
            cmbToDS.DataSource = tb;
            cmbToDS.DisplayMember = "TenTo";
            cmbToDS.ValueMember = "MaTo";
            cmbToDS.SelectedIndex = index;
            getMayds(CNguoiDung.MaTo);

        }
        void getMayds(int tods)
        {
            cmbMay.DataSource = _cCXuLy.getMayDS(tods);
            cmbMay.DisplayMember = "May";
            cmbMay.ValueMember = "May";
        }

        private void cmbToDS_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            try
            {
                getMayds(int.Parse(cmbToDS.SelectedValue.ToString()));
            }
            catch (Exception)
            {

            }

        }
    }
}
