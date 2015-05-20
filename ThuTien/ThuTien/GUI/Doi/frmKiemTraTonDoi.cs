using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.Doi;
using ThuTien.LinQ;

namespace ThuTien.GUI.Doi
{
    public partial class frmKiemTraTonDoi : Form
    {
        CTo _cTo = new CTo();
        CHoaDon _cHoaDon = new CHoaDon();

        public frmKiemTraTonDoi()
        {
            InitializeComponent();
        }

        private void frmKiemTraTonDoi_Load(object sender, EventArgs e)
        {
            dgvHDTuGia.AutoGenerateColumns = false;
            dgvHDCoQuan.AutoGenerateColumns = false;

            List<TT_To> lst = _cTo.GetDSHanhThu();
            TT_To to = new TT_To();
            to.MaTo = 0;
            to.TenTo = "Tất Cả";
            lst.Insert(0, to);
            cmbTo.DataSource = lst;
            cmbTo.DisplayMember = "TenTo";
            cmbTo.ValueMember = "MaTo";
        }
    }
}
