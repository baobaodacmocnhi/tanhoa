using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThuTien.DAL.QuanTri;
using ThuTien.DAL.ChuyenKhoan;
using ThuTien.LinQ;
using ThuTien.DAL.Doi;
using ThuTien.BaoCao;
using ThuTien.BaoCao.Doi;
using ThuTien.GUI.BaoCao;

namespace ThuTien.GUI.Doi
{
    public partial class frmGuiThongBao : Form
    {
        string _mnu = "mnuGuiThongBao";
        CHoaDon _cHoaDon = new CHoaDon();
        CGuiThongBao _cGuiThongBao = new CGuiThongBao();
        CTo _cTo = new CTo();
        CNguoiDung _cNguoiDung = new CNguoiDung();

        public frmGuiThongBao()
        {
            InitializeComponent();
        }

        private void frmGuiThongBao_Load(object sender, EventArgs e)
        {
            dgvGuiThongBao.AutoGenerateColumns = false;
            btnXemAll.PerformClick();
        }

        private void btnXemAll_Click(object sender, EventArgs e)
        {
            dgvGuiThongBao.DataSource = _cGuiThongBao.GetDS();
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Them"))
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
                                if (string.IsNullOrEmpty(item[0].ToString()) || item[0].ToString().Replace(" ", "").Length == 11)
                                {
                                    if (_cGuiThongBao.CheckExist(item[0].ToString().Replace(" ", "")) == true)
                                    {
                                        if (MessageBox.Show("Danh Bộ " + item[0].ToString() + " đã có\nBạn có chắc chắn thêm?", "Xác nhận thêm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                        {
                                            TT_GuiThongBao entity = new TT_GuiThongBao();
                                            entity.DanhBo = item[0].ToString().Replace(" ", "");
                                            _cGuiThongBao.Them(entity);
                                        }
                                    }
                                    else
                                    {
                                        TT_GuiThongBao entity = new TT_GuiThongBao();
                                        entity.DanhBo = item[0].ToString().Replace(" ", "");
                                        _cGuiThongBao.Them(entity);
                                    }
                                }
                            MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnXemAll.PerformClick();
                        }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi, Vui lòng thử lại\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Bạn không có quyền Thêm Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXem_HD_Click(object sender, EventArgs e)
        {
            dgvGuiThongBao.DataSource = _cGuiThongBao.GetDS(int.Parse(cmbFromDot.SelectedItem.ToString()), int.Parse(cmbToDot.SelectedItem.ToString()));
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CNguoiDung.CheckQuyen(_mnu, "Xoa"))
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    try
                    {
                        foreach (DataGridViewRow item in dgvGuiThongBao.SelectedRows)
                        {
                            TT_GuiThongBao entity = _cGuiThongBao.Get(int.Parse(item.Cells["ID"].Value.ToString()));
                            _cGuiThongBao.Xoa(entity);
                        }
                        MessageBox.Show("Thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnXemAll.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi, Vui lòng thử lại\n" + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
            else
                MessageBox.Show("Bạn không có quyền Xóa Form này", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            dsBaoCao ds = new dsBaoCao();
            foreach (DataGridViewRow item in dgvGuiThongBao.SelectedRows)
            {
                DataRow dr = ds.Tables["DSHoaDon"].NewRow();
                dr["DanhBo"] = item.Cells["DanhBo"].Value.ToString().Insert(4, " ").Insert(8, " ");
                dr["HoTen"] = item.Cells["HoTen"].Value;
                dr["DiaChi"] = item.Cells["DiaChi"].Value;
                dr["SoPhatHanh"] = item.Cells["HopDong"].Value;
                dr["To"] = item.Cells["To"].Value;
                dr["HanhThu"] = item.Cells["HanhThu"].Value;
                ds.Tables["DSHoaDon"].Rows.Add(dr);
                TT_GuiThongBao entity = _cGuiThongBao.Get(int.Parse(item.Cells["ID"].Value.ToString()));
                entity.In = true;
                _cGuiThongBao.Sua(entity);
            }
            rptGuiThongBao rpt = new rptGuiThongBao();
            rpt.SetDataSource(ds);
            frmBaoCao frm = new frmBaoCao(rpt);
            frm.Show();
        }

        private void dgvGuiThongBao_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvGuiThongBao.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvGuiThongBao_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvGuiThongBao.Columns[e.ColumnIndex].Name == "DanhBo" && e.Value != null && e.Value.ToString().Length == 11)
            {
                e.Value = e.Value.ToString().Insert(4, " ").Insert(8, " ");
            }
        }

        

        
    }
}
