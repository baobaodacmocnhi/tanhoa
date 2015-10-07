using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL;
using ThuTien.LinQ;
using ThuTien.BaoCao;
using ThuTien.GUI.BaoCao;
using ThuTien.BaoCao.Doi;

namespace ThuTien.GUI.Doi
{
    public partial class frmToTrinhCatHuy : Form
    {
        string _mnu = "mnuToTrinhCatHuy";
        CHoaDon _cHoaDon = new CHoaDon();
        CCAPNUOCTANHOA _cCapNuocTanHoa = new CCAPNUOCTANHOA();
        CToTrinhCatHuy _cToTrinhCatHuy = new CToTrinhCatHuy();

        public frmToTrinhCatHuy()
        {
            InitializeComponent();
        }

        private void frmToTrinhCatHuy_Load(object sender, EventArgs e)
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

                    HOADON hoadon = _cHoaDon.GetMoiNhat(txtDanhBo.Text.Trim());
                    if (dgvCTToTrinh.DataSource == null)
                    {
                        dgvCTToTrinh.Rows.Add();

                        dgvCTToTrinh["DanhBo", dgvCTToTrinh.Rows.Count - 1].Value = hoadon.DANHBA;
                        dgvCTToTrinh["MLT", dgvCTToTrinh.Rows.Count - 1].Value = hoadon.MALOTRINH;
                        dgvCTToTrinh["HoTen", dgvCTToTrinh.Rows.Count - 1].Value = hoadon.TENKH;
                        dgvCTToTrinh["DiaChi", dgvCTToTrinh.Rows.Count - 1].Value = hoadon.SO + " " + hoadon.DUONG;
                        //dgvCTToTrinh["Ky", dgvCTToTrinh.Rows.Count - 1].Value = Ky;
                        //dgvCTToTrinh["TongCong", dgvCTToTrinh.Rows.Count - 1].Value = TongCongSo;
                        //dgvCTToTrinh["TieuThu", dgvCTToTrinh.Rows.Count - 1].Value = TieuThu;
                        dgvCTToTrinh["CoDHN", dgvCTToTrinh.Rows.Count - 1].Value = _cCapNuocTanHoa.GetCoDHN(hoadon.DANHBA);
                    }
                    else
                    {
                        DataTable dtTemp = (DataTable)dgvCTToTrinh.DataSource;

                        DataRow dr = dtTemp.NewRow();

                        dr["DanhBo"] = hoadon.DANHBA;
                        dr["MLT"] = hoadon.MALOTRINH;
                        dr["HoTen"] = hoadon.TENKH;
                        dr["DiaChi"] = hoadon.SO + " " + hoadon.DUONG;
                        //dr["Ky"] = Ky;
                        //dr["TongCong"] = TongCongSo;
                        //dr["TieuThu"] = TieuThu;
                        dr["CoDHN"] = _cCapNuocTanHoa.GetCoDHN(hoadon.DANHBA);

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
            dgvToTrinh.DataSource = _cToTrinhCatHuy.GetDSTT();
            while (dgvCTToTrinh.Rows.Count > 0)
            {
                dgvCTToTrinh.DataSource = null;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
                if (dgvCTToTrinh.Rows.Count > 0)
                    try
                    {
                        //_cToTrinhCatHuy.BeginTransaction();
                        TT_ToTrinhCatHuy totrinh;
                        if (dgvCTToTrinh.DataSource == null)
                            totrinh = new TT_ToTrinhCatHuy();
                        else
                            totrinh = _cToTrinhCatHuy.GetTT(decimal.Parse(dgvCTToTrinh["MaTT_CT", 0].Value.ToString()));
                        int MaCTTT = _cToTrinhCatHuy.GetMaxMaCTTT();

                        foreach (DataGridViewRow item in dgvCTToTrinh.Rows)
                            if (item.Cells["MaCTTT"].Value==null||string.IsNullOrEmpty(item.Cells["MaCTTT"].Value.ToString()))
                            {
                                TT_CTToTrinhCatHuy cttotrinh = new TT_CTToTrinhCatHuy();
                                cttotrinh.MaCTTT = ++MaCTTT;
                                cttotrinh.DanhBo = item.Cells["DanhBo"].Value.ToString();
                                cttotrinh.MLT = item.Cells["MLT"].Value.ToString();
                                cttotrinh.CoDHN = int.Parse(item.Cells["CoDHN"].Value.ToString());
                                cttotrinh.HoTen = item.Cells["HoTen"].Value.ToString();
                                cttotrinh.DiaChi = item.Cells["DiaChi"].Value.ToString();
                                //cttotrinh.Ky = item.Cells["Ky"].Value.ToString();
                                //cttotrinh.TongCong = int.Parse(item.Cells["TongCong"].Value.ToString());
                                //cttotrinh.TieuThu = int.Parse(item.Cells["TieuThu"].Value.ToString());
                                if (item.Cells["GhiChu"].Value != null)
                                    cttotrinh.GhiChu = item.Cells["GhiChu"].Value.ToString();
                                cttotrinh.CreateBy = CNguoiDung.MaND;
                                cttotrinh.CreateDate = DateTime.Now;

                                totrinh.TT_CTToTrinhCatHuys.Add(cttotrinh);
                            }

                        if (dgvCTToTrinh.DataSource == null)
                            if (_cToTrinhCatHuy.ThemTT(totrinh))
                            {
                                //_cToTrinhCatHuy.CommitTransaction();
                                btnXem.PerformClick();
                                MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                //_cToTrinhCatHuy.Rollback();
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        else
                            if (_cToTrinhCatHuy.SuaTT(totrinh))
                            {
                                //_cToTrinhCatHuy.CommitTransaction();
                                btnXem.PerformClick();
                                MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                //_cToTrinhCatHuy.Rollback();
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                    }
                    catch (Exception)
                    {
                        //_cToTrinhCatHuy.Rollback();
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
                        //_cToTrinhCatHuy.BeginTransaction();
                        foreach (DataGridViewRow item in dgvCTToTrinh.SelectedRows)
                        {
                            TT_CTToTrinhCatHuy cttotrinh = _cToTrinhCatHuy.GetCT(int.Parse(item.Cells["MaCTTT"].Value.ToString()));
                            if (!_cToTrinhCatHuy.XoaCT(cttotrinh))
                            {
                                //_cToTrinhCatHuy.Rollback();
                                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        ///xóa tờ trình nếu hết chi tiết
                        if (_cToTrinhCatHuy.CountCTTT(decimal.Parse(dgvToTrinh.SelectedRows[0].Cells["MaTT"].Value.ToString())) == 0)
                        {
                            TT_ToTrinhCatHuy totrinh = _cToTrinhCatHuy.GetTT(decimal.Parse(dgvToTrinh.SelectedRows[0].Cells["MaTT"].Value.ToString()));
                            _cToTrinhCatHuy.XoaTT(totrinh);
                        }

                        //_cToTrinhCatHuy.CommitTransaction();
                        btnXem.PerformClick();
                        MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        //_cToTrinhCatHuy.Rollback();
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

            if(!bool.Parse(dgvToTrinh.SelectedRows[0].Cells["Khoa"].Value.ToString()))
                foreach (DataGridViewRow item in dgvCTToTrinh.Rows)
                {
                    DataRow dr = ds.Tables["ToTrinhCatHuy"].NewRow();
                    dr["MaTT"] = item.Cells["MaTT_CT"].Value.ToString().Insert(item.Cells["MaTT_CT"].Value.ToString().Length - 2, "-");
                    dr["ThoiGian"] = DateTime.Parse(item.Cells["CreateDate_CT"].Value.ToString()).ToString("MM/yyyy");
                    dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(4, " ").Insert(8, " ");
                    dr["MLT"] = item.Cells["MLT"].Value;
                    dr["CoDHN"] = item.Cells["CoDHN"].Value;
                    dr["HoTen"] = item.Cells["HoTen"].Value;
                    dr["DiaChi"] = item.Cells["DiaChi"].Value;

                    DataTable dt = _cHoaDon.GetDSTonByDanhBo_ExceptHD0(item.Cells["DanhBo"].Value.ToString());
                    string Ky = "";
                    int TongCongSo = 0;
                    int TieuThu = 0;
                    foreach (DataRow itemTon in dt.Rows)
                    {
                        if (Ky == "")
                            Ky += itemTon["Ky"];
                        else
                            Ky += ", " + itemTon["Ky"];
                        TongCongSo += int.Parse(itemTon["TongCong"].ToString());
                        TieuThu += int.Parse(itemTon["TieuThu"].ToString());
                    }

                    dr["Ky"] = Ky;
                    dr["TongCong"] = TongCongSo;
                    dr["TieuThu"] = TieuThu;
                    dr["GhiChu"] = item.Cells["GhiChu"].Value;
                    ds.Tables["ToTrinhCatHuy"].Rows.Add(dr);
                }
            else
                foreach (DataGridViewRow item in dgvCTToTrinh.Rows)
                {
                    DataRow dr = ds.Tables["ToTrinhCatHuy"].NewRow();
                    dr["MaTT"] = item.Cells["MaTT_CT"].Value.ToString().Insert(item.Cells["MaTT_CT"].Value.ToString().Length - 2, "-");
                    dr["ThoiGian"] = DateTime.Parse(item.Cells["CreateDate_CT"].Value.ToString()).ToString("MM/yyyy");
                    dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(4, " ").Insert(8, " ");
                    dr["MLT"] = item.Cells["MLT"].Value;
                    dr["CoDHN"] = item.Cells["CoDHN"].Value;
                    dr["HoTen"] = item.Cells["HoTen"].Value;
                    dr["DiaChi"] = item.Cells["DiaChi"].Value;
                    dr["Ky"] = item.Cells["Ky"].Value;
                    dr["TongCong"] = item.Cells["TongCong"].Value;
                    dr["TieuThu"] = item.Cells["TieuThu"].Value;
                    dr["GhiChu"] = item.Cells["GhiChu"].Value;
                    ds.Tables["ToTrinhCatHuy"].Rows.Add(dr);
                }

            rptToTrinhCatHuy rpt = new rptToTrinhCatHuy();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }

        private void dgvToTrinh_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvToTrinh.Columns[e.ColumnIndex].Name == "MaTT" && e.Value != null)
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

        private void dgvToTrinh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvToTrinh.RowCount > 0)
                dgvCTToTrinh.DataSource = _cToTrinhCatHuy.GetDSCTTT(decimal.Parse(dgvToTrinh["MaTT", e.RowIndex].Value.ToString()));
        }

        private void dgvCTToTrinh_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCTToTrinh.Columns[e.ColumnIndex].Name == "GhiChu")
            {
                TT_CTToTrinhCatHuy cttotrinh = _cToTrinhCatHuy.GetCT(int.Parse(dgvCTToTrinh["MaCTTT",e.RowIndex].Value.ToString()));
                cttotrinh.GhiChu = dgvCTToTrinh["GhiChu", e.RowIndex].Value.ToString();
                _cToTrinhCatHuy.SuaCTTT(cttotrinh);
            }
        }

        private void dgvToTrinh_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvToTrinh.Columns[e.ColumnIndex].Name == "Khoa")
            {
                TT_ToTrinhCatHuy totrinh = _cToTrinhCatHuy.GetTT(decimal.Parse(dgvToTrinh["MaTT", e.RowIndex].Value.ToString()));
                if (totrinh.Khoa == false)
                {
                    List<TT_CTToTrinhCatHuy> lst = _cToTrinhCatHuy.GetListCTTT(decimal.Parse(dgvToTrinh["MaTT", e.RowIndex].Value.ToString()));

                    foreach (TT_CTToTrinhCatHuy item in lst)
                    {
                        DataTable dtTon = _cHoaDon.GetDSTonByDanhBo_ExceptHD0(item.DanhBo);
                        string Ky = "";
                        int TongCongSo = 0;
                        int TieuThu = 0;
                        foreach (DataRow itemTon in dtTon.Rows)
                        {
                            if (Ky == "")
                                Ky += itemTon["Ky"];
                            else
                                Ky += ", " + itemTon["Ky"];
                            TongCongSo += int.Parse(itemTon["TongCong"].ToString());
                            TieuThu += int.Parse(itemTon["TieuThu"].ToString());
                        }

                        item.Ky = Ky;
                        item.TongCong = TongCongSo;
                        item.TieuThu = TieuThu;

                        _cToTrinhCatHuy.SuaCTTT(item);
                    }

                    totrinh.Khoa = bool.Parse(dgvToTrinh["Khoa", e.RowIndex].Value.ToString());
                    _cToTrinhCatHuy.SuaTT(totrinh);
                }
                else
                    MessageBox.Show("Đã khóa, không được quyền tự ý mở \r\n Xin vui lòng liên hệ CNTT", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
