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

namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    public partial class frmBaoCaoCHDB : Form
    {
        string _tuNgay = "", _denNgay = "";
        CCHDB _cCHDB = new CCHDB();

        public frmBaoCaoCHDB()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void frmBaoCaoCHDB_Load(object sender, EventArgs e)
        {

        }
        private void dateTu_ValueChanged(object sender, EventArgs e)
        {
            _tuNgay = dateTu.Value.ToString("dd/MM/yyyy");
            _denNgay = "";
        }

        private void dateDen_ValueChanged(object sender, EventArgs e)
        {
            _denNgay = dateDen.Value.ToString("dd/MM/yyyy");
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            if (radThongKeSoLuong.Checked)
            {
                DataTable dtCTDB = new DataTable();
                DataTable dtCHDB = new DataTable();
                DataTable dtYCCHDB = new DataTable();

                if (!string.IsNullOrEmpty(_tuNgay) && !string.IsNullOrEmpty(_denNgay))
                {
                    dtCTDB = _cCHDB.LoadDSCTCTDB(dateTu.Value, dateDen.Value);
                    dtCHDB = _cCHDB.LoadDSCTCHDB(dateTu.Value, dateDen.Value);
                    dtYCCHDB = _cCHDB.LoadDSYCCHDB_Don(dateTu.Value, dateDen.Value);
                }
                else
                    if (!string.IsNullOrEmpty(_tuNgay))
                    {
                        dtCTDB = _cCHDB.LoadDSCTCTDB(dateTu.Value);
                        dtCHDB = _cCHDB.LoadDSCTCHDB(dateTu.Value);
                        dtYCCHDB = _cCHDB.LoadDSYCCHDB_Don(dateTu.Value);
                    }

                DataSetBaoCao dsBaoCao = new DataSetBaoCao();

                int TCTBXuLy = 0;
                int TroNgai = 0;
                int ConLai = 0;
                int DaLapPhieu = 0;
                foreach (DataRow itemRow in dtCTDB.Rows)
                {
                    DataRow dr = dsBaoCao.Tables["ThongKeCHDB"].NewRow();
                    dr["TuNgay"] = _tuNgay;
                    dr["DenNgay"] = _denNgay;
                    dr["LoaiCat"] = "Lập Thông Báo Cắt Tạm";
                    dr["LyDo"] = itemRow["LyDo"];
                    dr["DanhBo"] = itemRow["DanhBo"];
                    if (bool.Parse(itemRow["TCTBXuLy"].ToString()))
                        TCTBXuLy++;
                    else
                        ConLai++;
                    if (bool.Parse(itemRow["TroNgai"].ToString()))
                        TroNgai++;
                    if (bool.Parse(itemRow["DaLapPhieu"].ToString()))
                        DaLapPhieu++;
                    dr["TCTBXuLy"] = TCTBXuLy;
                    dr["ConLai"] = ConLai;
                    dr["TroNgai"] = TroNgai;
                    dr["LapPhieu"] = DaLapPhieu;

                    dsBaoCao.Tables["ThongKeCHDB"].Rows.Add(dr);
                }

                TCTBXuLy = 0;
                TroNgai = 0;
                ConLai = 0;
                DaLapPhieu = 0;
                foreach (DataRow itemRow in dtCHDB.Rows)
                {
                    DataRow dr = dsBaoCao.Tables["ThongKeCHDB"].NewRow();
                    dr["TuNgay"] = _tuNgay;
                    dr["DenNgay"] = _denNgay;
                    dr["LoaiCat"] = "Lập Thông Báo Cắt Hủy";
                    dr["LyDo"] = itemRow["LyDo"];
                    dr["DanhBo"] = itemRow["DanhBo"];
                    if (bool.Parse(itemRow["TCTBXuLy"].ToString()))
                        TCTBXuLy++;
                    else
                        ConLai++;
                    if (bool.Parse(itemRow["TroNgai"].ToString()))
                        TroNgai++;
                    if (bool.Parse(itemRow["DaLapPhieu"].ToString()))
                        DaLapPhieu++;
                    dr["TCTBXuLy"] = TCTBXuLy;
                    dr["ConLai"] = ConLai;
                    dr["TroNgai"] = TroNgai;
                    dr["LapPhieu"] = DaLapPhieu;

                    dsBaoCao.Tables["ThongKeCHDB"].Rows.Add(dr);
                }

                foreach (DataRow itemRow in dtYCCHDB.Rows)
                {
                    DataRow dr = dsBaoCao.Tables["ThongKeCHDB"].NewRow();
                    dr["TuNgay"] = _tuNgay;
                    dr["DenNgay"] = _denNgay;
                    dr["LoaiCat"] = "Lập Phiếu Yêu Cầu Cắt Hủy";
                    dr["LyDo"] = itemRow["LyDo"];
                    dr["DanhBo"] = itemRow["DanhBo"];

                    dsBaoCao.Tables["ThongKeCHDB"].Rows.Add(dr);
                }

                dateTu.Value = DateTime.Now;
                dateDen.Value = DateTime.Now;
                _tuNgay = _denNgay = "";

                rptThongKeCHDB rpt = new rptThongKeCHDB();
                rpt.SetDataSource(dsBaoCao);
                crystalReportViewer1.ReportSource = rpt;
            }
            ///
            if (radDSYCCHDB.Checked || radDSYCCHDBNutBit.Checked)
            {
                DataTable dtYCCHDB = new DataTable();

                if (!string.IsNullOrEmpty(_tuNgay) && !string.IsNullOrEmpty(_denNgay))
                {
                    dtYCCHDB = _cCHDB.LoadDSYCCHDB(dateTu.Value, dateDen.Value);
                }
                else
                    if (!string.IsNullOrEmpty(_tuNgay))
                    {
                        dtYCCHDB = _cCHDB.LoadDSYCCHDB(dateTu.Value);
                    }

                DataSetBaoCao dsBaoCao = new DataSetBaoCao();

                if (radDSYCCHDB.Checked)
                {
                    foreach (DataRow itemRow in dtYCCHDB.Rows)
                    {
                        DataRow dr = dsBaoCao.Tables["DSYCCHDB"].NewRow();
                        dr["TuNgay"] = _tuNgay;
                        dr["DenNgay"] = _denNgay;
                        dr["SoPhieu"] = itemRow["SoPhieu"].ToString().Insert(itemRow["SoPhieu"].ToString().Length - 2, "-");
                        dr["NgayLap"] = itemRow["CreateDate"];
                        dr["HieuLucKy"] = itemRow["HieuLucKy"];
                        dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                        dr["HoTen"] = itemRow["HoTen"];
                        dr["DiaChi"] = itemRow["DiaChi"];
                        if (itemRow["LyDo"].ToString() == "Vấn Đề Khác")
                            dr["LyDo"] = itemRow["GhiChuLyDo"];
                        else
                            dr["LyDo"] = itemRow["LyDo"] + " " + itemRow["GhiChuLyDo"];

                        dsBaoCao.Tables["DSYCCHDB"].Rows.Add(dr);
                    }

                    dateTu.Value = DateTime.Now;
                    dateDen.Value = DateTime.Now;
                    _tuNgay = _denNgay = "";

                    rptDSYCCHDB rpt = new rptDSYCCHDB();
                    rpt.SetDataSource(dsBaoCao);
                    crystalReportViewer1.ReportSource = rpt;
                }
                else
                    if (radDSYCCHDBNutBit.Checked)
                    {
                        foreach (DataRow itemRow in dtYCCHDB.Rows)
                            if (!string.IsNullOrEmpty(itemRow["NgayCatTamNutBit"].ToString()))
                            {
                                DataRow dr = dsBaoCao.Tables["DSYCCHDB"].NewRow();
                                dr["TuNgay"] = _tuNgay;
                                dr["DenNgay"] = _denNgay;
                                dr["SoPhieu"] = itemRow["SoPhieu"].ToString().Insert(itemRow["SoPhieu"].ToString().Length - 2, "-");
                                dr["NgayLap"] = itemRow["CreateDate"];
                                dr["HieuLucKy"] = itemRow["HieuLucKy"];
                                dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                                dr["HoTen"] = itemRow["HoTen"];
                                dr["DiaChi"] = itemRow["DiaChi"];
                                if (itemRow["LyDo"].ToString() == "Vấn Đề Khác")
                                    dr["LyDo"] = itemRow["GhiChuLyDo"];
                                else
                                    dr["LyDo"] = itemRow["LyDo"] + " " + itemRow["GhiChuLyDo"];

                                dr["NgayCatTamNutBit"] = itemRow["NgayCatTamNutBit"];
                                dsBaoCao.Tables["DSYCCHDB"].Rows.Add(dr);
                            }

                        dateTu.Value = DateTime.Now;
                        dateDen.Value = DateTime.Now;
                        _tuNgay = _denNgay = "";

                        rptDSCatTamNutBit rpt = new rptDSCatTamNutBit();
                        rpt.SetDataSource(dsBaoCao);
                        crystalReportViewer1.ReportSource = rpt;
                    }
            }
            ///
            if (radDSCTDBtheocamket.Checked)
            {
                DataTable dt = new DataTable();

                if (!string.IsNullOrEmpty(_tuNgay) && !string.IsNullOrEmpty(_denNgay))
                {
                    dt = _cCHDB.LoadDSCTCTDBtheocamketByDates(dateTu.Value, dateDen.Value);
                }
                else
                    if (!string.IsNullOrEmpty(_tuNgay))
                    {
                        dt = _cCHDB.LoadDSCTCTDBtheocamketByDate(dateTu.Value);
                    }

                DataSetBaoCao dsBaoCao = new DataSetBaoCao();

                foreach (DataRow itemRow in dt.Rows)
                {
                    DataRow dr = dsBaoCao.Tables["DSYCCHDB"].NewRow();
                    dr["TuNgay"] = _tuNgay;
                    dr["DenNgay"] = _denNgay;
                    if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                        dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                    dr["HoTen"] = itemRow["HoTen"];
                    dr["DiaChi"] = itemRow["DiaChi"];
                dr["LyDo"] = itemRow["GhiChuLyDo"].ToString().Substring(30);
                    dr["NgayLap"] = itemRow["NgayTCTBXuLy"];
                    dr["HieuLucKy"] = itemRow["KetQuaTCTBXuLy"];

                    dsBaoCao.Tables["DSYCCHDB"].Rows.Add(dr);
                }

                dateTu.Value = DateTime.Now;
                dateDen.Value = DateTime.Now;
                _tuNgay = _denNgay = "";

                rptDSCTDBtheocamket rpt = new rptDSCTDBtheocamket();
                rpt.SetDataSource(dsBaoCao);
                crystalReportViewer1.ReportSource = rpt;
            }
        }
    }
}
