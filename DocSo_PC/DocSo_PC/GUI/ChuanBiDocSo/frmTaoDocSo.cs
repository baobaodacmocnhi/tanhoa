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
        //  CNguoiDung _cNguoiDung = new CNguoiDung();
        CChuanBiDS _cChuanBi = new CChuanBiDS();

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
            cmbToDS.DataSource = _cChuanBi.ExecuteQuery_SqlDataReader_DataTable(sql);
            cmbToDS.DisplayMember = "TenTo";
            cmbToDS.ValueMember = "MaTo";

            //PageLoad();
        }


        private void cmbDot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDot.SelectedIndex != -1)
            {
                SoDocSo();
            }
        }
        DataTable tb = null;
        public void SoDocSo()
        {
            string sql = " select May,COUNT(*) AS SOLUONG , 'True' as DaTao ,NVTaoDS,NgayTaoDS from DocSo WHERE (May BETWEEN " + CNguoiDung.TuMayDS + " AND " + CNguoiDung.DenMayDS + " )AND Nam=" + int.Parse(cmbNam.Text) + "AND Ky='" + cmbKy.Text + "' AND Dot='" + cmbDot.Text + "' group by May,NVTaoDS,NgayTaoDS ORDER BY May ASC ";
            tb = _cChuanBi.ExecuteQuery_SqlDataReader_DataTable(sql);
            if (tb.Rows.Count > 0)
                dataTaoDS.DataSource = tb;
            else
            {
                sql = "select May,COUNT(*) AS SOLUONG , 'False' as DaTao ,'' AS NVTaoDS, '' AS NgayTaoDS from BienDong WHERE (May BETWEEN " + CNguoiDung.TuMayDS + " AND " + CNguoiDung.DenMayDS + " )AND Nam=" + int.Parse(cmbNam.Text) + "AND Ky='" + cmbKy.Text + "' AND Dot='" + cmbDot.Text + "' group by May ORDER BY May ASC ";
                tb = _cChuanBi.ExecuteQuery_SqlDataReader_DataTable(sql);
                dataTaoDS.DataSource = tb;
            }

        }

        private void cmbToDS_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!"".Equals(cmbDot.Text))
            {
                if (tb != null)
                {

                    CTo _ct = new CTo();
                    To _t = _ct.GetByMaTo(int.Parse(cmbToDS.SelectedValue.ToString()));
                    DataTable t2 = tb.Select(" May > " + _t.TuMay + " and May <= " + _t.DenMay).CopyToDataTable();
                    //    tb.Select(" (May BETWEEN 0 AND 10 )");
                    dataTaoDS.DataSource = t2;
                }
            }
        }


        private void btnTaoDocSo_Click(object sender, EventArgs e)
        {
            if (tb != null)
            {
                int nam = int.Parse(cmbNam.Text);
                string ky = cmbKy.Text;
                string dot = cmbDot.Text;
                BillState bilS = CChuanBiDS.GetBillState(nam, ky, dot);
                if (bilS != null)
                {
                    if (bilS.izDS == "1")
                    {
                        MessageBox.Show("Dữ liệu đã chuyển Billing không  thể tạo dữ liệu đọc số  !! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    
                    }
                    if (bilS.izCB == "1")
                        if (MessageBox.Show("Đã tạo dữ liệu đọc số rồi ! Muốn tạo lại dữ liệu đọc số ? ", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                            return;
                }
                
                _cChuanBi.ExecuteNonQuery_Transaction("INSERT INTO BillState VALUES (" + "" + nam + ky + dot + ",1,0,0,0,0)");

                int total = Convert.ToInt32(tb.Compute("SUM(SOLUONG)", string.Empty));
                progressBar.Minimum = 0;
                progressBar.Maximum = total;
                int i = 0;
            }
            else
            {
                MessageBox.Show("Chưa load dữ liệu sổ đọc số !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}