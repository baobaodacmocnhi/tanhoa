using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.Doi;

namespace DocSo_PC.GUI.Doi
{
    public partial class frmTaoDotKiemTra : Form
    {
        CDocSo _cDocSo = new CDocSo();
        DataTable _dt = new DataTable();

        public frmTaoDotKiemTra(DataTable dt)
        {
            InitializeComponent();
            _dt = dt;
        }

        private void frmTaoDotKiemTra_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
            dgvDanhSach.DataSource = _dt;
            foreach (DataGridViewRow item in dgvDanhSach.Rows)
            {
                item.Cells["CSCuMoi"].Value = int.Parse(item.Cells["CSCu"].Value.ToString()) + int.Parse(item.Cells["TieuThuHD"].Value.ToString()) - int.Parse(item.Cells["TieuThuDS"].Value.ToString());
            }
        }

        private void dgvDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (_cDocSo.checkChot_BillState(dgvDanhSach["Nam", 0].Value.ToString(), dgvDanhSach["Ky", 0].Value.ToString(), dgvDanhSach["Dot", 0].Value.ToString()) == true)
                {
                    MessageBox.Show("Năm " + dgvDanhSach["Nam", 0].Value.ToString() + " Kỳ " + dgvDanhSach["Ky", 0].Value.ToString() + " Đợt " + dgvDanhSach["Dot", 0].Value.ToString() + " đã chuyển billing", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                foreach (DataGridViewRow item in dgvDanhSach.Rows)
                    if (bool.Parse(item.Cells["Chon"].Value.ToString()) == true)
                    {
                        string sql = "update DocSo set CSCu=" + item.Cells["CSCuMoi"].Value.ToString() + " where DocSoID=" + item.Cells["DocSoID"].Value.ToString();
                        CDocSo._cDAL.ExecuteNonQuery(sql);
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
