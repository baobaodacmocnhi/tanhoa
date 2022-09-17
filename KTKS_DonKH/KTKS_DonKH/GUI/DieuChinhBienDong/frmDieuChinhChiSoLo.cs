using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL.DieuChinhBienDong;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.DieuChinhBienDong;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.ThuTraLoi;
using KTKS_DonKH.DAL.DonTu;

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmDieuChinhChiSoLo : Form
    {
        string _mnu = "mnuDieuChinhChiSoLo";
        CDocSo _cDocSo = new CDocSo();
        CDCBD _cDCBD = new CDCBD();
        CThuTien _cThuTien = new CThuTien();
        CToTrinh _cTT = new CToTrinh();
        CDonTu _cDonTu = new CDonTu();
        CGiaNuoc _cGiaNuoc = new CGiaNuoc();
        CBanGiamDoc _cBanGiamDoc = new CBanGiamDoc();
        dbKinhDoanhDataContext _dbThuongVu = new dbKinhDoanhDataContext();

        public frmDieuChinhChiSoLo()
        {
            InitializeComponent();
        }

        private void frmDanhSachDocLoChiSoNuoc_Load(object sender, EventArgs e)
        {
            gridControl.LevelTree.Nodes.Add("Chi Tiết", gridViewChiTiet);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            string sql = "(select Chon=CAST(0 as bit),ID,DanhBo,MLT,HoTen,DiaChi,Nam,Ky,Dot,CodeCu,CodeMoi,CSC,CSM,TieuThu,TieuThuLo,TieuThuLoConLai,TinhTrang='',MaDon,STT,DCHD,UpdatedDHN"
                        + " from ChiSoLo_DanhBo where Nam=" + txtNam.Text.Trim() + " and Ky=" + txtKy.Text.Trim() + " and Dot=" + txtDot.Text.Trim() + ")order by MLT asc";
            DataTable dtParent = _cDCBD.ExecuteQuery_DataTable(sql);
            dtParent.TableName = "Parent";
            ds.Tables.Add(dtParent);

            sql = "select b.*,TinhTrang=case when MaNV_DangNgan is not null then N'Đã Đăng Ngân' else '' end "
                    + " from ChiSoLo_DanhBo a,ChiSoLo_HoaDon b,HOADON_TA.dbo.HOADON hd where a.Nam=" + txtNam.Text.Trim() + " and a.Ky=" + txtKy.Text.Trim() + " and a.Dot=" + txtDot.Text.Trim() + ""
                    + " and a.ID=b.ID and b.MaHD=hd.ID_HOADON order by MaHD desc";
            DataTable dtChild = _cDCBD.ExecuteQuery_DataTable(sql);
            dtChild.TableName = "Child";
            ds.Tables.Add(dtChild);

            if (dtParent.Rows.Count > 0 && dtChild.Rows.Count > 0)
                ds.Relations.Add("Chi Tiết", ds.Tables["Parent"].Columns["ID"], ds.Tables["Child"].Columns["ID"]);
            gridControl.DataSource = ds.Tables["Parent"];

            for (int i = 0; i < gridView.DataRowCount; i++)
            {
                DataRow row = gridView.GetDataRow(i);
                DataRow[] childRows = row.GetChildRows("Chi Tiết");
                int GiaiTrach = 0;
                bool flag = false;
                //tính chỉ số lố
                for (int j = 0; j < childRows.Count(); j++)
                {
                    if (childRows[j]["CodeMoi"].ToString().Contains("4") == true || childRows[j]["CodeMoi"].ToString().Contains("5") == true || childRows[j]["CodeMoi"].ToString().Contains("8") == true || childRows[j]["CodeMoi"].ToString().Contains("M") == true)
                    {
                        row["TieuThuLo"] = int.Parse(row["CSM"].ToString()) - (int.Parse(row["TieuThuLo"].ToString()) + int.Parse(childRows[j]["CSM"].ToString()));
                        if (j < childRows.Count() - 1)
                            if (childRows[j + 1]["CodeMoi"].ToString().Contains("4") == false && childRows[j + 1]["CodeMoi"].ToString().Contains("5") == false && childRows[j + 1]["CodeMoi"].ToString().Contains("8") == false && childRows[j + 1]["CodeMoi"].ToString().Contains("M") == false)
                                flag = true;
                        break;
                    }
                    else
                    {
                        row["TieuThuLo"] = int.Parse(row["TieuThuLo"].ToString()) + int.Parse(childRows[j]["TieuThu"].ToString());
                    }
                }
                int TieuThuLo = int.Parse(row["TieuThuLo"].ToString()) * -1;
                foreach (DataRow itemChild in childRows)
                {
                    //xét hđ tồn
                    if (itemChild["TinhTrang"].ToString() != "")
                        GiaiTrach++;

                    //tính khấu trừ
                    //if (itemChild["TinhTrang"].ToString() == "" && itemChild["CodeMoi"].ToString().Contains("4") == false && itemChild["CodeMoi"].ToString().Contains("5") == false && itemChild["CodeMoi"].ToString().Contains("8") == false && itemChild["CodeMoi"].ToString().Contains("M") == false)
                    //{
                    //    if (TieuThuLo > 0)
                    //    {
                    //        if (TieuThuLo >= int.Parse(itemChild["TieuThu"].ToString()))
                    //        {
                    //            itemChild["TieuThuDC"] = 0;
                    //            TieuThuLo -= int.Parse(itemChild["TieuThu"].ToString());
                    //        }
                    //        else
                    //            if (TieuThuLo < int.Parse(itemChild["TieuThu"].ToString()))
                    //            {
                    //                itemChild["TieuThuDC"] = (int.Parse(itemChild["TieuThu"].ToString()) - TieuThuLo);
                    //                TieuThuLo = 0;
                    //            }
                    //    }
                    //}
                }
                row["TieuThuLoConLai"] = TieuThuLo * -1;

                if (childRows.Count() == GiaiTrach)
                    row["TinhTrang"] = "Đã Đăng Ngân";
                else
                    if (flag == true)
                        row["TinhTrang"] = "Sai Chỉ Số";
                    else
                        row["TinhTrang"] = "Tồn";
            }
        }

        private void gridView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void chkChonAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChonAll.Checked)
                for (int i = 0; i < gridView.RowCount; i++)
                {
                    DataRow row = gridView.GetDataRow(i);
                    if (row["ID"].ToString() == "")
                    {
                        if (row["TinhTrang"].ToString() == "Tồn")
                            row["Chon"] = "True";
                    }
                    else
                        if (row["TinhTrang"].ToString() == "")
                            row["Chon"] = "True";
                    //gridView.SetRowCellValue(i, gridView.Columns["Chon"], "True");
                }
            else
                for (int i = 0; i < gridView.RowCount; i++)
                {
                    DataRow row = gridView.GetDataRow(i);
                    row["Chon"] = "False";
                    //gridView.SetRowCellValue(i, gridView.Columns["Chon"], "False");
                }
        }

        private void btnQLDHNChot_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn Chốt?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (_dbThuongVu.ChiSoLo_DanhBos.Any(item => item.Nam == int.Parse(gridView.GetDataRow(0)["Nam"].ToString()) && item.Ky == int.Parse(gridView.GetDataRow(0)["Ky"].ToString()) && item.Dot == int.Parse(gridView.GetDataRow(0)["Dot"].ToString()) && item.MaDon != null) == true)
                        {
                            MessageBox.Show("P. Thương Vụ đã Lập Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        for (int i = 0; i < gridView.DataRowCount; i++)
                        {
                            DataRow row = gridView.GetDataRow(i);
                            if (row["Chon"] != null && bool.Parse(row["Chon"].ToString()) == true)
                            {
                                ChiSoLo_DanhBo en = new ChiSoLo_DanhBo();
                                en.DanhBo = row["DanhBo"].ToString();
                                en.MLT = row["MLT"].ToString();
                                en.HoTen = row["HoTen"].ToString();
                                en.DiaChi = row["DiaChi"].ToString();
                                en.Nam = int.Parse(row["Nam"].ToString());
                                en.Ky = int.Parse(row["Ky"].ToString());
                                en.Dot = int.Parse(row["Dot"].ToString());
                                en.CodeCu = row["CodeCu"].ToString();
                                en.CodeMoi = row["CodeMoi"].ToString();
                                en.CSC = row["CSC"].ToString();
                                en.CSM = row["CSM"].ToString();
                                en.TieuThu = int.Parse(row["TieuThu"].ToString());
                                en.TieuThuLo = int.Parse(row["TieuThuLo"].ToString());
                                en.TieuThuLoConLai = int.Parse(row["TieuThuLoConLai"].ToString());
                                en.CreateBy = CTaiKhoan.MaUser;
                                en.CreateDate = DateTime.Now;
                                if (_dbThuongVu.ChiSoLo_DanhBos.Any(item => item.DanhBo == row["DanhBo"].ToString() && item.Nam == int.Parse(row["Nam"].ToString()) && item.Ky == int.Parse(row["Ky"].ToString())) == false)
                                {
                                    DataRow[] childRows = row.GetChildRows("Chi Tiết");
                                    foreach (DataRow itemChild in childRows)
                                        if (itemChild["TinhTrang"].ToString() == "")
                                        {
                                            ChiSoLo_HoaDon enCT = new ChiSoLo_HoaDon();
                                            enCT.MaHD = int.Parse(itemChild["MaHD"].ToString());
                                            enCT.Nam = int.Parse(itemChild["Nam"].ToString());
                                            enCT.Ky = int.Parse(itemChild["Ky"].ToString());
                                            enCT.CodeCu = itemChild["CodeCu"].ToString();
                                            enCT.CodeMoi = itemChild["CodeMoi"].ToString();
                                            enCT.CSC = itemChild["CSC"].ToString();
                                            enCT.CSM = itemChild["CSM"].ToString();
                                            enCT.TieuThu = int.Parse(itemChild["TieuThu"].ToString());
                                            //enCT.TieuThuDC = int.Parse(itemChild["TieuThuDC"].ToString());
                                            en.ChiSoLo_HoaDons.Add(enCT);
                                        }
                                    _dbThuongVu.ChiSoLo_DanhBos.InsertOnSubmit(en);
                                    _dbThuongVu.SubmitChanges();
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

        private void btnQLDHNXemChot_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            string sql = "(select Chon=CAST(0 as bit),ID,DanhBo,MLT,HoTen,DiaChi,Nam,Ky,Dot,CodeCu,CodeMoi,CSC,CSM,TieuThu,TieuThuLo,TieuThuLoConLai,TinhTrang='',MaDon,STT,DCHD,UpdatedDHN"
                        + " from ChiSoLo_DanhBo where Nam=" + txtNam.Text.Trim() + " and Ky=" + txtKy.Text.Trim() + " and Dot=" + txtDot.Text.Trim() + ")order by MLT asc";
            DataTable dtParent = _cDCBD.ExecuteQuery_DataTable(sql);
            dtParent.TableName = "Parent";
            ds.Tables.Add(dtParent);

            sql = "select b.*,TinhTrang=case when MaNV_DangNgan is not null then N'Đã Đăng Ngân' else '' end "
                    + " from ChiSoLo_DanhBo a,ChiSoLo_HoaDon b,HOADON_TA.dbo.HOADON hd where a.Nam=" + txtNam.Text.Trim() + " and a.Ky=" + txtKy.Text.Trim() + " and a.Dot=" + txtDot.Text.Trim() + ""
                    + " and a.ID=b.ID and b.MaHD=hd.ID_HOADON order by MaHD desc";
            DataTable dtChild = _cDCBD.ExecuteQuery_DataTable(sql);
            dtChild.TableName = "Child";
            ds.Tables.Add(dtChild);

            if (dtParent.Rows.Count > 0 && dtChild.Rows.Count > 0)
                ds.Relations.Add("Chi Tiết", ds.Tables["Parent"].Columns["ID"], ds.Tables["Child"].Columns["ID"]);

            gridControl.DataSource = ds.Tables["Parent"];
        }

        private void btnQLDHNIn_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            for (int i = 0; i < gridView.DataRowCount; i++)
            {
                DataRow row = gridView.GetDataRow(i);
                DataRow dr = dsBaoCao.Tables["DCHD"].NewRow();
                dr["DanhBo"] = row["DanhBo"].ToString().Insert(7, " ").Insert(4, " "); ;
                dr["HoTen"] = row["HoTen"].ToString();
                dr["DiaChi"] = row["DiaChi"].ToString();
                dr["TieuThuStart"] = row["Dot"].ToString();
                dr["TienNuocStart"] = row["Ky"].ToString();
                HOADON hd = _cThuTien.Get(row["DanhBo"].ToString(), int.Parse(row["Ky"].ToString()) - 1, int.Parse(row["Nam"].ToString()));
                dr["ThueGTGTStart"] = hd.CODE;
                dr["PhiBVMTStart"] = row["CodeMoi"].ToString();
                dr["TongCongStart"] = "5" + hd.CODE;
                dr["ChiTietMoi"] = row["CSM"].ToString();
                dsBaoCao.Tables["DCHD"].Rows.Add(dr);
            }
            rptDS_ChiSoLo rpt = new rptDS_ChiSoLo();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.Show();
        }

        private void btnQLDHNXoaChot_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn Xóa?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (_dbThuongVu.ChiSoLo_DanhBos.Any(item => item.Nam == int.Parse(gridView.GetDataRow(0)["Nam"].ToString()) && item.Ky == int.Parse(gridView.GetDataRow(0)["Ky"].ToString()) && item.Dot == int.Parse(gridView.GetDataRow(0)["Dot"].ToString()) && item.MaDon != null) == true)
                        {
                            MessageBox.Show("P. Thương Vụ đã Lập Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        for (int i = 0; i < gridView.DataRowCount; i++)
                        {
                            DataRow row = gridView.GetDataRow(i);
                            {
                                string sql = "delete ChiSoLo_HoaDon where ID=" + row["ID"].ToString()
                                    + " delete ChiSoLo_DanhBo where ID=" + row["ID"].ToString();
                                _cDCBD.ExecuteNonQuery(sql);
                            }
                        }
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnTVXem_Click(object sender, EventArgs e)
        {
            btnQLDHNXemChot.PerformClick();
            if (_dbThuongVu.ChiSoLo_DanhBos.Any(item => item.Nam == int.Parse(gridView.GetDataRow(0)["Nam"].ToString()) && item.Ky == int.Parse(gridView.GetDataRow(0)["Ky"].ToString()) && item.Dot == int.Parse(gridView.GetDataRow(0)["Dot"].ToString()) && item.DCHD == true) == true)
            {

            }
            else
            {
                int GiaiTrach = 0;
                for (int i = 0; i < gridView.DataRowCount; i++)
                {
                    DataRow row = gridView.GetDataRow(i);
                    //kiểm tra có lập tờ trình
                    string str = "";
                    bool flag = false;
                    if (_cTT.checkExist_ChiTiet_DieuChinhHoaDon_Tu072021(row["DanhBo"].ToString(), out str) == true)
                        row["TinhTrang"] = str;
                    else
                    {
                        DataRow[] childRows = row.GetChildRows("Chi Tiết");
                        int TieuThuLo = int.Parse(row["TieuThuLo"].ToString()) * -1;
                        GiaiTrach = 0;
                        foreach (DataRow itemChild in childRows)
                        {
                            if (itemChild["TinhTrang"].ToString() != "")
                                GiaiTrach++;
                            //kiểm tra có lập điều chỉnh hóa đơn
                            if (_cDCBD.checkExist_HoaDon(row["DanhBo"].ToString(), int.Parse(itemChild["Nam"].ToString()), int.Parse(itemChild["Ky"].ToString())))
                            {
                                itemChild["TinhTrang"] = "Có Điều Chỉnh Hóa Đơn";
                                flag = true;
                            }
                            //tính khấu trừ
                            if (itemChild["TinhTrang"].ToString() == "" && itemChild["CodeMoi"].ToString().Contains("4") == false && itemChild["CodeMoi"].ToString().Contains("5") == false && itemChild["CodeMoi"].ToString().Contains("8") == false && itemChild["CodeMoi"].ToString().Contains("M") == false)
                            {
                                if (TieuThuLo > 0)
                                {
                                    if (TieuThuLo >= int.Parse(itemChild["TieuThu"].ToString()))
                                    {
                                        itemChild["TieuThuDC"] = 0;
                                        TieuThuLo -= int.Parse(itemChild["TieuThu"].ToString());
                                    }
                                    else
                                        if (TieuThuLo < int.Parse(itemChild["TieuThu"].ToString()))
                                        {
                                            itemChild["TieuThuDC"] = (int.Parse(itemChild["TieuThu"].ToString()) - TieuThuLo);
                                            TieuThuLo = 0;
                                        }
                                }
                            }
                        }
                        if (flag == true)
                            row["TinhTrang"] = "Có Điều Chỉnh Hóa Đơn";
                        if (childRows.Count() == GiaiTrach)
                            row["TinhTrang"] = "Đã Đăng Ngân";
                        row["TieuThuLoConLai"] = TieuThuLo * -1;
                    }
                }
            }

        }

        private void btnTVLapDon_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen("mnuDCHD", "Them"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (_dbThuongVu.ChiSoLo_DanhBos.Any(item => item.Nam == int.Parse(gridView.GetDataRow(0)["Nam"].ToString()) && item.Ky == int.Parse(gridView.GetDataRow(0)["Ky"].ToString()) && item.Dot == int.Parse(gridView.GetDataRow(0)["Dot"].ToString()) && item.MaDon != null) == true)
                        {
                            MessageBox.Show("Đã có Mã Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        LinQ.DonTu entity = new LinQ.DonTu();

                        int ID = _cDonTu.getMaxID_ChiTiet();
                        int STT = 0;
                        for (int i = 0; i < gridView.DataRowCount; i++)
                        {
                            DataRow row = gridView.GetDataRow(i);
                            if (row["Chon"] != null && bool.Parse(row["Chon"].ToString()) == true)
                            {
                                HOADON hd = _cThuTien.GetMoiNhat(row["DanhBo"].ToString());

                                DonTu_ChiTiet entityCT = new DonTu_ChiTiet();
                                entityCT.ID = ++ID;
                                entityCT.STT = ++STT;

                                entityCT.DanhBo = row["DanhBo"].ToString();
                                entityCT.MLT = hd.MALOTRINH;
                                entityCT.HopDong = hd.HOPDONG;
                                entityCT.HoTen = row["HoTen"].ToString();
                                entityCT.DiaChi = row["DiaChi"].ToString();
                                entityCT.GiaBieu = hd.GB;
                                entityCT.DinhMuc = hd.DM;
                                entityCT.DinhMucHN = hd.DinhMucHN;
                                entityCT.Dot = int.Parse(row["Dot"].ToString());
                                entityCT.Ky = int.Parse(row["Ky"].ToString());
                                entityCT.Nam = int.Parse(row["Nam"].ToString());
                                entityCT.Quan = hd.Quan;
                                entityCT.Phuong = hd.Phuong;

                                entityCT.CreateBy = CTaiKhoan.MaUser;
                                entityCT.CreateDate = DateTime.Now;
                                //entityCT.TinhTrang = "Tồn";

                                entity.DonTu_ChiTiets.Add(entityCT);
                            }
                        }
                        entity.SoCongVan_PhongBanDoi = "Đ. QLĐHN";
                        entity.TongDB = entity.DonTu_ChiTiets.Count;
                        entity.ID_NhomDon_PKH = "7";
                        entity.Name_NhomDon_PKH = "Chỉ số nước";
                        entity.VanPhong = true;
                        entity.MaPhong = 1;
                        if (_cDonTu.Them(entity))
                        {
                            foreach (DonTu_ChiTiet itemDonChiTiet in entity.DonTu_ChiTiets)
                            {
                                _cDCBD.ExecuteNonQuery("update ChiSoLo_DanhBo set MaDon=" + itemDonChiTiet.MaDon + ",STT=" + itemDonChiTiet.STT + " where DanhBo='" + itemDonChiTiet.DanhBo + "' and Nam=" + itemDonChiTiet.Nam + " and Ky=" + itemDonChiTiet.Ky + " and Dot=" + itemDonChiTiet.Dot);
                            }
                            MessageBox.Show("Thành công\nMã Đơn: " + entity.MaDon.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            gridControl.DataSource = null;
                        }
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTVDieuChinh_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen("mnuDCHD", "Them"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (_dbThuongVu.ChiSoLo_DanhBos.Count(item => item.Nam == int.Parse(gridView.GetDataRow(0)["Nam"].ToString()) && item.Ky == int.Parse(gridView.GetDataRow(0)["Ky"].ToString()) && item.Dot == int.Parse(gridView.GetDataRow(0)["Dot"].ToString()) && item.MaDon == null) == gridView.DataRowCount)
                        {
                            MessageBox.Show("Chưa có Mã Đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (_dbThuongVu.ChiSoLo_DanhBos.Any(item => item.Nam == int.Parse(gridView.GetDataRow(0)["Nam"].ToString()) && item.Ky == int.Parse(gridView.GetDataRow(0)["Ky"].ToString()) && item.Dot == int.Parse(gridView.GetDataRow(0)["Dot"].ToString()) && item.DCHD == true) == true)
                        {
                            MessageBox.Show("Đã Điều Chỉnh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        for (int i = 0; i < gridView.DataRowCount; i++)
                        {
                            DataRow row = gridView.GetDataRow(i);
                            if (row["MaDon"].ToString() != "")
                            {
                                DonTu_ChiTiet dontu_ChiTiet = _cDonTu.get_ChiTiet(int.Parse(row["MaDon"].ToString()), int.Parse(row["STT"].ToString()));

                                if (_cDCBD.checkExist(dontu_ChiTiet.MaDon.Value) == false)
                                {
                                    DCBD dcbd = new DCBD();
                                    dcbd.MaDonMoi = dontu_ChiTiet.MaDon.Value;
                                    _cDCBD.Them(dcbd);
                                }
                                DataRow[] childRows = row.GetChildRows("Chi Tiết");
                                foreach (DataRow itemChild in childRows)
                                    if (itemChild["TinhTrang"].ToString() == "" && itemChild["TieuThuDC"].ToString() != "")
                                    {
                                        if (_cDCBD.checkExist_HoaDon(dontu_ChiTiet.MaDon.Value, dontu_ChiTiet.DanhBo, int.Parse(itemChild["Ky"].ToString()).ToString("00") + "/" + int.Parse(itemChild["Nam"].ToString())) == false)
                                        {
                                            DCBD_ChiTietHoaDon ctdchd = new DCBD_ChiTietHoaDon();
                                            ctdchd.MaDCBD = _cDCBD.get(dontu_ChiTiet.MaDon.Value).MaDCBD;
                                            ctdchd.STT = dontu_ChiTiet.STT.Value;

                                            ctdchd.DanhBo = dontu_ChiTiet.DanhBo;
                                            ctdchd.MLT = dontu_ChiTiet.MLT;
                                            ctdchd.HoTen = dontu_ChiTiet.HoTen;
                                            ctdchd.DiaChi = dontu_ChiTiet.DiaChi;

                                            ctdchd.NgayKy = DateTime.Now;

                                            ctdchd.KyHD = int.Parse(itemChild["Ky"].ToString()).ToString("00") + "/" + int.Parse(itemChild["Nam"].ToString());
                                            HOADON hd = _cThuTien.Get(dontu_ChiTiet.DanhBo, int.Parse(itemChild["Ky"].ToString()), int.Parse(itemChild["Nam"].ToString()));
                                            DocSo ds = _cDocSo.get(dontu_ChiTiet.DanhBo, int.Parse(itemChild["Ky"].ToString()), int.Parse(itemChild["Nam"].ToString()));
                                            if (hd != null)
                                                ctdchd.Dot = hd.DOT;
                                            else
                                                if (ds != null)
                                                    ctdchd.Dot = int.Parse(ds.Dot);
                                            ctdchd.Ky = int.Parse(itemChild["Ky"].ToString());
                                            ctdchd.Nam = int.Parse(itemChild["Nam"].ToString());
                                            if (hd != null)
                                            {
                                                ctdchd.MST = hd.MST;
                                                ctdchd.SoHoaDon = hd.SOHOADON;
                                                ctdchd.Phuong = hd.Phuong;
                                                ctdchd.Quan = hd.Quan;
                                            }
                                            ctdchd.SoHD = hd.SOPHATHANH.ToString();
                                            ///
                                            ctdchd.GiaBieu = hd.GB;
                                            if (hd.DinhMucHN == null)
                                                ctdchd.DinhMucHN = 0;
                                            else
                                                ctdchd.DinhMucHN = hd.DinhMucHN;
                                            ctdchd.DinhMuc = hd.DM;
                                            ctdchd.TieuThu = hd.TIEUTHU;
                                            ///
                                            ctdchd.GiaBieu_BD = hd.GB;
                                            if (hd.DinhMucHN == null)
                                                ctdchd.DinhMucHN_BD = 0;
                                            else
                                                ctdchd.DinhMucHN_BD = hd.DinhMucHN;
                                            ctdchd.DinhMuc_BD = hd.DM;
                                            ctdchd.TieuThu_BD = int.Parse(itemChild["TieuThuDC"].ToString());
                                            ///
                                            if ((hd.NAM < 2021) || (hd.NAM == 2021 && hd.KY <= 6))
                                                ctdchd.BaoCaoThue = true;
                                            ///
                                            string ChiTietNamCuTruoc = "", ChiTietNamMoiTruoc = "", ChiTietNamCuSau = "", ChiTietNamMoiSau = "", ChiTietPhiBVMTNamCuTruoc = "", ChiTietPhiBVMTNamMoiTruoc = "", ChiTietPhiBVMTNamCuSau = "", ChiTietPhiBVMTNamMoiSau = "";
                                            int Ky = 0, Nam = 0, TyleSH = 0, TyLeSX = 0, TyLeDV = 0, TyLeHCSN = 0, TienNuocNamCuTruoc = 0, TienNuocNamMoiTruoc = 0, TienNuocNamCuSau = 0, TienNuocNamMoiSau = 0, TieuThu_DieuChinhGia = 0
                                                , PhiBVMTNamCuTruoc = 0, PhiBVMTNamMoiTruoc = 0, PhiBVMTNamCuSau = 0, PhiBVMTNamMoiSau = 0
                                                , TienNuocTruoc = 0, ThueGTGTTruoc = 0, TDVTNTruoc = 0, ThueTDVTNTruoc = 0, TienNuocSau = 0, ThueGTGTSau = 0, TDVTNSau = 0, ThueTDVTNSau = 0, ThueTDVTN_VAT = 0;
                                            DateTime TuNgay = new DateTime(), DenNgay = new DateTime();

                                            if (hd != null)
                                            {
                                                Ky = hd.KY;
                                                Nam = hd.NAM;
                                                if (hd.TUNGAY != null)
                                                    TuNgay = hd.TUNGAY.Value;
                                                else
                                                {
                                                    TuNgay = ds.TuNgay.Value;
                                                }
                                                DenNgay = hd.DENNGAY.Value;
                                                if (hd.TILESH != null && hd.TILESH.Value != 0)
                                                    TyleSH = hd.TILESH.Value;
                                                if (hd.TILESX != null && hd.TILESX.Value != 0)
                                                    TyLeSX = hd.TILESX.Value;
                                                if (hd.TILEDV != null && hd.TILEDV.Value != 0)
                                                    TyLeDV = hd.TILEDV.Value;
                                                if (hd.TILEHCSN != null && hd.TILEHCSN.Value != 0)
                                                    TyLeHCSN = hd.TILEHCSN.Value;
                                            }
                                            else
                                                if (ds != null)
                                                {
                                                    Ky = int.Parse(ds.Ky);
                                                    Nam = ds.Nam.Value;
                                                    TuNgay = ds.TuNgay.Value;
                                                    DenNgay = ds.DenNgay.Value;
                                                    HOADON hoadon = new HOADON();
                                                    if (int.Parse(ds.Ky) == 1)
                                                        hoadon = _cThuTien.Get(ds.DanhBa, 12, ds.Nam.Value - 1);
                                                    else
                                                        hoadon = _cThuTien.Get(ds.DanhBa, int.Parse(ds.Ky) - 1, ds.Nam.Value);
                                                    if (hoadon.TILESH != null && hoadon.TILESH.Value != 0)
                                                        TyleSH = hoadon.TILESH.Value;
                                                    if (hoadon.TILESX != null && hoadon.TILESX.Value != 0)
                                                        TyLeSX = hoadon.TILESX.Value;
                                                    if (hoadon.TILEDV != null && hoadon.TILEDV.Value != 0)
                                                        TyLeDV = hoadon.TILEDV.Value;
                                                    if (hoadon.TILEHCSN != null && hoadon.TILEHCSN.Value != 0)
                                                        TyLeHCSN = hoadon.TILEHCSN.Value;
                                                }

                                            _cGiaNuoc.TinhTienNuoc(false, false, false, 0, hd.DANHBA, Ky, Nam, TuNgay, DenNgay, ctdchd.GiaBieu.Value, TyleSH, TyLeSX, TyLeDV, TyLeHCSN, ctdchd.DinhMuc.Value, ctdchd.DinhMucHN.Value, ctdchd.TieuThu.Value, out TienNuocNamCuTruoc, out ChiTietNamCuTruoc, out TienNuocNamMoiTruoc, out ChiTietNamMoiTruoc, out TieuThu_DieuChinhGia, out PhiBVMTNamCuTruoc, out ChiTietPhiBVMTNamCuTruoc, out PhiBVMTNamMoiTruoc, out ChiTietPhiBVMTNamMoiTruoc, out TienNuocTruoc, out ThueGTGTTruoc, out TDVTNTruoc, out ThueTDVTNTruoc, out ThueTDVTN_VAT);

                                            _cGiaNuoc.TinhTienNuoc(false, false, false, 0, hd.DANHBA, Ky, Nam, TuNgay, DenNgay, ctdchd.GiaBieu_BD.Value, TyleSH, TyLeSX, TyLeDV, TyLeHCSN, ctdchd.DinhMuc_BD.Value, ctdchd.DinhMucHN_BD.Value, ctdchd.TieuThu_BD.Value, out TienNuocNamCuSau, out ChiTietNamCuSau, out TienNuocNamMoiSau, out ChiTietNamMoiSau, out TieuThu_DieuChinhGia, out PhiBVMTNamCuSau, out ChiTietPhiBVMTNamCuSau, out PhiBVMTNamMoiSau, out ChiTietPhiBVMTNamMoiSau, out TienNuocSau, out ThueGTGTSau, out TDVTNSau, out ThueTDVTNSau, out ThueTDVTN_VAT);

                                            ctdchd.ChiTietCu = ChiTietNamCuTruoc + "\r\n" + ChiTietNamMoiTruoc;
                                            ctdchd.ChiTietMoi = ChiTietNamCuSau + "\r\n" + ChiTietNamMoiSau;
                                            ctdchd.HoTen_BD = "";
                                            ctdchd.DiaChi_BD = "";
                                            ctdchd.MST_BD = "";

                                            ///Tiền Nước
                                            if (hd.GIABAN.Value != 0)
                                                ctdchd.TienNuoc_Start = (int)hd.GIABAN.Value;
                                            else
                                                ctdchd.TienNuoc_Start = 0;

                                            if (TienNuocSau - (int)hd.GIABAN.Value != 0)
                                                ctdchd.TienNuoc_BD = TienNuocSau - (int)hd.GIABAN.Value;
                                            else
                                                ctdchd.TienNuoc_BD = 0;

                                            if (TienNuocSau != 0)
                                                ctdchd.TienNuoc_End = TienNuocSau;
                                            else
                                                ctdchd.TienNuoc_End = 0;

                                            ///Thuế GTGT
                                            if ((int)hd.GIABAN.Value != 0)
                                                ctdchd.ThueGTGT_Start = (int)hd.THUE.Value;
                                            else
                                                ctdchd.ThueGTGT_Start = 0;

                                            if (TienNuocSau - (int)hd.GIABAN.Value != 0)
                                                ctdchd.ThueGTGT_BD = (ThueGTGTSau - (int)hd.THUE.Value);
                                            else
                                                ctdchd.ThueGTGT_BD = 0;

                                            if (TienNuocSau != 0)
                                                ctdchd.ThueGTGT_End = (int)ThueGTGTSau;
                                            else
                                                ctdchd.ThueGTGT_End = 0;

                                            ///Phí BVMT
                                            if ((int)hd.GIABAN.Value != 0)
                                                ctdchd.PhiBVMT_Start = (int)hd.PHI.Value;
                                            else
                                                ctdchd.PhiBVMT_Start = 0;

                                            if (TienNuocSau - (int)hd.GIABAN.Value != 0)
                                                //ctdchd.PhiBVMT_BD = (int)(Math.Round((double)TienNuocSau * 10 / 100, 0, MidpointRounding.AwayFromZero) - (int)hd.PHI.Value);
                                                ctdchd.PhiBVMT_BD = TDVTNSau - (int)hd.PHI.Value;
                                            else
                                                ctdchd.PhiBVMT_BD = 0;

                                            if (TienNuocSau != 0)
                                                //ctdchd.PhiBVMT_End = (int)Math.Round((double)TienNuocSau * 10 / 100, 0, MidpointRounding.AwayFromZero);
                                                ctdchd.PhiBVMT_End = TDVTNSau;
                                            else
                                                ctdchd.PhiBVMT_End = 0;

                                            ///Tổng Cộng
                                            if ((int)hd.GIABAN.Value != 0)
                                                ctdchd.TongCong_Start = (int)hd.TONGCONG.Value;
                                            else
                                                ctdchd.TongCong_Start = 0;

                                            if (TienNuocSau - (int)hd.GIABAN.Value != 0)
                                                //ctdchd.TongCong_BD = ((TienNuocSau + (int)Math.Round((double)TienNuocSau * 5 / 100, 0, MidpointRounding.AwayFromZero) + (int)Math.Round((double)TienNuocSau * 10 / 100, 0, MidpointRounding.AwayFromZero)) - (int)hd.TONGCONG.Value);
                                                ctdchd.TongCong_BD = ((TienNuocSau + ThueGTGTSau + TDVTNSau) - (int)hd.TONGCONG.Value);
                                            else
                                                ctdchd.TongCong_BD = 0;

                                            if (TienNuocSau != 0)
                                                //ctdchd.TongCong_End = (TienNuocSau + (int)Math.Round((double)TienNuocSau * 5 / 100, 0, MidpointRounding.AwayFromZero) + (int)Math.Round((double)TienNuocSau * 10 / 100, 0, MidpointRounding.AwayFromZero));
                                                ctdchd.TongCong_End = (TienNuocSau + ThueGTGTSau + TDVTNSau);
                                            else
                                                ctdchd.TongCong_End = 0;

                                            ctdchd.ThongTin = "Tiêu Thụ";

                                            if (ctdchd.TienNuoc_End - ctdchd.TienNuoc_Start == 0)
                                                ctdchd.TangGiam = "";
                                            else
                                                if (ctdchd.TienNuoc_End - ctdchd.TienNuoc_Start > 0)
                                                    ctdchd.TangGiam = "Tăng";
                                                else
                                                    ctdchd.TangGiam = "Giảm";

                                            ///Ký Tên
                                            BanGiamDoc bangiamdoc = _cBanGiamDoc.getBGDNguoiKy();
                                            if (bangiamdoc.ChucVu.ToUpper() == "GIÁM ĐỐC")
                                                ctdchd.ChucVu = "GIÁM ĐỐC";
                                            else
                                                ctdchd.ChucVu = "KT. GIÁM ĐỐC\n" + bangiamdoc.ChucVu.ToUpper();
                                            ctdchd.NguoiKy = bangiamdoc.HoTen.ToUpper();
                                            ctdchd.PhieuDuocKy = true;
                                            _cDCBD.ThemDCHD(ctdchd);
                                        }
                                        _cDCBD.ExecuteNonQuery("update ChiSoLo_HoaDon set TieuThuDC=" + itemChild["TieuThuDC"] + " where MaHD=" + itemChild["MaHD"]);
                                    }
                                _cDCBD.ExecuteNonQuery("update ChiSoLo_DanhBo set DCHD=1 where DanhBo='" + row["DanhBo"] + "' and Nam=" + row["Nam"] + " and Ky=" + row["Ky"] + " and Dot=" + row["Dot"]);
                            }
                            _cDCBD.ExecuteNonQuery("update ChiSoLo_DanhBo set TieuThuLoConLai=" + row["TieuThuLoConLai"] + " where DanhBo='" + row["DanhBo"] + "' and Nam=" + row["Nam"] + " and Ky=" + row["Ky"] + " and Dot=" + row["Dot"]);
                        }
                        MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gridControl.DataSource = null;
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTVCapNhatQLDHN_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.Admin == true && CTaiKhoan.CheckQuyen("mnuDCHD", "Them"))
                {
                    if (MessageBox.Show("Bạn có chắc chắn?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {

                        for (int i = 0; i < gridView.DataRowCount; i++)
                        {
                            DataRow row = gridView.GetDataRow(i);
                            if (row["MaDon"].ToString() != "" && bool.Parse(row["UpdatedDHN"].ToString()) == false)
                            {
                                //string sql = " update DocSo set CodeMoi='55',CSMoi=" + (int.Parse(row["CSM"].ToString()) - int.Parse(row["TieuThuLoConLai"].ToString())) + " where DanhBa='" + row["DanhBo"] + "' and Nam=" + row["Nam"] + " and Ky=" + row["Ky"] + " and Dot=" + row["Dot"]
                                //    + " update DocSo set CodeCu='55',CSCu=" + (int.Parse(row["CSM"].ToString()) - int.Parse(row["TieuThuLoConLai"].ToString())) + " where DanhBa='" + row["DanhBo"] + "' and Nam=" + row["Nam"] + " and Ky=" + (int.Parse(row["Ky"].ToString()) + 1) + " and Dot=" + row["Dot"];
                                string sql = " update DocSo set CodeMoi='55',CSMoi=" + (int.Parse(row["CSM"].ToString()) - int.Parse(row["TieuThuLoConLai"].ToString())) + " where DocSoID=" + row["Nam"] + int.Parse(row["Ky"].ToString()).ToString("00") + row["DanhBo"]
                                    + " update DocSo set CodeCu='55',CSCu=" + (int.Parse(row["CSM"].ToString()) - int.Parse(row["TieuThuLoConLai"].ToString())) + " where DocSoID=" + row["Nam"] + (int.Parse(row["Ky"].ToString()) + 1).ToString("00") + row["DanhBo"];
                                if (_cDocSo.ExecuteNonQuery(sql))
                                {
                                    string sql2 = "update ChiSoLo_DanhBo set UpdatedDHN=1,UpdatedDHN_Ngay=getdate() where ID=" + row["ID"].ToString();
                                    _cDCBD.ExecuteNonQuery(sql2);
                                }
                            }
                        }
                        MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQLDHNExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select Chon=CAST(0 as bit),ID,DanhBo,MLT,HoTen,DiaChi,Nam,Ky,Dot,CodeCu,CodeMoi,CSC,CSM,TieuThu,TieuThuLo,TieuThuLoConLai,TinhTrang='',MaDon,STT,DCHD"
                   + " from ChiSoLo_DanhBo where Nam=" + txtNam.Text.Trim() + " and Ky=" + txtKy.Text.Trim() + " and Dot=" + txtDot.Text.Trim() + " and DCHD=1 order by MLT asc";
                DataTable dt = _cDCBD.ExecuteQuery_DataTable(sql);

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

                oSheet.Name = "Sheet1";
                // Tạo tiêu đề cột 
                Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A1", "A1");
                cl1.Value2 = "MLT";
                cl1.ColumnWidth = 12;

                Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B1", "B1");
                cl2.Value2 = "Danh Bộ";
                cl2.ColumnWidth = 12;

                Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C1", "C1");
                cl3.Value2 = "Khách Hàng";
                cl3.ColumnWidth = 20;

                Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D1", "D1");
                cl4.Value2 = "Địa Chỉ";
                cl4.ColumnWidth = 20;

                Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E1", "E1");
                cl5.Value2 = "Code Cũ";
                cl5.ColumnWidth = 10;

                Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F1", "F1");
                cl6.Value2 = "Code Mới";
                cl6.ColumnWidth = 10;

                Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G1", "G1");
                cl7.Value2 = "Code Điều Chỉnh";
                cl7.ColumnWidth = 10;

                Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H1", "H1");
                cl8.Value2 = "Chỉ Số";
                cl8.ColumnWidth = 10;

                Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I1", "I1");
                cl9.Value2 = "Tiêu Thụ Lố Tồn";
                cl9.ColumnWidth = 10;


                // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
                // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
                int numColumn = 9;
                object[,] arr = new object[dt.Rows.Count, numColumn];

                //Chuyển dữ liệu từ DataTable vào mảng đối tượng
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    {
                        arr[i, 0] = dr["MLT"].ToString();
                        arr[i, 1] = dr["DanhBo"].ToString();
                        arr[i, 2] = dr["HoTen"].ToString();
                        arr[i, 3] = dr["DiaChi"].ToString();
                        arr[i, 4] = dr["CodeCu"].ToString();
                        arr[i, 5] = dr["CodeMoi"].ToString();
                        if (int.Parse(dr["TieuThuLoConLai"].ToString()) == 0)
                            arr[i, 6] = "5" + dr["CodeCu"].ToString().Substring(0, 1);
                        else
                            arr[i, 6] = dr["CodeMoi"].ToString();
                        arr[i, 7] = dr["CSM"].ToString();
                        arr[i, 8] = dr["TieuThuLoConLai"].ToString();
                    }
                }

                //Thiết lập vùng điền dữ liệu
                int rowStart = 2;
                int columnStart = 1;

                int rowEnd = rowStart + dt.Rows.Count - 1;
                int columnEnd = numColumn;

                // Ô bắt đầu điền dữ liệu
                Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
                // Ô kết thúc điền dữ liệu
                Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
                // Lấy về vùng điền dữ liệu
                Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

                Microsoft.Office.Interop.Excel.Range c1a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 1];
                Microsoft.Office.Interop.Excel.Range c2a = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 1];
                Microsoft.Office.Interop.Excel.Range c3a = oSheet.get_Range(c1a, c2a);
                c3a.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                Microsoft.Office.Interop.Excel.Range c1b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 2];
                Microsoft.Office.Interop.Excel.Range c2b = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 2];
                Microsoft.Office.Interop.Excel.Range c3b = oSheet.get_Range(c1b, c2b);
                c3b.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                c3b.NumberFormat = "@";

                Microsoft.Office.Interop.Excel.Range c1c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 3];
                Microsoft.Office.Interop.Excel.Range c2c = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 3];
                Microsoft.Office.Interop.Excel.Range c3c = oSheet.get_Range(c1c, c2c);
                c3c.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                Microsoft.Office.Interop.Excel.Range c1d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, 4];
                Microsoft.Office.Interop.Excel.Range c2d = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, 4];
                Microsoft.Office.Interop.Excel.Range c3d = oSheet.get_Range(c1d, c2d);
                c3d.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                //Điền dữ liệu vào vùng đã thiết lập
                range.Value2 = arr;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
