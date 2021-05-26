using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.Doi;
using System.Globalization;
using ThuTien.LinQ;
using ThuTien.DAL;
using ThuTien.BaoCao;
using ThuTien.BaoCao.Doi;
using ThuTien.GUI.BaoCao;
using ThuTien.DAL.TongHop;
using ThuTien.DAL.DongNuoc;
using ThuTien.DAL.Quay;

namespace ThuTien.GUI.Doi
{
    public partial class frmLuuHD : Form
    {
        string _fileName = "";
        string _mnu = "mnuLuuHD";
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CHoaDon _cHoaDon = new CHoaDon();
        CDHN _cCapNuocTanHoa = new CDHN();
        CDCHD _cDCHD = new CDCHD();
        CDongNuoc _cDongNuoc = new CDongNuoc();
        CLenhHuy _cLenhHuy = new CLenhHuy();

        public frmLuuHD()
        {
            InitializeComponent();
        }

        private void frmLuuHoaDon_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";
            cmbKy.SelectedItem = DateTime.Now.Month.ToString();

            dgvTyLeTon.AutoGenerateColumns = false;
            cmbNam_TyLeTon.DataSource = _cHoaDon.GetNam();
            cmbNam_TyLeTon.DisplayMember = "Nam";
            cmbNam_TyLeTon.ValueMember = "Nam";
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Files (.dat)|*.dat";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtDuongDan.Text = dialog.FileName;
                _fileName = dialog.SafeFileName;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //TT_DongNuoc dn= _cDongNuoc.getDongNuoc_MoiNhat_Ton("13162310349",2020,7);
            //return;
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    if (txtDuongDan.Text.Trim() != "" && _fileName.Length == 12)
                    {
                        string[] lines = System.IO.File.ReadAllLines(txtDuongDan.Text.Trim());
                        progressBar.Minimum = 0;
                        progressBar.Maximum = lines.Count();
                        int i = 1;
                        int Nam = 0;
                        int Ky = 0;
                        int Dot = 0;
                        foreach (string line in lines)
                        {
                            progressBar.Value = i++;
                            string lineR = line.Replace("\",\"", "$").Replace("\"", "");
                            string[] contents = lineR.Split('$');
                            //string[] contents = System.Text.RegularExpressions.Regex.Split(line, @"\W+");
                            HOADON hoadon = new HOADON();
                            //if (!string.IsNullOrWhiteSpace(contents[0]))
                            //    hoadon.Khu = int.Parse(contents[0]);
                            if (!string.IsNullOrWhiteSpace(contents[1]))
                                hoadon.DOT = Dot = int.Parse(contents[1]);
                            if (!string.IsNullOrWhiteSpace(contents[2]))
                                hoadon.DANHBA = contents[2];
                            //if (!string.IsNullOrWhiteSpace(contents[3]))
                            //    hoadon.CD = int.Parse(contents[3]);
                            //if (!string.IsNullOrWhiteSpace(contents[4]))
                            //    hoadon.CuLy = int.Parse(contents[4]);
                            //if (!string.IsNullOrWhiteSpace(contents[5]))
                            //    hoadon.MSTLK = contents[5];
                            if (!string.IsNullOrWhiteSpace(contents[6]))
                                hoadon.HOPDONG = contents[6];
                            if (!string.IsNullOrWhiteSpace(contents[7]))
                                hoadon.TENKH = contents[7];
                            if (!string.IsNullOrWhiteSpace(contents[8]))
                                hoadon.SO = contents[8];
                            if (!string.IsNullOrWhiteSpace(contents[9]))
                                hoadon.DUONG = contents[9];
                            //if (!string.IsNullOrWhiteSpace(contents[10]))
                            //    hoadon.MSKH = contents[10];
                            //if (!string.IsNullOrWhiteSpace(contents[11]))
                            //    hoadon.MSCQ = contents[11];
                            if (!string.IsNullOrWhiteSpace(contents[12]))
                                hoadon.GB = int.Parse(contents[12]);
                            if (!string.IsNullOrWhiteSpace(contents[13]))
                                hoadon.TILESH = int.Parse(contents[13]);
                            if (!string.IsNullOrWhiteSpace(contents[14]))
                                hoadon.TILEHCSN = int.Parse(contents[14]);
                            if (!string.IsNullOrWhiteSpace(contents[15]))
                                hoadon.TILESX = int.Parse(contents[15]);
                            if (!string.IsNullOrWhiteSpace(contents[16]))
                                hoadon.TILEDV = int.Parse(contents[16]);
                            if (!string.IsNullOrWhiteSpace(contents[17]))
                                hoadon.DM = int.Parse(contents[17]);
                            if (!string.IsNullOrWhiteSpace(contents[18]))
                                hoadon.KY = Ky = int.Parse(contents[18]);
                            if (!string.IsNullOrWhiteSpace(contents[19]))
                                hoadon.NAM = Nam = int.Parse("20" + contents[19]);
                            if (!string.IsNullOrWhiteSpace(contents[20]))
                                hoadon.CODE = contents[20];
                            //if (!string.IsNullOrWhiteSpace(contents[21]))
                            //    hoadon.CodeFu = contents[21];
                            if (!string.IsNullOrWhiteSpace(contents[22]))
                                hoadon.CSCU = int.Parse(contents[22]);
                            if (!string.IsNullOrWhiteSpace(contents[23]))
                                hoadon.CSMOI = int.Parse(contents[23]);
                            //if (!string.IsNullOrWhiteSpace(contents[24]))
                            //    hoadon.RT = contents[24];
                            if (!string.IsNullOrWhiteSpace(contents[25]))
                                hoadon.TUNGAY = DateTime.ParseExact(contents[25], "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                            if (!string.IsNullOrWhiteSpace(contents[26]))
                                hoadon.DENNGAY = DateTime.ParseExact(contents[26], "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                            if (!string.IsNullOrWhiteSpace(contents[27]))
                                hoadon.SONGAY = int.Parse(contents[27]);
                            if (!string.IsNullOrWhiteSpace(contents[28]))
                                hoadon.TIEUTHU = int.Parse(contents[28]);
                            //if (!string.IsNullOrWhiteSpace(contents[29]))
                            //    hoadon.LNCT = int.Parse(contents[29]);
                            if (!string.IsNullOrWhiteSpace(contents[30]))
                                hoadon.TIEUTHUBU = int.Parse(contents[30]);
                            if (!string.IsNullOrWhiteSpace(contents[31]))
                                hoadon.TIEUTHUSH = int.Parse(contents[31]);
                            if (!string.IsNullOrWhiteSpace(contents[32]))
                                hoadon.TIEUTHUHCSN = int.Parse(contents[32]);
                            if (!string.IsNullOrWhiteSpace(contents[33]))
                                hoadon.TIEUTHUSX = int.Parse(contents[33]);
                            if (!string.IsNullOrWhiteSpace(contents[34]))
                                hoadon.TIEUTHUDV = int.Parse(contents[34]);
                            if (!string.IsNullOrWhiteSpace(contents[35]))
                                hoadon.MAY = contents[35];
                            if (!string.IsNullOrWhiteSpace(contents[36]))
                                hoadon.STT = contents[36];
                            if (!string.IsNullOrWhiteSpace(contents[37]))
                                hoadon.GIABAN = int.Parse(contents[37]);
                            if (!string.IsNullOrWhiteSpace(contents[38]))
                                hoadon.THUE = int.Parse(contents[38]);
                            if (!string.IsNullOrWhiteSpace(contents[39]))
                                hoadon.PHI = int.Parse(contents[39]);
                            if (!string.IsNullOrWhiteSpace(contents[40]))
                                hoadon.TONGCONG = int.Parse(contents[40]);
                            if (!string.IsNullOrWhiteSpace(contents[41]))
                                hoadon.GIABAN_BU = int.Parse(contents[41]);
                            if (!string.IsNullOrWhiteSpace(contents[42]))
                                hoadon.THUE_BU = int.Parse(contents[42]);
                            if (!string.IsNullOrWhiteSpace(contents[43]))
                                hoadon.PHI_BU = int.Parse(contents[43]);
                            if (!string.IsNullOrWhiteSpace(contents[44]))
                                hoadon.TONGCONG_BU = int.Parse(contents[44]);
                            if (!string.IsNullOrWhiteSpace(contents[45]))
                                hoadon.SOPHATHANH = int.Parse(contents[45]);
                            if (!string.IsNullOrWhiteSpace(contents[46]))
                                hoadon.SOHOADON = contents[46];
                            //if (!string.IsNullOrWhiteSpace(contents[47]))
                            //    hoadon.NgayPhatHanh = DateTime.Parse(contents[47]);
                            if (!string.IsNullOrWhiteSpace(contents[48]))
                                hoadon.Quan = contents[48];
                            if (!string.IsNullOrWhiteSpace(contents[49]))
                                hoadon.Phuong = contents[49];
                            if (!string.IsNullOrWhiteSpace(contents[50]))
                                hoadon.SoThanDHN = contents[50];
                            if (!string.IsNullOrWhiteSpace(contents[51]))
                                hoadon.MST = contents[51];
                            //if (!string.IsNullOrWhiteSpace(contents[52]))
                            //    hoadon.TileTieuThu = contents[52];
                            //if (!string.IsNullOrWhiteSpace(contents[53]))
                            //    hoadon.NgayGanDHN = DateTime.ParseExact(contents[53], "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                            //if (!string.IsNullOrWhiteSpace(contents[54]))
                            //    hoadon.SoHo = contents[54];
                            if ((hoadon.NAM > 2019 || (hoadon.KY == 12 && hoadon.NAM == 2019)) && !string.IsNullOrWhiteSpace(contents[61]))
                                hoadon.DinhMucHN = int.Parse(contents[61]);
                            hoadon.MALOTRINH = hoadon.DOT.Value.ToString("00") + hoadon.MAY + hoadon.STT;

                            //string Quan = "", Phuong = "", CoDH = "", MaDMA = "";
                            //_cCapNuocTanHoa.GetDMA(hoadon.DANHBA, out Quan, out Phuong, out CoDH, out MaDMA);
                            //hoadon.Quan = Quan;
                            //hoadon.Phuong = Phuong;
                            //hoadon.CoDH = CoDH;
                            //hoadon.MaDMA = MaDMA;
                            //if (CheckByNamKyDot(hoadon.NAM.Value, hoadon.KY, hoadon.DOT.Value))
                            //{
                            //    this.Rollback();
                            //    System.Windows.Forms.MessageBox.Show("Năm " + hoadon.NAM.Value + "; Kỳ " + hoadon.KY + "; Đợt " + hoadon.DOT.Value + " đã có rồi", "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                            //    return false;
                            //}

                            //Nếu chưa có hóa đơn
                            //if (hoadon.DANHBA == "13182498749")
                            if (!_cHoaDon.CheckExist(hoadon.DANHBA, hoadon.NAM.Value, hoadon.KY))
                            {
                                if (_cHoaDon.Them(hoadon) == true)
                                {
                                    if (hoadon.TIEUTHU != 0)
                                    {
                                        int NamTemp = hoadon.NAM.Value, KyTemp = hoadon.KY;
                                        if (KyTemp == 1)
                                        {
                                            KyTemp = 12;
                                            NamTemp--;
                                        }
                                        else
                                        {
                                            KyTemp--;
                                        }

                                        while (_cHoaDon.CheckExist_HD0(hoadon.DANHBA, NamTemp, KyTemp) == true)
                                        {
                                            if (KyTemp == 1)
                                            {
                                                KyTemp = 12;
                                                NamTemp--;
                                            }
                                            else
                                            {
                                                KyTemp--;
                                            }
                                        }

                                        //thêm hóa đơn mới vào lệnh đóng nước
                                        if (_cDongNuoc.CheckExist_CTDongNuoc_Ton(hoadon.DANHBA, NamTemp, KyTemp) == true)
                                        {
                                            TT_DongNuoc dongnuoc = _cDongNuoc.getDongNuoc_MoiNhat_Ton(hoadon.DANHBA, NamTemp, KyTemp);
                                            //update HOADON
                                           HOADON hoadonLenh=_cHoaDon.Get(hoadon.DANHBA, NamTemp, KyTemp);
                                           hoadon.TBDongNuoc_Ngay = hoadonLenh.TBDongNuoc_Ngay;
                                           hoadon.TBDongNuoc_NgayHen = hoadonLenh.TBDongNuoc_NgayHen;
                                           hoadon.TBDongNuoc_Location = hoadonLenh.TBDongNuoc_Location;

                                            TT_CTDongNuoc ctdongnuoc = new TT_CTDongNuoc();
                                            ctdongnuoc.MaDN = dongnuoc.MaDN;
                                            ctdongnuoc.MaHD = _cHoaDon.Get(hoadon.DANHBA, hoadon.NAM.Value, hoadon.KY).ID_HOADON;
                                            ctdongnuoc.SoHoaDon = hoadon.SOHOADON;
                                            ctdongnuoc.Ky = hoadon.KY + "/" + hoadon.NAM;
                                            ctdongnuoc.TieuThu = (int)hoadon.TIEUTHU;
                                            ctdongnuoc.GiaBan = (int)hoadon.GIABAN;
                                            ctdongnuoc.ThueGTGT = (int)hoadon.THUE;
                                            ctdongnuoc.PhiBVMT = (int)hoadon.PHI;
                                            ctdongnuoc.TongCong = (int)hoadon.TONGCONG;
                                            ctdongnuoc.CreateBy = CNguoiDung.MaND;
                                            ctdongnuoc.CreateDate = DateTime.Now;

                                            dongnuoc.TT_CTDongNuocs.Add(ctdongnuoc);

                                            _cDongNuoc.SuaDN(dongnuoc);
                                        }
                                        //thêm hóa đơn mới vào lệnh hủy
                                        if (_cLenhHuy.CheckExist_Ton(hoadon.DANHBA, NamTemp, KyTemp) == true)
                                        {
                                            TT_LenhHuy lenhhuy = new TT_LenhHuy();
                                            lenhhuy.MaHD = _cHoaDon.Get(hoadon.DANHBA, hoadon.NAM.Value, hoadon.KY).ID_HOADON;
                                            lenhhuy.SoHoaDon = hoadon.SOHOADON;
                                            lenhhuy.DanhBo = hoadon.DANHBA;
                                            TT_LenhHuy lhMoiNhat = _cLenhHuy.getMoiNhat(hoadon.DANHBA);
                                            if (lhMoiNhat != null)
                                            {
                                                lenhhuy.TinhTrang = lhMoiNhat.TinhTrang;
                                                lenhhuy.Cat = lhMoiNhat.Cat;
                                            }
                                            _cLenhHuy.Them(lenhhuy);
                                        }
                                    }

                                    //check hóa đơn chờ điều chỉnh
                                    if (_cDCHD.checkExist_HDChoDC(hoadon.DANHBA, hoadon.NAM.Value, hoadon.KY) == true)
                                    {
                                        DIEUCHINH_HD dchd = new DIEUCHINH_HD();
                                        dchd.FK_HOADON = _cHoaDon.Get(hoadon.DANHBA, hoadon.NAM.Value, hoadon.KY).ID_HOADON;
                                        dchd.SoHoaDon = hoadon.SOHOADON;
                                        dchd.GiaBieu = hoadon.GB;
                                        if (hoadon.DM != null)
                                            dchd.DinhMuc = (int)hoadon.DM;
                                        dchd.TIEUTHU_BD = (int)hoadon.TIEUTHU;
                                        dchd.GIABAN_BD = hoadon.GIABAN;
                                        dchd.PHI_BD = hoadon.PHI;
                                        dchd.THUE_BD = hoadon.THUE;
                                        dchd.TONGCONG_BD = hoadon.TONGCONG;
                                        dchd.NGAY_DC = DateTime.Now;

                                        if (_cDCHD.Them(dchd))
                                        {
                                            _cDCHD.Xoa_HDChoDC(_cDCHD.get_HDChoDC(hoadon.DANHBA, hoadon.NAM.Value, hoadon.KY));
                                        }
                                    }
                                }
                            }
                            ///Nếu đã có hóa đơn
                            else
                            {
                                HOADON hoadonCN = _cHoaDon.Get(hoadon.DANHBA, hoadon.NAM.Value, hoadon.KY, hoadon.DOT.Value);
                                Copy(ref hoadonCN, hoadon);
                                _cHoaDon.Sua(hoadonCN);
                            }
                        }

                        try
                        {
                            _cHoaDon.ExecuteNonQuery("if not exists (select * from Temp_Insert_HoaDon where Nam=" + Nam + " and Ky=" + Ky + " and Dot=" + Dot + ") insert into Temp_Insert_HoaDon(Nam,Ky,Dot)values(" + Nam + "," + Ky + "," + Dot + ")");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi Temp_Insert_HoaDon\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        try
                        {
                            _cHoaDon.ExecuteNonQuery("exec spUpdateHoaDonFromDHN " + Dot + "," + Ky + "," + Nam);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi spUpdateHoaDonFromDHN\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        try
                        {
                            //string lineR_Test = lines[0].Replace("\",\"", "$").Replace("\"", "");
                            //string[] contents_Test = lineR_Test.Split('$');
                            //int Nam = int.Parse("20" + contents_Test[19]);
                            //int Ky = int.Parse(contents_Test[18]);
                            //int Dot = int.Parse(contents_Test[1]);

                            //string sql = "update HOADON set Quan=DLKH.QUAN,Phuong=DLKH.PHUONG,CoDH=DLKH.CODH,MaDMA=DLKH.MADMA from DLKH where HOADON.DANHBA=DLKH.DANHBO and HOADON.NAM=" + Nam + " and HOADON.KY=" + Ky + " and HOADON.DOT=" + Dot;
                            //_cHoaDon.LinQ_ExecuteNonQuery(sql);
                            //string sql_Huy = "update HOADON set Quan=DLKH_HUY.QUAN,Phuong=DLKH_HUY.PHUONG,CoDH=DLKH_HUY.CODH,MaDMA=DLKH_HUY.MADMA from DLKH_HUY where HOADON.DANHBA=DLKH_HUY.DANHBO and HOADON.NAM=" + Nam + " and HOADON.KY=" + Ky + " and HOADON.DOT=" + Dot;
                            //_cHoaDon.LinQ_ExecuteNonQuery(sql_Huy);

                            if (Dot == 20)
                            {
                                CGiaBanBinhQuan _cGBBQ = new CGiaBanBinhQuan();
                                DataTable dt = _cHoaDon.GetGiaBanBinhQuan(Nam, Ky);
                                if (!_cGBBQ.CheckExist(Nam, Ky))
                                {
                                    TT_GiaBanBinhQuan entity = new TT_GiaBanBinhQuan();
                                    entity.Nam = Nam;
                                    entity.Ky = Ky;
                                    entity.TongGiaBan = decimal.Parse(dt.Rows[0]["TongGiaBan"].ToString());
                                    entity.TongTieuThu = decimal.Parse(dt.Rows[0]["TongTieuThu"].ToString());
                                    entity.GiaBanBinhQuan = float.Parse(dt.Rows[0]["GiaBanBinhQuan"].ToString());

                                    _cGBBQ.Them(entity);
                                }
                                else
                                    if (MessageBox.Show("Đã chốt Giá Bán Bình Quân, Bạn có chắc chốt lại không???", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                    {
                                        TT_GiaBanBinhQuan entity = _cGBBQ.Get(Nam, Ky);
                                        entity.TongGiaBan = decimal.Parse(dt.Rows[0]["TongGiaBan"].ToString());
                                        entity.TongTieuThu = decimal.Parse(dt.Rows[0]["TongTieuThu"].ToString());
                                        entity.GiaBanBinhQuan = float.Parse(dt.Rows[0]["GiaBanBinhQuan"].ToString());

                                        _cGBBQ.Sua(entity);
                                    }
                            }
                            _cHoaDon.ExecuteNonQuery("exec spUpdateHoaDonFromDHN " + Dot + "," + Ky + "," + Nam);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi Tính Giá Bình Quân\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (cmbKy.SelectedIndex != -1)
            {
                //var startTime = System.Diagnostics.Stopwatch.StartNew();
                dgvHoaDon.DataSource = _cHoaDon.GetTongByNamKy(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                //startTime.Stop();
                //MessageBox.Show(startTime.ElapsedMilliseconds.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //for (int i = 0; i < dgvHoaDon.Rows.Count; i++)
                //{
                //    DataTable dtDCHD = _cDCHD.GetTongChuanThu(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), i);
                //    if (dtDCHD != null && dtDCHD.Rows.Count > 0)
                //    {
                //        dgvHoaDon["TongGiaBan", i].Value = long.Parse(dgvHoaDon["TongGiaBan", i].Value.ToString()) - long.Parse(dtDCHD.Rows[0]["GIABAN_End"].ToString()) + long.Parse(dtDCHD.Rows[0]["GIABAN_BD"].ToString());
                //        dgvHoaDon["TongThueGTGT", i].Value = long.Parse(dgvHoaDon["TongThueGTGT", i].Value.ToString()) - long.Parse(dtDCHD.Rows[0]["ThueGTGT_End"].ToString()) + long.Parse(dtDCHD.Rows[0]["ThueGTGT_BD"].ToString());
                //        dgvHoaDon["TongPhiBVMT", i].Value = long.Parse(dgvHoaDon["TongPhiBVMT", i].Value.ToString()) - long.Parse(dtDCHD.Rows[0]["PhiBVMT_End"].ToString()) + long.Parse(dtDCHD.Rows[0]["PhiBVMT_BD"].ToString());
                //        dgvHoaDon["TongCong", i].Value = long.Parse(dgvHoaDon["TongCong", i].Value.ToString()) - long.Parse(dtDCHD.Rows[0]["TONGCONG_End"].ToString()) + long.Parse(dtDCHD.Rows[0]["TONGCONG_BD"].ToString());
                //    }
                //}

                int TongHD = 0;
                int TongTieuThu = 0;
                long TongGiaBan = 0;
                long TongThueGTGT = 0;
                long TongPhiBVMT = 0;
                long TongCong = 0;
                int TongHD0 = 0;
                foreach (DataGridViewRow item in dgvHoaDon.Rows)
                {
                    DataTable dtDCHD = _cDCHD.GetTongChuanThu(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(item.Cells["Dot"].Value.ToString()));
                    if (dtDCHD != null && dtDCHD.Rows.Count > 0)
                    {
                        item.Cells["TongGiaBan"].Value = long.Parse(item.Cells["TongGiaBan"].Value.ToString()) - long.Parse(dtDCHD.Rows[0]["GIABAN_DC"].ToString());
                        item.Cells["TongThueGTGT"].Value = long.Parse(item.Cells["TongThueGTGT"].Value.ToString()) - long.Parse(dtDCHD.Rows[0]["ThueGTGT_DC"].ToString());
                        item.Cells["TongPhiBVMT"].Value = long.Parse(item.Cells["TongPhiBVMT"].Value.ToString()) - long.Parse(dtDCHD.Rows[0]["PhiBVMT_DC"].ToString());
                        item.Cells["TongCong"].Value = long.Parse(item.Cells["TongCong"].Value.ToString()) - long.Parse(dtDCHD.Rows[0]["TONGCONG_DC"].ToString());
                    }

                    TongHD += int.Parse(item.Cells["TongHD"].Value.ToString());
                    TongTieuThu += int.Parse(item.Cells["TongTieuThu"].Value.ToString());
                    TongGiaBan += long.Parse(item.Cells["TongGiaBan"].Value.ToString());
                    TongThueGTGT += long.Parse(item.Cells["TongThueGTGT"].Value.ToString());
                    TongPhiBVMT += long.Parse(item.Cells["TongPhiBVMT"].Value.ToString());
                    TongCong += long.Parse(item.Cells["TongCong"].Value.ToString());
                    TongHD0 += int.Parse(item.Cells["HD0"].Value.ToString());
                }
                txtTongHD.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHD);
                txtTongTieuThu.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongTieuThu);
                txtTongGiaBan.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBan);
                txtTongThueGTGT.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongThueGTGT);
                txtTongPhiBVMT.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongPhiBVMT);
                txtTongCong.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
                txtTongHD0.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHD0);
            }
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongHD" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongTieuThu" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongGiaBan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongThueGTGT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongPhiBVMT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void txtDuongDan_TextChanged(object sender, EventArgs e)
        {

        }

        private void Copy(ref HOADON hoadonCu, HOADON hoadonMoi)
        {
            hoadonCu.DOT = hoadonMoi.DOT;
            hoadonCu.DANHBA = hoadonMoi.DANHBA;
            hoadonCu.HOPDONG = hoadonMoi.HOPDONG;
            hoadonCu.TENKH = hoadonMoi.TENKH;
            hoadonCu.SO = hoadonMoi.SO;
            hoadonCu.DUONG = hoadonMoi.DUONG;
            hoadonCu.GB = hoadonMoi.GB;
            hoadonCu.TILESH = hoadonMoi.TILESH;
            hoadonCu.TILEHCSN = hoadonMoi.TILEHCSN;
            hoadonCu.TILESX = hoadonMoi.TILESX;
            hoadonCu.TILEDV = hoadonMoi.TILEDV;
            hoadonCu.DM = hoadonMoi.DM;
            hoadonCu.KY = hoadonMoi.KY;
            hoadonCu.NAM = hoadonMoi.NAM;
            hoadonCu.CODE = hoadonMoi.CODE;
            hoadonCu.CSCU = hoadonMoi.CSCU;
            hoadonCu.CSMOI = hoadonMoi.CSMOI;
            hoadonCu.TUNGAY = hoadonMoi.TUNGAY;
            hoadonCu.DENNGAY = hoadonMoi.DENNGAY;
            hoadonCu.SONGAY = hoadonMoi.SONGAY;
            hoadonCu.TIEUTHU = hoadonMoi.TIEUTHU;
            hoadonCu.TIEUTHUBU = hoadonMoi.TIEUTHUBU;
            hoadonCu.TIEUTHUSH = hoadonMoi.TIEUTHUSH;
            hoadonCu.TIEUTHUHCSN = hoadonMoi.TIEUTHUHCSN;
            hoadonCu.TIEUTHUSX = hoadonMoi.TIEUTHUSX;
            hoadonCu.TIEUTHUDV = hoadonMoi.TIEUTHUDV;
            hoadonCu.MAY = hoadonMoi.MAY;
            hoadonCu.STT = hoadonMoi.STT;
            hoadonCu.GIABAN = hoadonMoi.GIABAN;
            hoadonCu.THUE = hoadonMoi.THUE;
            hoadonCu.PHI = hoadonMoi.PHI;
            hoadonCu.TONGCONG = hoadonMoi.TONGCONG;
            hoadonCu.GIABAN_BU = hoadonMoi.GIABAN_BU;
            hoadonCu.THUE_BU = hoadonMoi.THUE_BU;
            hoadonCu.PHI_BU = hoadonMoi.PHI_BU;
            hoadonCu.TONGCONG_BU = hoadonMoi.TONGCONG_BU;
            hoadonCu.SOPHATHANH = hoadonMoi.SOPHATHANH;
            hoadonCu.SOHOADON = hoadonMoi.SOHOADON;
            hoadonCu.Quan = hoadonMoi.Quan;
            hoadonCu.Phuong = hoadonMoi.Phuong;
            hoadonCu.MST = hoadonMoi.MST;
            hoadonCu.MALOTRINH = hoadonMoi.MALOTRINH;
        }

        private void btnSoSanhKyTruoc_Click(object sender, EventArgs e)
        {
            if (cmbKy.SelectedIndex != -1)
            {
                int Nam, NamTruoc, Ky, KyTruoc;
                Nam = int.Parse(cmbNam.SelectedValue.ToString());
                Ky = int.Parse(cmbKy.SelectedItem.ToString());
                if (Ky == 1)
                {
                    NamTruoc = int.Parse(cmbNam.SelectedValue.ToString()) - 1;
                    KyTruoc = 12;
                }
                else
                {
                    NamTruoc = Nam;
                    KyTruoc = Ky - 1;
                }
                DataTable dt = _cHoaDon.GetTongByNamKy(Nam, Ky);
                DataTable dtDCHD = _cDCHD.GetTongChuanThu(Nam, Ky);
                if (dtDCHD != null && dtDCHD.Rows.Count > 0)
                {
                    dt.Rows[0]["TongGiaBan"] = long.Parse(dt.Rows[0]["TongGiaBan"].ToString()) - long.Parse(dtDCHD.Rows[0]["GIABAN_DC"].ToString());
                    dt.Rows[0]["TongThueGTGT"] = long.Parse(dt.Rows[0]["TongThueGTGT"].ToString()) - long.Parse(dtDCHD.Rows[0]["ThueGTGT_DC"].ToString());
                    dt.Rows[0]["TongPhiBVMT"] = long.Parse(dt.Rows[0]["TongPhiBVMT"].ToString()) - long.Parse(dtDCHD.Rows[0]["PhiBVMT_DC"].ToString());
                    dt.Rows[0]["TongCong"] = long.Parse(dt.Rows[0]["TongCong"].ToString()) - long.Parse(dtDCHD.Rows[0]["TONGCONG_DC"].ToString());
                }
                DataTable dtTruoc = _cHoaDon.GetTongByNamKy(NamTruoc, KyTruoc);
                dtDCHD = _cDCHD.GetTongChuanThu(NamTruoc, KyTruoc);
                if (dtDCHD != null && dtDCHD.Rows.Count > 0)
                {
                    dtTruoc.Rows[0]["TongGiaBan"] = long.Parse(dtTruoc.Rows[0]["TongGiaBan"].ToString()) - long.Parse(dtDCHD.Rows[0]["GIABAN_DC"].ToString());
                    dtTruoc.Rows[0]["TongThueGTGT"] = long.Parse(dtTruoc.Rows[0]["TongThueGTGT"].ToString()) - long.Parse(dtDCHD.Rows[0]["ThueGTGT_DC"].ToString());
                    dtTruoc.Rows[0]["TongPhiBVMT"] = long.Parse(dtTruoc.Rows[0]["TongPhiBVMT"].ToString()) - long.Parse(dtDCHD.Rows[0]["PhiBVMT_DC"].ToString());
                    dtTruoc.Rows[0]["TongCong"] = long.Parse(dtTruoc.Rows[0]["TongCong"].ToString()) - long.Parse(dtDCHD.Rows[0]["TONGCONG_DC"].ToString());
                }
                dsBaoCao ds = new dsBaoCao();
                for (int i = 0; i < dtTruoc.Rows.Count; i++)
                {
                    DataRow dr = ds.Tables["PhanTichDoanhThu"].NewRow();
                    dr["LoaiBaoCao"] = "Đợt";
                    dr["Ky"] = cmbKy.SelectedItem.ToString();
                    dr["Nam"] = cmbNam.SelectedValue.ToString();
                    dr["Loai"] = dtTruoc.Rows[i]["Dot"].ToString();
                    dr["ChuKyTruoc"] = dtTruoc.Rows[i]["SoNgay"].ToString();
                    dr["TongHDTruoc"] = dtTruoc.Rows[i]["TongHD"].ToString();
                    dr["TongTieuThuTruoc"] = dtTruoc.Rows[i]["TongTieuThu"].ToString();
                    dr["TongCongTruoc"] = dtTruoc.Rows[i]["TongGiaBan"].ToString();
                    if (dt.Rows.Count - 1 >= i)
                    {
                        dr["ChuKy"] = dt.Rows[i]["SoNgay"].ToString();
                        dr["TongHD"] = dt.Rows[i]["TongHD"].ToString();
                        dr["TongTieuThu"] = dt.Rows[i]["TongTieuThu"].ToString();
                        dr["TongCong"] = dt.Rows[i]["TongGiaBan"].ToString();
                    }

                    ds.Tables["PhanTichDoanhThu"].Rows.Add(dr);
                }
                rptPhanTichBienDongHoaDon rpt = new rptPhanTichBienDongHoaDon();
                rpt.SetDataSource(ds);
                frmBaoCao frm = new frmBaoCao(rpt);
                frm.Show();
            }
        }

        private void btnXem_TyLeTon_Click(object sender, EventArgs e)
        {
            dgvTyLeTon.DataSource = _cHoaDon.GetBaoCaoTyLeTon(int.Parse(cmbNam.SelectedValue.ToString()));

            int TongHD = 0;
            long TongGiaBan = 0;
            int TongHDTon = 0;
            long TongGiaBanTon = 0;

            foreach (DataGridViewRow item in dgvTyLeTon.Rows)
            {
                DataTable dtDCHD = _cDCHD.GetTongChuanThu(int.Parse(cmbNam_TyLeTon.SelectedValue.ToString()), int.Parse(item.Cells["Ky_TyLeTon"].Value.ToString()));
                if (dtDCHD != null && dtDCHD.Rows.Count > 0)
                {
                    item.Cells["TongGiaBan_TyLeTon"].Value = long.Parse(item.Cells["TongGiaBan_TyLeTon"].Value.ToString()) - long.Parse(dtDCHD.Rows[0]["GIABAN_DC"].ToString());
                }

                DataTable dtDCHDTon = _cDCHD.GetTongChuanThuTon(int.Parse(cmbNam_TyLeTon.SelectedValue.ToString()), int.Parse(item.Cells["Ky_TyLeTon"].Value.ToString()));
                if (dtDCHDTon != null && dtDCHDTon.Rows.Count > 0)
                {
                    item.Cells["TongGiaBanTon_TyLeTon"].Value = long.Parse(item.Cells["TongGiaBanTon_TyLeTon"].Value.ToString()) - long.Parse(dtDCHD.Rows[0]["GIABAN_DC"].ToString());
                }

                item.Cells["TyLeTongHDTon_TyLeTon"].Value = Math.Round(double.Parse(item.Cells["TongHDTon_TyLeTon"].Value.ToString()) / double.Parse(item.Cells["TongHD_TyLeTon"].Value.ToString()) * 100, 2);
                item.Cells["TyLeGiaBanTon_TyLeTon"].Value = Math.Round(double.Parse(item.Cells["TongGiaBanTon_TyLeTon"].Value.ToString()) / double.Parse(item.Cells["TongGiaBan_TyLeTon"].Value.ToString()) * 100, 2);

                TongHD += int.Parse(item.Cells["TongHD_TyLeTon"].Value.ToString());
                TongGiaBan += long.Parse(item.Cells["TongGiaBan_TyLeTon"].Value.ToString());
                TongHDTon += int.Parse(item.Cells["TongHDTon_TyLeTon"].Value.ToString());
                TongGiaBanTon += long.Parse(item.Cells["TongGiaBanTon_TyLeTon"].Value.ToString());
            }

            txtTongHD_TyLeTon.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHD);
            txtTongGiaBan_TyLeTon.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBan);
            txtTongHDTon_TyLeTon.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHDTon);
            txtTongGiaBanTon_TyLeTon.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBanTon);
            txtTyLeTongHDTon.Text = Math.Round((double)TongHDTon / (double)TongHD * 100, 2).ToString();
            txtTyLeGiaBanTon.Text = Math.Round((double)TongGiaBanTon / (double)TongGiaBan * 100, 2).ToString();
        }

        private void dgvTyLeTon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTyLeTon.Columns[e.ColumnIndex].Name == "TongHD_TyLeTon" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTyLeTon.Columns[e.ColumnIndex].Name == "TongGiaBan_TyLeTon" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTyLeTon.Columns[e.ColumnIndex].Name == "TongHDTon_TyLeTon" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvTyLeTon.Columns[e.ColumnIndex].Name == "TongGiaBanTon_TyLeTon" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen("mnuDangNganChuyenKhoan", "Them"))
                {
                    if (dgvHoaDon.Columns[e.ColumnIndex].Name == "DangNganHD0")
                    {
                        if (MessageBox.Show("Bạn có chắc chắn Đăng Ngân HĐ=0 Đợt " + cmbKy.SelectedItem.ToString() + " Kỳ " + dgvHoaDon["Dot", e.RowIndex].Value.ToString() + "?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            DataTable dt = _cHoaDon.getDSHoaDon0_Ton(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()), int.Parse(dgvHoaDon["Dot", e.RowIndex].Value.ToString()));
                            foreach (DataRow item in dt.Rows)
                            {
                                _cHoaDon.DangNgan("ChuyenKhoan", item["SoHoaDon"].ToString(), _cNguoiDung.getChuyenKhoan().MaND);
                            }
                            MessageBox.Show("Xử Lý Hoàn Tất, Vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Đăng Ngân Chuyển Khoản Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
