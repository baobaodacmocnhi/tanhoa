using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.ToKhachHang;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL.DonTu;
using KTKS_DonKH.GUI.ToXuLy;
using KTKS_DonKH.GUI.ToBamChi;

namespace KTKS_DonKH.GUI.ToKhachHang
{
    public partial class frmCapNhatDonTKH : Form
    {
        string _mnu = "mnuCapNhatDon";
        CLoaiDon _cLoaiDon = new CLoaiDon();
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();
        DonKH _donkh = new DonKH();
        CLichSuDonTu _cLichSuDonTu = new CLichSuDonTu();
        CNoiChuyen _cNoiChuyen = new CNoiChuyen();
        CPhongBanDoi _cPhongBanDoi = new CPhongBanDoi();
        DataSet _dsNoiChuyen = new DataSet("NoiChuyen");
        bool _flagFirst = false;

        public frmCapNhatDonTKH()
        {
            InitializeComponent();
        }

        private void frmCapNhatDonKH_Load(object sender, EventArgs e)
        {
            dgvLichSuDonTu.AutoGenerateColumns = false;
            dgvLichSuDonTu_DCBD.AutoGenerateColumns = false;
            dgvLichSuDon.AutoGenerateColumns = false;
            dataGridView1.AutoGenerateColumns = false;

            cmbLD.DataSource = _cLoaiDon.LoadDSLoaiDon();
            cmbLD.DisplayMember = "TenLD";
            cmbLD.ValueMember = "MaLD";
            cmbLD.SelectedIndex = -1;

            cmbNoiChuyen.DataSource = _cNoiChuyen.GetDS("TKH");
            cmbNoiChuyen.DisplayMember = "Name";
            cmbNoiChuyen.ValueMember = "ID";
            cmbNoiChuyen.SelectedIndex = -1;

            DataTable dt = new DataTable();
            dt = _cTaiKhoan.GetDS_KTXM("TKH");
            dt.TableName = "1";//Kiểm Tra Xác Minh
            _dsNoiChuyen.Tables.Add(dt);
            ///
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
            ///
            dt = new DataTable();
            dt = _cTaiKhoan.GetDS_ThuKy("TVP");
            ///
            //DataRow dr2 = dt.NewRow();
            //dr2["MaU"] = "0";
            //dr2["HoTen"] = "Tổ Xử Lý";
            //dt.Rows.Add(dr2);
            /////
            //dr2 = dt.NewRow();
            //dr2["MaU"] = "0";
            //dr2["HoTen"] = "Tổ Bấm Chì";
            //dt.Rows.Add(dr2);
            /////
            //dr2 = dt.NewRow();
            //dr2["MaU"] = "0";
            //dr2["HoTen"] = "Tờ Trình Trình Phòng";
            //dt.Rows.Add(dr2);
            /////
            //dr2 = dt.NewRow();
            //dr2["MaU"] = "0";
            //dr2["HoTen"] = "Trình Phòng Xem Xét";
            //dt.Rows.Add(dr2);
            /////
            //dr2 = dt.NewRow();
            //dr2["MaU"] = "0";
            //dr2["HoTen"] = "Hẹn Định Mức 3 Ngày";
            //dt.Rows.Add(dr2);
            /////
            //dr2 = dt.NewRow();
            //dr2["MaU"] = "0";
            //dr2["HoTen"] = "Hẹn Định Mức Nhà Trọ";
            //dt.Rows.Add(dr2);
            /////
            //dr2 = dt.NewRow();
            //dr2["MaU"] = "0";
            //dr2["HoTen"] = "Hẹn Kiểm Định";
            //dt.Rows.Add(dr2);
            ///
            for (int i = 0; i < _dsNoiChuyen.Tables["6"].Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["MaU"] = _dsNoiChuyen.Tables["6"].Rows[i]["ID"];
                dr["HoTen"] = _dsNoiChuyen.Tables["6"].Rows[i]["Name"];
                dt.Rows.Add(dr);
            }
            DataTable dt2 = _cNoiChuyen.GetDS_CT(9);
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["MaU"] = dt2.Rows[i]["ID"];
                dr["HoTen"] = dt2.Rows[i]["Name"];
                dt.Rows.Add(dr);
            }
            ///
            //dr2 = dt.NewRow();
            //dr2["MaU"] = "0";
            //dr2["HoTen"] = "Khác";
            //dt.Rows.Add(dr2);
            /////
            //dr2 = dt.NewRow();
            //dr2["MaU"] = "0";
            //dr2["HoTen"] = "Tiếp Kết";
            //dt.Rows.Add(dr2);
            /////
            //dr2 = dt.NewRow();
            //dr2["MaU"] = "0";
            //dr2["HoTen"] = "Xếp Đơn";
            //dt.Rows.Add(dr2);
            dt.TableName = "9";//Tiến Trình
            _dsNoiChuyen.Tables.Add(dt);
            _flagFirst = true;
        }

        public void Clear()
        {
            cmbLD.SelectedIndex = -1;
            txtMaDon.Text = "";
            txtNgayNhan.Text = "";
            txtNoiDung.Text = "";
            txtSoCongVan.Text = "";
            ///
            txtDanhBo.Text = "";
            txtHopDong.Text = "";
            txtDienThoai.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtGiaBieu.Text = "";
            txtDinhMuc.Text = "";
        }

        public void LoadDonTKH(DonKH dontkh)
        {
            cmbLD.SelectedValue = dontkh.MaLD.Value;
            txtSoCongVan.Text = dontkh.SoCongVan;
            txtMaDon.Text = dontkh.MaDon.ToString().Insert(dontkh.MaDon.ToString().Length - 2, "-");
            txtNgayNhan.Text = dontkh.CreateDate.Value.ToString("dd/MM/yyyy");
            txtNoiDung.Text = dontkh.NoiDung;

            txtDanhBo.Text = dontkh.DanhBo;
            txtHopDong.Text = dontkh.HopDong;
            txtDienThoai.Text = dontkh.DienThoai;
            txtHoTen.Text = dontkh.HoTen;
            txtDiaChi.Text = dontkh.DiaChi;
            txtGiaBieu.Text = dontkh.GiaBieu;
            txtDinhMuc.Text = dontkh.DinhMuc;
            ///
            dgvLichSuDon.DataSource = _cLichSuDonTu.GetDS_3To(dontkh.DanhBo);
            ///
            dgvLichSuDonTu.DataSource = _cLichSuDonTu.GetDS("TKH", dontkh.MaDon);
            dgvLichSuDonTu_DCBD.DataSource = _cLichSuDonTu.GetDS_DCBD(txtDanhBo.Text.Trim());
            dateChuyen.Value = DateTime.Now;
            cmbNoiChuyen.SelectedIndex = -1;
            txtGhiChu.Text = "";
            ///
            dataGridView1.DataSource = _cLichSuDonTu.GetDS_Old("TKH", dontkh.MaDon);
        }

        private void btnNhapNhieuDB_Click(object sender, EventArgs e)
        {
            frmNhapNhieuDBTKH frm = new frmNhapNhieuDBTKH();
            frm.ShowDialog();
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDon.Text.Trim() != "")
            {
                if (_cDonKH.CheckExist(decimal.Parse(txtMaDon.Text.Trim().Replace("-", ""))) == true)
                {
                    _donkh = _cDonKH.Get(decimal.Parse(txtMaDon.Text.Trim().Replace("-", "")));
                    LoadDonTKH(_donkh);
                }
                else
                {
                    MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clear();
                }
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (_cLichSuDonTu.Xoa(_cLichSuDonTu.Get(int.Parse(dgvLichSuDonTu.CurrentRow.Cells["ID"].Value.ToString()))))
                {
                    dgvLichSuDonTu.DataSource = _cLichSuDonTu.GetDS("TKH", _donkh.MaDon);
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
                        case "1"://Kiểm Tra Xác Minh
                            chkcmbNoiNhan.Properties.DataSource = _dsNoiChuyen.Tables["1"];
                            chkcmbNoiNhan.Properties.DisplayMember = "HoTen";
                            chkcmbNoiNhan.Properties.ValueMember = "MaU";
                            break;
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
                        case "9"://Tiến Trình
                            chkcmbNoiNhan.Properties.DataSource = _dsNoiChuyen.Tables["9"];
                            chkcmbNoiNhan.Properties.DisplayMember = "HoTen";
                            chkcmbNoiNhan.Properties.ValueMember = "MaU";
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
                if (chkcmbNoiNhan.Properties.Items.Count > 0)
                {
                    bool flag = false;//ghi nhận có chọn checkcombobox
                    for (int i = 0; i < chkcmbNoiNhan.Properties.Items.Count; i++)
                        if (chkcmbNoiNhan.Properties.Items[i].CheckState == CheckState.Checked)
                        {
                            if (cmbNoiChuyen.SelectedValue.ToString() == "1")///KTXM
                            {
                                //LichSuChuyenKTXM lichsuchuyenkt = new LichSuChuyenKTXM();
                                //lichsuchuyenkt.NgayChuyen = dateChuyen.Value;
                                //lichsuchuyenkt.NguoiDi = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                //lichsuchuyenkt.GhiChuChuyen = txtGhiChu.Text.Trim();
                                //lichsuchuyenkt.MaDon = _donkh.MaDon;
                                //_cLichSuDonTu.Them(lichsuchuyenkt);

                                _donkh.NguoiDi_KTXM = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                                _donkh.NgayChuyen_KTXM = dateChuyen.Value;
                                _donkh.GhiChuChuyen_KTXM = txtGhiChu.Text.Trim();
                                _cDonKH.Sua(_donkh);
                            }
                            LichSuDonTu entity = new LichSuDonTu();
                            entity.NgayChuyen = dateChuyen.Value;
                            entity.ID_NoiChuyen = int.Parse(cmbNoiChuyen.SelectedValue.ToString());
                            entity.NoiChuyen = cmbNoiChuyen.Text;
                            entity.ID_NoiNhan = int.Parse(chkcmbNoiNhan.Properties.Items[i].Value.ToString());
                            entity.NoiNhan = chkcmbNoiNhan.Properties.Items[i].ToString();
                            entity.GhiChu = txtGhiChu.Text.Trim();
                            entity.MaDon = _donkh.MaDon;
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
                        entity.MaDon = _donkh.MaDon;
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
                    entity.MaDon = _donkh.MaDon;
                    _cLichSuDonTu.Them(entity);
                }
                dgvLichSuDonTu.DataSource = _cLichSuDonTu.GetDS("TKH", _donkh.MaDon);
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
            if (e.Button == MouseButtons.Right && (_donkh != null))
            {
                contextMenuStrip1.Show(dgvLichSuDonTu, new Point(e.X, e.Y));
            }
        }

        private void dgvLichSuDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLichSuDon.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void dgvLichSuDon_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvLichSuDon.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                if (dgvLichSuDon["MaDon", dgvLichSuDon.CurrentRow.Index].Value.ToString().ToUpper().Contains("TKH"))
                {
                    frmNhanDonTKH frm = new frmNhanDonTKH(decimal.Parse(dgvLichSuDon["MaDon", dgvLichSuDon.CurrentRow.Index].Value.ToString().Substring(3)));
                    frm.ShowDialog();
                }
                else
                    if (dgvLichSuDon["MaDon", dgvLichSuDon.CurrentRow.Index].Value.ToString().ToUpper().Contains("TXL"))
                    {
                        frmNhanDonTXL frm = new frmNhanDonTXL(decimal.Parse(dgvLichSuDon["MaDon", dgvLichSuDon.CurrentRow.Index].Value.ToString().Substring(3)));
                        frm.ShowDialog();
                    }
                    else

                        if (dgvLichSuDon["MaDon", dgvLichSuDon.CurrentRow.Index].Value.ToString().ToUpper().Contains("TBC"))
                        {
                            frmNhanDonTBC frm = new frmNhanDonTBC(decimal.Parse(dgvLichSuDon["MaDon", dgvLichSuDon.CurrentRow.Index].Value.ToString().Substring(3)));
                            frm.ShowDialog();
                        }
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            dgvLichSuDon.DataSource = _cLichSuDonTu.GetDS_3To(txtDanhBo.Text.Trim());
            dgvLichSuDonTu_DCBD.DataSource = _cLichSuDonTu.GetDS_DCBD(txtDanhBo.Text.Trim());
        }

    }
}
