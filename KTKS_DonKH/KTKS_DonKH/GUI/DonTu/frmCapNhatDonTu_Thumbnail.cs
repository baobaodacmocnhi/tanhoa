using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.DonTu;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.QuanTri;
using System.Transactions;

namespace KTKS_DonKH.GUI.DonTu
{
    public partial class frmCapNhatDonTu_Thumbnail : Form
    {
        CNoiChuyen _cNoiChuyen = new CNoiChuyen();
        CDonTu _cDonTu = new CDonTu();
        DonTu_ChiTiet _dontu_ChiTiet = null;
        string _TableName = null;
        int _ID = -1;
        int _selectedIndex = -1;

        public frmCapNhatDonTu_Thumbnail()
        {
            InitializeComponent();
        }

        public frmCapNhatDonTu_Thumbnail(DonTu_ChiTiet dontu_ChiTiet)
        {
            InitializeComponent();
            _dontu_ChiTiet = dontu_ChiTiet;
        }

        public frmCapNhatDonTu_Thumbnail(DonTu_ChiTiet dontu_ChiTiet, string TableName, int ID)
        {
            InitializeComponent();
            _dontu_ChiTiet = dontu_ChiTiet;
            _TableName = TableName;
            _ID = ID;
            switch (TableName)
            {
                case "KTXM_ChiTiet":
                    _selectedIndex = 5;
                    break;
                case "DCBD_ChiTietBienDong":
                case "DCBD_ChiTietHoaDon":
                    _selectedIndex = 6;
                    break;
                case "CHDB_ChiTietCatTam":
                case "CHDB_ChiTietCatHuy":
                case "CHDB_Phieu":
                    _selectedIndex = 7;
                    break;
                case "TruyThuTienNuoc_ChiTiet":
                case "GianLan_ChiTiet":
                    _selectedIndex = 8;
                    break;
                case "ThuTraLoi_ChiTiet":
                    _selectedIndex = 9;
                    break;
                case "ThuMoi_ChiTiet":
                    _selectedIndex = 10;
                    break;
                case "ToTrinh_ChiTiet":
                    _selectedIndex = 11;
                    break;
                case "VanBan_ChiTiet":
                    _selectedIndex = 38;
                    break;
            }
        }

        private void frmCapNhanDonTu_Thumbnail_Load(object sender, EventArgs e)
        {
            this.Location = new Point(200, 120);
            dgvLichSuDonTu.AutoGenerateColumns = false;

            cmbNoiChuyen.DataSource = _cNoiChuyen.GetDS("DonTuChuyen");
            cmbNoiChuyen.ValueMember = "ID";
            cmbNoiChuyen.DisplayMember = "Name";
            cmbNoiChuyen.SelectedValue = _selectedIndex;

            chkcmbNoiNhan.Properties.DataSource = _cNoiChuyen.GetDS("DonTuNhan");
            chkcmbNoiNhan.Properties.ValueMember = "ID";
            chkcmbNoiNhan.Properties.DisplayMember = "Name";

            if (_dontu_ChiTiet != null)
            {
                if (_dontu_ChiTiet.DonTu.DonTu_ChiTiets.Count == 1)
                    txtMaDon.Text = _dontu_ChiTiet.MaDon.Value.ToString();
                else
                    txtMaDon.Text = _dontu_ChiTiet.MaDon.Value.ToString() + "." + _dontu_ChiTiet.STT.Value.ToString();
                dgvLichSuDonTu.DataSource = _cDonTu.getDS_LichSu(_dontu_ChiTiet.MaDon.Value, _dontu_ChiTiet.STT.Value);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (_dontu_ChiTiet != null)
                {
                    bool flag = false;//ghi nhận có chọn checkcombobox
                    if (cmbNoiChuyen.SelectedIndex > -1)
                    {
                        for (int i = 0; i < chkcmbNoiNhan.Properties.Items.Count; i++)
                            if (chkcmbNoiNhan.Properties.Items[i].CheckState == CheckState.Checked)
                            {
                                //đi KTXM
                                if (chkcmbNoiNhan.Properties.Items[i].Value.ToString() == "5")
                                {
                                    //for (int j = 0; j < chkcmbNoiNhanKTXM.Properties.Items.Count; j++)
                                    //    if (chkcmbNoiNhanKTXM.Properties.Items[j].CheckState == CheckState.Checked)
                                    //    {
                                    //        DonTu_LichSu entity = new DonTu_LichSu();
                                    //        entity.NgayChuyen = dateChuyen.Value;
                                    //        entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                    //        entity.NoiChuyen = cmbNoiChuyen.Text;
                                    //        entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                    //        entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                    //        entity.NoiDung = txtNoiDung_LichSu.Text.Trim();
                                    //        entity.MaDon = _dontu.MaDon;
                                    //        entity.STT = 1;
                                    //        entity.ID_KTXM = int.Parse(chkcmbNoiNhanKTXM.Properties.Items[j].Value.ToString());
                                    //        entity.KTXM = chkcmbNoiNhanKTXM.Properties.Items[j].ToString();
                                    //        _cDonTu.Them_LichSu(entity);
                                    //    }
                                }
                                else
                                {
                                    DonTu_LichSu entity = new DonTu_LichSu();
                                    entity.NgayChuyen = dateChuyen.Value;
                                    entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                    entity.NoiChuyen = cmbNoiChuyen.Text;
                                    entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                    entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                    entity.NoiDung = txtNoiDung_LichSu.Text.Trim();
                                    entity.MaDon = _dontu_ChiTiet.MaDon;
                                    entity.STT = _dontu_ChiTiet.STT;
                                    if (_TableName != null)
                                    {
                                        entity.TableName = _TableName;
                                        entity.IDCT = _ID;
                                    }
                                    _cDonTu.Them_LichSu(entity);
                                }
                                flag = true;
                            }
                        if (flag == false)
                        {
                            if (chkHoanThanh.Checked == true)
                            {
                                if (txtNoiDung_LichSu.Text.Trim() != "")
                                {
                                    //cập nhật tình trạng
                                    _dontu_ChiTiet.HoanThanh = chkHoanThanh.Checked;
                                    _dontu_ChiTiet.HoanThanh_Ngay = DateTime.Now;
                                    _dontu_ChiTiet.HoanThanh_GhiChu = txtNoiDung_LichSu.Text.Trim();
                                    _cDonTu.SubmitChanges();
                                    //
                                    DonTu_LichSu entity = new DonTu_LichSu();
                                    entity.NgayChuyen = dateChuyen.Value;
                                    entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                    entity.NoiChuyen = cmbNoiChuyen.Text;
                                    //entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                    //entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                    entity.NoiDung = txtNoiDung_LichSu.Text.Trim();
                                    entity.MaDon = _dontu_ChiTiet.MaDon;
                                    entity.STT = _dontu_ChiTiet.STT;
                                    if (_TableName != null)
                                    {
                                        entity.TableName = _TableName;
                                        entity.IDCT = _ID;
                                    }
                                    _cDonTu.Them_LichSu(entity);
                                }
                                else
                                    MessageBox.Show("Thiếu Nội Dung lý do Hoàn Thành", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                DonTu_LichSu entity = new DonTu_LichSu();
                                entity.NgayChuyen = dateChuyen.Value;
                                entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                entity.NoiChuyen = cmbNoiChuyen.Text;
                                //entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                //entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                entity.NoiDung = txtNoiDung_LichSu.Text.Trim();
                                entity.MaDon = _dontu_ChiTiet.MaDon;
                                entity.STT = _dontu_ChiTiet.STT;
                                if (_TableName != null)
                                {
                                    entity.TableName = _TableName;
                                    entity.IDCT = _ID;
                                }
                                _cDonTu.Them_LichSu(entity);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chưa chọn Nơi Chuyển", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLichSuDonTu_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                ///Khi chuột phải Selected-Row sẽ được chuyển đến nơi click chuột
                dgvLichSuDonTu.CurrentCell = dgvLichSuDonTu.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dgvLichSuDonTu_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && (_dontu_ChiTiet != null))
            {
                contextMenuStrip1.Show(dgvLichSuDonTu, new Point(e.X, e.Y));
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn???", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        if (CTaiKhoan.Admin == true || CTaiKhoan.TruongPhong == true)
                        {
                            DonTu_LichSu dtls = _cDonTu.get_LichSu(int.Parse(dgvLichSuDonTu.CurrentRow.Cells["ID"].Value.ToString()));
                            int MaDon = dtls.MaDon.Value, STT = dtls.STT.Value;
                            bool HoanThanh = dtls.HoanThanh;
                            if (_cDonTu.Xoa_LichSu(dtls, true))
                            {
                                if (HoanThanh == true)
                                {
                                    DonTu_ChiTiet dtct = _cDonTu.get_ChiTiet(MaDon, STT);
                                    dtct.HoanThanh = false;
                                    dtct.HoanThanh_Ngay = null;
                                    dtct.HoanThanh_GhiChu = null;
                                    _cDonTu.SubmitChanges();
                                }
                                scope.Complete();
                            }
                            else
                                MessageBox.Show("Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            DonTu_LichSu dtls = _cDonTu.get_LichSu(int.Parse(dgvLichSuDonTu.CurrentRow.Cells["ID"].Value.ToString()));
                            int MaDon = dtls.MaDon.Value, STT = dtls.STT.Value;
                            bool HoanThanh = dtls.HoanThanh;
                            if (_cDonTu.Xoa_LichSu(dtls, CTaiKhoan.MaUser))
                            {
                                if (HoanThanh == true)
                                {
                                    DonTu_ChiTiet dtct = _cDonTu.get_ChiTiet(MaDon, STT);
                                    dtct.HoanThanh = false;
                                    dtct.HoanThanh_Ngay = null;
                                    dtct.HoanThanh_GhiChu = null;
                                    _cDonTu.SubmitChanges();
                                }
                                scope.Complete();
                            }
                            else
                                MessageBox.Show("Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _cDonTu.Refresh();
                    dgvLichSuDonTu.DataSource = _cDonTu.getDS_LichSu(_dontu_ChiTiet.MaDon.Value, _dontu_ChiTiet.STT.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
