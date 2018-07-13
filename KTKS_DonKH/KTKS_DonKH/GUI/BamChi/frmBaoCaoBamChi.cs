using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.BamChi;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.BamChi;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.BaoCao.KiemTraXacMinh;

namespace KTKS_DonKH.GUI.BamChi
{
    public partial class frmBaoCaoBamChi : Form
    {
        CBamChi _cBamChi = new CBamChi();
        CTrangThaiBamChi _cTrangThaiBamChi = new CTrangThaiBamChi();

        public frmBaoCaoBamChi()
        {
            InitializeComponent();
        }

        private void frmBaoCaoBamChi_Load(object sender, EventArgs e)
        {

        }

        private void btnBaoCao_ThongKeTrangThaiBamChi_Click(object sender, EventArgs e)
        {
            DataTable dt=new DataTable();
            if (chkAll_ThongKeHienTrangKiemTra.Checked == true)
                dt = _cBamChi.GetDS("", dateTu_ThongKeTrangThaiBamChi.Value, dateDen_ThongKeTrangThaiBamChi.Value);
            else
            {
            if (CTaiKhoan.ToKH)
                dt = _cBamChi.GetDS("TKH",dateTu_ThongKeTrangThaiBamChi.Value, dateDen_ThongKeTrangThaiBamChi.Value);
            else
                if (CTaiKhoan.ToXL)
                    dt = _cBamChi.GetDS("TXL", dateTu_ThongKeTrangThaiBamChi.Value, dateDen_ThongKeTrangThaiBamChi.Value);
                else
                    if (CTaiKhoan.ToBC)
                        dt = _cBamChi.GetDS("TBC", dateTu_ThongKeTrangThaiBamChi.Value, dateDen_ThongKeTrangThaiBamChi.Value);
            }

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DSBamChi"].NewRow();
                dr["TuNgay"] = dateTu_ThongKeTrangThaiBamChi.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen_ThongKeTrangThaiBamChi.Value.ToString("dd/MM/yyyy");
                //dr["MaCTBC"] = item["MaCTBC"];
                dr["TenLD"] = item["TenLD"];
                
                dsBaoCao.Tables["DSBamChi"].Rows.Add(dr);
            }

            rptThongKeTrangThaiBamChi rpt = new rptThongKeTrangThaiBamChi();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void btnIn_ThongKeTrangThaiBamChi_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (chkAll_ThongKeHienTrangKiemTra.Checked == true)
                dt = _cBamChi.GetDS("", dateTu_ThongKeTrangThaiBamChi.Value, dateDen_ThongKeTrangThaiBamChi.Value);
            else
            {
                if (CTaiKhoan.ToKH)
                    dt = _cBamChi.GetDS("TKH", dateTu_ThongKeTrangThaiBamChi.Value, dateDen_ThongKeTrangThaiBamChi.Value);
                else
                    if (CTaiKhoan.ToXL)
                        dt = _cBamChi.GetDS("TXL", dateTu_ThongKeTrangThaiBamChi.Value, dateDen_ThongKeTrangThaiBamChi.Value);
                    else
                        if (CTaiKhoan.ToBC)
                            dt = _cBamChi.GetDS("TBC", dateTu_ThongKeTrangThaiBamChi.Value, dateDen_ThongKeTrangThaiBamChi.Value);
            }
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DSKTXM"].NewRow();

                dr["TuNgay"] = dateTu_ThongKeTrangThaiBamChi.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen_ThongKeTrangThaiBamChi.Value.ToString("dd/MM/yyyy");
                dr["LoaiBaoCao"] = "BẤM CHÌ";
                dr["MaDon"] = item["MaDon"].ToString().Insert(item["MaDon"].ToString().Length - 2, "-");
                if (string.IsNullOrEmpty(item["DanhBo"].ToString()) == false && item["DanhBo"].ToString().Length==11)
                dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = item["HoTen"];
                dr["DiaChi"] = item["DiaChi"];
                dr["GhiChu"]=item["TenLD"];

                dsBaoCao.Tables["DSKTXM"].Rows.Add(dr);
            }

            rptKTXM_XuLy rpt = new rptKTXM_XuLy();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }


    }
}

