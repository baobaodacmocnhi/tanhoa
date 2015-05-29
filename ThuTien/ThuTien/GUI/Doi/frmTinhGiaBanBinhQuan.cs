using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;

namespace ThuTien.GUI.Doi
{
    public partial class frmTinhGiaBanBinhQuan : Form
    {
        CHoaDon _cHoaDon = new CHoaDon();

        public frmTinhGiaBanBinhQuan()
        {
            InitializeComponent();
        }

        private void frmTinhGiaBanBinhQuan_Load(object sender, EventArgs e)
        {
            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (cmbKy.SelectedIndex == 0)
                txtGiaBanBinhQuan.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _cHoaDon.TinhGiaBanBinhQuanByNam(int.Parse(cmbNam.SelectedValue.ToString())));
            else
                if (cmbKy.SelectedIndex > 0)
                    txtGiaBanBinhQuan.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _cHoaDon.TinhGiaBanBinhQuanByNamKy(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString())));
        }
    }
}
