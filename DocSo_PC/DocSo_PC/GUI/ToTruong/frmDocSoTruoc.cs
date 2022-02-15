using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.ToTruong;
using DocSo_PC.DAL.Doi;
using DocSo_PC.DAL.QuanTri;
using DocSo_PC.LinQ;

namespace DocSo_PC.GUI.ToTruong
{
    public partial class frmDocSoTruoc : Form
    {
        string _mnu = "mnuDocSoTruoc";
        CDocSoTruoc _cDST = new CDocSoTruoc();
        CDocSo _cDocSo = new CDocSo();
        CTo _cTo = new CTo();
        CMayDS _cMayDS = new CMayDS();
        bool _flagLoadFirst = false;

        public frmDocSoTruoc()
        {
            InitializeComponent();
        }

        private void frmDocSoTruoc_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;

            cmbNam.DataSource = _cDocSo.getDS_Nam();
            cmbNam.DisplayMember = "Nam";
            cmbNam.ValueMember = "Nam";
            cmbKy.SelectedItem = CNguoiDung.Ky;
            cmbDot.SelectedItem = CNguoiDung.Dot;
            if (CNguoiDung.Doi)
            {
                cmbTo.Visible = true;
                List<To> lst = _cTo.getDS_HanhThu();
                //To en = new To();
                //en.MaTo = 0;
                //en.TenTo = "Tất Cả";
                //lst.Insert(0, en);
                cmbTo.DataSource = lst;
                cmbTo.DisplayMember = "TenTo";
                cmbTo.ValueMember = "MaTo";
            }
            else
            {
                lbTo.Text = "Tổ  " + CNguoiDung.TenTo;
                loadMay(CNguoiDung.MaTo.ToString());
            }
            loaddgvDanhSach();
            _flagLoadFirst = true;
            loadMay(cmbTo.SelectedValue.ToString());
        }

        public void loaddgvDanhSach()
        {
            dgvDanhSach.DataSource = _cDST.getDS(cmbTo.SelectedValue.ToString());
        }

        public void loadMay(string MaTo)
        {
            try
            {
                DataTable dtMay = new DataTable();
                if (MaTo == "0")
                    for (int i = 1; i < cmbTo.Items.Count; i++)
                    {
                        dtMay.Merge(_cMayDS.getDS(((To)cmbTo.Items[i]).MaTo.ToString()));
                    }
                else
                    dtMay = _cMayDS.getDS(MaTo);
                //DataRow dr = dtMay.NewRow();
                //dr["May"] = "Tất Cả";
                //dtMay.Rows.InsertAt(dr, 0);
                cmbMay.DataSource = dtMay;
                cmbMay.DisplayMember = "May";
                cmbMay.ValueMember = "May";
                cmbMay.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Them"))
                {
                    if (_cDST.checkExist(cmbNam.SelectedValue.ToString(), cmbKy.SelectedItem.ToString(), cmbDot.SelectedItem.ToString(), cmbMay.SelectedValue.ToString()) == true)
                    {
                        MessageBox.Show("Đã Tồn Tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    DocSoTruoc en = new DocSoTruoc();
                    en.Nam = int.Parse(cmbNam.SelectedValue.ToString());
                    en.Ky = cmbKy.SelectedItem.ToString();
                    en.Dot = cmbDot.SelectedItem.ToString();
                    en.May = cmbMay.SelectedValue.ToString();
                    if (_cDST.them(en) == true)
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loaddgvDanhSach();
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
                {
                    DocSoTruoc en = _cDST.get(dgvDanhSach.CurrentRow.Cells["Nam"].Value.ToString(), dgvDanhSach.CurrentRow.Cells["Ky"].Value.ToString(), dgvDanhSach.CurrentRow.Cells["Dot"].Value.ToString(), dgvDanhSach.CurrentRow.Cells["May"].Value.ToString());
                    if (en != null)
                    {
                        if (_cDST.xoa(en) == true)
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loaddgvDanhSach();
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

        private void cmbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_flagLoadFirst == true && cmbTo.SelectedIndex > -1)
            {
                loadMay(cmbTo.SelectedValue.ToString());
                loaddgvDanhSach();
            }
        }

    }
}
