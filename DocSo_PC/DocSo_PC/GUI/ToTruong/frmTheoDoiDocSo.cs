using System;
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

namespace DocSo_PC.GUI.ToTruong
{
    public partial class frmTheoDoiDocSo : Form
    {
        CDocSo _cDocSo = new CDocSo();
        CTo _cTo = new CTo();

        public frmTheoDoiDocSo()
        {
            InitializeComponent();
        }

        private void frmTheoDoiDocSo_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;

            cmbNam.DataSource = _cDocSo.getDS_Nam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";
            cmbKy.SelectedItem = CNguoiDung.Ky;
            for (int i = CNguoiDung.FromDot; i <= CNguoiDung.ToDot; i++)
            {
                cmbDot.Items.Add(i.ToString("00"));
            }
            cmbDot.SelectedItem = CNguoiDung.Dot;
            if (CNguoiDung.Doi || CNguoiDung.Admin)
            {
                cmbTo.Visible = true;
                List<To> lst = null;
                if (CNguoiDung.Admin)
                    lst = _cTo.getDS_HanhThu();
                else
                    if (CNguoiDung.Doi)
                        lst = _cTo.getDS_HanhThu(CNguoiDung.IDPhong);
                To en = new To();
                en.MaTo = 0;
                en.TenTo = "Tất Cả";
                lst.Insert(0, en);
                cmbTo.DataSource = lst;
                cmbTo.DisplayMember = "TenTo";
                cmbTo.ValueMember = "MaTo";
            }
            else
            {
                lbTo.Text = "Tổ  " + CNguoiDung.TenTo;
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.Doi == true)
            {
                if (cmbTo.SelectedIndex == 0)
                    dgvDanhSach.DataSource = _cDocSo.getTheoDoiDocSo(cmbNam.SelectedValue.ToString(), cmbKy.SelectedItem.ToString(), cmbDot.SelectedItem.ToString());
                else
                    dgvDanhSach.DataSource = _cDocSo.getTheoDoiDocSo(cmbTo.SelectedValue.ToString(), cmbNam.SelectedValue.ToString(), cmbKy.SelectedItem.ToString(), cmbDot.SelectedItem.ToString());
            }
            else
                dgvDanhSach.DataSource = _cDocSo.getTheoDoiDocSo(CNguoiDung.MaTo.ToString(), cmbNam.SelectedValue.ToString(), cmbKy.SelectedItem.ToString(), cmbDot.SelectedItem.ToString());
        }
    }
}
