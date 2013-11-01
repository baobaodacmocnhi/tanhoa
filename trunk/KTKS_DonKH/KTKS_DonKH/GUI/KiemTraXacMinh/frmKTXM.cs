using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.KhachHang;
using KTKS_DonKH.DAL.KiemTraXacMinh;
using KTKS_DonKH.GUI.KhachHang;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.KiemTraXacMinh
{
    public partial class frmKTXM : Form
    {
        CChuyenDi _cChuyenDi = new CChuyenDi();
        CKTXM _cKTXM = new CKTXM();
        CDonKH _cDonKH = new CDonKH();
        DataTable DSKTXM_Edited = new DataTable();

        public frmKTXM()
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

        private void frmKTXM_Load(object sender, EventArgs e)
        {
            dgvDSKTXM.AutoGenerateColumns = false;
            DataGridViewComboBoxColumn cmbColumn = (DataGridViewComboBoxColumn)dgvDSKTXM.Columns["MaChuyen"];
            cmbColumn.DataSource = _cChuyenDi.LoadDSChuyenDi("KTXM");
            cmbColumn.DisplayMember = "NoiChuyenDi";
            cmbColumn.ValueMember = "MaChuyen";
            radChuDuyet.Checked = true;
        }

        private void dgvDSDonKH_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSKTXM.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void radChuDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radChuDuyet.Checked)
                dgvDSKTXM.DataSource = _cKTXM.LoadDSKTXMChuaDuyet();
        }

        private void radDaDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radDaDuyet.Checked)
                dgvDSKTXM.DataSource = _cKTXM.LoadDSKTXMDaDuyet();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (DSKTXM_Edited != null)
            {
                foreach (DataRow itemRow in DSKTXM_Edited.Rows)
                {
                    //if (itemRow["MaChuyen"].ToString() != "" && itemRow["MaChuyen"].ToString() != "NONE")
                    //{
                    KTXM ktxm = _cKTXM.getKTXMbyID(int.Parse(itemRow["MaDon"].ToString()));
                    if (ktxm == null)
                    {
                        ktxm = new KTXM();
                        ktxm.MaKTXM = int.Parse(itemRow["MaDon"].ToString());
                        ktxm.KetQua = itemRow["KetQua"].ToString();
                        if (itemRow["MaChuyen"].ToString() != "" && itemRow["MaChuyen"].ToString() != "NONE")
                        {
                            ktxm.Chuyen = true;
                            ktxm.MaChuyen = itemRow["MaChuyen"].ToString();
                            ktxm.LyDoChuyen = itemRow["LyDoChuyenDi"].ToString();
                        }
                        _cKTXM.ThemKTXM(ktxm);
                        ///Báo cho bảng DonKH là đơn này đã được nơi nhận xử lý
                        DonKH donkh = _cDonKH.getDonKHbyID(int.Parse(itemRow["MaDon"].ToString()));
                        donkh.Nhan = true;
                        _cDonKH.SuaDonKH(donkh);
                    }
                    else
                        if (!ktxm.Nhan)
                        {
                            ktxm.KetQua = itemRow["KetQua"].ToString();
                            if (itemRow["MaChuyen"].ToString() != "" && itemRow["MaChuyen"].ToString() != "NONE")
                            {
                                ktxm.Chuyen = true;
                                ktxm.MaChuyen = itemRow["MaChuyen"].ToString();
                                ktxm.LyDoChuyen = itemRow["LyDoChuyenDi"].ToString();
                            }
                            else
                                if (itemRow["MaChuyen"].ToString() == "NONE")
                                {
                                    ktxm.Chuyen = false;
                                    ktxm.MaChuyen = null;
                                    ktxm.LyDoChuyen = null;
                                }
                            _cKTXM.SuaKTXM(ktxm);
                        }
                        else
                        {
                            MessageBox.Show("Đơn " + ktxm.MaKTXM + " đã được xử lý nên không sửa đổi được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                }
                DSKTXM_Edited.Clear();

                if (radDaDuyet.Checked)
                    dgvDSKTXM.DataSource = _cKTXM.LoadDSKTXMDaDuyet();
                if (radChuDuyet.Checked)
                    dgvDSKTXM.DataSource = _cKTXM.LoadDSKTXMChuaDuyet();
            }
        }

        private void dgvDSKTXM_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDSKTXM.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                frmShowDonKH frm = new frmShowDonKH(_cDonKH.getDonKHbyID(int.Parse(dgvDSKTXM["MaDon", dgvDSKTXM.CurrentRow.Index].Value.ToString())));
                frm.ShowDialog();
            }
        }

        private void dgvDSKTXM_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            btnLuu.Enabled = false;
        }

        private void dgvDSKTXM_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ///Khai báo các cột tương ứng trong Datagridview
            if (DSKTXM_Edited.Columns.Count == 0)
                foreach (DataGridViewColumn itemCol in dgvDSKTXM.Columns)
                {
                    DSKTXM_Edited.Columns.Add(itemCol.Name, itemCol.ValueType);
                }

            ///Gọi hàm EndEdit để kết thúc Edit nếu không sẽ bị lỗi Value chưa cập nhật trong trường hợp chuyển Cell trong cùng 1 Row. Nếu chuyển Row thì không bị lỗi
            ((DataRowView)dgvDSKTXM.CurrentRow.DataBoundItem).Row.EndEdit();

            ///DataRow != DataGridViewRow nên phải qua 1 loạt gán biến
            ///Tránh tình trạng trùng Danh Bộ nên xóa đi rồi add lại
            if (DSKTXM_Edited.Select("MaDon = " + ((DataRowView)dgvDSKTXM.CurrentRow.DataBoundItem).Row["MaDon"]).Count() > 0)
                DSKTXM_Edited.Rows.Remove(DSKTXM_Edited.Select("MaDon = " + ((DataRowView)dgvDSKTXM.CurrentRow.DataBoundItem).Row["MaDon"])[0]);

            DSKTXM_Edited.ImportRow(((DataRowView)dgvDSKTXM.CurrentRow.DataBoundItem).Row);
            btnLuu.Enabled = true;
        }       
    }
}
