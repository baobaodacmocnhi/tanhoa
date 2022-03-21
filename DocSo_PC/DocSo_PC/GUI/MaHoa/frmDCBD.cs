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

namespace DocSo_PC.GUI.MaHoa
{
    public partial class frmDCBD : Form
    {
        string _mnu = "mnuDCBD";
        CDonTu _cDonTu = new CDonTu();
        CDCBD _cDCBD = new CDCBD();
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
                                    MessageBox.Show("Danh Bộ này đã được Lập Điều Chỉnh Biến Động", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnIn_Click(object sender, EventArgs e)
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




    }
}
