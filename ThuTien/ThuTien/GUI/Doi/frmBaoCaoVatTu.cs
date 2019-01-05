using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.DongNuoc;
using ThuTien.BaoCao;
using ThuTien.BaoCao.DongNuoc;
using ThuTien.GUI.BaoCao;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;

namespace ThuTien.GUI.Doi
{
    public partial class frmBaoCaoVatTu : Form
    {
        string _mnu = "mnuBaoCaoVatTu";
        CDongNuoc _cDongNuoc = new CDongNuoc();

        public frmBaoCaoVatTu()
        {
            InitializeComponent();
        }

        private void frmBaoCaoVatTu_Load(object sender, EventArgs e)
        {
            dgvBamChi.AutoGenerateColumns = false;

        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvBamChi.DataSource = _cDongNuoc.BaoCaoVatTu(dateTu.Value, dateDen.Value);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();

            foreach (DataGridViewRow item in dgvBamChi.Rows)
                if (item.Cells["DanhBo"].Value != null)
                {
                    DataRow dr = ds.Tables["KQDongNuoc"].NewRow();

                    dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                    dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(7, " ").Insert(4, " ");
                    dr["HoTen"] = item.Cells["HoTen"].Value.ToString();
                    dr["DiaChi"] = item.Cells["DiaChi"].Value.ToString();
                    dr["Hieu"] = item.Cells["Hieu"].Value.ToString();
                    dr["Co"] = item.Cells["Co"].Value.ToString();
                    dr["ChiSo"] = item.Cells["ChiSoDN"].Value.ToString();
                    DateTime date = new DateTime();
                    DateTime.TryParse(item.Cells["NgayDN"].Value.ToString(), out date);
                    dr["NgayDN"] = date.ToString("dd/MM/yyyy");
                    dr["To"] = item.Cells["To"].Value.ToString();
                    dr["NhanVien"] = item.Cells["NhanVien"].Value.ToString();
                    dr["VienChi"] = "1";
                    dr["DayDong"] = "0.6";
                    dr["GhiChu"] = "Thu hồi nợ";

                    ds.Tables["KQDongNuoc"].Rows.Add(dr);
                }

            rptBaoCaoVatTu rpt = new rptBaoCaoVatTu();
            rpt.SetDataSource(ds);

            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void dgvBamChi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvBamChi.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null && e.Value.ToString().Length == 11)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
        }

        private void dgvBamChi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvBamChi.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvBamChi_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvBamChi.Columns[e.ColumnIndex].Name == "Duyet" && bool.Parse(e.FormattedValue.ToString()) != bool.Parse(dgvBamChi[e.ColumnIndex, e.RowIndex].Value.ToString()))
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    TT_KQDongNuoc kqdongnuoc = _cDongNuoc.GetKQDongNuocByMaKQDN(int.Parse(dgvBamChi["MaKQDN", e.RowIndex].Value.ToString()));
                    kqdongnuoc.Duyet = bool.Parse(e.FormattedValue.ToString());
                    _cDongNuoc.SuaKQ(kqdongnuoc);
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
