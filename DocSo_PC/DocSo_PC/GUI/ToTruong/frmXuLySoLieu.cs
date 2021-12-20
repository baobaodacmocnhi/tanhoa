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
using DocSo_PC.DAL;

namespace DocSo_PC.GUI.ToTruong
{
    public partial class frmXuLySoLieu : Form
    {
        string _mnu = "mnuXuLySoLieu";
        CDocSo _cDocSo = new CDocSo();
        CTo _cTo = new CTo();
        CMayDS _cMayDS = new CMayDS();
        CDHN _cDHN = new CDHN();
        DocSo _docso = null;
        bool _flagLoadFirst = false;

        public frmXuLySoLieu()
        {
            InitializeComponent();
        }

        private void frmXuLySoLieu_Load(object sender, EventArgs e)
        {
            try
            {
                dgvDanhSach.AutoGenerateColumns = false;
                dgvThongBao.AutoGenerateColumns = false;
                dgvBaoThay.AutoGenerateColumns = false;
                dgvLichSu.AutoGenerateColumns = false;

                cmbNam.DataSource = _cDocSo.getDS_Nam();
                cmbNam.DisplayMember = "Nam";
                cmbNam.ValueMember = "Nam";
                cmbKy.SelectedItem = DateTime.Now.Month.ToString();
                DataTable dtCode = _cDocSo.getDS_Code();
                DataRow dr = dtCode.NewRow();
                dr["Code"] = "Tất Cả";
                dtCode.Rows.InsertAt(dr, 0);
                cmbCode.DataSource = dtCode;
                cmbCode.DisplayMember = "Code";
                cmbCode.ValueMember = "Code";
                if (CNguoiDung.Doi)
                {
                    cmbTo.Visible = true;

                    cmbTo.DataSource = _cTo.getDS_HanhThu();
                    cmbTo.DisplayMember = "TenTo";
                    cmbTo.ValueMember = "MaTo";
                    cmbTo.SelectedIndex = -1;
                }
                else
                {
                    lbTo.Text = "Tổ  " + CNguoiDung.TenTo;
                    loadMay(CNguoiDung.MaTo.ToString());
                }
                _flagLoadFirst = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadMay(string MaTo)
        {
            try
            {
                DataTable dtMay = _cMayDS.getDS(MaTo);
                DataRow dr = dtMay.NewRow();
                dr["May"] = "Tất Cả";
                dtMay.Rows.InsertAt(dr, 0);
                cmbMay.DataSource = dtMay;
                cmbMay.DisplayMember = "May";
                cmbMay.ValueMember = "May";
                //cmbMay.SelectedIndex = ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadThongTin()
        {
            try
            {
                if (_docso != null)
                {
                    TB_DULIEUKHACHHANG dhn = _cDHN.get(_docso.DanhBa);
                    if (dhn != null)
                    {
                        txtHoTen.Text = dhn.HOTEN;
                        txtDanhBo.Text = dhn.DANHBO.Insert(7, " ").Insert(4, " ");
                        txtHieu.Text = dhn.HIEUDH;
                        txtCo.Text = dhn.CODH;
                        txtSoThan.Text = dhn.SOTHANDH;
                        txtViTri.Text = dhn.VITRIDHN;
                        txtHopDong.Text = dhn.HOPDONG;
                        txtDiaChi.Text = dhn.SONHA + " " + dhn.TENDUONG;
                        txtMLT.Text = dhn.LOTRINH.Insert(4, " ").Insert(2, " ");
                        txtGiaBieu.Text = dhn.GIABIEU;
                        txtDinhMuc.Text = dhn.DINHMUC;
                        dgvThongBao.DataSource = _cDocSo.getThongBao(_docso.DanhBa);
                        dgvBaoThay.DataSource = _cDocSo.getBaoThay(_docso.DanhBa);
                        dgvLichSu.DataSource = _cDocSo.getLichSu(_docso.DanhBa, _docso.Nam.Value.ToString(), _docso.Ky);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_flagLoadFirst == true && cmbTo.SelectedIndex > -1)
                loadMay(cmbTo.SelectedValue.ToString());
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dtTong = new DataTable();
            if (CNguoiDung.Doi == true)
            {
                if (txtDanhBoTK.Text.Trim().Replace(" ", "").Replace("-", "") != "")
                {
                    dt = _cDocSo.getDS_XuLy_DanhBo(cmbNam.SelectedValue.ToString(), cmbKy.SelectedItem.ToString(), txtDanhBoTK.Text.Trim().Replace(" ", "").Replace("-", ""));
                }
                else
                {
                    dt = _cDocSo.getDS_XuLy(cmbTo.SelectedValue.ToString(), cmbNam.SelectedValue.ToString(), cmbKy.SelectedItem.ToString(), cmbDot.SelectedItem.ToString(), cmbMay.SelectedValue.ToString(), cmbCode.SelectedValue.ToString(), ref dtTong);
                }
            }
            else
            {

            }
            dgvDanhSach.DataSource = dt;
            if (dtTong != null && dtTong.Rows.Count > 0)
            {
                lbTongSL.Text = dtTong.Rows[0]["TongSL"].ToString();
                lbSLDaGhi.Text = dtTong.Rows[0]["SLDaGhi"].ToString();
                lbSLChuaGhi.Text = dtTong.Rows[0]["SLChuaGhi"].ToString();
                lbSanLuong.Text = dtTong.Rows[0]["SanLuong"].ToString();
                lbSLHD0.Text = dtTong.Rows[0]["SLHD0"].ToString();
            }
        }

        private void txtDanhBo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtDanhBoTK.Text.Trim().Replace(" ", "").Replace("-", "") != "")
                btnXem.PerformClick();
        }

        private void dgvDanhSach_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDanhSach.Columns[e.ColumnIndex].Name == "MLT" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(2, " ");
            }
            if (dgvDanhSach.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null)
            {
                e.Value = e.Value.ToString().Insert(7, " ").Insert(4, " ");
            }
        }

        private void dgvDanhSach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDanhSach.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _docso = _cDocSo.get_DocSo(dgvDanhSach.CurrentRow.Cells["DocSoID"].Value.ToString());
                loadThongTin();
            }
            catch
            {
            }
        }

        private void btnXemHinh_Click(object sender, EventArgs e)
        {
            if (_docso != null)
            {
                if (_docso.Ky == "01")
                {
                    lblKy0.Text = "12" + "/" + (_docso.Nam - 1);
                    lblKy1.Text = "11" + "/" + (_docso.Nam - 1);
                    lblKy2.Text = "10" + "/" + (_docso.Nam - 1);
                }
                else
                    if (_docso.Ky == "02")
                    {
                        lblKy0.Text = "01" + "/" + (_docso.Nam);
                        lblKy1.Text = "12" + "/" + (_docso.Nam - 1);
                        lblKy2.Text = "11" + "/" + (_docso.Nam - 1);
                    }
                    else
                        if (_docso.Ky == "03")
                        {
                            lblKy0.Text = "01" + "/" + (_docso.Nam);
                            lblKy1.Text = "02" + "/" + (_docso.Nam);
                            lblKy2.Text = "12" + "/" + (_docso.Nam - 1);
                        }
                        else
                        {
                            lblKy0.Text = (int.Parse(_docso.Ky) - 1).ToString("00") + "/" + (_docso.Nam);
                            lblKy1.Text = (int.Parse(_docso.Ky) - 2).ToString("00") + "/" + (_docso.Nam);
                            lblKy2.Text = (int.Parse(_docso.Ky) - 3).ToString("00") + "/" + (_docso.Nam);
                        }
                ptbKy0.Image = ImageUtil.FromByteArray(images.Img0);
                ptbKy1.Image = ImageUtil.FromByteArray(images.Img1);
                ptbKy2.Image = ImageUtil.FromByteArray(images.Img2);
            }
        }
    }
}
