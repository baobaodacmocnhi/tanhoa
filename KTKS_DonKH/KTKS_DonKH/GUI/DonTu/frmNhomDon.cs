using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.DonTu;
using KTKS_DonKH.DAL.QuanTri;

namespace KTKS_DonKH.GUI.DonTu
{
    public partial class frmNhomDon : Form
    {
        string _mnu = "mnuNhomDon";
        BindingList<NhomDon> _bSourceDieuChinh;
        BindingList<NhomDon> _bSourceKhieuNai;
        BindingList<NhomDon> _bSourceDHN;
        CNhomDon _cNhomDon = new CNhomDon();
        string _actionDieuChinh = "", _actionKhieuNai = "", _actionDHN = "";
        public frmNhomDon()
        {
            InitializeComponent();
        }

        private void frmNhomDon_Load(object sender, EventArgs e)
        {
            dgvDieuChinh.AutoGenerateColumns = false;
            _bSourceDieuChinh = new BindingList<NhomDon>(_cNhomDon.getDS_List("DieuChinh"));
            dgvDieuChinh.DataSource = _bSourceDieuChinh;
            dgvKhieuNai.AutoGenerateColumns = false;
            _bSourceKhieuNai = new BindingList<NhomDon>(_cNhomDon.getDS_List("KhieuNai"));
            dgvKhieuNai.DataSource = _bSourceKhieuNai;
            dgvDHN.AutoGenerateColumns = false;
            _bSourceDHN = new BindingList<NhomDon>(_cNhomDon.getDS_List("SuCo"));
            dgvDHN.DataSource = _bSourceDHN;
        }

        public void loaddgv()
        {
            _bSourceDieuChinh = new BindingList<NhomDon>(_cNhomDon.getDS_List("DieuChinh"));
            dgvDieuChinh.DataSource = _bSourceDieuChinh;
            _bSourceKhieuNai = new BindingList<NhomDon>(_cNhomDon.getDS_List("KhieuNai"));
            dgvKhieuNai.DataSource = _bSourceKhieuNai;
            _bSourceDHN = new BindingList<NhomDon>(_cNhomDon.getDS_List("SuCo"));
            dgvDHN.DataSource = _bSourceDHN;
        }

        private void dgvDieuChinh_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDieuChinh.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvKhieuNai_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvKhieuNai.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDHN_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDHN.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        int rowIndexFromMouseDown_DieuChinh;
        DataGridViewRow rw_DieuChinh;
        private void dgvDieuChinh_DragDrop(object sender, DragEventArgs e)
        {
            int rowIndexOfItemUnderMouseToDrop;
            Point clientPoint = dgvDieuChinh.PointToClient(new Point(e.X, e.Y));
            rowIndexOfItemUnderMouseToDrop = dgvDieuChinh.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            if (e.Effect == DragDropEffects.Move)
            {
                var item = this._bSourceDieuChinh[rowIndexFromMouseDown_DieuChinh];
                _bSourceDieuChinh.RemoveAt(rowIndexFromMouseDown_DieuChinh);
                _bSourceDieuChinh.Insert(rowIndexOfItemUnderMouseToDrop, item);

                ///update STT dô database
                for (int i = 0; i < _bSourceDieuChinh.Count; i++)
                {
                    _bSourceDieuChinh[i].STT = i + 1;
                }
                _cNhomDon.SubmitChanges();
            }
        }

        private void dgvDieuChinh_DragEnter(object sender, DragEventArgs e)
        {
            if (dgvDieuChinh.SelectedRows.Count > 0)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void dgvDieuChinh_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvDieuChinh.SelectedRows.Count == 1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    rw_DieuChinh = dgvDieuChinh.SelectedRows[0];
                    rowIndexFromMouseDown_DieuChinh = dgvDieuChinh.SelectedRows[0].Index;
                    dgvDieuChinh.DoDragDrop(rw_DieuChinh, DragDropEffects.Move);
                }
            }
        }

        int rowIndexFromMouseDown_KhieuNai;
        DataGridViewRow rw_KhieuNai;
        private void dgvKhieuNai_DragDrop(object sender, DragEventArgs e)
        {
            int rowIndexOfItemUnderMouseToDrop;
            Point clientPoint = dgvKhieuNai.PointToClient(new Point(e.X, e.Y));
            rowIndexOfItemUnderMouseToDrop = dgvKhieuNai.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            if (e.Effect == DragDropEffects.Move)
            {
                var item = this._bSourceKhieuNai[rowIndexFromMouseDown_KhieuNai];
                _bSourceKhieuNai.RemoveAt(rowIndexFromMouseDown_KhieuNai);
                _bSourceKhieuNai.Insert(rowIndexOfItemUnderMouseToDrop, item);

                ///update STT dô database
                for (int i = 0; i < _bSourceKhieuNai.Count; i++)
                {
                    _bSourceKhieuNai[i].STT = i + 1;
                }
                _cNhomDon.SubmitChanges();
            }
        }

        private void dgvKhieuNai_DragEnter(object sender, DragEventArgs e)
        {
            if (dgvKhieuNai.SelectedRows.Count > 0)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void dgvKhieuNai_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvKhieuNai.SelectedRows.Count == 1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    rw_KhieuNai = dgvKhieuNai.SelectedRows[0];
                    rowIndexFromMouseDown_KhieuNai = dgvKhieuNai.SelectedRows[0].Index;
                    dgvKhieuNai.DoDragDrop(rw_KhieuNai, DragDropEffects.Move);
                }
            }
        }

        int rowIndexFromMouseDown_DHN;
        DataGridViewRow rw_DHN;
        private void dgvDHN_DragDrop(object sender, DragEventArgs e)
        {
            int rowIndexOfItemUnderMouseToDrop;
            Point clientPoint = dgvDHN.PointToClient(new Point(e.X, e.Y));
            rowIndexOfItemUnderMouseToDrop = dgvDHN.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            if (e.Effect == DragDropEffects.Move)
            {
                var item = this._bSourceDHN[rowIndexFromMouseDown_DHN];
                _bSourceDHN.RemoveAt(rowIndexFromMouseDown_DHN);
                _bSourceDHN.Insert(rowIndexOfItemUnderMouseToDrop, item);

                ///update STT dô database
                for (int i = 0; i < _bSourceDHN.Count; i++)
                {
                    _bSourceDHN[i].STT = i + 1;
                }
                _cNhomDon.SubmitChanges();
            }
        }

        private void dgvDHN_DragEnter(object sender, DragEventArgs e)
        {
            if (dgvDHN.SelectedRows.Count > 0)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void dgvDHN_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvDHN.SelectedRows.Count == 1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    rw_DHN = dgvDHN.SelectedRows[0];
                    rowIndexFromMouseDown_DHN = dgvDHN.SelectedRows[0].Index;
                    dgvDHN.DoDragDrop(rw_DHN, DragDropEffects.Move);
                }
            }
        }

        private void dgvDieuChinh_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
                {
                    _actionDieuChinh = "add";
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDieuChinh_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDieuChinh.CurrentRow.Cells["ID_DieuChinh"].Value.ToString() != "0")
                try
                {
                    if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                    {
                        _actionDieuChinh = "edit";
                    }
                    else
                        MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void dgvDieuChinh_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string sql = "";
            switch (_actionDieuChinh)
            {
                case "add":
                    sql = "insert into NhomDon(ID,STT,Name,DieuChinh,CreateBy,CreateDate)values((select max(id)+1 from NhomDon)," + dgvDieuChinh.CurrentRow.Cells["STT_DieuChinh"].Value.ToString() + ",N'" + dgvDieuChinh.CurrentRow.Cells["Name_DieuChinh"].Value.ToString() + "',1," + CTaiKhoan.MaUser + ",getdate())";
                    break;
                case "edit":
                    sql = "update NhomDon set STT=" + dgvDieuChinh.CurrentRow.Cells["STT_DieuChinh"].Value.ToString() + ",Name=N'" + dgvDieuChinh.CurrentRow.Cells["Name_DieuChinh"].Value.ToString() + "',ModifyBy=" + CTaiKhoan.MaUser + ",ModifyDate=getdate() where ID=" + dgvDieuChinh.CurrentRow.Cells["ID_DieuChinh"].Value.ToString();
                    break;
                default:
                    break;
            }
            if (sql != "")
                if (_cNhomDon.ExecuteNonQuery(sql) == true)
                {
                    _actionDieuChinh = "";
                    loaddgv();
                }
        }

        private void dgvKhieuNai_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
                {
                    _actionKhieuNai = "add";
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvKhieuNai_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvKhieuNai.CurrentRow.Cells["ID_KhieuNai"].Value.ToString() != "0")
                try
                {
                    if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                    {
                        _actionKhieuNai = "edit";
                    }
                    else
                        MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void dgvKhieuNai_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string sql = "";
            switch (_actionKhieuNai)
            {
                case "add":
                    sql = "insert into NhomDon(ID,STT,Name,KhieuNai,CreateBy,CreateDate)values((select max(id)+1 from NhomDon)," + dgvKhieuNai.CurrentRow.Cells["STT_KhieuNai"].Value.ToString() + ",N'" + dgvKhieuNai.CurrentRow.Cells["Name_KhieuNai"].Value.ToString() + "',1," + CTaiKhoan.MaUser + ",getdate())";
                    break;
                case "edit":
                    sql = "update NhomDon set STT=" + dgvKhieuNai.CurrentRow.Cells["STT_KhieuNai"].Value.ToString() + ",Name=N'" + dgvKhieuNai.CurrentRow.Cells["Name_KhieuNai"].Value.ToString() + "',ModifyBy=" + CTaiKhoan.MaUser + ",ModifyDate=getdate() where ID=" + dgvKhieuNai.CurrentRow.Cells["ID_KhieuNai"].Value.ToString();
                    break;
                default:
                    break;
            }
            if (sql != "")
                if (_cNhomDon.ExecuteNonQuery(sql) == true)
                {
                    _actionKhieuNai = "";
                    loaddgv();
                }
        }

        private void dgvDHN_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
                {
                    _actionDHN = "add";
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDHN_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDHN.CurrentRow.Cells["ID_DHN"].Value.ToString() != "0")
                try
                {
                    if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                    {
                        _actionDHN = "edit";
                    }
                    else
                        MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void dgvDHN_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string sql = "";
            switch (_actionDHN)
            {
                case "add":
                    sql = "insert into NhomDon(ID,STT,Name,DHN,CreateBy,CreateDate)values((select max(id)+1 from NhomDon)," + dgvDHN.CurrentRow.Cells["STT_DHN"].Value.ToString() + ",N'" + dgvDHN.CurrentRow.Cells["Name_DHN"].Value.ToString() + "',1," + CTaiKhoan.MaUser + ",getdate())";
                    break;
                case "edit":
                    sql = "update NhomDon set STT=" + dgvDHN.CurrentRow.Cells["STT_DHN"].Value.ToString() + ",Name=N'" + dgvDHN.CurrentRow.Cells["Name_DHN"].Value.ToString() + "',ModifyBy=" + CTaiKhoan.MaUser + ",ModifyDate=getdate() where ID=" + dgvDHN.CurrentRow.Cells["ID_KhieuNai"].Value.ToString();
                    break;
                default:
                    break;
            }
            if (sql != "")
                if (_cNhomDon.ExecuteNonQuery(sql) == true)
                {
                    _actionDHN = "";
                    loaddgv();
                }
        }


    }
}
