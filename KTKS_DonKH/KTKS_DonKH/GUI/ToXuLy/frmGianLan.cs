using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using KTKS_DonKH.LinQ;
using KTKS_DonKH.DAL.ToKhachHang;
using KTKS_DonKH.DAL.ToXuLy;
using KTKS_DonKH.DAL;
using KTKS_DonKH.BaoCao;
using KTKS_DonKH.BaoCao.ToXuLy;
using KTKS_DonKH.GUI.BaoCao;

namespace KTKS_DonKH.GUI.ToXuLy
{
    public partial class frmGianLan : Form
    {
        DonKH _donkh = null;
        DonTXL _dontxl = null;
        HOADON _hoadon = null;
        CDonKH _cDonKH = new CDonKH();
        CDonTXL _cDonTXL = new CDonTXL();
        CThuTien _cThuTien = new CThuTien();
        CDocSo _cDocSo = new CDocSo();
        CGianLan _cGianLan = new CGianLan();
        GianLan _gianlan = null;

        public frmGianLan()
        {
            InitializeComponent();
        }

        public void LoadTTKH(HOADON hoadon)
        {
            txtDanhBo.Text = hoadon.DANHBA;
            txtHoTen.Text = hoadon.TENKH;
            txtDiaChi.Text = hoadon.SO + " " + hoadon.DUONG + _cDocSo.getPhuongQuanByID(hoadon.Quan, hoadon.Phuong);
        }

        public void LoadGianLan(GianLan entity)
        {
            if (entity.NgayKTXM!=null)
            dateKTXM.Value = entity.NgayKTXM.Value;
            txtNoiDungViPham.Text = entity.NoiDungViPham;
            if(entity.TienDHN!=null)
            txtTienDHN.Text = entity.TienDHN.Value.ToString();
            txtTinhTrang.Text = entity.TinhTrang;
            txtNhanVien.Text = entity.NhanVien;
            if (entity.ToTrinh1)
            {
                chkToTrinh1.Checked = true;
                txtTieuThu1.Text = entity.TieuThu1.Value.ToString();
                txtGiaBan1.Text = entity.GiaBan1.Value.ToString();
                txtSoThongBao1.Text = entity.SoThongBao1;
            }
            else
            {
                chkToTrinh1.Checked = false;
                txtTieuThu1.Text = "";
                txtGiaBan1.Text = "";
                txtSoThongBao1.Text = "";
            }
            ///
            if (entity.ToTrinh2)
            {
                chkToTrinh2.Checked = true;
                txtTieuThu2.Text = entity.TieuThu2.Value.ToString();
                txtGiaBan2.Text = entity.GiaBan2.Value.ToString();
                txtSoThongBao2.Text = entity.SoThongBao2;
            }
            else
            {
                chkToTrinh2.Checked = false;
                txtTieuThu2.Text = "";
                txtGiaBan2.Text = "";
                txtSoThongBao2.Text = "";
            }
            ///
            if (entity.ThanhToan1)
            {
                chkThanhToan1.Checked = true;
                dateThanhToan1.Value = entity.Ngay1.Value;
                txtSoTien1.Text = entity.SoTien1.Value.ToString();
            }
            else
            {
                chkThanhToan1.Checked = false;
                dateThanhToan1.Value = DateTime.Now;
                txtSoTien1.Text = "";
            }
            ///
            if (entity.ThanhToan1)
            {
                chkThanhToan2.Checked = true;
                dateThanhToan2.Value = entity.Ngay2.Value;
                txtSoTien2.Text = entity.SoTien2.Value.ToString();
            }
            else
            {
                chkThanhToan2.Checked = false;
                dateThanhToan2.Value = DateTime.Now;
                txtSoTien2.Text = "";
            }
            ///
            if (entity.ThanhToan3)
            {
                chkThanhToan3.Checked = true;
                dateThanhToan3.Value = entity.Ngay3.Value;
                txtSoTien3.Text = entity.SoTien3.Value.ToString();
            }
            else
            {
                chkThanhToan3.Checked = false;
                dateThanhToan3.Value = DateTime.Now;
                txtSoTien3.Text = "";
            }
        }

        public void Clear()
        {
            txtDanhBo.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            ///
            txtNoiDungViPham.Text = "";
            txtTienDHN.Text = "";
            txtTinhTrang.Text = "";
            txtNhanVien.Text = "";
            chkToTrinh1.Checked = false;
            chkToTrinh2.Checked = false;
            chkThanhToan1.Checked = false;
            chkThanhToan2.Checked = false;
            chkThanhToan3.Checked = false;
            ///
            _donkh = null;
            _dontxl = null;
            _hoadon = null;
            _gianlan = null;
            _file1 = null;
            _file2 = null;
            _fileBB = null;
        }

        private void frmGianLan_Load(object sender, EventArgs e)
        {
            dgvGianLan.AutoGenerateColumns = false;

            DataTable dt = _cGianLan.GetDSNoiDungViPham();
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            foreach (DataRow item in dt.Rows)
            {
                auto.Add(item["NoiDungViPham"].ToString());
            }
            txtNoiDungViPham.AutoCompleteCustomSource = auto;

            dt = _cGianLan.GetDSTinhTrang();
            AutoCompleteStringCollection auto1 = new AutoCompleteStringCollection();
            foreach (DataRow item in dt.Rows)
            {
                auto1.Add(item["TinhTrang"].ToString());
            }
            txtTinhTrang.AutoCompleteCustomSource = auto1;
        }

        private void txtMaDon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtMaDon.Text.Trim() != "")
            {
                Clear();
                ///Đơn Tổ Xử Lý
                if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
                {
                    if (_cDonTXL.getDonTXLbyID(decimal.Parse(txtMaDon.Text.Trim().Substring(3).Replace("-", ""))) != null)
                    {
                        _dontxl = _cDonTXL.getDonTXLbyID(decimal.Parse(txtMaDon.Text.Trim().Substring(3).Replace("-", "")));
                        txtMaDon.Text = "TXL" + _dontxl.MaDon.ToString().Insert(_dontxl.MaDon.ToString().Length - 2, "-");
                        if (_cThuTien.GetMoiNhat(_dontxl.DanhBo) != null)
                        {
                            _hoadon = _cThuTien.GetMoiNhat(_dontxl.DanhBo);
                            LoadTTKH(_hoadon);
                            if (_cGianLan.CheckExist_TXL(_dontxl.MaDon))
                            {
                                _gianlan = _cGianLan.Get_TXL(_dontxl.MaDon);
                                LoadGianLan(_gianlan);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //MessageBox.Show("Mã Đơn TXL này có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //txtDanhBo.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                ///Đơn Tổ Khách Hàng
                else
                    if (_cDonKH.getDonKHbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("-", ""))) != null)
                    {
                        _donkh = _cDonKH.getDonKHbyID(decimal.Parse(txtMaDon.Text.Trim().Replace("-", "")));
                        txtMaDon.Text = _donkh.MaDon.ToString().Insert(_donkh.MaDon.ToString().Length - 2, "-");
                        if (_cThuTien.GetMoiNhat(_donkh.DanhBo) != null)
                        {
                            _hoadon = _cThuTien.GetMoiNhat(_donkh.DanhBo);
                            LoadTTKH(_hoadon);
                            if (_cGianLan.CheckExist(_donkh.MaDon))
                            {
                                _gianlan = _cGianLan.Get_TXL(_donkh.MaDon);
                                LoadGianLan(_gianlan);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Danh Bộ này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //MessageBox.Show("Mã Đơn KH này có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //txtDanhBo.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Mã Đơn này không có", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ///Nếu đơn thuộc Tổ Xử Lý
            if (txtMaDon.Text.Trim().ToUpper().Contains("TXL"))
            {
                if (_dontxl != null)
                {
                    if (_cGianLan.CheckExist_TXL(_dontxl.MaDon))
                    {
                        MessageBox.Show("Đơn này đã lập Gian Lận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    GianLan entity = new GianLan();
                    entity.ToXuLy = true;
                    entity.MaDonTXL = _dontxl.MaDon;
                    entity.DanhBo = txtDanhBo.Text.Trim().Replace(" ","");
                    entity.HoTen = txtHoTen.Text.Trim();
                    entity.DiaChi = txtDiaChi.Text.Trim();
                    entity.NgayKTXM = dateKTXM.Value;
                    entity.NoiDungViPham = txtNoiDungViPham.Text.Trim();
                    if (!string.IsNullOrEmpty(txtTienDHN.Text.Trim()))
                        entity.TienDHN = int.Parse(txtTienDHN.Text.Trim());
                    entity.TinhTrang = txtTinhTrang.Text.Trim();
                    entity.NhanVien = txtNhanVien.Text.Trim();

                    if (_fileBB != null)
                    {
                        entity.FileBienBan = _fileBB;
                    }

                    if (chkToTrinh1.Checked)
                    {
                        entity.ToTrinh1 = true;
                        entity.TieuThu1 = int.Parse(txtTieuThu1.Text.Trim());
                        entity.GiaBan1 = int.Parse(txtGiaBan1.Text.Trim());
                        if (_file1 != null)
                        {
                            entity.File1 = _file1;
                        }
                    }
                    ///
                    if (chkToTrinh2.Checked)
                    {
                        entity.ToTrinh2 = true;
                        entity.TieuThu2 = int.Parse(txtTieuThu2.Text.Trim());
                        entity.GiaBan2 = int.Parse(txtGiaBan2.Text.Trim());
                        if (_file2 != null)
                        {
                            entity.File2 = _file2;
                        }
                    }
                    ///
                    if (chkThanhToan1.Checked)
                    {
                        entity.ThanhToan1 = true;
                        entity.Ngay1 = dateThanhToan1.Value;
                        entity.SoTien1 = int.Parse(txtSoTien1.Text.Trim());
                    }
                    ///
                    if (chkThanhToan2.Checked)
                    {
                        entity.ThanhToan2 = true;
                        entity.Ngay2 = dateThanhToan2.Value;
                        entity.SoTien2 = int.Parse(txtSoTien2.Text.Trim());
                    }
                    ///
                    if (chkThanhToan3.Checked)
                    {
                        entity.ThanhToan3 = true;
                        entity.Ngay3 = dateThanhToan3.Value;
                        entity.SoTien3 = int.Parse(txtSoTien3.Text.Trim());
                    }

                    if (_cGianLan.Them(entity))
                    {
                        Clear();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            ///Nếu đơn thuộc Tổ Khách Hàng
            else
            {
                if (_donkh != null)
                {
                    if (_cGianLan.CheckExist(_donkh.MaDon))
                    {
                        MessageBox.Show("Đơn này đã lập Gian Lận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    GianLan entity = new GianLan();
                    entity.MaDon = _donkh.MaDon;
                    entity.DanhBo = txtDanhBo.Text.Trim().Replace(" ", "");
                    entity.HoTen = txtHoTen.Text.Trim();
                    entity.DiaChi = txtDiaChi.Text.Trim();
                    entity.NgayKTXM = dateKTXM.Value;
                    entity.NoiDungViPham = txtNoiDungViPham.Text.Trim();
                    entity.TienDHN = int.Parse(txtTienDHN.Text.Trim());
                    entity.TinhTrang = txtTinhTrang.Text.Trim();
                    entity.NhanVien = txtNhanVien.Text.Trim();

                    if (_fileBB != null)
                    {
                        entity.FileBienBan = _fileBB;
                    }

                    if (chkToTrinh1.Checked)
                    {
                        entity.ToTrinh1 = true;
                        entity.TieuThu1 = int.Parse(txtTieuThu1.Text.Trim());
                        entity.GiaBan1 = int.Parse(txtGiaBan1.Text.Trim());
                        if (_file1 != null)
                        {
                            entity.File1 = _file1;
                        }
                    }
                    ///
                    if (chkToTrinh2.Checked)
                    {
                        entity.ToTrinh2 = true;
                        entity.TieuThu2 = int.Parse(txtTieuThu2.Text.Trim());
                        entity.GiaBan2 = int.Parse(txtGiaBan2.Text.Trim());
                        if (_file2 != null)
                        {
                            entity.File2 = _file2;
                        }
                    }
                    ///
                    if (chkThanhToan1.Checked)
                    {
                        entity.ThanhToan1 = true;
                        entity.Ngay1 = dateThanhToan1.Value;
                        entity.SoTien1 = int.Parse(txtSoTien1.Text.Trim());
                    }
                    ///
                    if (chkThanhToan2.Checked)
                    {
                        entity.ThanhToan2 = true;
                        entity.Ngay2 = dateThanhToan2.Value;
                        entity.SoTien2 = int.Parse(txtSoTien2.Text.Trim());
                    }
                    ///
                    if (chkThanhToan3.Checked)
                    {
                        entity.ThanhToan3 = true;
                        entity.Ngay3 = dateThanhToan3.Value;
                        entity.SoTien3 = int.Parse(txtSoTien3.Text.Trim());
                    }

                    if (_cGianLan.Them(entity))
                    {
                        Clear();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            btnXem.PerformClick();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_gianlan != null)
            {
                _gianlan.NgayKTXM = dateKTXM.Value;
                _gianlan.NoiDungViPham = txtNoiDungViPham.Text.Trim();
                if (!string.IsNullOrEmpty(txtTienDHN.Text.Trim()))
                    _gianlan.TienDHN = int.Parse(txtTienDHN.Text.Trim());
                _gianlan.TinhTrang = txtTinhTrang.Text.Trim();
                _gianlan.NhanVien = txtNhanVien.Text.Trim();

                if (_fileBB != null)
                {
                    _gianlan.FileBienBan = _fileBB;
                }

                if (chkToTrinh1.Checked)
                {
                    _gianlan.ToTrinh1 = true;
                    _gianlan.TieuThu1 = int.Parse(txtTieuThu1.Text.Trim());
                    _gianlan.GiaBan1 = int.Parse(txtGiaBan1.Text.Trim());
                    if (_file1 != null)
                    {
                        _gianlan.File1 = _file1;
                    }
                }
                else
                {
                    _gianlan.ToTrinh1 = false;
                    _gianlan.TieuThu1 = null;
                    _gianlan.GiaBan1 = null;
                    _gianlan.File1 = null;
                }
                ///
                if (chkToTrinh2.Checked)
                {
                    _gianlan.ToTrinh2 = true;
                    _gianlan.TieuThu2 = int.Parse(txtTieuThu2.Text.Trim());
                    _gianlan.GiaBan2 = int.Parse(txtGiaBan2.Text.Trim());
                    if (_file2 != null)
                    {
                        _gianlan.File2 = _file2;
                    }
                }
                else
                {
                    _gianlan.ToTrinh2 = false;
                    _gianlan.TieuThu2 = null;
                    _gianlan.GiaBan2 = null;
                    _gianlan.File2 = null;
                }
                ///
                if (chkThanhToan1.Checked)
                {
                    _gianlan.ThanhToan1 = true;
                    _gianlan.Ngay1 = dateThanhToan1.Value;
                    _gianlan.SoTien1 = int.Parse(txtSoTien1.Text.Trim());
                }
                else
                {
                    _gianlan.ThanhToan1 = false;
                    _gianlan.Ngay1 = null;
                    _gianlan.SoTien1 = null;
                }
                ///
                if (chkThanhToan2.Checked)
                {
                    _gianlan.ThanhToan2 = true;
                    _gianlan.Ngay2 = dateThanhToan2.Value;
                    _gianlan.SoTien2 = int.Parse(txtSoTien2.Text.Trim());
                }
                else
                {
                    _gianlan.ThanhToan2 = false;
                    _gianlan.Ngay2 = null;
                    _gianlan.SoTien2 = null;
                }
                ///
                if (chkThanhToan3.Checked)
                {
                    _gianlan.ThanhToan3 = true;
                    _gianlan.Ngay3 = dateThanhToan3.Value;
                    _gianlan.SoTien3 = int.Parse(txtSoTien3.Text.Trim());
                }
                else
                {
                    _gianlan.ThanhToan3 = false;
                    _gianlan.Ngay3 = null;
                    _gianlan.SoTien3 = null;
                }

                if (_cGianLan.Sua(_gianlan))
                {
                    Clear();
                    MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void chkToTrinh1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkToTrinh1.Checked)
                gbToTrinh1.Enabled = true;
            else
                gbToTrinh1.Enabled = false;
        }

        private void chkToTrinh2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkToTrinh2.Checked)
                gbToTrinh2.Enabled = true;
            else
                gbToTrinh2.Enabled = false;
        }

        private void chkThanhToan1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkThanhToan1.Checked)
                gbThanhToan1.Enabled = true;
            else
                gbThanhToan1.Enabled = false;
        }

        private void chkThanhToan2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkThanhToan2.Checked)
                gbThanhToan2.Enabled = true;
            else
                gbThanhToan2.Enabled = false;
        }

        private void chkThanhToan3_CheckedChanged(object sender, EventArgs e)
        {
            if (chkThanhToan3.Checked)
                gbThanhToan3.Enabled = true;
            else
                gbThanhToan3.Enabled = false;
        }

        private void txtTieuThu1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTieuThu1.Text.Trim()) && !string.IsNullOrEmpty(txtGiaBan1.Text.Trim()))
            {
                txtThanhTien1.Text = ((int.Parse(txtTieuThu1.Text.Trim()) * int.Parse(txtGiaBan1.Text.Trim()))*1.15).ToString();
            }
            else
                txtThanhTien1.Text = "";
        }

        private void txtGiaBan1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTieuThu1.Text.Trim()) && !string.IsNullOrEmpty(txtGiaBan1.Text.Trim()))
            {
                txtThanhTien1.Text = ((int.Parse(txtTieuThu1.Text.Trim()) * int.Parse(txtGiaBan1.Text.Trim())) * 1.15).ToString();
            }
            else
                txtThanhTien1.Text = "";
        }

        private void txtTieuThu2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTieuThu2.Text.Trim()) && !string.IsNullOrEmpty(txtGiaBan2.Text.Trim()))
            {
                txtThanhTien2.Text = ((int.Parse(txtTieuThu2.Text.Trim()) * int.Parse(txtGiaBan2.Text.Trim()))*1.15).ToString();
            }
            else
                txtThanhTien2.Text = "";
        }

        private void txtGiaBan2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTieuThu2.Text.Trim()) && !string.IsNullOrEmpty(txtGiaBan2.Text.Trim()))
            {
                txtThanhTien2.Text = ((int.Parse(txtTieuThu2.Text.Trim()) * int.Parse(txtGiaBan2.Text.Trim())) * 1.15).ToString();
            }
            else
                txtThanhTien2.Text = "";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dgvGianLan.DataSource = _cGianLan.GetDS(dateTu.Value,dateDen.Value);
        }

        private void btnInDS_Click(object sender, EventArgs e)
        {
            DataSetBaoCao dsBaoCao = new DataSetBaoCao();
            foreach (DataGridViewRow item in dgvGianLan.Rows)
            {
                DataRow dr = dsBaoCao.Tables["GianLan"].NewRow();
                dr["TuNgay"] = dateTu.Value.ToString("dd/MM/yyyy");
                dr["DenNgay"] = dateDen.Value.ToString("dd/MM/yyyy");

                GianLan entity = _cGianLan.Get(int.Parse(item.Cells["ID"].Value.ToString()));

                if (entity.ToXuLy)
                    dr["MaDon"] = "TXL" + entity.MaDonTXL.Value.ToString().Insert(entity.MaDonTXL.Value.ToString().Length - 2, "-");
                else
                    dr["MaDon"] = entity.MaDon.Value.ToString().Insert(entity.MaDon.Value.ToString().Length - 2, "-");
                if (entity.NgayKTXM != null)
                    dr["NgayKTXM"] = entity.NgayKTXM.Value.ToString("dd/MM/yyyy");
                dr["DanhBo"] = entity.DanhBo.Insert(7, " ").Insert(4, " ");
                dr["HoTen"] = entity.HoTen;
                dr["DiaChi"] = entity.DiaChi;
                dr["NoiDungViPham"] = entity.NoiDungViPham;
                if (entity.TieuThu1 != null)
                {
                    dr["TieuThu1"] = entity.TieuThu1;
                    dr["ThanhTien1"] = entity.TieuThu1 * entity.GiaBan1 * 1.15;
                }
                if (entity.TieuThu2 != null)
                {
                    dr["TieuThu2"] = entity.TieuThu2;
                    dr["ThanhTien2"] = entity.TieuThu2 * entity.GiaBan2 * 1.15;
                }
                if (entity.Ngay1 != null)
                {
                    dr["Ngay1"] = entity.Ngay1.Value.ToString("dd/MM/yyyy");
                    dr["SoTien1"] = entity.SoTien1;
                }
                if (entity.Ngay2 != null)
                {
                    dr["Ngay2"] = entity.Ngay2.Value.ToString("dd/MM/yyyy");
                    dr["SoTien2"] = entity.SoTien2;
                }
                if (entity.Ngay3 != null)
                {
                    dr["Ngay3"] = entity.Ngay3.Value.ToString("dd/MM/yyyy");
                    dr["SoTien3"] = entity.SoTien3;
                }

                dsBaoCao.Tables["GianLan"].Rows.Add(dr);
            }
            rptDSGianLan rpt = new rptDSGianLan();
            rpt.SetDataSource(dsBaoCao);
            frmShowBaoCao frm = new frmShowBaoCao(rpt);
            frm.ShowDialog();
        }

        private void dgvGianLan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        byte[] _file1=null;
        private void btnChonFile1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Files (.pdf)|*.pdf";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = File.OpenRead(dialog.FileName);
                _file1 = new byte[fs.Length];
                fs.Read(_file1, 0, (int)fs.Length);
            }
        }

        byte[] _file2=null;
        private void btnChonFile2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Files (.pdf)|*.pdf";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = File.OpenRead(dialog.FileName);
                _file2 = new byte[fs.Length];
                fs.Read(_file2, 0, (int)fs.Length);
            }
        }

        private void btnXemFile1_Click(object sender, EventArgs e)
        {
            if (_gianlan != null&&_gianlan.File1!=null)
            {
                frmPDFViewer frm = new frmPDFViewer(_gianlan.File1.ToArray());
                frm.ShowDialog();
            }
        }

        private void btnXemFile2_Click(object sender, EventArgs e)
        {
            if (_gianlan != null && _gianlan.File2 != null)
            {
                frmPDFViewer frm = new frmPDFViewer(_gianlan.File2.ToArray());
                frm.ShowDialog();
            }
        }

        byte[] _fileBB = null;
        private void btnChonBB_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Files (.pdf)|*.pdf";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = File.OpenRead(dialog.FileName);
                _fileBB = new byte[fs.Length];
                fs.Read(_fileBB, 0, (int)fs.Length);
            }
        }

        private void btnXemBB_Click(object sender, EventArgs e)
        {
            if (_gianlan != null && _gianlan.FileBienBan != null)
            {
                frmPDFViewer frm = new frmPDFViewer(_gianlan.FileBienBan.ToArray());
                frm.ShowDialog();
            }
        }

    }
}
