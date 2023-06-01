using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.VanThu;
using DocSo_PC.DAL;
using DocSo_PC.LinQ;
using DocSo_PC.DAL.QuanTri;
using System.Transactions;
using DocSo_PC.BaoCao;
using DocSo_PC.GUI.BaoCao;
using Spire.Pdf;
using System.IO;
using System.Drawing.Printing;

namespace DocSo_PC.GUI.VanThu
{
    public partial class frmCongVanDen : Form
    {
        string _mnu = "mnuCongVanDen";
        CCongVanDen _cCVD = new CCongVanDen();
        CThuongVu _cThuongVu = new CThuongVu();
        CGanMoi _cGanMoi = new CGanMoi();
        CDHN _cDHN = new CDHN();
        TB_DULIEUKHACHHANG _ttkh = null;
        TB_DULIEUKHACHHANG_HUYDB _ttkhHuy = null;
        CongVanDen _enCVD = null;
        bool _flagThemDienThoai = false;

        public frmCongVanDen()
        {
            InitializeComponent();
        }

        private void frmCongVanDen_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
            dgvDuyet.AutoGenerateColumns = false;
            dgvDienThoai.AutoGenerateColumns = false;
            cmbLoaiVanBan.SelectedIndex = 0;
            DataTable dt = _cCVD.getGroup_NoiDung();
            DataRow dr = dt.NewRow();
            dr["LoaiVB"] = "Tất Cả";
            dt.Rows.InsertAt(dr, 0);
            cmbLoaiVanBan_Duyet.DataSource = dt;
            cmbLoaiVanBan_Duyet.DisplayMember = "LoaiVB";
            cmbLoaiVanBan_Duyet.ValueMember = "LoaiVB";
            cmbLoaiVanBan_Duyet.SelectedIndex = 0;
            cmbTo.SelectedIndex = 0;
        }

        public void Clear()
        {
            txtMaDon.Text = "";
            txtMaDon.Focus();
            cmbLoaiVanBan_Nhap.SelectedIndex = -1;
            cmbNoiChuyen.SelectedIndex = -1;
            txtDanhBo.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtNoiDung.Text = "";
            _ttkh = null;
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDon.Text.Trim() != "")
            {
                DonTu_ChiTiet dontu_ChiTiet = null;
                if (txtMaDon.Text.Trim().Replace(" ", "").Replace("-", "").Contains(".") == true)
                {
                    string[] MaDons = txtMaDon.Text.Trim().Replace(" ", "").Replace("-", "").Split('.');
                    dontu_ChiTiet = _cThuongVu.get_ChiTiet(decimal.Parse(MaDons[0]), decimal.Parse(MaDons[1]));
                }
                else
                {
                    LinQ.DonTu dt = _cThuongVu.get(decimal.Parse(txtMaDon.Text.Trim().Replace(" ", "").Replace("-", "")));
                    if (dt != null)
                        dontu_ChiTiet = dt.DonTu_ChiTiets.SingleOrDefault();
                }
                switch (cmbLoaiVanBan.SelectedItem.ToString())
                {
                    case "BB Kiểm Tra":
                        if (dontu_ChiTiet != null)
                            dgvDanhSach.DataSource = _cThuongVu.getDS_KTXM(dontu_ChiTiet.MaDon.Value, dontu_ChiTiet.STT.Value);
                        else
                            dgvDanhSach.DataSource = _cThuongVu.getDS_KTXM(txtMaDon.Text.Trim().Replace(" ", "").Replace("-", ""));
                        break;
                    case "TB Cắt Tạm":
                        if (dontu_ChiTiet != null)
                            dgvDanhSach.DataSource = _cThuongVu.getDS_CHDB(dontu_ChiTiet.MaDon.Value, dontu_ChiTiet.STT.Value);
                        else
                            dgvDanhSach.DataSource = _cThuongVu.getDS_CHDB(txtMaDon.Text.Trim().Replace(" ", "").Replace("-", ""));
                        break;
                    case "TB Cắt Hủy":
                        if (dontu_ChiTiet != null)
                            dgvDanhSach.DataSource = _cThuongVu.getDS_CHDB(dontu_ChiTiet.MaDon.Value, dontu_ChiTiet.STT.Value);
                        else
                            dgvDanhSach.DataSource = _cThuongVu.getDS_CHDB(txtMaDon.Text.Trim().Replace(" ", "").Replace("-", ""));
                        break;
                    case "Tờ Trình":
                        if (dontu_ChiTiet != null)
                            dgvDanhSach.DataSource = _cThuongVu.getDS_ToTrinh(dontu_ChiTiet.MaDon.Value, dontu_ChiTiet.STT.Value);
                        else
                            dgvDanhSach.DataSource = _cThuongVu.getDS_ToTrinh(txtMaDon.Text.Trim().Replace(" ", "").Replace("-", ""));
                        break;
                    case "Biên Bản Nghiệm Thu":
                        dgvDanhSach.DataSource = _cGanMoi.getDS_BBNT(txtMaDon.Text.Trim().Replace(" ", "").Replace("-", ""));
                        break;
                    default:
                        break;
                }
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (chkAuto.Checked)
            {
                string MaTo = "";
                if (cmbTo.SelectedItem.ToString() == "Tân Bình")
                    MaTo = "ToTB";
                else
                    if (cmbTo.SelectedItem.ToString() == "Tân Phú")
                        MaTo = "ToTP";
                    else
                        if (cmbTo.SelectedItem.ToString() == "Bấm Chì")
                            MaTo = "ToBC";
                dgvDanhSach.DataSource = _cThuongVu.getDS_CVD(MaTo, dateTu.Value, dateDen.Value);
            }
            else
            {
                if (txtMaDon.Text.Trim() != "")
                    dgvDanhSach.DataSource = _cCVD.getDS(txtMaDon.Text.Trim().Replace(" ", "").Replace("-", ""));
                else
                    dgvDanhSach.DataSource = _cCVD.getDS(dateTu.Value, dateDen.Value);
            }
        }

        private void dgvDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDanhSach.Columns[e.ColumnIndex].Name == "XemHinh")
                {
                    if (dgvDanhSach.CurrentRow.Cells["TableName"].Value.ToString() == "")
                    {
                        MessageBox.Show("Không có File", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    DataTable dt = _cThuongVu.getFile(dgvDanhSach.CurrentRow.Cells["TableName"].Value.ToString(), int.Parse(dgvDanhSach.CurrentRow.Cells["IDCT"].Value.ToString()));
                    if (dt != null && dt.Rows.Count > 0)
                        foreach (DataRow item in dt.Rows)
                        {
                            if (item["Type"].ToString().ToLower().Contains("pdf"))
                                _cCVD.viewPDF((byte[])item["File"]);
                            else
                                _cCVD.viewImage((byte[])item["File"]);
                        }
                    //string TableNameHinh, IDName;
                    //_cThuongVu.getTableHinh(dgvDanhSach.CurrentRow.Cells["TableName"].Value.ToString(), out TableNameHinh, out IDName);
                    //System.Diagnostics.Process.Start("https://service.cskhtanhoa.com.vn/ThuongVu/viewFile?TableName=" + TableNameHinh + "&IDFileName=" + IDName + "&IDFileContent=" + dgvDanhSach.CurrentRow.Cells["IDCT"].Value.ToString());
                }
                else
                    if (dgvDanhSach.Columns[e.ColumnIndex].Name == "Them")
                    {
                        try
                        {
                            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                            {
                                if (dgvDanhSach.CurrentRow.Cells["NoiDung"].Value == null || string.IsNullOrEmpty(dgvDanhSach.CurrentRow.Cells["NoiDung"].Value.ToString().Trim()))
                                {
                                    MessageBox.Show("Nội Dung rỗng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                CongVanDen en = new CongVanDen();
                                en.LoaiVB = dgvDanhSach.CurrentRow.Cells["LoaiVB"].Value.ToString();
                                en.NoiChuyen = dgvDanhSach.CurrentRow.Cells["NoiChuyen"].Value.ToString();
                                //en.NgayChuyen = DateTime.Parse(dgvDanhSach.CurrentRow.Cells["NgayChuyen"].Value.ToString());
                                en.MLT = dgvDanhSach.CurrentRow.Cells["MLT"].Value.ToString();
                                en.DanhBo = dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString();
                                en.HoTen = dgvDanhSach.CurrentRow.Cells["HoTen"].Value.ToString();
                                en.DiaChi = dgvDanhSach.CurrentRow.Cells["DiaChi"].Value.ToString();
                                en.NoiDung = dgvDanhSach.CurrentRow.Cells["NoiDung"].Value.ToString();
                                en.MaDon = dgvDanhSach.CurrentRow.Cells["MaDon"].Value.ToString();
                                en.TableName = dgvDanhSach.CurrentRow.Cells["TableName"].Value.ToString();
                                en.IDCT = int.Parse(dgvDanhSach.CurrentRow.Cells["IDCT"].Value.ToString());
                                if (dgvDanhSach.CurrentRow.Cells["ToMaHoa"].Value != null && dgvDanhSach.CurrentRow.Cells["ToMaHoa"].Value.ToString() != "")
                                    en.ToMaHoa = bool.Parse(dgvDanhSach.CurrentRow.Cells["ToMaHoa"].Value.ToString());
                                if (_cCVD.checkExists(en.TableName, en.IDCT.Value) == true)
                                {
                                    MessageBox.Show("Đã nhập rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                if (_cCVD.Them(en) == true)
                                {
                                    if (en.LoaiVB == "Phiếu Hủy" && en.NoiChuyen == "P. Thương Vụ")
                                    {
                                        en.Duyet_Ngay = en.CreateDate;
                                        _cCVD.SubmitChanges();

                                        TB_DULIEUKHACHHANG danhbo = _cDHN.get(en.DanhBo);
                                        if (danhbo != null)
                                        {
                                            TB_DULIEUKHACHHANG_HUYDB danhbohuy = new TB_DULIEUKHACHHANG_HUYDB();
                                            danhbohuy.KHU = danhbo.KHU;
                                            danhbohuy.DOT = danhbo.DOT;
                                            danhbohuy.CUON_GCS = danhbo.CUON_GCS;
                                            danhbohuy.CUON_STT = danhbo.CUON_STT;
                                            danhbohuy.LOTRINH = danhbo.LOTRINH;
                                            danhbohuy.DANHBO = danhbo.DANHBO;
                                            danhbohuy.NGAYGANDH = danhbo.NGAYGANDH;
                                            danhbohuy.HOPDONG = danhbo.HOPDONG;
                                            danhbohuy.HOTEN = danhbo.HOTEN;
                                            danhbohuy.SONHA = danhbo.SONHA;
                                            danhbohuy.TENDUONG = danhbo.TENDUONG;
                                            danhbohuy.PHUONG = danhbo.PHUONG;
                                            danhbohuy.QUAN = danhbo.QUAN;
                                            danhbohuy.CHUKY = danhbo.CHUKY;
                                            danhbohuy.CODE = danhbo.CODE;
                                            danhbohuy.CODEFU = danhbo.CODEFU;
                                            danhbohuy.GIABIEU = danhbo.GIABIEU;
                                            danhbohuy.DINHMUC = danhbo.DINHMUC;
                                            danhbohuy.DINHMUCHN = danhbo.DINHMUCHN;
                                            danhbohuy.SH = danhbo.SH;
                                            danhbohuy.HCSN = danhbo.HCSN;
                                            danhbohuy.SX = danhbo.SX;
                                            danhbohuy.DV = danhbo.DV;
                                            danhbohuy.CODH = danhbo.CODH;
                                            danhbohuy.HIEUDH = danhbo.HIEUDH;
                                            danhbohuy.SOTHANDH = danhbo.SOTHANDH;
                                            danhbohuy.CAP = danhbo.CAP;
                                            danhbohuy.CHITHAN = danhbo.CHITHAN;
                                            danhbohuy.CHIGOC = danhbo.CHIGOC;
                                            danhbohuy.VITRIDHN = danhbo.VITRIDHN;
                                            danhbohuy.ViTriDHN_Ngoai = danhbo.ViTriDHN_Ngoai;
                                            danhbohuy.ViTriDHN_Hop = danhbo.ViTriDHN_Hop;
                                            danhbohuy.Gieng = danhbo.Gieng;
                                            danhbohuy.NGAYTHAY = danhbo.NGAYTHAY;
                                            danhbohuy.NGAYKIEMDINH = danhbo.NGAYKIEMDINH;
                                            danhbohuy.SODHN = danhbo.SODHN;
                                            danhbohuy.MSTHUE = danhbo.MSTHUE;
                                            danhbohuy.CHISOKYTRUOC = danhbo.CHISOKYTRUOC;
                                            CHDB_Phieu phieuhuy = _cThuongVu.getPhieuHuy(en.IDCT.Value);
                                            if (phieuhuy != null)
                                            {
                                                danhbohuy.SOPHIEU = phieuhuy.MaYCCHDB.ToString();
                                                danhbohuy.NGAYHUY = phieuhuy.CreateDate.Value;
                                                danhbohuy.HIEULUCHUY = phieuhuy.HieuLucKy;
                                                danhbohuy.NGUYENNHAN = phieuhuy.LyDo + " " + phieuhuy.GhiChuLyDo;
                                                danhbohuy.CREATEBY = CNguoiDung.HoTen;
                                                danhbohuy.CREATEDATE = DateTime.Now;
                                                CDHN._db.TB_DULIEUKHACHHANG_HUYDBs.InsertOnSubmit(danhbohuy);
                                                CDHN._db.TB_DULIEUKHACHHANGs.DeleteOnSubmit(danhbo);
                                                CDHN._db.SubmitChanges();
                                            }
                                        }
                                    }
                                    string sql = "insert into TB_GHICHU(DANHBO,DONVI,NOIDUNG,CREATEDATE,CREATEBY)values('" + en.DanhBo + "',N'QLDHN',N'" + en.NoiDung + "','" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture) + "',N'" + CNguoiDung.HoTen + "')";
                                    CDHN._cDAL.ExecuteNonQuery(sql);
                                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Clear();
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
                    else
                        if (dgvDanhSach.Columns[e.ColumnIndex].Name == "CapNhat")
                        {
                            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                            {
                                string sql = "insert into TB_GHICHU(DANHBO,DONVI,NOIDUNG,CREATEDATE,CREATEBY)values('" + dgvDanhSach.CurrentRow.Cells["DanhBo"].Value.ToString() + "',N'QLDHN',N'" + dgvDanhSach.CurrentRow.Cells["NoiDung"].Value.ToString() + "','" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture) + "',N'" + CNguoiDung.HoTen + "')";
                                CDHN._cDAL.ExecuteNonQuery(sql);
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
            }
            catch { }
        }

        private void dgvDanhSach_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Xoa") && MessageBox.Show("Bạn chắc chắn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CongVanDen en = _cCVD.get(int.Parse(dgvDanhSach.CurrentRow.Cells["ID"].Value.ToString()));
                    if (en != null)
                    {
                        if (_cCVD.Xoa(en))
                        {
                            string sql = "delete TB_GHICHU where DONVI=N'QLDHN' and NoiDung like N'" + dgvDanhSach.CurrentRow.Cells["NoiDung"].Value.ToString() + "'";
                            CDHN._cDAL.ExecuteNonQuery(sql);
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgvDanhSach_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (dgvDanhSach.Columns[e.ColumnIndex].Name == "ToMaHoa" && dgvDanhSach.CurrentRow.Cells["ID"].Value != null && dgvDanhSach.CurrentRow.Cells["ID"].Value.ToString() != "")
                    {
                        CongVanDen en = _cCVD.get(int.Parse(dgvDanhSach.CurrentRow.Cells["ID"].Value.ToString()));
                        en.ToMaHoa = bool.Parse(dgvDanhSach.CurrentRow.Cells["ToMaHoa"].Value.ToString());
                        _cCVD.Sua(en);
                    }
                    else
                        if (dgvDanhSach.Columns[e.ColumnIndex].Name == "NoiDung" && dgvDanhSach.CurrentRow.Cells["ID"].Value != null && dgvDanhSach.CurrentRow.Cells["ID"].Value.ToString() != "")
                        {
                            CongVanDen en = _cCVD.get(int.Parse(dgvDanhSach.CurrentRow.Cells["ID"].Value.ToString()));
                            en.NoiDung = dgvDanhSach.CurrentRow.Cells["NoiDung"].Value.ToString();
                            _cCVD.Sua(en);
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

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo.Text.Trim() != "")
            {
                _ttkh = _cDHN.get(txtDanhBo.Text.Trim().Replace(" ", "").Replace("-", ""));
                if (_ttkh == null)
                    _ttkhHuy = _cDHN.get_Huy(txtDanhBo.Text.Trim().Replace(" ", "").Replace("-", ""));
                if (_ttkh != null)
                {
                    txtDanhBo.Text = _ttkh.DANHBO;
                    txtHoTen.Text = _ttkh.HOTEN;
                    txtDiaChi.Text = _ttkh.SONHA + " " + _ttkh.TENDUONG;
                }
                else
                    if (_ttkhHuy != null)
                    {
                        txtDanhBo.Text = _ttkhHuy.DANHBO;
                        txtHoTen.Text = _ttkhHuy.HOTEN;
                        txtDiaChi.Text = _ttkhHuy.SONHA + " " + _ttkhHuy.TENDUONG;
                    }
                    else
                        MessageBox.Show("Danh Bộ không tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    if (_ttkh != null || _ttkhHuy != null)
                    {
                        if (string.IsNullOrEmpty(txtNoiDung.Text.Trim()))
                        {
                            MessageBox.Show("Nội Dung rỗng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        CongVanDen en = new CongVanDen();
                        en.LoaiVB = cmbLoaiVanBan_Nhap.SelectedItem.ToString();
                        en.NoiChuyen = cmbNoiChuyen.SelectedItem.ToString();
                        //en.NgayChuyen = DateTime.Parse(dgvDanhSach.CurrentRow.Cells["NgayChuyen"].Value.ToString());
                        if (_ttkh != null)
                        {
                            en.MLT = _ttkh.LOTRINH;
                            en.DanhBo = _ttkh.DANHBO;
                            en.HoTen = _ttkh.HOTEN;
                            en.DiaChi = _ttkh.SONHA + " " + _ttkh.TENDUONG;
                        }
                        else
                            if (_ttkhHuy != null)
                            {
                                en.MLT = _ttkhHuy.LOTRINH;
                                en.DanhBo = _ttkhHuy.DANHBO;
                                en.HoTen = _ttkhHuy.HOTEN;
                                en.DiaChi = _ttkhHuy.SONHA + " " + _ttkhHuy.TENDUONG;
                            }
                        en.NoiDung = txtNoiDung.Text.Trim();
                        if (_cCVD.checkExists(en.DanhBo, en.NoiDung) == true)
                        {
                            MessageBox.Show("Đã nhập rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (_cCVD.Them(en) == true)
                        {
                            //CThuongVu._cDAL.ExecuteNonQuery("update CongVanDi set Nhan_QLDHN=1,Nhan_QLDHN_Ngay=getdate() where ID=" + dgvDanhSach.CurrentRow.Cells["ID"].Value.ToString());
                            string sql = "insert into TB_GHICHU(DANHBO,DONVI,NOIDUNG,CREATEDATE,CREATEBY)values('" + en.DanhBo + "',N'QLDHN',N'" + en.NoiDung + "','" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", System.Globalization.CultureInfo.InvariantCulture) + "',N'" + CNguoiDung.HoTen + "')";
                            CDHN._cDAL.ExecuteNonQuery(sql);
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                    }
                    else
                        MessageBox.Show("Danh Bộ không tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //tab Bút Phê

        int _index = 0;
        DataTable _dtDuyet = null;
        public void Clear_ButPhe()
        {
            _enCVD = null;
            chkXem.Checked = false;
            chkCapNhat.Checked = false;
            chkTinhTieuThu.Checked = false;
            chkTheoDoi.Checked = false;
            chkKiemTraLaiHienTruong.Checked = false;
            chkBaoThay.Checked = false;
            chkDeBiet.Checked = false;
            chkKhac.Checked = false;
            txtKhac_GhiChu.Text = "";
            chkDaXuLy.Checked = false;
            txtDaXuLy_Ngay.Text = "";
            _index = 0;
            _dtDuyet = null;
            btnTruoc.Visible = false;
            btnSau.Visible = false;
            pictureBox.Image = null;
        }

        private void radChuaDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radChuaDuyet.Checked)
                panel1.Enabled = false;
        }

        private void radDaDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radDaDuyet.Checked)
                panel1.Enabled = true;
        }

        private void dgvDuyet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDuyet["TableName_Duyet", e.RowIndex].Value.ToString() == "")
                {
                    MessageBox.Show("Không có File", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Clear_ButPhe();
                _enCVD = _cCVD.get(int.Parse(dgvDuyet["ID_Duyet", e.RowIndex].Value.ToString()));
                if (_enCVD != null)
                {
                    chkXem.Checked = _enCVD.Xem;
                    chkCapNhat.Checked = _enCVD.CapNhat;
                    chkTinhTieuThu.Checked = _enCVD.TinhTieuThu;
                    chkTheoDoi.Checked = _enCVD.TheoDoi;
                    chkKiemTraLaiHienTruong.Checked = _enCVD.KiemTraLaiHienTruong;
                    chkBaoThay.Checked = _enCVD.BaoThay;
                    chkDeBiet.Checked = _enCVD.DeBiet;
                    chkKhac.Checked = _enCVD.Khac;
                    txtKhac_GhiChu.Text = _enCVD.Khac_GhiChu;
                    chkDaXuLy.Checked = _enCVD.DaXuLy;
                    if (_enCVD.DaXuLy_Ngay != null)
                        txtDaXuLy_Ngay.Text = _enCVD.DaXuLy_Ngay.Value.ToString();
                    dgvDienThoai.DataSource = _cDHN.getDS_DienThoai(_enCVD.DanhBo);
                }
                _dtDuyet = _cThuongVu.getFile(dgvDuyet["TableName_Duyet", e.RowIndex].Value.ToString(), int.Parse(dgvDuyet["IDCT_Duyet", e.RowIndex].Value.ToString()));
                if (_dtDuyet != null && _dtDuyet.Rows.Count > 0)
                {
                    int index = -1;
                    for (int i = 0; i < _dtDuyet.Rows.Count; i++)
                        if (_dtDuyet.Rows[i]["Type"].ToString().ToLower().Contains("pdf"))
                            _cCVD.viewPDF((byte[])_dtDuyet.Rows[i]["File"]);
                        else
                            if (index == -1)
                                index = i;
                    if (index > -1)
                    {
                        pictureBox.Image = _cCVD.byteArrayToImage((byte[])_dtDuyet.Rows[index]["File"]);
                        if (_dtDuyet.Rows.Count > 1)
                        {
                            btnTruoc.Visible = true;
                            btnSau.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (_enCVD != null)
                    {
                        _enCVD.Xem = chkXem.Checked;
                        _enCVD.CapNhat = chkCapNhat.Checked;
                        _enCVD.TinhTieuThu = chkTinhTieuThu.Checked;
                        _enCVD.TheoDoi = chkTheoDoi.Checked;
                        _enCVD.KiemTraLaiHienTruong = chkKiemTraLaiHienTruong.Checked;
                        _enCVD.BaoThay = chkBaoThay.Checked;
                        _enCVD.DeBiet = chkDeBiet.Checked;
                        if (chkKhac.Checked)
                        {
                            _enCVD.Khac = true;
                            _enCVD.Khac_GhiChu = txtKhac_GhiChu.Text.Trim();
                        }
                        else
                        {
                            _enCVD.Khac = false;
                            _enCVD.Khac_GhiChu = null;
                        }
                        _enCVD.Duyet_Ngay = DateTime.Now;
                        _cCVD.SubmitChanges();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear_ButPhe();
                    }
                    else
                    {
                        foreach (DataGridViewRow item in dgvDuyet.Rows)
                            if (item.Cells["Chon"].Value != null && item.Cells["Chon"].Value.ToString() != "" && bool.Parse(item.Cells["Chon"].Value.ToString()))
                            {
                                CongVanDen enCVD = _cCVD.get(int.Parse(item.Cells["ID_Duyet"].Value.ToString()));
                                if (enCVD != null)
                                {
                                    enCVD.Xem = chkXem.Checked;
                                    enCVD.CapNhat = chkCapNhat.Checked;
                                    enCVD.TinhTieuThu = chkTinhTieuThu.Checked;
                                    enCVD.TheoDoi = chkTheoDoi.Checked;
                                    enCVD.KiemTraLaiHienTruong = chkKiemTraLaiHienTruong.Checked;
                                    enCVD.BaoThay = chkBaoThay.Checked;
                                    enCVD.DeBiet = chkDeBiet.Checked;
                                    if (chkKhac.Checked)
                                    {
                                        enCVD.Khac = true;
                                        enCVD.Khac_GhiChu = txtKhac_GhiChu.Text.Trim();
                                    }
                                    else
                                    {
                                        enCVD.Khac = false;
                                        enCVD.Khac_GhiChu = null;
                                    }
                                    enCVD.Duyet_Ngay = DateTime.Now;
                                    _cCVD.SubmitChanges();
                                }
                            }
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear_ButPhe();
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

        private void btnXem_Duyet_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDanhBo_ButPhe.Text.Trim() != "")
                    dgvDuyet.DataSource = _cCVD.getDS(txtDanhBo_ButPhe.Text.Trim().Replace(" ", "").Replace("-", ""));
                else
                    if (radChuaDuyet.Checked)
                        dgvDuyet.DataSource = _cCVD.getDS_ChuaDuyet(cmbLoaiVanBan_Duyet.SelectedValue.ToString());
                    else
                        if (radDaDuyet.Checked)
                            dgvDuyet.DataSource = _cCVD.getDS_DaDuyet(cmbLoaiVanBan_Duyet.SelectedValue.ToString(), dateTu_Duyet.Value, dateDen_Duyet.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDuyet_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDuyet.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void chkKhac_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKhac.Checked)
                txtKhac_GhiChu.ReadOnly = false;
            else
                txtKhac_GhiChu.ReadOnly = true;
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            if (_dtDuyet != null && _dtDuyet.Rows.Count > 0)
            {
                while (_index > 0)
                {
                    _index--;
                    if (!_dtDuyet.Rows[_index]["Type"].ToString().ToLower().Contains("pdf"))
                        break;
                }
                pictureBox.Image = _cCVD.byteArrayToImage((byte[])_dtDuyet.Rows[_index]["File"]);
            }
        }

        private void btnSau_Click(object sender, EventArgs e)
        {
            if (_dtDuyet != null && _dtDuyet.Rows.Count > 0)
            {
                while (_index < _dtDuyet.Rows.Count - 1)
                {
                    _index++;
                    if (!_dtDuyet.Rows[_index]["Type"].ToString().ToLower().Contains("pdf"))
                        break;
                }
                pictureBox.Image = _cCVD.byteArrayToImage((byte[])_dtDuyet.Rows[_index]["File"]);
            }
        }

        private void btnIn_ToTrinh_Click(object sender, EventArgs e)
        {
            try
            {
                dsBaoCao dsBaoCao = new dsBaoCao();
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (DataGridViewRow item in dgvDanhSach.Rows)
                        if (item.Cells["LoaiVB"].Value.ToString() == "Tờ Trình" || item.Cells["LoaiVB"].Value.ToString() == "Phiếu Hủy")
                        {
                            DataTable dt = _cThuongVu.getFile(item.Cells["TableName"].Value.ToString(), int.Parse(item.Cells["IDCT"].Value.ToString()));
                            if (dt != null && dt.Rows.Count > 0)
                                foreach (DataRow itemC in dt.Rows)
                                {
                                    if (itemC["Type"].ToString().ToLower().Contains("pdf"))
                                    {
                                        File.WriteAllBytes(@"D:\temp.pdf", (byte[])itemC["File"]);
                                        PdfDocument pdf = new PdfDocument();
                                        pdf.LoadFromFile(@"D:\temp.pdf");
                                        pdf.PrintSettings.PrinterName = printDialog.PrinterSettings.PrinterName;
                                        pdf.Print();
                                    }
                                    else
                                    {
                                        DataRow dr = dsBaoCao.Tables["BaoCao"].NewRow();
                                        dr["Image"] = (byte[])itemC["File"];
                                        dsBaoCao.Tables["BaoCao"].Rows.Add(dr);
                                    }
                                }
                        }
                    if (dsBaoCao.Tables["BaoCao"].Rows.Count > 0)
                    {
                        frmShowBaoCao2 frm = new frmShowBaoCao2(dsBaoCao.Tables["BaoCao"]);
                        frm.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkDaXuLy_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKhac.Checked)
                txtDaXuLy_Ngay.ReadOnly = false;
            else
                txtDaXuLy_Ngay.ReadOnly = true;
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
                foreach (DataGridViewRow item in dgvDuyet.Rows)
                {
                    item.Cells["Chon"].Value = true;
                }
            else
                foreach (DataGridViewRow item in dgvDuyet.Rows)
                {
                    item.Cells["Chon"].Value = false;
                }
        }

        private void btnIn_ButPhe_Click(object sender, EventArgs e)
        {
            try
            {
                if (_enCVD != null)
                {
                    dsBaoCao dsBaoCao = new dsBaoCao();
                    PrintDialog printDialog = new PrintDialog();
                    if (printDialog.ShowDialog() == DialogResult.OK)
                    {
                        DataTable dt = _cThuongVu.getFile(_enCVD.TableName, _enCVD.IDCT.Value);
                        if (dt != null && dt.Rows.Count > 0)
                            foreach (DataRow itemC in dt.Rows)
                            {
                                if (itemC["Type"].ToString().ToLower().Contains("pdf"))
                                {
                                    File.WriteAllBytes(@"D:\temp.pdf", (byte[])itemC["File"]);
                                    PdfDocument pdf = new PdfDocument();
                                    pdf.LoadFromFile(@"D:\temp.pdf");
                                    pdf.PrintSettings.PrinterName = printDialog.PrinterSettings.PrinterName;
                                    pdf.Print();
                                }
                                else
                                {
                                    DataRow dr = dsBaoCao.Tables["BaoCao"].NewRow();
                                    dr["Image"] = (byte[])itemC["File"];
                                    dsBaoCao.Tables["BaoCao"].Rows.Add(dr);
                                }
                            }
                        if (dsBaoCao.Tables["BaoCao"].Rows.Count > 0)
                        {
                            frmShowBaoCao2 frm = new frmShowBaoCao2(dsBaoCao.Tables["BaoCao"]);
                            frm.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDuyet_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (dgvDuyet.Columns[e.ColumnIndex].Name == "ToMaHoa_Duyet" && dgvDuyet.CurrentRow.Cells["ID_Duyet"].Value != null && dgvDuyet.CurrentRow.Cells["ID_Duyet"].Value.ToString() != "")
                    {
                        CongVanDen en = _cCVD.get(int.Parse(dgvDuyet.CurrentRow.Cells["ID_Duyet"].Value.ToString()));
                        en.ToMaHoa = bool.Parse(dgvDuyet.CurrentRow.Cells["ToMaHoa_Duyet"].Value.ToString());
                        _cCVD.Sua(en);
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

        private void dgvDienThoai_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            _flagThemDienThoai = true;
        }

        private void dgvDienThoai_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
                {
                    if (_enCVD != null)
                    {
                        SDT_DHN en = _cDHN.get_DienThoai(e.Row.Cells["DanhBo_DT"].Value.ToString(), e.Row.Cells["DienThoai_DT"].Value.ToString());
                        if (en != null)
                        {
                            if (_cDHN.xoa_DienThoai(en) == true)
                            {
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgvDienThoai_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_flagThemDienThoai == false && dgvDienThoai["DanhBo_DT", e.RowIndex].Value.ToString() != "" && (dgvDienThoai.Columns[e.ColumnIndex].Name == "HoTen_DT" || dgvDienThoai.Columns[e.ColumnIndex].Name == "SoChinh_DT"))
                    if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                    {
                        if (_enCVD != null)
                        {
                            SDT_DHN en = _cDHN.get_DienThoai(dgvDienThoai["DanhBo_DT", e.RowIndex].Value.ToString(), dgvDienThoai["DienThoai_DT", e.RowIndex].Value.ToString());
                            if (en != null)
                            {
                                en.HoTen = dgvDienThoai["HoTen_DT", e.RowIndex].Value.ToString();
                                if (dgvDienThoai["SoChinh_DT", e.RowIndex].Value != null && dgvDienThoai["SoChinh_DT", e.RowIndex].Value.ToString() != "")
                                    en.SoChinh = bool.Parse(dgvDienThoai["SoChinh_DT", e.RowIndex].Value.ToString());
                                else
                                    en.SoChinh = false;
                                en.GhiChu = dgvDienThoai["GhiChu_DT", e.RowIndex].Value.ToString();
                                en.ModifyBy = CNguoiDung.MaND;
                                en.ModifyDate = DateTime.Now;
                                _cDHN.SubmitChanges();
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

        private void dgvDienThoai_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    if (_enCVD != null && _flagThemDienThoai == true)
                    {
                        if (dgvDienThoai["DienThoai_DT", e.RowIndex].Value.ToString().Length != 11 && dgvDienThoai["DienThoai_DT", e.RowIndex].Value.ToString().All(char.IsNumber) == false)
                        {
                            MessageBox.Show("Không đủ 10 số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (_cDHN.checkExists_DienThoai(_enCVD.DanhBo, dgvDienThoai["DienThoai_DT", e.RowIndex].Value.ToString()) == true)
                        {
                            MessageBox.Show("Đã Tồn Tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        SDT_DHN en = new SDT_DHN();
                        en.DanhBo = _enCVD.DanhBo;
                        en.DienThoai = dgvDienThoai["DienThoai_DT", e.RowIndex].Value.ToString();
                        en.HoTen = dgvDienThoai["HoTen_DT", e.RowIndex].Value.ToString();
                        if (dgvDienThoai["SoChinh_DT", e.RowIndex].Value != null && dgvDienThoai["SoChinh_DT", e.RowIndex].Value.ToString() != "")
                            en.SoChinh = bool.Parse(dgvDienThoai["SoChinh_DT", e.RowIndex].Value.ToString());
                        else
                            en.SoChinh = false;
                        en.GhiChu = dgvDienThoai["GhiChu_DT", e.RowIndex].Value.ToString();
                        if (_cDHN.them_DienThoai(en) == true)
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        _flagThemDienThoai = false;
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

        private void txtDanhBo_ButPhe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo_ButPhe.Text.Trim().Replace(" ", "").Replace("-", "").Length == 11)
            {
                btnXem_Duyet.PerformClick();
            }
        }

    }
}
