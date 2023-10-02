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
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmSoDangKyDinhMuc : Form
    {
        CChungTu _cChungTu = new CChungTu();
        ChungTu_ChiTiet _ctct = null;

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
                dt.Merge(_cChungTu.getDS_ChiTiet_CMND());
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    foreach (DataRow item in dt.Rows)
                    {
                        writer.Write("\"" + item["DanhBo"] + "\"");
                        writer.Write(",\"T\"");
                        writer.Write(",\"" + item["MaCT"].ToString().Trim() + "\"");
                        writer.Write(",\"" + item["HoTen"] + "\"");
                        writer.Write(",\"\"");//CMND_CU
                        writer.Write(",\"\"");//SHK_STT
                        writer.Write(",\"0\"");//NGHEO
                        writer.Write(",\"1\"");//LOAI_CDM
                        writer.Write(",\"\"");//THOIHAN_TT
                        writer.Write(",\"\"");//DBO_THTRU
                        writer.WriteLine(",\"\"");//MSDD_MOI
                    }
                MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //23/06/2022
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen("mnuDCBD", "Xoa"))
                {
                    if (_ctct != null && MessageBox.Show("Bạn có chắc chắn???", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (_cChungTu.XoaCT(_ctct))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _ctct = null;
                        }
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _ctct = _cChungTu.GetCT(dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString(), dgvDanhSach.CurrentRow.Cells["MaCT"].Value.ToString(), int.Parse(dgvDanhSach.CurrentRow.Cells["MaLCT"].Value.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
