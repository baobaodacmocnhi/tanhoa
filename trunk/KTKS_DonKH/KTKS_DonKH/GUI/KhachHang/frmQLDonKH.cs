﻿using System;
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
        BindingSource DSDonKH_BS = new BindingSource();

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

            dgvDSDonKH.DataSource = DSDonKH_BS;
            radChuDuyet.Checked = true;

            dateTimKiem.Location = txtNoiDungTimKiem.Location;
        }
            
        private void radDaDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radDaDuyet.Checked)
            {
                DSDonKH_BS.DataSource = _cDonKH.LoadDSDonKHDaDuyet();
            }
        }

        private void radChuDuyet_CheckedChanged(object sender, EventArgs e)
        {
            if (radChuDuyet.Checked)
            {
                DSDonKH_BS.DataSource = _cDonKH.LoadDSDonKHChuaDuyet();
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
                        DonKH donkh = _cDonKH.getDonKHbyID(decimal.Parse(itemRow["MaDon"].ToString()));
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
                            DonKH donkh = _cDonKH.getDonKHbyID(decimal.Parse(itemRow["MaDon"].ToString()));
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
                    DSDonKH_BS.DataSource = _cDonKH.LoadDSDonKHDaDuyet();
                if (radChuDuyet.Checked)
                    DSDonKH_BS.DataSource = _cDonKH.LoadDSDonKHChuaDuyet();
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
                if(frm.ShowDialog()==DialogResult.OK)
                    DSDonKH_BS.DataSource = _cDonKH.LoadDSDonKHChuaDuyet();
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
                    break;
                case "Ngày Lập":
                    txtNoiDungTimKiem.Visible = false;
                    dateTimKiem.Visible = true;
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
