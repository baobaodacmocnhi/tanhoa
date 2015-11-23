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
using System.Globalization;
using ThuTien.LinQ;
using ThuTien.DAL.TongHop;
using ThuTien.BaoCao.Doi;
using ThuTien.GUI.BaoCao;
using ThuTien.BaoCao;

namespace ThuTien.GUI.Doi
{
    public partial class frmChuanThu : Form
    {
        CTo _cTo = new CTo();
        CHoaDon _cHoaDon = new CHoaDon();
        CDCHD _cDCHD = new CDCHD();
        List<TT_To> _lstTo;

        public frmChuanThu()
        {
            InitializeComponent();
        }

        private void frmChuanThu_Load(object sender, EventArgs e)
        {
            dgvHDTuGia.AutoGenerateColumns = false;
            dgvHDCoQuan.AutoGenerateColumns = false;
            dgvNhanVien.AutoGenerateColumns = false;

            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";

            _lstTo = _cTo.GetDSHanhThu();
        }

        public void CountdgvHDTuGia()
        {
            int TongHD = 0;
            long TongGiaBan = 0;
            long TongCong = 0;
            int TongHDThu = 0;
            long TongGiaBanThu = 0;
            long TongCongThu = 0;
            int TongHDTon = 0;
            long TongGiaBanTon = 0;
            long TongCongTon = 0;

            if (dgvHDTuGia.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    if (!string.IsNullOrEmpty(item.Cells["TongHD_TG"].Value.ToString()))
                    TongHD += int.Parse(item.Cells["TongHD_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBan_TG"].Value.ToString()))
                        TongGiaBan += long.Parse(item.Cells["TongGiaBan_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCong_TG"].Value.ToString()))
                        TongCong += long.Parse(item.Cells["TongCong_TG"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDThu_TG"].Value.ToString()))
                    TongHDThu += int.Parse(item.Cells["TongHDThu_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBanThu_TG"].Value.ToString()))
                        TongGiaBanThu += long.Parse(item.Cells["TongGiaBanThu_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongThu_TG"].Value.ToString()))
                        TongCongThu += long.Parse(item.Cells["TongCongThu_TG"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDTon_TG"].Value.ToString()))
                    TongHDTon += int.Parse(item.Cells["TongHDTon_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBanTon_TG"].Value.ToString()))
                        TongGiaBanTon += long.Parse(item.Cells["TongGiaBanTon_TG"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongTon_TG"].Value.ToString()))
                        TongCongTon += long.Parse(item.Cells["TongCongTon_TG"].Value.ToString());
                    
                    if (string.IsNullOrEmpty(item.Cells["TongGiaBanThu_TG"].Value.ToString()))
                        item.Cells["TiLeGiaBan_TG"].Value = "0%";
                    else
                        item.Cells["TiLeGiaBan_TG"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongGiaBanThu_TG"].Value.ToString()) / double.Parse(item.Cells["TongGiaBan_TG"].Value.ToString())) * 100);
                    if (string.IsNullOrEmpty(item.Cells["TongCongThu_TG"].Value.ToString()))
                        item.Cells["TiLeTongCong_TG"].Value = "0%";
                    else
                        item.Cells["TiLeTongCong_TG"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongCongThu_TG"].Value.ToString()) / double.Parse(item.Cells["TongCong_TG"].Value.ToString())) * 100);
                }
                txtTongHD_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHD);
                txtTongGiaBan_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBan);
                txtTongCong_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
                txtTongHDThu_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDThu);
                txtTongGiaBanThu_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanThu);
                txtTongCongThu_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongThu);
                txtTongHDTon_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDTon);
                txtTongGiaBanTon_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanTon);
                txtTongCongTon_TG.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongTon);
            }
        }

        public void CountdgvHDCoQuan()
        {
            int TongHD = 0;
            long TongGiaBan = 0;
            long TongCong = 0;
            int TongHDThu = 0;
            long TongGiaBanThu = 0;
            long TongCongThu = 0;
            int TongHDTon = 0;
            long TongGiaBanTon = 0;
            long TongCongTon = 0;

            if (dgvHDCoQuan.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                {
                    if (!string.IsNullOrEmpty(item.Cells["TongHD_CQ"].Value.ToString()))
                    TongHD += int.Parse(item.Cells["TongHD_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBan_CQ"].Value.ToString()))
                        TongGiaBan += long.Parse(item.Cells["TongGiaBan_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCong_CQ"].Value.ToString()))
                        TongCong += long.Parse(item.Cells["TongCong_CQ"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDThu_CQ"].Value.ToString()))
                    TongHDThu += int.Parse(item.Cells["TongHDThu_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBanThu_CQ"].Value.ToString()))
                        TongGiaBanThu += long.Parse(item.Cells["TongGiaBanThu_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongThu_CQ"].Value.ToString()))
                        TongCongThu += long.Parse(item.Cells["TongCongThu_CQ"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDTon_CQ"].Value.ToString()))
                    TongHDTon += int.Parse(item.Cells["TongHDTon_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBanTon_CQ"].Value.ToString()))
                        TongGiaBanTon += long.Parse(item.Cells["TongGiaBanTon_CQ"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongTon_CQ"].Value.ToString()))
                        TongCongTon += long.Parse(item.Cells["TongCongTon_CQ"].Value.ToString());
                    
                    if (string.IsNullOrEmpty(item.Cells["TongGiaBanThu_CQ"].Value.ToString()))
                        item.Cells["TiLeGiaBan_CQ"].Value = "0%";
                    else
                        item.Cells["TiLeGiaBan_CQ"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongGiaBanThu_CQ"].Value.ToString()) / double.Parse(item.Cells["TongGiaBan_CQ"].Value.ToString())) * 100);
                    if (string.IsNullOrEmpty(item.Cells["TongCongThu_CQ"].Value.ToString()))
                        item.Cells["TiLeTongCong_CQ"].Value = "0%";
                    else
                        item.Cells["TiLeTongCong_CQ"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongCongThu_CQ"].Value.ToString()) / double.Parse(item.Cells["TongCong_CQ"].Value.ToString())) * 100);
                }
                txtTongHD_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHD);
                txtTongGiaBan_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBan);
                txtTongCong_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
                txtTongHDThu_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDThu);
                txtTongGiaBanThu_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanThu);
                txtTongCongThu_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongThu);
                txtTongHDTon_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDTon);
                txtTongGiaBanTon_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanTon);
                txtTongCongTon_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongTon);
            }
        }

        public void CountdgvNhanVien()
        {
            int TongHD = 0;
            long TongGiaBan = 0;
            long TongCong = 0;
            int TongHDThu = 0;
            long TongGiaBanThu = 0;
            long TongCongThu = 0;
            int TongHDTon = 0;
            long TongGiaBanTon = 0;
            long TongCongTon = 0;

            if (dgvNhanVien.RowCount > 0)
            {
                foreach (DataGridViewRow item in dgvNhanVien.Rows)
                {
                    if (!string.IsNullOrEmpty(item.Cells["TongHD_NV"].Value.ToString()))
                    TongHD += int.Parse(item.Cells["TongHD_NV"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBan_NV"].Value.ToString()))
                        TongGiaBan += long.Parse(item.Cells["TongGiaBan_NV"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCong_NV"].Value.ToString()))
                        TongCong += long.Parse(item.Cells["TongCong_NV"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDThu_NV"].Value.ToString()))
                    TongHDThu += int.Parse(item.Cells["TongHDThu_NV"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBanThu_NV"].Value.ToString()))
                        TongGiaBanThu += long.Parse(item.Cells["TongGiaBanThu_NV"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongThu_NV"].Value.ToString()))
                        TongCongThu += long.Parse(item.Cells["TongCongThu_NV"].Value.ToString());

                    if (!string.IsNullOrEmpty(item.Cells["TongHDTon_NV"].Value.ToString()))
                    TongHDTon += int.Parse(item.Cells["TongHDTon_NV"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongGiaBanTon_NV"].Value.ToString()))
                        TongGiaBanTon += long.Parse(item.Cells["TongGiaBanTon_NV"].Value.ToString());
                    if (!string.IsNullOrEmpty(item.Cells["TongCongTon_NV"].Value.ToString()))
                        TongCongTon += long.Parse(item.Cells["TongCongTon_NV"].Value.ToString());
                    
                    if (string.IsNullOrEmpty(item.Cells["TongGiaBanThu_NV"].Value.ToString()))
                        item.Cells["TiLeGiaBan_NV"].Value = "0%";
                    else
                        item.Cells["TiLeGiaBan_NV"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongGiaBanThu_NV"].Value.ToString()) / double.Parse(item.Cells["TongGiaBan_NV"].Value.ToString())) * 100);
                    if (string.IsNullOrEmpty(item.Cells["TongCongThu_NV"].Value.ToString()))
                        item.Cells["TiLeTongCong_NV"].Value = "0%";
                    else
                        item.Cells["TiLeTongCong_NV"].Value = String.Format("{0:0.00}%", (double.Parse(item.Cells["TongCongThu_NV"].Value.ToString()) / double.Parse(item.Cells["TongCong_NV"].Value.ToString())) * 100);
                }
                txtTongHD_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHD);
                txtTongGiaBan_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBan);
                txtTongCong_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
                txtTongHDThu_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDThu);
                txtTongGiaBanThu_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanThu);
                txtTongCongThu_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongThu);
                txtTongHDTon_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDTon);
                txtTongGiaBanTon_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanTon);
                txtTongCongTon_CQ.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCongTon);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dtDCHD = new DataTable();

            if (tabControl.SelectedTab.Name == "tabTuGia")
            {
                if (chkNgayKiemTra.Checked)
                {
                    dt = _cHoaDon.GetNangSuat_Doi("TG", _lstTo[0].MaTo,int.Parse(cmbNam.SelectedValue.ToString()),int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
                    dtDCHD = _cDCHD.GetChuanThu("TG", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
                    for (int i = 1; i < _lstTo.Count; i++)
                    {
                        dt.Merge(_cHoaDon.GetNangSuat_Doi("TG", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value));
                        dtDCHD.Merge(_cDCHD.GetChuanThu("TG", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value));
                    }

                    foreach (DataRow item in dtDCHD.Rows)
                    {
                        if (!string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()))
                        {
                            //string[] date = item["NgayGiaiTrach"].ToString().Split('/');
                            //string[] year = date[2].Split(' ');
                            //string[] time = year[1].Split(':');
                            //DateTime NgayGiaiTrach = new DateTime(int.Parse(year[0]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
                            DateTime NgayGiaiTrach = DateTime.Parse(item["NgayGiaiTrach"].ToString());

                            if (NgayGiaiTrach.Date <= dateGiaiTrach.Value.Date)
                            {
                                DataRow[] dr = dt.Select("MaTo=" + item["MaTo"].ToString());

                                dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                                dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                                dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanThu"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanThu"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                                dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongThu"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongThu"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                            }
                            else
                            {
                                DataRow[] dr = dt.Select("MaTo=" + item["MaTo"].ToString());

                                dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                                dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                                dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanTon"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanTon"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                                dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTon"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTon"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                            }
                        }
                        else
                        {
                            DataRow[] dr = dt.Select("MaTo=" + item["MaTo"].ToString());

                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanTon"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanTon"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTon"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTon"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                        }
                    }
                }
                else
                {
                    ///chọn tất cả các kỳ
                    if (cmbKy.SelectedIndex == 0)
                    {
                        dt = _cHoaDon.GetNangSuat_Doi("TG", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()));
                        dtDCHD = _cDCHD.GetChuanThu("TG", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()));
                        for (int i = 1; i < _lstTo.Count; i++)
                        {
                            dt.Merge(_cHoaDon.GetNangSuat_Doi("TG", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString())));
                            dtDCHD.Merge(_cDCHD.GetChuanThu("TG", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString())));
                        }
                    }
                    else
                        ///chọn 1 kỳ cụ thể
                        if (cmbKy.SelectedIndex > 0)
                            ///chọn tất cả đợt
                            if (cmbDot.SelectedIndex == 0)
                            {
                                dt = _cHoaDon.GetNangSuat_Doi("TG", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                dtDCHD = _cDCHD.GetChuanThu("TG", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                for (int i = 1; i < _lstTo.Count; i++)
                                {
                                    dt.Merge(_cHoaDon.GetNangSuat_Doi("TG", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString())));
                                    dtDCHD.Merge(_cDCHD.GetChuanThu("TG", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString())));
                                }
                            }
                            else
                                ///chọn 1 đợt cụ thể
                                if (cmbDot.SelectedIndex > 0)
                                {
                                    dt = _cHoaDon.GetNangSuat_Doi("TG", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
                                    dtDCHD = _cDCHD.GetChuanThu("TG", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
                                    for (int i = 1; i < _lstTo.Count; i++)
                                    {
                                        dt.Merge(_cHoaDon.GetNangSuat_Doi("TG", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString())));
                                        dtDCHD.Merge(_cDCHD.GetChuanThu("TG", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString())));
                                    }
                                }
                    foreach (DataRow item in dtDCHD.Rows)
                    {
                        if (!string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()))
                        {
                            DataRow[] dr = dt.Select("MaTo=" + item["MaTo"].ToString());

                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanThu"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanThu"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongThu"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongThu"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                        }
                        else
                        {
                            DataRow[] dr = dt.Select("MaTo=" + item["MaTo"].ToString());

                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanTon"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanTon"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTon"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTon"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                        }
                    }
                }
                dgvHDTuGia.DataSource = dt;
                CountdgvHDTuGia();
            }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                {
                    if (chkNgayKiemTra.Checked)
                    {
                        dt = _cHoaDon.GetNangSuat_Doi("CQ", _lstTo[0].MaTo,int.Parse(cmbNam.SelectedValue.ToString()),int.Parse(cmbKy.SelectedItem.ToString()) ,dateGiaiTrach.Value);
                        dtDCHD = _cDCHD.GetChuanThu("CQ", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
                        for (int i = 1; i < _lstTo.Count; i++)
                        {
                            dt.Merge(_cHoaDon.GetNangSuat_Doi("CQ", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value));
                            dtDCHD.Merge(_cDCHD.GetChuanThu("CQ", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value));
                        }

                        foreach (DataRow item in dtDCHD.Rows)
                        {
                            if (!string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()))
                            {
                                //string[] date = item["NgayGiaiTrach"].ToString().Split('/');
                                //string[] year = date[2].Split(' ');
                                //string[] time = year[1].Split(':');
                                //DateTime NgayGiaiTrach = new DateTime(int.Parse(year[0]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
                                DateTime NgayGiaiTrach = DateTime.Parse(item["NgayGiaiTrach"].ToString());

                                if (NgayGiaiTrach.Date <= dateGiaiTrach.Value.Date)
                                {
                                    DataRow[] dr = dt.Select("MaTo=" + item["MaTo"].ToString());

                                    dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                                    dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                                    dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanThu"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanThu"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                                    dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongThu"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongThu"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                                }
                                else
                                {
                                    DataRow[] dr = dt.Select("MaTo=" + item["MaTo"].ToString());

                                    dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                                    dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                                    dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanTon"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanTon"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                                    dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTon"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTon"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                                }
                            }
                            else
                            {
                                DataRow[] dr = dt.Select("MaTo=" + item["MaTo"].ToString());

                                dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                                dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                                dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanTon"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanTon"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                                dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTon"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTon"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                            }
                        }
                    }
                    else
                    {
                        ///chọn tất cả các kỳ
                        if (cmbKy.SelectedIndex == 0)
                        {
                            dt = _cHoaDon.GetNangSuat_Doi("CQ", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()));
                            dtDCHD = _cDCHD.GetChuanThu("CQ", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()));
                            for (int i = 1; i < _lstTo.Count; i++)
                            {
                                dt.Merge(_cHoaDon.GetNangSuat_Doi("CQ", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString())));
                                dtDCHD.Merge(_cDCHD.GetChuanThu("CQ", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString())));
                            }
                        }
                        else
                            ///chọn 1 kỳ cụ thể
                            if (cmbKy.SelectedIndex > 0)
                                ///chọn tất cả đợt
                                if (cmbDot.SelectedIndex == 0)
                                {
                                    dt = _cHoaDon.GetNangSuat_Doi("CQ", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                    dtDCHD = _cDCHD.GetChuanThu("CQ", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                                    for (int i = 1; i < _lstTo.Count; i++)
                                    {
                                        dt.Merge(_cHoaDon.GetNangSuat_Doi("CQ", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString())));
                                        dtDCHD.Merge(_cDCHD.GetChuanThu("CQ", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString())));
                                    }
                                }
                                else
                                    ///chọn 1 đợt cụ thể
                                    if (cmbDot.SelectedIndex > 0)
                                    {
                                        dt = _cHoaDon.GetNangSuat_Doi("CQ", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
                                        dtDCHD = _cDCHD.GetChuanThu("CQ", _lstTo[0].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
                                        for (int i = 1; i < _lstTo.Count; i++)
                                        {
                                            dt.Merge(_cHoaDon.GetNangSuat_Doi("CQ", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString())));
                                            dtDCHD.Merge(_cDCHD.GetChuanThu("CQ", _lstTo[i].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString())));
                                        }
                                    }

                        foreach (DataRow item in dtDCHD.Rows)
                        {
                            if (!string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()))
                            {
                                DataRow[] dr = dt.Select("MaTo=" + item["MaTo"].ToString());

                                dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                                dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                                dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanThu"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanThu"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                                dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongThu"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongThu"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                            }
                            else
                            {
                                DataRow[] dr = dt.Select("MaTo=" + item["MaTo"].ToString());

                                dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                                dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                                dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanTon"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanTon"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                                dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTon"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTon"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                            }
                        }
                    }
                    dgvHDCoQuan.DataSource = dt;
                    CountdgvHDCoQuan();
                }
        }

        private void btnInDoi_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
                foreach (DataGridViewRow item in dgvHDTuGia.Rows)
                {
                    DataRow dr = ds.Tables["NangSuatThuTien"].NewRow();
                    dr["Nam"] = cmbNam.SelectedValue.ToString();
                    dr["Ky"] = cmbKy.SelectedItem.ToString();
                    dr["Dot"] = cmbDot.SelectedItem.ToString();
                    dr["Loai"] = "TƯ GIA";
                    dr["TongHD"] = item.Cells["TongHD_TG"].Value;
                    dr["TongGiaBan"] = item.Cells["TongGiaBan_TG"].Value;
                    dr["TongCong"] = item.Cells["TongCong_TG"].Value;
                    dr["TongHDThu"] = item.Cells["TongHDThu_TG"].Value;
                    dr["TongGiaBanThu"] = item.Cells["TongGiaBanThu_TG"].Value;
                    dr["TongCongThu"] = item.Cells["TongCongThu_TG"].Value;
                    dr["TongHDTon"] = item.Cells["TongHDTon_TG"].Value;
                    dr["TongGiaBanTon"] = item.Cells["TongGiaBanTon_TG"].Value;
                    dr["TongCongTon"] = item.Cells["TongCongTon_TG"].Value;
                    dr["NhanVien"] = item.Cells["TenTo_TG"].Value;
                    dr["TiLeGiaBan"] = item.Cells["TiLeGiaBan_TG"].Value;
                    dr["TiLeTongCong"] = item.Cells["TiLeTongCong_TG"].Value;
                    ds.Tables["NangSuatThuTien"].Rows.Add(dr);
                }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                    foreach (DataGridViewRow item in dgvHDCoQuan.Rows)
                    {
                        DataRow dr = ds.Tables["NangSuatThuTien"].NewRow();
                        dr["Nam"] = cmbNam.SelectedValue.ToString();
                        dr["Ky"] = cmbKy.SelectedItem.ToString();
                        dr["Dot"] = cmbDot.SelectedItem.ToString();
                        dr["Loai"] = "CƠ QUAN";
                        dr["TongHD"] = item.Cells["TongHD_CQ"].Value;
                        dr["TongGiaBan"] = item.Cells["TongGiaBan_CQ"].Value;
                        dr["TongCong"] = item.Cells["TongCong_CQ"].Value;
                        dr["TongHDThu"] = item.Cells["TongHDThu_CQ"].Value;
                        dr["TongGiaBanThu"] = item.Cells["TongGiaBanThu_CQ"].Value;
                        dr["TongCongThu"] = item.Cells["TongCongThu_CQ"].Value;
                        dr["TongHDTon"] = item.Cells["TongHDTon_CQ"].Value;
                        dr["TongGiaBanTon"] = item.Cells["TongGiaBanTon_CQ"].Value;
                        dr["TongCongTon"] = item.Cells["TongCongTon_CQ"].Value;
                        dr["NhanVien"] = item.Cells["TenTo_CQ"].Value;
                        dr["TiLeGiaBan"] = item.Cells["TiLeGiaBan_CQ"].Value;
                        dr["TiLeTongCong"] = item.Cells["TiLeTongCong_CQ"].Value;
                        ds.Tables["NangSuatThuTien"].Rows.Add(dr);
                    }

            rptChuanThu_Doi rpt = new rptChuanThu_Doi();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void btnInTo_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            if (tabControl.SelectedTab.Name == "tabTuGia")
                foreach (DataGridViewRow item in dgvNhanVien.Rows)
                {
                    DataRow dr = ds.Tables["NangSuatThuTien"].NewRow();
                    dr["Nam"] = cmbNam.SelectedValue.ToString();
                    dr["Ky"] = cmbKy.SelectedItem.ToString();
                    dr["Dot"] = cmbDot.SelectedItem.ToString();
                    dr["To"] = dgvHDTuGia.SelectedRows[0].Cells["TenTo_TG"].Value.ToString();
                    dr["Loai"] = "TƯ GIA";
                    dr["TongHD"] = item.Cells["TongHD_NV"].Value;
                    dr["TongGiaBan"] = item.Cells["TongGiaBan_NV"].Value;
                    dr["TongCong"] = item.Cells["TongCong_NV"].Value;
                    dr["TongHDThu"] = item.Cells["TongHDThu_NV"].Value;
                    dr["TongGiaBanThu"] = item.Cells["TongGiaBanThu_NV"].Value;
                    dr["TongCongThu"] = item.Cells["TongCongThu_NV"].Value;
                    dr["TongHDTon"] = item.Cells["TongHDTon_NV"].Value;
                    dr["TongGiaBanTon"] = item.Cells["TongGiaBanTon_NV"].Value;
                    dr["TongCongTon"] = item.Cells["TongCongTon_NV"].Value;
                    dr["NhanVien"] = item.Cells["HoTen_NV"].Value;
                    dr["TiLeGiaBan"] = item.Cells["TiLeGiaBan_NV"].Value;
                    dr["TiLeTongCong"] = item.Cells["TiLeTongCong_NV"].Value;
                    ds.Tables["NangSuatThuTien"].Rows.Add(dr);
                }
            else
                if (tabControl.SelectedTab.Name == "tabCoQuan")
                    foreach (DataGridViewRow item in dgvNhanVien.Rows)
                    {
                        DataRow dr = ds.Tables["NangSuatThuTien"].NewRow();
                        dr["Nam"] = cmbNam.SelectedValue.ToString();
                        dr["Ky"] = cmbKy.SelectedItem.ToString();
                        dr["Dot"] = cmbDot.SelectedItem.ToString();
                        dr["To"] = dgvHDCoQuan.SelectedRows[0].Cells["TenTo_CQ"].Value.ToString();
                        dr["Loai"] = "CƠ QUAN";
                        dr["TongHD"] = item.Cells["TongHD_NV"].Value;
                        dr["TongGiaBan"] = item.Cells["TongGiaBan_NV"].Value;
                        dr["TongCong"] = item.Cells["TongCong_NV"].Value;
                        dr["TongHDThu"] = item.Cells["TongHDThu_NV"].Value;
                        dr["TongGiaBanThu"] = item.Cells["TongGiaBanThu_NV"].Value;
                        dr["TongCongThu"] = item.Cells["TongCongThu_NV"].Value;
                        dr["TongHDTon"] = item.Cells["TongHDTon_NV"].Value;
                        dr["TongGiaBanTon"] = item.Cells["TongGiaBanTon_NV"].Value;
                        dr["TongCongTon"] = item.Cells["TongCongTon_NV"].Value;
                        dr["NhanVien"] = item.Cells["HoTen_NV"].Value;
                        dr["TiLeGiaBan"] = item.Cells["TiLeGiaBan_NV"].Value;
                        dr["TiLeTongCong"] = item.Cells["TiLeTongCong_NV"].Value;
                        ds.Tables["NangSuatThuTien"].Rows.Add(dr);
                    }

            rptChuanThu_To rpt = new rptChuanThu_To();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void dgvHDTuGia_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongHD_TG" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongGiaBan_TG" && e.Value != null)
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
            if (dgvHDTuGia.Columns[e.ColumnIndex].Name == "TongGiaBanThu_TG" && e.Value != null)
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
        }

        private void dgvHDCoQuan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongHD_CQ" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongGiaBan_CQ" && e.Value != null)
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
            if (dgvHDCoQuan.Columns[e.ColumnIndex].Name == "TongGiaBanThu_CQ" && e.Value != null)
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
            if (chkNgayKiemTra.Checked)
            {
                dt = _cHoaDon.GetNangSuat_To("TG", int.Parse(dgvHDTuGia["MaTo_TG", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
                dtDCHD = _cDCHD.GetChuanThu("TG", int.Parse(dgvHDTuGia["MaTo_TG", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);

                foreach (DataRow item in dtDCHD.Rows)
                {
                    if (!string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()))
                    {
                        //string[] date = item["NgayGiaiTrach"].ToString().Split('/');
                        //string[] year = date[2].Split(' ');
                        //string[] time = year[1].Split(':');
                        //DateTime NgayGiaiTrach = new DateTime(int.Parse(year[0]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
                        DateTime NgayGiaiTrach = DateTime.Parse(item["NgayGiaiTrach"].ToString());

                        if (NgayGiaiTrach.Date <= dateGiaiTrach.Value.Date)
                        {
                            DataRow[] dr = dt.Select("MaNV=" + item["MaNV"].ToString());

                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanThu"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanThu"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongThu"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongThu"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                        }
                        else
                        {
                            DataRow[] dr = dt.Select("MaNV=" + item["MaNV"].ToString());

                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanTon"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanTon"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTon"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTon"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                        }
                    }
                    else
                    {
                        DataRow[] dr = dt.Select("MaNV=" + item["MaNV"].ToString());

                        dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                        dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                        dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanTon"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanTon"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                        dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTon"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTon"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                    }
                }
            }
            else
            {
                ///chọn tất cả các kỳ
                if (cmbKy.SelectedIndex == 0)
                {
                    dt = _cHoaDon.GetNangSuat_To("TG", int.Parse(dgvHDTuGia["MaTo_TG", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()));
                    dtDCHD = _cDCHD.GetChuanThu("TG", int.Parse(dgvHDTuGia["MaTo_TG", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()));
                }
                else
                    ///chọn 1 kỳ cụ thể
                    if (cmbKy.SelectedIndex > 0)
                        ///chọn tất cả đợt
                        if (cmbDot.SelectedIndex == 0)
                        {
                            dt = _cHoaDon.GetNangSuat_To("TG", int.Parse(dgvHDTuGia["MaTo_TG", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                            dtDCHD = _cDCHD.GetChuanThu("TG", int.Parse(dgvHDTuGia["MaTo_TG", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                        }
                        else
                            ///chọn 1 đợt cụ thể
                            if (cmbDot.SelectedIndex > 0)
                            {
                                dt = _cHoaDon.GetNangSuat_To("TG", int.Parse(dgvHDTuGia["MaTo_TG", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
                                dtDCHD = _cDCHD.GetChuanThu("TG", int.Parse(dgvHDTuGia["MaTo_TG", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
                            }
                foreach (DataRow item in dtDCHD.Rows)
                {
                    if (!string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()))
                    {
                        DataRow[] dr = dt.Select("MaNV=" + item["MaNV"].ToString());

                        dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                        dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                        dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanThu"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanThu"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                        dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongThu"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongThu"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                    }
                    else
                    {
                        DataRow[] dr = dt.Select("MaNV=" + item["MaNV"].ToString());

                        dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                        dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                        dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanTon"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanTon"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                        dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTon"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTon"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                    }
                }
            }
            dgvNhanVien.DataSource = dt;
            CountdgvNhanVien();
        }

        private void dgvHDCoQuan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dtDCHD = new DataTable();
            if (chkNgayKiemTra.Checked)
            {
                dt = _cHoaDon.GetNangSuat_To("CQ", int.Parse(dgvHDCoQuan["MaTo_CQ", e.RowIndex].Value.ToString()),int.Parse(cmbNam.SelectedValue.ToString()),int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);
                dtDCHD = _cDCHD.GetChuanThu("CQ", int.Parse(dgvHDCoQuan["MaTo_CQ", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), dateGiaiTrach.Value);

                foreach (DataRow item in dtDCHD.Rows)
                {
                    if (!string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()))
                    {
                        //string[] date = item["NgayGiaiTrach"].ToString().Split('/');
                        //string[] year = date[2].Split(' ');
                        //string[] time = year[1].Split(':');
                        //DateTime NgayGiaiTrach = new DateTime(int.Parse(year[0]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
                        DateTime NgayGiaiTrach = DateTime.Parse(item["NgayGiaiTrach"].ToString());

                        if (NgayGiaiTrach.Date <= dateGiaiTrach.Value.Date)
                        {
                            DataRow[] dr = dt.Select("MaNV=" + item["MaNV"].ToString());

                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanThu"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanThu"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongThu"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongThu"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                        }
                        else
                        {
                            DataRow[] dr = dt.Select("MaNV=" + item["MaNV"].ToString());

                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanTon"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanTon"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                            dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTon"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTon"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                        }
                    }
                    else
                    {
                        DataRow[] dr = dt.Select("MaNV=" + item["MaNV"].ToString());

                        dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                        dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                        dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanTon"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanTon"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                        dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTon"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTon"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                    }
                }
            }
            else
            {
                ///chọn tất cả các kỳ
                if (cmbKy.SelectedIndex == 0)
                {
                    dt = _cHoaDon.GetNangSuat_To("CQ", int.Parse(dgvHDCoQuan["MaTo_CQ", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()));
                    dtDCHD = _cDCHD.GetChuanThu("CQ", int.Parse(dgvHDCoQuan["MaTo_CQ", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()));
                }
                else
                    ///chọn 1 kỳ cụ thể
                    if (cmbKy.SelectedIndex > 0)
                        ///chọn tất cả đợt
                        if (cmbDot.SelectedIndex == 0)
                        {
                            dt = _cHoaDon.GetNangSuat_To("CQ", int.Parse(dgvHDCoQuan["MaTo_CQ", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                            dtDCHD = _cDCHD.GetChuanThu("CQ", int.Parse(dgvHDCoQuan["MaTo_CQ", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                        }
                        else
                            ///chọn 1 đợt cụ thể
                            if (cmbDot.SelectedIndex > 0)
                            {
                                dt = _cHoaDon.GetNangSuat_To("CQ", int.Parse(dgvHDCoQuan["MaTo_CQ", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
                                dtDCHD = _cDCHD.GetChuanThu("CQ", int.Parse(dgvHDCoQuan["MaTo_CQ", e.RowIndex].Value.ToString()), int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(cmbDot.SelectedItem.ToString()));
                            }

                foreach (DataRow item in dtDCHD.Rows)
                {
                    if (!string.IsNullOrEmpty(item["NgayGiaiTrach"].ToString()))
                    {
                        DataRow[] dr = dt.Select("MaNV=" + item["MaNV"].ToString());

                        dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                        dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                        dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanThu"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanThu"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                        dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongThu"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongThu"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                    }
                    else
                    {
                        DataRow[] dr = dt.Select("MaNV=" + item["MaNV"].ToString());

                        dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBan"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                        dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCong"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                        dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanTon"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongGiaBanTon"].ToString()) - int.Parse(item["GIABAN_END"].ToString()) + int.Parse(item["GIABAN_BD"].ToString());
                        dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTon"] = long.Parse(dt.Rows[dt.Rows.IndexOf(dr[0])]["TongCongTon"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                    }
                }
            }
            dgvNhanVien.DataSource = dt;
            CountdgvNhanVien();
        }

        private void dgvNhanVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "TongHD_NV" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "TongGiaBan_NV" && e.Value != null)
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
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "TongGiaBanThu_NV" && e.Value != null)
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
            dt.Columns.Add("Dot");
            dt.Columns.Add("TongHD1");
            dt.Columns.Add("TongCong1");
            dt.Columns.Add("TongHD2");
            dt.Columns.Add("TongCong2");
            dt.Columns.Add("TongHD3");
            dt.Columns.Add("TongCong3");
            dt.Columns.Add("TongHD4");
            dt.Columns.Add("TongCong4");
            dt.Columns.Add("TongHD5");
            dt.Columns.Add("TongCong5");

            for (int i = 1; i <= 20; i++)
            {
                DataTable dtTemp = new DataTable();
                DataTable dtDCHDTemp = new DataTable();
                for (int j = 0; j < _lstTo.Count; j++)
                {
                    dtTemp.Merge(_cHoaDon.GetChuanThu_Doi(_lstTo[j].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), i));
                    dtDCHDTemp.Merge(_cDCHD.GetTongChuanThu(_lstTo[j].MaTo, int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), i));
                }

                foreach (DataRow item in dtDCHDTemp.Rows)
                {
                    DataRow[] drTemp = dtTemp.Select("MaTo=" + item["MaTo"].ToString());

                    dtTemp.Rows[dtTemp.Rows.IndexOf(drTemp[0])]["TongCong"] = long.Parse(dtTemp.Rows[dtTemp.Rows.IndexOf(drTemp[0])]["TongCong"].ToString()) - int.Parse(item["TONGCONG_END"].ToString()) + int.Parse(item["TONGCONG_BD"].ToString());
                }

                DataRow dr = dt.NewRow();
                foreach (DataRow item in dtTemp.Rows)
                    switch (item["TenTo"].ToString())
                    {
                        case "TB1":
                            dr["Dot"] = i;
                            dr["TongHD1"] = item["TongHD"];
                            dr["TongCong1"] = item["TongCong"];
                            break;
                        case "TB2":
                            dr["Dot"] = i;
                            dr["TongHD2"] = item["TongHD"];
                            dr["TongCong2"] = item["TongCong"];
                            break;
                        case "TP1":
                            dr["Dot"] = i;
                            dr["TongHD3"] = item["TongHD"];
                            dr["TongCong3"] = item["TongCong"];
                            break;
                        case "TP2":
                            dr["Dot"] = i;
                            dr["TongHD4"] = item["TongHD"];
                            dr["TongCong4"] = item["TongCong"];
                            break;
                        default:
                            break;
                    }
                dt.Rows.Add(dr);

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

            XuatExcel(dt, oSheet, "ĐỘI");
        }

        private void XuatExcel(DataTable dt, Microsoft.Office.Interop.Excel.Worksheet oSheet, string SheetName)
        {
            oSheet.Name = SheetName;
            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A1", "A2");
            cl1.MergeCells = true;
            cl1.Value2 = "Đợt";
            cl1.ColumnWidth = 5;
            cl1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B1", "C1");
            cl2.MergeCells = true;
            cl2.Value2 = "TB1";
            cl2.ColumnWidth = 10;
            cl2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("D1", "E1");
            cl3.MergeCells = true;
            cl3.Value2 = "TB2";
            cl3.ColumnWidth = 10;
            cl3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("F1", "G1");
            cl4.MergeCells = true;
            cl4.Value2 = "TP1";
            cl4.ColumnWidth = 10;
            cl4.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("H1", "I1");
            cl5.MergeCells = true;
            cl5.Value2 = "TP2";
            cl5.ColumnWidth = 10;
            cl5.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("J1", "K1");
            cl6.MergeCells = true;
            cl6.Value2 = "Đội";
            cl6.ColumnWidth = 10;
            cl6.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            ///Dòng 2
            Microsoft.Office.Interop.Excel.Range cl22 = oSheet.get_Range("B2", "B2");
            cl22.Value2 = "Số Hóa Đơn";
            cl22.ColumnWidth = 10;
            cl22.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl32 = oSheet.get_Range("C2", "C2");
            cl32.Value2 = "Tổng Cộng";
            cl32.ColumnWidth = 20;
            cl32.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl42 = oSheet.get_Range("D2", "D2");
            cl42.Value2 = "Số Hóa Đơn";
            cl42.ColumnWidth = 10;
            cl42.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl52 = oSheet.get_Range("E2", "E2");
            cl52.Value2 = "Tổng Cộng";
            cl52.ColumnWidth = 20;
            cl52.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl62 = oSheet.get_Range("F2", "F2");
            cl62.Value2 = "Số Hóa Đơn";
            cl62.ColumnWidth = 10;
            cl62.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl72 = oSheet.get_Range("G2", "G2");
            cl72.Value2 = "Tổng Cộng";
            cl72.ColumnWidth = 20;
            cl72.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl82 = oSheet.get_Range("H2", "H2");
            cl82.Value2 = "Số Hóa Đơn";
            cl82.ColumnWidth = 10;
            cl82.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl92 = oSheet.get_Range("I2", "I2");
            cl92.Value2 = "Tổng Cộng";
            cl92.ColumnWidth = 20;
            cl92.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl102 = oSheet.get_Range("J2", "J2");
            cl102.Value2 = "Số Hóa Đơn";
            cl102.ColumnWidth = 10;
            cl102.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl112 = oSheet.get_Range("K2", "K2");
            cl112.Value2 = "Tổng Cộng";
            cl112.ColumnWidth = 20;
            cl112.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[dt.Rows.Count, 11];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                arr[i, 0] = dr["Dot"].ToString();
                arr[i, 1] = dr["TongHD1"].ToString();
                arr[i, 2] = dr["TongCong1"].ToString();
                arr[i, 3] = dr["TongHD2"].ToString();
                arr[i, 4] = dr["TongCong2"].ToString();
                arr[i, 5] = dr["TongHD3"].ToString();
                arr[i, 6] = dr["TongCong3"].ToString();
                arr[i, 7] = dr["TongHD4"].ToString();
                arr[i, 8] = dr["TongCong4"].ToString();
                if (!string.IsNullOrEmpty(dr["TongHD1"].ToString()))
                    arr[i, 9] = long.Parse(dr["TongHD1"].ToString()) + long.Parse(dr["TongHD2"].ToString()) + long.Parse(dr["TongHD3"].ToString()) + long.Parse(dr["TongHD4"].ToString());
                if (!string.IsNullOrEmpty(dr["TongCong1"].ToString()))
                    arr[i, 10] = long.Parse(dr["TongCong1"].ToString()) + long.Parse(dr["TongCong2"].ToString()) + long.Parse(dr["TongCong3"].ToString()) + long.Parse(dr["TongCong4"].ToString());
            }

            //Thiết lập vùng điền dữ liệu
            int rowStart = 3;
            int columnStart = 1;

            int rowEnd = rowStart + dt.Rows.Count - 1;
            int columnEnd = 11;

            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

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
    }
}
