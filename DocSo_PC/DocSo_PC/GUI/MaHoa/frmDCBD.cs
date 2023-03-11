using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.MaHoa;
using DocSo_PC.DAL.QuanTri;
using DocSo_PC.LinQ;
using System.Transactions;
using DocSo_PC.BaoCao;
using DocSo_PC.BaoCao.MaHoa;
using DocSo_PC.GUI.BaoCao;
using DocSo_PC.DAL;
using DocSo_PC.DAL.Doi;

namespace DocSo_PC.GUI.MaHoa
{
    public partial class frmDCBD : Form
    {
        string _mnu = "mnuDCBD";
        CDonTu _cDonTu = new CDonTu();
        CDocSo _cDocSo = new CDocSo();
        CDHN _cDHN = new CDHN();
        CDCBD _cDCBD = new CDCBD();
        CLichDocSo _cLDS = new CLichDocSo();
        CThuongVu _cThuongVu = new CThuongVu();
        CThuTien _cThuTien = new CThuTien();
        wrDHN.wsDHN _wsDHN = new wrDHN.wsDHN();
        MaHoa_DCBD _dcbd = null;

        public frmDCBD()
        {
            InitializeComponent();
        }

        private void frmDieuChinhThongTin_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
            dgvDCBD.AutoGenerateColumns = false;
            dgvHinh.AutoGenerateColumns = false;
            cmbTimTheo.SelectedIndex = 0;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = _cDonTu.getDS_ChuyenDCBD(dateTuNgay.Value, dateDenNgay.Value);
            string str = _cLDS.getHieuLucKyToi();
            foreach (DataGridViewRow item in dgvDanhSach.Rows)
            {
                item.Cells["Chon"].Value = true;
                item.Cells["HieuLucKy"].Value = str;
                if (item.Cells["DanhBo"].Value != null && item.Cells["DanhBo"].Value.ToString().Length == 11)
                {
                    HOADON hd = _cThuTien.GetMoiNhat(item.Cells["DanhBo"].Value.ToString());
                    if (hd != null)
                        item.Cells["GiaBieuCu"].Value = hd.GB;
                }
            }
        }

        private void dgvDanhSach_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string str = _cLDS.getHieuLucKyToi();
            foreach (DataGridViewRow item in dgvDanhSach.Rows)
            {
                item.Cells["Chon"].Value = true;
                item.Cells["HieuLucKy"].Value = str;
                if (item.Cells["DanhBo"].Value != null && item.Cells["DanhBo"].Value.ToString().Length == 11)
                {
                    HOADON hd = _cThuTien.GetMoiNhat(item.Cells["DanhBo"].Value.ToString());
                    if (hd != null)
                        item.Cells["GiaBieuCu"].Value = hd.GB;
                }
            }
        }

        private void dgvDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDanhSach_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDanhSach.Columns[e.ColumnIndex].Name == "ID")
                {
                    MaHoa_DonTu dontu = _cDonTu.get(int.Parse(dgvDanhSach["ID", e.RowIndex].Value.ToString()));
                    dgvDanhSach["DanhBo", e.RowIndex].Value = dontu.DanhBo;
                    dgvDanhSach["HoTen", e.RowIndex].Value = dontu.HoTen;
                    dgvDanhSach["DiaChi", e.RowIndex].Value = dontu.DiaChi;
                    dgvDanhSach["NoiDung", e.RowIndex].Value = dontu.NoiDung;
                    dgvDanhSach["GhiChu", e.RowIndex].Value = dontu.GhiChu;
                    dgvDanhSach["Dot", e.RowIndex].Value = dontu.Dot;
                    dgvDanhSach["GiaBieuCu", e.RowIndex].Value = dontu.GiaBieu;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    foreach (DataGridViewRow item in dgvDanhSach.Rows)
                        if (item.Cells["Chon"].Value != null && bool.Parse(item.Cells["Chon"].Value.ToString()) == true && item.Cells["ID"].Value != null && item.Cells["ID"].Value.ToString() != "")
                        {
                            MaHoa_DonTu dontu = _cDonTu.get(int.Parse(item.Cells["ID"].Value.ToString()));
                            if (dontu != null)
                            {
                                MaHoa_DCBD ctdcbd = new MaHoa_DCBD();
                                if (_cDCBD.checkExist(dontu.ID, dontu.DanhBo) == true)
                                {
                                    if (MessageBox.Show("Danh Bộ " + dontu.DanhBo + " đã được Lập Điều Chỉnh Biến Động\nVẫn muốn Lập tiếp???", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                                        return;
                                }
                                else
                                    if (_cDCBD.checkExist(dontu.DanhBo, 33) == true)
                                    {
                                        if (MessageBox.Show("Danh Bộ " + dontu.DanhBo + " đã được Lập Điều Chỉnh Biến Động trong 33 ngày gần nhất\nVẫn muốn Lập tiếp???", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                                            return;
                                    }
                                ctdcbd.IDMaDon = dontu.ID;
                                ctdcbd.DanhBo = dontu.DanhBo;
                                //ctdcbd.HopDong = dontu.HopDong;
                                ctdcbd.HoTen = dontu.HoTen;
                                ctdcbd.DiaChi = dontu.DiaChi;
                                ctdcbd.MaQuanPhuong = dontu.Quan + " " + dontu.Phuong;
                                ctdcbd.Ky = dontu.Ky;
                                ctdcbd.Nam = dontu.Nam;
                                ctdcbd.Dot = dontu.Dot;
                                ctdcbd.Phuong = dontu.Phuong;
                                ctdcbd.Quan = dontu.Quan;
                                ctdcbd.GiaBieu = int.Parse(item.Cells["GiaBieuCu"].Value.ToString());
                                if (item.Cells["DiaChi_BD"].Value != null && item.Cells["DiaChi_BD"].Value.ToString() != "")
                                {
                                    ctdcbd.DiaChi_BD = item.Cells["DiaChi_BD"].Value.ToString();
                                    ctdcbd.ThongTin = "Địa Chỉ";
                                }
                                if (item.Cells["GiaBieuMoi"].Value != null && item.Cells["GiaBieuMoi"].Value.ToString() != "")
                                {
                                    ctdcbd.GiaBieu_BD = int.Parse(item.Cells["GiaBieuMoi"].Value.ToString());
                                    if (ctdcbd.ThongTin == "")
                                        ctdcbd.ThongTin = "Giá Biểu";
                                    else
                                        ctdcbd.ThongTin += ", Giá Biểu";
                                }
                                ctdcbd.DinhMuc = dontu.DinhMuc;
                                ctdcbd.DinhMucHN = dontu.DinhMucHN;
                                ctdcbd.HieuLucKy = item.Cells["HieuLucKy"].Value.ToString();
                                ctdcbd.CongDung = item.Cells["GhiChu"].Value.ToString();
                                ctdcbd.PhieuDuocKy = true;
                                if (_cDCBD.Them(ctdcbd))
                                {
                                    if (dontu != null)
                                    {
                                        _cDonTu.Them_LichSu(ctdcbd.CreateDate.Value, "DCBD", "Đã Điều Chỉnh Biến Động, " + ctdcbd.ThongTin, ctdcbd.ID, dontu.ID);
                                    }
                                }
                            }
                        }
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.Text)
            {
                case "Thời Gian":
                    panel_Time.Visible = true;
                    panel_NoiDung.Visible = false;
                    break;
                default:
                    panel_Time.Visible = false;
                    panel_NoiDung.Visible = true;
                    break;
            }
        }

        private void btnXem_DS_Click(object sender, EventArgs e)
        {
            switch (cmbTimTheo.Text)
            {
                case "Thời Gian":
                    dgvDCBD.DataSource = _cDCBD.getDS(dateTu_DS.Value, dateDen_DS.Value);
                    break;
                case "Mã Đơn":
                    if (txtDenSo.Text.Trim() != "")
                        dgvDCBD.DataSource = _cDCBD.getDS_MaDon(int.Parse(txtTuSo.Text.Trim()), int.Parse(txtDenSo.Text.Trim()));
                    else
                        dgvDCBD.DataSource = _cDCBD.getDS_MaDon(int.Parse(txtTuSo.Text.Trim()));
                    break;
                case "Số Phiếu":
                    if (txtDenSo.Text.Trim() != "")
                        dgvDCBD.DataSource = _cDCBD.getDS_SoPhieu(int.Parse(txtTuSo.Text.Trim()), int.Parse(txtDenSo.Text.Trim()));
                    else
                        dgvDCBD.DataSource = _cDCBD.getDS_SoPhieu(int.Parse(txtTuSo.Text.Trim()));
                    break;
                case "Danh Bộ":
                    dgvDCBD.DataSource = _cDCBD.getDS_DanhBo(txtTuSo.Text.Trim());
                    break;
            }
        }

        private void txtTuSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnXem_DS.PerformClick();
        }

        private void txtDenSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnXem_DS.PerformClick();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        foreach (DataGridViewRow item in dgvDCBD.Rows)
                            if (item.Cells["Chon_DS"].Value != null && bool.Parse(item.Cells["Chon_DS"].Value.ToString()) == true)
                            {
                                MaHoa_DCBD en = _cDCBD.get(int.Parse(item.Cells["ID_DS"].Value.ToString()));
                                if (en != null)
                                {
                                    string flagID = en.ID.ToString();
                                    var transactionOptions = new TransactionOptions();
                                    transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
                                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                                    {
                                        if (_cDCBD.Xoa(en))
                                        {
                                            _wsDHN.xoa_Folder_Hinh_MaHoa("DCBD", flagID);
                                            scope.Complete();
                                            scope.Dispose();
                                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                            }
                }
                else
                    MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                dsBaoCao dsBaoCao = new dsBaoCao();
                foreach (DataGridViewRow item in dgvDCBD.Rows)
                    if (item.Cells["Chon_DS"].Value != null && bool.Parse(item.Cells["Chon_DS"].Value.ToString()) == true)
                    {
                        MaHoa_DCBD en = _cDCBD.get(int.Parse(item.Cells["ID_DS"].Value.ToString()));
                        if (en != null)
                        {
                            DataRow dr = dsBaoCao.Tables["DCBD"].NewRow();

                            dr["MaDon"] = en.IDMaDon.ToString();
                            dr["SoPhieu"] = en.ID.ToString();
                            dr["ThongTin"] = en.ThongTin.ToUpper();
                            dr["HieuLucKy"] = en.HieuLucKy;
                            dr["Dot"] = en.Dot;
                            ///Hiện tại xử lý mã số thuế như vậy
                            dr["DanhBo"] = en.DanhBo.Insert(7, " ").Insert(4, " ");
                            //dr["HopDong"] = en.HopDong;
                            dr["HoTen"] = en.HoTen;
                            dr["DiaChi"] = en.DiaChi;
                            dr["HoTenBD"] = en.HoTen_BD;
                            dr["DiaChiBD"] = en.DiaChi_BD;
                            dr["MaQuanPhuong"] = en.MaQuanPhuong;
                            dr["GiaBieu"] = en.GiaBieu;
                            dr["DinhMuc"] = en.DinhMuc;
                            dr["DinhMucHN"] = en.DinhMucHN;
                            ///Biến Động
                            dr["GiaBieuBD"] = en.GiaBieu_BD;
                            dr["ChucVu"] = "TUQ GIÁM ĐỐC\n" + CNguoiDung.ChucVu.ToUpper() + " " + CNguoiDung.TenPhong.ToUpper();
                            dr["NguoiKy"] = CNguoiDung.NguoiKy.ToUpper();
                            dsBaoCao.Tables["DCBD"].Rows.Add(dr);
                        }
                    }
                rptPhieuDCBD_15112019 rpt = new rptPhieuDCBD_15112019();
                rpt.SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInDSPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                dsBaoCao dsBaoCao = new dsBaoCao();
                foreach (DataGridViewRow item in dgvDCBD.Rows)
                    if (item.Cells["Chon_DS"].Value != null && bool.Parse(item.Cells["Chon_DS"].Value.ToString()) == true)
                    {
                        MaHoa_DCBD en = _cDCBD.get(int.Parse(item.Cells["ID_DS"].Value.ToString()));
                        if (en != null)
                        {
                            DataRow dr = dsBaoCao.Tables["DCBD"].NewRow();

                            dr["MaDon"] = en.IDMaDon.ToString();
                            dr["SoPhieu"] = en.ID.ToString();
                            dr["ThongTin"] = en.ThongTin.ToUpper();
                            dr["HieuLucKy"] = en.HieuLucKy;
                            dr["Dot"] = en.Dot;
                            ///Hiện tại xử lý mã số thuế như vậy
                            dr["DanhBo"] = en.DanhBo.Insert(7, " ").Insert(4, " ");
                            //dr["HopDong"] = en.HopDong;
                            dr["HoTen"] = en.HoTen;
                            dr["DiaChi"] = en.DiaChi;
                            dr["HoTenBD"] = en.HoTen_BD;
                            dr["DiaChiBD"] = en.DiaChi_BD;
                            dr["MaQuanPhuong"] = en.MaQuanPhuong;
                            dr["GiaBieu"] = en.GiaBieu;
                            dr["DinhMuc"] = en.DinhMuc;
                            dr["DinhMucHN"] = en.DinhMucHN;
                            ///Biến Động
                            dr["GiaBieuBD"] = en.GiaBieu_BD;
                            dr["ChucVu"] = "TUQ GIÁM ĐỐC\n" + CNguoiDung.ChucVu.ToUpper() + " " + CNguoiDung.TenPhong.ToUpper();
                            dr["NguoiKy"] = CNguoiDung.NguoiKy.ToUpper();
                            dsBaoCao.Tables["DCBD"].Rows.Add(dr);
                        }
                    }
                rptDSPhieuDCBD_15112019 rpt = new rptDSPhieuDCBD_15112019();
                rpt.SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInThuBao_Click(object sender, EventArgs e)
        {
            try
            {
                dsBaoCao dsBaoCao = new dsBaoCao();
                dsBaoCao dsBaoCaoCC = new dsBaoCao();
                foreach (DataGridViewRow item in dgvDCBD.Rows)
                    if (item.Cells["Chon_DS"].Value != null && bool.Parse(item.Cells["Chon_DS"].Value.ToString()) == true)
                    {
                        MaHoa_DCBD en = _cDCBD.get(int.Parse(item.Cells["ID_DS"].Value.ToString()));
                        if (en.CongDung != null && en.CongDung != "")
                        {
                            if (en.GiaBieu == 68 || en.GiaBieu_BD == 68)
                            {
                                DataRow dr = dsBaoCaoCC.Tables["DCBD"].NewRow();

                                dr["KyHieuPhong"] = "QLĐHN";
                                dr["SoPhieu"] = en.ID.ToString();
                                dr["HieuLucKy"] = en.HieuLucKy;
                                dr["DanhBo"] = en.DanhBo.Insert(7, " ").Insert(4, " ");
                                dr["HopDong"] = en.MaHoa_DonTu.MLT;
                                dr["HoTen"] = en.HoTen;
                                dr["DiaChi"] = en.DiaChi + _cDHN.getPhuongQuan(en.Quan, en.Phuong);
                                dr["ThongTin"] = en.CongDung;
                                string[] HieuLucKys = en.HieuLucKy.Split('/');
                                DataTable gn = _cThuongVu.getGiaNuoc(HieuLucKys[1]);
                                if (gn != null && gn.Rows.Count > 0)
                                {
                                    int ThueTDVTN_VAT = 0;
                                    if (gn.Rows[0]["VAT2_Ky"].ToString().Contains(int.Parse(HieuLucKys[0]).ToString("00") + "/" + HieuLucKys[1]))
                                        ThueTDVTN_VAT = int.Parse(gn.Rows[0]["VAT2"].ToString());
                                    else
                                        ThueTDVTN_VAT = int.Parse(gn.Rows[0]["VAT"].ToString());
                                    dr["TienNuocSH"] = (int)(int.Parse(gn.Rows[0]["SHTM"].ToString()) + int.Parse(gn.Rows[0]["SHTM"].ToString()) * 0.05 + int.Parse(gn.Rows[0]["SHTM"].ToString()) * int.Parse(gn.Rows[0]["PhiBVMT"].ToString()) / 100 + int.Parse(gn.Rows[0]["SHTM"].ToString()) * int.Parse(gn.Rows[0]["PhiBVMT"].ToString()) / 100 * ThueTDVTN_VAT / 100);
                                    dr["TienNuocSHVuot1"] = (int)(int.Parse(gn.Rows[0]["SHVM1"].ToString()) + int.Parse(gn.Rows[0]["SHVM1"].ToString()) * 0.05 + int.Parse(gn.Rows[0]["SHVM1"].ToString()) * int.Parse(gn.Rows[0]["PhiBVMT"].ToString()) / 100 + int.Parse(gn.Rows[0]["SHVM1"].ToString()) * int.Parse(gn.Rows[0]["PhiBVMT"].ToString()) / 100 * ThueTDVTN_VAT / 100);
                                    dr["TienNuocSHVuot2"] = (int)(int.Parse(gn.Rows[0]["SHVM2"].ToString()) + int.Parse(gn.Rows[0]["SHVM2"].ToString()) * 0.05 + int.Parse(gn.Rows[0]["SHVM2"].ToString()) * int.Parse(gn.Rows[0]["PhiBVMT"].ToString()) / 100 + int.Parse(gn.Rows[0]["SHVM2"].ToString()) * int.Parse(gn.Rows[0]["PhiBVMT"].ToString()) / 100 * ThueTDVTN_VAT / 100);
                                    dr["TienNuocKDDV"] = (int)(int.Parse(gn.Rows[0]["KDDV"].ToString()) + int.Parse(gn.Rows[0]["KDDV"].ToString()) * 0.05 + int.Parse(gn.Rows[0]["KDDV"].ToString()) * int.Parse(gn.Rows[0]["PhiBVMT"].ToString()) / 100 + int.Parse(gn.Rows[0]["KDDV"].ToString()) * int.Parse(gn.Rows[0]["PhiBVMT"].ToString()) / 100 * ThueTDVTN_VAT / 100);
                                }
                                if (en.SH_BD != "")
                                    dr["SH"] = en.SH_BD;
                                else
                                    if (en.SH != "")
                                        dr["SH"] = en.SH;

                                if (en.DV_BD != "")
                                    dr["DV"] = en.DV_BD;
                                else
                                    if (en.DV != "")
                                        dr["DV"] = en.DV;
                                dr["MaDon"] = en.IDMaDon.ToString();
                                dr["ChucVu"] = CNguoiDung.ChucVu.ToUpper() + " " + CNguoiDung.TenPhong.ToUpper();
                                dr["NguoiKy"] = CNguoiDung.NguoiKy.ToUpper();
                                dr["TenPhong"] = "";
                                dsBaoCaoCC.Tables["DCBD"].Rows.Add(dr);

                                DataRow drLogo = dsBaoCaoCC.Tables["BaoCao"].NewRow();
                                drLogo["PathLogo"] = Application.StartupPath.ToString() + @"\Resources\logocongty.png";
                                dsBaoCaoCC.Tables["BaoCao"].Rows.Add(drLogo);
                            }
                            else
                            {
                                DataRow dr = dsBaoCao.Tables["DCBD"].NewRow();

                                dr["KyHieuPhong"] = "QLĐHN";
                                dr["SoPhieu"] = en.ID.ToString();
                                dr["HieuLucKy"] = en.HieuLucKy;
                                dr["DanhBo"] = en.DanhBo.Insert(7, " ").Insert(4, " ");
                                dr["HopDong"] = en.MaHoa_DonTu.MLT;
                                dr["HoTen"] = en.HoTen;
                                dr["DiaChi"] = en.DiaChi;
                                dr["ThongTin"] = en.CongDung;
                                string[] HieuLucKys = en.HieuLucKy.Split('/');
                                DataTable gn = _cThuongVu.getGiaNuoc(HieuLucKys[1]);
                                if (gn != null)
                                {
                                    int ThueTDVTN_VAT = 0;
                                    if (gn.Rows[0]["VAT2_Ky"].ToString().Contains(int.Parse(HieuLucKys[0]).ToString("00") + "/" + HieuLucKys[1]))
                                        ThueTDVTN_VAT = int.Parse(gn.Rows[0]["VAT2"].ToString());
                                    else
                                        ThueTDVTN_VAT = int.Parse(gn.Rows[0]["VAT"].ToString());
                                    dr["TienNuocSH"] = (int)(int.Parse(gn.Rows[0]["SHTM"].ToString()) + int.Parse(gn.Rows[0]["SHTM"].ToString()) * 0.05 + int.Parse(gn.Rows[0]["SHTM"].ToString()) * int.Parse(gn.Rows[0]["PhiBVMT"].ToString()) / 100 + int.Parse(gn.Rows[0]["SHTM"].ToString()) * int.Parse(gn.Rows[0]["PhiBVMT"].ToString()) / 100 * ThueTDVTN_VAT / 100);
                                    dr["TienNuocSHVuot1"] = (int)(int.Parse(gn.Rows[0]["SHVM1"].ToString()) + int.Parse(gn.Rows[0]["SHVM1"].ToString()) * 0.05 + int.Parse(gn.Rows[0]["SHVM1"].ToString()) * int.Parse(gn.Rows[0]["PhiBVMT"].ToString()) / 100 + int.Parse(gn.Rows[0]["SHVM1"].ToString()) * int.Parse(gn.Rows[0]["PhiBVMT"].ToString()) / 100 * ThueTDVTN_VAT / 100);
                                    dr["TienNuocSHVuot2"] = (int)(int.Parse(gn.Rows[0]["SHVM2"].ToString()) + int.Parse(gn.Rows[0]["SHVM2"].ToString()) * 0.05 + int.Parse(gn.Rows[0]["SHVM2"].ToString()) * int.Parse(gn.Rows[0]["PhiBVMT"].ToString()) / 100 + int.Parse(gn.Rows[0]["SHVM2"].ToString()) * int.Parse(gn.Rows[0]["PhiBVMT"].ToString()) / 100 * ThueTDVTN_VAT / 100);
                                    dr["TienNuocKDDV"] = (int)(int.Parse(gn.Rows[0]["KDDV"].ToString()) + int.Parse(gn.Rows[0]["KDDV"].ToString()) * 0.05 + int.Parse(gn.Rows[0]["KDDV"].ToString()) * int.Parse(gn.Rows[0]["PhiBVMT"].ToString()) / 100 + int.Parse(gn.Rows[0]["KDDV"].ToString()) * int.Parse(gn.Rows[0]["PhiBVMT"].ToString()) / 100 * ThueTDVTN_VAT / 100);
                                }
                                if (en.SH_BD != "")
                                    dr["SH"] = en.SH_BD;
                                else
                                    if (en.SH != "")
                                        dr["SH"] = en.SH;

                                if (en.DV_BD != "")
                                    dr["DV"] = en.DV_BD;
                                else
                                    if (en.DV != "")
                                        dr["DV"] = en.DV;
                                dr["MaDon"] = en.IDMaDon.ToString();

                                dr["ChucVu"] = CNguoiDung.ChucVu.ToUpper() + " " + CNguoiDung.TenPhong.ToUpper();
                                dr["NguoiKy"] = CNguoiDung.NguoiKy.ToUpper();
                                dr["TenPhong"] = "";
                                dsBaoCao.Tables["DCBD"].Rows.Add(dr);

                                DataRow drLogo = dsBaoCao.Tables["BaoCao"].NewRow();
                                drLogo["PathLogo"] = Application.StartupPath.ToString() + @"\Resources\logocongty.png";
                                dsBaoCao.Tables["BaoCao"].Rows.Add(drLogo);
                            }
                        }
                    }
                if (dsBaoCaoCC.Tables["DCBD"].Rows.Count > 0)
                {
                    rptThuBaoDCBD_ChungCu rpt = new rptThuBaoDCBD_ChungCu();
                    rpt.SetDataSource(dsBaoCaoCC);
                    rpt.Subreports[0].SetDataSource(dsBaoCaoCC);
                    frmShowBaoCao frm = new frmShowBaoCao(rpt);
                    frm.Show();
                }
                if (dsBaoCao.Tables["DCBD"].Rows.Count > 0)
                {
                    rptThuBaoDCBD rpt = new rptThuBaoDCBD();
                    rpt.SetDataSource(dsBaoCao);
                    rpt.Subreports[0].SetDataSource(dsBaoCao);
                    frmShowBaoCao frm = new frmShowBaoCao(rpt);
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInNhan_Click(object sender, EventArgs e)
        {
            try
            {
                dsBaoCao dsBaoCao1 = new dsBaoCao();
                dsBaoCao dsBaoCao2 = new dsBaoCao();
                bool flag = true;///in 2 bên
                foreach (DataGridViewRow item in dgvDCBD.Rows)
                    if (item.Cells["Chon_DS"].Value != null && bool.Parse(item.Cells["Chon_DS"].Value.ToString()) == true)
                    {
                        MaHoa_DCBD en = _cDCBD.get(int.Parse(item.Cells["ID_DS"].Value.ToString()));
                        if (en.CongDung != null && en.CongDung != "")
                        {
                            if (flag == true)
                            {
                                DataRow dr = dsBaoCao1.Tables["BaoCao"].NewRow();

                                dr["HoTen"] = en.HoTen;
                                dr["DiaChi"] = en.DiaChi;
                                dr["MaDon"] = en.IDMaDon.ToString() + "/TB";

                                dsBaoCao1.Tables["BaoCao"].Rows.Add(dr);
                                flag = false;
                            }
                            else
                            {
                                DataRow dr = dsBaoCao2.Tables["BaoCao"].NewRow();

                                dr["HoTen"] = en.HoTen;
                                dr["DiaChi"] = en.DiaChi;
                                dr["MaDon"] = en.IDMaDon.ToString() + "/TB";

                                dsBaoCao2.Tables["BaoCao"].Rows.Add(dr);
                                flag = true;
                            }
                        }
                    }
                rptKinhGui rpt = new rptKinhGui();
                rpt.Subreports[0].SetDataSource(dsBaoCao1);
                rpt.Subreports[1].SetDataSource(dsBaoCao2);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDCBD_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDCBD.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDCBD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _dcbd = _cDCBD.get(int.Parse(dgvDCBD.Rows[e.RowIndex].Cells["ID_DS"].Value.ToString()));
                dgvHinh.Rows.Clear();
                foreach (MaHoa_DCBD_Hinh item in _dcbd.MaHoa_DCBD_Hinhs.ToList())
                {
                    var index = dgvHinh.Rows.Add();
                    dgvHinh.Rows[index].Cells["ID_Hinh"].Value = item.ID;
                    dgvHinh.Rows[index].Cells["Name_Hinh"].Value = item.Name;
                    dgvHinh.Rows[index].Cells["Loai_Hinh"].Value = item.Loai;
                }
                if (dgvDCBD.Columns[e.ColumnIndex].Name == "XemHinh")
                {
                    MaHoa_DonTu dontu = _cDonTu.get(int.Parse(dgvDCBD.Rows[e.RowIndex].Cells["IDMaDon_DS"].Value.ToString()));
                    _cDonTu.LoadImageView(_cDonTu.imageToByteArray(_cDonTu.byteArrayToImage(_wsDHN.get_Hinh_MaHoa("DonTu", dontu.ID.ToString(), dontu.MaHoa_DonTu_Hinhs.SingleOrDefault().Name + dontu.MaHoa_DonTu_Hinhs.SingleOrDefault().Loai))));
                }
            }
            catch { }
        }

        private void dgvDCBD_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDCBD.Columns[e.ColumnIndex].Name == "GhiChu_DS" || dgvDCBD.Columns[e.ColumnIndex].Name == "GiaBieu_DS" || dgvDCBD.Columns[e.ColumnIndex].Name == "GiaBieu_BD" || dgvDCBD.Columns[e.ColumnIndex].Name == "HieuLucKy_DS")
                    if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                    {
                        if (_dcbd != null)
                        {
                            _dcbd.GiaBieu = int.Parse(dgvDCBD["GiaBieu_DS", e.RowIndex].Value.ToString());
                            _dcbd.GiaBieu_BD = int.Parse(dgvDCBD["GiaBieu_BD", e.RowIndex].Value.ToString());
                            _dcbd.HieuLucKy = dgvDCBD["HieuLucKy_DS", e.RowIndex].Value.ToString();
                            _dcbd.CongDung = dgvDCBD["GhiChu_DS", e.RowIndex].Value.ToString();
                            if (_cDCBD.Sua(_dcbd))
                            {
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                        MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png|PDF files (*.pdf) | *.pdf";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    byte[] bytes = _cDCBD.scanVanBan(dialog.FileName);
                    if (_dcbd != null)
                    {
                        if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                        {
                            MaHoa_DCBD_Hinh en = new MaHoa_DCBD_Hinh();
                            en.IDParent = _dcbd.ID;
                            en.Name = DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss");
                            en.Loai = System.IO.Path.GetExtension(dialog.FileName);
                            if (_wsDHN.ghi_Hinh_MaHoa("DCBD", _dcbd.ID.ToString(), en.Name + en.Loai, bytes) == true)
                                if (_cDCBD.Them_Hinh(en) == true)
                                {
                                    //_cDCBD.Refresh();
                                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    var index = dgvHinh.Rows.Add();
                                    dgvHinh.Rows[index].Cells["Name_Hinh"].Value = en.Name;
                                    dgvHinh.Rows[index].Cells["Bytes_Hinh"].Value = Convert.ToBase64String(bytes);
                                    dgvHinh.Rows[index].Cells["Loai_Hinh"].Value = System.IO.Path.GetExtension(dialog.FileName);
                                }
                        }
                        else
                            MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvHinh_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            byte[] hinh = _wsDHN.get_Hinh_MaHoa("DCBD", _dcbd.ID.ToString(), dgvHinh.CurrentRow.Cells["Name_Hinh"].Value.ToString() + dgvHinh.CurrentRow.Cells["Loai_Hinh"].Value.ToString());
            if (hinh != null)
                _cDCBD.LoadImageView(hinh);
            else
                MessageBox.Show("Lỗi File", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvHinh_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (_dcbd != null)
                    if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                    {
                        if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            if (e.Row.Cells["ID_Hinh"].Value != null)
                                if (_wsDHN.xoa_Hinh_MaHoa("DCBD", _dcbd.ID.ToString(), e.Row.Cells["Name_Hinh"].Value.ToString() + e.Row.Cells["Loai_Hinh"].Value.ToString()) == true)
                                    if (_cDCBD.Xoa_Hinh(_cDCBD.get_Hinh(int.Parse(e.Row.Cells["ID_Hinh"].Value.ToString()))))
                                    {
                                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        dgvHinh.Rows.RemoveAt(e.Row.Index);
                                    }
                                    else
                                        MessageBox.Show("Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapNhatTraiDat_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        foreach (DataGridViewRow item in dgvDCBD.Rows)
                            if (item.Cells["Chon_DS"].Value != null && bool.Parse(item.Cells["Chon_DS"].Value.ToString()) == true && bool.Parse(item.Cells["ChuyenDocSo"].Value.ToString()) == false)
                            {
                                MaHoa_DCBD en = _cDCBD.get(int.Parse(item.Cells["ID_DS"].Value.ToString()));
                                if (en != null)
                                {
                                    string sql = "";
                                    if (!string.IsNullOrEmpty(en.DiaChi_BD))
                                    {
                                        if (sql == "")
                                            sql += " DiaChiHoaDon=N'" + en.DiaChi_BD + "',SOHO=SONHA+' '+TENDUONG,SONHA=N'" + en.DiaChi_BD.Substring(0, en.DiaChi_BD.IndexOf(" ")) + "',TENDUONG=N'" + en.DiaChi_BD.Substring((en.DiaChi_BD.IndexOf(" ") + 1), en.DiaChi_BD.Length - en.DiaChi_BD.IndexOf(" ") - 1) + "'";
                                        else
                                            sql += ",DiaChiHoaDon=N'" + en.DiaChi_BD + "',SOHO=SONHA+' '+TENDUONG,SONHA=N'" + en.DiaChi_BD.Substring(0, en.DiaChi_BD.IndexOf(" ")) + "',TENDUONG=N'" + en.DiaChi_BD.Substring((en.DiaChi_BD.IndexOf(" ") + 1), en.DiaChi_BD.Length - en.DiaChi_BD.IndexOf(" ") - 1) + "'";
                                    }
                                    if (!string.IsNullOrEmpty(en.GiaBieu_BD.ToString()))
                                    {
                                        if (sql == "")
                                            sql += "GIABIEU=" + en.GiaBieu_BD.Value.ToString();
                                        else
                                            sql += ",GIABIEU=" + en.GiaBieu_BD.Value.ToString();
                                    }
                                    if (sql != "")
                                        CDHN._cDAL.ExecuteNonQuery("update TB_DULIEUKHACHHANG set " + sql + " where DANHBO='" + en.DanhBo + "'");
                                    TB_GHICHU ghichu = new TB_GHICHU();
                                    ghichu.DANHBO = en.DanhBo;
                                    ghichu.DONVI = "QLDHN";
                                    ghichu.NOIDUNG = "PYC: " + en.ID.ToString();
                                    ghichu.NOIDUNG += " ," + en.CreateDate.Value.ToString("dd/MM/yyyy");
                                    ghichu.NOIDUNG += " - HL : " + en.HieuLucKy + " - ĐC";
                                    if (!string.IsNullOrEmpty(en.DiaChi_BD))
                                    {
                                        ghichu.NOIDUNG += " Địa Chỉ: " + en.DiaChi_BD + ",";
                                    }
                                    if (!string.IsNullOrEmpty(en.GiaBieu_BD.ToString()))
                                    {
                                        ghichu.NOIDUNG += " Giá Biểu Từ " + en.GiaBieu + " -> " + en.GiaBieu_BD + ",";
                                    }
                                    string sqlGhiChu = "insert into TB_GHICHU(DANHBO,DONVI,NOIDUNG,CREATEDATE,CREATEBY)values('" + ghichu.DANHBO + "',N'" + ghichu.DONVI + "',N'" + ghichu.NOIDUNG + "','" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture) + "',N'" + CNguoiDung.HoTen + "')";
                                    if (CDHN._cDAL.ExecuteNonQuery(sqlGhiChu))
                                    {
                                        en.ChuyenDocSo = true;
                                        en.NgayChuyenDocSo = DateTime.Now;
                                        en.NguoiChuyenDocSo = CNguoiDung.MaND;
                                        _cDCBD.Sua(en);
                                    }
                                }
                            }
                        MessageBox.Show("Cập Nhật Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThuHoiCapNhatTraiDat_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        foreach (DataGridViewRow item in dgvDCBD.Rows)
                            if (item.Cells["Chon_DS"].Value != null && bool.Parse(item.Cells["Chon_DS"].Value.ToString()) == true && bool.Parse(item.Cells["ChuyenDocSo"].Value.ToString()) == true)
                            {
                                MaHoa_DCBD en = _cDCBD.get(int.Parse(item.Cells["ID_DS"].Value.ToString()));
                                if (en != null)
                                {
                                    string sql = "";
                                    if (!string.IsNullOrEmpty(en.DiaChi_BD))
                                    {
                                        if (sql == "")
                                            sql += " DiaChiHoaDon=N'" + en.DiaChi + "',SONHA=N'" + en.DiaChi.Substring(0, en.DiaChi.IndexOf(" ")) + "',TENDUONG=N'" + en.DiaChi.Substring((en.DiaChi.IndexOf(" ") + 1), en.DiaChi.Length - en.DiaChi.IndexOf(" ") - 1) + "'";
                                        else
                                            sql += ",DiaChiHoaDon=N'" + en.DiaChi + "',SONHA=N'" + en.DiaChi.Substring(0, en.DiaChi.IndexOf(" ")) + "',TENDUONG=N'" + en.DiaChi.Substring((en.DiaChi.IndexOf(" ") + 1), en.DiaChi.Length - en.DiaChi.IndexOf(" ") - 1) + "'";
                                    }
                                    if (!string.IsNullOrEmpty(en.GiaBieu_BD.ToString()))
                                    {
                                        if (sql == "")
                                            sql += " GIABIEU=" + en.GiaBieu.Value.ToString();
                                        else
                                            sql += ",GIABIEU=" + en.GiaBieu.Value.ToString();
                                    }
                                    if (sql != "")
                                        CDHN._cDAL.ExecuteNonQuery("update TB_DULIEUKHACHHANG set " + sql + " where DANHBO='" + en.DanhBo + "'");
                                    string sqlGhiChu = "delete from TB_GHICHU where DONVI=N'QLDHN' and DANHBO='" + en.DanhBo + "' and NOIDUNG like 'PYC: " + en.ID.ToString() + "%'";
                                    if (CDHN._cDAL.ExecuteNonQuery(sqlGhiChu))
                                    {
                                        en.ChuyenDocSo = false;
                                        en.NgayChuyenDocSo = null;
                                        en.NguoiChuyenDocSo = null;
                                        _cDCBD.Sua(en);
                                    }
                                }
                            }
                        MessageBox.Show("Cập Nhật Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImportHinh_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    using (FolderBrowserDialog dlg = new FolderBrowserDialog())
                    {
                        dlg.Description = "Chọn Thư Mục Chứa File";
                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            foreach (string file in System.IO.Directory.GetFiles(dlg.SelectedPath))
                                if (file.ToLower().Contains(".jpg") || file.ToLower().Contains(".jpeg") || file.ToLower().Contains(".png") || file.ToLower().Contains(".pdf"))
                                {
                                    byte[] bytes = _cDCBD.scanVanBan(file);
                                    MaHoa_DCBD_Hinh en = new MaHoa_DCBD_Hinh();
                                    MaHoa_DCBD dcbd = _cDCBD.get_MaDon(int.Parse(System.IO.Path.GetFileNameWithoutExtension(file)));
                                    en.IDParent = dcbd.ID;
                                    en.Name = DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss");
                                    en.Loai = System.IO.Path.GetExtension(file);
                                    if (_wsDHN.ghi_Hinh_MaHoa("DCBD", dcbd.ID.ToString(), en.Name + en.Loai, bytes) == true)
                                        if (_cDCBD.Them_Hinh(en) == true)
                                        {

                                        }
                                }
                        }
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
