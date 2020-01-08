using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL;
using ThuTien.LinQ;
using ThuTien.BaoCao;
using ThuTien.GUI.BaoCao;
using ThuTien.DAL.Quay;
using ThuTien.DAL.TongHop;
using ThuTien.DAL.Doi;
using ThuTien.BaoCao.TongHop;

namespace ThuTien.GUI.TongHop
{
    public partial class frmToTrinhDCHD : Form
    {
        string _mnu = "mnuToTrinhDCHD";
        CHoaDon _cHoaDon = new CHoaDon();
        CDocSo _cCapNuocTanHoa = new CDocSo();
        CToTrinhDCHD _cToTrinhDCHD = new CToTrinhDCHD();
        CLenhHuy _cLenhHuy = new CLenhHuy();

        public frmToTrinhDCHD()
        {
            InitializeComponent();
        }

        private void frmToTrinhDCHD_Load(object sender, EventArgs e)
        {
            dgvToTrinh.AutoGenerateColumns = false;
            dgvCTToTrinh.AutoGenerateColumns = false;
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo.Text.Trim().Length == 11)
            {
                bool exist = false;
                foreach (DataGridViewRow item in dgvCTToTrinh.Rows)
                    if (item.Cells["DanhBo"].Value.ToString() == txtDanhBo.Text.Trim())
                    {
                        exist = true;
                        break;
                    }
                if (exist == false)
                {
                    //DataTable dt = _cHoaDon.GetDSTonByDanhBo(txtDanhBo.Text.Trim());
                    //string Ky = "";
                    //int TongCongSo = 0;
                    //int TieuThu = 0;
                    //foreach (DataRow item in dt.Rows)
                    //{
                    //    if (Ky == "")
                    //        Ky += item["Ky"];
                    //    else
                    //        Ky += ", " + item["Ky"];
                    //    TongCongSo += int.Parse(item["TongCong"].ToString());
                    //    TieuThu += int.Parse(item["TieuThu"].ToString());
                    //}

                    //if (dt.Rows.Count > 0)
                    //{
                    //if (dgvCTToTrinh.DataSource == null)
                    //{
                    //    dgvCTToTrinh.Rows.Add();

                    //    dgvCTToTrinh["DanhBo", dgvCTToTrinh.Rows.Count - 1].Value = dt.Rows[0]["DanhBo"].ToString();
                    //    dgvCTToTrinh["MLT", dgvCTToTrinh.Rows.Count - 1].Value = dt.Rows[0]["MLT"].ToString();
                    //    dgvCTToTrinh["HoTen", dgvCTToTrinh.Rows.Count - 1].Value = dt.Rows[0]["HoTen"].ToString();
                    //    dgvCTToTrinh["DiaChi", dgvCTToTrinh.Rows.Count - 1].Value = dt.Rows[0]["DiaChi"].ToString();
                    //    dgvCTToTrinh["Ky", dgvCTToTrinh.Rows.Count - 1].Value = Ky;
                    //    dgvCTToTrinh["TongCong", dgvCTToTrinh.Rows.Count - 1].Value = TongCongSo;
                    //    dgvCTToTrinh["TieuThu", dgvCTToTrinh.Rows.Count - 1].Value = TieuThu;
                    //    dgvCTToTrinh["CoDHN", dgvCTToTrinh.Rows.Count - 1].Value = _cCapNuocTanHoa.GetCoDHN(dt.Rows[0]["DanhBo"].ToString());
                    //}
                    //else
                    //{
                    //    DataTable dtTemp = (DataTable)dgvCTToTrinh.DataSource;

                    //    DataRow dr = dtTemp.NewRow();

                    //    dr["DanhBo"] = dt.Rows[0]["DanhBo"].ToString();
                    //    dr["MLT"] = dt.Rows[0]["MLT"].ToString();
                    //    dr["HoTen"] = dt.Rows[0]["HoTen"].ToString();
                    //    dr["DiaChi"] = dt.Rows[0]["DiaChi"].ToString();
                    //    dr["Ky"] = Ky;
                    //    dr["TongCong"] = TongCongSo;
                    //    dr["TieuThu"] = TieuThu;
                    //    dr["CoDHN"] = _cCapNuocTanHoa.GetCoDHN(dt.Rows[0]["DanhBo"].ToString());

                    //    dtTemp.Rows.Add(dr);
                    //    dtTemp.AcceptChanges();

                    //    dgvCTToTrinh.DataSource = dtTemp;
                    //}
                    //}

                    DataTable dtTon = _cHoaDon.GetDSTonByDanhBo_CodeF(txtDanhBo.Text.Trim());
                    string Ky = "";

                    foreach (DataRow itemTon in dtTon.Rows)
                    {
                        if (Ky == "")
                            Ky += itemTon["Ky"];
                        else
                            Ky += ", " + itemTon["Ky"];
                    }

                    if (Ky != "")
                        if (dgvCTToTrinh.DataSource == null)
                        {
                            dgvCTToTrinh.Rows.Add();

                            dgvCTToTrinh["DanhBo", dgvCTToTrinh.Rows.Count - 1].Value = dtTon.Rows[0]["DanhBo"];
                            dgvCTToTrinh["HoTen", dgvCTToTrinh.Rows.Count - 1].Value = dtTon.Rows[0]["HoTen"];
                            dgvCTToTrinh["DiaChi", dgvCTToTrinh.Rows.Count - 1].Value = dtTon.Rows[0]["DiaChi"] + " " + _cCapNuocTanHoa.GetPhuongQuan(dtTon.Rows[0]["DanhBo"].ToString());
                            dgvCTToTrinh["Ky", dgvCTToTrinh.Rows.Count - 1].Value = Ky;
                        }
                        else
                        {
                            DataTable dtTemp = (DataTable)dgvCTToTrinh.DataSource;

                            DataRow dr = dtTemp.NewRow();

                            dr["DanhBo"] = dtTon.Rows[0]["DanhBo"];
                            dr["HoTen"] = dtTon.Rows[0]["HoTen"];
                            dr["DiaChi"] = dtTon.Rows[0]["DiaChi"] + " " + _cCapNuocTanHoa.GetPhuongQuan(dtTon.Rows[0]["DanhBo"].ToString());
                            dr["Ky"] = Ky;

                            dtTemp.Rows.Add(dr);
                            dtTemp.AcceptChanges();

                            dgvCTToTrinh.DataSource = dtTemp;
                        }

                    txtDanhBo.Text = "";
                }
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvToTrinh.DataSource = _cToTrinhDCHD.GetDS();
            if (dgvCTToTrinh.DataSource != null)
                dgvCTToTrinh.DataSource = null;
            if (dgvCTToTrinh.Rows.Count > 0)
                dgvCTToTrinh.Rows.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                if (dgvCTToTrinh.Rows.Count > 0)
                    try
                    {
                        TT_ToTrinhDCHD totrinh;
                        if (dgvCTToTrinh.DataSource == null)
                            totrinh = new TT_ToTrinhDCHD();
                        else
                            totrinh = _cToTrinhDCHD.Get(decimal.Parse(dgvCTToTrinh["ID_CT", 0].Value.ToString()));
                        int IDCT = _cToTrinhDCHD.GetMaxIDCT();

                        foreach (DataGridViewRow item in dgvCTToTrinh.Rows)
                            if (item.Cells["IDCT"].Value == null || string.IsNullOrEmpty(item.Cells["IDCT"].Value.ToString()))
                            {
                                TT_ToTrinhDCHD_ChiTiet cttotrinh = new TT_ToTrinhDCHD_ChiTiet();
                                cttotrinh.IDCT = ++IDCT;
                                cttotrinh.DanhBo = item.Cells["DanhBo"].Value.ToString();
                                //cttotrinh.MLT = item.Cells["MLT"].Value.ToString();
                                //cttotrinh.CoDHN = int.Parse(item.Cells["CoDHN"].Value.ToString());
                                cttotrinh.HoTen = item.Cells["HoTen"].Value.ToString();
                                cttotrinh.DiaChi = item.Cells["DiaChi"].Value.ToString();
                                cttotrinh.Ky = item.Cells["Ky"].Value.ToString();
                                //cttotrinh.TongCong = int.Parse(item.Cells["TongCong"].Value.ToString());
                                //cttotrinh.TieuThu = int.Parse(item.Cells["TieuThu"].Value.ToString());
                                if (item.Cells["LyDo"].Value != null)
                                    cttotrinh.LyDo = item.Cells["LyDo"].Value.ToString();
                                if (item.Cells["DeNghi"].Value != null)
                                    cttotrinh.DeNghi = item.Cells["DeNghi"].Value.ToString();
                                cttotrinh.CreateBy = CNguoiDung.MaND;
                                cttotrinh.CreateDate = DateTime.Now;

                                totrinh.TT_ToTrinhDCHD_ChiTiets.Add(cttotrinh);
                            }

                        if (dgvCTToTrinh.DataSource == null)
                            if (_cToTrinhDCHD.Them(totrinh))
                            {
                                MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnXem.PerformClick();
                            }
                            else
                            {
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        else
                            if (_cToTrinhDCHD.Sua(totrinh))
                            {
                                MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnXem.PerformClick();
                            }
                            else
                            {
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        foreach (DataGridViewRow item in dgvCTToTrinh.SelectedRows)
                        {
                            TT_ToTrinhDCHD_ChiTiet cttotrinh = _cToTrinhDCHD.get_ChiTiet(int.Parse(item.Cells["IDCT"].Value.ToString()));
                            if (!_cToTrinhDCHD.XoaCT(cttotrinh))
                            {
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        ///xóa tờ trình nếu hết chi tiết
                        if (_cToTrinhDCHD.CountCT(int.Parse(dgvToTrinh.SelectedRows[0].Cells["ID"].Value.ToString())) == 0)
                        {
                            TT_ToTrinhDCHD totrinh = _cToTrinhDCHD.Get(decimal.Parse(dgvToTrinh.SelectedRows[0].Cells["ID"].Value.ToString()));
                            _cToTrinhDCHD.Xoa(totrinh);
                        }
                        MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnXem.PerformClick();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();

            //if (!bool.Parse(dgvToTrinh.SelectedRows[0].Cells["Khoa"].Value.ToString()))
            foreach (DataGridViewRow item in dgvCTToTrinh.Rows)
            {
                DataRow dr = ds.Tables["ToTrinhCatHuy"].NewRow();
                if (radOng.Checked)
                    dr["NguoiKy"] = "Ông";
                else
                    if (radBa.Checked)
                        dr["NguoiKy"] = "Bà";
                if (radGiamDoc.Checked)
                    dr["NguoiKy"] += " Giám Đốc";
                else
                    if (radPhoGiamDoc.Checked)
                        dr["NguoiKy"] += " Phó Giám Đốc";
                dr["MaTT"] = item.Cells["ID_CT"].Value.ToString().Insert(item.Cells["ID_CT"].Value.ToString().Length - 2, "-");
                dr["ThoiGian"] = DateTime.Parse(item.Cells["CreateDate_CT"].Value.ToString()).ToString("MM/yyyy");
                dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(4, " ").Insert(8, " ");
                //dr["MLT"] = item.Cells["MLT"].Value.ToString().Insert(4, " ").Insert(2, " ");
                //dr["CoDHN"] = item.Cells["CoDHN"].Value;
                dr["HoTen"] = item.Cells["HoTen"].Value;
                dr["DiaChi"] = item.Cells["DiaChi"].Value;
                dr["Ky"] = item.Cells["Ky"].Value;
                //dr["TongCong"] = TongCongSo;
                //dr["TieuThu"] = TieuThu;
                dr["LyDo"] = item.Cells["LyDo"].Value;
                dr["DeNghi"] = item.Cells["DeNghi"].Value;
                dr["ChucVu"] = CNguoiKy.getChucVu();
                dr["NguoiKy"] = CNguoiKy.getNguoiKy();
                ds.Tables["ToTrinhCatHuy"].Rows.Add(dr);
            }
            //else
            //    foreach (DataGridViewRow item in dgvCTToTrinh.Rows)
            //    {
            //        DataRow dr = ds.Tables["ToTrinhCatHuy"].NewRow();
            //        if (radOng.Checked)
            //            dr["NguoiKy"] = "Ông";
            //        else
            //            if (radBa.Checked)
            //                dr["NguoiKy"] = "Bà";
            //        if (radGiamDoc.Checked)
            //            dr["NguoiKy"] += " Giám Đốc";
            //        else
            //            if (radPhoGiamDoc.Checked)
            //                dr["NguoiKy"] += " Phó Giám Đốc";
            //        dr["ID"] = item.Cells["ID_CT"].Value.ToString().Insert(item.Cells["ID_CT"].Value.ToString().Length - 2, "-");
            //        dr["ThoiGian"] = DateTime.Parse(item.Cells["CreateDate_CT"].Value.ToString()).ToString("MM/yyyy");
            //        dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(4, " ").Insert(8, " ");
            //        dr["MLT"] = item.Cells["MLT"].Value.ToString().Insert(4, " ").Insert(2, " ");
            //        dr["CoDHN"] = item.Cells["CoDHN"].Value;
            //        dr["HoTen"] = item.Cells["HoTen"].Value;
            //        dr["DiaChi"] = item.Cells["DiaChi"].Value;
            //        dr["Ky"] = item.Cells["Ky"].Value;
            //        dr["TongCong"] = item.Cells["TongCong"].Value;
            //        dr["TieuThu"] = item.Cells["TieuThu"].Value;
            //        dr["GhiChu"] = item.Cells["GhiChu"].Value;
            //        dr["ChucVu"] = CNguoiKy.getChucVu();
            //        dr["NguoiKy"] = CNguoiKy.getNguoiKy();
            //        ds.Tables["ToTrinhCatHuy"].Rows.Add(dr);
            //    }

            rptToTrinhDCHD rpt = new rptToTrinhDCHD();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void dgvToTrinh_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvToTrinh.Columns[e.ColumnIndex].Name == "ID" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }

        }

        private void dgvToTrinh_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvToTrinh.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvToTrinh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvToTrinh.RowCount > 0)
                dgvCTToTrinh.DataSource = _cToTrinhDCHD.GetDSCT(int.Parse(dgvToTrinh["ID", e.RowIndex].Value.ToString()));
        }

        private void dgvToTrinh_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //if (dgvToTrinh.Columns[e.ColumnIndex].Name == "Khoa" && bool.Parse(e.FormattedValue.ToString()) != bool.Parse(dgvToTrinh[e.ColumnIndex, e.RowIndex].Value.ToString()))
            //    if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            //    {
            //        if (bool.Parse(e.FormattedValue.ToString()) == true)
            //        {
            //            TT_ToTrinhDCHD totrinh = _cToTrinhDCHD.Get(decimal.Parse(dgvToTrinh["ID", e.RowIndex].Value.ToString()));

            //            foreach (TT_ToTrinhDCHD_ChiTiet item in totrinh.TT_ToTrinhDCHD_ChiTiets.ToList())
            //            {
            //                DataTable dtTon = _cHoaDon.GetDSTonByDanhBo_ExceptHD0(item.DanhBo);
            //                string Ky = ""; string MaHD = ""; string SoHoaDon = "";
            //                int TongCongSo = 0;
            //                int TieuThu = 0;
            //                foreach (DataRow itemTon in dtTon.Rows)
            //                {
            //                    if (Ky == "")
            //                        Ky += itemTon["Ky"];
            //                    else
            //                        Ky += ", " + itemTon["Ky"];
            //                    TongCongSo += int.Parse(itemTon["TongCong"].ToString());
            //                    TieuThu += int.Parse(itemTon["TieuThu"].ToString());
            //                    if (MaHD == "")
            //                        MaHD += itemTon["MaHD"].ToString();
            //                    else
            //                        MaHD += "," + itemTon["MaHD"].ToString();
            //                    if (SoHoaDon == "")
            //                        SoHoaDon += itemTon["SoHoaDon"].ToString();
            //                    else
            //                        SoHoaDon += "," + itemTon["SoHoaDon"].ToString();

            //                    //if (!_cLenhHuy.CheckExist(itemTon["SoHoaDon"].ToString()))
            //                    //{
            //                    //    TT_LenhHuy lenhhuy = new TT_LenhHuy();
            //                    //    lenhhuy.MaHD = _cHoaDon.Get(itemTon["SoHoaDon"].ToString()).ID_HOADON;
            //                    //    lenhhuy.SoHoaDon = itemTon["SoHoaDon"].ToString();
            //                    //    lenhhuy.TinhTrang = totrinh.TT_ToTrinhDCHD_ChiTiets.SingleOrDefault(itemLst => itemLst.DanhBo == itemTon["DanhBo"].ToString()).GhiChu;
            //                    //    _cLenhHuy.Them(lenhhuy);
            //                    //}
            //                }

            //                item.Ky = Ky;
            //                item.TongCong = TongCongSo;
            //                item.TieuThu = TieuThu;
            //                item.MaHD = MaHD;
            //                item.SoHoaDon = SoHoaDon;

            //                _cToTrinhDCHD.SuaCT(item);
            //            }

            //            totrinh.Khoa = true;
            //            _cToTrinhDCHD.Sua(totrinh);
            //        }
            //        else
            //        {
            //            TT_ToTrinhDCHD totrinh = _cToTrinhDCHD.Get(decimal.Parse(dgvToTrinh["ID", e.RowIndex].Value.ToString()));

            //            if (totrinh.DaKy == true)
            //            {
            //                MessageBox.Show("Đã Ký, Không tắt được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                return;
            //            }
            //            if (MessageBox.Show("Đã khóa, bạn có chắc chắn mở khóa?", "Xác nhận khóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            //            {
            //                foreach (TT_ToTrinhDCHD_ChiTiet item in totrinh.TT_ToTrinhDCHD_ChiTiets.ToList())
            //                {
            //                    item.Ky = null;
            //                    item.TongCong = null;
            //                    item.TieuThu = null;
            //                    item.MaHD = "";
            //                    item.SoHoaDon = "";
            //                    _cToTrinhDCHD.SuaCT(item);
            //                }

            //                totrinh.Khoa = false;
            //                _cToTrinhDCHD.Sua(totrinh);
            //            }
            //        }
            //    }
            //    else
            //        MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            /////
            //if (dgvToTrinh.Columns[e.ColumnIndex].Name == "DaKy" && bool.Parse(e.FormattedValue.ToString()) != bool.Parse(dgvToTrinh[e.ColumnIndex, e.RowIndex].Value.ToString()))
            //    if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            //    {
            //        TT_ToTrinhDCHD totrinh = _cToTrinhDCHD.Get(decimal.Parse(dgvToTrinh["ID", e.RowIndex].Value.ToString()));
            //        if (totrinh.Khoa == false)
            //        {
            //            MessageBox.Show("Chưa Khóa, Không được check", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }
            //        totrinh.DaKy = bool.Parse(e.FormattedValue.ToString());
            //        if (_cToTrinhDCHD.Sua(totrinh))
            //        {
            //            if (totrinh.DaKy == true)
            //                foreach (TT_ToTrinhDCHD_ChiTiet item in totrinh.TT_ToTrinhDCHD_ChiTiets.ToList())
            //                {
            //                    //string[] MaHDs = item.MaHD.Split(',');
            //                    string[] SoHoaDons = item.SoHoaDon.Split(',');
            //                    foreach (string SoHoaDon in SoHoaDons)
            //                        if (String.IsNullOrEmpty(SoHoaDon) == false && _cLenhHuy.CheckExist(SoHoaDon) == false)
            //                        {
            //                            TT_LenhHuy lenhhuy = new TT_LenhHuy();
            //                            lenhhuy.MaHD = _cHoaDon.Get(SoHoaDon).ID_HOADON;
            //                            lenhhuy.SoHoaDon = SoHoaDon;
            //                            lenhhuy.TinhTrang = totrinh.TT_ToTrinhDCHD_ChiTiets.SingleOrDefault(itemLst => itemLst.DanhBo == item.DanhBo).GhiChu;
            //                            _cLenhHuy.Them(lenhhuy);
            //                        }
            //                }
            //        }
            //    }
            //    else
            //        MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvCTToTrinh_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvCTToTrinh.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
            if (dgvCTToTrinh.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvCTToTrinh.Columns[e.ColumnIndex].Name == "TieuThu" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvCTToTrinh_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvCTToTrinh.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvCTToTrinh_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvCTToTrinh["IDCT", e.RowIndex].Value != null)
            {
                if (dgvCTToTrinh["IDCT", e.RowIndex].Value.ToString() != "" && dgvCTToTrinh.Columns[e.ColumnIndex].Name == "LyDo" && (dgvCTToTrinh[e.ColumnIndex, e.RowIndex].Value == null || e.FormattedValue.ToString() != dgvCTToTrinh[e.ColumnIndex, e.RowIndex].Value.ToString()))
                    if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                    {
                        TT_ToTrinhDCHD_ChiTiet cttotrinh = _cToTrinhDCHD.get_ChiTiet(int.Parse(dgvCTToTrinh["IDCT", e.RowIndex].Value.ToString()));
                        cttotrinh.LyDo = e.FormattedValue.ToString();
                        _cToTrinhDCHD.SuaCT(cttotrinh);
                    }
                    else
                        MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (dgvCTToTrinh["IDCT", e.RowIndex].Value.ToString() != "" && dgvCTToTrinh.Columns[e.ColumnIndex].Name == "DeNghi" && (dgvCTToTrinh[e.ColumnIndex, e.RowIndex].Value == null || e.FormattedValue.ToString() != dgvCTToTrinh[e.ColumnIndex, e.RowIndex].Value.ToString()))
                    if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                    {
                        TT_ToTrinhDCHD_ChiTiet cttotrinh = _cToTrinhDCHD.get_ChiTiet(int.Parse(dgvCTToTrinh["IDCT", e.RowIndex].Value.ToString()));
                        cttotrinh.DeNghi = e.FormattedValue.ToString();
                        _cToTrinhDCHD.SuaCT(cttotrinh);
                    }
                    else
                        MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
