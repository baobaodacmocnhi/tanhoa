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
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.KhachHang;
using KTKS_DonKH.GUI.BaoCao;
using KTKS_DonKH.DAL.CapNhat;

namespace KTKS_DonKH.GUI.KhachHang
{
    public partial class frmQLDonKH : Form
    {
        CDonKH _cDonKH = new CDonKH();
        CChuyenDi _cChuyenDi = new CChuyenDi();
        DataTable DSDonKH_Edited = new DataTable();
        BindingSource DSDonKH_BS = new BindingSource();
        CLoaiDon _cLoaiDon = new CLoaiDon();
        string _tuNgay = "", _denNgay = "";

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
            dgvDSDonKH.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSDonKH.Font, FontStyle.Bold);
            DataGridViewComboBoxColumn cmbColumn = (DataGridViewComboBoxColumn)dgvDSDonKH.Columns["MaChuyen"];
            cmbColumn.DataSource = _cChuyenDi.LoadDSChuyenDi();
            cmbColumn.DisplayMember = "NoiChuyenDi";
            cmbColumn.ValueMember = "MaChuyen";

            dgvDSDonKH.DataSource = DSDonKH_BS;
            radAll.Checked = true;

            cmbTimTheo.SelectedIndex = 3;
            dateTimKiem.Location = txtNoiDungTimKiem.Location;
        }
            
        private void radDaDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radDaDuyet.Checked)
            {
                DSDonKH_BS.DataSource = _cDonKH.LoadDSDonKHDaDuyet();
                cmbTimTheo.SelectedIndex = 0;
            }
        }

        private void radChuaDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radChuaDuyet.Checked)
            {
                DSDonKH_BS.DataSource = _cDonKH.LoadDSDonKHChuaDuyet();
                cmbTimTheo.SelectedIndex = 0;
            }
        }

        private void radAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radAll.Checked)
            {
                DSDonKH_BS.DataSource = _cDonKH.LoadDSAllDonKH();
                cmbTimTheo.SelectedIndex = 0;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (DSDonKH_Edited.Rows.Count > 0)
                {
                    foreach (DataRow itemRow in DSDonKH_Edited.Rows)
                    {
                        //if (itemRow["MaChuyen"].ToString() != "" && itemRow["MaChuyen"].ToString() != "NONE")
                        //{
                        DonKH donkh = _cDonKH.getDonKHbyID(decimal.Parse(itemRow["MaDon"].ToString()));
                        //if (!donkh.Nhan)
                        //{
                        donkh.Chuyen = true;
                        donkh.MaChuyen = itemRow["MaChuyen"].ToString();
                        donkh.LyDoChuyen = itemRow["LyDoChuyen"].ToString();
                        if (string.IsNullOrEmpty(itemRow["SoLuongDiaChi"].ToString()))
                            donkh.SoLuongDiaChi = null;
                        else
                            donkh.SoLuongDiaChi = int.Parse(itemRow["SoLuongDiaChi"].ToString());
                        donkh.NVKiemTra = itemRow["NVKiemTra"].ToString();
                        _cDonKH.SuaDonKH(donkh);
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Đơn " + donkh.MaDon + " đã được xử lý nên không sửa đổi được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
                        //}
                        //else
                        //    if (itemRow["MaChuyen"].ToString() == "NONE")
                        //    {
                        //        DonKH donkh = _cDonKH.getDonKHbyID(decimal.Parse(itemRow["MaDon"].ToString()));
                        //        //if (!donkh.Nhan)
                        //        //{
                        //            donkh.Chuyen = false;
                        //            donkh.MaChuyen = null;
                        //            donkh.LyDoChuyen = null;
                        //            donkh.SoLuongDiaChi = null;
                        //            donkh.NVKiemTra = null;
                        //            _cDonKH.SuaDonKH(donkh);
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Đơn " + donkh.MaDon + " đã được xử lý nên không sửa đổi được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
                        //}
                    }
                    MessageBox.Show("Lưu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DSDonKH_Edited.Clear();

                    if (radDaDuyet.Checked)
                        DSDonKH_BS.DataSource = _cDonKH.LoadDSDonKHDaDuyet();
                    if (radChuaDuyet.Checked)
                        DSDonKH_BS.DataSource = _cDonKH.LoadDSDonKHChuaDuyet();
                    if (radAll.Checked)
                        DSDonKH_BS.DataSource = _cDonKH.LoadDSAllDonKH();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                      
        }

        /// <summary>
        /// Hiện thị số thứ tự dòng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSDonKH_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSDonKH.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        /// <summary>
        /// Ctrl+F Tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSDonKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvDSDonKH.Rows.Count > 0 && e.Control && e.KeyCode == Keys.F)
            {
                Dictionary<string, string> source = new Dictionary<string, string>();
                source.Add("Action", "Cập Nhật");
                source.Add("MaDon", dgvDSDonKH["MaDon", dgvDSDonKH.CurrentRow.Index].Value.ToString());
                frmShowDonKH frm = new frmShowDonKH(source);
                if (frm.ShowDialog() == DialogResult.OK)
                    if (radChuaDuyet.Checked)
                        DSDonKH_BS.DataSource = _cDonKH.LoadDSDonKHChuaDuyet();
                    else
                        if (radDaDuyet.Checked)
                            DSDonKH_BS.DataSource = _cDonKH.LoadDSDonKHDaDuyet();
            }
        }

        /// <summary>
        /// Bắt đầu Edit Column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSDonKH_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            btnLuu.Enabled = false;
        }

        /// <summary>
        /// Kết thúc Edit Column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Format dữ liệu trong column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSDonKH_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDSDonKH.Columns[e.ColumnIndex].Name == "MaDon" && e.Value != null)
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
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Ngày Lập":
                    txtNoiDungTimKiem.Visible = false;
                    dateTimKiem.Visible = true;
                    panel_KhoangThoiGian.Visible = false;
                    break;
                case "Khoảng Thời Gian":
                    txtNoiDungTimKiem.Visible = false;
                    dateTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = true;
                    break;
                default:
                    txtNoiDungTimKiem.Visible = false;
                    dateTimKiem.Visible = false;
                    panel_KhoangThoiGian.Visible = false;
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

        private void dateTu_ValueChanged(object sender, EventArgs e)
        {
            string expression = String.Format("CreateDate > #{0:yyyy-MM-dd} 00:00:00# and CreateDate < #{0:yyyy-MM-dd} 23:59:59#", dateTu.Value);
            DSDonKH_BS.Filter = expression;
            _tuNgay = dateTu.Value.ToString("dd/MM/yyyy");
            _denNgay = "";
        }

        private void dateDen_ValueChanged(object sender, EventArgs e)
        {
            string expression = String.Format("CreateDate > #{0:yyyy-MM-dd} 00:00:00# and CreateDate < #{1:yyyy-MM-dd} 23:59:59#", dateTu.Value, dateDen.Value);
            DSDonKH_BS.Filter = expression;
            _denNgay = dateDen.Value.ToString("dd/MM/yyyy");
        }

        private void btnInDSDonKH_Click(object sender, EventArgs e)
        {
            DataTable dt = ((DataTable)DSDonKH_BS.DataSource).DefaultView.ToTable();
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataRow itemRow in dt.Rows)
            {
                DataRow dr = dsBaoCao.Tables["DanhSachDonKH"].NewRow();

                dr["TuNgay"] = _tuNgay;
                dr["DenNgay"] = _denNgay;
                dr["TenLD"] = itemRow["TenLD"];
                dr["NgayNhan"] = itemRow["CreateDate"].ToString().Substring(0, 10);
                DonKH donkh = _cDonKH.getDonKHbyID(decimal.Parse(itemRow["MaDon"].ToString()));
                dr["MaDon"] = itemRow["MaDon"].ToString().Insert(itemRow["MaDon"].ToString().Length - 2, "-") + "/" + _cLoaiDon.getKyHieuLDubyID(donkh.MaLD.Value);
                //dr["MaXepDon"] = donkh.MaXepDon.ToString().Insert(donkh.MaXepDon.ToString().Length - 2, "-") + "/" + _cLoaiDon.getKyHieuLDubyID(donkh.MaLD.Value);
                if (donkh.KiemTraDHN)
                    dr["ChiTiet"] += "Kiểm Tra ĐHN, ";
                if (donkh.TienNuoc)
                    dr["ChiTiet"] += "Tiền Nước, ";
                if (donkh.ChiSoNuoc)
                    dr["ChiTiet"] += "Chỉ Số Nước, ";
                if (donkh.DonGiaNuoc)
                    dr["ChiTiet"] += "Đơn Giá Nước, ";
                if (donkh.SangTen)
                    dr["ChiTiet"] += "Sang Tên, ";
                if (donkh.NuocDuc)
                    dr["ChiTiet"] += "Nước Đục, ";
                if (donkh.DangKyDM || donkh.CatChuyenDM)
                    dr["ChiTiet"] += "Định Mức, ";
                if (donkh.LoaiKhac)
                    dr["ChiTiet"] += donkh.LyDoLoaiKhac + ", ";
                dr["DanhBo"] = itemRow["DanhBo"];
                dr["HoTen"] = itemRow["HoTen"];
                dr["DiaChi"] = itemRow["DiaChi"];
                dr["NoiDung"] = itemRow["NoiDung"];

                dsBaoCao.Tables["DanhSachDonKH"].Rows.Add(dr);
            }
            
            rptDSDonKH rpt = new rptDSDonKH();
            rpt.SetDataSource(dsBaoCao);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.ShowDialog();
        }

        private void dgvDSDonKH_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(itemID_KeyPress);//This line of code resolved my issue
            if (dgvDSDonKH.CurrentCell.ColumnIndex == dgvDSDonKH.Columns["SoLuongDiaChi"].Index)
            {
                TextBox itemID = e.Control as TextBox;
                if (itemID != null)
                {
                    itemID.KeyPress += new KeyPressEventHandler(itemID_KeyPress);
                }
            }
        }

        private void itemID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
