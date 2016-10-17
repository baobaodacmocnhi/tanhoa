using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.CatHuyDanhBo;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.CatHuyDanhBo;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    public partial class frmBaoCaoCHDB : Form
    {
        CCHDB _cCHDB = new CCHDB();

        public frmBaoCaoCHDB()
        {
            InitializeComponent();
        }

        private void frmBaoCaoCHDB_Load(object sender, EventArgs e)
        {

        }

        private void btnBaoCaoNgayLap_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            switch (cmbLoaiBaoCaoNgayLap.SelectedItem.ToString())
            {
                case "DS Cắt Hủy Đã Xử Lý":
                    dt = _cCHDB.GetDSCatHuy_NgayLap_DaXuLy(dateTu.Value, dateDen.Value);
                    break;
                case "DS Cắt Hủy Chưa Xử Lý":
                    dt = _cCHDB.GetDSCatHuy_NgayLap_ChuaXuLy(dateTu.Value, dateDen.Value);
                    break;
                case "DS Cắt Tạm Đã Xử Lý":
                    dt = _cCHDB.GetDSCatTam_NgayLap_DaXuLy(dateTu.Value, dateDen.Value);
                    break;
                case "DS Cắt Tạm Chưa Xử Lý":
                    dt = _cCHDB.GetDSCatTam_NgayLap_ChuaXuLy(dateTu.Value, dateDen.Value);
                    break;
                default:
                    break;
            }

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["ThongBaoCHDB"].NewRow();

                switch (cmbLoaiBaoCaoNgayLap.SelectedItem.ToString())
                {
                    case "DS Cắt Hủy Đã Xử Lý":
                        dr["LoaiBaoCao"] = "CẮT HỦY ĐÃ XỬ LÝ";
                        dr["SoPhieu"] = item["MaCTCHDB"].ToString().Insert(item["MaCTCHDB"].ToString().Length - 2, "-");
                        break;
                    case "DS Cắt Hủy Chưa Xử Lý":
                        dr["LoaiBaoCao"] = "CẮT HỦY CHƯA XỬ LÝ";
                        dr["SoPhieu"] = item["MaCTCHDB"].ToString().Insert(item["MaCTCHDB"].ToString().Length - 2, "-");
                        break;
                    case "DS Cắt Tạm Đã Xử Lý":
                        dr["LoaiBaoCao"] = "CẮT TẠM ĐÃ XỬ LÝ";
                        dr["SoPhieu"] = item["MaCTCTDB"].ToString().Insert(item["MaCTCTDB"].ToString().Length - 2, "-");
                        break;
                    case "DS Cắt Tạm Chưa Xử Lý":
                        dr["LoaiBaoCao"] = "CẮT CHƯA ĐÃ XỬ LÝ";
                        dr["SoPhieu"] = item["MaCTCTDB"].ToString().Insert(item["MaCTCTDB"].ToString().Length - 2, "-");
                        break;
                    default:
                        break;
                }

                dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                dr["CreateDate"] = item["CreateDate"].ToString();
                dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = item["HoTen"].ToString();
                dr["DiaChi"] = item["DiaChi"].ToString();
                dr["LyDo"] = item["LyDo"].ToString();
                dr["NgayXuLy"] = item["NgayXuLy"].ToString();
                dr["NoiDungXuLy"] = item["NoiDungXuLy"].ToString();
                dsBaoCao.Tables["ThongBaoCHDB"].Rows.Add(dr);
            }

            rptDSCHDB rpt = new rptDSCHDB();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void btnBaoCaoNgayXuLy_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            switch (cmbLoaiBaoCaoNgayXuLy.SelectedItem.ToString())
            {
                case "DS Cắt Hủy":
                    dt = _cCHDB.GetDSCatHuy_NgayXuLy_DaXuLy(dateTu.Value, dateDen.Value);
                    break;
                case "DS Cắt Tạm":
                    dt = _cCHDB.GetDSCatTam_NgayXuLy_DaXuLy(dateTu.Value, dateDen.Value);
                    break;
                default:
                    break;
            }

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["ThongBaoCHDB"].NewRow();

                switch (cmbLoaiBaoCaoNgayXuLy.SelectedItem.ToString())
                {
                    case "DS Cắt Hủy":
                        dr["LoaiBaoCao"] = "CẮT HỦY ĐÃ XỬ LÝ";
                        dr["SoPhieu"] = item["MaCTCHDB"].ToString().Insert(item["MaCTCHDB"].ToString().Length - 2, "-");
                        break;
                    case "DS Cắt Tạm":
                        dr["LoaiBaoCao"] = "CẮT TẠM ĐÃ XỬ LÝ";
                        dr["SoPhieu"] = item["MaCTCTDB"].ToString().Insert(item["MaCTCTDB"].ToString().Length - 2, "-");
                        break;
                    default:
                        break;
                }

                dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                dr["CreateDate"] = item["CreateDate"].ToString();
                dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = item["HoTen"].ToString();
                dr["DiaChi"] = item["DiaChi"].ToString();
                dr["LyDo"] = item["LyDo"].ToString();
                dr["NgayXuLy"] = item["NgayXuLy"].ToString();
                dr["NoiDungXuLy"] = item["NoiDungXuLy"].ToString();
                dr["GroupNoiDungXuLy"] = "True";
                dsBaoCao.Tables["ThongBaoCHDB"].Rows.Add(dr);
            }

            rptDSCHDB rpt = new rptDSCHDB();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }


    }
}