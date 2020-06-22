using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrungTamKhachHang.DAL.QuanTri;
using TrungTamKhachHang.DAL.LichDocSoThuTien;
using TrungTamKhachHang.LinQ;
using TrungTamKhachHang.BaoCao;
using TrungTamKhachHang.BaoCao.LichDocSoThuTien;
using TrungTamKhachHang.GUI.BaoCao;

namespace TrungTamKhachHang.GUI.LichDocSoThuTien
{
    public partial class frmLichThuTien : Form
    {
        string _mnu = "mnuLichThuTien";
        CLichThuTien _cLTT = new CLichThuTien();
        CLichDocSo _cLDS = new CLichDocSo();
        Lich_ThuTien _thutien = null;

        DateTimePicker _dtp = new DateTimePicker();
        Rectangle _rectangle;

        public frmLichThuTien()
        {
            InitializeComponent();

            dgvDot.Controls.Add(_dtp);
            _dtp.Visible = false;
            _dtp.Format = DateTimePickerFormat.Custom;
            _dtp.CustomFormat = "dd/MM/yyyy";
            _dtp.TextChanged += new EventHandler(dtp_TextChanged);
        }

        void dtp_TextChanged(object sender, EventArgs e)
        {
            dgvDot.CurrentCell.Value = _dtp.Text;
            if (dgvDot.Columns[dgvDot.CurrentCell.ColumnIndex].Name == "NgayThuTien_From")
            {
                DateTime NgayThuTien_From = _dtp.Value,
                    NgayThuTien_To = NgayThuTien_From.AddDays(1);
                //edit row 0
                if (NgayThuTien_From.DayOfWeek == DayOfWeek.Saturday)
                {
                    NgayThuTien_From = NgayThuTien_From.AddDays(2);
                    NgayThuTien_To = NgayThuTien_From.AddDays(1);
                }
                if (NgayThuTien_To.DayOfWeek == DayOfWeek.Saturday)
                {
                    NgayThuTien_To = NgayThuTien_To.AddDays(2);
                }
                int i = dgvDot.CurrentRow.Index;
                dgvDot["NgayThuTien_From", i].Value = NgayThuTien_From.ToString("dd/MM/yyyy");
                dgvDot["NgayThuTien_To", i].Value = NgayThuTien_To.ToString("dd/MM/yyyy");

                //edit row 1++
                while (i < dgvDot.RowCount - 1)
                {
                    DateTime date = DateTime.Parse(dgvDot.Rows[i].Cells["NgayThuTien_From"].Value.ToString());
                    NgayThuTien_From = date.AddDays(1);
                    NgayThuTien_To = NgayThuTien_From.AddDays(1);
                    if (NgayThuTien_From.DayOfWeek == DayOfWeek.Saturday)
                    {
                        NgayThuTien_From = NgayThuTien_From.AddDays(2);
                        NgayThuTien_To = NgayThuTien_From.AddDays(1);
                    }
                    if (NgayThuTien_To.DayOfWeek == DayOfWeek.Saturday)
                    {
                        NgayThuTien_To = NgayThuTien_To.AddDays(2);
                    }
                    dgvDot["NgayThuTien_From", i + 1].Value = NgayThuTien_From.ToString("dd/MM/yyyy");
                    dgvDot["NgayThuTien_To", i + 1].Value = NgayThuTien_To.ToString("dd/MM/yyyy");
                    i++;
                }
            }
        }

        private void frmLichThuTien_Load(object sender, EventArgs e)
        {
            dgvKy.AutoGenerateColumns = false;
            dgvDot.AutoGenerateColumns = false;

            dgvKy.DataSource = _cLTT.getDS();
        }

        public void Clear()
        {
            txtKy.Text = "";
            txtNam.Text = "";
            dateTu.Value = DateTime.Now;
            dateDen.Value = DateTime.Now;
            _thutien = null;
            dgvKy.DataSource = _cLTT.getDS();
            dgvDot.DataSource = null;
        }

        public void FillEntity(Lich_ThuTien thutien)
        {
            txtKy.Text = thutien.Ky.Value.ToString();
            txtNam.Text = thutien.Nam.Value.ToString();
            dateTu.Value = thutien.TuNgay.Value;
            dateDen.Value = thutien.DenNgay.Value;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CUser.CheckQuyen(_mnu, "Them"))
                {
                    int Ky = int.Parse(txtKy.Text.Trim());
                    int Nam = int.Parse(txtNam.Text.Trim());
                    if (_cLTT.checkExist(Ky, Nam) == true)
                    {
                        MessageBox.Show("Kỳ " + Ky + "/" + Nam + " đã tạo rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Lich_ThuTien en = new Lich_ThuTien();
                    en.Ky = Ky;
                    en.Nam = Nam;
                    en.TuNgay = dateTu.Value;
                    en.DenNgay = dateDen.Value;
                    if (_cLTT.Them(en) == true)
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
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
                if (CUser.CheckQuyen(_mnu, "Xoa"))
                {
                    if (_thutien != null && MessageBox.Show("Bạn chắc chắn Xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (_cLTT.Xoa(_thutien) == true)
                        {
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (CUser.CheckQuyen(_mnu, "Sua"))
                {
                    int Ky = int.Parse(txtKy.Text.Trim());
                    int Nam = int.Parse(txtNam.Text.Trim());
                    if ((_thutien.Ky != Ky || _thutien.Nam != Nam) && _cLTT.checkExist(Ky, Nam) == true)
                    {
                        MessageBox.Show("Kỳ " + Ky + "/" + Nam + " đã tạo rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _thutien.Ky = Ky;
                    _thutien.Nam = Nam;
                    _thutien.TuNgay = dateTu.Value;
                    _thutien.DenNgay = dateDen.Value;

                    foreach (DataGridViewRow item in dgvDot.Rows)
                    {
                        Lich_ThuTien_ChiTiet enCT = _thutien.Lich_ThuTien_ChiTiets.SingleOrDefault(itemA => itemA.IDDot == int.Parse(item.Cells["IDDot"].Value.ToString()));
                        if (item.Cells["NgayDoc"].Value != null)
                            enCT.NgayDoc = DateTime.Parse(item.Cells["NgayDoc"].Value.ToString());
                        if (item.Cells["NgayChuyenListing"].Value != null)
                            enCT.NgayChuyenListing = DateTime.Parse(item.Cells["NgayChuyenListing"].Value.ToString());
                        if (item.Cells["NgayThuTien_From"].Value != null)
                            enCT.NgayThuTien_From = DateTime.Parse(item.Cells["NgayThuTien_From"].Value.ToString());
                        if (item.Cells["NgayThuTien_To"].Value != null)
                            enCT.NgayThuTien_To = DateTime.Parse(item.Cells["NgayThuTien_To"].Value.ToString());
                        enCT.ModifyBy = CUser.MaUser;
                        enCT.ModifyDate = DateTime.Now;
                        _cLTT.SubmitChanges();
                    }

                    if (_cLTT.Sua(_thutien) == true)
                    {
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
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

        private void dgvKy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _thutien = _cLTT.get(int.Parse(dgvKy.CurrentRow.Cells["ID"].Value.ToString()));
                if (_thutien != null)
                {
                    FillEntity(_thutien);
                    dgvDot.DataSource = _thutien.Lich_ThuTien_ChiTiets.ToList();
                    if (dgvDot["NgayThuTien_From",0].Value == null)
                    {
                        Lich_DocSo _docso = _cLDS.get(_thutien.Ky.Value, _thutien.Nam.Value);
                        foreach (DataGridViewRow item in dgvDot.Rows)
                        {
                            item.Cells["NgayDoc"].Value = _docso.Lich_DocSo_ChiTiets[item.Index].NgayDoc;
                            item.Cells["NgayChuyenListing"].Value = _docso.Lich_DocSo_ChiTiets[item.Index].NgayChuyenListing;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void dgvDot_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (dgvDot.Columns[e.ColumnIndex].Name)
            {
                case "NgayChuyenListing":
                case "NgayThuTien_From":
                case "NgayThuTien_To":
                    _rectangle = dgvDot.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    _dtp.Size = new Size(_rectangle.Width, _rectangle.Height);
                    _dtp.Location = new Point(_rectangle.X, _rectangle.Y);
                    _dtp.Visible = true;
                    dgvDot.CurrentCell.Value = _dtp.Text;
                    break;
            }
        }

        private void dgvDot_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            _dtp.Visible = false;
        }

        private void dgvDot_Scroll(object sender, ScrollEventArgs e)
        {
            _dtp.Visible = false;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (_thutien != null)
            {
                dsBaoCao dsBaoCao = new dsBaoCao();
                foreach (Lich_ThuTien_ChiTiet item in _thutien.Lich_ThuTien_ChiTiets.ToList())
                {
                    DataRow dr = dsBaoCao.Tables["LichDocSoThuTien"].NewRow();
                    dr["LoaiBaoCao"] = "LỊCH THU TIỀN DỰ KIẾN KỲ " + _thutien.Ky + " NĂM " + _thutien.Nam;
                    dr["TuNgay"] = _thutien.TuNgay.Value.ToString("dd/MM/yyyy");
                    dr["DenNgay"] = _thutien.DenNgay.Value.ToString("dd/MM/yyyy");
                    dr["Dot"] = item.Lich_Dot.Name;
                    dr["NgayDoc"] = item.NgayDoc.Value.Day;
                    dr["NgayChuyenListing"] = item.NgayChuyenListing.Value.Day;
                    if (item.NgayThuTien_From.Value.Day != item.NgayThuTien_To.Value.Day)
                        dr["NgayDocSoThuTien"] = item.NgayThuTien_From.Value.Day.ToString("00") + "-" + item.NgayThuTien_To.Value.ToString("dd/MM/yyyy");
                    else
                        dr["NgayDocSoThuTien"] = item.NgayThuTien_From.Value.ToString("dd/MM/yyyy");
                    //dr["TB1_From"] = item.Lich_Dot.TB1_From.Value.ToString("000000000").Insert(4, ".").Insert(2, ".");
                    //dr["TB1_To"] = item.Lich_Dot.TB1_To.Value.ToString("000000000").Insert(4, ".").Insert(2, ".");
                    //dr["TB2_From"] = item.Lich_Dot.TB2_From.Value.ToString("000000000").Insert(4, ".").Insert(2, ".");
                    //dr["TB2_To"] = item.Lich_Dot.TB2_To.Value.ToString("000000000").Insert(4, ".").Insert(2, ".");
                    //dr["TP1_From"] = item.Lich_Dot.TP1_From.Value.ToString("000000000").Insert(4, ".").Insert(2, ".");
                    //dr["TP1_To"] = item.Lich_Dot.TP1_To.Value.ToString("000000000").Insert(4, ".").Insert(2, ".");
                    //dr["TP2_From"] = item.Lich_Dot.TP2_From.Value.ToString("000000000").Insert(4, ".").Insert(2, ".");
                    //dr["TP2_To"] = item.Lich_Dot.TP2_To.Value.ToString("000000000").Insert(4, ".").Insert(2, ".");
                    dr["TB1_From"] = item.Lich_Dot.TB1_From.Insert(4, ".").Insert(2, ".");
                    dr["TB1_To"] = item.Lich_Dot.TB1_To.Insert(4, ".").Insert(2, ".");
                    dr["TB2_From"] = item.Lich_Dot.TB2_From.Insert(4, ".").Insert(2, ".");
                    dr["TB2_To"] = item.Lich_Dot.TB2_To.Insert(4, ".").Insert(2, ".");
                    dr["TP1_From"] = item.Lich_Dot.TP1_From.Insert(4, ".").Insert(2, ".");
                    dr["TP1_To"] = item.Lich_Dot.TP1_To.Insert(4, ".").Insert(2, ".");
                    dr["TP2_From"] = item.Lich_Dot.TP2_From.Insert(4, ".").Insert(2, ".");
                    dr["TP2_To"] = item.Lich_Dot.TP2_To.Insert(4, ".").Insert(2, ".");
                    dsBaoCao.Tables["LichDocSoThuTien"].Rows.Add(dr);
                }

                rptLichThuTien rpt = new rptLichThuTien();
                rpt.SetDataSource(dsBaoCao);
                frmShowBaoCao frm = new frmShowBaoCao(rpt);
                frm.Show();
            }
        }
    }
}
