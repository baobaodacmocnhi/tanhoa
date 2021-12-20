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
using DocSo_PC.DAL;
using System.Globalization;
using System.Data.SqlClient;

namespace DocSo_PC.GUI.ChuanBiDocSo
{
    public partial class frmCapNhatBienDong : Form
    {
        string _fileName = "";
        string _mnu = "mnuLuuHD";
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CChuanBiDS _cChuanBi = new CChuanBiDS();
        CDAL _cDAL = new CDAL();


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

            if (DateTime.Now.Day >= 19)
                cmbKy.SelectedIndex = DateTime.Now.Month;
            else
                cmbKy.SelectedIndex = DateTime.Now.Month - 1;
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


        public void Add()
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

                    int nam = 0;
                    string ky = "", dot = "";
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
                            if (!_cChuanBi.CheckExistBienDong(hoadon.DanhBa, hoadon.Nam.Value, hoadon.Ky, hoadon.Dot))
                            {
                                _cChuanBi.InsertBienDong(hoadon);
                            }
                            ///Nếu đã có hóa đơn
                            else
                            {
                                BienDong hoadonCN = _cChuanBi.GetBienDong(hoadon.DanhBa, hoadon.Nam.Value, hoadon.Ky, hoadon.Dot);
                                Copy(ref hoadonCN, hoadon);
                                _cChuanBi.UpdateBienDong(hoadonCN);
                            }
                        }

                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBienDong();

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

        public void AddSQL(int _nam, string _ky, string _dot)
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

                    int nam = 0;
                    string ky = "", dot = "";
                    if (!string.IsNullOrWhiteSpace(contents[2]))
                        nam = int.Parse(contents[2]);
                    if (!string.IsNullOrWhiteSpace(contents[3]))
                        ky = contents[3];
                    if (!string.IsNullOrWhiteSpace(contents[4]))
                        dot = contents[4];
                    if (_nam == nam && _ky == ky && _dot != dot)
                    {
                        MessageBox.Show("File chọn không đúng với đợt đã chọn, kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        progressBar.Minimum = 0;
                        progressBar.Maximum = count;

                        int i = 1;

                        SqlConnection thisConnection = new SqlConnection(DocSo_PC.Properties.Settings.Default.DocSoTHTestConnectionString);
                        SqlCommand command = null;
                        thisConnection.Open();

                        string sql = "DELETE FROM [BienDong] WHERE NAM='" + nam + "' AND KY='" + ky + "' AND DOT='" + dot + "'";
                        command = new SqlCommand(sql, thisConnection);
                        command.ExecuteNonQuery();


                        foreach (string line in lines)
                        {
                            progressBar.Value = i++;
                            lineR = line.Replace("\",\"", "$").Replace("\"", "");
                            contents = lineR.Split('$');
                            string danhba = contents[8];

                            BienDong h = new BienDong();
                            h.Nam = nam;
                            h.Ky = ky;
                            h.Dot = dot;
                            h.DanhBa = danhba;
                            h.HopDong = null;
                            if (!string.IsNullOrWhiteSpace(contents[5]))
                                h.May = contents[5];
                            if (!string.IsNullOrWhiteSpace(contents[9]))
                                h.TenKH = contents[9];
                            if (!string.IsNullOrWhiteSpace(contents[10]))
                                h.So = contents[10];
                            if (!string.IsNullOrWhiteSpace(contents[11]))
                                h.Duong = contents[11];
                            if (!string.IsNullOrWhiteSpace(contents[13]))
                                h.Phuong = contents[13];
                            if (!string.IsNullOrWhiteSpace(contents[12]))
                                h.Quan = contents[12];
                            if (!string.IsNullOrWhiteSpace(contents[15]))
                                h.GB = short.Parse(contents[15]);
                            if (!string.IsNullOrWhiteSpace(contents[16]))
                                h.DM = int.Parse(contents[16]);
                            if (!string.IsNullOrWhiteSpace(contents[17]))
                                h.SH = short.Parse(contents[17]);
                            if (!string.IsNullOrWhiteSpace(contents[18]))
                                h.SX = short.Parse(contents[18]);
                            if (!string.IsNullOrWhiteSpace(contents[19]))
                                h.DV = short.Parse(contents[19]);
                            if (!string.IsNullOrWhiteSpace(contents[20]))
                                h.HC = short.Parse(contents[20]);
                            if (!string.IsNullOrWhiteSpace(contents[21]))
                                h.Co = short.Parse(contents[21]);
                            if (!string.IsNullOrWhiteSpace(contents[22]))
                                h.Hieu = contents[22];
                            if (!string.IsNullOrWhiteSpace(contents[23]))
                                h.SoThan = contents[23];
                            if (!string.IsNullOrWhiteSpace(contents[24]))
                                h.NgayGan = DateTime.ParseExact(contents[24], "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                            if (!string.IsNullOrWhiteSpace(contents[25]))
                                h.Code = contents[25];
                            if (!string.IsNullOrWhiteSpace(contents[26]))
                                h.ChiSo = int.Parse(contents[26]);
                            if (!string.IsNullOrWhiteSpace(contents[27]))
                                h.TieuThu = int.Parse(contents[27]);
                            if (!string.IsNullOrWhiteSpace(contents[0]))
                                h.STT = int.Parse(contents[0]);
                            if (!string.IsNullOrWhiteSpace(contents[6]))
                                h.MLT1 = h.Dot + h.May + "" + contents[6];
                            h.NVCapNhat = CNguoiDung.TaiKhoan;
                            h.BienDongID = h.Nam.ToString() + h.Ky + h.DanhBa;

                            //string cmd = "INSERT INTO [BienDong] ([BienDongID],[Nam],[Ky],[Dot],[DanhBa]) ";
                            //cmd += "VALUES ('" + BienDongID + "'," + nam + ",'" + ky + "','" + dot + "','" + danhba + "')";

                            string cmd = "INSERT INTO [BienDong] ([BienDongID],[Nam],[Ky],[Dot],[DanhBa],[HopDong],[May],[TenKH],[So],[Duong],[Phuong],[Quan],[GB],[DM],[SH],[SX],[DV],[HC],[Hieu],[Co],[SoThan],[Code],[ChiSo],[TieuThu],[NgayGan],[STT],[MLT1],[NVCapNhat]) ";
                            cmd += " VALUES ('" + h.BienDongID + "'," + h.Nam + ",'" + h.Ky + "','" + h.Dot + "','" + h.DanhBa + "','" + h.HopDong + "','" + h.May + "','" + h.TenKH + "','" + h.So + "',";
                            cmd += "'" + h.Duong + "','" + h.Phuong + "','" + h.Quan + "',0" + h.GB + ",0" + h.DM + ",0" + h.SH + ",0" + h.SX + ",0" + h.DV + ",0" + h.HC + ",'" + h.Hieu + "',";
                            cmd += "'" + h.Co + "','" + h.SoThan + "','" + h.Code + "',0" + h.ChiSo + ",0" + h.TieuThu + ",'" + h.NgayGan + "','" + h.STT + "','" + h.MLT1 + "','" + h.NVCapNhat + "')";

                            command = new SqlCommand(cmd, thisConnection);
                            command.ExecuteNonQuery();
                        }
                        thisConnection.Close();
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
        private void btnThem_Click(object sender, EventArgs e)
        {
            int nam = int.Parse(cmbNam.Text);
            string ky = cmbKy.Text;
            string dot = cmbDot.Text;

            AddSQL(nam, ky, dot);
            // Cập Nhật Thông Tin Biến Động
            _cChuanBi.UpdateStoredProcedure("UpdateBienDong", nam, ky, dot);

            LoadBienDong();
        }


        void LoadBienDong()
        {
            string sql = " select count(case when LEFT(CODE,1) ='4' then 1 else null end) AS '4',  ";
            sql += " count(case when LEFT(CODE,1) ='5' then 1 else null end) AS '5',   ";
            sql += " count(case when LEFT(CODE,1) ='6' then 1 else null end) AS '6',   ";
            sql += " count(case when LEFT(CODE,1) ='8' then 1 else null end) AS '8',   ";
            sql += " count(case when LEFT(CODE,1) ='F' then 1 else null end) AS 'F',   ";
            sql += " count(case when LEFT(CODE,1) ='K' then 1 else null end) AS 'K',   ";
            sql += " count(case when LEFT(CODE,1) ='M' then 1 else null end) AS 'M',   ";
            sql += " count(case when LEFT(CODE,1) ='N' then 1 else null end) AS 'N',   ";
            sql += " count(case when LEFT(CODE,1) ='Q' then 1 else null end) AS 'Q'	     ";
            sql += " from BienDong where NAM=" + cmbNam.Text + " and KY='" + cmbKy.Text + "' and dot='" + cmbDot.Text + "' ";
            dataCode.DataSource = CChuanBiDS._cDAL.ExecuteQuery_DataTable(sql);


            sql = "select  [MLT1], [DanhBa],[May],[TenKH],[So],[Duong],[Phuong],[Quan],[GB],[DM],[Hieu],[Co],[SoThan],[Code],[ChiSo],[TieuThu],convert(varchar(50),[NgayGan],103) as [NgayGan],[NgayCapNhat],[NVCapNhat] from BienDong where NAM=" + cmbNam.Text + " and KY='" + cmbKy.Text + "' and dot='" + cmbDot.Text + "' ";
            DataTable tb = CChuanBiDS._cDAL.ExecuteQuery_DataTable(sql);
            dataBiendong.DataSource = tb;
            lbSoLuongBd.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", tb.Rows.Count);


        }

        private void cmbDot_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadBienDong();
        }

        private void dataCode_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string headerText = dataCode.Columns[e.ColumnIndex].HeaderText;

                string sql = "select [MLT1], [DanhBa],[May],[TenKH],[So],[Duong],[Phuong],[Quan],[GB],[DM],[Hieu],[Co],[SoThan],[Code],[ChiSo],[TieuThu],convert(varchar(50),[NgayGan],103) as [NgayGan],[NgayCapNhat],[NVCapNhat] from BienDong where NAM=" + cmbNam.Text + " and KY='" + cmbKy.Text + "' and dot='" + cmbDot.Text + "'  AND LEFT(CODE,1)='" + headerText + "'";
                DataTable tb = CChuanBiDS._cDAL.ExecuteQuery_DataTable(sql);
                dataBiendong.DataSource = tb;

            }
            catch (Exception)
            {
            }
            
        }

        private void dataBiendong_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataBiendong.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }
    }
}