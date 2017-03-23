using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.BaoCao.DieuChinhBienDong;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.BaoCao;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmBaoCaoDCBD : Form
    {
        CChungTu _cChungTu = new CChungTu();
        CCatChuyenDM _cCatChuyenDM = new CCatChuyenDM();
        CDCBD _cDCBD = new CDCBD();
        CDocSo _cDocSo = new CDocSo();
        List<QUAN> _lst;
        CThuTien _cThuTien = new CThuTien();

        public frmBaoCaoDCBD()
        {
            InitializeComponent();
        }

        private void frmBCCapDinhMuc_Load(object sender, EventArgs e)
        {
            _lst = _cDocSo.LoadDSQuan();
            QUAN quan = new QUAN();
            quan.MAQUAN = 0;
            quan.TENQUAN = "Tất Cả";
            _lst.Insert(0, quan);
            cmbQuan.DataSource = _lst;
            cmbQuan.DisplayMember = "TenQuan";
            cmbQuan.ValueMember = "MaQuan";
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            if (radDSDMCapCoThoiHan.Checked)
            {
                DataTable dt = new DataTable();
                    dt = _cChungTu.LoadDSCapDinhMuc(dateTu.Value, dateDen.Value);

                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                foreach (DataRow itemRow in dt.Rows)
                {
                    HOADON hoadon = _cThuTien.GetMoiNhat(itemRow["DanhBo"].ToString());
                    if (cmbQuan.SelectedValue.ToString() == "0")
                    {
                        DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                        dr["TuNgay"] = dateTu.Value.Date.ToString("dd/MM/yyyy");
                        dr["DenNgay"] = dateDen.Value.Date.ToString("dd/MM/yyyy");
                        dr["LoaiBaoCao"] = "CÓ THỜI HẠN";
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
                        {
                            dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                            dr["TieuThu"] = _cThuTien.GetTieuThuMoiNhat(itemRow["DanhBo"].ToString());
                        }
                        dr["HoTen"] = hoadon.TENKH;
                        dr["DiaChi"] = hoadon.SO+" "+hoadon.DUONG;
                        dr["MaLCT"] = itemRow["MaLCT"];
                        dr["TenLCT"] = itemRow["TenLCT"];
                        dr["MaCT"] = itemRow["MaCT"];
                        dr["DinhMucCap"] = (int.Parse(itemRow["SoNKDangKy"].ToString()) * 4).ToString();
                        dr["NgayHetHan"] = itemRow["NgayHetHan"];
                        dr["DienThoai"] = itemRow["DienThoai"];
                        dr["GhiChu"] = itemRow["GhiChu"];
                        dr["Phuong"] = _cDocSo.getTenPhuongByMaQuanPhuong(int.Parse(hoadon.Quan), hoadon.Phuong);
                        dr["Quan"] = _cDocSo.getTenQuanByMaQuan(int.Parse(hoadon.Quan));

                        dsBaoCao.Tables["DSCapDinhMuc"].Rows.Add(dr);
                    }
                    else
                        if (cmbPhuong.SelectedValue.ToString() == "0")
                        {
                            if (cmbQuan.SelectedValue.ToString() == itemRow["Quan"].ToString())
                            {
                                DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                                dr["TuNgay"] = dateTu.Value.Date.ToString("dd/MM/yyyy");
                                dr["DenNgay"] = dateDen.Value.Date.ToString("dd/MM/yyyy");
                                dr["LoaiBaoCao"] = "CÓ THỜI HẠN";
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
                                {
                                    dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                                    dr["TieuThu"] = _cThuTien.GetTieuThuMoiNhat(itemRow["DanhBo"].ToString());
                                }
                                dr["HoTen"] = hoadon.TENKH;
                                dr["DiaChi"] = hoadon.SO + " " + hoadon.DUONG;
                                dr["MaLCT"] = itemRow["MaLCT"];
                                dr["TenLCT"] = itemRow["TenLCT"];
                                dr["MaCT"] = itemRow["MaCT"];
                                dr["DinhMucCap"] = (int.Parse(itemRow["SoNKDangKy"].ToString()) * 4).ToString();
                                dr["NgayHetHan"] = itemRow["NgayHetHan"];
                                dr["DienThoai"] = itemRow["DienThoai"];
                                dr["GhiChu"] = itemRow["GhiChu"];
                                dr["Phuong"] = _cDocSo.getTenPhuongByMaQuanPhuong(int.Parse(hoadon.Quan), hoadon.Phuong);
                                dr["Quan"] = _cDocSo.getTenQuanByMaQuan(int.Parse(hoadon.Quan));

                                dsBaoCao.Tables["DSCapDinhMuc"].Rows.Add(dr);
                            }
                        }
                        else
                        {
                            if (cmbPhuong.SelectedValue.ToString() == itemRow["Phuong"].ToString() && cmbQuan.SelectedValue.ToString() == itemRow["Quan"].ToString())
                            {
                                DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                                dr["TuNgay"] = dateTu.Value.Date.ToString("dd/MM/yyyy");
                                dr["DenNgay"] = dateDen.Value.Date.ToString("dd/MM/yyyy");
                                dr["LoaiBaoCao"] = "CÓ THỜI HẠN";
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
                                {
                                    dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                                    dr["TieuThu"] = _cThuTien.GetTieuThuMoiNhat(itemRow["DanhBo"].ToString());
                                }
                                dr["HoTen"] = hoadon.TENKH;
                                dr["DiaChi"] = hoadon.SO + " " + hoadon.DUONG;
                                dr["MaLCT"] = itemRow["MaLCT"];
                                dr["TenLCT"] = itemRow["TenLCT"];
                                dr["MaCT"] = itemRow["MaCT"];
                                dr["DinhMucCap"] = (int.Parse(itemRow["SoNKDangKy"].ToString()) * 4).ToString();
                                dr["NgayHetHan"] = itemRow["NgayHetHan"];
                                dr["DienThoai"] = itemRow["DienThoai"];
                                dr["GhiChu"] = itemRow["GhiChu"];
                                dr["Phuong"] = _cDocSo.getTenPhuongByMaQuanPhuong(int.Parse(hoadon.Quan), hoadon.Phuong);
                                dr["Quan"] = _cDocSo.getTenQuanByMaQuan(int.Parse(hoadon.Quan));

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
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.Show();
            }

            if (radDSDMCapKThoiHan.Checked)
            {
                DataTable dt = new DataTable();
                    dt = _cChungTu.LoadDSCapDinhMucKhongThoiHan(dateTu.Value, dateDen.Value);

                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                foreach (DataRow itemRow in dt.Rows)
                {
                    //HOADON hoadon = _cThuTien.GetMoiNhat(itemRow["DanhBo"].ToString());
                    if (cmbQuan.SelectedValue.ToString() == "0")
                    {
                        DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                        dr["TuNgay"] = dateTu.Value.Date.ToString("dd/MM/yyyy");
                        dr["DenNgay"] = dateDen.Value.Date.ToString("dd/MM/yyyy");
                        dr["LoaiBaoCao"] = "KHÔNG THỜI HẠN";
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

                                dr["TuNgay"] = dateTu.Value.Date.ToString("dd/MM/yyyy");
                                dr["DenNgay"] = dateDen.Value.Date.ToString("dd/MM/yyyy");
                                dr["LoaiBaoCao"] = "KHÔNG THỜI HẠN";
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

                                dr["TuNgay"] = dateTu.Value.Date.ToString("dd/MM/yyyy");
                                dr["DenNgay"] = dateDen.Value.Date.ToString("dd/MM/yyyy");
                                dr["LoaiBaoCao"] = "KHÔNG THỜI HẠN";
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
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.Show();
            }

            if (radDSDMCapNgayHetHan.Checked)
            {
                DataTable dt = _cChungTu.LoadDSCapDinhMucNgayHetHan(dateTu.Value, dateDen.Value);

                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                foreach (DataRow itemRow in dt.Rows)
                {
                    HOADON hoadon = _cThuTien.GetMoiNhat(itemRow["DanhBo"].ToString());
                    if (cmbQuan.SelectedValue.ToString() == "0")
                    {
                        DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                        dr["TuNgay"] = dateTu.Value.Date.ToString("dd/MM/yyyy");
                        dr["DenNgay"] = dateDen.Value.Date.ToString("dd/MM/yyyy");
                        dr["LoaiBaoCao"] = "SẮP THỜI HẠN";
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

                        if (hoadon != null)
                        {
                            dr["HoTen"] = hoadon.TENKH;
                            dr["DiaChi"] = hoadon.SO + " " + hoadon.DUONG;
                            dr["Phuong"] = _cDocSo.getTenPhuongByMaQuanPhuong(int.Parse(hoadon.Quan), hoadon.Phuong);
                            dr["Quan"] = _cDocSo.getTenQuanByMaQuan(int.Parse(hoadon.Quan));
                        }

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
                            if (cmbQuan.SelectedValue.ToString() == hoadon.Quan)
                            {
                                DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                                dr["TuNgay"] = dateTu.Value.Date.ToString("dd/MM/yyyy");
                                dr["DenNgay"] = dateDen.Value.Date.ToString("dd/MM/yyyy");
                                dr["LoaiBaoCao"] = "SẮP THỜI HẠN";
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

                                if (hoadon != null)
                                {
                                    dr["HoTen"] = hoadon.TENKH;
                                    dr["DiaChi"] = hoadon.SO + " " + hoadon.DUONG;
                                    dr["Phuong"] = _cDocSo.getTenPhuongByMaQuanPhuong(int.Parse(hoadon.Quan), hoadon.Phuong);
                                    dr["Quan"] = _cDocSo.getTenQuanByMaQuan(int.Parse(hoadon.Quan));
                                }

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
                            if (cmbPhuong.SelectedValue.ToString() == hoadon.Phuong && cmbQuan.SelectedValue.ToString() == hoadon.Quan)
                            {
                                DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                                dr["TuNgay"] = dateTu.Value.Date.ToString("dd/MM/yyyy");
                                dr["DenNgay"] = dateDen.Value.Date.ToString("dd/MM/yyyy");
                                dr["LoaiBaoCao"] = "SẮP THỜI HẠN";
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

                                if (hoadon != null)
                                {
                                    dr["HoTen"] = hoadon.TENKH;
                                    dr["DiaChi"] = hoadon.SO + " " + hoadon.DUONG;
                                    dr["Phuong"] = _cDocSo.getTenPhuongByMaQuanPhuong(int.Parse(hoadon.Quan), hoadon.Phuong);
                                    dr["Quan"] = _cDocSo.getTenQuanByMaQuan(int.Parse(hoadon.Quan));
                                }

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
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.Show();
            }

            if (radThongKeDC.Checked)
            {
                DataTable dtDCBD = new DataTable();
                DataTable dtDCHD = new DataTable();
                DataTable dtCatChuyenDM = new DataTable();

                    dtDCBD = _cDCBD.LoadDSCTDCBD(dateTu.Value, dateDen.Value);
                    dtDCHD = _cDCBD.LoadDSCTDCHD(dateTu.Value, dateDen.Value);
                    dtCatChuyenDM = _cChungTu.LoadDSCatChuyenDM(dateTu.Value, dateDen.Value);

                int DanhBoTangDM = 0;
                int DanhBoGiamDM = 0;
                int DinhMucTang = 0;
                int DinhMucGiam = 0;
                int DanhBoTangDM_CC = 0;
                int DanhBoGiamDM_CC = 0;
                int DinhMucTang_CC = 0;
                int DinhMucGiam_CC = 0;
                int DanhBoTangDM_NT = 0;
                int DanhBoGiamDM_NT = 0;
                int DinhMucTang_NT = 0;
                int DinhMucGiam_NT = 0;

                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                ///không nhập hiệu lực kỳ, tính tất cả
                if (string.IsNullOrEmpty(txtHieuLucKy.Text.Trim()))
                {
                    foreach (DataRow itemRow in dtDCBD.Rows)
                    {
                        DataRow dr = dsBaoCao.Tables["ThongKeDCBD"].NewRow();

                        dr["TuNgay"] = dateTu.Value.Date.ToString("dd/MM/yyyy");
                        dr["DenNgay"] = dateDen.Value.Date.ToString("dd/MM/yyyy");
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
                        dr["NhaTro"] = _cChungTu.CheckDinhMucNhaTro(itemRow["DanhBo"].ToString());

                        if (!string.IsNullOrEmpty(itemRow["DinhMuc_BD"].ToString()))
                        {
                            int a = 0;
                            if (string.IsNullOrEmpty(itemRow["DinhMuc"].ToString()))
                                a = 0;
                            else
                                a = int.Parse(itemRow["DinhMuc"].ToString());

                            if (bool.Parse(dr["NhaTro"].ToString()))
                                if (int.Parse(itemRow["DinhMuc_BD"].ToString()) > a)
                                {
                                    DanhBoTangDM_NT++;
                                    DinhMucTang_NT += int.Parse(itemRow["DinhMuc_BD"].ToString()) - a;
                                }
                                else
                                {
                                    DanhBoGiamDM_NT++;
                                    DinhMucGiam_NT += a - int.Parse(itemRow["DinhMuc_BD"].ToString());
                                }
                            else
                                if (int.Parse(itemRow["GiaBieu"].ToString()) != 51)
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
                                else
                                    if (int.Parse(itemRow["DinhMuc_BD"].ToString()) > a)
                                    {
                                        DanhBoTangDM_CC++;
                                        DinhMucTang_CC += int.Parse(itemRow["DinhMuc_BD"].ToString()) - a;
                                    }
                                    else
                                    {
                                        DanhBoGiamDM_CC++;
                                        DinhMucGiam_CC += a - int.Parse(itemRow["DinhMuc_BD"].ToString());
                                    }
                        }
                        dsBaoCao.Tables["ThongKeDCBD"].Rows.Add(dr);
                    }
                }
                ///tính theo hiệu lực kỳ
                else
                {
                    string[] hieulucky = txtHieuLucKy.Text.Trim().Split('/');
                    foreach (DataRow itemRow in dtDCBD.Rows)
                        if (itemRow["HieuLucKy"].ToString() != "")
                        {
                            if (hieulucky.Count() > 2)
                            {
                                string[] itemHLK = itemRow["HieuLucKy"].ToString().Split('/');
                                if (int.Parse(itemHLK[1]) < int.Parse(hieulucky[1]) || (int.Parse(itemHLK[1]) == int.Parse(hieulucky[1]) && int.Parse(itemHLK[0]) <= int.Parse(hieulucky[0])))
                                {
                                    DataRow dr = dsBaoCao.Tables["ThongKeDCBD"].NewRow();

                                    dr["TuNgay"] = dateTu.Value.Date.ToString("dd/MM/yyyy");
                                    dr["DenNgay"] = dateDen.Value.Date.ToString("dd/MM/yyyy");
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
                                    dr["NhaTro"] = _cChungTu.CheckDinhMucNhaTro(itemRow["DanhBo"].ToString());

                                    if (!string.IsNullOrEmpty(itemRow["DinhMuc_BD"].ToString()))
                                    {
                                        int a = 0;
                                        if (string.IsNullOrEmpty(itemRow["DinhMuc"].ToString()))
                                            a = 0;
                                        else
                                            a = int.Parse(itemRow["DinhMuc"].ToString());

                                        if (bool.Parse(dr["NhaTro"].ToString()))
                                            if (int.Parse(itemRow["DinhMuc_BD"].ToString()) > a)
                                            {
                                                DanhBoTangDM_NT++;
                                                DinhMucTang_NT += int.Parse(itemRow["DinhMuc_BD"].ToString()) - a;
                                            }
                                            else
                                            {
                                                DanhBoGiamDM_NT++;
                                                DinhMucGiam_NT += a - int.Parse(itemRow["DinhMuc_BD"].ToString());
                                            }
                                        else
                                            if (int.Parse(itemRow["GiaBieu"].ToString()) != 51)
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
                                            else
                                                if (int.Parse(itemRow["DinhMuc_BD"].ToString()) > a)
                                                {
                                                    DanhBoTangDM_CC++;
                                                    DinhMucTang_CC += int.Parse(itemRow["DinhMuc_BD"].ToString()) - a;
                                                }
                                                else
                                                {
                                                    DanhBoGiamDM_CC++;
                                                    DinhMucGiam_CC += a - int.Parse(itemRow["DinhMuc_BD"].ToString());
                                                }
                                    }
                                    dsBaoCao.Tables["ThongKeDCBD"].Rows.Add(dr);
                                }
                                ///không thuộc hiệu lực kỳ
                                else
                                {
                                    DateTime date = new DateTime();
                                    DateTime.TryParse(itemRow["CreateDate"].ToString(), out date);
                                    DataTable dtTemp = _cChungTu.LoadDSCapDinhMuc(itemRow["DanhBo"].ToString(), date);

                                    foreach (DataRow rowTemp in dtTemp.Rows)
                                    {
                                        HOADON hoadon = _cThuTien.GetMoiNhat(rowTemp["DanhBo"].ToString());
                                        DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                                        dr["TuNgay"] = dateTu.Value.Date.ToString("dd/MM/yyyy");
                                        dr["DenNgay"] = dateDen.Value.Date.ToString("dd/MM/yyyy");
                                        dr["LoaiBaoCao"] = "KHÔNG THUỘC HIỆU LỰC KỲ";
                                        if (_cDCBD.checkCTDCBDbyDanhBoCreateDate(rowTemp["DanhBo"].ToString(), DateTime.Parse(rowTemp["CreateDate"].ToString())))
                                        {
                                            string a = _cDCBD.getCTDCBDbyDanhBoCreateDate(rowTemp["DanhBo"].ToString(), DateTime.Parse(rowTemp["CreateDate"].ToString())).ToString();
                                            dr["SoPhieu"] = a.Insert(a.Length - 2, "-");
                                        }
                                        else
                                            dr["SoPhieu"] = "";

                                        if (_cChungTu.CheckMaDonbyDanhBoChungTu(rowTemp["DanhBo"].ToString(), rowTemp["MaCT"].ToString()))
                                        {
                                            decimal MaDon = _cChungTu.getMaDonbyDanhBoChungTu(rowTemp["DanhBo"].ToString(), rowTemp["MaCT"].ToString());
                                            dr["MaDon"] = MaDon.ToString().Insert(MaDon.ToString().Length - 2, "-");
                                        }
                                        else
                                            dr["MaDon"] = "";

                                        if (!string.IsNullOrEmpty(rowTemp["DanhBo"].ToString()))
                                        {
                                            dr["DanhBo"] = rowTemp["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                                            dr["TieuThu"] = _cThuTien.GetTieuThuMoiNhat(rowTemp["DanhBo"].ToString());
                                        }
                                        dr["HoTen"] = hoadon.TENKH;
                                        dr["DiaChi"] = hoadon.SO + " " + hoadon.DUONG;
                                        dr["MaLCT"] = rowTemp["MaLCT"];
                                        dr["TenLCT"] = rowTemp["TenLCT"];
                                        dr["MaCT"] = rowTemp["MaCT"];
                                        dr["DinhMucCap"] = (int.Parse(rowTemp["SoNKDangKy"].ToString()) * 4).ToString();
                                        dr["NgayHetHan"] = rowTemp["NgayHetHan"];
                                        dr["DienThoai"] = rowTemp["DienThoai"];
                                        dr["GhiChu"] = rowTemp["GhiChu"];
                                        dr["Phuong"] = _cDocSo.getTenPhuongByMaQuanPhuong(int.Parse(hoadon.Quan), hoadon.Phuong);
                                        dr["Quan"] = _cDocSo.getTenQuanByMaQuan(int.Parse(hoadon.Quan));

                                        dsBaoCao.Tables["DSCapDinhMuc"].Rows.Add(dr);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Số Phiếu: " + itemRow["SoPhieu"].ToString().Insert(itemRow["SoPhieu"].ToString().Length - 2, "-") + " sai hiệu lực kỳ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
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
                        {
                            dr["LoaiCatChuyen"] = "Cắt Chuyển đến Công ty khác";
                            dr["SoNK"] = itemRow["SoNK"];
                        }
                    }
                    else
                        if (itemRow["YeuCauCat"].ToString() != "")
                        {
                            if (bool.Parse(itemRow["YeuCauCat"].ToString()))
                            {
                                dr["LoaiCatChuyen"] = "Yêu Cầu Công ty khác Cắt";
                                dr["SoNK"] = itemRow["SoNK"];
                            }
                        }
                        else
                            if (itemRow["NhanDM"].ToString() != "")
                                if (bool.Parse(itemRow["NhanDM"].ToString()))
                                {
                                    dr["LoaiCatChuyen"] = "Nhận từ Công ty khác";
                                    dr["SoNK"] = itemRow["SoNK"];
                                }
                    dsBaoCao.Tables["ThongKeCatChuyenDM"].Rows.Add(dr);
                }

                //dateTu.Value = DateTime.Now;
                //dateDen.Value = DateTime.Now;
                //_tuNgay = _denNgay = "";

                rptThongKeDCBD rpt = new rptThongKeDCBD();
                rpt.SetDataSource(dsBaoCao);
                rpt.Subreports[0].SetDataSource(dsBaoCao);
                rpt.Subreports[1].SetDataSource(dsBaoCao);
                //rpt.Subreports[2].SetDataSource(dsBaoCao);

                rpt.SetParameterValue(0, DanhBoTangDM);
                rpt.SetParameterValue(1, DinhMucTang);
                rpt.SetParameterValue(2, DanhBoGiamDM);
                rpt.SetParameterValue(3, DinhMucGiam);
                rpt.SetParameterValue(4, DanhBoTangDM_CC);
                rpt.SetParameterValue(5, DinhMucTang_CC);
                rpt.SetParameterValue(6, DanhBoGiamDM_CC);
                rpt.SetParameterValue(7, DinhMucGiam_CC);
                rpt.SetParameterValue(8, DanhBoTangDM_NT);
                rpt.SetParameterValue(9, DinhMucTang_NT);
                rpt.SetParameterValue(10, DanhBoGiamDM_NT);
                rpt.SetParameterValue(11, DinhMucGiam_NT);

                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.Show();

                rptDSCapDinhMuc rpt2 = new rptDSCapDinhMuc();
                rpt2.SetDataSource(dsBaoCao);
                frmShowBaoCao frm2 = new frmShowBaoCao(rpt2);
                frm2.Show();
            }

            if (radThongKeDCSoCT.Checked)
            {
                DataTable dt = _cDCBD.LoadDSCTDCBDSoCT(dateTu.Value, dateDen.Value);

                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                foreach (DataRow itemRow in dt.Rows)
                {
                    DataRow dr = dsBaoCao.Tables["ThongKeDCSoCT"].NewRow();

                    dr["TuNgay"] = dateTu.Value.Date.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = dateDen.Value.Date.ToString("dd/MM/yyyy");
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
                    dr["Phuong"] = _cDocSo.getTenPhuongByMaQuanPhuong(int.Parse(itemRow["Quan"].ToString()), itemRow["Phuong"].ToString());
                    dr["Quan"] = _cDocSo.getTenQuanByMaQuan(int.Parse(itemRow["Quan"].ToString()));

                    dsBaoCao.Tables["ThongKeDCSoCT"].Rows.Add(dr);
                }

                //dateTu.Value = DateTime.Now;
                //dateDen.Value = DateTime.Now;
                //_tuNgay = _denNgay = "";

                rptThongKeDCSoCT rpt = new rptThongKeDCSoCT();
                rpt.SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.Show();
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
                        if (ctdcbd != null)
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

                        HOADON hoadon = _cThuTien.GetMoiNhat(itemRow["DanhBo"].ToString());
                        if (hoadon != null)
                        {
                            dr["HoTen"] = hoadon.TENKH;
                            dr["DiaChi"] = hoadon.SO + " " + hoadon.DUONG;
                            //dr["Phuong"] = _cDocSo.getTenPhuongByMaQuanPhuong(int.Parse(hoadon.Quan), hoadon.Phuong);
                            //dr["Quan"] = _cDocSo.getTenQuanByMaQuan(int.Parse(hoadon.Quan));
                        }

                        dsBaoCao.Tables["DSCapDinhMuc"].Rows.Add(dr);
                    }

                rptDSCapDinhMuc_HetHan rpt = new rptDSCapDinhMuc_HetHan();
                rpt.SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.Show();
            }

            if (radThongKeCapDMCoThoiHanTangGiam.Checked)
            {
                DataTable dt = new DataTable();
                    dt = _cChungTu.LoadThongKeDMCapCoThoiHan(dateTu.Value, dateDen.Value);

                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                foreach (DataRow itemRow in dt.Rows)
                {
                    HOADON hoadon = _cThuTien.GetMoiNhat(itemRow["DanhBo"].ToString());
                    if (cmbQuan.SelectedValue.ToString() == "0")
                    {
                        DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                        dr["TuNgay"] = dateTu.Value.Date.ToString("dd/MM/yyyy");
                        dr["DenNgay"] = dateDen.Value.Date.ToString("dd/MM/yyyy");

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
                        dr["Phuong"] = _cDocSo.getTenPhuongByMaQuanPhuong(int.Parse(hoadon.Quan), hoadon.Phuong);
                        dr["Quan"] = _cDocSo.getTenQuanByMaQuan(int.Parse(hoadon.Quan));
                        dsBaoCao.Tables["DSCapDinhMuc"].Rows.Add(dr);
                    }
                    else
                        if (cmbPhuong.SelectedValue.ToString() == "0")
                        {
                            if (cmbQuan.SelectedValue.ToString() == hoadon.Quan)
                            {
                                DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                                dr["TuNgay"] = dateTu.Value.Date.ToString("dd/MM/yyyy");
                                dr["DenNgay"] = dateDen.Value.Date.ToString("dd/MM/yyyy");

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
                                dr["Phuong"] = _cDocSo.getTenPhuongByMaQuanPhuong(int.Parse(hoadon.Quan), hoadon.Phuong);
                                dr["Quan"] = _cDocSo.getTenQuanByMaQuan(int.Parse(hoadon.Quan));
                                dsBaoCao.Tables["DSCapDinhMuc"].Rows.Add(dr);
                            }
                        }
                        else
                        {
                            if (cmbPhuong.SelectedValue.ToString() == hoadon.Phuong && cmbQuan.SelectedValue.ToString() == hoadon.Quan)
                            {
                                DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                                dr["TuNgay"] = dateTu.Value.Date.ToString("dd/MM/yyyy");
                                dr["DenNgay"] = dateDen.Value.Date.ToString("dd/MM/yyyy");

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
                                dr["Phuong"] = _cDocSo.getTenPhuongByMaQuanPhuong(int.Parse(hoadon.Quan), hoadon.Phuong);
                                dr["Quan"] = _cDocSo.getTenQuanByMaQuan(int.Parse(hoadon.Quan));
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
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.Show();
            }

            if (radDSDanhBoDMCap.Checked)
            {
                DataTable dt = _cChungTu.LoadDSDanhBoCapDinhMucCoThoiHan();

                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                foreach (DataRow itemRow in dt.Rows)
                {
                    if (cmbQuan.SelectedValue.ToString() == "0")
                    {
                        DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                        if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                        {
                            dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                            dr["DinhMucCap"] = _cDocSo.GetDinhMuc(itemRow["DanhBo"].ToString());
                        }
                        dr["HoTen"] = itemRow["HoTen"];
                        dr["DiaChi"] = itemRow["DiaChi"];
                        dr["Phuong"] = _cDocSo.getTenPhuongByMaQuanPhuong(int.Parse(itemRow["Quan"].ToString()), itemRow["Phuong"].ToString());
                        dr["Quan"] = _cDocSo.getTenQuanByMaQuan(int.Parse(itemRow["Quan"].ToString()));
                        
                        dsBaoCao.Tables["DSCapDinhMuc"].Rows.Add(dr);
                    }
                    else
                        if (cmbPhuong.SelectedValue.ToString() == "0")
                        {
                            if (cmbQuan.SelectedValue.ToString() == itemRow["Quan"].ToString())
                            {
                                DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                                if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                                {
                                    dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                                    dr["DinhMucCap"] = _cDocSo.GetDinhMuc(itemRow["DanhBo"].ToString());
                                }
                                dr["HoTen"] = itemRow["HoTen"];
                                dr["DiaChi"] = itemRow["DiaChi"];
                                dr["Phuong"] = _cDocSo.getTenPhuongByMaQuanPhuong(int.Parse(itemRow["Quan"].ToString()), itemRow["Phuong"].ToString());
                                dr["Quan"] = _cDocSo.getTenQuanByMaQuan(int.Parse(itemRow["Quan"].ToString()));
                                dsBaoCao.Tables["DSCapDinhMuc"].Rows.Add(dr);
                            }
                        }
                        else
                        {
                            if (cmbPhuong.SelectedValue.ToString() == itemRow["Phuong"].ToString() && cmbQuan.SelectedValue.ToString() == itemRow["Quan"].ToString())
                            {
                                DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                                if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                                {
                                    dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                                    dr["DinhMucCap"] = _cDocSo.GetDinhMuc(itemRow["DanhBo"].ToString());
                                }
                                dr["HoTen"] = itemRow["HoTen"];
                                dr["DiaChi"] = itemRow["DiaChi"];
                                dr["Phuong"] = _cDocSo.getTenPhuongByMaQuanPhuong(int.Parse(itemRow["Quan"].ToString()), itemRow["Phuong"].ToString());
                                dr["Quan"] = _cDocSo.getTenQuanByMaQuan(int.Parse(itemRow["Quan"].ToString()));
                                dsBaoCao.Tables["DSCapDinhMuc"].Rows.Add(dr);
                            }
                        }
                }
                rptDSCapDinhMucTheoDanhBo rpt = new rptDSCapDinhMucTheoDanhBo();
                rpt.SetDataSource(dsBaoCao);
                rpt.Subreports[0].SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.Show();
            }

            if (radDSDanhBoCapDMDoanThanhNien.Checked)
            {
                DataTable dt = _cChungTu.LoadDSDanhBoCapDinhMucCoThoiHanDoanThanhNien(dateTu.Value,dateDen.Value);

                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                foreach (DataRow itemRow in dt.Rows)
                {
                    if (cmbQuan.SelectedValue.ToString() == "0")
                    {
                        DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                        dr["LoaiBaoCao"] = "DANH SÁCH CẤP ĐỊNH MỨC CÓ THỜI HẠN (ĐOÀN THANH NIÊN)";
                        if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                        {
                            dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                            dr["DinhMucCap"] = _cDocSo.GetDinhMuc(itemRow["DanhBo"].ToString());
                        }
                        dr["HoTen"] = itemRow["HoTen"];
                        dr["DiaChi"] = itemRow["DiaChi"];
                        dr["Phuong"] = _cDocSo.getTenPhuongByMaQuanPhuong(int.Parse(itemRow["Quan"].ToString()), itemRow["Phuong"].ToString());
                        dr["Quan"] = _cDocSo.getTenQuanByMaQuan(int.Parse(itemRow["Quan"].ToString()));

                        dsBaoCao.Tables["DSCapDinhMuc"].Rows.Add(dr);
                    }
                    else
                        if (cmbPhuong.SelectedValue.ToString() == "0")
                        {
                            if (cmbQuan.SelectedValue.ToString() == itemRow["Quan"].ToString())
                            {
                                DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                                dr["LoaiBaoCao"] = "DANH SÁCH CẤP ĐỊNH MỨC CÓ THỜI HẠN (ĐOÀN THANH NIÊN)";
                                if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                                {
                                    dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                                    dr["DinhMucCap"] = _cDocSo.GetDinhMuc(itemRow["DanhBo"].ToString());
                                }
                                dr["HoTen"] = itemRow["HoTen"];
                                dr["DiaChi"] = itemRow["DiaChi"];
                                dr["Phuong"] = _cDocSo.getTenPhuongByMaQuanPhuong(int.Parse(itemRow["Quan"].ToString()), itemRow["Phuong"].ToString());
                                dr["Quan"] = _cDocSo.getTenQuanByMaQuan(int.Parse(itemRow["Quan"].ToString()));
                                dsBaoCao.Tables["DSCapDinhMuc"].Rows.Add(dr);
                            }
                        }
                        else
                        {
                            if (cmbPhuong.SelectedValue.ToString() == itemRow["Phuong"].ToString() && cmbQuan.SelectedValue.ToString() == itemRow["Quan"].ToString())
                            {
                                DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                                dr["LoaiBaoCao"] = "DANH SÁCH CẤP ĐỊNH MỨC CÓ THỜI HẠN (ĐOÀN THANH NIÊN)";
                                if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                                {
                                    dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                                    dr["DinhMucCap"] = _cDocSo.GetDinhMuc(itemRow["DanhBo"].ToString());
                                }
                                dr["HoTen"] = itemRow["HoTen"];
                                dr["DiaChi"] = itemRow["DiaChi"];
                                dr["Phuong"] = _cDocSo.getTenPhuongByMaQuanPhuong(int.Parse(itemRow["Quan"].ToString()), itemRow["Phuong"].ToString());
                                dr["Quan"] = _cDocSo.getTenQuanByMaQuan(int.Parse(itemRow["Quan"].ToString()));
                                dsBaoCao.Tables["DSCapDinhMuc"].Rows.Add(dr);
                            }
                        }
                }
                rptDSCapDinhMucTheoDanhBo rpt = new rptDSCapDinhMucTheoDanhBo();
                rpt.SetDataSource(dsBaoCao);
                rpt.Subreports[0].SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.Show();
            }

            if (radDSDanhBoDCHDCodeF2.Checked)
            {
                DataTable dt = _cChungTu.LoadDSDanhBoDCHDCodeF2(dateTu.Value, dateDen.Value);

                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                foreach (DataRow itemRow in dt.Rows)
                {
                    if (cmbQuan.SelectedValue.ToString() == "0")
                    {
                        DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                        dr["LoaiBaoCao"] = "DANH SÁCH ĐCHĐ (CODE F2=0)";
                        if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                        {
                            dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                            //dr["DinhMucCap"] = _cDocSo.GetDinhMuc(itemRow["DanhBo"].ToString());
                        }
                        dr["HoTen"] = itemRow["HoTen"];
                        dr["DiaChi"] = itemRow["DiaChi"];
                        dr["Phuong"] = _cDocSo.getTenPhuongByMaQuanPhuong(int.Parse(itemRow["Quan"].ToString()), itemRow["Phuong"].ToString());
                        dr["Quan"] = _cDocSo.getTenQuanByMaQuan(int.Parse(itemRow["Quan"].ToString()));

                        dsBaoCao.Tables["DSCapDinhMuc"].Rows.Add(dr);
                    }
                    else
                        if (cmbPhuong.SelectedValue.ToString() == "0")
                        {
                            if (cmbQuan.SelectedValue.ToString() == itemRow["Quan"].ToString())
                            {
                                DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                                dr["LoaiBaoCao"] = "DANH SÁCH ĐCHĐ (CODE F2=0)";
                                if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                                {
                                    dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                                    //dr["DinhMucCap"] = _cDocSo.GetDinhMuc(itemRow["DanhBo"].ToString());
                                }
                                dr["HoTen"] = itemRow["HoTen"];
                                dr["DiaChi"] = itemRow["DiaChi"];
                                dr["Phuong"] = _cDocSo.getTenPhuongByMaQuanPhuong(int.Parse(itemRow["Quan"].ToString()), itemRow["Phuong"].ToString());
                                dr["Quan"] = _cDocSo.getTenQuanByMaQuan(int.Parse(itemRow["Quan"].ToString()));
                                dsBaoCao.Tables["DSCapDinhMuc"].Rows.Add(dr);
                            }
                        }
                        else
                        {
                            if (cmbPhuong.SelectedValue.ToString() == itemRow["Phuong"].ToString() && cmbQuan.SelectedValue.ToString() == itemRow["Quan"].ToString())
                            {
                                DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                                dr["LoaiBaoCao"] = "DANH SÁCH ĐCHĐ (CODE F2=0)";
                                if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                                {
                                    dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                                    //dr["DinhMucCap"] = _cDocSo.GetDinhMuc(itemRow["DanhBo"].ToString());
                                }
                                dr["HoTen"] = itemRow["HoTen"];
                                dr["DiaChi"] = itemRow["DiaChi"];
                                dr["Phuong"] = _cDocSo.getTenPhuongByMaQuanPhuong(int.Parse(itemRow["Quan"].ToString()), itemRow["Phuong"].ToString());
                                dr["Quan"] = _cDocSo.getTenQuanByMaQuan(int.Parse(itemRow["Quan"].ToString()));
                                dsBaoCao.Tables["DSCapDinhMuc"].Rows.Add(dr);
                            }
                        }
                }
                rptDSCapDinhMucTheoDanhBo rpt = new rptDSCapDinhMucTheoDanhBo();
                rpt.SetDataSource(dsBaoCao);
                rpt.Subreports[0].SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.Show();
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

        private void radDSDanhBoDMCap_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            if (radDSDanhBoDMCap.Checked)
            {
                DataTable dt = _cChungTu.LoadDSDanhBoCapDinhMucCoThoiHan();

                //Tạo các đối tượng Excel
                Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbooks oBooks;
                Microsoft.Office.Interop.Excel.Sheets oSheets;
                Microsoft.Office.Interop.Excel.Workbook oBook;
                Microsoft.Office.Interop.Excel.Worksheet oSheet;
                //Microsoft.Office.Interop.Excel.Worksheet oSheetCQ;

                //Tạo mới một Excel WorkBook 
                oExcel.Visible = true;
                oExcel.DisplayAlerts = false;
                //khai báo số lượng sheet
                oExcel.Application.SheetsInNewWorkbook = 1;
                oBooks = oExcel.Workbooks;

                oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
                oSheets = oBook.Worksheets;
                oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

                oSheet.Name = "Định Mức Cấp Có Thời Hạn";

                // Tạo phần đầu nếu muốn
                Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "F1");
                head.MergeCells = true;
                head.Value2 = "DANH SÁCH ĐỊNH MỨC CẤP CÓ THỜI HẠN";
                head.Font.Bold = true;
                head.Font.Name = "Times New Roman";
                head.Font.Size = "20";
                head.RowHeight = 50;
                head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                // Tạo tiêu đề cột 
                Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");
                cl1.Value2 = "Danh Bộ";
                cl1.ColumnWidth = 15;

                Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");
                cl2.Value2 = "Khách Hàng";
                cl2.ColumnWidth = 30;

                Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");
                cl3.Value2 = "Địa Chỉ";
                cl3.ColumnWidth = 30;

                // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
                // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
                object[,] arr = new object[dt.Rows.Count, 3];

                //Chuyển dữ liệu từ DataTable vào mảng đối tượng
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];

                    arr[i, 0] = dr["DanhBo"].ToString();
                    arr[i, 1] = dr["HoTen"].ToString();
                    arr[i, 2] = dr["DiaChi"].ToString();
                }

                //Thiết lập vùng điền dữ liệu
                int rowStart = 4;
                int columnStart = 1;

                int rowEnd = rowStart + dt.Rows.Count - 1;
                int columnEnd = 3;

                // Ô bắt đầu điền dữ liệu
                Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
                // Ô kết thúc điền dữ liệu
                Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
                // Lấy về vùng điền dữ liệu
                Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

                Microsoft.Office.Interop.Excel.Range c1a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 1];
                Microsoft.Office.Interop.Excel.Range c2a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 1];
                Microsoft.Office.Interop.Excel.Range c3a = oSheet.get_Range(c1a, c2a);
                c3a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                Microsoft.Office.Interop.Excel.Range c1b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 2];
                Microsoft.Office.Interop.Excel.Range c2b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 2];
                Microsoft.Office.Interop.Excel.Range c3b = oSheet.get_Range(c1b, c2b);
                c3b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                c3b.NumberFormat = "#,##0";

                Microsoft.Office.Interop.Excel.Range c1c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 3];
                Microsoft.Office.Interop.Excel.Range c2c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 3];
                Microsoft.Office.Interop.Excel.Range c3c = oSheet.get_Range(c1c, c2c);
                c3c.NumberFormat = "@";
                c3c.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                //Điền dữ liệu vào vùng đã thiết lập
                range.Value2 = arr;

            }
        }

    }
}
