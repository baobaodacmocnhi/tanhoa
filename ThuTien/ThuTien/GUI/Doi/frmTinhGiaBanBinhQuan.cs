﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.Doi;
using ThuTien.DAL.TongHop;

namespace ThuTien.GUI.Doi
{
    public partial class frmTinhGiaBanBinhQuan : Form
    {
        CHoaDon _cHoaDon = new CHoaDon();
        CDCHD _cDCHD = new CDCHD();

        public frmTinhGiaBanBinhQuan()
        {
            InitializeComponent();
        }

        private void frmTinhGiaBanBinhQuan_Load(object sender, EventArgs e)
        {
            dgvGiaBanBinhQuan.AutoGenerateColumns = false;

            cmbNam.DataSource = _cHoaDon.GetNam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            //if (cmbKy.SelectedIndex == 0)
            //    txtGiaBanBinhQuan.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _cHoaDon.TinhGiaBanBinhQuanByNam(int.Parse(cmbNam.SelectedValue.ToString())));
            //else
            //    if (cmbKy.SelectedIndex > 0)
            //        txtGiaBanBinhQuan.Text = String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("vi-VN"), "{0:#,##}", _cHoaDon.TinhGiaBanBinhQuanByNamKy(int.Parse(cmbNam.SelectedValue.ToString()), int.Parse(cmbKy.SelectedItem.ToString())));

            dgvGiaBanBinhQuan.DataSource = _cHoaDon.TinhGiaBanBinhQuanByNam(int.Parse(cmbNam.SelectedValue.ToString()));

            for (int i = 0; i < dgvGiaBanBinhQuan.RowCount; i++)
            {
                DataTable dtDCHD = _cDCHD.GetTongChuanThu(int.Parse(cmbNam.SelectedValue.ToString()), i + 1);
                if(dtDCHD.Rows.Count>0)
                dgvGiaBanBinhQuan["GiaBanBinhQuan", i].Value = (long.Parse(dgvGiaBanBinhQuan["TongGiaBan", i].Value.ToString()) - long.Parse(dtDCHD.Rows[0]["GIABAN_END"].ToString()) + long.Parse(dtDCHD.Rows[0]["GIABAN_BD"].ToString())) / long.Parse(dgvGiaBanBinhQuan["TongTieuThu", i].Value.ToString());
                else
                    dgvGiaBanBinhQuan["GiaBanBinhQuan", i].Value = (long.Parse(dgvGiaBanBinhQuan["TongGiaBan", i].Value.ToString())) / long.Parse(dgvGiaBanBinhQuan["TongTieuThu", i].Value.ToString());
            }
        }

    }
}
