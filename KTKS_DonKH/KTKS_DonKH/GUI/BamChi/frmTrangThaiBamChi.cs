using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.BamChi;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.BamChi
{
    public partial class frmTrangThaiBamChi : Form
    {
        CTrangThaiBamChi _cTrangThaiBamChi = new CTrangThaiBamChi();
        int _selectedindexTTBC = -1;

        public frmTrangThaiBamChi()
        {
            InitializeComponent();
        }

        private void frmTrangThaiBamChi_Load(object sender, EventArgs e)
        {
            dgvDSTrangThaiBC.AutoGenerateColumns = false;
            dgvDSTrangThaiBC.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSTrangThaiBC.Font, FontStyle.Bold);
            dgvDSTrangThaiBC.DataSource = _cTrangThaiBamChi.LoadDSTrangThaiBamChi();
        }

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
                dgvDSTrangThaiBC.Rows[e.RowIndex].Selected = true;
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
                    dgvDSTrangThaiBC.DataSource = _cTrangThaiBamChi.LoadDSTrangThaiBamChi();
                    //bsTrangThaiBC = new BindingSource(_cTrangThaiBamChi.LoadDSTrangThaiBamChi(), string.Empty);
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
                        dgvDSTrangThaiBC.DataSource = _cTrangThaiBamChi.LoadDSTrangThaiBamChi();
                        //bsTrangThaiBC = new BindingSource(_cTrangThaiBamChi.LoadDSTrangThaiBamChi(), string.Empty);
                    }
                }
                else
                    MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnXoaTrangThaiBC_Click(object sender, EventArgs e)
        {
            if (_selectedindexTTBC != -1)
                if (_cTrangThaiBamChi.XoaTrangThaiBamChi(_cTrangThaiBamChi.getTrangThaiBamChibyID(int.Parse(dgvDSTrangThaiBC["MaTTBC", _selectedindexTTBC].Value.ToString()))))
                {
                    txtTrangThaiBC.Text = "";
                    _selectedindexTTBC = -1;
                    dgvDSTrangThaiBC.DataSource = _cTrangThaiBamChi.LoadDSTrangThaiBamChi();
                    //bsTrangThaiBC = new BindingSource(_cTrangThaiBamChi.LoadDSTrangThaiBamChi(), string.Empty);
                }
        }

        private void btnUpTrangThaiBC_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = dgvDSTrangThaiBC.SelectedRows[0].Index; // get the index of the currently selected row
                if (rowIndex == 0)
                {
                    MessageBox.Show("first line");
                    return;
                }
                List<string> list = new List<string>();
                for (int i = 0; i < dgvDSTrangThaiBC.Columns.Count; i++)
                {
                    list.Add(dgvDSTrangThaiBC.SelectedRows[0].Cells[i].Value.ToString());// array of data stored in the list of the currently selected row 
                }
                for (int j = 0; j < dgvDSTrangThaiBC.Columns.Count; j++)
                {
                    dgvDSTrangThaiBC.Rows[rowIndex].Cells[j].Value = dgvDSTrangThaiBC.Rows[rowIndex - 1].Cells[j].Value;
                    dgvDSTrangThaiBC.Rows[rowIndex - 1].Cells[j].Value = list[j].ToString();
                }
                dgvDSTrangThaiBC.Rows[rowIndex - 1].Selected = true;
                //dgvDSTrangThaiBC.Rows[rowIndex].Selected = false;
                for (int i = 0; i < dgvDSTrangThaiBC.Rows.Count; i++)
                {
                    TrangThaiBamChi trangthaibamchi = _cTrangThaiBamChi.getTrangThaiBamChibyID(int.Parse(dgvDSTrangThaiBC["MaTTBC", i].Value.ToString()));
                    trangthaibamchi.STT = i;
                    _cTrangThaiBamChi.SuaTrangThaiBamChi(trangthaibamchi);
                }
                _selectedindexTTBC = -1;
            }
            catch
            {
            }
        }

        private void btnDownTrangThaiBC_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = dgvDSTrangThaiBC.SelectedRows[0].Index; // get the index of the currently selected row
                if (rowIndex == dgvDSTrangThaiBC.Rows.Count - 1)
                {
                    MessageBox.Show("is the last line!");
                    return;
                }
                List<string> list = new List<string>();
                for (int i = 0; i < dgvDSTrangThaiBC.Columns.Count; i++)
                {
                    list.Add(dgvDSTrangThaiBC.SelectedRows[0].Cells[i].Value.ToString()); // array of data stored in the list of the currently selected row 
                }
                for (int j = 0; j < dgvDSTrangThaiBC.Columns.Count; j++)
                {
                    dgvDSTrangThaiBC.Rows[rowIndex].Cells[j].Value = dgvDSTrangThaiBC.Rows[rowIndex + 1].Cells[j].Value;
                    dgvDSTrangThaiBC.Rows[rowIndex + 1].Cells[j].Value = list[j].ToString();
                }
                dgvDSTrangThaiBC.Rows[rowIndex + 1].Selected = true;
                //dgvDSTrangThaiBC.Rows[rowIndex].Selected = false;
                for (int i = 0; i < dgvDSTrangThaiBC.Rows.Count; i++)
                {
                    TrangThaiBamChi trangthaibamchi = _cTrangThaiBamChi.getTrangThaiBamChibyID(int.Parse(dgvDSTrangThaiBC["MaTTBC", i].Value.ToString()));
                    trangthaibamchi.STT = i;
                    _cTrangThaiBamChi.SuaTrangThaiBamChi(trangthaibamchi);
                }
                _selectedindexTTBC = -1;
            }
            catch
            {
            }
        }

        #endregion
    }
}
