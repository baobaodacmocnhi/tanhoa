using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.DonTu;

namespace KTKS_DonKH.GUI.ToXuLy
{
    public partial class frmNhapNhieuDBTXL : Form
    {
        CLoaiDonTXL _cLoaiDonTXL = new CLoaiDonTXL();
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();
        CThuTien _cThuTien = new CThuTien();
        CDocSo _cDocSo = new CDocSo();
        CDonTu _cDonTu = new CDonTu();
        CDonTXL _cDonTXL = new CDonTXL();
        CLichSuDonTu _cLichSuDonTu = new CLichSuDonTu();

        LinQ.DonTu _dontu = null;

        private DateTimePicker cellDateTimePicker;
        bool _flag = false;

        public frmNhapNhieuDBTXL()
        {
            InitializeComponent();
        }

        private void frmNhapNhieuDB_Load(object sender, EventArgs e)
        {
            this.cellDateTimePicker = new DateTimePicker();
            this.cellDateTimePicker.ValueChanged += new EventHandler(cellDateTimePickerValueChanged);
            this.cellDateTimePicker.Visible = false;
            this.cellDateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.cellDateTimePicker.Format = DateTimePickerFormat.Custom;
            this.dgvDanhBo.Controls.Add(cellDateTimePicker);
            Location = new Point(20, 50);

            dgvDanhBo.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDanhBo.Font, FontStyle.Bold);

            cmbLD.DataSource = _cLoaiDonTXL.GetDS();
            cmbLD.DisplayMember = "TenLD";
            cmbLD.ValueMember = "MaLD";
            cmbLD.SelectedIndex = -1;

            DataGridViewComboBoxColumn cmbColumn = (DataGridViewComboBoxColumn)dgvDanhBo.Columns["NguoiDi"];
            cmbColumn.DataSource = _cTaiKhoan.GetDS_KTXM("TXL");
            cmbColumn.DisplayMember = "HoTen";
            cmbColumn.ValueMember = "MaU";
        }

        void cellDateTimePickerValueChanged(object sender, EventArgs e)
        {
            dgvDanhBo.CurrentCell.Value = cellDateTimePicker.Value.ToString("dd/MM/yyyy");
            cellDateTimePicker.Visible = false;
        }

        private void dgvDanhBo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {  
            if (dgvDanhBo.Columns[e.ColumnIndex].Name == "DanhBo" && dgvDanhBo["DanhBo",e.RowIndex].Value!=null)
            {
                for (int i = 0; i < dgvDanhBo.Rows.Count - 2; i++)
                    if (i!=e.RowIndex&&dgvDanhBo["DanhBo", i].Value != null && dgvDanhBo["DanhBo", i].Value.ToString()!="" && dgvDanhBo["DanhBo", i].Value.ToString() == dgvDanhBo["DanhBo", e.RowIndex].Value.ToString())
                    {
                        MessageBox.Show("Danh Bộ đã nhập rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                if (_cThuTien.GetMoiNhat(dgvDanhBo["DanhBo", e.RowIndex].Value.ToString()) != null)
                {
                    HOADON hoadon = _cThuTien.GetMoiNhat(dgvDanhBo["DanhBo", e.RowIndex].Value.ToString());
                    dgvDanhBo["HopDong", e.RowIndex].Value = hoadon.HOPDONG;
                    dgvDanhBo["HoTen", e.RowIndex].Value = hoadon.TENKH;
                    dgvDanhBo["DiaChi", e.RowIndex].Value = hoadon.SO + " " + hoadon.DUONG + _cDocSo.GetPhuongQuan(hoadon.Quan, hoadon.Phuong);
                    dgvDanhBo["MSThue", e.RowIndex].Value = hoadon.MST;
                    dgvDanhBo["GiaBieu", e.RowIndex].Value = hoadon.GB;
                    dgvDanhBo["DinhMuc", e.RowIndex].Value = hoadon.DM;
                    dgvDanhBo["Dot", e.RowIndex].Value = hoadon.DOT.ToString();
                    dgvDanhBo["Ky", e.RowIndex].Value = hoadon.KY.ToString();
                    dgvDanhBo["Nam", e.RowIndex].Value = hoadon.NAM.ToString();
                    dgvDanhBo["MLT", e.RowIndex].Value = hoadon.MALOTRINH.ToString();
                    dgvDanhBo["Quan", e.RowIndex].Value = hoadon.Quan.ToString();
                    dgvDanhBo["Phuong", e.RowIndex].Value = hoadon.Phuong.ToString();
                }
                else
                {
                    MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
            }
            if (e.RowIndex > 0 && dgvDanhBo.Columns[e.ColumnIndex].Name == "NguoiDi")
            {
                _flag = true;
                //dgvDanhBo["NgayChuyen", e.RowIndex].Value = dgvDanhBo["NgayChuyen", e.RowIndex - 1].Value;
                //dgvDanhBo["NguoiDi", e.RowIndex].Value = dgvDanhBo["NguoiDi", e.RowIndex - 1].Value;
            }
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            { 
                foreach (DataGridViewRow item in dgvDanhBo.Rows)
                    if (item.Cells["DanhBo"].Value != null || item.Cells["HoTen"].Value != null || item.Cells["DiaChi"].Value != null)
                    {
                        if (item.Cells["DanhBo"].Value != null)
                            if (_cDonTXL.CheckExist(item.Cells["DanhBo"].Value.ToString(), DateTime.Now) == true)
                            {
                                if (MessageBox.Show("Danh Bộ " + item.Cells["DanhBo"].Value.ToString() + "đã nhận đơn trong ngày hôm nay rồi\nBạn vẫn muốn tiếp tục???", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                    return;
                            }
                    }

                decimal min = 0, max = 0;
                _cDonTXL.beginTransaction();
                foreach (DataGridViewRow item in dgvDanhBo.Rows)
                    if (item.Cells["DanhBo"].Value != null || item.Cells["HoTen"].Value != null || item.Cells["DiaChi"].Value != null)
                    {
                        //if (item.Cells["DanhBo"].Value != null)
                        //    if (_cDonTXL.CheckExist(item.Cells["DanhBo"].Value.ToString(), DateTime.Now) == true)
                        //    {
                        //        MessageBox.Show("Danh Bộ này đã nhận đơn trong ngày hôm nay rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //        return;
                        //    }

                        DonTXL dontxl = new DonTXL();

                        if (_dontu != null)
                        {
                            dontxl.MaDonCha = _dontu.MaDon;
                        }

                        dontxl.MaLD = int.Parse(cmbLD.SelectedValue.ToString());
                        dontxl.SoCongVan = txtSoCongVan.Text.Trim();
                        dontxl.NoiDung = txtNoiDung.Text.Trim();
                        ///
                        if (item.Cells["DanhBo"].Value != null)
                            dontxl.DanhBo = item.Cells["DanhBo"].Value.ToString();
                        if (item.Cells["HopDong"].Value != null)
                            dontxl.HopDong = item.Cells["HopDong"].Value.ToString();
                        if (item.Cells["HoTen"].Value != null)
                            dontxl.HoTen = item.Cells["HoTen"].Value.ToString();
                        if (item.Cells["DiaChi"].Value != null)
                            dontxl.DiaChi = item.Cells["DiaChi"].Value.ToString();
                        if (item.Cells["MSThue"].Value != null)
                            dontxl.MSThue = item.Cells["MSThue"].Value.ToString();
                        if (item.Cells["GiaBieu"].Value != null)
                            dontxl.GiaBieu = item.Cells["GiaBieu"].Value.ToString();
                        if (item.Cells["DinhMuc"].Value != null)
                            dontxl.DinhMuc = item.Cells["DinhMuc"].Value.ToString();
                        if (item.Cells["Dot"].Value != null)
                            dontxl.Dot = item.Cells["Dot"].Value.ToString();
                        if (item.Cells["Ky"].Value != null)
                            dontxl.Ky = item.Cells["Ky"].Value.ToString();
                        if (item.Cells["Nam"].Value != null)
                            dontxl.Nam = item.Cells["Nam"].Value.ToString();
                        if (item.Cells["MLT"].Value != null)
                            dontxl.MLT = item.Cells["MLT"].Value.ToString();
                        if (item.Cells["Quan"].Value != null)
                            dontxl.Quan = item.Cells["Quan"].Value.ToString();
                        if (item.Cells["Phuong"].Value != null)
                            dontxl.Phuong = item.Cells["Phuong"].Value.ToString();
                        ///
                        if (item.Cells["NguoiDi"].Value != null)
                        {
                            string[] date = item.Cells["NgayChuyen"].Value.ToString().Split('/');
                            dontxl.Chuyen_KTXM = true;
                            dontxl.NgayChuyen_KTXM = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                            dontxl.NguoiDi_KTXM = int.Parse(item.Cells["NguoiDi"].Value.ToString());
                            if (item.Cells["GhiChu"].Value != null)
                                dontxl.GhiChuChuyen_KTXM = item.Cells["GhiChu"].Value.ToString();
                        }
                        ///
                        if (_cDonTXL.Them(dontxl))
                        {
                            if (min == 0)
                                min = dontxl.MaDon;
                            max = dontxl.MaDon;
                            if (item.Cells["NguoiDi"].Value != null)
                            {
                                string[] date = item.Cells["NgayChuyen"].Value.ToString().Split('/');
                                //LichSuChuyenKTXM lichsuchuyenkt = new LichSuChuyenKTXM();
                                //lichsuchuyenkt.NgayChuyen = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                                //lichsuchuyenkt.NguoiDi = int.Parse(item.Cells["NguoiDi"].Value.ToString());
                                //if (item.Cells["GhiChu"].Value != null)
                                //    lichsuchuyenkt.GhiChuChuyen = item.Cells["GhiChu"].Value.ToString();
                                //lichsuchuyenkt.MaDonTXL = dontxl.MaDon;
                                //_cLichSuDonTu.Them(lichsuchuyenkt);

                                LichSuDonTu entity = new LichSuDonTu();
                                entity.NgayChuyen = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                                entity.ID_NoiChuyen = 1;
                                entity.NoiChuyen = "Kiểm Tra Xác Minh";
                                entity.ID_NoiNhan = int.Parse(item.Cells["NguoiDi"].Value.ToString());
                                entity.NoiNhan = _cTaiKhoan.GetHoTen(int.Parse(item.Cells["NguoiDi"].Value.ToString()));
                                if (item.Cells["GhiChu"].Value != null)
                                    entity.GhiChu = item.Cells["GhiChu"].Value.ToString();
                                entity.MaDonTXL = dontxl.MaDon;
                                _cLichSuDonTu.Them(entity);
                            }
                        }
                    }

                _cDonTXL.commitTransaction();
                MessageBox.Show("Thành công\nSố đơn từ TXL" + min.ToString().Insert(min.ToString().Length - 2, "-") + " đến TXL" + max.ToString().Insert(max.ToString().Length - 2, "-"), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbLD.SelectedIndex = -1;
                txtNoiDung.Text = "";
                txtSoCongVan.Text = "";
                //dgvDanhBo.Rows.Clear();
                this.Close();
            }
            catch (Exception ex)
            {
                _cDonTXL.rollback();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhBo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhBo.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDanhBo_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvDanhBo.Columns[e.ColumnIndex].Name == "NgayChuyen")
            {
                //var index = dgvDanhBo.CurrentCell.ColumnIndex;

                Rectangle tempRect = this.dgvDanhBo.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                cellDateTimePicker.Location = tempRect.Location;
                cellDateTimePicker.Width = tempRect.Width;
                try
                {
                    cellDateTimePicker.Value = DateTime.Parse(dgvDanhBo.CurrentCell.Value.ToString());
                }
                catch
                {
                    cellDateTimePicker.Value = DateTime.Now;
                }
                cellDateTimePicker.Visible = true;
            }
        }

        private void dgvDanhBo_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
                if (!_flag)
                {
                    dgvDanhBo["NgayChuyen", e.RowIndex].Value = dgvDanhBo["NgayChuyen", e.RowIndex - 1].Value;
                    dgvDanhBo["NguoiDi", e.RowIndex].Value = dgvDanhBo["NguoiDi", e.RowIndex - 1].Value;
                }
                else
                    _flag = false;
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDon.Text.Trim() != "")
            {
                if (_cDonTu.CheckExist(int.Parse(txtMaDon.Text.Trim())) == true)
                {
                    _dontu = _cDonTu.Get(int.Parse(txtMaDon.Text.Trim()));
                    txtSoCongVan.Text = _dontu.SoCongVan;
                }
                else
                {
                    MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
