using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.CapNhat;

namespace KTKS_DonKH.GUI.CapNhat
{
    public partial class frmTTKH : Form
    {
        CTTKH _cTTKH = new CTTKH();

        public frmTTKH()
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

        private void frmTTKH_Load(object sender, EventArgs e)
        {
            dgvDSTTKHDate.AutoGenerateColumns = false;
            dgvDSTTKHDate.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSTTKHDate.Font, FontStyle.Bold);
            dgvDSTTKHDate.DataSource = _cTTKH.LoadDSTTKhachHangDate();
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Files (.dat)|*.dat";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtDuongDan.Text = dialog.FileName;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtDuongDan.Text.Trim() != "")
            {
                if (_cTTKH.CapNhatTTKH(txtDuongDan.Text.Trim()))
                    dgvDSTTKHDate.DataSource = _cTTKH.LoadDSTTKhachHangDate();
            }
        }

        
    }
}
