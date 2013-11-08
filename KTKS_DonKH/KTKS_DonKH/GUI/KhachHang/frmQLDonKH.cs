using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.KhachHang
{
    public partial class frmQLDonKH : Form
    {
        CDonKH _cDonKH = new CDonKH();
        CChuyenDi _cChuyenDi = new CChuyenDi();
        DataTable DSDonKH_Edited = new DataTable();

        public frmQLDonKH()
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

        private void frmQLDonKH_Load(object sender, EventArgs e)
        {
            dgvDSDonKH.AutoGenerateColumns = false;
            DataGridViewComboBoxColumn cmbColumn = (DataGridViewComboBoxColumn)dgvDSDonKH.Columns["MaChuyen"];
            cmbColumn.DataSource = _cChuyenDi.LoadDSChuyenDi();
            cmbColumn.DisplayMember = "NoiChuyenDi";
            cmbColumn.ValueMember = "MaChuyen";
            radChuDuyet.Checked = true;
            
        }
            
        private void dgvDSDonKH_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSDonKH.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void radDaDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radDaDuyet.Checked)
            {
                dgvDSDonKH.DataSource = _cDonKH.LoadDSDonKHDaDuyet();
            }
        }

        private void radChuDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radChuDuyet.Checked)
            {
                dgvDSDonKH.DataSource = _cDonKH.LoadDSDonKHChuaDuyet();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (DSDonKH_Edited.Rows.Count > 0)
            {
                foreach (DataRow itemRow in DSDonKH_Edited.Rows)
                {
                    if (itemRow["MaChuyen"].ToString() != "" && itemRow["MaChuyen"].ToString() != "NONE")
                    {
                        DonKH donkh = _cDonKH.getDonKHbyID(itemRow["MaDon"].ToString());
                        if (!donkh.Nhan)
                        {
                            donkh.Chuyen = true;
                            donkh.MaChuyen = itemRow["MaChuyen"].ToString();
                            donkh.LyDoChuyen = itemRow["LyDoChuyen"].ToString();
                            _cDonKH.SuaDonKH(donkh);
                        }
                        else
                        {
                            MessageBox.Show("Đơn " + donkh.MaDon + " đã được xử lý nên không sửa đổi được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        if (itemRow["MaChuyen"].ToString() == "NONE")
                        {
                            DonKH donkh = _cDonKH.getDonKHbyID(itemRow["MaDon"].ToString());
                            if (!donkh.Nhan)
                            {
                                donkh.Chuyen = false;
                                donkh.MaChuyen = null;
                                donkh.LyDoChuyen = null;
                                _cDonKH.SuaDonKH(donkh);
                            }
                            else
                            {
                                MessageBox.Show("Đơn " + donkh.MaDon + " đã được xử lý nên không sửa đổi được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                }
                DSDonKH_Edited.Clear();

                if (radDaDuyet.Checked)
                    dgvDSDonKH.DataSource = _cDonKH.LoadDSDonKHDaDuyet();
                if (radChuDuyet.Checked)
                    dgvDSDonKH.DataSource = _cDonKH.LoadDSDonKHChuaDuyet();
            }          
        }

        private void dgvDSDonKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDSDonKH.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                frmShowDonKH frm = new frmShowDonKH(_cDonKH.getDonKHbyID(dgvDSDonKH["MaDon", dgvDSDonKH.CurrentRow.Index].Value.ToString()));
                frm.ShowDialog();
            }
        }

        private void dgvDSDonKH_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            btnLuu.Enabled = false;
        }

        private void dgvDSDonKH_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ///Khai báo các cột tương ứng trong Datagridview
            if (DSDonKH_Edited.Columns.Count == 0)
                foreach (DataGridViewColumn itemCol in dgvDSDonKH.Columns)
                {
                    DSDonKH_Edited.Columns.Add(itemCol.Name, itemCol.ValueType);
                }

            ///Gọi hàm EndEdit để kết thúc Edit nếu không sẽ bị lỗi Value chưa cập nhật trong trường hợp chuyển Cell trong cùng 1 Row. Nếu chuyển Row thì không bị lỗi
            ((DataRowView)dgvDSDonKH.CurrentRow.DataBoundItem).Row.EndEdit();

            ///DataRow != DataGridViewRow nên phải qua 1 loạt gán biến
            ///Tránh tình trạng trùng Danh Bộ nên xóa đi rồi add lại
            if (DSDonKH_Edited.Select("MaDon = " + ((DataRowView)dgvDSDonKH.CurrentRow.DataBoundItem).Row["MaDon"]).Count() > 0)
                DSDonKH_Edited.Rows.Remove(DSDonKH_Edited.Select("MaDon = " + ((DataRowView)dgvDSDonKH.CurrentRow.DataBoundItem).Row["MaDon"])[0]);

            DSDonKH_Edited.ImportRow(((DataRowView)dgvDSDonKH.CurrentRow.DataBoundItem).Row);
            btnLuu.Enabled = true; 
        }

    }
}
