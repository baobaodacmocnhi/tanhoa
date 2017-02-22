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
            cmbTo.DataSource = _cTo.GetDS();
            cmbTo.DisplayMember = "TenTo";
            cmbTo.ValueMember = "MaTo";
            cmbTo.SelectedIndex = -1;

            _flagLoadFirst = true;
        }

        private void cmbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_flagLoadFirst == true && cmbTo.SelectedIndex != -1)
            {
                if ((_cTo.CheckHanhThu(int.Parse(cmbTo.SelectedValue.ToString()))))
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
            foreach (ListViewItem item in listA.Items)
            {
                if (listB.Items.ContainsKey(item.Name))
                {
                    listB.Items.RemoveByKey(item.Name);
                    listA.Items.Remove(item);
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
                    CExcel fileExcel = new CExcel(dialog.FileName);
                    DataTable dtExcel = fileExcel.GetDataTable("select * from [Sheet1$]");
                    foreach (DataRow item in dtExcel.Rows)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = item[0].ToString();
                        lvi.Name = item[0].ToString();

                        listA.Items.Add(lvi);
                    }
                    txtTongA.Text = dtExcel.Rows.Count.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    CExcel fileExcel = new CExcel(dialog.FileName);
                    DataTable dtExcel = fileExcel.GetDataTable("select * from [Sheet1$]");
                    foreach (DataRow item in dtExcel.Rows)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = item[0].ToString();
                        lvi.Name = item[0].ToString();

                        listB.Items.Add(lvi);
                    }
                    txtTongB.Text = dtExcel.Rows.Count.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi, Vui lòng thử lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
