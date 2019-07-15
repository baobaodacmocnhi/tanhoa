using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrungTamKhachHang.DAL.LichDocSoThuTien;
using TrungTamKhachHang.LinQ;
using TrungTamKhachHang.DAL.QuanTri;

namespace TrungTamKhachHang.GUI.LichDocSoThuTien
{
    public partial class frmLichDocSo : Form
    {
        string _mnu = "mnuLichDocSo";
        CLichDocSo _cLDS = new CLichDocSo();
        Lich_DocSo _docso = null;

        DateTimePicker _dtp = new DateTimePicker();
        Rectangle _rectangle;

        public frmLichDocSo()
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

        private void frmLichDocSo_Load(object sender, EventArgs e)
        {
            dgvKy.AutoGenerateColumns = false;
            dgvDot.AutoGenerateColumns = false;

            Clear();
        }

        public void Clear()
        {
            txtKy.Text = "";
            txtNam.Text = "";
            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;
            _docso = null;
            dgvKy.DataSource = _cLDS.getDS();
            dgvDot.DataSource = null;
        }

        public void FillEntity(Lich_DocSo docso)
        {
            txtKy.Text = docso.Ky.Value.ToString();
            txtNam.Text = docso.Nam.Value.ToString();
            dateTu.Value = docso.TuNgay.Value;
            dateDen.Value = docso.DenNgay.Value;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CUser.CheckQuyen(_mnu, "Them"))
                {
                    int Ky = int.Parse(txtKy.Text.Trim());
                    int Nam = int.Parse(txtNam.Text.Trim());
                    if (_cLDS.checkExist(Ky, Nam) == true)
                    {
                        MessageBox.Show("Kỳ " + Ky + "/" + Nam + " đã tạo rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Lich_DocSo en = new Lich_DocSo();
                    en.Ky = Ky;
                    en.Nam = Nam;
                    en.TuNgay = dateTu.Value;
                    en.DenNgay = dateDen.Value;
                    if (_cLDS.Them(en) == true)
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
                    if (_docso != null && MessageBox.Show("Bạn chắc chắn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (_cLDS.Xoa(_docso) == true)
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
                    if ((_docso.Ky != Ky || _docso.Nam!=Nam) && _cLDS.checkExist(Ky, Nam) == true)
                    {
                        MessageBox.Show("Kỳ " + Ky + "/" + Nam + " đã tạo rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _docso.Ky = Ky;
                    _docso.Nam = Nam;
                    _docso.TuNgay = dateTu.Value;
                    _docso.DenNgay = dateDen.Value;

                    foreach (DataGridViewRow item in dgvDot.Rows)
                    {
                       Lich_DocSo_ChiTiet enCT= _docso.Lich_DocSo_ChiTiets.SingleOrDefault(itemA => itemA.IDDot == int.Parse(item.Cells["IDDot"].Value.ToString()));
                       if (item.Cells["NgayDoc"].Value != null)
                           enCT.NgayDoc = DateTime.Parse(item.Cells["NgayDoc"].Value.ToString());
                       if (item.Cells["NgayKiemSoat_From"].Value != null)
                           enCT.NgayKiemSoat_From = DateTime.Parse(item.Cells["NgayKiemSoat_From"].Value.ToString());
                       if (item.Cells["NgayKiemSoat_To"].Value != null)
                           enCT.NgayKiemSoat_To = DateTime.Parse(item.Cells["NgayKiemSoat_To"].Value.ToString());
                       if (item.Cells["NgayChuyenListing"].Value != null)
                           enCT.NgayChuyenListing = DateTime.Parse(item.Cells["NgayChuyenListing"].Value.ToString());
                       enCT.ModifyBy = CUser.MaUser;
                       enCT.ModifyDate = DateTime.Now;
                       _cLDS.SubmitChanges();
                    }

                    if (_cLDS.Sua(_docso) == true)
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
                _docso = _cLDS.get(int.Parse(dgvKy.CurrentRow.Cells["ID"].Value.ToString()));
                if (_docso != null)
                {
                    FillEntity(_docso);
                    dgvDot.DataSource = _docso.Lich_DocSo_ChiTiets.ToList();
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
                case "NgayDoc":
                case "NgayKiemSoat_From":
                case "NgayKiemSoat_To":
                case "NgayChuyenListing":
                    _rectangle = dgvDot.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    _dtp.Size = new Size(_rectangle.Width, _rectangle.Height);
                    _dtp.Location = new Point(_rectangle.X,_rectangle.Y);
                    _dtp.Visible = true;
                    dgvDot.CurrentCell.Value = _dtp.Text;
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
