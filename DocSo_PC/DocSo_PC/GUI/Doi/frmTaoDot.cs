using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.QuanTri;
using DocSo_PC.LinQ;
using System.Data.SqlClient;
using DocSo_PC.DAL.Doi;
using DocSo_PC.DAL;

namespace DocSo_PC.GUI.Doi
{
    public partial class frmTaoDot : Form
    {
        string _mnu = "mnuTaoDot";
        string _fileName = "";
        CDocSo _cDocSo = new CDocSo();
        CLichDocSo _cLichDocSo = new CLichDocSo();
        CChuanBiDS _cChuanBi = new CChuanBiDS();

        public frmTaoDot()
        {
            InitializeComponent();
        }

        private void frmTaoDot_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
            cmbNam.DataSource = _cDocSo.getDS_Nam();
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
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    int i = 1;
                    string[] lines = System.IO.File.ReadAllLines(txtDuongDan.Text.Trim());
                    progressBar.Minimum = 0;
                    progressBar.Maximum = lines.Count();
                    //kiểm tra
                    string lineC = lines[0].Replace("\",\"", "$").Replace("\"", "");
                    string[] contentsC = lineC.Split('$');
                    if (_cDocSo.checkExists_BillState(contentsC[2], contentsC[3], contentsC[4]) == true)
                    {
                        MessageBox.Show("Năm " + contentsC[2] + " Kỳ " + contentsC[3] + " Đợt " + contentsC[4] + " đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        BillState enB = new BillState();
                        enB.BillID = contentsC[2] + contentsC[3] + contentsC[4];
                        enB.izCB = "1";
                        _cDocSo.them_BillState(enB);
                    }
                    foreach (string line in lines)
                    {
                        progressBar.Value = i++;
                        string lineR = line.Replace("\",\"", "$").Replace("\"", "");
                        string[] contents = lineR.Split('$');
                        BienDong en = new BienDong();

                        if (!string.IsNullOrWhiteSpace(contents[0]))
                            en.STT = int.Parse(contents[0]);
                        if (!string.IsNullOrWhiteSpace(contents[2]))
                            en.Nam = int.Parse(contents[2]);
                        if (!string.IsNullOrWhiteSpace(contents[3]))
                            en.Ky = contents[3];
                        if (!string.IsNullOrWhiteSpace(contents[4]))
                            en.Dot = contents[4];
                        if (!string.IsNullOrWhiteSpace(contents[5]))
                            en.May = contents[5];
                        if (!string.IsNullOrWhiteSpace(contents[6]))
                            en.MLT1 = en.Dot + en.May + contents[6];
                        if (!string.IsNullOrWhiteSpace(contents[8]))
                            en.DanhBa = contents[8];
                        if (!string.IsNullOrWhiteSpace(contents[9]))
                            en.TenKH = contents[9];
                        if (!string.IsNullOrWhiteSpace(contents[10]))
                            en.So = contents[10];
                        if (!string.IsNullOrWhiteSpace(contents[11]))
                            en.Duong = contents[11];
                        if (!string.IsNullOrWhiteSpace(contents[13]))
                            en.Phuong = contents[13];
                        if (!string.IsNullOrWhiteSpace(contents[12]))
                            en.Quan = contents[12];
                        if (!string.IsNullOrWhiteSpace(contents[15]))
                            en.GB = short.Parse(contents[15]);
                        if (!string.IsNullOrWhiteSpace(contents[16]))
                            en.DM = int.Parse(contents[16]);
                        if (!string.IsNullOrWhiteSpace(contents[17]))
                            en.SH = short.Parse(contents[17]);
                        if (!string.IsNullOrWhiteSpace(contents[18]))
                            en.SX = short.Parse(contents[18]);
                        if (!string.IsNullOrWhiteSpace(contents[19]))
                            en.DV = short.Parse(contents[19]);
                        if (!string.IsNullOrWhiteSpace(contents[20]))
                            en.HC = short.Parse(contents[20]);
                        if (!string.IsNullOrWhiteSpace(contents[21]))
                            en.Co = short.Parse(contents[21]);
                        if (!string.IsNullOrWhiteSpace(contents[22]))
                            en.Hieu = contents[22];
                        if (!string.IsNullOrWhiteSpace(contents[23]))
                            en.SoThan = contents[23];
                        if (!string.IsNullOrWhiteSpace(contents[24]))
                            en.NgayGan = DateTime.ParseExact(contents[24], "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        if (!string.IsNullOrWhiteSpace(contents[25]))
                            en.Code = contents[25];
                        if (!string.IsNullOrWhiteSpace(contents[26]))
                            en.ChiSo = int.Parse(contents[26]);
                        if (!string.IsNullOrWhiteSpace(contents[27]))
                            en.TieuThu = int.Parse(contents[27]);
                        en.BienDongID = en.Nam.ToString() + en.Ky + en.DanhBa;
                        en.NVCapNhat = CNguoiDung.TaiKhoan;
                        en.NgayCapNhat = DateTime.Now;

                        //string cmd = "INSERT INTO [BienDong] ([BienDongID],[Nam],[Ky],[Dot],[DanhBa],[HopDong],[May],[TenKH],[So],[Duong],[Phuong],[Quan],[GB],[DM],[SH],[SX],[DV],[HC],[Hieu],[Co],[SoThan],[Code],[ChiSo],[TieuThu],[NgayGan],[STT],[MLT1],[NVCapNhat]) ";
                        //cmd += " VALUES ('" + en.BienDongID + "'," + en.Nam + ",'" + en.Ky + "','" + en.Dot + "','" + en.DanhBa + "','" + en.HopDong + "','" + en.May + "','" + en.TenKH + "','" + en.So + "',";
                        //cmd += "'" + en.Duong + "','" + en.Phuong + "','" + en.Quan + "',0" + en.GB + ",0" + en.DM + ",0" + en.SH + ",0" + en.SX + ",0" + en.DV + ",0" + en.HC + ",'" + en.Hieu + "',";
                        //cmd += "'" + en.Co + "','" + en.SoThan + "','" + en.Code + "',0" + en.ChiSo + ",0" + en.TieuThu + ",'" + en.NgayGan + "','" + en.STT + "','" + en.MLT1 + "','" + en.NVCapNhat + "')";

                        _cDocSo.them_BienDong(en);
                    }
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = _cDocSo.getTong_TaoDot(cmbNam.SelectedValue.ToString(), cmbKy.SelectedItem.ToString());
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    if (dgvDanhSach.Columns[e.ColumnIndex].Name == "TaoDot")
                    {
                        if (MessageBox.Show("Bạn có chắc chắn Tạo Đợt " + dgvDanhSach["Dot", e.RowIndex].Value.ToString() + "?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            //if (_cDocSo.checkExists_DocSo(dgvDanhSach["Nam", e.RowIndex].Value.ToString(), dgvDanhSach["Ky", e.RowIndex].Value.ToString(), dgvDanhSach["Dot", e.RowIndex].Value.ToString()) == true)
                            //{
                            //    MessageBox.Show("Năm " + dgvDanhSach["Nam", e.RowIndex].Value.ToString() + " Kỳ " + dgvDanhSach["Ky", e.RowIndex].Value.ToString() + " Đợt " + dgvDanhSach["Dot", e.RowIndex].Value.ToString() + " đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //    return;
                            //}
                            int i = 1;
                            List<BienDong> lst = _cDocSo.getDS_BienDong(dgvDanhSach["Nam", e.RowIndex].Value.ToString(), dgvDanhSach["Ky", e.RowIndex].Value.ToString(), dgvDanhSach["Dot", e.RowIndex].Value.ToString());
                            progressBar.Minimum = 0;
                            progressBar.Maximum = lst.Count;
                            //lấy ngày đọc
                            DateTime NgayDoc = _cLichDocSo.getNgayDoc(int.Parse(dgvDanhSach["Ky", e.RowIndex].Value.ToString()), int.Parse(dgvDanhSach["Nam", e.RowIndex].Value.ToString()), int.Parse(dgvDanhSach["Dot", e.RowIndex].Value.ToString()));
                            foreach (BienDong item in lst)
                            {
                                progressBar.Value = i++;
                                if (_cDocSo.checkExists_DocSo(item.BienDongID) == false)
                                {
                                    DocSo en = new DocSo();
                                    en.DocSoID = item.BienDongID;
                                    en.DanhBa = item.DanhBa;
                                    en.MLT1 = item.MLT1;
                                    en.MLT2 = item.MLT1;
                                    en.SoNhaCu = item.So;
                                    en.Duong = item.Duong;
                                    en.GB = item.GB.Value.ToString();
                                    if (item.DM != null)
                                        en.DM = item.DM.Value.ToString();
                                    else
                                        en.DM = "0";
                                    en.Nam = item.Nam;
                                    en.Ky = item.Ky;
                                    en.Dot = item.Dot;
                                    en.May = en.PhanMay = item.May;
                                    en.TBTT = 0;
                                    en.TamTinh = 0;
                                    en.CodeCu = "";
                                    en.TTDHNCu = "";
                                    en.CSCu = item.ChiSo;
                                    en.TieuThuCu = item.TieuThu;
                                    en.TienNuoc = 0;
                                    en.BVMT = 0;
                                    en.Thue = 0;
                                    en.TongTien = 0;
                                    en.SoThanCu = item.SoThan;
                                    en.HieuCu = item.Hieu;
                                    en.CoCu = item.Co.Value.ToString();
                                    en.DenNgay = NgayDoc;
                                    en.NgayDS = DateTime.Now;
                                    //_cDocSo.updateDocSo(ref en);
                                    _cDocSo.them_DocSo(en);
                                }
                            }
                            _cDocSo.updateTBTTDocSo(dgvDanhSach["Nam", e.RowIndex].Value.ToString(), dgvDanhSach["Ky", e.RowIndex].Value.ToString(), dgvDanhSach["Dot", e.RowIndex].Value.ToString());
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
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

        private void dgvDanhSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
            //    {
            //        if (dgvDanhSach.Columns[e.ColumnIndex].Name == "Chot")
            //        {
            //            if (CNguoiDung.Doi == true)
            //            {
            //                BillState en = _cDocSo.get_BillState(dgvDanhSach["BillID", e.RowIndex].Value.ToString());
            //                if (en != null)
            //                {
            //                    if (dgvDanhSach[e.ColumnIndex, e.RowIndex].Value.ToString() != "" && bool.Parse(dgvDanhSach[e.ColumnIndex, e.RowIndex].Value.ToString()) == true)
            //                        en.izDS = "1";
            //                    else
            //                        en.izDS = null;
            //                    _cDocSo.SubmitChanges();
            //                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                }
            //            }
            //            else
            //            {
            //                if (dgvDanhSach[e.ColumnIndex, e.RowIndex].Value.ToString() != "" && bool.Parse(dgvDanhSach[e.ColumnIndex, e.RowIndex].Value.ToString()) == true)
            //                {
            //                    BillState en = _cDocSo.get_BillState(dgvDanhSach["BillID", e.RowIndex].Value.ToString());
            //                    if (en != null)
            //                    {
            //                        en.izDS = "1";
            //                        _cDocSo.SubmitChanges();
            //                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                    }
            //                }
            //                else
            //                {
            //                    MessageBox.Show("Đội mới có Quyền Bỏ Chốt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                }
            //            }
            //        }
            //    }
            //    else
            //        MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        //private void dataTaoDS_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        //{
        //    using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
        //    {
        //        e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
        //    }
        //}

        //private void frmTaoDocSo_Load(object sender, EventArgs e)
        //{
        //    cmbNam.Items.Add(DateTime.Now.Year - 2);
        //    cmbNam.Items.Add(DateTime.Now.Year - 1);
        //    cmbNam.Items.Add(DateTime.Now.Year);
        //    cmbNam.Items.Add(DateTime.Now.Year + 1);
        //    cmbNam.SelectedIndex = 2;

        //    if (DateTime.Now.Day >= 19)
        //        cmbKy.SelectedIndex = DateTime.Now.Month;
        //    else
        //        cmbKy.SelectedIndex = DateTime.Now.Month - 1;

        //    string sql = "SELECT MaTo,TenTo FROM [To] ";
        //    if (CNguoiDung.ToTruong)
        //        sql += " WHERE MaTo=" + CNguoiDung.MaTo;
        //    cmbToDS.DataSource = _cChuanBi.ExecuteQuery_DataTable(sql);
        //    cmbToDS.DisplayMember = "TenTo";
        //    cmbToDS.ValueMember = "MaTo";

        //    dsDenNgay.Value = DateTime.Now.Date.AddDays(1.0);
        //    //PageLoad();
        //}

        //private void cmbDot_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cmbDot.SelectedIndex != -1)
        //    {
        //        SoDocSo();
        //        dsTuNgay.Value = _cChuanBi.getDocTuNgay(int.Parse(cmbNam.Text),cmbKy.Text,cmbDot.Text);

        //    }
        //}
        //DataTable tb = null;
        //public void SoDocSo()
        //{

        //    try
        //    {
        //        CTo _ct = new CTo();
        //        To _t = _ct.GetByMaTo(int.Parse(cmbToDS.SelectedValue.ToString()));
        //        tumay = _t.TuMay.Value;
        //        denmay = _t.DenMay.Value;
        //        //DataTable t2 = tb.Select(" May > " + tumay + " and May <= " + denmay).CopyToDataTable();
        //        ////    tb.Select(" (May BETWEEN 0 AND 10 )");
        //        //dataTaoDS.DataSource = t2;
        //        string sql = " select May,COUNT(*) AS SOLUONG , 'True' as DaTao ,NVTaoDS,NgayTaoDS from DocSo WHERE (May BETWEEN " + tumay + " AND " + denmay + " )AND Nam=" + int.Parse(cmbNam.Text) + "AND Ky='" + cmbKy.Text + "' AND Dot='" + cmbDot.Text + "' group by May,NVTaoDS,NgayTaoDS ORDER BY May ASC ";
        //        tb = _cChuanBi.ExecuteQuery_DataTable(sql);
        //        if (tb.Rows.Count > 0)
        //            dgvDanhSach.DataSource = tb;
        //        else
        //        {
        //            sql = "select May,COUNT(*) AS SOLUONG , 'False' as DaTao ,'' AS NVTaoDS, '' AS NgayTaoDS from BienDong WHERE (May BETWEEN " + tumay + " AND " + denmay + " )AND Nam=" + int.Parse(cmbNam.Text) + "AND Ky='" + cmbKy.Text + "' AND Dot='" + cmbDot.Text + "' group by May ORDER BY May ASC ";
        //            tb = _cChuanBi.ExecuteQuery_DataTable(sql);
        //            dgvDanhSach.DataSource = tb;
        //        }
        //    }
        //    catch (Exception)
        //    {

        //    }

        //}

        //private void cmbToDS_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    if (!"".Equals(cmbDot.Text))
        //    {
        //        if (tb != null)
        //        {
        //            SoDocSo();                    
        //        }
        //    }
        //}

        //private void btnTaoDocSo_Click(object sender, EventArgs e)
        //{

        //    SqlConnection thisConnection = new SqlConnection(DocSo_PC.Properties.Settings.Default.DocSoTHTestConnectionString);
        //    SqlCommand command = null;
        //    thisConnection.Open();

        //    if (dgvDanhSach.Rows.Count <= 0)
        //    {
        //        MessageBox.Show("Chưa cập nhật biến động liệu đọc số  !! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    if (tb != null)
        //    {
        //        int nam = int.Parse(cmbNam.Text);
        //        string ky = cmbKy.Text;
        //        string dot = cmbDot.Text;
        //        BillState bilS = _cChuanBi.GetBillState(nam, ky, dot);
        //        if (bilS != null)
        //        {
        //            if (bilS.izDS == "1")
        //            {
        //                MessageBox.Show("Dữ liệu đã chuyển Billing không  thể tạo dữ liệu đọc số  !! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return;
        //            }           
        //            //if (bilS.izCB == "1")
        //        }
        //        try
        //        {
        //            if (!"".Equals(dgvDanhSach.Rows[0].Cells["NgayTao"].Value.ToString()))
        //            {
        //                MessageBox.Show("Đã tạo dữ liệu đọc số rồi không  thể tạo dữ liệu đọc số  !! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return;
        //                //if (MessageBox.Show("Đã tạo dữ liệu đọc số rồi ! Muốn tạo lại dữ liệu đọc số ? ", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
        //                //    return;
        //                ////else
        //                ////{
        //                //}
        //            }

        //        }
        //        catch (Exception)
        //        {
        //        }
        //        _cChuanBi.ExecuteNonQuery("INSERT INTO BillState VALUES (" + "" + nam + ky + dot + ",1,0,0,0,0)");

        //      //int total = Convert.ToInt32(tb.Compute("SUM(SOLUONG)", string.Empty));
        //        int total = dgvDanhSach.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToInt32(t.Cells["slDoc"].Value));
        //        progressBar.Minimum = 0;
        //        progressBar.Maximum = total;
        //        int fl = 0;
        //        string insert = "";
        //        string value = "";

        //        try
        //        {
        //            List<BienDong> list = _cChuanBi.getListBienFong(nam, ky, dot, tumay, denmay);
        //            foreach (var i in list)
        //            {
        //                progressBar.Value = fl++;
        //                DocSo d = new DocSo();

        //                d.DocSoID = i.BienDongID; d.DanhBa = i.DanhBa; d.MLT1 = i.MLT1; d.MLT2 = i.MLT1; d.SoNhaCu = i.So; d.SoNhaMoi = ""; d.Duong = i.Duong; d.SDT = i.HopDong; d.GB = i.GB.ToString(); d.DM = i.DM.ToString(); d.Nam = i.Nam; d.Ky = i.Ky; d.Dot = i.Dot; d.May = i.May;
        //                // d.TBTT = _cChuanBi.getTTTB3ky(d.DanhBa);
        //                d.TamTinh = 0;
        //                insert = " INSERT INTO  DocSo(DocSoID,DanhBa,MLT1,MLT2,SoNhaCu,SoNhaMoi,Duong,SDT,GB,DM,Nam,Ky,Dot,May,TBTT,TamTinh,";
        //                value = " VALUES('" + d.DocSoID + "','" + d.DanhBa + "','" + d.MLT1 + "','" + d.MLT2 + "','" + d.SoNhaCu + "','" + d.SoNhaMoi + "','" + d.Duong + "','" + d.SDT + "','" + d.GB + "','" + d.DM + "','" + d.Nam + "','" + d.Ky + "','" + d.Dot + "','" + d.May + "','" + d.TBTT + "','" + d.TamTinh + "',";

        //                d.CSCu = i.ChiSo; d.CSMoi = 0; d.CodeCu = i.Code; d.CodeMoi = ""; d.TTDHNCu = i.Code; d.TTDHNMoi = ""; d.TieuThuCu = i.TieuThu; d.TieuThuMoi = 0; d.TuNgay = dsTuNgay.Value; d.DenNgay = dsDenNgay.Value; d.TienNuoc = 0;
        //                insert += "CSCu,CSMoi,CodeCu,CodeMoi,TTDHNCu,TTDHNMoi,TieuThuCu,TieuThuMoi,TuNgay,DenNgay,TienNuoc";
        //                value += "'" + d.CSCu + "','" + d.CSMoi + "','" + d.CodeCu + "','" + d.CodeMoi + "','" + d.TTDHNCu + "','" + d.TTDHNMoi + "','" + d.TieuThuCu + "','" + d.TieuThuMoi + "','" + d.TuNgay + "','" + d.DenNgay + "','" + d.TienNuoc + "',";

        //                d.BVMT = 0; d.Thue = 0; d.TongTien = 0; d.SoThanCu = i.SoThan; d.SoThanMoi = ""; d.HieuCu = i.Hieu; d.HieuMoi = ""; d.CoCu = i.Co.ToString(); d.CoMoi = ""; d.GiengCu = ""; d.GiengMoi = ""; d.Van1Cu = "";
        //                insert += ",BVMT,Thue,TongTien,SoThanCu,SoThanMoi,HieuCu,HieuMoi,CoCu,CoMoi,GiengCu,GiengMoi,Van1Cu,";
        //                value += "'" + d.BVMT + "','" + d.Thue + "','" + d.TongTien + "','" + d.SoThanCu + "','" + d.SoThanMoi + "','" + d.HieuCu + "','" + d.HieuMoi + "','" + d.CoCu + "','" + d.CoMoi + "','" + d.GiengCu + "','" + d.GiengMoi + "','" + d.Van1Cu + "',";

        //                d.Van1Moi = ""; d.MVCu = ""; d.MVMoi = ""; d.ChiCoCu = ""; d.ChiCoMoi = ""; d.ChiThanCu = ""; d.ChiThanMoi = ""; d.ViTriCu = ""; d.ViTriMoi = ""; d.CapDoCu = ""; d.CapDoMoi = "";
        //                insert += "Van1Moi,MVCu,MVMoi,ChiCoCu,ChiCoMoi,ChiThanCu,ChiThanMoi,ViTriCu,ViTriMoi,CapDoCu,CapDoMoi,";
        //                value += "'" + d.Van1Moi + "','" + d.MVCu + "','" + d.MVMoi + "','" + d.ChiCoCu + "','" + d.ChiCoMoi + "','" + d.ChiThanCu + "','" + d.ChiThanMoi + "','" + d.ViTriCu + "','" + d.ViTriMoi + "','" + d.CapDoCu + "','" + d.CapDoMoi + "',";

        //                d.CongDungCu = ""; d.CongDungMoi = ""; d.DMACu = ""; d.DMAMoi = ""; d.GhiChuKH = ""; d.GhiChuDS = ""; d.GhiChuTV = "";
        //                insert += "CongDungCu,CongDungMoi,DMACu,DMAMoi,GhiChuKH,GhiChuDS,GhiChuTV,";
        //                value += "'" + d.CongDungCu + "','" + d.CongDungMoi + "','" + d.DMACu + "','" + d.DMAMoi + "','" + d.GhiChuKH + "','" + d.GhiChuDS + "','" + d.GhiChuTV + "',";

        //                d.GPSDATA = ""; d.TODS = int.Parse(cmbToDS.SelectedValue.ToString()); d.TenKH = i.TenKH; d.NVTaoDS = CNguoiDung.TaiKhoan; ;
        //                insert += "GPSDATA,TODS,TenKH,NVTaoDS,";
        //                value += "'" + d.GPSDATA + "','" + d.TODS + "','" + d.TenKH + "','" + d.NVTaoDS + "',";

        //                d.DutChiThan = "0_0"; d.DutChiGoc = "0_0"; d.DHNSaiTT = "0_0"; d.BaoKinhDoanh = "0_0";
        //                insert += "DutChiThan,DutChiGoc,DHNSaiTT,BaoKinhDoanh)";
        //                value += "'" + d.DutChiThan + "','" + d.DutChiGoc + "','" + d.DHNSaiTT + "','" + d.BaoKinhDoanh + "')";


        //                command = new SqlCommand(insert + value, thisConnection);
        //                command.ExecuteNonQuery();
        //            }
        //            thisConnection.Close();
        //            // Cập Nhật Thông Tin Biến Động
        //            _cChuanBi.UpdateStoredProcedure("UpdateDocSo", nam, ky, dot);
        //            SoDocSo();
        //        }
        //        catch (Exception)
        //        {
        //            MessageBox.Show("Lỗi tạo dữ liệu đọc số  !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }

        //       // MessageBox.Show(this, total + "==-" + fl);

        //    }
        //    else
        //    {
        //        MessageBox.Show("Chưa load biến động liệu sổ đọc số !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    }
        //}

    }
}