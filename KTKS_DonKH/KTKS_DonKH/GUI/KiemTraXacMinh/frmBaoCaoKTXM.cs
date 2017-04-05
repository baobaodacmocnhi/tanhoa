using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.BaoCao.KiemTraXacMinh;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.KiemTraXacMinh
{
    public partial class frmBaoCaoKTXM : Form
    {
        CKTXM _cKTXM = new CKTXM();
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();

        public frmBaoCaoKTXM()
        {
            InitializeComponent();
        }

        private void frmBaoCaoKTXM_Load(object sender, EventArgs e)
        {

        }

        private void btnBaoCao_ThongKeHienTrangKiemTra_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (chkAll_ThongKeHienTrangKiemTra.Checked==true)
                dt = _cKTXM.GetDS(dateTu_ThongKeHienTrangKiemTra.Value, dateDen_ThongKeHienTrangKiemTra.Value);
            else
            {
                if (CTaiKhoan.ToKH)
                    dt = _cKTXM.GetDS("TKH", dateTu_ThongKeHienTrangKiemTra.Value, dateDen_ThongKeHienTrangKiemTra.Value);
                else
                    if (CTaiKhoan.ToXL)
                        dt = _cKTXM.GetDS("TXL", dateTu_ThongKeHienTrangKiemTra.Value, dateDen_ThongKeHienTrangKiemTra.Value);
                    else
                        if (CTaiKhoan.ToBC)
                            dt = _cKTXM.GetDS("TBC", dateTu_ThongKeHienTrangKiemTra.Value, dateDen_ThongKeHienTrangKiemTra.Value);
            }

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DSKTXM"].NewRow();

                dr["TuNgay"] = dateTu_ThongKeHienTrangKiemTra.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen_ThongKeHienTrangKiemTra.Value.ToString("dd/MM/yyyy");
                if (chkAll_ThongKeHienTrangKiemTra.Checked==false)
                dr["To"] = item["To"];
                dr["MaCTKTXM"] = item["MaCTKTXM"];
                dr["STT_HTKT"] = item["STT_HTKT"];
                dr["HienTrangKiemTra"] = item["HienTrangKiemTra"];
                dr["TieuThuTrungBinh"] = item["TieuThuTrungBinh"];

                dsBaoCao.Tables["DSKTXM"].Rows.Add(dr);
            }

            rptThongKeHienTrangKiemTra rpt = new rptThongKeHienTrangKiemTra();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo_SoLuong.SelectedItem.ToString())
            {
                case "Mã Đơn":
                case "Danh Bộ":
                case "Số Công Văn":
                    txtNoiDungTimKiem.Visible = true;
                    txtNoiDungTimKiem2.Visible = true;
                    panel1.Visible = false;
                    break;
                case "Ngày":
                    txtNoiDungTimKiem.Visible = false;
                    txtNoiDungTimKiem2.Visible = false;
                    panel1.Visible = true;
                    break;
                default:
                    txtNoiDungTimKiem.Visible = false;
                    txtNoiDungTimKiem2.Visible = false;
                    panel1.Visible = false;
                    break;
            }
        }

        private void btnBaoCao_SoLuong_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            switch (cmbTimTheo_SoLuong.SelectedItem.ToString())
            {
                case "Mã Đơn":
                    if (txtNoiDungTimKiem.Text.Trim() != "" && txtNoiDungTimKiem2.Text.Trim() != "")
                    {
                        MessageBox.Show("Liên hệ BảoBảo", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        if (txtNoiDungTimKiem.Text.Trim() != "")
                        {
                            if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TXL"))
                                dt = _cKTXM.GetDS("TXL", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                            else
                                if (txtNoiDungTimKiem.Text.Trim().ToUpper().Contains("TBC"))
                                    dt = _cKTXM.GetDS("TBC", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                                else
                                    dt = _cKTXM.GetDS("TKH", decimal.Parse(txtNoiDungTimKiem.Text.Trim().Substring(3).Replace("-", "")));
                        }
                    break;
                case "Danh Bộ":
                    dt = _cKTXM.GetDS(txtNoiDungTimKiem.Text.Trim());
                    break;
                case "Số Công Văn":
                    dt = _cKTXM.GetDSBySoCongVan(txtNoiDungTimKiem.Text.Trim());
                    break;
                case "Ngày":
                    if (CTaiKhoan.ToKH)
                        dt = _cKTXM.GetDS("TKH", dateTu_SoLuong.Value, dateDen_SoLuong.Value);
                    else
                        if (CTaiKhoan.ToXL)
                            dt = _cKTXM.GetDS("TXL", dateTu_SoLuong.Value, dateDen_SoLuong.Value);
                        else
                            if (CTaiKhoan.ToBC)
                                dt = _cKTXM.GetDS("TBC", dateTu_SoLuong.Value, dateDen_SoLuong.Value);
                    break;
                default:
                    break;
            }

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataRow itemRow in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DSKTXM"].NewRow();

                if (CTaiKhoan.ToKH)
                    dr["To"] = "TỔ KHÁCH HÀNG";
                else
                    if (CTaiKhoan.ToXL)
                        dr["To"] = "TỔ XỬ LÝ";
                    else
                        if (CTaiKhoan.ToBC)
                            dr["To"] = "TỔ BẤM CHÌ";
                dr["TuNgay"] = dateTu_ThongKeHienTrangKiemTra.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen_ThongKeHienTrangKiemTra.Value.ToString("dd/MM/yyyy");
                dr["MaCTKTXM"] = itemRow["MaCTKTXM"];
                dr["MaDon"] = itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-");
                dr["NguoiLap"] = itemRow["CreateBy"];

                dsBaoCao.Tables["DSKTXM"].Rows.Add(dr);
            }

            rptThongKeDSKTXM rpt = new rptThongKeDSKTXM();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnBaoCao_DScoTruyThu_Click(object sender, EventArgs e)
        {
            DataTable dt = _cKTXM.GetDScoTruyThu(dateTu_DScoTruyThu.Value, dateDen_DScoTruyThu.Value);
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow itemRow in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DSKTXM"].NewRow();

                dr["TuNgay"] = dateTu_DScoTruyThu.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen_DScoTruyThu.Value.ToString("dd/MM/yyyy");
                dr["TenLD"] = itemRow["TenLD"];
                dr["MaCTKTXM"] = itemRow["MaCTKTXM"];
                dr["MaDon"] = itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-");
                if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                    dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = itemRow["HoTen"];
                dr["DiaChi"] = itemRow["DiaChi"];
                dr["DinhMucCu"] = itemRow["DinhMuc"];
                dr["DinhMucMoi"] = itemRow["DinhMucMoi"];
                dr["NguoiLap"] = CTaiKhoan.HoTen;

                dsBaoCao.Tables["DSKTXM"].Rows.Add(dr);
            }
            rptKTXMcoTruyThu rpt = new rptKTXMcoTruyThu();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

    }
}
