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

namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    public partial class frmDanhSachDocLoChiSoNuoc : Form
    {
        string _mnu = "mnuDanhSachDocLoChiSoNuoc";
        CDocSo _cDocSo = new CDocSo();
        CDCBD _cDCBD = new CDCBD();
        dbKinhDoanhDataContext _dbThuongVu = new dbKinhDoanhDataContext();

        public frmDanhSachDocLoChiSoNuoc()
        {
            InitializeComponent();
        }

        private void frmDanhSachDocLoChiSoNuoc_Load(object sender, EventArgs e)
        {
            gridControl.LevelTree.Nodes.Add("Chi Tiết", gridViewChiTiet);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            gridControl.DataSource = _cDocSo.getDS_DocLoChiSoNuoc(int.Parse(txtNam.Text.Trim()), int.Parse(txtKy.Text.Trim()), int.Parse(txtDot.Text.Trim())).Tables["Parent"];

            for (int i = 0; i < gridView.DataRowCount; i++)
            {
                DataRow row = gridView.GetDataRow(i);
                DataRow[] childRows = row.GetChildRows("Chi Tiết");
                int GiaiTrach = 0;

                //tính chỉ số lố
                foreach (DataRow itemChild in childRows)
                {
                    if (itemChild["CodeMoi"].ToString().Contains("4") == true || itemChild["CodeMoi"].ToString().Contains("5") == true || itemChild["CodeMoi"].ToString().Contains("8") == true || itemChild["CodeMoi"].ToString().Contains("M") == true)
                    {
                        row["TieuThuLo"] = int.Parse(row["CSM"].ToString()) - (int.Parse(row["TieuThuLo"].ToString()) + int.Parse(itemChild["CSM"].ToString()));
                        break;
                    }
                    else
                    {
                        row["TieuThuLo"] = int.Parse(row["TieuThuLo"].ToString()) + int.Parse(itemChild["TieuThu"].ToString());
                    }
                }
                int TieuThuLo = int.Parse(row["TieuThuLo"].ToString()) * -1;
                foreach (DataRow itemChild in childRows)
                {
                    //xét hđ tồn
                    if (itemChild["NgayGiaiTrach"].ToString() != "")
                        GiaiTrach++;

                    //tính khấu trừ
                    if (itemChild["NgayGiaiTrach"].ToString() == "" && itemChild["CodeMoi"].ToString().Contains("4") == false && itemChild["CodeMoi"].ToString().Contains("5") == false && itemChild["CodeMoi"].ToString().Contains("8") == false && itemChild["CodeMoi"].ToString().Contains("M") == false)
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
                row["TieuThuLoConLai"] = TieuThuLo * -1;
                if (childRows.Count() != GiaiTrach)
                    row["TinhTrang"] = "Tồn";
                //gridView.SetRowCellValue(i, "TinhTrang", "Tồn");
                else
                    row["TinhTrang"] = "Đã Đăng Ngân";
                //gridView.SetRowCellValue(i, "TinhTrang", "Đã Đăng Ngân");
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
                    if (row["TinhTrang"].ToString() == "Tồn")
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
                                    if (itemChild["TieuThuDC"] != null && itemChild["TieuThuDC"].ToString() != "")
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
                                        enCT.TieuThuDC = int.Parse(itemChild["TieuThuDC"].ToString());
                                        en.ChiSoLo_HoaDons.Add(enCT);
                                    }
                                _dbThuongVu.ChiSoLo_DanhBos.InsertOnSubmit(en);
                                _dbThuongVu.SubmitChanges();
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

            string sql = "(select Chon=CAST(0 as bit),ID,DanhBo,MLT,HoTen,DiaChi,Nam,Ky,Dot,CodeCu,CodeMoi,CSC,CSM,TieuThu,TieuThuLo,TieuThuLoConLai,TinhTrang=''"
                        + " from ChiSoLo_DanhBo where Nam=" + txtNam.Text.Trim() + " and Ky=" + txtKy.Text.Trim() + " and Dot=" + txtDot.Text.Trim() + ")order by DanhBo asc";
            DataTable dtParent = _cDCBD.ExecuteQuery_DataTable(sql);
            dtParent.TableName = "Parent";
            ds.Tables.Add(dtParent);

            sql = "select hd.* "
                    + " from ChiSoLo_DanhBo db,ChiSoLo_HoaDon hd where db.Nam=" + txtNam.Text.Trim() + " and db.Ky=" + txtKy.Text.Trim() + " and db.Dot=" + txtDot.Text.Trim() + ""
                    + " and db.ID=hd.ID order by MaHD desc";
            DataTable dtChild = _cDCBD.ExecuteQuery_DataTable(sql);
            dtChild.TableName = "Child";
            ds.Tables.Add(dtChild);

            if (dtParent.Rows.Count > 0 && dtChild.Rows.Count > 0)
                ds.Relations.Add("Chi Tiết", ds.Tables["Parent"].Columns["ID"], ds.Tables["Child"].Columns["ID"]);

            gridControl.DataSource = ds.Tables["Parent"];
        }
        CThuTien _cThuTien = new CThuTien();
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
                HOADON hd = _cThuTien.Get(row["DanhBo"].ToString(), int.Parse(row["Ky"].ToString())-1, int.Parse(row["Nam"].ToString()));
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
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
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
        CToTrinh _cTT = new CToTrinh();
        private void btnTVXem_Click(object sender, EventArgs e)
        {
            btnQLDHNXemChot.PerformClick();
            for (int i = 0; i < gridView.DataRowCount; i++)
            {
                DataRow row = gridView.GetDataRow(i);
                if (_cTT.checkExist_ChiTiet_DieuChinhHoaDon_Tu072021(row["DanhBo"].ToString()) == true)
                    row["TinhTrang"] = "Có Tờ Trình Điều Chỉnh Hóa Đơn";
            }
        }

        private void btnTVDieuChinh_Click(object sender, EventArgs e)
        {

        }


    }
}
