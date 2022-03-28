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

namespace DocSo_PC.GUI.MaHoa
{
    public partial class frmDCBD : Form
    {
        string _mnu = "mnuDCBD";
        CDonTu _cDonTu = new CDonTu();
        CDCBD _cDCBD = new CDCBD();
        CThuongVu _cThuongVu = new CThuongVu();
        wrDHN.wsDHN _wsDHN = new wrDHN.wsDHN();

        public frmDCBD()
        {
            InitializeComponent();
        }

        private void frmDieuChinhThongTin_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;

        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = _cDonTu.getDS_ChuyenDCBD(dateTuNgay.Value, dateDenNgay.Value);
        }

        private void dgvDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    foreach (DataGridViewRow item in dgvDanhSach.Rows)
                        if (item.Cells["Chon"].Value != null && bool.Parse(item.Cells["Chon"].Value.ToString()) == true)
                        {
                            MaHoa_DonTu dontu = _cDonTu.get(int.Parse(item.Cells["ID"].Value.ToString()));
                            if (dontu != null)
                            {
                                MaHoa_DCBD ctdcbd = new MaHoa_DCBD();
                                if (_cDCBD.checkExist(dontu.ID, dontu.DanhBo) == true)
                                {
                                    MessageBox.Show("Danh Bộ " + dontu.DanhBo + " đã được Lập Điều Chỉnh Biến Động", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                ctdcbd.IDMaDon = dontu.ID;
                                ctdcbd.DanhBo = dontu.DanhBo;
                                ctdcbd.HopDong = dontu.HopDong;
                                ctdcbd.HoTen = dontu.HoTen;
                                ctdcbd.DiaChi = dontu.DiaChi;
                                ctdcbd.MaQuanPhuong = dontu.Quan + " " + dontu.Phuong;
                                ctdcbd.Ky = dontu.Ky.ToString();
                                ctdcbd.Nam = dontu.Nam.ToString();
                                ctdcbd.Dot = dontu.Dot.ToString();
                                ctdcbd.Phuong = dontu.Phuong;
                                ctdcbd.Quan = dontu.Quan;
                                ctdcbd.GiaBieu = int.Parse(item.Cells["GiaBieuCu"].Value.ToString());
                                ctdcbd.GiaBieu_BD = int.Parse(item.Cells["GiaBieuMoi"].Value.ToString());
                                ctdcbd.DinhMuc = dontu.DinhMuc;
                                ctdcbd.DinhMucHN = dontu.DinhMucHN;
                                ctdcbd.HieuLucKy = item.Cells["HieuLucKy"].Value.ToString();
                                ctdcbd.ThongTin = "Giá Biểu";
                                ctdcbd.CongDung = item.Cells["GhiChu"].Value.ToString();
                                ctdcbd.PhieuDuocKy = true;
                                using (TransactionScope scope = new TransactionScope())
                                    if (_cDCBD.Them(ctdcbd))
                                    {
                                        if (dontu != null)
                                        {
                                            if (_cDonTu.Them_LichSu(ctdcbd.CreateDate.Value, "DCBD", "Đã Điều Chỉnh Biến Động, " + ctdcbd.ThongTin, ctdcbd.ID, dontu.ID) == true)
                                            {
                                                scope.Complete();
                                            }
                                        }
                                        else
                                            scope.Complete();
                                    }
                            }
                        }
                    MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXem_DS_Click(object sender, EventArgs e)
        {
            dgvDCBD.DataSource = _cDCBD.getDS(dateTu_DS.Value, dateDen_DS.Value);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        foreach (DataGridViewRow item in dgvDanhSach.Rows)
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
                foreach (DataGridViewRow item in dgvDanhSach.Rows)
                    if (item.Cells["Chon_DS"].Value != null && bool.Parse(item.Cells["Chon_DS"].Value.ToString()) == true)
                    {
                        MaHoa_DCBD en = _cDCBD.get(int.Parse(item.Cells["ID_DS"].Value.ToString()));
                        if (en != null)
                        {
                            dsBaoCao dsBaoCao = new dsBaoCao();
                            DataRow dr = dsBaoCao.Tables["DCBD"].NewRow();

                            dr["MaDon"] = en.IDMaDon.ToString();
                            dr["SoPhieu"] = en.ID.ToString();
                            dr["ThongTin"] = en.ThongTin;
                            dr["HieuLucKy"] = en.HieuLucKy;
                            dr["Dot"] = en.Dot;
                            ///Hiện tại xử lý mã số thuế như vậy
                            dr["DanhBo"] = en.DanhBo.Insert(7, " ").Insert(4, " ");
                            dr["HopDong"] = en.HopDong;
                            dr["HoTen"] = en.HoTen;
                            dr["DiaChi"] = en.DiaChi;
                            dr["MaQuanPhuong"] = en.MaQuanPhuong;
                            dr["GiaBieu"] = en.GiaBieu;
                            dr["DinhMuc"] = en.DinhMuc;
                            dr["DinhMucHN"] = en.DinhMucHN;
                            ///Biến Động
                            dr["GiaBieuBD"] = en.GiaBieu_BD;

                            dsBaoCao.Tables["DCBD"].Rows.Add(dr);

                            rptPhieuDCBD_15112019 rpt = new rptPhieuDCBD_15112019();
                            rpt.SetDataSource(dsBaoCao);
                            frmShowBaoCao frm = new frmShowBaoCao(rpt);
                            frm.Show();
                        }
                    }
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

        private void btnInThongBao_Click(object sender, EventArgs e)
        {
            try
            {
                dsBaoCao dsBaoCao = new dsBaoCao();
                dsBaoCao dsBaoCaoCC = new dsBaoCao();
                foreach (DataGridViewRow item in dgvDanhSach.Rows)
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
                                dr["HopDong"] = en.HopDong;
                                dr["HoTen"] = en.HoTen;
                                dr["DiaChi"] = en.DiaChi;
                                dr["ThongTin"] = en.CongDung;
                                string[] HieuLucKys = en.HieuLucKy.Split('/');
                                DataTable gn = _cThuongVu.getGiaNuoc(HieuLucKys[1]);
                                if (gn != null && gn.Rows.Count > 0)
                                {
                                    dr["TienNuocSH"] = (int)(int.Parse(gn.Rows[0]["SHTM"].ToString()) + int.Parse(gn.Rows[0]["SHTM"].ToString()) * 0.05 + int.Parse(gn.Rows[0]["SHTM"].ToString()) * int.Parse(gn.Rows[0]["PhiBVMT"].ToString()) / 100 + int.Parse(gn.Rows[0]["SHTM"].ToString()) * int.Parse(gn.Rows[0]["PhiBVMT"].ToString()) / 100 * 0.1);
                                    dr["TienNuocSHVuot1"] = (int)(int.Parse(gn.Rows[0]["SHVM1"].ToString()) + int.Parse(gn.Rows[0]["SHVM1"].ToString()) * 0.05 + int.Parse(gn.Rows[0]["SHVM1"].ToString()) * int.Parse(gn.Rows[0]["PhiBVMT"].ToString()) / 100 + int.Parse(gn.Rows[0]["SHVM1"].ToString()) * int.Parse(gn.Rows[0]["PhiBVMT"].ToString()) / 100 * 0.1);
                                    dr["TienNuocSHVuot2"] = (int)(int.Parse(gn.Rows[0]["SHVM2"].ToString()) + int.Parse(gn.Rows[0]["SHVM2"].ToString()) * 0.05 + int.Parse(gn.Rows[0]["SHVM2"].ToString()) * int.Parse(gn.Rows[0]["PhiBVMT"].ToString()) / 100 + int.Parse(gn.Rows[0]["SHVM2"].ToString()) * int.Parse(gn.Rows[0]["PhiBVMT"].ToString()) / 100 * 0.1);
                                    dr["TienNuocKDDV"] = (int)(int.Parse(gn.Rows[0]["KDDV"].ToString()) + int.Parse(gn.Rows[0]["KDDV"].ToString()) * 0.05 + int.Parse(gn.Rows[0]["KDDV"].ToString()) * int.Parse(gn.Rows[0]["PhiBVMT"].ToString()) / 100 + int.Parse(gn.Rows[0]["KDDV"].ToString()) * int.Parse(gn.Rows[0]["PhiBVMT"].ToString()) / 100 * 0.1);
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
                                dr["ChucVu"] = CNguoiDung.ChucVu.Replace(" PHÒNG", "");
                                dr["NguoiKy"] = CNguoiDung.NguoiKy;
                                dr["TenPhong"] = "";
                                dsBaoCaoCC.Tables["DCBD"].Rows.Add(dr);

                                DataRow drLogo = dsBaoCaoCC.Tables["BienNhanDonKH"].NewRow();
                                drLogo["PathLogo"] = Application.StartupPath.ToString() + @"\Resources\logocongty.png";
                                dsBaoCaoCC.Tables["BienNhanDonKH"].Rows.Add(drLogo);
                            }
                            else
                            {
                                DataRow dr = dsBaoCao.Tables["DCBD"].NewRow();

                                dr["KyHieuPhong"] = "QLĐHN";
                                dr["SoPhieu"] = en.ID.ToString();
                                dr["HieuLucKy"] = en.HieuLucKy;
                                dr["DanhBo"] = en.DanhBo.Insert(7, " ").Insert(4, " ");
                                dr["HopDong"] = en.HopDong;
                                dr["HoTen"] = en.HoTen;
                                dr["DiaChi"] = en.DiaChi;
                                dr["ThongTin"] = en.CongDung;
                                string[] HieuLucKys = en.HieuLucKy.Split('/');
                                DataTable gn = _cThuongVu.getGiaNuoc(HieuLucKys[1]);
                                if (gn != null)
                                {
                                    dr["TienNuocSH"] = (int)(int.Parse(gn.Rows[0]["SHTM"].ToString()) + int.Parse(gn.Rows[0]["SHTM"].ToString()) * 0.05 + int.Parse(gn.Rows[0]["SHTM"].ToString()) * int.Parse(gn.Rows[0]["PhiBVMT"].ToString()) / 100 + int.Parse(gn.Rows[0]["SHTM"].ToString()) * int.Parse(gn.Rows[0]["PhiBVMT"].ToString()) / 100 * 0.1);
                                    dr["TienNuocSHVuot1"] = (int)(int.Parse(gn.Rows[0]["SHVM1"].ToString()) + int.Parse(gn.Rows[0]["SHVM1"].ToString()) * 0.05 + int.Parse(gn.Rows[0]["SHVM1"].ToString()) * int.Parse(gn.Rows[0]["PhiBVMT"].ToString()) / 100 + int.Parse(gn.Rows[0]["SHVM1"].ToString()) * int.Parse(gn.Rows[0]["PhiBVMT"].ToString()) / 100 * 0.1);
                                    dr["TienNuocSHVuot2"] = (int)(int.Parse(gn.Rows[0]["SHVM2"].ToString()) + int.Parse(gn.Rows[0]["SHVM2"].ToString()) * 0.05 + int.Parse(gn.Rows[0]["SHVM2"].ToString()) * int.Parse(gn.Rows[0]["PhiBVMT"].ToString()) / 100 + int.Parse(gn.Rows[0]["SHVM2"].ToString()) * int.Parse(gn.Rows[0]["PhiBVMT"].ToString()) / 100 * 0.1);
                                    dr["TienNuocKDDV"] = (int)(int.Parse(gn.Rows[0]["KDDV"].ToString()) + int.Parse(gn.Rows[0]["KDDV"].ToString()) * 0.05 + int.Parse(gn.Rows[0]["KDDV"].ToString()) * int.Parse(gn.Rows[0]["PhiBVMT"].ToString()) / 100 + int.Parse(gn.Rows[0]["KDDV"].ToString()) * int.Parse(gn.Rows[0]["PhiBVMT"].ToString()) / 100 * 0.1);
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

                                dr["ChucVu"] = CNguoiDung.ChucVu.Replace(" PHÒNG", "");
                                dr["NguoiKy"] = CNguoiDung.NguoiKy;
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




    }
}
