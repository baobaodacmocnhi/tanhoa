using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.Doi;
using System.Globalization;
using ThuTien.LinQ;
using ThuTien.DAL;

namespace ThuTien.GUI.Doi
{
    public partial class frmLuuHD : Form
    {
        string _fileName = "";
        string _mnu = "mnuLuuHD";
        CNguoiDung _cNguoiDung = new CNguoiDung();
        CHoaDon _cHoaDon = new CHoaDon();
        CCAPNUOCTANHOA _cCapNuocTanHoa = new CCAPNUOCTANHOA();
         
        public frmLuuHD()
        {
            InitializeComponent();
        }

        private void frmLuuHoaDon_Load(object sender, EventArgs e)
        {
            dgvHoaDon.AutoGenerateColumns = false;
            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";
            cmbKy.SelectedItem = DateTime.Now.Month.ToString();
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
            {
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
                        HOADON hoadon = new HOADON();
                        //if (!string.IsNullOrWhiteSpace(contents[0]))
                        //    hoadon.Khu = int.Parse(contents[0]);
                        if (!string.IsNullOrWhiteSpace(contents[1]))
                            hoadon.DOT = int.Parse(contents[1]);
                        if (!string.IsNullOrWhiteSpace(contents[2]))
                            hoadon.DANHBA = contents[2];
                        //if (!string.IsNullOrWhiteSpace(contents[3]))
                        //    hoadon.CD = int.Parse(contents[3]);
                        //if (!string.IsNullOrWhiteSpace(contents[4]))
                        //    hoadon.CuLy = int.Parse(contents[4]);
                        //if (!string.IsNullOrWhiteSpace(contents[5]))
                        //    hoadon.MSTLK = contents[5];
                        if (!string.IsNullOrWhiteSpace(contents[6]))
                            hoadon.HOPDONG = contents[6];
                        if (!string.IsNullOrWhiteSpace(contents[7]))
                            hoadon.TENKH = contents[7];
                        if (!string.IsNullOrWhiteSpace(contents[8]))
                            hoadon.SO = contents[8];
                        if (!string.IsNullOrWhiteSpace(contents[9]))
                            hoadon.DUONG = contents[9];
                        //if (!string.IsNullOrWhiteSpace(contents[10]))
                        //    hoadon.MSKH = contents[10];
                        //if (!string.IsNullOrWhiteSpace(contents[11]))
                        //    hoadon.MSCQ = contents[11];
                        if (!string.IsNullOrWhiteSpace(contents[12]))
                            hoadon.GB = int.Parse(contents[12]);
                        if (!string.IsNullOrWhiteSpace(contents[13]))
                            hoadon.TILESH = int.Parse(contents[13]);
                        if (!string.IsNullOrWhiteSpace(contents[14]))
                            hoadon.TILEHCSN = int.Parse(contents[14]);
                        if (!string.IsNullOrWhiteSpace(contents[15]))
                            hoadon.TILESX = int.Parse(contents[15]);
                        if (!string.IsNullOrWhiteSpace(contents[16]))
                            hoadon.TILEDV = int.Parse(contents[16]);
                        if (!string.IsNullOrWhiteSpace(contents[17]))
                            hoadon.DM = int.Parse(contents[17]);
                        if (!string.IsNullOrWhiteSpace(contents[18]))
                            hoadon.KY = int.Parse(contents[18]);
                        if (!string.IsNullOrWhiteSpace(contents[19]))
                            hoadon.NAM = int.Parse("20" + contents[19]);
                        if (!string.IsNullOrWhiteSpace(contents[20]))
                            hoadon.CODE = contents[20];
                        //if (!string.IsNullOrWhiteSpace(contents[21]))
                        //    hoadon.CodeFu = contents[21];
                        if (!string.IsNullOrWhiteSpace(contents[22]))
                            hoadon.CSCU = int.Parse(contents[22]);
                        if (!string.IsNullOrWhiteSpace(contents[23]))
                            hoadon.CSMOI = int.Parse(contents[23]);
                        //if (!string.IsNullOrWhiteSpace(contents[24]))
                        //    hoadon.RT = contents[24];
                        if (!string.IsNullOrWhiteSpace(contents[25]))
                            hoadon.TUNGAY = DateTime.ParseExact(contents[25], "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                        if (!string.IsNullOrWhiteSpace(contents[26]))
                            hoadon.DENNGAY = DateTime.ParseExact(contents[26], "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                        if (!string.IsNullOrWhiteSpace(contents[27]))
                            hoadon.SONGAY = int.Parse(contents[27]);
                        if (!string.IsNullOrWhiteSpace(contents[28]))
                            hoadon.TIEUTHU = int.Parse(contents[28]);
                        //if (!string.IsNullOrWhiteSpace(contents[29]))
                        //    hoadon.LNCT = int.Parse(contents[29]);
                        if (!string.IsNullOrWhiteSpace(contents[30]))
                            hoadon.TIEUTHUBU = int.Parse(contents[30]);
                        if (!string.IsNullOrWhiteSpace(contents[31]))
                            hoadon.TIEUTHUSH = int.Parse(contents[31]);
                        if (!string.IsNullOrWhiteSpace(contents[32]))
                            hoadon.TIEUTHUHCSN = int.Parse(contents[32]);
                        if (!string.IsNullOrWhiteSpace(contents[33]))
                            hoadon.TIEUTHUSX = int.Parse(contents[33]);
                        if (!string.IsNullOrWhiteSpace(contents[34]))
                            hoadon.TIEUTHUDV = int.Parse(contents[34]);
                        if (!string.IsNullOrWhiteSpace(contents[35]))
                            hoadon.MAY = contents[35];
                        if (!string.IsNullOrWhiteSpace(contents[36]))
                            hoadon.STT = contents[36];
                        if (!string.IsNullOrWhiteSpace(contents[37]))
                            hoadon.GIABAN = int.Parse(contents[37]);
                        if (!string.IsNullOrWhiteSpace(contents[38]))
                            hoadon.THUE = int.Parse(contents[38]);
                        if (!string.IsNullOrWhiteSpace(contents[39]))
                            hoadon.PHI = int.Parse(contents[39]);
                        if (!string.IsNullOrWhiteSpace(contents[40]))
                            hoadon.TONGCONG = int.Parse(contents[40]);
                        if (!string.IsNullOrWhiteSpace(contents[41]))
                            hoadon.GIABAN_BU = int.Parse(contents[41]);
                        if (!string.IsNullOrWhiteSpace(contents[42]))
                            hoadon.THUE_BU = int.Parse(contents[42]);
                        if (!string.IsNullOrWhiteSpace(contents[43]))
                            hoadon.PHI_BU = int.Parse(contents[43]);
                        if (!string.IsNullOrWhiteSpace(contents[44]))
                            hoadon.TONGCONG_BU = int.Parse(contents[44]);
                        if (!string.IsNullOrWhiteSpace(contents[45]))
                            hoadon.SOPHATHANH = int.Parse(contents[45]);
                        if (!string.IsNullOrWhiteSpace(contents[46]))
                            hoadon.SOHOADON = contents[46];
                        //if (!string.IsNullOrWhiteSpace(contents[47]))
                        //    hoadon.NgayPhatHanh = DateTime.Parse(contents[47]);
                        //if (!string.IsNullOrWhiteSpace(contents[48]))
                        //    hoadon.Quan = int.Parse(contents[48]);
                        //if (!string.IsNullOrWhiteSpace(contents[49]))
                        //    hoadon.Phuong = int.Parse(contents[49]);
                        //if (!string.IsNullOrWhiteSpace(contents[50]))
                        //    hoadon.SoDHN = contents[50];
                        if (!string.IsNullOrWhiteSpace(contents[51]))
                            hoadon.MST = contents[51];
                        //if (!string.IsNullOrWhiteSpace(contents[52]))
                        //    hoadon.TileTieuThu = contents[52];
                        //if (!string.IsNullOrWhiteSpace(contents[53]))
                        //    hoadon.NgayGanDHN = DateTime.ParseExact(contents[53], "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                        //if (!string.IsNullOrWhiteSpace(contents[54]))
                        //    hoadon.SoHo = contents[54];
                        hoadon.MALOTRINH = hoadon.DOT.Value.ToString("00") + hoadon.MAY + hoadon.STT;

                        //string Quan = "", Phuong = "", CoDH = "", MaDMA = "";
                        //_cCapNuocTanHoa.GetDMA(hoadon.DANHBA, out Quan, out Phuong, out CoDH, out MaDMA);
                        //hoadon.Quan = Quan;
                        //hoadon.Phuong = Phuong;
                        //hoadon.CoDH = CoDH;
                        //hoadon.MaDMA = MaDMA;
                        //if (CheckByNamKyDot(hoadon.NAM.Value, hoadon.KY, hoadon.DOT.Value))
                        //{
                        //    this.Rollback();
                        //    System.Windows.Forms.MessageBox.Show("Năm " + hoadon.NAM.Value + "; Kỳ " + hoadon.KY + "; Đợt " + hoadon.DOT.Value + " đã có rồi", "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        //    return false;
                        //}

                        if (!_cHoaDon.CheckBySoHoaDon(hoadon.SOHOADON))
                            _cHoaDon.Them(hoadon);
                        else
                        {
                            if (hoadon.DM != null)
                                _cHoaDon.LinQ_ExecuteNonQuery("update HOADON set HOPDONG='" + hoadon.HOPDONG + "',GB=" + hoadon.GB.Value + ",DM=" + hoadon.DM.Value + ",CODE='" + hoadon.CODE + "',CSCU=" + hoadon.CSCU.Value + ",CSMOI=" + hoadon.CSMOI.Value + ",TIEUTHU=" + hoadon.TIEUTHU.Value + ",GIABAN=" + hoadon.GIABAN.Value + ",THUE=" + hoadon.THUE.Value + ",PHI=" + hoadon.PHI.Value + ",TONGCONG=" + hoadon.TONGCONG.Value + ",SOPHATHANH='" + hoadon.SOPHATHANH + "' where SOHOADON='" + hoadon.SOHOADON + "'");
                            else
                                _cHoaDon.LinQ_ExecuteNonQuery("update HOADON set HOPDONG='" + hoadon.HOPDONG + "',GB=" + hoadon.GB.Value + ",CODE='" + hoadon.CODE + "',CSCU=" + hoadon.CSCU.Value + ",CSMOI=" + hoadon.CSMOI.Value + ",TIEUTHU=" + hoadon.TIEUTHU.Value + ",GIABAN=" + hoadon.GIABAN.Value + ",THUE=" + hoadon.THUE.Value + ",PHI=" + hoadon.PHI.Value + ",TONGCONG=" + hoadon.TONGCONG.Value + ",SOPHATHANH='" + hoadon.SOPHATHANH + "' where SOHOADON='" + hoadon.SOHOADON + "'");
                            //string sql = "";
                            //if (hoadon.TILESH != null)
                            //    sql += "TILESH=" + hoadon.TILESH;
                            //else
                            //    sql += "TILESH=null";

                            //if (hoadon.TILEHCSN != null)
                            //    sql += ",TILEHCSN=" + hoadon.TILEHCSN;
                            //else
                            //    sql += ",TILEHCSN=null";

                            //if (hoadon.TILESX != null)
                            //    sql += ",TILESX=" + hoadon.TILESX;
                            //else
                            //    sql += ",TILESX=null";

                            //if (hoadon.TILEDV != null)
                            //    sql += ",TILEDV=" + hoadon.TILEDV;
                            //else
                            //    sql += ",TILEDV=null";

                            //if (hoadon.TIEUTHUSH != null)
                            //    sql += ",TIEUTHUSH=" + hoadon.TIEUTHUSH;
                            //else
                            //    sql += ",TIEUTHUSH=null";

                            //if (hoadon.TIEUTHUSX != null)
                            //    sql += ",TIEUTHUSX=" + hoadon.TIEUTHUSX;
                            //else
                            //    sql += ",TIEUTHUSX=null";

                            //if (hoadon.TIEUTHUHCSN != null)
                            //    sql += ",TIEUTHUHCSN=" + hoadon.TIEUTHUHCSN;
                            //else
                            //    sql += ",TIEUTHUHCSN=null" ;

                            //if (hoadon.TIEUTHUDV != null)
                            //    sql += ",TIEUTHUDV=" + hoadon.TIEUTHUDV;
                            //else
                            //    sql += ",TIEUTHUDV=null";
                            //_cHoaDon.LinQ_ExecuteNonQuery("update HOADON set " + sql + " where SOHOADON='" + hoadon.SOHOADON + "'");
                        }
                    }

                    try
                    {
                        string lineR_Test = lines[0].Replace("\",\"", "$").Replace("\"", "");
                        string[] contents_Test = lineR_Test.Split('$');
                        int Nam = int.Parse("20" + contents_Test[19]);
                        int Ky = int.Parse(contents_Test[18]);
                        int Dot = int.Parse(contents_Test[1]);
                        string sql = "update HOADON set Quan=DLKH.QUAN,Phuong=DLKH.PHUONG,CoDH=DLKH.CODH,MaDMA=DLKH.MADMA from DLKH where HOADON.DANHBA=DLKH.DANHBO and HOADON.NAM=" + Nam + " and HOADON.KY=" + Ky + " and HOADON.DOT=" + Dot;
                        _cHoaDon.LinQ_ExecuteNonQuery(sql);
                        string sql_Huy = "update HOADON set Quan=DLKH_HUY.QUAN,Phuong=DLKH_HUY.PHUONG,CoDH=DLKH_HUY.CODH,MaDMA=DLKH_HUY.MADMA from DLKH_HUY where HOADON.DANHBA=DLKH_HUY.DANHBO and HOADON.NAM=" + Nam + " and HOADON.KY=" + Ky + " and HOADON.DOT=" + Dot;
                        _cHoaDon.LinQ_ExecuteNonQuery(sql_Huy);
                    }
                    catch (Exception)
                    {
                    }
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (cmbKy.SelectedIndex != -1)
            {
                //var startTime = System.Diagnostics.Stopwatch.StartNew();
                dgvHoaDon.DataSource = _cHoaDon.GetTongByNamKy(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString()));
                //startTime.Stop();
                //MessageBox.Show(startTime.ElapsedMilliseconds.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                int TongHD = 0;
                int TongTieuThu = 0;
                long TongGiaBan = 0;
                long TongThueGTGT = 0;
                long TongPhiBVMT = 0;
                long TongCong = 0;
                foreach (DataGridViewRow item in dgvHoaDon.Rows)
                {
                    TongHD += int.Parse(item.Cells["TongHD"].Value.ToString());
                    TongTieuThu += int.Parse(item.Cells["TongTieuThu"].Value.ToString());
                    TongGiaBan += long.Parse(item.Cells["TongGiaBan"].Value.ToString());
                    TongThueGTGT += long.Parse(item.Cells["TongThueGTGT"].Value.ToString());
                    TongPhiBVMT += long.Parse(item.Cells["TongPhiBVMT"].Value.ToString());
                    TongCong += long.Parse(item.Cells["TongCong"].Value.ToString());
                }
                txtTongHD.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongHD);
                txtTongTieuThu.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongTieuThu);
                txtTongGiaBan.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongGiaBan);
                txtTongThueGTGT.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongThueGTGT);
                txtTongPhiBVMT.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongPhiBVMT);
                txtTongCong.Text = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", TongCong);
            }
        }

        private void dgvHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongHD" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongTieuThu" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongGiaBan" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongThueGTGT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongPhiBVMT" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvHoaDon.Columns[e.ColumnIndex].Name == "TongCong" && e.Value != null)
            {
                e.Value = String.Format(CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void txtDuongDan_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
