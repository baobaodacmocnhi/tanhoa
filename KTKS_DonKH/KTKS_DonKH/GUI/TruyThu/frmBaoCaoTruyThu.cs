using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.TruyThu;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.TruyThu;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.TruyThu
{
    public partial class frmBaoCaoTruyThu : Form
    {
        CTruyThuTienNuoc _cTTTN = new CTruyThuTienNuoc();

        public frmBaoCaoTruyThu()
        {
            InitializeComponent();
        }

        private void frmBaoCaoTruyThu_Load(object sender, EventArgs e)
        {

        }

        private void btnBaoCao_ThongKeTruyThu_Click(object sender, EventArgs e)
        {
            DataTable dt = _cTTTN.GetDS(dateTu_ThongKeTruyThu.Value, dateDen_ThongKeTruyThu.Value);

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["TruyThuTienNuoc"].NewRow();

                dr["TuNgay"] = dateTu_ThongKeTruyThu.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen_ThongKeTruyThu.Value.ToString("dd/MM/yyyy");
                dr["NoiDung"] = item["NoiDung"];
                dr["TieuThuMoi"] = item["Tongm3BinhQuan"];
                dr["TongCongMoi"] = item["TongTien"];

                dsBaoCao.Tables["TruyThuTienNuoc"].Rows.Add(dr);
            }

            rptThongKeTruyThu rpt = new rptThongKeTruyThu();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();

            dsBaoCao = new DataSetBaoCao();

            if (radDaThanhToan.Checked == true)
            {
                foreach (DataRow item in dt.Rows)
                    if (bool.Parse(item["XepDon"].ToString()) == true)
                    {
                        DataRow dr = dsBaoCao.Tables["TruyThuTienNuoc"].NewRow();

                        dr["TuNgay"] = dateTu_ThongKeTruyThu.Value.ToString("dd/MM/yyyy");
                        dr["DenNgay"] = dateDen_ThongKeTruyThu.Value.ToString("dd/MM/yyyy");
                        dr["LoaiBaoCao"] = "ĐÃ THANH TOÁN";
                        dr["MaDon"] = item["MaDon"].ToString().Insert(item["MaDon"].ToString().Length - 2, "-");
                        dr["NgayLap"] = item["CreateDate"];
                        dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                        dr["HoTen"] = item["HoTen"];
                        dr["DiaChi"] = item["DiaChi"];
                        dr["NoiDung"] = item["NoiDung"];

                        dr["TieuThuMoi"] = item["Tongm3BinhQuan"];
                        dr["TongCongMoi"] = item["TongTien"];

                        dsBaoCao.Tables["TruyThuTienNuoc"].Rows.Add(dr);
                    }
            }
            else
                if (radChuaThanhToan.Checked == true)
                {
                    foreach (DataRow item in dt.Rows)
                        if (bool.Parse(item["XepDon"].ToString()) == false && int.Parse(item["TongTien"].ToString()) != 0)
                        {
                            DataRow dr = dsBaoCao.Tables["TruyThuTienNuoc"].NewRow();

                            dr["TuNgay"] = dateTu_ThongKeTruyThu.Value.ToString("dd/MM/yyyy");
                            dr["DenNgay"] = dateDen_ThongKeTruyThu.Value.ToString("dd/MM/yyyy");
                            dr["LoaiBaoCao"] = "CHƯA THANH TOÁN";
                            dr["MaDon"] = item["MaDon"].ToString().Insert(item["MaDon"].ToString().Length - 2, "-");
                            dr["NgayLap"] = item["CreateDate"];
                            dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                            dr["HoTen"] = item["HoTen"];
                            dr["DiaChi"] = item["DiaChi"];
                            dr["NoiDung"] = item["NoiDung"];

                            dr["TieuThuMoi"] = item["Tongm3BinhQuan"];
                            dr["TongCongMoi"] = item["TongTien"];

                            dsBaoCao.Tables["TruyThuTienNuoc"].Rows.Add(dr);
                        }
                }
                else
                    if (radGuiThu.Checked == true)
                    {
                        foreach (DataRow item in dt.Rows)
                            if (bool.Parse(item["XepDon"].ToString()) == false && int.Parse(item["TongTien"].ToString()) == 0)
                            {
                                DataRow dr = dsBaoCao.Tables["TruyThuTienNuoc"].NewRow();

                                dr["TuNgay"] = dateTu_ThongKeTruyThu.Value.ToString("dd/MM/yyyy");
                                dr["DenNgay"] = dateDen_ThongKeTruyThu.Value.ToString("dd/MM/yyyy");
                                dr["LoaiBaoCao"] = "GỬI THƯ";
                                dr["MaDon"] = item["MaDon"].ToString().Insert(item["MaDon"].ToString().Length - 2, "-");
                                dr["NgayLap"] = item["CreateDate"];
                                dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                                dr["HoTen"] = item["HoTen"];
                                dr["DiaChi"] = item["DiaChi"];
                                dr["NoiDung"] = item["NoiDung"];

                                dr["TieuThuMoi"] = item["Tongm3BinhQuan"];
                                dr["TongCongMoi"] = item["TongTien"];

                                dsBaoCao.Tables["TruyThuTienNuoc"].Rows.Add(dr);
                            }
                    }
            rptDSTruyThuTienNuoc rpt2 = new rptDSTruyThuTienNuoc();
            rpt2.SetDataSource(dsBaoCao);
            frmShowBaoCao frm2 = new frmShowBaoCao(rpt2);
            frm2.ShowDialog();


        }
    }
}
