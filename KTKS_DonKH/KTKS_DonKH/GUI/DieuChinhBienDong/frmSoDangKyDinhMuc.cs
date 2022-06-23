using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using System.IO;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmSoDangKyDinhMuc : Form
    {
        CChungTu _cChungTu = new CChungTu();

        public frmSoDangKyDinhMuc()
        {
            InitializeComponent();
        }

        private void frmSoDangKyDinhMuc_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = _cChungTu.getTimKiemSoDangKyDinhMuc(txtMaCT.Text.Trim());
        }

        private void txtMaCT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnTimKiem.PerformClick();
        }

        private void btnFileBilling_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "dat";
            saveFileDialog.Filter = "Text files (*.dat)|*.dat";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = _cChungTu.getDS_ChiTiet_CCCD();

                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    foreach (DataRow item in dt.Rows)
                    {
                        writer.Write("\"" + item["DanhBo"] + "\"");
                        writer.Write(",\"T\"");
                        writer.Write(",\"" + item["MaCT"] + "\"");
                        writer.Write(",\"" + item["HoTen"] + "\"");
                        writer.Write(",\"\"");//CMND_CU
                        writer.Write(",\"\"");//SHK_STT
                        writer.Write(",\"\"");//NGHEO
                        writer.Write(",\"\"");//LOAI_CDM
                        writer.Write(",\"\"");//THOIHAN_TT
                        writer.Write(",\"\"");//DBO_THTRU
                        writer.WriteLine(",\"\"");//MSDD_MOI
                    }
                MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
