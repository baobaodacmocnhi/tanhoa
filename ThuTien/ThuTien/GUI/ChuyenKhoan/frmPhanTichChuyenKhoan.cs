using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.ChuyenKhoan;
using ThuTien.LinQ;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.Doi;

namespace ThuTien.GUI.ChuyenKhoan
{
    public partial class frmPhanTichChuyenKhoan : Form
    {
        CDichVuThu _cDichVuThu = new CDichVuThu();
        CTo _cTo = new CTo();
        CHoaDon _cHoaDon = new CHoaDon();
        CNguoiDung _cNguoiDung = new CNguoiDung();

        public frmPhanTichChuyenKhoan()
        {
            InitializeComponent();
        }

        private void frmPhanTichChuyenKhoan_Load(object sender, EventArgs e)
        {
            dgvTo_PhanTich.AutoGenerateColumns = false;
            dgvNhanVien_PhanTich.AutoGenerateColumns = false;

            DataTable dtDichVuThu = _cDichVuThu.GetDichVuThu();
            DataRow dr = dtDichVuThu.NewRow();
            dr["ID"] = "";
            dr["TenDichVu"] = "Tất Cả";
            dtDichVuThu.Rows.InsertAt(dr, 0);
            cmbDichVuThu.DataSource = dtDichVuThu;
            cmbDichVuThu.DisplayMember = "TenDichVu";
            cmbDichVuThu.ValueMember = "ID";

            List<TT_To> lstTo = _cTo.GetDSHanhThu();
            TT_To to = new TT_To();
            to.MaTo = 0;
            to.TenTo = "Tất Cả";
            lstTo.Insert(0, to);
            cmbTo_PhanTich.DataSource = lstTo;
            cmbTo_PhanTich.DisplayMember = "TenTo";
            cmbTo_PhanTich.ValueMember = "MaTo";

            cmbNam_PhanTich.DataSource = _cHoaDon.GetNam();
            cmbNam_PhanTich.DisplayMember = "Nam";
            cmbNam_PhanTich.ValueMember = "Nam";

        }

        private void cmbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTo_PhanTich.SelectedIndex > 0)
            {
                List<TT_NguoiDung> lstND = _cNguoiDung.GetDSHanhThuByMaTo(int.Parse(cmbTo_PhanTich.SelectedValue.ToString()));
                TT_NguoiDung nguoidung = new TT_NguoiDung();
                nguoidung.MaND = 0;
                nguoidung.HoTen = "Tất Cả";
                lstND.Insert(0, nguoidung);
                cmbNhanVien_PhanTich.DataSource = lstND;
                cmbNhanVien_PhanTich.DisplayMember = "HoTen";
                cmbNhanVien_PhanTich.ValueMember = "MaND";
            }
            else
            {
                cmbNhanVien_PhanTich.DataSource = null;
            }
        }

        private void btnXem_PhanTich_Click(object sender, EventArgs e)
        {

        }

        private void btnInDS_PhanTich_Click(object sender, EventArgs e)
        {

        }
    }
}
