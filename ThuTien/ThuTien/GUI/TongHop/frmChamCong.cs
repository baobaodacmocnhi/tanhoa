using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.TongHop;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;
using ThuTien.BaoCao;
using ThuTien.BaoCao.TongHop;
using ThuTien.GUI.BaoCao;

namespace ThuTien.GUI.TongHop
{
    public partial class frmChamCong : Form
    {
        string _mnu = "mnuChamCong";
        CChamCong _cChamCong = new CChamCong();
        CNguoiDung _cNguoiDung = new CNguoiDung();

        public frmChamCong()
        {
            InitializeComponent();
        }

        private void frmChamCong_Load(object sender, EventArgs e)
        {
            dgvChamCong.AutoGenerateColumns = false;

            dateChamCong.Value = DateTime.Now;

            if (!_cChamCong.CheckExist(DateTime.Now.Month, DateTime.Now.Year))
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    List<TT_NguoiDung> lstND = _cNguoiDung.GetDSChamCong();

                    ///xét năm mới
                    if (DateTime.Now.Month == 1)
                    {
                        int SoNgayPhep = 12;
                        foreach (TT_NguoiDung item in lstND)
                        {
                            item.NgayPhepNamCu = item.NgayPhepNamMoi;
                            item.NgayPhepNamMoi = SoNgayPhep + (DateTime.Now.Year - item.NamVaoLam.Value) / 5;
                        }
                    }

                    ///ngày phép cũ chỉ dữ hết tháng 3
                    if (DateTime.Now.Month == 4)
                        foreach (TT_NguoiDung item in lstND)
                        {
                            item.NgayPhepNamCu = 0;
                        }

                    TT_ChamCong chamcong = new TT_ChamCong();
                    chamcong.Thang = DateTime.Now.Month;
                    chamcong.Nam = DateTime.Now.Year;

                    foreach (TT_NguoiDung item in lstND)
                    {
                        TT_CTChamCong ctchamcong = new TT_CTChamCong();
                        ctchamcong.MaND = item.MaND;
                        ctchamcong.CreateBy = CNguoiDung.MaND;
                        ctchamcong.CreateDate = DateTime.Now;

                        #region
                        //for (int i = 1; i <= GetTongNgay(DateTime.Now.Month, DateTime.Now.Year); i++)
                        //{
                        //    DateTime time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, i);

                        //    if (time.DayOfWeek == DayOfWeek.Saturday || time.DayOfWeek == DayOfWeek.Sunday)
                        //    {
                        //        #region Thứ 7 & CN

                        //        switch (i)
                        //        {
                        //            case 1:
                        //                ctchamcong.N1 = false;
                        //                break;
                        //            case 2:
                        //                ctchamcong.N2 = false;
                        //                break;
                        //            case 3:
                        //                ctchamcong.N3 = false;
                        //                break;
                        //            case 4:
                        //                ctchamcong.N4 = false;
                        //                break;
                        //            case 5:
                        //                ctchamcong.N5 = false;
                        //                break;
                        //            case 6:
                        //                ctchamcong.N6 = false;
                        //                break;
                        //            case 7:
                        //                ctchamcong.N7 = false;
                        //                break;
                        //            case 8:
                        //                ctchamcong.N8 = false;
                        //                break;
                        //            case 9:
                        //                ctchamcong.N9 = false;
                        //                break;
                        //            case 10:
                        //                ctchamcong.N10 = false;
                        //                break;
                        //            case 11:
                        //                ctchamcong.N11 = false;
                        //                break;
                        //            case 12:
                        //                ctchamcong.N12 = false;
                        //                break;
                        //            case 13:
                        //                ctchamcong.N13 = false;
                        //                break;
                        //            case 14:
                        //                ctchamcong.N14 = false;
                        //                break;
                        //            case 15:
                        //                ctchamcong.N15 = false;
                        //                break;
                        //            case 16:
                        //                ctchamcong.N16 = false;
                        //                break;
                        //            case 17:
                        //                ctchamcong.N17 = false;
                        //                break;
                        //            case 18:
                        //                ctchamcong.N18 = false;
                        //                break;
                        //            case 19:
                        //                ctchamcong.N19 = false;
                        //                break;
                        //            case 20:
                        //                ctchamcong.N20 = false;
                        //                break;
                        //            case 21:
                        //                ctchamcong.N21 = false;
                        //                break;
                        //            case 22:
                        //                ctchamcong.N22 = false;
                        //                break;
                        //            case 23:
                        //                ctchamcong.N23 = false;
                        //                break;
                        //            case 24:
                        //                ctchamcong.N24 = false;
                        //                break;
                        //            case 25:
                        //                ctchamcong.N25 = false;
                        //                break;
                        //            case 26:
                        //                ctchamcong.N26 = false;
                        //                break;
                        //            case 27:
                        //                ctchamcong.N27 = false;
                        //                break;
                        //            case 28:
                        //                ctchamcong.N28 = false;
                        //                break;
                        //            case 29:
                        //                ctchamcong.N29 = false;
                        //                break;
                        //            case 30:
                        //                ctchamcong.N30 = false;
                        //                break;
                        //            case 31:
                        //                ctchamcong.N31 = false;
                        //                break;
                        //            default:
                        //                break;
                        //        }

                        //        #endregion
                        //    }
                        //    else
                        //    {
                        //        #region Thứ 2, 3, 4, 5, 6

                        //        switch (i)
                        //        {
                        //            case 1:
                        //                ctchamcong.N1 = true;
                        //                break;
                        //            case 2:
                        //                ctchamcong.N2 = true;
                        //                break;
                        //            case 3:
                        //                ctchamcong.N3 = true;
                        //                break;
                        //            case 4:
                        //                ctchamcong.N4 = true;
                        //                break;
                        //            case 5:
                        //                ctchamcong.N5 = true;
                        //                break;
                        //            case 6:
                        //                ctchamcong.N6 = true;
                        //                break;
                        //            case 7:
                        //                ctchamcong.N7 = true;
                        //                break;
                        //            case 8:
                        //                ctchamcong.N8 = true;
                        //                break;
                        //            case 9:
                        //                ctchamcong.N9 = true;
                        //                break;
                        //            case 10:
                        //                ctchamcong.N10 = true;
                        //                break;
                        //            case 11:
                        //                ctchamcong.N11 = true;
                        //                break;
                        //            case 12:
                        //                ctchamcong.N12 = true;
                        //                break;
                        //            case 13:
                        //                ctchamcong.N13 = true;
                        //                break;
                        //            case 14:
                        //                ctchamcong.N14 = true;
                        //                break;
                        //            case 15:
                        //                ctchamcong.N15 = true;
                        //                break;
                        //            case 16:
                        //                ctchamcong.N16 = true;
                        //                break;
                        //            case 17:
                        //                ctchamcong.N17 = true;
                        //                break;
                        //            case 18:
                        //                ctchamcong.N18 = true;
                        //                break;
                        //            case 19:
                        //                ctchamcong.N19 = true;
                        //                break;
                        //            case 20:
                        //                ctchamcong.N20 = true;
                        //                break;
                        //            case 21:
                        //                ctchamcong.N21 = true;
                        //                break;
                        //            case 22:
                        //                ctchamcong.N22 = true;
                        //                break;
                        //            case 23:
                        //                ctchamcong.N23 = true;
                        //                break;
                        //            case 24:
                        //                ctchamcong.N24 = true;
                        //                break;
                        //            case 25:
                        //                ctchamcong.N25 = true;
                        //                break;
                        //            case 26:
                        //                ctchamcong.N26 = true;
                        //                break;
                        //            case 27:
                        //                ctchamcong.N27 = true;
                        //                break;
                        //            case 28:
                        //                ctchamcong.N28 = true;
                        //                break;
                        //            case 29:
                        //                ctchamcong.N29 = true;
                        //                break;
                        //            case 30:
                        //                ctchamcong.N30 = true;
                        //                break;
                        //            case 31:
                        //                ctchamcong.N31 = true;
                        //                break;
                        //            default:
                        //                break;
                        //        }

                        //        #endregion
                        //    }
                        //}
                        #endregion

                        chamcong.TT_CTChamCongs.Add(ctchamcong);
                    }

                    _cChamCong.Them(chamcong);
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            #region textbox=0

            txtN1.Text = "0";
            txtN2.Text = "0";
            txtN3.Text = "0";
            txtN4.Text = "0";
            txtN5.Text = "0";
            txtN6.Text = "0";
            txtN7.Text = "0";
            txtN8.Text = "0";
            txtN9.Text = "0";
            txtN10.Text = "0";
            txtN11.Text = "0";
            txtN12.Text = "0";
            txtN13.Text = "0";
            txtN14.Text = "0";
            txtN15.Text = "0";
            txtN16.Text = "0";
            txtN17.Text = "0";
            txtN18.Text = "0";
            txtN19.Text = "0";
            txtN20.Text = "0";
            txtN21.Text = "0";
            txtN22.Text = "0";
            txtN23.Text = "0";
            txtN24.Text = "0";
            txtN25.Text = "0";
            txtN26.Text = "0";
            txtN27.Text = "0";
            txtN28.Text = "0";
            txtN29.Text = "0";
            txtN30.Text = "0";
            txtN31.Text = "0";

            #endregion

            dgvChamCong.DataSource = _cChamCong.GetDS(dateChamCong.Value.Month, dateChamCong.Value.Year);

            for (int i = 1; i <= GetTongNgay(dateChamCong.Value.Month, dateChamCong.Value.Year); i++)
            {
                DateTime time = new DateTime(dateChamCong.Value.Year, dateChamCong.Value.Month, i);

                if (time.DayOfWeek == DayOfWeek.Saturday || time.DayOfWeek == DayOfWeek.Sunday)
                    dgvChamCong.Columns["N" + i].DefaultCellStyle.BackColor = Color.Orange;
                else
                    dgvChamCong.Columns["N" + i].DefaultCellStyle.BackColor = Color.White;
            }

            foreach (DataGridViewRow item in dgvChamCong.Rows)
            {
                #region count textbox

                if (bool.Parse(item.Cells["N1"].Value.ToString()))
                {
                    txtN1.Text = (int.Parse(txtN1.Text) + 1).ToString();
                    item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                }
                if (bool.Parse(item.Cells["N2"].Value.ToString()))
                {
                    txtN2.Text = (int.Parse(txtN2.Text) + 1).ToString();
                    item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                }
                if (bool.Parse(item.Cells["N3"].Value.ToString()))
                {
                    txtN3.Text = (int.Parse(txtN3.Text) + 1).ToString();
                    item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                }
                if (bool.Parse(item.Cells["N4"].Value.ToString()))
                {
                    txtN4.Text = (int.Parse(txtN4.Text) + 1).ToString();
                    item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                }
                if (bool.Parse(item.Cells["N5"].Value.ToString()))
                {
                    txtN5.Text = (int.Parse(txtN5.Text) + 1).ToString();
                    item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                }
                if (bool.Parse(item.Cells["N6"].Value.ToString()))
                {
                    txtN6.Text = (int.Parse(txtN6.Text) + 1).ToString();
                    item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                }
                if (bool.Parse(item.Cells["N7"].Value.ToString()))
                {
                    txtN7.Text = (int.Parse(txtN7.Text) + 1).ToString();
                    item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                }
                if (bool.Parse(item.Cells["N8"].Value.ToString()))
                {
                    txtN8.Text = (int.Parse(txtN8.Text) + 1).ToString();
                    item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                }
                if (bool.Parse(item.Cells["N9"].Value.ToString()))
                {
                    txtN9.Text = (int.Parse(txtN9.Text) + 1).ToString();
                    item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                }
                if (bool.Parse(item.Cells["N10"].Value.ToString()))
                {
                    txtN10.Text = (int.Parse(txtN10.Text) + 1).ToString();
                    item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                }
                if (bool.Parse(item.Cells["N11"].Value.ToString()))
                {
                    txtN11.Text = (int.Parse(txtN11.Text) + 1).ToString();
                    item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                }
                if (bool.Parse(item.Cells["N12"].Value.ToString()))
                {
                    txtN12.Text = (int.Parse(txtN12.Text) + 1).ToString();
                    item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                }
                if (bool.Parse(item.Cells["N13"].Value.ToString()))
                {
                    txtN13.Text = (int.Parse(txtN13.Text) + 1).ToString();
                    item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                }
                if (bool.Parse(item.Cells["N14"].Value.ToString()))
                {
                    txtN14.Text = (int.Parse(txtN14.Text) + 1).ToString();
                    item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                }
                if (bool.Parse(item.Cells["N15"].Value.ToString()))
                {
                    txtN15.Text = (int.Parse(txtN15.Text) + 1).ToString();
                    item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                }
                if (bool.Parse(item.Cells["N16"].Value.ToString()))
                {
                    txtN16.Text = (int.Parse(txtN16.Text) + 1).ToString();
                    item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                }
                if (bool.Parse(item.Cells["N17"].Value.ToString()))
                {
                    txtN17.Text = (int.Parse(txtN17.Text) + 1).ToString();
                    item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                }
                if (bool.Parse(item.Cells["N18"].Value.ToString()))
                {
                    txtN18.Text = (int.Parse(txtN18.Text) + 1).ToString();
                    item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                }
                if (bool.Parse(item.Cells["N19"].Value.ToString()))
                {
                    txtN19.Text = (int.Parse(txtN19.Text) + 1).ToString();
                    item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                }
                if (bool.Parse(item.Cells["N20"].Value.ToString()))
                {
                    txtN20.Text = (int.Parse(txtN20.Text) + 1).ToString();
                    item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                }
                if (bool.Parse(item.Cells["N21"].Value.ToString()))
                {
                    txtN21.Text = (int.Parse(txtN21.Text) + 1).ToString();
                    item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                }
                if (bool.Parse(item.Cells["N22"].Value.ToString()))
                {
                    txtN22.Text = (int.Parse(txtN22.Text) + 1).ToString();
                    item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                }
                if (bool.Parse(item.Cells["N23"].Value.ToString()))
                {
                    txtN23.Text = (int.Parse(txtN23.Text) + 1).ToString();
                    item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                }
                if (bool.Parse(item.Cells["N24"].Value.ToString()))
                {
                    txtN24.Text = (int.Parse(txtN24.Text) + 1).ToString();
                    item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                }
                if (bool.Parse(item.Cells["N25"].Value.ToString()))
                {
                    txtN25.Text = (int.Parse(txtN25.Text) + 1).ToString();
                    item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                }
                if (bool.Parse(item.Cells["N26"].Value.ToString()))
                {
                    txtN26.Text = (int.Parse(txtN26.Text) + 1).ToString();
                    item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                }
                if (bool.Parse(item.Cells["N27"].Value.ToString()))
                {
                    txtN27.Text = (int.Parse(txtN27.Text) + 1).ToString();
                    item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                }
                if (bool.Parse(item.Cells["N28"].Value.ToString()))
                {
                    txtN28.Text = (int.Parse(txtN28.Text) + 1).ToString();
                    item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                }
                if (bool.Parse(item.Cells["N29"].Value.ToString()))
                {
                    txtN29.Text = (int.Parse(txtN29.Text) + 1).ToString();
                    item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                }
                if (bool.Parse(item.Cells["N30"].Value.ToString()))
                {
                    txtN30.Text = (int.Parse(txtN30.Text) + 1).ToString();
                    item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                }
                if (bool.Parse(item.Cells["N31"].Value.ToString()))
                {
                    txtN31.Text = (int.Parse(txtN31.Text) + 1).ToString();
                    item.Cells["Nghi"].Value = int.Parse(item.Cells["Nghi"].Value.ToString()) + 1;
                }
                #endregion
            }
        }

        public int GetTongNgay(int Thang, int Nam)
        {
            switch (Thang)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                case 2:
                    if (Nam % 400 == 0 || (Nam % 4 == 0 && Nam % 100 != 0))
                        return 29;
                    else
                        return 28;
                default:
                    return 0;
            }
        }

        private void dgvChamCong_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            {
                if(_cChamCong.ChamCong(int.Parse(dgvChamCong["MaCC", e.RowIndex].Value.ToString()), int.Parse(dgvChamCong["MaNV", e.RowIndex].Value.ToString()), dgvChamCong.Columns[e.ColumnIndex].Name, bool.Parse(dgvChamCong[e.ColumnIndex, e.RowIndex].Value.ToString())))
                    if (bool.Parse(dgvChamCong[e.ColumnIndex, e.RowIndex].Value.ToString()))
                    {
                        TT_NguoiDung nguoidung = _cNguoiDung.GetByMaND(int.Parse(dgvChamCong["MaNV", e.RowIndex].Value.ToString()));
                        if (nguoidung.NgayPhepNamCu > 0)
                            nguoidung.NgayPhepNamCu -= 1;
                        else
                            nguoidung.NgayPhepNamMoi -= 1;
                        _cNguoiDung.Sua(nguoidung);
                    }
                    else
                    {
                        TT_NguoiDung nguoidung = _cNguoiDung.GetByMaND(int.Parse(dgvChamCong["MaNV", e.RowIndex].Value.ToString()));
                        if (DateTime.Now.Month <= 3)
                            if (nguoidung.NgayPhepNamCu > 0)
                                nguoidung.NgayPhepNamCu += 1;
                            else
                                nguoidung.NgayPhepNamMoi += 1;
                        else
                            nguoidung.NgayPhepNamMoi += 1;
                        _cNguoiDung.Sua(nguoidung);
                    }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvChamCong_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvChamCong.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvChamCong.Rows)
            {
                DataRow dr = ds.Tables["ChamCong"].NewRow();
                dr["ThoiGian"] = dateChamCong.Value.ToString("MM/yyyy");
                dr["HoTen"] = item.Cells["HoTen"].Value;
                dr["N1"] = item.Cells["N1"].Value;
                dr["N2"] = item.Cells["N2"].Value;
                dr["N3"] = item.Cells["N3"].Value;
                dr["N4"] = item.Cells["N4"].Value;
                dr["N5"] = item.Cells["N5"].Value;
                dr["N6"] = item.Cells["N6"].Value;
                dr["N7"] = item.Cells["N7"].Value;
                dr["N8"] = item.Cells["N8"].Value;
                dr["N9"] = item.Cells["N9"].Value;
                dr["N10"] = item.Cells["N10"].Value;
                dr["N11"] = item.Cells["N11"].Value;
                dr["N12"] = item.Cells["N12"].Value;
                dr["N13"] = item.Cells["N13"].Value;
                dr["N14"] = item.Cells["N14"].Value;
                dr["N15"] = item.Cells["N15"].Value;
                dr["N16"] = item.Cells["N16"].Value;
                dr["N17"] = item.Cells["N17"].Value;
                dr["N18"] = item.Cells["N18"].Value;
                dr["N19"] = item.Cells["N19"].Value;
                dr["N20"] = item.Cells["N20"].Value;
                dr["N21"] = item.Cells["N21"].Value;
                dr["N22"] = item.Cells["N22"].Value;
                dr["N23"] = item.Cells["N23"].Value;
                dr["N24"] = item.Cells["N24"].Value;
                dr["N25"] = item.Cells["N25"].Value;
                dr["N26"] = item.Cells["N26"].Value;
                dr["N27"] = item.Cells["N27"].Value;
                dr["N28"] = item.Cells["N28"].Value;
                dr["N29"] = item.Cells["N29"].Value;
                dr["N30"] = item.Cells["N30"].Value;
                dr["N31"] = item.Cells["N31"].Value;
                dr["Nghi"] = item.Cells["Nghi"].Value;
                ds.Tables["ChamCong"].Rows.Add(dr);
            }
            rptChamCong rpt = new rptChamCong();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }

    }
}
