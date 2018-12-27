using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrungTamKhachHang.DAL.QuanTri;
using TrungTamKhachHang.LinQ;

namespace TrungTamKhachHang.GUI.QuanTri
{
    public partial class frmUser : Form
    {
        string _mnu = "mnuUser";
        CNhom _cNhom = new CNhom();
        CUser _cUser = new CUser();
        CMenu _cMenu = new CMenu();
        CPhanQuyenUser _cPhanQuyenUser = new CPhanQuyenUser();
        BindingList<User> _blUser;
        User _user = null;

        public frmUser()
        {
            InitializeComponent();
        }

        private void frmNguoiDung_Load(object sender, EventArgs e)
        {
            if (CUser.Admin)
            {
                chkAn.Visible = true;
                _blUser = new BindingList<User>(_cUser.GetDS_Admin());
            }
            else
            {
                chkAn.Visible = false;
                _blUser = new BindingList<User>(_cUser.GetDSExcept(CUser.MaUser));
            }
            dgvNguoiDung.AutoGenerateColumns = false;

            cmbNhom.DataSource = _cNhom.GetDS();
            cmbNhom.DisplayMember = "Name";
            cmbNhom.ValueMember = "ID";
            //cmbNhom.SelectedIndex = -1;

            dgvNguoiDung.DataSource = _blUser;
        }

        public void Clear()
        {
            txtHoTen.Text = "";
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            _user = null;
            if (CUser.Admin)
            {
                _blUser = new BindingList<User>(_cUser.GetDS_Admin());
            }
            else
            {
                _blUser = new BindingList<User>(_cUser.GetDSExcept(CUser.MaUser));
            }
            dgvNguoiDung.DataSource = _blUser;
        }

        public void LoadEntity(User entity)
        {
            txtHoTen.Text = entity.Name;
            txtTaiKhoan.Text = entity.Username;
            txtMatKhau.Text = entity.Password;
            if (entity.MaNhom != null)
                cmbNhom.SelectedValue = entity.MaNhom;
            chkAn.Checked = entity.An;
            gridControl.DataSource = _cPhanQuyenUser.GetDS(entity.ID);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CUser.CheckQuyen(_mnu, "Them"))
                {
                    if (txtHoTen.Text.Trim() != "" && txtTaiKhoan.Text.Trim() != "" && txtMatKhau.Text.Trim() != "")
                    {
                        if (_cUser.CheckExist(txtTaiKhoan.Text.Trim()) == true)
                        {
                            MessageBox.Show("Tài Khoản này đã có rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        User user = new User();
                        user.Name = txtHoTen.Text.Trim();
                        user.Username = txtTaiKhoan.Text.Trim();
                        user.Password = txtMatKhau.Text.Trim();
                        if (cmbNhom.SelectedIndex != -1)
                            user.MaNhom = (int)cmbNhom.SelectedValue;
                        user.An = chkAn.Checked;
                        ///tự động thêm quyền cho người mới
                        foreach (var item in _cMenu.GetDS())
                        {
                            PhanQuyenUser phanquyenuser = new PhanQuyenUser();
                            phanquyenuser.MaMenu = item.ID;
                            phanquyenuser.MaUser = user.ID;
                            user.PhanQuyenUsers.Add(phanquyenuser);
                        }
                        if (_cUser.Them(user))
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (CUser.CheckQuyen(_mnu, "Sua"))
                {
                    if (_user != null)
                    {
                        if (txtHoTen.Text.Trim() != "" && txtTaiKhoan.Text.Trim() != "" && txtMatKhau.Text.Trim() != "")
                        {
                            //if (_cUser.CheckExist(txtTaiKhoan.Text.Trim()) == true)
                            //{
                            //    MessageBox.Show("Tài Khoản này đã có rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //    return;
                            //}
                            _user.Name = txtHoTen.Text.Trim();
                            //_user.Username = txtTaiKhoan.Text.Trim();
                            _user.Password = txtMatKhau.Text.Trim();
                            _user.MaNhom = (int)cmbNhom.SelectedValue;
                            _user.An = chkAn.Checked;

                            _cUser.Sua(_user);
                        }
                        DataTable dt = ((DataView)gridView.DataSource).Table;
                        foreach (DataRow item in dt.Rows)
                        {
                            PhanQuyenUser phanquyenuser = _cPhanQuyenUser.Get(int.Parse(item["MaMenu"].ToString()), _user.ID);
                            if (phanquyenuser.Xem != bool.Parse(item["Xem"].ToString()) || phanquyenuser.Them != bool.Parse(item["Them"].ToString()) ||
                                phanquyenuser.Sua != bool.Parse(item["Sua"].ToString()) || phanquyenuser.Xoa != bool.Parse(item["Xoa"].ToString()) ||
                                phanquyenuser.QuanLy != bool.Parse(item["QuanLy"].ToString()))
                            {
                                phanquyenuser.Xem = bool.Parse(item["Xem"].ToString());
                                phanquyenuser.Them = bool.Parse(item["Them"].ToString());
                                phanquyenuser.Sua = bool.Parse(item["Sua"].ToString());
                                phanquyenuser.Xoa = bool.Parse(item["Xoa"].ToString());
                                phanquyenuser.QuanLy = bool.Parse(item["QuanLy"].ToString());
                                _cPhanQuyenUser.Sua(phanquyenuser);
                            }
                        }
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                    }
                    else
                        MessageBox.Show("Lỗi, Vui lòng chọn Đối Tượng cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        if (_user != null)
                        {
                            ///xóa quan hệ 1 nhiều
                            //_cPhanQuyenUser.Xoa(user.PhanQuyenUsers.ToList());
                            _user.An = true;
                            _cUser.Sua(_user);
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                        else
                            MessageBox.Show("Lỗi, Vui lòng chọn Người Dùng cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvNguoiDung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _user = _cUser.Get(int.Parse(dgvNguoiDung.CurrentRow.Cells["ID"].Value.ToString()));
                LoadEntity(_user);
            }
            catch (Exception)
            {
            }
        }

        private void dgvNguoiDung_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvNguoiDung.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvNguoiDung_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
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

        //private void dgvNguoiDung_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode.Equals(Keys.Up))
        //    {
        //        moveUp();
        //    }
        //    if (e.KeyCode.Equals(Keys.Down))
        //    {
        //        moveDown();
        //    }
        //    e.Handled = true;
        //}

        //private void moveUp()
        //{
        //    if (dgvNguoiDung.RowCount > 0)
        //    {
        //        if (dgvNguoiDung.SelectedRows.Count > 0)
        //        {
        //            int rowCount = dgvNguoiDung.Rows.Count;
        //            int index = dgvNguoiDung.SelectedCells[0].OwningRow.Index;

        //            if (index == 0)
        //            {
        //                return;
        //            }
        //            //DataGridViewRowCollection rows = dgvNguoiDung.Rows;

        //            // remove the previous row and add it behind the selected row.
        //            //DataGridViewRow prevRow = rows[index - 1];
        //            //rows.Remove(prevRow);
        //            //prevRow.Frozen = false;
        //            //rows.Insert(index, prevRow);
        //            //dgvNguoiDung.ClearSelection();
        //            //dgvNguoiDung.Rows[index - 1].Selected = true;
        //            var itemToMoveUp = this._blUser[index];
        //            this._blUser.RemoveAt(index);
        //            this._blUser.Insert(index - 1, itemToMoveUp);
        //            dgvNguoiDung.ClearSelection();
        //            dgvNguoiDung.Rows[index - 1].Selected = true;
        //        }
        //    }
        //}

        //private void moveDown()
        //{
        //    if (dgvNguoiDung.RowCount > 0)
        //    {
        //        if (dgvNguoiDung.SelectedRows.Count > 0)
        //        {
        //            int rowCount = dgvNguoiDung.Rows.Count;
        //            int index = dgvNguoiDung.SelectedCells[0].OwningRow.Index;

        //            if (index == (rowCount - 2)) // include the header row
        //            {
        //                return;
        //            }
        //            //DataGridViewRowCollection rows = dgvNguoiDung.Rows;

        //            // remove the next row and add it in front of the selected row.
        //            //DataGridViewRow nextRow = rows[index + 1];
        //            //rows.Remove(nextRow);
        //            //nextRow.Frozen = false;
        //            //rows.Insert(index, nextRow);
        //            //dgvNguoiDung.ClearSelection();
        //            //dgvNguoiDung.Rows[index + 1].Selected = true;
        //            var itemToMoveDown = this._blUser[index];
        //            this._blUser.RemoveAt(index);
        //            this._blUser.Insert(index + 1, itemToMoveDown);
        //            dgvNguoiDung.ClearSelection();
        //            dgvNguoiDung.Rows[index + 1].Selected = true;
        //        }
        //    }
        //}

        int rowIndexFromMouseDown;
        DataGridViewRow rw;
        private void dgvNguoiDung_DragDrop(object sender, DragEventArgs e)
        {
            int rowIndexOfItemUnderMouseToDrop;
            Point clientPoint = dgvNguoiDung.PointToClient(new Point(e.X, e.Y));
            rowIndexOfItemUnderMouseToDrop = dgvNguoiDung.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            if (e.Effect == DragDropEffects.Move)
            {
                var item = this._blUser[rowIndexFromMouseDown];
                _blUser.RemoveAt(rowIndexFromMouseDown);
                _blUser.Insert(rowIndexOfItemUnderMouseToDrop, item);

                ///update STT dô database
                //for (int i = 0; i < _blUser.Count; i++)
                //{
                //    _blUser[i].STT = i + 1;
                //}
                _cUser.SubmitChanges();
            }
        }

        private void dgvNguoiDung_DragEnter(object sender, DragEventArgs e)
        {
            if (dgvNguoiDung.SelectedRows.Count > 0)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void dgvNguoiDung_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvNguoiDung.SelectedRows.Count == 1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    rw = dgvNguoiDung.SelectedRows[0];
                    rowIndexFromMouseDown = dgvNguoiDung.SelectedRows[0].Index;
                    dgvNguoiDung.DoDragDrop(rw, DragDropEffects.Move);
                }
            }
        }
    }
}
