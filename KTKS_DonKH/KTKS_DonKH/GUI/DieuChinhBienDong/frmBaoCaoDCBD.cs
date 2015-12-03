using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.DieuChinhBienDong;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.KhachHang;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmBaoCaoDCBD : Form
    {
        string _tuNgay = "", _denNgay = "";
        CChungTu _cChungTu = new CChungTu();
        CCatChuyenDM _cCatChuyenDM = new CCatChuyenDM();
        CDCBD _cDCBD = new CDCBD();
        CPhuongQuan _cPhuongQuan = new CPhuongQuan();
        List<QUAN> _lst;

        public frmBaoCaoDCBD()
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

        private void frmBCCapDinhMuc_Load(object sender, EventArgs e)
        {
            _lst = _cPhuongQuan.LoadDSQuan();
            QUAN quan = new QUAN();
            quan.MAQUAN = 0;
            quan.TENQUAN = "Tất Cả";
            _lst.Insert(0, quan);
            cmbQuan.DataSource = _lst;
            cmbQuan.DisplayMember = "TenQuan";
            cmbQuan.ValueMember = "MaQuan";
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
            if (radDanhSachDMCapCoThoiHan.Checked)
            {
                DataTable dt = new DataTable();
                if (!string.IsNullOrEmpty(_tuNgay) && !string.IsNullOrEmpty(_denNgay))
                    dt = _cChungTu.LoadDSCapDinhMuc(dateTu.Value, dateDen.Value);
                else
                    if (!string.IsNullOrEmpty(_tuNgay))
                        dt = _cChungTu.LoadDSCapDinhMuc(dateTu.Value);

                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                foreach (DataRow itemRow in dt.Rows)
                {
                    if (cmbQuan.SelectedValue.ToString() == "0")
                    {
                        DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                        dr["TuNgay"] = _tuNgay;
                        dr["DenNgay"] = _denNgay;
                        if (_cDCBD.checkCTDCBDbyDanhBoCreateDate(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())))
                        {
                            string a = _cDCBD.getCTDCBDbyDanhBoCreateDate(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())).ToString();
                            dr["SoPhieu"] = a.Insert(a.Length - 2, "-");
                        }
                        else
                            dr["SoPhieu"] = "";


                        if (_cChungTu.CheckMaDonbyDanhBoChungTu(itemRow["DanhBo"].ToString(), itemRow["MaCT"].ToString()))
                        {
                            decimal MaDon = _cChungTu.getMaDonbyDanhBoChungTu(itemRow["DanhBo"].ToString(), itemRow["MaCT"].ToString());
                            dr["MaDon"] = MaDon.ToString().Insert(MaDon.ToString().Length - 2, "-");
                        }
                        else
                            dr["MaDon"] = "";

                        if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                            dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                        dr["HoTen"] = itemRow["HoTen"];
                        dr["DiaChi"] = itemRow["DiaChi"];
                        dr["MaLCT"] = itemRow["MaLCT"];
                        dr["TenLCT"] = itemRow["TenLCT"];
                        dr["MaCT"] = itemRow["MaCT"];
                        dr["DinhMucCap"] = (int.Parse(itemRow["SoNKDangKy"].ToString()) * 4).ToString();
                        dr["NgayHetHan"] = itemRow["NgayHetHan"];
                        dr["DienThoai"] = itemRow["DienThoai"];
                        dr["GhiChu"] = itemRow["GhiChu"];
                        dr["Phuong"] = _cPhuongQuan.getTenPhuongByMaQuanPhuong(int.Parse(itemRow["Quan"].ToString()), itemRow["Phuong"].ToString());
                        dr["Quan"] = _cPhuongQuan.getTenQuanByMaQuan(int.Parse(itemRow["Quan"].ToString()));
                        dsBaoCao.Tables["DSCapDinhMuc"].Rows.Add(dr);
                    }
                    else
                        if (cmbPhuong.SelectedValue.ToString() == "0")
                        {
                            if (cmbQuan.SelectedValue.ToString() == itemRow["Quan"].ToString())
                            {
                                DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                                dr["TuNgay"] = _tuNgay;
                                dr["DenNgay"] = _denNgay;
                                if (_cDCBD.checkCTDCBDbyDanhBoCreateDate(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())))
                                {
                                    string a = _cDCBD.getCTDCBDbyDanhBoCreateDate(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())).ToString();
                                    dr["SoPhieu"] = a.Insert(a.Length - 2, "-");
                                }
                                else
                                    dr["SoPhieu"] = "";


                                if (_cChungTu.CheckMaDonbyDanhBoChungTu(itemRow["DanhBo"].ToString(), itemRow["MaCT"].ToString()))
                                {
                                    decimal MaDon = _cChungTu.getMaDonbyDanhBoChungTu(itemRow["DanhBo"].ToString(), itemRow["MaCT"].ToString());
                                    dr["MaDon"] = MaDon.ToString().Insert(MaDon.ToString().Length - 2, "-");
                                }
                                else
                                    dr["MaDon"] = "";

                                if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                                    dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                                dr["HoTen"] = itemRow["HoTen"];
                                dr["DiaChi"] = itemRow["DiaChi"];
                                dr["MaLCT"] = itemRow["MaLCT"];
                                dr["TenLCT"] = itemRow["TenLCT"];
                                dr["MaCT"] = itemRow["MaCT"];
                                dr["DinhMucCap"] = (int.Parse(itemRow["SoNKDangKy"].ToString()) * 4).ToString();
                                dr["NgayHetHan"] = itemRow["NgayHetHan"];
                                dr["DienThoai"] = itemRow["DienThoai"];
                                dr["GhiChu"] = itemRow["GhiChu"];
                                dr["Phuong"] = _cPhuongQuan.getTenPhuongByMaQuanPhuong(int.Parse(itemRow["Quan"].ToString()), itemRow["Phuong"].ToString());
                                dr["Quan"] = _cPhuongQuan.getTenQuanByMaQuan(int.Parse(itemRow["Quan"].ToString()));
                                dsBaoCao.Tables["DSCapDinhMuc"].Rows.Add(dr);
                            }
                        }
                        else
                        {
                            if (cmbPhuong.SelectedValue.ToString() == itemRow["Phuong"].ToString() && cmbQuan.SelectedValue.ToString() == itemRow["Quan"].ToString())
                            {
                                DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                                dr["TuNgay"] = _tuNgay;
                                dr["DenNgay"] = _denNgay;
                                if (_cDCBD.checkCTDCBDbyDanhBoCreateDate(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())))
                                {
                                    string a = _cDCBD.getCTDCBDbyDanhBoCreateDate(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())).ToString();
                                    dr["SoPhieu"] = a.Insert(a.Length - 2, "-");
                                }
                                else
                                    dr["SoPhieu"] = "";


                                if (_cChungTu.CheckMaDonbyDanhBoChungTu(itemRow["DanhBo"].ToString(), itemRow["MaCT"].ToString()))
                                {
                                    decimal MaDon = _cChungTu.getMaDonbyDanhBoChungTu(itemRow["DanhBo"].ToString(), itemRow["MaCT"].ToString());
                                    dr["MaDon"] = MaDon.ToString().Insert(MaDon.ToString().Length - 2, "-");
                                }
                                else
                                    dr["MaDon"] = "";

                                if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                                    dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                                dr["HoTen"] = itemRow["HoTen"];
                                dr["DiaChi"] = itemRow["DiaChi"];
                                dr["MaLCT"] = itemRow["MaLCT"];
                                dr["TenLCT"] = itemRow["TenLCT"];
                                dr["MaCT"] = itemRow["MaCT"];
                                dr["DinhMucCap"] = (int.Parse(itemRow["SoNKDangKy"].ToString()) * 4).ToString();
                                dr["NgayHetHan"] = itemRow["NgayHetHan"];
                                dr["DienThoai"] = itemRow["DienThoai"];
                                dr["GhiChu"] = itemRow["GhiChu"];
                                dr["Phuong"] = _cPhuongQuan.getTenPhuongByMaQuanPhuong(int.Parse(itemRow["Quan"].ToString()), itemRow["Phuong"].ToString());
                                dr["Quan"] = _cPhuongQuan.getTenQuanByMaQuan(int.Parse(itemRow["Quan"].ToString()));
                                dsBaoCao.Tables["DSCapDinhMuc"].Rows.Add(dr);
                            }
                        }
                }

                //dateTu.Value = DateTime.Now;
                //dateDen.Value = DateTime.Now;
                //_tuNgay = _denNgay = "";

                rptDSCapDinhMuc rpt = new rptDSCapDinhMuc();
                rpt.SetDataSource(dsBaoCao);
                rpt.Subreports[0].SetDataSource(dsBaoCao);
                crystalReportViewer1.ReportSource = rpt;  
            }

            if (radDanhSachDMCapKThoiHan.Checked)
            {
                DataTable dt = new DataTable();
                if (!string.IsNullOrEmpty(_tuNgay) && !string.IsNullOrEmpty(_denNgay))
                    dt = _cChungTu.LoadDSCapDinhMucKhongThoiHan(dateTu.Value, dateDen.Value);
                else
                    if (!string.IsNullOrEmpty(_tuNgay))
                        dt = _cChungTu.LoadDSCapDinhMucKhongThoiHan(dateTu.Value);

                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                foreach (DataRow itemRow in dt.Rows)
                {
                    if (cmbQuan.SelectedValue.ToString() == "0")
                    {
                        DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                        dr["TuNgay"] = _tuNgay;
                        dr["DenNgay"] = _denNgay;
                        if (_cDCBD.checkCTDCBDbyDanhBoCreateDate(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())))
                        {
                            string a = _cDCBD.getCTDCBDbyDanhBoCreateDate(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())).ToString();
                            dr["SoPhieu"] = a.Insert(a.Length - 2, "-");
                        }
                        else
                            dr["SoPhieu"] = "";


                        if (_cChungTu.CheckMaDonbyDanhBoChungTu(itemRow["DanhBo"].ToString(), itemRow["MaCT"].ToString()))
                        {
                            decimal MaDon = _cChungTu.getMaDonbyDanhBoChungTu(itemRow["DanhBo"].ToString(), itemRow["MaCT"].ToString());
                            dr["MaDon"] = MaDon.ToString().Insert(MaDon.ToString().Length - 2, "-");
                        }
                        else
                            dr["MaDon"] = "";

                        if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                            dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                        dr["HoTen"] = itemRow["HoTen"];
                        dr["DiaChi"] = itemRow["DiaChi"];
                        dr["MaLCT"] = itemRow["MaLCT"];
                        dr["TenLCT"] = itemRow["TenLCT"];
                        dr["MaCT"] = itemRow["MaCT"];
                        dr["DinhMucCap"] = (int.Parse(itemRow["SoNKDangKy"].ToString()) * 4).ToString();
                        dr["NgayHetHan"] = itemRow["NgayHetHan"];
                        dr["DienThoai"] = itemRow["DienThoai"];
                        dr["GhiChu"] = itemRow["GhiChu"];
                        dsBaoCao.Tables["DSCapDinhMuc"].Rows.Add(dr);
                    }
                    else
                        if (cmbPhuong.SelectedValue.ToString() == "0")
                        {
                            if (cmbQuan.SelectedValue.ToString() == itemRow["Quan"].ToString())
                            {
                                DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                                dr["TuNgay"] = _tuNgay;
                                dr["DenNgay"] = _denNgay;
                                if (_cDCBD.checkCTDCBDbyDanhBoCreateDate(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())))
                                {
                                    string a = _cDCBD.getCTDCBDbyDanhBoCreateDate(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())).ToString();
                                    dr["SoPhieu"] = a.Insert(a.Length - 2, "-");
                                }
                                else
                                    dr["SoPhieu"] = "";


                                if (_cChungTu.CheckMaDonbyDanhBoChungTu(itemRow["DanhBo"].ToString(), itemRow["MaCT"].ToString()))
                                {
                                    decimal MaDon = _cChungTu.getMaDonbyDanhBoChungTu(itemRow["DanhBo"].ToString(), itemRow["MaCT"].ToString());
                                    dr["MaDon"] = MaDon.ToString().Insert(MaDon.ToString().Length - 2, "-");
                                }
                                else
                                    dr["MaDon"] = "";

                                if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                                    dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                                dr["HoTen"] = itemRow["HoTen"];
                                dr["DiaChi"] = itemRow["DiaChi"];
                                dr["MaLCT"] = itemRow["MaLCT"];
                                dr["TenLCT"] = itemRow["TenLCT"];
                                dr["MaCT"] = itemRow["MaCT"];
                                dr["DinhMucCap"] = (int.Parse(itemRow["SoNKDangKy"].ToString()) * 4).ToString();
                                dr["NgayHetHan"] = itemRow["NgayHetHan"];
                                dr["DienThoai"] = itemRow["DienThoai"];
                                dr["GhiChu"] = itemRow["GhiChu"];
                                dsBaoCao.Tables["DSCapDinhMuc"].Rows.Add(dr);
                            }
                        }
                        else
                        {
                            if (cmbPhuong.SelectedValue.ToString() == itemRow["Phuong"].ToString() && cmbQuan.SelectedValue.ToString() == itemRow["Quan"].ToString())
                            {
                                DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                                dr["TuNgay"] = _tuNgay;
                                dr["DenNgay"] = _denNgay;
                                if (_cDCBD.checkCTDCBDbyDanhBoCreateDate(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())))
                                {
                                    string a = _cDCBD.getCTDCBDbyDanhBoCreateDate(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())).ToString();
                                    dr["SoPhieu"] = a.Insert(a.Length - 2, "-");
                                }
                                else
                                    dr["SoPhieu"] = "";


                                if (_cChungTu.CheckMaDonbyDanhBoChungTu(itemRow["DanhBo"].ToString(), itemRow["MaCT"].ToString()))
                                {
                                    decimal MaDon = _cChungTu.getMaDonbyDanhBoChungTu(itemRow["DanhBo"].ToString(), itemRow["MaCT"].ToString());
                                    dr["MaDon"] = MaDon.ToString().Insert(MaDon.ToString().Length - 2, "-");
                                }
                                else
                                    dr["MaDon"] = "";

                                if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                                    dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                                dr["HoTen"] = itemRow["HoTen"];
                                dr["DiaChi"] = itemRow["DiaChi"];
                                dr["MaLCT"] = itemRow["MaLCT"];
                                dr["TenLCT"] = itemRow["TenLCT"];
                                dr["MaCT"] = itemRow["MaCT"];
                                dr["DinhMucCap"] = (int.Parse(itemRow["SoNKDangKy"].ToString()) * 4).ToString();
                                dr["NgayHetHan"] = itemRow["NgayHetHan"];
                                dr["DienThoai"] = itemRow["DienThoai"];
                                dr["GhiChu"] = itemRow["GhiChu"];
                                dsBaoCao.Tables["DSCapDinhMuc"].Rows.Add(dr);
                            }
                        }
                }

                //dateTu.Value = DateTime.Now;
                //dateDen.Value = DateTime.Now;
                //_tuNgay = _denNgay = "";

                rptDSCapDinhMuc rpt = new rptDSCapDinhMuc();
                rpt.SetDataSource(dsBaoCao);
                rpt.Subreports[0].SetDataSource(dsBaoCao);
                crystalReportViewer1.ReportSource = rpt;
            }

            if (radDanhSachDMCapNgayHetHan.Checked)
            {
                DataTable dt = new DataTable();
                if (!string.IsNullOrEmpty(_tuNgay) && !string.IsNullOrEmpty(_denNgay))
                    dt = _cChungTu.LoadDSCapDinhMucNgayHetHan(dateTu.Value, dateDen.Value);
                else
                    if (!string.IsNullOrEmpty(_tuNgay))
                        dt = _cChungTu.LoadDSCapDinhMucNgayHetHan(dateTu.Value);

                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                foreach (DataRow itemRow in dt.Rows)
                {
                    if (cmbQuan.SelectedValue.ToString() == "0")
                    {
                        DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                        dr["TuNgay"] = _tuNgay;
                        dr["DenNgay"] = _denNgay;
                        if (_cDCBD.checkCTDCBDbyDanhBoCreateDate(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())))
                        {
                            string a = _cDCBD.getCTDCBDbyDanhBoCreateDate(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())).ToString();
                            dr["SoPhieu"] = a.Insert(a.Length - 2, "-");
                        }
                        else
                            dr["SoPhieu"] = "";


                        if (_cChungTu.CheckMaDonbyDanhBoChungTu(itemRow["DanhBo"].ToString(), itemRow["MaCT"].ToString()))
                        {
                            decimal MaDon = _cChungTu.getMaDonbyDanhBoChungTu(itemRow["DanhBo"].ToString(), itemRow["MaCT"].ToString());
                            dr["MaDon"] = MaDon.ToString().Insert(MaDon.ToString().Length - 2, "-");
                        }
                        else
                            dr["MaDon"] = "";

                        if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                            dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                        dr["HoTen"] = itemRow["HoTen"];
                        dr["DiaChi"] = itemRow["DiaChi"];
                        dr["MaLCT"] = itemRow["MaLCT"];
                        dr["TenLCT"] = itemRow["TenLCT"];
                        dr["MaCT"] = itemRow["MaCT"];
                        dr["DinhMucCap"] = (int.Parse(itemRow["SoNKDangKy"].ToString()) * 4).ToString();
                        dr["NgayHetHan"] = itemRow["NgayHetHan"];
                        dr["DienThoai"] = itemRow["DienThoai"];
                        dr["GhiChu"] = itemRow["GhiChu"];
                        dr["Phuong"] = _cPhuongQuan.getTenPhuongByMaQuanPhuong(int.Parse(itemRow["Quan"].ToString()), itemRow["Phuong"].ToString());
                        dr["Quan"] = _cPhuongQuan.getTenQuanByMaQuan(int.Parse(itemRow["Quan"].ToString()));
                        dsBaoCao.Tables["DSCapDinhMuc"].Rows.Add(dr);
                    }
                    else
                        if (cmbPhuong.SelectedValue.ToString() == "0")
                        {
                            if (cmbQuan.SelectedValue.ToString() == itemRow["Quan"].ToString())
                            {
                                DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                                dr["TuNgay"] = _tuNgay;
                                dr["DenNgay"] = _denNgay;
                                if (_cDCBD.checkCTDCBDbyDanhBoCreateDate(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())))
                                {
                                    string a = _cDCBD.getCTDCBDbyDanhBoCreateDate(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())).ToString();
                                    dr["SoPhieu"] = a.Insert(a.Length - 2, "-");
                                }
                                else
                                    dr["SoPhieu"] = "";


                                if (_cChungTu.CheckMaDonbyDanhBoChungTu(itemRow["DanhBo"].ToString(), itemRow["MaCT"].ToString()))
                                {
                                    decimal MaDon = _cChungTu.getMaDonbyDanhBoChungTu(itemRow["DanhBo"].ToString(), itemRow["MaCT"].ToString());
                                    dr["MaDon"] = MaDon.ToString().Insert(MaDon.ToString().Length - 2, "-");
                                }
                                else
                                    dr["MaDon"] = "";

                                if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                                    dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                                dr["HoTen"] = itemRow["HoTen"];
                                dr["DiaChi"] = itemRow["DiaChi"];
                                dr["MaLCT"] = itemRow["MaLCT"];
                                dr["TenLCT"] = itemRow["TenLCT"];
                                dr["MaCT"] = itemRow["MaCT"];
                                dr["DinhMucCap"] = (int.Parse(itemRow["SoNKDangKy"].ToString()) * 4).ToString();
                                dr["NgayHetHan"] = itemRow["NgayHetHan"];
                                dr["DienThoai"] = itemRow["DienThoai"];
                                dr["GhiChu"] = itemRow["GhiChu"];
                                dr["Phuong"] = _cPhuongQuan.getTenPhuongByMaQuanPhuong(int.Parse(itemRow["Quan"].ToString()), itemRow["Phuong"].ToString());
                                dr["Quan"] = _cPhuongQuan.getTenQuanByMaQuan(int.Parse(itemRow["Quan"].ToString()));
                                dsBaoCao.Tables["DSCapDinhMuc"].Rows.Add(dr);
                            }
                        }
                        else
                        {
                            if (cmbPhuong.SelectedValue.ToString() == itemRow["Phuong"].ToString() && cmbQuan.SelectedValue.ToString() == itemRow["Quan"].ToString())
                            {
                                DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                                dr["TuNgay"] = _tuNgay;
                                dr["DenNgay"] = _denNgay;
                                if (_cDCBD.checkCTDCBDbyDanhBoCreateDate(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())))
                                {
                                    string a = _cDCBD.getCTDCBDbyDanhBoCreateDate(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())).ToString();
                                    dr["SoPhieu"] = a.Insert(a.Length - 2, "-");
                                }
                                else
                                    dr["SoPhieu"] = "";


                                if (_cChungTu.CheckMaDonbyDanhBoChungTu(itemRow["DanhBo"].ToString(), itemRow["MaCT"].ToString()))
                                {
                                    decimal MaDon = _cChungTu.getMaDonbyDanhBoChungTu(itemRow["DanhBo"].ToString(), itemRow["MaCT"].ToString());
                                    dr["MaDon"] = MaDon.ToString().Insert(MaDon.ToString().Length - 2, "-");
                                }
                                else
                                    dr["MaDon"] = "";

                                if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                                    dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                                dr["HoTen"] = itemRow["HoTen"];
                                dr["DiaChi"] = itemRow["DiaChi"];
                                dr["MaLCT"] = itemRow["MaLCT"];
                                dr["TenLCT"] = itemRow["TenLCT"];
                                dr["MaCT"] = itemRow["MaCT"];
                                dr["DinhMucCap"] = (int.Parse(itemRow["SoNKDangKy"].ToString()) * 4).ToString();
                                dr["NgayHetHan"] = itemRow["NgayHetHan"];
                                dr["DienThoai"] = itemRow["DienThoai"];
                                dr["GhiChu"] = itemRow["GhiChu"];
                                dr["Phuong"] = _cPhuongQuan.getTenPhuongByMaQuanPhuong(int.Parse(itemRow["Quan"].ToString()), itemRow["Phuong"].ToString());
                                dr["Quan"] = _cPhuongQuan.getTenQuanByMaQuan(int.Parse(itemRow["Quan"].ToString()));
                                dsBaoCao.Tables["DSCapDinhMuc"].Rows.Add(dr);
                            }
                        }
                }

                //dateTu.Value = DateTime.Now;
                //dateDen.Value = DateTime.Now;
                //_tuNgay = _denNgay = "";

                rptDSCapDinhMuc rpt = new rptDSCapDinhMuc();
                rpt.SetDataSource(dsBaoCao);
                rpt.Subreports[0].SetDataSource(dsBaoCao);
                crystalReportViewer1.ReportSource = rpt;
            }

            if (radThongKeDC.Checked)
            {
                DataTable dtDCBD = new DataTable();
                DataTable dtDCHD = new DataTable();
                DataTable dtCatChuyenDM = new DataTable();

                if (!string.IsNullOrEmpty(_tuNgay) && !string.IsNullOrEmpty(_denNgay))
                {
                    dtDCBD = _cDCBD.LoadDSCTDCBD(dateTu.Value, dateDen.Value);
                    dtDCHD = _cDCBD.LoadDSCTDCHD(dateTu.Value, dateDen.Value);
                    dtCatChuyenDM = _cChungTu.LoadDSCatChuyenDM(dateTu.Value, dateDen.Value);
                }
                else
                    if (!string.IsNullOrEmpty(_tuNgay))
                    {
                        dtDCBD = _cDCBD.LoadDSCTDCBD(dateTu.Value);
                        dtDCHD = _cDCBD.LoadDSCTDCHD(dateTu.Value);
                        dtCatChuyenDM = _cChungTu.LoadDSCatChuyenDM(dateTu.Value);
                    }

                int DanhBoTangDM = 0;
                int DanhBoGiamDM = 0;
                int DinhMucTang = 0;
                int DinhMucGiam = 0;

                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                foreach (DataRow itemRow in dtDCBD.Rows)
                {
                    DataRow dr = dsBaoCao.Tables["ThongKeDCBD"].NewRow();

                    dr["TuNgay"] = _tuNgay;
                    dr["DenNgay"] = _denNgay;
                    dr["DanhBo"] = itemRow["DanhBo"];
                    dr["HoTen"] = itemRow["HoTen_BD"];
                    dr["GiaBieuCu"] = itemRow["GiaBieu"];
                    dr["GiaBieuMoi"] = itemRow["GiaBieu_BD"];
                    dr["DinhMucCu"] = itemRow["DinhMuc"];
                    dr["DinhMucMoi"] = itemRow["DinhMuc_BD"];
                    dr["DiaChi"] = itemRow["DiaChi_BD"];
                    dr["MSThue"] = itemRow["MSThue_BD"];
                    dr["SH"] = itemRow["SH_BD"];
                    dr["SX"] = itemRow["SX_BD"];
                    dr["DV"] = itemRow["DV_BD"];
                    dr["HCSN"] = itemRow["HCSN_BD"];

                    if (!string.IsNullOrEmpty(itemRow["DinhMuc_BD"].ToString()))
                    {
                        int a = 0;
                        if (string.IsNullOrEmpty(itemRow["DinhMuc"].ToString()))
                            a = 0;
                        else
                            a = int.Parse(itemRow["DinhMuc"].ToString());

                        if (int.Parse(itemRow["DinhMuc_BD"].ToString()) > a)
                        {
                            DanhBoTangDM++;
                            DinhMucTang += int.Parse(itemRow["DinhMuc_BD"].ToString()) - a;
                        }
                        else
                        {
                            DanhBoGiamDM++;
                            DinhMucGiam += a - int.Parse(itemRow["DinhMuc_BD"].ToString());
                        }
                    }

                    dsBaoCao.Tables["ThongKeDCBD"].Rows.Add(dr);
                }

                foreach (DataRow itemRow in dtDCHD.Rows)
                {
                    DataRow dr = dsBaoCao.Tables["ThongKeDCHD"].NewRow();
                    dr["DanhBo"] = itemRow["DanhBo"];
                    dr["TangGiam"] = itemRow["TangGiam"];
                    dr["SoTien"] = itemRow["TongCong_BD"];

                    dsBaoCao.Tables["ThongKeDCHD"].Rows.Add(dr);
                }

                foreach (DataRow itemRow in dtCatChuyenDM.Rows)
                {
                    DataRow dr = dsBaoCao.Tables["ThongKeCatChuyenDM"].NewRow();
                    dr["SoPhieu"] = itemRow["SoPhieu"];
                    if (itemRow["CatDM"].ToString() != "")
                    {
                        if (bool.Parse(itemRow["CatDM"].ToString()))
                            dr["LoaiCatChuyen"] = "Cắt Chuyển đến Công ty khác";
                    }
                    else
                        if (itemRow["YeuCauCat"].ToString() != "")
                        {
                            if (bool.Parse(itemRow["YeuCauCat"].ToString()))
                                dr["LoaiCatChuyen"] = "Yêu Cầu Công ty khác Cắt";
                        }
                        else
                            if (itemRow["NhanDM"].ToString() != "")
                                if (bool.Parse(itemRow["NhanDM"].ToString()))
                                    dr["LoaiCatChuyen"] = "Nhận từ Công ty khác";

                    dsBaoCao.Tables["ThongKeCatChuyenDM"].Rows.Add(dr);
                }

                //dateTu.Value = DateTime.Now;
                //dateDen.Value = DateTime.Now;
                //_tuNgay = _denNgay = "";

                rptThongKeDCBD rpt = new rptThongKeDCBD();
                rpt.SetDataSource(dsBaoCao);
                rpt.Subreports[0].SetDataSource(dsBaoCao);
                rpt.Subreports[1].SetDataSource(dsBaoCao);

                rpt.SetParameterValue(0, DanhBoTangDM);
                rpt.SetParameterValue(1, DinhMucTang);
                rpt.SetParameterValue(2, DanhBoGiamDM);
                rpt.SetParameterValue(3, DinhMucGiam);

                crystalReportViewer1.ReportSource = rpt;
            }

            if (radDSChuyenDocSo.Checked)
            {
                DataTable dt = new DataTable();
                if (!string.IsNullOrEmpty(_tuNgay) && !string.IsNullOrEmpty(_denNgay))
                    dt = _cDCBD.LoadDSCTDCBDbyNgayChuyenDocSo(dateTu.Value, dateDen.Value);
                else
                    if (!string.IsNullOrEmpty(_tuNgay))
                        dt = _cDCBD.LoadDSCTDCBDbyNgayChuyenDocSo(dateTu.Value);
                
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                foreach (DataRow itemRow in dt.Rows)
                {
                    DataRow dr = dsBaoCao.Tables["ChiTietDieuChinh"].NewRow();

                    dr["TuNgay"] = _tuNgay;
                    dr["DenNgay"] = _denNgay;
                    dr["SoPhieu"] = itemRow["SoPhieu"].ToString().Insert(itemRow["SoPhieu"].ToString().Length - 2, "-");
                    dr["ThongTin"] = itemRow["ThongTin"];
                    dr["HieuLucKy"] = itemRow["HieuLucKy"];
                    dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                    dr["HoTen"] = itemRow["HoTen"];
                    dr["DiaChi"] = itemRow["DiaChi"];
                    dr["GiaBieu"] = itemRow["GiaBieu"];
                    dr["DinhMuc"] = itemRow["DinhMuc"];

                    dsBaoCao.Tables["ChiTietDieuChinh"].Rows.Add(dr);
                }

                //dateTu.Value = DateTime.Now;
                //dateDen.Value = DateTime.Now;
                //_tuNgay = _denNgay = "";

                rptDSChuyenDocSo rpt = new rptDSChuyenDocSo();
                rpt.SetDataSource(dsBaoCao);
                crystalReportViewer1.ReportSource = rpt;  
            }

            if (radDSChuyenDocSo_LocUser.Checked)
            {
                DataTable dt = new DataTable();
                if (!string.IsNullOrEmpty(_tuNgay) && !string.IsNullOrEmpty(_denNgay))
                    dt = _cDCBD.LoadDSCTDCBDbyNgayChuyenDocSo(dateTu.Value, dateDen.Value);
                else
                    if (!string.IsNullOrEmpty(_tuNgay))
                        dt = _cDCBD.LoadDSCTDCBDbyNgayChuyenDocSo(dateTu.Value);

                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                foreach (DataRow itemRow in dt.Rows)
                {
                    DataRow dr = dsBaoCao.Tables["ChiTietDieuChinh"].NewRow();

                    dr["TuNgay"] = _tuNgay;
                    dr["DenNgay"] = _denNgay;
                    dr["SoPhieu"] = itemRow["SoPhieu"].ToString().Insert(itemRow["SoPhieu"].ToString().Length - 2, "-");
                    dr["ThongTin"] = itemRow["ThongTin"];
                    dr["HieuLucKy"] = itemRow["HieuLucKy"];
                    dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                    dr["HoTen"] = itemRow["HoTen"];
                    dr["DiaChi"] = itemRow["DiaChi"];
                    dr["GiaBieu"] = itemRow["GiaBieu"];
                    dr["DinhMuc"] = itemRow["DinhMuc"];
                    dr["CreateBy"] = itemRow["CreateBy"];

                    dsBaoCao.Tables["ChiTietDieuChinh"].Rows.Add(dr);
                }

                //dateTu.Value = DateTime.Now;
                //dateDen.Value = DateTime.Now;
                //_tuNgay = _denNgay = "";

                rptDSChuyenDocSo_LocUser rpt = new rptDSChuyenDocSo_LocUser();
                rpt.SetDataSource(dsBaoCao);
                crystalReportViewer1.ReportSource = rpt;
            }

            if (radThongKeDCSoCT.Checked)
            {
                DataTable dt=_cDCBD.LoadDSCTDCBDSoCT(dateTu.Value, dateDen.Value);

                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                foreach (DataRow itemRow in dt.Rows)
                {
                    DataRow dr = dsBaoCao.Tables["ThongKeDCSoCT"].NewRow();

                    dr["TuNgay"] = _tuNgay;
                    dr["DenNgay"] = _denNgay;
                    dr["DanhBo"] = itemRow["DanhBo"];
                    if (itemRow["MaLCT"].ToString() == "2")
                        dr["SoTamTru"] = "true";
                    if (itemRow["MaLCT"].ToString() == "5")
                        dr["KT3"] = "true";
                    if (itemRow["MaLCT"].ToString() == "6")
                        dr["GiayTamTruNKTT"] = "true";
                    if (itemRow["MaLCT"].ToString() == "7")
                        dr["GiayXNTamTru"] = "true";
                    dr["DinhMucCap"] = int.Parse(itemRow["SoNKDangKy"].ToString()) * 4;
                    dr["Phuong"] = _cPhuongQuan.getTenPhuongByMaQuanPhuong(int.Parse(itemRow["Quan"].ToString()), itemRow["Phuong"].ToString());
                    dr["Quan"] = _cPhuongQuan.getTenQuanByMaQuan(int.Parse(itemRow["Quan"].ToString()));

                    dsBaoCao.Tables["ThongKeDCSoCT"].Rows.Add(dr);
                }

                //dateTu.Value = DateTime.Now;
                //dateDen.Value = DateTime.Now;
                //_tuNgay = _denNgay = "";

                rptThongKeDCSoCT rpt = new rptThongKeDCSoCT();
                rpt.SetDataSource(dsBaoCao);
                crystalReportViewer1.ReportSource = rpt;
            }

            if (radDSDMCapHetHan.Checked)
            {
                DataTable dt = new DataTable();
                dt = _cChungTu.LoadDSCapDinhMucHetHan();

                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                dsBaoCao.Tables["DSCapDinhMuc"].PrimaryKey = new DataColumn[] { dsBaoCao.Tables["DSCapDinhMuc"].Columns["DanhBo"] };

                foreach (DataRow itemRow in dt.Rows)
                    if (!string.IsNullOrEmpty(itemRow["NgayHetHan"].ToString()) && !dsBaoCao.Tables["DSCapDinhMuc"].Rows.Contains(itemRow["DanhBo"].ToString().Insert(4, " ").Insert(8, " ")))
                    {
                        DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                        dr["TuNgay"] = "";
                        dr["DenNgay"] = "";
                        CTDCBD ctdcbd = _cDCBD.getLastCTDCBDbyDanhBo(itemRow["DanhBo"].ToString());
                        if (ctdcbd!=null)
                        {
                            dr["SoPhieu"] = ctdcbd.MaCTDCBD.ToString().Insert(ctdcbd.MaCTDCBD.ToString().Length - 2, "-");
                            dr["DinhMucCap"] = ctdcbd.DinhMuc_BD;
                            ///lấy đỡ cột ghi chú xài đỡ
                            dr["GhiChu"] = ctdcbd.DinhMuc;
                        }
                        else
                            dr["SoPhieu"] = "";
                        dr["TenLCT"] = itemRow["TenLCT"];
                        if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                            dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                        dr["HoTen"] = itemRow["HoTen"];
                        dr["DiaChi"] = itemRow["DiaChi"];
                        dsBaoCao.Tables["DSCapDinhMuc"].Rows.Add(dr);
                    }

                rptDSCapDinhMuc_HetHan rpt = new rptDSCapDinhMuc_HetHan();
                rpt.SetDataSource(dsBaoCao);
                crystalReportViewer1.ReportSource = rpt;
            }

            if (radThongKeCapDMCoThoiHanTangGiam.Checked)
            {
                DataTable dt = new DataTable();
                if (!string.IsNullOrEmpty(_tuNgay) && !string.IsNullOrEmpty(_denNgay))
                    dt = _cChungTu.LoadThongKeDMCapCoThoiHan(dateTu.Value, dateDen.Value);
                else
                    if (!string.IsNullOrEmpty(_tuNgay))
                        dt = _cChungTu.LoadThongKeDMCapCoThoiHan(dateTu.Value);

                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                foreach (DataRow itemRow in dt.Rows)
                {
                    if (cmbQuan.SelectedValue.ToString() == "0")
                    {
                        DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                        dr["TuNgay"] = _tuNgay;
                        dr["DenNgay"] = _denNgay;

                        CTDCBD ctdcbd = _cDCBD.getLastCTDCBDbyDanhBo(itemRow["DanhBo"].ToString());
                        if (ctdcbd != null)
                        {
                            if (ctdcbd.DinhMuc_BD != null)
                                dr["DinhMucCap"] = ctdcbd.DinhMuc_BD;
                            if (ctdcbd.DinhMuc != null)
                                dr["DinhMucTruoc"] = ctdcbd.DinhMuc;
                            if (ctdcbd.DinhMuc_BD != null && ctdcbd.DinhMuc != null)
                                if (ctdcbd.DinhMuc_BD.Value - ctdcbd.DinhMuc.Value > 0)
                                    dr["Tang"] = ctdcbd.DinhMuc_BD.Value - ctdcbd.DinhMuc.Value;
                                else
                                    dr["Giam"] = ctdcbd.DinhMuc_BD.Value - ctdcbd.DinhMuc.Value;
                        }

                        if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                            dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                        dr["MaLCT"] = itemRow["MaLCT"];
                        dr["TenLCT"] = itemRow["TenLCT"];
                        dr["Phuong"] = _cPhuongQuan.getTenPhuongByMaQuanPhuong(int.Parse(itemRow["Quan"].ToString()), itemRow["Phuong"].ToString());
                        dr["Quan"] = _cPhuongQuan.getTenQuanByMaQuan(int.Parse(itemRow["Quan"].ToString()));
                        dsBaoCao.Tables["DSCapDinhMuc"].Rows.Add(dr);
                    }
                    else
                        if (cmbPhuong.SelectedValue.ToString() == "0")
                        {
                            if (cmbQuan.SelectedValue.ToString() == itemRow["Quan"].ToString())
                            {
                                DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                                dr["TuNgay"] = _tuNgay;
                                dr["DenNgay"] = _denNgay;

                                CTDCBD ctdcbd = _cDCBD.getLastCTDCBDbyDanhBo(itemRow["DanhBo"].ToString());
                                if (ctdcbd != null)
                                {
                                    if (ctdcbd.DinhMuc_BD != null)
                                        dr["DinhMucCap"] = ctdcbd.DinhMuc_BD;
                                    if (ctdcbd.DinhMuc != null)
                                        dr["DinhMucTruoc"] = ctdcbd.DinhMuc;
                                    if (ctdcbd.DinhMuc != null && ctdcbd.DinhMuc_BD != null)
                                        if (ctdcbd.DinhMuc_BD.Value - ctdcbd.DinhMuc.Value > 0)
                                            dr["Tang"] = ctdcbd.DinhMuc_BD.Value - ctdcbd.DinhMuc.Value;
                                        else
                                            dr["Giam"] = ctdcbd.DinhMuc_BD.Value - ctdcbd.DinhMuc.Value;
                                }

                                if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                                    dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                                dr["MaLCT"] = itemRow["MaLCT"];
                                dr["TenLCT"] = itemRow["TenLCT"];
                                dr["Phuong"] = _cPhuongQuan.getTenPhuongByMaQuanPhuong(int.Parse(itemRow["Quan"].ToString()), itemRow["Phuong"].ToString());
                                dr["Quan"] = _cPhuongQuan.getTenQuanByMaQuan(int.Parse(itemRow["Quan"].ToString()));
                                dsBaoCao.Tables["DSCapDinhMuc"].Rows.Add(dr);
                            }
                        }
                        else
                        {
                            if (cmbPhuong.SelectedValue.ToString() == itemRow["Phuong"].ToString() && cmbQuan.SelectedValue.ToString() == itemRow["Quan"].ToString())
                            {
                                DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                                dr["TuNgay"] = _tuNgay;
                                dr["DenNgay"] = _denNgay;

                                CTDCBD ctdcbd = _cDCBD.getLastCTDCBDbyDanhBo(itemRow["DanhBo"].ToString());
                                if (ctdcbd != null)
                                {
                                    dr["DinhMucCap"] = ctdcbd.DinhMuc_BD;
                                    dr["DinhMucTruoc"] = ctdcbd.DinhMuc;
                                    if (ctdcbd.DinhMuc_BD.Value - ctdcbd.DinhMuc.Value > 0)
                                        dr["Tang"] = ctdcbd.DinhMuc_BD.Value - ctdcbd.DinhMuc.Value;
                                    else
                                        dr["Giam"] = ctdcbd.DinhMuc_BD.Value - ctdcbd.DinhMuc.Value;
                                }

                                if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                                    dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                                dr["MaLCT"] = itemRow["MaLCT"];
                                dr["TenLCT"] = itemRow["TenLCT"];
                                dr["Phuong"] = _cPhuongQuan.getTenPhuongByMaQuanPhuong(int.Parse(itemRow["Quan"].ToString()), itemRow["Phuong"].ToString());
                                dr["Quan"] = _cPhuongQuan.getTenQuanByMaQuan(int.Parse(itemRow["Quan"].ToString()));
                                dsBaoCao.Tables["DSCapDinhMuc"].Rows.Add(dr);
                            }
                        }
                }

                //dateTu.Value = DateTime.Now;
                //dateDen.Value = DateTime.Now;
                //_tuNgay = _denNgay = "";

                rptThongKeCapDinhMucTangGiam rpt = new rptThongKeCapDinhMucTangGiam();
                rpt.SetDataSource(dsBaoCao);
                rpt.Subreports[0].SetDataSource(dsBaoCao);
                crystalReportViewer1.ReportSource = rpt;
            }
        }

        private void cmbQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<PHUONG> lst = ((QUAN)cmbQuan.SelectedItem).PHUONGs.ToList();
            PHUONG phuong = new PHUONG();
            phuong.MAPHUONG = "0";
            phuong.TENPHUONG = "Tất Cả";
            lst.Insert(0, phuong);
            cmbPhuong.DataSource = lst;
            cmbPhuong.DisplayMember = "TenPhuong";
            cmbPhuong.ValueMember = "MaPhuong";
        }

    }
}
