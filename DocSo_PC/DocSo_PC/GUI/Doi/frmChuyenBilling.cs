﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.Doi;
using DocSo_PC.DAL.QuanTri;
using DocSo_PC.LinQ;
using DocSo_PC.wrDHN;
using System.IO;
using DocSo_PC.DAL;


namespace DocSo_PC.GUI.Doi
{
    public partial class frmChuyenBilling : Form
    {
        string _mnu = "mnuChuyenBilling";
        CDocSo _cDocSo = new CDocSo();
        CChuyenBilling _cChuyenBilling = new CChuyenBilling();
        wsDHN _wsDHN = new wsDHN();

        public frmChuyenBilling()
        {
            InitializeComponent();
        }

        private void frmChuyenBilling_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
            cmbNam.DataSource = _cDocSo.getDS_Nam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";
            cmbKy.SelectedItem = CNguoiDung.Ky;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                dgvDanhSach.DataSource = _cDocSo.getTong_ChuyenBilling(cmbNam.SelectedValue.ToString(), cmbKy.SelectedItem.ToString(), CNguoiDung.FromDot.ToString("00"), CNguoiDung.ToDot.ToString("00"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvDanhSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (dgvDanhSach.Columns[e.ColumnIndex].Name == "Chot")
                    {
                        if (CNguoiDung.Doi == true)
                        {
                            BillState en = _cDocSo.get_BillState(dgvDanhSach["BillID", e.RowIndex].Value.ToString());
                            if (en != null)
                            {
                                if (dgvDanhSach[e.ColumnIndex, e.RowIndex].Value.ToString() != "" && bool.Parse(dgvDanhSach[e.ColumnIndex, e.RowIndex].Value.ToString()) == true)
                                {
                                    en.izDS = "1";
                                    en.NgayChot = DateTime.Now;
                                }
                                else
                                {
                                    en.izDS = null;
                                }
                                _cDocSo.SubmitChanges();
                                MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            if (dgvDanhSach[e.ColumnIndex, e.RowIndex].Value.ToString() != "" && bool.Parse(dgvDanhSach[e.ColumnIndex, e.RowIndex].Value.ToString()) == true)
                            {
                                BillState en = _cDocSo.get_BillState(dgvDanhSach["BillID", e.RowIndex].Value.ToString());
                                if (en != null)
                                {
                                    en.izDS = "1";
                                    en.NgayChot = DateTime.Now;
                                    _cDocSo.SubmitChanges();
                                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Đội mới có Quyền Bỏ Chốt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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

        private void dgvDanhSach_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDanhSach.Columns[e.ColumnIndex].Name == "TongTieuThu" && e.Value != null)
            {
                e.Value = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", e.Value);
            }
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string index = "";
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    if (dgvDanhSach.Columns[e.ColumnIndex].Name == "ChuyenBilling")
                    {
                        if (MessageBox.Show("Bạn có chắc chắn Chuyển Billing Năm " + dgvDanhSach["Nam", e.RowIndex].Value.ToString() + " Kỳ " + dgvDanhSach["Ky", e.RowIndex].Value.ToString() + " Đợt " + dgvDanhSach["Dot", e.RowIndex].Value.ToString() + "?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            if (_cDocSo.checkChot_BillState(dgvDanhSach["BillID", e.RowIndex].Value.ToString()) == false)
                            {
                                MessageBox.Show("Năm " + dgvDanhSach["Nam", e.RowIndex].Value.ToString() + " Kỳ " + dgvDanhSach["Ky", e.RowIndex].Value.ToString() + " Đợt " + dgvDanhSach["Đợt", e.RowIndex].Value.ToString() + " chưa Chốt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            int i = 1;
                            DataTable dt = _cDocSo.getDS_ChuyenBilling(dgvDanhSach["Nam", e.RowIndex].Value.ToString(), dgvDanhSach["Ky", e.RowIndex].Value.ToString(), dgvDanhSach["Dot", e.RowIndex].Value.ToString());
                            progressBar.Minimum = 0;
                            progressBar.Maximum = dt.Rows.Count;
                            int count = 0;
                            //System.IO.StreamWriter writer = new System.IO.StreamWriter(@"C:\\DocSoBilling.txt");
                            foreach (DataRow item in dt.Rows)
                            {
                                index = item["DanhBa"].ToString();
                                progressBar.Value = i++;
                                //writer.WriteLine(i.ToString() + "," + item["DanhBa"].ToString());
                                string message;
                                if (_wsDHN.insertBilling(item["DocSoID"].ToString(), "tanho@2022", out message) == true)
                                    //if (_cChuyenBilling.insertBilling(item) == true)
                                    count++;
                                else
                                    index += " : " + message;
                            }
                            MessageBox.Show("Đã chuyển xong " + count, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + index, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = true;
            dgvDanhSach.DataSource = _cChuyenBilling.getDS_Code();
        }

        private void btnFileThayDHN_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "dat";
            saveFileDialog.Filter = "Text files (*.dat)|*.dat";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = CDHN._cDAL.ExecuteQuery_DataTable("select DanhBo,NgayThay=CONVERT(varchar(10),NgayThay,103) from TB_DULIEUKHACHHANG a,DocSoTH.dbo.DocSo b where a.DanhBo=b.DanhBa and b.Nam=" + cmbNam.SelectedValue.ToString() + " and b.Ky=" + cmbKy.SelectedItem.ToString() + " and b.CodeMoi like '8%'");

                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    foreach (DataRow item in dt.Rows)
                    {
                        writer.Write("\"" + item["DanhBo"] + "\"");
                        //writer.Write(",\"" + item["NgayGan"] + "\"");
                        writer.WriteLine(",\"" + item["NgayThay"] + "\"");
                    }
                MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


    }
}
