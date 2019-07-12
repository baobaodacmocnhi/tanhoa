using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrungTamKhachHang.DAL.QuanTri;
using TrungTamKhachHang.DAL.LichDocSoThuTien;
using TrungTamKhachHang.LinQ;

namespace TrungTamKhachHang.GUI.LichDocSoThuTien
{
    public partial class frmLichThuTien : Form
    {
        string _mnu = "mnuLichThuTien";
        CLichThuTien _cLTT = new CLichThuTien();
        Lich_ThuTien _thutien = null;

        DateTimePicker _dtp = new DateTimePicker();
        Rectangle _rectangle;

        public frmLichThuTien()
        {
            InitializeComponent();

            dgvDot.Controls.Add(_dtp);
            _dtp.Visible = false;
            _dtp.Format = DateTimePickerFormat.Custom;
            _dtp.CustomFormat = "dd/MM/yyyy";
            _dtp.TextChanged += new EventHandler(dtp_TextChanged);
        }

        void dtp_TextChanged(object sender, EventArgs e)
        {
            dgvDot.CurrentCell.Value = _dtp.Text;
        }

        private void frmLichThuTien_Load(object sender, EventArgs e)
        {
            dgvKy.AutoGenerateColumns = false;
            dgvDot.AutoGenerateColumns = false;

            dgvKy.DataSource = _cLTT.getDS();
        }

        public void Clear()
        {
            txtKy.Text = "";
            txtNam.Text = "";
            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;
            _thutien = null;
            dgvKy.DataSource = _cLTT.getDS();
            dgvDot.DataSource = null;
        }

        public void FillEntity(Lich_ThuTien thutien)
        {
            txtKy.Text = thutien.Ky.Value.ToString();
            txtNam.Text = thutien.Nam.Value.ToString();
            dateTu.Value = thutien.TuNgay.Value;
            dateDen.Value = thutien.DenNgay.Value;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CUser.CheckQuyen(_mnu, "Them"))
                {
                    int Ky = int.Parse(txtKy.Text.Trim());
                    int Nam = int.Parse(txtNam.Text.Trim());
                    if (_cLTT.checkExist(Ky, Nam) == true)
                    {
                        MessageBox.Show("Kỳ " + Ky + "/" + Nam + " đã tạo rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Lich_ThuTien en = new Lich_ThuTien();
                    en.Ky = Ky;
                    en.Nam = Nam;
                    en.TuNgay = dateTu.Value;
                    en.DenNgay = dateDen.Value;
                    if (_cLTT.Them(en) == true)
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (CUser.CheckQuyen(_mnu, "Xoa"))
                {
                    if (_thutien != null && MessageBox.Show("Bạn chắc chắn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (_cLTT.Xoa(_thutien) == true)
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (CUser.CheckQuyen(_mnu, "Sua"))
                {
                    int Ky = int.Parse(txtKy.Text.Trim());
                    int Nam = int.Parse(txtNam.Text.Trim());
                    if ((_thutien.Ky != Ky || _thutien.Nam != Nam) && _cLTT.checkExist(Ky, Nam) == true)
                    {
                        MessageBox.Show("Kỳ " + Ky + "/" + Nam + " đã tạo rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _thutien.Ky = Ky;
                    _thutien.Nam = Nam;
                    _thutien.TuNgay = dateTu.Value;
                    _thutien.DenNgay = dateDen.Value;

                    foreach (DataGridViewRow item in dgvDot.Rows)
                    {
                        Lich_ThuTien_ChiTiet enCT = _thutien.Lich_ThuTien_ChiTiets.SingleOrDefault(itemA => itemA.IDDot == int.Parse(item.Cells["IDDot"].Value.ToString()));
                        if (item.Cells["NgayChuyenListing"].Value != null)
                            enCT.NgayChuyenListing = DateTime.Parse(item.Cells["NgayChuyenListing"].Value.ToString());
                        if (item.Cells["NgayThuTien_From"].Value != null)
                            enCT.NgayThuTien_From = DateTime.Parse(item.Cells["NgayThuTien_From"].Value.ToString());
                        if (item.Cells["NgayThuTien_To"].Value != null)
                            enCT.NgayThuTien_To = DateTime.Parse(item.Cells["NgayThuTien_To"].Value.ToString());
                        enCT.ModifyBy = CUser.MaUser;
                        enCT.ModifyDate = DateTime.Now;
                        _cLTT.SubmitChanges();
                    }

                    if (_cLTT.Sua(_thutien) == true)
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvKy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _thutien = _cLTT.get(int.Parse(dgvKy.CurrentRow.Cells["ID"].Value.ToString()));
                if (_thutien != null)
                {
                    FillEntity(_thutien);
                    dgvDot.DataSource = _thutien.Lich_ThuTien_ChiTiets.ToList();
                }
            }
            catch
            {
            }
        }

        private void dgvDot_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (dgvDot.Columns[e.ColumnIndex].Name)
            {
                case "NgayChuyenListing":
                case "NgaThuTien_From":
                case "NgayThuTien_To":
                    _rectangle = dgvDot.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    _dtp.Size = new Size(_rectangle.Width, _rectangle.Height);
                    _dtp.Location = new Point(_rectangle.X, _rectangle.Y);
                    _dtp.Visible = true;
                    break;
            }
        }

        private void dgvDot_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            _dtp.Visible = false;
        }

        private void dgvDot_Scroll(object sender, ScrollEventArgs e)
        {
            _dtp.Visible = false;
        }
    }
}
