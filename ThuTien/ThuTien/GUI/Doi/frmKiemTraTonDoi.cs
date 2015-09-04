using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.Doi;
using ThuTien.LinQ;
using System.Globalization;
using ThuTien.BaoCao;
using KTKS_DonKH.GUI.BaoCao;
using ThuTien.DAL.TongHop;
using ThuTien.DAL.Quay;
using ThuTien.DAL.DongNuoc;
using ThuTien.DAL.ChuyenKhoan;

namespace ThuTien.GUI.Doi
{
    public partial class frmKiemTraTonDoi : Form
    {
        CTo _cTo = new CTo();
        CHoaDon _cHoaDon = new CHoaDon();
        CDCHD _cDCHD = new CDCHD();
        CLenhHuy _cLenhHuy = new CLenhHuy();
        CDongNuoc _cDongNuoc = new CDongNuoc();
        CDuLieuKhachHang _cDLKH = new CDuLieuKhachHang();
        List<TT_To> _lstTo;

        public frmKiemTraTonDoi()
        {
            InitializeComponent();
        }

        private void frmKiemTraTonDoi_Load(object sender, EventArgs e)
        {
            dgvHDTuGia.AutoGenerateColumns = false;
            dgvHDCoQuan.AutoGenerateColumns = false;
            dgvNhanVien.AutoGenerateColumns = false;

            List<TT_To> lstTo = _cTo.GetDSHanhThu();
            TT_To to = new TT_To();
            to.MaTo = 0;
            to.TenTo = "Tất Cả";
            lstTo.Insert(0, to);
            cmbTo.DataSource = lstTo;
            cmbTo.DisplayMember = "TenTo";
            cmbTo.ValueMember = "MaTo";

            DataTable dtNam = _cHoaDon.GetNam();
            DataRow dr = dtNam.NewRow();
            dr["ID"] = "Tất Cả";
            dtNam.Rows.InsertAt(dr, 0);
            cmbNam.DataSource = dtNam;
            cmbNam.DisplayMember = "ID";
            cmbNam.ValueMember = "Nam";

            _lstTo = _cTo.GetDSHanhThu();
        }

        public void CountdgvHDTuGia()
        {
            int TongHD = 0;
            long TongCong = 0;
            int TongHDThu = 0;
            long TongCongThu = 0;
            int TongHDTon = 0;
            long TongGiaBanTon = 0;
            long TongCongTon = 0;
            long TongCongTonBilling = 0;

            if (dgvHDTuGia.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    if (!string.IsNullOrEmpty(item.Cells["TongHD_TG"].Value.ToString()))
                        TongHD += int.Parse(item.Cells["TongHD_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCong_TG"].Value.ToString()))
                        TongCong += long.Parse(item.Cells["TongCong_TG"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDThu_TG"].Value.ToString()))
                        TongHDThu += int.Parse(item.Cells["TongHDThu_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongThu_TG"].Value.ToString()))
                        TongCongThu += long.Parse(item.Cells["TongCongThu_TG"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDTon_TG"].Value.ToString()))
                        TongHDTon += int.Parse(item.Cells["TongHDTon_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBanTon_TG"].Value.ToString()))
                        TongGiaBanTon += long.Parse(item.Cells["TongGiaBanTon_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongTon_TG"].Value.ToString()))
                        TongCongTon += long.Parse(item.Cells["TongCongTon_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongTonBilling_TG"].Value.ToString()))
                        TongCongTonBilling += long.Parse(item.Cells["TongCongTonBilling_TG"].Value.ToString());

                }
                txtTongHD_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHD);
                txtTongCong_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
                txtTongHDThu_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDThu);
                txtTongCongThu_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongThu);
                txtTongHDTon_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDTon);
                txtTongGiaBanTon_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanTon);
                txtTongCongTon_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongTon);
                txtTongCongTonBilling_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongTonBilling);
            }
        }

        public void CountdgvHDCoQuan()
        {
            int TongHD = 0;
            long TongCong = 0;
            int TongHDThu = 0;
            long TongCongThu = 0;
            int TongHDTon = 0;
            long TongGiaBanTon = 0;
            long TongCongTon = 0;
            long TongCongTonBilling = 0;

            if (dgvHDCoQuan.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                {
                    if (!string.IsNullOrEmpty(item.Cells["TongHD_CQ"].Value.ToString()))
                        TongHD += int.Parse(item.Cells["TongHD_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCong_CQ"].Value.ToString()))
                        TongCong += long.Parse(item.Cells["TongCong_CQ"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDThu_CQ"].Value.ToString()))
                        TongHDThu += int.Parse(item.Cells["TongHDThu_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongThu_CQ"].Value.ToString()))
                        TongCongThu += long.Parse(item.Cells["TongCongThu_CQ"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDTon_CQ"].Value.ToString()))
                        TongHDTon += int.Parse(item.Cells["TongHDTon_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBanTon_CQ"].Value.ToString()))
                        TongGiaBanTon += long.Parse(item.Cells["TongGiaBanTon_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongTon_CQ"].Value.ToString()))
                        TongCongTon += long.Parse(item.Cells["TongCongTon_CQ"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongCongTonBilling_CQ"].Value.ToString()))
                        TongCongTonBilling += long.Parse(item.Cells["TongCongTonBilling_CQ"].Value.ToString());
                }
                txtTongHD_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHD);
                txtTongCong_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
                txtTongHDThu_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDThu);
                txtTongCongThu_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongThu);
                txtTongHDTon_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDTon);
                txtTongGiaBanTon_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanTon);
                txtTongCongTon_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongTon);
                txtTongCongTonBilling_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongTonBilling);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dtDCHD = new DataTable();

            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                ///chọn tất cả tổ
                if (cmbTo.SelectedIndex == 0)
                {
                    if (chkKyKiemTra.Checked && chkNgayKiemTra.Checked)
                    {
                        dt = _cHoaDon.GetTongTonDenKyDenNgay_Doi("TG", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
                        dtDCHD = _cDCHD.GetChuanThuTonDenKyDenNgay("TG", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
                        for (int i = 1; i < _lstTo.Count; i++)
                        {
                            dt.Merge(_cHoaDon.GetTongTonDenKyDenNgay_Doi("TG", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value));
                            dtDCHD.Merge(_cDCHD.GetChuanThuTonDenKyDenNgay("TG", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value));
                        }
                        foreach (DataRow item in dtDCHD.Rows)
                        {
                            if (string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()))
                            {
                                DataRow[] dr = dt.Select("MaTo=" + item["MaTo"].ToString());

                                dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                            }
                            else
                            {
                                //string[] date = item["NgayGiaiTrach"].ToString().Split('/');
                                //string[] year = date[2].Split(' ');
                                //string[] time = year[1].Split(':');
                                //DateTime NgayGiaiTrach = new DateTime(int.Parse(year[0]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
                                DateTime NgayGiaiTrach = DateTime.Parse(item["NgayGiaiTrach"].ToString());

                                if (NgayGiaiTrach.Date > dateGiaiTrach.Value.Date)
                                {
                                    DataRow[] dr = dt.Select("MaTo=" + item["MaTo"].ToString());

                                    dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                                }
                            }
                        }
                    }
                    else
                        if (chkKyKiemTra.Checked)
                        {
                            dt = _cHoaDon.GetTongTonDenKy_Doi("TG", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                            dtDCHD = _cDCHD.GetChuanThuTonDenKy("TG", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                            for (int i = 1; i < _lstTo.Count; i++)
                            {
                                dt.Merge(_cHoaDon.GetTongTonDenKy_Doi("TG", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString())));
                                dtDCHD.Merge(_cDCHD.GetChuanThuTonDenKy("TG", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString())));
                            }
                            foreach (DataRow item in dtDCHD.Rows)
                            {
                                if (string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()))
                                {
                                    DataRow[] dr = dt.Select("MaTo=" + item["MaTo"].ToString());

                                    dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                                }
                            }
                        }
                        else
                            if (chkNgayKiemTra.Checked)
                            {
                                dt = _cHoaDon.GetTongTon_Doi("TG", _lstTo[0].MaTo, dateGiaiTrach.Value);
                                dtDCHD = _cDCHD.GetChuanThuTon("TG", _lstTo[0].MaTo, dateGiaiTrach.Value);
                                for (int i = 1; i < _lstTo.Count; i++)
                                {
                                    dt.Merge(_cHoaDon.GetTongTon_Doi("TG", _lstTo[i].MaTo, dateGiaiTrach.Value));
                                    dtDCHD.Merge(_cDCHD.GetChuanThuTon("TG", _lstTo[i].MaTo, dateGiaiTrach.Value));
                                }
                                foreach (DataRow item in dtDCHD.Rows)
                                {
                                    if (string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()))
                                    {
                                        DataRow[] dr = dt.Select("MaTo=" + item["MaTo"].ToString());

                                        dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                                    }
                                    else
                                    {
                                        //string[] date = item["NgayGiaiTrach"].ToString().Split('/');
                                        //string[] year = date[2].Split(' ');
                                        //string[] time = year[1].Split(':');
                                        //DateTime NgayGiaiTrach = new DateTime(int.Parse(year[0]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
                                        DateTime NgayGiaiTrach = DateTime.Parse(item["NgayGiaiTrach"].ToString());

                                        if (NgayGiaiTrach.Date > dateGiaiTrach.Value.Date)
                                        {
                                            DataRow[] dr = dt.Select("MaTo=" + item["MaTo"].ToString());

                                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                                        }
                                    }
                                }
                            }
                            else
                            {
                                ///chọn tất cả các năm
                                if (cmbNam.SelectedIndex == 0)
                                {
                                    dt = _cHoaDon.GetTongTon_Doi("TG", _lstTo[0].MaTo);
                                    dtDCHD = _cDCHD.GetChuanThuTon("TG", _lstTo[0].MaTo);
                                    for (int i = 1; i < _lstTo.Count; i++)
                                    {
                                        dt.Merge(_cHoaDon.GetTongTon_Doi("TG", _lstTo[i].MaTo));
                                        dtDCHD.Merge(_cDCHD.GetChuanThuTon("TG", _lstTo[i].MaTo));
                                    }
                                }
                                else
                                    ///chọn 1 năm cụ thể
                                    if (cmbNam.SelectedIndex > 0)
                                        ///chọn tất cả các kỳ
                                        if (cmbKy.SelectedIndex == 0)
                                        {
                                            dt = _cHoaDon.GetTongTon_Doi("TG", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()));
                                            dtDCHD = _cDCHD.GetChuanThuTon("TG", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()));
                                            for (int i = 1; i < _lstTo.Count; i++)
                                            {
                                                dt.Merge(_cHoaDon.GetTongTon_Doi("TG", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString())));
                                                dtDCHD.Merge(_cDCHD.GetChuanThuTon("TG", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString())));
                                            }
                                        }
                                        else
                                            ///chọn 1 kỳ cụ thể
                                            if (cmbKy.SelectedIndex > 0)
                                                ///chọn tất cả các đợt
                                                if (cmbDot.SelectedIndex == 0)
                                                {
                                                    dt = _cHoaDon.GetTongTon_Doi("TG", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                                    dtDCHD = _cDCHD.GetChuanThuTon("TG", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                                    for (int i = 1; i < _lstTo.Count; i++)
                                                    {
                                                        dt.Merge(_cHoaDon.GetTongTon_Doi("TG", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString())));
                                                        dtDCHD.Merge(_cDCHD.GetChuanThuTon("TG", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString())));
                                                    }
                                                }
                                                else
                                                    ///chọn 1 đợt cụ thể
                                                    if (cmbDot.SelectedIndex > 0)
                                                    {
                                                        dt = _cHoaDon.GetTongTon_Doi("TG", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
                                                        dtDCHD = _cDCHD.GetChuanThuTon("TG", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
                                                        for (int i = 1; i < _lstTo.Count; i++)
                                                        {
                                                            dt.Merge(_cHoaDon.GetTongTon_Doi("TG", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString())));
                                                            dtDCHD.Merge(_cDCHD.GetChuanThuTon("TG", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString())));
                                                        }
                                                    }
                                foreach (DataRow item in dtDCHD.Rows)
                                {
                                    if (string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()))
                                    {
                                        DataRow[] dr = dt.Select("MaTo=" + item["MaTo"].ToString());

                                        dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                                    }
                                }
                            }
                }
                ///chọn 1 tổ
                else
                {
                    if (chkKyKiemTra.Checked && chkNgayKiemTra.Checked)
                    {
                        dt = _cHoaDon.GetTongTonDenKyDenNgay_Doi("TG", int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
                        dtDCHD = _cDCHD.GetChuanThuTonDenKyDenNgay("TG", int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
                        foreach (DataRow item in dtDCHD.Rows)
                        {
                            if (string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()))
                            {
                                DataRow[] dr = dt.Select("MaTo=" + item["MaTo"].ToString());

                                dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                            }
                            else
                            {
                                //string[] date = item["NgayGiaiTrach"].ToString().Split('/');
                                //string[] year = date[2].Split(' ');
                                //string[] time = year[1].Split(':');
                                //DateTime NgayGiaiTrach = new DateTime(int.Parse(year[0]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
                                DateTime NgayGiaiTrach = DateTime.Parse(item["NgayGiaiTrach"].ToString());

                                if (NgayGiaiTrach.Date > dateGiaiTrach.Value.Date)
                                {
                                    DataRow[] dr = dt.Select("MaTo=" + item["MaTo"].ToString());

                                    dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                                }
                            }
                        }
                    }
                    else
                        if (chkKyKiemTra.Checked)
                        {
                            dt = _cHoaDon.GetTongTonDenKy_Doi("TG", int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                            dtDCHD = _cDCHD.GetChuanThuTonDenKy("TG", int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                            foreach (DataRow item in dtDCHD.Rows)
                            {
                                if (string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()))
                                {
                                    DataRow[] dr = dt.Select("MaTo=" + item["MaTo"].ToString());

                                    dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                                }
                            }
                        }
                        else
                            if (chkNgayKiemTra.Checked)
                            {
                                dt = _cHoaDon.GetTongTon_Doi("TG", int.Parse(cmbTo.SelectedValue.ToString()), dateGiaiTrach.Value);
                                dtDCHD = _cDCHD.GetChuanThuTon("TG", int.Parse(cmbTo.SelectedValue.ToString()), dateGiaiTrach.Value);
                                foreach (DataRow item in dtDCHD.Rows)
                                {
                                    if (string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()))
                                    {
                                        DataRow[] dr = dt.Select("MaTo=" + item["MaTo"].ToString());

                                        dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                                    }
                                    else
                                    {
                                        //string[] date = item["NgayGiaiTrach"].ToString().Split('/');
                                        //string[] year = date[2].Split(' ');
                                        //string[] time = year[1].Split(':');
                                        //DateTime NgayGiaiTrach = new DateTime(int.Parse(year[0]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
                                        DateTime NgayGiaiTrach = DateTime.Parse(item["NgayGiaiTrach"].ToString());

                                        if (NgayGiaiTrach.Date > dateGiaiTrach.Value.Date)
                                        {
                                            DataRow[] dr = dt.Select("MaTo=" + item["MaTo"].ToString());

                                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                                        }
                                    }
                                }
                            }
                            else
                            {
                                ///chọn tất cả các năm
                                if (cmbNam.SelectedIndex == 0)
                                {
                                    dt = _cHoaDon.GetTongTon_Doi("TG", int.Parse(cmbTo.SelectedValue.ToString()));
                                    dtDCHD = _cDCHD.GetChuanThuTon("TG", int.Parse(cmbTo.SelectedValue.ToString()));
                                }
                                else
                                    ///chọn 1 năm cụ thể
                                    if (cmbNam.SelectedIndex > 0)
                                        ///chọn tất cả các kỳ
                                        if (cmbKy.SelectedIndex == 0)
                                        {
                                            dt = _cHoaDon.GetTongTon_Doi("TG", int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()));
                                            dtDCHD = _cDCHD.GetChuanThuTon("TG", int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()));
                                        }
                                        else
                                            ///chọn 1 kỳ cụ thể
                                            if (cmbKy.SelectedIndex > 0)
                                                ///chọn tất cả các đợt
                                                if (cmbDot.SelectedIndex == 0)
                                                {
                                                    dt = _cHoaDon.GetTongTon_Doi("TG", int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                                    dtDCHD = _cDCHD.GetChuanThuTon("TG", int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                                }
                                                else
                                                    ///chọn 1 đợt cụ thể
                                                    if (cmbDot.SelectedIndex > 0)
                                                    {
                                                        dt = _cHoaDon.GetTongTon_Doi("TG", int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
                                                        dtDCHD = _cDCHD.GetChuanThuTon("TG", int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
                                                    }
                                foreach (DataRow item in dtDCHD.Rows)
                                {
                                    if (string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()))
                                    {
                                        DataRow[] dr = dt.Select("MaTo=" + item["MaTo"].ToString());

                                        dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                                    }
                                }
                            }
                }
                dgvHDTuGia.DataSource = dt;
                CountdgvHDTuGia();
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    ///chọn tất cả tổ
                    if (cmbTo.SelectedIndex == 0)
                    {
                        if (chkKyKiemTra.Checked && chkNgayKiemTra.Checked)
                        {
                            dt = _cHoaDon.GetTongTonDenKyDenNgay_Doi("CQ", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
                            dtDCHD = _cDCHD.GetChuanThuTonDenKyDenNgay("CQ", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
                            for (int i = 1; i < _lstTo.Count; i++)
                            {
                                dt.Merge(_cHoaDon.GetTongTonDenKyDenNgay_Doi("CQ", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value));
                                dtDCHD.Merge(_cDCHD.GetChuanThuTonDenKyDenNgay("CQ", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value));
                            }
                            foreach (DataRow item in dtDCHD.Rows)
                            {
                                if (string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()))
                                {
                                    DataRow[] dr = dt.Select("MaTo=" + item["MaTo"].ToString());

                                    dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                                }
                                else
                                {
                                    //string[] date = item["NgayGiaiTrach"].ToString().Split('/');
                                    //string[] year = date[2].Split(' ');
                                    //string[] time = year[1].Split(':');
                                    //DateTime NgayGiaiTrach = new DateTime(int.Parse(year[0]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
                                    DateTime NgayGiaiTrach = DateTime.Parse(item["NgayGiaiTrach"].ToString());

                                    if (NgayGiaiTrach.Date > dateGiaiTrach.Value.Date)
                                    {
                                        DataRow[] dr = dt.Select("MaTo=" + item["MaTo"].ToString());

                                        dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                                    }
                                }
                            }
                        }
                        else
                            if (chkKyKiemTra.Checked)
                            {
                                dt = _cHoaDon.GetTongTonDenKy_Doi("CQ", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                dtDCHD = _cDCHD.GetChuanThuTonDenKy("CQ", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                for (int i = 1; i < _lstTo.Count; i++)
                                {
                                    dt.Merge(_cHoaDon.GetTongTonDenKy_Doi("CQ", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString())));
                                    dtDCHD.Merge(_cDCHD.GetChuanThuTonDenKy("CQ", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString())));
                                }
                                foreach (DataRow item in dtDCHD.Rows)
                                {
                                    if (string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()))
                                    {
                                        DataRow[] dr = dt.Select("MaTo=" + item["MaTo"].ToString());

                                        dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                                    }
                                }
                            }
                            else
                                if (chkNgayKiemTra.Checked)
                                {
                                    dt = _cHoaDon.GetTongTon_Doi("CQ", _lstTo[0].MaTo, dateGiaiTrach.Value);
                                    dtDCHD = _cDCHD.GetChuanThuTon("CQ", _lstTo[0].MaTo, dateGiaiTrach.Value);
                                    for (int i = 1; i < _lstTo.Count; i++)
                                    {
                                        dt.Merge(_cHoaDon.GetTongTon_Doi("CQ", _lstTo[i].MaTo, dateGiaiTrach.Value));
                                        dtDCHD.Merge(_cDCHD.GetChuanThuTon("CQ", _lstTo[i].MaTo, dateGiaiTrach.Value));
                                    }
                                    foreach (DataRow item in dtDCHD.Rows)
                                    {
                                        if (string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()))
                                        {
                                            DataRow[] dr = dt.Select("MaTo=" + item["MaTo"].ToString());

                                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                                        }
                                        else
                                        {
                                            //string[] date = item["NgayGiaiTrach"].ToString().Split('/');
                                            //string[] year = date[2].Split(' ');
                                            //string[] time = year[1].Split(':');
                                            //DateTime NgayGiaiTrach = new DateTime(int.Parse(year[0]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
                                            DateTime NgayGiaiTrach = DateTime.Parse(item["NgayGiaiTrach"].ToString());

                                            if (NgayGiaiTrach.Date > dateGiaiTrach.Value.Date)
                                            {
                                                DataRow[] dr = dt.Select("MaTo=" + item["MaTo"].ToString());

                                                dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    ///chọn tất cả các năm
                                    if (cmbNam.SelectedIndex == 0)
                                    {
                                        dt = _cHoaDon.GetTongTon_Doi("CQ", _lstTo[0].MaTo);
                                        dtDCHD = _cDCHD.GetChuanThuTon("CQ", _lstTo[0].MaTo);
                                        for (int i = 1; i < _lstTo.Count; i++)
                                        {
                                            dt.Merge(_cHoaDon.GetTongTon_Doi("CQ", _lstTo[i].MaTo));
                                            dtDCHD.Merge(_cDCHD.GetChuanThuTon("CQ", _lstTo[i].MaTo));
                                        }
                                    }
                                    else
                                        ///chọn 1 năm cụ thể
                                        if (cmbNam.SelectedIndex > 0)
                                            ///chọn tất cả các kỳ
                                            if (cmbKy.SelectedIndex == 0)
                                            {
                                                dt = _cHoaDon.GetTongTon_Doi("CQ", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()));
                                                dtDCHD = _cDCHD.GetChuanThuTon("CQ", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()));
                                                for (int i = 1; i < _lstTo.Count; i++)
                                                {
                                                    dt.Merge(_cHoaDon.GetTongTon_Doi("CQ", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString())));
                                                    dtDCHD.Merge(_cDCHD.GetChuanThuTon("CQ", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString())));
                                                }
                                            }
                                            else
                                                ///chọn 1 kỳ cụ thể
                                                if (cmbKy.SelectedIndex > 0)
                                                    ///chọn tất cả các đợt
                                                    if (cmbDot.SelectedIndex == 0)
                                                    {
                                                        dt = _cHoaDon.GetTongTon_Doi("CQ", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                                        dtDCHD = _cDCHD.GetChuanThuTon("CQ", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                                        for (int i = 1; i < _lstTo.Count; i++)
                                                        {
                                                            dt.Merge(_cHoaDon.GetTongTon_Doi("CQ", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString())));
                                                            dtDCHD.Merge(_cDCHD.GetChuanThuTon("CQ", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString())));
                                                        }
                                                    }
                                                    else
                                                        ///chọn 1 đợt cụ thể
                                                        if (cmbDot.SelectedIndex > 0)
                                                        {
                                                            dt = _cHoaDon.GetTongTon_Doi("CQ", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
                                                            dtDCHD = _cDCHD.GetChuanThuTon("CQ", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
                                                            for (int i = 1; i < _lstTo.Count; i++)
                                                            {
                                                                dt.Merge(_cHoaDon.GetTongTon_Doi("CQ", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString())));
                                                                dtDCHD.Merge(_cDCHD.GetChuanThuTon("CQ", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString())));
                                                            }
                                                        }
                                    foreach (DataRow item in dtDCHD.Rows)
                                    {
                                        if (string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()))
                                        {
                                            DataRow[] dr = dt.Select("MaTo=" + item["MaTo"].ToString());

                                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                                        }
                                    }
                                }
                    }
                    ///chọn 1 tổ
                    else
                    {
                        if (chkKyKiemTra.Checked && chkNgayKiemTra.Checked)
                        {
                            dt = _cHoaDon.GetTongTonDenKyDenNgay_Doi("CQ", int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
                            dtDCHD = _cDCHD.GetChuanThuTonDenKyDenNgay("CQ", int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
                            foreach (DataRow item in dtDCHD.Rows)
                            {
                                if (string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()))
                                {
                                    DataRow[] dr = dt.Select("MaTo=" + item["MaTo"].ToString());

                                    dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                                }
                                else
                                {
                                    //string[] date = item["NgayGiaiTrach"].ToString().Split('/');
                                    //string[] year = date[2].Split(' ');
                                    //string[] time = year[1].Split(':');
                                    //DateTime NgayGiaiTrach = new DateTime(int.Parse(year[0]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
                                    DateTime NgayGiaiTrach = DateTime.Parse(item["NgayGiaiTrach"].ToString());

                                    if (NgayGiaiTrach.Date > dateGiaiTrach.Value.Date)
                                    {
                                        DataRow[] dr = dt.Select("MaTo=" + item["MaTo"].ToString());

                                        dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                                    }
                                }
                            }
                        }
                        else
                            if (chkKyKiemTra.Checked)
                            {
                                dt = _cHoaDon.GetTongTonDenKy_Doi("CQ", int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                dtDCHD = _cDCHD.GetChuanThuTonDenKy("CQ", int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                foreach (DataRow item in dtDCHD.Rows)
                                {
                                    if (string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()))
                                    {
                                        DataRow[] dr = dt.Select("MaTo=" + item["MaTo"].ToString());

                                        dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                                    }
                                }
                            }
                            else
                                if (chkNgayKiemTra.Checked)
                                {
                                    dt = _cHoaDon.GetTongTon_Doi("CQ", int.Parse(cmbTo.SelectedValue.ToString()), dateGiaiTrach.Value);
                                    dtDCHD = _cDCHD.GetChuanThuTon("CQ", int.Parse(cmbTo.SelectedValue.ToString()), dateGiaiTrach.Value);
                                    foreach (DataRow item in dtDCHD.Rows)
                                    {
                                        if (string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()))
                                        {
                                            DataRow[] dr = dt.Select("MaTo=" + item["MaTo"].ToString());

                                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                                        }
                                        else
                                        {
                                            //string[] date = item["NgayGiaiTrach"].ToString().Split('/');
                                            //string[] year = date[2].Split(' ');
                                            //string[] time = year[1].Split(':');
                                            //DateTime NgayGiaiTrach = new DateTime(int.Parse(year[0]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
                                            DateTime NgayGiaiTrach = DateTime.Parse(item["NgayGiaiTrach"].ToString());

                                            if (NgayGiaiTrach.Date > dateGiaiTrach.Value.Date)
                                            {
                                                DataRow[] dr = dt.Select("MaTo=" + item["MaTo"].ToString());

                                                dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    ///chọn tất cả các năm
                                    if (cmbNam.SelectedIndex == 0)
                                    {
                                        dt = _cHoaDon.GetTongTon_Doi("CQ", int.Parse(cmbTo.SelectedValue.ToString()));
                                        dtDCHD = _cDCHD.GetChuanThuTon("CQ", int.Parse(cmbTo.SelectedValue.ToString()));
                                    }
                                    else
                                        ///chọn 1 năm cụ thể
                                        if (cmbNam.SelectedIndex > 0)
                                            ///chọn tất cả các kỳ
                                            if (cmbKy.SelectedIndex == 0)
                                            {
                                                dt = _cHoaDon.GetTongTon_Doi("CQ", int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()));
                                                dtDCHD = _cDCHD.GetChuanThuTon("CQ", int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()));
                                            }
                                            else
                                                ///chọn 1 kỳ cụ thể
                                                if (cmbKy.SelectedIndex > 0)
                                                    ///chọn tất cả các đợt
                                                    if (cmbDot.SelectedIndex == 0)
                                                    {
                                                        dt = _cHoaDon.GetTongTon_Doi("CQ", int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                                        dtDCHD = _cDCHD.GetChuanThuTon("CQ", int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                                    }
                                                    else
                                                        ///chọn 1 đợt cụ thể
                                                        if (cmbDot.SelectedIndex > 0)
                                                        {
                                                            dt = _cHoaDon.GetTongTon_Doi("CQ", int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
                                                            dtDCHD = _cDCHD.GetChuanThuTon("CQ", int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
                                                        }
                                    foreach (DataRow item in dtDCHD.Rows)
                                    {
                                        if (string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()))
                                        {
                                            DataRow[] dr = dt.Select("MaTo=" + item["MaTo"].ToString());

                                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                                        }
                                    }
                                }
                    }
                    dgvHDCoQuan.DataSource = dt;
                    CountdgvHDCoQuan();
                }
        }

        private void btnInDSTo_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                DataTable dt = new DataTable();
                if (chkKyKiemTra.Checked && chkNgayKiemTra.Checked)
                {
                    dt = _cHoaDon.GetDSTonDenKyDenNgay_To("TG", int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaTo_TG"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                }
                else
                    if (chkKyKiemTra.Checked)
                    {
                        dt = _cHoaDon.GetDSTonDenKy_To("TG", int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaTo_TG"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                    }
                    else
                        if (chkNgayKiemTra.Checked)
                        {
                            dt = _cHoaDon.GetDSTon_To("TG", int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaTo_TG"].Value.ToString()), dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                        }
                        else
                        {
                            if (cmbNam.SelectedIndex == 0)
                                dt = _cHoaDon.GetDSTon_To("TG", int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaTo_TG"].Value.ToString()), int.Parse(txtSoKy.Text.Trim()));
                            else
                                if (cmbNam.SelectedIndex > 0)
                                    if (cmbKy.SelectedIndex == 0)
                                        dt = _cHoaDon.GetDSTon_To("TG", int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaTo_TG"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtSoKy.Text.Trim()));
                                    else
                                        if (cmbKy.SelectedIndex > 1)
                                            if (cmbDot.SelectedIndex == 0)
                                                dt = _cHoaDon.GetDSTon_To("TG", int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaTo_TG"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                                            else
                                                dt = _cHoaDon.GetDSTon_To("TG", int.Parse(dgvHDTuGia.SelectedRows[0].Cells["MaTo_TG"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                        }
                foreach (DataRow item in dt.Rows)
                {
                    DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                    dr["LoaiBaoCao"] = "TƯ GIA TỒN";
                    dr["DanhBo"] = item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
                    dr["Ky"] = item["Ky"];
                    dr["MLT"] = item["MLT"];
                    dr["TongCong"] = item["TongCong"];
                    dr["SoPhatHanh"] = item["SoPhatHanh"];
                    dr["SoHoaDon"] = item["SoHoaDon"];
                    dr["NhanVien"] = dgvHDTuGia.SelectedRows[0].Cells["TenTo_TG"].Value.ToString();
                    if (_cLenhHuy.CheckExist(item["SoHoaDon"].ToString()))
                        dr["LenhHuy"] = true;
                    ds.Tables["DSHoaDon"].Rows.Add(dr);
                }
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    DataTable dt = new DataTable();
                    if (chkKyKiemTra.Checked && chkNgayKiemTra.Checked)
                    {
                        dt = _cHoaDon.GetDSTonDenKyDenNgay_To("CQ", int.Parse(dgvHDCoQuan.SelectedRows[0].Cells["MaTo_CQ"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                    }
                    else
                        if (chkKyKiemTra.Checked)
                        {
                            dt = _cHoaDon.GetDSTonDenKy_To("CQ", int.Parse(dgvHDCoQuan.SelectedRows[0].Cells["MaTo_CQ"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                        }
                        else
                            if (chkNgayKiemTra.Checked)
                            {
                                dt = _cHoaDon.GetDSTon_To("CQ", int.Parse(dgvHDCoQuan.SelectedRows[0].Cells["MaTo_CQ"].Value.ToString()), dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                            }
                            else
                            {
                                if (cmbNam.SelectedIndex == 0)
                                    dt = _cHoaDon.GetDSTon_To("CQ", int.Parse(dgvHDCoQuan.SelectedRows[0].Cells["MaTo_CQ"].Value.ToString()), int.Parse(txtSoKy.Text.Trim()));
                                else
                                    if (cmbNam.SelectedIndex > 0)
                                        if (cmbKy.SelectedIndex == 0)
                                            dt = _cHoaDon.GetDSTon_To("CQ", int.Parse(dgvHDCoQuan.SelectedRows[0].Cells["MaTo_CQ"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtSoKy.Text.Trim()));
                                        else
                                            if (cmbKy.SelectedIndex > 1)
                                                if (cmbDot.SelectedIndex == 0)
                                                    dt = _cHoaDon.GetDSTon_To("CQ", int.Parse(dgvHDCoQuan.SelectedRows[0].Cells["MaTo_CQ"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                                                else
                                                    dt = _cHoaDon.GetDSTon_To("CQ", int.Parse(dgvHDCoQuan.SelectedRows[0].Cells["MaTo_CQ"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                            }
                    foreach (DataRow item in dt.Rows)
                    {
                        DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                        dr["LoaiBaoCao"] = "CƠ QUAN TỒN";
                        dr["DanhBo"] = item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
                        dr["Ky"] = item["Ky"];
                        dr["MLT"] = item["MLT"];
                        dr["TongCong"] = item["TongCong"];
                        dr["SoPhatHanh"] = item["SoPhatHanh"];
                        dr["SoHoaDon"] = item["SoHoaDon"];
                        dr["NhanVien"] = dgvHDCoQuan.SelectedRows[0].Cells["TenTo_CQ"].Value.ToString();
                        if (_cLenhHuy.CheckExist(item["SoHoaDon"].ToString()))
                            dr["LenhHuy"] = true;
                        ds.Tables["DSHoaDon"].Rows.Add(dr);
                    }
                }
            rptDSHoaDon rpt = new rptDSHoaDon();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnInDSNhanVien_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dsBaoCao ds = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                if (chkKyKiemTra.Checked && chkNgayKiemTra.Checked)
                {
                    dt = _cHoaDon.GetDSTonDenKyDenNgay_NV("TG", int.Parse(dgvNhanVien.SelectedRows[0].Cells["MaNV_NV"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                }
                else
                    if (chkKyKiemTra.Checked)
                    {
                        dt = _cHoaDon.GetDSTonDenKy_NV("TG", int.Parse(dgvNhanVien.SelectedRows[0].Cells["MaNV_NV"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                    }
                    else
                        if (chkNgayKiemTra.Checked)
                        {
                            dt = _cHoaDon.GetDSTon_NV("TG", int.Parse(dgvNhanVien.SelectedRows[0].Cells["MaNV_NV"].Value.ToString()), dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                        }
                        else
                        {
                            if (cmbNam.SelectedIndex == 0)
                                dt = _cHoaDon.GetDSTon_NV("TG", int.Parse(dgvNhanVien.SelectedRows[0].Cells["MaNV_NV"].Value.ToString()), int.Parse(txtSoKy.Text.Trim()));
                            else
                                if (cmbNam.SelectedIndex > 0)
                                    if (cmbKy.SelectedIndex == 0)
                                        dt = _cHoaDon.GetDSTon_NV("TG", int.Parse(dgvNhanVien.SelectedRows[0].Cells["MaNV_NV"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtSoKy.Text.Trim()));
                                    else
                                        if (cmbKy.SelectedIndex > 1)
                                            if (cmbDot.SelectedIndex == 0)
                                                dt = _cHoaDon.GetDSTon_NV("TG", int.Parse(dgvNhanVien.SelectedRows[0].Cells["MaNV_NV"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                                            else
                                                dt = _cHoaDon.GetDSTon_NV("TG", int.Parse(dgvNhanVien.SelectedRows[0].Cells["MaNV_NV"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                        }
                foreach (DataRow item in dt.Rows)
                {
                    DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                    dr["LoaiBaoCao"] = "TƯ GIA TỒN";
                    dr["DanhBo"] = item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
                    dr["Ky"] = item["Ky"];
                    dr["MLT"] = item["MLT"];
                    dr["TongCong"] = item["TongCong"];
                    dr["SoPhatHanh"] = item["SoPhatHanh"];
                    dr["SoHoaDon"] = item["SoHoaDon"];
                    dr["NhanVien"] = dgvNhanVien.SelectedRows[0].Cells["HoTen_NV"].Value.ToString();
                    if (_cLenhHuy.CheckExist(item["SoHoaDon"].ToString()))
                        dr["LenhHuy"] = true;
                    ds.Tables["DSHoaDon"].Rows.Add(dr);
                }
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    if (chkKyKiemTra.Checked && chkNgayKiemTra.Checked)
                    {
                        dt = _cHoaDon.GetDSTonDenKyDenNgay_NV("CQ", int.Parse(dgvNhanVien.SelectedRows[0].Cells["MaNV_NV"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                    }
                    else
                        if (chkKyKiemTra.Checked)
                        {
                            dt = _cHoaDon.GetDSTonDenKy_NV("CQ", int.Parse(dgvNhanVien.SelectedRows[0].Cells["MaNV_NV"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                        }
                        else
                            if (chkNgayKiemTra.Checked)
                            {
                                dt = _cHoaDon.GetDSTon_NV("CQ", int.Parse(dgvNhanVien.SelectedRows[0].Cells["MaNV_NV"].Value.ToString()), dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                            }
                            else
                            {
                                if (cmbNam.SelectedIndex == 0)
                                    dt = _cHoaDon.GetDSTon_NV("CQ", int.Parse(dgvNhanVien.SelectedRows[0].Cells["MaNV_NV"].Value.ToString()), int.Parse(txtSoKy.Text.Trim()));
                                else
                                    if (cmbNam.SelectedIndex > 0)
                                        if (cmbKy.SelectedIndex == 0)
                                            dt = _cHoaDon.GetDSTon_NV("CQ", int.Parse(dgvNhanVien.SelectedRows[0].Cells["MaNV_NV"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtSoKy.Text.Trim()));
                                        else
                                            if (cmbKy.SelectedIndex > 1)
                                                if (cmbDot.SelectedIndex == 0)
                                                    dt = _cHoaDon.GetDSTon_NV("TG", int.Parse(dgvNhanVien.SelectedRows[0].Cells["MaNV_NV"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                                                else
                                                    dt = _cHoaDon.GetDSTon_NV("TG", int.Parse(dgvNhanVien.SelectedRows[0].Cells["MaNV_NV"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                            }
                    foreach (DataRow item in dt.Rows)
                    {
                        DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                        dr["LoaiBaoCao"] = "CƠ QUAN TỒN";
                        dr["DanhBo"] = item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
                        dr["Ky"] = item["Ky"];
                        dr["MLT"] = item["MLT"];
                        dr["TongCong"] = item["TongCong"];
                        dr["SoPhatHanh"] = item["SoPhatHanh"];
                        dr["SoHoaDon"] = item["SoHoaDon"];
                        dr["NhanVien"] = dgvNhanVien.SelectedRows[0].Cells["HoTen_NV"].Value.ToString();
                        if (_cLenhHuy.CheckExist(item["SoHoaDon"].ToString()))
                            dr["LenhHuy"] = true;
                        ds.Tables["DSHoaDon"].Rows.Add(dr);
                    }
                }
            rptDSHoaDon rpt = new rptDSHoaDon();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }

        private void dgvHDTuGia_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongHD_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCong_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongHDThu_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCongThu_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongHDTon_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongGiaBanTon_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCongTon_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongCongTonBilling_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHDCoQuan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongHD_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongCong_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongHDThu_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongCongThu_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongHDTon_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongGiaBanTon_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongCongTon_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongCongTonBilling_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHDTuGia_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHDTuGia.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvHDCoQuan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvHDCoQuan.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvHDTuGia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dtDCHD = new DataTable();
            if (chkKyKiemTra.Checked && chkNgayKiemTra.Checked)
            {
                dt = _cHoaDon.GetTongTonDenKyDenNgay_To("TG", int.Parse(dgvHDTuGia["MaTo_TG", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()),dateGiaiTrach.Value);
                dtDCHD = _cDCHD.GetChuanThuTonDenKyDenNgay("TG", int.Parse(dgvHDTuGia["MaTo_TG", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
                foreach (DataRow item in dtDCHD.Rows)
                {
                    if (string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()))
                    {
                        DataRow[] dr = dt.Select("MaNV=" + item["MaNV"].ToString());

                        dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                    }
                    else
                    {
                        //string[] date = item["NgayGiaiTrach"].ToString().Split('/');
                        //string[] year = date[2].Split(' ');
                        //string[] time = year[1].Split(':');
                        //DateTime NgayGiaiTrach = new DateTime(int.Parse(year[0]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
                        DateTime NgayGiaiTrach = DateTime.Parse(item["NgayGiaiTrach"].ToString());

                        if (NgayGiaiTrach.Date > dateGiaiTrach.Value.Date)
                        {
                            DataRow[] dr = dt.Select("MaNV=" + item["MaNV"].ToString());

                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                        }
                    }
                }
            }
            else
                if (chkKyKiemTra.Checked)
                {
                    dt = _cHoaDon.GetTongTonDenKy_To("TG", int.Parse(dgvHDTuGia["MaTo_TG", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                    dtDCHD = _cDCHD.GetChuanThuTonDenKy("TG", int.Parse(dgvHDTuGia["MaTo_TG", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                    foreach (DataRow item in dtDCHD.Rows)
                    {
                        if (string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()))
                        {
                            DataRow[] dr = dt.Select("MaNV=" + item["MaNV"].ToString());

                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                        }
                    }
                }
                else
                    if (chkNgayKiemTra.Checked)
                    {
                        dt = _cHoaDon.GetTongTon_To("TG", int.Parse(dgvHDTuGia["MaTo_TG", e.RowIndex].Value.ToString()), dateGiaiTrach.Value);
                        dtDCHD = _cDCHD.GetChuanThuTon("TG", int.Parse(dgvHDTuGia["MaTo_TG", e.RowIndex].Value.ToString()), dateGiaiTrach.Value);
                        foreach (DataRow item in dtDCHD.Rows)
                        {
                            if (string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()))
                            {
                                DataRow[] dr = dt.Select("MaNV=" + item["MaNV"].ToString());

                                dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                            }
                            else
                            {
                                //string[] date = item["NgayGiaiTrach"].ToString().Split('/');
                                //string[] year = date[2].Split(' ');
                                //string[] time = year[1].Split(':');
                                //DateTime NgayGiaiTrach = new DateTime(int.Parse(year[0]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
                                DateTime NgayGiaiTrach = DateTime.Parse(item["NgayGiaiTrach"].ToString());

                                if (NgayGiaiTrach.Date > dateGiaiTrach.Value.Date)
                                {
                                    DataRow[] dr = dt.Select("MaNV=" + item["MaNV"].ToString());

                                    dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                                }
                            }
                        }
                    }
                    else
                    {
                        if (cmbNam.SelectedIndex == 0)
                        {
                            dt = _cHoaDon.GetTongTon_To("TG", int.Parse(dgvHDTuGia["MaTo_TG", e.RowIndex].Value.ToString()));
                            dtDCHD = _cDCHD.GetChuanThuTon("TG", int.Parse(dgvHDTuGia["MaTo_TG", e.RowIndex].Value.ToString()));
                        }
                        else
                            if (cmbNam.SelectedIndex > 0)
                                if (cmbKy.SelectedIndex == 0)
                                {
                                    dt = _cHoaDon.GetTongTon_To("TG", int.Parse(dgvHDTuGia["MaTo_TG", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()));
                                    dtDCHD = _cDCHD.GetChuanThuTon("TG", int.Parse(dgvHDTuGia["MaTo_TG", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()));
                                }
                                else
                                    if (cmbKy.SelectedIndex > 0)
                                        if (cmbDot.SelectedIndex == 0)
                                        {
                                            dt = _cHoaDon.GetTongTon_To("TG", int.Parse(dgvHDTuGia["MaTo_TG", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                            dtDCHD = _cDCHD.GetChuanThuTon("TG", int.Parse(dgvHDTuGia["MaTo_TG", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                        }
                                        else
                                            if (cmbDot.SelectedIndex > 0)
                                            {
                                                dt = _cHoaDon.GetTongTon_To("TG", int.Parse(dgvHDTuGia["MaTo_TG", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
                                                dtDCHD = _cDCHD.GetChuanThuTon("TG", int.Parse(dgvHDTuGia["MaTo_TG", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
                                            }
                        foreach (DataRow item in dtDCHD.Rows)
                        {
                            if (string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()))
                            {
                                DataRow[] dr = dt.Select("MaNV=" + item["MaNV"].ToString());

                                dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                            }
                        }
                    }
            dgvNhanVien.DataSource = dt;
        }

        private void dgvHDCoQuan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dtDCHD = new DataTable();
            if (chkKyKiemTra.Checked && chkNgayKiemTra.Checked)
            {
                dt = _cHoaDon.GetTongTonDenKyDenNgay_To("CQ", int.Parse(dgvHDCoQuan["MaTo_CQ", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
                dtDCHD = _cDCHD.GetChuanThuTonDenKyDenNgay("CQ", int.Parse(dgvHDCoQuan["MaTo_CQ", e.RowIndex].Value.ToString()),int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
                foreach (DataRow item in dtDCHD.Rows)
                {
                    if (string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()))
                    {
                        DataRow[] dr = dt.Select("MaNV=" + item["MaNV"].ToString());

                        dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                    }
                    else
                    {
                        //string[] date = item["NgayGiaiTrach"].ToString().Split('/');
                        //string[] year = date[2].Split(' ');
                        //string[] time = year[1].Split(':');
                        //DateTime NgayGiaiTrach = new DateTime(int.Parse(year[0]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
                        DateTime NgayGiaiTrach = DateTime.Parse(item["NgayGiaiTrach"].ToString());

                        if (NgayGiaiTrach.Date > dateGiaiTrach.Value.Date)
                        {
                            DataRow[] dr = dt.Select("MaNV=" + item["MaNV"].ToString());

                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                        }
                    }
                }
            }
            else
                if (chkKyKiemTra.Checked)
                {
                    dt = _cHoaDon.GetTongTonDenKy_To("CQ", int.Parse(dgvHDCoQuan["MaTo_CQ", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                    dtDCHD = _cDCHD.GetChuanThuTonDenKy("CQ", int.Parse(dgvHDCoQuan["MaTo_CQ", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                    foreach (DataRow item in dtDCHD.Rows)
                    {
                        if (string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()))
                        {
                            DataRow[] dr = dt.Select("MaNV=" + item["MaNV"].ToString());

                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                        }
                    }
                }
                else
                    if (chkNgayKiemTra.Checked)
                    {
                        dt = _cHoaDon.GetTongTon_To("CQ", int.Parse(dgvHDCoQuan["MaTo_CQ", e.RowIndex].Value.ToString()), dateGiaiTrach.Value);
                        dtDCHD = _cDCHD.GetChuanThuTon("CQ", int.Parse(dgvHDCoQuan["MaTo_CQ", e.RowIndex].Value.ToString()), dateGiaiTrach.Value);
                        foreach (DataRow item in dtDCHD.Rows)
                        {
                            if (string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()))
                            {
                                DataRow[] dr = dt.Select("MaNV=" + item["MaNV"].ToString());

                                dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                            }
                            else
                            {
                                //string[] date = item["NgayGiaiTrach"].ToString().Split('/');
                                //string[] year = date[2].Split(' ');
                                //string[] time = year[1].Split(':');
                                //DateTime NgayGiaiTrach = new DateTime(int.Parse(year[0]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
                                DateTime NgayGiaiTrach = DateTime.Parse(item["NgayGiaiTrach"].ToString());

                                if (NgayGiaiTrach.Date > dateGiaiTrach.Value.Date)
                                {
                                    DataRow[] dr = dt.Select("MaNV=" + item["MaNV"].ToString());

                                    dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                                }
                            }
                        }
                    }
                    else
                    {
                        if (cmbNam.SelectedIndex == 0)
                        {
                            dt = _cHoaDon.GetTongTon_To("CQ", int.Parse(dgvHDCoQuan["MaTo_CQ", e.RowIndex].Value.ToString()));
                            dtDCHD = _cDCHD.GetChuanThuTon("CQ", int.Parse(dgvHDCoQuan["MaTo_CQ", e.RowIndex].Value.ToString()));
                        }
                        else
                            if (cmbNam.SelectedIndex > 0)
                                if (cmbKy.SelectedIndex == 0)
                                {
                                    dt = _cHoaDon.GetTongTon_To("CQ", int.Parse(dgvHDCoQuan["MaTo_CQ", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()));
                                    dtDCHD = _cDCHD.GetChuanThuTon("CQ", int.Parse(dgvHDCoQuan["MaTo_CQ", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()));
                                }
                                else
                                    if (cmbKy.SelectedIndex > 0)
                                        if (cmbDot.SelectedIndex == 0)
                                        {
                                            dt = _cHoaDon.GetTongTon_To("CQ", int.Parse(dgvHDCoQuan["MaTo_CQ", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                            dtDCHD = _cDCHD.GetChuanThuTon("CQ", int.Parse(dgvHDCoQuan["MaTo_CQ", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                        }
                                        else
                                            if (cmbDot.SelectedIndex > 0)
                                            {
                                                dt = _cHoaDon.GetTongTon_To("CQ", int.Parse(dgvHDCoQuan["MaTo_CQ", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
                                                dtDCHD = _cDCHD.GetChuanThuTon("CQ", int.Parse(dgvHDCoQuan["MaTo_CQ", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
                                            }
                        foreach (DataRow item in dtDCHD.Rows)
                        {
                            if (string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()))
                            {
                                DataRow[] dr = dt.Select("MaNV=" + item["MaNV"].ToString());

                                dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTonBilling"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                            }
                        }
                    }
            dgvNhanVien.DataSource = dt;
        }

        private void dgvNhanVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "TongHD_NV" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "TongCong_NV" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "TongHDThu_NV" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "TongCongThu_NV" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "TongHDTon_NV" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "TongGiaBanTon_NV" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "TongCongTon_NV" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "TongCongTonBilling_NV" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvNhanVien_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvNhanVien.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                ///chọn tất cả tổ
                if (cmbTo.SelectedIndex == 0)
                {
                    if (chkKyKiemTra.Checked && chkNgayKiemTra.Checked)
                    {
                        dt = _cHoaDon.GetDSTonDenKyDenNgay_To("TG", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()),dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                        for (int i = 1; i < _lstTo.Count; i++)
                            dt.Merge(_cHoaDon.GetDSTonDenKyDenNgay_To("TG", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim())));
                    }
                    else
                        if (chkKyKiemTra.Checked)
                        {
                            dt = _cHoaDon.GetDSTonDenKy_To("TG", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                            for (int i = 1; i < _lstTo.Count; i++)
                                dt.Merge(_cHoaDon.GetDSTonDenKy_To("TG", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim())));
                        }
                        else
                            if (chkNgayKiemTra.Checked)
                            {
                                dt = _cHoaDon.GetDSTon_To("TG", _lstTo[0].MaTo, dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                                for (int i = 1; i < _lstTo.Count; i++)
                                    dt.Merge(_cHoaDon.GetDSTon_To("TG", _lstTo[i].MaTo, dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim())));
                            }
                            else
                            {
                                ///chọn tất cả các năm
                                if (cmbNam.SelectedIndex == 0)
                                {
                                    dt = _cHoaDon.GetDSTon_To("TG", _lstTo[0].MaTo, int.Parse(txtSoKy.Text.Trim()));
                                    for (int i = 1; i < _lstTo.Count; i++)
                                        dt.Merge(_cHoaDon.GetDSTon_To("TG", _lstTo[i].MaTo, int.Parse(txtSoKy.Text.Trim())));
                                }
                                else
                                    ///chọn 1 năm cụ thể
                                    if (cmbNam.SelectedIndex > 0)
                                        ///chọn tất cả các kỳ
                                        if (cmbKy.SelectedIndex == 0)
                                        {
                                            dt = _cHoaDon.GetDSTon_To("TG", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtSoKy.Text.Trim()));
                                            for (int i = 1; i < _lstTo.Count; i++)
                                                dt.Merge(_cHoaDon.GetDSTon_To("TG", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtSoKy.Text.Trim())));
                                        }
                                        ///chọn 1 kỳ cụ thể
                                        else
                                            if (cmbKy.SelectedIndex > 0)
                                            {
                                                dt = _cHoaDon.GetDSTon_To("TG", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                                                for (int i = 1; i < _lstTo.Count; i++)
                                                    dt.Merge(_cHoaDon.GetDSTon_To("TG", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim())));
                                            }
                            }
                }
                ///chọn 1 tổ
                else
                {
                    if (chkKyKiemTra.Checked && chkNgayKiemTra.Checked)
                    {
                        dt = _cHoaDon.GetDSTonDenKyDenNgay_To("TG", int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                    }
                    else
                        if (chkKyKiemTra.Checked)
                        {
                            dt = _cHoaDon.GetDSTonDenKy_To("TG", int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                        }
                        else
                            if (chkNgayKiemTra.Checked)
                            {
                                dt = _cHoaDon.GetDSTon_To("TG", int.Parse(cmbTo.SelectedValue.ToString()), dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                            }
                            else
                            {
                                ///chọn tất cả các năm
                                if (cmbNam.SelectedIndex == 0)
                                {
                                    dt = _cHoaDon.GetDSTon_To("TG", int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(txtSoKy.Text.Trim()));
                                }
                                else
                                    ///chọn 1 năm cụ thể
                                    if (cmbNam.SelectedIndex > 0)
                                        ///chọn tất cả các kỳ
                                        if (cmbKy.SelectedIndex == 0)
                                            dt = _cHoaDon.GetDSTon_To("TG", int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtSoKy.Text.Trim()));
                                        ///chọn 1 kỳ cụ thể
                                        else
                                            if (cmbKy.SelectedIndex > 0)
                                                dt = _cHoaDon.GetDSTon_To("TG", int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                            }
                }

                foreach (DataRow item in dt.Rows)
                {
                    if (_cDCHD.CheckExist(item["SoHoaDon"].ToString()))
                    {
                        DataTable dtDCHD = _cDCHD.GetChuanThu(item["SoHoaDon"].ToString());
                        item["GiaBan"] = long.Parse(item["GiaBan"].ToString()) - int.Parse(dtDCHD.Rows[0]["GIABAN_END"].ToString()) + int.Parse(dtDCHD.Rows[0]["GIABAN_BD"].ToString());
                        item["ThueGTGT"] = long.Parse(item["ThueGTGT"].ToString()) - int.Parse(dtDCHD.Rows[0]["THUEGTGT_END"].ToString()) + int.Parse(dtDCHD.Rows[0]["THUEGTGT_BD"].ToString());
                        item["PhiBVMT"] = long.Parse(item["PhiBVMT"].ToString()) - int.Parse(dtDCHD.Rows[0]["PHIBVMT_END"].ToString()) + int.Parse(dtDCHD.Rows[0]["PHIBVMT_BD"].ToString());
                        item["TongCong"] = long.Parse(item["TongCong"].ToString()) - int.Parse(dtDCHD.Rows[0]["TONGCONG_END"].ToString()) + int.Parse(dtDCHD.Rows[0]["TONGCONG_BD"].ToString());
                    }
                }

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

                XuatExcel(dt, oSheet, "TƯ GIA");
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    ///chọn tất cả tổ
                    if (cmbTo.SelectedIndex == 0)
                    {
                        if (chkKyKiemTra.Checked && chkNgayKiemTra.Checked)
                        {
                            dt = _cHoaDon.GetDSTonDenKyDenNgay_To("CQ", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                            for (int i = 1; i < _lstTo.Count; i++)
                                dt.Merge(_cHoaDon.GetDSTonDenKyDenNgay_To("CQ", int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), _lstTo[i].MaTo, dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim())));
                        }
                        else
                            if (chkKyKiemTra.Checked)
                            {
                                dt = _cHoaDon.GetDSTonDenKy_To("CQ", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                                for (int i = 1; i < _lstTo.Count; i++)
                                    dt.Merge(_cHoaDon.GetDSTonDenKy_To("CQ", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim())));
                            }
                            else
                                if (chkNgayKiemTra.Checked)
                                {
                                    dt = _cHoaDon.GetDSTon_To("CQ", _lstTo[0].MaTo, dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                                    for (int i = 1; i < _lstTo.Count; i++)
                                        dt.Merge(_cHoaDon.GetDSTon_To("CQ", _lstTo[i].MaTo, dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim())));
                                }
                                else
                                {
                                    ///chọn tất cả các năm
                                    if (cmbNam.SelectedIndex == 0)
                                    {
                                        dt = _cHoaDon.GetDSTon_To("CQ", _lstTo[0].MaTo, int.Parse(txtSoKy.Text.Trim()));
                                        for (int i = 1; i < _lstTo.Count; i++)
                                            dt.Merge(_cHoaDon.GetDSTon_To("CQ", _lstTo[i].MaTo, int.Parse(txtSoKy.Text.Trim())));
                                    }
                                    else
                                        ///chọn 1 năm cụ thể
                                        if (cmbNam.SelectedIndex > 0)
                                            ///chọn tất cả các kỳ
                                            if (cmbKy.SelectedIndex == 0)
                                            {
                                                dt = _cHoaDon.GetDSTon_To("CQ", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtSoKy.Text.Trim()));
                                                for (int i = 1; i < _lstTo.Count; i++)
                                                    dt.Merge(_cHoaDon.GetDSTon_To("CQ", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtSoKy.Text.Trim())));
                                            }
                                            ///chọn 1 kỳ cụ thể
                                            else
                                                if (cmbKy.SelectedIndex > 0)
                                                {
                                                    dt = _cHoaDon.GetDSTon_To("CQ", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                                                    for (int i = 1; i < _lstTo.Count; i++)
                                                        dt.Merge(_cHoaDon.GetDSTon_To("CQ", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim())));
                                                }
                                }
                    }
                    ///chọn 1 tổ
                    else
                    {
                        if (chkKyKiemTra.Checked && chkNgayKiemTra.Checked)
                        {
                            dt = _cHoaDon.GetDSTonDenKyDenNgay_To("CQ", int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                        }
                        else
                            if (chkKyKiemTra.Checked)
                            {
                                dt = _cHoaDon.GetDSTonDenKy_To("CQ", int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                            }
                            else
                                if (chkNgayKiemTra.Checked)
                                {
                                    dt = _cHoaDon.GetDSTon_To("CQ", int.Parse(cmbTo.SelectedValue.ToString()), dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                                }
                                else
                                {
                                    ///chọn tất cả các năm
                                    if (cmbNam.SelectedIndex == 0)
                                    {
                                        dt = _cHoaDon.GetDSTon_To("CQ", _lstTo[0].MaTo, int.Parse(txtSoKy.Text.Trim()));
                                        for (int i = 1; i < _lstTo.Count; i++)
                                            dt.Merge(_cHoaDon.GetDSTon_To("CQ", _lstTo[i].MaTo, int.Parse(txtSoKy.Text.Trim())));
                                    }
                                    else
                                        ///chọn 1 năm cụ thể
                                        if (cmbNam.SelectedIndex > 0)
                                            ///chọn tất cả các kỳ
                                            if (cmbKy.SelectedIndex == 0)
                                                dt = _cHoaDon.GetDSTon_To("CQ", int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtSoKy.Text.Trim()));
                                            ///chọn 1 kỳ cụ thể
                                            else
                                                if (cmbKy.SelectedIndex > 0)
                                                    dt = _cHoaDon.GetDSTon_To("CQ", int.Parse(cmbTo.SelectedValue.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                                }
                    }

                    foreach (DataRow item in dt.Rows)
                    {
                        if (_cDCHD.CheckExist(item["SoHoaDon"].ToString()))
                        {
                            DataTable dtDCHD = _cDCHD.GetChuanThu(item["SoHoaDon"].ToString());
                            item["GiaBan"] = long.Parse(item["GiaBan"].ToString()) - int.Parse(dtDCHD.Rows[0]["GIABAN_END"].ToString()) + int.Parse(dtDCHD.Rows[0]["GIABAN_BD"].ToString());
                            item["ThueGTGT"] = long.Parse(item["ThueGTGT"].ToString()) - int.Parse(dtDCHD.Rows[0]["THUEGTGT_END"].ToString()) + int.Parse(dtDCHD.Rows[0]["THUEGTGT_BD"].ToString());
                            item["PhiBVMT"] = long.Parse(item["PhiBVMT"].ToString()) - int.Parse(dtDCHD.Rows[0]["PHIBVMT_END"].ToString()) + int.Parse(dtDCHD.Rows[0]["PHIBVMT_BD"].ToString());
                            item["TongCong"] = long.Parse(item["TongCong"].ToString()) - int.Parse(dtDCHD.Rows[0]["TONGCONG_END"].ToString()) + int.Parse(dtDCHD.Rows[0]["TONGCONG_BD"].ToString());
                        }
                    }

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

                    XuatExcel(dt, oSheet, "CƠ QUAN");
                }
        }

        private void XuatExcel(DataTable dt, Microsoft.Office.Interop.Excel.Worksheet oSheet, string SheetName)
        {
            oSheet.Name = SheetName;
            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A1", "A1");
            cl1.Value2 = "Số Hóa Đơn";
            cl1.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B1", "B1");
            cl2.Value2 = "Kỳ";
            cl2.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C1", "C1");
            cl3.Value2 = "Danh Bộ";
            cl3.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D1", "D1");
            cl4.Value2 = "Khách Hàng";
            cl4.ColumnWidth = 30;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E1", "E1");
            cl5.Value2 = "MLT";
            cl5.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F1", "F1");
            cl6.Value2 = "Giá Bán";
            cl6.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G1", "G1");
            cl7.Value2 = "Thuế GTGT";
            cl7.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H1", "H1");
            cl8.Value2 = "Phí BVMT";
            cl8.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I1", "I1");
            cl9.Value2 = "Tổng Cộng";
            cl9.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("J1", "J1");
            cl10.Value2 = "Hành Thu";
            cl10.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl11 = oSheet.get_Range("K1", "K1");
            cl11.Value2 = "Tổ";
            cl11.ColumnWidth = 5;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[dt.Rows.Count, 13];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                arr[i, 0] = dr["SoHoaDon"].ToString();
                arr[i, 1] = dr["Ky"].ToString();
                arr[i, 2] = dr["DanhBo"].ToString();
                arr[i, 3] = dr["HoTen"].ToString();
                arr[i, 4] = dr["MLT"].ToString();
                arr[i, 5] = dr["GiaBan"].ToString();
                arr[i, 6] = dr["ThueGTGT"].ToString();
                arr[i, 7] = dr["PhiBVMT"].ToString();
                arr[i, 8] = dr["TongCong"].ToString();
                arr[i, 9] = dr["HanhThu"].ToString();
                arr[i, 10] = dr["To"].ToString();
            }

            //Thiết lập vùng điền dữ liệu
            int rowStart = 2;
            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count - 1;
            int columnEnd = 11;

            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            Microsoft.Office.Interop.Excel.Range c1a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 1];
            Microsoft.Office.Interop.Excel.Range c2a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 1];
            Microsoft.Office.Interop.Excel.Range c3a = oSheet.get_Range(c1a, c2a);
            oSheet.get_Range(c2a, c3a).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            Microsoft.Office.Interop.Excel.Range c1b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 2];
            Microsoft.Office.Interop.Excel.Range c2b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 2];
            Microsoft.Office.Interop.Excel.Range c3b = oSheet.get_Range(c1b, c2b);
            oSheet.get_Range(c2b, c3b).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            oSheet.get_Range(c2b, c3b).NumberFormat = "@";

            Microsoft.Office.Interop.Excel.Range c1c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 3];
            Microsoft.Office.Interop.Excel.Range c2c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 3];
            Microsoft.Office.Interop.Excel.Range c3c = oSheet.get_Range(c1c, c2c);
            oSheet.get_Range(c2c, c3c).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            Microsoft.Office.Interop.Excel.Range c1d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 4];
            Microsoft.Office.Interop.Excel.Range c2d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 4];
            Microsoft.Office.Interop.Excel.Range c3d = oSheet.get_Range(c1d, c2d);
            oSheet.get_Range(c2d, c3d).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            //Microsoft.Office.Interop.Excel.Range c1e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 5];
            //Microsoft.Office.Interop.Excel.Range c2e = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 5];
            //Microsoft.Office.Interop.Excel.Range c3e = oSheet.get_Range(c1e, c2e);
            //oSheet.get_Range(c2e, c3e).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            //Microsoft.Office.Interop.Excel.Range c1f = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 6];
            //Microsoft.Office.Interop.Excel.Range c2f = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 6];
            //Microsoft.Office.Interop.Excel.Range c3f = oSheet.get_Range(c1f, c2f);
            //oSheet.get_Range(c2f, c3f).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;
        }

        private void chkNgayKiemTra_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNgayKiemTra.Checked)
                dateGiaiTrach.Enabled = true;
            else
                dateGiaiTrach.Enabled = false;
        }

        private void btnInDSNVThucTe_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dsBaoCao ds = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                if (chkKyKiemTra.Checked && chkNgayKiemTra.Checked)
                {
                    dt = _cHoaDon.GetDSTonDenKyDenNgay_NV("TG", int.Parse(dgvNhanVien.SelectedRows[0].Cells["MaNV_NV"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                }
                else
                    if (chkKyKiemTra.Checked)
                    {
                        dt = _cHoaDon.GetDSTonDenKy_NV("TG", int.Parse(dgvNhanVien.SelectedRows[0].Cells["MaNV_NV"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                    }
                    else
                        if (chkNgayKiemTra.Checked)
                        {
                            dt = _cHoaDon.GetDSTon_NV("TG", int.Parse(dgvNhanVien.SelectedRows[0].Cells["MaNV_NV"].Value.ToString()), dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                        }
                        else
                        {
                            if (cmbNam.SelectedIndex == 0)
                                dt = _cHoaDon.GetDSTon_NV("TG", int.Parse(dgvNhanVien.SelectedRows[0].Cells["MaNV_NV"].Value.ToString()), int.Parse(txtSoKy.Text.Trim()));
                            else
                                if (cmbNam.SelectedIndex > 0)
                                    if (cmbKy.SelectedIndex == 0)
                                        dt = _cHoaDon.GetDSTon_NV("TG", int.Parse(dgvNhanVien.SelectedRows[0].Cells["MaNV_NV"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtSoKy.Text.Trim()));
                                    else
                                        if (cmbKy.SelectedIndex > 1)
                                            dt = _cHoaDon.GetDSTon_NV("TG", int.Parse(dgvNhanVien.SelectedRows[0].Cells["MaNV_NV"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                        }
                foreach (DataRow item in dt.Rows)
                    if (!_cDongNuoc.CheckCTDongNuocBySoHoaDon(item["SoHoaDon"].ToString()) && !_cLenhHuy.CheckExist(item["SoHoaDon"].ToString()) && !_cDLKH.CheckExistSoHoaDon(item["SoHoaDon"].ToString()))
                    {
                        DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                        dr["LoaiBaoCao"] = "TƯ GIA TỒN";
                        dr["DanhBo"] = item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
                        dr["Ky"] = item["Ky"];
                        dr["MLT"] = item["MLT"];
                        dr["TongCong"] = item["TongCong"];
                        dr["SoPhatHanh"] = item["SoPhatHanh"];
                        dr["SoHoaDon"] = item["SoHoaDon"];
                        dr["NhanVien"] = dgvNhanVien.SelectedRows[0].Cells["HoTen_NV"].Value.ToString();
                        ds.Tables["DSHoaDon"].Rows.Add(dr);
                    }
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    if (chkKyKiemTra.Checked && chkNgayKiemTra.Checked)
                    {
                        dt = _cHoaDon.GetDSTonDenKyDenNgay_NV("CQ", int.Parse(dgvNhanVien.SelectedRows[0].Cells["MaNV_NV"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                    }
                    else
                        if (chkKyKiemTra.Checked)
                        {
                            dt = _cHoaDon.GetDSTonDenKy_NV("CQ", int.Parse(dgvNhanVien.SelectedRows[0].Cells["MaNV_NV"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                        }
                        else
                            if (chkNgayKiemTra.Checked)
                            {
                                dt = _cHoaDon.GetDSTon_NV("CQ", int.Parse(dgvNhanVien.SelectedRows[0].Cells["MaNV_NV"].Value.ToString()), dateGiaiTrach.Value, int.Parse(txtSoKy.Text.Trim()));
                            }
                            else
                            {
                                if (cmbNam.SelectedIndex == 0)
                                    dt = _cHoaDon.GetDSTon_NV("CQ", int.Parse(dgvNhanVien.SelectedRows[0].Cells["MaNV_NV"].Value.ToString()), int.Parse(txtSoKy.Text.Trim()));
                                else
                                    if (cmbNam.SelectedIndex > 0)
                                        if (cmbKy.SelectedIndex == 0)
                                            dt = _cHoaDon.GetDSTon_NV("CQ", int.Parse(dgvNhanVien.SelectedRows[0].Cells["MaNV_NV"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(txtSoKy.Text.Trim()));
                                        else
                                            if (cmbKy.SelectedIndex > 1)
                                                dt = _cHoaDon.GetDSTon_NV("CQ", int.Parse(dgvNhanVien.SelectedRows[0].Cells["MaNV_NV"].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(txtSoKy.Text.Trim()));
                            }
                    foreach (DataRow item in dt.Rows)
                        if (!_cDongNuoc.CheckCTDongNuocBySoHoaDon(item["SoHoaDon"].ToString()) && !_cLenhHuy.CheckExist(item["SoHoaDon"].ToString()) && !_cDLKH.CheckExistSoHoaDon(item["SoHoaDon"].ToString()))
                        {
                            DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                            dr["LoaiBaoCao"] = "CƠ QUAN TỒN";
                            dr["DanhBo"] = item["DanhBo"].ToString().Insert(4, " ").Insert(8, " ");
                            dr["Ky"] = item["Ky"];
                            dr["MLT"] = item["MLT"];
                            dr["TongCong"] = item["TongCong"];
                            dr["SoPhatHanh"] = item["SoPhatHanh"];
                            dr["SoHoaDon"] = item["SoHoaDon"];
                            dr["NhanVien"] = dgvNhanVien.SelectedRows[0].Cells["HoTen_NV"].Value.ToString();
                            ds.Tables["DSHoaDon"].Rows.Add(dr);
                        }
                }
            rptDSHoaDon rpt = new rptDSHoaDon();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }


    }
}
