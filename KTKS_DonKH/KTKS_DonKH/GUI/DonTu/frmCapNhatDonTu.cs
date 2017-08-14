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
        DataSet _dsNoiChuyen = new DataSet("NoiChuyen");
        bool _flagFirst = false;

        public frmCapNhatDonTu()
        {
            InitializeComponent();
        }

        private void frmCapNhatDonTu_Load(object sender, EventArgs e)
        {
            dgvLichSuDonTu.AutoGenerateColumns = false;

            cmbNoiChuyen.DataSource = _cNoiChuyen.GetDS("DonTu");
            cmbNoiChuyen.DisplayMember = "Name";
            cmbNoiChuyen.ValueMember = "ID";
            cmbNoiChuyen.SelectedIndex = -1;

            _flagFirst = true;

            DataTable dt = new DataTable();
            dt = new DataTable();
            dt = _cTaiKhoan.GetDS_ThuKy("TKH");
            dt.TableName = "2";//Tổ Khách Hàng
            _dsNoiChuyen.Tables.Add(dt);
            ///
            dt = new DataTable();
            dt = _cTaiKhoan.GetDS_ThuKy("TXL");
            dt.TableName = "3";//Tổ Xử Lý
            _dsNoiChuyen.Tables.Add(dt);
            ///
            dt = new DataTable();
            dt = _cTaiKhoan.GetDS_ThuKy("TBC");
            dt.TableName = "4";//Tổ Bấm Chì
            _dsNoiChuyen.Tables.Add(dt);
            ///
            dt = new DataTable();
            dt = _cTaiKhoan.GetDS_ThuKy("TVP");
            dt.TableName = "5";//Tổ Văn Phòng
            _dsNoiChuyen.Tables.Add(dt);
            ///
            dt = new DataTable();
            dt = _cPhongBanDoi.GetDS();
            dt.TableName = "6";//Phòng Ban Đội Khác
            _dsNoiChuyen.Tables.Add(dt);
        }

        public void LoadDonTu(LinQ.DonTu entity)
        {
            if (entity.SoCongVan != null)
            {
                txtSoCongVan.Text = entity.SoCongVan;
                txtTongDB.Text = entity.TongDB.ToString();
            }
            dateCreateDate.Value = entity.CreateDate.Value;

            //chkcmbDieuChinh.SetEditValue(entity.ID_NhomDon);
            //chkcmbKhieuNai.SetEditValue(entity.ID_NhomDon);
            //chkcmbDHN.SetEditValue(entity.ID_NhomDon);

            //if (entity.SoNK != null)
            //{
            //    txtSoNK.Text = entity.SoNK.Value.ToString();
            //    txtHieuLucKy.Text = entity.HieuLucKy;
            //}
            txtNoiDung.Text = entity.Name_NhomDon;
            txtVanDeKhac.Text = entity.VanDeKhac;
            if (entity.DanhBo.Length == 11)
                txtDanhBo.Text = entity.DanhBo.Insert(7, " ").Insert(4, " ");
            txtHopDong.Text = entity.HopDong;
            txtDienThoai.Text = entity.DienThoai;
            txtHoTen.Text = entity.HoTen;
            txtDiaChi.Text = entity.DiaChi;
            if (entity.GiaBieu != null)
                txtGiaBieu.Text = entity.GiaBieu.Value.ToString();
            if (entity.DinhMuc != null)
                txtDinhMuc.Text = entity.DinhMuc.Value.ToString();
            
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

        private void cmbNoiChuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_flagFirst == true)
            {
                if (cmbNoiChuyen.SelectedIndex != -1)
                {
                    switch (cmbNoiChuyen.SelectedValue.ToString())
                    {
                        case "2"://Tổ Khách Hàng
                            chkcmbNoiNhan.Properties.DataSource = _dsNoiChuyen.Tables["2"];
                            chkcmbNoiNhan.Properties.DisplayMember = "HoTen";
                            chkcmbNoiNhan.Properties.ValueMember = "MaU";
                            break;
                        case "3"://Tổ Xử Lý
                            chkcmbNoiNhan.Properties.DataSource = _dsNoiChuyen.Tables["3"];
                            chkcmbNoiNhan.Properties.DisplayMember = "HoTen";
                            chkcmbNoiNhan.Properties.ValueMember = "MaU";
                            break;
                        case "4"://Tổ Bấm Chì
                            chkcmbNoiNhan.Properties.DataSource = _dsNoiChuyen.Tables["4"];
                            chkcmbNoiNhan.Properties.DisplayMember = "HoTen";
                            chkcmbNoiNhan.Properties.ValueMember = "MaU";
                            break;
                        case "5"://Tổ Văn Phòng
                            chkcmbNoiNhan.Properties.DataSource = _dsNoiChuyen.Tables["5"];
                            chkcmbNoiNhan.Properties.DisplayMember = "HoTen";
                            chkcmbNoiNhan.Properties.ValueMember = "MaU";
                            break;
                        case "6"://Phòng Ban Đội Khác
                            chkcmbNoiNhan.Properties.DataSource = _dsNoiChuyen.Tables["6"];
                            chkcmbNoiNhan.Properties.DisplayMember = "Name";
                            chkcmbNoiNhan.Properties.ValueMember = "ID";
                            break;
                        default:
                            chkcmbNoiNhan.Properties.DataSource = null;
                            break;
                    }
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
    }
}
