using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.QuanTri;
using KTKS_DonKH.DAL.PhongKhachHang;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL;
using System.IO;

namespace KTKS_DonKH.GUI.PhongKhachHang
{
    public partial class frmTraHopDong : Form
    {
        string _mnu = "mnuTraHopDong";
        CTraHopDong _cTHD = new CTraHopDong();
        KH_HopDong _en = new KH_HopDong();
        CDHN _cDHN = new CDHN();

        public frmTraHopDong()
        {
            InitializeComponent();
        }

        private void frmTraHopDong_Load(object sender, EventArgs e)
        {
            dgvDanhBo.AutoGenerateColumns = false;
            Clear();
            txtNam.Text = DateTime.Now.Year.ToString();
            txtKy.Text = DateTime.Now.Month.ToString();
        }

        public void LoadEntity(KH_HopDong en)
        {
            txtID.Text = en.ID.ToString();
            txtDanhBo.Text = en.DanhBo;
        }

        public void Clear()
        {
            txtID.Text = "";
            txtDanhBo.Text = "";
            _en = null;

            dgvDanhBo.DataSource = _cTHD.getDS();

            txtDanhBo.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Them"))
                {
                    if (_cDHN.CheckExist(txtDanhBo.Text.Trim().Replace(" ", "")) == false)
                    {
                        MessageBox.Show("Danh Bộ không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    KH_HopDong en = new KH_HopDong();
                    en.DanhBo = txtDanhBo.Text.Trim().Replace(" ", "");
                    if (_cTHD.them(en) == true)
                    {
                        MessageBox.Show("Thành công STT: " + en.ID, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                {

                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (CTaiKhoan.CheckQuyen(_mnu, "Xoa"))
                {
                    if (_en != null && MessageBox.Show("Bạn chắc chắn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (_cTHD.xoa(_en) == true)
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhBo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDanhBo.Columns[e.ColumnIndex].Name == "SoTien" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(7, " ").Insert(4, " ");
            }
        }

        private void dgvDanhBo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhBo.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDanhBo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _en = _cTHD.get(int.Parse(dgvDanhBo.CurrentRow.Cells["ID"].Value.ToString()));
                LoadEntity(_en);
            }
            catch (Exception)
            {
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBo.Text.Trim().Replace(" ", "").Length == 11)
                btnThem.PerformClick();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvDanhBo.DataSource = _cTHD.getDS(txtDanhBo.Text.Trim().Replace(" ", ""));
        }

        private void dgvDanhBo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDanhBo.Columns[e.ColumnIndex].Name == "Tra")
                {
                    if (CTaiKhoan.CheckQuyen(_mnu, "Sua"))
                    {
                        if (_en != null)
                        {
                            _en.Tra = bool.Parse(dgvDanhBo[e.ColumnIndex, e.RowIndex].Value.ToString());
                            if (_en.Tra == true)
                                _en.NgayTra = DateTime.Now;
                            else
                                _en.NgayTra = null;
                            _cTHD.sua(_en);
                        }
                    }
                    else
                        MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatTXT_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                //saveFileDialog1.init = @ "C:\";      
                saveFileDialog1.Title = "Save text Files";
                //saveFileDialog1.CheckFileExists = true;
                saveFileDialog1.CheckPathExists = true;
                saveFileDialog1.DefaultExt = "txt";
                saveFileDialog1.Filter = "Text files (*.txt)|*.txt";
                //saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.FileName = "lichdocso." + txtKy.Text.Trim() + "." + txtNam.Text.Trim();
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog1.FileName;
                    // Check if file already exists. If yes, delete it.     
                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }
                    CDocSo _cDocSo = new CDocSo();
                    //string sql = "select Nam,Ky,Dot=RIGHT('0' + CAST(d.ID AS VARCHAR(2)), 2),nd.May,NgayDoc=CONVERT(varchar(10),NgayDoc,103),nd.HoTen,DienThoai=REPLACE(nd.DienThoai,'.','')"
                    //                + " from Lich_DocSo ds,Lich_DocSo_ChiTiet ctds,Lich_Dot d,NguoiDung nd"
                    //                + " where ds.ID=ctds.IDDocSo and d.ID=ctds.IDDot and Nam=" + txtNam.Text.Trim() + " and Ky=" + txtKy.Text.Trim() + " and nd.May!=''"
                    //                + " and ((nd.May>=SUBSTRING(d.TB1_From,3,2) and nd.May<=SUBSTRING(d.TB1_To,3,2)) "
                    //                + " or (nd.May>=SUBSTRING(d.TB2_From,3,2) and nd.May<=SUBSTRING(d.TB2_To,3,2)) "
                    //                + " or (nd.May>=SUBSTRING(d.TP1_From,3,2) and nd.May<=SUBSTRING(d.TP1_To,3,2)) "
                    //                + " or (nd.May>=SUBSTRING(d.TP2_From,3,2) and nd.May<=SUBSTRING(d.TP2_To,3,2)))";
                    string sql = "select Nam,Ky,Dot=RIGHT('0' + CAST(d.ID AS VARCHAR(2)), 2),nd.May,NgayDoc=CONVERT(varchar(10),NgayDoc,103),nd.HoTen,DienThoai=REPLACE(nd.DienThoai,'.','')"
                                   + " from Lich_DocSo ds,Lich_DocSo_ChiTiet ctds,Lich_Dot d,NguoiDung nd"
                                   + " where ds.ID=ctds.IDDocSo and d.ID=ctds.IDDot and Nam=" + txtNam.Text.Trim() + " and Ky=" + txtKy.Text.Trim() + " and nd.May!=''"
                                   + " and ((nd.May>=SUBSTRING(d.To1_From,3,2) and nd.May<=SUBSTRING(d.To1_To,3,2)) "
                                   + " or (nd.May>=SUBSTRING(d.To2_From,3,2) and nd.May<=SUBSTRING(d.To2_To,3,2)))";
                    DataTable dt = _cDocSo.ExecuteQuery_DataTable(sql);
                    // Create a new file     
                    using (StreamWriter sw = File.CreateText(fileName))
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            sw.WriteLine(item["Nam"] + "," + item["Ky"] + "," + item["Dot"] + "," + item["May"] + "," + item["NgayDoc"] + "," + item["HoTen"] + "," + item["DienThoai"].ToString().Split('-')[0]);
                        }
                    }
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
