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
using KTKS_DonKH.DAL;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    public partial class frmBaoCaoCHDB : Form
    {
        CCHDB _cCHDB = new CCHDB();
        CDocSo _cDocSo = new CDocSo();

        public frmBaoCaoCHDB()
        {
            InitializeComponent();
        }

        private void frmBaoCaoCHDB_Load(object sender, EventArgs e)
        {
            List<QUAN> lst = _cDocSo.GetDSQuan();
            QUAN quan = new QUAN();
            quan.MAQUAN = 0;
            quan.TENQUAN = "Tất Cả";
            lst.Insert(0, quan);
            cmbQuan_TheoNgayLap.DataSource = lst;
            cmbQuan_TheoNgayLap.DisplayMember = "TenQuan";
            cmbQuan_TheoNgayLap.ValueMember = "MaQuan";

        }

        private void btnBaoCao_TheoNgayLap_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            switch (cmbLoaiBaoCao_TheoNgayLap.SelectedItem.ToString())
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

                switch (cmbLoaiBaoCao_TheoNgayLap.SelectedItem.ToString())
                {
                    case "DS Cắt Hủy Đã Xử Lý":
                        dr["LoaiBaoCao"] = "TB CẮT HỦY ĐÃ XỬ LÝ";
                        dr["SoPhieu"] = item["MaCTCHDB"].ToString().Insert(item["MaCTCHDB"].ToString().Length - 2, "-");
                        break;
                    case "DS Cắt Hủy Chưa Xử Lý":
                        dr["LoaiBaoCao"] = "TB CẮT HỦY CHƯA XỬ LÝ";
                        dr["SoPhieu"] = item["MaCTCHDB"].ToString().Insert(item["MaCTCHDB"].ToString().Length - 2, "-");
                        break;
                    case "DS Cắt Tạm Đã Xử Lý":
                        dr["LoaiBaoCao"] = "TB CẮT TẠM ĐÃ XỬ LÝ";
                        dr["SoPhieu"] = item["MaCTCTDB"].ToString().Insert(item["MaCTCTDB"].ToString().Length - 2, "-");
                        break;
                    case "DS Cắt Tạm Chưa Xử Lý":
                        dr["LoaiBaoCao"] = "TB CẮT TẠM CHƯA XỬ LÝ";
                        dr["SoPhieu"] = item["MaCTCTDB"].ToString().Insert(item["MaCTCTDB"].ToString().Length - 2, "-");
                        break;
                    default:
                        break;
                }

                dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                dr["CreateDate"] = item["CreateDate"].ToString();
                if (item["DanhBo"].ToString()!="")
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

        private void btnBaoCao_TheoNgayXuLy_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            switch (cmbLoaiBaoCao_TheoNgayXuLy.SelectedItem.ToString())
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

                switch (cmbLoaiBaoCao_TheoNgayXuLy.SelectedItem.ToString())
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
                if (item["DanhBo"].ToString() != "")
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

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DataTable dtCTDB = new DataTable();
            DataTable dtCHDB = new DataTable();
            DataTable dtYCCHDB = new DataTable();

                dtCTDB = _cCHDB.GetDSCatTam(dateTu.Value, dateDen.Value);
                dtCHDB = _cCHDB.GetDSCatHuy(dateTu.Value, dateDen.Value);
                dtYCCHDB = _cCHDB.LoadDSYCCHDB_Don(dateTu.Value, dateDen.Value);

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow itemRow in dtCTDB.Rows)
            {
                DataRow dr = dsBaoCao.Tables["ThongKeCHDB"].NewRow();
                dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                dr["LoaiCat"] = "Lập Thông Báo Cắt Tạm";
                dr["LyDo"] = itemRow["LyDo"];
                dr["DanhBo"] = itemRow["DanhBo"];
                if (!string.IsNullOrEmpty(itemRow["NoiDungXuLy"].ToString()))
                    dr["NoiDungXuLy"] = itemRow["NoiDungXuLy"];
                else
                    dr["NoiDungXuLy"] = "Chưa Xử Lý";

                //if (bool.Parse(itemRow["DaLapPhieu"].ToString()))
                //{
                //    dr["LapPhieu"] = "True";
                //}

                dsBaoCao.Tables["ThongKeCHDB"].Rows.Add(dr);
            }

            foreach (DataRow itemRow in dtCHDB.Rows)
            {
                DataRow dr = dsBaoCao.Tables["ThongKeCHDB"].NewRow();
                dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                dr["LoaiCat"] = "Lập Thông Báo Cắt Hủy";
                dr["LyDo"] = itemRow["LyDo"];
                dr["DanhBo"] = itemRow["DanhBo"];
                if (!string.IsNullOrEmpty(itemRow["NoiDungXuLy"].ToString()))
                    dr["NoiDungXuLy"] = itemRow["NoiDungXuLy"];
                else
                    dr["NoiDungXuLy"] = "Chưa Xử Lý";

                //if (bool.Parse(itemRow["DaLapPhieu"].ToString()))
                //{
                //    dr["LapPhieu"] = "True";
                //}

                dsBaoCao.Tables["ThongKeCHDB"].Rows.Add(dr);
            }

            DataSetBaoCao dsBaoCaoPhieuHuy = new DataSetBaoCao();
            foreach (DataRow itemRow in dtYCCHDB.Rows)
            {
                DataRow dr = dsBaoCaoPhieuHuy.Tables["ThongKeCHDB"].NewRow();
                dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");
                dr["LoaiCat"] = "Lập Phiếu Hủy Danh Bộ";
                dr["LyDo"] = itemRow["LyDo"];
                dr["DanhBo"] = itemRow["DanhBo"];
                //if (!string.IsNullOrEmpty(itemRow["NoiDungTroNgai"].ToString()))
                //    dr["NoiDungTroNgai"] = itemRow["NoiDungTroNgai"];
                //else
                //    dr["NoiDungTroNgai"] = "Chưa Xử Lý";

                dsBaoCaoPhieuHuy.Tables["ThongKeCHDB"].Rows.Add(dr);
            }

            rptThongKeCHDB rpt = new rptThongKeCHDB();
            rpt.SetDataSource(dsBaoCao);
            rpt.Subreports[0].SetDataSource(dsBaoCaoPhieuHuy);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }


    }
}