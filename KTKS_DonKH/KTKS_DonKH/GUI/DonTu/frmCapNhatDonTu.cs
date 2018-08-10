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
        DonTu_ChiTiet _dontu_ChiTiet = null;

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
                txtMaDon.Text = entity.MaDon.ToString();
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
                    txtMaDon.Text += "." + _dontu_ChiTiet.STT;
                    txtSoCongVan.Text = entity.SoCongVan;
                    txtTongDB.Text = entity.TongDB.ToString();

                    dgvDanhBo.DataSource = entity.DonTu_ChiTiets.ToList();
                }

                dateCreateDate.Value = entity.CreateDate.Value;

                txtNoiDung.Text = entity.Name_NhomDon;
                txtVanDeKhac.Text = entity.VanDeKhac;

                LoadLichSu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadLichSu()
        {
            if (_dontu != null)
                if (_dontu_ChiTiet == null)
                    dgvLichSuDonTu.DataSource = _cDonTu.getDS_LichSu(_dontu.MaDon, 1);
                else
                    dgvLichSuDonTu.DataSource = _cDonTu.getDS_LichSu(_dontu_ChiTiet.MaDon.Value, _dontu_ChiTiet.STT.Value);
        }

        public void Clear()
        {
            txtSoCongVan.Text = "";
            txtTongDB.Text = "";
            txtMaDon.Text = "";

            txtSoNK.Text = "";
            txtHieuLucKy.Text = "";
            txtDM.Text = "";
            txtNoiDung.Text = "";
            txtVanDeKhac.Text = "";

            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtDienThoai.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
            dgvDanhBo.DataSource = null;
            dgvDanhBo.Rows.Clear();

            _dontu = null;
            _dontu_ChiTiet = null;
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMaDon.Text.Trim() != "" && e.KeyChar == 13)
            {
                string MaDon = txtMaDon.Text.Trim();
                Clear();
                if (MaDon.Contains(".") == true)
                {
                    string[] MaDons = MaDon.Split('.');
                    _dontu = _cDonTu.get(int.Parse(MaDons[0]));
                    _dontu_ChiTiet = _cDonTu.get_ChiTiet(int.Parse(MaDons[0]), int.Parse(MaDons[1]));
                }
                else
                {
                    _dontu = _cDonTu.get(int.Parse(MaDon));
                }
                
                if (_dontu!=null)
                {
                    if (_dontu.SoCongVan != null && _dontu_ChiTiet == null)
                    {
                        MessageBox.Show("Đơn Công Văn, vui lòng nhập thêm số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    LoadDonTu(_dontu);
                }
                else
                {
                    Clear();
                    MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);  
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
                                    //đi KTXM
                                    if (chkcmbNoiNhan.Properties.Items[i].Value.ToString() == "1")
                                    {
                                        DonTu_LichSu entity = new DonTu_LichSu();
                                        entity.NgayChuyen = dateChuyen.Value;
                                        entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                        entity.NoiChuyen = cmbNoiChuyen.Text;
                                        entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                        entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                        entity.NoiDung = txtNoiDung_LichSu.Text.Trim();
                                        entity.MaDon = _dontu.MaDon;
                                        if (_dontu_ChiTiet == null)
                                            entity.STT = 1;
                                        else
                                            entity.STT = _dontu_ChiTiet.STT;
                                        for (int j = 0; j < chkcmbNoiNhanKTXM.Properties.Items.Count; j++)
                                            if (chkcmbNoiNhanKTXM.Properties.Items[j].CheckState == CheckState.Checked)
                                            {
                                                entity.ID_KTXM = int.Parse(chkcmbNoiNhanKTXM.Properties.Items[j].Value.ToString());
                                                entity.KTXM = chkcmbNoiNhanKTXM.Properties.Items[j].ToString();
                                                _cDonTu.Them(entity);
                                            }
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
                                        entity.MaDon = _dontu.MaDon;
                                        if (_dontu_ChiTiet == null)
                                            entity.STT = 1;
                                        else
                                            entity.STT = _dontu_ChiTiet.STT;
                                        _cDonTu.Them(entity);
                                    }
                                    flag = true;
                                    chkcmbNoiNhan.Properties.Items[i].CheckState = CheckState.Unchecked;
                                }
                            if (flag == false)
                            {
                                DonTu_LichSu entity = new DonTu_LichSu();
                                entity.NgayChuyen = dateChuyen.Value;
                                entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                                entity.NoiChuyen = cmbNoiChuyen.Text;
                                //entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                //entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                                entity.NoiDung = txtNoiDung_LichSu.Text.Trim();
                                entity.MaDon = _dontu.MaDon;
                                if (_dontu_ChiTiet == null)
                                    entity.STT = 1;
                                else
                                    entity.STT = _dontu_ChiTiet.STT;
                                _cDonTu.Them(entity);
                            }
                        }
                        LoadLichSu();
                        //dgvLichSuDonTu.DataSource = _cLichSuDonTu.GetDS("DonTu", _dontu.MaDon);
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
                if (_cDonTu.Xoa(_cDonTu.get_LichSu(int.Parse(dgvLichSuDonTu.CurrentRow.Cells["ID"].Value.ToString()))))
                {
                    LoadLichSu();
                }
            }
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
