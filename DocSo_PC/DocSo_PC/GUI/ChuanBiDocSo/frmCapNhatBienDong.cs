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
using System.IO;
using DocSo_PC.LinQ;

namespace DocSo_PC.GUI.ChuanBiDocSo
{
    public partial class frmCapNhatBienDong : Form
    {
        string _fileName = "";
        string _mnu = "mnuLuuHD";
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CChuanBiDS _cHoaDon = new CChuanBiDS();


        public frmCapNhatBienDong()
        {
            InitializeComponent();
        }
        private void frmCapNhatBienDong_Load(object sender, EventArgs e)
        {
            cmbNam.Items.Add(DateTime.Now.Year - 2);
            cmbNam.Items.Add(DateTime.Now.Year - 1);
            cmbNam.Items.Add(DateTime.Now.Year);
            cmbNam.Items.Add(DateTime.Now.Year + 1);
            cmbNam.SelectedIndex = 2;
        }

        OpenFileDialog dialog = new OpenFileDialog();
        private void btnChonFile_Click(object sender, EventArgs e)
        {

            dialog.Filter = "Files (.dat)|*.dat";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtDuongDan.Text = dialog.FileName;
                _fileName = dialog.SafeFileName;
            }
        }

        private void Copy(ref  BienDong hoadonCu, BienDong hoadonMoi)
        {
            hoadonCu.Nam = hoadonMoi.Nam;
            hoadonCu.Ky = hoadonMoi.Ky;
            hoadonCu.Dot = hoadonMoi.Dot;
            hoadonCu.DanhBa = hoadonMoi.DanhBa;
            hoadonCu.HopDong = hoadonMoi.HopDong;
            hoadonCu.May = hoadonMoi.May;
            hoadonCu.TenKH = hoadonMoi.TenKH;
            hoadonCu.So = hoadonMoi.So;
            hoadonCu.Duong = hoadonMoi.Duong;
            hoadonCu.Phuong = hoadonMoi.Phuong;
            hoadonCu.Quan = hoadonMoi.Quan;
            hoadonCu.GB = hoadonMoi.GB;
            hoadonCu.DM = hoadonMoi.DM;
            hoadonCu.SH = hoadonMoi.SH;
            hoadonCu.SX = hoadonMoi.SX;
            hoadonCu.DV = hoadonMoi.DV;
            hoadonCu.HC = hoadonMoi.HC;
            hoadonCu.Hieu = hoadonMoi.Hieu;
            hoadonCu.Co = hoadonMoi.Co;
            hoadonCu.SoThan = hoadonMoi.SoThan;
            hoadonCu.Code = hoadonMoi.Code;
            hoadonCu.ChiSo = hoadonMoi.ChiSo;
            hoadonCu.TieuThu = hoadonMoi.TieuThu;
            hoadonCu.NgayGan = hoadonMoi.NgayGan;
            hoadonCu.STT = hoadonMoi.STT;
            hoadonCu.MLT1 = hoadonMoi.MLT1;
        }


        private void btnThem_Click(object sender, EventArgs e)
        {


            //if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            //{
            if (txtDuongDan.Text.Trim() != "")
            {
                string[] lines = System.IO.File.ReadAllLines(txtDuongDan.Text.Trim());

                int count = lines.Count();
                if (count > 0)
                {
                    string lineR = lines.First().Replace("\",\"", "$").Replace("\"", "");
                    string[] contents = lineR.Split('$');

                    int nam=0;
                    string ky="", dot="";
                    if (!string.IsNullOrWhiteSpace(contents[2]))
                        nam = int.Parse(contents[2]);
                    if (!string.IsNullOrWhiteSpace(contents[3]))
                        ky = contents[3];
                    if (!string.IsNullOrWhiteSpace(contents[4]))
                        dot = contents[4];
                    if (int.Parse(cmbNam.Text) == nam && cmbKy.Text == ky && cmbDot.Text != dot)
                    {
                        MessageBox.Show("File chọn không đúng với đợt đã chọn, kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        progressBar.Minimum = 0;
                        progressBar.Maximum = count;

                        int i = 1;
                        foreach (string line in lines)
                        {
                            progressBar.Value = i++;
                            lineR = line.Replace("\",\"", "$").Replace("\"", "");
                            contents = lineR.Split('$');

                            //string[] contents = System.Text.RegularExpressions.Regex.Split(line, @"\W+");

                            BienDong hoadon = new BienDong();
                            hoadon.Nam = nam;
                            hoadon.Ky = ky;
                            hoadon.Dot = dot;
                            if (!string.IsNullOrWhiteSpace(contents[8]))
                                hoadon.DanhBa = contents[8];

                            hoadon.HopDong = null;

                            if (!string.IsNullOrWhiteSpace(contents[5]))
                                hoadon.May = contents[5];

                            if (!string.IsNullOrWhiteSpace(contents[9]))
                                hoadon.TenKH = contents[9];

                            if (!string.IsNullOrWhiteSpace(contents[10]))
                                hoadon.So = contents[10];
                            if (!string.IsNullOrWhiteSpace(contents[11]))
                                hoadon.Duong = contents[11];

                            if (!string.IsNullOrWhiteSpace(contents[13]))
                                hoadon.Phuong = contents[13];
                            if (!string.IsNullOrWhiteSpace(contents[12]))
                                hoadon.Quan = contents[12];

                            if (!string.IsNullOrWhiteSpace(contents[15]))
                                hoadon.GB = short.Parse(contents[15]);
                            if (!string.IsNullOrWhiteSpace(contents[16]))
                                hoadon.DM = int.Parse(contents[16]);

                            if (!string.IsNullOrWhiteSpace(contents[17]))
                                hoadon.SH = short.Parse(contents[17]);
                            if (!string.IsNullOrWhiteSpace(contents[18]))
                                hoadon.SX = short.Parse(contents[18]);
                            if (!string.IsNullOrWhiteSpace(contents[19]))
                                hoadon.DV = short.Parse(contents[19]);
                            if (!string.IsNullOrWhiteSpace(contents[20]))
                                hoadon.HC = short.Parse(contents[20]);

                            if (!string.IsNullOrWhiteSpace(contents[21]))
                                hoadon.Co = short.Parse(contents[21]);

                            if (!string.IsNullOrWhiteSpace(contents[22]))
                                hoadon.Hieu = contents[22];

                            if (!string.IsNullOrWhiteSpace(contents[23]))
                                hoadon.SoThan = contents[23];

                            if (!string.IsNullOrWhiteSpace(contents[24]))
                                hoadon.NgayGan = DateTime.ParseExact(contents[24], "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

                            if (!string.IsNullOrWhiteSpace(contents[25]))
                                hoadon.Code = contents[25];
                            if (!string.IsNullOrWhiteSpace(contents[26]))
                                hoadon.ChiSo = int.Parse(contents[26]);

                            if (!string.IsNullOrWhiteSpace(contents[27]))
                                hoadon.TieuThu = int.Parse(contents[27]);

                            if (!string.IsNullOrWhiteSpace(contents[0]))
                                hoadon.STT = int.Parse(contents[0]);
                            if (!string.IsNullOrWhiteSpace(contents[6]))
                                hoadon.MLT1 = hoadon.Dot + "" + contents[6];
                            hoadon.NVCapNhat = CNguoiDung.TaiKhoan;
                            hoadon.BienDongID = hoadon.Nam.ToString() + hoadon.Ky + hoadon.DanhBa;

                            ///Nếu chưa có hóa đơn
                            if (!_cHoaDon.CheckExistBienDong(hoadon.DanhBa, hoadon.Nam.Value, hoadon.Ky, hoadon.Dot))
                            {
                                _cHoaDon.InsertBienDong(hoadon);
                            }
                            ///Nếu đã có hóa đơn
                            else
                            {
                                BienDong hoadonCN = _cHoaDon.GetBienDong(hoadon.DanhBa, hoadon.Nam.Value, hoadon.Ky, hoadon.Dot);
                                Copy(ref hoadonCN, hoadon);
                                _cHoaDon.UpdateBienDong(hoadonCN);
                            }
                        }

                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                else
                {
                    MessageBox.Show("File biến động không hợp lệ !!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            //}
            //else
            //    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
