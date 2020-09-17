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
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmBaoCaoDCBD : Form
    {
        CChungTu _cChungTu = new CChungTu();
        CDCBD _cDCBD = new CDCBD();
        CDHN _cDocSo = new CDHN();
        List<QUAN> _lst;
        CThuTien _cThuTien = new CThuTien();

        public frmBaoCaoDCBD()
        {
            InitializeComponent();
        }

        private void frmBCCapDinhMuc_Load(object sender, EventArgs e)
        {
            _lst = _cDocSo.GetDSQuan();
            QUAN quan = new QUAN();
            quan.MAQUAN = 0;
            quan.TENQUAN = "Tất Cả";
            _lst.Insert(0, quan);
            cmbQuan.DataSource = _lst;
            cmbQuan.DisplayMember = "TenQuan";
            cmbQuan.ValueMember = "MaQuan";

            cmbQuan_ThongKeDC.DataSource = _lst;
            cmbQuan_ThongKeDC.DisplayMember = "TenQuan";
            cmbQuan_ThongKeDC.ValueMember = "MaQuan";
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
                        if (_cDCBD.checkExist_BienDong(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())))
                        {
                            string a = _cDCBD.getMaBienDong(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())).ToString();
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
                        dr["Phuong"] = _cDocSo.GetTenPhuong(int.Parse(hoadon.Quan), hoadon.Phuong);
                        dr["Quan"] = _cDocSo.GetTenQuan(int.Parse(hoadon.Quan));

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
                                if (_cDCBD.checkExist_BienDong(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())))
                                {
                                    string a = _cDCBD.getMaBienDong(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())).ToString();
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
                                dr["Phuong"] = _cDocSo.GetTenPhuong(int.Parse(hoadon.Quan), hoadon.Phuong);
                                dr["Quan"] = _cDocSo.GetTenQuan(int.Parse(hoadon.Quan));

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
                                if (_cDCBD.checkExist_BienDong(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())))
                                {
                                    string a = _cDCBD.getMaBienDong(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())).ToString();
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
                                dr["Phuong"] = _cDocSo.GetTenPhuong(int.Parse(hoadon.Quan), hoadon.Phuong);
                                dr["Quan"] = _cDocSo.GetTenQuan(int.Parse(hoadon.Quan));

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
                        if (_cDCBD.checkExist_BienDong(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())))
                        {
                            string a = _cDCBD.getMaBienDong(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())).ToString();
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
                                if (_cDCBD.checkExist_BienDong(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())))
                                {
                                    string a = _cDCBD.getMaBienDong(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())).ToString();
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
                                if (_cDCBD.checkExist_BienDong(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())))
                                {
                                    string a = _cDCBD.getMaBienDong(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())).ToString();
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
                        dr["LoaiBaoCao"] = "SẮP HẾT HẠN";
                        if (_cDCBD.checkExist_BienDong(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())))
                        {
                            string a = _cDCBD.getMaBienDong(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())).ToString();
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
                            dr["Phuong"] = _cDocSo.GetTenPhuong(int.Parse(hoadon.Quan), hoadon.Phuong);
                            dr["Quan"] = _cDocSo.GetTenQuan(int.Parse(hoadon.Quan));
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
                                dr["LoaiBaoCao"] = "SẮP HẾT HẠN";
                                if (_cDCBD.checkExist_BienDong(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())))
                                {
                                    string a = _cDCBD.getMaBienDong(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())).ToString();
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
                                    dr["Phuong"] = _cDocSo.GetTenPhuong(int.Parse(hoadon.Quan), hoadon.Phuong);
                                    dr["Quan"] = _cDocSo.GetTenQuan(int.Parse(hoadon.Quan));
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
                                dr["LoaiBaoCao"] = "SẮP HẾT HẠN";
                                if (_cDCBD.checkExist_BienDong(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())))
                                {
                                    string a = _cDCBD.getMaBienDong(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())).ToString();
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
                                    dr["Phuong"] = _cDocSo.GetTenPhuong(int.Parse(hoadon.Quan), hoadon.Phuong);
                                    dr["Quan"] = _cDocSo.GetTenQuan(int.Parse(hoadon.Quan));
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
                    dr["Phuong"] = _cDocSo.GetTenPhuong(int.Parse(itemRow["Quan"].ToString()), itemRow["Phuong"].ToString());
                    dr["Quan"] = _cDocSo.GetTenQuan(int.Parse(itemRow["Quan"].ToString()));

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
                        DCBD_ChiTietBienDong ctdcbd = _cDCBD.getBienDongDinhMuc_Last(itemRow["DanhBo"].ToString());
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
                            //dr["Phuong"] = _cDocSo.GetTenPhuong(int.Parse(hoadon.Quan), hoadon.Phuong);
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

                        DCBD_ChiTietBienDong ctdcbd = _cDCBD.getBienDongDinhMuc_Last(itemRow["DanhBo"].ToString());
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
                        dr["Phuong"] = _cDocSo.GetTenPhuong(int.Parse(hoadon.Quan), hoadon.Phuong);
                        dr["Quan"] = _cDocSo.GetTenQuan(int.Parse(hoadon.Quan));
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

                                DCBD_ChiTietBienDong ctdcbd = _cDCBD.getBienDongDinhMuc_Last(itemRow["DanhBo"].ToString());
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
                                dr["Phuong"] = _cDocSo.GetTenPhuong(int.Parse(hoadon.Quan), hoadon.Phuong);
                                dr["Quan"] = _cDocSo.GetTenQuan(int.Parse(hoadon.Quan));
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

                                DCBD_ChiTietBienDong ctdcbd = _cDCBD.getBienDongDinhMuc_Last(itemRow["DanhBo"].ToString());
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
                                dr["Phuong"] = _cDocSo.GetTenPhuong(int.Parse(hoadon.Quan), hoadon.Phuong);
                                dr["Quan"] = _cDocSo.GetTenQuan(int.Parse(hoadon.Quan));
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
                if (dt == null)
                    return;
                foreach (DataRow itemRow in dt.Rows)
                {
                    if (cmbQuan.SelectedValue.ToString() == "0")
                    {
                        DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                        if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                        {
                            dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                            dr["DinhMucCap"] = itemRow["DinhMuc"];
                            if (itemRow["Quan"].ToString() != "")
                            {
                                dr["Phuong"] = _cDocSo.GetTenPhuong(int.Parse(itemRow["Quan"].ToString()), itemRow["Phuong"].ToString());
                                dr["Quan"] = _cDocSo.GetTenQuan(int.Parse(itemRow["Quan"].ToString()));
                            }
                        }
                        dr["HoTen"] = itemRow["HoTen"];
                        dr["DiaChi"] = itemRow["DiaChi"];


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
                                    dr["DinhMucCap"] = itemRow["DinhMuc"];
                                    if (itemRow["Quan"].ToString() != "")
                                    {
                                        dr["Phuong"] = _cDocSo.GetTenPhuong(int.Parse(itemRow["Quan"].ToString()), itemRow["Phuong"].ToString());
                                        dr["Quan"] = _cDocSo.GetTenQuan(int.Parse(itemRow["Quan"].ToString()));
                                    }
                                }
                                dr["HoTen"] = itemRow["HoTen"];
                                dr["DiaChi"] = itemRow["DiaChi"];

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
                                    dr["DinhMucCap"] = itemRow["DinhMuc"];
                                    if (itemRow["Quan"].ToString() != "")
                                    {
                                        dr["Phuong"] = _cDocSo.GetTenPhuong(int.Parse(itemRow["Quan"].ToString()), itemRow["Phuong"].ToString());
                                        dr["Quan"] = _cDocSo.GetTenQuan(int.Parse(itemRow["Quan"].ToString()));
                                    }
                                }
                                dr["HoTen"] = itemRow["HoTen"];
                                dr["DiaChi"] = itemRow["DiaChi"];

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
                DataTable dt = _cChungTu.LoadDSDanhBoCapDinhMucCoThoiHanDoanThanhNien(dateTu.Value, dateDen.Value);

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
                        dr["Phuong"] = _cDocSo.GetTenPhuong(int.Parse(itemRow["Quan"].ToString()), itemRow["Phuong"].ToString());
                        dr["Quan"] = _cDocSo.GetTenQuan(int.Parse(itemRow["Quan"].ToString()));

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
                                dr["Phuong"] = _cDocSo.GetTenPhuong(int.Parse(itemRow["Quan"].ToString()), itemRow["Phuong"].ToString());
                                dr["Quan"] = _cDocSo.GetTenQuan(int.Parse(itemRow["Quan"].ToString()));
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
                                dr["Phuong"] = _cDocSo.GetTenPhuong(int.Parse(itemRow["Quan"].ToString()), itemRow["Phuong"].ToString());
                                dr["Quan"] = _cDocSo.GetTenQuan(int.Parse(itemRow["Quan"].ToString()));
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
                        dr["Phuong"] = _cDocSo.GetTenPhuong(int.Parse(itemRow["Quan"].ToString()), itemRow["Phuong"].ToString());
                        dr["Quan"] = _cDocSo.GetTenQuan(int.Parse(itemRow["Quan"].ToString()));

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
                                dr["Phuong"] = _cDocSo.GetTenPhuong(int.Parse(itemRow["Quan"].ToString()), itemRow["Phuong"].ToString());
                                dr["Quan"] = _cDocSo.GetTenQuan(int.Parse(itemRow["Quan"].ToString()));
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
                                dr["Phuong"] = _cDocSo.GetTenPhuong(int.Parse(itemRow["Quan"].ToString()), itemRow["Phuong"].ToString());
                                dr["Quan"] = _cDocSo.GetTenQuan(int.Parse(itemRow["Quan"].ToString()));
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

        private void btnBaoCao_DSChungCu_Click(object sender, EventArgs e)
        {
            DataTable dt = _cDocSo.GetDSChungCu();

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow itemRow in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                dr["LoaiBaoCao"] = "CHUNG CƯ QUẬN";
                if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                {
                    dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                }
                dr["HoTen"] = itemRow["HoTen"];
                dr["DiaChi"] = itemRow["DiaChi"];
                dr["GiaBieu"] = itemRow["GiaBieu"];
                dr["DinhMucTruoc"] = itemRow["DinhMuc"];
                dr["Quan"] = itemRow["Quan"];
                dr["Phuong"] = itemRow["Phuong"];
                dr["TenPhong"] = CTaiKhoan.TenPhong.ToUpper();

                dsBaoCao.Tables["DSCapDinhMuc"].Rows.Add(dr);
            }

            rptDS_DanhBo rpt = new rptDS_DanhBo();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void btnBaoCao_ThongKeDC_Click(object sender, EventArgs e)
        {
            DataTable dtDCBD = new DataTable();
            DataTable dtDCHD = new DataTable();
            DataTable dtCatChuyenDM = new DataTable();

            if (int.Parse(cmbQuan_ThongKeDC.SelectedValue.ToString()) == 0)
            {
                dtDCBD = _cDCBD.getDS_BienDong_CreateDate(dateTu_ThongKeDC.Value, dateDen_ThongKeDC.Value);
                dtDCHD = _cDCBD.getDS_HoaDon_CreateDate(dateTu_ThongKeDC.Value, dateDen_ThongKeDC.Value);
                dtCatChuyenDM = _cChungTu.getDSCatChuyenDM(dateTu_ThongKeDC.Value, dateDen_ThongKeDC.Value);
            }
            else
                if (int.Parse(cmbPhuong_ThongKeDC.SelectedValue.ToString()) == 0)
                {
                    dtDCBD = _cDCBD.getDS_BienDong_CreateDate(dateTu_ThongKeDC.Value, dateDen_ThongKeDC.Value, int.Parse(cmbQuan_ThongKeDC.SelectedValue.ToString()));
                    dtDCHD = _cDCBD.getDS_HoaDon_CreateDate(dateTu_ThongKeDC.Value, dateDen_ThongKeDC.Value, int.Parse(cmbQuan_ThongKeDC.SelectedValue.ToString()));
                    dtCatChuyenDM = _cChungTu.getDSCatChuyenDM(dateTu_ThongKeDC.Value, dateDen_ThongKeDC.Value, int.Parse(cmbQuan_ThongKeDC.SelectedValue.ToString()));
                }
                else
                {
                    dtDCBD = _cDCBD.getDS_BienDong_CreateDate(dateTu_ThongKeDC.Value, dateDen_ThongKeDC.Value, int.Parse(cmbQuan_ThongKeDC.SelectedValue.ToString()), int.Parse(cmbPhuong_ThongKeDC.SelectedValue.ToString()));
                    dtDCHD = _cDCBD.getDS_HoaDon_CreateDate(dateTu_ThongKeDC.Value, dateDen_ThongKeDC.Value, int.Parse(cmbQuan_ThongKeDC.SelectedValue.ToString()), int.Parse(cmbPhuong_ThongKeDC.SelectedValue.ToString()));
                    dtCatChuyenDM = _cChungTu.getDSCatChuyenDM(dateTu_ThongKeDC.Value, dateDen_ThongKeDC.Value, int.Parse(cmbQuan_ThongKeDC.SelectedValue.ToString()), int.Parse(cmbPhuong_ThongKeDC.SelectedValue.ToString()));
                }

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
            if (string.IsNullOrEmpty(txtHieuLucKy_ThongKeDC.Text.Trim()))
            {
                foreach (DataRow itemRow in dtDCBD.Rows)
                {
                    DataRow dr = dsBaoCao.Tables["ThongKeDCBD"].NewRow();

                    if (int.Parse(cmbQuan_ThongKeDC.SelectedValue.ToString()) == 0)
                    {

                    }
                    else
                        if (int.Parse(cmbPhuong_ThongKeDC.SelectedValue.ToString()) == 0)
                        {
                            //dr["Quan"] = itemRow["TenQuan"];
                            dr["Quan"] = cmbQuan_ThongKeDC.Text;
                        }
                        else
                        {
                            //dr["Quan"] = itemRow["TenQuan"];
                            //dr["Phuong"] = itemRow["TenPhuong"];
                            dr["Quan"] = cmbQuan_ThongKeDC.Text;
                            dr["Phuong"] = cmbPhuong_ThongKeDC.Text;
                        }

                    dr["TuNgay"] = dateTu_ThongKeDC.Value.Date.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = dateDen_ThongKeDC.Value.Date.ToString("dd/MM/yyyy");
                    if (string.IsNullOrEmpty(itemRow["SoCongVan"].ToString()) == true)
                        dr["SoCongVan"] = "(theo đơn khách hàng)";
                    else
                        dr["SoCongVan"] = "(theo công văn)";
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
                    if (string.IsNullOrEmpty(itemRow["GhiChu"].ToString()) == false)
                        dr["GuiThongBao"] = itemRow["GhiChu"];
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
                string[] hieulucky = txtHieuLucKy_ThongKeDC.Text.Trim().Split('/');
                foreach (DataRow itemRow in dtDCBD.Rows)
                    if (itemRow["HieuLucKy"].ToString() != "")
                    {
                        if (hieulucky.Count() > 2)
                        {
                            string[] itemHLK = itemRow["HieuLucKy"].ToString().Split('/');
                            if (int.Parse(itemHLK[1]) < int.Parse(hieulucky[1]) || (int.Parse(itemHLK[1]) == int.Parse(hieulucky[1]) && int.Parse(itemHLK[0]) <= int.Parse(hieulucky[0])))
                            {
                                DataRow dr = dsBaoCao.Tables["ThongKeDCBD"].NewRow();

                                if (int.Parse(cmbQuan_ThongKeDC.SelectedValue.ToString()) == 0)
                                {

                                }
                                else
                                    if (int.Parse(cmbPhuong_ThongKeDC.SelectedValue.ToString()) == 0)
                                    {
                                        //dr["Quan"] = itemRow["TenQuan"];
                                        dr["Quan"] = cmbQuan_ThongKeDC.Text;
                                    }
                                    else
                                    {
                                        //dr["Quan"] = itemRow["TenQuan"];
                                        //dr["Phuong"] = itemRow["TenPhuong"];
                                        dr["Quan"] = cmbQuan_ThongKeDC.Text;
                                        dr["Phuong"] = cmbPhuong_ThongKeDC.Text;
                                    }

                                dr["TuNgay"] = dateTu_ThongKeDC.Value.Date.ToString("dd/MM/yyyy");
                                dr["DenNgay"] = dateDen_ThongKeDC.Value.Date.ToString("dd/MM/yyyy");
                                if (string.IsNullOrEmpty(itemRow["SoCongVan"].ToString()) == true)
                                    dr["SoCongVan"] = "(theo đơn khách hàng)";
                                else
                                    dr["SoCongVan"] = "(theo công văn)";
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
                                if (string.IsNullOrEmpty(itemRow["GhiChu"].ToString()) == false)
                                    dr["GuiThongBao"] = itemRow["GhiChu"];
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

                                    dr["TuNgay"] = dateTu_ThongKeDC.Value.Date.ToString("dd/MM/yyyy");
                                    dr["DenNgay"] = dateDen_ThongKeDC.Value.Date.ToString("dd/MM/yyyy");
                                    dr["LoaiBaoCao"] = "KHÔNG THUỘC HIỆU LỰC KỲ";
                                    if (_cDCBD.checkExist_BienDong(rowTemp["DanhBo"].ToString(), DateTime.Parse(rowTemp["CreateDate"].ToString())))
                                    {
                                        string a = _cDCBD.getMaBienDong(rowTemp["DanhBo"].ToString(), DateTime.Parse(rowTemp["CreateDate"].ToString())).ToString();
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
                                    dr["Phuong"] = _cDocSo.GetTenPhuong(int.Parse(hoadon.Quan), hoadon.Phuong);
                                    dr["Quan"] = _cDocSo.GetTenQuan(int.Parse(hoadon.Quan));

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
                if (bool.Parse(itemRow["CatDM"].ToString()) == true)
                {
                    dr["LoaiCatChuyen"] = "Cắt Chuyển đến Công ty khác";
                    dr["SoNK"] = itemRow["SoNK"];
                }
                else
                    if (bool.Parse(itemRow["YeuCauCat"].ToString()) == true)
                    {
                        dr["LoaiCatChuyen"] = "Yêu Cầu Công ty khác Cắt";
                        dr["SoNK"] = itemRow["SoNK"];
                    }
                    else
                        if (bool.Parse(itemRow["NhanDM"].ToString()) == true)
                        {
                            dr["LoaiCatChuyen"] = "Nhận từ Công ty khác";
                            dr["SoNK"] = itemRow["SoNK"];
                        }
                dsBaoCao.Tables["ThongKeCatChuyenDM"].Rows.Add(dr);
            }

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

            if (txtHieuLucKy_ThongKeDC.Text.Trim() != "")
            {
                rptDSCapDinhMuc rpt2 = new rptDSCapDinhMuc();
                rpt2.SetDataSource(dsBaoCao);
                frmShowBaoCao frm2 = new frmShowBaoCao(rpt2);
                frm2.Show();
            }
        }

        private void cmbQuan_ThongKeDC_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<PHUONG> lst = ((QUAN)cmbQuan_ThongKeDC.SelectedItem).PHUONGs.ToList();
            PHUONG phuong = new PHUONG();
            phuong.MAPHUONG = "0";
            phuong.TENPHUONG = "Tất Cả";
            lst.Insert(0, phuong);
            cmbPhuong_ThongKeDC.DataSource = lst;
            cmbPhuong_ThongKeDC.DisplayMember = "TenPhuong";
            cmbPhuong_ThongKeDC.ValueMember = "MaPhuong";
        }

        private void btnXuatExcel_DSDCBD_Click(object sender, EventArgs e)
        {
            DataTable dt = null;
            String strName = "";
            if (radBienDong.Checked)
            {
                strName = "DANH SÁCH ĐIỀU CHỈNH BIẾN ĐỘNG";
                dt = _cDCBD.getDS_BienDong_CreateDate(dateTu_DSDCBD.Value, dateDen_DSDCBD.Value);
            }
            else
            {
                strName = "DANH SÁCH ĐIỀU CHỈNH HÓA ĐƠN";
                dt = _cDCBD.getDS_HoaDon_CreateDate(dateTu_DSDCBD.Value, dateDen_DSDCBD.Value);
            }
            if (dt == null)
                return;
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

            oSheet.Name = strName;

            // Tạo phần đầu nếu muốn
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "F1");
            head.MergeCells = true;
            head.Value2 = strName;
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "20";
            head.RowHeight = 50;
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo phần đầu nếu muốn
            Microsoft.Office.Interop.Excel.Range head2 = oSheet.get_Range("A2", "F2");
            head2.MergeCells = true;
            head2.Value2 = "Từ Ngày " + dateTu_DSDCBD.Value.ToString("dd/MM/yyyy") + " Đến Ngày " + dateDen_DSDCBD.Value.ToString("dd/MM/yyyy");
            head2.Font.Bold = true;
            head2.Font.Name = "Times New Roman";
            head2.Font.Size = "20";
            head2.RowHeight = 50;
            head2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            object[,] arrHead = new object[1, dt.Columns.Count];
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                DataColumn dc = dt.Columns[i];

                arrHead[0, i] = dc.ColumnName;
            }
            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1Head = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[4, 1];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2Head = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[4, dt.Columns.Count];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range rangeHead = oSheet.get_Range(c1Head, c2Head);

            rangeHead.Value2 = arrHead;

            // Tạo tiêu đề cột 
            //Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A4", "A4");
            //cl1.Value2 = "Danh Bộ";
            //cl1.ColumnWidth = 15;

            //Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B4", "B4");
            //cl2.Value2 = "Khách Hàng";
            //cl2.ColumnWidth = 30;

            //Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C4", "C4");
            //cl3.Value2 = "Địa Chỉ";
            //cl3.ColumnWidth = 30;


            //Thiết lập vùng điền dữ liệu
            int columnStart = 1;
            int columnEnd = dt.Columns.Count;
            int rowStart = 5;
            int rowEnd = rowStart + dt.Rows.Count - 1;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[dt.Rows.Count, columnEnd];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    arr[i, j] = dr[j];
                }
            }

            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);
            range.NumberFormat = "@";
            //Microsoft.Office.Interop.Excel.Range c1a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 1];
            //Microsoft.Office.Interop.Excel.Range c2a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 1];
            //Microsoft.Office.Interop.Excel.Range c3a = oSheet.get_Range(c1a, c2a);
            //c3a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            //Microsoft.Office.Interop.Excel.Range c1b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 2];
            //Microsoft.Office.Interop.Excel.Range c2b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 2];
            //Microsoft.Office.Interop.Excel.Range c3b = oSheet.get_Range(c1b, c2b);
            //c3b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            //c3b.NumberFormat = "#,##0";

            //Microsoft.Office.Interop.Excel.Range c1c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 3];
            //Microsoft.Office.Interop.Excel.Range c2c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 3];
            //Microsoft.Office.Interop.Excel.Range c3c = oSheet.get_Range(c1c, c2c);
            //c3c.NumberFormat = "@";
            //c3c.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;
        }

        private void btnInDS_DSDCBD_Click(object sender, EventArgs e)
        {
            if (radHoaDon.Checked)
            {
                DataTable dt = _cDCBD.getDS_HoaDon_CreateDate(dateTu_DSDCBD.Value, dateDen_DSDCBD.Value);
                DataSetBaoCao dsBaoCao = new DataSetBaoCao();
                foreach (DataRow item in dt.Rows)
                {
                    DataRow dr = dsBaoCao.Tables["DCHD"].NewRow();
                    dr["TuNgay"] = dateTu_DSDCBD.Value.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = dateDen_DSDCBD.Value.ToString("dd/MM/yyyy");
                    dr["SoPhieu"] = item["ID"].ToString();
                    if (!string.IsNullOrEmpty(item["DanhBo"].ToString()))
                        dr["DanhBo"] = item["DanhBo"].ToString().Insert(7, " ").Insert(4, " "); ;
                    dr["GiaBieuStart"] = item["GiaBieu"].ToString();
                    dr["GiaBieuEnd"] = item["GiaBieu_BD"].ToString();
                    dr["DinhMucStart"] = item["DinhMuc"].ToString();
                    dr["DinhMucEnd"] = item["DinhMuc_BD"].ToString();
                    dr["TieuThuStart"] = item["TieuThu"].ToString();
                    dr["TieuThuEnd"] = item["TieuThu_BD"].ToString();
                    dr["TongCongStart"] = item["TongCong_Start"].ToString();
                    dr["TongCongEnd"] = item["TongCong_End"].ToString();
                    dr["TongCongBD"] = item["TongCong_BD"].ToString();
                    dr["TangGiam"] = item["TangGiam"].ToString();
                    dr["ThongTin"] = item["ThongTin"].ToString();
                    dr["LyDoDieuChinh"] = item["LyDoDieuChinh"].ToString();
                    dsBaoCao.Tables["DCHD"].Rows.Add(dr);
                }
                rptDSDCHD rpt = new rptDSDCHD();
                rpt.SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.ShowDialog();
            }
        }

        private void btnXuatExcel_ThongKeDMNT_Click(object sender, EventArgs e)
        {
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

            oSheet.Name = "Sheet1";

            // Tạo phần đầu nếu muốn
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "M1");
            head.MergeCells = true;
            head.Value2 = "TỔNG HỢP SỐ LIỆU CẤP ĐỊNH MỨC NƯỚC SINH HOẠT\r\nCHO ĐỐI TƯỢNG THUÊ NHÀ THEO CÔNG TY CP CN TÂN HÒA";
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "20";
            head.RowHeight = 60;
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            //

            oSheet.Columns[1].ColumnWidth = 10;
            Microsoft.Office.Interop.Excel.Range head1 = oSheet.get_Range("A3", "A6");
            head1.MergeCells = true;
            head1.Value2 = "Số liệu tính đến tháng";
            head1.Font.Bold = true;
            head1.Font.Name = "Times New Roman";
            head1.Font.Size = "12";
            head1.WrapText = true;
            head1.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            head1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            //

            oSheet.Columns[2].ColumnWidth = 12;
            Microsoft.Office.Interop.Excel.Range head2 = oSheet.get_Range("B3", "B6");
            head2.MergeCells = true;
            head2.Value2 = "QUẬN";
            head2.Font.Bold = true;
            head2.Font.Name = "Times New Roman";
            head2.Font.Size = "12";
            head2.WrapText = true;
            head2.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            head2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            //

            Microsoft.Office.Interop.Excel.Range head3 = oSheet.get_Range("C3", "E3");
            head3.MergeCells = true;
            head3.Value2 = "Số liệu lũy tiến kỳ trước";
            head3.Font.Bold = true;
            head3.Font.Name = "Times New Roman";
            head3.Font.Size = "12";
            head3.WrapText = true;
            head3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            head3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            oSheet.Columns[3].ColumnWidth = 10;
            Microsoft.Office.Interop.Excel.Range head3a = oSheet.get_Range("C4", "C5");
            head3a.MergeCells = true;
            head3a.Value2 = "Số lượng nhà trọ đã cấp định mức nước sinh hoạt";
            head3a.Font.Bold = true;
            head3a.Font.Name = "Times New Roman";
            head3a.Font.Size = "12";
            head3a.WrapText = true;
            head3a.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            head3a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range head3aa = oSheet.get_Range("C6", "C6");
            head3aa.MergeCells = true;
            head3aa.Value2 = "1";
            head3aa.Font.Italic = true;
            head3aa.Font.Name = "Times New Roman";
            head3aa.Font.Size = "12";
            head3aa.WrapText = true;
            head3aa.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            head3aa.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            oSheet.Columns[4].ColumnWidth = 10;
            Microsoft.Office.Interop.Excel.Range head3b = oSheet.get_Range("D4", "D5");
            head3b.MergeCells = true;
            head3b.Value2 = "Số lượng nhân khẩu đã cấp định mức nước sinh hoạt";
            head3b.Font.Bold = true;
            head3b.Font.Name = "Times New Roman";
            head3b.Font.Size = "12";
            head3b.WrapText = true;
            head3b.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            head3b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range head3bb = oSheet.get_Range("D6", "D6");
            head3bb.MergeCells = true;
            head3bb.Value2 = "2";
            head3bb.Font.Italic = true;
            head3bb.Font.Name = "Times New Roman";
            head3bb.Font.Size = "12";
            head3bb.WrapText = true;
            head3bb.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            head3bb.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            oSheet.Columns[5].ColumnWidth = 10;
            Microsoft.Office.Interop.Excel.Range head3c = oSheet.get_Range("E4", "E5");
            head3c.MergeCells = true;
            head3c.Value2 = "Lượng nước tiêu thụ bình quân trong kỳ";
            head3c.Font.Bold = true;
            head3c.Font.Name = "Times New Roman";
            head3c.Font.Size = "12";
            head3c.WrapText = true;
            head3c.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            head3c.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range head3cc = oSheet.get_Range("E6", "E6");
            head3cc.MergeCells = true;
            head3cc.Value2 = "3";
            head3cc.Font.Italic = true;
            head3cc.Font.Name = "Times New Roman";
            head3cc.Font.Size = "12";
            head3cc.WrapText = true;
            head3cc.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            head3cc.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            //

            Microsoft.Office.Interop.Excel.Range head4 = oSheet.get_Range("F3", "J3");
            head4.MergeCells = true;
            head4.Value2 = "Số liệu phát sinh trong kỳ";
            head4.Font.Bold = true;
            head4.Font.Name = "Times New Roman";
            head4.Font.Size = "12";
            head4.WrapText = true;
            head4.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            head4.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range head4a = oSheet.get_Range("F4", "G4");
            head4a.MergeCells = true;
            head4a.Value2 = "Số lượng nhà trọ đã cấp định mức nước sinh hoạt";
            head4a.Font.Bold = true;
            head4a.Font.Name = "Times New Roman";
            head4a.Font.Size = "12";
            head4a.WrapText = true;
            head4a.RowHeight = 100;
            head4a.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            head4a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range head4aa = oSheet.get_Range("F5", "F5");
            head4aa.MergeCells = true;
            head4aa.Value2 = "Tăng";
            head4aa.Font.Bold = true;
            head4aa.Font.Name = "Times New Roman";
            head4aa.Font.Size = "12";
            head4aa.WrapText = true;
            head4aa.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            head4aa.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range head4aaa = oSheet.get_Range("F6", "F6");
            head4aaa.MergeCells = true;
            head4aaa.Value2 = "4";
            head4aaa.Font.Italic = true;
            head4aaa.Font.Name = "Times New Roman";
            head4aaa.Font.Size = "12";
            head4aaa.WrapText = true;
            head4aaa.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            head4aaa.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range head4ab = oSheet.get_Range("G5", "G5");
            head4ab.MergeCells = true;
            head4ab.Value2 = "Giảm";
            head4ab.Font.Bold = true;
            head4ab.Font.Name = "Times New Roman";
            head4ab.Font.Size = "12";
            head4ab.WrapText = true;
            head4ab.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            head4ab.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range head4abb = oSheet.get_Range("G6", "G6");
            head4abb.MergeCells = true;
            head4abb.Value2 = "5";
            head4abb.Font.Italic = true;
            head4abb.Font.Name = "Times New Roman";
            head4abb.Font.Size = "12";
            head4abb.WrapText = true;
            head4abb.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            head4abb.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range head4b = oSheet.get_Range("H4", "I4");
            head4b.MergeCells = true;
            head4b.Value2 = "Số lượng nhân khẩu đã cấp định mức nước sinh hoạt";
            head4b.Font.Bold = true;
            head4b.Font.Name = "Times New Roman";
            head4b.Font.Size = "12";
            head4b.WrapText = true;
            head4b.RowHeight = 100;
            head4b.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            head4b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range head4ba = oSheet.get_Range("H5", "H5");
            head4ba.MergeCells = true;
            head4ba.Value2 = "Tăng";
            head4ba.Font.Bold = true;
            head4ba.Font.Name = "Times New Roman";
            head4ba.Font.Size = "12";
            head4ba.WrapText = true;
            head4ba.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            head4ba.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range head4baa = oSheet.get_Range("H6", "H6");
            head4baa.MergeCells = true;
            head4baa.Value2 = "6";
            head4baa.Font.Italic = true;
            head4baa.Font.Name = "Times New Roman";
            head4baa.Font.Size = "12";
            head4baa.WrapText = true;
            head4baa.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            head4baa.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range head4bb = oSheet.get_Range("I5", "I5");
            head4bb.MergeCells = true;
            head4bb.Value2 = "Giảm";
            head4bb.Font.Bold = true;
            head4bb.Font.Name = "Times New Roman";
            head4bb.Font.Size = "12";
            head4bb.WrapText = true;
            head4bb.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            head4bb.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range head4bbb = oSheet.get_Range("I6", "I6");
            head4bbb.MergeCells = true;
            head4bbb.Value2 = "7";
            head4bbb.Font.Italic = true;
            head4bbb.Font.Name = "Times New Roman";
            head4bbb.Font.Size = "12";
            head4bbb.WrapText = true;
            head4bbb.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            head4bbb.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range head4c = oSheet.get_Range("J4", "J5");
            head4c.MergeCells = true;
            head4c.Value2 = "Lượng nước tiêu thụ bình quân trong kỳ";
            head4c.Font.Bold = true;
            head4c.Font.Name = "Times New Roman";
            head4c.Font.Size = "12";
            head4c.WrapText = true;
            head4c.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            head4c.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range head4ca = oSheet.get_Range("J6", "J6");
            head4ca.MergeCells = true;
            head4ca.Value2 = "8";
            head4ca.Font.Italic = true;
            head4ca.Font.Name = "Times New Roman";
            head4ca.Font.Size = "12";
            head4ca.WrapText = true;
            head4ca.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            head4ca.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            //

            Microsoft.Office.Interop.Excel.Range head5 = oSheet.get_Range("K3", "M3");
            head5.MergeCells = true;
            head5.Value2 = "Số liệu lũy tiến đến kỳ hiện tại";
            head5.Font.Bold = true;
            head5.Font.Name = "Times New Roman";
            head5.Font.Size = "12";
            head5.WrapText = true;
            head5.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            head5.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            oSheet.Columns[11].ColumnWidth = 10;
            Microsoft.Office.Interop.Excel.Range head5a = oSheet.get_Range("K4", "K5");
            head5a.MergeCells = true;
            head5a.Value2 = "Số lượng nhà trọ đã cấp định mức nước sinh hoạt";
            head5a.Font.Bold = true;
            head5a.Font.Name = "Times New Roman";
            head5a.Font.Size = "12";
            head5a.WrapText = true;
            head5a.RowHeight = 40;
            head5a.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            head5a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range head5aa = oSheet.get_Range("K6", "K6");
            head5aa.MergeCells = true;
            head5aa.Value2 = "(9=1+4-5)";
            head5aa.Font.Italic = true;
            head5aa.Font.Name = "Times New Roman";
            head5aa.Font.Size = "12";
            head5aa.WrapText = true;
            head5aa.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            head5aa.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            oSheet.Columns[12].ColumnWidth = 10;
            Microsoft.Office.Interop.Excel.Range head5b = oSheet.get_Range("L4", "L5");
            head5b.MergeCells = true;
            head5b.Value2 = "Số lượng nhân khẩu đã cấp định mức nước sinh hoạt";
            head5b.Font.Bold = true;
            head5b.Font.Name = "Times New Roman";
            head5b.Font.Size = "12";
            head5b.WrapText = true;
            head5b.RowHeight = 40;
            head5b.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            head5b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range head5bb = oSheet.get_Range("L6", "L6");
            head5bb.MergeCells = true;
            head5bb.Value2 = "(10=2+6-7)";
            head5bb.Font.Italic = true;
            head5bb.Font.Name = "Times New Roman";
            head5bb.Font.Size = "12";
            head5bb.WrapText = true;
            head5bb.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            head5bb.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            oSheet.Columns[13].ColumnWidth = 10;
            Microsoft.Office.Interop.Excel.Range head5c = oSheet.get_Range("M4", "M5");
            head5c.MergeCells = true;
            head5c.Value2 = "Lượng nước tiêu thụ bình quân trong kỳ";
            head5c.Font.Bold = true;
            head5c.Font.Name = "Times New Roman";
            head5c.Font.Size = "12";
            head5c.WrapText = true;
            head5c.RowHeight = 40;
            head5c.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            head5c.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range head5cc = oSheet.get_Range("M6", "M6");
            head5cc.MergeCells = true;
            head5cc.Value2 = "(11=3+8)";
            head5cc.Font.Italic = true;
            head5cc.Font.Name = "Times New Roman";
            head5cc.Font.Size = "12";
            head5cc.WrapText = true;
            head5cc.VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            head5cc.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            DataTable dt = _cChungTu.getBaoCaoNhaTroGuiTong(dateTu_ThongKeDMNT.Value, dateDen_ThongKeDMNT.Value);
            DataTable dtExcel = new DataTable();
            DataColumn col = new DataColumn("Ky");
            col.DataType = System.Type.GetType("System.String");
            dtExcel.Columns.Add(col);

            col = new DataColumn("Quan");
            col.DataType = System.Type.GetType("System.String");
            dtExcel.Columns.Add(col);

            col = new DataColumn("SoLuongDCDau");
            col.DataType = System.Type.GetType("System.Int32");
            dtExcel.Columns.Add(col);

            col = new DataColumn("SoLuongNKDau");
            col.DataType = System.Type.GetType("System.Int32");
            dtExcel.Columns.Add(col);

            col = new DataColumn("SoLuongDMDau");
            col.DataType = System.Type.GetType("System.Int32");
            dtExcel.Columns.Add(col);

            col = new DataColumn("SoLuongDCTang");
            col.DataType = System.Type.GetType("System.Int32");
            dtExcel.Columns.Add(col);

            col = new DataColumn("SoLuongDCGiam");
            col.DataType = System.Type.GetType("System.Int32");
            dtExcel.Columns.Add(col);

            col = new DataColumn("SoLuongNKTang");
            col.DataType = System.Type.GetType("System.Int32");
            dtExcel.Columns.Add(col);

            col = new DataColumn("SoLuongDM");
            col.DataType = System.Type.GetType("System.Int32");
            dtExcel.Columns.Add(col);

            col = new DataColumn("SoLuongNKGiam");
            col.DataType = System.Type.GetType("System.Int32");
            dtExcel.Columns.Add(col);

            col = new DataColumn("SoLuongDCCuoi");
            col.DataType = System.Type.GetType("System.Int32");
            dtExcel.Columns.Add(col);

            col = new DataColumn("SoLuongNKCuoi");
            col.DataType = System.Type.GetType("System.Int32");
            dtExcel.Columns.Add(col);

            col = new DataColumn("SoLuongDMCuoi");
            col.DataType = System.Type.GetType("System.Int32");
            dtExcel.Columns.Add(col);

            foreach (DataRow item in dt.Rows)
            {
                string Ky = "";
                DateTime date = DateTime.Parse(item["CreateDate"].ToString());
                if (date.Date < dateTu_ThongKeDMNT.Value.Date)
                    Ky = "12/" + dateTu_ThongKeDMNT.Value.Year;
                else
                if (date.Month == 12)
                {
                    //if (date.Day <= 20)
                    //    Ky = date.Month.ToString("00") + "/" + date.Year;
                    //else
                        Ky = "01/" + (date.Year + 1);
                }
                else
                {
                    if (date.Day <= 20)
                        Ky = date.Month.ToString("00") + "/" + date.Year;
                    else
                        Ky = (date.Month + 1).ToString("00") + "/" + date.Year;
                }
                bool exists = false;
                for (int i = 0; i < dtExcel.Rows.Count; i++)
                    if (dtExcel.Rows[i]["Ky"].ToString() == Ky && dtExcel.Rows[i]["Quan"].ToString() == item["Quan"].ToString())
                    {
                        exists = true;
                        int DinhMuc = 0, DinhMucBD = 0;
                        if (item["DinhMuc"].ToString() != "")
                            DinhMuc = int.Parse(item["DinhMuc"].ToString());
                        if (item["DinhMuc_BD"].ToString() != "")
                            DinhMucBD = int.Parse(item["DinhMuc_BD"].ToString());
                        if (DinhMuc > DinhMucBD)
                        {
                            dtExcel.Rows[i]["SoLuongDCGiam"] = int.Parse(dtExcel.Rows[i]["SoLuongDCGiam"].ToString()) + 1;
                            dtExcel.Rows[i]["SoLuongNKGiam"] = int.Parse(dtExcel.Rows[i]["SoLuongNKGiam"].ToString()) + ((DinhMuc - DinhMucBD) / 4);
                        }
                        else
                            if (DinhMuc < DinhMucBD)
                            {
                                dtExcel.Rows[i]["SoLuongDCTang"] = int.Parse(dtExcel.Rows[i]["SoLuongDCTang"].ToString()) + 1;
                                dtExcel.Rows[i]["SoLuongNKTang"] = int.Parse(dtExcel.Rows[i]["SoLuongNKTang"].ToString()) + ((DinhMucBD - DinhMuc) / 4);
                            }
                    }
                if (exists == false)
                {
                    DataRow row = dtExcel.NewRow();
                    row["Ky"] = Ky;
                    row["Quan"] = item["Quan"];
                    int DinhMuc = 0, DinhMucBD = 0;
                    if (item["DinhMuc"].ToString() != "")
                        DinhMuc = int.Parse(item["DinhMuc"].ToString());
                    if (item["DinhMuc_BD"].ToString() != "")
                        DinhMucBD = int.Parse(item["DinhMuc_BD"].ToString());
                    if (DinhMuc > DinhMucBD)
                    {
                        row["SoLuongDCDau"] = 0;
                        row["SoLuongNKDau"] = 0;
                        row["SoLuongDMDau"] = 0;

                        row["SoLuongDCTang"] = 0;
                        row["SoLuongNKTang"] = 0;
                        row["SoLuongDCGiam"] = 1;
                        row["SoLuongNKGiam"] = (DinhMuc - DinhMucBD) / 4;
                        row["SoLuongDM"] = 0;

                        row["SoLuongDCCuoi"] = 0;
                        row["SoLuongNKCuoi"] = 0;
                        row["SoLuongDMCuoi"] = 0;
                    }
                    else
                        if (DinhMuc < DinhMucBD)
                        {
                            row["SoLuongDCDau"] = 0;
                            row["SoLuongNKDau"] = 0;
                            row["SoLuongDMDau"] = 0;

                            row["SoLuongDCTang"] = 1;
                            row["SoLuongNKTang"] = (DinhMucBD - DinhMuc) / 4;
                            row["SoLuongDCGiam"] = 0;
                            row["SoLuongNKGiam"] = 0;
                            row["SoLuongDM"] = 0;

                            row["SoLuongDCCuoi"] = 0;
                            row["SoLuongNKCuoi"] = 0;
                            row["SoLuongDMCuoi"] = 0;
                        }
                        else
                        {
                            row["SoLuongDCDau"] = 0;
                            row["SoLuongNKDau"] = 0;
                            row["SoLuongDMDau"] = 0;

                            row["SoLuongDCTang"] = 0;
                            row["SoLuongNKTang"] = 0;
                            row["SoLuongDCGiam"] = 0;
                            row["SoLuongNKGiam"] = 0;
                            row["SoLuongDM"] = 0;

                            row["SoLuongDCCuoi"] = 0;
                            row["SoLuongNKCuoi"] = 0;
                            row["SoLuongDMCuoi"] = 0;
                        }
                    dtExcel.Rows.Add(row);
                }
            }

            for (int i = 0; i < dtExcel.Rows.Count; i++)
            {
                dtExcel.Rows[i]["SoLuongDM"] = (int.Parse(dtExcel.Rows[i]["SoLuongNKTang"].ToString()) - int.Parse(dtExcel.Rows[i]["SoLuongNKGiam"].ToString())) * 4;

                dtExcel.Rows[i]["SoLuongDCCuoi"] = int.Parse(dtExcel.Rows[i]["SoLuongDCDau"].ToString()) + int.Parse(dtExcel.Rows[i]["SoLuongDCTang"].ToString()) - int.Parse(dtExcel.Rows[i]["SoLuongDCGiam"].ToString());
                dtExcel.Rows[i]["SoLuongNKCuoi"] = int.Parse(dtExcel.Rows[i]["SoLuongNKDau"].ToString()) + int.Parse(dtExcel.Rows[i]["SoLuongNKTang"].ToString()) - int.Parse(dtExcel.Rows[i]["SoLuongNKGiam"].ToString());
                dtExcel.Rows[i]["SoLuongDMCuoi"] = int.Parse(dtExcel.Rows[i]["SoLuongDMDau"].ToString()) + int.Parse(dtExcel.Rows[i]["SoLuongDM"].ToString());

                string[] Kys = dtExcel.Rows[i]["Ky"].ToString().Split('/');
                for (int j = i + 1; j < dtExcel.Rows.Count; j++)
                {
                    int Ky = 0, Nam = 0;
                    if (int.Parse(Kys[0]) == 12 && int.Parse(Kys[1]) == dateDen_ThongKeDMNT.Value.Year - 1)
                    {
                        Ky = 1;
                        Nam = int.Parse(Kys[1]) + 1;
                    }
                    else
                    {
                        Ky = int.Parse(Kys[0]) + 1;
                        Nam = dateDen_ThongKeDMNT.Value.Year;
                    }
                    if (dtExcel.Rows[j]["Ky"].ToString() == Ky.ToString("00") + "/" + Nam && dtExcel.Rows[i]["Quan"].ToString() == dtExcel.Rows[j]["Quan"].ToString())
                    {
                        dtExcel.Rows[j]["SoLuongDCDau"] = dtExcel.Rows[i]["SoLuongDCCuoi"];
                        dtExcel.Rows[j]["SoLuongNKDau"] = dtExcel.Rows[i]["SoLuongNKCuoi"];
                        dtExcel.Rows[j]["SoLuongDMDau"] = dtExcel.Rows[i]["SoLuongDMCuoi"];
                    }
                }
            }
            //xóa dòng đầu kỳ 12 nằm trước
            for (int i = dtExcel.Rows.Count - 1; i >= 0; i--)
            {
                string Ky = "12/" + (dateDen_ThongKeDMNT.Value.Year - 1);
                if (dtExcel.Rows[i]["Ky"].ToString() == Ky)
                    dtExcel.Rows.RemoveAt(i);
            }

            //Thiết lập vùng điền dữ liệu
            int columnStart = 1;
            int columnEnd = dtExcel.Columns.Count;
            int rowStart = 7;
            int rowEnd = rowStart + dtExcel.Rows.Count - 1;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[dtExcel.Rows.Count, columnEnd];

            string Temp = "";
            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int i = 0; i < dtExcel.Rows.Count; i++)
            {
                DataRow dr = dtExcel.Rows[i];
                if (Temp != dr["Ky"].ToString())
                {
                    Temp = dr["Ky"].ToString();
                    arr[i, 0] = dr["Ky"].ToString();
                }
                arr[i, 1] = dr["Quan"].ToString();
                arr[i, 2] = dr["SoLuongDCDau"].ToString();
                arr[i, 3] = dr["SoLuongNKDau"].ToString();
                arr[i, 4] = dr["SoLuongDMDau"].ToString();
                arr[i, 5] = dr["SoLuongDCTang"].ToString();
                arr[i, 6] = dr["SoLuongDCGiam"].ToString();
                arr[i, 7] = dr["SoLuongNKTang"].ToString();
                arr[i, 8] = dr["SoLuongNKGiam"].ToString();
                arr[i, 9] = dr["SoLuongDM"].ToString();
                arr[i, 10] = dr["SoLuongDCCuoi"].ToString();
                arr[i, 11] = dr["SoLuongNKCuoi"].ToString();
                arr[i, 12] = dr["SoLuongDMCuoi"].ToString();
            }

            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);
            range.NumberFormat = "@";
            //Microsoft.Office.Interop.Excel.Range c1a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 1];
            //Microsoft.Office.Interop.Excel.Range c2a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 1];
            //Microsoft.Office.Interop.Excel.Range c3a = oSheet.get_Range(c1a, c2a);
            //c3a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            //Microsoft.Office.Interop.Excel.Range c1b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 2];
            //Microsoft.Office.Interop.Excel.Range c2b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 2];
            //Microsoft.Office.Interop.Excel.Range c3b = oSheet.get_Range(c1b, c2b);
            //c3b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
            //c3b.NumberFormat = "#,##0";

            //Microsoft.Office.Interop.Excel.Range c1c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 3];
            //Microsoft.Office.Interop.Excel.Range c2c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 3];
            //Microsoft.Office.Interop.Excel.Range c3c = oSheet.get_Range(c1c, c2c);
            //c3c.NumberFormat = "@";
            //c3c.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;

            oSheet.Cells[rowEnd + 2, 5].Font.Bold = true;
            oSheet.Cells[rowEnd + 2, 5].Font.Name = "Times New Roman";
            oSheet.Cells[rowEnd + 2, 5].Font.Size = "13";
            oSheet.Cells[rowEnd + 2, 5] = "PHÓ GIÁM ĐỐC KINH DOANH";

            oSheet.Cells[rowEnd + 2, 11].Font.Bold = true;
            oSheet.Cells[rowEnd + 2, 11].Font.Name = "Times New Roman";
            oSheet.Cells[rowEnd + 2, 11].Font.Size = "13";
            oSheet.Cells[rowEnd + 2, 11] = "TRƯỞNG PHÒNG";

            oSheet.Cells[rowEnd + 4, 1].Font.Italic = true;
            oSheet.Cells[rowEnd + 4, 1].Font.Underline = true;
            oSheet.Cells[rowEnd + 4, 1].Font.Name = "Times New Roman";
            oSheet.Cells[rowEnd + 4, 1].Font.Size = "11";
            oSheet.Cells[rowEnd + 4, 1] = "Nơi nhận:";

            oSheet.Cells[rowEnd + 5, 1].Font.Name = "Times New Roman";
            oSheet.Cells[rowEnd + 5, 1].Font.Size = "11";
            oSheet.Cells[rowEnd + 5, 1] = " - P. KDDVKH - Tổng Cty";

            oSheet.Cells[rowEnd + 6, 1].Font.Name = "Times New Roman";
            oSheet.Cells[rowEnd + 6, 1].Font.Size = "11";
            oSheet.Cells[rowEnd + 6, 1] = " - Lưu.";
        }


    }
}
