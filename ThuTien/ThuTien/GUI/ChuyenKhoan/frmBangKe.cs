using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.ChuyenKhoan;
using ThuTien.LinQ;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmBangKe : Form
    {
        string _mnu = "mnuBangKe";
        CBangKe _cBangKe = new CBangKe();

        public frmBangKe()
        {
            InitializeComponent();
        }

        private void frmBangKe_Load(object sender, EventArgs e)
        {
            dgvDanhBo.AutoGenerateColumns = false;
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                try
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                    dialog.Multiselect = false;

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        Excel fileExcel = new Excel(dialog.FileName);
                        DataTable dtExcel = fileExcel.GetDataTable("select * from [Sheet1$]");

                        foreach (DataRow item in dtExcel.Rows)
                            if (item[0].ToString().Length == 11 && !_cDLKH.CheckExistDanhBo(item[0].ToString()))
                            {
                                TT_BangKe bangke = new TT_BangKe();
                                bangke.DanhBo = item[0].ToString();
                                bangke.MaNH = int.Parse(item[1].ToString());
                                bangke.SoPhieu = int.Parse(item[2].ToString());
                                _cDLKH.Them(dlkh);
                            }
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
