using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.Doi;
using DocSo_PC.LinQ;
using DocSo_PC.DAL.QuanTri;
using DocSo_PC.DAL;

namespace DocSo_PC.GUI.MaHoa
{
    public partial class frmTimKiem : Form
    {
        CDocSo _cDocSo = new CDocSo();
        CTo _cTo = new CTo();
        CMayDS _cMayDS = new CMayDS();
        CDHN _cDHN = new CDHN();

        public frmTimKiem()
        {
            InitializeComponent();
        }

        private void frmTimKiem_Load(object sender, EventArgs e)
        {
            try
            {
                List<To> lst = _cTo.getDS_HanhThu();
                DataTable dtMay = new DataTable();
                for (int i = 0; i < lst.Count; i++)
                {
                    dtMay.Merge(_cMayDS.getDS(lst[i].MaTo.ToString()));
                }
                DataRow dr = dtMay.NewRow();
                dr["May"] = "Tất Cả";
                dtMay.Rows.InsertAt(dr, 0);
                cmbMay.DataSource = dtMay;
                cmbMay.DisplayMember = "May";
                cmbMay.ValueMember = "May";
                cmbMay.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDot.SelectedIndex >= 0)
                {
                    dgvDanhSach.DataSource = _cDHN.getDS_DiaChiSaiLech(cmbDot.SelectedItem.ToString(),cmbMay.SelectedValue.ToString());
                }
                else
                    MessageBox.Show("Chưa chọn Đợt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }
    }
}
