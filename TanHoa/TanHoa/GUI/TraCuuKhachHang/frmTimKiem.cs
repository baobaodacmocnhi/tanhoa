using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TanHoa.DAL;

namespace TanHoa.GUI.TraCuuKhachHang
{
    public partial class frmTimKiem : Form
    {
        //CConnection _cDHN = new CConnection("Data Source=192.168.90.8\\KD;Initial Catalog=CAPNUOCTANHOA;Persist Security Info=True;User ID=sa;Password=P@ssW012d");
        //CConnection _cDocSo = new CConnection("Data Source=192.168.90.8\\KD;Initial Catalog=DocSoTH;Persist Security Info=True;User ID=sa;Password=P@ssW012d");
        //CConnection _cThuTien = new CConnection("Data Source=192.168.90.9;Initial Catalog=HOADON_TA;Persist Security Info=True;User ID=sa;Password=P@ssW012d9");
        //CConnection _cKinhDoanh = new CConnection("Data Source=192.168.90.11;Initial Catalog=KTKS_DonKH;Persist Security Info=True;User ID=sa;Password=capnuoctanhoa789");
        CConnection _cDHN = new CConnection("Data Source=hp_g7\\KD;Initial Catalog=CAPNUOCTANHOA;Persist Security Info=True;User ID=sa;Password=P@ssW012d");
        CConnection _cDocSo = new CConnection("Data Source=hp_g7\\KD;Initial Catalog=DocSoTH;Persist Security Info=True;User ID=sa;Password=P@ssW012d");
        CConnection _cThuTien = new CConnection("Data Source=server9;Initial Catalog=HOADON_TA;Persist Security Info=True;User ID=sa;Password=P@ssW012d9");
        CConnection _cKinhDoanh = new CConnection("Data Source=serverg8-01;Initial Catalog=KTKS_DonKH;Persist Security Info=True;User ID=sa;Password=capnuoctanhoa789");
        
        public frmTimKiem()
        {
            InitializeComponent();
        }

        public void GetResult(string DanhBo)
        {
            if (DanhBo.Length==11)
            {
                txtDanhBoTimKiem.Text = DanhBo;
                btnTimKiem.PerformClick();
            }
        }

        private void frmTimKiem_Load(object sender, EventArgs e)
        {
            dgvDHN_DocSo.AutoGenerateColumns = false;
            dgvDHN_GhiChu.AutoGenerateColumns = false;
            dgvThuTien.AutoGenerateColumns = false;
            dgvKinhDoanh.AutoGenerateColumns = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDanhBoTimKiem.Text.Trim().Replace(" ", "")) == false)
            {
                try
                {
                    string DanhBo = txtDanhBoTimKiem.Text.Trim().Replace(" ", "");
                    bool flagHuyDB = false;
                    //lấy thông tin khách hàng
                    string sql = "select DanhBo"
                        + ",HoTen"
                        + ",DiaChi=SoNha+' '+TenDuong+', P.'+(select TenPhuong from Phuong where MaPhuong=Phuong and MaQuan=Quan)+', Q.'+(select TenQuan from Quan where MaQuan=Quan)"
                        + ",HopDong"
                        + ",DienThoai"
                        + ",MLT=LoTrinh"
                        + ",DinhMuc"
                        + ",GiaBieu"
                        + ",NgayThay"
                        + ",CoDH"
                        + ",HieuDH"
                        + ",SoThanDH"
                        + ",ViTriDHN"
                        + " from TB_DULIEUKHACHHANG where DanhBo=" + DanhBo;
                    DataTable dt = _cDHN.ExecuteQuery_DataTable(sql);
                    //lấy thông tin khách hàng đã hủy
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        sql = "select DanhBo"
                        + ",HoTen"
                        + ",DiaChi=SoNha+' '+TenDuong+', P.'+(select TenPhuong from Phuong where MaPhuong=Phuong and MaQuan=Quan)+', Q.'+(select TenQuan from Quan where MaQuan=Quan)"
                        + ",HopDong"
                        //+ ",DienThoai"
                        + ",MLT=LoTrinh"
                        + ",DinhMuc"
                        + ",GiaBieu"
                        + ",NgayThay"
                        + ",CoDH"
                        + ",HieuDH"
                        + ",SoThanDH"
                        + ",ViTriDHN"
                        + " from TB_DULIEUKHACHHANG_HUYDB where DanhBo=" + DanhBo;
                        dt = _cDHN.ExecuteQuery_DataTable(sql);
                        flagHuyDB = true;
                    }
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        if (flagHuyDB == true)
                            MessageBox.Show("Danh Bộ này đã Hủy", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDanhBo.Text = dt.Rows[0]["DanhBo"].ToString().Insert(7, " ").Insert(4, " ");
                        txtHoTen.Text = dt.Rows[0]["HoTen"].ToString();
                        txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
                        if (dt.Columns.Contains("DienThoai") == true)
                            txtDienThoai.Text = dt.Rows[0]["DienThoai"].ToString();
                        txtHopDong.Text = dt.Rows[0]["HopDong"].ToString();
                        txtMLT.Text = dt.Rows[0]["MLT"].ToString().Insert(4, " ").Insert(2, " "); ;
                        txtGiaBieu.Text = dt.Rows[0]["GiaBieu"].ToString();
                        txtDinhMuc.Text = dt.Rows[0]["DinhMuc"].ToString();
                        DateTime date = DateTime.Parse(dt.Rows[0]["NgayThay"].ToString());
                        txtNgayGan.Text = date.ToString("dd/MM/yyyy");
                        txtCo.Text = dt.Rows[0]["CoDH"].ToString();
                        txtHieu.Text = dt.Rows[0]["HieuDH"].ToString();
                        txtSoThan.Text = dt.Rows[0]["SoThanDH"].ToString();
                        txtViTri.Text = dt.Rows[0]["ViTriDHN"].ToString();

                        //lấy thông tin đọc số
                        sql = "select top(12) Ky=CONVERT(char(2),Ky)+'/'+CONVERT(char(4),Nam)"
                            + ",NgayDoc=CONVERT(char(10),DenNgay,103)"
                            + ",CodeMoi"
                            + ",ChiSoCu=CSCu"
                            + ",ChiSoMoi=CSMoi"
                            + ",TieuThu=TieuThuMoi"
                            + " from DocSo"
                            + " where DanhBa="+DanhBo
                            + " order by Nam desc,CAST(Ky as int) desc";
                        dgvDHN_DocSo.DataSource = _cDocSo.ExecuteQuery_DataTable(sql);
                        dgvDHN_GhiChu.DataSource = _cDHN.ExecuteQuery_DataTable("select NoiDung,CreateDate from TB_GHICHU where DanhBo=" + DanhBo + " order by CreateDate desc");
                        //lấy thông tin thu tiền
                        sql = "select top(12) Ky=CONVERT(char(2),KY)+'/'+CONVERT(char(4),NAM)"
                            + ",TIEUTHU"
                            + ",GIABAN"
                            + ",ThueGTGT=THUE"
                            + ",PhiBVMT=PHI"
                            + ",TONGCONG"
                            + ",NGAYGIAITRACH=CONVERT(char(10),NGAYGIAITRACH,103)"
                            + " from HOADON"
                            + " where DANHBA="+DanhBo
                            + " order by ID_HOADON desc";
                        dgvThuTien.DataSource = _cThuTien.ExecuteQuery_DataTable(sql);
                        //lấy thông tin kinh doanh
                        sql = "declare @DanhBo char(11)"
                            + " set @DanhBo="+DanhBo
                            + " select CreateDate,Loai=N'Đơn '+(select TenLD from LoaiDon where MaLD=a.MaLD),NoiDung,GhiChu from DonKH a where DanhBo=@DanhBo"
                            + " union all"
                            + " select CreateDate,Loai=N'Đơn '+(select TenLD from LoaiDonTXL where MaLD=a.MaLD),NoiDung,GhiChu='' from DonTXL a where DanhBo=@DanhBo"
                            + " union all"
                            + " select CreateDate,Loai=N'Đơn '+(select TenLD from LoaiDonTBC where MaLD=a.MaLD),NoiDung,GhiChu='' from DonTBC a where DanhBo=@DanhBo"
                            + " union all"
                            + " select CreateDate=NgayKTXM,Loai=N'Kiểm Tra Xác Minh',NoiDung=HienTrangKiemTra,GhiChu=NoiDungKiemTra from KTXM_ChiTiet where DanhBo=@DanhBo"
                            + " union all"
                            + " select CreateDate=NgayBC,Loai=N'Bấm Chì',NoiDung=TrangThaiBC,GhiChu='' from BamChi_ChiTiet where DanhBo=@DanhBo"
                            + " union all"
                            + " select CreateDate,Loai=N'Điều Chỉnh Biến Động',NoiDung=ThongTin,GhiChu='' from DCBD_ChiTietBienDong where DanhBo=@DanhBo"
                            + " union all"
                            + " select CreateDate,Loai=N'Điều Chỉnh Hóa Đơn',NoiDung=ThongTin,GhiChu=LyDoDieuChinh from DCBD_ChiTietHoaDon where DanhBo=@DanhBo"
                            + " union all"
                            + " select CreateDate,Loai=N'Thông Báo Cắt Tạm',NoiDung=LyDo+' '+GhiChuLyDo,GhiChu=NoiDung from CHDB_ChiTietCatTam where DanhBo=@DanhBo"
                            + " union all"
                            + " select CreateDate,Loai=N'Thông Báo Cắt Hủy',NoiDung=LyDo+' '+GhiChuLyDo,GhiChu=NoiDung from CHDB_ChiTietCatHuy where DanhBo=@DanhBo"
                            + " union all"
                            + " select CreateDate,Loai=N'Tờ Trình',NoiDung=VeViec,GhiChu=NoiDung from ToTrinh_ChiTiet where DanhBo=@DanhBo"
                            + " union all"
                            + " select CreateDate,Loai=N'Thư Trả Lời',NoiDung=VeViec,GhiChu=NoiDung from TTTL_ChiTiet where DanhBo=@DanhBo"
                            + " union all"
                            + " select CreateDate,Loai=N'Truy Thu',NoiDung=TinhTrang,GhiChu=CONVERT(char(10),TongTien) from TruyThuTienNuoc_ChiTiet where DanhBo=@DanhBo"
                            + " union all"
                            + " select CreateDate,Loai=N'Gian Lận',NoiDung=NoiDungViPham,GhiChu=TinhTrang from GianLan_ChiTiet where DanhBo=@DanhBo"
                            + " order by CreateDate desc";
                        dgvKinhDoanh.DataSource = _cKinhDoanh.ExecuteQuery_DataTable(sql);
                    }
                    else
                    {
                        MessageBox.Show("Không Tìm Thấy Danh Bộ này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtDanhBoTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnTimKiem.PerformClick();
        }

        private void dgvThuTien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvThuTien.Columns[e.ColumnIndex].Name == "GiaBan_TT" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvThuTien.Columns[e.ColumnIndex].Name == "ThueGTGT_TT" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvThuTien.Columns[e.ColumnIndex].Name == "PhiBVMT_TT" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvThuTien.Columns[e.ColumnIndex].Name == "TongCong_TT" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void frmTimKiem_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                frmTimKiemDanhBo frm = new frmTimKiemDanhBo();
                frm.GetResult = new frmTimKiemDanhBo.GetValue(GetResult);
                frm.ShowDialog();
            }
        }
    }
}
