using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.ChuyenKhoan;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmLichSuDieuChinhTienDu : Form
    {
        CTienDu _cTienDu = new CTienDu();

        public frmLichSuDieuChinhTienDu()
        {
            InitializeComponent();
        }

        private void frmLichSuDieuChinhTien_Load(object sender, EventArgs e)
        {
            dgvLichSuDieuChinhTienDu.AutoGenerateColumns = false;

            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dateTu.Value <= dateDen.Value)
            {
                DataTable dtChuyen = _cTienDu.GetDSChuyenTien(dateTu.Value, dateDen.Value);
                DataTable dtNhan = _cTienDu.GetDSNhanTien(dateTu.Value, dateDen.Value);

                DataTable dt = new DataTable();
                dt.Columns.Add("DanhBoChuyen", typeof(string));
                dt.Columns.Add("SoTienChuyen", typeof(int));
                dt.Columns.Add("DanhBoNhan", typeof(string));
                dt.Columns.Add("CreateDate", typeof(DateTime));

                for (int i = 0; i < dtChuyen.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();

                    dr["DanhBoChuyen"] = dtChuyen.Rows[i]["DanhBo"];
                    dr["SoTienChuyen"] = int.Parse(dtChuyen.Rows[i]["SoTien"].ToString()) * -1;
                    dr["DanhBoNhan"] = dtNhan.Rows[i]["DanhBo"];
                    dr["CreateDate"] = dtChuyen.Rows[i]["CreateDate"];

                    dt.Rows.Add(dr);
                }

                dgvLichSuDieuChinhTienDu.DataSource = dt;
            }
        }

        private void dgvLichSuDieuChinhTienDu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLichSuDieuChinhTienDu.Columns[e.ColumnIndex].Name == "DanhBoChuyen" && e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvLichSuDieuChinhTienDu.Columns[e.ColumnIndex].Name == "SoTienChuyen" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvLichSuDieuChinhTienDu.Columns[e.ColumnIndex].Name == "DanhBoNhan" && e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
        }

        private void dgvLichSuDieuChinhTienDu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvLichSuDieuChinhTienDu.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
    }
}
