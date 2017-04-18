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


namespace KTKS_DonKH.GUI.CallCenter
{
    public partial class frmTiepNhanKN : Form
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        string danhbo = "";
        string loaikh = "";
        public frmTiepNhanKN(string db, string loai)
        {
            danhbo = db;
            loaikh = loai;
            InitializeComponent();
            fLoad(loaikh);
            if ("KH".Equals(loaikh))
            {
                TB_DULIEUKHACHHANG khachhang = DAL.CallCenter.CKhachHang.finByDanhBo(danhbo);
                if (khachhang != null)
                {
                    txtSoDanhBo.Text = khachhang.DANHBO;
                    txtTenKH.Text = khachhang.HOTEN;
                    txtsonha.Text = khachhang.SONHA;
                    txtDuong.Text = khachhang.TENDUONG;
                    txtDienThoai.Text = khachhang.DIENTHOAI;
                  
                    cbQuan.SelectedValue = khachhang.QUAN;

                     cbPhuong.SelectedValue = khachhang.PHUONG;
                }
            }
            else if ("GM".Equals(loaikh))
            {
                BIENNHANDON donkh = DAL.CallCenter.CGanMoi.searchBienNhan(danhbo);
                if (donkh != null)
                 {
                     txtSoDanhBo.Text = donkh.SHS;
                     txtTenKH.Text = donkh.HOTEN;
                     txtsonha.Text = donkh.SONHA;
                     txtDuong.Text = donkh.DUONG;
                     txtDienThoai.Text = donkh.DIENTHOAI;
                     QUAN q = CHeThongDuong.finByMaQuan(donkh.QUAN);
                     cbQuan.Text = q.TENQUAN;
                     cbPhuong.Text = CHeThongDuong.finbyPhuong(q.MAQUAN, donkh.PHUONG).TENPHUONG;
                 }

            }

        }
       
        public void lDuong()
        {
            DataTable table = CHeThongDuong.getQuanPhuong(this.txtDuong.Text);
            if (table.Rows.Count > 0)
            {
                this.cbPhuong.SelectedText = table.Rows[0][0].ToString();
                this.cbQuan.SelectedText = table.Rows[0][1].ToString();
            }
        }

        public void fLoad(string loaikh)
        {
            txtSoHoSo.Text = CTiepNhanDon.IdentityBienNhan();
            cbLoaiTiepNhan.DataSource = CTiepNhanDon.getLoaiTiepNhan(loaikh);
            cbLoaiTiepNhan.DisplayMember = "TenLoai";
            cbLoaiTiepNhan.ValueMember = "ID";

            try
            {
                List<TENDUONG> list = CHeThongDuong.getList();
                foreach (var item in list)
                {
                    namesCollection.Add(item.DUONG);
                }
                txtDuong.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtDuong.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtDuong.AutoCompleteCustomSource = namesCollection;

                //this.cbPhuong.DataSource = CHeThongDuong.getListPhuong();
                //this.cbPhuong.DisplayMember = "Display";
                //this.cbPhuong.ValueMember = "Value";

                cbQuan.DataSource = CHeThongDuong.getListQUAN();
                cbQuan.DisplayMember = "Display";
                cbQuan.ValueMember = "Value";



            }
            catch (Exception)
            {
            }

        }

        private void txtDuong_Leave(object sender, EventArgs e)
        {
            lDuong();
        }

        private void txtDuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 || e.KeyChar == 9)
            {
                lDuong();
            }
        }

        private void cbPhuong_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                List<PHUONG> phuong = CHeThongDuong.ListPhuongByTenPhuong(this.cbPhuong.Text);
                if (phuong.Count > 0)
                {
                    PHUONG p = phuong[0];
                    cbQuan.Text = p.QUAN.TENQUAN;

                }
            }
            catch (Exception)
            {

            }
        }

        private void btTiepNhan_Click(object sender, EventArgs e)
        {
            TTKH_TiepNhan tn = new TTKH_TiepNhan();
            tn.LoaiTN = loaikh;
            tn.SoHoSo = this.txtSoHoSo.Text;
            tn.DanhBo = this.txtSoDanhBo.Text;
            tn.DienThoai = this.txtDienThoai.Text;
            tn.TenKH = this.txtTenKH.Text;
            tn.SoNha = this.txtsonha.Text;
            tn.TenDuong = this.txtDuong.Text;
            tn.Phuong = this.cbPhuong.SelectedValue + "";
            tn.Quan = this.cbQuan.SelectedValue + "";
            tn.LoaiHs = this.cbLoaiTiepNhan.SelectedValue + "";
            tn.NgayNhan = DateTime.Now;
            tn.ChuyenHS = false;
            tn.GhiChu = this.txtGhiChu.Text;
            tn.CreateBy = CTaiKhoan.HoTen + "";
            tn.CreateDate = DateTime.Now;
            if (CTiepNhanDon.Insert(tn))
            {

                MessageBox.Show(this, "Tiếp Nhận Thông Tin Thành Công!", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show(this, "Tiếp Nhận Thông Tin Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }                 
        private void cbQuan_ValueMemberChanged(object sender, EventArgs e)
        {
            try
            {
                this.cbPhuong.DataSource = CHeThongDuong.getListPhuong(int.Parse(cbQuan.SelectedValue.ToString()));
                this.cbPhuong.DisplayMember = "Display";
                this.cbPhuong.ValueMember = "Value";
            }
            catch (Exception)
            {

            }
        }

        private void cbQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.cbPhuong.DataSource = CHeThongDuong.getListPhuong(int.Parse(cbQuan.SelectedValue.ToString()));
                this.cbPhuong.DisplayMember = "Display";
                this.cbPhuong.ValueMember = "Value";
            }
            catch (Exception)
            {

            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}