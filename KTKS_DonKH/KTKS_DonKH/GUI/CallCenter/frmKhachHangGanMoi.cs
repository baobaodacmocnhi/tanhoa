using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.CallCenter;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.GUI.TruyThu;

namespace KTKS_DonKH.GUI.CallCenter
{
    public partial class frmKhachHangGanMoi : Form
    {
        string _mnu = "mnuKhachHangGanMoi";
        string title = "";
        string noidungtrongai = "";
        int currentPageIndex = 1;
        int pageSize = 10000;
        int pageNumber = 0;
        int FirstRow=0;
        int rows;


        public frmKhachHangGanMoi()
        {
            InitializeComponent();
        }

        private void Search(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                search();
            }
        }
        private void PageTotal()
        {
            try
            {
                pageNumber = rows % pageSize != 0 ? rows / pageSize + 1 : rows / pageSize;
                lbPaing.Text = currentPageIndex + "/" + pageNumber;
            }
            catch (Exception)
            {
            }

        }

        public void refesh()
        {
            this.SearchMaHoSo.Text = "";
            this.searchHoTenKH.Text = "";
            this.searchDiaChi.Text = "";
            this.searchDienThoai.Text = "";
            this.SearchMaHoSo.Focus();
            DataTable table = DAL.CallCenter.CGanMoi.TimBienNhan("13", "", "", 0, 0, "");
            this.dataGridView1.DataSource = table;
            clearText();
            this.groupBox1.Visible = false;
        }

        void clearText()
        {

            NgayTrinhKyGD.Text = "";
            SoDoVienTK.Text = "";
            NgayTraHoSoKH.Text = "";
            txtNgayGiaoTTK.Text = "";
            txtNgayNhanHS.Text = "";
            txtLoaiHS.Text = "";
            DotNhanDon.Text = "";
            txtNgayGiaoSDV.Text = "";
            SoTienDong.Text = "";
            NgayHoanTat.Text = "";
            DotXinPhepDD.Text = "";
            NgayXinPhepDD.Text = "";
            NgayCoPhep.Text = "";
            NgayLapBG.Text = "";
            DotThiCong.Text = "";
            NgayThiCong.Text = "";
            NgayHoanCong.Text = "";
            NgayLenDotTC.Text = "";
            NgayLenDotNhanDon.Text = "";
            txtDomViTC.Text = "";
            txtNgayDongTien.Text = "";
            txtNgayChuyenTC.Text = "";
            txtTapThe.Text = "";
            txtTuNgay.Text = "";
            txtDenNgay.Text = "";
            //ChoDanhBo.Text = "";
            txtGhiChu.Text = "";


            //this.txtNgayNhanHS.Text = "";
            //this.txtLoaiHS.Text = "";
            //this.txtNgayNhanHS.Text = "";
            //this.txtLoaiHS.Text = "";
            //this.DotNhanDon.Text = "";
            //this.NgayLenDotNhanDon.Text = "";
            //this.txtNgayGiaoTTK.Text = "";
            //this.SoDoVienTK.Text = "";
            //this.txtNgayGiaoSDV.Text = "";
            //this.txtDomViTC.Text = "";
            //this.txtNgayChuyenTC.Text = "";
            //NgayLapBG.Text = "";
            //SoTienDong.Text = "";
            //NgayTrinhKyGD.Text = "";
            //NgayHoanTat.Text = "";
            //NgayTraHoSoKH.Text = "";
            //DotXinPhepDD.Text = "";
            //NgayXinPhepDD.Text = "";
            //NgayCoPhep.Text = "";
            //DotThiCong.Text = "";
            //NgayLenDotTC.Text = "";
            //NgayThiCong.Text = "";
            //NgayHoanCong.Text = "";
            //ChoDanhBo.Text = "";
            title = "";
            noidungtrongai = "";
            this.resultNoiDung.Text = "";
        }
        public void formatRows(DataGridView dview)
        {
            for (int i = 0; i < dview.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    dview.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(217))))); ;

                }
                else
                {
                    dview.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                }
            }
        }
        void search()
        {
            groupBox1.Text = "Kết Quả ";
            try
            {
                rows = DAL.CallCenter.CGanMoi.TotalTimDonKH(this.SearchMaHoSo.Text, this.searchHoTenKH.Text, this.searchDiaChi.Text, this.searchDienThoai.Text);
            }
            catch (Exception)
            {
            }
            PageTotal();

            DataTable table = DAL.CallCenter.CGanMoi.TimDonKH(this.SearchMaHoSo.Text, this.searchHoTenKH.Text, this.searchDiaChi.Text, FirstRow, pageSize, this.searchDienThoai.Text);
            this.dataGridView1.DataSource = table;
            lbsohoso.Text = "Tổng Số Có " + rows + " Hồ Sơ.";
            formatRows(dataGridView1);
            if (table.Rows.Count <= 0)
            {

                try
                {
                    rows = DAL.CallCenter.CGanMoi.TotalRecord(this.SearchMaHoSo.Text, this.searchHoTenKH.Text, this.searchDiaChi.Text, this.searchDienThoai.Text);
                }
                catch (Exception)
                {
                }
                PageTotal();

                table = DAL.CallCenter.CGanMoi.TimBienNhan(this.SearchMaHoSo.Text, this.searchHoTenKH.Text, this.searchDiaChi.Text, FirstRow, pageSize, this.searchDienThoai.Text);
                this.dataGridView1.DataSource = table;
                lbsohoso.Text = "Tổng Số Có " + rows + " Hồ Sơ.";
                formatRows(dataGridView1);
                if (table.Rows.Count <= 0)
                {
                    MessageBox.Show(this, "Không Tìm Thấy Thông Tin Khách Hàng !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refesh();
                }
                else
                {
                    title = "HỒ SƠ CHƯA LÊN ĐỢT <br/> NHẬN ĐƠN";
                }


            }
            else if (table.Rows.Count == 1)
            {
                try
                {
                    clearText();
                    this.txtNgayNhanHS.Text = dataGridView1.Rows[0].Cells["NGAYNHAN"].Value + "";
                    this.txtLoaiHS.Text = dataGridView1.Rows[0].Cells["LOAIHS"].Value + "";
                    this.txtNgayNhanHS.Text = dataGridView1.Rows[0].Cells["NGAYNHAN"].Value + "";
                    this.txtLoaiHS.Text = dataGridView1.Rows[0].Cells["LOAIHS"].Value + "";
                    DON_KHACHHANG donkh = DAL.CallCenter.CGanMoi.searchTimKiemDon(dataGridView1.Rows[0].Cells["g_SoHoSo"].Value + "");
                    Result(donkh);

                }
                catch (Exception)
                {
                }
            }

            groupBox1.Visible = true;
            if (title.Contains("HỒ SƠ TRỞ NGẠI"))
            {
                this.lbresult.ForeColor = Color.Red;
                this.lbresult.Text = title;
                this.resultNoiDung.Text = noidungtrongai;
            }
            else
            {
                this.lbresult.ForeColor = Color.Blue;
                this.lbresult.Text = title;
            }
        }
        string shs = "";
        #region Result
        void Result(DON_KHACHHANG donkh)
        {
            if (donkh != null)
            {
                shs = donkh.SHS;

                this.txtNgayDongTien.Text = donkh.NGAYDONGTIEN != null ? Utilities.DateToString.NgayVNVN(donkh.NGAYDONGTIEN.Value) : "";
                SoTienDong.Text = String.Format("{0:0,0}", donkh.SOTIEN != null ? donkh.SOTIEN : 0.0).Replace(",",".");
                this.DotNhanDon.Text = donkh.MADOT;
                this.NgayLenDotNhanDon.Text = Utilities.DateToString.NgayVNVN(donkh.CREATEDATE.Value);
                //if (donkh.HOSOCHA != null)
                //{
                   // donkh = DAL.C_DonKhachHang.searchTimKiemDon(donkh.HOSOCHA);
                    txtTapThe.Text = donkh.HOSOCHA;
                //}
                    this.txtGhiChu.Text = donkh.GHICHU;

                if (donkh.NGAYCHUYEN_HOSO != null)
                {
                    this.txtNgayGiaoTTK.Text = Utilities.DateToString.NgayVNVN(donkh.NGAYCHUYEN_HOSO.Value);
                    TOTHIETKE ttk = DAL.CallCenter.CGanMoi.findBySHS(donkh.SHS);
                    if (ttk != null)
                    {
                        if (ttk.SODOVIEN != null)
                        {
                            this.SoDoVienTK.Text = DAL.CallCenter.CGanMoi.findByUserName(ttk.SODOVIEN).FULLNAME;
                            this.txtNgayGiaoSDV.Text = ttk.NGAYGIAOSDV != null ? Utilities.DateToString.NgayVNVN(ttk.NGAYGIAOSDV.Value) : "";
                            NgayTrinhKyGD.Text = ttk.NGAYTKGD != null ? Utilities.DateToString.NgayVNVN(ttk.NGAYTKGD.Value) : "";
                            NgayHoanTat.Text = ttk.NGAYHOANTATTK != null ? Utilities.DateToString.NgayVNVN(ttk.NGAYHOANTATTK.Value) : "";
                            NgayTraHoSoKH.Text = ttk.NGAYTRAHS != null ? Utilities.DateToString.NgayVNVN(ttk.NGAYTRAHS.Value) : "";


                            if (ttk.TRONGAITHIETKE == true)
                            {
                                title = "HỒ SƠ TRỞ NGẠI THIẾT KẾ";
                                noidungtrongai = ttk.NOIDUNGTRONGAI;
                                NgayHoanTat.Text = ttk.NGAYHOANTATTK != null ? Utilities.DateToString.NgayVNVN(ttk.NGAYHOANTATTK.Value) : "";
                                NgayTraHoSoKH.Text = ttk.NGAYTRAHS != null ? Utilities.DateToString.NgayVNVN(ttk.NGAYTRAHS.Value) : "";
                            }
                            else
                            {

                                BG_KHOILUONGXDCB xdcb = DAL.CallCenter.CGanMoi.findBySHSXDCB(donkh.SHS);

                                if (xdcb != null)
                                {
                                    NgayLapBG.Text = xdcb.CREATEDATE != null ? Utilities.DateToString.NgayVNVN(xdcb.CREATEDATE.Value) : "";
                                  //  SoTienDong.Text = String.Format("{0:0,0.00}", xdcb.TONGIATRI != null ? xdcb.TONGIATRI : 0.0);
                                    SoTienDong.Text = String.Format("{0:0,0}", xdcb.TONGIATRI != null ? xdcb.TONGIATRI : 0.0).Replace(",", ".");
                                                                      
                                    if (ttk.NGAYCHUYENHS != null)
                                    {
                                        KH_HOSOKHACHHANG hoskh = DAL.CallCenter.CGanMoi.findBySHSKH(donkh.SHS);
                                        if (hoskh != null)
                                        {
                                            if (hoskh.MADOTDD != null)
                                            {
                                                KH_XINPHEPDAODUONG xiphep = DAL.CallCenter.CGanMoi.finbyMaDot(hoskh.MADOTDD);
                                                DotXinPhepDD.Text = xiphep.MAQUANLY;
                                                NgayXinPhepDD.Text = xiphep.NGAYLAP.Value!= null ? Utilities.DateToString.NgayVNVN(xiphep.NGAYLAP.Value):"";
                                                NgayCoPhep.Text = xiphep.NGAYCOPHEP != null ? Utilities.DateToString.NgayVNVN(xiphep.NGAYCOPHEP.Value) : "";
                                                title = "HỒ SƠ ĐÃ LÊN ĐỢT XIN PHÉP <br/>  ĐÀO ĐƯỜNG";
                                            }
                                            else
                                            {
                                                title = "HỒ SƠ CHƯA LÊN ĐỢT XIN PHÉP <br/> ĐÀO ĐƯỜNG";
                                            }
                                            if (hoskh.MADOTTC != null)
                                            {

                                                try
                                                {
                                                    KH_DOTTHICONG dotc = DAL.CallCenter.CGanMoi.findByMadot(hoskh.MADOTTC);
                                                        DotThiCong.Text = dotc.MADOTTC;
                                                        NgayLenDotTC.Text =dotc.NGAYLAP.Value!= null ? Utilities.DateToString.NgayVNVN(dotc.NGAYLAP.Value):"";
                                                        txtDomViTC.Text = dotc.DONVITHICONG != null ? DAL.CallCenter.CGanMoi.findDVTCbyID(dotc.DONVITHICONG.Value).TENCONGTY : "";
                                                        txtNgayChuyenTC.Text = dotc.NGAYCHUYENTC.Value != null ? Utilities.DateToString.NgayVNVN(dotc.NGAYCHUYENTC.Value) : "";

                                                        txtTuNgay.Text = dotc.TCTUNGAY.Value != null ? Utilities.DateToString.NgayVNVN(dotc.TCTUNGAY.Value) : "";
                                                        txtDenNgay.Text = dotc.TCDENNGAY.Value != null ? Utilities.DateToString.NgayVNVN(dotc.TCDENNGAY.Value) : "";
                                                        
                                                }
                                                catch (Exception)
                                                {
                                                }
                                               

                                                NgayThiCong.Text = hoskh.NGAYTHICONG != null ? Utilities.DateToString.NgayVNVN(hoskh.NGAYTHICONG.Value) : "";
                                                NgayHoanCong.Text = hoskh.NGAYHOANCONG != null ? Utilities.DateToString.NgayVNVN(hoskh.NGAYHOANCONG.Value) : "";
                                                ChoDanhBo.Text = hoskh.DHN_NGAYCHOSODB != null ? Utilities.DateToString.NgayVNVN(hoskh.DHN_NGAYCHOSODB.Value) : "";
                                                sodanhbo.Text = hoskh.DHN_SODANHBO;

                                                if (hoskh.HOANCONG != true)
                                                {
                                                    title = "HỒ CHƯA HOÀN CÔNG.";
                                                }
                                                else if (hoskh.DHN_CHODB != true)
                                                {
                                                    title = "HỒ CHƯA CHO DANH BỘ.";
                                                }
                                                else
                                                {
                                                    if (CKhachHang.checkHoSogoc(hoskh.DHN_SODANHBO) == true)
                                                    {
                                                        title = "HỒ SƠ ĐÃ HOÀN TẤT";
                                                       
                                                    }
                                                    else
                                                    {
                                                        title = "HỒ SƠ CHƯA ĐƯỢC SCAN ";
                                                    }

                                                   

                                                }
                                                
                                                title = "HỒ SƠ ĐÃ LÊN ĐỢT <br/> THI CÔNG";
                                            }
                                            NgayThiCong.Text = hoskh.NGAYTHICONG != null ? Utilities.DateToString.NgayVNVN(hoskh.NGAYTHICONG.Value) : "";
                                            if (hoskh.TRONGAI == true)
                                            {
                                                title = "HỒ SƠ TRỞ NGẠI THI CÔNG";
                                                noidungtrongai = hoskh.NOIDUNGTN;
                                            }
                                        }
                                        else
                                        {
                                            title = "HỒ SƠ CHƯA LÊN ĐỢT <br/> THI CÔNG";
                                        }

                                        if (hoskh.TRONGAI == true)
                                        {
                                            title = "HỒ SƠ TRỞ NGẠI THI CÔNG";
                                            noidungtrongai = hoskh.NOIDUNGTN;
                                        }
                                    }
                                    else
                                    {
                                        title = "HỒ SƠ CHƯA CHUYỂN <br/> KẾ HOẠCH";
                                    }
                                   
                                }
                                else
                                {
                                    KH_HOSOKHACHHANG hoskh = DAL.CallCenter.CGanMoi.findBySHSKH(donkh.SHS);
                                    if (hoskh != null)
                                    {
                                        if (hoskh.MADOTDD != null)
                                        {
                                            KH_XINPHEPDAODUONG xiphep = DAL.CallCenter.CGanMoi.finbyMaDot(hoskh.MADOTDD);
                                            DotXinPhepDD.Text = xiphep.MAQUANLY != null ? xiphep.MAQUANLY : "";
                                            NgayXinPhepDD.Text = xiphep.NGAYLAP.Value != null ? Utilities.DateToString.NgayVNVN(xiphep.NGAYLAP.Value) : "" ;
                                            NgayCoPhep.Text = xiphep.NGAYCOPHEP != null ? Utilities.DateToString.NgayVNVN(xiphep.NGAYCOPHEP.Value) : "";

                                        }
                                        else
                                        {
                                            title = "HỒ SƠ CHƯA LÊN ĐỢT <br/> ĐÀO ĐƯỜNG";
                                        }
                                        if (hoskh.MADOTTC != null)
                                        {
                                            try
                                            {
                                                KH_DOTTHICONG dotc = DAL.CallCenter.CGanMoi.findByMadot(hoskh.MADOTTC);
                                                if (dotc != null)
                                                {
                                                    DotThiCong.Text = dotc.MADOTTC;
                                                    NgayLenDotTC.Text = dotc.NGAYLAP.Value != null ? Utilities.DateToString.NgayVNVN(dotc.NGAYLAP.Value) : "";
                                                    txtDomViTC.Text = dotc.DONVITHICONG != null ? DAL.CallCenter.CGanMoi.findDVTCbyID(dotc.DONVITHICONG.Value).TENCONGTY : "";
                                                    txtNgayChuyenTC.Text = dotc.NGAYCHUYENTC.Value != null ? Utilities.DateToString.NgayVNVN(dotc.NGAYCHUYENTC.Value) : "";
                                                    txtTuNgay.Text = dotc.TCTUNGAY.Value != null ? Utilities.DateToString.NgayVNVN(dotc.TCTUNGAY.Value) : "";
                                                    txtDenNgay.Text = dotc.TCDENNGAY.Value != null ? Utilities.DateToString.NgayVNVN(dotc.TCDENNGAY.Value) : "";
                                                  
                                                }
                                            }
                                            catch (Exception)
                                            {


                                            }


                                            NgayThiCong.Text = hoskh.NGAYTHICONG != null ? Utilities.DateToString.NgayVNVN(hoskh.NGAYTHICONG.Value) : "";
                                            NgayHoanCong.Text = hoskh.NGAYHOANCONG != null ? Utilities.DateToString.NgayVNVN(hoskh.NGAYHOANCONG.Value) : "";
                                            ChoDanhBo.Text = hoskh.DHN_NGAYCHOSODB != null ? Utilities.DateToString.NgayVNVN(hoskh.DHN_NGAYCHOSODB.Value) : "";
                                            sodanhbo.Text = hoskh.DHN_SODANHBO;
                                            if (hoskh.HOANCONG != true)
                                            {
                                                title = "HỒ CHƯA HOÀN CÔNG.";
                                            }
                                            else if (hoskh.DHN_CHODB != true)
                                            {
                                                title = "HỒ CHƯA CHO DANH BỘ.";
                                            }
                                            else
                                            {
                                                if (DAL.CallCenter.CKhachHang.checkHoSogoc(hoskh.DHN_SODANHBO) == true)
                                                {
                                                    title = "HỒ SƠ ĐÃ HOÀN TẤT";

                                                }
                                                else
                                                {
                                                    title = "HỒ SƠ CHƯA ĐƯỢC SCAN ";
                                                }
                                            }
                                        }
                                        else
                                        {
                                            title = "HỒ SƠ CHƯA LÊN ĐỢT <br/> THI CÔNG";
                                            if (donkh.TRONGAITHIETKE == true)
                                            {
                                                title = "HỒ SƠ TRỞ NGẠI THI CÔNG";
                                                noidungtrongai = donkh.NOIDUNGTRONGAI;
                                            }

                                        }

                                        if (hoskh.TRONGAI == true)
                                        {
                                            title = "HỒ SƠ TRỞ NGẠI THI CÔNG";
                                            noidungtrongai = hoskh.NOIDUNGTN;
                                        }
                                        
                                    }
                                    else {

                                        if ("".Equals(NgayHoanTat.Text.Trim()))
                                        {
                                            title = "HỒ SƠ CHƯA CHẠY BẢNG GIÁ.";
                                        }
                                        else {
                                            title = "HỒ SƠ ĐÃ HOÀN TẤT THIẾT KẾ";
                                        }
                                        if (donkh.TRONGAITHIETKE == true)
                                        {
                                            title = "HỒ SƠ TRỞ NGẠI THI CÔNG";
                                            noidungtrongai = donkh.NOIDUNGTRONGAI;
                                        }
                                    }

                                }
                            }

                        }
                        else
                        {
                            title = "CHƯA GIAO HỒ SƠ <br/>CHO SƠ ĐỒ VIÊN";
                        }
                        if (DAL.CallCenter.CGanMoi.dontaixet(donkh.SOHOSO))
                        {
                            groupBox1.Text = "Kết Quả ----> ĐƠN TÁI XÉT";
                            lbTMP.Text = "Ghi Chú TX";
                            txtGhiChu.Text = DAL.CallCenter.CGanMoi.rTX;
                        }
                    }
                    else
                    {
                        title = "TỔ THIẾT KẾ KHÔNG NHẬN HỒ SƠ NÀY.";
                    }

                }
                else
                {
                    title = "HỒ SƠ CHƯA CHUYỂN <br/> TỔ THIẾT KẾ";
                }

            }
            else
            {
                title = "CHƯA LÊN ĐỢT NHẬN ĐƠN <br/> CHUYỂN TỔ THIẾT KẾ";
            }
            // TRƯỜNG HỢP ĐẶT BIỆT HỒ SƠ CHẠY BẢNG GIÁ MẪU
            if (donkh.TRONGAITHIETKE!=true || donkh.TRONGAITHIETKE !=null) {
                KH_HOSOKHACHHANG hoskh1 = DAL.CallCenter.CGanMoi.findBySHSKH(donkh.SHS);
                if (hoskh1 != null)
                {
                    if (hoskh1.MADOTDD != null)
                    {
                        KH_XINPHEPDAODUONG xiphep = DAL.CallCenter.CGanMoi.finbyMaDot(hoskh1.MADOTDD);
                        DotXinPhepDD.Text = xiphep.MAQUANLY;
                        NgayXinPhepDD.Text = Utilities.DateToString.NgayVNVN(xiphep.NGAYLAP.Value);
                        NgayCoPhep.Text = xiphep.NGAYCOPHEP != null ? Utilities.DateToString.NgayVNVN(xiphep.NGAYCOPHEP.Value) : "";
                    }
                    else
                    {
                        title = "HỒ SƠ CHƯA LÊN ĐỢT <br/> ĐÀO ĐƯỜNG";
                    }
                    if (hoskh1.MADOTTC != null)
                    {
                        try
                        {
                            KH_DOTTHICONG dotc = DAL.CallCenter.CGanMoi.findByMadot(hoskh1.MADOTTC);
                            if (dotc != null) {
                                DotThiCong.Text = dotc.MADOTTC;
                                NgayLenDotTC.Text = Utilities.DateToString.NgayVNVN(dotc.NGAYLAP.Value);
                                txtDomViTC.Text = DAL.CallCenter.CGanMoi.findDVTCbyID(dotc.DONVITHICONG.Value).TENCONGTY;
                                txtNgayChuyenTC.Text = Utilities.DateToString.NgayVNVN(dotc.NGAYCHUYENTC.Value);
                                txtTuNgay.Text = dotc.TCTUNGAY.Value != null ? Utilities.DateToString.NgayVNVN(dotc.TCTUNGAY.Value) : "";
                                txtDenNgay.Text = dotc.TCDENNGAY.Value != null ? Utilities.DateToString.NgayVNVN(dotc.TCDENNGAY.Value) : "";
                            }
                        }
                        catch (Exception)
                        {
                            
                           
                        }
                       
                        

                        NgayThiCong.Text = hoskh1.NGAYTHICONG != null ? Utilities.DateToString.NgayVNVN(hoskh1.NGAYTHICONG.Value) : "";
                        NgayHoanCong.Text = hoskh1.NGAYHOANCONG != null ? Utilities.DateToString.NgayVNVN(hoskh1.NGAYHOANCONG.Value) : "";
                        ChoDanhBo.Text = hoskh1.DHN_NGAYCHOSODB != null ? Utilities.DateToString.NgayVNVN(hoskh1.DHN_NGAYCHOSODB.Value) : "";

                        if (hoskh1.HOANCONG != true)
                        {
                            title = "HỒ CHƯA HOÀN CÔNG.";
                        }
                        else if (hoskh1.DHN_CHODB != true)
                        {
                            title = "HỒ CHƯA CHO DANH BỘ.";
                        }
                        else
                        {
                            if (DAL.CallCenter.CKhachHang.checkHoSogoc(hoskh1.DHN_SODANHBO) == true)
                            {
                                title = "HỒ SƠ ĐÃ HOÀN TẤT";

                            }
                            else
                            {
                                title = "HỒ SƠ CHƯA ĐƯỢC SCAN ";
                            }
                        }                       
                    }
                    else
                    {
                        title = "HỒ SƠ CHƯA LÊN ĐỢT <br/> THI CÔNG";
                    }
                    if (hoskh1.TRONGAI == true)
                    {
                        title = "HỒ SƠ TRỞ NGẠI THI CÔNG";
                        noidungtrongai = hoskh1.NOIDUNGTN;
                    }

                }
            }
        }
        #endregion

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                groupBox1.Text = "Kết Quả ";
                clearText();
                groupBox1.Visible = true;
                this.txtNgayNhanHS.Text = dataGridView1.Rows[e.RowIndex].Cells["NGAYNHAN"].Value + "";
                this.txtLoaiHS.Text = dataGridView1.Rows[e.RowIndex].Cells["LOAIHS"].Value + "";
                this.txtNgayNhanHS.Text = dataGridView1.Rows[e.RowIndex].Cells["NGAYNHAN"].Value + "";
                this.txtLoaiHS.Text = dataGridView1.Rows[e.RowIndex].Cells["LOAIHS"].Value + "";
                DON_KHACHHANG donkh = DAL.CallCenter.CGanMoi.searchTimKiemDon(dataGridView1.Rows[e.RowIndex].Cells["g_SoHoSo"].Value + "");
                Result(donkh);
                groupBox1.Visible = true;
                if (title.Contains("HỒ SƠ TRỞ NGẠI"))
                {
                    this.lbresult.ForeColor = Color.Red;
                    this.lbresult.Text = title;
                    this.resultNoiDung.Text = noidungtrongai;
                }
                else
                {
                    this.lbresult.ForeColor = Color.Blue;
                    this.lbresult.Text = title;
                    this.resultNoiDung.Text = donkh.SONHA_TTK;
                }
            }
            catch (Exception)
            {

            } 

        }

        private void btLamLai_Click(object sender, EventArgs e)
        {
            refesh();
        }

        private void btHoSoGoc_Click(object sender, EventArgs e)
        {
            if (CKhachHang.findByHoSoGoc(sodanhbo.Text.Replace("-", "")) != null)
            {
                frmPDFViewer F = new frmPDFViewer(CKhachHang.GetHoSoGoc(sodanhbo.Text.Replace("-", "")));
                F.ShowDialog();
            }
            else
            {
                MessageBox.Show(this, "Hồ sơ gốc chưa được cập nhật !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btTiepNhanKN_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                frmTiepNhanKN f = new frmTiepNhanKN(shs, "GM");
                f.ShowDialog();
            }
        }

        private void frmKhachHangGanMoi_Load(object sender, EventArgs e)
        {

        }

       

       
       


    }
}