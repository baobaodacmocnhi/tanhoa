using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.DonTu;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.DonTu
{
    public partial class frmCapNhatDonTu : Form
    {
        string _mnu = "mnuCapNhatDonTu";
        CDonTu _cDonTu = new CDonTu();
        CNoiChuyen _cNoiChuyen = new CNoiChuyen();
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();
        CPhongBanDoi _cPhongBanDoi = new CPhongBanDoi();
        CLichSuDonTu _cLichSuDonTu = new CLichSuDonTu();

        LinQ.DonTu _dontu = null;

        public frmCapNhatDonTu()
        {
            InitializeComponent();
        }

        private void frmCapNhatDonTu_Load(object sender, EventArgs e)
        {
            dgvDanhBo.AutoGenerateColumns = false;
            dgvLichSuDonTu.AutoGenerateColumns = false;

            cmbNoiChuyen.DataSource = _cNoiChuyen.GetDS("DonTuChuyen");
            cmbNoiChuyen.ValueMember = "ID";
            cmbNoiChuyen.DisplayMember = "Name";
            cmbNoiChuyen.SelectedIndex = -1;

            chkcmbNoiNhan.Properties.DataSource = _cNoiChuyen.GetDS("DonTuNhan");
            chkcmbNoiNhan.Properties.ValueMember = "ID";
            chkcmbNoiNhan.Properties.DisplayMember = "Name";
            //chkcmbNoiNhan.Properties.DropDownRows = dt.Rows.Count + 1;

        }

        public void LoadDonTu(LinQ.DonTu entity)
        {
            try
            {
                if (entity.SoCongVan == null)
                {
                    tabControl.SelectTab("tabTTKH");
                    if (entity.SoNK != null)
                    {
                        txtSoNK.Text = entity.SoNK.Value.ToString();
                        txtHieuLucKy.Text = entity.HieuLucKy;
                    }
                    if (entity.DonTu_ChiTiets.SingleOrDefault().DanhBo.Length == 11)
                        txtDanhBo.Text = entity.DonTu_ChiTiets.SingleOrDefault().DanhBo.Insert(7, " ").Insert(4, " ");
                    txtHopDong.Text = entity.DonTu_ChiTiets.SingleOrDefault().HopDong;
                    txtDienThoai.Text = entity.DonTu_ChiTiets.SingleOrDefault().DienThoai;
                    txtHoTen.Text = entity.DonTu_ChiTiets.SingleOrDefault().HoTen;
                    txtDiaChi.Text = entity.DonTu_ChiTiets.SingleOrDefault().DiaChi;
                    if (entity.GiaBieu != null)
                        txtGiaBieu.Text = entity.DonTu_ChiTiets.SingleOrDefault().GiaBieu.Value.ToString();
                    if (entity.DinhMuc != null)
                        txtDinhMuc.Text = entity.DonTu_ChiTiets.SingleOrDefault().DinhMuc.Value.ToString();
                }
                else
                {
                    tabControl.SelectTab("tabCongVan");
                    txtSoCongVan.Text = entity.SoCongVan;
                    txtTongDB.Text = entity.TongDB.ToString();

                    dgvDanhBo.DataSource = entity.DonTu_ChiTiets.ToList();
                }
                txtMaDon.Text = entity.MaDon.ToString();
                dateCreateDate.Value = entity.CreateDate.Value;

                txtNoiDung.Text = entity.Name_NhomDon;
                txtVanDeKhac.Text = entity.VanDeKhac;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Clear()
        {
            txtSoCongVan.Text = "";
            txtTongDB.Text = "";
            txtMaDon.Text = "";

            //for (int i = 0; i < chkcmbDieuChinh.Properties.Items.Count; i++)
            //{
            //    chkcmbDieuChinh.Properties.Items[i].CheckState = CheckState.Unchecked;
            //}
            //for (int i = 0; i < chkcmbKhieuNai.Properties.Items.Count; i++)
            //{
            //    chkcmbKhieuNai.Properties.Items[i].CheckState = CheckState.Unchecked;
            //}
            //for (int i = 0; i < chkcmbDHN.Properties.Items.Count; i++)
            //{
            //    chkcmbDHN.Properties.Items[i].CheckState = CheckState.Unchecked;
            //}
            //txtSoNK.Text = "";
            //txtHieuLucKy.Text = "";
            txtNoiDung.Text = "";
            txtVanDeKhac.Text = "";

            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtDienThoai.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";

            _dontu = null;
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMaDon.Text.Trim() != "" && e.KeyChar == 13)
            {
                if (_cDonTu.CheckExist(int.Parse(txtMaDon.Text.Trim())) == true)
                {
                    _dontu = _cDonTu.Get(int.Parse(txtMaDon.Text.Trim()));
                    LoadDonTu(_dontu);
                }
                else
                {
                    MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clear();
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                try
                {
                    if (_dontu != null)
                    {
                        bool flag = false;//ghi nhận có chọn checkcombobox
                        if (chkcmbNoiNhan.Properties.Items.Count > 0)
                        {
                            for (int i = 0; i < chkcmbNoiNhan.Properties.Items.Count; i++)
                                if (chkcmbNoiNhan.Properties.Items[i].CheckState == CheckState.Checked)
                                {
                                    LichSuDonTu entity = new LichSuDonTu();
                                    entity.NgayChuyen = dateChuyen.Value;
                                    entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                    entity.NoiChuyen = cmbNoiChuyen.Text;
                                    entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                    entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                    entity.GhiChu = txtGhiChu.Text.Trim();
                                    entity.MaDonMoi = _dontu.MaDon;
                                    _cLichSuDonTu.Them(entity);
                                    flag = true;
                                    chkcmbNoiNhan.Properties.Items[i].CheckState = CheckState.Unchecked;
                                }
                            if (flag == false)
                            {
                                LichSuDonTu entity = new LichSuDonTu();
                                entity.NgayChuyen = dateChuyen.Value;
                                entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                entity.NoiChuyen = cmbNoiChuyen.Text;
                                //entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                //entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                entity.GhiChu = txtGhiChu.Text.Trim();
                                entity.MaDonMoi = _dontu.MaDon;
                                _cLichSuDonTu.Them(entity);
                            }
                        }
                        else
                        {
                            LichSuDonTu entity = new LichSuDonTu();
                            entity.NgayChuyen = dateChuyen.Value;
                            entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                            entity.NoiChuyen = cmbNoiChuyen.Text;
                            //entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                            //entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                            entity.GhiChu = txtGhiChu.Text.Trim();
                            entity.MaDonMoi = _dontu.MaDon;
                            _cLichSuDonTu.Them(entity);
                        }
                        dgvLichSuDonTu.DataSource = _cLichSuDonTu.GetDS("DonTu", _dontu.MaDon);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (e.Button == MouseButtons.Right && (_dontu != null))
            {
                contextMenuStrip1.Show(dgvLichSuDonTu, new Point(e.X, e.Y));
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (_cLichSuDonTu.Xoa(_cLichSuDonTu.Get(int.Parse(dgvLichSuDonTu.CurrentRow.Cells["ID"].Value.ToString()))))
                {
                    dgvLichSuDonTu.DataSource = _cLichSuDonTu.GetDS("TXL", _dontu.MaDon);
                }
            }
        }

        private void dgvLichSuDonTu_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvLichSuDonTu.Columns[e.ColumnIndex].Name == "HoanLenh" && bool.Parse(e.FormattedValue.ToString()) != bool.Parse(dgvLichSuDonTu[e.ColumnIndex, e.RowIndex].Value.ToString()))
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {
                    LichSuDonTu entity = _cLichSuDonTu.Get(int.Parse(dgvLichSuDonTu["ID", e.RowIndex].Value.ToString()));
                    entity.HoanLenh = bool.Parse(e.FormattedValue.ToString());
                    if (entity.HoanLenh == true)
                        entity.NgayHoanLenh = DateTime.Now;
                    else
                        entity.NgayHoanLenh = null;
                    if (_cLichSuDonTu.Sua(entity))
                        MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtSoNK_TextChanged(object sender, EventArgs e)
        {
            if (txtSoNK.Text.Trim() != "")
                txtDM.Text = (int.Parse(txtSoNK.Text.Trim()) * 4).ToString();
        }

        private void txtSoNK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void chkcmbNoiNhan_EditValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < chkcmbNoiNhan.Properties.Items.Count; i++)
                if (chkcmbNoiNhan.Properties.Items[i].CheckState == CheckState.Checked && chkcmbNoiNhan.Properties.Items[i].Value.ToString() == "1")
                {
                    DataTable dt = new DataTable();
                    
                    //if(CTaiKhoan.ToKH==true)
                        dt = _cTaiKhoan.GetDS_KTXM("TKH");
                    //else if(CTaiKhoan.ToKH==true)
                    //    dt = _cTaiKhoan.GetDS_KTXM("TXL");
                    //else if(CTaiKhoan.ToKH==true)
                    //    dt = _cTaiKhoan.GetDS_KTXM("TBC");
                    chkcmbNoiNhanKTXM.Properties.DataSource = dt;
                    chkcmbNoiNhanKTXM.Properties.ValueMember = "MaU";
                    chkcmbNoiNhanKTXM.Properties.DisplayMember = "HoTen";
                }
        }
    }
}
