using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.ThuTraLoi;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.ThuTraLoi
{
    public partial class frmBaoCaoTTTL : Form
    {
        CToTrinh _cToTrinh = new CToTrinh();
        CTTTL _cTTTL = new CTTTL();

        public frmBaoCaoTTTL()
        {
            InitializeComponent();
        }

        private void frmBaoCaoTTTL_Load(object sender, EventArgs e)
        {

        }

        private void dateDen_ToTrinh_ValueChanged(object sender, EventArgs e)
        {
            DataTable dt = _cToTrinh.getGroup_VeViec(dateTu_ToTrinh.Value, dateDen_ToTrinh.Value);
            DataRow dr = dt.NewRow();
            dr["VeViec"] = "Tất Cả";
            dt.Rows.InsertAt(dr, 0);
            cmbNoiDung_ToTrinh.DataSource = dt;
            cmbNoiDung_ToTrinh.DisplayMember = "VeViec";
            cmbNoiDung_ToTrinh.ValueMember = "VeViec";
        }

        private void dateDen_TTTL_ValueChanged(object sender, EventArgs e)
        {
            DataTable dt = _cTTTL.getGroup_VeViec(dateTu_TTTL.Value, dateDen_TTTL.Value);
            DataRow dr = dt.NewRow();
            dr["VeViec"] = "Tất Cả";
            dt.Rows.InsertAt(dr, 0);
            cmbNoiDung_TTTL.DataSource = dt;
            cmbNoiDung_TTTL.DisplayMember = "VeViec";
            cmbNoiDung_TTTL.ValueMember = "VeViec";
        }

        private void btnBaoCao_ToTrinh_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (cmbNoiDung_ToTrinh.SelectedValue.ToString() == "Tất Cả")
                dt = _cToTrinh.getDS_ChiTiet_VeViec(dateTu_ToTrinh.Value, dateDen_ToTrinh.Value);
            else
                dt = _cToTrinh.getDS_ChiTiet_VeViec(cmbNoiDung_ToTrinh.SelectedValue.ToString(), dateTu_ToTrinh.Value, dateDen_ToTrinh.Value);
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
            {
                {
                    DataRow dr = dsBaoCao.Tables["DanhSach"].NewRow();

                    dr["TuNgay"] = dateTu_ToTrinh.Value.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = dateDen_ToTrinh.Value.ToString("dd/MM/yyyy");
                    dr["LoaiBaoCao"] = "TỜ TRÌNH";
                    dr["MaDon"] = item["MaDon"];
                    dr["DanhBo"] = item["DanhBo"];
                    dr["HoTen"] = item["HoTen"];
                    dr["DiaChi"] = item["DiaChi"];
                    dr["NhomDon"] = item["VeViec"];
                    dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();

                    dsBaoCao.Tables["DanhSach"].Rows.Add(dr);
                }
            }
            rptDanhSach_Doc_GroupNhomDon rpt = new rptDanhSach_Doc_GroupNhomDon();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void btnBaoCao_TTTL_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (cmbNoiDung_TTTL.SelectedValue.ToString() == "Tất Cả")
                dt = _cTTTL.getDS_ChiTiet_VeViec(dateTu_TTTL.Value, dateDen_TTTL.Value);
            else
                dt = _cTTTL.getDS_ChiTiet_VeViec(cmbNoiDung_TTTL.SelectedValue.ToString(), dateTu_TTTL.Value, dateDen_TTTL.Value);
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
            {
                {
                    DataRow dr = dsBaoCao.Tables["DanhSach"].NewRow();

                    dr["TuNgay"] = dateTu_TTTL.Value.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = dateDen_TTTL.Value.ToString("dd/MM/yyyy");
                    dr["LoaiBaoCao"] = "THƯ TRẢ LỜI";
                    dr["MaDon"] = item["MaDon"];
                    dr["DanhBo"] = item["DanhBo"];
                    dr["HoTen"] = item["HoTen"];
                    dr["DiaChi"] = item["DiaChi"];
                    dr["NhomDon"] = item["VeViec"];
                    dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();

                    dsBaoCao.Tables["DanhSach"].Rows.Add(dr);
                }
            }
            rptDanhSach_Doc_GroupNhomDon rpt = new rptDanhSach_Doc_GroupNhomDon();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }
    }
}
