using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.BaoCao;
using ThuTien.GUI.BaoCao;
using ThuTien.BaoCao.ToTruong;
using System.Globalization;
using ThuTien.DAL.Quay;

namespace ThuTien.GUI.ToTruong
{
    public partial class frmTongHopNo : Form
    {
        CHoaDon _cHoaDon = new CHoaDon();
        BindingSource bsHoaDon = new BindingSource();
        DataTable dt = new DataTable();

        public frmTongHopNo()
        {
            InitializeComponent();
        }

        private void frmTongHopNo_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
            dgvHoaDon.DataSource = bsHoaDon;

            //DataTable dt = new DataTable();
            DataColumn col = new DataColumn("MaHD");
            col.DataType = System.Type.GetType("System.String");
            dt.Columns.Add(col);
            DataColumn[] columns = new DataColumn[1];
            columns[0] = dt.Columns["MaHD"];
            dt.PrimaryKey = columns;

            col = new DataColumn("DanhBo");
            col.DataType = System.Type.GetType("System.String");
            dt.Columns.Add(col);

            col = new DataColumn("DiaChi");
            col.DataType = System.Type.GetType("System.String");
            dt.Columns.Add(col);

            col = new DataColumn("Ky");
            col.DataType = System.Type.GetType("System.String");
            dt.Columns.Add(col);

            col = new DataColumn("TieuThu");
            col.DataType = System.Type.GetType("System.Int32");
            dt.Columns.Add(col);

            col = new DataColumn("GiaBan");
            col.DataType = System.Type.GetType("System.Int32");
            dt.Columns.Add(col);

            col = new DataColumn("ThueGTGT");
            col.DataType = System.Type.GetType("System.Int32");
            dt.Columns.Add(col);

            col = new DataColumn("PhiBVMT");
            col.DataType = System.Type.GetType("System.Int32");
            dt.Columns.Add(col);

            col = new DataColumn("TongCong");
            col.DataType = System.Type.GetType("System.Int32");
            dt.Columns.Add(col);

            //bsHoaDon.DataSource = dt;
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                DataTable dtTemp = _cHoaDon.GetDSTonByDanhBo(txtDanhBo.Text.Trim());
                foreach (DataRow item in dtTemp.Rows)
                    if (!dt.Rows.Contains(item["MaHD"].ToString()))
                    {
                        DataRow row = dt.NewRow();
                        row["MaHD"] = item["MaHD"];
                        row["DanhBo"] = item["DanhBo"];
                        row["DiaChi"] = item["DiaChi"];
                        row["Ky"] = item["Ky"];
                        row["TieuThu"] = item["TieuThu"];
                        row["GiaBan"] = item["GiaBan"];
                        row["ThueGTGT"] = item["ThueGTGT"];
                        row["PhiBVMT"] = item["PhiBVMT"];
                        row["TongCong"] = item["TongCong"];
                        dt.Rows.Add(row);
                    }
                bsHoaDon.DataSource = dt;
                txtDanhBo.Text = "";
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            CTamThu _cTamThu = new CTamThu();
            dsBaoCao ds = new dsBaoCao();
            int TongCongSo = 0;
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = ds.Tables["TongHopNo"].NewRow();
                dr["KinhGui"] = txtKinhGui.Text.Trim();
                dr["DanhBo"] = item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
                dr["DiaChi"] = item["DiaChi"].ToString();
                dr["Ky"] = item["Ky"].ToString();
                dr["TieuThu"] = item["TieuThu"].ToString();
                dr["GiaBan"] = item["GiaBan"].ToString();
                dr["ThueGTGT"] = item["ThueGTGT"].ToString();
                dr["PhiBVMT"] = item["PhiBVMT"].ToString();
                dr["TongCong"] = item["TongCong"].ToString();
                TongCongSo += int.Parse(item["TongCong"].ToString());
                ds.Tables["TongHopNo"].Rows.Add(dr);
            }
            DataRow dr1 = ds.Tables["TongHopNo"].NewRow();
            dr1["TongCongChu"] = _cTamThu.ConvertMoneyToWord(TongCongSo.ToString());
            ds.Tables["TongHopNo"].Rows.Add(dr1);
            rptTongHopNo rpt = new rptTongHopNo();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TieuThu" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "GiaBan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "ThueGTGT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "PhiBVMT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHoaDon_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHoaDon.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        
    }
}
