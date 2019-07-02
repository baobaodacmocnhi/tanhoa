using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTCN_CongVan.DAL.QuanTri;
using KTCN_CongVan.LinQ;

namespace KTCN_CongVan.GUI.QuanTri
{
    public partial class frmUser : Form
    {
        CNhom _cNhom = new CNhom();
        CUser _cNguoiDung = new CUser();
        CMenu _cMenu = new CMenu();
        CPhanQuyenUser _cPhanQuyenNguoiDung = new CPhanQuyenUser();
        int _selectedindex = -1;
        string _mnu = "mnuUser";
        BindingList<User> _blNguoiDung;

        public frmUser()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            _selectedindex = -1;
            txtHoTen.Text = "";
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            if (CUser.Admin)
            {
                _blNguoiDung = new BindingList<User>(_cNguoiDung.GetDS_Admin());
            }
            else
            {
                _blNguoiDung = new BindingList<User>(_cNguoiDung.GetDSExceptMaND(CUser.ID));
            }
            dgvNguoiDung.DataSource = _blNguoiDung;
        }

        private void frmNguoiDung_Load(object sender, EventArgs e)
        {
            if (CUser.Admin)
            {
                chkAn.Visible = true;
                _blNguoiDung = new BindingList<User>(_cNguoiDung.GetDS_Admin());
            }
            else
                if (CUser.Doi)
                {
                    chkAn.Visible = true;
                    _blNguoiDung = new BindingList<User>(_cNguoiDung.GetDSExceptMaND_Doi(CUser.ID));
                }else
            {
                chkAn.Visible = false;
                _blNguoiDung = new BindingList<User>(_cNguoiDung.GetDSExceptMaND(CUser.ID));
            }
            dgvNguoiDung.AutoGenerateColumns = false;

            cmbNhom.DataSource = _cNhom.GetDS();
            cmbNhom.DisplayMember = "Name";
            cmbNhom.ValueMember = "ID";
            //cmbNhom.SelectedIndex = -1;
            
            dgvNguoiDung.DataSource = _blNguoiDung;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CUser.CheckQuyen(_mnu, "Them"))
            {
                if (txtHoTen.Text.Trim() != "" && txtTaiKhoan.Text.Trim() != "" && txtMatKhau.Text.Trim() != "")
                {
                    User en = new User();
                    en.Name = txtHoTen.Text.Trim();

                    en.Username = txtTaiKhoan.Text.Trim();
                    en.Password = txtMatKhau.Text.Trim();
                    en.STT = _cNguoiDung.GetMaxSTT()+1;

                    if (cmbNhom.SelectedIndex != -1)
                        en.IDNhom = (int)cmbNhom.SelectedValue;
                    ///tự động thêm quyền cho người mới
                    foreach (var item in _cMenu.GetDS())
                    {
                        PhanQuyenUser phanquyennguoidung = new PhanQuyenUser();
                        phanquyennguoidung.IDMenu = item.ID;
                        phanquyennguoidung.IDUser = en.ID;
                        en.PhanQuyenUsers.Add(phanquyennguoidung);
                    }
                    
                    if (_cNguoiDung.Them(en))
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                    }
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CUser.CheckQuyen(_mnu, "Sua"))
            {
                if (_selectedindex != -1)
                {
                    User en = _cNguoiDung.GetByMaND(int.Parse(dgvNguoiDung["ID", _selectedindex].Value.ToString()));
                    if (txtHoTen.Text.Trim() != "" && txtTaiKhoan.Text.Trim() != "" && txtMatKhau.Text.Trim() != "")
                    {
                        en.Name = txtHoTen.Text.Trim();
                        en.Username = txtTaiKhoan.Text.Trim();
                        en.Password = txtMatKhau.Text.Trim();
                        en.IDNhom = (int)cmbNhom.SelectedValue;
                        en.An = chkAn.Checked;
                        _cNguoiDung.Sua(en);
                    }
                    DataTable dt = ((DataView)gridView.DataSource).Table;
                    foreach (DataRow item in dt.Rows)
                    {
                        PhanQuyenUser phanquyennguoidung = _cPhanQuyenNguoiDung.get(int.Parse(item["IDMenu"].ToString()), en.ID);
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CUser.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    if (_selectedindex != -1)
                    {
                        User en = _cNguoiDung.GetByMaND(int.Parse(dgvNguoiDung["ID", _selectedindex].Value.ToString()));
                        ///xóa quan hệ 1 nhiều
                        //_cPhanQuyenNguoiDung.Xoa(en.TT_PhanQuyenNguoiDungs.ToList());
                        en.An = true;
                        _cNguoiDung.Sua(en);
                        Clear();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Lỗi, Vui lòng chọn Người Dùng cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvNguoiDung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _selectedindex = e.RowIndex;
                txtHoTen.Text = dgvNguoiDung["Namee", e.RowIndex].Value.ToString();
                txtTaiKhoan.Text = dgvNguoiDung["Username", e.RowIndex].Value.ToString();
                txtMatKhau.Text = dgvNguoiDung["Password", e.RowIndex].Value.ToString();
                if (dgvNguoiDung["IDNhom", e.RowIndex].Value != null)
                    cmbNhom.SelectedValue = int.Parse(dgvNguoiDung["IDNhom", e.RowIndex].Value.ToString());

                if (CUser.Admin)
                    gridControl.DataSource = _cPhanQuyenNguoiDung.GetDSByMaND(true, int.Parse(dgvNguoiDung["ID", e.RowIndex].Value.ToString()));
                else
                    gridControl.DataSource = _cPhanQuyenNguoiDung.GetDSByMaND(false, int.Parse(dgvNguoiDung["ID", e.RowIndex].Value.ToString()));
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
            //if (dgvNguoiDung.Columns[e.ColumnIndex].Name == "TenTo" && dgvNguoiDung["MaTo", e.RowIndex].Value != null)
            //    e.Value = _cTo.GetTenToByMaTo(int.Parse(dgvNguoiDung["MaTo", e.RowIndex].Value.ToString()));
            if (dgvNguoiDung.Columns[e.ColumnIndex].Name == "TenNhom" && dgvNguoiDung["IDNhom", e.RowIndex].Value != null)
                e.Value = _cNhom.getName(int.Parse(dgvNguoiDung["IDNhom", e.RowIndex].Value.ToString()));
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
        //            var itemToMoveUp = this._blNguoiDung[index];
        //            this._blNguoiDung.RemoveAt(index);
        //            this._blNguoiDung.Insert(index - 1, itemToMoveUp);
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
        //            var itemToMoveDown = this._blNguoiDung[index];
        //            this._blNguoiDung.RemoveAt(index);
        //            this._blNguoiDung.Insert(index + 1, itemToMoveDown);
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
                var item = this._blNguoiDung[rowIndexFromMouseDown];
                _blNguoiDung.RemoveAt(rowIndexFromMouseDown);
                _blNguoiDung.Insert(rowIndexOfItemUnderMouseToDrop,item);
                
                ///update STT dô database
                for (int i = 0; i < _blNguoiDung.Count; i++)
                {
                    _blNguoiDung[i].STT = i + 1;
                }
                _cNguoiDung.SubmitChanges();
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
