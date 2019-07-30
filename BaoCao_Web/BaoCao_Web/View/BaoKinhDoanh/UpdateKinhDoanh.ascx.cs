using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaoCao_Web.DataBase;
using System.Data;
using System.Drawing;

namespace BaoCao_Web.View.BaoKinhDoanh
{
    public partial class UpdateKinhDoanh : System.Web.UI.UserControl
    {
        BAOCAO_KINHDOANH kd = null;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            flag = true;
            int y = DateTime.Now.Year;
            for (int i = y - 2; i < y + 3; i++)
            {
                year.Items.Add(i + "");
            }
            year.SelectedIndex = 2;
           
        }

        void refesh()
        {
            this.txtDoanhThu.Text = "";
            this.txtTiLeDTKy.Text = "";
            this.txtTiLeDT4Ky.Text = "";
            this.txtSanLuong.Text = "";
            this.txtDHN.Text = "";
            this.txtTangDHN.Text = "";
            this.txtHoaDonNho3.Text = "";
            this.txtGiaBinhQuan.Text = "";
            this.txtHoaDonDM.Text = "";
            this.hdTBPN.Text = "";
            this.HdTBTB.Text = "";
            this.hdtbTP.Text = "";
            this.hdtbTongCong.Text = "";
            this.hdtbTANGGIAM.Text = "";
            this.hd0MPN.Text = "";
            this.hd0mTB.Text = "";
            this.hd0mTP.Text = "";
            this.hd0mTONG.Text = "";
            this.hd0mTANGGIAM.Text = "";
            this.hd4mPN.Text = "";
            this.hd4mTB.Text = "";
            this.hd4mTP.Text = "";
            this.hd4mTONGCONG.Text = "";
            this.hd4mTANGGIAM.Text = "";
            this.hdTonKyTruoc.Text = "";
            this.hdTonTG.Text = "";
            this.hdTonCQ.Text = "";
            this.hdTonTONGCONG.Text = "";
            this.dtTonTG.Text = "";
            this.dtTonCQ.Text = "";
            this.dtTonTONGCONG.Text = "";
            txtDoanhThu.Focus();

        }

        void Insert()
        {
            kd = new BAOCAO_KINHDOANH();
            kd.KY = int.Parse(ky.Text);
            kd.NAM = int.Parse(year.Text);
            try
            { kd.DOANHTHU = double.Parse(this.txtDoanhThu.Text.Replace(" ", "")); }
            catch (Exception) { kd.DOANHTHU = null; }

            try
            { kd.DT_KY = double.Parse(this.txtTiLeDTKy.Text.Replace(" ", "")); }
            catch (Exception) { kd.DT_KY = null; }

            try
            { kd.DT_4KY = double.Parse(this.txtTiLeDT4Ky.Text.Replace(" ", "")); }
            catch (Exception) { kd.DT_4KY = null; }

            try
            { kd.SANLUONG = double.Parse(this.txtSanLuong.Text.Replace(" ", "")); }
            catch (Exception) { kd.SANLUONG = null; }

            try
            { kd.SLDHN = double.Parse(this.txtDHN.Text.Replace(" ", "")); }
            catch (Exception) { kd.SLDHN = null; }

            try
            { kd.TANGDHN = double.Parse(this.txtTangDHN.Text.Replace(" ", "")); }
            catch (Exception) { kd.TANGDHN = null; }

            try
            { kd.DHN_NHO3 = double.Parse(this.txtHoaDonNho3.Text.Replace(" ", "")); }
            catch (Exception) { kd.DHN_NHO3 = null; }

            try
            { kd.GIABQ = double.Parse(this.txtGiaBinhQuan.Text.Replace(" ", "")); }
            catch (Exception) { kd.GIABQ = null; }


            try
            { kd.TONG_DM = double.Parse(this.txtHoaDonDM.Text.Replace(" ", "")); }
            catch (Exception) { kd.TONG_DM = null; }

            try
            { kd.HDTB_PN = double.Parse(this.hdTBPN.Text.Replace(" ", "")); }
            catch (Exception) { kd.HDTB_PN = null; }

            try
            { kd.HDTB_TB = double.Parse(this.HdTBTB.Text.Replace(" ", "")); }
            catch (Exception) { kd.HDTB_TB = null; }

            try
            { kd.HDTB_TP = double.Parse(this.hdtbTP.Text.Replace(" ", "")); }
            catch (Exception) { kd.HDTB_TP = null; }

            try
            { kd.HDTB = double.Parse(this.hdtbTongCong.Text.Replace(" ", "")); }
            catch (Exception) { kd.HDTB = null; }

            try
            { kd.HDTB_TANG = double.Parse(this.hdtbTANGGIAM.Text.Replace(" ", "")); }
            catch (Exception) { kd.HDTB_TANG = null; }

            try
            { kd.HOADON0_PN = double.Parse(this.hd0MPN.Text.Replace(" ", "")); }
            catch (Exception) { kd.HOADON0_PN = null; }

            try
            { kd.HOADON0_TB = double.Parse(this.hd0mTB.Text.Replace(" ", "")); }
            catch (Exception) { kd.HOADON0_TB = null; }

            try
            { kd.HOADON0_TP = double.Parse(this.hd0mTP.Text.Replace(" ", "")); }
            catch (Exception) { kd.HOADON0_TP = null; }

            try
            { kd.HOADON0 = double.Parse(this.hd0mTONG.Text.Replace(" ", "")); }
            catch (Exception) { kd.HOADON0 = null; }

            try
            { kd.HOADON0_TG = double.Parse(this.hd0mTANGGIAM.Text.Replace(" ", "")); }
            catch (Exception) { kd.HOADON0_TG = null; }

            try
            { kd.HOADON4_PN = double.Parse(this.hd4mPN.Text.Replace(" ", "")); }
            catch (Exception) { kd.HOADON4_PN = null; }

            try
            { kd.HOADON4_TB = double.Parse(this.hd4mTB.Text.Replace(" ", "")); }
            catch (Exception) { kd.HOADON4_TB = null; }

            try
            { kd.HOADON4_TP = double.Parse(this.hd4mTP.Text.Replace(" ", "")); }
            catch (Exception) { kd.HOADON4_TP = null; }

            try
            { kd.HOADON4 = double.Parse(this.hd4mTONGCONG.Text.Replace(" ", "")); }
            catch (Exception) { kd.HOADON4 = null; }

            try
            { kd.HOADON4_TG = double.Parse(this.hd4mTANGGIAM.Text.Replace(" ", "")); }
            catch (Exception) { kd.HOADON4_TG = null; }

            try
            { kd.HDTON_TRUOC = double.Parse(this.hdTonKyTruoc.Text.Replace(" ", "")); }
            catch (Exception) { kd.HDTON_TRUOC = null; }

            try
            { kd.HDTON_TG = double.Parse(this.hdTonTG.Text.Replace(" ", "")); }
            catch (Exception) { kd.HDTON_TG = null; }

            try
            { kd.HDTON_CQ = double.Parse(this.hdTonCQ.Text.Replace(" ", "")); }
            catch (Exception) { kd.HDTON_CQ = null; }

            try
            { kd.HDTON_TONG = double.Parse(this.hdTonTONGCONG.Text.Replace(" ", "")); }
            catch (Exception) { kd.HDTON_TONG = null; }

            try
            { kd.SLTON_TG = double.Parse(this.dtTonTG.Text.Replace(" ", "")); }
            catch (Exception) { kd.SLTON_TG = null; }

            try
            { kd.SLTON_CQ = double.Parse(this.dtTonCQ.Text.Replace(" ", "")); }
            catch (Exception) { kd.SLTON_CQ = null; }

            try
            { kd.SLTON_TONG = double.Parse(this.dtTonTONGCONG.Text.Replace(" ", "")); }
            catch (Exception) { kd.SLTON_TONG = null; }

            try
            {
                if (Class.SoLieuKinhDoanh.Insert(kd))
                {
                    lbResult.Text = "Cập Nhật Dữ Liệu Thành Công !";
                    lbResult.ForeColor = Color.Blue;

                }
                else
                {
                    lbResult.Text = "Cập Nhật Thất Bại, Xin Kiểm Tra Lại !";
                    lbResult.ForeColor = Color.Red;
                }
            }
            catch (Exception) { }
        }

        void Update()
        {
            if (kd != null)
            {
                try
                { kd.DOANHTHU = double.Parse(this.txtDoanhThu.Text.Replace(" ", "")); }
                catch (Exception) { kd.DOANHTHU = null; }

                try
                { kd.DT_KY = double.Parse(this.txtTiLeDTKy.Text.Replace(" ", "")); }
                catch (Exception) { kd.DT_KY = null; }

                try
                { kd.DT_4KY = double.Parse(this.txtTiLeDT4Ky.Text.Replace(" ", "")); }
                catch (Exception) { kd.DT_4KY = null; }

                try
                { kd.SANLUONG = double.Parse(this.txtSanLuong.Text.Replace(" ", "")); }
                catch (Exception) { kd.SANLUONG = null; }

                try
                { kd.SLDHN = double.Parse(this.txtDHN.Text.Replace(" ", "")); }
                catch (Exception) { kd.SLDHN = null; }

                try
                { kd.TANGDHN = double.Parse(this.txtTangDHN.Text.Replace(" ", "")); }
                catch (Exception) { kd.TANGDHN = null; }

                try
                { kd.DHN_NHO3 = double.Parse(this.txtHoaDonNho3.Text.Replace(" ", "")); }
                catch (Exception) { kd.DHN_NHO3 = null; }

                try
                { kd.GIABQ = double.Parse(this.txtGiaBinhQuan.Text.Replace(" ", "")); }
                catch (Exception) { kd.GIABQ = null; }


                try
                { kd.TONG_DM = double.Parse(this.txtHoaDonDM.Text.Replace(" ", "")); }
                catch (Exception) { kd.TONG_DM = null; }

                try
                { kd.HDTB_PN = double.Parse(this.hdTBPN.Text.Replace(" ", "")); }
                catch (Exception) { kd.HDTB_PN = null; }

                try
                { kd.HDTB_TB = double.Parse(this.HdTBTB.Text.Replace(" ", "")); }
                catch (Exception) { kd.HDTB_TB = null; }

                try
                { kd.HDTB_TP = double.Parse(this.hdtbTP.Text.Replace(" ", "")); }
                catch (Exception) { kd.HDTB_TP = null; }

                try
                { kd.HDTB = double.Parse(this.hdtbTongCong.Text.Replace(" ", "")); }
                catch (Exception) { kd.HDTB = null; }

                try
                { kd.HDTB_TANG = double.Parse(this.hdtbTANGGIAM.Text.Replace(" ", "")); }
                catch (Exception) { kd.HDTB_TANG = null; }

                try
                { kd.HOADON0_PN = double.Parse(this.hd0MPN.Text.Replace(" ", "")); }
                catch (Exception) { kd.HOADON0_PN = null; }

                try
                { kd.HOADON0_TB = double.Parse(this.hd0mTB.Text.Replace(" ", "")); }
                catch (Exception) { kd.HOADON0_TB = null; }

                try
                { kd.HOADON0_TP = double.Parse(this.hd0mTP.Text.Replace(" ", "")); }
                catch (Exception) { kd.HOADON0_TP = null; }

                try
                { kd.HOADON0 = double.Parse(this.hd0mTONG.Text.Replace(" ", "")); }
                catch (Exception) { kd.HOADON0 = null; }

                try
                { kd.HOADON0_TG = double.Parse(this.hd0mTANGGIAM.Text.Replace(" ", "")); }
                catch (Exception) { kd.HOADON0_TG = null; }

                try
                { kd.HOADON4_PN = double.Parse(this.hd4mPN.Text.Replace(" ", "")); }
                catch (Exception) { kd.HOADON4_PN = null; }

                try
                { kd.HOADON4_TB = double.Parse(this.hd4mTB.Text.Replace(" ", "")); }
                catch (Exception) { kd.HOADON4_TB = null; }

                try
                { kd.HOADON4_TP = double.Parse(this.hd4mTP.Text.Replace(" ", "")); }
                catch (Exception) { kd.HOADON4_TP = null; }

                try
                { kd.HOADON4 = double.Parse(this.hd4mTONGCONG.Text.Replace(" ", "")); }
                catch (Exception) { kd.HOADON4 = null; }

                try
                { kd.HOADON4_TG = double.Parse(this.hd4mTANGGIAM.Text.Replace(" ", "")); }
                catch (Exception) { kd.HOADON4_TG = null; }

                try
                { kd.HDTON_TRUOC = double.Parse(this.hdTonKyTruoc.Text.Replace(" ", "")); }
                catch (Exception) { kd.HDTON_TRUOC = null; }

                try
                { kd.HDTON_TG = double.Parse(this.hdTonTG.Text.Replace(" ", "")); }
                catch (Exception) { kd.HDTON_TG = null; }

                try
                { kd.HDTON_CQ = double.Parse(this.hdTonCQ.Text.Replace(" ", "")); }
                catch (Exception) { kd.HDTON_CQ = null; }

                try
                { kd.HDTON_TONG = double.Parse(this.hdTonTONGCONG.Text.Replace(" ", "")); }
                catch (Exception) { kd.HDTON_TONG = null; }

                try
                { kd.SLTON_TG = double.Parse(this.dtTonTG.Text.Replace(" ", "")); }
                catch (Exception) { kd.SLTON_TG = null; }

                try
                { kd.SLTON_CQ = double.Parse(this.dtTonCQ.Text.Replace(" ", "")); }
                catch (Exception) { kd.SLTON_CQ = null; }

                try
                { kd.SLTON_TONG = double.Parse(this.dtTonTONGCONG.Text.Replace(" ", "")); }
                catch (Exception) { kd.SLTON_TONG = null; }

                try
                {
                    if (Class.SoLieuKinhDoanh.Update())
                    {
                        lbResult.Text = "Cập Nhật Dữ Liệu Thành Công !";
                        lbResult.ForeColor = Color.Blue;

                    }
                    else
                    {
                        lbResult.Text = "Cập Nhật Thất Bại, Xin Kiểm Tra Lại !";
                        lbResult.ForeColor = Color.Red;
                    }
                }
                catch (Exception) { }
            }
        }

        bool flag = true;

        protected void ky_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btCapNhat_Click(object sender, EventArgs e)
        {
            string nam = year.Text;
            string ky_ = ky.Text;
            kd = Class.SoLieuKinhDoanh.findByKy(int.Parse(ky_), int.Parse(nam));

            if (kd != null)
            {
                Update();
            }
            else {
                Insert();
            }
        }

        protected void hdtbTP_TextChanged(object sender, EventArgs e)
        {
            double rs = 0;
            try
            { rs += double.Parse(this.hd0MPN.Text.Replace(" ", "")); }
            catch (Exception) { }

            try
            { rs += double.Parse(this.hd0mTB.Text.Replace(" ", "")); }
            catch (Exception) {  }

            try
            { rs += double.Parse(this.hd0mTP.Text.Replace(" ", "")); }
            catch (Exception) { }

            this.hd0mTONG.Text = rs + "";
        }

        protected void btCapNhat0_Click(object sender, EventArgs e)
        {
            string nam = year.Text;
            string ky_ = ky.Text;
            kd = Class.SoLieuKinhDoanh.findByKy(int.Parse(ky_), int.Parse(nam));
            if (flag)
            {
                if (kd != null)
                {
                    this.txtDoanhThu.Text = kd.DOANHTHU + "";
                    this.txtTiLeDTKy.Text = kd.DT_KY + "";
                    this.txtTiLeDT4Ky.Text = kd.DT_4KY + "";
                    this.txtSanLuong.Text = kd.SANLUONG + "";
                    this.txtDHN.Text = kd.SLDHN + "";
                    this.txtTangDHN.Text = kd.TANGDHN + "";
                    this.txtHoaDonNho3.Text = kd.DHN_NHO3 + "";
                    this.txtGiaBinhQuan.Text = kd.GIABQ + "";
                    this.txtHoaDonDM.Text = kd.TONG_DM + "";
                    this.hdTBPN.Text = kd.HDTB_PN + "";
                    this.HdTBTB.Text = kd.HDTB_TB + "";
                    this.hdtbTP.Text = kd.HDTB_TP + "";
                    this.hdtbTongCong.Text = kd.HDTB + "";
                    this.hdtbTANGGIAM.Text = kd.HDTB_TANG + "";
                    this.hd0MPN.Text = kd.HOADON0_PN + "";
                    this.hd0mTB.Text = kd.HOADON0_TB + ""; ;
                    this.hd0mTP.Text = kd.HOADON0_TP + "";
                    this.hd0mTONG.Text = kd.HOADON0 + "";
                    this.hd0mTANGGIAM.Text = kd.HOADON0_TG + "";
                    this.hd4mPN.Text = kd.HOADON4_PN + "";
                    this.hd4mTB.Text = kd.HOADON4_TB + "";
                    this.hd4mTP.Text = kd.HOADON4_TP + "";
                    this.hd4mTONGCONG.Text = kd.HOADON4 + "";
                    this.hd4mTANGGIAM.Text = kd.HOADON4_TG + "";
                    this.hdTonKyTruoc.Text = kd.HDTON_TRUOC + "";
                    this.hdTonTG.Text = kd.HDTON_TG + "";
                    this.hdTonCQ.Text = kd.HDTON_CQ + "";
                    this.hdTonTONGCONG.Text = kd.HDTON_TONG + "";
                    this.dtTonTG.Text = kd.SLTON_TG + "";
                    this.dtTonCQ.Text = kd.SLTON_CQ + "";
                    this.dtTonTONGCONG.Text = kd.SLTON_TONG + "";
                }
                else
                {
                    refesh();
                }
            }
        }
    }
}