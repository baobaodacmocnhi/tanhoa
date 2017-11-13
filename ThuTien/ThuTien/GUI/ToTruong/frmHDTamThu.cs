using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Quay;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.DongNuoc;
using ThuTien.LinQ;
using ThuTien.DAL.Doi;

namespace ThuTien.GUI.ToTruong
{
    public partial class frmHDTamThu : Form
    {
        CTamThu _cTamThu = new CTamThu();
        CDongNuoc _cDongNuoc = new CDongNuoc();
        CLenhHuy _cLenhHuy = new CLenhHuy();
        CTo _cTo = new CTo();
        CHoaDon _cHoaDon = new CHoaDon();

        public frmHDTamThu()
        {
            InitializeComponent();
        }

        private void frmHoaDonTamThu_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
            dgvHoaDon_LH.AutoGenerateColumns = false;
            dgvHoaDon_LL.AutoGenerateColumns = false;

            if (CNguoiDung.Doi)
            {
                cmbTo.Visible = true;

                List<TT_To> lstTo = _cTo.GetDSHanhThu();
                TT_To to = new TT_To();
                to.MaTo = 0;
                to.TenTo = "Tất Cả";
                lstTo.Insert(0,to);
                cmbTo.DataSource = lstTo;
                cmbTo.DisplayMember = "TenTo";
                cmbTo.ValueMember = "MaTo";
            }
            else
                lbTo.Text = "Tổ  " + CNguoiDung.TenTo;

            DataTable dtNam = _cHoaDon.GetNam();
            //DataRow dr = dtNam.NewRow();
            //dr["ID"] = "Tất Cả";
            //dtNam.Rows.InsertAt(dr, 0);
            cmbNam.DataSource = dtNam;
            cmbNam.DisplayMember = "ID";
            cmbNam.ValueMember = "Nam";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.Doi)
            {
                if (cmbTo.SelectedIndex == 0)
                    dgvHoaDon.DataSource = _cTamThu.GetDSTon(false);
                else
                    if (cmbTo.SelectedIndex > 0)
                        dgvHoaDon.DataSource = _cTamThu.GetDSTon((int)cmbTo.SelectedValue, false);
            }
            else
                dgvHoaDon.DataSource = _cTamThu.GetDSTon(CNguoiDung.MaTo, false);

            foreach (DataGridViewRow item in dgvHoaDon.Rows)
            {
                if (_cDongNuoc.CheckExist_CTDongNuoc(item.Cells["SoHoaDon"].Value.ToString()))
                    item.DefaultCellStyle.BackColor = Color.Yellow;
                if (_cLenhHuy.CheckExist(item.Cells["SoHoaDon"].Value.ToString()))
                    item.DefaultCellStyle.BackColor = Color.Red;
            }
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "MLT" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(2, " ");
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHoaDon_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHoaDon.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnXem_LH_Click(object sender, EventArgs e)
        {
            DataTable dtLH = _cLenhHuy.GetDSDanhBoTon(CNguoiDung.MaTo);
            DataTable dtHD = new DataTable(); 
            
            if (cmbDot.SelectedIndex == 0)
                dtHD =  _cHoaDon.GetDSTon_CoTieuThu(CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
            else
                if (cmbDot.SelectedIndex > 0)
                    dtHD = _cHoaDon.GetDSTon_CoTieuThu(CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
            
            List<DataRow> RowsToDelete = new List<DataRow>();

            for (int i = 0; i < dtHD.Rows.Count; i++)
            {
                if (dtLH.Select("DanhBo='" + dtHD.Rows[i]["DanhBo"].ToString() + "'").Count() == 0 || _cLenhHuy.CheckExist(dtHD.Rows[i]["SoHoaDon"].ToString()) == true)
                {
                    RowsToDelete.Add(dtHD.Rows[i]);
                }
            }
            foreach (var dr in RowsToDelete)
            {
                dtHD.Rows.Remove(dr);
            }
            dgvHoaDon_LH.DataSource = dtHD;

            /////////////////
           
            DataTable dtLL = _cDongNuoc.GetDSCTDongNuocTon(CNguoiDung.MaTo);
            DataTable dtHD2 = new DataTable();
            if (cmbDot.SelectedIndex == 0)
                dtHD2 = _cHoaDon.GetDSTon_CoTieuThu(CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
            else
                if (cmbDot.SelectedIndex > 0)
                    dtHD2 = _cHoaDon.GetDSTon_CoTieuThu(CNguoiDung.MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
            RowsToDelete = new List<DataRow>();

            for (int i = 0; i < dtHD2.Rows.Count; i++)
            {
                if (dtLL.Select("DanhBo='" + dtHD2.Rows[i]["DanhBo"].ToString() + "'").Count() == 0)
                {
                    RowsToDelete.Add(dtHD2.Rows[i]);
                }
            }
            foreach (var dr in RowsToDelete)
            {
                dtHD2.Rows.Remove(dr);
            }
            dgvHoaDon_LL.DataSource = dtHD2;
        }

        private void dgvHoaDon_LH_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon_LH.Columns[e.ColumnIndex].Name == "MLT_LH" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(2, " ");
            }
            if (dgvHoaDon_LH.Columns[e.ColumnIndex].Name == "DanhBo_LH" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHoaDon_LH.Columns[e.ColumnIndex].Name == "TongCong_LH" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHoaDon_LL_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon_LL.Columns[e.ColumnIndex].Name == "MLT_LL" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(2, " ");
            }
            if (dgvHoaDon_LL.Columns[e.ColumnIndex].Name == "DanhBo_LL" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvHoaDon_LL.Columns[e.ColumnIndex].Name == "TongCong_LL" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }
    }
}
