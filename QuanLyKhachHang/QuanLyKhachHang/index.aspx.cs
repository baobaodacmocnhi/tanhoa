using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QuanLyKhachHang.Class;
using QuanLyKhachHang.DataBase;
using System.Drawing;
using System.IO;
using System.Data;
using System.ComponentModel;

namespace QuanLyKhachHang
{
    public partial class index1 : System.Web.UI.Page
    {
        TB_DULIEUKHACHHANG khachhang = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;
            if (IsPostBack)
                return;
            string danhbo = Request.QueryString["danhbo"];
            if (danhbo != null && danhbo.Length == 11)
                LoadThongTinDB(danhbo);
        }

        void LoadThongTinDB(string sodanhbo)
        {
            if (sodanhbo.Length == 11)
            {
                khachhang = C_DuLieuKhachHang.finByDanhBo(sodanhbo);
                Session["danhbo"] = sodanhbo;
                Session["db"] = C_KyThuat.getDataTable("SELECT * FROM DongHo where DBDONGHONUOC='" + sodanhbo + "'");
                if (khachhang != null)
                {
                    txtDB.Text = lbDanhBo.Text = khachhang.DANHBO;
                    sdt.Text = khachhang.DIENTHOAI;
                    hopdong.Text = khachhang.HOPDONG;
                    lotrinh.Text = khachhang.LOTRINH;
                    //DOT.Text = khachhang.LOTRINH.Substring(1, 2);
                    //HOPDONG.Text = khachhang.HOPDONG;
                    lbTenKh.Text = khachhang.HOTEN;
                    diachi.Text = khachhang.SONHA + ' ' + khachhang.TENDUONG;
                    //txtDienThoai.Text = khachhang.DIENTHOAI;
                    //QUAN.Text = khachhang.QUAN + "." + khachhang.PHUONG;
                    hieuluc.Text = String.Format("{0:00}", khachhang.KY) + "/" + khachhang.NAM;
                    giabieu.Text = khachhang.GIABIEU;
                    dinhmuc.Text = khachhang.DINHMUC;
                    try
                    {
                        ngaygan.Text = Format.NgayVNVN(khachhang.NGAYTHAY.Value);
                        ngaykiemdinh.Text = Format.NgayVNVN(khachhang.NGAYKIEMDINH.Value);
                    }
                    catch (Exception)
                    {

                    }

                    hieudhn.Text = khachhang.HIEUDH + "  - " + khachhang.CODH + "  - " + khachhang.SOTHANDH + " - " + khachhang.VITRIDHN;
                    //txtDMA.Text = khachhang.MADMA;
                    //txtApluc.Text = CKhachHang.getApLuc(khachhang.MADMA.Replace("TH-", ""));
                    nvds.Text = C_DuLieuKhachHang.getNVDS(khachhang.LOTRINH.Substring(2, 2));
                    nvtt.Text = C_DuLieuKhachHang.getNVThuTien(khachhang.DANHBO);
                    loadHoaDon(khachhang.DANHBO);
                    loadGhiChu(khachhang.DANHBO);
                    LoadHInh(khachhang.DANHBO);
                    LoadVideos(this.txtDB.Text);
                }
                else
                {
                    TB_DULIEUKHACHHANG_HUYDB khachhanghuy = C_DuLieuKhachHang.finByDanhBoHuy(sodanhbo);
                    if (khachhanghuy != null)
                    {
                        try
                        {
                            txtDB.Text = lbDanhBo.Text = khachhanghuy.DANHBO;
                            lotrinh.Text = khachhang.LOTRINH;
                            ////    DOT.Text = khachhanghuy.DOT;
                            //HOPDONG.Text = khachhanghuy.HOPDONG;
                            hopdong.Text = khachhanghuy.HOPDONG;
                            lbTenKh.Text = khachhang.HOTEN;
                            diachi.Text = khachhang.SONHA + ' ' + khachhang.TENDUONG;
                            //QUAN.Text = khachhanghuy.QUAN + "  " + khachhanghuy.PHUONG;
                            hieuluc.Text = "Hết HL " + khachhanghuy.HIEULUCHUY;
                            giabieu.Text = khachhanghuy.GIABIEU;
                            dinhmuc.Text = khachhanghuy.DINHMUC;
                            try
                            {
                                ngaygan.Text = Format.NgayVNVN(khachhanghuy.NGAYTHAY.Value);
                                ngaykiemdinh.Text = Format.NgayVNVN(khachhanghuy.NGAYKIEMDINH.Value);
                            }
                            catch (Exception)
                            {

                            }
                            hieudhn.Text = khachhanghuy.HIEUDH + "  - " + khachhanghuy.CODH + "  - " + khachhanghuy.SOTHANDH + " - " + khachhanghuy.VITRIDHN;
                            nvds.Text = C_DuLieuKhachHang.getNVDS(khachhanghuy.LOTRINH.Substring(2, 2));
                            nvtt.Text = C_DuLieuKhachHang.getNVThuTien(khachhanghuy.DANHBO);

                            loadHoaDon(khachhanghuy.DANHBO);
                            loadGhiChu(khachhanghuy.DANHBO);
                            LoadHInh(khachhanghuy.DANHBO);
                            LoadVideos(this.txtDB.Text);
                        }
                        catch (Exception)
                        {

                        }
                    }
                    else
                    {
                        lbTenKh.Text = "Không Tìm Thấy Khách Hàng";
                        lbTenKh.ForeColor = Color.Red;
                        //Refesh();
                    }
                }
            }
        }

        public void loadHoaDon(string db)
        {
            GridView1.DataSource = Class.C_DuLieuKhachHang.getListHoaDonReport(db);
            GridView1.DataBind();
        }

        public void loadGhiChu(string db)
        {
            GridView2.DataSource = Class.C_DuLieuKhachHang.lisGhiChu(db);
            GridView2.DataBind();

            GridView4.DataSource = Class.C_TrungTamKhachHang.getKiemTraXM(db);
            GridView4.DataBind();
        }

        public void LoadHInh(string db)
        {
            List<TB_DULIEUKHACHHANG_IMG> lis = C_DuLieuKhachHang.getListImg(db);
            foreach (TB_DULIEUKHACHHANG_IMG value in lis)
            {
                byte[] _byteArr = value.IMG.ToArray();
                string strBase64 = Convert.ToBase64String(_byteArr);

                int i = 1;

                System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
                img.ID = "image" + i.ToString();
                img.ImageUrl = "data:Image/png;base64," + strBase64;
                img.Width = 300;
                img.Height = 300;
                img.Visible = true;
                i++;

                PanelImg.Controls.Add(img);
                Label t = new Label();
                t.Text = "   ";
                PanelImg.Controls.Add(t);
            }
        }

        public void LoadVideos(string db)
        {
            List<TB_DULIEUKHACHHANG_IMG> lis = C_DuLieuKhachHang.getListVideo(db);
            DataList1.DataSource = lis;
            DataList1.DataBind();
        }

        protected void txtDB_TextChanged(object sender, EventArgs e)
        {
            string s = dot.SelectedValue + "";
            string search = txtDB.Text;
            if ("0".Equals(s))
            {
                LoadThongTinDB(this.txtDB.Text.Replace(" ", "").Replace("-", ""));
                Panel3.Visible = false;
            }
            else if ("1".Equals(s))
            {
                string query = "SELECT DANHBO, LOTRINH,HOTEN, (SONHA+ ' ' + TENDUONG ) AS DCHI,HOPDONG,GIABIEU,DINHMUC,CODH, HIEUDH,SOTHANDH,YEAR(NGAYTHAY) AS NAMGAN, VITRIDHN,CHISOKYTRUOC"
                                + " FROM TB_DULIEUKHACHHANG KH"
                                + " WHERE (SONHA+' '+ TENDUONG) LIKE N'%" + this.txtDB.Text.Replace("*", "%") + "%'"
                                + " union all"
                                + " SELECT DANHBO, LOTRINH,HOTEN, (SONHA+ ' ' + TENDUONG ) AS DCHI,HOPDONG,GIABIEU,DINHMUC,CODH, HIEUDH,SOTHANDH,YEAR(NGAYTHAY) AS NAMGAN, VITRIDHN,CHISOKYTRUOC"
                                + " FROM TB_DULIEUKHACHHANG_HUYDB KH"
                                + " WHERE (SONHA+' '+ TENDUONG) LIKE N'%" + this.txtDB.Text.Replace("*", "%") + "%'";
                DataTable tb = LinQConnection.getDataTable(query);
                GridView3.DataSource = tb;
                GridView3.DataBind();
                Panel3.Visible = true;
            }
            else if ("2".Equals(s))
            {
                string query = "SELECT DANHBO, LOTRINH,HOTEN, (SONHA+ ' ' + TENDUONG ) AS DCHI,HOPDONG,GIABIEU,DINHMUC,CODH, HIEUDH,SOTHANDH,YEAR(NGAYTHAY) AS NAMGAN, VITRIDHN,CHISOKYTRUOC"
                               + " FROM TB_DULIEUKHACHHANG KH"
                               + " WHERE SOTHANDH LIKE N'%" + this.txtDB.Text + "%'"
                               + " union all"
                               + " SELECT DANHBO, LOTRINH,HOTEN, (SONHA+ ' ' + TENDUONG ) AS DCHI,HOPDONG,GIABIEU,DINHMUC,CODH, HIEUDH,SOTHANDH,YEAR(NGAYTHAY) AS NAMGAN, VITRIDHN,CHISOKYTRUOC"
                               + " FROM TB_DULIEUKHACHHANG_HUYDB KH"
                               + " WHERE SOTHANDH LIKE N'%" + this.txtDB.Text + "%'";
                DataTable tb = LinQConnection.getDataTable(query);
                GridView3.DataSource = tb;
                GridView3.DataBind();
                Panel3.Visible = true;
            }
            //Session["sds"] = Class.C_QuanLyDHN.getDiaChi(search);

        }

        public static byte[] Resize2Max50Kbytes(byte[] byteImageIn)
        {
            byte[] currentByteImageArray = byteImageIn;
            double scale = 1f;
            MemoryStream inputMemoryStream = new MemoryStream(byteImageIn);
            System.Drawing.Image fullsizeImage = System.Drawing.Image.FromStream(inputMemoryStream);

            while (currentByteImageArray.Length > 50000)
            {
                Bitmap fullSizeBitmap = new Bitmap(fullsizeImage, new Size((int)(fullsizeImage.Width * scale), (int)(fullsizeImage.Height * scale)));
                MemoryStream resultStream = new MemoryStream();

                fullSizeBitmap.Save(resultStream, fullsizeImage.RawFormat);

                currentByteImageArray = resultStream.ToArray();
                resultStream.Dispose();
                resultStream.Close();

                scale -= 0.05f;
            }
            return currentByteImageArray;
        }

        protected void btUploag_Click(object sender, EventArgs e)
        {
            if ("".Contains(FileUpload2.FileName))
            {
                return;
            }
            else if (FileUpload2.FileName.Contains("mp4"))
            {
                try
                {
                    if (Request.Files[0].InputStream.Length > Int32.MaxValue)
                        return;
                    int dataLen = (int)Request.Files[0].InputStream.Length;
                    byte[] _byteArr = new byte[dataLen];
                    Request.Files[0].InputStream.Read(_byteArr, 0, dataLen);
                    TB_DULIEUKHACHHANG_IMG img = new TB_DULIEUKHACHHANG_IMG();
                    img.DANHBO = lbDanhBo.Text;
                    img.NGAYUP = DateTime.Now;
                    img.Loai = "mp4";
                    img.Video = _byteArr;
                    C_DuLieuKhachHang.InsertImg(img);

                    //string strBase64 = Convert.ToBase64String(_byteArr);
                    //Image1.ImageUrl = "data:Image/png;base64," + strBase64;

                    this.upload.Text = "OK";
                    this.upload.BackColor = Color.Blue;

                    LoadVideos(this.txtDB.Text);
                }
                catch (Exception ex)
                {
                    this.upload.BackColor = Color.Red;
                    this.upload.Text = "Lỗi" + ex.ToString(); ;
                }
            }
            else
            {
                if (FileUpload2.HasFile)
                    try
                    {
                        if (Request.Files[0].InputStream.Length > Int32.MaxValue)
                            return;
                        int dataLen = (int)Request.Files[0].InputStream.Length;
                        byte[] _byteArr = new byte[dataLen];
                        Request.Files[0].InputStream.Read(_byteArr, 0, dataLen);
                        TB_DULIEUKHACHHANG_IMG img = new TB_DULIEUKHACHHANG_IMG();
                        img.DANHBO = lbDanhBo.Text;
                        img.NGAYUP = DateTime.Now;
                        img.IMG = Resize2Max50Kbytes(_byteArr);
                        img.Loai = "img";
                        C_DuLieuKhachHang.InsertImg(img);

                        //string strBase64 = Convert.ToBase64String(_byteArr);
                        //Image1.ImageUrl = "data:Image/png;base64," + strBase64;

                        this.upload.Text = "OK";
                        this.upload.BackColor = Color.Blue;
                        LoadHInh(this.txtDB.Text);
                    }
                    catch (Exception ex)
                    {
                        this.upload.BackColor = Color.Red;
                        this.upload.Text = "Lỗi" + ex.ToString(); ;
                    }
            }
        }

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if ("Select".Equals(e.CommandName))
            {
                this.txtDB.Text = e.CommandArgument.ToString();
                LoadThongTinDB(e.CommandArgument.ToString());
                Panel3.Visible = false;
            }
        }
    }
}