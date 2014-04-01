using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KTKS_DonKH.DAL.HeThong;
using KTKS_DonKH.LinQ;

namespace KTKS_DonKH.GUI.HeThong
{
    public partial class frmTaiKhoan : Form
    {
        CTaiKhoan _cTaiKhoan = new CTaiKhoan();
        int selectedindex = -1;
        public frmTaiKhoan()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            dgvDSTaiKhoan.AutoGenerateColumns = false;
            dgvDSTaiKhoan.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDSTaiKhoan.Font, FontStyle.Bold);
            dgvDSTaiKhoan.DataSource = _cTaiKhoan.LoadDSTaiKhoan();

            dgvPhanQuyen.AutoGenerateColumns = false;
            dgvPhanQuyen.ColumnHeadersDefaultCellStyle.Font = new Font(dgvPhanQuyen.Font, FontStyle.Bold);
        }

        private void Clear()
        {
            txtHoTen.Text = "";
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            selectedindex = -1;
            dgvDSTaiKhoan.DataSource = _cTaiKhoan.LoadDSTaiKhoan();
            dgvPhanQuyen.DataSource = null;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text.Trim() != "" && txtTaiKhoan.Text.Trim() != "" && txtMatKhau.Text.Trim() != "")
            {
                User nguoidung = new User();
                nguoidung.HoTen = txtHoTen.Text.Trim();
                nguoidung.TaiKhoan = txtTaiKhoan.Text.Trim();
                nguoidung.MatKhau = txtMatKhau.Text.Trim();
                nguoidung.MaKiemBamChi = txtMaKiemBamChi.Text.Trim();

                _cTaiKhoan.ThemTaiKhoan(nguoidung);

                Clear();
            }
            else
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (selectedindex != -1)
                if (MessageBox.Show("Bạn chắc chắn xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    User nguoidung = _cTaiKhoan.getUserbyID(int.Parse(dgvDSTaiKhoan["MaU", selectedindex].Value.ToString()));

                    _cTaiKhoan.XoaTaiKhoan(nguoidung);

                    Clear();
                }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedindex != -1)
                if (txtHoTen.Text.Trim() != "" && txtTaiKhoan.Text.Trim() != "" && txtMatKhau.Text.Trim() != "")
                {
                    User nguoidung = _cTaiKhoan.getUserbyID(int.Parse(dgvDSTaiKhoan["MaU", selectedindex].Value.ToString()));
                    nguoidung.HoTen = txtHoTen.Text.Trim();
                    nguoidung.MatKhau = txtMatKhau.Text.Trim();
                    nguoidung.MaKiemBamChi = txtMaKiemBamChi.Text.Trim();

                    if (nguoidung.TaiKhoan != txtTaiKhoan.Text.Trim())
                    {
                        nguoidung.TaiKhoan = txtTaiKhoan.Text.Trim();
                        _cTaiKhoan.SuaTaiKhoan(nguoidung, true);
                    }
                    else
                        _cTaiKhoan.SuaTaiKhoan(nguoidung, false);

                    Clear();
                }
                else
                    MessageBox.Show("Chưa nhập đủ thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvDSTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedindex = e.RowIndex;
                txtHoTen.Text = dgvDSTaiKhoan["HoTen", e.RowIndex].Value.ToString();
                txtTaiKhoan.Text = dgvDSTaiKhoan["TaiKhoan", e.RowIndex].Value.ToString();
                txtMatKhau.Text = dgvDSTaiKhoan["MatKhau", e.RowIndex].Value.ToString();
                txtMaKiemBamChi.Text = dgvDSTaiKhoan["MaKiemBamChi", e.RowIndex].Value.ToString();
                dgvPhanQuyen.DataSource = _cTaiKhoan.LoadDSRolebyUser(int.Parse(dgvDSTaiKhoan["MaU", e.RowIndex].Value.ToString()));
            }
            catch (Exception)
            {

            }
        }

        private void dgvDSTaiKhoan_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ///Cập nhật quyền trực tiếp khi click vào datagridview
            //if (e.ColumnIndex > 3)
            //{
            //    int MaR = 0;
            //    switch (dgvDSTaiKhoan.Columns[e.ColumnIndex].Name)
            //    {
            //        case "QTaiKhoan":
            //            MaR = 1;
            //            break;
            //        case "QCapNhat":
            //            MaR = 2;
            //            break;
            //        case "QNhanDonKH":
            //            MaR = 3;
            //            break;
            //        case "QQLDonKH":
            //            MaR = 4;
            //            break;
            //        case "QKTXM":
            //            MaR = 5;
            //            break;
            //        case "QQLKTXM":
            //            MaR = 6;
            //            break;
            //        case "QDCBD":
            //            MaR = 7;
            //            break;
            //        case "QCHDB":
            //            MaR = 8;
            //            break;
            //        case "QTTTL":
            //            MaR = 9;
            //            break;
            //    }
            //    bool ischecked = false;
            //    if (bool.Parse(dgvDSTaiKhoan[e.ColumnIndex, e.RowIndex].Value.ToString()) == true)
            //        ischecked = true;
            //    else
            //        ischecked = false;
            //    _cTaiKhoan.SuaQuyen(int.Parse(dgvDSTaiKhoan["MaU", e.RowIndex].Value.ToString()), MaR, ischecked);
            //}
        }

        private void dgvDSTaiKhoan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDSTaiKhoan.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvPhanQuyen_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvPhanQuyen.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvPhanQuyen_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            bool ischecked = false;
            if (bool.Parse(dgvPhanQuyen[e.ColumnIndex, e.RowIndex].Value.ToString()) == true)
                ischecked = true;
            else
                ischecked = false;
            _cTaiKhoan.SuaQuyen(int.Parse(dgvDSTaiKhoan["MaU", selectedindex].Value.ToString()), e.RowIndex + 1, dgvPhanQuyen.Columns[e.ColumnIndex].Name, ischecked);
        }
        
    }
}
