using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.TongHop;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;

namespace ThuTien.GUI.TongHop
{
    public partial class frmChamCong : Form
    {
        string _mnu = "mnuChamCong";
        CChamCong _cChamCong = new CChamCong();
        CNguoiDung _cNguoiDung = new CNguoiDung();

        public frmChamCong()
        {
            InitializeComponent();
        }

        private void frmChamCong_Load(object sender, EventArgs e)
        {
            dgvChamCong.AutoGenerateColumns = false;

            dateChamCong.Value = DateTime.Now;

            if (!_cChamCong.CheckExist(DateTime.Now.Month, DateTime.Now.Year))
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    List<TT_NguoiDung> lstND = _cNguoiDung.GetDSExceptAdmin();

                    TT_ChamCong chamcong = new TT_ChamCong();
                    chamcong.Thang = DateTime.Now.Month;
                    chamcong.Nam = DateTime.Now.Year;

                    foreach (TT_NguoiDung item in lstND)
                    {
                        TT_CTChamCong ctchamcong = new TT_CTChamCong();
                        ctchamcong.MaND = item.MaND;
                        ctchamcong.CreateBy = CNguoiDung.MaND;
                        ctchamcong.CreateDate = DateTime.Now;

                        chamcong.TT_CTChamCongs.Add(ctchamcong);
                    }

                    _cChamCong.Them(chamcong);
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvChamCong.DataSource = _cChamCong.GetDS(dateChamCong.Value.Month, dateChamCong.Value.Year);
        }

        private void dgvChamCong_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvChamCong_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvChamCong.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
    }
}
