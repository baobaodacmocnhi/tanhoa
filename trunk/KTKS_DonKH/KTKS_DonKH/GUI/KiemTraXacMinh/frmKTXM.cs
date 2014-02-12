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
using KTKS_DonKH.DAL.DieuChinhBienDong;

namespace KTKS_DonKH.GUI.KiemTraXacMinh
{
    public partial class frmKTXM : Form
    {
        CChuyenDi _cChuyenDi = new CChuyenDi();
        CKTXM _cKTXM = new CKTXM();
        CDonKH _cDonKH = new CDonKH();
        DataTable DSKTXM_Edited = new DataTable();
        CDCBD _cDCBD = new CDCBD();
        BindingSource DSDonKH_BS = new BindingSource();

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
            dgvDSKTXM.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSKTXM.Font, FontStyle.Bold);
            DataGridViewComboBoxColumn cmbColumn = (DataGridViewComboBoxColumn)dgvDSKTXM.Columns["MaChuyen"];
            cmbColumn.DataSource = _cChuyenDi.LoadDSChuyenDi("KTXM");
            cmbColumn.DisplayMember = "NoiChuyenDi";
            cmbColumn.ValueMember = "MaChuyen";

            dgvDSKTXM.DataSource = DSDonKH_BS;
            radChuaDuyet.Checked = true;

            dateTimKiem.Location = txtNoiDungTimKiem.Location;
        }

        private void radChuaDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radChuaDuyet.Checked)
            {
                DSDonKH_BS.DataSource = _cKTXM.LoadDSKTXMChuaDuyet();
                cmbTimTheo.SelectedIndex = 0;
            }
        }

        private void radDaDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radDaDuyet.Checked)
            {
                DSDonKH_BS.DataSource = _cKTXM.LoadDSKTXMDaDuyet();
                cmbTimTheo.SelectedIndex = 0;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (DSKTXM_Edited != null && DSKTXM_Edited.Rows.Count > 0)
            {
                foreach (DataRow itemRow in DSKTXM_Edited.Rows)
                {
                    if (itemRow["MaKTXM"].ToString() == "")
                    {
                        KTXM ktxm = new KTXM();
                        //ktxm.MaKTXM = decimal.Parse(itemRow["MaDon"].ToString());
                        ktxm.MaDon = decimal.Parse(itemRow["MaDon"].ToString());
                        ktxm.MaNoiChuyenDen = decimal.Parse(itemRow["MaNoiChuyenDen"].ToString());
                        ktxm.NoiChuyenDen = itemRow["NoiChuyenDen"].ToString();
                        ktxm.LyDoChuyenDen = itemRow["LyDoChuyenDen"].ToString();
                        ktxm.KetQua = itemRow["KetQua"].ToString();
                        if (itemRow["MaChuyen"].ToString() != "" && itemRow["MaChuyen"].ToString() != "NONE")
                        {
                            ktxm.Chuyen = true;
                            ktxm.MaChuyen = itemRow["MaChuyen"].ToString();
                            ktxm.LyDoChuyen = itemRow["LyDoChuyenDi"].ToString();
                        }
                        if (_cKTXM.ThemKTXM(ktxm))
                        {
                            switch (itemRow["NoiChuyenDen"].ToString())
                            {
                                case "Khách Hàng":
                                    ///Báo cho bảng DonKH là đơn này đã được nơi nhận xử lý
                                    DonKH donkh = _cDonKH.getDonKHbyID(decimal.Parse(itemRow["MaDon"].ToString()));
                                    donkh.Nhan = true;
                                    _cDonKH.SuaDonKH(donkh);
                                    break;
                                case "Điều Chỉnh Biến Động":
                                    ///Báo cho bảng KTXM là đơn này đã được nơi nhận xử lý
                                    DCBD dcbd = _cDCBD.getDCBDbyID(decimal.Parse(itemRow["MaNoiChuyenDen"].ToString()));
                                    dcbd.Nhan = true;
                                    _cDCBD.SuaDCBD(dcbd);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        KTXM ktxm = _cKTXM.getKTXMbyID(decimal.Parse(itemRow["MaKTXM"].ToString()));
                        ///Đơn đã được nơi nhận xử lý thì không được sửa
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
                }
                DSKTXM_Edited.Clear();

                if (radDaDuyet.Checked)
                    DSDonKH_BS.DataSource = _cKTXM.LoadDSKTXMDaDuyet();
                if (radChuaDuyet.Checked)
                    DSDonKH_BS.DataSource = _cKTXM.LoadDSKTXMChuaDuyet();
            }
        }

        /// <summary>
        /// Hiện thị số thứ tự dòng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSDonKH_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSKTXM.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        /// <summary>
        /// Ctrl+F Tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSKTXM_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDSKTXM.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                Dictionary<string, string> source = new Dictionary<string, string>();
                source.Add("Action", "View");
                source.Add("MaDon", dgvDSKTXM["MaDon", dgvDSKTXM.CurrentRow.Index].Value.ToString());
                frmShowDonKH frm = new frmShowDonKH(source);
                frm.ShowDialog();
            }
        }

        /// <summary>
        /// Bắt đầu Edit Column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSKTXM_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            btnLuu.Enabled = false;
        }

        /// <summary>
        /// Kết thúc Edit Column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Format dữ liệu trong column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSKTXM_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSKTXM.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(e.Value.ToString().Length - 2, "-");
            }
        }

        private void cmbTimTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTimTheo.SelectedItem.ToString())
            {
                case "Mã Đơn":
                    txtNoiDungTimKiem.Visible = true;
                    dateTimKiem.Visible = false;
                    break;
                case "Ngày Lập":
                    txtNoiDungTimKiem.Visible = false;
                    dateTimKiem.Visible = true;
                    break;
                default:
                    txtNoiDungTimKiem.Visible = false;
                    dateTimKiem.Visible = false;
                    DSDonKH_BS.RemoveFilter();
                    break;
            }
        }

        private void txtNoiDungTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtNoiDungTimKiem.Text.Trim() != "")
            {
                string expression = "";
                switch (cmbTimTheo.SelectedItem.ToString())
                {
                    case "Mã Đơn":
                        expression = String.Format("MaDon = {0}", txtNoiDungTimKiem.Text.Trim().Replace("-", ""));
                        break;
                }
                DSDonKH_BS.Filter = expression;
            }
            else
                DSDonKH_BS.RemoveFilter();
        }

        private void dateTimKiem_ValueChanged(object sender, EventArgs e)
        {
            string expression = String.Format("CreateDate > #{0:yyyy-MM-dd} 00:00:00# and CreateDate < #{0:yyyy-MM-dd} 23:59:59#", dateTimKiem.Value);
            DSDonKH_BS.Filter = expression;
        }

  
    }
}
