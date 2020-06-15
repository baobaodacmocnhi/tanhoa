using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Data.SqlClient;

namespace BauCu
{
    public partial class Form1 : Form
    {
        dbDH_CODONGDataContext db = new dbDH_CODONGDataContext();
        DataTable dtQuanTri = null;
        DataTable dtKiemSoat = null;
        DSCODONG_THAMDU codong = null;
        int TongUV = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvUngVien.AutoGenerateColumns = false;
            dgvUngVien_KQ.AutoGenerateColumns = false;
            dgvBauCu.AutoGenerateColumns = false;
            dgvKhongHopLe.AutoGenerateColumns = false;
            dgvChuaBoPhieu.AutoGenerateColumns = false;
            cmbLan.SelectedIndex = 0;
            dtQuanTri = LINQToDataTable(db.UNGVIENs.Where(item => item.LoaiBC == 1).ToList());
            dtKiemSoat = LINQToDataTable(db.UNGVIENs.Where(item => item.LoaiBC == 2).ToList());
            radQuanTri.Checked = true;
        }

        public DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();

            // column names 
            PropertyInfo[] oProps = null;

            if (varlist == null) return dtReturn;

            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow 
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }

                DataRow dr = dtReturn.NewRow();

                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);
                }

                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }

        public void Clear()
        {
            codong = null;
            txtSTTCD.Text = "";
            txtHoTenCD.Text = "";
            txtTongSoCoPhan.Text = "";
            txtTongSoPhieuBau.Text = "";
            chkKhongHopLe.Checked = false;
            checkAll.Checked = false;
            foreach (DataGridViewRow item in dgvUngVien.Rows)
            {
                item.Cells["Chon"].Value = false;
            }
        }

        public void LoadDSBauCu()
        {
            try
            {
                Clear();
                int LoaiBC = 0;
                if (radQuanTri.Checked)
                    LoaiBC = 1;
                else
                    if (radKiemSoat.Checked)
                        LoaiBC = 2;

                //cổ đông tham dự
                if (db.DSCODONG_THAMDUs.Count() > 0)
                    txtCDThamDu.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", db.DSCODONG_THAMDUs.Count());
                else
                    txtCDThamDu.Text = "0";

                if (db.DSCODONG_THAMDUs.Count() > 0)
                    txtCDThamDu_CP.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", db.DSCODONG_THAMDUs.Sum(item => item.TONGCD.Value) * TongUV);
                else
                    txtCDThamDu_CP.Text = "0";

                //cổ đông bỏ phiếu
                if (db.KIEMPHIEU_BAUCUs.Where(item => item.UNGVIEN.LoaiBC == LoaiBC).Select(item => item.STTCD).Distinct().Count() + db.KHONGHOPLEs.Where(item => item.LoaiBC == LoaiBC).Count() > 0)
                    txtCDBoPhieu.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", db.KIEMPHIEU_BAUCUs.Where(item => item.UNGVIEN.LoaiBC == LoaiBC).Select(item => item.STTCD).Distinct().Count() + db.KHONGHOPLEs.Where(item => item.LoaiBC == LoaiBC).Count());
                else
                    txtCDBoPhieu.Text = "0";

                if (db.KIEMPHIEU_BAUCUs.Where(item => item.UNGVIEN.LoaiBC == LoaiBC).Select(item => item.STTCD).Distinct().Count() > 0 && (db.KIEMPHIEU_BAUCUs.Where(item => item.UNGVIEN.LoaiBC == LoaiBC).Select(item => item.STTCD).Distinct().Count() + db.KHONGHOPLEs.Where(item => item.LoaiBC == LoaiBC).Count() + db.BAUSOPHIEUDUs.Where(item => item.LoaiBC == LoaiBC).Count()) > 0)
                {
                    long Tong = db.KIEMPHIEU_BAUCUs.Where(item => item.UNGVIEN.LoaiBC == LoaiBC).Count() > 0 ? db.KIEMPHIEU_BAUCUs.Where(item => item.UNGVIEN.LoaiBC == LoaiBC).Sum(item => item.TONGCD.Value) : 0;
                    Tong += db.KHONGHOPLEs.Where(item => item.LoaiBC == LoaiBC).Count() > 0 ? (db.KHONGHOPLEs.Where(item => item.LoaiBC == LoaiBC).Sum(item => item.TONGCD.Value) * TongUV) : 0;
                    Tong += db.BAUSOPHIEUDUs.Where(item => item.LoaiBC == LoaiBC).Count() > 0 ? (db.BAUSOPHIEUDUs.Where(item => item.LoaiBC == LoaiBC).Sum(item => item.TONGCD.Value)) : 0;
                    txtCDBoPhieu_CP.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", Tong);
                }
                else
                    txtCDBoPhieu_CP.Text = "0";

                txtTyLeBoPhieu.Text = Math.Round((double.Parse(txtCDBoPhieu_CP.Text.Trim().Replace(".", "")) / double.Parse(txtCDThamDu_CP.Text.Trim().Replace(".", "")) * 100), 2).ToString();

                //cổ đông hợp lệ
                if (db.KIEMPHIEU_BAUCUs.Where(item => item.UNGVIEN.LoaiBC == LoaiBC).Select(item => item.STTCD).Distinct().Count() > 0)
                    txtPhieuHopLe.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", db.KIEMPHIEU_BAUCUs.Where(item => item.UNGVIEN.LoaiBC == LoaiBC).Select(item => item.STTCD).Distinct().Count());
                else
                    txtPhieuHopLe.Text = "0";

                int phieuhople = 0;
                if (db.KIEMPHIEU_BAUCUs.Where(item => item.UNGVIEN.LoaiBC == LoaiBC).Select(item => item.STTCD).Distinct().Count() > 0)
                    phieuhople = db.KIEMPHIEU_BAUCUs.Where(item => item.UNGVIEN.LoaiBC == LoaiBC).Sum(item => item.TONGCD.Value);
                else
                    phieuhople = 0;
                if (phieuhople > 0)
                    txtPhieuHopLe_CP.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", phieuhople);
                else
                    txtPhieuHopLe_CP.Text = "0";

                txtTyLeHopLe.Text = Math.Round((double.Parse(txtPhieuHopLe_CP.Text.Trim().Replace(".", "")) / double.Parse(txtCDThamDu_CP.Text.Trim().Replace(".", "")) * 100), 2).ToString();

                //cổ đông không tín nhiệm
                if (db.BAUSOPHIEUDUs.Where(item => item.LoaiBC == LoaiBC).Count() > 0)
                    txtPhieuKhongTinNhiem_CP.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", db.BAUSOPHIEUDUs.Where(item => item.LoaiBC == LoaiBC).Sum(item => item.TONGCD.Value));
                else
                    txtPhieuKhongTinNhiem_CP.Text = "0";

                txtTyLePhieuKhongTinNhiem.Text = Math.Round((double.Parse(txtPhieuKhongTinNhiem_CP.Text.Trim().Replace(".", "")) / (double.Parse(txtCDThamDu_CP.Text.Trim().Replace(".", "")) / 1) * 100), 2).ToString();

                //cổ đông không hợp lệ
                if (db.KHONGHOPLEs.Where(item => item.LoaiBC == LoaiBC).Count() > 0)
                    txtPhieuKhongHopLe.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", db.KHONGHOPLEs.Where(item => item.LoaiBC == LoaiBC).Count());
                else
                    txtPhieuKhongHopLe.Text = "0";

                if (db.KHONGHOPLEs.Where(item => item.LoaiBC == LoaiBC).Count() > 0)
                    txtPhieuKhongHopLe_CP.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", db.KHONGHOPLEs.Where(item => item.LoaiBC == LoaiBC).Sum(item => item.TONGCD.Value) * TongUV);
                else
                    txtPhieuKhongHopLe_CP.Text = "0";

                txtTyLeKhongHopLe.Text = Math.Round((double.Parse(txtPhieuKhongHopLe_CP.Text.Trim().Replace(".", "")) / (double.Parse(txtCDThamDu_CP.Text.Trim().Replace(".", "")) / 1) * 100), 2).ToString();

                //cổ đông không bỏ phiếu
                if (db.DSCODONG_THAMDUs.Count() - (db.KIEMPHIEU_BAUCUs.Where(item => item.UNGVIEN.LoaiBC == LoaiBC).Select(item => item.STTCD).Distinct().Count() + db.KHONGHOPLEs.Where(item => item.LoaiBC == LoaiBC).Count()) > 0)
                    txtCDKhongBoPhieu.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", db.DSCODONG_THAMDUs.Count() - (db.KIEMPHIEU_BAUCUs.Where(item => item.UNGVIEN.LoaiBC == LoaiBC).Select(item => item.STTCD).Distinct().Count() + db.KHONGHOPLEs.Where(item => item.LoaiBC == LoaiBC).Count()));
                else
                    txtCDKhongBoPhieu.Text = "0";

                string sql = "select SUM(TONGCD) from DSCODONG_THAMDU where MACD in (select distinct MACD from KIEMPHIEU_BAUCU a,UNGVIEN b where a.ID_UngCu=b.ID and b.LoaiBC=" + LoaiBC + ")";
                int cdchuabophieu = 0;
                if (ExecuteQuery_SqlDataAdapter_DataTable(sql).Rows[0][0].ToString() != "")
                    cdchuabophieu = int.Parse(ExecuteQuery_SqlDataAdapter_DataTable(sql).Rows[0][0].ToString());

                int cdthamdu = 0;
                if (db.DSCODONG_THAMDUs.Count() > 0)
                    cdthamdu = db.DSCODONG_THAMDUs.Sum(item => item.TONGCD.Value);
                else
                    cdthamdu = 0;

                if ((cdthamdu - ((db.KIEMPHIEU_BAUCUs.Where(item => item.UNGVIEN.LoaiBC == LoaiBC).Count() > 0 ? cdchuabophieu : 0) + (db.KHONGHOPLEs.Where(item => item.LoaiBC == LoaiBC).Count() > 0 ? db.KHONGHOPLEs.Where(item => item.LoaiBC == LoaiBC).Sum(item => item.TONGCD.Value) : 0))) > 0)
                {
                    long Tong = (db.DSCODONG_THAMDUs.Sum(item => item.TONGCD.Value) - ((db.KIEMPHIEU_BAUCUs.Where(item => item.UNGVIEN.LoaiBC == LoaiBC).Count() > 0 ? cdchuabophieu : 0) + (db.KHONGHOPLEs.Where(item => item.LoaiBC == LoaiBC).Count() > 0 ? db.KHONGHOPLEs.Where(item => item.LoaiBC == LoaiBC).Sum(item => item.TONGCD.Value) : 0))) * TongUV;
                    txtCDKhongBoPhieu_CP.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", Tong);
                }
                else
                    txtCDKhongBoPhieu_CP.Text = "0";

                txtTyLeKhongBoPhieu.Text = Math.Round((double.Parse(txtCDKhongBoPhieu_CP.Text.Trim().Replace(".", "")) / (double.Parse(txtCDThamDu_CP.Text.Trim().Replace(".", "")) / TongUV) * 100), 2).ToString();
                //txtTyLeKhongBoPhieu.Text = (100- double.Parse(txtCDThamDu_CP.Text.Trim())).ToString();

                if (txtTyLeKhongBoPhieu.Text.Trim() != "0")
                    txtTyLeKhongBoPhieu.Text = Math.Round((100 - double.Parse(txtTyLeBoPhieu.Text.Trim())), 2).ToString();

                if (txtTyLeKhongHopLe.Text.Trim() != "0")
                    txtTyLeKhongHopLe.Text = Math.Round((double.Parse(txtTyLeBoPhieu.Text.Trim()) - double.Parse(txtTyLeHopLe.Text.Trim()) - double.Parse(txtTyLePhieuKhongTinNhiem.Text.Trim())), 2).ToString();
                else
                    if (txtTyLePhieuKhongTinNhiem.Text.Trim() != "0")
                        txtTyLePhieuKhongTinNhiem.Text = Math.Round((double.Parse(txtTyLeBoPhieu.Text.Trim()) - double.Parse(txtTyLeHopLe.Text.Trim())), 2).ToString();
                ///

                var query = from itemBC in db.KIEMPHIEU_BAUCUs
                            join itemUV in db.UNGVIENs on itemBC.ID_UngCu equals itemUV.ID
                            join itemCD in db.DSCODONG_THAMDUs on itemBC.STTCD equals itemCD.STTCD
                            where itemUV.LoaiBC.Value == LoaiBC
                            orderby itemBC.CREATEDATE descending
                            select new
                            {
                                itemBC.ID,
                                itemCD.STTCD,
                                itemCD.TENCD,
                                TenUV = itemUV.Name,
                                SoPhieu = itemBC.TONGCD,
                            };
                dgvBauCu.DataSource = LINQToDataTable(query);

                ///

                var query2 = from itemBC in db.KIEMPHIEU_BAUCUs
                             where itemBC.UNGVIEN.LoaiBC == LoaiBC
                             group itemBC by itemBC.ID_UngCu into itemGroup
                             select new
                             {
                                 ID = itemGroup.Key,
                                 Name = db.UNGVIENs.SingleOrDefault(item => item.ID == itemGroup.Key).Name,
                                 SoPhieu = itemGroup.Count(item => item.TONGCD > 0),
                                 CoPhan = itemGroup.Sum(item => item.TONGCD.Value),
                                 Dat = Math.Round(((double)(itemGroup.Sum(item => item.TONGCD.Value)) / (double)(db.DSCODONG_THAMDUs.Sum(item => item.TONGCD.Value)) * 100), 2, MidpointRounding.AwayFromZero),
                             };
                dgvUngVien_KQ.DataSource = LINQToDataTable(query2);

                //tính tròn 100%
                //double Sum = 0;
                //foreach (DataGridViewRow item in dgvUngVien_KQ.Rows)
                //    if (item.Cells["Name_KQ"].Value.ToString().ToUpper() != "Trần Hữu Năm".ToUpper())
                //    {
                //        item.Cells["Dat_KQ"].Value = Math.Round(double.Parse(item.Cells["Dat2"].Value.ToString()), 2);
                //        Sum += double.Parse(item.Cells["Dat_KQ"].Value.ToString());
                //    }

                //foreach (DataGridViewRow item in dgvUngVien_KQ.Rows)
                //    if (item.Cells["Name_KQ"].Value.ToString().ToUpper() == "Trần Hữu Năm".ToUpper())
                //    {
                //        item.Cells["Dat_KQ"].Value = Math.Round(200 - Sum - double.Parse(txtTyLeKhongBoPhieu.Text.Trim()) - double.Parse(txtTyLeKhongHopLe.Text.Trim()) - double.Parse(txtTyLePhieuKhongTinNhiem.Text.Trim()), 2);
                //    }

                ///

                var query3 = from item in db.KHONGHOPLEs
                             where item.LoaiBC == LoaiBC
                             select new
                             {
                                 item.STTCD,
                                 item.LoaiBC,
                                 item.TenCD,
                                 SoPhieu = item.TONGCD.Value * TongUV,
                             };
                dgvKhongHopLe.DataSource = LINQToDataTable(query3);

                ///

                string sql2 = "select sttcd,tencd,sophieu=tongcd*(" + TongUV + ") from DSCODONG_THAMDU where MACD not in (select distinct MACD from KHONGHOPLE WHERE LoaiBC=" + LoaiBC + " ) AND  MACD not in (select distinct MACD from KIEMPHIEU_BAUCU a,UNGVIEN b where a.ID_UngCu=b.ID and b.LoaiBC=" + LoaiBC + ")";
                dgvChuaBoPhieu.DataSource = ExecuteQuery_SqlDataAdapter_DataTable(sql2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radQuanTri_CheckedChanged(object sender, EventArgs e)
        {
            if (radQuanTri.Checked)
            {
                try
                {
                    dgvUngVien.DataSource = dtQuanTri;
                    TongUV = dtQuanTri.Rows.Count;
                    foreach (DataGridViewRow item in dgvUngVien.Rows)
                        item.Cells["SoPhieu"].Value = 0;
                    LoadDSBauCu();
                }
                catch (Exception)
                {
                }
            }
        }

        private void radKiemSoat_CheckedChanged(object sender, EventArgs e)
        {
            if (radKiemSoat.Checked)
            {
                try
                {
                    dgvUngVien.DataSource = dtKiemSoat;
                    TongUV = dtKiemSoat.Rows.Count;
                    foreach (DataGridViewRow item in dgvUngVien.Rows)
                        item.Cells["SoPhieu"].Value = 0;
                    LoadDSBauCu();
                }
                catch (Exception)
                {
                }
            }
        }

        private void txtSTTCD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtSTTCD.Text.Trim() != "" && e.KeyChar == 13)
            {
                codong = db.DSCODONG_THAMDUs.SingleOrDefault(item => item.STTCD == int.Parse(txtSTTCD.Text.Trim()));
                if (codong != null)
                {
                    txtHoTenCD.Text = codong.TENCD;
                    txtTongSoCoPhan.Text = codong.TONGCD.Value.ToString();
                    txtTongSoPhieuBau.Text = (codong.TONGCD.Value * TongUV).ToString();
                    foreach (DataGridViewRow item in dgvUngVien.Rows)
                    {
                        item.Cells["Chon"].Value = true;
                    }
                }
            }
            else
                codong = null;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (codong != null)
            {
                int LoaiBC = 0;
                if (radQuanTri.Checked)
                    LoaiBC = 1;
                else
                    if (radKiemSoat.Checked)
                        LoaiBC = 2;
                if (db.KHONGHOPLEs.Any(item => item.STTCD == codong.STTCD && item.LoaiBC == LoaiBC))
                {
                    MessageBox.Show("Cổ đông này đã có trong không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int sophieu = 0;
                foreach (DataGridViewRow item in dgvUngVien.Rows)
                    if (item.Cells["SoPhieu"].Value != null && item.Cells["SoPhieu"].Value.ToString().Trim() != "")
                    {
                        sophieu += int.Parse(item.Cells["SoPhieu"].Value.ToString().Trim());
                    }
                if (sophieu > int.Parse(txtTongSoPhieuBau.Text.Trim()))
                {
                    MessageBox.Show("Phiếu không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                foreach (DataGridViewRow item in dgvUngVien.Rows)
                    if (item.Cells["SoPhieu"].Value != null && item.Cells["SoPhieu"].Value.ToString().Trim() != "")
                        if (db.KIEMPHIEU_BAUCUs.Any(itemA => itemA.ID_UngCu == int.Parse(item.Cells["ID"].Value.ToString().Trim()) && itemA.STTCD == codong.STTCD) == false)
                        {
                            KIEMPHIEU_BAUCU entity = new KIEMPHIEU_BAUCU();
                            entity.LANBQ = int.Parse(cmbLan.SelectedItem.ToString());
                            entity.NGAYBQ = DateTime.Now;
                            entity.STTCD = codong.STTCD;
                            entity.MACD = codong.MACD;
                            entity.TONGCD = int.Parse(item.Cells["SoPhieu"].Value.ToString().Trim());
                            entity.ID_UngCu = int.Parse(item.Cells["ID"].Value.ToString().Trim());
                            entity.CREATEDATE = DateTime.Now;
                            db.KIEMPHIEU_BAUCUs.InsertOnSubmit(entity);
                            db.SubmitChanges();
                        }
                if (int.Parse(txtTongSoPhieuBau.Text.Trim()) > sophieu)
                {
                    int flagLoaiBC = 0;
                    if (radQuanTri.Checked)
                        flagLoaiBC = 1;
                    else
                        if (radKiemSoat.Checked)
                            flagLoaiBC = 2;
                    if (db.BAUSOPHIEUDUs.Any(item => item.STTCD == codong.STTCD && item.LoaiBC == flagLoaiBC) == false)
                    {
                        BAUSOPHIEUDU entity = new BAUSOPHIEUDU();
                        entity.MACD = codong.MACD;
                        entity.STTCD = codong.STTCD;
                        entity.TenCD = codong.TENCD;
                        entity.TONGCD = int.Parse(txtTongSoPhieuBau.Text.Trim()) - sophieu;
                        entity.LoaiBC = flagLoaiBC;
                        db.BAUSOPHIEUDUs.InsertOnSubmit(entity);
                        db.SubmitChanges();
                    }
                }
                foreach (DataGridViewRow item in dgvUngVien.Rows)
                {
                    item.Cells["Chon"].Value = false;
                    item.Cells["SoPhieu"].Value = 0;
                }
                LoadDSBauCu();
                txtSTTCD.Focus();
            }
        }

        private void btnThemChiaDoi_Click(object sender, EventArgs e)
        {
            if (codong != null)
            {
                int LoaiBC = 0;
                if (radQuanTri.Checked)
                    LoaiBC = 1;
                else
                    if (radKiemSoat.Checked)
                        LoaiBC = 2;
                if (db.KHONGHOPLEs.Any(item => item.STTCD == codong.STTCD && item.LoaiBC == LoaiBC))
                {
                    MessageBox.Show("Cổ đông này đã có trong không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int sophieu = 0;
                foreach (DataGridViewRow item in dgvUngVien.Rows)
                    if (item.Cells["SoPhieu"].Value != null && item.Cells["SoPhieu"].Value.ToString().Trim() != "")
                    {
                        sophieu += int.Parse(item.Cells["SoPhieu"].Value.ToString().Trim());
                    }
                if (sophieu > int.Parse(txtTongSoPhieuBau.Text.Trim()))
                {
                    MessageBox.Show("Phiếu không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                foreach (DataGridViewRow item in dgvUngVien.Rows)
                    if (db.KIEMPHIEU_BAUCUs.Any(itemA => itemA.ID_UngCu == int.Parse(item.Cells["ID"].Value.ToString().Trim()) && itemA.STTCD == codong.STTCD) == false)
                    {
                        KIEMPHIEU_BAUCU entity = new KIEMPHIEU_BAUCU();
                        entity.LANBQ = int.Parse(cmbLan.SelectedItem.ToString());
                        entity.NGAYBQ = DateTime.Now;
                        entity.STTCD = codong.STTCD;
                        entity.MACD = codong.MACD;
                        entity.TONGCD = int.Parse(txtTongSoCoPhan.Text.Trim().Replace(".", ""));
                        entity.ID_UngCu = int.Parse(item.Cells["ID"].Value.ToString().Trim());
                        entity.CREATEDATE = DateTime.Now;
                        db.KIEMPHIEU_BAUCUs.InsertOnSubmit(entity);
                        db.SubmitChanges();
                    }

                LoadDSBauCu();
                txtSTTCD.Focus();
            }
        }

        private void dgvUngVien_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (codong != null)
            {
                if (dgvUngVien.Columns[e.ColumnIndex].Name == "Chon")
                {
                    int number = 0;
                    foreach (DataGridViewRow item in dgvUngVien.Rows)
                        if (item.Cells["Chon"].Value != null && bool.Parse(item.Cells["Chon"].Value.ToString()) == true)
                        {
                            number++;
                        }
                    int sophieu = codong.TONGCD.Value * TongUV;
                    if (number == 0)
                        sophieu = 0;
                    else
                        sophieu = sophieu / number;
                    foreach (DataGridViewRow item in dgvUngVien.Rows)
                        if (item.Cells["Chon"].Value != null && bool.Parse(item.Cells["Chon"].Value.ToString()) == true)
                        {
                            item.Cells["SoPhieu"].Value = sophieu;
                        }
                        else
                        {
                            item.Cells["SoPhieu"].Value = "0";
                        }
                }

                //if (dgvUngVien.Columns[e.ColumnIndex].Name == "SoPhieu")
                //{
                //    foreach (DataGridViewRow item in dgvUngVien.Rows)
                //    {

                //    }
                //}
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn xóa?", "Xác nhận khóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (DataGridViewRow item in dgvBauCu.SelectedRows)
                {
                    KIEMPHIEU_BAUCU entity = db.KIEMPHIEU_BAUCUs.SingleOrDefault(itemA => itemA.ID == int.Parse(item.Cells["ID_BC"].Value.ToString()));
                    db.KIEMPHIEU_BAUCUs.DeleteOnSubmit(entity);

                    if (db.BAUSOPHIEUDUs.Any(itemB => itemB.STTCD == int.Parse(item.Cells["STTCD"].Value.ToString())))
                    {
                        BAUSOPHIEUDU entity2 = db.BAUSOPHIEUDUs.SingleOrDefault(itemB => itemB.STTCD == int.Parse(item.Cells["STTCD"].Value.ToString()));
                        db.BAUSOPHIEUDUs.DeleteOnSubmit(entity2);
                    }

                    db.SubmitChanges();
                }
                LoadDSBauCu();
            }
        }

        private void chkKhongHopLe_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKhongHopLe.Checked)
            {
                KHONGHOPLE entity = new KHONGHOPLE();
                entity.MACD = codong.MACD;
                entity.STTCD = codong.STTCD;
                entity.TenCD = codong.TENCD;
                entity.TONGCD = codong.TONGCD;
                if (radQuanTri.Checked)
                    entity.LoaiBC = 1;
                else
                    if (radKiemSoat.Checked)
                        entity.LoaiBC = 2;

                if (db.KIEMPHIEU_BAUCUs.Any(item => item.STTCD == codong.STTCD && item.UNGVIEN.LoaiBC == entity.LoaiBC))
                {
                    MessageBox.Show("Đã bỏ phiếu rồi, Không làm được nữa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                db.KHONGHOPLEs.InsertOnSubmit(entity);
                db.SubmitChanges();
                LoadDSBauCu();
            }
        }

        private void dgvUngVien_KQ_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvUngVien_KQ.Columns[e.ColumnIndex].Name == "SoPhieu_KQ" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
            if (dgvUngVien_KQ.Columns[e.ColumnIndex].Name == "CoPhan_KQ" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void btnXoaKhongHopLe_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn xóa?", "Xác nhận khóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (DataGridViewRow item in dgvKhongHopLe.SelectedRows)
                {
                    KHONGHOPLE entity = db.KHONGHOPLEs.SingleOrDefault(itemA => itemA.STTCD == int.Parse(item.Cells["STTCD_KHL"].Value.ToString()) && itemA.LoaiBC == int.Parse(item.Cells["LoaiBC"].Value.ToString()));
                    db.KHONGHOPLEs.DeleteOnSubmit(entity);
                    db.SubmitChanges();
                }
                LoadDSBauCu();
            }
        }

        protected static string _connectionString;  // Chuỗi kết nối
        protected SqlConnection connection;         // Đối tượng kết nối
        protected SqlDataAdapter adapter;           // Đối tượng adapter chứa dữ liệu
        protected SqlCommand command;               // Đối tượng command thực thi truy vấn

        public void Connect()
        {
            _connectionString = BauCu.Properties.Settings.Default.DH_CODONGConnectionString;
            connection = new SqlConnection(_connectionString);
            if (connection.State == ConnectionState.Closed)
                connection.Open();
        }

        public void Disconnect()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }

        /// <summary>
        /// Thực thi câu truy vấn SQL trả về một đối tượng DataSet chứa kết quả trả về
        /// </summary>
        /// <param name="strSelect">Câu truy vấn cần thực thi lấy dữ liệu</param>
        /// <returns>Đối tượng dataset chứa dữ liệu kết quả câu truy vấn</returns>
        public DataSet ExecuteQuery_SqlDataAdapter_DataSet(string sql)
        {
            try
            {
                Connect();
                DataSet dataset = new DataSet();
                command = new SqlCommand();
                command.Connection = this.connection;
                adapter = new SqlDataAdapter(sql, connection);
                try
                {
                    adapter.Fill(dataset);
                }
                catch (SqlException e)
                {
                    throw e;
                }
                Disconnect();
                return dataset;
            }
            catch (Exception ex)
            {
                Disconnect();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Thực thi câu truy vấn SQL trả về một đối tượng DataTable chứa kết quả trả về
        /// </summary>
        /// <param name="strSelect">Câu truy vấn cần thực thi lấy dữ liệu</param>
        /// <returns>Đối tượng datatable chứa dữ liệu kết quả câu truy vấn</returns>
        public DataTable ExecuteQuery_SqlDataAdapter_DataTable(string sql)
        {
            try
            {
                return ExecuteQuery_SqlDataAdapter_DataSet(sql).Tables[0];
            }
            catch (Exception ex)
            {
                Disconnect();
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void checkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAll.Checked)
            {
                foreach (DataGridViewRow item in dgvUngVien.Rows)
                {
                    item.Cells["Chon"].Value = true;
                }
                btnThem.PerformClick();
            }
        }

        private void btnInsertCD_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Files (.Excel)|*.xlsx;*.xlt;*.xls";
                dialog.Multiselect = false;

                if (dialog.ShowDialog() == DialogResult.OK)
                    if (MessageBox.Show("Bạn có chắc chắn Thêm?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        CExcel fileExcel = new CExcel(dialog.FileName);
                        DataTable dtExcel = fileExcel.GetDataTable("select * from [Sheet1$]");

                        foreach (DataRow item in dtExcel.Rows)
                        {
                            DSCODONG en = new DSCODONG();
                            if (db.DSCODONGs.Count() == 0)
                            {
                                en.STT = 1;
                                en.STTCD = 1;
                                en.MACD = "THW " + 1.ToString("000");
                            }
                            else
                            {
                                en.STT = db.DSCODONGs.Max(itemA => itemA.STT) + 1;
                                en.STTCD = en.STT;
                                en.MACD = "THW " + en.STT.ToString("000");
                            }
                            en.TENCD = ToFirstUpper(item[4].ToString());
                            en.CMND = item[1].ToString();
                            if (item[2].ToString() != "")
                            {
                                string[] date = item[2].ToString().Trim().Split('/');
                                string[] year = date[2].Split(' ');
                                en.NGAYCAP = new DateTime(int.Parse(year[0]), int.Parse(date[1]), int.Parse(date[0]));
                            }
                            en.CDGD = 0;
                            en.PHONGTOA = 0;
                            en.TONGCD = int.Parse(item[3].ToString());
                            db.DSCODONGs.InsertOnSubmit(en);
                            db.SubmitChanges();
                        }
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi, Vui lòng thử lại\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string ToFirstUpper(string s)
        {
            if (String.IsNullOrEmpty(s))
                return s;

            string result = "";

            //lấy danh sách các từ  

            string[] words = s.Split(' ');

            foreach (string word in words)
            {
                // từ nào là các khoảng trắng thừa thì bỏ  
                if (word.Trim() != "")
                {
                    if (word.Length > 1)
                        result += word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower() + " ";
                    else
                        result += word.ToUpper() + " ";
                }

            }
            return result.Trim();
        }

        private void btnInDSCD_Click(object sender, EventArgs e)
        {
            DataTable dt = ExecuteQuery_SqlDataAdapter_DataTable("select * from DSCODONG");
            dsReport dsReport = new dsReport();

            foreach (DataRow item in dt.Rows)
            {
                DataRow dr = dsReport.Tables["CoDong"].NewRow();

                dr["HoTen"] = item["TENCD"];
                dr["CMND"] = item["CMND"];
                dr["NgayCap"] = item["NgayCap"];

                dsReport.Tables["CoDong"].Rows.Add(dr);
            }

            rptDSCoDong rpt = new rptDSCoDong();
            rpt.SetDataSource(dsReport);
            frmShowReport frm = new frmShowReport(rpt);
            frm.ShowDialog();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                switch (e.KeyCode)
                {
                    case Keys.Space:
                        btnThemChiaDoi.PerformClick();
                        break;
                }
        }


    }
}
