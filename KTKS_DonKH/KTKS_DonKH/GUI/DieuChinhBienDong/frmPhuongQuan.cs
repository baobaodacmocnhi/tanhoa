using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.DieuChinhBienDong;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmPhuongQuan : Form
    {
        CDocSo _cDocSo = new CDocSo();
        CChungTu _cChungTu = new CChungTu();
        CDCBD _cDCBD = new CDCBD();
        DataTable _dt = new DataTable();
        string _TuNgay="", _DenNgay="";
        DateTime _dateTuNgay, _dateDenNgay;

        public frmPhuongQuan()
        {
            InitializeComponent();
        }

        public frmPhuongQuan(DateTime TuNgay)
        {
            InitializeComponent();
            _dateTuNgay = TuNgay;
            _TuNgay = TuNgay.ToString("dd/MM/yyyy");  
        }

        public frmPhuongQuan(DateTime TuNgay, DateTime DenNgay)
        {
            InitializeComponent();
            _dateTuNgay = TuNgay;
            _dateDenNgay = DenNgay;
            _TuNgay = TuNgay.ToString("dd/MM/yyyy");
            _DenNgay = DenNgay.ToString("dd/MM/yyyy");   
        }

        private void frmPhuongQuan_Load(object sender, EventArgs e)
        {
            this.Location = new Point(200,200);
            List<QUAN> lst = _cDocSo.GetDSQuan();
            QUAN quan = new QUAN();
            quan.MAQUAN = 0;
            quan.TENQUAN = "Tất Cả";
            lst.Insert(0, quan);
            cmbQuan.DataSource = lst;
            cmbQuan.DisplayMember = "TenQuan";
            cmbQuan.ValueMember = "MaQuan";
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

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            if (chkKhongThoiHan.Checked)
            {
                if (!string.IsNullOrEmpty(_DenNgay))
                    _dt = _cChungTu.LoadDSCapDinhMucKhongThoiHan(_dateTuNgay, _dateDenNgay);
                else
                    _dt = _cChungTu.LoadDSCapDinhMucKhongThoiHan(_dateTuNgay);
            }
            else
            {
                if(!string.IsNullOrEmpty(_DenNgay))
                    _dt = _cChungTu.LoadDSCapDinhMuc(_dateTuNgay, _dateDenNgay);
                else
                    _dt = _cChungTu.LoadDSCapDinhMuc(_dateTuNgay);
            }

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataRow itemRow in _dt.Rows)
            {
                    if (cmbQuan.SelectedValue.ToString() == "0")
                    {
                        DataRow dr = dsBaoCao.Tables["DSCapDinhMuc"].NewRow();

                        dr["TuNgay"] = _TuNgay;
                        dr["DenNgay"] = _DenNgay;
                        if (_cDCBD.checkExist_BienDong(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())))
                        {
                            string a = _cDCBD.getBienDong(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())).ToString();
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

                                dr["TuNgay"] = _TuNgay;
                                dr["DenNgay"] = _DenNgay;
                                if (_cDCBD.checkExist_BienDong(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())))
                                {
                                    string a = _cDCBD.getBienDong(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())).ToString();
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

                                dr["TuNgay"] = _TuNgay;
                                dr["DenNgay"] = _DenNgay;
                                if (_cDCBD.checkExist_BienDong(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())))
                                {
                                    string a = _cDCBD.getBienDong(itemRow["DanhBo"].ToString(), DateTime.Parse(itemRow["CreateDate"].ToString())).ToString();
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

            rptDSCapDinhMuc rpt = new rptDSCapDinhMuc();
            rpt.SetDataSource(dsBaoCao);
            rpt.Subreports[0].SetDataSource(dsBaoCao);
            //crystalReportViewer1.ReportSource = rpt;  
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }
    }
}
