using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.CapNhat;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.HeThong;

namespace KTKS_DonKH.GUI.CapNhat
{
    public partial class frmThongTin_KT_BC : Form
    {
        CHienTrangKiemTra _cHienTrangKiemTra = new CHienTrangKiemTra();
        CTrangThaiBamChi _cTrangThaiBamChi = new CTrangThaiBamChi();
        int _selectedindexHTKT = -1;
        int _selectedindexTTBC = -1;
        BindingSource bsHienTrangKT;
        BindingSource bsTrangThaiBC;
        bool _flagHienTrangKT = false;
        bool _flagTrangThaiBC = false;

        public frmThongTin_KT_BC()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void frmThongTin_KT_BC_Load(object sender, EventArgs e)
        {
            dgvDSHienTrangKT.AutoGenerateColumns = false;
            dgvDSHienTrangKT.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSHienTrangKT.Font, FontStyle.Bold);
            bsHienTrangKT = new BindingSource(_cHienTrangKiemTra.LoadDSHienTrangKiemTra(), string.Empty);
            dgvDSHienTrangKT.DataSource = bsHienTrangKT;

            dgvDSTrangThaiBC.AutoGenerateColumns = false;
            dgvDSTrangThaiBC.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSTrangThaiBC.Font, FontStyle.Bold);
            bsTrangThaiBC = new BindingSource(_cTrangThaiBamChi.LoadDSTrangThaiBamChi(), string.Empty);
            dgvDSTrangThaiBC.DataSource = bsTrangThaiBC;
        }

        #region Hiện Trạng Kiểm Tra

        private void dgvDSHienTrangKT_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSHienTrangKT.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSHienTrangKT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _selectedindexHTKT = e.RowIndex;
                txtHienTrangKT.Text = dgvDSHienTrangKT["TenHTKT", e.RowIndex].Value.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void btnThemHienTrangKT_Click(object sender, EventArgs e)
        {
            if (txtHienTrangKT.Text.Trim() != "")
            {
                HienTrangKiemTra hientrangkiemtra = new HienTrangKiemTra();
                hientrangkiemtra.TenHTKT = txtHienTrangKT.Text.Trim();

                if (_cHienTrangKiemTra.ThemHienTrangKiemTra(hientrangkiemtra))
                {
                    txtHienTrangKT.Text = "";
                    bsHienTrangKT = new BindingSource(_cHienTrangKiemTra.LoadDSHienTrangKiemTra(), string.Empty);
                }
            }
            else
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSuaHienTrangKT_Click(object sender, EventArgs e)
        {
            if (_selectedindexHTKT != -1)
                if (txtHienTrangKT.Text.Trim() != "")
                {
                    HienTrangKiemTra hientrangkiemtra = _cHienTrangKiemTra.getHienTrangKiemTrabyID(int.Parse(dgvDSHienTrangKT["MaHTKT", _selectedindexHTKT].Value.ToString()));
                    hientrangkiemtra.TenHTKT = txtHienTrangKT.Text.Trim();

                    if (_cHienTrangKiemTra.SuaHienTrangKiemTra(hientrangkiemtra))
                    {
                        txtHienTrangKT.Text = "";
                        _selectedindexHTKT = -1;
                        bsHienTrangKT = new BindingSource(_cHienTrangKiemTra.LoadDSHienTrangKiemTra(), string.Empty);
                    }
                }
                else
                    MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //if (_flagHienTrangKT)
            //{
            //    DataTable dt = ((DataTable)bsHienTrangKT.DataSource).DefaultView.Table;
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        HienTrangKiemTra hientrangkiemtra = _cHienTrangKiemTra.getHienTrangKiemTrabyID(int.Parse(dt.Rows[i]["MaHTKT"].ToString()));
            //        hientrangkiemtra.STT = i;
            //        _cHienTrangKiemTra.SuaHienTrangKiemTra(hientrangkiemtra);
            //    }
            //    _flagHienTrangKT = false;
            //}
        }

        private void btnXoaHienTrangKT_Click(object sender, EventArgs e)
        {
            if (_selectedindexHTKT != -1)
                if (_cHienTrangKiemTra.XoaHienTrangKiemTra(_cHienTrangKiemTra.getHienTrangKiemTrabyID(int.Parse(dgvDSHienTrangKT["MaHTKT", _selectedindexHTKT].Value.ToString()))))
                {
                    txtHienTrangKT.Text = "";
                    _selectedindexHTKT = -1;
                    bsHienTrangKT = new BindingSource(_cHienTrangKiemTra.LoadDSHienTrangKiemTra(), string.Empty);
                }
        }

        private void btnUpHienTrangKT_Click(object sender, EventArgs e)
        {
            _flagHienTrangKT = true;
            int position = bsHienTrangKT.Position;
            if (position == 0) return;  // already at top

            bsHienTrangKT.RaiseListChangedEvents = false;

            HienTrangKiemTra current = (HienTrangKiemTra)bsHienTrangKT.Current;
            bsHienTrangKT.Remove(current);

            position--;

            bsHienTrangKT.Insert(position, current);
            bsHienTrangKT.Position = position;

            bsHienTrangKT.RaiseListChangedEvents = true;
            bsHienTrangKT.ResetBindings(false);
        }

        private void btnDownHienTrangKT_Click(object sender, EventArgs e)
        {
            _flagHienTrangKT = true;
            int position = bsHienTrangKT.Position;
            if (position == bsHienTrangKT.Count - 1) return;  // already at bottom

            bsHienTrangKT.RaiseListChangedEvents = false;

            HienTrangKiemTra current = (HienTrangKiemTra)bsHienTrangKT.Current;
            bsHienTrangKT.Remove(current);

            position++;

            bsHienTrangKT.Insert(position, current);
            bsHienTrangKT.Position = position;

            bsHienTrangKT.RaiseListChangedEvents = true;
            bsHienTrangKT.ResetBindings(false);
        }

        #endregion

        #region Trạng Thái Bấm Chì

        private void dgvDSTrangThaiBC_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSTrangThaiBC.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSTrangThaiBC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _selectedindexTTBC = e.RowIndex;
                txtTrangThaiBC.Text = dgvDSTrangThaiBC["TenTTBC", e.RowIndex].Value.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void btnThemTrangThaiBC_Click(object sender, EventArgs e)
        {
            if (txtTrangThaiBC.Text.Trim() != "")
            {
                TrangThaiBamChi trangthaibamchi = new TrangThaiBamChi();
                trangthaibamchi.TenTTBC = txtTrangThaiBC.Text.Trim();

                if (_cTrangThaiBamChi.ThemTrangThaiBamChi(trangthaibamchi))
                {
                    txtTrangThaiBC.Text = "";
                    bsTrangThaiBC = new BindingSource(_cTrangThaiBamChi.LoadDSTrangThaiBamChi(), string.Empty);
                }
            }
            else
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSuaTrangThaiBC_Click(object sender, EventArgs e)
        {
            if (_selectedindexTTBC != -1)
                if (txtTrangThaiBC.Text.Trim() != "")
                {
                    TrangThaiBamChi trangthaibamchi = _cTrangThaiBamChi.getTrangThaiBamChibyID(int.Parse(dgvDSTrangThaiBC["MaTTBC", _selectedindexTTBC].Value.ToString()));
                    trangthaibamchi.TenTTBC = txtTrangThaiBC.Text.Trim();

                    if (_cTrangThaiBamChi.SuaTrangThaiBamChi(trangthaibamchi))
                    {
                        txtTrangThaiBC.Text = "";
                        _selectedindexTTBC = -1;
                        bsTrangThaiBC = new BindingSource(_cTrangThaiBamChi.LoadDSTrangThaiBamChi(), string.Empty);
                    }
                }
                else
                    MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //if (_flagTrangThaiBC)
            //{
            //    string a = "";
            //    for (int i = 0; i < bsTrangThaiBC.List.Count; i++)
            //    {
            //        //a += ((TrangThaiBamChi)bsTrangThaiBC.List[i]).TenTTBC + "\n";
            //        TrangThaiBamChi trangthaibamchi = new TrangThaiBamChi();
            //         trangthaibamchi = _cTrangThaiBamChi.getTrangThaiBamChibyID(((TrangThaiBamChi)bsTrangThaiBC.List[i]).MaTTBC);
            //        trangthaibamchi.STT = i;
            //        _cTrangThaiBamChi.SuaTrangThaiBamChi(trangthaibamchi);
            //    }
            //    MessageBox.Show(a, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        _flagTrangThaiBC = false;
            //}
        }

        private void btnXoaTrangThaiBC_Click(object sender, EventArgs e)
        {
            if (_selectedindexTTBC != -1)
                if (_cTrangThaiBamChi.XoaTrangThaiBamChi(_cTrangThaiBamChi.getTrangThaiBamChibyID(int.Parse(dgvDSTrangThaiBC["MaTTBC", _selectedindexTTBC].Value.ToString()))))
                {
                    txtTrangThaiBC.Text = "";
                    _selectedindexTTBC = -1;
                    bsTrangThaiBC = new BindingSource(_cTrangThaiBamChi.LoadDSTrangThaiBamChi(), string.Empty);
                }
        }

        private void btnUpTrangThaiBC_Click(object sender, EventArgs e)
        {
            _flagTrangThaiBC = true;
            int position = bsTrangThaiBC.Position;
            if (position == 0) return;  // already at top

            bsTrangThaiBC.RaiseListChangedEvents = false;

            TrangThaiBamChi current = (TrangThaiBamChi)bsTrangThaiBC.Current;
            bsTrangThaiBC.Remove(current);

            position--;

            bsTrangThaiBC.Insert(position, current);
            bsTrangThaiBC.Position = position;

            bsTrangThaiBC.RaiseListChangedEvents = true;
            bsTrangThaiBC.ResetBindings(false);
        }

        private void btnDownTrangThaiBC_Click(object sender, EventArgs e)
        {
            _flagTrangThaiBC = true;
            int position = bsTrangThaiBC.Position;
            if (position == bsTrangThaiBC.Count - 1) return;  // already at bottom

            bsTrangThaiBC.RaiseListChangedEvents = false;

            TrangThaiBamChi current = (TrangThaiBamChi)bsTrangThaiBC.Current;
            bsTrangThaiBC.Remove(current);

            position++;

            bsTrangThaiBC.Insert(position, current);
            bsTrangThaiBC.Position = position;

            bsTrangThaiBC.RaiseListChangedEvents = true;
            bsTrangThaiBC.ResetBindings(false);
        }

        #endregion

    }
}
