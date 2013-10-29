using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using KTKS_DonKH.GUI.KhachHang;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.KiemTraXacMinh
{
    public partial class frmKTXM : Form
    {
        CChuyenDi _cChuyenDi = new CChuyenDi();
        CKTXM _cKTXM = new CKTXM();
        CDonKH _cDonKH = new CDonKH();

        public frmKTXM()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void frmKTXM_Load(object sender, EventArgs e)
        {
            dgvDSKTXM.AutoGenerateColumns = false;
            DataGridViewComboBoxColumn cmbColumn = (DataGridViewComboBoxColumn)dgvDSKTXM.Columns["MaChuyen"];
            cmbColumn.DataSource = _cChuyenDi.LoadDSChuyenDi("KTXM");
            cmbColumn.DisplayMember = "NoiChuyenDi";
            cmbColumn.ValueMember = "MaChuyen";
            radChuDuyet.Checked = true;
        }

        private void dgvDSDonKH_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSKTXM.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void radChuDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radChuDuyet.Checked)
                dgvDSKTXM.DataSource = _cKTXM.LoadDSKTXMChuaDuyet();
        }

        private void radDaDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radDaDuyet.Checked)
                dgvDSKTXM.DataSource = _cKTXM.LoadDSKTXMDaDuyet();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DataTable table = (DataTable)dgvDSKTXM.DataSource;
            foreach (DataRow itemRow in table.Rows)
            {
                if (itemRow["MaChuyen"].ToString() != "")
                {
   
                    KTXM ktxm = _cKTXM.getKTXMbyID(int.Parse(itemRow["MaDon"].ToString()));
                    if(ktxm==null)
                    {
                        ktxm = new KTXM();
                        ktxm.MaKTXM = int.Parse(itemRow["MaDon"].ToString());
                        ktxm.KetQua = itemRow["KetQua"].ToString();
                        ktxm.MaChuyen = itemRow["MaChuyen"].ToString();
                        ktxm.LyDoChuyen = itemRow["LyDoChuyenDi"].ToString();
                        _cKTXM.ThemKTXM(ktxm); 
                    }
                    else
                    {
                        ktxm.KetQua = itemRow["KetQua"].ToString();
                        ktxm.MaChuyen = itemRow["MaChuyen"].ToString();
                        ktxm.LyDoChuyen = itemRow["LyDoChuyenDi"].ToString();
                        _cKTXM.SuaKTXM(ktxm);
                    }
                    DonKH donkh = _cDonKH.getDonKHbyID(int.Parse(itemRow["MaDon"].ToString()));
                    donkh.Nhan = true;
                    _cDonKH.SuaDonKH(donkh);
                } 
            }
            if (radDaDuyet.Checked)
                dgvDSKTXM.DataSource = _cKTXM.LoadDSKTXMDaDuyet();
            if (radChuDuyet.Checked)
                dgvDSKTXM.DataSource = _cKTXM.LoadDSKTXMChuaDuyet();
        }

        private void dgvDSKTXM_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                frmShowDonKH frm = new frmShowDonKH(_cDonKH.getDonKHbyID(int.Parse(dgvDSKTXM["MaDon", e.RowIndex].Value.ToString())));
                frm.ShowDialog();
            }
        }

        
    }
}
