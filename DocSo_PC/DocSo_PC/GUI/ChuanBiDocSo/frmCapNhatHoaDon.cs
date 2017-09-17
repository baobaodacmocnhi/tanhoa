using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.QuanTri;
using DocSo_PC.DAL.ChuanBiDocSo;
using DocSo_PC.LinQ;

namespace DocSo_PC.GUI.ChuanBiDocSo
{
    public partial class frmCapNhatHoaDon : Form
    {
        string _fileName = "";
        string _mnu = "mnuLuuHD";
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CChuanBiDS _cHoaDon = new CChuanBiDS();

        public frmCapNhatHoaDon()
        {
            InitializeComponent();
        }
        private void frmCapNhatHoaDon_Load(object sender, EventArgs e)
        {
            cmbNam.Items.Add(DateTime.Now.Year-2);
            cmbNam.Items.Add(DateTime.Now.Year - 1);
            cmbNam.Items.Add(DateTime.Now.Year);
            cmbNam.Items.Add(DateTime.Now.Year +1);
            cmbNam.SelectedIndex = 2;
         //   cmbKy.SelectedIndex = DateTime.Now.Month-1;
        }
        private void btnChonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Files (.dat)|*.dat";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtDuongDan.Text = dialog.FileName;
                _fileName = dialog.SafeFileName;
            }
        }

        private void Copy(ref HoaDon hoadonCu, HoaDon hoadonMoi)
        {
            hoadonCu.Nam = hoadonMoi.Nam;
            hoadonCu.Ky = hoadonMoi.Ky;
            hoadonCu.Dot = hoadonMoi.Dot;
            hoadonCu.DanhBa = hoadonMoi.DanhBa;
            hoadonCu.TenKH = hoadonMoi.TenKH;
            hoadonCu.So = hoadonMoi.So;
            hoadonCu.Duong = hoadonMoi.Duong;
            hoadonCu.GB = hoadonMoi.GB;
            hoadonCu.DM = hoadonMoi.DM;
            hoadonCu.Code = hoadonMoi.Code;
            hoadonCu.CSCu = hoadonMoi.CSCu;
            hoadonCu.CSMoi = hoadonMoi.CSMoi;
            hoadonCu.TieuThu = hoadonMoi.TieuThu;
            hoadonCu.TuNgay = hoadonMoi.TuNgay;
            hoadonCu.DenNgay = hoadonMoi.DenNgay;
            hoadonCu.SoHoaDon = hoadonMoi.SoHoaDon;
            hoadonCu.TienHD = hoadonMoi.TienHD;
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            //if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            //{
               if (txtDuongDan.Text.Trim() != "" && _fileName.Length == 12)
                {
                    string[] lines = System.IO.File.ReadAllLines(txtDuongDan.Text.Trim());
                    progressBar.Minimum = 0;
                    progressBar.Maximum = lines.Count();
                    int i = 1;
                    foreach (string line in lines)
                    {
                        progressBar.Value = i++;
                        string lineR = line.Replace("\",\"", "$").Replace("\"", "");
                        string[] contents = lineR.Split('$');
                        
                        //string[] contents = System.Text.RegularExpressions.Regex.Split(line, @"\W+");

                        HoaDon hoadon = new HoaDon();

                        if (!string.IsNullOrWhiteSpace(contents[19]))
                            hoadon.Nam = int.Parse("20" +contents[19]);
                        if (!string.IsNullOrWhiteSpace(contents[18]))
                            hoadon.Ky = contents[18];
                        if (!string.IsNullOrWhiteSpace(contents[1]))
                            hoadon.Dot = contents[1];
                        if (!string.IsNullOrWhiteSpace(contents[2]))
                            hoadon.DanhBa = contents[2];

                        if (!string.IsNullOrWhiteSpace(contents[7]))
                            hoadon.TenKH = contents[7];

                        if (!string.IsNullOrWhiteSpace(contents[8]))
                            hoadon.So = contents[8];
                        if (!string.IsNullOrWhiteSpace(contents[9]))
                            hoadon.Duong = contents[9];
                        if (!string.IsNullOrWhiteSpace(contents[12]))
                            hoadon.GB = int.Parse(contents[12]);
                        if (!string.IsNullOrWhiteSpace(contents[17]))
                            hoadon.DM = int.Parse(contents[17]);
                        if (!string.IsNullOrWhiteSpace(contents[20]))
                            hoadon.Code = contents[20];
                        if (!string.IsNullOrWhiteSpace(contents[22]))
                            hoadon.CSCu = int.Parse(contents[22]);

                        if (!string.IsNullOrWhiteSpace(contents[23]))
                            hoadon.CSMoi = int.Parse(contents[23]);
                        if (!string.IsNullOrWhiteSpace(contents[28]))
                            hoadon.TieuThu = int.Parse(contents[28]);
                        if (!string.IsNullOrWhiteSpace(contents[25]))
                            hoadon.TuNgay = DateTime.ParseExact(contents[25], "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                        if (!string.IsNullOrWhiteSpace(contents[26]))
                            hoadon.DenNgay = DateTime.ParseExact(contents[26], "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

                        if (!string.IsNullOrWhiteSpace(contents[46]))
                            hoadon.SoHoaDon = contents[46];

                        if (!string.IsNullOrWhiteSpace(contents[40]))
                            hoadon.TienHD = int.Parse(contents[40]);

                        hoadon.NVCapNhat = CNguoiDung.TaiKhoan;
                        hoadon.HoaDonID = hoadon.Nam.ToString() + hoadon.Ky + hoadon.DanhBa;


                        ///Nếu chưa có hóa đơn
                        if (!_cHoaDon.CheckExist(hoadon.DanhBa, hoadon.Nam.Value, hoadon.Ky, hoadon.Dot))
                        {
                            _cHoaDon.Insert(hoadon);
                        }
                        ///Nếu đã có hóa đơn
                        else
                        {
                            HoaDon hoadonCN = _cHoaDon.Get(hoadon.DanhBa, hoadon.Nam.Value, hoadon.Ky, hoadon.Dot);
                            Copy(ref hoadonCN, hoadon);
                            _cHoaDon.Update(hoadonCN);
                        }
                    }

                    
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            //}
            //else
            //    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cmbKy_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbKy.SelectedIndex != -1)
            {
                DataTable tb = _cHoaDon.GetTongByNamKy(int.Parse(cmbNam.Text), cmbKy.Text.ToString());
                int sumTongHD = tb.AsEnumerable().Sum(r => r.Field<int>("TongHD"));
                int sumSanLuong = tb.AsEnumerable().Sum(r => r.Field<int>("TongTieuThu"));
                DataRow dr = tb.NewRow();

                dr[1] = sumTongHD;
                dr[2] = sumSanLuong;
                 //dr[3] = null;

                 tb.Rows.Add(dr);

                dgvHoaDon.DataSource = tb;
                dgvHoaDon.Rows[dgvHoaDon.Rows.Count - 1].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(217))))); ;
                //dgvHoaDon.Rows[dgvHoaDon.Rows.Count - 1].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);

                
            }
        }

       

       
    }
}
