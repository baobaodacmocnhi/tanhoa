using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.QuanTri
{
    public partial class frmTaiKhoan : Form
    {
        string _mnu = "mnuNguoiDung";
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();
        CPhanQuyenNguoiDung _cPhanQuyenNguoiDung = new CPhanQuyenNguoiDung();
        CNhom _cNhom = new CNhom();
        CMenu _cMenu = new CMenu();
        CTo _cTo = new CTo();
        int _selectedindex = -1;
        BindingList<User> _blNguoiDung;

        public frmTaiKhoan()
        {
            InitializeComponent();
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            if (CTaiKhoan.Admin)
            {
                chkPhoGiamDoc.Visible = true;
                chkAn.Visible = true;
                _blNguoiDung = new BindingList<User>(_cTaiKhoan.GetDS());
            }
            else
            {
                chkPhoGiamDoc.Visible = false;
                chkAn.Visible = false;
                _blNguoiDung = new BindingList<User>(_cTaiKhoan.GetDSExceptMaND(CTaiKhoan.MaUser));
            }
            dgvDSTaiKhoan.AutoGenerateColumns = false;
            dgvDSTaiKhoan.DataSource = _blNguoiDung;

            cmbTo.DataSource = _cTo.GetDS();
            cmbTo.DisplayMember = "TenTo";
            cmbTo.ValueMember = "MaTo";

            cmbNhom.DataSource = _cNhom.GetDS();
            cmbNhom.DisplayMember = "TenNhom";
            cmbNhom.ValueMember = "MaNhom";
        }

        private void Clear()
        {
            txtHoTen.Text = "";
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            _selectedindex = -1;
            chkPhoGiamDoc.Checked = false;
            chkTruongPhong.Checked = false;
            chkToTruong.Checked = false;
            chkAn.Checked = false;
            chkKTXM.Checked = false;
            chkBamChi.Checked = false;
            if (CTaiKhoan.Admin)
            {
                _blNguoiDung = new BindingList<User>(_cTaiKhoan.GetDS());
            }
            else
            {
                _blNguoiDung = new BindingList<User>(_cTaiKhoan.GetDSExceptMaND(CTaiKhoan.MaUser));
            }
            dgvDSTaiKhoan.DataSource = _blNguoiDung;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
            {
                if (txtHoTen.Text.Trim() != "" && txtTaiKhoan.Text.Trim() != "" && txtMatKhau.Text.Trim() != "")
                {
                    User nguoidung = new User();
                    nguoidung.HoTen = txtHoTen.Text.Trim();
                    nguoidung.TaiKhoan = txtTaiKhoan.Text.Trim();
                    nguoidung.MatKhau = txtMatKhau.Text.Trim();
                    nguoidung.STT = _cTaiKhoan.GetMaxSTT() + 1;
                    nguoidung.MaKiemBamChi = txtMaKiemBamChi.Text.Trim();
                    nguoidung.MaTo = int.Parse(cmbTo.SelectedValue.ToString());
                    nguoidung.MaNhom = int.Parse(cmbNhom.SelectedValue.ToString());
                    nguoidung.PhoGiamDoc = chkPhoGiamDoc.Checked;
                    nguoidung.An = chkAn.Checked;
                    nguoidung.TruongPhong = chkTruongPhong.Checked;
                    nguoidung.ToTruong = chkToTruong.Checked;
                    nguoidung.KTXM = chkKTXM.Checked;
                    nguoidung.BamChi = chkBamChi.Checked;
                    ///tự động thêm quyền cho người mới
                    foreach (var item in _cMenu.GetDS())
                    {
                        PhanQuyenNguoiDung phanquyennguoidung = new PhanQuyenNguoiDung();
                        phanquyennguoidung.MaMenu = item.MaMenu;
                        phanquyennguoidung.MaND = nguoidung.MaU;
                        nguoidung.PhanQuyenNguoiDungs.Add(phanquyennguoidung);
                    }

                    if (_cTaiKhoan.Them(nguoidung))
                        MessageBox.Show("Thêm Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Clear();
                }
                else
                    MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    if (_selectedindex != -1)
                    {
                        User nguoidung = _cTaiKhoan.GetByID(int.Parse(dgvDSTaiKhoan["MaU", _selectedindex].Value.ToString()));
                        ///xóa quan hệ 1 nhiều
                        //_cPhanQuyenNguoiDung.Xoa(nguoidung.TT_PhanQuyenNguoiDungs.ToList());
                        nguoidung.An = true;
                        _cTaiKhoan.Sua(nguoidung);
                        Clear();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Lỗi, Vui lòng chọn Người Dùng cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
            {
                if (_selectedindex != -1)
                {
                    User nguoidung = _cTaiKhoan.GetByID(int.Parse(dgvDSTaiKhoan["MaU", _selectedindex].Value.ToString()));
                    nguoidung.HoTen = txtHoTen.Text.Trim();
                    nguoidung.TaiKhoan = txtTaiKhoan.Text.Trim();
                    nguoidung.MatKhau = txtMatKhau.Text.Trim();
                    nguoidung.MaTo = (int)cmbTo.SelectedValue;
                    nguoidung.MaNhom = (int)cmbNhom.SelectedValue;
                    nguoidung.PhoGiamDoc = chkPhoGiamDoc.Checked;
                    nguoidung.An = chkAn.Checked;
                    nguoidung.TruongPhong = chkTruongPhong.Checked;
                    nguoidung.ToTruong = chkToTruong.Checked;
                    nguoidung.KTXM = chkKTXM.Checked;
                    nguoidung.BamChi = chkBamChi.Checked;

                    _cTaiKhoan.Sua(nguoidung);
                    DataTable dt = ((DataView)gridView.DataSource).Table;
                    foreach (DataRow item in dt.Rows)
                    {
                        PhanQuyenNguoiDung phanquyennguoidung = _cPhanQuyenNguoiDung.GetByMaMenuMaND(int.Parse(item["MaMenu"].ToString()), nguoidung.MaU);
                        if (phanquyennguoidung.Xem != bool.Parse(item["Xem"].ToString()) || phanquyennguoidung.Them != bool.Parse(item["Them"].ToString()) ||
                            phanquyennguoidung.Sua != bool.Parse(item["Sua"].ToString()) || phanquyennguoidung.Xoa != bool.Parse(item["Xoa"].ToString()) ||
                            phanquyennguoidung.QuanLy != bool.Parse(item["QuanLy"].ToString()))
                        {
                            phanquyennguoidung.Xem = bool.Parse(item["Xem"].ToString());
                            phanquyennguoidung.Them = bool.Parse(item["Them"].ToString());
                            phanquyennguoidung.Sua = bool.Parse(item["Sua"].ToString());
                            phanquyennguoidung.Xoa = bool.Parse(item["Xoa"].ToString());
                            phanquyennguoidung.QuanLy = bool.Parse(item["QuanLy"].ToString());
                            _cPhanQuyenNguoiDung.Sua(phanquyennguoidung);
                        }
                    }
                    Clear();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvDSTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _selectedindex = e.RowIndex;
                txtHoTen.Text = dgvDSTaiKhoan["HoTen", e.RowIndex].Value.ToString();
                txtTaiKhoan.Text = dgvDSTaiKhoan["TaiKhoan", e.RowIndex].Value.ToString();
                txtMatKhau.Text = dgvDSTaiKhoan["MatKhau", e.RowIndex].Value.ToString();
                txtMaKiemBamChi.Text = dgvDSTaiKhoan["MaKiemBamChi", e.RowIndex].Value.ToString();
                if (dgvDSTaiKhoan["MaTo", e.RowIndex].Value != null)
                    cmbTo.SelectedValue = int.Parse(dgvDSTaiKhoan["MaTo", e.RowIndex].Value.ToString());
                if (dgvDSTaiKhoan["MaNhom", e.RowIndex].Value != null)
                    cmbNhom.SelectedValue = int.Parse(dgvDSTaiKhoan["MaNhom", e.RowIndex].Value.ToString());
                chkPhoGiamDoc.Checked = bool.Parse(dgvDSTaiKhoan["PhoGiamDoc", e.RowIndex].Value.ToString());
                chkAn.Checked = bool.Parse(dgvDSTaiKhoan["An", e.RowIndex].Value.ToString());
                chkTruongPhong.Checked = bool.Parse(dgvDSTaiKhoan["TruongPhong", e.RowIndex].Value.ToString());
                chkToTruong.Checked = bool.Parse(dgvDSTaiKhoan["ToTruong", e.RowIndex].Value.ToString());
                chkKTXM.Checked = bool.Parse(dgvDSTaiKhoan["KTXM", e.RowIndex].Value.ToString());
                chkBamChi.Checked = bool.Parse(dgvDSTaiKhoan["BamChi", e.RowIndex].Value.ToString());
                if (CTaiKhoan.Admin)
                    gridControl.DataSource = _cPhanQuyenNguoiDung.GetDSByMaND(true, int.Parse(dgvDSTaiKhoan["MaU", e.RowIndex].Value.ToString()));
                else
                    gridControl.DataSource = _cPhanQuyenNguoiDung.GetDSByMaND(false, int.Parse(dgvDSTaiKhoan["MaU", e.RowIndex].Value.ToString()));
            }
            catch (Exception)
            {
            }
        }

        private void dgvDSTaiKhoan_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDSTaiKhoan.RowCount>0)
            {
                User taikhoan = _cTaiKhoan.GetByID(int.Parse(dgvDSTaiKhoan["MaU", e.RowIndex].Value.ToString()));
                taikhoan.ToKH = bool.Parse(dgvDSTaiKhoan["ToKH", e.RowIndex].Value.ToString());
                taikhoan.ToXL = bool.Parse(dgvDSTaiKhoan["ToXL", e.RowIndex].Value.ToString());
                taikhoan.ToBC = bool.Parse(dgvDSTaiKhoan["ToBC", e.RowIndex].Value.ToString());
                taikhoan.ToVP = bool.Parse(dgvDSTaiKhoan["ToVP", e.RowIndex].Value.ToString());
                _cTaiKhoan.Sua(taikhoan);
            }
        }

        private void dgvDSTaiKhoan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSTaiKhoan.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        int rowIndexFromMouseDown;
        DataGridViewRow rw;
        private void dgvDSTaiKhoan_DragDrop(object sender, DragEventArgs e)
        {
            int rowIndexOfItemUnderMouseToDrop;
            Point clientPoint = dgvDSTaiKhoan.PointToClient(new Point(e.X, e.Y));
            rowIndexOfItemUnderMouseToDrop = dgvDSTaiKhoan.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            if (e.Effect == DragDropEffects.Move)
            {
                var item = this._blNguoiDung[rowIndexFromMouseDown];
                _blNguoiDung.RemoveAt(rowIndexFromMouseDown);
                _blNguoiDung.Insert(rowIndexOfItemUnderMouseToDrop, item);

                ///update STT dô database
                for (int i = 0; i < _blNguoiDung.Count; i++)
                {
                    _blNguoiDung[i].STT = i + 1;
                }
                _cTaiKhoan.SubmitChanges();
            }
        }

        private void dgvDSTaiKhoan_DragEnter(object sender, DragEventArgs e)
        {
            if (dgvDSTaiKhoan.SelectedRows.Count > 0)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void dgvDSTaiKhoan_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvDSTaiKhoan.SelectedRows.Count == 1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    rw = dgvDSTaiKhoan.SelectedRows[0];
                    rowIndexFromMouseDown = dgvDSTaiKhoan.SelectedRows[0].Index;
                    dgvDSTaiKhoan.DoDragDrop(rw, DragDropEffects.Move);
                }
            }
        }

        private void gridView_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Name == "ToanQuyen")
                if (bool.Parse(e.Value.ToString()))
                {
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["Xem"], "True");
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["Them"], "True");
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["Sua"], "True");
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["Xoa"], "True");
                }
                else
                {
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["Xem"], "False");
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["Them"], "False");
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["Sua"], "False");
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["Xoa"], "False");
                }
        }

        

    }
}
