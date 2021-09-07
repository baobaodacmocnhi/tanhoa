using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using ThuTien.LinQ;
using ThuTien.DAL.Doi;
using ThuTien.DAL.ChuyenKhoan;

namespace ThuTien.GUI.Doi
{
    public partial class frmKiemTraSaiBiet : Form
    {
        CTo _cTo = new CTo();
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CHoaDon _cHoaDon = new CHoaDon();
        bool _flagLoadFirst = false;


        public frmKiemTraSaiBiet()
        {
            InitializeComponent();
        }

        private void frmKiemTraSaiViec_Load(object sender, EventArgs e)
        {
            cmbTo.DataSource = _cTo.getDS();
            cmbTo.DisplayMember = "TenTo";
            cmbTo.ValueMember = "MaTo";
            cmbTo.SelectedIndex = -1;

            _flagLoadFirst = true;
        }

        private void cmbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_flagLoadFirst == true && cmbTo.SelectedIndex != -1)
            {
                if ((_cTo.checkHanhThu(int.Parse(cmbTo.SelectedValue.ToString()))))
                    cmbNhanVien.DataSource = _cNguoiDung.GetDSHanhThuByMaTo(int.Parse(cmbTo.SelectedValue.ToString()));
                else
                    cmbNhanVien.DataSource = _cNguoiDung.GetDSByToVanPhong(int.Parse(cmbTo.SelectedValue.ToString()));
                cmbNhanVien.DisplayMember = "HoTen";
                cmbNhanVien.ValueMember = "MaND";
            }
            else
                cmbNhanVien.DataSource = null;
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Files (.dat)|*.dat";
                dialog.Multiselect = false;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    int i = 0;
                    string[] lines = System.IO.File.ReadAllLines(dialog.FileName);
                    foreach (string line in lines)
                    {
                        string lineR = line.Replace("\",\"", "$").Replace("\"", "");
                        string[] contents = lineR.Split('$');
                        string[] date = contents[2].Split('/');
                        HOADON hoadon = _cHoaDon.Get(contents[3], int.Parse(date[1].ToString()), int.Parse(date[0].ToString()));
                        if (hoadon != null)
                        {
                            ListViewItem lvi = new ListViewItem();
                            lvi.Text = hoadon.SOHOADON;
                            lvi.SubItems.Add(hoadon.KY + "/" + hoadon.NAM);
                            lvi.SubItems.Add(hoadon.TONGCONG.ToString());
                            lvi.SubItems.Add(hoadon.DANHBA.Insert(7, " ").Insert(4, " "));
                            lvi.Name = hoadon.SOHOADON;

                            lstView_Billing.Items.Add(lvi);
                            i++;
                        }
                    }
                    txtTongHD_Billing.Text = i.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            lstView_TH.Items.Clear();
            DataTable dt = new DataTable();
            int i = 0;
            if (cmbNhanVien.Items.Count > 0 && cmbNhanVien.SelectedIndex != -1)
                dt = _cHoaDon.GetDSDangNgan((int)cmbNhanVien.SelectedValue, dateGiaiTrach.Value);

            foreach (DataRow item in dt.Rows)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = item["SoHoaDon"].ToString();
                lvi.SubItems.Add(item["Ky"].ToString());
                lvi.SubItems.Add(item["TongCong"].ToString());
                lvi.SubItems.Add(item["DanhBo"].ToString().Insert(7, " ").Insert(4, " "));
                lvi.Name = item["SoHoaDon"].ToString();

                lstView_TH.Items.Add(lvi);
                i++;
            }
            txtTongHD_TH.Text = i.ToString();
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstView_Billing.Items)
            {
                if (lstView_TH.Items.ContainsKey(item.Name))
                {
                    lstView_TH.Items.RemoveByKey(item.Name);
                    lstView_Billing.Items.Remove(item);
                }
            }
        }

        private void btnKiemTraAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstViewA.Items)
            {
                if (lstViewB.Items.ContainsKey(item.Name))
                {
                    lstViewB.Items.RemoveByKey(item.Name);
                    lstViewA.Items.Remove(item);
                }
            }
        }

        private void btnChonFileA_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                dialog.Multiselect = false;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    lstViewA.Items.Clear();
                    DataTable dtExcel = _cHoaDon.ExcelToDataTable(dialog.FileName);
                    //CExcel fileExcel = new CExcel(dialog.FileName);
                    //DataTable dtExcel = fileExcel.GetDataTable("select * from [Sheet1$]");
                    foreach (DataRow item in dtExcel.Rows)
                        if (item[0].ToString().Trim() != "")
                        {
                            ListViewItem lvi = new ListViewItem();
                            lvi.Text = item[0].ToString();
                            lvi.Name = item[0].ToString();

                            lstViewA.Items.Add(lvi);
                        }
                    txtTongA.Text = dtExcel.Rows.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi, Vui lòng thử lại "+ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChonFileB_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                dialog.Multiselect = false;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    lstViewB.Items.Clear();
                    DataTable dtExcel = _cHoaDon.ExcelToDataTable(dialog.FileName);
                    //CExcel fileExcel = new CExcel(dialog.FileName);
                    //DataTable dtExcel = fileExcel.GetDataTable("select * from [Sheet1$]");
                    foreach (DataRow item in dtExcel.Rows)
                        if (item[0].ToString().Trim() != "")
                        {
                            ListViewItem lvi = new ListViewItem();
                            lvi.Text = item[0].ToString();
                            lvi.Name = item[0].ToString();

                            lstViewB.Items.Add(lvi);
                        }
                    txtTongB.Text = dtExcel.Rows.Count.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCopyToClipboard_Billing_Click(object sender, EventArgs e)
        {
            string str = "";
            foreach (ListViewItem item in lstView_Billing.Items)
            {
                str += item.Text + "\n";
            }
            Clipboard.SetText(str);
        }

        private void btnCopyToClipboard_TH_Click(object sender, EventArgs e)
        {
            string str = "";
            foreach (ListViewItem item in lstView_TH.Items)
            {
                str += item.Text + "\n";
            }
            Clipboard.SetText(str);
        }

        private void btnCopyToClipboardA_Click(object sender, EventArgs e)
        {
            string str = "";
            foreach (ListViewItem item in lstViewA.Items)
            {
                str += item.Text + "\n";
            }
            Clipboard.SetText(str);
        }

        private void btnCopyToClipboardB_Click(object sender, EventArgs e)
        {
            string str = "";
            foreach (ListViewItem item in lstViewB.Items)
            {
                str += item.Text + "\n";
            }
            Clipboard.SetText(str);
        }

        private void txtNoiDungA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtNoiDungA.Text.Trim()))
            {
                foreach (string item in txtNoiDungA.Lines)
                    if (item.Trim() != "")
                    {
                        if (lstViewA.FindItemWithText(item.Trim().ToUpper()) == null)
                        {
                            ListViewItem lvi = new ListViewItem();
                            lvi.Text = item.Trim().ToUpper();
                            lvi.Name = item.Trim().ToUpper();
                            lstViewA.Items.Add(lvi);
                            lstViewA.EnsureVisible(lstViewA.Items.Count - 1);
                        }
                    }
                //else
                //    ///Trung An thêm 'K' phía cuối liên hóa đơn
                //    if (item.Trim() != "")
                //    {
                //        if (lstViewA.FindItemWithText(item.Trim().ToUpper().Replace("K", "")) == null)
                //        {
                //            lstViewA.Items.Add(item.Trim().ToUpper().Replace("K", ""));
                //            lstViewA.EnsureVisible(lstViewA.Items.Count - 1);
                //        }
                //    }
                txtTongA.Text = lstViewA.Items.Count.ToString();
                txtNoiDungA.Text = "";
            }
        }

        private void txtNoiDungB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && !string.IsNullOrEmpty(txtNoiDungB.Text.Trim()))
            {
                foreach (string item in txtNoiDungB.Lines)
                    if (item.Trim() != "")
                    {
                        if (lstViewB.FindItemWithText(item.Trim().ToUpper()) == null)
                        {
                            ListViewItem lvi = new ListViewItem();
                            lvi.Text = item.Trim().ToUpper();
                            lvi.Name = item.Trim().ToUpper();
                            lstViewB.Items.Add(lvi);
                            lstViewB.EnsureVisible(lstViewB.Items.Count - 1);
                        }
                    }
                //else
                //    ///Trung An thêm 'K' phía cuối liên hóa đơn
                //    if (item.Trim() != "")
                //    {
                //        if (lstViewB.FindItemWithText(item.Trim().ToUpper().Replace("K", "")) == null)
                //        {
                //            lstViewB.Items.Add(item.Trim().ToUpper().Replace("K", ""));
                //            lstViewB.EnsureVisible(lstViewB.Items.Count - 1);
                //        }
                //    }
                txtTongB.Text = lstViewB.Items.Count.ToString();
                txtNoiDungB.Text = "";
            }
        }

        private void btnSoSanh_Click(object sender, EventArgs e)
        {

        }

    }
}
