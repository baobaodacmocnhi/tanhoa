using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.QuanTri;
using CallCenter.DAL;
using KTKS_DonKH.BaoCao.CallCenter;
using KTKS_DonKH.GUI.BaoCao;


namespace KTKS_DonKH.GUI.CallCenter
{
    public partial class frmDanhSachKN : Form
    {
        string _mnu = "mnuDSTiepNhan";

        public frmDanhSachKN()
        {
            InitializeComponent();
            dateTuNgay.ValueObject = DateTime.Now.Date;
            dateDenNgay.ValueObject = DateTime.Now.Date;
            cbLoai.SelectedIndex = 0;
            pLoad();
            timer1.Start();
        }

        public void pLoad()
        {
            string sql = " SELECT tn.SoHoSo,DienThoai,DanhBo,lt.TenLoai,NgayNhan, GhiChu,CreateBy,ChuyenHS,DonViChuyen,NgayChuyen,NgayXuLy,KetQuaXuLy,NhanVienXuLy,TenKH,(SoNha + ' ' + TenDuong ) as DiaChi ";
            sql += "   FROM TTKH_TiepNhan tn, TTKH_LoaiTiepNhan lt ";
            sql += "   WHERE tn.LoaiHs=lt.ID  ";
            sql += " AND CONVERT(DATE,NgayNhan,103) BETWEEN CONVERT(DATE,'" + Utilities.DateToString.NgayVN(dateTuNgay.Value.Date) + "',103) AND CONVERT(DATE,'" + Utilities.DateToString.NgayVN(dateDenNgay.Value.Date) + "',103) ";

            if (cbLoai.SelectedIndex == 0)
                sql += " AND LoaiTN='KH'";
            else
                sql += " AND LoaiTN='GM'";

            if (ckChuaChuyen.Checked)
                sql += " AND (ChuyenHS is NULL OR ChuyenHS='False')";
            else if (ckChuaXuLy.Checked)
                sql += " AND (ChuyenHS is not null AND NgayXuLy is null) ";
            else if (ckHoanTat.Checked)
                sql += " AND NgayXuLy IS NOT NULL ";

            sql += " ORDER BY NgayNhan DESC";

            dataGrid.DataSource = CCallCenter.getDataTable(sql);
            // format();
            cbPhongBan.DataSource = CCallCenter.getDataTable("SELECT *  FROM PhongBanDoi ");
            cbPhongBan.DisplayMember = "Name";
            cbPhongBan.ValueMember = "ID";
        }

        private void check(object sender, EventArgs e)
        {
            pLoad();
        }

        void format()
        {
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {

                if (!bool.Parse(this.dataGrid.Rows[i].Cells["ChuyenHS"].Value + ""))
                {
                    dataGrid.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                }
                else if (bool.Parse(this.dataGrid.Rows[i].Cells["ChuyenHS"].Value + "") && "".Equals(this.dataGrid.Rows[i].Cells["NgayXuLy"].Value + ""))
                {
                    dataGrid.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(149)))));
                }


            }
        }

        private void dateDenNgay_ValueChanged(object sender, EventArgs e)
        {
            pLoad();
        }

        private void dateTuNgay_ValueChanged(object sender, EventArgs e)
        {
            pLoad();
        }

        private void btChuyenHS_Click(object sender, EventArgs e)
        {
            try
            {
                string listDanhBa = "";
                int flag = 0;
                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    if ("True".Equals(this.dataGrid.Rows[i].Cells["checkChon"].Value + ""))
                    {
                        flag++;
                        listDanhBa += ("'" + (this.dataGrid.Rows[i].Cells["sohoso"].Value + "").Replace(" ", "") + "',");
                    }
                }
                string sql = "UPDATE TTKH_TiepNhan SET ChuyenHS='True',Mess='True' ,NgayChuyen=GETDATE(),MaDVChuyen=" + cbPhongBan.SelectedValue + ",DonViChuyen=N'" + cbPhongBan.Text + "'   WHERE SoHoSo IN (" + listDanhBa.Remove(listDanhBa.Length - 1, 1) + ") ";
                if (CCallCenter.ExecuteCommand_(sql) > 0)
                { MessageBox.Show(this, "Chuyển Hồ Sơ Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information); pLoad(); }
                else
                    MessageBox.Show(this, "Chuyển Hồ Sơ Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Chuyển Hồ Sơ Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            // MessageBox.Show(this, listDanhBa.Remove(listDanhBa.Length - 1, 1));

        }

        private void dataGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            format();
        }

        private void btCapNhat_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                string sql = "UPDATE TTKH_TiepNhan SET ChuyenHS='True',NgayChuyen=GETDATE(),NgayXuLy=GETDATE(),KetQuaXuLy=N'" + txtKetQuaXL.Text + "',NhanVienXuLy=N'" + CTaiKhoan.HoTen + "'  WHERE SoHoSo='" + txtSoHoSo.Text + "'";
                if (CCallCenter.ExecuteCommand_(sql) > 0)
                { MessageBox.Show(this, "Cập Nhật Xử Lý Thành Công !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Information); pLoad(); }
                else
                    MessageBox.Show(this, "Cập Nhật Xử Lý Thất Bại !", "..: Thông Báo :..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGrid.CurrentCell.OwningColumn.Name != "checkChon")
            {
                try
                {
                    string sohoso = dataGrid.Rows[e.RowIndex].Cells["sohoso"].Value + "";
                    string DanhBo = dataGrid.Rows[e.RowIndex].Cells["DanhBo"].Value + "";
                    string DienThoai = dataGrid.Rows[e.RowIndex].Cells["DienThoai"].Value + "";
                    string TenLoai = dataGrid.Rows[e.RowIndex].Cells["TenLoai"].Value + "";
                    string TenKH = dataGrid.Rows[e.RowIndex].Cells["TenKH"].Value + "";
                    string DiaChi = dataGrid.Rows[e.RowIndex].Cells["DiaChi"].Value + "";
                    string GhiChu = dataGrid.Rows[e.RowIndex].Cells["GhiChu"].Value + "";
                    string Ngaytn = dataGrid.Rows[e.RowIndex].Cells["NgayNhan"].Value + "";
                    txtSoHoSo.Text = sohoso;
                    txtSoDanhBo.Text = DanhBo;
                    txtDienThoai.Text = DienThoai;
                    txtTenKH.Text = TenKH;
                    txtDuong.Text = DiaChi;
                    txtGhiChu.Text = GhiChu;
                    txtLoaiTiepNhan.Text = TenLoai;
                    dateNgaytn.ValueObject = Ngaytn;
                }
                catch (Exception)
                {

                }
            }

        }

        private void cbLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            pLoad();
        }

        int _ticks = 0;
        public void alrt()
        {

            string sql = " SELECT tn.SoHoSo,DienThoai,DanhBo,lt.TenLoai,NgayNhan, GhiChu,CreateBy,ChuyenHS,DonViChuyen,NgayChuyen,NgayXuLy,KetQuaXuLy,NhanVienXuLy,TenKH,(SoNha + ' ' + TenDuong ) as DiaChi ";
            sql += "   FROM TTKH_TiepNhan tn, TTKH_LoaiTiepNhan lt ";
            sql += "   WHERE tn.LoaiHs=lt.ID  ";
            sql += " AND  DATEDIFF(DD,NgayNhan,GETDATE())>3 ";
            sql += "  AND NgayXuLy IS  NULL ";
            sql += " ORDER BY NgayNhan DESC";


            DataTable tb = CCallCenter.getDataTable(sql);
            if (tb.Rows.Count > 0)
            {
                MessChuaXL of = new MessChuaXL(tb);
                timer1.Stop();
                of.ShowDialog();
                //if (of.ShowDialog() == System.Windows.Forms.DialogResult.OK  )
                //    timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _ticks++;
            if (_ticks % 2 == 0)
                alrt();
        }

        private void frmDanhSachKN_Load(object sender, EventArgs e)
        {

        }

        private void btIn_Click(object sender, EventArgs e)
        {
            string tungay = Utilities.DateToString.NgayVN(dateTuNgay.Value.Date);
            string denngay = Utilities.DateToString.NgayVN(dateDenNgay.Value.Date);

            string query = " SELECT * FROM  TrungTamKH ";
            query += " WHERE CONVERT(DATE,NgayNhan,103) BETWEEN CONVERT(DATE,'" + tungay + "',103) AND CONVERT(DATE,'" + denngay + "',103) ";

            DataTable tb = CCallCenter.reportTrungTamKH(query).Tables[0];
            DataRow[] tsDaXL =  tb.Select("NgayXuLy IS NOT NULL");
            DataRow[] tsChuaXL = tb.Select("NgayXuLy IS  NULL");

            rptTiepNhan rpt = new rptTiepNhan();
            rpt.SetDataSource(CCallCenter.reportTrungTamKH(query));
            rpt.SetParameterValue("tungay", tungay);
            rpt.SetParameterValue("denngay", denngay);
            rpt.SetParameterValue("tsCuocGoi", "00");
            rpt.SetParameterValue("tsTiepNhan", tb.Rows.Count);
            rpt.SetParameterValue("tsDaXL", tsDaXL.Length);
            rpt.SetParameterValue("tsChuaXL", tsChuaXL.Length);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }
    }
}