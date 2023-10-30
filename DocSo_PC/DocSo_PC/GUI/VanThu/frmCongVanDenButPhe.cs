using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DocSo_PC.DAL.VanThu;
using DocSo_PC.LinQ;
using DocSo_PC.DAL;
using DocSo_PC.DAL.QuanTri;
using DocSo_PC.BaoCao;
using DocSo_PC.GUI.BaoCao;
using System.IO;
using Spire.Pdf;

namespace DocSo_PC.GUI.VanThu
{
    public partial class frmCongVanDenButPhe : Form
    {
        string _mnu = "mnuCongVanDen";
        DataTable _dt = new DataTable();
        string _MaTo = ""; int _ID = -1;
        CCongVanDen _cCVD = new CCongVanDen();
        CongVanDen _enCVD = null;
        CThuongVu _cThuongVu = new CThuongVu();

        public frmCongVanDenButPhe()
        {
            InitializeComponent();
        }

        public frmCongVanDenButPhe(string MaTo)
        {
            InitializeComponent();
            _MaTo = MaTo;
        }

        public frmCongVanDenButPhe(int ID)
        {
            InitializeComponent();
            _ID = ID;
        }

        private void frmCongVanDenButPhe_Load(object sender, EventArgs e)
        {
            dgvDuyet.AutoGenerateColumns = false;
            if (_MaTo != "")
                dgvDuyet.DataSource = _cCVD.getDS_ToMaHoa();
            else
                if (_ID > 0)
                    dgvDuyet.DataSource = _cCVD.get_ID(_ID.ToString());
        }

        int _index = 0;
        DataTable _dtDuyet = null;
        public void Clear_ButPhe()
        {
            _enCVD = null;
            chkXem.Checked = false;
            chkCapNhat.Checked = false;
            chkTinhTieuThu.Checked = false;
            chkTheoDoi.Checked = false;
            chkKiemTraLaiHienTruong.Checked = false;
            chkBaoThay.Checked = false;
            chkDeBiet.Checked = false;
            chkKhac.Checked = false;
            txtKhac_GhiChu.Text = "";
            _index = 0;
            _dtDuyet = null;
            btnTruoc.Visible = false;
            btnSau.Visible = false;
            pictureBox.Image = null;
        }

        private void dgvDuyet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Clear_ButPhe();
                _enCVD = _cCVD.get(int.Parse(dgvDuyet["ID_Duyet", e.RowIndex].Value.ToString()));
                if (_enCVD != null)
                {
                    chkXem.Checked = _enCVD.Xem;
                    chkCapNhat.Checked = _enCVD.CapNhat;
                    chkTinhTieuThu.Checked = _enCVD.TinhTieuThu;
                    chkTheoDoi.Checked = _enCVD.TheoDoi;
                    chkKiemTraLaiHienTruong.Checked = _enCVD.KiemTraLaiHienTruong;
                    chkBaoThay.Checked = _enCVD.BaoThay;
                    chkDeBiet.Checked = _enCVD.DeBiet;
                    chkKhac.Checked = _enCVD.Khac;
                    txtKhac_GhiChu.Text = _enCVD.Khac_GhiChu;
                    chkDaXuLy.Checked = _enCVD.DaXuLy;
                    if (_enCVD.DaXuLy_Ngay != null)
                        txtDaXuLy_Ngay.Text = _enCVD.DaXuLy_Ngay.Value.ToString();
                }
                if (dgvDuyet["TableName_Duyet", e.RowIndex].Value.ToString() == "")
                {
                    MessageBox.Show("Không có File", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;
                }
                else
                {
                    _dtDuyet = _cThuongVu.getFile(dgvDuyet["TableName_Duyet", e.RowIndex].Value.ToString(), int.Parse(dgvDuyet["IDCT_Duyet", e.RowIndex].Value.ToString()));
                    if (_dtDuyet != null && _dtDuyet.Rows.Count > 0)
                    {
                        int index = -1;
                        for (int i = 0; i < _dtDuyet.Rows.Count; i++)
                            if (_dtDuyet.Rows[i]["Type"].ToString().ToLower().Contains("pdf"))
                                _cCVD.viewPDF(i, (byte[])_dtDuyet.Rows[i]["File"]);
                            else
                                if (index == -1)
                                    index = i;
                        if (index > -1)
                        {
                            pictureBox.Image = _cCVD.byteArrayToImage((byte[])_dtDuyet.Rows[index]["File"]);
                            if (_dtDuyet.Rows.Count > 1)
                            {
                                btnTruoc.Visible = true;
                                btnSau.Visible = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            if (_dtDuyet != null && _dtDuyet.Rows.Count > 0)
            {
                while (_index > 0)
                {
                    _index--;
                    if (!_dtDuyet.Rows[_index]["Type"].ToString().ToLower().Contains("pdf"))
                        break;
                }
                pictureBox.Image = _cCVD.byteArrayToImage((byte[])_dtDuyet.Rows[_index]["File"]);
            }
        }

        private void btnSau_Click(object sender, EventArgs e)
        {
            if (_dtDuyet != null && _dtDuyet.Rows.Count > 0)
            {
                while (_index < _dtDuyet.Rows.Count - 1)
                {
                    _index++;
                    if (!_dtDuyet.Rows[_index]["Type"].ToString().ToLower().Contains("pdf"))
                        break;
                }
                pictureBox.Image = _cCVD.byteArrayToImage((byte[])_dtDuyet.Rows[_index]["File"]);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (CNguoiDung.CheckQuyen(_mnu, "Sua"))
                {
                    if (_enCVD != null)
                    {
                        //_enCVD.Xem = chkXem.Checked;
                        //_enCVD.CapNhat = chkCapNhat.Checked;
                        //_enCVD.TinhTieuThu = chkTinhTieuThu.Checked;
                        //_enCVD.TheoDoi = chkTheoDoi.Checked;
                        //_enCVD.KiemTraLaiHienTruong = chkKiemTraLaiHienTruong.Checked;
                        //_enCVD.BaoThay = chkBaoThay.Checked;
                        //_enCVD.DeBiet = chkDeBiet.Checked;
                        //if (chkKhac.Checked)
                        //{
                        //    _enCVD.Khac = true;
                        //    _enCVD.Khac_GhiChu = txtKhac_GhiChu.Text.Trim();
                        //}
                        //else
                        //{
                        //    _enCVD.Khac = false;
                        //    _enCVD.Khac_GhiChu = null;
                        //}
                        //_enCVD.Duyet_Ngay = DateTime.Now;
                        if (chkDaXuLy.Checked)
                        {
                            _enCVD.DaXuLy = true;
                            _enCVD.DaXuLy_Ngay = DateTime.Now;
                        }
                        else
                        {
                            _enCVD.DaXuLy = true;
                            _enCVD.DaXuLy_Ngay = DateTime.Now;
                        }
                        _cCVD.SubmitChanges();
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear_ButPhe();
                    }
                }
                else
                    MessageBox.Show("Bạn không có quyền Sửa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDuyet_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDuyet.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 4);
            }
        }

        private void chkDaXuLy_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKhac.Checked)
                txtDaXuLy_Ngay.ReadOnly = false;
            else
                txtDaXuLy_Ngay.ReadOnly = true;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (_enCVD != null)
                {
                    dsBaoCao dsBaoCao = new dsBaoCao();
                    PrintDialog printDialog = new PrintDialog();
                    if (printDialog.ShowDialog() == DialogResult.OK)
                    {
                        DataTable dt = _cThuongVu.getFile(_enCVD.TableName, _enCVD.IDCT.Value);
                        if (dt != null && dt.Rows.Count > 0)
                            foreach (DataRow itemC in dt.Rows)
                            {
                                if (itemC["Type"].ToString().ToLower().Contains("pdf"))
                                {
                                    File.WriteAllBytes(@"D:\temp.pdf", (byte[])itemC["File"]);
                                    PdfDocument pdf = new PdfDocument();
                                    pdf.LoadFromFile(@"D:\temp.pdf");
                                    pdf.PrintSettings.PrinterName = printDialog.PrinterSettings.PrinterName;
                                    pdf.Print();
                                }
                                else
                                {
                                    DataRow dr = dsBaoCao.Tables["BaoCao"].NewRow();
                                    dr["Image"] = (byte[])itemC["File"];
                                    dsBaoCao.Tables["BaoCao"].Rows.Add(dr);
                                }
                            }
                        if (dsBaoCao.Tables["BaoCao"].Rows.Count > 0)
                        {
                            frmShowBaoCao2 frm = new frmShowBaoCao2(dsBaoCao.Tables["BaoCao"]);
                            frm.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
