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
using KTKS_DonKH.LinQ;

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
            List<BamChi_TrangThai> lst = _cTrangThaiBamChi.GetDS();
            BamChi_TrangThai en=new BamChi_TrangThai();
            en.TenTTBC="Tất Cả";
            lst.Insert(0, en);
            cmbTrangThaiBC.DataSource = lst;
            cmbTrangThaiBC.DisplayMember = "TenTTBC";
            cmbTrangThaiBC.ValueMember = "TenTTBC";
            cmbTrangThaiBC.SelectedIndex = -1;
        }

        private void btnBaoCao_ThongKeLoaiDon_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = _cBamChi.getDS(dateTu_ThongKeLoaiDon.Value, dateDen_ThongKeLoaiDon.Value);

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DSBamChi"].NewRow();
                dr["TuNgay"] = dateTu_ThongKeLoaiDon.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen_ThongKeLoaiDon.Value.ToString("dd/MM/yyyy");
                //dr["MaCTBC"] = item["MaCTBC"];
                dr["TenLD"] = item["TenLD"];

                dsBaoCao.Tables["DSBamChi"].Rows.Add(dr);
            }

            rptThongKeTrangThaiBamChi rpt = new rptThongKeTrangThaiBamChi();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void btnIn_ThongKeLoaiDon_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = _cBamChi.getDS(dateTu_ThongKeLoaiDon.Value, dateDen_ThongKeLoaiDon.Value);

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DSKTXM"].NewRow();

                dr["TuNgay"] = dateTu_ThongKeLoaiDon.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen_ThongKeLoaiDon.Value.ToString("dd/MM/yyyy");
                dr["LoaiBaoCao"] = "BẤM CHÌ";
                dr["MaDon"] = item["MaDon"].ToString();
                if (string.IsNullOrEmpty(item["DanhBo"].ToString()) == false && item["DanhBo"].ToString().Length == 11)
                    dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = item["HoTen"];
                dr["DiaChi"] = item["DiaChi"];
                dr["GhiChu"] = item["TenLD"];

                dsBaoCao.Tables["DSKTXM"].Rows.Add(dr);
            }

            rptKTXM_XuLy rpt = new rptKTXM_XuLy();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void btnBaoCao_ThongKeTrangThaiBamChi_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (cmbTrangThaiBC.SelectedIndex == 0)
                dt = _cBamChi.getDS(dateTu_ThongKeTrangThaiBamChi.Value, dateDen_ThongKeTrangThaiBamChi.Value);
            else
                if (cmbTrangThaiBC.SelectedIndex > 0)
                    dt = _cBamChi.getDS(cmbTrangThaiBC.SelectedValue.ToString(), dateTu_ThongKeTrangThaiBamChi.Value, dateDen_ThongKeTrangThaiBamChi.Value);
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DSBamChi"].NewRow();
                dr["TuNgay"] = dateTu_ThongKeTrangThaiBamChi.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen_ThongKeTrangThaiBamChi.Value.ToString("dd/MM/yyyy");
                //dr["MaCTBC"] = item["MaCTBC"];
                dr["TenLD"] = item["TrangThaiBC"];

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
            if (cmbTrangThaiBC.SelectedIndex == 0)
                dt = _cBamChi.getDS(dateTu_ThongKeTrangThaiBamChi.Value, dateDen_ThongKeTrangThaiBamChi.Value);
            else
                if (cmbTrangThaiBC.SelectedIndex > 0)
                    dt = _cBamChi.getDS(cmbTrangThaiBC.SelectedValue.ToString(), dateTu_ThongKeTrangThaiBamChi.Value, dateDen_ThongKeTrangThaiBamChi.Value);

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DSKTXM"].NewRow();

                dr["TuNgay"] = dateTu_ThongKeTrangThaiBamChi.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen_ThongKeTrangThaiBamChi.Value.ToString("dd/MM/yyyy");
                dr["LoaiBaoCao"] = "BẤM CHÌ";
                dr["MaDon"] = item["MaDon"].ToString();
                if (string.IsNullOrEmpty(item["DanhBo"].ToString()) == false && item["DanhBo"].ToString().Length == 11)
                    dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = item["HoTen"];
                dr["DiaChi"] = item["DiaChi"];
                dr["GhiChu"] = item["TrangThaiBC"];

                dsBaoCao.Tables["DSKTXM"].Rows.Add(dr);
            }

            rptKTXM_XuLy rpt = new rptKTXM_XuLy();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }


    }
}

