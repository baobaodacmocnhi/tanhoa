using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmDieuChinhHangLoat : Form
    {
        string _mnu = "mnuDieuChinhHangLoat";
        CDCBD _cDCBD = new CDCBD();

        public frmDieuChinhHangLoat()
        {
            InitializeComponent();
        }

        private void frmDieuChinhHangLoat_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                    dialog.Multiselect = false;

                    if (dialog.ShowDialog() == DialogResult.OK)
                        if (MessageBox.Show("Bạn có chắc chắn Thêm?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            DataTable dtExcel = _cDCBD.ExcelToDataTable(dialog.FileName);

                            foreach (DataRow item in dtExcel.Rows)
                                if ((string.IsNullOrEmpty(item[0].ToString()) || item[0].ToString().Replace(" ", "").Length == 11) && !string.IsNullOrEmpty(item[1].ToString()) && !string.IsNullOrEmpty(item[2].ToString()))
                                {
                                    DieuChinhHangLoat en = new DieuChinhHangLoat();
                                    en.STT2 = int.Parse(item[0].ToString().Trim());
                                    en.MLT = item[1].ToString().Trim();
                                    en.DanhBo = item[2].ToString().Trim();
                                    en.HoTen = item[3].ToString().Trim();
                                    en.DiaChi = item[4].ToString().Trim();
                                    en.Code = item[5].ToString().Trim();
                                    en.ChiSo = item[6].ToString().Trim();
                                    en.TieuThu = int.Parse(item[7].ToString().Trim());
                                    en.Nam = int.Parse(txtNam.Text.Trim());
                                    en.Ky = int.Parse(txtKy.Text.Trim());
                                    en.Dot = int.Parse(txtDot.Text.Trim());
                                }
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi, Vui lòng thử lại\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
