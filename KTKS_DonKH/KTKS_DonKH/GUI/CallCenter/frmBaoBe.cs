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
    public partial class frmBaoBe : Form
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
      
        public frmBaoBe( )
        {
           
            InitializeComponent();
            fLoad();

        }
       
        public void lDuong()
        {
            //DataTable table = CHeThongDuong.getQuanPhuong(this.txtDuong.Text);
            //if (table.Rows.Count > 0)
            //{
            //    this.cbPhuong.SelectedText = table.Rows[0][0].ToString();
            //    this.cbQuan.SelectedText = table.Rows[0][1].ToString();
            //}
        }

        public void fLoad( )
        {
            txtSoHoSo.Text = CTiepNhanDon.IdentityBienNhan();
            cbLoaiTiepNhan.DataSource = CTiepNhanDon.getLoaiTiepNhan("BB");
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

                this.cbPhuong.DataSource = CHeThongDuong.getListPhuong();
                this.cbPhuong.DisplayMember = "Display";
                this.cbPhuong.ValueMember = "Value";

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
            tn.LoaiTN = "KH";
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
            tn.ChuyenHS = true;
            tn.NgayChuyen = DateTime.Now;
            tn.DonViChuyen = "TCTB";
            tn.Mess = true;
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
            //try
            //{
            //    this.cbPhuong.DataSource = CHeThongDuong.getListPhuong(int.Parse(cbQuan.SelectedValue.ToString()));
            //    this.cbPhuong.DisplayMember = "Display";
            //    this.cbPhuong.ValueMember = "Value";
            //}
            //catch (Exception)
            //{

            //}
        }

        private void cbQuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    this.cbPhuong.DataSource = CHeThongDuong.getListPhuong(int.Parse(cbQuan.SelectedValue.ToString()));
            //    this.cbPhuong.DisplayMember = "Display";
            //    this.cbPhuong.ValueMember = "Value";
            //}
            //catch (Exception)
            //{

            //}
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}