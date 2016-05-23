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
using KTKS_DonKH.DAL.HeThong;

namespace KTKS_DonKH.GUI.KiemTraXacMinh
{
    public partial class frmBaoCaoKTXM : Form
    {
        string _tuNgay = "", _denNgay = "";
        CKTXM _cKTXM = new CKTXM();
        int soLapBangGia = 0;
        int soDongTien = 0;
        int soChuyenLapTBCat = 0;
        int soMatDHN_LapBangGia = 0;
        int soDCMS_LapBangGia = 0;
        int soKhac_LapBangGia = 0;

        public frmBaoCaoKTXM()
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

        private void frmBaoCaoKTXM_Load(object sender, EventArgs e)
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

        class ThongKeBienBan
        {
            string _loaiBienBan = "";
            public string LoaiBienBan
            {
                get { return _loaiBienBan; }
                set { _loaiBienBan = value; }
            }

            int _tongDanhBo = 0;
            public int TongDanhBo
            {
                get { return _tongDanhBo; }
                set { _tongDanhBo = value; }
            }

            int _toKH = 0;
            public int ToKH
            {
                get { return _toKH; }
                set { _toKH = value; }
            }

            int _toXuLy = 0;
            public int ToXuLy
            {
                get { return _toXuLy; }
                set { _toXuLy = value; }
            }

            //int _lapBangGia = 0;
            //public int LapBangGia
            //{
            //    get { return _lapBangGia; }
            //    set { _lapBangGia = value; }
            //}

            int _dongTienBoiThuong = 0;
            public int DongTienBoiThuong
            {
                get { return _dongTienBoiThuong; }
                set { _dongTienBoiThuong = value; }
            }

            int _tieuThuTrungBinh = 0;
            public int TieuThuTrungBinh
            {
                get { return _tieuThuTrungBinh; }
                set { _tieuThuTrungBinh = value; }
            }

            int _chuaDongTienBoiThuong = 0;
            public int ChuaDongTienBoiThuong
            {
                get { return _chuaDongTienBoiThuong; }
                set { _chuaDongTienBoiThuong = value; }
            }

            //int _chuyenLapTBCat = 0;
            //public int ChuyenLapTBCat
            //{
            //    get { return _chuyenLapTBCat; }
            //    set { _chuyenLapTBCat = value; }
            //}
        };

        ThongKeBienBan[] a = new ThongKeBienBan[6];

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            if (radThongKeBienBan.Checked)
            {
                soLapBangGia = 0;
                soDongTien = 0;
                soChuyenLapTBCat = 0;
                soMatDHN_LapBangGia = 0;
                soDCMS_LapBangGia = 0;
                soKhac_LapBangGia = 0;

                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();
                if (!string.IsNullOrEmpty(_tuNgay) && !string.IsNullOrEmpty(_denNgay))
                {
                    dt = _cKTXM.LoadDSCTKTXM(CTaiKhoan.MaUser, dateTu.Value, dateDen.Value);
                    dt2 = _cKTXM.LoadDSCTKTXMbyNgayLapBangGia(CTaiKhoan.MaUser, dateTu.Value, dateDen.Value);
                    soDongTien = _cKTXM.countCTKTXMbyNgayDongTien(dateTu.Value, dateDen.Value);
                    soChuyenLapTBCat = _cKTXM.countCTKTXMbyNgayChuyenLapTBCat(dateTu.Value, dateDen.Value);
                }
                else
                    if (!string.IsNullOrEmpty(_tuNgay))
                    {
                        dt = _cKTXM.LoadDSCTKTXM(CTaiKhoan.MaUser, dateTu.Value);
                        dt2 = _cKTXM.LoadDSCTKTXMbyNgayLapBangGia(CTaiKhoan.MaUser, dateTu.Value);
                        soDongTien = _cKTXM.countCTKTXMbyNgayDongTien(dateTu.Value);
                        soChuyenLapTBCat = _cKTXM.countCTKTXMbyNgayChuyenLapTBCat(dateTu.Value);
                    }

                for (int i = 0; i < 6; i++)
                {
                    a[i] = new ThongKeBienBan();
                }

                foreach (DataRow itemRow in dt.Rows)
                {
                    if (itemRow["LoaiBienBan"].ToString().Contains("bồi thường") && !itemRow["LoaiBienBan"].ToString().Contains("không"))
                    {
                        if (itemRow["LoaiBienBan"].ToString().Equals("BB mất ĐHN bồi thường"))
                        {
                            a[0].LoaiBienBan = "BB mất ĐHN bồi thường";
                            a[0].TongDanhBo++;
                            if (!string.IsNullOrEmpty(itemRow["MaDon"].ToString()))
                                a[0].ToKH++;
                            if (!string.IsNullOrEmpty(itemRow["MaDonTXL"].ToString()))
                                a[0].ToXuLy++;
                            if (bool.Parse(itemRow["LapBangGia"].ToString()))
                            {
                                //a[0].LapBangGia++;
                                //soLapBangGia++;
                                //soMatDHN_LapBangGia++;
                            }
                            if (bool.Parse(itemRow["DongTienBoiThuong"].ToString()))
                            {
                                a[0].DongTienBoiThuong++;
                                //soDongTien++;
                            }
                            else
                                a[0].ChuaDongTienBoiThuong++;
                            if (!string.IsNullOrEmpty(itemRow["TieuThuTrungBinh"].ToString()))
                                a[0].TieuThuTrungBinh += int.Parse(itemRow["TieuThuTrungBinh"].ToString());
                            if (bool.Parse(itemRow["ChuyenLapTBCat"].ToString()))
                            {
                                //a[0].ChuyenLapTBCat++;
                                //soChuyenLapTBCat++;
                            }
                        }
                        else
                            if (itemRow["LoaiBienBan"].ToString().Equals("BB đứt chì MS bồi thường"))
                            {
                                a[1].LoaiBienBan = "BB đứt chì MS bồi thường";
                                a[1].TongDanhBo++;
                                if (!string.IsNullOrEmpty(itemRow["MaDon"].ToString()))
                                    a[1].ToKH++;
                                if (!string.IsNullOrEmpty(itemRow["MaDonTXL"].ToString()))
                                    a[1].ToXuLy++;
                                if (bool.Parse(itemRow["LapBangGia"].ToString()))
                                {
                                    //a[1].LapBangGia++;
                                    //soLapBangGia++;
                                    //soDCMS_LapBangGia++;
                                }
                                if (bool.Parse(itemRow["DongTienBoiThuong"].ToString()))
                                {
                                    a[1].DongTienBoiThuong++;
                                    //soDongTien++;
                                }
                                else
                                    a[1].ChuaDongTienBoiThuong++;
                                if (!string.IsNullOrEmpty(itemRow["TieuThuTrungBinh"].ToString()))
                                    a[1].TieuThuTrungBinh += int.Parse(itemRow["TieuThuTrungBinh"].ToString());
                                if (bool.Parse(itemRow["ChuyenLapTBCat"].ToString()))
                                {
                                    //a[1].ChuyenLapTBCat++;
                                    //soChuyenLapTBCat++;
                                }
                            }
                    }
                    else
                        if (itemRow["LoaiBienBan"].ToString().Contains("gian lận"))
                        {
                            a[2].LoaiBienBan = "BB gian lận";
                            a[2].TongDanhBo++;
                            if (!string.IsNullOrEmpty(itemRow["TieuThuTrungBinh"].ToString()))
                                a[2].TieuThuTrungBinh += int.Parse(itemRow["TieuThuTrungBinh"].ToString());
                        }
                        else
                            if (itemRow["LoaiBienBan"].ToString() == "BB chạy ngược")
                            {
                                a[3].LoaiBienBan = "BB chạy ngược";
                                a[3].TongDanhBo++;
                                if (!string.IsNullOrEmpty(itemRow["TieuThuTrungBinh"].ToString()))
                                    a[3].TieuThuTrungBinh += int.Parse(itemRow["TieuThuTrungBinh"].ToString());
                            }
                            else
                                if (itemRow["LoaiBienBan"].ToString() == "BB tái lập Danh Bộ")
                                {
                                    a[4].LoaiBienBan = "BB tái lập Danh Bộ";
                                    a[4].TongDanhBo++;
                                }
                                else
                                    if (itemRow["LoaiBienBan"].ToString() == "BB hủy Danh Bộ")
                                    {
                                        a[5].LoaiBienBan = "BB hủy Danh Bộ";
                                        a[5].TongDanhBo++;
                                    }
                                    //else
                                    //{
                                    //    if (bool.Parse(itemRow["LapBangGia"].ToString()))
                                    //    {
                                    //        soLapBangGia++;
                                    //        soKhac_LapBangGia++;
                                    //    }
                                    //    if (bool.Parse(itemRow["DongTienBoiThuong"].ToString()))
                                    //    {
                                    //        soDongTien++;
                                    //    }
                                    //}
                }

                foreach (DataRow itemRow in dt2.Rows)
                {
                    if (itemRow["LoaiBienBan"].ToString().Equals("BB mất ĐHN bồi thường"))
                    {
                        if (bool.Parse(itemRow["LapBangGia"].ToString()))
                        {
                            soLapBangGia++;
                            soMatDHN_LapBangGia++;
                        }
                    }
                    else
                        if (itemRow["LoaiBienBan"].ToString().Equals("BB đứt chì MS bồi thường"))
                        {
                            if (bool.Parse(itemRow["LapBangGia"].ToString()))
                            {
                                soLapBangGia++;
                                soDCMS_LapBangGia++;
                            }
                        }
                        else
                        {
                            if (bool.Parse(itemRow["LapBangGia"].ToString()))
                            {
                                soLapBangGia++;
                                soKhac_LapBangGia++;
                            }
                        }
                }

                DataSetBaoCao dsBaoCao = new DataSetBaoCao();

                for (int i = 0; i < 6; i++)
                    ///nếu không có if thì sẽ in ra hết 5 loaibienban (có những cái sẽ không có)
                    if (!string.IsNullOrEmpty(a[i].LoaiBienBan))
                    {
                        DataRow dr = dsBaoCao.Tables["ThongKeBienBanKTXM"].NewRow();

                        dr["TuNgay"] = _tuNgay;
                        dr["DenNgay"] = _denNgay;
                        dr["LoaiBienBan"] = a[i].LoaiBienBan;
                        dr["TongDanhBo"] = a[i].TongDanhBo;
                        ///if chỗ này để không cho xuất hiện bên report nếu = 0
                        if (a[i].ToKH == 0)
                            dr["ToKH"] = "";
                        else
                            dr["ToKH"] = a[i].ToKH;

                        if (a[i].ToXuLy == 0)
                            dr["ToXuLy"] = "";
                        else
                            dr["ToXuLy"] = a[i].ToXuLy;

                        //if (soLapBangGia == 0)
                        //    dr["LapBangGia"] = "";
                        //else
                        dr["LapBangGia"] = soLapBangGia;

                        if (a[i].DongTienBoiThuong == 0)
                            dr["DongTienBoiThuong"] = "";
                        else
                            dr["DongTienBoiThuong"] = a[i].DongTienBoiThuong;

                        if (a[i].TieuThuTrungBinh == 0)
                            dr["TieuThuTrungBinh"] = "";
                        else
                            dr["TieuThuTrungBinh"] = "Tiêu Thụ Trung Bình "+a[i].TieuThuTrungBinh+"m3";

                        if (a[i].ChuaDongTienBoiThuong == 0)
                            dr["ChuaDongTienBoiThuong"] = "";
                        else
                            dr["ChuaDongTienBoiThuong"] = a[i].ChuaDongTienBoiThuong;

                        //if (soChuyenLapTBCat == 0)
                        //    dr["ChuyenLapTBCat"] = "";
                        //else
                        dr["ChuyenLapTBCat"] = soChuyenLapTBCat;

                        //if (soDongTien == 0)
                        //    dr["DongTien"] = "";
                        //else
                        dr["DongTien"] = soDongTien;

                        dr["soMatDHN_LapBangGia"] = soMatDHN_LapBangGia;
                        dr["soDCMS_LapBangGia"] = soDCMS_LapBangGia;
                        dr["soKhac_LapBangGia"] = soKhac_LapBangGia;

                        dsBaoCao.Tables["ThongKeBienBanKTXM"].Rows.Add(dr);
                    }

                //dateTu.Value = DateTime.Now;
                //dateDen.Value = DateTime.Now;
                //_tuNgay = _denNgay = "";

                rptThongKeKTXM rpt = new rptThongKeKTXM();
                rpt.SetDataSource(dsBaoCao);
                crystalReportViewer1.ReportSource = rpt;
            }
        }
    }
}
