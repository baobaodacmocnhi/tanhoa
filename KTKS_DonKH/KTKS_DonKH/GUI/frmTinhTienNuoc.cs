using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.DAL;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI
{
    public partial class frmTinhTienNuoc : Form
    {
        CThuTien _cThuTien = new CThuTien();
        CGiaNuoc _cGiaNuoc = new CGiaNuoc();
        CDocSo _cDocSo = new CDocSo();
        HOADON _hoadon = null;
        DocSo _docso = null;

        public frmTinhTienNuoc()
        {
            InitializeComponent();
        }

        private void frmTinhTienNuoc_Load(object sender, EventArgs e)
        {
            cmbKy.SelectedItem = DateTime.Now.Month.ToString();
            txtNam.Text = DateTime.Now.Year.ToString();
        }

        public void Clear()
        {
            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;
            txtGiaBieu.Text = "0";
            txtSH.Text = "0";
            txtSX.Text = "0";
            txtDV.Text = "0";
            txtHCSN.Text = "0";
            txtDinhMucHN.Text = "0";
            txtDinhMuc.Text = "0";
            txtTieuThu.Text = "0";
            //
            txtTongSoNgay.Text = "0";
            txtSoNgayCu.Text = "0";
            txtSoNgayMoi.Text = "0";
            txtDinhMucCu.Text = "0";
            txtDinhMucMoi.Text = "0";
            txtDinhMucHNCu.Text = "0";
            txtDinhMucHNMoi.Text = "0";
            txtTieuThuCu.Text = "0";
            txtTieuThuMoi.Text = "0";
            //
            txtChiTietCu.Text = "";
            txtChiTietMoi.Text = "";
            txtGiaBanCu.Text = "0";
            txtGiaBanMoi.Text = "0";
            txtGiaBan.Text = "0";
            txtThueGTGT.Text = "0";
            txtTDVTNCu.Text = "0";
            txtTongCong.Text = "0";
        }

        public void LoadTTKH()
        {
            if (txtDanhBo.Text.Trim() != "" && txtNam.Text.Trim() != "")
            {
                Clear();
                _hoadon = _cThuTien.Get(txtDanhBo.Text.Trim().Replace(" ", ""), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtNam.Text.Trim()));
                if (_hoadon != null)
                {
                    dateTu.Value = _hoadon.TUNGAY.Value;
                    dateDen.Value = _hoadon.DENNGAY.Value;
                    txtGiaBieu.Text = _hoadon.GB.ToString();
                    if (_hoadon.TILESH != null)
                        txtSH.Text = _hoadon.TILESH.Value.ToString();
                    if (_hoadon.TILESX != null)
                        txtSX.Text = _hoadon.TILESX.Value.ToString();
                    if (_hoadon.TILEDV != null)
                        txtDV.Text = _hoadon.TILEDV.Value.ToString();
                    if (_hoadon.TILEHCSN != null)
                        txtHCSN.Text = _hoadon.TILEHCSN.Value.ToString();
                    if (_hoadon.DinhMucHN != null)
                        txtDinhMucHN.Text = _hoadon.DinhMucHN.Value.ToString();
                    else
                        txtDinhMucHN.Text = "0";
                    if (_hoadon.DM != null)
                        txtDinhMuc.Text = _hoadon.DM.Value.ToString();
                    else
                        txtDinhMuc.Text = "0";
                    txtTieuThu.Text = _hoadon.TIEUTHU.Value.ToString();
                }
                else
                {
                    _docso = _cDocSo.get(txtDanhBo.Text.Trim(), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtNam.Text.Trim()));
                    if (_docso != null)
                    {
                        int Ky = 0, Nam = 0;
                        if (int.Parse(cmbKy.SelectedItem.ToString()) == 1)
                        {
                            Ky = 12;
                            Nam = int.Parse(txtNam.Text.Trim()) - 1;
                        }
                        else
                        {
                            Ky = int.Parse(cmbKy.SelectedItem.ToString()) - 1;
                            Nam = int.Parse(txtNam.Text.Trim());
                        }
                        _hoadon = _cThuTien.Get(txtDanhBo.Text.Trim(), Ky, Nam);
                        dateTu.Value = _docso.TuNgay.Value;
                        dateDen.Value = _docso.DenNgay.Value;
                        txtGiaBieu.Text = _docso.GB;
                        if (_hoadon.TILESH != null)
                            txtSH.Text = _hoadon.TILESH.Value.ToString();
                        if (_hoadon.TILESX != null)
                            txtSX.Text = _hoadon.TILESX.Value.ToString();
                        if (_hoadon.TILEDV != null)
                            txtDV.Text = _hoadon.TILEDV.Value.ToString();
                        if (_hoadon.TILEHCSN != null)
                            txtHCSN.Text = _hoadon.TILEHCSN.Value.ToString();
                        //if (_hoadon.DinhMucHN != null)
                        //    txtDinhMucHN.Text = _hoadon.DinhMucHN.Value.ToString();
                        //else
                        //    txtDinhMucHN.Text = "0";
                        txtDinhMuc.Text = _docso.DM;
                        txtTieuThu.Text = _docso.TieuThuMoi.Value.ToString();
                    }
                }
                btnTinhTienNuoc.PerformClick();
            }
        }

        private void btnTinhTienNuoc_Click(object sender, EventArgs e)
        {
            DataTable dtGiaNuoc = _cGiaNuoc.getDS();
            //check giảm giá
            _cGiaNuoc.checkExists_GiamGiaNuoc(int.Parse(txtNam.Text.Trim()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtGiaBieu.Text.Trim()), ref dtGiaNuoc);

            int index = -1;
            for (int i = 0; i < dtGiaNuoc.Rows.Count; i++)
                if (dateTu.Value.Date < DateTime.Parse(dtGiaNuoc.Rows[i]["NgayTangGia"].ToString()).Date && DateTime.Parse(dtGiaNuoc.Rows[i]["NgayTangGia"].ToString()).Date < dateDen.Value.Date)
                {
                    index = i;
                }
                else
                    if (dateTu.Value.Date >= DateTime.Parse(dtGiaNuoc.Rows[i]["NgayTangGia"].ToString()).Date)
                    {
                        index = i;
                    }
            if (index != -1)
            {
                if (dateDen.Value.Date < new DateTime(2019, 11, 15))
                {
                }
                else
                    if (dateTu.Value.Date < DateTime.Parse(dtGiaNuoc.Rows[index]["NgayTangGia"].ToString()).Date && DateTime.Parse(dtGiaNuoc.Rows[index]["NgayTangGia"].ToString()).Date < dateDen.Value.Date)
                    {
                        //int TieuThu_DieuChinhGia;
                        int TongSoNgay = (int)((dateDen.Value.Date - dateTu.Value.Date).TotalDays);

                        int SoNgayCu = (int)((DateTime.Parse(dtGiaNuoc.Rows[index]["NgayTangGia"].ToString()).Date - dateTu.Value.Date).TotalDays);
                        int TieuThuCu = (int)Math.Round(double.Parse(txtTieuThu.Text.Trim()) * SoNgayCu / TongSoNgay, 0, MidpointRounding.AwayFromZero);
                        int TieuThuMoi = int.Parse(txtTieuThu.Text.Trim()) - TieuThuCu;
                        int TongDinhMucCu = (int)Math.Round(double.Parse(txtDinhMuc.Text.Trim()) * SoNgayCu / TongSoNgay, 0, MidpointRounding.AwayFromZero);
                        int TongDinhMucMoi = int.Parse(txtDinhMuc.Text.Trim()) - TongDinhMucCu;
                        int DinhMucHN_Cu = 0, DinhMucHN_Moi = 0;
                        if (dateTu.Value.Date > new DateTime(2019, 11, 15))
                            if (TongDinhMucCu != 0 && int.Parse(txtDinhMucHN.Text.Trim()) != 0 && int.Parse(txtDinhMuc.Text.Trim()) != 0)
                                DinhMucHN_Cu = (int)Math.Round((double)TongDinhMucCu * int.Parse(txtDinhMucHN.Text.Trim()) / int.Parse(txtDinhMuc.Text.Trim()), 0, MidpointRounding.AwayFromZero);
                        if (TongDinhMucMoi != 0 && int.Parse(txtDinhMucHN.Text.Trim()) != 0 && int.Parse(txtDinhMuc.Text.Trim()) != 0)
                            DinhMucHN_Moi = (int)Math.Round((double)TongDinhMucMoi * int.Parse(txtDinhMucHN.Text.Trim()) / int.Parse(txtDinhMuc.Text.Trim()), 0, MidpointRounding.AwayFromZero);

                        txtTongSoNgay.Text = TongSoNgay.ToString();
                        txtSoNgayCu.Text = SoNgayCu.ToString();
                        txtSoNgayMoi.Text = (TongSoNgay - SoNgayCu).ToString();
                        txtDinhMucCu.Text = TongDinhMucCu.ToString();
                        txtDinhMucMoi.Text = TongDinhMucMoi.ToString();
                        txtDinhMucHNCu.Text = DinhMucHN_Cu.ToString();
                        txtDinhMucHNMoi.Text = DinhMucHN_Moi.ToString();
                        txtTieuThuCu.Text = TieuThuCu.ToString();
                        txtTieuThuMoi.Text = TieuThuMoi.ToString();
                    }
                    else
                    {
                    }
            }
            else
            {
            }

            int TienNuocNamCu = 0, TienNuocNamMoi = 0, TienNuoc = 0, ThueGTGT = 0, TDVTNNamCu = 0, TDVTNNamMoi = 0, TDVTN = 0, ThueTDVTN = 0, TongCong = 0, TieuThu_DieuChinhGia = 0;
            string ChiTietNamCu = "", ChiTietNamMoi = "", ChiTietPhiBVMTNamCu = "", ChiTietPhiBVMTNamMoi = "";
            _cGiaNuoc.TinhTienNuoc(false, false, false, 0, txtDanhBo.Text.Trim(), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtNam.Text.Trim()), dateTu.Value, dateDen.Value, int.Parse(txtGiaBieu.Text.Trim()), int.Parse(txtSH.Text.Trim()), int.Parse(txtSX.Text.Trim()), int.Parse(txtDV.Text.Trim()), int.Parse(txtHCSN.Text.Trim()), int.Parse(txtDinhMuc.Text.Trim()), int.Parse(txtDinhMucHN.Text.Trim()), int.Parse(txtTieuThu.Text.Trim()), out TienNuocNamCu, out ChiTietNamCu, out TienNuocNamMoi, out ChiTietNamMoi, out TieuThu_DieuChinhGia, out  TDVTNNamCu, out  ChiTietPhiBVMTNamCu, out  TDVTNNamMoi, out ChiTietPhiBVMTNamMoi, out TienNuoc, out ThueGTGT, out TDVTN, out ThueTDVTN);
            //ThueGTGT = (int)Math.Round((double)(TienNuocNamCu + TienNuocNamMoi) * 5 / 100, 0, MidpointRounding.AwayFromZero);
            TongCong = TienNuoc + ThueGTGT + TDVTN + ThueTDVTN;

            txtGiaBanCu.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TienNuocNamCu);
            txtGiaBanMoi.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TienNuocNamMoi);
            txtGiaBan.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TienNuoc);

            txtThueGTGT.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ThueGTGT);

            txtTDVTNCu.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TDVTNNamCu);
            txtTDVTNMoi.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TDVTNNamMoi);
            txtTDVTN.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TDVTN);

            txtChiTietCu.Text = ChiTietNamCu;
            txtChiTietTDVTNCu.Text = ChiTietPhiBVMTNamCu;
            txtChiTietMoi.Text = ChiTietNamMoi;
            txtChiTietTDVTNMoi.Text = ChiTietPhiBVMTNamMoi;
            ////Từ 2022 Phí BVMT -> Tiền Dịch Vụ Thoát Nước
            //if ((dateTu.Value.Year < 2021) || (dateTu.Value.Year == 2021 && dateDen.Value.Year == 2021))
            //{
            //    TongCong = (TienNuocNamCu + TienNuocNamMoi) + ThueGTGT + (TDVTNNamCu + TDVTNNamMoi);
            //}
            //else
            //    if (dateTu.Value.Year == 2021 && dateDen.Value.Year == 2022)
            //    {
            //        ThueTDVTN = (int)Math.Round((double)TDVTNNamMoi * 10 / 100, 0, MidpointRounding.AwayFromZero);
            //        TongCong = (TienNuocNamCu + TienNuocNamMoi) + ThueGTGT + (TDVTNNamCu + TDVTNNamMoi) + ThueTDVTN;
            //    }
            //    else
            //        if (dateTu.Value.Year >= 2022)
            //        {
            //            ThueTDVTN = (int)Math.Round((double)(TDVTNNamCu + TDVTNNamMoi) * 10 / 100, 0, MidpointRounding.AwayFromZero);
            //            TongCong = (TienNuocNamCu + TienNuocNamMoi) + ThueGTGT + (TDVTNNamCu + TDVTNNamMoi) + ThueTDVTN;
            //        }
            txtThueGTGTTDVTN.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ThueTDVTN);
            txtTongCong.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                LoadTTKH();
            }
        }

        private void cmbKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTTKH();
        }

        private void txtNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                LoadTTKH();
            }
        }

        private void btnTinhTienNuoc_TheoSoNgay_Click(object sender, EventArgs e)
        {
            List<GiaNuoc2> lst = _cGiaNuoc.getList();
            int index = -1;
            for (int i = 0; i < lst.Count; i++)
                if (dateTu.Value.Date < lst[i].NgayTangGia.Value.Date && lst[i].NgayTangGia.Value.Date < dateDen.Value.Date)
                {
                    index = i;
                }
                else
                    if (dateTu.Value.Date >= lst[i].NgayTangGia.Value.Date)
                    {
                        index = i;
                    }
            if (index != -1)
            {
                if (dateDen.Value.Date < new DateTime(2019, 11, 15))
                {
                }
                else
                    if (dateTu.Value.Date < lst[index].NgayTangGia.Value.Date && lst[index].NgayTangGia.Value.Date < dateDen.Value.Date)
                    {
                        //int TieuThu_DieuChinhGia;

                    }
                    else
                    {
                    }
            }
            else
            {
            }
            int TongSoNgay = (int)((dateDen.Value.Date - dateTu.Value.Date).TotalDays);

            int SoNgayCu = int.Parse(txtSoNgayCu.Text.Trim());
            int TieuThuCu = (int)Math.Round(double.Parse(txtTieuThu.Text.Trim()) * SoNgayCu / TongSoNgay, 0, MidpointRounding.AwayFromZero);
            int TieuThuMoi = int.Parse(txtTieuThu.Text.Trim()) - TieuThuCu;
            int TongDinhMucCu = (int)Math.Round(double.Parse(txtDinhMuc.Text.Trim()) * SoNgayCu / TongSoNgay, 0, MidpointRounding.AwayFromZero);
            int TongDinhMucMoi = int.Parse(txtDinhMuc.Text.Trim()) - TongDinhMucCu;
            int DinhMucHN_Cu = 0, DinhMucHN_Moi = 0;
            if (dateTu.Value.Date > new DateTime(2019, 11, 15))
                if (TongDinhMucCu != 0 && int.Parse(txtDinhMucHN.Text.Trim()) != 0 && int.Parse(txtDinhMuc.Text.Trim()) != 0)
                    DinhMucHN_Cu = (int)Math.Round((double)TongDinhMucCu * int.Parse(txtDinhMucHN.Text.Trim()) / int.Parse(txtDinhMuc.Text.Trim()), 0, MidpointRounding.AwayFromZero);
            if (TongDinhMucMoi != 0 && int.Parse(txtDinhMucHN.Text.Trim()) != 0 && int.Parse(txtDinhMuc.Text.Trim()) != 0)
                DinhMucHN_Moi = (int)Math.Round((double)TongDinhMucMoi * int.Parse(txtDinhMucHN.Text.Trim()) / int.Parse(txtDinhMuc.Text.Trim()), 0, MidpointRounding.AwayFromZero);

            txtTongSoNgay.Text = TongSoNgay.ToString();
            txtSoNgayCu.Text = SoNgayCu.ToString();
            txtSoNgayMoi.Text = (TongSoNgay - SoNgayCu).ToString();
            txtDinhMucCu.Text = TongDinhMucCu.ToString();
            txtDinhMucMoi.Text = TongDinhMucMoi.ToString();
            txtDinhMucHNCu.Text = DinhMucHN_Cu.ToString();
            txtDinhMucHNMoi.Text = DinhMucHN_Moi.ToString();
            txtTieuThuCu.Text = TieuThuCu.ToString();
            txtTieuThuMoi.Text = TieuThuMoi.ToString();

            int GiaBanNamCu = 0, GiaBanNamMoi = 0, TienNuoc = 0, ThueGTGT = 0, PhiBVMTNamCu = 0, PhiBVMTNamMoi = 0, TDVTN = 0, ThueTDVTN = 0, TongCong = 0, TieuThu_DieuChinhGia = 0;
            string ChiTietNamCu, ChiTietNamMoi, ChiTietPhiBVMTNamCu, ChiTietPhiBVMTNamMoi;
            _cGiaNuoc.TinhTienNuoc_TheoSoNgay(false, false, false, 0, txtDanhBo.Text.Trim(), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtNam.Text.Trim()), dateTu.Value, dateDen.Value, int.Parse(txtSoNgayCu.Text.Trim()), int.Parse(txtGiaBieu.Text.Trim()), int.Parse(txtSH.Text.Trim()), int.Parse(txtSX.Text.Trim()), int.Parse(txtDV.Text.Trim()), int.Parse(txtHCSN.Text.Trim()), int.Parse(txtDinhMuc.Text.Trim()), int.Parse(txtDinhMucHN.Text.Trim()), int.Parse(txtTieuThu.Text.Trim()), out GiaBanNamCu, out ChiTietNamCu, out GiaBanNamMoi, out ChiTietNamMoi, out TieuThu_DieuChinhGia, out  PhiBVMTNamCu, out  ChiTietPhiBVMTNamCu, out  PhiBVMTNamMoi, out ChiTietPhiBVMTNamMoi, out TienNuoc, out ThueGTGT, out TDVTN, out ThueTDVTN);
            //ThueGTGT = (int)Math.Round((double)(GiaBanNamCu + GiaBanNamMoi) * 5 / 100, 0, MidpointRounding.AwayFromZero);
            //TDVTN = (PhiBVMTNamCu + PhiBVMTNamMoi);
            TongCong = TienNuoc + ThueGTGT + TDVTN + ThueTDVTN;
            txtGiaBanCu.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaBanNamCu);
            txtGiaBanMoi.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", GiaBanNamMoi);
            txtGiaBan.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TienNuoc);
            txtThueGTGT.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", ThueGTGT);
            txtTDVTNCu.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TDVTN);
            txtTongCong.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            txtChiTietCu.Text = ChiTietNamCu;
            txtChiTietMoi.Text = ChiTietNamMoi;
        }


    }
}
