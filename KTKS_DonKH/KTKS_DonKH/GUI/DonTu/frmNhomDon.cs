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

namespace KTKS_DonKH.GUI.DonTu
{
    public partial class frmNhomDon : Form
    {
        string _mnu = "mnuNhomDon";
        BindingList<NhomDon> _bSourceDieuChinh;
        BindingList<NhomDon> _bSourceKhieuNai;
        BindingList<NhomDon> _bSourceDHN;
        CNhomDon _cNhomDon = new CNhomDon();

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
            _bSourceDHN = new BindingList<NhomDon>(_cNhomDon.getDS_List("DHN"));
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
            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvKhieuNai_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void dgvDHN_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

        }
    }
}
