using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrangThietBi.DAL;
using TrangThietBi.LinQ;

namespace TrangThietBi
{
    public partial class frmMain : Form
    {
        CDAL _cDAL = new CDAL();
        ThietBi _thietbi = null;
        PhanMem _phanmem = null;
        bool _ghilichsubangiao = false;
        bool _ghilichsuthuhoi = false;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            dgvDSThietBi.AutoGenerateColumns = false;
            dgvDSPhanMem.AutoGenerateColumns = false;

            cmbPhongBanNhanTB.DataSource = _cDAL.GetDSPhongBan();
            cmbPhongBanNhanTB.DisplayMember = "TenPhongBan";
            cmbPhongBanNhanTB.ValueMember = "ID";

            cmbPhongBanNhanPM.DataSource = _cDAL.GetDSPhongBan();
            cmbPhongBanNhanPM.DisplayMember = "TenPhongBan";
            cmbPhongBanNhanPM.ValueMember = "ID";

            dgvDSThietBi.DataSource = _cDAL.GetDSThietBi();
            dgvDSPhanMem.DataSource = _cDAL.GetDSPhanMem();
        }

        private void GetDSThietBi()
        {
            dgvDSThietBi.DataSource = _cDAL.GetDSThietBi();
        }

        private void FillThongTinThietBi(ThietBi item)
        {
            txtTenTB.Text = item.Ten;
            txtGiaTienTB.Text = item.GiaTien.Value.ToString();
            txtCauHinh.Text = item.CauHinh;
            dateMua.Value = item.NgayMua.Value;
            dateHetHanTB.Value = item.NgayHetHan.Value;
            if (item.BanGiao)
            {
                chkBanGiao.Checked = true;
                dateBanGiao.Value = item.NgayBanGiao.Value;
                txtNguoiNhan.Text = item.NguoiNhan;
                cmbPhongBanNhanTB.SelectedValue = item.PhongBanNhan;
                txtGhiChuBanGiao.Text = item.GhiChuBanGiao;
            }
            else
            {
                chkBanGiao.Checked = false;
                dateBanGiao.Value = DateTime.Now;
                txtNguoiNhan.Text = "";
                cmbPhongBanNhanTB.SelectedIndex = -1;
                txtGhiChuBanGiao.Text = "";
            }
            if (item.ThuHoi)
            {
                chkThuHoi.Checked = true;
                dateThuHoi.Value = item.NgayThuHoi.Value;
                txtGhiChuThuHoi.Text = item.GhiChuThuHoi;
            }
            else
            {
                chkThuHoi.Checked = false;
                dateThuHoi.Value = DateTime.Now;
                txtGhiChuThuHoi.Text = "";
            }
        }

        private void ClearThietBi()
        {
            txtTenTB.Text = "";
            txtGiaTienTB.Text = "";
            dateMua.Value = DateTime.Now;
            dateHetHanTB.Value = DateTime.Now;

            chkBanGiao.Checked = false;
            dateBanGiao.Value = DateTime.Now;
            txtNguoiNhan.Text = "";
            cmbPhongBanNhanTB.SelectedIndex = -1;
            txtGhiChuBanGiao.Text = "";

            chkThuHoi.Checked = false;
            dateThuHoi.Value = DateTime.Now;
            txtGhiChuThuHoi.Text = "";

            _ghilichsubangiao = false;
            _ghilichsuthuhoi = false;
            _thietbi = null;

            dgvDSThietBi.DataSource = _cDAL.GetDSThietBi();
        }

        private void chkBanGiao_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBanGiao.Checked)
                gBanGiao.Enabled = true;
            else
                gBanGiao.Enabled = false;
        }

        private void chkThuHoi_CheckedChanged(object sender, EventArgs e)
        {
            if (chkThuHoi.Checked)
                gThuHoi.Enabled = true;
            else
                gThuHoi.Enabled = false;
        }

        private void btnThemTB_Click(object sender, EventArgs e)
        {
            ThietBi item = new ThietBi();
            item.Ten = txtTenTB.Text.Trim();
            if (txtGiaTienTB.Text.Trim()!="")
            item.GiaTien = int.Parse(txtGiaTienTB.Text.Trim());
            item.CauHinh = txtCauHinh.Text.Trim();
            item.NgayMua = dateMua.Value;
            //item.NgayHetHan = dateHetHanTB.Value;
            if (chkBanGiao.Checked)
            {
                _ghilichsubangiao = true;

                item.BanGiao = true;
                item.NgayBanGiao = dateBanGiao.Value;
                item.NguoiNhan = txtNguoiNhan.Text.Trim();
                item.PhongBanNhan = int.Parse(cmbPhongBanNhanTB.SelectedValue.ToString());
                item.GhiChuBanGiao = txtGhiChuBanGiao.Text.Trim();
            }

            if (_cDAL.ThemThietBi(item))
            {
                if (_ghilichsubangiao == true)
                {
                    LichSuBanGiao lsbg = new LichSuBanGiao();
                    lsbg.NgayBanGiao = item.NgayBanGiao;
                    lsbg.NguoiNhan = item.NguoiNhan;
                    lsbg.PhongBanNhan = item.PhongBanNhan;
                    lsbg.GhiChuBanGiao = item.GhiChuBanGiao;
                    lsbg.MaTB = item.MaTB;

                    _cDAL.ThemLichSuBanGiao(lsbg);
                }
                ClearThietBi();
            }
        }

        private void btnSuaTB_Click(object sender, EventArgs e)
        {
            if (_thietbi != null)
            {
                _thietbi.Ten = txtTenTB.Text.Trim();
                if (txtGiaTienTB.Text.Trim() != "")
                    _thietbi.GiaTien = int.Parse(txtGiaTienTB.Text.Trim());
                else
                    _thietbi.GiaTien = null;
                _thietbi.CauHinh = txtCauHinh.Text.Trim();
                _thietbi.NgayMua = dateMua.Value;
                _thietbi.NgayHetHan = dateHetHanTB.Value;
                if (chkBanGiao.Checked)
                {
                    if (_thietbi.BanGiao == false)
                        _ghilichsubangiao = true;

                    _thietbi.BanGiao = true;
                    _thietbi.NgayBanGiao = dateBanGiao.Value;
                    _thietbi.NguoiNhan = txtNguoiNhan.Text.Trim();
                    _thietbi.PhongBanNhan = int.Parse(cmbPhongBanNhanTB.SelectedValue.ToString());
                    _thietbi.GhiChuBanGiao = txtGhiChuBanGiao.Text.Trim();
                }
                else
                {
                    _thietbi.BanGiao = false;
                    _thietbi.NgayBanGiao = null;
                    _thietbi.NguoiNhan = null;
                    _thietbi.PhongBanNhan = null;
                    _thietbi.GhiChuBanGiao = null;
                }

                if (chkThuHoi.Checked)
                {
                    if (_thietbi.ThuHoi == false)
                        _ghilichsuthuhoi = true;

                    _thietbi.ThuHoi = true;
                    _thietbi.NgayThuHoi = dateThuHoi.Value;
                    _thietbi.GhiChuThuHoi = txtGhiChuThuHoi.Text.Trim();
                }
                else
                {
                    _thietbi.ThuHoi = false;
                    _thietbi.NgayThuHoi = null;
                    _thietbi.GhiChuThuHoi = null;
                }

                if (_cDAL.SuaThietBi(_thietbi))
                {
                    if (_ghilichsubangiao == true)
                    {
                        LichSuBanGiao lsbg = new LichSuBanGiao();
                        lsbg.NgayBanGiao = _thietbi.NgayBanGiao;
                        lsbg.NguoiNhan = _thietbi.NguoiNhan;
                        lsbg.PhongBanNhan = _thietbi.PhongBanNhan;
                        lsbg.GhiChuBanGiao = _thietbi.GhiChuBanGiao;
                        lsbg.MaTB = _thietbi.MaTB;

                        _cDAL.ThemLichSuBanGiao(lsbg);
                    }

                    if (_ghilichsuthuhoi == true)
                    {
                        LichSuThuHoi lsth = new LichSuThuHoi();
                        lsth.NgayThuHoi = _thietbi.NgayThuHoi;
                        lsth.GhiChuThuHoi = _thietbi.GhiChuThuHoi;
                        lsth.MaTB = _thietbi.MaTB;

                        _cDAL.ThemLichSuThuHoi(lsth);
                    }

                    ClearThietBi();
                }
            }
        }

        private void btnXoaTB_Click(object sender, EventArgs e)
        {
            if (_thietbi != null)
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (_cDAL.XoaThietBi(_thietbi))
                        ClearThietBi();
                }

        }

        private void dgvDSThietBi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _thietbi = _cDAL.GetThietBi(int.Parse(dgvDSThietBi.CurrentRow.Cells["MaTB"].Value.ToString()));
                FillThongTinThietBi(_thietbi);
            }
            catch
            {
                
            }
        }

        private void GetDSPhanMem()
        {
            dgvDSPhanMem.DataSource = _cDAL.GetDSPhanMem();
        }

        private void FillThongTinPhanMem(PhanMem item)
        {
            txtTenPM.Text = item.Ten;
            txtGiaTienPM.Text = item.GiaTien.Value.ToString();
            dateHetHanPM.Value = item.NgayHetHan.Value;
            cmbPhongBanNhanPM.SelectedValue = item.PhongBanNhan;
        }

        private void ClearPhanMem()
        {
            txtTenPM.Text = "";
            txtGiaTienPM.Text = "";
            dateHetHanPM.Value = DateTime.Now;
            cmbPhongBanNhanPM.SelectedIndex = -1;

            _phanmem = null;

            dgvDSPhanMem.DataSource = _cDAL.GetDSPhanMem();
        }

        private void btnThemPM_Click(object sender, EventArgs e)
        {
            PhanMem item = new PhanMem();
            item.Ten = txtTenPM.Text.Trim();
            item.GiaTien = int.Parse(txtGiaTienPM.Text.Trim());
            item.NgayHetHan = dateHetHanPM.Value;
            item.PhongBanNhan = int.Parse(cmbPhongBanNhanPM.SelectedValue.ToString());

            if (_cDAL.ThemPhanMem(item))
            {
                ClearPhanMem();
            }
        }

        private void btnSuaPM_Click(object sender, EventArgs e)
        {
            if (_phanmem != null)
            {
                _phanmem.Ten = txtTenPM.Text.Trim();
                _phanmem.GiaTien = int.Parse(txtGiaTienPM.Text.Trim());
                _phanmem.NgayHetHan = dateHetHanPM.Value;
                _phanmem.PhongBanNhan = int.Parse(cmbPhongBanNhanPM.SelectedValue.ToString());

                if(_cDAL.SuaPhanMem(_phanmem))
                    ClearPhanMem();
            }
        }

        private void btnXoaPM_Click(object sender, EventArgs e)
        {
            if (_phanmem != null)
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (_cDAL.XoaPhanMem(_phanmem))
                        ClearPhanMem();
                }
        }

        private void dgvDSPhanMem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _phanmem = _cDAL.GetPhanMem(int.Parse(dgvDSPhanMem.CurrentRow.Cells["MaPM"].Value.ToString()));
                FillThongTinPhanMem(_phanmem);
            }
            catch
            {

            }
        }

        
    }
}
