using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrungTamKhachHang.DAL.KhachHang;

namespace TrungTamKhachHang.GUI.KhachHang
{
    public partial class frmDanhSachKhieuNai : Form
    {
        CKhieuNai _cKN = new CKhieuNai();

        public frmDanhSachKhieuNai()
        {
            InitializeComponent();
        }

        private void frmDanhSachKhieuNai_Load(object sender, EventArgs e)
        {
            dgvKhieuNai.AutoGenerateColumns = false;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvKhieuNai.DataSource = _cKN.getDS(dateTu.Value,dateDen.Value);
        }

        private void dgvKhieuNai_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvKhieuNai.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvKhieuNai_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvKhieuNai.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                frmKhieuNaiKhachHang frm = new frmKhieuNaiKhachHang(int.Parse(dgvKhieuNai["ID", dgvKhieuNai.CurrentRow.Index].Value.ToString()));
                frm.ShowDialog();
            }
        }
    }
}
