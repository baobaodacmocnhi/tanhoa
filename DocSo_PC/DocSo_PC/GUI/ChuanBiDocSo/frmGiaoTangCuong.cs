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

namespace DocSo_PC.GUI.ChuanBiDocSo
{
    public partial class frmGiaoTangCuong : Form
    {
        //  CNguoiDung _cNguoiDung = new CNguoiDung();
        CChuanBiDS _cChuanBi = new CChuanBiDS();
        int tumay = CNguoiDung.TuMayDS;
        int denmay = CNguoiDung.DenMayDS;
        public frmGiaoTangCuong()
        {
            InitializeComponent();
        }

        private void dataTaoDS_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataDS.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }
        private void dataTC_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGiaoTC.RowHeadersDefaultCellStyle.ForeColor))
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
            cmbToDS.DataSource = _cChuanBi.ExecuteQuery_SqlDataReader_DataTable(sql);
            cmbToDS.DisplayMember = "TenTo";
            cmbToDS.ValueMember = "MaTo";

            // add checkbox header
            Rectangle rect = dataDS.GetCellDisplayRectangle(0, -1, true);
            // set checkbox header to center of header cell. +1 pixel to position correctly.
            rect.X = rect.Location.X + (rect.Width / 4);

            CheckBox checkboxHeader = new CheckBox();
            checkboxHeader.Name = "checkChia";
            checkboxHeader.Size = new Size(17, 17);
            checkboxHeader.Location = rect.Location;
            checkboxHeader.CheckedChanged += new EventHandler(checkboxHeader_CheckedChanged);
            dataDS.Controls.Add(checkboxHeader);

        }


        private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            int sl = int.Parse(slGiao.Text);
            if (sl > dataDS.RowCount)
            {
                for (int i = 0; i < dataDS.RowCount; i++)
                {
                    dataDS[0, i].Value = ((CheckBox)dataDS.Controls.Find("checkChia", true)[0]).Checked;
                }
            }
            else 
            {
                for (int i = 0; i < sl; i++)
                {
                    dataDS[0, i].Value = ((CheckBox)dataDS.Controls.Find("checkChia", true)[0]).Checked;
                }
            }
           
        }
        //private void checkboxHeader1_CheckedChanged(object sender, EventArgs e)
        //{
        //    for (int i = 0; i < DG_SDV.RowCount; i++)
        //    {
        //        DG_SDV[0, i].Value = ((CheckBox)DG_SDV.Controls.Find("checkboxHeader", true)[0]).Checked;
        //    }
        //}

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
                To _t = _ct.GetByMaTo(int.Parse(cmbToDS.SelectedValue.ToString()));
                tumay = _t.TuMay.Value;
                denmay = _t.DenMay.Value;
                for (int i = tumay; i < denmay; i++)
                {
                    cmbMay.Items.Add(setSoMay(i));
                    cmbDenTC.Items.Add(setSoMay(i));
                }
            }
            catch (Exception)
            {
            } 
           
            
            //if (!"".Equals(cmbDot.Text))
            //{
            //    if (tb != null)
            //    {
            //        SoDocSo();                    
            //    }
            //}
        }
        CheckBox checkboxHeader1 = new CheckBox();
        CheckBox checkboxHeader = new CheckBox();

        public void _tuMay()
        {
            string sql = " select 'false' as checkChia, MLT1,DanhBa,SoNhaCu,Duong from DocSo WHERE May = " + cmbMay.Text + " AND Nam=" + int.Parse(cmbNam.Text) + "AND Ky='" + cmbKy.Text + "' AND Dot='" + cmbDot.Text + "'   ORDER BY MLT1 ASC ";
            dataDS.DataSource = _cChuanBi.ExecuteQuery_SqlDataAdapter_DataTable(sql);
            lbSlDocTu.Text = " Tổng số lượng đọc " + dataDS.Rows.Count + " đc";
 
        }
        private void cmbMay_SelectedValueChanged(object sender, EventArgs e)
        {
            _tuMay();
        }
        public void _denMay()
        {
            string sql = " select MLT1,DanhBa,SoNhaCu,Duong from DocSo WHERE May = " + cmbDenTC.Text + " AND Nam=" + int.Parse(cmbNam.Text) + "AND Ky='" + cmbKy.Text + "' AND Dot='" + cmbDot.Text + "'   ORDER BY MLT1 ASC ";
            dataGiaoTC.DataSource = _cChuanBi.ExecuteQuery_SqlDataAdapter_DataTable(sql);
            lbGiaoTC.Text = " Tổng số lượng đọc " + dataGiaoTC.Rows.Count + " đc - Tăn cường " + _cChuanBi.getTangCuong(int.Parse(cmbNam.Text), cmbKy.Text, cmbDot.Text, cmbMay.Text) +" đc";

        
        }
         private void cmbDenTC_SelectedValueChanged(object sender, EventArgs e)
        {
            _denMay();
        }

        private void btGiaoViec_Click(object sender, EventArgs e)
        {
            if (!"".Equals(cmbDenTC.Text) && !cmbDenTC.Text.Equals(cmbMay.Text))
            {

                try
                {
                  //  bool chek = false;
                    for (int i = 0; i < dataDS.RowCount; i++)
                    {
                        if (dataDS[0, i].Value != null && "True".Equals(dataDS[0, i].Value.ToString()))
                        {
                            //chek = true;
                            string db = dataDS.Rows[i].Cells["dbChua"].Value.ToString();
                            string sql = "Update DocSo Set May='" + cmbDenTC.Text + "' WHERE DanhBa='"+db+"' AND Nam=" + int.Parse(cmbNam.Text) + "AND Ky='" + cmbKy.Text + "' AND Dot='" + cmbDot.Text + "'";
                            _cChuanBi.ExecuteNonQuery(sql);
                           // DAL.C_ToThietKe.giaoviecSDV(shs, this.sodovien.SelectedValue.ToString(), DAL.C_USERS._userName);
                        }
                    }

                    _tuMay();
                    _denMay();
                    checkboxHeader.Checked = false;
                    //if (chek == false)
                    //{
                    //    MessageBox.Show(this, "Chưa Chọn Hồ Sơ Để Giao Cho Sơ Đồ Viên.", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                    //else
                    //{
                    //    giaoviec();
                    //}
                }
                catch (Exception ex)
                {
                    //log.Error("TTK Giao Viec Loi " + ex.Message);
                }
           

            }
            else
            {
                MessageBox.Show("Cần chọn máy đọc số để giao tăng cường  !! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        
    }
}