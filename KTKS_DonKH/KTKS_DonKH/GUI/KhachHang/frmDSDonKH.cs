using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.KhachHang;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.BaoCao.ToXuLy;
using KTKS_DonKH.DAL.ToXuLy;

namespace KTKS_DonKH.GUI.KhachHang
{
    public partial class frmDSDonKH : Form
    {
        CDonKH _cDonKH = new CDonKH();
        CChuyenDi _cChuyenDi = new CChuyenDi();
        DataTable DSDonKH_Edited = new DataTable();
        //BindingSource DSDonKH_BS = new BindingSource();
        CLoaiDon _cLoaiDon = new CLoaiDon();
        string _tuNgay = "", _denNgay = "";
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();
        CDonTXL _cDonTXL = new CDonTXL();

        public frmDSDonKH()
        {
            InitializeComponent();
        }

        private void frmQLDonKH_Load(object sender, EventArgs e)
        {
            dgvDSDonKH.AutoGenerateColumns = false;
            dgvDSDonKH.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSDonKH.Font, FontStyle.Bold);
            //DataGridViewComboBoxColumn cmbColumn = (DataGridViewComboBoxColumn)dgvDSDonKH.Columns["MaChuyen"];
            //cmbColumn.DataSource = _cChuyenDi.LoadDSChuyenDi();
            //cmbColumn.DisplayMember = "NoiChuyenDi";
            //cmbColumn.ValueMember = "MaChuyen";

            //dgvDSDonKH.DataSource = DSDonKH_BS;
            //radAll.Checked = true;

            cmbTimTheo.SelectedIndex = 4;
            dateTimKiem.Location = txtNoiDungTimKiem.Location;
            panel_KhoangThoiGian.Location = new Point(txtNoiDungTimKiem.Location.X, panel_KhoangThoiGian.Location.Y);
        }
            
        /// <summary>
        /// Hiện thị số thứ tự dòng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSDonKH_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSDonKH.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        /// <summary>
        /// Ctrl+F Tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSDonKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDSDonKH.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                Dictionary<string, string> source = new Dictionary<string, string>();
                source.Add("Action", "Cập Nhật");
                source.Add("MaDon", dgvDSDonKH["MaDon", dgvDSDonKH.CurrentRow.Index].Value.ToString());
                frmShowDonKH frm = new frmShowDonKH(source);
                frm.ShowDialog();
                //if (frm.ShowDialog() == DialogResult.OK)
                    //if (radChuaDuyet.Checked)
                    //    DSDonKH_BS.DataSource = _cDonKH.LoadDSDonKHChuaDuyet();
                    //else
                    //    if (radDaDuyet.Checked)
                    //        DSDonKH_BS.DataSource = _cDonKH.LoadDSDonKHDaDuyet();
                    //    else
                    //        if (radAll.Checked)
                    //            DSDonKH_BS.DataSource = _cDonKH.LoadDSAllDonKH();
            }
        }

        /// <summary>
        /// Format dữ liệu trong column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSDonKH_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSDonKH.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null&&e.Value.ToString().Length>2)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
            if (dgvDSDonKH.Columns[e.ColumnIndex].Name == "NVKiemTra")
            {
                string str = "";
                DonKH donkh = _cDonKH.getDonKHbyID(decimal.Parse(dgvDSDonKH["MaDon", e.RowIndex].Value.ToString()));
                if (donkh.ChuyenToXuLy)
                    str = ", TXL";
                e.Value = _cDonTXL.GetNVKiemTraDonKHbyMaDon(decimal.Parse(dgvDSDonKH["MaDon", e.RowIndex].Value.ToString())) + str;
            }
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                case "Danh Bộ":
                case "Số Công Văn":
                    txtNoiDungTimKiem.Visible = true;
                    txtNoiDungTimKiem2.Visible = true;
                    dateTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Ngày":
                    txtNoiDungTimKiem.Visible = false;
                    txtNoiDungTimKiem2.Visible = false;
                    dateTimKiem.Visible = true;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Khoảng Thời Gian":
                    txtNoiDungTimKiem.Visible = false;
                    txtNoiDungTimKiem2.Visible = false;
                    dateTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = true;
                    break;
                default:
                    txtNoiDungTimKiem.Visible = false;
                    txtNoiDungTimKiem2.Visible = false;
                    dateTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
                    //DSDonKH_BS.RemoveFilter();
                    break;
            }
            dgvDSDonKH.DataSource = null;
        }

        private void txtNoiDungTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if (txtNoiDungTimKiem.Text.Trim() != "")
                //{
                //    string expression = "";
                //    switch (cmbTimTheo.SelectedItem.ToString())
                //    {
                //        case "Mã Đơn":
                //            expression = String.Format("MaDon = {0}", txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                //            break;
                //        case "Danh Bộ":
                //            expression = String.Format("DanhBo like '{0}%'", txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                //            break;
                //    }
                //    DSDonKH_BS.Filter = expression;
                //}
                //else
                //    DSDonKH_BS.RemoveFilter();

                if (txtNoiDungTimKiem.Text.Trim() != "")
                {
                    switch (cmbTimTheo.SelectedItem.ToString())
                    {
                        case "Mã Đơn":
                            dgvDSDonKH.DataSource = _cDonKH.LoadDSDonKHByMaDon(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")));
                            break;
                        case "Danh Bộ":
                            dgvDSDonKH.DataSource = _cDonKH.LoadDSDonKHByDanhBo(txtNoiDungTimKiem.Text.Trim());
                            break;
                        case "Số Công Văn":
                            dgvDSDonKH.DataSource = _cDonKH.LoadDSDonKHBySoCongVan(txtNoiDungTimKiem.Text.Trim().ToUpper());
                            break;
                    }

                }
            }
            catch (Exception)
            {
                
            }
            
        }

        private void dateTimKiem_ValueChanged(object sender, EventArgs e)
        {
            //string expression = String.Format("CreateDate >= #{0:yyyy-MM-dd} 00:00:00# and CreateDate <= #{0:yyyy-MM-dd} 23:59:59#", dateTimKiem.Value);
            //DSDonKH_BS.Filter = expression;
            _tuNgay = dateTimKiem.Value.ToString("dd/MM/yyyy");
            _denNgay = "";
            dgvDSDonKH.DataSource = _cDonKH.LoadDSDonKHByDate(dateTimKiem.Value);
        }

        private void dateTu_ValueChanged(object sender, EventArgs e)
        {
            //string expression = String.Format("CreateDate >= #{0:yyyy-MM-dd} 00:00:00# and CreateDate <= #{0:yyyy-MM-dd} 23:59:59#", dateTu.Value);
            //DSDonKH_BS.Filter = expression;
            _tuNgay = dateTu.Value.ToString("dd/MM/yyyy");
            _denNgay = "";
            dgvDSDonKH.DataSource = _cDonKH.LoadDSDonKHByDate(dateTu.Value);
        }

        private void dateDen_ValueChanged(object sender, EventArgs e)
        {
            //string expression = String.Format("CreateDate >= #{0:yyyy-MM-dd} 00:00:00# and CreateDate <= #{1:yyyy-MM-dd} 23:59:59#", dateTu.Value, dateDen.Value);
            //DSDonKH_BS.Filter = expression;
            _denNgay = dateDen.Value.ToString("dd/MM/yyyy");
            dgvDSDonKH.DataSource = _cDonKH.LoadDSDonKHByDates(dateTu.Value, dateDen.Value);
        }

        private void btnInDSDonKH_Click(object sender, EventArgs e)
        {
            DataTable dt = ((DataTable)dgvDSDonKH.DataSource).DefaultView.ToTable();
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataRow itemRow in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DanhSachDonKH"].NewRow();

                dr["TuNgay"] = _tuNgay;
                dr["DenNgay"] = _denNgay;
                dr["MaLD"] = itemRow["MaLD"];
                dr["TenLD"] = itemRow["TenLD"];
                dr["NgayNhan"] = itemRow["CreateDate"].ToString().Substring(0, 10);
                DonKH donkh = _cDonKH.getDonKHbyID(decimal.Parse(itemRow["MaDon"].ToString()));
                dr["MaDon"] = itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-") + "/" + _cLoaiDon.getKyHieuLDubyID(donkh.MaLD.Value);
                //dr["MaXepDon"] = donkh.MaXepDon.ToString().Insert(donkh.MaXepDon.ToString().Length - 2, "-") + "/" + _cLoaiDon.getKyHieuLDubyID(donkh.MaLD.Value);
                if (donkh.KiemTraDHN)
                    dr["ChiTiet"] += "Kiểm Tra ĐHN, ";
                if (donkh.TienNuoc)
                    dr["ChiTiet"] += "Tiền Nước, ";
                if (donkh.ChiSoNuoc)
                    dr["ChiTiet"] += "Chỉ Số Nước, ";
                if (donkh.DonGiaNuoc)
                    dr["ChiTiet"] += "Đơn Giá Nước, ";
                if (donkh.SangTen)
                    dr["ChiTiet"] += "Sang Tên, ";
                if (donkh.NuocDuc)
                    dr["ChiTiet"] += "Nước Đục, ";
                if (donkh.DangKyDM || donkh.CatChuyenDM)
                    dr["ChiTiet"] += "Định Mức, ";
                if (donkh.LoaiKhac)
                    dr["ChiTiet"] += donkh.LyDoLoaiKhac + ", ";
                if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                    dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = itemRow["HoTen"];
                dr["DiaChi"] = itemRow["DiaChi"];
                dr["NoiDung"] = itemRow["NoiDung"];

                string str = "";
                str = _cDonTXL.GetNVKiemTraDonKHbyMaDon(donkh.MaDon);
                if (donkh.ChuyenToXuLy)
                    str = ", TXL";
                dr["NVKiemTra"] = str;

                dsBaoCao.Tables["DanhSachDonKH"].Rows.Add(dr);
            }
            
            rptDSDonKH rpt = new rptDSDonKH();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void dgvDSDonKH_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(itemID_KeyPress);//This line of code resolved my issue
            if (dgvDSDonKH.CurrentCell.ColumnIndex == dgvDSDonKH.Columns["SoLuongDiaChi"].Index)
            {
                TextBox itemID = e.Control as TextBox;
                if (itemID != null)
                {
                    itemID.KeyPress += new KeyPressEventHandler(itemID_KeyPress);
                }
            }
        }

        private void itemID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnInDSDonTXL_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //DataTable dt = ((DataTable)dgvDSDonKH.DataSource).DefaultView.ToTable();
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                    dt = _cDonTXL.LoadDSDonTKHDaChuyenKT(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Replace("-", "")));
                    break;
                case "Ngày":
                    dt = _cDonTXL.LoadDSDonTKHDaChuyenKT(dateTimKiem.Value);
                    break;
                case "Khoảng Thời Gian":
                    dt = _cDonTXL.LoadDSDonTKHDaChuyenKT(dateTu.Value, dateDen.Value);
                    break;
                case "Số Công Văn":
                    dt = _cDonTXL.LoadDSDonTKHDaChuyenKTbySoCongVan(txtNoiDungTimKiem.Text.Trim().ToUpper());
                    break;
            }

            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            if (chkChuaKT.Checked)
                foreach (DataRow itemRow in dt.Rows)
                {
                    string a = itemRow["NguoiDi"].ToString();
                    string b = itemRow["MaDon"].ToString();
                    if (!string.IsNullOrEmpty(itemRow["NguoiDi"].ToString()))
                    if (!_cDonTXL.CheckGiaiQuyetDonKHbyUser(int.Parse(itemRow["NguoiDi"].ToString()), decimal.Parse(itemRow["MaDon"].ToString())))
                    {
                        DataRow dr = dsBaoCao.Tables["DSDonTXL"].NewRow();

                        dr["TuNgay"] = _tuNgay;
                        dr["DenNgay"] = _denNgay;
                        //dr["MaLD"] = itemRow["MaLD"];
                        dr["TenLD"] = itemRow["TenLD"];
                        dr["SoCongVan"] = itemRow["SoCongVan"];
                        dr["NgayNhan"] = itemRow["CreateDate"].ToString().Substring(0, 10);
                        DonKH donkh = _cDonKH.getDonKHbyID(decimal.Parse(itemRow["MaDon"].ToString()));
                        dr["MaDon"] =  itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-");
                        dr["TenLD"] = donkh.LoaiDon.TenLD;

                        if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                            dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                        dr["HoTen"] = itemRow["HoTen"];
                        dr["DiaChi"] = itemRow["DiaChi"];
                        dr["NoiDung"] = itemRow["NoiDung"];
                        dr["GhiChuChuyenKT"] = itemRow["GhiChuChuyenKT"];
                        if (!string.IsNullOrEmpty(itemRow["NguoiDi"].ToString()))
                        {
                            dr["NguoiDi"] = _cTaiKhoan.getHoTenUserbyID(int.Parse(itemRow["NguoiDi"].ToString()));
                            //dr["DaGiaiQuyet"] = _cDonTXL.CheckGiaiQuyetbyUser(int.Parse(itemRow["NguoiDi"].ToString()), dontxl.MaDon).ToString();
                        }

                        dsBaoCao.Tables["DSDonTXL"].Rows.Add(dr);
                    }
                }
            else
                foreach (DataRow itemRow in dt.Rows)
                {
                    DataRow dr = dsBaoCao.Tables["DSDonTXL"].NewRow();

                    dr["TuNgay"] = _tuNgay;
                    dr["DenNgay"] = _denNgay;
                    //dr["MaLD"] = itemRow["MaLD"];
                    dr["TenLD"] = itemRow["TenLD"];
                    dr["SoCongVan"] = itemRow["SoCongVan"];
                    dr["NgayNhan"] = itemRow["CreateDate"].ToString().Substring(0, 10);
                    DonKH donkh = _cDonKH.getDonKHbyID(decimal.Parse(itemRow["MaDon"].ToString()));
                    dr["MaDon"] = itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-");
                    dr["TenLD"] = donkh.LoaiDon.TenLD;

                    if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                        dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                    dr["HoTen"] = itemRow["HoTen"];
                    dr["DiaChi"] = itemRow["DiaChi"];
                    dr["NoiDung"] = itemRow["NoiDung"];
                    dr["GhiChuChuyenKT"] = itemRow["GhiChuChuyenKT"];
                    if (!string.IsNullOrEmpty(itemRow["NguoiDi"].ToString()))
                    {
                        dr["NguoiDi"] = _cTaiKhoan.getHoTenUserbyID(int.Parse(itemRow["NguoiDi"].ToString()));
                        string NgayGiaiQuyet;
                        dr["DaGiaiQuyet"] = _cDonTXL.CheckGiaiQuyetDonKHbyUser(int.Parse(itemRow["NguoiDi"].ToString()), donkh.MaDon, out NgayGiaiQuyet).ToString();
                        dr["NgayGiaiQuyet"] = NgayGiaiQuyet;
                    }

                    dsBaoCao.Tables["DSDonTXL"].Rows.Add(dr);
                }

            rptDSDonTXL rpt = new rptDSDonTXL();
            rpt.SetDataSource(dsBaoCao);
            rpt.Subreports[0].SetDataSource(dsBaoCao);
            rpt.Subreports[1].SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnInChiTiet_Click(object sender, EventArgs e)
        {
            DataTable dt = ((DataTable)dgvDSDonKH.DataSource).DefaultView.ToTable();
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataRow itemRow in dt.Rows)
            {
                DonKH donkh = _cDonKH.getDonKHbyID(decimal.Parse(itemRow["MaDon"].ToString()));
                if (donkh.ChuyenKT)
                {
                    DataRow dr = dsBaoCao.Tables["ChiTietDonTXL"].NewRow();

                    dr["MaDon"] = itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-");
                    dr["TenLD"] = itemRow["TenLD"].ToString();
                    dr["NgayNhan"] = itemRow["CreateDate"].ToString();
                    dr["NoiDung"] = itemRow["NoiDung"].ToString();
                    dr["LoaiChuyen"] = "Đi Kiểm Tra";
                    if (donkh.NgayChuyenKT != null)
                        dr["NgayChuyen"] = donkh.NgayChuyenKT.Value.ToString("dd/MM/yyyy");
                    if (donkh.NguoiDi != null)
                        dr["GhiChu"] = _cTaiKhoan.getHoTenUserbyID(int.Parse(donkh.NguoiDi.Value.ToString()));
                    dr["GhiChu"] += ". " + donkh.GhiChuChuyenKT;

                    dsBaoCao.Tables["ChiTietDonTXL"].Rows.Add(dr);
                }
                if (donkh.ChuyenBanDoiKhac)
                {
                    DataRow dr = dsBaoCao.Tables["ChiTietDonTXL"].NewRow();

                    dr["MaDon"] = itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-");
                    dr["TenLD"] = itemRow["TenLD"].ToString();
                    dr["NgayNhan"] = itemRow["CreateDate"].ToString();
                    dr["NoiDung"] = itemRow["NoiDung"].ToString();
                    dr["LoaiChuyen"] = "Đi Ban Đội Khác";
                    if (donkh.NgayChuyenBanDoiKhac != null)
                        dr["NgayChuyen"] = donkh.NgayChuyenBanDoiKhac.Value.ToString("dd/MM/yyyy");
                    dr["GhiChu"] = donkh.GhiChuChuyenBanDoiKhac;

                    dsBaoCao.Tables["ChiTietDonTXL"].Rows.Add(dr);
                }
                if (donkh.ChuyenToXuLy)
                {
                    DataRow dr = dsBaoCao.Tables["ChiTietDonTXL"].NewRow();

                    dr["MaDon"] = itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-");
                    dr["TenLD"] = itemRow["TenLD"].ToString();
                    dr["NgayNhan"] = itemRow["CreateDate"].ToString();
                    dr["NoiDung"] = itemRow["NoiDung"].ToString();
                    dr["LoaiChuyen"] = "Đi Tổ Khách Hàng";
                    if (donkh.NgayChuyenToXuLy != null)
                        dr["NgayChuyen"] = donkh.NgayChuyenToXuLy.Value.ToString("dd/MM/yyyy");
                    dr["GhiChu"] = donkh.GhiChuChuyenToXuLy;

                    dsBaoCao.Tables["ChiTietDonTXL"].Rows.Add(dr);
                }
                if (donkh.ChuyenBanDoiKhac)
                {
                    DataRow dr = dsBaoCao.Tables["ChiTietDonTXL"].NewRow();

                    dr["MaDon"] = itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-");
                    dr["TenLD"] = itemRow["TenLD"].ToString();
                    dr["NgayNhan"] = itemRow["CreateDate"].ToString();
                    dr["NoiDung"] = itemRow["NoiDung"].ToString();
                    dr["LoaiChuyen"] = "Đi Khác";
                    if (donkh.NgayChuyenKhac != null)
                        dr["NgayChuyen"] = donkh.NgayChuyenKhac.Value.ToString("dd/MM/yyyy");
                    dr["GhiChu"] = donkh.GhiChuChuyenKhac;

                    dsBaoCao.Tables["ChiTietDonTXL"].Rows.Add(dr);
                }
            }
            rptChiTietDonTXL rpt = new rptChiTietDonTXL();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void btnGiaoTXL_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //DataTable dt = ((DataTable)dgvDSDonTXL.DataSource).DefaultView.ToTable();
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Ngày":
                    dt = _cDonTXL.LoadDSDonTKHDaChuyenTXL(dateTimKiem.Value);
                    break;
                case "Khoảng Thời Gian":
                    dt = _cDonTXL.LoadDSDonTKHDaChuyenTXL(dateTu.Value, dateDen.Value);
                    break;
                case "Số Công Văn":
                    dt = _cDonTXL.LoadDSDonTKHDaChuyenTXLbySoCongVan(txtNoiDungTimKiem.Text.Trim().ToUpper());
                    break;
            }
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();

            foreach (DataRow itemRow in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DSDonTXL"].NewRow();

                dr["TuNgay"] = _tuNgay;
                dr["DenNgay"] = _denNgay;
                //dr["MaLD"] = itemRow["MaLD"];
                dr["TenLD"] = itemRow["TenLD"];
                dr["SoCongVan"] = itemRow["SoCongVan"];
                dr["NgayNhan"] = itemRow["CreateDate"].ToString().Substring(0, 10);
                //DonTXL dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(itemRow["MaDon"].ToString()));
                dr["MaDon"] = "TXL" + itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-");
                dr["TenLD"] = itemRow["TenLD"].ToString();

                if (!string.IsNullOrEmpty(itemRow["DanhBo"].ToString()))
                    dr["DanhBo"] = itemRow["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = itemRow["HoTen"];
                dr["DiaChi"] = itemRow["DiaChi"];
                dr["NoiDung"] = itemRow["NoiDung"];
                dr["GhiChuChuyenKT"] = itemRow["GhiChuChuyenKT"];
                //if (!string.IsNullOrEmpty(itemRow["NguoiDi"].ToString()))
                //{
                //    dr["NguoiDi"] = _cTaiKhoan.getHoTenUserbyID(int.Parse(itemRow["NguoiDi"].ToString()));
                //    string NgayGiaiQuyet;
                //    dr["DaGiaiQuyet"] = _cDonTXL.CheckGiaiQuyetDonTXLbyUser(int.Parse(itemRow["NguoiDi"].ToString()), dontxl.MaDon, out NgayGiaiQuyet).ToString();
                //    dr["NgayGiaiQuyet"] = NgayGiaiQuyet;
                //}

                dsBaoCao.Tables["DSDonTXL"].Rows.Add(dr);
            }
            rptDSDonTXLChuyenTXL rpt = new rptDSDonTXLChuyenTXL();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void txtNoiDungTimKiem2_TextChanged(object sender, EventArgs e)
        {
            if (txtNoiDungTimKiem.Text.Trim() != "" && txtNoiDungTimKiem2.Text.Trim() != "")
            {
                switch (cmbTimTheo.SelectedItem.ToString())
                {
                    case "Mã Đơn":
                        dgvDSDonKH.DataSource = _cDonKH.LoadDSDonKHByMaDons(decimal.Parse(txtNoiDungTimKiem.Text.Trim().Replace("-", "")), decimal.Parse(txtNoiDungTimKiem2.Text.Trim().Replace("-", "")));
                        break;
                }

            }
        }

    }
}
